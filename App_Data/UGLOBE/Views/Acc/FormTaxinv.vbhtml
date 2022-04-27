
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    * {
        font-size: 13px;
    }

    #tbDetail td {
        font-size: 13px;
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
                <td width="60" id="lblHead">SERVICE</td>
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
            <label><input type="checkbox" id='cash' name="vehicle1" value=""> CASH</label>
            DATE<label id='cashDate' style='text-decoration: underline;'>____________</label>  AMOUNT <label id='cashAmount'>____________</label> BAHT
        </div>
        <div>
            <label><input type="checkbox" id='chq' name="vehicle2" value=""> CHEQUE</label>
            DATE<label id='chqDate' style='text-decoration: underline;'>____________</label> NO<label id='chqNo'  style='text-decoration: underline;'>____________</label> BANK<label id='chqBank'  style='text-decoration: underline;'>____________</label>  AMOUNT<label id='chqAmount' style='text-decoration: underline;'>____________</label>BAHT
        </div>
        <div>
            <label><input type="checkbox" id='transfer' name="vehicle3" value=""> TRANSFER</label>
            DATE<label id='transferDate' style='text-decoration: underline;'>____________</label> BANK<label id='transferBank'  style='text-decoration: underline;'>____________</label>  AMOUNT<label id='transferAmount' style='text-decoration: underline;'>____________</label>BAHT
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
    const dbID = '@ViewBag.Database';
    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');
    let ans = confirm('OK to print Original or Cancel For Copy');
    if (ans == true) {
        $('#dvCopy').html('<b>**ORIGINAL**</b>');
    } else {
        $('#dvCopy').html('<b>**COPY**</b>');
    }
    if (dbID == '1') {
        $('#lblHead').html('TRANSPORT');
    } else {
        $('#lblHead').html('SERVICE');
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
            $('#lblCustName').text(h.BillTName);
            $('#lblCustAddr').text(h.BillTAddr);
        } else {
            $('#lblCustName').text(h.BillEName);
            $('#lblCustAddr').text(h.BillEAddr);
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
	$('#lblReceiptDate').text();
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;
        let adv = 0;
        for (let d of dt) {
            html = '<tr style="font-size:13px">';
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