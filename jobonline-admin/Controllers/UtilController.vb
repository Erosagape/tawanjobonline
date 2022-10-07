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
            Dim str As String = ""
            If System.IO.File.Exists(fileName) Then
                Dim oDataConfig = ReadExcelFromFile(fileName, "Config$")
                If oDataConfig.Rows.Count > 0 Then
                    Dim tbHeaderName As String = ""
                    Dim tbDetailName As String = ""
                    Dim tbHeaderKeys As List(Of String) = New List(Of String)
                    Dim tbDetailKeys As List(Of String) = New List(Of String)
                    Dim tbHeaderFields As List(Of String) = New List(Of String)
                    Dim tbDetailFields As List(Of String) = New List(Of String)
                    Dim sqlHeader As String = "SELECT * FROM {0} WHERE {1}"
                    Dim sqlDetail As String = "SELECT * FROM {0} WHERE {1}"
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
                            tbHeaderFields.Add(dr(1).ToString())
                        End If
                        If dr(0).ToString().Contains("Detail_Field") Then
                            tbDetailFields.Add(dr(1).ToString())
                        End If
                    Next
                    sqlHeader = String.Format(sqlHeader, tbHeaderName)
                    For Each fld As String In tbHeaderKeys
                        If sqlWhereHeader <> "" Then
                            sqlWhereHeader &= " AND "
                        End If
                        sqlWhereHeader &= " " & fld & "=''"
                    Next
                    sqlDetail = String.Format(sqlDetail, tbDetailName)
                    For Each fld As String In tbDetailKeys

                    Next
                Else
                    str = "Config sheet Not found in file"
                End If
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