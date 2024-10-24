﻿
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Receipt Slip"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-size: 13px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
    div {
        margin-bottom:10px;
    }
</style>
<div style="text-align:center;width:100%">
    <h2>RECEIPTS</h2>
</div>
<!--
<div style="display:flex;">
    <div style="flex:3;">
        <label>CUSTOMER:</label>
        <br/>
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
        <b>NAME : </b><label id="lblCustName"></label><br />
        <b>ADDRESS : </b><br/><label id="lblCustAddr"></label><br />
        <b>TAX ID : </b><lable id="lblCustTax"></lable>
        <b>BRANCH : </b><lable id="lblTaxBranch"></lable>
    </div>
    <div style="flex:1;border:1px solid black;border-radius:5px;">
        <b>DOC NO. : </b><label id="lblReceiptNo"></label><br />
        <b>REC DATE : </b><label id="lblReceiptDate"></label><br />
    </div>
</div>
<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <thead>
        <tr style="background-color:lightblue;">
            <th height="40" width="260">INV.NO.</th>
            <th width="70">JOB</th>
            <th width="60">AMOUNT</th>
            <th width="30">CURRENCY</th>
            <th width="40">RATE</th>
            <th width="60">THB AMOUNT</th>
        </tr>
    </thead>
    <tbody id="tbDetail">
    </tbody>
    <tfoot>
        <tr style="background-color:lightblue;text-align:center;">
            <td colspan="3"><label id="lblTotalText"></label></td>
            <td colspan="2">TOTAL RECEIPT</td>
            <td colspan="1"><label id="lblTotalNum"></label></td>
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
    $.get(path + 'acc/getreceivereport?type=SUM&branch=' + branch + '&code=' + receiptno, function (r) {
        if (r.receipt.data.length !== null) {
            ShowData(r.receipt.data);
        }
    });
    function ShowData(dt) {
        let h = dt[0];
        //$('#lblCustCode').text(h.CustCode);
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr').text(h.CustTAddr);
        } else {
            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr').text(h.CustEAddr);
        }
        //$('#lblCustTel').text(h.CustPhone);
        $.get(path + 'Master/GetCompany?TaxNumber=' + h.CustTaxID).done(function (r) {
            if (r.company.data.length > 0) {
                let c = r.company.data[0];
                $('#lblTaxBranch').text(c.Branch);
            }
        });
        $('#lblCustTax').text(h.CustTaxID);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateEN(h.ReceiveDate)));
        let html = '';
        let total = 0;

        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.FNet,2) + '</td>';
            html += '<td style="text-align:center">' + d.CurrencyCode + '</td>';
            html += '<td style="text-align:center">' + d.ExchangeRate + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.Net,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);

            total += Number(d.Net);
        }
        $('#lblTotalNum').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(total));
    }
</script>