@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Transport Acknowledgement"
    ViewBag.Title = "Transport Acknowledgement"
End Code
<style>
    * {
        font-size:10px;
    }
    table {
        width: 100%;
    }

    table, td, td {
        border: 1px solid black;
        border-collapse: collapse;
    }
</style>
<table>
    <tr>
        <td>Customer Name<br />ชื่อลูกค้า</td>
        <td colspan="3">
            <label id="txtNotifyName" style="width:100%"></label>
        </td>
    </tr>
    <tr>
        <td>Customer Address<br />ที่อยู่ลูกค้า</td>
        <td colspan="3">
            <div id="txtCustomerAddress" style="width:100%" value=""></div>
        </td>
    </tr>
    <tr>
        <td>Pickup Date<br />วันรับตู้เปล่า/ตู้หนัก</td>
        <td>
            <label id="txtExpectedDateTime1" style="width:100%" value=""></label>
        </td>
        <td>Loading Date<br />วันบรรจุ/ส่งสินค้า</td>
        <td>
            <label id="txtExpectedDateTime2" style="width:100%" value=""></label>
        </td>
    </tr>
    <tr>
        <td>B/L No<br />เลขที่ใบตราส่ง</td>
        <td>
            <label id="txtHAWBNo" style="width:100%"></label>
        </td>
        <td>Vessel Name<br />ชื่อเรือ</td>
        <td>
            <label id="txtVesselName" style="width:100%"></label>
        </td>
    </tr>
    <tr>
        <td>Loading Place<br />รับสินค้า/ตู้เปล่าที่</td>
        <td>
            <label id="txtLocation2" style="width:100%" value=""></label>
        </td>
        <td>Discharge Place<br />คืนตู้ที่/ส่งสินค้าที่</td>
        <td>
            <label id="txtLocation3" style="width:100%" value=""></label>
        </td>
    </tr>
    <tr>
        <td>Truck Company<br />บริษัทรถ</td>
        <td>
            <label id="txtVenderName" style="width:100%"></label>
        </td>
        <td>Quantity<br />จำนวน</td>
        <td>
            <label id="txtTotalContainer" style="width:100%"></label>
        </td>
    </tr>
    <tr>
        <td>Invoice รถเลขที่</td>
        <td>
            <label id="txtDeliveryNo" style="width:100%"></label>
        </td>
        <td>Type<br />ชนิดรถ</td>
        <td>
            <label id="txtTruckType" style="width:100%" value=""></label>
        </td>
    </tr>
    <tr>
        <td>หมายเลข Job Order</td>
        <td>
            <label id="txtJNo" style="width:100%"></label>
        </td>
        <td>แผนก</td>
        <td>
            <label id="txtJobTypeName" style="width:100%"></label>
        </td>
    </tr>
    <tr>
        <td colspan="4"><u>Expenses Detail</u></td>
    </tr>
    <tr>
        <td colspan="2">Transport Charges/Trip</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">Transport For Return Container</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">Transport TOTAL</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">Depot Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">Port Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">X-Ray Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">Others Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2"><br /></td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2">TOTAL</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td>Transport</td>
        <td></td>
        <td colspan="2" rowspan="4">
            NOTE:<br />
        </td>
    </tr>
    <tr>
        <td>DATE วันที่</td>
        <td></td>
    </tr>
    <tr>
        <td>PAID ชำระแล้ว</td>
        <td></td>
    </tr>
    <tr>
        <td>DATE วันที่</td>
        <td></td>
    </tr>
</table>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    let cont = getQueryString("ContainerNo");
    let user = '@ViewBag.User';
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc +'&Cont=' +cont).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#txtHAWBNo').text(h.HAWB);
            $('#txtVesselName').text(h.VesselName);
            $('#txtDeliveryNo').text(h.DeliveryNo);
            $('#txtJNo').text(h.JNo);
            $('#txtNotifyName').text(h.NotifyName);
            $('#txtVenderName').text(h.ForwarderName);
            $('#txtCustomerAddress').html(CStr(h.NotifyAddress1 + '\n' + h.NotifyAddress2));
            $('#txtVenderAddress').html(CStr(h.ForwarderAddress1 + '\n' + h.ForwarderAddress2));
            $('#txtCustomerContact').text(h.CustContactName);
            $('#txtVenderContact').text(h.ForwarderContact);
            $('#txtCustomerPhone').text(h.NotifyPhone);
            $('#txtVenderPhone').text(h.ForwarderPhone);
            $('#txtCarrierName').text(h.CarrierName);
            $('#txtCarrierContactPhone').html (CStr(h.CarrierContact + '\n' + h.CarrierPhone));
            $('#txtServiceMode').text(h.TransMode);
            $('#txtCustomerTariff').text(h.CYPlace + '->' + h.PackingPlace + '->' + h.FactoryPlace + '->' + h.ReturnPlace);
            $('#txtCarrierBooking').text(h.BookingNo);
            $('#txtVenderTariff').text(h.Location);
            $('#txtBookingDate').text(CDateEN(h.BookingDate));
            $('#txtRemark').html(CStr(h.Remark));
            $('#txtServiceType').text(h.LocationRoute);
            $('#txtTruck').text(h.TruckNO);
            $('#txtContainerType').text(h.CTN_SIZE);
            $('#txtDriverName').text(h.Driver);
            $('#txtSpecialInstruction').html(h.Description);
            $('#txtContainer').text(h.CTN_NO);
            $('#txtDiscrepancyReason').html(h.Comment);
            $('#txtCustomerInvoice').text(h.InvNo);
            $('#txtAssignVender').text(h.CSName);
            $('#txtVenderInvoice').text('');
            $('#txtBillingRemark').text('');
            $('#txtCreatedBy').text(user + ' @DateTime.Now.ToString("yyyy-MM-dd HH:mm")');
            $('#txtUpdatedBy').text(user + ' @DateTime.Now.ToString("yyyy-MM-dd HH:mm")');
            $('#txtLocation1').text(h.PlaceName1);
            $('#txtLocation2').text(h.PlaceName2);
            $('#txtLocation3').text(h.PlaceName3);
            $('#txtAddress1').html(CStr(h.PlaceAddress1));
            $('#txtAddress2').html(CStr(h.PlaceAddress2));
            $('#txtAddress3').html(CStr(h.PlaceAddress3));
            $('#txtContact1').text(h.PlaceContact1);
            $('#txtContact2').text(h.PlaceContact2);
            $('#txtContact3').text(h.PlaceContact3);
            $('#txtExpectedDateTime1').text(CDateEN(h.TargetYardDate));
            $('#txtExpectedDateTime2').text(CDateEN(h.TargetDeliveryDate));
            $('#txtExpectedDateTime3').text(CDateEN(h.TargetReturnDate));
            $('#txtActualDateTime1').text(CDateEN(h.ActualYardDate));
            $('#txtActualDateTime2').text(CDateEN(h.ActualDeliveryDate));
            $('#txtActualDateTime3').text(CDateEN(h.ActualReturnDate));
        }
    });
</script>
