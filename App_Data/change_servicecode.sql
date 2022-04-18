create procedure dbo.ChangeServiceCode
(
	@fromcode nvarchar(50),
	@tocode nvarchar(50)
)
as
begin
	update Job_QuotationItem SET SICode=@tocode where SICode=@fromcode
	update Job_AdvDetail  SET SICode=@tocode where SICode=@fromcode
	update Job_BudgetPolicy  SET SICode=@tocode where SICode=@fromcode
	update Job_ClearDetail  SET SICode=@tocode where SICode=@fromcode
	update Job_ClearExp  SET SICode=@tocode where SICode=@fromcode
	update Job_CNDNDetail  SET SICode=@tocode where SICode=@fromcode
	update Job_InvoiceDetail  SET SICode=@tocode where SICode=@fromcode
	update Job_ReceiptDetail  SET SICode=@tocode where SICode=@fromcode
	update Job_PaymentDetail  SET SICode=@tocode where SICode=@fromcode
	update Job_TransportPrice  SET SICode=@tocode where SICode=@fromcode
end