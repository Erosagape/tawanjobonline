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
            
        </div>
        <div   style="flex:2">

        </div>
    </div>
    <table border="1">
        <thead>
            <tr>
                <th rowspan="2">ADV NO</th>
                <th rowspan="2">CLEAR NO</th>
                <th rowspan="2">DESCRIPTION</th>
                <th rowspan="2">AMOUNT</th>
            </tr>
        </thead>
        <tbody id="tb">
        </tbody>
        @*<tfoot>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align: right" colspan="2"></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align: right" colspan="2"></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align: right" colspan="2"></td>
            </tr>
            <tr>
                <td colspan="7"></td>
            </tr>
        </tfoot>*@
    </table>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("BranchCode");
    let job = getQueryString("JNo");
    let sService = 0;
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
                //$("#sumService").text(CCurrency(CDbl(dr.DutyCustPayOtherAmt, 2)));
                sService = parseFloat(dr.DutyCustPayOtherAmt);
              
                if (dr.Description) {
                    console.log(dr.Description);
                    let remarks = dr.Description.split("/");
                    $('#remark1').text(remarks[0]);
                    $('#remark2').text(remarks[1]);              
                }
               
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
                getClearIngReport();
                GetChequeInfo(branch, job);
            }
        });

        
    }

    function getClearIngReport() {
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

                let h = r.data[0];

                commrate = h.Commission;

                //let d = r.data.filter(function (data) {
                //    return data.BNet !== 0 && data.AdvNO !== "";
                //});
		let d = r.data.filter(data => data.BNet !== 0 && data.AdvNO !== "")
			.sort((a, b) =>{
			if (a.AdvNO === b.AdvNO) {
				return a.AdvItemNo - b.AdvItemNo;
			}
			return a.AdvNO.localeCompare(b.AdvNO);
		});
                //console.log(JSON.stringify(d));
                let customerSlipSum = 0;
                let companySlipSum = 0;
                let noSlipSum = 0;
                let servSum = 0;
                let profitSum = 0;
		let currentAdvNo = '';
		let sumClrNet = 0;

		let currentAdvNet = 0;
                for (let i = 0; i < d.length; i++) {
                        let html = '';
			
    			let advKey = d[i].AdvNO + '#' + d[i].AdvItemNo;

    			if (currentAdvNo !== '' && currentAdvNo !== advKey) {
				let balance = currentAdvNet - sumClrNet;
        			html += '<tr style="font-weight:bold;background:#f5f5f5">';
        			html += '<td colspan="3" style="text-align:right">TOTAL</td>';
        			html += '<td style="text-align:right">' + CCurrency(CDbl(balance,2)) + '</td>';
        			html += '</tr>';

        			sumClrNet = 0;
    			}

    			if (currentAdvNo !== advKey) {

        			currentAdvNo = advKey;
				currentAdvNet = d[i].AdvNet;
       				html += '<tr>';
        			html += '<td colspan="2" style="font-weight:bold;background:#f5f5f5">' + advKey + ' Request By : ' + d[i].AdvReqBy + '</td>';
        			html += '<td style="background:#f5f5f5">' + (d[i].AdvSICode != '' ? '[' + d[i].AdvSICode + '] ' : '') + d[i].AdvDesc + '</td>';
        			html += '<td style="background:#f5f5f5">' + CCurrency(CDbl(d[i].AdvNet,2)) + '</td>';
        			html += '</tr>';
    			}

    			html += '<tr>';
    			html += '<td></td>';
    			html += '<td>' + d[i].ClrNo + '#' + d[i].ItemNo + '</td>';
    			html += '<td>[' + d[i].SICode + '] ' + d[i].SDescription + '</td>';
    			html += '<td style="text-align:right">' + CCurrency(CDbl(d[i].ClrNet,2)) + '</td>';
    			html += '</tr>';
			
			sumClrNet += d[i].ClrNet;

    			if (i === d.length - 1) {
				let balance = currentAdvNet - sumClrNet;
        			html += '<tr style="font-weight:bold;background:#f5f5f5">';
        			html += '<td colspan="3" style="text-align:right">TOTAL</td>';
        			html += '<td style="text-align:right">' + CCurrency(CDbl(balance,2)) + '</td>';
        			html += '</tr>';
    			}			
    			tb.append(html);
                }
                /*let summary = ` <tr>
               <td></td>
               <td></td>
	       <td style="text-align:right">${servSum != 0 ? CCurrency(CDbl(servSum, 2)) : ""}</td>
           	</tr >`;
                tb.append(summary);
		$("#sumService").text(CCurrency(CDbl(servSum, 2)));
                $("#sumCost").text(CCurrency(CDbl(customerSlipSum + noSlipSum, 2)));
                $("#sumBalance").text(CCurrency(CDbl(servSum - (customerSlipSum + noSlipSum),2)));*/
            }
        });
    }
    function GetChequeInfo(branch, code) {
        $.get(path + 'acc/getvouchergrid?branch=' + branch + '&job=' + code + '&type=CHQP', function (r) {
            if (r.voucher.data.length > 0) {
                let dv = $('#dvCheque');
                dv.empty();
                let totalChq = 0;
                for (o of r.voucher.data) {
                    let html = '';

                    html += '<tr>';
                    html += '<td>' + o.ChqNo + '</td>';
                    html += '<td>' + o.BankCode + ' สาขา ' + o.BankBranch + '</td>';
                    html += '<td>' + ShowDate(CDateTH(o.ChqDate)) + '</td>';
                    html += '<td style="text-align:right">' + CCurrency(CDbl(o.ChqAmount, 2)) + '</td>';                    
                    html += '<td>' + o.DRemark + '</td>';
                    html += '</tr>';
                    totalChq += Number(o.ChqAmount);
                    dv.append(html);
                }
                $('#totalChq').text(CCurrency(CDbl(totalChq,2)));
            }
        });
    }
</script>

