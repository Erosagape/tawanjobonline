
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = ""
    ViewBag.Title = "Delivery Order Letter"
End Code
<div style="text-align:right;width:100%">
    SHIPMENT NO :<label id="lblJNo"></label><br />
    DATE : <label id="lblPrintDate">@DateTime.Now.ToString("dd/MM/yyyy")</label>
</div>
<br />
<div style="text-align:left">
    <label id="subj">เรื่อง  </label>ขอใช้จดหมายรับ D/O เนื่องจาก OB/L SURRENDER
    <br /><br />
    <label id="to">เรียน </label>เจ้าหน้าที่แผนกขาเข้าทางเรือ
</div>
<br />
<br />
&emsp; เนื่องด้วยบริษัท <label id="lblNameThai"></label>
<br />
มีสินค้าเข้ามากับเรือ <label id="lblVesselName"></label>
เที่ยววันที่ <label id="lblETADate"></label>
<br />
ตาม B/L No: <label id="lblHAWB"></label>
จำนวน <label id="lblProductQtyUnit"></label>
<br />
ซึ่งผู้ขายของบริษัทฯ ได้ทำการ SURRENDER ORIGINAL B/L ทางต้นทางไว้เรียบร้อยแล้ว
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
        (@ViewBag.UserName)
    </div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let job = getQueryString("JNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetJobReport?Branch=' + br + '&JNo=' + job).done(function (r) {
        if (r.job.data.length > 0) {
            let dr = r.job.data[0];
            $('#lblJNo').text(dr.JNo);
            $('#lblETADate').text(CDateEN(dr.ETADate));
            $('#lblVesselName').text(dr.VesselName);
            $('#lblNameThai').text(dr.CustTName);
            $('#lblProductQtyUnit').text(dr.InvProductQty + ' ' + dr.InvProductUnit);
            $('#lblHAWB').text(dr.HAWB);
        }
    });
</script>