Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class ListController
        Inherits MController

        ' GET: Mobile/List
        Function Index() As ActionResult
            Return View()
        End Function
        Function Companies(id As String) As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Companies", "List")
                Return RedirectToAction("Index", "Login")
            End If
            Dim sql = ""
            If id <> "" Then
                sql = " WHERE CONCAT(CustCode,'|',Branch)='{0}'"
            End If
            Dim lst = New CCompany(ViewBag.JobConn).GetData(sql).AsEnumerable
            Return View(lst)
        End Function
    End Class
End Namespace