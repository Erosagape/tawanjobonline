create procedure ChangeVender
(
@fromcode varchar(50),
@tocode varchar(50)
)
as
begin
update Job_SrvSingle set DefaultVender=@tocode where DefaultVender=@fromcode
update Job_LoadInfo set VenderCode=@tocode where VenderCode=@fromcode
update Job_TransportPrice set VenderCode=@tocode where VenderCode=@fromcode
update Job_Order set AgentCode=@tocode where AgentCode=@fromcode 
update Job_Order set ForwarderCode=@tocode where ForwarderCode=@fromcode 
update Job_AdvDetail set VenCode=@tocode where VenCode=@fromcode
update Job_ClearDetail set VenderCode=@tocode where VenderCode=@fromcode
update Job_QuotationItem set VenderCode=@tocode where VenderCode=@fromcode 
update Job_PaymentHeader set VenCode=@tocode where VenCode=@fromcode 
update Mas_Vender set VenCode=@tocode where VenCode=@fromcode 
end