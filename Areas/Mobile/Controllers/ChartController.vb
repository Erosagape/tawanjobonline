Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class ChartController
        Inherits MController

        ' GET: Mobile/Chart
        Function Index() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Index", "Chart")
                Return RedirectToAction("Index", "Login")
            End If
            Dim sqlW = ""
            Dim dateWhere = "DocDate"
            If Not IsNothing(Request.QueryString("OnDate")) Then
                dateWhere = Request.QueryString("OnDate")
            End If
            If Not IsNothing(Request.QueryString("DateFrom")) Then
                sqlW &= dateWhere & " >='" & Request.QueryString("DateFrom") & "'"
            End If
            If Not IsNothing(Request.QueryString("DateTo")) Then
                If sqlW <> "" Then
                    sqlW &= " AND "
                End If
                sqlW &= dateWhere & " <='" & Request.QueryString("DateFrom") & "'"
            End If
            If sqlW <> "" Then
                sqlW = " WHERE " & sqlW
            End If
            PopulateJobData(sqlW)
            Return View("Index")
        End Function
        Sub PopulateJobData(sqlw As String)
            Dim oJob = New CJobOrder(ViewBag.JobConn).GetData(sqlw).AsEnumerable()
            Select Case ViewBag.UserRole
                Case "S"
                    Dim oJobFilter = From job In oJob
                                     Where job.CSCode.Equals(ViewBag.UserID) Or job.ManagerCode.Equals(ViewBag.UserID) Or "3,4,5".Contains(ViewBag.UserPosition) = False
                                     Select job

                    ViewBag.JobList = oJobFilter.ToList()
                Case "C"
                    Dim oCust = New CCompany(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oCustCode = If(oCust.Count > 0, oCust(0).CustCode, "")
                    Dim oCustBranch = If(oCust.Count > 0, oCust(0).Branch, "")
                    Dim oJobFilter = From job In oJob
                                     Where (job.CustCode.Equals(oCustCode) And job.CustBranch.Equals(oCustBranch))
                                     Select job

                    ViewBag.JobList = oJobFilter.ToList()
                Case "V"
                    Dim oVend = New CVender(ViewBag.JobConn).GetData(String.Format(" WHERE LoginName='{0}'", ViewBag.UserID))
                    Dim oVenCode = If(oVend.Count > 0, oVend(0).VenCode, "")
                    Dim oJobFilter = From job In oJob
                                     Where (job.AgentCode.Equals(oVenCode) Or job.ForwarderCode.Equals(oVenCode))
                                     Select job
                    ViewBag.JobList = oJobFilter.ToList()
            End Select
        End Sub
    End Class
End Namespace