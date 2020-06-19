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
<div style="display:flex">
    <div style="flex-direction:row;width:55%;font-size:10px;">
        <div style="display:flex;flex-direction:column;">
            <div style="height:100px;border-bottom:solid;border-top:solid;border-left:solid;border-width:thin;">
                <b>Shipper</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <label id="lblShipperAddress2"></label>
                </div>
            </div>
            <div style="height:100px;border-bottom:solid;border-left:solid;border-width:thin;">
                <b>Consignee</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <label id="lblConsignAddress2"></label>
                </div>
            </div>
            <div style="height:100px;border-bottom:solid;border-left:solid;border-width:thin;">
                <b>Notify Party</b>
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
                    <b>Feeder Vessel</b>
                    <div>
                        <label id="lblVesselName"></label>
                    </div>
                </div>
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Place of Receipt</b>
                    <div>
                        <label id="lblPackingPlace"></label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Ocean Vessel</b>
                    <div>
                        <label id="lblMVesselName"></label>
                    </div>
                </div>
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Port of Loading</b>
                    <div>
                        <label id="lblClearPortName"></label>
                    </div>
                </div>
            </div>
            <div style="display:flex;flex-direction:row;">
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Port of Discharge</b>
                    <div>
                        <label id="lblInterPortName"></label>,<label id="lblCountryName"></label>
                    </div>
                </div>
                <div style="flex:1;border-left:solid;border-bottom:solid;border-width:thin;">
                    <b>Port of Delivery</b>
                    <div>
                        <label id="lblFactoryPlace"></label>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div style="flex-direction:row;width:45%;font-size:12px;border-top:solid;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
        <div style="display:flex;flex-direction:column;">
            <div style="display:flex;flex-direction:row;padding:5px 5px 5px 5px;">
                <div style="flex:1">
                    <b>BILL OF LADING</b><br />
                    <input type="text" value="ORIGINAL/COPY" style="border:none;">
                </div>
                <div style="flex:1;text-align:center;align-items:center;border:thin;border-width:thin;border-style:solid;">
                    House Bill of Lading
                    <br />
                    <label id="lblHAWB"></label>
                </div>
            </div>
            <div style="text-align:center">
                <br />
                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:60%" />
                <br /><br />
                <div id="divCompany" style="text-align:center;color:darkblue;font-size:12px">
                    <div style="font-weight:bold;font-size:12px">
                        ADVANCE CARGO EXPRESS CO.,LTD
                    </div>
                    21 ROMKLAO 21/3 KLONGSAMPRAVET<br />LADKRABANG BANGKOK 10320 THAILAND
                    <br />Tel (662) 670 0660 Fax (662) 170 7253
                    <br />E-mail/Website ace@th-ace.com
                </div>

            </div>
        </div>
    </div>
</div>
<div style="width:100%;display:flex;flex-direction:row;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="width:20%;"><b>Marks & Numbers</b></div>
    <div style="width:15%;"><b>Number and Kind of Packages</b></div>
    <div style="width:35%;"><b>Description of Goods</b></div>
    <div style="width:15%;"><b>Gross Weight (KGS)</b></div>
    <div style="width:15%;"><b>Measurement (CBM)</b></div>
</div>
<div id="dvDetail" style="height:380px;vertical-align:top;display:flex;flex-direction:column;font-size:10px;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
</div>
<div style="width:100%;font-size:10px;text-align:center;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;"><b>according to the declaration of the consigner</b></div>
<div style="width:100%;font-size:10px;text-align:left;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    The goods and instructions are accepted and dealt with subject to the standard conditions which are available upon request.
    Taken in charge in apparent good order and condition,unless otherwise noted herein,at the place of receipt for transport and delivery as mentioned above.
    One of these Multi-modal transport bills of lading must be surrendered duty endorse in exchange for the goods. In witness whereof the original multi-modal transport bill of lading all of this tenor and of this tenor and date have been signed in the number stated below One of this being accomplished the others to be void
</div>
<div style="font-size:10px;border-right:solid;border-left:solid;border-bottom:solid;border-width:thin;">
    <div style="display:flex;flex-direction:row">
        <div style="flex:3;border-right:solid;border-width:thin;">
            <b>Freight Payable At:</b><br />
            <label id="lblPaymentBy"></label>
        </div>
        <div style="flex:3;border-right:solid;border-width:thin;">
            <b>Freight Condition:</b><br /><label id="lblPaymentCondition"></label>
        </div>
        <div style="flex:4;">
            <b>Place and date of issue :</b><br />
            <label id="lblBookingDate"></label>
        </div>
    </div>
</div>
<div style="display:flex;">
    <div style="width:60%;border-left:solid;border-bottom:solid;border-width:thin;">
        <div style="display:flex;flex-direction:column;font-size:10px;width:100%">
            <div style="display:flex;flex-direction:row">
                <div style="flex:1;">
                    <b>Cargo insurance through the undersigned</b><br />
                    <input type="checkbox" /> Not Covered<br /><input type="checkbox" /> Covered according to attached policy
                </div>
                <div style="flex:1;border-left:solid;border-width:thin;">
                    <b>Number or original BLs :</b><br /><label id="lblBLNo"></label>
                </div>
            </div>
        </div>
        <div style="font-size:10px;border-top:solid;border-width:thin;">
            <b>For delivery of goods please apply to:</b><br />
            <label id="lblDeliveryTo"></label><br />
            <label id="lblDeliveryAddr"></label>
        </div>
    </div>
    <div style="width:40%;font-size:10px;border-left:solid;border-right:solid;border-bottom:solid;border-width:thin;">
        <div style="text-align:center">
            <br />
            <b>Stamp And Signature:</b>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            AS AGENT FOR <label id="lblForwarderName"></label>
        </div>
        <br />
        <label id="lblProductUnit" style="display:none"></label>
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
            $('#lblHAWB').text(h.HAWB);
            $('#lblBLNo').text(h.BLNo);
            $('#lblDeliveryTo').text(h.DeliveryTo);
            $('#lblDeliveryAddr').text(h.DeliveryAddr);
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ForwarderName);
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
let unit=units.filter(function(data){
   return data.Code==h.InvProductUnit;
 });
if(unit.length>0) {
   $('#lblProductUnit').text(unit[0].TName);
} else {
   $('#lblProductUnit').text(h.InvProductUnit);
}
	var Showinv=false;
	if(confirm("Print PO/Commercial Invoice?")==true) {
	 Showinv=true;
	}
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
                ShowCountry(path, h.InvFCountry, '#lblCountryName');
            } else {
                ShowCountry(path, h.InvCountry, '#lblCountryName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
            }
            $('#lblFactoryPlace').text(h.FactoryPlace);


            let html = '';
            html += '<div style="width:100%;text-align:center;font-size:10px">"SHIPPER LOAD & COUNT & SEAL"<br/>"SAID TO CONTAIN ('+ h.TransMode +')"</div>';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:20%;">'+ CStr(h.Remark) +'</div>';
            html += '<div style="width:15%;">' + h.InvProductQty + ' ' + $('#lblProductUnit').text() + '</div>';
            html += '<div style="width:35%;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
	if(Showinv==true) {
            html += '<br/>AS ORDER NO ' + h.CustRefNO;
            html += '<br/>INVOICE NO ' + h.InvNo;
            html += '<br/> DATE ' + ShowDate(h.ConfirmDate);
	}
            html += '</div>';
            html += '<div style="width:15%;">G.W ' + ShowNumber(h.TotalGW,2) + ' ' + h.GWUnit + '';
            if(h.TotalNW>0)  {
            html += '<br/>N.W '+ ShowNumber(h.TotalNW,2) + ' ' + h.GWUnit
            }
            html +='</div>';
            html += '<div style="width:15%;text-align:center">'+ h.TotalM3 +' M3</div>';
            html += '</div>';

            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:45%;"><u>CONTAINER & SEAL</u></div>';
            html += '<div style="width:25%;"><u>QTY & PACKAGES</u></div>';
            html += '<div style="width:15%;"><u>G.W.</u></div>';
            html += '<div style="width:15%;"><u>MEASUREMENT</u></div>';
            html += '</div>';
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                htmlTemplate += '<div style="width:15%;">'+ r.booking.data[i].CTN_NO +'</div>';
                htmlTemplate += '<div style="width:30%;">'+ r.booking.data[i].SealNumber +'</div>';
unit=units.filter(function(data){
   return data.Code==r.booking.data[i].ProductUnit;
 });
if(unit.length>0) {
                htmlTemplate += '<div style="width:25%;">'+ r.booking.data[i].ProductQty + ' '+ unit[0].TName +'</div>';
} else {
                htmlTemplate += '<div style="width:25%;">'+ r.booking.data[i].ProductQty + ' '+ r.booking.data[i].ProductUnit +'</div>';
}
                htmlTemplate += '<div style="width:15%;">'+ ShowNumber(r.booking.data[i].GrossWeight,2) +'</div>';
                htmlTemplate += '<div style="width:15%;text-align:center;">' + r.booking.data[i].Measurement + '</div>';
                htmlTemplate += '</div>';

                html += htmlTemplate;
            }
            html += '<div style="font-size:9px;"><br/>TOTAL (' + (i) + ') CONTAINER(s)';
            html += '<br/> TOTAL PACKAGES ' + CNumEng(h.InvProductQty) + ' ' + $('#lblProductUnit').text() + ' ONLY';
            html += '</div>';
            $('#dvDetail').html(html);
        }
    });
    }
</script>
