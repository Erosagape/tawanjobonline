
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
	min-width:20mm ;
	
    }

    b{
	white-space:nowrap;
    }
</style>
<table style="width:100%">
	<tbody>
		<tr>
			<td colspan="2"><b>BOOKING NO. : </b></td>
			<td colspan="3" style="border-bottom:1px solid black" id="bookingNo"> </td>
			
			<td><b>HBL NO. :</b> </td>
			<td colspan="3" style="border-bottom:1px solid black" id="hblNo"> </td>
		</tr>	
		<tr>
			<td colspan="2"><b>MBL NO. :</b> </td>
			<td colspan="5" style="border-bottom:1px solid black" id="mblNo"></td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td colspan="2"><b>TO : </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="toShipperName"></td>
			<td colspan="2" > </td>
		</tr>		
		<tr>
			<td colspan="2"><b>REMARK : </b></td>
			<td colspan="7"  style="border-bottom:1px solid black" id="remark"></td>
		</tr>	
		<tr>
			<td><br/> </td>
		</tr>
	</tbody>
	<tbody>
		<tr>
			<td colspan="2"><b>BOOKING TYPE : </b></td>
			<td style="border-bottom:1px solid black" id="bookingType"> </td>
			<td> </td>
			<td colspan="3"><b>BOOKING QTY SIZE/TYPE :  </b></td>
			<td colspan="2" style="border-bottom:1px solid black" id="totalContainer"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>VESSEL CARRIER : </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="forwarderName"> </td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td colspan="2"><b>SHIPPER :  </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="shipperName"> </td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td colspan="2"><b>CONSIGNEE :  </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="consigneeName"> </td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td colspan="2"><b>COMMODITY : </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="product"> </td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td><br/> </td>
		</tr>
		<tr>
			<td><b>FEEDER:  </b></td>
			<td colspan="6" style="border-bottom:1px solid black" id="feederVessel"> </td>
			@*<td style="text-align:right"><b>V.  </b></td>
			<td style="border-bottom:1px solid black"> </td>*@
			<td><b>ETD :  </b></td>
			<td style="border-bottom:1px solid black" id="etd"> </td>
		</tr>
		<tr>
			<td><b>M/V : </b></td>
			<td colspan="6" style="border-bottom:1px solid black"  id="motherVessel"> </td>
			@*<td  style="text-align:right"><b>V.  </b></td>
			<td style="border-bottom:1px solid black"> </td>*@
			<td><b>ETA :  </b></td>
			<td style="border-bottom:1px solid black" id="eta"> </td>
		</tr>
		<tr>
			<td><br/> </td>
		</tr>
		<tr>
			<td colspan="2"><b>PLACE OF RECEIPT: </b></td>
			<td colspan="5"  style="border-bottom:1px solid black" id="placeOfreceipt"> </td>
			<td colspan="2"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>PORT OF LOADING: </b></td>
			<td colspan="5"  style="border-bottom:1px solid black" id="portOfLoading"> </td>
			<td colspan="2"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>T/S PORT:  </b></td>
			<td colspan="5"  style="border-bottom:1px solid black" id="transhipPort"> </td>
			<td colspan="2"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>PORT OF DISCHARGE: </b></td>
			<td colspan="5"  style="border-bottom:1px solid black" id="portOfdischarge"> </td>
			<td colspan="2"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>FINAL DESTINATION : </b></td>
			<td colspan="5"  style="border-bottom:1px solid black" id="finalDestination"> </td>
			<td colspan="2"> </td>
		</tr>
		<tr>
			<td><br/> </td>
		</tr>
		<tr>
			<td colspan="2"><b>CY DATE : </b></td>
			<td colspan="2" style="border-bottom:1px solid black" id="cyDate"> </td>
			<td colspan="3"  style="text-align:center"> <b>RETURN DATE :  </b></td>
			<td colspan="2" style="border-bottom:1px solid black" id="returnDate"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>CY YARD :  </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="cyAt"> </td>
			<td colspan="2"</td>
		</tr>

		<tr>
			<td colspan="2" style="text-align:right"><b>CONTACT : </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="cyContact"> </td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td colspan="2"><b>RETURN YARD :  </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="returnAt"> </td>
			<td colspan="2"</td>
		</tr>
		<tr>
			<td colspan="2"  style="text-align:right"><b>CONTACT : </b></td>
			<td colspan="5" style="border-bottom:1px solid black" id="returnContact"> </td>
			<td colspan="2" > </td>
		</tr>
		<tr>
			<td><br/><br/> </td>
		</tr>
		</tr>
		<tr>
			<td colspan="2"><b>1ST RETURN : </b></td>
			<td colspan="3" style="border-bottom:1px solid black" id="1stReturnDate"> </td>
			<td colspan="4"> </td>
		</tr>
		<tr>
			<td colspan="2"><b>SI CUT OFF:  </b></td>
			<td colspan="3" style="border-bottom:1px solid black" id="siCutoffDate"> </td>
			<td colspan="4">17:00 Hrs </td>
		</tr>
		<tr>
			<td colspan="2"><b>VGM CUT OFF : </b></td>
			<td colspan="3" style="border-bottom:1px solid black" id="vgmCutoffDate"> </td>
			<td colspan="4">18:00 Hrs</td>
		</tr>
		<tr>
			<td colspan="2"><b>FCL CY CUT OFF : </b></td>
			<td colspan="3" style="border-bottom:1px solid black" id="cyCutoffDate"> </td>
			<td colspan="4"> 19.00 Hrs</td>
		</tr>
		<tr>
			<td><br/><br/> </td>
		</tr>
	</tbody>
	<tbody>
		<tr>
			<td colspan="2"><b>Contact Booking Team : </b></td>
			<td colspan="3">pricing1@yifanlogistic.co.th </td>
			<td>K.Potae</td>		
			<td><b>Tel. </b></td>
			<td colspan="2">065-838-5918</td>
		</tr>
		<tr>
			<td colspan="2"><b>Contact CS Team :</b></td>
			<td colspan="3">export10@yifanlogistic.co.th </td>
			<td>K.DAO</td>		
			<td><b>Tel. </b></td>
			<td colspan="2">061-192-9466</td>
		</tr>
	</tbody>
    <tbody style="display:none">
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
            <td colspan="5" id="lblPaymentBy"></td>
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
            <td> <b>RTNDATE</b></td>
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
        <b>QUANTITY : </b><label id="lblTotalContainer"></label>
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
	    	$('#bookingNo').text(h.BookingNo);
		$('#hblNo').text(h.HAWB);
		$('#mblNo').text(h.MAWB);
		$('#toShipperName').text(h.ShipperName);
		$('#remark').text(h.Remark);
		$('#totalContainer').text(h.TotalContainer);
		$('#forwarderName').text(h.CarrierName);
		
		$('#shipperName').text(h.ShipperName);
		$('#consigneeName').text(h.ConsigneeName);
		$('#product').text(h.InvProduct);

		$('#feederVessel').text(h.VesselName);
		$('#motherVessel').text(h.MVesselName);
		$('#etd').text(ShowDate(h.ETDDate));
		$('#eta').text(ShowDate(h.ETADate));

		$('#placeOfreceipt').text(h.CYPlace);
		$('#portOfLoading').text(h.FactoryPlace);
		$('#transhipPort').text();	
		$('#portOfdischarge').text(h.PackingPlace);
		$('#finalDestination').text(h.ReturnPlace);

		$('#transhipPort').text(h.FactoryAddress);
		
		$('#cyAt').text(h.CYAddress);
		$('#returnAt').text(h.ReturnAddress);
		$('#cyContact').text(h.CYContact);
		$('#returnContact').text(h.ReturnContact);

		$('#cyDate').text(ShowDate(h.CYDate));
		$('#cyCutoffDate').text(ShowDate(h.CYDate));
		$('#siCutoffDate').text(ShowDate(h.SICutoffDate));
		$('#vgmCutoffDate').text(ShowDate(h.EstDeliverDate));
		$('#returnDate').text(ShowDate(h.ReturnDate));
		$('#1stReturnDate').text(ShowDate(h.ReturnDate));
		$.get(path + 'joborder/gettransportdetail?Branch=' + br + '&Code=' + doc ).done(function (r) {
			let dr = r.transport.detail;
			let actualyard =   dr.map((r) => r.ActualYardDate);
			//console.log(actualyard );
            		if (dr.length > 0) {
               	 		//$('#cyCutoffDate' ).text(ShowDate(dr[0].ActualYardDate));
				//$('#1stReturnDate').text(ShowDate(dr[0].ReturnDate));
            		}
        	});

		$.get(path + 'Config/GetConfig?Code=JOB_TYPE&Key=0' +h.JobType ).done(function (r) {
			let dr = r.config.data;
            		if (dr.length > 0) {
               	 		$('#bookingType').text(dr[0].ConfigValue);
            		}
        	});
		
	return;
            $('#lblInvProduct').text(h.InvProduct);
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblShipperName2').text(h.ShipperName);
            $('#lblAgentName').text(h.CarrierName);
            //$('#lblTotalContainer').text(h.TotalContainer);
            $('#lblPaymentBy').text(h.PaymentBy);
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblPortArrival');
                ShowCountry(path, h.InvFCountry, '#lblCountry');
            } else {
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblPortArrival');
                ShowCountry(path, h.InvCountry, '#lblCountry');
            }
            $('#lblProductQty').text(h.TotalContainer);

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
                $('#lblReturnDate').text(ShowDate(h.ReturnDate)+"        (First return container)");
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
	    $('#lblCustomsCode').text(h.ClearPort);
/*
            $.get(path + 'Master/GetCustomsPort?Code=' + h.ClearPort).done(function (r) {
                $('#lblCustomsCode').text(r.RFARS.data[0].AreaName+"-"+h.ClearPort);
            });
*/
            $('#lblCSMail').text(h.CSEMail);
            $('#lblCSName').text(h.CSName);
            let str = h.Description;
            $('#dvRemark').html(CStr(str));
            $('#lblRemark').text(h.Remark);
            $('#lblCloseDatetime').text(ShowDate(h.FactoryDate) + "( BEFORE " + ShowTime(h.FactoryTime) + " HRS.)");
            $('#lblSICutoff').text("CUT OFF SI : " + ShowDate(h.LoadDate) + " @@ " + ShowTime(h.EstDeliverTime) + ". VGM : " + ShowDate(h.EstDeliverDate) + " BEFORE " + ShowTime(h.ConfirmChqDate));
            
        }
    });
</script>
