
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
                    <label id="lblConsignName">APL LOGISTICS SVCS THAILAND</label>
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
                <label id="lblAgentName">APL LOGISTICS CO.,LTD</label>
            </div>
            <div>
                <b>Attn</b>
                <label id="lblAgentContact">Khun Nid</label>
            </div>
            <div>
                <b>From</b>
                <label id="lblCSName">Sunisa Klangmueng</label>
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
<div style="width:100%;border-collapse:collapse;display:flex;flex-direction:row;border-style:solid;border-width:thin">
    <div style="width:20%;"><b>Marks && No</b></div>
    <div style="width:10%;"><b>Quantity</b></div>
    <div style="width:40%;"><b>Description of Goods</b></div>
    <div style="width:15%;"><b>Gross Weight (KGS)</b></div>
    <div style="width:15%;"><b>Measurement (CBM)</b></div>
</div>
<div id="dvDetail" style="height:200px;vertical-align:top;display:flex;flex-direction:column;border-style:solid;border-width:thin">
    <div style="width:100%;display:flex;flex-direction:row">
        <div style="width:20%;">1</div>
        <div style="width:10%;">100 C62</div>
        <div style="width:40%;">TEST PRODUCTS</div>
        <div style="width:15%;">10000</div>
        <div style="width:15%;">43.155</div>
    </div>
</div>
<div style="display:flex;">
    <div style="flex-direction:column;width:60%;border-style:solid;border-width:thin">
        <div>
            <input type="checkbox" /><b>CY EMPTY CONTAINER ON </b><label id="lblCYDate">10/12/2019</label><br />AT <label id="lblCYTime">18.00</label>
            <br/><label id="lblCYPlace">KM.13 LADKRABANG</label>
        </div>
        <div>
            <input type="checkbox" /><b>RETURN CONTAINER ON </b><label id="lblReturnDate">13/12/2019</label> <br />AT <label id="lblReturnTime">19.00</label>
            <br/>
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

