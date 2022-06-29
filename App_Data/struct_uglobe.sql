USE [job_bop_new]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCommission]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  UserDefinedFunction [dbo].[GetDataSplit]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  Table [dbo].[Job_AddFuel]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_AddFuel](
	[BranchCode] [nvarchar](3) NOT NULL,
	[DocNo] [nvarchar](15) NOT NULL,
	[DocDate] [date] NULL,
	[CarLicense] [nvarchar](50) NULL,
	[Driver] [nvarchar](255) NULL,
	[FuelType] [nvarchar](50) NULL,
	[BudgetVolume] [float] NULL,
	[BudgetValue] [float] NULL,
	[ActualVolume] [float] NULL,
	[UnitPrice] [float] NULL,
	[TotalAmount] [float] NULL,
	[StationCode] [nvarchar](50) NULL,
	[StationInvNo] [nvarchar](50) NULL,
	[PaymentType] [nvarchar](50) NULL,
	[MileBegin] [float] NULL,
	[MileEnd] [float] NULL,
	[MileTotal] [float] NULL,
	[Remark] [nvarchar](max) NULL,
	[TotalWeight] [float] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
	[LastUpdate] [datetime] NULL,
	[ApproveBy] [nvarchar](50) NULL,
	[ApproveDate] [datetime] NULL,
	[CancelBy] [nvarchar](50) NULL,
	[CancelDate] [datetime] NULL,
	[CancelReason] [nvarchar](max) NULL,
	[BookingNo] [nvarchar](50) NULL,
	[BookingItemNo] [int] NULL,
	[JNo] [nvarchar](15) NULL,
	[TrailerNo] [nvarchar](50) NULL,
	[CarNo] [varchar](12) NULL,
	[EmpCode] [varchar](12) NULL,
	[InvoiceDate] [datetime] NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentRef] [varchar](50) NULL,
 CONSTRAINT [PK_Job_AddFuel] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_AdvDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[Doc50Tavi] [varchar](50) NULL,
	[Is50Tavi] [tinyint] NULL,
	[VATRate] [float] NULL,
	[AdvNet] [float] NULL,
	[SDescription] [nvarchar](max) NULL,
	[ForJNo] [varchar](15) NULL,
	[VenCode] [varchar](50) NULL,
	[CurrencyCode] [varchar](12) NULL,
	[ExchangeRate] [float] NOT NULL,
	[AdvQty] [float] NOT NULL,
	[UnitPrice] [float] NOT NULL,
 CONSTRAINT [pk_adv_d] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[AdvNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_AdvHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[ExchangeRate] [float] NOT NULL,
 CONSTRAINT [pk_adv_h] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[AdvNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_BillAcceptDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_BillAcceptHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_BudgetPolicy]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_CashControl]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_CashControlDoc]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_CashControlSub]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_ClearDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_ClearDetail](
	[BranchCode] [varchar](5) NOT NULL,
	[ClrNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[LinkItem] [smallint] NULL,
	[STCode] [varchar](10) NULL,
	[SICode] [varchar](10) NULL,
	[SDescription] [nvarchar](max) NULL,
	[VenderCode] [varchar](15) NULL,
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
	[NO50Tavi] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[Job_ClearExp]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[ExchangeRate] [float] NULL,
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
/****** Object:  Table [dbo].[Job_ClearHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_CNDNDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_CNDNHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_Document]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_GLDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_GLHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_InvoiceDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_InvoiceHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_LoadInfo]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_LoadInfo](
	[BranchCode] [varchar](3) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[VenderCode] [varchar](15) NULL,
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
/****** Object:  Table [dbo].[Job_LoadInfoDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_LoadInfoDetail](
	[BranchCode] [varchar](3) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[CTN_NO] [nvarchar](50) NULL,
	[SealNumber] [varchar](20) NULL,
	[TruckNO] [nvarchar](50) NULL,
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
	[DeliveryNo] [nvarchar](50) NULL,
	[LocationID] [int] NULL,
	[NetWeight] [float] NULL,
	[ProductPrice] [float] NULL,
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
	[MileBegin] [float] NULL,
	[MileEnd] [float] NULL,
 CONSTRAINT [PK_LoadInfoDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BookingNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_Order]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[ForwarderCode] [varchar](15) NULL,
	[AgentCode] [varchar](15) NULL,
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
/****** Object:  Table [dbo].[Job_OrderLog]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_PaymentDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_PaymentHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_QuotationDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_QuotationHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_QuotationItem]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_ReceiptDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_ReceiptHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_SrvGroup]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_SrvSingle]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[IsTaxCharge] [tinyint] NOT NULL,
	[Is50Tavi] [tinyint] NOT NULL,
	[Rate50Tavi] [float] NOT NULL,
	[IsCredit] [tinyint] NOT NULL,
	[IsExpense] [tinyint] NOT NULL,
	[IsShowPrice] [tinyint] NOT NULL,
	[IsHaveSlip] [tinyint] NOT NULL,
	[IsPay50TaviTo] [tinyint] NOT NULL,
	[IsLtdAdv50Tavi] [tinyint] NOT NULL,
	[IsUsedCoSlip] [int] NOT NULL,
	[GroupCode] [varchar](10) NULL,
 CONSTRAINT [pk_sicode] PRIMARY KEY CLUSTERED 
(
	[SICode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_TransportPlace]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  Table [dbo].[Job_TransportPrice]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_TransportRoute]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  Table [dbo].[job_transportroutetemp]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  Table [dbo].[Job_WHTax]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[IsCSV] [int] NOT NULL,
 CONSTRAINT [PK_JobWHTax] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_WHTaxDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_Account]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_BookAccount]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_BookAccount](
	[BranchCode] [varchar](5) NOT NULL,
	[BookCode] [varchar](15) NOT NULL,
	[BookName] [nvarchar](max) NULL,
	[BankCode] [varchar](10) NULL,
	[BankBranch] [varchar](50) NULL,
	[IsLocal] [tinyint] NOT NULL,
	[ACType] [varchar](10) NULL,
	[TAddress1] [nvarchar](max) NULL,
	[TAddress2] [nvarchar](max) NULL,
	[EAddress1] [nvarchar](max) NULL,
	[EAddress2] [nvarchar](max) NULL,
	[Phone] [varchar](30) NULL,
	[FaxNumber] [varchar](30) NULL,
	[LimitBalance] [float] NULL,
	[GLAccountCode] [varchar](10) NULL,
	[ControlBalance] [float] NULL,
 CONSTRAINT [pk_masbookacc] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mas_Branch]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_CarLicense]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_CarLicense](
	[CLid] [int] IDENTITY(1,1) NOT NULL,
	[CarNo] [varchar](12) NOT NULL,
	[CarLicense] [varchar](255) NULL,
	[EmpCode] [varchar](12) NULL,
	[DateStart] [datetime] NULL,
	[CarBrand] [varchar](12) NULL,
	[ModelYear] [varchar](4) NULL,
	[CarModel] [varchar](50) NULL,
	[CarType] [varchar](50) NULL,
	[CarPic] [text] NULL,
	[Status] [varchar](12) NULL,
	[Weight] [float] NOT NULL,
	[CarRefNo] [nvarchar](50) NULL,
	[CarRefType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mas_CarLicense] PRIMARY KEY CLUSTERED 
(
	[CarNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mas_Company]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[CustType] [tinyint] NOT NULL,
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
	[Is19bis] [tinyint] NOT NULL,
	[MgrSeq] [smallint] NOT NULL,
	[LevelNoExp] [int] NOT NULL,
	[LevelNoImp] [int] NOT NULL,
	[LnNO] [varchar](10) NULL,
	[AdjTaxCode] [varchar](10) NULL,
	[BkAuthorNo] [varchar](10) NULL,
	[BkAuthorCnn] [varchar](10) NULL,
	[LtdPsWkName] [varchar](70) NULL,
	[ConsStatus] [varchar](255) NULL,
	[CommLevel] [varchar](5) NULL,
	[DutyLimit] [float] NOT NULL,
	[CommRate] [float] NOT NULL,
	[TAddress] [nvarchar](max) NULL,
	[TDistrict] [nvarchar](max) NULL,
	[TSubProvince] [nvarchar](max) NULL,
	[TProvince] [nvarchar](255) NULL,
	[TPostCode] [nvarchar](255) NULL,
	[DMailAddress] [nvarchar](255) NULL,
	[PrivilegeOption] [varchar](1) NULL,
	[GoldCardNO] [smallint] NOT NULL,
	[CustomsBrokerSeq] [smallint] NOT NULL,
	[ISCustomerSign] [tinyint] NOT NULL,
	[ISCustomerSignInv] [tinyint] NOT NULL,
	[ISCustomerSignDec] [tinyint] NOT NULL,
	[ISCustomerSignECon] [tinyint] NOT NULL,
	[IsShippingCannotSign] [tinyint] NOT NULL,
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
/****** Object:  Table [dbo].[Mas_CompanyContact]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_Config]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  Table [dbo].[Mas_Config_Back]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_Config_Back](
	[ConfigCode] [nvarchar](50) NOT NULL,
	[ConfigKey] [nvarchar](500) NOT NULL,
	[ConfigValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mas_Config_Back2]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_Config_Back2](
	[ConfigCode] [nvarchar](50) NOT NULL,
	[ConfigKey] [nvarchar](500) NOT NULL,
	[ConfigValue] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mas_CurrencyCode]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_Employee]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mas_Employee](
	[Eid] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [varchar](12) NOT NULL,
	[PreName] [varchar](12) NULL,
	[Name] [varchar](50) NULL,
	[NickName] [varchar](12) NULL,
	[AccountNumber] [varchar](50) NULL,
	[Branch] [varchar](12) NULL,
	[Address] [text] NULL,
	[Tel] [varchar](12) NULL,
	[Remark] [text] NULL,
	[Email] [varchar](20) NULL,
 CONSTRAINT [PK_Mas_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mas_User]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_UserAuth]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_UserRole]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_UserRoleDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_UserRolePolicy]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Mas_Vender]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  View [dbo].[V_Job_WHTax]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[V_Job_WHTax]
AS
SELECT        '0' AS HItemN0, Format(CONVERT(FLOAT, dbo.Job_WHTax.BranchCode, 12), '000000') AS BranchCode, dbo.Mas_Branch.BrName, dbo.Job_WHTax.DocNo, CONVERT(DATE, dbo.Job_WHTax.DocDate, 103) AS DocDate, 
                         format(dbo.Job_WHTax.DocDate, 'yyyy', 'th-uk') AS TAX_YEAR, dbo.Job_WHTax.TaxNumber1, dbo.Job_WHTax.TName1, dbo.Job_WHTax.TAddress1, dbo.Job_WHTax.TaxNumber2, dbo.Job_WHTax.TName2, 
                         dbo.Job_WHTax.TAddress2, dbo.Job_WHTax.TaxNumber3, dbo.Job_WHTax.TName3, dbo.Job_WHTax.TAddress3, dbo.Job_WHTax.IDCard1, dbo.Job_WHTax.IDCard2, dbo.Job_WHTax.IDCard3, dbo.Job_WHTax.SeqInForm, 
                         dbo.Job_WHTax.FormType, 
                         CASE [FormType] WHEN 1 THEN 'PND1A' WHEN 2 THEN 'PND1AS' WHEN 3 THEN 'PND2' WHEN 4 THEN 'PND3' WHEN 5 THEN 'PND2A' WHEN 6 THEN 'PND3A' WHEN 7 THEN 'PND53' ELSE 'PND3' END AS TAX_TYP, 
                         dbo.Job_WHTax.TaxLawNo, ROUND(ISNULL(dbo.Job_WHTax.IncRate, 0), 2) AS IncRate, dbo.Job_WHTax.IncOther, dbo.Job_WHTax.UpdateBy, ROUND(ISNULL(dbo.Job_WHTax.TotalPayAmount, 0), 2) AS TotalPayAmount, 
                         ROUND(ISNULL(dbo.Job_WHTax.TotalPayTax, 0), 2) AS TotalPayTax, dbo.Job_WHTax.SoLicenseNo, ROUND(ISNULL(dbo.Job_WHTax.SoLicenseAmount, 0), 2) AS SoLicenseAmount, 
                         ROUND(ISNULL(dbo.Job_WHTax.SoAccAmount, 0), 2) AS SoAccAmount, dbo.Job_WHTax.PayeeAccNo, dbo.Job_WHTax.SoTaxNo, dbo.Job_WHTax.PayTaxType, dbo.Job_WHTax.PayTaxOther, dbo.Job_WHTax.CancelProve, 
                         dbo.Job_WHTax.CancelReason, CONVERT(DATE, dbo.Job_WHTax.CancelDate, 103) AS CancelDate, dbo.Job_WHTax.LastUpdate, ROUND(ISNULL(dbo.Job_WHTax.TeacherAmt, 0), 2) AS TeacherAmt, format(CONVERT(FLOAT, 
                         dbo.Job_WHTax.Branch1, 12), '000000') AS Branch1, FOrmat(CONVERT(FLOAT, dbo.Job_WHTax.Branch2, 12), '000000') AS Branch2, FOrmat(CONVERT(FLOAT, dbo.Job_WHTax.Branch3, 12), '000000') AS Branch3, 
                         CASE WHEN ([CancelReason] <> '' AND [CancelReason] IS NOT NULL) THEN '1' ELSE '0' END AS ISCancel, dbo.Job_WHTax.IsCSV
FROM            dbo.Job_WHTax INNER JOIN
                         dbo.Mas_Branch ON dbo.Job_WHTax.BranchCode = dbo.Mas_Branch.Code

GO
/****** Object:  View [dbo].[V_Job_WHTaxDetail1]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[V_Job_WHTaxDetail1]
AS
SELECT        Format(CONVERT(FLOAT, BranchCode, 12), '000000') AS BranchCode, DocNo, ItemNo, IncType, CONVERT(DATE, PayDate, 103) AS PayDate, PayRate, ROUND(ISNULL(SUM(PayAmount), 0), 2) AS PayAmount, 
                         ROUND(ISNULL(SUM(PayTax), 0), 2) AS PayTax, PayTaxDesc, '1' AS PAY_CON
FROM            dbo.Job_WHTaxDetail
WHERE        (ItemNo = '1')
GROUP BY BranchCode, DocNo, ItemNo, IncType, PayDate, PayRate, PayAmount, PayTax, PayTaxDesc

GO
/****** Object:  View [dbo].[V_Job_WHTaxDetail2]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[V_Job_WHTaxDetail2]
AS
SELECT        Format(CONVERT(FLOAT, BranchCode, 12), '000000') AS BranchCode, DocNo, ItemNo, IncType, CONVERT(DATE, PayDate, 103) AS PayDate, PayRate, ROUND(ISNULL(SUM(PayAmount), 0), 2) AS PayAmount, 
                         ROUND(ISNULL(SUM(PayTax), 0), 2) AS PayTax, PayTaxDesc, '1' AS PAY_CON
FROM            dbo.Job_WHTaxDetail
WHERE        (ItemNo = '2')
GROUP BY BranchCode, DocNo, ItemNo, IncType, PayDate, PayRate, PayAmount, PayTax, PayTaxDesc

GO
/****** Object:  View [dbo].[V_Job_WHTaxDetail3]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[V_Job_WHTaxDetail3]
AS
SELECT        Format(CONVERT(FLOAT, BranchCode, 12), '000000') AS BranchCode, DocNo, ItemNo, IncType, CONVERT(DATE, PayDate, 103) AS PayDate, PayRate, ROUND(ISNULL(SUM(PayAmount), 0), 2) AS PayAmount, 
                         ROUND(ISNULL(SUM(PayTax), 0), 2) AS PayTax, PayTaxDesc, '1' AS PAY_CON
FROM            dbo.Job_WHTaxDetail
WHERE        (ItemNo = '3')
GROUP BY BranchCode, DocNo, ItemNo, IncType, PayDate, PayRate, PayAmount, PayTax, PayTaxDesc

GO
/****** Object:  View [dbo].[V_Job_WHTaxDetail]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[V_Job_WHTaxDetail]
AS
SELECT        dbo.V_Job_WHTax.BranchCode, dbo.V_Job_WHTax.BrName, dbo.V_Job_WHTax.DocNo, dbo.V_Job_WHTax.DocDate, dbo.V_Job_WHTax.Branch1, dbo.V_Job_WHTax.IDCard1, dbo.V_Job_WHTax.TaxNumber1, 
                         dbo.V_Job_WHTax.TName1, dbo.V_Job_WHTax.TAddress1, dbo.V_Job_WHTax.Branch2, dbo.V_Job_WHTax.IDCard2, dbo.V_Job_WHTax.TaxNumber2, dbo.V_Job_WHTax.TName2, dbo.V_Job_WHTax.TAddress2, 
                         dbo.V_Job_WHTax.TAddress3, dbo.V_Job_WHTax.SeqInForm, dbo.V_Job_WHTax.FormType, 
                         CASE [FormType] WHEN 1 THEN 'PND1A' WHEN 2 THEN 'PND1AS' WHEN 3 THEN 'PND2' WHEN 4 THEN 'PND3' WHEN 5 THEN 'PND2A' WHEN 6 THEN 'PND3A' WHEN 7 THEN 'PND53' ELSE 'PND3' END AS TAX_TYP, 
                         dbo.V_Job_WHTax.TaxLawNo, dbo.V_Job_WHTax.IncRate, dbo.V_Job_WHTax.IncOther, dbo.V_Job_WHTax.TotalPayAmount, dbo.V_Job_WHTax.TotalPayTax, dbo.V_Job_WHTax.SoLicenseNo, 
                         dbo.V_Job_WHTax.SoLicenseAmount, dbo.V_Job_WHTax.SoAccAmount, dbo.V_Job_WHTax.PayeeAccNo, dbo.V_Job_WHTax.SoTaxNo, dbo.V_Job_WHTax.PayTaxType, dbo.V_Job_WHTax.PayTaxOther, 
                         dbo.V_Job_WHTax.TeacherAmt, 'D' AS DETAIL, 'SEQ' AS SEQ_NO, dbo.V_Job_WHTax.Branch3 AS BRANCH_NO, CASE dbo.V_Job_WHTax.IDCard3 WHEN NULL 
                         THEN '0000000000000' WHEN '' THEN '0000000000000' ELSE dbo.V_Job_WHTax.IDCard3 END AS PIN, CASE dbo.V_Job_WHTax.TaxNumber3 WHEN NULL 
                         THEN '0000000000' WHEN '' THEN '0000000000' ELSE dbo.V_Job_WHTax.TaxNumber3 END AS TIN, '' AS TITLE_NAME, dbo.V_Job_WHTax.TName3 AS FNAME, dbo.V_Job_WHTax.TName3 AS SNAME, 
                         dbo.V_Job_WHTaxDetail1.PayDate AS PAID_DATE1, ROUND(ISNULL(dbo.V_Job_WHTaxDetail1.PayRate, 0), 2) AS TAX_RATE1, ROUND(ISNULL(dbo.V_Job_WHTaxDetail1.PayAmount, 0), 2) AS PAID_AMT1, 
                         ROUND(ISNULL(dbo.V_Job_WHTaxDetail1.PayTax, 0), 2) AS TAX_AMT1, dbo.V_Job_WHTaxDetail1.PayTaxDesc AS INC_TYPE_PND1, dbo.V_Job_WHTaxDetail1.PAY_CON AS PAY_CON1, 
                         dbo.V_Job_WHTaxDetail2.PayDate AS PAID_DATE2, ROUND(ISNULL(dbo.V_Job_WHTaxDetail2.PayRate, 0), 2) AS TAX_RATE2, ROUND(ISNULL(dbo.V_Job_WHTaxDetail2.PayAmount, 0), 2) AS PAID_AMT2, 
                         ROUND(ISNULL(dbo.V_Job_WHTaxDetail2.PayTax, 0), 2) AS TAX_AMT2, dbo.V_Job_WHTaxDetail2.PayTaxDesc AS INC_TYPE_PND2, dbo.V_Job_WHTaxDetail2.PAY_CON AS PAY_CON2, 
                         dbo.V_Job_WHTaxDetail3.PayDate AS PAID_DATE3, ROUND(ISNULL(dbo.V_Job_WHTaxDetail3.PayRate, 0), 2) AS TAX_RATE3, ROUND(ISNULL(dbo.V_Job_WHTaxDetail3.PayAmount, 0), 2) AS PAID_AMT3, 
                         ROUND(ISNULL(dbo.V_Job_WHTaxDetail3.PayTax, 0), 2) AS TAX_AMT3, dbo.V_Job_WHTaxDetail3.PayTaxDesc AS INC_TYPE_PND3, dbo.V_Job_WHTaxDetail3.PAY_CON AS PAY_CON3, NULL AS BUILD_NAME, NULL 
                         AS ROOM_NO, NULL AS FLOOR_NO, NULL AS VILLAGE_NAME, NULL AS ADD_NO, NULL AS MOO_NO, NULL AS STREET_NAME, NULL AS TAMBON, NULL AS AMPHUR, NULL AS PROVINCE, NULL AS POSTAL_CODE, 
                         dbo.V_Job_WHTax.CancelReason, dbo.V_Job_WHTax.ISCancel, dbo.V_Job_WHTax.IsCSV
FROM            dbo.V_Job_WHTax INNER JOIN
                         dbo.V_Job_WHTaxDetail1 ON dbo.V_Job_WHTax.BranchCode = dbo.V_Job_WHTaxDetail1.BranchCode AND dbo.V_Job_WHTax.DocNo = dbo.V_Job_WHTaxDetail1.DocNo LEFT OUTER JOIN
                         dbo.V_Job_WHTaxDetail2 ON dbo.V_Job_WHTax.BranchCode = dbo.V_Job_WHTaxDetail2.BranchCode AND dbo.V_Job_WHTax.DocNo = dbo.V_Job_WHTaxDetail2.DocNo LEFT OUTER JOIN
                         dbo.V_Job_WHTaxDetail3 ON dbo.V_Job_WHTax.BranchCode = dbo.V_Job_WHTaxDetail3.BranchCode AND dbo.V_Job_WHTax.DocNo = dbo.V_Job_WHTaxDetail3.DocNo

GO
/****** Object:  View [dbo].[vMas_Company]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vMas_Company]
AS
SELECT        CustCode, MIN(Branch) AS CustBranch
FROM            dbo.Mas_Company
GROUP BY CustCode
GO
/****** Object:  View [dbo].[Mas_Company_Distinct]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Mas_Company_Distinct]
AS
SELECT        dbo.Mas_Company.*
FROM            dbo.vMas_Company INNER JOIN
                         dbo.Mas_Company ON dbo.vMas_Company.CustCode = dbo.Mas_Company.CustCode AND dbo.vMas_Company.CustBranch = dbo.Mas_Company.Branch
GO
/****** Object:  View [dbo].[V_Job_WHTaxHeader]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[V_Job_WHTaxHeader]
AS
SELECT        Format(CONVERT(FLOAT, dbo.Job_WHTax.BranchCode, 12), '000000') AS BranchCode, dbo.Mas_Branch.BrName AS DEPT_NAME, format(dbo.Job_WHTax.DocDate, 'yyyy', 'th-uk') AS TAX_YEAR, 
                         format(dbo.Job_WHTax.DocDate, 'MM', 'th-uk') AS TAX_MONTH, dbo.Job_WHTax.IDCard1, dbo.Job_WHTax.TaxNumber1, 
                         CASE [FormType] WHEN 1 THEN 'PND1A' WHEN 2 THEN 'PND1AS' WHEN 3 THEN 'PND2' WHEN 4 THEN 'PND3' WHEN 5 THEN 'PND2A' WHEN 6 THEN 'PND3A' WHEN 7 THEN 'PND53' ELSE 'PND3' END AS TAX_TYP, 
                         CASE [TaxLawNo] WHEN 1 THEN '1' ELSE '0' END AS SECTION3, CASE [TaxLawNo] WHEN 3 THEN '1' ELSE '0' END AS SECTION48, CASE [TaxLawNo] WHEN 4 THEN '1' ELSE '0' END AS SECTION50, 
                         ROUND(ISNULL(SUM(dbo.Job_WHTax.TotalPayAmount), 0), 2) AS TotalPayAmount, ROUND(ISNULL(SUM(dbo.Job_WHTax.TotalPayTax), 0), 2) AS TotalPayTax, CASE WHEN ([CancelReason] <> '' AND 
                         [CancelReason] IS NOT NULL) THEN '1' ELSE '0' END AS ISCancel, dbo.Job_WHTax.TaxLawNo, dbo.Job_WHTax.FormType, dbo.Job_WHTax.DocDate
FROM            dbo.Job_WHTax INNER JOIN
                         dbo.Mas_Branch ON dbo.Job_WHTax.BranchCode = dbo.Mas_Branch.Code
GROUP BY dbo.Job_WHTax.BranchCode, dbo.Mas_Branch.BrName, dbo.Job_WHTax.DocDate, dbo.Job_WHTax.IDCard1, dbo.Job_WHTax.TaxNumber1, dbo.Job_WHTax.FormType, dbo.Job_WHTax.TaxLawNo, 
                         dbo.Job_WHTax.CancelReason

GO
ALTER TABLE [dbo].[Job_AdvDetail] ADD  DEFAULT ((1)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[Job_AdvDetail] ADD  DEFAULT ((1)) FOR [AdvQty]
GO
ALTER TABLE [dbo].[Job_AdvDetail] ADD  DEFAULT ((1)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[Job_AdvHeader] ADD  DEFAULT ((1)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[Job_ClearExp] ADD  DEFAULT ((1)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [Is50Tavi]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [WHTRate]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [WHTAmt]
GO
ALTER TABLE [dbo].[Job_CNDNDetail] ADD  DEFAULT ((0)) FOR [BillItemNo]
GO
ALTER TABLE [dbo].[Job_LoadInfoDetail] ADD  DEFAULT ('') FOR [DeliveryNo]
GO
ALTER TABLE [dbo].[Job_LoadInfoDetail] ADD  DEFAULT ((0)) FOR [NetWeight]
GO
ALTER TABLE [dbo].[Job_LoadInfoDetail] ADD  DEFAULT ((0)) FOR [ProductPrice]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsTaxCharge]  DEFAULT ((0)) FOR [IsTaxCharge]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_Is50Tavi]  DEFAULT ((0)) FOR [Is50Tavi]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_Rate50Tavi]  DEFAULT ((0)) FOR [Rate50Tavi]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsCredit]  DEFAULT ((0)) FOR [IsCredit]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsExpense]  DEFAULT ((0)) FOR [IsExpense]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsShowPrice]  DEFAULT ((0)) FOR [IsShowPrice]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsHaveSlip]  DEFAULT ((0)) FOR [IsHaveSlip]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsPay50TaviTo]  DEFAULT ((0)) FOR [IsPay50TaviTo]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsLtdAdv50Tavi]  DEFAULT ((0)) FOR [IsLtdAdv50Tavi]
GO
ALTER TABLE [dbo].[Job_SrvSingle] ADD  CONSTRAINT [DF_Job_SrvSingle_IsUsedCoSlip]  DEFAULT ((0)) FOR [IsUsedCoSlip]
GO
ALTER TABLE [dbo].[Mas_BookAccount] ADD  CONSTRAINT [DF_Mas_BookAccount_IsLocal]  DEFAULT ((0)) FOR [IsLocal]
GO
ALTER TABLE [dbo].[Mas_BookAccount] ADD  DEFAULT ((0)) FOR [LimitBalance]
GO
ALTER TABLE [dbo].[Mas_BookAccount] ADD  DEFAULT ('') FOR [GLAccountCode]
GO
ALTER TABLE [dbo].[Mas_CarLicense] ADD  CONSTRAINT [DF_Mas_CarLicense_weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_CustType]  DEFAULT ((0)) FOR [CustType]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_Is19bis]  DEFAULT ((0)) FOR [Is19bis]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_MgrSeq]  DEFAULT ((0)) FOR [MgrSeq]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_LevelNoExp]  DEFAULT ((0)) FOR [LevelNoExp]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_LevelNoImp]  DEFAULT ((0)) FOR [LevelNoImp]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_DutyLimit]  DEFAULT ((0)) FOR [DutyLimit]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_CommRate]  DEFAULT ((0)) FOR [CommRate]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_GoldCardNO]  DEFAULT ((0)) FOR [GoldCardNO]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_CustomsBrokerSeq]  DEFAULT ((0)) FOR [CustomsBrokerSeq]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_ISCustomerSign]  DEFAULT ((0)) FOR [ISCustomerSign]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_ISCustomerSignInv]  DEFAULT ((0)) FOR [ISCustomerSignInv]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_ISCustomerSignDec]  DEFAULT ((0)) FOR [ISCustomerSignDec]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_ISCustomerSignECon]  DEFAULT ((0)) FOR [ISCustomerSignECon]
GO
ALTER TABLE [dbo].[Mas_Company] ADD  CONSTRAINT [DF_Mas_Company_IsShippingCannotSign]  DEFAULT ((0)) FOR [IsShippingCannotSign]
GO
/****** Object:  StoredProcedure [dbo].[ChangeCustomer]    Script Date: 20/06/2022 14:07:19 ******/
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
/****** Object:  StoredProcedure [dbo].[ChangeServiceCode]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[ChangeServiceCode]
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
GO
/****** Object:  StoredProcedure [dbo].[ChangeUser]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ChangeUser]
(
	@fromcode nvarchar(50),
	@tocode nvarchar(50)
)
as 
begin
update Job_AddFuel set CreateBy=@tocode where CreateBy=@fromcode
update Job_AddFuel set UpdateBy=@tocode where UpdateBy=@fromcode
update Job_AddFuel set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_AddFuel set CancelBy=@tocode where CancelBy=@fromcode
update Job_AddFuel set EmpCode=@tocode where EmpCode=@fromcode
update Job_Order set CSCode=@tocode where CSCode=@fromcode
update Job_Order set ShippingEmp=@tocode where ShippingEmp=@fromcode
update Job_Order set ManagerCode=@tocode where ManagerCode=@fromcode
update Job_Order set CloseJobBy=@tocode where CloseJobBy=@fromcode
update Job_Order set CancelProve=@tocode where CancelProve=@fromcode
update Job_BillAcceptHeader set CancelProve=@tocode where CancelProve=@fromcode
update Job_BillAcceptHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_BudgetPolicy set UpdateBy=@tocode where UpdateBy=@fromcode
update Job_PaymentHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_PaymentHeader set CancelProve=@tocode where CancelProve=@fromcode
update Job_PaymentHeader set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_PaymentHeader set PaymentBy=@tocode where PaymentBy=@fromcode
update Job_AdvHeader set AdvBy=@tocode where AdvBy=@fromcode
update Job_AdvHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_AdvHeader set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_AdvHeader set PaymentBy=@tocode where PaymentBy=@fromcode
update Job_AdvHeader set CancelProve=@tocode where CancelProve=@fromcode
update Job_CNDNHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_CNDNHeader set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_CNDNHeader set UpdateBy=@tocode where UpdateBy=@fromcode
update Job_GLHeader set UpdateBy=@tocode where UpdateBy=@fromcode
update Job_GLHeader set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_GLHeader set PostBy=@tocode where PostBy=@fromcode
update Job_GLHeader set CancelBy=@tocode where CancelBy=@fromcode
update Job_GLDetail set EntryBy=@tocode where EntryBy=@fromcode
update Job_Document set UploadBy=@tocode where UploadBy=@fromcode
update Job_Document set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_Document set CheckedBy=@tocode where CheckedBy=@fromcode
update Job_InvoiceHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_InvoiceHeader set PrintedBy=@tocode where PrintedBy=@fromcode
update Job_InvoiceHeader set CancelProve=@tocode where CancelProve=@fromcode
update Job_ClearHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_ClearHeader set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_ClearHeader set ReceiveBy=@tocode where ReceiveBy=@fromcode
update Job_ClearHeader set CancelProve=@tocode where CancelProve=@fromcode
update Job_CashControl set RecUser=@tocode where RecUser=@fromcode
update Job_CashControl set PostedBy=@tocode where PostedBy=@fromcode
update Job_CashControl set CancelProve=@tocode where CancelProve=@fromcode
update Job_QuotationHeader set ManagerCode=@tocode where ManagerCode=@fromcode
update Job_QuotationHeader set ApproveBy=@tocode where ApproveBy=@fromcode
update Job_QuotationHeader set CancelBy=@tocode where CancelBy=@fromcode
update Job_ReceiptHeader set EmpCode=@tocode where EmpCode=@fromcode
update Job_ReceiptHeader set PrintedBy=@tocode where PrintedBy=@fromcode
update Job_ReceiptHeader set ReceiveBy=@tocode where ReceiveBy=@fromcode
update Job_ReceiptHeader set CancelProve=@tocode where CancelProve=@fromcode
update Job_WHTax set UpdateBy=@tocode where UpdateBy=@fromcode
update Job_WHTax set CancelProve=@tocode where CancelProve=@fromcode
update Mas_User set UserID=@tocode where UserID=@fromcode
update Mas_UserAuth set UserID=@tocode where UserID=@fromcode
update Mas_UserRoleDetail set UserID=@tocode where UserID=@fromcode
end
GO
/****** Object:  StoredProcedure [dbo].[ChangeVender]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ChangeVender]
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
GO
/****** Object:  StoredProcedure [dbo].[SyncMasterFile]    Script Date: 20/06/2022 14:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[SyncMasterFile]
as
begin

--sync Mas_Employee
insert into job_uglobe.dbo.Mas_Employee (EmpCode,PreName,Name,NickName,Accountnumber,Branch,Address,Tel,Remark,Email)
select cd.EmpCode,cd.PreName,cd.Name,cd.NickName,cd.Accountnumber,cd.Branch,cd.Address,cd.Tel,cd.Remark,cd.Email from job_uglobe_t.dbo.Mas_Employee cd
left join job_uglobe.dbo.Mas_Employee cs
on cd.EmpCode =cs.EmpCode
where cs.EmpCode is null

insert into job_uglobe_t.dbo.Mas_Employee (EmpCode,PreName,Name,NickName,Accountnumber,Branch,Address,Tel,Remark,Email)
select cd.EmpCode,cd.PreName,cd.Name,cd.NickName,cd.Accountnumber,cd.Branch,cd.Address,cd.Tel,cd.Remark,cd.Email from job_uglobe.dbo.Mas_Employee cd
left join job_uglobe_t.dbo.Mas_Employee cs
on cd.EmpCode =cs.EmpCode
where cs.EmpCode is null

--Sync Mas_CarLicense
insert into job_uglobe.dbo.Mas_CarLicense
(CarNo,CarLicense,EmpCode,DateStart,CarBrand,ModelYear,CarModel,CarType,CarPic,Status,Weight,CarRefNo,CarRefType)
select cd.CarNo,cd.CarLicense,cd.EmpCode,cd.DateStart,cd.CarBrand,cd.ModelYear,cd.CarModel,cd.CarType,cd.CarPic,cd.Status,cd.Weight,cd.CarRefNo,cd.CarRefType
from job_uglobe_t.dbo.Mas_CarLicense cd
left join job_uglobe.dbo.Mas_CarLicense cs
on cd.CarNo=cs.CarNo
where cs.CarNo is null

insert into job_uglobe_t.dbo.Mas_CarLicense
(CarNo,CarLicense,EmpCode,DateStart,CarBrand,ModelYear,CarModel,CarType,CarPic,Status,Weight,CarRefNo,CarRefType)
select cd.CarNo,cd.CarLicense,cd.EmpCode,cd.DateStart,cd.CarBrand,cd.ModelYear,cd.CarModel,cd.CarType,cd.CarPic,cd.Status,cd.Weight,cd.CarRefNo,cd.CarRefType
from job_uglobe.dbo.Mas_CarLicense cd
left join job_uglobe_t.dbo.Mas_CarLicense cs
on cd.CarNo=cs.CarNo
where cs.CarNo is null

--Sync Mas_Company
insert into job_uglobe.dbo.Mas_Company
select cd.* from job_uglobe_t.dbo.Mas_Company cd
left join job_uglobe.dbo.Mas_Company cs
on cd.CustCode=cs.CustCode and cd.Branch=cs.Branch
where cs.CustCode is null

insert into job_uglobe_t.dbo.Mas_Company
select cd.* from job_uglobe.dbo.Mas_Company cd
left join job_uglobe_t.dbo.Mas_Company cs
on cd.CustCode=cs.CustCode and cd.Branch=cs.Branch
where cs.CustCode is null

--Sync Mas_Vender
insert into job_uglobe.dbo.Mas_Vender
select cd.* from job_uglobe_t.dbo.Mas_Vender cd
left join job_uglobe.dbo.Mas_Vender cs
on cd.VenCode=cs.VenCode 
where cs.VenCode is null

insert into job_uglobe_t.dbo.Mas_Vender
select cd.* from job_uglobe.dbo.Mas_Vender cd
left join job_uglobe_t.dbo.Mas_Vender cs
on cd.VenCode=cs.VenCode 
where cs.VenCode is null

--Sync Job_SrvGroup
insert into job_uglobe.dbo.Job_SrvGroup
select cd.* from job_uglobe_t.dbo.Job_SrvGroup cd
left join job_uglobe.dbo.Job_SrvGroup cs
on cd.GroupCode=cs.GroupCode 
where cs.GroupCode is null

insert into job_uglobe_t.dbo.Job_SrvGroup
select cd.* from job_uglobe.dbo.Job_SrvGroup cd
left join job_uglobe_t.dbo.Job_SrvGroup cs
on cd.GroupCode=cs.GroupCode 
where cs.GroupCode is null

--Sync Job_Single
insert into job_uglobe.dbo.Job_SrvSingle
select cd.* from job_uglobe_t.dbo.Job_SrvSingle cd
left join job_uglobe.dbo.Job_SrvSingle cs
on cd.SICode=cs.SICode 
where cs.SICode is null

insert into job_uglobe_t.dbo.Job_SrvSingle
select cd.* from job_uglobe.dbo.Job_SrvSingle cd
left join job_uglobe_t.dbo.Job_SrvSingle cs
on cd.SICode=cs.SICode 
where cs.SICode is null
/*
--Sync Mas_User
insert into job_uglobe.dbo.Mas_User
select cd.* from job_uglobe_t.dbo.Mas_User cd
left join job_uglobe.dbo.Mas_User cs
on cd.UserID=cs.UserID
where cs.UserID is null

insert into job_uglobe_t.dbo.Mas_User
select cd.* from job_uglobe.dbo.Mas_User cd
left join job_uglobe_t.dbo.Mas_User cs
on cd.UserID=cs.UserID
where cs.UserID is null

--Sync Mas_UserAuth
insert into job_uglobe.dbo.Mas_UserAuth
select cd.* from job_uglobe_t.dbo.Mas_UserAuth cd
left join job_uglobe.dbo.Mas_UserAuth cs
on cd.UserID=cs.UserID
and cd.AppID=cs.AppID
and cd.MenuID=cs.MenuID
where cs.UserID is null

insert into job_uglobe_t.dbo.Mas_UserAuth
select cd.* from job_uglobe.dbo.Mas_UserAuth cd
left join job_uglobe_t.dbo.Mas_UserAuth cs
on cd.UserID=cs.UserID
and cd.AppID=cs.AppID
and cd.MenuID=cs.MenuID
where cs.UserID is null
*/
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vMas_Company"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Mas_Company"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Mas_Company_Distinct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Mas_Company_Distinct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[43] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Job_WHTax"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 204
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 31
         End
         Begin Table = "Mas_Branch"
            Begin Extent = 
               Top = 6
               Left = 261
               Bottom = 201
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[5] 2[46] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "V_Job_WHTaxDetail1"
            Begin Extent = 
               Top = 94
               Left = 325
               Bottom = 224
               Right = 508
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "V_Job_WHTaxDetail2"
            Begin Extent = 
               Top = 1
               Left = 548
               Bottom = 131
               Right = 739
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "V_Job_WHTaxDetail3"
            Begin Extent = 
               Top = 5
               Left = 788
               Bottom = 135
               Right = 984
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "V_Job_WHTax"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 40
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 70
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Wid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'th = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Job_WHTaxDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Job_WHTaxDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Job_WHTaxDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxDetail3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Job_WHTax"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 211
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Mas_Branch"
            Begin Extent = 
               Top = 6
               Left = 277
               Bottom = 102
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxHeader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Job_WHTaxHeader'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Mas_Company"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMas_Company'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vMas_Company'
GO
