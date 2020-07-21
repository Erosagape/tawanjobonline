
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    * {
        font-size: 13px;
    }

    td {
        font-size: 13px;
    }

    th {
        font-size: 14px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter {
        display: none;
    }

    .roundbox {
        border: 1px solid black;
        border-radius: 5px;
        margin: 2px 2px 2px 2px;
        padding: 2px 2px 2px 2px;
    }
</style>
<div style="text-align:right;width:100%;">
    <label style="font-size:16px;font-weight:bold;">TAX INVOICE/OFFICIAL RECEIPT</label>
    <br />
    <label style="font-size:16px;font-weight:bold;">ใบกำกับภาษี/ใบเสร็จรับเงิน</label>
</div>
<br />
<span class="roundbox">CUSTOMER :</span>
<label>TAX REFERENCE-ID:</label>
<label id="lblCustTax"></label>
<label>BRANCH:</label>
<label id="lblCustBranch"></label>
<div style="display:flex;width:100%">
    <div style="flex:3" class="roundbox">
        NAME : <label id="lblCustName"></label>
        <br />
        ADDRESS : <label id="lblCustAddr"></label><br />
    </div>
    <div style="flex:1;" class="roundbox">
        DATE : <label id="lblReceiptDate"></label><br />
        NO. : <label id="lblReceiptNo"></label><br />
    </div>
</div>
<br />
<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <thead>
        <tr style="background-color:lightblue;">
            <th height="40" width="60">NO.</th>
            <th width="250">DESCRIPTION</th>
            <th width="70">ADVANCE REIMBURSEMENT</th>
            <th width="60">TRANSPORT</th>
            <th width="60">VAT</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                1
            </td>
            <td>
                Service Charge NON VAT
            </td>
            <td></td>
            <td style="text-align:right">
                <label id="lblServNonVat"></label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                2
            </td>
            <td>
                Service Charge VAT
            </td>
            <td></td>
            <td></td>
            <td style="text-align:right">
                <label id="lblServVat"></label>
            </td>
        </tr>
        <tr>
            <td>
                3
            </td>
            <td>
                Advance Reimbursement
            </td>
            <td style="text-align:right">
                <label id="lblSumAdv"></label>
            </td>
            <td></td>
            <td></td>
        </tr>
    </tbody>
    <tfoot>
        <tr style="text-align:right;">
            <td colspan="2" rowspan="6" style="text-align:left;vertical-align:top;">
                W/T :<label id="lblTotalWHT"></label>
                <div id="dvInv"></div>
            </td>
            <td colspan="2">TOTAL VAT</td>
            <td colspan="1"><label id="lblTotalBeforeVAT"></label></td>
        </tr>
        <tr style="text-align:right;">
            <td colspan="2">TOTAL NON-VAT</td>
            <td colspan="1"><label id="lblTotalNONVAT"></label></td>
        </tr>
        <tr style="text-align:right;">
            <td colspan="2">VAT</td>
            <td colspan="1"><label id="lblTotalVAT"></label></td>
        </tr>
        <tr style="text-align:right;">
            <td colspan="2">Advance Reimbursement</td>
            <td colspan="1"><label id="lblTotalADV"></label></td>
        </tr>
        <tr style="text-align:right;">
            <td colspan="2">GRAND TOTAL</td>
            <td colspan="1"><label id="lblTotalAfterVAT"></label></td>
        </tr>
        <tr>
            <td colspan="3">
                <div>
                    Payment Detail
                </div>
                <div>
                    <label><input type="checkbox" name="vehicle1" id="chkCash" value=""> CASH</label>
                    AMOUNT <label id="lblCashAmount">___________________</label> BAHT
                </div>
                <div>
                    <label><input type="checkbox" name="vehicle2" id="chkCheque" value=""> CHEQUE</label>
                    BANK / BRANCH <label id="lblChqBank">___________________</label> <br />
                    NO <label id="lblChqNo">___________________</label>  <br/>
                    AMOUNT <label id="lblChqAmount">___________________</label> BAHT
                </div>
                <div>                    
                    ________________________<br/>
                    ______/_________/_______
                </div>
            </td>
        </tr>
    </tfoot>
</table>
<div style="display:flex;text-align:center">
    <div class="roundbox" style="flex:1">
        FOR THE CUSTOMER
        <br /><br /><br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ____/_______/_____
    </div>
    <div class="roundbox" style="flex:1">
        FOR THE APL LOGISTICS SVCS THAILAND
        <br /><br /><br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ____/_______/_____
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');

    $.get(path + 'acc/getreceivereport?branch=' + branch + '&code=' + receiptno, function (r) {
        if (r.receipt.data.length !== null) {
            ShowData(r.receipt.data);
        }
    });
    function ShowData(dt) {
        let h = dt[0];
        $('#lblCustName').text(h.CustEName);
        $('#lblCustAddr').text(h.CustEAddr);
        $('#lblCustTel').text(h.CustPhone);
        $('#lblCustTax').text(h.CustTaxID);
        if (Number(h.CustBranch) == 0) {
            $('#lblCustBranch').text('HEAD OFFICE');
        } else {
            $('#lblCustBranch').text(h.CustBranch);
        }
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        if (h.TRemark.indexOf(':') > 0) {
            let vData = h.TRemark.split(':');
            switch (vData.length) {
                case 1:
                    if (vData[0] == 'CHQ') {
                        $('#chkCheque').prop('checked',true);
                    } else {
                        $('#chkCash').prop('checked', true);
                    }
                    break;
                case 2:
                    if (vData[0] == 'CHQ') {
                        $('#chkCheque').prop('checked', true);
                        $('#lblChqAmount').text(ShowNumber(vData[1], 2));

                        $('#lblChqAmount').css('text-decoration', 'underline');
                    } else {
                        $('#chkCash').prop('checked', true);
                        $('#lblCashAmount').text(ShowNumber(vData[1], 2));
                        $('#lblCashAmount').css('text-decoration', 'underline');
                    }
                    break;
                case 3:
                    if (vData[0] == 'CHQ') {
                        $('#chkCheque').prop('checked', true);
                        $('#lblChqAmount').text(ShowNumber(vData[1], 2));
                        $('#lblChqBank').text(vData[2]);

                        $('#lblChqAmount').css('text-decoration', 'underline');
                        $('#lblChqBank').css('text-decoration', 'underline');
                    } else {
                        $('#chkCash').prop('checked', true);
                        $('#lblCashAmount').text(ShowNumber(vData[1], 2));
                        $('#lblCashAmount').css('text-decoration', 'underline');
                    }
                    break;
                case 4:
                    if (vData[0] == 'CHQ') {
                        $('#chkCheque').prop('checked', true);
                        $('#lblChqAmount').text(ShowNumber(vData[1], 2));
                        $('#lblChqBank').text(vData[2]);
                        $('#lblChqNo').text(vData[3]);

                        $('#lblChqAmount').css('text-decoration', 'underline');
                        $('#lblChqBank').css('text-decoration', 'underline');
                        $('#lblChqNo').css('text-decoration', 'underline');
                    } else {
                        $('#chkCash').prop('checked', true);
                        $('#lblCashAmount').text(ShowNumber(vData[1], 2));
                        $('#lblCashAmount').css('text-decoration', 'underline');
                    }
                    break;
            }
        }
        let service = 0;
        let transport = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;
        let adv = 0;
        let invlist = [];
        let invno = '';
        for (let d of dt) {
            if (invlist.indexOf(d.InvoiceNo) < 0) {
                if (invno !== '') invno += ',';
                invno += d.InvoiceNo;
                invlist.push(d.InvoiceNo);
            }
            if (d.AmtCharge > 0) {
                if (d.AmtVAT == 0) {
                    transport += Number(d.Amt);
                } else {
                    service += Number(d.Amt);
                }
                vat += Number(d.AmtVAT);
                wht += Number(d.Amt50Tavi);
                total += Number(d.Net);
            } else {
                adv += Number(d.Net);
                total += Number(d.Net);
            }
        }
        if (service > 0) $('#lblServVat').text(ShowNumber(service, 2));
        if (transport > 0) $('#lblServNonVat').text(ShowNumber(transport, 2));
        if (adv > 0) $('#lblSumAdv').text(ShowNumber(adv, 2));

        $('#dvInv').html('REF: ' +invno);
        $('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalNONVAT').text(ShowNumber(transport, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(total+wht, 2));
    }
</script>