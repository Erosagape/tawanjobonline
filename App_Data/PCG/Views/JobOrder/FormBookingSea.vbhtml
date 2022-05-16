
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation Form"
    ViewBag.Title = "BOOKING CONFIRMATION"
End Code
<style>
    #dvFooter {
        display: none;
    }

    td {
        vertical-align: top;
    }
</style>
<table style="width:100%">
    <tbody>
        <tr>
            <td style="width:25%"><b>TO </b></td>
            <td>:</td>
            <td style="width:25%" id="lblShipperName"></td>
            <td style="width:10%"></td>
            <td style="width:15%"><b>FROM </b></td>
            <td>:</td>
            <td style="width:25%">UNITED GLOBE</td>
        </tr>
        <tr>
            <td> <b>ATTN  </b></td>
            <td>:</td>
            <td id="lblShipperContact"></td>
            <td></td>
            <td><b>ATTN </b></td>
            <td>:</td>
            <td id="lblCSName"></td>
        </tr>
        <tr>
            <td> <b>TEL  </b></td>
            <td>:</td>
            <td id="lblShipperTel"></td>
            <td></td>
            <td> <b>TEL  </b></td>
            <td>:</td>
            <td> @ViewBag.PROFILE_COMPANY_TEL</td>
        </tr>
        <tr>
            <td> <b>FAX </b></td>
            <td>:</td>
            <td id="lblShipperFax"></td>
            <td></td>
            <td> <b>FAX  </b></td>
            <td>:</td>
            <td> @ViewBag.PROFILE_COMPANY_FAX</td>
        </tr>
        <tr>
            <td> <b>EMAIL </b></td>
            <td>:</td>
            <td id="lblShipperMail"></td>
            <td></td>
            <td> <b>EMAIL  </b></td>
            <td>:</td>
            <td id="lblCSMail"></td>
        </tr>
        <tr> </tr>
        <tr>
            <td> <b>DATE OF BOOKING</b></td>
            <td>:</td>
            <td colspan="5" id="lblBookingDate"></td>
        </tr>
        <tr>
            <td colspan="7">
                Private & Confidential - Ocean Freight Rate (Booking Confirm)<br />
                FURTHER TO YOUR BOOKING OF THE BELOW SHIPMENT PLEASE FIND THE FOLLOWING  DETAILS FOR YOUR KIND REFERENCE :-
                <br />
            </td>
        </tr>
        <tr>
            <td> <b>Subject</b></td>
            <td>:</td>
            <td colspan="5"></td>
        </tr>



        <tr>
            <td> <b>SHIPPER</b></td>
            <td>:</td>
            <td colspan="5" id="lblShipperName2"></td>
        </tr>
        <tr>
            <td> <b>PORT OF LOADING</b></td>
            <td>:</td>
            <td colspan="5" id="lblPortLoading"></td>
        </tr>
        <tr>
            <td> <b>PORT OF DELIVERY</b></td>
            <td>:</td>
            <td colspan="5" id="lblPortArrival"></td>
        </tr>
        <tr>
            <td> <b>QUANTITY</b></td>
            <td>:</td>
            <td colspan="5" id="lblProductQty"></td>
        </tr>
        <tr>
            <td> <b>OCEAN FREIGHT CHARGE</b></td>
            <td>:</td>
            <td colspan="5"></td>
        </tr>
        <tr>
            <td> <b>FEEDER/VESSEL</b></td>
            <td>:</td>
            <td colspan="5" id="lblVesselName"></td>
        </tr>
        <tr>
            <td> <b>MOTHER VESSEL</b></td>
            <td>:</td>
            <td colspan="5" id="lblMVesselName"></td>
        </tr>
        <tr>
            <td> <b>ETD ORIGIN</b></td>
            <td>:</td>
            <td colspan="5" id="lblETDDate"></td>
        </tr>
        <tr>
            <td> <b>ETA FINAL DESTINATION</b></td>
            <td>:</td>
            <td colspan="5" id="lblETADate"></td>
        </tr>
        <tr>
            <td> <b>BOOKING REF NO</b></td>
            <td>:</td>
            <td colspan="5" id="lblBookingNo"></td>
        </tr>

        <tr>
            <td> <b>AGENT</b></td>
            <td>:</td>
            <td colspan="5" id="lblAgentName"></td>
        </tr>
        <tr>
            <td> <b>PAPERLESS CODE</b></td>
            <td>:</td>
            <td colspan="5" id="lblCustomsCode"></td>
        </tr>
        <tr>
            <td> <b>CY YARD LOCATION</b></td>
            <td>:</td>
            <td colspan="5">
                <label id="lblCYPlace"></label>
                <label id="lblCYContact"></label>
            </td>
        </tr>
        <tr>
            <td> <b>CY DATE</b></td>
            <td>:</td>
            <td colspan="5" id="lblCYDate"></td>
        </tr>
        <tr>
            <td> <b>RTN YARD LOCATION</b></td>
            <td>:</td>
            <td colspan="5">
                <label id="lblReturnPlace"></label>
                <label id="lblReturnContact"></label>
            </td>
        </tr>
        <tr>
            <td> <b>RETURN DATE</b></td>
            <td>:</td>
            <td colspan="5" id="lblReturnDate"></td>
        </tr>

        <tr>
            <td> <b>CUT - OFF DATE & TIME</b></td>
            <td>:</td>
            <td colspan="5" id="lblCloseDatetime"></td>
        </tr>
        <tr>
            <td> <b>Doc Cut-off</b></td>
            <td>:</td>
            <td colspan="5"> <label id="lblSICutoff"></label><label id="lblVGMCutoff"></label></td>
        </tr>
        <tr>
            <td> <b>REMARK</b></td>
            <td>:</td>
            <td colspan="5" id="lblRemark"></td>
        </tr>
        <tr>
            <td colspan="7">
                If you have any further questions  or queries.please don't hesitate to contact us. We are greatful for your kind consideration.
                <br />Yours sincerely,
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <br /><br /><br /><br />
                ________________________________
                <br />Chatweeraya W.
                <br />UNITED GLOBE LOGISTICS (THAILAND) CO.,LTD.
            </td>
            <td colspan="3">
                <br /><br /><br /><br />
                ________________________________

            </td>
        </tr>
    </tbody>
</table>

@*<div style="display:flex;font-size:14px">

        <div style="text-align:left;flex:1;">
            <b>TO :</b><label id="lblShipperName"></label>
            <br />
            <b>AN : </b><label id="lblShipperContact"></label>
            <br />
            <b>TEL : </b><label id="lblShipperTel"></label>
            <br />
            <b>FAX : </b><label id="lblShipperFax"></label>
            <br />
            <b>EMAIL : </b><label id="lblShipperEMail"></label>
        </div>
        <div style="text-align:right;flex:1">
            <b>TO :</b><label id="lblShipperName"></label>
            <br />
            <b>AN : </b><label id="lblShipperContact"></label>

            <br />
            <b>TEL : </b><label id="lblShipperTel"></label>
            <br />
            <b>FAX : </b><label id="lblShipperFax"></label>
            <br />
            <b>EMAIL : </b><label id="lblShipperEMail"></label>
        </div>
    </div>
    <div style="width:100%;font-size:14px">
        Private & Confidential - Ocean Freight Rate (Booking Confirm)<br />
        FURTHER TO YOUR BOOKING OF THE BELOW SHIPMENT PLEASE FIND THE FOLLOWING  DETAILS FOR YOUR KIND REFERENCE :-
        <br />
        Subject        :
    </div>
    <div style="width:100%;font-size:14px">
        <b>DATE :</b> <label id="lblBookingDate"></label>
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
        <b>QUANTITY : </b><label id="lblProductQty"></label> &nbsp; <label id="lblProductUnit"></label>
        <br />

        <br />

        <b>VOLUME :</b><label id="lblTotalContainer"></label>
        <br />

        <b>COMMODITY :</b> <label id="lblInvProduct"></label>
        <br />
        <b>MOTHER VESSEL / VOY :</b> <label id="lblMVesselName"></label>
        <br />
        <b>FEEDER VESSEL / VOY :</b> <label id="lblVesselName"></label>
        <br />
        <b>ETD DATE :</b><label id="lblETDDate"></label>
        <br />
        <b>ETA DATE :</b><label id="lblETADate"></label>
        <br />
        <b>AGENT :</b> <label id="lblAgentName"></label>
        <br />
        <b>PAPERLESS :</b> <label id="lblCustomsCode"></label>
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

        <b>CLOSING DATE :</b><label id="lblClosingDate"></label> <b> CLOSING TIME </b> <label id="lblClosingTime"></label>
        <b>AT :</b><label id="lblClosingPlace"></label>
        <b>REMARK:</b> <div id="dvRemark"></div>
                       <div>
                           If you have any further questions  or queries.please don't hesitate to contact us. We are greatful for your kind consideration.
                           <br />Yours sincerely,
                       </div>
        <br />
        <br />
        <br />
        <br />
    </div>*@
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
            //ShowReleasePort(path, h.ClearPort, '#lblPortLoading');
            $('#lblPortLoading').text(h.FactoryPlace);
            $('#lblPackingPlace').text(h.PackingPlace);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperContact').text(h.ShipperContact);
            $('#lblShipperTel').text(h.ShipperPhone);
            $('#lblShipperFax').text(h.ShipperFax);
            $('#lblShipperEMail').text(h.ShipperEMail);
           

            $.get(path + 'Master/GetCustomsPort?Code=' + h.ClearPort).done(function (r) {
                $('#lblCustomsCode').text(r.RFARS.data[0].AreaName+"-"+h.ClearPort);
            });

            $('#lblCSMail').text(h.CSEMail);
            $('#lblCSName').text(h.CSName);
            let str = h.Description;
            $('#dvRemark').html(CStr(str));
            $('#lblRemark').text(h.Remark);
            $('#lblCloseDatetime').text(ShowDate(h.FactoryDate) + "( BEFORE " + ShowTime(h.FactoryTime) + " HRS.)");
            $('#lblSICutoff').text("CUT OFF SI : " + ShowDate(h.LoadDate) + " @@ " + ShowTime(h.EstDeliverTime) + ". VGM : " + ShowDate(h.EstDeliverDate) + " BEFORE " + ShowTime(h.ConfirmChqDate));
          
            //$('#lblVGMCutoff').text(h.VGMCutoff);
            //$('#').text(h.EstDeliverTime);
            //$('#').text(h.EstDeliverTime);
            
        }
    });
</script>
