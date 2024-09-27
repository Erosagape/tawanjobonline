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
<div style="display:flex;flex-direction:column" class="table">
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Job Date</b>
            <span id="dvJobDate"></span>
        </div>
        <div style="flex:1">
            <b>Shipping</b>
            <span id="dvShipping"></span>
        </div>
        <div style="flex:1">
            <b>Port</b>
            <span id="dvClearPort"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Job Number</b>
            <span id="dvJobNo"></span>
        </div>
        <div style="flex:1">
            <b>TP</b>
            <span id="dvPoNo"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Customer</b>
            <span id="dvCustomer"></span>
        </div>
        <div style="flex:1">
            <b>Im/Ex Name</b>
            <span id="dvConsignee"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Inv</b>
            <span id="dvCustInv"></span>
        </div>
        <div style="flex:1">
            <b>B/L,BKG</b>
            <span id="dvBooking"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>ETD</b>
            <span id="dvETDDate"></span>
        </div>
        <div style="flex:1">
            <b>ETA</b>
            <span id="dvETADate"></span>
        </div>
        <div style="flex:1">
            <b>Total Container</b>
            <span id="dvTotalContainer"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>QTY</b>
            <span id="dvInvProd"></span>
        </div>
        <div style="flex:1">
            <b>G.W.</b>
            <span id="dvGrossWeight"></span>
        </div>
        <div style="flex:1">
            <b>Measurement</b>
            <span id="dvMeasurement"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Receive D/O Date:</b>
            <span id="dvReadyClear"></span>
        </div>
        <div style="flex:1">
            <b>Receive Cheque Date:</b>
            <span id="dvChqDate"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Clearing Date:</b>
            <span id="dvClearDate"></span>
        </div>
        <div style="flex:1">
            <b>Delivery Date:</b>
            <span id="dvDeliveryDate"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Delivery To</b>
            <span id="dvDeliveryTo"></span>
        </div>
        <div style="flex:1">
            <b>Date</b>
            <span id="dvUnloadDate"></span>
        </div>
        <div style="flex:1">
            <b>Time</b>
            <span id="dvUnloadTime"></span>
        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            <b>Truck Company</b>
            <span id="dvTransport"></span>
        </div>
    </div>

    <table class="block" border="1">
        <tr>
            <td rowspan="2">
                Exchange Rate: <div id="dvInvCurRate"></div>
            </td>
            <td colspan="6" style="width:45%">
                COST
            </td>
            <td colspan="2" style="width:15%">SELLING</td>
            <td rowspan="2" colspan="2" style="width:15%">PROFIT</td>
        </tr>
        <tr>
            <td colspan="2" style="width:15%">
                CUSTOMER-SLIP
            </td>
            <td colspan="2" style="width:15%">
                COMPANY-SLIP
            </td>
            <td colspan="2" style="width:15%">
                NO-SLIP
            </td>
            <td colspan="2">
                SERVICES
            </td>
        </tr>
        <tbody>
            <tr>
                <td class="textleft">FREIGHT CHARGE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">CFS CHARGE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">THC CHARGE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">B/L FEE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">D/O FEE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">SEAL FEE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">STATUS</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">FACILITIES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">HANDLING</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">CUSTOMS FORMAILTY</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">SERVICE CHARGES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">TRANSPORTATION CHARGES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">LABOUR CHARGES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">CUSTOMS FEE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">CASHIER CHEQUE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">OVERTIME AGENT</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">OVERTIME PORT</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">CLEANING CONTAINER/FLOOR</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">TRUCKING PLANT</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">PROCURATION</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">PLANT CERFICATE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">PAPERLESS FEE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">PORT CHARGES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">STORAGE CHARGES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">DEMURRAGE/DETENTION CHARGES</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">RETURN EMPTY CONTAINER</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">KB TO CUSTOMER</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">REFUND FROM CARRIER</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">AGENT FEE</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft">OPERATION COSTS</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
            <tr>
                <td class="textleft" colspan="11">
                    REMARK
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="textright" colspan="9">NET PROFIT</td>
                <td class="textright" style="width:11%"></td>
                <td class="textright" style="width:4%"></td>
            </tr>
        </tbody>
    </table>
    <div class="block" style="display:flex;width:50%">
        <div style="flex:1">
            HANDLE BY:
        </div>
        <div  style="flex:2">

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
                $('#dvJobDate').html(ShowDate(dr.DocDate));
                $('#dvShipping').html(CStr(dr.ShippingEmp));
                $('#dvJobNo').html(CStr(dr.JNo));
                $('#dvPoNo').html(CStr(dr.CustRefNO));
                $('#dvCustInv').html(CStr(dr.InvNo));
                $('#dvBooking').html(CStr(dr.BookingNo));
                $('#dvETDDate').html(ShowDate(dr.ETDDate));
                $('#dvETADate').html(ShowDate(dr.ETADate));
                $('#dvTotalContainer').html(CStr(dr.TotalContainer));
                $('#dvInvProd').html(CStr(dr.InvProductQty + ' ' + dr.InvProductUnit));
                $('#dvGrossWeight').html(CStr(dr.TotalGW + ' ' + dr.GWUnit));
                $('#dvMeasurement').html(CStr(dr.Measurement));
                $('#dvReadyClear').html(ShowDate(dr.ReadyToClearDate));
                $('#dvChqDate').html(ShowDate(dr.ConfirmChqDate));
                $('#dvClearDate').html(ShowDate(dr.DutyDate));
                $('#dvDeliveryDate').html(ShowDate(dr.EstDeliverDate));
                $('#dvDeliveryTo').html(CStr(dr.DeliveryTo));
                $('#dvUnloadDate').html(ShowDate(dr.LoadDate));
                //$('#dvUnloadTime').html('');

                $.get(path + 'Master/GetCustomsPort?Code=' + dr.ClearPort).done((r) => {
                    if (r.RFARS.length > 0) {
                        let p = r.RFARS.data[0];
                        $('#dvClearPort').html(p.AreaName);
                    }
                });
                $.get(path + 'Master/GetCompany?Code=' + dr.CustCode + '&Branch=' + dr.CustBranch).done((r) => {
                    if (r.company.data.length > 0) {
                        let c = r.company.data[0];
                        $('#dvCustomer').html(CStr(c.NameEng));
                    }
                });
                $.get(path + 'Master/GetCompany?Code=' + dr.Consigneecode).done((r) => {
                    if (r.company.data.length > 0) {
                        let c = r.company.data[0];
                        $('#dvConsignee').html(CStr(c.NameEng));
                    }
                });
                $.get(path + 'Master/GetVender?Code=' + dr.AgentCode).done((r) => {
                    if (r.vender.data.length > 0) {
                        let c = r.vender.data[0];
                        $('#dvTransport').html(CStr(c.English));
                    }
                });
            }
        });
    }
</script>

