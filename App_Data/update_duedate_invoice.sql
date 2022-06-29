/*
select c.CustCode,c.CreditLimit,
i.DueDate,DATEADD(day,c.CreditLimit,i.DocDate) as DueDateCal
*/
update i set i.DueDate=DATEADD(day,c.CreditLimit,i.DocDate)
from Mas_Company c 
inner join Job_InvoiceHeader i on c.CustCode=i.BillToCustCode and c.Branch=i.BillToCustBranch
where c.CreditLimit >0 and i.DueDate is null 
go
/*
select c.CustCode,c.CreditLimit,i.BillToCustCode,
i.DueDate,DATEADD(day,c.CreditLimit,i.DocDate) as DueDateCal
*/
update i set i.DueDate=DATEADD(day,c.CreditLimit,i.DocDate)
from Mas_Company c 
inner join Job_InvoiceHeader i on c.CustCode=i.CustCode and c.Branch=i.CustBranch
where c.CreditLimit >0 and i.DueDate is null
and i.BillToCustCode<>i.CustCode
go
--select h.CustCode,h.DuePaymentDate,DATEADD(day,c.CreditLimit,h.BillDate)
update h set h.DuePaymentDate=DATEADD(day,c.CreditLimit,h.BillDate)
from Job_BillAcceptHeader h
inner join Job_BillAcceptDetail d
on h.BillAcceptNo=d.BillAcceptNo
inner join Mas_Company c on h.CustCode=c.CustCode 
where h.DuePaymentDate is null

