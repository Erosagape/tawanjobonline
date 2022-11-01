@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = "BILLING COVER SHEET"
End Code
<style>
    td {
        font-size: 11px;
    }
    #dvFooter {
	display:none;
    }		
    table {
        border-width: thin;
        border-collapse: collapse;
    }
</style>
      <div id="dvCopy" style="float:right"></div>
<br/><br/>
<div>
    <div style="float:left">
        <p>
            TAX-ID : <label id="lblTaxNumber"></label>
        </p>
    </div>
    <div style="float:right;">
          DOC NO : <label id="lblBillAcceptNo"></label>
        <br />DATE : <label id="lblBillDate"></label>
    </div>
</div>
<br/>
<div style="display:flex;">
    <div class="text-left">
        <p>
            NAME : <label id="lblCustName"></label>
        </p>
    </div>
</div>
<div style="display:flex;flex-direction:column">
    <div style="flex:1" class="text-left">
        <label id="lblCustAddress"></label>
    </div>
    <div style="flex:1" class="text-left">
        <br />
        PLEASE APPROVE BEFORE PAYMENT
    </div>
</div>
<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
    <thead>
        <tr>
            <th class="text-center" width="100">ITEMS</th>
            <th class="text-center" width="100">ISSUE DATE</th>
            <th class="text-center" width="130">INVOICE NO.</th>
            <th class="text-center">CONSIGNEE</th>
            <th class="text-center">DUE DATE</th>
            <th class="text-center" width="100">TOTAL</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tfoot>
        <tr>
            <td style="text-align:right" colspan="5">TOTAL</td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
        </tr>
        <tr style="background-color:lightblue">
            <th class="text-center" colspan="6"><label id="lblBillTotalEng"></label></th>
        </tr>
    </tfoot>
</table>

<div style="margin-top:60px">
	<p>Remark : <br>
		<label id='lblRemark'></label>
	</p>
    <p>PAYMENT DUE DATE : <label id="lblPaymentDueDate"></label></p>
    <p>PLEASE PAY CHEQUE IN NAME @ViewBag.PROFILE_COMPANY_NAME_EN</p>
    <p>PAYMENT SHOULD BE PAID BY CROSS CHEQUE IN FAVOR OF  @ViewBag.PROFILE_COMPANY_NAME_EN</p>
    <p>SIGN ON RECEIVER AND ASSIGNED PAYMENT DATE AND SEND THIS PAPER TO @ViewBag.PROFILE_COMPANY_NAME_EN FAX. @ViewBag.PROFILE_COMPANY_FAX</p>
</div>

<div style="display:flex">
    <div style="flex:1;border:1px solid black ;border-radius:5px;text-align:center">
        FOR THE CUSTOMER<br />
        <br /><br /><br /><br />
        __________________________________________<br />
        .........................................<br />
        _____/______/______
    </div>
    <div style="flex:1;border:1px solid black ;border-radius:5px;text-align:center">
        FOR @ViewBag.PROFILE_COMPANY_NAME_EN<br />
        <br /><br /><br /><br />
        __________________________________________<br />
        .........................................<br />
        _____/______/______
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let billno = getQueryString('code');
    let ans = confirm('OK to print Original or Cancel For Copy');
	let trans = "";
    if (ans == true) {
        $('#dvCopy').html('<b>**ORIGINAL**</b>');
    } else {
        $('#dvCopy').html('<b>**COPY**</b>');
    }
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
			$('#lblRemark').html(data.header[0][0].BillRemark.replaceAll("\n", "<br>"));
        }
        if (data.customer.length > 0) {
            if (data.customer[0][0].UsedLanguage == 'TH') {
		if(Number(data.customer[0][0].Branch)==0) {
	            $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' Branch : สำนักงานใหญ่');
		} else {
	            $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' Branch : '+ data.customer[0][0].Branch);
		}
                $('#lblCustName').text(data.customer[0][0].NameThai);
                $('#lblCustAddress').text(data.customer[0][0].TAddress1 + '\n' + data.customer[0][0].TAddress2);
            } else {
		if(Number(data.customer[0][0].Branch)==0) {
	            $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' Branch : HEAD OFFICE');
		} else {
	            $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' Branch : '+ data.customer[0][0].Branch);
		}
                $('#lblCustName').text(data.customer[0][0].NameEng);
                $('#lblCustAddress').text(data.customer[0][0].EAddress1 + '\n' + data.customer[0][0].EAddress2);
            }
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
            for (let dr of data.detail[0]) {
                html += '<tr>';
                html += '<td>' + dr.ItemNo + '</td>';
                html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td>' + dr.InvNo + '</td>';
                html += '<td style="text-align:left">' + dr.CustTName + '</td>';
                html += '<td style="text-align:right">' + ShowDate(CDateTH(dr.DueDate)) + '</td>';
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
            $('#lblBillTotalEng').text(CNumEng(ShowNumber(total,2)));
			
			trans = CNumThai(ShowNumber(total,2));
			document.getElementById("lblBillTotalEng").onclick = () =>{ 
				let tmp = $('#lblBillTotalEng').text();
				$('#lblBillTotalEng').text(trans);
				trans = tmp;
			};
		
        }
    }
</script>