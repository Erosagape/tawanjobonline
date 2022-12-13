Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class AdminController
        Inherits CController

        ' GET: Admin
        Function Index() As ActionResult
            Return GetView("Index")
        End Function
        Function Util() As ActionResult
            Return GetView("Util")
        End Function
        Function UpVersion() As ActionResult
            Return GetView("UpVersion")
        End Function
        <HttpPost()>
        Function ImportLangMenu(data As List(Of CLangMessage)) As ActionResult
            Dim i As Integer = 0
            If data.Count > 0 Then
                For Each lang In data
                    Dim oCfg = New CConfig(GetSession("ConnJob")) With {
                    .ConfigCode = "LANG_MENU",
                    .ConfigKey = lang.Source,
                    .ConfigValue = lang.Translate
                    }
                    If oCfg.SaveData() Then
                        i += 1
                    End If
                Next
            End If
            Return Content(i + " row(s) imported", textContent)
        End Function
        <HttpPost()>
        Function ImportLangMessage(data As List(Of CLangMessage)) As ActionResult
            Dim i As Integer = 0
            If data.Count > 0 Then
                For Each lang In data
                    Dim oCfg = New CConfig(GetSession("ConnJob")) With {
                    .ConfigCode = "LANG_MESSAGE_TH",
                    .ConfigKey = lang.Source,
                    .ConfigValue = lang.Translate
                    }
                    If oCfg.SaveData() Then
                        i += 1
                    End If
                Next
            End If
            Return Content(i + " row(s) imported", textContent)
        End Function
        <HttpPost()>
        Function ImportReportGroup(data As List(Of CReportGroup)) As ActionResult
            Dim i As Integer = 0
            For Each row In data
                Dim oCfg = New CConfig(GetSession("ConnJob")) With {
                    .ConfigCode = "REPORT_GROUP",
                    .ConfigKey = row.ConfigKey,
                    .ConfigValue = row.ConfigValue
                    }
                If oCfg.SaveData() Then
                    i += 1
                End If
            Next
            Return Content(i + " row(s) saved", textContent)
        End Function
        <HttpPost()>
        Function ImportReportConfig(data As List(Of CReportConfig)) As ActionResult
            Dim i As Integer = 0
            For Each row In data
                Dim oCfg = New CConfig(GetSession("ConnJob")) With {
                    .ConfigCode = "REPORT_" + row.ReportCode
                    }
                oCfg.ConfigKey = "ReportGroup"
                oCfg.ConfigValue = row.ReportGroup
                oCfg.SaveData()

                oCfg.ConfigKey = "ReportAuthor"
                oCfg.ConfigValue = row.ReportAuthor
                oCfg.SaveData()

                oCfg.ConfigKey = "ReportType"
                oCfg.ConfigValue = row.ReportType
                oCfg.SaveData()

                oCfg.ConfigKey = "ReportNameTH"
                oCfg.ConfigValue = row.ReportNameTH
                oCfg.SaveData()

                oCfg.ConfigKey = "ReportNameEN"
                oCfg.ConfigValue = row.ReportNameEN
                oCfg.SaveData()

                i += 1
            Next
            Return Content(i + " row(s) saved", textContent)
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
        Function ChangePassword() As ActionResult
            ViewBag.Message = "Ready"
            Return View()
        End Function
        <HttpPost>
        <ActionName("ChangePassword")>
        Function PostChangePassword() As ActionResult
            Dim str = "User ID={0} Old Pass={1} New Pass={2} Db={3}"
            str = String.Format(str, Request.Form("userid"), Request.Form("oldpass"), Request.Form("newpass"), Request.Form("db"))
            ViewBag.Message = str
            Dim userid = Request.Form("userid")
            Dim oldpass = Request.Form("oldpass")
            Dim newpass = Request.Form("newpass")
            Dim db = Request.Form("db")
            Dim conn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", db)
            If conn.Length <> 2 Then
                ViewBag.Message = "Cannot Connect Database"
            Else
                Dim oUser = New CUser(conn(0)).GetData(String.Format(" WHERE UserID='{0}'", userid))
                If oUser.Count > 0 Then
                    If oUser(0).UPassword.Equals(oldpass) Then
                        If newpass.Length = 0 Then
                            ViewBag.Message = "Password must be input"
                            Return View()
                        End If
                        oUser(0).UPassword = newpass
                        str = oUser(0).SaveData(String.Format(" WHERE UserID='{0}'", userid))
                        If str.Substring(0, 1) = "S" Then
                            ViewBag.Message = str + " <a href=""../Default"">Back To Login</a>"
                        Else
                            ViewBag.Message = str
                        End If
                    Else
                        ViewBag.Message = "Old Password Incorrect"
                    End If
                Else
                    ViewBag.Message = "User Not Found"
                End If
            End If
            Return View()
        End Function
        Function Test() As ActionResult
            Return View()
        End Function
        Function TestFunction() As String
            Return "Test Function Called"
        End Function
        Function ExecuteStoreProcedure() As String
            Try
                Dim procName As String = ""
                If Not Request.QueryString("PROC") Is Nothing Then
                    procName = Request.QueryString("PROC")
                Else
                    Return "Procedure Not Found"
                End If
                Dim dbID As String = "1"
                If Not Request.QueryString("DBID") Is Nothing Then
                    dbID = Request.QueryString("DBID") Is Nothing
                End If
                Dim connWebLicense = ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString
                Dim custID = My.MySettings.Default.LicenseTo.ToString
                Dim dbType As String = "Tran"
                If Not Request.QueryString("DBTYPE") Is Nothing Then
                    dbType = Request.QueryString("DBTYPE") Is Nothing
                End If
                Using cnConfig As New SqlClient.SqlConnection(connWebLicense)
                    cnConfig.Open()
                    Dim sql = "SELECT * FROM TWTCustomerApp wHERE CustID='{0}' AND Seq={1}"
                    Using rd As SqlClient.SqlDataReader = New SqlClient.SqlCommand(String.Format(sql, custID, dbID), cnConfig).ExecuteReader
                        If rd.HasRows Then
                            While rd.Read
                                Dim connStr = rd("Web" + dbType + "Connect").ToString()
                                Using cn As New SqlClient.SqlConnection(connStr)
                                    cn.Open()
                                    If cn.State = ConnectionState.Open Then
                                        Using cm As New SqlClient.SqlCommand
                                            cm.Connection = cn
                                            cm.CommandTimeout = Main.GetValueConfig("PROFILE", "QUERY_TIMEOUT", 600)
                                            cm.CommandType = CommandType.StoredProcedure
                                            cm.CommandText = procName
                                            Dim i As Integer = 1
                                            While i > 0
                                                If Not Request.QueryString("PARAM" & i) Is Nothing Then
                                                    Dim params = Request.QueryString("PARAM" & i).Split("|")
                                                    If UBound(params) > 0 Then
                                                        cm.Parameters.AddWithValue("@" + params(0).ToString(), params(1).ToString())
                                                    End If
                                                    i += 1
                                                Else
                                                    i = 0
                                                End If
                                            End While
                                            Try
                                                cm.ExecuteNonQuery()
                                            Catch sqlex As SqlClient.SqlException
                                                Return sqlex.Message
                                            End Try
                                        End Using
                                    Else
                                        Return "Can Not Open Connection"
                                    End If
                                End Using
                                rd.Close()
                            End While
                            Return "Execute Complete"
                        Else
                            Return "Config Not Found"
                        End If
                    End Using
                    cnConfig.Close()
                End Using

            Catch ex As Exception
                Return ex.Message
            End Try
        End Function
    End Class
End Namespace