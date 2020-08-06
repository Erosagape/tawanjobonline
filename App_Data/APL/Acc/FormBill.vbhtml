
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = "BILLING NOTE"
End Code
<style>
    td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

</style>
<div style="display:flex;float:right;">
    <div style="flex:1;" class="text-right">
        <b>NO :</b> <label id="lblBillAcceptNo"></label>
        <br />
        <b>DATE :</b> <label id="lblBillDate"></label>
    </div>
</div>
<br/>
<div style="display:flex;">
    <div class="text-left">
        <table>
            <tr>
                <td><b>NAME :</b></td>
                <td><label id="lblCustName"></label></td>
            </tr>
            <tr>
                <td><b>ADDRESS :</b></td>
                <td><label id="lblCustAddress"></label></td>
            </tr>
            <tr>
                <td><b>CONTACT :</b></td>
                <td><label id="lblCustContact"></label></td>
            </tr>
            <tr>
                <td><b>TEL :</b></td>
                <td><label id="lblCustTel"></label></td>
            </tr>
        </table>
    </div>
</div>
<p>
    <br/>
    I HAVE ALREADY RECEIVED BILLING NOTE AND WILL PAY THE AMOUNT FOLLOWED:
</p>
<br/>
<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
    <thead>
        <tr>
            <th class="text-center" rowspan="2" width="40">ITEMS</th>
            <th class="text-center" rowspan="2" width="100">BILLING NO</th>
            <th class="text-center" rowspan="2" width="80">INVOICE DATE</th>
            <th class="text-center" rowspan="2" width="90">RE-IMBURSEMENT</th>
            <th class="text-center" colspan="2">SERVICE CHARGES</th>
            <th class="text-center" rowspan="2" width="70">VAT</th>
            <th class="text-center" colspan="2">WHD TAX</th>
            <th class="text-center" rowspan="2" width="80">NET</th>
        </tr>
        <tr>
            <th class="text-center" width="80">NON-VAT</th>
            <th class="text-center" width="80">VAT</th>
            <th class="text-center" width="70">1%</th>
            <th class="text-center" width="70">3%</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tfoot>
        <tr>
            <td style="text-align:right" colspan="9">TOTAL</td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
        </tr>
    </tfoot>
</table>
<p>
    <br/>
    I HAVE RECEIVED BILLING NOTE AMOUNT IN GOOD ORDER
</p>
<p>
    <br/>
    BILL RECEIVER : _______________________________________ 
    DATE OF COLLECTION : <label id="lblPaymentDueDate"></label>
</p>
<div style="display:flex">
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
        <br />
        FOR THE CUSTOMER <br /><br /> <br /><br /><br />
        ......................................................... <br />
        __________/_________/________ <br />
        AUTHORIZED SIGNATURE
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
        <br />
        FOR THE APL LOGISTICS SVCS (THAILAND) <br /><br /> <br /><br /><br />
        ......................................................... <br />
        __________/_________/________ <br />
        AUTHORIZED SIGNATURE
    </div>
</div>
<p>
    PLEASE PAY CHEQUE IN NAME OF : APL LOGISTICS SVCS (THAILAND),LTD.<br />
    PAYMENT SHOULD BE PAID BY CROSS CHEQUE IN FAVOR OF : APL LOGISTICS SVCS (THAILAND),LTD.<br />
    SIGN ON RECEIVER AND ASSIGNED PAYMENT DATE AND SEND THIS PAPER TO APL LOGISTICS SVCS (THAILAND),LTD<br />
</p>
<script type="text/javascript">
    let path = '@Url.Content("~")';

    let branch = getQueryString('branch');
    let billno = getQueryString('code');
    $.get(path + 'acc/getbilling?branch=' + branch + '&code=' + billno, function (r) {
        if (r.billing.header !== null) {
            ShowData(r.billing);
        }
    });
    function ShowData(data) {
        if (data.header.length > 0) {
            $('#lblBillAcceptNo').text(data.header[0][0].BillAcceptNo);
            $('#lblBillDate').text(ShowDate(CDateEN(data.header[0][0].BillDate)));
            $('#lblPaymentDueDate').text(ShowDate(CDateEN(data.header[0][0].DuePaymentDate)));
        }
        if (data.customer.length > 0) {
            //$('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' Branch : '+ data.customer[0][0].Branch);
            $('#lblCustName').text(data.customer[0][0].NameEng);
            $('#lblCustContact').text(data.customer[0][0].DMailAddress);
            $('#lblCustTel').text(data.customer[0][0].Phone);
            $('#lblCustAddress').text(data.customer[0][0].EAddress1 + '\n' + data.customer[0][0].EAddress2 + ' '+data.customer[0][0].TProvince+ ' ' + data.customer[0][0].TPostCode);
        }
        if (data.detail.length > 0) {
            let total = 0;
            let serv = 0;
            let adv = 0;
            let vat = 0;
            let wh1 = 0;
            let wh3 = 0;

            let dv = $('#tbDetail');
            let html = '';
            let i = 0;
            for (let dr of data.detail[0]) {
                i += 1;
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + dr.InvNo + '</td>';
                html += '<td>' + ShowDate(CDateEN(dr.InvDate)) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtChargeNonVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtChargeVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + (dr.AmtWHRate == 1? ShowNumber(dr.AmtWH, 2):'0.00') + '</td>';
                html += '<td style="text-align:right">' + (dr.AmtWHRate !== 1? ShowNumber(dr.AmtWH, 2):'0.00') + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtTotal, 2) + '</td>';
                html += '</tr>';

                total += Number(dr.AmtTotal);
                serv += Number(dr.AmtChargeNonVAT);
                adv += Number(dr.AmtAdvance);
                vat += Number(dr.AmtVAT);
                wh1 += Number(dr.AmtWHRate == 1 ? ShowNumber(dr.AmtWH, 2) : 0);
                wh3 += Number(dr.AmtWHRate !== 1 ? ShowNumber(dr.AmtWH, 2) : 0);
            }
            dv.html(html);

            $('#lblBillTotal').text(ShowNumber(total,2));
            //$('#lblBillTotalEng').text(CNumEng(total));
        }
    }
</script>