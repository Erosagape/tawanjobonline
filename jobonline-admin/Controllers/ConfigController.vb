Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json
Namespace Controllers
    Public Class ConfigController
        Inherits CController

        ' GET: Config
        Function Index() As ActionResult
            Return GetView("Index")
        End Function
        Function App() As ActionResult
            ViewBag.App = New TWTApp(My.Settings.weblicenseConnection).GetData("")
            Return GetView("App")
        End Function
        Function Cust() As ActionResult
            Return GetView("Cust")
        End Function
        Function Log() As ActionResult
            ViewBag.Cust = New TWTCustomer(My.Settings.weblicenseConnection).GetData("")
            Return GetView("Log")
        End Function
        Function CustApp() As ActionResult
            ViewBag.Data = New TWTCustomerApp(My.Settings.weblicenseConnection).GetData("")
            ViewBag.App = New TWTApp(My.Settings.weblicenseConnection).GetData("")
            ViewBag.Cust = New TWTCustomer(My.Settings.weblicenseConnection).GetData("")
            ViewBag.Subscription = New TWTSubscription(My.Settings.weblicenseConnection).GetData("")
            Return GetView("CustApp")
        End Function
        Function Users() As ActionResult
            ViewBag.Data = New TWTUser(My.Settings.weblicenseConnection).GetData("")
            Return GetView("User")
        End Function
        Function Subscription() As ActionResult
            ViewBag.Data = New TWTSubscription(My.Settings.weblicenseConnection).GetData("")
            ViewBag.App = New TWTApp(My.Settings.weblicenseConnection).GetData("")
            Return GetView("Subscription")
        End Function
        Function SetSubscription(<FromBody()> data As TWTSubscription) As ActionResult
            data.SetConnect(My.Settings.weblicenseConnection)
            Dim msg = If(data.SaveData(), "Save Complete", "Save Failed")
            Return Content(msg, "text/html")
        End Function
        Function GetSubscription() As ActionResult
            Dim tSql As String = ""
            If Not Request.QueryString("ID") Is Nothing Then
                tSql &= String.Format(" WHERE SubScriptionID={0}", Request.QueryString("ID").ToString)
            End If
            Dim oData = New TWTSubscription(My.Settings.weblicenseConnection).GetData(tSql)
            Dim json = JsonConvert.SerializeObject(oData)
            Return Content(json, "text/json")
        End Function
        Function GetUser() As ActionResult
            Dim tSql As String = ""
            If Not Request.QueryString("Code") Is Nothing Then
                tSql &= String.Format(" WHERE TWTUserID='{0}'", Request.QueryString("Code").ToString)
            End If
            Dim oData = New TWTUser(My.Settings.weblicenseConnection).GetData(tSql)
            Dim json = JsonConvert.SerializeObject(oData)
            Return Content(json, "text/json")
        End Function
        Function SetUser(<FromBody()> data As TWTUser) As ActionResult
            data.SetConnect(My.Settings.weblicenseConnection)
            Dim msg = If(data.SaveData(), "Save Complete", "Save Failed")
            Return Content(msg, "text/html")
        End Function
        Function GetApp() As ActionResult
            Dim tSql As String = ""
            If Not Request.QueryString("Code") Is Nothing Then
                tSql &= String.Format(" WHERE AppID='{0}'", Request.QueryString("Code").ToString)
            End If
            Dim oTable = New CUtil(My.Settings.weblicenseConnection).GetTableFromSQL("SELECT * FROM TWTApp " & tSql)
            Dim json = JsonConvert.SerializeObject(oTable)
            Return Content(json, "text/json")
        End Function
        Function SetApp(<FromBody()> data As TWTApp) As ActionResult
            data.SetConnect(My.Settings.weblicenseConnection)
            Dim msg = data.SaveData(String.Format(" WHERE AppID='{0}'", data.AppID))
            Return Content(msg, "text/html")
        End Function
        Function GetCustomer() As ActionResult
            Dim tSql As String = ""
            If Not Request.QueryString("Code") Is Nothing Then
                tSql &= String.Format(" WHERE CustID='{0}'", Request.QueryString("Code").ToString)
            End If
            Dim oTable = New CUtil(My.Settings.weblicenseConnection).GetTableFromSQL("SELECT * FROM TWTCustomer " & tSql)
            Dim json = JsonConvert.SerializeObject(oTable)
            Return Content(json, "text/json")
        End Function
        Function SetCustomer(<FromBody()> data As TWTCustomer) As ActionResult
            data.SetConnect(My.Settings.weblicenseConnection)
            Dim msg = data.SaveData(String.Format(" WHERE CustID='{0}'", data.CustID))
            Return Content(msg, "text/html")
        End Function
        Function GetCustomerApp() As ActionResult
            Dim tSql As String = " WHERE Seq>0 "
            If Not Request.QueryString("App") Is Nothing Then
                tSql &= String.Format(" AND AppID='{0}'", Request.QueryString("App").ToString)
            End If
            If Not Request.QueryString("Cust") Is Nothing Then
                tSql &= String.Format(" AND CustID='{0}'", Request.QueryString("Cust").ToString)
            End If
            If Not Request.QueryString("ID") Is Nothing Then
                tSql &= String.Format(" AND Seq={0}", Request.QueryString("ID").ToString)
            End If
            Dim oData = New TWTCustomerApp(My.Settings.weblicenseConnection).GetData(tSql)
            Dim json = JsonConvert.SerializeObject(oData)
            Return Content(json, "text/json")
        End Function
        Function SetCustomerApp(<FromBody()> data As TWTCustomerApp) As ActionResult
            data.SetConnect(My.Settings.weblicenseConnection)
            Dim msg = data.SaveData(String.Format(" WHERE CustID='{0}' AND AppID='{1}' AND Seq={2}", data.CustID, data.AppID, data.Seq))
            Return Content(msg, "text/html")
        End Function
        Function GetLog() As ActionResult
            Dim tSqlw As String = " WHERE CustID<>'' "
            If Not IsNothing(Request.QueryString("Error")) Then
                tSqlw &= String.Format(" AND IsError={0}", Request.QueryString("Error").ToString())
            End If

            If Not IsNothing(Request.QueryString("Cust")) Then
                tSqlw &= String.Format(" AND CustID Like '{0}%'", Request.QueryString("Cust").ToString())
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                tSqlw &= " AND LogDateTime>='" & Request.QueryString("DateFrom") & " 00:00:00'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                tSqlw &= " AND LogDateTime<='" & Request.QueryString("DateTo") & " 23:59:59'"
            End If
            Dim oData = New CLog(My.Settings.weblicenseConnection).GetData(tSqlw)
            Dim json = JsonConvert.SerializeObject(oData)
            Return Content(json, "text/json")
        End Function
    End Class
End Namespace