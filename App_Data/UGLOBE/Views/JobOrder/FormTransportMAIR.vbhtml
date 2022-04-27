@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
    body {
        font-size:8px;
    }
    table,td,th {
        padding:5px 5px 5px 5px;
        vertical-align:top;
    }

    .bottom {
    }
    .top-right {
    }

    .top-left {
    }
    #dvFooter, #pFooter {
        display: none;
    }
</style>
<div style="display:flex;width:100%;">
    <div style="flex:1;text-align:left">
        <label id="lblMAWB" style="font-weight:bold"></label>
    </div>
    <div style="flex:1;text-align:center">
        <label id="lblHAWB" style="font-size:12px;display:none"></label>
    </div>
</div>
<table  style="width:100%;">
    <tr>
        <td colspan="7" style="width:45%;height:60px;" rowspan="2">
            <br/>
            <div>
                <label id="lblShipperName"></label>
                <br />
                <label id="lblShipperAddress1"></label>
                <br />
                <div id="lblShipperAddress2"></div>
            </div>
        </td>
        <td colspan="7" style="width:55%;">
            <div style="display:flex;width:80%;">
                <div style="flex:1">
                    <br />
                    <br />                    
                    <br />                    
                    <br/>
                    <br/>
                </div>
                <div style="text-align:center;flex:2">
                    <label id="lblForwarderName"></label>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="7" style="font-size:8px">
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="7" style="height:60px;">
            <br />
            <div>
                <label id="lblConsigneeName"></label>
                <br />
                <label id="lblConsignAddress1"></label>
                <br />
                <div id="lblConsignAddress2"></div>
            </div>
        </td>
        <td colspan="7" style="font-size:8px">
            <br />
            <br />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="7" style="height:80px;">
            <br />
            <div>
                <label id="lblDeliveryTo"></label><br />
                <div id="lblDeliveryAddr"></div>
            </div>
        </td>
        <td colspan="7" rowspan="2">
            <br />
            <div>
                <label id="lblNotifyName"></label>
                <br />
                <label id="lblNotifyAddress1"></label>
                <br />
                <label id="lblNotifyAddress2"></label>
            </div>

        </td>
    </tr>
    <tr>
        <td colspan="3">
            <br />
            <br />
            <label id="lblFactoryContact"></label>
        </td>
        <td colspan="4">
            <br />
            <br/>
            <label id="lblPackingContact"></label>
        </td>
    </tr>
    <tr>
        <td colspan="7">
            <br />
            <br/>
            <label id="lblPackingPlace"></label>
        </td>
        <td colspan="7">
            <br />
            <div style="display:flex;width:100%;">
                <div style="flex:1">
                    <label id="lblPoNo"></label>
                </div>
                <div style="flex:1">
                    <label id="lblServiceMode"></label>
                </div>
                <div style="flex:1">
                    <label id="lblPackingDate"></label>
                </div>
            </div>

        </td>
    </tr>
    <tr>
        <td>
            <br/>
            <label id="lblClearPortName"></label>
        </td>
        <td>
            <br/>
            <label id="lblMVesselName"></label>
        </td>
        <td>
            <br/>
            <label id="lblInvInterPort"></label>
        </td>
        <td>
            <br/>
            <label id="lblCarrierCode"></label>
        </td>
        <td>
            <br/>
            <label id="lblCarrierPlace"></label>
        </td>
        <td>
            <br/>
            <label id="lblCarrierContact"></label>
        </td>
        <td>
            <br/>
            <label id="lblInvCurrency"></label>
        </td>
        <td>
            <br/>
            <label id="lblBLNo"></label>
        </td>
        <td colspan="2">
            <br/>
            <div style="display:flex;width:100%;">
                <div style="flex:1;text-align:center;">
                    <br />
                    <label id="lblWP"></label>
                </div>
                <div style="flex:1;text-align:center;">
                    <br />
                    <label id="lblWC"></label>
                </div>
            </div>
        </td>
        <td colspan="2">
            <br />
            <div style="display:flex;width:100%;">
                <div style="flex:1;text-align:center;">
                    <br />
                    <label id="lblOP"></label>
                </div>
                <div style="flex:1;text-align:center;">
                    <br />
                    <label id="lblOC"></label>
                </div>
            </div>
        </td>
        <td style="text-align:center">
            <br/>
            NVD
        </td>
        <td style="text-align:center">
            <br/>
            NCV
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <br/>
            <label id="lblFactoryPlace"></label>
        </td>
        <td colspan="4">
            <br />
            <div style="width:100%;display:flex;">
                <div style="flex:1">
                    <label id="lblMVesselName2"></label>
                </div>
                <div style="flex:1">
                    <label id="lblVesselName"></label>
                </div>
            </div>
        </td>
        <td colspan="4">
            <br/>
            <label id="lblPaymentBy"></label>
        </td>
        <td colspan="3" style="font-size:8px;">
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="13" style="border-right:none;">            
            <br />   
            <label id="lblRemark"></label>
        </td>
        <td style="padding:0;border-left:none;border-right:none;border-top:none;border-bottom:none;vertical-align:bottom;text-align:right;">
            <label id="lblShippingCmd"></label>
            <br/>
            <div style="border-style:solid;border-collapse:collapse;border-width:thin;text-align:center;border-right:none;border-bottom:none;">
                <br/>
                <label id="lblSCI"></label>
            </div>
        </td>
    </tr>
</table>
<table  style="width:100%;">
    <tr>
        <td>
        </td>
        <td style="width:10%;">
        </td>
        <td>
        </td>
        <td>

        </td>
        <td>
        </td>
        <td>
        </td>
        <td></td>
        <td>
        </td>
        <td>

        </td>
        <td>
        </td>
        <td>

        </td>
        <td style="width:15%;">
        </td>
        <td>

        </td>
        <td style="width:40%;">
        </td>
    </tr>    
    <tr style="height:200px;">
        <td>
            <div id="dvDetail" style="position:absolute;width:720px"></div>
        </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>
<table  style="width: 100%;">
    <tr style="vertical-align:top;">
        <td style="width:20%;">
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:20%;">
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:60%;" colspan="3" rowspan="3">
            <br/>            
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td colspan="3" rowspan="3">
            <br />
            <div style="text-align:center">
                <br /><br /><br />
                <label id="lblForwarderName2" style="font-size:10px;"></label>
            </div>
            <div style="width:100%;text-align:center;border-top:solid;border-width:thin;">
                <br />
            </div>
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td colspan="3" rowspan="2">
            <div style="display:flex;width:100%;">
                <div style="flex:1">
                    <br /><br /><br />
                    <label id="lblBookingDate" style="text-decoration:underline"></label>
                    <br />
                </div>
                <div style="flex:2">
                    <br /><br /><br />
                    <label id="lblPackingPlace2" style="text-decoration:underline"></label>
                    <br/>
                </div>
                <div style="flex:2">
                    <br /><br /><br />
                    <label id="lblTransportName" style="text-decoration:underline"></label>
                    <br/>
                </div>
            </div>
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td style="text-align:center"></td>
        <td>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:20%;">
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:40%;" colspan="2">
            <label id="lblAWBNo"></label>
        </td>
    </tr>
</table>
<script type="text/javascript">
    let br = getQueryString("Branch");
    let doc = getQueryString("Code");
    var path = '@Url.Content("~")';
    var units=[];
    $.get(path + 'Master/GetCustomsUnit').done(function(m) {
	units=m.customsunit.data;
	LoadData();
    });
    function LoadData() {
$.get(path + 'JobOrder/GetBooking?Branch=' + br + '&MAWB=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#lblMAWB').text(h.MAWB);
            $('#lblHAWB').text(h.HAWB);
            $('#lblAWBNo').text(h.HAWB);
            $('#lblBLNo').text(h.BLNo);
            if (CStr(h.BLNo).substr(0, 1) == 'P') $('#lblWP').text('X');
            if (CStr(h.BLNo).substr(0, 1) == 'C') $('#lblWC').text('X');
            if (CStr(h.BLNo).substr(1, 1) == 'P') $('#lblOP').text('X');
            if (CStr(h.BLNo).substr(1, 1) == 'C') $('#lblOC').text('X');
                
            $('#lblDeliveryTo').text(h.DeliveryTo);
            $('#lblDeliveryAddr').html(CStr(h.DeliveryAddr));
            $('#lblTransMode').text(h.TransMode);
            $('#lblPoNo').text(h.CustRefNO);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text(h.PaymentCondition);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));            
            $('#lblCarrierCode').text(h.CarrierCode);
            $('#lblCarrierPlace').text(h.CYAddress);
            $('#lblCarrierContact').text(h.CYContact);
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(h.ShipperAddress1);
            $('#lblShipperAddress2').html(CStr(h.ShipperAddress2));
            $('#lblConsigneeName').text(h.ConsigneeName);
            $('#lblConsignAddress1').text(h.ConsignAddress1);
            $('#lblConsignAddress2').html(CStr(h.ConsignAddress2));
            $('#lblNotifyName').text(h.NotifyName);
            $('#lblNotifyAddress1').text(h.NotifyAddress1);
            $('#lblNotifyAddress2').text(h.NotifyAddress2);
            $('#lblVesselName').text(h.VesselName);
            $('#lblMVesselName').text(h.MVesselName);
            $('#lblMVesselName2').text(h.MVesselName);
            $('#lblPackingPlace').text(h.CYPlace);
            $('#lblPackingPlace2').text(h.CYPlace);
            $('#lblClearPortName').text(h.ClearPortNo);
            $('#lblTransportName').text(h.PackingPlace);
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblForwarderName2').text(h.ForwarderName);
            let unit=units.filter(function(data){
               return data.Code==h.InvProductUnit;
             });
            if(unit.length>0) {
               $('#lblProductUnit').text(unit[0].TName);
            } else {
               $('#lblProductUnit').text(h.InvProductUnit);
            }
            $('#lblInvInterPort').text(h.InvInterPort);

            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblReturnPlace').text(h.ReturnPlace);
            $('#lblFactoryContact').text(h.FactoryContact);
            $('#lblPackingContact').text(h.PackingContact);
            $('#lblPackingAddress').text(h.PackingAddress);
            $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
            $('#lblRemark').text(CStr(h.Description));
            $('#lblServiceMode').text(h.TRemark);
            $('#lblInvCurrency').text(h.InvCurUnit);
            $('#lblShippingCmd').text(h.ShippingCmd);
            if (h.ShippingCmd !== '') {
                $('#lblSCI').text('X');
            } else {
                $('#lblShippingCmd').text('\n');
            }
            $('#lblPackingDate').text((h.JobType==1 ?'ETA:':'ETD:') + CDateEN(h.PackingDate) + ' ' + ShowTime(h.PackingTime));

            let html = '';
            //html += '<div style="width:100%;text-align:center;font-size:10px">"SHIPPER LOAD & COUNT & SEAL"</div>';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            let i = 0;
            let htmlSub1 = '';
            let htmlSub2 = '<div style="width:100%;display:flex;">';
            let tqty = 0;
            let tprice = 0;
            let tweight = 0;
            for (i = 0; i < r.booking.data.length; i++) {
                htmlSub1 += r.booking.data[i].CTN_NO + ' / ' + r.booking.data[i].ProductQty;
                htmlSub1 += '<br/>';
                tqty += Number(r.booking.data[i].ProductQty);
                tweight += Number(r.booking.data[i].GrossWeight);
                tprice += Number(r.booking.data[i].ProductPrice);
            }
            htmlSub2 += '<div style="flex:5%;text-align:right;">' + tqty + '</div>';
            htmlSub2 += '<div style="flex:15%;text-align:right;">' + CDbl(tweight,2) + '</div>';
            htmlSub2 += '<div style="flex:3%;text-align:right;">K</div>';
            htmlSub2 += '<div style="flex:2%;text-align:right;"></div>';
            htmlSub2 += '<div style="flex:5%;text-align:right;">Q</div>';
            htmlSub2 += '<div style="flex:13%;text-align:right;">-</div>';
            htmlSub2 += '<div style="flex:14%;text-align:right;">' + CDbl(tweight,2) + '</div>';
            htmlSub2 += '<div style="flex:3%;text-align:right;"></div>';
            htmlSub2 += '<div style="flex:10%;text-align:right;">' + ShowNumber(tprice, 2) + '</div>';
            if (tprice > 0) {
                htmlSub2 += '<div style="flex:25%;text-align:right;">' + ShowNumber(tprice*tweight,2) + '</div>';
            } else {
                htmlSub2 += '<div style="flex:25%;text-align:right;">' + h.PaymentCondition + '</div>';
            }
            htmlSub2 += '<div style="flex:5%;text-align:right;"></div>';
            htmlSub2 += '</div>';
            htmlSub2 += '<br/>' + CStr(h.Remark);
            html += '<div style="width:65%;">' + htmlSub2 + '</div>';
            html += '<div style="width:35%;">' + CStr(h.ProjectName + '<br/>' + h.InvProduct) + '<br/>';
            html += '<br/>DIM:<br/>';

            html += htmlSub1;
            html += '</div>';
            html += '</div>';
            $('#dvDetail').html(html);
        }
    });
    }
</script>
