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
        <HttpPost>
        <ActionName("Loading")>
        Function PostLoading(form As FormCollection) As ActionResult
            TempData("AtDate") = form("atDate")
            Return RedirectToAction("Loading", "Chart")
        End Function
        Function Finance() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Finance", "Chart")
                Return RedirectToAction("Index", "Login")
            End If
            Dim atDate = DateTime.Today.ToString("yyyy-MM-dd")
            If Not IsNothing(Request.QueryString("AtDate")) Then
                atDate = Request.QueryString("AtDate")
            End If
            PopulateCashDaily(atDate)
            ViewBag.AtDate = atDate
            Return View()
        End Function
        Function Loading() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Loading", "Chart")
                Return RedirectToAction("Index", "Login")
            End If
            Dim sqlW = ""
            Dim dateWhere = "DocDate"
            If Not IsNothing(Request.QueryString("OnDate")) Then
                dateWhere = Request.QueryString("OnDate")
            End If
            Dim atDate = DateTime.Today.ToString("yyyy-MM-dd")
            If Not IsNothing(TempData("AtDate")) Then
                atDate = TempData("AtDate")
            End If
            ViewBag.AtDate = atDate
            PopulateJobLoadingMonthly(sqlW, dateWhere, atDate)
            Return View()
        End Function
        Public Sub PopulateJobLoadingMonthly(sqlw As String, dateWhere As String, atDate As String)
            Dim oJobIMToday = New CJobOrder(ViewBag.JobConn).GetData(String.Format(" WHERE JobStatus<>99 AND JobType=1 AND ETADate='{0}'", atDate))
            Dim oJobEXToday = New CJobOrder(ViewBag.JobConn).GetData(String.Format(" WHERE JobStatus<>99 AND JobType<>1 AND ETDDate='{0}'", atDate))
            Dim oJobIMLastWeek = New CJobOrder(ViewBag.JobConn).GetData(String.Format(" WHERE JobStatus<>99 AND JobType=1 AND ETADate>=DATEADD(week,-1,'{0}') AND ETADate<'{0}'", atDate))
            Dim oJobEXLastWeek = New CJobOrder(ViewBag.JobConn).GetData(String.Format(" WHERE JobStatus<>99 AND JobType<>1 AND ETDDate>=DATEADD(week,-1,'{0}') AND ETDDate<'{0}'", atDate))

            Dim oJobIMNextWeek = New CJobOrder(ViewBag.JobConn).GetData(String.Format(" WHERE JobStatus<>99 AND JobType=1 AND ETADate<=DATEADD(week,1,'{0}') AND ETADate>'{0}'", atDate))
            Dim oJobEXNextWeek = New CJobOrder(ViewBag.JobConn).GetData(String.Format(" WHERE JobStatus<>99 AND JobType<>1 AND ETDDate<=DATEADD(week,1,'{0}') AND ETDDate>'{0}'", atDate))

            Dim oReleasePort = New CCustomsPort(ViewBag.MasConn).GetData("")

            Dim oCountJobIM = From job In oJobIMToday
                              Join port In oReleasePort
                              On job.ClearPort Equals port.AreaCode
                              Group By job.ClearPort, ClearPortName = port.AreaName
                              Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEx = Count(job.JobType <> 1)
                              Order By ClearPortName

            Dim oCountJobEX = From job In oJobEXToday
                              Join port In oReleasePort
                              On job.ClearPort Equals port.AreaCode
                              Group By job.ClearPort, ClearPortName = port.AreaName
                              Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEx = Count(job.JobType <> 1)
                              Order By ClearPortName

            ViewBag.JobExToday = oCountJobEX.ToList()
            ViewBag.JobImToday = oCountJobIM.ToList()

            Dim ListTodayJoin = oCountJobIM.Concat(oCountJobEX)

            ViewBag.JobToday = From lst In ListTodayJoin
                               Group By lst.ClearPort, lst.ClearPortName
                               Into DataSource = Group, CountIM = Sum(lst.CountIM), CountEX = Sum(lst.CountEx)
                               Order By ClearPortName

            Dim oCountJobIMLastWeek = From job In oJobIMLastWeek
                                      Join port In oReleasePort
                                      On job.ClearPort Equals port.AreaCode
                                      Group By job.ClearPort, ClearPortName = port.AreaName, ImExDate = job.ETADate
                                            Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEx = Count(job.JobType <> 1)
                                      Order By ClearPort

            Dim oCountJobEXLastWeek = From job In oJobEXLastWeek
                                      Join port In oReleasePort
                                      On job.ClearPort Equals port.AreaCode
                                      Group By job.ClearPort, ClearPortName = port.AreaName, ImExDate = job.ETDDate
                                      Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEx = Count(job.JobType <> 1)
                                      Order By ClearPort

            ViewBag.JobExLastWeek = oCountJobEXLastWeek.ToList()
            ViewBag.JobImLastWeek = oCountJobIMLastWeek.ToList()

            Dim ListLastWeekJoin = oCountJobEXLastWeek.Concat(oCountJobIMLastWeek)

            ViewBag.JobLastWeek = From lst In ListLastWeekJoin
                                  Group By lst.ImExDate
                                  Into DataSource = Group, CountIM = Sum(lst.CountIM), CountEX = Sum(lst.CountEx)
                                  Order By ImExDate

            Dim oCountJobIMNextWeek = From job In oJobIMNextWeek
                                      Join port In oReleasePort
                                      On job.ClearPort Equals port.AreaCode
                                      Group By job.ClearPort, ClearPortName = port.AreaName, ImExDate = job.ETADate
                                            Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEx = Count(job.JobType <> 1)
                                      Order By ClearPort

            Dim oCountJobEXNextWeek = From job In oJobEXNextWeek
                                      Join port In oReleasePort
                                      On job.ClearPort Equals port.AreaCode
                                      Group By job.ClearPort, ClearPortName = port.AreaName, ImExDate = job.ETDDate
                                      Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEx = Count(job.JobType <> 1)
                                      Order By ClearPort

            ViewBag.JobExNextWeek = oCountJobEXNextWeek.ToList()
            ViewBag.JobImNextWeek = oCountJobIMNextWeek.ToList()

            Dim ListNextWeekJoin = oCountJobEXNextWeek.Concat(oCountJobIMNextWeek)

            ViewBag.JobNextWeek = From lst In ListNextWeekJoin
                                  Group By lst.ImExDate
                                  Into DataSource = Group, CountIM = Sum(lst.CountIM), CountEX = Sum(lst.CountEx)
                                  Order By ImExDate
        End Sub
        Sub PopulateCashDaily(atDate As String)
            Dim oAdvHdr = New CAdvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocStatus<>99 AND PayChqDate='{0}'", atDate))
            Dim oAdvDtl = From d In New CAdvDetail(ViewBag.JobConn).GetData(" WHERE AdvNo NOT IN(select AdvNo from Job_AdvHeader where DocStatus=99)")
                          Join h In oAdvHdr On String.Concat(d.BranchCode, d.AdvNo) Equals String.Concat(h.BranchCode, h.AdvNo)
                          Group By DueDate = h.PayChqDate
                            Into DataSource = Group, SumExpense = Sum(d.AdvNet + d.Charge50Tavi), SumReceive = Sum(0)
                          Order By DueDate

            Dim oInvHdr = New CInvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DueDate='{0}' AND NOT CancelProve<>''", atDate))
            Dim oInvDtl = From d In New CInvDetail(ViewBag.JobConn).GetData(" WHERE DocNo NOT IN(SELECT DocNo from Job_InvoiceHeader WHERE DueDate is null OR CancelProve<>'')")
                          Join h In oInvHdr On String.Concat(d.BranchCode, d.DocNo) Equals String.Concat(h.BranchCode, h.DocNo)
                          Where h.CancelProve.ToString() = ""
                          Group By h.DueDate
                              Into DataSource = Group, SumExpense = Sum(0), SumReceive = Sum(d.TotalAmt + d.Amt50Tavi)
                          Order By DueDate

            ViewBag.SumInvDue = oInvDtl.ToList()
            ViewBag.SumPayDue = oAdvDtl.ToList()
            ViewBag.SumCashDaily = From r In oInvDtl.Union(oAdvDtl)
                                   Group By r.DueDate
                                   Into TotalExpense = Sum(r.SumExpense), TotalReceive = Sum(r.SumReceive)
                                   Order By DueDate
        End Sub
    End Class
End Namespace