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
        border-width: thin;
        border-collapse: collapse;
        padding:5px 5px 5px 5px;
        vertical-align:top;
    }

    .bottom {
        border-collapse: collapse;
        border-bottom: solid;
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
    #dvFooter, #pFooter {
        display: none;
    }
</style>
<div style="display:flex;width:100%;">
    <div style="flex:1;text-align:left">
        <label id="lblMAWB" style="font-weight:bold"></label>
    </div>
    <div style="flex:1;text-align:center">
        <label id="lblHAWB" style="font-size:12px;"></label>
    </div>
</div>
<table border="1" style="width:100%;">
    <tr>
        <td colspan="7" style="width:45%;height:60px;" rowspan="2">
            Shipper's name and address
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
                    Not Negotiable
                    <br />
                    <span style="font-size:14px;"><b>Air Waybill</b></span>
                    <br />
                    Issue By
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
            Copied 1,2 and 3 of this Air way bill are originals and have the same validity.
        </td>
    </tr>
    <tr>
        <td colspan="7" style="height:60px;">
            Consignee's name and address
            <div>
                <label id="lblConsigneeName"></label>
                <br />
                <label id="lblConsignAddress1"></label>
                <br />
                <div id="lblConsignAddress2"></div>
            </div>
        </td>
        <td colspan="7" style="font-size:8px">
            It is agreed that the Goods described herein are accepted in apparent good order and condition (except as noted) for carriage SUBJECT TO THE CONDITIONS OF CONTRACT ON THE REVERSE HEREOF ALL GOODS MAYBE CARRIED BY ANY OTHER MEANS INCLUDING ROAD OR ANY OTHER CARRIER UNLESS SPECIFIC CONTRARY INSTRUCTION ARE GIVEN HEREON BY THE SHIPPER,
            AND SHIPPER AGREES THAT THE SHIPMENT MAYBE CARRIED VIA INTERMEDIATED STOPPING PLACES WHICH THE CARRIER DEEM APPROPRIATED. THE SHIPPER'S ATTENTION IS DRAWN TO THE NOTICE CONCERNING CARRIER'S LIMITATION OF LIABILITY. Shipper may increse such limitation of liability by declaring a higher value for carriage and paying a supplemental charge if required.
        </td>
    </tr>
    <tr>
        <td colspan="7" style="height:80px;">
            Issuring carrier's agent name and city
            <div>
                <label id="lblDeliveryTo"></label><br />
                <div id="lblDeliveryAddr"></div>
            </div>
        </td>
        <td colspan="7" rowspan="2">
            Accounting information
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
            Agent's IATA Code
            <br />
            <label id="lblFactoryContact"></label>
        </td>
        <td colspan="4">
            Account No
            <br/>
            <label id="lblPackingContact"></label>
        </td>
    </tr>
    <tr>
        <td colspan="7">
            Airport of Departure (Addr. Of First Carrier) and requested routing
            <br/>
            <label id="lblPackingPlace"></label>
        </td>
        <td colspan="7">
            Optional Shipping Information
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
            To:
            <br/>
            <label id="lblClearPortName"></label>
        </td>
        <td>
            By First Carrier
            <br/>
            <label id="lblMVesselName"></label>
        </td>
        <td>
            To
            <br/>
            <label id="lblInvInterPort"></label>
        </td>
        <td>
            By
            <br/>
            <label id="lblCarrierCode"></label>
        </td>
        <td>
            To
            <br/>
            <label id="lblCarrierPlace"></label>
        </td>
        <td>
            By
            <br/>
            <label id="lblCarrierContact"></label>
        </td>
        <td>
            Currency
            <br/>
            <label id="lblInvCurrency"></label>
        </td>
        <td>
            CHGS Code
            <br/>
            <label id="lblBLNo"></label>
        </td>
        <td colspan="2">
            WT/VAL
            <br/>
            <div style="display:flex;width:100%;">
                <div style="flex:1;text-align:center;">
                    PPD/
                    <br />
                    <label id="lblWP"></label>
                </div>
                <div style="flex:1;text-align:center;">
                    COLL
                    <br />
                    <label id="lblWC"></label>
                </div>
            </div>
        </td>
        <td colspan="2">
            Others
            <br />
            <div style="display:flex;width:100%;">
                <div style="flex:1;text-align:center;">
                    PPD/
                    <br />
                    <label id="lblOP"></label>
                </div>
                <div style="flex:1;text-align:center;">
                    COLL
                    <br />
                    <label id="lblOC"></label>
                </div>
            </div>
        </td>
        <td style="text-align:center">
            Declare Value For Carriage
            <br/>
            NVD
        </td>
        <td style="text-align:center">
            Declare value for Customs
            <br/>
            NCV
        </td>
    </tr>
    <tr>
        <td colspan="3">
            Airport of Destination
            <br/>
            <label id="lblFactoryPlace"></label>
        </td>
        <td colspan="4">
            Requested Flight/Date
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
            Amount of Insurance
            <br/>
            <label id="lblPaymentBy"></label>
        </td>
        <td colspan="3" style="font-size:8px;">
            INSURANCE - If Carrier offers insurance,and such insurance is requested in accordance with the condition thereof,indicate amount to be insured in figures in box marked "Amount of insurance"
        </td>
    </tr>
    <tr>
        <td colspan="13" style="border-right:none;">
            Handling Information
            <br />   
            <label id="lblRemark"></label>
        </td>
        <td style="padding:0;border-left:none;border-right:none;border-top:none;border-bottom:none;vertical-align:bottom;text-align:right;">
            <label id="lblShippingCmd"></label>
            <br/>
            <div style="border-style:solid;border-collapse:collapse;border-width:thin;text-align:center;border-right:none;border-bottom:none;">
                SCI
                <br/>
                <label id="lblSCI"></label>
            </div>
        </td>
    </tr>
</table>
<table border="1" style="width:100%;">
    <tr>
        <td>
            No Of 
            Pieces RCP
        </td>
        <td style="width:10%;">
            Gross Weight
        </td>
        <td>
            Kg lb
        </td>
        <td>

        </td>
        <td>
            Rate Class            
        </td>
        <td>
            Commodity Item No
        </td>
        <td></td>
        <td>
            Chargeable Weight
        </td>
        <td>

        </td>
        <td>
            Rate/Charges
        </td>
        <td>

        </td>
        <td style="width:15%;">
            Total
        </td>
        <td>

        </td>
        <td style="width:40%;">
            Nature and Quantity of Goods (Incl. Dimension and Volume)
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
<table border="1" style="width: 100%;">
    <tr style="vertical-align:top;">
        <td style="width:20%;">
            <b>Weight Charge</b> : Prepaid
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:20%;">
            Collect
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:60%;" colspan="3" rowspan="3">
            Other Charges
            <br/>            
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <b>Valuable Charge</b> : Prepaid
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            Collect
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <b>Tax</b> : Prepaid
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            Collect
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <b>Other Charge (Agent)</b> : Prepaid
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            Collect
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td colspan="3" rowspan="3">
            Shipper Certifies that the particulars on the face hereof are correct and that insofar as any port of the consignment contain dangerous goods,such part is properly described by name and is in proper condition for carriage by air according to the applicable Dangerous Goods Regulations.
            <br />
            <div style="text-align:center">
                <br /><br /><br />
                <label id="lblForwarderName2" style="font-size:10px;"></label>
            </div>
            <div style="width:100%;text-align:center;border-top:solid;border-width:thin;">
                Signature of shipper or his agent
            </div>
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <b>Other Charge (Carrier)</b> : Prepaid
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            Collect
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
            <b>Total Prepaid</b>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <b>Total Collect</b>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td colspan="3" rowspan="2">
            <div style="display:flex;width:100%;">
                <div style="flex:1">
                    <br /><br /><br />
                    <label id="lblBookingDate" style="text-decoration:underline"></label>
                    <br />
                    Execute On (Date)
                </div>
                <div style="flex:2">
                    <br /><br /><br />
                    <label id="lblPackingPlace2" style="text-decoration:underline"></label>
                    <br/>
                    At (Place)
                </div>
                <div style="flex:2">
                    <br /><br /><br />
                    <label id="lblTransportName" style="text-decoration:underline"></label>
                    <br/>
                    Signature of issuring Carrier or its agent
                </div>
            </div>
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td>
            <b>Currency Conversion Rate</b>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td>
            <b>CC Charges In Dest.Currency</b>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
    </tr>
    <tr style="vertical-align:top;">
        <td style="text-align:center">For Carrier's Use Only At Destination</td>
        <td>
            <b>Charges At Destination</b>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:20%;">
            <b>Total Collect Charges</b>
            <br />
            <input type="text" style="border:none;text-align:right;font-size:9px;" value="" />
        </td>
        <td style="width:40%;" colspan="2">
            <label id="lblAWBNo"></label>
        </td>
    </tr>
</table>
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
