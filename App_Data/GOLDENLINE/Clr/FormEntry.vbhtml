@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Clearing Form"
End Code
<style>
    .underline {
        border-bottom:solid;
        border-width:thin;
        border-collapse:collapse;
    }
    table {
        border-width:thin;
        border-collapse:collapse;
    }
    .block {
        margin-bottom:4px;
    }
    .block tr td {
        text-align:center;
    }
    .textleft {
        text-align:left !important;
    }
    .textright {
        text-align:right !important;
    }
</style>
<div style="display:flex;flex-direction:column">
    <div class="block" style="width:100%;display:flex;flex-direction:row">
        <div style="flex:1">
            SHIPPER/CONSIGNEE:
        </div>
        <div id="dvConsignee" class="underline" style="flex:4">

        </div>
        <div style="flex:1">
            JOB NO:
        </div>
        <div id="dvJNo" class="underline" style="flex:1">

        </div>

    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1;">
            O BL/AWB NO:
        </div>
        <div id="dvMAWB" class="underline" style="flex:2">

        </div>
        <div style="flex:1;">
            DECLARE NO:
        </div>
        <div id="dvDeclareNumber" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            ETD DATE:
        </div>
        <div id="dvETDDate" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            CLOSE JOB:
        </div>
        <div id="dvCloseJobDate" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            CONTAINER SIZE:
        </div>
        <div id="dvTotalContainer" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            DESTINATION:
        </div>
        <div class="underline" style="flex:2">
            <span id="dvToPort"></span>
            <span id="dvToCountry"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            PRODUCT:
        </div>
        <div id="dvProduct" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            FROM PORT:
        </div>
        <div class="underline" style="flex:2">
            <span id="dvFromPort"></span>
            <span id="dvFromCountry"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            DELIVERY PLACE:
        </div>
        <div id="dvDelivery" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            TRANSPORT BY:
        </div>
        <div id="dvAgentName" class="underline" style="flex:2">

        </div>
    </div>
    <table class="block" border="1">
        <tr>
            <td rowspan="2">
                Exchange Rate: <div id="dvInvCurRate"></div>
            </td>
            <td colspan="3" style="width:45%">
                COST
            </td>
            <td style="width:15%;">SELLING</td>
            <td style="width:15%" rowspan="2">PROFIT</td>
        </tr>
        <tr>
            <td style="width:15%">
                CUSTOMER-SLIP
            </td>
            <td style="width:15%">
                COMPANY-SLIP
            </td>
            <td style="width:15%">
                NO-SLIP
            </td>
            <td>
                SERVICES
            </td>
        </tr>
        <tbody id="tbDetail">
        </tbody>
        <tr>
            <td class="textright">TOTAL</td>
            <td class="textright" id="fldSumClrAdv"></td>
            <td class="textright" id="fldSumClrCostSlip"></td>
            <td class="textright" id="fldSumClrCostNonSlip"></td>
            <td class="textright" id="fldSumClrService"></td>
            <td class="textright" id="fldSumClrProfit"></td>
        </tr>
        <tr>
            <td class="textright" colspan="5">CLEARING</td>
            <td class="textright" id="fldSumClr"></td>
        </tr>
        <tr>
            <td class="textright" colspan="5">ADVANCE</td>
            <td class="textright" id="fldSumAdv"></td>
        </tr>
        <tr>
            <td class="textright" colspan="5">BALANCE</td>
            <td class="textright" id="fldSumBal"></td>
        </tr>
        <tr>
            <td class="textleft" colspan="6">REMARK</td>
        </tr>

    </table>
    <div class="block" style="display:flex;width:50%">
        <div style="flex:1">
            HANDLE BY:
        </div>
        <div id="dvCSName" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block">
        <table style="border-collapse:collapse;width:100%">
            <tr>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                    Requested By
                </td>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                    Checked By
                </td>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                    Approved By
                </td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom" height="100px">
                    <label id="lblReqBy" style="font-size:10px">(___________________________)</label>
                    <br />
                    Import Manager
                    <br/>
                    <label id="lblRequestDate" style="font-size:9px">__/__/____</label>
                </td>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
                    <label id="lblCheckBy" style="font-size:9px">(___________________________)</label>
                    <br />
                    General Manager
                    <br/>
                    <label id="lblCheckDate" style="font-size:9px">__/__/____</label>
                </td>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
                    <label id="lblAppBy" style="font-size:10px">(___________________________)</label>
                    <br />
                    Managing Director
                    <br/>
                    <label id="lblAppDate" style="font-size:9px">__/__/____</label>
                </td>
            </tr>
        </table>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let job = getQueryString("Job");
    let sumAdv = 0;
    let sumClr = 0;
    if (branch !== job && job !== '') {
        $.get(path + 'Clr/GetClearingReport?Branch=' + branch + '&Job=' + job).done(function (r) {
            sumAdv = 0;
            sumClr = 0;
            if (r.data.length > 0) {
                let dt = r.data[0].Table.filter(function (data) {
                    return data.BNet !== 0;
                });
                let html = '<tr>';
                html += '<td class="textleft">{0}</td>';
                html += '<td class="textright">{1}</td>';
                html += '<td class="textright">{2}</td>';
                html += '<td class="textright">{3}</td>';
                html += '<td class="textright">{4}</td>';
                html += '<td class="textright">{5}</td>';
                html += '</tr>';
                let sumclrAdv = 0;
                let sumclrCostSlip = 0;
                let sumclrCostNonSlip = 0;
                let sumclrServ = 0;
                let sumclrProfit = 0;
                for (let d of dt) {
                    let data = html;
                    let netCharge = ShowNumber(d.BNet, 2);
                    let netAdvance = ShowNumber(CDbl(Number(d.BNet) + Number(d.ChargeVAT),2), 2);
                    data = data.replace('{0}', d.SDescription);
                    if (d.IsCredit == 1) {
                        data = data.replace('{1}', netAdvance);
                        sumclrAdv += Number(d.BNet) + Number(d.ChargeVAT);
                        sumClr += Number(d.BNet) + Number(d.ChargeVAT);
                    } else {
                        data = data.replace('{1}', '');
                    }
                    if (d.IsExpense == 1 && d.IsCredit==0) {
                        if (d.SlipNO == '') {
                            data = data.replace('{2}', '');
                            data = data.replace('{3}', netCharge);
                            sumclrCostNonSlip += d.BNet;
                        } else {
                            data = data.replace('{3}', '');
                            data = data.replace('{2}', netCharge);
                            sumclrCostSlip += d.BNet;
                        }
                        sumClr += Number(d.BNet) + Number(d.ChargeVAT);
                    } else {
                        data = data.replace('{2}', '');
                        data = data.replace('{3}', '');
                    }
                    if (d.IsExpense == 0 && d.IsCredit == 0) {
                        data = data.replace('{4}', netCharge);
                        data = data.replace('{5}', netCharge);
                        sumclrServ += d.BNet;
                        sumclrProfit += d.BNet;
                    } else {
                        data = data.replace('{4}', '');
                        if (d.IsCredit == 1) {
                            data = data.replace('{5}', '');
                        } else {
                            data = data.replace('{5}', ShowNumber(Number(d.BNet) * -1, 2));
                            sumclrProfit -= d.BNet;
                        }
                    }
                    $('#tbDetail').append(data);
                }
                $('#fldSumClr').html(ShowNumber(sumClr, 2));
                $('#fldSumClrAdv').html(ShowNumber(sumclrAdv, 2));
                $('#fldSumClrCostSlip').html(ShowNumber(sumclrCostSlip, 2));
                $('#fldSumClrCostNonSlip').html(ShowNumber(sumclrCostNonSlip, 2));
                $('#fldSumClrService').html(ShowNumber(sumclrServ, 2));
                $('#fldSumClrProfit').html(ShowNumber(sumclrProfit, 2));
                $.get(path + 'Adv/GetAdvanceReport?BranchCode=' + branch + '&JobNo=' + job).done(function (r) {
                    if (r.adv.data.length > 0) {
                        let dt = r.adv.data[0].Table;
                        for (let d of dt) {
                            sumAdv += d.AdvPayAmount;
                        }
                    }
                    $('#fldSumAdv').html(ShowNumber(sumAdv, 2));
                    $('#fldSumBal').html(ShowNumber(sumAdv - sumClr, 2));
                });
            }
        });
        $.get(path + 'JobOrder/GetJobSql?Branch=' + branch + '&JNo=' + job).done(function (r) {
            if (r.job.data.length > 0) {
                let dr = r.job.data[0];
                $('#dvDeclareNumber').html(CStr(dr.DeclareNumber));
                $('#dvMAWB').html(CStr(dr.MAWB));
                $('#dvJNo').html(CStr(dr.JNo));
                $('#dvCloseJobDate').html(ShowDate(dr.CloseJobDate));
                $('#dvETDDate').html(ShowDate(dr.ETDDate));
                $('#dvDelivery').html(CStr(dr.DeliveryTo));
                $('#dvProduct').html(CStr(dr.InvProduct));
                $('#dvTotalContainer').html(CStr(dr.TotalContainer));

                $.get(path + 'Master/GetUser?Code=' + dr.CSCode).done((r) => {
                    if (r.user.data.length > 0) {
                        let p = r.user.data[0];
                        $('#dvCSName').html(p.TName);
                    }
                });
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
    }
</script>

