
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<div style="display:flex">
    <div style="flex-direction:row;width:70%;border-style:solid;border-width:thin;font-size:12px;">
        <div style="display:flex;flex-direction:column;">
            <div>
                <b>Shipper</b>
                <div>
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <label id="lblShipperAddress2"></label>
                </div>
            </div>
            <div>
                <b>Consignee</b>
                <div>
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <label id="lblConsignAddress2"></label>
                </div>
            </div>
            <div>
                <b>Notify Party</b>
                <div>
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1">
                    <b>Feeder Vessel / Voyage No</b>
                    <div>
                        <label id="lblVesselName"></label>
                    </div>
                </div>
                <div style="flex:1">
                    <b>Place of Receipt</b>
                    <div>
                        <label id="lblPackingPlace"></label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1">
                    <b>Ocean Vessel</b>
                    <div>
                        <label id="lblMVesselName"></label>
                    </div>
                </div>
                <div style="flex:1">
                    <b>Port of Loading</b>
                    <div>
                        <label id="lblClearPortName"></label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1">
                    <b>Port of Discharge</b>
                    <div>
                        <label id="lblInterPortName"></label>
                    </div>
                </div>
                <div style="flex:1">
                    <b>Port of Delivery</b>
                    <div>
                        <label id="lblFactoryPlace"></label>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div style="flex-direction:row;width:30%;border-style:solid;border-width:thin;font-size:12px">
        <div style="display:flex;flex-direction:column;">
            <div>
                <b>House Bill of Lading <label id="lblHAWB"></label> </b>
            </div>
            <div>
                <br />
                <b>FORWARDING AGENT :</b><br />
                <label id="lblForwarderName"></label>
                <br />
                <label id="lblForwarderAddress1"></label>
                <br />
                <label id="lblForwarderAddress2"></label>
            </div>
            <div>
                <br />
                <b>MOVEMENT :</b><label id="lblTransMode"></label>
            </div>
            <div>
                <br />
                <b>FREIGHT PAYABLE AT :</b><br />
                <label id="lblPaymentBy"></label>
            </div>
            <div>
                <br />
                <b>FREIGHT PAID :</b><br />
                <label id="lblPaymentCondition"></label>
            </div>
        </div>
    </div>
</div>
<div style="width:100%;border-collapse:collapse;display:flex;flex-direction:row;border-style:solid;border-width:thin;font-size:12px">
    <div style="width:20%;"><b>Marks & No</b></div>
    <div style="width:10%;"><b>Quantity</b></div>
    <div style="width:40%;"><b>Description of Goods</b></div>
    <div style="width:15%;"><b>Gross Weight (KGS)</b></div>
    <div style="width:15%;"><b>Measurement (CBM)</b></div>
</div>
<div id="dvDetail" style="height:300px;vertical-align:top;display:flex;flex-direction:column;border-style:solid;border-width:thin;font-size:12px">
</div>
<div style="width:100%;border-style:solid;border-width:thin;font-size:11px;text-align:center">according to the declaration of the consigner</div>
<div style="display:flex;">
    <div style="flex-direction:column;width:60%;border-style:solid;border-width:thin;font-size:12px">
        <div>
            <b>For delivery of goods please apply to:</b>
        </div>
        <div>            
            The goods and instructions are accepted and dealth with subject to the standard conditions print overleaf
            <br />
            <br />
        </div>
        <div>
            taken in charge in apparent good order and condition,unless otherwise noted herein,at the place of receipt for transport and delivery as mentioned above.
            <br />
            <br />
        </div>
        <div>
            One of these transport modal multi bills of lading must be surrendered duty endorse in exchange for the goods. in witness wareof the original multi modal transport bill of lading all of this tenor and data have been signed in the number stated below,one of this being accomplished the others to be void
        </div>
    </div>
    <div style="flex-direction:row;width:40%;border-style:solid;border-width:thin;font-size:12px">
        <b>ON BOARD</b> <label id="lblETADate"></label>
        <br />
        <b>Place and date of issue :</b><label id="lblBookingDate"></label> 
        <br />
        <b>Number of original BLs:</b>
        <br />
        <b>Stamp And Signature:</b><br />
    </div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#lblHAWB').text(h.HAWB);
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblForwarderAddress1').text(h.ForwarderAddress1);
            $('#lblForwarderAddress2').text(h.ForwarderAddress2);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(h.ShipperAddress1);
            $('#lblShipperAddress2').text(h.ShipperAddress2);
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress1').text(h.ConsignAddress1);
            $('#lblConsignAddress2').text(h.ConsignAddress2);
            $('#lblNotifyName').text(h.NotifyName);
            $('#lblNotifyAddress1').text(h.NotifyAddress1);
            $('#lblNotifyAddress2').text(h.NotifyAddress2);
            $('#lblVesselName').text(h.VesselName);
            $('#lblMVesselName').text(h.MVesselName);
            $('#lblPackingPlace').text(h.PackingPlace);
            ShowReleasePort(path, h.ClearPort, '#lblClearPortName');
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
            } else {
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
            }
            $('#lblFactoryPlace').text(h.FactoryPlace);

            $('#lblETADate').text(ShowDate(h.ETADate));

            let html = '';
            html = '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:12px">';
            html += '<div style="width:20%;">'+ h.Remark +'</div>';
            html += '<div style="width:10%;">' + h.InvProductQty + ' ' + h.InvProductUnit + '</div>';
            html += '<div style="width:40%;">' + h.InvProduct + '</div>';
            html += '<div style="width:15%;">'+ h.TotalGW + ' ' + h.GWUnit +'</div>';
            html += '<div style="width:15%;">'+ h.TotalM3 +'</div>';
            html += '</div>';

            html += '<div style="width:100%;text-align:center;font-size:11px">"SHIPPER LOAD & COUNT"<br/>"SAID TO CONTAIN"</div>';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:12px">';
            html += '<div style="width:45%;"><u>CONTAINER & SEAL</u></div>';
            html += '<div style="width:25%;"><u>QTY & PACKAGES</u></div>';
            html += '<div style="width:15%;"><u>G.W.</u></div>';
            html += '<div style="width:15%;"><u>MEASUREMENT</u></div>';
            html += '</div>';
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:12px">';
                htmlTemplate += '<div style="width:15%;">CONTAINER #'+ (i+1) +'</div>';
                htmlTemplate += '<div style="width:30%;">'+ r.booking.data[i].CTN_NO +'/'+ r.booking.data[i].SealNumber +'</div>';
                htmlTemplate += '<div style="width:25%;">'+ r.booking.data[i].ProductQty + ' '+ r.booking.data[i].ProductUnit +'</div>';
                htmlTemplate += '<div style="width:15%;">'+ r.booking.data[i].GrossWeight +'</div>';
                htmlTemplate += '<div style="width:15%;">' + r.booking.data[i].Measurement + '</div>';
                htmlTemplate += '</div>';

                html += htmlTemplate;
            }
            html += '<div style="font-size:12px;"><br/>TOTAL (' + (i) + ') CONTAINER(s)</div>';
            $('#dvDetail').html(html);
        }
    });
</script>
