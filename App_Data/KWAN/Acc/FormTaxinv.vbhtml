﻿
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    td {
        font-size: 12px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
</style>
<div style="text-align:center;width:100%">
    <h2><label id="lblDocType">TAX-INVOICE</label></h2>
</div>
<!--
<div style="display:flex;">
    <div style="flex:3;">
        <label>CUSTOMER:</label>
        <br />
        <label id="lblCustCode"></label>
    </div>
    <div style="flex:1">
        BRANCH: <label id="lblBranchName">@ViewBag.PROFILE_DEFAULT_BRANCH_NAME</label>
        <br />
        TAX ID: <label id="lblTaxNumer">@ViewBag.PROFILE_TAXNUMBER</label>
    </div>
</div>
-->
<div id="dvCopy" style="text-align:right;width:100%">
</div>
<div style="display:flex;">
    <div style="flex:3;border:1px solid black;border-radius:5px;">
        NAME : <label id="lblCustName"></label><br />
        ADDRESS : <label id="lblCustAddr"></label><br />
        TEL : <label id="lblCustTel"></label><br />
        TAX-ID : <lable id="lblCustTax"></lable>
    </div>
    <div style="flex:1;border:1px solid black;border-radius:5px;">
        NO. : <label id="lblReceiptNo"></label><br />
        ISSUE DATE : <label id="lblReceiptDate"></label><br />
    </div>
</div>

<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <thead>
        <tr style="background-color:lightblue;">
            <th height="40" width="60">INV.NO.</th>
            <th width="200">DESCRIPTION</th>
            <th width="70">JOB</th>
            <th width="60">SERVICE</th>
            <th width="30">VAT</th>
            <th width="30">WHT</th>
            <th width="60">ADVANCE</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tfoot>
        <tr style="background-color:lightblue;text-align:right;">
            <td colspan="4" style="text-align:center"><label id="lblTotalText"></label></td>
            <td colspan="2">TOTAL AMOUNT</td>
            <td colspan="1"><label id="lblTotalBeforeVAT"></label></td>
        </tr>
        <tr style="background-color:lightblue;text-align:right;">            
            <td colspan="6">TOTAL VAT</td>
            <td colspan="1"><label id="lblTotalVAT"></label></td>
        </tr>
        <tr style="background-color:lightblue;text-align:right;">
            <td colspan="6">TOTAL RECEIPT</td>
            <td colspan="1"><label id="lblTotalAfterVAT"></label></td>
        </tr>
    </tfoot>
</table>
<p>
    PAY BY
</p>
<div style="display:flex;flex-direction:column">
    <div>
        <label><input type="checkbox" name="vehicle1" value=""> CASH</label>
        DATE_____________  AMOUNT______________BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle2" value=""> CHEQUE</label>
        DATE_____________  NO_______________  BANK_________________  AMOUNT______________BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle3" value=""> TRANSFER</label>
        DATE_____________  BANK_________________  AMOUNT______________BAHT
    </div>
</div>
<br />
<div style="display:flex;">
    <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">

        FOR THE CUSTOMER
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
        AUTHORIZED SIGNATURE
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

        FOR THE COMPANY
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');
    let ans = confirm('OK to print Original or Cancel For Copy');
    if (ans == true) {
        $('#dvCopy').html('<b>**ORIGINAL**</b>');
    } else {
        $('#dvCopy').html('<b>**COPY**</b>');
    }
    $.get(path + 'acc/getreceivereport?branch=' + branch + '&code=' + receiptno, function (r) {
        if (r.receipt.data.length !== null) {
            ShowData(r.receipt.data);
        }
    });
    function ShowData(dt) {
        let h = dt[0];
        switch (h.ReceiptType) {
            case 'TAX':
                $('#lblDocType').text('TAX-INVOICE/RECEIPT');
                break;
            case 'SRV':
                $('#lblDocType').text('TAX-INVOICE');
                break;
            default:
                $('#lblDocType').text('RECEIPT');
                break;
        }
        //$('#lblCustCode').text(h.CustCode);
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr').text(h.CustTAddr);
        } else {
            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr').text(h.CustEAddr);
        }
        $('#lblCustTel').text(h.CustPhone);
        $('#lblCustTax').text(h.CustTaxID);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;

        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td>' + d.SICode+ '-'+ d.SDescription + '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvVAT,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Inv50Tavi,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? '0.00':ShowNumber(d.InvTotal,2)) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            if (d.AmtCharge > 0) {
                service += Number(d.InvAmt);
                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
                total += Number(d.InvAmt) + Number(d.InvVAT);
            }
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(total));
    }
</script>