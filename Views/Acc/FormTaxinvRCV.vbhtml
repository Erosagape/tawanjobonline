@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    td {
        font-size: 12px;
    }

    #dvFooter {
        display: none;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
</style>
<div style="text-align:center;width:100%">
    <h2><label id="lblDocType">TAX-INVOICE</label></h2>
</div>
<!--
<div style="display:flex;">
    <div style="flex:3;">
        <label>CUSTOMER:</label>
        <br />
        <label id="lblCustCode"></label>
    </div>
    <div style="flex:1">
        BRANCH: <label id="lblBranchName">@ViewBag.PROFILE_DEFAULT_BRANCH_NAME</label>
        <br />
        TAX ID: <label id="lblTaxNumer">@ViewBag.PROFILE_TAXNUMBER</label>
    </div>
</div>
-->
<div id="dvCopy" style="text-align:right;width:100%">
</div>
<div style="display:flex;padding:5px">
    <div style="flex:3;border:1px solid black;border-radius:5px;">
        NAME : <label id="lblCustName"></label><br />
        ADDRESS : <label id="lblCustAddr"></label><br />
        TAX-ID : <lable id="lblCustTax"></lable>
    </div>
    <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px">
        NO. : <label id="lblReceiptNo"></label><br />
        ISSUE DATE : <label id="lblReceiptDate"></label><br />
    </div>
</div>

<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <thead>
        <tr style="background-color:lightblue;">
            @*<th height="40" width="60">INV.NO.</th>*@
            <th width="150">DESCRIPTION</th>
            @*<th width="60">JOB</th>*@
            <th width="20">QTY</th>
            <th width="20">CURR</th>
            <th width="20">EXC</th>
            <th width="50">TOTAL</th>
            @*<th width="60">SERVICE</th>
            <th width="30">VAT</th>
            <th width="30">WHT</th>*@
            <th width="50">ADVANCE</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    @*<tr>
        <td rowspan="4" colspan="5">
            TOTAL PAYMENT (1 <label id="lblCurrencyCode"></label> = <label id="lblExchangeRate"></label> THB)
            <br />
            <label id="lblFTotalNet"></label>
        </td>
        <td colspan="3" style="text-align:right;">TOTAL ADVANCE (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalAdv"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align:right;">TOTAL AMOUNT (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalBeforeVAT"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align:right;">TOTAL VAT (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalVAT"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align:right;">TOTAL RECEIPT (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalAfterVAT"></label>
        </td>
    </tr>*@
    <tr>
        <td colspan="3" > <div style="display:flex;"><div style="width: 30%">Total amount in words </div><div id="lblTotalText" style="text-align:center"></div></div></td>
        <td colspan="2" style="text-align:right;">TOTAL NET (THB)</td>
        <td style="background-color:lightblue;text-align:right;">     
            <label id="lblTotalNet"></label>
        </td>
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
<br />
<br />
<p style="width:100%;text-align:center">
    ใบเสร็จ/ใบกำกับภาษีนี้จะสมบูรณ์ต่อเมื่อมีลายเซ็นของพนักงานรักษาเงินเท่านั้น และต่อเมื่อบริษัทฯ ไปเรียกเก็บเงินจากเช็คครบถ้วนแล้ว<br />
    This Receipt/Tax invoice is not valid unless signed by out bill collector and cashier and the cheque has already been cleared by bank<br /><br />
    บริษัทจะกำหนดเวลาในการแก้ไขใบเสร็จรับเงิน/ใบกำกับภาษี ภายใน 10 วันนับจากวันที่ออกเอกสาร หากพ้นกำหนดทางบริษัทฯ จะถือว่าถูกต้องแล้ว
</p>
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
    $.get(path + 'acc/getreceivereport?branch=' + branch + '&code=' + receiptno, function (r) {
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
                $('#lblDocType').text('RECEIPT ADVANCE');
                break;
        }
        //$('#lblCustCode').text(h.CustCode);
        if (h.UsedLanguage == 'TH') {
	        if(Number(h.BillToCustBranch)==0) {
	        $('#lblCustTax').text(h.BillTaxID + ' BRANCH : สำนักงานใหญ่');
	        } else {
	        $('#lblCustTax').text(h.BillTaxID + ' BRANCH : '+ h.BillToCustBranch);
	        }
            $('#lblCustName').text(h.BillTName);
            $('#lblCustAddr').text(h.BillTAddr);
        } else {
	        if(Number(h.BillToCustBranch)==0) {
	        $('#lblCustTax').text(h.BillTaxID + ' BRANCH : HEAD OFFICE');
	        } else {
	        $('#lblCustTax').text(h.BillTaxID + ' BRANCH : '+ h.BillToCustBranch);
	        }
            $('#lblCustName').text(h.BillEName);
            $('#lblCustAddr').text(h.BillEAddr);
        }
        //$('#lblCustTel').text(h.CustPhone);

        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        let html = '';
        let adv = 0;
        let service = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;
        let totalf = 0;
        for (let d of dt) {
            let fnet = (Number(d.InvTotal) + Number(d.Inv50Tavi)) / Number(d.ExchangeRate);
            html = '<tr>';
            //html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td>' + d.SDescription + '</td>';
            //html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:center">' + h.Qty + '</td>';
            html += '<td style="text-align:center">' + h.CurrencyCode + '</td>';
            html += '<td style="text-align:center">' + h.DExchangeRate + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(fnet,2) +'</td>';
            //html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            //html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvVAT,2):'0.00') + '</td>';
            //html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Inv50Tavi,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtAdvance > 0 ?  ShowNumber(d.AmtAdvance, 2):'') + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            if (d.AmtCharge > 0) {
                service += Number(d.InvAmt);

                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
            }
            if (d.AmtAdvance > 0)  {
                adv += Number(d.InvTotal);
            }
            total += Number(d.InvAmt) + Number(d.InvVAT);
            totalf += fnet;
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(service+vat, 2));
        $('#lblTotalAdv').text(ShowNumber(adv, 2));
        $('#lblTotalNet').text(ShowNumber(service +adv+ vat - wht, 2));
        $('#lblCurrencyCode').text(h.CurrencyCode);
        $('#lblExchangeRate').text(h.ExchangeRate);
        $('#lblFTotalNet').text(ShowNumber(totalf, 2) + ' ' + h.CurrencyCode);

        if (h.UsedLanguage == 'TH') {
            $('#lblTotalText').text(CNumThai(CDbl((service + adv + vat - wht),2)));
        } else {
            $('#lblTotalText').text(CNumEng(CDbl((totalf),2)));
        }
    }
    </script>
