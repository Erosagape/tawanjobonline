/**MIGRATION FROM EasyShipping TO Job_Online**/
--Job Order--
ALTER TABLE Job_Order ADD [DeliveryNo] nvarchar(100) NULL
ALTER TABLE Job_Order ADD [DeliveryTo] nvarchar(1000) NULL
ALTER TABLE Job_Order ADD [DeliveryAddr] nvarchar(MAX) NULL
ALTER TABLE Job_Order ADD [CreateDate] datetime NULL
--Mas_User
ALTER TABLE Mas_User ADD [DeptID] nvarchar(10) NULL
--Mas_Company
ALTER TABLE Mas_Company ADD [WEB_SITE] nvarchar(MAX) null
--Mas_Vender
ALTER TABLE Mas_Vender ADD BranchCode nvarchar(10) NULL
ALTER TABLE Mas_Vender ADD WEB_SITE nvarchar(MAX) NULL
--Job_ClearDetail
ALTER TABLE Job_ClearDetail ADD AdvItemNo int
ALTER TABLE Job_ClearDetail ADD LinkBillNo varchar(50)
ALTER TABLE Job_ClearDetail ADD VATType int
ALTER TABLE Job_ClearDetail ADD VATRate float
ALTER TABLE Job_ClearDetail ADD Tax50TaviRate float
ALTER TABLE Job_ClearDetail ADD Qno varchar(15)
ALTER TABLE Job_ClearDetail ADD FNet float
ALTER TABLE Job_ClearDetail ADD BNet float
--UPDATE DATA CLEAR DETAIL
UPDATE c
SET c.LinkBillNo=d.DNNo,c.LinkItem=d.LinkItem,c.FNet=d.FPrice,c.BNet=d.BPrice,
c.VATType=b.IsTaxCharge,c.VATRate=(case when c.ChargeVAT>0 THEN 7 ELSE 0 END),c.Tax50TaviRate=b.Rate50Tavi
FROM Job_ClearDetail c inner join Job_Detail d
on c.BranchCode=d.BranchCode and c.JobNo=d.JNo
and c.ClrNo=d.ClearingNO
and c.ItemNo=d.LinkItem
inner join Job_BillingDetail b
on d.BranchCode=b.BranchCode and d.DNNo=b.DocNo and d.LinkItem=b.ItemNo
where d.DNNo<>'' AND c.LinkBillNo IS NULL
--Job_ClearHeader
ALTER TABLE Job_ClearHeader add CTN_NO nvarchar(100)
ALTER TABLE Job_ClearHeader add ClearTotal float
ALTER TABLE Job_ClearHeader add ClearVat float
ALTER TABLE Job_ClearHeader add ClearWht float
ALTER TABLE Job_ClearHeader add ClearNet float
ALTER TABLE Job_ClearHeader add ClearBill float
ALTER TABLE Job_ClearHeader add ClearCost float
--Job Service Single
ALTER TABLE Job_SrvSingle add GroupCode nvarchar(10)
ALTER TABLE Job_SrvSingle add GLAccountCodeCost nvarchar(10)
ALTER TABLE Job_SrvSingle add GLAccountCodeSales nvarchar(10)
--Update Data ClearHeader
update h
set 
h.ClearBill =c.ClearBill,
h.ClearCost=c.ClearCost,
h.ClearNet=c.ClearNet,
h.ClearVat=c.ClearVat,
h.ClearWht=c.ClearWht,
h.ClearTotal=c.ClearTotal
from Job_ClearHeader h inner join (
select d.BranchCode,d.ClrNo,
sum(case when s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as ClearBill,
sum(case when s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as ClearCost,
sum(d.ChargeVAT) as ClearVat,sum(d.Tax50Tavi) as ClearWht,
sum(d.UsedAmount+d.ChargeVAT-d.Tax50Tavi) as ClearNet,
sum(d.UsedAmount) as ClearTotal
from Job_ClearDetail d inner join Job_SrvSingle s 
on d.SICode=s.SICode 
group by d.BranchCode,d.ClrNo 
) c on h.BranchCode=c.BranchCode and h.ClrNo=c.ClrNo
where h.ClearTotal is null
--insert clear frpm job_detail without clearing
INSERT INTO Job_ClearDetail
select c.BranchCode	,
'AUTOCLR'+FORMAT(DENSE_RANK() OVER (ORDER BY d.DocNo),'00000'),
ROW_NUMBER() OVER(PARTITION BY d.DocNo ORDER BY d.DocNo),
c.LinkItem	,
c.STCode	,
c.SICode	,
c.SDescription	,
c.VenderCode	,
c.Qty	,
c.UnitCode	,
c.CurrencyCode	,
c.CurRate	,
c.UnitPrice	,
c.FPrice	,
c.BPrice	,
c.QUnitPrice	,
c.QFPrice	,
c.QBPrice	,
c.UnitCost	,
c.FCost	,
c.BCost	,
((d.AmtAdvance+d.AmtCharge)*h.VATRate*0.01)	,
c.Tax50Tavi	,
''	,
0	,
(d.AmtCharge+d.AmtAdvance)	,
c.IsQuoItem	,
c.RSlipNO	,
c.Sremark	,
0	,
0	,
''	,
''	,
''	,
''	,
c.AirQtyStep	,
c.StepSub	,
c.JNo	,
0	,
c.DNNo	,
1	,
h.VATRate	,
d.Rate50Tavi	,
''	,
(((d.AmtAdvance+d.AmtCharge)*(h.VATRate-d.Rate50Tavi)*0.01)/h.ExchangeRate)	,
((d.AmtAdvance+d.AmtCharge)*(h.VATRate-d.Rate50Tavi)*0.01)	
from Job_Detail c inner join Job_BillingDetail d
on c.BranchCode=d.BranchCode and c.DNNo=d.DocNo 
and c.LinkItem=d.ItemNo
inner join Job_BillingHeader h
on d.BranchCode=h.BranchCode and d.DocNo=h.DocNo
where isnull(c.ClearingNO,'') ='' and c.DNNo<>''
and isnull(h.CancelProve,'')=''
order by d.DocNo
--insert clear header
insert into Job_ClearHeader 
select d.BranchCode,
d.ClrNo,
MAX(isnull(i.DocDate,j.DocDate)),
MAX(isnull(i.DocDate,j.DocDate)),
MAX(i.EmpCode),
'',
0,
MAX(j.JobType),
MAX(j.JNo),
SUBSTRING(MAX(j.InvNo),1,100),
0,
0,
0,
sum(d.UsedAmount),
'',
'',
null,
null,
'',
null,
null,
'',
'',
'',
null,
null,
'',
'',
SUM(d.UsedAmount),
sum(d.ChargeVAT),
sum(d.Tax50Tavi),
sum(d.BNet),
sum(d.BPrice),
sum(d.BCost)
from Job_ClearDetail d left join Job_ClearHeader h
on d.BranchCode=h.BranchCode and d.ClrNo=h.ClrNo
inner join Job_BillingHeader i
on d.BranchCode=i.BranchCode and d.LinkBillNo=i.DocNo
inner join Job_Order j on 
d.BranchCode=j.BranchCode and 
d.JobNo=j.JNo
where h.ClrNo is null and isnull(i.CancelProve,'')=''
group by d.BranchCode,d.ClrNo
--Update data
update Mas_Company SET Is19bis='' where Is19bis is null
update Mas_Company SET MgrSeq='' where MgrSeq is null
update Mas_Company SET LevelNoExp='' where LevelNoExp is null
update Mas_Company SET LevelNoImp='' where LevelNoImp is null
update Mas_Company SET ISCustomerSign='' where ISCustomerSign is null
update Mas_Company SET ISCustomerSignInv='' where ISCustomerSignInv is null
update Mas_Company SET ISCustomerSignDec='' where ISCustomerSignDec is null
update Mas_Company SET ISCustomerSignECon='' where ISCustomerSignECon is null
update Mas_Company SET IsShippingCannotSign='' where IsShippingCannotSign is null
update Mas_vender set BranchCode='0000' where BranchCode is null
update Job_ClearDetail set FNet=UsedAmount+ChargeVAT-Tax50Tavi/CurRate where FNet Is NULL and CurRate>0
update Job_ClearDetail set BNet=UsedAmount+ChargeVAT-Tax50Tavi where BNet Is NULL
update Job_ClearHeader set ClearTotal=0,ClearVat=0,ClearWht=0,ClearNet=0,ClearBill=0,ClearCost=0 where TotalExpense=0 and cleartotal is null
--delete duplicate data in table invoice

WITH cte AS (
    SELECT 
        BranchCode, 
        DocNo, 
        ItemNo, 
        ROW_NUMBER() OVER (
            PARTITION BY 
                BranchCode, 
                DocNo, 
                ItemNo
            ORDER BY 
                BranchCode, 
                DocNo, 
                ItemNo
        ) row_num
     FROM 
        job_bop.dbo.Job_BillingDetail
)
DELETE FROM cte
WHERE row_num > 1;
