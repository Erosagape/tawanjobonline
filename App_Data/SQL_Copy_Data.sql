--Change job_stm to source database
insert into Mas_User select * from job_stm.dbo.Mas_User where UserID='admin'
insert into Mas_UserAuth select * from job_stm.dbo.Mas_UserAuth where UserID='admin'
insert into Mas_UserRole select * from job_stm.dbo.Mas_UserRole 
insert into Mas_UserRoleDetail select * from job_stm.dbo.Mas_UserRoleDetail where UserID='admin'
insert into Mas_UserRolePolicy select * from job_stm.dbo.Mas_UserRolePolicy
insert into Job_SrvGroup select * from job_stm.dbo.Job_SrvGroup
insert into Job_SrvSingle select * from job_stm.dbo.Job_SrvSingle
insert into Mas_Vender select * from job_stm.dbo.Mas_Vender
insert into Mas_Company select * from job_stm.dbo.Mas_Company where CustCode='TAWAN'
insert into Mas_Config select * from job_stm.dbo.Mas_Config