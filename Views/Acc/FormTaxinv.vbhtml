
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    td {
        font-size: 12px;
    }

table {
        border-collapse: collapse;
}
.noborder {
border-bottom: 0px solid #000000;
border-top: 0px solid #000000;
border-right: 0px solid #000000;
border-left: 0px solid #000000;
}
.border td,th {
border-bottom: 0.5px solid;
border-top: 0.5px solid;
border-right: 0.5px solid;
border-left: 0.5px solid;
}
</style>
<<<<<<< HEAD
<div id="dvheader"></div>
<table style="width:100%; margin-top:3px" class="text-center">
    <thead id="theader">
        <tr class="border">
            <th height="40" width="240">INV.NO.</th>
            <th width="70">JOB</th>
            <th width="60">NON VAT</th>
            <th width="60">SERVICE VAT</th>
            <th width="30">VAT</th>
            <th width="30">WHT</th>
            <th width="60">ADVANCE</th>
            <th width="60">TOTAL</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tr class="border" style="display:none">
        <td id="tremark"></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
	  <td></td>
        <td></td>
    </tr>
    <tr class="border" style="text-align:right;">
        <td style="text-align:center"><label id="lblTotalText"></label></td>
        <td>TOTAL AMOUNT</td>
        <td><label id="lblTotalBeforeNOVAT"></label></td>
        <td><label id="lblTotalBeforeVAT"></label></td>
        <td><label id="lblTotalVAT"></label></td>
        <td><label id="lblTotalWHT"></label></td>
        <td><label id="lblTotalADV"></label></td>
        <td><label id="lblTotalNET"></label></td>
    </tr>
    <tr class="border" style="text-align:right;">
	<td colspan="1">TOTAL SERVICES</td>
	<td colspan="1"><label id="lblTotalCharge"></label></td>
	<td colspan="2">TOTAL AMOUNT VAT</td>
	<td colspan="1"><label id="lblTotalAmtVat"></label></td>
        <td colspan="2">TOTAL RECEIPT</td>
        <td colspan="1"><label id="lblTotalAfterVAT"></label></td>
    </tr>
=======
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
>>>>>>> everbest
</table>
<p>
    PAY BY
</p>
<<<<<<< HEAD
 <div style="display:flex;flex-direction:column">
        <div>
            <label><input type="checkbox" id='cash' name="vehicle1" value=""> CASH</label>
            DATE &nbsp; <label id='cashDate' style='text-decoration: underline;'>____________</label>  AMOUNT &nbsp; <label id='cashAmount' style='text-decoration: underline;'>____________</label>  &nbsp;BAHT
        </div>
        <div>
            <label><input type="checkbox" id='chq' name="vehicle2" value=""> CHEQUE</label>
            DATE &nbsp;<label id='chqDate' style='text-decoration: underline;'>____________</label> NO &nbsp;<label id='chqNo'  style='text-decoration: underline;'>____________</label> BANK<label id='chqBank'  style='text-decoration: underline;'>____________</label>  AMOUNT<label id='chqAmount' style='text-decoration: underline;'>____________</label>BAHT
        </div>
        <div>
            <label><input type="checkbox" id='transfer' name="vehicle3" value=""> TRANSFER</label>
            DATE &nbsp;<label id='transferDate' style='text-decoration: underline;'>____________</label> &nbsp; BANK &nbsp;<label id='transferBank'  style='text-decoration: underline;'>____________</label>  &nbsp; AMOUNT &nbsp;<label id='transferAmount' style='text-decoration: underline;'>____________</label> &nbsp;BAHT
        </div>
    </div>
<div style="display:flex;padding:30px;gap:5px;">
    <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">
	<br />
        <br />
	<br />
	<br />
        <p>__________________________________________</p>
        @*_____________________<br />
        ___/_______/___<br />*@
	ผู้มีอำนาจลงนาม<br />
        AUTHORIZED SIGNATURE
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

	<br />
        <br />
        <br />
        <br />
        <p>__________________________________________</p>
        @*_____________________<br />
        ___/_______/___<br />*@
	ผู้รับเงิน<br />
        AUTHORIZED SIGNATURE
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

	<br />
        <br />
        <br />
        <br />
        <p>__________________________________________</p>
        @*_____________________<br />
        ___/_______/___<br />*@
	ผู้รับใบเสร็จรับเงิน/ใบกำกับภาษี<br />
        AUTHORIZED SIGNATURE
    </div>
</div>

<label>
	หมายเหตุ  :
	การชำระเงินด้วยเช็คจะสมบูรณ์ต่อเมื่อบริษัทได้รับเงินตามเช็คเรียบร้อยแล้ว
	กรณีแก้ไขเอกสารกรุณาแจ้งภายใน7วัน
	หากพ้นกำหนด บริษัทจะไม่รับผิดชอบใดๆทั้งสิ้น<br/>
</label>
=======
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
>>>>>>> everbest
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let htmlheader = '<div style="text-align:center;width:100%">';
    htmlheader += '<b><label style="font-size:16px;">{doctype}</label></b>';
    htmlheader += '</div>';
    htmlheader += '<div style="text-align:right;width:100%">{copy}</div>';
    htmlheader += '<div style="display:flex;">';
    htmlheader += '<div style="flex:3;border:1px solid black;border-radius:5px;margin-right:8px;padding:5px 5px 5px 5px;">';
    htmlheader += 'NAME : <label>{custname}</label><br />';
    htmlheader += 'ADDRESS : <label>{custaddr}</label><br />';
    htmlheader += 'TEL : <label>{custtel}</label><br />';
    htmlheader += 'TAX-ID : <label>{custtax}</label>';
    htmlheader += '</div>';
    htmlheader += '<div style="flex:1;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;">';
    htmlheader += 'NO. : <label>{docno}</label><br />';
    htmlheader += 'ISSUE DATE : <label>{docdate}</label><br />';
    htmlheader += '</div>';
    htmlheader += '</div>';

    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');
    let ans = confirm('OK to print Original or Cancel For Copy');
    if (ans == true) {
        //$('#dvCopy').html('<b>**ORIGINAL**</b>');
        htmlheader = htmlheader.replace('{copy}', '<b>**ORIGINAL**</b>');
    } else {
        //$('#dvCopy').html('<b>**COPY**</b>');
        htmlheader = htmlheader.replace('{copy}', '<b>**COPY**</b>');
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
                //$('#lblDocType').html('TAX-INVOICE / RECEIPT<br>ใบกำกับภาษี / ใบเสร็จรับเงิน');
                htmlheader = htmlheader.replace('{doctype}', 'RECEIPT / TAX-INVOICE<br>ใบเสร็จรับเงิน / ใบกำกับภาษี');
                break;
            case 'SRV':
                //$('#lblDocType').text('TAX-INVOICE / ใบกำกับภาษี');
                htmlheader = htmlheader.replace('{doctype}', 'RECEIPT / TAX-INVOICE<br>ใบเสร็จรับเงิน / ใบกำกับภาษี');
                break;
            case 'DNR':
                //$('#lblDocType').text('DEBIT NOTE RECEIPT / ใบเสร็จรับเงิน');
                htmlheader = htmlheader.replace('{doctype}', 'DEBIT NOTE RECEIPT / ใบเสร็จรับเงิน');
                break;
             case 'RCV':
                //$('#lblDocType').text('RECEIPT / ใบเสร็จรับเงิน');
                htmlheader = htmlheader.replace('{doctype}', 'RECEIPT / ใบเสร็จรับเงิน');
                break;
            case 'ADV':
                //$('#lblDocType').text('RECEIPT / ใบเสร็จรับเงินทดรองจ่าย');
                htmlheader = htmlheader.replace('{doctype}', 'RECEIPT / ใบเสร็จรับเงินทดรองจ่าย');
                break;
            default:
<<<<<<< HEAD
                //$('#lblDocType').text('RECEIPT / ใบเสร็จรับเงิน');
                htmlheader = htmlheader.replace('{doctype}', 'RECEIPT / ใบเสร็จรับเงิน');
=======
                $('#lblDocType').text('TAX-INVOICE/RECEIPT');
                serviceText = 'Service Charges';
>>>>>>> everbest
                break;
        }
        //$('#lblCustCode').text(h.BillToCustCode);
        let branchText = '';
        if (h.UsedLanguage == 'TH') {
<<<<<<< HEAD
            //$('#lblCustName').text(h.BillTName);
            //$('#lblCustAddr').text(h.BillTAddr);
            htmlheader = htmlheader.replace('{custname}', h.BillTName);
            htmlheader = htmlheader.replace('{custaddr}', h.BillTAddr);
=======
            $('#lblCustName').text(h.BillTName);
            $('#lblCustAddr').text(h.BillTAddr);
>>>>>>> everbest
            if (Number(h.BillToCustBranch) == 0) {
                branchText = ' สาขา: สำนักงานใหญ่';
            } else {
                branchText = ' BRANCH: 000'+CCode(Number(h.BillToCustBranch));
            }
        } else {
<<<<<<< HEAD
            //$('#lblCustName').text(h.BillEName);
            //$('#lblCustAddr').text(h.BillEAddr);
            htmlheader = htmlheader.replace('{custname}', h.BillEName);
            htmlheader = htmlheader.replace('{custaddr}', h.BillEAddr);
=======
            $('#lblCustName').text(h.BillEName);
            $('#lblCustAddr').text(h.BillEAddr);
>>>>>>> everbest
            if (Number(h.BillToCustBranch) == 0) {
                branchText = ' BRANCH: HEAD OFFICE';
            } else {
                branchText =  ' BRANCH: 000'+CCode(Number(h.BillToCustBranch));
            }
        }
<<<<<<< HEAD
	if(h.TRemark){
	   let payment =  h.TRemark.split(";");
           let ca = payment[0].split(":")[1];
	   let isTransfer = h.TRemark.toLowerCase().indexOf("transfer")>-1;
           let transfer =  isTransfer?payment[1].split(":")[1]:0;
	   let chq =  isTransfer?0:payment[1].split(":")[1];
           if( ca > 0){
		 $('#cashDate').text(payment[0].split(":")[3]?payment[0].split(":")[3]:"____________");
                 $('#cashAmount').text(ca?ca:"____________");
		 document.getElementById("cash").checked=true;
	   }
            if(transfer > 0){
		 $('#transferDate').text( payment[0].split(":")[3]?payment[0].split(":")[3]:"____________");
                 $('#transferAmount').text(transfer?transfer:"____________");
		 $('#transferBank').text(payment[1].split(":")[2]?payment[1].split(":")[2]:"____________");
	 	 document.getElementById("transfer").checked=true;
	    }
	    if(chq > 0){
		 $('#chqDate').text( payment[0].split(":")[3]?payment[0].split(":")[3]:"____________");
                 $('#chqAmount').text(chq);
		 $('#chqNo').text(payment[1].split(":")[3]?payment[1].split(":")[3]:"____________");
		 $('#chqBank').text(payment[1].split(":")[2]?payment[1].split(":")[2]:"____________");
	         document.getElementById("chq").checked=true;
	   }
	 
	}
        $('#tremark').text(h.TRemark);
        //$('#lblCustTel').text(h.BillPhone);
        //$('#lblCustTax').text(h.BillTaxID + branchText);
        //$('#lblReceiptNo').text(h.ReceiptNo);
        //$('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiveDate)));
        htmlheader = htmlheader.replace('{custtel}', h.BillPhone);
        htmlheader = htmlheader.replace('{custtax}', h.BillTaxID+ branchText);
        htmlheader = htmlheader.replace('{docno}', h.ReceiptNo);
        htmlheader = htmlheader.replace('{docdate}', ShowDate(CDateTH(h.ReceiveDate)));
        $('#dvheader').html(htmlheader);
=======
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
>>>>>>> everbest
        let html = '';
        let service = 0;
        let servat = 0;
        let sernovat = 0;
        let vat = 0;
        let wht = 0;
        let amt = 0;
        let total = 0;
        let adv = 0;
        let icount = 0;
        for (let d of dt) {
<<<<<<< HEAD
            icount++;
            if (icount == 40) {
                html = '<tr class="noborder">';
                html += '<td colspan="8">';
                html += htmlheader;
                html += '</td>';
                html += '</tr>';
                html += $('#theader').html();
	        html += '<tr class="border">';
            } else {
	        html = '<tr class="border">';
	    }

            html += '<td style="text-align:center">' + d.InvoiceNo + ' Date :' + ShowDate(d.InvoiceDate) +' '+ serviceText+ '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge > 0 ? ShowNumber(d.AmtSrvNOVAT, 2) : '') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.AmtCharge-d.AmtSrvNOVAT,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.AmtVAT,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Amt50Tavi,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtAdvance>0? ShowNumber(d.AmtAdvance,2):'') + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.Net,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            servat += Number(d.AmtCharge - d.AmtSrvNOVAT);
            sernovat += Number(d.AmtSrvNOVAT);
            if (d.AmtCharge > 0) {
                service += d.AmtCharge;
                vat += d.InvVAT;
                wht += d.Amt50Tavi;
               
	        amt += Number(d.Amt) + Number(d.AmtVAT);
            } else {

            }

            adv += Number(d.AmtAdvance);
            total +=Number(CDbl(d.Net,2));
	    //console.log(amt);
=======
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
>>>>>>> everbest
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(servat, 2));
        $('#lblTotalBeforeNOVAT').text(ShowNumber(sernovat, 2));
        $('#lblTotalCharge').text(ShowNumber(sernovat+servat, 2));
        $('#lblTotalAmtVat').text(ShowNumber(servat+vat, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        //$('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
<<<<<<< HEAD
        $('#lblTotalAfterVAT').text(ShowNumber(adv+servat+sernovat+vat, 2));
        $('#lblTotalNET').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(CDbl(total,2)));
	console.log('adv : ' + adv);
	console.log('servat : ' + servat);
	console.log('sernovat : ' + sernovat);
	console.log('vat : ' + vat);
	console.log('wht : ' + wht);
=======
        $('#lblTotal').text(ShowNumber(amt, 2));

        $('#lblTotalNET').text(ShowNumber(amt+adv , 2));
        $('#lblTotalText').text(CNumThai(CDbl(amt+adv,2)));
>>>>>>> everbest
    }
</script>