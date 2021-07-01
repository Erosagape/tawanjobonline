USE [job_speed]
GO
select c.NameEng as 'Customer',
j.HAWB as 'BL',
j.InvNo as 'Inv',
t.TName as 'Transporter',a.TName as 'Agent',
j.InvProduct as 'Product',
j.TotalContainer as 'Qty',
j.ETDDate as 'ETD Date',
j.ETADate as 'ETA Date',
j.VesselName as 'Vessel',
j.ClearPort as 'Customs Port',
j.ClearPortNo as 'Port No',
j.ConfirmDate as 'VGM Date' ,
j.ImExDate as 'DO Date',
j.ReadyToClearDate as 'Pickup Date',
j.DutyDate as 'Duty Date',
j.ClearDate as 'Inspection Date',
j.LoadDate as 'Load Date',
j.EstDeliverDate as 'Unload Date',
j.Description as 'Description',
j.TRemark as 'Remark',
j.ShippingCmd as 'Note'
from Job_Order j inner join Mas_Company c
on j.CustCode=c.CustCode and j.CustBranch=c.Branch
left join Mas_Vender a on j.AgentCode=a.VenCode
left join Mas_Vender t on j.ForwarderCode=t.VenCode
where j.JobStatus<99 {0}