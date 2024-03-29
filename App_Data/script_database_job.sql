/****** Object:  UserDefinedFunction [dbo].[GetCommission]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  UserDefinedFunction [dbo].[GetDataSplit]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
/****** Object:  Table [dbo].[Job_AdvDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_AdvDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[AdvNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[STCode] [varchar](10) NULL,
	[SICode] [varchar](10) NULL,
	[AdvAmount] [float] NULL,
	[IsChargeVAT] [tinyint] NULL,
	[ChargeVAT] [float] NULL,
	[Rate50Tavi] [float] NULL,
	[Charge50Tavi] [float] NULL,
	[TRemark] [nvarchar](max) NULL,
	[IsDuplicate] [tinyint] NULL,
	[PayChqTo] [nvarchar](max) NULL,
	[Doc50Tavi] [varchar](10) NULL,
	[Is50Tavi] [tinyint] NULL,
	[VATRate] [float] NULL,
	[AdvNet] [float] NULL,
	[SDescription] [nvarchar](max) NULL,
	[ForJNo] [varchar](15) NULL,
	[VenCode] [varchar](50) NULL,
	[CurrencyCode] [varchar](12) NULL,
	[ExchangeRate] [float] NOT NULL DEFAULT ((1)),
	[AdvQty] [float] NOT NULL DEFAULT ((1)),
	[UnitPrice] [float] NOT NULL DEFAULT ((1)),
 CONSTRAINT [pk_adv_d] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[AdvNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_AdvHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_AdvHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[AdvNo] [varchar](15) NOT NULL,
	[JobType] [tinyint] NULL,
	[AdvDate] [datetime] NULL,
	[AdvType] [tinyint] NULL,
	[EmpCode] [varchar](50) NULL,
	[JNo] [varchar](15) NULL,
	[InvNo] [varchar](100) NULL,
	[DocStatus] [tinyint] NULL,
	[VATRate] [int] NULL,
	[TotalAdvance] [float] NULL,
	[TotalVAT] [float] NULL,
	[Total50Tavi] [float] NULL,
	[TRemark] [nvarchar](max) NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[PaymentBy] [varchar](50) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentTime] [datetime] NULL,
	[PaymentRef] [varchar](20) NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[AdvCash] [float] NULL,
	[AdvChqCash] [float] NULL,
	[AdvChq] [float] NULL,
	[AdvCred] [float] NULL,
	[PayChqTo] [nvarchar](max) NULL,
	[PayChqDate] [datetime] NULL,
	[Doc50Tavi] [varchar](15) NULL,
	[AdvBy] [varchar](50) NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](4) NULL,
	[ShipBy] [tinyint] NULL,
	[PaymentNo] [varchar](20) NULL,
	[MainCurrency] [varchar](12) NULL,
	[SubCurrency] [varchar](12) NULL,
	[ExchangeRate] [float] NOT NULL DEFAULT ((1)),
 CONSTRAINT [pk_adv_h] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[AdvNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_BillAcceptDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_BillAcceptDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[BillAcceptNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[InvNo] [varchar](50) NULL,
	[AmtAdvance] [float] NULL,
	[AmtChargeNonVAT] [float] NULL,
	[AmtChargeVAT] [float] NULL,
	[AmtWH] [float] NULL,
	[AmtVAT] [float] NULL,
	[AmtTotal] [float] NULL,
	[CurrencyCode] [varchar](50) NULL,
	[ExchangeRate] [float] NULL,
	[AmtCustAdvance] [float] NULL,
	[AmtForeign] [float] NULL,
	[InvDate] [datetime] NULL,
	[RefNo] [nvarchar](max) NULL,
	[AmtVATRate] [float] NULL,
	[AmtWHRate] [float] NULL,
	[AmtDiscount] [float] NULL,
	[AmtDiscRate] [float] NULL,
 CONSTRAINT [PK_BillAcceptD] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BillAcceptNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_BillAcceptHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_BillAcceptHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[BillAcceptNo] [varchar](15) NOT NULL,
	[BillDate] [datetime] NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](4) NULL,
	[BillRecvBy] [varchar](30) NULL,
	[BillRecvDate] [datetime] NULL,
	[DuePaymentDate] [datetime] NULL,
	[BillRemark] [nvarchar](max) NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[EmpCode] [varchar](50) NULL,
	[RecDateTime] [datetime] NULL,
	[TotalCustAdv] [float] NULL,
	[TotalAdvance] [float] NULL,
	[TotalChargeVAT] [float] NULL,
	[TotalChargeNonVAT] [float] NULL,
	[TotalVAT] [float] NULL,
	[TotalWH] [float] NULL,
	[TotalDiscount] [float] NULL,
	[TotalNet] [float] NULL,
 CONSTRAINT [PK_BillAcceptH] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BillAcceptNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_BudgetPolicy]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_BudgetPolicy](
	[ID] [int] NOT NULL,
	[BranchCode] [varchar](5) NULL,
	[JobType] [tinyint] NULL,
	[ShipBy] [tinyint] NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[TRemark] [nvarchar](max) NULL,
	[MaxAdvance] [float] NULL,
	[MaxCost] [float] NULL,
	[MinCharge] [float] NULL,
	[MinProfit] [float] NULL,
	[Active] [varchar](5) NULL,
	[LastUpdate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_CashControl]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_CashControl](
	[BranchCode] [varchar](3) NOT NULL,
	[ControlNo] [varchar](15) NOT NULL,
	[VoucherDate] [datetime] NULL,
	[TRemark] [nvarchar](max) NULL,
	[RecUser] [varchar](50) NULL,
	[RecDate] [datetime] NULL,
	[RecTime] [datetime] NULL,
	[PostedBy] [varchar](50) NULL,
	[PostedDate] [datetime] NULL,
	[PostedTime] [datetime] NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](4) NULL,
	[PostRefNo] [varchar](20) NULL,
 CONSTRAINT [PK_CashControl] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ControlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_CashControlDoc]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_CashControlDoc](
	[BranchCode] [varchar](3) NOT NULL,
	[ControlNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[DocType] [varchar](5) NULL,
	[DocNo] [varchar](50) NOT NULL,
	[DocDate] [datetime] NULL,
	[CmpType] [varchar](1) NULL,
	[CmpCode] [varchar](15) NULL,
	[CmpBranch] [varchar](4) NULL,
	[PaidAmount] [float] NULL,
	[TotalAmount] [float] NULL,
	[acType] [varchar](15) NULL,
 CONSTRAINT [PK_CashControldoc] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ControlNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_CashControlSub]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_CashControlSub](
	[BranchCode] [varchar](3) NOT NULL,
	[ControlNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[PRVoucher] [varchar](20) NULL,
	[PRType] [varchar](1) NULL,
	[ChqNo] [varchar](20) NULL,
	[BookCode] [varchar](15) NULL,
	[BankCode] [varchar](10) NULL,
	[BankBranch] [varchar](50) NULL,
	[ChqDate] [datetime] NULL,
	[CashAmount] [float] NULL,
	[ChqAmount] [float] NULL,
	[CreditAmount] [float] NULL,
	[IsLocal] [tinyint] NULL,
	[ChqStatus] [varchar](1) NULL,
	[TRemark] [nvarchar](max) NULL,
	[PayChqTo] [nvarchar](max) NULL,
	[DocNo] [varchar](15) NULL,
	[SICode] [varchar](100) NULL,
	[RecvBank] [varchar](5) NULL,
	[RecvBranch] [varchar](50) NULL,
	[acType] [varchar](15) NULL,
	[SumAmount] [float] NULL,
	[CurrencyCode] [varchar](20) NULL,
	[ExchangeRate] [float] NULL,
	[TotalAmount] [float] NULL,
	[VatInc] [float] NULL,
	[VatExc] [float] NULL,
	[WhtInc] [float] NULL,
	[WhtExc] [float] NULL,
	[TotalNet] [float] NULL,
	[ForJNo] [varchar](15) NULL,
 CONSTRAINT [PK_CashControlSub] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ControlNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_ClearDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_ClearDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[ClrNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[LinkItem] [smallint] NULL,
	[STCode] [varchar](10) NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[VenderCode] [varchar](10) NULL,
	[Qty] [float] NULL,
	[UnitCode] [varchar](10) NULL,
	[CurrencyCode] [varchar](3) NULL,
	[CurRate] [float] NULL,
	[UnitPrice] [float] NULL,
	[FPrice] [float] NULL,
	[BPrice] [float] NULL,
	[QUnitPrice] [float] NULL,
	[QFPrice] [float] NULL,
	[QBPrice] [float] NULL,
	[UnitCost] [float] NULL,
	[FCost] [float] NULL,
	[BCost] [float] NULL,
	[ChargeVAT] [float] NULL,
	[Tax50Tavi] [float] NULL,
	[AdvNO] [varchar](15) NULL,
	[AdvAmount] [float] NULL,
	[UsedAmount] [float] NULL,
	[IsQuoItem] [tinyint] NULL,
	[SlipNO] [varchar](50) NULL,
	[Remark] [nvarchar](max) NULL,
	[IsDuplicate] [tinyint] NULL,
	[IsLtdAdv50Tavi] [tinyint] NULL,
	[Pay50TaviTo] [nvarchar](255) NULL,
	[NO50Tavi] [varchar](10) NULL,
	[Date50Tavi] [datetime] NULL,
	[VenderBillingNo] [varchar](15) NULL,
	[AirQtyStep] [varchar](100) NULL,
	[StepSub] [varchar](4000) NULL,
	[JobNo] [varchar](15) NULL,
	[AdvItemNo] [smallint] NULL,
	[LinkBillNo] [varchar](50) NULL,
	[VATType] [smallint] NULL,
	[VATRate] [float] NULL,
	[Tax50TaviRate] [float] NULL,
	[QNo] [varchar](15) NULL,
	[FNet] [float] NOT NULL,
	[BNet] [float] NOT NULL,
 CONSTRAINT [pK_ClearDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ClrNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_ClearExp]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_ClearExp](
	[BranchCode] [varchar](5) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[SICode] [nvarchar](10) NOT NULL,
	[SDescription] [nvarchar](max) NULL,
	[TRemark] [nvarchar](max) NULL,
	[AmountCharge] [float] NULL,
	[Status] [varchar](5) NULL,
	[CurrencyCode] [varchar](50) NULL,
	[ExchangeRate] [float] NULL DEFAULT ((1)),
	[Qty] [float] NULL,
	[QtyUnit] [varchar](50) NULL,
	[AmtVatRate] [float] NULL,
	[AmtVat] [float] NULL,
	[AmtWht] [float] NULL,
	[AmtWhtRate] [float] NULL,
	[AmtTotal] [float] NULL,
 CONSTRAINT [PK_ClearExp] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[JNo] ASC,
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_ClearHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_ClearHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[ClrNo] [varchar](15) NOT NULL,
	[ClrDate] [datetime] NULL,
	[ClearanceDate] [datetime] NULL,
	[EmpCode] [varchar](50) NULL,
	[AdvRefNo] [varchar](255) NULL,
	[AdvTotal] [float] NULL,
	[JobType] [tinyint] NULL,
	[JNo] [varchar](15) NULL,
	[InvNo] [varchar](100) NULL,
	[ClearType] [tinyint] NULL,
	[ClearFrom] [tinyint] NULL,
	[DocStatus] [tinyint] NULL,
	[TotalExpense] [float] NULL,
	[TRemark] [nvarchar](max) NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[ReceiveBy] [varchar](50) NULL,
	[ReceiveDate] [datetime] NULL,
	[ReceiveTime] [datetime] NULL,
	[ReceiveRef] [varchar](20) NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[CoPersonCode] [varchar](15) NULL,
	[CTN_NO] [nvarchar](50) NULL,
	[ClearTotal] [float] NULL,
	[ClearVat] [float] NOT NULL,
	[ClearWht] [float] NOT NULL,
	[ClearNet] [float] NOT NULL,
	[ClearBill] [float] NOT NULL,
	[ClearCost] [float] NOT NULL,
 CONSTRAINT [PK_ClearHeader] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ClrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_CNDNDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_CNDNDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[DocNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[BillingNo] [varchar](15) NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[OriginalAmt] [float] NULL,
	[CorrectAmt] [float] NULL,
	[DiffAmt] [float] NULL,
	[IsTaxCharge] [int] NULL,
	[VATRate] [float] NULL,
	[VATAmt] [float] NULL,
	[TotalNet] [float] NULL,
	[CurrencyCode] [varchar](3) NULL,
	[ExchangeRate] [float] NULL,
	[ForeignNet] [float] NULL,
	[Is50Tavi] [int] NULL,
	[WHTRate] [float] NULL,
	[WHTAmt] [float] NULL,
	[BillItemNo] [int] NULL,
 CONSTRAINT [PK_CNDNDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_CNDNHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_CNDNHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[DocNo] [varchar](15) NOT NULL,
	[DocType] [smallint] NULL,
	[CustCode] [varchar](15) NOT NULL,
	[CustBranch] [varchar](5) NOT NULL,
	[DocDate] [datetime] NULL,
	[EmpCode] [varchar](50) NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[LastupDate] [datetime] NULL,
	[DocStatus] [int] NULL,
	[CancelDate] [datetime] NULL,
	[CancelReason] [varchar](255) NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_CNDN] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_Document]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_Document](
	[BranchCode] [varchar](5) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[DocType] [varchar](5) NULL,
	[DocDate] [datetime] NULL,
	[DocNo] [varchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[FileType] [varchar](5) NULL,
	[FilePath] [varchar](max) NULL,
	[FileSize] [float] NULL,
	[UploadBy] [varchar](50) NULL,
	[UploadDate] [datetime] NULL,
	[CheckedBy] [varchar](50) NULL,
	[CheckedDate] [datetime] NULL,
	[CheckNote] [nvarchar](max) NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveDate] [datetime] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[JNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_GLDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_GLDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[GLRefNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[GLAccountCode] [varchar](50) NULL,
	[GLDescription] [nvarchar](max) NULL,
	[SourceDocument] [nvarchar](max) NULL,
	[DebitAmt] [float] NULL,
	[CreditAmt] [float] NULL,
	[EntryDate] [datetime] NULL,
	[EntryBy] [varchar](50) NULL,
 CONSTRAINT [PK_GLDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[GLRefNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_GLHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_GLHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[GLRefNo] [varchar](15) NOT NULL,
	[FiscalYear] [varchar](10) NOT NULL,
	[LastupDate] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[GLType] [varchar](10) NULL,
	[Remark] [nvarchar](max) NULL,
	[TotalDebit] [float] NULL,
	[TotalCredit] [float] NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveBy] [varchar](50) NULL,
	[PostDate] [datetime] NULL,
	[PostBy] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelBy] [varchar](50) NULL,
	[CancelReason] [nvarchar](max) NULL,
	[BatchDate] [datetime] NULL,
 CONSTRAINT [PK_GLHeader] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[GLRefNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_InvoiceDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_InvoiceDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[DocNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[ExpSlipNO] [varchar](100) NULL,
	[SRemark] [nvarchar](max) NULL,
	[CurrencyCode] [varchar](50) NULL,
	[ExchangeRate] [float] NOT NULL,
	[Qty] [float] NOT NULL,
	[QtyUnit] [varchar](30) NULL,
	[UnitPrice] [float] NOT NULL,
	[FUnitPrice] [float] NOT NULL,
	[Amt] [float] NOT NULL,
	[FAmt] [float] NOT NULL,
	[DiscountType] [int] NOT NULL,
	[DiscountPerc] [float] NOT NULL,
	[AmtDiscount] [float] NOT NULL,
	[FAmtDiscount] [float] NOT NULL,
	[Is50Tavi] [tinyint] NOT NULL,
	[Rate50Tavi] [float] NOT NULL,
	[Amt50Tavi] [float] NOT NULL,
	[IsTaxCharge] [tinyint] NOT NULL,
	[AmtVat] [float] NOT NULL,
	[TotalAmt] [float] NOT NULL,
	[FTotalAmt] [float] NOT NULL,
	[AmtAdvance] [float] NOT NULL,
	[AmtCharge] [float] NOT NULL,
	[CurrencyCodeCredit] [varchar](50) NULL,
	[ExchangeRateCredit] [float] NOT NULL,
	[AmtCredit] [float] NOT NULL,
	[FAmtCredit] [float] NOT NULL,
	[VATRate] [float] NOT NULL,
 CONSTRAINT [PK_InvD] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_InvoiceHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_InvoiceHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[DocNo] [varchar](15) NOT NULL,
	[DocDate] [datetime] NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](4) NULL,
	[BillToCustCode] [varchar](15) NULL,
	[BillToCustBranch] [varchar](4) NULL,
	[ContactName] [nvarchar](max) NULL,
	[EmpCode] [varchar](50) NULL,
	[PrintedBy] [varchar](50) NULL,
	[PrintedDate] [datetime] NULL,
	[PrintedTime] [datetime] NULL,
	[RefNo] [nvarchar](max) NULL,
	[VATRate] [float] NULL,
	[TotalAdvance] [float] NULL,
	[TotalCharge] [float] NULL,
	[TotalIsTaxCharge] [float] NULL,
	[TotalIs50Tavi] [float] NULL,
	[TotalVAT] [float] NULL,
	[Total50Tavi] [float] NULL,
	[TotalCustAdv] [float] NULL,
	[TotalNet] [float] NULL,
	[CurrencyCode] [varchar](50) NULL,
	[ExchangeRate] [float] NULL,
	[ForeignNet] [float] NULL,
	[BillAcceptDate] [datetime] NULL,
	[BillIssueDate] [datetime] NULL,
	[BillAcceptNo] [varchar](15) NULL,
	[Remark1] [nvarchar](max) NULL,
	[Remark2] [nvarchar](max) NULL,
	[Remark3] [nvarchar](max) NULL,
	[Remark4] [nvarchar](max) NULL,
	[Remark5] [nvarchar](max) NULL,
	[Remark6] [nvarchar](max) NULL,
	[Remark7] [nvarchar](max) NULL,
	[Remark8] [nvarchar](max) NULL,
	[Remark9] [nvarchar](max) NULL,
	[Remark10] [nvarchar](max) NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[ShippingRemark] [nvarchar](max) NULL,
	[SumDiscount] [float] NULL,
	[DiscountRate] [float] NULL,
	[DiscountCal] [float] NULL,
	[TotalDiscount] [float] NULL,
	[DueDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_InvH] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_LoadInfo]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_LoadInfo](
	[BranchCode] [varchar](3) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[VenderCode] [varchar](10) NULL,
	[ContactName] [nvarchar](max) NULL,
	[BookingNo] [varchar](50) NOT NULL,
	[LoadDate] [datetime] NULL,
	[Remark] [nvarchar](max) NULL,
	[PackingPlace] [nvarchar](max) NULL,
	[CYPlace] [nvarchar](max) NULL,
	[FactoryPlace] [nvarchar](max) NULL,
	[ReturnPlace] [nvarchar](max) NULL,
	[PackingDate] [datetime] NULL,
	[CYDate] [datetime] NULL,
	[FactoryDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[PackingTime] [datetime] NULL,
	[CYTime] [datetime] NULL,
	[FactoryTime] [datetime] NULL,
	[ReturnTime] [datetime] NULL,
	[NotifyCode] [varchar](50) NULL,
	[TransMode] [varchar](50) NULL,
	[PaymentCondition] [nvarchar](max) NULL,
	[PaymentBy] [nvarchar](max) NULL,
	[CYAddress] [nvarchar](max) NULL,
	[PackingAddress] [nvarchar](max) NULL,
	[FactoryAddress] [nvarchar](max) NULL,
	[ReturnAddress] [nvarchar](max) NULL,
	[CYContact] [nvarchar](max) NULL,
	[PackingContact] [nvarchar](max) NULL,
	[FactoryContact] [nvarchar](max) NULL,
	[ReturnContact] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoadInfo] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BookingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_LoadInfoDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_LoadInfoDetail](
	[BranchCode] [varchar](3) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[CTN_NO] [nvarchar](50) NULL,
	[SealNumber] [varchar](20) NULL,
	[TruckNO] [varchar](15) NULL,
	[TruckIN] [datetime] NULL,
	[Start] [datetime] NULL,
	[Finish] [datetime] NULL,
	[CauseCode] [varchar](5) NULL,
	[Comment] [nvarchar](max) NULL,
	[TruckType] [varchar](20) NULL,
	[Driver] [nvarchar](max) NULL,
	[TargetYardDate] [datetime] NULL,
	[TargetYardTime] [datetime] NULL,
	[ActualYardDate] [datetime] NULL,
	[ActualYardTime] [datetime] NULL,
	[UnloadFinishDate] [datetime] NULL,
	[UnloadFinishTime] [datetime] NULL,
	[UnloadDate] [datetime] NULL,
	[UnloadTime] [datetime] NULL,
	[Location] [nvarchar](max) NULL,
	[ReturnDate] [datetime] NULL,
	[ShippingMark] [nvarchar](max) NULL,
	[ProductDesc] [nvarchar](max) NULL,
	[CTN_SIZE] [varchar](15) NULL,
	[ProductQty] [float] NULL,
	[ProductUnit] [varchar](20) NULL,
	[GrossWeight] [float] NULL,
	[Measurement] [float] NULL,
	[BookingNo] [varchar](50) NOT NULL,
	[TimeUsed] [float] NULL,
	[DeliveryNo] [nvarchar](50) NULL DEFAULT (''),
	[LocationID] [int] NULL,
	[NetWeight] [float] NULL DEFAULT ((0)),
	[ProductPrice] [float] NULL DEFAULT ((0)),
	[PlaceName1] [nvarchar](max) NULL,
	[PlaceAddress1] [nvarchar](max) NULL,
	[PlaceContact1] [nvarchar](max) NULL,
	[PlaceName2] [nvarchar](max) NULL,
	[PlaceAddress2] [nvarchar](max) NULL,
	[PlaceContact2] [nvarchar](max) NULL,
	[PlaceName3] [nvarchar](max) NULL,
	[PlaceAddress3] [nvarchar](max) NULL,
	[PlaceContact3] [nvarchar](max) NULL,
	[PlaceName4] [nvarchar](max) NULL,
	[PlaceAddress4] [nvarchar](max) NULL,
	[PlaceContact4] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoadInfoDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BookingNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_Order]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_Order](
	[BranchCode] [varchar](5) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[JRevise] [tinyint] NULL,
	[ConfirmDate] [datetime] NULL,
	[CPolicyCode] [varchar](10) NULL,
	[DocDate] [datetime] NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](5) NULL,
	[CustContactName] [nvarchar](max) NULL,
	[QNo] [varchar](15) NULL,
	[Revise] [smallint] NULL,
	[ManagerCode] [varchar](50) NULL,
	[CSCode] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[TRemark] [nvarchar](max) NULL,
	[JobStatus] [tinyint] NULL,
	[JobType] [tinyint] NULL,
	[ShipBy] [tinyint] NULL,
	[InvNo] [nvarchar](max) NULL,
	[InvTotal] [float] NULL,
	[InvProduct] [nvarchar](max) NULL,
	[InvCountry] [varchar](2) NULL,
	[InvFCountry] [varchar](2) NULL,
	[InvInterPort] [varchar](3) NULL,
	[InvProductQty] [float] NULL,
	[InvProductUnit] [varchar](3) NULL,
	[InvCurUnit] [varchar](3) NULL,
	[InvCurRate] [float] NULL,
	[ImExDate] [datetime] NULL,
	[BLNo] [varchar](40) NULL,
	[BookingNo] [varchar](50) NULL,
	[ClearPort] [varchar](5) NULL,
	[ClearPortNo] [nvarchar](max) NULL,
	[ClearDate] [datetime] NULL,
	[LoadDate] [datetime] NULL,
	[ForwarderCode] [varchar](10) NULL,
	[AgentCode] [varchar](10) NULL,
	[VesselName] [varchar](50) NULL,
	[ETDDate] [datetime] NULL,
	[ETADate] [datetime] NULL,
	[ETTime] [datetime] NULL,
	[FNetPrice] [varchar](50) NULL,
	[BNetPrice] [float] NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelProveDate] [datetime] NULL,
	[CancelProveTime] [datetime] NULL,
	[CloseJobDate] [datetime] NULL,
	[CloseJobTime] [datetime] NULL,
	[CloseJobBy] [varchar](50) NULL,
	[DeclareType] [varchar](3) NULL,
	[DeclareNumber] [varchar](20) NULL,
	[DeclareStatus] [varchar](1) NULL,
	[TyAuthorSp] [varchar](2) NULL,
	[Ty19BIS] [varchar](2) NULL,
	[TyClearTax] [varchar](2) NULL,
	[TyClearTaxReson] [varchar](1000) NULL,
	[EstDeliverDate] [datetime] NULL,
	[EstDeliverTime] [datetime] NULL,
	[TotalContainer] [varchar](50) NULL,
	[DutyDate] [datetime] NULL,
	[DutyAmount] [float] NULL,
	[DutyCustPayOther] [varchar](30) NULL,
	[DutyCustPayChqAmt] [float] NULL,
	[DutyCustPayBankAmt] [float] NULL,
	[DutyCustPayEPAYAmt] [float] NULL,
	[DutyCustPayCardAmt] [float] NULL,
	[DutyCustPayCashAmt] [float] NULL,
	[DutyCustPayOtherAmt] [float] NULL,
	[DutyLtdPayOther] [varchar](30) NULL,
	[DutyLtdPayChqAmt] [float] NULL,
	[DutyLtdPayEPAYAmt] [float] NULL,
	[DutyLtdPayCashAmt] [float] NULL,
	[DutyLtdPayOtherAmt] [float] NULL,
	[ConfirmChqDate] [datetime] NULL,
	[ShippingEmp] [varchar](50) NULL,
	[ShippingCmd] [nvarchar](max) NULL,
	[TotalGW] [float] NULL,
	[GWUnit] [varchar](3) NULL,
	[TSRequest] [tinyint] NULL,
	[ShipmentType] [tinyint] NULL,
	[ReadyToClearDate] [datetime] NULL,
	[Commission] [int] NULL,
	[CommPayTo] [varchar](100) NULL,
	[ProjectName] [nvarchar](max) NULL,
	[MVesselName] [varchar](50) NULL,
	[TotalNW] [float] NULL,
	[Measurement] [varchar](20) NULL,
	[CustRefNO] [varchar](50) NULL,
	[TotalQty] [varchar](50) NULL,
	[HAWB] [varchar](50) NULL,
	[MAWB] [varchar](50) NULL,
	[consigneecode] [varchar](50) NULL,
	[privilegests] [varchar](255) NULL,
	[DeliveryNo] [nvarchar](50) NULL,
	[DeliveryTo] [nvarchar](500) NULL,
	[DeliveryAddr] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [pk_JobOrder] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[JNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_OrderLog]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_OrderLog](
	[BranchCode] [varchar](5) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[EmpCode] [varchar](50) NULL,
	[LogDate] [datetime] NULL,
	[LogTime] [datetime] NULL,
	[TRemark] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderLog] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[JNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_PaymentDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_PaymentDetail](
	[BranchCode] [varchar](3) NOT NULL,
	[DocNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[SRemark] [nvarchar](max) NULL,
	[Qty] [float] NOT NULL,
	[QtyUnit] [varchar](30) NULL,
	[UnitPrice] [float] NOT NULL,
	[IsTaxCharge] [tinyint] NOT NULL,
	[Is50Tavi] [tinyint] NOT NULL,
	[DiscountPerc] [float] NOT NULL,
	[Amt] [float] NOT NULL,
	[AmtDisc] [float] NOT NULL,
	[AmtVAT] [float] NOT NULL,
	[AmtWHT] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[FTotal] [float] NOT NULL,
	[ForJNo] [varchar](50) NULL,
	[ClrRefNo] [nvarchar](50) NULL,
	[BookingRefNo] [nvarchar](50) NULL,
	[BookingItemNo] [int] NULL,
	[AdvItemNo] [int] NULL,
	[ClrItemNo] [int] NULL,
 CONSTRAINT [PK_PaymentDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_PaymentHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_PaymentHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[DocNo] [varchar](15) NOT NULL,
	[DocDate] [datetime] NULL,
	[VenCode] [varchar](15) NULL,
	[ContactName] [nvarchar](max) NULL,
	[EmpCode] [varchar](50) NULL,
	[PoNo] [varchar](50) NULL,
	[VATRate] [float] NOT NULL,
	[TaxRate] [float] NOT NULL,
	[TotalExpense] [float] NOT NULL,
	[TotalTax] [float] NOT NULL,
	[TotalVAT] [float] NOT NULL,
	[TotalDiscount] [float] NOT NULL,
	[TotalNet] [float] NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[CurrencyCode] [varchar](50) NULL,
	[ExchangeRate] [float] NOT NULL,
	[ForeignAmt] [float] NOT NULL,
	[RefNo] [varchar](50) NULL,
	[PayType] [varchar](2) NULL,
	[AdvRef] [varchar](20) NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[PaymentBy] [varchar](50) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentTime] [datetime] NULL,
	[PaymentRef] [varchar](20) NULL,
	[ApproveRef] [varchar](50) NULL,
 CONSTRAINT [PK_PaymentH] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_QuotationDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_QuotationDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[QNo] [varchar](15) NOT NULL,
	[SeqNo] [smallint] NOT NULL,
	[JobType] [smallint] NOT NULL,
	[ShipBy] [smallint] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuoDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[QNo] ASC,
	[SeqNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_QuotationHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_QuotationHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[QNo] [varchar](15) NOT NULL,
	[ReferQNo] [varchar](20) NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](4) NULL,
	[BillToCustCode] [varchar](15) NULL,
	[BillToCustBranch] [varchar](5) NULL,
	[ContactName] [nvarchar](max) NULL,
	[DocDate] [datetime] NULL,
	[ManagerCode] [varchar](50) NULL,
	[DescriptionH] [nvarchar](max) NULL,
	[DescriptionF] [nvarchar](max) NULL,
	[TRemark] [nvarchar](max) NULL,
	[DocStatus] [int] NULL,
	[ApproveBy] [varchar](50) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[CancelBy] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelReason] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuotaionH] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[QNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_QuotationItem]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_QuotationItem](
	[BranchCode] [varchar](5) NOT NULL,
	[QNo] [varchar](15) NOT NULL,
	[SeqNo] [smallint] NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[SICode] [varchar](10) NULL,
	[DescriptionThai] [nvarchar](max) NULL,
	[CalculateType] [int] NOT NULL,
	[QtyBegin] [float] NULL,
	[QtyEnd] [float] NULL,
	[UnitCheck] [varchar](10) NOT NULL,
	[CurrencyCode] [varchar](3) NULL,
	[CurrencyRate] [float] NOT NULL,
	[ChargeAmt] [float] NOT NULL,
	[Isvat] [int] NOT NULL,
	[VatRate] [float] NULL,
	[VatAmt] [float] NOT NULL,
	[IsTax] [int] NOT NULL,
	[TaxRate] [float] NULL,
	[TaxAmt] [float] NOT NULL,
	[TotalAmt] [float] NOT NULL,
	[TotalCharge] [float] NOT NULL,
	[UnitDiscntPerc] [float] NOT NULL,
	[UnitDiscntAmt] [float] NOT NULL,
	[VenderCode] [varchar](10) NULL,
	[VenderCost] [float] NULL,
	[BaseProfit] [float] NULL,
	[CommissionPerc] [float] NULL,
	[CommissionAmt] [float] NULL,
	[NetProfit] [float] NULL,
	[IsRequired] [int] NOT NULL,
 CONSTRAINT [PK_QuoItem] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[QNo] ASC,
	[SeqNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_ReceiptDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_ReceiptDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[ReceiptNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[CreditAmount] [float] NULL,
	[CashAmount] [float] NULL,
	[TransferAmount] [float] NULL,
	[ChequeAmount] [float] NULL,
	[ControlNo] [varchar](15) NULL,
	[VoucherNo] [varchar](15) NULL,
	[ControlItemNo] [int] NULL,
	[InvoiceNo] [varchar](15) NULL,
	[InvoiceItemNo] [int] NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[VATRate] [float] NULL,
	[Rate50Tavi] [float] NULL,
	[Amt] [float] NULL,
	[AmtVAT] [float] NULL,
	[Amt50Tavi] [float] NULL,
	[Net] [float] NULL,
	[DCurrencyCode] [varchar](50) NULL,
	[DExchangeRate] [float] NULL,
	[FAmt] [float] NULL,
	[FAmtVAT] [float] NULL,
	[FAmt50Tavi] [float] NULL,
	[FNet] [float] NULL,
 CONSTRAINT [PK_ReceiptD] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ReceiptNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_ReceiptHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_ReceiptHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[ReceiptNo] [varchar](15) NOT NULL,
	[ReceiptDate] [datetime] NULL,
	[ReceiptType] [varchar](10) NULL,
	[CustCode] [varchar](15) NULL,
	[CustBranch] [varchar](4) NULL,
	[BillToCustCode] [varchar](15) NULL,
	[BillToCustBranch] [varchar](4) NULL,
	[TRemark] [nvarchar](max) NULL,
	[EmpCode] [varchar](50) NULL,
	[PrintedBy] [varchar](50) NULL,
	[PrintedDate] [datetime] NULL,
	[PrintedTime] [datetime] NULL,
	[ReceiveBy] [varchar](50) NULL,
	[ReceiveDate] [datetime] NULL,
	[ReceiveTime] [datetime] NULL,
	[ReceiveRef] [varchar](30) NULL,
	[CancelReson] [nvarchar](max) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelTime] [datetime] NULL,
	[CurrencyCode] [varchar](50) NULL,
	[ExchangeRate] [float] NULL,
	[TotalCharge] [float] NULL,
	[TotalVAT] [float] NULL,
	[Total50Tavi] [float] NULL,
	[TotalNet] [float] NULL,
	[FTotalNet] [float] NULL,
 CONSTRAINT [PK_ReceiptHeader] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ReceiptNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_SrvGroup]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_SrvGroup](
	[GroupCode] [varchar](10) NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[GLAccountCode] [varchar](15) NULL,
	[IsApplyPolicy] [int] NULL,
	[IsTaxCharge] [tinyint] NULL,
	[Is50Tavi] [tinyint] NULL,
	[Rate50Tavi] [float] NULL,
	[IsCredit] [tinyint] NULL,
	[IsExpense] [tinyint] NULL,
	[IsHaveSlip] [tinyint] NULL,
	[IsLtdAdv50Tavi] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_SrvSingle]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_SrvSingle](
	[SICode] [varchar](10) NOT NULL,
	[NameThai] [nvarchar](max) NULL,
	[NameEng] [nvarchar](max) NULL,
	[StdPrice] [float] NULL,
	[UnitCharge] [varchar](10) NULL,
	[CurrencyCode] [varchar](3) NULL,
	[DefaultVender] [varchar](15) NULL,
	[ProcessDesc] [nvarchar](max) NULL,
	[GLAccountCodeSales] [varchar](15) NULL,
	[GLAccountCodeCost] [varchar](15) NULL,
	[IsTaxCharge] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsTaxCharge]  DEFAULT ((0)),
	[Is50Tavi] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_Is50Tavi]  DEFAULT ((0)),
	[Rate50Tavi] [float] NOT NULL CONSTRAINT [DF_Job_SrvSingle_Rate50Tavi]  DEFAULT ((0)),
	[IsCredit] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsCredit]  DEFAULT ((0)),
	[IsExpense] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsExpense]  DEFAULT ((0)),
	[IsShowPrice] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsShowPrice]  DEFAULT ((0)),
	[IsHaveSlip] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsHaveSlip]  DEFAULT ((0)),
	[IsPay50TaviTo] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsPay50TaviTo]  DEFAULT ((0)),
	[IsLtdAdv50Tavi] [tinyint] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsLtdAdv50Tavi]  DEFAULT ((0)),
	[IsUsedCoSlip] [int] NOT NULL CONSTRAINT [DF_Job_SrvSingle_IsUsedCoSlip]  DEFAULT ((0)),
	[GroupCode] [varchar](10) NULL,
 CONSTRAINT [pk_sicode] PRIMARY KEY CLUSTERED 
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_TransportPlace]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_TransportPlace](
	[PlaceType] [int] NOT NULL,
	[PlaceName] [nvarchar](255) NOT NULL,
	[PlaceAddress] [nvarchar](max) NULL,
	[PlaceContact] [nvarchar](500) NULL,
 CONSTRAINT [PK_Job_TransportPlace] PRIMARY KEY CLUSTERED 
(
	[PlaceType] ASC,
	[PlaceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Job_TransportPrice]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_TransportPrice](
	[BranchCode] [varchar](5) NOT NULL,
	[LocationID] [int] NOT NULL,
	[VenderCode] [varchar](15) NOT NULL,
	[CustCode] [varchar](15) NOT NULL,
	[SICode] [varchar](10) NOT NULL,
	[CostAmount] [float] NULL,
	[ChargeAmount] [float] NULL,
	[SDescription] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[ChargeCode] [varchar](10) NULL,
 CONSTRAINT [PK_Job_TransportPrice] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[LocationID] ASC,
	[VenderCode] ASC,
	[CustCode] ASC,
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_TransportRoute]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_TransportRoute](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Place1] [nvarchar](255) NULL,
	[Place2] [nvarchar](255) NULL,
	[Place3] [nvarchar](255) NULL,
	[Place4] [nvarchar](255) NULL,
	[LocationRoute] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[Address1] [nvarchar](max) NULL,
	[Contact1] [nvarchar](500) NULL,
	[Address2] [nvarchar](max) NULL,
	[Contact2] [nvarchar](500) NULL,
	[Address3] [nvarchar](max) NULL,
	[Contact3] [nvarchar](500) NULL,
	[Address4] [nvarchar](max) NULL,
	[Contact4] [nvarchar](500) NULL,
	[RouteFormat] [nvarchar](4) NULL,
 CONSTRAINT [PK_Job_TransportRoute] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[job_transportroutetemp]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_transportroutetemp](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[Place1] [nvarchar](255) NULL,
	[Place2] [nvarchar](255) NULL,
	[Place3] [nvarchar](255) NULL,
	[Place4] [nvarchar](255) NULL,
	[LocationRoute] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[Address1] [nvarchar](max) NULL,
	[Contact1] [nvarchar](500) NULL,
	[Address2] [nvarchar](max) NULL,
	[Contact2] [nvarchar](500) NULL,
	[Address3] [nvarchar](max) NULL,
	[Contact3] [nvarchar](500) NULL,
	[Address4] [nvarchar](max) NULL,
	[Contact4] [nvarchar](500) NULL,
	[RouteFormat] [nvarchar](4) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Job_WHTax]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_WHTax](
	[BranchCode] [varchar](4) NOT NULL,
	[DocNo] [varchar](50) NOT NULL,
	[DocDate] [datetime] NULL,
	[TaxNumber1] [varchar](15) NULL,
	[TName1] [nvarchar](max) NULL,
	[TAddress1] [nvarchar](max) NULL,
	[TaxNumber2] [varchar](15) NULL,
	[TName2] [nvarchar](max) NULL,
	[TAddress2] [nvarchar](max) NULL,
	[TaxNumber3] [varchar](15) NULL,
	[TName3] [nvarchar](max) NULL,
	[TAddress3] [nvarchar](max) NULL,
	[IDCard1] [varchar](15) NULL,
	[IDCard2] [varchar](15) NULL,
	[IDCard3] [varchar](15) NULL,
	[SeqInForm] [int] NULL,
	[FormType] [tinyint] NULL,
	[TaxLawNo] [varchar](2) NULL,
	[IncRate] [float] NULL,
	[IncOther] [varchar](70) NULL,
	[UpdateBy] [nvarchar](255) NULL,
	[TotalPayAmount] [float] NULL,
	[TotalPayTax] [float] NULL,
	[SoLicenseNo] [varchar](50) NULL,
	[SoLicenseAmount] [float] NULL,
	[SoAccAmount] [float] NULL,
	[PayeeAccNo] [varchar](15) NULL,
	[SoTaxNo] [varchar](15) NULL,
	[PayTaxType] [tinyint] NULL,
	[PayTaxOther] [varchar](20) NULL,
	[CancelProve] [varchar](50) NULL,
	[CancelReason] [nvarchar](max) NULL,
	[CancelDate] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
	[TeacherAmt] [float] NULL,
	[Branch1] [varchar](5) NULL,
	[Branch2] [varchar](5) NULL,
	[Branch3] [varchar](5) NULL,
 CONSTRAINT [PK_JobWHTax] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Job_WHTaxDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Job_WHTaxDetail](
	[BranchCode] [varchar](4) NOT NULL,
	[DocNo] [varchar](50) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[IncType] [varchar](5) NULL,
	[PayDate] [datetime] NULL,
	[PayAmount] [float] NULL,
	[PayTax] [float] NULL,
	[PayTaxDesc] [nvarchar](max) NULL,
	[JNo] [varchar](15) NULL,
	[DocRefType] [tinyint] NULL,
	[DocRefNo] [varchar](20) NULL,
	[PayRate] [float] NULL,
 CONSTRAINT [PK_JobWHTaxD] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_Account]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_Account](
	[AccCode] [varchar](10) NOT NULL,
	[AccTName] [nvarchar](max) NULL,
	[AccEName] [nvarchar](max) NULL,
	[AccType] [int] NULL,
	[AccMain] [varchar](20) NULL,
	[AccSide] [char](1) NULL,
 CONSTRAINT [PK_Mas_Account] PRIMARY KEY CLUSTERED 
(
	[AccCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_BookAccount]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_BookAccount](
	[BranchCode] [varchar](5) NOT NULL,
	[BookCode] [varchar](15) NOT NULL,
	[BookName] [nvarchar](max) NULL,
	[BankCode] [varchar](10) NULL,
	[BankBranch] [varchar](50) NULL,
	[IsLocal] [tinyint] NOT NULL CONSTRAINT [DF_Mas_BookAccount_IsLocal]  DEFAULT ((0)),
	[ACType] [varchar](10) NULL,
	[TAddress1] [nvarchar](max) NULL,
	[TAddress2] [nvarchar](max) NULL,
	[EAddress1] [nvarchar](max) NULL,
	[EAddress2] [nvarchar](max) NULL,
	[Phone] [varchar](30) NULL,
	[FaxNumber] [varchar](30) NULL,
	[LimitBalance] [float] NULL DEFAULT ((0)),
	[GLAccountCode] [varchar](10) NULL DEFAULT (''),
	[ControlBalance] [float] NULL,
 CONSTRAINT [pk_masbookacc] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_Branch]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_Branch](
	[Code] [varchar](5) NOT NULL,
	[BrName] [nvarchar](max) NULL,
 CONSTRAINT [pk_branch] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_Company]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_Company](
	[CustCode] [varchar](15) NOT NULL,
	[Branch] [varchar](10) NOT NULL,
	[CustGroup] [varchar](20) NULL,
	[TaxNumber] [varchar](50) NULL,
	[Title] [nvarchar](15) NULL,
	[NameThai] [nvarchar](max) NULL,
	[NameEng] [nvarchar](max) NULL,
	[TAddress1] [nvarchar](max) NULL,
	[TAddress2] [nvarchar](max) NULL,
	[EAddress1] [nvarchar](max) NULL,
	[EAddress2] [nvarchar](max) NULL,
	[Phone] [nvarchar](255) NULL,
	[FaxNumber] [nvarchar](255) NULL,
	[LoginName] [varchar](20) NULL,
	[LoginPassword] [varchar](20) NULL,
	[ManagerCode] [varchar](10) NULL,
	[CSCodeIM] [varchar](20) NULL,
	[CSCodeEX] [varchar](20) NULL,
	[CSCodeOT] [varchar](20) NULL,
	[GLAccountCode] [varchar](15) NULL,
	[CustType] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_CustType]  DEFAULT ((0)),
	[BillToCustCode] [varchar](15) NULL,
	[BillToBranch] [varchar](10) NULL,
	[UsedLanguage] [varchar](2) NULL,
	[LevelGrade] [varchar](5) NULL,
	[TermOfPayment] [tinyint] NULL,
	[BillCondition] [nvarchar](max) NULL,
	[CreditLimit] [float] NULL,
	[MapText] [varchar](250) NULL,
	[MapFileName] [varchar](150) NULL,
	[CmpType] [varchar](1) NULL,
	[CmpLevelExp] [varchar](1) NULL,
	[CmpLevelImp] [varchar](1) NULL,
	[Is19bis] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_Is19bis]  DEFAULT ((0)),
	[MgrSeq] [smallint] NOT NULL CONSTRAINT [DF_Mas_Company_MgrSeq]  DEFAULT ((0)),
	[LevelNoExp] [int] NOT NULL CONSTRAINT [DF_Mas_Company_LevelNoExp]  DEFAULT ((0)),
	[LevelNoImp] [int] NOT NULL CONSTRAINT [DF_Mas_Company_LevelNoImp]  DEFAULT ((0)),
	[LnNO] [varchar](10) NULL,
	[AdjTaxCode] [varchar](10) NULL,
	[BkAuthorNo] [varchar](10) NULL,
	[BkAuthorCnn] [varchar](10) NULL,
	[LtdPsWkName] [varchar](70) NULL,
	[ConsStatus] [varchar](255) NULL,
	[CommLevel] [varchar](5) NULL,
	[DutyLimit] [float] NOT NULL CONSTRAINT [DF_Mas_Company_DutyLimit]  DEFAULT ((0)),
	[CommRate] [float] NOT NULL CONSTRAINT [DF_Mas_Company_CommRate]  DEFAULT ((0)),
	[TAddress] [nvarchar](max) NULL,
	[TDistrict] [nvarchar](max) NULL,
	[TSubProvince] [nvarchar](max) NULL,
	[TProvince] [nvarchar](255) NULL,
	[TPostCode] [nvarchar](255) NULL,
	[DMailAddress] [nvarchar](255) NULL,
	[PrivilegeOption] [varchar](1) NULL,
	[GoldCardNO] [smallint] NOT NULL CONSTRAINT [DF_Mas_Company_GoldCardNO]  DEFAULT ((0)),
	[CustomsBrokerSeq] [smallint] NOT NULL CONSTRAINT [DF_Mas_Company_CustomsBrokerSeq]  DEFAULT ((0)),
	[ISCustomerSign] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_ISCustomerSign]  DEFAULT ((0)),
	[ISCustomerSignInv] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_ISCustomerSignInv]  DEFAULT ((0)),
	[ISCustomerSignDec] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_ISCustomerSignDec]  DEFAULT ((0)),
	[ISCustomerSignECon] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_ISCustomerSignECon]  DEFAULT ((0)),
	[IsShippingCannotSign] [tinyint] NOT NULL CONSTRAINT [DF_Mas_Company_IsShippingCannotSign]  DEFAULT ((0)),
	[ExportCode] [varchar](20) NULL,
	[Code19BIS] [varchar](15) NULL,
	[WEB_SITE] [nvarchar](max) NULL,
 CONSTRAINT [pk_company] PRIMARY KEY CLUSTERED 
(
	[CustCode] ASC,
	[Branch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_CompanyContact]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_CompanyContact](
	[CustCode] [varchar](15) NOT NULL,
	[Branch] [varchar](10) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[Department] [nvarchar](255) NULL,
	[Position] [nvarchar](255) NULL,
	[ContactName] [nvarchar](max) NULL,
	[EMail] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
 CONSTRAINT [PK_CustContact] PRIMARY KEY CLUSTERED 
(
	[CustCode] ASC,
	[Branch] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_Config]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_Config](
	[ConfigCode] [nvarchar](50) NOT NULL,
	[ConfigKey] [nvarchar](500) NOT NULL,
	[ConfigValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[ConfigCode] ASC,
	[ConfigKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mas_ConfigTemp]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_ConfigTemp](
	[ConfigCode] [nvarchar](50) NOT NULL,
	[ConfigKey] [nvarchar](500) NOT NULL,
	[ConfigValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mas_CurrencyCode]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_CurrencyCode](
	[Code] [varchar](3) NOT NULL,
	[TName] [varchar](35) NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [pk_currency] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_User]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_User](
	[UserID] [varchar](50) NOT NULL,
	[UPassword] [varchar](70) NULL,
	[TName] [nvarchar](max) NULL,
	[EName] [nvarchar](max) NULL,
	[TPosition] [nvarchar](max) NULL,
	[LoginDate] [datetime] NULL,
	[LoginTime] [datetime] NULL,
	[LogoutDate] [datetime] NULL,
	[LogoutTime] [datetime] NULL,
	[UPosition] [smallint] NULL,
	[MaxRateDisc] [float] NULL,
	[MaxAdvance] [float] NULL,
	[JobAuthorize] [varchar](20) NULL,
	[EMail] [varchar](50) NULL,
	[MobilePhone] [varchar](50) NULL,
	[IsAlertByAgent] [tinyint] NULL,
	[IsAlertByEMail] [tinyint] NULL,
	[IsAlertBySMS] [tinyint] NULL,
	[UserUpline] [varchar](20) NULL,
	[GLAccountCode] [varchar](15) NULL,
	[UsedLanguage] [varchar](2) NULL,
	[DMailAccount] [varchar](50) NULL,
	[DMailPassword] [varchar](50) NULL,
	[JobPolicy] [varchar](255) NULL,
	[AlertPolicy] [varchar](255) NULL,
	[DeptID] [nvarchar](10) NULL,
 CONSTRAINT [pk_user] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_UserAuth]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_UserAuth](
	[UserID] [varchar](50) NOT NULL,
	[AppID] [varchar](50) NOT NULL,
	[MenuID] [varchar](255) NOT NULL,
	[Author] [varchar](10) NULL,
 CONSTRAINT [pk_userauth] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[AppID] ASC,
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_UserRole]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_UserRole](
	[RoleID] [varchar](50) NOT NULL,
	[RoleDesc] [nvarchar](255) NOT NULL,
	[RoleGroup] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_UserRoleDetail]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_UserRoleDetail](
	[RoleID] [varchar](50) NOT NULL,
	[UserID] [varchar](20) NOT NULL,
 CONSTRAINT [PK_RoleDetail] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_UserRolePolicy]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_UserRolePolicy](
	[RoleID] [varchar](50) NOT NULL,
	[ModuleID] [varchar](50) NOT NULL,
	[Author] [varchar](10) NULL,
 CONSTRAINT [PK_RolePolicy] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[ModuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_Vender]    Script Date: 3/26/2021 11:02:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_Vender](
	[VenCode] [varchar](50) NOT NULL,
	[BranchCode] [varchar](10) NULL,
	[TaxNumber] [varchar](30) NULL,
	[Title] [nvarchar](15) NULL,
	[TName] [nvarchar](max) NULL,
	[English] [nvarchar](max) NULL,
	[TAddress1] [nvarchar](max) NULL,
	[TAddress2] [nvarchar](max) NULL,
	[EAddress1] [nvarchar](max) NULL,
	[EAddress2] [nvarchar](max) NULL,
	[Phone] [varchar](30) NULL,
	[FaxNumber] [varchar](30) NULL,
	[LoginName] [varchar](20) NULL,
	[LoginPassword] [varchar](20) NULL,
	[GLAccountCode] [varchar](15) NULL,
	[ContactAcc] [nvarchar](max) NULL,
	[ContactSale] [nvarchar](max) NULL,
	[ContactSupport1] [nvarchar](max) NULL,
	[ContactSupport2] [nvarchar](max) NULL,
	[ContactSupport3] [nvarchar](max) NULL,
	[WEB_SITE] [nvarchar](max) NULL,
 CONSTRAINT [pk_vender] PRIMARY KEY CLUSTERED 
(
	[VenCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdvExpense]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvExpense] ON [dbo].[Job_AdvDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdvJob]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvJob] ON [dbo].[Job_AdvDetail]
(
	[BranchCode] ASC,
	[ForJNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Adv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Adv] ON [dbo].[Job_AdvDetail]
(
	[BranchCode] ASC,
	[ForJNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_AdvCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_AdvCode] ON [dbo].[Job_AdvDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdvCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvCancel] ON [dbo].[Job_AdvHeader]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdvCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvCust] ON [dbo].[Job_AdvHeader]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AdvDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvDate] ON [dbo].[Job_AdvHeader]
(
	[AdvDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdvIssueBy]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvIssueBy] ON [dbo].[Job_AdvHeader]
(
	[AdvBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdvReqBy]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvReqBy] ON [dbo].[Job_AdvHeader]
(
	[EmpCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AdvStatus]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AdvStatus] ON [dbo].[Job_AdvHeader]
(
	[DocStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BillInv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_BillInv] ON [dbo].[Job_BillAcceptDetail]
(
	[InvNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BillCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_BillCust] ON [dbo].[Job_BillAcceptHeader]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_BillDate] ON [dbo].[Job_BillAcceptHeader]
(
	[BillDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_VoucherCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherCancel] ON [dbo].[Job_CashControl]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_VoucherCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherCust] ON [dbo].[Job_CashControl]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VoucherDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherDate] ON [dbo].[Job_CashControl]
(
	[VoucherDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_voucherDoc]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_voucherDoc] ON [dbo].[Job_CashControlDoc]
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_VoucherDoc]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherDoc] ON [dbo].[Job_CashControlDoc]
(
	[DocType] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_VoucherLink]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherLink] ON [dbo].[Job_CashControlDoc]
(
	[BranchCode] ASC,
	[ControlNo] ASC,
	[acType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Chq]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Chq] ON [dbo].[Job_CashControlSub]
(
	[ChqNo] ASC,
	[BankCode] ASC,
	[ChqDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_CashControlSub]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_CashControlSub] ON [dbo].[Job_CashControlSub]
(
	[BookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_VoucherChq]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherChq] ON [dbo].[Job_CashControlSub]
(
	[BranchCode] ASC,
	[PRType] ASC,
	[ChqNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_VoucherSub]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_VoucherSub] ON [dbo].[Job_CashControlSub]
(
	[BranchCode] ASC,
	[PRVoucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearAdv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearAdv] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[AdvNO] ASC,
	[AdvItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearCode] ON [dbo].[Job_ClearDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearInv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearInv] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[LinkBillNo] ASC,
	[LinkItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearPayment]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearPayment] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[VenderBillingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Clear]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Clear] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[JobNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Clear_Adv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Clear_Adv] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[AdvNO] ASC,
	[AdvItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Clear_Code]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Clear_Code] ON [dbo].[Job_ClearDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Clear_Invoice]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Clear_Invoice] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[LinkBillNo] ASC,
	[LinkItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Vender_Clear]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Vender_Clear] ON [dbo].[Job_ClearDetail]
(
	[BranchCode] ASC,
	[VenderBillingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearCancel] ON [dbo].[Job_ClearHeader]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearContainer]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearContainer] ON [dbo].[Job_ClearHeader]
(
	[CTN_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClearDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearDate] ON [dbo].[Job_ClearHeader]
(
	[ClrDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClearStatus]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearStatus] ON [dbo].[Job_ClearHeader]
(
	[DocStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClearType]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearType] ON [dbo].[Job_ClearHeader]
(
	[ClearType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvCode] ON [dbo].[Job_InvoiceDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_InvoiceCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_InvoiceCode] ON [dbo].[Job_InvoiceDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvBill]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvBill] ON [dbo].[Job_InvoiceHeader]
(
	[BranchCode] ASC,
	[BillAcceptNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvBillTo]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvBillTo] ON [dbo].[Job_InvoiceHeader]
(
	[BillToCustCode] ASC,
	[BillToCustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvCancel] ON [dbo].[Job_InvoiceHeader]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvCreate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvCreate] ON [dbo].[Job_InvoiceHeader]
(
	[CreateDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvCust] ON [dbo].[Job_InvoiceHeader]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvDate] ON [dbo].[Job_InvoiceHeader]
(
	[DocDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvDue]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_InvDue] ON [dbo].[Job_InvoiceHeader]
(
	[DueDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Transport]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Transport] ON [dbo].[Job_LoadInfo]
(
	[BranchCode] ASC,
	[JNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobBooking]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobBooking] ON [dbo].[Job_LoadInfo]
(
	[BranchCode] ASC,
	[JNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobBookingKey]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobBookingKey] ON [dbo].[Job_LoadInfo]
(
	[BranchCode] ASC,
	[JNo] ASC,
	[BookingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TranCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranCust] ON [dbo].[Job_LoadInfo]
(
	[NotifyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TranCYDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranCYDate] ON [dbo].[Job_LoadInfo]
(
	[CYDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TranDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranDate] ON [dbo].[Job_LoadInfo]
(
	[LoadDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TranFacDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranFacDate] ON [dbo].[Job_LoadInfo]
(
	[FactoryDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TranPackDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranPackDate] ON [dbo].[Job_LoadInfo]
(
	[PackingDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TranReturnDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranReturnDate] ON [dbo].[Job_LoadInfo]
(
	[ReturnDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TranVender]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranVender] ON [dbo].[Job_LoadInfo]
(
	[VenderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AReturnDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AReturnDate] ON [dbo].[Job_LoadInfoDetail]
(
	[ReturnDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AUnloadDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AUnloadDate] ON [dbo].[Job_LoadInfoDetail]
(
	[UnloadFinishDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AYardDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AYardDate] ON [dbo].[Job_LoadInfoDetail]
(
	[ActualYardDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Cont]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cont] ON [dbo].[Job_LoadInfoDetail]
(
	[CTN_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_DeliveryNo]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_DeliveryNo] ON [dbo].[Job_LoadInfoDetail]
(
	[DeliveryNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Cont]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Cont] ON [dbo].[Job_LoadInfoDetail]
(
	[BranchCode] ASC,
	[JNo] ASC,
	[CTN_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Trans]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Trans] ON [dbo].[Job_LoadInfoDetail]
(
	[BranchCode] ASC,
	[JNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TranCont]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TranCont] ON [dbo].[Job_LoadInfoDetail]
(
	[BranchCode] ASC,
	[BookingNo] ASC,
	[JNo] ASC,
	[CTN_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TUnloadDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TUnloadDate] ON [dbo].[Job_LoadInfoDetail]
(
	[UnloadDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TYardDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TYardDate] ON [dbo].[Job_LoadInfoDetail]
(
	[TargetYardDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Booking]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Booking] ON [dbo].[Job_Order]
(
	[BranchCode] ASC,
	[BookingNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ClearPort]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ClearPort] ON [dbo].[Job_Order]
(
	[ClearPort] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobClearDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobClearDate] ON [dbo].[Job_Order]
(
	[ClearDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobCloseDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobCloseDate] ON [dbo].[Job_Order]
(
	[CloseJobDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobConfirmDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobConfirmDate] ON [dbo].[Job_Order]
(
	[ConfirmDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobConsignee]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobConsignee] ON [dbo].[Job_Order]
(
	[consigneecode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobCreate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobCreate] ON [dbo].[Job_Order]
(
	[CreateDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobCust] ON [dbo].[Job_Order]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobCustRef]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobCustRef] ON [dbo].[Job_Order]
(
	[CustRefNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobDate] ON [dbo].[Job_Order]
(
	[DocDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobDeclare]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobDeclare] ON [dbo].[Job_Order]
(
	[DeclareNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobDutyDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobDutyDate] ON [dbo].[Job_Order]
(
	[DutyDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobEstDeliver]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobEstDeliver] ON [dbo].[Job_Order]
(
	[EstDeliverDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobETADate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobETADate] ON [dbo].[Job_Order]
(
	[ETADate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobETDDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobETDDate] ON [dbo].[Job_Order]
(
	[ETDDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobForwarder]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobForwarder] ON [dbo].[Job_Order]
(
	[ForwarderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobHAWB]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobHAWB] ON [dbo].[Job_Order]
(
	[HAWB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobLoadDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobLoadDate] ON [dbo].[Job_Order]
(
	[LoadDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobMAWB]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobMAWB] ON [dbo].[Job_Order]
(
	[MAWB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobQuo]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobQuo] ON [dbo].[Job_Order]
(
	[BranchCode] ASC,
	[QNo] ASC,
	[Revise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobStatus]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobStatus] ON [dbo].[Job_Order]
(
	[JobStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_JobTransport]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobTransport] ON [dbo].[Job_Order]
(
	[AgentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobType]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_JobType] ON [dbo].[Job_Order]
(
	[JobType] ASC,
	[ShipBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayBooking]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayBooking] ON [dbo].[Job_PaymentDetail]
(
	[BranchCode] ASC,
	[BookingRefNo] ASC,
	[BookingItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayClear]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayClear] ON [dbo].[Job_PaymentDetail]
(
	[BranchCode] ASC,
	[ClrRefNo] ASC,
	[ClrItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayCode] ON [dbo].[Job_PaymentDetail]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayJob]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayJob] ON [dbo].[Job_PaymentDetail]
(
	[BranchCode] ASC,
	[ForJNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayAdv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayAdv] ON [dbo].[Job_PaymentHeader]
(
	[AdvRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayCancel] ON [dbo].[Job_PaymentHeader]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PayDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayDate] ON [dbo].[Job_PaymentHeader]
(
	[DocDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayInvNO]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayInvNO] ON [dbo].[Job_PaymentHeader]
(
	[RefNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayPoNO]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayPoNO] ON [dbo].[Job_PaymentHeader]
(
	[PoNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_PayVenCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_PayVenCode] ON [dbo].[Job_PaymentHeader]
(
	[VenCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuoType]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoType] ON [dbo].[Job_QuotationDetail]
(
	[JobType] ASC,
	[ShipBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuoAppDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoAppDate] ON [dbo].[Job_QuotationHeader]
(
	[ApproveDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuoBillCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoBillCust] ON [dbo].[Job_QuotationHeader]
(
	[BillToCustCode] ASC,
	[BillToCustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuoCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoCust] ON [dbo].[Job_QuotationHeader]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuoDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoDate] ON [dbo].[Job_QuotationHeader]
(
	[DocDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuoCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoCode] ON [dbo].[Job_QuotationItem]
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_QuoVender]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_QuoVender] ON [dbo].[Job_QuotationItem]
(
	[VenderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Recv_Inv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Recv_Inv] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[InvoiceNo] ASC,
	[InvoiceItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Job_Recv_Voucher]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_Job_Recv_Voucher] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[ControlNo] ASC,
	[ControlItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpControl]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpControl] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[ControlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpControlSub]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpControlSub] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[ControlNo] ASC,
	[ControlItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpInv]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpInv] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[InvoiceNo] ASC,
	[InvoiceItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpInvHeader]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpInvHeader] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[InvoiceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpVoucher]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpVoucher] ON [dbo].[Job_ReceiptDetail]
(
	[BranchCode] ASC,
	[VoucherNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpBillCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpBillCust] ON [dbo].[Job_ReceiptHeader]
(
	[BillToCustCode] ASC,
	[BillToCustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpCancel] ON [dbo].[Job_ReceiptHeader]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpCust]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpCust] ON [dbo].[Job_ReceiptHeader]
(
	[CustCode] ASC,
	[CustBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RcpDate]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpDate] ON [dbo].[Job_ReceiptHeader]
(
	[ReceiptDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RcpType]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_RcpType] ON [dbo].[Job_ReceiptHeader]
(
	[ReceiptType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ChargeCode]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_ChargeCode] ON [dbo].[Job_TransportPrice]
(
	[ChargeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FormType]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_FormType] ON [dbo].[Job_WHTax]
(
	[FormType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_WHDCancel]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_WHDCancel] ON [dbo].[Job_WHTax]
(
	[CancelProve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BillPlace]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_BillPlace] ON [dbo].[Mas_Company]
(
	[BillToCustCode] ASC,
	[BillToBranch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TaxNumber]    Script Date: 3/26/2021 11:02:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_TaxNumber] ON [dbo].[Mas_Company]
(
	[TaxNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [Is50Tavi]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [WHTRate]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [WHTAmt]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [BillItemNo]
GO
