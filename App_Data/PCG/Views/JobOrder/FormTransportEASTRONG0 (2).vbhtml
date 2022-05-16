@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
    body {
        font-size: 9px;
    }

    table {
        border-collapse: collapse;
    }

    td {
        vertical-align: top;
    }

    .left {
        border-collapse: collapse;
        border-left: solid;
        border-width: thin;
    }

    .right {
        border-collapse: collapse;
        border-right: solid;
        border-width: thin;
    }

    .top-right {
        border-collapse: collapse;
        border-top: solid;
        border-right: solid;
        border-width: thin;
    }

    .top-left {
        border-collapse: collapse;
        border-top: solid;
        border-left: solid;
        border-width: thin;
    }

    .bottom-right {
        border-collapse: collapse;
        border-bottom: solid;
        border-right: solid;
        border-width: thin;
    }

    .bottom-left {
        border-collapse: collapse;
        border-bottom: solid;
        border-left: solid;
        border-width: thin;
    }

    .top {
        border-collapse: collapse;
        border-top: solid;
        border-width: thin;
    }
    .bodered{
        border : 1px solid black;
    }
    .vbodered {
        border-left: 1px solid black;
        border-right: 1px solid black;
    }
    #dvFooter, #pFooter {
        display: none;
    }
</style>
<p>
    <table style="width:100%">
        <tr>
            <td class="bodered" style="height:100px;width:40%;" colspan="2">
                <b>Shipper</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <div id="lblShipperAddress2"></div>
                </div>
            </td>
            <td class="bodered" style="width: 30%;" rowspan="2">
                <p> RECEIVED  by the Carrier the Goods as specified above in apparent good order and condition unless otherwise stated, to be transported to such place as agreed, authorized or permitted herein and subject to all the terms and conditions appearing on the  front and reverse of the of Bill of Lading, any local  privileges and customer notwithstanding</p>

                <p>     The particulars given bellows as stated by the shipper and the weight, measure, quanlity, condition, contents and value of the Goods are unknown to the Carrier.</p>

                <p>          In WITNESS whereof one (1) original Bill of Lading has been signed if not otherwise stated blow, the same being accomplished the other(s), if any, to be void. If required by the Carrier one (1) original Bill of Lading must be surrendered duly endorsed in exchange for the Goods for delivery order.</p>

            </td>
            <td class="bodered" style="width:30%" rowspan="2" colspan="2">
                <div>     BILL OF LANDING NO</div>

            </td>
        </tr>
        <tr>
            <td class="bodered" style="height:100px" colspan="2">
                <b>Consignee</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblConsigneeName"></label>
                    <br />
                    <label id="lblConsignAddress1"></label>
                    <br />
                    <div id="lblConsignAddress2"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bodered" style="height:100px;" rowspan="2" colspan="2">
                <b>Notify Party</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </td>
            <td class="bodered" style="height:100px;" rowspan="2">
                <b>Also Notify Party</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </td>
            <td class="bodered" colspan="2">
                Place and Date of issue
                <br />
                <label id="lblBookingDate"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="bodered">
                No. of Original B/L(s)
                <div>
                    <label id="lblBLNo"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bodered" colspan="2">
                <b>Place of Receipt</b>
                <div>
                    <label id="lblPackingPlace"></label>
                </div>
            </td>
            <td class="bodered">
                <b>Port of Loading</b>
                <div>
                    <label id="lblFactoryPlace"></label>
                </div>
            </td>
            <td class="bodered" colspan="2">
                <b>Pre-Carriage By</b>
                <div>
                    <label id="lblMVesselName"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td class="bodered" colspan="2">
                <b>Place of Delivery</b>
                <div>
                    <label id="lblInterPortName"></label>,<label id="lblCountryName"></label>
                </div>
            </td>
            <td class="bodered">
                <b>Port of Discharge</b>
                <div>
                    <label id="lblDischargePlace"></label>
                </div>
            </td>
            <td class="bodered">
                <b>Vessel / Voy.No.</b>
                <div>
                    <label id="lblVesselName"></label>
                </div>
            </td>
        </tr>

        @*<tr style="height:30px;">
                <td class="top" style="width:25%;">
                    <b>Pre-Carriage By</b>
                    <div>
                        <label id="lblMVesselName"></label>
                    </div>
                </td>
                <td class="top" style="width:25%;">
                    <b>Place of Receipt</b>
                    <div>
                        <label id="lblPackingPlace"></label>
                    </div>
                </td>
                <td class="top" style="width:50%;" rowspan="2" colspan="2">
                    <b>For delivery of Goods please apply to:</b>
                    <div style="padding:5px 5px 5px 5px">
                        <label id="lblDeliveryTo"></label><br />
                        <div id="lblDeliveryAddr"></div>
                    </div>
                </td>
            </tr>
            <tr style="height:30px;">
                <td class="top" style="width:25%;">
                    <b>Vessel / Voy.No.</b>
                    <div>
                        <label id="lblVesselName"></label>
                    </div>
                </td>
                <td class="top" style="width:25%;">
                    <b>Port of Loading</b>
                    <div>
                        <label id="lblFactoryPlace"></label>
                    </div>
                </td>
            </tr>
            <tr style="height:30px;">
                <td class="top" style="width:25%;">
                    <b>Port of Discharge</b>
                    <div>
                        <label id="lblDischargePlace"></label>
                    </div>
                </td>
                <td class="top" style="width:25%;">
                    <b>Place of Delivery</b>
                    <div>
                        <label id="lblInterPortName"></label>,<label id="lblCountryName"></label>
                    </div>
                </td>
                <td class="top" style="width:50%;">
                    <b>Excess Limit Declaration as per Clause 16</b>
                </td>
            </tr>*@
    </table>
    <table style="width:100%" class="bodered">
        <thead>
            <tr>
                <th class="bodered" style="width:20%;text-align:center">MARKS AND NUMBERS<br />CONTAINER NO/SEAL NO</th>
                <th class="bodered" style="width: 20%; text-align: center">NO OF PACKAGE OR CONTAINER</th>
                <th class="bodered" style="width: 30%; text-align: center">KIND OF PACKAGE & DESCRIPTION OF GOODS</th>
                <th class="bodered" style="width: 15%; text-align: center">GROSS WEIGHT </th>
                <th class="bodered" style="width: 15%; text-align: center">MEASUREMENT</th>
            </tr>
        </thead>
        <tbody id="dvDetail">
        </tbody>
    </table>
    <table style="width:100%" class="bodered">
        <tbody>
            <tr>
                <td class="vbodered" style="width:40%">SHIPPED ON BOARD DATE :</td>
                <td class="vbodered" style="width:30%">PAYABLE AT :</td>
                <td class="vbodered" style="width:30%; text-align:center;" colspan="2">FREIGHT AND CHARGE</td>
            </tr>
            <tr>
                <td  class="vbodered">PLACE :</td>
                <td class="vbodered"></td>
                <td class="bodered" style="text-align:center">PREPAID</td>
                <td class="bodered" style="text-align:center">COLLECT</td>
            </tr>
            <tr>
                <td class="vbodered"><br /></td>
                <td class="vbodered"></td>
                <td class="vbodered"></td>
                <td class="vbodered"></td>
            </tr>
            <tr>
                <td class="vbodered" style="width:40%">FOR DELIVERY OF GOODS, PLEASE APPLY TO :</td>
                <td colspan="3"></td>
            </tr>
        </tbody>
    </table>
    <label id="lblProductUnit" style="display:none;"></label>
    @*<table style="width:100%">
            <tr>
                <td class="bottom top" colspan="7" style="width:100%;text-align: center;">
                    <b>The below particulars of the goods are according to the declaration of the shipper,and are unknown to the Carrier</b>
                </td>
            </tr>
            <tr>
                <td class="bottom top" style="width:10%;">
                    <b>Container No.</b>
                </td>
                <td class="bottom top" style="width:15%;">
                    <b>Seal No.<br />Marks and Numbers</b>
                </td>
                <td class="bottom top" style="width:10%;">
                    <b>No.Of Containers<br />Of Pkgs</b>
                </td>
                <td class="bottom top" style="width:15%;">
                    <b>Kinds Of Packages</b>
                </td>
                <td class="bottom top" style="width:20%;">
                    <b>Description Of Goods</b>
                </td>
                <td class="bottom top" style="width:15%;">
                    <b>Gross Weight</b>
                </td>
                <td class="bottom top" style="width:15%;">
                    <b>Measurement</b>
                </td>
            </tr>
            <tr style="height:360px;">
                <td colspan="7" id="dvDetail" class="bottom">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    TOTAL No.Of Containers or Packages<br/> (In Words)
                </td>
                <td colspan="5">
                    <label id="lblSumQty"></label>
                    <label id="lblProductUnit" style="display:none;"></label>
                </td>
            </tr>
        </table>
        <table style="width:100%">
            <tr class="top">
                <td colspan="2">
                    Freight And Charges
                    <div>
                        <label id="lblPaymentCondition"></label>
                    </div>
                </td>
                <td>
                    Revenue Tons
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td>
                    Rate
                </td>
                <td>
                    Per
                </td>
                <td>
                    Prepaid
                </td>
                <td class="left">
                    Collect
                </td>
            </tr>
            <tr>
                <td class="top-right">
                    Ex.Rate
                </td>
                <td colspan="2" class="top-right">
                    Prepaid At
                </td>
                <td colspan="2" class="top-right">
                    Payable At
                    <br />
                    <label id="lblPaymentBy"></label>
                </td>
                <td colspan="2" class="top-left">
                    Place and Date of issue
                    <br/>
                    <label id="lblBookingDate"></label>
                </td>
            </tr>
            <tr>
                <td class="top-right">
                    <label id="lblExchangeRate"></label>
                </td>
                <td colspan="2" class="top-right">
                    Total Prepaid in local Currencys
                </td>
                <td colspan="2" class="top-right">
                    No. of Original B/L(s)
                    <div>
                        <label id="lblBLNo"></label>
                    </div>
                </td>
                <td colspan="2" rowspan="2" class="top-left">
                    Stamp / Signature of the Carrier or its agent
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="top-right">
                    SHIPPED on board the vessel
                    <br />
                    Date
                    <br />
                    <div style="text-align:center">
                        <label id="lblLoadDate"></label>
                    </div>
                </td>
                <td colspan="3" class="top-left">

                </td>
            </tr>
        </table>*@
</p>
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
            $('#lblMAWB').text(h.MAWB);
            $('#lblHAWB').text(h.HAWB);
            $('#lblBLNo').text(h.BLNo);
            $('#lblDeliveryTo').text(h.DeliveryTo);
            $('#lblDeliveryAddr').html(CStr(h.DeliveryAddr));
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
            $('#lblLoadDate').text(ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(CStr(h.ShipperAddress1));
            $('#lblShipperAddress2').html(CStr(h.ShipperAddress2));
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress1').text(CStr(h.ConsignAddress1));
            $('#lblConsignAddress2').html(CStr(h.ConsignAddress2));
            $('#lblNotifyName').text(h.NotifyName);
            $('#lblNotifyAddress1').text(h.NotifyAddress1);
            $('#lblNotifyAddress2').text(h.NotifyAddress2);
            $('#lblVesselName').text(h.VesselName);
            $('#lblMVesselName').text(h.MVesselName);
            $('#lblPackingPlace').text(h.CYPlace);

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
                ShowCountry(path, h.InvFCountry, '#lblCountryName');
            } else {
                ShowCountry(path, h.InvCountry, '#lblCountryName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
            }
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblRouting').text(h.FactoryAddress);
            $('#lblReturnPlace').text(h.ReturnPlace);
            $('#lblReturnAddress').text(h.ReturnAddress);
            $('#lblPickupPlace').text(h.CYAddress);
            $('#lblDischargePlace').text(h.ClearPortNo);
            $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
            $('#lblServiceMode').text(h.TRemark);
            $('#lblInvCurRate').text(h.InvCurRate);
            $('#lblSumQty').text(CNumEng(h.InvProductQty).replace('ONLY', '') + ' ' + $('#lblProductUnit').text() + ' ONLY');
            let html = ''
            let row = $('<tr></tr>');
            row.append($('<td class="vbodered">' + CStr(h.Remark) + '</td>'));
            row.append($('<td class="vbodered">' + h.InvProductQty + ' ' + $('#lblProductUnit').text() + '</td>'));
            row.append($('<td class="vbodered">' + h.InvProduct + '<br/>' + CStr(h.ProjectName) + '</td>'));
            row.append($('<td class="vbodered>' + 'G.W ' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit  + '</td>'));
           // row.append($('<td>' + 'N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit + '</td>'));
            row.append($('<td class="vbodered">' + h.TotalM3 +' M3' + '</td>'));
            $('#dvDetail').append(row);
            let tmprow = $('<tr></tr>');
            tmprow.append($('<td class="vbodered">Detail</td><td class="vbodered"></td><td class="vbodered"></td><td class="vbodered"></td>'));
            $('#dvDetail').append( tmprow);
            for (i = 0; i < r.booking.data.length; i++){
                let row2 = $('<tr></tr>');
                row2.append($('<td class="vbodered">' + r.booking.data[i].CTN_NO + '<br />' + r.booking.data[i].SealNumber + '</td>'));
                row2.append($('<td class="vbodered">' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + '</td>'));
                row2.append($('<td class="vbodered">' + r.booking.data[i].CTN_SIZE + '</td>'));
                row2.append($('<td class="vbodered">' + r.booking.data[i].GrossWeight + ' ' + h.GWUnit + '</td>'));
                row2.append($('<td class="vbodered">' + r.booking.data[i].Measurement + ' M3' + '</td>'));
             
                $('#dvDetail').append(row2);
                //let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                //htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].CTN_NO +'</div>';
                //htmlTemplate += '<div style="width:15%;">' + r.booking.data[i].SealNumber +'</div>';
                //htmlTemplate += '<div style="width:5%;">' + r.booking.data[i].CTN_SIZE +'</div>';
                //htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].GrossWeight + ' ' + h.GWUnit +'</div>';
                //htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].Measurement + ' M3</div>';
                //htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + '</div>';                
                //htmlTemplate += '<div style="width:10%;">'+h.TransMode+'</div>';
                //htmlTemplate += '</div>';

                //html += htmlTemplate;
            }
            
            //html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            //html += '<div style="width:25%;padding:5px 5px 5px 5px;">'+ CStr(h.Remark) +'</div>';
            //html += '<div style="width:10%;padding:5px 5px 5px 5px;">' + h.InvProductQty + '<br/>' + $('#lblProductUnit').text() + '</div>';
            //html += '<div style="width:30%;padding:5px 5px 5px 5px;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
            //html += '</div>';
            //html += '<div style="width:20%;padding:5px 5px 5px 5px;">G.W ' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit + '';
            //if(h.TotalNW>0)  {
            //    html += '<br/>N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit;
            //}
            //html +='</div>';
            //html += '<div style="width:15%;text-align:center;padding:5px 5px 5px 5px;">'+ h.TotalM3 +' M3</div>';
            //html += '</div>';

            //html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px;margin:5px 5px 5px 5px;">';
            //html += '<div style="width:10%;">Container</div>';
            //html += '<div style="width:15%;">Seal</div>';
            //html += '<div style="width:5%;">Type</div>';
            //html += '<div style="width:10%;">Weight</div>';
            //html += '<div style="width:10%;">Volume</div>';
            //html += '<div style="width:10%;">Package</div>';
            //html += '<div style="width:10%;">Mode</div>';
            //html += '</div>';
            //let i = 0;
            //for (i = 0; i < r.booking.data.length; i++){
            //    let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
            //    htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].CTN_NO +'</div>';
            //    htmlTemplate += '<div style="width:15%;">' + r.booking.data[i].SealNumber +'</div>';
            //    htmlTemplate += '<div style="width:5%;">' + r.booking.data[i].CTN_SIZE +'</div>';
            //    htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].GrossWeight + ' ' + h.GWUnit +'</div>';
            //    htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].Measurement + ' M3</div>';
            //    htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + '</div>';                
            //    htmlTemplate += '<div style="width:10%;">'+h.TransMode+'</div>';
            //    htmlTemplate += '</div>';

            //    html += htmlTemplate;
            //}
            ////html += '<br/> TOTAL No.Of Containers or Packages (In Words) : ' + CNumEng(h.InvProductQty).replace('ONLY','') + ' ' + $('#lblProductUnit').text() + ' ONLY';
            //html += '</div>';
         /*   $('#dvDetail').html(html);*/
         
        }
    });
    }
</script>