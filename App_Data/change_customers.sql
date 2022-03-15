/****** Object:  StoredProcedure [dbo].[ChangeCustomer]    Script Date: 3/14/2022 2:02:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[ChangeCustomer](
@fromcode varchar(50),
@frombranch varchar(50),
@tocode varchar(50),
@tobranch varchar(50)
)
AS 
begin
update Job_AdvHeader set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_BillAcceptHeader set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_CashControl set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_CashControlDoc set CmpCode=@tocode,CmpBranch=@tobranch where CmpCode=@fromcode and CmpBranch=@frombranch
update Job_CNDNHeader set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_InvoiceHeader set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_InvoiceHeader set BillToCustCode=@tocode,BillToCustBranch=@tobranch where BillToCustCode=@fromcode and BillToCustBranch=@frombranch
update Job_LoadInfo set NotifyCode=@tocode where NotifyCode=@fromcode
update Job_Order set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_Order set consigneecode=@tocode where consigneecode=@fromcode
update Job_QuotationHeader set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_QuotationHeader set BillToCustCode=@tocode,BillToCustBranch=@tobranch where BillToCustCode=@fromcode and BillToCustBranch=@frombranch
update Job_ReceiptHeader set CustCode=@tocode,CustBranch=@tobranch where CustCode=@fromcode and CustBranch=@frombranch
update Job_ReceiptHeader set BillToCustCode=@tocode,BillToCustBranch=@tobranch where BillToCustCode=@fromcode and BillToCustBranch=@frombranch
update Job_TransportPrice set CustCode=@tocode where CustCode=@fromcode
update Mas_Company set CustCode=@tocode,Branch=@tobranch where CustCode=@fromcode and Branch=@frombranch
update Mas_Company set BillToCustCode=@tocode,BillToBranch=@tobranch where BillToCustCode=@fromcode and BillToBranch=@frombranch
update Mas_CompanyContact set CustCode=@tocode,Branch=@tobranch where CustCode=@fromcode and Branch=@frombranch
end
GO


