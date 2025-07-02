select d.DocNo,h.RefNo,h.BillAcceptNo,d.ItemNo,d.SICode,d.SDescription,r.ReceiptNo
from 
Job_InvoiceDetail d
left join Job_ReceiptDetail r on 
d.DocNo=r.InvoiceNo and d.ItemNo=r.InvoiceItemNo
inner join Job_InvoiceHeader h
on d.DocNo=h.DocNo and isnull(h.CancelProve,'')=''
left join Job_ClearDetail c
on d.docNo=c.LinkBillNo and d.ItemNo=c.LinkItem 
where 
/*
exists(
	select RefNo,count(*) from Job_InvoiceHeader 
	where isnull(CancelPRove,'')=''
	and RefNo=h.RefNo
	group by RefNo 
	having count(*)>1
) and 
*/
c.LinkBillNo is null
order by 2 desc
