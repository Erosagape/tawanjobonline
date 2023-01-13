
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation"
    ViewBag.Title = "BOOKING CONFIRMATION"
End Code
<style>
    #dvFooter {
        display: none;
    }

    td div h3 {
        display: none;
    }

    td {
        border: 0px;
        /*           border-color:transparent;
            background-color:white*/
    }
</style>

<table border="1" style="width:100%; border-collapse: collapse;">
    <tr>
        <td colspan="5" style="width: 100%; font-size: 25px; font-weight: bold; padding: 5px; border:1px solid black" align="center">
            BOOKING CONFIRMATION
        </td>
    </tr>
    <tr>
        <td style="width:25%">
            TO :
        </td>
        <td colspan="2" style="width:40%">
            <label id="lblShipperName"></label>
        </td>
        <td style="width:10%">
            DATE :
        </td>
        <td style="width:25%">
            <label id="lblBookingDate"></label>
        </td>
    </tr>
    <tr>
        <td>
            TEL :
        </td>
        <td colspan="2">
            <label id="lblShipperTel"></label>
        </td>
        <td>
            QUTN :
        </td>
        <td>
            <label id="lblQutn"></label>
        </td>
    </tr>
    <tr>
        <td>
            ATTN :
        </td>
        <td id="lblContactName" colspan="2">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            EMAIL :
        </td>
        <td colspan="2">
            <label id="lblShipperEMail"></label>
        </td>
        <td align="right">
            E-mail :
        </td>
        <td>
            support @@bftfreight.com
        </td>
    </tr>
</table>
<table border="1" style="width:100%; border-collapse: collapse;">
    <tr>
        <td style="width:25%">
            CARRIER BOOKING NO.
        </td>
        <td style="width:25%">
            <label id="lblBookingNo"></label>
        </td>
        <td style="width:25%">
            SHIPPING LINE :
        </td>
        <td style="width:25%">
            <label id="lblShipperName2"></label>
        </td>
    </tr>
    <tr>
        <td>
            VOLUME :
        </td>
        <td>
            <label id="lblTotalContainer"></label>
        </td>
        <td>
            LOADING TYPE :
        </td>
        <td>
            <label id="lblTransMode"></label>
        </td>
    </tr>
    <tr>
        <td>
            COMMODITY :
        </td>
        <td>
            <label id="lblInvProduct"></label>
        </td>
        <td>
            PLACE OF DELIVERY :
        </td>
        <td>
            <label id="lblPortArrival"></label>,<label id="lblCountry"></label>
        </td>
    </tr>
</table>
<table border="1" style="width:100%; border-collapse: collapse;">
    <tr>
        <td style="width:25%">
            PLACE OF RECEIPT :
        </td>
        <td style="width:25%">
            <label id="lblPackingPlace"></label>
        </td>
        <td style="width:25%">
            PORT OF LOADING :
        </td>
        <td style="width:25%">
            <label id="lblPortLoading"></label>
        </td>
    </tr>
    <tr>
        <td>
            ETD :
        </td>
        <td>
            <label id="lblETDDate"></label>
        </td>
        <td>
            DEST ETA :
        </td>
        <td>
            <label id="lblETADate"></label>
        </td>
    </tr>
    <tr>
        <td>
            FEEDER :
        </td>
        <td>
            <label id="lblVesselName"></label>
        </td>
        <td>
            MOTHER VESSEL :
        </td>
        <td>
            <label id="lblMVesselName"></label>
        </td>
    </tr>
</table>
<table border="1" style="width:100%; border-collapse: collapse;">
    <tr>
        <td style="width:25%">
            CFS OR CY DATE :
        </td>
        <td style="width:75%">
            <label id="lblCYDate"></label>
        </td>
    </tr>
    <tr>
        <td>
            CFS OR CY AT :
        </td>
        <td>
            <label id="lblCYAddress"></label>
        </td>
    </tr>
    <tr>
        <td>
            CTC :
        </td>
        <td>
            <label id="lblCYContact"></label>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            RN DATE :
        </td>
        <td>
            <label id="lblReturnDate"></label>
        </td>
    </tr>
    <tr>
        <td>
            RETURN AT :
        </td>
        <td>
            <label id="lblReturnAddress"></label>
        </td>
    </tr>
    <tr>
        <td>
            CTC :
        </td>
        <td>
            <label id="lblReturnContact"></label>
        </td>
    </tr>
</table>
<table border="1" style="width:100%; border-collapse: collapse;">
    <tr>
        <td style="width:25%">
            CLOSING DATE :
        </td>
        <td style="width:25%">
            <label id="lblClosingDate"></label>
        </td>
        <td style="width:25%">
            AT BEFORE :
        </td>
        <td style="width:25%">
            <label id="lblClosingTime"></label>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            FREIGHT PAYABLE :
        </td>
        <td>
            <label id="lblPaymentBy"></label>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            PAPER LESS CODE :
        </td>
        <td>
            <label id="lblCustomsCode"></label>
        </td>
        <td>
            VGM CUT OFF :
        </td>
        <td>
            <label id="lblVGMCutoff"></label> <label id="lblVGMTime"></label>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            SI CUT OFF :
        </td>
        <td>
            <label id="lblSICutoff"></label> <label id="lblSITime"></label>
        </td>
    </tr>
</table>
<table border="1" style="width:100%; border-collapse: collapse;">
    <tr>
        <td style="width:60%">
            NOTE : <div id="dvRemark"></div>
        </td>
    </tr>
    <tr>
        <td>
            <img src="~/resource/BFT.jpg" style="width:100%;padding:0px 20%" />
        </td>
        <td style="text-align:center">
            <span id="lblManagerName"></span>
            ........................................................................................<br />
            AUTHORIZED SIGNATURE
        </td>
    </tr>
    <tr>
        <td style="font-size:10px" colspan="2">
            Remark:-<br />
            A). Customer can revise volume / postpone shipment more than twice times, there will be amendment charge 50 USD <br />
            <br />
            B). THB 1,000 per TEU for failure to cancel booking 120 hrs prior feeder cut off at loading port.<br />
            <br />
            C). 100 USD/set for failure to submit shipping particular 48 hrs -2 days prior SI cut off time. The container will be shut out (for those booking which is missing S/I)<br /><br />
            D). USD 100/Set for failure to submit shipping particular 96 hrs -4 days (shipment involved with ENS /AMS /AFR submission) prior feeder cut off at loading port.<br />
            <br />
            E). Customer has to confirm Bill of Lading as per Deadline CFM BL and if have any amendment after deadline there will be amendment charge incur @@ THB 1500 per
            set but for Europe, USA, CA and CN that has to submit Manifest have, there will be amendment charge incur @@ THB 1500 per set and manifest amendment 50 USD<br />
            <br />
            F). If customer request to Re-issue/Re Print Bill of Lading, there is Re-Print fee @@ THB 1700
            <br />  <br />
            G). Customer should pick up B/L within 7 days after vessel departure otherwise there is Late pick up B/L fee THB 150<br />
        </td>
    </tr>
</table>

<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';

    $("#imgLogo").hide();
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $.get(path + 'JobOrder/getjobsql?Branch=' + br + '&jno=' + h.JNo).done(function (q) {
                $('#lblQutn').text(q.job.data[0].QNo);
            })

            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblShipperName2').text(h.CarrierName);
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

            $('#lblCYDate').text(ShowDate(h.CYDate));
            $('#lblCYAddress').text(h.CYAddress);
            $('#lblCYContact').text(h.CYContact);
         /*   if (h.TransMode.substr(0, 2) == 'CY') {*/
                $('#lblReturnDate').text(ShowDate(h.ReturnDate));
                $('#lblReturnAddress').text(h.FactoryAddress);
                $('#lblReturnContact').text(h.FactoryContact);
                $('#lblClosingPlace').text(h.EstDeliverDate);
                $('#lblClosingDate').text(ShowDate(h.FactoryDate));
                $('#lblClosingTime').text(ShowTime(h.FactoryTime));
            //} else {
            //    $('#lblClosingDate').text(ShowDate(h.PackingDate));
            //    $('#lblClosingTime').text(ShowTime(h.PackingTime));
            //}
            //ShowReleasePort(path, h.ClearPort, '#lblPortLoading');
            $("#lblPortLoading").text(h.FactoryPlace);
            $("#lblVGMCutoff").text(ShowDate(h.EstDeliverDate));
            $("#lblVGMTime").text(ShowTime(h.ConfirmChqDate));
            $("#lblSICutoff").text(ShowDate(h.LoadDate));
            $("#lblSITime").text(ShowTime(h.EstDeliverTime));
            $('#lblPackingPlace').text(h.CYPlace);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperContact').text(h.ShipperContact);
            $('#lblShipperTel').text(h.ShipperPhone);
            $('#lblContactName').text(h.ShipperFax);
            $('#lblShipperEMail').text(h.ShipperEMail);
            $('#lblCustomsCode').text(h.ClearPort);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblTransMode').text(h.TransMode);
            $('#lblManagerName').text(h.ManagerName);
            let str = h.Description;
            $('#dvRemark').html(CStr(str));
        }
    });
</script>
