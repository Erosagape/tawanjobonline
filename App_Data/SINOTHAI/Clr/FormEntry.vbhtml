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
            COMMERCIAL INVOICE:
        </div>
        <div id="dvInvNo" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            JOB NO:
        </div>
        <div id="dvJNo" class="underline" style="flex:2">

        </div>

    </div>
    <div class="block" style="width:100%;display:flex;flex-direction:row">
        <div style="flex:1">
            SHIPPER/CONSIGNEE:
        </div>
        <div id="dvConsignee" class="underline" style="flex:5">

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
            ETA DATE:
        </div>
        <div id="dvETADate" class="underline" style="flex:2">

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
                <td class="textleft">CUSTOMS TAX</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">D/O CHARGE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">DEPOSIT</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">CUSTOMS SERVICE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">OT CUSTOMS</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">RENT</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">Department of Agriculture</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">Royal forest Department</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">OTHER CHARGES</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">RETURN CONTAINER</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">TRANSPORT CHARGE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">SHIPPING CHARGE</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">SHIPPING BANGPU</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">OT SHIPPING BANGPU</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft">INSPECTION</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft"><br /></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft"><br /></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft"><br /></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft"><br /></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textright">TOTAL</td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
                <td class="textright"></td>
            </tr>
            <tr>
                <td class="textleft" colspan="6">REMARK</td>
            </tr>
        </tbody>
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
                    <label id="lblReqBy" style="font-size:10px">(__________________)</label>
                    <br />
                    Import Manager
                    <br />
                    <label id="lblRequestDate" style="font-size:9px">__/__/____</label>
                </td>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
                    <label id="lblCheckBy" style="font-size:9px">( Paruhas Boonpamorn )</label>
                    <br />
                    General Manager
                    <br />
                    <label id="lblCheckDate" style="font-size:9px">__/__/____</label>
                </td>
                <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
                    <label id="lblAppBy" style="font-size:10px">( Yingqing Pan )</label>
                    <br />
                    Managing Director
                    <br />
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
    if (branch !== job && job !== '') {
        $.get(path + 'JobOrder/GetJobSql?Branch=' + branch + '&JNo=' + job).done(function (r) {
            if (r.job.data.length > 0) {
                let dr = r.job.data[0];
                $('#dvDeclareNumber').html(CStr(dr.DeclareNumber));
                $('#dvMAWB').html(CStr(dr.MAWB));
                $('#dvJNo').html(CStr(dr.JNo));
                $('#dvInvNo').html(CStr(dr.InvNo));
                $('#dvCloseJobDate').html(ShowDate(dr.CloseJobDate));
                $('#dvETADate').html(ShowDate(dr.ETADate));                
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

