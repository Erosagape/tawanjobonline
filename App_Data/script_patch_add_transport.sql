alter table Job_LoadInfoDetail alter column Comment nvarchar(max)
alter table Job_LoadInfo alter column Remark nvarchar(max)
alter table Job_LoadInfo add CYAddress nvarchar(max)
alter table Job_LoadInfo add PackingAddress nvarchar(max)
alter table Job_LoadInfo add FactoryAddress nvarchar(max)
alter table Job_LoadInfo add ReturnAddress nvarchar(max)
alter table Job_LoadInfo add CYContact nvarchar(500)
alter table Job_LoadInfo add PackingContact nvarchar(500)
alter table Job_LoadInfo add FactoryContact nvarchar(500)
alter table Job_LoadInfo add ReturnContact nvarchar(500)