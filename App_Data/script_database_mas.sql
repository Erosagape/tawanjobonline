USE [jobmaster]
GO
/****** Object:  Table [dbo].[Mas_BankCode]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_BankCode](
	[Code] [varchar](5) NOT NULL,
	[BName] [varchar](50) NULL,
	[CustomsCode] [varchar](3) NULL,
 CONSTRAINT [pK_masbankcode] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_CountryFT]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_CountryFT](
	[CTYCODE] [varchar](3) NOT NULL,
	[CTYName] [varchar](35) NULL,
	[CURCODE] [varchar](3) NULL,
	[FTCODE] [int] NULL,
	[CUCODE] [int] NULL,
 CONSTRAINT [pk_country] PRIMARY KEY CLUSTERED 
(
	[CTYCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_CurrencyCode]    Script Date: 07/05/2020 10:49:05 ******/
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
/****** Object:  Table [dbo].[Mas_Province]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_Province](
	[ProvinceCode] [varchar](3) NOT NULL,
	[ProvinceName] [varchar](35) NULL,
 CONSTRAINT [PK_ProvinceCode] PRIMARY KEY CLUSTERED 
(
	[ProvinceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_ProvinceSub]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_ProvinceSub](
	[ProvinceCode] [varchar](3) NULL,
	[SubProvince] [varchar](35) NULL,
	[District] [varchar](35) NULL,
	[PostCode] [varchar](9) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Mas_ProvinceSub] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_RFARS]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_RFARS](
	[AreaCode] [varchar](5) NOT NULL,
	[AreaName] [varchar](70) NULL,
	[AccNo] [varchar](10) NULL,
	[Payee] [varchar](10) NULL,
	[BankCode] [varchar](5) NULL,
	[AcType] [varchar](1) NULL,
 CONSTRAINT [pk_customsPort] PRIMARY KEY CLUSTERED 
(
	[AreaCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_RFDCT]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_RFDCT](
	[Type] [varchar](3) NOT NULL,
	[Description] [varchar](50) NULL,
	[Category] [varchar](1) NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [pk_declareType] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_RFIPC]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_RFIPC](
	[PortCode] [varchar](3) NOT NULL,
	[PortName] [varchar](35) NULL,
	[CountryCode] [varchar](3) NOT NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
 CONSTRAINT [pk_interport] PRIMARY KEY CLUSTERED 
(
	[PortCode] ASC,
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_RFUNT]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_RFUNT](
	[Code] [varchar](3) NOT NULL,
	[TName] [varchar](35) NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_ServUnitType]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_ServUnitType](
	[UnitType] [varchar](10) NOT NULL,
	[UName] [varchar](50) NULL,
	[EName] [varchar](50) NULL,
	[IsCTNUnit] [int] NULL,
 CONSTRAINT [pk_servunit] PRIMARY KEY CLUSTERED 
(
	[UnitType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_User]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_User](
	[UserID] [varchar](10) NOT NULL,
	[UPassword] [varchar](70) NULL,
	[TName] [varchar](70) NULL,
	[EName] [varchar](70) NULL,
	[TPosition] [varchar](50) NULL,
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
	[UserUpline] [varchar](10) NULL,
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
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mas_Vessel]    Script Date: 07/05/2020 10:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mas_Vessel](
	[RegsNumber] [varchar](17) NOT NULL,
	[TName] [varchar](35) NULL,
	[VesselType] [varchar](1) NULL,
	[OTNumber] [varchar](10) NULL,
	[CompanyBranch] [varchar](4) NULL,
	[NCountry] [varchar](2) NULL,
	[CargoType] [varchar](50) NULL,
	[TICount] [varchar](3) NULL,
	[RiskRating] [varchar](2) NULL,
	[TareTonnage] [varchar](6) NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
 CONSTRAINT [PK_Vessel] PRIMARY KEY CLUSTERED 
(
	[RegsNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
