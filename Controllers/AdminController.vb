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
            Dim id As Integer = 0
            If Not Request.QueryString("Id") Is Nothing Then
                id = Convert.ToInt32(Request.QueryString("Id"))
            End If
            Try
                Dim o = New CLog(ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString).GetData(String.Format(" WHERE CustID='" & My.MySettings.Default.LicenseTo.ToString & "' AND LogID={0}", id))
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
        Function RestoreLogId() As ActionResult
            Dim id As Integer = 0
            If Not Request.QueryString("Id") Is Nothing Then
                id = Convert.ToInt32(Request.QueryString("Id"))
            End If
            Dim obj = New CUtil(ConfigurationManager.ConnectionStrings("TawanConnectionString").ConnectionString)
            Dim o = obj.GetTableFromSQL(String.Format(" SELECT * FROM TWTLog WHERE LogID={0}", id))
            Dim conn = Main.GetDatabaseConnection(My.MySettings.Default.LicenseTo, "JOBSHIPPING", 0)
            If o.Rows.Count > 0 Then
                Dim r = o.Rows(0)
                Dim jsonData = r("JsonData").ToString()
                Select Case r("ModuleName").ToString()
                    Case "CWHTaxHeader"
                        Dim oData = JsonConvert.DeserializeObject(Of CWHTaxHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo)), "text/html")
                    Case "CWHTaxDetail"
                        Dim oData = JsonConvert.DeserializeObject(Of CWHTaxDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo)), "text/html")
                    Case "CVoucherSub"
                        Dim oData = JsonConvert.DeserializeObject(Of CVoucherSub)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE ControlNo='{0}' And ItemNo={1}", oData.ControlNo, oData.ItemNo)), "text/html")
                    Case "CVoucherDoc"
                        Dim oData = JsonConvert.DeserializeObject(Of CVoucherDoc)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE ControlNo='{0}' And ItemNo={1}", oData.ControlNo, oData.ItemNo)), "text/html")
                    Case "CVoucher"
                        Dim oData As CVoucher = JsonConvert.DeserializeObject(Of CVoucher)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE ControlNo='{0}'", oData.ControlNo)), "text/html")
                    Case "CVender"
                        Dim oData As CVender = JsonConvert.DeserializeObject(Of CVender)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE VenCode='{0}'", oData.VenCode)), "text/html")
                    Case "CTransportHeader"
                        Dim oData As CTransportHeader = JsonConvert.DeserializeObject(Of CTransportHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE BookingNo='{0}'", oData.BookingNo)), "text/html")
                    Case "CTransportDetail"
                        Dim oData As CTransportDetail = JsonConvert.DeserializeObject(Of CTransportDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE BookingNo='{0}' AND ItemNo={1}", oData.BookingNo, oData.ItemNo)), "text/html")
                    Case "CPayHeader"
                        Dim oData As CPayHeader = JsonConvert.DeserializeObject(Of CPayHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo)), "text/html")
                    Case "CPayDetail"
                        Dim oData As CPayDetail = JsonConvert.DeserializeObject(Of CPayDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo)), "text/html")
                    Case "CJobOrder"
                        Dim oData As CJobOrder = JsonConvert.DeserializeObject(Of CJobOrder)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE JNo='{0}'", oData.JNo)), "text/html")
                    Case "CInvHeader"
                        Dim oData As CInvHeader = JsonConvert.DeserializeObject(Of CInvHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo)), "text/html")
                    Case "CInvDetail"
                        Dim oData As CInvDetail = JsonConvert.DeserializeObject(Of CInvDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo)), "text/html")
                    Case "CCompany"
                        Dim oData As CCompany = JsonConvert.DeserializeObject(Of CCompany)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE CustCode='{0}' AND Branch='{1}'", oData.CustCode, oData.Branch)), "text/html")
                    Case "CCNDNHeader"
                        Dim oData As CCNDNHeader = JsonConvert.DeserializeObject(Of CCNDNHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}'", oData.DocNo)), "text/html")

                    Case "CCNDNDetail"
                        Dim oData As CCNDNDetail = JsonConvert.DeserializeObject(Of CCNDNDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE DocNo='{0}' AND ItemNo={1}", oData.DocNo, oData.ItemNo)), "text/html")
                    Case "CClrHeader"
                        Dim oData As CClrHeader = JsonConvert.DeserializeObject(Of CClrHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE ClrNo='{0}' ", oData.ClrNo)), "text/html")
                    Case "CClrDetail"
                        Dim oData As CClrDetail = JsonConvert.DeserializeObject(Of CClrDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE ClrNo='{0}' AND ItemNo={1}", oData.ClrNo, oData.ItemNo)), "text/html")
                    Case "CBillHeader"
                        Dim oData As CBillHeader = JsonConvert.DeserializeObject(Of CBillHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE BillAcceptNo='{0}'", oData.BillAcceptNo)), "text/html")
                    Case "CBillDetail"
                        Dim oData As CBillDetail = JsonConvert.DeserializeObject(Of CBillDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE BillAcceptNo='{0}' AND ItemNo={1}", oData.BillAcceptNo, oData.ItemNo)), "text/html")
                    Case "CAdvHeader"
                        Dim oData As CAdvHeader = JsonConvert.DeserializeObject(Of CAdvHeader)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE AdvNo='{0}'", oData.AdvNo)), "text/html")
                    Case "CAdvDetail"
                        Dim oData As CAdvDetail = JsonConvert.DeserializeObject(Of CAdvDetail)(jsonData)
                        oData.SetConnect(conn(0))
                        Return Content(oData.SaveData(String.Format(" WHERE AdvNo='{0}' AND ItemNo={1}", oData.AdvNo, oData.ItemNo)), "text/html")
                End Select
                Return Content("Not found type", "text/html")
            Else
                Return Content(obj.Message, "text/html")
            End If
        End Function

    End Class
End Namespace