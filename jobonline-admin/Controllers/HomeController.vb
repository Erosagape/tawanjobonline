Public Class HomeController
    Inherits CController
    Function TestConnectLicense() As ActionResult
        Try
            Using cn As New SqlClient.SqlConnection(My.Settings.weblicenseConnection)
                cn.Open()
                Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""OK""}", "application/json;charset=UTF-8")
            End Using
        Catch ex As Exception
            Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""" & ex.Message & """}", "application/json;charset=UTF-8")
        End Try
    End Function
    Function TestConnectApplication() As ActionResult
        Try
            Using cn As New SqlClient.SqlConnection(My.Settings.weblicenseConnection)
                cn.Open()
                If Request.QueryString("Cust") Is Nothing Then
                    Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""Please Specified Customer Code""}", "application/json;charset=UTF-8")
                Else
                    If Request.QueryString("App") Is Nothing Then
                        Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""Please Specified Application""}", "application/json;charset=UTF-8")
                    Else
                        Dim strCust = Request.QueryString("Cust").ToString
                        Dim strApp = Request.QueryString("App").ToString
                        Dim oData = New CUtil(My.Settings.weblicenseConnection).GetTableFromSQL(String.Format("SELECT * FROM TWTCustomerApp WHERE CustID='{0}' AND AppID='{1}'", strCust, strApp))
                        If oData.Rows.Count > 0 Then
                            Dim strResult = ""
                            For Each dr As DataRow In oData.Rows
                                Try
                                    Using cnMas As New SqlClient.SqlConnection(dr("WebMasConnect").ToString())
                                        cnMas.Open()
                                        strResult &= "MAS(" & dr("Seq").ToString & ")=OK;"
                                        cnMas.Close()
                                    End Using
                                Catch e1 As Exception
                                    strResult &= "MAS(" & dr("Seq").ToString & ")=" & e1.Message & ";"
                                End Try
                                Try
                                    Using cnTran As New SqlClient.SqlConnection(dr("WebTranConnect").ToString())
                                        cnTran.Open()
                                        strResult &= "TRAN(" & dr("Seq").ToString & ")=OK;"
                                        cnTran.Close()
                                    End Using
                                Catch e2 As Exception
                                    strResult &= "TRAN(" & dr("Seq").ToString & ")=" & e2.Message & ";"
                                End Try
                            Next
                            Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""" & strResult & """}", "application/json;charset=UTF-8")
                        Else
                            Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""Data Not Found""}", "application/json;charset=UTF-8")
                        End If
                    End If
                End If
                cn.Close()
            End Using
        Catch e As Exception
            Return Content("{""connect"":""" & My.Settings.weblicenseConnection.Replace("\", "\\") & """,""result"":""" & e.Message & """}", "application/json;charset=UTF-8")
        End Try
    End Function
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
