
/****** Object:  StoredProcedure [dbo].[DeleteJobNumber]    Script Date: 07/11/2025 12:54:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DeleteJobNumber]
(
	@datefrom date,
	@dateto date,
	@filter varchar(20)
)
as
begin
    delete from Job_Order where DocDate>=@datefrom and DocDate<=@dateto and JNo like @filter+'%'

	delete from Job_OrderLog where JNo not in(select JNo from Job_Order)

	delete from Job_AddFuel where JNo not in(select JNo from Job_Order)		

	delete from Job_AdvDetail where ForJNo not in(select JNo from Job_Order) and ForJNo<>'' 

	delete a from Job_AdvHeader a where not exists(
		select 1 from Job_AdvDetail where AdvNo=a.AdvNo
	)

	delete from Job_ClearDetail where JobNo not in(select JNo from Job_Order)
	delete a from Job_ClearHeader a where not exists(
		select 1 from Job_ClearDetail where ClrNo=a.ClrNo
	)

	delete from Job_ClearExp where JNo not in(select JNo from Job_Order)

	delete from Job_LoadInfo where JNo not in(select JNo from Job_Order)

	delete from Job_LoadInfoDetail where JNo not in(select JNo from Job_Order)

	delete from Job_PaymentDetail where ForJNo not in(select JNo from Job_Order)
	delete a from Job_PaymentHeader a where not exists(
		select 1 from Job_PaymentDetail where DocNo=a.DocNo
	)

	delete from Job_CashControlSub where ForJNo not in(select JNo from Job_Order) and ForJNo<>''			
	delete a from Job_CashControl a where not exists(
		select 1 from Job_CashControlSub where ControlNo=a.ControlNo
	)
	delete a from Job_CashControlDoc a where not exists(
		select 1 from Job_CashControl where ControlNo=a.ControlNo
	)
	delete a from Job_InvoiceDetail as a where not exists(
		select 1 from Job_ClearDetail where LinkBillNo=a.DocNo and LinkItem=a.ItemNo
	)
	delete a from Job_InvoiceHeader a where not exists(
		select 1 from Job_InvoiceDetail where DocNo=a.DocNo
	)
	delete a from Job_BillAcceptDetail a where not exists(
		select 1 from Job_InvoiceHeader where DocNo=a.InvNo
	)		
	delete a from Job_BillAcceptHeader a where not exists(
		select 1 from Job_BillAcceptDetail where BillAcceptNo=a.BillAcceptNo
	)
	delete a from Job_ReceiptDetail as a where not exists(
		select 1 from Job_ClearDetail where LinkBillNo=a.InvoiceNo and LinkItem=a.InvoiceItemNo 
	)	
	delete a from Job_ReceiptHeader a where not exists(
		select 1 from Job_ReceiptDetail where ReceiptNo=a.ReceiptNo 
	)

end
GO


