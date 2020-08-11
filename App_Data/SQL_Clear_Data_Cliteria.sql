use job_stm
go
delete from Job_AdvHeader where AdvNo in(select AdvNo from Job_AdvDetail where ForJNo like '%2007%')
delete from Job_AdvDetail where ForJNo like '%2007%'
delete from Job_ClearHeader where ClrNo in(select ClrNo from Job_ClearDetail where JobNo like '%2007%')
delete from Job_ClearDetail where JobNo like '%2007%'
delete from Job_InvoiceDetail where DocNo in(select DocNo from Job_InvoiceHeader where RefNo like  '%2007%')
delete from Job_InvoiceHeader where RefNo like  '%2007%'
delete from Job_BillAcceptDetail where InvNo not in(SELECT DocNo from Job_InvoiceHeader)
delete from Job_BillAcceptHeader where BillAcceptNo NOT IN (select BillAcceptNo from Job_BillAcceptHeader)
delete from Job_ReceiptDetail where  InvoiceNo not in(SELECT DocNo from Job_InvoiceHeader)
delete from Job_ReceiptHeader where  ReceiptNo not in(SELECT ReceiptNo from Job_ReceiptHeader)
delete from Job_CashControlDoc where DocType<>'INV'
AND SUBSTRING(DocNo,0,13) NOT IN (SELECT AdvNo FROM Job_AdvHeader)
delete a from Job_CashControlSub a left join Job_CashControlDoc b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo and a.acType=b.acType
WHERE b.acType is null AND a.ControlNo like '2007%' AND a.PRType='P'
delete from Job_CashControl where ControlNo like '2007%' and
controlNo not in (select controlno from job_cashcontrolsub)
delete from Job_LoadinfoDetail where JNo like '%2007%'
delete from Job_Loadinfo where JNo like '%2007%'
delete from Job_PaymentDetail where ForJNo Like '%2007%'
delete from Job_PaymentHeader where DocNo not in(SELECT DocNo from Job_PaymentDetail)
delete from Job_WHTaxDetail where DocNo  Like '%2007%'
delete from Job_WHTax where DocNo  Like '%2007%'
delete from Job_Order where JNo  Like '%2007%'