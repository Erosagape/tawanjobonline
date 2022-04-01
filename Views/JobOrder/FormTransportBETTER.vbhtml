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
        padding: 5px 5px 5px 5px;
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

    .bodered {
        border: 1px solid black;
    }

    .vbodered {
        border-left: 1px solid black;
        border-right: 1px solid black;
    }

    #dvFooter, #pFooter {
        display: none;
    }
</style>

<div style="width:100%;">
    <img src="~/Resource/bft_blheader.png" style="width:100%" />

</div>
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
            <p> RECEIVED  by the Carrier the Goods as specified above in apparent good order and condition unless otherwise stated, to be transported to such place as agreed, authorised or permitted herein and subject to all the terms and conditions appearing on the  front and reverse of the of Bill of Lading,to Which the customer notwithstanding</p>

            <p>     The particulars given belows as stated by the shipper and the weight, measure, quanlity, condition, contents and value of the Goods are unknown to the Carrier.</p>

            <p>          In WITNESS whereof one (1) original Bill of Lading has been signed if not otherwise stated below, the same being accomplished the other(s), if any, to be void. If required by the Carrier one (1) original Bill of Lading must be surrendered duly endorsed in exchange for the Goods for delivery order.</p>

        </td>
        <td class="bodered" style="width:30%" rowspan="2" colspan="2">
            <div>
                <b>   BILL OF LADING NO :</b><label id="lblBookingNo"></label>
                <br />
                <br />
                <b>     BFT NO. </b><label id="lbljno"></label>
                <br />
                <br />
                <br />
                <br />
                <img src="~/Resource/bft_blpic.png" style="width:100%;" />
                <br />
                <br />
                <br />
                <div style="width:100%;text-align:center"> PARTICULARS FURNISHED BY THE MERCHANT</div>
            </div>

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
                <label id="lblANotifyName"></label>
                <br />
                <label id="lblANotifyAddress"></label>
            </div>
        </td>
        <td class="bodered" colspan="2">
            <b> Place and Date of issue</b>
            <br />
            <label id="lblBookingDate"></label>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="bodered">
            <b>  No. of Original B/L(s)</b>
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
            <b>LOCAL VESSEL</b>
            <div>
                <label id="lblVesselName"></label>
            </div>
        </td>
    </tr>
    <tr>
        <td class="bodered" colspan="2">
            <b>Place of Delivery</b>
            <div>
                <label id="lblDeliveryPlace"></label>
            </div>
        </td>
        <td class="bodered">
            <b>Port of Discharge</b>
            <div>
                <label id="lblDischargePlace"></label>
            </div>
        </td>
        <td class="bodered">
            <b>OCEAN VESSEL</b>
            <div>
                <label id="lblMVesselName"></label>
            </div>
        </td>
    </tr>
</table>
<table style="width:100%;" class="bodered">
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
        <tr>
            <td id="dvCont" colspan="5" style="position:absolute;width:100%;"></td>
        </tr>
        <tr style="height:300px;">
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
        </tr>
    </tbody>
</table>
<table style="width:100%" class="bodered">
    <tbody>
        <tr>
            <td class="vbodered" style="width:40%">
                SHIPPED ON BOARD DATE :
                <label id="lblOnBoardDate"></label>
            </td>
            <td class="vbodered" style="width:30%">PAYABLE AT :</td>
            <td class="vbodered" style="width:30%; text-align:center;" colspan="2">FREIGHT AND CHARGE</td>
        </tr>
        <tr>
            <td class="vbodered">PLACE : <label id="lblOnBoardPlace"></label></td>
            <td class="vbodered"><label id="lblPaymentBy"></label></td>
            <td class="bodered" colspan="2" style="text-align:center">
                <label id="lblPaymentCondition"></label>
                <br /><label id="lblTransMode"></label>
            </td>
        </tr>
        <tr>
            <td class="bodered" style="width:40%">
                FOR DELIVERY OF GOODS, PLEASE APPLY TO :
                <br />
                <label id="lblReturnPlace"></label><br />
                <label id="lblReturnAddress"></label>
            </td>
            <td class="bodered" colspan="3" style="text-align:center">
                SIGNED ON BEHALF OF THE CARRIER<br />
                BY <label style="color:transparent">_______________________________________________</label>

                <br />
                <br />
                <br />

                <br />
                <br />
                <br />
                <div style="border-top:1px dotted black">
                    BETTER FREIGHT & TRANSPORT CO.LTD
                    <br />
                    AS AGENT FOR THE CARRIER BF CONTAINER LINE
                </div>
            </td>
        </tr>
    </tbody>
</table>
<label id="lblProductUnit" style="display:none;"></label>
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
            $('#lbljno').text(h.JNo);
            $('#lblMAWB').text(h.MAWB);
            $('#lblHAWB').text(h.HAWB);
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBLNo').text(h.BLNo);
            $('#lblDeliveryPlace').text(h.PackingPlace);
            $('#lblDeliveryAddr').html(CStr(h.PackingAddr));
            $('#lblTransMode').text(h.TransMode);
            $('#lblPaymentBy').text(h.PaymentBy);
            $('#lblPaymentCondition').text('"'+h.PaymentCondition+'"');
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
            $('#lblANotifyName').text(h.DeliveryTo);
            $('#lblANotifyAddress').text(h.DeliveryAddr);

            let unit=units.filter(function(data){
               return data.Code==h.InvProductUnit;
            });
            if(unit.length>0) {
               $('#lblProductUnit').text(unit[0].TName);
            } else {
               $('#lblProductUnit').text(h.InvProductUnit);
            }
            /*if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblInterPortName');
                ShowCountry(path, h.InvFCountry, '#lblCountryName');
            } else {
                ShowCountry(path, h.InvCountry, '#lblCountryName');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblInterPortName');
            }*/
	        $('#txtDeliveryPlace').text(h.PackingPlace);
            $('#lblOnBoardDate').text(ShowDate(h.ETDDate));
            $('#lblOnBoardPlace').text(h.CYPlace);
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblRouting').text(h.FactoryAddress);
            $('#lblReturnPlace').text(h.DeliveryTo);
            $('#lblReturnAddress').text(h.DeliveryAddress);
            $('#lblPickupPlace').text(h.CYAddress);
            $('#lblDischargePlace').text(h.ClearPortNo);
            $('#lblTotalPackage').text(CNumEng(h.InvProductQty).replace('ONLY', ''));
            $('#lblServiceMode').text(h.TRemark);
            $('#lblInvCurRate').text(h.InvCurRate);
            $('#lblSumQty').text(CNumEng(h.InvProductQty).replace('ONLY', '') + ' ' + $('#lblProductUnit').text() + ' ONLY');
            let row = $('<tr>');
            row.append($('<td class="vbodered"><br/><br/><br/>' + CStr(h.Remark) + '</td>'));
            row.append($('<td class="vbodered" style="text-align:center;"><br/><br/>' + h.TotalContainer + '<br/>(' + h.InvProductQty + ' '+ h.InvProductUnit+ ')</td>'));
            row.append($('<td class="vbodered">' + CStr(h.ProjectName) + '<br/><br/>' + h.InvProduct + '</td>'));
            row.append($('<td class="vbodered"><br/><br/><br/>' + 'G.W ' + ShowNumber(h.TotalGW, 3) + ' ' + h.GWUnit + '</td>'));
            row.append($('<td class="vbodered"><br/><br/><br/>' + h.TotalM3 + ' CBM' + '</td></tr>'));

            $('#dvDetail').prepend(row);
            let row2=$('<div>CONTAINER NO<br/>');
            for (i = 0; i < r.booking.data.length; i++) {
                row2.append($('<div style="width:100%;">'+ r.booking.data[i].CTN_NO + '/' + r.booking.data[i].SealNumber + '=' + r.booking.data[i].ProductQty + ' ' + $('#lblProductUnit').text() + ' G.W ' + r.booking.data[i].GrossWeight + ' ' + h.GWUnit+'</div>'));
            }
            row2.append($('</div>'));
            $('#dvCont').append(row2);
        }
    });
    }
</script>