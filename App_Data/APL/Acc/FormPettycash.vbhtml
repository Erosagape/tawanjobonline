﻿@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "CLEARING ADVANCE SLIP"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-family: Tahoma;
        font-size: 11px;
    }

    #pFooter, #dvFooter {
        display: none;
    }

    td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    .underline {
        border-bottom: solid;
        border-width: thin;
        border-collapse: collapse;
    }
</style>
<div style="display:flex;flex-direction:column">
    <b>PETTY CASH FUND</b>
    <b>RECONCILATION AND REIMBURSEMENT FORM</b>
    <div style="display:flex;width:100%;flex-direction:column">
        <div style="flex:1">
            <table>
                <tr>
                    <td style="width:40%">VENDOR ID</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblVenderID">EMP9019713</label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">CUSTODIAN'S NAME</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblVenderName">NITTAMAPORN RATTANAMANEE</label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">INVOICE NO</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblInvNo"></label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">DATE</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblDate"></label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">CURRENCY</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblCurrency">THB</label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">COST CENTRE</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblCostCenter">9762999</label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">ACCOUNT</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblAccCode">11901110</label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">FORM COMPLETE BY</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblUserID">NITTAMAPORN RATTANAMANEE(GY)</label>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">CASH ON HAND</td>
                    <td class="underline" style="width:60%;">
                        <label id="lblCashOnhand"></label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="flex:1">
            <br />
            <table border="1">
                <tr>
                    <td>No</td>
                    <td>PO Nos</td>
                    <td>VAT Type</td>
                    <td>Line Code</td>
                    <td>WHT Code</td>
                    <td>VAT Code</td>
                    <td>VAT Amt</td>
                    <td>NET Amt (THB)</td>
                </tr>
                <tr>
                    <td>1</td>
                    <td></td>
                    <td>Exempt</td>
                    <td></td>
                    <td>LRN</td>
                    <td>GE</td>
                    <td></td>
                    <td style="text-align:right"><label id="lblSumNonVAT"></label></td>
                </tr>
                <tr>
                    <td>2</td>
                    <td></td>
                    <td>Recoverable</td>
                    <td></td>
                    <td>LRN</td>
                    <td>I7</td>
                    <td style="text-align:right"><label id="lblSumVAT"></label></td>
                    <td style="text-align:right"><label id="lblSumBaseVAT"></label></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>TOTAL</td>
                    <td style="text-align:right"><label id="lblTotalVAT"></label></td>
                    <td style="text-align:right"><label id="lblTotalNET"></label></td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <table border="1">
        <tr>
            <td>Document No.</td>
            <td>Date</td>
            <td>Req.By</td>
            <td>Description</td>
            <td>CC</td>
            <td>Acc</td>
            <td>Amt</td>
            <td>VAT</td>
            <td>WHT</td>
            <td>Status</td>
        </tr>
        <tbody id="tbDetail"></tbody>
    </table>
    <br />
    Total By Cost Centre:
    <table border="1">
        <tr>
            <td>Description CC/Acc</td>
            <td>CC</td>
            <td>ACC</td>
            <td>Amt</td>
            <td>VAT</td>
            <td>WHT</td>
            <td>Total</td>
        </tr>
        <tbody id="tbSummary"></tbody>
        <tr>
            <td colspan="3">Total Re-imbursement</td>
            <td style="text-align:right"><label id="lblAmt"></label></td>
            <td style="text-align:right"><label id="lblVat"></label></td>
            <td style="text-align:right"><label id="lblWht"></label></td>
            <td style="text-align:right"><label id="lblNet"></label></td>
        </tr>
        <tr>
            <td colspan="3">With-holding Tax (3%,1.5%)</td>
            <td></td>
            <td></td>
            <td></td>
            <td style="text-align:right"><label id="lblSumWHT3"></label></td>
        </tr>
        <tr>
            <td colspan="3">With-holding Tax (1%)</td>
            <td></td>
            <td></td>
            <td></td>
            <td style="text-align:right"><label id="lblSumWHT1"></label></td>
        </tr>
        <tr>
            <td colspan="3">Petty Cash Balance</td>
            <td></td>
            <td></td>
            <td></td>
            <td style="text-align:right"><label id="lblAdv"></label></td>
        </tr>
        <tr>
            <td colspan="3">Cash on hand</td>
            <td></td>
            <td></td>
            <td></td>
            <td style="text-align:right"><label id="lblBal"></label></td>
        </tr>
    </table>
</div>
Group Accounts:<label id="lblBookCode"></label>
<br />
<br />
Re-imbursement Approve By ___________________________________ Date ___________________
<br />
Re-imbursement Request By ___________________________________ Date ___________________
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const branchcode = getQueryString("Branch");
    const bookno = getQueryString("Code");
    const id = getQueryString("DocNo");

    if (branchcode !== '' && (bookno !== '' || id !== '')) {
        let url = 'Acc/GetVoucherDetail?BranchCode=' + branchcode;
        if (bookno !== '') {
            url += '&BookNo=' + bookno;
        }
        if (id !== '') {
            url += '&DocNo=' + id;
        }
        $.get(path + url, function (r) {
            if (r.data.header.length > 0) {
                let dt = r.data.header[0].Table;
                let htmls = '';
                for (let s of dt) {
                    if (s.Amt !== null) {
                    htmls = '<tr>';
                    htmls += '<td>' + s.GLDesc + '</td>';
                    htmls += '<td>' + s.CostCenter + '</td>';
                    htmls += '<td>' + s.AccountCode + '</td>';
                    htmls += '<td style="text-align:right;">' + ShowNumber(s.Amt, 2) + '</td>';
                    htmls += '<td style="text-align:right;">' + ShowNumber(s.Vat, 2) + '</td>';
                    htmls += '<td style="text-align:right;">' + ShowNumber(s.Wht, 2) + '</td>';
                    htmls += '<td style="text-align:right;">' + ShowNumber(s.Net,2) + '</td>';
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
                $('#lblAdv').text(ShowNumber(dh.ControlBalance,2));

                let dr = r.data.detail[0].Table;
                let htmld = '';
                let sumBaseVat = 0;
                let sumNonVat = 0;
                let sumVat = 0;
                let sumWht = 0;
                let sumWht1 = 0;
                let sumWht3 = 0;
                let sumNet = 0;
                for (let d of dr) {
                    if (d.TotalAdvance>0) {
                        if (d.TotalVAT > 0) {
                            sumBaseVat += (Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi));
                        } else {
                            sumNonVat += (Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi));
                        }
                        sumWht += Number(d.Total50Tavi);
                        if (d.Rate50Tavi == 1) {
                            sumWht1 += Number(d.Total50Tavi);
                        } else {
                            sumWht3 += Number(d.Total50Tavi);
                        }
                        sumVat += Number(d.TotalVAT);
                        sumNet += (Number(d.TotalAdvance) + Number(d.TotalVAT) - Number(d.Total50Tavi));

                        htmld = '<tr>';
                        htmld += '<td>' + d.DocNo + '</td>';
                        htmld += '<td>' + ShowDate(d.AdvDate) + '</td>';
                        htmld += '<td>' + d.EmpCode + '</td>';
                        htmld += '<td>' + d.SDescription + '</td>';
                        htmld += '<td>' + d.CostCenter + '</td>';
                        htmld += '<td>' + d.AccountCost + '</td>';
                        htmld += '<td style="text-align:right">' + ShowNumber(d.TotalAdvance, 2) + '</td>';
                        htmld += '<td style="text-align:right">' + ShowNumber(d.TotalVAT, 2) + '</td>';
                        htmld += '<td style="text-align:right">' + ShowNumber(d.Total50Tavi, 2) + '</td>';
                        htmld += '<td>Closed</td>';
                        htmld += '</tr>';
                        $('#tbDetail').append(htmld);

                    }
                }
                $('#lblSumBaseVAT').text(ShowNumber(sumBaseVat, 2));
                $('#lblSumNonVAT').text(ShowNumber(sumNonVat, 2));
                $('#lblSumVAT').text(ShowNumber(sumVat, 2));
                $('#lblSumWHT1').text(ShowNumber(sumWht1, 2));
                $('#lblSumWHT3').text(ShowNumber(sumWht3, 2));
                $('#lblTotalVAT').text(ShowNumber(sumVat, 2));
                $('#lblTotalNET').text(ShowNumber(sumBaseVat + sumNonVat, 2));
                $('#lblAmt').text(ShowNumber(sumBaseVat + sumNonVat, 2));
                $('#lblVat').text(ShowNumber(sumVat, 2));
                $('#lblWht').text(ShowNumber(sumWht, 2));
                $('#lblNet').text(ShowNumber(sumNet, 2));
                $('#lblBal').text(ShowNumber(dh.ControlBalance - sumNet, 2));
                $('#lblCashOnhand').text(ShowNumber(dh.ControlBalance - sumNet, 2));
            }

        });
    }
</script>