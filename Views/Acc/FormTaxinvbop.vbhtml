
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
        <th height="40" width="240">INV.NO.</th>
        <th width="70">JOB</th>
        <th width="60">ADVANCE</th>
        <th width="60">SERVICE</th>
        <th width="30">VAT</th>
        <th width="60">TOTAL VAT</th>
        @*<th width="30">WHT</th>*@


    </tr>
    <tbody id="tbDetail"></tbody>
        <tr>
	<td></td>
	<td></td>
	<td></td>
	<td></td>
	<td></td>
	<td></td>
        </tr>
        <tr style="background-color:lightblue;text-align:right;">
            <td style="text-align:center"><label id="lblTotalText"></label></td>
            <td>TOTAL AMOUNT</td>
            <td><label id="lblTotalADV"></label></td>
            <td><label id="lblTotalBeforeVAT"></label></td>

            <td><label id="lblTotalVAT"></label></td>
            @*<td><label id="lblTotalWHT"></label></td>*@
            <td><label id="lblTotal"></label></td>
            @*<td><label id="lblTotalNET"></label></td>*@
        </tr>
        <tr style="background-color:lightblue;text-align:right;">
            @*<td colspan="2">TOTAL VAT</td>
        <td colspan="2"><label id="lblTotalAfterVAT"></label></td>*@
            <td colspan="1"></td>
            <td colspan="1">GRAND TOTAL</td>
            <td colspan="4"><label id="lblTotalNET"></label></td>
        </tr>
</table>
<p>
    PAY BY
</p>
<div style="display:flex;flex-direction:column">
    <div>
        <label><input type="checkbox" name="vehicle1" id="chkCash" value=""> CASH</label> : 
        AMOUNT <label id="lblCashAmount">______________</label> BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle2" id="chkCheque" value=""> CHEQUE</label> &nbsp;:&nbsp;
        NO &nbsp;<label id="lblChqNo">_______________</label> &nbsp;&nbsp;BANK &nbsp;<label id="lblChqBank">_________________</label> &nbsp;&nbsp; AMOUNT <label id="lblChqAmount">______________</label>&nbsp;BAHT&nbsp;&nbsp; DATE <label id="lblChqDate">______________</label><br/>
        <label><input type="checkbox" name="vehicle3" id="chkTransfer" value=""> TRANSFER</label> &nbsp;:&nbsp;
        NO &nbsp;<label id="lblTransNo">_______________</label> &nbsp;&nbsp;BANK &nbsp;<label id="lblTransBank">_________________</label> &nbsp;&nbsp; AMOUNT <label id="lblTransAmount">______________</label>&nbsp;BAHT&nbsp;&nbsp; DATE <label id="lblTransDate">______________</label>
    </div>
</div>
<br />
<div style="display:flex;">
    <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
        ผู้รับเงิน / Bill collector
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
	    ผู้จัดการ / Manager 
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
                $('#lblDocType').text('TAX-INVOICE/RECEIPT');
                serviceText = 'Service Charges';
                break;
        }
        //$('#lblCustCode').text(h.BillToCustCode);
        let branchText = '';
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.BillTName);
            $('#lblCustAddr').text(h.BillTAddr);
            if (Number(h.BillToCustBranch) == 0) {
                branchText = ' สาขา: สำนักงานใหญ่';
            } else {
                branchText = ' BRANCH: 000'+CCode(Number(h.BillToCustBranch));
            }
        } else {
            $('#lblCustName').text(h.BillEName);
            $('#lblCustAddr').text(h.BillEAddr);
            if (Number(h.BillToCustBranch) == 0) {
                branchText = ' BRANCH: HEAD OFFICE';
            } else {
                branchText =  ' BRANCH: 000'+CCode(Number(h.BillToCustBranch));
            }
        }
        $('#tremark').text(h.TRemark);
	let vRemark = h.TRemark.split(';');
        for (let t of vRemark) {
            if (t.indexOf(':') > 0) {
                let vData = t.split(':');
		console.log(vData);
                if (Number(vData[1]) > 0) {
                    switch (vData[0]) {
                        case 'CHQ':
                            $('#chkCheque').prop('checked', true)
				if (vData[5] == 'TRANSFER') {
					$('#lblTransAmount').text(ShowNumber(vData[1], 2));
                            		$('#lblTransAmount').css('text-decoration', 'underline');
					$('#chkCheque').prop('checked', false);
                                    	$('#chkTransfer').prop('checked', true);
 				    	$('#lblTransNo').text(vData[3]);
                                    	$('#lblTransNo').css('text-decoration', 'underline');
				    	$('#lblTransBank').text(vData[2]);
                                    	$('#lblTransBank').css('text-decoration', 'underline');
				    	$('#lblTransDate').text(vData[4]);
				    	$('#lblTransDate').css('text-decoration', 'underline');	
				}else{
					$('#lblChqAmount').text(ShowNumber(vData[1], 2));
                            		$('#lblChqAmount').css('text-decoration', 'underline');
					 $('#chkCheque').prop('checked', true);
                                    	$('#chkTransfer').prop('checked', false);
                                    	$('#lblChqNo').text(vData[3]);
                                    	$('#lblChqNo').css('text-decoration', 'underline');
				    	$('#lblChqBank').text(vData[2]);
                                    	$('#lblChqBank').css('text-decoration', 'underline');
				    	$('#lblChqDate').text(vData[4]);
				    	$('#lblChqDate').css('text-decoration', 'underline');
				}
                            break;
                        case 'CASH':
                            $('#chkCash').prop('checked', true);
                            $('#lblCashAmount').text(ShowNumber(vData[1], 2));
                            $('#lblCashAmount').css('text-decoration', 'underline');
                            break;
                        case 'CHG':
                            $('#lblBankChg').text(ShowNumber(vData[1], 2));
                            $('#lblBankChg').css('text-decoration', 'underline');
                            break;
                        default:
                            break;
                    }
                   }
            }
        }
        $('#lblCustTel').text(h.BillPhone);
        $('#lblCustTax').text(h.BillTaxID + branchText);
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
            html += '<td style="text-align:center">' + d.InvoiceNo + ' Date :' + ShowDate(d.InvoiceDate) +' '+ serviceText+ '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:right">' + (d.AmtAdvance > 0 ? ShowNumber(d.AmtAdvance, 2) : '') + '</td>';

            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.AmtCharge,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvVAT,2):'') + '</td>';
           // html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Inv50Tavi,2):'') + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.AmtCharge + d.InvVAT, 2) + '</td>';
            //html += '<td style="text-align:right">' + ShowNumber(d.AmtCharge+d.AmtAdvance+d.InvVAT-d.Inv50Tavi,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            if (d.AmtCharge > 0) {
                service += Number(CDbl(d.AmtCharge,2));
                vat += Number(CDbl(d.InvVAT,2));
                wht += Number(CDbl(d.Inv50Tavi,2));
                amt += Number(CDbl(d.AmtCharge,2)) + Number(CDbl(d.InvVAT,2));
            } 

	    if(d.AmtAdvance > 0) {
                adv +=Number(CDbl(d.AmtAdvance,2));
            }
            total +=Number(CDbl(d.InvTotal,2));
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        //$('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
        $('#lblTotal').text(ShowNumber(amt, 2));

        $('#lblTotalNET').text(ShowNumber(amt+adv , 2));
        $('#lblTotalText').text(CNumThai(CDbl(amt+adv,2)));
    }
</script>