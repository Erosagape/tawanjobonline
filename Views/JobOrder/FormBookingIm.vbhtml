
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Truck Order"
    ViewBag.Title = "ใบสั่งงานรถ (Truck Order)"
End Code
<div style="text-align:right;width:100%">
    <b>DATE :</b> <label id="lblBookingDate"></label><br/>
    <b>JOB NUMBER :</b> <label id="lblJNo"></label>
</div>
<div style="width:100%">
    <div style="display:flex">
        <div style="flex:1">
            <b>BL NUMBER/BOOKING NO:</b>
        </div>
        <div style="flex:1">
            <label id="lblBookingNo"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>Customer Invoice:</b>
        </div>
        <div style="flex:1">
            <label id="lblCustInv"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>บริษัทรถ / TRANSPORT COMPANY :</b>
        </div>
        <div style="flex:1">
            <label id="lblForwarderName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ประเภทรถ / TYPE OF TRANSPORT : </b>
        </div>
        <div style="flex:1">
            <label id="lblTruckType"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>จำนวนรถ / QUANTITY : </b>
        </div>
        <div style="flex:1">
            <label id="lblTotalContainer"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>วันรับสินค้า / PICK UP GOODS DATE : </b>
        </div>
        <div style="flex:1">
            <label id="lblPickupDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สถานที่รับตู้ / PICK UP DEPOT : </b>
        </div>
        <div style="flex:1">
            <label id="lblPickupPlace"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>หมายเลขตู้ / CONTAINER LISTS : </b>
            <div style="flex:1">
                <div id="lblContainerList"></div>
            </div>
        </div>

    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>เจ้าหน้าที่ตรวจปล่อย / SHIPPING OFFICER : </b>
        </div>
        <div style="flex:1">
            <label id="lblShippingName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ท่าตรวจปล่อย / RELEASE PORT: </b>
        </div>
        <div style="flex:1">
            <label id="lblReleasePort"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>วันที่ตรวจปล่อย / INSPECTION DATE: </b>
        </div>
        <div style="flex:1">
            <label id="lblInspectionDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>วันเวลาที่ส่งสินค้า / DELIVERY DATE :</b>
        </div>
        <div style="flex:1">
            <label id="lblFactoryDate"></label> / <label id="lblFactoryTime"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สถานที่ส่งสินค้า / DELIVERY PLACE :</b>
        </div>
        <div style="flex:1">
            <label id="lblFactoryPlace"></label>
            <div id="lblFactoryAddress"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>บุคคลติดต่อ / CONTACT PERSON :</b>
        </div>
        <div style="flex:1">
            <label id="lblFactoryContact"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สายเรือ,สายการบิน / AGENT : </b>
        </div>
        <div style="flex:1">
            <label id="lblCarrierName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ผู้นำเข้า / CONSIGNEE : </b>
        </div>
        <div style="flex:1">
            <label id="lblConsignName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สินค้า / GOODS DESCRIPTION : </b>
        </div>
        <div style="flex:1">
            <label id="lblInvProduct"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>น้ำหนักรวมสินค้า / GROSS WEIGHT : </b>
        </div>
        <div style="flex:1">
            <label id="lblGrossWeight"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>น้ำหนักรวมสินค้า / NET WEIGHT : </b>
        </div>
        <div style="flex:1">
            <label id="lblNetWeight"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>สรุปรายละเอียดงาน / JOB DETAILS : </b>
        </div>
        <div style="flex:1">
            <div id="lblDescription"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ที่อยู่ในการวางบิลรถ : </b>
        </div>
        <div style="flex:1">
            <label id="lblBillToName"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>ที่อยู่ในการออกใบเสร็จค่าท่า,ค่าตู้ : </b>
        </div>
        <div style="flex:1">
            <div id="lblBillToAddress"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1">
            <b>NOTE:</b>
        </div>
        <div style="flex:1">
            <div id="dvRemark"></div>
        </div>
    </div>
    <div style="display:flex">
        <div style="flex:1;text-align:center">
            <br>   <br>
            <br>   <br>
            
            <br>   <br>
            ได้รับสินค้าสภาพครบถ้วนสมบูรณ์แล้ว <b> (The cargoes have been properly received)</b>
            <br>
            <br>
            ผู้รับสินค้า.....................................................................................
            <br>
            (ตัวบรรจง)
            <br>
            <br>
            วันที่ ............................ เวลา ............................ น
        </div>
    </div>

    <div style="display:flex">
        <div style="flex:2">

        </div>
        <div style="flex:2">

        </div>
        <div style="flex:1">
            HANDLER BY : <br />
            REVISED       :
        </div>
        <div style="flex:1">
            <div> ..........................................................</div>
            <div> ..........................................................</div>
        </div>
    </div>
    <table>
        <thead></thead>
    </table>
</div>
    <script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
        var path = '@Url.Content("~")';
        $("#imgLogo").hide();
        $("#imgLogoAdd").show();
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $.get(path + 'JobOrder/getjobsql?Branch=' + br + '&Jno=' + h.JNo).done(function (r) {
                if (r.job !== null) {
                    let j = r.job.data[0];
                    $('#lblCustInv').text(j.InvNo);        
                    $('#lblInspectionDate').text(ShowDate(j.DutyDate));
                    $.get(path + 'Master/GetCustomsPort?code=' + j.ClearPort).done(function (r) {
                        if (r.RFARS !== null) {
                            let p = r.RFARS.data[0];
                            $('#lblReleasePort').text(p.AreaCode);
                        }    
                    });
                }
            });
        
            $('#lblBookingNo').text(h.BookingNo);
            $('#lblBookingDate').text(ShowDate(h.BookingDate));
            $('#lblJNo').text(h.JNo);
            $('#lblTruckType').text(h.TRemark);
            $('#lblTotalContainer').text(h.TotalContainer);
            $('#lblForwarderName').text(h.ForwarderName);
            $('#lblPickupDate').text(ShowDate(h.CYDate) + ' / '+ ShowTime(h.CYTime));
            $('#lblPickupPlace').text(h.CYPlace);
            $('#lblShippingName').text(h.ShippingName + ' ' + h.ShippingTel);
            $('#lblFactoryDate').text(ShowDate(h.FactoryDate));
            $('#lblFactoryTime').text(ShowTime(h.FactoryTime));
            $('#lblFactoryPlace').text(h.FactoryPlace);
            $('#lblFactoryAddress').html(CStr(h.FactoryAddress));
            $('#lblFactoryContact').text(h.FactoryContact);
            $('#lblCarrierName').text(h.CarrierName);
            $('#lblConsignName').text(h.ConsigneeName);
            $('#lblInvProduct').text(h.InvProduct);
            $('#lblGrossWeight').text(h.TotalGW + ' ' + h.GWUnit);
            $('#lblNetWeight').text(h.TotalNW + ' ' + h.GWUnit);
            $('#lblDescription').html(CStr(h.Description));
            $('#lblBillToName').text(h.PaymentBy);
            $('#lblBillToAddress').html(CStr(h.PaymentCondition));

            $('#dvRemark').html(CStr(h.Remark));
          
             let ctnList = '';
            for (let d of r.booking.data) {
                if (d.CTN_NO !== '') {
                    if (ctnList.indexOf(d.CTN_NO) < 0) {
                        if (ctnList !== '') ctnList += '';
                        ctnList += " <tr><td>" + d.CTN_NO + "</td><td style='text-align:right'>" + d.GrossWeight + "</td><td style='text-align:right'>" + d.GrossWeight + "</td><td>" + d.LocationRoute + "</td></tr>";
                    }
                }
            }
            let html = `   <table>
                <thead>
                <tr>
                    <th>Container</th>
                    <th>Net Weight</th>
                    <th>GrossWeight</th>
                    <th>Route</th>
                </tr>
        </thead >
                <tbody>
                    ${ctnList}
                </tbody>
    </table >`;
            $('#lblContainerList').html(html);
        }
    });
    </script>
