use apllbkk
go
with cl
as
(
select d.BranchCode,d.DocNo as LinkBillNo,d.ItemNo as LinkItem,d.SICode,
d.Amt,s.ClrAmount,s.ClrNo,s.ItemNo,
s.JobNo,h.RefNo,h.DocDate 
from Job_InvoiceDetail d
inner join Job_InvoiceHeader h
on d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
left join Job_ClearDetail c
ON d.BranchCode=c.BranchCode AND d.DocNo=c.LinkBillNo
AND d.ItemNo=c.LinkItem,
(
SELECT d.BranchCode,d.JobNo,d.ClrNo,d.ItemNo,d.SICode,SUM(d.UsedAmount) as ClrAmount
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
WHERE ISNULL(h.CancelProve,'')='' AND ISNULL(d.LinkBillNo,'')=''
group by d.BranchCode,d.JobNo,d.ClrNo,d.ItemNo,d.SICode
) s
where ISNULL(c.ClrNo,'')='' AND ISNULL(h.CancelProve,'')=''
AND d.BranchCode=s.BranchCode AND CHARINDEX(s.JobNo,h.RefNo)>0 AND d.SICode=s.SICode
) 
update cd
SET cd.LinkBillNo=cl.LinkBillNo,
cd.LinkItem=cl.LinkItem
from Job_ClearDetail cd 
inner join cl
ON cd.BranchCode=cl.BranchCode
AND cd.ClrNo=cl.ClrNo
AND cd.ItemNo=cl.ItemNo