
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "DELIVERY NOTE"
    ViewBag.Title = "Delivery Form"
End Code
<style>

    td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    div {
        padding: 4px 4px 4px 4px;
    }

        div.div3 {
            border: 1px solid black;
            margin-bottom: 15px;
            width: 100%;
        }
</style>
<div style="margin-bottom:15px;">
    <div style="text-align:right;position:relative;float:right;">
        วันที่ส่งสินค้า (Delivery Date) &nbsp;
        <label style="display:inline-block;width:100px;text-decoration:underline" id="lblDeliveryDate">________________________</label>
    </div>
    <div style="text-align:left;position:relative;float:left;">
        เลขที่เอกสาร (Document No) &nbsp; <label style="display:inline-block;width:150px;text-decoration:underline" id="lblDeliveryNo">________________________</label>
    </div>
</div>
<br />
<div style="display:flex;flex-direction:column;align-items:center;width:100%;">
    <div class="div3">
        <div style="font-size:12px">
            Importer Name(ชื่อผู้นำเข้า) &nbsp; <label style="display: inline-block; width: 250px; text-decoration: underline; font-size: 13px" id="lblNameThai">________________________</label>
            TAX No: &nbsp; <label style="display: inline-block; width: 150px; text-decoration: underline; font-size: 12px " id="lblTaxNumber">________________________</label><br />
            <label style="display: inline-block; width: 300px; text-decoration: underline;font-size: 12px" id="lblTAddress">________________________</label><br />
            Invoice no.(เลขที่อินวอยซ์) &nbsp; <label id="lblInvNo" style="display: inline-block; width: 200px; text-decoration: underline; font-size: 13px">________________________</label><br />
            Job# <label style="display: inline-block; width: 200px; text-decoration: underline; font-size: 12px" id="lblJNo">________________________</label>
            <br />
            Place of Delivery(สถานที่ส่งสินค้า) &nbsp; <label style="display: inline-block; width: 400px; text-decoration: underline; font-size: 12px" id="lblPlaceNameAll">________________________</label><br />
            Description of Goods(รายละเอียดสินค้า) &nbsp; <label style="display: inline-block; width: 400px; text-decoration: underline; font-size: 12px" id="lblInvProduct">________________________</label><br />
            Quantity(ปริมาณหีบห่อ) &nbsp;<label style="display: inline-block; width: 100px; text-decoration: underline; font-size: 12px" id="lblInvProductQtyUnit">________________________</label>Gross Weight-KGS (น้ำหนักรวม-กิโลกรัม) &nbsp; <label style="display: inline-block; width: 100px; text-decoration: underline; font-size: 12px" id="lblTotalGW">________________________</label><br />
            Vessel/Fight(เรือ/เที่ยวบิน) &nbsp;<label style="display: inline-block; width: 200px; text-decoration: underline; font-size: 12px" id="lblVesselName">________________________</label>ETA(วันเรือเข้า) &nbsp; <label style="display: inline-block; width: 150px; text-decoration: underline; font-size: 12px" id="lblETADate">________________________</label><br />
            House B/L &nbsp;<label style="display: inline-block; width: 200px; text-decoration: underline; font-size: 12px" id="lblHAWB">________________________</label>Master B/L &nbsp; <label style="display: inline-block; width: 200px; text-decoration: underline; font-size: 12px" id="lblMAWB">________________________</label><br />
            Remark from CS(ข้อพึงระวัง) &nbsp;<label style="display: inline-block; width: 400px; text-decoration: underline; font-size: 12px" id="lblShippingCmd">________________________</label><br /><br />
        </div>
    </div>
    <div class="div3">
        <div>
            2.Record pf Cargo and Document Receipt(บันทึกการตรวจรับสินค้าเเละเอกสาร)<br /><br />
            I have received the above mentioned cargo completely in good condition and acceptance.<br />
            In case od damage or unacceptance. please kindy identify clearly the apparent condition and inform us within 3 days after receiving cargo<br />
            ข้าเจ้าได้รับสินค้าตามรายการที่ระบุข้างต้นในสภาพที่สมบูรณ์เป็นที่เรียบร้อยเเล้ว เเละยอมรับได้<br />
            ในกรณีที่สินค้าเสียหายหรือไม่สามารถยอมรับได้ กรุณาระบุสภาพสินค้าตามความเป็นจริงอย่างชัดเจนเเละเเจ้งกลับภายใน 3 วันหลังจากรับสินค้า<br />
            2.1 ตรวจสภาพสินค้า
            <div style="display:flex;">
                <input type="checkbox" />&nbsp;&nbsp;เรียบร้อย
                <input type="checkbox" />&nbsp;&nbsp;ไม่เรียบร้อย  เนื่องจาก_____________________________
            </div><br />
            2.2 ตรวจเอกสารเเนบส่งสินค้า
            <div style="display:flex;">
                <input type="checkbox" />&nbsp;&nbsp;Packing List
                <input type="checkbox" />&nbsp;&nbsp;ใบส่งของของบริษัท
                <input type="checkbox" />&nbsp;&nbsp;ใบส่งของของผู้ว่าจ้าง
            </div><br />
            <br /><br />
                  <div style="display:flex;">
                      <div class="text-left">
                          ลงชื่อ ______________________ ผู้รับสินค้า(ตัวบรรจง)<br /><br /><br />
                          วันที่ _______________________<br />
                      </div>
                      <div class="text-left" style="text-align:right; margin-left:50px;">
                          เวลาเข้า _______________________________ เวลาออก _______________________________
                      </div>
                  </div>
            <br />
        </div>
    </div>
    <div class="div3">
        <div>
            3.รายละเอียดรถบรรทุก<br />
            เบอร์ตู้  &nbsp; <label style="display:inline-block;width:250px;font-weight:bold;text-decoration:underline; font-size:15px;" id="lblCTN_NO">________________________</label> 
            size : &nbsp; <label style="display:inline-block;width:200px; font:bold;text-decoration:underline; font-size:15px;" id="lblCTN_SIZE"></label>
     @*Transport :&nbsp;<label style="display:inline-block;width:200px; font:bold;text-decoration:underline; font-size:15px;" id="lblTSP"></label>*@
     <br />
            ประเภทรถบรรทุก
            <div style="display:flex;font-weight:bold;">
                <input type="checkbox" id="chkTRK4" />&nbsp;&nbsp;4ล้อ
                <input type="checkbox" id="chkTRK6" />&nbsp;&nbsp;6ล้อ
                <input type="checkbox" id="chkTRK10" />&nbsp;&nbsp;10ล้อ
                <input type="checkbox" id="chk20F" />&nbsp;&nbsp;ตู้20ฟุต
                <input type="checkbox" id="chk40F" />&nbsp;&nbsp;ตู้40ฟุต &nbsp;
                <input type="checkbox" id="chkHBC" />&nbsp;&nbsp;รถเฮี๊ยบ
            </div>

            จำนวนรถ: &nbsp; <label style="display:inline-block;width:200px;text-decoration:underline" id="lblComment">________________________</label>
           <br /><br />ชื่อพนักงานขับรถบรรทุก &nbsp; <label style="display:inline-block;width:200px;text-decoration:underline" id="lblDriver">________________________</label>ทะเบียนรถเลขที่ &nbsp;<label style="display:inline-block;width:200px;text-decoration:underline" id="lblTruckNO">________________________</label>
            <br /><br />
        </div>
    </div>
    <div class="div3">
        <div>
            4.อุปกรณ์ Safety ของพนักงานขับรถ ตรวจสอบโดยผู้ตรวจปล่อยสินค้า<br />
            <div style="display:flex;">
                <input type="checkbox" />&nbsp;&nbsp;การเเต่งกาย_________
                <input type="checkbox" />&nbsp;&nbsp;สภาพรถ________
                <input type="checkbox" />&nbsp;&nbsp;สภาพตู้________ &nbsp;
                <input type="checkbox" />&nbsp;&nbsp;สายรัด
                <input type="checkbox" />&nbsp;&nbsp;อุปกรณ์ Safety
            </div><br />
        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let docno = getQueryString("Doc");
    if (docno !== '') {
        $.get(path + 'JobOrder/GetTransportReport?Branch=' + branch + '&Doc=' + docno, function (r) {
            if (r.transport.data.length > 0) {
                let j = r.transport.data[0];
                if (j.CTN_NO !== null) $('#lblCTN_NO').text(j.CTN_NO);
                if (j.CTN_SIZE !== null) $('#lblCTN_SIZE').text(j.CTN_SIZE);
                if (j.TName !== null) $('#lblTSP').text(j.TName);
                if (j.JNo !== null) $('#lblJNo').text(j.JNo);
                //if (j.Driver!==null) $('#lblDriver').text(j.Driver);
                //if (j.DriverName!==null) $('#lblDriver').text(j.DriverName);
                let driverDisplayName = j.DriverName || j.Driver || "________________________________________________";
                let truckNoDisplayName = j.TruckNO || "" || "________________________________________________"; 
                $('#lblDriver').text(driverDisplayName);
                $('#lblComment').text(j.Comment);
             	$('#lblTruckNO').text(truckNoDisplayName);

                $('#chkTRK4').prop('checked', (j.TruckType == 'TRK4'));
                $('#chkTRK6').prop('checked', (j.TruckType == 'TRK6'));
                $('#chkTRK10').prop('checked', (j.TruckType == 'TRK10'));
                $('#chk20F').prop('checked', (j.CTN_SIZE.indexOf('20F') >= 0));

                //if (j.TruckNO!==null) $('#lblTruckNO').text(j.TruckNO);
                $('#chk40F').prop('checked', (j.CTN_SIZE.indexOf('40F') >= 0));
                if (j.CarLicense!==null) $('#lblTruckNO').text(j.CarLicense);
                if (j.UnloadDate!==null) $('#lblDeliveryDate').text(ShowDate(j.UnloadDate) + ' ' + ShowTime(j.ActualYardTime));
		if (j.ActualYardTime!==null) $('#lblDeliveryTime').text(ShowTime(j.ActualYardTime));
                if (j.DeliveryNo !== null) $('#lblDeliveryNo').text(j.DeliveryNo);
                if (j.PlaceName1 !== null) $('lblPlaceName1').text(j.Placename1);
                if (j.PlaceName2 !== null) $('lblPlaceName2').text(j.Placename2);
                if (j.PlaceName3 !== null) $('lblPlaceName3').text(j.Placename3);
                if (j.PlaceContact2!==null) $('#lblDeliveryTo').text(j.PlaceName2);
                if (j.Location !== null) $('#lblDeliveryAddr').text(j.PlaceAddress2);
                if (j.InvNo!==null) $('#lblInvNo').text(j.InvNo);
                if (j.CustRefNO!==null) $('#lblCustRefNo').text(j.CustRefNO);
                if (j.InvProduct!==null) $('#lblInvProduct').text(j.InvProduct);
                if (j.ProductQty!==null) $('#lblInvProductQtyUnit').text(j.ProductQty + ' ' + j.ProductUnit);
                if (j.GrossWeight!==null) $('#lblTotalGW').text(j.GrossWeight);
                if (j.VesselName!==null) $('#lblVesselName').text(j.VesselName);
                if (j.ETADate!==null) $('#lblETADate').text(ShowDate(j.ETADate));
                if (j.HAWB!==null) $('#lblHAWB').text(j.HAWB);
                if (j.MAWB!==null) $('#lblMAWB').text(j.MAWB);
                if (j.ShippingCmd!==null) $('#lblShippingCmd').text(j.ShippingCmd);
                if (j.NameThai!==null) $('#lblNameThai').text(j.NameThai);
                if (j.TaxNumber!==null) $('#lblTaxNumber').text(j.TaxNumber);
                if (j.TAddress1 !== null) $('#lblTAddress').text(j.TAddress1 + ' ' + j.TAddress2);
                let place = '';
                //if (j.PlaceName1 !== null && j.PlaceName2 !== null && j.PlaceName3 !== null) {
                    place = (j.PlaceName1 ?? "") + " > " + (j.PlaceName2 ?? "") + " > " + (j.PlaceName3 ?? "");
                //}
		
                $('#lblPlaceNameAll').text(place);
            }
        });
    }
</script>