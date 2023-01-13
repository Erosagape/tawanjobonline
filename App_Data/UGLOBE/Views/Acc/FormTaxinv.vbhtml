@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
   *{
        font-size: 13px;
    }

    #dvFooter {
        display: none;
    }

    #taxtable {
        border-width: thin;
        border-collapse: collapse;
        border: 1px black solid;
    }

    tr td{
        padding:3px;
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
<div style="display:flex;">
    <div style="flex:3;border:1px solid black;border-radius:5px;padding:5px">
        NAME : <label id="lblCustName"></label><br />
        ADDRESS : <label id="lblCustAddr"></label><br />
        TAX-ID : <lable id="lblCustTax"></lable>
    </div>
    <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px">
        NO. : <label id="lblReceiptNo"></label><br />
        ISSUE DATE : <label id="lblReceiptDate"></label><br />
    </div>
</div>

<table id="taxtable" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <thead>
        <tr style="background-color:lightblue;">
            @*<th height="40" width="100">INV.NO.</th>*@
            @*<th width="50">INV NO</th>*@
            <th width="150">DESCRIPTION</th>
            @*<th width="60">JOB</th>*@
            <th width="20">QTY</th>
            <th width="20">CURR</th>
            <th width="20">EXC</th>
            <th width="50">TOTAL</th>
            <th width="60">SERVICE</th>
            <th width="30">VAT</th>
            <th width="30">WHT</th>
            <th width="50">ADVANCE</th>
        </tr>
    </thead>
    <tbody id="tbDetail" style="border-bottom:1px black solid"></tbody>
    <tr>
        <td rowspan="4" colspan="5" style="border-right:1px black solid">
            @*TOTAL PAYMENT (1 <label id="lblCurrencyCode"></label> = <label id="lblExchangeRate"></label> THB)
        <br />
        <label id="lblFTotalNet"></label>*@

            JOB NO : <label id="lblRefJob"></label><br />
            INV NO : <label id="lblRefInv"></label>
        </td>
        <td colspan="3" style="text-align:right;">TOTAL ADVANCE (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalAdv"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align:right">TOTAL AMOUNT (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalBeforeVAT"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align:right">TOTAL VAT (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalVAT"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align:right">TOTAL RECEIPT (THB)</td>
        <td style="background-color:lightblue;text-align:right;">
            <label id="lblTotalAfterVAT"></label>
        </td>
    </tr>
    <tr style="border-top:1px black solid">
        <td colspan="9" > <div style="display:flex;"><div style="width: 30%">TOTAL AMOUNT IN WORDS </div><div id="lblTotalText" style="text-align:center"></div></div></td>
        @*<td colspan="3" style="text-align:right;">TOTAL NET (THB)</td>*@
        @*<td style="background-color:lightblue;text-align:right;">     
            <label id="lblTotalNet"></label>
        </td>*@
    </tr>
</table>
<p>
    PAY BY
</p>
<table style="width:100%">
 	<tr>
            <td colspan="3">
                <div>
                    PAYMENT DETAIL:
                </div>
                <div>
                    <label><input type="checkbox" name="vehicle1" id="chkCash" value=""> CASH</label>&ensp;
                    AMOUNT <label id="lblCashAmount">________________</label> BAHT&ensp;
                    BANK CHARGES  <label id="lblBankChg">________________</label>&ensp;
                </div>
                <div>
                    <label><input type="checkbox" name="vehicle3" id="chkTransfer" value=""> TRANSFER</label> &nbsp;
                    <label><input type="checkbox" name="vehicle2" id="chkCheque" value=""> CHEQUE</label>&ensp;
                    NO <label id="lblChqNo">________________</label>&ensp;
                    BANK/BRANCH <label id="lblChqBank">________________</label>&ensp;
                    AMOUNT <label id="lblChqAmount">________________</label> BAHT
                </div>
            </td>
        </tr>
</table>

<br />
<div style="display:flex;">
    <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">

        FOR THE CUSTOMER
        <br /><br /><br />
        <p>_____________________</p>

        <label id="lblCMPAcceptdate"></label><br />
        COLLECTOR
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

        FOR THE COMPANY
        <br /><br /><br />
        <p>_____________________</p>
        <label id="lblCSTAcceptdate"></label><br />
        AUTHORIZED SIGNATURE

    </div>
</div>
<br />
<br />
<p style="width:100%;text-align:center;font-size:12px">
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
                $('#lblDocType').text('RECEIPT');
                break;
        }
        //$('#lblCustCode').text(h.CustCode);
        //if (h.UsedLanguage == 'TH') {
	       // if(Number(h.BillToCustBranch)==0) {
	       // $('#lblCustTax').text(h.BillTaxID + ' BRANCH : สำนักงานใหญ่');
	       // } else {
	       // $('#lblCustTax').text(h.BillTaxID + ' BRANCH : '+ h.BillToCustBranch);
	       // }
        //    $('#lblCustName').text(h.BillTName);
        //    $('#lblCustAddr').text(h.BillTAddr);
        //} else {
	        if(Number(h.BillToCustBranch)==0) {
	        $('#lblCustTax').text(h.BillTaxID + ' BRANCH : HEAD OFFICE');
	        } else {
	        $('#lblCustTax').text(h.BillTaxID + ' BRANCH : '+ h.BillToCustBranch);
	        }
            $('#lblCustName').text(h.BillEName);
        $('#lblCustAddr').text(h.BillEAddr);

        //}
        //$('#lblCustTel').text(h.CustPhone);

        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        $('#lblCSTAcceptdate').text(ShowDate(CDateTH(h.ReceiptDate)));
        $('#lblCMPAcceptdate').text(ShowDate(CDateTH(h.ReceiptDate)));

        let jobSet = new Set();
        let invSet = new Set();
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
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvVAT,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Inv50Tavi,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge > 0 ? '0.00' : ShowNumber(d.InvTotal, 2)) + '</td>';
            html += '</tr>';
            jobSet.add(d.JobNo);
            invSet.add(d.InvoiceNo);
            $('#tbDetail').append(html);

          
            if (d.AmtCharge > 0) {
                service += Number(d.InvAmt);

                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
            } else {
                adv += Number(d.InvTotal);
            }
            total += Number(d.InvAmt) + Number(d.InvVAT);
            totalf += fnet;
        }
     
        let invList = Array.from(invSet);
        let jobList = Array.from(jobSet);
        $('#lblRefInv').text(invList.map(i => i));
        $('#lblRefJob').text(jobList.map(i => i));
        let rowCount = $('#tbDetail >tr').length;
        let blankRow = '<tr><td><br></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>'
        let blankRows = "";
        for (let i = 0; i < 12 - rowCount; i++) {
            blankRows += blankRow;
        }
        $('#tbDetail').append(blankRows);
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
	 $('#chkCash').prop('checked', false);
        $('#chkCheque').prop('checked', false);
        $('#chkTransfer').prop('checked', false);
        let vRemark = h.TRemark.split(';');
        for (let t of vRemark) {
            if (t.indexOf(':') > 0) {
                let vData = t.split(':');
                if (Number(vData[1]) > 0) {
                    switch (vData[0]) {
                        case 'CHQ':
                            $('#chkCheque').prop('checked', true);
                            $('#lblChqAmount').text(ShowNumber(vData[1], 2));
                            $('#lblChqAmount').css('text-decoration', 'underline');
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
                    switch (vData.length) {
                        case 3:
                            if (vData[0] == 'CHQ') {
                                $('#lblChqBank').text(vData[2]);
                                $('#lblChqBank').css('text-decoration', 'underline');
                            }
                            break;
                        case 4:
                            if (vData[0] == 'CHQ') {
                                if (vData[3] == 'TRANSFER') {
                                    $('#chkCheque').prop('checked', false);
                                    $('#chkTransfer').prop('checked', true);
                                } else {
                                    $('#chkCheque').prop('checked', true);
                                    $('#chkTransfer').prop('checked', false);
                                    $('#lblChqNo').text(vData[3]);
                                    $('#lblChqNo').css('text-decoration', 'underline');
                                }
                                $('#lblChqBank').text(vData[2]);
                                $('#lblChqBank').css('text-decoration', 'underline');
                            }
                            break;
                    }
                }
            }
        }
    }
    </script>
