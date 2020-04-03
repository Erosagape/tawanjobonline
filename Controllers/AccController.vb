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
            Return View()
        End Function
        '-----Controller-----
        Function Voucher() As ActionResult
            Return GetView("Voucher", "MODULE_ACC")
        End Function
        Function WHTax() As ActionResult
            Return GetView("WHTax", "MODULE_ACC")
        End Function
        Function FormWTax3() As ActionResult
            Return GetView("FormWTax3")
        End Function
        Function FormWTax53() As ActionResult
            Return GetView("FormWTax53")
        End Function
        Function FormWTax3D() As ActionResult
            Return GetView("FormWTax3D")
        End Function
        Function FormWTax53D() As ActionResult
            Return GetView("FormWTax53D")
        End Function
        Function Approve() As ActionResult
            Return GetView("Approve", "MODULE_ACC")
        End Function
        Function ApproveExpense(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = Session("CurrUser").ToString()
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
                For Each str As String In data
                    If str.IndexOf("|") >= 0 Then
                        If lst <> "" Then lst &= ","
                        lst &= "'" & str & "'"
                    Else
                        user = str
                    End If
                Next

                If lst <> "" Then
                    Dim tSQL As String = String.Format("UPDATE Job_PaymentHeader SET ApproveBy='" & user & "',ApproveDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',ApproveTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE BranchCode+'|'+DocNo in({0})", lst)
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

                Dim oData = New CPayHeader(GetSession("ConnJob")).GetData(tSqlw & " AND NOT ISNULL(AdvRef,'')<>''")
                Dim json As String = JsonConvert.SerializeObject(oData)
                Dim oDataD = New CPayDetail(GetSession("ConnJob")).GetData(tSqlw & " AND AdvItemNo=0 ")
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)

                json = "{""payment"":{""header"":" & json & ",""detail"":" & jsonD & "}}"
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
                        tSqlH &= String.Format(" AND NOT (DocNo IN(SELECT p.DocNo FROM (SELECT h.DocNo FROM Job_CashControlDoc h INNER JOIN Job_CashControlSub d ON h.BranchCode=d.BranchCode AND h.ControlNo=d.ControlNo AND h.acType=d.acType WHERE h.DocType='PAY' AND d.PRType='P' AND h.BranchCode='{0}') p  )", Request.QueryString("Branch").ToString)
                        tSqlH &= String.Format(" OR DocNo IN(SELECT DISTINCT p.PaymentNo FROM (SELECT h.PaymentNo FROM Job_AdvHeader h WHERE h.DocStatus<>99 AND h.BranchCode='{0}') p WHERE p.PaymentNo IS NOT NULL))", Request.QueryString("Branch").ToString)
                    End If
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    If Request.QueryString("Status").ToString = "A" Then
                        tSqlH &= " AND ISNULL(ApproveBy,'')<>'' "
                    End If
                    If Request.QueryString("Status").ToString = "R" Then
                        tSqlH &= " AND ISNULL(ApproveBy,'')='' "
                    End If
                    tSqlH &= " AND NOT ISNULL(CancelProve,'')<>'' "
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
        Function GetPaymentGrid() As ActionResult
            Try
                Dim tSqlw As String = SQLSelectPaymentReport() & " WHERE h.DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.DocNo='{0}' ", Request.QueryString("Code").ToString)
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
                        tSqlw &= String.Format(" AND NOT (h.DocNo IN(SELECT p.DocNo FROM (SELECT hd.DocNo FROM Job_CashControlDoc hd INNER JOIN Job_CashControlSub dt ON hd.BranchCode=dt.BranchCode AND hd.ControlNo=dt.ControlNo AND hd.acType=dt.acType WHERE hd.DocType='PAY' AND dt.PRType='P' AND hd.BranchCode='{0}') p  )", Request.QueryString("Branch").ToString)
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.DocNo = "" Then
                        data.AddNew(payPrefix & Now.ToString("yyMM") & "-____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""payment"":{""result"":""Please Select Some branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""payment"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Document""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))

                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2} ", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"

                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""payment"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo='{0}' ", Request.QueryString("Code").ToString)
                    oData.DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""payment"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                    oData.ItemNo = Convert.ToInt32(Request.QueryString("Item").ToString)
                Else
                    Return Content("{""payment"":{""result"":""Please Select Some Item"",""data"":[]}}", jsonContent)
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
            Try
                If Not Request.QueryString("branch") Is Nothing Then
                    If Not Request.QueryString("code") Is Nothing Then
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
            Return GetView("FormInv")
        End Function
        Function FormBill() As ActionResult
            Return GetView("FormBill")
        End Function
        Function FormRcp() As ActionResult
            Try
                If Not Request.QueryString("branch") Is Nothing Then
                    If Not Request.QueryString("code") Is Nothing Then
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
            Return GetView("FormRcp")
        End Function
        Function FormTaxInv() As ActionResult
            Try
                If Not Request.QueryString("branch") Is Nothing Then
                    If Not Request.QueryString("code") Is Nothing Then
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

            Return GetView("FormTaxInv")
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If
                    If data.ItemNo = 0 Then
                        data.AddNew()
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2} ", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""creditnote"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND DocNo Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""creditnote"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""creditnote"":{""result"":""Please Select Branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}'", Request.QueryString("Code").ToString)
                    oData.DocNo = Request.QueryString("Code").ToString
                    oDataD.DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""creditnote"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data.GLRefNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND GLRefNo='{1}' AND ItemNo={2} ", data.BranchCode, data.GLRefNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""journal"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND GLRefNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please Select Some Item"",""data"":[]}}", jsonContent)
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.GLRefNo = "" Then
                        data.AddNew(data.GLType & data.BatchDate.ToString("yyMM") & "____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND GLRefNo='{1}' ", data.BranchCode, data.GLRefNo))
                    Dim json = "{""result"":{""data"":""" & data.GLRefNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""journal"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND GLRefNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""journal"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
            ViewBag.User = Session("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Expense")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print expenses", textContent)
            End If

            Return GetView("FormExpense")
        End Function
        Function FormVoucher() As ActionResult
            ViewBag.User = Session("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print voucher", textContent)
            End If

            Return GetView("FormVoucher")
        End Function
        Function FormWHTax() As ActionResult
            ViewBag.User = Session("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print wh-tax form", textContent)
            End If

            Return GetView("FormWHTax")
        End Function
        Function GetVoucherGrid() As ActionResult
            Try
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("R") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("R") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""msg"":""You are not authorize to read""}}", jsonContent)
                        End If
                    End If
                End If

                Dim tSqlw As String = SQLSelectVoucher()
                tSqlw &= " WHERE h.ControlNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND d.ForJNo ='{0}'", Request.QueryString("Job").ToString)
                End If
                If IsNothing(Request.QueryString("Cancel")) Then
                    tSqlw &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                Else
                    tSqlw &= String.Format(" AND ISNULL(h.CancelProve,'')='{0}' ", Request.QueryString("Cancel").ToString())
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
                            tSqlw &= " AND d.DocNo Like '" & expPrefix & "%' "
                    End Select
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData.AsEnumerable().ToList())
                Dim json = "{""voucher"":{""data"":" & oHead & ",""msg"":""Complete!""}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucherGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetVoucherReport() As ActionResult
            Try
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("R") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("R") < 0 Then
                            Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""You are not authorize to read""}}", jsonContent)
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

                Dim oData = New CVoucher(GetSession("ConnJob")).GetData(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData)
                Dim oSub As String = JsonConvert.SerializeObject(New CVoucherSub(GetSession("ConnJob")).GetData(tSqlw))
                Dim oDoc As String = JsonConvert.SerializeObject(New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectVoucherDoc(tSqlw)))

                Dim json = "{""voucher"":{""header"":" & oHead & ",""payment"":" & oSub & ",""document"":" & oDoc & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucher", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function

        Function GetVoucher() As ActionResult
            Try
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("R") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("R") < 0 Then
                            Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""You are not authorize to read""}}", jsonContent)
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

                Dim oData = New CVoucher(GetSession("ConnJob")).GetData(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData)
                Dim oSub As String = JsonConvert.SerializeObject(New CVoucherSub(GetSession("ConnJob")).GetData(tSqlw))
                Dim oDoc As String = JsonConvert.SerializeObject(New CVoucherDoc(GetSession("ConnJob")).GetData(tSqlw))

                Dim json = "{""voucher"":{""header"":" & oHead & ",""payment"":" & oSub & ",""document"":" & oDoc & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetVoucher", ex.Message, ex.StackTrace, True)
                Return Content("{""voucher"":{""header"":null,""payment"":null,""document"":null,""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function SetVoucherHeader(<FromBody()> data As CVoucher) As ActionResult
            Try
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("E") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("E") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to edit voucher""}}", jsonContent)
                        End If
                    End If
                End If

                If Not IsNothing(data) Then

                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If

                    data.SetConnect(GetSession("ConnJob"))

                    If "" & data.ControlNo = "" Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                            If AuthorizeStr.IndexOf("I") < 0 Then
                                AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                                If AuthorizeStr.IndexOf("I") < 0 Then
                                    Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to add voucher""}}", jsonContent)
                                End If
                            End If
                        End If
                        If data.VoucherDate = DateTime.MinValue Then
                            data.VoucherDate = Today.Date
                        End If
                        data.AddNew(data.VoucherDate.ToString("yyMM") & "-___")
                    End If
                    Dim tSql As String = String.Format(" WHERE BranchCode='{0}' AND  ControlNo='{1}' ", data.BranchCode, data.ControlNo)
                    Dim msg = data.SaveData(tSql)
                    Dim json = "{""result"":{""data"":""" & data.ControlNo & """,""msg"":""" & msg & """}}"

                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("E") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("E") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to edit detail""}}", jsonContent)
                        End If
                    End If
                End If

                Dim json As String = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
                If IsNothing(data) Then
                    Return Content(json, jsonContent)
                End If

                If "" & data(0).BranchCode = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                End If

                If "" & data(0).ControlNo = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                End If

                If data(0).ItemNo = 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                    If AuthorizeStr.IndexOf("I") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                            If AuthorizeStr.IndexOf("I") < 0 Then
                                Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to add detail""}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("E") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("E") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to edit document""}}", jsonContent)
                        End If
                    End If
                End If

                Dim json As String = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
                If IsNothing(data) Then
                    Return Content(json, jsonContent)
                End If

                If "" & data(0).BranchCode = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                End If

                If "" & data(0).ControlNo = "" Then
                    Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                End If

                If data(0).ItemNo = 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                    If AuthorizeStr.IndexOf("I") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                            If AuthorizeStr.IndexOf("I") < 0 Then
                                Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to add document""}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("D") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("D") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""result"":""You are not authorize to delete document""}}", jsonContent)
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
                    Return Content("{""voucher"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If

                If IsNothing(Request.QueryString("Item")) Then
                    Return Content("{""voucher"":{""result"":""Please Select Some Item"",""data"":[]}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("D") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("D") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""result"":""You are not authorize to delete document""}}", jsonContent)
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
                    Return Content("{""voucher"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If

                If IsNothing(Request.QueryString("Item")) Then
                    Return Content("{""voucher"":{""result"":""Please Select Some Item"",""data"":[]}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Voucher")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ADV", "Payment")
                    If AuthorizeStr.IndexOf("D") < 0 Then
                        AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
                        If AuthorizeStr.IndexOf("D") < 0 Then
                            Return Content("{""voucher"":{""data"":null,""result"":""You are not authorize to delete""}}", jsonContent)
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
                    Return Content("{""voucher"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""whtax"":{""header"":null,""detail"":null,""msg"":""You are not authorize to read""}}", jsonContent)
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
        Function GetWHTaxGrid() As ActionResult
            Try
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""whtax"":{""data"":null,""msg"":""You are not authorize to read""}}", jsonContent)
                End If

                Dim tSqlw As String = SQLSelectWHTax()

                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" WHERE h.BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                Else
                    tSqlw &= " WHERE NOT ISNULL(h.CancelProve,'')<>'' "
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.DocNo ='{0}'", Request.QueryString("Code").ToString)
                End If

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(tSqlw)
                Dim oHead As String = JsonConvert.SerializeObject(oData.AsEnumerable().ToList())
                Dim json = "{""whtax"":{""data"":" & oHead & ",""msg"":""Complete!""}}"

                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetWHTaxGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""whtax"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function

        Function SetWHTaxHeader(<FromBody()> data As CWHTaxHeader) As ActionResult
            Try
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to edit""}}", jsonContent)
                End If

                If Not IsNothing(data) Then

                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If

                    data.SetConnect(GetSession("ConnJob"))

                    If "" & data.DocNo = "" Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to add""}}", jsonContent)
                        End If
                        If data.DocDate = DateTime.MinValue Then
                            data.DocDate = Today.Date
                        End If
                        data.AddNew(whtPrefix & data.DocDate.ToString("yyMM") & "-____")
                    End If

                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"

                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""whtax"":{""data"":null,""result"":""You are not authorize to delete""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode Like '{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""whtax"":{""detail"":null,""msg"":""You are not authorize to read""}}", jsonContent)
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to edit""}}", jsonContent)
                End If

                If Not IsNothing(data) Then

                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If

                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If

                    If data.ItemNo = 0 Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""You are not authorize to add""}}", jsonContent)
                        End If
                    End If

                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo={2} ", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                ViewBag.User = Session("CurrUser").ToString()
                Dim AuthorizeStr = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "WHTax")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""whtax"":{""data"":null,""result"":""You are not authorize to delete""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo ='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("ItemNo")) Then
                    tSqlw &= String.Format("AND ItemNo ='{0}' ", Request.QueryString("ItemNo").ToString)
                Else
                    Return Content("{""whtax"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                    Dim oJob = New CJobOrder(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND JNo IN(SELECT JobNo FROM Job_ClearDetail WHERE BranchCode='{0}' AND LinkBillNo='{1}')", oDet(0).BranchCode, oDet(0).DocNo))
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.DocNo = "" Then
                        If data.DocType = "" Then
                            data.DocType = invPrefix
                        End If
                        If data.DocDate = DateTime.MinValue Then
                            data.DocDate = Today
                        End If
                        data.AddNew(data.DocType & data.DocDate.ToString("yyMM") & "____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", data.BranchCode, data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""invheader"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                Dim DocNo As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}' ", Request.QueryString("Code").ToString)
                    DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""invheader"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                json = "{""billheader"":{""data"":" & json & "}}"
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.BillAcceptNo = "" Then
                        If data.BillDate = DateTime.MinValue Then
                            data.BillDate = Today.Date
                        End If
                        data.AddNew(billPrefix & data.BillDate.ToString("yyMM") & "____")
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
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""billheader"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo Like '{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""billheader"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.ReceiptNo = "" Then
                        If data.ReceiptDate = DateTime.MinValue Then
                            data.ReceiptDate = Today.Date
                        End If
                        Select Case data.ReceiptType
                            Case "REC"
                                data.AddNew("RC-" & data.ReceiptDate.ToString("yyMM") & "___")
                            Case "TAX"
                                data.AddNew("TX-" & data.ReceiptDate.ToString("yyMM") & "___")
                            Case "SRV"
                                data.AddNew("SV-" & data.ReceiptDate.ToString("yyMM") & "___")
                            Case "RCV"
                                data.AddNew("RV-" & data.ReceiptDate.ToString("yyMM") & "___")
                            Case "ADV"
                                data.AddNew("AV-" & data.ReceiptDate.ToString("yyMM") & "___")
                            Case Else
                                Return Content("{""result"":{""data"":null,""msg"":""Please Enter Receipt Type""}}", jsonContent)
                        End Select
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}' ", data.BranchCode, data.ReceiptNo))
                    Dim json = "{""result"":{""data"":""" & data.ReceiptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""rcpheader"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""rcpheader"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectChequeBalance(chqType) & tSqlw)
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
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectDocumentBalance(prType) & tSqlw)
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
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectClrForInvoice() & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""invdetail"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearForInv", ex.Message, ex.StackTrace, True)
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data(0).DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
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
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data.DocNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' AND ItemNo='{2}'", data.BranchCode, data.DocNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""invdetail"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                Dim DocNo As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}' ", Request.QueryString("Code").ToString)
                    DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""invdetail"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo ='{0}' ", Request.QueryString("Item").ToString)
                End If
                Dim oData As New CInvDetail(GetSession("ConnJob"))
                Dim oRec = oData.GetData(tSqlw)
                If oRec.Count > 0 Then
                    Dim msg = ""
                    For Each doc In oRec
                        msg &= doc.DeleteData(tSqlw) & vbCrLf
                    Next
                    Dim json = "{""invdetail"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oRec(0)) & "]}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""invdetail"":{""result"":""Data Not Found"",""data"":[]}}"
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
                        tSqlw &= " AND ISNULL(id.AmtCharge,0)>0 AND ISNULL(id.AmtVat,0)>0 "
                    End If
                    If Request.QueryString("Type").ToString.ToUpper = "TAX" Then
                        'have advance or have service
                        tSqlw &= " AND ((ISNULL(id.AmtCharge,0)>0 AND ISNULL(id.AmtVat,0)>0) OR ISNULL(id.AmtAdvance,0)>0) "
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
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND a.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND a.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND a.CustCode='{0}' ", Request.QueryString("Cust").ToString)
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
                Dim oDet = New CBillDetail(GetSession("ConnJob")).GetData(" WHERE BillAcceptNo IN(SELECT BillAcceptNo FROM Job_BillAcceptHeader " & tSqlw & ")")

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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
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
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""billdetail"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                Dim Code As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BillAcceptNo ='{0}' ", Request.QueryString("Code").ToString)
                    Code = Request.QueryString("Code").ToString
                Else
                    Return Content("{""billdetail"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
                    Dim json = "{""billdetail"":{""result"":""Data Not Found"",""data"":[]}}"
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data(0).ReceiptNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
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
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Branch""}}", jsonContent)
                    End If
                    If "" & data.ReceiptNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND ReceiptNo='{1}' AND ItemNo='{2}' ", data.BranchCode, data.ReceiptNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ReceiptNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
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
                    Return Content("{""rcpdetail"":{""result"":""Please Select Some Branch"",""data"":[]}}", jsonContent)
                End If
                Dim DocNo As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ReceiptNo Like '{0}' ", Request.QueryString("Code").ToString)
                    DocNo = Request.QueryString("Code").ToString
                Else
                    Return Content("{""rcpdetail"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
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
    End Class
End Namespace