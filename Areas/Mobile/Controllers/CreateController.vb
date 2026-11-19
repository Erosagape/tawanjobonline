Imports System.Web.Mvc
Namespace Areas.Mobile.Controllers
    Public Class CreateController
        Inherits MController

        ' GET: Mobile/Create
        Function Index() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Index", "Create")
                Return RedirectToAction("Index", "Login")
            End If
            Return View()
        End Function
        ' GET: Mobile/Create
        Function Company() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Company", "Create")
                Return RedirectToAction("Index", "Login")
            End If
            Return View()
        End Function
        ' GET: Mobile/Create
        Function Booking() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Booking", "Create")
                Return RedirectToAction("Index", "Login")
            End If
            Return View()
        End Function
        ' GET: Mobile/Create
        Function Shipment() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Shipment", "Create")
                Return RedirectToAction("Index", "Login")
            End If

            Return View()
        End Function
        ' GET: Mobile/Create
        Function Quotation() As ActionResult
            If Not CheckLogin() Then
                TempData("UrlReturn") = Url.Action("Quotation", "Create")
                Return RedirectToAction("Index", "Login")
            End If

            Return View()
        End Function
        <HttpPost>
        <ActionName("Booking")>
        Function PostBooking(form As FormCollection) As ActionResult
            Dim o = New CTransportHeader(ViewBag.JobConn)

            Return RedirectToAction("Booking", "List")
        End Function
        <HttpPost>
        <ActionName("Container")>
        Function PostContainer(form As FormCollection) As ActionResult

            Return RedirectToAction("Container", "List")
        End Function
        <HttpPost>
        <ActionName("Truck")>
        Function PostTruck(form As FormCollection) As ActionResult

            Return RedirectToAction("Truck", "List")
        End Function
        <HttpPost>
        <ActionName("Shipment")>
        Function PostShipment(form As FormCollection) As ActionResult
            Dim data = New CJobOrder(ViewBag.JobConn)
            data.JobType = form("jobtype")
            data.ShipBy = form("shipby")
            data.CustCode = form("customer").Split("|")(0)
            data.CustBranch = form("customer").Split("|")(1)
            data.Consigneecode = form("consignee")
            If data.JobType = 1 Then
                data.InvCountry = form("invcountry").Split("|")(1)
                data.InvFCountry = form("invfcountry").Split("|")(1)
                data.InvInterPort = form("invfcountry").Split("|")(0)
                data.ETADate = form("imexdate")
            Else
                data.InvFCountry = form("invcountry").Split("|")(1)
                data.InvCountry = form("invfcountry").Split("|")(1)
                data.InvInterPort = form("invcountry").Split("|")(0)
                data.ETDDate = form("imexdate")
            End If
            data.InvProduct = form("product")
            data.InvProductQty = form("prdqty")
            data.InvProductUnit = form("prdunit")
            data.TotalQty = form("totalbox")
            data.TotalContainer = form("totalctn") & "x" & form("ctnunit")
            data.Measurement = form("totalbox") * ((form("boxwidth") * form("boxheight") * form("boxhigh")) / 1000000)
            data.TotalNW = form("boxweight")
            data.TotalGW = form("totalbox") * form("boxweight")
            data.Description = "DIM=" & form("boxwidth") & "x" & form("boxheight") & "x" & form("boxhigh")
            data.ClearPort = form("clearport")
            data.ClearPortNo = form("clearportno")
            data.DeliveryTo = form("deliveryto")
            data.DeliveryAddr = form("deliveryaddr")
            Dim prefix As String = GetJobPrefix(data)
            If Not IsNothing(Request.QueryString("Prefix")) Then
                prefix = "" & Request.QueryString("Prefix")
            End If
            Dim fmt = Main.GetValueConfig("RUNNING", "JOB")
            If fmt <> "" Then
                If fmt.IndexOf("bb") >= 0 Then
                    fmt = fmt.Replace("bb", data.DocDate.AddYears(543).ToString("yy"))
                End If
                If fmt.IndexOf("yy") >= 0 Then
                    fmt = fmt.Replace("yy", data.DocDate.ToString("yy"))
                End If
                If fmt.IndexOf("MM") >= 0 Then
                    fmt = fmt.Replace("MM", data.DocDate.ToString("MM"))
                End If
            Else
                fmt = data.DocDate.ToString("yyMM") & "____"
            End If
            If Main.GetValueConfig("PROFILE", "RUNNING_BYMASK") = "N" Then
                data.AddNew("%" & fmt, False)
                If data.JNo.IndexOf("%") > 0 Then
                    data.JNo = data.JNo.Replace("%", prefix)
                Else
                    data.JNo = prefix & data.JNo.Substring(3)
                End If
            Else
                data.AddNew(prefix & fmt, False)
            End If
            Dim msg = data.SaveData(String.Format(" WHERE BranchCode='{0}' AND JNo='{1}'", data.BranchCode, data.JNo))
            Return RedirectToAction("Shipment", "List")
        End Function
        <HttpPost>
        <ActionName("Company")>
        Function PostCompany(form As FormCollection) As ActionResult
            Return RedirectToAction("Companies", "List")
        End Function
        <HttpPost>
        <ActionName("Quotation")>
        Function PostQuotation(form As FormCollection) As ActionResult
            Return RedirectToAction("Quotation", "List")
        End Function
    End Class
End Namespace