@Code
    Layout = "~/Views/Shared/_ReportNoHeadLandscape.vbhtml"
End Code
<style>
    * {
        font-family: AngsanaUPC;
        font-size: 13px;
    }

    #pFooter,#dvFooter {
        display: none;
    }

    thead {
        text-align: center;
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

    .flex-container {
        display: flex;
        flex-wrap: nowrap;
    }

        .flex-container > div {
            background-color: #f1f1f1;
            width: 15px;
            margin: 1px;
            text-align: center;
            line-height: 20px;
            font-size: 7px;
        }
</style>
<table>
    <tr>
        <td>
            <table id="report" style="width:100%">
                <tr>
                    <td style="width:10%">
                        ใบแนบ <label style="font-size:32px;font-weight:bold">ภ.ง.ด.3</label>
                    </td>
                    <td style="width:60%">
                        <br />
                        เลขที่ประจำตัวผู้เสียภาษีอากร (ของผู้มีหน้าที่หักภาษี ณ ที่จ่าย) : <label id="lblTaxNumber1"></label>
                        สาขา : <label id="lblBranch1"></label>
                        <br />
                        ชื่อผู้เสียภาษีอากร : <label id="lblTName1"></label><br />
                        ที่อยู่ : <label id="lblTAddress1"></label>
                    </td>
                    <td style="width:30%;text-align:right">
                        <br />                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table id="tbDetail" border="1" style="border-style:solid;border-width:thin;border-collapse:collapse;">
                <thead style="text-align:center">
                    <tr>
                        <td rowspan="3">
                            <p>ลำดับที่</p>
                        </td>
                        <td>
                            <p>เลขประจำตัวผู้เสียภาษีอากร (ของผู้มีเงินได้)</p>
                        </td>
                        <td>
                            <p>สาขา</p>
                        </td>
                        <td colspan="4">
                            <p>รายละเอียดเกี่ยวกับการจ่ายเงิน</p>
                        </td>
                        <td colspan="3">
                            <p>รวมเงินภาษีที่หักและนำส่งในครั้งนี้</p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            ชื่อผู้มีเงินได้
                            (ให้ระบุให้ชัดเจนว่าเป็น นาย นาง นางสาวหรือยศ)
                        </td>
                        <td rowspan="2">
                            <p>
                                วัน เดือน ปี<br> ที่จ่าย
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                1 ประเภทเงินได้<br>(ถ้ามากกว่าหนึ่งประเภทให้กรอกเรียงลงไป)
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                อัตราภาษีร้อยละ
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                จำนวนเงินที่จ่ายแต่ละประเภท<br>เฉพาะคนหนึ่งๆ ในครั้งนี้
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                จำนวนเงิน
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>2 เงื่อนไข</p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            ที่อยู่ของผู้มีเงินได้ (ให้ระบุเลขที่ ตรอก/ซอย ถนน ตำบล/แขวง อำเภอ/เขต จังหวัด)
                        </td>
                    </tr>
                </thead>
                <tbody></tbody>
                <tfoot>
                    <tr>
                        <td colspan="6">
                            <p>รวมยอดเงินได้และภาษีที่นำส่ง (นำไปรวมกับ <b>ใบแนบ ภ.ง.ด.3 </b>แผ่นอื่น(ถ้ามี))</p>
                        </td>
                        <td style="text-align:right"><label id="lblSumPayAmount"></label></td>
                        <td style="text-align:right"><label id="lblSumPayTax"></label></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="text-left" colspan="4">
                            (ให้กรอกลำดับที่ต่อเนื่องกันไปทุกแผ่น)
                            <br>
                            <b>หมายเหตุ</b> 1 ให้ระบุว่าจ่ายเป็นค่าอะไร เช่น ค่าเช่าอาคาร ค่าสอบบัญชี ค่าทนายความ ค่าวิชาชีพของแพทย์<br/>
                            ค่าก่อสร้าง รางวัล ส่วนลดหรือประโยชน์ใดๆ เนื่องจากการส่งเสริมการขาย รางวัลในการประกวด การแข่งขัน การชิงโชค ค่าจ้างแสดงภาพยนต์ ร้องเพลงดนตรี ค่าจ้างทำของ ค่าโฆษณา ค่าขนส่งสินค้า ฯลฯ
                            <br>
                            2 เงื่อนไขการหักภาษี ณ ที่จ่ายให้กรอกดังนี้<br>
                            หัก ณ ที่จ่าย กรอก 1<br>
                            ออกภาษีให้ กรอก 2<br>
                            ออกให้ครั้งเดียว กรอก 3
                        </td>
                        <td colspan="3" style="text-align:center">
                            <br>
                            ลงชื่อ.....................................................ผู้จ่ายเงิน<br>
                            ( @ViewBag.TaxAuthorize )<br>
                            ตำแหน่ง @ViewBag.TaxPosition  <br>
                            ยื่นวันที่ @ViewBag.TaxIssueDate
                        </td>
                        <td colspan="2">
                            <div class="circle"><br />ตราประทับ<br />นิติบุคคล<br />(ถ้ามี)</div>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </td>
    </tr>
</table>


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
                    $('#lblTaxNumber1').text(tb.TaxNumber1);
                    $('#lblBranch1').text(tb.Branch1);
                    $('#lblTName1').text(tb.TName1);
                    $('#lblTAddress1').text(tb.TAddress1);
                    let n = 0;
                    let c = 0;
                    let sumamt = 0;
                    let sumtax = 0;
                    let template = '';
                    let field1 = '';
                    let field2 = '';
                    let field3 = '';
                    let field4 = '';
                    let field5 = '';
                    let rd = res.result;
                    sortData(rd, 'DocNo', 'asc');
                    let docno = '';
                    for (let r of rd) {
                        if (docno !== r.DocNo) {
                            n += 1;
                            if (docno !== '') {
                                template += '</tr>';
                                template = template.replace('{1}', field1);
                                template = template.replace('{2}', field2);
                                template = template.replace('{3}', field3);
                                template = template.replace('{4}', field4);
                                template = template.replace('{5}', field5);

                                $('#tbDetail tbody').append(template);
                            }
                            field1 = '';
                            field2 = '';
                            field3 = '';
                            field4 = '';
                            field5 = '';

                            template = '';
                            template += '<tr>';
                            template += '<td>' + n + '</td>';
                            template += '<td>';
                            template += '<p class="text-left">';
                            template += 'เลขประจำตัวผู้เสียอาษีอากร : ' + r.TaxNumber3;
                            template += '<br />';
                            template += 'ชื่อ : ' + r.TName3;
                            template += '<br />';
                            template += 'ที่อยู่ : ' + r.TAddress3;
                            template += '</p>';
                            template += '</td>';
                            template += '<td>' + r.Branch3 + '</td>';
                            template += '<td>{1}</td>';
                            template += '<td>' + r.DocNo + ' / ' + r.JNo + '{5}</td>';
                            template += '<td>{2}</td>';
                            template += '<td style="text-align:right">{3}</td>';
                            template += '<td style="text-align:right">{4}</td>';
                            template += '<td>' + r.PayTaxType + '</td>';
                            docno = r.DocNo;
   
                        }

                        field1 += '<br/>' + ShowDate(r.PayDate);                        
                        field2 += '<br/>' + r.PayRate;
                        field3 += '<br/>' + ShowNumber(r.PayAmount, 2);
                        field4 += '<br/>' + ShowNumber(r.PayTax, 2);
                        field5 += '<br/>' + r.PayTaxDesc;

                        sumamt += CNum(r.PayAmount);
                        sumtax += CNum(r.PayTax);

                        c += 1;
                        if (c == rd.length) {
                            template += '</tr>';
                            template = template.replace('{1}', field1);
                            template = template.replace('{2}', field2);
                            template = template.replace('{3}', field3);
                            template = template.replace('{4}', field4);
                            template = template.replace('{5}', field5);
                            $('#tbDetail tbody').append(template);
                        }
                    }
                    $('#lblSumPayAmount').text(ShowNumber(sumamt, 2));
                    $('#lblSumPayTax').text(ShowNumber(sumtax, 2));
                }
            }
        });
    }
</script>




