DROP TABLE Mas_CarLicense
go
/****** Object:  Table [dbo].[Mas_CarLicense]    Script Date: 7/7/2021 4:49:35 PM ******/
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
 CONSTRAINT [PK_Mas_CarLicense] PRIMARY KEY CLUSTERED 
(
	[CarNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Mas_CarLicense] ADD  CONSTRAINT [DF_Mas_CarLicense_weight]  DEFAULT ((0)) FOR [Weight]
GO


