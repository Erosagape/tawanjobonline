
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation"
    ViewBag.Title = "BOOKING CONFIRMATION"
End Code
    <div style="display:flex">
        <div style="text-align:left;flex:1">
            <b>BOOKING NO:</b> <label id="lblBookingNo"></label>
        </div>
        <div style="text-align:right;flex:1">
            <b>DATE :</b> <label id="lblBookingDate"></label>            
            <br />
            <b>SHIPMENT NO:</b> <label id="lblJNo"></label>
        </div>
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
        <div style="display:flex">
            <div style="flex:1">
                <b>FEEDER / VOY :</b>
            </div>
            <div style="flex:2">
                <label id="lblVesselName"></label>
            </div>
            <div style="flex:1">
                <b>ETD DATE :</b><label id="lblETDDate"></label>
            </div>
            <div style="flex:1">
                <b>DEPARTURE PORT :</b> <label id="lblPortDeparture"></label>
            </div>
        </div>
        <br />
        <div style="display:flex">
            <div style="flex:1">
                <b>M.VESSEL / VOY :</b>
            </div>
            <div style="flex:2">
                <label id="lblMVesselName"></label>
            </div>
            <div style="flex:1">
                <b>ETA DATE :</b><label id="lblETADate"></label>
            </div>
            <div style="flex:2">
                <b>DESTINATION PORT :</b><label id="lblPortArrival"></label>
            </div>
        </div>
        <br />
        <b>VOLUME :</b><label id="lblTotalContainer"></label>
        <br />
        <b>QUANTITY : </b><label id="lblProductQty"></label> &nbsp; <label id="lblProductUnit"></label>
        <br />
        <b>CY DATE :</b> <label id="lblCYDate"></label>
        <br />
        <b>CY AT :</b> <label id="lblCYPlace"></label>
        <br />
        <b>RETURN DATE :</b> <label id="lblReturnDate"></label>
        <br />
        <b>RETURN AT :</b> <label id="lblReturnPlace"></label>
        <br />
        <b>CFS/LOADING DATE :</b> <label id="lblCFSDate"></label>
        <br />
        <b>CFS/LOADING AT :</b> <label id="lblCFSPlace"></label>
        <br />
        <b>LAST LOAD DATE :</b> <label id="lblClosingDate"></label>
        <br />
        <b>LAST LOAD AT :</b> <label id="lblClosingTime"></label>
        <br />
        <b>LINERS :</b> <label id="lblAgentName"></label>
        <br/>
        <b>SHIPPER LOAD:</b>
        <br />
        <label id="lblShipperName"></label>
        <br />
        <label id="lblShipperAddress1"></label>
        <br />
        <label id="lblShipperAddress2"></label>
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
            $('#lblJNo').text(h.JNo);
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ShipperName);
            $('#lblForwarderContact').text(h.CustContactName);
            $('#lblCSName').text(h.CSName);
            $('#lblProjectName').text(h.ProjectName);
            $('#lblAgentName').text(h.ForwarderName);
            $('#lblTotalContainer').text(h.TotalContainer);

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
            $('#lblMVesselName').text(h.MVesselName);

            $('#lblETDDate').text(ShowDate(h.ETDDate));
            $('#lblETADate').text(ShowDate(h.ETADate));

            if (h.TransMode.substr(0, 2) == 'CY') {
                $('#lblCYDate').text(ShowDate(h.CYDate));
                $('#lblCYPlace').text(h.CYPlace);
                $('#lblReturnDate').text(ShowDate(h.ReturnDate));
                $('#lblReturnPlace').text(h.ReturnPlace);

                $('#lblClosingDate').text(ShowDate(h.PackingDate));
                $('#lblClosingTime').text(ShowTime(h.PackingTime));
            } else {
                $('#lblCFSDate').text(ShowDate(h.PackingDate));
                $('#lblCFSPlace').text(h.PackingPlace);
                $('#lblClosingDate').text(ShowDate(h.CYDate));
                $('#lblClosingTime').text(ShowTime(h.CYTime));
            }
            
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(h.ShipperAddress1);
            $('#lblShipperAddress2').text(h.ShipperAddress2);

            let str = h.Remark;
            str += '\n RELEASE PORT ' + h.ClearPort + ' LOAD PORT ' + h.ClearPortNo;
            $('#dvRemark').html(CStr(str));
        }
    });
</script>
