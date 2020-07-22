@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Transport Order"
    ViewBag.Title = "Transport Order"
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
        <td>หมายเลข Job Order</td>
        <td>
            <label id="txtJNo" style="width:100%"></label>
        </td>
        <td>เลขที่เอกสาร</td>
        <td>
            <label id="txtDeliveryNo" style="width:100%"></label>
        </td>
    </tr>
    <tr>
        <th colspan="2"><u>Customer Information / ข้อมูลเกี่ยวกับลูกค้า</u></th>
        <th colspan="2"><u>Vendor information / ข้อมูลเกี่ยวกับบริษัท</u></th>
    </tr>
    <tr>
        <td>
            Customer <br />ชื่อบริษัท
        </td>
        <td>
            <label id="txtNotifyName" style="width:100%"></label>
        </td>
        <td>Vendor <br />ชื่อบริษัทขนส่ง</td>
        <td>
            <label id="txtVenderName" style="width:100%"></label>
        </td>
    </tr>
    <tr>
        <td>Customer Address <br />ที่อยู่  </td>
        <td><div id="txtCustomerAddress" style="width:100%" value=""></div></td>
        <td>Vendor Address <br />ที่อยู่</td>
        <td><div id="txtVenderAddress" style="width:100%" value=""></div></td>
    </tr>
    <tr>
        <td>Customer Contact <br />ชื่อผู้ติดต่อ</td>
        <td><label id="txtCustomerContact" style="width:100%" value=""></label></td>
        <td>Vendor Contact <br />ผู้ติดต่อ</td>
        <td><label id="txtVenderContact" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Customer Phone <br />โทรศัพท์</td>
        <td><label id="txtCustomerPhone" style="width:100%" value=""></label></td>
        <td>Vendor Phone <br />โทรศัพท์</td>
        <td><label id="txtVenderPhone" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <th colspan="2"><u>Carrier information / ข้อมูลเกี่ยวกับบริษัทเดินเรือ</u></th>
        <th colspan="2"><u>Assignment / ข้อมูลส่งมอบงาน</u></th>
    </tr>
    <tr>
        <td>Carrier Name<br />ชื่อบริษัทเดินเรือ</td>
        <td><label id="txtCarrierName" style="width:100%" value=""></label></td>
        <td>Service Mode <br />ชนิดการขนส่ง</td>
        <td><label id="txtServiceMode" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Carrier Contact & Phone <br />ชื่อผู้ติดต่อ/โทรศัพท์</td>
        <td><div id="txtCarrierContactPhone" style="width:100%" value=""></div></td>
        <td>Customer Tariff <br />ประเภทการให้บริการลูกค้า</td>
        <td><label id="txtCustomerTariff" style="width:100%"></label></td>
    </tr>
    <tr>
        <td><b>Carrier Booking No</b><br />เลขที่ใบจองการเดินเรือ</td>
        <td><b></b><label id="txtCarrierBooking" style="width:100%" value=""></label><b/></td>
        <td>Vendor Tariff <br />ประเภทบริการของบริษัทขนส่ง</td>
        <td><label id="txtVenderTariff" style="width:100%"></label></td>
    </tr>
    <tr>
        <td>Booking Date <br />วันที่จอง</td>
        <td><label id="txtBookingDate" style="width:100%" value=""></label></td>
        <td>Remark <br />หมายเหตุ</td>
        <td><div id="txtRemark" style="width:100%" value=""></div></td>
    </tr>
    <tr>
        <th colspan="2"><u>Service Information / ข้อมูลเกี่ยวกับการบริการ</u></th>
        <th colspan="2"><u>Truck Information / ข้อมูลเกี่ยวกับรถบรรทุก</u></th>
    </tr>
    <tr>
        <td>Service Type <br />ประเภทการให้บริการ</td>
        <td><label id="txtServiceType" style="width:100%" value=""></label></td>
        <td>Truck <br />ทะเบียน/ยี่ห้อรถบรรทุก</td>
        <td><label id="txtTruck" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Container Type <br />ประเภทตู้สินค้า</td>
        <td><label id="txtContainerType" style="width:100%"></label></td>
        <td>Driver Name&Phone <br />ชื่อคนขับ/โทรศัพท์</td>
        <td><label id="txtDriverName" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Special Instruction <br />คำแนะนำในการส่งสินค้า</td>
        <td><div id="txtSpecialInstruction" style="width:100%" value=""></div></td>
        <td>Container No <br />หมายเลขตู้สินค้า</td>
        <td><label id="txtContainer" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td colspan="2"></td>
        <td>Discrepancy Reason <br />หมายเหตุในการส่งสินค้าล่าช้า</td>
        <td><div id="txtDiscrepancyReason" style="width:100%" value=""></div></td>
    </tr>
    <tr>
        <th colspan="2"><u>Billing information / ข้อมูลด้านบัญชีการเงิน</u> </th>
        <th colspan="2"><u>Audit Information / ข้อมูลสำหรับตรวจสอบสถานะเอกสาร</u></th>
    </tr>
    <tr>
        <td>Customer Invoice <br />หมายเลขใบกำกับภาษีของลูกค้า</td>
        <td><label id="txtCustomerInvoice" style="width:100%" value=""></label></td>
        <td>Assign Vendor By <br />ผู้รับมอบหมายให้บริษัทขนส่ง</td>
        <td><label id="txtAssignVender" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Vendor Invoice No <br />หมายเลขใบกำกับภาษีบริษัทขนส่ง</td>
        <td><label id="txtVenderInvoice" style="width:100%" value=""></label></td>
        <td>Created By <br />ผู้สร้างเอกสาร</td>
        <td><label id="txtCreatedBy" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Billing Remark <br />หมายเหตุทางการเงิน</td>
        <td><label id="txtBillingRemark" style="width:100%" value=""></label></td>
        <td>Updated By <br />ผู้แก้ไขเอกสารล่าสุด</td>
        <td><label id="txtUpdatedBy" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <th></th>
        <th><u>Pickup Services / การไปรับสินค้า</u></th>
        <th><u>Delivery Services / การส่งสินค้า</u></th>
        <th><u>Return Services / การส่งคืนสินค้า</u></th>
    </tr>
    <tr>
        <td>
            Location <br />ชื่อสถานที่
        </td>
        <td><label id="txtLocation1" style="width:100%" value=""></label></td>
        <td><label id="txtLocation2" style="width:100%" value=""></label></td>
        <td><label id="txtLocation3" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Address <br />ที่อยู่</td>
        <td><div id="txtAddress1" style="width:100%" value=""></div></td>
        <td><div id="txtAddress2" style="width:100%" value=""></div></td>
        <td><div id="txtAddress3" style="width:100%" value=""></div></td>
    </tr>
    <tr>
        <td>
            Contact <br />ชื่อผู้ติดต่อ
        </td>
        <td><label id="txtContact1" style="width:100%" value=""></label></td>
        <td><label id="txtContact2" style="width:100%" value=""></label></td>
        <td><label id="txtContact3" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>
            Expected Date Time <br />วัน/เวลาที่คาดหมาย
        </td>
        <td><label id="txtExpectedDateTime1" style="width:100%" value=""></label></td>
        <td><label id="txtExpectedDateTime2" style="width:100%" value=""></label></td>
        <td><label id="txtExpectedDateTime3" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Actual Date Time <br />วัน/เวลาจริง</td>
        <td><label id="txtActualDateTime1" style="width:100%" value=""></label></td>
        <td><label id="txtActualDateTime2" style="width:100%" value=""></label></td>
        <td><label id="txtActualDateTime3" style="width:100%" value=""></label></td>
    </tr>
    <tr>
        <td>Remark <br />หมายเหตุ</td>
        <td><label id="txtRemark1" style="width:100%" value=""></label></td>
        <td><label id="txtRemark2" style="width:100%" value=""></label></td>
        <td><label id="txtRemark3" style="width:100%" value=""></label></td>
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
