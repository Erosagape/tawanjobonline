
@Code
    ViewBag.Title = "WTax-3"
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
End Code
<style>
    * {
        font-family: AngsanaUPC;
        font-size: 14px;
    }

    #pFooter {
        display: none;
    }

    .circle {
        width: 100px; /* ความกว้าง */
        height: 100px; /* ความสูง */
        -moz-border-radius: 70px;
        -webkit-border-radius: 70px;
        border: 1px solid #000000;
        border-radius: 50%;
        text-align: center;
    }
</style>
<img src="~/Resource/pnd3.png" style="width:100%" />
<div style="display:flex">
    <div style="flex:45%;border-bottom-style:solid;border-bottom-width:1px">
        <div style="display:flex;flex-direction:column">
            <div style="flex:1">
                <div style="display:flex;flex-direction:row">
                    <div style="flex:2">
                        เลขที่ประจำตัวประชาชนของผู้มีหน้าที่หัก ณ ที่จ่าย :
                    </div>
                    <div style="flex:1">
                        <label id="lblIDCard1"></label>
                    </div>
                </div>
            </div>
            <div style="flex:1">
                <div style="display:flex;flex-direction:row">
                    <div style="flex:2">
                        เลขที่ประจำตัวผู้เสียภาษีของผู้มีหน้าที่หัก ณ ที่จ่าย<br />
                        (ที่เป็นผู้ไม่มีเลขประจำตัวบัตรประชาชน) :
                    </div>
                    <div style="flex:1">
                        <label id="lblTaxNumber1"></label>
                    </div>
                </div>
            </div>
        </div>
        <div style="flex:1">
            <div style="display:flex;flex-direction:row">
                <div style="flex:2">
                    <b>ชื่อผู้มีหน้าที่หักภาษี ณ ที่จ่าย (หน่วยงาน)</b>
                </div>
                <div style="flex:1">
                    <b>สาขาที่</b>
                    <label id="lblBranch1"></label>
                </div>
            </div>
        </div>
        <div style="flex:1">
            <label id="lblTName1"></label><br />
            <label id="lblTAddress1"></label>
        </div>
    </div>
    <div style="flex:55%;border-left-style:solid;border-left-width:1px;border-bottom-style:solid;border-bottom-width:1px">
        <div style="display:flex;flex-direction:column">
            <div>
                <b>เดือนที่จ่ายเงินได้พึงประเมิน</b> (ให้ทำเครื่องหมาย <input type="checkbox" checked /> ลงใน <input type="checkbox" /> หน้าชื่อเดือน) พ.ศ. <input type="text" id="txtTaxYear" style="width:50px" />
            </div>
            <div style="display:flex">
                <div style="flex:1">
                    <input type="checkbox" id="chkMo1" /> (1) มกราคม
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo2" /> (2) กุมภาพันธ์
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo3" /> (3) มีนาคม
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo4" /> (4) เมษายม
                </div>
            </div>
            <div style="display:flex">
                <div style="flex:1">
                    <input type="checkbox" id="chkMo5" /> (5) พฤษภาคม
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo6" /> (6) มิถุนายน
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo7" /> (7) กรกฏาคม
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo8" /> (8) สิงหาคม
                </div>
            </div>
            <div style="display:flex">
                <div style="flex:1">
                    <input type="checkbox" id="chkMo9" /> (9) กันยายน
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo10" /> (10) ตุลาคม
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo11" /> (11) พฤศจิกายน
                </div>
                <div style="flex:1">
                    <input type="checkbox" id="chkMo12" /> (12) ธันวาคม
                </div>
            </div>
        </div>
    </div>
</div>
<div style="display:flex">
    <div style="flex:45%;border-bottom-style:solid;border-bottom-width:1px;padding:5px 5px 5px 5px">
        <div style="display:flex">
            <div style="flex:1;padding:5px 5px 5px 5px">
                <input type="checkbox" /> (1) ยื่นปกติ
            </div>
            <div style="flex:2;padding:5px 5px 5px 5px">
                <input type="checkbox" /> (2) ยื่นเพิ่มเติมครั้งที่ <input type="text" style="width:30px" />
            </div>
        </div>
    </div>
    <div style="flex:55%;border-left-style:solid;border-left-width:1px;border-bottom-style:solid;border-bottom-width:1px">

    </div>
</div>
<div style="width:100%;text-align:center;font-weight:bold;font-size:16px">
    นำส่งภาษีตาม :
    <input type="checkbox" id="chkLaw1" /> (1) มาตรา 3 เตรส แห่งประมวลรัษฏากร
    <input type="checkbox" id="chkLaw4" /> (2) มาตรา 48 ทวิ แห่งประมวลรัษฏากร
    <input type="checkbox" id="chkLaw5" /> (3) มาตรา 50 (3)(4)(5) แห่งประมวลรัษฏากร
</div>
<hr />
<div style="display:flex">
    <div style="flex:40%;text-align:center;font-size:16px;">
        มีรายละเอียดการหักเป็นรายผู้มีเงินได้ ปรากฏตาม
        <br />
        (ให้แสดงรายละเอียดใน<b>ใบแนบ ภ.ง.ด. 3</b> หรือใน<b>สื่อบันทึกในระบบคอมพิวเตอร์</b>อย่างใดอย่างหนึ่งเท่านั้น)
    </div>
    <div style="flex:60%;">
        <div style="display:flex;">
            <div style="flex:2;font-size:16px">
                <input type="checkbox" /> ใบแนบ <b>ภ.ง.ด. 3</b> ที่แนบมาพร้อมนี้
            </div>
            <div style="flex:1;font-size:16px">
                จำนวน <input type="text" style="width:50px" /> ราย
                <br />
                จำนวน <input type="text" style="width:50px" /> แผ่น
            </div>
        </div>
        <div style="display:flex;">
            <div style="flex:2;font-size:16px">
                <input type="checkbox" /> สื่อบันทึกในระบบคอมพิวเตอร์ ที่แนบมาพร้อมนี้
            </div>
            <div style="flex:1;font-size:16px">
                จำนวน <input type="text" style="width:50px" /> ราย
                <br />
                จำนวน <input type="text" style="width:50px" /> แผ่น
            </div>
        </div>
        <div style="text-align:right;">
            (ตามหนังสือแสดงความประสงค์ ทะเบียนรับเลขที่......................................)
            <br />
            หรือตามหนังสือข้อตกลงการใช้งานฯ เลขอ้างอิงการลงทะเบียน................................................)
        </div>
    </div>
</div>
<br />
<div style="display:flex;flex-direction:column;align-items:center">
    <div style="width:80%;display:flex">
        <div style="flex:2;text-align:center;background-color:lightgrey;border-style:solid;border-width:1px">
            <b>สรุปรายการภาษีที่นำส่ง</b>
        </div>
        <div style="flex:1;text-align:center;border-style:solid;border-width:1px">
            จำนวนเงิน
        </div>
    </div>
    <div style="width:80%;display:flex">
        <div style="flex:2">
            <b>1. รวมยอดเงินได้ทั้งสิ้น</b>
        </div>
        <div style="flex:1">
            <input type="text" id="txtSumPayAmount" style="width:100%;text-align:right" />
        </div>
    </div>
    <div style="width:80%;display:flex">
        <div style="flex:2">
            <b>2. รวมยอดภาษีที่นำส่งทั้งสิ้น</b>
        </div>
        <div style="flex:1">
            <input type="text" id="txtSumPayTax" style="width:100%;text-align:right" />
        </div>
    </div>
    <div style="width:80%;display:flex">
        <div style="flex:2">
            <b>3. เงินเพิ่ม(ถ้ามี)</b>
        </div>
        <div style="flex:1">
            <input type="text" value="0.00" style="width:100%;text-align:right" />
        </div>
    </div>
    <div style="width:80%;display:flex">
        <div style="flex:2">
            <b>4. รวมยอดภาษีที่นำส่งทั้งสิ้นและเงินเพิ่ม (2.+3.)</b>
        </div>
        <div style="flex:1">
            <input type="text" id="txtSumTax" style="width:100%;text-align:right" />
        </div>
    </div>
</div>
<br />
<hr />
<br />
<div>
    <div style="width:100%;text-align:center;font-size:16px;float:left">
        <div style="float:right">
            <br />
            <div class="circle"><br />ประทับตรา<br />นิติบุคคล<br />(ถ้ามี)</div>
            <br />
        </div>
        ข้าพเจ้าขอรับรองว่า รายการที่แจ้งไว้ข้างต้นนี้ เป็นรายการที่ถูกต้องและครบถ้วนทุกประการ
        <br />
        <br />
        <br />
        ลงชื่อ..............................................................................................ผู้จ่ายเงิน
        <br />
        (..............................................................................................)
        <br />
        ตำแหน่ง .....................................................................................
        <br />
        ยื่นวันที่............ เดือน..............................................พ.ศ. ...................
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let data = getQueryString("data");
    let cliteria = getQueryString("cliteria");
    let user = '@ViewBag.User';
    let lang = '@ViewBag.PROFILE_DEFAULT_LANG';
    let row = {};
    if (data !== '') {
        row = JSON.parse(data);
        let obj = JSON.parse(cliteria);
        html = '';
        if (obj.DATEFROM !== '') html += obj.DATEFROM + ',';
        if (obj.DATETO !== '') html += obj.DATETO + ',';
        if (obj.CUSTWHERE !== '') html += obj.CUSTWHERE + ',';
        if (obj.JOBWHERE !== '') html += obj.JOBWHERE + ',';
        if (obj.VENDWHERE !== '') html += obj.VENDWHERE + ',';
        if (obj.STATUSWHERE !== '') html += obj.STATUSWHERE + ',';
        if (obj.EMPWHERE !== '') html += obj.EMPWHERE + ',';
        let params = {
            ReportCode: row.REPORTCODE,
            ReportCliteria: html
        }
        let str = JSON.stringify(params);
        $.ajax({
            url: path + 'Acc/GetWHTaxReport',
            type: "POST",
            contentType: "application/json",
            data: str,
            success: function (response) {
                let res = JSON.parse(response);
                if (res.msg !== "OK") {
                    //alert(r.msg);
                    return;
                }
                if (res.result.length > 0) {
                    var tb = res.result[0];
                    $('#lblIDCard1').text(tb.IDCard1);
                    $('#lblTaxNumber1').text(tb.TaxNumber1);
                    $('#lblBranch1').text(tb.Branch1);
                    $('#lblTName1').text(tb.TName1);
                    $('#lblTAddress1').text(tb.TAddress1);
                    $('#txtTaxYear').val(tb.TaxYear + 543);
                    $('#chkMo' + tb.TaxMonth).prop('checked', true);
                    $('#chkLaw' + tb.TaxLawNo).prop('checked', true);
                    $('#txtSumPayAmount').val(ShowNumber(tb.SumPayAmount,2));
                    $('#txtSumPayTax').val(ShowNumber(tb.SumPayTax,2));
                    $('#txtSumTax').val(ShowNumber(tb.SumPayTax,2));
                }
            }
        });
    }
</script>