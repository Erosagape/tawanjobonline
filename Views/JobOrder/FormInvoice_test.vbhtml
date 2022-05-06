@Code
    ViewData("Title") = "FormInvoice"
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
End Code
<style>
</style>

    ON BEHALF OF : _________________________-

    <h1 style="text-align: center;">
        DEVERY NOTICE<br>
        (ใบส่งสินค้า/ใบแจ้งการส่งสินค้า)
    </h1>
    <div style="display: flex;width: 100%;">
        <div>
            STAFF ON UNITED GLOBE LOGISTICS (THAILAND) CO.,LTD.
        </div>
        <div style="flex:1;text-align: right;">
            INV NO. : _______________
        </div>
    </div>
    <div> DELIVERY OF DESCRIPTION (รายละเอียดสินค้า)</div>
    <div style="display: flex;width: 100%;">
        <div style="width:5%">1</div>
        <div style="width:15%;border-bottom: 1px black solid;"></div>
        <div style="width:20%">PACKAGES</div>
        <div style="width:15%;border-bottom: 1px black solid;"></div>
        <div style="width:20%">WEIGHT</div>
        <div style="width:25%;border-bottom: 1px black solid;"></div>
    </div>
    <div style="display: flex;width: 100%;">
        <div style="flex:40;">DESTINATION (สถานที่ส่งของ)</div>
        <div style="flex:60;border-bottom: 1px black solid;"></div>
    </div>
    <div style="display: flex;width: 100%;">
        <div>TRUCK DETAILS (รายละเอียดรถบรรทุก)</div>
    </div>
    <div style="display: flex;width: 100%;">
        <div style="width:40%"> DELIVERY BY TRUCK/TRAILER NO.<br>(ทะเบียนรถ)</div>
        <div style="width:35%;border-bottom: 1px black solid;"></div>
        <div style="width:10%;text-align: right;">TOTAL :</div>
        <div style="width:15%;border-bottom: 1px black solid;"></div>
    </div>

    <div style="display: flex;width: 100%;"> SIGNATURE OF RECEIVER (ส่วนของผู้รับสินค้า)</div>
    <div style="display: flex;width: 100%;">
        <div style="flex:30;">RECEIVER'S NAME <br>(ชื่อผู้รับสินค้า)</div>
        <div style="flex:35;border-bottom: 1px black solid;"></div>
        <div style="flex:10">DIVISION</div>
        <div style="flex:25;border-bottom: 1px black solid;"></div>
    </div>

    <div style="display: flex;width: 100%;">
        <div style="flex:30;">DATE OF RECEIVED CARCGO <br>(วันที่รับสินค้า)</div>
        <div style="flex:70;border-bottom: 1px black solid;"> </div>
    </div>

    <div style="display: flex;width: 100%;">
        <div style="flex:30;">REMARKS (กรณีสินค้าชำรุด)</div>
        <div style="flex:70;border-bottom: 1px black solid;"> </div>





    </div>
    ทางบริษัทฯ จะไม่รับชอบค่าเสียหายของสินค้าหลังจากมีการเซ็นรับสภาพลักษณะสินค้า
    กรุณาอย่าทำใบส่งสินค้า ยับ หรือ เสียหาย ขอบคุณมาก
    <script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    if (br !== '' && doc !== '') {
        $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
            if (r.booking !== null) {
                let h = r.booking.data[0];
                $('#lblJNo').html(h.JNo);
                $('#lblForwarder').html(h.ForwarderName);
                $('#lblClearPortNo').html(h.ClearPortNo);
                $('#lblCYPlace').html(h.CYPlace);
                $('#lblCYDate').html(ShowDate(h.CYDate));
                $('#lblReturnPlace').html(h.PackingPlace);
                $('#lblReturnDate').html(ShowDate(h.ReturnDate));
                $('#lblCommodity').html(CStr(h.ProjectName));
                $('#lblHSCode').html(h.ShippingCmd);
                $('#lblShipperName').html(h.NotifyName);
                $('#lblTotalContainer').html(h.TotalContainer);
                $('#lblDestinationPort').html(h.FactoryPlace);
                $('#lblCSName').html(h.CSName);
                $('#lblCSTel').html(h.CSTel);
            }
        });
    }
    </script>
