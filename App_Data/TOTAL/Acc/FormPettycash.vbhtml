@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "CLEARING ADVANCE SLIP"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-size: 11px;
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
<div class="center bold">
    <label id="companyName" style="font-size:20px">TOTAL SHIPPING SERVICE CO.,LTD.</label>
</div>
<div class="center bold">
    <label style="font-size:16px">INBOUND PAYABLE VOUCHER</label>
</div>
<table class="table">
    <thead></thead>
    <tbody>
        <tr>
            <td colspan="2" class="bold">
                <label id="billToLbl">BILL TO NAME AND ADDRESS</label>
            </td>
            <td class="right">
                <label id="id"></label>
            </td>
            <td>
                <labe id="voucherLbl" class="bold">VOUCHER NO:</label>
            </td>
            <td>
                <label id="voucherNo"></label>
            </td>
        </tr>
        <tr>
            <td id="billTo" rowspan="4" colspan="3">ชื่อที่่อยู่บริษัทลูกค้า</td>
            <td>
                <label id="voucherDateLbl" class="bold">VOUCHER DATE:</label>
            </td>
            <td>
                <label id="voucherDate"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="dueDateLbl" class="bold">DUE DATE:</label>
            </td>
            <td>
                <label id="dueDate"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="creditTermLbl" class="bold">CREDIT TERM:</label>
            </td>
            <td>
                <label id="creditTerm"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="currencyLbl" class="bold">CURRENCY:</label>
            </td>
            <td>
                <label id="currency"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="jobNoLbl" class="bold">JOB NO</label>
            </td>
            <td>:</td>
            <td>
                <label id="jobNo" class=""></label>
            </td>
            <td>
                <label id="masterBLNoLbl" class="bold">MASTER B/L NO.</label>
            </td>
            <td>
                <label id="masterBLNo">:</label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="feederLbl" class="bold">FEEDER/VOYAGE</label>
            </td>
            <td>:</td>
            <td>
                <label id="feeder" class=""></label>
            </td>
            <td>
                <label id="houseBLNoLbl" class="bold">HOUSE B/L NO.</label>
            </td>
            <td>
                <label id="houseBLNo"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="vesselLbl" class="bold">VESSEL/VOYAGE</label>
            </td>
            <td>:</td>
            <td>
                <label id="vessel" class=""></label>
            </td>
            <td>
                <label id="newHBLNoLbl" class="bold">NEW HB/L NO.</label>
            </td>
            <td>
                <label id="newHBLNo"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="shipperNameLbl" class="bold">SHIPPER NAME</label>
            </td>
            <td>:</td>
            <td>
                <label id="shipperName" class=""></label>
            </td>
            <td>
                <label id="etdLbl" class="bold">ETD : </label>
                <label id="etd"></label>
            </td>
            <td>
                <label id="etaLbl" class="bold">ETA : </label>
                <label id="eta"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="consigneeNameLbl" class="bold">CONSIGNEE NAME</label>
            </td>
            <td>:</td>
            <td>
                <label id="consigneeName" class=""></label>
            </td>
            <td>
                <label id="originalLbl" class="bold">ORIGINAL</label>
            </td>
            <td>
                <label id="original"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="carrierLbl" class="bold">CARRIER</label>
            </td>
            <td>:</td>
            <td>
                <label id="carrier" class=""></label>
            </td>
        </tr>
    </tbody>
</table>
<table class="table" border="1" style="border-width:thin;border-collapse:collapse;width:100%;">
    <thead>
        <tr>
            <th class="align-top" rowspan="2">DESCRIPTION</th>
            <th class="center align-top" rowspan="2">QTYs</th>
            <th class="center align-top" rowspan="2">UOM</th>
            <th class="center" colspan="4">IN SOURCE CURRENCY</th>
            <th class="center" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr">
            <th class="center">CURR.</th>
            <th class="center">@@ UNIT</th>
            <th class="center">AMOUNT</th>
            <th class="center">EXC.</th>
            <th class="center">ADVANCE</th>
            <th class="center">NO VAT</th>
            <th class="center">VAT</th>
            </tr>
    </thead>
    <tbody>
        <tr>
            <td class="">INSPECTION CHARGE</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1,500.0000</td>
            <td class="right">1,500.00</td>
            <td class="right">1.0000</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">1,500.00</td>
        </tr>
        <tr>
            <td class="">CUSTOMS CLEARANCE CHARGE</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1,900.0000</td>
            <td class="right">1,900.00</td>
            <td class="right">1.0000</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">1,900.00</td>
        </tr>
        <tr>
            <td class="">FDA</td>
            <td class="right ">1.000</td>
            <td class="center ">SET</td>
            <td class="center ">THB</td>
            <td class="right ">1,500.0000</td>
            <td class="right ">1,500.00</td>
            <td class="right ">1.0000</td>
            <td class="right ">-</td>
            <td class="right ">-</td>
            <td class="right ">1,500.00</td>
        </tr>
        <tr>
            <td class="">LPI PERMIT (DFA)</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1,000.0000</td>
            <td class="right">1,000.00</td>
            <td class="right">1.0000</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">1,000.00</td>
        </tr>
        <tr>
            <td class="">TRANSPORTATION</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">8,000.0000</td>
            <td class="right">8,000.00</td>
            <td class="right">1.0000</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">8,000.00</td>
        </tr>
        <tr>
            <td class="">CUSTOM TAX ( RECEIPT )</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">200.000</td>
            <td class="right">200.00</td>
            <td class="right">1.0000</td>
            <td class="right">200.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
        <tr class="underLine">
            <td class="">WAREHOUSE RENTAL (RECEIPT)</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">676.1300</td>
            <td class="right">676.13</td>
            <td class="right">1.0000</td>
            <td class="right">676.13</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
        <tr>
            <td rowspan="5" colspan="3">
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
                                <label id="wht1"></label>
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
                                <label id="wht1_5"></label>
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
                                <label id="wht3"></label>
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
                                <label id="wht10"></label>
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
                                <label id="whtOthers"></label>
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
            <td id="totalVatExclusiveAmountLbl" class="bold" colspan="4">TOTAL VAT EXCLUSIVE AMOUNT</td>
            <td id="advanceVatExclusiveAmount" class="right bold"></td>
            <td id="noVatVatExclusiveAmount" class="right bold"></td>
            <td id="vatVatExclusiveAmount" class="right bold"></td>

        </tr>
        <tr>
            <td id="totalVatAmountLbl" class="bold" colspan="4">TOTAL VAT AMOUNT</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="totalVatAmount" class="right bold"></td>
        </tr>
        <tr>
            <td id="totalVatInclusiveAmountLbl" class="bold" colspan="4">TOTAL VAT INCLUSIVE AMOUNT</td>
            <td id="totalVatInclusiveAmount" class="right bold" colspan="3"></td>
        </tr>
        <tr>
            <td id="lessWTLbl" class="bold" colspan="4">LESS W/T</td>
            <td id="lessWT" class="right bold" colspan="3"></td>
        </tr>
        <tr>
            <td id="netPaymentLbl" class="bold" colspan="4">NET PAYMENT</td>
            <td id="netPayment" class="right bold" colspan="3"></td>
        </tr>
    </tbody>
</table>
<table class="table table-bordered">
    <tr>
        <td class="center bold">
            PREPARED BY:
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
        <td class="center bold">
            APPROVED BY:
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
        <td class="center bold">
            RECEIVED BY:
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
        <td class="center bold">
            ACCOUNTANT:
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
    </tr>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const branchcode = getQueryString("Branch");
    const bookno = getQueryString("Code");
    const id = getQueryString("DocNo");
    var showDetails = confirm("Show Net Amount only");
    if (branchcode !== '' && (bookno !== '' || id !== '')) {
        let url = 'Acc/GetVoucherDetail?BranchCode=' + branchcode;
        if (showDetails == true) {
            url += '&Sum=Y';
        }
        if (bookno !== '') {
            url += '&BookNo=' + bookno;
        }
        if (id !== '') {
            url += '&DocNo=' + id;
        }
        $.get(path + url).done(function (r) {
            if (r.data.header.length > 0) {
                let dt = r.data.header[0].Table;
                let htmls = '';
                for (let s of dt) {
                    if (s.Amt !== null) {
                        htmls = '<tr>';
                        htmls += '<td>' + s.GLDesc + '</td>';
                        htmls += '<td>' + s.CostCenter + '</td>';
                        htmls += '<td>' + s.AccountCode + '</td>';
                        if (showDetails == true) {
                            htmls += '<td style="text-align:right;">' + ShowNumber(s.Net, 2) + '</td>';
                            htmls += '<td style="text-align:right;"></td>';
                            htmls += '<td style="text-align:right;"></td>';
                            htmls += '<td style="text-align:right;"></td>';
                        } else {
                            htmls += '<td style="text-align:right;">' + ShowNumber(s.Amt, 2) + '</td>';
                            htmls += '<td style="text-align:right;">' + ShowNumber(s.Vat, 2) + '</td>';
                            htmls += '<td style="text-align:right;">' + ShowNumber(s.Wht, 2) + '</td>';
                            htmls += '<td style="text-align:right;">' + ShowNumber(s.Net, 2) + '</td>';
                        }
                        htmls += '</tr>';
                        $('#tbSummary').append(htmls);

                    }
                }
            }
            if (r.data.detail.length > 0) {
                let dh = r.data.detail[0].Table[0];
                //$('#lblVenderName').text(dh.AdvBy);
                if (id !== '') {
                    $('#lblInvNo').text(id);
                } else {
                    $('#lblInvNo').text('{New Document}');
                }
                $('#lblBookCode').text(dh.BookCode);
                $('#lblDate').text(ShowDate(dh.PostedDate));

                let dr = r.data.detail[0].Table;
                let htmld = '';
                let sumBaseVat = 0;
                let sumNonVat = 0;
                let sumVat = 0;
                let sumWht = 0;
                let sumWht1 = 0;
                let sumWht3 = 0;
                let sumNet = 0;
                let row = 0;
                $('#Body2').html('');
                $('#Body1').html('');
                for (let d of dr) {
                    row += 1;
                    if (d.TotalAdvance>0) {
                        if (d.TotalVAT > 0) {
                            sumBaseVat += (Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi));
                        } else {
                            sumNonVat += (Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi));
                        }
                        sumWht += Number(d.Total50Tavi);
                        sumWht1 += Number(d.Total50Tavi1);
                        sumWht3 += Number(d.Total50Tavi3);
                        sumVat += Number(d.TotalVAT);
                        sumNet += (Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi));

                        htmld += '<tr>';
                        htmld += '<td>' + d.DocNo + '</td>';
                        htmld += '<td>' + ShowDate(d.AdvDate) + '</td>';
                        htmld += '<td>' + d.EmpCode + '</td>';
                        htmld += '<td>' + d.SDescription + '</td>';
                        htmld += '<td>' + d.CostCenter + '</td>';
                        htmld += '<td>' + d.AccountCost + '</td>';
                        if (showDetails == true) {
                            htmld += '<td style="text-align:right">' + ShowNumber((Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi)), 2) + '</td>';
                        } else {
                            htmld += '<td style="text-align:right">' + ShowNumber(d.TotalAdvance, 2) + '</td>';
                            htmld += '<td style="text-align:right">' + ShowNumber(d.TotalVAT, 2) + '</td>';
                            htmld += '<td style="text-align:right">' + ShowNumber(d.Total50Tavi, 2) + '</td>';
                            htmld += '<td>Closed</td>';
                        }
                        htmld += '</tr>';
                    }
                }
                if (showDetails == true) {
                    $('#lblSumNonVAT').text(ShowNumber(sumNet, 2));
                    $('#lblTotalNET').text(ShowNumber(sumNet, 2));
                } else {
                    $('#lblSumNonVAT').text(ShowNumber(sumNonVat, 2));
                    $('#lblSumBaseVAT').text(ShowNumber(sumBaseVat, 2));
                    $('#lblSumVAT').text(ShowNumber(sumVat, 2));
                    $('#lblTotalVAT').text(ShowNumber(sumVat, 2));
                    $('#lblTotalNET').text(ShowNumber(sumBaseVat + sumNonVat, 2));

                    $('#lblAdv').text(ShowNumber(dh.ControlBalance, 2));
                }

                $('#lblSumWHT1').text(ShowNumber(sumWht1, 2));
                $('#lblSumWHT3').text(ShowNumber(sumWht3, 2));
                if (showDetails == true) {
                    $('#lblAmt').text(ShowNumber(sumNet, 2));
                } else {
                    $('#lblAmt').text(ShowNumber(sumBaseVat + sumNonVat, 2));
                    $('#lblVat').text(ShowNumber(sumVat, 2));
                    $('#lblWht').text(ShowNumber(sumWht, 2));
                    $('#lblNet').text(ShowNumber(sumNet, 2));

                    $('#lblBal').text(ShowNumber(dh.ControlBalance - sumNet, 2));
                }
                $('#lblCashOnhand').text(ShowNumber(dh.ControlBalance - sumNet, 2));
                if (showDetails == true) {
                    $('#Body2').html(htmld);
                } else {
                    $('#Body1').html(htmld);
                }
            }

            if (showDetails == true) {
                $('#tbDetail1').css('display', 'none');
                $('#rowWHTSum3').css('display', 'none');
                $('#rowWHTSum1').css('display', 'none');
            } else {
                $('#tbDetail2').css('display', 'none');
            }
        });
    }
</script>