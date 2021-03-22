
@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    * {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
    #pFooter,#dvFooter {
        display:none;
    }
</style>
<div style="display:flex;flex-direction:column">
    <div style="display:flex;width:100%">
        <div id="dvHeadF" style="float:left;flex:55%;">
            <b>ROTJANIN CHANASINPHAWATKUN (DAN PHAK KAD)</b><br />
            9/10 T.Thachang,A.Mueng <br />
            Chanthaburi,THAILAND 22000<br />
            Tel: 084-5399663
        </div>
        <div id="dvHeadS" style="float:left;flex:55%;">
            <div style="display:flex">
                <div style="flex:1;margin:5px 5px 5px 5px;">
                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:90px" />
                </div>
                <div style="flex:4;">
                    <b>ห้างหุ้นสวนจํากัด แดน ผักกาด (สำนักงานใหญ่)</b><br />
                    9/10 หมู่ที 10 ตําบลท่าช้าง<br />
                    อําเภอเมืองจันทบุรี จังหวัดจันทบุรี<br />
                    โทร.039-460383,084-5399663<br />
                    เลขประจำตัวผู้เสียภาษี 0223552000575
                </div>
            </div>
        </div>
        <div style="float:right;text-align:right;flex:45%;">
            <b><label id="lblDocType">TAX-INVOICE</label></b>
            <div id="dvCopy">
            </div>
        </div>
    </div>
    <br/>
    <div style="display:flex;">
        <div style="flex:3;border:1px solid black;border-radius:5px;">
            NAME : <label id="lblCustName"></label><br />
            ADDRESS : <label id="lblCustAddr"></label><br />
            TEL : <label id="lblCustTel"></label><br />
            TAX-ID : <lable id="lblCustTax"></lable>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;">
            NO. : <label id="lblReceiptNo"></label><br />
            ISSUE DATE : <label id="lblReceiptDate"></label><br />
        </div>
    </div>

    <table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
        <tr style="background-color:lightblue;text-align:center">
            <td height="40" width="60">INV.NO.</td>
            <td width="210">DESCRIPTION</td>
            <td width="60">JOB</td>
            <td width="60">SERVICE</td>
            <td width="30">VAT</td>
            <td width="30">WHT</td>
            <td width="60">ADVANCE</td>
        </tr>
        <tbody id="tbDetail"></tbody>
        <tr style="background-color:lightblue;text-align:right;">
            <td colspan="4" style="text-align:center"><label id="lblTotalText"></label></td>
            <td colspan="2">TOTAL AMOUNT</td>
            <td colspan="1"><label id="lblTotalBeforeVAT"></label></td>
        </tr>
        <tr style="background-color:lightblue;text-align:right;">
            <td colspan="6">TOTAL VAT</td>
            <td colspan="1"><label id="lblTotalVAT"></label></td>
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
</div>

<br />
<div style="display:flex;">
    <!--
    <div class="text-left" style="border:1px solid black;flex:2">
        PLEASE REMIT TO ACCOUNT NO: 528-2-38819-9<br />
        "DAN PHAK KAD LIMITED PARTNERSHIP"<br />
        KASIKORNTHAI BANK<br />
        ROBINSON CHANTANABURI BRANCH
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
                $('#dvHeadF').hide();
                $('#lblDocType').text('TAX-INVOICE/RECEIPT - ใบกำกับภาษี/ใบเสร็จรับเงิน');
                break;
            case 'SRV':
                $('#dvHeadF').hide();
                $('#lblDocType').text('TAX-INVOICE / ใบกำกับภาษี');
                break;
            case 'REC':
                $('#dvHeadS').hide();
                $('#lblDocType').text('RECEIPT / ใบเสร็จรับเงิน');
                break;
            default:
                $('#dvHeadF').hide();
                $('#lblDocType').text('RECEIPT / ใบเสร็จรับเงิน');
                break;
        }
        //$('#lblCustCode').text(h.CustCode);
        let tax = h.CustTaxID;
        if (h.UsedLanguage == 'TH') {
            if (Number(h.CustBranch) == 0) {
                tax += ' BRANCH : สำนักงานใหญ่';
            } else {
                tax += ' BRANCH : '+ h.CustBranch;
            }

            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr').text(h.CustTAddr);
        } else {
            if (Number(h.CustBranch) == 0) {
                tax += ' BRANCH : HEAD OFFICE';
            } else {
                tax += ' BRANCH : '+ h.CustBranch;
            }

            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr').text(h.CustEAddr);
        }
        $('#lblCustTel').text(h.CustPhone);

        $('#lblCustTax').text(tax);
        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        let html = '';
        let service = 0;
        let vat = 0;
        let wht = 0;
        let total = 0;

        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td>'+d.SDescription + '</td>';
            html += '<td style="text-align:center">' + d.JobNo + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.InvVAT,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? ShowNumber(d.Inv50Tavi,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0? '0.00':ShowNumber(d.InvTotal,2)) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);
            if (d.AmtCharge > 0) {
                service += Number(d.InvAmt);
                vat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
                total += Number(d.InvAmt) + Number(d.InvVAT);
            }
        }
        $('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(vat, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(total));
    }
</script>
