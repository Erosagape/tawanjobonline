Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class AccController
        Inherits CController
        ' GET: Acc
        Function Index() As ActionResult
            LoadCompanyProfile()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
            If AuthorizeStr.IndexOf("M") < 0 Then
                ViewBag.Module = "Voucher Lists"
                Return RedirectToAction("AuthError", "Menu")
            End If
            Return View()
        End Function
        '-----Controller-----
        Function Advance() As ActionResult
            LoadCompanyProfile()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
            If AuthorizeStr.IndexOf("M") < 0 Then
                ViewBag.Module = "Advance"
                Return RedirectToAction("AuthError", "Menu")
            End If
            Return View()
        End Function
        Function Clearing() As ActionResult
            LoadCompanyProfile()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
            If AuthorizeStr.IndexOf("M") < 0 Then
                ViewBag.Module = "Clearing"
                Return RedirectToAction("AuthError", "Menu")
            End If
            Return View()
        End Function
        Function Voucher() As ActionResult
            Return GetView("Voucher", "MODULE_ACC")
        End Function
        Function WHTax() As ActionResult
            Return GetView("WHTax", "MODULE_ACC")
        End Function
        Function Tax50Tavi() As ActionResult
            LoadCompanyProfile()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
            If AuthorizeStr.IndexOf("M") < 0 Then
                ViewBag.Module = "WH-Tax"
                Return RedirectToAction("AuthError", "Menu")
            End If
            Return View()
        End Function
        Function FormCheque() As ActionResult
            Return GetView("FormCheque")
        End Function

        Function FormPettyCash() As ActionResult
            Return GetView("FormPettyCash")
        End Function
        Function FormWTax3() As ActionResult
            Dim vw = GetView("FormWTax3")
            ViewBag.TaxAuthorize = GetValueConfig("PRD", "AUTHOR_NAME", "..............................................................................................")
            ViewBag.TaxPosition = GetValueConfig("PRD", "AUTHOR_POSITION", ".....................................................................................")
            ViewBag.TaxIssueDate = DateTime.Today.Day.ToString("00") & "/" & GetMonthThai(DateTime.Today.Month) & "/" & DateTime.Today.Year + 543
            Return vw
        End Function
        Function FormWTax53() As ActionResult
            Dim vw = GetView("FormWTax53")
            ViewBag.TaxAuthorize = GetValueConfig("PRD", "AUTHOR_NAME", "..............................................................................................")
            ViewBag.TaxPosition = GetValueConfig("PRD", "AUTHOR_POSITION", ".....................................................................................")
            ViewBag.TaxIssueDate = DateTime.Today.Day.ToString("00") & "/" & GetMonthThai(DateTime.Today.Month) & "/" & DateTime.Today.Year + 543
            Return vw
        End Function
        Function FormWTax3D() As ActionResult
            Dim vw = GetView("FormWTax3D")
            ViewBag.TaxAuthorize = GetValueConfig("PRD", "AUTHOR_NAME", "..............................................................................................")
            ViewBag.TaxPosition = GetValueConfig("PRD", "AUTHOR_POSITION", ".....................................................................................")
            ViewBag.TaxIssueDate = DateTime.Today.Day.ToString("00") & "/" & GetMonthThai(DateTime.Today.Month) & "/" & DateTime.Today.Year + 543
            Return vw
        End Function
        Function FormWTax53D() As ActionResult
            Dim vw = GetView("FormWTax53D")
            ViewBag.TaxAuthorize = GetValueConfig("PRD", "AUTHOR_NAME", "..............................................................................................")
            ViewBag.TaxPosition = GetValueConfig("PRD", "AUTHOR_POSITION", ".....................................................................................")
            ViewBag.TaxIssueDate = DateTime.Today.Day.ToString("00") & "/" & GetMonthThai(DateTime.Today.Month) & "/" & DateTime.Today.Year + 543
            Return vw
        End Function
        Function Approve() As ActionResult
            Return GetView("Approve", "MODULE_ACC")
        End Function
        Function ApprovePettyCash(<FromBody()> data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "PettyCash")
                If AuthorizeStr.IndexOf("I") < 0 Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If

                Dim poNumber = ""
                If Request.QueryString("ID") IsNot Nothing Then
                    poNumber = Request.QueryString("ID").ToString()
                End If

                If IsNothing(data) Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If

                Dim json As String = ""
                Dim lst As String = ""
                Dim user As String = ""
                For Each str As String In data
                    If str.IndexOf("|") >= 0 Then
                        If lst <> "" Then lst &= ","
                        lst &= "'" & str & "'"
                    Else
                        user = str
                    End If
                Next

                If lst <> "" Then
                    Dim tSQL As String = ""
                    If poNumber <> "" Then
                        tSQL = String.Format("UPDATE Job_CashControl SET PostRefNo='" & poNumber & "',PostedDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',PostedTime='" & DateTime.Now.ToString("HH:mm:ss") & "'  WHERE BranchCode+'|'+ControlNo in({0}) AND NOT ISNULL(CancelProve,'')<>''", lst)
                    Else
                        Dim fmt = Main.GetValueConfig("RUNNING", "APP_PETTYCASH")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", DateTime.Today.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", DateTime.Today.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", DateTime.Today.ToString("yy"))
                            End If
                        Else
                            fmt = DateTime.Today.ToString("yyMM") & "____"
                        End If
                        Dim pFormat = Main.GetValueConfig("RUNNING_FORMAT", "APP_PETTYCASH") & fmt
                        Dim sqlApp = String.Format("SELECT MAX(PostRefNo) as t FROM Job_CashControl WHERE PostRefNo Like '%{0}' ", pFormat)
                        Dim appRef = Main.GetMaxByMask(GetSession("ConnJob"), sqlApp, pFormat)
                        tSQL = String.Format("UPDATE Job_CashControl SET PostRefNo='" & appRef & "',PostedBy='" & user & "',PostedDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',PostedTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE BranchCode+'|'+ControlNo in({0}) AND ISNULL(PostRefNo,'')='' AND NOT ISNULL(CancelProve,'')<>'' ", lst)

                    End If
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            Catch ex As Exception
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End Try
        End Function
        Function ApproveExpense(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                Dim poNumber = ""
                Dim vencode = ""
                If Request.QueryString("Code") IsNot Nothing Then
                    vencode = Request.QueryString("Code").ToString()
                End If
                If Request.QueryString("ID") IsNot Nothing Then
                    poNumber = Request.QueryString("ID").ToString()
                Else
                    ViewBag.User = GetSession("CurrUser").ToString()
                    Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Payment")
                    If AuthorizeStr.IndexOf("I") < 0 Then
                        Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                    End If
                End If

                If IsNothing(data) Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If

                Dim json As String = ""
                Dim lst As String = ""
                Dim user As String = ""
                For Each str As String In data
                    If str.IndexOf("|") >= 0 Then
                        If lst <> "" Then lst &= ","
                        lst &= "'" & str & "'"
                    Else
                        user = str
                    End If
                Next

                If lst <> "" Then
                    Dim tSQL As String = ""
                    If poNumber <> "" Then
                        tSQL = String.Format("UPDATE Job_PaymentHeader SET PoNo='" & poNumber & "' WHERE BranchCode+'|'+DocNo in({0}) AND NOT ISNULL(CancelProve,'')<>'' ", lst)
                        Main.DBExecute(GetSession("ConnJob"), tSQL)
                    End If
                    Dim fmt = Main.GetValueConfig("RUNNING", "APP_PAY")
                    If fmt <> "" Then
                        If fmt.IndexOf("bb") >= 0 Then
                            fmt = fmt.Replace("bb", DateTime.Today.AddYears(543).ToString("yy"))
                        End If
                        If fmt.IndexOf("MM") >= 0 Then
                            fmt = fmt.Replace("MM", DateTime.Today.ToString("MM"))
                        End If
                        If fmt.IndexOf("yy") >= 0 Then
                            fmt = fmt.Replace("yy", DateTime.Today.ToString("yy"))
                        End If
                    Else
                        fmt = DateTime.Today.ToString("yyMM") & "____"
                    End If
                    Dim pFormat = Main.GetValueConfig("RUNNING_FORMAT", "APP_PAY") & fmt
                    If pFormat.IndexOf("[VEN]") >= 0 Then
                        pFormat = pFormat.Replace("[VEN]", vencode)
                    End If
                    Dim sqlApp = String.Format("SELECT MAX(ApproveRef) as t FROM Job_PaymentHeader WHERE ApproveRef Like '%{0}' ", pFormat)
                    Dim appRef = Main.GetMaxByMask(GetSession("ConnJob"), sqlApp, pFormat)
                    tSQL = String.Format("UPDATE Job_PaymentHeader SET ApproveRef='" & appRef & "',ApproveBy='" & user & "',ApproveDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',ApproveTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE BranchCode+'|'+DocNo in({0}) AND ISNULL(ApproveRef,'')='' AND NOT ISNULL(CancelProve,'')<>''", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            Catch ex As Exception
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End Try
        End Function
        Function Payment() As ActionResult
            Return GetView("Payment", "MODULE_ACC")
        End Function
        Function GetPaymentForAdv() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("VenCode")) Then
                    tSqlw &= String.Format(" AND VenCode='{0}' ", Request.QueryString("VenCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlw &= String.Format(" AND CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    Select Case Request.QueryString("Status").ToString
                        Case "N"
                            tSqlw &= " AND ISNULL(ApproveRef,'')='' AND ISNULL(PaymentRef,'')='' "
                        Case "A"
                            tSqlw &= " AND NOT ISNULL(ApproveRef,'')='' AND ISNULL(PaymentRef,'')='' "
                        Case "P"
                            tSqlw &= " AND NOT ISNULL(PaymentRef,'')='' "
                    End Select
                End If
                Dim oData = New CPayHeader(GetSession("ConnJob")).GetData(tSqlw & " AND NOT ISNULL(AdvRef,'')<>''")
                Dim json As String = JsonConvert.SerializeObject(oData)
                Dim oDataD = New CPayDetail(GetSession("ConnJob")).GetData(" WHERE DocNo IN(SELECT DocNo FROM Job_PaymentHeader " & tSqlw & ") AND AdvItemNo=0 ")
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)

                json = "{""payment"":{""header"":" & json & ",""detail"":" & jsonD & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPayment", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetPettyCashList() As ActionResult
            Try
                Dim tSqlH As String = " WHERE ISNULL(PostRefNo,'')<>'' AND ISNULL(CancelProve,'')='' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlH &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlH &= String.Format(" AND ControlNo IN(SELECT ControlNo FROM Job_CashControlSub WHERE BookCode='{0}')", Request.QueryString("Code").ToString)
                End If

                Dim oData = (From row As CVoucher
                                 In New CVoucher(GetSession("ConnJob")).GetData(tSqlH)
                             Select row.PostRefNo, row.PostedDate).Distinct()

                Dim json As String = JsonConvert.SerializeObject(oData)

                json = "{""pettycash"":{""header"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPettyCashList", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetPaymentApprove() As ActionResult
            Try
                Dim tSqlH As String = " WHERE DocNo<>'' "
                Dim tSqlD As String = tSqlH
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlH &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                    tSqlD = tSqlH
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlH &= String.Format(" AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                    tSqlD = tSqlH
                End If
                If Not IsNothing(Request.QueryString("VenCode")) Then
                    tSqlH &= String.Format(" AND VenCode='{0}' ", Request.QueryString("VenCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("Ref")) Then
                    tSqlH &= String.Format(" AND RefNo='{0}' ", Request.QueryString("Ref").ToString)
                End If
                If Not IsNothing(Request.QueryString("Po")) Then
                    tSqlH &= String.Format(" AND PoNo='{0}' ", Request.QueryString("Po").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlH &= String.Format(" AND CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlH &= " AND DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlH &= " AND DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString = "NOPAY" Then
                        tSqlH &= String.Format(" AND NOT (DocNo IN(SELECT p.DocNo FROM (
SELECT h.DocNo FROM 
Job_CashControlDoc h INNER JOIN Job_CashControlSub d ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType 
INNER JOIN Job_CashControl m ON h.BranchCode=m.BranchCode AND h.ControlNo=m.ControlNo 
WHERE h.DocType='PAY' AND d.PRType='P' AND h.BranchCode='{0}' AND ISNULL(m.CancelProve,'')=''
) p)", Request.QueryString("Branch").ToString)
                        tSqlH &= String.Format(" OR DocNo IN(SELECT DISTINCT p.PaymentNo FROM (SELECT h.PaymentNo FROM Job_AdvHeader h WHERE h.DocStatus<>99 AND h.BranchCode='{0}') p WHERE p.PaymentNo IS NOT NULL))", Request.QueryString("Branch").ToString)
                    End If
                    If Request.QueryString("Type").ToString = "NOPO" Then
                        tSqlH &= " AND ISNULL(PoNo,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "NOAPP" Then
                        tSqlH &= " AND ISNULL(ApproveRef,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "APP" Then
                        tSqlH &= " AND NOT ISNULL(ApproveRef,'')='' "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    If Request.QueryString("Status").ToString = "A" Then
                        tSqlH &= " AND ISNULL(ApproveBy,'')<>'' "
                    End If
                    If Request.QueryString("Status").ToString = "R" Then
                        tSqlH &= " AND ISNULL(ApproveBy,'')='' "
                    End If
                    If Request.QueryString("Status").ToString = "N" Then
                        tSqlH &= " AND ISNULL(CancelProve,'')<>'' "
                    Else
                        tSqlH &= " AND NOT ISNULL(CancelProve,'')<>'' "
                    End If
                End If
                Dim oData = (From row As CPayHeader
                                 In New CPayHeader(GetSession("ConnJob")).GetData(tSqlH)
                             Select row.ApproveRef, row.PoNo, row.PaymentRef).Distinct()

                Dim json As String = JsonConvert.SerializeObject(oData)

                json = "{""payment"":{""header"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPayment", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetPayment() As ActionResult
            Try
                Dim tSqlH As String = " WHERE DocNo<>'' "
                Dim tSqlD As String = tSqlH
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlH &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                    tSqlD = tSqlH
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlH &= String.Format(" AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                    tSqlD = tSqlH
                End If
                If Not IsNothing(Request.QueryString("VenCode")) Then
                    tSqlH &= String.Format(" AND VenCode='{0}' ", Request.QueryString("VenCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("Ref")) Then
                    tSqlH &= String.Format(" AND RefNo='{0}' ", Request.QueryString("Ref").ToString)
                End If
                If Not IsNothing(Request.QueryString("Po")) Then
                    tSqlH &= String.Format(" AND PoNo='{0}' ", Request.QueryString("Po").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlH &= String.Format(" AND DocNo IN(SELECT DocNo FROM Job_PaymentDetail WHERE ForJNo='{0}') ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlH &= String.Format(" AND CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlH &= " AND DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlH &= " AND DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString = "NOPAY" Then
                        tSqlH &= String.Format(" AND NOT (DocNo IN(SELECT p.DocNo FROM (
SELECT h.DocNo FROM 
Job_CashControlDoc h INNER JOIN Job_CashControlSub d ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType 
INNER JOIN Job_CashControl m ON h.BranchCode=m.BranchCode AND h.ControlNo=m.ControlNo 
WHERE h.DocType='PAY' AND d.PRType='P' AND h.BranchCode='{0}' AND ISNULL(m.CancelProve,'')=''
) p)", Request.QueryString("Branch").ToString)
                        tSqlH &= String.Format(" OR DocNo IN(SELECT DISTINCT p.PaymentNo FROM (SELECT h.PaymentNo FROM Job_AdvHeader h WHERE h.DocStatus<>99 AND h.BranchCode='{0}') p WHERE p.PaymentNo IS NOT NULL))", Request.QueryString("Branch").ToString)
                    End If
                    If Request.QueryString("Type").ToString = "NOPO" Then
                        tSqlH &= " AND ISNULL(PoNo,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "NOAPP" Then
                        tSqlH &= " AND ISNULL(ApproveRef,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "APP" Then
                        tSqlH &= " AND NOT ISNULL(ApproveRef,'')='' "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    If Request.QueryString("Status").ToString = "A" Then
                        tSqlH &= " AND ISNULL(ApproveBy,'')<>'' "
                    End If
                    If Request.QueryString("Status").ToString = "R" Then
                        tSqlH &= " AND ISNULL(ApproveBy,'')='' "
                    End If
                    If Request.QueryString("Status").ToString = "N" Then
                        tSqlH &= " AND ISNULL(CancelProve,'')<>'' "
                    Else
                        tSqlH &= " AND NOT ISNULL(CancelProve,'')<>'' "
                    End If
                End If
                Dim oData = New CPayHeader(GetSession("ConnJob")).GetData(tSqlH)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Dim oDataD = New CPayDetail(GetSession("ConnJob")).GetData(tSqlD & " AND DocNo IN(SELECT DocNo FROM Job_PaymentHeader " & tSqlH & " )")
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)

                json = "{""payment"":{""header"":" & json & ",""detail"":" & jsonD & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPayment", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetPaymentRef() As ActionResult
            Dim appref = ""
            If Not IsNothing(Request.QueryString("AppRef")) Then
                appref = Request.QueryString("AppRef").ToString
            End If
            Dim payref = ""
            If Not IsNothing(Request.QueryString("PayRef")) Then
                payref = Request.QueryString("PayRef").ToString
            End If
            If appref = "" Or payref = "" Then
                Return Content("Cannot approve", textContent)
            Else
                Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_PaymentHeader SET PaymentRef='{1}' WHERE ApproveRef='{0}' ", appref, payref))
                Return Content("Approve Complete", textContent)
            End If
        End Function
        Function GetVenderReport() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.ApproveRef='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("No")) Then
                    tSqlw &= String.Format(" AND h.PoNo='{0}' ", Request.QueryString("No").ToString)
                End If
                If Not IsNothing(Request.QueryString("VenCode")) Then
                    tSqlw &= String.Format(" AND h.VenCode='{0}' ", Request.QueryString("VenCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("PayType")) Then
                    tSqlw &= String.Format(" AND h.PayType='{0}' ", Request.QueryString("PayType").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlw &= String.Format(" AND h.CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND h.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND h.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString = "NOPAY" Then
                        tSqlw &= String.Format(" AND NOT (h.DocNo IN(SELECT p.DocNo FROM (
SELECT h.DocNo FROM 
Job_CashControlDoc h INNER JOIN Job_CashControlSub d ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType 
INNER JOIN Job_CashControl m ON h.BranchCode=m.BranchCode AND h.ControlNo=m.ControlNo 
WHERE h.DocType='PAY' AND d.PRType='P' AND h.BranchCode='{0}' AND ISNULL(m.CancelProve,'')=''
) p)", Request.QueryString("Branch").ToString)
                        tSqlw &= " OR ISNULL(h.AdvRef,'')<>'')"
                        tSqlw &= " AND ISNULL(h.ApproveBy,'')<>'' "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "ACTIVE" Then
                        tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlw &= " AND ISNULL(h.CancelProve,'')<>'' "
                    End If
                End If
                Dim sqlSub = "
SELECT d.SICode,s.IsExpense,Max(d.SDescription) as Description 
FROM Job_PaymentHeader h INNER JOIN Job_PaymentDetail d 
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo 
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode 
WHERE NOT ISNULL(h.CancelProve,'')<>'' 
"
                sqlSub &= tSqlw & " GROUP BY d.SICode,s.IsExpense ORDER BY s.IsExpense DESC,d.SICode"
                Dim fldSub = ""
                Dim oSub = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlSub)
                If oSub.Rows.Count > 0 Then
                    For Each dr As DataRow In oSub.Rows
                        fldSub &= ","
                        fldSub &= "SUM(CASE WHEN d.SICode='" & dr("SICode").ToString & "' THEN d.Amt+d.AmtVAT ELSE 0 END) as '" & dr("Description").ToString & "'"
                    Next
                End If
                Dim sqlM = SQLSelectVenderReport(tSqlw, fldSub)
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlM)
                Dim json = JsonConvert.SerializeObject(oData)
                Return Content("{""payment"":{""data"":" & json & ",""msg"":""" & oData.Rows.Count & """}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPaymentGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""payment"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetPaymentSummary() As ActionResult
            Try
                Dim tSqlw As String = " WHERE h.DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.DocNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlw &= String.Format(" AND h.CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("VenCode")) Then
                    tSqlw &= String.Format(" AND h.VenCode='{0}' ", Request.QueryString("VenCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("PayType")) Then
                    tSqlw &= String.Format(" AND h.PayType='{0}' ", Request.QueryString("PayType").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlw &= String.Format(" AND h.CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND h.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND h.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString = "NOPAY" Then
                        tSqlw &= String.Format(" AND NOT (h.DocNo IN(SELECT p.DocNo FROM (
SELECT h.DocNo FROM 
Job_CashControlDoc h INNER JOIN Job_CashControlSub d ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType 
INNER JOIN Job_CashControl m ON h.BranchCode=m.BranchCode AND h.ControlNo=m.ControlNo 
WHERE h.DocType='PAY' AND d.PRType='P' AND h.BranchCode='{0}' AND ISNULL(m.CancelProve,'')=''
) p)", Request.QueryString("Branch").ToString)
                        tSqlw &= " OR ISNULL(h.AdvRef,'')<>'')"
                        tSqlw &= " AND ISNULL(h.ApproveBy,'')<>'' "
                    End If
                    If Request.QueryString("Type").ToString = "NOPO" Then
                        tSqlw &= " AND ISNULL(h.PoNo,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "BILL" Then
                        tSqlw &= " AND ISNULL(h.PoNo,'')<>'' AND ISNULL(h.ApproveRef,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "NOAPP" Then
                        tSqlw &= " AND ISNULL(h.ApproveRef,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "APP" Then
                        tSqlw &= " AND NOT ISNULL(h.ApproveRef,'')='' "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "ACTIVE" Then
                        tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlw &= " AND ISNULL(h.CancelProve,'')<>'' "
                    End If
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(SQLSelectPaymentSummary(), tSqlw))
                Dim json = JsonConvert.SerializeObject(oData)
                Return Content("{""payment"":{""data"":" & json & ",""msg"":""" & oData.Rows.Count & """}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPaymentGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""payment"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetPaymentReport() As ActionResult
            Dim tSql = Main.GetValueConfig("REPORT_PAYREPORT", "MAIN_SQL")
            Dim tSqlw = ""
            If Not IsNothing(Request.QueryString("Branch")) Then
                tSqlw &= String.Format(" AND h.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("Code")) Then
                tSqlw &= String.Format(" AND h.ApproveRef='{0}' ", Request.QueryString("Code").ToString)
            End If
            Try
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(tSql, tSqlw))
                Dim json = JsonConvert.SerializeObject(oData)
                Return Content("{""payment"":{""data"":" & json & ",""msg"":""" & oData.Rows.Count & """}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPaymentReport", ex.Message, ex.StackTrace, True)
                Return Content("{""payment"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetPaymentGrid() As ActionResult
            Try
                Dim tSqlw As String = SQLSelectPaymentReport() & " WHERE h.DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.DocNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlw &= String.Format(" AND h.CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("VenCode")) Then
                    tSqlw &= String.Format(" AND h.VenCode='{0}' ", Request.QueryString("VenCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("PayType")) Then
                    tSqlw &= String.Format(" AND h.PayType='{0}' ", Request.QueryString("PayType").ToString)
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlw &= String.Format(" AND h.CurrencyCode='{0}' ", Request.QueryString("Currency").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND h.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND h.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString = "NOPAY" Then
                        tSqlw &= String.Format(" AND NOT (h.DocNo IN(SELECT p.DocNo FROM (
SELECT h.DocNo FROM 
Job_CashControlDoc h INNER JOIN Job_CashControlSub d ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType 
INNER JOIN Job_CashControl m ON h.BranchCode=m.BranchCode AND h.ControlNo=m.ControlNo 
WHERE h.DocType='PAY' AND d.PRType='P' AND h.BranchCode='{0}' AND ISNULL(m.CancelProve,'')=''
) p)", Request.QueryString("Branch").ToString)
                        tSqlw &= " OR ISNULL(h.AdvRef,'')<>'')"
                        tSqlw &= " AND ISNULL(h.ApproveBy,'')<>'' "
                    End If
                    If Request.QueryString("Type").ToString = "NOPO" Then
                        tSqlw &= " AND ISNULL(h.PoNo,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "NOAPP" Then
                        tSqlw &= " AND ISNULL(h.ApproveRef,'')='' "
                    End If
                    If Request.QueryString("Type").ToString = "APP" Then
                        tSqlw &= " AND NOT ISNULL(h.ApproveRef,'')='' "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "ACTIVE" Then
                        tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlw &= " AND ISNULL(h.CancelProve,'')<>'' "
                    End If
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSqlw)
                Dim json = JsonConvert.SerializeObject(oData)
                Return Content("{""payment"":{""data"":" & json & ",""msg"":""" & oData.Rows.Count & """}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPaymentGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""payment"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function SetPayHeader(<FromBody()> data As CPayHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.DocNo = "" Then
                        data.AddNew(GetValueConfig("RUNNING_FORMAT", "PAY", payPrefix) & Now.ToString("yyMM") & "-____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetPayHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelPayHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""payment"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""payment"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CPayHeader(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Dim oDataD As New CPayDetail(GetSession("ConnJob"))
                oDataD.DeleteData(tSqlw)

                Dim json = "{""payment"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelPayHeader", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetPayDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                Dim oData = New CPayDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""payment"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPayDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetPayDetail(<FromBody()> data As CPayDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))

                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2} ", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"

                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetPayDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelPayDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                Dim oData As New CPayDetail(GetSession("ConnJob"))
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                    oData.BranchCode = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""payment"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                    oData.DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""payment"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                    oData.ItemNo = Convert.ToInt32(Request.QueryString("Item").ToString)
                Else
                    Return Content("{""payment"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""payment"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelPayDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function FormInv() As ActionResult
            Dim formName As String = ""
            Try
                If Request.QueryString("Form") IsNot Nothing Then
                    formName = Request.QueryString("Form").ToString
                End If
                If Request.QueryString("branch") IsNot Nothing Then
                    If Request.QueryString("code") IsNot Nothing Then
                        Dim oRec = New CInvHeader(GetSession("ConnJob"))
                        Dim sqlw = String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}'", Request.QueryString("branch").ToString, Request.QueryString("code").ToString)
                        Dim oRow = oRec.GetData(sqlw)
                        If oRow.Count > 0 Then
                            oRow(0).PrintedBy = Session("CurrUser").ToString
                            oRow(0).PrintedDate = DateTime.Today
                            oRow(0).PrintedTime = DateTime.Now
                            oRow(0).SaveData(sqlw)
                        End If
                    End If
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "FormInv", ex.Message, ex.StackTrace, True)
            End Try
            Return GetView("FormInv" & formName)
        End Function
        Function FormBill() As ActionResult
            Return GetView("FormBill")
        End Function
        Function FormRcp() As ActionResult
            Dim formName = ""
            Try
                If Request.QueryString("Form") IsNot Nothing Then
                    formName = Request.QueryString("Form").ToString()
                End If
                If Request.QueryString("branch") IsNot Nothing Then
                    If Request.QueryString("code") IsNot Nothing Then
                        Dim oRec = New CRcpHeader(GetSession("ConnJob"))
                        Dim sqlw = String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}'", Request.QueryString("branch").ToString, Request.QueryString("code").ToString)
                        Dim oRow = oRec.GetData(sqlw)
                        If oRow.Count > 0 Then
                            oRow(0).PrintedBy = Session("CurrUser").ToString
                            oRow(0).PrintedDate = DateTime.Today
                            oRow(0).PrintedTime = DateTime.Now
                            oRow(0).SaveData(sqlw)
                        End If
                    End If
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "FormRcp", ex.Message, ex.StackTrace, True)
            End Try
            Return GetView("FormRcp" & formName)
        End Function
        Function FormTaxInv() As ActionResult
            Dim formName = ""
            Try
                If Request.QueryString("Form") IsNot Nothing Then
                    formName = Request.QueryString("Form").ToString()
                End If
                If Request.QueryString("branch") IsNot Nothing Then
                    If Request.QueryString("code") IsNot Nothing Then
                        Dim oRec = New CRcpHeader(GetSession("ConnJob"))
                        Dim sqlw = String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}'", Request.QueryString("branch").ToString, Request.QueryString("code").ToString)
                        Dim oRow = oRec.GetData(sqlw)
                        If oRow.Count > 0 Then
                            oRow(0).PrintedBy = Session("CurrUser").ToString
                            oRow(0).PrintedDate = DateTime.Today
                            oRow(0).PrintedTime = DateTime.Now
                            oRow(0).SaveData(sqlw)
                        End If
                    End If
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "FormTaxInv", ex.Message, ex.StackTrace, True)
            End Try

            Return GetView("FormTaxInv" & formName)
        End Function
        Function FormCreditNote() As ActionResult
            Return GetView("FormCreditNote")
        End Function
        Function FormGL() As ActionResult
            Return GetView("FormGL")
        End Function
        Function Expense() As ActionResult
            Return GetView("Expense", "MODULE_ACC")
        End Function
        Function Invoice() As ActionResult
            Return GetView("Invoice", "MODULE_ACC")
        End Function
        Function Billing() As ActionResult
            Return GetView("Billing", "MODULE_ACC")
        End Function
        Function GenerateBilling() As ActionResult
            Return GetView("GenerateBilling")
        End Function
        Function GenerateReceipt() As ActionResult
            Return GetView("GenerateReceipt")
        End Function
        Function GenerateTaxInv() As ActionResult
            Return GetView("GenerateTaxInv")
        End Function
        Function PettyCash() As ActionResult
            Return GetView("PettyCash", "MODULE_ACC")
        End Function
        Function Cheque() As ActionResult
            Return GetView("Cheque", "MODULE_ACC")
        End Function
        Function Receipt() As ActionResult
            Return GetView("Receipt", "MODULE_ACC")
        End Function
        Function RecvInv() As ActionResult
            Return GetView("RecvInv", "MODULE_ACC")
        End Function
        Function TaxInvoice() As ActionResult
            Return GetView("TaxInvoice", "MODULE_ACC")
        End Function
        Function CreditNote() As ActionResult
            Return GetView("CreditNote", "MODULE_ACC")
        End Function
        Function VenderInv() As ActionResult
            Return GetView("VenderInv")
        End Function
        Function BillPayment() As ActionResult
            Return GetView("BillPayment")
        End Function

        Function GetCNDNDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo ='{0}'", Request.QueryString("Item").ToString)
                End If
                Dim oData = New CCNDNDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""creditnote"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCNDNDetail", ex.Message, ex.StackTrace, True)

                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetCNDNDetail(<FromBody()> data As CCNDNDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If data.ItemNo = 0 Then
                        data.AddNew()
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2} ", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCNDNDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelCNDNDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode Like '{0}'", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""creditnote"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""creditnote"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CCNDNDetail(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""creditnote"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCNDNDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetCNDNGrid() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw = String.Format(" WHERE a.DocStatus IN('{0}') ", Request.QueryString("Status").ToString().Replace(",", "','"))
                Else
                    tSqlw = " WHERE a.DocStatus <>'99' "
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "CN" Then
                        tSqlw &= " AND b.TotalNet>0 "
                    End If
                    If Request.QueryString("Show").ToString = "DN" Then
                        tSqlw &= " AND b.TotalNet<0 "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND a.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND a.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND a.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND a.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(Main.SQLSelectCNDNSummary() & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""creditnote"":{""data"":" & json & ",""msg"":""" & tSqlw & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCNDNGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""creditnote"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetCreditNote() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CCNDNHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim strCust As String = "[]"
                If oData.Count > 0 Then
                    Dim oCust = New CCompany(GetSession("ConnJob")).GetData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oData(0).CustCode, oData(0).CustBranch))
                    If oCust.Count > 0 Then
                        strCust = JsonConvert.SerializeObject(oCust(0))
                    End If
                End If
                Dim jsonH As String = JsonConvert.SerializeObject(oData)
                Dim oDataD = New CCNDNDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)
                Dim json = "{""creditnote"":{""header"":" & jsonH & ",""detail"":" & jsonD & ",""customer"":" & strCust & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCreditNote", ex.Message, ex.StackTrace, True)
                Return Content("{""creditnote"":{""header"":[],""detail"":[],""customer"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function SetCNDNHeader(<FromBody()> data As CCNDNHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.DocNo = "" Then
                        If data.DocDate = DateTime.MinValue Then
                            data.DocDate = Today.Date
                        End If
                        data.AddNew(If(data.DocType = 0, "CN", "DN") & "-" & data.DocDate.ToString("yyMM") & "-____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetCNDNHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelCreditNote() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                Dim oData As New CCNDNHeader(GetSession("ConnJob"))
                Dim oDataD As New CCNDNDetail(GetSession("ConnJob"))
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                    oData.BranchCode = Request.QueryString("Branch").ToString
                    oDataD.BranchCode = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""creditnote"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}'", Request.QueryString("Code").ToString)
                    oData.DocNo = Request.QueryString("Code").ToString
                    oDataD.DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""creditnote"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                oDataD.DeleteData(tSqlw)
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""creditnote"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelCreditNote", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GLNote() As ActionResult
            Return GetView("GLNote", "MODULE_ACC")
            'Return RedirectToAction("FormGL")
        End Function
        Function GetJournalEntry() As ActionResult
            Try
                Dim tSqlw As String = " WHERE GLRefNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND GLRefNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oDataD = New CGLDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)
                If Not IsNothing(Request.QueryString("Year")) Then
                    tSqlw &= String.Format("AND FiscalYear='{0}' ", Request.QueryString("Year").ToString)
                End If
                Dim oData = New CGLHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""journal"":{""header"":" & json & ",""detail"":" & jsonD & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJournalEntry", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetGLDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE GLRefNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND GLRefNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                Dim oData = New CGLDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""journal"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetGLDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetGLDetail(<FromBody()> data As CGLDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.GLRefNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND GLRefNo='{1}' AND ItemNo={2} ", data.BranchCode, data.GLRefNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetGLDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelGLDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE GLRefNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND GLRefNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CGLDetail(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""journal"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelGLDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetGLHeader(<FromBody()> data As CGLHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.GLRefNo = "" Then
                        data.AddNew(data.GLType & data.BatchDate.ToString("yyMM") & "____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND GLRefNo='{1}' ", data.BranchCode, data.GLRefNo))
                    Dim json = "{""result"":{""data"":""" & data.GLRefNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetGLHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelGLHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE GLRefNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND GLRefNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CGLHeader(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Dim oDataD As New CGLDetail(GetSession("ConnJob"))
                Dim msgD = oDataD.DeleteData(tSqlw)

                Dim json = "{""journal"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelGLHeader", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function FormExpense() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Expense")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If

            Return GetView("FormExpense")
        End Function
        Function FormVoucher() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If

            Return GetView("FormVoucher")
        End Function
        Function FormWHTax() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If

            Return GetView("FormWHTax")
        End Function
        Function GetVoucherGrid() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("R") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("R") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""msg"":""You are not allow to view""}}", jsonContent)
                        End If
                    End If
                End If

                Dim tSqlw As String = SQLSelectVoucher()
                tSqlw &= " WHERE h.ControlNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.ControlNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND d.ForJNo ='{0}'", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND h.VoucherDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND h.VoucherDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If IsNothing(Request.QueryString("Cancel")) Then
                    If IsNothing(Request.QueryString("Show")) Then
                        tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                Else
                    tSqlw &= String.Format(" AND ISNULL(h.CancelProve,'')='{0}' ", Request.QueryString("Cancel").ToString())
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlw &= " AND ISNULL(h.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "ACTIVE" Then
                        tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "POSTED" Then
                        tSqlw &= " AND ISNULL(h.PostedBy,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "NOTPOST" Then
                        tSqlw &= " AND NOT ISNULL(h.PostedBy,'')<>'' "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    Select Case Request.QueryString("Type").ToString
                        Case "CHQP"
                            tSqlw &= " AND d.ChqAmount>0 AND PRType='P'"
                        Case "CHQR"
                            tSqlw &= " AND d.ChqAmount>0 AND PRType='R'"
                        Case "CASHP"
                            tSqlw &= " AND d.CashAmount>0 AND PRType='P'"
                        Case "CASHR"
                            tSqlw &= " AND d.CashAmount>0 AND PRType='R'"
                        Case "TACC"
                            tSqlw &= " AND d.DocNo Like '" & GetValueConfig("RUNNING_FORMAT", "EXP", expPrefix) & "%' "
                    End Select
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData)
                Dim json = "{""voucher"":{""data"":" & oHead & ",""msg"":""Complete!""}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucherGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetVoucherDetail() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    tSqlw &= String.Format(" AND b.BranchCode ='{0}'", Request.QueryString("BranchCode").ToString)
                End If
                If Not IsNothing(Request.QueryString("BookNo")) Then
                    tSqlw &= String.Format(" AND b.BookCode='{0}'", Request.QueryString("BookNo").ToString)
                End If
                If Not IsNothing(Request.QueryString("DocNo")) Then
                    tSqlw &= String.Format(" AND a.PostRefNo='{0}'", Request.QueryString("DocNo").ToString)
                Else
                    tSqlw &= " AND NOT ISNULL(a.PostRefNo,'')<>'' "
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND a.VoucherDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND a.VoucherDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                Dim isSummary = False
                If Not IsNothing(Request.QueryString("Sum")) Then
                    isSummary = Request.QueryString("Sum").ToString = "Y"
                End If
                Dim tsqlH = "
with vc
as
(
select a.ControlNo,a.VoucherDate,a.TRemark,b.BookCode,d.BookName,d.ControlBalance,b.PRType,a.PostRefNo,
(CASE WHEN b.PRType='R' THEN b.CashAmount+b.ChqAmount ELSE (b.CashAmount+b.ChqAmount)*-1 END) as TotalVoucher,
c.DocNo,c.PaidAmount,e.TotalAdvance,e.TotalVAT,e.Total50Tavi,e.AdvDate,e.EmpCode,e.AdvBy,e.SDescription,
e.CustName,a.PostedDate,a.PostedBy,
(CASE WHEN SUBSTRING(e.AccountCost,1,1)<='3' THEN '9762999' ELSE  e.CostCenter END) as CostCenter,
ac1.AccTName as CostCenterName,e.AccountCost,ac2.AccTName as AccountName
from 
Job_CashControl a inner join Job_CashControlSub b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN Job_CashControlDoc c
ON b.BranchCode=c.BranchCode AND b.ControlNo=c.ControlNo
AND b.acType=c.acType 
left join Mas_BookAccount d on b.BookCode=d.BookCode
left join (
 SELECT h.BranchCode,h.AdvNo,h.AdvDate,h.EmpCode,h.AdvBy,d.SDescription,cu.GLAccountCode as CostCenter,
 ISNULL(sv.GLAccountCodeCost,sv.GLAccountCodeSales) as AccountCost,cu.NameEng as CustName,
 SUM(d.AdvAmount) as TotalAdvance,
 SUM(d.ChargeVAT) as TotalVAT,sum(d.Charge50Tavi) as Total50Tavi
 from Job_AdvHeader h inner join Job_AdvDetail d
 on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
 left join Mas_Company cu ON h.CustCode=cu.CustCode AND h.CustBranch=cu.Branch
 left join Job_SrvSingle sv ON d.SICode=sv.SICode
 group by h.BranchCode,h.AdvNo,h.AdvDate,h.EmpCode,h.AdvBy,d.SDescription,cu.GLAccountCode,
 cu.NameEng,ISNULL(sv.GLAccountCodeCost,sv.GLAccountCodeSales)
) e on c.BranchCode=e.BranchCode AND c.DocNo=e.AdvNo
left join Mas_Account ac1 ON e.CostCenter=ac1.AccCode
left join Mas_Account ac2 ON e.AccountCost=ac1.AccCode
WHERE ISNULL(a.CancelProve,'')='' AND  b.PRType='P' " & tSqlw & " 
)
select CustName + '/'+ISNULL(AccountName,'') as 'GLDesc',CostCenter,AccountCost as AccountCode,
SUM(TotalAdvance) as Amt,SUM(TotalVAT) as Vat,SUM(Total50Tavi) as Wht,
SUM(TotalAdvance+TotalVAT-Total50Tavi) as Net
from vc where PaidAmount>0
group by CustName,AccountName,CostCenter,AccountCost
"
                Dim tSqlD = ""
                If isSummary = False Then
                    tSqlD = "
with vc
as
(
select a.ControlNo,a.VoucherDate,a.TRemark,b.BookCode,d.BookName,d.ControlBalance,b.PRType,
(CASE WHEN b.PRType='R' THEN b.CashAmount+b.ChqAmount ELSE (b.CashAmount+b.ChqAmount)*-1 END) as TotalVoucher,
c.DocNo,c.PaidAmount,e.TotalAdvance+e.TotalVAT-e.Total50Tavi as TotalNet,a.PostRefNo,a.PostedDate,a.PostedBy,
e.TotalAdvance,e.TotalVAT,e.Total50Tavi,e.AdvDate,e.EmpCode,e.AdvBy,e.SDescription,
(CASE WHEN SUBSTRING(e.AccountCost,1,1)<='3' THEN '9762999' ELSE  e.CostCenter END) as CostCenter,
ac1.AccTName as CostCenterName,e.AccountCost,ac2.AccTName as AccountName,e.Rate50Tavi,
e.Total50Tavi1,e.Total50Tavi3,e.ForJNo as JobNo
from 
Job_CashControl a inner join Job_CashControlSub b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN Job_CashControlDoc c
ON b.BranchCode=c.BranchCode AND b.ControlNo=c.ControlNo
AND b.acType=c.acType 
left join Mas_BookAccount d on b.BookCode=d.BookCode
left join (
 SELECT h.BranchCode,h.AdvNo,h.AdvDate,h.EmpCode,h.AdvBy,
 d.SDescription,cu.GLAccountCode as CostCenter,d.ForJNo,
 ISNULL(sv.GLAccountCodeCost,sv.GLAccountCodeSales) as AccountCost,d.Rate50Tavi,
 SUM(d.AdvAmount) as TotalAdvance,
 SUM(d.ChargeVAT) as TotalVAT,sum(d.Charge50Tavi) as Total50Tavi,
 sum(CASE WHEN d.Rate50Tavi=1 THEN d.Charge50Tavi ELSE 0 END) as Total50Tavi1,
 sum(CASE WHEN d.Rate50Tavi<>1 THEN d.Charge50Tavi ELSE 0 END) as Total50Tavi3
 from Job_AdvHeader h inner join Job_AdvDetail d
 on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
 left join Mas_Company cu ON h.CustCode=cu.CustCode AND h.CustBranch=cu.Branch
 left join Job_SrvSingle sv ON d.SICode=sv.SICode
 group by h.BranchCode,h.AdvNo,h.AdvDate,h.EmpCode,h.AdvBy,d.SDescription,
 cu.GLAccountCode,ISNULL(sv.GLAccountCodeCost,sv.GLAccountCodeSales),
 d.Rate50Tavi,d.ForJNo
) e on c.BranchCode=e.BranchCode AND c.DocNo=e.AdvNo
left join Mas_Account ac1 ON e.CostCenter=ac1.AccCode
left join Mas_Account ac2 ON e.AccountCost=ac1.AccCode
WHERE ISNULL(a.CancelProve,'')='' AND b.PRType='P' " & tSqlw & " 
)
select * from vc WHERE PaidAmount>0 order by PRType DESC,DocNo
"
                Else
                    tSqlD = "
with vc
as
(
select a.ControlNo,a.VoucherDate,a.TRemark,b.BookCode,d.BookName,d.ControlBalance,b.PRType,
(CASE WHEN b.PRType='R' THEN b.CashAmount+b.ChqAmount ELSE (b.CashAmount+b.ChqAmount)*-1 END) as TotalVoucher,
c.DocNo,c.PaidAmount,e.TotalAdvance+e.TotalVAT-e.Total50Tavi as TotalNet,a.PostRefNo,a.PostedDate,a.PostedBy,
e.TotalAdvance,e.TotalVAT,e.Total50Tavi,e.AdvDate,e.EmpCode,e.AdvBy,e.SDescription,
(CASE WHEN SUBSTRING(e.AccountCost,1,1)<='3' THEN '9762999' ELSE  e.CostCenter END) as CostCenter,
ac1.AccTName as CostCenterName,e.AccountCost,ac2.AccTName as AccountName,e.Total50Tavi1,e.Total50Tavi3
from 
Job_CashControl a inner join Job_CashControlSub b
ON a.BranchCode=b.BranchCode AND a.ControlNo=b.ControlNo
LEFT JOIN Job_CashControlDoc c
ON b.BranchCode=c.BranchCode AND b.ControlNo=c.ControlNo
AND b.acType=c.acType 
left join Mas_BookAccount d on b.BookCode=d.BookCode
left join (
 SELECT h.BranchCode,h.AdvNo,h.AdvDate,h.EmpCode,h.AdvBy,
 (SELECT STUFF((
    SELECT DISTINCT ',' + SDescription
    FROM Job_AdvDetail WHERE BranchCode=h.BranchCode
    AND AdvNo=h.AdvNo  
FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
)) as SDescription,
 cu.GLAccountCode as CostCenter,
 ISNULL(sv.GLAccountCodeCost,sv.GLAccountCodeSales) as AccountCost,
 SUM(d.AdvAmount) as TotalAdvance,
 SUM(d.ChargeVAT) as TotalVAT,sum(d.Charge50Tavi) as Total50Tavi,
 sum(CASE WHEN d.Rate50Tavi=1 THEN d.Charge50Tavi ELSE 0 END) as Total50Tavi1,
 sum(CASE WHEN d.Rate50Tavi<>1 THEN d.Charge50Tavi ELSE 0 END) as Total50Tavi3
 from Job_AdvHeader h inner join Job_AdvDetail d
 on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
 left join Mas_Company cu ON h.CustCode=cu.CustCode AND h.CustBranch=cu.Branch
 left join Job_SrvSingle sv ON d.SICode=sv.SICode
 group by h.BranchCode,h.AdvNo,h.AdvDate,h.EmpCode,h.AdvBy,
 cu.GLAccountCode,ISNULL(sv.GLAccountCodeCost,sv.GLAccountCodeSales)
) e on c.BranchCode=e.BranchCode AND c.DocNo=e.AdvNo
left join Mas_Account ac1 ON e.CostCenter=ac1.AccCode
left join Mas_Account ac2 ON e.AccountCost=ac1.AccCode
WHERE ISNULL(a.CancelProve,'')='' AND b.PRType='P' " & tSqlw & " 
)
select * from vc WHERE PaidAmount>0 order by PRType DESC,DocNo
"
                End If
                Dim oDataH As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tsqlH)
                Dim jsonH = JsonConvert.SerializeObject(oDataH.AsEnumerable.ToList())
                Dim oDataD As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSqlD)
                Dim jsonD = JsonConvert.SerializeObject(oDataD.AsEnumerable.ToList())

                Return Content("{""data"":{""header"":" & jsonH & ",""detail"":" & jsonD & ",""msg"":""OK""}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucherDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""data"":{""header"":[],""detail"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetVoucherReport() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("R") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("R") < 0 Then
                            Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""You are not allow to view""}}", jsonContent)
                        End If
                    End If
                End If

                Dim tSqlw As String = " WHERE ControlNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND ControlNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim tSqlH As String = " AND ControlNo IN(SELECT ControlNo FROM Job_CashControl " & tSqlw & " "
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlH &= " AND VoucherDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlH &= " AND VoucherDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                tSqlH &= ")"
                Dim oData = New CVoucher(GetSession("ConnJob")).GetData(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData)
                Dim oSub As String = JsonConvert.SerializeObject(New CVoucherSub(GetSession("ConnJob")).GetData(tSqlw & tSqlH))
                'Dim oDoc As String = JsonConvert.SerializeObject(New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectVoucherDoc(tSqlw & tSqlH)))
                Dim oDoc As String = JsonConvert.SerializeObject(New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectVoucherDetail(tSqlw & tSqlH)))

                Dim json = "{""voucher"":{""header"":" & oHead & ",""payment"":" & oSub & ",""document"":" & oDoc & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucher", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function

        Function GetVoucher() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("R") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("R") < 0 Then
                            Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""You are not allow to view""}}", jsonContent)
                        End If
                    End If
                End If

                Dim tSqlw As String = " WHERE ControlNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND ControlNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim tSqlH As String = " AND ControlNo IN(SELECT ControlNo from Job_CashControl " & tSqlw
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlH &= " AND VoucherDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlH &= " AND VoucherDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                tSqlH &= ")"
                Dim oData = New CVoucher(GetSession("ConnJob")).GetData(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData)
                Dim oSub As String = JsonConvert.SerializeObject(New CVoucherSub(GetSession("ConnJob")).GetData(tSqlw))
                Dim oDoc As String = JsonConvert.SerializeObject(New CVoucherDoc(GetSession("ConnJob")).GetData(tSqlw & tSqlH))

                Dim json = "{""voucher"":{""header"":" & oHead & ",""payment"":" & oSub & ",""document"":" & oDoc & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucher", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function SetVoucherHeader(<FromBody()> data As CVoucher) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("E") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("E") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save voucher""}}", jsonContent)
                        End If
                    End If
                End If

                If Not IsNothing(data) Then

                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If

                    data.SetConnect(GetSession("ConnJob"))

                    If "" & data.ControlNo = "" Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                            If AuthorizeStr.IndexOf("I") < 0 Then
                                AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                                If AuthorizeStr.IndexOf("I") < 0 Then
                                    Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add voucher""}}", jsonContent)
                                End If
                            End If
                        End If
                        Dim fmt = Main.GetValueConfig("RUNNING", "VOUCHER")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.VoucherDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.VoucherDate.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.VoucherDate.ToString("yy"))
                            End If
                        Else
                            fmt = data.VoucherDate.ToString("yyMM") & "-___"
                        End If
                        data.AddNew(fmt)
                    End If
                    Dim tSql As String = String.Format(" WHERE BranchCode='{0}' AND  ControlNo='{1}' ", data.BranchCode, data.ControlNo)
                    Dim msg = data.SaveData(tSql)
                    Dim json = "{""result"":{""data"":""" & data.ControlNo & """,""msg"":""" & msg & """}}"

                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetVoucherHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetVoucherSub(<FromBody()> data As List(Of CVoucherSub)) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("E") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("E") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                        End If
                    End If
                End If

                Dim json As String = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                If IsNothing(data) Then
                    Return Content(json, jsonContent)
                End If

                If "" & data(0).BranchCode = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                End If

                If "" & data(0).ControlNo = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                End If

                If data(0).ItemNo = 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                    If AuthorizeStr.IndexOf("I") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                            If AuthorizeStr.IndexOf("I") < 0 Then
                                Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                            End If
                        End If
                    End If
                End If

                Dim i As Integer = 0
                Dim str As String = ""
                Dim branchcode As String = ""
                Dim docno As String = ""

                For Each o As CVoucherSub In data
                    i += 1
                    branchcode = o.BranchCode
                    docno = o.ControlNo
                    o.SetConnect(GetSession("ConnJob"))
                    If o.PRVoucher = "" Then
                        o.AddNew(o.PRType & "V-" & DateTime.Today.ToString("yyMM") & "-____")
                    End If
                    If str <> "" Then str &= ","
                    Dim msg = o.SaveData(String.Format(" WHERE BranchCode='{0}' AND  ControlNo='{1}' And ItemNo='{2}' ", o.BranchCode, o.ControlNo, o.ItemNo))
                    If msg.Substring(0, 1) = "[" Then
                        Return Content("{""result"":{""data"":[],""msg"":""" & msg & """}}", jsonContent)
                    End If
                    str &= msg
                Next

                Dim obj = New CVoucherSub(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' And ControlNo='{1}'", branchcode, docno))
                json = "{""result"":{""msg"":""" & str & """,""data"":[" & JsonConvert.SerializeObject(obj) & "]}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetVoucherSub", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":[],""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetVoucherDoc(<FromBody()> data As List(Of CVoucherDoc)) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("E") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("E") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                        End If
                    End If
                End If

                Dim json As String = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                If IsNothing(data) Then
                    Return Content(json, jsonContent)
                End If

                If "" & data(0).BranchCode = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                End If

                If "" & data(0).ControlNo = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                End If

                If data(0).ItemNo = 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                    If AuthorizeStr.IndexOf("I") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                            If AuthorizeStr.IndexOf("I") < 0 Then
                                Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                            End If
                        End If
                    End If
                End If

                Dim i As Integer = 0
                Dim str As String = ""
                Dim branchcode As String = ""
                Dim docno As String = ""

                For Each o As CVoucherDoc In data
                    i += 1
                    branchcode = o.BranchCode
                    docno = o.ControlNo
                    o.SetConnect(GetSession("ConnJob"))
                    Dim msg = o.SaveData(String.Format(" WHERE BranchCode='{0}' AND  ControlNo='{1}' And ItemNo='{2}' ", o.BranchCode, o.ControlNo, o.ItemNo))
                    If str <> "" Then str &= ","
                    str &= msg
                Next

                Dim obj = New CVoucherDoc(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' And ControlNo='{1}'", branchcode, docno))
                json = "{""result"":{""msg"":""" & str & """,""data"":""" & docno & """,""document"":[" & JsonConvert.SerializeObject(obj) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetVoucherDoc", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""Error!"",""error"":""" & ex.Message & """,""document"":[]}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelVoucherSub() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("D") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("D") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""result"":""You are not allow to delete""}}", jsonContent)
                        End If
                    End If
                End If

                Dim tSqlw As String = " WHERE ControlNo<>'' "
                Dim oData As New CVoucherSub(GetSession("ConnJob"))
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                    oData.BranchCode = Request.QueryString("Branch").ToString
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND ControlNo='{0}'", Request.QueryString("Code").ToString)
                    oData.ControlNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""voucher"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                If IsNothing(Request.QueryString("Item")) Then
                    Return Content("{""voucher"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                Else
                    oData.ItemNo = Convert.ToInt32(Request.QueryString("Item").ToString)
                    tSqlw &= String.Format(" AND ItemNo='{0}'", Request.QueryString("Item").ToString)
                End If
                Dim msg = ""
                Dim oDataSub = oData.GetData(tSqlw)
                For Each oRow In oDataSub
                    msg &= oRow.DeleteData()
                Next

                Dim json = "{""voucher"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oDataSub) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelVoucherSub", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function DelVoucherDoc() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("D") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("D") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""result"":""You are not allow to delete""}}", jsonContent)
                        End If
                    End If
                End If

                Dim tSqlw As String = " WHERE ControlNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND ControlNo='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""voucher"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                If IsNothing(Request.QueryString("Item")) Then
                    Return Content("{""voucher"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oData As New CVoucherDoc(GetSession("ConnJob"))
                Dim oDataDoc = oData.GetData(tSqlw & String.Format(" AND ItemNo='{0}'", Request.QueryString("Item").ToString))
                Dim msg = ""
                For Each oRow In oDataDoc
                    msg &= oRow.DeleteData()
                Next

                Dim json = "{""voucher"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oDataDoc) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelVoucherDoc", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function DelVoucher() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("D") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("D") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""result"":""You are not allow to delete""}}", jsonContent)
                        End If
                    End If
                End If
                Dim oData As New CVoucher(GetSession("ConnJob"))
                Dim tSqlw As String = " WHERE ControlNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                    oData.BranchCode = Request.QueryString("Branch").ToString
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND ControlNo='{0}'", Request.QueryString("Code").ToString)
                    oData.ControlNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""voucher"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""voucher"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelVoucher", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetWHTax() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""whtax"":{""header"":null,""detail"":null,""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If

                Dim oDatah = New CWHTaxHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonh As String = JsonConvert.SerializeObject(oDatah)

                Dim oDatad = New CWHTaxDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsond As String = JsonConvert.SerializeObject(oDatad)

                Dim jsonAll = "{""whtax"":{""header"":" & jsonh & ",""detail"":" & jsond & "}}"
                Return Content(jsonAll, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetWHTax", ex.Message, ex.StackTrace, True)
                Return Content("{""whtax"":{""msg"":""" & ex.Message & """,""header"":[],""detail"":[]}}", jsonContent)
            End Try
        End Function
        Function GetWHTaxReport(<FromBody()> data As CReport) As ActionResult
            Dim sqlM As String = ""
            Dim sqlW As String = ""
            Try
                Dim cliteria As String = data.ReportCliteria
                Select Case data.ReportCode
                    Case "PRD3"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate) as TaxYear,Month(DocDate) as TaxMonth,
sum(a.PayAmount) as SumPayAmount,sum(a.PayTax) as SumPayTax,Count(DISTINCT a.DocNo) as CountDoc
FROM (" & SQLSelectWHTax() & " WHERE h.FormType=4 AND NOT ISNULL(h.CancelProve,'')<>'' AND isnull(h.TaxNumber2,'')='' " & sqlW & ") a 
GROUP BY a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate),Month(DocDate)
ORDER BY a.TName1
"
                    Case "PRD3A"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate) as TaxYear,Month(DocDate) as TaxMonth,
sum(a.PayAmount) as SumPayAmount,sum(a.PayTax) as SumPayTax,Count(DISTINCT a.DocNo) as CountDoc
FROM (" & SQLSelectWHTax() & " WHERE h.FormType=4 AND NOT ISNULL(h.CancelProve,'')<>'' AND isnull(h.TaxNumber2,'')<>'' " & sqlW & ") a 
GROUP BY a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate),Month(DocDate)
ORDER BY a.TName1
"
                    Case "PRD53"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate) as TaxYear,Month(DocDate) as TaxMonth,
sum(a.PayAmount) as SumPayAmount,sum(a.PayTax) as SumPayTax,Count(DISTINCT a.DocNo) as CountDoc
FROM (" & SQLSelectWHTax() & " WHERE h.FormType=7 AND NOT ISNULL(h.CancelProve,'')<>''  AND isnull(h.TaxNumber2,'')='' " & sqlW & ") a 
GROUP BY a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate),Month(DocDate)
ORDER BY a.TName1
"
                    Case "PRD53A"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate) as TaxYear,Month(DocDate) as TaxMonth,
sum(a.PayAmount) as SumPayAmount,sum(a.PayTax) as SumPayTax,Count(DISTINCT a.DocNo) as CountDoc
FROM (" & SQLSelectWHTax() & " WHERE h.FormType=7 AND NOT ISNULL(h.CancelProve,'')<>''  AND isnull(h.TaxNumber2,'')<>'' " & sqlW & ") a 
GROUP BY a.IDCard1,a.TaxNumber1,a.TName1,a.TAddress1,Branch1,FormType,TaxLawNo,Year(DocDate),Month(DocDate)
ORDER BY a.TName1
"
                    Case "PRD3D"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT a.* FROM (" & SQLSelectWHTax() & " WHERE h.FormType=4 AND NOT ISNULL(h.CancelProve,'')<>'' AND isnull(h.TaxNumber2,'')='' " & sqlW & ") a ORDER BY a.TAddress1,a.DocDate,a.DocNo"
                    Case "PRD53D"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT a.* FROM (" & SQLSelectWHTax() & " WHERE h.FormType=7 AND NOT ISNULL(h.CancelProve,'')<>'' AND isnull(h.TaxNumber2,'')='' " & sqlW & ") a ORDER BY a.TAddress1,a.DocDate,a.DocNo"
                    Case "PRD3AD"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT a.* FROM (" & SQLSelectWHTax() & " WHERE h.FormType=4 AND NOT ISNULL(h.CancelProve,'')<>'' AND isnull(h.TaxNumber2,'')<>''" & sqlW & ") a ORDER BY a.TAddress1,a.DocDate,a.DocNo"
                    Case "PRD53AD"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "h.TaxNumber1", "h.JNo", "h.UpdateBy", "h.TaxNumber3", "h.TaxLawNo", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT a.* FROM (" & SQLSelectWHTax() & " WHERE h.FormType=7 AND NOT ISNULL(h.CancelProve,'')<>'' AND isnull(h.TaxNumber2,'')<>''" & sqlW & ") a ORDER BY a.TAddress1,a.DocDate,a.DocNo"
                End Select
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlM, True)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content("{""result"":" & json & ",""msg"":""OK"",""sql"":""" & sqlW & """}")
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetWHTaxReport", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""msg"":""" & ex.Message & """,""sql"":""" & sqlW & """}")

            End Try
        End Function
        Function GetWHTaxGrid() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""whtax"":{""data"":null,""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim tSqlw As String = SQLSelectWHTax()

                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" WHERE h.BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                Else
                    tSqlw &= " WHERE NOT ISNULL(h.DocNo,'')<>'' "
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.DocNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND h.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND h.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlw &= " AND ISNULL(h.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "ACTIVE" Then
                        tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData)
                Dim json = "{""whtax"":{""data"":" & oHead & ",""msg"":""Complete!""}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetWHTaxGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""whtax"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function

        Function SetWHTaxHeader(<FromBody()> data As CWHTaxHeader) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                End If

                If Not IsNothing(data) Then

                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If

                    data.SetConnect(GetSession("ConnJob"))

                    If "" & data.DocNo = "" Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                        If data.DocDate = DateTime.MinValue Then
                            data.DocDate = Today.Date
                        End If
                        data.AddNew(GetValueConfig("RUNNING_FORMAT", "WHTAX", whtPrefix) & data.DocDate.ToString("yyMM") & "-____")
                    End If

                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"

                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetWHTaxHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelWHTaxHeader() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""whtax"":{""data"":null,""result"":""You are not allow to delete""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode Like '{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oData As New CWHTaxHeader(GetSession("ConnJob"))
                Dim msg = New CWHTaxDetail(GetSession("ConnJob")).DeleteData(tSqlw)
                msg = oData.DeleteData(tSqlw)

                Dim json = "{""whtax"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelWHTaxHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""whtax"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetWHTaxDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""whtax"":{""detail"":null,""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                End If

                Dim oData = New CWHTaxDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""whtax"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetWHTaxDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""whtax"":{""msg"":""" & ex.Message & """,""detail"":[]}}", jsonContent)
            End Try
        End Function
        Function SetWHTaxDetail(<FromBody()> data As CWHTaxDetail) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                End If

                If Not IsNothing(data) Then

                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If

                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If

                    If data.ItemNo = 0 Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                    End If

                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2} ", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetWHTaxDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelWHTaxDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""whtax"":{""data"":null,""result"":""You are not allow to delete""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo ='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("ItemNo")) Then
                    tSqlw &= String.Format("AND ItemNo ='{0}' ", Request.QueryString("ItemNo").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oData As New CWHTaxDetail(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""whtax"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelWHTaxDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""whtax"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetInvoice() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                Dim docNo As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                    docNo = Request.QueryString("Code").ToString
                End If

                Dim oHead = New CInvHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim oDet = New CInvDetail(GetSession("ConnJob")).GetData(tSqlw)

                Dim jsonH As String = ""
                Dim jsonD As String = ""
                Dim jsonC As String = ""
                Dim jsonJob As String = ""

                If oHead.Count > 0 Then
                    jsonH = JsonConvert.SerializeObject(oHead)
                    If oDet.Count > 0 Then
                        jsonD = JsonConvert.SerializeObject(oDet)
                    End If
                    Dim oCust = New CCompany(GetSession("ConnJob")).GetData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oHead(0).CustCode, oHead(0).CustBranch))
                    jsonC = JsonConvert.SerializeObject(oCust)
                End If

                If oDet.Count > 0 Then
                    Dim oJob = New CJobOrder(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND JNo IN(SELECT d.JobNo FROM Job_ClearDetail d inner join Job_ClearHeader h on d.branchcode=h.branchcode and d.clrno=h.clrno WHERE d.BranchCode='{0}' AND d.LinkBillNo='{1}' AND d.JobNo<>'' AND h.DocStatus<>99)", oDet(0).BranchCode, oDet(0).DocNo))
                    jsonJob = JsonConvert.SerializeObject(oJob)
                End If
                Return Content("{""invoice"":{""msg"":""" & docNo & """,""header"":[" & jsonH & "],""detail"":[" & jsonD & "],""customer"":[" & jsonC & "],""job"":[" & jsonJob & "]}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvoice", ex.Message, ex.StackTrace, True)
                Return Content("{""invoice"":{""msg"":""" & ex.Message & """,""header"":[],""detail"":[]}}", jsonContent)
            End Try
        End Function
        Function GetInvHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format("AND CustCode ='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cancel")) Then
                    tSqlw &= String.Format("AND ISNULL(CancelProve,''){0}", If(Request.QueryString("Cancel").ToString.ToUpper = "Y", "<>''", "=''"))
                End If
                Dim oData = New CInvHeader(GetSession("ConnJob")).GetData(tSqlw & " ORDER BY DocDate DESC")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""invheader"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""invheader"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function SetInvHeader(<FromBody()> data As CInvHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.DocNo = "" Then
                        Dim invHeadDefault = GetValueConfig("RUNNING_FORMAT", "INV", invPrefix)
                        If data.DocType = "" Then
                            data.DocType = "INV"
                        End If
                        Dim invHeadConfig = GetValueConfig("RUNNING_FORMAT", data.DocType, "IVS-")
                        If invHeadConfig <> invHeadDefault And invHeadConfig <> "" Then
                            invHeadDefault = invHeadConfig
                        End If
                        If data.DocDate = DateTime.MinValue Then
                            data.DocDate = Today
                        End If
                        Dim fmt = Main.GetValueConfig("RUNNING", "INV")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.DocDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.DocDate.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.DocDate.ToString("yy"))
                            End If
                        Else
                            fmt = data.DocDate.ToString("yyMM") & "____"
                        End If
                        data.AddNew(invHeadDefault & fmt)
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetInvHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelInvHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                    Branch = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""invheader"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                Dim DocNo As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}' ", Request.QueryString("Code").ToString)
                    DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""invheader"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oData As New CInvHeader(GetSession("ConnJob")) With {
                    .BranchCode = Branch,
                    .DocNo = DocNo
                }
                Dim msg = oData.DeleteData(tSqlw)

                Dim oDet As New CInvDetail(GetSession("ConnJob"))
                oDet.DeleteData(tSqlw)

                Dim json = "{""invheader"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelInvHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""invheader"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetBillHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE BillAcceptNo<>'' "
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString() = "ACTIVE" Then
                        tSqlw &= String.Format(" AND NOT ISNULL(CancelProve,'')<>'' ")
                    End If
                    If Request.QueryString("Show").ToString() = "CANCEL" Then
                        tSqlw &= String.Format(" AND ISNULL(CancelProve,'')<>'' ")
                    End If
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format("AND CustCode ='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND BillDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND BillDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                Dim oData = New CBillHeader(GetSession("ConnJob")).GetData(tSqlw & " ORDER BY BillDate DESC")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = " {""billheader"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBillHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""billheader"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function SetBillHeader(<FromBody()> data As CBillHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.BillAcceptNo = "" Then
                        If data.BillDate = DateTime.MinValue Then
                            data.BillDate = Today.Date
                        End If
                        Dim fmt = Main.GetValueConfig("RUNNING", "BILL")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.BillDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.BillDate.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.BillDate.ToString("yy"))
                            End If
                        Else
                            fmt = data.BillDate.ToString("yyMM") & "____"
                        End If
                        data.AddNew(GetValueConfig("RUNNING_FORMAT", "BILL", billPrefix) & fmt)

                        'Get Due Date from Customers
                        Dim oCust = New CCompany(GetSession("ConnJob")).GetData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", data.CustCode, data.CustBranch))
                        If oCust.Count > 0 Then
                            Dim creditdays = CInt(oCust(0).CreditLimit)
                            data.DuePaymentDate = data.BillDate.AddDays(creditdays)
                        End If
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND BillAcceptNo='{1}' ", data.BranchCode, data.BillAcceptNo))
                    Dim json = "{""result"":{""data"":""" & data.BillAcceptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetBillHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelBillHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE BillAcceptNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""billheader"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo Like '{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""billheader"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim Branch As String = Request.QueryString("Branch").ToString
                Dim Code As String = Request.QueryString("Code").ToString

                Dim oData As New CBillHeader(GetSession("ConnJob")) With {
                    .BranchCode = Branch,
                    .BillAcceptNo = Code
                }
                Dim msg = oData.DeleteData(tSqlw)

                Dim oDet As New CBillDetail(GetSession("ConnJob"))
                oDet.DeleteData(tSqlw)

                Dim json = "{""billheader"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelBillHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""billheader"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetReceiveReport() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ISNULL(rh.CancelProve,'')='' "

                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND rh.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND rh.ReceiptNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND rh.ReceiptDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND rh.ReceiptDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND rh.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("InvDateFrom")) Then
                    tSqlw &= " AND ih.DocDate>='" & Request.QueryString("InvDateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("InvDateTo")) Then
                    tSqlw &= " AND ih.DocDate<='" & Request.QueryString("InvDateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("BillTo")) Then
                    tSqlw &= String.Format(" AND rh.BillToCustCode='{0}' ", Request.QueryString("BillTo").ToString)
                End If
                Dim isSummary As Boolean = False
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString = "SUM" Then
                        isSummary = True
                    End If
                End If
                Dim tSql As String = ""
                If isSummary = False Then
                    tSql = SQLSelectReceiptReport() & tSqlw
                Else
                    tSql = SQLSelectReceiptSummaryByInv(tSqlw)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSql)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""receipt"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetReceiptReport", ex.Message, ex.StackTrace, True)
                Return Content("{""receipt"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetReceipt() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ReceiptNo<>'' "
                Dim docNo As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo='{0}' ", Request.QueryString("Code").ToString)
                    docNo = Request.QueryString("Code").ToString
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format("AND CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND ReceiptDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND ReceiptDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    tSqlw &= " AND ReceiptType = '" & Request.QueryString("Type").ToString() & "' "
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString() = "ACTIVE" Then
                        tSqlw &= String.Format(" AND NOT ISNULL(CancelProve,'')<>'' ")
                    End If
                    If Request.QueryString("Show").ToString() = "CANCEL" Then
                        tSqlw &= String.Format(" AND ISNULL(CancelProve,'')<>'' ")
                    End If
                End If

                Dim oHead = New CRcpHeader(GetSession("ConnJob")).GetData(tSqlw & " ORDER BY ReceiptDate DESC")
                Dim oDet = New CRcpDetail(GetSession("ConnJob")).GetData(" WHERE ReceiptNo IN(SELECT ReceiptNo FROM Job_ReceiptHeader " & tSqlw & ")")

                Dim jsonH As String = ""
                Dim jsonD As String = ""
                Dim jsonC As String = ""

                If oHead.Count > 0 Then
                    jsonH = JsonConvert.SerializeObject(oHead)
                    If oDet.Count > 0 Then
                        jsonD = JsonConvert.SerializeObject(oDet)
                    End If

                    Dim oCust = New CCompany(GetSession("ConnJob")).GetData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oHead(0).CustCode, oHead(0).CustBranch))
                    If oCust.Count > 0 Then
                        jsonC = JsonConvert.SerializeObject(oCust)
                    End If
                End If

                Return Content("{""receipt"":{""msg"":""" & docNo & """,""header"":[" & jsonH & "],""detail"":[" & jsonD & "],""customer"":[" & jsonC & "]}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetReceipt", ex.Message, ex.StackTrace, True)
                Return Content("{""receipt"":{""msg"":""" & ex.Message & """,""header"":[],""detail"":[],""customer"":[]}}", jsonContent)
            End Try
        End Function
        Function GetRcpHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ReceiptNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CRcpHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""rcpheader"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetRcpHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""rcpheader"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function SetRcpHeader(<FromBody()> data As CRcpHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.ReceiptNo = "" Then
                        If data.ReceiptDate = DateTime.MinValue Then
                            data.ReceiptDate = Today.Date
                        End If
                        Dim prefix = GetValueConfig("RUNNING_FORMAT", "RECEIVE_" & data.ReceiptType, "")
                        If prefix = "" Then
                            Select Case data.ReceiptType
                                Case "REC" 'Cash Receipts
                                    prefix = "RC-"
                                Case "TAX" 'Receipt/Tax Invoice
                                    prefix = "TX-"
                                Case "SRV" 'Tax Invoice Only
                                    prefix = "SV-"
                                Case "RCV" 'Receive Non Vat
                                    prefix = "RV-"
                                Case "ADV" 'Receive Reimbursement
                                    prefix = "AV-"
                                Case Else
                                    Return Content("{""result"":{""data"":null,""msg"":""Please Enter Receipt Type""}}", jsonContent)
                            End Select
                        End If
                        Dim fmt = Main.GetValueConfig("RUNNING", "RCP")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.ReceiptDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.ReceiptDate.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.ReceiptDate.ToString("yy"))
                            End If
                        Else
                            fmt = data.ReceiptDate.ToString("yyMM") & "____"
                        End If
                        data.AddNew(prefix & fmt)
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}' ", data.BranchCode, data.ReceiptNo))
                    Dim json = "{""result"":{""data"":""" & data.ReceiptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetRcpHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelRcpHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ReceiptNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""rcpheader"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""rcpheader"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oData As New CRcpHeader(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim oDetail As New CRcpDetail(GetSession("ConnJob")) With {
                    .BranchCode = Request.QueryString("Branch").ToString,
                    .ReceiptNo = Request.QueryString("Code").ToString
                }
                oDetail.DeleteData(tSqlw)

                Dim json = "{""rcpheader"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelRcpHeader", ex.Message, ex.StackTrace, True)
                Return Content("{""rcpheader"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetCheque() As ActionResult
            Try
                Dim tSqlw = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND b.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND b.ChqNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim chqType = "CU"
                If Not IsNothing(Request.QueryString("Type")) Then
                    chqType = Request.QueryString("Type").ToString
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND b.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cancel")) Then
                    If Request.QueryString("Cancel").ToString() = "Y" Then
                        tSqlw &= " AND ISNULL(b.CancelProve,'')<>'' "
                    Else
                        tSqlw &= " AND ISNULL(b.CancelProve,'')='' "
                    End If
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectChequeBalance(chqType, If(chqType = "CU", "P", "R")) & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""cheque"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetCheque", ex.Message, ex.StackTrace, True)
                Return Content("{""cheque"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetDocBalance() As ActionResult
            Try
                Dim tSqlw = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND b.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND b.DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim prType = "R"
                If Not IsNothing(Request.QueryString("Type")) Then
                    prType = Request.QueryString("Type").ToString
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND b.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cancel")) Then
                    If Request.QueryString("Cancel").ToString() = "Y" Then
                        tSqlw &= " AND ISNULL(b.CancelProve,'')<>'' "
                    Else
                        tSqlw &= " AND ISNULL(b.CancelProve,'')='' "
                    End If
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectDocumentBalance(prType, "Credit") & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""document"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetDocBalance", ex.Message, ex.StackTrace, True)
                Return Content("{""document"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetClearForInv() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ISNULL(b.LinkBillNo,'')='' AND a.DocStatus NOT IN('99','1') AND b.BNet<>0 "

                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND b.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND b.JobNo ='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlw &= String.Format(" AND c.JobType ={0} ", Request.QueryString("JType").ToString)
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlw &= String.Format(" AND c.ShipBy ={0} ", Request.QueryString("SBy").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND c.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND a.ClrDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND a.ClrDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    If Request.QueryString("Status").ToString = "CLOSE" Then
                        tSqlw &= " AND c.JobStatus>=3 AND c.JobStatus<90 "
                    End If
                    If Request.QueryString("Status").ToString = "ACTIVE" Then
                        tSqlw &= " AND c.JobStatus<90 "
                    End If
                    If Request.QueryString("Status").ToString = "NOEARNEST" Then
                        tSqlw &= " AND s.NameThai NOT LIKE '%มัดจำ%' AND c.JobStatus>=3 AND c.JobStatus<90 "
                    End If
                End If
                tSqlw &= " ORDER BY b.LinkBillNo,b.JobNo,s.IsCredit DESC,b.SDescription"
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectClrForInvoice() & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""invdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearForInv", ex.Message, ex.StackTrace, True)
                Return Content("{""invdetail"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetInvDetailReport() As ActionResult
            Try
                Dim tSqlw As String = " WHERE h.DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectInvDetail() & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""invdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""invdetail"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try

        End Function
        Function GetInvDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CInvDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""invdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""invdetail"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function SaveInvDetail(<FromBody()> data As List(Of CInvDetail)) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data(0).BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data(0).DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    Dim i As Integer = 0
                    Dim msg As String = ""
                    For Each dt In data
                        'Invoice's Service+Advance
                        If dt.ItemNo > 0 Then
                            dt.SetConnect(GetSession("ConnJob"))
                            Dim result = dt.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2}", dt.BranchCode, dt.DocNo, dt.ItemNo))
                            If result.Substring(0, 1) = "S" Then
                                i += 1
                                msg &= i & " row(s) saved!\n"
                            Else
                                msg &= i & " Error: " & result & "\n"
                            End If
                        Else
                            'Invoice's Cost
                            Dim Sql = String.Format("UPDATE Job_ClearDetail SET LinkBillNo='{0}',LinkItem={1} ", dt.DocNo, dt.ItemNo)
                            Sql &= String.Format(" WHERE ClrNo+'/'+Convert(varchar,ItemNo) IN('{0}')", dt.ClrNoList.Replace(",", "','"))
                            msg &= "Update " & dt.ClrNoList & "=" & Main.DBExecute(GetSession("ConnJob"), Sql) & "\n"
                        End If
                    Next
                    Dim json = "{""result"":{""data"":""" & data(0).DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SaveInvDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function

        Function SetInvDetail(<FromBody()> data As CInvDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo='{2}'", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetInvDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelInvDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                    Branch = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""invdetail"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                Dim DocNo As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}' ", Request.QueryString("Code").ToString)
                    DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""invdetail"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo ='{0}' ", Request.QueryString("Item").ToString)
                End If
                Dim oData As New CInvDetail(GetSession("ConnJob"))
                Dim oRec = oData.GetData(tSqlw)
                If oRec.Count > 0 Then
                    Dim msg = ""
                    For Each doc In oRec
                        msg &= doc.DeleteData(tSqlw) & ","
                    Next
                    Dim json = "{""invdetail"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oRec(0)) & "]}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""invdetail"":{""result"":""Data not found"",""data"":[]}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelInvDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""invdetail"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetInvReport() As ActionResult
            Try
                Dim defaultWhere As String = "(id.TotalAmt-ISNULL(id.AmtCredit,0)-ISNULL(r.ReceivedNet,0)-ISNULL(c.CreditNet,0))"
                Dim tSqlw As String = " AND " & defaultWhere & " >0 "
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString.ToUpper = "NOPAY" Then
                        tSqlw &= " AND ISNULL(r.ReceivedNet,0)=0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "RECEIVED" Then
                        tSqlw = " AND ISNULL(r.ReceivedNet,0)>0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "CLEARED" Then
                        tSqlw = " AND " & defaultWhere & "<=0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "ALL" Then
                        tSqlw = ""
                    End If
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND ih.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND ih.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND ih.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND ih.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("BillDateFrom")) Then
                    tSqlw &= " AND ih.BillIssueDate>='" & Request.QueryString("BillDateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("BillDateTo")) Then
                    tSqlw &= " AND ih.BillIssueDate<='" & Request.QueryString("BillDateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("BillTo")) Then
                    tSqlw &= String.Format(" AND ih.BillToCustCode='{0}' ", Request.QueryString("BillTo").ToString)
                End If
                Dim isSummary As Boolean = False
                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString.ToUpper = "SUM" Then
                        isSummary = True
                    End If
                End If
                Dim oData = If(isSummary, New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectInvSummary(tSqlw)), New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectInvReport(tSqlw)))
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""inv"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvReport", ex.Message, ex.StackTrace, True)
                Return Content("{""inv"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetInvForReceive() As ActionResult
            Dim defaultWhere As String = "(id.TotalAmt-ISNULL(c.CreditNet,0)-ISNULL(r.ReceivedNet,0))"
            Dim tSqlw As String = " AND " & defaultWhere & ">0 "
            Try
                Dim bCheckVoucher As Boolean = False
                Dim byReceipt As Boolean = False
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString.ToUpper = "WAIT" Then
                        'don't have receipt document yet
                        tSqlw &= " AND ISNULL(r.ReceivedNet,0)=0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "RECV" Then
                        'have receipt document
                        tSqlw = " AND ISNULL(r.ReceivedNet,0)>0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "OPEN" Then
                        'by receipt document
                        bCheckVoucher = True
                        byReceipt = True
                        tSqlw = " AND (id.Amt-ISNULL(id.AmtCredit,0))>0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "FULLPAY" Then
                        tSqlw = " AND " & defaultWhere & "<=0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "PARTPAY" Then
                        tSqlw = " AND " & defaultWhere & ">0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "WAITPAY" Then
                        bCheckVoucher = True
                        tSqlw = " AND ISNULL(r.LastReceiptNo,'')<>'' AND ISNULL(r.LastControlNo,'')='' "
                        tSqlw &= " AND " & defaultWhere & ">=0 "
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "HAVERV" Then
                        bCheckVoucher = True
                    End If
                    If Request.QueryString("Show").ToString.ToUpper = "ALL" Then
                        tSqlw = ""
                    Else
                        If Request.QueryString("Show").ToString.ToUpper = "CANCEL" Then
                            tSqlw = " WHERE NOT ISNULL(ih.CancelProve,'')='' " & tSqlw
                        Else
                            tSqlw = " WHERE ISNULL(ih.CancelProve,'')='' " & tSqlw
                        End If
                    End If
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND ih.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If byReceipt = True Then
                    If Not IsNothing(Request.QueryString("DateFrom")) Then
                        tSqlw &= " AND r.ReceiptDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                    End If
                    If Not IsNothing(Request.QueryString("DateTo")) Then
                        tSqlw &= " AND r.ReceiptDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                    End If
                    If Not IsNothing(Request.QueryString("DueDateFrom")) Then
                        tSqlw &= " AND bh.DuePaymentDate>='" & Request.QueryString("DueDateFrom") & " 00:00:00'"
                    End If
                    If Not IsNothing(Request.QueryString("DueDateTo")) Then
                        tSqlw &= " AND bh.DuePaymentDate<='" & Request.QueryString("DueDateTo") & " 23:59:00'"
                    End If
                Else
                    If Not IsNothing(Request.QueryString("DateFrom")) Then
                        tSqlw &= " AND ih.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                    End If
                    If Not IsNothing(Request.QueryString("DateTo")) Then
                        tSqlw &= " AND ih.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                    End If
                End If
                If Not IsNothing(Request.QueryString("BillDateFrom")) Then
                    tSqlw &= " AND ih.BillIssueDate>='" & Request.QueryString("BillDateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("BillDateTo")) Then
                    tSqlw &= " AND ih.BillIssueDate<='" & Request.QueryString("BillDateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("BillTo")) Then
                    tSqlw &= String.Format(" AND ih.BillToCustCode='{0}' ", Request.QueryString("BillTo").ToString)
                End If

                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND ih.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                Dim recvNo As String = ""
                If Not IsNothing(Request.QueryString("RecvNo")) Then
                    recvNo = Request.QueryString("RecvNo").ToString
                End If

                If Not IsNothing(Request.QueryString("Type")) Then
                    If Request.QueryString("Type").ToString.ToUpper = "ADV" Then
                        tSqlw &= " AND ISNULL(id.AmtAdvance,0)>0 "
                    End If
                    If Request.QueryString("Type").ToString.ToUpper = "SRV" Then
                        tSqlw &= " AND ISNULL(id.AmtCharge,0)>0 "
                    End If
                    If Request.QueryString("Type").ToString.ToUpper = "TAX" Then
                        'have advance or have service
                        tSqlw &= " AND (ISNULL(id.AmtCharge,0)>0 OR ISNULL(id.AmtAdvance,0)>0) "
                    End If
                    If Request.QueryString("Type").ToString.ToUpper = "REC" Then
                        'have service but no vat
                        tSqlw &= " AND ISNULL(id.AmtCharge,0)>0 AND ISNULL(id.AmtVat,0)=0 "
                    End If
                    If Request.QueryString("Type").ToString.ToUpper = "RCV" Then
                        'have service non vat or advance
                        tSqlw &= " AND ((ISNULL(id.AmtCharge,0)>0 AND ISNULL(id.AmtVat,0)=0) OR ISNULL(id.AmtAdvance,0)>0) "
                    End If
                End If


                If Not IsNothing(Request.QueryString("InvNo")) Then
                    Dim invNo = Request.QueryString("InvNo").ToString
                    tSqlw &= String.Format(" WHERE ih.DocNo='{0}' ", invNo)
                End If

                If byReceipt Then
                    Dim sql As String = SQLSelectInvByReceive(recvNo, bCheckVoucher) & tSqlw
                    Dim sqlSum As String = "SELECT t.InvoiceNo,t.InvoiceDate,t.BillToCustCode,t.RefNo,Sum(t.Amt) as TotalAmt,Sum(t.AmtVAT) as TotalVAT,Sum(t.Amt50Tavi) as Total50Tavi,Sum(t.Net) as TotalNet "
                    sqlSum &= ",Sum(t.AmtAdvance) as TotalAdvance,Sum(t.AmtCharge) as TotalCharge FROM ({0}) as t GROUP BY t.InvoiceNo,t.InvoiceDate,t.BillToCustCode,t.RefNo"
                    sqlSum = String.Format(sqlSum, sql)
                    sql &= " ORDER BY ih.DocNo DESC"
                    Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                    Dim oDataSum = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlSum)
                    Dim json As String = JsonConvert.SerializeObject(oData)
                    Dim jsonSum As String = JsonConvert.SerializeObject(oDataSum)
                    json = "{""invdetail"":{""data"":" & json & ",""summary"":" & jsonSum & ",""condition"":""" & tSqlw & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim sql As String = SQLSelectInvForReceive(bCheckVoucher) & tSqlw
                    Dim sqlSum As String = "SELECT t.InvoiceNo,t.InvoiceDate,t.BillToCustCode,t.RefNo,Sum(t.Amt) as TotalAmt,Sum(t.AmtVAT) as TotalVAT,Sum(t.Amt50Tavi) as Total50Tavi,Sum(t.Net) as TotalNet "
                    sqlSum &= " FROM ({0}) as t GROUP BY t.InvoiceNo,t.InvoiceDate,t.BillToCustCode,t.RefNo"
                    sqlSum = String.Format(sqlSum, sql)
                    sql &= " ORDER BY ih.DocNo DESC"
                    Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                    Dim oDataSum = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlSum)
                    Dim json As String = JsonConvert.SerializeObject(oData)
                    Dim jsonSum As String = JsonConvert.SerializeObject(oDataSum)
                    json = "{""invdetail"":{""data"":" & json & ",""summary"":" & jsonSum & ",""condition"":""" & tSqlw & """}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvForReceive", ex.Message, ex.StackTrace, True)
                Return Content("{""invdetail"":{""msg"":""" & ex.Message & """,""data"":[],""condition"":""" & tSqlw & """}}", jsonContent)
            End Try
        End Function
        Function GetInvForBill() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ISNULL(a.CustCode,'')<>'' "
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "BILLED" Then
                        tSqlw &= " AND ISNULL(a.BillAcceptNo,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "ACTIVE" Then
                        tSqlw &= " AND NOT ISNULL(a.CancelProve,'')<>'' "
                    End If
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlw &= " AND ISNULL(a.CancelProve,'')<>'' "
                    End If
                Else
                    tSqlw &= " AND ISNULL(a.BillAcceptNo,'')='' AND  NOT ISNULL(a.CancelProve,'')<>''  "
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND a.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND a.DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND a.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND a.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND a.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Bill")) Then
                    tSqlw &= String.Format(" AND a.BillToCustCode='{0}' ", Request.QueryString("Bill").ToString)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectInvForBilling() & tSqlw & " ORDER BY a.DocDate DESC ")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""invdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetInvForBill", ex.Message, ex.StackTrace, True)
                Return Content("{""invdetail"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetBilling() As ActionResult
            Try
                Dim tSqlw As String = " WHERE BillAcceptNo<>'' "
                Dim docNo As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo='{0}' ", Request.QueryString("Code").ToString)
                    docNo = Request.QueryString("Code").ToString
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format("AND CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If

                Dim oHead = New CBillHeader(GetSession("ConnJob")).GetData(tSqlw)
                'Dim oDet = New CBillDetail(GetSession("ConnJob")).GetData(" WHERE BillAcceptNo IN(SELECT BillAcceptNo FROM Job_BillAcceptHeader " & tSqlw & ")")
                Dim oDet = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT * FROM (" & SQLSelectBillDetail() & ") t WHERE BillAcceptNo IN(SELECT BillAcceptNo FROM Job_BillAcceptHeader " & tSqlw & ")")
                Dim jsonH As String = ""
                Dim jsonD As String = ""
                Dim jsonC As String = ""

                If oHead.Count > 0 Then
                    jsonH = JsonConvert.SerializeObject(oHead)
                    If oDet.Rows.Count > 0 Then
                        jsonD = JsonConvert.SerializeObject(oDet)
                    End If

                    Dim oCust = New CCompany(GetSession("ConnJob")).GetData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oHead(0).CustCode, oHead(0).CustBranch))
                    If oCust.Count > 0 Then
                        jsonC = JsonConvert.SerializeObject(oCust)
                    End If
                End If

                Return Content("{""billing"":{""msg"":""" & docNo & """,""header"":[" & jsonH & "],""detail"":[" & jsonD & "],""customer"":[" & jsonC & "]}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBilling", ex.Message, ex.StackTrace, True)
                Return Content("{""billing"":{""msg"":""" & ex.Message & """,""header"":[],""detail"":[],""customer"":[]}}", jsonContent)
            End Try
        End Function
        Function GetBillDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE BillAcceptNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CBillDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""billdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBillDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""billdetail"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function SetBillDetail(<FromBody()> data As List(Of CBillDetail)) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data(0).BillAcceptNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    Else
                        Dim o = New CBillDetail(GetSession("ConnJob")) With {
                            .BranchCode = data(0).BranchCode,
                            .BillAcceptNo = data(0).BillAcceptNo
                        }
                        o.DeleteData(String.Format(" WHERE BranchCode='{0}' And BillAcceptNo='{1}'", data(0).BranchCode, data(0).BillAcceptNo))
                    End If
                    Dim msg = ""
                    For Each dt In data
                        dt.SetConnect(GetSession("ConnJob"))
                        msg &= "\n" & dt.SaveData(String.Format(" WHERE BranchCode='{0}' AND BillAcceptNo='{1}' AND ItemNo='{2}' ", dt.BranchCode, dt.BillAcceptNo, dt.ItemNo))
                    Next
                    Dim json = "{""result"":{""data"":""" & data(0).BillAcceptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetBillDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelBillDetail() As ActionResult
            Try
                Dim Branch As String = ""
                Dim tSqlw As String = " WHERE BillAcceptNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                    Branch = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""billdetail"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                Dim Code As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo ='{0}' ", Request.QueryString("Code").ToString)
                    Code = Request.QueryString("Code").ToString
                Else
                    Return Content("{""billdetail"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim Item As String = ""
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo ='{0}' ", Request.QueryString("Item").ToString)
                    Item = Request.QueryString("Item").ToString
                End If
                Dim oData As New CBillDetail(GetSession("ConnJob"))
                Dim oRec = oData.GetData(tSqlw)
                If oRec.Count > 0 Then
                    Dim msg = oRec(0).DeleteData(tSqlw)
                    Dim json = "{""billdetail"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oRec(0)) & "]}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""billdetail"":{""result"":""Data not found"",""data"":[]}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelRcpDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""billdetail"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetRcpDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ReceiptNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("InvNo")) Then
                    tSqlw &= String.Format("AND InvoiceNo ='{0}' ", Request.QueryString("InvNo").ToString)
                    tSqlw &= "AND ReceiptNo NOT IN(SELECT ReceiptNo FROM Job_ReceiptHeader WHERE ISNULL(CancelProve,'')<>'') "
                End If
                Dim oData = New CRcpDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""rcpdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetRcpDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""rcpdetail"":{""msg"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function SaveRcpDetail(<FromBody()> data As List(Of CRcpDetail)) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data(0).BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data(0).ReceiptNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    Dim i As Integer = 0
                    Dim msg As String = ""
                    For Each dt In data
                        'Invoice's Service+Advance
                        dt.SetConnect(GetSession("ConnJob"))
                        Dim result = dt.SaveData(String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}' AND ItemNo={2}", dt.BranchCode, dt.ReceiptNo, dt.ItemNo))
                        If result.Substring(0, 1) = "S" Then
                            i += 1
                            msg &= i & " row(s) saved!\n"
                        Else
                            msg &= i & " Error: " & result & "\n"
                        End If
                    Next
                    Dim json = "{""result"":{""data"":""" & data(0).ReceiptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SaveRcpDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function

        Function SetRcpDetail(<FromBody()> data As CRcpDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.ReceiptNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}' AND ItemNo='{2}' ", data.BranchCode, data.ReceiptNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ReceiptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetRcpDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelRcpDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ReceiptNo<>'' "
                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                    Branch = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""rcpdetail"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                Dim DocNo As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo Like '{0}' ", Request.QueryString("Code").ToString)
                    DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""rcpdetail"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo='{0}' ", Request.QueryString("Item").ToString)
                End If

                Dim oData As New CRcpDetail(GetSession("ConnJob")) With {
                    .BranchCode = Branch,
                    .ReceiptNo = DocNo
                }
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""rcpdetail"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelRcpDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""rcpdetail"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function Summary() As ActionResult
            Dim sqlClrByTruck = "
select r.Yearly,r.Monthly,r.TruckNo
,sum(ISNULL(SumRevenue,0)) as TotalRevenue 
,sum(ISNULL(SumService,0)) as TotalService
,sum(ISNULL(SumAdvance,0)) as TotalAdvance
,sum(ISNULL(SumCost,0)) as TotalCost
,sum(ISNULL(SumFuel,0)) as TotalFuel
,sum(ISNULL(SumProfit,0)) as TotalProfit
,count(*) as CountTrip 
from (
select Year(j.DocDate) as Yearly,Month(j.DocDate) as Monthly,
isnull(em.Name,ld.Driver) as Driver,
isnull(cl.CarLicense,ld.TruckNO) as TruckNo,ld.CTN_NO,
cd.SumRevenue,cd.SumService,cd.SumAdvance,
cd.SumCost,cd.SumFuel,cd.SumRevenue-cd.SumCost as SumProfit
from Job_LoadInfoDetail ld
inner join Job_Order j
on ld.BranchCode=j.BranchCode 
and ld.JNo=j.JNo
left join Mas_CarLicense cl
on ld.TruckNO=cl.CarNo
left join Mas_Employee em
on ld.Driver=em.EmpCode
left join (
 select h.BranchCode,h.CTN_NO,d.JobNo
 ,SUM(case when s.IsExpense=0 THEN d.BNet else 0 END) as SumRevenue
 ,SUM(case when s.IsExpense=0 AND s.IsCredit=0 THEN d.BNet else 0 END) as SumService
 ,SUM(case when s.IsExpense=0 AND s.IsCredit=1 THEN d.BNet else 0 END) as SumAdvance
 ,SUM(case when s.IsExpense=1 THEN d.BNet else 0 END) as SumCost
 ,SUM(case when s.IsExpense=1 AND d.SDescription like '%น้ำมัน%' THEN d.BNet else 0 END) as SumFuel

 from Job_ClearDetail d inner join Job_ClearHeader h
 on d.BranchCode=h.BranchCode and d.ClrNo=h.ClrNo
 inner join Job_SrvSingle s on d.SICode=s.SICode
 where h.DocStatus<>99
 group by h.BranchCode,h.CTN_NO,d.JobNo
) cd
on ld.BranchCode=cd.BranchCode 
and ld.CTN_NO=cd.CTN_NO
and ld.JNo=cd.JobNo
) r
group by r.Yearly,r.Monthly,r.TruckNo
order by 1,2,3
"
            Dim oTbl = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlClrByTruck)
            Dim html = ""
            html = "<h2>Summary By Truck</h2>"
            html &= "<table border=""1"" style=""border-collapse:collapse;border-width:thin;background-color:white;width:100%;"">"
            html &= "<thead>"
            html &= "<tr>"
            html &= "<th>Truck No</th>"
            html &= "<th>Revenue</th>"
            html &= "<th>Service/Transport</th>"
            html &= "<th>Advance</th>"
            html &= "<th>Cost</th>"
            html &= "<th>Cost-Fuel</th>"
            html &= "<th>Profit</th>"
            html &= "<th>Trip<br/>Count</th>"
            html &= "</tr>"
            html &= "</thead>"
            html &= "<tbody>"
            If oTbl.Rows.Count > 0 Then
                Dim currYear = oTbl.Rows(0)("Yearly").ToString() & " / " & oTbl.Rows(0)("Monthly").ToString()
                html &= "<tr class=""groupheader"">"
                html &= "<td>" & currYear & "</td>"
                html &= "<td colspan=""7""></td>"
                html &= "</tr>"
                Dim sumValues(7) As Double
                Dim rowCount = 0
                For Each dr As DataRow In oTbl.Rows
                    rowCount += 1
                    If currYear <> dr("Yearly").ToString() & " / " & dr("Monthly").ToString() Then
                        If rowCount > 1 Then
                            html &= "<tr class=""grouptotal number"">"
                            html &= "<td>" & currYear & "</td>"
                            For i As Integer = 0 To 6
                                If i = 6 Then
                                    html &= "<td>" & sumValues(i).ToString("0") & "</td>"
                                Else
                                    html &= "<td>" & sumValues(i).ToString("#,###,##0.00") & "</td>"
                                End If
                            Next
                            html &= "</tr>"
                        End If

                        currYear = dr("Yearly").ToString() & " / " & dr("Monthly").ToString()

                        html &= "<tr class=""groupheader"">"
                        html &= "<td>" & currYear & "</td>"
                        html &= "<td colspan=""7""></td>"
                        html &= "</tr>"

                        For i As Integer = 0 To 6
                            sumValues(i) = 0
                        Next
                    End If

                    html &= "<tr class=""number"">"
                    html &= "<td>" & dr("TruckNo").ToString() & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("TotalRevenue")).ToString("#,###,##0.00") & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("TotalService")).ToString("#,###,##0.00") & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("TotalAdvance")).ToString("#,###,##0.00") & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("TotalCost")).ToString("#,###,##0.00") & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("TotalFuel")).ToString("#,###,##0.00") & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("TotalProfit")).ToString("#,###,##0.00") & "</td>"
                    html &= "<td>" & Convert.ToDouble(dr("CountTrip")).ToString("0") & "</td>"
                    html &= "</tr>"
                    sumValues(0) += Convert.ToDouble(dr(3))
                    sumValues(1) += Convert.ToDouble(dr(4))
                    sumValues(2) += Convert.ToDouble(dr(5))
                    sumValues(3) += Convert.ToDouble(dr(6))
                    sumValues(4) += Convert.ToDouble(dr(7))
                    sumValues(5) += Convert.ToDouble(dr(8))
                    sumValues(6) += Convert.ToDouble(dr(9))
                    If rowCount = oTbl.Rows.Count Then
                        html &= "<tr class=""grouptotal number"">"
                        html &= "<td>" & currYear & "</td>"
                        html &= "<td>" & sumValues(0).ToString("#,###,##0.00") & "</td>"
                        html &= "<td>" & sumValues(1).ToString("#,###,##0.00") & "</td>"
                        html &= "<td>" & sumValues(2).ToString("#,###,##0.00") & "</td>"
                        html &= "<td>" & sumValues(3).ToString("#,###,##0.00") & "</td>"
                        html &= "<td>" & sumValues(4).ToString("#,###,##0.00") & "</td>"
                        html &= "<td>" & sumValues(5).ToString("#,###,##0.00") & "</td>"
                        html &= "<td>" & sumValues(6).ToString("0") & "</td>"
                        html &= "</tr>"

                    End If
                Next
            End If
            html &= "</tbody>"
            html &= "</table>"
            ViewBag.DataGrid1 = html
            Return GetView("Summary", "MODULE_CLR")
        End Function
    End Class
End Namespace