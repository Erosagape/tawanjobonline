/****** Object:  StoredProcedure [dbo].[ChangeJobNumber]    Script Date: 08/04/2022 15:18:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ChangeJobNumber]
(
	@fromjob nvarchar(50),
	@tojob nvarchar(50)
)
as
begin
UPDATE dbo.Job_Order SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_ClearExp SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_ClearDetail SET JobNo=@tojob WHERE JobNo=@fromjob
UPDATE dbo.Job_AdvDetail SET ForJNo=@tojob WHERE ForJNo=@fromjob
UPDATE dbo.Job_PaymentDetail SET ForJNo=@tojob WHERE ForJNo=@fromjob
UPDATE dbo.Job_LoadInfo SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_LoadInfoDetail SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_AddFuel SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_AdvHeader SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_Document SET JNo=@tojob WHERE JNo=@fromjob
UPDATE dbo.Job_InvoiceHeader SET RefNo=@tojob WHERE RefNo=@fromjob
UPDATE dbo.Job_CashControlSub SET ForJNo=@tojob WHERE ForJNo=@fromjob
end 
GO


