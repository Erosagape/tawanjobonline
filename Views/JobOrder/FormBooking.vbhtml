
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "SHIPPING PARTICULARS"
    ViewBag.Title = "SHIPPING PARTICULARS"
End Code
<style>
    #dvFooter {
        display:none;
    }
</style>
    <div style="display:flex">
        <div style="flex-direction:row;width:50%;font-size:12px;">
            <div style="display:flex;flex-direction:column;">
                <div style="border-style:solid;border-width:thin;height:100px">
                    <b>Shipper</b>
                    <div style="padding:5px 5px 5px 5px">
                        <label id="lblShipperName"></label>
                        <br />
                        <label id="lblShipperAddress1"></label>
                        <br />
                        <label id="lblShipperAddress2"></label>
                    </div>
                </div>
                <div style="border-style:solid;border-width:thin;height:100px">
                    <b>Consignee</b>
                    <div style="padding:5px 5px 5px 5px">
                        <label id="lblConsigneeName"></label>
                        <br />
                        <label id="lblConsignAddress"></label>
                    </div>
                </div>
                <div style="border-style:solid;border-width:thin;height:100px">
                    <b>Notify Party</b>
                    <div style="padding:5px 5px 5px 5px">
                        <input type="text" style="border:none" value="SAME AS CONSIGNEE">
                        <br/>
                        <input type="text" style="border:none" value="">
                        <br/>
                        <input type="text" style="border:none" value="">
                    </div>
                </div>
                <div style="display:flex;flex-direction:row;">
                    <div style="flex:1;border-style:solid;border-width:thin;">
                        <b>Feeder Vessel / Voyage No</b>
                        <div>
                            <label id="lblVesselName"></label>
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
                        <b>Mother Vessel</b>
                        <div>
                            <label id="lblMVesselName"></label>
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
                <label id="lblInterPortName"></label>,<label id="lblCountry"></label>
            </div>
        </div>
        <div style="flex:1;border-style:solid;border-width:thin;">
            <b>Port of Delivery</b>
            <div>
                <label id="lblInterPortName1"></label>,<label id="lblCountry1"></label>
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
    <div style="width:100%;border-collapse:collapse;display:flex;flex-direction:row;border-style:solid;border-width:thin;font-size:12px;text-align:center">
        <div style="width:20%;"><b>Marks & Numbers</b></div>
        <div style="width:15%;"><b>Number and Kind of Packages</b></div>
        <div style="width:35%;"><b>Description of Goods</b></div>
        <div style="width:15%;"><b>Gross Weight (KGS)</b></div>
        <div style="width:15%;"><b>Measurement (CBM)</b></div>
    </div>
<div id="dvDetail" style="height:300px;vertical-align:top;display:flex;flex-direction:column;border-style:solid;border-width:thin;font-size:12px">
</div>
<div style="width:100%;border-style:solid;border-width:thin;font-size:16px;text-align:center">
    <input type="text" value="BL ORIGINAL" style="text-align:center;font-size:16px;border:none" />
</div>
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
    var units = [];
    $.get(path + 'Master/GetCustomsUnit').done(function(m) {
        units = m.customsunit.data;
        LoadData();
    });
    function LoadData() {
        $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
            if (r.booking !== null) {
                let h = r.booking.data[0];
                $('#lblBookingNo').text(h.BookingNo);
                $('#lblJNo').text(h.JNo);
                $('#lblPaymentCondition').text(h.PaymentCondition);
                $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
                //$('#lblShipperName').text('@ViewBag.PROFILE_COMPANY_NAME_EN');
                //$('#lblShipperName2').text(h.ShipperName);
                $('#lblShipperName').text(h.ShipperName);
                $('#lblForwarderName').text(h.ForwarderName);
                //$('#lblShipperAddress1').text('@ViewBag.PROFILE_COMPANY_ADDR1_EN');
                //$('#lblShipperAddress2').text('@ViewBag.PROFILE_COMPANY_ADDR2_EN');
                $('#lblShipperAddress1').text(h.ShipperAddress1);
                $('#lblShipperAddress2').text(h.ShipperAddress2);
                //$('#lblConsigneeName').text(h.DeliveryTo);
                //$('#lblConsignAddress').text(h.DeliveryAddr);            
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress').text(h.ConsignAddress1 + h.ConsignAddress2);
                $('#lblNotifyName').text(h.NotifyName);
                $('#lblNotifyAddress1').text(h.NotifyAddress1);
                $('#lblNotifyAddress2').text(h.NotifyAddress2);
                $('#lblVesselName').text(h.VesselName);
                $('#lblMVesselName').text(h.MVesselName);
                $('#lblPackingPlace').text(h.PackingPlace);
                //$('#lblFactoryPlace').text(h.FactoryPlace);
		ShowReleasePort(path,h.ClearPort,'#lblFactoryPlace');
                $('#lblCSName').text(h.CSName);
                $('#lblCSTel').text(h.CSTel);
                $('#lblCSEMail').text(h.CSEMail);

            
                if (h.JobType == '1') {
                    ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
                    ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName1');
                    ShowCountry(path, h.InvFCountry, '#lblCountry');
                    ShowCountry(path, h.InvFCountry, '#lblCountry1');
                } else {
                    ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
                    ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName1');
                    ShowCountry(path, h.InvCountry, '#lblCountry');
                    ShowCountry(path, h.InvCountry, '#lblCountry1');
                }
            
                $('#lblBLNo').text(h.BLNo);
                $('#lblTotalQtyText').text(CNumEng(h.InvProductQty) + ' ' + h.InvProductUnit + ' ONLY');
                $('#lblETADate').text(ShowDate(h.ETADate));
                var Showinv = false; 
                if (confirm("Print PO/Commercial Invoice?") == true) {
                    Showinv = true;
                }
                let html = '';
                html += '<div style="width:100%;text-align:center;font-size:11px">"SHIPPER LOAD & COUNT & SEAL"<br/>"SAID TO CONTAIN ('+ h.TransMode +')"</div>';
                html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:12px">';
                html += '<div style="width:20%;">'+ CStr(h.Remark) +'</div>';
                html += '<div style="width:15%;">' + h.InvProductQty + ' ' + $('#lblProductUnit').text() + '</div>';
                html += '<div style="width:35%;">' + h.InvProduct + '<br/>' + h.ProjectName;
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

                html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:12px">';
                html += '<div style="width:45%;"><u>CONTAINER & SEAL</u></div>';
                html += '<div style="width:25%;"><u>QTY & PACKAGES</u></div>';
                html += '<div style="width:15%;"><u>G.W.</u></div>';
                html += '<div style="width:15%;"><u>MEASUREMENT</u></div>';
                html += '</div>';
                let i = 0;
                for (i = 0; i < r.booking.data.length; i++){
                    let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:12px">';
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
                html += '<div style="font-size:12px;"><br/>TOTAL (' + (i) + ') CONTAINER(s)';
                html += '<br/> TOTAL PACKAGES ' + CNumEng(h.InvProductQty) + ' ' + $('#lblProductUnit').text() + ' ONLY';
                html += '</div>';
                $('#dvDetail').html(html);
            }
        });
    }
</script>
