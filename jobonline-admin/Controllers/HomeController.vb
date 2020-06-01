Public Class HomeController
    Inherits CController
    Function Index() As ActionResult
        ViewBag.Title = "System Variable"
        Return GetView("Index")
    End Function
    Function Login() As ActionResult
        ViewBag.Title = "Login"
        Return View()
    End Function
    Function CheckLogin() As ContentResult
        If Not Request.QueryString("UID") Is Nothing Then
            If Not Request.QueryString("UPWD") Is Nothing Then
                Dim userID = Request.QueryString("UID").ToString
                Dim userPassword = Request.QueryString("UPWD").ToString
                Dim tSql = String.Format("SELECT TWTUserName FROM TWTUser WHERE TWTUserID='{0}' AND TWTUserPassword='{1}'", userID, userPassword)
                Dim oChk = GetValueSQL(My.Settings.weblicenseConnection, tSql)
                If oChk.Result <> "" Then
                    If oChk.IsError = False Then
                        Session("CurrUser") = userID
                        Session("UserName") = oChk.Result
                        Return Content("OK", textContent)
                    Else
                        Return Content(oChk.Result, textContent)
                    End If
                Else
                    Return Content("User or Password Incorrect", textContent)
                End If
            Else
                Return Content("Please Enter Password", textContent)
            End If
        Else
            Return Content("Please Enter User ID", textContent)
        End If
    End Function
End Class
