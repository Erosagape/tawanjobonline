Imports System.Web.Http
Imports System.Web.Mvc
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net

Namespace Controllers
    Public Class AdvController
        Inherits CController
        ' GET: Advance
        Function Index() As ActionResult
            Main.DBExecute(GetSession("ConnJob"), Main.SQLUpdateAdvStatus())
            Return GetView("Index", "MODULE_ADV")
        End Function
        Function Approve() As ActionResult
            Return GetView("Approve", "MODULE_ADV")
        End Function
        Function FormClrAdv() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If
            Return GetView("FormClrAdv")
        End Function
        Function Payment() As ActionResult
            Return GetView("Payment", "MODULE_ADV")
        End Function
        Function CreditAdv() As ActionResult
            Return GetView("CreditAdv", "MODULE_ADV")
        End Function
        Function EstimateCost() As ActionResult
            Return GetView("EstimateCost", "MODULE_ADV")
        End Function
        Function GetClearExpFromQuo() As ActionResult
            Try
                Dim tSqlW As String = " WHERE j.JNo<>'' "
                Dim branch As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    branch = Request.QueryString("Branch").ToString
                    tSqlW &= String.Format(" AND j.BranchCode='{0}'", branch)
                End If
                Dim job As String = ""
                If Not IsNothing(Request.QueryString("Job")) Then
                    job = Request.QueryString("Job").ToString
                    tSqlW &= String.Format(" AND j.JNo='{0}'", job)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectExpenseFromQuo() & tSqlW)
                If oData.Rows.Count > 0 Then
                    For Each row As DataRow In oData.Rows
                        Dim oRow As New CClearExp(GetSession("ConnJob")) With {
                            .BranchCode = row("BranchCode").ToString,
                            .JNo = row("JNo").ToString,
                            .SICode = row("SICode").ToString,
                            .SDescription = row("NameThai").ToString,
                            .TRemark = row("TRemark").ToString,
                            .Status = If(row("IsRequired").ToString = "1", "R", "O"),
                            .CurrencyCode = row("CurrencyCode").ToString,
                            .ExchangeRate = row("CurrencyRate"),
                            .AmountCharge = row("ChargeAmt"),
                            .Qty = row("QtyBegin"),
                            .QtyUnit = row("UnitCheck").ToString,
                            .AmtVatRate = row("VatRate"),
                            .AmtVat = row("VatAmt"),
                            .AmtWhtRate = row("TaxRate"),
                            .AmtWht = row("TaxAmt"),
                            .AmtTotal = row("TotalAmt")
                        }
                        Dim msg = oRow.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}' AND SICode='{2}'", oRow.BranchCode, oRow.JNo, oRow.SICode))
                    Next
                End If
                Dim oRows = New CClearExp(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}' ", branch, job))
                Dim json = JsonConvert.SerializeObject(oRows)
                json = "{""estimate"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearExpFromQuo", ex.Message, ex.StackTrace, True)
                Return Content("{""estimate"":{""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetClearExpReport() As ActionResult
            Try
                Dim tSqlw As String = " WHERE a.JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND a.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format("AND a.JNo ='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND a.SICode ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Group")) Then
                    tSqlw &= String.Format("AND s.GroupCode ='{0}' ", Request.QueryString("Group").ToString)
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw &= String.Format("AND (CASE WHEN b.ClrNo IS NOT NULL THEN 'CLR' ELSE 'NOCLR' END)='{0}' ", Request.QueryString("Status").ToString)
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    Select Case Request.QueryString("Type").ToString
                        Case "1"
                            tSqlw &= "AND s.IsExpense=0 AND s.IsCredit=1 "
                        Case "2"
                            tSqlw &= "AND s.IsExpense=1 "
                        Case "3"
                            tSqlw &= "AND s.IsExpense=0 AND s.IsCredit=0 "
                    End Select
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectClearExp() & tSqlw)
                Dim json = JsonConvert.SerializeObject(oData)
                json = "{""estimate"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearExpReport", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetClearExp() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format("AND JNo ='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND SICode ='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CClearExp(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""estimate"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearExp", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function CopyClearExp() As ActionResult
            Dim msg As String = ""
            Try
                Dim cliteria = Request.QueryString("cliteria").ToString()
                Dim jobSource = cliteria.Split("=")(0)
                Dim jobDest = cliteria.Split("=")(1)
                Dim oSrc = New CClearExp(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode+'|'+JNo='{0}'", jobSource))
                For Each oRow In oSrc
                    Dim oDesc = New CClearExp(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode+'|'+JNo='{0}' AND SICode='{1}' ", jobDest, oRow.SICode))
                    Dim oRec = New CClearExp(GetSession("ConnJob"))
                    If oDesc.Count > 0 Then
                        oRec = oDesc(0)
                    Else
                        oRec.BranchCode = jobDest.Split("|")(0).Trim()
                        oRec.SICode = oRow.SICode
                        oRec.JNo = jobDest.Split("|")(1).Trim()
                    End If
                    oRec.SDescription = oRow.SDescription
                    oRec.AmountCharge = oRow.AmountCharge
                    oRec.TRemark = oRow.TRemark
                    oRec.Status = oRow.Status
                    oRec.CurrencyCode = oRow.CurrencyCode
                    oRec.ExchangeRate = oRow.ExchangeRate
                    oRec.Qty = oRow.Qty
                    oRec.QtyUnit = oRow.QtyUnit
                    oRec.AmtVatRate = oRow.AmtVatRate
                    oRec.AmtVat = oRow.AmtVat
                    oRec.AmtWhtRate = oRow.AmtWhtRate
                    oRec.AmtWht = oRow.AmtWht
                    oRec.AmtTotal = oRow.AmtTotal

                    msg &= "<br/>" & oRec.SaveData(String.Format(" WHERE BranchCode+'|'+JNo='{0}' AND SICode='{1}' ", jobDest, oRow.SICode))
                Next
                If msg = "" Then msg = "No data to Save"
                msg = "Result:<br/>" & msg
                Return Content(msg, textContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CopyClearExp", ex.Message, ex.StackTrace, True)
                Return Content("[ERROR] " + ex.Message, textContent)
            End Try
        End Function
        Function SetClearExp(<FromBody()> data As CClearExp) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.JNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input job""}}", jsonContent)
                    End If
                    If "" & data.SICode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input code""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE SICode='{0}' AND BranchCode='{1}' AND JNo='{2}' ", data.SICode, data.BranchCode, data.JNo))
                    Dim json = "{""result"":{""data"":""" & data.SICode & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetClearExp", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelClearExp() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "

                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode = '{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""estimate"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format("AND JNo = '{0}' ", Request.QueryString("Job").ToString)
                Else
                    Return Content("{""estimate"":{""result"":""Please input job"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND SICode = '{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData As New CClearExp(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""estimate"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelClearExp", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function FormCreditAdv() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "CreditAdv")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If
            Return GetView("FormCreditAdv")
        End Function
        Function FormAdv() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If
            Return GetView("FormAdv")
        End Function
        Function FormEstimate() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "EstimateCost")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If
            Return GetView("FormEstimate")
        End Function
        Function PaymentAdvance(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                If AuthorizeStr.IndexOf("I") < 0 Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If

                If IsNothing(data) Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If

                Dim json As String = ""
                Dim lst As String = ""
                Dim user As String = ""
                Dim docno As String = ""
                Dim i As Integer = 0
                For Each str As String In data
                    i += 1
                    If i = 1 Then
                        user = str.Split("|")(0)
                        docno = str.Split("|")(1)
                    Else
                        If str.IndexOf("|") >= 0 Then
                            If lst <> "" Then lst &= ","
                            lst &= "'" & str & "'"
                        End If
                    End If
                Next

                If lst <> "" Then
                    Dim tSQL As String = String.Format("UPDATE Job_AdvHeader SET DocStatus=(CASE WHEN DocStatus<=2 THEN 3 ELSE DocStatus END),PaymentRef='" & docno & "',PaymentBy='" & user & "',PaymentDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',PaymentTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE BranchCode+'|'+AdvNo in({0}) AND DocStatus<>99", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_PaymentHeader SET PaymentRef='" & docno & "',PaymentBy='" & user & "',PaymentDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',PaymentTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE NOT ISNULL(CancelProve,'')<>'' AND BranchCode+'|'+AdvRef in({0})", lst))
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "PaymentAdvance", ex.Message, ex.StackTrace, True)
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End Try
        End Function
        Function ApproveAdvance(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Approve")
                If AuthorizeStr.IndexOf("I") < 0 Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
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
                    Dim tSQL As String = String.Format("UPDATE Job_AdvHeader SET DocStatus=2,ApproveBy='" & user & "',ApproveDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',ApproveTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE DocStatus=1 AND BranchCode+'|'+AdvNo in({0}) AND DocStatus<>99", lst)
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
        Function SaveAdvanceHeader(<FromBody()> ByVal data As CAdvHeader) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))
                    Dim prefix As String = GetValueConfig("RUNNING_FORMAT", "ADV", advPrefix)
                    If data.AdvNo = "" Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                        If data.AdvDate = DateTime.MinValue Then
                            data.AdvDate = Today.Date
                        End If
                        Dim fmt = Main.GetValueConfig("RUNNING", "ADV")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.AdvDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.AdvDate.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.AdvDate.ToString("yy"))
                            End If
                        Else
                            fmt = data.AdvDate.ToString("yyMM") & "____"
                        End If
                        data.AddNew(prefix & fmt)
                    End If

                    If AuthorizeStr.IndexOf("E") < 0 Then
                        Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                    End If

                    Dim msg As String = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND AdvNo='{1}'", data.BranchCode, data.AdvNo))
                    Dim json = "{""result"":{""data"":""" & data.AdvNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SaveAdvanceHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" + ex.Message + """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SaveCustAdvance(<FromBody()> ByVal data As CAdvHeader) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))
                    Dim prefix As String = GetValueConfig("RUNNING_FORMAT", "EXP", expPrefix)
                    If data.AdvNo = "" Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                        If data.AdvDate = DateTime.MinValue Then
                            data.AdvDate = Today.Date
                        End If
                        data.AddNew(prefix & data.AdvDate.ToString("yyMM") & "____")
                    End If

                    If AuthorizeStr.IndexOf("E") < 0 Then
                        Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                    End If

                    Dim msg As String = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND AdvNo='{1}'", data.BranchCode, data.AdvNo))
                    Dim json = "{""result"":{""data"":""" & data.AdvNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SaveCustAdvance", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" + ex.Message + """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetAdvDetail(<FromBody()> ByVal data As List(Of CAdvDetail)) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()

                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                End If

                Dim json As String = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                If IsNothing(data) Then
                    Return Content(json, jsonContent)
                End If

                If "" & data(0).BranchCode = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                End If

                If "" & data(0).AdvNo = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                End If

                If data(0).ItemNo = 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                    If AuthorizeStr.IndexOf("I") < 0 Then
                        Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                    End If
                End If

                Dim i As Integer = 0
                Dim str As String = ""
                Dim branchcode As String = ""
                Dim docno As String = ""
                Dim isUpdatePay As Boolean = False
                For Each o As CAdvDetail In data
                    i += 1
                    branchcode = o.BranchCode
                    docno = o.AdvNo
                    o.SetConnect(GetSession("ConnJob"))
                    If o.STCode = "EXP" And o.PayChqTo.IndexOf("#") > 0 Then
                        If isUpdatePay = False Then
                            Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_PaymentHeader SET AdvRef='{0}' WHERE BranchCode='{1}' AND DocNo='{2}' ", o.AdvNo, o.BranchCode, o.PayChqTo.Split("#".ToCharArray())(0)))
                            isUpdatePay = True
                        End If
                    End If
                    Dim msg = o.SaveData(String.Format(" WHERE BranchCode='{0}' AND AdvNo='{1}' And ItemNo='{2}' ", o.BranchCode, o.AdvNo, o.ItemNo))
                    If str <> "" Then str &= ","
                    str &= msg
                Next

                Dim obj = New CAdvDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' And AdvNo='{1}'", branchcode, docno))
                json = "{""result"":{""msg"":""" & str & """,""data"":""" & docno & """,""document"":[" & JsonConvert.SerializeObject(obj) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetAdvDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""Error!"",""error"":""" & ex.Message & """,""document"":[]}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SaveAdvanceDetail(<FromBody()> ByVal data As CAdvDetail) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))

                    If data.ItemNo = 0 Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                    End If

                    If AuthorizeStr.IndexOf("E") < 0 Then
                        Return Content("{""result"":{""data"":null,""msg"":""You are not allow to save""}}", jsonContent)
                    End If
                    Dim msg As String = ""
                    If data.ForJNo <> "" Then
                        Dim chkDupRows = New CAdvDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND ForJNo='{1}' AND SICode='{2}' AND AdvNo<>'{3}' AND SDescription='{4}' AND AdvNo NOT IN(SELECT AdvNo FROM Job_AdvHeader WHERE DocStatus=99) ", data.BranchCode, data.ForJNo, data.SICode, data.AdvNo, data.SDescription))
                        If chkDupRows.Count > 0 Then
                            If data.SDescription.IndexOf("ซ้ำ") < 0 Then
                                data.SDescription = "**ซ้ำ**" & data.SDescription
                            End If
                            msg &= "This expenses has been advanced in " & chkDupRows(0).AdvNo & "\n"
                        End If
                    End If
                    msg &= data.SaveData(String.Format(" WHERE BranchCode='{0}' AND AdvNo='{1}' AND ItemNo={2} ", data.BranchCode, data.AdvNo, data.ItemNo))
                    'Dim msg = JsonConvert.SerializeObject(data)
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SaveAdvanceDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" + ex.Message + """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelAdvanceDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""adv"":{""result"":""You are not allow to delete""}}", jsonContent)
                End If

                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If
                Dim Docno As String = ""
                Dim tSqlW As String = String.Format(" WHERE BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND AdvNo='" & Request.QueryString("AdvNo").ToString & "'"
                    Docno = Request.QueryString("AdvNo").ToString
                End If

                Dim ItemNo As String = "0"
                If Not IsNothing(Request.QueryString("ItemNo")) Then
                    ItemNo = Request.QueryString("ItemNo").ToString
                End If
                tSqlW &= " AND ItemNo=" & ItemNo & ""

                Dim oADVD = New CAdvDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' And AdvNo='{1}' And ItemNo={2}", Branch, Docno, ItemNo))
                Dim msg As String = "No data to delete"
                If oADVD.Count > 0 Then
                    msg = oADVD(0).DeleteData(tSqlW)
                End If
                Dim json = "{""adv"":{""result"":""" & msg & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelAdvanceDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""adv"":{""result"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelAdvanceHeader() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""adv"":{""result"":""You are not allow to delete""}}", jsonContent)
                End If

                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim tSqlW As String = String.Format(" WHERE BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If

                Dim oAdvH As New CAdvHeader(GetSession("ConnJob"))
                Dim msg As String = oAdvH.DeleteData(tSqlW)
                Dim oAdvD As New CAdvDetail(GetSession("ConnJob"))
                Dim msgD As String = oAdvD.DeleteData(tSqlW)

                Dim json = "{""adv"":{""result"":""" & msg & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelAdvanceHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""adv"":{""result"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function GetNewAdvanceHeader() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("I") < 0 Then
                    Return Content("[]", jsonContent)
                End If

                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim oAdvH As New CAdvHeader(GetSession("ConnJob")) With {
                    .BranchCode = Branch,
                    .AdvNo = "",
                    .AdvDate = DateTime.Today,
                    .DocStatus = 1
                }

                Dim oAdvD As New CAdvDetail(GetSession("ConnJob")) With {
                    .BranchCode = Branch,
                    .AdvNo = "",
                    .ItemNo = 0
                }

                Dim jsonh As String = JsonConvert.SerializeObject(oAdvH)
                Dim jsond As String = JsonConvert.SerializeObject(oAdvD)
                Dim json = "{""adv"":{""header"":" & jsonh & ",""detail"":" & jsond & ",""result"":""OK""}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewAdvanceHeader", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetNewAdvanceDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("I") < 0 Then
                    Return Content("[]", jsonContent)
                End If

                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim AdvNo As String = ""
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    AdvNo = Request.QueryString("AdvNo")
                End If

                Dim oAdvD As New CAdvDetail(GetSession("ConnJob")) With
                    {
                        .BranchCode = Branch,
                        .AdvNo = AdvNo,
                        .ItemNo = 0,
                        .IsDuplicate = 1
                    }

                'Dim msg As String = oAdvD.SaveData(String.Format(" WHERE BranchCode='{0}' And AdvNo='{1}' And ItemNo={2}", oAdvD.BranchCode, oAdvD.AdvNo, oAdvD.ItemNo))
                Dim jsonh As String = JsonConvert.SerializeObject(oAdvD)
                Dim json = "{""adv"":{""detail"":" & jsonh & ",""result"":""OK""}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewAdvanceDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetAdvanceReport() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""adv"":{""data"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim Branch As String = ""
                Dim JobNo As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim tSqlW As String = String.Format(" WHERE a.BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND a.AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("JobNo")) Then
                    tSqlW &= " AND d.ForJNo='" & Request.QueryString("JobNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlW &= " AND d.VenCode='" & Request.QueryString("Vend") & "'"
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND a.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= " AND a.ShipBy=" & Request.QueryString("SBy") & ""
                End If
                If Not IsNothing(Request.QueryString("ReqBy")) Then
                    tSqlW &= " AND a.Empcode='" & Request.QueryString("ReqBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND a.CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustBranch")) Then
                    tSqlW &= " AND a.CustBranch='" & Request.QueryString("CustBranch") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND a.Advdate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND a.Advdate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND a.DocStatus='" & Request.QueryString("Status") & "' "
                Else
                    tSqlW &= " AND a.DocStatus<>99 "
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlW &= " AND b.TaxNumber='" & Request.QueryString("TaxNumber") & "' "
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlW &= " AND a.SubCurrency='" & Request.QueryString("Currency") & "' "
                End If
                If Not IsNothing(Request.QueryString("AdvType")) Then
                    tSqlW &= " AND a.AdvType IN(" & Request.QueryString("AdvType") & ") "
                Else
                    tSqlW &= " AND a.AdvType IN(1,2,3,4) "
                End If
                Dim sql As String = SQLSelectAdvDetail()
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql + tSqlW + " ORDER BY a.AdvDate DESC")
                Dim json = "{""adv"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvanceReport", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetAdvanceGrid() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""adv"":{""data"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim Branch As String = ""
                Dim JobNo As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim tSqlW As String = String.Format(" WHERE a.BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("JobNo")) Then
                    tSqlW &= " AND a.AdvNo IN(SELECT AdvNo FROM Job_AdvDetail WHERE BranchCode='" & Branch & "' And ForJNo='" & Request.QueryString("JobNo") & "')"
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND a.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= " AND a.ShipBy=" & Request.QueryString("SBy") & ""
                End If
                If Not IsNothing(Request.QueryString("ReqBy")) Then
                    tSqlW &= " AND a.Empcode='" & Request.QueryString("ReqBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("AdvBy")) Then
                    tSqlW &= " AND a.AdvBy='" & Request.QueryString("AdvBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND a.CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustBranch")) Then
                    tSqlW &= " AND a.CustBranch='" & Request.QueryString("CustBranch") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND a.Advdate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND a.Advdate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("PayDateFrom")) Then
                    tSqlW &= " AND a.PayChqDate>='" & Request.QueryString("PayDateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("PayDateTo")) Then
                    tSqlW &= " AND a.PayChqDate<='" & Request.QueryString("PayDateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND a.DocStatus='" & Request.QueryString("Status") & "' "
                Else
                    'tSqlW &= " AND a.DocStatus<>99 "
                End If

                If Not IsNothing(Request.QueryString("Show")) Then

                    If Request.QueryString("Show").ToString() = "ACTIVE" Then
                        tSqlW &= " AND a.DocStatus<>99 "
                    End If
                    If Request.QueryString("Show").ToString() = "CANCEL" Then
                        tSqlW &= " AND a.DocStatus=99 "
                    End If
                    If Request.QueryString("Show").ToString() = "NOPAY" Then
                        tSqlW &= " AND ISNULL(a.PaymentBy,'')='' AND a.DocStatus<>99 "
                    End If
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlW &= " AND b.TaxNumber='" & Request.QueryString("TaxNumber") & "' "
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlW &= " AND a.SubCurrency='" & Request.QueryString("Currency") & "' "
                End If
                If Not IsNothing(Request.QueryString("AdvType")) Then
                    tSqlW &= " AND a.AdvType IN(" & Request.QueryString("AdvType") & ") "
                Else
                    tSqlW &= " AND a.AdvType IN(1,2,3,4) "
                End If
                Dim sql As String = SQLSelectAdvHeader()
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql + tSqlW + " ORDER BY a.AdvDate DESC")
                Dim json = "{""adv"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvanceGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetAdvanceGridSummary() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""adv"":{""data"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim Branch As String = ""
                Dim JobNo As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim tSqlW As String = String.Format(" WHERE a.BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("JobNo")) Then
                    tSqlW &= " AND a.AdvNo IN(SELECT AdvNo FROM Job_AdvDetail WHERE BranchCode='" & Branch & "' And ForJNo='" & Request.QueryString("JobNo") & "')"
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND a.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= " AND a.ShipBy=" & Request.QueryString("SBy") & ""
                End If
                If Not IsNothing(Request.QueryString("ReqBy")) Then
                    tSqlW &= " AND a.Empcode='" & Request.QueryString("ReqBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("AdvBy")) Then
                    tSqlW &= " AND a.AdvBy='" & Request.QueryString("AdvBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND a.CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustBranch")) Then
                    tSqlW &= " AND a.CustBranch='" & Request.QueryString("CustBranch") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND a.Advdate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND a.Advdate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("PayDateFrom")) Then
                    tSqlW &= " AND a.PayChqDate>='" & Request.QueryString("PayDateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("PayDateTo")) Then
                    tSqlW &= " AND a.PayChqDate<='" & Request.QueryString("PayDateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND a.DocStatus='" & Request.QueryString("Status") & "' "
                Else
                    'tSqlW &= " AND a.DocStatus<>99 "
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString() = "ACTIVE" Then
                        tSqlW &= " AND a.DocStatus<>99 "
                    Else
                        tSqlW &= " AND a.DocStatus=99 "
                    End If
                End If
                If Not IsNothing(Request.QueryString("Currency")) Then
                    tSqlW &= " AND a.SubCurrency='" & Request.QueryString("Currency") & "' "
                End If
                If Not IsNothing(Request.QueryString("AdvType")) Then
                    tSqlW &= " AND a.AdvType IN(" & Request.QueryString("AdvType") & ") "
                Else
                    tSqlW &= " AND a.AdvType IN(1,2,3,4) "
                End If
                Dim sql As String = SQLSelectAdvanceTotalEmp(tSqlW)
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                Dim json = "{""adv"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvanceGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function

        Function GetAdvance() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""adv"":{""header"":[],""detail"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim oAdvH As New CAdvHeader(GetSession("ConnJob"))
                Dim oADVD As New CAdvDetail(GetSession("ConnJob"))
                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If
                Dim tSqlW As String = String.Format(" WHERE BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If

                Dim oDataH = oAdvH.GetData(tSqlW)
                Dim oDataD = oADVD.GetData(tSqlW)

                Dim jsonh As String = JsonConvert.SerializeObject(oDataH)
                Dim jsond As String = JsonConvert.SerializeObject(oDataD)
                Dim json = "{""adv"":{""header"":" & jsonh & ",""detail"":" & jsond & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvance", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""header"":[],""detail"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetAdvanceClear() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
            If AuthorizeStr.IndexOf("R") < 0 Then
                Return Content("{""adv"":{""header"":[],""detail"":[],""msg"":""You are not allow to view""}}", jsonContent)
            End If
            Try
                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If
                Dim tSqlW As String = String.Format(" AND a.BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND a.AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If
                Dim oDataH = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectAdvSumClear(tSqlW))
                Dim oDataD = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectAdvClear(tSqlW))
                Dim jsonh As String = JsonConvert.SerializeObject(oDataH)
                Dim jsond As String = JsonConvert.SerializeObject(oDataD)
                Dim json = "{""adv"":{""header"":" & jsonh & ",""detail"":" & jsond & "}}"
                Return Content(json, jsonContent)

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvanceClear", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""header"":[],""detail"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetAdvanceForWht() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""adv"":{""detail"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                Else
                    Return Content("{""adv"":{""detail"":[],""msg"":""Please enter some data""}}", jsonContent)
                End If

                Dim tSqlW As String = String.Format(" AND BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If

                Dim oDataD = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectAdvForWhTax(tSqlW))
                Dim jsond As String = JsonConvert.SerializeObject(oDataD)

                Dim json = "{""adv"":{""detail"":" & jsond & "}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvanceDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""detail"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetAdvanceDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""adv"":{""detail"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim oADVD As New CAdvDetail(GetSession("ConnJob"))
                Dim Branch As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                Else
                    Return Content("{""adv"":{""detail"":[],""msg"":""Please enter some data""}}", jsonContent)
                End If

                Dim tSqlW As String = String.Format(" WHERE BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlW &= " AND AdvNo IN(SELECT AdvNo FROM Job_AdvHeader WHERE BranchCode='" & Branch & "' AND CustCode IN(SELECT CustCode FROM Mas_Company WHERE TaxNumber='" & Request.QueryString("TaxNumber") & "'))"
                End If

                Dim oDataD = oADVD.GetData(tSqlW)
                Dim jsond As String = JsonConvert.SerializeObject(oDataD)
                Dim oDataH = New CAdvHeader(GetSession("ConnJob")).GetData(tSqlW)
                Dim jsonh As String = JsonConvert.SerializeObject(oDataH)

                Dim json = "{""adv"":{""detail"":" & jsond & ",""header"":" & jsonh & "}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvanceDetail", ex.Message, ex.StackTrace, True)
                Return Content("{""adv"":{""detail"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function UpdateAdvStatus() As ActionResult
            Main.DBExecute(GetSession("ConnJob"), Main.SQLUpdateAdvStatus())
            Return Content("OK", textContent)
        End Function
    End Class
End Namespace