Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Namespace Controllers
    Public Class JobOrderController
        Inherits CController
        Function Approve() As ActionResult
            Return GetView("Approve")
        End Function
        Function Index() As ActionResult
            Return GetView("Index", "MODULE_CS")
        End Function
        Function Config() As ActionResult
            Return GetView("Config")
        End Function
        Function TruckOrder() As ActionResult
            Return GetView("TruckOrder")
        End Function
        Function FormTruckOrder() As ActionResult
            Return GetView("FormTruckOrder")
        End Function
        Function CreateJob() As ActionResult
            Return GetView("CreateJob", "MODULE_CS")
        End Function
        Function ShowJob() As ActionResult
            Return GetView("ShowJob", "MODULE_CS")
        End Function
        Function TruckApprove() As ActionResult
            Return GetView("TruckApprove", "MODULE_CS")
        End Function
        Function FormJob() As ActionResult
            ViewBag.User = GetSession("CurrUser").ToString()
            Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CS", "ShowJob")
            If AuthorizeStr.IndexOf("P") < 0 Then
                Return Content("You are not allow to print", textContent)
            End If
            Return GetView("FormJob")
        End Function
        Function FormPrepare() As ActionResult
            Return GetView("FormPrepare")
        End Function
        Function FormJobSum() As ActionResult
            Return GetView("FormJobSum")
        End Function
        Function FormQuotation() As ActionResult
            Return GetView("FormQuotation")
        End Function
        Function CreateContainer() As ActionResult
            Try
                Dim branch = ""
                If Request.QueryString("Branch") IsNot Nothing Then
                    branch = Request.QueryString("Branch").ToString
                Else
                    Return Content("{""result"":{""data"":[],""msg"":""Please input branch""}}", jsonContent)
                End If
                Dim book = ""
                If Request.QueryString("Code") IsNot Nothing Then
                    book = Request.QueryString("Code").ToString
                Else
                    Return Content("{""result"":{""data"":[],""msg"":""Please enter some data""}}", jsonContent)
                End If
                Dim size = ""
                If Request.QueryString("Size") IsNot Nothing Then
                    size = Request.QueryString("Size").ToString
                Else
                    Return Content("{""result"":{""data"":[],""msg"":""Please select unit""}}", jsonContent)
                End If
                Dim route = 0
                Dim routename = ""
                If Request.QueryString("Route") IsNot Nothing Then
                    route = Convert.ToInt32("0" & Request.QueryString("Route").ToString())
                    Dim oRoute = New CTransportRoute(GetSession("ConnJob")).GetData(String.Format(" WHERE LocationID={0}", route))
                    If oRoute.Count > 0 Then
                        routename = oRoute(0).LocationRoute
                    End If
                    'Else
                    'Return Content("{""result"":{""data"":[],""msg"":""Please select route""}}", jsonContent)
                End If
                Dim volume = 0
                If Request.QueryString("Qty") IsNot Nothing Then
                    volume = Convert.ToInt16("0" & Request.QueryString("Qty").ToString)
                Else
                    Return Content("{""result"":{""data"":[],""msg"":""Value must be more than zero""}}", jsonContent)
                End If
                If volume <= 0 Then
                    Return Content("{""result"":{""data"":[],""msg"":""Value must be more than zero""}}", jsonContent)
                Else
                    Dim bookData = New CTransportHeader(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}'", branch, book))
                    Dim booking = New CTransportHeader()
                    If bookData.Count > 0 Then
                        booking = bookData(0)
                    End If
                    Dim oList As New List(Of CTransportDetail)
                    For i As Integer = 1 To volume
                        Dim oRec = New CTransportDetail(GetSession("ConnJob")) With {
                            .BranchCode = branch,
                            .BookingNo = book,
                            .JNo = GetValueSQL(GetSession("ConnJob"), String.Format("SELECT JNo FROM Job_LoadInfo WHERE BranchCode='{0}' AND BookingNo='{1}'", branch, book)).Result.ToString(),
                            .CTN_NO = "",
                            .SealNumber = "",
                            .TruckNO = "",
                            .CauseCode = "",
                            .Comment = "",
                            .TruckType = "",
                            .Driver = "",
                            .LocationID = route,
                            .Location = routename,
                            .ShippingMark = ""
                        }
                        oRec.ProductDesc = GetValueSQL(GetSession("ConnJob"), String.Format("SELECT InvProduct FROM Job_Order WHERE BranchCode='{0}' AND JNo='{1}'", branch, oRec.JNo)).Result.ToString()
                        oRec.CTN_SIZE = size
                        oRec.ProductQty = 0
                        oRec.ProductUnit = ""
                        oRec.GrossWeight = 0
                        oRec.Measurement = 0
                        oRec.DeliveryNo = ""
                        oRec.TargetYardDate = booking.CYDate
                        oRec.TargetYardTime = booking.CYTime
                        oRec.UnloadDate = booking.FactoryDate
                        oRec.UnloadTime = booking.FactoryTime
                        oRec.TruckIN = booking.ReturnDate
                        oRec.Start = booking.ReturnTime
                        oRec.PlaceName1 = booking.CYPlace
                        oRec.PlaceAddress1 = booking.CYAddress
                        oRec.PlaceContact1 = booking.CYContact
                        oRec.PlaceName2 = booking.FactoryPlace
                        oRec.PlaceAddress2 = booking.FactoryAddress
                        oRec.PlaceContact2 = booking.FactoryContact
                        oRec.PlaceName3 = booking.PackingPlace
                        oRec.PlaceAddress3 = booking.PackingAddress
                        oRec.PlaceContact3 = booking.PackingContact
                        oRec.PlaceName4 = booking.ReturnPlace
                        oRec.PlaceAddress4 = booking.ReturnAddress
                        oRec.PlaceContact4 = booking.ReturnContact
                        oRec.AddNew()
                        Dim msg = oRec.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' AND ItemNo={2}", oRec.BranchCode, oRec.BookingNo, oRec.ItemNo))
                        If msg.Substring(0, 1) = "S" Then
                            oList.Add(oRec)
                        Else
                            Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CreateContainer", "Save Container No" + i, msg, True, "", JsonConvert.SerializeObject(oRec))
                        End If
                    Next
                    Dim json = JsonConvert.SerializeObject(oList)
                    If GetSession("CurrentLang") = "TH" Then
                        Return Content("{""result"":{""data"":" & json & ",""msg"":""สร้างรายการจำนวน " & oList.Count & " เรียบร้อย""}}", jsonContent)
                    Else
                        Return Content("{""result"":{""data"":" & json & ",""msg"":""Create Complete=" & oList.Count & " Record(s)""}}", jsonContent)
                    End If
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CreateContainer", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function UpdateContainerToJob() As ActionResult
            Try
                Dim tSqlW As String = ""
                Dim branch = ""
                If Request.QueryString("Branch") IsNot Nothing Then
                    branch = Request.QueryString("Branch").ToString
                    tSqlW &= String.Format(" AND h.BranchCode='{0}' ", branch)
                Else
                    Return Content("{""result"":{""data"":[],""msg"":""Please enter some data""}}", jsonContent)
                End If
                Dim job = ""
                If Request.QueryString("Job") IsNot Nothing Then
                    job = Request.QueryString("Job").ToString
                    tSqlW &= String.Format(" AND h.JNo='{0}' ", job)
                Else
                    Return Content("{""result"":{""data"":[],""msg"":""Please select job number""}}", jsonContent)
                End If
                Dim sqlCtn = "
	SELECT (SELECT STUFF((
	SELECT ',' + Convert(varchar,Count(*)) + 'x' + CTN_SIZE
	FROM Job_LoadInfoDetail WHERE BranchCode=a.BranchCode
	AND BookingNo=a.BookingNo AND ISNULL(CTN_SIZE,'')<>''
	AND ISNULL(CauseCode,'')<>'99'
	GROUP BY CTN_SIZE
	FOR XML PATH(''),type).value('.','nvarchar(max)'),1,1,''
	)) as SumContainer
	from job_loadinfo a WHERE a.BranchCode='" & branch & "' AND a.JNo='" & job & "'
"
                Dim ctnTotal = GetValueSQL(GetSession("ConnJob"), sqlCtn).Result.ToString()
                Dim msg = Main.DBExecute(GetSession("ConnJob"), SQLUpdateContainer() & tSqlW)
                Return Content("{""result"":{""data"":""" & ctnTotal & """,""msg"":""" & msg & """}}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "UpdateContainerToJob", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function ApproveTransport(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                If IsNothing(data) Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If
                Dim strStatus = ""
                Dim json As String = ""
                Dim lst As String = ""
                Dim user As String = ""
                strStatus = Request.QueryString("Status").ToString()
                For Each str As String In data
                    If str.IndexOf("|") >= 0 Then
                        If lst <> "" Then lst &= ","
                        lst &= "'" & str & "'"
                    Else
                        user = str
                    End If
                Next

                If lst <> "" Then
                    Dim tSQL As String = String.Format("UPDATE Job_LoadInfoDetail SET CauseCode='" & strStatus & "'
 WHERE BookingNo+'|'+CTN_NO in({0})", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "ApproveTransport", ex.Message, ex.StackTrace, True)
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End Try
        End Function
        Function ApproveQuotation(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_SALES", "QuoApprove")
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
                    Dim tSQL As String = String.Format("UPDATE Job_QuotationHeader SET DocStatus=1,ApproveBy='" & user & "',ApproveDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',ApproveTime='" & DateTime.Now.ToString("HH:mm:ss") & "' 
 WHERE DocStatus=0 AND BranchCode+'|'+QNo in({0})", lst)
                    Dim result = Main.DBExecute(GetSession("ConnJob"), tSQL)
                    If result = "OK" Then
                        Return New HttpResponseMessage(HttpStatusCode.OK)
                    End If
                End If
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "ApproveQuotation", ex.Message, ex.StackTrace, True)
                Return New HttpResponseMessage(HttpStatusCode.BadRequest)
            End Try
        End Function

        Function Quotation() As ActionResult
            Return GetView("Quotation", "MODULE_SALES")
        End Function
        Function CopyQuotation() As ActionResult
            Dim tSqlw As String = " WHERE QNo<>'' "
            If Not IsNothing(Request.QueryString("Branch")) Then
                tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("Code")) Then
                tSqlw &= String.Format(" AND QNo='{0}' ", Request.QueryString("Code").ToString)
            End If

            Dim custcode As String
            Dim custbranch As String
            If Not IsNothing(Request.QueryString("Cust")) Then
                custcode = Request.QueryString("Cust").ToString().Split("|")(0)
                custbranch = Request.QueryString("Cust").ToString().Split("|")(1)
            Else
                Return Content("{""result"":""Please choose customer first""}", jsonContent)
            End If
            Try
                Dim oHead = New CQuoHeader(GetSession("ConnJob")).GetData(tSqlw)
                If oHead.Count > 0 Then
                    Dim oDetails = New CQuoDetail(GetSession("ConnJob")).GetData(tSqlw)
                    Dim oItems = New CQuoItem(GetSession("ConnJob")).GetData(tSqlw)
                    oHead(0).DocDate = DateTime.Today
                    oHead(0).CustCode = custcode
                    oHead(0).CustBranch = custbranch
                    oHead(0).BillToCustCode = custcode
                    oHead(0).BillToCustBranch = custbranch
                    oHead(0).DocStatus = 0
                    oHead(0).ApproveBy = ""
                    oHead(0).ApproveDate = DateTime.MinValue
                    oHead(0).ApproveTime = DateTime.MinValue
                    oHead(0).CancelBy = ""
                    oHead(0).CancelDate = DateTime.MinValue
                    oHead(0).CancelReason = ""
                    oHead(0).ReferQNo = Request.QueryString("Code").ToString
                    oHead(0).AddNew("Q-" & DateTime.Now.ToString("yyMM") & "-____")
                    Dim msg = oHead(0).SaveData(String.Format(" WHERE BranchCode='{0}' AND QNo='{1}'", oHead(0).BranchCode, oHead(0).QNo))
                    If msg.Substring(0, 1) = "S" Then
                        For Each detail In oDetails
                            detail.QNo = oHead(0).QNo
                            detail.SaveData(String.Format(" WHERE BranchCode='{0}' AND QNo='{1}' AND SeqNo={2}", oHead(0).BranchCode, oHead(0).QNo, detail.SeqNo))
                        Next
                        For Each item In oItems
                            item.QNo = oHead(0).QNo
                            item.SaveData(String.Format(" WHERE BranchCode='{0}' AND QNo='{1}' AND SeqNo={2} AND ItemNo={3}", oHead(0).BranchCode, oHead(0).QNo, item.SeqNo, item.ItemNo))
                        Next
                        Return Content("{""result"":""" & oHead(0).QNo & """}", jsonContent)
                    Else
                        Return Content("{""result"":""" & msg & """}", jsonContent)
                    End If
                Else
                    If GetSession("CurrentLang") = "TH" Then
                        Return Content("{""result"":""ไม่พบใบเสนอราคาของ " & Request.QueryString("Cust").ToString & """}", jsonContent)
                    Else
                        Return Content("{""result"":""Not Found Quotation " & Request.QueryString("Cust").ToString & """}", jsonContent)
                    End If
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "CopyQuotation", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":""" & ex.Message & """}", jsonContent)
            End Try
        End Function
        Function GetQuotationGrid() As ActionResult
            Try
                Dim tSqlW As String = ""
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND Job_QuotationDetail.JobType=" & Request.QueryString("JType").ToString & ""
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= " AND Job_QuotationDetail.ShipBy=" & Request.QueryString("SBy").ToString & ""
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlW &= " AND Job_QuotationHeader.BranchCode='" & Request.QueryString("Branch").ToString & "'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND Job_QuotationHeader.DocStatus='" & Request.QueryString("Status").ToString & "'"
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlW &= " AND Job_QuotationHeader.CustCode='" & Request.QueryString("Cust").ToString & "'"
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlW &= " AND Job_QuotationItem.SICode='" & Request.QueryString("Code").ToString & "'"
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectQuotation() & " WHERE NOT ISNULL(Job_QuotationHeader.CancelBy,'')<>'' " & tSqlW & " ORDER BY Job_QuotationHeader.BranchCode,Job_QuotationHeader.QNo,Job_QuotationHeader.ApproveDate DESC,Job_QuotationItem.SICode,Job_QuotationItem.QtyBegin")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""quotation"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetQuotationGrid", ex.Message, ex.StackTrace, True)
                Return Content("{""quotation"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetQuotation() As ActionResult
            Try
                Dim tSqlw As String = " WHERE QNo<>'' "
                If Not IsNothing(Request.QueryString("Show")) Then
                    If Request.QueryString("Show").ToString() = "ACTIVE" Then
                        tSqlw &= String.Format(" AND NOT ISNULL(CancelBy,'')<>'' ")
                    End If
                    If Request.QueryString("Show").ToString() = "CANCEL" Then
                        tSqlw &= String.Format(" AND ISNULL(CancelBy,'')<>'' ")
                    End If
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw &= String.Format("AND DocStatus={0} ", Request.QueryString("Status").ToString)
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND QNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format("AND CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Sales")) Then
                    tSqlw &= String.Format("AND ManagerCode='{0}' ", Request.QueryString("Sales").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                Dim oDataH = New CQuoHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonH As String = JsonConvert.SerializeObject(oDataH)
                Dim oDataD = New CQuoDetail(GetSession("ConnJob")).GetData(" WHERE QNo IN(SELECT QNo FROM Job_QuotationHeader " & tSqlw & " )")
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)
                Dim oDataI = New CQuoItem(GetSession("ConnJob")).GetData(" WHERE QNo IN(SELECT QNo FROM Job_QuotationHeader " & tSqlw & " )")
                Dim jsonI As String = JsonConvert.SerializeObject(oDataI)
                Dim json As String = "{""quotation"":{""header"":" & jsonH & ",""detail"":" & jsonD & ",""item"":" & jsonI & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetQuotation", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetQuoHeader(<FromBody()> data As CQuoHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.QNo = "" Then
                        Dim fmt As String = GetValueConfig("RUNNING", "QUO")
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
                        data.AddNew(GetValueConfig("RUNNING_FORMAT", "QUO", quoPrefix) & fmt)
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND QNo='{1}' ", data.BranchCode, data.QNo))
                    Dim json = "{""result"":{""data"":""" & data.QNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetQuoHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelQuoHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE QNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""quoheader"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND QNo='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""quoheader"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CQuoHeader(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Dim oDataD As New CQuoDetail(GetSession("ConnJob"))
                oDataD.DeleteData(tSqlw)
                Dim oDataI As New CQuoItem(GetSession("ConnJob"))
                oDataI.DeleteData(tSqlw)
                Dim json = "{""quoheader"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelQuoHeader", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetQuoDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE QNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND QNo='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Seq")) Then
                    tSqlw &= String.Format(" AND SeqNo={0}", Request.QueryString("Seq").ToString)
                End If
                Dim oData = New CQuoDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Dim oDataD = New CQuoItem(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)
                json = "{""quotation"":{""detail"":" & json & ",""items"":" & jsonD & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetQuoDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetQuoDetail(<FromBody()> data As CQuoDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.QNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND QNo='{1}' AND SeqNo={2} ", data.BranchCode, data.QNo, data.SeqNo))
                    Dim json = "{""result"":{""data"":""" & data.SeqNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetQuoDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelQuoDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE QNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""quodetail"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND QNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""quodetail"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Seq")) Then
                    tSqlw &= String.Format(" AND SeqNo={0} ", Request.QueryString("Seq").ToString)
                End If
                Dim oData As New CQuoDetail(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Dim oDataD As New CQuoItem(GetSession("ConnJob"))
                oDataD.DeleteData(tSqlw)

                Dim json = "{""quodetail"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelQuoDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetQuoItem() As ActionResult
            Try
                Dim tSqlw As String = " WHERE QNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND QNo='{0}'", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Seq")) Then
                    tSqlw &= String.Format(" AND SeqNo={0}", Request.QueryString("Seq").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0}", Request.QueryString("Item").ToString)
                End If
                Dim oData = New CQuoItem(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""quotation"":{""items"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetQuoItem", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetQuoItem(<FromBody()> data As CQuoItem) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.QNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    If "" & data.SeqNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND QNo='{1}' And SeqNo={2} And ItemNo={3} ", data.BranchCode, data.QNo, data.SeqNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetQuoItem", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelQuoItem() As ActionResult
            Try
                Dim tSqlw As String = " WHERE QNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""quoitem"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND QNo='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""quoitem"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Seq")) Then
                    tSqlw &= String.Format(" AND SeqNo={0} ", Request.QueryString("Seq").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                Dim oData As New CQuoItem(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""quoitem"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelQuoItem", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function

        Function QuoApprove() As ActionResult
            Return GetView("QuoApprove", "MODULE_SALES")
        End Function
        Function FormLetter() As ActionResult
            Return GetView("FormLetter")
        End Function
        Function FormBookingIm() As ActionResult
            Return GetView("FormBookingIm")
        End Function
        Function FormBookingEx() As ActionResult
            Return GetView("FormBookingEx")
        End Function
        Function FormBookingAir() As ActionResult
            Return GetView("FormBookingAir")
        End Function
        Function FormBookingSea() As ActionResult
            Return GetView("FormBookingSea")
        End Function
        Function FormBooking() As ActionResult
            Return GetView("FormBooking")
        End Function
        Function FormDelivery() As ActionResult
            Return GetView("FormDelivery")
        End Function
        Function Transport() As ActionResult
            Return GetView("Transport", "MODULE_CS")
            'Return RedirectToAction("FormDelivery")
        End Function
        Function GetTransport() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oDataH = New CTransportHeader(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonH As String = JsonConvert.SerializeObject(oDataH)
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format("AND JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                Dim oDataD = New CTransportDetail(GetSession("ConnJob")).GetData(tSqlw)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD)
                Dim json = "{""transport"":{""header"":" & jsonH & ",""detail"":" & jsonD & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransport", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetLocation() As ActionResult
            Try
                Dim place = "1"
                If Not IsNothing(Request.QueryString("Place")) Then
                    place = Request.QueryString("Place").ToString
                End If
                Dim sql = "
SELECT PlaceName as Place,PlaceAddress as Address,PlaceContact as Contact FROM Job_TransportPlace
WHERE PlaceType=" & place & "
"
                Dim oDataD = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD.Rows)
                Dim json = "{""data"":" & jsonD & "}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransportEntry", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try

        End Function
        Function GetLocationEntry() As ActionResult
            Try
                Dim place = "1"
                If Not IsNothing(Request.QueryString("Place")) Then
                    place = Request.QueryString("Place").ToString
                End If
                Dim sql = "
SELECT DISTINCT PlaceName" & place & " as Place,PlaceAddress" & place & " as Address,PlaceContact" & place & " as Contact FROM Job_LoadinfoDetail
WHERE ISNULL(PlaceName" & place & ",'')<>''
"
                Dim oDataD = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
                Dim jsonD As String = JsonConvert.SerializeObject(oDataD.Rows)
                Dim json = "{""data"":" & jsonD & "}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransportEntry", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetTransportHeader(<FromBody()> data As CTransportHeader) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If

                    If "" & data.BookingNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' ", data.BranchCode, data.BookingNo))
                    Dim json = "{""result"":{""data"":""" & data.BookingNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportHeader", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelTransportHeader() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""transport"":{""result"":""Please input branch""}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND BookingNo='{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""transport"":{""result"":""Please enter some data""}}", jsonContent)
                End If
                Dim oDataH As New CTransportHeader(GetSession("ConnJob"))
                Dim msg = ""
                For Each oDoc In oDataH.GetData(tSqlw)
                    msg &= "\n" & oDoc.DeleteData(tSqlw)
                Next
                Dim json = "{""transport"":{""result"":""" & msg & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelTransportHeader", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetTransportDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE a.JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND a.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND a.BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND a.ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format("AND a.JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    If Request.QueryString("Status").ToString = "N" Then
                        tSqlw &= "AND ISNULL(a.CauseCode,'0') IN('0','') "
                    ElseIf Request.QueryString("Status").ToString = "Y" Then
                        tSqlw &= "AND ISNULL(a.CauseCode,'0') IN('2','3') "
                    Else
                        tSqlw &= String.Format("AND ISNULL(a.CauseCode,'0') IN('{0}') ", Request.QueryString("Status").ToString())
                    End If
                End If
                Dim tSqlH = " AND a.BookingNo IN(SELECT BookingNo FROM Job_LoadInfo WHERE BookingNo<>'' "
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlH &= String.Format(" AND NotifyCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlH &= String.Format(" AND VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlH &= " AND LoadDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlH &= " AND LoadDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                tSqlH &= ")"
                'Dim oData = New CTransportDetail(GetSession("ConnJob")).GetData(tSqlw & tSqlH)
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectTransportDetail() & tSqlw & tSqlH)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""transport"":{""detail"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransportDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetTransportDetail(<FromBody()> data As CTransportDetail) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.BookingNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.CTN_NO <> "" Then
                        If data.GetData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}' AND ItemNo<>{2} AND CTN_NO='{3}'", data.BranchCode, data.JNo, data.ItemNo, data.CTN_NO)).Count > 0 Then
                            Return Content("{""result"":{""data"":null,""msg"":""This Container is duplicate""}}", jsonContent)
                        End If
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' AND ItemNo='{2}' ", data.BranchCode, data.BookingNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportDetail", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelTransportDetail() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""transport"":{""result"":""Please input branch""}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND BookingNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""transport"":{""result"":""Please select job number""}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo={0}", Request.QueryString("Item").ToString)
                End If
                Dim oData As New CTransportDetail(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""transport"":{""result"":""" & msg & """}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelTransportDetail", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetTrackingReport() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND Job_Order.BranchCode='{0}'", Request.QueryString("Branch").ToString())
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND Job_Order.JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfo.BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Doc")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfoDetail.DeliveryNo='{0}' ", Request.QueryString("Doc").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND Job_Order.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw &= String.Format(" AND Job_Order.JobStatus='{0}' ", Request.QueryString("Status").ToString)
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlw &= String.Format(" AND Mas_Company.TaxNumber='{0}' ", Request.QueryString("TaxNumber").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfo.VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND Job_Order.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND Job_Order.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectTracking(tSqlw))
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""transport"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTrackingReport", ex.Message, ex.StackTrace, True)
                Return Content("{""transport"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetBooking() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND h.BranchCode='{0}'", Request.QueryString("Branch").ToString())
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND h.JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND h.BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Doc")) Then
                    tSqlw &= String.Format(" AND d.DeliveryNo='{0}' ", Request.QueryString("Doc").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cont")) Then
                    tSqlw &= String.Format(" AND d.CTN_NO='{0}' ", Request.QueryString("Cont").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND j.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("HAWB")) Then
                    tSqlw &= String.Format(" AND j.HAWB='{0}' ", Request.QueryString("HAWB").ToString)
                End If
                If Not IsNothing(Request.QueryString("MAWB")) Then
                    tSqlw &= String.Format(" AND j.MAWB IN(SELECT MAWB FROM Job_Order where JNo='{0}' AND MAWB<>'') ", Request.QueryString("MAWB").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND a.VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND h.LoadDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND h.LoadDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectBooking() & tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""booking"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetBooking", ex.Message, ex.StackTrace, True)
                Return Content("{""booking"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetTransportReport() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfo.BranchCode='{0}'", Request.QueryString("Branch").ToString())
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfoDetail.JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("JobList")) Then
                    Dim JobList = Request.QueryString("JobList").ToString
                    tSqlw &= String.Format(" AND Job_LoadInfoDetail.JNo IN('{0}') ", JobList.Replace(",", "','"))
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfo.BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Doc")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfoDetail.DeliveryNo='{0}' ", Request.QueryString("Doc").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND Job_Order.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw &= String.Format(" AND Job_Order.JobStatus='{0}' ", Request.QueryString("Status").ToString)
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlw &= String.Format(" AND Mas_Company.TaxNumber='{0}' ", Request.QueryString("TaxNumber").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND Job_Loadinfo.VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cont")) Then
                    tSqlw &= String.Format(" AND Job_LoadinfoDetail.CTN_NO='{0}' ", Request.QueryString("Cont").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND Job_LoadInfo.LoadDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND Job_LoadInfo.LoadDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectTransport(tSqlw))
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""transport"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransportReport", ex.Message, ex.StackTrace, True)
                Return Content("{""transport"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function FormTransport() As ActionResult
            Dim type As String = ""
            If Request.QueryString("Type") IsNot Nothing Then
                type = Request.QueryString("Type").ToString
            End If
            Return GetView("FormTransport" & type)
        End Function
        Function ChangeBooking() As ActionResult
            Dim fromBookNo = ""
            Dim toBookNo = ""
            If Not IsNothing(Request.QueryString("From")) Then
                fromBookNo = Request.QueryString("From").ToString()
            End If
            If Not IsNothing(Request.QueryString("To")) Then
                toBookNo = Request.QueryString("To").ToString()
            End If
            If fromBookNo = "" Or toBookNo = "" Then
                Return Content("{""result"":""Data Not Found""}", jsonContent)
            Else
                Dim msgJ = Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_Order SET BookingNo='{0}' WHERE BookingNo='{1}' ", toBookNo, fromBookNo))
                Dim msgH = Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_LoadInfo SET BookingNo='{0}' WHERE BookingNo='{1}' ", toBookNo, fromBookNo))
                Dim msgD = Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_LoadInfoDetail SET BookingNo='{0}' WHERE BookingNo='{1}' ", toBookNo, fromBookNo))
                Dim msgP = Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_PaymentDetail SET BookingRefNo='{0}' WHERE BookingRefNo='{1}' ", toBookNo, fromBookNo))
                Return Content("{""result"":""Update Job Order=" & msgJ & "\nUpdate Transport Header=" & msgH & "\nUpdate Container=" & msgD & "\nUpdate Vender Billing=" & msgP & """}", jsonContent)
            End If
        End Function
        Function CheckAPI() As ActionResult
            Return Content("Hi API is Running")
        End Function
        Function GetDocSummary() As ActionResult
            Try
                Dim tSqlW As String = " WHERE t.Period<>'' "

                If Not IsNothing(Request.QueryString("Year")) Then
                    tSqlW &= " AND t.Period Like '" & Request.QueryString("Year") & "/%' "
                End If
                If Not IsNothing(Request.QueryString("Period")) Then
                    tSqlW &= " AND t.Period='" & Request.QueryString("Period") & "' "
                End If
                Dim cancel As Boolean = False
                If Not IsNothing(Request.QueryString("Cancel")) Then
                    cancel = Request.QueryString("Cancel").ToString() = "Y"
                End If
                Dim sqlm As String = SQLSelectDocSummary(cancel)
                If Not IsNothing(Request.QueryString("Summary")) Then
                    If Request.QueryString("Summary").ToString <> "Y" Then
                        sqlm = SQLSelectDocList(cancel)
                    End If
                End If
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sqlm, tSqlW))
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobSummary", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetJobDocument() As ActionResult
            Try
                Dim branch As String = ""
                Dim job As String = ""
                Dim doctype As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    branch = Request.QueryString("Branch").ToString()
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    job = Request.QueryString("Job").ToString
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    doctype = Request.QueryString("Type").ToString
                End If
                Dim status = " WHERE IsCancel=0 "
                If Not IsNothing(Request.QueryString("Cancel")) Then
                    status = " WHERE " & If(Request.QueryString("Cancel").ToString = "Y", "IsCancel=1", "IsCancel=0")
                End If
                If doctype <> "" Then
                    status &= String.Format(" AND DocType='{0}' ", doctype)
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT * FROM (" & SQLSelectDocumentByJob(branch, job) & ") as t " & status)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""job"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobDocument", ex.Message, ex.StackTrace, True)
                Return Content("{""job"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetJobReport() As ActionResult
            Try
                Dim isShowAll As Boolean = True
                Dim oUser = New CUser(GetSession("Connjob")).GetData(String.Format(" WHERE UserID='{0}'", GetSession("CurrUser")))
                If oUser.Count > 0 Then
                    If "5,4".IndexOf(oUser(0).UPosition) > 0 Then
                        isShowAll = False
                    End If
                End If
                Dim tSqlW As String = ""
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND j.JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= " AND j.ShipBy=" & Request.QueryString("SBy") & ""
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlW &= " AND j.BranchCode='" & Request.QueryString("Branch") & "'"
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND j.JobStatus='" & Request.QueryString("Status") & "'"
                End If
                If Not IsNothing(Request.QueryString("JNo")) Then
                    tSqlW &= " AND j.JNo='" & Request.QueryString("JNo") & "'"
                End If
                Dim dField = "j.DocDate"
                If Not IsNothing(Request.QueryString("ByDate")) Then
                    dField = "j." & Request.QueryString("ByDate").ToString
                End If
                If Not IsNothing(Request.QueryString("Year")) Then
                    tSqlW &= " AND Year(" & dField & ")='" & Request.QueryString("Year") & "'"
                End If
                If Not IsNothing(Request.QueryString("Month")) Then
                    tSqlW &= " AND Month(" & dField & ")='" & Request.QueryString("Month") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND j.CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("CSCode")) Then
                    tSqlW &= " AND j.CSCode='" & Request.QueryString("CSCode") & "'"
                Else
                    If isShowAll = False And oUser(0).UPosition = 4 Then
                        tSqlW &= " AND (j.CSCode='" & oUser(0).UserID & "')"
                    End If
                End If
                If Not IsNothing(Request.QueryString("DeclareNo")) Then
                    tSqlW &= " AND j.DeclareNumber Like '%" & Request.QueryString("DeclareNo") & "%'"
                End If
                If Not IsNothing(Request.QueryString("HAWB")) Then
                    tSqlW &= " AND j.HAWB Like '%" & Request.QueryString("HAWB") & "%'"
                End If
                If Not IsNothing(Request.QueryString("MAWB")) Then
                    tSqlW &= " AND j.MAWB Like '%" & Request.QueryString("MAWB") & "%'"
                End If
                If Not IsNothing(Request.QueryString("InvNo")) Then
                    tSqlW &= " AND j.InvNo Like '%" & Request.QueryString("InvNo") & "%'"
                End If
                If Not IsNothing(Request.QueryString("BookingNo")) Then
                    tSqlW &= " AND j.BookingNo Like '%" & Request.QueryString("BookingNo") & "%'"
                End If
                If Not IsNothing(Request.QueryString("ManagerCode")) Then
                    tSqlW &= " AND j.ManagerCode='" & Request.QueryString("ManagerCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("ShippingCode")) Then
                    tSqlW &= " AND j.ShippingEmp='" & Request.QueryString("ShippingCode") & "'"
                Else
                    If isShowAll = False And oUser(0).UPosition = 5 Then
                        tSqlW &= " AND (j.ShippingEmp='" & oUser(0).UserID & "')"
                    End If
                End If
                If Not IsNothing(Request.QueryString("Forwarder")) Then
                    tSqlW &= " AND j.ForwarderCode='" & Request.QueryString("Forwarder") & "'"
                End If
                If Not IsNothing(Request.QueryString("Agent")) Then
                    tSqlW &= " AND j.AgentCode='" & Request.QueryString("Agent") & "'"
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlW &= " AND j.CustCode IN(SELECT CustCode FROM Mas_Company WHERE TaxNumber='" & Request.QueryString("TaxNumber") & "')"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND " & dField & ">='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND " & dField & "<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectJobReport() & " WHERE j.JNo<>'' " & tSqlW & " ORDER BY j.BranchCode,j.JNo")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""job"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobReport", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetJobSummary() As ActionResult
            Try
                Dim tSqlW As String = ""

                If Not IsNothing(Request.QueryString("Year")) Then
                    tSqlW &= " AND Year(j.CreateDate) ='" & Request.QueryString("Year") & "' "
                End If
                If Not IsNothing(Request.QueryString("JobType")) Then
                    tSqlW &= " AND j.JobType =" & Request.QueryString("JobType") & " "
                End If
                If Not IsNothing(Request.QueryString("ShipBy")) Then
                    tSqlW &= " AND j.ShipBy =" & Request.QueryString("ShipBy") & " "
                End If
                Dim period = ""
                If Not IsNothing(Request.QueryString("Period")) Then
                    period &= " WHERE t.Period='" & Request.QueryString("Period") & "' "
                End If
                Dim cancel As Boolean = False
                If Not IsNothing(Request.QueryString("Cancel")) Then
                    cancel = Request.QueryString("Cancel").ToString() = "Y"
                End If
                Dim sqlm As String = SQLSelectJobSummary(tSqlW, cancel)
                If Not IsNothing(Request.QueryString("Summary")) Then
                    If Request.QueryString("Summary").ToString <> "Y" Then
                        sqlm = SQLSelectJobList(tSqlW, cancel)
                    End If
                End If
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlm & period & " ORDER BY t.Period")
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobSummary", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetJobSQL() As ActionResult
            Try
                Dim conn As String = GetSession("ConnJob")
                If Not IsNothing(Request.QueryString("DBID")) Then
                    Dim dbID = Request.QueryString("DBID")
                    conn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo.ToString, appName, dbID)(0)
                End If
                Dim oJob As New CJobOrder(conn)
                Dim tSqlW As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlW &= " AND BranchCode='" & Request.QueryString("Branch") & "'"
                End If
                If Not IsNothing(Request.QueryString("JNo")) Then
                    tSqlW &= " AND JNo='" & Request.QueryString("JNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("InvNo")) Then
                    tSqlW &= " AND InvNo='" & Request.QueryString("InvNo") & "'"
                End If
                If Not IsNothing(Request.QueryString("JType")) Then
                    tSqlW &= " AND JobType=" & Request.QueryString("JType") & ""
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    tSqlW &= " AND ShipBy=" & Request.QueryString("SBy") & ""
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlW &= " AND JobStatus IN(" & Request.QueryString("Status") & ")"
                End If
                If Not IsNothing(Request.QueryString("Year")) Then
                    tSqlW &= " AND Year(DocDate)='" & Request.QueryString("Year") & "'"
                End If
                If Not IsNothing(Request.QueryString("Month")) Then
                    tSqlW &= " AND Month(DocDate)='" & Request.QueryString("Month") & "'"
                End If
                If Not IsNothing(Request.QueryString("CustCode")) Then
                    tSqlW &= " AND CustCode='" & Request.QueryString("CustCode") & "'"
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlW &= " AND AgentCode='" & Request.QueryString("Vend") & "'"
                End If
                If Not IsNothing(Request.QueryString("CS")) Then
                    tSqlW &= " AND CSCode='" & Request.QueryString("CS") & "'"
                End If
                If Not IsNothing(Request.QueryString("Agent")) Then
                    tSqlW &= " AND ForwarderCode='" & Request.QueryString("Agent") & "'"
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlW &= " AND CustCode IN(SELECT CustCode FROM Mas_Company WHERE TaxNumber='" & Request.QueryString("TaxNumber") & "')"
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlW &= " AND DutyDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlW &= " AND DutyDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                Dim oData = oJob.GetData(" WHERE JNo<>'' " & tSqlW & " ORDER BY BranchCode,DocDate DESC")
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""job"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobSQL", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetShipBy() As ActionResult
            If Request.QueryString("Type") IsNot Nothing Then
                Dim tsqlW As String = If(Request.QueryString("Type").ToString = "", "", " AND EXISTS(select b.ConfigValue from Mas_Config b where b.ConfigCode='SHIP_BY_FILTER' and b.ConfigKey='" & Request.QueryString("Type").ToString & "' AND CHARINDEX(a.ConfigKey,b.ConfigValue)>0)")
                Dim odata = New CConfig(GetSession("ConnJob")).GetData(" a WHERE a.ConfigCode='SHIP_BY' " & tsqlW)
                Dim json = JsonConvert.SerializeObject(odata)
                json = "{""config"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Else
                Dim oData = New CConfig(GetSession("ConnJob")).GetData(" WHERE ConfigCode='SHIP_BY' ORDER BY ConfigKey ASC ")
                Dim json = JsonConvert.SerializeObject(oData)
                json = "{""config"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            End If
        End Function
        Function GetJobYear() As ActionResult
            Try
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT DISTINCT Year(DocDate) as JobYear from Job_Order")
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobYear", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetJobOrderLog() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ItemNo>0 "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode ='{0}'", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND JNo ='{0}'", Request.QueryString("Code").ToString)
                End If
                Dim oData = New CJobOrderLog(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""joborderlog"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetJobOrderLog(<FromBody()> data As CJobOrderLog) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.JNo = "" Or "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If data.ItemNo = 0 Then
                        data.AddNew()
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}' AND ItemNo={2} ", data.BranchCode, data.JNo, data.ItemNo))
                    Dim json = "{""result"":{""data"":""" & data.ItemNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelJobOrderLog() As ActionResult
            Try
                Dim tSqlw As String = " WHERE ItemNo>0 "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""joborderlog"":{""result"":""Please input branch"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND JNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""joborderlog"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If

                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format(" AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If

                Dim oData As New CJobOrderLog(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""joborderlog"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetDataDistinct() As ActionResult
            Try
                Dim tSqlW As String = ""
                If IsNothing(Request.QueryString("Field")) Then
                    Return Content("[]", jsonContent)
                End If
                If IsNothing(Request.QueryString("Table")) Then
                    Return Content("[]", jsonContent)
                End If
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT DISTINCT " + Request.QueryString("Field").ToString() + " as val from " & Request.QueryString("Table").ToString())
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetDataDistinct", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetJobDataDistinct() As ActionResult
            Try
                Dim tSqlW As String = ""
                If IsNothing(Request.QueryString("Field")) Then
                    Return Content("[]", jsonContent)
                End If
                Dim oData As DataTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT DISTINCT " + Request.QueryString("Field").ToString() + " as val from Job_Order")
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetJobDataDistinct", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetFormJobLOV() As ActionResult
            Dim html As String = "
            <div id=""frmSearchCurr"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchUser"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchCust"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchCons"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchProj"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchProd"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchVessel"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchMVessel"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchDType"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchCPort"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchIUnt"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchWUnt"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchCountry"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchFCountry"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchVend"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchForw"" class=""modal fade"" role=""dialog""></div>
            <div id=""frmSearchIPort"" class=""modal fade"" role=""dialog""></div>
"
            Return Content(html, textContent)
        End Function
        Function GetNewDelivery() As ActionResult
            Try
                Dim branch As String = ""
                Dim booking As String = ""
                Dim itemno As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    branch = Request.QueryString("Branch").ToString
                Else
                    Return Content("Please input branch", textContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    booking = Request.QueryString("Code").ToString
                Else
                    Return Content("Please input invoice/booking", textContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    itemno = Request.QueryString("Item").ToString
                Else
                    Return Content("Please enter some data", textContent)
                End If
                Dim pFormatSQL As String = "DO" & DateTime.Now().ToString("yyMM") & "_____"
                Dim data = New CTransportDetail(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' AND ItemNo={2}", branch, booking, itemno))
                Dim msg = "Data not found"
                If data.Count > 0 Then
                    Dim row = data(0)
                    row.DeliveryNo = Main.GetMaxByMask(GetSession("ConnJob"), String.Format("SELECT MAX(DeliveryNo) as t FROM Job_LoadInfoDetail WHERE BranchCode='{0}' And DeliveryNo Like '%{1}' ", branch, pFormatSQL), pFormatSQL)
                    msg = row.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' AND ItemNo={2}", branch, booking, itemno))
                    If msg.Substring(0, 1) = "S" Then
                        Dim header = New CTransportHeader(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' ", branch, booking))
                        If header.Count > 0 Then
                            Dim job = New CJobOrder(GetSession("ConnJob")).GetData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}'", row.BranchCode, row.JNo))
                            If job.Count > 0 Then
                                job(0).EstDeliverDate = row.UnloadFinishDate
                                job(0).DeliveryNo = row.DeliveryNo
                                job(0).DeliveryTo = header(0).ContactName
                                job(0).DeliveryAddr = row.Location
                                msg = job(0).SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}'", row.BranchCode, row.JNo))
                                If msg.Substring(0, 1) = "S" Then
                                    msg = row.DeliveryNo
                                Else
                                    row.DeliveryNo = ""
                                    row.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' AND ItemNo={2}", branch, booking, itemno))
                                End If
                            Else
                                msg = "Data not found"
                            End If
                        Else
                            msg = "Data not found"
                        End If
                    End If
                End If
                Return Content(msg, textContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewDelivery", ex.Message, ex.StackTrace, True)
                Return Content("[ERROR]:" + ex.Message, textContent)
            End Try
        End Function
        Function GetNewJob() As ActionResult
            Try
                Dim oJob As New CJobOrder(GetSession("ConnJob"))
                If Not IsNothing(Request.QueryString("JType")) Then
                    oJob.JobType = Convert.ToInt16("" & Request.QueryString("JType"))
                End If
                If Not IsNothing(Request.QueryString("SBy")) Then
                    oJob.ShipBy = Convert.ToInt16("" & Request.QueryString("SBy"))
                End If
                If Not IsNothing(Request.QueryString("Branch")) Then
                    oJob.BranchCode = "" & Request.QueryString("Branch")
                Else
                    oJob.BranchCode = "00"
                End If
                If Not IsNothing(Request.QueryString("Inv")) Then
                    oJob.InvNo = "" & Request.QueryString("Inv")
                End If

                Dim sql As String = String.Format(" WHERE BranchCode='{0}' AND JobType='{1}' AND ShipBy='{2}' ", oJob.BranchCode, oJob.JobType, oJob.ShipBy)
                If Not IsNothing(Request.QueryString("Cust")) Then
                    oJob.CustCode = "" & Request.QueryString("Cust").Split("|")(0)
                    oJob.CustBranch = "" & Request.QueryString("Cust").Split("|")(1)
                    Dim oCust = New CCompany(GetSession("ConnJob")).GetData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oJob.CustCode, oJob.CustBranch))
                    If oCust.Count > 0 Then
                        oJob.Commission = oCust(0).CommRate
                    Else
                        Return Content("{""job"":{""data"":[],""status"":""N"",""result"":""Customer not found""}}", jsonContent)
                    End If
                End If
                sql &= String.Format(" AND CustCode='{0}' And CustBranch='{1}' And InvNo='{2}' AND JobStatus<>99 ", oJob.CustCode, oJob.CustBranch, oJob.InvNo)
                Dim FindJob = oJob.GetData(sql)
                If FindJob.Count > 0 Then
                    If GetSession("CurrentLang") = "TH" Then
                        Return Content("{""job"":{""data"":[],""status"":""N"",""result"":""อินวอย '" + oJob.InvNo + "' ถูกเปิดไปแล้วในเลขที่ '" + FindJob(0).JNo + "' ""}}", jsonContent)
                    Else
                        Return Content("{""job"":{""data"":[],""status"":""N"",""result"":""invoice '" + oJob.InvNo + "' has been opened for job '" + FindJob(0).JNo + "' ""}}", jsonContent)
                    End If
                End If

                Dim CopyFrom As String = ""
                If Not IsNothing(Request.QueryString("CopyFrom")) Then
                    CopyFrom = "" & Request.QueryString("CopyFrom")
                End If
                If CopyFrom <> "" Then
                    FindJob = oJob.GetData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}'", oJob.BranchCode, CopyFrom))
                    If FindJob.Count > 0 Then
                        oJob = FindJob(0)
                        oJob.JNo = ""
                        oJob.CloseJobBy = ""
                        oJob.CloseJobDate = DateTime.MinValue
                        oJob.CloseJobTime = DateTime.MinValue
                        oJob.CancelDate = DateTime.MinValue
                        oJob.CancelProve = ""
                        oJob.CancelTime = DateTime.MinValue
                        oJob.JobStatus = 0
                        oJob.ConfirmDate = DateTime.MinValue
                    End If
                End If
                oJob.CreateDate = DateTime.Today
                Dim json As String = JsonConvert.SerializeObject(oJob)
                json = "{""job"":{""data"":[" & json & "],""status"":""Y"",""result"":""OK""}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetNewJob", ex.Message, ex.StackTrace, True)
                Return Content("{""job"":{""data"":[],""status"":""N"",""result"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function TestSetJobData() As ActionResult
            Dim data = New CJobOrder(GetSession("ConnJob")).GetData(" WHERE BranchCode='00' AND JNo='TS00000000'")(0)
            Try
                data.SetConnect(GetSession("ConnJob"))
                If data.BranchCode = "" Then
                    Return Content("{""msg"":""Please enter some data""}", jsonContent)
                End If
                If data.JNo = "" Then
                    Return Content("{""msg"":""Please select job number""}", jsonContent)
                End If
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetJobOrder", "Save", JsonConvert.SerializeObject(data), False)
                Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}'", data.BranchCode, data.JNo))
                Return Content("{""msg"":""" & msg & """,""data"":" & JsonConvert.SerializeObject(data) & "}", jsonContent)

            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetJobOrder", ex.Message, ex.StackTrace, True)
                Dim json = "{""msg"":""" & ex.Message & """,""data"":" & JsonConvert.SerializeObject(data) & "}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function SetJobStatus(<FromBody()> ByVal data As String()) As HttpResponseMessage
            Try
                ViewBag.User = GetSession("CurrUser").ToString()
                Dim AuthorizeStr As String = Main.GetAuthorize(ViewBag.User, "MODULE_CS", "Approve")
                If AuthorizeStr.IndexOf("E") < 0 Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If

                If IsNothing(data) Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If
                If IsNothing(Request.QueryString("Status")) Then
                    Return New HttpResponseMessage(HttpStatusCode.BadRequest)
                End If
                Dim status = Request.QueryString("Status").ToString
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
                    Select Case status
                        Case "0" 'Reopen Job
                            tSQL = String.Format("UPDATE Job_Order SET JobStatus=0,CancelProve='',CancelDate=NULL,CancelTime=NULL,CloseJobBy='',CloseJobDate=NULL,CloseJobTime=NULL  WHERE BranchCode+'|'+JNo in({0})", lst)
                        Case "1" 'Confirm
                            tSQL = String.Format("UPDATE Job_Order SET JobStatus=1,ConfirmDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "' WHERE BranchCode+'|'+JNo in({0})", lst)
                        Case "3" 'Close
                            tSQL = String.Format("UPDATE Job_Order SET JobStatus=3,CloseJobBy='" & user & "',CloseJobDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',CloseJobTime='" & DateTime.Now.ToString("HH:mm:ss") & "' WHERE BranchCode+'|'+JNo in({0})", lst)
                        Case "6" 'Billing Complete
                            tSQL = String.Format("UPDATE Job_Order SET JobStatus=6,CloseJobBy='" & user & "',CloseJobDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',CloseJobTime='" & DateTime.Now.ToString("HH:mm:ss") & "' WHERE BranchCode+'|'+JNo in({0})", lst)
                        Case "7"
                            tSQL = String.Format("UPDATE Job_Order SET JobStatus=7,CloseJobBy='" & user & "',CloseJobDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',CloseJobTime='" & DateTime.Now.ToString("HH:mm:ss") & "' WHERE BranchCode+'|'+JNo in({0})", lst)
                        Case "99"
                            tSQL = String.Format("UPDATE Job_Order SET JobStatus=99,CancelProve='" & user & "',CancelDate='" & DateTime.Now.ToString("yyyy-MM-dd") & "',CancelTime='" & DateTime.Now.ToString("HH:mm:ss") & "' WHERE BranchCode+'|'+JNo in({0})", lst)
                    End Select
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
        Function SetJobData(<FromBody()> ByVal data As CJobOrder) As ActionResult
            Try
                If Not IsNothing(data) Then
                    data.SetConnect(GetSession("ConnJob"))
                    If data.BranchCode = "" Then
                        Return Content("{""msg"":""Please enter some data""}", jsonContent)
                    End If
                    If data.JNo = "" Then
                        'Return Content("{""msg"":""Please select JobNo""}", jsonContent)
                        Dim prefix As String = GetJobPrefix(data)
                        If Not IsNothing(Request.QueryString("Prefix")) Then
                            prefix = "" & Request.QueryString("Prefix")
                        End If
                        Dim fmt = Main.GetValueConfig("RUNNING", "JOB")
                        If fmt <> "" Then
                            If fmt.IndexOf("bb") >= 0 Then
                                fmt = fmt.Replace("bb", data.DocDate.AddYears(543).ToString("yy"))
                            End If
                            If fmt.IndexOf("yy") >= 0 Then
                                fmt = fmt.Replace("yy", data.DocDate.ToString("yy"))
                            End If
                            If fmt.IndexOf("MM") >= 0 Then
                                fmt = fmt.Replace("MM", data.DocDate.ToString("MM"))
                            End If
                        Else
                            fmt = data.DocDate.ToString("yyMM") & "____"
                        End If
                        If Main.GetValueConfig("PROFILE", "RUNNING_BYMASK") = "N" Then
                            data.AddNew("%" & fmt, False)
                            If data.JNo.IndexOf("%") > 0 Then
                                data.JNo = data.JNo.Replace("%", prefix)
                            Else
                                data.JNo = prefix & data.JNo.Substring(3)
                            End If
                        Else
                            data.AddNew(prefix & fmt, False)
                        End If
                    End If
                    Dim sql As String = String.Format(" WHERE CustCode='{0}' And BranchCode='{1}' And InvNo='{2}' AND JobStatus<>99 ", data.CustCode, data.BranchCode, data.InvNo)
                    Dim FindJob = New CJobOrder(GetSession("ConnJob")).GetData(sql)
                    If FindJob.Count > 0 Then
                        If FindJob(0).JNo <> data.JNo Then
                            Return Content("{""msg"":""invoice '" + data.InvNo + "' has been opened for job '" + FindJob(0).JNo + "' ""}", jsonContent)
                        End If
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}'", data.BranchCode, data.JNo))
                    'Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetJobOrder", "Save", JsonConvert.SerializeObject(data), False)
                    Return Content("{""msg"":""" & msg & """,""result"":""" & data.JNo & """}", jsonContent)
                Else
                    Return Content("{""msg"":""No data to Save"",""result"":""" & data.JNo & """}", jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetJobOrder", ex.Message, ex.StackTrace, True)
                Dim json = "{""msg"":""" & ex.Message & """,""result"":""" & data.JNo & """}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function UpdateJobStatus() As ActionResult
            Dim tSqlW As String = ""
            Dim bLog As Boolean = True
            If Not IsNothing(Request.QueryString("NoLog")) Then
                bLog = Request.QueryString("NoLog").ToString IsNot "Y"
            End If
            If Not IsNothing(Request.QueryString("JType")) Then
                tSqlW &= " AND j.JobType=" & Request.QueryString("JType") & ""
            End If
            If Not IsNothing(Request.QueryString("SBy")) Then
                tSqlW &= " AND j.ShipBy=" & Request.QueryString("SBy") & ""
            End If
            If Not IsNothing(Request.QueryString("Branch")) Then
                tSqlW &= " AND j.BranchCode='" & Request.QueryString("Branch") & "'"
            End If
            If Not IsNothing(Request.QueryString("Status")) Then
                tSqlW &= " AND j.JobStatus='" & Request.QueryString("Status") & "'"
            End If
            If Not IsNothing(Request.QueryString("JNo")) Then
                tSqlW &= " AND j.JNo='" & Request.QueryString("JNo") & "'"
            End If
            If Not IsNothing(Request.QueryString("Year")) Then
                tSqlW &= " AND Year(j.DocDate)='" & Request.QueryString("Year") & "'"
            End If
            If Not IsNothing(Request.QueryString("Month")) Then
                tSqlW &= " AND Month(j.DocDate)='" & Request.QueryString("Month") & "'"
            End If
            If Not IsNothing(Request.QueryString("CSCode")) Then
                tSqlW &= " AND j.CSCode='" & Request.QueryString("CSCode") & "'"
            End If
            If Not IsNothing(Request.QueryString("CustCode")) Then
                tSqlW &= " AND j.CustCode='" & Request.QueryString("CustCode") & "'"
            End If
            If Not IsNothing(Request.QueryString("ShippingCode")) Then
                tSqlW &= " AND j.ShippingEmp='" & Request.QueryString("ShippingCode") & "'"
            End If
            If Not IsNothing(Request.QueryString("ManagerCode")) Then
                tSqlW &= " AND j.ManagerCode='" & Request.QueryString("ManagerCode") & "'"
            End If
            If Not IsNothing(Request.QueryString("TaxNumber")) Then
                tSqlW &= " AND j.CustCode IN(SELECT CustCode FROM Mas_Company WHERE TaxNumber='" & Request.QueryString("TaxNumber") & "')"
            End If
            Dim oCmd = New CUtil(GetSession("ConnJob"))
            oCmd.ExecuteSQL(SQLUpdateCashFlowToJob() & tSqlW)
            Dim tResult = oCmd.ExecuteSQL(SQLUpdateJobStatus(tSqlW), bLog)
            Return Content(tResult, textContent)
        End Function
        Function GetDashboardSQL() As ActionResult
            Dim json1 = SQLDashboard1("")
            Dim json2 = SQLDashboard2("")
            Dim json3 = SQLDashboard3("")
            Return Content("{""result"":[{""data1"":""" & json1 & """,""data2"":""" & json2 & """,""data3"":""" & json3 & """}]}", jsonContent)
        End Function
        Function GetTimelineReport() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}'", Request.QueryString("Branch").ToString())
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Doc")) Then
                    tSqlw &= String.Format(" AND DeliveryNo='{0}' ", Request.QueryString("Doc").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw &= String.Format(" AND JobStatus='{0}' ", Request.QueryString("Status").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND ForwarderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND DutyDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND DutyDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If
                Dim onDate As Date = DateTime.Today
                If Not IsNothing(Request.QueryString("OnDate")) Then
                    onDate = Convert.ToDateTime(Request.QueryString("OnDate").ToString())
                End If
                Dim useDate As String = "DutyDate"
                If Not IsNothing(Request.QueryString("UseDate")) Then
                    useDate = Request.QueryString("UseDate").ToString()
                End If
                Dim totDays As Integer = 3
                If Not IsNothing(Request.QueryString("Days")) Then
                    totDays = Convert.ToInt32(Request.QueryString("Days").ToString())
                End If
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectTrackingDay(useDate, onDate, totDays, tSqlw))
                Dim json As String = ""
                Dim jsonD As String = ""
                For i As Integer = 0 To oData.Rows.Count - 1
                    If i = 0 Then
                        jsonD = "["
                        For j As Integer = 0 To oData.Columns.Count - 1
                            If jsonD <> "[" Then
                                jsonD &= ","
                            End If
                            jsonD &= """" & oData.Columns(j).ColumnName & """"
                        Next
                        jsonD &= "]"
                    End If
                    jsonD &= ",["
                    For j As Integer = 0 To oData.Columns.Count - 1
                        If j > 0 Then
                            jsonD &= ","
                        End If
                        If oData.Columns(j).ColumnName = "JobDay" Then
                            jsonD &= """" & oData.Rows(i)(j) & """"
                        Else
                            jsonD &= "" & oData.Rows(i)(j)
                        End If
                    Next
                    jsonD &= "]"
                Next
                json = "{""tracking"":{""data"":[" & jsonD & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTimelineReport", ex.Message, ex.StackTrace, True)
                Return Content("{""tracking"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetTrackingSummary() As ActionResult
            Try
                Dim tSqlw As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND Job_Order.BranchCode='{0}'", Request.QueryString("Branch").ToString())
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format(" AND Job_Order.JNo='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfo.BookingNo='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Doc")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfoDetail.DeliveryNo='{0}' ", Request.QueryString("Doc").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND Job_Order.CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Status")) Then
                    tSqlw &= String.Format(" AND Job_Order.JobStatus='{0}' ", Request.QueryString("Status").ToString)
                End If
                If Not IsNothing(Request.QueryString("TaxNumber")) Then
                    tSqlw &= String.Format(" AND Mas_Company.TaxNumber='{0}' ", Request.QueryString("TaxNumber").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND Job_LoadInfo.VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= " AND Job_Order.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00'"
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= " AND Job_Order.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00'"
                End If

                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLSelectTrackingCount(tSqlw))
                Dim json As String = ""
                For i As Integer = 0 To oData.Rows.Count - 1
                    If i = 0 Then
                        json = "[""Status"",""Volume"", {""role"": ""style"" }]"
                    End If
                    Dim status As String = Convert.ToInt16(oData.Rows(i)("JobStatus")).ToString("00")
                    json &= ",[""" & GetValueConfig("JOB_STATUS", status) & """," & oData.Rows(i)("TotalJob") & ","
                    Select Case status
                        Case "00"
                            json &= """color:aqua"""
                        Case "01"
                            json &= """color:aquamarine"""
                        Case "02"
                            json &= """color:cadetblue"""
                        Case "03"
                            json &= """color:chocolate"""
                        Case "04"
                            json &= """color:brown"""
                        Case "05"
                            json &= """color:blueviolet"""
                        Case "06"
                            json &= """color:crimson"""
                        Case "07"
                            json &= """color:darkgreen"""
                        Case "98"
                            json &= """color:dimgrey"""
                        Case "99"
                            json &= """color:red"""
                        Case Else
                            json &= """color:black"""
                    End Select
                    json &= "]"
                Next
                json = "{""transport"":{""data"":[" & json & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTrackingSummary", ex.Message, ex.StackTrace, True)
                Return Content("{""transport"":{""data"":[],""msg"":""" & ex.Message & """}}", jsonContent)
            End Try
        End Function
        Function GetDashboard() As ActionResult
            Try
                If GetSession("ConnJob") = "" Then
                    Return Content("{""result"":[],""msg"":""No Connection""}", jsonContent)
                End If
                Dim msg As String = New CUtil(GetSession("ConnJob")).ExecuteSQL(SQLUpdateJobStatus(""), False)
                Dim tSqlw1 As String = ""
                Dim bCheck As Boolean = False
                If Request.QueryString("Period") IsNot Nothing Then
                    bCheck = True
                    Dim yy = Request.QueryString("Period").ToString().Split("/")(1)
                    Dim mm = Convert.ToInt16(Request.QueryString("Period").ToString().Split("/")(0))
                    tSqlw1 = " WHERE Year(j.DocDate)=" & yy & " AND Month(j.DocDate)=" & mm & " "
                Else
                    If Request.QueryString("DateFrom") IsNot Nothing Then
                        If Request.QueryString("DateFrom").ToString() <> "" Then
                            bCheck = True
                            tSqlw1 = " WHERE j.DutyDate>=Convert(datetime,'" & Request.QueryString("DateFrom").ToString() & " 00:00:00',102) "
                        End If
                    End If
                    If Request.QueryString("DateTo") IsNot Nothing Then
                        If Request.QueryString("DateTo").ToString() <> "" Then
                            bCheck = True
                            If tSqlw1 <> "" Then tSqlw1 &= " AND " Else tSqlw1 = " WHERE "
                            tSqlw1 &= " j.DutyDate<=Convert(datetime,'" & Request.QueryString("DateTo").ToString() & " 23:59:59',102) "
                        End If
                    End If
                End If
                If Request.QueryString("ShipBy") IsNot Nothing Then
                    If bCheck Then
                        tSqlw1 &= " AND "
                    Else
                        tSqlw1 &= " WHERE "
                        bCheck = True
                    End If
                    tSqlw1 &= " j.ShipBy=" & Request.QueryString("ShipBy").ToString & " "
                End If
                If Request.QueryString("JobType") IsNot Nothing Then
                    If bCheck Then
                        tSqlw1 &= " AND "
                    Else
                        tSqlw1 &= " WHERE "
                        bCheck = True
                    End If
                    tSqlw1 &= " j.JobType=" & Request.QueryString("JobType").ToString & " "
                End If
                If Request.QueryString("Cust") IsNot Nothing Then
                    If bCheck Then
                        tSqlw1 &= " AND "
                    Else
                        tSqlw1 &= " WHERE "
                        bCheck = True
                    End If
                    tSqlw1 &= " j.CustCode IN(SELECT CustCode FROM Mas_Company WHERE LoginName='" & Request.QueryString("Cust").ToString & "') "
                End If
                Dim oData1 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLDashboard1(tSqlw1))
                msg = SQLDashboard1(tSqlw1)
                Dim json1 As String = ""
                json1 = "[""Status"",""Volume""]"
                Dim oStatus = Main.GetDataConfig("JOB_STATUS")
                If oData1.Rows.Count = 0 Then
                    json1 &= ",[""ALL"",0]"
                Else
                    Dim bFound As Boolean = False
                    For Each oRow As CConfig In oStatus
                        bFound = False
                        For i As Integer = 0 To oData1.Rows.Count - 1
                            If oData1.Rows(i)("TotalJob").Equals(System.DBNull.Value) = False Then
                                If oRow.ConfigKey.Equals(Convert.ToInt16(oData1.Rows(i)("JobStatus")).ToString("00")) Then
                                    bFound = True
                                    json1 &= ",[""" & oRow.ConfigValue & """," & oData1.Rows(i)("TotalJob") & "]"
                                    Exit For
                                End If
                            End If
                        Next
                        If bFound = False Then
                            json1 &= ",[""" & oRow.ConfigValue & """,0]"
                        End If
                    Next
                End If
                Dim oData2 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLDashboard2(tSqlw1))
                msg = SQLDashboard2(tSqlw1)
                Dim json2 As String = ""
                For i As Integer = 0 To oData2.Rows.Count - 1
                    If i = 0 Then
                        json2 = "["
                        For j As Integer = 0 To oData2.Columns.Count - 1
                            If json2 <> "[" Then
                                json2 &= ","
                            End If
                            json2 &= """" & oData2.Columns(j).ColumnName & """"
                        Next
                        json2 &= "]"
                    End If
                    json2 &= ",["
                    For j As Integer = 0 To oData2.Columns.Count - 1
                        If j > 0 Then
                            json2 &= ","
                        End If
                        If oData2.Columns(j).ColumnName = "ShipBy" Then
                            If oData2.Rows(i)("ShipBy").Equals(System.DBNull.Value) = False Then
                                Dim status As String = Convert.ToInt16(oData2.Rows(i)("ShipBy")).ToString("00")
                                json2 &= """" & GetValueConfig("SHIP_BY", status) & """"
                            Else
                                json2 &= """ALL"""
                            End If
                        Else
                            json2 &= "" & oData2.Rows(i)(j)
                        End If
                    Next
                    json2 &= "]"
                Next

                Dim oData3 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLDashboard3(tSqlw1))
                msg = SQLDashboard3(tSqlw1)

                Dim json3 As String = ""
                For i As Integer = 0 To oData3.Rows.Count - 1
                    If i = 0 Then
                        json3 = "["
                        For j As Integer = 0 To oData3.Columns.Count - 1
                            If json3 <> "[" Then
                                json3 &= ","
                            End If
                            json3 &= """" & oData3.Columns(j).ColumnName & """"
                        Next
                        json3 &= "]"
                    End If
                    json3 &= ",["
                    For j As Integer = 0 To oData3.Columns.Count - 1
                        If j > 0 Then
                            json3 &= ","
                        End If
                        If oData3.Columns(j).ColumnName = "CustCode" Then
                            json3 &= """" & oData3.Rows(i)(j) & """"
                        Else
                            json3 &= "" & oData3.Rows(i)(j)
                        End If
                    Next
                    json3 &= "]"
                Next
                Return Content("{""result"":[{""data1"":[" & json1 & "],""data2"":[" & json2 & "],""data3"":[" & json3 & "]}]}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetDashboard", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""msg"":""" & ex.Message & """}", jsonContent)
            End Try
        End Function
        Function GetDashboard_V2() As ActionResult
            Try
                If GetSession("ConnJob") = "" Then
                    Return Content("{""result"":[],""msg"":""No Connection""}", jsonContent)
                End If
                Dim msg As String = New CUtil(GetSession("ConnJob")).ExecuteSQL(SQLUpdateJobStatus(""), False)
                Dim tSqlw1 As String = ""
                Dim bCheck As Boolean = False
                If Request.QueryString("Period") IsNot Nothing Then
                    bCheck = True
                    Dim yy = Request.QueryString("Period").ToString().Split("/")(1)
                    Dim mm = Convert.ToInt16(Request.QueryString("Period").ToString().Split("/")(0))
                    tSqlw1 = " WHERE Year(j.DocDate)=" & yy & " AND Month(j.DocDate)=" & mm & " "
                Else
                    If Request.QueryString("DateFrom") IsNot Nothing Then
                        If Request.QueryString("DateFrom").ToString() <> "" Then
                            bCheck = True
                            tSqlw1 = " WHERE j.DutyDate>=Convert(datetime,'" & Request.QueryString("DateFrom").ToString() & " 00:00:00',102) "
                        End If
                    End If
                    If Request.QueryString("DateTo") IsNot Nothing Then
                        If Request.QueryString("DateTo").ToString() <> "" Then
                            bCheck = True
                            If tSqlw1 <> "" Then tSqlw1 &= " AND " Else tSqlw1 = " WHERE "
                            tSqlw1 &= " j.DutyDate<=Convert(datetime,'" & Request.QueryString("DateTo").ToString() & " 23:59:59',102) "
                        End If
                    End If
                End If
                If Request.QueryString("ShipBy") IsNot Nothing Then
                    If bCheck Then
                        tSqlw1 &= " AND "
                    Else
                        tSqlw1 &= " WHERE "
                        bCheck = True
                    End If
                    tSqlw1 &= " j.ShipBy=" & Request.QueryString("ShipBy").ToString & " "
                End If
                If Request.QueryString("JobType") IsNot Nothing Then
                    If bCheck Then
                        tSqlw1 &= " AND "
                    Else
                        tSqlw1 &= " WHERE "
                        bCheck = True
                    End If
                    tSqlw1 &= " j.JobType=" & Request.QueryString("JobType").ToString & " "
                End If
                If Request.QueryString("Cust") IsNot Nothing Then
                    If bCheck Then
                        tSqlw1 &= " AND "
                    Else
                        tSqlw1 &= " WHERE "
                        bCheck = True
                    End If
                    tSqlw1 &= " j.CustCode IN(SELECT CustCode FROM Mas_Company WHERE LoginName='" & Request.QueryString("Cust").ToString & "') "
                End If
                Dim oData1 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLDashboard1(tSqlw1))
                msg = SQLDashboard1(tSqlw1)
                Dim json1 As String = ""
                json1 = "[""Status"",""Volume""]"
                Dim oStatus = Main.GetDataConfig("JOB_STATUS")
                If oData1.Rows.Count = 0 Then
                    json1 &= ",[""ALL"",0]"
                Else
                    Dim bFound As Boolean = False
                    For Each oRow As CConfig In oStatus
                        bFound = False
                        For i As Integer = 0 To oData1.Rows.Count - 1
                            If oData1.Rows(i)("TotalJob").Equals(System.DBNull.Value) = False Then
                                If oRow.ConfigKey.Equals(Convert.ToInt16(oData1.Rows(i)("JobStatus")).ToString("00")) Then
                                    bFound = True
                                    json1 &= ",[""" & oRow.ConfigValue & """," & oData1.Rows(i)("TotalJob") & "]"
                                    Exit For
                                End If
                            End If
                        Next
                        If bFound = False Then
                            json1 &= ",[""" & oRow.ConfigValue & """,0]"
                        End If
                    Next
                End If
                Dim oData2 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLDashboard4(tSqlw1))
                msg = SQLDashboard4(tSqlw1)
                Dim json2 As String = ""
                For i As Integer = 0 To oData2.Rows.Count - 1
                    If i = 0 Then
                        json2 = "["
                        For j As Integer = 0 To oData2.Columns.Count - 1
                            If json2 <> "[" Then
                                json2 &= ","
                            End If
                            json2 &= """" & oData2.Columns(j).ColumnName & """"
                        Next
                        json2 &= "]"
                    End If
                    json2 &= ",["
                    For j As Integer = 0 To oData2.Columns.Count - 1
                        If j > 0 Then
                            json2 &= ","
                        End If
                        If oData2.Columns(j).ColumnName = "JobType" Then
                            If oData2.Rows(i)("JobType").Equals(System.DBNull.Value) = False Then
                                Dim status As String = Convert.ToInt16(oData2.Rows(i)("JobType")).ToString("00")
                                json2 &= """" & GetValueConfig("JOB_TYPE", status) & """"
                            Else
                                json2 &= """ALL"""
                            End If
                        Else
                            json2 &= "" & oData2.Rows(i)(j)
                        End If
                    Next
                    json2 &= "]"
                Next

                Dim oData3 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(SQLDashboard5(tSqlw1))
                msg = SQLDashboard3(tSqlw1)

                Dim json3 As String = ""
                For i As Integer = 0 To oData3.Rows.Count - 1
                    If i = 0 Then
                        json3 = "["
                        For j As Integer = 0 To oData3.Columns.Count - 1
                            If json3 <> "[" Then
                                json3 &= ","
                            End If
                            json3 &= """" & oData3.Columns(j).ColumnName & """"
                        Next
                        json3 &= "]"
                    End If
                    json3 &= ",["
                    For j As Integer = 0 To oData3.Columns.Count - 1
                        If j > 0 Then
                            json3 &= ","
                        End If
                        If oData3.Columns(j).ColumnName = "CSCode" Then
                            Dim oUser = New CUser(GetSession("ConnJob")).GetData(String.Format(" WHERE UserID='{0}'", oData3.Rows(i)(j)))
                            If oUser.Count > 0 Then
                                json3 &= """" & oUser(0).TName & """"
                            Else
                                json3 &= """" & oData3.Rows(i)(j) & """"
                            End If
                        Else
                            json3 &= "" & oData3.Rows(i)(j)
                        End If
                    Next
                    json3 &= "]"
                Next
                Return Content("{""result"":[{""data1"":[" & json1 & "],""data2"":[" & json2 & "],""data3"":[" & json3 & "]}]}", jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetDashboard", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""msg"":""" & ex.Message & """}", jsonContent)
            End Try
        End Function
        Function GetDocument() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND JNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Type")) Then
                    tSqlw &= String.Format("AND DocType ='{0}' ", Request.QueryString("Type").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                Dim oData = New CDocument(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""document"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetDocument", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetDocument(<FromBody()> data As CDocument) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    If "" & data.JNo = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If data.ItemNo = 0 Then
                        data.AddNew()
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}' AND ItemNo={2} ", data.BranchCode, data.JNo, data.ItemNo))
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetDocument", "Save", JsonConvert.SerializeObject(data), False)
                    Dim json = "{""result"":{""data"":""" & data.JNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetDocument", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelDocument() As ActionResult
            Try
                Dim tSqlw As String = " WHERE JNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                Else
                    Return Content("{""document"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND JNo='{0}' ", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""document"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND ItemNo={0} ", Request.QueryString("Item").ToString)
                End If
                Dim oData As New CDocument(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelDocument", "SQL", tSqlw, False)
                Dim json = "{""document"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelDocument", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetTransportPrice() As ActionResult
            Try
                Dim tSqlw As String = " WHERE LocationID>0 "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format(" AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format(" AND LocationID ={0} ", Request.QueryString("ID").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format(" AND VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format(" AND CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format(" AND SICode='{0}' ", Request.QueryString("Code").ToString)
                End If
                tSqlw &= String.Format(" AND LocationID IN(SELECT LocationID From Job_TransportRoute WHERE IsActive=1) ")
                Dim oData = New CTransportPrice(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""transportprice"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransportPrice", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetTransportPrice(<FromBody()> data As CTransportPrice) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.BranchCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input branch""}}", jsonContent)
                    End If
                    If "" & data.VenderCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please choose vender first""}}", jsonContent)
                    End If
                    If "" & data.CustCode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please choose customer first""}}", jsonContent)
                    End If
                    If "" & data.SICode = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please input expense code""}}", jsonContent)
                    End If
                    If data.LocationID = 0 Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND LocationID={1} AND VenderCode='{2}' AND CustCode='{3}' AND SICode='{4}'  ", data.BranchCode, data.LocationID, data.VenderCode, data.CustCode, data.SICode))
                    Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportPrice", "Save", JsonConvert.SerializeObject(data), False)
                    Dim json = "{""result"":{""data"":""" & data.LocationID & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportPrice", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelTransportPrice() As ActionResult
            Try
                Dim tSqlw As String = " WHERE LocationID>0 "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format("AND LocationID={0} ", Request.QueryString("ID").ToString)
                End If
                If Not IsNothing(Request.QueryString("Vend")) Then
                    tSqlw &= String.Format("AND VenderCode='{0}' ", Request.QueryString("Vend").ToString)
                End If
                If Not IsNothing(Request.QueryString("Cust")) Then
                    tSqlw &= String.Format("AND CustCode='{0}' ", Request.QueryString("Cust").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND SICode='{0}' ", Request.QueryString("Code").ToString)
                End If
                Dim oData As New CTransportPrice(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelTransportPrice", "SQL", tSqlw, False)
                Dim json = "{""transportprice"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelTransportPrice", ex.Message, ex.StackTrace, True)
                Return Content("{""transportprice"":{""result"":""" & ex.Message & """,""data"":[]}}", jsonContent)
            End Try
        End Function
        Function GetTransportRoute() As ActionResult
            Try
                Dim tSqlw As String = " WHERE IsActive=1 "
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format("AND LocationID ={0}", Request.QueryString("ID").ToString)
                End If
                If Not IsNothing(Request.QueryString("Place1")) Then
                    tSqlw &= String.Format("AND Place1='{0}' ", Request.QueryString("Place1").ToString)
                End If
                If Not IsNothing(Request.QueryString("Place2")) Then
                    tSqlw &= String.Format("AND Place2='{0}' ", Request.QueryString("Place2").ToString)
                End If
                If Not IsNothing(Request.QueryString("Place3")) Then
                    tSqlw &= String.Format("AND Place3='{0}' ", Request.QueryString("Place3").ToString)
                End If
                If Not IsNothing(Request.QueryString("Place4")) Then
                    tSqlw &= String.Format("AND Place4='{0}' ", Request.QueryString("Place4").ToString)
                End If
                Dim oData = New CTransportRoute(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""transportroute"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetTransportRoute", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetTransportRoute(<FromBody()> data As CTransportRoute) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If "" & data.LocationRoute = "" Then
                        Return Content("{""result"":{""data"":null,""msg"":""Please enter some data""}}", jsonContent)
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    Dim msg = data.SaveData(String.Format(" WHERE LocationID={0} ", data.LocationID))
                    If msg.Substring(0, 1) <> "[" Then
                        Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportRoute", "Save", JsonConvert.SerializeObject(data), False)
                    Else
                        Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportRoute", "Save", msg, True)
                    End If
                    Dim json = "{""result"":{""data"":""" & data.LocationID & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No data to Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "SetTransportRoute", ex.Message, ex.StackTrace, True)
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelTransportRoute() As ActionResult
            Try
                Dim tSqlw As String = " WHERE LocationID>0 "
                If Not IsNothing(Request.QueryString("ID")) Then
                    tSqlw &= String.Format("AND LocationID ={0}", Request.QueryString("ID").ToString)
                Else
                    Return Content("{""transportroute"":{""result"":""Please enter some data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CTransportRoute(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelTransportRoute", "SQL", tSqlw, False)
                Dim json = "{""transportroute"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "DelTransportRoute", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function GetPaperless() As ActionResult
            Try
                Dim listPaperless = Main.GetValueConfig("PAPERLESS", "DBLINK")
                Dim hostPaperless = Main.GetValueConfig("PAPERLESS", "DBHOST")
                Dim dbPaperless = Main.GetValueConfig("PAPERLESS", "DBTYPE")

                Dim job As String = ""
                Dim type As Integer = 0
                If Request.QueryString("job") IsNot Nothing Then
                    job = Request.QueryString("job")
                End If
                If Request.QueryString("type") IsNot Nothing Then
                    type = Convert.ToInt16(Request.QueryString("type").ToString()) - 1
                End If
                If dbPaperless = "ECS" Then
                    Dim connStr = hostPaperless & ";Initial Catalog=" & listPaperless.Split(",")(type)
                    Dim dt As New DataTable
                    Using cn As SqlClient.SqlConnection = New SqlClient.SqlConnection(connStr)
                        cn.Open()
                        Dim sql As String = ""
                        If type = 0 Then
                            sql = "SELECT * FROM qDecI_Declare where ECS_JobNO='{0}'"
                        Else
                            sql = "SELECT * FROM qDecX_Declare where ECS_JobNO='{0}'"
                        End If
                        Using da As New SqlClient.SqlDataAdapter(String.Format(sql, job), cn)
                            da.Fill(dt)
                        End Using
                        cn.Close()
                    End Using
                    Dim json = JsonConvert.SerializeObject(dt)
                    Return Content(json, jsonContent)
                Else
                    Dim connStr = hostPaperless & ";database=" & listPaperless.Split(",")(type)
                    Dim dt As New DataTable
                    Using cn As MySqlConnection = New MySqlConnection(connStr)
                        cn.Open()
                        Dim sql As String = String.Format("Select decl.*,inv.invoiceno from decl inner join inv On decl.referenceno=inv.referenceno where decl.refnocmn='{0}' and decl.refnocmn<>'' and decl.status<>'C' ", job)
                        Using da As New MySqlDataAdapter(sql, cn)
                            da.Fill(dt)
                        End Using
                        cn.Close()
                    End Using
                    Dim json = JsonConvert.SerializeObject(dt)
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetPaperless", ex.Message, ex.StackTrace, True)
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function FormSalesContract() As ActionResult
            Return GetView("FormSalesContract")
        End Function
        Function FormInvoice() As ActionResult
            Return GetView("FormInvoice")
        End Function
        Function FormPackingList() As ActionResult
            Return GetView("FormPackingList")
        End Function
        Function AddFuel() As ActionResult
            Return GetView("AddFuel")
        End Function
        Function GetAddFuel() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlw &= String.Format("AND BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
                End If
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo ='{0}' ", Request.QueryString("Code").ToString)
                End If
                If Not IsNothing(Request.QueryString("Job")) Then
                    tSqlw &= String.Format("AND JNo ='{0}' ", Request.QueryString("Job").ToString)
                End If
                If Not IsNothing(Request.QueryString("Station")) Then
                    tSqlw &= String.Format("AND StationCode ='{0}' ", Request.QueryString("Station").ToString)
                End If
                If Not IsNothing(Request.QueryString("Booking")) Then
                    tSqlw &= String.Format("AND BookingNo ='{0}' ", Request.QueryString("Booking").ToString)
                End If
                If Not IsNothing(Request.QueryString("Item")) Then
                    tSqlw &= String.Format("AND BookingItemNo ={0} ", Request.QueryString("Item").ToString)
                End If
                If Not IsNothing(Request.QueryString("DateFrom")) Then
                    tSqlw &= "AND DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
                End If
                If Not IsNothing(Request.QueryString("DateTo")) Then
                    tSqlw &= "AND DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
                End If

                Dim oData = New CAddFuel(GetSession("ConnJob")).GetData(tSqlw)
                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""addfuel"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function SetAddFuel(<FromBody()> data As CAddFuel) As ActionResult
            Try
                If Not IsNothing(data) Then
                    If data.DocDate = DateTime.MinValue Then
                        data.DocDate = Today.Date
                    End If
                    data.SetConnect(GetSession("ConnJob"))
                    If "" & data.DocNo = "" Then
                        'Return Content("{""result"":{""data"":null,""msg"":""Please Enter Data""}}", jsonContent)
                        data.AddNew("RF" & data.DocDate.ToString("yyMM") & "____")
                    End If
                    Dim msg = data.SaveData(String.Format(" WHERE DocNo='{0}' ", data.DocNo))
                    Dim json = "{""result"":{""data"":""" & data.DocNo & """,""msg"":""" & msg & """}}"
                    Return Content(json, jsonContent)
                Else
                    Dim json = "{""result"":{""data"":null,""msg"":""No Data To Save""}}"
                    Return Content(json, jsonContent)
                End If
            Catch ex As Exception
                Dim json = "{""result"":{""data"":null,""msg"":""" & ex.Message & """}}"
                Return Content(json, jsonContent)
            End Try
        End Function
        Function DelAddFuel() As ActionResult
            Try
                Dim tSqlw As String = " WHERE DocNo<>'' "
                If Not IsNothing(Request.QueryString("Code")) Then
                    tSqlw &= String.Format("AND DocNo Like '{0}'", Request.QueryString("Code").ToString)
                Else
                    Return Content("{""addfuel"":{""result"":""Please Select Some Data"",""data"":[]}}", jsonContent)
                End If
                Dim oData As New CAddFuel(GetSession("ConnJob"))
                Dim msg = oData.DeleteData(tSqlw)

                Dim json = "{""addfuel"":{""result"":""" & msg & """,""data"":[" & JsonConvert.SerializeObject(oData) & "]}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]", jsonContent)
            End Try
        End Function
        Function FormAddFuel() As ActionResult
            Return GetView("FormAddFuel")
        End Function
        Function CopyTransportData() As ActionResult
            Dim rowsCont = 0
            Dim bookingCount = 0
            Dim dbID = ""
            If Request.QueryString("DBID") Is Nothing Then
                Return Content("Source Database not found", textContent)
            Else
                dbID = Request.QueryString("DBID")
            End If
            Dim sourceJob = ""
            If Request.QueryString("FROM") Is Nothing Then
                Return Content("Source job not found", textContent)
            Else
                sourceJob = Request.QueryString("FROM")
            End If
            Dim destJob = ""
            If Request.QueryString("TO") Is Nothing Then
                Return Content("Destination job not found", textContent)
            Else
                destJob = Request.QueryString("TO")
            End If
            Dim conn = Main.GetDatabaseConnection(My.Settings.LicenseTo, "JOBSHIPPING", dbID)(0)
            If conn = "" Then
                Return Content("Connection not found", textContent)
            Else
                Dim oRowSource = New CTransportHeader(conn).GetData(String.Format(" WHERE JNo='{0}'", sourceJob))
                For Each row In oRowSource
                    row.SetConnect(GetSession("ConnJob"))
                    row.JNo = destJob
                    Dim result = row.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}'", row.BranchCode, row.BookingNo))
                    If result.Substring(0, 1) = "S" Then
                        bookingCount += 1
                        Dim oContSource = New CTransportDetail(conn).GetData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}'", row.BranchCode, row.BookingNo))
                        For Each cont In oContSource
                            cont.SetConnect(GetSession("ConnJob"))
                            cont.JNo = destJob
                            Dim msg = cont.SaveData(String.Format(" WHERE BranchCode='{0}' AND BookingNo='{1}' AND ItemNo={2}", cont.BranchCode, cont.BookingNo, cont.ItemNo))
                            If msg.Substring(0, 1) = "S" Then
                                rowsCont += 1
                            End If
                        Next
                    End If
                Next
                Return Content("Total " + rowsCont + " row(s) copied! (" & bookingCount & " Booking)", textContent)
            End If
        End Function
        Function CloseFuel() As ActionResult
            ViewBag.DataForApprove = New CAddFuel(GetSession("ConnJob")).GetData(" WHERE ISNULL(ApproveBy,'')='' AND ISNULL(CancelBy,'')='' ")
            ViewBag.DataForBill = New CAddFuel(GetSession("ConnJob")).GetData(" WHERE ISNULL(ApproveBy,'')<>'' AND ISNULL(StationInvNo,'')='' AND ISNULL(CancelBy,'')=''")
            ViewBag.DataBilled = New CAddFuel(GetSession("ConnJob")).GetData(" WHERE ISNULL(ApproveBy,'')<>'' AND ISNULL(StationInvNo,'')<>'' AND ISNULL(CancelBy,'')=''")
            ViewBag.MessageBill = "Ready"
            ViewBag.MessageApp = "Ready"
            Return GetView("CloseFuel")
        End Function
        <HttpPost()>
        Function SetInvoiceFuel() As ActionResult
            Dim approveList = Request.Form("txtBilling") & ","
            For Each doc In approveList.Split(",")
                If doc <> "" Then
                    Main.DBExecute(GetSession("ConnJob"), String.Format("UPDATE Job_AddFuel SET StationInvNo='{0}' WHERE BranchCode='{1}' AND DocNo='{2}'", Request.Form("txtInvNo"), GetSession("CurrBranch"), doc))
                End If
            Next
            ViewBag.DataForApprove = New CAddFuel(GetSession("ConnJob")).GetData(" WHERE ISNULL(ApproveBy,'')='' AND ISNULL(CancelBy,'')='' ")
            ViewBag.DataForBill = New CAddFuel(GetSession("ConnJob")).GetData(" WHERE ISNULL(ApproveBy,'')<>'' AND ISNULL(StationInvNo,'')='' AND ISNULL(CancelBy,'')=''")
            ViewBag.DataBilled = New CAddFuel(GetSession("ConnJob")).GetData(" WHERE ISNULL(ApproveBy,'')<>'' AND ISNULL(StationInvNo,'')<>'' AND ISNULL(CancelBy,'')=''")
            ViewBag.MessageApp = "Ready"
            ViewBag.MessageBill = approveList + " Updated"
            Return GetView("CloseFuel")
        End Function

        Function GetJobOSQL() As ActionResult
            Try
                Dim conn As String = GetSession("ConnJob")

                Dim oJob As New CJobOrderN(conn)
                Dim tSqlW As String = ""
                If Not IsNothing(Request.QueryString("Branch")) Then
                    tSqlW &= " AND f.BranchCode='" & Request.QueryString("Branch") & "'"
                End If
                If Not IsNothing(Request.QueryString("JNo")) Then
                    tSqlW &= " AND f.JNo='" & Request.QueryString("JNo") & "'"
                End If
                Dim oData = oJob.GetData(" WHERE f.JNo<>'' AND f.BranchCode<>''" & tSqlW & " ORDER BY BranchCode,DocDate DESC")

                Dim json As String = JsonConvert.SerializeObject(oData)
                json = "{""job"":{""data"":" & json & "}}"
                Return Content(json, jsonContent)
            Catch ex As Exception
                Return Content("[]" + ex.Message, jsonContent)
            End Try
        End Function
        Function GetFuelData() As ActionResult
            Dim tSqlw As String = " WHERE f.DocNo<>'' "
            If Not IsNothing(Request.QueryString("Branch")) Then
                tSqlw &= String.Format("AND f.BranchCode ='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("Code")) Then
                tSqlw &= String.Format("AND f.DocNo ='{0}' ", Request.QueryString("Code").ToString)
            End If
            If Not IsNothing(Request.QueryString("Job")) Then
                tSqlw &= String.Format("AND f.JNo ='{0}' ", Request.QueryString("Job").ToString)
            End If
            If Not IsNothing(Request.QueryString("Station")) Then
                tSqlw &= String.Format("AND f.StationCode ='{0}' ", Request.QueryString("Station").ToString)
            End If
            If Not IsNothing(Request.QueryString("Booking")) Then
                tSqlw &= String.Format("AND f.BookingNo ='{0}' ", Request.QueryString("Booking").ToString)
            End If
            If Not IsNothing(Request.QueryString("Item")) Then
                tSqlw &= String.Format("AND f.BookingItemNo ={0} ", Request.QueryString("Item").ToString)
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                tSqlw &= "AND f.DocDate>='" & Request.QueryString("DateFrom") & " 00:00:00' "
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                tSqlw &= "AND f.DocDate<='" & Request.QueryString("DateTo") & " 23:59:00' "
            End If
            Dim sql = GetValueConfig("SQL", "SelectFuelData")
            If sql = "" Then
                sql = "
SELECT f.*,e.Tel,e.Email,e.Remark as EmpRemark,c.CarBrand,c.CarType,c.CarModel 
FROM Job_AddFuel f
left join Mas_Employee e
on f.EmpCode=e.EmpCode
left join Mas_CarLicense c
on f.CarNo=c.CarNo
"
            End If
            Dim oDataD = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql & tSqlw)
            Dim jsonD As String = JsonConvert.SerializeObject(oDataD)
            Dim json = "{""data"":" & jsonD & "}"
            Return Content(json, jsonContent)
        End Function
        Function Summary() As ActionResult
            Main.DBExecute(GetSession("ConnJob"), SQLUpdateJobStatus(""))
            Dim cfgStatus = Main.GetDataConfig("JOB_STATUS")
            ViewBag.DataStatus = cfgStatus
            Dim fldStatus = ""
            For Each status In cfgStatus
                fldStatus &= String.Format(",SUM(CASE WHEN j.JobStatus={0} THEN 1 ELSE 0 END) as '{1}'", status.ConfigKey, status.ConfigValue)
            Next
            Dim sql = "
SELECT c.CustCode,c.NameThai,c.NameEng,COUNT(*) as TotalJob,
MAX(j.DutyDate) as LastWorkDate,MAX(j.JNo) as LastJobNo
" & fldStatus & "
FROM Job_Order j INNER JOIN Mas_Company c ON
j.CustCode=c.CustCode
GROUP BY c.CustCode,c.NameThai,c.NameEng
"
            ViewBag.DataCount1 = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
            Return GetView("Summary", "MODULE_CS")
        End Function
    End Class

End Namespace