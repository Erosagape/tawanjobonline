Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class MenuController
        Inherits MController
        ' GET: Mobile/Menu
        Function Index() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Index", "Menu")
                Return RedirectToAction("Index", "Login")
            End If
            Return View()
        End Function
    End Class
End Namespace