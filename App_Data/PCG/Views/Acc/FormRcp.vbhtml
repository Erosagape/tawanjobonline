
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

    tbody > tr {
        border-bottom-color: white !important;
    }
</style>
<div style="text-align:center;width:100%">
    <h2><label id="lblDocType" style="font-size:18px">RECEIPT</label></h2>
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
        <br />
        <div id="dvRemark"></div>
    </div>
</div>

<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
        <tr style="background-color:lightblue;">
            <th height="40" width="350">DESCRIPTION</th>
            <th height="40" width="80">INVOICE</th>
            <th width="60">RATE</th>
            <th width="60">CHARGE</th>
        </tr>
    <tbody id="tbDetail"></tbody>
        <tr style="background-color:lightblue;text-align:right;">
            <td colspan="2">TOTAL</td>
            <td style="text-align:center"><label id="lblCurrencyCode"></label></td>
            <td><label id="lblFTotalNet"></label></td>
        </tr>
</table>

<script type="text/javascript">
    //$('#imgLogo').hide();
    $('#imgLogoAdd').hide();

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
        $('#lblCustName').text(h.CustEName);
        $('#lblCustAddr').text(h.CustEAddr);
        if (Number(h.CustBranch) == 0) {
            branchText = ' BRANCH: HEAD OFFICE';
        } else {
            branchText = CCode(Number(h.CustBranch));
        }
        $('#lblCustTel').text(h.CustPhone);
        $('#lblCustTax').text(h.CustTaxID + branchText);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblCurrencyCode').text(h.CurrencyCode);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        $('#lblFTotalNet').text(ShowNumber(h.FTotalNet, 2));
        $('#lblTotalText').text(CNumThai(h.FTotalNet));
        $('#dvRemark').html(CStr(h.TRemark));
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;
        let adv = 0;
        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:left">' + d.SDescription + ' '+ d.ExpSlipNO + '</td>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td style="text-align:center">' + d.DCurrencyCode + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.Net+d.Amt50Tavi,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            if (d.AmtCharge > 0) {
                service += Number(d.Amt);
                vat += Number(d.AmtVAT);
                wht += Number(d.Amt50Tavi);
                total += Number(d.Net);
            } else {
                adv +=Number(d.Net);
            }
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
    }
</script>