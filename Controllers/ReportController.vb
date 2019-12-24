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
        Function GetSQLCommand(cliteria As String, fldDate As String, fldCust As String, fldJob As String, fldEmp As String, fldVend As String, fldStatus As String, fldBranch As String) As String
            Dim sqlW As String = ""
            If cliteria Is Nothing Then
                Return ""
            End If
            For Each str As String In cliteria.Split(",")
                If str <> "" Then
                    If sqlW <> "" Then
                        If str.Substring(0, 2) <> "OR" Then
                            sqlW &= " AND ("
                        Else
                            sqlW = "(" & sqlW & ")"
                            str = str.Replace("OR", " OR ((")
                        End If
                    Else
                        sqlW &= "("
                    End If
                    If fldBranch <> "" Then str = ProcessCliteria(str, "[BRANCH]", fldBranch)
                    If fldDate <> "" Then str = ProcessCliteria(str, "[DATE]", fldDate)
                    If fldCust <> "" Then str = ProcessCliteria(str, "[CUST]", fldCust)
                    If fldJob <> "" Then str = ProcessCliteria(str, "[JOB]", fldJob)
                    If fldEmp <> "" Then str = ProcessCliteria(str, "[EMP]", fldEmp)
                    If fldStatus <> "" Then str = ProcessCliteria(str, "[STATUS]", fldStatus)
                    If fldVend <> "" Then str = ProcessCliteria(str, "[VEND]", fldVend)
                    sqlW &= str
                    If sqlW <> "" Then
                        sqlW &= ")"
                    End If
                End If
            Next
            If sqlW.Substring(0, 2) = "((" Then
                sqlW &= ")"
            End If
            Return sqlW
        End Function
        Private Function ProcessCliteria(str As String, key As String, val As String) As String
            If str.Contains(key) Then
                Dim fld As String = str.Replace(key, " " & val & " ")
                fld = FindFieldCliteria(fld) & FindValueCliteria(str)
                Return fld
            Else
                Return str
            End If
        End Function
        Private Function FindFieldCliteria(str As String) As String
            If str.IndexOf(">=") > 0 Then
                Return str.Split(">=")(0)
            End If
            If str.IndexOf("<=") > 0 Then
                Return str.Split("<=")(0)
            End If
            If str.IndexOf("<>") > 0 Then
                Return str.Split("<>")(0)
            End If
            If str.IndexOf("LIKE%") > 0 Then
                Return str.Split("LIKE%")(0)
            End If
            If str.IndexOf("=") > 0 Then
                Return str.Split("=")(0)
            End If
            Return ""
        End Function

        Private Function FindValueCliteria(str As String) As String
            If str.IndexOf(">=") > 0 Then
                Return ">='" & str.Split(">=")(1).Substring(1) & "'"
            End If
            If str.IndexOf("<=") > 0 Then
                Return "<='" & str.Split("<=")(1).Substring(1) & "'"
            End If
            If str.IndexOf("<>") > 0 Then
                Return "<>'" & str.Split("<>")(1).Substring(1) & "'"
            End If
            If str.IndexOf("LIKE%") > 0 Then
                Return "Like '" & str.Split("LIKE%")(1).Substring(3) & "%'"
            End If
            If str.IndexOf("=") > 0 Then
                Return "='" & str.Split("=")(1) & "'"
            End If
            Return "''"
        End Function
        Function GetReport(<FromBody()> data As CReport) As ActionResult
            Dim sqlM As String = ""
            Dim sqlW As String = ""
            Dim fldGroup = ""
            Dim cliteria As String = data.ReportCliteria
            Try
                Select Case data.ReportCode
                    Case "JOBDAILY"
                        fldGroup = "DutyDate"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.DocDate,j.DutyDate,j.ShippingEmp,j.InvProduct,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j ORDER BY j.DutyDate DESC"
                    Case "JOBCS"
                        fldGroup = "CSCode"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.DocDate,j.DutyDate,j.CSCode,j.InvProduct,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.CSCode DESC"
                    Case "JOBSHP"
                        fldGroup = "ShippingEmp"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.DocDate,j.DutyDate,j.ShippingEmp,j.InvProduct,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ShippingEmp DESC"
                    Case "JOBTYPE"
                        fldGroup = "JobTypeName"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.JobTypeName,j.ShipByName,j.DutyDate,j.InvProduct,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.JobType,j.CustCode,j.ShipBy,j.DocDate DESC"
                    Case "JOBSHIPBY"
                        fldGroup = "ShipByName"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.JobTypeName,j.ShipByName,j.DutyDate,j.InvProduct,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ShipBy,j.CustCode,j.JobType,j.DocDate DESC"
                    Case "JOBCUST"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.DocDate,j.DutyDate,j.CustCode,j.InvProduct,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.CustCode,j.DutyDate DESC"
                    Case "JOBPORT"
                        fldGroup = "ClearPort"
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.LoadDate,j.CustCode,j.InvNo,j.DeliveryTo,j.InvProductQty,j.InvProductUnit,j.ClearPort,j.TotalContainer,j.TotalGW,j.ETDDate,j.ETADate,j.CSCode FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ClearPort,j.LoadDate DESC,j.CustCode,j.InvNo"
                    Case "JOBADV"
                        fldGroup = "ReqBy"
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
                    Case "TAXDAILY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT>0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT>0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net,rc.PRVoucher FROM (" & SQLSelectReceiptReport() & sqlW & ") rc ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "CASHDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "r.CmpCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE (d.ChqAmount >0 OR d.CashAmount>0) AND " & sqlW
                        sqlM = "SELECT vc.PRVoucher,vc.VoucherDate,vc.BookCode,vc.ChqNo,vc.ChqDate,vc.RecvBank,vc.CashAmount+vc.ChqAmount as Total,vc.DRefNo FROM (" & SQLSelectVoucher() & sqlW & ") vc ORDER BY vc.VoucherDate,vc.PRVoucher"
                    Case "CLRDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.ClrDate", "j.CustCode", "j.JNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE h.DocStatus<>99 " & sqlW
                        sqlM = "SELECT cl.ClrNo,cl.ClrDate,cl.SDescription,cl.AdvNO,cl.JobNo,cl.AdvNet,cl.ClrNet,cl.Tax50Tavi,cl.SlipNo FROM (" & SQLSelectClrDetail() & sqlW & ") cl ORDER BY cl.ClrDate,cl.ClrNo"
                    Case "INVDAILY"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "ih.RefNo", "ih.EmpCode", "", "", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT inv.DocNo,inv.DocDate,inv.SDescription,inv.Amt,inv.AmtVat,inv.AmtCredit,inv.TotalInv,inv.CreditNet,inv.ReceivedNet FROM (" & SQLSelectInvReport(sqlW) & ") inv ORDER BY inv.DocDate,inv.DocNo"
                    Case "BILLDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.BillDate", "h.CustCode", "", "h.EmpCode", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT bl.BillAcceptNo,bl.BillDate,bl.CustCode,bl.InvNo,bl.AmtAdvance,bl.AmtChargeNonVAT,bl.AmtChargeVAT,bl.AmtVAT,bl.AmtWH,bl.AmtTotal FROM (" & SQLSelectBillReport() & ") bl ORDER BY bl.BillDate,bl.BillAcceptNo"
                    Case "JOBCOST"
                        sqlW = GetSQLCommand(cliteria, "ch.ClrDate", "j.CustCode", "j.JNo", "j.CSCode", "j.ForwarderCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT CustCode,JNo,DeclareNumber,InvNo,DutyDate,SumAdvance,SumCost,SumCharge,Profit FROM (
SELECT j.BranchCode, j.JNo, j.CustCode, j.CustBranch, j.InvNo, j.DutyDate, j.DeclareNumber,j.CSCode,j.ManagerCode,
SUM(CASE WHEN ch.ClearType=1 THEN cd.BNet ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN ch.ClearType=2 THEN cd.BNet+cd.Tax50Tavi ELSE 0 END) AS SumCost,
SUM(CASE WHEN ch.ClearType=3 THEN cd.BNet+cd.Tax50Tavi ELSE 0 END) AS SumCharge,
SUM(CASE WHEN ch.ClearType=3 THEN cd.BNet+cd.Tax50Tavi ELSE 0 END)-SUM(CASE WHEN ch.ClearType=2 THEN cd.BNet+cd.Tax50Tavi ELSE 0 END) as Profit
FROM            dbo.Job_ClearHeader AS ch INNER JOIN
                         dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
						 AND ch.ClrNo=cd.ClrNo
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
                    Case "WHTAX"
                        sqlW = GetSQLCommand(cliteria, "cd.Date50Tavi", "c.CustCode", "cd.JobNo", "ch.EmpCode", "cd.VenderCode", "", "ch.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT Date50Tavi,NO50Tavi,VenTaxNumber,VenTaxBranch,VenderName,CustCode,CustTaxBranch,CustTaxNumber,CustName,
(CASE WHEN Tax50TaviRate =1 THEN 'ค่าขนส่ง' ELSE (CASE WHEN Tax50TaviRate =3 THEN 'ค่าบริการ' ELSE (CASE WHEN Tax50TaviRate =5 THEN 'ค่าเช่า' ELSE (CASE WHEN Tax50TaviRate =2 THEN 'ค่าโฆษณา' ELSE (CASE WHEN Tax50TaviRate =10 THEN 'ออกให้มูลนิธิ/สมาคม' ELSE 'เงินเดือน' END) END) END) END) END) as TaxType,
(CASE WHEN CustName Like '%จำกัด%' THEN '53' ELSE '3' END) as TaxForm,
(CASE WHEN IsLtdAdv50Tavi=1 THEN Tax50Tavi ELSE 0 END) as Tax3Tres,
(CASE WHEN IsLtdAdv50Tavi=0 THEN Tax50Tavi ELSE 0 END) as TaxNot3Tres,
SlipNO,UsedAmount,Tax50TaviRate
FROM (" & String.Format(SQLSelectTax50TaviReport(), sqlW) & ") as t ORDER BY Date50Tavi,NO50Tavi"
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
                        sqlM = "SELECT PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t ORDER BY PRType DESC,PRVoucher"
                    Case "STATEMENT"
                        fldGroup = "BookCode"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT BookCode,VoucherDate,TRemark,PRVoucher,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t WHERE BookCode<>'' ORDER BY BookCode,VoucherDate,PRVoucher "
                    Case "ARBAL"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "DocDate", "CustCode", "RefNo", "EmpCode", "", "", "BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "
SELECT CustCode,DocNo,DocDate,RefNo,
Sum(AmtAdvance) as TotalAdv,Sum(AmtCharge) as TotalCharge,Sum(AmtVAT) as TotalVat,Sum(Amt50Tavi) as Total50Tavi,
Sum(TotalAmt) as TotalNet,Sum(TotalReceiveAmt) as TotalReceived,Sum(TotalCreditAmt) as TotalCredit,Sum(TotalBal) as TotalBal
FROM (
SELECT ih.*,id.SICode,id.SDescription,id.AmtCharge,id.AmtVat,id.Amt50Tavi,id.AmtAdvance,
id.TotalAmt,ISNULL(c.TotalCredit,0) as TotalCreditAmt,ISNULL(r.RecvNet,0) as TotalReceiveAmt
,id.TotalAmt-ISNULL(c.TotalCredit,0)-ISNULL(r.RecvNet,0) as TotalBal
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
                        sqlW = GetSQLCommand(cliteria, "a.DocDate", "a.CustCode", "", "a.EmpCode", "", "", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = SQLSelectCNDNSummary() & " WHERE a.DocStatus<>99 AND ISNULL(a.ApproveBy,'')<>'' {0} "
                        sqlM = "SELECT CustCode,DocDate,DocNo,InvoiceNo,TotalAmt,TotalVAT,TotalWHT,TotalNet FROM (" & String.Format(sqlM, sqlW) & ") t ORDER BY CustCode,DocDate,DocNo "
                    Case "TRIALBAL"
                    Case "BALANCS"
                    Case "PROFITLOSS"
                    Case "JOURNAL"
                End Select
                Dim oData = New CUtil(jobWebConn).GetTableFromSQL(sqlM, True)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content("{""result"":" & json & ",""group"":""" & fldGroup & """,""msg"":""OK"",""sql"":""" & sqlW & """}")
            Catch ex As Exception
                Main.SaveLog(GetSession("CurrLicense").ToString(), "JOBSHIPPING", "GetReport", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""group"":null,""msg"":""" & ex.Message & """,""sql"":""" & sqlW & """}")
            End Try
        End Function
    End Class
End Namespace