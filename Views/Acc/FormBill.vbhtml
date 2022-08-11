
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = "ใบวางบิล (BILLING COVER SHEET)"
End Code
<style>
    * {
        font-size: 12px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter {
        display: none;
    }
</style>
<div id="dvCopy"></div>
<div style="display:flex;">
    <div style="flex:1;" class="text-left">
        <p>
            TAX-ID : <label id="lblTaxNumber"></label>
        </p>
    </div>
    <div style="flex:1;text-align:right">
        DOC NO : <label id="lblBillAcceptNo"></label>
        <br />DATE : <label id="lblBillDate"></label>
    </div>
</div>
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
            <th class="text-center" width="50" rowspan="2">NO</th>
            <th class="text-center" width="100" rowspan="2">ISSUE DATE</th>
            <th class="text-center" width="130" rowspan="2">INVOICE NO.</th>
            <th class="text-center" width="130" rowspan="2">COMM.INV</th>
            <th class="text-center" width="130" rowspan="2">CTN_NO</th>
            @*<th class="text-center" width="130" rowspan="2">JOB NO.</th>*@
            <th class="text-center" colspan="2">AMOUNT</th>
            <th class="text-center" width="60" rowspan="2">VAT</th>
            <th class="text-center">W/H</th>
            @*<th class="text-center" width="80" rowspan="2">PREPAID</th>*@
            <th class="text-center" width="100" rowspan="2">NET</th>
        </tr>
        <tr>
            <th class="text-center" width="100">ADVANCE</th>
            <th class="text-center" width="90">SERVICE</th>
            @*<th class="text-center" width="50">1%</th>*@
            <th class="text-center" width="50">3%</th>
        </tr>
    </thead>
    <tbody id="tbDetail">
    </tbody>
    <tfoot>
        <tr>
            <td style="text-align:right" colspan="5">TOTAL</td>
            <td style="text-align:right"><label id="lblSumAdv"></label></td>
            <td style="text-align:right"><label id="lblSumService"></label></td>
            <td style="text-align:right"><label id="lblSumVat"></label></td>
            @*<td style="text-align:right"><label id="lblSumWh1"></label></td>*@
            <td style="text-align:right"><label id="lblSumWh3"></label></td>
            @*<td style="text-align:right"><label id="lblSumPrepaid"></label></td>*@
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
        </tr>
        <tr style="background-color:lightblue">
            <th class="text-center" colspan="12"><label id="lblBillTotalEng"></label></th>
        </tr>
    </tfoot>
</table>

<div>
    <p>PAYMENT DUE DATE : <label id="lblPaymentDueDate"></label></p>
    @*
    <p>PLEASE PAY CHEQUE IN NAME @ViewBag.PROFILE_COMPANY_NAME_EN</p>
    <p>PAYMENT SHOULD BE PAID BY CROSS CHEQUE IN FAVOR OF  @ViewBag.PROFILE_COMPANY_NAME</p>
    <p>SIGN ON RECEIVER AND ASSIGNED PAYMENT DATE AND SEND THIS PAPER TO @ViewBag.PROFILE_COMPANY_NAME FAX. @ViewBag.PROFILE_COMPANY_FAX</p>
    *@
</div>
<table>
    <tbody>
        <tr>
            <td>BANK</td>
            <td>KASIKORN BANK</td>
        </tr>

        <tr>
            <td>ACCOUNT NAME</td>
            <td>SINCERELY SERVICE CO.,LTD</td>
        </tr>

        <tr>
            <td>ACCOUNT NO</td>
            <td>132-3-71563-3 / SAVING AC</td>
        </tr>
    </tbody>
</table>
<br>
<div style="display:flex">
    <div style="flex:1;border:1px solid black ;border-radius:5px;text-align:center">
        FOR THE CUSTOMER<br />
        <br /><br /><br /><br />
        __________________________________________<br />
        .........................................<br />
        _____/______/______
    </div>
    <div style="flex:1;border:1px solid black ;border-radius:5px;text-align:center">
        FOR @ViewBag.PROFILE_COMPANY_NAME<br />
        <br /><br /><br /><br />
        __________________________________________<br />
        .........................................<br />
        _____/______/______
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let ans = confirm('OK to print Original or Cancel For Copy');
    if (ans == true) {
        $('#dvCopy').html('<b>**ORIGINAL**</b>');
    } else {
        $('#dvCopy').html('<b>**COPY**</b>');
    }
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

            $('#lblTaxNumber').text(data.customer[0][0].TaxNumber);
            if (data.customer[0][0].UsedLanguage == 'TH') {
                if(Number(data.customer[0][0].Branch)>0) {
                        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :' + h.CustBranch);
                } else {
                        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :สำนักงานใหญ่');
                }
                $('#lblCustName').text(data.customer[0][0].NameThai);
                $('#lblCustAddress').text(data.customer[0][0].TAddress1 + '\n' + data.customer[0][0].TAddress2);
            } else {
                if(Number(data.customer[0][0].Branch)>0) {
                        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :' + h.CustBranch);
                } else {
                        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :HEAD OFFICE');
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
            let prepaid = 0;
            let dv = $('#tbDetail');
            let html = '';

            for (let dr of data.detail[0]) {
                html += '<tr>';
                html += '<td>' + dr.ItemNo + '</td>';
                html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td>' + dr.InvNo + '</td>';
                /*  html += '<td>' + dr.RefNo + '</td>';*/
                html += '<td>' + dr.CustInvNo + '</td>';
                html += '<td>' + dr.CTN_NO + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(Number(dr.AmtChargeNonVAT)+Number(dr.AmtChargeVAT), 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtVAT, 2) + '</td>';
                //html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH1, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH3, 2) + '</td>';
                //html += '<td style="text-align:right">' + ShowNumber(dr.TotalCustAdv, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.TotalNet, 2) + '</td>';
                html += '</tr>';

                total += Number(dr.TotalNet);
                serv += Number(dr.AmtChargeNonVAT)+Number(dr.AmtChargeVAT);
                adv += Number(dr.AmtAdvance);
                vat += Number(dr.AmtVAT);
                prepaid += Number(dr.TotalCustAdv);
                wh1 += Number(CDbl(dr.AmtWH1, 2));
                wh3 += Number(CDbl(dr.AmtWH3, 2));
            }
            dv.html(html);
            $('#lblSumAdv').text(ShowNumber(adv, 2));
            $('#lblSumService').text(ShowNumber(serv, 2));
            $('#lblSumVat').text(ShowNumber(vat, 2));
            $('#lblSumWh1').text(ShowNumber(wh1, 2));
            $('#lblSumWh3').text(ShowNumber(wh3, 2));
            $('#lblSumPrepaid').text(ShowNumber(prepaid, 2));
            $('#lblBillTotal').text(ShowNumber(total,2));
            $('#lblBillTotalEng').text(CNumEng(CDbl(total,2)));
        }
    }
</script>