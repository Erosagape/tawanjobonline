delete from Job_ReceiptHeader where Year(ReceiptDate)=2024
delete from Job_ReceiptDetail where ReceiptNo not in(select ReceiptNo from Job_ReceiptHeader)
delete from Job_BillAcceptHeader where Year(billDate)=2024
delete from Job_BillAcceptDetail where BillAcceptNo not in(select BillAcceptNo from Job_BillAcceptHeader)
Update Job_ClearDetail set LinkBillNo='',LinkItem=0 where LinkBillNo in (select DocNo from Job_InvoiceHeader where Year(DocDate)=2024)
delete from Job_InvoiceHeader where Year(DocDate)=2024
delete from Job_InvoiceDetail where DocNo not in(select DocNo from Job_InvoiceHeader)
delete from Job_ClearHeader where Year(ClrDate)=2024
delete from Job_ClearDetail where ClrNo not in(select ClrNo from Job_ClearHeader)
delete from job_AdvHeader where Year(AdvDate)=2024
delete from Job_AdvDetail where AdvNo not in(select AdvNo from Job_AdvHeader)
delete from Job_LoadInfoDetail where JNo in(select JNo from Job_Order where Year(CreateDate)=2024)
delete from Job_LoadInfo where JNo in(select JNo from Job_Order where Year(CreateDate)=2024)
delete from Job_Order where Year(CreateDate)=2024
delete from Job_Order where Year(DocDate)=2024
delete from Job_CashControl where Year(VoucherDate)=2024
delete from Job_CashControlDoc where ControlNo not in(select ControlNo from Job_CAshControl)
delete from Job_CashControlSub where ControlNo not in(select ControlNo from Job_CAshControl)
delete from Job_PaymentHeader where Year(DocDate)=2024
delete from Job_PaymentDetail where DocNo not in(select DocNo from Job_PaymentHeader)