@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "SHIPPING PARTICULAR"
    ViewBag.Title = "SHIPPING PARTICULAR"
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
    @*<img src="~/Resource/bft_blheader.png" style="width:100%" />*@
    <div style="width:100%;display:flex;font-size:13px">
        <div style="width:100%">
            <div style="text-align: center; white-space: nowrap; font-weight: bold; font-size: 16px">@ViewBag.Title</div>
        </div>
    </div>
</div>
<table style="width:100%">
    <tr>
        <td class="bodered" style="height:100px;width:50%;" colspan="3">
            <u><b>SHIPPER</b></u>
            <div style="padding:5px 5px 5px 5px">
                <label id="lblShipperName"></label>
                <br />
                <label id="lblShipperAddress1"></label>
                <br />
                <div id="lblShipperAddress2"></div>
            </div>
        </td>
        <td class="bodered" style="width: 50%;" rowspan="5" colspan="2">
            <div style="display:flex;flex-direction:column;height:200px">
                <div style="display:flex;flex:1;">
                    <div style="width:50%;display:flex;flex-direction:column">
                        <div style="display: flex; flex: 1">
                            <div>     TO : </div>
                            <div style="flex: 1; padding: 0px 5px" contenteditable="true"></div>
                        </div>
                        <div style="display: flex; flex: 1">
                            <div>     ATTN : </div>
                            <div style="flex: 1; padding: 0px 5px" contenteditable="true"></div>
                        </div>
                        <div style="display: flex; flex: 1">
                            <div>     REF.NO : </div>
                            <div style="flex: 1; padding: 0px 5px" contenteditable="true">
                                <div id="lblJobNo" style="flex: 1"></div>
                            </div>
                        </div>
                        <div style="width:50%">
                            <img src="~/Resource/logo_teg.jpg" style="width:100%;" />
                        </div>
                        @*<p>    ATTN : <label id="lblForwarderName"></label></p>*@
                    </div>
                </div>

                <div style="flex: 1; display: flex; flex-direction: column">
                    <div style="display: flex; flex: 1">
                        FROM : @ViewBag.UserName / UNITED GLOBE
                    </div>
                    <div style="display: flex; flex: 1">
                        TEL : 02-664 6229<br />
                        FAX : 02-664 6233<br />
                        E-MAIL: @@operation@@unitedglobe.co.th
                    </div>


                </div>

                <div style="display: flex;flex: 1;">
                    <div style="width:60%;text-align:right;font-weight:bold;font-size:16px">
                        **SURRENDER BL**
                    </div>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td class="bodered" style="height:100px" colspan="3">
            <u><b>CONSIGNEE</b></u>
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
        <td class="bodered" style="height:100px;" colspan="3">
            <u><b>NOTIFY PARTY</b></u>
            <div style="padding:5px 5px 5px 5px">
                <label id="lblNotifyName"></label>
                <br />
                <label id="lblNotifyAddress1"></label>
                <br />
                <label id="lblNotifyAddress2"></label>
            </div>
        </td>
        @*
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
        *@
    </tr>
    <tr>
        <td class="bodered">
            <b>FEEDER:</b>
        </td>
        <td class="bodered" colspan="2">
            <label id="lblVesselName"></label>
        </td>
    </tr>
    <tr>
        <td class="bodered">
            <b>MOTHER VESSEL:</b>
        </td>
        <td class="bodered" colspan="2">
            <label id="lblMVesselName"></label>
        </td>
    </tr>
    @*
        <tr>
            <td colspan="2" class="bodered">
                <b>  No. of Original B/L(s)</b>
                <div>
                    <label id="lblBLNo"></label>
                </div>
            </td>
        </tr>
    *@
    <tr>
        <td class="bodered" colspan="2">
            <b>PORT OF LOADING</b>
            <div>
                <label id="lblFactoryPlace"></label>
            </div>
            @*
                <b>Place of Receipt</b>
                <div>
                    <label id="lblPackingPlace"></label>
                </div>
            *@
        </td>
        <td class="bodered">
            <b>PORT OF DISCHARGE</b>
            <div>
                <label id="lblDischargePlace"></label>
            </div>
        </td>
        <td class="bodered" colspan="2">
            <b>PORT OF DELIVERY:</b>
            <div>
                <label id="lblDeliveryPlace"></label>
            </div>
            @*
                <b>LOCAL VESSEL</b>
                <div>
                    <label id="lblVesselName"></label>
                </div>
            *@
        </td>
    </tr>
    @*
        <tr>
            <td class="bodered" colspan="2">

            </td>
            <td class="bodered">

            </td>
            <td class="bodered" colspan="2">
                <b>OCEAN VESSEL</b>
                <div>
                    <label id="lblMVesselName"></label>
                </div>
            </td>
        </tr>
    *@
</table>
<table style="width:100%;" class="bodered">
    <thead>
        <tr>
            <th class="bodered" style="width:20%;text-align:center">MARKS AND NO</th>
            <th class="bodered" style="width: 20%; text-align: center">QUANTITY</th>
            <th class="bodered" style="width: 30%; text-align: center">DESCRIPTION OF GOODS</th>
            <th class="bodered" style="width: 15%; text-align: center">GROSS WEIGHT </th>
            <th class="bodered" style="width: 15%; text-align: center">MEASUREMENT</th>
        </tr>
    </thead>
    <tbody id="dvDetail">
        <tr>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered" id="dvCont"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
        </tr>
        <tr style="height:300px;">
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
            <td class="vbodered"></td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <td rowspan="4" style="text-align:center;vertical-align:middle" class="bodered">
                <b><label id="lblTransMode"></label></b>
            </td>
        </tr>
        <tr>
            <td colspan="5" class="bodered">
                <b>CONTAINER AND SEAL NO.</b>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="bodered">
                <b>QTY</b>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="5" class="bodered">
                <b>REMARK:</b>
                <br />
                <span style="width:100%;text-align:center">
                    <u><b>ACTUAL SHIPPER :</b></u>
                    <label id="lblActualShipper"></label>
                </span>
            </td>
        </tr>
    </tfoot>
</table>
<!--
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
            <td class="vbodered" rowspan="2">PLACE : <label id="lblOnBoardPlace"></label></td>
            <td class="vbodered" rowspan="2"><label id="lblPaymentBy"></label></td>
            <td class="bodered" style=" text-align: center;">PREPAID</td>
            <td class="bodered" style=" text-align: center;">COLLECT</td>
        </tr>
        <tr>
            <td contenteditable="true" style="padding: 5px;width:10%"><br /></td>
            <td contenteditable="true" style="padding: 5px; width:10%"><br /></td>
            @*<td class="bodered" colspan="2" style="text-align:center">
                    <label id="lblPaymentCondition"></label>
                    <br /><label id="lblTransMode"></label>
                </td>*@
        </tr>
        @*<tr>
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
            </tr>*@
    </tbody>
</table>
    -->
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
                $('#lblDeliveryTo').text(h.DeliveryTo);
                $('#lblDeliveryAddr').html(CStr(h.DeliveryAddr));
                $('#lblTransMode').text(h.TransMode);
                $('#lblPaymentBy').text(h.PaymentBy);
                $('#lblPaymentCondition').text('"'+h.PaymentCondition+'"');
                $('#lblBookingDate').text('BANGKOK ' + ShowDate(h.BookingDate));
                $('#lblLoadDate').text(ShowDate(h.BookingDate));
                $('#lblForwarderName').text(h.ForwarderName);
                if (confirm("Show Shipper as Company?") == false) {
                    $('#lblShipperName').text(h.ShipperName);
                    $('#lblShipperAddress1').text(CStr(h.ShipperAddress1));
                    $('#lblShipperAddress2').html(CStr(h.ShipperAddress2));
                    $('#lblActualShipper').text('@ViewBag.PROFILE_COMPANY_NAME_EN');
                } else {
                    $('#lblActualShipper').text(h.ShipperName);
                    $('#lblShipperName').text('@ViewBag.PROFILE_COMPANY_NAME_EN');
                    $('#lblShipperAddress1').text('@ViewBag.PROFILE_COMPANY_ADDR1_EN');
                    $('#lblShipperAddress2').html('@ViewBag.PROFILE_COMPANY_ADDR2_EN');
                }
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
                $('#lblBookNo').text(h.BookingNo);
                $('#lblJobNo').text(h.JNo);
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
	            $('#lblDeliveryPlace').text(h.PackingPlace);
                $('#lblOnBoardDate').text(ShowDate(h.ETDDate));
                $('#lblOnBoardPlace').text(h.CYPlace);
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
                let row = $('<tr>');
                row.append($('<td class="vbodered"><br/>' + CStr(h.Remark) + '</td>'));
                row.append($('<td class="vbodered" style="text-align:center;"><br/>' + h.InvProductQty + ' '+ h.InvProductUnit+ '</td>'));
                row.append($('<td class="vbodered">**SAID TO CONTAIN**<pre style="white-space: pre-wrap;">' + CStr(h.ProjectName) + '</pre></td>'));
                row.append($('<td class="vbodered"><br/>' + 'G.W ' + ShowNumber(h.TotalGW, 3) + ' ' + h.GWUnit + '<br/>' + 'N.W ' + ShowNumber(h.TotalNW, 3) + ' ' + h.GWUnit + '</td>'));
                row.append($('<td class="vbodered"><br/>' + h.TotalM3 + ' CBM' + '</td></tr>'));

                $('#dvDetail').prepend(row);
                let row2 = $('<div style="width:100%;text-align:center;">');
                for (i = 0; i < r.booking.data.length; i++) {
                    row2.append($('<div style="width:100%;text-align:center;">(' + CNumEng(h.InvProductQty) + ' ' + h.InvProductUnit + ')<br/>' + r.booking.data[i].PaymentCondition +'</div>'));
                }
                row2.append($('</div>'));
                $('#dvCont').append(row2);
            }
        });
    }
</script>