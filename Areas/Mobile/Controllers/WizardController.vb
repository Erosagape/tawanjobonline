﻿Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class WizardController
        Inherits MController

        ' GET: Mobile/Wizard
        Function Index() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Index", "Wizard")
                Return RedirectToAction("Index", "Login")
            End If
            Return View()
        End Function
    End Class
End Namespace