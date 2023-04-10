Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class ChartController
        Inherits MController

        ' GET: Mobile/Chart
        Function Index() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Index", "Chart")
                Return RedirectToAction("Index", "Login")
            End If
            Dim sqlW = ""
            Dim dateWhere = "DocDate"
            If Not IsNothing(Request.QueryString("OnDate")) Then
                dateWhere = Request.QueryString("OnDate")
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                sqlW &= dateWhere & " >='" & Request.QueryString("DateFrom") & "'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                If sqlW <> "" Then
                    sqlW &= " AND "
                End If
                sqlW &= dateWhere & " <='" & Request.QueryString("DateFrom") & "'"
            End If
            If sqlW <> "" Then
                sqlW = " WHERE " & sqlW
            End If
            PopulateJobData(sqlW)
            Return View("Index")
        End Function
        Sub PopulateJobData(sqlw As String)
            Dim oJob = New CJobOrder(ViewBag.JobConn).GetData(sqlw).AsEnumerable()
            Select Case ViewBag.UserRole
                Case "S"
                    Dim oJobFilter = From job In oJob
                                     Where job.CSCode.Equals(ViewBag.UserID) Or job.ManagerCode.Equals(ViewBag.UserID) Or "3,4,5".Contains(ViewBag.UserPosition) = False
                                     Select job

                    ViewBag.JobList = oJobFilter.ToList()
                Case "C"
                    Dim oCust = New CCompany(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oCustCode = If(oCust.Count > 0, oCust(0).CustCode, "")
                    Dim oCustBranch = If(oCust.Count > 0, oCust(0).Branch, "")
                    Dim oJobFilter = From job In oJob
                                     Where (job.CustCode.Equals(oCustCode) And job.CustBranch.Equals(oCustBranch))
                                     Select job

                    ViewBag.JobList = oJobFilter.ToList()
                Case "V"
                    Dim oVend = New CVender(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oVenCode = If(oVend.Count > 0, oVend(0).VenCode, "")
                    Dim oJobFilter = From job In oJob
                                     Where (job.AgentCode.Equals(oVenCode) Or job.ForwarderCode.Equals(oVenCode))
                                     Select job
                    ViewBag.JobList = oJobFilter.ToList()
            End Select
        End Sub
        Function Yearly() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Yearly", "Chart")
                Return RedirectToAction("Index", "Login")
            End If
            Dim sqlW = ""
            Dim dateWhere = "DocDate"
            If Not IsNothing(Request.QueryString("OnDate")) Then
                dateWhere = Request.QueryString("OnDate")
            End If
            Dim fromYear = ""
            If Not IsNothing(Request.QueryString("FromYear")) Then
                fromYear = Request.QueryString("FromYear")
                sqlW &= dateWhere & " >='" & fromYear & "-01-01'"
            End If
            Dim toYear = ""
            If Not IsNothing(Request.QueryString("ToYear")) Then
                If sqlW <> "" Then
                    sqlW &= " AND "
                End If
                toYear = Request.QueryString("ToYear")
                sqlW &= dateWhere & " <='" & toYear & "-12-31'"
            End If
            If sqlW <> "" Then
                sqlW = " WHERE " & sqlW
            End If
            PopulateJobYearly(sqlW)
            PopulateCostYearly(fromYear, toYear)
            Return View()
        End Function
        Sub PopulateCostYearly(fromYear As String, toYear As String)
            Dim advD = New CAdvDetail(ViewBag.JobConn).GetData("")
            If fromYear = "" Then fromYear = "0"
            If toYear = "" Then toYear = "9999"
            Dim advH = New CAdvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocStatus<>99 AND Year(PaymentDate)>='{0}' AND Year(PaymentDate)<='{1}'", fromYear, toYear))
            Dim advAll = From det In advD
                         Join hdr In advH
                         On det.BranchCode Equals hdr.BranchCode And det.AdvNo Equals hdr.AdvNo
                         Select PayYear = hdr.PaymentDate.Year, PayMonth = hdr.PaymentDate.Month, det.AdvNet, det.Charge50Tavi, det.SDescription, det.ForJNo, hdr.JobType
            Dim advSum = From data In advAll
                         Order By data.PayYear, data.PayMonth
                         Group By data.PayYear, data.PayMonth
                             Into AdvList = Group,
                             SumPaymentIM = Sum(If(data.JobType = 1, data.AdvNet + data.Charge50Tavi, 0)),
                             SumPaymentEX = Sum(If(data.JobType <> 1, data.AdvNet + data.Charge50Tavi, 0))
                         Select PayYear, PayMonth, SumPaymentIM, SumPaymentEX

            ViewBag.AdvSumMonthly = advSum

            Dim jobs = New CJobOrder(ViewBag.JobConn).GetData("")
            Dim clrD = New CClrDetail(ViewBag.JobConn).GetData(" WHERE ClrNo not in(select ClrNo from job_ClearHeader where DocStatus=99) ")
            Dim rcpD = (From data In (From dtl In New CRcpDetail(ViewBag.JobConn).GetData("")
                                      Join clr In clrD
                       On dtl.BranchCode Equals clr.BranchCode And dtl.InvoiceNo Equals clr.LinkBillNo And dtl.InvoiceItemNo Equals clr.LinkItem
                                      Select dtl.BranchCode, dtl.ReceiptNo, dtl.InvoiceNo, dtl.InvoiceItemNo, dtl.SDescription, dtl.Amt, dtl.Amt50Tavi, dtl.AmtVAT, dtl.Net, clr.JobNo)
                        Join job In jobs
                        On data.BranchCode Equals job.BranchCode And data.JobNo Equals job.JNo
                        Select job.JobType, job.ShipBy,
                            data.BranchCode, data.ReceiptNo, data.InvoiceNo, data.InvoiceItemNo, data.SDescription, data.Amt, data.Amt50Tavi, data.AmtVAT, data.Net, data.JobNo
                            )


            Dim rcpH = New CRcpHeader(ViewBag.JobConn).GetData(String.Format(" WHERE NOT CancelProve<>'' AND Year(ReceiptDate)>='{0}' AND Year(ReceiptDate)<='{1}'", fromYear, toYear))
            Dim rcpAll = From det In rcpD
                         Join hdr In rcpH
                         On det.BranchCode Equals hdr.BranchCode And det.ReceiptNo Equals hdr.ReceiptNo
                         Select RcpYear = hdr.ReceiptDate.Year, RcpMonth = hdr.ReceiptDate.Month,
                             det.Net, det.Amt50Tavi, det.SDescription, det.InvoiceNo, det.JobType, det.ShipBy

            Dim rcpSum = From data In rcpAll
                         Order By data.RcpYear, data.RcpMonth
                         Group By data.RcpYear, data.RcpMonth
                           Into RcpList = Group,
                             SumReceiveIM = Sum(If(data.JobType = 1, data.Net + data.Amt50Tavi, 0)),
                             SumReceiveEX = Sum(If(data.JobType <> 1, data.Net + data.Amt50Tavi, 0))
                         Order By RcpYear, RcpMonth

            ViewBag.RcpSumMonthly = rcpSum

            Dim advrcpCompare = From rcp In rcpSum
                                Join adv In advSum
                                On rcp.RcpYear Equals adv.PayYear And rcp.RcpMonth Equals adv.PayMonth
                                Select FiscalYear = rcp.RcpYear, FiscalMonth = rcp.RcpMonth,
                                    TotalReceive = rcp.SumReceiveEX + rcp.SumReceiveIM,
                                    TotalAdvance = adv.SumPaymentEX + adv.SumPaymentIM

            ViewBag.SumAdvRcpMonthly = advrcpCompare
        End Sub
        Sub PopulateJobYearly(sqlw As String)
            Dim oJob = New CJobOrder(ViewBag.JobConn).GetData(sqlw).AsEnumerable()
            Select Case ViewBag.UserRole
                Case "S"
                    Dim oJobFilter = From job In oJob
                                     Where job.CSCode.Equals(ViewBag.UserID) Or job.ManagerCode.Equals(ViewBag.UserID) Or "3,4,5".Contains(ViewBag.UserPosition) = False
                                     Order By job.DocDate.Year, job.DocDate.Month
                                     Group By JobYear = job.DocDate.Year, JobMonth = job.DocDate.Month
                                     Into DataSource = Group, JobCountIM = Count(job.JobType = 1), JobCountEX = Count(job.JobType <> 1)
                                     Order By JobYear, JobMonth
                    ViewBag.JobCountMonthly = oJobFilter.ToList()
                Case "C"
                    Dim oCust = New CCompany(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oCustCode = If(oCust.Count > 0, oCust(0).CustCode, "")
                    Dim oCustBranch = If(oCust.Count > 0, oCust(0).Branch, "")
                    Dim oJobFilter = From job In oJob
                                     Where (job.CustCode.Equals(oCustCode) And job.CustBranch.Equals(oCustBranch))
                                     Order By job.DocDate.Year, job.DocDate.Month
                                     Group By JobYear = job.DocDate.Year, JobMonth = job.DocDate.Month
                                     Into DataSource = Group, JobCountIM = Count(job.JobType = 1), JobCountEX = Count(job.JobType <> 1)
                                     Order By JobYear, JobMonth
                    ViewBag.JobCountMonthly = oJobFilter.ToList()
                Case "V"
                    Dim oVend = New CVender(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oVenCode = If(oVend.Count > 0, oVend(0).VenCode, "")
                    Dim oJobFilter = From job In oJob
                                     Where (job.AgentCode.Equals(oVenCode) Or job.ForwarderCode.Equals(oVenCode))
                                     Order By job.DocDate.Year, job.DocDate.Month
                                     Group By JobYear = job.DocDate.Year, JobMonth = job.DocDate.Month
                                     Into DataSource = Group, JobCountIM = Count(job.JobType = 1), JobCountEX = Count(job.JobType <> 1)
                                     Order By JobYear, JobMonth
                    ViewBag.JobCountMonthly = oJobFilter.ToList()
            End Select
        End Sub
    End Class
End Namespace