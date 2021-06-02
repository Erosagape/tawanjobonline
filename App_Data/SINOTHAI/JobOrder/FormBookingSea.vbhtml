
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation"
    ViewBag.Title = "BOOKING CONFIRMATION"
End Code
<style>
    #dvFooter {
        display:none;
    }
    * {
        font-size: 13px;
    }
</style>
    <div style="display:flex;font-size:14px">
        <div style="text-align:left;flex:1">
            <b>TO :</b><label id="lblShipperName"></label>
            <br />
            <b>AN : </b><label id="lblShipperContact"></label>
        </div>
        <div style="text-align:right;flex:1">
            <b>DATE :</b> <label id="lblBookingDate"></label>
            <br />
            <b>TEL : </b><label id="lblShipperTel"></label>
            <br />
            <b>FAX : </b><label id="lblShipperFax"></label>
            <br />
            <b>EMAIL : </b><label id="lblShipperEMail"></label>
        </div>
    </div>
    <div style="width:100%;font-size:14px">
        <br />
        <b>BOOKING NO:</b> <label id="lblBookingNo"></label>
        <br />
        <b>SHIPPER LOAD:</b> <label id="lblShipperName2"></label>
        <br />
        <b>PORT OF RECEIPT :</b> <label id="lblPackingPlace"></label>
        <br />
        <b>PORT OF LOADING :</b> <label id="lblPortLoading"></label>
        <br />
        <b>PLACE OF DELIVERY :</b> <label id="lblPortArrival"></label>,<label id="lblCountry"></label>
        <br />
        <b>CLOSING DATE :</b><label id="lblClosingDate"></label> <b> CLOSING TIME </b> <label id="lblClosingTime"></label>
        <b>AT :</b><label id="lblClosingPlace"></label>
        <br />
        <b>ETD DATE :</b><label id="lblETDDate"></label>
        <br />
        <b>ETA DATE :</b><label id="lblETADate"></label>
        <br />
        <b>VOLUME :</b><label id="lblTotalContainer"></label>
        <br />
        <b>QUANTITY : </b><label id="lblProductQty"></label> &nbsp; <label id="lblProductUnit"></label>
        <br />
        <b>COMMODITY :</b> <label id="lblInvProduct"></label>
        <br />
        <b>MOTHER VESSEL / VOY :</b> <label id="lblMVesselName"></label>
        <br />
        <b>FEEDER VESSEL / VOY :</b> <label id="lblVesselName"></label>
        <br />
        <b>CARRIER :</b> <label id="lblAgentName"></label>
        <br />
        <div style="display:flex">
            <div>
                <b>CY AT :</b><label id="lblCYDate"></label> <b>AT</b> &nbsp; &nbsp;
            </div>
            <div>
                <label id="lblCYPlace"></label>
                <br />
                <label id="lblCYContact"></label>
            </div>
        </div>
        <br />
        <div style="display:flex">
            <div>
                <b>CFS/LOADING AT :</b><label id="lblCFSDate"></label> <b>AT</b> &nbsp; &nbsp;
            </div>
            <div>
                <label id="lblCFSPlace"></label>
                <br />
                <label id="lblCFSContact"></label>
            </div>
        </div>
        <br />
        <div style="display:flex">
            <div>
                <b>RETURN AT :</b><label id="lblReturnDate"></label> <b>AT</b> &nbsp; &nbsp;
            </div>
            <div>
                <label id="lblReturnPlace"></label>
                <br />
                <label id="lblReturnContact"></label>
            </div>
        </div>
        <br />
        <b>PAPERLESS :</b> <label id="lblCustomsCode"></label>
        <br />
        <b>REMARK:</b> <div id="dvRemark"></div>
        <br />
        <br />
        <br />
        <br />
    </div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];

            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblShipperName2').text(h.ShipperName);
            $('#lblAgentName').text(h.ForwarderName);
            $('#lblTotalContainer').text(h.TotalContainer);

            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblPortArrival');
                ShowCountry(path, h.InvFCountry, '#lblCountry');
            } else {
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblPortArrival');
                ShowCountry(path, h.InvCountry, '#lblCountry');
            }
            $('#lblProductQty').text(h.InvProductQty);
            $('#lblInvProduct').text(h.InvProduct);
            ShowInvUnit(path, h.InvProductUnit, '#lblProductUnit');
            $('#lblTotalGW').text(h.TotalGW);
            ShowInvUnit(path, h.GWUnit, '#lblGWUnit');

            $('#lblVesselName').text(h.VesselName);
            $('#lblMVesselName').text(h.MVesselName);

            $('#lblETDDate').text(ShowDate(h.ETDDate));
            $('#lblETADate').text(ShowDate(h.ETADate));

            if (h.TransMode.substr(0, 2) == 'CY') {
                $('#lblCYDate').text(ShowDate(h.CYDate));
                $('#lblCYPlace').text(h.CYPlace);
                $('#lblCYContact').text(h.CYContact);
                $('#lblReturnDate').text(ShowDate(h.ReturnDate));
                $('#lblReturnPlace').text(h.ReturnPlace);
                $('#lblReturnContact').text(h.ReturnContact);
                $('#lblClosingPlace').text(h.ReturnPlace);
                $('#lblClosingDate').text(ShowDate(h.PackingDate));
                $('#lblClosingTime').text(ShowTime(h.PackingTime));
            } else {
                $('#lblCFSDate').text(ShowDate(h.CYDate));
                $('#lblCFSPlace').text(h.CYPlace);
                $('#lblCFSContact').text(h.CYContact);
                $('#lblClosingDate').text(ShowDate(h.PackingDate));
                $('#lblClosingTime').text(ShowTime(h.PackingTime));
            }
            ShowReleasePort(path, h.ClearPort, '#lblPortLoading');
            $('#lblPackingPlace').text(h.PackingPlace);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperContact').text(h.ShipperContact);
            $('#lblShipperTel').text(h.ShipperPhone);
            $('#lblShipperFax').text(h.ShipperFax);
            $('#lblShipperEMail').text(h.ShipperEMail);
            $('#lblCustomsCode').text(h.ClearPort);
            let str = h.Description;
            $('#dvRemark').html(CStr(str));
        }
    });
</script>
