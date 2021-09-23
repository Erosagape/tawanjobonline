@Code
    ViewData("Title") = "Cheque Arrangement Form"
    Layout = "~/Views/Shared/_Report.vbhtml"
End Code
<style>
    #dvFooter, #pFooter {
        display: none;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    .block {
        border-left: solid;
        border-right: solid;
        border-top: solid;
        border-bottom: solid;
        border-width: thin;
        border-collapse: collapse;
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
<div style="width:100%;text-align:right">
        Voucher No : <label id="lblVoucherNo"></label>
</div>

<div style="display:flex;flex-direction:column">
    <div class="block" style="width:100%;text-align:center">
        Customer Name : <label id="lblCustomerName"></label>
    </div>
    <div class="block" style="width:100%;text-align:center">
        <label id="lblJobType"></label>/<label id="lblShipBy"></label>
    </div>
    <div style="width:100%;display:flex">
        <div class="block" style="flex:1;">
            VESSEL =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblMVesselName"></label>
        </div>
        <div class="block" style="flex:1;">
            INVOICE NO =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblInvNo"></label>
        </div>
    </div>
    <div style="width:100%;display:flex">
        <div class="block" style="flex:1;">
            B/L =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblBookingNo"></label>
        </div>
        <div class="block" style="flex:1;">
            JOB NO =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblJNo"></label>
        </div>
    </div>
    <div style="width:100%;display:flex">
        <div class="block" style="flex:1;">
            GROSS WEIGHT =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblGrossWeight"></label> &nbsp;
            <label id="lblWeightUnit"></label>
        </div>
        <div class="block" style="flex:1;">
            DATE =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblDocDate"></label>
        </div>
    </div>
    <div style="width:100%;display:flex">
        <div class="block" style="flex:1;">
            QTY =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblInvProductQty"></label> &nbsp;
            <label id="lblInvProductUnit"></label>
        </div>
        <div class="block" style="flex:1;">
            DESCRIPTION =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblInvProduct"></label>
        </div>
    </div>
    <div style="width:100%;display:flex">
        <div class="block" style="flex:1;">
            CONTAINER QTY =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblTotalContainer"></label>
        </div>
        <div class="block" style="flex:1;">
            ETA =
        </div>
        <div class="block" style="flex:2;">
            <label id="lblETADate"></label>
        </div>
    </div>
    <div style="width:100%;display:flex">
        <div class="block" style="flex:1;">
            CONTAINER LIST =
        </div>
        <div class="block" style="flex:5;">
            <div id="lblContainerList"></div>
        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block" style="flex:3;">
            Description
        </div>
        <div class="block" style="flex:1;">
            Qty
        </div>
        <div class="block" style="flex:1;">
            Cost Estimate
        </div>
        <div class="block" style="flex:1;">
            Real Cost
        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            D/O
        </div>
        <div class="block" style="flex:1;" id="qty1">

        </div>
        <div class="block textright" style="flex:1;" id="cost1">

        </div>
        <div class="block textright" style="flex:1;" id="real1">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            VAT
        </div>
        <div class="block" style="flex:1;" id="qty2">

        </div>
        <div class="block textright" style="flex:1;" id="cost2">

        </div>
        <div class="block textright" style="flex:1;" id="real2">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            DEMURRAGE
        </div>
        <div class="block" style="flex:1;" id="qty3">

        </div>
        <div class="block textright" style="flex:1;" id="cost3">

        </div>
        <div class="block textright" style="flex:1;" id="real3">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            STORAGE / RENT
        </div>
        <div class="block" style="flex:1;" id="qty4">

        </div>
        <div class="block textright" style="flex:1;" id="cost4">

        </div>
        <div class="block textright" style="flex:1;" id="real4">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            MOVEMENT
        </div>
        <div class="block" style="flex:1;" id="qty5">

        </div>
        <div class="block textright" style="flex:1;" id="cost5">

        </div>
        <div class="block textright" style="flex:1;" id="real5">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            RE-LOCATION
        </div>
        <div class="block" style="flex:1;" id="qty6">

        </div>
        <div class="block textright" style="flex:1;" id="cost6">

        </div>
        <div class="block textright" style="flex:1;" id="real6">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            LIFT-ON
        </div>
        <div class="block" style="flex:1;" id="qty7">

        </div>
        <div class="block textright" style="flex:1;" id="cost7">

        </div>
        <div class="block textright" style="flex:1;" id="real7">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            OVERTIME
        </div>
        <div class="block" style="flex:1;" id="qty8">

        </div>
        <div class="block textright" style="flex:1;" id="cost8">

        </div>
        <div class="block textright" style="flex:1;" id="real8">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            TARIFF
        </div>
        <div class="block" style="flex:1;" id="qty9">

        </div>
        <div class="block textright" style="flex:1;" id="cost9">

        </div>
        <div class="block textright" style="flex:1;" id="real9">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            DEPOSIT CONTAINER
        </div>
        <div class="block" style="flex:1;" id="qty10">

        </div>
        <div class="block textright" style="flex:1;" id="cost10">

        </div>
        <div class="block textright" style="flex:1;" id="real10">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            CLEANING CONTAINER
        </div>
        <div class="block" style="flex:1;" id="qty11">

        </div>
        <div class="block textright" style="flex:1;" id="cost11">

        </div>
        <div class="block textright" style="flex:1;" id="real11">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            CUSTOMS CLEARANCE (NON-RECEIPT)
        </div>
        <div class="block" style="flex:1;" id="qty12">

        </div>
        <div class="block textright" style="flex:1;" id="cost12">

        </div>
        <div class="block textright" style="flex:1;" id="real12">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            CUSTOMS CLEARANCE - DEPARTMENT OF AGRICULTURE (NON-RECEIPT)
        </div>
        <div class="block" style="flex:1;" id="qty13">

        </div>
        <div class="block textright" style="flex:1;" id="cost13">

        </div>
        <div class="block textright" style="flex:1;" id="real13">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            CUSTOMS CLEARANCE - DEPARTMENT OF FORESTRY (NON-RECEIPT)
        </div>
        <div class="block" style="flex:1;" id="qty14">

        </div>
        <div class="block textright" style="flex:1;" id="cost14">

        </div>
        <div class="block textright" style="flex:1;" id="real14">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            D/O DELAY
        </div>
        <div class="block" style="flex:1;" id="qty15">

        </div>
        <div class="block textright" style="flex:1;" id="cost15">

        </div>
        <div class="block textright" style="flex:1;" id="real15">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            GATE CHARGE / LIFT OFF
        </div>
        <div class="block" style="flex:1;" id="qty16">

        </div>
        <div class="block textright" style="flex:1;" id="cost16">

        </div>
        <div class="block textright" style="flex:1;" id="real16">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block textleft" style="flex:3;">
            D/O FEE (NON-RECEIPT)
        </div>
        <div class="block" style="flex:1;" id="qty17">

        </div>
        <div class="block textright" style="flex:1;" id="cost17">

        </div>
        <div class="block textright" style="flex:1;" id="real17">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block" style="flex:4;">
            TOTAL
        </div>
        <div class="block textright" style="flex:1;" id="costsum">

        </div>
        <div class="block textright" style="flex:1;" id="realsum">

        </div>
    </div>
    <div style="width:100%;display:flex;text-align:center">
        <div class="block" style="flex:1;">
            <br/><br /><br />
            (_______________________)<br/>
            Approve By
        </div>
        <div class="block" style="flex:1;">
            <br /><br /><br />
            (_______________________)<br />
            Received By
        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("BranchCode");
    let code = getQueryString("ControlNo");
    if (branch !== '' && code !== '') {
        $.get(path + 'Acc/GetVoucherGrid?Branch=' + branch + '&Code=' + code).done(function (r) {
            if (r.voucher.data.length > 0) {
                let h = r.voucher.data[0];
                $('#lblVoucherNo').text(h.ControlNo);
                $('#lblDocDate').text(ShowDate(h.VoucherDate));
                let jobno = '';
                let sumcost = 0;
                let sumreal = 0;

                for (let d of r.voucher.data[0].Table) {
                    for (let i = 1; i <= 17; i++) {
                        let codeCheck = '';
                        let SICode = d.SICode;
                        switch (i) {
                            case 1: // D/O
                                codeCheck = 'B-ADV-022';
                                break;
                            case 2:
                                codeCheck = 'B-ADV-018';
                                break;
                            case 3:
                                codeCheck = 'B-ADV-023';
                                break;
                            case 4:
                                codeCheck = 'B-ADV-052';
                                break;
                            case 5:
                                codeCheck = 'B-ADV-029';
                                break;
                            case 6:
                                codeCheck = 'B-ADV-047';
                                break;
                            case 7:
                                codeCheck = 'B-ADV-040';
                                break;
                            case 8:
                                codeCheck = 'B-ADV-020';
                                break;
                            case 9:
                                codeCheck = 'R-ADV-019';
                                break;
                            case 10:
                                codeCheck = 'B-DEP-001';
                                break;
                            case 11:
                                codeCheck = 'B-ADV-015';
                                break;
                            case 12:
                                codeCheck = 'E-CST-002,E-CST-003,E-CST-004';
                                break;
                            case 13:
                                codeCheck = '';
                                break;
                            case 14:
                                codeCheck = '';
                                break;
                            case 15:
                                codeCheck = '';
                                break;
                            case 16:
                                codeCheck = 'B-ADV-035,B-ADV-061';
                                break;
                            case 17:
                                codeCheck = 'B-ADV-006';
                                break;
                        }
                        if (SICode !== '') {
                            if (codeCheck.indexOf(SICode) >= 0 && codeCheck !== '') {
                                $('#qty' + i).text('1 SHP');
                                $('#cost' + i).text(ShowNumber(d.ChqAmount, 2));
                                $('#real' + i).text(ShowNumber(d.PaidTotal, 2));
                                sumcost += Number(d.ChqAmount);
                                sumreal += Number(d.PaidTotal);
                            }
                        }
                    }
                    $('#costsum').text(ShowNumber(sumcost, 2));
                    $('#realsum').text(ShowNumber(sumreal, 2));
                    if (jobno == '' && d.ForJNo !== '') {
                        jobno = d.ForJNo;
                        ReadJob(h.BranchCode, jobno);
                    }
                }
            }
        });
    }
    function ReadJob(branch, jno) {
        $.get(path + 'JobOrder/GetJobSQL?Branch' + branch + '&JNo=' + jno).done(function (r) {
            if (r.job.data.length > 0) {
                let j = r.job.data[0];
                ShowCustomerEN(path, j.CustCode, j.CustBranch, '#lblCustomerName');
                ShowJobTypeShipBy(path, j.JobType, j.ShipBy, j.JobStatus, '#lblJobType', '#lblShipBy', '');
                $('#lblMVesselName').text(j.MVesselName);
                $('#lblInvNo').text(j.InvNo);
                $('#lblBookingNo').text(j.BookingNo);
                $('#lblJNo').text(j.JNo);
                $('#lblGrossWeight').text(j.TotalGW);
                $('#lblWeightUnit').text(j.WeightUnit);
                $('#lblInvProduct').text(j.InvProduct);
                $('#lblInvProductQty').text(j.InvProductQty);
                $('#lblInvProductUnit').text(j.InvProductUnit);
                $('#lblTotalContainer').text(j.TotalContainer);
                $('#lblETADate').text(ShowDate(j.ETADate));

                ReadBooking(j.BranchCode, j.BookingNo);
            }
        });
    }
    function ReadBooking(branch, code) {
        $.get(path + 'JobOrder/GetTransport?Branch=' + branch + '&Code=' + code).done(function (r) {
            if (r.transport.detail.length > 0) {
                let str = '<table style="width:100%;"><tr>';
                let ctCount = 0;
                for (let d of r.transport.detail) {
                    ctCount += 1;
                    if (ctCount > 4) {
                        str += '</tr>';
                        str += '<tr>';
                        ctCount = 1;
                    }
                    str += '<td style="text-align:left;">No = '+ d.CTN_NO + '<br/>Date =' + ShowDate(d.UnloadDate)+ '</td>';
                }
                str += '</tr></table>';
                $('#lblContainerList').html(CStr(str));
            }
        });
    }
    

</script>