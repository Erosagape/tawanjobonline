Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class AdminController
        Inherits CController

        ' GET: Admin
        Function Index() As ActionResult
            Return GetView("Index")
        End Function
        Function GetLog() As ActionResult
            Dim json = "{""data"":[{0}],""message"":""{1}""}"
            Dim msg = "Complete"
            Dim data = ""
            Try
                Dim o = New CLog(ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString).GetData(" WHERE CustID='" & My.MySettings.Default.LicenseTo.ToString & "'")
                data = JsonConvert.SerializeObject(o)
            Catch ex As Exception
                msg = "[ERROR]:" & ex.StackTrace
            End Try
            Return Content(String.Format(json, data, msg), jsonContent)
        End Function
    End Class
End Namespace