USE [job_dyy_t]
GO

/****** Object:  StoredProcedure [dbo].[SyncMasterFile]    Script Date: 04/04/2022 10:53:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
CREATE procedure [dbo].[SyncMasterFile]
as
begin

--sync Mas_Employee
insert into job_porcheon.dbo.Mas_Employee (EmpCode,PreName,Name,NickName,Accountnumber,Branch,Address,Tel,Remark,Email)
select cd.EmpCode,cd.PreName,cd.Name,cd.NickName,cd.Accountnumber,cd.Branch,cd.Address,cd.Tel,cd.Remark,cd.Email from job_dyy_t.dbo.Mas_Employee cd
left join job_porcheon.dbo.Mas_Employee cs
on cd.EmpCode =cs.EmpCode
where cs.EmpCode is null

insert into job_dyy_t.dbo.Mas_Employee (EmpCode,PreName,Name,NickName,Accountnumber,Branch,Address,Tel,Remark,Email)
select cd.EmpCode,cd.PreName,cd.Name,cd.NickName,cd.Accountnumber,cd.Branch,cd.Address,cd.Tel,cd.Remark,cd.Email from job_porcheon.dbo.Mas_Employee cd
left join job_dyy_t.dbo.Mas_Employee cs
on cd.EmpCode =cs.EmpCode
where cs.EmpCode is null

--Sync Mas_CarLicense
insert into job_porcheon.dbo.Mas_CarLicense
(CarNo,CarLicense,EmpCode,DateStart,CarBrand,ModelYear,CarModel,CarType,CarPic,Status,Weight,CarRefNo,CarRefType)
select cd.CarNo,cd.CarLicense,cd.EmpCode,cd.DateStart,cd.CarBrand,cd.ModelYear,cd.CarModel,cd.CarType,cd.CarPic,cd.Status,cd.Weight,cd.CarRefNo,cd.CarRefType
from job_dyy_t.dbo.Mas_CarLicense cd
left join job_porcheon.dbo.Mas_CarLicense cs
on cd.CarNo=cs.CarNo
where cs.CarNo is null

insert into job_dyy_t.dbo.Mas_CarLicense
(CarNo,CarLicense,EmpCode,DateStart,CarBrand,ModelYear,CarModel,CarType,CarPic,Status,Weight,CarRefNo,CarRefType)
select cd.CarNo,cd.CarLicense,cd.EmpCode,cd.DateStart,cd.CarBrand,cd.ModelYear,cd.CarModel,cd.CarType,cd.CarPic,cd.Status,cd.Weight,cd.CarRefNo,cd.CarRefType
from job_porcheon.dbo.Mas_CarLicense cd
left join job_dyy_t.dbo.Mas_CarLicense cs
on cd.CarNo=cs.CarNo
where cs.CarNo is null

--Sync Mas_Company
insert into job_porcheon.dbo.Mas_Company
select cd.* from job_dyy_t.dbo.Mas_Company cd
left join job_porcheon.dbo.Mas_Company cs
on cd.CustCode=cs.CustCode and cd.Branch=cs.Branch
where cs.CustCode is null

insert into job_dyy_t.dbo.Mas_Company
select cd.* from job_porcheon.dbo.Mas_Company cd
left join job_dyy_t.dbo.Mas_Company cs
on cd.CustCode=cs.CustCode and cd.Branch=cs.Branch
where cs.CustCode is null

--Sync Mas_Vender
insert into job_porcheon.dbo.Mas_Vender
select cd.* from job_dyy_t.dbo.Mas_Vender cd
left join job_porcheon.dbo.Mas_Vender cs
on cd.VenCode=cs.VenCode 
where cs.VenCode is null

insert into job_dyy_t.dbo.Mas_Vender
select cd.* from job_porcheon.dbo.Mas_Vender cd
left join job_dyy_t.dbo.Mas_Vender cs
on cd.VenCode=cs.VenCode 
where cs.VenCode is null
/*
--Sync Job_SrvGroup
insert into job_porcheon.dbo.Job_SrvGroup
select cd.* from job_dyy_t.dbo.Job_SrvGroup cd
left join job_porcheon.dbo.Job_SrvGroup cs
on cd.GroupCode=cs.GroupCode 
where cs.GroupCode is null

insert into job_dyy_t.dbo.Job_SrvGroup
select cd.* from job_porcheon.dbo.Job_SrvGroup cd
left join job_dyy_t.dbo.Job_SrvGroup cs
on cd.GroupCode=cs.GroupCode 
where cs.GroupCode is null

--Sync Job_Single
insert into job_porcheon.dbo.Job_SrvSingle
select cd.* from job_dyy_t.dbo.Job_SrvSingle cd
left join job_porcheon.dbo.Job_SrvSingle cs
on cd.SICode=cs.SICode 
where cs.SICode is null

insert into job_dyy_t.dbo.Job_SrvSingle
select cd.* from job_porcheon.dbo.Job_SrvSingle cd
left join job_dyy_t.dbo.Job_SrvSingle cs
on cd.SICode=cs.SICode 
where cs.SICode is null
*/
/*
--Sync Mas_User
insert into job_porcheon.dbo.Mas_User
select cd.* from job_dyy_t.dbo.Mas_User cd
left join job_porcheon.dbo.Mas_User cs
on cd.UserID=cs.UserID
where cs.UserID is null

insert into job_dyy_t.dbo.Mas_User
select cd.* from job_porcheon.dbo.Mas_User cd
left join job_dyy_t.dbo.Mas_User cs
on cd.UserID=cs.UserID
where cs.UserID is null

--Sync Mas_UserAuth
insert into job_porcheon.dbo.Mas_UserAuth
select cd.* from job_dyy_t.dbo.Mas_UserAuth cd
left join job_porcheon.dbo.Mas_UserAuth cs
on cd.UserID=cs.UserID
and cd.AppID=cs.AppID
and cd.MenuID=cs.MenuID
where cs.UserID is null

insert into job_dyy_t.dbo.Mas_UserAuth
select cd.* from job_porcheon.dbo.Mas_UserAuth cd
left join job_dyy_t.dbo.Mas_UserAuth cs
on cd.UserID=cs.UserID
and cd.AppID=cs.AppID
and cd.MenuID=cs.MenuID
where cs.UserID is null
*/
end

GO


