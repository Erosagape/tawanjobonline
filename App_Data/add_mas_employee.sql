DROP TABLE Mas_Employee
/****** Object:  Table [dbo].[Mas_Employee]    Script Date: 7/7/2021 4:50:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mas_Employee](
	[Eid] [int] IDENTITY(1,1) NOT NULL,
	[EmpCode] [varchar](12) NOT NULL,
	[PreName] [varchar](50) NULL,
	[Name] [varchar](255) NULL,
	[NickName] [varchar](50) NULL,
	[AccountNumber] [varchar](50) NULL,
	[Branch] [varchar](50) NULL,
	[Address] [text] NULL,
	[Tel] [varchar](50) NULL,
	[Remark] [text] NULL,
	[Email] [varchar](255) NULL,
 CONSTRAINT [PK_Mas_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


