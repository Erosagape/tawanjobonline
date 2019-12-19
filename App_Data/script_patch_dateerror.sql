UPDATE dbo.Job_Order SET DocDate=NULL WHERE Year(DocDate)>2100
UPDATE dbo.Job_Order SET ConfirmDate=NULL WHERE Year(ConfirmDate)>2100
UPDATE dbo.Job_Order SET ImExDate=NULL WHERE Year(ImExDate)>2100
UPDATE dbo.Job_Order SET ClearDate=NULL WHERE Year(ClearDate)>2100
UPDATE dbo.Job_Order SET LoadDate=NULL WHERE Year(LoadDate)>2100
UPDATE dbo.Job_Order SET ETDDate=NULL WHERE Year(ETDDate)>2100
UPDATE dbo.Job_Order SET ETADate=NULL WHERE Year(ETADate)>2100
UPDATE dbo.Job_Order SET ETTime=NULL WHERE Year(ETTime)>2100
UPDATE dbo.Job_Order SET CloseJobDate=NULL WHERE Year(CloseJobDate)>2100
UPDATE dbo.Job_Order SET CloseJobTime=NULL WHERE Year(CloseJobTime)>2100
UPDATE dbo.Job_Order SET EstDeliverDate=NULL WHERE Year(EstDeliverDate)>2100
UPDATE dbo.Job_Order SET EstDeliverTime=NULL WHERE Year(EstDeliverTime)>2100
UPDATE dbo.Job_Order SET DutyDate=NULL WHERE Year(DutyDate)>2100
UPDATE dbo.Job_Order SET ConfirmChqDate=NULL WHERE Year(ConfirmChqDate)>2100
UPDATE dbo.Job_Order SET ReadyToClearDate=NULL WHERE Year(ReadyToClearDate)>2100
UPDATE dbo.Job_Order SET CancelDate=NULL WHERE Year(CancelDate)>2100
UPDATE dbo.Job_Order SET CancelTime=NULL WHERE Year(CancelTime)>2100
UPDATE dbo.Job_Order SET CancelProveDate=NULL WHERE Year(CancelProveDate)>2100
UPDATE dbo.Job_Order SET CancelProveTime=NULL WHERE Year(CancelProveTime)>2100
GO
SELECT BranchCode,JNo,DocDate,ConfirmDate,ImExDate,ClearDate,LoadDate,ETDDate,ETADate,ETTime,
CloseJobDate,CloseJobTime,EstDeliverDate,EstDeliverTime,DutyDate,ConfirmChqDate,ReadyToClearDate,
CancelDate,CancelTime,CancelProveDate,CancelProveTime
FROM dbo.Job_Order
GO