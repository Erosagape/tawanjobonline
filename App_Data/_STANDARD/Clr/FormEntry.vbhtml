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
    <table class="block" border="1">
        <tr>
            <td>DESCRIPTION</td>
            <td>WEIGHT</td>
            <td>CBM(M3)</td>
            <td>CONTAINER</td>
        </tr>
        <tbody>
            <tr>
                <td id="dvProduct"></td>
                <td id="dvGrossWeight"></td>
                <td id="dvMeasurement"></td>
                <td id="dvTotalContainer"></td>
            </tr>
        </tbody>
    </table>
    <table class="block" border="1">
        <tr>
            <td rowspan="2">
                Exchange Rate: <div id="dvInvCurRate"></div>
            </td>
            <td colspan="3">
                COST
            </td>
            <td>SELLING</td>
            <td rowspan="2">PROFIT</td>
        </tr>
        <tr>
            <td>
                CUSTOMER-SLIP
            </td>
            <td>
                COMPANY-SLIP
            </td>
            <td>
                NO-SLIP
            </td>
            <td>
                SERVICES
            </td>
        </tr>
        <tbody>
            <tr>
                <td class="textleft">FREIGHT CHARGE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">CFS CHARGE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">THC CHARGE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">B/L FEE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">D/O FEE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">SEAL FEE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">STATUS</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">FACILITIES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">HANDLING</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">CUSTOMS FORMAILTY</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">SERVICE CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">TRANSPORTATION CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">LABOUR CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">CUSTOMS FEE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">CASHIER CHEQUE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">OVERTIME AGENT</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">OVERTIME PORT</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">CLEANING CONTAINER/FLOOR</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">TRUCKING PLANT</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">PROCURATION</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">PLANT CERFICATE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">PAPERLESS FEE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">PORT CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">STORAGE CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">DEMURRAGE/DETENTION CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">RETURN EMPTY CONTAINER</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">KB TO CUSTOMER</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">REFUND FROM CARRIER</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">AGENT FEE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">OPERATION COSTS</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft" colspan="6">REMARK</td>
            </tr>
            <tr>
                <td class="textright" colspan="5">NET PROFIT</td>
                <td class="textright"></td>
            </tr>
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
    }
</script>

