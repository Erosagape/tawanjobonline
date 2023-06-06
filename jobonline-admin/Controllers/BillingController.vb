Imports System.Web.Mvc

Namespace Controllers
    Public Class BillingController
        Inherits Controller

        ' GET: Billing
        Function Index() As ActionResult
            ViewBag.CustProfiles = New TWTCustomer(jobonline_admin.My.MySettings.Default.weblicenseConnection).GetData("")
            ViewBag.CustData = New TWTCustomerApp(My.MySettings.Default.weblicenseConnection).GetData("")
            ViewBag.CustSel = ""
            ViewBag.DBSel = ""
            ViewBag.YearSel = DateTime.Now.Year
            ViewBag.MonthSel = DateTime.Now.AddMonths(-1).Month
            ViewBag.JobList = Nothing
            ViewBag.InvList = Nothing
            ViewBag.LoginList = Nothing
            Return View()
        End Function
        <HttpPost()>
        <ActionName("Index")>
        Function PostIndex() As ActionResult
            ViewBag.CustProfiles = New TWTCustomer(jobonline_admin.My.MySettings.Default.weblicenseConnection).GetData("")
            ViewBag.CustData = New TWTCustomerApp(My.MySettings.Default.weblicenseConnection).GetData("")
            ViewBag.CustSel = Request.Form("selCustomer")
            ViewBag.DBSel = Request.Form("selDatabase")
            ViewBag.YearSel = Request.Form("onYear")
            ViewBag.MonthSel = Request.Form("onMonth")
            ViewBag.JobList = Nothing
            ViewBag.InvList = Nothing
            ViewBag.LoginList = Nothing
            If ViewBag.DBSel > 0 And ViewBag.CustSel <> "" Then
                Dim config = New TWTCustomerApp(My.MySettings.Default.weblicenseConnection).GetData(String.Format(" WHERE CustID='{0}' AND Seq={1}", ViewBag.CustSel, ViewBag.DBSel))
                If config.Count > 0 Then
                    Dim oConnStr = config(0).WebTranConnect
                    Dim oConn = New CUtil(oConnStr)

                    Dim oJob = oConn.GetTableFromSQL(String.Format(Request.Form("sqlJob"), Request.Form("onYear"), Request.Form("onMonth")))
                    If oJob.Rows.Count > 0 Then
                        ViewBag.JobList = oJob.AsEnumerable().ToList()
                    End If

                    Dim oInv = oConn.GetTableFromSQL(String.Format(Request.Form("sqlInv"), Request.Form("onYear"), Request.Form("onMonth")))
                    If oInv.Rows.Count > 0 Then
                        ViewBag.InvList = oInv.AsEnumerable().ToList()
                    End If

                    Dim oLogin = oConn.GetTableFromSQL(String.Format(Request.Form("sqlLogin"), Request.Form("onYear"), Request.Form("onMonth"), Request.Form("selCustomer")))
                    If oLogin.Rows.Count > 0 Then
                        ViewBag.LoginList = oLogin.AsEnumerable.ToList()
                    End If
                End If
            End If
            Return View()
        End Function
    End Class
End Namespace