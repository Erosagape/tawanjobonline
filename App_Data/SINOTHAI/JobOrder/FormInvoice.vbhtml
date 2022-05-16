@Code
    ViewData("Title") = "FormInvoice"
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
End Code
<style>
    #pFooter,#dvFooter {
        display:none;
    }
</style>
<div style="float:right">
    Reference Number <span id="lblJNo">(Job Number)</span>
</div>
<br/>
<br/>
<p>
    Dear <span id="lblForwarder">(Agent/Forwarder)</span> Team,
    <br /><br />
    Please kindly create new booking for Vessel to <span id="lblClearPortNo">(Discharges Port)</span>
    as details below, Thank you.
    <br /><br />
    Start CY Container by truck at <span id="lblCYPlace">(CY Place)</span> : <span id="lblCYDate">(CY DAte)</span>
    <br />
    Return Container by truck at <span id="lblReturnPlace">(Return Place)</span> : <span id="lblReturnDate">(Return Date)</span>
    <br /><br />
    <b>Commodity : </b><span id="lblCommodity">(Products Description)</span>
    <br />
    <b>H.S. Code :</b><span id="lblHSCode">(H.S Code)</span>
    <br /><br />
    Shipper : <span id="lblShipperName">(Shipper/Consignee)</span>
    <br />
    Quantity : <span id="lblTotalContainer">(Total Container)</span>
    <br />
    Destination Port : <span id="lblDestinationPort">(Destination Port)</span>
    <br /><br />
    <b>Thank you and Best Regards</b>
    <br />
    <span id="lblCSName">(CS Name)</span>
    <br />booking@sinothai.com
    <br /><br />
    <span id="lblCSTel">(CS Tel)</span>
    <br />
    <b>SINO THAI LOGISTICS INTERNATIONAL CO.,LTD</b>
</p>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    if (br !== '' && doc !== '') {
        $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
            if (r.booking !== null) {
                let h = r.booking.data[0];
                $('#lblJNo').html(h.JNo);
                $('#lblForwarder').html(h.ForwarderName);
                $('#lblClearPortNo').html(h.ClearPortNo);
                $('#lblCYPlace').html(h.CYPlace);
                $('#lblCYDate').html(ShowDate(h.CYDate));
                $('#lblReturnPlace').html(h.PackingPlace);
                $('#lblReturnDate').html(ShowDate(h.ReturnDate));
                $('#lblCommodity').html(CStr(h.ProjectName));
                $('#lblHSCode').html(h.ShippingCmd);
                $('#lblShipperName').html(h.NotifyName);
                $('#lblTotalContainer').html(h.TotalContainer);
                $('#lblDestinationPort').html(h.FactoryPlace);
                $('#lblCSName').html(h.CSName);
                $('#lblCSTel').html(h.CSTel);
            }
        });
    }
</script>
