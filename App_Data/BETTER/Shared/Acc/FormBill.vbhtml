﻿
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-size: 12px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
        margin-bottom: 10px;
        page-break-inside: auto;
    }

    #summary td {
        width: 16%;
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
        border-color: #66FFCC;
        font-size: 12px;
    }


    #dvFooter {
        display: none;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .bold {
        font-weight: bold;
    }

    .textSpace {
        width: 20em;
    }

    .underLine {
        border-bottom: 1px solid #66FFCC !important;
    }

    .upperLine {
        border-top: 1px solid #66FFCC !important;
    }

    .table td, .table th, .table thead th {
        padding: 0.3em;
    }

    table {
        width: 100%;
    }
</style>
@*<div id="dvCopy"></div>*@
@*<div style="display:flex;">
        <div style="flex:1;" class="text-left">
            <p>
                TAX-ID : <label id="lblTaxNumber"></label>
            </p>
        </div>
        <div style="flex:1;text-align:right" onclick="$('#test1').show();$('#test2').show();$('#test3').show();">
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
    </div>*@
<table id="test3" style="width: 100%; border: 1px solid #66FFCC;">
    <tbody>
        <tr>
            <td style="width:55%;font-weight:bold">RECEIVED FROM</td>
            <td style="background-color:#FFCCFF;border-left:1px solid #66FFCC;font-weight:bold">No.</td>
            <td style="background-color:#FFCCFF" >:</td>
            <td style="background-color:#FFCCFF"><label id="lblBillAcceptNo"></label></td>
        </tr>
        <tr>
            <td><label id="lblCustName" style="font-weight:bold"></label></td>
            <td style="background-color:#FFCCFF;border-left: 1px solid #66FFCC; border-bottom: 1px solid #66FFCC;font-weight:bold">DATE</td>
            <td style="background-color:#FFCCFF;border-bottom:1px solid #66FFCC">:</td>
            <td style="background-color:#FFCCFF;border-bottom:1px solid #66FFCC"><label id="lblBillDate"></label></td>
        </tr>
        <tr>
            <td><label id="lblCustAddress" rowspan="2"></label></td>
            <td style="border-left:1px solid #66FFCC" rowspan="3" colspan="3">
                <p style="text-align:center;font-weight:bold;font-size:16px">ใบวางบิล (BILLING NOTE) </p>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td>
                TAX-ID <label id="lblTaxNumber"></label> 
            </td>
        </tr>
    </tbody>
</table>
<table id="test2" style="width:100%" border="1">
    <tbody id="summary">
        <tr style="text-align:center">
            <td rowspan="2">SUMMARY</td>
            <td style='background-color:#FFCCFF;'>REIMBURSEMENT</td>
            <td style='background-color:#FFCCFF;'>SERVICE</td>
            <td style='background-color:#FFCCFF;'>VAT 7%</td>
            <td style='background-color:#FFCCFF;'>TOTAL AMOUNT</td>
            <td style='background-color:#FFCCFF;'>GRAND TOTAL</td>
        </tr>
    </tbody>
</table>
<table id="test1" style="border-style:solid;width:100%;" class="text-center">
    <thead>
        <tr>
            <th class="border" style='background-color:#FFCCFF;' height="40">NO.</th>
            <th class="border" style='background-color:#FFCCFF;'  height="40">INV.NO.</th>
            <th class="border" style='background-color:#FFCCFF;'  >REF NO</th>
            <th class="border" style='background-color:#FFCCFF;'  >BFT NO</th>
            <th class="border" style='background-color:#FFCCFF;'  >ADVANCE</th>
            <th class="border" style='background-color:#FFCCFF;'  >SERVICE</th>
            <th class="border" style='background-color:#FFCCFF;'  >VAT</th>
            <th class="border" style='background-color:#FFCCFF;'  >WHT</th>
            <th class="border" style='background-color:#FFCCFF;'  >TOTAL</th>
        </tr>
    </thead>

    <tbody id="tbDetail2"></tbody>
    <tr style="text-align:right;">
        <td class="border" colspan="4" style="text-align:center;background-color:#FFCCFF;">TOTAL</td>
        <td class="border" style='background-color:#FFCCFF;font-weight:bold;'  ><label id="lblTotalADV"></label></td>
        <td class="border" style='background-color:#FFCCFF;font-weight:bold;'  ><label id="lblTotalBeforeVAT"></label></td>
        <td class="border" style='background-color:#FFCCFF;font-weight:bold;'  ><label id="lblTotalVAT"></label></td>
        <td class="border" style='background-color:#FFCCFF;font-weight:bold;'  ><label id="lblTotalWHT"></label></td>
        <td class="border" style='background-color:#FFCCFF;font-weight:bold;'  ><label id="lblTotalNET"></label></td>
    </tr>
    <tr class="border" style="">
        <td colspan="2" style="text-align: left;">TOTAL RECEIPT : BAHT</td>
        <td style="text-align:center;font-weight:bold;" colspan="8"><label id="lblTotalText"></label></td>
        @*<td colspan="1"><label id="lblTotalAfterVAT"></label></td>*@
    </tr>
</table>
@*<table style="width:70%" ;>
        <tbody>
            <tr>
                <td rowspan="2" style="width:10%;vertical-align: central; font-size: 16px; white-space: nowrap">PAY BY:</td>
                <td style="width: 10%; white-space: nowrap">TRANSFER</td>
                <td contenteditable="true" style="border-bottom:1px black solid;white-space:pre;"></td>
                <td style="width: 10%; white-space: nowrap">RV NO.</td>
                <td contenteditable="true" style="border-bottom: 1px black solid; white-space: pre;"></td>
            </tr>
            <tr>
                <td style="width: 10%; white-space: nowrap ">CHEQUE NO.</td>
                <td contenteditable="true" style="border-bottom: 1px black solid; white-space: pre"></td>
                <td style="width: 10%; white-space: nowrap">DATE:.</td>
                <td contenteditable="true" style="border-bottom: 1px black solid; white-space: pre"></td>
            </tr>
        </tbody>
    </table>*@
<div id="dvCopy" style="display:flex;width:100%">
    <div style="width:70%;"></div>
</div>
<p class="bold">DULY CHECKED AND RECEIVED IN GOOD CONDITION</p>
<table class="table">
    <tr>
        <td class="bold" style="width:100px">By :</td>
        <td class="underLine textSpace" style="width:50px"></td>
        <td style="width:50px"> </td>
        <td class="underLine center" style="width:200px">

            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td class="bold">DUE DATE :</td>
        <td class="textSpace"></td>
        <td style="width:50px"> </td>
        <td class="center bold">
            @ViewBag.User
            <br />
            AUTHORIZED SIGNATURE
        </td>
    </tr>
</table>
@*<div style="display:flex;width:100%">
        <div style="width:70%;"></div>
        <div style="width:30%;border-top:1px dotted black;text-align:center;padding:10px;margin:30px 0px;">
            AUTHORIZED SIGNATURE
        </div>
    </div>*@
<!--<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
    <thead>
        <tr>
            <th class="text-center" width="50" rowspan="2">NO</th>
            <th class="text-center" width="100" rowspan="2">ISSUE DATE</th>
            <th class="text-center" width="130" rowspan="2">INVOICE NO.</th>
            <th class="text-center" width="130" rowspan="2">CUST INV..</th>-->
@*<th class="text-center" width="130" rowspan="2">JOB NO.</th>*@
<!--<th class="text-center" colspan="2">AMOUNT</th>
            <th class="text-center" width="60" rowspan="2">VAT</th>
            <th class="text-center" colspan="2">W/H</th>
            <th class="text-center" width="80" rowspan="2">PREPAID</th>
            <th class="text-center" width="100" rowspan="2">NET</th>
        </tr>
        <tr>
            <th class="text-center" width="100">ADVANCE</th>
            <th class="text-center" width="90">SERVICE</th>
            <th class="text-center" width="50">1%</th>
            <th class="text-center" width="50">3%</th>
        </tr>
    </thead>
    <tbody id="tbDetail">
    </tbody>
    <tfoot>
        <tr>
            <td style="text-align:right" colspan="4">TOTAL</td>
            <td style="text-align:right"><label id="lblSumAdv"></label></td>
            <td style="text-align:right"><label id="lblSumService"></label></td>
            <td style="text-align:right"><label id="lblSumVat"></label></td>
            <td style="text-align:right"><label id="lblSumWh1"></label></td>
            <td style="text-align:right"><label id="lblSumWh3"></label></td>
            <td style="text-align:right"><label id="lblSumPrepaid"></label></td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
        </tr>
        <tr style="background-color:lightblue">
            <th class="text-center" colspan="11"><label id="lblBillTotalEng"></label></th>
        </tr>
    </tfoot>
</table>-->
@*<div style="margin-top:60px">
        <p>PAYMENT DUE DATE : <label id="lblPaymentDueDate"></label></p>
        <p>PLEASE PAY CHEQUE IN NAME @ViewBag.PROFILE_COMPANY_NAME</p>
        <p>PAYMENT SHOULD BE PAID BY CROSS CHEQUE IN FAVOR OF  @ViewBag.PROFILE_COMPANY_NAME</p>
        <p>SIGN ON RECEIVER AND ASSIGNED PAYMENT DATE AND SEND THIS PAPER TO @ViewBag.PROFILE_COMPANY_NAME FAX. @ViewBag.PROFILE_COMPANY_FAX</p>
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
    </div>*@
@*<div style="text-align:center">
        (โปรดตรวจสอบความถูกต้องของรายการในเอกสารฉบับนี้ภายใน 7 วัน มิฉะนั้นบริษัทฯ จะถือว่าเอกสารฉบับนี้ถูกต้องสมบูรณ์)
        <br />
        ใบวางบิลนี้จะสมบูรณ์ก็ต่อเมื่อมีลายเซ็นต์ของผู้รับเงินและผู้ได้รับมอบอำนาจเท่านั้น
        <br />
        และต่อเมื่อบริษัทฯ ได้เรียกเก็บเงินตามเช็คและเงินเข้าบัญชีบริษัทครบถ้วนแล้ว
        <br />
        <label style="font-size:10px"> This billing cover sheet is not valid unless signed by our bill collector and authorized person and that the cheque has already been cleared by bank.</label>

    </div>*@
<script type="text/javascript">
    $('#imgLogo').hide();
    $('#imgLogoAdd').show();
    //$('#test1').hide();
    //$('#test2').hide();
    //$('#test3').hide();
    let path = '@Url.Content("~")';
    let ans = confirm('OK to print Original or Cancel For Copy');
    let str = ans == true ? "ต้นฉบับ/ORIGINAL" : "สำเนา/COPY";

    $('#dvCopy').html($('#dvCopy').html() + '<div style="width:30%;margin: 1em 0em; padding: 1em; border: 1px black solid;font-size:18px;text-align:center;font-weight:bold">' + str + '</div>');

    //let ans = confirm('OK to print Original or Cancel For Copy');
    //if (ans == true) {
    //    $('#dvCopy').html(`<b onclick="$('#test1').toggle();$('#test2').toggle();$('#test3').toggle();">**ORIGINAL**</b>`);
    //} else {
    //    $('#dvCopy').html('<b>**COPY**</b>');
    //}
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
            $("#lblTaxNumber").text(data.customer[0][0].TaxNumber);
            if (data.customer[0][0].UsedLanguage == "TH") {
                if (Number(data.customer[0][0].Branch) > 0) {
                    $("#lblTaxNumber").text(
                        data.customer[0][0].TaxNumber +
                        " BRANCH :" +
                        data.customer[0][0].CustBranch
                    );
                } else {
                    $("#lblTaxNumber").text(
                        data.customer[0][0].TaxNumber + " BRANCH :สำนักงานใหญ่"
                    );
                }
                $("#lblCustName").text(data.customer[0][0].NameThai);
                $("#lblCustAddress").text(
                    data.customer[0][0].TAddress1 + "\n" + data.customer[0][0].TAddress2
                );
            } else {
                if (Number(data.customer[0][0].Branch) > 0) {
                    $("#lblTaxNumber").text(
                        data.customer[0][0].TaxNumber + " BRANCH :" + h.CustBranch
                    );
                } else {
                    $("#lblTaxNumber").text(
                        data.customer[0][0].TaxNumber + " BRANCH :HEAD OFFICE"
                    );
                }
                $("#lblCustName").text(data.customer[0][0].NameEng);
                $("#lblCustAddress").text(
                    data.customer[0][0].EAddress1 + "\n" + data.customer[0][0].EAddress2
                );
            }
        }

        if (data.detail.length > 0) {
            let total = 0;
            let serv = 0;
            let adv = 0;
            let vat = 0;
            let wh1 = 0;
            let wh3 = 0;
            let wh = 0;
            let prepaid = 0;
            let dv = $('#tbDetail');
            let html = '';
            let testNewBillTotal = 0;
            let i = 0;
            let html2 =""
            for (let dr of data.detail[0]) {
                html += '<tr>';
                html += '<td>' + dr.ItemNo + '</td>';
                html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td>' + dr.InvNo + '</td>';
              /*  html += '<td>' + dr.RefNo + '</td>';*/
                html += '<td>' + dr.CustInv + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(Number(dr.AmtChargeNonVAT)+Number(dr.AmtChargeVAT), 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH1, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH3, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.TotalCustAdv, 2) + '</td>';

                let testNewNet = dr.AmtAdvance + Number(dr.AmtChargeNonVAT) + Number(dr.AmtChargeVAT) + dr.AmtVAT - dr.AmtWH;
                testNewBillTotal += testNewNet;
                //console.log(dr.AmtAdvance);
                //console.log(Number(dr.AmtChargeNonVAT) + Number(dr.AmtChargeVAT));
                //console.log(dr.AmtVAT);
                //console.log(dr.AmtWH1);
                //console.log(dr.AmtWH3);

                html += '<td style="text-align:right">' + ShowNumber(testNewNet , 2) + '</td>';
             /*   html += '<td style="text-align:right">' + ShowNumber(dr.TotalNet, 2) + '</td>';*/
                html += '</tr>';

                total += Number(dr.TotalNet);
                serv += Number(dr.AmtChargeNonVAT)+Number(dr.AmtChargeVAT);
                adv += Number(dr.AmtAdvance);
                vat += Number(dr.AmtVAT);
                prepaid += Number(dr.TotalCustAdv);
                wh1 += Number(dr.AmtWH1);
                wh3 += Number(dr.AmtWH3);
                wh += Number(dr.AmtWH);

                html2 += '<tr>';
                html2 += '<td class="vborder" style="text-align:center;">' + dr.ItemNo  + '</td>';
                html2 += '<td class="vborder"  style="text-align:center">' + dr.InvNo  + '</td>';
                html2 += '<td  class="vborder" style="text-align:center">' + dr.CustInv  + '</td>';
                html2 += '<td  class="vborder" style="text-align:center">' + dr.RefNo + '</td>';
                //html += '<td style="text-align:center">' + d.CurrencyCode + '</td>';
                //html += '<td style="text-align:center">' + d.ExchangeRate + '</td>';
                html2 += '<td  class="vborder" style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                html2 += '<td  class="vborder" style="text-align:right">' + ShowNumber(Number(dr.AmtChargeNonVAT) + Number(dr.AmtChargeVAT), 2)  + '</td>';
                html2 += '<td  class="vborder" style="text-align:right">' + ShowNumber(dr.AmtVAT, 2)  + '</td>';
                html2 += '<td  class="vborder" style="text-align:right">' + ShowNumber(dr.AmtWH, 2) + '</td>';
                html2 += '<td  class="vborder" style="text-align:right">' + ShowNumber(testNewNet, 2)  + '</td>';
                html2 += '</tr>';
            }
            dv.html(html);
            $('#tbDetail2').html(html2);


            $('#lblTotalBeforeVAT').text(ShowNumber(serv, 2));
            $('#lblTotalVAT').text(ShowNumber(vat, 2));

            $('#lblTotalWHT').text(ShowNumber(wh, 2));
            $('#lblTotalADV').text(ShowNumber(adv, 2));
            //$('#lblTotalAfterVAT').text(ShowNumber(amt, 2));
            $('#lblTotalNET').text(ShowNumber(testNewBillTotal, 2));
            $('#lblTotalText').text(CNumThai(CDbl(testNewBillTotal, 2)));

            $('#summary').html($('#summary').html() +
             `<tr style="text-align:right">
                <td>${ShowNumber(adv, 2)}</td>
                <td>${ShowNumber(serv, 2)}</td>
                <td>${ShowNumber(vat, 2)}</td>
                <td>${ShowNumber(serv + vat, 2)}</td>
                <td>${ShowNumber(testNewBillTotal, 2)}</td>
             </tr>`);


            $('#lblSumAdv').text(ShowNumber(adv, 2));
            $('#lblSumService').text(ShowNumber(serv, 2));
            $('#lblSumVat').text(ShowNumber(vat, 2));
            $('#lblSumWh1').text(ShowNumber(wh1, 2));
            $('#lblSumWh3').text(ShowNumber(wh3, 2));
            $('#lblSumPrepaid').text(ShowNumber(prepaid, 2));
            $('#lblBillTotal').text(ShowNumber(testNewBillTotal,2));
            $('#lblBillTotalEng').text(CNumEng(total));
        }
    }
</script>