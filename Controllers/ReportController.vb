Imports System.Web.Http
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class ReportController
        Inherits CController

        ' GET: Report
        Function Index() As ActionResult
            ViewBag.ReportName = "Reports"
            Return GetView("Index", "MODULE_REP")
        End Function
        Function Import() As ActionResult
            Return GetView("Import", "MODULE_REP")
        End Function
        Function ImportFile() As ActionResult
            Return GetView("ImportFile")
        End Function
        Function Export() As ActionResult
            Return GetView("Export", "MODULE_REP")
        End Function
        Function Preview() As ActionResult
            Return GetView("Preview")
        End Function
        Function GetReport(<FromBody()> data As CReport) As ActionResult
            Dim sqlM As String = ""
            Dim sqlW As String = ""
            Dim fldGroup = ""
            Dim groupDatas = ""
            Dim cliteria As String = data.ReportCliteria
            Try
                Select Case data.ReportCode
                    Case "JOBDAILY"
                        fldGroup = "LoadDate"
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.LoadDate,j.DutyDate,j.ShippingEmp,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j ORDER BY j.LoadDate DESC"
                    Case "JOBCS"
                        fldGroup = "CSCode"
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CSCode,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.CSCode DESC"
                    Case "JOBSHP"
                        fldGroup = "ShippingEmp"
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.LoadDate,j.DutyDate,j.ShippingEmp,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ShippingEmp DESC"
                    Case "JOBTYPE"
                        fldGroup = "JobTypeName"
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.ShippingEmp", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.DeclareTypeName FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.JobType,j.CustCode,j.ShipBy,j.DocDate DESC"
                    Case "JOBSHIPBY"
                        fldGroup = "ShipByName"
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.ShippingEmp", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.DeclareTypeName FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ShipBy,j.CustCode,j.JobType,j.DocDate DESC"
                    Case "JOBCUST"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.CustCode,j.DutyDate DESC"
                    Case "JOBPORT"
                        fldGroup = "ClearPort"
                        groupDatas = JsonConvert.SerializeObject(New CCustomsPort(GetSession("ConnMas")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.LoadDate,j.CustCode,j.DeclareNumber,j.DeliveryTo,j.InvProductQty,j.InvProductUnit,j.ClearPort,j.TotalContainer,j.TotalGW,j.ETDDate,j.ETADate,j.ShippingEmp FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ClearPort,j.LoadDate DESC,j.CustCode,j.InvNo"
                    Case "JOBADV"
                        fldGroup = "ReqBy"
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "c.PaymentDate", "c.CustCode", "a.ForJNo", "c.ReqBy", "a.VenCode", "c.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT t.PaymentDate,t.AdvNo,t.JobNo,t.ReqBy,t.SDescription,t.VenderCode,t.AdvNet,t.UsedAmount,t.AdvBalance FROM (" & SQLSelectAdvForClear() & sqlW & ") t ORDER BY t.ReqBy,t.PaymentDate,t.AdvNo"
                    Case "JOBVOLUME"
                        fldGroup = "NameThai"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.*,c.NameThai FROM (" & SQLSelectJobCount(sqlW, "j.CustCode") & ") j INNER JOIN Mas_Company c ON j.CustCode=c.CustCode ORDER BY c.NameThai"
                    Case "JOBSTATUS"
                        fldGroup = "TName"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.ManagerCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.*,c.TName FROM (" & SQLSelectJobCount(sqlW, "j.CSCode") & ") j INNER JOIN Mas_User c ON j.CSCode=c.UserID ORDER BY c.TName"
                    Case "JOBSALES"
                        fldGroup = "TName"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.ManagerCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.*,c.TName FROM (" & SQLSelectJobCount(sqlW, "j.ManagerCode") & ") j INNER JOIN Mas_User c ON j.ManagerCode=c.UserID ORDER BY c.TName"
                    Case "JOBCOMM"
                        sqlW = GetSQLCommand(cliteria, "dbo.Job_ReceiptHeader.ReceiptDate", "dbo.Job_Order.CustCode", "dbo.Job_Order.JNo", "dbo.Job_Order.ManagerCode", "dbo.Job_Order.AgentCode", "dbo.Job_Order.JobStatus", "dbo.Job_Order.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.ManagerCode,j.CustCode,j.CSCode,j.ReceiptNo,j.SumReceipt,j.TotalComm FROM (" & SQLSelectSumReceipt(sqlW) & ") j ORDER BY j.JNo,j.ReceiptNo"
                    Case "ADVDAILY"
                        sqlW = GetSQLCommand(cliteria, "a.PaymentDate", "a.CustCode", "d.ForJNo", "a.ReqBy", "d.VenCode", "a.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT ad.AdvNo,ad.PaymentDate,ad.EmpCode as ReqBy,ad.SDescription,ad.ForJNo,ad.AdvPayAmount,ad.Charge50Tavi FROM (" & SQLSelectAdvDetail() & sqlW & ") ad  ORDER BY ad.PaymentDate,ad.AdvNo"
                    Case "EXPDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "", "d.ForJNo", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT pa.DocNo,pa.DocDate,pa.VenCode,pa.RefNo,pa.SDescription,pa.Total FROM (" & SQLSelectPaymentReport() & sqlW & ") pa ORDER BY pa.DocDate,pa.DocNo"
                    Case "RCPDAILY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT=0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT=0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net,rc.PRVoucher FROM (" & SQLSelectReceiptReport() & sqlW & ") rc ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "RCPSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT=0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT=0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,SUM(rc.Amt) as Amt,SUM(rc.Amt50Tavi) as Amt50Tavi,SUM(rc.Net) as AmtNet FROM (" & SQLSelectReceiptReport() & sqlW & ") rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "TAXDAILY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT>0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT>0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.Net,rc.PRVoucher FROM (" & SQLSelectReceiptReport() & sqlW & ") rc ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "TAXSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT>0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT>0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,SUM(rc.Amt) as Amt,SUM(rc.AmtVAT) as AmtVAT,SUM(rc.Amt50Tavi) as Amt50Tavi,SUM(rc.Net) as AmtNet FROM (" & SQLSelectReceiptReport() & sqlW & ") rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "CASHDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "r.CmpCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE (d.ChqAmount >0 OR d.CashAmount>0) AND " & sqlW
                        sqlM = "SELECT vc.PRVoucher,vc.VoucherDate,vc.BookCode,vc.ChqNo,vc.ChqDate,vc.RecvBank,(CASE WHEN vc.PRType='P' THEN -1 ELSE 1 END)*(vc.CashAmount+vc.ChqAmount) as Total,vc.DRefNo FROM (" & SQLSelectVoucher() & sqlW & ") vc ORDER BY vc.VoucherDate,vc.PRVoucher"
                        fldGroup = "VoucherDate"
                    Case "CLRDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.ClrDate", "j.CustCode", "j.JNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE h.DocStatus<>99 AND " & sqlW
                        sqlM = "SELECT cl.ClrNo,cl.ClrDate,cl.SDescription,cl.AdvNO,cl.JobNo,cl.AdvNet,cl.ClrNet,cl.Tax50Tavi,cl.SlipNo,cl.LinkBillNo as InvoiceNo FROM (" & SQLSelectClrDetail() & sqlW & ") cl ORDER BY cl.ClrDate,cl.ClrNo"
                    Case "CLRSTATUS"
                        sqlW = GetSQLCommand(cliteria, "h.ClrDate", "j.CustCode", "j.JNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE h.DocStatus<>99 AND " & sqlW
                        sqlM = "SELECT cl.ClrNo,cl.ClrDate,cl.JobNo,SUM(cl.UsedAmount) as UsedAmount,SUM(cl.ChargeVAT) as AmtVat,SUM(cl.Tax50Tavi) as Tax50Tavi,"
                        sqlM &= "SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=1 THEN cl.ClrNet ELSE 0 END) as SumAdvance,SUM(CASE WHEN cl.IsExpense=1 THEN cl.ClrNet ELSE 0 END) as SumCost,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=0 THEN cl.ClrNet ELSE 0 END) as SumCharge,cl.LinkBillNo as InvoiceNo FROM (" & SQLSelectClrDetail() & sqlW & ") cl "
                        sqlM &= "WHERE cl.ClrNet > 0 GROUP BY cl.ClrNo,cl.ClrDate,cl.JobNo,cl.LinkBillNo ORDER BY cl.ClrDate,cl.ClrNo"
                    Case "INVDAILY"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "ih.RefNo", "ih.EmpCode", "", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT inv.DocNo,inv.DocDate,inv.SDescription,inv.Amt,inv.AmtVat,inv.AmtCredit,inv.TotalInv,inv.CreditNet,inv.ReceivedNet,inv.ReceiptNo FROM (" & SQLSelectInvReport(sqlW) & ") inv ORDER BY inv.DocDate,inv.DocNo"
                    Case "INVSTATUS"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "ih.RefNo", "ih.EmpCode", "", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.CustCode,
sum(inv.Amt) as AmtTotal,sum(inv.AmtVat) as TotalVAT,sum(inv.Amt50Tavi) as Total50Tavi,
sum(inv.AmtCredit) as TotalPrepaid,sum(inv.TotalInv) as TotalInv,sum(ISNULL(inv.CreditNet,0)) as TotalCredit,
sum(inv.ReceivedNet) as TotalReceived 
FROM (" & SQLSelectInvReport(sqlW) & ") inv 
GROUP BY inv.DocNo,inv.DocDate,inv.RefNo,inv.CustCode
ORDER BY inv.DocNo
"
                    Case "BILLDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.BillDate", "h.CustCode", "", "h.EmpCode", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT bl.BillAcceptNo,bl.BillDate,bl.CustCode,bl.InvNo,bl.AmtAdvance,bl.AmtChargeNonVAT,bl.AmtChargeVAT,bl.AmtVAT,bl.AmtWH,bl.AmtTotal FROM (" & SQLSelectBillReport() & ") bl ORDER BY bl.BillDate,bl.BillAcceptNo"
                    Case "JOBCOST"
                        sqlW = GetSQLCommand(cliteria, "ch.ClrDate", "j.CustCode", "j.JNo", "j.CSCode", "j.ForwarderCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT CustCode,JNo,DeclareNumber,DutyDate,SumAdvance,SumCost,SumCharge,SumWhTax,Profit FROM (
SELECT j.BranchCode, j.JNo, j.CustCode, j.CustBranch, j.InvNo, j.DutyDate, j.DeclareNumber,j.CSCode,j.ManagerCode,
SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.Tax50Tavi ELSE 0 END) AS SumWhTax,
SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) AS SumCost,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumCharge,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) as Profit
FROM            dbo.Job_ClearHeader AS ch INNER JOIN
                         dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
						 AND ch.ClrNo=cd.ClrNo
                         INNER JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
						 INNER JOIN
                         dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo
WHERE        (ch.DocStatus <> 99) AND (j.JobStatus < 99) {0}
GROUP BY j.BranchCode, j.JNo, j.CustCode, j.CustBranch, j.InvNo, j.DutyDate, j.DeclareNumber,j.CSCode,j.ManagerCode
) as t ORDER BY CustCode,DutyDate,InvNo"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "BOOKBAL"
                        sqlW = GetSQLCommand(cliteria, "a.VoucherDate", "", "", "b.RecUser", "", "", "b.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT bk.BookCode,bk.LimitBalance,bk.SumCashOnhand,bk.SumChqClear,bk.SumChqOnhand,bk.SumCredit+bk.SumChqReturn as SumCreditable FROM (" & String.Format(SQLSelectBookAccBalance(), sqlW) & ") bk ORDER BY BookCode"
                    Case "VATSALES"
                        sqlW = GetSQLCommand(cliteria, "t.ReceiptDate", "t.CustCode", "", "", "", "", "")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = String.Format(SQLSelectVATSales(), sqlW)
                    Case "VATBUY"
                        sqlW = GetSQLCommand(cliteria, "t.ExpenseDate", "t.CustCode", "t.JobNo", "", "t.VenCode", "", "")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = String.Format(SQLSelectVATBuy(), sqlW)
                    Case "WHTDAILY"
                        fldGroup = "DocDate"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.FormType", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT a.DocDate,a.DocNo,a.TName1 as TaxBy,a.TName3 as TaxFor,a.FormTypeName,a.TaxLawName,a.PayTaxDesc,a.PayRate,a.PayAmount,a.PayTax FROM (" & String.Format(SQLSelectWHTax() & sqlW) & ") a order by a.DocDate,a.DocNo"
                    Case "WHTAXCLR"
                        sqlW = GetSQLCommand(cliteria, "cd.Date50Tavi", "c.CustCode", "cd.JobNo", "ch.EmpCode", "cd.VenderCode", "", "ch.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT Date50Tavi,NO50Tavi,VenTaxNumber,VenTaxBranch,VenderName,CustTaxNumber,CustName,
(CASE WHEN Tax50TaviRate =1 THEN 'ค่าขนส่ง' ELSE (CASE WHEN (Tax50TaviRate=1.5 OR Tax50TaviRate=3) THEN 'ค่าบริการ' ELSE (CASE WHEN Tax50TaviRate =5 THEN 'ค่าเช่า' ELSE (CASE WHEN Tax50TaviRate =2 THEN 'ค่าโฆษณา' ELSE (CASE WHEN Tax50TaviRate =10 THEN 'ออกให้มูลนิธิ/สมาคม' ELSE 'เงินเดือน' END) END) END) END) END) as TaxType,
(CASE WHEN CustName Like '%จำกัด%' THEN 'ภงด53' ELSE 'ภงด3' END) as TaxForm,
(CASE WHEN IsLtdAdv50Tavi=1 THEN Tax50Tavi ELSE 0 END) as Tax3Tres,
(CASE WHEN IsLtdAdv50Tavi=0 THEN Tax50Tavi ELSE 0 END) as TaxNot3Tres,
SlipNO,UsedAmount,Tax50TaviRate
FROM (" & String.Format(SQLSelectTax50TaviReport(), sqlW) & ") as t ORDER BY 9,1,2"
                        fldGroup = "TaxForm"
                    Case "WHTAXSUM"
                        fldGroup = "FormTypeName"
                        sqlW = GetSQLCommand(cliteria, "a.PayDate", "c.CustCode", "a.JNo", "a.UpdateBy", "a.TaxNumber3", "a.FormType", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = String.Format(SQLSelectWHTaxSummary(), sqlW)
                    Case "ACCEXP"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t WHERE PRType='P' ORDER BY PRVoucher"
                    Case "ACCINC"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t WHERE PRType='R' ORDER BY PRVoucher"
                    Case "CASHFLOW"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t ORDER BY PRType DESC,PRVoucher"
                        fldGroup = "PRType"
                    Case "STATEMENT"
                        fldGroup = "BookCode"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT BookCode,VoucherDate,TRemark,PRVoucher,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t WHERE BookCode<>'' ORDER BY BookCode,VoucherDate,PRVoucher "
                    Case "ARBAL"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "DocDate", "CustCode", "RefNo", "EmpCode", "", "", "BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "
SELECT CustCode,DocNo,DocDate,RefNo,
Sum(AmtAdvance) as TotalAdv,Sum(AmtCharge) as TotalCharge,Sum(AmtVAT) as TotalVat,Sum(Amt50Tavi) as Total50Tavi,
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
SUM((CASE WHEN rd.VoucherNo<>'' THEN rd.Net ELSE 0 END)) AS RecvNet,
(SELECT STUFF((
SELECT DISTINCT ',' + ReceiptNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
  )) as FromReceiptNo,
(SELECT STUFF((
SELECT DISTINCT ',' + VoucherNo
FROM Job_ReceiptDetail WHERE BranchCode=rd.BranchCode
AND InvoiceNo=rd.InvoiceNo AND InvoiceItemNo=rd.InvoiceItemNo
  FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
  )) as VoucherNo,
MAX(rh.ReceiptDate) as ReceiptDate
FROM      dbo.Job_ReceiptHeader AS rh INNER JOIN
             dbo.Job_ReceiptDetail AS rd ON rh.BranchCode = rd.BranchCode AND rh.ReceiptNo = rd.ReceiptNo
WHERE    (NOT (ISNULL(rh.CancelProve, '') <> ''))
GROUP BY rd.InvoiceNo, rd.InvoiceItemNo, rd.BranchCode) as r
ON id.BranchCode=r.BranchCode AND id.DocNo=r.InvoiceNo AND id.ItemNo=r.InvoiceItemNo
WHERE    (NOT (ISNULL(ih.CancelProve, '') <> ''))
) t {0} GROUP BY CustCode,DocNo,DocDate,RefNo
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "APBAL"
                        fldGroup = "TName"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "", "", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT h.DocNo, h.DocDate, v.TName, h.PoNo, h.RefNo, 
CASE WHEN h.PaymentRef<>'' THEN h.TotalNet ELSE 0 END as PaidAmount,
CASE WHEN NOT h.PaymentRef<>'' THEN h.TotalNet ELSE 0 END as UnPaidAmount,
h.PaymentRef
FROM dbo.Job_PaymentHeader AS h INNER JOIN dbo.Mas_Vender AS v ON h.VenCode = v.VenCode
WHERE (h.ApproveBy <> '') AND NOT (ISNULL(h.CancelProve,'')<>'') {0} ORDER BY v.TName
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CNDN"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "a.DocDate", "a.CustCode", "", "a.EmpCode", "", "", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = SQLSelectCNDNSummary() & " WHERE a.DocStatus<>99 AND ISNULL(a.ApproveBy,'')<>'' {0} "
                        sqlM = "SELECT CustCode,DocDate,DocNo,InvoiceNo,TotalAmt,TotalVAT,TotalWHT,TotalNet FROM (" & String.Format(sqlM, sqlW) & ") t ORDER BY CustCode,DocDate,DocNo "
                    Case "CREDITADV"
                        fldGroup = "EmpCode"
                        sqlW = GetSQLCommand(cliteria, "a.PaymentDate", "a.CustCode", "b.ForJNo", "a.EmpCode", "", "a.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
MAX(e.ControlNo) as ReceiveRef,SUM(e.PaidAmount) as ReceiveAmt
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'')=''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
	SELECT dt.BranchCode,dt.ControlNo,dt.DocNo,dt.PaidAmount 
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'')='' AND dt.DocType='CLR'
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+'#'+Convert(varchar,b.ItemNo))=e.DocNo
WHERE a.DocStatus>2 AND a.AdvType=5 {0}
GROUP BY
a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode
ORDER BY a.EmpCode,a.PaymentDate,a.AdvNo
"
                        sqlM = String.Format(sqlM, sqlW)
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                    Case "ADVSUMMARY"
                        fldGroup = "EmpCode"
                        sqlW = GetSQLCommand(cliteria, "a.PaymentDate", "a.CustCode", "b.ForJNo", "a.EmpCode", "", "a.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
MAX(e.ControlNo) as ReceiveRef,SUM(e.PaidAmount) as ReceiveAmt
FROM Job_AdvHeader a INNER JOIN Job_AdvDetail b 
ON a.BranchCode=b.BranchCode AND a.AdVNo=b.AdvNo
LEFT JOIN Mas_Company c
ON a.CustCode=c.CustCode AND a.CustBranch=c.Branch
LEFT JOIN (
	SELECT dt.BranchCode,dt.AdvNo,dt.AdvItemNo,SUM(dt.BNet) as ClrNet
	FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo
	WHERE ISNULL(hd.CancelProve,'')=''
	GROUP BY dt.BranchCode,dt.AdvNo,dt.AdvItemNo
) d ON b.BranchCode=d.BranchCode AND b.AdvNo=d.AdvNo AND b.ItemNo=d.AdvItemNo
left join (
	SELECT dt.BranchCode,dt.ControlNo,dt.DocNo,dt.PaidAmount 
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'')='' AND dt.DocType='CLR'
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+'#'+Convert(varchar,b.ItemNo))=e.DocNo
WHERE a.DocStatus>2 AND a.AdvType<>5 {0}
GROUP BY
a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode
ORDER BY a.EmpCode,a.PaymentDate,a.AdvNo
"
                        sqlM = String.Format(sqlM, sqlW)
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                    Case "CLRSUMMARY"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "b.ClrDate", "c.CustCode", "c.JNo", "c.EmpCode", "a.VenderCode", "b.ClrStatus", "b.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.JNo,a.AdvNo,b.ClrNo,b.ClrDate,c.CustCode,a.SICode + ' / ' + d.NameThai as SDescription,a.SlipNo,a.Date50Tavi as SlipDate,
a.BCost as SumCost,a.Tax50Tavi as Amt50Tavi,(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN a.BPrice ELSE 0 END) as TotalInv,
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 0 ELSE a.BPrice END) as Balance,a.LinkBillNo
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'')='' {0}
    order by a.SICode
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CUSTSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "c.DutyDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT CustCode,CustName,
SUM(AdvCleared+CostCleared) as TotalExpClear,SUM(ExpWaitBill) as TotalExpWaitBill,
SUM(CostWaitBill) as TotalCostWaitBill,
SUM(AdvCleared) as TotalAdv,SUM(ChargeCleared) as TotalCharge,SUM(CostCleared) as TotalCost,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+' '+e.NameThai as CustName,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=0 AND a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as ExpWaitBill,
(CASE WHEN d.IsExpense=0 AND NOT a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as ExpBilled,
(CASE WHEN d.IsExpense=1 AND a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as CostWaitBill,
(CASE WHEN d.IsExpense=1 AND NOT a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as CostBilled,
(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'')='' {0}
) clr
GROUP BY CustCode,CustName
ORDER BY CustName
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBSUMMARY"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "c.DutyDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode,
SUM(AdvCleared+CostCleared) as TotalExpClear,SUM(AdvWaitBill+ChargeWaitBill) as TotalExpWaitBill,
SUM(CostWaitBill) as TotalCostWaitBill,
SUM(AdvCleared) as TotalAdv,SUM(ChargeCleared) as TotalCharge,SUM(CostCleared) as TotalCost,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
	select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
	b.ClrNo,b.ClrDate,b.ClearType,b.DocStatus,a.AdvNo,a.AdvItemNo,c.CustCode,c.CustBranch,
	e.Title+' '+e.NameThai as CustName,a.SICode,a.SDescription,a.SlipNo,a.Date50Tavi as SlipDate,
	a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
	(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as AdvWaitBill,
	(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as ChargeWaitBill,
	(CASE WHEN d.IsExpense=1 AND a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as CostWaitBill,
	(CASE WHEN d.IsExpense=1 AND NOT a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as CostBilled,
	(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 AND NOT a.LinkBillNo='' THEN a.UsedAmount ELSE 0 END) as AdvBilled,
	(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 AND NOT a.LinkBillNo=''THEN a.UsedAmount ELSE 0 END) as ChargeBilled
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'')='' {0}
) clr
GROUP BY JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode
ORDER BY CustCode,DutyDate,JNo
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "INVSUMMARY"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "f.DocDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,
ISNULL(AmtCost,0) as TotalCost,
SUM(CASE WHEN IsCredit=1 THEN TotalNet ELSE 0 END) as TotalAdvance,
SUM(CASE WHEN IsCredit=0 THEN TotalNet ELSE 0 END) as TotalCharge,
SUM(AmtCredit) as TotalPrepaid,
SUM(ReceiptNet) as TotalReceived,
SUM(Balance) as TotalBalance,
SUM(ReceiptNet+AmtCredit)- SUM(CASE WHEN IsCredit=1 THEN TotalNet ELSE 0 END)-ISNULL(AmtCost,0) as TotalProfit
FROM (
	select f.BranchCode,f.DocNo,f.DocDate as InvDate, f.CustCode,f.CustBranch,c.JNo,c.DocDate as JobDate ,b.ClrNo,b.ClrDate,c.DeclareNumber,c.InvNo,
	c.DutyDate,c.CloseJobDate,c.CSCode,c.ShippingEmp,c.ManagerCode,c.InvProduct,c.VesselName,c.TotalContainer,e.Title+''+e.NameThai as CustName,
	f.BillAcceptNo,f.BillIssueDate,f.BillAcceptDate,f.DueDate,a.SICode,
	d.NameThai as SDescription,d.IsExpense,d.IsCredit,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	h.AmtAdvance,h.AmtCharge,h.AmtVat,h.Amt50Tavi,h.TotalAmt,h.AmtCredit,(h.TotalAmt+h.AmtCredit) as TotalNet,g.ReceiptNet,
	g.ReceiptNo,g.VoucherNo,i.AdjAmt as AdjustAmt,(h.TotalAmt-h.AmtCredit)-ISNULL(g.ReceiptNet,0) as Balance
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
		AND dt.ReceiptNo=hd.ReceiptNo WHERE ISNULL(hd.CancelProve,'')='' 
		GROUP BY dt.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo) g 
		ON a.BranchCode=g.BranchCode AND a.LinkBillNo=g.InvoiceNo AND a.LinkItem=g.InvoiceItemNo
	inner join Job_InvoiceDetail h on a.BranchCode=h.BranchCode and a.LinkBillNo=h.DocNo and a.LinkItem=h.ItemNo
	left join (
		SELECT dt.BranchCode,dt.BillingNo as InvoiceNo,dt.BillItemNo as InvoiceItemNo,sum(dt.TotalNet) as AdjAmt FROM Job_CNDNDetail dt inner join Job_CNDNHeader hd on dt.BranchCode=hd.BranchCode
		and dt.DocNo=hd.DocNo WHERE hd.DocStatus<>99 GROUP BY dt.BranchCode,dt.BillingNo,dt.BillItemNo
		) i 
		ON h.BranchCode=i.BranchCode and h.DocNo=i.InvoiceNo and h.ItemNo=i.InvoiceItemNo
	where ISNULL(b.CancelProve,'')='' AND ISNULL(f.CancelProve,'')='' {0}
) inv 
left join (
	SELECT dt.BranchCode,dt.LinkBillNo,SUM(dt.BNet) as AmtCost FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo WHERE ISNULL(hd.CancelProve,'')=''
	AND dt.LinkItem=0 AND hd.ClearType=2 GROUP BY dt.BranchCode,dt.LinkBillNo
) cost ON inv.BranchCode=cost.BranchCode AND inv.DocNo=cost.LinkBillNo
GROUP BY DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,AmtCost
ORDER BY CustCode,InvDate,DocNo
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CHQRECEIVE"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "a.ChqDate", "b.CustCode", "", "b.RecUser", "", "a.ChqStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = " SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,AmountRemain,DocUsed,TRemark FROM (" & SQLSelectChequeBalance("CU", "R") & sqlW & ") t ORDER BY CustCode,ChqDate,ChqNo "
                    Case "CHQISSUE"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "a.ChqDate", "b.CustCode", "", "b.RecUser", "", "a.ChqStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = " SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,DocUsed,TRemark FROM (" & SQLSelectChequeBalance("CH", "P") & sqlW & ") t ORDER BY CustCode,ChqDate,ChqNo "
                    Case "RVDAILY"
                        fldGroup = "VoucherDate"
                        sqlW = GetSQLCommand(cliteria, "VoucherDate", "CustCode", "", "RecUser", "", "", "BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (" & SQLSelectDocumentBalance("R", "") & ") t " & sqlW & " ORDER BY VoucherDate,ControlNo"
                    Case "PVDAILY"
                        fldGroup = "VoucherDate"
                        sqlW = GetSQLCommand(cliteria, "VoucherDate", "CustCode", "", "RecUser", "", "", "BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT ControlNo,PRVoucher as VoucherNo,VoucherDate,DocNo,CashAmount,ChqAmount,AmountUsed FROM (" & SQLSelectDocumentBalance("P", "") & " ) t " & sqlW & " ORDER BY VoucherDate,ControlNo"
                    Case "TRIALBAL"
                    Case "BALANCS"
                    Case "PROFITLOSS"
                    Case "JOURNAL"
                End Select
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlM, True)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content("{""result"":" & json & ",""group"":""" & fldGroup & """,""groupdata"":[" & groupDatas & "],""msg"":""OK"",""sql"":""" & sqlW & """}")
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetReport", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""group"":null,""msg"":""" & ex.Message & """,""sql"":""" & sqlW & """}")
            End Try
        End Function
    End Class
End Namespace