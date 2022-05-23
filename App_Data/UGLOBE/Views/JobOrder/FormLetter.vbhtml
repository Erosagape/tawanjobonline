@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = ""
    ViewBag.Title = "Delivery Order Letter"
End Code
<style>
    #dvFooter {
        display: none;
    }

    input[type="text"] {
        border: none;
    }

    * {
        font-size: 12px;
    }
</style>
<div style="padding:30px 30px 30px 30px">
    <div style="text-align:right;width:100%">
        DATE : <label id="lblPrintDate">@DateTime.Now.ToString("dd/MM/yyyy")</label>
    </div>
    <br />
    <div style="text-align:left">
        <label id="subj">เรื่อง  </label><span id="lblSubj">ขอรับ D/O โดยปราศจาก B/L ต้นฉบับ</span>
        <br /><br />
        <label id="to">เรียน </label><span id="lblTo">เจ้าหน้าที่แผนกเรือเข้า </span> <label id="lblForwarderName">บริษัท__________________________________________</label>
    </div>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  เนื่องด้วยบริษัท <label id="lblNameThai"></label>
    มีสินค้าเข้ามากับเรือ <label id="lblVesselName"></label>
    <br />
    เที่ยววันที่ <label id="lblETADate"></label>  &nbsp; มีสินค้ามาจาก PORT <label id="lblInterPort"></label> &nbsp;
    จำนวน <label id="lblProductQty"></label>  <label id="lblProductUnit"></label> / <label id="lblGrossWeight"></label>  <label id="lblWeightUnit"></label> / <label id="lblMeasurement"></label> CBM <br />
    <br />
    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    CONSIGNEE <label id="lblConsignName"></label>
    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    B/L No: <label id="lblHAWB"></label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ซึ่งการนำสินค้าเข้าในครั้งนี้ ผู้ขายของบริษัทฯ ได้ทำการ <input type="text" id="txtType2" style="width:200px;" value="SURRENDER ORIGINAL B/L" />
    <br />ไว้กับทางต้นทางเรียบร้อยแล้ว
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ดังนั้นทางบริษัทฯ จึงขอรับ D/O โดยปราศจาก B/L ต้นฉบับ เพิ้อไปทำการตรวจปล่อยสินค้า
    <br />ซึ่งในการนี้ หากเกิดความเสียหายใดๆ เกิดขึ้น ทางบริษัทฯ ยินดีจะรับผิดชอบความเสียหายที่เกิดขึ้นนั้นทุกประการ
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  จึงเรียนมาเพื่อทราบและโปรดพิจารณาดำเนินการ
    <br />
    <div style="display:flex">
        <div style="width:50%">

        </div>
        <div style="width:50%;text-align:center">
            ขอแสดงความนับถือ
            <br />
            <br />
            <br />
            <br />
            ______________________
            <br />
            (@ViewBag.UserName)<br />
            แผนกเรือขาเข้า
        </div>
    </div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let job = getQueryString("JNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetJobReport?Branch=' + br + '&JNo=' + job).done(function (r) {
        if (r.job.data.length > 0) {
            let dr = r.job.data[0];
            let strSub = '';
            let strTo = '';
            if (dr.JobType == 1) {
                strTo+='เจ้าหน้าที่แผนกตรวจปล่อยขาเข้า';
            } else {
                strTo+='เจ้าหน้าที่แผนกตรวจปล่อยขาออก';
            }
            if (dr.ShipBy == 1) {
                strTo += 'ทางอากาศ';
            } else {
                strTo += 'ทางเรือ';
            }
            $('#lblTo').html(strTo);
            $('#lblETADate').text(ShowDate(dr.ETADate));
            $('#lblVesselName').text(dr.VesselName);
            $('#lblForwarderName').text(dr.ForwarderName); 
            $('#lblConsignName').text(dr.ConsigneeName);
            $('#lblNameThai').text(dr.CustTName);
            $('#lblProductQty').text(dr.InvProductQty);
            $('#lblGrossWeight').text(dr.TotalGW);
            $('#lblWeightUnit').text(dr.GWUnit);
            $('#lblMeasurement').text(dr.Measurement);
            ShowInterPort(path, dr.InvCountry, dr.InvInterPort, '#lblInterPort');
            ShowInvUnit(path, dr.InvProductUnit, '#lblProductUnit');
            $('#lblHAWB').text(dr.HAWB);
        }
    });
</script>