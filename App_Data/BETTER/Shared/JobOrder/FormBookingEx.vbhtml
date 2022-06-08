
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = ""
    ViewBag.Title = "ใบสั่งงานรถ (Truck Order)"
End Code
<style>
    * {
        font-size: 11px;
    }

    .center {
        text-align: center;
    }

    .bold {
        font-weight: bold;
    }

    td {
        border-color: black !important;
        border-collapse:collapse;
        vertical-align:top;
    }

    .pinkBg {
        background-color: pink;
    }
    .table {
        border-spacing: 0px;
    }
</style>

<table border="1" class="table  table-bordered">
    <thead>
    </thead>
    <tbody>
        <tr>
            <td colspan="2" style="height:100px;">
                <label class="bold">Shipper</label>
                <br>
                <label id="shipperName">N.R.ENGINEERING CO.,LTD</label>
                <div id="shipperAddress"></div>
                <label id="shipperTelLbl">TEL:</label>
                <label id="shipperTel"></label>
                <label id="shipperFaxLbl">FAX:</label>
                <label id="shipperFax"></label>
            </td>
            <td style="padding: 0px;" rowspan="3" colspan="3" class="center">
                <p style="border:1px solid; padding: 1em;background-color:pink">
                    <label id="trucwaybillNoLbl" class="bold">TRUCK WAY BILL NO.: </label>
                    <label id="trucwaybillNo" class="bold"></label>
                </p>
                <br>
                <label id="transportName" class="bold"></label>
                <br/>
                <label id="transportAddress"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height:100px;width:45%;">
                <label class="bold">Consignee</label>
                <br>
                <label id="consigneeName"></label>
                <div id="consigneeAddress"></div>
                <label id="consigneeTelLbl">TEL: </label>
                <label id="consigneeTel"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height:100px;">
                <label class="bold">Notify Party</label>
                <br />
                <label id="notifyName"></label>
                <div id="notifyAddress"></div>
            </td>
        </tr>
        <tr>
            <td>
                <label id="placeOfLoadingLbl" class="bold">Place of loading</label>
                <br>
                <label id="placeOfLoading"></label>
            </td>
            <td>
                <label id="placeOfDischargeLbl" class="bold">Place of discharge</label>
                <br>
                <label id="placeOfDischarge"></label>
            </td>
            <td colspan="3">
                <label id="placeOfDeliveryLbl" class="bold">Place of delivery</label>
                <br>
                <label id="placeOfDelivery"></label>
            </td>
        </tr>
        <tr>
            <td class="center bold pinkBg" style="width:20%;">
                <label id="markOfNosLbl">Mark of Nos</label>
            </td>
            <td class="center bold pinkBg" style="width:30%;">
                <label id="descriptionOfGoodsLbl">Description of goods</label>
            </td>
            <td class="center bold pinkBg" style="width:20%;">
                <label id="quantityLbl">Quantity(Carton)</label>
            </td>
            <td class="center bold pinkBg" style="width:15%;">
                <label id="netweightLbl">Net weight</label>
            </td>
            <td class="center bold pinkBg" style="width:15%;">
                <label id="grossweightLbl">Gross weight</label>
            </td>
        </tr>
        <tr>
            <td style="border-bottom-style:none;height:250px;" class="center">
                <label id="remark"></label>
            </td>
            <td style="border-bottom-style:none">
                <label id="product">WIRE ELECTRICAL CABLE</label>
            </td>
            <td style="border-bottom-style:none" class="center">
                <label id="package">9 ROLLS. AND 14WOODEN</label>
            </td>
            <td style="border-bottom-style:none" class="center">
                <label id="nw">2,639.60</label>
            </td>
            <td style="border-bottom-style:none" class="center">
                <label id="gw">3,290.00</label>
            </td>
        </tr>
        <tr>
            <td style="border-top-style:none;border-bottom-style:none"></td>
            <td style="border-top-style:none;border-bottom-style:none;padding-top: 0px;">
                <div>
                    <label id="invoicenoLbl">INVOICE NO.: </label>
                    <label id="invoiceno"></label>
                </div>
                <div>
                    <label id="dateLbl">DATE: </label>
                    <label id="date"></label>
                </div>
                <div>
                    <label id="loadingDateLbl">LOADING DATE: </label>
                    <label id="loadingDate"></label>
                </div>
            </td>
            <td class="center" style="border-top-style:none;border-bottom-style:none;padding: 0px;">
                <div class="pinkBg">
                    <label id="totalQW"></label>
                    <label id="unitQW"></label>
                </div>
            </td>
            <td class="center" style="border-top-style:none;border-bottom-style:none;padding: 0px;">
                <div class="pinkBg">
                    <label id="totalNW"></label>
                </div>
            </td>
            <td class="center" style="border-top-style:none;border-bottom-style:none;padding: 0px;">
                <div class="pinkBg">
                    <label id="totalGW"></label>
                </div>
            </td>
        </tr>
        <tr>
            <td style="border-top-style:none"></td>
            <td style="border-top-style:none;">
                <p>Total :</p>
                <br/>
                <label id="quantityLbl">
                    QUANTITY :
                    <label id="quantity"></label>
                    <label id="qtyUnit"></label>
                </label>
                <br />
                <label>
                    NET WEIGHT :
                    <label id="netweight"></label>
                    <label id="nwUnit"></label>
                </label>
                    <br />
                    <label>
                        GROSS WEIGHT :
                        <label id="grossweight"></label>
                        <label id="gwUnit"></label>
                    </label>
</td>
            <td style="border-top-style:none"></td>
            <td style="border-top-style:none"></td>
            <td style="border-top-style:none"></td>
        </tr>
        <tr>
            <td colspan="3">
                <label>RECEIVED FOR SHIPMENT as above in apparent good order and condition unless otherwise stated</label>
                <label>Herein the goods described in above particulars</label>
                <label>WITNESS whereof the number of original waybill truck stated below have been signed,all of this loner</label>
                <label>And date,one of being accomplished the other stand void</label>
            </td>
            <td class="center bold" colspan="2" style="height:100px">As agent to the carrier</td>
        </tr>
    </tbody>
</table>
<script src="~/Scripts/Func/reports.js"></script>
<script>
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    LoadData();
    function LoadData() {
        $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc)
            .done(function (r) {
                if (r.booking !== null) {
                    let h = r.booking.data[0];
                    $('#trucwaybillNo').text(h.HAWB);
                    $("#transportName").text(h.CarrierName);
                    $("#transportAddress").text(h.CarrierAddress1 + ' ' + h.CarrierAddress2);
                    $("#shipperName").text(h.ShipperName);
                    $("#shipperAddress").html(h.ShipperAddress1 + '<br/>' + h.ShipperAddress2);
                    $("#shipperTel").text(h.ShipperPhone);
                    $("#shipperFax").text(h.ShipperFax);
                    $("#consigneeName").text(h.ConsigneeName);
                    $("#consigneeAddress").html(h.ConsignAddress1 + '<br/>' + h.ConsignAddress2);
                    $("#consigneeTel").text(h.ConsignPhone);
                    $("#notifyName").text(h.NotifyName);
                    $("#notifyAddress").html(h.NotifyAddress1 + '<br/>' + h.NotifyAddress2);
                    $("#placeOfLoading").text(h.CYPlace);
                    $("#placeOfDischarge").text(h.ClearPortNo);
                    $("#placeOfDelivery").text(h.FactoryPlace);
                    $("#remark").text(h.Remark);
                    $("#product").text(h.ProductDesc);
                    $("#package").text(h.ProjectName);
                    $("#nw").text(ShowNumber(h.TotalNW,2));
                    $("#gw").text(ShowNumber(h.TotalGW,2));
                    $("#invoiceno").text(h.InvNo);
                    $("#date").text(ShowDate(h.BookingDate));
                    $("#loadingDate").text(ShowDate(h.CYDate));
                    $("#quantity").text(h.InvProductQty);
                    ShowInvUnit(path, h.InvProductUnit, '#qtyUnit');
                    $("#netweight").text(ShowNumber(h.TotalNW, 2));
                    $("#grossweight").text(ShowNumber(h.TotalGW, 2));
                    $("#nwUnit").text(h.GWUnit);
                    $("#gwUnit").text(h.GWUnit);
                    $("#totalQW").text("TOTAL "+h.InvProductQty);
                    ShowInvUnit(path, h.InvProductUnit, '#unitQW');
                    $("#totalNW").text(ShowNumber(h.TotalNW, 2) + ' ' + h.GWUnit);
                    $("#totalGW").text(ShowNumber(h.TotalGW, 2) + ' ' + h.GWUnit);
                }
            });
    }

</script>
