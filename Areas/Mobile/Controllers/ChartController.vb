Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class ChartController
        Inherits MController

        ' GET: Mobile/Chart
#Region "Get Function"
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
                sqlW &= dateWhere & " <='" & Request.QueryString("DateTo") & "'"
            End If
            If sqlW <> "" Then
                sqlW = " WHERE " & sqlW
            End If
            PopulateJobData(sqlW)
            Return View("Index")
        End Function
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
            PopulateCashWeekly(atDate)
            PopulateCashMonthly(atDate)
            PopulatePayablesDaily(atDate)
            PopulatePayablesWeekly(atDate)
            PopulateReceivablesDaily(atDate)
            PopulateReceivablesWeekly(atDate)

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
        Function Advance() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Advance", "Chart")
                Return RedirectToAction("Index", "Login")
            End If
            Dim sqlW = ""
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                ViewBag.DateFrom = Request.QueryString("DateFrom")
                sqlW &= "{0} >='" & Request.QueryString("DateFrom") & "'"
            Else
                ViewBag.DateFrom = ""
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                If sqlW <> "" Then
                    sqlW &= " AND "
                End If
                ViewBag.DateTo = Request.QueryString("DateTo")
                sqlW &= "{1} <='" & Request.QueryString("DateTo") & "'"
            Else
                ViewBag.DateTo = ""
            End If

            Dim oAdvReq = (From dtl In New CAdvDetail(ViewBag.JobConn).GetData("")
                           Join hdr In New CAdvHeader(ViewBag.JobConn).GetData(" WHERE DocStatus IN('1','2')" & IIf(sqlW <> "", String.Format(sqlW, " AND AdvDate", "AdvDate"), ""))
                          On String.Concat(dtl.BranchCode, dtl.AdvNo) Equals String.Concat(hdr.BranchCode, hdr.AdvNo)
                           Group By hdr.EmpCode
                              Into DataSource = Group,
                               SumCash = Sum(If(hdr.AdvCash > 0, dtl.AdvNet + dtl.Charge50Tavi, 0)),
                               SumChq = Sum(If(hdr.AdvChq > 0, dtl.AdvNet + dtl.Charge50Tavi, 0)),
                               SumChqCash = Sum(If(hdr.AdvChqCash > 0, dtl.AdvNet + dtl.Charge50Tavi, 0))
                              ).ToList()

            Dim oAdvUnCleared = (From dtl In New CAdvDetail(ViewBag.JobConn).GetData(" WHERE CONCAT(AdvNo,ItemNo) NOT IN(Select DISTINCT CONCAT(b.AdvNO,b.AdvItemNo) as LinkAdv from Job_ClearDetail b inner join Job_ClearHeader a on b.BranchCode=a.BranchCode AND b.ClrNo=a.ClrNo where b.AdvNO<>'' AND a.DocStatus<>99)")
                                 Join hdr In New CAdvHeader(ViewBag.JobConn).GetData(" WHERE DocStatus <99 AND DocStatus>2 " & IIf(sqlW <> "", String.Format(sqlW, " AND PaymentDate", "PaymentDate"), ""))
                          On String.Concat(dtl.BranchCode, dtl.AdvNo) Equals String.Concat(hdr.BranchCode, hdr.AdvNo)
                                 Group By hdr.EmpCode
                              Into DataSource = Group,
                               SumCash = Sum(If(hdr.AdvCash > 0, dtl.AdvNet + dtl.Charge50Tavi, 0)),
                               SumChq = Sum(If(hdr.AdvChq > 0, dtl.AdvNet + dtl.Charge50Tavi, 0)),
                               SumChqCash = Sum(If(hdr.AdvChqCash > 0, dtl.AdvNet + dtl.Charge50Tavi, 0))
                              ).ToList()

            Dim oAdvUnBilled = (From dtl In New CAdvDetail(ViewBag.JobConn).GetData("")
                                Join hdr In New CAdvHeader(ViewBag.JobConn).GetData(" WHERE DocStatus <99 AND DocStatus>2 " & IIf(sqlW <> "", String.Format(sqlW, " AND PaymentDate", "PaymentDate"), ""))
                          On String.Concat(dtl.BranchCode, dtl.AdvNo) Equals String.Concat(hdr.BranchCode, hdr.AdvNo)
                                Join clr In New CClrDetail(ViewBag.JobConn).GetData(" WHERE AdvNO<>'' AND ClrNo NOT IN(SELECT ClrNo FROM Job_ClearHeader where DocStatus=99 )")
                                On String.Concat(dtl.BranchCode, dtl.AdvNo, dtl.ItemNo) Equals String.Concat(clr.BranchCode, clr.AdvNO, clr.AdvItemNo)
                                Join srv In New CServiceCode(ViewBag.JobConn).GetData("")
                                On clr.SICode Equals srv.SICode
                                Join job In New CJobOrder(ViewBag.JobConn).GetData("")
                                On String.Concat(clr.BranchCode, clr.JobNo) Equals String.Concat(job.BranchCode, job.JNo)
                                Where clr.LinkItem = 0 And clr.BNet > 0 And srv.IsExpense = 0
                                Group By job.CustCode
                              Into DataSource = Group, SumNet = Sum(clr.BNet), SumWht = Sum(clr.Tax50Tavi)
                              ).ToList()

            Dim oAdvCleared = (From dtl In New CAdvDetail(ViewBag.JobConn).GetData("")
                               Join hdr In New CAdvHeader(ViewBag.JobConn).GetData(" WHERE DocStatus <99 AND DocStatus>2 " & IIf(sqlW <> "", String.Format(sqlW, " AND PaymentDate", "PaymentDate"), ""))
                          On String.Concat(dtl.BranchCode, dtl.AdvNo) Equals String.Concat(hdr.BranchCode, hdr.AdvNo)
                               Join clr In New CClrDetail(ViewBag.JobConn).GetData(" WHERE AdvNO<>'' AND ClrNo NOT IN(SELECT ClrNo FROM Job_ClearHeader where DocStatus=99 )")
                                On String.Concat(dtl.BranchCode, dtl.AdvNo, dtl.ItemNo) Equals String.Concat(clr.BranchCode, clr.AdvNO, clr.AdvItemNo)
                               Join srv In New CServiceCode(ViewBag.JobConn).GetData("")
                                On clr.SICode Equals srv.SICode
                               Join job In New CJobOrder(ViewBag.JobConn).GetData("")
                                On String.Concat(clr.BranchCode, clr.JobNo) Equals String.Concat(job.BranchCode, job.JNo)
                               Group By job.CustCode
                              Into DataSource = Group,
                                   SumBilled = Sum(If(clr.LinkItem > 0 And srv.IsExpense = 0, clr.UsedAmount + clr.ChargeVAT, 0)),
                                   SumUnBilled = Sum(If(clr.LinkItem = 0 And srv.IsExpense = 0, clr.UsedAmount + clr.ChargeVAT, 0)),
                                   SumCost = Sum(If(srv.IsExpense = 1, clr.UsedAmount + clr.ChargeVAT, 0))
                              ).ToList()

            ViewBag.AdvRequest = oAdvReq
            ViewBag.AdvCleared = oAdvCleared
            ViewBag.AdvUnCleared = oAdvUnCleared
            ViewBag.AdvUnBilled = oAdvUnBilled
            Return View()
        End Function
#End Region 'GET Functions
#Region "Post Function"
        <HttpPost>
        <ActionName("Loading")>
        Function PostLoading(form As FormCollection) As ActionResult
            TempData("AtDate") = form("atDate")
            Return RedirectToAction("Loading", "Chart")
        End Function
#End Region 'POST Functions
#Region "Populate Function"
        Sub PopulateJobData(sqlw As String)
            If sqlw = "" Then
                sqlw = " WHERE "
            Else
                sqlw = sqlw & " AND "
            End If
            Select Case ViewBag.UserRole
                Case "S"
                    Dim oJobFilter = New CJobOrder(ViewBag.JobConn).GetData(sqlw & String.Format(" (CSCode='{0}' OR NOT CHARINDEX('{1}','3,4,5')>0)", ViewBag.UserID, ViewBag.UserPosition))

                    ViewBag.JobList = oJobFilter
                    Dim oJobGroup = From job In oJobFilter
                                    Join sby In New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY' ")
                                        On Convert.ToInt32(job.ShipBy) Equals Convert.ToInt32(sby.ConfigKey)
                                    Where job.JobStatus <> 99
                                    Group By job.ShipBy, ShipByName = sby.ConfigValue
                                        Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEX = Count(job.JobType = 1)
                                    Order By ShipByName
                    ViewBag.JobByType = oJobGroup.ToList()
                Case "C"

                    Dim oCust = New CCompany(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oCustCode = If(oCust.Count > 0, oCust(0).CustCode, "")
                    Dim oCustBranch = If(oCust.Count > 0, oCust(0).Branch, "")
                    Dim oJobFilter = New CJobOrder(ViewBag.JobConn).GetData(sqlw & String.Format(" (CustCode='{0}' AND CustBranch='{1}')", oCustCode, oCustBranch))

                    ViewBag.JobList = oJobFilter
                    Dim oJobGroup = From job In oJobFilter
                                    Join sby In New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY' ")
                                        On Convert.ToInt32(job.ShipBy) Equals Convert.ToInt32(sby.ConfigKey)
                                    Where job.JobStatus <> 99
                                    Group By job.ShipBy, ShipByName = sby.ConfigValue
                                        Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEX = Count(job.JobType = 1)
                                    Order By ShipByName
                    ViewBag.JobByType = oJobGroup.ToList()
                Case "V"
                    Dim oVend = New CVender(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oVenCode = If(oVend.Count > 0, oVend(0).VenCode, "")
                    Dim oJobFilter = New CJobOrder(ViewBag.JobConn).GetData(sqlw & String.Format(" (AgentCode='{0}' OR ForwarderCode='{0}')", oVenCode))

                    ViewBag.JobList = oJobFilter

                    Dim oJobGroup = From job In oJobFilter
                                    Join sby In New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY' ")
                                        On Convert.ToInt32(job.ShipBy) Equals Convert.ToInt32(sby.ConfigKey)
                                    Where job.JobStatus <> 99
                                    Group By job.ShipBy, ShipByName = sby.ConfigValue
                                        Into DataSource = Group, CountIM = Count(job.JobType = 1), CountEX = Count(job.JobType = 1)
                                    Order By ShipByName
                    ViewBag.JobByType = oJobGroup.ToList()
            End Select
        End Sub
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
            If sqlw = "" Then
                sqlw = " WHERE "
            Else
                sqlw = sqlw & " AND "
            End If
            Select Case ViewBag.UserRole
                Case "S"

                    Dim oJob = New CJobOrder(ViewBag.JobConn).GetData(sqlw & String.Format(" (CSCode='{0}' OR NOT CHARINDEX('{1}','3,4,5')>0)", ViewBag.UserID, ViewBag.UserPosition))

                    Dim oJobFilter = From job In oJob
                                     Order By job.DocDate.Year, job.DocDate.Month
                                     Group By JobYear = job.DocDate.Year, JobMonth = job.DocDate.Month
                                     Into DataSource = Group, JobCountIM = Count(job.JobType = 1), JobCountEX = Count(job.JobType <> 1)
                                     Order By JobYear, JobMonth
                    ViewBag.JobCountMonthly = oJobFilter.ToList()
                Case "C"
                    Dim oCust = New CCompany(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oCustCode = If(oCust.Count > 0, oCust(0).CustCode, "")
                    Dim oCustBranch = If(oCust.Count > 0, oCust(0).Branch, "")
                    Dim oJob = New CJobOrder(ViewBag.JobConn).GetData(sqlw & String.Format(" (CustCode='{0}' AND CustBranch='{1}')", oCustCode, oCustBranch))
                    Dim oJobFilter = From job In oJob
                                     Order By job.DocDate.Year, job.DocDate.Month
                                     Group By JobYear = job.DocDate.Year, JobMonth = job.DocDate.Month
                                     Into DataSource = Group, JobCountIM = Count(job.JobType = 1), JobCountEX = Count(job.JobType <> 1)
                                     Order By JobYear, JobMonth
                    ViewBag.JobCountMonthly = oJobFilter.ToList()
                Case "V"
                    Dim oVend = New CVender(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oVenCode = If(oVend.Count > 0, oVend(0).VenCode, "")
                    Dim oJob = New CJobOrder(ViewBag.JobConn).GetData(sqlw & String.Format(" (AgentCode='{0}' OR ForwarderCode='{0}')", oVenCode))
                    Dim oJobFilter = From job In oJob
                                     Order By job.DocDate.Year, job.DocDate.Month
                                     Group By JobYear = job.DocDate.Year, JobMonth = job.DocDate.Month
                                     Into DataSource = Group, JobCountIM = Count(job.JobType = 1), JobCountEX = Count(job.JobType <> 1)
                                     Order By JobYear, JobMonth
                    ViewBag.JobCountMonthly = oJobFilter.ToList()
            End Select
        End Sub
        Sub PopulateJobLoadingMonthly(sqlw As String, dateWhere As String, atDate As String)
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
        Sub PopulateCashMonthly(atDate As String)
            Dim atYear = Convert.ToDateTime(atDate).Year

            Dim oAdvHdr = New CAdvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocStatus<>99 AND Year(PayChqDate)={0} ", atYear))
            Dim oAdvDtl = From d In New CAdvDetail(ViewBag.JobConn).GetData(" WHERE AdvNo NOT IN(select AdvNo from Job_AdvHeader where DocStatus=99)")
                          Join h In oAdvHdr On String.Concat(d.BranchCode, d.AdvNo) Equals String.Concat(h.BranchCode, h.AdvNo)
                          Group By DueYear = h.PayChqDate.Year, DueMonth = h.PayChqDate.Month
                            Into SumExpense = Sum(d.AdvNet + d.Charge50Tavi), SumReceive = Sum(0)
                          Order By DueYear, DueMonth

            Dim oInvHdr = New CInvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE Year(DueDate)={0} AND NOT CancelProve<>''", atYear))
            Dim oInvDtl = From d In New CInvDetail(ViewBag.JobConn).GetData(" WHERE DocNo NOT IN(SELECT DocNo from Job_InvoiceHeader WHERE DueDate is null OR CancelProve<>'')")
                          Join h In oInvHdr On String.Concat(d.BranchCode, d.DocNo) Equals String.Concat(h.BranchCode, h.DocNo)
                          Where h.CancelProve.ToString() = ""
                          Group By DueYear = h.DueDate.Year, DueMonth = h.DueDate.Month
                              Into SumExpense = Sum(0), SumReceive = Sum(d.TotalAmt + d.Amt50Tavi)
                          Order By DueYear, DueMonth

            ViewBag.SumInvDueMonthly = oInvDtl.ToList()
            ViewBag.SumPayDueMonthly = oAdvDtl.ToList()
            Dim sumDue As List(Of DuePaymentMonthly) = New List(Of DuePaymentMonthly)
            For Each d In oInvDtl.ToList()
                Dim o As New DuePaymentMonthly
                o.DueYear = d.DueYear
                o.DueMonth = d.DueMonth
                o.SumExpense = d.SumExpense
                o.SumReceive = d.SumReceive
                sumDue.Add(o)
            Next
            For Each d In oAdvDtl.ToList()
                Dim o As New DuePaymentMonthly
                o.DueYear = d.DueYear
                o.DueMonth = d.DueMonth
                o.SumExpense = d.SumExpense
                o.SumReceive = d.SumReceive
                sumDue.Add(o)
            Next
            ViewBag.SumCashMonthly = (From o In sumDue
                                      Group By o.DueYear, o.DueMonth
                                       Into TotalExpense = Sum(o.SumExpense), TotalReceive = Sum(o.SumReceive)
                                      Order By DueYear, DueMonth).ToList()
        End Sub
        Sub PopulateCashDaily(atDate As String)
            Dim oAdvHdr = New CAdvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocStatus<>99 AND PayChqDate='{0}'", atDate))
            Dim oAdvDtl = From d In New CAdvDetail(ViewBag.JobConn).GetData(" WHERE AdvNo NOT IN(select AdvNo from Job_AdvHeader where DocStatus=99)")
                          Join h In oAdvHdr On String.Concat(d.BranchCode, d.AdvNo) Equals String.Concat(h.BranchCode, h.AdvNo)
                          Group By DueDate = h.PayChqDate
                            Into SumExpense = Sum(d.AdvNet + d.Charge50Tavi), SumReceive = Sum(0)
                          Order By DueDate

            Dim oAdvVend = From d In New CAdvDetail(ViewBag.JobConn).GetData(" WHERE AdvNo NOT IN(select AdvNo from Job_AdvHeader where DocStatus=99)")
                           Join h In oAdvHdr On String.Concat(d.BranchCode, d.AdvNo) Equals String.Concat(h.BranchCode, h.AdvNo)
                           Join v In New CVender(ViewBag.JobConn).GetData("") On d.VenCode Equals v.VenCode
                           Group By VenderName = v.TName
                                Into DataSource = Group, SumExpense = Sum(d.AdvNet + d.Charge50Tavi)
                           Order By VenderName
            ViewBag.SumVendDaily = oAdvVend

            Dim oInvHdr = New CInvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DueDate='{0}' AND NOT CancelProve<>''", atDate))
            Dim oInvDtl = From d In New CInvDetail(ViewBag.JobConn).GetData(" WHERE DocNo NOT IN(SELECT DocNo from Job_InvoiceHeader WHERE DueDate is null OR CancelProve<>'')")
                          Join h In oInvHdr On String.Concat(d.BranchCode, d.DocNo) Equals String.Concat(h.BranchCode, h.DocNo)
                          Group By h.DueDate
                              Into SumExpense = Sum(0), SumReceive = Sum(d.TotalAmt + d.Amt50Tavi)
                          Order By DueDate

            Dim oInvCust = From d In New CInvDetail(ViewBag.JobConn).GetData(" WHERE DocNo NOT IN(SELECT DocNo from Job_InvoiceHeader WHERE DueDate is null OR CancelProve<>'')")
                           Join h In oInvHdr On String.Concat(d.BranchCode, d.DocNo) Equals String.Concat(h.BranchCode, h.DocNo)
                           Join c In New CCompany(ViewBag.JobConn).GetData("") On String.Concat(h.BillToCustCode, h.BillToCustBranch) Equals String.Concat(c.CustCode, c.Branch)
                           Group By CustName = c.NameThai
                               Into DataSource = Group, SumReceive = Sum(d.TotalAmt + d.Amt50Tavi)
                           Order By CustName

            ViewBag.SumCustDaily = oInvCust

            Dim sumDue As List(Of DuePaymentSummary) = New List(Of DuePaymentSummary)
            For Each d In oInvDtl.ToList()
                Dim o As New DuePaymentSummary
                o.DueDate = d.DueDate
                o.SumExpense = d.SumExpense
                o.SumReceive = d.SumReceive
                sumDue.Add(o)
            Next
            For Each d In oAdvDtl.ToList()
                Dim o As New DuePaymentSummary
                o.DueDate = d.DueDate
                o.SumExpense = d.SumExpense
                o.SumReceive = d.SumReceive
                sumDue.Add(o)
            Next
            ViewBag.SumCashDaily = (From o In sumDue
                                    Group By o.DueDate
                                       Into TotalExpense = Sum(o.SumExpense), TotalReceive = Sum(o.SumReceive)
                                    Order By DueDate).ToList()
        End Sub
        Sub PopulateCashWeekly(atDate As String)
            Dim oAdvHdr = New CAdvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocStatus<>99 AND PayChqDate>='{0}' AND PayChqDate<=DATEADD(day,7,'{0}')", atDate))
            Dim oAdvDtl = From d In New CAdvDetail(ViewBag.JobConn).GetData(" WHERE AdvNo NOT IN(select AdvNo from Job_AdvHeader where DocStatus=99)")
                          Join h In oAdvHdr On String.Concat(d.BranchCode, d.AdvNo) Equals String.Concat(h.BranchCode, h.AdvNo)
                          Group By DueDate = h.PayChqDate
                            Into SumExpense = Sum(d.AdvNet + d.Charge50Tavi), SumReceive = Sum(0)
                          Order By DueDate

            Dim oInvHdr = New CInvHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DueDate>='{0}' AND DueDate<=DATEADD(day,7,'{0}') AND NOT CancelProve<>''", atDate))
            Dim oInvDtl = From d In New CInvDetail(ViewBag.JobConn).GetData(" WHERE DocNo NOT IN(SELECT DocNo from Job_InvoiceHeader WHERE DueDate is null OR CancelProve<>'')")
                          Join h In oInvHdr On String.Concat(d.BranchCode, d.DocNo) Equals String.Concat(h.BranchCode, h.DocNo)
                          Where h.CancelProve.ToString() = ""
                          Group By h.DueDate
                              Into SumExpense = Sum(0), SumReceive = Sum(d.TotalAmt + d.Amt50Tavi)
                          Order By DueDate

            ViewBag.SumInvDueWeekly = oInvDtl.ToList()
            ViewBag.SumPayDueWeekly = oAdvDtl.ToList()
            Dim sumDue As List(Of DuePaymentSummary) = New List(Of DuePaymentSummary)
            For Each d In oInvDtl.ToList()
                Dim o As New DuePaymentSummary
                o.DueDate = d.DueDate
                o.SumExpense = d.SumExpense
                o.SumReceive = d.SumReceive
                sumDue.Add(o)
            Next
            For Each d In oAdvDtl.ToList()
                Dim o As New DuePaymentSummary
                o.DueDate = d.DueDate
                o.SumExpense = d.SumExpense
                o.SumReceive = d.SumReceive
                sumDue.Add(o)
            Next
            ViewBag.SumCashWeekly = (From o In sumDue
                                     Group By o.DueDate
                                       Into TotalExpense = Sum(o.SumExpense), TotalReceive = Sum(o.SumReceive)
                                     Order By DueDate).ToList()
        End Sub
        Sub PopulateReceivablesDaily(atDate As String)
            Dim oBillHdr = New CBillHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DuePaymentDate='{0}' AND NOT CancelProve<>''", atDate))
            Dim oBillHdrMonth = New CBillHeader(ViewBag.JobConn).GetData(String.Format(" WHERE Year(DuePaymentDate)={0} AND Month(DuePaymentDate)={1} AND NOT CancelProve<>''", Convert.ToDateTime(atDate).Year, Convert.ToDateTime(atDate).Month))
            Dim oBillDtl = New CBillDetail(ViewBag.JobConn).GetData(" WHERE BillAcceptNo not in(select BillAcceptNo from Job_BillAcceptHeader where CancelProve<>'')")
            Dim oBillAll = From h In oBillHdr
                           Join d In oBillDtl
                              On String.Concat(h.BranchCode, h.BillAcceptNo) Equals String.Concat(d.BranchCode, d.BillAcceptNo)
                           Join c In New CCompany(ViewBag.JobConn).GetData("")
                               On String.Concat(h.CustCode, h.CustBranch) Equals String.Concat(c.CustCode, c.Branch)
                           Group By CustName = c.NameThai
                               Into DataSource = Group, TotalInvoice = Sum(d.AmtTotal + d.AmtWH)

            Dim oBillMonth = From h In oBillHdrMonth
                             Join d In oBillDtl
                              On String.Concat(h.BranchCode, h.BillAcceptNo) Equals String.Concat(d.BranchCode, d.BillAcceptNo)
                             Join c In New CCompany(ViewBag.JobConn).GetData("")
                               On String.Concat(h.CustCode, h.CustBranch) Equals String.Concat(c.CustCode, c.Branch)
                             Group By CustName = c.NameThai
                               Into DataSource = Group, TotalInvoice = Sum(d.AmtTotal + d.AmtWH)

            ViewBag.ARToday = oBillAll.ToList()
            ViewBag.ARMonth = oBillMonth.ToList()
        End Sub
        Sub PopulateReceivablesWeekly(atDate As String)
            Dim oBillHdrLastWeek = New CBillHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DuePaymentDate>=DATEADD(day,-7,'{0}') AND DuePaymentDate<'{0}' AND NOT CancelProve<>''", atDate))
            Dim oBillHdrNextWeek = New CBillHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DuePaymentDate>'{0}' AND DuePaymentDate<=DATEADD(day,7,'{0}') AND NOT CancelProve<>''", atDate))
            Dim oBillDtl = New CBillDetail(ViewBag.JobConn).GetData(" WHERE BillAcceptNo not in(select BillAcceptNo from Job_BillAcceptHeader WHERE CancelProve<>'')")
            Dim oBillLastWeek = From h In oBillHdrLastWeek
                                Join d In oBillDtl
                              On String.Concat(h.BranchCode, h.BillAcceptNo) Equals String.Concat(d.BranchCode, d.BillAcceptNo)
                                Group By DueDate = h.DuePaymentDate
                               Into DataSource = Group, TotalInvoice = Sum(d.AmtTotal + d.AmtWH)
            Dim oBillNextWeek = From h In oBillHdrNextWeek
                                Join d In oBillDtl
                              On String.Concat(h.BranchCode, h.BillAcceptNo) Equals String.Concat(d.BranchCode, d.BillAcceptNo)
                                Group By DueDate = h.DuePaymentDate
                              Into DataSource = Group, TotalInvoice = Sum(d.AmtTotal + d.AmtWH)
            ViewBag.ARLastWeek = oBillLastWeek.ToList()
            ViewBag.ARNextWeek = oBillNextWeek.ToList()
        End Sub
        Sub PopulatePayablesDaily(atDate As String)
            Dim oPayHdr = New CPayHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocDate='{0}' AND NOT CancelProve<>''", atDate))
            Dim oPayHdrMonth = New CPayHeader(ViewBag.JobConn).GetData(String.Format(" WHERE Year(DocDate)={0} AND Month(DocDate)={1} AND NOT CancelProve<>''", Convert.ToDateTime(atDate).Year, Convert.ToDateTime(atDate).Month))
            Dim oPayDtl = New CPayDetail(ViewBag.JobConn).GetData(" WHERE DocNo not in(select DocNo from Job_PaymentHeader WHERE CancelProve<>'')")
            Dim oPayAll = From h In oPayHdr
                          Join d In oPayDtl
                              On String.Concat(h.BranchCode, h.DocNo) Equals String.Concat(d.BranchCode, d.DocNo)
                          Join v In New CVender(ViewBag.JobConn).GetData("")
                              On h.VenCode Equals v.VenCode
                          Group By VenderName = v.TName
                              Into DataSource = Group, TotalPayment = Sum(d.Total + d.AmtWHT)

            Dim oPayMonth = From h In oPayHdrMonth
                            Join d In oPayDtl
                              On String.Concat(h.BranchCode, h.DocNo) Equals String.Concat(d.BranchCode, d.DocNo)
                            Join v In New CVender(ViewBag.JobConn).GetData("")
                              On h.VenCode Equals v.VenCode
                            Group By VenderName = v.TName
                              Into DataSource = Group, TotalPayment = Sum(d.Total + d.AmtWHT)
            ViewBag.APToday = oPayAll.ToList()
            ViewBag.APMonth = oPayMonth.ToList()
        End Sub
        Sub PopulatePayablesWeekly(atDate As String)
            Dim oPayHdrLastWeek = New CPayHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocDate>=DATEADD(day,-7,'{0}') AND DocDate<'{0}' AND NOT CancelProve<>''", atDate))
            Dim oPayHdrNextWeek = New CPayHeader(ViewBag.JobConn).GetData(String.Format(" WHERE DocDate>'{0}' AND DocDate<=DATEADD(day,7,'{0}') AND NOT CancelProve<>''", atDate))
            Dim oPayDtl = New CPayDetail(ViewBag.JobConn).GetData(" WHERE DocNo not in(select DocNo from Job_PaymentHeader WHERE CancelProve<>'')")
            Dim oPayLastWeek = From h In oPayHdrLastWeek
                               Join d In oPayDtl
                              On String.Concat(h.BranchCode, h.DocNo) Equals String.Concat(d.BranchCode, d.DocNo)
                               Group By DueDate = h.DocDate
                               Into DataSource = Group, TotalPayment = Sum(d.Total + d.AmtWHT)
            Dim oPayNextWeek = From h In oPayHdrNextWeek
                               Join d In oPayDtl
                              On String.Concat(h.BranchCode, h.DocNo) Equals String.Concat(d.BranchCode, d.DocNo)
                               Group By DueDate = h.DocDate
                              Into DataSource = Group, TotalPayment = Sum(d.Total + d.AmtWHT)
            ViewBag.APLastWeek = oPayLastWeek.ToList()
            ViewBag.APNextWeek = oPayNextWeek.ToList()
        End Sub
#End Region 'Populate Data Functions
    End Class

    Public Class DuePaymentSummary
        Public DueDate As DateTime
        Public SumExpense As Double
        Public SumReceive As Double
    End Class
    Public Class DuePaymentMonthly
        Public DueYear As Integer
        Public DueMonth As Integer
        Public SumExpense As Double
        Public SumReceive As Double
    End Class
End Namespace