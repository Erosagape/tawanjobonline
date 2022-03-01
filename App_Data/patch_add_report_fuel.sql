use job_demo
go
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