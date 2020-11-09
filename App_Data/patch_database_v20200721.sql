alter table Job_CashControl add PostRefNo varchar(20)
-----------------------------------------------------------------------
alter table Job_LoadInfoDetail alter column CTN_NO nvarchar(50)
alter table Job_ClearHeader alter column CTN_NO nvarchar(50)
alter table Job_AdvHeader alter column CustBranch varchar(10)
alter table Job_BillAcceptHeader alter column CustBranch varchar(10)
alter table Job_CashControl alter column CustBranch varchar(10)
alter table Job_CNDNHeader alter column CustBranch varchar(10)
alter table Job_InvoiceHeader alter column CustBranch varchar(10)
alter table Job_InvoiceHeader alter column BillToCustBranch varchar(10)
alter table Job_Order alter column CustBranch varchar(10)
alter table Job_QuotationHeader alter column CustBranch varchar(10)
alter table Job_ReceiptHeader alter column CustBranch varchar(10)
alter table Job_ReceiptHeader alter column BillToCustBranch varchar(10)
--------------------------------------------------------------------------
alter table Job_LoadinfoDetail add PlaceName1 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceAddress1 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceContact1 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceName2 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceAddress2 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceContact2 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceName3 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceAddress3 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceContact3 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceName4 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceAddress4 nvarchar(MAX)
alter table Job_LoadinfoDetail add PlaceContact4 nvarchar(MAX)
GO
---------------------------------------------------------------------
alter table Job_PaymentHeader add ApproveRef nvarchar(50) NULL
alter table Mas_BookAccount add ControlBalance float NULL
GO
alter table Job_AdvDetail alter column TRemark nvarchar(MAX)
alter table Job_AdvDetail alter column PayChqTo nvarchar(MAX)
alter table Job_AdvDetail alter column SDescription nvarchar(MAX)

alter table Job_AdvHeader alter column TRemark nvarchar(MAX)
alter table Job_AdvHeader alter column CancelReson nvarchar(MAX)
alter table Job_AdvHeader alter column PayChqTo nvarchar(MAX)
alter table Job_AdvHeader alter column EmpCode varchar(50) NULL
alter table Job_AdvHeader alter column ApproveBy varchar(50) NULL
alter table Job_AdvHeader alter column PaymentBy varchar(50) NULL
alter table Job_AdvHeader alter column CancelProve varchar(50) NULL
alter table Job_AdvHeader alter column AdvBy varchar(50) NULL

alter table Job_BillAcceptHeader alter column BillRemark nvarchar(MAX)
alter table Job_BillAcceptHeader alter column CancelReson nvarchar(MAX)
alter table Job_BillAcceptHeader alter column EmpCode varchar(50) NULL
alter table Job_BillAcceptHeader alter column CancelProve varchar(50) NULL

alter table Job_BudgetPolicy alter column SDescription nvarchar(MAX)
alter table Job_BudgetPolicy alter column TRemark nvarchar(MAX)
alter table Job_BudgetPolicy alter column UpdateBy varchar(50) NULL

alter table Job_CashControl alter column TRemark nvarchar(MAX)
alter table Job_CashControl alter column CancelReson nvarchar(MAX)
alter table Job_CashControl alter column RecUser varchar(50) NULL
alter table Job_CashControl alter column PostedBy varchar(50) NULL
alter table Job_CashControl alter column CancelProve varchar(50) NULL

alter table Job_CashControlSub alter column TRemark nvarchar(max)
alter table Job_CashControlSub alter column PayChqTo nvarchar(max)

alter table Job_ClearDetail alter column SDescription nvarchar(max)
alter table Job_ClearDetail alter column Remark nvarchar(max)
alter table Job_ClearDetail alter column VenderCode nvarchar(50)

alter table Job_ClearExp alter column SDescription nvarchar(max)
alter table Job_ClearExp alter column TRemark nvarchar(max)

alter table Job_ClearHeader alter column TRemark nvarchar(MAX)
alter table Job_ClearHeader alter column CancelReson nvarchar(MAX)
alter table Job_ClearHeader alter column EmpCode varchar(50) NULL
alter table Job_ClearHeader alter column ApproveBy varchar(50) NULL
alter table Job_ClearHeader alter column ReceiveBy varchar(50) NULL
alter table Job_ClearHeader alter column CancelProve varchar(50) NULL

alter table Job_CNDNDetail alter column SDescription nvarchar(MAX)
alter table Job_CNDNHeader alter column Remark nvarchar(MAX)
alter table Job_CNDNHeader alter column EmpCode varchar(50) NULL
alter table Job_CNDNHeader alter column ApproveBy varchar(50) NULL
alter table Job_CNDNHeader alter column UpdateBy varchar(50) NULL

alter table Job_Document alter column [Description] nvarchar(MAX)
alter table Job_Document alter column CheckNote nvarchar(MAX)
alter table Job_Document alter column UploadBy varchar(50) NULL
alter table Job_Document alter column ApproveBy varchar(50) NULL
alter table Job_Document alter column CheckedBy varchar(50) NULL

alter table Job_GLDetail alter column GLDescription nvarchar(MAX)
alter table Job_GLDetail alter column EntryBy varchar(50) NULL

alter table Job_GLHeader alter column Remark nvarchar(MAX)
alter table Job_GLHeader alter column CancelReason nvarchar(MAX)
alter table Job_GLHeader alter column UpdateBy varchar(50) NULL
alter table Job_GLHeader alter column ApproveBy varchar(50) NULL
alter table Job_GLHeader alter column PostBy varchar(50) NULL
alter table Job_GLHeader alter column CancelBy varchar(50) NULL

alter table Job_InvoiceDetail alter column SDescription nvarchar(MAX)
alter table Job_InvoiceDetail alter column SRemark nvarchar(MAX)

alter table Job_InvoiceHeader alter column ContactName nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark1 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark2 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark3 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark4 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark5 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark6 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark7 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark8 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark9 nvarchar(MAX)
alter table Job_InvoiceHeader alter column Remark10 nvarchar(MAX)
alter table Job_InvoiceHeader alter column CancelReson nvarchar(MAX)
alter table Job_InvoiceHeader alter column ShippingRemark nvarchar(MAX)
alter table Job_InvoiceHeader alter column EmpCode varchar(50) NULL
alter table Job_InvoiceHeader alter column PrintedBy varchar(50) NULL
alter table Job_InvoiceHeader alter column CancelProve varchar(50) NULL

alter table Job_LoadInfo alter column ContactName nvarchar(MAX)
alter table Job_Loadinfo alter column Remark nvarchar(MAX)
alter table Job_Loadinfo alter column PackingPlace nvarchar(MAX)
alter table Job_Loadinfo alter column CYPlace nvarchar(MAX)
alter table Job_Loadinfo alter column FactoryPlace nvarchar(MAX)
alter table Job_Loadinfo alter column ReturnPlace nvarchar(MAX)
alter table Job_Loadinfo alter column PaymentCondition nvarchar(MAX)
alter table Job_Loadinfo alter column PaymentBy nvarchar(MAX)
alter table Job_Loadinfo alter column CYAddress nvarchar(MAX)
alter table Job_Loadinfo alter column PackingAddress nvarchar(MAX)
alter table Job_Loadinfo alter column FactoryAddress nvarchar(MAX)
alter table Job_Loadinfo alter column ReturnAddress nvarchar(MAX)
alter table Job_Loadinfo alter column CYContact nvarchar(MAX)
alter table Job_Loadinfo alter column PackingContact nvarchar(MAX)
alter table Job_Loadinfo alter column FactoryContact nvarchar(MAX)
alter table Job_Loadinfo alter column ReturnContact nvarchar(MAX)

alter table Job_LoadinfoDetail alter column Driver nvarchar(max)
alter table Job_LoadinfoDetail alter column Location nvarchar(max)
alter table Job_LoadinfoDetail alter column ShippingMark nvarchar(max)
alter table Job_LoadinfoDetail alter column ProductDesc nvarchar(max)

alter table Job_Order alter column CustContactName nvarchar(MAX)
alter table Job_Order alter column [Description] nvarchar(MAX)
alter table Job_Order alter column TRemark nvarchar(MAX)
alter table Job_Order alter column InvProduct nvarchar(MAX)
alter table Job_Order alter column InvNo nvarchar(MAX)
alter table Job_Order alter column ClearPortNo nvarchar(MAX)
alter table Job_Order alter column CancelReson nvarchar(MAX)
alter table Job_Order alter column ShippingCmd nvarchar(MAX)
alter table Job_Order alter column ProjectName nvarchar(MAX)
alter table Job_Order alter column CSCode varchar(50) NULL
alter table Job_Order alter column CancelProve varchar(50) NULL
alter table Job_Order alter column CloseJobBy varchar(50) NULL
alter table Job_Order alter column ShippingEmp varchar(50) NULL
alter table Job_Order alter column ManagerCode varchar(50) NULL
alter table Job_OrderLog alter column EmpCode varchar(50) NULL
alter table Job_OrderLog alter column TRemark nvarchar(MAX)

alter table Job_PaymentDetail alter column SDescription nvarchar(MAX)
alter table Job_PaymentDetail alter column SRemark nvarchar(MAX)

alter table Job_PaymentHeader alter column ContactName nvarchar(MAX)
alter table Job_PaymentHeader alter column Remark nvarchar(MAX)
alter table Job_PaymentHeader alter column CancelReson nvarchar(MAX)
alter table Job_PaymentHeader alter column EmpCode varchar(50) NULL
alter table Job_PaymentHeader alter column PaymentBy varchar(50) NULL
alter table Job_PaymentHeader alter column ApproveBy varchar(50) NULL
alter table Job_PaymentHeader alter column CancelProve varchar(50) NULL

alter table Job_QuotationDetail alter column [Description] nvarchar(MAX)
alter table Job_QuotationHeader alter column ContactName nvarchar(MAX)
alter table Job_QuotationHeader alter column DescriptionH nvarchar(MAX)
alter table Job_QuotationHeader alter column DescriptionF nvarchar(MAX)
alter table Job_QuotationHeader alter column TRemark nvarchar(MAX)
alter table Job_QuotationHeader alter column CancelReason nvarchar(MAX)
alter table Job_QuotationItem alter column DescriptionThai nvarchar(MAX)

alter table Job_ReceiptDetail alter column SDescription nvarchar(MAX)
alter table Job_ReceiptHeader alter column TRemark nvarchar(MAX)
alter table Job_ReceiptHeader alter column CancelReson nvarchar(MAX)
alter table Job_ReceiptHeader alter column EmpCode varchar(50) NULL
alter table Job_ReceiptHeader alter column PrintedBy varchar(50) NULL
alter table Job_ReceiptHeader alter column ReceiveBy varchar(50) NULL
alter table Job_ReceiptHeader alter column CancelProve varchar(50) NULL
alter table Job_QuotationHeader alter column ManagerCode varchar(50) NULL
alter table Job_QuotationHeader alter column ApproveBy varchar(50) NULL
alter table Job_QuotationHeader alter column CancelBy varchar(50) NULL

alter table Job_SrvGroup alter column GroupName nvarchar(MAX)
alter table Job_SrvSingle alter column NameThai nvarchar(MAX)
alter table Job_SrvSingle alter column NameEng nvarchar(MAX)
alter table Job_SrvSingle alter column ProcessDesc nvarchar(MAX)

alter table Job_WHTax alter column TName1 nvarchar(MAX)
alter table Job_WHTax alter column TName2 nvarchar(MAX)
alter table Job_WHTax alter column TName3 nvarchar(MAX)
alter table Job_WHTax alter column TAddress1 nvarchar(MAX)
alter table Job_WHTax alter column TAddress2 nvarchar(MAX)
alter table Job_WHTax alter column TAddress3 nvarchar(MAX)
alter table Job_WHTax alter column CancelReason nvarchar(MAX)
alter table Job_WHTaxDetail alter column PayTaxDesc nvarchar(MAX)

alter table Mas_Account alter column AccTName nvarchar(MAX)
alter table Mas_Account alter column AccEName nvarchar(MAX)

alter table Mas_BookAccount alter column BookName nvarchar(MAX)
alter table Mas_BookAccount alter column TAddress1 nvarchar(MAX)
alter table Mas_BookAccount alter column TAddress2 nvarchar(MAX)
alter table Mas_BookAccount alter column EAddress1 nvarchar(MAX)
alter table Mas_BookAccount alter column EAddress2 nvarchar(MAX)

alter table Mas_Branch alter column BrName nvarchar(MAX)

alter table Mas_Company alter column Title nvarchar(15)
alter table Mas_Company alter column NameThai nvarchar(MAX)
alter table Mas_Company alter column NameEng nvarchar(MAX)
alter table Mas_Company alter column TAddress1 nvarchar(MAX)
alter table Mas_Company alter column TAddress2 nvarchar(MAX)
alter table Mas_Company alter column EAddress1 nvarchar(MAX)
alter table Mas_Company alter column EAddress2 nvarchar(MAX)
alter table Mas_Company alter column BillCondition nvarchar(MAX)
alter table Mas_Company alter column CSCodeIM nvarchar(20)
alter table Mas_Company alter column CSCodeEX nvarchar(20)
alter table Mas_Company alter column CSCodeOT nvarchar(20)
alter table Mas_Company alter column CommLevel nvarchar(5)

alter table Mas_User alter column TName nvarchar(MAX)
alter table Mas_User alter column EName nvarchar(MAX)
alter table Mas_User alter column TPosition nvarchar(MAX)
alter table Mas_User alter column UserUpline nvarchar(20)

alter table Mas_Vender alter column Title nvarchar(15)
alter table Mas_Vender alter column TName nvarchar(max)
alter table Mas_Vender alter column English nvarchar(max)
alter table Mas_Vender alter column TAddress1 nvarchar(max)
alter table Mas_Vender alter column TAddress2 nvarchar(max)
alter table Mas_Vender alter column EAddress1 nvarchar(max)
alter table Mas_Vender alter column EAddress2 nvarchar(max)
alter table Mas_Vender alter column ContactAcc nvarchar(max)
alter table Mas_Vender alter column ContactSale nvarchar(max)
alter table Mas_Vender alter column ContactSupport1 nvarchar(max)
alter table Mas_Vender alter column ContactSupport2 nvarchar(max)
alter table Mas_Vender alter column ContactSupport3 nvarchar(max)
alter table Mas_Vender alter column WEB_SITE nvarchar(max)

GO
CREATE FUNCTION [dbo].[GetCommission](
@amt float,@emp varchar(50)
) returns float 
as
begin
declare @comm float;

with data as (
select
CommRate,CheckAmt,
SUM(CheckAmt)  over (order by CheckAmt asc rows between unbounded preceding and current row) as BaseAmt
from (
	SELECT (CAST(r.ConfigKey as float)*u.MaxRateDisc) as CheckAmt,CAST(r.ConfigValue as float) as CommRate
	from Mas_Config r,Mas_User u WHERE r.ConfigCode='COMMISSION_STEP'
	AND u.UserID=@emp
) src
)
select @comm=SUM(CommAmt) FROM (
select *,(CASE WHEN @amt>BaseAmt THEN CheckAmt*CommRate ELSE (@amt-(BaseAmt-CheckAmt))*CommRate END) as CommAmt from data
) comm where CommAmt>0

return @comm;
end 
GO
---FOR DLL Version As 2020-07-21
CREATE FUNCTION [dbo].[GetDataSplit](@data nvarchar(MAX),@split nvarchar(max),@idx integer)
RETURNS  nvarchar(MAX)
AS
BEGIN
DECLARE @findidx as integer= CHARINDEX(@split,@data);
DECLARE @findstr as nvarchar(MAX);

IF (@findidx<=0 )
BEGIN
	SET @data=@data +@split;
	SET @findidx= CHARINDEX(@split,@data);
END

BEGIN
	IF (@idx=0) 
	BEGIN
		SET @findstr=SUBSTRING(@data,1,@findidx-1);
	END
	ELSE
	BEGIN
		SET @findstr=SUBSTRING(@data,@findidx+1,LEN(@data));
	END
END
RETURN @findstr;
END
GO
---------------------------------------------------
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','ADV','ADV-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','CLR_ADV','CLR-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','CLR_COST','CST-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','CLR_SERV','SRV-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','INV','IVS-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','BILL','BL-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','PAY','PAY-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','WHTAX','WT-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','EXP','ACC-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','QUO','Q-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','RECEIVE_REC','RC-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','RECEIVE_TAX','TX-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','RECEIVE_SRV','SV-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','RECEIVE_RCV','RV-'
INSERT INTO Mas_Config SELECT 'RUNNING_FORMAT','RECEIVE_ADV','AV-'
insert into Mas_Config SELECT 'RUNNING_FORMAT','APP_PAY','[VEN]-'
GO
INSERT INTO Mas_Config SELECT 'RUNNING','INV','yyMM____'
INSERT INTO Mas_Config SELECT 'RUNNING','BILL','yyMM____'
INSERT INTO Mas_Config SELECT 'RUNNING','RCP','yyMM____'
INSERT INTO Mas_Config SELECT 'RUNNING','QUO','-yyMM-___'
insert into Mas_Config SELECT 'RUNNING','APP_PAY','yy-____'
GO
