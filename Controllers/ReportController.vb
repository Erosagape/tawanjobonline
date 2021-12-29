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
        <Mvc.HttpPost>
        Function Import(fileUpload As HttpPostedFileBase) As ActionResult
            Try
                If fileUpload.ContentLength > 0 Then
                    If Not System.IO.Directory.Exists(Server.MapPath("~/Resource/Import")) Then
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Resource/Import"))
                    End If
                    Dim savePath As String = System.IO.Path.Combine(Server.MapPath("~/Resource/Import"), System.IO.Path.GetFileName(fileUpload.FileName))
                    If System.IO.File.Exists(savePath) Then
                        System.IO.File.Delete(savePath)
                    End If
                    fileUpload.SaveAs(savePath)
                    Dim dt = New CUtil(GetSession("ConnJob")).ReadExcelFromFile(savePath)
                    Dim data = dt.Clone()
                    Dim tbName = "Job_Order"
                    Dim rowUpdate As Long = 0
                    Dim msgUpdate As String = ""
                    Using cn = New SqlClient.SqlConnection(GetSession("ConnJob"))
                        cn.Open()
                        For Each dr As DataRow In dt.Rows
                            Try
                                Dim sql As String = "SELECT * FROM Job_Order WHERE BranchCode='{0}' AND JNo='{1}'"
                                Using da As New SqlClient.SqlDataAdapter(String.Format(sql, GetSession("CurrBranch"), dr("JNo").ToString), cn)
                                    Dim cb As New SqlClient.SqlCommandBuilder(da)
                                    Dim tb As New DataTable
                                    da.Fill(tb)
                                    If tb.Rows.Count > 0 Then
                                        Dim r = tb.Rows(0)
                                        For Each dc As DataColumn In dt.Columns
                                            If tb.Columns.IndexOf(dc.ColumnName) >= 0 Then
                                                Try
                                                    r(dc.ColumnName) = dr(dc.ColumnName)
                                                Catch ex As Exception

                                                End Try
                                            End If
                                        Next
                                        da.Update(tb)
                                        data.ImportRow(r)
                                        rowUpdate += 1
                                    Else
                                        msgUpdate &= vbCrLf & "[ERROR(" & dr("JNo").ToString & ")] Job Not Found"
                                    End If
                                End Using
                            Catch ex As Exception
                                msgUpdate &= vbCrLf & "[ERROR(" & dr("JNo").ToString & ")]" & ex.Message
                            End Try
                        Next
                        cn.Close()
                    End Using
                    ViewBag.Data = data
                    ViewBag.Message = "Upload " & fileUpload.FileName & " Complete (" & rowUpdate & " Updated)" & vbCrLf & msgUpdate
                Else
                    ViewBag.Message = "You must select some file"
                End If
            Catch ex As Exception
                ViewBag.Message = ex.Message
            End Try
            Return GetView("Import", "MODULE_REP")
        End Function
        Function ImportFile() As ActionResult
            Return GetView("ImportFile")
        End Function
        Function Export() As ActionResult
            Return GetView("Export", "MODULE_REP")
        End Function
        <Mvc.HttpPost>
        <Mvc.ActionName("Export")>
        Function Export_Post() As ActionResult
            Dim dateFrom = Request.Form("dateFrom")
            Dim dateTo = Request.Form("dateTo")
            Dim sqlW = " WHERE JobStatus<>99 "
            sqlW &= " AND DocDate>='" & dateFrom & "'"
            sqlW &= " AND DocDate<='" & dateTo & "'"
            Dim oTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT * FROM Job_Order" & sqlW)
            Dim sb As StringBuilder = New StringBuilder()
            sb.Append("<table>")
            'Export Column Header
            sb.Append("<tr>")
            Dim c As Integer = 0
            For Each col As DataColumn In oTable.Columns
                sb.Append("<td>" + col.ColumnName + "</td>")
                c += 1
            Next
            sb.Append("</tr>")
            'Export Row Data
            For Each row As DataRow In oTable.Rows
                sb.Append("<tr>")
                For i As Integer = 1 To c
                    Try
                        Dim val = row(i - 1).ToString()
                        If val.Substring(0, 1) = "0" Then
                            sb.Append("<td>" + val + "</td>")
                        Else
                            sb.Append("<td>" + val + "</td>")
                        End If
                    Catch ex As Exception
                        sb.Append("<td></td>")
                    End Try
                Next
                sb.Append("</tr>")
            Next
            sb.Append("</table>")

            Response.Clear()
            Response.ClearContent()
            Response.ClearHeaders()
            Response.Charset = "UTF-8"
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment; filename=Job_Order.xls")
            Response.Write(sb.ToString())
            Response.End()
            Return GetView("Export", "MODULE_REP")
        End Function
        Function Preview() As ActionResult
            If Request.QueryString("Layout") IsNot Nothing Then
                ViewBag.Layout = Request.QueryString("Layout").ToString()
            Else
                ViewBag.Layout = ""
            End If
            Return GetView("Preview" & ViewBag.Layout)
        End Function
        Function GetReportByConfig(<FromBody()> data As CReport) As ActionResult
            Dim sqlW As String = ""
            Dim groupDatas = ""
            Dim cliteria As String = data.ReportCliteria
            Try
                Dim fldWhere = (GetValueConfig("REPORT_" & data.ReportCode, "MAIN_CLITERIA") & ",,,,,,,,").Split(",")
                sqlW = GetSQLCommand(cliteria, fldWhere(1), fldWhere(2), fldWhere(3), fldWhere(4), fldWhere(5), fldWhere(6), fldWhere(7), fldWhere(8), fldWhere(9))
                If sqlW <> "" Then
                    sqlW = fldWhere(0) & " " & sqlW
                End If
                Dim sqlM As String = GetValueConfig("REPORT_" & data.ReportCode, "MAIN_SQL")
                Dim fldGroup As String = GetValueConfig("REPORT_" & data.ReportCode, "GROUP_FIELD")
                Dim fldLength As String = GetValueConfig("REPORT_" & data.ReportCode, "COLUMN_LENGTH")
                Dim fldSum = GetValueConfig("REPORT_" & data.ReportCode, "COLUMN_SUM")
                Dim fldNoSum = GetValueConfig("REPORT_" & data.ReportCode, "COLUMN_NOSUM")
                Dim dsGroup = GetValueConfig("REPORT_" & data.ReportCode, "GROUP_DATASOURCE")
                If dsGroup <> "" Then
                    groupDatas = JsonConvert.SerializeObject(Main.GetDataConfig("GROUP_DATASOURCE"))
                End If
                sqlM = String.Format(sqlM, sqlW)
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlM, True)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content("{""result"":" & json & ",""group"":""" & fldGroup & """,""groupdata"":[" & groupDatas & "],""colwidth"":""" & fldLength & """,""summary"":""" & fldSum & """,""text_field"":""" & fldNoSum & """,""msg"":""OK"",""sql"":""" & sqlW & """}")
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetReportByConfig", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""group"":null,""msg"":""" & ex.Message & """,""sql"":""" & sqlW & """}")
            End Try
        End Function
        Function GetReportGroup() As ActionResult
            Dim oList = Main.GetDataConfig("REPORT_GROUP")
            Dim data = New List(Of CReportGroup)
            For Each row In oList
                data.Add(New CReportGroup() With {
                    .ConfigKey = row.ConfigKey,
                    .ConfigValue = row.ConfigValue
                         })
            Next
            Dim json As String = JsonConvert.SerializeObject(data)
            Return Content(json, jsonContent)
        End Function
        Function GetReportList() As ActionResult
            Dim groupCode = If(IsNothing(Request.QueryString("Group")), "", Request.QueryString("Group").ToString)
            Dim sql = "
select REPLACE(s.ConfigCode,'REPORT_','') as ReportCode, 
s.ConfigValue as ReportNameTH,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='ReportNameEN') as ReportNameEN,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='ReportGroup') as ReportGroup,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='ReportType') as ReportType,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='ReportAuthor') as ReportAuthor,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='MAIN_SQL') as ReportSQL,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='ReportUrl') as ReportUrl,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='MAIN_CLITERIA') as ReportCliteria,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='GROUP_FIELD') as ReportGroupFields,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='GROUP_DATASOURCE') as ReportGroupSource,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='COLUMN_SUM') as ReportColSum,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='COLUMN_NOSUM') as ReportColNoSum,
(SELECT ConfigValue FROM Mas_Config WHERE ConfigCode=s.ConfigCode AND ConfigKey='COLUMN_LENGTH') as ReportCollength
from Mas_Config s where s.ConfigCode like 'REPORT_%' AND s.ConfigKey='ReportNameTH'
"
            If groupCode <> "" Then
                sql &= String.Format(" and s.ConfigCode in(select ConfigCode from Mas_Config WHERE ConfigKey='ReportGroup' AND ConfigValue='{0}')", groupCode)
            End If
            Dim ds = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
            If ds.Rows.Count > 0 Then
                Dim json As String = JsonConvert.SerializeObject(ds)
                Return Content(json, jsonContent)
            Else
                Return Content("{}", jsonContent)
            End If
        End Function
        Function GetReport(<FromBody()> data As CReport) As ActionResult
            Dim sqlM As String = ""
            Dim sqlW As String = ""
            Dim fldGroup = ""
            Dim groupDatas = ""
            Dim cliteria As String = data.ReportCliteria
            Try
                Dim fldLength As String = GetValueConfig("REPORT_" & data.ReportCode, "COLUMN_LENGTH")
                Dim fldSum As String = GetValueConfig("REPORT_" & data.ReportCode, "COLUMN_SUM")
                Dim fldNoSum As String = GetValueConfig("REPORT_" & data.ReportCode, "COLUMN_NOSUM")
                Select Case data.ReportCode
                    Case "JOBDAILY"
                        fldGroup = "LoadDate"
                        sqlW = GetSQLCommand(cliteria, "j.DutyDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.DeclareNumber,j.VesselName,j.LoadDate,j.DutyDate,j.ShippingEmp,j.HAWB,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j ORDER BY j.LoadDate DESC"
                    Case "JOBFOLLOWUP"
                        fldGroup = "JobStatus"
                        groupDatas = JsonConvert.SerializeObject(Main.GetDataConfig("JOB_STATUS"))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.DeclareNumber,j.HAWB,j.ConfirmDate,j.ImExDate,j.CloseJobDate,j.JobStatus,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.Consigneecode,j.InvProduct,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j ORDER BY j.JobStatus,j.JNo DESC"
                    Case "JOBCS"
                        fldGroup = "CSCode"
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CSCode,j.InvNo,j.DeclareTypeName,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.CSCode DESC"
                    Case "JOBSHP"
                        fldGroup = "ShippingEmp"
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.VesselName,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.ShippingCmd FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ShippingEmp DESC"
                    Case "JOBTYPE"
                        fldGroup = "JobTypeName"
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.ShippingEmp", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.VesselName,j.DeliveryNo FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.JobType,j.CustCode,j.ShipBy,j.DocDate DESC"
                    Case "JOBSHIPBY"
                        fldGroup = "ShipByName"
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.ShippingEmp", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.JobTypeName,j.ShipByName,j.DutyDate,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer,j.DeclareTypeName FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ShipBy,j.CustCode,j.JobType,j.DocDate DESC"
                    Case "JOBCUST"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.HAWB,j.DeclareNumber,j.LoadDate,j.DutyDate,j.CustCode,j.ShippingEmp,j.InvProductQty,j.TotalGW,j.TotalContainer FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.CustCode,j.DutyDate DESC"
                    Case "JOBPORT"
                        fldGroup = "ClearPort"
                        groupDatas = JsonConvert.SerializeObject(New CCustomsPort(GetSession("ConnMas")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "j.LoadDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT j.InvProduct,j.LoadDate,j.CustCode,j.DeclareNumber,j.HAWB,j.InvNo,j.InvProductQty,j.InvProductUnit,j.ClearPort,j.TotalContainer,j.TotalGW,j.ETDDate,j.ETADate,j.ShippingEmp FROM (" & SQLSelectJobReport() & sqlW & ") j  ORDER BY j.ClearPort,j.LoadDate DESC,j.CustCode,j.InvNo"
                    Case "JOBADV"
                        fldGroup = "ReqBy"
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "c.PaymentDate", "c.CustCode", "a.ForJNo", "c.ReqBy", "a.VenCode", "c.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT t.PaymentDate,t.AdvNo,t.JobNo,t.ReqBy,t.SDescription,t.PaymentRef,t.DocStatus,t.AdvNet,t.UsedAmount,t.AdvBalance FROM (" & SQLSelectAdvForClear() & sqlW & ") t ORDER BY t.ReqBy,t.PaymentDate,t.AdvNo"
                    Case "JOBVOLUME"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT c.NameThai,j.* FROM (" & SQLSelectJobCount(sqlW, "j.CustCode") & ") j INNER JOIN Mas_Company c ON j.CustCode=c.CustCode ORDER BY c.NameThai"
                    Case "JOBSTATUS"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.ManagerCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT c.TName,j.* FROM (" & SQLSelectJobCount(sqlW, "j.CSCode") & ") j INNER JOIN Mas_User c ON j.CSCode=c.UserID ORDER BY c.TName"
                    Case "JOBSALES"
                        fldGroup = "TName"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.ManagerCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT c.TName,j.* FROM (" & SQLSelectJobCount(sqlW, "j.ManagerCode") & ") j INNER JOIN Mas_User c ON j.ManagerCode=c.UserID ORDER BY c.TName"
                    Case "JOBCOMM"
                        sqlW = GetSQLCommand(cliteria, "dbo.Job_ReceiptHeader.ReceiptDate", "dbo.Job_Order.CustCode", "dbo.Job_Order.JNo", "dbo.Job_Order.ManagerCode", "dbo.Job_Order.AgentCode", "dbo.Job_Order.JobStatus", "dbo.Job_Order.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT j.JNo,j.InvNo,j.ManagerCode,j.CustCode,j.CSCode,j.ReceiptNo,j.SumReceipt,j.TotalComm FROM (" & SQLSelectSumReceipt(sqlW) & ") j ORDER BY j.JNo,j.ReceiptNo"
                    Case "ADVDAILY"
                        fldGroup = "AdvDate"
                        sqlW = GetSQLCommand(cliteria, "a.AdvDate", "a.CustCode", "d.ForJNo", "a.ReqBy", "d.VenCode", "a.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT ad.AdvNo,ad.AdvDate,ad.PaymentDate,ad.PaymentRef,ad.EmpCode as ReqBy,ad.SDescription,ad.CustCode,ad.ForJNo,ad.AdvPayAmount,ad.Charge50Tavi FROM (" & SQLSelectAdvDetail() & sqlW & ") ad  ORDER BY ad.AdvDate,ad.AdvNo"
                    Case "ADVDETAIL"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "a.AdvDate", "a.CustCode", "d.ForJNo", "a.ReqBy", "d.VenCode", "a.DocStatus", "a.BranchCode", "d.SICode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT ad.AdvNo,ad.PaymentDate,ad.PaymentRef,ad.EmpCode as ReqBy,ad.SDescription,ad.CustCode,ad.ForJNo,ad.AdvPayAmount,ad.Charge50Tavi FROM (" & SQLSelectAdvDetail() & sqlW & ") ad  ORDER BY ad.SDescription,ad.AdvNo"
                    Case "EXPDAILY"
                        fldGroup = "DocDate"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "", "d.ForJNo", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT pa.DocNo,pa.DocDate,pa.VenCode,pa.RefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total,pa.PayType FROM (" & SQLSelectPaymentReport() & sqlW & ") pa ORDER BY pa.DocDate,pa.DocNo"
                    Case "EXPDETAIL"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "", "d.ForJNo", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT pa.DocNo,pa.DocDate,pa.VenCode,pa.RefNo,pa.SDescription,pa.Amt,pa.AmtVAT,pa.AmtWHT as Amt50Tavi,pa.Total,pa.PayType FROM (" & SQLSelectPaymentReport() & sqlW & ") pa ORDER BY pa.SDescription,pa.DocDate,pa.DocNo"
                    Case "TAXDETAIL"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode", "rd.SICode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT>0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT>0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net as AmtNet,rc.PRVoucher FROM (" & SQLSelectReceiptReport() & sqlW & ") rc ORDER BY rc.SDescription,rc.ReceiptNo"
                    Case "RCPDAILY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT=0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT=0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,SUM(rc.Net) as AmtNet FROM (" & SQLSelectReceiptReport() & sqlW & ") rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "RCPDETAIL"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode", "rd.SICode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT=0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT=0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,rc.ClrNo,rc.AdvNo,rc.SDescription,rc.Net as AmtNet,rc.PRVoucher FROM (" & SQLSelectReceiptReport() & sqlW & ") rc ORDER BY rc.SDescription,rc.ReceiptNo"
                    Case "RCPSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT=0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT=0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo,SUM(rc.Amt) as Amt,SUM(rc.Amt50Tavi) as Amt50Tavi,SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'')='' THEN 0 ELSE rc.Net END) as TotalReceived FROM (" & SQLSelectReceiptReport() & sqlW & ") rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.InvoiceNo,rc.JobNo ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "TAXDAILY"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT>0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT>0 "
                        sqlM = "SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,SUM(rc.Net) as AmtNet FROM (" & SQLSelectReceiptReport() & sqlW & ") rc GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode ORDER BY rc.ReceiptDate,rc.ReceiptNo"
                    Case "TAXSUMMARY"
                        fldGroup = "NameThai"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "ih.RefNo", "rh.EmpCode", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE rh.TotalVAT>0 AND " & sqlW Else sqlW = " WHERE rh.TotalVAT>0 "
                        sqlM = "
SELECT rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName as NameThai,rc.InvoiceNo,rc.JobNo,SUM(rc.Amt) as Amt,SUM(rc.AmtVAT) as AmtVAT,SUM(rc.Amt50Tavi) as Amt50Tavi,SUM(rc.Net) as AmtNet,SUM(CASE WHEN ISNULL(rc.PRVoucher,'')='' THEN 0 ELSE rc.Net END) as TotalReceived 
FROM (" & SQLSelectReceiptReport() & sqlW & ") rc 
GROUP BY rc.ReceiptNo,rc.ReceiptDate,rc.CustCode,rc.CustTName,rc.InvoiceNo,rc.JobNo 
ORDER BY rc.CustTName,rc.ReceiptDate,rc.ReceiptNo"
                    Case "CASHDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "r.CmpCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE (d.ChqAmount >0 OR d.CashAmount>0) AND d.acType<>'CU' AND " & sqlW Else sqlW = " WHERE (d.ChqAmount >0 OR d.CashAmount>0) AND d.acType<>'CU' "
                        sqlM = "SELECT vc.PRVoucher,vc.VoucherDate,vc.BookCode,vc.acType,vc.ChqNo,vc.ChqDate,vc.RecvBank,(CASE WHEN vc.PRType='P' THEN -1 ELSE 1 END)*(vc.CashAmount+vc.ChqAmount) as Total,vc.DRefNo FROM (" & SQLSelectVoucher() & sqlW & ") vc ORDER BY vc.VoucherDate,vc.PRVoucher"
                        fldGroup = "VoucherDate"
                    Case "CLRDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.ClrDate", "j.CustCode", "j.JNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE h.DocStatus<>99 AND " & sqlW Else sqlW = " WHERE h.DocStatus<>99 "
                        sqlM = "SELECT cl.ClrNo,cl.ClrDate,cl.SDescription,cl.AdvNO,cl.JobNo,cl.AdvAmount as AdvNet,cl.ClrNet,cl.Tax50Tavi,cl.SlipNo,cl.LinkBillNo as InvoiceNo FROM (" & SQLSelectClrDetail() & sqlW & ") cl ORDER BY cl.ClrDate,cl.ClrNo"
                    Case "CLRSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "h.ClrDate", "j.CustCode", "j.JNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE h.DocStatus<>99 AND " & sqlW Else sqlW = " WHERE h.DocStatus<>99 "
                        sqlM = "SELECT cl.ClrNo,cl.ClrDate,cl.JobNo,SUM(cl.UsedAmount) as UsedAmount,SUM(cl.ChargeVAT) as AmtVat,SUM(cl.Tax50Tavi) as Tax50Tavi,"
                        sqlM &= "SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=1 THEN cl.ClrNet ELSE 0 END) as SumAdvance,SUM(CASE WHEN cl.IsExpense=1 THEN cl.ClrNet ELSE 0 END) as SumCost,SUM(CASE WHEN cl.IsExpense=0 AND cl.IsCredit=0 THEN cl.ClrNet ELSE 0 END) as SumCharge,cl.LinkBillNo as InvoiceNo FROM (" & SQLSelectClrDetail() & sqlW & ") cl "
                        sqlM &= "WHERE cl.ClrNet > 0 GROUP BY cl.ClrNo,cl.ClrDate,cl.JobNo,cl.LinkBillNo ORDER BY cl.ClrDate,cl.ClrNo"
                    Case "INVDAILY"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "ih.RefNo", "ih.EmpCode", "", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT inv.DocNo,inv.DocDate,inv.SDescription,inv.Amt,inv.AmtVat,inv.AmtCredit,inv.Amt50Tavi,inv.TotalInv,inv.CreditNet,inv.ReceivedNet,inv.ReceiptNo,inv.LastVoucher FROM (" & SQLSelectInvReport(sqlW) & ") inv ORDER BY inv.DocDate,inv.DocNo"
                    Case "INVDETAIL"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "ih.RefNo", "ih.EmpCode", "", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode", "id.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.SDescription,inv.AmtAdvance,inv.AmtCharge as TotalCharge,inv.AmtCredit,inv.AmtVat,inv.Amt50Tavi,inv.TotalInv,inv.ReceivedNet,inv.ReceiptNo,inv.LastVoucher FROM (" & SQLSelectInvReport(sqlW) & ") inv ORDER BY inv.SDescription,inv.DocNo"
                    Case "INVSTATUS"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "ih.RefNo", "ih.EmpCode", "", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT inv.DocNo,inv.DocDate,inv.RefNo,inv.CustCode,
sum(inv.AmtAdvance) as TotalAdvance,sum(inv.AmtCharge) as TotalCharge,sum(inv.AmtVat) as TotalVAT,sum(inv.Amt50Tavi) as Total50Tavi,
sum(inv.AmtCredit) as TotalPrepaid,sum(inv.TotalInv) as TotalInv,sum(ISNULL(inv.CreditNet,0)) as TotalCredit,
sum(inv.ReceivedNet) as TotalReceived,max(inv.LastVoucher) as VoucherNo 
FROM (" & SQLSelectInvReport(sqlW) & ") inv 
GROUP BY inv.DocNo,inv.DocDate,inv.RefNo,inv.CustCode
ORDER BY inv.DocNo
"
                    Case "BILLDAILY"
                        sqlW = GetSQLCommand(cliteria, "h.BillDate", "h.CustCode", "", "h.EmpCode", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT bl.BillAcceptNo,bl.BillDate,bl.CustCode,bl.InvNo,bl.AmtAdvance,bl.AmtChargeNonVAT,bl.AmtChargeVAT,bl.AmtVAT,bl.AmtWH,bl.AmtTotal FROM (" & SQLSelectBillReport() & sqlW & ") bl ORDER BY bl.BillDate,bl.BillAcceptNo"
                    Case "JOBCOST"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.ForwarderCode", "j.JobStatus", "j.BranchCode")
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
WHERE (cd.BNet>0) AND       (ch.DocStatus <> 99) AND (j.JobStatus < 90) {0}
GROUP BY j.BranchCode, j.JNo, j.CustCode, j.CustBranch, j.InvNo, j.DutyDate, j.DeclareNumber,j.CSCode,j.ManagerCode
) as t ORDER BY CustCode,DutyDate,InvNo"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "BOOKBAL"
                        sqlW = GetSQLCommand(cliteria, "b.VoucherDate", "", "", "b.RecUser", "", "", "b.BranchCode")
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
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT a.DocDate,a.DocNo,a.TName1 as TaxBy,a.TName3 as TaxFor,a.FormTypeName,a.TaxLawName,a.PayTaxDesc,a.PayRate,a.PayAmount,a.PayTax FROM (" & String.Format(SQLSelectWHTax() & " WHERE NOT ISNULL(h.CancelProve,'')<>'' " & sqlW) & ") a order by a.DocDate,a.DocNo"
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
                        fldGroup = "acType"
                        Dim oDic = New Dictionary(Of String, String) From {
                            {"CA", "Cash/Transfer"},
                            {"CH", "Cashier Cheque"},
                            {"CU", "Customer Cheque"},
                            {"CR", "Credit"}
                        }
                        groupDatas = JsonConvert.SerializeObject(oDic)
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT acType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t WHERE PRType='P' ORDER BY acType,PRVoucher"
                    Case "ACCINC"
                        fldGroup = "acType"
                        Dim oDic = New Dictionary(Of String, String) From {
                            {"CA", "Cash/Transfer"},
                            {"CH", "Cashier Cheque"},
                            {"CU", "Customer Cheque"},
                            {"CR", "Credit"}
                        }
                        groupDatas = JsonConvert.SerializeObject(oDic)
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT acType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t WHERE PRType='R' ORDER BY acType,PRVoucher"
                    Case "CASHFLOW"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlW &= " AND d.acType<>'CU' "
                        sqlM = "SELECT PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t ORDER BY PRType DESC,PRVoucher"
                        fldGroup = "PRType"
                        Dim oDic = New Dictionary(Of String, String) From {
                            {"R", "Cash-Received"},
                            {"P", "Cash-Paymented"}
                        }
                        groupDatas = JsonConvert.SerializeObject(oDic)
                    Case "CASHBAL"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT acType,PRType,PRVoucher,VoucherDate,TRemark,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t ORDER BY acType,VoucherDate,PRVoucher"
                        fldGroup = "acType"
                        Dim oDic = New Dictionary(Of String, String) From {
                            {"CA", "Cash/Transfer"},
                            {"CH", "Cashier Cheque"},
                            {"CU", "Customer Cheque"},
                            {"CR", "Credit"}
                        }
                        groupDatas = JsonConvert.SerializeObject(oDic)
                    Case "STATEMENT"
                        fldGroup = "BookCode"
                        sqlW = GetSQLCommand(cliteria, "h.VoucherDate", "h.CustCode", "d.ForJNo", "h.RecUser", "", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT BookCode,VoucherDate,TRemark,PRVoucher,ChqNo,ChqDate,(CASE WHEN PRType='P' THEN TotalNet*-1 ELSE TotalNet END) as TotalNet,ControlNo FROM (" & String.Format(SQLSelectCashFlow(), sqlW) & ") as t ORDER BY BookCode,VoucherDate,PRVoucher "
                    Case "ARBAL"
                        fldGroup = "CustCode"
                        groupDatas = JsonConvert.SerializeObject(New CCompany(GetSession("ConnJob")).GetData(""))
                        sqlW = GetSQLCommand(cliteria, "DueDate", "CustCode", "RefNo", "EmpCode", "", "", "BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "
SELECT CustCode,DocNo,DocDate,DueDate,RefNo,
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
SUM((CASE WHEN ISNULL(rd.VoucherNo,'')<>'' THEN rd.Net ELSE 0 END)) AS RecvNet,
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
) t {0} GROUP BY CustCode,DocNo,DocDate,DueDate,RefNo
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
e.ReceiveRef,e.PaidAmount as ReceiveAmt
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
SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'')='' AND dt.DocType='CLR'
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+'#'+Convert(varchar,b.ItemNo))=e.DocNo
WHERE a.DocStatus>2 AND a.AdvType=5 {0}
GROUP BY
a.AdvNo,a.CustCode,a.PaymentDate,a.EmpCode,e.ReceiveRef,e.PaidAmount
ORDER BY a.EmpCode,a.PaymentDate,a.AdvNo
"
                        sqlM = String.Format(sqlM, sqlW)
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                    Case "ADVSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "a.PaymentDate", "a.CustCode", "b.ForJNo", "a.EmpCode", "", "a.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select a.AdvNo,a.EmpCode,c.CustCode,c.NameThai as CustName,b.ForJNo as JobNo,
j.DutyDate as InspectionDate,a.PaymentDate,
SUM(b.AdvNet) as AdvTotal,SUM(ISNULL(d.ClrNet,0)) as ClrTotal,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))>=SUM(b.AdvNet) THEN SUM(ISNULL(d.ClrNet,0))-SUM(b.AdvNet) ELSE 0 END) as TotalPayback,
(CASE WHEN SUM(ISNULL(d.ClrNet,0))<SUM(b.AdvNet) THEN SUM(b.AdvNet)-SUM(ISNULL(d.ClrNet,0)) ELSE 0 END) as TotalReturn,
e.ReceiveRef,e.PaidAmount as ReceiveAmt,st.AdvStatusName
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
	SELECT dt.BranchCode,Max(dt.ControlNo) as ReceiveRef,dt.DocNo,SUM(dt.PaidAmount) as PaidAmount
	FROM Job_CashControlDoc dt INNER JOIN Job_CashControl hd
	ON dt.BranchCode=hd.BranchCode AND dt.ControlNo=hd.ControlNo
	WHERE ISNULL(hd.CancelProve,'')='' AND dt.DocType='CLR'
	GROUP BY dt.BranchCode,dt.DocNo
) e ON b.BranchCode=e.BranchCode AND (b.AdvNo+'#'+Convert(varchar,b.ItemNo))=e.DocNo
inner join Job_Order j ON b.BranchCode=j.BranchCode AND b.ForJNo=j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as AdvStatus, ConfigValue as AdvStatusName FROM Mas_Config WHERE ConfigCode='ADV_STATUS'
) st ON a.DocStatus=st.AdvStatus
WHERE a.DocStatus>2 {0}
GROUP BY a.AdvNo,a.EmpCode,c.CustCode,c.NameThai,b.ForJNo,
j.DutyDate,a.PaymentDate,e.ReceiveRef,e.PaidAmount,st.AdvStatusName
"
                        sqlM = String.Format(sqlM, sqlW)
                        groupDatas = JsonConvert.SerializeObject(New CUser(GetSession("ConnJob")).GetData(""))
                    Case "CLRDETAIL"
                        fldGroup = "SDescription"
                        sqlW = GetSQLCommand(cliteria, "b.ClrDate", "c.CustCode", "c.JNo", "c.EmpCode", "a.VenderCode", "b.ClrStatus", "b.BranchCode", "a.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.JNo,a.AdvNo,b.ClrNo,b.ClrDate,c.CustCode,d.NameThai as SDescription,a.VenderCode,a.Date50Tavi as SlipDate,a.UsedAmount,
a.BPrice as SumCost,a.ChargeVAT as AmtVat,a.Tax50Tavi as Amt50Tavi,(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN a.BNet ELSE 0 END) as TotalInv,
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 0 ELSE a.BNet END) as Balance,a.LinkBillNo
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	where ISNULL(b.CancelProve,'')='' {0}
    order by a.SICode
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBTRANSPORT"
                        sqlW = GetSQLCommand(cliteria, "c.LoadDate", "c.NotifyCode", "a.JNo", "", "c.VenderCode", "", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " And " & sqlW
                        sqlM = "SELECT t.LoadDate,t.NotifyCode,t.VenderCode,t.JNo,t.BookingNo,t.CTN_NO,t.CTN_SIZE,t.TruckNO,t.TruckType,t.Location,
(CASE WHEN t.CauseCode<>'' THEN (case when t.CauseCode='99' THEN 'Cancel' ELSE (CASE WHEN t.CauseCode='3' THEN 'Finish' ELSE 'Working' END) END) ELSE 'Request' END) as JobStatus,
t.CountBill,t.CountClear
FROM (
SELECT a.*,ISNULL(b.CountBill,0) as CountBill,ISNULL(b.CountClear,0) as CountClear, 
ISNULL(b.CountBill,0)-ISNULL(b.CountClear,0) as CountBalance,c.LoadDate,c.NotifyCode,c.VenderCode
FROM Job_LoadInfoDetail a LEFT JOIN(
    SELECT h.BranchCode,d.BookingRefNo,d.BookingItemNo,COUNT(*) as CountBill,
    SUM(CASE WHEN ISNULL(d.ClrReFNo,'')<>'' THEN 1 ELSE 0 END) as CountClear
    FROM Job_PaymentDetail d INNER JOIN Job_PaymentHeader h 
    ON d.BranchCode=h.BranchCode AND d.DocNo=h.DocNo
    WHERE ISNULL(h.CancelProve,'')='' GROUP BY h.BranchCode,d.BookingRefNo,d.BookingItemNo
) b ON a.BranchCode=b.BranchCode AND a.BookingNo=b.BookingRefNo AND a.ItemNo=b.BookingItemNo
 INNER JOIN Job_LoadInfo c ON a.BranchCode=c.BranchCode AND a.BookingNo=c.BookingNo
WHERE c.LoadDate IS NOT NULL {0} ) t ORDER BY t.VenderCode,t.LoadDate"
                        sqlM = String.Format(sqlM, sqlW)

                    Case "CUSTSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "c.DocDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " And " & sqlW
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
where ISNULL(b.CancelProve,'')='' AND a.BNet>0 {0}
) clr
GROUP BY CustCode,CustName
ORDER BY CustName
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CUSTPROFIT"
                        sqlW = GetSQLCommand(cliteria, "c.DocDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " And " & sqlW
                        sqlM = "
SELECT CustCode,CustName,TAddress,COUNT(DISTINCT JNo) as CountJob,
SUM(CostCleared) as TotalCost,SUM(Deposit) as TotalEarnest,
SUM(AdvBilled) as TotalAdv,SUM(ChargeBilled) as TotalCharge,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit
FROM (
select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
c.CustCode,c.CustBranch,e.Title+' '+e.NameThai as CustName,e.TAddress,e.EAddress1+''+e.EAddress2 as EAddress,
a.SICode,a.SDescription,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=1 AND NOT ISNULL(a.LinkBillNo,'')='' THEN a.UsedAmount ELSE 0 END) as AdvBilled,
(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 AND NOT ISNULL(a.LinkBillNo,'')='' THEN a.UsedAmount ELSE 0 END) as ChargeBilled,
(CASE WHEN d.GroupCode='ERN' THEN a.UsedAmount ELSE 0 END) as Deposit,
(CASE WHEN d.IsCredit=1 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as AdvCleared,
(CASE WHEN d.IsCredit=0 AND d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ChargeCleared
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
where ISNULL(b.CancelProve,'')='' AND a.BNet>0 {0}
) clr
GROUP BY CustCode,CustName,TAddress
ORDER BY CustCode
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBSUMMARY"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "c.DocDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT JNo,DeclareNumber,InvNo,DutyDate,CloseJobDate,CustCode,
SUM(AdvCleared) as TotalAdv,
SUM(ChargeCleared) as TotalCharge,
SUM(AdvBilled) as TotalAdvBilled,
SUM(ChargeBilled) as TotalChargeBilled,
SUM(CostCleared) as TotalCost,
SUM(DepositAmt) as TotalEarnest,
SUM(ChargeCleared)-SUM(CostCleared) as TotalProfit,
SUM(AdvWaitBill) as TotalAdvWaitBill,
SUM(ChargeWaitBill) as TotalChargeWaitBill
FROM (
	select c.BranchCode,c.JNo,c.DeclareNumber,c.InvNo,c.DocDate as JobDate,c.DutyDate,c.CloseJobDate,
	b.ClrNo,b.ClrDate,b.ClearType,b.DocStatus,a.AdvNo,a.AdvItemNo,c.CustCode,c.CustBranch,
	e.Title+' '+e.NameThai as CustName,a.SICode,a.SDescription,a.SlipNo,a.Date50Tavi as SlipDate,
	a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END) as ExpenseCleared,
	(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as CostCleared,
    (CASE WHEN d.GroupCode='ERN' THEN a.UsedAmount ELSE 0 END) as DepositAmt,
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
	where ISNULL(b.CancelProve,'')='' AND a.BNet>0 {0}
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
SUM(CASE WHEN IsCredit=1 THEN BNet ELSE 0 END) as TotalAdvance,
SUM(CASE WHEN IsCredit=0 THEN BNet ELSE 0 END) as TotalCharge,
SUM(CASE WHEN IsCredit=0 THEN ChargeVAT ELSE 0 END) as TotalVat,
SUM(CASE WHEN IsCredit=0 THEN Tax50Tavi ELSE 0 END) as Total50Tavi,
SUM(ReceiptNet+AmtCredit) as TotalReceived,
SUM(Balance) as TotalBalance,
SUM(ReceiptNet+AmtCredit)- SUM(CASE WHEN IsCredit=1 THEN BNet ELSE 0 END)-ISNULL(AmtCost,0) as TotalProfit
FROM (
	select f.BranchCode,f.DocNo,f.DocDate as InvDate, f.CustCode,f.CustBranch,c.JNo,c.DocDate as JobDate ,b.ClrNo,b.ClrDate,c.DeclareNumber,c.InvNo,
	c.DutyDate,c.CloseJobDate,c.CSCode,c.ShippingEmp,c.ManagerCode,c.InvProduct,c.VesselName,c.TotalContainer,e.Title+''+e.NameThai as CustName,
	f.BillAcceptNo,f.BillIssueDate,f.BillAcceptDate,f.DueDate,a.SICode,
	d.NameThai as SDescription,d.IsExpense,d.IsCredit,a.UsedAmount,a.ChargeVAT,a.Tax50Tavi,a.BNet,
	h.AmtAdvance,h.AmtCharge,h.AmtVat,h.Amt50Tavi,h.TotalAmt,h.AmtCredit,(h.TotalAmt+h.AmtCredit) as TotalNet,g.ReceiptNet,
	g.ReceiptNo,g.VoucherNo,i.AdjAmt as AdjustAmt,(a.BNet-h.AmtCredit)-ISNULL(g.ReceiptNet,0) as Balance
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
		AND dt.ReceiptNo=hd.ReceiptNo WHERE ISNULL(hd.CancelProve,'')='' AND dt.VoucherNo<>''
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
	SELECT dt.BranchCode,dt.LinkBillNo,dt.JobNo,SUM(dt.BNet) as AmtCost FROM Job_ClearDetail dt INNER JOIN Job_ClearHeader hd
	ON dt.BranchCode=hd.BranchCode AND dt.ClrNo=hd.ClrNo WHERE ISNULL(hd.CancelProve,'')=''
	AND dt.LinkItem=0 AND hd.ClearType=2 GROUP BY dt.BranchCode,dt.LinkBillNo,dt.JobNo
) cost ON inv.BranchCode=cost.BranchCode AND inv.DocNo=cost.LinkBillNo AND inv.JNo=cost.JobNo
GROUP BY DocNo,InvDate,CustCode,JNo,DeclareNumber,InvNo,AmtCost
ORDER BY CustCode,InvDate,DocNo
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CHQRECEIVE"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "a.ChqDate", "b.CustCode", "", "b.RecUser", "", "a.ChqStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = " SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,AmountUsed,AmountRemain,DocUsed,ControlNo,TRemark FROM (" & SQLSelectChequeBalance("CU", "R") & sqlW & ") t ORDER BY CustCode,ChqDate,ChqNo "
                    Case "CHQISSUE"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "a.ChqDate", "b.CustCode", "", "b.RecUser", "", "a.ChqStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = " SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,DocUsed,ControlNo,TRemark FROM (" & SQLSelectChequeBalance("CH", "P") & sqlW & ") t ORDER BY CustCode,ChqDate,ChqNo "
                    Case "CHQCUSTPAY"
                        fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "a.ChqDate", "b.CustCode", "", "b.RecUser", "", "a.ChqStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = " SELECT ChqNo,ChqDate,CustCode,ChqStatus,ChqAmount,ControlNo,DocUsed,TRemark FROM (" & SQLSelectChequeBalance("CU", "P") & sqlW & ") t ORDER BY CustCode,ChqDate,ChqNo "
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
                    Case "APBILL"
                        fldGroup = "VenCode"
                        sqlW = GetSQLCommand(cliteria, "ph.DocDate", "jd.CustCode", "jd.JNo", "jd.CSCode", "ph.VenCode", "jd.JobStatus", "ph.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT        ph.DocNo,ph.DocDate, ph.VenCode, ph.RefNo, pd.ForJNo, pd.SDescription, ph.PaymentRef, pd.Total, pd.BookingRefNo, pd.ClrRefNo, cd.LinkBillNo, jd.CustCode, 
                         jd.DeclareNumber, jd.CSCode
FROM            dbo.Job_PaymentHeader AS ph INNER JOIN
                         dbo.Job_PaymentDetail AS pd ON ph.BranchCode = pd.BranchCode AND ph.DocNo = pd.DocNo INNER JOIN
                         dbo.Job_LoadInfoDetail AS ld ON pd.BookingItemNo = ld.ItemNo AND pd.BookingRefNo = ld.BookingNo AND pd.BranchCode = ld.BranchCode LEFT OUTER JOIN
                         dbo.Job_Order AS jd ON pd.ForJNo = jd.JNo AND pd.BranchCode = jd.BranchCode LEFT OUTER JOIN
                         dbo.Job_ClearDetail AS cd ON pd.ClrItemNo = cd.ItemNo AND pd.ClrRefNo = cd.ClrNo AND pd.BranchCode = cd.BranchCode
WHERE        (ISNULL(ph.CancelProve, '') = '') {0} ORDER BY ph.VenCode,ph.RefNo
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBANALYSIS"
                        'fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "jd.CreateDate", "jd.CustCode", "jd.JNo", "jd.CSCode", "jd.AgentCode", "jd.JobStatus", "jd.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT CustCode,CSCode,AgentCode,JNo, DeclareNumber,DocDate, CreateDate, 
DATEDIFF(d,CreateDate,DocDate) as OpenDays,
DutyDate,
DATEDIFF(d,CreateDate,DutyDate) as DutyDays,
 LastClearDate,
 DATEDIFF(d,DutyDate,LastClearDate) as ClearDays,
  CloseJobDate,
 DATEDIFF(d,DutyDate,CloseJobDate) as CloseDays,
 LastInvDate,
 DATEDIFF(d,LastClearDate,LastInvDate) as InvDays,
 LastRcvDate,
 DATEDIFF(d,LastInvDate,LastRcvDate) as RcvDays
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'')<>''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'')<>'' AND NOT ISNULL(ih.CancelProve,'')<>'' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'')<>'' AND NOT ISNULL(rh.CancelProve,'')<>'' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0} ORDER BY jd.CustCode,jd.JNo
                            "
                        sqlM = String.Format(sqlM, sqlW)
                    Case "ADVSTATUS"
                        sqlW = GetSQLCommand(cliteria, "a.AdvDate", "", "", "a.EmpCode", "", "", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select a.CustCode,a.CustBranch,b.NameThai,b.CreditLimit,b.DutyLimit,
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END) as AdvRequest,
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END) as AdvInProcess,
SUM(CASE WHEN a.DocStatus IN(4,5,6) THEN a.TotalAdvance ELSE 0 END) as AdvClear
from Job_AdvHeader a LEFT JOIN Mas_Company b
ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
WHERE a.DocStatus<>99 {0}
group by a.Custcode,a.CustBranch ,b.NameThai,b.CreditLimit,b.DutyLimit
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CUSTSTATUS"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.CustCode,c.Branch,c.NameThai,
SUM(CASE WHEN j.JobStatus IN(0,1,2) THEN 1 ELSE 0 END) as JobInProcess,
SUM(CASE WHEN j.JobStatus IN(3,4) THEN 1 ELSE 0 END) as JobOnClosing,
SUM(CASE WHEN j.JobStatus IN(5,6) THEN 1 ELSE 0 END) as JobOnBilling,
SUM(CASE WHEN j.JobStatus IN(7) THEN 1 ELSE 0 END) as JobPaymented,
SUM(CASE WHEN j.JobStatus IN(98,99) THEN 1 ELSE 0 END) as JobCancelled,
COUNT(j.JNo) as JobTotal
FROM Job_Order j LEFT JOIN Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE j.CustCode<>'' {0}
GROUP BY c.CustCode,c.Branch,c.NameThai
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBVALUE"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select j.JNo,j.CSCode,j.CustCode,j.DeclareNumber,j.DocDate,j.CloseJobDate,
ISNULL(a.TotalAdvPay,0) as TotalAdv,
ISNULL(c.TotalAdvClear,0) as TotalAdvClear,
ISNULL(a.TotalAdvPay,0)-ISNULL(c.TotalAdvClear,0) as AdvBalance,
ISNULL(c.TotalService,0) as TotalService,
ISNULL(c.TotalCost,0) as TotalCost,
ISNULL(c.TotalDeposit,0) as TotalDeposit,
ISNULL(c.TotalService,0)-ISNULL(c.TotalCost,0) as TotalProfit,
ISNULL(c.TotalAdvBill,0) as TotalAdvBilled,
ISNULL(c.TotalServiceBill,0) as TotalChargeBilled,
ISNULL(c.TotalAdvUnBill,0) as TotalAdvUnBill,
ISNULL(c.TotalServiceUnBill,0) as TotalChargeUnBill,
ISNULL(p.TotalVenderPaid,0) as TotalVenderPaid,
ISNULL(p.TotalVenderBill,0) as TotalVenderBill,
ISNULL(p.TotalVenderUnBill,0) as TotalVenderUnBill
from Job_Order j
left join (
	select h.BranchCode,d.ForJNo,sum(d.AdvNet) as TotalAdvPay
	from Job_AdvHeader h inner join Job_AdvDetail d
	on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
	where h.DocStatus>=3 AND h.DocStatus<99
	group by h.BranchCode,d.ForJNo
) a on j.BranchCode=a.BranchCode and j.JNo=a.ForJNo
left join (
	select h.BranchCode,d.JobNo,sum(CASE WHEN h.ClearType=1 THEN d.BNet ELSE 0 END) as TotalAdvClear,
	sum(CASE WHEN h.ClearType=2 AND SUBSTRING(d.SICode,1,3)<>'ERN' THEN d.BNet ELSE 0 END) as TotalCost,
	sum(CASE WHEN h.ClearType=2 AND SUBSTRING(d.SICode,1,3)='ERN' THEN d.BNet ELSE 0 END) as TotalDeposit,
	sum(CASE WHEN h.ClearType=3 THEN d.BNet ELSE 0 END) as TotalService,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalAdvBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalServiceBill,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalAdvUnBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalServiceUnBill
	from Job_ClearHeader h inner join Job_ClearDetail d
	on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
	where h.DocStatus>=1 AND h.DocStatus<99
	group by h.BranchCode,d.JobNo	
) c ON j.BranchCode=c.BranchCode AND j.JNo=c.JobNo
left join (
	select h.BranchCode,d.ForJNo,
	sum(CASE WHEN ISNULL(h.PaymentBy,'')<>'' THEN d.Total ELSE 0 END) as TotalVenderPaid,
	sum(CASE WHEN ISNULL(h.PaymentBy,'')='' AND ISNULL(h.PoNo,'')<>'' THEN d.Total ELSE 0 END) as TotalVenderBill,
	sum(CASE WHEN ISNULL(h.PaymentBy,'')='' AND ISNULL(h.PoNo,'')=''THEN d.Total ELSE 0 END) as TotalVenderUnBill
	from Job_PaymentHeader h inner join Job_PaymentDetail d
	on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
	inner join Job_SrvSingle s ON d.SICode=s.SICode
	where NOT ISNULL(h.CancelProve,'')<>''
	group by h.BranchCode,d.ForJNo
) p ON j.BranchCode=p.BranchCode AND j.JNo=p.ForJNo
WHERE j.JobStatus<>99 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "ADVFOLLOWUP"
                        sqlW = GetSQLCommand(cliteria, "h.PaymentDate", "h.CustCode", "d.ForJNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select h.AdvNo,h.EmpCode,h.CustCode,d.ForJNo,h.PaymentDate,d.SDescription,d.VenCode,d.UnitPrice,
(CASE WHEN h.AdvType=1 THEN d.AdvNet ELSE 0 END) as AdvCS,
(CASE WHEN h.AdvType=2 THEN d.AdvNet ELSE 0 END) as AdvCustoms,
(CASE WHEN h.AdvType=3 THEN d.AdvNet ELSE 0 END) as AdvShipping,
(CASE WHEN h.AdvType=1 THEN d.AdvNet ELSE 0 END) as AdvAdd,
ISNULL(c.ClrNet,0) as AdvUsed,c.LastClrDate,
ISNULL(d.AdvNet,0)-ISNULL(c.ClrNet,0) as AdvBal,
ISNULL(c.ClrBilled,0) as AdvCollected,c.LastInvNo,
ISNULL(c.ClrNet,0)-ISNULL(c.ClrBilled,0) as ClrBal
from Job_AdvHeader h inner join Job_AdvDetail d
on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
left join (
	select a.BranchCode,b.AdvNo,b.AdvItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,
    sum(CASE WHEN b.LinkItem>0 THEN b.BNet ELSE 0 END) as ClrBilled,
    MAX(b.LinkBillNo) as LastInvNo
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	where a.DocStatus<>99 and isnull(b.AdvNo,'')<>'' 
	group by a.BranchCode,b.AdvNo,b.AdvItemNo
) c
on d.BranchCode=c.BranchCode and d.AdvNo=c.AdvNo and d.ItemNo=c.AdvItemNo
where h.DocStatus>=3 and h.DocStatus<99 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "CLRSTATUS"
                        sqlW = GetSQLCommand(cliteria, "b.ClrDate", "c.CustCode", "c.JNo", "c.CSCode", "a.VenderCode", "b.DocStatus", "b.BranchCode", "a.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.JNo,a.AdvNo,b.ClrNo,b.ClrDate,c.CustCode,d.NameThai as SDescription,a.VenderCode,a.Date50Tavi as SlipDate,
(CASE WHEN b.ClearType=1 THEN 'ADV' ELSE (CASE WHEN b.ClearType=2 THEN 'COST' ELSE 'SERV' END) END) as ClearType,
a.UsedAmount as ClrAmt,a.ChargeVAT as ClrVat,a.Tax50Tavi as Clr50Tavi,a.BNet as ClrNet,(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN a.BNet ELSE 0 END) as ClrBilled,
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 0 ELSE a.BNet END) as ClrUnBill,a.LinkBillNo as InvNo,
i.DocDate as InvDate
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_InvoiceHeader i on a.BranchCode=i.BranchCode and a.LinkBillNo=i.DocNo
	where ISNULL(b.CancelProve,'')='' {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "INVFOLLOWUP"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "cd.JobNo", "ih.EmpCode", "cd.VenderCode", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select id.DocNo as InvNo,ih.DocDate as InvDate, cd.ClrNo,ch.ClrDate,cd.AdvNo,cd.JobNo,id.ItemNo,cd.SDescription,
(CASE WHEN ch.ClearType=1 THEN 'ADV' ELSE (CASE WHEN ch.ClearType=3 THEN 'SERV' ELSE 'COST' END) END) as InvType,
cd.BNet as ClrNet,id.AmtAdvance,id.AmtCharge,id.AmtCredit,id.AmtVat,id.Amt50Tavi,ISNULL(rd.ReceiptNet,0) as RcvNet,
ISNULl(rd.LastRcvNo,'') as RcvNo,rd.LastRcvDate,id.TotalAmt-ISNULL(rd.ReceiptNet,0) as Balance
from Job_InvoiceDetail id left join Job_ClearDetail cd
on id.BranchCode=cd.BranchCode and id.DocNo=cd.LinkBillNo
and id.ItemNo=cd.LinkItem
left join Job_ClearHeader ch on cd.BranchCode=ch.BranchCode
and cd.ClrNo=ch.ClrNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
left join (
	SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,sum(d.Net) as ReceiptNet
	,Max(h.ReceiptNo) as LastRcvNo,Max(h.ReceiptDate) as LastRcvDate
	FROM Job_ReceiptDetail d inner join Job_ReceiptHeader h
	on d.BranchCode=h.BranchCode and d.ReceiptNo=h.ReceiptNo
	where NOT ISNULL(h.CancelProve,'')<>''
	group by d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
)rd on id.BranchCode=rd.BranchCode and id.DocNo=rd.InvoiceNo
and id.ItemNo=rd.InvoiceItemNo
where NOT ISNULL(ih.CancelProve,'')<>'' AND ISNULL(ch.DocStatus,0)<>99 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "EXPFOLLOWUP"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "j.CustCode", "d.ForJNo", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT h.DocNo, h.DocDate,h.PaymentDate,h.VenCode,v.TName, h.EmpCode, h.PoNo as VenInvNo,h.RefNo as CTN_NO,
d.SDescription, d.Qty, d.QtyUnit, d.UnitPrice, d.Amt, d.AmtVAT, d.AmtWHT,
(CASE WHEN s.IsExpense=1 THEN 'COST' ELSE 'ADV' END) as CostType,
(CASE WHEN ISNULL(h.PaymentBy,'')<>'' THEN d.Total ELSE 0 END) as PaidAmt,
(CASE WHEN ISNULL(h.PaymentBy,'')='' THEN d.Total ELSE 0 END) as UnPaidAmt,
d.ForJNo,j.CustCode
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'')<>'' {0}
"
                        sqlM = String.Format(sqlM, sqlW)

                    Case "YEARSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "h.ClrDate", "j.CustCode", "j.JNo", "h.EmpCode", "d.VenderCode", "j.JobStatus", "h.BranchCode", "d.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select Year(h.ClrDate) as yy,(CASE WHEN h.ClearType=1 THEN 'ADV' ELSE (CASE WHEN h.ClearType=2 THEN 'COST' ELSE 'SERV' END) END) as ClrType
,c.CustCode,c.Branch,
Sum(CASE WHEN Month(h.ClrDate)=1 THEN d.BNet ELSE 0 END) as ClrJan,
Sum(CASE WHEN Month(h.ClrDate)=2 THEN d.BNet ELSE 0 END) as ClrFeb,
Sum(CASE WHEN Month(h.ClrDate)=3 THEN d.BNet ELSE 0 END) as ClrMar,
Sum(CASE WHEN Month(h.ClrDate)=4 THEN d.BNet ELSE 0 END) as ClrApr,
Sum(CASE WHEN Month(h.ClrDate)=5 THEN d.BNet ELSE 0 END) as ClrMay,
Sum(CASE WHEN Month(h.ClrDate)=6 THEN d.BNet ELSE 0 END) as ClrJun,
Sum(CASE WHEN Month(h.ClrDate)=7 THEN d.BNet ELSE 0 END) as ClrJul,
Sum(CASE WHEN Month(h.ClrDate)=8 THEN d.BNet ELSE 0 END) as ClrAug,
Sum(CASE WHEN Month(h.ClrDate)=9 THEN d.BNet ELSE 0 END) as ClrSep,
Sum(CASE WHEN Month(h.ClrDate)=10 THEN d.BNet ELSE 0 END) as ClrOct,
Sum(CASE WHEN Month(h.ClrDate)=11 THEN d.BNet ELSE 0 END) as ClrNov,
Sum(CASE WHEN Month(h.ClrDate)=12 THEN d.BNet ELSE 0 END) as ClrDec
from Job_ClearHeader h inner join Job_ClearDetail d ON h.BranchCode=d.BranchCode
AND h.ClrNo=d.ClrNo
INNER JOIN Job_Order j ON d.BranchCode=j.BranchCode AND d.JobNo=j.JNo
INNER JOIN Mas_Company c on j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE h.DocStatus<>99 {0}
GROUP BY h.ClearType,c.CustCode,c.Branch,Year(h.ClrDate)
ORDER BY CustCode,Branch,ClearType
                            "
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT01"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        Dim sqlW2 = GetSQLCommand(cliteria, "", "", "", "", "", "", "", "", "c.CommLevel")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        If sqlW2 <> "" Then sqlW2 = " WHERE " & sqlW2
                        sqlM = "SELECT c.NameEng as 'Customer',j.* FROM (" & SQLSelectJobCount(sqlW, "j.CustCode") & ") j INNER JOIN Mas_Company c ON j.CustCode=c.CustCode " & sqlW2 & " ORDER BY c.NameEng"
                    Case "MGMT02"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.ManagerCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        Dim sqlW2 = GetSQLCommand(cliteria, "", "", "", "", "", "", "", "", "CommLevel")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        If sqlW2 <> "" Then sqlW2 = " AND j.CustCode IN(SELECT CustCode FROM Mas_Company WHERE " & sqlW2 & ")"
                        sqlM = "SELECT c.EName as 'Customer Service',j.* FROM (" & SQLSelectJobCount(sqlW & sqlW2, "j.CSCode") & ") j INNER JOIN Mas_User c ON j.CSCode=c.UserID ORDER BY c.EName"
                    Case "MGMT03"
                        'fldGroup = "CustCode"
                        sqlW = GetSQLCommand(cliteria, "jd.CreateDate", "jd.CustCode", "jd.JNo", "jd.CSCode", "jd.AgentCode", "jd.JobStatus", "jd.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT CustCode as 'Customer',CSCode as 'CS',AgentCode as Vender,JNo as 'Job Number', DeclareNumber as 'Customs Declare#',
DocDate as 'Job Date', CreateDate as 'Creation Date', 
DATEDIFF(d,CreateDate,DocDate) as OpenDays,
DutyDate as 'Customs Inspection Date',
DATEDIFF(d,CreateDate,DutyDate) as 'Customs Lead Time',
 LastClearDate as 'Job Clear Date',
 DATEDIFF(d,DutyDate,LastClearDate) as 'Clear Lead Time',
  CloseJobDate as 'Job Close Date',
 DATEDIFF(d,DutyDate,CloseJobDate) as 'Close Lead Time',
 LastInvDate as 'Invoice Creation Date',
 DATEDIFF(d,LastClearDate,LastInvDate) as 'Invoice Lead Time',
 LastRcvDate as 'Receipt Date',
 DATEDIFF(d,LastInvDate,LastRcvDate) as 'A/R Aging Days'
FROM            dbo.Job_Order AS jd LEFT JOIN
(
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ch.ClrDate) as LastClearDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 WHERE NOT ISNULL(ch.CancelProve,'')<>''
 GROUP BY ch.BranchCode,cd.JobNo
) cs
ON jd.BranchCode=cs.BranchCode AND jd.JNo=cs.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(ih.DocDate) as LastInvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceHeader ih on cd.BranchCode=ih.BranchCode
 AND cd.LinkBillNo=ih.DocNo 
 WHERE NOT ISNULL(ch.CancelProve,'')<>'' AND NOT ISNULL(ih.CancelProve,'')<>'' 
 GROUP BY ch.BranchCode,cd.JobNo
) iv
ON jd.BranchCode=iv.BranchCode AND jd.JNo=iv.JobNo
LEFT JOIN (
 SELECT ch.BranchCode ,cd.JobNo ,MAX(rh.ReceiptDate) as LastRcvDate
 FROM Job_ClearHeader ch inner join Job_ClearDetail cd
 ON ch.BranchCode=cd.BranchCode AND ch.ClrNo=cd.ClrNo
 INNER JOIN Job_InvoiceDetail id on cd.BranchCode=id.BranchCode
 AND cd.LinkBillNo=id.DocNo INNER JOIN Job_ReceiptDetail rd
 ON id.BranchCode=rd.BranchCode AND id.DocNo=rd.InvoiceNo
 AND id.ItemNo=rd.InvoiceItemNo INNER JOIN Job_ReceiptHeader rh
 ON rd.BranchCode=rh.BranchCode AND rd.ReceiptNo=rh.ReceiptNo
 WHERE NOT ISNULL(ch.CancelProve,'')<>'' AND NOT ISNULL(rh.CancelProve,'')<>'' 
 GROUP BY ch.BranchCode,cd.JobNo
) rs
ON jd.BranchCode=rs.BranchCode AND jd.JNo=rs.JobNo
WHERE jd.JobStatus<90 {0} ORDER BY jd.CustCode,jd.JNo
                            "
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT04"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select j.CustCode as 'Customer',j.JNo as 'Job Number',j.DeclareNumber as 'Customs Declare#',j.InvNo as 'Commercial Invoice#'
,j.CSCode as 'CS',j.CreateDate as 'Job Creation Date',j.CloseJobDate as 'Job Close Date',
ISNULL(a.TotalAdvPay,0) as 'Invoice To Customer-Advance',
ISNULL(c.TotalService,0) as 'Invoice To Customer-Service',
ISNULL(c.TotalAdvClear,0) as 'Payment To Vender-Advance',
ISNULL(c.TotalCost,0) as 'Payment To Vender-Cost',
ISNULL(c.TotalDeposit,0) as 'Payment To Vender-Deposit',
ISNULL(c.TotalService,0)-ISNULL(c.TotalCost,0) as 'Profit',
ISNULL(c.TotalAdvBill,0) as 'Customer Billed-Advance',
ISNULL(c.TotalServiceBill,0) as 'Customer Billed-Service',
ISNULL(c.TotalAdvUnBill,0) as 'Customer Unbilled-Advance',
ISNULL(c.TotalServiceUnBill,0) as 'Customer Unbilled-Service',
ISNULL(p.TotalVenderBill,0) as 'Exp-Billed',
ISNULL(p.TotalVenderUnBill,0) as 'Exp-Unbilled',
ISNULL(p.TotalVenderPaid,0) as 'Exp-Paid'
from Job_Order j
left join (
	select h.BranchCode,d.ForJNo,sum(d.AdvNet) as TotalAdvPay
	from Job_AdvHeader h inner join Job_AdvDetail d
	on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
	where h.DocStatus>=3 AND h.DocStatus<99
	group by h.BranchCode,d.ForJNo
) a on j.BranchCode=a.BranchCode and j.JNo=a.ForJNo
left join (
	select h.BranchCode,d.JobNo,sum(CASE WHEN h.ClearType=1 THEN d.BNet ELSE 0 END) as TotalAdvClear,
	sum(CASE WHEN h.ClearType=2 AND SUBSTRING(d.SICode,1,3)<>'ERN' THEN d.BNet ELSE 0 END) as TotalCost,
	sum(CASE WHEN h.ClearType=2 AND SUBSTRING(d.SICode,1,3)='ERN' THEN d.BNet ELSE 0 END) as TotalDeposit,
	sum(CASE WHEN h.ClearType=3 THEN d.BNet ELSE 0 END) as TotalService,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalAdvBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem>0 THEN d.BNet ELSE 0 END) as TotalServiceBill,
	sum(CASE WHEN h.ClearType=1 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalAdvUnBill,
	sum(CASE WHEN h.ClearType=3 AND d.LinkItem=0 THEN d.BNet ELSE 0 END) as TotalServiceUnBill
	from Job_ClearHeader h inner join Job_ClearDetail d
	on h.BranchCode=d.BranchCode and h.ClrNo=d.ClrNo
	where h.DocStatus>=1 AND h.DocStatus<99
	group by h.BranchCode,d.JobNo	
) c ON j.BranchCode=c.BranchCode AND j.JNo=c.JobNo
left join (
	select h.BranchCode,d.ForJNo,
	sum(CASE WHEN ISNULL(h.PaymentBy,'')<>'' THEN d.Total ELSE 0 END) as TotalVenderPaid,
	sum(CASE WHEN ISNULL(h.PaymentBy,'')='' AND ISNULL(h.PoNo,'')<>'' THEN d.Total ELSE 0 END) as TotalVenderBill,
	sum(CASE WHEN ISNULL(h.PaymentBy,'')='' AND ISNULL(h.PoNo,'')=''THEN d.Total ELSE 0 END) as TotalVenderUnBill
	from Job_PaymentHeader h inner join Job_PaymentDetail d
	on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
	inner join Job_SrvSingle s ON d.SICode=s.SICode
	where NOT ISNULL(h.CancelProve,'')<>''
	group by h.BranchCode,d.ForJNo
) p ON j.BranchCode=p.BranchCode AND j.JNo=p.ForJNo
WHERE j.JobStatus<>99 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT05"
                        sqlW = GetSQLCommand(cliteria, "h.PaymentDate", "h.CustCode", "d.ForJNo", "h.EmpCode", "d.VenCode", "h.DocStatus", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select d.ForJNo as 'Job Number',h.AdvNo as 'Advance No',c.LastClrNo as 'Clearing No',
c.LastClrDate as 'Clearing Date',c.LastInvNo as 'Invoice No',c.LastInvDate as 'Invoice Date',
(CASE WHEN ISNULL(c.LastInvNo,'')='' THEN DATEDIFF(DAY,c.LastClrDate,GetDate()) ELSE 0 END) as 'Unbilled Aging Day',
(CASE WHEN ISNULL(c.LastInvNo,'')<>'' THEN DATEDIFF(DAY,c.LastClrDate,c.LastInvDate) ELSE 0 END) as 'Billed Aging Day',
h.CustCode as 'Customer',c.LastReceiptNo as 'Receipt No',c.LastReceiptDate as 'Receipt Date',
(d.AdvNet) as 'Advance Amount',
ISNULL(c.ClrNet,0) as 'Actual Spending',
ISNULL(c.ClrBillAble,0) as 'Billable Amount',
ISNULL(c.ClrVat,0) as 'VAT',
ISNULL(c.ClrWht,0) as 'WHT',
ISNULL(c.ClrBilled,0) as 'Billed Advance',
ISNULL(c.ClrUnBilled,0) as 'Unbilled Advance'
from Job_AdvHeader h inner join Job_AdvDetail d
on h.BranchCode=d.BranchCode and h.AdvNo=d.AdvNo
left join (
	select a.BranchCode,b.AdvNo,b.AdvItemNo,sum(b.BNet) as ClrNet,
	Max(a.Clrdate) as LastClrDate,Max(a.ClrNo) as LastClrNo,
    sum(CASE WHEN b.LinkItem>0 and a.ClearType<>2 THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrBilled,
	sum(CASE WHEN b.LinkItem=0 and a.ClearType<>2 THEN b.BNet+b.Tax50Tavi ELSE 0 END) as ClrUnBilled,
    MAX(b.LinkBillNo) as LastInvNo,Max(i.DocDate) as LastInvDate,
	MAX(r.ReceiptNo) as LastReceiptNo,MAX(t.ReceiptDate) as LastReceiptDate,
	sum(CASE WHEN a.ClearType<>2 THEN b.UsedAmount ELSE 0 END) as ClrBillAble,
	sum(CASE WHEN a.ClearType<>2 THEN b.ChargeVAT ELSE 0 END) as ClrVat,
	sum(CASE WHEN a.ClearType<>2 THEN b.Tax50Tavi ELSE 0 END) as ClrWht
	FROM Job_ClearHeader a inner join Job_ClearDetail b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	left join Job_InvoiceHeader i on b.BranchCode=i.BranchCode 
	AND b.LinkBillNo=i.DocNo
    left join Job_ReceiptDetail r on b.BranchCode=r.BranchCode
    AND b.LinkBillNo=r.InvoiceNo AND b.LinkItem=r.InvoiceItemNo
    left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
    and r.ReceiptNo=t.ReceiptNo
	where a.DocStatus<>99 and isnull(b.AdvNo,'')<>'' AND ISNULL(t.CancelProve,'')=''
	group by a.BranchCode,b.AdvNo,b.AdvItemNo
) c
on d.BranchCode=c.BranchCode and d.AdvNo=c.AdvNo and d.ItemNo=c.AdvItemNo
where h.DocStatus>=3 and h.DocStatus<99 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT06"
                        sqlW = GetSQLCommand(cliteria, "a.AdvDate", "", "", "a.EmpCode", "", "", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select b.NameEng as 'Customer Name',b.CreditLimit as 'Advanced Credit Term',b.DutyLimit as 'Advanced Credit Limit',
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END) as 'Advance Requested',
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END) as 'Advance Paid',
SUM(ISNULL(c.AdvUsed,0)) as 'Paid+Cleared Advance',
SUM(ISNULL(c.AdvBilled,0)) as 'Billed To Customer',
SUM(ISNULL(c.AdvUnbill,0)) as 'Unbilled Advance',
SUM(ISNULL(c.AdvCost,0)) as 'Advance Cost',
SUM(ISNULL(c.AdvReceive,0)) as 'Customer Payment',
(CASE WHEN b.DutyLimit>0 THEN b.DutyLimit
-
SUM(CASE WHEN a.DocStatus=3 THEN a.TotalAdvance ELSE 0 END)
-
sum(CASE WHEN a.DocStatus<=2 THEN a.TotalAdvance ELSE 0 END)
-
SUM(ISNULL(c.AdvUsed,0)) ELSE 0 END)
+
SUM(ISNULL(c.AdvReceive,0))
  as 'Net Avaiable Balance'
from Job_AdvHeader a LEFT JOIN Mas_Company b
ON a.CustCode=b.CustCode AND a.CustBranch=b.Branch
left join (
	select h.BranchCode,d.AdvNo,SUM(d.BNet) as AdvUsed,
	SUM(CASE WHEN d.LinkItem>0 AND h.ClearType<>'2' THEN d.BNet ELSE 0 END) as AdvBilled,
	SUM(CASE WHEN d.LinkItem=0 AND h.ClearType<>'2' THEN d.BNet ELSE 0 END) as AdvUnbill,
	SUM(CASE WHEN h.ClearType='2' THEN d.BNet ELSE 0 END) as AdvCost,
	SUM(CASE WHEN h.ClearType='2' THEN 0 ELSE ISNULL(r.Net,0) END) as AdvReceive
	from Job_ClearHeader h
	inner join Job_ClearDetail d ON h.BranchCode=d.BranchCode
	and h.ClrNo=d.ClrNo
	left join Job_ReceiptDetail r on d.BranchCode=r.BranchCode 
	and d.LinkBillNo=r.InvoiceNo AND d.LinkItem=r.InvoiceItemNo
	left join Job_ReceiptHeader t on r.BranchCode=t.BranchCode
	and r.ReceiptNo=t.ReceiptNo
	where h.DocStatus<>99 AND ISNULL(t.CancelProve,'')=''
	group by h.BranchCode,d.AdvNo
) c
ON a.BranchCode=c.BranchCode and a.AdvNo=c.AdvNo
WHERE a.DocStatus<>99 {0}
group by b.NameEng,b.CreditLimit,b.DutyLimit
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT07"
                        sqlW = GetSQLCommand(cliteria, "b.ClrDate", "c.CustCode", "c.JNo", "b.EmpCode", "a.VenderCode", "b.DocStatus", "b.BranchCode", "a.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.JNo as 'Job Number',a.AdvNo as 'Advance No',b.ClrNo as 'Clearing No',b.ClrDate as 'Clearing Date',c.CustCode as 'Customer',
b.CTN_NO as 'Container Number',a.VenderCode as 'Vender',
a.SlipNO as 'Receipt#',a.Date50Tavi as 'Receipt Date',a.UsedAmount as 'Container Deposit',
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN a.BNet ELSE 0 END) as 'Addition Expenses',
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 0 ELSE a.BNet END) as 'Deposit Return',
a.LinkBillNo as 'V/Receipt#, APLL Inv#',v.VoucherDate as 'Deposit Received Date'
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
	where ISNULL(b.CancelProve,'')='' AND d.GroupCode='ERN' AND a.UsedAmount>0 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT08"
                        sqlW = GetSQLCommand(cliteria, "ih.DocDate", "ih.CustCode", "cd.JobNo", "ih.EmpCode", "cd.VenderCode", "(CASE WHEN ISNULL(ih.CancelProve,'')<>'' THEN 99 ELSE 0 END)", "ih.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select ih.CustCode as 'Customer',id.DocNo as 'Invoice No',cd.JobNo as 'Job Number',ih.DocDate as 'Invoice Date', cd.SDescription as 'Description',
(CASE WHEN ch.ClearType=1 THEN 'ADV' ELSE (CASE WHEN ch.ClearType=3 THEN 'SERV' ELSE 'COST' END) END) as 'Type',
id.Amt as 'Amount',id.AmtVat as 'VAT',id.AmtCredit as 'Prepaid' ,id.Amt50Tavi as 'WHT',id.TotalAmt as'Total Amount',
0 as 'CN,DN Amount',id.AmtCharge as 'Advance Amount',id.AmtCharge as 'SVC Amount',ISNULL(rd.ReceiptNet,0) as 'Payment Received',
ISNULl(rd.LastRcvNo,'') as 'Receipt No',rd.LastRcvDate as 'Receipt Date'
from Job_InvoiceDetail id left join Job_ClearDetail cd
on id.BranchCode=cd.BranchCode and id.DocNo=cd.LinkBillNo
and id.ItemNo=cd.LinkItem
left join Job_ClearHeader ch on cd.BranchCode=ch.BranchCode
and cd.ClrNo=ch.ClrNo
inner join Job_InvoiceHeader ih on id.BranchCode=ih.BranchCode and id.DocNo=ih.DocNo
left join (
	SELECT d.BranchCode,d.InvoiceNo,d.InvoiceItemNo,sum(d.Net) as ReceiptNet
	,Max(h.ReceiptNo) as LastRcvNo,Max(h.ReceiptDate) as LastRcvDate
	FROM Job_ReceiptDetail d inner join Job_ReceiptHeader h
	on d.BranchCode=h.BranchCode and d.ReceiptNo=h.ReceiptNo
	where NOT ISNULL(h.CancelProve,'')<>''
	group by d.BranchCode,d.InvoiceNo,d.InvoiceItemNo
)rd on id.BranchCode=rd.BranchCode and id.DocNo=rd.InvoiceNo
and id.ItemNo=rd.InvoiceItemNo
where NOT ISNULL(ih.CancelProve,'')<>'' AND ISNULL(ch.DocStatus,0)<>99 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT09"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "j.CustCode", "d.ForJNo", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT h.DocNo as 'Reference#',d.ForJNo as 'Job Number', h.DocDate as 'Creation Date',
v.TName as 'Vender',h.RefNo as 'Container No',d.SDescription as 'Expense',
(CASE WHEN s.IsExpense=1 THEN 'COST' ELSE 'ADV' END) as 'Type',
d.Amt as 'Amount', d.AmtVAT as 'VAT', d.AmtWHT as 'WHT',
(CASE WHEN ISNULL(h.PaymentBy,'')<>'' THEN d.Total ELSE 0 END) as 'BILLED',
(CASE WHEN ISNULL(h.PaymentBy,'')='' THEN d.Total ELSE 0 END) as 'UNBILLED',
h.PoNo as 'Vender Inv#',j.CustCode as 'Customer'
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'')<>'' {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT10"
                        sqlW = GetSQLCommand(cliteria, "h.DocDate", "j.CustCode", "d.ForJNo", "h.EmpCode", "h.VenCode", "", "h.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT h.DocNo as 'Reference#', h.DocDate as 'Creation Date',
v.TName as 'Vender',h.RefNo as 'Container No',d.SDescription as 'Expense',
(CASE WHEN s.IsExpense=1 THEN 'COST' ELSE 'ADV' END) as 'Type',
d.Amt as 'Amount', d.AmtVAT as 'VAT', d.AmtWHT as 'WHT',
d.Total as 'Total',d.ForJNo as 'Job Number',j.CustCode as 'Customer'
FROM dbo.Job_PaymentHeader AS h LEFT OUTER JOIN
dbo.Mas_Vender AS v ON h.VenCode = v.VenCode INNER JOIN
dbo.Job_PaymentDetail AS d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode
LEFT JOIN dbo.Job_Order as j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
WHERE NOT ISNULL(h.CancelProve,'')<>'' AND ISNULL(h.PoNo,'')='' {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "MGMT11"
                        sqlW = GetSQLCommand(cliteria, "b.ClrDate", "c.CustCode", "c.JNo", "c.CSCode", "a.VenderCode", "b.DocStatus", "b.BranchCode", "a.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.JNo as 'Job Number',d.NameThai as 'Description',a.AdvNo as 'Advance No',
b.ClrNo as 'Clearing No',b.ClrDate as 'Clearing date',c.CustCode as 'Customer',r.ReceiptNo as 'Receipt No',r.ReceiptDate as 'Receipt Date',
a.UsedAmount as 'Amount',a.ChargeVAT as 'VAT Amount',a.Tax50Tavi as 'WHT Amount',(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN a.BNet ELSE 0 END) as 'Invoice Billed',
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 0 ELSE a.BNet END) as 'Invoice Unbilled',a.LinkBillNo as 'Invoice No',
i.DocDate as 'Invoice Date',
(CASE WHEN b.ClearType=1 THEN 'ADV' ELSE (CASE WHEN b.ClearType=2 THEN 'COST' ELSE 'SERV' END) END) as 'Type'
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_InvoiceHeader i on a.BranchCode=i.BranchCode and a.LinkBillNo=i.DocNo
	left join (
		SELECT hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo,MAX(hd.ReceiptDate) as ReceiptDate,MAX(hd.ReceiptNo) as ReceiptNo
		FROM Job_ReceiptHeader hd INNER JOIN Job_ReceiptDetail dt
		ON hd.BranchCode=dt.BranchCode AND hd.ReceiptNo=dt.ReceiptNo
		WHERE ISNULL(hd.CancelProve,'')=''
		GROUP BY hd.BranchCode,dt.InvoiceNo,dt.InvoiceItemNo
	) r on a.BranchCode=r.BranchCode and a.LinkBillNo=r.InvoiceNo AND a.LinkItem=r.InvoiceItemNo
	where ISNULL(b.CancelProve,'')='' {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "BUYRATE"
                        fldGroup = "CostName"
                        sqlW = GetSQLCommand(cliteria, "", "d.CustCode", "", "", "d.VenderCode", "", "d.BranchCode", "d.SICode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "
select h.LocationRoute as WorkType,d.VenderCode,d.CustCode,d.SDescription as CostName,d.CostAmount,s.NameThai as ChargeName ,d.ChargeAmount,
d.ChargeAmount-d.CostAmount as Profit
from Job_TransportPrice d inner join Job_TransportRoute h
ON d.LocationID=h.LocationID
left join Job_SrvSingle s 
ON d.ChargeCode=s.SICode
{0}
ORDER BY d.SDescription,d.ChargeAmount-d.CostAmount DESC
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "ADVTOTAL"
                        sqlW = GetSQLCommand(cliteria, "a.PaymentDate", "a.CustCode", "b.ForJNo", "a.EmpCode", "", "a.DocStatus", "a.BranchCode",, "c.CommLevel")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = SQLSelectAdvanceTotal(sqlW)
                    Case "ADVEXPENSE"
                        sqlW = GetSQLCommand(cliteria, "a.PaymentDate", "a.CustCode", "b.ForJNo", "a.EmpCode", "", "a.DocStatus", "a.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = SQLSelectAdvanceTotalJob(sqlW)
                    Case "JOBDETAIL"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.ForwarderCode", "j.JobStatus", "j.BranchCode",, "c.CommLevel")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = SQLSelectClearingTotal(sqlW)
                    Case "JOBDETAILSUM"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.ForwarderCode", "j.JobStatus", "j.BranchCode",, "c.CommLevel")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = SQLSelectClearingTotal2(sqlW)
                    Case "ADVCLEARING"
                        sqlW = GetSQLCommand(cliteria, "t.AdvDate", "t.CustCode", "t.ForJNo", "t.AdvBy", "t.ForwarderCode", "t.AdvStatus", "t.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT t.DocDate as JobDate,t.ForJNo as JobNo,t.HAWB,t.AgentCode,t.ETADate,t.DutyDate,t.JobTypeName,t.ShipByName,t.AdvBy,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (" & SQLSelectAdvReport() & ") as t " & sqlW & " ORDER BY t.DocDate,t.ForJNo"
                    Case "ADVIMPORT"
                        sqlW = GetSQLCommand(cliteria, "t.ETADate", "t.CustCode", "t.ForJNo", "t.AdvBy", "t.ForwarderCode", "t.AdvStatus", "t.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT t.ForJNo,t.ETADate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (" & SQLSelectAdvReport() & ") as t WHERE t.JobType=1 AND t.JobStatus<>99 " & sqlW & " ORDER BY t.ETADate,t.ForJNo"
                    Case "ADVEXPORT"
                        sqlW = GetSQLCommand(cliteria, "t.ETDDate", "t.CustCode", "t.ForJNo", "t.AdvBy", "t.ForwarderCode", "t.AdvStatus", "t.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT t.ForJNo,t.ETDDate,SUBSTRING(t.ForJNo,1,2) as JobType,t.EmpCode,t.AdvDate,t.AdvStatus,t.AdvNo,t.SDescription,t.AdvNet, t.ClrNo,t.ClrDate,t.ClrSDescription,t.BNet as ClrNet FROM (" & SQLSelectAdvReport() & ") as t WHERE t.JobType=2 AND t.JobStatus<>99 " & sqlW & " ORDER BY t.ETDDate,t.ForJNo"
                    Case "PLANLOAD"
                        sqlW = GetSQLCommand(cliteria, "t.BookingDate", "t.CustCode", "t.JNo", "t.CSCode", "t.ForwarderCode", "t.JobStatus", "t.BranchCode")
                        If sqlW <> "" Then sqlW = " WHERE " & sqlW
                        sqlM = "SELECT t.JNo,t.BookingNo,t.BookingDate,t.ForwarderCode,t.TotalContainer,t.TargetYardDate as PickUpTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'' THEN (case when t.CauseCode='99' THEN 'Cancel' ELSE (CASE WHEN t.CauseCode='3' THEN 'Finish' ELSE 'Working' END) END) ELSE 'Request' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (" & SQLSelectContainerReport() & ") as t " & sqlW & " ORDER BY t.BookingDate,t.JNo"
                    Case "PLANLOADIM"
                        sqlW = GetSQLCommand(cliteria, "t.TargetYardDate", "t.CustCode", "t.JNo", "t.CSCode", "t.ForwarderCode", "t.JobStatus", "t.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT t.JNo,t.BookingNo,t.ETADate,t.ForwarderCode,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'' THEN (case when t.CauseCode='99' THEN 'Cancel' ELSE (CASE WHEN t.CauseCode='3' THEN 'Finish' ELSE 'Working' END) END) ELSE 'Request' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (" & SQLSelectContainerReport() & ") as t WHERE t.JobType=1 AND t.JobStatus<>99 " & sqlW & " ORDER BY t.ETADate,t.JNo"
                    Case "PLANLOADEX"
                        sqlW = GetSQLCommand(cliteria, "t.TargetYardDate", "t.CustCode", "t.JNo", "t.CSCode", "t.ForwarderCode", "t.JobStatus", "t.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "SELECT t.JNo,t.BookingNo,t.ETDDate,t.ForwarderCode,t.TotalContainer,t.TargetYardDate as PickupTargetDate,t.ActualYardDate as PickupActualDate,(CASE WHEN t.CauseCode<>'' THEN (case when t.CauseCode='99' THEN 'Cancel' ELSE (CASE WHEN t.CauseCode='3' THEN 'Finish' ELSE 'Working' END) END) ELSE 'Request' END) as ContainerStatus,t.CTN_NO,t.UnloadFinishDate as DeliveryDate,t.CtnReturnDate as ReturnDate FROM (" & SQLSelectContainerReport() & ") as t WHERE t.JobType=2 AND t.JobStatus<>99 " & sqlW & " ORDER BY t.ETDDate,t.JNo"
                    Case "DAILYCASH"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "", "", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT t.ReceiptNo as 'Receipt No',CONCAT(t.CustEName,'<br/>Ref# ',t.PaidRef,' Bank:', t.PaidBank) as 'Shipper/Cheque Details',
(CASE WHEN t.PaidType='CHQ' THEN Convert(float,t.PaidAmount) ELSE 0 END) as 'Chq Amt',
(CASE WHEN t.PaidType='CASH' THEN Convert(float,t.PaidAmount) ELSE 0 END) as 'Cash Amt',
t.TotalWhtax as 'WHD Tax',t.PaidAmount as 'Total Amt',t.InvNo as 'Invoice No'
FROM (" & SQLSelectReceiptSummary(sqlW) & ") as t 
ORDER BY t.ReceiptNo
"
                    Case "OUTPUTTAX"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "", "", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT 
t.CustEName as 'Customer',t.TaxNumber,(CASE WHEN t.Branch=0 THEN 'HEAD OFFICE' ELSE t.Branch END) as Branch,
t.ReceiptDate as 'Date',t.ReceiptNo,t.TotalTransport as 'Transport',t.TotalService as 'Service',
t.TotalVat as 'Vat',t.TotalAdvance as 'Advance',t.TotalTransport+t.TotalService+t.TotalVat+t.TotalAdvance as 'Amt.Baht'
FROM (" & SQLSelectReceiptSummary(sqlW) & ") as t 
ORDER BY t.ReceiptNo
"
                    Case "OUTPUTWHT"
                        sqlW = GetSQLCommand(cliteria, "rh.ReceiptDate", "rh.CustCode", "", "", "", "", "rh.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT 
t.ReceiptDate as 'Date',t.ReceiptNo,t.CustEName as 'Customer',t.TaxNumber,
(CASE WHEN t.Branch=0 THEN 'HEAD OFFICE' ELSE t.Branch END) as Branch,t.TotalWhtax as 'WHD Tax'
FROM (" & SQLSelectReceiptSummary(sqlW) & ") as t 
ORDER BY t.ReceiptNo
"
                    Case "EARNEST"
                        sqlW = GetSQLCommand(cliteria, "b.ClrDate", "c.CustCode", "c.JNo", "b.EmpCode", "a.VenderCode", "b.DocStatus", "b.BranchCode", "a.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select c.CustCode as 'Customer',c.AgentCode as 'Vender',
c.JNo as 'Job Number',a.AdvNo as 'Advance No',c.DutyDate as 'Inspection Date',
b.ClrDate as 'Clearing Date',c.TotalContainer as 'Container Number',
a.SlipNO as 'Receipt No',a.Date50Tavi as 'Date Receipt',
a.AdvAmount as 'Container Deposit',
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN a.BNet ELSE 0 END) as 'Addition Expenses',
(CASE WHEN ISNULL(a.LinkBillNo,'')<>'' THEN 0 ELSE a.BNet END) as 'Deposit Return',
a.LinkBillNo as 'V/Receipt#',v.VoucherDate as 'Received Date'
	from Job_ClearDetail a inner join Job_ClearHeader b
	on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
	inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
	inner join Job_SrvSingle d on a.SICode=d.SICode
	inner join Mas_Company e on c.CustCode=e.CustCode and c.CustBranch=e.Branch
	left join Job_CashControl v on a.BranchCode=v.BranchCode ANd a.LinkBillNo=v.ControlNo
	where ISNULL(b.CancelProve,'')='' AND d.GroupCode='ERN' AND a.UsedAmount>0 {0}
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "GROSSPROFIT"
                        sqlW = GetSQLCommand(cliteria, "c.DocDate", "c.CustCode", "c.JNo", "c.CSCode", "c.AgentCode", "c.JobStatus", "c.BranchCode", "a.SICode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
select jt.JobTypeName as 'JobType',sb.ShipByName as 'ShipBy',
sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount-a.Tax50Tavi ELSE 0 END) as 'Revenue',
sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as 'Cost',
count(DISTINCT c.JNo) as 'Total Job',
sum(CASE WHEN d.IsExpense=0 AND d.IsCredit=0 THEN a.UsedAmount-a.Tax50Tavi ELSE 0 END)/count(DISTINCT c.JNo) as 'Average Revenue',
sum(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END) as 'Profit',
(sum(CASE WHEN d.IsExpense=0 THEN a.UsedAmount ELSE 0 END)-sum(CASE WHEN d.IsExpense=1 THEN a.UsedAmount ELSE 0 END))/count(DISTINCT c.JNo) as 'Average Profit'
from Job_ClearDetail a inner join Job_ClearHeader b
on a.BranchCode=b.BranchCode and a.ClrNo=b.ClrNo
inner join Job_Order c on a.BranchCode=c.BranchCode and a.JobNo=c.JNo
inner join Job_SrvSingle d on a.SICode=d.SICode
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode='JOB_TYPE'
) jt ON c.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode='SHIP_BY'
) sb ON c.ShipBy=sb.ShipBy
where ISNULL(b.CancelProve,'')='' AND a.BNet>0 AND c.JobStatus<90 {0}
group by jt.JobTypeName,sb.ShipByName
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBPROFIT"
                        sqlW = GetSQLCommand(cliteria, "j.DocDate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT j.CSCode, j.JNo, j.DocDate as JobDate, j.CustCode,j.CustBranch,
jt.JobTypeName as JobType,sb.ShipByName as ShipBy,c.NameEng as CustEName,
j.BookingNo, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo as CustInvNo,j.TotalContainer,
SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) AS SumCost,
SUM(CASE WHEN sv.IsCredit=1 AND sv.IsExpense=0 THEN cd.BNet ELSE 0 END) AS SumAdvance,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END) AS SumCharge,
SUM(CASE WHEN sv.GroupCode='ERN' THEN cd.UsedAmount ELSE 0 END) AS SumDeposit,
SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END) as Profit,
(SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END)
-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END))/ABS(SUM(CASE WHEN sv.IsCredit=0 AND sv.IsExpense=0 THEN cd.UsedAmount ELSE 0 END)-SUM(CASE WHEN sv.IsExpense=1 THEN cd.UsedAmount ELSE 0 END)) as Margin
FROM dbo.Job_ClearHeader AS ch INNER JOIN
dbo.Job_ClearDetail AS cd ON ch.BranchCode = cd.BranchCode 
 AND ch.ClrNo=cd.ClrNo
 INNER JOIN dbo.Job_SrvSingle sv ON cd.SICode=sv.SICode 
 INNER JOIN
 dbo.Job_Order AS j ON cd.BranchCode = j.BranchCode AND cd.JobNo = j.JNo
inner join (
	SELECT CAST(ConfigKey as int) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode='JOB_TYPE'
) jt ON j.JobType=jt.JobType
inner join (
	SELECT CAST(ConfigKey as int) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode='SHIP_BY'
) sb ON j.ShipBy=sb.ShipBy
inner join Mas_Company c
ON j.CustCode=c.CustCode AND j.CustBranch=c.Branch
WHERE (cd.BNet>0) AND       (ch.DocStatus <> 99) AND (j.JobStatus < 90) {0}
GROUP BY j.CSCode, j.JNo, j.DocDate , j.CustCode,j.CustBranch,
jt.JobTypeName,sb.ShipByName,c.NameEng,
j.BookingNo, j.DeclareNumber,j.ConfirmDate,j.DutyDate,j.LoadDate,j.EstDeliverDate,
j.InvNo,j.TotalContainer
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "JOBLOADING"
                        sqlW = GetSQLCommand(cliteria, "j.ETADate", "j.CustCode", "j.JNo", "j.CSCode", "j.AgentCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        sqlM = "
SELECT j.JNo as 'Job Number',j.consigneecode as 'Consignee',j.BookingNo as 'Booking/BL',j.TotalContainer as 'CONTAINER',j.VesselName as 'Vessel/Flight',j.ForwarderCode as 'Agent',
t.TransMode as 'MODE',t.CYPlace + '-' +t.PackingPlace as 'Transport Route',j.ETADate as 'ETA Date',j.ReadyToClearDate as 'Ready Date',j.ShippingEmp as 'Shipping',j.DutyDate as 'Inspection Date'
,j.DeclareStatus,j.EstDeliverDate as 'Delivery Date',t.ReturnDate as 'Demurrage Date',t.FactoryPlace as 'Delivery Place'
FROM Job_Order j LEFT JOIN Job_Loadinfo t
ON j.BranchCode=t.BranchCode and j.JNo=t.JNo
WHERE j.JobStatus<>99 {0}
ORDER BY j.ETADate
"
                        sqlM = String.Format(sqlM, sqlW)
                    Case "VENDSUMMARY"
                        sqlW = GetSQLCommand(cliteria, "b.UnloadFinishDate", "j.CustCode", "j.JNo", "j.CSCode", "h.VenCode", "j.JobStatus", "j.BranchCode")
                        If sqlW <> "" Then sqlW = " AND " & sqlW
                        Dim sqlSub = "
SELECT d.SICode,s.IsExpense,Max(d.SDescription) as Description 
FROM Job_PaymentHeader h INNER JOIN Job_PaymentDetail d 
ON h.BranchCode=d.BranchCode AND h.DocNo=d.DocNo 
INNER JOIN Job_SrvSingle s ON d.SICode=s.SICode 
LEFT JOIN Job_Order j ON d.BranchCode=j.BranchCode AND d.ForJNo=j.JNo
LEFT OUTER JOIN Job_LoadInfoDetail b ON h.BranchCode=b.BranchCode 
AND h.RefNo=b.CTN_NO AND j.BranchCode=b.BranchCode AND j.JNo=b.JNo
WHERE NOT ISNULL(h.CancelProve,'')<>'' 
"
                        sqlSub &= sqlW & " GROUP BY d.SICode,s.IsExpense ORDER BY s.IsExpense DESC,d.SICode"
                        Dim fldSub = ""
                        Dim oSub = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlSub)
                        If oSub.Rows.Count > 0 Then
                            For Each dr As DataRow In oSub.Rows
                                fldSub &= ","
                                fldSub &= "SUM(CASE WHEN d.SICode='" & dr("SICode").ToString & "' THEN d.Amt ELSE 0 END) as '" & dr("Description").ToString & "'"
                            Next
                        End If
                        sqlM = SQLSelectVenderReport(sqlW, fldSub)
                End Select
                Dim oData = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sqlM, True)
                Dim json As String = JsonConvert.SerializeObject(oData)
                Return Content("{""result"":" & json & ",""group"":""" & fldGroup & """,""groupdata"":[" & groupDatas & "],""colwidth"":""" & fldLength & """,""summary"":""" & fldSum & """,""text_field"":""" & fldNoSum & """,""msg"":""OK"",""sql"":""" & sqlW & """}")
            Catch ex As Exception
                Main.SaveLog(My.MySettings.Default.LicenseTo.ToString, appName, "GetReport", ex.Message, ex.StackTrace, True)
                Return Content("{""result"":[],""group"":null,""msg"":""" & ex.Message & """,""sql"":""" & sqlW & """}")
            End Try
        End Function
        Function GetWHTax53Export() As ActionResult
            Dim yy As String = DateTime.Now.Year.ToString("yyyy")
            If Not Request.QueryString("Year") Is Nothing Then
                yy = Request.QueryString("Year").ToString
            End If
            Dim mm As String = DateTime.Now.Month.ToString()
            If Not Request.QueryString("Month") Is Nothing Then
                mm = Request.QueryString("Month").ToString
            End If
            Dim tx As String = ""
            If Not Request.QueryString("Code") Is Nothing Then
                tx = Request.QueryString("Code").ToString
            End If

            Dim strHeader As String = ""
            Dim strDetail As String = ""
            Dim strAll As String = ""
            Dim sqlH = "
select h.TaxNumber1,Convert(numeric,'0'+h.Branch1) as Branch1,h.TaxNumber2,Convert(numeric,'0'+h.Branch2) as Branch2,h.SeqInForm,h.TaxLawNo,
count(distinct d.DocNo) as TotalDoc,SUM(d.PayAmount) as TotalPayAmount,sum(d.PayTax) as TotalPayTax
from Job_WHTax h left join Job_WHTaxDetail d
on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
where h.FormType=7 AND Year(h.DocDate)={0} AND Month(h.DocDate)={1} AND h.TaxNumber1='{2}'
group by h.TaxNumber1,Convert(numeric,'0'+h.Branch1),h.TaxNumber2,Convert(numeric,'0'+h.Branch2),h.SeqInForm,h.TaxLawNo
"
            Dim sqlD = "
select h.DocNo,h.TaxNumber3,Convert(numeric,'0'+h.Branch3) as Branch3,MAX(h.TName3) as TName3,MAX(h.TAddress3) as TAddress3,
d.PayRate,d.PayDate,d.PayTaxDesc,d.DocRefType,
SUM(d.PayAmount) as PayAmount,sum(d.PayTax) as PayTax
from Job_WHTax h left join Job_WHTaxDetail d
on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
where h.FormType=7 AND Year(h.DocDate)={0} AND Month(h.DocDate)={1} AND h.TaxNumber1='{2}'
AND h.TaxNumber2='{3}' AND Convert(numeric,'0'+h.Branch2)={4} AND h.SeqInForm='{5}' AND h.TaxLawNo='{6}'
group by h.DocNo,h.TaxNumber3,Convert(numeric,'0'+h.Branch3),
d.PayRate,d.PayDate,d.PayTaxDesc,d.DocRefType
"
            Dim th = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sqlH, yy, mm, tx))
            For Each rh As DataRow In th.Rows
                strHeader = "H" & "|"   '#1
                strHeader &= "0000" & "|"   '#2
                If rh("TaxNumber2").ToString <> "" Then
                    strHeader &= rh("TaxNumber2").ToString & "|"    '#3
                    strHeader &= CInt("0" & rh("Branch2").ToString).ToString("000000") & "|"    '#4
                    strHeader &= "2" & "|"   '#5
                Else
                    strHeader &= rh("TaxNumber1").ToString & "|"    '#3
                    strHeader &= CInt("0" & rh("Branch1").ToString).ToString("000000") & "|"    '#4
                    strHeader &= "1" & "|"   '#5
                End If
                strHeader &= "PND53" & "|"   '#6
                strHeader &= rh("TaxNumber1").ToString & "|"    '#7
                strHeader &= CInt("0" & rh("Branch1").ToString).ToString("000000") & "|"    '#8
                strHeader &= "แผนกบัญชี" & "|"    '#9
                If CInt("0" & rh("TaxLawNo").ToString) = 1 Then
                    strHeader &= "1" & "|"    '#10
                Else
                    strHeader &= "0" & "|"    '#10
                End If
                If CInt("0" & rh("TaxLawNo").ToString) = 2 Then
                    strHeader &= "1" & "|"    '#11
                Else
                    strHeader &= "0" & "|"    '#11
                End If
                If CInt("0" & rh("TaxLawNo").ToString) = 3 Then
                    strHeader &= "1" & "|"    '#12
                Else
                    strHeader &= "0" & "|"    '#12
                End If
                strHeader &= "0" & "|"    '#13
                strHeader &= CInt("0" & mm).ToString("00") & "|"    '#14
                strHeader &= CInt("0" & yy).ToString("0000") + 543 & "|"    '#15
                strHeader &= "V" & "|"    '#16                
                strHeader &= CInt("0" & rh("SeqInForm").ToString).ToString("00") & "|"    '#17
                strHeader &= rh("TotalDoc") & "|"    '#18
                strHeader &= rh("TotalPayAmount") & "|"    '#19
                strHeader &= rh("TotalPayTax") & "|"    '#20
                strHeader &= "0.00" & "|"    '#21
                strHeader &= rh("TotalPayTax") & "|"    '#22
                strHeader &= "0.00" & "|"    '#23
                strHeader &= Main.GetValueConfig("PROFILE", "TAX_REGISTER_ID") & "|"    '#24
                strHeader &= "2" & "|"    '#25
                strHeader &= vbCrLf

                strDetail = ""
                Dim lastDoc = ""
                Dim lastAddr = ""

                Dim rc As Integer = 0
                Dim ic As Integer = 0
                Dim td = New CUtil(GetSession("ConnJob")).GetTableFromSQL(String.Format(sqlD, yy, mm, tx, rh("TaxNumber2").ToString, rh("Branch2").ToString, rh("SeqInForm").ToString, rh("TaxLawNo").ToString))
                For Each rd As DataRow In td.Rows
                    If lastDoc <> rd("DocNo").ToString Then
                        If ic = 1 Then
                            strDetail &= "00000000|"    '#15
                            strDetail &= "|"    '#16
                            strDetail &= "|"    '#17
                            strDetail &= "|"    '#18
                            strDetail &= "|"    '#19
                            strDetail &= "|"    '#20

                            strDetail &= "00000000|"    '#21
                            strDetail &= "|"    '#22
                            strDetail &= "|"    '#23
                            strDetail &= "|"    '#24
                            strDetail &= "|"    '#25
                            strDetail &= "|"    '#26
                        End If
                        If ic = 2 Then
                            strDetail &= "00000000|"    '#21
                            strDetail &= "|"    '#22
                            strDetail &= "|"    '#23
                            strDetail &= "|"    '#24
                            strDetail &= "|"    '#25
                            strDetail &= "|"    '#26
                        End If
                        strDetail &= "|"    '#27
                        strDetail &= "|"    '#28
                        strDetail &= "|"    '#29
                        strDetail &= lastAddr & "|"    '#30
                        strDetail &= "|"    '#31
                        strDetail &= "|"    '#32
                        strDetail &= "|"    '#33
                        strDetail &= "|"    '#34
                        strDetail &= "|"    '#35
                        strDetail &= "|"    '#36
                        strDetail &= "|"    '#37
                        strDetail &= "|"    '#38

                        lastDoc = rd("DocNo").ToString
                        lastAddr = rd("TAddress3").ToString
                        ic = 0
                        rc += 1
                        If rc > 1 Then
                            strDetail &= vbCrLf
                        End If
                        strDetail &= "D" & "|"  '#1
                        strDetail &= rc & "|"  '#2
                        strDetail &= CInt("0" & rd("Branch3").ToString).ToString("000000") & "|"    '#3
                        If rd("TaxNumber3").ToString.Length = 13 Then
                            strDetail &= CInt("0" & rd("TaxNumber3").ToString).ToString("000000") & "|"    '#4
                        Else
                            strDetail &= "|"    '#4
                        End If
                        If rd("TaxNumber3").ToString.Length < 13 Then
                            strDetail &= CInt("0" & rd("TaxNumber3").ToString).ToString("000000") & "|"    '#5
                        Else
                            strDetail &= "|"    '#5
                        End If
                        strDetail &= "|"    '#6
                        strDetail &= rd("TName3").ToString() & "|"    '#7
                        strDetail &= "|"    '#8
                    End If
                    ic += 1
                    If ic = 1 Then
                        strDetail &= CDate(rd("PayDate").ToString()).AddYears(543).ToString("ddMMyyyy") & "|"    '#9
                        strDetail &= rd("PayRate").ToString() & "|"    '#10
                        strDetail &= rd("PayAmount").ToString() & "|"    '#11
                        strDetail &= rd("PayTax").ToString() & "|"    '#12
                        strDetail &= rd("PayTaxDesc").ToString() & "|"    '#13
                        strDetail &= rd("DocRefType").ToString() & "|"    '#14
                    End If
                    If ic = 2 Then
                        strDetail &= CDate(rd("PayDate").ToString()).AddYears(543).ToString("ddMMyyyy") & "|"    '#15
                        strDetail &= rd("PayRate").ToString() & "|"    '#16
                        strDetail &= rd("PayAmount").ToString() & "|"    '#17
                        strDetail &= rd("PayTax").ToString() & "|"    '#18
                        strDetail &= rd("PayTaxDesc").ToString() & "|"    '#19
                        strDetail &= rd("DocRefType").ToString() & "|"    '#20
                    End If
                    If ic = 3 Then
                        strDetail &= CDate(rd("PayDate").ToString()).AddYears(543).ToString("ddMMyyyy") & "|"    '#21
                        strDetail &= rd("PayRate").ToString() & "|"    '#22
                        strDetail &= rd("PayAmount").ToString() & "|"    '#23
                        strDetail &= rd("PayTax").ToString() & "|"    '#24
                        strDetail &= rd("PayTaxDesc").ToString() & "|"    '#25
                        strDetail &= rd("DocRefType").ToString() & "|"    '#26
                    End If
                Next
                If ic = 1 Then
                    strDetail &= "00000000|"    '#15
                    strDetail &= "|"    '#16
                    strDetail &= "|"    '#17
                    strDetail &= "|"    '#18
                    strDetail &= "|"    '#19
                    strDetail &= "|"    '#20

                    strDetail &= "00000000|"    '#21
                    strDetail &= "|"    '#22
                    strDetail &= "|"    '#23
                    strDetail &= "|"    '#24
                    strDetail &= "|"    '#25
                    strDetail &= "|"    '#26
                End If
                If ic = 2 Then
                    strDetail &= "00000000|"    '#21
                    strDetail &= "|"    '#22
                    strDetail &= "|"    '#23
                    strDetail &= "|"    '#24
                    strDetail &= "|"    '#25
                    strDetail &= "|"    '#26
                End If
                strDetail &= "|"    '#27
                strDetail &= "|"    '#28
                strDetail &= "|"    '#29
                strDetail &= lastAddr & "|"    '#30
                strDetail &= "|"    '#31
                strDetail &= "|"    '#32
                strDetail &= "|"    '#33
                strDetail &= "|"    '#34
                strDetail &= "|"    '#35
                strDetail &= "|"    '#36
                strDetail &= "|"    '#37
                strDetail &= "|"    '#38

                If strAll <> "" Then
                    strAll &= vbCrLf
                End If
                strAll &= strHeader & strDetail
            Next

            Return Content(strAll, textContent)
        End Function
        Function TruckProfit() As ActionResult
            Dim sql As String = GetValueConfig("SQL", "SelectCostByLoading")
            Dim sqlW As String = " "

            If Not IsNothing(Request.QueryString("Branch")) Then
                sqlW &= String.Format(" AND j.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("Job")) Then
                sqlW &= String.Format(" AND j.JNo='{0}' ", Request.QueryString("Job").ToString)
            End If
            If Not IsNothing(Request.QueryString("HBL")) Then
                sqlW &= String.Format(" AND j.HAWB='{0}' ", Request.QueryString("HBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("MBL")) Then
                sqlW &= String.Format(" AND j.MAWB='{0}' ", Request.QueryString("MBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("JobType")) Then
                sqlW &= String.Format(" AND j.JobType={0} ", Request.QueryString("JobType").ToString)
            End If
            If Not IsNothing(Request.QueryString("ShipBy")) Then
                sqlW &= String.Format(" AND j.ShipBy={0} ", Request.QueryString("ShipBy").ToString)
            End If
            If Not IsNothing(Request.QueryString("Agent")) Then
                sqlW &= String.Format(" AND j.ForwarderCode='{0}' ", Request.QueryString("Agent").ToString)
            End If
            If Not IsNothing(Request.QueryString("Transport")) Then
                sqlW &= String.Format(" AND j.AgentCode='{0}' ", Request.QueryString("Transport").ToString)
            End If
            Dim dateBy As String = "a.DutyDate"
            If Not IsNothing(Request.QueryString("DateBy")) Then
                dateBy = Request.QueryString("DateBy")
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                sqlW &= " AND " & dateBy & ">='" & Request.QueryString("DateFrom") & " 00:00:00'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                sqlW &= " AND " & dateBy & "<='" & Request.QueryString("DateTo") & " 23:59:00'"
            End If
            If Not IsNothing(Request.QueryString("Status")) Then
                sqlW &= String.Format(" AND j.JobStatus={0} ", Request.QueryString("Status").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cust")) Then
                sqlW &= String.Format(" AND j.CustCode='{0}' ", Request.QueryString("Cust").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cons")) Then
                sqlW &= String.Format(" AND j.consigneecode='{0}' ", Request.QueryString("Cons").ToString)
            End If
            If Not IsNothing(Request.QueryString("Shipping")) Then
                sqlW &= String.Format(" AND j.ShippingEmp='{0}' ", Request.QueryString("Shipping").ToString)
            End If
            If Not IsNothing(Request.QueryString("CS")) Then
                sqlW &= String.Format(" AND j.CSCode='{0}' ", Request.QueryString("CS").ToString)
            End If
            sql = sql.Replace("{0}", sqlW)

            Dim dt = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
            ViewBag.DataTable = dt
            Return GetView("TruckProfit")
        End Function
        Function TruckProfitDetail() As ActionResult
            Dim sql As String = GetValueConfig("SQL", "SelectCostByLoading")
            Dim sqlW As String = " "

            If Not IsNothing(Request.QueryString("Branch")) Then
                sqlW &= String.Format(" AND j.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("Job")) Then
                sqlW &= String.Format(" AND j.JNo='{0}' ", Request.QueryString("Job").ToString)
            End If
            If Not IsNothing(Request.QueryString("HBL")) Then
                sqlW &= String.Format(" AND j.HAWB='{0}' ", Request.QueryString("HBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("MBL")) Then
                sqlW &= String.Format(" AND j.MAWB='{0}' ", Request.QueryString("MBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("JobType")) Then
                sqlW &= String.Format(" AND j.JobType={0} ", Request.QueryString("JobType").ToString)
            End If
            If Not IsNothing(Request.QueryString("ShipBy")) Then
                sqlW &= String.Format(" AND j.ShipBy={0} ", Request.QueryString("ShipBy").ToString)
            End If
            If Not IsNothing(Request.QueryString("Agent")) Then
                sqlW &= String.Format(" AND j.ForwarderCode='{0}' ", Request.QueryString("Agent").ToString)
            End If
            If Not IsNothing(Request.QueryString("Transport")) Then
                sqlW &= String.Format(" AND j.AgentCode='{0}' ", Request.QueryString("Transport").ToString)
            End If
            Dim dateBy As String = "a.DutyDate"
            If Not IsNothing(Request.QueryString("DateBy")) Then
                dateBy = Request.QueryString("DateBy")
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                sqlW &= " AND " & dateBy & ">='" & Request.QueryString("DateFrom") & " 00:00:00'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                sqlW &= " AND " & dateBy & "<='" & Request.QueryString("DateTo") & " 23:59:00'"
            End If
            If Not IsNothing(Request.QueryString("Status")) Then
                sqlW &= String.Format(" AND j.JobStatus={0} ", Request.QueryString("Status").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cust")) Then
                sqlW &= String.Format(" AND j.CustCode='{0}' ", Request.QueryString("Cust").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cons")) Then
                sqlW &= String.Format(" AND j.consigneecode='{0}' ", Request.QueryString("Cons").ToString)
            End If
            If Not IsNothing(Request.QueryString("Shipping")) Then
                sqlW &= String.Format(" AND j.ShippingEmp='{0}' ", Request.QueryString("Shipping").ToString)
            End If
            If Not IsNothing(Request.QueryString("CS")) Then
                sqlW &= String.Format(" AND j.CSCode='{0}' ", Request.QueryString("CS").ToString)
            End If
            sql = sql.Replace("{0}", sqlW)

            Dim dt = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
            ViewBag.DataTable = dt
            Return GetView("TruckProfitDetail")
        End Function

        Function KITProfitDetail() As ActionResult
            Dim sql As String = GetValueConfig("SQL", "SelectCostByLoading")
            Dim sqlW As String = " "

            If Not IsNothing(Request.QueryString("Branch")) Then
                sqlW &= String.Format(" AND j.BranchCode='{0}' ", Request.QueryString("Branch").ToString)
            End If
            If Not IsNothing(Request.QueryString("Job")) Then
                sqlW &= String.Format(" AND j.JNo='{0}' ", Request.QueryString("Job").ToString)
            End If
            If Not IsNothing(Request.QueryString("HBL")) Then
                sqlW &= String.Format(" AND j.HAWB='{0}' ", Request.QueryString("HBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("MBL")) Then
                sqlW &= String.Format(" AND j.MAWB='{0}' ", Request.QueryString("MBL").ToString)
            End If
            If Not IsNothing(Request.QueryString("JobType")) Then
                sqlW &= String.Format(" AND j.JobType={0} ", Request.QueryString("JobType").ToString)
            End If
            If Not IsNothing(Request.QueryString("ShipBy")) Then
                sqlW &= String.Format(" AND j.ShipBy={0} ", Request.QueryString("ShipBy").ToString)
            End If
            If Not IsNothing(Request.QueryString("Agent")) Then
                sqlW &= String.Format(" AND j.ForwarderCode='{0}' ", Request.QueryString("Agent").ToString)
            End If
            If Not IsNothing(Request.QueryString("Transport")) Then
                sqlW &= String.Format(" AND j.AgentCode='{0}' ", Request.QueryString("Transport").ToString)
            End If
            Dim dateBy As String = "a.DutyDate"
            If Not IsNothing(Request.QueryString("DateBy")) Then
                dateBy = Request.QueryString("DateBy")
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                sqlW &= " AND " & dateBy & ">='" & Request.QueryString("DateFrom") & " 00:00:00'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                sqlW &= " AND " & dateBy & "<='" & Request.QueryString("DateTo") & " 23:59:00'"
            End If
            If Not IsNothing(Request.QueryString("Status")) Then
                sqlW &= String.Format(" AND j.JobStatus={0} ", Request.QueryString("Status").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cust")) Then
                sqlW &= String.Format(" AND j.CustCode='{0}' ", Request.QueryString("Cust").ToString)
            End If
            If Not IsNothing(Request.QueryString("Cons")) Then
                sqlW &= String.Format(" AND j.consigneecode='{0}' ", Request.QueryString("Cons").ToString)
            End If
            If Not IsNothing(Request.QueryString("Shipping")) Then
                sqlW &= String.Format(" AND j.ShippingEmp='{0}' ", Request.QueryString("Shipping").ToString)
            End If
            If Not IsNothing(Request.QueryString("CS")) Then
                sqlW &= String.Format(" AND j.CSCode='{0}' ", Request.QueryString("CS").ToString)
            End If
            sql = sql.Replace("{0}", sqlW)

            Dim dt = New CUtil(GetSession("ConnJob")).GetTableFromSQL(sql)
            ViewBag.DataTable = dt
            Return GetView("KITProfitDetail")
        End Function
    End Class
End Namespace