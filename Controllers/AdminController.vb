Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class AdminController
        Inherits CController

        ' GET: Admin
        Function Index() As ActionResult
            Return GetView("Index")
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
    End Class
End Namespace