--structure transport theso
alter table Job_LoadInfoDetail add MileBegin int;
alter table Job_LoadInfoDetail add MileEnd int;
alter table Job_PaymentHeader add ApproveRef nvarchar(255);
alter table Job_CashControl add PostRefNo nvarchar(255);
alter table Mas_BookAccount add ControlBalance float;
alter table Job_WHTax add IsCSV int;
go
--structure fuel

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

ALTER TABLE [dbo].[Mas_CarLicense] ADD  CONSTRAINT [DF_Mas_CarLicense_weight]  DEFAULT ((0)) FOR [Weight]
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
delete from dbo.Mas_Config where ConfigCode in(
'REPORT_CLRBYEMP',
'REPORT_CLRBYTRUCK',
'REPORT_CLRSUMMARY',
'REPORT_COSTBYTRUCK',
'REPORT_FUELDAILY',
'REPORT_FUELSUMMARY',
'REPORT_JOBCHECKFUEL',
'REPORT_TRUCKEXPENSES'
)
go
insert into dbo.Mas_Config select * from job_theso.dbo.Mas_Config where ConfigCode in(
'REPORT_CLRBYEMP',
'REPORT_CLRBYTRUCK',
'REPORT_CLRSUMMARY',
'REPORT_COSTBYTRUCK',
'REPORT_FUELDAILY',
'REPORT_FUELSUMMARY',
'REPORT_JOBCHECKFUEL',
'REPORT_TRUCKEXPENSES'
)
go
delete from dbo.Mas_Config where ConfigCode='SQL'
and ConfigValue like '%Job_AddFuel%'
go
insert into dbo.Mas_Config select * from job_theso.dbo.Mas_Config where ConfigCode='SQL'
and ConfigValue like '%Job_AddFuel%'
go
--SQL->SelectPlanload 
/*
select j.JNo,j.ConfirmDate,j.CustCode,c.NameThai as CustTName,
j.ConsigneeCode,s.NameThai as ConsigneeTName,j.InvProduct,j.TotalContainer,
j.CustContactName,j.Description,j.TRemark,j.CustRefNO,j.InvNo,j.VesselName,j.MVesselName,
j.ETDDate,j.ETADate,j.DeliveryTo,j.DeliveryAddr,j.InvProductQty,j.InvProductUnit,j.TotalGW,j.TotalNW,
j.ClearPort,j.ClearPortNo,j.InvInterPort,j.HAWB,j.MAWB,j.BLNo,j.BookingNo,j.DutyDate,j.DutyAmount,
j.ForwarderCode,f.TName as ForwarderName,j.AgentCode,t.TName as TransporterName,
(CASE WHEN j.JobType=1 THEN (SELECT TOP 1 PortName from jobmaster.dbo.Mas_RFIPC where CountryCode=j.InvFCountry AND PortCode=j.InvInterPort) 
ELSE (SELECT TOP 1 PortName from jobmaster.dbo.Mas_RFIPC where CountryCode=j.InvCountry AND PortCode=j.InvInterPort) END )as PortName
,(select SUM(a.AdvNet+a.Charge50Tavi) as TotalDO from Job_AdvDetail a 
inner join Job_AdvHeader h on a.BranchCode=h.BranchCode and a.AdvNo=h.AdvNo
where h.DocStatus<>99 and  a.SDescription not like '%มัดจำ%'  and a.SDescription not like '%ล้างตู้%' and a.SDescription not like '%DEM%' 
AND a.BranchCode=j.BranchCode AND a.ForJNo=j.JNo
) as TotalDO
,(select SUM(a.AdvNet+a.Charge50Tavi) as TotalDO from Job_AdvDetail a 
inner join Job_AdvHeader h on a.BranchCode=h.BranchCode and a.AdvNo=h.AdvNo
where h.DocStatus<>99 and  a.SDescription like '%มัดจำ%'
AND a.BranchCode=j.BranchCode AND a.ForJNo=j.JNo
) as TotalERN
,(select SUM(a.AdvNet+a.Charge50Tavi) as TotalDO from Job_AdvDetail a 
inner join Job_AdvHeader h on a.BranchCode=h.BranchCode and a.AdvNo=h.AdvNo
where h.DocStatus<>99 and  a.SDescription like '%ล้างตู้%'
AND a.BranchCode=j.BranchCode AND a.ForJNo=j.JNo
) as TotalCLEAN
,(select SUM(a.AdvNet+a.Charge50Tavi) as TotalDO from Job_AdvDetail a 
inner join Job_AdvHeader h on a.BranchCode=h.BranchCode and a.AdvNo=h.AdvNo
where h.DocStatus<>99 and  a.SDescription like '%DEM%'
AND a.BranchCode=j.BranchCode AND a.ForJNo=j.JNo
) as TotalDEM
,(select sum(AmtTotal) as TotalEstimate from Job_ClearExp where BranchCode=j.BranchCode and JNo=j.JNo) as TotalEstimate
,(SELECT STUFF((
    SELECT DISTINCT ',' + CTN_NO
    FROM Job_LoadInfoDetail WHERE BranchCode=j.BranchCode
    AND JNo=j.JNo 
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as ContainerList
from (select * from Job_Order where JobType<>6) j left join Mas_Company c
on j.CustCode=c.CustCode and j.CustBranch=c.Branch
left join Mas_Company s
on j.consigneecode=s.CustCode 
left join Mas_Vender f on j.ForwarderCode=f.VenCode
left join Mas_Vender t on j.AgentCode=t.VenCode
{0}
*/