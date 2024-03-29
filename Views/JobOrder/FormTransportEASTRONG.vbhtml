﻿@Code
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

    #dvFooter, #pFooter {
        display: none;
    }
</style>
<p>
    <table style="width:100%">
        <tr>
            <td class="top" style="height:100px;width:50%;" colspan="2">
                <b>Shipper</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblShipperName"></label>
                    <br />
                    <label id="lblShipperAddress1"></label>
                    <br />
                    <div id="lblShipperAddress2"></div>
                </div>
            </td>
            <td class="top" style="width:50%;" rowspan="3" colspan="2">
                <div style="display:flex">
                    <div style="flex:1;text-align:center;">
                        <h1>BILL OF LADING</h1>
                    </div>
                    <div style="flex:1;text-align:left;" class="top-left bottom-right">
                        B/L No.
                        <br/>
                        <div style="text-align:center;width:100%">
                            <label id="lblHAWB" style="color:red;font-size:14px;"></label>
                        </div>
                    </div>
                </div>
                <div style="display:flex">
                    <div style="flex:1;">
                        <input type="text" style="text-align: center;border-style:none; width: 100%;" value="ORIGINAL" />
                    </div>
                    <div style="flex:1;text-align:center">
                        ORIGINAL BILL REQUIRED AT DESTINATION
                    </div>
                </div>
                <img src="~/Resource/logo-east.jpg" style="width:200px" />
                <div style="font-size:16px">
                    EASTRONG INTERNATIONAL LOGISTICS CO.,LTD
                </div>
                as the Carrier
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    RECEIVED by the Carrier in apparent good order and condition except as otherwise noted the goods below for shipment subject to the terms of this Bill of lading including those on the back page.
                    One of the Original Bill of Lading must be surrendered duty endorsed in exchange for the Goods of Delivery Order. IN WITNESS whereof the number of Original Bill of lading stated below have been signed. one of which having been accomplished the others to be void.
                    On presentation of this Document (duty endorsed) to the Carrier by or On behalf of the Holder,The rights and liablility arising in accordance with the terms hereof shall (without prejudice to any rule of common law or statute rendering them binding on the Merchant)
                    become binding in all respects between the Carrier and the Holder as though the contract evidence hereby has been made between them.
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    The Contract evidenced by this Bill of lading is governed by the Laws of the People's republic of China, Any Claim or dispute must be determined exclusively by the Courts in the People's republic of China and other courts'

                </div>

            </td>

        </tr>
        <tr>
            <td class="top" style="width:50%;height:100px;" colspan="2">
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
            <td class="top" style="width:50%;height:100px;" colspan="2">
                <b>Notify Party</b>
                <div style="padding:5px 5px 5px 5px">
                    <label id="lblNotifyName"></label>
                    <br />
                    <label id="lblNotifyAddress1"></label>
                    <br />
                    <label id="lblNotifyAddress2"></label>
                </div>
            </td>
        </tr>
        <tr style="height:30px;">
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
        </tr>
    </table>
    <table style="width:100%">
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
    </table>
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

            let html = '';
            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px">';
            html += '<div style="width:25%;padding:5px 5px 5px 5px;">'+ CStr(h.Remark) +'</div>';
            html += '<div style="width:10%;padding:5px 5px 5px 5px;">' + h.InvProductQty + '<br/>' + $('#lblProductUnit').text() + '</div>';
            html += '<div style="width:30%;padding:5px 5px 5px 5px;">' + h.InvProduct + '<br/>' + CStr(h.ProjectName);
            html += '</div>';
            html += '<div style="width:20%;padding:5px 5px 5px 5px;">G.W ' + ShowNumber(h.TotalGW,3) + ' ' + h.GWUnit + '';
            if(h.TotalNW>0)  {
                html += '<br/>N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit;
            }
            html +='</div>';
            html += '<div style="width:15%;text-align:center;padding:5px 5px 5px 5px;">'+ h.TotalM3 +' M3</div>';
            html += '</div>';

            html += '<div style="width:100%;display:flex;flex-direction:row;margin-bottom:5px;font-size:10px;margin:5px 5px 5px 5px;">';
            html += '<div style="width:10%;">Container</div>';
            html += '<div style="width:15%;">Seal</div>';
            html += '<div style="width:5%;">Type</div>';
            html += '<div style="width:10%;">Weight</div>';
            html += '<div style="width:10%;">Volume</div>';
            html += '<div style="width:10%;">Package</div>';
            html += '<div style="width:10%;">Mode</div>';
            html += '</div>';
            let i = 0;
            for (i = 0; i < r.booking.data.length; i++){
                let htmlTemplate = '<div style="width:100%;display:flex;flex-direction:row;font-size:10px">';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].CTN_NO +'</div>';
                htmlTemplate += '<div style="width:15%;">' + r.booking.data[i].SealNumber +'</div>';
                htmlTemplate += '<div style="width:5%;">' + r.booking.data[i].CTN_SIZE +'</div>';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].GrossWeight + ' ' + h.GWUnit +'</div>';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].Measurement + ' M3</div>';
                htmlTemplate += '<div style="width:10%;">' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + '</div>';                
                htmlTemplate += '<div style="width:10%;">'+h.TransMode+'</div>';
                htmlTemplate += '</div>';

                html += htmlTemplate;
            }
            //html += '<br/> TOTAL No.Of Containers or Packages (In Words) : ' + CNumEng(h.InvProductQty).replace('ONLY','') + ' ' + $('#lblProductUnit').text() + ' ONLY';
            html += '</div>';
            $('#dvDetail').html(html);
        }
    });
    }
</script>