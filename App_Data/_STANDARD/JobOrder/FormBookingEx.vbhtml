﻿
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Truck Order"
    ViewBag.Title = "ใบสั่งงานรถ (Truck Order)"
End Code
<div style="text-align:right;width:100%">
    <b>DATE :</b> <label id="lblBookingDate"></label><br/>
    <b>JOB NUMBER :</b> <label id="lblJNo"></label>
</div>
<div style="width:100%">
    <div style="display:flex">
        <div style="flex:1">
            <b>BL NUMBER/BOOKING NO:</b>
        </div>
        <div style="flex:1">
            <label id="lblBookingNo"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>บริษัทรถ / TRANSPORT COMPANY :</b>
        </div>
        <div style="flex:1">
            <label id="lblForwarderName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ประเภทรถ / TYPE OF TRANSPORT : </b>
        </div>
        <div style="flex:1">
            <label id="lblTruckType"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>จำนวนรถ / QUANTITY : </b>
        </div>
        <div style="flex:1">
            <label id="lblTotalContainer"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>วันรับตู้ / PICK UP CONTAINER DATE : </b>
        </div>
        <div style="flex:1">
            <label id="lblPickupDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สถานที่รับตู้เปล่า / PICK UP DEPOT : </b>
        </div>
        <div style="flex:1">
            <label id="lblPickupPlace"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>เบอร์ติดต่อลานตู้ / DEPOT CONTACT PERSON : </b>
        </div>
        <div style="flex:1">
            <label id="lblPickupContact"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>วันเวลาที่บรรจุสินค้า / JOB DATE :</b>
        </div>
        <div style="flex:1">
            <label id="lblJobDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สถานที่บรรจุสินค้า / FACTORY ADDRESS :</b>
        </div>
        <div style="flex:1">
            <label id="lblFactoryPlace"></label>
            <br />
            <div id="lblFactoryAddress"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>บุคคลติดต่อ / FACTORY CONTACT PERSON :</b>
        </div>
        <div style="flex:1">
            <label id="lblFactoryContact"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ท่าเรือที่คืนตู้ / RETURN AT : </b>
        </div>
        <div style="flex:1">
            <label id="lblReturnPlace"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สายเรือ,สายการบิน / AGENT : </b>
        </div>
        <div style="flex:1">
            <label id="lblCarrierName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>วันที่สามารถคืนตู้ / FIRST RETURN : </b>
        </div>
        <div style="flex:1">
            <label id="lblFactoryDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ท่าเรือต้นทาง / POL : </b>
        </div>
        <div style="flex:1">
            <label id="lblLocalPort"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>กำหนดคืนตู้ / CLOSING TIME : </b>
        </div>
        <div style="flex:1">
            <label id="lblReturnDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ท่าเรือปลายทาง / POD : </b>
        </div>
        <div style="flex:1">
            <label id="lblDeliveryTo"></label>
        </div>
    </div>

    <div style="display:flex">
        <div style="flex:1">
            <b>ผู้ส่งออก / SHIPPER : </b>
        </div>
        <div style="flex:1">
            <label id="lblConsignName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สินค้า / GOODS DESCRIPTION : </b>
        </div>
        <div style="flex:1">
            <label id="lblInvProduct"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>น้ำหนักรวมสินค้า / GROSS WEIGHT : </b>
        </div>
        <div style="flex:1">
            <label id="lblGrossWeight"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สรุปรายละเอียดงาน / JOB DETAILS : </b>
        </div>
        <div style="flex:1">
            <div id="lblDescription"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ที่อยู่ในการออกใบเสร็จค่ารถ : </b>
        </div>
        <div style="flex:1">
            <label id="lblBillTransportTo"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ที่อยู่ในการออกใบเสร็จค่าตู้และอื่นๆ : </b>
        </div>
        <div style="flex:1">
            <div id="lblBillToAddress"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>NOTE:</b>
        </div>
        <div style="flex:1">
            <div id="dvRemark"></div>
        </div>
    </div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblJNo').text(h.JNo);
            $('#lblTruckType').text(h.TRemark);
            $('#lblTotalContainer').text(h.TotalContainer);
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblPickupDate').text(ShowDate(h.CYDate));
            $('#lblPickupPlace').text(h.CYPlace);
            $('#lblPickupContact').text(h.CYContact); 
            $('#lblReturnDate').text(ShowDate(h.ReturnDate) + ' ' + ShowTime(h.ReturnTime));
            $('#lblReturnPlace').text(h.PackingPlace);
            $('#lblFactoryDate').text(ShowDate(h.FactoryDate));
            $('#lblFactoryTime').text(ShowTime(h.FactoryTime));
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblFactoryAddress').html(CStr(h.FactoryAddress));
            $('#lblFactoryContact').text(h.FactoryContact);
            $('#lblCarrierName').text(h.CarrierName);
            $('#lblConsignName').text(h.ConsigneeName);
            $('#lblInvProduct').text(h.InvProduct);
            $('#lblLocalPort').text(h.ClearPortNo);
            $('#lblDeliveryTo').text(h.DeliveryTo);
            $('#lblGrossWeight').text(h.TotalGW + ' '+ h.GWUnit);
            $('#lblDescription').html(CStr(h.Description));
            $('#lblBillTransportTo').text(h.PaymentBy);
            $('#lblBillToAddress').html(CStr(h.PaymentCondition));
            $('#dvRemark').html(CStr(h.Remark));

            let ctnList = '';
            let html = '';
            let ctn = JSON.parse(JSON.stringify(r.booking.data));
            sortData(ctn, 'TargetYardDate', 'asc');
            let yardDate = '';
            let ctnCount = 0;
            for (let d of ctn) {
                let chk = ShowDate(d.TargetYardDate) + '-' + ShowTime(d.TargetYardTime);
                if ((yardDate !== chk) && (yardDate!=='')) {
                    if (ctnList.indexOf(yardDate) < 0) {
                        if (ctnList !== '') ctnList += ',';
                        ctnList += yardDate + '(' + ctnCount + ')';
                        yardDate = chk;
                        ctnCount = 1;
                    }
                } else {
                    yardDate = chk;
                    ctnCount++;
                }
            }
            if (ctnList !== '') ctnList += ',';
            ctnList += yardDate + '('+ ctnCount+')';
            $('#lblJobDate').html(ctnList);
        }
    });
</script>
