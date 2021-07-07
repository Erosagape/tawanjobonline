INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CAR_STATUS', N'ACTIVE', N'พร้อมใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CAR_STATUS', N'DAMAGED', N'รถเสีย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CAR_STATUS', N'INACTIVE', N'ยุติการใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CAR_STATUS', N'REPAIRING', N'กำลังซ่อม')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CAR_STATUS', N'WORKING', N'กำลังวิ่งงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'FUEL_PAYMENT', N'CASH', N'เงินสด')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'FUEL_PAYMENT', N'CREDIT', N'เครดิต')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'FUEL_STATION', N'OTHERS', N'ที่อื่น')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'FUEL_STATION', N'THESO', N'เดอะโซ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'FUEL_TYPE', N'DIESEL', N'ดีเซล')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'FUEL_TYPE', N'GAS', N'แก๊ส')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'LANG_MENU', N'mnuMasA10', N'Car License|ข้อมูลรถ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'LANG_MENU', N'mnuMasA11', N'Employee|ข้อมูลพนักงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'COLUMN_NOSUM', N'UnitPrice')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'MAIN_CLITERIA', N'AND,a.DocDate,j.CustCode,j.JNo,a.CreateBy,a.StationCode,j.JobStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'MAIN_SQL', N'select a.DocDate,a.FuelType,a.DocNo,a.CarLicense,a.BudgetVolume,a.BudgetValue,a.ActualVolume,a.UnitPrice,a.TotalAmount,a.StationCode
from Job_AddFuel a left join Job_Order j ON a.BranchCode=j.BranchCode and a.JNo=j.JNo 
where NOT isnull(a.CancelBy,'''')<>'''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'ReportAuthor', N'1,2,3,4,5,6,98,99')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'ReportGroup', N'ACC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'ReportNameEN', N'Refuel Daily Report By Refill Date')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'ReportNameTH', N'รายงานการเติมน้ำมัน/เชื้อเพลิงตามวันที่')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_FUELDAILY', N'ReportType', N'ADD')
GO
