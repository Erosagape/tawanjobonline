@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Transport Order Confirmation"
    ViewBag.Title = "Transport Order Confirmation"

End Code
<style>
    * {
        font-size: 10px;
    }

    table {
        width: 100%;
    }

    table, th, td {
        border: 1px solid black;
        border-collapse: collapse;
    }
</style>
<table>
    <tr>
        <th>วันที่เอกสาร</th>
        <th colspan="3">@DateTime.Now.ToString("dd/MM/yyyy HH:mm")</th>
    </tr>
    <tr>
        <td>หมายเลข Job Order</td>
        <td><label id="txtJNo"></label></td>
        <td>เลขที่เอกสาร</td>
        <td><label id="txtDeliveryNo"></label></td>
    </tr>
    <tr>
        <td>ชื่อเรือ/เที่ยว</td>
        <td><label id="txtVesselName"></label></td>
        <td>ปลายทาง(Port)</td>
        <td><label id="txtDischargePort"></label></td>
    </tr>
    <tr>
        <td>วัน-เวลาปิดรับ</td>
        <td><label id="txtCYDate"></label></td>
        <td>วันเรือออก</td>
        <td><label id="txtETDDate"></label></td>
    </tr>
    <tr>
        <td>คำแนะนำในการส่งสินค้า</td>
        <td><div id="txtSpecialInstruction"></div></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <th colspan="2">ข้อมูลเกี่ยวกับลูกค้า</th>
        <th colspan="2">ข้อมูลเกี่ยวกับบริษัทเดินเรือ</th>
    </tr>
    <tr>
        <td>ชื่อบริษัทลูกค้า</td>
        <td><label id="txtNotifyName"></label></td>
        <td>ชือบริษัทเดินเรือ</td>
        <td><label id="txtCarrierName"></label></td>
    </tr>
    <tr>
        <td>ที่อยู่</td>
        <td><div id="txtNotifyAddress"></div></td>
        <td>ชื่อผู้ติดต่อ/โทรศัพท์</td>
        <td><label id="txtCarrierContact"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td><b>บุ้คกิ้ง<b></td>
        <td><b><label id="txtCarrierBooking"></label><b></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>วันที่จอง</td>
        <td><label id="txtBookingDate"></label></td>
    </tr>
    <tr>
        <th colspan="2">ข้อมูลเกี่ยวกับการบริการ</th>
        <th colspan="2">ข้อมูลเกี่ยวกับรถบรรทุก</th>
    </tr>
    <tr>
        <td><b>ประเภทการให้บริการ</b></td>
        <td><b><label id="txtServiceType"></label></b></td>
        <td><b>ทะเบียนรถบรรทุก</b></td>
        <td><b><label id="txtTruck"></label></b></td>
    </tr>
    <tr>
        <td><b>ขนาดตู้คอนเทนเนอร์</b></td>
        <td><b><label id="txtContainerType"></label></b></td>
        <td><b>ชื่อคนขับ/โทรศัพท์</b></td>
        <td><b><label id="txtDriverName"></label></b></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td><b>หมายเลขตู้คอนเทนเนอร์</b></td>
        <td><b><label id="txtContainer"></label></b></td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td><div id="txtRemark"></div></td>
        <td><b>หมายเหตุในการส่งตู้ล่าช้า<b></td>
        <td><b><div id="txtDiscrepancyReason"></div></b></td>
    </tr>
    <tr>
        <th></th>
        <th>สถานที่รับตู้  / VGM Closing</th>
        <th>ไปส่งที่  / Loading </th>
        <th>สถานที่ส่งคืน  /  CY Closing</th>
    </tr>
    <tr>
        <td>ชื่อสถานที่</td>
        <td><label id="txtPlace1"></label></td>
        <td><label id="txtPlace2"></label></td>
        <td><label id="txtPlace3"></label></td>
    </tr>
    <tr>
        <td>ที่อยู่</td>
        <td><label id="txtAddress1"></label></td>
        <td><label id="txtAddress2"></label></td>
        <td><label id="txtAddress3"></label></td>
    </tr>
    <tr>
        <td>ชื่อผู้ติดต่อ</td>
        <td><label id="txtContact1"></label></td>
        <td><label id="txtContact2"></label></td>
        <td><label id="txtContact3"></label></td>
    </tr>
    <tr>
        <td>วัน/เวลา</td>
        <td><label id="txtTargetDate1"></label></td>
        <td><label id="txtTargetDate2"></label></td>
        <td><label id="txtTargetDate3"></label></td>
    </tr>
    <tr>
        <td>วัน/เวลาจริง</td>
        <td><label id="txtActualDate1"></label></td>
        <td><label id="txtActualDate2"></label></td>
        <td><label id="txtActualDate3"></label></td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td><label id="txtRemark1"></label></td>
        <td><label id="txtRemark2"></label></td>
        <td><label id="txtRemark3"></label></td>
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
            $('#txtJNo').text(h.JNo);
            $('#txtDeliveryNo').text(h.DeliveryNo);
            $('#txtNotifyName').text(h.NotifyName);
            $('#txtVesselName').text(h.VesselName);
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#txtDischargePort');
            } else {
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblDischargePort');
            }
            $('#txtCYDate').text(ShowDate(h.CYDate));
            $('#txtETDDate').text(ShowDate(h.ETDDate));
            $('#txtSpecialInstruction').html(h.Description);
            $('#txtNotifyName').text(h.NotifyName);
            $('#txtCarrierName').text(h.CarrierName);
            $('#txtNotifyAddress').html(CStr(h.NotifyAddress1+'\n'+h.NotifyAddress2));
            $('#txtCarrierContact').text(h.CarrierContact);
            $('#txtCarrierBooking').text(h.BookingNo);
            $('#txtBookingDate').text(ShowDate(h.BookingDate));
            $('#txtServiceType').text(h.LocationRoute);
            $('#txtTruck').text(h.CarLicense);
            $('#txtContainerType').text(h.CTN_SIZE);
            $('#txtDriverName').text(h.DriverName);
            $('#txtContainer').text(h.CTN_NO);
            $('#txtDiscrepancyReason').html(h.Comment);
            $('#txtRemark').html(CStr(h.Remark));

            $('#txtPlace1').text(h.PlaceName1);
            $('#txtPlace2').text(h.PlaceName2);
            $('#txtPlace3').text(h.PlaceName3);
            $('#txtAddress1').html(CStr(h.PlaceAddress1));
            $('#txtAddress2').html(CStr(h.PlaceAddress2));
            $('#txtAddress3').html(CStr(h.PlaceAddress3));
            $('#txtTargetDate1').text(ShowDate(h.TargetYardDate) + ' ' + ShowTime(h.TargetYardTime));
            $('#txtTargetDate2').text(ShowDate(h.TargetDeliveryDate) + ' ' + ShowTime(h.TargetDeliveryTime));
            $('#txtTargetDate3').text(ShowDate(h.TargetReturnDate) + ' ' + ShowTime(h.TargetReturnTime));
            $('#txtActualDate1').text(ShowDate(h.ActualYardDate) + ' ' + ShowTime(h.ActualYardTime));
            $('#txtActualDate2').text(ShowDate(h.ActualDeliveryDate) + ' ' + ShowTime(h.ActualDeliveryTime));
            $('#txtActualDate3').text(ShowDate(h.ActualReturnDate) + ' ' + ShowTime(h.ActualReturnTime));
            $('#txtContact1').text(h.PlaceContact1);
            $('#txtContact2').text(h.PlaceContact2);
            $('#txtContact3').text(h.PlaceContact3);
        }
    });
</script>
