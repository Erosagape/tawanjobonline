Public Class MController
    Inherits System.Web.Mvc.Controller
    Public Function CheckLogin() As Boolean
        Dim IsLoginProperly = False
        If Not IsNothing(TempData("UserID")) Then
            IsLoginProperly = True
            SetViewData("UserID")
            SetViewData("UserRole")
            SetViewData("UserDB", "UserDatabase")
            SetViewData("JobConn")
            SetViewData("MasConn")
            SetViewData("UserName")
            SetViewData("UserEName")
            SetViewData("UserEMail")
            SetViewData("UserPosition")

            '---Old Version---
            'ViewBag.UserID = TempData("UserID")
            'ViewBag.UserRole = TempData("UserRole")
            'ViewBag.UserDB = TempData("UserDatabase")
            'ViewBag.JobConn = TempData("JobConn")
            'ViewBag.MasConn = TempData("MasConn")
            'ViewBag.UserName = TempData("UserName")
            'ViewBag.UserEName = TempData("UserEName")
            'ViewBag.UserEMail = TempData("UserEMail")
            'ViewBag.UserPosition = TempData("UserPosition")

            'TempData("UserID") = ViewBag.UserID
            'TempData("UserRole") = ViewBag.UserRole
            'TempData("UserDatabase") = ViewBag.UserDB
            'TempData("JobConn") = ViewBag.JobConn
            'TempData("MasConn") = ViewBag.MasConn
            'TempData("UserName") = ViewBag.UserName
            'TempData("UserEName") = ViewBag.UserEName
            'TempData("UserEMail") = ViewBag.UserEMail
            'TempData("UserPosition") = ViewBag.UserPosition
        End If
        Return IsLoginProperly
    End Function
    Sub SetViewData(propName As String)
        ViewData(propName) = TempData(propName)
        TempData(propName) = ViewData(propName)
    End Sub
    Sub SetViewData(propName As String, tempName As String)
        ViewData(propName) = TempData(tempName)
        TempData(tempName) = ViewData(propName)
    End Sub
End Class
