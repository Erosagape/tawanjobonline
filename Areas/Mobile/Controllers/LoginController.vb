Imports System.Web.Mvc
Namespace Areas.Mobile.Controllers
    Public Class LoginController
        Inherits Controller

        ' GET: Mobile/Login
        Function Index() As ActionResult
            Dim licenseTo = My.MySettings.Default.LicenseTo
            ViewBag.DatabaseList = Main.GetDatabaseProfile(licenseTo, "")
            ViewBag.Message = "Ready"
            If Not IsNothing(TempData("Message")) Then
                ViewBag.Message = TempData("Message")
            End If
            Return View()
        End Function
        <HttpPost>
        <ActionName("Index")>
        Function PostIndex(form As FormCollection) As ActionResult
            Dim userid = form("txtUserID").ToString()
            Dim userrole = form("cboRole").ToString()
            Dim databaseid = form("cboDatabase").ToString()
            Dim jobconn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", databaseid)(0)
            Dim user = New CUser(jobconn).GetData(String.Format(" WHERE UserID='{0}'", userid))
            If user.Count = 0 Then
                TempData("Message") = "User not found"
                Return RedirectToAction("Index", "Login")
            Else
                TempData("DbId") = databaseid
                TempData("DbUser") = userid
                TempData("DbRole") = userrole
                Return RedirectToAction("Verification", "Login")
            End If
        End Function
        Function Verification() As ActionResult
            If IsNothing(TempData("DbId")) Then
                TempData("Message") = "Config database not found"
                Return RedirectToAction("Index", "Login")
            End If
            If IsNothing(TempData("DbUser")) Then
                TempData("Message") = "User not found"
                Return RedirectToAction("Index", "Login")
            End If
            If IsNothing(TempData("DbRole")) Then
                TempData("Message") = "User Role not found"
                Return RedirectToAction("Index", "Login")
            End If
            If Not IsNothing(TempData("Message")) Then
                ViewBag.Message = TempData("Message")
            Else
                ViewBag.Message = "Ready"
            End If
            ViewBag.User = TempData("DbUser")
            ViewBag.UserRole = TempData("DbRole")
            ViewBag.UserDB = TempData("DbId")
            Return View()
        End Function
        <HttpPost>
        <ActionName("Verification")>
        Function PostVerification(form As FormCollection) As ActionResult
            Dim userid = form("txtUserID").ToString()
            Dim userrole = form("txtUserRole").ToString()
            Dim userpassword = form("txtUserPassword").ToString()
            Dim databaseid = form("txtDatabaseID").ToString()
            Dim jobconn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", databaseid)(0)
            Dim user = New CUser(jobconn).GetData(String.Format(" WHERE UserID='{0}'", userid))
            If user.Count = 0 Then
                TempData("Message") = "User not found"
                Return RedirectToAction("Index", "Login")
            Else
                If user(0).UPassword.Equals(userpassword) Then
                    TempData("UserID") = userid
                Else
                    TempData("Message") = "Password Inforrect"
                    TempData("DbId") = databaseid
                    TempData("DbUser") = userid
                    TempData("DbRole") = userrole
                    Return View("Verification")
                End If
            End If
            Return RedirectToAction("Index", "Menu")
        End Function
    End Class
End Namespace