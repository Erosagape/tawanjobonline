insert into Mas_Config SELECT 'RUNNING_FORMAT','APP_PAY','APLL-'
insert into Mas_Config SELECT 'RUNNING','APP_PAY','yy-____'
alter table Job_PaymentHeader add ApproveRef varchar(50) NULL

//---------STANDARD-------------
alter table Job_AdvHeader alter column EmpCode varchar(50) NULL
alter table Job_AdvHeader alter column ApproveBy varchar(50) NULL
alter table Job_AdvHeader alter column PaymentBy varchar(50) NULL
alter table Job_AdvHeader alter column CancelProve varchar(50) NULL
alter table Job_AdvHeader alter column AdvBy varchar(50) NULL

alter table Job_BillAcceptHeader alter column EmpCode varchar(50) NULL
alter table Job_BillAcceptHeader alter column CancelProve varchar(50) NULL

alter table Job_BudgetPolicy alter column UpdateBy varchar(50) NULL

alter table Job_CashControl alter column RecUser varchar(50) NULL
alter table Job_CashControl alter column PostedBy varchar(50) NULL
alter table Job_CashControl alter column CancelProve varchar(50) NULL

alter table Job_ClearHeader alter column EmpCode varchar(50) NULL
alter table Job_ClearHeader alter column ApproveBy varchar(50) NULL
alter table Job_ClearHeader alter column ReceiveBy varchar(50) NULL
alter table Job_ClearHeader alter column CancelProve varchar(50) NULL

alter table Job_CNDNHeader alter column EmpCode varchar(50) NULL
alter table Job_CNDNHeader alter column ApproveBy varchar(50) NULL
alter table Job_CNDNHeader alter column UpdateBy varchar(50) NULL

alter table Job_Document alter column UploadBy varchar(50) NULL
alter table Job_Document alter column ApproveBy varchar(50) NULL
alter table Job_Document alter column CheckedBy varchar(50) NULL

alter table Job_GLDetail alter column EntryBy varchar(50) NULL

alter table Job_GLHeader alter column UpdateBy varchar(50) NULL
alter table Job_GLHeader alter column ApproveBy varchar(50) NULL
alter table Job_GLHeader alter column PostBy varchar(50) NULL
alter table Job_GLHeader alter column CancelBy varchar(50) NULL

alter table Job_InvoiceHeader alter column EmpCode varchar(50) NULL
alter table Job_InvoiceHeader alter column PrintedBy varchar(50) NULL
alter table Job_InvoiceHeader alter column CancelProve varchar(50) NULL

alter table Job_Order alter column CSCode varchar(50) NULL
alter table Job_Order alter column CancelProve varchar(50) NULL
alter table Job_Order alter column CloseJobBy varchar(50) NULL
alter table Job_Order alter column ShippingEmp varchar(50) NULL
alter table Job_Order alter column ManagerCode varchar(50) NULL
alter table Job_OrderLog alter column EmpCode varchar(50) NULL

alter table Job_PaymentHeader alter column EmpCode varchar(50) NULL
alter table Job_PaymentHeader alter column PaymentBy varchar(50) NULL
alter table Job_PaymentHeader alter column ApproveBy varchar(50) NULL
alter table Job_PaymentHeader alter column CancelProve varchar(50) NULL

alter table Job_QuotationHeader alter column ManagerCode varchar(50) NULL
alter table Job_QuotationHeader alter column ApproveBy varchar(50) NULL
alter table Job_QuotationHeader alter column CancelBy varchar(50) NULL

alter table Job_ReceiptHeader alter column EmpCode varchar(50) NULL
alter table Job_ReceiptHeader alter column PrintedBy varchar(50) NULL
alter table Job_ReceiptHeader alter column ReceiveBy varchar(50) NULL
alter table Job_ReceiptHeader alter column CancelProve varchar(50) NULL
