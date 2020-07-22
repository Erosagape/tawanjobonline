
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Booking Confirmation"
    ViewBag.Title = "BOOKING CONFIRMATION"
End Code
    <div style="display:flex;font-size:14px">
        <div style="text-align:left;flex:1">
            <b>BOOKING NO:</b> <label id="lblBookingNo"></label>
        </div>
        <div style="text-align:right;flex:1">
            <b>DATE :</b> <label id="lblBookingDate"></label>            
            <br />
            <b>SHIPMENT NO:</b> <label id="lblJNo"></label>
        </div>
    </div>
    <div style="width:100%;font-size:14px">
        <b>TO :</b><label id="lblForwarderName"></label>
        <br />
        <b>ATTN : </b><label id="lblForwarderContact"></label>
        <br />
        <b>FROM : </b><label id="lblCSName"></label>
        <br />
        <b>SUBJECT : </b><label id="lblProjectName"></label>
        <br />
        <div style="display:flex;font-size:14px">
            <div style="flex:1">
                <b>FEEDER / VOY :</b>
            </div>
            <div style="flex:2">
                <label id="lblVesselName"></label>
            </div>
            <div style="flex:1">
                <b>ETD DATE :</b><label id="lblETDDate"></label>
            </div>
            <div style="flex:2">
                <b>DEPARTURE PORT :</b><br/><label id="lblPortDeparture"></label>
            </div>
        </div>
        <br />
        <div style="display:flex;font-size:14px">
            <div style="flex:1">
                <b>M.VESSEL / VOY :</b>
            </div>
            <div style="flex:2">
                <label id="lblMVesselName"></label>
            </div>
            <div style="flex:1">
                <b>ETA DATE :</b><label id="lblETADate"></label>
            </div>
            <div style="flex:2">
                <b>DESTINATION PORT :</b><br/><label id="lblPortArrival"></label>
            </div>
        </div>
        <br />
        <div style="display:flex;flex-direction:row">
            <div style="flex:1;font-size:14px">
                <b>VOLUME :</b><label id="lblTotalContainer"></label>
                <br />
                <b>QUANTITY : </b><label id="lblProductQty"></label> &nbsp; <label id="lblProductUnit"></label>
                <br />
                <b>CY DATE :</b> <label id="lblCYDate"></label>
                <br />
                <b>CY AT :</b> <label id="lblCYPlace"></label>
                <br />
                <b>RETURN DATE :</b> <label id="lblReturnDate"></label>
                <br />
                <b>RETURN AT :</b> <label id="lblReturnPlace"></label>
                <br />
                <b>CFS/LOADING DATE :</b> <label id="lblCFSDate"></label>
                <br />
                <b>CFS/LOADING AT :</b> <label id="lblCFSPlace"></label>
                <br />
                <b>LAST LOAD DATE :</b> <label id="lblClosingDate"></label>
                <br />
                <b>LAST LOAD AT :</b> <label id="lblClosingTime"></label>
                <br />
                <b>LINERS :</b> <label id="lblAgentName"></label>
                <br />
                <b>SHIPPER LOAD:</b>
                <br />
                <label id="lblShipperName"></label>
                <br />
                <label id="lblShipperAddress1"></label>
                <br />
                <label id="lblShipperAddress2"></label>
                <br />
                <b>REMARK:</b>
                <br />
                <div id="dvRemark"></div>
            </div>
            <div style="flex:1">
                Reminder:<br />
                <textarea style="height:100%;width:100%">
1.คืนตู้ได้เริ่มวันแรก 4 วัน ก่อนเรือออก
2.กรุณาแจ้งยกเลิก booking ได้ก่อนภายใน 5 วันก่อนเรือออก
แต่หากเป็นตู้ CFS กรุณาแจ้งยกเลิก booking ก่อนภายใน 3 วันก่อนวันบรรจุสินค้า
3.กรุณา submit VGM ภายใน 3 ชั่วโมง หลังจากการโหลดสินค้า
4.กรุณาส่ง S/I ภายใน 3 วันก่อนเรือออก
5.กรุณา confirm B/L ภายใน 7 วันหลังเรือออก
**หากไม่สามารถปฏิบัติตามได้ อาจมีค่าใช้จ่ายตามอัตราที่สายเรือกำหนด**
</textarea>
            </div>

        </div>
        <br />
        <br />
        hope you have been well informed, For further info or inquiry you may require, please feel free to contact us.
        <br />
        <br />
        THANK YOU AND BEST REGARDS,
        <br />
        <br />
        <br />
        <br />
        (________________________)<br/>
        ______/___________/_______

    </div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#lblJNo').text(h.JNo);
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblForwarderName').text(h.ShipperName);
            $('#lblForwarderContact').text(h.CustContactName);
            $('#lblCSName').text(h.CSName);
            $('#lblProjectName').text(h.ProjectName);
            $('#lblAgentName').text(h.ForwarderName);
            $('#lblTotalContainer').text(h.TotalContainer);

            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#lblPortDeparture');
                ShowReleasePort(path, h.ClearPort, '#lblPortArrival');
            } else {
                ShowReleasePort(path, h.ClearPort, '#lblPortDeparture');
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblPortArrival');
            }
            $('#lblProductQty').text(h.InvProductQty);
            ShowInvUnit(path, h.InvProductUnit, '#lblProductUnit');
            $('#lblTotalGW').text(h.TotalGW);
            ShowInvUnit(path, h.GWUnit, '#lblGWUnit');

            $('#lblVesselName').text(h.VesselName);
            $('#lblMVesselName').text(h.MVesselName);

            $('#lblETDDate').text(ShowDate(h.ETDDate));
            $('#lblETADate').text(ShowDate(h.ETADate));

            if (h.TransMode.substr(0, 2) == 'CY') {
                $('#lblCYDate').text(ShowDate(h.CYDate));
                $('#lblCYPlace').text(h.CYPlace);
                $('#lblReturnDate').text(ShowDate(h.ReturnDate));
                $('#lblReturnPlace').text(h.ReturnPlace);

                $('#lblClosingDate').text(ShowDate(h.PackingDate));
                $('#lblClosingTime').text(ShowTime(h.PackingTime));
            } else {
                $('#lblCFSDate').text(ShowDate(h.CYDate));
                $('#lblCFSPlace').text(h.CYPlace);
                $('#lblClosingDate').text(ShowDate(h.PackingDate));
                $('#lblClosingTime').text(ShowTime(h.PackingTime));
            }
            
            $('#lblShipperName').text(h.ShipperName);
            $('#lblShipperAddress1').text(h.ShipperAddress1);
            $('#lblShipperAddress2').text(h.ShipperAddress2);

            let str = h.Remark;
            str += '\n RELEASE PORT ' + h.ClearPort + ' LOAD PORT ' + h.ClearPortNo;
            $('#dvRemark').html(CStr(str));
        }
    });
</script>
