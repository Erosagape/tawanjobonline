﻿@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = ""
    ViewBag.Title = "Job Costing Summary"
End Code
<style>
    * {
        font-size: 11px;
    }

    body {
        line-height: 1;
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

    .table-bordered td, .table-bordered th {
        border: 1px solid black;
    }

    .table td, table th {
        padding: .2rem;
    }

    .table-borderless td {
        border: none;
    }

    .table-bordered thead td, .table-bordered thead th {
        border-bottom-width: 1px;
    }
</style>
<div style="display: flex;">
    <div style="flex:30%"></div>
    <div class="center bold" style="flex:40%">
        <label class="" style="font-size:16px">JOB SUMMARY</label>
    </div>
    <div style="flex:10%">
        <label id="numberLbl">Number</label>
    </div>
    <div style="flex:20%">
        <label id="number"></label>
    </div>
</div>
<div style="display: flex;">
    <div style="flex:70%"></div>
    <div id="salesbyLbl" style="flex:10%">Sals by</div>
    <div id="salesby" style="flex:20%"></div>
</div>
<table class="table table-borderless">
    <thead></thead>
    <tbody>
        <tr>
            <td id="dateLbl" style="width:60px">Date</td>
            <td>:</td>
            <td id="date"></td>

            <td id="referenceLbl" style="width:60px">Reference </td>
            <td>:</td>
            <td id="reference"></td>

            <td id="BLNoLbl" style="width:60px">B/L No.</td>
            <td>:</td>
            <td id="BLNo"></td>
        </tr>
        <tr>
            <td id="agentLbl">Agent</td>
            <td>:</td>
            <td id="agent"></td>

            <td id="fromLbl">From.</td>
            <td>:</td>
            <td id="from"></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td id="shipperLbl">Shipper</td>
            <td>:</td>
            <td id="shipper"></td>

            <td id="toLbl">To.</td>
            <td>:</td>
            <td id="to"></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td id="consigneeNameLbl">Consignee</td>
            <td>:</td>
            <td id="consigneeName"></td>

            <td id="termLbl">Term</td>
            <td>:</td>
            <td id="term"></td>

            <td></td>
            <td></td>
            <td></td>

        </tr>
        <tr>
            <td id="shippingAgentLbl">Shipping Agent</td>
            <td>:</td>
            <td id="shippingAgent"></td>

            <td id="etdLbl">ETD</td>
            <td>:</td>
            <td id="etd"></td>

            <td id="etaLbl">ETA</td>
            <td>:</td>
            <td id="eta"></td>
        </tr>
        <tr>
            <td id="customsBrokerLbl">Customs Broker</td>
            <td>:</td>
            <td id="customsBroker"></td>

            <td id="shedLbl">SHED</td>
            <td>:</td>
            <td id="shed"></td>

            <td id="terminalLbl">TERMINAL</td>
            <td>:</td>
            <td id="terminal"></td>
        </tr>
        <tr>
            <td id="feederLbl">FEEDER / VESSEL</td>
            <td>:</td>
            <td id="feeder"></td>

            <td id="cbmLbl">CBM</td>
            <td>:</td>
            <td id="cbm"></td>

            <td id="volumeLbl">Volume</td>
            <td>:</td>
            <td id="volume"></td>
        </tr>
        <tr>
            <td id="remarkLbl">REMARK</td>
            <td>:</td>
            <td id="remark"></td>

            <td id="sellUSDTHBLbl">Selling USD:THB</td>
            <td>:</td>
            <td id="sellUSDTHB"></td>

            <td id="buyUSDTHBLbl">Buying USD:THB</td>
            <td>:</td>
            <td id="buyUSDTHB"></td>
        </tr>
    </tbody>
</table>

<table class="table" border="1" style="width:100%;border-collapse:collapse;border-width:thin;">
    <tr>
        <td rowspan="2" style="width:30%">Description</td>
        <td class="center" rowspan="2" style="width:8em">Customer Pay</td>
        @*<td class="center" rowspan="2">Settle with</td>*@
        <td class="center" colspan="8">TOTAL REVENUE</td>
    </tr>
    <tr>
        <td class="center">Unit price</td>
        <td class="center">Qty</td>
        <td class="center">Curr</td>
        <td class="center">Amount</td>
        <td class="center">VAT</td>
        <td class="center">WHD</td>
        <td class="center">Advance</td>
        <td class="center">Revenue</td>
        <td class="center">Total</td>
    </tr>
    <tbody id="dt1">
    </tbody>
</table>
<br />
<table class="table" border="1" style="width:100%;border-width:thin;border-collapse:collapse;">
    <tr>
        <td rowspan="2">Description</td>
        <td class="center" rowspan="2" style="width:8em">Company Pay</td>
        @*<td class="center" rowspan="2">Settle with</td>*@
        <td class="center" colspan="8">TOTAL COST</td>
    </tr>
    <tr>
        <td class="center">Unit price</td>
        <td class="center">Qty</td>
        <td class="center">Curr</td>
        <td class="center">Amount</td>
        <td class="center">VAT</td>
        <td class="center">WHD</td>
        <td class="center">Advance</td>
        <td class="center">Cost</td>
        <td class="center">Total</td>
    </tr>
    <tbody id="dt2">
    </tbody>
</table>

<div class="row">
    <div class="col-8"></div>
    <div class="col-4">
        <p class="right bold" style="border: 1px solid black; padding:5px">
            <label id="netAmountLbl">SALES PROFIT</label>
            <label id="netAmount"></label>
        </p>
    </div>
</div>
<div class="row">
    <div class="col-8"></div>
    <div class="col-4">
        <p class="right bold" style="border: 1px solid black; padding:5px">
            <label id="netProfitLbl">JOB PROFIT</label>
            <label id="netProfit"></label>
        </p>
    </div>
</div>
<script src="~/Scripts/Func/reports.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString('BranchCode');
    let job = getQueryString('JNo');
    let commissionCode = 'CST-138,CST-147';
    if (branch != "" && job != "") {
        let url = path + 'clr/getclearingreport?branch=' + branch + '&job=' + job;
        $.get(url, (r) => {
            if (r.data.length> 0) {
                let h = r.data[0];
                $("#number").text(h.JobNo);
                $("#date").text(ShowDate(h.JobDate));
                $("#reference").text(h.CustRefNO);
                $("#BLNo").text(h.HAWB);
                ShowVender(path, h.AgentCode, '#agent');
                $("#from").text(h.ClearPortNo);
                $("#shipper").text(h.NameEng);
                $("#to").text(h.JobCondition);
                ShowCustomerEN(path, h.consigneecode, h.CustBranch, 'consigneeName');
                $("#term").text(h.JobDesc);
                ShowVender(path, h.ForwarderCode, '#shippingAgent');
   		$("#salesby").text(h.SalesEName);
                $("#etd").text(ShowDate(h.ETDDate));
                $("#eta").text(ShowDate(h.ETADate));
                ShowUser(path, h.ShippingEmp, '#customsBroker');
                $("#shed").text(h.DeliveryTo);
                ShowReleasePort(path, h.ClearPort, '#terminal');
                $("#feeder").text(h.MVesselName);
                $("#cbm").text(h.Measurement);
                $("#volume").text(h.TotalQty);
                $("#remark").text(h.ShippingCmd);
                $("#sellUSDTHB").text(h.InvCurRate);
                $("#buyUSDTHB").text(h.InvCurRate);

                let d = r.data;
                let dt1 = d.filter((data) => {
                    return data.IsCredit == 1 || data.IsExpense == 0;
                });

                let html = '';
                html += '<tr>';
                html += '<td>{0}</td>';
                html += `<td class="center"><a href="${path}/acc/voucher?Branch=${branch}&Code={1}" target="_blank" >{1}</a></td>`;
                //html += '<td class="">{2}</td>';
                html += '<td class="right">{3}</td>';
                html += '<td class="right">{12}</td>';
                html += '<td class="right">{4}</td>';
                html += '<td class="center">{5}</td>';
                //html += '<td class="right">{6}</td>';
                html += '<td class="right">{7}</td>';
                html += '<td class="right">{8}</td>';
                html += '<td class="right">{9}</td>';
                html += '<td class="right">{10}</td>';
                html += '<td class="right">{11}</td>';
                html += '</tr>';

                let htmlTotal = '';
                htmlTotal += '<tr>';
                htmlTotal += '<td colspan="5"></td>';
                htmlTotal += '<td class="right">{3}</td>';
                htmlTotal += '<td class="right">{4}</td>';
                htmlTotal += '<td class="right">{5}</td>';
                htmlTotal += '<td class="right">{0}</td>';
                htmlTotal += '<td class="right">{1}</td>';
                htmlTotal += '<td class="right">{2}</td>';
                htmlTotal += '</tr>';

                let html1 = '';
                let suma1 = 0;
                let sumc1 = 0;
                let sumt1 = 0;
                let sumv1 = 0;
                let sumw1 = 0;
                let sum1 = 0;

                //alert(dt1.length);
                for (let i = 0; i < dt1.length; i++) {
                    let tmp = html;
                    tmp =tmp.replaceAll('{0}', dt1[i].SDescription);
            /*        tmp = tmp.replaceAll('{1}', dt1[i].LinkBillNo);*/
                    //tmp = tmp.replaceAll('{2}', dt1[i].CustCode);
                    tmp = tmp.replaceAll('{1}', dt1[i].ReceiveRef);
                    tmp = tmp.replaceAll('{3}', ShowNumber(dt1[i].UnitPrice, 2));
                    tmp = tmp.replaceAll('{12}', dt1[i].Qty);
                    tmp = tmp.replaceAll('{4}', dt1[i].CurrencyCode);
                    tmp = tmp.replaceAll('{5}', ShowNumber(dt1[i].UsedAmount, 2));
                                        //tmp = tmp.replaceAll('{6}', dt1[i].CurRate);
                    tmp = tmp.replaceAll('{7}', ShowNumber(dt1[i].ChargeVAT, 2));
                    tmp = tmp.replaceAll('{8}', ShowNumber(dt1[i].Tax50Tavi, 2));
                    tmp = tmp.replaceAll('{9}', dt1[i].IsCredit==1 ? ShowNumber(dt1[i].BNet, 2) : '');
                    tmp = tmp.replaceAll('{10}', dt1[i].IsExpense == 0 && dt1[i].IsCredit == 0 ? ShowNumber(dt1[i].BNet, 2):'');
                    tmp = tmp.replaceAll('{11}', ShowNumber(dt1[i].BNet, 2));

                    if (dt1[i].IsCredit == 1)
                    {
                        suma1 += dt1[i].BNet;
                    }
                    if (dt1[i].IsExpense == 0 && dt1[i].IsCredit == 0) {
                        sumc1 += dt1[i].BNet;
                        sumv1 += dt1[i].ChargeVAT;
                        sumw1 += dt1[i].Tax50Tavi;
                    }
                    sumt1 += dt1[i].BNet;
                    sum1 += dt1[i].UsedAmount;

                    html1 += tmp;
                }

                let tmp = htmlTotal;
                tmp = tmp.replaceAll('{0}', ShowNumber(suma1, 2));
                tmp = tmp.replaceAll('{1}', ShowNumber(sumc1, 2));
                tmp = tmp.replaceAll('{2}', ShowNumber(sumt1, 2));
                tmp = tmp.replaceAll('{3}', ShowNumber(sum1, 2));
                tmp = tmp.replaceAll('{4}', ShowNumber(sumv1, 2));
                tmp = tmp.replaceAll('{5}', ShowNumber(sumw1, 2));
                html1 += tmp;
                $('#dt1').html(html1);

                let dt2 = d.filter((data) => {
                    return data.IsCredit == 1 || data.IsExpense == 1;
                });

                let html2 = '';
                let suma2 = 0;
                let sumc2 = 0;
                let sumt2 = 0;
                let sumv2 = 0;
                let sumw2 = 0;
                let sum2 = 0;
                let sumcomm = 0;

                //alert(dt2.length);
                for (let i = 0; i < dt2.length; i++) {
                    console.log("------------");
                    console.log(commissionCode);
                    console.log(dt2[i].SICode);
                    console.log(commissionCode.indexOf(dt2[i].SICode) );
                    console.log("------------");
                    if (commissionCode.indexOf(dt2[i].SICode) >= 0) {
                       
                        sumcomm += dt2[i].BNet;
                    }
                    let tmp = html;
                    tmp = tmp.replaceAll('{0}', dt2[i].SDescription);
                 /*   tmp = tmp.replaceAll('{1}', dt2[i].LinkBillNo);*/
                    tmp = tmp.replaceAll('{1}', dt2[i].AdvPay ? dt2[i].AdvPay : dt2[i].ClrPay );
                    //tmp = tmp.replaceAll('{2}', dt2[i].VenderCode);
                    //tmp = tmp.replaceAll('{6}', dt2[i].CurRate);
                    tmp = tmp.replaceAll('{3}', ShowNumber(dt2[i].UnitCost, 2));
                    tmp = tmp.replaceAll('{12}', dt2[i].Qty);
                    tmp = tmp.replaceAll('{4}', dt2[i].CurrencyCode);
                    tmp = tmp.replaceAll('{5}', ShowNumber(dt2[i].UsedAmount, 2));
                    tmp = tmp.replaceAll('{7}', ShowNumber(dt2[i].ChargeVAT, 2));
                    tmp = tmp.replaceAll('{8}', ShowNumber(dt2[i].Tax50Tavi, 2));
                    tmp = tmp.replaceAll('{9}', dt2[i].IsCredit == 1 ? ShowNumber(dt2[i].BNet, 2) : '');
                    tmp = tmp.replaceAll('{10}', dt2[i].IsExpense == 1 && dt2[i].IsCredit == 0 ? ShowNumber(dt2[i].BNet, 2) : '');
                    tmp = tmp.replaceAll('{11}', ShowNumber(dt2[i].BNet, 2));

                    if (dt2[i].IsCredit == 1) {
                        suma2 += dt2[i].BNet;
                        sumv2 += dt2[i].ChargeVAT;
                        sumw2 += dt2[i].Tax50Tavi;
                    }
                    if (dt2[i].IsExpense == 1 && dt2[i].IsCredit == 0) {
                        sumc2 += dt2[i].BNet;
                    }
                    sumt2 += dt2[i].BNet;
                    sum2 += dt2[i].UsedAmount;

                    html2 += tmp;
                }
                tmp = htmlTotal;
                tmp = tmp.replaceAll('{0}', ShowNumber(suma2, 2));
                tmp = tmp.replaceAll('{1}', ShowNumber(sumc2, 2));
                tmp = tmp.replaceAll('{2}', ShowNumber(sumt2, 2));
                tmp = tmp.replaceAll('{3}', ShowNumber(sum2, 2));
                tmp = tmp.replaceAll('{4}', ShowNumber(sumv2, 2));
                tmp = tmp.replaceAll('{5}', ShowNumber(sumw2, 2));
                html2 += tmp;
                $('#dt2').html(html2);
                console.log(sum1);
                console.log(sumt1);
                $("#netAmount").text(ShowNumber(sum1 - sum2, 2));
                $("#netProfit").text(ShowNumber(sumt1 - sumt2 + sumcomm, 2));
            }
        });

    }
</script>