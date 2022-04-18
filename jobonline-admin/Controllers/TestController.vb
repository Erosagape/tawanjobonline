Imports System.Web.Mvc

Namespace Controllers
    Public Class TestController
        Inherits Controller

        ' GET: Test
        Function Index() As ActionResult
            Return View()
        End Function
        Function ExcelReader() As ActionResult
            If Not System.IO.Directory.Exists(Server.MapPath("~/Resources")) Then
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Resources"))
            End If
            ViewBag.Message = "Ready"
            ViewBag.Data = Nothing
            Return View()
        End Function
        <HttpPost>
        Function ExcelReader(fileUpload As HttpPostedFileBase) As ActionResult
            Try
                If fileUpload.ContentLength > 0 Then
                    If Not System.IO.Directory.Exists(Server.MapPath("~/Resources")) Then
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Resources"))
                    End If
                    Dim savePath As String = System.IO.Path.Combine(Server.MapPath("~/Resources"), System.IO.Path.GetFileName(fileUpload.FileName))
                    If System.IO.File.Exists(savePath) Then
                        System.IO.File.Delete(savePath)
                    End If
                    fileUpload.SaveAs(savePath)
                    ViewBag.Data = ReadExcelFromFile(savePath)
                    ViewBag.Message = "Upload " & fileUpload.FileName & " Complete"
                Else
                    ViewBag.Message = "You must select some file"
                End If
            Catch ex As Exception
                ViewBag.Message = ex.Message
            End Try
            Return View()
        End Function
        <HttpPost()>
        <ActionName("PostForm")>
        Function PostFormSubmit() As ActionResult
            Dim value = Request.Form("text1")
            ViewBag.Result = "Value=" & value
            Return View("PostForm")
        End Function
        Function PostForm() As ActionResult
            ViewBag.Result = "Ready"
            Return View()
        End Function
    End Class
End Namespace