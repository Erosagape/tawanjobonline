
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = "BILLING COVER SHEET (ใบวางบิล/ใบแจ้งหนี้) "
End Code
<style>
    * {
        font-size: 12px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
    tbody td,th {
        font-size:12px;
    }
</style>
<div style="display:flex;flex-direction:column">
    <div style="display:flex;">
        <div style="flex:1;" class="text-left">
            <p>
                TAX-ID : <label id="lblTaxNumber"></label>
            </p>
        </div>
        <div style="flex:1;" class="text-right">
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
    <br/>
    <table border="1" style="border-style:solid;width:100%;margin-top:5px ">
        <tr>
            <td class="text-center" width="100" rowspan="2">ITEMS</td>
            <td class="text-center" width="100" rowspan="2">ISSUE DATE</td>
            <td class="text-center" width="130" rowspan="2">INVOICE NO.</td>
            <td class="text-center" width="130" rowspan="2">JOB NO.</td>
            <td class="text-center" colspan="2">AMOUNT</td>
            <td class="text-center" width="60" rowspan="2">VAT</td>
            <td class="text-center" colspan="2">W/H</td>
            <td class="text-center" width="100" rowspan="2">TOTAL</td>
        </tr>
        <tr>
            <td class="text-center" width="130">REIMBURSEMENT</td>
            <td class="text-center" width="90">SERVICE</td>
            <td class="text-center" width="50">1%</td>
            <td class="text-center" width="50">3%</td>
        </tr>
        <tbody id="tbDetail"></tbody>
        <tr>
            <td style="text-align:right" colspan="4">TOTAL</td>
            <td style="text-align:right"><label id="lblSumAdv"></label></td>
            <td style="text-align:right"><label id="lblSumService"></label></td>
            <td style="text-align:right"><label id="lblSumVat"></label></td>
            <td style="text-align:right"><label id="lblSumWh1"></label></td>
            <td style="text-align:right"><label id="lblSumWh3"></label></td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
        </tr>
        <tr style="background-color:lightblue">
            <th class="text-center" colspan="10"><label id="lblBillTotalEng"></label></th>
        </tr>
    </table>

    <div>
        <p>กำหนดชำระเงิน : <label id="lblPaymentDueDate"></label></p>
        <p><u>รายการชำระเงิน</u></p>
        <table id="tbPayS" style="width:100%">
            <tr><td>กรุณาโอนเงินเข้าบัญชีธนาคารกสิกรไทย สาขาโรบินสันจันทบุรี</td></tr>
            <tr><td>บัญชีออมทรัพย์ ชื่อบัญชี "บริษัท แดนผักกาด จำกัด" เลขที่บัญชี 528-2-38819-9</td></tr>
            <tr><td>กรุณาหัก ณ ที่จ่าย และนำส่งใบหัก ณ ที่จ่าย มายัง</td></tr>
            <tr><td>บริษัท แดนผักกาด จำกัด เลขที่ 9/10 ม.10 ต.ท่าช้าง อ.เมือง จ.จันทบุรี 22000</td></tr>
        </table>
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
            FOR @ViewBag.PROFILE_COMPANY_NAME<br />
            <br /><br /><br /><br />
            __________________________________________<br />
            .........................................<br />
            _____/______/______
        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    
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
                $('#lblCustName').text(data.customer[0][0].NameThai);
                $('#lblCustAddress').text(data.customer[0][0].TAddress1 + '\n' + data.customer[0][0].TAddress2);
            } else {
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
            let whsum1 = 0;
            let whsum3 = 0;
            let dv = $('#tbDetail');
            let html = '';
            let row = 0;
            for (let dr of data.detail[0]) {
                $.get(path + 'Acc/GetInvoice?Branch=' + dr.BranchCode + '&Code=' + dr.InvNo).done(function (r) {
                    if (r.invoice.detail.length > 0) {
                        row += 1;
                        wh1 = 0;
                        wh3 = 0;
                        for (let t of r.invoice.detail[0]) {
                            if (t.AmtCharge > 0) {
                                if (t.Rate50Tavi == 1) {
                                    wh1 += t.Amt50Tavi;
                                } else {
                                    wh3 += t.Amt50Tavi;
                                }
                            }
                        }
                        whsum1 += wh1;
                        whsum3 += wh3;
                        html = '<tr>';
                        html += '<td>' + row + '</td>';
                        html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                        html += '<td>' + dr.InvNo + '</td>';
                        html += '<td>' + dr.RefNo + '</td>';
                        html += '<td style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                        html += '<td style="text-align:right">' + ShowNumber(Number(dr.AmtChargeNonVAT + dr.AmtChargeVAT), 2) + '</td>';
                        html += '<td style="text-align:right">' + ShowNumber(dr.AmtVAT, 2) + '</td>';
                        html += '<td style="text-align:right">' + ShowNumber(wh1, 2) + '</td>';
                        html += '<td style="text-align:right">' + ShowNumber(wh3, 2) + '</td>';
                        html += '<td style="text-align:right">' + ShowNumber(dr.AmtTotal, 2) + '</td>';
                        html += '</tr>';
                        dv.append(html);

                        $('#lblSumWh1').text(ShowNumber(whsum1, 2));
                        $('#lblSumWh3').text(ShowNumber(whsum3, 2));
                    }
                });

                total += Number(dr.AmtTotal);
                serv += Number(dr.AmtChargeNonVAT)+Number(dr.AmtChargeVAT);
                adv += Number(dr.AmtAdvance);
                vat += Number(dr.AmtVAT);

            }
            $('#lblSumAdv').text(ShowNumber(adv, 2));
            $('#lblSumService').text(ShowNumber(serv, 2));
            $('#lblSumVat').text(ShowNumber(vat, 2));

            $('#lblBillTotal').text(ShowNumber(total,2));
            $('#lblBillTotalEng').text(CNumEng(total));
        }
    }
</script>