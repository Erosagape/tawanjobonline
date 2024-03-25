
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

    label {
        font-weight: bold;
    }

    div.div3 {
        border: 1px solid black;
        width: 100%;
    }
</style>
<div style="float:left;">
    หมายเลขงาน<br />Job No.
    <label id="lblJobNo">_______________________</label>
</div>
<div style="float:right;">
    เลขที่ <br /> No.
    <label id="lblDeliveryNo">_______________________</label>
</div>
<div style="width:98%;text-align:center;">
    ใบส่งสินค้า
</div>
<br />
<div style="width:98%">
    วันเดือนปี <br /> Date
    <label id="lblLoadDate">_______________________</label>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ชื่อลูกค้า<br />Customer Name
        <label id="lblCustName">_______________________</label>
    </div>
    <div style="flex:1">
        สถานที่ส่งสินค้า<br />Delivery Place
        <label id="lblFactoryAddress">_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ต้นทาง<br />Place of Loading
        <label id="lblCYPlace">_______________________</label>
    </div>
    <div style="flex:1">
        วันที่/เวลา<br />Date/Time
        <label id="lblCYDate">_______________________</label>
    </div>
    <div style="flex:1">
        ประเภทรถ<br />Type of Truck
        <label id="lblTRemark">_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        ปลายทาง<br />Place of Discharge
        <label id="lblFactoryPlace">_______________________</label>
    </div>
    <div style="flex:1">
        วันที่/เวลา<br />Date/Time
        <label id="lblFactoryDate">_______________________</label>
    </div>
    <div style="flex:1">
        ติดต่อ<br />Contact Person
        <label id="lblFactoryContact">_______________________</label>
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1">
        สำหรับคนขับรถ / For Driver
    </div>
    <div style="flex:1">
    </div>
</div>
<div style="width:98%;display:flex;flex-direction:row">
    <div style="flex:1;display:flex;flex-direction:column;" class="div3">
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:1">
                Name<br />ชื่อคนขับรถ
            </div>
            <div style="flex:2;border-bottom:1px solid black"></div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:1">
                Tel.<br />เบอร์โทร
            </div>
            <div style="flex:2;border-bottom:1px solid black"></div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:1">
                Haulage No.<br />ทะเบียนหัว
            </div>
            <div style="flex:2;border-bottom:1px solid black"></div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:1">
                Chassis No.<br />ทะเบียนหาง
            </div>
            <div style="flex:2;border-bottom:1px solid black"></div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:1">
                Arrive At Factory.<br />เวลาถึงโรงงาน
            </div>
            <div style="flex:2;border-bottom:1px solid black"></div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:1">
                Load-Unload Already<br />เวลาออกจากโรงงาน
            </div>
            <div style="flex:2;border-bottom:1px solid black"></div>
        </div>
        <br />
        <div style="width: 100%;display:flex;flex-direction:row;">
            <div style="flex:2">
                Cargos and Container Damage<br />การชำรุดของสินค้าหรือตู้สินค้า
            </div>
            <div style="flex:3;border-bottom:1px solid black"></div>
        </div>
        <br />
        @*
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
                    <label>___________</label>
                </div>
            </div>
            <br />
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    ทะเบียนหัว<br />Prime Mover License No.<br />
                    <label>_______________________</label>
                </div>
                <div style="flex:1">
                    ทะเบียนหาง<br />Trailer License No.<br />
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
                    <label>___________</label>
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
                    <label>___________</label>
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
                    <label>___________</label>
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
                    <label>___________</label>
                </div>
            </div>
                <br>
        *@
        <div style="width:100%" class="div3">
            <br />
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    <input type="checkbox" id="chkImport" /> Import / ขาเข้า
                </div>
                <div style="flex:1">
                    B/L No.
                    <label id="lblImportBooking">_______________________</label>
                </div>
            </div>
            <div style="width: 100%;display:flex;flex-direction:row;">
                <div style="flex:1">
                    <input type="checkbox" id="chkExport" /> Export / ขาออก
                </div>
                <div style="flex:1">
                    Booking No.
                    <label id="lblExportBooking">_______________________</label>
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
        <div style="flex:5%;text-align:center;" class="div3">
            รายการสินค้า<br />CARGO INFORMATION
        </div>
        <div style="flex:30%;position:relative" class="div3">
            <label id="lblInvProduct"></label>
            <div style="width: 100%;vertical-align:middle; position: absolute; bottom: 0; left: 0;">
                CONTAINER NO.
                <div style="display:flex;flex-direction:row;width:100%">
                    <div style="flex:1;flex-direction:column;" id="dvConOdd">

                    </div>
                    <div style="flex:1;flex-direction: column;" id="dvConEven">

                    </div>
                </div>
            </div>
        </div>
        <div style="flex:65%;display:flex;flex-direction:column">
            <div style="flex:1;text-align:center;" class="div3">
                สำหรับพนักงานขับรถรับส่งสินค้า<br />DRIVER ONLY
            </div>
            <div style="flex:10" class="div3">
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
            <br />
            <br />
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
                    <label>________________</label>
                </div>
            </div>            
            <br />
        </div>
    </div>
    <div style="flex:1">
        2. สำหรับลูกค้า
        <div style="width:100%" class="div3">
            ผู้ว่าจ้าง/ตัวแทน ตรวจสอบสินค้าและได้รับสินค้าเรียบร้อยแล้ว<br />
            All Item received in good condition<br />
            <div style="display:flex;flex-direction:row">
                <div style="flex:1">
                    <br /><br /><br />
                    ลงชื่อ<br />Signature
                    <label>_______________________</label>
                    <br />
                    <br />
                </div>
                <div style="flex:1">
                    <br /><br /><br />
                    ผู้ว่าจ้าง/ตัวแทน<br />Client/Authorized Person<br />
                    <label id="lblConsignName" style="font-size:10px;">_______________________</label>
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
                $('#lblJobNo').text(j.JNo);
                $('#lblDeliveryNo').text(j.DeliveryNo);
                $('#lblLoadDate').text(ShowDate(j.LoadDate));
                $('#lblCustName').text(j.NameThai);
                $('#lblConsignName').text(j.NameThai);
                $('#lblFactoryAddress').text(j.FactoryAddress);
                $('#lblFactoryPlace').text(j.FactoryAddress);
                $('#lblTRemark').text(j.TRemark);
                $('#lblCYPlace').text(j.CYPlace);
                $('#lblCYDate').text(ShowDate(j.CYDate));
                $('#lblFactoryDate').text(ShowDate(j.FactoryDate));
                $('#lblFactoryContact').text(j.FactoryContact);
                $('#lblInvProduct').text(j.InvProduct);
                let ctn = '';
                let htmlOdd = '';
                let htmlEven = '';
                for (let i = 0; i < r.transport.data.length; i++) {
                    ctn = '<input type="checkbox" />';
                    ctn += r.transport.data[i].CTN_NO + '';
                    if (Math.abs((i + 1) % 2) == 0) {
                        if (htmlEven !== '') htmlEven += '<br>';
                        htmlEven += ctn;
                    } else {
                        if (htmlOdd !== '') htmlOdd += '<br>';
                        htmlOdd += ctn;
                    }
                }
                $('#dvConEven').html(htmlEven);
                $('#dvConOdd').html(htmlOdd);
                $('#lblImportBooking').text(j.JobType == 1 ? j.BookingNo : '');
                $('#lblExportBooking').text(j.JobType == 2 ? j.BookingNo : '');
            }
        });
    }
</script>