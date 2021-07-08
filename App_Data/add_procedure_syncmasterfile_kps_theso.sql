create procedure SyncMasterFile
as
begin
--Sync Mas_Company
insert into job_kps.dbo.Mas_Company
select cd.* from job_theso.dbo.Mas_Company cd
left join job_kps.dbo.Mas_Company cs
on cd.CustCode=cs.CustCode and cd.Branch=cs.Branch
where cs.CustCode is null

insert into job_theso.dbo.Mas_Company
select cd.* from job_kps.dbo.Mas_Company cd
left join job_theso.dbo.Mas_Company cs
on cd.CustCode=cs.CustCode and cd.Branch=cs.Branch
where cs.CustCode is null

--Sync Mas_Vender
insert into job_kps.dbo.Mas_Vender
select cd.* from job_theso.dbo.Mas_Vender cd
left join job_kps.dbo.Mas_Vender cs
on cd.VenCode=cs.VenCode 
where cs.VenCode is null

insert into job_theso.dbo.Mas_Vender
select cd.* from job_kps.dbo.Mas_Vender cd
left join job_theso.dbo.Mas_Vender cs
on cd.VenCode=cs.VenCode 
where cs.VenCode is null

--Sync Job_SrvGroup
insert into job_kps.dbo.Job_SrvGroup
select cd.* from job_theso.dbo.Job_SrvGroup cd
left join job_kps.dbo.Job_SrvGroup cs
on cd.GroupCode=cs.GroupCode 
where cs.GroupCode is null

insert into job_theso.dbo.Job_SrvGroup
select cd.* from job_kps.dbo.Job_SrvGroup cd
left join job_theso.dbo.Job_SrvGroup cs
on cd.GroupCode=cs.GroupCode 
where cs.GroupCode is null

--Sync Job_Single
insert into job_kps.dbo.Job_SrvSingle
select cd.* from job_theso.dbo.Job_SrvSingle cd
left join job_kps.dbo.Job_SrvSingle cs
on cd.SICode=cs.SICode 
where cs.SICode is null

insert into job_theso.dbo.Job_SrvSingle
select cd.* from job_kps.dbo.Job_SrvSingle cd
left join job_theso.dbo.Job_SrvSingle cs
on cd.SICode=cs.SICode 
where cs.SICode is null

--Sync Mas_User
insert into job_kps.dbo.Mas_User
select cd.* from job_theso.dbo.Mas_User cd
left join job_kps.dbo.Mas_User cs
on cd.UserID=cs.UserID
where cs.UserID is null

insert into job_theso.dbo.Mas_User
select cd.* from job_kps.dbo.Mas_User cd
left join job_theso.dbo.Mas_User cs
on cd.UserID=cs.UserID
where cs.UserID is null

--Sync Mas_UserAuth
insert into job_kps.dbo.Mas_UserAuth
select cd.* from job_theso.dbo.Mas_UserAuth cd
left join job_kps.dbo.Mas_UserAuth cs
on cd.UserID=cs.UserID
and cd.AppID=cs.AppID
and cd.MenuID=cs.MenuID
where cs.UserID is null

insert into job_theso.dbo.Mas_UserAuth
select cd.* from job_kps.dbo.Mas_UserAuth cd
left join job_theso.dbo.Mas_UserAuth cs
on cd.UserID=cs.UserID
and cd.AppID=cs.AppID
and cd.MenuID=cs.MenuID
where cs.UserID is null

end