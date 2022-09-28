Imports System.Web.Mvc

Namespace Controllers
    Public Class UtilController
        Inherits CController

        ' GET: Util
        Function Index() As ActionResult
            Return View()
        End Function
        Function Excel() As ActionResult
            Return GetView("Excel")
        End Function
        <HttpPost()>
        <ActionName("Excel")>
        Function PostExcel() As ActionResult

        End Function
    End Class
End Namespace