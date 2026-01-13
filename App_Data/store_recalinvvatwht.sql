use job_sss
go
create procedure RecalInvoiceVATWHT
(
@docno varchar(20)
)
as
begin
update Job_ClearDetail set 
Tax50Tavi=UsedAmount*(Tax50TaviRate*0.01) where Tax50TaviRate>0 
and SICode like 'S%' and LinkBillNo=@docno;

update Job_ClearDetail set 
ChargeVAT=UsedAmount*(VATRate*0.01) where VATRate>0 
and SICode like 'S%' and LinkBillNo=@docno;

update Job_ClearDetail set 
BNet=UsedAmount+ChargeVAT-Tax50Tavi,
FNet=(UsedAmount+ChargeVAT-Tax50Tavi)/CurRate
where SICode like 'S%' and LinkBillNo=@docno;

UPDATE a
SET a.AdvTotal=ISNULL(b.AdvTotal,0)
,a.TotalExpense=ISNULL(b.TotalNET,0)
,a.ClearTotal=ISNULL(b.AdvTotal-b.TotalNET,0)
,a.ClearVat=ISNULL(b.TotalVAT,0)
,a.ClearWht=ISNULL(b.TotalWHT,0)
,a.ClearNet=ISNULL(b.TotalNET,0)
,a.ClearBill=ISNULL(b.TotalBill,0)
,a.ClearCost=ISNULL(b.TotalCost,0)
FROM Job_ClearHeader a LEFT JOIN (
  SELECT BranchCode,ClrNo,Sum(AdvAmount) as AdvTotal,
  Sum(ChargeVAT) as TotalVAT,Sum(Tax50Tavi) as TotalWHT,Sum(BNet) as TotalNET,
  Sum(CASE WHEN BPrice >0 THEN BPrice ELSE 0 END) as TotalBill,
  Sum(CASE WHEN BPrice =0 THEN BCost ELSE 0 END) as TotalCost
  FROM Job_ClearDetail
  GROUP BY BranchCode,ClrNo
) b
ON a.BranchCode=b.BranchCode AND a.ClrNo=b.ClrNo
where exists(
select 1 from Job_ClearDetail where
LinkBillNo=@docno and ClrNo=a.ClrNo)

update a
set a.Amt50Tavi=b.Tax50Tavi,
a.TotalAmt=b.BNet,
a.FTotalAmt=b.BNet/c.ExchangeRate
from Job_InvoiceDetail a
inner join Job_ClearDetail b
on a.DocNo=b.LinkBillNo
and a.ItemNo=b.LinkItem
inner join Job_InvoiceHeader c 
on a.DocNo=c.DocNo
where a.SICode like 'S%' and a.Amt50Tavi>0 
and a.DocNo=@docno;

update h
set h.TotalAdvance=ROUND(d.TotalAdvance,2),
h.TotalCharge=ROUND(d.TotalCharge,2),
h.TotalIsTaxCharge=ROUND(d.TotalIsTaxCharge,2),
h.TotalIs50Tavi=ROUND(d.TotalIs50Tavi,2),
h.TotalVAT=ROUND(d.TotalVAT,2),
h.Total50Tavi=ROUND(d.Total50Tavi,2),
h.SumDiscount=ROUND(d.SumDiscount,2),
h.DiscountCal=ROUND(d.TotalNet*(h.DiscountRate*0.01),2),
h.TotalNet=ROUND(d.TotalNet-(d.TotalNet*(h.DiscountRate*0.01)),2),
h.ForeignNet=ROUND((d.TotalNet-(d.TotalNet*(h.DiscountRate*0.01)))/h.ExchangeRate,2)
from Job_InvoiceHeader h
inner join (
	select BranchCode,DocNo,
	sum((CASE WHEN AmtCharge>0 THEN Amt-AmtDiscount ELSE 0 END)) as TotalCharge,
	sum((CASE WHEN AmtAdvance>0 THEN TotalAmt ELSE 0 END)) as TotalAdvance,
	sum(case when IsTaxCharge=1 And AmtCharge>0 then Amt-AmtDiscount else 0 end) as TotalIsTaxCharge, 
	sum(case when Is50Tavi=1 And AmtCharge>0 then Amt-AmtDiscount else 0 end) as TotalIs50Tavi,
	sum(case when AmtCharge>0 then AmtVat else 0 end) as TotalVAT,
	sum(case when AmtCharge>0 then Amt50Tavi else 0 end) as Total50Tavi,
    sum(AmtDiscount) as SumDiscount,
	sum(TotalAmt-AmtCredit) as TotalNet
	from Job_InvoiceDetail
	group by BranchCode,DocNo
) d
on h.BranchCode=d.BranchCode
and h.DocNo=d.DocNo 
where h.DocNo=@docno;

update a
set a.AmtWH=b.Total50Tavi,
a.AmtTotal=b.TotalNet,
a.AmtForeign=b.ForeignNet
from Job_BillAcceptDetail a
inner join Job_InvoiceHeader b 
on a.InvNo=b.DocNo 
where b.DocNo =@docno;

UPDATE a
SET a.TotalCustAdv=ISNULL(b.SumCustAdvance,0),
a.TotalAdvance=ISNULL(b.SumAdvance,0),
a.TotalChargeVAT=ISNULL(b.SumChargeVAT,0),
a.TotalChargeNonVAT=ISNULL(b.SumChargeNonVAT,0),
a.TotalVAT=ISNULL(b.SumVAT,0),
a.TotalWH=ISNULL(b.SumWH,0),
a.TotalDiscount=ISNULL(b.SumDiscount,0),
a.TotalNet=ISNULL(b.SumNet,0)
FROM Job_BillAcceptHeader a 
LEFT JOIN (
    SELECT BranchCode,BillAcceptNo,
    SUM(AmtCustAdvance) as SumCustAdvance,
    SUM(AmtAdvance) as SumAdvance,
    SUM(AmtChargeVAT) as SumChargeVAT,
    SUM(AmtChargeNonVAT) as SumChargeNonVAT,
    SUM(AmtVAT) as SumVAT,
    SUM(AmtWH) as SumWH,
    SUM(AmtDiscount) as SumDiscount,
    SUM(AmtTotal) as SumNet
    FROM Job_BillAcceptDetail
    GROUP BY BranchCode,BillAcceptNo
) b
ON a.BranchCode=b.BranchCode
AND a.BillAcceptNo=b.BillAcceptNo
WHERE exists(
select 1 from Job_BillAcceptDetail where InvNo=@docno and BillAcceptNo=a.BillAcceptNo
)
end

