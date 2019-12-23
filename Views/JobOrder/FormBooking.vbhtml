
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation"
    ViewBag.Title = "BOOKING CONFIRMATION"
End Code
<div style="display:flex">
    <div style="flex-direction:row;width:70%;border-style:solid;border-width:thin">
        <div style="display:flex;flex-direction:column;">
            <div>
                <b>Shipper</b>
                <div>
                    <label id="lblShipperName">KGM SERVICES CO.,LTD</label>
                    <br />
                    <label id="lblShipperAddress1">18 SSP TOWER 2 18 FLOOR</label>
                    <br />
                    <label id="lblShipperAddress2">KLONGTOEY BANGKOK</label>
                </div>
            </div>
            <div>
                <b>Consignee</b>
                <div>
                    <label id="lblConsigneeName">APL LOGISTICS SVCS THAILAND</label>
                    <br />
                    <label id="lblConsignAddress1">10205 WIBULTHANI BLDG 3rd FLOOR</label>
                    <br />
                    <label id="lblConsignAddress2">KLONGTOEY BANGKOK</label>
                </div>
            </div>
            <div>
                <b>Notify Party</b>
                <div>
                    <label id="lblNotifyName">SUMITOMO JAPAN LTD</label>
                    <br />
                    <label id="lblNotifyAddress1">1050 KINZA 106-BUILDING 18 FL</label>
                    <br />
                    <label id="lblNotifyAddress2">YANAKUSA, GENKI AVENUE</label>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1">
                    <b>Feeder Vessel</b>
                    <div>
                        <label id="lblVesselName">14-2556</label>
                    </div>
                </div>
                <div style="flex:1">
                    <b>Origin Port</b>
                    <div>
                        <label id="lblPackingPlace">ด่านสระแก้ว</label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1">
                    <b>Mother Vessel</b>
                    <div>
                        <label id="lblMVesselName">WANHAI 547</label>
                    </div>
                </div>
                <div style="flex:1">
                    <b>Loading Port</b>
                    <div>
                        <label id="lblClearPortName">สำนักงานสุลกากรท่าเรือแหลมฉบัง</label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1">
                    <b>Discharge Port</b>
                    <div>
                        <label id="lblInterPortName">POIPET,CAMBODIA</label>
                    </div>
                </div>
                <div style="flex:1">
                    <b>Destination Port</b>
                    <div>
                        <label id="lblFactoryPlace">SIAMREAP FACTORY</label>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div style="flex-direction:row;width:30%;border-style:solid;border-width:thin">
        <div style="display:flex;flex-direction:column;">
            <div>
                <b>Booking No</b>
                <br />
                <label id="lblBookingNo">BKAU12050120</label>
            </div>
            <div>
                <b>Booking Date</b>
                <label id="lblBookingDate">12/12/2019</label>
            </div>
            <div>
                <b>To</b>
                <label id="lblForwarderContact">APL LOGISTICS CO.,LTD</label>
            </div>
            <div>
                <b>Attn</b>
                <label id="lblForwarderName">Khun Nid</label>
            </div>
            <div>
                <b>Tel</b>
                <label id="lblCSTel">027145556 Ext 3505</label>
            </div>
            <div>
                <b>Fax</b>
                <label id="lblCSEMail">027156665</label>
            </div>
            <div>
                <b>From</b>
                <label id="lblCSName">Sunisa Klangmueng</label>
            </div>
            <div>
                <b>Volume</b>
                <label id="lblTotalContainer">2x40F</label>
            </div>
            <div>
                <b>Container / Seal No</b>
                <div id="dvContainers">
                    CGAU1204505 / MF1050<br />
                    CAGU1208066 / CF1405<br />
                </div>
            </div>
        </div>

    </div>
</div>
<div style="display:flex;">
    <div style="flex-direction:column;width:60%;border-style:solid;border-width:thin">
        <div>
            <input type="checkbox" /><b>CY EMPTY CONTAINER ON </b><label id="lblCYDate">10/12/2019</label><br />AT <label id="lblCYTime">18.00</label>
            <br /><label id="lblCYPlace">KM.13 LADKRABANG</label>
        </div>
        <div>
            <input type="checkbox" /><b>RETURN CONTAINER ON </b><label id="lblReturnDate">13/12/2019</label> <br />AT <label id="lblReturnTime">19.00</label>
            <br />
            <label id="lblReturnPlace"></label>
        </div>
        <div>
            <input type="checkbox" /><b>STUFFING CONTAINER ON </b><label id="lblFactoryDate">20/12/2019</label><br />AT <label id="lblFactoryTime">20.00</label>
        </div>
    </div>
    <div style="flex-direction:row;width:40%;border-style:solid;border-width:thin">
        <b>ON BOARD</b> <label id="lblETADate">11/12/2019</label>
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
            $('#lblBookingDate').text(ShowDate(h.LoadDate));
            $('#lblForwarderName').text(h.ShipperName);
            $('#lblForwarderContact').text(h.ForwarderContact);
            $('#lblCSName').text(h.CSName);
            $('#lblCSTel').text(h.CSTel);
            $('#lblCSEMail').text(h.CSEmail);
            $('#lblTotalContainer').text(h.TotalContainer);
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
            $('#lblCYDate').text(ShowDate(h.CYDate));
            $('#lblCYTime').text(ShowTime(h.CYTime));
            $('#lblCYPlace').text(h.CYPlace);
            $('#lblReturnDate').text(ShowDate(h.ReturnDate));
            $('#lblReturnTime').text(ShowTime(h.ReturnTime));
            $('#lblReturnPlace').text(h.ReturnPlace);
            $('#lblFactoryDate').text(ShowDate(h.FactoryDate));
            $('#lblFactoryTime').text(ShowTime(h.FactoryTime));
            $('#lblETADate').text(ShowDate(h.ETADate));
            //let str = h.Remark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#dvContainers').html(CStr(h.Remark));

        }
    });
</script>
