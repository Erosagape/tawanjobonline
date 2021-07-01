@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Fuel Refill Form"
    ViewBag.ReportName = "ใบสั่งเติมน้ำมัน/เชื้อเพลิง"
End Code
<div style="float:right">
    เลขที่ใบสั่งเติม : <label id="lblDocNo"></label>
    <hr />
</div>

<div style="display:flex">
    <div style="flex:2">
        <div style="display:flex">
            <div style="flex:20%">
                ปั้มที่เติม
            </div>
            <div style="flex:80%">
                <label id="lblStationCode"></label>
            </div>
        </div>
    </div>
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                วันที่
            </div>
            <div style="flex:80%">
                <label id="lblDocDate"></label>
            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:2">
        <div style="display:flex">
            <div style="flex:20%">
                ทะเบียนรถ
            </div>
            <div style="flex:80%">
                <label id="lblCarLicense"></label>
            </div>
        </div>
    </div>
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                ชื่อ พขร
            </div>
            <div style="flex:80%">
                <label id="lblDriver"></label>
            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:2">
        <div style="display:flex">
            <div style="flex:20%">
                ชนิดเชื้อเพลิง
            </div>
            <div style="flex:80%">
                <label id="lblFuelType"></label>
            </div>
        </div>
    </div>
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                เลขไมล์
            </div>
            <div style="flex:80%">
                <label id="lblMileEnd"></label>
            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:2">
        <div style="display:flex">
            <div style="flex:20%">
                ปริมาณ (ลิตร/กก)
            </div>
            <div style="flex:80%">
                <label id="lblBudgetVolume"></label>
            </div>
        </div>
    </div>
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                Job No
            </div>
            <div style="flex:80%">
                <label id="lblJNo"></label>
            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:2">
        <div style="display:flex">
            <div style="flex:20%">
                จำนวนเงิน (บาท)
            </div>
            <div style="flex:80%">
                <label id="lblBudgetValue"></label>
            </div>
        </div>
    </div>
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">

            </div>
            <div style="flex:80%">

            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                หมายเหตุ
            </div>
            <div style="flex:80%">
                <label id="lblRemark"></label>
            </div>
        </div>
    </div>
</div>
<hr />
ขอให้ทางปั้มเติมน้ำมันรายการดังกล่าวข้างต้นด้วย
<br />
<div style="display:flex">
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                ลงชื่อ
            </div>
            <div style="flex:80%">
                ..............................................................พนักงานขัยรถ
            </div>
        </div>
    </div>
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                ลงชื่อ
            </div>
            <div style="flex:80%">
                ..............................................................ผู้สั่งเติม
            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:1">
        <div style="display:flex">
            <div style="flex:20%">
                ลงชื่อ
            </div>
            <div style="flex:80%">
                ..............................................................พนักงานปั้มน้ำมัน
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    let branch = getQueryString("Branch");
    let code = getQueryString("Code");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetAddFuel?Branch=' + branch + '&Code=' + code).done(function (r) {
        if (r.addfuel.data.length > 0) {
            let d = r.addfuel.data[0];
            $('#lblDocNo').text(d.DocNo);
            $('#lblDocDate').text(ShowDate(d.DocDate));
            $('#lblStationCode').text(d.StationCode);
            $('#lblCarLicense').text(d.CarLicense);
            $('#lblDriver').text(d.Driver);
            $('#lblFuelType').text(d.FuelType);
            $('#lblMileEnd').text(d.MileEnd);
            $('#lblBudgetVolume').text(d.BudgetVolume);
            $('#lblJNo').text(d.JNo);
            $('#lblBudgetValue').text(d.BudgetValue);
            $('#lblRemark').text(d.Remark);
        }
    });
</script>