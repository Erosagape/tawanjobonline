
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
border-bottom: 1px solid;
border-top: 1px solid;
border-right: 1px solid;
border-left: 1px solid;
}
</style>
<div id="dvheader"></div>
<table style="width:100%; margin-top:5px" class="text-center">
    <thead id="theader">
        <tr style="background-color:lightblue;"  class="border">
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
    <tr class="border">
        <td id="tremark"></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr class="border" style="background-color:lightblue;text-align:right;">
        <td style="text-align:center"><label id="lblTotalText"></label></td>
        <td>TOTAL AMOUNT</td>
        <td><label id="lblTotalBeforeNOVAT"></label></td>
        <td><label id="lblTotalBeforeVAT"></label></td>
        <td><label id="lblTotalVAT"></label></td>
        <td><label id="lblTotalWHT"></label></td>
        <td><label id="lblTotalADV"></label></td>
        <td><label id="lblTotalNET"></label></td>
    </tr>
    <tr class="border" style="background-color:lightblue;text-align:right;">
	<td colspan="3">TOTAL SERVICES</td>
	<td><label id="lblTotalCharge"></label></td>
        <td colspan="3">TOTAL RECEIPT</td>
        <td colspan="1"><label id="lblTotalAfterVAT"></label></td>
    </tr>
</table>
<p>
    PAY BY
</p>
<div style="display:flex;flex-direction:column">
    <div>
        <label><input type="checkbox" name="vehicle1" value=""> CASH</label>
        DATE__________________________ AMOUNT___________________________BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle2" value=""> CHEQUE</label>
        DATE__________________________  NO____________________________  BANK______________________________  AMOUNT___________________________BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle3" value=""> TRANSFER</label>
        DATE__________________________  BANK______________________________  AMOUNT___________________________BAHT
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
    let htmlheader = '<div style="text-align:center;width:100%">';
    htmlheader += '<h2><label style="font-size:18px;">{doctype}</label></h2>';
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
                htmlheader = htmlheader.replace('{doctype}', 'TAX-INVOICE / RECEIPT<br>ใบกำกับภาษี / ใบเสร็จรับเงิน');
                break;
            case 'SRV':
                //$('#lblDocType').text('TAX-INVOICE / ใบกำกับภาษี');
                htmlheader = htmlheader.replace('{doctype}', 'TAX-INVOICE / ใบกำกับภาษี');
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
                //$('#lblDocType').text('RECEIPT / ใบเสร็จรับเงิน');
                htmlheader = htmlheader.replace('{doctype}', 'RECEIPT / ใบเสร็จรับเงิน');
                break;
        }
        //$('#lblCustCode').text(h.BillToCustCode);
        let branchText = '';
        if (h.UsedLanguage == 'TH') {
            //$('#lblCustName').text(h.BillTName);
            //$('#lblCustAddr').text(h.BillTAddr);
            htmlheader = htmlheader.replace('{custname}', h.BillTName);
            htmlheader = htmlheader.replace('{custaddr}', h.BillTAddr);
            if (Number(h.BillToCustBranch) == 0) {
                branchText = ' สาขา: สำนักงานใหญ่';
            } else {
                branchText = ' BRANCH: 000'+CCode(Number(h.BillToCustBranch));
            }
        } else {
            //$('#lblCustName').text(h.BillEName);
            //$('#lblCustAddr').text(h.BillEAddr);
            htmlheader = htmlheader.replace('{custname}', h.BillEName);
            htmlheader = htmlheader.replace('{custaddr}', h.BillEAddr);
            if (Number(h.BillToCustBranch) == 0) {
                branchText = ' BRANCH: HEAD OFFICE';
            } else {
                branchText =  ' BRANCH: 000'+CCode(Number(h.BillToCustBranch));
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
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvVAT,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Inv50Tavi,2):'') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtAdvance>0? ShowNumber(d.AmtAdvance,2):'') + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.InvTotal,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            servat += Number(d.AmtCharge - d.AmtSrvNOVAT);
            sernovat += Number(d.AmtSrvNOVAT);
            if (d.AmtCharge > 0) {
                service += Number(d.AmtCharge);
                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
               
	     amt += Number(d.InvAmt) + Number(d.InvVAT);
            } else {

            }

            adv += Number(d.AmtAdvance);
            total +=Number(d.InvTotal);
		console.log(amt);
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(servat, 2));
        $('#lblTotalBeforeNOVAT').text(ShowNumber(sernovat, 2));
        $('#lblTotalCharge').text(ShowNumber(sernovat+servat, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(adv+servat+sernovat+vat, 2));
        $('#lblTotalNET').text(ShowNumber(servat+sernovat+vat+adv-wht, 2));
        $('#lblTotalText').text(CNumThai(CDbl(servat+sernovat+vat+adv-wht,2)));
    }
</script>