use job_damon
go
alter table Job_Order alter column CustBranch varchar(5) null
alter table Job_Order alter column CustcontactName varchar(255) null
alter table Job_Order alter column [Description] varchar(MAX) null
alter table Job_Order alter column TRemark varchar(MAX) null
alter table Job_Order alter column InvNo varchar(1000) null
alter table Job_Order alter column InvProduct varchar(1000) null
alter table Job_Order alter column AgentCode varchar(10) null
alter table Job_Order alter column TyClearTaxReson varchar(1000) null
alter table Job_Order alter column ProjectName varchar(1000) null
alter table Job_Order alter column ShippingCmd varchar(1000) null

