
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "SHIPPING PARTICULARS"
    ViewBag.Title = "SHIPPING PARTICULARS"
End Code
    <div style="display:flex">
        <div style="flex-direction:row;width:50%;font-size:12px;">
            <div style="display:flex;flex-direction:column;">
                <div style="border-style:solid;border-width:thin;">
                    <b>Shipper</b>
                    <div>
                        <label id="lblShipperName"></label>
                        <br />
                        <label id="lblShipperAddress1"></label>
                        <br />
                        <label id="lblShipperAddress2"></label>
                    </div>
                </div>
                <div style="border-style:solid;border-width:thin;">
                    <b>Consignee</b>
                    <div>
                        <label id="lblConsigneeName"></label>
                        <br />
                        <label id="lblConsignAddress1"></label>
                        <br />
                        <label id="lblConsignAddress2"></label>
                    </div>
                </div>
                <div style="border-style:solid;border-width:thin;">
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
                    <div style="flex:1;border-style:solid;border-width:thin;">
                        <b>Feeder Vessel / Voyage No</b>
                        <div>
                            <label id="lblMVesselName"></label>
                        </div>
                    </div>
                    <div style="flex:1;border-style:solid;border-width:thin;">
                        <b>Place of Receipt</b>
                        <div>
                            <label id="lblPackingPlace"></label>
                        </div>
                    </div>
                </div>
                <div style="display:flex;flex-direction:row;">
                    <div style="flex:1;border-style:solid;border-width:thin;">
                        <b>Ocean Vessel</b>
                        <div>
                            <label id="lblVesselName"></label>
                        </div>
                    </div>
                    <div style="flex:1;border-style:solid;border-width:thin;">
                        <b>Port of Loading</b>
                        <div>
                            <label id="lblFactoryPlace"></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="flex-direction:row;width:50%;border-style:solid;border-width:thin;font-size:12px">
            <div style="display:flex;flex-direction:column;">
                <div>
                    <b>ATTN</b> : <label id="lblForwarderName"></label>
                    <br />
                </div>
                <div>
                    <br />
                    <b>FROM</b> : <label id="lblCSName"></label><br />
                    <b>TEL</b> : <label id="lblCSTel"></label><br />
                    <b>EMAIL</b> : <label id="lblCSEMail"></label><br />
                </div>
                <div>
                    <br />
                    <b>Actual Shipper :</b><br />
                    <label id="lblShipperName2"></label>
                </div>
                <div>
                    <br />
                    <br />
                    <b>Master-File NO :</b><label id="lblJNo"></label>
                </div>
                <div>
                    <b>BOOKING NO: <label id="lblBookingNo"></label> </b>
                </div>
            </div>
        </div>        
    </div>
    <div style="display:flex;">
        <div style="flex:1;border-style:solid;border-width:thin;">
            <b>Port of Discharge</b>
            <div>
                <label id="lblInterPortName"></label>
            </div>
        </div>
        <div style="flex:1;border-style:solid;border-width:thin;">
            <b>Port of Delivery</b>
            <div>
                <label id="lblInterPortName1"></label>,<label id="lblCountry"></label>
            </div>
        </div>
        <div style="flex:1;border-style:solid;border-width:thin;">
            <b>Freight and charge payable at</b><br />
            <label id="lblPaymentCondition"></label>
        </div>
        <div style="flex:1;border-style:solid;border-width:thin;">
            <b>Number of original B/Ls</b><br />
            <label id="lblBLNo"></label>
        </div>
    </div>
<div style="width:100%;border-collapse:collapse;display:flex;flex-direction:row;border-style:solid;border-width:thin;font-size:12px">
    <div style="width:20%;padding:1px 1px 1px 1px;"><b>For FCL shipments container marks and Nos,to be stated,marks and Nos</b></div>
    <div style="width:10%;padding:1px 1px 1px 1px;"><b>Quantity and kind of packages</b></div>
    <div style="width:40%;padding:1px 1px 1px 1px;"><b>Description of Goods</b></div>
    <div style="width:15%;padding:1px 1px 1px 1px;"><b>Gross Weight (KGS)</b></div>
    <div style="width:15%;padding:1px 1px 1px 1px;"><b>Measurement (M3)</b></div>
</div>
<div id="dvDetail" style="height:300px;vertical-align:top;display:flex;flex-direction:column;border-style:solid;border-width:thin;font-size:12px">
</div>
<div style="width:100%;border-style:solid;border-width:thin;font-size:16px;text-align:center">BL ORIGINAL</div>
<div style="display:flex;">
    <div style="flex-direction:row;width:40%;border-style:solid;border-width:thin;font-size:12px">
        <b>ON BOARD DATE</b> <label id="lblETADate"></label>
    </div>
    <div style="flex-direction:row;width:60%;border-style:solid;border-width:thin;font-size:12px">
        <br/>
        TOTAL : <label id="lblTotalQtyText"></label>
    </div>
</div>
    <script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblJNo').text(h.JNo);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperName2').text(h.ShipperName);
            $('#lblForwarderName').text(h.ForwarderName);
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
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblCSName').text(h.CSName);
            $('#lblCSTel').text(h.CSTel);
            $('#lblCSEMail').text(h.CSEMail);

            
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName1');
                ShowCountry(path, h.InvFCountry, '#lblCountry');
            } else {
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName1');
                ShowCountry(path, h.InvCountry, '#lblCountry');
            }
            
            $('#lblBLNo').text(h.BLNo);
            $('#lblTotalQtyText').text(CNumEng(h.InvProductQty) + ' ' + h.InvProductUnit + ' ONLY');
            $('#lblETADate').text(ShowDate(h.ETADate));

            let html = '';
            html = '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:12px">';
            html += '<div style="width:20%;">'+ h.Remark +'</div>';
            html += '<div style="width:10%;">' + h.InvProductQty + ' ' + h.InvProductUnit + '</div>';
            html += '<div style="width:40%;">"SAID TO CONTAIN -' + h.TotalContainer + ' (' + h.TransMode + ')"<br/>"SHIPPER LOAD & COUNT"';
            html += '<br/> H.S.CODE ' + h.ShippingCmd;
            html += '<br/> ITEM CODE ' + h.InvProduct;
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                html += '<br/>' + r.booking.data[i].GrossWeight + ' KGS ' + r.booking.data[i].ProductDesc + '<br/>';
            }
            html += '<br/>L/C NO ' + h.MAWB;
            html += '<br/>INVOICE NO ' + h.InvNo;
            html += '</div>';
            html += '<div style="width:15%;">G.W ' + h.TotalGW + ' ' + h.GWUnit + '';
            html += '<br/>N.W '+ h.TotalNW + ' ' + h.GWUnit +'</div>';
            html += '<div style="width:15%;">'+ h.TotalM3 +'</div>';
            html += '</div>';

            $('#dvDetail').html(html);
        }
    });
    </script>
