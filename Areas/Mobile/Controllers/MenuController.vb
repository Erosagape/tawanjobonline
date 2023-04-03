Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class MenuController
        Inherits Controller
        ' GET: Mobile/Menu
        Function Index() As ActionResult
            If TempData("UserID") Is Nothing Then
                Return RedirectToAction("Index", "Login")
            Else
                ViewBag.UserID = TempData("UserID")
                TempData("UserID") = ViewBag.UserID
            End If
            Return View()
        End Function
    End Class
End Namespace