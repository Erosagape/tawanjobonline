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
        <td style="width:30%">Pickup Date<br />วันรับตู้เปล่า/ตู้หนัก</td>
        <td style="width:20%">
            <label id="txtExpectedDateTime1" style="width:100%" value=""></label>
        </td>
        <td style="width:30%">Loading Date<br />วันบรรจุ/ส่งสินค้า</td>
        <td style="width:20%">
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
        <td colspan="4" style="text-align:center"><u>Expenses Detail</u></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">Transport Charges/Trip</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">Transport For Return Container</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">Transport TOTAL</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">Depot Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">Port Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">X-Ray Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">Others Fee</td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2"><br /></td>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">TOTAL</td>
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
            $('#txtNotifyName').text(h.NotifyName);
            $('#txtCustomerAddress').html(CStr(h.NotifyAddress1 + '\n' + h.NotifyAddress2));
            $('#txtExpectedDateTime1').text(CDateEN(h.TargetYardDate));
            $('#txtExpectedDateTime2').text(CDateEN(h.TargetDeliveryDate));
            $('#txtHAWBNo').text(h.HAWB);
            $('#txtVesselName').text(h.VesselName);
            $('#txtLocation2').text(h.PlaceName2);
            $('#txtLocation3').text(h.PlaceName3);
            $('#txtVenderName').text(h.ForwarderName);
            $('#txtTotalContainer').text(h.TotalContainer);
            $('#txtDeliveryNo').text(h.DeliveryNo);
            $('#txtJNo').text(h.JNo);
            $('#txtTruckType').text(h.TruckType);
            $.get(path + 'Config/GetConfig?Code=JOB_TYPE&Key=' + CCode(h.JobType))
                .done(function (r) {
                    let b = r.config.data;
                    if (b.length > 0) {
                        $('#txtJobTypeName').text(b[0].ConfigValue);
                    }
                });
        }
    });
</script>
