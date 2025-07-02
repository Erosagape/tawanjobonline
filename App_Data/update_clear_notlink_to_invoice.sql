/**update job ไม่ ลิ้ง invoice**/
--select a.LinkBillNo,a.LinkItem,a.SICode,a.UsedAmount,cd.ItemNo
update a set a.LinkBillNo=cd.DocNo,a.LinkItem=cd.ItemNo
from Job_ClearDetail a
inner join Job_ClearHeader ch 
on a.ClrNo=ch.ClrNo and ch.DocStatus<>99
left join Job_InvoiceDetail b
on a.LinkBillNo=b.DocNo 
and a.LinkItem=b.ItemNo
left join Job_InvoiceDetail cd
on a.LinkBillNo=cd.DocNo and a.SICode=cd.SICode 
where a.LinkBillNo<>'' and a.LinkItem>0  
and b.DocNo is null 

--select distinct i.DocNo,i.RefNo,d.ItemNo,d.SICode,d.ExpSlipNO,d.Amt,c.UsedAmount,c.LinkBillNo,c.LinkItem
--/*
update c
set c.LinkBillNo=d.DocNo,c.LinkItem=d.ItemNo 
--*/
from Job_InvoiceHeader i 
inner join Job_InvoiceDetail d
on i.DocNo=d.DocNo 
left join Job_ClearDetail c 
on i.RefNo=c.JobNo and d.SICode=c.SICode
where isnull(i.CancelProve,'')=''
--and c.JobNo='DI25010097'
and d.DocNo <>c.LinkBillNo 
and d.ItemNo<>c.LinkItem
and not exists(
   select 1 from Job_ClearDetail 
   where LinkBillNo =i.DocNo and LinkItem>0
   and clrno not in(select ClrNo from Job_ClearHeader where DocStatus=99)
)
/*
and exists(
select RefNo,count(*) from Job_InvoiceHeader 
where CancelPRove=''
and RefNo=i.RefNo
group by RefNo 
having count(*)>1
)
*/
--order by 1 desc