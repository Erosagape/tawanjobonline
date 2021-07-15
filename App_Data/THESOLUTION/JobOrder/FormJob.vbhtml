@Code
    ViewData("Title") = "FormJob"
    Layout = "~/Views/Shared/_Report.vbhtml"
End Code
<style>
    table {
        padding: 10px;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .box {
        width: 100%;
        height: 150px;
        border: 2px solid black;
    }
    .table thead > tr > th, .table tbody > tr > th, .table tfoot > tr > th, .table thead > tr > td, .table tbody > tr > td, .table tfoot > tr > td {
        border-style: none;
        border-color: white;
    }

    .upperLine {
        border-top: 1px solid black;
    }

    .underLine {
        border-bottom: 1px solid black;
    }

    .roundBorder {
        border: 1px solid black;
        padding: 10px;
    }
</style>
<h1 class="center">ใบสั่งงาน</h1>
<table>
    <tbody>
        <tr>
            <td><label id="orderNoLbl">เลขที่ Order</label></td>
            <td>:</td>
            <td colspan="8"><label id="orderNo"></label></td>
        </tr>
        <tr>
            <td style="width:80px"><label>เลขที่ใบสั่งงาน</label></td>
            <td style="width:10px">:</td>
            <td style="width:150px"><label id="docNo"></label></td>
            <td style="width:50px"><label>Ref No.</label></td>
            <td style="width:10px">:</td>
            <td style="width:150px"><label id="refNo"></label></td>
            <td style="width:50px"><label>วันที่สั่งงาน</label></td>
            <td style="width:10px">:</td>
            <td style="width:80px"><label id="docDate"></label></td>
            <td style="width:50px"></td>
        </tr>
        <tr>
            <td><label>ชื่อโรงงาน</label></td>
            <td>:</td>
            <td><label id="factory"></label></td>
            <td></td>
            <td></td>
            <td></td>
            <td><label>ชื่อสินค้า</label></td>
            <td>:</td>
            <td><label id="product"></label></td>
            <td></td>
        </tr>
        <tr>
            <td><label>เอเยนต์เรือ</label></td>
            <td>:</td>
            <td><label id="agent"></label></td>
            <td></td>
            <td></td>
            <td></td>
            <td><label>ชื่อเรือ</label></td>
            <td>:</td>
            <td><label id="vessel"></label></td>
            <td></td>
        </tr>
        <tr>
            <td><label>ท่าปลายทาง</label></td>
            <td>:</td>
            <td><label id="destPort"></label></td>
            <td></td>
            <td></td>
            <td></td>
            <td><label>Last Load</label></td>
            <td>:</td>
            <td><label id="lastLoad"></label></td>
            <td></td>
        </tr>
        <tr>
            <td><label>เบอร์ตู้ (1)</label></td>
            <td>:</td>
            <td><label id="containerNo"></label></td>
            <td><label>เบอร์ซีล</label></td>
            <td>:</td>
            <td><label id="sealNo"></label></td>
            <td><label>เบอร์บุ๊คกิ้ง</label></td>
            <td>:</td>
            <td><label id="bookingNo"></label></td>
            <td></td>
        </tr>
        <tr>
            <td><label>เบอร์ตู้ (2)</label></td>
            <td>:</td>
            <td><label id="containerNo2"></label></td>
            <td><label>เบอร์ซีล</label></td>
            <td>:</td>
            <td><label id="sealNo2"></label></td>
            <td><label>เบอร์บุ๊คกิ้ง</label></td>
            <td>:</td>
            <td><label id="bookingNo2"></label></td>
            <td></td>
        </tr>
        <tr>
            <td><label>สถานที่รับตู้</label></td>
            <td>:</td>
            <td><label id="getContainerPlace"></label></td>
            <td></td>
            <td></td>
            <td></td>
            <td><label>วันที่รับตู้</label></td>
            <td>:</td>
            <td><label id="getContainerDate"></label></td>
            <td class="right"><label id="getContainerTime"></label></td>
        </tr>
        <tr>
            <td><label>สถานที่บรรจุ</label></td>
            <td>:</td>
            <td><label id="loadPlace"></label></td>
            <td></td>
            <td></td>
            <td></td>
            <td><label>วันที่บรรจุ</label></td>
            <td>:</td>
            <td><label id="loadDate"></label></td>
            <td class="right"><label id="loadTime"></label></td>
        </tr>
        <tr>
            <td><label>สถานที่คืนตู้</label></td>
            <td>:</td>
            <td><label id="returnContainerPlace"></label></td>
            <td></td>
            <td></td>
            <td></td>
            <td><label>วันที่คืนตู้</label></td>
            <td>:</td>
            <td><label id="returnContainerDate"></label></td>
            <td class="right"><label id="returnContainerTime"></label></td>
        </tr>
        <tr class="roundBorder">
            <td class="right"><label>คำสั่งลากตู้</label></td>
            <td>:</td>
            <td colspan="8"><label id="route"></label></td>
        </tr>
        <tr>
            <td><label>หมายเหตุ</label></td>
            <td>:</td>
            <td colspan="8"><label id="remark"></label></td>
        </tr>
        <tr>
            <td><label>ชื่อ พขร</label></td>
            <td>:</td>
            <td><label id="driverName"></label></td>
            <td><label>เบอร์รถ</label></td>
            <td>:</td>
            <td><label id="carID"></label></td>
            <td><label>ทะเบียนรถ</label></td>
            <td>:</td>
            <td><label id="carLicenseNo"></label></td>
            <td class="right"><label id="trialer"></label></td>
        </tr>
        <tr>
            <td colspan="4">
                <div class="center" style="white-space: nowrap;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <p>................................................................................................................................................</p>
                    <p>ลงชื่อ พนักงานขับรถ</p>
                </div>
                <div style="white-space: nowrap;">
                    <br />
                    <br />
                    <p>ลงชื่อ ...................................................................................................................................</p>
                    <p>เวลารถเข้าถึงโรงงาน .......................................................................................................</p>
                    <p class="center">ผู้ว่าจ้างหรือตัวแทนเจ้าของสินค้า</p>
                </div>
            </td>
            <td></td>
            <td></td>
            <td colspan="4">
                <div class="center" style="white-space: nowrap;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <p>................................................................................................................................................</p>
                    <p>ลงชื่อ ผู้สั่งงาน</p>
                </div>
                <div style="white-space: nowrap;">
                    <br />
                    <br />
                    <p>ลงชื่อ .....................................................................................................................................</p>
                    <p>เวลารถออกจากโรงงาน ......................................................................................................</p>
                    <p class="center">ผู้ว่าจ้างหรือตัวแทนเจ้าของสินค้า</p>
                </div>
            </td>
        </tr>
    </tbody>
</table>
<div class="container box">
    ออกใบเสร็จในนาม KHEMPHONE COOLING (อาเจียง)
</div>

<script type="text/javascript"> 

    let path = '@Url.Content("~")';
    let br = getQueryString('BranchCode');
    let jno = getQueryString('JNo');
    if (br != "" && jno != "") {
        GetJob(br, jno);
    }

    function GetJob(Branch, Job) {
        $.get(path + 'joborder/getjobosql?branch=' + Branch + '&jno=' + Job)
        .done(function (r) {
            if (r.job.data.length > 0) {
                var rec = r.job.data[0];
                $('#orderNo').text(rec.JNo);
                $('#docNo').text(rec.DocNo);
                $('#refNo').text(rec.CustRefNO);
                $('#factory').text(rec.Factory);
                $('#product').text(rec.Product);
                $('#agent').text(rec.AgentCode);
                $('#docDate').text(CDateEN(rec.DocDate));          
                $('#vessel').text(rec.VesselName);
                $('#destPort').text(rec.Destination);
                $('#lastLoad').text(CDateEN(rec.Finish));
                $('#containerNo').text(rec.CTN_SIZE + " " + rec.CTN_NO);
                $('#sealNo').text(rec.SealNumber);
                $('#bookingNo').text(rec.BookingNo);
                $('#getContainerPlace').text(rec.FactoryAddress);
                $('#getContainerDate').text(CDateEN(rec.FactoryTime));
                $('#getContainerTime').text(rec.FactoryTime.substring(11,16));
                $('#loadPlace').text(rec.PackingAddress);
                $('#loadDate').text(CDateEN(rec.PackingTime));
                $('#loadTime').text(rec.PackingTime.substring(11, 16));
                $('#returnContainerPlace').text(rec.ReturnAddress);
                $('#returnContainerDate').text(CDateEN(rec.ReturnTime));
                $('#returnContainerTime').text(rec.PackingTime.substring(11, 16));
                $('#route').text(rec.DeliveryAddr);
                $('#remark').text(rec.Remark);
                $('#driverName').text(rec.Driver);
                $('#carID').text(rec.TruckNo);
                $('#carLicenseNo').text(rec.CarLicense);
                $('#trialer').text("");
               
                console.log(JSON.stringify(r));
            }
        });

    }
    //$('#orderNo').text("20326");
    //$('#docNo').text("44523");
    //$('#refNo').text("20326");
    //$('#docDate').text("15/06/21");
    //$('#factory').text("KHEMPHONE COOLING (อาเจียง)");
    //$('#product').text("");
    //$('#agent').text("");
    //$('#vessel').text("");
    //$('#destPort').text("");
    //$('#lastLoad').text("");
    //$('#containerNo').text("40'HC  EGHU9467581");
    //$('#sealNo').text("");
    //$('#bookingNo').text("EGLV156100340492");
    //$('#containerNo2').text("");
    //$('#sealNo2').text("");
    //$('#bookingNo2').text("");
    //$('#getContainerPlace').text("เคอรี่");
    //$('#getContainerDate').text("16/06/21");
    //$('#getContainerTime').text("0.00");
    //$('#loadPlace').text("ปากซัน(ข้ามบึงกาฬ)เวียงจันทร์");
    //$('#loadDate').text("17/06/21");
    //$('#loadTime').text("0.00");
    //$('#returnContainerPlace').text("SDS-ACUTECH");
    //$('#returnContainerDate').text("18/06/21");
    //$('#returnContainerTime').text("0.00");
    //$('#route').text("แหลมฉบัง -> เคอรี่ -> ปากซัน(ข้ามบึงกาฬ)เวียงจันทร์ -> SDS-ACUTECH");
    //$('#remark').text("*** DEM 21 วัน/DET 21 วัน***");
    //$('#driverName').text("ประจวบ คำปุย");
    //$('#carID').text("72-5876");
    //$('#carLicenseNo').text("72-5876 สป");

    //getScriptFromScratch();

    function getScriptFromScratch() {
        let size = 0
        let labels = document.getElementsByTagName("LABEL");
        for (let index = 0; index < labels.length; index++) {
            const element = labels[index];
            if (element.id !== "") {

                console.log("$(#" + element.id + "').text('" + element.innerText + "');");
                size++;
            }
        }
        console.log(size)
    }


</script>
