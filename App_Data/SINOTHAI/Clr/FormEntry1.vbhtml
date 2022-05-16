@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Clearing Form"
End Code
<style>
    .underline {
        border-bottom: solid;
        border-width: thin;
        border-collapse: collapse;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    .block {
        margin-bottom: 4px;
    }

        .block tr td {
            text-align: center;
        }

    .textleft {
        text-align: left !important;
    }

    .textright {
        text-align: right !important;
    }
</style>
<div style="display:flex;flex-direction:column">

    <div class="block">
        <div style="float:left">
            <input type="checkbox" id="chkExport" />OUTBOUND
            <input type="checkbox" id="chkImport" />INBOUND
            <input type="checkbox" id="chkOther" />SHIPPING
        </div>
        <div style="float:right;width:50%;">
            <div style="width:100%;display:flex">
                <div style="flex:1;">
                    O BL/AWB NO:
                </div>
                <div id="dvMAWB" class="underline" style="flex:3">

                </div>
            </div>
            <div style="width:100%;display:flex">
                <div style="flex:1;">
                    H BL/AWB NO:
                </div>
                <div id="dvHAWB" class="underline" style="flex:3">

                </div>
            </div>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            JOB NO:
        </div>
        <div id="dvJNo" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            CUSTOMER INV.NO:
        </div>
        <div id="dvInvNo" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            SHIPPER/CONSIGNEE:
        </div>
        <div id="dvConsignee" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            ETD:
        </div>
        <div id="dvETDDate" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            CONTACT:
        </div>
        <div id="dvContactName" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            ETA:
        </div>
        <div id="dvETADate" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            FEEDER:
        </div>
        <div id="dvVesselName" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            D/O DATE:
        </div>
        <div id="dvEstDeliverDate" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            FROM PORT:
        </div>
        <div class="underline" style="flex:2">
            <span id="dvFromPort"></span>
            <span id="dvFromCountry"></span>
        </div>
        <div style="flex:1">
            AGENT:
        </div>
        <div id="dvAgentName" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            TO PORT:
        </div>
        <div class="underline" style="flex:2">
            <span id="dvToPort"></span>
            <span id="dvToCountry"></span>
        </div>
        <div style="flex:1">
            CONTAINER.DEPOSIT:
        </div>
        <div id="dvDeposit" class="underline" style="flex:2">

        </div>
    </div>
    <table border="1">
        <thead>
            <tr>
                <th rowspan="2">CLEAR NO</th>
                <th rowspan="2">DESCRIPTION</th>
                <th colspan="3">COST</th>
                <th>SELLING</th>
                <th rowspan="2" colspan="2">PROFIT</th>
            </tr>
            <tr>
                <th>CUSTOMER-SLIP</th>
                <th>COMPANY-SLIP</th>
                <th>NO-SLIP</th>
                <th>SERVICES</th>
            </tr>
        </thead>
        <tbody id="tb">
        </tbody>
    </table>
    <div class="block" style="display:flex;width:50%">
        <div style="flex:1">
            HANDLE BY:
        </div>
        <div class="underline" style="flex:2">

        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let job = getQueryString("Job");
    if (branch !== job && job !== '') {
        $.get(path + 'JobOrder/GetJobSql?Branch=' + branch + '&JNo=' + job).done(function (r) {
            if (r.job.data.length > 0) {
                let dr = r.job.data[0];
                $('#chkImport').prop('checked', dr.JobType == 1 ? true : false);
                $('#chkExport').prop('checked', dr.JobType == 2 ? true : false);
                $('#chkOther').prop('checked', dr.JobType > 2 ? true : false);
                $('#dvMAWB').html(CStr(dr.MAWB));
                $('#dvHAWB').html(CStr(dr.HAWB));
                $('#dvJNo').html(CStr(dr.JNo));
                $('#dvInvNo').html(CStr(dr.InvNo));
                $('#dvContactName').html(CStr(dr.CustContactName));
                $('#dvETDDate').html(ShowDate(dr.ETDDate));
                $('#dvETADate').html(ShowDate(dr.ETADate));
                $('#dvEstDeliverDate').html(ShowDate(dr.EstDeliverDate));
                $('#dvVesselName').html(CStr(dr.VesselName));
                $('#dvProduct').html(CStr(dr.InvProduct));
                $('#dvGrossWeight').html(CStr(dr.TotalGW + ' ' + dr.GWUnit));
                $('#dvMeasurement').html(CStr(dr.Measurement));
                $('#dvTotalContainer').html(CStr(dr.TotalContainer));
                let intercountry = dr.InvFCountry;
                if (dr.JobType !== 1) {
                    intercountry = dr.InvCountry;
                    $.get(path + 'Master/GetInterPort?Key=' + intercountry + '&Code=' + dr.InvInterPort).done((r) => {
                        if (r.interport.length > 0) {
                            let p = r.interport.data[0];
                            $('#dvToPort').html(p.PortName);
                        }
                    });
                    $.get(path + 'Master/GetCustomsPort?Code=' + dr.ClearPort).done((r) => {
                        if (r.RFARS.length > 0) {
                            let p = r.RFARS.data[0];
                            $('#dvFromPort').html(p.AreaName);
                        }
                    });
                    $.get(path + 'Master/GetCountry?Code=' + intercountry).done((r) => {
                        if (r.country.data.length > 0) {
                            let c = r.country.data[0];
                            $('#dvToCountry').html(c.CTYName);
                        }
                    });
                    $.get(path + 'Master/GetCountry?Code=' + dr.InvFCountry).done((r) => {
                        if (r.country.data.length > 0) {
                            let c = r.country.data[0];
                            $('#dvFromCountry').html(c.CTYName);
                        }
                    });
                } else {
                    $.get(path + 'Master/GetInterPort?Key=' + intercountry + '&Code=' + dr.InvInterPort).done((r) => {
                        if (r.interport.length > 0) {
                            let p = r.interport.data[0];
                            $('#dvFromPort').html(p.PortName);
                        }
                    });
                    $.get(path + 'Master/GetCustomsPort?Code=' + dr.ClearPort).done((r) => {
                        if (r.RFARS.length > 0) {
                            let p = r.RFARS.data[0];
                            $('#dvToPort').html(p.AreaName);
                        }
                    });
                    $.get(path + 'Master/GetCountry?Code=' + intercountry).done((r) => {
                        if (r.country.data.length > 0) {
                            let c = r.country.data[0];
                            $('#dvFromCountry').html(c.CTYName);
                        }
                    });
                    $.get(path + 'Master/GetCountry?Code=' + dr.InvCountry).done((r) => {
                        if (r.country.data.length > 0) {
                            let c = r.country.data[0];
                            $('#dvToCountry').html(c.CTYName);
                        }
                    });
                }
                $.get(path + 'Master/GetCompany?Code=' + dr.Consigneecode).done((r) => {
                    if (r.company.data.length > 0) {
                        let c = r.company.data[0];
                        $('#dvConsignee').html(CStr(c.NameEng));
                    }
                });
                $.get(path + 'Master/GetVender?Code=' + dr.ForwarderCode).done((r) => {
                    if (r.vender.data.length > 0) {
                        let c = r.vender.data[0];
                        $('#dvAgentName').html(CStr(c.English));
                    }
                });
            }
        });

        $.get(path + 'clr/getclearingreport?branch=' + branch + '&job=' + job, function (r) {
            let amtadv = 0;
            let amtserv = 0;
            let amtvat = 0;
            let amtwht = 0;
            let amttotal = 0;
            let amtprofit = 0;
            let amtcost = 0;
            let commrate = 0;
            if (r.data.length > 0) {
                let tb = $('#tb');
                tb.empty();

                let h = r.data[0].Table[0];

                commrate = h.Commission;

                let d = r.data[0].Table.filter(function (data) {
                    return data.BNet !== 0;
                });
                //console.log(JSON.stringify(d));
                let customerSlipSum = 0;
                let companySlipSum = 0;
                let noSlipSum = 0;
                let servSum = 0;
                let profitSum = 0;
                for (let i = 0; i < d.length; i++) {
                    let html = '';
                    let amt = d[i].UsedAmount;
                    //let adv = (d[i].IsCredit == 1 ? amt : 0);
                    //let cost = (d[i].IsExpense == 1 || d[i].IsCredit == 1 ? amt : 0);                
                    let customerSlip = (d[i].IsHaveSlip == 1 && d[i].IsCredit == 1 ? amt : 0);
                    let companySlip = (d[i].IsHaveSlip == 1 &&  d[i].IsExpense == 1? amt : 0);
                    let noSlip = d[i].IsHaveSlip ==0 && d[i].IsExpense== 1 ? amt : 0;
                    let serv = (d[i].IsCredit == 0 && d[i].IsExpense == 0 ? amt : 0);
                    let profit = (d[i].IsExpense == 1 ? amt * -1 : d[i].IsCredit == 1 ? 0 : d[i].UsedAmount);
                    //amtadv += adv;
                    //amtserv += serv;
                    customerSlipSum += customerSlip;
                    companySlipSum += companySlip;
                    noSlipSum += noSlip;
                    servSum += serv;
                    profitSum += profit;
                    if (d[i].IsCredit == 0 && d[i].IsExpense == 0) {
                        if (d[i].IsTaxCharge > 0) {
                            amtvat += d[i].ChargeVAT;
                        }
                        if (d[i].Is50Tavi > 0) {
                            amtwht += d[i].Tax50Tavi;
                        }
                    }
                    html = '<tr>';
                    html += '<td>' + d[i].ClrNo + '#' + d[i].ItemNo + '</td>';
                    html += '<td>' + d[i].SICode + '-' + d[i].SDescription;
                    //if (d[i].AdvNO !== null) html += ' จากใบเบิก ' + d[i].AdvNO;
                    //if (d[i].SlipNO !== null) html += ' ใบเสร็จเลขที่ ' + d[i].SlipNO;

                    html += '</td>';
                    //if (customerSlip > 0) {
                    //    html += '<td style="text-align:right">' + customerSlip > 0 ? CCurrency(CDbl(customerSlip, 2)) : '' + '</td>';//CUSTOMER-SLIP
                    //} else {
                    //    html += '<td style="text-align:right"></td>';//CUSTOMER-SLIP
                    //}
                   html += '<td style="text-align:right">' + (customerSlip!=0? CCurrency(CDbl(customerSlip, 2)):'' )+ '</td>';//CUSTOMER-SLIP
                    html += '<td style="text-align:right">' + (companySlip!=0? CCurrency(CDbl(companySlip, 2)):'' )+ '</td>';//COMPANY-SLIP
                    html += '<td style="text-align:right">' + (noSlip !=0?CCurrency(CDbl(noSlip, 2)):'')+ '</td>';//NO-SLIP
                    html += '<td style="text-align:right">' + (serv !=0?CCurrency(CDbl(serv, 2)) :'')+ '</td>';//SERVICES
                    html += '<td style="text-align:right">' + (profit !=0?CCurrency(CDbl(profit, 2)):'') + '</td>';//PROFIT
                    html += '</tr>';



                    //amtcost += cost;
                    //amttotal += serv + adv;
                    //amtprofit += profit;

                    tb.append(html);
                }
                let summary = ` <tr>
               <td></td>
               <td></td>

               <td style="text-align:right">${customerSlipSum !=0?CCurrency(CDbl(customerSlipSum, 2)):""}</td>
               <td style="text-align:right">${companySlipSum !=0?CCurrency(CDbl(companySlipSum, 2)):""}</td>
               <td style="text-align:right">${noSlipSum !=0?CCurrency(CDbl(noSlipSum, 2)):""}</td>
               <td style="text-align:right">${servSum !=0?CCurrency(CDbl(servSum, 2)):""}</td>
               <td style="text-align:right">${profitSum !=0?CCurrency(CDbl(profitSum, 2)):""}</td>
           </tr >`;
                tb.append(summary);
            }
            //$('#lblSumAdv').text(CCurrency(CDbl(amtadv, 2)));
            //$('#lblSumServ').text(CCurrency(CDbl(amtserv, 2)));

            //$('#lblSumCharge').text(CCurrency(CDbl(amttotal, 2)));
            //$('#lblSumTax').text(CCurrency(CDbl(amtwht, 2)));
            //$('#lblSumCost').text(CCurrency(CDbl(amtcost, 2)));
            //$('#lblSumProfit').text(CCurrency(CDbl(amtprofit, 2)));
            //$('#lblTotalVAT').text(CCurrency(CDbl(amtvat, 2)));
            //if (amtprofit > 0) {
            //    $('#lblCommRate').text(CCurrency(CDbl(amtprofit * (commrate / 100), 2)));
            //    $('#lblNetProfit').text(CCurrency(CDbl(amtprofit - (amtprofit * (commrate / 100)), 2)));
            //} else {
            //    $('#lblCommRate').text(CCurrency(CDbl(0, 2)));
            //    $('#lblNetProfit').text(CCurrency(CDbl(amtprofit, 2)));
            //}
        });
    }
</script>

