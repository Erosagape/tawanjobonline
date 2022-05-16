
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
<div style="float:right;">
    <div style="flex:1;" class="text-right">
        <b>NO :</b> <label id="lblBillAcceptNo"></label>
        <br />
        <b>DATE :</b> <label id="lblBillDate"></label>
    </div>
</div>
<br/>
<div style="display:flex;flex-direction:column;width:100%">
<div style="display:flex;">
    <div class="text-left">
        <p>
            <b>NAME :</b> <label id="lblCustName"></label>
            <br />
            <b>ADDRESS :</b> <label id="lblCustAddress"></label>
            <br />
            <b>CUSTOMER PO :</b> <label id="lblCustPo"></label>
</p>
    </div>
</div>

<p>
    <br/>
    I have already received billing note and will pay the amount followed.
</p>
<br/>
<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
        <tr>
            <th class="text-center" rowspan="2" width="30">Items</th>
            <th class="text-center" rowspan="2" width="80">Billing No.</th>
            <th class="text-center" rowspan="2" width="70">Issuring Date</th>
            <th class="text-center" rowspan="2" width="80">Job No.</th>
            <th class="text-center" rowspan="2" width="70">Inspection</th>
            <th class="text-center" rowspan="2" width="100">Re-imbursement</th>
            <th class="text-center" colspan="2" width="60">Service Charges</th>
            <th class="text-center" rowspan="2" width="60">Vat</th>
            <th class="text-center" rowspan="2" width="60">Wht</th>
            <th class="text-center" rowspan="2" width="70">Net</th>
        </tr>
        <tr>            
            <th class="text-center" width="100">NON-VAT</th>
            <th class="text-center" width="100">VAT</th>
        </tr>
    <tbody id="tbDetail"></tbody>
    <tr>
            <td style="text-align:right" colspan="5">TOTAL</td>
	    <td style="text-align:right"><label id="lblAdv"></label></td>
            <td style="text-align:right"><label id="lblServNonVat"></label></td>
	    <td style="text-align:right"><label id="lblServVat"></label></td>
            <td style="text-align:right"><label id="lblVat"></label></td>
	    <td style="text-align:right"><label id="lblWht"></label></td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
    </tr>
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
</div>
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
	    let servvat = 0;
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
                html += '<td style="text-align:center">' + i + '</td>';
                html += '<td style="text-align:center">' + dr.InvNo + '</td>';
                html += '<td style="text-align:center">' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td style="text-align:center">' + dr.RefNo + '</td>';
                html += '<td style="text-align:center">' + ShowDate(CDateTH(dr.DutyDate)) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtChargeNonVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtChargeVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtTotal, 2) + '</td>';
                html += '</tr>';

                total += Number(dr.AmtTotal);
                serv += Number(dr.AmtChargeNonVAT);
                servvat += Number(dr.AmtChargeVAT);
                adv += Number(dr.AmtAdvance);
                vat += Number(dr.AmtVAT);
                wh1 += Number(dr.AmtWH1);
                wh3 += Number(dr.AmtWH3);
            }
            dv.html(html);
	    $('#lblAdv').text(ShowNumber(adv, 2));	
   	    $('#lblServNonVat').text(ShowNumber(serv , 2));	
            $('#lblServVat').text(ShowNumber(servvat, 2));	
            $('#lblVat').text(ShowNumber(vat, 2));	
   	    $('#lblWht').text(ShowNumber(wh1+wh3, 2));	
            $('#lblBillTotal').text(ShowNumber(total, 2));		
            $.get(path + 'acc/getinvoice?branch=' + branch + '&code=' + data.detail[0][0].InvNo, function (r) {
                $('#lblCustPo').text(r.invoice.job[0][0].CustRefNO);
            });
            //$('#lblBillTotalEng').text(CNumEng(total));
        }
    }
</script>