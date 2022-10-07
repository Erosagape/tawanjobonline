@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "PAYABLE VOUCHER"
    ViewBag.ReportName = "ใบขออนุมัติเบิกจ่าย"
End Code
<style>
    * {
        font-size: 11px;
    }

    h3{
        font-size:16px;
    }
    .table {
        width: 100%;
        page-break-inside: auto;
    }

    body {
        line-height: 1;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .bold {
        font-weight: bold;
    }

    .table td, .table th {
        border-color: black;
        border-top: 0px none;
        padding: 0.3rem;
    }

    .table-bordered td, .table-bordered th {
        border: 1px solid black;
    }

    .table thead th {
        border-color: black;
        border-width: 1px;
        padding: 0.5em;
    }

    .table-borderless td, .table-borderless th {
        border: 0px none;
    }

    .underLine {
        border-bottom: 1px solid black !important;
    }

    .noUnderLine {
        border-bottom: 0px none !important;
    }

    .noUpperLine {
        border-top: 0px none !important;
    }

    .sideLine {
        border-left: 1px solid black;
        border-right: 1px solid black;
    }

</style>

<table class="table" border="1" style="border-width:thin;border-collapse:collapse;width:100%;">
    <thead>
        <tr>
            <td colspan="14">
                <table id="renderpage" class="table">
                    <thead></thead>
                    <tbody>
                        <tr>
                            <td class="bold">
                                <label id="venderToLbl"> VENDER NAME (จ่ายให้)</label>
                            </td>
                            @*<td colspan="2" class="bold">
                                <label id="billToLbl">BILL TO NAME AND ADDRESS</label>
                            </td>*@
                            <td>
                                <label id="venderName"></label>
                            </td>
                            <td>
                                <label id="voucherLbl" class="bold">A/P NO:</label>
                            </td>
                            <td>
                                <label id="voucherNo"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label id="refno1Lbl" class="bold">REF NO.1 : </label>
                            </td>
                            <td>
                                <label id="refno1" class=""></label>
                            </td>
                            <td>
                                <label id="voucherDateLbl" class="bold">DUE DATE:</label>
                            </td>
                            <td>
                                <label id="voucherDate"></label>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <label id="refno2Lbl" class="bold">เลขที่บัญชี : </label>
                            </td>
                            <td>
                                <label id="refno2" class=""></label>
                            </td>
                            <td id="payTypeLbl" class="bold"> PAYMENT TYPE</td>
                            <td><label id="payType" class=""></label></td>
                        </tr>
                        <tr>
                        </tr>

                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <th class="align-top" rowspan="2" style="width:60px">SI CODE</th>
            <th class="align-top" rowspan="2">JOB NO</th>
            <th class="align-top" rowspan="2">BOOKING NO.</th>
            <th class="align-top" rowspan="2">DESCRIPTION</th>
            <th class="center align-top" rowspan="2" colspan="2">QTYs</th>
            <th class="center" colspan="5">IN SOURCE CURRENCY</th>
            <th class="center" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr>
            <th class="center">CURR.</th>
            <th class="center">@@ UNIT</th>
            <th class="center">AMOUNT</th>
            <th class="center">EXC.</th>
            <th class="center">WH</th>
            <th class="center" style="width:60px">ADVANCE</th>
            <th class="center" style="width:60px">NO VAT</th>
            <th class="center" style="width:60px">VAT</th>
        </tr>
    </thead>
    <tbody id="details">
    </tbody>
    <tr>
        <td rowspan="5" colspan="4" style="padding:0px">
            <table class="table table-borderless">
                <thead>
                    <tr class="underLine">
                        <th>WHT</th>
                        <th class="center">Gross Amt.</th>
                        <th class="center">Tax Amt.</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <label id="wht1">1%</label>
                        </td>
                        <td class="right">
                            <label id="gross1"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt1"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="wht1_5">1.5%</label>
                        </td>
                        <td class="right">
                            <label id="gross1_5"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt1_5"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="wht3">3%</label>
                        </td>
                        <td class="right">
                            <label id="gross3"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt3"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="wht10">10%</label>
                        </td>
                        <td class="right">
                            <label id="gross10"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt10"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="whtOthers">Others</label>
                        </td>
                        <td class="right">
                            <label id="grossOthers"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmtOthers"></label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
        <td id="totalVatExclusiveAmountLbl" class="bold" colspan="7">TOTAL VAT EXCLUSIVE AMOUNT</td>
        <td id="advanceVatExclusiveAmount" class="right bold"></td>
        <td id="noVatVatExclusiveAmount" class="right bold"></td>
        <td id="vatVatExclusiveAmount" class="right bold"></td>

    </tr>
    <tr>
        <td id="totalVatAmountLbl" class="bold" colspan="7">TOTAL VAT AMOUNT</td>
        <td class="right"></td>
        <td class="right"></td>
        <td id="totalVatAmount" class="right bold"></td>
    </tr>
    <tr>
        <td id="totalVatInclusiveAmountLbl" class="bold" colspan="7">TOTAL VAT INCLUSIVE AMOUNT</td>
        <td id="totalVatInclusiveAmount" class="right bold" colspan="3"></td>
    </tr>
    <tr>
        <td id="lessWTLbl" class="bold" colspan="7">LESS W/T</td>
        <td id="lessWT" class="right bold" colspan="3"></td>
    </tr>
    <tr>
        <td id="netPaymentLbl" class="bold" colspan="7">NET PAYMENT (ยอดเงินที่ต้องจ่าย)
        <br><br><br>
                <div style="text-align: center"><label style="font-size:5px;font-weight:lighter">ประทับตราจ่าย</label></div>
        <br /><br>
        </td>
        <td id="netPayment" class="right bold" colspan="3" style="vertical-align:top"></td>
    </tr>
</table>
<br />
<br />
( ผู้จัดทำ ผู้อนุมัติ และบัญชีผู้ตรวจสอบ ลงนามเซ็นชื่อรับทราบ และยืนยันความถูกต้อง ว่าได้มีการตรวจสอบข้อมูลการเบิกจ่ายว่าเป็นข้อมูลที่ใช้ในงานอย่างถูกต้อง ก่อนที่จะให้ผู้บริหารโอนจ่ายหรือทำเช็คจ่าย หากมีความเสียหายเกิดขึ้นหรือข้อมูลที่ให้ไม่เป็นความจริง ยินดีรับผิดชอบความเสียหายนั้นทั้งหมดครบถ้วนสมบูรณ์ )
<br />
<br />
<table class="table table-bordered">
    <tr>
        <td class="center bold" style="height: 100px; vertical-align: top;width:20%;">
            บัญชีผู้จัดทำ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center" id="empCode"></div>
        </td>
        <td class="center bold" style="height: 100px; vertical-align: top;width:20%;">
            หัวหน้าฝ่ายบัญชีผู้ตรวจสอบ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center" id="approveBy"></div>
        </td>
        <td class="center bold" style="height: 100px; vertical-align: top;width:20%;">
            การเงินผู้ทำจ่าย :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center" id="paymentBy"></div>
        </td>
        <td class="center bold" style="height: 100px; vertical-align: top;width:20%;">
            ผู้จัดการฝ่ายการเงินตรวจสอบและอนุมัติ :
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center">WANIDA PROMTHONG (AEW)</div>
        </td>
    </tr>
</table>
<br /><b>REMARKS:</b>
<span id="remark"></span>
<br />
<br />
<table class="table table-bordered">
    <tr>
        <td class="center bold" style="vertical-align: top;width:20%;">
            หัวหน้าฝ่ายส่งออกรับทราบ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center"> LAONGDAO MAIPAE (DAO)</div>
        </td>
        <td class="center bold" style="vertical-align: top;width:20%;">
            หัวหน้าฝ่ายนำเข้ารับทราบ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center"> SAKORN HAETUY (DIN)</div>
        </td>
        <td class="center bold" style="vertical-align: top;width:20%;">
            หัวหน้าฝ่ายปฎิบัติงานรับทราบ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center"> PHATSAMON JASALA(PUD)</div>
        </td>
        <td class="center bold" style="vertical-align: top;width:20%;">
            ผู้จัดการฝ่ายขายรับทราบ  :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center">HASSAPON UDOMSUK (VECH)</div>
        </td>
    </tr>
</table>

<table class="table table-bordered">
    <tr>
        <td class="center bold" style="vertical-align: top;width:30%;">
            ผู้จัดการฝ่ายต่างประเทศรับทราบ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center"> SOMPHOT LILANGAMYING (PATRICK)</div>
        </td>
        <td class="center bold" style="vertical-align: top;width:30%;">
            กรรมการผู้จัดการรับทราบ :
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center"> PRASERT PORNTEPCHAROEN</div>
</td>
        <td class="center bold" style="vertical-align: top;width:30%;color:red">
            ผู้จัดการฝ่ายบัญชีตรวจสอบและลงบันทึกใบสำคัญจ่าย :
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
            <div class="center"> SUDARUT SORNDECH (AEW)</div>
        </td>
    </tr>
</table>

<script src="~/Scripts/Func/reports.js"></script>
<script type="text/javascript">
    
    const path = '@Url.Content("~")';
    const branchcode = getQueryString("BranchCode");
    const id = getQueryString("DocNo");
    if (branchcode !== '' && id !== '') {
        let url = 'Acc/GetPaymentGrid?Branch=' + branchcode;
        if (id !== '') {
            url += '&Code=' + id;
        }
        $.get(path + url).done(function (r) {
            if (r.payment.data.length > 0) {
                let h = r.payment.data[0];
                $("#dvFooter").html($("#dvFooter").html() + "	A/P NO : " + h.DocNo);
                $("#voucherNo").text(h.DocNo);
                $("#voucherDate").text(ShowDate(h.DocDate));
                $("#jobNo").text(h.ForJNo);
                $("#remark").html(CStr(h.Remark));
                $("#totalVatAmount").text(ShowNumber(h.TotalVAT, 2));
                $("#lessWT").text(ShowNumber(h.TotalTax, 2));
                $("#netPayment").text(ShowNumber(h.TotalNet, 2));
                $("#refno1").text(h.RefNo);
                $("#refno2").text(h.PoNo);
                $("#payType").text(h.PayType);
                ShowUser(path, h.EmpCode, "#empCode");
                ShowUser(path, h.ApproveBy, "#approveBy");

                ShowUser(path, h.PaymentBy, "#paymentBy");
                $.get(path + "/Master/GetVender?code=" + h.VenCode).done(function (r) {
                    if (r.vender.data.length > 0) {
                        $("#venderName").text(r.vender.data[0].English);
                        // $("#venderAddress").text(r.vender.data[0].EAddress1 + r.vender.data[0].EAddress2 );
                    }
                });
                LoadJob(h.BranchCode, h.ForJNo, h);
                let d = r.payment.data;
                let sumAdv = 0;
                let sumNoVat = 0;
                let sumVat = 0;

                let sumbaseWht1 = 0
                let sumbaseWht1_5 = 0
                let sumbaseWht3 = 0
                let sumbaseWht10 = 0
                let sumbaseWhtother = 0

                let sumWht1 = 0
                let sumWht1_5 = 0
                let sumWht3 = 0
                let sumWht10 = 0
                let sumWhtother = 0
                let html = '';
                let totalRows = 20;
                let blankRows = totalRows - d.length;

                for (let row of d) {
                    html += '<tr>';
                    html += '<td class="">' + row.SICode + '</td>';
                    html += '<td class="">' + row.ForJNo + '</td>';
                    html += '<td class="">' + row.BookingRefNo + '</td>';
                    html += '<td class="">' + row.SDescription + (row.Remark ? "(" + row.Remark + ")" : "") + '</td>';
                    html += '<td class="center" colspan="2">' + row.Qty + " " + row.QtyUnit + '</td>';
                    html += '<td class="center">' + row.CurrencyCode + '</td>';
                    html += '<td class="right">' + ShowNumber(row.UnitPrice, 2) + '</td>';
                    html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                    html += '<td class="right">' + row.ExchangeRate + '</td>';
                    html += '<td class="right">{WHTP}</td>';
                    let code = row.SICode;
                    if (code.indexOf('ADV') >= 0 || (code.indexOf('ATK') >= 0) || (code.indexOf('AVF') >= 0) || (code.indexOf('ASP') >= 0)) {
                        html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                        html += '<td class="right"></td>';
                        html += '<td class="right"></td>';
                        sumAdv += row.Amt;
                    } else {
                        html += '<td class="right"></td>';
                        if (row.AmtVAT > 0) {
                            html += '<td class="right"></td>';
                            html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                            sumVat += row.Amt;
                        } else {
                            html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                            html += '<td class="right"></td>';
                            sumNoVat += row.Amt;
                        }
                    }
                    html += '</tr>';
                    html += '<tr><td colspan="14"><b>REMARK :  </b>' + row.SRemark+ '</td></tr>';
                    let rateCal = 0;
                    if (row.AmtWHT != 0) {
                        //if (((row.AmtWHT * 0.01) * 1) == row.Amt)
                        if (CDbl((row.Amt * 0.01),2) == CDbl(row.AmtWHT,2))
                        {
                            rateCal = 1.0;

                        }

                        if (CDbl((row.Amt * 0.015),2) == CDbl(row.AmtWHT,2)) {
                            rateCal = 1.5;

                        }
                        if (CDbl((row.Amt * 0.03),2) == CDbl(row.AmtWHT,2)) {
                            rateCal = 3.0;

                        }
                        if (CDbl((row.Amt * 0.10),2) == CDbl(row.AmtWHT,2)) {
                            rateCal = 10.0;

                        }
                        if (rateCal == 0) {
                            rateCal = ((row.AmtWHT * 100) / row.Amt).toFixed(1);

                        }
                   
                        switch (true) {
                            case 0==rateCal:
                                break;
                            case 1.0==rateCal:
                            sumbaseWht1 += row.Amt;
                            sumWht1 += row.AmtWHT;
                                $('#gross1').text(ShowNumber(sumbaseWht1,2));
                                $('#taxAmt1').text(ShowNumber(sumWht1, 2));
                                break;
                            case 1.5==rateCal:
                            sumbaseWht1_5 += row.Amt;
                            sumWht1_5 += row.AmtWHT;
                                $('#gross1_5').text(ShowNumber(sumbaseWht1_5, 2));
                                $('#taxAmt1_5').text(ShowNumber(sumWht1_5, 2));
                                break;
                            case 3.0==rateCal:
                            sumbaseWht3 += row.Amt;
                            sumWht3 += row.AmtWHT;
                                $('#gross3').text(ShowNumber(sumbaseWht3, 2));
                                $('#taxAmt3').text(ShowNumber(sumWht3, 2));
                                break;
                            case 10.0==rateCal:
                            sumbaseWht10 += row.Amt;
                            sumWht10 += row.AmtWHT;
                                $('#gross10').text(ShowNumber(sumbaseWht10, 2));
                                $('#taxAmt10').text(ShowNumber(sumWht10, 2));
                                break;
                            default:
                            sumbaseWhtother += row.Amt;
                            sumWhtother += row.AmtWHT;
                                $('#grossOthers').text(ShowNumber(sumbaseWhtother, 2));
                                $('#taxAmtOthers').text(ShowNumber(sumWhtother, 2));
                                break;
                        }
                    }
                    if (rateCal) {

                        html = html.replace("{WHTP}", (rateCal - 0).toFixed(1) + "");
                    } else {
                        html = html.replace("{WHTP}", "");
                    }
                }
                //for (let i = 1; i <= blankRows; i++) {
                //    html += '<tr>';
                //    html += '<td class=""><br/></td>';
                //    html += '<td class=""><br/></td>';
                //    html += '<td class=""><br/></td>';
                //    html += '<td class="center" colspan="2"></td>';
                //    html += '<td class="center"></td>';
                //    html += '<td class="right"></td>';
                //    html += '<td class="right"></td>';
                //    html += '<td class="right"></td>';
                //    html += '<td class="right"></td>';
                //    html += '<td class="right"></td>';
                //    html += '<td class="right"></td>';
                //}
                $('#details').html(html);
                $("#advanceVatExclusiveAmount").text(ShowNumber(sumAdv,2));
                $("#noVatVatExclusiveAmount").text(ShowNumber(sumNoVat, 2));
                $("#vatVatExclusiveAmount").text(ShowNumber(sumVat, 2));
                $("#totalVatInclusiveAmount").text(ShowNumber(sumAdv+sumVat + h.TotalVAT, 2));
            }
        });
       
    }
  
    function LoadJob(branch, job, header) {
        $("#dvFooter").show();
        $.get(path + 'JobOrder/getjobsql?Branch=' + branch + '&JNo=' + job).done(function (r) {
            if (r.job.data.length > 0) {
                let j = r.job.data[0];
                $("#id").text(j.CustCode);
                $("#masterBLNo").text(j.MAWB);
                $("#feeder").text(j.MVesselName);
                $("#houseBLNo").text(j.HAWB);
                $("#vessel").text(j.VesselName);
                $("#newHBLNo").text(j.BookingNo);
                $("#etd").text(ShowDate(j.ETDDate));
                $("#eta").text(ShowDate(j.ETADate));
                ShowCustomerAddress(path, j.CustCode, j.CustBranch, header);
                if (j.JobType == 1) {
                    ShowCustomerEN(path, j.CustCode, j.CustBranch, '#shipperName');
                    ShowCustomerEN(path, j.Consigneecode, j.CustBranch, '#consigneeName');
                    ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#original');
                } else {
                    ShowCustomerEN(path, j.CustCode, j.CustBranch, '#consigneeName');
                    ShowCustomerEN(path, j.Consigneecode, j.CustBranch, '#shipperName');
                    ShowInterPort(path, j.InvCountry, j.InvInterPort, '#original');
                }
                ShowVender(path, j.ForwarderCode, '#carrier');
            
            }
        });
    }
    function ShowCustomerAddress(path, code, branch,h) {
        $.get(path + 'Master/GetCompany?Code=' + code + '&Branch=' + branch).done(function (r) {
            if (r.company.data.length>0) {
                let c = r.company.data[0];
                $('#billName').text(c.NameEng);
                $('#billAddress').html(c.EAddress1 + '<br/>' + c.EAddress2);
                let creditlimit = Number(c.CreditLimit);
                $('#dueDate').text(AddDate(h.DocDate, creditlimit));
                $("#creditTerm").text(creditlimit + " DAYS");
                $("#currency").text(h.CurrencyCode);
            }
        });
    }
   
</script>