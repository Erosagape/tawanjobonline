
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
    <b>BL NUMBER/BOOKING NO:</b> <label id="lblBookingNo"></label>
    <br />
    <b>บริษัทรถ / TRANSPORT COMPANY :</b><label id="lblForwarderName"></label>
    <br />
    <b>ประเภทรถ / TYPE OF TRANSPORT : </b><label id="lblTRemark"></label>
    <br />
    <b>จำนวนรถ / QUANTITY : </b><label id="lblTotalContainer"></label>
    <br />
    <b>วันรับตู้ / PICK UP CONTAINER DATE : </b><label id="lblPickupDate"></label>
    <br />
    <b>สถานที่รับตู้เปล่า / PICK UP DEPOT : </b><label id="lblPickupPlace"></label>
    <br />
    <b>หมายเลขตู้ / CONTAINER LISTS : </b> <textarea id="lblContainerList"></textarea>
    <br />
    <b>เบอร์ติดต่อลานตู้ / DEPOT CONTACT PERSON : </b><label id="lblPickupContact"></label>
    <br />
    <b>วันเวลาที่บรรจุสินค้า / JOB DATE :</b><label id="lblFactoryDate"></label> / <label id="lblFactoryTime"></label>
    <br />
    <b>สถานที่บรรจุสินค้า / FACTORY ADDRESS :</b><label id="lblFactoryPlace"></label>
    <br />
    <label id="lblFactoryAddress"></label>
    <b>บุคคลติดต่อ / FACTORY CONTACT PERSON :</b> <label id="lblFactoryContact"></label>
    <br />
    <b>ท่าเรือที่คืนตู้ / RETURN AT : </b> <label id="lblReturnPlace"></label>
    <br/>
    <b>วันที่คืนตู้ / RETURN DATE : </b> <label id="lblReturnDate"></label>
    <br/>
    <b>สายเรือ,สายการบิน / AGENT : </b> <label id="lblCarrierName"></label>
    <br />
    <b>ผู้ส่งออก / SHIPPER : </b> <label id="lblConsignName"></label>
    <br />
    <b>สินค้า / GOODS DESCRIPTION : </b> <label id="lblInvProduct"></label>
    <br />
    <b>น้ำหนักรวมสินค้า / GROSS WEIGHT : </b> <label id="lblGrossWeight"></label>
    <br />
    <b>สรุปรายละเอียดงาน / JOB DETAILS : </b> <textarea id="lblDescription"></textarea>
    <br />
    <b>ที่อยู่ในการออกใบเสร็จค่ารถ : </b> <textarea id="lblBillTransportTo"></textarea>
    <br />
    <b>ที่อยู่ในการออกใบเสร็จค่าตู้และอื่นๆ : </b> <textarea id="lblBillTransportAddress"></textarea>
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
            $('#lblJNo').text(h.JNo);
            $('#lblTRemark').text(h.TRemark);
            $('#lblTotalContainer').text(h.TotalContainer);
            $('#lblForwarderName').text(h.TransportName);
            $('#lblPickupDate').text(ShowDate(h.CYDate));
            $('#lblPickupPlace').text(h.CYPlace);
            $('#lblPickupContact').text(h.CYContact); 
            $('#lblReturnDate').text(ShowDate(h.ReturnDate));
            $('#lblReturnPlace').text(h.ReturnPlace);
            $('#lblFactoryDate').text(ShowDate(h.FactoryDate));
            $('#lblFactoryTime').text(ShowTime(h.FactoryTime));
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblFactoryAddress').text(h.FactoryAddress);
            $('#lblFactoryContact').text(h.FactoryContact);
            $('#lblCarrierName').text(h.CarrierName);
            $('#lblConsignName').text(h.ConsigneeName);
            $('#lblInvProduct').text(h.InvProduct);
            $('#lblGrossWeight').text(h.GrossWeight + ' '+ h.GWUnit);
            $('#lblDescription').text(CStr(h.Description));
            $('#lblBillTransportTo').text(h.ShipperName);
            $('#lblBillTransportAddress').text(h.ShipperAddress);
            $('#dvRemark').html(CStr(h.Remark));

            let ctnList = '';
            for (let d of r.booking.data) {
                if (d.CTN_NO !== '') {
                    if (ctnList.indexOf(d.CTN_NO) < 0) {
                        if (ctnList !== '') ctlList += ',';
                        ctnList += d.CTN_NO;
                    }
                }
            }
        }
    });
</script>
