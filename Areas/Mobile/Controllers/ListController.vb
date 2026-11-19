Imports System.Web.Mvc

Namespace Areas.Mobile.Controllers
    Public Class ListController
        Inherits MController

        ' GET: Mobile/List
        Function Index() As ActionResult
            Return View()
        End Function
        Function Booking() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Booking", "List")
                Return RedirectToAction("Index", "Login")
            End If
            ViewBag.DataHeader = New CTransportHeader(ViewBag.JobConn).GetData("")
            ViewBag.DataDetail = New CTransportDetail(ViewBag.JobConn).GetData("")
            Return View()
        End Function
        Function Container() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Container", "List")
                Return RedirectToAction("Index", "Login")
            End If
            ViewBag.DataHeader = New CTransportHeader(ViewBag.JobConn).GetData("")
            ViewBag.DataDetail = New CTransportDetail(ViewBag.JobConn).GetData("")
            Return View()
        End Function
        Function Truck() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Truck", "List")
                Return RedirectToAction("Index", "Login")
            End If
            ViewBag.DataHeader = New CTransportHeader(ViewBag.JobConn).GetData("")
            ViewBag.DataDetail = New CTransportDetail(ViewBag.JobConn).GetData("")
            Return View()
        End Function
        Function Quotation() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Quotation", "List")
                Return RedirectToAction("Index", "Login")
            End If
            ViewBag.DataHeader = New CQuoHeader(ViewBag.JobConn).GetData("")
            ViewBag.DataDetail = New CQuoDetail(ViewBag.JobConn).GetData("")
            Return View()
        End Function
        Function Shipment() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Shipment", "List")
                Return RedirectToAction("Index", "Login")
            End If
            ViewBag.DataSource = New CJobOrder(ViewBag.JobConn).GetData("")
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