@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Transport Order Confirmation"
    ViewBag.Title = "Transport Order Confirmation"

End Code
<style>
    * {
        font-size: 12px;
    }

    table {
        width: 100%;
    }

    table, th, td {
        border: 1px solid black;
        border-collapse: collapse;
    }

    table tr>td{
        padding:5px
    }
</style>
<table>
    <tr>
        <th>วันที่เอกสาร</th>
        <th colspan="3">@DateTime.Now.ToString("dd/MM/yyyy HH:mm")</th>
    </tr>
    <tr>
        <td>หมายเลข Job Order</td>
        <td><label id="txtJNo"></label></td>
        <td>เลขที่เอกสาร</td>
        <td><label id="txtDeliveryNo"></label></td>
    </tr>
    <tr>
        <td>ชื่อเรือ/เที่ยว</td>
        <td><label id="txtVesselName"></label></td>
        <td>ปลายทาง(Port)</td>
        <td><label id="txtDischargePort"></label></td>
    </tr>
    <tr>
        <td>วัน-เวลาปิดรับ</td>
        <td><label id="txtCYDate"></label></td>
        <td>วันเรือออก</td>
        <td><label id="txtETDDate"></label></td>
    </tr>
    <tr>
        <td>คำแนะนำในการส่งสินค้า</td>
        <td><div id="txtSpecialInstruction"></div></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <th colspan="2">ข้อมูลเกี่ยวกับลูกค้า</th>
        <th colspan="2">ข้อมูลเกี่ยวกับบริษัทเดินเรือ</th>
    </tr>
    <tr>
        <td>ชื่อบริษัทลูกค้า</td>
        <td><label id="txtNotifyName"></label></td>
        <td>ชือบริษัทเดินเรือ</td>
        <td><label id="txtCarrierName"></label></td>
    </tr>
    <tr>
        <td>ที่อยู่</td>
        <td><div id="txtNotifyAddress"></div></td>
        <td>ชื่อผู้ติดต่อ/โทรศัพท์</td>
        <td><label id="txtCarrierContact"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>บุ้คกิ้ง</td>
        <td><label id="txtCarrierBooking"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>วันที่จอง</td>
        <td><label id="txtBookingDate"></label></td>
    </tr>
    <tr>
        <th colspan="2">ข้อมูลเกี่ยวกับการบริการ</th>
        <th colspan="2">ข้อมูลเกี่ยวกับรถบรรทุก</th>
    </tr>
    <tr>
        <td>ประเภทการให้บริการ</td>
        <td><label id="txtServiceType"></label></td>
        <td>ทะเบียนรถบรรทุก</td>
        <td><label id="txtTruck"></label></td>
    </tr>
    <tr>
        <td>ขนาดตู้คอนเทนเนอร์</td>
        <td><label id="txtContainerType"></label></td>
        <td>ชื่อคนขับ/โทรศัพท์</td>
        <td><label id="txtDriverName"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>หมายเลขตู้คอนเทนเนอร์</td>
        <td><label id="txtContainer"></label></td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td><div id="txtRemark"></div></td>
        <td>หมายเหตุในการส่งตู้ล่าช้า</td>
        <td><div id="txtDiscrepancyReason"></div></td>
    </tr>
    <tr>
        <th></th>
        <th>สถานที่รับตู้</th>
        <th>ไปส่งที่</th>
        <th>สถานที่ส่งคืน</th>
    </tr>
    <tr>
        <td>ชื่อสถานที่</td>
        <td><label id="txtPlace1"></label></td>
        <td><label id="txtPlace2"></label></td>
        <td><label id="txtPlace3"></label></td>
    </tr>
    <tr>
        <td>ที่อยู่</td>
        <td><label id="txtAddress1"></label></td>
        <td><label id="txtAddress2"></label></td>
        <td><label id="txtAddress3"></label></td>
    </tr>
    <tr>
        <td>ชื่อผู้ติดต่อ</td>
        <td><label id="txtContact1"></label></td>
        <td><label id="txtContact2"></label></td>
        <td><label id="txtContact3"></label></td>
    </tr>
    <tr>
        <td>วัน/เวลา</td>
        <td><label id="txtTargetDate1"></label></td>
        <td><label id="txtTargetDate2"></label></td>
        <td><label id="txtTargetDate3"></label></td>
    </tr>
    <tr>
        <td>วัน/เวลาจริง</td>
        <td><label id="txtActualDate1"></label></td>
        <td><label id="txtActualDate2"></label></td>
        <td><label id="txtActualDate3"></label></td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td><label id="txtRemark1"></label></td>
        <td><label id="txtRemark2"></label></td>
        <td><label id="txtRemark3"></label></td>
    </tr>
</table>
<br />
<table id="transcost" style="width:100%">
    <thead>
        <tr>
            <th colspan="5" style="background-color: gray;">ค่าใช้จ่ายเคลียร์ค่าขนส่ง</th>
        </tr>
        <tr>
            <th colspan="3">
                มีใบเสร็จในนามลูกค้า
            </th>
            <th colspan="2">
                ไม่มีใบเสร็จรับเงิน
            </th>
        </tr>
        <tr>
            <th>รายละเอียด</th>
            <th>เลขที่ใบเสร็จ</th>
            <th>จำนวนเงิน</th>
            <th>รายละเอียด</th>
            <th>จำนวนเงิน</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>ค่าน้ำมัน01</td>
            <td></td>
            <td></td>
            <td>ค่าน้ำมัน01</td>
            <td></td>
        </tr>
        <tr>
            <td>ค่าน้ำมัน02</td>
            <td></td>
            <td></td>
            <td>ค่าน้ำมัน02</td>
            <td></td>
        </tr>
        <tr>
            <td>ค่าน้ำมัน03</td>
            <td></td>
            <td></td>
            <td>ค่าน้ำมัน03</td>
            <td></td>
        </tr>
        <tr>
            <td>ค่าผ่าน</td>
            <td></td>
            <td></td>
            <td>ค่าผ่าน</td>
            <td></td>
        </tr>
        <tr>
            <td>ค่าทางด่วน</td>
            <td></td>
            <td></td>
            <td>ค่าทางด่วน</td>
            <td></td>
        </tr>
        <tr>
            <td>ค่าข้ามสะพาน</td>
            <td></td>
            <td></td>
            <td>ค่าข้ามสะพาน</td>
            <td></td>
        </tr>
        <tr>
            <td>ค่าเที่ยวคนขับ</td>
            <td></td>
            <td></td>
            <td>ค่าเที่ยวคนขับ</td>
            <td></td>
        </tr>
        <tr></tr>
        <tr></tr>
    </tbody>
</table>
<br />
<br />
<br />
<div style="display:flex">
    <div>ลายเซ็นคนจัดทำ ______________________ </div>
    <div style="flex:1;text-align:right">ลายเซ็นคนขับ ______________________</div>
</div>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    let cont = getQueryString("ContainerNo");
    let user = '@ViewBag.User';
    var path = '@Url.Content("~")';
 
   

    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc +'&Cont=' +cont).done(function (r) {
        if (r.booking !== null) {
         
            let h = r.booking.data[0];
            $.get(path + 'Master/GetEmployee?code=' + h.Driver).done(function (r) {
                let e = r.employee.data[0];            
                $('#txtDriverName').text(e.Name);
            });
            $.get(path + 'Master/GetCarLicense?code=' + h.TruckNO).done(function (r) {
                let c = r.carlicense.data[0];
                $('#txtTruck').text(c.CarLicense);
            });



            $('#txtJNo').text(h.JNo);
            $('#txtDeliveryNo').text(h.DeliveryNo);
            $('#txtNotifyName').text(h.NotifyName);
            $('#txtVesselName').text(h.VesselName);
            if (h.JobType == '1') {
                ShowInterPort(path, h.InvFCountry, h.InvInterPort, '#txtDischargePort');
            } else {
                ShowInterPort(path, h.InvCountry, h.InvInterPort, '#lblDischargePort');
            }
            $('#txtCYDate').text(ShowDate(h.CYDate));
            $('#txtETDDate').text(ShowDate(h.ETDDate));
            $('#txtSpecialInstruction').html(h.Description);
            $('#txtNotifyName').text(h.NotifyName);
            $('#txtCarrierName').text(h.CarrierName);
            $('#txtNotifyAddress').html(CStr(h.NotifyAddress1+'\n'+h.NotifyAddress2));
            $('#txtCarrierContact').text(h.CarrierContact);
            $('#txtCarrierBooking').text(h.BookingNo);
            $('#txtBookingDate').text(ShowDate(h.BookingDate));
            $('#txtServiceType').text(h.LocationRoute);
        
            $('#txtContainerType').text(h.CTN_SIZE);
           
            $('#txtContainer').text(h.CTN_NO);
            $('#txtDiscrepancyReason').html(h.Comment);
            $('#txtRemark').html(CStr(h.Remark));

            $('#txtPlace1').text(h.PlaceName1);
            $('#txtPlace2').text(h.PlaceName2);
            $('#txtPlace3').text(h.PlaceName3);
            $('#txtAddress1').html(CStr(h.PlaceAddress1));
            $('#txtAddress2').html(CStr(h.PlaceAddress2));
            $('#txtAddress3').html(CStr(h.PlaceAddress3));
            $('#txtTargetDate1').text(ShowDate(h.TargetYardDate));
            $('#txtTargetDate2').text(ShowDate(h.TargetDeliveryDate));
            $('#txtTargetDate3').text(ShowDate(h.TargetReturnDate));
            $('#txtActualDate1').text(ShowDate(h.ActualYardDate));
            $('#txtActualDate2').text(ShowDate(h.ActualDeliveryDate));
            $('#txtActualDate3').text(ShowDate(h.ActualReturnDate));
            $('#txtContact1').text(h.PlaceContact1);
            $('#txtContact2').text(h.PlaceContact2);
            $('#txtContact3').text(h.PlaceContact3);
        }
    });
</script>
