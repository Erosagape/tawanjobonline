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
        font-size: 13px;
    }
</style>
<div style="text-align:right;width:100%">
    DATE : <label id="lblPrintDate">@DateTime.Now.ToString("dd/MM/yyyy")</label>
</div>
<br />
<div style="text-align:left">
    <label id="subj">เรื่อง  </label><span id="lblSubj">ขอใช้จดหมายรับ D/O เนื่องจาก SURRENDER <input type="text" id="txtType" value="OB/L" /></span>
    <br /><br />
    <label id="to">เรียน </label><span id="lblTo">เจ้าหน้าที่แผนกขาเข้าทางเรือ</span>
</div>
<br />
<br />
&emsp; เนื่องด้วยบริษัท <label id="lblNameThai"></label>
<br />
มีสินค้าเข้ามากับเรือ <label id="lblVesselName"></label>
เที่ยววันที่ <label id="lblETADate"></label>
<br />
ตาม B/L No: <label id="lblHAWB"></label>
จำนวน <label id="lblProductQty"></label>  <label id="lblProductUnit"></label>
<br />
ซึ่งผู้ขายของบริษัทฯ ได้ทำการ <input type="text" id="txtType2" value="SURRENDER ORIGINAL B/L" /> ทางต้นทางไว้เรียบร้อยแล้ว
<br />
<br />
&emsp; ดังนั้นทางบริษัทฯ จึงขอรับ D/O โดยใช้จดหมายของทางบริษัทฯ เพิ้อไปทำการปล่อยสินค้า ซึ่งในการนี้ หากเกิดความเสียหายใดๆ เกิดขึ้นทุกประการ ทางบริษัทฯ ยินดีจะรับผิดชอบความเสียหายนั้น
<br />
<br />
&emsp; จึงเรียนมาเพื่อทราบและโปรดพิจารณาดำเนินการ
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
            $('#lblETADate').text(CDateEN(dr.ETADate));
            $('#lblVesselName').text(dr.VesselName);
            $('#lblNameThai').text(dr.CustTName);
            $('#lblProductQty').text(dr.InvProductQty);
            ShowInvUnit(path, dr.InvProductUnit, '#lblProductUnit');
            $('#lblHAWB').text(dr.HAWB);
        }
    });
</script>