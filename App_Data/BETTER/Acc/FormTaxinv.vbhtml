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
    <h2><label id="lblDocType" style="font-size:18px;">TAX-INVOICE</label></h2>
</div>
<div id="dvCopy" style="text-align:right;width:100%">
</div>
<div style="display:flex;">
    <div style="flex:3;border:1px solid black;border-radius:5px;margin-right:8px;padding:5px 5px 5px 5px;">
        NAME : <label id="lblCustName"></label><br />
        ADDRESS : <label id="lblCustAddr"></label><br />
        TEL : <label id="lblCustTel"></label><br />
        TAX-ID : <lable id="lblCustTax"></lable>
    </div>
    <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;">
        NO. : <label id="lblReceiptNo"></label><br />
        ISSUE DATE : <label id="lblReceiptDate"></label><br />
    </div>
</div>

<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <tr style="background-color:lightblue;">
        <th height="40" width="200">INV.NO.</th>
        <th width="40">DATE</th>
        <th width="70">JOB</th>
        <th width="20">CUR</th>
        <th width="20">EXC</th>
        <th width="60">SERVICE</th>
        <th width="30">VAT</th>
        <th width="30">WHT</th>
        <th width="60">ADVANCE</th>
        <th width="60">TOTAL</th>
    </tr>
    <tbody id="tbDetail"></tbody>
    <tr style="background-color:lightblue;text-align:right;">
        <td style="text-align:center" colspan="2"><label id="lblTotalText"></label></td>
        <td colspan="3">TOTAL AMOUNT</td>
        <td><label id="lblTotalBeforeVAT"></label></td>
        <td><label id="lblTotalVAT"></label></td>
        <td><label id="lblTotalWHT"></label></td>
        <td><label id="lblTotalADV"></label></td>
        <td><label id="lblTotalNET"></label></td>
    </tr>
    <tr style="background-color:lightblue;text-align:right;">
        <td colspan="9">TOTAL RECEIPT</td>
        <td colspan="1"><label id="lblTotalAfterVAT"></label></td>
    </tr>
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

        ได้รับทราบ / ตรวจสอบรายการและราคาค่าบริการเรียบร้อยแล้ว
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
        ลูกค้า/ผู้ชำระเงิน
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

        ใบเสร็จรับเงินสมบูรณ์ต่อเมื่อมีลายเซ็นของเจ้าหน้าที่การเงิน
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
        ผู้รับชำระเงิน
    </div>
</div>
<div style="text-align:center">
    (โปรดตรวจสอบควำมถูกต้องของรำยกำรในเอกสำรฉบับนี้ภำยใน 7 วัน มิฉะนั้นบริษัทฯ จะถือว่ำเอกสำรฉบับนี้ถูกต้องสมบูรณ์)
    <br />
    ใบเสร็จรับเงิน/ใบกำกับภำษีนี้จะสมบูรณ์ก็ต่อเมื่อมีลำยเซ็นต์ของผู้รับเงินและผู้ได้รับมอบอำนำจเท่ำนั้น
    <br />
    และต่อเมื่อบริษัทฯ ได้เรียกเก็บเงินตำมเช็คและเงินเข้ำบัญชีบริษัทครบถ้วนแล้ว
    <br />
    This Receipt/Tax invoice is not valid unless signed by our bill collector and authorized person and that the cheque has already been cleared by bank.
</div>
<script type="text/javascript">
    $('#imgLogo').hide();
    $('#imgLogoAdd').show();

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
        let serviceText = '';
        switch (h.ReceiptType) {
            case 'TAX':
                $('#lblDocType').text('TAX-INVOICE/RECEIPT');
                serviceText = 'Service Charges';
                break;
            case 'SRV':
                $('#lblDocType').text('TAX-INVOICE');
                serviceText = 'Service Charges';
                break;
            default:
                $('#lblDocType').text('RECEIPT');
                serviceText = 'Transportation Charges';
                break;
        }
        //$('#lblCustCode').text(h.CustCode);
        let branchText = '';
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr').text(h.CustTAddr);
            if (Number(h.CustBranch) == 0) {
                branchText = ' สาขา: สำนักงานใหญ่';
            } else {
                branchText = CCode(Number(h.CustBranch));
            }
        } else {
            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr').text(h.CustEAddr);
            if (Number(h.CustBranch) == 0) {
                branchText = ' BRANCH: HEAD OFFICE';
            } else {
                branchText = CCode(Number(h.CustBranch));
            }
        }
        $('#lblCustTel').text(h.CustPhone);
        $('#lblCustTax').text(h.CustTaxID + branchText);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiveDate)));
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let amt = 0;
        let total = 0;
        let adv = 0;
        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td style="text-align:center">' + ShowDate(d.InvoiceDate) + '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:center">' + d.CurrencyCode + '</td>';
            html += '<td style="text-align:center">' + d.ExchangeRate + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge > 0 ? ShowNumber(d.AmtCharge,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.InvVAT>0? ShowNumber(d.InvVAT,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.Inv50Tavi>0? ShowNumber(d.Inv50Tavi,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtAdvance > 0 ? ShowNumber(d.AmtAdvance, 2) : '0.00') + '</td>';
            html += '<td style="text-align:right">' + ShowNumber((d.AmtCharge + d.AmtAdvance + d.InvVAT - d.Inv50Tavi) * d.ExchangeRate.toFixed(4), 2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            //if (d.AmtCharge > 0) {
                service += Number(d.AmtCharge);
                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
                //amt += Number(d.InvAmt) + Number(d.InvVAT);
            amt += Number(d.Net)
            //} else {
                adv +=Number(d.AmtAdvance);
            //}
            total +=Number(d.InvTotal);
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(amt, 2));
        $('#lblTotalNET').text(ShowNumber(amt, 2));
        $('#lblTotalText').text(CNumThai(CDbl(amt,2)));
    }
</script>