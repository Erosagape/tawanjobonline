Imports System.Web.Mvc
Imports System.Web.Http
Imports Newtonsoft.Json
Namespace Controllers
    Public Class DefaultController
        Inherits CController

        ' GET: Default
        Function Index() As ActionResult
            Return View()
        End Function
        Function TestTracking() As ActionResult
            Return View()
        End Function

        Function TestDate(<FromBody()> ByVal data As CTestDate) As ActionResult
            data.DocDate = Main.GetDBDate(data.DocDate)
            Dim json = JsonConvert.SerializeObject(data)
            Return Content(json, jsonContent)
        End Function
        Function TestQR() As ActionResult
            Return GetView("TestQR")
        End Function
        Function TestCanvas() As ActionResult
            Return GetView("TestCanvas")
        End Function
        Function PostCanvas(<FromBody()> dataImage As String) As ActionResult
            Dim str = dataImage.Split(";")
            Dim fileName = ""
            If Request.QueryString("ID") IsNot Nothing Then
                fileName = Request.QueryString("ID").ToString()
            End If
            Dim msg = "Cannot Process Data"
            If str.Length = 2 And fileName <> "" Then
                If str(1).IndexOf(",") > 0 Then
                    Dim imgArr = str(1).Split(",")
                    Try
                        System.IO.File.WriteAllBytes(Server.MapPath("~/Resource/Import") + "/" & fileName & ".png", Convert.FromBase64String(imgArr(1)))
                        msg = "Save Completed!"
                    Catch ex As Exception
                        msg = ex.Message
                    End Try
                End If
            End If
            Return Content(msg, "text/html")
        End Function

    End Class
End Namespace