use job_theso
go
update Job_Order
set JobStatus=99,CancelDate=GetDate(),CancelProve='ADMIN',CancelReson='Training Job'
from Job_Order 
where Year(DocDate)=2021 and Month(DocDate)=7
and JobStatus<>99
go
Update h
set h.DocStatus=99,h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_AdvHeader h
inner join Job_AdvDetail d
on h.AdvNo=d.AdvNo
inner join Job_Order j On d.ForJNo=j.JNo
where j.JobStatus=99 and h.DocStatus<>99
go
Update h
set h.DocStatus=99,h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_ClearHeader h
inner join Job_ClearDetail d
on h.ClrNo=d.ClrNo
inner join Job_Order j On d.JobNo=j.JNo
where j.JobStatus=99 and h.DocStatus<>99
go
Update h
set h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_InvoiceHeader h
inner join Job_ClearDetail d
on h.DocNo=d.LinkBillNo
inner join Job_Order j On d.JobNo=j.JNo
where j.JobStatus=99  and h.CancelProve<>'ADMIN'
go
Update h
set h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_BillAcceptHeader h
inner join Job_BillAcceptDetail d
on h.BillAcceptNo=d.BillAcceptNo
inner join Job_InvoiceHeader i On d.InvNo=i.DocNo
where isnull(i.CancelProve,'')<>'' and h.CancelProve<>'ADMIN'
go
Update h
set h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_ReceiptHeader h
inner join Job_ReceiptDetail d
on h.ReceiptNo=d.ReceiptNo
inner join Job_InvoiceHeader i On d.InvoiceNo=i.DocNo
where isnull(i.CancelProve,'')<>'' and h.CancelProve<>'ADMIN'
go
Update h
set h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_Cashcontrol h
inner join Job_CAshControlDoc d
on h.ControlNo=d.ControlNo
inner join Job_AdvHeader a
on d.DocNo=a.AdvNo 
where d.DocType='ADV'
and a.DocStatus=99 and h.CancelProve<>'ADMIN'
go
Update h
set h.CancelDate=GetDate(),h.CancelProve='ADMIN',h.CancelReson='Test Job'
from Job_Cashcontrol h
inner join Job_CAshControlDoc d
on h.ControlNo=d.ControlNo
inner join Job_ClearHeader a
on d.DocNo=a.ClrNo 
where d.DocType='CLR'
and a.DocStatus=99 and h.CancelProve<>'ADMIN'
go
delete from Job_Order where isnull(CancelProve,'')<>'' and DocDate>='2021-07-01'
delete from Job_CashControl where isnull(CancelProve,'')<>'' and VoucherDate>='2021-07-01'
delete from Job_CashControlSub where ControlNo not in (SELECT ControlNo from Job_CashControl)
delete from Job_CashControlDoc where ControlNo not in (SELECT ControlNo from Job_CashControl)
delete from Job_CashControl where ControlNo not in(SELECT ControlNo from Job_CashControlSub)

delete from Job_AdvHeader where isnull(CancelProve,'')<>'' and AdvDate>='2021-07-01'
delete from Job_AdvDetail where AdvNo not in(select AdvNo From job_Advheader)
delete from Job_AdvHeader where AdvNo not in(select AdvNo From job_AdvDetail)
delete from Job_ClearHeader where isnull(CancelProve,'')<>'' and ClrDate<'2021-07-01'
delete from Job_ClearDetail where ClrNo not in(select ClrNo From job_Clearheader)
delete from Job_ClearHeader where ClrNo not in(select ClrNo From job_ClearDetail)
delete from Job_InvoiceHeader where isnull(CancelProve,'')<>'' and DocDate>='2021-07-01'
delete from Job_InvoiceDetail where DocNo not in(select DocNo From job_Invoiceheader)
delete from Job_InvoiceHeader where DocNo not in(select DocNo From job_InvoiceDetail)
delete from Job_BillAcceptHeader where isnull(CancelProve,'')<>'' and BillDate>='2021-07-01'
delete from Job_BillAcceptDetail where BillAcceptNo not in(select BillAcceptNo From job_BillAcceptheader)
delete from Job_BillAcceptHeader where BillAcceptNo not in(select BillAcceptNo From job_BillAcceptDetail)
delete from Job_ReceiptHeader where isnull(CancelProve,'')<>'' and ReceiptDate>='2021-07-01'
delete from Job_ReceiptDetail where ReceiptNo not in(select ReceiptNo From job_Receiptheader)
delete from Job_ReceiptHeader where ReceiptNo not in(select ReceiptNo From job_ReceiptDetail)
delete from Job_PaymentHeader where DocDate>='2021-07-01'
delete from Job_PaymentDetail where DocNo not in(SELECT DocNo from Job_PaymentHeader)
delete from Job_PaymentHeader where DocNo not in(SELECT DocNo from Job_PaymentDetail)
