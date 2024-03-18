
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "DELIVERY NOTE"
    ViewBag.Title = "Delivery Form"
End Code
<style>
    * {
        font-size: 13px;
    }

    td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    div.div3 {
        border: 1px solid black;
        width: 100%;
    }
</style>
<div style="float:left;">
    เล่่มที่ <br />Book No.
    <label>_______________________</label>
</div>
<div style="float:right;">
    เลขที่ <br /> No.
    <label>_______________________</label>
</div>
<div style="width:98%;text-align:center;">
    ใบส่งสินค้า / Delivery Note
</div>
<br />
<div style="width:98%">
    วันเดือนปี <br /> Date
    <label>_______________________</label>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ชื่อลูกค้า<br />Customer Name
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        สถานที่ส่งสินค้า<br />Delivery Place
        <label>_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ทะเบียนหัว<br />Prime Mover License No.
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        ทะเบียนหาง<br />Trailer License No.
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        ประเภทรถ<br />Type of Truck
        <label>_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ต้นทาง<br />Place of Loading
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        วันที่/เวลา<br />Date/Time
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        ติดต่อ<br />Contact Person
        <label>_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ปลายทาง<br />Place of Discharge
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        วันที่/เวลา<br />Date/Time
        <label>_______________________</label>
    </div>
    <div style="flex:1">
        ติดต่อ<br />Contact Person
        <label>_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1;display:flex;flex-direction:column;" class="div3">
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:3">
                วันที่รับสินค้า/รับตู้เปล่า/รับตู้หนัก
                <br />
                Pickup/CY Empty/CY Laden
                <br />
                <label>_______________________</label>
            </div>
            <div style="flex:1">
                เวลา
                <br />
                Time
                <label>_______________________</label>
            </div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:3">
                วันที่ถึงหน้างาน
                <br />
                Arrival Date
                <label>_______________________</label>
            </div>
            <div style="flex:1">
                เวลา
                <br />
                Time
                <label>_______________________</label>
            </div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:3">
                วันที่เริ่มลงสินค้า/เริ่มบรรจุสินค้า
                <br />
                Start Unload/Load Date
                <br />
                <label>_______________________</label>
            </div>
            <div style="flex:1">
                เวลา
                <br />
                Time
                <label>_______________________</label>
            </div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:3">
                วันที่ลงสินค้าเสร็จ/บรรจุสินค้าเสร็จ
                <br />
                Completed Unload/Load Date
                <br />
                <label>_______________________</label>
            </div>
            <div style="flex:1">
                เวลา
                <br />
                Time
                <label>_______________________</label>
            </div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:3">
                วันที่คืนตุ้เปล่า/ส่งตู้หนัก
                <br />
                CY Return Empty date/CTN Loaded Date
                <br />
                <label>_______________________</label>
            </div>
            <div style="flex:1">
                เวลา
                <br />
                Time
                <label>_______________________</label>
            </div>
        </div>
        <br />
        <div style="width:100%" class="div3">
            <br />
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    <input type="checkbox" id="chkImport" /> Import / ขาเข้า
                </div>
                <div style="flex:1">
                    B/L No.
                    <label>_______________________</label>
                </div>
            </div>
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    <input type="checkbox" id="chkExport" /> Export / ขาออก
                </div>
                <div style="flex:1">
                    Booking No.
                    <label>_______________________</label>
                </div>
            </div>
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    <input type="checkbox" id="chkCrossborder" /> Cross Border / ผ่านแดน
                </div>
                <div style="flex:1">
                    Ref No.
                    <label>_______________________</label>
                </div>
            </div>
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    <input type="checkbox" id="chkDomestic" /> Domestic / ในประเทศ
                </div>
                <div style="flex:1">
                    B/L No.
                    <label>_______________________</label>
                </div>
            </div>
            <br />
        </div>
    </div>
    <div style="flex:1;display:flex;flex-direction:column">
        <div style="flex:1;text-align:center;" class="div3">
            รายการสินค้า<br />CARGO INFORMATION
        </div>
        <div style="flex:1" class="div3">
            <br />
            <br />
            <br />
            CONTAINER NO.
            <label>_______________________</label>
        </div>
        <div style="flex:1;display:flex;flex-direction:column">
            <div style="flex:1;text-align:center;" class="div3">
                สำหรับพนักงานขับรถรับส่งสินค้า<br />DRIVER ONLY
            </div>
            <div style="flex:1" class="div3">
                ผลการตรวจสอบสินค้าตอนรับสินค้า/รับตู้ <br />
                Cargo Condition at pickup place<br />
                <div style="display:flex;flex-direction:row">
                    <div>
                        <input type="checkbox" class="form-control checkbox" />
                    </div>
                    <div>
                        สภาพเรียบร้อยไม่เสียหาย<br />
                        All items received in good condition
                    </div>
                </div>
                <div style="display:flex;flex-direction:row">
                    <div>
                        <input type="checkbox" class="form-control checkbox" />
                    </div>
                    <div>
                        สภาพไม่เรียบร้อย/ชำรุด<br />
                        If no,please provide details of items in the cargo which are damaged and also described the extend of damage
                    </div>
                </div>
                ผลการตรวจสอบสินค้า/ตู้ตอนถึงหน้างาน
                <br />Cargo condition at load/unload place
                <div style="display:flex;flex-direction:row">
                    <div>
                        <input type="checkbox" class="form-control checkbox" />
                    </div>
                    <div>
                        สภาพเรียบร้อยไม่เสียหาย<br />
                        All items received in good condition
                    </div>
                </div>
                <div style="display:flex;flex-direction:row">
                    <div>
                        <input type="checkbox" class="form-control checkbox" />
                    </div>
                    <div>
                        สภาพไม่เรียบร้อย/ชำรุด<br />
                        If no,please provide details of items in the cargo which are damaged and also described the extend of damage
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        1. สำหรับพนักงาน
        <div style="width:100%" class="div3">
            ผู้ออกใบเวลา
            <br />Instructed By
            <label>_______________________</label>
            <br />บริษัทรถ
            <br />Company
            <label>_______________________</label>
            <div style="display:flex;flex-direction:row">
                <div style="flex:1">
                    คนขับรถ<br />Driver
                    <label>_______________________</label>
                </div>
                <div style="flex:1">
                    เบอร์โทร<br />Mobile No.
                    <label>_______________________</label>
                </div>
            </div>
        </div>
    </div>
    <div style="flex:1">
        2. สำหรับลูกค้า
        <div style="width:100%" class="div3">
            ผู้ว่าจ้าง/ตัวแทน ตรวจสอบสินค้าและได้รับสินค้าเรียบร้อยแล้ว<br />
            All Item received in good condition<br />
            <div style="display:flex;flex-direction:row">
                <div style="flex:1">
                    <br /><br />
                    ลงชื่อ<br />Signature
                    <label>_______________________</label>
                </div>
                <div style="flex:1">
                    <br /><br />
                    ผู้ว่าจ้าง/ตัวแทน<br />Client/Authorized Person
                    <label>_______________________</label>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let docno = getQueryString("Doc");
    if (docno !== '') {
        $.get(path + 'JobOrder/GetTransportReport?Branch=' + branch + '&Doc=' + docno, function (r) {
            if (r.transport.data.length > 0) {
                let j = r.transport.data[0];
                if (j.CTN_NO!==null>1) $('#lblCTN_NO').text(j.CTN_NO);
                if (j.Driver!==null>1) $('#lblDriver').text(j.Driver);
                $('#chkTRK4').prop('checked', (j.TruckType == 'TRK4'));
                $('#chkTRK6').prop('checked', (j.TruckType == 'TRK6'));
                $('#chkTRK10').prop('checked', (j.TruckType == 'TRK10'));
                $('#chk20F').prop('checked', (j.CTN_SIZE.indexOf('20F') >= 0));
                $('#chk40F').prop('checked', (j.CTN_SIZE.indexOf('40F') >= 0));
                if (j.TruckNO!==null>1) $('#lblTruckNO').text(j.TruckNO);
                if (j.EstDeliverDate!==null>1) $('#lblDeliveryDate').text(ShowDate(j.EstDeliverDate));
                if (j.DeliveryNo!==null>1) $('#lblDeliveryNo').text(j.DeliveryNo);
                if (j.ContactName!==null>1) $('#lblDeliveryTo').text(j.ContactName);
                if (j.Location!==null>1) $('#lblDeliveryAddr').text(j.Location);
                if (j.InvNo!==null>1) $('#lblInvNo').text(j.InvNo);
                if (j.CustRefNO!==null>1) $('#lblCustRefNo').text(j.CustRefNO);
                if (j.InvProduct!==null>1) $('#lblInvProduct').text(j.InvProduct);
                if (j.ProductQty!==null>1) $('#lblInvProductQtyUnit').text(j.ProductQty + ' ' + j.ProductUnit);
                if (j.GrossWeight!==null>1) $('#lblTotalGW').text(j.GrossWeight);
                if (j.VesselName!==null>1) $('#lblVesselName').text(j.VesselName);
                if (j.ETADate!==null>1) $('#lblETADate').text(ShowDate(j.ETADate));
                if (j.HAWB!==null>1) $('#lblHAWB').text(j.HAWB);
                if (j.MAWB!==null>1) $('#lblMAWB').text(j.MAWB);
                if (j.ShippingCmd!==null>1) $('#lblShippingCmd').text(j.ShippingCmd);
                if (j.NameThai!==null>1) $('#lblNameThai').text(j.NameThai);
                if (j.TaxNumber!==null>1) $('#lblTaxNumber').text(j.TaxNumber);
                if (j.TAddress1!==null>1) $('#lblTAddress').text(j.TAddress1 + ' '+ j.TAddress2);
            }
        });
    }
</script>