Imports System.Web.Mvc
Imports System.Data.OleDb
Namespace Controllers
    Public Class ExcelController
        Inherits Controller

        ' GET: Excel
        Function Index() As ActionResult
            Return View()
        End Function
        Function Import() As ActionResult
            ViewBag.FileList = GetExcelFiles()
            Return View()
        End Function
        Function ReadExcelFile() As ActionResult
            If Request.QueryString("ID") IsNot Nothing Then
                Dim filename = Request.QueryString("ID").ToString
                Dim path = System.IO.Path.Combine(Server.MapPath("~/Resource/Import"), filename)
                If System.IO.File.Exists(path) Then
                    Return Content(filename + " is found")
                Else
                    Return Content(filename + " is not found")
                End If
            Else
                Return Content("File name not found", textContent)
            End If
        End Function
        Function UploadExcelFile() As ActionResult
            Dim msg As String = ""
            Dim exts As String = ".xlsx, .xls"

            Try
                For Each fileIdx As String In Request.Files
                    Dim File As HttpPostedFileBase = Request.Files.Item(fileIdx)
                    Dim filename = System.IO.Path.GetFileName(File.FileName)
                    If File.ContentLength > 0 Then
                        If exts.IndexOf(System.IO.Path.GetExtension(filename).ToLower) >= 0 Then
                            Try
                                If System.IO.Directory.Exists(Server.MapPath("~/Resource/Import")) = False Then
                                    IO.Directory.CreateDirectory(Server.MapPath("~/Resource/Import"))
                                End If
                                Dim path = System.IO.Path.Combine(Server.MapPath("~/Resource/Import"), filename)
                                File.SaveAs(path)
                                msg = msg + "Upload " + filename + " successfully" + vbCrLf
                            Catch ex As Exception
                                msg = msg + "[Error] " + filename + "=>" + ex.Message + vbCrLf
                            End Try
                        Else
                            msg = msg + "[Error] " + filename + " Is Not allowed to upload" + vbCrLf
                        End If
                    Else
                        msg = msg + "[Error] " + filename + " cannot upload" + vbCrLf
                    End If
                Next
            Catch e As Exception
                msg = "[Error] " + e.Message
            End Try
            If msg = "" Then msg = "[Error] No File To Upload"
            Return Content(msg, textContent)
        End Function
        Private Function GetExcelFiles() As List(Of String)
            Dim lst As New List(Of String)
            Dim files As New System.IO.DirectoryInfo(Server.MapPath("~/Resource/Import"))
            For Each file As System.IO.FileInfo In files.GetFiles("*.xls*", IO.SearchOption.TopDirectoryOnly)
                lst.Add(file.Name)
            Next
            Return lst
        End Function
        <HttpPost>
        <ActionName("Index")>
        Function Index_Post() As ActionResult
            Dim tbName = "Job_Order"
            If Request.QueryString("ID") IsNot Nothing Then
                tbName = Request.QueryString("ID").ToString()
            End If
            Dim oTable = New CUtil(GetSession("ConnJob")).GetTableFromSQL("SELECT * FROM " + tbName)
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
            Response.AddHeader("content-disposition", "attachment;filename=" + tbName + ".xls")
            Response.Write(sb.ToString())
            Response.End()

            Return View()
        End Function
    End Class
End Namespace