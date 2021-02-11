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
        font-size:12px;
    }
</style>
<div style="padding:30px 30px 30px 30px">
    <div style="text-align:right;width:100%">
        DATE : <label id="lblPrintDate">@DateTime.Now.ToString("dd/MM/yyyy")</label>
    </div>
    <br />
    <div style="text-align:left">
        <label id="subj">เรื่อง  </label><span id="lblSubj">ขอใช้จดหมายรับ D/O เนื่องจาก <input type="text" id="txtType" style="width:200px" value="SURRENDER OB/L" /></span>
        <br /><br />
        <label id="to">เรียน </label><span id="lblTo">เจ้าหน้าที่แผนกขาเข้าทางเรือ</span> <label id="lblForwarderName">บริษัท__________________________________________</label>
    </div>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  เนื่องด้วยบริษัท <label id="lblNameThai"></label>
    มีสินค้าเข้ามากับเรือ <label id="lblVesselName"></label>
    <br />
    เที่ยววันที่ <label id="lblETADate"></label> ตาม B/L No: <label id="lblHAWB"></label>
    จำนวน <label id="lblProductQty"></label> <input type="text" id="txtPackUnit" style="width:200px;" value="PACKAGES" />
    <br />
    ซึ่งผู้ขายของบริษัทฯ ได้ทำการ <input type="text" id="txtType2" style="width:200px;" value="SURRENDER ORIGINAL B/L" />
    <br />ไว้กับทางต้นทางเรียบร้อยแล้ว
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  ดังนั้นทางบริษัทฯ จึงขอรับ D/O โดยใช้จดหมายของทางบริษัทฯ เพิ้อไปทำการปล่อยสินค้า
    <br />ซึ่งในการนี้ หากเกิดความเสียหายใดๆ เกิดขึ้นทุกประการ ทางบริษัทฯ ยินดีจะรับผิดชอบความเสียหายที่เกิดขึ้นนั้นตามจริง
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
            (นายชาณุศักดิ์ ชายภักตร์)
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
            $('#lblNameThai').text(dr.CustTName);
            $('#lblProductQty').text(dr.TotalQty);
            //ShowInvUnit(path, dr.InvProductUnit, '#lblProductUnit');
            $('#lblHAWB').text(dr.HAWB);
        }
    });
</script>