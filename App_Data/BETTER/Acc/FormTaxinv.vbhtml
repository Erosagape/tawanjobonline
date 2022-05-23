
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #summary td {
        width: 16%;
        border-color: #66FFCC;
        border: 1px solid #66FFCC;
    }

    .border {
        border: 1px solid #66FFCC;
    }

    .vborder {
        border-left: 1px solid #66FFCC;
        border-right: 1px solid #66FFCC;
    }

   td {
        padding: 5px;
        border-color:black;
         font-size: 12px;
    }

    table {
        margin-bottom: 10px
    }


</style>

<div style="text-align:center;width:100%">
    <h2><label id="lblDocType" style="font-size:18px;display:none">TAX-INVOICE</label></h2>
</div>
<table id="taxHeader" style="width: 100%; border: 1px solid #66FFCC;">
    <tbody>
        <tr >
            <td style="width:55%;font-weight:bold">RECEIVED FROM</td>
            <td style="border-left:1px solid #66FFCC;background-color: #FFFFCC;font-weight:bold">No.</td>
            <td style="background-color: #FFFFCC;font-weight: bold">:</td>
            <td style="background-color: #FFFFCC;font-weight: bold"><label id="lblReceiptNo"></label></td>
        </tr>
        <tr style="font-weight: bold">
            <td><label id="lblCustName"></label></td>
            <td style="border-left: 1px solid #66FFCC; border-bottom: 1px solid #66FFCC;background-color: #FFFFCC;font-weight:bold">DATE</td>
            <td style="border-bottom:1px solid #66FFCC;background-color: #FFFFCC;">:</td>
            <td style="border-bottom:1px solid #66FFCC;background-color: #FFFFCC;"><label id="lblReceiptDate"></label></td>
        </tr>
        <tr>
            <td><label id="lblCustAddr" rowspan="2"></label></td>
            <td style="border-left:1px solid #66FFCC" rowspan="3" colspan="3">
                <p  style="text-align:center;font-weight:bold;font-size:16px">ใบเสร็จรับเงิน/ใบกำกับภาษี</p>
                <p style="text-align: center; font-weight: bold; font-size: 18px">RECEIPT / TAX INVOICE</p>
            </td>
        </tr>
        <tr>
           
        </tr>
        <tr>
            <td>
                TAX-ID <label><lable id="lblCustTax"></label>
            </td>
        </tr>
    </tbody>
</table>
@*<div style="display:flex;">
        <div style="flex:3;border:1px solid black;border-radius:5px;margin-right:8px;padding:5px 5px 5px 5px;">
            NAME : <label id="lblCustName"></label><br />
            ADDRESS : <label id="lblCustAddr"></label><br />
            TEL : <label id="lblCustTel"></label><br />
            TAX-ID : <lable id="lblCustTax"></lable>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;">
            NO. : <label id="lblReceiptNo"></label><br />
            CUST INV : <label id="lblInvNo"></label><br />
        </div>
    </div>*@


<table style="width:100%" >
    <tbody id="summary">
        <tr style="text-align:center;" >
            <td rowspan="2">SUMMARY</td>
            <td style="background-color: #FFFFCC;">REIMBURSEMENT</td>
            <td style="background-color: #FFFFCC;">SERVICE</td>
            <td style="background-color: #FFFFCC;">VAT 7%</td>
            <td style="background-color: #FFFFCC;">TOTAL AMOUNT</td>
            <td style="background-color: #FFFFCC;">GRAND TOTAL</td>
        </tr>
    </tbody>
</table>
<table style="border-style:solid;width:100%;" class="text-center">
    <tr style="background-color: #FFFFCC;">
        <th class="border" height="40" width="40">NO.</th>
        <th class="border" height="40" width="80">INV.NO.</th>
        <th class="border" width="40">REF.NO</th>
        <th class="border" width="60">BFT NO</th>
        @*<th width="20">CUR</th>
            <th width="20">EXC</th>*@
        <th class="border" width="60">ADVANCE</th>
        <th class="border" width="60">SERVICE</th>
        <th class="border" width="30">VAT</th>
        <th class="border" width="30">WHT</th>
        <th class="border" width="60">TOTAL</th>
    </tr>
    <tbody id="tbDetail"></tbody>
    <tr style="text-align:right;background-color:#FFFFCC;font-weight: bold">
        <td class="border" colspan="4" style="text-align:center">TOTAL</td>
        <td class="border"><label id="lblTotalADV"></label></td>
        <td class="border"><label id="lblTotalBeforeVAT"></label></td>
        <td class="border"><label id="lblTotalVAT"></label></td>
        <td class="border"><label id="lblTotalWHT"></label></td>
        <td class="border"><label id="lblTotalNET" onclick="$(this).text(ShowNumber(Math.round($(this).text().replaceAll(',',''),2),2)); "></label></td>
    </tr>
    <tr class="border" style="font-weight: bold">
        <td colspan="2" style="text-align: left;">TOTAL RECEIPT : BAHT</td>
        <td style="text-align:center" colspan="8"><label id="lblTotalText"></label></td>
        @*<td colspan="1"><label id="lblTotalAfterVAT"></label></td>*@
    </tr>
</table>
@*<p>
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
    <br />*@
@*<div style="display:flex;">
        <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">

            ได้รับทราบ / ตรวจสอบรายการและราคาค่าบริการเรียบร้อยแล้ว
            <br /><br /><br />
            <p>_____________________</p>
            _____________________<br />
            ___/_______/___<br />
            ลูกค้า/ผู้ชำระเงิน
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

            ใบเสร็จรับเงินสมบูรณ์ต่อเมื่อมีลายเซ็นของเจ้าหน้าที่การเงิน
            <br /><br /><br />
            <p>_____________________</p>
            _____________________<br />
            ___/_______/___<br />
            ผู้รับชำระเงิน
        </div>
    </div>*@
<table style="width:70%";>
    <tbody>
        <tr>
            <td rowspan="2" style="width:10%;vertical-align: central; font-size: 16px; white-space: nowrap">PAY BY:</td>
            <td style="width: 10%; white-space: nowrap">TRANSFER</td>
            <td id="lblPayRef" contenteditable="true" style="border-bottom:1px #66FFCC solid;white-space:pre;"></td>
            <td style="width: 10%; white-space: nowrap">RV NO.</td>
            <td id="lblPRVoucher" contenteditable="true" style="border-bottom: 1px #66FFCC solid; white-space: pre;"></td>
        </tr>
        <tr>
            <td style="width: 10%; white-space: nowrap ">CHEQUE NO.</td>
            <td id="lblChequeNo" contenteditable="true" style="border-bottom: 1px #66FFCC solid; white-space: pre"></td>
            <td style="width: 10%; white-space: nowrap">DATE:.</td>
            <td id="lblVoucherDate" contenteditable="true" style="border-bottom: 1px #66FFCC solid; white-space: pre"></td>
        </tr>
    </tbody>
</table>
<div id="dvCopy" style="display:flex;width:100%">
    <div style="width:70%;"></div>
</div>
<div  style="display:flex;width:100%">
    <div style="width:70%;"></div>
    <div  style="width:30%;border-top:3px dotted #66FFCC;text-align:center;padding:10px;margin:30px 0px;">
        @viewbag.username
        <br />
        AUTHORIZED SIGNATURE
    </div>
</div>
<div style="text-align:center;color:#38cd9c">
    (โปรดตรวจสอบความถูกต้องของรายการในเอกสารฉบับนี้ภายใน 7 วัน มิฉะนั้นบริษัทฯ จะถือว่าเอกสารฉบับนี้ถูกต้องสมบูรณ์)
    <br />
    ใบเสร็จรับเงิน/ใบกากับภาษีนี้จะสมบูรณ์ก็ต่อเมื่อมีลายเซ็นต์ของผู้รับเงินและผู้ได้รับมอบอำนาจเท่านั้น
    <br />
    และต่อเมื่อบริษัทฯ ได้เรียกเก็บเงินตามเช็คและเงินเข้าบัญชีบริษัทครบถ้วนแล้ว
    <br />
    <label style="font-size:10px"> This Receipt/Tax invoice is not valid unless signed by our bill collector and authorized person and that the cheque has already been cleared by bank.</label>
   
</div>
<script type="text/javascript">
    $('#imgLogo').hide();
    $('#imgLogoAdd').show();

    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');
    let ans = confirm('OK to print Original or Cancel For Copy');
    let str = ans == true ? "ต้นฉบับ/ORIGINAL" : "สำเนา/COPY";

    $('#dvCopy').html($('#dvCopy').html() + '<div style="width:30%;margin: 1em 0em; padding: 1em; border: 1px black solid;font-size:18px;text-align:center;font-weight:bold">'+str+'</div>');
    
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
                $('#lblDocType').text('RECEIPT');
                serviceText = 'Transportation Charges';
                break;
        }
        //$('#lblCustCode').text(h.CustCode);
        let branchText = '';
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr').text(h.CustTAddr);
            if (Number(h.CustBranch) == 0) {
                branchText = ' สาขา: สำนักงานใหญ่';
            } else {
                branchText = ' สาขา 000'+CCode(Number(h.CustBranch));
            }
        } else {
            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr').text(h.CustEAddr);
            if (Number(h.CustBranch) == 0) {
                branchText = ' BRANCH: HEAD OFFICE';
            } else {
                branchText = ' BRANCH 000'+CCode(Number(h.CustBranch));
            }
        }
        $('#lblCustTel').text(h.CustPhone);
        $('#lblCustTax').text(h.CustTaxID + branchText);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiveDate)));
        $('#lblPRVoucher').text(h.PRVoucher);
        $('#lblPayRef').text(h.PayRef);
        
        $('#lblChequeNo').text(h.ChequeNo);
        $('#lblVoucherDate').text(h.ControlDate);
        console.log(h.ControlNo);
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let amt = 0;
        let total = 0;
        let adv = 0;
        let i = 1;
        for (let d of dt) {
            html = '<tr>';
            html += '<td class="vborder" style="text-align:center;">' + (i++) + '</td>';
            html += '<td class="vborder"  style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td  class="vborder" style="text-align:center">' + d.InvNo + '</td>';
            html += '<td  class="vborder" style="text-align:center">' + d.JobNo + '</td>';
            //html += '<td style="text-align:center">' + d.CurrencyCode + '</td>';
            //html += '<td style="text-align:center">' + d.ExchangeRate + '</td>';
            html += '<td  class="vborder" style="text-align:right">' + (d.AmtAdvance > 0 ? ShowNumber(d.AmtAdvance, 2) : '0.00') + '</td>';
            html += '<td  class="vborder" style="text-align:right">' + (d.AmtCharge > 0 ? ShowNumber(d.AmtCharge,2):'') + '</td>';
            html += '<td  class="vborder" style="text-align:right">' + (d.AmtCharge > 0 ? ShowNumber(d.AmtVAT * d.ExchangeRate,2):'') + '</td>';
            html += '<td  class="vborder" style="text-align:right">' + (d.AmtCharge > 0 ? ShowNumber(d.Amt50Tavi * d.ExchangeRate,2):'') + '</td>';
            //html += '<td  class="vborder" style="text-align:right">' + ShowNumber((d.Amt + d.AmtVAT - d.Amt50Tavi) * d.ExchangeRate.toFixed(4), 2) + '</td>';
            html += '<td  class="vborder" style="text-align:right">' + ShowNumber((d.AmtAdvance+d.AmtCharge+ d.AmtVAT - d.Amt50Tavi) * d.ExchangeRate.toFixed(4), 2) + '</td>';
            html += '</tr>';
            console.log(d.AmtCharge + d.AmtAdvance + d.InvVAT - d.Inv50Tavi);
            console.log(d.ExchangeRate);
            $('#tbDetail').append(html);
            //if (d.AmtCharge > 0) {
                service += (Number(d.AmtCharge)>0? Number(d.AmtCharge) :0);
                vat += (Number(d.AmtCharge)>0? Number(d.AmtVAT) :0);
                wht += (Number(d.AmtCharge)>0? Number(d.Amt50Tavi) :0);
                //amt += Number(d.InvAmt) + Number(d.InvVAT);
            amt += Number(d.Net)
            //} else {
                adv +=(Number(d.AmtAdvance)>0? Number(d.AmtAdvance) :0);
            //}
            total +=Number(d.InvTotal);
        }


        $('#summary').html($('#summary').html()+
         `<tr style="text-align:right">
            <td>${ShowNumber(adv, 2)}</td>
            <td>${ShowNumber(service, 2)}</td>
            <td>${ShowNumber(vat, 2)}</td>
            <td>${ShowNumber(service+vat, 2)}</td>
            <td onclick="$(this).text(ShowNumber(Math.round($(this).text().replaceAll(',',''),2),2));">${ShowNumber(amt, 2)}</td>
        </tr>`);
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalWHT').text(ShowNumber(wht, 2));
        $('#lblTotalADV').text(ShowNumber(adv, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(amt, 2));
        $('#lblTotalNET').text(ShowNumber(amt, 2));
        $('#lblTotalText').text(CNumThai(CDbl(amt, 2)));


        
    }
</script>