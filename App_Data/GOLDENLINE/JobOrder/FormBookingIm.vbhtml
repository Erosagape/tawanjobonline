
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
    <div class="row">
        <div class="col-sm-6">
            <b>BL NUMBER/BOOKING NO:</b>
        </div>
        <div class="col-sm-6">
            <label id="lblBookingNo"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>บริษัทรถ / TRANSPORT COMPANY :</b>
        </div>
        <div class="col-sm-6">
            <label id="lblForwarderName"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>ประเภทรถ / TYPE OF TRANSPORT : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblTruckType"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>จำนวนรถ / QUANTITY : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblTotalContainer"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>วันรับสินค้า / PICK UP GOODS DATE : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblPickupDate"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>สถานที่รับตู้ / PICK UP DEPOT : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblPickupPlace"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>หมายเลขตู้ / CONTAINER LISTS : </b>
        </div>
        <div class="col-sm-6">
            <div id="lblContainerList"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>เจ้าหน้าที่ตรวจปล่อย / SHIPPING OFFICER : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblShippingName"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>วันเวลาที่ส่งสินค้า / DELIVERY DATE :</b>
        </div>
        <div class="col-sm-6">
            <label id="lblFactoryDate"></label> / <label id="lblFactoryTime"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>สถานที่ส่งสินค้า / DELIVERY PLACE :</b>
        </div>
        <div class="col-sm-6">
            <label id="lblFactoryPlace"></label>
            <div id="lblFactoryAddress"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>บุคคลติดต่อ / CONTACT PERSON :</b>
        </div>
        <div class="col-sm-6">
            <label id="lblFactoryContact"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>สายเรือ,สายการบิน / AGENT : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblCarrierName"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>ผู้นำเข้า / CONSIGNEE : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblConsignName"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>สินค้า / GOODS DESCRIPTION : </b> 
        </div>
        <div class="col-sm-6">
            <label id="lblInvProduct"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>น้ำหนักรวมสินค้า / GROSS WEIGHT : </b> 
        </div>
        <div class="col-sm-6">
            <label id="lblGrossWeight"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>สรุปรายละเอียดงาน / JOB DETAILS : </b> 
        </div>
        <div class="col-sm-6">
            <div id="lblDescription"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>ที่อยู่ในการวางบิลรถ : </b> 
        </div>
        <div class="col-sm-6">
            <label id="lblBillTransportTo"></label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>ที่อยู่ในการออกใบเสร็จค่าท่า,ค่าตู้ : </b>
        </div>
        <div class="col-sm-6">
            <label id="lblBillToName"></label>
            <div id="lblBillToAddress"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <b>NOTE:</b>
        </div>
        <div class="col-sm-6">
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
            $('#lblTruckType').text(h.TruckType);
            $('#lblTotalContainer').text(h.TotalContainer);
            $('#lblForwarderName').text(h.TransportName);
            $('#lblPickupDate').text(ShowDate(h.CYDate));
            $('#lblPickupPlace').text(h.CYPlace);
            $('#lblShippingName').text(h.ShippingName); 
            $('#lblFactoryDate').text(ShowDate(h.FactoryDate));
            $('#lblFactoryTime').text(ShowTime(h.FactoryTime));
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblFactoryAddress').html(CStr(h.FactoryAddress));
            $('#lblFactoryContact').text(h.FactoryContact);
            $('#lblCarrierName').text(h.CarrierName);
            $('#lblConsignName').text(h.ConsigneeName);
            $('#lblInvProduct').text(h.InvProduct);
            $('#lblGrossWeight').text(h.GrossWeight + ' '+ h.GWUnit);
            $('#lblDescription').html(CStr(h.Description));
            $('#lblBillTransportTo').text(h.PaymentBy);
            $('#lblBillToName').text(h.PaymentBy);
            $('#lblBillTransportAddress').html(CStr(h.PaymentCondition));

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
            $('#lblContainerList').html(ctnList);
        }
    });
</script>
