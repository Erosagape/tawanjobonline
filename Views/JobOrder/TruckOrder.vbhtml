@Code
    ViewBag.Title = "Truck Order"

End Code
<style>
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
        <td>สาขา</td>
        <td style="display:flex">
            <input type="text" class="form-control" id="txtBranchCode" style="width:20%" disabled />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
            <input type="text" class="form-control" id="txtBranchName" style="width:100%" disabled />
        </td>
        <td>หมายเลข Job Order</td>
        <td style="display:flex">
            <input type="text" id="txtJNo" class="form-control" style="width:100%" />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('job');" />
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
        <td style="display:flex">
            <input type="text" id="txtNotifyCode" class="form-control" style="width:20%" />
            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
            <input type="text" id="txtNotifyName" class="form-control" style="width:100%" disabled />
        </td>
        <td>Vendor <br />ชื่อบริษัทขนส่ง</td>
        <td style="display:flex">
            <input type="text" id="txtVenderCode" class="form-control" style="width:20%">
            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('vender')">...</button>
            <input type="text" id="txtVenderName" class="form-control" style="width:100%" disabled />
        </td>
    </tr>
    <tr>
        <td>Customer Address <br />ที่อยู่  </td>
        <td><textarea id="CustomerAddress" style="width:100%" value=""></textarea></td>
        <td>Vendor Address <br />ที่อยู่</td>
        <td><textarea id="VendorAddress" style="width:100%" value=""></textarea></td>
    </tr>
    <tr>
        <td>Customer Contact <br />ชื่อผู้ติดต่อ</td>
        <td><input type="text" id="CustomerContact" style="width:100%" value="" /></td>
        <td>Vendor Contact <br />ผู้ติดต่อ</td>
        <td><input type="text" id="VendorContact" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Customer Phone <br />โทรศัพท์</td>
        <td><input type="text" id="CustomerPhone" style="width:100%" value="" /></td>
        <td>Vendor Phone <br />โทรศัพท์</td>
        <td><input type="text" id="VendorPhone" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <th colspan="2"><u>Carrier information / ข้อมูลเกี่ยวกับบริษัทเดินเรือ</u></th>
        <th colspan="2"><u>Assignment / ข้อมูลส่งมอบงาน</u></th>
    </tr>
    <tr>
        <td>Carrier Name<br />ชื่อบริษัทเดินเรือ</td>
        <td><input type="text" id="CarrierName" style="width:100%" value="" /></td>
        <td>Service Mode <br />ชนิดการขนส่ง</td>
        <td><input type="text" id="ServiceMode" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Carrier Contact & Phone <br />ชื่อผู้ติดต่อ/โทรศัพท์</td>
        <td><input type="text" id="CarrierContactPhone" style="width:100%" value="" /></td>
        <td>Customer Tariff <br />ประเภทการให้บริการลูกค้า</td>
        <td><select id="CustomerTariff" style="width:100%"></select></td>
    </tr>
    <tr>
        <td>Carrier Booking No <br />เลขที่ใบจองการเดินเรือ</td>
        <td><input type="text" id="CarrierBooking" style="width:100%" value="" /></td>
        <td>Vendor Tariff <br />ประเภทบริการของบริษัทขนส่ง</td>
        <td><select id="VendorTariff" style="width:100%"></select></td>
    </tr>
    <tr>
        <td>Booking Date <br />วันที่จอง</td>
        <td><input type="text" id="BookingDate" style="width:100%" value="" /></td>
        <td>Remark <br />หมายเหตุ</td>
        <td><input type="text" id="Remark" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <th colspan="2"><u>Service Information / ข้อมูลเกี่ยวกับการบริการ</u></th>
        <th colspan="2"><u>Truck Information / ข้อมูลเกี่ยวกับรถบรรทุก</u></th>
    </tr>
    <tr>
        <td>Service Type <br />ประเภทการให้บริการ</td>
        <td><input type="text" id="ServiceType" style="width:100%" value="" /></td>
        <td>Truck <br />ทะเบียน/ยี่ห้อรถบรรทุก</td>
        <td><input type="text" id="Truck" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Container Type <br />ประเภทตู้สินค้า</td>
        <td><select id="ContainerType" style="width:100%"></select></td>
        <td>Driver Name&Phone <br />ชื่อคนขับ/โทรศัพท์</td>
        <td><input type="text" id="DriverName" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Special Instruction <br />คำแนะนำในการส่งสินค้า</td>
        <td><input type="text" id="SpecialInstruction" style="width:100%" value="" /></td>
        <td>Container No <br />หมายเลขตู้สินค้า</td>
        <td><input type="text" id="Container" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td colspan="2"></td>
        <td>Discrepancy Reason <br />หมายเหตุในการส่งสินค้าล่าช้า</td>
        <td><input type="text" id="DiscrepancyReason" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <th colspan="2"><u>Billing information / ข้อมูลด้านบัญชีการเงิน</u> </th>
        <th colspan="2"><u>Audit Information / ข้อมูลสำหรับตรวจสอบสถานะเอกสาร</u></th>
    </tr>
    <tr>
        <td>Customer Invoice <br />หมายเลขใบกำกับภาษีของลูกค้า</td>
        <td><input type="text" id="CustomerInvoice" style="width:100%" value="" /></td>
        <td>Assign Vendor By <br />ผู้รับมอบหมายให้บริษัทขนส่ง</td>
        <td><input type="text" id="AssignVendor" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Vendor Invoice No <br />หมายเลขใบกำกับภาษีบริษัทขนส่ง</td>
        <td><input type="text" id="VendorInvoice" style="width:100%" value="" /></td>
        <td>Created By <br />ผู้สร้างเอกสาร</td>
        <td><input type="text" id="CreatedBy" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Billing Remark <br />หมายเหตุทางการเงิน</td>
        <td><input type="text" id="BillingRemark" style="width:100%" value="" /></td>
        <td>Updated By <br />ผู้แก้ไขเอกสารล่าสุด</td>
        <td><input type="text" id="UpdatedBy" style="width:100%" value="" /></td>
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
        <td><textarea id="Location1" style="width:100%" value=""></textarea></td>
        <td><textarea id="Location2" style="width:100%" value=""></textarea></td>
        <td><textarea id="Location3" style="width:100%" value=""></textarea></td>
    </tr>
    <tr>
        <td>Address <br />ที่อยู่</td>
        <td><textarea id="Address1" style="width:100%" value=""></textarea></td>
        <td><textarea id="Address2" style="width:100%" value=""></textarea></td>
        <td><textarea id="Address3" style="width:100%" value=""></textarea></td>
    </tr>
    <tr>
        <td>
            Contact <br />ชื่อผู้ติดต่อ
        </td>
        <td><input type="text" id="Contact1" style="width:100%" value="" /></td>
        <td><input type="text" id="Contact2" style="width:100%" value="" /></td>
        <td><input type="text" id="Contact3" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>
            Expected Date Time <br />วัน/เวลาที่คาดหมาย
        </td>
        <td><input type="text" id="ExpectedDateTime1" style="width:100%" value="" /></td>
        <td><input type="text" id="ExpectedDateTime2" style="width:100%" value="" /></td>
        <td><input type="text" id="ExpectedDateTime3" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Actual Date Time <br />วัน/เวลาจริง</td>
        <td><input type="text" id="ActualDateTime1" style="width:100%" value="" /></td>
        <td><input type="text" id="ActualDateTime2" style="width:100%" value="" /></td>
        <td><input type="text" id="ActualDateTime3" style="width:100%" value="" /></td>
    </tr>
    <tr>
        <td>Remark <br />หมายเหตุ</td>
        <td><input type="text" id="Remark1" style="width:100%" value="" /></td>
        <td><input type="text" id="Remark2" style="width:100%" value="" /></td>
        <td><input type="text" id="Remark3" style="width:100%" value="" /></td>
    </tr>
</table>
<input type="button" class="btn btn-success" value="Save" onclick="SaveValue()" />
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    var vTruckSheet = localStorage.getItem("TruckSheet");
    var vWorkOrder = localStorage.getItem("WorkOrder");
    var vCustomer = localStorage.getItem("Customer");
    var vVendor = localStorage.getItem("Vendor");
    var vCustomerAddress = localStorage.getItem("CustomerAddress");
    var vVendorAddress = localStorage.getItem("VendorAddress");
    var vCustomerContact = localStorage.getItem("CustomerContact");
    var vVendorContact = localStorage.getItem("VendorContact");
    var vCustomerPhone = localStorage.getItem("CustomerPhone");
    var vVendorPhone = localStorage.getItem("VendorPhone");
    var vCarrierName = localStorage.getItem("CarrierName");
    var vServiceMode = localStorage.getItem("ServiceMode");
    var vCarrierContact = localStorage.getItem("CarrierContact");
    var vCustomerTariff = localStorage.getItem("CustomerTariff");
    var vCarrierBooking = localStorage.getItem("CarrierBooking");
    var vVendorTariff = localStorage.getItem("VendorTariff");
    var vBookingDate = localStorage.getItem("BookingDate");
    var vRemark = localStorage.getItem("Remark");
    var vServiceType = localStorage.getItem("ServiceType");
    var vTruck = localStorage.getItem("Truck");
    var vContainerType = localStorage.getItem("ContainerType");
    var vDriverName = localStorage.getItem("DriverName");
    var vSpecialInstruction = localStorage.getItem("SpecialInstruction");
    var vContainer = localStorage.getItem("Container");
    var vDiscrepancyReason = localStorage.getItem("DiscrepancyReason");
    var vCustomerInvoice = localStorage.getItem("CustomerInvoice");
    var vAssignVendor = localStorage.getItem("AssignVendor");
    var vVendorInvoice = localStorage.getItem("VendorInvoice");
    var vCreatedBy = localStorage.getItem("CreatedBy");
    var vBillingRemark = localStorage.getItem("BillingRemark");
    var vUpdatedBy = localStorage.getItem("UpdatedBy");
    var vLocation1 = localStorage.getItem("Location1");
    var vLocation2 = localStorage.getItem("Location2");
    var vLocation3 = localStorage.getItem("Location3");
    var vAddress1 = localStorage.getItem("Address1");
    var vAddress2 = localStorage.getItem("Address2");
    var vAddress3 = localStorage.getItem("Address3");
    var vContact1 = localStorage.getItem("Contact1");
    var vContact2 = localStorage.getItem("Contact2");
    var vContact3 = localStorage.getItem("Contact3");
    var vExpectedDateTime1 = localStorage.getItem("ExpectedDateTime1");
    var vExpectedDateTime2 = localStorage.getItem("ExpectedDateTime2");
    var vExpectedDateTime3 = localStorage.getItem("ExpectedDateTime3");
    var vActualDateTime1 = localStorage.getItem("ActualDateTime1");
    var vActualDateTime2 = localStorage.getItem("ActualDateTime2");
    var vActualDateTime3 = localStorage.getItem("ActualDateTime3");
    var vRemark1 = localStorage.getItem("Remark1");
    var vRemark2 = localStorage.getItem("Remark2");
    var vRemark3 = localStorage.getItem("Remark3");

    function SaveValue() {
        localStorage.setItem("TruckSheet", vTruckSheet);
        localStorage.setItem("WorkOrder", vWorkOrder);
        localStorage.setItem("Customer", vCustomer);
        localStorage.setItem("Vendor", vVendor);
        localStorage.setItem("CustomerAddress", vCustomerAddress);
        localStorage.setItem("VendorAddress", vVendorAddress);
        localStorage.setItem("CustomerContact", vCustomerContact);
        localStorage.setItem("VendorContact", vVendorContact);
        localStorage.setItem("CustomerPhone", vCustomerPhone);
        localStorage.setItem("VendorPhone", vVendorPhone);
        localStorage.setItem("CarrierName", vCarrierName);
        localStorage.setItem("ServiceMode", vServiceMode);
        localStorage.setItem("CarrierContact", vCarrierContact);
        localStorage.setItem("CustomerTariff", vCustomerTariff);
        localStorage.setItem("CarrierBooking", vCarrierBooking);
        localStorage.setItem("VendorTariff", vVendorTariff);
        localStorage.setItem("BookingDate", vBookingDate);
        localStorage.setItem("Remark", vRemark);
        localStorage.setItem("ServiceType", vServiceType);
        localStorage.setItem("Truck", vTruck);
        localStorage.setItem("ContainerType", vContainerType);
        localStorage.setItem("DriverName&Phone", vDriverName);
        localStorage.setItem("SpecialInstruction", vSpecialInstruction);
        localStorage.setItem("Container", vContainer);
        localStorage.setItem("DiscrepancyReason", vDiscrepancyReason);
        localStorage.setItem("CustomerInvoice", vCustomerInvoice);
        localStorage.setItem("AssignVendor", vAssignVendor);
        localStorage.setItem("VendorInvoice", vVendorInvoice);
        localStorage.setItem("CreatedBy", vCreatedBy);
        localStorage.setItem("BillingRemark", vBillingRemark);
        localStorage.setItem("UpdatedBy", vUpdatedBy);
        localStorage.setItem("Location1", vLocation1);
        localStorage.setItem("Location2", vLocation2);
        localStorage.setItem("Location3", vLocation3);
        localStorage.setItem("Address1", vAddress1);
        localStorage.setItem("Address2", vAddress2);
        localStorage.setItem("Address3", vAddress3);
        localStorage.setItem("Contact1", vContact1);
        localStorage.setItem("Contact2", vContact2);
        localStorage.setItem("Contact3", vContact3);
        localStorage.setItem("Expected Date Time1", vExpectedDateTime1);
        localStorage.setItem("Expected Date Time2", vExpectedDateTime2);
        localStorage.setItem("Expected Date Time3", vExpectedDateTime3);
        localStorage.setItem("Actual Date Time1", vActualDateTime1);
        localStorage.setItem("Actual Date Time2", vActualDateTime2);
        localStorage.setItem("Actual Date Time3", vActualDateTime3);
        localStorage.setItem("Remark1", vRemark1);
        localStorage.setItem("Remark2", vRemark2);
        localStorage.setItem("Remark3", vRemark3);
        ShowMessage('Save OK');
    }
</script>
