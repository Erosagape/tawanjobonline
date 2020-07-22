
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation"
    ViewBag.Title = "ใบสั่งงานรถ (Truck Order)"
End Code
<div style="text-align:right;width:100%">
    <b>DATE :</b> <label id="lblBookingDate"></label>
</div>
<div style="width:100%">
    <b>BL NUMBER/BOOKING NO:</b> <label id="lblBookingNo"></label>
    <br />
    <b>บริษัทรถ / TRANSPORT COMPANY :</b><label id="lblForwarderName"></label>
    <br />
    <b>ประเภทรถ / TYPE OF TRANSPORT : </b><label id="lblTRemark"></label>
    <br />
    <b>จำนวนรถ / QUANTITY : </b><label id="lblTotalContainer"></label>
    <br />
    <b>วันรับสินค้า / PICK UP GOODS DATE : </b><label id="lblPickupDate"></label>
    <br />
    <b>สถานที่รับตู้ / PICK UP DEPOT : </b><label id="lblPickupPlace"></label>
    <br />
    <b>เจ้าหน้าที่ตรวจปล่อย / SHIPPING OFFICER : </b><label id="lblShippingName"></label>
    <br />
    <b>วันเวลาที่ส่งสินค้า / DELIVERY DATE :</b><label id="lblFactoryDate"></label> / <label id="lblFactoryTime"></label>
    <br />
    <b>สถานที่ส่งสินค้า / DELIVERY PLACE :</b><label id="lblFactoryPlace"></label>
    <br />
    <label id="lblFactoryAddress"></label>
    <b>บุคคลติดต่อ / CONTACT PERSON :</b> <label id="lblFactoryContact"></label>
    <br />
    <b>สายเรือ,สายการบิน / AGENT : </b> <label id="lblCarrierName"></label>
    <br />
    <b>ผู้นำเข้า / CONSIGNEE : </b> <label id="lblConsignName"></label>
    <br />
    <b>สินค้า / GOODS DESCRIPTION : </b> <label id="lblInvProduct"></label>
    <br />
    <b>น้ำหนักรวมสินค้า / GROSS WEIGHT : </b> <label id="lblGrossWeight"></label>
    <br />
    <b>NOTE:</b>
    <br />
    <div id="dvRemark"></div>
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
            $('#lblTRemark').text(h.TRemark);
            $('#lblTotalContainer').text(h.TotalContainer);
            $('#lblForwarderName').text(h.TransportName);
            $('#lblPickupDate').text(ShowDate(h.CYDate));
            $('#lblPickupPlace').text(h.CYPlace);
            $('#lblShippingName').text(h.ShippingName); 
            $('#lblFactoryDate').text(ShowDate(h.FactoryDate));
            $('#lblFactoryTime').text(ShowTime(h.FactoryTime));
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblFactoryAddress').text(h.FactoryAddress);
            $('#lblFactoryContact').text(h.FactoryContact);
            $('#lblCarrierName').text(h.CarrierName);
            $('#lblConsignName').text(h.ConsigneeName);
            $('#lblInvProduct').text(h.InvProduct);
            $('#lblGrossWeight').text(h.GrossWeight);
        
            $('#dvRemark').html(CStr(h.Remark));
        }
    });
</script>
