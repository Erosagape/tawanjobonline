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
            If Not IsNothing(TempData("UrlReturn")) Then
                ViewBag.Redirect = TempData("UrlReturn")
            Else
                ViewBag.Redirect = Url.Action("Index", "Main")
            End If
            Return View()
        End Function
        <HttpPost>
        <ActionName("Index")>
        Function PostIndex(form As FormCollection) As ActionResult
            Dim userid = form("txtUserID").ToString()
            Dim userrole = form("cboRole").ToString()
            Dim databaseid = form("cboDatabase").ToString()
            Dim targeturl = form("redirect").ToString()
            Dim jobconn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", databaseid)(0)
            Dim user = New CUser(jobconn).GetData(String.Format(" WHERE UserID='{0}'", userid))
            If user.Count = 0 Then
                TempData("Message") = "User not found"
                Return RedirectToAction("Index", "Login")
            Else
                TempData("DbId") = databaseid
                TempData("DbUser") = userid
                TempData("DbRole") = userrole
                TempData("TargetURL") = targeturl
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
            ViewBag.Redirect = TempData("TargetURL")
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
            Dim targeturl = form("Redirect").ToString()
            Dim jobconn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", databaseid)(0)
            Dim masconn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", databaseid)(1)
            Dim user = New CUser(jobconn).GetData(String.Format(" WHERE UserID='{0}'", userid))
            If user.Count = 0 Then
                If userrole = "C" Then
                    Dim cust = New CCompany(jobconn).GetData(String.Format(" WHERE LoginName='{0}' And LoginPassword='{1}'", userid, userpassword))
                    If cust.Count > 0 Then
                        TempData("UserID") = userid
                        TempData("UserRole") = userrole
                        TempData("UserDatabase") = databaseid
                        TempData("JobConn") = jobconn
                        TempData("MasConn") = masconn
                        TempData("UserName") = cust(0).NameThai
                        TempData("UserEName") = cust(0).NameEng
                        TempData("UserEMail") = cust(0).DMailAddress
                        TempData("UserPosition") = "99"
                        Return Redirect(targeturl)
                    End If
                End If
                If userrole = "V" Then
                    Dim vend = New CVender(jobconn).GetData(String.Format(" WHERE LoginName='{0}' And LoginPassword='{1}'", userid, userpassword))
                    If vend.Count > 0 Then
                        TempData("UserID") = userid
                        TempData("UserRole") = userrole
                        TempData("UserDatabase") = databaseid
                        TempData("JobConn") = jobconn
                        TempData("MasConn") = masconn
                        TempData("UserName") = vend(0).TName
                        TempData("UserEName") = vend(0).English
                        TempData("UserEMail") = vend(0).WEB_SITE
                        TempData("UserPosition") = "99"
                        Return Redirect(targeturl)
                    End If
                End If
                TempData("Message") = "User not found"
                Return RedirectToAction("Index", "Login")
            Else
                If user(0).UPassword.Equals(userpassword) Then
                    TempData("UserID") = userid
                    TempData("UserRole") = userrole
                    TempData("UserDatabase") = databaseid
                    TempData("JobConn") = jobconn
                    TempData("MasConn") = masconn
                    TempData("UserName") = user(0).TName
                    TempData("UserEName") = user(0).EName
                    TempData("UserEMail") = user(0).EMail
                    TempData("UserPosition") = user(0).UPosition
                    Return Redirect(targeturl)
                Else
                    TempData("Message") = "Password Inforrect"
                    TempData("DbId") = databaseid
                    TempData("DbUser") = userid
                    TempData("DbRole") = userrole
                    TempData("TargetURL") = targeturl
                    Return RedirectToAction("Verification", "Login")
                End If
            End If

        End Function
    End Class
End Namespace