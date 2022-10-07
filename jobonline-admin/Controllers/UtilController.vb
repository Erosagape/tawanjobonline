Imports System.Web.Mvc
Imports Newtonsoft.Json
Namespace Controllers
    Public Class UtilController
        Inherits CController

        ' GET: Util
        Function Index() As ActionResult
            Return View()
        End Function
        Function Excel() As ActionResult
            Dim directoryPath = Server.MapPath("~") & "/Resources/Import/"
            Dim list As New List(Of String)
            Dim files = New IO.DirectoryInfo(directoryPath).GetFiles("*.xls*")
            For Each file As System.IO.FileInfo In files
                list.Add(file.Name)
            Next
            ViewBag.FileList = list
            Return GetView("Excel")
        End Function
        <HttpPost()>
        <ActionName("Excel")>
        Function PostExcel(xlsFiles As HttpPostedFileBase) As ActionResult
            Dim msg = ""
            Try
                If xlsFiles.ContentLength > 0 Then
                    Dim files = xlsFiles
                    Dim fname = Server.MapPath("~") & "/Resources/Import/" + files.FileName
                    If System.IO.File.Exists(fname) Then
                        System.IO.File.Delete(fname)
                    End If
                    files.SaveAs(fname)
                    If System.IO.File.Exists(fname) Then
                        msg = "Uploaded " + files.FileName + " Complete"
                    End If
                Else
                    msg = "No file sent"
                End If
            Catch ex As Exception
                msg = ex.Message
            End Try
            Return Content(msg, textContent)
        End Function
        Function ExcelImport() As ActionResult
            Dim fileName As String = Server.MapPath("~") & "/Resources/Import/" & Request.QueryString("FileName")
            Dim databaseName As String = Request.QueryString("DatabaseName")
            Dim sheetName As String = Request.QueryString("SheetName")
            Dim str As String = ""
            If System.IO.File.Exists(fileName) Then
                Try
                    Using oDataConfig = ReadExcelFromFile(fileName, "Config$")
                        If oDataConfig.Rows.Count > 0 Then
                            Dim tbName As String = ""
                            Dim tbKeys As List(Of String) = New List(Of String)
                            Dim tbFields As New List(Of KeyValuePair(Of String, String))
                            Dim sql As String = "SELECT * FROM {0} "
                            Dim sqlWhere As String = ""
                            For Each dr As DataRow In oDataConfig.Rows
                                If dr(0).ToString() = "Table" Then
                                    tbName = dr(1).ToString()
                                End If
                                If dr(0).ToString().Contains("Key") Then
                                    tbKeys.Add(dr(1).ToString())
                                End If
                                If dr(0).ToString().Contains("Field") Then
                                    tbFields.Add(New KeyValuePair(Of String, String)(dr(0).ToString().Replace("Field", ""), dr(1).ToString()))
                                End If
                            Next
                            sql = String.Format(sql, tbName)
                            Dim i = 0
                            For Each fld As String In tbKeys
                                If sqlWhere <> "" Then
                                    sqlWhere &= " AND "
                                End If
                                sqlWhere &= " " & fld & "='{" & i & "}'"
                                i += 1
                            Next
                            sql &= " WHERE " & sqlWhere

                            Dim sqlConn = My.Settings.weblicenseConnection.Replace("weblicense", databaseName)
                            Dim dataHeader As String = ""
                            Dim dataDetail As String = ""
                            Dim rowHeader = 0
                            Dim rowDetail = 0
                            Using cn As New SqlClient.SqlConnection(sqlConn)
                                cn.Open()
                                If cn.State = ConnectionState.Open Then

                                    Using oDataHeader = ReadExcelFromFile(fileName, sheetName & "$")
                                        If oDataHeader.Rows.Count > 0 Then
                                            For Each dh As DataRow In oDataHeader.Rows
                                                Dim sqlTemp = sql
                                                i = 0
                                                For Each pk In tbKeys
                                                    Dim idxKey = tbFields.Find(Function(o) o.Value.Equals(pk)).Key
                                                    If idxKey <> "" Then
                                                        Dim idx = Convert.ToInt32(idxKey) - 1
                                                        Dim val = dh(idx).ToString()
                                                        If val <> "" Then
                                                            sqlTemp = sqlTemp.Replace("{" & i & "}", val)
                                                            i += 1
                                                        End If
                                                    End If
                                                Next
                                                If i <> tbKeys.Count Then
                                                    Continue For
                                                End If
                                                Using da As New SqlClient.SqlDataAdapter(sqlTemp, cn)
                                                    Using cb As New SqlClient.SqlCommandBuilder(da)
                                                        Using dt As New DataTable
                                                            da.Fill(dt)
                                                            Dim dr As DataRow = dt.NewRow
                                                            If dt.Rows.Count > 0 Then
                                                                dr = dt.Rows(0)
                                                            End If
                                                            For Each col In tbFields
                                                                Try
                                                                    Dim idx = Convert.ToInt32(col.Key) - 1
                                                                    dr(col.Value) = dh(idx)
                                                                Catch ex As Exception
                                                                End Try
                                                            Next
                                                            If dr.RowState = DataRowState.Detached Then
                                                                dt.Rows.Add(dr)
                                                            End If
                                                            If da.Update(dt) > 0 Then
                                                                If dataHeader <> "" Then
                                                                    dataHeader &= ","
                                                                End If
                                                                dataHeader &= JsonConvert.SerializeObject(dt)
                                                                rowHeader += 1
                                                            End If
                                                        End Using
                                                    End Using
                                                End Using
                                            Next
                                        End If
                                    End Using
                                End If
                                cn.Close()
                            End Using
                            str = "{""msg"":""Total =" & rowHeader & """,""sql"":""" & sql & """,""data"":[" & dataHeader & "]}"
                        Else
                            str = "{""msg"":""Config sheet Not found in file""}"
                        End If
                    End Using
                Catch ex As Exception
                    str = "{""msg"":""" & ex.Message & """}"
                End Try
            End If
            Return Content(str, jsonContent)
        End Function
        Function ExcelImportHeaderDetail() As ActionResult
            Dim fileName As String = Server.MapPath("~") & "/Resources/Import/" & Request.QueryString("FileName")
            Dim databaseName As String = Request.QueryString("DatabaseName")
            Dim str As String = ""
            If System.IO.File.Exists(fileName) Then
                Try
                    Using oDataConfig = ReadExcelFromFile(fileName, "Config$")
                        If oDataConfig.Rows.Count > 0 Then
                            Dim tbHeaderName As String = ""
                            Dim tbDetailName As String = ""
                            Dim tbHeaderKeys As List(Of String) = New List(Of String)
                            Dim tbDetailKeys As List(Of String) = New List(Of String)
                            Dim tbHeaderFields As New List(Of KeyValuePair(Of String, String))
                            Dim tbDetailFields As New List(Of KeyValuePair(Of String, String))
                            Dim sqlHeader As String = "SELECT * FROM {0} "
                            Dim sqlDetail As String = "SELECT * FROM {0} "
                            Dim sqlWhereHeader As String = ""
                            Dim sqlWhereDetail As String = ""
                            For Each dr As DataRow In oDataConfig.Rows
                                If dr(0).ToString() = "Header_Table" Then
                                    tbHeaderName = dr(1).ToString()
                                End If
                                If dr(0).ToString() = "Detail_Table" Then
                                    tbDetailName = dr(1).ToString()
                                End If
                                If dr(0).ToString().Contains("Header_Key") Then
                                    tbHeaderKeys.Add(dr(1).ToString())
                                End If
                                If dr(0).ToString().Contains("Detail_Key") Then
                                    tbDetailKeys.Add(dr(1).ToString())
                                End If
                                If dr(0).ToString().Contains("Header_Field") Then
                                    tbHeaderFields.Add(New KeyValuePair(Of String, String)(dr(0).ToString().Replace("Header_Field", ""), dr(1).ToString()))
                                End If
                                If dr(0).ToString().Contains("Detail_Field") Then
                                    tbDetailFields.Add(New KeyValuePair(Of String, String)(dr(0).ToString().Replace("Detail_Field", ""), dr(1).ToString()))
                                End If
                            Next
                            sqlHeader = String.Format(sqlHeader, tbHeaderName)
                            Dim i = 0
                            For Each fld As String In tbHeaderKeys
                                If sqlWhereHeader <> "" Then
                                    sqlWhereHeader &= " AND "
                                End If
                                sqlWhereHeader &= " " & fld & "='{" & i & "}'"
                                i += 1
                            Next
                            sqlHeader &= " WHERE " & sqlWhereHeader

                            sqlDetail = String.Format(sqlDetail, tbDetailName)
                            i = 0
                            For Each fld As String In tbDetailKeys
                                If sqlWhereDetail <> "" Then
                                    sqlWhereDetail &= " AND "
                                End If
                                sqlWhereDetail &= " " & fld & "='{" & i & "}'"
                                i += 1
                            Next
                            sqlDetail &= " WHERE " & sqlWhereDetail

                            Dim sqlConn = My.Settings.weblicenseConnection.Replace("weblicense", databaseName)
                            Dim dataHeader As String = ""
                            Dim dataDetail As String = ""
                            Dim rowHeader = 0
                            Dim rowDetail = 0
                            Using cn As New SqlClient.SqlConnection(sqlConn)
                                cn.Open()
                                If cn.State = ConnectionState.Open Then

                                    Using oDataHeader = ReadExcelFromFile(fileName, "Header$")
                                        If oDataHeader.Rows.Count > 0 Then
                                            For Each dh As DataRow In oDataHeader.Rows
                                                Dim sqlTemp = sqlHeader
                                                i = 0
                                                For Each pk In tbHeaderKeys
                                                    Dim idxKey = tbHeaderFields.Find(Function(o) o.Value.Equals(pk)).Key
                                                    If idxKey <> "" Then
                                                        Dim idx = Convert.ToInt32(idxKey) - 1
                                                        Dim val = dh(idx).ToString()
                                                        If val <> "" Then
                                                            sqlTemp = sqlTemp.Replace("{" & i & "}", val)
                                                            i += 1
                                                        End If
                                                    End If
                                                Next
                                                If i <> tbHeaderKeys.Count Then
                                                    Continue For
                                                End If
                                                Using da As New SqlClient.SqlDataAdapter(sqlTemp, cn)
                                                    Using cb As New SqlClient.SqlCommandBuilder(da)
                                                        Using dt As New DataTable
                                                            da.Fill(dt)
                                                            Dim dr As DataRow = dt.NewRow
                                                            If dt.Rows.Count > 0 Then
                                                                dr = dt.Rows(0)
                                                            End If
                                                            For Each col In tbHeaderFields
                                                                Try
                                                                    Dim idx = Convert.ToInt32(col.Key) - 1
                                                                    dr(col.Value) = dh(idx)
                                                                Catch ex As Exception
                                                                End Try
                                                            Next
                                                            If dr.RowState = DataRowState.Detached Then
                                                                dt.Rows.Add(dr)
                                                            End If
                                                            If da.Update(dt) > 0 Then
                                                                If dataHeader <> "" Then
                                                                    dataHeader &= ","
                                                                End If
                                                                dataHeader &= JsonConvert.SerializeObject(dt)
                                                                rowHeader += 1
                                                            End If
                                                        End Using
                                                    End Using
                                                End Using
                                            Next
                                        End If
                                    End Using

                                    Using oDataDetail = ReadExcelFromFile(fileName, "Detail$")
                                        If oDataDetail.Rows.Count > 0 Then
                                            For Each dh As DataRow In oDataDetail.Rows
                                                Dim sqlTemp = sqlDetail
                                                i = 0
                                                For Each pk In tbDetailKeys
                                                    Dim idxKey = tbDetailFields.Find(Function(o) o.Value.Equals(pk)).Key
                                                    If idxKey <> "" Then
                                                        Dim idx = Convert.ToInt32(idxKey) - 1
                                                        Dim val = dh(idx).ToString()
                                                        If val <> "" Then
                                                            sqlTemp = sqlTemp.Replace("{" & i & "}", val)
                                                            i += 1
                                                        End If
                                                    End If
                                                Next
                                                If i <> tbDetailKeys.Count Then
                                                    Continue For
                                                End If
                                                Using da As New SqlClient.SqlDataAdapter(sqlTemp, cn)
                                                    Using cb As New SqlClient.SqlCommandBuilder(da)
                                                        Using dt As New DataTable
                                                            da.Fill(dt)
                                                            Dim dr As DataRow = dt.NewRow
                                                            If dt.Rows.Count > 0 Then
                                                                dr = dt.Rows(0)
                                                            End If
                                                            For Each col In tbDetailFields
                                                                Try
                                                                    Dim idx = Convert.ToInt32(col.Key) - 1
                                                                    dr(col.Value) = dh(idx)
                                                                Catch ex As Exception
                                                                End Try
                                                            Next
                                                            If dr.RowState = DataRowState.Detached Then
                                                                dt.Rows.Add(dr)
                                                            End If
                                                            If da.Update(dt) > 0 Then
                                                                If dataDetail <> "" Then
                                                                    dataDetail &= ","
                                                                End If
                                                                dataDetail &= JsonConvert.SerializeObject(dt)
                                                                rowDetail += 1
                                                            End If
                                                        End Using
                                                    End Using
                                                End Using
                                            Next
                                        End If
                                    End Using
                                End If
                                cn.Close()
                            End Using

                            str = "{""msg"":""Header =" & rowHeader & ",Detail =" & rowDetail & """,""sqlheader"":""" & sqlHeader & """,""sqldetail"":""" & sqlDetail & """,""header"":[" & dataHeader & "],""detail"":[" & dataDetail & "]}"

                        Else
                            str = "{""msg"":""Config sheet Not found in file""}"
                        End If
                    End Using
                Catch ex As Exception
                    str = "{""msg"":""" & ex.Message & """}"
                End Try
            End If
            Return Content(str, jsonContent)
        End Function
        Function ExcelReader() As ActionResult
            Dim fileName As String = Server.MapPath("~") & "/Resources/Import/" & Request.QueryString("FileName")
            Dim sheetName As String = Request.QueryString("SheetName")
            Dim str As String = "[]"
            If System.IO.File.Exists(fileName) Then
                Dim oData = ReadExcelFromFile(fileName, sheetName)
                str = JsonConvert.SerializeObject(oData)
            End If
            Return Content(str, jsonContent)
        End Function
    End Class
End Namespace