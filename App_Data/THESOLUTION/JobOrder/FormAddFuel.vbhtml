@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Fuel Refill Form"
    ViewBag.ReportName = "ใบสั่งเติมน้ำมัน/เชื้อเพลิง"
End Code
<style>
    table {
        padding: 10px;
    }

    tr td {
        border-color: white;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .box {
        width: 100%;
        border: 2px solid black;
        height: 150px;
    }

    .dottedUnderline {
        border-bottom: 2px dotted black;
    }
    .underline {
        border-bottom: 2px solid black;
    }
</style>

    <table class="container table">
        <thead>
            <tr>
                <td class="center" colspan="5">
                    <label for="" style="border:2px solid black;padding: 10px;border-radius: 10px;position: relative;top: 0em;">
                        ใบสั่งเติมน้ำมัน
                    </label>
                </td>
            </tr>
            <tr>
                <td class="underline" colspan="3"><label id="date"></label> <label id="time"></label></td>
                <td class="underline" colspan="2">เลขที่ใบสั่งเติม <label id="docNo">39990</label></td>
            </tr>
        </thead>


        <tbody>
            <tr>
                <td style="width:20%">ชื่อปั๊มที่เติม</td>
                <td class="dottedUnderline" style="width:40%" colspan="2"><label id="fillingStation">เดอะโซ</label></td>
                <td style="width:10%">วันที่</td>
                <td class="dottedUnderline" style="width:30%"><label id="fillDate">15 มิ.ย. 2564</label></td>
            </tr>
            <tr>
                <td>ทะเบียนรถที่เติม</td>
                <td class="dottedUnderline" colspan="2"><label id="carLicenseNo">72-5876 สป รถหัวลาก</label></td>
                <td>ชื่อ พขร</td>
                <td class="dottedUnderline"><label id="driverName">ประจวบ คำปุย</label></td>
            </tr>
            <tr>
                <td>ชนิดเชื้อเพลิง</td>
                <td class="dottedUnderline" colspan="2"><label id="fuelType">ดีเซล</label></td>
                <td>เลขไมล์</td>
                <td class="dottedUnderline center"><label id="mile">372645</label></td>
            </tr>
            <tr>
                <td>ปริมาตร(ลิตร|กก.)</td>
                <td class="dottedUnderline right"><label id="volume">520</label></td>
                <td class="dottedUnderline" style="display:flex">
                    (
                    <div style="flex: 1;text-align: center;">
                        <label id="volumeText">ห้าร้อยยี่สิบ</label>
                    </div>
                    )
                </td>
                <td>Job no. : </td>
                <td class="dottedUnderline"><label id="jobNo">44523</label></td>
            </tr>
            <tr>
                <td>จำนวนเงิน (บาท)</td>
                <td class="dottedUnderline right"><label id="baht"></label></td>
                <td class="dottedUnderline" style="display:flex">
                    (
                    <div style="flex: 1;text-align: center;"><label id="bahtText"></label></div>
                    )
                </td>
                <td> </td>
                <td></td>
            </tr>
            <tr>
                <td>หมายเหตุ</td>
                <td class="dottedUnderline" colspan="4"><label id="weight">น้ำหนัก 11559 ตัน</label></td>
            </tr>
            <tr>
                <td colspan="5">ขอให้ทางปั๊มเดิมน้ำมันดังกล่าวข้างต้นด้วย</td>
            </tr>
            <tr>
                <td colspan="3">
                    ลงชื่อ .............................................................................. พนักงานขับรถ
                </td>

                <td colspan="4">
                    ลงชื่อ .............................................................................. ผู้สั่งเติม
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    ลงชื่อ .............................................................................. พนักงานปั๊มน้ำมัน
                </td>
            </tr>
        </tbody>
    </table>

<script type="text/javascript">
    let branch = getQueryString("Branch");
    let code = getQueryString("Code");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetAddFuel?Branch=' + branch + '&Code=' + code).done(function (r) {
        if (r.addfuel.data.length > 0) {
            let d = r.addfuel.data[0];
            //$('#date').text(new Date().toString());
            //$('#time').text(ShowTime(new Date().toString()));
            $('#docNo').text(d.DocNo);
            $('#fillingStation').text(d.StationCode);
            $('#fillDate').text(ShowDate(d.DocDate));
            $('#carLicenseNo').text(d.CarLicense);
            $('#driverName').text(d.Driver);
            $('#fuelType').text(d.FuelType);
            $('#mile').text(d.MileEnd);
            $('#volume').text(d.ActualVolume);
            $('#volumeText').text(CNumThai(d.ActualVolume).replace("บาทถ้วน",""));
            $('#jobNo').text(d.JNo);
            $('#baht').text(d.TotalAmount);
            $('#bahtText').text(CNumThai(d.TotalAmount));
            $('#weight').text(d.Remark);
        }
    });
</script>