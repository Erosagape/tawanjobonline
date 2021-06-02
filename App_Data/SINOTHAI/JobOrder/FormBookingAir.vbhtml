
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
<div style="text-align:right;width:100%">
    <b>SHIPMENT NO:</b> <label id="lblBookingNo"></label>
    <br/>
    <b>DATE :</b> <label id="lblBookingDate"></label>
</div>
<div style="width:100%">
    <b>TO :</b><label id="lblForwarderName"></label>
    <br />
    <b>ATTN : </b><label id="lblForwarderContact"></label>
    <br />
    <b>FROM : </b><label id="lblCSName"></label>
    <br />
    <b>SUBJECT : </b><label id="lblProjectName"></label>
    <br />
    <b>DEPARTURE PORT :</b> <label id="lblPortDeparture"></label>
    <br />
    <b>DESTINATION PORT :</b><label id="lblPortArrival"></label>
    <br />
    <b>COMMODITY : </b><label id="lblProduct"></label>
    <br />
    <b>PIECES : </b><label id="lblProductQty"></label> &nbsp; <label id="lblProductUnit"></label>
    <br />
    <div style="display:flex">
        <div style="flex:1">
            <b>GROSS WEIGHT :</b><label id="lblTotalGW"></label> &nbsp; <label id="lblGWUnit"></label>
            <br />
            <b>FLIGHT NO :</b><label id="lblVesselName"></label>
            <br />
            <b>ETD DATE :</b><label id="lblETDDate"></label>
            <br />
            <b>ETA DATE :</b><label id="lblETADate"></label>
            <br />
            <b>PICKUP DATE:</b><label id="lblPickupDate"></label>
        </div>
        <div style="flex:1">
            <b>VOLUME WEIGHT : </b><label id="lblMeasurement"></label>
            <br />
            <b>CNX FLIGHT NO : </b><label id="lblMVesselName"></label>
            <br />
            <b>ETD TIME :</b> <label id="lblETDTime"></label>
            <br />
            <b>ETA TIME :</b> <label id="lblETATime"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>MAWB NO :</b> <label id="lblMAWB"></label>
        </div>
        <div style="flex:1">
            <b>HAWB NO :</b><label id="lblHAWB"></label>
        </div>
    </div>
    <b>SHIPPER:</b>
    <br />
    <label id="lblShipperName"></label>
    <br />
    <label id="lblShipperAddress1"></label>
    <br />
    <label id="lblShipperAddress2"></label>
    <br />
    <b>CONSIGNEE:</b>
    <br />
    <label id="lblConsigneeName"></label>
    <br />
    <label id="lblConsignAddress1"></label>
    <br />
    <label id="lblConsignAddress2"></label>
    <br />
    <b>REMARK:</b>
    <br />
    <div id="dvRemark"></div>
    <br />
    <br />
    hope you have been well informed, For further info or inquiry you may require, please feel free to contact us.
    <br />
    <br />
    THANK YOU AND BEST REGARDS,
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
            $('#lblBookingNo').text(h.JNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ShipperName);
            $('#lblForwarderContact').text(h.CustContactName);
            $('#lblCSName').text(h.CSName);
            $('#lblProjectName').text(h.ProjectName);
            $('#lblProduct').text(h.InvProduct);
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblPortDeparture');
                ShowReleasePort(path, h.ClearPort, '#lblPortArrival');
            } else {
                ShowReleasePort(path, h.ClearPort, '#lblPortDeparture');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblPortArrival');
            }
            $('#lblProductQty').text(h.InvProductQty);
            ShowInvUnit(path, h.InvProductUnit, '#lblProductUnit');
            $('#lblTotalGW').text(h.TotalGW);
            ShowInvUnit(path, h.GWUnit, '#lblGWUnit');
            $('#lblVesselName').text(h.VesselName);
            $('#lblETDDate').text(ShowDate(h.PackingDate));
            $('#lblETADate').text(ShowDate(h.FactoryDate));
            $('#lblPickupDate').text(ShowDate(h.CYDate));
            $('#lblMeasurement').text(h.TotalM3);
            $('#lblMVesselName').text(h.MVesselName);
            $('#lblETDTime').text(ShowTime(h.PackingTime));
            $('#lblETATime').text(ShowTime(h.FactoryTime));
            $('#lblHAWB').text(h.HAWB);
            $('#lblMAWB').text(h.MAWB);

            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(h.ShipperAddress1);
            $('#lblShipperAddress2').text(h.ShipperAddress2);
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress1').text(h.ConsignAddress1);
            $('#lblConsignAddress2').text(h.ConsignAddress2);
            
            $('#dvRemark').html(CStr(h.Remark));
        }
    });
</script>
