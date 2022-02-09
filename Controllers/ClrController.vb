Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Mvc
Imports Newtonsoft.Json
Namespace Controllers
    Public Class ClrController
        Inherits CController
        ' GET: Clr
        Function Entry() As ActionResult
            LoadCompanyProfile()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
            If AuthorizeStr.IndexOf("M") < 0 Then
                ViewBag.Module = "Clearing Entry"
                Return RedirectToAction("AuthError", "Menu")
            End If
            Return View()
        End Function
        Function Index() As ActionResult
            LoadCompanyProfile()
            Me.UpdateClearStatus()
            Return GetView("Index", "MODULE_CLR")
        End Function
        Function Approve() As ActionResult
            Return GetView("Approve", "MODULE_CLR")
        End Function
        Function FormEntry() As ActionResult
            Return GetView("FormEntry")
        End Function
        Function Receive() As ActionResult
            LoadCompanyProfile()
            Main.UpdateClearStatus()
            Return GetView("Receive", "MODULE_CLR")
        End Function
        Function FormClr() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If
            Return GetView("FormClr")
        End Function
        Function Costing() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_ACC", "Costing")
            If AuthorizeStr.IndexOf("M") < 0 Then
                Return Content("You are not allow to view", textContent)
            End If
            Return GetView("Costing", "MODULE_ACC")
        End Function
        Function GetClearExpFromClr() As ActionResult
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
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectExpenseFromClr() & tSqlW)
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
        Function GenerateInv() As ActionResult
            Return GetView("GenerateInv", "MODULE_ACC")
        End Function
        Function Earnest() As ActionResult
            Return GetView("Earnest", "MODULE_CLR")
        End Function

        '-----Controller-----
        Function ApproveClearing(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Approve")
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
                    Dim tSQL As String = String.Format("UPDATE Job_ClearHeader SET DocStatus=2,ApproveBy='" & user & "',ApproveDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',ApproveTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE DocStatus=1 AND BranchCode+'|'+ClrNo in({0}) AND DocStatus<>99", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "ApproveClearing", ex.Message, ex.StackTrace, True)
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End Try
        End Function
        Function ReceiveEarnest(<FromBody()> data As String()) As HttpResponseMessage
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Earnest")
            If AuthorizeStr.IndexOf("I") < 0 Then
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End If
            If IsNothing(data) Then
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End If

            Dim lst As String = ""
            Dim docno As String = ""
            Dim i As Integer = 0
            For Each str As String In data
                i += 1
                If i = 1 Then
                    docno = str
                Else
                    If str.IndexOf("|") >= 0 Then
                        If lst <> "" Then lst &= ","
                        lst &= "'" & str & "'"
                    End If
                End If
            Next

            If lst <> "" Then
                Dim tSQL As String = String.Format("UPDATE Job_ClearDetail SET LinkBillNo='{0}',LinkItem=1,ChargeVAT=0,Tax50Tavi=0,FNet=0,BNet=0 WHERE BranchCode+'|'+ClrNo+'|'+Convert(varchar,ItemNo) in({1})", docno, lst)
                Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                If result = "OK" Then
                    Main.UpdateClearStatus()
                    Return New HttpResponseMessage(HttpStatusCode.OK)
                End If
            End If
            Return New HttpResponseMessage(HttpStatusCode.NoContent)
        End Function
        Function ReceiveClearing(<FromBody()> data As String()) As HttpResponseMessage
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Receive")
            If AuthorizeStr.IndexOf("I") < 0 Then
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End If
            If IsNothing(data) Then
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End If

            Dim lst As String = ""
            Dim i As Integer = 0
            Dim doctype As String = "CLR"
            Dim user As String = ""
            Dim docno As String = ""
            For Each str As String In data
                i += 1
                If i = 1 Then
                    User = str.Split("|")(0)
                    docno = str.Split("|")(1)
                    doctype = str.Split("|")(2)
                Else
                    If str.IndexOf("|") >= 0 Then
                        If lst <> "" Then lst &= ","
                        lst &= "'" & str & "'"
                    End If
                End If
            Next

            If lst <> "" Then
                If doctype = "CLR" Then
                    Dim tSQL As String = String.Format("UPDATE Job_ClearHeader SET DocStatus=3,ReceiveBy='" & user & "',ReceiveRef='" & docno & "',ReceiveDate=GetDate(),ReceiveTime=Convert(varchar(10),GetDate(),108) WHERE BranchCode+'|'+ClrNo in({0}) AND DocStatus<>99 ", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Main.UpdateClearStatus()
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                If doctype = "ADV" Then
                    Dim tSQL As String = String.Format("UPDATE Job_AdvHeader SET DocStatus=6 WHERE BranchCode+'|'+AdvNo in({0}) AND DocStatus<>99", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Main.DBExecute(GetSession("ConnJob"), Main.SQLUpdateClrReceiveFromAdvance(user, docno, lst))
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If

            End If
            Return New HttpResponseMessage(HttpStatusCode.NoContent)
        End Function
        Function GetClearingReport() As ActionResult
            Dim branch As String = ""
            If Request.QueryString("Branch") IsNot Nothing Then
                branch = Request.QueryString("Branch").ToString
            End If
            Dim sql As String = SQLSelectClrDetail() & String.Format(" WHERE h.BranchCode='{0}' ", branch)
            Try
                If Request.QueryString("Code") IsNot Nothing Then
                    sql &= " AND h.ClrNo='" & Request.QueryString("Code").ToString & "' "
                End If
                If Request.QueryString("Job") IsNot Nothing Then
                    sql &= " AND d.JobNo='" & Request.QueryString("Job").ToString & "' AND h.DocStatus<>99 "
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    sql &= " AND h.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("CFrom")) Then
                    sql &= " AND h.ClearFrom=" & Request.QueryString("CFrom") & ""
                End If
                If Not IsNothing(Request.QueryString("CType")) Then
                    sql &= " AND h.ClearType=" & Request.QueryString("CType") & ""
                End If
                If Not IsNothing(Request.QueryString("ClrBy")) Then
                    sql &= " AND h.EmpCode='" & Request.QueryString("ClrBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    sql &= " AND j.CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Request.QueryString("VenCode") IsNot Nothing Then
                    sql &= " AND d.VenderCode='" & Request.QueryString("VenCode").ToString & "'"
                End If
                If Not IsNothing(Request.QueryString("CustBranch")) Then
                    sql &= " AND j.CustBranch='" & Request.QueryString("CustBranch") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    sql &= " AND h.ClrDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    sql &= " AND h.ClrDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    sql &= " AND h.DocStatus='" & Request.QueryString("Status") & "' "
                Else
                    sql &= " AND h.DocStatus<>99 "
                End If
                If Not IsNothing(Request.QueryString("SICode")) Then
                    sql &= " AND d.SICode='" & Request.QueryString("SICode") & "' "
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    sql &= " AND j.CustCode IN(Select CustCode from Mas_Company where TaxNumber='" & Request.QueryString("TaxNumber") & "') "
                End If
                If Not IsNothing(Request.QueryString("Condition")) Then
                    Select Case Request.QueryString("Condition").ToString()
                        Case "ERN"
                            sql &= " AND d.LinkItem=0 AND d.UsedAmount > 0 "
                    End Select
                End If
                sql &= " ORDER BY h.BranchCode,h.ClrDate DESC,h.ClrNo,j.CustCode,j.CustBranch,d.ItemNo "

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                Dim json = "{""data"":" & JsonConvert.SerializeObject(oData) & "}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearingReport", ex.Message, ex.StackTrace, True)
                Return Content("{""data"":[],""msg"":""" & ex.Message & """}", jsonContent)
            End Try

        End Function
        Function GetClearingSum() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""clr"":{""data"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim Branch As String = ""
                Dim JobNo As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim tSqlW As String = String.Format(" WHERE h.BranchCode='{0}'", Branch)

                Dim tbPrefix = "a"
                If Not IsNothing(Request.QueryString("Data")) Then
                    If Request.QueryString("Data").ToString = "CLR" Then
                        tbPrefix = "h"
                    End If
                End If

                If Not IsNothing(Request.QueryString("ClrNo")) Then
                    tSqlW &= " AND h.ClrNo='" & Request.QueryString("ClrNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND a.AdvNo='" & Request.QueryString("AdvNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("JobNo")) Then
                    If tbPrefix = "a" Then
                        tSqlW &= " AND a.ForJNo='" & Request.QueryString("JobNo") & "'"
                    Else
                        tSqlW &= " AND d.JobNo='" & Request.QueryString("JobNo") & "'"
                    End If
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND " & tbPrefix & ".JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("AdvBy")) Then
                    tSqlW &= " AND " & tbPrefix & ".EmpCode='" & Request.QueryString("AdvBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND " & Replace(tbPrefix, "h", "j") & ".CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustBranch")) Then
                    tSqlW &= " AND " & Replace(tbPrefix, "h", "j") & ".CustBranch='" & Request.QueryString("CustBranch") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND " & IIf(tbPrefix = "a", "a.PaymentDate", "h.ClrDate") & ">='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND " & IIf(tbPrefix = "a", "a.PaymentDate", "h.ClrDate") & "<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If tbPrefix = "a" Then
                    tSqlW &= " AND a.DocStatus<>99 AND a.AdvNo IS NOT NULL  AND h.DocStatus<>99 "
                    tSqlW &= " AND a.AdvNo+'#'+Convert(varchar,a.ItemNo) NOT IN(SELECT c1.DocNo FROM Job_CashControlDoc c1 inner join Job_CashControl c2 on c1.BranchCode=c2.BranchCode and c1.ControlNo=c2.ControlNo where ISNULL(c2.CancelProve,'')='')"
                Else
                    tSqlW &= " AND h.DocStatus<>99 AND a.AdvNo IS NULL AND h.ClearType<>3 "
                    tSqlW &= " AND h.ClrNo+'#'+Convert(varchar,d.ItemNo) NOT IN(SELECT c1.DocNo FROM Job_CashControlDoc c1 inner join Job_CashControl c2 on c1.BranchCode=c2.BranchCode and c1.ControlNo=c2.ControlNo where ISNULL(c2.CancelProve,'')='')"
                    tSqlW &= " AND h.ClrNo+'#'+Convert(varchar,d.ItemNo) NOT IN(SELECT p1.ClrRefNo+'#'+Convert(varchar,p1.ClrItemNo) FROM Job_PaymentDetail p1 INNER JOIN Job_PaymentHeader p2 ON p1.BranchCode=p2.BranchCode AND p1.DocNo=p2.DocNo WHERE ISNULL(p2.CancelProve,'')='' AND p1.ClrRefNo=h.ClrNo AND p1.ClrItemNo=d.ItemNo) "
                End If

                Dim sql As String = If(tbPrefix = "a", SQLSelectClrFromAdvance(), SQLSelectClrNoAdvance())
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "BAL" Then
                        sql &= " having (ISNULL(a.AdvAmount,0)+ISNULL(a.ChargeVAT,0))-sum(d.UsedAmount+d.ChargeVAT)<>0"
                    End If
                End If
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sql, tSqlW))
                Dim json = "{""clr"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearingSum", ex.Message, ex.StackTrace, True)
                Return Content("{""clr"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetClearingGrid() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""clr"":{""data"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim Branch As String = ""
                Dim JobNo As String = ""
                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Branch = Request.QueryString("BranchCode")
                End If

                Dim tSqlW As String = String.Format(" WHERE a.BranchCode='{0}'", Branch)
                If Not IsNothing(Request.QueryString("JobNo")) Then
                    tSqlW &= " AND b.JobNo='" & Request.QueryString("JobNo") & "' "
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND a.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("CFrom")) Then
                    tSqlW &= " AND a.ClearFrom=" & Request.QueryString("CFrom") & ""
                End If
                If Not IsNothing(Request.QueryString("CType")) Then
                    tSqlW &= " AND a.ClearType=" & Request.QueryString("CType") & ""
                End If
                If Not IsNothing(Request.QueryString("ClrBy")) Then
                    tSqlW &= " AND a.EmpCode='" & Request.QueryString("ClrBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND b.CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustBranch")) Then
                    tSqlW &= " AND b.CustBranch='" & Request.QueryString("CustBranch") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND a.ClrDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND a.ClrDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND a.DocStatus='" & Request.QueryString("Status") & "' "
                    'Else
                    'tSqlW &= " AND a.DocStatus<>99 "
                End If
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString() = "ACTIVE" Then
                        tSqlW &= " AND a.DocStatus<>99 "
                    Else
                        tSqlW &= " AND a.DocStatus=99 "
                    End If
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlW &= " AND b.CustCode IN(Select CustCode from Mas_Company where TaxNumber='" & Request.QueryString("TaxNumber") & "') "
                End If

                Dim sql As String = SQLSelectClrHeader() & "{0} ORDER BY a.ClrDate DESC"

                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sql, tSqlW))
                Dim json = "{""clr"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearingGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""clr"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetPaymentForClear() As ActionResult
            Try
                Dim tSqlW As String = ""
                If Not IsNothing(Request.QueryString("Show")) Then
                    tSqlW = " AND d.ClrItemNo=0 AND d.AdvItemNo=0 "
                    If Request.QueryString("Show").ToString = "CLR" Then
                        tSqlW = " AND d.ClrItemNo>0 "
                    End If
                    If Request.QueryString("Show").ToString = "CANCEL" Then
                        tSqlW &= " AND ISNULL(h.CancelProve,'')<>'' "
                    Else
                        tSqlW &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                    End If
                Else
                    tSqlW &= " AND NOT ISNULL(h.CancelProve,'')<>'' "
                End If
                Dim isForCharge As Boolean = False
                If Not IsNothing(Request.QueryString("Type")) Then
                    Select Case Request.QueryString("Type").ToString().ToUpper()
                        Case "ADV"
                            tSqlW &= " AND d.SICode IN(SELECT SICode FROM Job_SrvSingle WHERE IsCredit=1 AND IsExpense=0) "
                        Case "COST"
                            tSqlW &= " AND d.SICode IN(SELECT SICode FROM Job_SrvSingle WHERE IsExpense=1) "
                        Case "SERV"
                            tSqlW &= " AND (p.ChargeCode + d.DocNo + '#0') NOT IN(SELECT x.SICode+x.VenderBillingNo FROM Job_ClearDetail x INNER JOIN Job_ClearHeader y ON x.BranchCode=y.BranchCode AND x.ClrNo=y.ClrNo WHERE y.DocStatus<>99 AND ISNULL(x.VenderBillingNo,'')<>'') "
                            isForCharge = True
                    End Select
                End If
                If Not IsNothing(Request.QueryString("JobNo")) Then
                    tSqlW &= " AND d.ForJNo='" & Request.QueryString("JobNo") & "' "
                End If
                If Not IsNothing(Request.QueryString("Vender")) Then
                    tSqlW &= " AND h.VenCode IN(SELECT UserID FROM Mas_User WHERE DeptID='" & Request.QueryString("Vender") & "')"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND h.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND h.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If isForCharge = False Then
                    tSqlW &= " AND d.ClrItemNo=0 "
                    Dim sql As String = SQLSelectPayForClear() & "{0}"
                    Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sql, tSqlW))
                    Dim json = "{""clr"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim sql As String = SQLSelectPayForCharge() & "{0}"
                    Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sql, tSqlW))
                    Dim json = "{""clr"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPaymentForClear", ex.Message, ex.StackTrace, True)
                Return Content("{""clr"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try

        End Function
        Function GetAdvForClear() As ActionResult
            Try
                Dim tSqlW As String = " WHERE (a.AdvNet-ISNULL(d.TotalCleared,0))>0 AND c.DocStatus IN('3','4','5') "
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString = "NOCLR" Then
                        tSqlW = " WHERE d.AdvNo IS NULL AND c.DocStatus IN('2','3') "
                    End If
                    If Request.QueryString("Show").ToString = "CLR" Then
                        tSqlW = " WHERE d.AdvNo IS NOT NULL AND c.DocStatus IN('4','5','6') "
                    End If
                    If Request.QueryString("Show").ToString = "ALL" Then
                        tSqlW = " WHERE c.DocStatus>0 "
                    End If
                End If

                If Not IsNothing(Request.QueryString("BranchCode")) Then
                    Dim Branch = Request.QueryString("BranchCode")
                    tSqlW &= String.Format(" AND c.BranchCode='{0}'", Branch)
                End If

                If Not IsNothing(Request.QueryString("JobNo")) Then
                    tSqlW &= " AND a.ForJNo='" & Request.QueryString("JobNo") & "' "
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND c.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("CFrom")) Then
                    tSqlW &= " AND c.EmpCode IN(SELECT UserID FROM Mas_User WHERE DeptID='" & Request.QueryString("CFrom") & "')"
                End If
                If Not IsNothing(Request.QueryString("ReqBy")) Then
                    tSqlW &= " AND c.EmpCode='" & Request.QueryString("ReqBy") & "'"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND c.AdvDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND c.AdvDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND c.DocStatus='" & Request.QueryString("Status") & "' "
                End If
                If Not IsNothing(Request.QueryString("AdvNo")) Then
                    tSqlW &= " AND c.AdvNo IN('" & Request.QueryString("AdvNo").ToString().Replace(",", "','") & "') "
                End If
                Dim sql As String = SQLSelectAdvForClear() & "{0}"

                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sql, tSqlW))
                Dim json = "{""clr"":{""data"":" & JsonConvert.SerializeObject(oData) & ",""msg"":""" & tSqlW & """}}"
                Return Content(json, jsonContent)

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetAdvForClear", ex.Message, ex.StackTrace, True)
                Return Content("{""clr"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetNewClearHeader() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
            If AuthorizeStr.IndexOf("I") < 0 Then
                Return Content("[]", jsonContent)
            End If

            Dim Branch As String = ""
            If Not IsNothing(Request.QueryString("BranchCode")) Then
                Branch = Request.QueryString("BranchCode")
            End If

            Dim oHead As New CClrHeader(GetSession("ConnJob")) With {
                .BranchCode = Branch,
                .ClrNo = "",
                .ClrDate = DateTime.Today,
                .ClearFrom = 1,
                .ClearType = 1,
                .DocStatus = 1
            }

            Dim oDetail As New CClrDetail(GetSession("ConnJob")) With {
                .BranchCode = Branch,
                .ClrNo = "",
                .ItemNo = 0
            }

            Dim json As String = "{""clr"":{""header"":[" + JsonConvert.SerializeObject(oHead) + "],""detail"":[" + JsonConvert.SerializeObject(oDetail) + "],""result"":""OK""}}"
            Return Content(json, jsonContent)
        End Function
        Function GetNewClearDetail() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
            If AuthorizeStr.IndexOf("I") < 0 Then
                Return Content("[]", jsonContent)
            End If

            Dim Branch As String = ""
            If Not IsNothing(Request.QueryString("BranchCode")) Then
                Branch = Request.QueryString("BranchCode")
            End If

            Dim ClrNo As String = ""
            If Not IsNothing(Request.QueryString("ClrNo")) Then
                ClrNo = Request.QueryString("ClrNo")
            End If

            Dim oDetail As New CClrDetail(GetSession("ConnJob")) With
                {
                    .BranchCode = Branch,
                    .ClrNo = ClrNo,
                    .ItemNo = 0
                }

            Dim jsond As String = JsonConvert.SerializeObject(oDetail)
            Dim json = "{""clr"":{""detail"":" & jsond & ",""result"":""OK""}}"
            Return Content(json, jsonContent)
        End Function
        Function GetClearing() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""clr"":{""header"":[],""detail"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE ClrNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ClrNo ='{0}' ", Request.QueryString("Code").ToString)
                End If

                Dim oData = New CClrHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)

                Dim oDataD = New CClrDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)

                json = "{""clr"":{""header"":" & json & ",""detail"":" & jsonD & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClearing", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetClrHeader(<FromBody()> data As CClrHeader) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":[],""msg"":""You are not allow to save""}}", jsonContent)
                End If

                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.ClrNo = "" Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":[],""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                        If data.ClrDate = DateTime.MinValue Then
                            data.ClrDate = Today.Date
                        End If
                        Dim runningFormat = GetValueConfig("RUNNING_FORMAT", "CLR_ADV", clrPrefix)
                        Select Case data.ClearType
                            Case 2
                                runningFormat = GetValueConfig("RUNNING_FORMAT", "CLR_COST", costPrefix)
                            Case 3
                                runningFormat = GetValueConfig("RUNNING_FORMAT", "CLR_SERV", servPrefix)
                        End Select
                        Dim fmt = Main.GetValueConfig("RUNNING", "CLR")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.ClrDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.ClrDate.ToString("MM"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.ClrDate.ToString("yy"))
                            End If
                        Else
                            fmt = data.ClrDate.ToString("yyMM") & "____"
                        End If
                        data.AddNew(runningFormat & fmt)
                    End If

                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND ClrNo='{1}' ", data.BranchCode, data.ClrNo))

                    Dim json = "{""result"":{""data"":""" & data.ClrNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetClrHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelClearing() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""clr"":{""data"":[],""result"":""You are not allow to delete""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE ClrNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""clr"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ClrNo ='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""clr"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oDataD As New CClrDetail(GetSession("ConnJob"))
                Dim msg = oDataD.DeleteData(tSqlw)

                Dim oData As New CClrHeader(GetSession("ConnJob"))
                msg = oData.DeleteData(tSqlw)

                Dim json = "{""clr"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelClearing", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetClrDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("R") < 0 Then
                    Return Content("{""clr"":{""detail"":[],""msg"":""You are not allow to view""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE ClrNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ClrNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo IN({0}) ", Request.QueryString("Item").ToString)
                End If

                Dim oData = New CClrDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""clr"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetClrDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SaveClearDetail(<FromBody()> data As List(Of CClrDetail)) As ActionResult
            Try
                Dim branchcode As String = ""
                Dim clrno As String = ""
                Dim icount As Integer = 0
                For Each o As CClrDetail In data
                    branchcode = o.BranchCode
                    clrno = o.ClrNo
                    o.SetConnect(GetSession("ConnJob"))
                    Dim msg = o.SaveData(String.Format(" WHERE BranchCode='{0}' AND  ClrNo='{1}' And ItemNo='{2}' ", o.BranchCode, o.ClrNo, o.ItemNo))
                    If msg.Substring(0, 1) = "S" Then
                        icount += 1
                    End If
                Next
                Dim obj = New CClrDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' And ClrNo='{1}'", branchcode, clrno))
                Dim json = "{""result"":{""msg"":""" & icount & " row saved! (Clearing No=" + clrno + ")"",""data"":""" & clrno & """,""detail"":[" & JsonConvert.SerializeObject(obj) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SaveClearDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """,""detail"":[]}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetClrDetail(<FromBody()> data As CClrDetail) As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return Content("{""result"":{""data"":[],""msg"":""You are not allow to save""}}", jsonContent)
                End If

                If Not IsNothing(data) Then
                    If "" & data.ClrNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    If data.ItemNo = 0 Then
                        If AuthorizeStr.IndexOf("I") < 0 Then
                            Return Content("{""result"":{""data"":[],""msg"":""You are not allow to add""}}", jsonContent)
                        End If
                    End If

                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND ClrNo='{1}' AND ItemNo={2} ", data.BranchCode, data.ClrNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ClrNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetClrDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelClrDetail() As ActionResult
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CLR", "Index")
                If AuthorizeStr.IndexOf("D") < 0 Then
                    Return Content("{""clr"":{""data"":[],""result"":""You are not allow to delete""}}", jsonContent)
                End If

                Dim tSqlw As String = " WHERE ClrNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""clr"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND ClrNo ='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""clr"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo ={0} ", Request.QueryString("Item").ToString)
                Else
                    Return Content("{""clr"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                Dim oData As New CClrDetail(GetSession("ConnJob"))
                Dim oRows = oData.GetData(tSqlw)
                If oRows.Count > 0 Then
                    oData = oRows(0)
                End If
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""clr"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelClrDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetClrByPay() As ActionResult
            Try
                Dim branchcode As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    branchcode = Request.QueryString("Branch").ToString()
                Else
                    Return Content("{""clr"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                Dim docList As String = ""
                If Not IsNothing(Request.QueryString("Code")) Then
                    docList = Request.QueryString("Code").ToString() & ","
                Else
                    Return Content("{""clr"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim refno As String = ""
                If Not IsNothing(Request.QueryString("Ref")) Then
                    refno = Request.QueryString("Ref").ToString()
                Else
                    Return Content("{""clr"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim bCancel As Boolean = False
                If Not IsNothing(Request.QueryString("Status")) Then
                    If Request.QueryString("Status").ToString() = "N" Then
                        bCancel = True
                    End If
                End If
                Dim clrNoList As String = ""
                For Each docno As String In docList.Split(",")
                    If docno <> "" Then
                        Dim oHead = New CPayHeader(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ", branchcode, docno))
                        Dim oDet = New CPayDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND DocNo='{1}' ORDER BY ForJNo ", branchcode, docno))
                        If oHead.Count > 0 Then
                            Dim oPayH = oHead(0)
                            Dim LastJob As String = ""
                            Dim iCount As Integer = 1
                            Dim totalamt As Double = 0
                            Dim totalvat As Double = 0
                            Dim totalwht As Double = 0
                            Dim totalnet As Double = 0
                            Dim row As Integer = 0
                            For Each oPayD In oDet
                                Dim oClr = New CClrHeader(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND AdvRefNO='{1}' AND CTN_NO='{2}' ", branchcode, docno, oPayD.SRemark))
                                Dim oClrH = New CClrHeader(GetSession("ConnJob"))
                                If oClr.Count > 0 Then
                                    oClrH = oClr(0)
                                Else
                                    oClrH.BranchCode = oPayH.BranchCode
                                    oClrH.AddNew(GetValueConfig("RUNNING_FORMAT", "EXP", expPrefix) & DateTime.Now.ToString("yyMM") & "-____")
                                    oClrH.ClrDate = DateTime.Today
                                    oClrH.ClearanceDate = DateTime.MinValue
                                    oClrH.ClearType = 0
                                    oClrH.ClearFrom = 0
                                    oClrH.AdvRefNo = oPayH.DocNo
                                    oClrH.CTN_NO = oPayD.SRemark
                                    oClrH.SaveData(String.Format(" WHERE BranchCode='{0}' AND ClrNo='{1}' ", oClrH.BranchCode, oClrH.ClrNo))
                                End If
                                If clrNoList.IndexOf(oClrH.ClrNo) < 0 Then
                                    clrNoList &= If(clrNoList <> "", ",", "") & oClrH.ClrNo
                                End If
                                oClrH.EmpCode = oPayH.EmpCode
                                oClrH.DocStatus = If(bCancel = True Or oPayH.CancelProve <> "", 99, 2)
                                oClrH.ApproveBy = GetSession("CurrUser").ToString()
                                oClrH.ApproveDate = Main.GetDBDate(DateTime.Today)
                                oClrH.ApproveTime = Main.GetDBTime(DateTime.Now)
                                oClrH.ReceiveBy = GetSession("CurrUser").ToString()
                                oClrH.ReceiveDate = Main.GetDBDate(DateTime.Today)
                                oClrH.ReceiveTime = Main.GetDBTime(DateTime.Now)
                                oClrH.ReceiveRef = refno
                                oClrH.CancelReson = oPayH.CancelReson
                                oClrH.CancelDate = If(bCancel = True, Main.GetDBDate(DateTime.Today), oPayH.CancelDate)
                                oClrH.CancelTime = If(bCancel = True, Main.GetDBTime(DateTime.Now), oPayH.CancelTime)
                                oClrH.CancelProve = If(bCancel = True, GetSession("CurrUser").ToString(), oPayH.CancelProve)

                                row += 1
                                Dim oClrDet = New CClrDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND ClrNo='{1}' AND ItemNo={2} ", oClrH.BranchCode, oClrH.ClrNo, row))
                                Dim oClrD = New CClrDetail(GetSession("ConnJob"))
                                If oClrDet.Count > 0 Then
                                    oClrD = oClrDet(0)
                                Else
                                    oClrD.BranchCode = oPayD.BranchCode
                                    oClrD.ClrNo = oClrH.ClrNo
                                    oClrD.ItemNo = row
                                    oClrD.LinkItem = 0
                                End If
                                oClrD.SICode = oPayD.SICode
                                oClrD.SDescription = oPayD.SDescription

                                Dim oServ = New CServiceCode(GetSession("ConnJob")).GetData(String.Format(" WHERE SICode='{0}'", oPayD.SICode))

                                oClrD.VenderCode = oPayH.VenCode
                                oClrD.Qty = oPayD.Qty
                                oClrD.UnitCode = oPayD.QtyUnit
                                oClrD.CurrencyCode = oPayH.CurrencyCode
                                oClrD.CurRate = oPayH.ExchangeRate
                                Dim isCost As Boolean = False
                                If oServ.Count > 0 Then
                                    isCost = oServ(0).IsExpense = 1
                                End If
                                If isCost Then
                                    oClrD.UnitPrice = 0
                                    oClrD.FPrice = 0
                                    oClrD.BPrice = 0
                                Else
                                    oClrD.UnitPrice = oPayD.UnitPrice
                                    oClrD.FPrice = (oPayD.UnitPrice * oPayD.Qty) / oPayH.ExchangeRate
                                    oClrD.BPrice = (oPayD.UnitPrice * oPayD.Qty)
                                End If
                                oClrD.UnitCost = oPayD.UnitPrice
                                oClrD.FCost = (oPayD.UnitPrice * oPayD.Qty) / oPayH.ExchangeRate
                                oClrD.BCost = (oPayD.UnitPrice * oPayD.Qty)
                                oClrD.UsedAmount = oPayD.Amt - oPayD.AmtDisc
                                oClrD.ChargeVAT = oPayD.AmtVAT
                                oClrD.Tax50Tavi = oPayD.AmtWHT
                                oClrD.FNet = (oPayD.Total) / oPayH.ExchangeRate
                                oClrD.BNet = oPayD.Total
                                oClrD.VenderBillingNo = oPayH.RefNo
                                oClrD.JobNo = oPayD.ForJNo
                                oClrD.VATType = If(oPayD.AmtVAT > 0, 1, 0)
                                oClrD.VATRate = oPayH.VATRate
                                oClrD.Tax50TaviRate = oPayH.TaxRate
                                oClrD.QNo = oPayH.PoNo
                                oClrD.SaveData(String.Format(" WHERE BranchCode='{0}' AND ClrNo='{1}' AND ItemNo={2} ", oClrH.BranchCode, oClrH.ClrNo, row))

                                totalamt += oPayD.Amt - oPayD.AmtDisc
                                totalvat += oPayD.AmtVAT
                                totalwht += oPayD.AmtWHT
                                totalnet += oPayD.Total

                                If iCount = oDet.Count Or LastJob <> oPayD.SRemark Then
                                    LastJob = oPayD.SRemark

                                    oClrH.TotalExpense = totalamt

                                    oClrH.ClearTotal = totalamt
                                    oClrH.ClearVat = totalvat
                                    oClrH.ClearWht = totalwht
                                    oClrH.ClearNet = totalnet
                                    oClrH.SaveData(String.Format(" WHERE BranchCode='{0}' AND ClrNo='{1}' ", oClrH.BranchCode, oClrH.ClrNo))
                                    totalamt = 0
                                    totalvat = 0
                                    totalwht = 0
                                    totalnet = 0
                                    row = 0
                                End If
                                iCount += 1
                            Next
                        End If
                    End If
                Next
                If clrNoList <> "" Then
                    Return Content("{""clr"":{""result"":""Save To " & clrNoList & """,""data"":[]}}", jsonContent)
                Else
                    Return Content("{""clr"":{""result"":""No data to Save"",""data"":[]}}", jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetClrByPay", ex.Message, ex.StackTrace, True)
                Return Content("{""clr"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function UpdateClearStatus() As ActionResult
            Main.UpdateClearStatus()
            Return Content("OK", textContent)
        End Function
    End Class
End Namespace