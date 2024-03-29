USE [apllbkk]
GO
/****** Object:  Table [dbo].[Job_AdvDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
	[Doc50Tavi] [varchar](10) NULL,
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
/****** Object:  Table [dbo].[Job_AdvHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_BillAcceptDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_BillAcceptHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_BudgetPolicy]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_CashControl]    Script Date: 7/31/2020 5:48:34 PM ******/
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
 CONSTRAINT [PK_CashControl] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[ControlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_CashControlDoc]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_CashControlSub]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_ClearDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_ClearExp]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_ClearHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
	[CTN_NO] [varchar](15) NULL,
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
/****** Object:  Table [dbo].[Job_CNDNDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_CNDNHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
	[ApproveBy] [varchar](110) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[UpdateBy] [varchar](110) NULL,
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
/****** Object:  Table [dbo].[Job_Document]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_GLDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
	[EntryBy] [varchar](15) NULL,
 CONSTRAINT [PK_GLDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[GLRefNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_GLHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_GLHeader](
	[BranchCode] [varchar](5) NOT NULL,
	[GLRefNo] [varchar](15) NOT NULL,
	[FiscalYear] [varchar](10) NOT NULL,
	[LastupDate] [datetime] NULL,
	[UpdateBy] [varchar](15) NULL,
	[GLType] [varchar](10) NULL,
	[Remark] [nvarchar](max) NULL,
	[TotalDebit] [float] NULL,
	[TotalCredit] [float] NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveBy] [varchar](15) NULL,
	[PostDate] [datetime] NULL,
	[PostBy] [varchar](15) NULL,
	[CancelDate] [datetime] NULL,
	[CancelBy] [varchar](15) NULL,
	[CancelReason] [nvarchar](max) NULL,
	[BatchDate] [datetime] NULL,
 CONSTRAINT [PK_GLHeader] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[GLRefNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_InvoiceDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_InvoiceHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_LoadInfo]    Script Date: 7/31/2020 5:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Job_LoadInfoDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_LoadInfoDetail](
	[BranchCode] [varchar](3) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[ItemNo] [smallint] NOT NULL,
	[CTN_NO] [varchar](15) NULL,
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
 CONSTRAINT [PK_LoadInfoDetail] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[BookingNo] ASC,
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_Order]    Script Date: 7/31/2020 5:48:34 PM ******/
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
	[ManagerCode] [varchar](15) NULL,
	[CSCode] [varchar](15) NULL,
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
	[CancelProve] [varchar](15) NULL,
	[CancelProveDate] [datetime] NULL,
	[CancelProveTime] [datetime] NULL,
	[CloseJobDate] [datetime] NULL,
	[CloseJobTime] [datetime] NULL,
	[CloseJobBy] [varchar](10) NULL,
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
/****** Object:  Table [dbo].[Job_OrderLog]    Script Date: 7/31/2020 5:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job_OrderLog](
	[BranchCode] [varchar](5) NOT NULL,
	[JNo] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[EmpCode] [varchar](10) NULL,
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
/****** Object:  Table [dbo].[Job_PaymentDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_PaymentHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
 CONSTRAINT [PK_PaymentH] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_QuotationDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_QuotationHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
	[ManagerCode] [varchar](10) NULL,
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
/****** Object:  Table [dbo].[Job_QuotationItem]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_ReceiptDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_ReceiptHeader]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_SrvGroup]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_SrvSingle]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_TransportPlace]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_TransportPrice]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_TransportRoute]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Job_WHTax]    Script Date: 7/31/2020 5:48:34 PM ******/
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
 CONSTRAINT [PK_JobWHTax] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job_WHTaxDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_Account]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_BookAccount]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_Branch]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_Company]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_CompanyContact]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_Config]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_CurrencyCode]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_User]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_UserAuth]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_UserRole]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_UserRoleDetail]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_UserRolePolicy]    Script Date: 7/31/2020 5:48:34 PM ******/
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
/****** Object:  Table [dbo].[Mas_Vender]    Script Date: 7/31/2020 5:48:34 PM ******/
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
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'ADV-004', N'ค่าปรับ', N'Customs Penalty', 2000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 2000)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'ADV-005', N'ค่าภาระเอเยนต์', N'ค่าภาระเอเยนต์', 6410, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 6410)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'ADV-006', N'ค่าล่วงเวลาการท่า', N'ค่าล่วงเวลาการท่า', 1000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1000)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'ADV-007', N'ค่าธรรมเนียมการท่า', N'ค่าธรรมเนียมการท่า', 8800, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 8800)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'ADV-022', N'ค่า D/O', N'ค่า D/O', 1350, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1350)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'ADV-023', N'ค่าล้างตู้', N'ค่าล้างตู้', 1200, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1200)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'CST-001', N'ต้นทุน - ค่าตรวจปล่อย', N'ต้นทุน - ค่าตรวจปล่อย', 400, N'R', N'THB', 1, 1, N'CTR', 7, 28, 6, 1.5, 422)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'SVC-002', N'ค่าบริการพิธีการ - ตู้แรก', N'ค่าบริการพิธีการ - ตู้แรก', 1700, N'R', N'THB', 1, 1, N'CTR', 7, 119, 25.5, 1.5, 1793.5)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'SVC-003', N'ค่าบริการพิธีการ - ตู้ต่อไป', N'ค่าบริการพิธีการ - ตู้ต่อไป', 800, N'R', N'THB', 1, 1, N'CTR', 7, 56, 12, 1.5, 844)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'SVT-001', N'ค่าขนส่ง', N'ค่าขนส่ง', 10600, N'R', N'THB', 1, 2, N'CTR', 7, 742, 159, 1.5, 11183)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'ES20060001', N'TRC-001', N'ต้นทุน - ค่าขนส่ง', N'ต้นทุน - ค่าขนส่ง', 10000, N'R', N'THB', 1, 2, N'CTR', 0, 0, 100, 1, 9900)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IA20060001', N'SNT-001', N'ค่าขนส่ง 4 ล้อ', N'ค่าขนส่ง 4 ล้อ', 1700, N'R', N'THB', 1, 1, N'TRK4', 7, 119, 25.5, 1.5, 1793.5)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IA20060001', N'SVC-001', N'ค่าบริการพิธีการ', N'ค่าบริการพิธีการ', 1550, N'R', N'THB', 1, 1, N'SHP', 7, 108.5, 23.25, 1.5, 1635.25)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS19110001', N'SVC-001', N'ค่าบริการพิธีการ', NULL, 4500, N'R', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS19110001', N'SVT-001', N'ค่าขนส่ง', NULL, 3000, N'R', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060002', N'SVC-001', N'ค่าบริการพิธีการ', N'ค่าบริการพิธีการ', 2000, N'R', N'THB', 1, 1, N'SHP', 7, 140, 30, 1.5, 2110)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060002', N'SVT-001', N'ค่าขนส่ง', N'Transport Charge', 8000, N'R', N'THB', 1, 1, N'SHP', 7, 560, 240, 3, 8320)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'ADV-007', N'ค่าธรรมเนียมการท่า', N'ค่าธรรมเนียมการท่า', 10, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 10)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'ADV-022', N'ค่า D/O', N'ค่า D/O', 100, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 100)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'CST-001', N'ต้นทุน - ค่าตรวจปล่อย', N'ต้นทุน - ค่าตรวจปล่อย', 20000, N'R', N'THB', 1, 20, N'SHP', 0, 0, 0, 0, 20000)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'CST-002', N'ต้นทุน - ค่าใช้จ่ายอื่นๆ', N'ต้นทุน - ค่าใช้จ่ายอื่นๆ', 800, N'R', N'THB', 1, 1, N'SHP', 7, 56, 12, 1.5, 844)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'SVC-001', N'ค่าบริการพิธีการ', N'ค่าบริการพิธีการ', 2000, N'R', N'THB', 1, 1, N'SHP', 7, 140, 30, 1.5, 2110)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'SVT-003', N'ค่าหัวลาก', N'ค่าหัวลาก', 5000, N'R', N'THB', 1, 1, N'SHP', 7, 350, 75, 1.5, 5275)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060005', N'TRC-001', N'ต้นทุน - ค่าขนส่ง', N'ต้นทุน - ค่าขนส่ง', 4000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 40, 1, 3960)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060006', N'ADV-007', N'ค่าธรรมเนียมการท่า', N'ค่าธรรมเนียมการท่า', 10, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 10)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060006', N'ADV-022', N'ค่า D/O', N'ค่า D/O', 100, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 100)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060006', N'CST-001', N'ต้นทุน - ค่าตรวจปล่อย', N'ต้นทุน - ค่าตรวจปล่อย', 1000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1000)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060006', N'SVC-001', N'ค่าบริการพิธีการ', N'ค่าบริการพิธีการ', 2000, N'R', N'THB', 1, 1, N'SHP', 7, 140, 30, 1.5, 2110)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060006', N'SVT-003', N'ค่าหัวลาก', N'ค่าหัวลาก', 5000, N'R', N'THB', 1, 1, N'SHP', 7, 350, 75, 1.5, 5275)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060006', N'TRC-001', N'ต้นทุน - ค่าขนส่ง', N'ต้นทุน - ค่าขนส่ง', 4000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 40, 1, 3960)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'ADV-004', N'ค่าปรับ', N'Customs Penalty', 2000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 2000)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'ADV-005', N'ค่าภาระเอเยนต์', N'ค่าภาระเอเยนต์', 6410, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 6410)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'ADV-006', N'ค่าล่วงเวลาการท่า', N'ค่าล่วงเวลาการท่า', 1000, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1000)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'ADV-007', N'ค่าธรรมเนียมการท่า', N'ค่าธรรมเนียมการท่า', 8800, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 8800)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'ADV-022', N'ค่า D/O', N'ค่า D/O', 1350, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1350)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'ADV-023', N'ค่าล้างตู้', N'ค่าล้างตู้', 1200, N'R', N'THB', 1, 1, N'SHP', 0, 0, 0, 0, 1200)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'CST-001', N'ต้นทุน - ค่าตรวจปล่อย', N'ต้นทุน - ค่าตรวจปล่อย', 400, N'R', N'THB', 1, 1, N'CTR', 7, 28, 6, 1.5, 422)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'SVC-002', N'ค่าบริการพิธีการ - ตู้แรก', N'ค่าบริการพิธีการ - ตู้แรก', 1700, N'R', N'THB', 1, 1, N'CTR', 7, 119, 25.5, 1.5, 1793.5)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'SVC-003', N'ค่าบริการพิธีการ - ตู้ต่อไป', N'ค่าบริการพิธีการ - ตู้ต่อไป', 800, N'R', N'THB', 1, 1, N'CTR', 7, 56, 12, 1.5, 844)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'SVT-001', N'ค่าขนส่ง', N'ค่าขนส่ง', 10600, N'R', N'THB', 1, 2, N'CTR', 7, 742, 159, 1.5, 11183)
INSERT [dbo].[Job_ClearExp] ([BranchCode], [JNo], [SICode], [SDescription], [TRemark], [AmountCharge], [Status], [CurrencyCode], [ExchangeRate], [Qty], [QtyUnit], [AmtVatRate], [AmtVat], [AmtWht], [AmtWhtRate], [AmtTotal]) VALUES (N'00', N'IS20060007', N'TRC-001', N'ต้นทุน - ค่าขนส่ง', N'ต้นทุน - ค่าขนส่ง', 10000, N'R', N'THB', 1, 2, N'CTR', 0, 0, 100, 1, 9900)
GO
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'GO19110001', 1, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:15:16.000' AS DateTime), N'เทสเทส')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'GO19110001', 2, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:15:43.000' AS DateTime), N'เทสเทสเทส')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'GO19110001', 3, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:17:18.000' AS DateTime), N'เทสเทสเทสเทส')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'GO19110001', 4, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:17:20.000' AS DateTime), N'เทสเทสเทสเทส')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'IS19110001', 1, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:13:19.000' AS DateTime), N'ทดสอบจ้า')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'IS19110001', 2, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:13:43.000' AS DateTime), N'Test Remark')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'IS19110001', 3, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:13:45.000' AS DateTime), N'Test Remark')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'IS19110002', 1, N'ADMIN', CAST(N'2562-11-11T00:00:00.000' AS DateTime), CAST(N'2562-11-11T18:40:56.000' AS DateTime), N'test')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'IT19100001', 1, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:21:21.000' AS DateTime), N'ttest')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'IT19100002', 1, N'ADMIN', CAST(N'2562-11-05T00:00:00.000' AS DateTime), CAST(N'2562-11-05T12:17:55.000' AS DateTime), N'ทดสอบ')
INSERT [dbo].[Job_OrderLog] ([BranchCode], [JNo], [ItemNo], [EmpCode], [LogDate], [LogTime], [TRemark]) VALUES (N'00', N'TE19110001', 1, N'ADMIN', CAST(N'2562-11-12T00:00:00.000' AS DateTime), CAST(N'2562-11-12T15:13:30.000' AS DateTime), N'เทส')
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'B-ADV', N'Advance Re-imbursement', N'13608830', 1, 0, 0, 0, 1, 0, 1, 0)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'B-DEP', N'Deposit Container', N'18801514', 1, 0, 0, 0, 1, 0, 1, 0)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'E-CST', N'Customs Cost', N'85333180', 1, 1, 1, 3, 0, 1, 0, 1)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'E-TRC', N'Transportation Cost - Non VAT/ W1%', N'77401405', 1, 0, 1, 1, 0, 1, 0, 0)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'E-TRN', N'Lift On-Off / Gate Fee/ Other Cost - VAT/ W3%', N'77281660', 1, 1, 1, 3, 0, 1, 0, 0)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'E-TRV', N'Transportation Cost - VAT / W3%', N'77401405', 1, 1, 1, 3, 0, 1, 0, 0)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'R-SNT', N'Service Non Vat - Transport ( 0% )', N'63101000', 1, 0, 1, 1, 0, 0, 0, 1)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'R-SVC', N'Service Vat - Customs Clearance', N'63301000', 1, 1, 1, 3, 0, 0, 0, 1)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'R-SVD', N'Service Vat - Document Fee', N'61751000', 1, 1, 1, 3, 0, 0, 0, 1)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'R-SVG', N'Service Vat - Others Revenue', N'67909110', 1, 1, 1, 3, 0, 0, 0, 1)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'R-SVP', N'Service Vat - Port charge/Storage charge  - VAT/ W3%', N'63108000', 1, 1, 1, 3, 0, 0, 0, 1)
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'R-SVT', N'Service Vat - Transport  (7%)', N'63101000', 1, 1, 1, 3, 0, 0, 0, 1)
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-001', N'ADMISSION FEE', N'ADMISSION FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-002', N'ADVANCE FILING CHAGE', N'ADVANCE FILING CHAGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-003', N'AIR WAY BILL', N'AIR WAY BILL', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-004', N'AMENDMENT FEE', N'AMENDMENT FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-005', N'B/L CORRECTION FEE', N'B/L CORRECTION FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-006', N'B/L FEE', N'B/L FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-007', N'B/L REISSUING FEE', N'B/L REISSUING FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-008', N'BANK FEE', N'BANK FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-009', N'BUNKER SURCHARGE', N'BUNKER SURCHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-010', N'CANCELLATION FEE', N'CANCELLATION FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-011', N'CARRIER CHARGE', N'CARRIER CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-012', N'CERTIFICATE ISSUE SERVICE', N'CERTIFICATE ISSUE SERVICE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-013', N'CFS', N'CFS', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-014', N'CHAMBER FEE', N'CHAMBER FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-015', N'CLEANING CHARGE', N'CLEANING CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-016', N'CONTAINER INBALANCE CHARGE', N'CONTAINER INBALANCE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-017', N'CONTINGENCY SURCHARGE', N'CONTINGENCY SURCHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-018', N'CUSTOMS DUTY', N'CUSTOMS DUTY', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-019', N'CUSTOMS FEE', N'CUSTOMS FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-020', N'CUSTOMS OVERTIME', N'CUSTOMS OVERTIME', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-021', N'CUSTOMS PENALTY', N'CUSTOMS PENALTY', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-022', N'D/O FEE', N'D/O FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-023', N'DEMURRAGE CHARGE', N'DEMURRAGE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-024', N'DETENTION CHARGE', N'DETENTION CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-025', N'DFT FEE', N'DFT FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-026', N'EMPTY REPOSITION', N'EMPTY REPOSITION', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-027', N'EQUIPMENT MAINTENANCE CHARGE', N'EQUIPMENT MAINTENANCE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-028', N'EQUIPMENT SURPLUS SURCHARGE', N'EQUIPMENT SURPLUS SURCHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-029', N'EXTRA MOVEMENT', N'EXTRA MOVEMENT', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-030', N'EXTRA RECOVERY CHARGE', N'EXTRA RECOVERY CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-031', N'FACILITIES', N'FACILITIES', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-032', N'FORWARDER AGENT', N'FORWARDER AGENT', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-033', N'FTI FEE', N'FTI FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-034', N'FUEL CHARGE', N'FUEL CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-035', N'GATE CHARGE', N'GATE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-036', N'IMBALANCE SURCHARGE', N'IMBALANCE SURCHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-037', N'LATE PICK UP', N'LATE PICK UP', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-038', N'LEGALIZE FEE', N'LEGALIZE FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-039', N'LIFF OFF', N'LIFF OFF', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-040', N'LIFF ON', N'LIFF ON', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-041', N'LIFF ON/ OFF GATE CHARGE', N'LIFF ON/ OFF GATE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-042', N'LOW SULPHUR FUEL SURCHARGE', N'LOW SULPHUR FUEL SURCHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-043', N'OCEAN FREIGHT', N'OCEAN FREIGHT', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-044', N'PORT CHARGES', N'PORT CHARGES', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-045', N'PORT CONGESTION SURCHARGE', N'PORT CONGESTION SURCHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-046', N'PORT OVERTIME', N'PORT OVERTIME', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-047', N'RELOCATION', N'RELOCATION', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-048', N'REPAIR / DAMAGE CHARGE', N'REPAIR / DAMAGE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-049', N'SEAL CHARGE', N'SEAL CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-050', N'SECURITY CHARGE', N'SECURITY CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-051', N'STATAUS CHARGE', N'STATAUS CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-052', N'STORAGE CHARGE', N'STORAGE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-053', N'UNSTUFFING CHARGE', N'UNSTUFFING CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-054', N'SURRENDER FEE', N'SURRENDER FEE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-055', N'THC', N'THC', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-056', N'VGM', N'VGM', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-ADV-057', N'WEIGHT CHARGE', N'WEIGHT CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'13608830', N'13608830', 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'B-ADV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'B-DEP-001', N'CONTAINER DEPOSIT', N'CONTAINER DEPOSIT', 0, N'CNTR', N'THB', NULL, NULL, NULL, N'18801514', 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, N'B-DEP')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-CST-001', N'CO/FTA FEE', N'CO/FTA FEE', 0, N'SET', N'THB', NULL, NULL, NULL, N'85333180', 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-CST')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-CST-002', N'CUSTOMS CLEARANCE', N'CUSTOMS CLEARANCE', 0, N'SHP', N'THB', NULL, NULL, NULL, N'85333180', 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-CST')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-CST-003', N'CUSTOMS CLEARANCE - FIRST CONTAINER', N'CUSTOMS CLEARANCE - FIRST CONTAINER', 0, N'CNTR', N'THB', NULL, NULL, NULL, N'85333180', 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-CST')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-CST-004', N'CUSTOMS CLEARNACE - NEXT CONTAINER', N'CUSTOMS CLEARNACE - NEXT CONTAINER', 0, N'CNTR', N'THB', NULL, NULL, NULL, N'85333180', 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-CST')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-CST-005', N'LABOUR CHARGE', N'LABOUR CHARGE', 0, N'SHP', N'THB', NULL, NULL, NULL, N'85333180', 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-CST')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-CST-006', N'OTHER CHARGES', N'OTHER CHARGES', 0, N'SHP', N'THB', NULL, NULL, NULL, N'85333180', 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-CST')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRC-001', N'TRANSPORT CHARGE', N'TRANSPORT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'77401405', NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, N'E-TRC')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-001', N'ADMISSION FEE', N'ADMISSION FEE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-002', N'GATE CHARGE', N'GATE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-003', N'INSPECTION CHARGE', N'INSPECTION CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-004', N'LABOUR CHARGE', N'LABOUR CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-005', N'LIFT ON/LIFT OFF CHARGE', N'LIFT ON/LIFT OFF CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-006', N'PORT CHARGE', N'PORT CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-007', N'STORAGE CHARGE', N'STORAGE CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRN-008', N'WEIGHT CHARGE', N'WEIGHT CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77281660', NULL, 1, 1, 3, 0, 1, 0, 0, 1, 0, 0, N'E-TRN')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'E-TRV-001', N'TRANSPORTATION CHARGE', N'TRANSPORTATION CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'77401405', NULL, 1, 1, 3, 0, 1, 0, 0, 0, 0, 0, N'E-TRV')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-001', N'TRANSPORT CHARGE', N'TRANSPORT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-002', N'TRANSPORT CHARGE - NEXT DAY RETURN ', N'TRANSPORT CHARGE - NEXT DAY RETURN', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-003', N'TRANSPORT CHARGE - ROUND TRIP', N'TRANSPORT CHARGE - ROUND TRIP', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-004', N'TRANSPORT CHARGE - OVERNIGHT CHARGE', N'TRANSPORT CHARGE - OVERNIGHT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-005', N'TRANSPORT CHARGE - OVERWAITING CHARGE', N'TRANSPORT CHARGE - OVERWAITING CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-006', N'TRANSPORT CHARGE - DROP CHARGE', N'TRANSPORT CHARGE - DROP CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-007', N'TRANSPORT CHARGE - CHASSIS CHARGE', N'TRANSPORT CHARGE - CHASSIS CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-008', N'TRANSPORT CHARGE - REQUIRE CONTAINER NO. BEFORE LOADING DATE', N'TRANSPORT CHARGE - REQUIRE CONTAINER NO. BEFORE LOADING DATE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-009', N'TRANSPORT CHARGE - RETURN CONTAINER AT LAEM CHABANG PORT', N'TRANSPORT CHARGE - RETURN CONTAINER AT LAEM CHABANG PORT', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SNT-010', N'TRANSPORT CHARGE - RETURN CONTAINER AT OTHER PORT', N'TRANSPORT CHARGE - RETURN CONTAINER AT OTHER PORT', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVC-001', N'CUSTOMS CLEARANCE', N'CUSTOMS CLEARANCE', 0, N'SHP', N'THB', NULL, NULL, N'63301000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVC')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVC-002', N'CUSTOMS CLEARANCE - FIRST CONTAINER', N'CUSTOMS CLEARANCE - FIRST CONTAINER', 0, N'SHP', N'THB', NULL, NULL, N'63301000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVC')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVC-003', N'CUSTOMS CLEARNACE - NEXT CONTAINER', N'CUSTOMS CLEARNACE - NEXT CONTAINER', 0, N'SHP', N'THB', NULL, NULL, N'63301000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVC')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVC-004', N'NEXT PAGES', N'NEXT PAGES', 0, N'SHP', N'THB', NULL, NULL, N'63301000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVC')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVD-001', N'ATTORNEY SIGNATURE FEE', N'ATTORNEY SIGNATURE FEE', 0, N'SHP', N'THB', NULL, NULL, N'61751000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVD')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVD-002', N'CO/FTA FEE', N'CO/FTA FEE', 0, N'SHP', N'THB', NULL, NULL, N'61751000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVD')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVD-003', N'DOCUMENT FEE', N'DOCUMENT FEE', 0, N'SHP', N'THB', NULL, NULL, N'61751000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVD')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-001', N'BOI SUBMISSION', N'BOI SUBMISSION', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-002', N'CUSTOMS OVERTIME', N'CUSTOMS OVERTIME', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-003', N'EXTRA CHARGE', N'EXTRA CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-004', N'FUMIGATION CHARGE', N'FUMIGATION CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-005', N'HANDLING CHARGE', N'HANDLING CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-006', N'LABOUR CHARGE', N'LABOUR CHARGE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-007', N'NEW SUBMISSION', N'NEW SUBMISSION', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-008', N'OTHER SERVICE', N'OTHER SERVICE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-009', N'REGISTRATION FEE', N'REGISTRATION FEE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-010', N'SERVICE FEE', N'SERVICE FEE', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVG-011', N'TISI SUBMISSION', N'TISI SUBMISSION', 0, N'SHP', N'THB', NULL, NULL, N'67909110', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVG')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-001', N'ADMISSION FEE', N'ADMISSION FEE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-002', N'EIR STORAGE YARD CHARGE', N'EIR STORAGE YARD CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-003', N'GATE CHARGE', N'GATE CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-004', N'INSPECTION CHARGE', N'INSPECTION CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-005', N'LIFT ON/LIFT OFF CHARGE', N'LIFT ON/LIFT OFF CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-006', N'OT-TOPPICK', N'OT-TOPPICK', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-007', N'PORT CHARGE', N'PORT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-008', N'STORAGE CHARGE', N'STORAGE CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVP-009', N'WEIGHT CHARGE', N'WEIGHT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63108000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SNT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-001', N'TRANSPORT CHARGE', N'TRANSPORT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-002', N'TRANSPORT CHARGE - NEXT DAY RETURN ', N'TRANSPORT CHARGE - NEXT DAY RETURN', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-003', N'TRANSPORT CHARGE - ROUND TRIP', N'TRANSPORT CHARGE - ROUND TRIP', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-004', N'TRANSPORT CHARGE - OVERNIGHT CHARGE', N'TRANSPORT CHARGE - OVERNIGHT CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-005', N'TRANSPORT CHARGE - OVERWAITING CHARGE', N'TRANSPORT CHARGE - OVERWAITING CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-006', N'TRANSPORT CHARGE - DROP CHARGE', N'TRANSPORT CHARGE - DROP CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-007', N'TRANSPORT CHARGE - CHASSIS CHARGE', N'TRANSPORT CHARGE - CHASSIS CHARGE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-008', N'TRANSPORT CHARGE - REQUIRE CONTAINER NO. BEFORE LOADING DATE', N'TRANSPORT CHARGE - REQUIRE CONTAINER NO. BEFORE LOADING DATE', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-009', N'TRANSPORT CHARGE - RETURN CONTAINER AT LAEM CHABANG PORT', N'TRANSPORT CHARGE - RETURN CONTAINER AT LAEM CHABANG PORT', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'R-SVT-010', N'TRANSPORT CHARGE - RETURN CONTAINER AT OTHER PORT', N'TRANSPORT CHARGE - RETURN CONTAINER AT OTHER PORT', 0, N'CNTR', N'THB', NULL, NULL, N'63101000', NULL, 1, 1, 3, 0, 0, 0, 0, 0, 1, 0, N'R-SVT')
GO
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'AWP ', N'AWP LOGISTICS 6/1 ม.10 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'B.C.DEPOT CO.,LTD.(BC-1 PAT) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Bangkok Barge Terminal (BBT) ', N'8/08 Moo.8 Poochaosamingprai Road, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Bangplee LCB', N'Nongkam ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'BC (ข้างกรมศุล) ', N'คลองเตย ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'BC2 บางนา กม.18 ', N'Bangna KM. 18 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'BCSC ', N'109/9 หมู่ 6, ซอยวัดศรีวารีน้อย ถนนบางนา-ตราด กม.18 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'BDS ', N'พระประแดง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'BMT Pacific/ BMTP ', N'พระสมุทรเจดีย์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'BSA (บางนา-ตราด กม.13) ', N'ถ.บางนา-ตราด กม.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'CDS#2 ', N'บางนา กม. 6.5 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'CMA CGM DEPOT BKK ', N'54/9 MOO.9 BANG CHALONG, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'CONCENTER 3 (กล้วยน้ำไท) ', N'ถ.อาจณรงค์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'CONCENTER 4  ', N'ถ. บางนา-ตราด กม.4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'CONTPOOL ', N'20/4 ซอยวัดคลองปลัดเปรียง บางนา-ตราด กม.6 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Cosiam 1 ', N'ถ.บางนา-ตราด กม.2 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Cosiam 2 ', N'ถ. บางนาตราด กม. 3.5 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Cosiam 3 ', N'84/9 ม.3 ถ.บางนาตราด กม.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Cosiam 5 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Cosiam9 ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'D-DEPOT (Bangna KM.13) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'D-DEPOT ', N'Laemchabang ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ECD Laemchabang ', N'Laemchabang ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'FALCON LCB (FCD&W) ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'G - Fortune ', N'ถ.บางนา-ตราด กม.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'GLOBAL THAI DEPOT (LKB) ', N'GLOBAL THAI DEPOT (LKB) CTC ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'GOODYEAR ', N'50/9 หมู่ที่ 3 ถ.พหลโยธิน กม.36 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'GREATAINER YARD ', N'Razan Road ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'GREATING FORTUNE BKK DEPOT 2 ', N'GREATING FORTUNE BKK DEPOT 2 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'GREATING FORTUNE LCB  ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'HUTCHISON LAEMCHABANG(C1C2) ', N'Hutchison Laemchabang Terminal,Ltd.(C1&C2) ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'IKEA (BANGNA)', N'IKEA STORE 38 หมู่ 6 ถ.บางนา-ตราด ก.ม.8  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'JWD-LCB ', N'JWD (DG Warehouse) ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'K.R.C.TRANSPORT AND SERVICE ', N'96 Moo 5, Tung Sukkhla, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'KBCY ', N'บางนา กม. 3.5 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'KCD', N'KCD (THAILAND) Limited 113/1 Moo 1 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'KERRY SIAM SEAPORT', N'แยกอ่าวอุดม - ใกล้ไทยออยล์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'KSP DEPOT CO.,LTD. ', N'311/76 Moo7, Tumbol ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Laem Chabang - Terminal 5 ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'LAEMCHABANG INTER DEPOT AND TR ', N'687/5 MOO1, T.NONGKHAM, A.SRIRACHA, CHONBURI ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'LARN 127 ', N'Bangna K.M. 4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'LCD', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'LCIT#5 (LCB B.5) ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'LF W/H ', N'Ladkrabang ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'M.P.J.Distribution LCB ', N'(Opposite siam depot LCB) ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'MCCT ', N'96 Moo 11, Tumbon Nongkham,  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Modern Depot and Transport ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'MON LOGISTICS SERVICES ', N'196 Moo1, Nongkam, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'MRCD Container  ', N'277/37 Moo 12, Tambol Thung Sukla ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'MRCD ', N'277/37 หมู่ 12 ต. ทุ่งสุขคา ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'MSC DEPOT LCB ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'N&DD ', N'31/3 M.1 Bangna-Trad Rd., Km 12.5 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'NHP', N'109 หมู่ 6 ถ.คู่ขนาดทางหลวงพิเศษ กทม - ชลบุรี ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'PB (แหลมฉบัง) ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'PCD TERMINAL ', N'ถ.บางนาตราด กม.4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'PH DEPOT LCB ', N'LCB ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'RCL ', N'เทพารักษ์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'RS CONTAINER ', N'ถ.บางนาตราด ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SAHATHAI', N'51/1 หมู่ 3 ถ.ปู่เจ้าสมิงพราย  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SAKAMI WAREHOUSE', N'Sakami ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SCG ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SCS 1', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SCS 2 ', N'233/11 หมู่ 6 ต. ทุ่งสุขขา ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SCT (Siam Container Terminal) ', N'102 กม 25 หมู่ 2 ถนนเทพารักษ์  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SIAM COMMERCIAL SEAPORT', N'ต.ทุ่งสุขลา ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SIAM DEPOT', N'ถ.กิ่งแก้ว ต.ราชาเทวะ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SIAM SHORSIDE SERVICE (LKB) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SITC ', N'LCB ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SMART LOGISTIC YARD', N'Bangpleeyai. ,Bangplee ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SR LKB ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SSW TERMINAL  ', N'88/1 หมู่ 4 ถนนสุขสวัสดิ์ ตำบลบางจาก อำเภอพระประแดง  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'STAR PACIFIC ', N'60/3 Moo 13, Bangplee-Yai, Bangplee ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'SUVARNABHUMI AIRPORT', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'TANARUNG', N'ถ.บางนา-ตราด กม.6  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Thai connectivity ', N'98 Moo 3 Poochaosamingprai Rd Samrongklang, อำเภอพระประแดง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'THAI ENGKONG', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'THAI INTERDEPOT & TRANSPORT', N'Bangna K.M.18  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'THAI LCB TERMINAL', N'88 Moo3 Tungsukhla,  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'TID', N'Bangna km.18 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'TIPS CD ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'TPT', N'ท่าปูน ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'TRIPLE I CONTAINER DEPOT  ', N'(TCD DEPOT)  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'TSTL ท่าน้ำตาล ', N'ถนนปู่เจ้าสมิงพราย ติดแม่น้ำเจ้าพระยา ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'UNICON ', N'ถ.กิ่งแก้ว ต.ราชาเทวะ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'UNITHAI', N'ท้ายบ้าน ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'Universal (Tennis)', N'ถ.เพชรเกษม ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'USAVE ', N'31/3-5 ถ.บางนา-ตราด กม.12.5  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'WINWIN - LCB', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'WINWIN - LKB', N'ลาดกระบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'YJC  ', N'Bangna KM.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'YJC LCB', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาดกระบัง ประตู 1 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาดกระบัง ประตู 2 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาดกระบัง ประตู 3 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาดกระบัง ประตู 4 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาดกระบัง ประตู 5 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาดกระบัง ประตู 6 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ลาน นวเชต ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'ศรีไทย บางนาตราด กม. 8 ', N'บางนาตราด กม. 8 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'สตาร์แปซิฟิก (บางนา ตราด กม.9) ', N'ถ. บางนา-ตราด กม.9 ', NULL)
GO
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'สินธนโชติ ', N'ซอยลาซาล ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า A.2 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า A0 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า B.1 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า B.2', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า B.3 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า B.5', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (1, N'แหลมฉบัง ท่า C.3', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'APLL W/H BANGNA KM.18 (WHA) ', N'11/5 ต.บางโฉลง  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'APLL W/H BANGNA KM.18/3', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'APLL โกดังร่มเกล้า ', N'136 Moo 4 Kong-Samva, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Aroon ', N'ถ.บางนาตราด กม.4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'AWP ', N'AWP LOGISTICS 6/1 ม.10 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Best Bonded W/H Bang-Pa-In ', N'14/2-9 หมู่ 8, เชียงรากน้อย บางปะอิน ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Best Bonded W/H KINGKAEW', N'3/2 ถนน กิ่งแก้ว ต.ราชาเทวะ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'EASTBORAD (วัฒนานคร)', N'170 MOO 4,WATTANANAKORN-KLONGHAD RD', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'GOODYEAR ', N'50/9 หมู่ที่ 3 ถ.พหลโยธิน กม.36 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'GREATING FORTUNE BKK DEPOT 2 ', N'GREATING FORTUNE BKK DEPOT 2 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'IKEA (BANGNA)', N'IKEA STORE 38 หมู่ 6 ถ.บางนา-ตราด ก.ม.8  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'IKEA (BANGYAI)', N'BANGYAI', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KAWASUM (SIS)', NULL, NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KAWASUMI (KORAT) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KAWASUMI (NAVANAKORN) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KAWASUMI (SIS AMATA)  ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KAWASUMI (SYNERGY HEALTH) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KERRY W/H  (BANGNA KM.23)', N'BANGNA KM.23', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'KSP DEPOT CO.,LTD. ', N'311/76 Moo7, Tumbol ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'LAEMCHABANG INTER DEPOT AND TR ', N'687/5 MOO1, T.NONGKHAM, A.SRIRACHA, CHONBURI ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'LF W/H ', N'Ladkrabang ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Masterich (บางปูใหม่ กม. 39.5) ', N'บางปูใหม่ กม. 39.5 ข้างวัดดำหรุ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Merry Coperation Co.,Ltd ', N'39 หมู่ 4 ซอย เพชรเกษม 69 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'NAVANAKORN', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'NHP', N'109 หมู่ 6 ถ.คู่ขนาดทางหลวงพิเศษ กทม - ชลบุรี ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'P.A.O ', N'ถ.บางนา-ตราด กม.35 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'P.H. Garment Manufacturing ', N'217/1-7 Moo 5 , Suwannasorn RD., ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'PRESIDENT AUTO', N'PRESIDENT AUTO, SAMUTSAKRON', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'ROYAL FINISHING (BANBUNG)', N'999 Moo.10 T. Nongirun, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'SAKAMI WAREHOUSE', N'Sakami ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'SIAM SHORSIDE SERVICE (LKB) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'SIAMWALLA W/H', N'KINGKAEW', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'SSW TERMINAL  ', N'88/1 หมู่ 4 ถนนสุขสวัสดิ์ ตำบลบางจาก อำเภอพระประแดง  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'SUVARNABHUMI AIRPORT', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'THAI LCB TERMINAL', N'88 Moo3 Tungsukhla,  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'TOSHIBA (CB TACT)', N'BANGSAOTHONG', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'TOSHIBA (GOLDENSEA)', N'Rayong ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'TOSHIBA (NISSHINBO)', N'BANGSAOTHONG', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'TOSHIBA (S.K.)', N'BANGPLEE (BANGPLA)', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'TOSHIBA (TLGT)', N'144/1 Moo 5, Bangkadi Industrial Park ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'TOSHIBA (VIRIYA)', N'บางกระเจ้า', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Universal (Football)', N'ถ.เพชรเกษม ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'Universal (Tennis)', N'ถ.เพชรเกษม ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'URC  ', N'1/123 นิคมอุตสาหกรรม สมุทรสาคร ซอย 4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'WINWIN - LKB', N'ลาดกระบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'เบสท์บอนด์ บางปะอิน ', N'14/2-9 ม.8 ต. เชียงรากน้อย ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'เบสบอนด์ กิ่งแก้ว ', N'ถ.กิ่งแก้ว  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'รีกัลเทรดเดอร์ ', N'99/915 ซ. ไร่ขิง 30 ถ.ท่าพูด-พุทธมณฑลสาย 5 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'ลาดกระบัง ประตู 1 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (2, N'ลาดกระบัง ประตู 4 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'A-One Internetional Depot ', N'6 ม.10 ต.ทุ่งสุขลา อ.ศรีราชา ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'Aroon ', N'ถ.บางนาตราด กม.4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'AWP ', N'AWP LOGISTICS 6/1 ม.10 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'B.C.DEPOT CO.,LTD.(BC-1 PAT) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'Bangkok Barge Terminal (BBT) ', N'8/08 Moo.8 Poochaosamingprai Road, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'BCSC ', N'109/9 หมู่ 6, ซอยวัดศรีวารีน้อย ถนนบางนา-ตราด กม.18 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'BDS ', N'พระประแดง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'BMT Pacific/ BMTP ', N'พระสมุทรเจดีย์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'BSA (บางนา-ตราด กม.13) ', N'ถ.บางนา-ตราด กม.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'CIMC LOGISTICS ', N'184 LEABKLONGMORN ROAD ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'CMA CGM DEPOT BKK ', N'54/9 MOO.9 BANG CHALONG, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'CONCENTER 4  ', N'ถ. บางนา-ตราด กม.4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'CONTPOOL ', N'20/4 ซอยวัดคลองปลัดเปรียง บางนา-ตราด กม.6 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'Cosiam 3 ', N'84/9 ม.3 ถ.บางนาตราด กม.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'D-DEPOT (Bangna KM.13) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ECD Laemchabang ', N'Laemchabang ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'GLOBAL THAI DEPOT (LKB) ', N'GLOBAL THAI DEPOT (LKB) CTC ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'GOODYEAR ', N'50/9 หมู่ที่ 3 ถ.พหลโยธิน กม.36 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'GREATING FORTUNE BKK DEPOT 2 ', N'GREATING FORTUNE BKK DEPOT 2 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'GREATING FORTUNE LCB  ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'HUTCHISON LAEMCHABANG(C1C2) ', N'Hutchison Laemchabang Terminal,Ltd.(C1&C2) ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'IKEA (BANGNA)', N'IKEA STORE 38 หมู่ 6 ถ.บางนา-ตราด ก.ม.8  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'JWD-LCB ', N'JWD (DG Warehouse) ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'K.R.C.TRANSPORT AND SERVICE ', N'96 Moo 5, Tung Sukkhla, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'KBCY ', N'บางนา กม. 3.5 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'KCD', N'KCD (THAILAND) Limited 113/1 Moo 1 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'KERRY SIAM SEAPORT', N'แยกอ่าวอุดม - ใกล้ไทยออยล์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'KSP DEPOT CO.,LTD. ', N'311/76 Moo7, Tumbol ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'LAD KRABANG', NULL, NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'Laem Chabang - Terminal 5 ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'LAEMCHABANG INTER DEPOT AND TR ', N'687/5 MOO1, T.NONGKHAM, A.SRIRACHA, CHONBURI ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'LCB', NULL, NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'LCD', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'LCIT#5 (LCB B.5) ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'LF W/H ', N'Ladkrabang ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'M.P.J.Distribution LCB ', N'(Opposite siam depot LCB) ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'MCCT ', N'96 Moo 11, Tumbon Nongkham,  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'MON LOGISTICS SERVICES ', N'196 Moo1, Nongkam, ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'MRCD Container  ', N'277/37 Moo 12, Tambol Thung Sukla ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'NHP', N'109 หมู่ 6 ถ.คู่ขนาดทางหลวงพิเศษ กทม - ชลบุรี ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'RCL ', N'เทพารักษ์ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SAHATHAI', N'51/1 หมู่ 3 ถ.ปู่เจ้าสมิงพราย  ', NULL)
GO
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SAKAMI WAREHOUSE', N'Sakami ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SCG ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SCS 1', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SCT (Siam Container Terminal) ', N'102 กม 25 หมู่ 2 ถนนเทพารักษ์  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SIAM DEPOT', N'ถ.กิ่งแก้ว ต.ราชาเทวะ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SIAM SHORSIDE SERVICE (LKB) ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SR LKB ', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SSW TERMINAL  ', N'88/1 หมู่ 4 ถนนสุขสวัสดิ์ ตำบลบางจาก อำเภอพระประแดง  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'SUVARNABHUMI AIRPORT', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'TANARUNG', N'ถ.บางนา-ตราด กม.6  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'Thai connectivity ', N'98 Moo 3 Poochaosamingprai Rd Samrongklang, อำเภอพระประแดง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'THAI ENGKONG', N'', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'THAI LCB TERMINAL', N'88 Moo3 Tungsukhla,  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'TIPS CD ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'TPT', N'ท่าปูน ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'TRIPLE I CONTAINER DEPOT  ', N'(TCD DEPOT)  ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'TSTL ท่าน้ำตาล ', N'ถนนปู่เจ้าสมิงพราย ติดแม่น้ำเจ้าพระยา ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'UNICON ', N'ถ.กิ่งแก้ว ต.ราชาเทวะ ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'UNITHAI', N'ท้ายบ้าน ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'WINWIN - LCB', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'WINWIN - LKB', N'ลาดกระบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'YJC  ', N'Bangna KM.13 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ท่าเรือคลองเตย ', N'คลองเตย พระราม 4 ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ลาดกระบัง ประตู 1 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ลาดกระบัง ประตู 2 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ลาดกระบัง ประตู 3 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ลาดกระบัง ประตู 4 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ลาดกระบัง ประตู 5 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'ลาดกระบัง ประตู 6 ', N'ถ.เจ้าคุณทหาร ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'สินธนโชติ ', N'ซอยลาซาล ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า A.2 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า A0 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า A3 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า B.1 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า B.2', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า B.3 ', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า B.5', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (3, N'แหลมฉบัง ท่า C.3', N'แหลมฉบัง ', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'10W', N'10 WHEELS TRUCK', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'4W', N'4 WHEELS TRUCK', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'6W', N'6 WHEELS TRUCK', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'D20', N'FCL D20', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'D40', N'FCL D40', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'D40''H', N'FCL 40H', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'D45', N'FCL 45', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'FB', N'FLAT-BED', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'FR', N'FLAT-RACK', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'LCL', N'LCL', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'OT40', N'OPENTOP-40''', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'RF20', N'REEFER 20', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'RF40', N'REEFER 40', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'RF45', N'REEFER45', NULL)
INSERT [dbo].[Job_TransportPlace] ([PlaceType], [PlaceName], [PlaceAddress], [PlaceContact]) VALUES (4, N'TRAILER', N'TRAILER', NULL)
GO
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 36, N'RBI', N'KAWAS', N'R-SVT-001', 4200, 4500, N'TRANSPORT CHARGE', N'D40->LCB->KAWASUM (SIS)->LCB', N'E-TRC-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 37, N'NDD', N'GYTH', N'E-TRC-001', 4800, 5066, N'TRANSPORT CHARGE', N'LKB->BBW(DHL) WH->PAT', N'R-SVT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 38, N'USAVE', N'IKANO', N'E-TRC-001', 5200, 5500, N'TRANSPORT CHARGE', N'LAD KRABANG->LAEM CHABANG->IKEA (BANGNA)', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 39, N'NDD', N'GYTH', N'R-SVT-001', 5500, 5887, N'TRANSPORT CHARGE', N'LKB->GOODYEAR->TSTL', N'E-TRC-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 40, N'NDD', N'BATA', N'R-SVT-001', 6250, 4100, N'TRANSPORT CHARGE', N'LKB->LKB->BATA', N'E-TRC-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 42, N'NDD', N'GYTH', N'R-SVT-001', 8000, 8299, N'TRANSPORT CHARGE', N'LCB->BBW(DHL) WH->LCB', N'E-TRC-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 43, N'RBI', N'TOSHIBA', N'R-SVT-001', 5472, 5726, N'TRANSPORT CHARGE', N'D40->LKB->TOSHIBA (VIRIYA)->LKB', N'R-SVT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 45, N'NDD', N'REVED', N'E-TRC-001', 4100, 6000, N'TRANSPORT CHARGE', N'20''->LKB->LKB->Rev Editon WH.19', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 46, N'RBI', N'KAWAS', N'E-TRC-001', 5200, 5500, N'TRANSPORT CHARGE', N'D20->LKB->KAWASUMI (NAVA-3B)->LKB', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 47, N'USAVE', N'IKANO', N'E-TRC-001', 5200, 5500, N'TRANSPORT CHARGE', N'LAEM CHABANG->IKEA (BANGNA)->LAD KRABANG', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 48, N'TSL', N'PRESID', N'E-TRC-001', 7500, 9500, N'TRANSPORT CHARGE', N'LCB->PACO->LCB', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 49, N'NDD', N'REVED', N'E-TRC-001', 4100, 6000, N'TRANSPORT CHARGE', N'40''HC->LKB->REV EDITON KM.19->LKB', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 50, N'NDD', N'IKANO', N'E-TRC-001', 8200, 9500, N'TRANSPORT CHARGE', N'LAEM CHABANG->IKEA (BANGYAI)->LAD KRABANG', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 51, N'NDD', N'BATA', N'E-TRC-001', 4100, 6250, N'TRANSPORT CHARGE', N'40''D->LKB->BATA WHA KM.18->LKB', N'R-SNT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 52, N'RBI', N'TOSHIBA', N'E-TRC-001', 3936, 4658, N'TRANSPORT CHARGE', N'D40->LKB->TOSHIBA (NISSHINBO) 19.01-22.00->LKB', N'R-SVT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 53, N'RBI', N'TOSHIBA', N'E-TRC-001', 3936, 4658, N'TRANSPORT CHARGE', N'D40->LKB->TOSHIBA (SK) 19.01-22.00->LKB', N'R-SVT-001')
INSERT [dbo].[Job_TransportPrice] ([BranchCode], [LocationID], [VenderCode], [CustCode], [SICode], [CostAmount], [ChargeAmount], [SDescription], [Location], [ChargeCode]) VALUES (N'00', 54, N'RBI', N'TOSHIBA', N'E-TRC-001', 4320, 4658, N'TRANSPORT CHARGE', N'D40->LKB->TOSHIBA (CB TACT) 19.01-22.00->LKB', N'R-SVT-001')
GO
SET IDENTITY_INSERT [dbo].[Job_TransportRoute] ON 

INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (36, N'D40', N'LCB', N'KAWASUM (SIS)', N'LCB', N'D40->LCB->KAWASUM (SIS)->LCB', 1, N'FCL D40', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (37, N'', N'LKB', N'BBW(DHL) WH', N'PAT', N'LKB->BBW(DHL) WH->PAT', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (38, N'', N'LAD KRABANG', N'LAEM CHABANG', N'IKEA (BANGNA)', N'LAD KRABANG->LAEM CHABANG->IKEA (BANGNA)', 0, N'', N'', N'', N'', N'', N'', N'IKEA STORE 38 หมู่ 6 ถ.บางนา-ตราด ก.ม.8  ', N'', N'4312')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (39, N'', N'LKB', N'GOODYEAR', N'TSTL', N'LKB->GOODYEAR->TSTL', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (40, N'', N'LKB', N'LKB', N'BATA', N'LKB->LKB->BATA', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'4312')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (41, N'', N'LCB', N'GOODYEAR', N'LCB', N'LCB->GOODYEAR->LCB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (42, N'', N'LCB', N'BBW(DHL) WH', N'LCB', N'LCB->BBW(DHL) WH->LCB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (43, N'D40', N'LKB', N'TOSHIBA (VIRIYA)', N'LKB', N'D40->LKB->TOSHIBA (VIRIYA)->LKB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (44, N'20''', N'LKB', N'LKB', N'REV EDIOTN WH.KM.19', N'20''->LKB->LKB->REV EDIOTN WH.KM.19', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'4312')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (45, N'20''', N'LKB', N'LKB', N'Rev Editon WH.19', N'20''->LKB->LKB->Rev Editon WH.19', 0, N'', N'', N'', N'', N'', N'', N'', N'', N'4312')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (46, N'D20', N'LKB', N'KAWASUMI (NAVA-3B)', N'LKB', N'D20->LKB->KAWASUMI (NAVA-3B)->LKB', 1, N'FCL D20', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (47, N'', N'LAEM CHABANG', N'IKEA (BANGNA)', N'LAD KRABANG', N'LAEM CHABANG->IKEA (BANGNA)->LAD KRABANG', 1, N'', N'', N'', N'', N'IKEA STORE 38 หมู่ 6 ถ.บางนา-ตราด ก.ม.8  ', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (48, N'', N'LCB', N'PACO', N'LCB', N'LCB->PACO->LCB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (49, N'40''HC', N'LKB', N'REV EDITON KM.19', N'LKB', N'40''HC->LKB->REV EDITON KM.19->LKB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (50, N'', N'LAEM CHABANG', N'IKEA (BANGYAI)', N'LAD KRABANG', N'LAEM CHABANG->IKEA (BANGYAI)->LAD KRABANG', 1, N'', N'', N'', N'', N'BANGYAI', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (51, N'40''D', N'LKB', N'BATA WHA KM.18', N'LKB', N'40''D->LKB->BATA WHA KM.18->LKB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (52, N'D40', N'LKB', N'TOSHIBA (NISSHINBO) 19.01-22.00', N'LKB', N'D40->LKB->TOSHIBA (NISSHINBO) 19.01-22.00->LKB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (53, N'D40', N'LKB', N'TOSHIBA (SK) 19.01-22.00', N'LKB', N'D40->LKB->TOSHIBA (SK) 19.01-22.00->LKB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
INSERT [dbo].[Job_TransportRoute] ([LocationID], [Place1], [Place2], [Place3], [Place4], [LocationRoute], [IsActive], [Address1], [Contact1], [Address2], [Contact2], [Address3], [Contact3], [Address4], [Contact4], [RouteFormat]) VALUES (54, N'D40', N'LKB', N'TOSHIBA (CB TACT) 19.01-22.00', N'LKB', N'D40->LKB->TOSHIBA (CB TACT) 19.01-22.00->LKB', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'4123')
SET IDENTITY_INSERT [dbo].[Job_TransportRoute] OFF
GO
INSERT [dbo].[Mas_Account] ([AccCode], [AccTName], [AccEName], [AccType], [AccMain], [AccSide]) VALUES (N'7010100', N'CNS ', N'CNS ', 1, N'', N'D')
INSERT [dbo].[Mas_Account] ([AccCode], [AccTName], [AccEName], [AccType], [AccMain], [AccSide]) VALUES (N'7012200', N'TRANSPORTATION', N'TRANSPORTATION', 1, N'', N'D')
INSERT [dbo].[Mas_Account] ([AccCode], [AccTName], [AccEName], [AccType], [AccMain], [AccSide]) VALUES (N'7012300', N'CUSTOMS ', N'CUSTOMS ', 1, N'', N'D')
INSERT [dbo].[Mas_Account] ([AccCode], [AccTName], [AccEName], [AccType], [AccMain], [AccSide]) VALUES (N'7013600', N'GOODYEAR THAILAND', N'GOODYEAR THAILAND', 1, N'', N'D')
GO
INSERT [dbo].[Mas_BookAccount] ([BranchCode], [BookCode], [BookName], [BankCode], [BankBranch], [IsLocal], [ACType], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LimitBalance], [GLAccountCode], [ControlBalance]) VALUES (N'00', N'ADVCUSTOMS', N'บัญชีสำหรับจ่ายเงินทดรองจ่าย', N'2', N'อาคารวิบูลย์ธานี', 1, N'S', N'พระรามสี่', N'', N'', N'', N'', N'', 0, N'', 1000000)
INSERT [dbo].[Mas_BookAccount] ([BranchCode], [BookCode], [BookName], [BankCode], [BankBranch], [IsLocal], [ACType], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LimitBalance], [GLAccountCode], [ControlBalance]) VALUES (N'00', N'ADVTRUCK', N'บัญชีสำหรับจ่ายเงินทดรองจ่าย', N'2', N'อาคารวิบูลย์ธานี', 1, N'S', N'พระรามสี่', N'', N'', N'', N'', N'', 0, N'', 3000000)
INSERT [dbo].[Mas_BookAccount] ([BranchCode], [BookCode], [BookName], [BankCode], [BankBranch], [IsLocal], [ACType], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LimitBalance], [GLAccountCode], [ControlBalance]) VALUES (N'00', N'BDEP', N'มัดจำตู้', N'3', N'อาคารวิบูลย์ธานี', 1, N'S', N'พระรามสี่', N'', N'', N'', N'', N'', 0, N'', 300000)
GO
INSERT [dbo].[Mas_Branch] ([Code], [BrName]) VALUES (N'00', N'สำนักงานใหญ่')
GO
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'ASIAP', N'0', N'CUSTOMERS', N'0205553022761', N'บริษัท', N'ASIA PRECISION A.T. CO.,LTD.', N'ASIA PRECISION A.T. CO.,LTD.', N'700/331 MOO 6 TAMBOL DONHUALOR,AMPH', N'MUANGCHONBURI,CHONBURI 20000 THAILAND', N'700/331 MOO 6 TAMBOL DONHUALOR,AMPH', N'MUANGCHONBURI,CHONBURI 20000 THAILAND', N'66-2-03846', NULL, NULL, NULL, N'', N'', N'', N'', N'7010100', 0, N'ASIAP', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'CHONBURI', N'20000', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'BATA', N'0', N'CUSTOMERS', N'0105527007751', N'บริษัท', N'BATA (THAILAND) LIMITED', N'BATA (THAILAND) LIMITED', N'1858/2,1858/134,35TH FLOOR,', N'DEBARATNA ROAD, BANGNA TAI,', N'1858/2,1858/134,35TH FLOOR,', N'DEBARATNA ROAD, BANGNA TAI,', N'66-02-3120', NULL, NULL, NULL, N'', N'THANYAKAN', N'', N'', N'', 0, N'BATA', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10260', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'BSH', N'0', N'CUSTOMERS', N'0105544021308', N'บริษัท', N'BSH HOME APPLIANCES LIMITED', N'BSH HOME APPLIANCES LIMITED', N'ITAL THAI TOWER, 2034/31-39, 2ND FL', N'NEW PETCHBURI RD., BANGKAPI,', N'ITAL THAI TOWER, 2034/31-39, 2ND FL', N'NEW PETCHBURI RD., BANGKAPI,', N'', NULL, NULL, NULL, N'', N'', N'', N'NATTAPAKSON', N'7012300', 0, N'BSH', N'0', N'TH', NULL, 30, N'WED', 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10310', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'CONICE', N'0', N'CUSTOMERS', N'0105519014085', N'บริษัท', N'CONICE ELECTRONIC CO.,LTD.', N'CONICE ELECTRONIC CO.,LTD.', N'NO.4 SOI VIBHAVADI RANGSIT 2;', N'JUNCTION 2,RATCHADAPISEK,', N'NO.4 SOI VIBHAVADI RANGSIT 2;', N'JUNCTION 2,RATCHADAPISEK,', N'089-2002260', NULL, NULL, NULL, N'TANU', N'KANJANA', NULL, N'NATTAPAKSON', N'', 0, N'CONICE', N'0', N'TH', NULL, 0, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10400', N'conice@.co.th', NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'DECAT', N'0', N'CUSTOMERS', N'0115558007311', N'บริษัท', N'DECATHLON (THAILAND) CO.,LTD', N'DECATHLON (THAILAND) CO.,LTD', N'NO. 19/501 MOO 13 DABARATANA ROAD,', N'BANGKAEW', N'NO. 19/501 MOO 13 DABARATANA ROAD,', N'BANGKAEW', N'', NULL, NULL, NULL, N'', N'THANYAKAN', N'', N'', N'7012300', 0, N'DECAT', N'0', N'TH', NULL, 30, N'Every 7th of the Month', 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'SAMUTPRAKARN', N'10540', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'EASTB', N'0', N'CUSTOMERS', N'0105535116741', N'บริษัท', N'EAST BOARD INDUSTRY CO., LTD.', N'EAST BOARD INDUSTRY CO., LTD.', N'170 MOO 4,WATTANANAKORN-KLONGHAD RD', N'TOMBOL WATTANANAKORN AMPHUR', N'170 MOO 4,WATTANANAKORN-KLONGHAD RD', N'TOMBOL WATTANANAKORN AMPHUR', N'', NULL, NULL, NULL, N'', N'RAKSAK', N'RAKSAK', N'', N'7012200', 0, N'EASTB', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10110', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'EMERS', N'0', N'CUSTOMERS', N'0105534122021', N'บริษัท', N'EMERSON ELECTRIC (THAILAND) LT', N'EMERSON ELECTRIC (THAILAND) LT', N'24 MOO 4, TAMBOL PLUAKDAENG,', N'AMPHUR PLUAKDEANG, RAYONG 21140', N'24 MOO 4, TAMBOL PLUAKDAENG,', N'AMPHUR PLUAKDEANG, RAYONG 21140', N'', NULL, NULL, NULL, N'', N'WANVISA', N'', N'', N'7010100', 0, N'EMERS', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'RAYONG', N'21140', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'FOREV', N'0', N'CUSTOMERS', N'0105539028375', N'บริษัท', N'FOREVER SERVICE CO.,LTD.', N'FOREVER SERVICE CO.,LTD.', N'1/571 หมู่ที่ 14 ตำบลบางวัว', N'อำเภอบางปะกง จังหวัดฉะเชิงเทรา', N'', N'', N'', NULL, NULL, NULL, N'', N'RAKSAK', N'', N'', N'7012300', 0, N'FOREV', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'CHACHOENGSAO', N'24180', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'GORET', N'0', N'CUSTOMERS', N'0105557054498', N'บริษัท', N'GO RETAIL CO., LTD.', N'GO RETAIL CO., LTD.', N'2032 ITALTHAI TOWER,5 FLR.,', N'NEW PETCHBURI RD.,BANGKAPI,', N'2032 ITALTHAI TOWER,5 FLR.,', N'NEW PETCHBURI RD.,BANGKAPI,', N'662349770', NULL, NULL, NULL, N'', N'RAKSAK', N'', N'', N'7012300', 0, N'GORET', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10310', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'GYTH', N'0', N'CUSTOMERS', N'0107537001188', N'บริษัท', N'GOODYEAR (THAILAND) PCL.', N'GOODYEAR (THAILAND) PCL.', N'50/9 PHAHOLYOTHIN ROAD KM.36,', N'KLONGNUENG,KLONGLUANG', N'50/9 PHAHOLYOTHIN ROAD KM.36,', N'KLONGNUENG,KLONGLUANG', N'66-2-9098080', NULL, NULL, NULL, N'THANIT', N'WUTTHICHAI', N'THUNYAPORN', N'', N'7013600', 0, N'GYTH', N'0', N'TH', NULL, 90, N'MON, WED, FRI', 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'PATUMTHANI', N'12120', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'HIT', N'0', N'CUSTOMERS', N'0105553074311', N'บริษัท', N'HANESBRANDS INTERNATIONAL (THAILAND) LTD.', N'HANESBRANDS INTERNATIONAL (THAILAND) LTD.', N'388 EXCHANGE TOWER, 28TH FLOOR,', N'UNIT 2801,SUKHUMVIT RD, KLONGTOEY', N'388 EXCHANGE TOWER, 28TH FLOOR,', N'UNIT 2801,SUKHUMVIT RD, KLONGTOEY', N'6622627576', NULL, NULL, NULL, N'', N'', N'', N'', N'7012300', 0, N'HIT', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10110', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'IKANO', N'0', N'CUSTOMERS', N'0105550011416', N'บริษัท', N'IKANO (THAILAND) LIMITED.', N'IKANO (THAILAND) LIMITED.', N'38 MOO 6 BANGKEAW SUB-DISTRICT,', N'BANGPLEE DISTRICT, SAMUTPRAKARN 10540', N'38 MOO 6 BANGKEAW SUB-DISTRICT,', N'BANGPLEE DISTRICT, SAMUTPRAKARN 10540', N'', NULL, NULL, NULL, N'', N'RAKSAK', N'', N'', N'7010100', 0, N'IKANO', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'SAMUTPRAKARN', N'10540', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'IKANO2', N'4', N'CUSTOMERS', N'0105550011416', N'บริษัท', N'IKANO (THAILAND) LIMITED (BRANCH 00004)', N'IKANO (THAILAND) LIMITED (BRANCH 00004)', N'109,199,199/1-2  MOO.6 RATTANATHIBET ROAD,', N'SAO THONG HIN SUB-DISTRICT, BANG YAI DISTRICT', N'109,199,199/1-2  MOO.6 RATTANATHIBET ROAD,', N'SAO THONG HIN SUB-DISTRICT, BANG YAI DISTRICT', N'', NULL, NULL, NULL, N'', N'RAKSAK', N'', N'', N'7010100', 0, N'IKANO2', N'4', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'Nonthaburi', N'11140', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'ITOTH', N'0', N'CUSTOMERS', N'0115547013713', N'บริษัท', N'ITO THAI METAL WORK CO, LTD', N'ITO THAI METAL WORK CO, LTD', N'103 MOO 4 MABYANGPORN', N'PLUAKDAENG', N'103 MOO 4 MABYANGPORN', N'PLUAKDAENG', N'6638660225', NULL, NULL, NULL, N'', N'', N'', N'', N'', 0, N'ITOTH', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'RAYONG', N'21140', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'KAWAS', N'0', N'CUSTOMERS', N'0105521005021', N'บริษัท', N'KAWASUMI LABORATORIES (TH) LTD', N'KAWASUMI LABORATORIES (TH) LTD', N'NAVA NAKORN INDUSTRIAL PROMOTION ZO', N'55/26 MOO 13,PHAHOYOTHIN RD.,KM.46,', N'NAVA NAKORN INDUSTRIAL PROMOTION ZO', N'55/26 MOO 13,PHAHOYOTHIN RD.,KM.46,', N'', NULL, NULL, NULL, N'', N'', N'WANVISA', N'', N'7012200', 0, N'KAWAS', N'0', N'TH', NULL, 30, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'PATHUMTHANI', N'12120', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'NANYA', N'0', N'CUSTOMERS', N'0105533044581', N'บริษัท', N'NAN YANG GARMENT CO.LTD.,', N'NAN YANG GARMENT CO.LTD.,', N'27 PHETKASEM RD.,NONGKANGPLOO,', N'NONGKHAM,BANGKOK 10160 THAILAND.', N'27 PHETKASEM RD.,NONGKANGPLOO,', N'NONGKHAM,BANGKOK 10160 THAILAND.', N'6622421216', NULL, NULL, NULL, N'', N'', N'', N'', N'', 0, N'NANYA', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10160', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'PRESID', N'0', N'CUSTOMERS', N'0105534092989', N'บริษัท', N'PRESIDENT AUTOMOBILE INDUSTRIES. CO.,LTD.', N'PRESIDENT AUTOMOBILE INDUSTRIES. CO.,LTD.', N'88/8 MOO 9 SATETHAKIT 1 ROAD,', N'SUANLUANG, KRATHUMBAN,', N'88/8 MOO 9 SATETHAKIT 1 ROAD,', N'SUANLUANG, KRATHUMBAN,', N'662-8100526-8', NULL, NULL, NULL, N'', N'', N'NAVIDA', N'', N'7012200', 0, N'PRESID', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'SAMUTSAKORN', N'74110', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'REVED', N'0', N'CUSTOMERS', N'0105548134981', N'บริษัท', N'REV EDITION CO., LTD.', N'REV EDITION CO., LTD.', N'989 SIAM PIWAT TOWER, ROOM A2 FLOOR', N'RAMA 1 ROAD, PATHUMWAN, PATHUMWAN,', N'989 SIAM PIWAT TOWER, ROOM A2 FLOOR', N'RAMA 1 ROAD, PATHUMWAN, PATHUMWAN,', N'66-94-9361', NULL, NULL, NULL, N'TANU', N'KANJANA', NULL, N'THANYAKAN', N'7012300', 0, N'REVED', N'0', N'TH', NULL, 30, N'Every 7th of the Month', 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10330', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'ROYAL', N'0', N'CUSTOMERS', N'0205551027846', N'บริษัท', N'ROYAL FINISHING CO.,LTD.', N'ROYAL FINISHING CO.,LTD.', N'1146/146-147 MOO.5, EAKPAILIN TOWER', N'SRINAKARIN RD., T.SAMRONGNUA, A.MUANG,', N'1146/146-147 MOO.5, EAKPAILIN TOWER', N'SRINAKARIN RD., T.SAMRONGNUA, A.MUANG,', N'', NULL, NULL, NULL, N'', N'', N'WANVISA', N'', N'7012200', 0, N'ROYAL', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'SAMUTPRAKARN', N'10270', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'TCLEL', N'0', N'CUSTOMERS', N'0105547134618', N'บริษัท', N'TCL ELECTRONICS (THAILAND) CO.', N'TCL ELECTRONICS (THAILAND) CO.', N'RUNGROJTHANAKUL BUILDING 9TH FLOOR,', N'46/7 RATCHADAPISEK ROAD,HUAYKWANG,', N'RUNGROJTHANAKUL BUILDING 9TH FLOOR,', N'46/7 RATCHADAPISEK ROAD,HUAYKWANG,', N'', NULL, NULL, NULL, N'THANIT', N'KATESARIRAT', N'KATESARIRAT', N'RAKSAK', N'7012300', 0, N'TCLEL', N'', N'TH', NULL, 30, NULL, 0, N'0', N'0', NULL, NULL, NULL, 0, 10310, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'TOSHIBA', N'0', N'CUSTOMERS', N'0135543000498', N'บริษัท', N'TOSHIBA LOGISTICS (THAILAND) CO., LTD.', N'TOSHIBA LOGISTICS (THAILAND) CO., LTD.', N'144/1 MOO 5, BANGKADI INDUSTRIAL PARK,', N'TAMBOL BANGKADEE, AMPHUR MUANG,', N'144/1 MOO 5, BANGKADI INDUSTRIAL PARK,', N'TAMBOL BANGKADEE, AMPHUR MUANG,', N'', NULL, NULL, NULL, N'', N'', N'WANVISA', N'', N'7012200', 0, N'TOSHIBA', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'PATHUMTHANI', N'12000', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'TPG', N'0', N'CUSTOMERS', N'0145541000300', N'บริษัท', N'THAI PROGRESS GARMENT CO.LTD.', N'THAI PROGRESS GARMENT CO.LTD.', N'587 SOI 4/2 EXPORT PROCESSING ZONE,', N'BANGPA-IN INDUSTRIAL ESTATE,', N'587 SOI 4/2 EXPORT PROCESSING ZONE,', N'BANGPA-IN INDUSTRIAL ESTATE,', N'66-2-03522', NULL, NULL, NULL, N'', N'', N'RAKSAK', N'', N'7012200', 0, N'TPG', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'AYUTTHAYA', N'13160', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'UASPO', N'0', N'CUSTOMERS', N'0105558022093', N'บริษัท', N'UA SPORTS (THAILAND) CO,. LTD.', N'UA SPORTS (THAILAND) CO,. LTD.', N'989 SIAM PIWAT TOWER, ROOM A2,', N'7TH FLOOR, RAMA 1 ROAD, PATHUMWAN,', N'989 SIAM PIWAT TOWER, ROOM A2,', N'7TH FLOOR, RAMA 1 ROAD, PATHUMWAN,', N'66-2-09024', NULL, NULL, NULL, N'', N'THANYAKAN', N'', N'', N'7012300', 0, N'UASPO', N'0', N'TH', NULL, 30, N'Every 7th of the Month', 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'BANGKOK', N'10330', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'UNIVER', N'1', N'CUSTOMERS', N'0105531011830', N'บริษัท', N'UNIVERSAL SPORTING GOODS(THAI)CO,LTD. (BRANCH NO.00001)', N'UNIVERSAL SPORTING GOODS(THAI)CO,LTD. (BRANCH NO.00001)', N'91/1 MOO1 SOI WAT THIEN-DAD, PETCHKASEM RD,', N'BAN-MAI, SAM-PHAN', N'91/1 MOO1 SOI WAT THIEN-DAD, PETCHKASEM RD,', N'BAN-MAI, SAM-PHAN', N'6624290690', NULL, NULL, NULL, N'', N'', N'WANVISA', N'', N'7012200', 0, N'UNIVER', N'1', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'Nakornpathom ', N'73110', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Mas_Company] ([CustCode], [Branch], [CustGroup], [TaxNumber], [Title], [NameThai], [NameEng], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [ManagerCode], [CSCodeIM], [CSCodeEX], [CSCodeOT], [GLAccountCode], [CustType], [BillToCustCode], [BillToBranch], [UsedLanguage], [LevelGrade], [TermOfPayment], [BillCondition], [CreditLimit], [MapText], [MapFileName], [CmpType], [CmpLevelExp], [CmpLevelImp], [Is19bis], [MgrSeq], [LevelNoExp], [LevelNoImp], [LnNO], [AdjTaxCode], [BkAuthorNo], [BkAuthorCnn], [LtdPsWkName], [ConsStatus], [CommLevel], [DutyLimit], [CommRate], [TAddress], [TDistrict], [TSubProvince], [TProvince], [TPostCode], [DMailAddress], [PrivilegeOption], [GoldCardNO], [CustomsBrokerSeq], [ISCustomerSign], [ISCustomerSignInv], [ISCustomerSignDec], [ISCustomerSignECon], [IsShippingCannotSign], [ExportCode], [Code19BIS], [WEB_SITE]) VALUES (N'UNIVER2', N'0', N'CUSTOMERS', N'0105531011830', N'บริษัท', N'UNIVERSAL SPORTING GOODS (THAI) CO.,LTD.', N'UNIVERSAL SPORTING GOODS (THAI) CO.,LTD.', N'91 MOO 1 WAT THIEN-DAD, PETCHKASEM RD,', N'BAN-MAI, SAM-PHAN,', N'91 MOO 1 WAT THIEN-DAD, PETCHKASEM RD,', N'BAN-MAI, SAM-PHAN,', N'6624290690', NULL, NULL, NULL, N'', N'', N'WANVISA', N'', N'7012200', 0, N'UNIVER2', N'0', N'TH', NULL, NULL, NULL, 0, N'', N'', N'', N'', N'', 0, 0, 0, 0, N'', N'', N'', N'', N'', N'', N'', 0, 0, NULL, NULL, NULL, N'Nakornpathom ', N'73110', NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'BSH', N'0', 1, N'IMPORT', N'Supply Chain Officer', N'Kwannapa Charoenkul', N'Kwannapa.Charoenkul@bshg.com', N'02-0127914')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'CONICE', N'0', 1, N'Transport', N'CS', N'Pensi', N'Pensi@conice.co.th', NULL)
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GORET', N'0', 1, N'IMPORT', N'', N'', N'', N'02-034-9770')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 1, N'EXPORT AV', N'CS', N'คุณไก่', N'sirinya_homhual@goodyear.com', N'02 909 8082 Ext#302')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 2, N'EXPORT GT', N'CS', N'คุณจุ๊บ', N'sujitra_intarapukdee@goodyear.com', N'02 909 8080 Ext#318')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 3, N'EXPORT RW', N'CS', N'คุณจุ๊บ', N'sujitra_intarapukdee@goodyear.com', N'02 909 8080 Ext#318')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 4, N'IMPORT RW', N'CS', N'คุณเจี๊ยบ สมปรารถนา', N'LDA5713 <apll_rm@goodyear.com>', N'084 439 3154')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 5, N'IMPORT RW', N'OPERATION BBW W/H#1', N'คุณกิตติศักดิ์', N'', N'087 066 6026')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 6, N'IMPORT GT', N'OPERATION BBW W/H#2', N'คุณธนเดช', N'', N'094 563 6615')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 7, N'IMPORT AV', N'OPERATION W/H AV', N'คุณจำเนียน', N'', N'098 426 8827')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 8, N'IMPORT RW', N'OPERATION W/H RW', N'คุณวสันต์', N'wasan_khantharaksa@goodyear.com', N'02-9098080 Ext#178')
INSERT [dbo].[Mas_CompanyContact] ([CustCode], [Branch], [ItemNo], [Department], [Position], [ContactName], [EMail], [Phone]) VALUES (N'GYTH', N'0', 9, N'EXPORT GT', N'OPERATION W/H GT/AV', N'คุณเล็ก', N'acharaporn_ruangphachum@goodyear.com', N'085 812 5657')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'01', N'รออนุมัติ (REQUEST)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'02', N'อนุมัติแล้ว(APPROVED)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'03', N'รอเคลียร์เงิน (PAYMENTED)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'04', N'ปิดมาแล้วบางส่วน (PART-CLEARING)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'05', N'ปิดมาครบแล้ว (FULL-CLEARING)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'06', N'เคลียร์เงินแล้ว (CLEARED)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'99', N'ยกเลิก (CANCELLED)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'01', N'ค่าใช้จ่ายการเตรียมงาน (C/S)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'02', N'ค่าดำเนินการทางพิธีการ (C/S)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'03', N'ค่าใช้จ่ายในระหว่างการตรวจปล่อย (S/P)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'04', N'ค่าใช้จ่ายอื่นๆ หลังการตรวจปล่อย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'C', N'รอเคลียริ่ง')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'P', N'เช็คผ่าน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'R', N'เช็คคืน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'1', N'Marketing Dept.')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'2', N'Customer Services')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'3', N'Shipping Dept')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'4', N'Financial Dept')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'5', N'Accounting Dept')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'6', N'IT Administration Dept')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'01', N'รออนุมัติ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'02', N'อนุมัติแล้ว')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'03', N'เคลียร์เงินแล้ว')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'04', N'BILLED')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'99', N'ยกเลิก')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'1', N'เงินทดรองจ่ายเรียกเก็บได้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'2', N'ต้นทุนเรียกเก็บไม่ได้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'3', N'ค่าบริการ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'CNS', N'CNS-7010100')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'CNSG', N'NON CNS GY 7013600')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'CNSN', N'NON CNS 7012200')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'RT', N'ผู้ค้าปลีก')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'WO', N'ผุ้ค่าส่ง')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'AG', N'AGENT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'CO', N'CONSIGNEE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'DI', N'DISTRIBUTOR')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'FW', N'FORWARDER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'MA', N'MANUFACTURERS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'OT', N'OTHERS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'TR', N'TRANSPORTER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'VE', N'VENDER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'CONSIGNEE', N'ผู้ซื้อขาย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'CUSTOMERS', N'ลูกค้าทั่วไป')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'INTERNAL', N'หน่วยงานภายใน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'NOTIFY_PARTY', N'ผู้รับส่งสินค้า')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'PERSON', N'บุคคลทั่วไป')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'PROSPECT', N'ผู้มุ่งหวัง')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_TYPE', N'0', N'LOCAL')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_TYPE', N'1', N'FOREIGN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_19BIS', N'BG', N'BANK GUARANTEE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_19BIS', N'CA', N'CASH')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_19BIS', N'DD', N'DRAFT DEPOSIT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'AF', N'AFTA')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'FD', N'FORM D')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'FR', N'FORM CO')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'FT', N'FORM FTA')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'NX', N'TAX EXCEPTS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'OT', N'OTHERS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'TX', N'TAX PAID')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_PRIVILEGE', N'CB', N'CUSTOMS BROKER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_PRIVILEGE', N'GC', N'GOLD CARD')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_ACC', N'G', N'GL')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_ACC', N'P', N'PV')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_ACC', N'R', N'RV')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'ADV', N'ADVANCE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'CLR', N'CLEARING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'INV', N'INVOICE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'PAY', N'BILL PAYMENT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'00', N'PENDING CONFIRM')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'01', N'JOB CONFIRMED')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'02', N'JOB IN PROCESS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'03', N'CLEARANCE COMPLETED')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'04', N'READY FOR BILLING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'05', N'PARTIAL BILLING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'06', N'BILLING COMPLETED')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'07', N'PAYMENT COMPLETED')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'98', N'HOLD FOR CHECKING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'99', N'CANCELLED')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'01', N'IMPORT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'02', N'EXPORT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'03', N'DOMESTIC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'04', N'C/O')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'05', N'BANKING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'06', N'OFFICE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'07', N'SUPPORT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'08', N'FREIGHT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'99', N'GENERAL')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'ACC', N'Accounting')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'ADM', N'Admin')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'ADV', N'Advance Request')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'CLR', N'Advance Clearing')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'CS', N'Job Control')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'MAS', N'Master Files')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'REP', N'Reports & Analysis')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'SALES', N'Marketing')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'AccountCode', N'ผังบัญชี')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Adjustment', N'รายการปรับปรุง')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Approve', N'อนุมัติรายการ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Billing', N'ใบวางบิล')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Cheque', N'รับเช็คล่วงหน้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Costing', N'ต้นทุนค่าบริการค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'CreditNote', N'ใบเพิ่มหนี้/ลดหนี้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Expense', N'บิลค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'GenerateInv', N'สร้างใบแจ้งหนี้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'GLNote', N'สมุุดรายวัน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Invoice', N'ใบแจ้งหนี้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Payment', N'จ่ายเงินตามบิลค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'PettyCash', N'เงินสดย่อย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Receipt', N'ใบเสร็จรับเงิน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'RecvInv', N'รับชำระตามใบแจ้งหนี้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'TaxInvoice', N'ใบกำกับภาษี')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Voucher', N'ข้อมูลการรับ/จ่ายเงิน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'WHTax', N'ใบหัก ณ ที่จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADM', N'FileManager', N'File Manager')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADM', N'Role', N'บทบาทผู้ใช้งาน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADM', N'SQLAdmin', N'SQL Administrator')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'Approve', N'อนุมัติใบเบิกค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'CreditAdv', N'เบิกเงินสดย่อย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'EstimateCost', N'ประมาณการค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'Index', N'ใบเบิกค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'Payment', N'จ่ายเงินตามใบเบิกค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Approve', N'อนุมัติใบปิดค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Earnest', N'เคลียร์เงินมัดจำตู้')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Index', N'ใบปิดค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Receive', N'รับเคลียร์เงินจากใบปิดค่าใช้จ่าย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'CreateJob', N'เปิดงานใหม่')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Index', N'ค้นหางาน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'ShowJob', N'รายละเอียดงาน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Transport', N'ใบจองรถ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'TruckApprove', N'อนุมัติงานขนส่ง')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Bank', N'ธนาคาร')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'BookAccount', N'สมุดบัญชีธนาคาร')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Branch', N'สาขา')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'BudgetPolicy', N'มาตรฐานค่าบริการ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'CompanyContact', N'รายชื่อผู้ติดต่อ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Country', N'ประเทศ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Currency', N'สกุลเงิน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Customers', N'ผู้นำเข้าส่งออก')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'CustomsPort', N'ท่าที่ตรวจปล่อย')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'CustomsUnit', N'หน่วยสินค้า')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'DeclareType', N'ประเภทใบขนสินค้า')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Index', N'ค่าคงที่ระบบ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'InterPort', N'ท่าต่างประเทศ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Province', N'จังหวัด/อำเภอ/ตำบล')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'ServiceCode', N'ค่าบริการต่างๆ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'ServiceGroup', N'กลุ่มค่าบริการ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'ServUnit', N'หน่วยการบริการ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'TransportRoute', N'เส้นทางการขนส่งสินค้า')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'UserAuth', N'สิทธิการใช้งาน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Users', N'ผู้ใช้งาน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Venders', N'ผู้ให้บริการ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Vessel', N'ชื่อพาหนะ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Export', N'ส่งออกข้อมูล')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Import', N'นำเข้าข้อมูล')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Index', N'รายงานต่างๆ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Tracking', N'ตรวจสอบสถานะงาน')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_SALES', N'QuoApprove', N'อนุมัติใบเสนอราคา')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_SALES', N'Quotation', N'ใบเสนอราคา')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CA', N'Cash/Transfer')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CH', N'Cashier Cheque')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CR', N'Credit')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CU', N'Customer Cheque')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS1', N'3195/8 อาคารวิบูลย์ธานี 1 ชั้น 3 ถนนพระราม 4')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS1_EN', N'3195/8  VIBULTHANI 3RD FLOOR RAMA IV ROAD')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS2', N'แขวงคลองตัน เขตคลองเตย กรุงเทพมหานคร 10110')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS2_EN', N'KLONGTON KLONGTOEY BKK 10110')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_EMAIL', N'www.apllogistics.com')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_FAX', N'0-20809009')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_LOGO', N'apl-logo.jpg')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_NAME', N'บริษัท เอพีแอล โลจิสติกส์ เอสวีซีเอส (ประเทศไทย) จำกัด')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_NAME_EN', N'APL LOGISTICS SVCS (THAILAND) CO.,LTD')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TAXBRANCH', N'00000')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TAXNUMBER', N'0105542016277')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TEL', N'0-20809000')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'CURRENCY', N'THB')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'DEFAULT_BRANCH', N'00')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'DEFAULT_LANGUAGE', N'EN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'PAYMENT_CREDIT_DAYS', N'30')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'VATRATE', N'0.07')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo, h.RecUser,,, h.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'MAIN_SQL', N'SELECT acType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) {0}
) as t WHERE PRType=''P'' ORDER BY acType,PRVoucher')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'MAIN_SQL', N'SELECT acType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> ''''))  {0}
) as t WHERE PRType=''R'' ORDER BY acType,PRVoucher')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'MAIN_CLITERIA', N'WHERE,t.AdvDate, t.CustCode, t.ForJNo, t.AdvBy, t.ForwarderCode, t.AdvStatus, t.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'MAIN_SQL', N'SELECT t.DocDate as JobDate,t.ForJNo as JobNo,t.HAWB,t.AgentCode,t.ETADate,t.DutyDate,t.JobTypeName,t.ShipByName,t.AdvBy,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t {0} ORDER BY t.DocDate,t.ForJNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'MAIN_CLITERIA', N'WHERE,a.AdvDate,a.CustCode,d.ForJNo,a.ReqBy,d.VenCode,a.DocStatus,a.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'MAIN_SQL', N'SELECT ad.AdvNo,ad.AdvDate,ad.PaymentDate,ad.PaymentRef,ad.EmpCode as ReqBy,ad.SDescription,ad.CustCode,ad.ForJNo,ad.AdvPayAmount,ad.Charge50Tavi FROM (
select a.*,d.ForJNo,d.ItemNo,d.SICode,d.SDescription,
d.IsDuplicate,d.IsChargeVAT,d.Is50Tavi,d.CurrencyCode,d.ExchangeRate as DExchangeRate,
b.TaxNumber,b.NameThai,b.NameEng,d.VenCode,d.TRemark as DRemark,
d.BaseAmount,d.RateVAT,d.ChargeVAT,d.Rate50Tavi,d.Charge50Tavi,
d.AdvQty,d.UnitPrice,d.AdvNet,d.AdvPayAmount,
d.BaseVATExc,d.VATExc,d.BaseVATInc,d.VATInc,
d.Base50TaviInc,d.WHTExc,d.Base50TaviExc,d.WHTInc,
d.BaseVATInc+d.BaseVATExc as BaseVAT,d.Base50TaviExc+d.Base50TaviInc as Base50Tavi,j.*
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN (
SELECT BranchCode as JobBranch,JNo as JobNo,JRevise, ConfirmDate, CPolicyCode, DocDate, CustContactName, QNo, Revise, ManagerCode, CSCode, JobStatus, 
                         InvNo as CustInvNo, InvTotal, InvProduct, InvCountry, InvFCountry, InvInterPort, InvProductQty, InvProductUnit, InvCurUnit, InvCurRate, ImExDate, BLNo, 
                         BookingNo, ClearPort, ClearPortNo, ClearDate, LoadDate, ForwarderCode, AgentCode, VesselName, ETDDate, ETADate, ETTime, FNetPrice, BNetPrice, 
                          CancelProveTime, CloseJobDate, CloseJobTime, CloseJobBy, DeclareType, DeclareNumber, 
                         DeclareStatus, TyAuthorSp, Ty19BIS, TyClearTax, TyClearTaxReson, EstDeliverDate, EstDeliverTime, TotalContainer, DutyDate, DutyAmount, DutyCustPayOther, 
                         DutyCustPayChqAmt, DutyCustPayBankAmt, DutyCustPayEPAYAmt, DutyCustPayCardAmt, DutyCustPayCashAmt, DutyCustPayOtherAmt, DutyLtdPayOther, 
                         DutyLtdPayChqAmt, DutyLtdPayEPAYAmt, DutyLtdPayCashAmt, DutyLtdPayOtherAmt, ConfirmChqDate, ShippingEmp, ShippingCmd, TotalGW, GWUnit, TSRequest, 
                         ShipmentType, ReadyToClearDate, Commission, CommPayTo, ProjectName, MVesselName, TotalNW, Measurement, CustRefNO, TotalQty, HAWB, MAWB, 
                         consigneecode, privilegests, DeliveryNo, DeliveryTo, DeliveryAddr, CreateDate
FROM dbo.Job_Order
) j on d.BranchCode=j.JobBranch AND d.ForJNo=j.JobNo {0}
) ad  ORDER BY ad.AdvDate,ad.AdvNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'MAIN_CLITERIA', N'WHERE,a.AdvDate,a.CustCode,d.ForJNo,a.ReqBy,d.VenCode,a.DocStatus,a.BranchCode,d.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'MAIN_SQL', N'SELECT ad.AdvNo,ad.PaymentDate,ad.PaymentRef,ad.EmpCode as ReqBy,ad.SDescription,ad.CustCode,ad.ForJNo,ad.AdvPayAmount,ad.Charge50Tavi FROM (
select a.*,d.ForJNo,d.ItemNo,d.SICode,d.SDescription,
d.IsDuplicate,d.IsChargeVAT,d.Is50Tavi,d.CurrencyCode,d.ExchangeRate as DExchangeRate,
b.TaxNumber,b.NameThai,b.NameEng,d.VenCode,d.TRemark as DRemark,
d.BaseAmount,d.RateVAT,d.ChargeVAT,d.Rate50Tavi,d.Charge50Tavi,
d.AdvQty,d.UnitPrice,d.AdvNet,d.AdvPayAmount,
d.BaseVATExc,d.VATExc,d.BaseVATInc,d.VATInc,
d.Base50TaviInc,d.WHTExc,d.Base50TaviExc,d.WHTInc,
d.BaseVATInc+d.BaseVATExc as BaseVAT,d.Base50TaviExc+d.Base50TaviInc as Base50Tavi,j.*
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN (
SELECT BranchCode as JobBranch,JNo as JobNo,JRevise, ConfirmDate, CPolicyCode, DocDate, CustContactName, QNo, Revise, ManagerCode, CSCode, JobStatus, 
                         InvNo as CustInvNo, InvTotal, InvProduct, InvCountry, InvFCountry, InvInterPort, InvProductQty, InvProductUnit, InvCurUnit, InvCurRate, ImExDate, BLNo, 
                         BookingNo, ClearPort, ClearPortNo, ClearDate, LoadDate, ForwarderCode, AgentCode, VesselName, ETDDate, ETADate, ETTime, FNetPrice, BNetPrice, 
                          CancelProveTime, CloseJobDate, CloseJobTime, CloseJobBy, DeclareType, DeclareNumber, 
                         DeclareStatus, TyAuthorSp, Ty19BIS, TyClearTax, TyClearTaxReson, EstDeliverDate, EstDeliverTime, TotalContainer, DutyDate, DutyAmount, DutyCustPayOther, 
                         DutyCustPayChqAmt, DutyCustPayBankAmt, DutyCustPayEPAYAmt, DutyCustPayCardAmt, DutyCustPayCashAmt, DutyCustPayOtherAmt, DutyLtdPayOther, 
                         DutyLtdPayChqAmt, DutyLtdPayEPAYAmt, DutyLtdPayCashAmt, DutyLtdPayOtherAmt, ConfirmChqDate, ShippingEmp, ShippingCmd, TotalGW, GWUnit, TSRequest, 
                         ShipmentType, ReadyToClearDate, Commission, CommPayTo, ProjectName, MVesselName, TotalNW, Measurement, CustRefNO, TotalQty, HAWB, MAWB, 
                         consigneecode, privilegests, DeliveryNo, DeliveryTo, DeliveryAddr, CreateDate
FROM dbo.Job_Order
) j on d.BranchCode=j.JobBranch AND d.ForJNo=j.JobNo
 {0}) ad  ORDER BY ad.SDescription,ad.AdvNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'MAIN_SQL', N'SELECT a.CustCode as ''Customer'',c.consigneecode as ''Consignee'',
c.InvProduct as ''Products'',c.TotalContainer as ''Containers'',
c.BookingNo as ''BL/AWB'',c.CSCode as ''CS'',c.AgentCode as ''Vender'',
b.ForJNo as ''Job Number'',c.DeclareNumber as ''Customs Declare'',
c.DocDate as ''Job Date'',
SUM(CASE WHEN b.SICode='''' THEN b.AdvNet ELSE 0 END) as ''(N/A)'',SUM(CASE WHEN b.SICode=''ADV-001'' THEN b.AdvNet ELSE 0 END) as ''ค่าภาษีอากร'',SUM(CASE WHEN b.SICode=''ADV-019'' THEN b.AdvNet ELSE 0 END) as ''ค่า ฺB/L'',SUM(CASE WHEN b.SICode=''ERN-001'' THEN b.AdvNet ELSE 0 END) as ''ค่ามัดจำตู้'',
SUM(b.AdvNet) as ''Advance Paid'',a.EmpCode as ''Request By'',
SUM(d.ClrNet) as ''Clearing'',c.CloseJobDate as ''Close Job Date''
FROM Job_AdvDetail b
INNER JOIN Job_AdvHeader a ON b.BranchCode=a.BranchCode 
AND b.AdvNo= a.AdvNo
INNER JOIN Job_Order c ON b.BranchCode=c.BranchCode
AND b.ForJNo=c.JNo
LEFT JOIN (
    SELECT ch.BranchCode,cd.AdvNo,cd.AdvItemNo,SUM(cd.BNet) as ClrNet
    FROM Job_ClearHeader ch INNER JOIN Job_ClearDetail cd
    ON ch.BranchCode=cd.BranchCode AND 
    ch.ClrNo=cd.ClrNo
    WHERE ch.DocStatus<>99
    GROUP BY ch.BranchCode,cd.AdvNo,cd.AdvItemNo
) d
ON b.BranchCode=d.BranchCode
AND b.AdvNo=d.AdvNo
AND b.ItemNo=d.AdvItemNo
WHERE a.DocStatus<>99 AND b.AdvNet>0 {0}
GROUP BY a.CustCode,c.consigneecode,c.InvProduct,c.TotalContainer,c.BookingNo,
c.CSCode,c.AgentCode,b.ForJNo,c.DeclareNumber,c.DocDate,a.EmpCode,c.CloseJobDate
ORDER BY a.CustCode,b.ForJNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'MAIN_CLITERIA', N'AND,t.ETDDate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETDDate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType=2 AND t.JobStatus<>99  {0} ORDER BY t.ETDDate,t.ForJNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'MAIN_CLITERIA', N'AND,t.ETADate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETADate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType=1 AND t.JobStatus<>99 {0}  ORDER BY t.ETADate,t.ForJNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'MAIN_SQL', N'select a.AdvNo,a.EmpCode,c.CustCode,c.NameThai as CustName,b.ForJNo as JobNo,
j.DutyDate as InspectionDate,a.PaymentDate,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt,st.AdvStatusName
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
	SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.DocType=''CLR''
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+''#''+Convert(varchar,b.ItemNo))=e.DocNo
inner join Job_Order j ON b.BranchCode=j.BranchCode AND b.ForJNo=j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as AdvStatus, ConfigValue as AdvStatusName FROM Mas_Config WHERE ConfigCode=''ADV_STATUS''
) st ON a.DocStatus=st.AdvStatus
WHERE a.DocStatus>2 {0}
GROUP BY a.AdvNo,a.EmpCode,c.CustCode,c.NameThai,b.ForJNo,
j.DutyDate,a.PaymentDate,e.ReceiveRef,e.PaidAmount,st.AdvStatusName')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'MAIN_CLITERIA', N'AND,h.DocDate,,,h.EmpCode,h.VenCode,,h.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'MAIN_SQL', N'SELECT h.DocNo, h.DocDate, v.TName, h.PoNo, h.RefNo, 
CASE WHEN ISNULL(h.PaymentRef,'''')<>'''' THEN h.TotalNet ELSE 0 END as PaidAmount,
CASE WHEN NOT ISNULL(h.PaymentRef,'''')<>'''' THEN h.TotalNet ELSE 0 END as UnPaidAmount,
h.PaymentRef
FROM dbo.Job_PaymentHeader AS h INNER JOIN dbo.Mas_Vender AS v ON h.VenCode = v.VenCode
WHERE (h.ApproveBy <> '''') AND NOT (ISNULL(h.CancelProve,'''')<>'''') {0} ORDER BY v.TName')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'MAIN_CLITERIA', N'AND,ph.DocDate,jd.CustCode,jd.JNo,jd.CSCode,ph.VenCode,jd.JobStatus,ph.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'MAIN_SQL', N'SELECT ph.DocNo,ph.DocDate, ph.VenCode, ph.RefNo, pd.ForJNo, pd.SDescription, ph.PaymentRef, pd.Total,pd.BookingRefNo, pd.ClrRefNo, cd.LinkBillNo, jd.CustCode, jd.DeclareNumber, jd.CSCode
FROM dbo.Job_PaymentHeader AS ph INNER JOIN dbo.Job_PaymentDetail AS pd ON ph.BranchCode = pd.BranchCode AND ph.DocNo = pd.DocNo INNER JOIN dbo.Job_LoadInfoDetail AS ld ON pd.BookingItemNo = ld.ItemNo AND pd.BookingRefNo = ld.BookingNo AND pd.BranchCode = ld.BranchCode LEFT OUTER JOIN dbo.Job_Order AS jd ON pd.ForJNo = jd.JNo AND pd.BranchCode = jd.BranchCode LEFT OUTER JOIN dbo.Job_ClearDetail AS cd ON pd.ClrItemNo = cd.ItemNo AND pd.ClrRefNo = cd.ClrNo AND pd.BranchCode = cd.BranchCode WHERE (ISNULL(ph.CancelProve, '''') = '''') {0} ORDER BY ph.VenCode,ph.RefNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'MAIN_CLITERIA', N'WHERE,t.DueDate,t.CustCode,t.RefNo,t.EmpCode,,,t.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'MAIN_SQL', N'SELECT CustCode,DocNo,DocDate,DueDate,RefNo,
Sum(AmtAdvance) as TotalAdv,Sum(AmtCharge) as TotalCharge,Sum(AmtVAT) as TotalVat,Sum(Amt50Tavi) as Total50Tavi,
Sum(TotalAmt) as TotalNet,Sum(TotalReceiveAmt) as TotalReceived,Sum(TotalCreditAmt) as TotalCredit,Sum(TotalBal) as TotalBal
FROM (
SELECT ih.*,id.SICode,id.SDescription,id.AmtCharge,id.AmtVat,id.Amt50Tavi,id.AmtAdvance,
id.TotalAmt,id.AmtCredit,ISNULL(c.TotalCredit,0) as TotalCreditAmt,id.AmtCredit+ISNULL(r.RecvNet,0) as TotalReceiveAmt
,id.TotalAmt-id.AmtCredit-ISNULL(c.TotalCredit,0)-ISNULL(r.RecvNet,0) as TotalBal
,r.FromReceiptNo,r.VoucherNo,r.ReceiptDate
FROM dbo.Job_InvoiceHeader AS ih INNER JOIN dbo.Job_InvoiceDetail AS id 
ON ih.BranchCode = id.BranchCode AND ih.DocNo=id.DocNo
LEFT JOIN (SELECT    cd.BranchCode, cd.BillingNo, cd.BillItemNo, SUM(cd.TotalNet) AS TotalCredit
FROM dbo.Job_CNDNHeader AS ch INNER JOIN dbo.Job_CNDNDetail AS cd 
ON ch.BranchCode = cd.BranchCode AND ch.DocNo = cd.DocNo
WHERE (ch.DocStatus <> 99)
GROUP BY cd.BranchCode, cd.BillingNo, cd.BillItemNo) as c
ON id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
LEFT JOIN (SELECT    rd.BranchCode, rd.InvoiceNo, rd.InvoiceItemNo, 
SUM((CASE WHEN rd.VoucherNo<>'''' THEN rd.Net ELSE 0 END)) AS RecvNet,
(SELECT STUFF((
SELECT DISTINCT '','' + ReceiptNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as FromReceiptNo,
(SELECT STUFF((
SELECT DISTINCT '','' + VoucherNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as VoucherNo,
MAX(rh.ReceiptDate) as ReceiptDate
FROM      dbo.Job_ReceiptHeader AS rh INNER JOIN
             dbo.Job_ReceiptDetail AS rd ON rh.BranchCode = rd.BranchCode AND rh.ReceiptNo = rd.ReceiptNo
WHERE    (NOT (ISNULL(rh.CancelProve, '''') <> ''''))
GROUP BY rd.InvoiceNo, rd.InvoiceItemNo, rd.BranchCode) as r
ON id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
WHERE    (NOT (ISNULL(ih.CancelProve, '''') <> ''''))
) t {0} GROUP BY CustCode,DocNo,DocDate,DueDate,RefNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'MAIN_CLITERIA', N'WHERE,h.BillDate,h.CustCode,,h.EmpCode,,,h.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'MAIN_SQL', N'SELECT bl.BillAcceptNo,bl.BillDate,bl.CustCode,bl.InvNo,bl.AmtAdvance,bl.AmtChargeNonVAT,bl.AmtChargeVAT,bl.AmtVAT,bl.AmtWH,bl.AmtTotal FROM (
SELECT h.BranchCode, h.BillAcceptNo, h.BillDate, h.CustCode, h.CustBranch, h.BillRecvBy, h.BillRecvDate, h.DuePaymentDate, h.BillRemark, h.CancelReson, 
h.CancelProve, h.CancelDate, h.CancelTime, h.EmpCode, h.RecDateTime, h.TotalCustAdv, h.TotalAdvance, h.TotalChargeVAT, h.TotalChargeNonVAT, h.TotalVAT, 
h.TotalWH, h.TotalDiscount, h.TotalNet, d.ItemNo, d.InvNo, d.AmtAdvance, d.AmtChargeNonVAT, d.AmtChargeVAT, d.AmtWH, d.AmtVAT, d.AmtTotal, d.CurrencyCode, 
d.ExchangeRate, d.AmtCustAdvance, d.AmtForeign, d.InvDate, d.RefNo, d.AmtVATRate, d.AmtWHRate, d.AmtDiscount, d.AmtDiscRate
FROM dbo.Job_BillAcceptHeader AS h INNER JOIN
dbo.Job_BillAcceptDetail AS d ON h.BranchCode = d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo AND ISNULL(h.CancelProve,'''')='''' {0}
) bl ORDER BY bl.BillDate,bl.BillAcceptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'MAIN_CLITERIA', N'AND,b.VoucherDate,,,b.RecUser,,,b.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'MAIN_SQL', N'SELECT bk.BookCode,bk.LimitBalance,bk.SumCashOnhand,bk.SumChqClear,bk.SumChqOnhand,bk.SumCredit+bk.SumChqReturn as SumCreditable FROM (
SELECT q.*,q.SumCashOnhand+q.SumChqClear as SumCash,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand-q.LimitBalance as SumCashInBank,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand+q.SumCredit as SumBal,
q.SumCredit+q.SumChqReturn as SumCreditable
FROM (
select c.BookCode,c.LimitBalance,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount) else a.CashAmount end) as SumCashOnhand,
Sum(Case when a.ChqStatus=''P'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqClear,
Sum(Case when a.ChqStatus=''R'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqReturn,
Sum(Case when a.ChqStatus NOT IN(''P'',''R'') then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqOnhand,
Sum(Case when a.PRType=''P'' then -1*a.CreditAmount else a.CreditAmount end) as SumCredit,
Sum(Case when a.PRType=''P'' then -1*(a.CreditAmount) else 0 end) as SumAP,
Sum(Case when a.PRType=''R'' then (a.CreditAmount) else 0 end) as SumAR,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount+a.ChqAmount) else 0 end) as SumPV,
Sum(Case when a.PRType=''R'' then (a.CashAmount+a.ChqAmount) else 0 end) as SumRV
from Job_CashControlSub a inner join Job_CashControl b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo
left join Mas_BookAccount c 
on a.BookCode=c.BookCode
WHERE ISNULL(b.CancelProve,'''')='''' {0}
group by c.BookCode,c.LimitBalance) q
) bk ORDER BY BookCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'MAIN_CLITERIA', N'WHERE,,d.CustCode,,,d.VenderCode,,d.BranchCode,d.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'MAIN_SQL', N'select h.LocationRoute as WorkType,d.VenderCode,d.CustCode,d.SDescription as CostName,d.CostAmount,s.NameThai as ChargeName ,d.ChargeAmount,
d.ChargeAmount-d.CostAmount as Profit
from Job_TransportPrice d inner join Job_TransportRoute h
ON d.LocationID=h.LocationID
left join Job_SrvSingle s 
ON d.ChargeCode=s.SICode
{0}
ORDER BY d.SDescription,d.ChargeAmount-d.CostAmount DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'MAIN_SQL', N'SELECT acType,PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) {0}
) as t ORDER BY acType,VoucherDate,PRVoucher')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'MAIN_SQL', N'SELECT PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE d.acType<>''CU'' {0}
) as t ORDER BY PRType DESC,PRVoucher')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'MAIN_CLITERIA', N'AND,b.VoucherDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,ControlNo,VoucherDate,DocUsed,AmountUsed,AmountRemain,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU'' {0}
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' 
) t ORDER BY CustCode,ChqDate,ChqNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'MAIN_CLITERIA', N'AND,a.ChqDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,DocUsed,AmountUsed,ControlNo,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.BankCode,h.BankBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.BankCode=c.BankCode AND a.BankBranch=c.BankBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.BankCode,h.BankBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.BankCode,h.BankBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.BankCode=d.BankCode AND a.BankBranch=d.BankBranch 
WHERE a.acType=''CH'' {0}
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' 
) t ORDER BY CustCode,ChqDate,ChqNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'MAIN_CLITERIA', N'AND,a.ChqDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,AmountUsed,AmountRemain,DocUsed,ControlNo,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU''
AND a.PRType=''R'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' {0}
) t ORDER BY CustCode,ChqDate,ChqNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'MAIN_CLITERIA', N'AND,h.ClrDate,j.CustCode,j.JNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'MAIN_SQL', N'SELECT cl.ClrNo,cl.ClrDate,cl.SDescription,cl.AdvNO,cl.JobNo,cl.AdvAmount as AdvNet,cl.ClrNet,cl.Tax50Tavi,cl.SlipNo,cl.LinkBillNo as InvoiceNo FROM (select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
 WHERE h.DocStatus<>99 {0} ) cl ORDER BY cl.ClrDate,cl.ClrNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,c.EmpCode,a.VenderCode,b.ClrStatus,b.BranchCode,a.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'MAIN_SQL', N'select c.JNo,a.AdvNo,b.ClrNo,b.ClrDate,c.CustCode,d.NameThai as SDescription,a.VenderCode,a.Date50Tavi as SlipDate,a.UsedAmount,
a.BPrice as SumCost,a.ChargeVAT as AmtVat,a.Tax50Tavi as Amt50Tavi,(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as TotalInv,
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as Balance,a.LinkBillNo
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'''')='''' {0}
    order by a.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'MAIN_CLITERIA', N'AND,j.DutyDate,j.CustCode, j.JNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'MAIN_SQL', N'SELECT cl.ClrNo,cl.ClrDate,cl.JobNo,cl.DutyDate,SUM(cl.UsedAmount) as UsedAmount,SUM(cl.ChargeVAT) as AmtVat,SUM(cl.Tax50Tavi) as Tax50Tavi,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=1 THEN cl.ClrNet ELSE 0 END) as SumAdvance,SUM(CASE WHEN cl.IsExpense=1 THEN cl.ClrNet ELSE 0 END) as SumCost,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=0 THEN cl.ClrNet ELSE 0 END) as SumCharge,cl.LinkBillNo as InvoiceNo FROM (select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,j.DutyDate,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
 WHERE h.DocStatus<>99 {0} ) cl WHERE cl.ClrNet > 0 GROUP BY cl.ClrNo,cl.ClrDate,cl.JobNo,cl.DutyDate,cl.LinkBillNo ORDER BY cl.ClrDate,cl.ClrNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'MAIN_CLITERIA', N'AND,a.DocDate,a.CustCode,,a.EmpCode,,,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'MAIN_SQL', N'SELECT CustCode,DocDate,DocNo,InvoiceNo,TotalAmt,TotalVAT,TotalWHT,TotalNet FROM (
SELECT a.*,b.InvoiceNo,
b.TotalAmt,b.TotalVAT,b.TotalWHT,b.TotalNet,b.FTotalNet
FROM Job_CNDNHeader a LEFT JOIN
(
    SELECT BranchCode,DocNo,
    (SELECT STUFF((
SELECT DISTINCT '','' + BillingNo
FROM Job_CNDNDetail WHERE BranchCode=d.BranchCode
AND DocNo=d.DocNo  
    FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
    )) as InvoiceNo,
    Sum(DiffAmt) as TotalAmt,
    Sum(VATAmt) as TotalVAT,
    Sum(WHTAmt) as TotalWHT,
    Sum(TotalNet) as TotalNet,
    Sum(ForeignNet) as FTotalNet
    FROM Job_CNDNDetail d
    GROUP BY BranchCode,DocNo
) b
ON a.BranchCode=b.BranchCode
AND a.DocNo=b.DocNo
 WHERE a.DocStatus<>99 AND ISNULL(a.ApproveBy,'''')<>'''' {0}) t ORDER BY CustCode,DocDate,DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'MAIN_SQL', N'select a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.DocType=''CLR''
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+''#''+Convert(varchar,b.ItemNo))=e.DocNo
WHERE a.DocStatus>2 AND a.DocStatus<99 AND a.AdvType=5 {0}
GROUP BY
a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,e.ReceiveRef,e.PaidAmount
ORDER BY a.EmpCode,a.PaymentDate,a.AdvNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'MAIN_CLITERIA', N'AND,c.DutyDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode, c.JobStatus,c.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'MAIN_SQL', N'SELECT CustCode,CustName,TAddress,COUNT(DISTINCT JNo) as CountJob,
SUM(CostCleared) as TotalCost,SUM(Deposit) as TotalEarnest,
SUM(AdvBilled) as TotalAdv,SUM(ChargeBilled) as TotalCharge,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+'' ''+e.NameThai as CustName,e.TAddress,e.EAddress1+''''+e.EAddress2 as EAddress,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as AdvBilled,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as ChargeBilled,
(CASE WHEN d.GroupCode=''ERN'' THEN a.UsedAmount ELSE 0 END) as Deposit,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 {0}
) clr
GROUP BY CustCode,CustName,TAddress
ORDER BY CustCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'MAIN_CLITERIA', N'AND,c.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'MAIN_SQL', N'SELECT CustCode,CustName,
SUM(AdvCleared+CostCleared) as TotalExpClear,SUM(ExpWaitBill) as TotalExpWaitBill,
SUM(CostWaitBill) as TotalCostWaitBill,
SUM(AdvCleared) as TotalAdv,SUM(ChargeCleared) as TotalCharge,SUM(CostCleared) as TotalCost,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+'' ''+e.NameThai as CustName,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=0 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ExpWaitBill,
(CASE WHEN d.IsExpense=0 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ExpBilled,
(CASE WHEN d.IsExpense=1 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as CostWaitBill,
(CASE WHEN d.IsExpense=1 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as CostBilled,
(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 {0}
) clr
GROUP BY CustCode,CustName
ORDER BY CustName')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'MAIN_SQL', N'SELECT t.ReceiptNo as ''Receipt No'',CONCAT(t.CustEName,''<div style="display:flex;"><span style="flex:1">Ref# '',t.PaidRef,''</span><span style="flex:1"> Bank:'', t.PaidBank,''</span></div>'') as ''Shipper/Cheque Details'',
(CASE WHEN t.PaidType=''CHQ'' THEN Convert(float,t.PaidAmount) ELSE 0 END) as ''Chq Amt'',
(CASE WHEN t.PaidType=''CASH'' THEN Convert(float,t.PaidAmount) ELSE 0 END) as ''Cash Amt'',
t.TotalWhtax as ''WHD Tax'',t.PaidAmount as ''Total Amt'',t.InvNo as ''Invoice No''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' 
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'MAIN_CLITERIA', N'AND,a.Date50Tavi,c.CustCode,c.JNo,b.EmpCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'MAIN_SQL', N'select c.CustCode as ''Customer'',c.AgentCode as ''Vender'',
c.JNo as ''Job Number'',a.AdvNo as ''Advance No'',c.DutyDate as ''Inspection Date'',
b.ClrDate as ''Clearing Date'',c.TotalContainer as ''Container Number'',
a.SlipNO as ''Receipt No'',a.Date50Tavi as ''Date Receipt'',
a.AdvAmount as ''Container Deposit'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Addition Expenses'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Deposit Return'',
a.LinkBillNo as ''V/Receipt#'',v.VoucherDate as ''Received Date''
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
	where ISNULL(b.CancelProve,'''')='''' AND d.GroupCode=''ERN'' AND a.UsedAmount>0 {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'MAIN_CLITERIA', N'AND,h.DocDate,,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'MAIN_SQL', N'SELECT pa.DocNo,pa.DocDate,pa.ApproveDate,pa.VenCode,pa.PoNo,pa.RefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total,pa.PayType,pa.PaymentRef FROM (
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveDate,h.PaymentRef,
h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo 
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' {0}
) pa ORDER BY pa.DocDate,pa.DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'MAIN_CLITERIA', N'AND,h.DocDate,,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'MAIN_SQL', N'SELECT pa.DocNo,pa.DocDate,pa.VenCode,pa.BookingRefNo,pa.ClrRefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total,pa.PayType,pa.PaymentDate,pa.PaymentRef,pa.ForJNo FROM (
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.PaymentDate,h.PaymentRef,
h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo,d.ClrRefNo,d.BookingRefNo
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
) pa ORDER BY pa.SDescription,pa.DocDate,pa.DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'MAIN_CLITERIA', N'AND,c.DutyDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode,a.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'MAIN_SQL', N'select jt.JobTypeName as ''JobType'',sb.ShipByName as ''ShipBy'',
sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount-a.Tax50Tavi ELSE 0 END) as ''Revenue'',
sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as ''Cost'',
count(DISTINCT c.JNo) as ''Total Job'',
sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount-a.Tax50Tavi ELSE 0 END)/count(DISTINCT c.JNo) as ''Average Revenue'',
sum(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as ''Profit'',
(sum(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END))/count(DISTINCT c.JNo) as ''Average Profit'',
sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END)/count(DISTINCT c.JNo) as ''Average Cost''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON c.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON c.ShipBy=sb.ShipBy
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<90 {0}
group by jt.JobTypeName,sb.ShipByName')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'MAIN_CLITERIA', N'AND,ih.DocDate, ih.CustCode,ih.RefNo,ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.BillIssueDate,inv.BillAcceptNo,inv.BillAcceptDate,inv.DueDate,inv.SDescription,inv.Amt,inv.AmtVat,inv.AmtCredit,inv.Amt50Tavi,inv.TotalInv,inv.CreditNet,inv.ReceivedNet,inv.ReceiptNo,inv.LastVoucher FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt ELSE 0 END) as ReceivedAmt,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.AmtVAT ELSE 0 END) as ReceivedVat,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt50Tavi ELSE 0 END) as ReceivedWht,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Net ELSE 0 END) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv ORDER BY inv.DocDate,inv.DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,ih.RefNo, ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode,id.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.SDescription,inv.AmtAdvance,inv.AmtCharge,inv.AmtCredit,inv.AmtVat,inv.Amt50Tavi,inv.TotalInv,inv.ReceivedNet,inv.ReceiptNo,inv.LastVoucher FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt ELSE 0 END) as ReceivedAmt,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.AmtVAT ELSE 0 END) as ReceivedVat,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt50Tavi ELSE 0 END) as ReceivedWht,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Net ELSE 0 END) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv ORDER BY inv.SDescription,inv.DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,ih.RefNo,ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.CustCode,
sum(inv.AmtAdvance) as TotalAdvance,sum(inv.AmtCharge) as TotalCharge,sum(inv.AmtVat) as TotalVAT,sum(inv.Amt50Tavi) as Total50Tavi,
sum(inv.AmtCredit) as TotalPrepaid,sum(inv.TotalInv) as TotalInv,sum(ISNULL(inv.CreditNet,0)) as TotalCredit,
sum(inv.ReceivedNet) as TotalReceived,max(inv.LastVoucher) as VoucherNo 
FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt ELSE 0 END) as ReceivedAmt,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.AmtVAT ELSE 0 END) as ReceivedVat,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Amt50Tavi ELSE 0 END) as ReceivedWht,
	sum(CASE WHEN rd.ControlNo<>'''' THEN rd.Net ELSE 0 END) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv 
GROUP BY inv.DocNo,inv.DocDate,inv.RefNo,inv.CustCode
ORDER BY inv.DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'MAIN_CLITERIA', N'AND,f.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'MAIN_SQL', N'SELECT DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,
ISNULL(AmtCost,0) as TotalCost,
SUM(CASE WHEN IsCredit=1 THEN BNet ELSE 0 END) as TotalAdvance,
SUM(CASE WHEN IsCredit=0 THEN BNet ELSE 0 END) as TotalCharge,
SUM(AmtCredit) as TotalPrepaid,
SUM(ReceiptNet) as TotalReceived,
SUM(Balance) as TotalBalance,
SUM(ReceiptNet+AmtCredit)- SUM(CASE WHEN IsCredit=1 THEN BNet ELSE 0 END)-ISNULL(AmtCost,0) as TotalProfit
FROM (
	select f.BranchCode,f.DocNo,f.DocDate as InvDate, f.CustCode,f.CustBranch,c.JNo,c.DocDate as JobDate ,b.ClrNo,b.ClrDate,c.DeclareNumber,c.InvNo,
	c.DutyDate,c.CloseJobDate,c.CSCode,c.ShippingEmp,c.ManagerCode,c.InvProduct,c.VesselName,c.TotalContainer,e.Title+''''+e.NameThai as CustName,
	f.BillAcceptNo,f.BillIssueDate,f.BillAcceptDate,f.DueDate,a.SICode,
	d.NameThai as SDescription,d.IsExpense,d.IsCredit,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	h.AmtAdvance,h.AmtCharge,h.AmtVat,h.Amt50Tavi,h.TotalAmt,h.AmtCredit,(h.TotalAmt+h.AmtCredit) as TotalNet,g.ReceiptNet,
	g.ReceiptNo,g.VoucherNo,i.AdjAmt as AdjustAmt,(a.BNet-h.AmtCredit)-ISNULL(g.ReceiptNet,0) as Balance
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	inner join Job_InvoiceHeader f on a.BranchCode=f.BranchCode and a.LinkBillNo=f.DocNo
	left join (
		SELECT dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,Max(dt.ReceiptNo) as ReceiptNo 
		,sum(dt.Net) as ReceiptNet,Max(dt.VoucherNo) as VoucherNo from
		Job_ReceiptDetail dt INNER JOIN Job_ReceiptHeader hd ON dt.BranchCode=hd.BranchCode
		AND dt.ReceiptNo=hd.ReceiptNo WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.VoucherNo<>'''' AND dt.InvoiceNo<>'''' 
		GROUP BY dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo) g 
		ON a.BranchCode=g.BranchCode AND a.LinkBillNo=g.InvoiceNo AND a.LinkItem=g.InvoiceItemNo
	inner join Job_InvoiceDetail h on a.BranchCode=h.BranchCode and a.LinkBillNo=h.DocNo and a.LinkItem=h.ItemNo
	left join (
		SELECT dt.BranchCode,dt.BillingNo as InvoiceNo,dt.BillItemNo as InvoiceItemNo,sum(dt.TotalNet) as AdjAmt FROM Job_CNDNDetail dt inner join Job_CNDNHeader hd on dt.BranchCode=hd.BranchCode
		and dt.DocNo=hd.DocNo WHERE hd.DocStatus<>99 GROUP BY dt.BranchCode,dt.BillingNo,dt.BillItemNo
		) i 
		ON h.BranchCode=i.BranchCode and h.DocNo=i.InvoiceNo and h.ItemNo=i.InvoiceItemNo
	where ISNULL(b.CancelProve,'''')='''' AND ISNULL(f.CancelProve,'''')='''' {0}
) inv 
left join (
	SELECT dt.BranchCode,dt.LinkBillNo,dt.JobNo,SUM(dt.BNet) as AmtCost FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo WHERE ISNULL(hd.CancelProve,'''')=''''
	AND dt.LinkItem=0 AND hd.ClearType=2 GROUP BY dt.BranchCode,dt.LinkBillNo,dt.JobNo
) cost ON inv.BranchCode=cost.BranchCode AND inv.DocNo=cost.LinkBillNo AND inv.JNo=cost.JobNo
GROUP BY DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,AmtCost
ORDER BY CustCode,InvDate,DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'MAIN_CLITERIA', N'AND,c.PaymentDate,c.CustCode,a.ForJNo,c.ReqBy,a.VenCode,c.DocStatus,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'MAIN_SQL', N'SELECT t.PaymentDate,t.AdvNo,t.JobNo,t.ReqBy,t.SDescription,t.PaymentRef,t.DocStatus,t.AdvNet,t.UsedAmount,t.AdvBalance FROM (
Select a.BranchCode,'''' as ClrNo,0 as ItemNo,0 as LinkItem,
a.STCode,a.SICode,a.SDescription,a.VenCode as VenderCode,
a.AdvQty as Qty,b.UnitCharge as UnitCode,a.CurrencyCode,a.ExchangeRate as CurRate,
(CASE WHEN b.IsExpense=0 THEN a.UnitPrice ELSE 0 END) as UnitPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice ELSE 0 END) as FPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice*a.ExchangeRate ELSE 0 END) as BPrice,
q.TotalCharge as QUnitPrice,a.AdvQty*q.ChargeAmt as QFPrice,a.AdvQty*q.ChargeAmt*q.CurrencyRate as QBPrice,
a.UnitPrice as UnitCost,a.AdvQty*a.UnitPrice as FCost,a.AdvQty*a.UnitPrice*a.ExchangeRate as BCost,
a.ChargeVAT,a.Charge50Tavi as Tax50Tavi,a.AdvNo as AdvNO,d.AdvDate,a.ItemNo as AdvItemNo,a.AdvAmount,a.AdvNet,
a.AdvNet-ISNULL(d.TotalCleared,0) as AdvBalance,ISNULL(d.TotalCleared,0) as UsedAmount,
(CASE WHEN ISNULL(q.QNo,'''')='''' THEN 0 ELSE 1 END) as IsQuoItem,
a.IsDuplicate,b.IsExpense,
b.IsLtdAdv50Tavi,(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN '''' ELSE a.PayChqTo END) as Pay50TaviTo,a.Doc50Tavi as NO50Tavi,NULL as Date50Tavi,
(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN a.PayChqTo ELSE '''' END) as VenderBillingNo,'''' as SlipNO,'''' as Remark,
(SELECT STUFF((
	SELECT DISTINCT '','' + Convert(varchar,QtyBegin) + ''-''+convert(varchar,QtyEnd)+''=''+convert(varchar,ChargeAmt)
	FROM Job_QuotationItem WHERE BranchCode=q.BranchCode
	AND QNo=q.QNo AND SICode=q.SICode AND VenderCode =q.VenderCode
	AND UnitCheck=q.UnitCheck AND CalculateType=1
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AirQtyStep,q.CalculateType as StepSub,
a.ForJNo as JobNo,a.IsChargeVAT as VATType,a.VATRate,a.Rate50Tavi as Tax50TaviRate,q.QNo,
c.DocStatus,c.AdvBy,c.EmpCode as ReqBy,c.PaymentDate,c.CustCode,c.PaymentRef
FROM Job_AdvDetail a LEFT JOIN Job_SrvSingle b on a.SICode=b.SICode
INNER JOIN Job_AdvHeader c on a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo 
left join Job_Order j on a.BranchCode=j.BranchCode and a.ForJNo=j.JNo
left join 
(
	select qh.BranchCode,qh.QNo,
	qd.JobType,qd.ShipBy,qd.SeqNo,
	qi.ItemNo,qi.SICode,qi.CalculateType,
	qi.QtyBegin,qi.QtyEnd,qi.UnitCheck,qi.CurrencyCode,
	qi.CurrencyRate,qi.ChargeAmt,qi.Isvat,qi.VatRate,
	qi.VatAmt,qi.IsTax,qi.TaxRate,qi.TaxAmt,
	qi.TotalAmt,qi.TotalCharge,qi.UnitDiscntPerc,qi.UnitDiscntAmt,
	qi.VenderCode,qi.VenderCost,qi.BaseProfit,qi.CommissionPerc,qi.CommissionAmt,
	qi.NetProfit,qi.IsRequired
	from Job_QuotationHeader qh	inner join Job_QuotationDetail qd ON qh.BranchCode=qd.BranchCode and qh.QNo=qd.QNo
	inner join Job_QuotationItem qi	on qd.BranchCode=qi.BranchCode and qd.QNo=qi.QNo and qd.SeqNo=qi.SeqNo 
    where qh.DocStatus=3 
) q
on a.BranchCode=q.BranchCode and b.SICode=q.SICode and ISNULL(a.VenCode,b.DefaultVender)=q.VenderCode 
and b.UnitCharge=q.UnitCheck and a.AdvQty <=q.QtyEnd and a.AdvQty>=q.QtyBegin and q.QNo=j.QNo
left join 
(
	SELECT ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,
    SUM(ISNULL(cd.BNet,0)) as TotalCleared    
	FROM Job_ClearDetail cd INNER JOIN Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode	and cd.ClrNo =ch.ClrNo 	and ch.DocStatus<>99
    INNER JOIN Job_AdvDetail ad on cd.BranchCode=ad.BranchCode and cd.AdvNO=ad.AdvNo and cd.AdvItemNo=ad.ItemNo
    INNER JOIN Job_AdvHeader ah on ad.BranchCode=ah.BranchCode and ad.AdvNo=ah.AdvNo
    WHERE ah.DocStatus<>99 AND ch.DocStatus<>99 
	GROUP BY ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,ad.IsDuplicate,ad.AdvNet
) d
ON a.BranchCode=d.BranchCode and a.AdvNo=d.AdvNo and a.ItemNo=d.ItemNo
WHERE c.DocStatus<90 {0} ) t ORDER BY t.ReqBy,t.PaymentDate,t.AdvNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'MAIN_CLITERIA', N'AND,jd.ConfirmDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'MAIN_SQL', N'SELECT CustCode,CSCode,AgentCode,JNo, DeclareNumber,DocDate, CreateDate, ConfirmDate,
DATEDIFF(d,CreateDate,DocDate) as OpenDays,
DutyDate,
DATEDIFF(d,CreateDate,DutyDate) as DutyDays,
 LastClearDate,
 DATEDIFF(d,DutyDate,LastClearDate) as ClearDays,
  CloseJobDate,
 DATEDIFF(d,DutyDate,CloseJobDate) as CloseDays,
 LastInvDate,
 DATEDIFF(d,LastClearDate,LastInvDate) as InvDays,
 LastRcvDate,
 DATEDIFF(d,LastInvDate,LastRcvDate) as RcvDays
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0} ORDER BY jd.CustCode,jd.JNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'MAIN_CLITERIA', N'AND,dbo.Job_ReceiptHeader.ReceiptDate,dbo.Job_Order.CustCode,dbo.Job_Order.JNo,dbo.Job_Order.ManagerCode,dbo.Job_Order.AgentCode,dbo.Job_Order.JobStatus, dbo.Job_Order.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.ManagerCode,j.CustCode,j.CSCode,j.ReceiptNo,j.SumReceipt,j.TotalComm FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.InvNo, dbo.Job_Order.CustCode, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, SUM(dbo.Job_ReceiptDetail.Net) AS SumReceipt,
dbo.Job_Order.Commission, dbo.Job_ReceiptDetail.InvoiceNo, dbo.Job_ReceiptDetail.ReceiptNo, SUM(dbo.Job_ReceiptDetail.Net) * (dbo.Job_Order.Commission * 0.01) AS TotalComm
FROM dbo.Job_ClearDetail INNER JOIN
 dbo.Job_ClearHeader ON dbo.Job_ClearDetail.BranchCode = dbo.Job_ClearHeader.BranchCode INNER JOIN
 dbo.Job_ReceiptDetail ON dbo.Job_ClearDetail.BranchCode = dbo.Job_ReceiptDetail.BranchCode AND 
 dbo.Job_ClearDetail.LinkItem = dbo.Job_ReceiptDetail.InvoiceItemNo AND dbo.Job_ClearDetail.LinkBillNo = dbo.Job_ReceiptDetail.InvoiceNo INNER JOIN
 dbo.Job_ReceiptHeader ON dbo.Job_ReceiptDetail.BranchCode = dbo.Job_ReceiptHeader.BranchCode AND 
 dbo.Job_ReceiptDetail.ReceiptNo = dbo.Job_ReceiptHeader.ReceiptNo INNER JOIN
 dbo.Job_Order ON dbo.Job_ClearDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_ClearDetail.JobNo = dbo.Job_Order.JNo INNER JOIN
 dbo.Job_InvoiceHeader ON dbo.Job_ReceiptDetail.BranchCode = dbo.Job_InvoiceHeader.BranchCode AND 
 dbo.Job_ReceiptDetail.InvoiceNo = dbo.Job_InvoiceHeader.DocNo
WHERE (ISNULL(dbo.Job_InvoiceHeader.CancelProve, '''') = '''') AND (ISNULL(dbo.Job_ReceiptHeader.ReceiveRef, '''') <> '''') AND (dbo.Job_ClearHeader.DocStatus <> 99)  AND  (dbo.Job_ClearHeader.ClearType=3)
GROUP BY dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.InvNo, dbo.Job_Order.CustCode, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Commission, 
 dbo.Job_ReceiptDetail.InvoiceNo, dbo.Job_ReceiptDetail.ReceiptNo
) j ORDER BY j.JNo,j.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'MAIN_CLITERIA', N'AND,j.DutyDate,j.CustCode,j.JNo,j.CSCode,j.ForwarderCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'MAIN_SQL', N'SELECT CustCode,JNo,DeclareNumber,DutyDate,SumAdvance,SumCost,SumCharge,SumWhTax,Profit FROM (
SELECT j.BranchCode, j.JNo, j.CustCode, j.CustBranch, j.InvNo, j.DutyDate, j.DeclareNumber,j.CSCode,j.ManagerCode,
SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.Tax50Tavi ELSE 0 END) AS SumWhTax,
SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) AS SumCost,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumCharge,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) as Profit
FROM            dbo.Job_ClearHeader AS ch INNER JOIN
                         dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
						 AND ch.ClrNo=cd.ClrNo
                         INNER JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
						 INNER JOIN
                         dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo
WHERE (cd.BNet>0) AND       (ch.DocStatus <> 99) AND (j.JobStatus < 90) {0}
GROUP BY j.BranchCode, j.JNo, j.CustCode, j.CustBranch, j.InvNo, j.DutyDate, j.DeclareNumber,j.CSCode,j.ManagerCode
) as t ORDER BY CustCode,DutyDate,InvNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'MAIN_SQL', N'SELECT j.JNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CSCode,j.InvNo,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0} ) j  ORDER BY j.CSCode DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type] {0}
) j  ORDER BY j.CustCode,j.DutyDate DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'MAIN_CLITERIA', N'WHERE,j.DutyDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.DeclareNumber,j.VesselName,j.LoadDate,j.DutyDate,j.ShippingEmp,j.HAWB,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j ORDER BY j.LoadDate DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'MAIN_SQL', N'SELECT j.JNo,j.DeclareNumber,j.HAWB,j.ConfirmDate,j.ImExDate,j.CloseJobDate,j.JobStatus,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.Consigneecode,j.InvProduct,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j ORDER BY j.JobStatus,j.JNo DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'MAIN_CLITERIA', N'AND,j.ETADate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'MAIN_SQL', N'SELECT j.JNo as ''Job Number'',j.consigneecode as ''Consignee'',j.BookingNo as ''Booking/BL'',j.TotalContainer as ''CONTAINER'',j.VesselName as ''Vessel/Flight'',j.ForwarderCode as ''Agent'',
t.TransMode as ''MODE'',t.CYPlace + ''-'' +t.PackingPlace as ''Transport Route'',j.ETADate as ''ETA Date'',j.ReadyToClearDate as ''Ready Date'',j.ShippingEmp as ''Shipping'',j.DutyDate as ''Inspection Date''
,j.DeclareStatus,j.EstDeliverDate as ''Delivery Date'',t.ReturnDate as ''Demurrage Date'',t.FactoryPlace as ''Delivery Place''
FROM Job_Order j LEFT JOIN Job_Loadinfo t
ON j.BranchCode=t.BranchCode and j.JNo=t.JNo
WHERE j.JobStatus<>99  {0}
ORDER BY j.ETADate')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'MAIN_CLITERIA', N'AND,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'MAIN_SQL', N'SELECT j.JNo,j.InvProduct,j.LoadDate,j.CustCode,j.DeclareNumber,j.HAWB,j.InvNo,j.InvProductQty,j.InvProductUnit,j.ClearPort,j.TotalContainer,j.TotalGW,j.ETDDate,j.ETADate,j.ShippingEmp FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ClearPort,j.LoadDate DESC,j.CustCode,j.InvNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'MAIN_SQL', N'SELECT j.CSCode, j.JNo, j.DocDate as JobDate, j.CustCode,j.CustBranch,
jt.JobTypeName as JobType,sb.ShipByName as ShipBy,c.NameEng as CustEName,
j.BookingNo, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo as CustInvNo,j.TotalContainer,
SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) AS SumCost,
SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumCharge,
SUM(CASE WHEN sv.GroupCode=''ERN'' THEN cd.UsedAmount ELSE 0 END) AS SumDeposit,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) as Profit,
CAST(100*(SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END)
-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END))/(SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END)) as numeric(10,2)) as Margin
FROM dbo.Job_ClearHeader AS ch INNER JOIN
dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
 AND ch.ClrNo=cd.ClrNo
 INNER JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
 INNER JOIN
 dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON j.ShipBy=sb.ShipBy
inner join Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE (cd.BNet>0) AND       (ch.DocStatus <> 99) AND (j.JobStatus < 90) {0}
GROUP BY j.CSCode, j.JNo, j.DocDate , j.CustCode,j.CustBranch,
jt.JobTypeName,sb.ShipByName,c.NameEng,
j.BookingNo, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo,j.TotalContainer')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.ManagerCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'MAIN_SQL', N'SELECT c.TName,j.* FROM (
SELECT j.ManagerCode
,SUM(CASE WHEN j.JobStatus=0 THEN 1 ELSE 0 END) as ''PENDING CONFIRM'',SUM(CASE WHEN j.JobStatus=1 THEN 1 ELSE 0 END) as ''JOB CONFIRMED'',SUM(CASE WHEN j.JobStatus=2 THEN 1 ELSE 0 END) as ''JOB IN PROCESS'',SUM(CASE WHEN j.JobStatus=3 THEN 1 ELSE 0 END) as ''CLEARANCE COMPLETED'',SUM(CASE WHEN j.JobStatus=4 THEN 1 ELSE 0 END) as ''READY FOR BILLING'',SUM(CASE WHEN j.JobStatus=5 THEN 1 ELSE 0 END) as ''PARTIAL BILLING'',SUM(CASE WHEN j.JobStatus=6 THEN 1 ELSE 0 END) as ''BILLING COMPLETED'',SUM(CASE WHEN j.JobStatus=7 THEN 1 ELSE 0 END) as ''PAYMENT COMPLETED'',SUM(CASE WHEN j.JobStatus=98 THEN 1 ELSE 0 END) as ''HOLD FOR CHECKING'',SUM(CASE WHEN j.JobStatus=99 THEN 1 ELSE 0 END) as ''CANCELLED''
FROM Job_Order j {0}
GROUP BY j.ManagerCode) j INNER JOIN Mas_User c ON j.ManagerCode=c.UserID ORDER BY c.TName')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.ShippingEmp,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.DeclareTypeName FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ShipBy,j.CustCode,j.JobType,j.DocDate DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.VesselName,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.ShippingCmd FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ShippingEmp DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.ManagerCode,j.AgentCode, j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'MAIN_SQL', N'SELECT c.TName,j.* FROM (
SELECT j.CSCode
,SUM(CASE WHEN j.JobStatus=0 THEN 1 ELSE 0 END) as ''PENDING CONFIRM'',SUM(CASE WHEN j.JobStatus=1 THEN 1 ELSE 0 END) as ''JOB CONFIRMED'',SUM(CASE WHEN j.JobStatus=2 THEN 1 ELSE 0 END) as ''JOB IN PROCESS'',SUM(CASE WHEN j.JobStatus=3 THEN 1 ELSE 0 END) as ''CLEARANCE COMPLETED'',SUM(CASE WHEN j.JobStatus=4 THEN 1 ELSE 0 END) as ''READY FOR BILLING'',SUM(CASE WHEN j.JobStatus=5 THEN 1 ELSE 0 END) as ''PARTIAL BILLING'',SUM(CASE WHEN j.JobStatus=6 THEN 1 ELSE 0 END) as ''BILLING COMPLETED'',SUM(CASE WHEN j.JobStatus=7 THEN 1 ELSE 0 END) as ''PAYMENT COMPLETED'',SUM(CASE WHEN j.JobStatus=98 THEN 1 ELSE 0 END) as ''HOLD FOR CHECKING'',SUM(CASE WHEN j.JobStatus=99 THEN 1 ELSE 0 END) as ''CANCELLED''
FROM Job_Order j {0}
GROUP BY j.CSCode) j INNER JOIN Mas_User c ON j.CSCode=c.UserID ORDER BY c.TName')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'MAIN_CLITERIA', N'AND,c.DutyDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'MAIN_SQL', N'SELECT JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode,
SUM(AdvCleared) as TotalAdv,
SUM(ChargeCleared) as TotalCharge,
SUM(AdvBilled) as TotalAdvBilled,
SUM(ChargeBilled) as TotalChargeBilled,
SUM(CostCleared) as TotalCost,
SUM(DepositAmt) as TotalEarnest,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit,
SUM(AdvWaitBill) as TotalAdvWaitBill,
SUM(ChargeWaitBill) as TotalChargeWaitBill
FROM (
	select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
	b.ClrNo,b.ClrDate,b.ClearType,b.DocStatus,a.AdvNo,a.AdvItemNo,c.CustCode,c.CustBranch,
	e.Title+'' ''+e.NameThai as CustName,a.SICode,a.SDescription,a.SlipNo,a.Date50Tavi as SlipDate,
	a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
	(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
    (CASE WHEN d.GroupCode=''ERN'' THEN a.UsedAmount ELSE 0 END) as DepositAmt,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as AdvWaitBill,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ChargeWaitBill,
	(CASE WHEN d.IsExpense=1 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as CostWaitBill,
	(CASE WHEN d.IsExpense=1 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as CostBilled,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as AdvBilled,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 AND NOT a.LinkBillNo=''''THEN a.UsedAmount ELSE 0 END) as ChargeBilled
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 {0}
) clr
GROUP BY JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode
ORDER BY CustCode,DutyDate,JNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'MAIN_CLITERIA', N'AND,c.LoadDate,c.NotifyCode,a.JNo,,c.VenderCode,,c.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'MAIN_SQL', N'SELECT t.LoadDate,t.NotifyCode,t.VenderCode,t.JNo,t.BookingNo,t.CTN_NO,t.CTN_SIZE,t.TruckNO,t.TruckType,t.Location,
(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as JobStatus,
t.CountBill,t.CountClear
FROM (
SELECT a.*,ISNULL(b.CountBill,0) as CountBill,ISNULL(b.CountClear,0) as CountClear, 
ISNULL(b.CountBill,0)-ISNULL(b.CountClear,0) as CountBalance,c.LoadDate,c.NotifyCode,c.VenderCode
FROM Job_LoadInfoDetail a LEFT JOIN(
    SELECT h.BranchCode,d.BookingRefNo,d.BookingItemNo,COUNT(*) as CountBill,
    SUM(CASE WHEN ISNULL(d.ClrReFNo,'''')<>'''' THEN 1 ELSE 0 END) as CountClear
    FROM Job_PaymentDetail d INNER JOIN Job_PaymentHeader h 
    ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
    WHERE ISNULL(h.CancelProve,'''')='''' GROUP BY h.BranchCode,d.BookingRefNo,d.BookingItemNo
) b ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingRefNo AND a.ItemNo=b.BookingItemNo
 INNER JOIN Job_LoadInfo c ON a.BranchCode=c.BranchCode AND a.BookingNo=c.BookingNo
WHERE c.LoadDate IS NOT NULL  {0} ) t ORDER BY t.VenderCode,t.LoadDate')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.ShippingEmp,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.VesselName,j.DeliveryNo FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.JobType,j.CustCode,j.ShipBy,j.DocDate DESC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'MAIN_CLITERIA', N'AND,jd.CreateDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'MAIN_SQL', N'SELECT CustCode as ''Customer'',CSCode as ''CS'',AgentCode as Vender,JNo as ''Job Number'', DeclareNumber as ''Customs Declare#'',
DocDate as ''Job Date'', CreateDate as ''Creation Date'', 
DATEDIFF(d,CreateDate,DocDate) as OpenDays,
DutyDate as ''Customs Inspection Date'',
DATEDIFF(d,CreateDate,DutyDate) as ''Customs Lead Time'',
 LastClearDate as ''Job Clear Date'',
 DATEDIFF(d,DutyDate,LastClearDate) as ''Clear Lead Time'',
  CloseJobDate as ''Job Close Date'',
 DATEDIFF(d,DutyDate,CloseJobDate) as ''Close Lead Time'',
 LastInvDate as ''Invoice Creation Date'',
 DATEDIFF(d,LastClearDate,LastInvDate) as ''Invoice Lead Time'',
 LastRcvDate as ''Receipt Date'',
 DATEDIFF(d,LastInvDate,LastRcvDate) as ''A/R Aging Days''
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0}  ORDER BY jd.CustCode,jd.JNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'MAIN_SQL', N'select j.CustCode as ''Customer'',j.JNo as ''Job Number'',j.DeclareNumber as ''Customs Declare#'',j.InvNo as ''Commercial Invoice#''
,j.CSCode as ''CS'',j.CreateDate as ''Job Creation Date'',j.CloseJobDate as ''Job Close Date'',
ISNULL(a.TotalAdvPay,0) as ''Invoice To Customer-Advance'',
ISNULL(c.TotalService,0) as ''Invoice To Customer-Service'',
ISNULL(c.TotalAdvClear,0) as ''Payment To Vender-Advance'',
ISNULL(c.TotalCost,0) as ''Payment To Vender-Cost'',
ISNULL(c.TotalDeposit,0) as ''Payment To Vender-Deposit'',
ISNULL(c.TotalService,0)-ISNULL(c.TotalCost,0) as ''Profit'',
ISNULL(c.TotalAdvBill,0) as ''Customer Billed-Advance'',
ISNULL(c.TotalServiceBill,0) as ''Customer Billed-Service'',
ISNULL(c.TotalAdvUnBill,0) as ''Customer Unbilled-Advance'',
ISNULL(c.TotalServiceUnBill,0) as ''Customer Unbilled-Service'',
ISNULL(p.TotalVenderBill,0) as ''Exp-Billed'',
ISNULL(p.TotalVenderUnBill,0) as ''Exp-Unbilled'',
ISNULL(p.TotalVenderPaid,0) as ''Exp-Paid''
from Job_Order j
left join (
	select h.BranchCode,d.ForJNo,sum(d.AdvNet) as TotalAdvPay
	from Job_AdvHeader h inner join Job_AdvDetail d
	on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
	where h.DocStatus>=3 AND h.DocStatus<99
	group by h.BranchCode,d.ForJNo
) a on j.BranchCode=a.BranchCode and j.JNo=a.ForJNo
left join (
	select h.BranchCode,d.JobNo,sum(CASE WHEN h.ClearType=1 THEN d.BNet ELSE 0 END) as TotalAdvClear,
	sum(CASE WHEN h.ClearType=2 AND SUBSTRING(d.SICode,1,3)<>''ERN'' THEN d.BNet ELSE 0 END) as TotalCost,
	sum(CASE WHEN h.ClearType=2 AND SUBSTRING(d.SICode,1,3)=''ERN'' THEN d.BNet ELSE 0 END) as TotalDeposit,
	sum(CASE WHEN h.ClearType=3 THEN d.BNet ELSE 0 END) as TotalService,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalAdvBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalServiceBill,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalAdvUnBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalServiceUnBill
	from Job_ClearHeader h inner join Job_ClearDetail d
	on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
	where h.DocStatus>=1 AND h.DocStatus<99
	group by h.BranchCode,d.JobNo	
) c ON j.BranchCode=c.BranchCode AND j.JNo=c.JobNo
left join (
	select h.BranchCode,d.ForJNo,
	sum(CASE WHEN ISNULL(h.PaymentBy,'''')<>'''' THEN d.Total ELSE 0 END) as TotalVenderPaid,
	sum(CASE WHEN ISNULL(h.PaymentBy,'''')='''' AND ISNULL(h.PoNo,'''')<>'''' THEN d.Total ELSE 0 END) as TotalVenderBill,
	sum(CASE WHEN ISNULL(h.PaymentBy,'''')='''' AND ISNULL(h.PoNo,'''')=''''THEN d.Total ELSE 0 END) as TotalVenderUnBill
	from Job_PaymentHeader h inner join Job_PaymentDetail d
	on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
	inner join Job_SrvSingle s ON d.SICode=s.SICode
	where NOT ISNULL(h.CancelProve,'''')<>''''
	group by h.BranchCode,d.ForJNo
) p ON j.BranchCode=p.BranchCode AND j.JNo=p.ForJNo
WHERE j.JobStatus<>99 {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'MAIN_CLITERIA', N'AND,h.PaymentDate,h.CustCode,d.ForJNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'MAIN_SQL', N'select d.ForJNo as ''Job Number'',h.AdvNo as ''Advance No'',c.LastClrNo as ''Clearing No'',
c.LastClrDate as ''Clearing Date'',c.LastInvNo as ''Invoice No'',c.LastInvDate as ''Invoice Date'',
(CASE WHEN ISNULL(c.LastInvNo,'''')='''' THEN DATEDIFF(DAY,c.LastClrDate,GetDate()) ELSE 0 END) as ''Unbilled Aging Day'',
(CASE WHEN ISNULL(c.LastInvNo,'''')<>'''' THEN DATEDIFF(DAY,c.LastClrDate,c.LastInvDate) ELSE 0 END) as ''Billed Aging Day'',
h.CustCode as ''Customer'',c.LastReceiptNo as ''Receipt No'',c.LastReceiptDate as ''Receipt Date'',
(d.AdvNet) as ''Advance Amount'',
ISNULL(c.ClrNet,0) as ''Actual Spending'',
ISNULL(c.ClrBillAble,0) as ''Billable Amount'',
ISNULL(c.ClrVat,0) as ''VAT'',
ISNULL(c.ClrWht,0) as ''WHT'',
ISNULL(c.ClrBilled,0) as ''Billed Advance'',
ISNULL(c.ClrUnBilled,0) as ''Unbilled Advance''
from Job_AdvHeader h inner join Job_AdvDetail d
on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
left join (
	select a.BranchCode,b.AdvNo,b.AdvItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,Max(a.ClrNo) as LastClrNo,
    sum(CASE WHEN b.LinkItem>0 and a.ClearType<>2 THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrBilled,
	sum(CASE WHEN b.LinkItem=0 and a.ClearType<>2 THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrUnBilled,
    MAX(b.LinkBillNo) as LastInvNo,Max(i.DocDate) as LastInvDate,
	MAX(r.ReceiptNo) as LastReceiptNo,MAX(t.ReceiptDate) as LastReceiptDate,
	sum(CASE WHEN a.ClearType<>2 THEN b.UsedAmount ELSE 0 END) as ClrBillAble,
	sum(CASE WHEN a.ClearType<>2 THEN b.ChargeVAT ELSE 0 END) as ClrVat,
	sum(CASE WHEN a.ClearType<>2 THEN b.Tax50Tavi ELSE 0 END) as ClrWht
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	left join Job_InvoiceHeader i on b.BranchCode=i.BranchCode 
	AND b.LinkBillNo=i.DocNo
    left join Job_ReceiptDetail r on b.BranchCode=r.BranchCode
    AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
    left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
    and r.ReceiptNo=t.ReceiptNo
	where a.DocStatus<>99 and isnull(b.AdvNo,'''')<>'''' AND ISNULL(t.CancelProve,'''')=''''
	group by a.BranchCode,b.AdvNo,b.AdvItemNo
) c
on d.BranchCode=c.BranchCode and d.AdvNo=c.AdvNo and d.ItemNo=c.AdvItemNo
where h.DocStatus>=3 and h.DocStatus<99 {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'MAIN_CLITERIA', N'AND,a.AdvDate,,,a.EmpCode,,,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'MAIN_SQL', N'select b.NameEng as ''Customer Name'',b.CreditLimit as ''Advanced Credit Term'',b.DutyLimit as ''Advanced Credit Limit'',
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END) as ''Advance Requested'',
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END) as ''Advance Paid'',
SUM(ISNULL(c.AdvUsed,0)) as ''Paid+Cleared Advance'',
SUM(ISNULL(c.AdvBilled,0)) as ''Billed To Customer'',
SUM(ISNULL(c.AdvUnbill,0)) as ''Unbilled Advance'',
SUM(ISNULL(c.AdvCost,0)) as ''Advance Cost'',
SUM(ISNULL(c.AdvReceive,0)) as ''Customer Payment'',
(CASE WHEN b.DutyLimit>0 THEN b.DutyLimit
-
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END)
-
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END)
-
SUM(ISNULL(c.AdvUsed,0)) ELSE 0 END)
+
SUM(ISNULL(c.AdvReceive,0))
  as ''Net Avaiable Balance''
from Job_AdvHeader a LEFT JOIN Mas_Company b
ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
left join (
	select h.BranchCode,d.AdvNo,SUM(d.BNet) as AdvUsed,
	SUM(CASE WHEN d.LinkItem>0 AND h.ClearType<>''2'' THEN d.BNet ELSE 0 END) as AdvBilled,
	SUM(CASE WHEN d.LinkItem=0 AND h.ClearType<>''2'' THEN d.BNet ELSE 0 END) as AdvUnbill,
	SUM(CASE WHEN h.ClearType=''2'' THEN d.BNet ELSE 0 END) as AdvCost,
	SUM(CASE WHEN h.ClearType=''2'' THEN 0 ELSE ISNULL(r.Net,0) END) as AdvReceive
	from Job_ClearHeader h
	inner join Job_ClearDetail d ON h.BranchCode=d.BranchCode
	and h.ClrNo=d.ClrNo
	left join Job_ReceiptDetail r on d.BranchCode=r.BranchCode 
	and d.LinkBillNo=r.InvoiceNo AND d.LinkItem=r.InvoiceItemNo
	left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
	and r.ReceiptNo=t.ReceiptNo
	where h.DocStatus<>99 AND ISNULL(t.CancelProve,'''')=''''
	group by h.BranchCode,d.AdvNo
) c
ON a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo
WHERE a.DocStatus<>99 {0}
group by b.NameEng,b.CreditLimit,b.DutyLimit')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,b.EmpCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'MAIN_SQL', N'select c.JNo as ''Job Number'',a.AdvNo as ''Advance No'',b.ClrNo as ''Clearing No'',b.ClrDate as ''Clearing Date'',c.CustCode as ''Customer'',
b.CTN_NO as ''Container Number'',a.VenderCode as ''Vender'',
a.SlipNO as ''Receipt#'',a.Date50Tavi as ''Receipt Date'',a.UsedAmount as ''Container Deposit'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Addition Expenses'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Deposit Return'',
a.LinkBillNo as ''V/Receipt#, APLL Inv#'',v.VoucherDate as ''Deposit Received Date''
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
	where ISNULL(b.CancelProve,'''')='''' AND d.GroupCode=''ERN'' AND a.UsedAmount>0 {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,cd.JobNo,ih.EmpCode,cd.VenderCode,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'MAIN_SQL', N'select ih.CustCode as ''Customer'',id.DocNo as ''Invoice No'',cd.JobNo as ''Job Number'',ih.DocDate as ''Invoice Date'', cd.SDescription as ''Description'',
(CASE WHEN ch.ClearType=1 THEN ''ADV'' ELSE (CASE WHEN ch.ClearType=3 THEN ''SERV'' ELSE ''COST'' END) END) as ''Type'',
id.Amt as ''Amount'',id.AmtVat as ''VAT'',id.AmtCredit as ''Prepaid'' ,id.Amt50Tavi as ''WHT'',id.TotalAmt as''Total Amount'',
0 as ''CN,DN Amount'',id.AmtCharge as ''Advance Amount'',id.AmtCharge as ''SVC Amount'',ISNULL(rd.ReceiptNet,0) as ''Payment Received'',
ISNULl(rd.LastRcvNo,'''') as ''Receipt No'',rd.LastRcvDate as ''Receipt Date''
from Job_InvoiceDetail id left join Job_ClearDetail cd
on id.BranchCode=cd.BranchCode and id.DocNo=cd.LinkBillNo
and id.ItemNo=cd.LinkItem
left join Job_ClearHeader ch on cd.BranchCode=ch.BranchCode
and cd.ClrNo=ch.ClrNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
left join (
	SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,sum(d.Net) as ReceiptNet
	,Max(h.ReceiptNo) as LastRcvNo,Max(h.ReceiptDate) as LastRcvDate
	FROM Job_ReceiptDetail d inner join Job_ReceiptHeader h
	on d.BranchCode=h.BranchCode and d.ReceiptNo=h.ReceiptNo
	where NOT ISNULL(h.CancelProve,'''')<>''''
	group by d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
)rd on id.BranchCode=rd.BranchCode and id.DocNo=rd.InvoiceNo
and id.ItemNo=rd.InvoiceItemNo
where NOT ISNULL(ih.CancelProve,'''')<>'''' AND ISNULL(ch.DocStatus,0)<>99 {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'MAIN_CLITERIA', N'AND,h.DocDate,j.CustCode,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'MAIN_SQL', N'SELECT h.DocNo as ''Reference#'',d.ForJNo as ''Job Number'', h.DocDate as ''Creation Date'',
v.TName as ''Vender'',h.RefNo as ''Container No'',d.SDescription as ''Expense'',
(CASE WHEN s.IsExpense=1 THEN ''COST'' ELSE ''ADV'' END) as ''Type'',
d.Amt as ''Amount'', d.AmtVAT as ''VAT'', d.AmtWHT as ''WHT'',
(CASE WHEN ISNULL(h.PaymentBy,'''')<>'''' THEN d.Total ELSE 0 END) as ''BILLED'',
(CASE WHEN ISNULL(h.PaymentBy,'''')='''' THEN d.Total ELSE 0 END) as ''UNBILLED'',
h.PoNo as ''Vender Inv#'',j.CustCode as ''Customer''
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'MAIN_CLITERIA', N'AND,h.DocDate,j.CustCode,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'MAIN_SQL', N'SELECT h.DocNo as ''Reference#'', h.DocDate as ''Creation Date'',
v.TName as ''Vender'',h.RefNo as ''Container No'',d.SDescription as ''Expense'',
(CASE WHEN s.IsExpense=1 THEN ''COST'' ELSE ''ADV'' END) as ''Type'',
d.Amt as ''Amount'', d.AmtVAT as ''VAT'', d.AmtWHT as ''WHT'',
d.Total as ''Total'',d.ForJNo as ''Job Number'',j.CustCode as ''Customer''
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' AND ISNULL(h.PoNo,'''')='''' {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,c.CSCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'MAIN_SQL', N'select c.JNo as ''Job Number'',d.NameThai as ''Description'',a.AdvNo as ''Advance No'',
b.ClrNo as ''Clearing No'',b.ClrDate as ''Clearing date'',c.CustCode as ''Customer'',r.ReceiptNo as ''Receipt No'',r.ReceiptDate as ''Receipt Date'',
a.UsedAmount as ''Amount'',a.ChargeVAT as ''VAT Amount'',a.Tax50Tavi as ''WHT Amount'',(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Invoice Billed'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Invoice Unbilled'',a.LinkBillNo as ''Invoice No'',
i.DocDate as ''Invoice Date'',
(CASE WHEN b.ClearType=1 THEN ''ADV'' ELSE (CASE WHEN b.ClearType=2 THEN ''COST'' ELSE ''SERV'' END) END) as ''Type''
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_InvoiceHeader i on a.BranchCode=i.BranchCode and a.LinkBillNo=i.DocNo
	left join (
		SELECT hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,MAX(hd.ReceiptDate) as ReceiptDate,MAX(hd.ReceiptNo) as ReceiptNo
		FROM Job_ReceiptHeader hd INNER JOIN Job_ReceiptDetail dt
		ON hd.BranchCode=dt.BranchCode AND hd.ReceiptNo=dt.ReceiptNo
		WHERE ISNULL(hd.CancelProve,'''')=''''
		GROUP BY hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo
	) r on a.BranchCode=r.BranchCode and a.LinkBillNo=r.InvoiceNo AND a.LinkItem=r.InvoiceItemNo
	where ISNULL(b.CancelProve,'''')='''' {0}')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'MAIN_SQL', N'SELECT 
t.CustEName as ''Customer'',t.TaxNumber,(CASE WHEN t.Branch=0 THEN ''HEAD OFFICE'' ELSE t.Branch END) as Branch,
t.ReceiptDate as ''Date'',t.ReceiptNo,t.TotalTransport as ''Transport'',t.TotalService as ''Service'',
t.TotalVat as ''Vat'',t.TotalAdvance as ''Advance'',t.TotalTransport+t.TotalService+t.TotalVat+t.TotalAdvance as ''Amt.Baht''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'MAIN_SQL', N'SELECT 
t.ReceiptDate as ''Date'',t.ReceiptNo,t.CustEName as ''Customer'',t.TaxNumber,
(CASE WHEN t.Branch=0 THEN ''HEAD OFFICE'' ELSE t.Branch END) as Branch,t.TotalWhtax as ''WHD Tax''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'MAIN_CLITERIA', N'WHERE,t.BookingDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.BookingDate,t.TotalContainer,t.TargetYardDate as PickUpTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t {0}  ORDER BY t.BookingDate,t.JNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'MAIN_CLITERIA', N'AND,t.TargetYardDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.ETDDate,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t WHERE t.JobType=2 AND t.JobStatus<>99 {0} ORDER BY t.ETDDate,t.JNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'MAIN_CLITERIA', N'AND,t.TargetYardDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.ETADate,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t WHERE t.JobType=1 AND t.JobStatus<>99 {0} ORDER BY t.ETADate,t.JNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'MAIN_CLITERIA', N'WHERE,VoucherDate,CustCode,,RecUser,,,BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'MAIN_SQL', N'SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType=''P'' AND (a.CashAmount+a.ChqAmount)>0 
 ) t {0} ORDER BY VoucherDate,ControlNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
 WHERE rh.TotalVAT=0 {0}) rc ORDER BY rc.ReceiptDate,rc.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode,rd.SICode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
 WHERE rh.TotalVAT=0 {0}) rc ORDER BY rc.SDescription,rc.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,SUM(rc.Amt) as Amt,SUM(rc.Amt50Tavi) as Amt50Tavi,SUM(rc.Net) as AmtNet FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
 WHERE rh.TotalVAT=0 {0}) rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptDate,rc.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'MAIN_CLITERIA', N'WHERE,VoucherDate,CustCode,,RecUser,,,BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'MAIN_SQL', N'SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE a.PRType=''R'' AND (a.CashAmount+a.ChqAmount)>0 
) t {0} ORDER BY VoucherDate,ControlNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'MAIN_CLITERIA', N'WHERE,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'MAIN_SQL', N'SELECT BookCode,VoucherDate,TRemark,PRVoucher,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) {0}
) as t ORDER BY BookCode,VoucherDate,PRVoucher')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.Net,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
 WHERE rh.TotalVAT>0 {0}) rc ORDER BY rc.ReceiptDate,rc.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName as NameThai,rc.InvoiceNo,rc.JobNo,SUM(rc.Amt) as Amt,SUM(rc.AmtVAT) as AmtVAT,SUM(rc.Amt50Tavi) as Amt50Tavi,SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'''')<>'''' THEN 0 ELSE rc.Net END) as TotalReceived FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlSub vd ON rd.BranchCode=vd.BranchCode AND rd.ControlNo=vd.ControlNo AND rd.ControlItemNo=vd.ItemNo
 WHERE rh.TotalVAT>0 {0}) rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName,rc.InvoiceNo,rc.JobNo ORDER BY rc.CustTName,rc.ReceiptDate,rc.ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'MAIN_CLITERIA', N'WHERE,t.ExpenseDate,t.CustCode,t.JobNo,,t.VenCode,,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'MAIN_SQL', N'SELECT ExpenseDate,SlipNo,VenderName,TaxNumber,Branch,ExpenseAmt,ExpenseVAT,CancelReson FROM (
SELECT cd.Date50Tavi as ExpenseDate, cd.SlipNO as SlipNo, v.TName as VenderName, v.TaxNumber, v.BranchCode as Branch, v.VenCode, cd.UsedAmount as ExpenseAmt, cd.ChargeVAT as ExpenseVAT, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.PaymentDate IS NOT NULL) AND (cd.SlipNO <> '''')
UNION
SELECT h.CancelDate, ''*''+cd.SlipNO, v.TName + ''**ยกเลิก**'', v.TaxNumber, v.BranchCode, v.VenCode, 0, 0, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.CancelDate IS NOT NULL) AND (cd.SlipNO <> '''')
) AS t {0} ORDER BY ExpenseDate,SlipNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'MAIN_CLITERIA', N'WHERE,t.ReceiptDate,t.CustCode,,,,,')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'MAIN_SQL', N'SELECT ReceiptDate,ReceiptNo,ServiceType,TaxNumber,Branch,TotalChargeVAT,TotalVAT,TotalChargeNonVAT,CancelReson FROM (
SELECT h.ReceiptDate,h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN h.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
CASE WHEN h.TotalVAT>0 THEN d.TotalVATCharge ELSE 0 END as TotalChargeVAT,
h.TotalVAT,
CASE WHEN h.TotalVAT=0 THEN d.TotalNonVAT ELSE 0 END as TotalChargeNonVAT,
h.TotalCharge+h.TotalVAT as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h inner join (
	SELECT BranchCode,ReceiptNo,
	SUM(CASE WHEN VATRate>0 THEN Amt ELSE 0 END) as TotalVATCharge,
	SUM(CASE WHEN VATRate=0 THEN Amt ELSE 0 END) as TotalNonVAT
	FROM Job_ReceiptDetail 
	GROUP BY BranchCode,ReceiptNo
) d ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.ReceiptType<>''ADV'' AND NOT ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.DocDate,h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
CASE WHEN d.VATAmt <>0 THEN d.DiffAmt ELSE 0 END as TotalChargeVAT,
d.VATAmt,
CASE WHEN d.VATAmt =0 THEN d.DiffAmt ELSE 0 END as TotalChargeNonVAT,
d.DiffAmt+d.VATAmt as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE NOT h.DocStatus<>99
UNION
SELECT h.CancelDate,''*''+h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN h.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVat,
0 as TotalChargeNonVAT,
0 as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.ReceiptType<>''ADV'' AND ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.CancelDate,''*''+h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVAT,
0 as TotalNonVAT,
0 as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.DocStatus<>99
) AS t {0} ORDER BY ReceiptDate,ReceiptNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'MAIN_CLITERIA', N'AND,cd.Date50Tavi,c.CustCode,cd.JobNo,ch.EmpCode,cd.VenderCode,,ch.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'MAIN_SQL', N'SELECT Date50Tavi,NO50Tavi,VenTaxNumber,VenTaxBranch,VenderName,CustTaxNumber,CustName,
(CASE WHEN Tax50TaviRate =1 THEN ''ค่าขนส่ง'' ELSE (CASE WHEN (Tax50TaviRate=1.5 OR Tax50TaviRate=3) THEN ''ค่าบริการ'' ELSE (CASE WHEN Tax50TaviRate =5 THEN ''ค่าเช่า'' ELSE (CASE WHEN Tax50TaviRate =2 THEN ''ค่าโฆษณา'' ELSE (CASE WHEN Tax50TaviRate =10 THEN ''ออกให้มูลนิธิ/สมาคม'' ELSE ''เงินเดือน'' END) END) END) END) END) as TaxType,
(CASE WHEN CustName Like ''%จำกัด%'' THEN ''ภงด53'' ELSE ''ภงด3'' END) as TaxForm,
(CASE WHEN IsLtdAdv50Tavi=1 THEN Tax50Tavi ELSE 0 END) as Tax3Tres,
(CASE WHEN IsLtdAdv50Tavi=0 THEN Tax50Tavi ELSE 0 END) as TaxNot3Tres,
SlipNO,UsedAmount,Tax50TaviRate
FROM (
SELECT cd.Date50Tavi, cd.NO50Tavi, v.VenCode, v.TaxNumber AS VenTaxNumber, v.BranchCode AS VenTaxBranch, v.TName AS VenderName, c.CustCode, 
    c.TaxNumber AS CustTaxNumber, c.Branch AS CustTaxBranch, c.NameThai AS CustName, cd.SICode, cd.SDescription, cd.UsedAmount, cd.Tax50TaviRate, 
    cd.Tax50Tavi, cd.IsLtdAdv50Tavi, cd.SlipNO
FROM     dbo.Job_ClearDetail AS cd INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch INNER JOIN
    dbo.Mas_Vender AS v ON cd.VenderCode = v.VenCode
WHERE (cd.Tax50Tavi > 0) AND ch.DocStatus<>99 {0}
) as t ORDER BY 9,1,2')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'MAIN_CLITERIA', N'WHERE,a.PayDate,c.CustCode,a.JNo,a.UpdateBy,a.TaxNumber3,a.FormType,a.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'MAIN_SQL', N'SELECT FormTypeName,TaxLawName,TaxNumber1 as TaxNumber,Branch1 as Branch,NameThai as TaxBy,
Year(a.PayDate) as TaxYear,Month(a.PayDate)  as TaxMonth,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayAmount END) as ServiceAmount,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayTax END) as TaxService, 
SUM(CASE WHEN a.PayRate<>1 THEN 0 ELSE a.PayAmount END) as TranAmount,
SUM(CASE WHEN a.PayRate<>1 THEN 0 ELSE a.PayTax END) as TaxTransport
FROM
(
    SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
    d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
    j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
    (CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
    (CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
    FROM dbo.Job_WHTax h INNER JOIN dbo.Job_WHTaxDetail d
    ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
    LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
    AND d.JNo=j.JNo 
    LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
) a LEFT JOIN dbo.Mas_Company c ON a.TaxNumber1=c.TaxNumber 
{0}
GROUP BY FormTypeName,TaxLawName,TaxNumber1,Branch1,Year(a.PayDate),Month(a.PayDate),NameThai
ORDER BY FormTypeName,NameThai,Year(a.PayDate),Month(a.PayDate)')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'MAIN_CLITERIA', N'WHERE,h.DocDate,h.TaxNumber1,h.JNo,h.UpdateBy,h.TaxNumber3,h.FormType,h.BranchCode')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'MAIN_SQL', N'SELECT a.DocDate,a.DocNo,a.TName1 as TaxBy,a.TName3 as TaxFor,a.FormTypeName,a.TaxLawName,a.PayTaxDesc,a.PayRate,a.PayAmount,a.PayTax FROM (
SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
(CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
(CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
AND d.JNo=j.JNo 
LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
{0}
) a order by a.DocDate,a.DocNo')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'BILL', N'yy_____')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'INV', N'yy_____')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'QUO', N'yy____')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING', N'RCP', N'yy_____')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'ADV', N'ADV-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'BILL', N'APLL-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'CLR_ADV', N'CLR-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'CLR_COST', N'CST-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'CLR_SERV', N'SRV-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'EXP', N'ACC-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'INV', N'IVS-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'PAY', N'PAY-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'QUO', N'APLLQ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_ADV', N'REC-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_RCV', N'REC-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_REC', N'REC-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_SRV', N'TAX-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'RECEIVE_TAX', N'TAX-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'RUNNING_FORMAT', N'WHTAX', N'WT-')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'EXP', N'Expenses')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'INC', N'Income')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'STD', N'Standard Services')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'01', N'AIR')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'02', N'SEA')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'03', N'TRUCK')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'04', N'TRAIN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'05', N'PARCEL')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'06', N'PASSENGER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'07', N'19BIS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'08', N'MACHINE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'09', N'CONSIGNMENT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'10', N'LOCAL - CUSTOMS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'11', N'TRANSFER-IN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'12', N'TRANSFER-OUT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'13', N'REFUND-TAX')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'14', N'BOI')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'15', N'RE-EXPORT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'16', N'FORMULA')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'17', N'TAX-RETURN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'18', N'FORM-A')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'19', N'FORM-D')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'20', N'FORM-E')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'21', N'FORM-CO')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'22', N'CHAMBER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'23', N'FORM-AI')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'24', N'FORM-AK')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'25', N'TEXTTILE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'26', N'THAI-AUS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'27', N'JTEPA')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'28', N'MEXICO')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'29', N'ANNZ')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'30', N'REGISTER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'31', N'BANKING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'32', N'LEGALIZE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'33', N'INSURANCE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'34', N'COURIER')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'35', N'MARGETING')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'36', N'FREIGHT')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'37', N'DOCUMENT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'38', N'WAREHOUSE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'39', N'LABOUR')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'40', N'MILK-RUN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'41', N'FREEZONE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'42', N'YARD')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'43', N'SUPPLY-CHAIN')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'44', N'CUSTOMER-SERVICE')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'45', N'OTHERS')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'46', N'AIR-IMP')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'47', N'AIR-EXP')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'48', N'SEA-IMP')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'49', N'SEA-EXP')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'50', N'DOMESTIC')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'01', N'01,02,03,04,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'02', N'01,02,03,04,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'03', N'01,02,03,04,07,08,10,13,14,15,16,17,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'04', N'18,19,20,21,22,23,24,25,26,27,28,29,30,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'05', N'31,32,33,37,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'06', N'30,35,36,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'07', N'09,37,38,39,40,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'08', N'01,02,41,45,46,47,48,49,50')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'99', N'09,10,37,38,40,42,43,44,45')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'01', N'Managing director')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'02', N'Manager')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'03', N'Sales')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'04', N'Customer Services')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'05', N'Shipping')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'06', N'Accounting')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'98', N'Others')
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'99', N'Administrators')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'ADMIN', N'9t;yogm8', N'ADMINISTRATOR', N'ADMINISTRATOR', N'ADMINISTRATOR', NULL, NULL, NULL, NULL, 99, 0, 0, N'11111111111111111', N'', N'', 1, 0, 0, N'', N'', N'TH', N'', N'', N',01,02,03,04,05,06', N',01,02,03,04', N'6')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Anurak', N'Anurak', N'Anurak Malalai', N'Anurak Malalai', N'Manager', NULL, NULL, NULL, NULL, 1, NULL, NULL, N'', N'Anurak_Malalai@apllogistics.com', N'084-4393132', NULL, NULL, NULL, N'VU, TRUYEN', NULL, N'EN', N'', N'', N'', N'', N'6')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Boripat', N'Boripat', N'Boripat Chandraumporn', N'Boripat Chandraumporn', N'Manager', NULL, NULL, NULL, NULL, 6, 0, 0, N'', N'Boripat_Chandraumporn@apllogistics.com', N'084-4393183', 0, 0, 0, N'IVAN CHUA KOK SIONG', N'', N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Douangkamol', N'Douangkamol', N'Douangkamol Rodwanna', N'Doungkamol Rodwanna', N'Admisitrator', NULL, NULL, NULL, NULL, 2, 0, 0, N'', N'Douangkamol_Rodwanna@apllogistics.com', N'', 0, 0, 0, N'THIDARAT', N'', N'EN', N'', N'', N'', N'', N'5')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Kanjana', N'Kanjana', N'Kanjana Poolsawad', N'Kanjana Poolsawad', N'CS', NULL, NULL, NULL, NULL, 4, NULL, NULL, N'', N'Kanjana_Poolsawad@apllogistics.com', N'084-4393164', NULL, NULL, NULL, N'THIDARAT', NULL, N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Katesarirat', N'Katesarirat', N'Katesarirat Suya', N'Katesarirat Suya', N'Supervisor', NULL, NULL, NULL, NULL, 99, 0, 0, NULL, N'Katesarirat_Suya@apllogistics.com', N'084-4393174', 0, 0, 0, N'THIDARAT', NULL, N'EN', NULL, NULL, NULL, NULL, N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Nattapaksorn', N'Nattapaksorn', N'Nattapaksorn', N'Nattapaksorn', N'Supervisor', NULL, NULL, NULL, NULL, 99, 0, 0, NULL, N'Nattapakson_Kanjananivas@apllogistics.com', N'084-4393166', 0, 0, 0, N'BORIPAT', NULL, N'EN', NULL, NULL, NULL, NULL, N'4')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Natthanan', N'Natthanan', N'Natthanan Sopha', N'Natthanan Sopha', N'Cashier', NULL, NULL, NULL, NULL, 6, NULL, NULL, N'', N'Natthanan_Sopha@apllogistics.com', NULL, NULL, NULL, NULL, N'PATCHAREE', NULL, N'EN', N'', N'', N'', N'', N'5')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Navinda', N'Navinda', N'Navinda nakrat', N'Navinda nakrat', N'CS', NULL, NULL, NULL, NULL, 6, 0, 0, N'', N'navinda_nakrat@apllogistics.com', N'081-9195374', 0, 0, 0, N'NATTAPAKSON', N'', N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'NDD', N'NDD', N'N&DD INTERNATIONAL (THAILAND) CO.,LTD. ', N'', N'VENDER', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, N'EN', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Nittamaporn', N'Nittamaporn', N'Nittamaporn Jitjairaj', N'Nittamaporn Jitjairaj', N'Admisitrator', NULL, NULL, NULL, NULL, 6, 0, 0, NULL, N'Nittamaporn_Jitjairaj2@apllogistics.com', NULL, 0, 0, 0, N'TANAGORN', NULL, N'EN', NULL, NULL, NULL, NULL, N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Orapan', N'Orapan', N'Orapan Buranakool', N'Orapan Buranakool', N'Finance AR', NULL, NULL, NULL, NULL, 6, NULL, NULL, N'', N'orapan_buranakool@apllogistics.com', NULL, NULL, NULL, NULL, N'PATCHAREE', NULL, N'EN', N'', N'', N'', N'', N'4')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Patchaneeya', N'Patchaneeya', N'Patchaneeya Yeamsap', N'Patchaneeya Yeamsap', N'CS', NULL, NULL, NULL, NULL, 4, NULL, NULL, N'', N'Patchaneeya_Yeamsap@apllogistics.com', N'098-2460241', NULL, NULL, NULL, N'THIDARAT', NULL, N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Patcharee', N'Patcharee', N'Patcharee Rungrodpattanakul', N'Patcharee Rungrodpattanakul', N'Manager', NULL, NULL, NULL, NULL, 6, NULL, NULL, N'', N'Patcharee_Rungrodpattanakul@apllogistics.com', NULL, NULL, NULL, NULL, N'TANAGORN', NULL, N'EN', N'', N'', N'', N'', N'5')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Raksak', N'Raksak', N'Raksak Sengprayoon', N'Raksak Sengprayoon', N'CS', NULL, NULL, NULL, NULL, 6, 0, 0, N'', N'Raksak_Sengprayoon@apllogistics.com', N'084-4393167', 0, 0, 0, N'NATTAPAKSON', N'', N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'RBI', N'RBI', N'RAJABOVORN INTERNATIONAL 2004 CO.,LTD. ', N'', N'VENDER', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, N'EN', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Sasitorn', N'Sasitorn', N'Sasitorn Boonthaworn', N'Sasitorn Boonthaworn', N'SQ', NULL, NULL, NULL, NULL, 99, NULL, NULL, N'', N'Sasitorn_Boonthaworn@apllogistics.com', N'084-4393183', NULL, NULL, NULL, N'BORIPAT', NULL, N'EN', N'', N'', N'', N'', N'1')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Tanagorn', N'Tanagorn', N'Tanagorn Asavapivat', N'Tanagorn Asavapivat', N'Manager', NULL, NULL, NULL, NULL, 1, NULL, NULL, N'', N'Tanagorn_Asavapivat@apllogistics.com', NULL, NULL, NULL, NULL, N'AILEEN', NULL, N'EN', N'', N'', N'', N'', N'5')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Thannicha', N'Thannicha', N'Thannicha Vaiyapan', N'Thannicha Vaiyapan', N'Finance AR', NULL, NULL, NULL, NULL, 6, NULL, NULL, N'', N'thannicha_vaiyapan@apllogistics.com', NULL, NULL, NULL, NULL, N'PATCHAREE', NULL, N'EN', N'', N'', N'', N'', N'4')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Thanyakan', N'Thanyakan', N'Thanyakan Maneewong', N'Thanyakan Maneewong', N'CS', NULL, NULL, NULL, NULL, 6, 0, 0, N'', N'Thanyakan_Maneewong@apllogistics.com', N'081-8247321', 0, 0, 0, N'NATTAPAKSON', N'', N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Thanyaporn', N'Thanyaporn', N'Thanyaporn Tuantua', N'Thanyaporn Tuantua', N'CS', NULL, NULL, NULL, NULL, 4, 0, 0, NULL, N'thanyaporn_tuantua@apllogistics.com', N'081-9214750', 0, 0, 0, N'KATESARIRAT', NULL, N'EN', NULL, NULL, NULL, NULL, N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Thidarat', N'Thidarat', N'Thidarat Patjaisomboon', N'Thidarat Patjaisomboon', N'Manager', NULL, NULL, NULL, NULL, 99, 0, 0, NULL, N'Thidarat_Patjaisomboon@apllogistics.com', N'081-9055924', 0, 0, 0, N'BORIPAT', NULL, N'EN', NULL, NULL, NULL, NULL, N'4')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'TSL', N'TSL', N'TSL TRANSPORT AND SERVICE LIMITED PARTNERSHIP', N'', N'VENDER', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, N'EN', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'USL', N'USAVE', N'U-SAVE LOGISTICS SERVICES CO.,LTD ', N'', N'VENDER', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, N'EN', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Wannapa', N'Wannapa', N'Wannapa Kahlong', N'Wannapa Kahlong', N'CS', NULL, NULL, NULL, NULL, 4, NULL, NULL, N'', N'Wannapa_Kahlong@apllogistics.com', N'098-2460240', NULL, NULL, NULL, N'THIDARAT', NULL, N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Wanvisa', N'Wanvisa', N'Wanvisa kleebputsa', N'Wanvisa kleebputsa', N'CS', NULL, NULL, NULL, NULL, 6, 0, 0, N'', N'wanvisa_kleebputsa@apllogistics.com', N'081-9159681', 0, 0, 0, N'NATTAPAKSON', N'', N'EN', N'', N'', N'', N'', N'2')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Wichai ', N'Wichai ', N'Wichai Sriphien', N'Wichai Sriphien', N'Manager', NULL, NULL, NULL, NULL, 1, NULL, NULL, N'', N'wichai_sriphien@apllogistics.com', N'081-9277924', NULL, NULL, NULL, N'PHIL DEARTH ', NULL, N'EN', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'Wutthichai', N'Wutthichai', N'Wutthichai Chinual', N'Wutthichai Chinual', N'CS', NULL, NULL, NULL, NULL, 4, 0, 0, NULL, N'wutthichai_chainual@apllogistics.com', N'092-2715526', 0, 0, 0, N'KATESARIRAT', NULL, N'EN', NULL, NULL, NULL, NULL, N'2')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Invoice', N'MR')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Anurak', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Boripat', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Douangkamol', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Doungkamol', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Kanjana', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Katesarirat', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nattapaksorn', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Natthanan', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_REP', N'Export', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Navinda', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'NDD', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'NDD', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'NDD', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'NDD', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Nittamaporn', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Orapan', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'', N'', N'')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patchaneeya', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CLR', N'Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Patcharee', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Raksak', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'RBI', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'RBI', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'RBI', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'RBI', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Sasitorn', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Tanagorn', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thannicha', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyakan', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thanyaporn', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Province', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_REP', N'Reports', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Thidarat', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'TSL', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'TSL', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'TSL', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'TSL', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USAVE', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USAVE', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USAVE', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USAVE', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USL', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USL', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USL', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'USL', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wannapa', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADM', N'FileManager', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADM', N'Role', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_ADV', N'Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Bank', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Branch', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Country', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Currency', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Customers', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'InterPort', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Province', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Users', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Venders', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_MAS', N'Vessel', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_REP', N'Dashboard', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_REP', N'Export', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_REP', N'Import', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_REP', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_REP', N'Reports', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wanvisa', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ACC', N'Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ADV', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_CLR', N'Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_CLR', N'Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_CLR', N'Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wichai ', N'MODULE_SALES', N'Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_ACC', N'WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_ADV', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_CLR', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_CS', N'CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_CS', N'Index', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_CS', N'ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_CS', N'Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_CS', N'TruckApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'Wutthichai', N'MODULE_MAS', N'TransportRoute', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'ACC', N'Accounting Staff', 5)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'ACC-MGR', N'Accounting Manager', 5)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CS', N'Customer Services Staff', 2)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CS-MGR', N'Customer Services Manager', 2)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'FIN', N'Finance Staff', 4)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'FIN-MGR', N'Finance Manager', 4)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'IT', N'IT Department', 6)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'MGT', N'Marketing Staff', 1)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'MGT-MGR', N'Marketing Manager', 1)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'SP', N'Shipping Staff', 3)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'SP-MGR', N'Shipping Manager', 3)
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'VEND', N'Vender', 2)
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Douangkamol')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Doungkamol')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Natthanan')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Nittamaporn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Patcharee')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Raksak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Thanyakan')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Anurak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Boripat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Patcharee')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Tanagorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'Wichai ')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Douangkamol')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Kanjana')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Navinda')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Patchaneeya')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Patcharee')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Raksak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Thanyakan')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Thanyaporn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Wannapa')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Wanvisa')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'Wutthichai')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Anurak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Boripat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Douangkamol')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Patcharee')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Raksak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'Wichai ')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Douangkamol')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Doungkamol')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Natthanan')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Nittamaporn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Orapan')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Patcharee')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Raksak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Thannicha')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Boripat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Orapan')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Patcharee')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Thannicha')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'Wichai ')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'Anurak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'Katesarirat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'Nattapaksorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'Sasitorn')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'Thidarat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'Anurak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'Boripat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'Wichai ')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'ADMIN')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'Anurak')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'Boripat')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'Wichai ')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'VEND', N'NDD')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'VEND', N'RBI')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'VEND', N'TSL')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'VEND', N'USAVE')
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'VEND', N'USL')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Adjustment', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Approve', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Cheque', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/CreditNote', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/GLNote', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Payment', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/PettyCash', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Receipt', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/RecvInv', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/TaxInvoice', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CLR/Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CLR/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CLR/Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/ShowJob', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/Transport', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/AccountCode', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Adjustment', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/CreditNote', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/GLNote', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Voucher', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_CS/Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_MAS/BookAccount', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_MAS/BudgetPolicy', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ACC/WHTax', N'MIREP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ADV/CreditAdv', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ADV/EstimateCost', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ADV/Index', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CLR/Index', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/ShowJob', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/Transport', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/TruckApprove', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_MAS/TransportRoute', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ACC/Costing', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CLR/Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CLR/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CS/ShowJob', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CS/Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Billing', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Cheque', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Costing', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Expense', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/GenerateInv', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Invoice', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Payment', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/PettyCash', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Receipt', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/RecvInv', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/TaxInvoice', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Voucher', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/WHTax', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/Payment', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CLR/Earnest', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CLR/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CLR/Receive', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/CreateJob', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/ShowJob', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/Transport', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Billing', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Cheque', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Costing', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Expense', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/GenerateInv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Invoice', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/PettyCash', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Receipt', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/RecvInv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/TaxInvoice', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Voucher', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_CLR/Earnest', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_CLR/Receive', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_CS/Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ACC/AccountCode', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ACC/Expense', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ACC/Payment', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ADM/FileManager', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ADM/Role', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ADM/SQLAdmin', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Bank', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/BookAccount', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Branch', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/BudgetPolicy', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Country', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Currency', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Customers', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/CustomsPort', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/CustomsUnit', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/DeclareType', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Index', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/InterPort', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Province', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/ServiceCode', N'MR')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/ServiceGroup', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/ServUnit', N'MIRE')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/UserAuth', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Users', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Venders', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Vessel', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Dashboard', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Export', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Import', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Index', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Reports', N'M')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_SALES/QuoApprove', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_SALES/Quotation', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT', N'MODULE_ADV/CreditAdv', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT', N'MODULE_ADV/EstimateCost', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT', N'MODULE_SALES/Quotation', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_ADV/CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_ADV/EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_MAS/BudgetPolicy', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_MAS/CompanyContact', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_SALES/QuoApprove', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_SALES/Quotation', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_ADV/CreditAdv', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_ADV/EstimateCost', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_ADV/Index', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CLR/Index', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/ShowJob', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/Transport', N'MEIRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/TruckApprove', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_MAS/TransportRoute', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ACC/Costing', N'MRP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/CreditAdv', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/EstimateCost', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_CLR/Approve', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_CLR/Index', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_CS/Transport', N'MEIRDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_ACC/Expense', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_CS/Transport', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_CS/TruckApprove', N'MIREDP')
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'VEND', N'MODULE_MAS/TransportRoute', N'MIREDP')
GO
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'AGIC', N'0', N'0105545098690', N'บริษัท', N'A&G INTERNATIONAL CARGO (THAILAND) CO.,LTD.', N'A&G INTERNATIONAL CARGO (THAILAND) CO.,LTD.', N'514/18 REGENT RATCHADA, SOI RAMKHAMHAENG 39 (THEPLELA 1) RANKHAMHAENG ROAD,', N' WANGTHONGLANG, WANGTHONGLANG, BANGKOK 10310', N'514/18 REGENT RATCHADA, SOI RAMKHAMHAENG 39 (THEPLELA 1) RANKHAMHAENG ROAD,', N' WANGTHONGLANG, WANGTHONGLANG, BANGKOK 10310', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'AGILI', N'0', N'0105532011396', N'บริษัท', N'AGILITY CO., LTD', N'AGILITY CO., LTD', N'136 ROMKLAO ROAD, KLONGSAMPRAVEJ', N' LADKRABANG, BANGKOK 10520', N'136 ROMKLAO ROAD, KLONGSAMPRAVEJ', N' LADKRABANG, BANGKOK 10520', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'AIRPA', N'0', N'0105538069540', N'บริษัท', N'AIR PACIFIC LIMITED', N'AIR PACIFIC LIMITED', N'TAC HOUSE, 5TH FLOOR, 1 SOI RUAM RUDI, PLOENCHIT ROAD,', N'KWANG LUPINI, KHET PATUMWAN, BANGKOK 10330', N'TAC HOUSE, 5TH FLOOR, 1 SOI RUAM RUDI, PLOENCHIT ROAD,', N'KWANG LUPINI, KHET PATUMWAN, BANGKOK 10330', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'AIRTI', N'0', N'0105529004546', N'บริษัท', N'AIR TIGER EXPRESS (THAILAND) CO., LTD.', N'AIR TIGER EXPRESS (THAILAND) CO., LTD.', N'524/22 SOI PREYANUCH (SOI 19) RAMA 9 ROAD', N'KWANG BANGKAPI, KHET HUAYKWANG, BANGKOK 10310 THAILAND', N'524/22 SOI PREYANUCH (SOI 19) RAMA 9 ROAD', N'KWANG BANGKAPI, KHET HUAYKWANG, BANGKOK 10310 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'ANANT', N'0', N'0103552005187', N'บริษัท', N'ANANTA TRANSPORTATION LTD.,PART ', N'ANANTA TRANSPORTATION LTD.,PART ', N'199 SOI ONNUT 30, SUKHUMVIT 77 RD.,', N'SUANLUANG, SUANLUANG,77 RD., SUANLUANGPAN ROAD,SILOM,BANGRAK,', N'199 SOI ONNUT 30, SUKHUMVIT 77 RD.,', N'SUANLUANG, SUANLUANG,77 RD., SUANLUANGPAN ROAD,SILOM,BANGRAK,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'ANL', N'0', N'0993000050690', N'บริษัท', N'ANL SINGAPORE PTE LTD CO CMA CGM (THAILAND) LTD', N'ANL SINGAPORE PTE LTD CO CMA CGM (THAILAND) LTD', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'APLL', N'0000', N'0105542016277', N'บริษัท', N'APL LOGISTICS SVCS (THAILAND), LTD.', N'APL LOGISTICS SVCS (THAILAND), LTD.', N'3195/8  VIBULTHANI 3RD FLOOR RAMA IV ROAD', N'KLONGTON KLONGTOEY BKK 10110', N'3195/8  VIBULTHANI 3RD FLOOR RAMA IV ROAD', N'KLONGTON KLONGTOEY BKK 10110', N'0-20809000', N'0-20809009', N'', N'', N'', N'', N'', N'', N'', N'', N'0-20809009')
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'BBL', N'0', N'0105537103159', N'บริษัท', N'BANGKOK BRIGHT LOGISTICS CO.,LTD. ', N'BANGKOK BRIGHT LOGISTICS CO.,LTD. ', N'1571 MOOBAN SUPALAI VILLE', N'SUKHUMVIT 105 RD., BANGNABANGNA', N'1571 MOOBAN SUPALAI VILLE', N'SUKHUMVIT 105 RD., BANGNABANGNA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'BEELO', N'0', N'0105547162727', N'บริษัท', N'BEE LOGISTICS (THAILAND) COMPANY LIMITED', N'BEE LOGISTICS (THAILAND) COMPANY LIMITED', N' 2/22 IYARA TOWER,6TH ROOM NO.601,CHAN ROAD,THUNGWATDON,SATHORN, BANGKOK 10120', N'THUNGWATDON,SATHORN, BANGKOK 10120', N' 2/22 IYARA TOWER,6TH ROOM NO.601,CHAN ROAD,THUNGWATDON,SATHORN, BANGKOK 10120', N'THUNGWATDON,SATHORN, BANGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'BENLI', N'0', N'0105517012891', N'บริษัท', N'BEN LINE AGENCIES (THAILAND) LTD.', N'BEN LINE AGENCIES (THAILAND) LTD.', N'139 SETHIWAN TOWER,14TH FLOOR,', N'PAN ROAD,SILOM,BANGRAK,', N'139 SETHIWAN TOWER,14TH FLOOR,', N'PAN ROAD,SILOM,BANGRAK,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'BETTE', N'0', N'0105540094246', N'บริษัท', N'BETTER FREIGHT  AND TRANSPORT CO., LTD.', N'BETTER FREIGHT  AND TRANSPORT CO., LTD.', N'116/89 SSP TOWER 2, 23RD FL.,', N' NA RANONG RD, KONGTOEY, BANGKOK 10110', N'116/89 SSP TOWER 2, 23RD FL.,', N' NA RANONG RD, KONGTOEY, BANGKOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'BLUE', N'0', N'0105546044640', N'บริษัท', N'BLUE WHALE LINE CO.,LTD.', N'BLUE WHALE LINE CO.,LTD.', N'98/32 ROMKLAO ROAD', N' KLONGSAMPRAVET LAD KRABANG BANGKOK 10520', N'98/32 ROMKLAO ROAD', N' KLONGSAMPRAVET LAD KRABANG BANGKOK 10520', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'BSTAR', N'0', N'0103553018304', N'บริษัท', N'BANGKOK STAR LOGISTICS LTD., PART. ', N'BANGKOK STAR LOGISTICS LTD., PART. ', N'1003/15 SOI PHETKASEM 106', N'NONGKHANGPHLUNONGKHAEM', N'1003/15 SOI PHETKASEM 106', N'NONGKHANGPHLUNONGKHAEM', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CAPAR', N'0', N'0105551031259', N'บริษัท', N'CARGO-PARTNER LOGISTICS LTD.', N'CARGO-PARTNER LOGISTICS LTD.', N'1011 SUPALAI GRAND TOWER 9TH FLOOR, UNIT NO.06-07 RAMA 3 ROAD,', N' CHONGNONSEE, YANNAWA 10120 BANGKOK, THAILAND', N'1011 SUPALAI GRAND TOWER 9TH FLOOR, UNIT NO.06-07 RAMA 3 ROAD,', N' CHONGNONSEE, YANNAWA 10120 BANGKOK, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CAWOR', N'0', N'0105559019100', N'บริษัท', N'CARGO WORLD (THAILAND) CO., LTD.', N'CARGO WORLD (THAILAND) CO., LTD.', N'191/1 HUNG SENG HUAT BLDG., 10TH FL. RAMA III RD', N'BANGKHORLAEM, BANGKHORLAEM, BANGKOK 10120 THAILAND', N'191/1 HUNG SENG HUAT BLDG., 10TH FL. RAMA III RD', N'BANGKHORLAEM, BANGKHORLAEM, BANGKOK 10120 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CCJ', N'0', N'0115558022891', N'บริษัท', N'C.C. AND J SERVICE CO., LTD. ', N'C.C. AND J SERVICE CO., LTD. ', N'250/124 SAMRONG , PRAPRADANG', N'', N'250/124 SAMRONG , PRAPRADANG', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CEVA ', N'0', N'0105540022059', N'บริษัท', N'CEVA FREIGHT (THAILAND) LTD ', N'CEVA FREIGHT (THAILAND) LTD ', N'ELECTROLUX BUILDING, 8TH FLOOR, 1', N'1910  NEW PETCHBURI ROAD.BANGKAPI, HUAYKWABG', N'ELECTROLUX BUILDING, 8TH FLOOR, 1', N'1910  NEW PETCHBURI ROAD.BANGKAPI, HUAYKWABG', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CHAOK', N'0', N'0115558017812', N'บริษัท', N'CHAOKHUN DIESEL & TRANS CO.,LTD. ', N'CHAOKHUN DIESEL & TRANS CO.,LTD. ', N'14 ICD Rd. , Klongsampravet , Latkr', N'', N'14 ICD Rd. , Klongsampravet , Latkr', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CHENG', N'0', N'0993000074505', N'บริษัท', N'CHENG LIE NAVIGATION CO.,LTD. C/O CMA CGM (THAILAND) LIMITED (HO)', N'CHENG LIE NAVIGATION CO.,LTD. C/O CMA CGM (THAILAND) LIMITED (HO)', N'14TH FLOOR Q HOUSE LUMPINI 1 SOUTH SATHORN ROAD', N'TUNGMAHAMEK SATHORN BANGKOK/10120 THAILAND', N'14TH FLOOR Q HOUSE LUMPINI 1 SOUTH SATHORN ROAD', N'TUNGMAHAMEK SATHORN BANGKOK/10120 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CHINANAV', N'0', N'0993000089421', N'บริษัท', N'THE CHINA NAVIGATION CO. PTE. LTD. C/O BEN LINE AGENCIES (THAILAND) LTD.', N'THE CHINA NAVIGATION CO. PTE. LTD. C/O BEN LINE AGENCIES (THAILAND) LTD.', N'14TH FL., SETHIWAN TOWER, 139 PAN ROAD, ', N'SILOM, BANGRAK, BANGKOK 10500', N'14TH FL., SETHIWAN TOWER, 139 PAN ROAD, ', N'SILOM, BANGRAK, BANGKOK 10500', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CMA', N'0', N'0993000059395', N'บริษัท', N'CMA CGM (THAILAND) LIMITED. ', N'CMA CGM (THAILAND) LIMITED. ', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CNC_AMER', N'0', N'0993000377141', N'บริษัท', N'AMERICAN PRESIDENT LINES. LTD. C/O CMA CGM (THAILAND) LTD.', N'AMERICAN PRESIDENT LINES. LTD. C/O CMA CGM (THAILAND) LTD.', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CNC_APL', N'0', N'0993000377133', N'บริษัท', N'APL CO PTE LTD C/O CMA CGM (THAILAND) LTD.', N'APL CO PTE LTD C/O CMA CGM (THAILAND) LTD.', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', N'14TH FLOOR, Q HOUSE LUMPINI', N'1 SOUTH SATHORN ROAD., TUNGMAHAMEKSATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CNLOG', N'0', N'0105560135941', N'บริษัท', N'CN LOGISTICS (THAILAND) CO., LTD.', N'CN LOGISTICS (THAILAND) CO., LTD.', N'123/9 NONSEE ROAD,CHONGNONSEE, ', N' YANNAWA, BANGKOK 10120 THAILAND', N'123/9 NONSEE ROAD,CHONGNONSEE, ', N' YANNAWA, BANGKOK 10120 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CONSO', N'0', N'0105549068426', N'บริษัท', N'CONSOL LINK CO., LTD.', N'CONSOL LINK CO., LTD.', N'HANDLE INTER GROUP BUILDING, 1 BANGNA-TRAD SOI 21 (YAEK 11)', N' DEBARATNA ROAD, BANGNA NUEA, BANGNA, BANGKOK 10260, THAILAND', N'HANDLE INTER GROUP BUILDING, 1 BANGNA-TRAD SOI 21 (YAEK 11)', N' DEBARATNA ROAD, BANGNA NUEA, BANGNA, BANGKOK 10260, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'COSCO', N'0', N'0993000042972', N'บริษัท', N'CHINA OCEAN SHIPPING CO.,LTD C/O COSCO SHIPPING LINES (THAILAND) CO.,LTD', N'CHINA OCEAN SHIPPING CO.,LTD C/O COSCO SHIPPING LINES (THAILAND) CO.,LTD', N'319 CHAMCHURI SQUARE BUILDING', N'25TH FLOOR , UNIT 1-8TAMBOL TUNGSUKLAAMPHOR SRIRACHAPHAYATHAI ROAD', N'319 CHAMCHURI SQUARE BUILDING', N'25TH FLOOR , UNIT 1-8TAMBOL TUNGSUKLAAMPHOR SRIRACHAPHAYATHAI ROAD', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CTILOG', N'0', N'0105520010900', N'บริษัท', N'CTI LOGISTICS CO., LTD.', N'CTI LOGISTICS CO., LTD.', N'CTI TOWER, 31ST FLOOR. NO 191/2-5 RATCHADAPISEK ROAD,', N'KLONGTON, KLONGTOEY, BANGKOK 10110', N'CTI TOWER, 31ST FLOOR. NO 191/2-5 RATCHADAPISEK ROAD,', N'KLONGTON, KLONGTOEY, BANGKOK 10110', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'CUSTOMS', N'0', NULL, N'บริษัท', N'THE CUSTOMS DEPARTMENT (SUSPENSION) ', N'THE CUSTOMS DEPARTMENT (SUSPENSION) ', N'NO 1  SOONTHORNKOSA ROAD ,', N'KLONG TOEY ', N'NO 1  SOONTHORNKOSA ROAD ,', N'KLONG TOEY ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'DACHS', N'0', N'0105549033843', N'บริษัท', N'DACHSER (THAILAND) CO., LTD.', N'DACHSER (THAILAND) CO., LTD.', N'1768 THAI SUMMIT TOWER, 31 ST FLOOR, NEW PETCHBURI ROAD', N'BANGKAPI, HUAYKWANG, BANGKOK 10310', N'1768 THAI SUMMIT TOWER, 31 ST FLOOR, NEW PETCHBURI ROAD', N'BANGKAPI, HUAYKWANG, BANGKOK 10310', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'DHLGL', N'0', N'0105527019996', N'บริษัท', N'DHL GLOBAL FORWARDING (THAILAND) LIMITED', N'DHL GLOBAL FORWARDING (THAILAND) LIMITED', N'209 KKP TOWER A 12TH - 12ATH FLOOR', N'SUKHUMVIT 21 ROAD (ASOKE)KLONGTOEY-NUA,WATTANA', N'209 KKP TOWER A 12TH - 12ATH FLOOR', N'SUKHUMVIT 21 ROAD (ASOKE)KLONGTOEY-NUA,WATTANA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'DIGIT', N'0', N'0105544027276', N'บริษัท', N'DIGITAL TRANSPORT SYSTEM CO., LTD.', N'DIGITAL TRANSPORT SYSTEM CO., LTD.', N'555 SSP TOWER 1, 15TH FLOOR, SOI EKAMAI', N'SUKHUMVIT 63 ROAD, KLONG-TAN NUA, WATTANA BANGKOK 10110', N'555 SSP TOWER 1, 15TH FLOOR, SOI EKAMAI', N'SUKHUMVIT 63 ROAD, KLONG-TAN NUA, WATTANA BANGKOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'DWTW', N'0', N'0105558125640', N'บริษัท', N'DWT WORLDWIDE (THAILAND) CO., LTD', N'DWT WORLDWIDE (THAILAND) CO., LTD', N'26/56 TPI TOWR, FL.19, CHAN TAT MAI,KWAENG THUNGMAHAMEK', N'SATHORN BANGKOK 10120 THAILAND', N'26/56 TPI TOWR, FL.19, CHAN TAT MAI,KWAENG THUNGMAHAMEK', N'SATHORN BANGKOK 10120 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'EASTE', N'0', N'0105514004961', N'บริษัท', N'EASTERN MARITIME (THAILAND) LTD.', N'EASTERN MARITIME (THAILAND) LTD.', N'4181/5 RAMA IV ROAD PHRAKANONG KLONG TOEY', N' BANGKOK THAILAND 10110', N'4181/5 RAMA IV ROAD PHRAKANONG KLONG TOEY', N' BANGKOK THAILAND 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'ECU', N'0', N'0105542050815', N'บริษัท', N'ECU WORLDWIDE (THAILAND) CO.,LTD.', N'ECU WORLDWIDE (THAILAND) CO.,LTD.', N'628, 5TH FLOOR, TRIPLE I BUILDING, SOI KLAB CHOM,', N' NONSEE ROAD, CHONGNONSEE, YANNAWA, BANGKOK 10120', N'628, 5TH FLOOR, TRIPLE I BUILDING, SOI KLAB CHOM,', N' NONSEE ROAD, CHONGNONSEE, YANNAWA, BANGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'EDISI', N'0', N'0105541032287', N'บริษัท', N'EDI SIAM CORP.,LTD ', N'EDI SIAM CORP.,LTD ', N'3366/9-10 SOI MANOROM', N'RAMA 4 RD.,KLONG TONKLONG TOEY', N'3366/9-10 SOI MANOROM', N'RAMA 4 RD.,KLONG TONKLONG TOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'EMPIR', N'0', N'0105551043656', N'บริษัท', N'EMPIRE GLOBAL LOGISTICS CO., LTD.', N'EMPIRE GLOBAL LOGISTICS CO., LTD.', N'445/3 PHETCHBURI ROAD,', N'PHAYATHAI,RAJTAVEE, BANGKOK 10400', N'445/3 PHETCHBURI ROAD,', N'PHAYATHAI,RAJTAVEE, BANGKOK 10400', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'EVERG', N'0', N'0105544015421', N'บริษัท', N'EVERGREEN SHIPPING AGENCY (THAILAND) CO. LTD.', N'EVERGREEN SHIPPING AGENCY (THAILAND) CO. LTD.', N'3656/81 24-25TH FLOOR GREEN', N'RAMA IV ROAD,KLONGTON,KLONGTOEY', N'3656/81 24-25TH FLOOR GREEN', N'RAMA IV ROAD,KLONGTON,KLONGTOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'EXPED', N'0', N'0105536136517', N'บริษัท', N'EXPEDITORS(THAILAND)LTD. ', N'EXPEDITORS(THAILAND)LTD. ', N'5TH FL,VORARAT BLDG', N'849 SILOM RD.BANGRAK', N'5TH FL,VORARAT BLDG', N'849 SILOM RD.BANGRAK', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'FRMEY', N'0', N'0105559119406', N'บริษัท', N'FR. MEYER ''S SOHN (THAILAND) LTD.', N'FR. MEYER ''S SOHN (THAILAND) LTD.', N'127/25 PPANJATHANI TOWER 20TH FLOOR, NONSRI ROAD,', N' CHONGNONSRI, YANNAWA 10120 BANGKOK THAILAND', N'127/25 PPANJATHANI TOWER 20TH FLOOR, NONSRI ROAD,', N' CHONGNONSRI, YANNAWA 10120 BANGKOK THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'G3LOG', N'0', N'0105548151010', N'บริษัท', N'G3 GLOGISTICS (THAILAND) CO., LTD.', N'G3 GLOGISTICS (THAILAND) CO., LTD.', N'75/37 RICHMOND BLDG, 12A FL., SUKHUMVIT SOI 26,', N'KLONGTON, KLONGTOEY, BANGKOK 10110', N'75/37 RICHMOND BLDG, 12A FL., SUKHUMVIT SOI 26,', N'KLONGTON, KLONGTOEY, BANGKOK 10110', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'GATEW', N'0', N'0105547115478', N'บริษัท', N'GATEWAY CONTAINER LINE CO., LTD.   HEAD OFFICE', N'GATEWAY CONTAINER LINE CO., LTD.   HEAD OFFICE', N'1000/64-65 TROKWADCHANNAI RAMA3 ROAD', N'BANGKHLO, BANGKHOLAEM, BANGKOK 10120', N'1000/64-65 TROKWADCHANNAI RAMA3 ROAD', N'BANGKHLO, BANGKHOLAEM, BANGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'GDA', N'0', N'0135534000685', N'บริษัท', N'GLOBAL DISTRIBUTION ALLIANCE (THAILAND) CO., LTD.', N'GLOBAL DISTRIBUTION ALLIANCE (THAILAND) CO., LTD.', N'47 SOI SUKCHAI (YAK BAN KLUAY TAI) SUKHUMVIT 42 RD.,', N' PRAKANONG, KONGTOEY, BANKGOK 10110', N'47 SOI SUKCHAI (YAK BAN KLUAY TAI) SUKHUMVIT 42 RD.,', N' PRAKANONG, KONGTOEY, BANKGOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'GLINK', N'0', N'0105558158599', N'บริษัท', N'GRANDLINK LOGISTICS CO.,LTD.', N'GRANDLINK LOGISTICS CO.,LTD.', N'79/345-350 SATHUPRADIT RD.,CHONGNONSEE', N'YANNAWA, BANGKOK 10120 THAILAND.', N'79/345-350 SATHUPRADIT RD.,CHONGNONSEE', N'YANNAWA, BANGKOK 10120 THAILAND.', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HAMBU', N'0', N'0993000275586', N'บริษัท', N'HAMBURG SUDAMERIKANISCHE DAMPFSCHIFFFAHRTS-GESELLSCHAFT KG C/O LINER CLASS CO., LTD.', N'HAMBURG SUDAMERIKANISCHE DAMPFSCHIFFFAHRTS-GESELLSCHAFT KG C/O LINER CLASS CO., LTD.', N'3388/72 SIRINRAT BLDG., 20 TH FL.,RAMA 4 RD.', N'KLONGTON, KONGTOEY, BANGKOK 10110', N'3388/72 SIRINRAT BLDG., 20 TH FL.,RAMA 4 RD.', N'KLONGTON, KONGTOEY, BANGKOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HANDL', N'0', N'0105548031839', N'บริษัท', N'HANDLE INTER CONSOLIDATION CO.,LTD. ', N'HANDLE INTER CONSOLIDATION CO.,LTD. ', N'HANDLE INTER GROUP BUILDING, 1 BANGNA-TRAD SOI 21 (YAEK 11)', N' DEBARATNA ROAD, BANGNA NUEA, BANGNA, BANGKOK 10260, THAILAND', N'HANDLE INTER GROUP BUILDING, 1 BANGNA-TRAD SOI 21 (YAEK 11)', N' DEBARATNA ROAD, BANGNA NUEA, BANGNA, BANGKOK 10260, THAILAND', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HAPAG', N'0', N'0993000275977', N'บริษัท', N'HAPAG-LLOYD (THAILAND) LTD ', N'HAPAG-LLOYD (THAILAND) LTD ', N'PANJATHANI TOWER, 24 TH FLOOR', N'127/29 NONSEE ROAD, CHONGNONSEEYANNAWA', N'PANJATHANI TOWER, 24 TH FLOOR', N'127/29 NONSEE ROAD, CHONGNONSEEYANNAWA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HMM', N'0', N'0993000048466', N'บริษัท', N'HMM (THAILAND) TO., LTD.', N'HMM (THAILAND) TO., LTD.', N'3199, MALEENONT TOWER, 12TH, RAMA IV RD., ', N'KLONGTON, KLONGTOEY, BANGKOK 10110', N'3199, MALEENONT TOWER, 12TH, RAMA IV RD., ', N'KLONGTON, KLONGTOEY, BANGKOK 10110', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HNF', N'0', N'0105543017340', N'บริษัท', N'H & FRIEDNS GTL (THAILAND) CO., LTD.', N'H & FRIEDNS GTL (THAILAND) CO., LTD.', N'BLDG 301, RM 402, 403, 404 FREEZONE, SUVARNABHUMI AIRPORT,', N'999 MOO 7 RACHATHEWA, BANGPHIL SAMUTPRAKAN 10540 THIALND', N'BLDG 301, RM 402, 403, 404 FREEZONE, SUVARNABHUMI AIRPORT,', N'999 MOO 7 RACHATHEWA, BANGPHIL SAMUTPRAKAN 10540 THIALND', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HONOU', N'0', N'0105554050301', N'บริษัท', N'HONOUR LANE LOGISTICS CO., LTD', N'HONOUR LANE LOGISTICS CO., LTD', N' FLOOR, C.C.T.BUILDING, 109 SURAWONG ROAD', N' SURIYAWONG, BANGRAK, BANGKOK 10500, THAILAND', N' FLOOR, C.C.T.BUILDING, 109 SURAWONG ROAD', N' SURIYAWONG, BANGRAK, BANGKOK 10500, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'HTNS ', N'0', N'0105555079981', N'บริษัท', N'HTNS (THAILAND) CO.,LTD.', N'HTNS (THAILAND) CO.,LTD.', N'ROOM NO.205, 2ND FL.,B-FZ BLDG.,FREE ZONE SUVANNABHUMI  AIRPORT', N'999 MOO 7 T.RACHATHEWA, A.BANGPHLI, SAMUTPRAKARN 10540 THAILAND.', N'ROOM NO.205, 2ND FL.,B-FZ BLDG.,FREE ZONE SUVANNABHUMI  AIRPORT', N'999 MOO 7 T.RACHATHEWA, A.BANGPHLI, SAMUTPRAKARN 10540 THAILAND.', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'INFINITY', N'0', N'0105547109362', N'บริษัท', N'INFINITY SHIPPING (THAILAND) CO.,LTD.', N'INFINITY SHIPPING (THAILAND) CO.,LTD.', N'109 CCT BUILDING 9TH FL. UNIT 1, SURAWONGSE ROAD.,', N' SURIYAWONGSE, BANGRAK, BANGKOK, 10500, THAILAND', N'109 CCT BUILDING 9TH FL. UNIT 1, SURAWONGSE ROAD.,', N' SURIYAWONGSE, BANGRAK, BANGKOK, 10500, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'IWALOG', N'0', N'0105546099495', N'บริษัท', N'IWA LOGISTICS (THAILAND) CO., LTD. (HEAD OFFICE)', N'IWA LOGISTICS (THAILAND) CO., LTD. (HEAD OFFICE)', N'100-102 ANUMARNRAJATHON 1, SURAWONGSE ROAD', N'BANGRAK, BANGKOK 10500 THAILAND', N'100-102 ANUMARNRAJATHON 1, SURAWONGSE ROAD', N'BANGRAK, BANGKOK 10500 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'K&N', N'0', N'0105528008441', N'บริษัท', N'KUEHNE + NAGEL LIMITED ', N'KUEHNE + NAGEL LIMITED ', N'9TH FLOOR,THANAPOOM TOWER', N'1550 NEW PETCHBURI ROADMAKKASAN,RACHTAVEE', N'9TH FLOOR,THANAPOOM TOWER', N'1550 NEW PETCHBURI ROADMAKKASAN,RACHTAVEE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'KANIN', N'0', N'0205541000163', N'บริษัท', N'KANIN TRANSPORT CO.,LTD. ', N'KANIN TRANSPORT CO.,LTD. ', N'84/16 M.10', N'TAMBON TUNGSUKLAAMPOUR SRIRACHA', N'84/16 M.10', N'TAMBON TUNGSUKLAAMPOUR SRIRACHA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'KDPLOG', N'0', N'0105551078557', N'บริษัท', N'KDP LOGISTICS (THAILAND) CO.,LTD. (HEAD OFFICE)', N'KDP LOGISTICS (THAILAND) CO.,LTD. (HEAD OFFICE)', N'360/24 RAMA III ROAD, CHONGNONSI', N'YANNAWA, BABGKOK 10120', N'360/24 RAMA III ROAD, CHONGNONSI', N'YANNAWA, BABGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'KFC', N'0', N'0105561013521', N'บริษัท', N'KFC (THAILAND) CO., LTD.', N'KFC (THAILAND) CO., LTD.', N'3388/79 SIRINRAT BUILDING, 22ND FLOOR, RAMA 4 ROAD,', N'KLONGTON, KLONGTOEY BANGKOK 10110', N'3388/79 SIRINRAT BUILDING, 22ND FLOOR, RAMA 4 ROAD,', N'KLONGTON, KLONGTOEY BANGKOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'KMTC', N'0', N'0993000093101', N'บริษัท', N'KMTC (THAILAND) CO.,LTD ', N'KMTC (THAILAND) CO.,LTD ', N'3195/13 VIBULTHANEE TOWER,', N'RAMA IV ROAD, KLONGTON,KLONGTOEY,', N'3195/13 VIBULTHANEE TOWER,', N'RAMA IV ROAD, KLONGTON,KLONGTOEY,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'KORCH', N'0', N'0105543050134', N'บริษัท', N'KORCHINA FREIGHT (THAILAND) CO., LTD', N'KORCHINA FREIGHT (THAILAND) CO., LTD', N'OSC BUILDING, 5TH FLOOR, 99  MOO 5 KINGKAEW RD,', N'RACHATEWA, BANGPLEE, SAMUTPRAKARN 10540', N'OSC BUILDING, 5TH FLOOR, 99  MOO 5 KINGKAEW RD,', N'RACHATEWA, BANGPLEE, SAMUTPRAKARN 10540', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'KWE', N'0', N'0105554085767', N'บริษัท', N'KWE -KINTETSU WORLD EXPRESS (THAILAND) CO., LTD.', N'KWE -KINTETSU WORLD EXPRESS (THAILAND) CO., LTD.', N'99 SOI LADPRAO 28', N'RATCHADAPHISEK  ROAD.CHANKASEM', N'99 SOI LADPRAO 28', N'RATCHADAPHISEK  ROAD.CHANKASEM', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'LESCH', N'0', N'0105542055418', N'บริษัท', N'Leschaco (Thailand) LTD', N'Leschaco (Thailand) LTD', N'3354/36-39, 11TH FLOOR, MANOROM BUILDING,RAMA IV ROAD', N'KLONGTON, KLONGTOEY, BANGKOK 10110, THAILAND', N'3354/36-39, 11TH FLOOR, MANOROM BUILDING,RAMA IV ROAD', N'KLONGTON, KLONGTOEY, BANGKOK 10110, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'LINER', N'0', N'0105533096654', N'บริษัท', N'LINER CLASS CO.,LTD. (HEAD OFFICE)', N'LINER CLASS CO.,LTD. (HEAD OFFICE)', N'3388/72 SIRINRAT BLDG.,20TH FL.,RAMA 4 RD', N'KLONGTON,KLONGTOEY BANGKOK 10110', N'3388/72 SIRINRAT BLDG.,20TH FL.,RAMA 4 RD', N'KLONGTON,KLONGTOEY BANGKOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'M+RFO', N'0', N'0105538064530', N'บริษัท', N'M+R FORWARDING (THAILAND) CO., LTD. (HEAD OFFICE)', N'M+R FORWARDING (THAILAND) CO., LTD. (HEAD OFFICE)', N'15 TH FLOOR, MANOROM BLDG., 3354/49 RAMA IV ROAD, ', N'KLONGTON, KLONGTOEY, BANGKOK 10110 THAILAND', N'15 TH FLOOR, MANOROM BLDG., 3354/49 RAMA IV ROAD, ', N'KLONGTON, KLONGTOEY, BANGKOK 10110 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MAERSK', N'0', N'0993000328493', N'บริษัท', N'MAERSK A/S C/O MAERSK LINE (THAILAND) LTD.', N'MAERSK A/S C/O MAERSK LINE (THAILAND) LTD.', N'1 SOUTH SATHORN ROAD', N'YANNAWA , SATHORN', N'1 SOUTH SATHORN ROAD', N'YANNAWA , SATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MARCH', N'0', N'0105560071799', N'บริษัท', N'MARCH LOGISTICS CO., LTD.', N'MARCH LOGISTICS CO., LTD.', N'3360/3 RAMA 4 ROAD, KLONGTON, KLONGTOEY,', N'BANGKOK  10110 THAILAND', N'3360/3 RAMA 4 ROAD, KLONGTON, KLONGTOEY,', N'BANGKOK  10110 THAILAND', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MCONN', N'0', N'0105559020337', N'บริษัท', N'MARINE CONNECTIONS CO.,LTD.', N'MARINE CONNECTIONS CO.,LTD.', N'14TH FL., SETHIWAN TOWER, 139 PAN ROAD, ', N'SILOM, BANGRAK, BANGKOK 10500', N'14TH FL., SETHIWAN TOWER, 139 PAN ROAD, ', N'SILOM, BANGRAK, BANGKOK 10500', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MFREI', N'0', N'0105556157404', N'บริษัท', N'MAINFREIGHT LOGISTICS (THAILAND) CO., LTD', N'MAINFREIGHT LOGISTICS (THAILAND) CO., LTD', N'193/64 16 th Floor, Lake Rajada Office Complex,', N' Ratchadapisek Road, Klongtoey Klongtoey, Bangkok 10110, Thailand', N'193/64 16 th Floor, Lake Rajada Office Complex,', N' Ratchadapisek Road, Klongtoey Klongtoey, Bangkok 10110, Thailand', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MORCON', N'0', N'0105539060589', N'บริษัท', N'MORCON SERVICE CO.,LTD.', N'MORCON SERVICE CO.,LTD.', N'19/6 หมู่ที่ 8 ต,บางโฉลง อ,บางพลี', N' จ.สมุทรปราการ 10540', N'19/6 หมู่ที่ 8 ต,บางโฉลง อ,บางพลี', N' จ.สมุทรปราการ 10540', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MSC', N'0', N'0105544019079', N'บริษัท', N'MEDITERRANEAN SHIPPING (THAILAND) CO.LTD', N'MEDITERRANEAN SHIPPING (THAILAND) CO.LTD', N'MSC BUILDING, 571 SUKHUMVIT 71 ROAD., KLONGTON-NUA', N' VADHANA, BANGKOK 10110', N'MSC BUILDING, 571 SUKHUMVIT 71 ROAD., KLONGTON-NUA', N' VADHANA, BANGKOK 10110', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MSCCO', N'0', N'0993000003667', N'บริษัท', N'MEDITERRANEAN SHIPPING COMPANY S.A. C/O MEDITERRANEAN SHIPPING (THAILAND) CO., LTD', N'MEDITERRANEAN SHIPPING COMPANY S.A. C/O MEDITERRANEAN SHIPPING (THAILAND) CO., LTD', N'MSC BUILDING, 571 SUKHUMVIT 71 ROAD., KLONGTON-NUA', N' VADHANA, BANGKOK 10111', N'MSC BUILDING, 571 SUKHUMVIT 71 ROAD., KLONGTON-NUA', N' VADHANA, BANGKOK 10111', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'MTK', N'0', N'0105555080238', N'บริษัท', N'MTK GLOBAL LOGISTICS CO.,LTD.', N'MTK GLOBAL LOGISTICS CO.,LTD.', N'116/72 SSP TOWER 2 20TH FLOOR', N'NA RANONG ROAD, KLONG TOEY, BANGKOK 10110 THAILAND', N'116/72 SSP TOWER 2 20TH FLOOR', N'NA RANONG ROAD, KLONG TOEY, BANGKOK 10110 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NDD', N'0', N'0105540102061', N'บริษัท', N'N&DD INTERNATIONAL (THAILAND) CO.,LTD. ', N'N&DD INTERNATIONAL (THAILAND) CO.,LTD. ', N'10/19 MOO 4, BANGCHALONG SUBDISTRIC', N'BANGPLEE DISTRICT,', N'10/19 MOO 4, BANGCHALONG SUBDISTRIC', N'BANGPLEE DISTRICT,', N'', N'', N'NDD', N'1234', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NEEDA', N'0', N'0105546080409', N'บริษัท', N'NEEDAWAN (THAILAND) CO.,LTD. ', N'NEEDAWAN (THAILAND) CO.,LTD. ', N'6 SOI CHAN45, CHAN RD.,', N'THUNGWATDON, SATHORN,', N'6 SOI CHAN45, CHAN RD.,', N'THUNGWATDON, SATHORN,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NGOW', N'0', N'0993000048814', N'บริษัท', N'NGOW HOCK CO., LTD ', N'NGOW HOCK CO., LTD ', N'PANJATHANI BUILDING', N'127/9 RACHADAPISEK ROAD,CHONGNONSEE, YANNAWA', N'PANJATHANI BUILDING', N'127/9 RACHADAPISEK ROAD,CHONGNONSEE, YANNAWA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NIPPON', N'0', N'0993000037928', N'บริษัท', N'NIPPON YUSEN KABUSHIKI KAISHA CO.,LTD. C/O NYK LINE (THAILAND) CO., LTD', N'NIPPON YUSEN KABUSHIKI KAISHA CO.,LTD. C/O NYK LINE (THAILAND) CO., LTD', N'2525 ONE FYI CENTER, 2 ND,7TH FL., RAMA 4 RD.,', N'KLONGTOEY, KLONGTOEY, BANGKOK 10110, THAILAND', N'2525 ONE FYI CENTER, 2 ND,7TH FL., RAMA 4 RD.,', N'KLONGTOEY, KLONGTOEY, BANGKOK 10110, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NITTSU', N'0', N'0105534021577', N'บริษัท', N'NITTSU LOGISTICS (THAILAND) CO.,LTD.', N'NITTSU LOGISTICS (THAILAND) CO.,LTD.', N'2032, 4TH FLOOR, ITALTHAI TOWER, NEW PETCHABURI RD', N'BANGKAPI, HUAYKWANG, BANGKOK 10310', N'2032, 4TH FLOOR, ITALTHAI TOWER, NEW PETCHABURI RD', N'BANGKAPI, HUAYKWANG, BANGKOK 10310', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NPPOOL', N'0', N'0135548002286', N'บริษัท', N'N.P. POOL GROUP CO LTD ', N'N.P. POOL GROUP CO LTD ', N'74/ 7 MOO2, KLONGSONGTONNUN', N'LATKRABANG', N'74/ 7 MOO2, KLONGSONGTONNUN', N'LATKRABANG', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NSLOG', N'0', N'0105548159886', N'บริษัท', N'NS LOGISTICS CO., LTD. ', N'NS LOGISTICS CO., LTD. ', N'199 SOI ONNUT 30, SUKHUMVIT', N'77 RD., SUANLUANGPAN ROAD,SILOM,BANGRAK,', N'199 SOI ONNUT 30, SUKHUMVIT', N'77 RD., SUANLUANGPAN ROAD,SILOM,BANGRAK,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'NTLSO', N'0', N'0203559001569', N'บริษัท', N'NTL SOLUTIONS & SERVICE  LIMITED PARTNERSHIP', N'NTL SOLUTIONS & SERVICE  LIMITED PARTNERSHIP', N'75/63 MOO 10 SUKUMVIT ROAD', N'TAMBOL TUNGSUKLAAMPHOR SRIRACHA', N'75/63 MOO 10 SUKUMVIT ROAD', N'TAMBOL TUNGSUKLAAMPHOR SRIRACHA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'ONE', N'0', N'0105560142050', N'บริษัท', N'OCEAN NETWORK EXPRESS (THAILAND) LTD. ', N'OCEAN NETWORK EXPRESS (THAILAND) LTD. ', N'319 CHAMCHURI SQUARE BUILDING', N'28 TH FLOOR UNIT 1-16PHAYATHAI ROAD. PATHUMWAN', N'319 CHAMCHURI SQUARE BUILDING', N'28 TH FLOOR UNIT 1-16PHAYATHAI ROAD. PATHUMWAN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'ONTIME', N'0', N'0105549000465', N'บริษัท', N'ON-TIME WORLDWIDE LOGISTICS LTD.', N'ON-TIME WORLDWIDE LOGISTICS LTD.', N'10TH FLOOR, PIPATANASIN BUILDING 6/10 NARADHIWAS RAJANAGARINDRA ROAD', N'THUNGMAHAMEK, SATHORN, BANGKOK 10120', N'10TH FLOOR, PIPATANASIN BUILDING 6/10 NARADHIWAS RAJANAGARINDRA ROAD', N'THUNGMAHAMEK, SATHORN, BANGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'OOCL', N'0', N'0993000037774', N'บริษัท', N'ORIENT OVERSEAS CONTAINER LINE LTD. ', N'ORIENT OVERSEAS CONTAINER LINE LTD. ', N'75/68-69 , 29F OCEAN TOWERII', N'SUKHUMVIT 19 ROADKLONGTOEY -NUA', N'75/68-69 , 29F OCEAN TOWERII', N'SUKHUMVIT 19 ROADKLONGTOEY -NUA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'PAT', N'0', N'994000165480', N'บริษัท', N'PORT AUTHORITY OF THAILAND', N'PORT AUTHORITY OF THAILAND', N'444 TARUA RD.,  KLONGTOEY, BANGKOK 10110', NULL, N'444 TARUA RD.,  KLONGTOEY, BANGKOK 10110', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'PENAN', N'0', N'0105545117805', N'บริษัท', N'PENANSHIN SHIPPING (THAILAND) LTD', N'PENANSHIN SHIPPING (THAILAND) LTD', N'731/32-33 RATCHADAPISEK ROAD,', N'BANGPONGPANG, YANNAWA, BANGKOK 10120', N'731/32-33 RATCHADAPISEK ROAD,', N'BANGPONGPANG, YANNAWA, BANGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'PILOT', N'0', N'0105531072332', N'บริษัท', N'PILOT CONSOLIDATOR CO.,LTD. (HEAD OFFICE)', N'PILOT CONSOLIDATOR CO.,LTD. (HEAD OFFICE)', N'2024/164-168 RIMTHANG ROTFAI SAIPAKNAM RD', N'PHRAKANONG. KLONGTOEY, BANGKOK 10260', N'2024/164-168 RIMTHANG ROTFAI SAIPAKNAM RD', N'PHRAKANONG. KLONGTOEY, BANGKOK 10260', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'PROFR', N'0', N'0105531044860', N'บริษัท', N'PROFREIGHT INTERNATIONAL CO LTD. ', N'PROFREIGHT INTERNATIONAL CO LTD. ', N'19 SRINAKARIN ROAD, BANGNA', N'BANGNA,', N'19 SRINAKARIN ROAD, BANGNA', N'BANGNA,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'PROIN', N'0', N'0105558000022', N'บริษัท', N'PRO INTERFREIGHT CO.,LTD', N'PRO INTERFREIGHT CO.,LTD', N'29/43 SOI CHAN 43 YAK 26-1-1', N' BANGKHLO, BANGKHOLAEM, BANGKOK THAILAND 10120', N'29/43 SOI CHAN 43 YAK 26-1-1', N' BANGKHLO, BANGKHOLAEM, BANGKOK THAILAND 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'RBI', N'0', N'0105547007829', N'บริษัท', N'RAJABOVORN INTERNATIONAL 2004 CO.,LTD. ', N'RAJABOVORN INTERNATIONAL 2004 CO.,LTD. ', N'14 ICD ROAD,', N'KLONGSAMPRAWET, LADKHABANG,', N'14 ICD ROAD,', N'KLONGSAMPRAWET, LADKHABANG,', NULL, NULL, N'RBI', N'RBI', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'REVEN', N'0', NULL, N'บริษัท', N'REVENUE DEPARTMENT ', N'REVENUE DEPARTMENT ', N'(OTHER TAX)', N'90 PHAHOLYOTIN RD,SOI 7, PHYATHAI', N'(OTHER TAX)', N'90 PHAHOLYOTIN RD,SOI 7, PHYATHAI', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'RHENU', N'0', N'0105537040751', N'บริษัท', N'RHENUS LOGISTICS CO., LTD. ', N'RHENUS LOGISTICS CO., LTD. ', N'191/14 CTI TOWER ,28TH FLOOR', N'RATCHADAPISEK RD., KLONGTOEYKLONGTOEY', N'191/14 CTI TOWER ,28TH FLOOR', N'RATCHADAPISEK RD., KLONGTOEYKLONGTOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'RTLTR', N'0', N'0105552130412', N'บริษัท', N'RTL TRANSPORTATION CO.,LTD. ', N'RTL TRANSPORTATION CO.,LTD. ', N'162 Moo 7', N'Tumbol Padad,Aumphur Muang Chiangmai,', N'162 Moo 7', N'Tumbol Padad,Aumphur Muang Chiangmai,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SAGAMI', N'0', N'0105531042450', N'บริษัท', N'SAGAMI THAI CO., LTD ', N'SAGAMI THAI CO., LTD ', N'31/3-5  BANGNA- TRAD HIGHWAY', N'K.M. 12. 5 , MOO 1TUMBON RACHATHEVA,BANG PLEE DISTRICT', N'31/3-5  BANGNA- TRAD HIGHWAY', N'K.M. 12. 5 , MOO 1TUMBON RACHATHEVA,BANG PLEE DISTRICT', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SBTTR', N'0', N'0105543004507', N'บริษัท', N'S.B.T TRANSPORT CO.,LTD. ', N'S.B.T TRANSPORT CO.,LTD. ', N'50/391 Moo 3 Soi Lasalle,', N'Sukumvit 105 Road, Bangna', N'50/391 Moo 3 Soi Lasalle,', N'Sukumvit 105 Road, Bangna', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SCHEN', N'0', N'0105517008975', N'บริษัท', N'SCHENKER (THAI) LTD.', N'SCHENKER (THAI) LTD.', N'3388/54-61,63,66-67, SIRINRAT BLDG., 16TH-19TH FL., RAMA 4', N' KLONGTON, KLONGTOEY BANGKOK 10110 THAILAND', N'3388/54-61,63,66-67, SIRINRAT BLDG., 16TH-19TH FL., RAMA 4', N' KLONGTON, KLONGTOEY BANGKOK 10110 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SELAND', N'0', N'0993000302559', N'บริษัท', N'SEALAND MAERSK ASIA PTE LTD C/O MAERSK LINE (THAILAND)  LTD.', N'SEALAND MAERSK ASIA PTE LTD C/O MAERSK LINE (THAILAND)  LTD.', N'1 SOUTH SATHORN ROAD,', N'YANNAWA SATHORN', N'1 SOUTH SATHORN ROAD,', N'YANNAWA SATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SHIPCO', N'0', N'0105541045303', N'บริษัท', N'SHIPCO TRANSPORT (THAILAND) LTD', N'SHIPCO TRANSPORT (THAILAND) LTD', N'3656/69-71, 21ST.FLOOR, GREEN TOWER BLDG., RAMA 4 ROAD', N' KLONGTON, KLONGTOEY, BANGKOK THAILAND 10110', N'3656/69-71, 21ST.FLOOR, GREEN TOWER BLDG., RAMA 4 ROAD', N' KLONGTON, KLONGTOEY, BANGKOK THAILAND 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SICONN', N'0', N'0105553057468', N'บริษัท', N'SINO CONNECTIONS LOGISTICS (THAILAND) CO.,LTD.', N'SINO CONNECTIONS LOGISTICS (THAILAND) CO.,LTD.', N'1011 SUPALAI GRAND TOWER, 7TH FLOOR, UNIT NO. 05,', N' RAMA 3 ROAD,CHONGNONSEE, YANNAWA, BANGKOK 10120', N'1011 SUPALAI GRAND TOWER, 7TH FLOOR, UNIT NO. 05,', N' RAMA 3 ROAD,CHONGNONSEE, YANNAWA, BANGKOK 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SINTA', N'0', N'0105531016041', N'บริษัท', N'SINTANACHOTE CO., LTD. ', N'SINTANACHOTE CO., LTD. ', N'876 LAZAL ROAD,KHWAENG BANGNA,', N'KHET BANGNA', N'876 LAZAL ROAD,KHWAENG BANGNA,', N'KHET BANGNA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SITRANS', N'0', N'0105547450273', N'บริษัท', N'SINOTRANS THAI LOGISTICS CO., LTD.', N'SINOTRANS THAI LOGISTICS CO., LTD.', N'193/69-70 LAKE RAJADA OFFICE COMPLEX,17TH FLOOR', N' RATCHADAPISEK ROAD, KONGTOEY, KLONGTOEY, BANGKOK 10110 ', N'193/69-70 LAKE RAJADA OFFICE COMPLEX,17TH FLOOR', N' RATCHADAPISEK ROAD, KONGTOEY, KLONGTOEY, BANGKOK 10110 ', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SKY', N'0', N'0105541029154', N'บริษัท', N'SKY -  MARINE INTERNATIONAL CORP.,LTD.', N'SKY -  MARINE INTERNATIONAL CORP.,LTD.', N'8TH FLOOR, C.C.T. BUILDING 109 SURAWONG ROAD', N' BANGRAK, BANGKOK 10500 THAILAND', N'8TH FLOOR, C.C.T. BUILDING 109 SURAWONG ROAD', N' BANGRAK, BANGKOK 10500 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'SRISO', N'0', N'0105555147821', N'บริษัท', N'SRISOMKID SUPPLY CHAIN CO.,LTD. ', N'SRISOMKID SUPPLY CHAIN CO.,LTD. ', N'188/138 ROMKLAO ROAD, KLONG 3 PRAVE', N'LAD KRABANG, BANGKOK', N'188/138 ROMKLAO ROAD, KLONG 3 PRAVE', N'LAD KRABANG, BANGKOK', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'STDTR', N'0', N'0115538002488', N'บริษัท', N'S T D & TRANSPORT CO.,LTD. ', N'S T D & TRANSPORT CO.,LTD. ', N'15/107 M00 10 SAMRONGNUA', N'MUANGSAMUTHPRAKARN', N'15/107 M00 10 SAMRONGNUA', N'MUANGSAMUTHPRAKARN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TAIRWAY', N'0', N'107537001757', N'บริษัท', N'THAI AIRWAYS INTERNATIONAL PUBLIC COMPANY LIMITED', N'THAI AIRWAYS INTERNATIONAL PUBLIC COMPANY LIMITED', N'CARGO TERMINAL BLDG., 333, 333/1 MOO 7 RACHA THAE WA, BANG PHIL,', N'SAMUTPRAKARN 10540', N'CARGO TERMINAL BLDG., 333, 333/1 MOO 7 RACHA THAE WA, BANG PHIL,', N'SAMUTPRAKARN 10540', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TANDT', N'0', N'0243555001343', N'บริษัท', N'T AND T SHIPPING AIR LOGISTICS LTD, PARTNERSHIP.', N'T AND T SHIPPING AIR LOGISTICS LTD, PARTNERSHIP.', N'103/107 MOO 9.', N'TAMBON KLONG UDOM CHONLAJHONAUMPHUR MUANG', N'103/107 MOO 9.', N'TAMBON KLONG UDOM CHONLAJHONAUMPHUR MUANG', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TCCAG', N'0', N'0105555141393', N'บริษัท', N'TCC AGENCY LTD.', N'TCC AGENCY LTD.', N'LUMPINI TOWER, 3 RD FLOOR, NO.1168/5, RAMA 4 ROAD', N'TUNGMAHAMEK, SATHORN, BANGKOK 10120 THAILAND', N'LUMPINI TOWER, 3 RD FLOOR, NO.1168/5, RAMA 4 ROAD', N'TUNGMAHAMEK, SATHORN, BANGKOK 10120 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'THEM', N'0', N'0105555047206', N'บริษัท', N'THE M CORP LAND CO., LTD.', N'THE M CORP LAND CO., LTD.', N'896/35 อาคารเอสวี ซิตี้ ชั้น 21 ถนนพระราม 3', N' แขวงบางโพงพาง เขตยานนาวา กรุงเทพมานคร 10120', N'896/35 อาคารเอสวี ซิตี้ ชั้น 21 ถนนพระราม 3', N' แขวงบางโพงพาง เขตยานนาวา กรุงเทพมานคร 10120', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TOLLG', N'0', N'0105535014779', N'บริษัท', N'TOLL GLOBAL FORWARDING (THAILAND) LTD. ', N'TOLL GLOBAL FORWARDING (THAILAND) LTD. ', N'SUITE 1702-1704 17TH  FLOOR ONE PAC', N'PLACE, 140 SUKHUMVIT ROAD.KLONGTOEY , KLONGTOEY', N'SUITE 1702-1704 17TH  FLOOR ONE PAC', N'PLACE, 140 SUKHUMVIT ROAD.KLONGTOEY , KLONGTOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TRSPO', N'0', N'0105518004132', N'บริษัท', N'TRANSPO INTERNATIONAL LTD.', N'TRANSPO INTERNATIONAL LTD.', N'311/44-46 SONGPRAPA RD.,', N' DONMUANG, BANGKOK 10210, THAILAND', N'311/44-46 SONGPRAPA RD.,', N' DONMUANG, BANGKOK 10210, THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TSCON', N'0', N'0105549050632', N'บริษัท', N'TS CONTAINER LINES (THAILAND ) CO., LTD. ', N'TS CONTAINER LINES (THAILAND ) CO., LTD. ', N'193/87-88 LAKE RAJADA OFFICE COMPLE', N'21ST FLOOR, RACHADAPISEK ROADKLONGTOEY', N'193/87-88 LAKE RAJADA OFFICE COMPLE', N'21ST FLOOR, RACHADAPISEK ROADKLONGTOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TSHIPP', N'0', N'0105533091741', N'บริษัท', N'THAI SHIPPING AGENCIES AND TRADING CO LTD', N'THAI SHIPPING AGENCIES AND TRADING CO LTD', N'3360 SOI MANOROM, RAMA 4 RD.', N'KLONGTON, KLONGTOEY', N'3360 SOI MANOROM, RAMA 4 RD.', N'KLONGTON, KLONGTOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TSJ', N'0', N'0105555082648', N'บริษัท', N'TSJ EXPRESS TRANSPORT CO.,LTD. ', N'TSJ EXPRESS TRANSPORT CO.,LTD. ', N'17/4 Moo.3  Tambol Klongdan,', N'A.Bangboa', N'17/4 Moo.3  Tambol Klongdan,', N'A.Bangboa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TSL', N'0', N'0203551006481', N'บริษัท', N'TSL TRANSPORT AND SERVICE LIMITED PARTNERSHIP', N'TSL TRANSPORT AND SERVICE LIMITED PARTNERSHIP', N'789/134 MOO 8, T.BANGLAMUNG,', N'A.BANGLAMUNG', N'789/134 MOO 8, T.BANGLAMUNG,', N'A.BANGLAMUNG', NULL, NULL, N'TSL', N'TSL', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TSPEED', N'0', N'0105529031951', N'บริษัท', N'TRANSPEED CO.,LTD.', N'TRANSPEED CO.,LTD.', N'3360/6-8 SOI MANOROM.RAMA 4 RD.,', N' KLONGTON,KLONGTOEY BNAGKOK 10110', N'3360/6-8 SOI MANOROM.RAMA 4 RD.,', N' KLONGTON,KLONGTOEY BNAGKOK 10110', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'TWORLD', N'0', N'0105557160026', N'บริษัท', N'TRANSWORLD GLS (THAILAND) LIMITED', N'TRANSWORLD GLS (THAILAND) LIMITED', N'179 BANGKOK CITY TOWER, 5TH FLOOR, SOUTH SATHORN ROAD', N'THUNGMAHAMEK, SATHORN, BANGKOK 10120 THAILAND', N'179 BANGKOK CITY TOWER, 5TH FLOOR, SOUTH SATHORN ROAD', N'THUNGMAHAMEK, SATHORN, BANGKOK 10120 THAILAND', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'USAVE', N'0', N'0115547003645', N'บริษัท', N'U-SAVE LOGISTICS SERVICES CO.,LTD ', N'U-SAVE LOGISTICS SERVICES CO.,LTD ', N'99/443 MOO 4, BANGNA-TRAD', N'BANGCHALONG SUB-DISTRICTBANGPLEE DISTRICT', N'99/443 MOO 4, BANGNA-TRAD', N'BANGCHALONG SUB-DISTRICTBANGPLEE DISTRICT', N'', N'', N'USAVE', N'1234', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'UTMOST', N'0', N'0105546095597', N'บริษัท', N'UTMOST LOGITEC (THAILAND) CO.,LTD (HEAD OFFICE)', N'UTMOST LOGITEC (THAILAND) CO.,LTD (HEAD OFFICE)', N'1350/115-118 PATTANAKARN ROAD', N' SUANLUANG, SUANLUANG, BANGKOK 10250', N'1350/115-118 PATTANAKARN ROAD', N' SUANLUANG, SUANLUANG, BANGKOK 10250', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'VCARG', N'0', N'0105531047133', N'บริษัท', N'V. CARGO CO., LTD. ', N'V. CARGO CO., LTD. ', N'9/233-234 SOI PHAHONYOTHIN 48', N'PHAHONYOTHIN RD.,849 SILOM RD.BANGRAKANUSAWARI , BANGKHEN', N'9/233-234 SOI PHAHONYOTHIN 48', N'PHAHONYOTHIN RD.,849 SILOM RD.BANGRAKANUSAWARI , BANGKHEN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'VCSUP', N'0', N'0105540044974', N'บริษัท', N'V.CARGO & SUPPLY CO., LTD ', N'V.CARGO & SUPPLY CO., LTD ', N'9/179 MOO 8 SOI PAHOLYOTHIN 48', N'PAHOLYOTHIN RD., ANUSAVAREEBANGKHEN', N'9/179 MOO 8 SOI PAHOLYOTHIN 48', N'PAHOLYOTHIN RD., ANUSAVAREEBANGKHEN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'VGUARD', N'0', N'0105547018693', N'บริษัท', N'VANGUARD LOGISTICS SERVICES (THAILAND) CO.,LTD.', N'VANGUARD LOGISTICS SERVICES (THAILAND) CO.,LTD.', N'139 SETHIWAN TOWER,17TH FLOOR,UNIT', N'PAN ROAD,SILOM,BANGRAK,', N'139 SETHIWAN TOWER,17TH FLOOR,UNIT', N'PAN ROAD,SILOM,BANGRAK,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'WAHAI', N'0', N'0993000052463', N'บริษัท', N'WAN HAI LINES LTD. ', N'WAN HAI LINES LTD. ', N'21 ST FLOOR, LUMPINI TOWER', N'1168/56 RAMA 4 RD., THUNGMAHAMEKSATHORN', N'21 ST FLOOR, LUMPINI TOWER', N'1168/56 RAMA 4 RD., THUNGMAHAMEKSATHORN', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'WALLEM', N'0', N'0105510003412', N'บริษัท', N'WALLEM SHIPPING (THAILAND) LTD. ', N'WALLEM SHIPPING (THAILAND) LTD. ', N'849 Vorawat Building, 18th Floor', N'Unit 1804 Silom Road.Silom, Bangrak', N'849 Vorawat Building, 18th Floor', N'Unit 1804 Silom Road.Silom, Bangrak', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'WORLDU', N'0', N'0105542063429', N'บริษัท', N'WORLD UNITED LOGISTICS (THAILAND) CO.,LTD.', N'WORLD UNITED LOGISTICS (THAILAND) CO.,LTD.', N'SUB SOMBOON BUILDING., 46/183 NUSLCHAN RD.', N'NUALCHAN, BUNG-GOOM, BANGKOK 10230', N'SUB SOMBOON BUILDING., 46/183 NUSLCHAN RD.', N'NUALCHAN, BUNG-GOOM, BANGKOK 10230', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'WTP', N'0', N'0105541017741', N'บริษัท', N'W.T.P. GROUP COMPANY LIMITED ', N'W.T.P. GROUP COMPANY LIMITED ', N'160/173-175 FLOOR 12A ITF', N'SILOM PALACE TOWERSILOM ROAD, SURIYAWONG', N'160/173-175 FLOOR 12A ITF', N'SILOM PALACE TOWERSILOM ROAD, SURIYAWONG', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'YMING', N'0', N'0105560162166', N'บริษัท', N'YANG MING LINE (THAILAND) CO., LTD. ', N'YANG MING LINE (THAILAND) CO., LTD. ', N'388 EXCHANGE TOWER ,39TH FL', N'UNIT NO.3901, SUKHUMVIT RDPLACE, 140 SUKHUMVIT ROAD.KLONGTOEY , KLONGTOEYKLONGTOEY', N'388 EXCHANGE TOWER ,39TH FL', N'UNIT NO.3901, SUKHUMVIT RDPLACE, 140 SUKHUMVIT ROAD.KLONGTOEY , KLONGTOEYKLONGTOEY', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Mas_Vender] ([VenCode], [BranchCode], [TaxNumber], [Title], [TName], [English], [TAddress1], [TAddress2], [EAddress1], [EAddress2], [Phone], [FaxNumber], [LoginName], [LoginPassword], [GLAccountCode], [ContactAcc], [ContactSale], [ContactSupport1], [ContactSupport2], [ContactSupport3], [WEB_SITE]) VALUES (N'YUSEN', N'0', N'0105512002448', N'บริษัท', N'YUSEN LOGISTICS (THAILAND) CO.,LTD. ', N'YUSEN LOGISTICS (THAILAND) CO.,LTD. ', N'11TH, 14TH, 15TH FLOOR', N'OCEAN INSURANCE BLDG163 SURAWONGSE ROAD, SURIYAWONGSE', N'11TH, 14TH, 15TH FLOOR', N'OCEAN INSURANCE BLDG163 SURAWONGSE ROAD, SURIYAWONGSE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
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
