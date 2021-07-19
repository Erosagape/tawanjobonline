
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    * {
        font-size: 13px;
    }

    #tbDetail td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    div {
        margin-bottom: 10px;
    }

    #dvFooter {
        display: none;
    }
</style>
<div style="display:flex;flex-direction:column">
    <div style="text-align:center;width:100%">
        <h2><label id="lblDocType">TAX-INVOICE</label></h2>
    </div>
    <div id="dvCopy" style="text-align:right;width:100%">
    </div>
    <div style="display:flex;">
        <div style="flex:3;border:1px solid black;border-radius:5px;">
            <b>NAME : </b><label id="lblCustName"></label><br />
            <b>ADDRESS : </b><br /><label id="lblCustAddr"></label><br />
            <b>TAX ID : </b><lable id="lblCustTax"></lable>
            <b>BRANCH : </b><label id="lblTaxBranch"></label>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;">
            <b>NO. : </b><label id="lblReceiptNo"></label><br />
            <b>ISSUE DATE : </b><label id="lblReceiptDate"></label><br />
        </div>
    </div>

    <table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
            <tr style="background-color:lightblue;">
                <td height="40" width="270">INV.NO.</td>
                <td width="70">JOB</td>
                <td width="60">ADVANCE</td>
                <td width="60">SERVICE</td>
                <td width="30">VAT</td>
                <td width="30">WHT</td>
                <td width="30">TOTAL</td>
            </tr>
        <tbody id="tbDetail"></tbody>
            <tr style="background-color:lightblue;text-align:right;">
                <td style="text-align:center"><label id="lblTotalText"></label></td>
                <td>TOTAL AMOUNT</td>
                <td><label id="lblTotalADV"></label></td>
                <td><label id="lblTotalBeforeVAT"></label></td>
                <td><label id="lblTotalVAT"></label></td>
                <td><label id="lblTotalWHT"></label></td>
                <td><label id="lblTotalSumVAT"></label></td>
            </tr>
            <tr style="background-color:lightblue;text-align:right;">
                <td colspan="6">TOTAL RECEIPT</td>
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
        <!--
        <div class="text-left" style="border:1px solid black;flex:2">
            PLEASE REMIT TO ACCOUNT NO: 170-279834-5<br />
            "DAMON GOOD SERVICES CO.,LTD"<br />
            SIAM COMMERCIAL BANK PUBLIC LIMITED<br />
            THE MALL THA-PHRA BRANCH
        </div>
            -->
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
        //$('#lblCustTel').text(h.CustPhone);
        $.get(path + 'Master/GetCompany?TaxNumber=' + h.CustTaxID).done(function (r) {
            if (r.company.data.length > 0) {
                let c = r.company.data[0];
                $('#lblTaxBranch').text(c.Branch);
            }
        });
        $('#lblCustTax').text(h.CustTaxID);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiveDate)));
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;
        let adv = 0;
        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:right">' + (CDbl(d.AmtAdvance) > 0 ? ShowNumber((d.AmtAdvance), 2) : '0.00') + '</td>';
            html += '<td style="text-align:right">' + (CDbl(d.AmtCharge)>0 ? ShowNumber(d.AmtCharge,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (CDbl(d.AmtCharge) > 0 ? ShowNumber(d.InvVAT, 2) : '0.00') + '</td>';
            html += '<td style="text-align:right">' + (CDbl(d.AmtCharge) > 0 ? ShowNumber(d.Inv50Tavi, 2) : '0.00') + '</td>';
            html += '<td style="text-align:right">' + (CDbl(d.AmtCharge) > 0 ? ShowNumber((d.AmtCharge + d.InvVAT), 2) : '0.00') + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            service += Number(d.AmtCharge);
            adv += Number(d.AmtAdvance);
            if (CDbl(d.AmtCharge) > 0) {
                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
            }
            total += Number(d.InvAmt) + Number(d.InvVAT);
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
        $('#lblTotalSumVAT').text(ShowNumber(service+vat, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(adv+service+vat, 2));
        $('#lblTotalText').text(CNumThai(adv+service+vat));
    }
</script>