@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
    #dvFooter, #pFooter {
        display: none;
    }
</style>
<br />
<br />
<br />
<div style="display:flex">
    <div style="flex-direction:row;width:50%;font-size:10px;">
        <div style="display:flex;flex-direction:column;">
            <div style="height:100px;border-bottom:solid;border-top:solid;border-left:solid;border-width:thin;">
                <b>Shipper</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <div id="lblShipperAddress2"></div>
                </div>
            </div>
            <div style="height:100px;border-bottom:solid;border-left:solid;border-width:thin;">
                <b>Consignee or order</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <div id="lblConsignAddress2"></div>
                </div>
            </div>
            <div style="height:100px;border-bottom:solid;border-left:solid;border-width:thin;">
                <b>Notify address</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Place of Receipt</b>
                    <div>
                        <label id="lblPackingPlace"></label>
                    </div>
                </div>
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Port of Loading</b>
                    <div>
                        <label id="lblClearPortName"></label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="flex-direction:row;width:50%;font-size:12px;border-top:solid;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
        <div style="display:flex;flex-direction:column;">
            <div style="display:flex;flex-direction:column;padding:5px 5px 5px 5px;width:50%;align-self:center">
                <div style="flex:1;text-align:center;align-items:center;border:thin;border-width:thin;border-style:solid;">
                    B/L NO:<label id="lblHAWB" style="color:red"></label>
                </div>
            </div>
            <div style="text-align:center">
                <img id="imgLogo" src="~/Resource/logo-stl.png" style="width:60%" />
                <br />
                <div id="divCompany" style="text-align:center;color:darkblue;font-size:12px;">
                    <p style="font-weight:bold;font-size:12px">
                        SINOTHAI LOGISTICS INTERNATIONAL CO.,LTD<br />
                        <b>BILL OF LADING</b>
                    </p>
                    <p style="font-size:10px;text-align:left;">
                        RECEIVED by the Carrier that the Goods as specified above in apparent good order and condition
                        unless otherwise stated,to be transported to such place as agreed authorized or permited herein
                        and subject to all the terms and conditions appearing on the front and reverse of this bill of lading
                        that the Merchant agree by accepting this bill of lading any local privileges and customs not withstanding.
                    </p>
                    <p style="font-size:10px;text-align:left;">
                        The particulars given below as stated by shipper and weight measure,quantity,condition contents and value of the goods
                        are unknown to the Carrier in WITNESS where of one (1) original bill of lading has been signed if not otherwise stated below
                        the same being accomplished the other(s),if any to be void,if required by the Carrier one (1) original bill of lading
                        must be surrendered duty endorsed in exchange for the Goods or delivery order.
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="flex:1;">
        <b>Ocean Vessel/Voyage No</b>
        <div>
            <label id="lblMVesselName"></label>
        </div>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Port of Discharge</b>
        <div>
            <label id="lblInterPortName"></label>
        </div>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Port of Delivery</b>
        <div>
            <label id="lblFactoryPlace"></label>
        </div>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Freight Payable At:</b><br />
        <label id="lblPaymentBy"></label>
    </div>
    <div style="flex:1;border-left:solid;border-width:thin;">
        <b>Number or original BLs :</b><br /><label id="lblBLNo"></label>
    </div>
</div>
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="width:20%;"><b>Marks & Numbers</b></div>
    <div style="width:15%;"><b>No. of Pkgs or Units</b></div>
    <div style="width:35%;"><b>Kind of Pkgs or Description of Goods<br />(said to contain)</b></div>
    <div style="width:15%;"><b>Gross Weight</b></div>
    <div style="width:15%;"><b>Measurements</b></div>
</div>
<div id="dvDetail" style="height:280px;vertical-align:top;display:flex;flex-direction:column;font-size:10px;border-right:solid;border-left:solid;border-width:thin;">
</div>
<div id="dvContainer" style="height:200px;vertical-align:top;width:100%;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
</div>
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="width:20%;"><b>Total number of Packages or units (in words)</b></div>
    <div style="width:80%;">
        <label id="lblTotalPackage"></label><label id="lblProductUnit"></label> ONLY
    </div>
</div>
<div style="display:flex;">
    <div style="font-size: 10px;width: 40%; border-left: solid; border-bottom: solid; border-width: thin;">
        <div>
            <b>Freight Details,Charges etc.</b>
            <br /><label id="lblPaymentCondition"></label>
        </div>
        <div>
            <b>F/Agent Name to delivery</b><br />
            <label id="lblDeliveryTo"></label><br />
            <div id="lblDeliveryAddr"></div>
        </div>
    </div>
    <div style="width:60%;font-size:10px;border-left:solid;border-right:solid;border-bottom:solid;border-width:thin;">
        <div>
            <b>Type of Service</b>
            <label id="lblServiceMode"></label>
        </div>
        <div>
            <b>Laden on Board</b>
            <label id="lblCYDate"></label>
        </div>
        <div>
            <b>Place and date of issue :</b>
            <label id="lblBookingDate"></label>
        </div>
        <div>
            <b>Signed on behalf of the carrier:</b>
            <br />
            <br />
            AS AGENT FOR THE CARRIER: <label id="lblForwarderName"></label>
        </div>
    </div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    var units=[];
    $.get(path + 'Master/GetCustomsUnit').done(function(m) {
	    units=m.customsunit.data;
	    LoadData();
    });
    function LoadData() {
        $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
            if (r.booking !== null) {
                let h = r.booking.data[0];
                //$('#lblMAWB').text(h.MAWB);
                $('#lblHAWB').text(h.HAWB);
                $('#lblBLNo').text(h.BLNo);
                $('#lblDeliveryTo').text(h.DeliveryTo);
                $('#lblDeliveryAddr').html(CStr(h.DeliveryAddr));
                $('#lblTransMode').text(h.TransMode);
                $('#lblPaymentBy').text(h.PaymentBy);
                $('#lblPaymentCondition').text(h.PaymentCondition);
                $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
                $('#lblForwarderName').text(h.ForwarderName);
                $('#lblShipperName').text(h.ShipperName);
                $('#lblShipperAddress1').text(h.ShipperAddress1);
                $('#lblShipperAddress2').html(CStr(h.ShipperAddress2));
                $('#lblConsigneeName').text(h.ConsigneeName);
                $('#lblConsignAddress1').text(h.ConsignAddress1);
                $('#lblConsignAddress2').html(CStr(h.ConsignAddress2));
                $('#lblNotifyName').text(h.NotifyName);
                $('#lblNotifyAddress1').text(h.NotifyAddress1);
                $('#lblNotifyAddress2').text(h.NotifyAddress2);

                $('#lblMVesselName').text(h.MVesselName);
                $('#lblPackingPlace').text(h.CYPlace);
                $('#lblClearPortName').text(h.ClearPortNo);

                let unit=units.filter(function(data){
                   return data.Code==h.InvProductUnit;
                 });
                if(unit.length>0) {
                   $('#lblProductUnit').text(unit[0].TName);
                } else {
                   $('#lblProductUnit').text(h.InvProductUnit);
                }
                if (h.JobType == '1') {
                    ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
                    //ShowCountry(path, h.InvFCountry, '#lblCountryName');
                } else {
                    //ShowCountry(path, h.InvCountry, '#lblCountryName');
                    ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
                }
                $('#lblFactoryPlace').text(h.FactoryPlace);
                $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
                $('#lblServiceMode').text(h.TRemark);
                $('#lblCYDate').text(ShowDate(h.CYDate));

                let html = '';

                html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
                html += '<div style="width:20%;">'+ CStr(h.Remark) +'</div>';
                html += '<div style="width:15%;">' + h.InvProductQty + '<br/>' + $('#lblProductUnit').text() + '</div>';
                html += '<div style="width:35%;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
                html += '<br/>SAY ' + h.TotalContainer + ' CONTAINER(s) ONLY';
                html += '</div>';
                html += '<div style="width:15%;">G.W ' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit + '';
                if(h.TotalNW>0)  {
                    html += '<br/>N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit;
                }
                html +='</div>';
                html += '<div style="width:15%;text-align:center">'+ h.TotalM3 +' M3</div>';
                html += '</div>';

                $('#dvDetail').html(html);

                html = '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
                html += '<div style="width:45%;"><u>CONTAINER & SEAL</u></div>';
                html += '</div>';

                let i = 0;
                for (i = 0; i < r.booking.data.length; i++){
                    let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                    htmlTemplate += r.booking.data[i].CTN_NO + '/' + r.booking.data[i].CTN_SIZE + ' #' + r.booking.data[i].SealNumber + ' ' + r.booking.data[i].Measurement + ' M3 G.W '+ r.booking.data[i].GrossWeight+' KGS QTY: '+ r.booking.data[i].ProductQty + ' ' + r.booking.data[i].ProductUnit+ ' ' +h.TransMode;
                    htmlTemplate += '</div>';

                    html += htmlTemplate;
                }

                html += '</div>';

                $('#dvContainer').html(html);
            }
        });
    }
</script>
