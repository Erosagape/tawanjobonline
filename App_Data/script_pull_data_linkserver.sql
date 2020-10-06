--ON SOURCE SERVER
create procedure dbo.SetIdentityOnOff(
@tablename varchar(MAX),
@onoff int
)
as
begin
if (@onoff=0) EXEC ('SET IDENTITY_INSERT '+ @tablename + ' OFF');
if (@onoff=1) EXEC ('SET IDENTITY_INSERT '+ @tablename + ' ON');
end 
go
create procedure dbo.ReIdentity(
@tablename varchar(MAX)
)
as
begin
DBCC CHECKIDENT(@tablename,RESEED,1);
end
go
--ON DESTINATION SERVER
create procedure [dbo].[PushDataToServer] (
@toserver varchar(max),
@tablename varchar(max),
@todb varchar(max)
)
as
begin
EXEC ('delete from [' + @toserver + '].['+ @todb +'].[dbo].[' + @tablename + ']');
EXEC ('insert into [' + @toserver + '].['+ @todb +'].[dbo].[' + @tablename + '] select * from ' + @tablename + '');
end
go
create procedure dbo.PushCompanyData (
@toserver varchar(max),
@todb varchar(max)
)
as 
begin
EXEC dbo.PushDataToServer @toserver,'Mas_Config',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_User',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_UserAuth',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_UserRole',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_UserRoleDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_UserRolePolicy',@todb
end 
go
create procedure dbo.PushMasterData (
@toserver varchar(max),
@todb varchar(max)
)
as
begin
EXEC dbo.PushDataToServer @toserver,'Job_SrvGroup',@todb
EXEC dbo.PushDataToServer @toserver,'Job_SrvSingle',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_Account',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_BookAccount',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_Branch',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_Company',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_CompanyContact',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_CurrencyCode',@todb
EXEC dbo.PushDataToServer @toserver,'Mas_Vender',@todb
end
go
create procedure dbo.PushRouteToServer (
@toserver varchar(max),
@todb varchar(max)
)
as
begin
EXEC ('DELETE FROM [' + @toserver+ '].[' + @todb+ '].dbo.Job_TransportRoute;');
EXEC ('[' + @toserver+ '].[' + @todb+ '].dbo.ReIdentity ''Job_TransportRoute''');
EXEC ('[' + @toserver+ '].[' + @todb+ '].dbo.SetIdentityOnOff ''Job_TransportRoute'',1');
EXEC ('INSERT INTO [' + @toserver+ '].[' + @todb+ '].dbo.Job_TransportRoute (Place1,Place2,Place3,Place4,LocationRoute,IsActive,
Address1,Contact1,Address2,Contact2,Address3,Contact3,Address4,Contact4,RouteFormat) SELECT Place1,Place2,Place3,Place4,LocationRoute,IsActive,
Address1,Contact1,Address2,Contact2,Address3,Contact3,Address4,Contact4,RouteFormat
FROM dbo.Job_TransportRoute;');
EXEC ('[' + @toserver+ '].[' + @todb+ '].dbo.SetIdentityOnOff ''Job_TransportRoute'',0');
end
go
create procedure dbo.PushTransactionData (
@toserver varchar(max),
@todb varchar(max)
)
as
begin
EXEC dbo.PushDataToServer @toserver,'Job_AdvDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_AdvHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_BillAcceptDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_BillAcceptHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_BudgetPolicy',@todb
EXEC dbo.PushDataToServer @toserver,'Job_CashControl',@todb
EXEC dbo.PushDataToServer @toserver,'Job_CashControlDoc',@todb
EXEC dbo.PushDataToServer @toserver,'Job_CashControlSub',@todb
EXEC dbo.PushDataToServer @toserver,'Job_ClearDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_ClearExp',@todb
EXEC dbo.PushDataToServer @toserver,'Job_ClearHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_CNDNDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_CNDNHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_Document',@todb
EXEC dbo.PushDataToServer @toserver,'Job_GLDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_GLHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_InvoiceDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_InvoiceHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_LoadInfoDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_LoadInfo',@todb
EXEC dbo.PushDataToServer @toserver,'Job_Order',@todb
EXEC dbo.PushDataToServer @toserver,'Job_OrderLog',@todb
EXEC dbo.PushDataToServer @toserver,'Job_PaymentDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_PaymentHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_QuotationDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_QuotationHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_QuotationItem',@todb
EXEC dbo.PushDataToServer @toserver,'Job_ReceiptDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_ReceiptHeader',@todb
EXEC dbo.PushDataToServer @toserver,'Job_TransportPrice',@todb
EXEC dbo.PushDataToServer @toserver,'Job_TransportPlace',@todb
EXEC dbo.PushDataToServer @toserver,'Job_WHTaxDetail',@todb
EXEC dbo.PushDataToServer @toserver,'Job_WHTax',@todb
EXEC dbo.PushRouteToServer @toserver,@todb
end
go
create procedure dbo.PushData(
@toserver varchar(max),
@todb varchar(max)
)
as 
begin
EXEC dbo.PushCompanyData @toserver,@todb
EXEC dbo.PushMasterData @toserver,@todb
EXEC dbo.PushTransactionData @toserver,@todb
end
go
create procedure dbo.PullDataFromServer (
@fromserver varchar(max),
@tablename varchar(max),
@fromdb varchar(max)
)
as
begin
EXEC ('delete from ' + @tablename); 
EXEC ('insert into ' + @tablename + ' select * from [' + @fromserver + '].['+ @fromdb +'].[dbo].[' + @tablename + ']');
end
go
create procedure dbo.PullCompanyData (
@fromserver varchar(max),
@fromdb varchar(max)
)
as 
begin
EXEC dbo.PullDataFromServer @fromserver,'Mas_Config',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_User',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_UserAuth',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_UserRole',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_UserRoleDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_UserRolePolicy',@fromdb
end 
go
create procedure dbo.PullMasterData (
@fromserver varchar(max),
@fromdb varchar(max)
)
as
begin
EXEC dbo.PullDataFromServer @fromserver,'Job_SrvGroup',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_SrvSingle',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_Account',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_BookAccount',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_Branch',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_Company',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_CompanyContact',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_CurrencyCode',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Mas_Vender',@fromdb
end
go
create procedure dbo.PullRouteFromServer (
@fromserver varchar(max),
@fromdb varchar(max)
)
as
begin
DELETE FROM Job_TransportRoute;
DBCC CHECKIDENT('Job_TransportRoute',RESEED,1);
SET IDENTITY_INSERT Job_TransportRoute ON;
EXEC ('INSERT INTO Job_TransportRoute (LocationID,Place1,Place2,Place3,Place4,LocationRoute,IsActive,
Address1,Contact1,Address2,Contact2,Address3,Contact3,Address4,Contact4,RouteFormat) SELECT LocationID,Place1,Place2,Place3,Place4,LocationRoute,IsActive,
Address1,Contact1,Address2,Contact2,Address3,Contact3,Address4,Contact4,RouteFormat
FROM [' + @fromserver+ '].[' + @fromdb+ '].dbo.Job_TransportRoute;');
SET IDENTITY_INSERT Job_TransportRoute OFF;
end
go
create procedure dbo.PullTransactionData (
@fromserver varchar(max),
@fromdb varchar(max)
)
as
begin
EXEC dbo.PullDataFromServer @fromserver,'Job_AdvDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_AdvHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_BillAcceptDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_BillAcceptHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_BudgetPolicy',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_CashControl',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_CashControlDoc',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_CashControlSub',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_ClearDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_ClearExp',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_ClearHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_CNDNDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_CNDNHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_Document',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_GLDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_GLHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_InvoiceDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_InvoiceHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_LoadInfoDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_LoadInfo',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_Order',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_OrderLog',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_PaymentDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_PaymentHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_QuotationDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_QuotationHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_QuotationItem',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_ReceiptDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_ReceiptHeader',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_TransportPrice',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_TransportPlace',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_WHTaxDetail',@fromdb
EXEC dbo.PullDataFromServer @fromserver,'Job_WHTax',@fromdb
EXEC dbo.PullRouteFromServer @fromserver,@fromdb
end
go
create procedure dbo.PullData(
@fromserver varchar(max),
@fromdb varchar(max)
)
as 
begin
EXEC dbo.PullCompanyData @fromserver,@fromdb
EXEC dbo.PullMasterData @fromserver,@fromdb
EXEC dbo.PullTransactionData @fromserver,@fromdb
end
go