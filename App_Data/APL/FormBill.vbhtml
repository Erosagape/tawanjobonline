
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
        <p>
            <b>NAME :</b> <label id="lblCustName"></label>
            <br />
            <b>ADDRESS :</b> <label id="lblCustAddress"></label>
        </p>
    </div>
</div>
<p>
    <br/>
    I have already received billing note and will pay the amount followed.
</p>
<br/>
<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
    <thead>
        <tr>
            <th class="text-center" width="50">ITEMS</th>
            <th class="text-center" width="130">BILLING NO.</th>
            <th class="text-center" width="100">ISSUING DATE</th>
            <th class="text-center" width="100">BAHT</th>
            <th class="text-center">REMARK</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tfoot>
        <tr>
            <td style="text-align:right" colspan="3">TOTAL</td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
            <td></td>
        </tr>
    </tfoot>
</table>
<p>
    <br/>
    I have received billing note amount in good order
</p>
<p>
    <br/>
    Bill Receiver _______________________________________ 
    Date of Collection : <label id="lblPaymentDueDate"></label>
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
            $('#lblBillDate').text(ShowDate(CDateTH(data.header[0][0].BillDate)));
            $('#lblPaymentDueDate').text(ShowDate(CDateTH(data.header[0][0].DuePaymentDate)));
        }
        if (data.customer.length > 0) {
            //$('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' Branch : '+ data.customer[0][0].Branch);
            $('#lblCustName').text(data.customer[0][0].NameEng);
            $('#lblCustAddress').text(data.customer[0][0].EAddress1 + '\n' + data.customer[0][0].EAddress2);
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
                html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtTotal, 2) + '</td>';
                html += '<td>' + dr.Remark1 + '</td>';
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