CREATE FUNCTION [dbo].[GetCommission](
@amt float,@emp varchar(50)
) returns float 
as
begin
declare @comm float;

with data as (
select
CommRate,CheckAmt,
SUM(CheckAmt)  over (order by CheckAmt asc rows between unbounded preceding and current row) as BaseAmt
from (
	SELECT (CAST(r.ConfigKey as float)*u.MaxRateDisc) as CheckAmt,CAST(r.ConfigValue as float) as CommRate
	from Mas_Config r,Mas_User u WHERE r.ConfigCode='COMMISSION_STEP'
	AND u.UserID=@emp
) src
)
select @comm=SUM(CommAmt) FROM (
select *,(CASE WHEN @amt>BaseAmt THEN CheckAmt*CommRate ELSE (@amt-(BaseAmt-CheckAmt))*CommRate END) as CommAmt from data
) comm where CommAmt>0

return @comm;
end 
GO
DELETE FROM [dbo].[Mas_Config] WHERE [ConfigCode] Like 'REPORT_%'
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'MAIN_CLITERIA', N'WHERE,c.ClrDate,c.CustCode,j.JNo,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'MAIN_CLITERIA', N'WHERE,c.ClrDate,c.CustCode,j.JNo,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCINC', N'MAIN_SQL', N'SELECT j.CustCode,c.ClrNo,c.ClrDate,c.JobNo,c.SDescription,c.SlipNo,c.VenderCode,c.AmtCharge as TotalCharge,c.Amt,
c.AmtVat,c.AmtWht as TotalWHT,c.InvoiceNo,c.AmtChargeBill as BILLED,c.AmtChargeUnBill as UNBILLED
 FROM (
select h.BranchCode,h.ClrNo,h.ClrDate,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as Amt,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.BNet ELSE 0 END) as AmtCharge,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.ChargeVAT ELSE 0 END) as AmtVat,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.Tax50Tavi ELSE 0 END) as AmtWht,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' THEN d.BNet ELSE 0 END) as AmtChargeBill,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' THEN d.BNet ELSE 0 END) as AmtChargeUnBill
from Job_ClearDetail d inner join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
inner join Job_AdvHeader a ON d.BranchCode=a.BranchCode AND d.AdvNO=a.AdvNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=0 AND s.IsExpense=0)
UNION
select h.BranchCode,h.ClrNo,h.ClrDate,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as Amt,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.BNet ELSE 0 END) as AmtCharge,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.ChargeVAT ELSE 0 END) as AmtVat,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.Tax50Tavi ELSE 0 END) as AmtWht,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' THEN d.BNet ELSE 0 END) as AmtChargeBill,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' THEN d.BNet ELSE 0 END) as AmtChargeUnBill
from (select *,SUBSTRING(VenderBillingNo,0,CHARINDEX(''#'',VenderBillingNo,0)) as VenderInvNo from Job_ClearDetail) d inner join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
inner join Job_PaymentHeader a ON d.BranchCode=a.BranchCode AND d.VenderInvNo=a.DocNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=0 AND s.IsExpense=0)
union
select h.BranchCode,h.ClrNo,h.ClrDate,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as Amt,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.BNet ELSE 0 END) as AmtCharge,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.ChargeVAT ELSE 0 END) as AmtVat,
(CASE WHEN s.IsCredit=0 AND s.IsExpense=0 THEN d.Tax50Tavi ELSE 0 END) as AmtWht,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' THEN d.BNet ELSE 0 END) as AmtChargeBill,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' THEN d.BNet ELSE 0 END) as AmtChargeUnBill
from Job_ClearDetail d inner join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=0 AND s.IsExpense=0)
AND ISNULL(d.AdvNo,'''')='''' AND ISNULL(d.VenderBillingNo,'''')=''''
) c LEFT JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'MAIN_CLITERIA', N'WHERE,t.AdvDate, t.CustCode, t.ForJNo, t.AdvBy, t.ForwarderCode, t.AdvStatus, t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVCLEARING', N'MAIN_SQL', N'SELECT t.DocDate as JobDate,t.ForJNo as JobNo,t.HAWB,t.AgentCode,t.ETADate,t.DutyDate,t.JobTypeName,t.ShipByName,t.AdvBy,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t {0} ORDER BY t.DocDate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'MAIN_CLITERIA', N'AND,a.AdvDate,a.CustCode,d.ForJNo,a.ReqBy,d.VenCode,a.DocStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'MAIN_SQL', N'select 
j.DocDate,j.JNo,j.CustRefNO,ct.CTYName,j.TRemark,
ctn.[4W],ctn.[6W],ctn.[20F],ctn.[40S],ctn.[40H],ctn.[45F],ctn.TotalCont,
j.InvProductQty,j.InvProductUnit,j.VesselName,j.ClearPortNo,l.CYPlace,l.FactoryPlace,j.ETADate,j.LoadDate,l.PackingPlace,
j.ClearDate,j.EstDeliverDate,j.AgentCode,j.MAWB,j.HAWB,j.BookingNo,j.ImExDate,l.FactoryDate,l.FactoryTime,l.ContactName,
l.Remark,l.VenderCode,l.ReturnPlace,j.InvNo,j.InvProduct,j.TyClearTaxReson,j.ShippingCmd,j.DeclareNumber,j.DutyAmount,j.DutyDate,
cl.[CLEARANCE],cl.[2++],cl.[NEXT PAGES],cl.[TRANSPORTATION],cl.[CHARSIS],cl.[THC],cl.[BL/LABOUR],cl.[R-OTHERS],cl.[R-TTL BEFORE VAT],cl.[R-VAT],cl.[R-TOTAL],
cl.[CUSTOMS FEE],cl.[CUSTOMS FEE],cl.[CUSTOMS OT],cl.[CUSTOMS DUTY],cl.[D/O FEE],cl.[PORT CHG],cl.[GATE CHG],cl.[LIFT OFF],cl.DEMURRAGE,cl.DETENSION,cl.[DAMAGE],cl.[B-OTHERS],cl.[B-TTL],
cl.[TOTAL AMOUNT],cl.[APLL-INVOICE],cl.[APLL-BILLING],cl.[INVOICE DATE],
cl.[THC FEE],cl.[BL FEE],cl.[HANDLING FEE],cl.[FREIGHT],cl.[BUNKER],cl.[DEM/DET],cl.[CLEANING FEE],cl.[DAMAGE FEE],cl.[OTHERS],cl.[B-BASE VAT],cl.[B-VAT],cl.[B-ADV TTL]
from Job_Order j left join [jobmaster].[dbo].[Mas_CountryFT] ct
on j.InvFCountry=ct.CTYCODE
left join Job_LoadInfo l on j.BranchCode=l.BranchCode AND j.JNo=l.JNo and j.BookingNo=l.BookingNo
left join 
(SELECT BranchCode,JNo,BookingNo,
SUM(CASE WHEN CTN_SIZE=''4W'' THEN 1 ELSE 0 END) as ''4W'',
SUM(CASE WHEN CTN_SIZE=''6W'' THEN 1 ELSE 0 END) as ''6W'',
SUM(CASE WHEN CTN_SIZE=''D20'' THEN 1 ELSE 0 END) as ''20F'',
SUM(CASE WHEN CTN_SIZE=''D40'' THEN 1 ELSE 0 END) as ''40S'',
SUM(CASE WHEN CTN_SIZE=''D40''''H'' THEN 1 ELSE 0 END) as ''40H'',
SUM(CASE WHEN CTN_SIZE=''D45'' THEN 1 ELSE 0 END) as ''45F'',
COUNT(*) as ''TotalCont''
FROM Job_LoadInfoDetail
WHERE CauseCode<>''99''
GROUP BY BranchCode,JNo,BookingNo
) ctn on l.BranchCode=ctn.BranchCode AND l.BookingNo=ctn.BookingNo AND l.JNo=ctn.JNo
left join 
(
select d.BranchCode,d.JobNo as JNo,
SUM(CASE WHEN d.SICode in(''R-SVC-001'',''R-SVC-002'') THEN d.UsedAmount ELSE 0 END) as ''CLEARANCE'',
SUM(CASE WHEN d.SICode in(''R-SVC-003'') THEN d.UsedAmount ELSE 0 END) as ''2++'',
SUM(CASE WHEN d.SICode in(''R-SVC-004'') THEN d.UsedAmount ELSE 0 END) as ''NEXT PAGES'',
SUM(CASE WHEN d.SICode NOT in(''R-SVT-007'',''R-SNT-007'') AND SICode Like ''R-S_T%'' THEN d.UsedAmount ELSE 0 END) as ''TRANSPORTATION'',
SUM(CASE WHEN d.SICode in(''R-SVT-007'',''R-SNT-007'') THEN d.UsedAmount ELSE 0 END) as ''CHARSIS'',
SUM(CASE WHEN d.SICode in(''R-SVG-005'') THEN d.UsedAmount ELSE 0 END) as ''THC'',
SUM(CASE WHEN d.SICode in(''R-SVG-006'') THEN d.UsedAmount ELSE 0 END) as ''BL/LABOUR'',
SUM(CASE WHEN d.SICode NOT in(''R-SVG-006'',''R-SVG-005'',''R-SVT-007'',''R-SNT-007'',
''R-SVC-004'',''R-SVC-003'',''R-SVC-002'',''R-SVC-001'') AND SICode NOT Like ''R-S_T%'' AND SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-OTHERS'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-TTL BEFORE VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.ChargeVAT ELSE 0 END) as ''R-VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''R-TOTAL'',
SUM(CASE WHEN d.SICode in(''B-ADV-019'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-020'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS OT'',
SUM(CASE WHEN d.SICode in(''B-ADV-018'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS DUTY'',
SUM(CASE WHEN d.SICode in(''B-ADV-022'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''D/O FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-044'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''PORT CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-035'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''GATE CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''LIFT OFF'',
SUM(CASE WHEN d.SICode in(''B-ADV-023'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DEMURRAGE'',
SUM(CASE WHEN d.SICode in(''B-ADV-024'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DETENSION'',
SUM(CASE WHEN d.SICode in(''B-ADV-048'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DAMAGE'',
SUM(CASE WHEN d.SICode NOT in(''B-ADV-048'',''B-ADV-024'',''B-ADV-041'',''B-ADV-015'',
''B-ADV-023'',''B-ADV-039'',''B-ADV-040'',''B-ADV-035'',''B-ADV-044'',''B-ADV-022'',''B-ADV-018'',''B-ADV-020'',''B-ADV-019'') AND SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-OTHERS'',
SUM(CASE WHEN d.SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-TTL'',
SUM(CASE WHEN d.SICode NOT like ''E-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''TOTAL AMOUNT'',
MAX(CASE WHEN d.SICode NOT like ''E-%'' AND d.LinkBillNo like ''BKK%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-INVOICE'',
MAX(CASE WHEN d.SICode NOT like ''E-%'' AND d.LinkBillNo like ''RGM%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-BILLING'',
MAX(i.DocDate) as ''INVOICE DATE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-055'') THEN d.UsedAmount ELSE 0 END) as ''THC FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-005'',''B-ADV-006'',''B-ADV-007'') THEN d.UsedAmount ELSE 0 END) as ''BL FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-058'') THEN d.UsedAmount ELSE 0 END) as ''HANDLING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-043'') THEN d.UsedAmount ELSE 0 END) as ''FREIGHT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-009'') THEN d.UsedAmount ELSE 0 END) as ''BUNKER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-023'',''B-ADV-024'') THEN d.UsedAmount ELSE 0 END) as ''DEM/DET'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-015'') THEN d.UsedAmount ELSE 0 END) as ''CLEANING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-048'') THEN d.UsedAmount ELSE 0 END) as ''DAMAGE FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode not in(''B-ADV-048'',''B-ADV-015'',''B-ADV-023'',''B-ADV-024''
,''B-ADV-009'',''B-ADV-043'',''B-ADV-058'',''B-ADV-005'',''B-ADV-006'',''B-ADV-007'',''B-ADV-055'') AND SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''OTHERS'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''B-BASE VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.ChargeVAT ELSE 0 END) as ''B-VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-ADV TTL''
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
LEFT JOIN Job_InvoiceHeader i 
ON d.BranchCode=i.BranchCode
AND d.LinkBillNo=i.DocNo
WHERE h.DocStatus<>99 AND ISNULL(i.CancelProve,'''')=''''
GROUP BY d.BranchCode,d.JobNo
) cl ON j.BranchCode=cl.BranchCode AND j.JNo=cl.JNo
where j.JobType=1 AND j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'MAIN_CLITERIA', N'WHERE,t.DocDate,t.CustCode,t.RefNo,t.EmpCode,,,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'MAIN_SQL', N'select j.DocDate,j.JNo,b.NameEng as Customer,j.HAWB,jt.JobTypeName,sb.ShipByName,
a.PaymentDate,a.PaymentRef,v.acType,p.BookCode,bk.BookName,a.AdvBy,a.AdvDate,a.AdvNo,
d.SDescription,d.AdvPayAmount as PaidAmount,d.Charge50Tavi as ''TotalWHT'',p.ChqDate,p.ChqNo
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN  dbo.Job_Order j on d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
INNER JOIN (SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt
ON j.JobType=jt.JobType
INNER JOIN (SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') sb
ON j.ShipBy=sb.ShipBy
LEFT JOIN Job_CashControlDoc v ON a.BranchCode=v.BranchCode AND a.PaymentRef=v.ControlNo AND v.DocType=''ADV''
LEFT JOIN Job_CashControlSub p ON v.BranchCode=p.BranchCode AND v.ControlNo=p.ControlNo AND v.acType=p.acType
LEFT JOIN Mas_BookAccount bk ON p.BranchCode=bk.BranchCode AND p.BookCode=bk.BookCode
WHERE a.DocStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPENSE', N'MAIN_SQL', N'SELECT e.NameEng as ''Customer'',i.NameEng as ''Consignee'',
c.InvProduct as ''Products'',c.TotalContainer as ''Containers'',
c.BookingNo as ''Booking'',
c.HAWB as ''BL/AWB'',c.CSCode as ''CS'',v.TName as ''Vender'',
b.ForJNo as ''Job Number'',c.DeclareNumber as ''Customs Declare'',
c.DocDate as ''Job Date'',
SUM(CASE WHEN b.SICode='''' THEN b.AdvNet ELSE 0 END) as ''(N/A)'',SUM(CASE WHEN b.SICode=''ADV-001'' THEN b.AdvNet ELSE 0 END) as ''ค่าภาษีอากร'',SUM(CASE WHEN b.SICode=''ADV-019'' THEN b.AdvNet ELSE 0 END) as ''ค่า ฺB/L'',SUM(CASE WHEN b.SICode=''ERN-001'' THEN b.AdvNet ELSE 0 END) as ''ค่ามัดจำตู้'',
SUM(b.AdvNet) as ''Advance Paid'',a.EmpCode as ''Request By'',
SUM(d.ClrNet) as ''Clearing'',c.CloseJobDate as ''Close Job Date''
FROM Job_AdvDetail b
INNER JOIN Job_AdvHeader a ON b.BranchCode=a.BranchCode 
AND b.AdvNo= a.AdvNo
INNER JOIN Job_Order c ON b.BranchCode=c.BranchCode
AND b.ForJNo=c.JNo
INNER JOIN Mas_Company e ON e.CustCode=c.CustCode AND e.Branch=c.CustBranch
LEFT JOIN (Select CustCode,MAX(Branch) as Branch,MAX(NameEng) as NameEng from Mas_Company Group by CustCode) i ON i.CustCode=c.CustCode 
LEFT JOIN (
    SELECT ch.BranchCode,cd.AdvNo,cd.AdvItemNo,SUM(cd.BNet) as ClrNet
    FROM Job_ClearHeader ch INNER JOIN Job_ClearDetail cd
    ON ch.BranchCode=cd.BranchCode AND 
    ch.ClrNo=cd.ClrNo
    WHERE ch.DocStatus<>99
    GROUP BY ch.BranchCode,cd.AdvNo,cd.AdvItemNo
) d
ON b.BranchCode=d.BranchCode
AND b.AdvNo=d.AdvNo
AND b.ItemNo=d.AdvItemNo
LEFT JOIN Mas_Vender on c.ForwarderCode=v.VenCode
WHERE a.DocStatus<>99 AND b.AdvNet>0 {0}
GROUP BY e.NameEng,i.NameEng,c.InvProduct,c.TotalContainer,c.BookingNo,c.HAWB,
c.CSCode,v.TName,b.ForJNo,c.DeclareNumber,c.DocDate,a.EmpCode,c.CloseJobDate
ORDER BY e.NameEng,b.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'MAIN_CLITERIA', N'AND,t.ETDDate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVEXPORT', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETDDate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType=2 AND t.JobStatus<>99  {0} ORDER BY t.ETDDate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'MAIN_SQL', N'SELECT bl.BillAcceptNo,bl.BillDate,bl.CustCode,bl.InvNo,bl.AmtAdvance,bl.AmtChargeNonVAT,bl.AmtChargeVAT,bl.AmtVAT,bl.AmtWH,bl.AmtTotal 
FROM (
SELECT h.BranchCode, h.BillAcceptNo, h.BillDate, h.CustCode, h.CustBranch, h.BillRecvBy, h.BillRecvDate, h.DuePaymentDate, h.BillRemark, h.CancelReson, 
h.CancelProve, h.CancelDate, h.CancelTime, h.EmpCode, h.RecDateTime, h.TotalCustAdv, h.TotalAdvance, h.TotalChargeVAT, h.TotalChargeNonVAT, h.TotalVAT, 
h.TotalWH, h.TotalDiscount, h.TotalNet, d.ItemNo, d.InvNo, i.AmtAdvance, i.AmtChargeNonVAT, i.AmtChargeVAT, i.AmtWH, i.AmtVAT, i.AmtTotal, d.CurrencyCode, 
d.ExchangeRate, d.AmtCustAdvance, d.AmtForeign, d.InvDate, d.RefNo, d.AmtVATRate, d.AmtWHRate, d.AmtDiscount, d.AmtDiscRate
FROM dbo.Job_BillAcceptHeader AS h INNER JOIN
dbo.Job_BillAcceptDetail AS d ON h.BranchCode = d.BranchCode AND h.BillAcceptNo=d.BillAcceptNo 
INNER JOIN (
	SELECT a.BranchCode,a.DocNo,SUM(b.AmtAdvance) as AmtAdvance,
	SUM(CASE WHEN b.AmtCharge >0 AND b.AmtVAT>0 THEN b.AmtCharge ELSE 0 END) as AmtChargeVAT,
	SUM(CASE WHEN b.AmtCharge >0 AND b.AmtVAT=0 THEN b.AmtCharge ELSE 0 END) as AmtChargeNonVAT,
	SUM(CASE WHEN b.AmtCharge >0 AND b.AmtVAT>0 THEN b.AmtVat ELSE 0 END) as AmtVAT,
	SUM(CASE WHEN b.AmtCharge >0 AND b.Amt50Tavi>0 THEN b.Amt50Tavi ELSE 0 END) as AmtWH,
	SUM(b.TotalAmt) as AmtTotal
	FROM Job_InvoiceHeader a INNER JOIN Job_InvoiceDetail b
	ON a.BranchCode=b.BranchCode AND a.DocNo=b.DocNo
        WHERE ISNULL(a.CancelProve,'''')=''''
	GROUP BY a.BranchCode,a.DocNo
) i ON d.BranchCode=i.BranchCode AND d.InvNo=i.DocNo
WHERE ISNULL(h.CancelProve,'''')='''' {0}
) bl ORDER BY bl.BillDate,bl.BillAcceptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'MAIN_CLITERIA', N'AND,b.VoucherDate,,,b.RecUser,,,b.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BOOKBAL', N'MAIN_SQL', N'SELECT bk.BookCode,bk.LimitBalance,bk.SumCashOnhand,bk.SumChqClear,bk.SumChqOnhand,bk.SumCredit+bk.SumChqReturn as SumCreditable,bk.SumBal as 
TotalBalance FROM (
SELECT q.*,q.SumCashOnhand+q.SumChqClear as SumCash,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand-q.LimitBalance as SumCashInBank,
q.SumCashOnhand+q.SumChqClear+q.SumChqOnhand+q.SumCredit as SumBal,
q.SumCredit+q.SumChqReturn as SumCreditable
FROM (
select c.BookCode,c.LimitBalance,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount) else a.CashAmount end) as SumCashOnhand,
Sum(Case when a.ChqStatus=''P'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqClear,
Sum(Case when a.ChqStatus=''R'' then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqReturn,
Sum(Case when a.ChqStatus NOT IN(''P'',''R'') then (CASE WHEN a.PRType=''P'' THEN -1*a.ChqAmount ELSE a.ChqAmount end) else 0 end) as SumChqOnhand,
Sum(Case when a.PRType=''P'' then -1*a.CreditAmount else a.CreditAmount end) as SumCredit,
Sum(Case when a.PRType=''P'' then -1*(a.CreditAmount) else 0 end) as SumAP,
Sum(Case when a.PRType=''R'' then (a.CreditAmount) else 0 end) as SumAR,
Sum(Case when a.PRType=''P'' then -1*(a.CashAmount+a.ChqAmount) else 0 end) as SumPV,
Sum(Case when a.PRType=''R'' then (a.CashAmount+a.ChqAmount) else 0 end) as SumRV
from Job_CashControlSub a inner join Job_CashControl b
on a.BranchCode=b.BranchCode and a.ControlNo=b.ControlNo
left join Mas_BookAccount c 
on a.BookCode=c.BookCode
WHERE ISNULL(b.CancelProve,'''')='''' AND a.PRType<>'''' {0}
group by c.BookCode,c.LimitBalance) q
) bk ORDER BY BookCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'MAIN_CLITERIA', N'WHERE,GetDate(),d.CustCode,,,d.VenderCode,,d.BranchCode,d.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BUYRATE', N'MAIN_SQL', N'select h.LocationRoute as WorkType,d.VenderCode,d.CustCode,d.SDescription as CostName,d.CostAmount,s.NameThai as ChargeName ,d.ChargeAmount,
d.ChargeAmount-d.CostAmount as Profit
from Job_TransportPrice d inner join Job_TransportRoute h
ON d.LocationID=h.LocationID
left join Job_SrvSingle s 
ON d.ChargeCode=s.SICode
{0}
ORDER BY d.SDescription,d.ChargeAmount-d.CostAmount DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,ControlNo,VoucherDate,DocUsed,AmountUsed,AmountRemain,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU'' {0}
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' 
) t ORDER BY CustCode,ChqDate,ChqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'MAIN_CLITERIA', N'AND,a.ChqDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,AmountUsed,AmountRemain,DocUsed,ControlNo,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,RecvBank,RecvBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.RecvBank,h.RecvBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.RecvBank,h.RecvBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.RecvBank=c.RecvBank AND a.RecvBranch=c.RecvBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.RecvBank,h.RecvBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.RecvBank,h.RecvBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.RecvBank=d.RecvBank AND a.RecvBranch=d.RecvBranch 
WHERE a.acType=''CU''
AND a.PRType=''R'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' {0}
) t ORDER BY CustCode,ChqDate,ChqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'MAIN_CLITERIA', N'AND,h.ClrDate,j.CustCode,j.JNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'MAIN_SQL', N'select c.JNo,a.AdvNo,b.ClrNo,b.ClrDate,c.CustCode,d.NameThai as SDescription,a.VenderCode,a.Date50Tavi as SlipDate,a.UsedAmount,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as SumCharge,a.ChargeVAT as AmtVat,a.Tax50Tavi as Amt50Tavi,
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ''Invoice Billed'',
(CASE WHEN NOT ISNULL(a.LinkBillNo,'''')<>'''' AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as TotalBalance,a.LinkBillNo
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where b.DocStatus<>99 {0}
    order by a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'MAIN_CLITERIA', N'AND,j.DutyDate,j.CustCode, j.JNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRSUMMARY', N'MAIN_SQL', N'SELECT cl.ClrNo,cl.ClrDate,cl.JobNo,cl.DutyDate,SUM(cl.UsedAmount) as UsedAmount,SUM(cl.ChargeVAT) as AmtVat,SUM(cl.Tax50Tavi) as TotalWHT,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=1 THEN cl.BNet ELSE 0 END) as SumAdvance,SUM(CASE WHEN cl.IsExpense=1 THEN cl.BNet ELSE 0 END) as SumCost,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=0 THEN cl.BNet ELSE 0 END) as SumCharge,cl.LinkBillNo as InvoiceNo FROM (select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,j.DutyDate,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
 WHERE h.DocStatus<>99 {0} ) cl WHERE cl.ClrNet > 0 GROUP BY cl.ClrNo,cl.ClrDate,cl.JobNo,cl.DutyDate,cl.LinkBillNo ORDER BY cl.ClrDate,cl.ClrNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'MAIN_CLITERIA', N'AND,a.DocDate,a.CustCode,,a.EmpCode,,,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CNDN', N'MAIN_SQL', N'SELECT CustCode,DocDate,DocNo,InvoiceNo,TotalAmt as ''Amount'',TotalVAT,TotalWHT,TotalNet FROM (
SELECT a.*,b.InvoiceNo,
b.TotalAmt,b.TotalVAT,b.TotalWHT,b.TotalNet,b.FTotalNet
FROM Job_CNDNHeader a LEFT JOIN
(
    SELECT BranchCode,DocNo,
    (SELECT STUFF((
SELECT DISTINCT '','' + BillingNo
FROM Job_CNDNDetail WHERE BranchCode=d.BranchCode
AND DocNo=d.DocNo  
    FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
    )) as InvoiceNo,
    Sum(DiffAmt) as TotalAmt,
    Sum(VATAmt) as TotalVAT,
    Sum(WHTAmt) as TotalWHT,
    Sum(TotalNet) as TotalNet,
    Sum(ForeignNet) as FTotalNet
    FROM Job_CNDNDetail d
    GROUP BY BranchCode,DocNo
) b
ON a.BranchCode=b.BranchCode
AND a.DocNo=b.DocNo
 WHERE a.DocStatus<>99 AND ISNULL(a.ApproveBy,'''')<>'''' {0}) t ORDER BY CustCode,DocDate,DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CREDITADV', N'MAIN_SQL', N'select a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.DocType=''CLR''
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+''#''+Convert(varchar,b.ItemNo))=e.DocNo
WHERE a.DocStatus>2 AND a.DocStatus<99 AND a.AdvType=5 {0}
GROUP BY
a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,e.ReceiveRef,e.PaidAmount
ORDER BY a.EmpCode,a.PaymentDate,a.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'MAIN_CLITERIA', N'AND,c.DutyDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode, c.JobStatus,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'MAIN_SQL', N'WITH rcv
AS 
(
select r.*,
CAST(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',0) as float) as CashAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',0) as CashBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',1) as CashRef,
CAST(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',0) as float) as ChqAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',0) as ChqBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',1),'';'',0) as ChqRef,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'';'',1),'':'',1) as BankChg
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.Remark,c.LnNO as CustNo,rh.CurrencyCode,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
rd.InvoiceNo as InvNo
from 
(
SELECT *,(CASE WHEN SUBSTRING(TRemark,1,2)=''CH'' THEN ''CASH;'' + TRemark ELSE TRemark END) as Remark 
FROM
Job_ReceiptHeader
WHERE ISNULL(CancelProve,'''')=''''
)
rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.Remark,rh.CancelProve
,c.LnNO,rh.CurrencyCode,rd.InvoiceNo
) r
)
SELECT rcv.CustNo,''CA'' as ''PayType'',RIGHT(''0''+CAST(Month(rcv.ReceiptDate) as varchar),2)+RIGHT(''0''+CAST(DAY(rcv.ReceiptDate) as varchar),2)+SUBSTRING(rcv.CustCode,1,2) as ''Chq.No'',
rcv.CashAmount as ''Chq.Amt'',rcv.InvNo,rcv.TotalReceipt,rcv.CurrencyCode,rcv.TotalWhtax,
(CASE WHEN rcv.TotalWhtax>0 THEN ''A04'' ELSE '''' END) as ''DeductReason'',Convert(varchar,rcv.ReceiptDate,101) as ''Deposit'','''' as ACCT,'''' as CT
FROM rcv where rcv.CashAmount>0 AND SUBSTRING(rcv.CashRef,1,2)<>''TR'' 
UNION
SELECT rcv.CustNo,''WT'' as ''PayType'',RIGHT(''0''+CAST(Month(rcv.ReceiptDate) as varchar),2)+RIGHT(''0''+CAST(DAY(rcv.ReceiptDate) as varchar),2)+SUBSTRING(rcv.CustCode,1,2) as ''Chq.No'',
rcv.CashAmount as ''Chq.Amt'',rcv.InvNo,rcv.TotalReceipt,rcv.CurrencyCode,rcv.TotalWhtax,
(CASE WHEN rcv.TotalWhtax>0 THEN ''A04'' ELSE '''' END) as ''DeductReason'',Convert(varchar,rcv.ReceiptDate,101) as ''Deposit'','''' as ACCT,'''' as CT
FROM rcv where rcv.CashAmount>0 AND SUBSTRING(rcv.CashRef,1,2)=''TR'' 
UNION
SELECT rcv.CustNo,''CK'' as ''PayType'',RIGHT(rcv.ChqRef,6) as ''Chq.No'',rcv.ChqAmount as ''Chq.Amt'',rcv.InvNo,rcv.TotalReceipt,rcv.CurrencyCode,rcv.TotalWhtax,
(CASE WHEN rcv.TotalWhtax>0 THEN ''A04'' ELSE '''' END) as ''DeductReason'',Convert(varchar,rcv.ReceiptDate,101) as ''Deposit'','''' as ACCT,'''' as CT
FROM rcv where rcv.ChqAmount>0')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'MAIN_SQL', N'select e.NameEng as ''Customer'',t.English as ''Agent'',
c.JNo as ''Job Number'',c.HAWB as ''AWB/BL No'',a.AdvNo as ''Advance No'',c.DutyDate as ''Inspection Date'',
b.ClrDate as ''Clearing Date'',c.TotalContainer as ''Container Number'',
a.SlipNO as ''Slip No'',a.Date50Tavi as ''Slip Date'',
a.AdvAmount as ''Container Deposit'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Addition Expenses'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Deposit Return'',
a.LinkBillNo as ''Receipt#'',v.VoucherDate as ''Received Date''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
left join Mas_Vender t on c.ForwarderCode=t.VenCode
where ISNULL(b.CancelProve,'''')='''' AND d.GroupCode IN(''ERN'',''B-DEP'') AND a.UsedAmount>0 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'MAIN_CLITERIA', N'AND,h.DocDate,,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDAILY', N'MAIN_SQL', N'SELECT pa.DocNo,pa.DocDate,pa.ApproveDate,pa.VenCode,pa.PoNo,pa.RefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total as TotalNet,pa.PayType,pa.PaymentRef FROM (
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.ApproveDate,h.PaymentRef,
h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo 
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' {0}
) pa ORDER BY pa.DocDate,pa.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'MAIN_CLITERIA', N'AND,h.DocDate,,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EXPDETAIL', N'MAIN_SQL', N'SELECT pa.DocNo,pa.DocDate,pa.VenCode,pa.BookingRefNo,pa.ClrRefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total as TotalNet,pa.PayType,pa.PaymentDate,pa.PaymentRef,pa.ForJNo FROM (
SELECT h.BranchCode, h.DocNo, h.DocDate, h.VenCode, v.TaxNumber, v.TName, v.English, v.TAddress1, v.TAddress2, v.EAddress1, v.EAddress2, v.Phone, v.FaxNumber, 
v.GLAccountCode, v.ContactAcc, v.ContactSale, v.ContactSupport1, v.ContactSupport2, v.ContactSupport3, v.WEB_SITE, h.ContactName, h.EmpCode, h.PoNo, h.PaymentDate,h.PaymentRef,
h.VATRate, h.TaxRate, h.TotalExpense, h.TotalTax, h.TotalVAT, h.TotalDiscount, h.TotalNet, h.Remark, h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, 
h.CurrencyCode, h.ExchangeRate, h.ForeignAmt, h.RefNo, h.PayType, d.ItemNo, d.SICode, d.SDescription, d.SRemark, d.Qty, d.QtyUnit, d.UnitPrice, d.IsTaxCharge, 
d.Is50Tavi, d.DiscountPerc, d.Amt, d.AmtDisc, d.AmtVAT, d.AmtWHT, d.Total, d.FTotal, d.ForJNo,d.ClrRefNo,d.BookingRefNo
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode LEFT OUTER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
WHERE ISNULL(h.CancelProve,'''')='''' {0}
) pa ORDER BY pa.SDescription,pa.DocDate,pa.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'MAIN_CLITERIA', N'AND,c.DutyDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.BillIssueDate,inv.BillAcceptNo,inv.BillAcceptDate,inv.DueDate,inv.SDescription,inv.Amt,
inv.AmtVat,  
inv.AmtCredit,
inv.Amt50Tavi,
inv.TotalInv as TotalNet,inv.CreditNet as ''Adjust Amount'',inv.ReceivedNet as TotalReceived,inv.ReceiptNo,inv.LastVoucher FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv ORDER BY inv.DocDate,inv.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,ih.RefNo, ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode,id.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'MAIN_SQL', N'SELECT 
(CASE WHEN inv.CancelProve<>'''' THEN ''*''+inv.DocNo ELSE inv.DocNo END) as DocNo
,inv.DocDate,inv.CustCode,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.AmtAdvance END) as TotalAdvance,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.AmtCharge END) as TotalCharge,
sum(CASE WHEN inv.CancelProve<>'''' OR inv.AmtCharge=0 THEN 0 ELSE inv.AmtVat END) as TotalVAT,
sum(CASE WHEN inv.CancelProve<>'''' OR inv.AmtCharge=0 THEN 0 ELSE inv.Amt50Tavi END) as Total50Tavi,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.AmtCredit END) as TotalPrepaid,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.TotalInv END) as TotalNet,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE ISNULL(inv.CreditNet,0) END) as TotalCredit,
sum(case when inv.BillAcceptNo='''' AND NOT inv.CancelProve<>'''' THEN inv.TotalInv ELSE 0 END) as UNBILLED,
sum(case when inv.BillAcceptNo<>'''' AND NOT inv.CancelProve<>'''' THEN inv.TotalInv ELSE 0 END) as BILLED,
sum(CASE WHEN inv.CancelProve<>'''' THEN 0 ELSE inv.ReceivedNet END) as TotalReceived,
max(CASE WHEN inv.CancelProve<>'''' THEN '''' ELSE inv.LastVoucher END) as VoucherNo 
FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id right join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
{0}
) inv 
GROUP BY inv.DocNo,inv.CancelProve,inv.DocDate,inv.RefNo,inv.CustCode
ORDER BY inv.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'MAIN_CLITERIA', N'AND,f.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'MAIN_SQL', N'SELECT t.PaymentDate,t.AdvNo,t.JobNo,t.ReqBy,t.SDescription,t.PaymentRef,t.DocStatus,t.AdvNet,t.UsedAmount,t.AdvBalance FROM (
Select a.BranchCode,'''' as ClrNo,0 as ItemNo,0 as LinkItem,
a.STCode,a.SICode,a.SDescription,a.VenCode as VenderCode,
a.AdvQty as Qty,b.UnitCharge as UnitCode,a.CurrencyCode,a.ExchangeRate as CurRate,
(CASE WHEN b.IsExpense=0 THEN a.UnitPrice ELSE 0 END) as UnitPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice ELSE 0 END) as FPrice,
(CASE WHEN b.IsExpense=0 THEN a.AdvQty*a.UnitPrice*a.ExchangeRate ELSE 0 END) as BPrice,
q.TotalCharge as QUnitPrice,a.AdvQty*q.ChargeAmt as QFPrice,a.AdvQty*q.ChargeAmt*q.CurrencyRate as QBPrice,
a.UnitPrice as UnitCost,a.AdvQty*a.UnitPrice as FCost,a.AdvQty*a.UnitPrice*a.ExchangeRate as BCost,
a.ChargeVAT,a.Charge50Tavi as Tax50Tavi,a.AdvNo as AdvNO,d.AdvDate,a.ItemNo as AdvItemNo,a.AdvAmount,a.AdvNet,
a.AdvNet-ISNULL(d.TotalCleared,0) as AdvBalance,ISNULL(d.TotalCleared,0) as UsedAmount,
(CASE WHEN ISNULL(q.QNo,'''')='''' THEN 0 ELSE 1 END) as IsQuoItem,
a.IsDuplicate,b.IsExpense,
b.IsLtdAdv50Tavi,(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN '''' ELSE a.PayChqTo END) as Pay50TaviTo,a.Doc50Tavi as NO50Tavi,NULL as Date50Tavi,
(CASE WHEN CHARINDEX(''#'',a.PayChqTo,0)>0 THEN a.PayChqTo ELSE '''' END) as VenderBillingNo,'''' as SlipNO,'''' as Remark,
(SELECT STUFF((
	SELECT DISTINCT '','' + Convert(varchar,QtyBegin) + ''-''+convert(varchar,QtyEnd)+''=''+convert(varchar,ChargeAmt)
	FROM Job_QuotationItem WHERE BranchCode=q.BranchCode
	AND QNo=q.QNo AND SICode=q.SICode AND VenderCode =q.VenderCode
	AND UnitCheck=q.UnitCheck AND CalculateType=1
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AirQtyStep,q.CalculateType as StepSub,
a.ForJNo as JobNo,a.IsChargeVAT as VATType,a.VATRate,a.Rate50Tavi as Tax50TaviRate,q.QNo,
c.DocStatus,c.AdvBy,c.EmpCode as ReqBy,c.PaymentDate,c.CustCode,c.PaymentRef
FROM Job_AdvDetail a LEFT JOIN Job_SrvSingle b on a.SICode=b.SICode
INNER JOIN Job_AdvHeader c on a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo 
left join Job_Order j on a.BranchCode=j.BranchCode and a.ForJNo=j.JNo
left join 
(
	select qh.BranchCode,qh.QNo,
	qd.JobType,qd.ShipBy,qd.SeqNo,
	qi.ItemNo,qi.SICode,qi.CalculateType,
	qi.QtyBegin,qi.QtyEnd,qi.UnitCheck,qi.CurrencyCode,
	qi.CurrencyRate,qi.ChargeAmt,qi.Isvat,qi.VatRate,
	qi.VatAmt,qi.IsTax,qi.TaxRate,qi.TaxAmt,
	qi.TotalAmt,qi.TotalCharge,qi.UnitDiscntPerc,qi.UnitDiscntAmt,
	qi.VenderCode,qi.VenderCost,qi.BaseProfit,qi.CommissionPerc,qi.CommissionAmt,
	qi.NetProfit,qi.IsRequired
	from Job_QuotationHeader qh	inner join Job_QuotationDetail qd ON qh.BranchCode=qd.BranchCode and qh.QNo=qd.QNo
	inner join Job_QuotationItem qi	on qd.BranchCode=qi.BranchCode and qd.QNo=qi.QNo and qd.SeqNo=qi.SeqNo 
    where qh.DocStatus=3 
) q
on a.BranchCode=q.BranchCode and b.SICode=q.SICode and ISNULL(a.VenCode,b.DefaultVender)=q.VenderCode 
and b.UnitCharge=q.UnitCheck and a.AdvQty <=q.QtyEnd and a.AdvQty>=q.QtyBegin and q.QNo=j.QNo
left join 
(
	SELECT ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,
    SUM(ISNULL(cd.BNet,0)) as TotalCleared    
	FROM Job_ClearDetail cd INNER JOIN Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode	and cd.ClrNo =ch.ClrNo 	and ch.DocStatus<>99
    INNER JOIN Job_AdvDetail ad on cd.BranchCode=ad.BranchCode and cd.AdvNO=ad.AdvNo and cd.AdvItemNo=ad.ItemNo
    INNER JOIN Job_AdvHeader ah on ad.BranchCode=ah.BranchCode and ad.AdvNo=ah.AdvNo
    WHERE ah.DocStatus<>99 AND ch.DocStatus<>99 
	GROUP BY ad.BranchCode,ad.AdvNo,ad.ItemNo,ah.AdvDate,ad.IsDuplicate,ad.AdvNet
) d
ON a.BranchCode=d.BranchCode and a.AdvNo=d.AdvNo and a.ItemNo=d.ItemNo
WHERE c.DocStatus<90 {0} ) t ORDER BY t.ReqBy,t.PaymentDate,t.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'MAIN_CLITERIA', N'AND,jd.ConfirmDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'MAIN_SQL', N'SELECT j.DocDate,j.DutyDate as InspectionDate,j.JNo,jt.JobTypeName,sb.ShipByName
,c.NameEng as Customer,e.NameEng as Consignee,j.DeliveryTo as Shipper,v.TName as Agent,
j.InvProduct,j.InvNo,j.HAWB,j.DeclareNumber,j.ETDDate,j.ETADate,j.LoadDate,j.EstDeliverDate as UnloadDate,j.TotalContainer,
cl.SumCost,cl.SumAdvance,cl.SumCharge,cl.Profit,
j.CSCode,j.ShippingEmp,ad.TotalAdvance,ad.TotalExpClear,ad.TotalPayback,ad.TotalReturn,
cl.TotalEarnest,cl.DepositReturnDate,
j.CloseJobDate
FROM dbo.Job_Order AS j 
 LEFT JOIN (
 SELECT h.BranchCode,d.ForJNo,
 SUM(d.AdvNet) as TotalAdvance,
 SUM(ISNULL(c.BNet,0)) AS TotalExpClear,
 SUM(CASE WHEN c.BNet >d.AdvNet AND c.BNet>0 THEN c.BNet-d.AdvNet ELSE 0 END) as TotalPayback,
 SUM(CASE WHEN c.BNet <d.AdvNet AND c.BNet>0 THEN d.AdvNet-c.BNet ELSE 0 END) as TotalReturn
 FROM Job_AdvDetail d INNER JOIN Job_AdvHeader h
 ON h.BranchCode=d.BranchCode AND h.AdvNo=d.AdvNo
 left join (
	SELECT a.BranchCode,b.AdvNO,b.AdvItemNo,SUM(b.BNet) as BNet
	FROM Job_ClearDetail b INNER JOIN Job_ClearHeader a
	ON b.BranchCode=a.BranchCode AND b.ClrNo=a.ClrNo
	WHERE a.DocStatus<>99
	GROUP BY a.BranchCode,b.AdvNO,b.AdvItemNo
 ) c ON d.BranchCode=c.BranchCode AND d.AdvNo=c.AdvNO AND d.ItemNo=c.AdvItemNo
 WHERE h.DocStatus<>99
 GROUP BY h.BranchCode,d.ForJNo
 ) ad ON j.BranchCode=ad.BranchCode AND j.JNo=ad.ForJNo
 LEFT JOIN ( 
 SELECT ch.BranchCode,cd.JobNo,
 SUM(CASE WHEN sv.IsExpense=1 AND cd.LinkItem=0 THEN cd.BNet ELSE 0 END) AS SumCost,
 SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumAdvance,
 SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumCharge,
 SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 AND cd.LinkItem=0 THEN cd.BNet ELSE 0 END) as Profit,
 SUM(CASE WHEN CHARINDEX(''ERN'',cd.SICode)>0 OR CHARINDEX(''B-DEP'',cd.SICode)>0 THEN cd.BNet ELSE 0 END) AS TotalEarnest,
 (SELECT TOP 1 VoucherDate FROM Job_CashControl WHERE BranchCode=ch.BranchCode AND ControlNo= MAX(CASE WHEN CHARINDEX(''ERN'',cd.SICode)>0 And cd.LinkBillNo<>'''' THEN cd.LinkBillNo ELSE '''' END) ) AS DepositReturnDate
 FROM dbo.Job_ClearDetail AS cd 
 LEFT JOIN  dbo.Job_ClearHeader AS ch 
 ON cd.BranchCode = ch.BranchCode 
 AND cd.ClrNo=ch.ClrNo 
 LEFT JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
 WHERE  (isnull(ch.DocStatus,0)<>99) 
 GROUP BY ch.BranchCode,cd.JobNo
 ) cl
 on j.BranchCode=cl.BranchCode AND j.JNo=cl.JobNo
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON j.ShipBy=sb.ShipBy
INNER JOIN dbo.Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT JOIN (SELECT CustCode,MAX(Branch) as Branch,MAX(NameEng) as NameEng FROM dbo.Mas_Company GROUP BY CustCode) e ON j.CustCode=e.CustCode AND j.CustBranch=e.Branch
LEFT JOIN Mas_Vender v ON j.ForwarderCode=v.VenCode {0}
ORDER BY j.DocDate,j.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.DeclareNumber,j.VesselName,j.LoadDate,j.DutyDate,j.ShippingEmp,j.HAWB,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j ORDER BY j.LoadDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBFOLLOWUP', N'MAIN_SQL', N'SELECT j.JNo,j.DeclareNumber,j.HAWB,j.ConfirmDate,j.ImExDate,j.CloseJobDate,j.JobStatus,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.Consigneecode,j.InvProduct,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j ORDER BY j.JobStatus,j.JNo DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'MAIN_CLITERIA', N'AND,jd.CreateDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.DeclareTypeName FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ShipBy,j.CustCode,j.JobType,j.DocDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHP', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.VesselName,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.ShippingCmd FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ShippingEmp DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.ManagerCode,j.AgentCode, j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'MAIN_SQL', N'SELECT t.LoadDate,t.NotifyCode,t.VenderCode,t.JNo,t.BookingNo,t.CTN_NO,t.CTN_SIZE,t.TruckNO,t.TruckType,t.Location,
(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as JobStatus,
t.CountBill,t.CountClear
FROM (
SELECT a.*,ISNULL(b.CountBill,0) as CountBill,ISNULL(b.CountClear,0) as CountClear, 
ISNULL(b.CountBill,0)-ISNULL(b.CountClear,0) as CountBalance,c.LoadDate,c.NotifyCode,c.VenderCode
FROM Job_LoadInfoDetail a LEFT JOIN(
    SELECT h.BranchCode,d.BookingRefNo,d.BookingItemNo,COUNT(*) as CountBill,
    SUM(CASE WHEN ISNULL(d.ClrReFNo,'''')<>'''' THEN 1 ELSE 0 END) as CountClear
    FROM Job_PaymentDetail d INNER JOIN Job_PaymentHeader h 
    ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
    WHERE ISNULL(h.CancelProve,'''')='''' GROUP BY h.BranchCode,d.BookingRefNo,d.BookingItemNo
) b ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingRefNo AND a.ItemNo=b.BookingItemNo
 INNER JOIN Job_LoadInfo c ON a.BranchCode=c.BranchCode AND a.BookingNo=c.BookingNo
WHERE c.LoadDate IS NOT NULL  {0} ) t ORDER BY t.VenderCode,t.LoadDate')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.ShippingEmp,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTYPE', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.VesselName,j.DeliveryNo FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.JobType,j.CustCode,j.ShipBy,j.DocDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'MAIN_CLITERIA', N'WHERE,jd.CreateDate,jd.CustCode,jd.JNo,jd.CSCode,jd.AgentCode,jd.JobStatus,jd.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'MAIN_SQL', N'select j.CustCode as ''Customer'',j.JNo as ''Job Number'',j.DeclareNumber as ''Customs Declare#'',j.InvNo as ''Commercial Invoice#''
,j.CSCode as ''CS'',j.CreateDate as ''Job Creation Date'',j.CloseJobDate as ''Job Close Date'',j.JobStatus as ''JobStatus'',
ISNULL(a.TotalAdvPay,0) as ''Invoice To Customer-Advance'',
ISNULL(c.TotalService,0) as ''Invoice To Customer-Service'',
ISNULL(c.TotalAdvClear,0) as ''Payment To Vender-Advance'',
ISNULL(c.TotalCost,0) as ''Payment To Vender-Cost'',
ISNULL(c.TotalDeposit,0) as ''Payment To Vender-Deposit'',
ISNULL(c.TotalService,0)-ISNULL(c.TotalCost,0) as ''Profit'',
ISNULL(c.TotalAdvBill,0) as ''Customer Billed-Advance'',
ISNULL(c.TotalServiceBill,0) as ''Customer Billed-Service'',
ISNULL(c.TotalAdvUnBill,0) as ''Customer Unbilled-Advance'',
ISNULL(c.TotalServiceUnBill,0) as ''Customer Unbilled-Service'',
ISNULL(p.TotalVenderBill,0) as ''Exp-Billed'',
ISNULL(p.TotalVenderUnBill,0) as ''Exp-Unbilled'',
ISNULL(p.TotalVenderPaid,0) as ''Exp-Paid''
from Job_Order j
left join (
	select h.BranchCode,d.ForJNo,sum(d.AdvNet) as TotalAdvPay
	from Job_AdvHeader h inner join Job_AdvDetail d
	on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
	where h.DocStatus<99
	group by h.BranchCode,d.ForJNo
) a on j.BranchCode=a.BranchCode and j.JNo=a.ForJNo
left join (
	select h.BranchCode,d.JobNo,sum(CASE WHEN h.ClearType=1 THEN d.BNet ELSE 0 END) as TotalAdvClear,
	sum(CASE WHEN SUBSTRING(d.SICode,1,4) NOT IN(''ERN-'',''B-DE'') AND h.ClearType=2 THEN d.BNet ELSE 0 END) as TotalCost,
	sum(CASE WHEN SUBSTRING(d.SICode,1,4) IN(''ERN-'',''B-DE'') THEN d.BNet ELSE 0 END) as TotalDeposit,
	sum(CASE WHEN h.ClearType=3 THEN d.BNet ELSE 0 END) as TotalService,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalAdvBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalServiceBill,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalAdvUnBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalServiceUnBill
	from Job_ClearHeader h inner join Job_ClearDetail d
	on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
	where h.DocStatus<99
	group by h.BranchCode,d.JobNo	
) c ON j.BranchCode=c.BranchCode AND j.JNo=c.JobNo
left join (
	select h.BranchCode,d.ForJNo,
	sum(CASE WHEN ISNULL(h.PaymentRef,'''')<>'''' THEN d.Total ELSE 0 END) as TotalVenderPaid,
	sum(CASE WHEN ISNULL(h.PaymentRef,'''')='''' AND ISNULL(h.ApproveRef,'''')<>'''' THEN d.Total ELSE 0 END) as TotalVenderBill,
	sum(CASE WHEN ISNULL(h.PaymentRef,'''')='''' AND ISNULL(h.ApproveRef,'''')=''''THEN d.Total ELSE 0 END) as TotalVenderUnBill
	from Job_PaymentHeader h inner join Job_PaymentDetail d
	on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
	inner join Job_SrvSingle s ON d.SICode=s.SICode
	where NOT ISNULL(h.CancelProve,'''')<>''''
	group by h.BranchCode,d.ForJNo
) p ON j.BranchCode=p.BranchCode AND j.JNo=p.ForJNo
{0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'MAIN_CLITERIA', N'AND,h.PaymentDate,h.CustCode,d.ForJNo,h.EmpCode,d.VenCode,h.DocStatus,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'MAIN_SQL', N'select b.NameEng as ''Customer Name'',b.CreditLimit as ''Advanced Credit Term'',b.DutyLimit as ''Advanced Credit Limit'',
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END) as ''Advance Requested'',
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END) as ''Advance Paid'',
SUM(ISNULL(c.AdvUsed,0)) as ''Paid+Cleared Advance'',
SUM(ISNULL(c.AdvBilled,0)) as ''Billed To Customer'',
SUM(ISNULL(c.AdvUnbill,0)) as ''Unbilled Advance'',
SUM(ISNULL(c.AdvCost,0)) as ''Advance Cost'',
SUM(ISNULL(c.AdvReceive,0)) as ''Customer Payment'',
(CASE WHEN b.DutyLimit>0 THEN b.DutyLimit
-
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END)
-
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END)
-
SUM(ISNULL(c.AdvUsed,0)) ELSE 0 END)
+
SUM(ISNULL(c.AdvReceive,0))
  as ''Net Avaiable Balance''
from Job_AdvHeader a LEFT JOIN Mas_Company b
ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
left join (
	select h.BranchCode,d.AdvNo,SUM(d.BNet) as AdvUsed,
	SUM(CASE WHEN d.LinkItem>0 AND h.ClearType<>''2'' THEN d.BNet ELSE 0 END) as AdvBilled,
	SUM(CASE WHEN d.LinkItem=0 AND h.ClearType<>''2'' THEN d.BNet ELSE 0 END) as AdvUnbill,
	SUM(CASE WHEN h.ClearType=''2'' THEN d.BNet ELSE 0 END) as AdvCost,
	SUM(CASE WHEN h.ClearType=''2'' THEN 0 ELSE ISNULL(r.Net,0) END) as AdvReceive
	from Job_ClearHeader h
	inner join Job_ClearDetail d ON h.BranchCode=d.BranchCode
	and h.ClrNo=d.ClrNo
	left join Job_ReceiptDetail r on d.BranchCode=r.BranchCode 
	and d.LinkBillNo=r.InvoiceNo AND d.LinkItem=r.InvoiceItemNo
	left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
	and r.ReceiptNo=t.ReceiptNo
	where h.DocStatus<>99 AND ISNULL(t.CancelProve,'''')=''''
	group by h.BranchCode,d.AdvNo
) c
ON a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo
WHERE a.DocStatus<>99 {0}
group by b.NameEng,b.CreditLimit,b.DutyLimit')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,b.EmpCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT07', N'MAIN_SQL', N'select c.JNo as ''Job Number'',a.AdvNo as ''Advance No'',b.ClrNo as ''Clearing No'',b.ClrDate as ''Clearing Date'',c.CustCode as ''Customer'',
b.CTN_NO as ''Container Number'',a.VenderCode as ''Vender'',
a.SlipNO as ''Receipt#'',a.Date50Tavi as ''Receipt Date'',a.UsedAmount as ''Container Deposit'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Addition Expenses'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Deposit Return'',
a.LinkBillNo as ''V/Receipt#, APLL Inv#'',v.VoucherDate as ''Deposit Received Date''
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
	where ISNULL(b.CancelProve,'''')='''' AND d.GroupCode IN(''ERN'',''B-DEP'') AND a.UsedAmount>0 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'MAIN_CLITERIA', N'AND,ih.DocDate,ih.CustCode,cd.JobNo,ih.EmpCode,cd.VenderCode,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'MAIN_SQL', N'select c.JNo as ''Job Number'',d.NameThai as ''Description'',a.AdvNo as ''Advance No'',
b.ClrNo as ''Clearing No'',b.ClrDate as ''Clearing date'',c.CustCode as ''Customer'',r.ReceiptNo as ''Receipt No'',r.ReceiptDate as ''Receipt Date'',
a.UsedAmount as ''Amount'',a.ChargeVAT as ''VAT Amount'',a.Tax50Tavi as ''WHT Amount'',(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN a.BNet ELSE 0 END) as ''Invoice Billed'',
(CASE WHEN ISNULL(a.LinkBillNo,'''')<>'''' THEN 0 ELSE a.BNet END) as ''Invoice Unbilled'',a.LinkBillNo as ''Invoice No'',
i.DocDate as ''Invoice Date'',
(CASE WHEN b.ClearType=1 THEN ''ADV'' ELSE (CASE WHEN b.ClearType=2 THEN ''COST'' ELSE ''SERV'' END) END) as ''Type''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
left join Job_InvoiceHeader i on a.BranchCode=i.BranchCode and a.LinkBillNo=i.DocNo
left join (
	SELECT hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,MAX(hd.ReceiptDate) as ReceiptDate,MAX(hd.ReceiptNo) as ReceiptNo
	FROM Job_ReceiptHeader hd INNER JOIN Job_ReceiptDetail dt
	ON hd.BranchCode=dt.BranchCode AND hd.ReceiptNo=dt.ReceiptNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo
) r on a.BranchCode=r.BranchCode and a.LinkBillNo=r.InvoiceNo AND a.LinkItem=r.InvoiceItemNo
where ISNULL(b.CancelProve,'''')='''' 
AND ISNULL(i.CancelProve,'''')='''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'MAIN_SQL', N'SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType
    WHERE h.PRType=''P'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.DocNo<> ''''
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
    HAVING SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))<>''''
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE ISNULL(a.PRType,''R'')=''R'' AND NOT ISNULL(b.CancelProve,'''')<>''''
) t {0} ORDER BY VoucherDate,ControlNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'MAIN_CLITERIA', N'AND,h.DocDate,h.CustCode,h.RefNo, h.EmpCode,,(CASE WHEN ISNULL(h.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),h.BranchCode,d.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_SETAR', N'MAIN_SQL', N'SELECT * FROM (
select ''H'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
''MLI'' as ''AR Code'',
CAST(Year(h.DocDate) as varchar)+RIGHT(''0''+CAST(Month(h.DocDate) as varchar),2)+RIGHT(''0''+CAST(DAY(h.DocDate) as varchar),2) as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
h.CurrencyCode as ''Currency'',
c.LnNo as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(h.TotalNet+h.Total50Tavi) as ''Extend Amt'',
'''' as ''Account'',
'''' as ''Cost Center'',
'''' as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
''CLS'' as ''LOB'',
'''' as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
WHERE h.TotalNet>0 AND ISNULL(h.CancelProve,'''')='''' {0}
GROUP BY c.LnNo,h.DocNo,h.DocDate,h.CurrencyCode,j.CustPONo
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
h.CurrencyCode as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.FAmt) as ''Extend Amt'',
ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales) as ''Account'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)<=''3'' THEN ''9762999'' ELSE c.GLAccountCode END) as ''Cost Center'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)=''6'' THEN ''INAS'' ELSE '''' END) as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
d.SDescription as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat>0 AND ISNULL(h.CancelProve,'''')=''''  {0}
GROUP BY c.LnNo,h.DocNo,h.DocDate,h.CurrencyCode,j.CustPONo,d.SDescription,s.GLAccountCodeCost,s.GLAccountCodeSales,c.GLAccountCode
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
h.CurrencyCode as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.FAmt) as ''Extend Amt'',
ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales) as ''Account'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)<=''3'' THEN ''9762999'' ELSE c.GLAccountCode END) as ''Cost Center'',
(CASE WHEN SUBSTRING(ISNULL(s.GLAccountCodeCost,s.GLAccountCodeSales),1,1)=''6'' THEN ''INAS'' ELSE '''' END) as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
d.SDescription as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat=0 AND ISNULL(h.CancelProve,'''')='''' {0}
GROUP BY c.LnNo,h.DocNo,h.DocDate,h.CurrencyCode,j.CustPONo,s.GLAccountCodeCost,s.GLAccountCodeSales,c.GLAccountCode,d.SDescription
UNION
select ''I'' as RecID,
''L762'' as ''CompanyCode'',
''BGK'' as ''City Code'',
c.LnNo as ''CustNo'',
h.DocNo as ''Inv Number'',
'''' as ''LinkInvoice'',
''P'' as ''FunctionCode'',
'''' as ''AR Code'',
'''' as InvDATE,
h.DocNo as ''Ref Number'',
''BKK'' as ''Ref Data'',
'''' as ''TCN'',
'''' as ''PCFN'',
'''' as ''Load Port'',
'''' as ''Load Port Call'',
'''' as ''Discharge Port'',
'''' as ''Discharge Call'',
j.CustPONo as ''Inv Desc'',
h.CurrencyCode as ''Currency'',
'''' as ''Consignee'',
'''' as ''Charge Code'',
'''' as ''Unit Code'',
'''' as ''Unit Price'',
SUM(d.AmtVat) as ''Extend Amt'',
''32406100'' as ''Account'',
''9762999'' as ''Cost Center'',
'''' as ''PSL'',
'''' as TaxCode,
'''' as Vessel,
'''' as Voy,
'''' as ''LOB'',
''VAT Amount (BASE '' + Cast(SUM(d.Amt) as varchar) + '')'' as ''GL Line'',
'''' as ''Free Day'',
'''' as ''Bill Start'',
'''' as ''Bill End'',
'''' as ''Bill Period Start'',
'''' as ''Bill Period End'',
'''' as ''Bill Start Loc'',
'''' as ''Bill End Loc''
from Mas_Company c INNER JOIN Job_InvoiceHeader h 
ON c.CustCode=h.CustCode
AND c.Branch=h.CustBranch
INNER JOIN (SELECT c.BranchCode,c.LinkBillNo,MAX(j.CustRefNo) as CustPONo FROM Job_ClearDetail c INNER JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo GROUP BY c.BranchCode,c.LinkBillNo) j
ON h.BranchCode=j.BranchCode AND h.DocNo=j.LinkBillNo
INNER JOIN Job_InvoiceDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
WHERE d.AmtVat>0 AND ISNULL(h.CancelProve,'''')='''' {0}
GROUP BY c.LnNO,c.GLAccountCode,h.DocNo,h.CurrencyCode,j.CustPONo
) t
ORDER BY 5')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'MAIN_SQL', N'SELECT 
t.ReceiptDate as ''Date'',t.ReceiptNo,t.CustEName as ''Customer'',t.TaxNumber,
(CASE WHEN t.Branch=0 THEN ''HEAD OFFICE'' ELSE t.Branch END) as Branch,t.TotalWhtax as ''WHD Tax''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,
CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''**CANCEL**''+ c.NameEng ELSE c.NameEng END as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 THEN rd.AmtVat ELSE 0 END) as TotalVat,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 THEN rd.Amt50Tavi ELSE 0 END) as TotalWhtax,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' THEN rd.Net+rd.Amt50Tavi ELSE 0 END) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'MAIN_CLITERIA', N'WHERE,t.BookingDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOAD', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.BookingDate,t.TotalContainer,t.TargetYardDate as PickUpTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t {0}  ORDER BY t.BookingDate,t.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'MAIN_CLITERIA', N'AND,t.TargetYardDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADEX', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.ETDDate,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t WHERE t.JobType=2 AND t.JobStatus<>99 {0} ORDER BY t.ETDDate,t.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'MAIN_CLITERIA', N'AND,t.TargetYardDate,t.CustCode,t.JNo,t.CSCode,t.ForwarderCode,t.JobStatus,t.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PLANLOADIM', N'MAIN_SQL', N'SELECT t.JNo,t.BookingNo,t.ETADate,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'''' THEN (case when t.CauseCode=''99'' THEN ''Cancel'' ELSE (CASE WHEN t.CauseCode=''3'' THEN ''Finish'' ELSE ''Working'' END) END) ELSE ''Request'' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (
SELECT dbo.Job_Order.BranchCode, dbo.Job_Order.JNo, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustCode, dbo.Job_Order.CustBranch, dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, 
dbo.Job_Order.CSCode, dbo.Job_Order.Description, dbo.Job_Order.TRemark, dbo.Job_Order.JobStatus, dbo.Job_Order.JobType, dbo.Job_Order.ShipBy, 
dbo.Job_Order.InvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, 
dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, 
dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, 
dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, 
dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelReson, dbo.Job_Order.CancelDate, dbo.Job_Order.CancelTime, dbo.Job_Order.CancelProve, 
dbo.Job_Order.CancelProveDate, dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, 
dbo.Job_Order.DeclareType, dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, 
dbo.Job_Order.TyClearTax, dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, 
dbo.Job_Order.DutyDate, dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_LoadInfo.VenderCode, dbo.Job_LoadInfo.ContactName, 
dbo.Job_LoadInfo.BookingNo AS BookingRefNo, dbo.Job_LoadInfo.LoadDate AS Bookingdate, dbo.Job_LoadInfo.Remark, dbo.Job_LoadInfo.PackingPlace, 
dbo.Job_LoadInfo.CYPlace, dbo.Job_LoadInfo.FactoryPlace, dbo.Job_LoadInfo.ReturnPlace, dbo.Job_LoadInfo.PackingDate, dbo.Job_LoadInfo.CYDate, 
dbo.Job_LoadInfo.FactoryDate, dbo.Job_LoadInfo.ReturnDate, dbo.Job_LoadInfo.PackingTime, dbo.Job_LoadInfo.CYTime, dbo.Job_LoadInfo.FactoryTime, 
dbo.Job_LoadInfo.ReturnTime, dbo.Job_LoadInfo.NotifyCode, dbo.Job_LoadInfo.TransMode, dbo.Job_LoadInfo.PaymentCondition, dbo.Job_LoadInfo.PaymentBy, 
dbo.Job_LoadInfo.CYAddress, dbo.Job_LoadInfo.PackingAddress, dbo.Job_LoadInfo.FactoryAddress, dbo.Job_LoadInfo.ReturnAddress, dbo.Job_LoadInfo.CYContact, 
dbo.Job_LoadInfo.PackingContact, dbo.Job_LoadInfo.FactoryContact, dbo.Job_LoadInfo.ReturnContact, dbo.Job_LoadInfoDetail.ItemNo, 
dbo.Job_LoadInfoDetail.CTN_NO, dbo.Job_LoadInfoDetail.SealNumber, dbo.Job_LoadInfoDetail.TruckNO, dbo.Job_LoadInfoDetail.TruckIN, 
dbo.Job_LoadInfoDetail.Start, dbo.Job_LoadInfoDetail.Finish, dbo.Job_LoadInfoDetail.CauseCode, dbo.Job_LoadInfoDetail.Comment, 
dbo.Job_LoadInfoDetail.TruckType, dbo.Job_LoadInfoDetail.Driver, dbo.Job_LoadInfoDetail.TargetYardDate, dbo.Job_LoadInfoDetail.TargetYardTime, 
dbo.Job_LoadInfoDetail.ActualYardDate, dbo.Job_LoadInfoDetail.ActualYardTime, dbo.Job_LoadInfoDetail.UnloadFinishDate, 
dbo.Job_LoadInfoDetail.UnloadFinishTime, dbo.Job_LoadInfoDetail.UnloadDate, dbo.Job_LoadInfoDetail.UnloadTime, dbo.Job_LoadInfoDetail.Location, 
dbo.Job_LoadInfoDetail.ReturnDate AS CtnReturnDate, dbo.Job_LoadInfoDetail.ShippingMark, dbo.Job_LoadInfoDetail.ProductDesc, 
dbo.Job_LoadInfoDetail.CTN_SIZE, dbo.Job_LoadInfoDetail.ProductQty, dbo.Job_LoadInfoDetail.ProductUnit, dbo.Job_LoadInfoDetail.GrossWeight, 
dbo.Job_LoadInfoDetail.Measurement AS DMeasurement, dbo.Job_LoadInfoDetail.TimeUsed, dbo.Job_LoadInfoDetail.DeliveryNo AS DONo, 
dbo.Job_LoadInfoDetail.LocationID, dbo.Job_LoadInfoDetail.NetWeight, dbo.Job_LoadInfoDetail.ProductPrice
FROM dbo.Job_LoadInfoDetail INNER JOIN
dbo.Job_LoadInfo ON dbo.Job_LoadInfoDetail.BranchCode = dbo.Job_LoadInfo.BranchCode AND 
dbo.Job_LoadInfoDetail.BookingNo = dbo.Job_LoadInfo.BookingNo RIGHT OUTER JOIN
dbo.Job_Order ON dbo.Job_LoadInfo.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_LoadInfo.JNo = dbo.Job_Order.JNo
) as t WHERE t.JobType=1 AND t.JobStatus<>99 {0} ORDER BY t.ETADate,t.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'MAIN_CLITERIA', N'WHERE,VoucherDate,CustCode,,RecUser,,,BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net as TotalReceived,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)<>''T'' {0}) rc ORDER BY rc.SDescription,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.SDescription,rc.Net as TotalReceived,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)=''T'' {0}) rc ORDER BY rc.ReceiptDate,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'MAIN_SQL', N'SELECT Date50Tavi,NO50Tavi,VenTaxNumber,VenTaxBranch,VenderName,CustTaxNumber,CustName,
(CASE WHEN Tax50TaviRate =1 THEN ''ค่าขนส่ง'' ELSE (CASE WHEN (Tax50TaviRate=1.5 OR Tax50TaviRate=3) THEN ''ค่าบริการ'' ELSE (CASE WHEN Tax50TaviRate =5 THEN ''ค่าเช่า'' ELSE (CASE WHEN Tax50TaviRate =2 THEN ''ค่าโฆษณา'' ELSE (CASE WHEN Tax50TaviRate =10 THEN ''ออกให้มูลนิธิ/สมาคม'' ELSE ''เงินเดือน'' END) END) END) END) END) as TaxType,
(CASE WHEN CustName Like ''%จำกัด%'' THEN ''ภงด53'' ELSE ''ภงด3'' END) as TaxForm,
(CASE WHEN IsLtdAdv50Tavi=1 THEN Tax50Tavi ELSE 0 END) as Tax3Tres,
(CASE WHEN IsLtdAdv50Tavi=0 THEN Tax50Tavi ELSE 0 END) as TaxNot3Tres,
SlipNO,UsedAmount,Tax50TaviRate
FROM (
SELECT cd.Date50Tavi, cd.NO50Tavi, v.VenCode, v.TaxNumber AS VenTaxNumber, v.BranchCode AS VenTaxBranch, v.TName AS VenderName, c.CustCode, 
    c.TaxNumber AS CustTaxNumber, c.Branch AS CustTaxBranch, c.NameThai AS CustName, cd.SICode, cd.SDescription, cd.UsedAmount, cd.Tax50TaviRate, 
    cd.Tax50Tavi, cd.IsLtdAdv50Tavi, cd.SlipNO
FROM     dbo.Job_ClearDetail AS cd INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch INNER JOIN
    dbo.Mas_Vender AS v ON cd.VenderCode = v.VenCode
WHERE (cd.Tax50Tavi > 0) AND ch.DocStatus<>99 {0}
) as t ORDER BY 9,1,2')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'MAIN_CLITERIA', N'AND,h.DocDate,h.TaxNumber1,d.JNo,h.UpdateBy,h.TaxNumber3,h.FormType,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXSUM', N'MAIN_SQL', N'SELECT FormTypeName,TaxLawName,TaxNumber1 as TaxNumber,Branch1 as Branch,TName1 as TaxBy,
Year(a.DocDate) as TaxYear,Month(a.DocDate)  as TaxMonth,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayAmount END) as ServiceAmount,
SUM(CASE WHEN a.PayRate=1 THEN 0 ELSE a.PayTax END) as TaxService, 
SUM(CASE WHEN a.PayRate>1 THEN 0 ELSE a.PayAmount END) as TranAmount,
SUM(CASE WHEN a.PayRate>1 THEN 0 ELSE a.PayTax END) as TaxTransport
FROM
(
    SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
    d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
    j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
    (CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
    (CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
    FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
    ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
    LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
    AND d.JNo=j.JNo 
    LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
	LEFT JOIN dbo.Mas_Company c ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
    WHERE NOT ISNULL(h.CancelProve,'''')<>'''' 
	{0}
) a 
GROUP BY FormTypeName,TaxLawName,TaxNumber1,Branch1,Year(a.DocDate),Month(a.DocDate),TName1
ORDER BY FormTypeName,TName1,Year(a.DocDate),Month(a.DocDate)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'MAIN_CLITERIA', N'AND,h.DocDate,h.TaxNumber1,h.JNo,h.UpdateBy,h.TaxNumber3,h.FormType,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBKPI', N'MAIN_SQL', N'SELECT NameEng as Customer,CSCode,TName as Agent,JNo, DeclareNumber,CreateDate, ConfirmDate,
DATEDIFF(d,CreateDate,ConfirmDate) as OpenDays,
LoadDate,DutyDate as InspectionDate,EstDeliverDate as UnloadDate,
DATEDIFF(d,LoadDate,EstDeliverDate) as DutyDays,
 LastClearDate,
 DATEDIFF(d,EstDeliverDate,LastClearDate) as ClearDays,
  CloseJobDate,
 DATEDIFF(d,CloseJobDate,LastClearDate) as CloseDays, 
 DATEDIFF(d,ConfirmDate,CloseJobDate) as TotalDays
FROM            dbo.Job_Order AS jd 
INNER JOIN Mas_Company c ON jd.CustCode=c.CustCode AND jd.CustBranch=c.Branch
LEFT JOIN Mas_Vender v ON jd.AgentCode=v.VenCode
LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0}
 ORDER BY jd.CustCode,jd.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'MAIN_CLITERIA', N'AND,j.ETADate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBLOADING', N'MAIN_SQL', N'SELECT j.JNo as ''Job Number'',j.consigneecode as ''Consignee'',j.BookingNo as ''Booking/BL'',j.TotalContainer as ''CONTAINER'',j.VesselName as ''Vessel/Flight'',j.ForwarderCode as ''Agent'',
t.TransMode as ''MODE'',t.CYPlace + ''-'' +t.PackingPlace as ''Transport Route'',j.ETADate as ''ETA Date'',j.ReadyToClearDate as ''Ready Date'',j.ShippingEmp as ''Shipping'',j.DutyDate as ''Inspection Date''
,j.DeclareStatus,j.EstDeliverDate as ''Delivery Date'',t.ReturnDate as ''Demurrage Date'',t.FactoryPlace as ''Delivery Place''
FROM Job_Order j LEFT JOIN Job_Loadinfo t
ON j.BranchCode=t.BranchCode and j.JNo=t.JNo
WHERE j.JobStatus<>99  {0}
ORDER BY j.ETADate')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'MAIN_CLITERIA', N'AND,j.LoadDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSTATUS', N'MAIN_SQL', N'SELECT c.TName,j.* FROM (
SELECT j.CSCode
,SUM(CASE WHEN j.JobStatus=0 THEN 1 ELSE 0 END) as ''PENDING CONFIRM'',SUM(CASE WHEN j.JobStatus=1 THEN 1 ELSE 0 END) as ''JOB CONFIRMED'',SUM(CASE WHEN j.JobStatus=2 THEN 1 ELSE 0 END) as ''JOB IN PROCESS'',SUM(CASE WHEN j.JobStatus=3 THEN 1 ELSE 0 END) as ''CLEARANCE COMPLETED'',SUM(CASE WHEN j.JobStatus=4 THEN 1 ELSE 0 END) as ''READY FOR BILLING'',SUM(CASE WHEN j.JobStatus=5 THEN 1 ELSE 0 END) as ''PARTIAL BILLING'',SUM(CASE WHEN j.JobStatus=6 THEN 1 ELSE 0 END) as ''BILLING COMPLETED'',SUM(CASE WHEN j.JobStatus=7 THEN 1 ELSE 0 END) as ''PAYMENT COMPLETED'',SUM(CASE WHEN j.JobStatus=98 THEN 1 ELSE 0 END) as ''HOLD FOR CHECKING'',SUM(CASE WHEN j.JobStatus=99 THEN 1 ELSE 0 END) as ''CANCELLED''
FROM Job_Order j {0}
GROUP BY j.CSCode) j INNER JOIN Mas_User c ON j.CSCode=c.UserID ORDER BY c.TName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'MAIN_CLITERIA', N'AND,c.DutyDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSUMMARY', N'MAIN_SQL', N'SELECT JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode,
SUM(AdvCleared) as TotalAdv,
SUM(ChargeCleared) as TotalCharge,
SUM(AdvBilled) as TotalAdvBilled,
SUM(ChargeBilled) as TotalChargeBilled,
SUM(CostCleared) as TotalCost,
SUM(DepositAmt) as TotalEarnest,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit,
SUM(AdvWaitBill) as TotalAdvWaitBill,
SUM(ChargeWaitBill) as TotalChargeWaitBill
FROM (
	select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
	b.ClrNo,b.ClrDate,b.ClearType,b.DocStatus,a.AdvNo,a.AdvItemNo,c.CustCode,c.CustBranch,
	e.Title+'' ''+e.NameThai as CustName,a.SICode,a.SDescription,a.SlipNo,a.Date50Tavi as SlipDate,
	a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
	(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
    (CASE WHEN d.GroupCode IN(''ERN'',''B-DEP'') THEN a.UsedAmount ELSE 0 END) as DepositAmt,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as AdvWaitBill,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as ChargeWaitBill,
	(CASE WHEN d.IsExpense=1 AND ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as CostWaitBill,
	(CASE WHEN d.IsExpense=1 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as CostBilled,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.UsedAmount ELSE 0 END) as AdvBilled,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 AND NOT ISNULL(a.LinkBillNo,'''')=''''THEN a.UsedAmount ELSE 0 END) as ChargeBilled
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 {0}
) clr
GROUP BY JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode
ORDER BY CustCode,DutyDate,JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBTRANSPORT', N'MAIN_CLITERIA', N'AND,c.LoadDate,c.NotifyCode,a.JNo,,c.VenderCode,,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT03', N'MAIN_SQL', N'SELECT CustCode as ''Customer'',CSCode as ''CS'',AgentCode as Vender,JNo as ''Job Number'', DeclareNumber as ''Customs Declare#'',
DocDate as ''Job Date'', CreateDate as ''Creation Date'', 
DATEDIFF(d,CreateDate,DocDate) as ''Open Days'',
DutyDate as ''Customs Inspection Date'',
DATEDIFF(d,CreateDate,DutyDate) as ''Customs Lead Time'',
 LastClearDate as ''Job Clear Date'',
 DATEDIFF(d,DutyDate,LastClearDate) as ''Clear Lead Time'',
  CloseJobDate as ''Job Close Date'',
 DATEDIFF(d,DutyDate,CloseJobDate) as ''Close Lead Time'',
 LastInvDate as ''Invoice Creation Date'',
 DATEDIFF(d,LastClearDate,LastInvDate) as ''Invoice Lead Time'',
 LastRcvDate as ''Receipt Date'',
 DATEDIFF(d,LastInvDate,LastRcvDate) as ''A/R Aging Days'',jd.JobStatus
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
{0}  ORDER BY jd.CustCode,jd.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT04', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXSUMMARY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName as NameThai,rc.InvoiceNo,rc.JobNo,SUM(CASE WHEN rc.AmtAdvance>0 THEN rc.Net ELSE 0 END) as AmtAdvance,
SUM(CASE WHEN rc.AmtCharge>0 THEN rc.Amt ELSE 0 END) as TotalCharge,
SUM(CASE WHEN rc.AmtCharge>0 THEN rc.AmtVAT ELSE 0 END) as AmtVAT,
SUM(CASE WHEN rc.AmtCharge>0 THEN rc.Amt50Tavi ELSE 0 END) as Amt50Tavi,SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'''')='''' THEN 0 ELSE rc.Net END) as TotalReceived FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)=''T'' AND NOT ISNULL(rh.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' {0}) rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'MAIN_CLITERIA', N'AND,d.UnloadFinishDate, j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ARBAL', N'MAIN_SQL', N'SELECT CustCode,DocNo,DocDate,DueDate,RefNo,
Sum(AmtAdvance) as TotalAdv,Sum(AmtCharge) as TotalCharge,Sum(CASE WHEN AmtCharge>0 THEN AmtVAT ELSE 0 END) as TotalVat,
Sum(CASE WHEN AmtCharge>0 THEN Amt50Tavi ELSE 0 END) as Total50Tavi,
Sum(TotalAmt) as TotalNet,Sum(TotalReceiveAmt) as TotalReceived,Sum(TotalCreditAmt) as TotalCredit,Sum(TotalBal) as TotalBal
FROM (
SELECT ih.*,id.SICode,id.SDescription,id.AmtCharge,id.AmtVat,id.Amt50Tavi,id.AmtAdvance,
id.TotalAmt,id.AmtCredit,ISNULL(c.TotalCredit,0) as TotalCreditAmt,id.AmtCredit+ISNULL(r.RecvNet,0) as TotalReceiveAmt
,id.TotalAmt-id.AmtCredit-ISNULL(c.TotalCredit,0)-ISNULL(r.RecvNet,0) as TotalBal
,r.FromReceiptNo,r.VoucherNo,r.ReceiptDate
FROM dbo.Job_InvoiceHeader AS ih INNER JOIN dbo.Job_InvoiceDetail AS id 
ON ih.BranchCode = id.BranchCode AND ih.DocNo=id.DocNo
LEFT JOIN (SELECT    cd.BranchCode, cd.BillingNo, cd.BillItemNo, SUM(cd.TotalNet) AS TotalCredit
FROM dbo.Job_CNDNHeader AS ch INNER JOIN dbo.Job_CNDNDetail AS cd 
ON ch.BranchCode = cd.BranchCode AND ch.DocNo = cd.DocNo
WHERE (ch.DocStatus <> 99)
GROUP BY cd.BranchCode, cd.BillingNo, cd.BillItemNo) as c
ON id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
LEFT JOIN (SELECT    rd.BranchCode, rd.InvoiceNo, rd.InvoiceItemNo, 
SUM(rd.Net) AS RecvNet,
(SELECT STUFF((
SELECT DISTINCT '','' + ReceiptNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as FromReceiptNo,
(SELECT STUFF((
SELECT DISTINCT '','' + VoucherNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
  )) as VoucherNo,
MAX(rh.ReceiptDate) as ReceiptDate
FROM      dbo.Job_ReceiptHeader AS rh INNER JOIN
             dbo.Job_ReceiptDetail AS rd ON rh.BranchCode = rd.BranchCode AND rh.ReceiptNo = rd.ReceiptNo
WHERE    (NOT (ISNULL(rh.CancelProve, '''') <> ''''))
GROUP BY rd.InvoiceNo, rd.InvoiceItemNo, rd.BranchCode) as r
ON id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
WHERE    (NOT (ISNULL(ih.CancelProve, '''') <> ''''))
) t {0} GROUP BY CustCode,DocNo,DocDate,DueDate,RefNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_BILLDAILY', N'MAIN_CLITERIA', N'AND,h.BillDate,h.CustCode,,h.EmpCode,,,h.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT05', N'MAIN_SQL', N'select d.ForJNo as ''Job Number'',h.AdvNo as ''Advance No'',c.LastClrNo as ''Clearing No'',
c.LastClrDate as ''Clearing Date'',c.LastInvNo as ''Invoice No'',c.LastInvDate as ''Invoice Date'',
(CASE WHEN ISNULL(c.LastInvNo,'''')='''' THEN DATEDIFF(DAY,c.LastClrDate,GetDate()) ELSE 0 END) as ''Unbilled Aging Day'',
(CASE WHEN ISNULL(c.LastInvNo,'''')<>'''' THEN DATEDIFF(DAY,c.LastClrDate,c.LastInvDate) ELSE 0 END) as ''Billed Aging Day'',
h.CustCode as ''Customer'',c.LastReceiptNo as ''Receipt No'',c.LastReceiptDate as ''Receipt Date'',
(d.AdvNet) as ''Advance Amount'',
ISNULL(c.ClrNet,0) as ''Actual Spending'',
ISNULL(c.ClrBillAble,0) as ''Billable Amount'',
ISNULL(c.ClrVat,0) as ''TotalVAT'',
ISNULL(c.ClrWht,0) as ''TotalWHT'',
ISNULL(c.ClrBilled,0) as ''Billed Advance'',
ISNULL(c.ClrUnBilled,0) as ''Unbilled Advance''
from Job_AdvHeader h inner join Job_AdvDetail d
on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
left join (
	select a.BranchCode,b.AdvNo,b.AdvItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,Max(a.ClrNo) as LastClrNo,
    sum(CASE WHEN b.LinkItem>0 and a.ClearType<>2 THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrBilled,
	sum(CASE WHEN b.LinkItem=0 and a.ClearType<>2 THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrUnBilled,
    MAX(b.LinkBillNo) as LastInvNo,Max(i.DocDate) as LastInvDate,
	MAX(r.ReceiptNo) as LastReceiptNo,MAX(t.ReceiptDate) as LastReceiptDate,
	sum(CASE WHEN a.ClearType<>2 THEN b.UsedAmount ELSE 0 END) as ClrBillAble,
	sum(CASE WHEN a.ClearType<>2 THEN b.ChargeVAT ELSE 0 END) as ClrVat,
	sum(CASE WHEN a.ClearType<>2 THEN b.Tax50Tavi ELSE 0 END) as ClrWht
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	left join Job_InvoiceHeader i on b.BranchCode=i.BranchCode 
	AND b.LinkBillNo=i.DocNo
    left join Job_ReceiptDetail r on b.BranchCode=r.BranchCode
    AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
    left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
    and r.ReceiptNo=t.ReceiptNo
	where a.DocStatus<>99 and isnull(b.AdvNo,'''')<>'''' AND ISNULL(t.CancelProve,'''')=''''
	group by a.BranchCode,b.AdvNo,b.AdvItemNo
) c
on d.BranchCode=c.BranchCode and d.AdvNo=c.AdvNo and d.ItemNo=c.AdvItemNo
where  h.DocStatus<99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT06', N'MAIN_CLITERIA', N'AND,a.AdvDate,,,a.EmpCode,,,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKKPI', N'MAIN_SQL', N'select h.JNo,d.CTN_NO,d.PlaceName2 as ''DeliveryPlace'',j.ForwarderCode as ''Agent'',d.Comment,d.CTN_SIZE,
h.FactoryDate as ''ETADate'',j.InvCountry,p.PortName as ''POL'',h.BookingNo,d.SealNumber,
FORMAT(CAST(d.UnloadDate as DateTime)+CAST(CAST(ISNULL(d.UnloadTime,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as DeliveryTarget,
FORMAT(CAST(d.TargetYardDate as DateTime)+CAST(CAST(ISNULL(d.TargetYardTime,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as PickupActual,
FORMAT(CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as DeliveryActual,
DATEDIFF(mi,CAST(d.UnloadDate as DateTime)+CAST(CAST(ISNULL(d.UnloadTime,''00:00:00'') as Time) as DateTime),CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime))/60 as DeliveryHour,
(CASE WHEN DATEDIFF(mi,CAST(d.UnloadDate as DateTime)+CAST(CAST(ISNULL(d.UnloadTime,''00:00:00'') as Time) as DateTime),CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime))<=0 THEN 
''Early'' ELSE (CASE WHEN d.UnloadFinishDate IS NULL THEN ''Ongoing'' ELSE ''Late'' END) END) as DeliveryOntime,
FORMAT(CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime),''dd/MM/yyyy HH:mm'') as ActualReturn,
DATEDIFF(mi,CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime),CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime))/60 as ReturnHour,
(CASE WHEN (DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60)>4 THEN ''Y'' ELSE ''N'' END) as ReturnLate,
(CASE WHEN ((DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60)-4)<3 THEN
((DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60))
ELSE 0 END) as ReturnWithIn2,
(CASE WHEN ((DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60)-4)>=3 THEN
((DATEDIFF(mi,CAST(d.UnloadFinishDate as DateTime)+CAST(CAST(ISNULL(d.UnloadFinishTime,''00:00:00'') as Time) as DateTime),CAST(d.ReturnDate as DateTime)+CAST(CAST(ISNULL(d.Finish,''00:00:00'') as Time) as DateTime))/60))
ELSE 0 END) as ReturnOver3,d.Driver,d.TruckNo,d.PlaceName1 as PickupPlace,d.PlaceName3 as ReturnPlace,d.ProductDesc
FROM Job_LoadInfoDetail d INNER JOIN Job_Loadinfo h 
ON d.BranchCode=h.BranchCode AND d.BookingNo=h.BookingNo
INNER JOIN (SELECT *,(CASE WHEN JobType=1 THEN InvFCountry ELSE InvCountry END) as CountryCode FROM Job_Order) j ON h.BranchCode=j.BranchCode AND h.JNo=j.JNo
LEFT JOIN jobmaster.dbo.Mas_RFIPC p on j.InvInterPort=p.PortCode AND p.CountryCode=j.CountryCode
WHERE j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'MAIN_CLITERIA', N'WHERE,d.UnloadFinishDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT08', N'MAIN_SQL', N'select DISTINCT ih.CustCode as ''Customer'',id.DocNo as ''Invoice No'',cd.JobNo as ''Job Number'',ih.DocDate as ''Invoice Date'', cd.SDescription as ''Description'',
(CASE WHEN ch.ClearType=1 THEN ''ADV'' ELSE (CASE WHEN ch.ClearType=3 THEN ''SERV'' ELSE ''COST'' END) END) as ''Type'',
id.Amt as ''Amount'',id.AmtVat as ''TotalVAT'',id.AmtCredit as ''Prepaid'' ,id.Amt50Tavi as ''TotalWHT'',id.TotalAmt as''Total Amount'',
0 as ''CN,DN Amount'',(CASE WHEN id.AmtAdvance>0 THEN id.TotalAmt ELSE 0 END) as ''Advance Amount'',(CASE WHEN id.AmtAdvance=0 THEN id.TotalAmt ELSE 0 END) as ''SVC Amount'',ISNULL(rd.ReceiptNet,0) as ''Payment Received'',
ISNULl(rd.LastRcvNo,'''') as ''Receipt No'',rd.LastRcvDate as ''Receipt Date''
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih 
on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Job_ClearDetail cd
on id.BranchCode=cd.BranchCode and id.DocNo=cd.LinkBillNo
and id.ItemNo=cd.LinkItem
inner join Job_ClearHeader ch on cd.BranchCode=ch.BranchCode
and cd.ClrNo=ch.ClrNo
left join (
	SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,sum(d.Net) as ReceiptNet
	,Max(h.ReceiptNo) as LastRcvNo,Max(h.ReceiptDate) as LastRcvDate
	FROM Job_ReceiptDetail d inner join Job_ReceiptHeader h
	on d.BranchCode=h.BranchCode and d.ReceiptNo=h.ReceiptNo
	where NOT ISNULL(h.CancelProve,'''')<>'''' 
	group by d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
)rd on id.BranchCode=rd.BranchCode and id.DocNo=rd.InvoiceNo
and id.ItemNo=rd.InvoiceItemNo
where NOT ISNULL(ih.CancelProve,'''')<>'''' AND ISNULL(ch.DocStatus,0)<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'MAIN_CLITERIA', N'AND,h.DocDate,j.CustCode,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT09', N'MAIN_SQL', N'SELECT h.DocNo as ''Reference#'',d.ForJNo as ''Job Number'', h.DocDate as ''Creation Date'',
v.TName as ''Vender'',h.RefNo as ''Container No'',d.SDescription as ''Expense'',
(CASE WHEN s.IsExpense=1 THEN ''COST'' ELSE ''ADV'' END) as ''Type'',
d.Amt as ''Amount'', d.AmtVAT as ''TotalVAT'', d.AmtWHT as ''TotalWHT'',
(CASE WHEN ISNULL(h.ApproveRef,'''')<>'''' THEN d.Total ELSE 0 END) as ''BILLED'',
(CASE WHEN ISNULL(h.ApproveRef,'''')='''' THEN d.Total ELSE 0 END) as ''UNBILLED'',
h.PoNo as ''Vender Inv#'',j.CustCode as ''Customer'',h.PaymentRef as ''Payment Ref#''
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'MAIN_CLITERIA', N'AND,h.DocDate,j.CustCode,d.ForJNo,h.EmpCode,h.VenCode,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT10', N'MAIN_SQL', N'SELECT h.DocNo as ''Reference#'', h.DocDate as ''Creation Date'',
v.TName as ''Vender'',h.RefNo as ''Container No'',d.SDescription as ''Expense'',
(CASE WHEN s.IsExpense=1 THEN ''COST'' ELSE ''ADV'' END) as ''Type'',
d.Amt as ''Amount'', d.AmtVAT as ''TotalVAT'', d.AmtWHT as ''TotalWHT'',
d.Total as ''TotalNet'',d.ForJNo as ''Job Number'',j.CustCode as ''Customer'',
h.ApproveRef as ''Approve Ref#''
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' AND ISNULL(h.PaymentRef,'''')='''' {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_MGMT11', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,c.CSCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTPROFIT', N'MAIN_SQL', N'SELECT CustCode,CustName,TAddress,COUNT(DISTINCT JNo) as ''Total Job'',
SUM(CostCleared) as TotalCost,SUM(Deposit) as TotalEarnest,
SUM(AdvBilled) as TotalAdv,SUM(ChargeBilled) as TotalCharge,
SUM(ChargeBilled)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+'' ''+e.NameThai as CustName,e.TAddress,e.EAddress1+''''+e.EAddress2 as EAddress,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.BNet ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=1 AND NOT d.GroupCode IN(''ERN'',''B-DEP'')  THEN a.BNet ELSE 0 END) as CostCleared,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.BNet ELSE 0 END) as AdvBilled,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND NOT ISNULL(a.LinkBillNo,'''')='''' THEN a.BNet ELSE 0 END) as ChargeBilled,
(CASE WHEN d.GroupCode IN(''ERN'',''B-DEP'') THEN a.BNet ELSE 0 END) as Deposit,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.BNet ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.BNet ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<90 {0}
) clr
GROUP BY CustCode,CustName,TAddress
ORDER BY CustCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'MAIN_CLITERIA', N'AND,c.DocDate,c.CustCode,c.JNo,c.CSCode,c.AgentCode,c.JobStatus,c.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUSTSUMMARY', N'MAIN_SQL', N'SELECT CustCode,CustName,
SUM(AdvCleared+CostCleared) as TotalExpClear,
SUM(AdvWaitBill) as TotalAdvWaitBill,
SUM(ChgWaitBill) as TotalChargeWaitBill,
SUM(AdvCleared) as TotalAdv,SUM(ChargeCleared) as TotalCharge,SUM(CostCleared) as TotalCost,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+'' ''+e.NameThai as CustName,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as AdvWaitBill,
(CASE WHEN d.IsExpense=0 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ExpBilled,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as ChgWaitBill,
(CASE WHEN d.IsExpense=1 AND NOT a.LinkBillNo='''' THEN a.UsedAmount ELSE 0 END) as CostBilled,
(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 {0}
) clr
GROUP BY CustCode,CustName
ORDER BY CustName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CUTAR', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TRUCKPNL', N'MAIN_SQL', N'SELECT h.BookingNo,j.JNo,c.CustCode,c.NameEng,d.ActualYardDate as PickupDate,
d.UnloadFinishDate as DeliveryDate,d.ReturnDate,h.VenderCode,a.AccTName,d.CTN_NO,d.CTN_SIZE,
(SELECT STUFF((
SELECT DISTINCT '',''+ LinkBillNo FROM Job_ClearDetail WHERE BranchCode=j.BranchCode AND JobNo=j.JNo
AND LinkBillNo<>'''' AND LinkItem>0
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoCust,
(SELECT STUFF((
SELECT DISTINCT '',''+ ph.PoNo
FROM Job_PaymentHeader ph INNER JOIN Job_PaymentDetail pd
ON ph.BranchCode=pd.BranchCode AND ph.DocNo=pd.DocNo
WHERE pd.BranchCode=h.BranchCode AND pd.ForJNo=h.JNo
AND pd.BookingRefNo=d.BookingNo and pd.BookingItemNo=d.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNoVend,
CONVERT(numeric(10,2),e.TotalExpense) as TotalCost,clr.TotalInvoice as ''Invoice Billed'',clr.TotalInvoice-e.TotalExpense as ''Profit'',
j.CSCode,CONCAT(Year(j.DocDate),''/'',Month(j.DocDate)) as Period,jt.JobTypeName
FROM Job_Loadinfo h INNER JOIN Job_LoadInfoDetail d
ON h.BranchCode=d.BranchCode AND h.BookingNo =d.BookingNo
INNER JOIN Job_Order j on h.BranchCode=j.BranchCode
AND h.JNo=j.JNo LEFT JOIN Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
LEFT JOIN Mas_Account a ON c.GLAccountCode=a.AccCode
INNER JOIN (
SELECT Convert(int,ConfigKey) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
LEFT JOIN
(
	select ch.BranchCode,ch.CTN_NO,
	SUM(cd.UsedAmount) as TotalInvoice,cd.JobNo
	from Job_ClearDetail cd inner join Job_ClearHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.ClrNo=ch.ClrNo
	where ch.DocStatus<>99
	AND LinkItem>0 AND ch.ClearType=3
	group by ch.BranchCode,ch.CTN_NO,cd.JobNo	
) clr
ON d.BranchCode=clr.BranchCode AND d.CTN_NO=clr.CTN_NO AND d.JNo=clr.JobNo
LEFT JOIN (
	SELECT pd.BranchCode,pd.BookingRefNo,pd.BookingItemNo,
	SUM(pd.Amt) as TotalExpense
	FROM Job_PaymentHeader ph INNER JOIN Job_PaymentDetail pd
	ON ph.BranchCode=pd.BranchCode AND ph.DocNo=pd.DocNo
	INNER JOIN Job_SrvSingle sv ON pd.SICode=sv.SICode 
	WHERE NOT ISNULL(ph.CancelProve,'''')<>'''' AND sv.IsCredit=0
	GROUP BY pd.BranchCode,pd.BookingRefNo,pd.BookingItemNo
) e ON d.BranchCode=e.BranchCode AND d.BookingNo=e.BookingRefNo AND d.ItemNo=e.BookingItemNo
{0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'MAIN_CLITERIA', N'WHERE,t.ExpenseDate,t.CustCode,t.JobNo,,t.VenCode,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_DAILYCASH', N'MAIN_SQL', N'SELECT t.ReceiptNo as ''Receipt No'',CONCAT(t.CustEName,''<div style="display:flex;"><span style="flex:1">'',
(CASE WHEN t.CashAmount>''0.00'' THEN ''<br/>'' + t.CashRef ELSE '''' END),
(CASE WHEN t.ChqAmount>''0.00'' THEN ''<br/>'' + t.ChqRef ELSE '''' END),
''</span><span style="flex:1">'',
(CASE WHEN t.CashAmount>''0.00'' THEN ''<br/>'' + t.CashBank ELSE '''' END),
(CASE WHEN t.ChqAmount>''0.00'' THEN ''<br/>'' + t.ChqBank ELSE '''' END),
''</span></div>'') as ''Shipper/Cheque Details'',
t.ChqAmount as ''Chq Amt'',
t.CashAmount as ''Cash Amt'',
t.TotalWhtax as ''WHD Tax'',
Cast(t.ChqAmount as float)+Cast(t.CashAmount as float)+t.TotalWHTax as ''Total Amt'',t.InvNo as ''Invoice No''
FROM (
select r.*,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',0) as CashAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',0) as CashBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',0),'':'',1),'':'',1),'':'',1) as CashRef,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',0) as ChqAmount,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',0) as ChqBank,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'':'',1),'':'',1),'':'',1),'';'',0) as ChqRef,
dbo.GetDataSplit(dbo.GetDataSplit(dbo.GetDataSplit(Remark,'';'',1),'';'',1),'':'',1) as BankChg
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng as CustEName,
rh.Remark,
Sum(CASE WHEN id.AmtAdvance >0 THEN rd.Net ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(rd.AmtVat) as TotalVat,
Sum(rd.Amt50Tavi) as TotalWhtax,
Sum(rd.Net+rd.Amt50Tavi) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from 
(
SELECT *,(CASE WHEN SUBSTRING(TRemark,1,2)=''CH'' THEN ''CASH;'' + TRemark ELSE TRemark END) as Remark 
FROM
Job_ReceiptHeader
WHERE ISNULL(CancelProve,'''')=''''
)
rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
inner join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
inner join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.Remark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_EARNEST', N'MAIN_CLITERIA', N'AND,a.Date50Tavi,c.CustCode,c.JNo,b.EmpCode,a.VenderCode,b.DocStatus,b.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTTAX', N'MAIN_SQL', N'SELECT 
t.CustEName as ''Customer'',t.TaxNumber,(CASE WHEN t.Branch=0 THEN ''HEAD OFFICE'' ELSE t.Branch END) as Branch,
t.ReceiptDate as ''Date'',t.ReceiptNo,t.TotalTransport as ''Transport'',t.TotalService as ''Service'',
t.TotalVat as ''Vat'',t.TotalAdvance as ''Advance'',t.TotalReceipt as ''Amt.Baht''
FROM (
select r.*,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),1,CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''))),'':'','''') as PaidBank,
REPLACE(SUBSTRING(REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'',''''),CHARINDEX('':'',REPLACE(r.PaidDetail,r.PaidType+'':'' + r.PaidAmount+'':'','''')),100),'':'','''') as PaidRef
from (
select rh.BranchCode,rh.ReceiptNo,rh.Receiptdate,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN ISNULL(rh.CancelProve,'''')='''' THEN c.NameEng ELSE ''**CANCEL** '' + c.NameEng END) as CustEName,
rh.TRemark as PaidDetail,
REPLACE(SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),'':'','''')  as PaidType,
REPLACE(SUBSTRING(REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''),1,CHARINDEX('':'',REPLACE(rh.TRemark,SUBSTRING(rh.TRemark,1,CHARINDEX('':'',rh.TRemark)),''''))),'':'','''')  as PaidAmount,
Sum(CASE WHEN id.AmtAdvance >0 AND ISNULL(rh.CancelProve,'''')='''' THEN rd.Amt+rd.AmtVAT ELSE 0 END) as TotalAdvance,
Sum(CASE WHEN id.AmtCharge >0 AND ISNULL(rh.CancelProve,'''')='''' AND id.AmtVat=0 THEN rd.Amt ELSE 0 END) as TotalTransport,
Sum(CASE WHEN id.AmtCharge >0 AND ISNULL(rh.CancelProve,'''')='''' AND id.AmtVat>0 THEN rd.Amt ELSE 0 END) as TotalService,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0 THEN rd.AmtVat ELSE 0 END) as TotalVat,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' AND id.AmtCharge >0  THEN rd.Amt50Tavi ELSE 0 END) as TotalWhtax,
Sum(CASE WHEN ISNULL(rh.CancelProve,'''')='''' THEN rd.Net+rd.Amt50Tavi ELSE 0 END) as TotalReceipt,
(CASE WHEN ISNULL(rh.CancelProve,'''')<>'''' THEN ''N'' ELSE ''Y'' END) as DocStatus,
(SELECT STUFF((
SELECT DISTINCT '',''+ InvoiceNo FROM Job_ReceiptDetail WHERE BranchCode=rh.BranchCode AND ReceiptNo=rh.ReceiptNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as InvNo
from Job_ReceiptHeader rh inner join Job_ReceiptDetail rd
ON rh.BranchCode=rd.BranchCode and rh.ReceiptNo=rd.ReceiptNo
left join Job_InvoiceDetail id on rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
left join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
left join Mas_Company c on rh.CustCode=c.CustCode and rh.CustBranch=c.Branch
where ISNULL(ih.CancelProve,'''')='''' AND rh.ReceiptType=''TAX'' {0}
group by rh.BranchCode,rh.ReceiptNo,rh.ReceiptDate,c.CustCode,c.TaxNumber,c.Branch,c.NameEng,rh.TRemark,rh.CancelProve
) r
) as t 
ORDER BY t.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_OUTPUTWHT', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,,,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_GROSSPROFIT', N'MAIN_SQL', N'select jt.JobTypeName as ''JobType'',sb.ShipByName as ''ShipBy'',
sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END) as ''Revenue'',
sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as ''Cost'',
count(DISTINCT c.JNo) as ''Total Job'',
convert(decimal(10,2),sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END)/count(DISTINCT c.JNo)) as ''Average Revenue'',
convert(decimal(10,2),sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END)) as ''Profit'',
convert(decimal(10,2),(sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END))/count(DISTINCT c.JNo)) as ''Average Profit'',
convert(decimal(10,2),sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END)/count(DISTINCT c.JNo)) as ''Average Cost''
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON c.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON c.ShipBy=sb.ShipBy
where ISNULL(b.CancelProve,'''')='''' AND a.BNet>0 AND c.JobStatus<90 {0}
group by jt.JobTypeName,sb.ShipByName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDAILY', N'MAIN_CLITERIA', N'AND,ih.DocDate, ih.CustCode,ih.RefNo,ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPORT', N'MAIN_SQL', N'SELECT j.JNo,j.InvProduct,j.LoadDate,j.CustCode,j.DeclareNumber,j.HAWB,j.InvNo,j.InvProductQty,j.InvProductUnit,j.ClearPort,j.TotalContainer,j.TotalGW,j.ETDDate,j.ETADate,j.ShippingEmp FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0}) j  ORDER BY j.ClearPort,j.LoadDate DESC,j.CustCode,j.InvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBPROFIT', N'MAIN_SQL', N'SELECT j.CSCode, j.JNo, j.DocDate as JobDate, 
jt.JobTypeName as JobType,sb.ShipByName as ShipBy,c.NameEng as CustEName,
j.HAWB, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo as CustInvNo,j.TotalContainer,
SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) AS SumCost,
SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumCharge,
SUM(CASE WHEN sv.GroupCode IN(''ERN'',''B-DEP'') THEN cd.UsedAmount ELSE 0 END) AS TotalEarnest,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) as Profit,
CASE WHEN SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)>0 THEN
CAST(100*((SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END))/SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) ) as numeric(10,2)) 
ELSE 0 END
as Margin
FROM dbo.Job_ClearHeader AS ch INNER JOIN
dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
 AND ch.ClrNo=cd.ClrNo
 INNER JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
 INNER JOIN
 dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE''
) jt ON j.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY''
) sb ON j.ShipBy=sb.ShipBy
inner join Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE (cd.BNet>0) AND (ISNULL(ch.CancelProve,'''')='''') AND (j.JobStatus < 90) {0}
GROUP BY j.CSCode, j.JNo, j.DocDate ,
jt.JobTypeName,sb.ShipByName,c.NameEng,
j.HAWB, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo,j.TotalContainer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.ManagerCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSALES', N'MAIN_SQL', N'SELECT c.TName,j.* FROM (
SELECT j.ManagerCode
,SUM(CASE WHEN j.JobStatus=0 THEN 1 ELSE 0 END) as ''PENDING CONFIRM'',SUM(CASE WHEN j.JobStatus=1 THEN 1 ELSE 0 END) as ''JOB CONFIRMED'',SUM(CASE WHEN j.JobStatus=2 THEN 1 ELSE 0 END) as ''JOB IN PROCESS'',SUM(CASE WHEN j.JobStatus=3 THEN 1 ELSE 0 END) as ''CLEARANCE COMPLETED'',SUM(CASE WHEN j.JobStatus=4 THEN 1 ELSE 0 END) as ''READY FOR BILLING'',SUM(CASE WHEN j.JobStatus=5 THEN 1 ELSE 0 END) as ''PARTIAL BILLING'',SUM(CASE WHEN j.JobStatus=6 THEN 1 ELSE 0 END) as ''BILLING COMPLETED'',SUM(CASE WHEN j.JobStatus=7 THEN 1 ELSE 0 END) as ''PAYMENT COMPLETED'',SUM(CASE WHEN j.JobStatus=98 THEN 1 ELSE 0 END) as ''HOLD FOR CHECKING'',SUM(CASE WHEN j.JobStatus=99 THEN 1 ELSE 0 END) as ''CANCELLED''
FROM Job_Order j {0}
GROUP BY j.ManagerCode) j INNER JOIN Mas_User c ON j.ManagerCode=c.UserID ORDER BY c.TName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBSHIPBY', N'MAIN_CLITERIA', N'WHERE,j.LoadDate,j.CustCode,j.JNo,j.ShippingEmp,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVDETAIL', N'MAIN_SQL', N'SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.SDescription,inv.AmtAdvance,inv.AmtCharge as TotalCharge,inv.AmtCredit,
(CASE WHEN inv.AmtCharge>0 THEN inv.AmtVat ELSE 0 END) as TotalVAT
,(CASE WHEN inv.AmtCharge>0 THEN inv.Amt50Tavi ELSE 0 END) as TotalWHT
,inv.TotalInv as TotalNet,inv.ReceivedNet as TotalReceived,inv.ReceiptNo,inv.LastVoucher FROM (
select ih.*,id.ItemNo,id.SICode,id.SDescription,id.ExpSlipNO,id.SRemark,
id.Amt,id.AmtDiscount,id.AmtCredit,
id.AmtCharge,id.AmtAdvance,id.AmtVat,id.Amt50Tavi,
id.TotalAmt,id.TotalAmt-id.AmtCredit as TotalInv,
r.ReceivedAmt,r.ReceivedVat,r.ReceivedWht,r.ReceivedNet,
r.ReceiptNo,
c.CreditAmt,c.CreditVat,c.CreditWht,c.CreditNet,
c.CreditNo,r.LastVoucher,
r.ControlLink,v.PRVoucher,v.PRType,v.acType,v.ChqNo,v.ChqDate,
v.RecvBank,v.RecvBranch,v.BookCode,v.BankCode,v.BankBranch,
c1.NameThai as CustTName,c2.NameThai as BillTName,
c1.NameEng as CustEName,c2.NameEng as BillEName
from Job_InvoiceDetail id inner join Job_InvoiceHeader ih
on id.BranchCode=ih.BranchCode
and id.DocNo=ih.DocNo
left join (
	select rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo,
    max(rd.ReceiptNo) as ReceiptNo,max(rd.VoucherNo) as LastVoucher,
    max(rd.ControlNo + ''-'' +Convert(varchar,rd.ControlItemNo)) as ControlLink,
	sum(rd.Amt) as ReceivedAmt,
	sum(rd.AmtVAT) as ReceivedVat,
	sum(rd.Amt50Tavi) as ReceivedWht,
	sum(rd.Net) as ReceivedNet
	from Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
	on rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
	and ISNULL(rh.CancelProve,'''')=''''
	group by rd.BranchCode,rd.InvoiceNo,rd.InvoiceItemNo
) r
on id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
left join (
	
select cd.BranchCode,cd.BillingNo,cd.BillItemNo,    
	sum(cd.DiffAmt) as CreditAmt,
	sum(cd.VATAmt) as CreditVat,
	sum(cd.WHTAmt) as CreditWht,
	sum(cd.TotalNet) as CreditNet,
    max(cd.DocNo) as CreditNo
	from Job_CNDNDetail cd inner join Job_CNDNHeader ch
	on cd.BranchCode=ch.BranchCode AND cd.DocNo=ch.DocNo
	and ch.DocStatus=1
	group by cd.BranchCode,cd.BillingNo,cd.BillItemNo

) c
on id.BranchCode=c.BranchCode AND id.DocNo=c.BillingNo AND id.ItemNo=c.BillItemNo
left join Job_CashControlSub v ON r.BranchCode=v.BranchCode AND r.ControlLink=(v.ControlNo+''-''+Convert(varchar,v.ItemNo)) 
left join Mas_Company c1 on ih.CustCode=c1.CustCode AND ih.CustBranch=c1.Branch
left join Mas_Company c2 on ih.BillToCustCode=c2.CustCode AND ih.BillToCustBranch=c2.Branch
where ISNULL(ih.CancelProve,'''')='''' {0}
) inv ORDER BY inv.SDescription,inv.DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSTATUS', N'MAIN_CLITERIA', N'WHERE,ih.DocDate,ih.CustCode,ih.RefNo,ih.EmpCode,,(CASE WHEN ISNULL(ih.CancelProve,'''')<>'''' THEN 99 ELSE 0 END),ih.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATBUY', N'MAIN_SQL', N'SELECT ExpenseDate,SlipNo,VenderName,TaxNumber,Branch,ExpenseAmt,ExpenseVAT,CancelReson FROM (
SELECT cd.Date50Tavi as ExpenseDate, cd.SlipNO as SlipNo, v.TName as VenderName, v.TaxNumber, v.BranchCode as Branch, v.VenCode, cd.UsedAmount as ExpenseAmt, cd.ChargeVAT as ExpenseVAT, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.PaymentDate IS NOT NULL) AND (cd.SlipNO <> '''')
UNION
SELECT h.CancelDate, ''*''+cd.SlipNO, v.TName + ''**ยกเลิก**'', v.TaxNumber, v.BranchCode, v.VenCode, 0, 0, j.CustCode, j.CustBranch, cd.JobNo, 
    c.TaxNumber AS CustTaxNumber, h.DocNo, h.DocDate, h.PoNo, h.RefNo, h.AdvRef, d.AdvItemNo, h.PaymentRef, ch.ClrNo, ch.ClrDate, h.PaymentDate, d.SICode, 
    d.SDescription, d.Amt, d.AmtVAT, d.AmtWHT, d.Total, d.BookingRefNo, d.BookingItemNo, h.CancelReson, h.CancelDate
FROM     dbo.Job_PaymentDetail AS d INNER JOIN
    dbo.Job_ClearDetail AS cd ON d.BranchCode = cd.BranchCode AND d.ClrItemNo = cd.ItemNo AND d.ClrRefNo = cd.ClrNo INNER JOIN
    dbo.Job_ClearHeader AS ch ON cd.BranchCode = ch.BranchCode AND cd.ClrNo = ch.ClrNo INNER JOIN
    dbo.Job_PaymentHeader AS h ON d.BranchCode = h.BranchCode AND d.DocNo = h.DocNo INNER JOIN
    dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
    dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo INNER JOIN
    dbo.Mas_Company AS c ON j.CustCode = c.CustCode AND j.CustBranch = c.Branch
WHERE (ch.DocStatus <> 99) AND (cd.ChargeVAT > 0) AND (h.CancelDate IS NOT NULL) AND (cd.SlipNO <> '''')
) AS t {0} ORDER BY ExpenseDate,SlipNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'MAIN_CLITERIA', N'WHERE,t.ReceiptDate,t.CustCode,,,,,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_INVSUMMARY', N'MAIN_SQL', N'SELECT DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,
ISNULL(AmtCost,0) as TotalCost,
SUM(CASE WHEN IsCredit=1 THEN BNet ELSE 0 END) as TotalAdvance,
SUM(CASE WHEN IsCredit=0 THEN BNet ELSE 0 END) as TotalCharge,
SUM(AmtCredit) as TotalPrepaid,
SUM(ReceiptNet) as TotalReceived,
SUM(Balance) as TotalBalance,
SUM(CASE WHEN IsCredit=0 THEN BNet ELSE 0 END)-ISNULL(AmtCost,0) as TotalProfit
FROM (
	select f.BranchCode,f.DocNo,f.DocDate as InvDate, f.CustCode,f.CustBranch,c.JNo,c.DocDate as JobDate ,b.ClrNo,b.ClrDate,c.DeclareNumber,c.InvNo,
	c.DutyDate,c.CloseJobDate,c.CSCode,c.ShippingEmp,c.ManagerCode,c.InvProduct,c.VesselName,c.TotalContainer,e.Title+''''+e.NameThai as CustName,
	f.BillAcceptNo,f.BillIssueDate,f.BillAcceptDate,f.DueDate,a.SICode,
	d.NameThai as SDescription,d.IsExpense,d.IsCredit,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	h.AmtAdvance,h.AmtCharge,h.AmtVat,h.Amt50Tavi,h.TotalAmt,h.AmtCredit,(h.TotalAmt+h.AmtCredit) as TotalNet,g.ReceiptNet,
	g.ReceiptNo,g.VoucherNo,i.AdjAmt as AdjustAmt,(a.BNet-h.AmtCredit)-ISNULL(g.ReceiptNet,0) as Balance
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	inner join Job_InvoiceHeader f on a.BranchCode=f.BranchCode and a.LinkBillNo=f.DocNo
	left join (
		SELECT dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,Max(dt.ReceiptNo) as ReceiptNo 
		,sum(dt.Net) as ReceiptNet,Max(dt.VoucherNo) as VoucherNo from
		Job_ReceiptDetail dt INNER JOIN Job_ReceiptHeader hd ON dt.BranchCode=hd.BranchCode
		AND dt.ReceiptNo=hd.ReceiptNo WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.InvoiceNo<>'''' 
		GROUP BY dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo) g 
		ON a.BranchCode=g.BranchCode AND a.LinkBillNo=g.InvoiceNo AND a.LinkItem=g.InvoiceItemNo
	inner join Job_InvoiceDetail h on a.BranchCode=h.BranchCode and a.LinkBillNo=h.DocNo and a.LinkItem=h.ItemNo
	left join (
		SELECT dt.BranchCode,dt.BillingNo as InvoiceNo,dt.BillItemNo as InvoiceItemNo,sum(dt.TotalNet) as AdjAmt FROM Job_CNDNDetail dt inner join Job_CNDNHeader hd on dt.BranchCode=hd.BranchCode
		and dt.DocNo=hd.DocNo WHERE hd.DocStatus<>99 GROUP BY dt.BranchCode,dt.BillingNo,dt.BillItemNo
		) i 
		ON h.BranchCode=i.BranchCode and h.DocNo=i.InvoiceNo and h.ItemNo=i.InvoiceItemNo
	where ISNULL(b.CancelProve,'''')='''' AND ISNULL(f.CancelProve,'''')='''' {0}
) inv 
left join (
	SELECT dt.BranchCode,dt.LinkBillNo,dt.JobNo,SUM(dt.BNet) as AmtCost FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo WHERE ISNULL(hd.CancelProve,'''')=''''
	AND dt.LinkItem=0 AND hd.ClearType=2 GROUP BY dt.BranchCode,dt.LinkBillNo,dt.JobNo
) cost ON inv.BranchCode=cost.BranchCode AND inv.DocNo=cost.LinkBillNo AND inv.JNo=cost.JobNo
GROUP BY DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,AmtCost
ORDER BY CustCode,InvDate,DocNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBADV', N'MAIN_CLITERIA', N'AND,c.PaymentDate,c.CustCode,a.ForJNo,c.ReqBy,a.VenCode,c.DocStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_PVDAILY', N'MAIN_SQL', N'SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (
SELECT a.*,ISNULL(c.CreditUsed,0) AS AmountUsed,(a.CashAmount+a.ChqAmount)-ISNULL(c.CreditUsed,0) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate
FROM Job_CashControlSub a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo)) as DocNo,SUM(d.PaidAmount) as CreditUsed    
    FROM Job_CashControlSub h INNER JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    )
    GROUP BY h.BranchCode,SUBSTRING(d.DocNo,0,CHARINDEX(''#'',d.DocNo))
) c
ON a.BranchCode=c.BranchCode
AND a.DocNo=c.DocNo 
WHERE ISNULL(a.PRType,''R'')=''P'' AND  NOT ISNULL(b.CancelProve,'''')<>''''
 ) t {0} ORDER BY VoucherDate,ControlNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDAILY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net as TotalReceived,rc.PRVoucher FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)<>''T'' {0}) rc ORDER BY rc.ReceiptDate,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPDETAIL', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode,rd.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ACCEXP', N'MAIN_SQL', N'SELECT j.CustCode,c.ClrNo,c.ClrDate,c.JobNo,c.SDescription,c.VenderCode,c.AmtCostClear+c.AmtCostUnClear+c.AmtCostSlip+c.AmtCostNoSlip+c.CostVat as TotalExpClear,
c.AmtCostSlip,c.AmtCostNoSlip,c.CostVat as TotalVAT,c.CostTax as TotalWHT,c.AmtCostClear as ''BILLED'',c.AmtCostUnClear as ''UNBILLED'',
c.RefNo,c.PaymentDate,c.SlipNo
FROM (
select h.BranchCode,h.ClrNo,h.ClrDate,d.ItemNo,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,d.UsedAmount,d.BNet,
(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as AmtAdvance,
(CASE WHEN s.IsHaveSlip=1 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostSlip,
(CASE WHEN s.IsHaveSlip=0 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostNoSlip,
(CASE WHEN s.IsExpense=1 THEN d.ChargeVAT ELSE 0 END) as CostVat,
(CASE WHEN s.IsExpense=1 THEN d.Tax50Tavi ELSE 0 END) as CostTax,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostClear,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostUnClear,
d.AdvNO as RefNo,a.PaymentDate
from Job_ClearDetail d left join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
inner join Job_AdvHeader a ON d.BranchCode=a.BranchCode AND d.AdvNO=a.AdvNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=1 OR s.IsExpense=1)
AND NOT isnull(a.CancelProve,'''')<>'''' AND d.AdvNO<>''''
union
select h.BranchCode,h.ClrNo,h.ClrDate,d.ItemNo,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,d.UsedAmount,d.BNet,
(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as AmtAdvance,
(CASE WHEN s.IsHaveSlip=1 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostSlip,
(CASE WHEN s.IsHaveSlip=0 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostNoSlip,
(CASE WHEN s.IsExpense=1 THEN d.ChargeVAT ELSE 0 END) as CostVat,
(CASE WHEN s.IsExpense=1 THEN d.Tax50Tavi ELSE 0 END) as CostTax,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostClear,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostUnClear,
d.VenderBillingNo as RefNo,a.PaymentDate
from Job_ClearDetail d left join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
left join Job_PaymentHeader a ON d.BranchCode=a.BranchCode AND SUBSTRING(d.VenderBillingNo,1,13)=a.DocNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=1 OR s.IsExpense=1)
AND ISNULL(d.VenderBillingNo,'''')<>''''
union
select h.BranchCode,h.ClrNo,h.ClrDate,d.ItemNo,d.JobNo,d.SDescription,d.SlipNo,d.VenderCode,d.UsedAmount,d.BNet,
(CASE WHEN s.IsCredit=1 AND s.IsExpense=0 THEN d.UsedAmount ELSE 0 END) as AmtAdvance,
(CASE WHEN s.IsHaveSlip=1 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostSlip,
(CASE WHEN s.IsHaveSlip=0 AND s.IsExpense=1 THEN d.UsedAmount ELSE 0 END) as AmtCostNoSlip,
(CASE WHEN s.IsExpense=1 THEN d.ChargeVAT ELSE 0 END) as CostVat,
(CASE WHEN s.IsExpense=1 THEN d.Tax50Tavi ELSE 0 END) as CostTax,
d.LinkBillNo as InvoiceNo,
(CASE WHEN ISNULL(d.LinkBillNo,'''')<>'''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostClear,
(CASE WHEN ISNULL(d.LinkBillNo,'''')='''' AND s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet+d.Tax50Tavi ELSE 0 END) as AmtCostUnClear,
h.ClrNo as RefNo,h.ReceiveDate
from Job_ClearDetail d left join Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
left join Job_SrvSingle s ON d.SICode=s.SICode
where NOT isnull(h.CancelProve,'''')<>'''' AND (s.IsCredit=1 OR s.IsExpense=1)
AND ISNULL(d.VenderBillingNo,'''')='''' AND ISNULL(d.AdvNO,'''')=''''
) c LEFT JOIN Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBANALYSIS', N'MAIN_SQL', N'SELECT CustCode,CSCode,AgentCode,JNo, DeclareNumber,DocDate, CreateDate, ConfirmDate,
DATEDIFF(d,CreateDate,DocDate) as OpenDays,
DutyDate,
DATEDIFF(d,CreateDate,DutyDate) as DutyDays,
 LastClearDate,
 DATEDIFF(d,DutyDate,LastClearDate) as ClearDays,
  CloseJobDate,
 DATEDIFF(d,DutyDate,CloseJobDate) as CloseDays,
 LastInvDate,
 DATEDIFF(d,LastClearDate,LastInvDate) as InvDays,
 LastRcvDate,
 DATEDIFF(d,LastInvDate,LastRcvDate) as RcvDays
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>''''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(ih.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'''')<>'''' AND NOT ISNULL(rh.CancelProve,'''')<>'''' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0} ORDER BY jd.CustCode,jd.JNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'MAIN_CLITERIA', N'AND,h.ReceiptDate,j.CustCode,j.JNo,j.ManagerCode,j.ForwarderCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOMM', N'MAIN_SQL', N'select q.DocStatus,j.ManagerCode,j.CustCode,j.CustBranch,j.QNo,q.DocDate as QuoDate,
j.JNo,j.InvNo,d.ReceiptNo,h.ReceiptDate,j.TotalContainer,
MAX(d.VoucherNo) as VoucherNo,SUM(d.Net) as TotalCharge,
dbo.GetCommission(SUM(d.Net),j.ManagerCode) as Commission
from Job_ReceiptDetail d inner join Job_ReceiptHeader h
on d.BranchCode=h.BranchCode 
and d.ReceiptNo=h.ReceiptNo
inner join Job_ClearDetail c
on d.BranchCode=c.BranchCode 
and d.InvoiceNo=c.LinkBillNo
and d.InvoiceItemNo=c.LinkItem
inner join Job_SrvSingle s
on d.SICode=s.SICode
inner join Job_Order j
on c.BranchCode=j.BranchCode
and c.JobNo=j.JNo
left join Job_QuotationHeader q
on j.BranchCode =q.BranchCode
and j.QNo=q.QNo
where NOT ISNULL(h.CancelProve,'''')<>''''
and s.IsExpense=0 and s.IsCredit=0 {0}
group by j.ManagerCode,j.CustCode,j.CustBranch,j.QNo,q.DocDate,q.DocStatus,j.JNo,
j.InvNo,j.TotalContainer,d.ReceiptNo,h.ReceiptDate')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCOST', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.ForwarderCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDAILY', N'MAIN_SQL', N'SELECT ad.AdvNo,ad.AdvDate,ad.PaymentDate,ad.PaymentRef,ad.EmpCode as ReqBy,ad.SDescription,ad.CustCode,ad.ForJNo,
ad.BaseAmount as Amount,ad.ChargeVAT as TotalVAT,
ad.AdvPayAmount as TotalAdvance,ad.Charge50Tavi as TotalWHT, 
(CASE WHEN ad.PaymentRef<>'''' THEN ad.AdvPayAmount ELSE 0 END) as ''Advance Paid''
FROM (
select a.*,d.ForJNo,d.ItemNo,d.SICode,d.SDescription,
d.IsDuplicate,d.IsChargeVAT,d.Is50Tavi,d.CurrencyCode,d.ExchangeRate as DExchangeRate,
b.TaxNumber,b.NameThai,b.NameEng,d.VenCode,d.TRemark as DRemark,
d.BaseAmount,d.RateVAT,d.ChargeVAT,d.Rate50Tavi,d.Charge50Tavi,
d.AdvQty,d.UnitPrice,d.AdvNet,d.AdvPayAmount,
d.BaseVATExc,d.VATExc,d.BaseVATInc,d.VATInc,
d.Base50TaviInc,d.WHTExc,d.Base50TaviExc,d.WHTInc,
d.BaseVATInc+d.BaseVATExc as BaseVAT,d.Base50TaviExc+d.Base50TaviInc as Base50Tavi,j.*
FROM Job_AdvHeader as a LEFT JOIN
Mas_Company b ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
LEFT JOIN (
    SELECT *,
    VATRate as RateVAT,AdvAmount+ChargeVAT as AdvPayAmount,
    AdvAmount as BaseAmount,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as Base50TaviExc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT<>2 THEN AdvAmount ELSE 0 END) as BaseVATExc,
    (CASE WHEN Charge50Tavi>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as Base50TaviInc,
    (CASE WHEN ChargeVAT>0 And IsChargeVAT=2 THEN AdvAmount ELSE 0 END) as BaseVATInc,
    (CASE WHEN IsChargeVAT<>2 THEN ChargeVAT ELSE 0 END) as VATExc,
    (CASE WHEN IsChargeVAT=2 THEN ChargeVAT ELSE 0 END) as VATInc,
    (CASE WHEN IsChargeVAT<>2 THEN Charge50Tavi ELSE 0 END) as WHTExc,
    (CASE WHEN IsChargeVAT=2 THEN Charge50Tavi ELSE 0 END) as WHTInc
    FROM Job_AdvDetail 
) d
ON a.BranchCode=d.BranchCode AND a.AdvNo=d.AdvNo
LEFT JOIN (
SELECT BranchCode as JobBranch,JNo as JobNo,JRevise, ConfirmDate, CPolicyCode, DocDate, CustContactName, QNo, Revise, ManagerCode, CSCode, JobStatus, 
                         InvNo as CustInvNo, InvTotal, InvProduct, InvCountry, InvFCountry, InvInterPort, InvProductQty, InvProductUnit, InvCurUnit, InvCurRate, ImExDate, BLNo, 
                         BookingNo, ClearPort, ClearPortNo, ClearDate, LoadDate, ForwarderCode, AgentCode, VesselName, ETDDate, ETADate, ETTime, FNetPrice, BNetPrice, 
                          CancelProveTime, CloseJobDate, CloseJobTime, CloseJobBy, DeclareType, DeclareNumber, 
                         DeclareStatus, TyAuthorSp, Ty19BIS, TyClearTax, TyClearTaxReson, EstDeliverDate, EstDeliverTime, TotalContainer, DutyDate, DutyAmount, DutyCustPayOther, 
                         DutyCustPayChqAmt, DutyCustPayBankAmt, DutyCustPayEPAYAmt, DutyCustPayCardAmt, DutyCustPayCashAmt, DutyCustPayOtherAmt, DutyLtdPayOther, 
                         DutyLtdPayChqAmt, DutyLtdPayEPAYAmt, DutyLtdPayCashAmt, DutyLtdPayOtherAmt, ConfirmChqDate, ShippingEmp, ShippingCmd, TotalGW, GWUnit, TSRequest, 
                         ShipmentType, ReadyToClearDate, Commission, CommPayTo, ProjectName, MVesselName, TotalNW, Measurement, CustRefNO, TotalQty, HAWB, MAWB, 
                         consigneecode, privilegests, DeliveryNo, DeliveryTo, DeliveryAddr, CreateDate
FROM dbo.Job_Order 
) j on d.BranchCode=j.JobBranch AND d.ForJNo=j.JobNo WHERE a.DocStatus<>99 {0}
) ad  ORDER BY ad.AdvDate,ad.AdvNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVDETAIL', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,d.ForJNo,a.ReqBy,d.VenCode,a.DocStatus,a.BranchCode,d.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'MAIN_CLITERIA', N'AND,t.ETADate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVIMPORT', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETADate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType=1 AND t.JobStatus<>99 {0}  ORDER BY t.ETADate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'MAIN_CLITERIA', N'AND,t.ETDDate,t.CustCode,t.ForJNo,t.AdvBy,t.ForwarderCode,t.AdvStatus,t.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVOTHER', N'MAIN_SQL', N'SELECT t.ForJNo,t.ETDDate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (
SELECT        dbo.Job_AdvDetail.BranchCode, dbo.Job_AdvDetail.AdvNo, dbo.Job_AdvDetail.ItemNo, dbo.Job_AdvDetail.STCode, dbo.Job_AdvDetail.SICode, 
dbo.Job_AdvDetail.AdvAmount, dbo.Job_AdvDetail.IsChargeVAT, dbo.Job_AdvDetail.ChargeVAT, dbo.Job_AdvDetail.Rate50Tavi, dbo.Job_AdvDetail.Charge50Tavi, 
dbo.Job_AdvDetail.TRemark, dbo.Job_AdvDetail.IsDuplicate, dbo.Job_AdvDetail.PayChqTo, dbo.Job_AdvDetail.Doc50Tavi, dbo.Job_AdvDetail.Is50Tavi, 
dbo.Job_AdvDetail.VATRate, dbo.Job_AdvDetail.AdvNet, dbo.Job_AdvDetail.SDescription, dbo.Job_AdvDetail.ForJNo, dbo.Job_AdvDetail.VenCode, 
dbo.Job_AdvDetail.CurrencyCode, dbo.Job_AdvDetail.ExchangeRate, dbo.Job_AdvDetail.AdvQty, dbo.Job_AdvDetail.UnitPrice, dbo.Job_AdvHeader.JobType, 
dbo.Job_AdvHeader.AdvDate, dbo.Job_AdvHeader.AdvType, dbo.Job_AdvHeader.EmpCode, dbo.Job_AdvHeader.JNo, dbo.Job_AdvHeader.InvNo, 
dbo.Job_AdvHeader.DocStatus as AdvStatus, dbo.Job_AdvHeader.VATRate AS Expr1, dbo.Job_AdvHeader.TotalAdvance, dbo.Job_AdvHeader.TotalVAT, 
dbo.Job_AdvHeader.Total50Tavi, dbo.Job_AdvHeader.ApproveBy, dbo.Job_AdvHeader.ApproveDate, dbo.Job_AdvHeader.ApproveTime, 
dbo.Job_AdvHeader.PaymentBy, dbo.Job_AdvHeader.PaymentDate, dbo.Job_AdvHeader.PaymentTime, dbo.Job_AdvHeader.PaymentRef, 
dbo.Job_AdvHeader.CancelReson, dbo.Job_AdvHeader.CancelProve, dbo.Job_AdvHeader.CancelDate, dbo.Job_AdvHeader.CancelTime, 
dbo.Job_AdvHeader.AdvCash, dbo.Job_AdvHeader.AdvChqCash, dbo.Job_AdvHeader.AdvChq, dbo.Job_AdvHeader.AdvCred, dbo.Job_AdvHeader.PayChqDate, 
dbo.Job_AdvHeader.Doc50Tavi AS AdvWhtaxNo, dbo.Job_AdvHeader.AdvBy, dbo.Job_AdvHeader.CustCode, dbo.Job_AdvHeader.CustBranch, 
dbo.Job_AdvHeader.ShipBy, dbo.Job_AdvHeader.PaymentNo, dbo.Job_AdvHeader.MainCurrency, dbo.Job_AdvHeader.SubCurrency, 
dbo.Job_AdvHeader.ExchangeRate AS AdvExcRate, dbo.Job_Order.JRevise, dbo.Job_Order.ConfirmDate, dbo.Job_Order.CPolicyCode, dbo.Job_Order.DocDate, 
dbo.Job_Order.CustContactName, dbo.Job_Order.QNo, dbo.Job_Order.Revise, dbo.Job_Order.ManagerCode, dbo.Job_Order.CSCode, dbo.Job_Order.Description, 
dbo.Job_Order.JobStatus, dbo.Job_Order.InvNo AS CustInvNo, dbo.Job_Order.InvTotal, dbo.Job_Order.InvProduct, dbo.Job_Order.InvCountry, 
dbo.Job_Order.InvFCountry, dbo.Job_Order.InvInterPort, dbo.Job_Order.InvProductQty, dbo.Job_Order.InvProductUnit, dbo.Job_Order.InvCurUnit, 
dbo.Job_Order.InvCurRate, dbo.Job_Order.ImExDate, dbo.Job_Order.BLNo, dbo.Job_Order.BookingNo, dbo.Job_Order.ClearPort, dbo.Job_Order.ClearPortNo, 
dbo.Job_Order.ClearDate, dbo.Job_Order.LoadDate, dbo.Job_Order.ForwarderCode, dbo.Job_Order.AgentCode, dbo.Job_Order.VesselName, dbo.Job_Order.ETDDate, 
dbo.Job_Order.ETADate, dbo.Job_Order.ETTime, dbo.Job_Order.FNetPrice, dbo.Job_Order.BNetPrice, dbo.Job_Order.CancelProveDate, 
dbo.Job_Order.CancelProveTime, dbo.Job_Order.CloseJobDate, dbo.Job_Order.CloseJobTime, dbo.Job_Order.CloseJobBy, dbo.Job_Order.DeclareType, 
dbo.Job_Order.DeclareNumber, dbo.Job_Order.DeclareStatus, dbo.Job_Order.TyAuthorSp, dbo.Job_Order.Ty19BIS, dbo.Job_Order.TyClearTax, 
dbo.Job_Order.TyClearTaxReson, dbo.Job_Order.EstDeliverDate, dbo.Job_Order.EstDeliverTime, dbo.Job_Order.TotalContainer, dbo.Job_Order.DutyDate, 
dbo.Job_Order.DutyAmount, dbo.Job_Order.DutyCustPayOther, dbo.Job_Order.DutyCustPayChqAmt, dbo.Job_Order.DutyCustPayBankAmt, 
dbo.Job_Order.DutyCustPayEPAYAmt, dbo.Job_Order.DutyCustPayCardAmt, dbo.Job_Order.DutyCustPayCashAmt, dbo.Job_Order.DutyCustPayOtherAmt, 
dbo.Job_Order.DutyLtdPayOther, dbo.Job_Order.DutyLtdPayChqAmt, dbo.Job_Order.DutyLtdPayEPAYAmt, dbo.Job_Order.DutyLtdPayCashAmt, 
dbo.Job_Order.DutyLtdPayOtherAmt, dbo.Job_Order.ConfirmChqDate, dbo.Job_Order.ShippingEmp, dbo.Job_Order.ShippingCmd, dbo.Job_Order.TotalGW, 
dbo.Job_Order.GWUnit, dbo.Job_Order.TSRequest, dbo.Job_Order.ShipmentType, dbo.Job_Order.ReadyToClearDate, dbo.Job_Order.Commission, 
dbo.Job_Order.CommPayTo, dbo.Job_Order.ProjectName, dbo.Job_Order.MVesselName, dbo.Job_Order.TotalNW, dbo.Job_Order.Measurement, 
dbo.Job_Order.CustRefNO, dbo.Job_Order.TotalQty, dbo.Job_Order.HAWB, dbo.Job_Order.MAWB, dbo.Job_Order.consigneecode, dbo.Job_Order.privilegests, 
dbo.Job_Order.DeliveryNo, dbo.Job_Order.DeliveryTo, dbo.Job_Order.DeliveryAddr, dbo.Job_Order.CreateDate,
dbo.Job_ClearDetail.ClrNo,dbo.Job_ClearDetail.ItemNo AS ClrItemNo, 
dbo.Job_ClearDetail.LinkItem, dbo.Job_ClearDetail.SICode AS ClrSICode, dbo.Job_ClearDetail.SDescription AS ClrSDescription, dbo.Job_ClearDetail.VenderCode, 
dbo.Job_ClearDetail.Qty, dbo.Job_ClearDetail.UnitCode, dbo.Job_ClearDetail.CurrencyCode AS DCurrency, dbo.Job_ClearDetail.CurRate, 
dbo.Job_ClearDetail.UnitPrice AS ClrUnitPrice, dbo.Job_ClearDetail.FPrice, dbo.Job_ClearDetail.BPrice, dbo.Job_ClearDetail.QUnitPrice, 
dbo.Job_ClearDetail.QFPrice, dbo.Job_ClearDetail.QBPrice, dbo.Job_ClearDetail.UnitCost, dbo.Job_ClearDetail.FCost, dbo.Job_ClearDetail.BCost, 
dbo.Job_ClearDetail.ChargeVAT AS ClrVat, dbo.Job_ClearDetail.Tax50Tavi AS ClrTax, dbo.Job_ClearDetail.UsedAmount, dbo.Job_ClearDetail.IsQuoItem, 
dbo.Job_ClearDetail.SlipNO, dbo.Job_ClearDetail.Remark, dbo.Job_ClearDetail.IsLtdAdv50Tavi, dbo.Job_ClearDetail.Pay50TaviTo, dbo.Job_ClearDetail.NO50Tavi, 
dbo.Job_ClearDetail.Date50Tavi, dbo.Job_ClearDetail.VenderBillingNo, dbo.Job_ClearDetail.AirQtyStep, dbo.Job_ClearDetail.StepSub, dbo.Job_ClearDetail.JobNo, 
dbo.Job_ClearDetail.AdvItemNo, dbo.Job_ClearDetail.LinkBillNo, dbo.Job_ClearDetail.VATType, dbo.Job_ClearDetail.VATRate AS ClrVatRate, 
dbo.Job_ClearDetail.Tax50TaviRate, dbo.Job_ClearDetail.FNet, dbo.Job_ClearDetail.BNet, dbo.Job_ClearHeader.ClrDate, dbo.Job_ClearHeader.ClearanceDate, 
dbo.Job_ClearHeader.EmpCode AS ClrBy, dbo.Job_ClearHeader.AdvRefNo, dbo.Job_ClearHeader.AdvTotal, dbo.Job_ClearHeader.ClearType, 
dbo.Job_ClearHeader.ClearFrom, dbo.Job_ClearHeader.DocStatus AS ClrStatus, dbo.Job_ClearHeader.TotalExpense, dbo.Job_ClearHeader.ReceiveBy, 
dbo.Job_ClearHeader.ReceiveDate, dbo.Job_ClearHeader.ReceiveTime, dbo.Job_ClearHeader.ReceiveRef, dbo.Job_ClearHeader.CoPersonCode, 
dbo.Job_ClearHeader.CTN_NO, dbo.Job_ClearHeader.ClearTotal, dbo.Job_ClearHeader.ClearVat, dbo.Job_ClearHeader.ClearWht, dbo.Job_ClearHeader.ClearNet, 
dbo.Job_ClearHeader.ClearBill, dbo.Job_ClearHeader.ClearCost,jt.JobTypeName,sb.ShipByName
FROM dbo.Job_ClearHeader RIGHT OUTER JOIN
dbo.Job_ClearDetail RIGHT OUTER JOIN
dbo.Job_AdvDetail INNER JOIN
dbo.Job_AdvHeader ON dbo.Job_AdvDetail.BranchCode = dbo.Job_AdvHeader.BranchCode AND dbo.Job_AdvDetail.AdvNo = dbo.Job_AdvHeader.AdvNo ON 
dbo.Job_ClearDetail.AdvItemNo = dbo.Job_AdvDetail.ItemNo AND dbo.Job_ClearDetail.AdvNO = dbo.Job_AdvDetail.AdvNo AND 
dbo.Job_ClearDetail.BranchCode = dbo.Job_AdvDetail.BranchCode LEFT OUTER JOIN
dbo.Job_Order ON dbo.Job_AdvDetail.BranchCode = dbo.Job_Order.BranchCode AND dbo.Job_AdvDetail.ForJNo = dbo.Job_Order.JNo ON 
dbo.Job_ClearHeader.BranchCode = dbo.Job_ClearDetail.BranchCode AND dbo.Job_ClearHeader.ClrNo = dbo.Job_ClearDetail.ClrNo
INNER JOIN (SELECT CAST(ConfigKey as Int) as JobType,ConfigValue as JobTypeName FROM dbo.Mas_Config WHERE ConfigCode=''JOB_TYPE'') jt ON jt.JobType=dbo.Job_Order.JobType
INNER JOIN (SELECT CAST(ConfigKey as Int) as ShipBy,ConfigValue as ShipByName FROM dbo.Mas_Config WHERE ConfigCode=''SHIP_BY'') sb ON sb.ShipBy=dbo.Job_Order.ShipBy
WHERE dbo.Job_AdvHeader.DocStatus<>99 AND ISNULL(dbo.Job_ClearHeader.DocStatus,0)<>99 
) as t WHERE t.JobType>2 AND t.JobStatus<>99  {0} ORDER BY t.ETDDate,t.ForJNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'MAIN_CLITERIA', N'AND,a.PaymentDate,a.CustCode,b.ForJNo,a.EmpCode,,a.DocStatus,a.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_ADVSUMMARY', N'MAIN_SQL', N'select a.AdvNo,a.EmpCode,c.CustCode,c.NameThai as CustName,b.ForJNo as JobNo,
j.DutyDate as InspectionDate,a.PaymentDate,a.PaymentRef,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt,st.AdvStatusName
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'''')=''''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
	SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'''')='''' AND dt.DocType=''CLR''
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+''#''+Convert(varchar,b.ItemNo))=e.DocNo
inner join Job_Order j ON b.BranchCode=j.BranchCode AND b.ForJNo=j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as AdvStatus, ConfigValue as AdvStatusName FROM Mas_Config WHERE ConfigCode=''ADV_STATUS''
) st ON a.DocStatus=st.AdvStatus
WHERE a.DocStatus<>99 {0}
GROUP BY a.AdvNo,a.EmpCode,c.CustCode,c.NameThai,b.ForJNo,
j.DutyDate,a.PaymentDate,a.PaymentRef,e.ReceiveRef,e.PaidAmount,st.AdvStatusName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'MAIN_CLITERIA', N'AND,h.DocDate,,,h.EmpCode,h.VenCode,,h.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBAL', N'MAIN_SQL', N'SELECT h.DocNo, h.DocDate, v.TName, h.PoNo, h.RefNo, 
CASE WHEN ISNULL(h.PaymentRef,'''')<>'''' THEN h.TotalNet ELSE 0 END as PaidAmount,
CASE WHEN NOT ISNULL(h.PaymentRef,'''')<>'''' THEN h.TotalNet ELSE 0 END as UnPaidAmount,
h.PaymentRef
FROM dbo.Job_PaymentHeader AS h LEFT JOIN dbo.Mas_Vender AS v ON h.VenCode = v.VenCode
WHERE NOT (ISNULL(h.CancelProve,'''')<>'''') {0} ORDER BY v.TName')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'MAIN_CLITERIA', N'AND,ph.DocDate,jd.CustCode,jd.JNo,jd.CSCode,ph.VenCode,jd.JobStatus,ph.BranchCode,')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APBILL', N'MAIN_SQL', N'SELECT ph.DocNo,ph.DocDate, ph.VenCode, ph.RefNo, pd.ForJNo, pd.SDescription, ph.PaymentRef, pd.Total as TotalNet,pd.BookingRefNo, pd.ClrRefNo, cd.LinkBillNo, jd.CustCode, jd.DeclareNumber, jd.CSCode
FROM dbo.Job_PaymentHeader AS ph INNER JOIN dbo.Job_PaymentDetail AS pd ON ph.BranchCode = pd.BranchCode AND ph.DocNo = pd.DocNo LEFT JOIN dbo.Job_LoadInfoDetail AS ld ON pd.BookingItemNo = ld.ItemNo AND pd.BookingRefNo = ld.BookingNo AND pd.BranchCode = ld.BranchCode LEFT OUTER JOIN dbo.Job_Order AS jd ON pd.ForJNo = jd.JNo AND pd.BranchCode = jd.BranchCode LEFT OUTER JOIN dbo.Job_ClearDetail AS cd ON pd.ClrItemNo = cd.ItemNo AND pd.ClrRefNo = cd.ClrNo AND pd.BranchCode = cd.BranchCode WHERE (ISNULL(ph.CancelProve, '''') = '''') {0} ORDER BY ph.VenCode,ph.RefNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLEXPORT', N'MAIN_SQL', N'select 
j.DocDate,j.JNo,j.CustRefNO,ct.CTYName,j.TRemark,
ctn.[4W],ctn.[6W],ctn.[20F],ctn.[40S],ctn.[40H],ctn.[45F],ctn.TotalCont,
j.InvProductQty,j.InvProductUnit,l.FactoryDate,l.FactoryTime,j.LoadDate,l.Remark,j.TotalGW,l.VenderCode,j.AgentCode,
j.BookingNo,l.CYPlace,l.FactoryPlace,l.PackingPlace,l.ReturnPlace,l.CYDate,l.CYTime,j.ETDDate,j.VesselName,j.MAWB,
j.InvNo,j.DeclareNumber,j.InvProduct,j.TyClearTaxReson,j.ShippingCmd,
cl.[CLEARANCE],cl.[NEXT PAGES],cl.[FORM],cl.[FUMIGATE],cl.[TRANSPORTATION],cl.[EXTRA],cl.[THC],cl.[BL/LABOUR],cl.[R-OTHERS],cl.[R-TTL BEFORE VAT],cl.[R-VAT],cl.[R-TOTAL],
cl.[CUSTOMS FEE],cl.[CUSTOMS OT],cl.[FORM FEE],cl.[CHAMBER FEE],cl.[FTI CHG],cl.[GATE CHG],cl.[LIFT OFF],cl.[B/L],cl.[DEM/DET],cl.[B-OTHERS],cl.[REIM TTL],cl.[TOTAL AMOUNT],
cl.[APLL-INVOICE],cl.[APLL-BILLING],cl.[INVOICE DATE],
cl.[THC FEE],cl.[B/L FEE],cl.[SURRENDER],cl.[FREIGHT],cl.[BUNKER],cl.[SEAL],cl.[HANDLING FEE],cl.[OTHERS],cl.[B-BASE VAT],cl.[B-VAT],cl.[B-ADV TTL]
from Job_Order j left join [jobmaster].[dbo].[Mas_CountryFT] ct
on j.InvCountry=ct.CTYCODE
left join Job_LoadInfo l on j.BranchCode=l.BranchCode AND j.JNo=l.JNo and j.BookingNo=l.BookingNo
left join 
(SELECT BranchCode,JNo,BookingNo,
SUM(CASE WHEN CTN_SIZE=''4W'' THEN 1 ELSE 0 END) as ''4W'',
SUM(CASE WHEN CTN_SIZE=''6W'' THEN 1 ELSE 0 END) as ''6W'',
SUM(CASE WHEN CTN_SIZE=''D20'' THEN 1 ELSE 0 END) as ''20F'',
SUM(CASE WHEN CTN_SIZE=''D40'' THEN 1 ELSE 0 END) as ''40S'',
SUM(CASE WHEN CTN_SIZE=''D40''''H'' THEN 1 ELSE 0 END) as ''40H'',
SUM(CASE WHEN CTN_SIZE=''D45'' THEN 1 ELSE 0 END) as ''45F'',
COUNT(*) as ''TotalCont''
FROM Job_LoadInfoDetail
WHERE CauseCode<>''99''
GROUP BY BranchCode,JNo,BookingNo
) ctn on l.BranchCode=ctn.BranchCode AND l.BookingNo=ctn.BookingNo AND l.JNo=ctn.JNo
left join 
(
select d.BranchCode,d.JobNo as JNo,
SUM(CASE WHEN d.SICode in(''R-SVC-001'',''R-SVC-002'') THEN d.UsedAmount ELSE 0 END) as ''CLEARANCE'',
SUM(CASE WHEN d.SICode in(''R-SVC-004'') THEN d.UsedAmount ELSE 0 END) as ''NEXT PAGES'',
SUM(CASE WHEN d.SICode in(''R-SVD-001'',''R-SVD-002'',''R-SVD-003'') THEN d.UsedAmount ELSE 0 END) as ''FORM'',
SUM(CASE WHEN d.SICode in(''R-SVG-004'') THEN d.UsedAmount ELSE 0 END) as ''FUMIGATE'',
SUM(CASE WHEN d.SICode NOT in(''R-SVT-007'',''R-SNT-007'') AND SICode Like ''R-S_T%'' THEN d.UsedAmount ELSE 0 END) as ''TRANSPORTATION'',
SUM(CASE WHEN d.SICode in(''R-SVG-003'') THEN d.UsedAmount ELSE 0 END) as ''EXTRA'',
SUM(CASE WHEN d.SICode in(''R-SVG-005'') THEN d.UsedAmount ELSE 0 END) as ''THC'',
SUM(CASE WHEN d.SICode in(''R-SVG-006'') THEN d.UsedAmount ELSE 0 END) as ''BL/LABOUR'',
SUM(CASE WHEN d.SICode NOT in(''R-SVG-006'',''R-SVG-005'',''R-SVG-004'',''R-SVG-003'',
''R-SVC-004'',''R-SVD-001'',''R-SVD-002'',''R-SVD-003'',''R-SVC-002'',''R-SVC-001'') AND SICode NOT Like ''R-S_T%'' AND SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-OTHERS'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount ELSE 0 END) as ''R-TTL BEFORE VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.ChargeVAT ELSE 0 END) as ''R-VAT'',
SUM(CASE WHEN d.SICode Like ''R-S%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''R-TOTAL'',
SUM(CASE WHEN d.SICode in(''B-ADV-019'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-020'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CUSTOMS OT'',
SUM(CASE WHEN d.SICode in(''B-ADV-022'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''FORM FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-014'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''CHAMBER FEE'',
SUM(CASE WHEN d.SICode in(''B-ADV-033'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''FTI CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-035'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''GATE CHG'',
SUM(CASE WHEN d.SICode in(''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''LIFT OFF'',
SUM(CASE WHEN d.SICode in(''B-ADV-006'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B/L'',
SUM(CASE WHEN d.SICode in(''B-ADV-023'',''B-ADV-024'') THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''DEM/DET'',
SUM(CASE WHEN d.SICode  NOT in(''B-ADV-006'',''B-ADV-024'',
''B-ADV-023'',''B-ADV-015'',''B-ADV-039'',''B-ADV-040'',''B-ADV-041'',''B-ADV-035'',''B-ADV-033'',''B-ADV-022'',''B-ADV-014'',''B-ADV-020'',''B-ADV-019'') AND SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-OTHERS'',
SUM(CASE WHEN d.SICode like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''REIM TTL'',
SUM(CASE WHEN d.SICode NOT like ''E-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''TOTAL AMOUNT'',
MAX(CASE WHEN d.SICode NOT like ''E-%'' AND d.LinkBillNo like ''BKK%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-INVOICE'',
MAX(CASE WHEN d.SICode NOT like ''E-%'' AND d.LinkBillNo like ''RGM%'' THEN d.LinkBillNo ELSE '''' END) as ''APLL-BILLING'',
MAX(i.DocDate) as ''INVOICE DATE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-055'') THEN d.UsedAmount ELSE 0 END) as ''THC FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-005'',''B-ADV-006'',''B-ADV-007'') THEN d.UsedAmount ELSE 0 END) as ''B/L FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-054'') THEN d.UsedAmount ELSE 0 END) as ''SURRENDER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-043'') THEN d.UsedAmount ELSE 0 END) as ''FREIGHT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-009'') THEN d.UsedAmount ELSE 0 END) as ''BUNKER'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-049'') THEN d.UsedAmount ELSE 0 END) as ''SEAL'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode in(''B-ADV-058'') THEN d.UsedAmount ELSE 0 END) as ''HANDLING FEE'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode not in(''B-ADV-058'',''B-ADV-049''
,''B-ADV-009'',''B-ADV-043'',''B-ADV-054'',''B-ADV-005'',''B-ADV-006'',''B-ADV-007'',''B-ADV-055'') AND SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''OTHERS'',

SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount ELSE 0 END) as ''B-BASE VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.ChargeVAT ELSE 0 END) as ''B-VAT'',
SUM(CASE WHEN d.LinkItem>0 AND d.SICode Like ''B-%'' THEN d.UsedAmount+d.ChargeVAT ELSE 0 END) as ''B-ADV TTL''
FROM Job_ClearDetail d INNER JOIN Job_ClearHeader h
ON d.BranchCode=h.BranchCode AND d.ClrNo=h.ClrNo
LEFT JOIN Job_InvoiceHeader i 
ON d.BranchCode=i.BranchCode
AND d.LinkBillNo=i.DocNo
WHERE h.DocStatus<>99 AND ISNULL(i.CancelProve,'''')=''''
GROUP BY d.BranchCode,d.JobNo
) cl ON j.BranchCode=cl.BranchCode AND j.JNo=cl.JNo
where j.JobType<>1 AND j.JobStatus<>99 {0}')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_APLIMPORT', N'MAIN_CLITERIA', N'AND,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus, j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_VATSALES', N'MAIN_SQL', N'SELECT ReceiptDate,ReceiptNo,ServiceType,TaxNumber,Branch,TotalChargeVAT,TotalVAT,TotalChargeNonVAT,CancelReson FROM (
SELECT h.ReceiptDate,h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
d.TotalVATCharge as TotalChargeVAT,
d.TotalVAT,
d.TotalNonVAT as TotalChargeNonVAT,
d.TotalCharge+d.TotalVAT as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h inner join (
	SELECT a.BranchCode,a.ReceiptNo,
	SUM(CASE WHEN b.AmtCharge>0 THEN a.Amt ELSE 0 END) as TotalCharge,
	SUM(CASE WHEN b.AmtCharge>0 AND a.AmtVAT>0 THEN a.Amt ELSE 0 END) as TotalVATCharge,
	SUM(CASE WHEN b.AmtCharge>0 AND a.AmtVAT=0 THEN a.Amt ELSE 0 END) as TotalNonVAT,
	SUM(CASE WHEN b.AmtCharge>0 AND a.AmtVAT=0 THEN a.AmtVAT ELSE 0 END) as TotalVAT
	FROM Job_ReceiptDetail a INNER JOIN Job_InvoiceDetail b ON a.BranchCode=b.BranchCode 
	AND a.InvoiceNo=b.DocNo AND a.InvoiceItemNo=b.ItemNo     
	GROUP BY a.BranchCode,a.ReceiptNo
) d ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE NOT ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.DocDate,h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
(CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
CASE WHEN d.VATAmt <>0 THEN d.DiffAmt ELSE 0 END as TotalChargeVAT,
d.VATAmt,
CASE WHEN d.VATAmt =0 THEN d.DiffAmt ELSE 0 END as TotalChargeNonVAT,
d.DiffAmt+d.VATAmt as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE  NOT h.DocStatus<>99
UNION
SELECT h.CancelDate,''*''+h.ReceiptNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN h.TotalVAT>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END) + c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVat,
0 as TotalChargeNonVAT,
0 as TotalDoc,h.CancelReson
FROM Job_ReceiptHeader h INNER JOIN Mas_Company c
ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE  SUBSTRING(h.ReceiptType,1,1)=''T'' AND ISNULL(h.CancelProve,'''')<>''''
UNION
SELECT h.CancelDate,''*''+h.DocNo,c.CustCode,c.TaxNumber,c.Branch,
''**ยกเลิก**''+ (CASE WHEN d.DiffAmt>0 THEN ''เพิ่มหนี้'' ELSE ''ลดหนี้'' END)+(CASE WHEN d.VATAmt <>0 THEN ''ค่าบริการของบริษัท'' ELSE ''ค่าขนส่งของบริษัท'' END)+c.NameThai as ServiceType,
0 as TotalChargeVAT,
0 as TotalVAT,
0 as TotalNonVAT,
0 as TotalDoc,h.CancelReason
FROM Job_CNDNHeader h INNER JOIN Job_CNDNDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
INNER JOIN Mas_Company c ON h.CustCode=c.CustCode AND h.CustBranch=c.Branch
WHERE h.DocStatus<>99
) AS t {0} ORDER BY ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTAXCLR', N'MAIN_CLITERIA', N'AND,cd.Date50Tavi,c.CustCode,cd.JobNo,ch.EmpCode,cd.VenderCode,,ch.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCS', N'MAIN_SQL', N'SELECT j.JNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CSCode,j.InvNo,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type]
{0} ) j  ORDER BY j.CSCode DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'MAIN_CLITERIA', N'WHERE,j.DocDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBCUST', N'MAIN_SQL', N'SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (
select j.*,c2.JobStatusName,c1.JobTypeName,c3.ShipByName,
u1.ManagerName,u2.CSName,u3.ShippingName,
c4.ConsigneeName,v1.AgentName,v2.ForwarderName,
m1.Description as DeclareTypeName
from (
  select j.*,
  c.NameThai as CustTName,c.NameEng as CustEName
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c1
on j.JobType=c1.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c2
on j.JobStatus=c2.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c3
on j.ShipBy=c3.JobTypeKey
left join (select UserID,TName as ManagerName from Mas_User ) u1 on j.ManagerCode=u1.UserID
left join (select UserID,TName as CSName from Mas_User ) u2 on j.CSCode=u2.UserID
left join (select UserID,TName as ShippingName from Mas_User ) u3 on j.ShippingEmp=u3.UserID
left join (select CustCode,Max(NameThai) as ConsigneeName from Mas_Company group by CustCode) c4 on j.consigneecode=c4.CustCode
left join (select VenCode,TName as AgentName from Mas_Vender) v1 on j.AgentCode=v1.VenCode
left join (select VenCode,TName as ForwarderName from Mas_Vender) v2 on j.ForwarderCode=v2.VenCode
left join (select [Type],Description from jobmaster.dbo.Mas_RFDCT) m1 on j.DeclareType=m1.[Type] {0}
) j  ORDER BY j.CustCode,j.DutyDate DESC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_JOBDAILY', N'MAIN_CLITERIA', N'WHERE,j.DutyDate,j.CustCode,j.JNo,j.CSCode,j.AgentCode,j.JobStatus,j.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHBAL', N'MAIN_SQL', N'SELECT BookCode,acType,PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN (CashAmount+ChqAmount)*-1 ELSE (CashAmount+ChqAmount) END) as TotalNet,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) AND d.PRType<>'''' {0}
) as t ORDER BY BookCode,acType,VoucherDate,PRVoucher')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'MAIN_CLITERIA', N'AND,h.VoucherDate,h.CustCode,d.ForJNo,h.RecUser,,,h.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CASHFLOW', N'MAIN_SQL', N'SELECT BookCode,PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType=''P'' THEN (CashAmount+ChqAmount+CreditAmount) ELSE 0 END) as PaidAmount,
(CASE WHEN PRType=''P'' THEN 0 ELSE (CashAmount+ChqAmount+CreditAmount) END) as TotalReceived,ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE d.PRType<>'''' AND ISNULL(h.CancelProve,'''')='''' {0}
) as t ORDER BY VoucherDate,PRVoucher')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQCUSTPAY', N'MAIN_CLITERIA', N'AND,b.VoucherDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RCPSUMMARY', N'MAIN_SQL', N'SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,
SUM(CASE WHEN rc.AmtAdvance>0 THEN rc.Amt+rc.AmtVAT ELSE 0 END) as TotalAdvance
,SUM(CASE WHEN rc.AmtCharge>0 THEN rc.Amt+rc.AmtVAT ELSE 0 END) as TotalCharge
,SUM(rc.Amt50Tavi) as Amt50Tavi,
SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'''')='''' THEN 0 ELSE rc.Net END) as TotalReceived
FROM (
SELECT rh.*,c1.UsedLanguage,
c1.Title + '' ''+ c1.NameThai as CustTName,c1.NameEng as CustEName,c1.TAddress1+'' ''+c1.TAddress2 as CustTAddr,c1.EAddress1+'' ''+c1.EAddress2 as CustEAddr,c1.Phone as CustPhone,c1.TaxNumber as CustTaxID,
c2.Title + '' ''+ c2.NameThai as BillTName,c2.NameEng as BillEName,c2.TAddress1+'' ''+c2.TAddress2 as BillTAddr,c2.EAddress1+'' ''+c2.EAddress2 as BillEAddr,c2.Phone as BillPhone,c2.TaxNumber as BillTaxID,
rd.ItemNo,rd.InvoiceNo,rd.InvoiceItemNo,ih.DocDate as InvoiceDate,ih.BillAcceptNo,ih.BillIssueDate,ih.BillAcceptDate,ih.RefNo,
id.ExpSlipNO,id.AmtCharge,id.AmtAdvance,id.Amt-id.AmtDiscount as InvAmt,id.AmtVat as InvVAT,id.Amt50Tavi as Inv50Tavi,id.TotalAmt as InvTotal,
(SELECT STUFF((
    SELECT DISTINCT '','' + JobNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as JobNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + ClrNo
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as ClrNo,
(SELECT STUFF((
    SELECT DISTINCT '','' + AdvNO
    FROM Job_ClearDetail WHERE BranchCode=id.BranchCode
    AND LinkBillNo=id.DocNo AND LinkItem=id.ItemNo
FOR XML PATH(''''),type).value(''.'',''nvarchar(max)''),1,1,''''
)) as AdvNo,
rd.SICode,rd.SDescription,rd.Amt,rd.FAmt,rd.AmtVAT,rd.FAmtVAT,rd.Amt50Tavi,rd.FAmt50Tavi,rd.Net,rd.FNet,
rd.DCurrencyCode,rd.DExchangeRate,rd.ControlNo,rd.ControlItemNo,vd.ChqNo,vd.ChqDate,vd.PRVoucher
FROM Job_ReceiptHeader rh INNER JOIN Job_ReceiptDetail rd ON rh.BranchCode=rd.BranchCode AND rh.ReceiptNo=rd.ReceiptNo
AND NOT ISNULL(rh.CancelProve,'''')<>''''
INNER JOIN Job_InvoiceDetail id ON rd.BranchCode=id.BranchCode AND rd.InvoiceNo=id.DocNo AND rd.InvoiceItemNo=id.ItemNo
LEFT JOIN Mas_Company c1 ON rh.CustCode=c1.CustCode AND rh.CustBranch=c1.Branch
LEFT JOIN Mas_Company c2 ON rh.BillToCustCode=c2.CustCode AND rh.BillToCustBranch=c2.Branch
INNER JOIN Job_InvoiceHeader ih ON rd.BranchCode=ih.BranchCode AND rd.InvoiceNo=ih.DocNo 
AND NOT ISNULL(ih.CancelProve,'''')<>''''
LEFT JOIN Job_CashControlDoc vc 
ON rd.BranchCode=vc.BranchCode AND rd.ControlNo=vc.ControlNo AND rd.ControlItemNo=vc.ItemNo
LEFT JOIN Job_CashControlSub vd
ON vc.BranchCode=vd.BranchCode AND vc.ControlNo=vd.ControlNo AND vc.acType=vd.acType
 WHERE SUBSTRING(rh.ReceiptType,1,1)<>''T'' {0}) rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptDate,rc.ReceiptNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_RVDAILY', N'MAIN_CLITERIA', N'WHERE,VoucherDate,CustCode,,RecUser,,,BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQISSUE', N'MAIN_SQL', N'SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,DocUsed,AmountUsed,ControlNo,TRemark FROM (
SELECT a.*,ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0) AS AmountUsed,a.ChqAmount-(ISNULL(c.ChqUsed,0)+ISNULL(d.UsedAmount,0)) as AmountRemain,
b.CustCode,b.CustBranch,b.VoucherDate,d.DocUsed,b.TRemark 
FROM 
(   
    SELECT BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType,
    SUM(ChqAmount) as ChqAmount
    FROM Job_CashControlSub
    GROUP BY BranchCode,ControlNo,ChqNo,ChqStatus,ChqDate,PayChqTo,BankCode,BankBranch,acType,PRType
) a INNER JOIN Job_CashControl b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN (
    SELECT h.BranchCode,h.ChqNo,SUM(h.ChqAmount) as ChqUsed,
    h.BankCode,h.BankBranch
    FROM Job_CashControlSub h LEFT JOIN Job_CashControlDoc d
    ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo
    WHERE h.PRType=''R'' AND NOT EXISTS(
select ControlNo from Job_CashControl
where BranchCode=h.BranchCode AND ControlNo=h.ControlNo AND ISNULL(CancelProve,'''')<>''''
    ) AND d.ControlNo IS NULL
    GROUP BY h.BranchCode,h.ChqNo
    ,h.BankCode,h.BankBranch
) c
ON a.BranchCode=c.BranchCode
AND a.ChqNo=c.ChqNo AND a.BankCode=c.BankCode AND a.BankBranch=c.BankBranch 
left join (
	SELECT h.BranchCode,h.ChqNo
,h.BankCode,h.BankBranch
    ,SUM(d.PaidAmount) as UsedAmount,Max(d.DocNo) as DocUsed
	FROM Job_CashControlDoc d INNER JOIN Job_CashControlSub h 
    ON d.BranchCode=h.BranchCode AND d.ControlNo=h.ControlNo
	WHERE NOT EXISTS(
		select ControlNo from Job_CashControl
		where BranchCode=d.BranchCode 
		AND ControlNo=d.ControlNo 
		AND ISNULL(CancelProve,'''')<>''''
    )
	GROUP BY h.BranchCode,h.ChqNo,h.BankCode,h.BankBranch
) d
on a.BranchCode=d.BranchCode
    AND a.ChqNo=d.ChqNo AND a.BankCode=d.BankCode AND a.BankBranch=d.BankBranch 
WHERE a.acType=''CH'' {0}
AND a.PRType=''P'' AND a.ChqAmount>0 AND ISNULL(a.ChqNo,'''')<>'''' 
) t ORDER BY CustCode,ChqDate,ChqNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CHQRECEIVE', N'MAIN_CLITERIA', N'AND,a.ChqDate,b.CustCode,,b.RecUser,,a.ChqStatus,a.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDAILY', N'MAIN_SQL', N'SELECT cl.ClrNo,cl.ClrDate,cl.SDescription,cl.AdvNO,cl.JobNo,cl.AdvNet as TotalAdvance,cl.ClrNet as TotalExpClear,cl.Tax50Tavi as TotalWHT,cl.SlipNo,cl.LinkBillNo as InvoiceNo FROM (select 
h.BranchCode,h.ClrNo,h.ClrDate,h.DocStatus,c1.ClrStatusName,
h.ClearanceDate,h.JobType,c4.JobTypeName,j.ShipBy,c6.ShipByName,
b.BrName as BranchName,h.CTN_NO,h.CoPersonCode,h.TRemark,h.ClearType,c2.ClrTypeName,h.ClearFrom,c3.ClrFromName,
h.EmpCode,u1.TName as ClrByName,h.ApproveBy,u2.TName as ApproveByName,
h.ApproveDate,h.ReceiveBy,u3.TName as ReceiveByName, h.ReceiveDate,h.ReceiveRef,
h.AdvTotal,h.ClearTotal,h.TotalExpense,h.ClearVat,h.ClearWht,h.ClearNet,h.ClearBill,h.ClearCost,
d.ItemNo,d.AdvNO,d.AdvItemNo,a.IsDuplicate,d.AdvAmount,
a.AdvNet,a.PaymentDate,a.AdvDate,a.DocStatus as AdvStatus,
d.SICode,d.SDescription,d.SlipNO,d.JobNo,d.VenderCode,v.TName as VenderName,
d.UsedAmount,d.Tax50Tavi,d.ChargeVAT,d.BNet as ClrNet,
d.FPrice,d.BPrice,d.FCost,d.BCost,
d.UnitPrice,d.Qty,d.CurrencyCode,d.CurRate,d.UnitCost,d.FNet,d.BNet,d.Tax50TaviRate,d.VATRate,
d.LinkItem,d.LinkBillNo,s.IsExpense,s.IsCredit,s.IsTaxCharge,s.Is50Tavi,s.IsHaveSlip,s.IsLtdAdv50Tavi,
d.Remark,j.CustCode,j.CustBranch,j.InvNo,j.NameEng,j.NameThai,j.TotalContainer,j.VesselName,j.Commission,j.consigneecode,j.DeliveryTo,
j.JobDate,j.JobStatus,c5.JobStatusName,j.CloseJobDate,j.CloseJobBy,j.DeclareNumber,j.InvProduct,j.TotalGW,j.InvProductQty,
h.CancelProve,h.CancelReson,h.CancelDate,r.LastReceipt,r.ReceiveNet 
from Job_ClearHeader h inner join Job_ClearDetail d on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
left join Mas_Branch b on h.BranchCode=b.Code 
left join (
  select ah.BranchCode,ah.AdvNo,ad.ItemNo,ah.PaymentDate,ah.EmpCode,ad.AdvAmount,ad.ChargeVAT,
  ad.IsDuplicate,ad.AdvNet,ah.AdvDate,ah.DocStatus
  from Job_AdvHeader ah inner join Job_AdvDetail ad
  on ah.BranchCode=ad.BranchCode and ah.AdvNo=ad.AdvNo
) a 
on d.BranchCode=a.BranchCode and d.AdvNO=a.AdvNo and d.AdvItemNo=a.ItemNo
left join (
  select j.*,j.DocDate as JobDate,c.NameThai,c.NameEng
  from Job_Order j inner join Mas_Company c
  on j.CustCode=c.CustCode and j.CustBranch=c.Branch
) j
on d.BranchCode=j.BranchCode and d.JobNo=j.JNo
left join 
(SELECT ConfigKey as ClrStatusKey,ConfigValue as ClrStatusName FROM Mas_Config WHERE ConfigCode=''CLR_STATUS'') c1
on h.DocStatus=c1.ClrStatusKey
left join 
(SELECT ConfigKey as ClrTypeKey,ConfigValue as ClrTypeName FROM Mas_Config WHERE ConfigCode=''CLR_TYPE'') c2
on h.ClearType=c2.ClrTypeKey
left join 
(SELECT ConfigKey as ClrFromKey,ConfigValue as ClrFromName FROM Mas_Config WHERE ConfigCode=''CLR_FROM'') c3
on h.ClearFrom=c3.ClrFromKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode=''JOB_TYPE'') c4
on h.JobType=c4.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as JobStatusName FROM Mas_Config WHERE ConfigCode=''JOB_STATUS'') c5
on j.JobStatus=c5.JobTypeKey
left join 
(SELECT ConfigKey as JobTypeKey,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode=''SHIP_BY'') c6
on j.ShipBy=c6.JobTypeKey
left join Mas_User u1 on h.EmpCode=u1.UserID
left join Mas_User u2 on h.ApproveBy=u2.UserID
left join Mas_User u3 on h.ReceiveBy=u3.UserID 
left join Job_SrvSingle s on d.SICode=s.SICode
left join Mas_Vender v on d.VenderCode=v.VenCode
left join (
    SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,MAX(d.ReceiptNo) as LastReceipt,
    SUM(d.Net) as ReceiveNet
    FROM Job_ReceiptHeader h INNER JOIN Job_ReceiptDetail d
    ON h.BranchCode=d.BranchCode AND h.ReceiptNo=d.ReceiptNo
    WHERE NOT ISNULL(h.CancelProve,'''')<>''''
    GROUP BY d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
) r on d.BranchCode=r.BranchCode and d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
 WHERE h.DocStatus<>99 {0} ) cl ORDER BY cl.ClrDate,cl.ClrNo')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_CLRDETAIL', N'MAIN_CLITERIA', N'AND,b.ClrDate,c.CustCode,c.JNo,c.EmpCode,a.VenderCode,b.ClrStatus,b.BranchCode,a.SICode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_STATEMENT', N'MAIN_SQL', N'SELECT BookCode,VoucherDate,TRemark,PRVoucher,ChqNo,ChqDate,
(CASE WHEN PRType=''P'' THEN CashAmount*-1 ELSE CashAmount END) as CashAmount,
(CASE WHEN PRType=''P'' THEN ChqAmount*-1 ELSE ChqAmount END) as ChqAmount,
(CASE WHEN PRType=''P'' THEN CreditAmount*-1 ELSE CreditAmount END) as ''Adjust Amount'',
(CASE WHEN PRType=''P'' THEN (CashAmount+ChqAmount+CreditAmount)*-1 ELSE (CashAmount+ChqAmount+CreditAmount) END) as TotalNet,
ControlNo FROM (
SELECT h.BranchCode, h.ControlNo, h.VoucherDate, h.TRemark, h.RecUser, h.RecDate, h.RecTime, h.PostedBy, h.PostedDate, h.PostedTime, 
    h.CancelReson, h.CancelProve, h.CancelDate, h.CancelTime, h.CustCode, h.CustBranch, d.ItemNo, d.PRVoucher, d.PRType, d.ChqNo, d.BookCode, d.BankCode, 
    d.BankBranch, d.ChqDate, d.CashAmount, d.ChqAmount, d.CreditAmount, d.IsLocal, d.ChqStatus, d.PayChqTo, d.SICode, d.RecvBank, d.RecvBranch, d.acType, 
    d.SumAmount, d.CurrencyCode, d.ExchangeRate, d.TotalAmount, d.VatInc, d.VatExc, d.WhtInc, d.WhtExc, d.TotalNet, d.ForJNo
FROM     dbo.Job_CashControl AS h INNER JOIN
    dbo.Job_CashControlSub AS d ON h.BranchCode = d.BranchCode AND h.ControlNo = d.ControlNo
WHERE (NOT (ISNULL(h.CancelProve, '''') <> '''')) AND d.PRType<>'''' {0}
) as t ORDER BY BookCode,VoucherDate,PRVoucher')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_TAXDAILY', N'MAIN_CLITERIA', N'AND,rh.ReceiptDate,rh.CustCode,ih.RefNo,rh.EmpCode,,,rh.BranchCode')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'REPORT_WHTDAILY', N'MAIN_SQL', N'SELECT a.DocDate,a.DocNo,a.TName1 as TaxBy,a.TName3 as TaxFor,a.FormTypeName,a.TaxLawName,a.PayTaxDesc,a.PayRate,a.PayAmount as Amount,a.PayTax FROM (
SELECT h.*,d.ItemNo,d.IncType,d.PayDate,d.PayAmount,d.PayTax,d.PayTaxDesc,
d.JNo,d.DocRefType,d.DocRefNo,d.PayRate,
j.InvNo,j.CustCode,j.CustBranch,u.TName as UpdateName,
(CASE WHEN h.FormType=1 THEN ''ภงด1ก'' ELSE (CASE WHEN h.FormType=2 THEN ''ภงด1ก(พิเศษ)'' ELSE (CASE WHEN h.FormType=3 THEN ''ภงด2'' ELSE (CASE WHEN h.FormType=4 THEN ''ภงด3'' ELSE (CASE WHEN h.FormType=5 THEN ''ภงด2ก'' ELSE (CASE WHEN h.FormType=6 THEN ''ภงด3ก'' ELSE (CASE WHEN h.FormType=7 THEN ''ภงด53'' ELSE ''ไม่ระบุ'' END) END) END) END) END) END) END) as FormTypeName,
(CASE WHEN h.TaxLawNo=1 THEN ''3เตรส'' ELSE (CASE WHEN h.TaxLawNo=2 THEN ''65จัตวา'' ELSE (CASE WHEN h.TaxLawNo=3 THEN ''69ทวิ'' ELSE (CASE WHEN h.TaxLawNo=4 THEN ''48ทวิ'' ELSE (CASE WHEN h.TaxLawNo=5 THEN ''50ทวิ'' ELSE ''ไม่ระบุ'' END) END) END) END) END) as TaxLawName
FROM dbo.Job_WHTax h LEFT JOIN dbo.Job_WHTaxDetail d
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo
LEFT JOIN dbo.Job_Order j ON d.BranchCode=j.BranchCode
AND d.JNo=j.JNo 
LEFT JOIN dbo.Mas_User u ON h.UpdateBy=u.UserID
WHERE NOT ISNULL(h.CancelProve,'''')<>'''' 
{0}
) a order by a.DocDate,a.DocNo')
GO
