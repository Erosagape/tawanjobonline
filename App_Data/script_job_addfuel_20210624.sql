/****** Object:  Table [dbo].[Job_AddFuel]    Script Date: 6/24/2021 3:51:00 PM ******/
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
 CONSTRAINT [PK_Job_AddFuel] PRIMARY KEY CLUSTERED 
(
	[BranchCode] ASC,
	[DocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


