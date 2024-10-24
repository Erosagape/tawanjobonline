@Code
    Layout = "~/Views/Shared/_ReportNoHeadLandscape.vbhtml"
End Code
<style>
    * {
        font-family: AngsanaUPC;
        font-weight:bold;
    }
    thead,tfoot {
        font-size: 14px;
    }
    tbody {
        font-size: 15px;
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

	*{
		 page-break-inside: auto !important;page-break-after:auto !important;
	}

</style>
<div style="padding:20px;width:100%;">
<table>
    <tr>
        <td>
            <table style="width:98%">
                <tr>
                    <td style="width:10%">
                        ใบแนบ <label style="font-size:32px;font-weight:bold">ภ.ง.ด.3</label>
                    </td>
                    <td style="width:60%">
                        เลขที่ประจำตัวผู้เสียภาษีอากร (ของผู้มีหน้าที่หักภาษี ณ ที่จ่าย) : <label id="lblTaxNumber1"></label>
                        สาขา : <label id="lblBranch1"></label>
                        <br />
                        ชื่อผู้เสียภาษีอากร : <label id="lblTName1"></label><br />
                        ที่อยู่ : <label id="lblTAddress1"></label>
                    </td>
                    <td style="width:30%;text-align:right">
                        หน้าที่ 1 ใน <span id="dvPages"></span> หน้า
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td id="report">
            <table id="tbDetail" border="1" style="border-style:solid;border-width:thin;border-collapse:collapse;display:none;">
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
                        <td style="text-align:right">{0}</td>
                        <td style="text-align:right">{1}</td>
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
                            (<input type="text" style="border-style:none;text-align:center;width:150px" value=" @ViewBag.TaxAuthorize " />) <br>
                            ตำแหน่ง <input type="text" style="border-style:none;text-align:center;width:150px" value="{2}" /> <br>
                            ยื่นวันที่ <input type="text" id="txtIssueDate" style="border-style:none;text-align:center" value="{d}" />
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
        let html = '';
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
                    let dateIssue = prompt('กรุณาใส่วันที่ออกเอกสาร');
                    $('#lblTaxNumber1').text(tb.TaxNumber1);
                    $('#lblBranch1').text('00'+CCode(tb.Branch1));
                    $('#lblTName1').text(tb.TName1);
                    $('#lblTAddress1').text(tb.TAddress1);
                    let n = 0;
                    let c = 0;
                    let p = 1;
                    let sumamt = 0;
                    let sumtax = 0;
                    let template = '';
                    let field1 = '';
                    let field2 = '';
                    let field3 = '';
                    let field4 = '';
                    let field5 = '';
                    let rows = 5;  
                    let htmlAll = GetTableHtml();
                    let htmlHead = $('#tbDetail thead').html();
                    let htmlFoot = $('#tbDetail tfoot').html();
                    let rd = res.result;
                    //sortData(rd, 'DocNo', 'asc');
                    let docno = '';
                    let t = 1;
                    let d = 0;
                    for (let r of rd) {
                        if (docno !== r.DocNo) {
                            docno = r.DocNo;
                            d += 1;
                        }
                    }
                    if (d > (rows-1)) {
                        let r = 1;
                        for (let i = rows; i <= d; i++) {
                            if (r == rows || i == d) {
                                t += 1;
                                r = 1;
                            } else {
                                r += 1;
                            }
                        }
                    }
                    docno = '';

                    $('#dvPages').html(t);
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

                                if ((p == 1 && n == rows) || (((n - rows) % rows) == 0 && p > 1)) {
                                    htmlFoot = htmlFoot.replace('{d}', dateIssue);
                                    htmlFoot = htmlFoot.replace('{0}', ShowNumber(sumamt, 2));
                                    htmlFoot = htmlFoot.replace('{1}', ShowNumber(sumtax, 2));
                                    if (params.ReportCode == 'PRD3AD') {
                                        htmlFoot = htmlFoot.replace('{2}', 'กระทำการแทน');
                                    } else {
                                        htmlFoot = htmlFoot.replace('{2}', '@ViewBag.TaxPosition');
                                    }
                                    htmlAll = htmlAll.replace('{0}', htmlHead);
                                    htmlAll = htmlAll.replace('{1}', template);
                                    htmlAll = htmlAll.replace('{2}', htmlFoot);

                                    if (p > 1) {
                                        htmlAll = '<div style="width:98%;text-align:right;page-break-before:always"><br/>หน้าที่ ' + p + ' จาก ' + t + ' หน้า </div>' + htmlAll;
                                    }

                                    $('#report').append(htmlAll);

                                    sumamt = 0;
                                    sumtax = 0;

                                    htmlAll = GetTableHtml();
                                    htmlHead = $('#tbDetail thead').html();
                                    htmlFoot = $('#tbDetail tfoot').html();

                                    template = '';
                                    p += 1;
                                }
                            }
                            field1 = '';
                            field2 = '';
                            field3 = '';
                            field4 = '';
                            field5 = '';

                            template += '<tr>';
                            template += '<td>' + n + '</td>';
                            template += '<td>';
                            template += '<p class="text-left">';
                            template += 'เลขประจำตัวผู้เสียภาษีอากร : ' + r.TaxNumber3;
                            template += '<br />';
                            template += 'ชื่อ : ' + r.TName3;
                            template += '<br />';
                            template += 'ที่อยู่ : ' + r.TAddress3;
                            template += '</p>';
                            template += '</td>';
                            template += '<td>' + '00'+CCode(r.Branch3) + '</td>';
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

                            htmlFoot = htmlFoot.replace('{d}', dateIssue);
                            htmlFoot = htmlFoot.replace('{0}', ShowNumber(sumamt, 2));
                            htmlFoot = htmlFoot.replace('{1}', ShowNumber(sumtax, 2));
                            if (params.ReportCode == 'PRD3AD') {
                                htmlFoot = htmlFoot.replace('{2}', 'กระทำการแทน');
                            } else {
                                htmlFoot = htmlFoot.replace('{2}', '@ViewBag.TaxPosition');
                            }
                            htmlAll = htmlAll.replace('{0}', htmlHead);
                            htmlAll = htmlAll.replace('{1}', template);
                            htmlAll = htmlAll.replace('{2}', htmlFoot);

                            if (p > 1) {
                                htmlAll = '<div style="width:98%;text-align:right;page-break-before:always;"><br/>หน้าที่ ' + p + ' จาก ' + t + ' หน้า </div>' + htmlAll;
                            }

                            $('#report').append(htmlAll);
                        }
                    }
                }
            }
        });
    }
    function GetTableHtml() {
        let htmlTable = '<table border="1" style="border-style:solid;border-width:thin;border-collapse:collapse;">';
        htmlTable += '<thead>{0}</thead>';
        htmlTable += '<tbody>{1}</tbody>';
        htmlTable += '<tfoot>{2}</tfoot>';
        htmlTable += '</table>';
        return htmlTable;
    }
</script>




