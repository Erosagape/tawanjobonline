@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Pre-invoice"
    ViewBag.ReportName = "Pre-invoice"
End Code
<div style="float:right">
    <b>Shipment No : </b><label id="lblJNo"></label>
    <br/>
    <b>Date : </b><label id="lblOpenDate"></label>
</div>
<div style="float:left">
    <b>Invoice To : </b><label id="lblCustName"></label>
    <br />
    <b>Address : </b><label id="lblCustAddress1"></label>
    <br /><label id="lblCustAddress2"></label>
</div>
<br/>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>ORIGIN : </b><label id="lblCountryPort"></label>
    </div>
    <div style="flex:1">
        <b>ETD :</b><label id="lblETDDate"></label>
    </div>
    <div style="flex:1">
        <b>ETA :</b><label id="lblETADate"></label>
    </div>
</div>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>VESSEL : </b><label id="lblVesselName"></label>
    </div>
    <div style="flex:2">
        <b>FEEDER/VOY : </b><label id="lblMVesselName"></label>
    </div>
</div>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>COMMODITY :</b><label id="lblInvProduct"></label>
    </div>
    <div style="flex:1">
        <b>QUANTITY :</b><label id="lblInvQty"></label> &nbsp; <label id="lblInvQtyUnit"></label>
    </div>
    <div style="flex:1">
        <b>CBM :</b><label id="lblMeasurement"></label>
    </div>
</div>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>B/L CHANGE : </b><label id="lblBLStatus"></label>
    </div>
    <div style="flex:1">
        <b>WEIGHT : </b><label id="lblGrossWeight"></label>
    </div>
    <div style="flex:1">
        <b>SHED : </b><label id="lblDeliveryTo"></label>
    </div>
</div>
<hr style="border-style:solid;" />
<div style="display:flex;text-align:center;">
    <div style="width:30%">
        <u><b>DESCRIPTION</b></u>
    </div>
    <div style="width:5%">
        <u><b>RATE</b></u>
    </div>
    <div style="width:15%">
        <u><b>CURRENCY</b></u>
    </div>
    <div style="width:20%">
        <u><b>QTY</b></u>
    </div>
    <div style="width:10%">
        <u><b>UNIT</b></u>
    </div>
    <div style="width:20%">
        <u><b>AMOUNT</b></u>
    </div>
</div>
<div style="height:250px" id="dvDetail">
</div>
<hr style="border-style:solid;" />
<div style="width:80%;text-align:right;float:left">
    <b>Amount:</b><br />
    <b>Vat:</b><br />
    <b>Total:</b><br />
</div>
<div style="width:20%;float:right;text-align:right;">
    <div style="display:block;width:100%">
        <label id="lblSumAmount"></label>
    </div>
    <div style="display:block;width:100%">
        <label id="lblSumVat"></label>
    </div>
    <div style="display:block;width:100%">
        <label id="lblSumTotal"></label>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let job = getQueryString("Job");
    $.get(path + 'Adv/GetClearExp?Branch=' + branch + '&Job=' + job).done(function (r) {
        if (r.estimate.data.length > 0) {
            let dr = r.estimate.data;
            CallBackQueryJob(path, branch, job, ReadJob);
            ReadData(dr);
        }
    });
    function ReadJob(dt) {
        let dr = {};
        if (dt.length > 0) {
            dr = dt[0];
        } else {
            return;
        }
        $('#lblETDDate').text(ShowDate(dr.ETDDate));
        $('#lblETADate').text(ShowDate(dr.ETADate));
        $('#lblVesselName').text(dr.VesselName);
        $('#lblMVesselName').text(dr.MVesselName);
        $('#lblInvProduct').text(dr.InvProduct);
        $('#lblInvQty').text(dr.InvProductQty);
        ShowInvUnit(path, dr.InvProductUnit, '#lblInvQtyUnit');
        $('#lblMeasurement').text(dr.Measurement);
        $('#lblBLStatus').text(dr.BookingNo);
        $('#lblGrossWeight').text(dr.TotalGW + ' ' + dr.GWUnit);
        $('#lblDeliveryTo').text(dr.ClearPortNo);

        CallBackQueryCustomer(path, dr.CustCode, dr.CustBranch, function (data) {
            $('#lblCustName').text(data.NameEng);
            $('#lblCustAddress1').text(data.EAddress1);
            $('#lblCustAddress2').text(data.EAddress2);
        });
    }
    function ReadData(dt) {
        let dr = {};
        if (dt.length > 0) {
            dr = dt[0];
        } else {
            return;
        }
        $('#lblJNo').text(dr.JNo);
        $('#lblOpenDate').text(ShowDate(GetToday()));
      
        let html = '';
        let totamt = 0;
        let totvat = 0;
        let total = 0;
        for (let r of dt) {
            html += '<div style="display:flex;width:100%">';
            html += '<div style="width:30%">'+ r.SDescription +'</div>';
            html += '<div style="width:5%">' + r.ExchangeRate + '</div>';
            html += '<div style="width:15%;text-align:center">' + r.CurrencyCode + '</div>';
            html += '<div style="width:20%;text-align:center">' + r.Qty + '</div>';
            html += '<div style="width:10%;text-align:center">' + r.QtyUnit + '</div>';
            html += '<div style="width:20%;text-align:right">' + CCurrency(CDbl(r.AmountCharge,2)) + '</div>';
            html += '</div>';

            totamt += CNum(r.AmountCharge);
            totvat += CNum(r.AmtVat);
            total += CNum(r.AmountCharge)+CNum(r.AmtVat);
        }
        $('#dvDetail').html(html);

        $('#lblSumAmount').text(CCurrency(CDbl(totamt,2)));
        $('#lblSumVat').text(CCurrency(CDbl(totvat,2)));
        $('#lblSumTotal').text(CCurrency(CDbl(total,2)));
    }
</script>