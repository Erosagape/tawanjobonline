@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Truck Order"
    ViewBag.Title = "Truck Order"

End Code
<style>
    * {
        font-size:9px;
    }
    table {
        width: 100%;
    }

    table, th, td {
        border: 1px solid black;
        border-collapse: collapse;
    }
</style>

<table>
    <tr>
        <td>เลขที่เอกสาร Truck Sheet</td>
        <td><input type="text" value="111963" /></td>
        <td>หมายเลข Work Order</td>
        <td>42502</td>
    </tr>
    <tr>
        <th colspan="2"><u>Customer Information / ข้อมูลเกี่ยวกับลูกค้า</u></th>
        <th colspan="2"><u>Vendor information / ข้อมูลเกี่ยวกับบริษัท</u></th>
    </tr>
    <tr>
        <td>customer <br>ชื่อบริษัท</br></td>
        <td>Goodyear(Thailand) Pubilc Co.,Ltd.</th>
        <td>Vendor <br>ชื่อบริษัทขนส่ง</br></td>
        <td>N & DD International(thailand)Ltd.</td>
    </tr>
    <tr>
        <td>Customer Address <br>ที่อยู่</br></td>
        <td>50/9 Phaholyothin Road Km.36 Klong 1,Klongluang Pathumthani 12120</th>
        <td>Vendor Address <br>ที่อยู่</br></td>
        <td>10/19 M.4 Bangna-Trad Rd.,Bangchaiong Subdistrict Bangplee District,Samutprakarn 10540</td>
    </tr>
    <tr>
        <td>Customer Contact <br>ชื่อผู้ติดต่อ</br></td>
        <td>คุณเล็ก</th>
        <td>Vendor Contact <br>ผู้ติดต่อ</br></td>
        <td>Mr. Kwanmuang Janchote</td>
    </tr>
    <tr>
        <td>Customer Phone <br>โทรศัพท์</br></td>
        <td>02-909 8061; 085-812 5657</th>
        <td>Vendor Phone <br>โทรศัพท์</br></td>
        <td>081-9079932</td>
    </tr>
    <tr>
        <th colspan="2">Carrier information / ข้อมูลเกี่ยวกับบริษัทเดินเรือ</th>
        <th colspan="2">Assignment / ข้อมูลส่งมอบงาน</th>
    </tr>
    <tr>
        <td>Carrier Name</td>
        <td>ZIM LINE</th>
        <td>Service Mode <br>ชนิดการขนส่ง</br></td>
        <td>Outbound Non Ctcl - GY</td>
    </tr>
    <tr>
        <td>Carrier Contact & Phone <br>ชื่อผู้ติดต่อ/โทรศัพท์</br></td>
        <td>K.มะเหมี่ยว <br>02-2498633</br></th>
        <td>Customer Tariff <br>ประเภทการให้บริการลูกค้า</br></td>
        <td>CT (Same day Return) GOOD YEAR -- BANGNA/LKB - GY(Rangsit) - PAT 20'D</td>
    </tr>
    <tr>
        <td>Carrier Booking No <br>เลขที่ใบจองการเดินเรือ</br></td>
        <td>GOSUBKK002053046</th>
        <td>Vendor Tariff <br>ประเภทบริการของบริษัทขนส่ง</br></td>
        <td>CT (Same day Return) GOOD YEAR -- BANGNA/LKB - GY(Rangsit) - PAT 20'D</td>
    </tr>
    <tr>
        <td>Booking Date <br>วันที่จอง</br></td>
        <td>20-DEC-2019</td>
        <td>Remark <br>หมายเหตุ</br></td>
        <td></td>
    </tr>
    <tr>
        <th colspan="2">Service Information / ข้อมูลเกี่ยวกับการบริการ</th>
        <th colspan="2">Truck Information / ข้อมูลเกี่ยวกับรถบรรทุก</th>
    </tr>
    <tr>
        <td>Service Type <br>ประเภทการให้บริการ</br></td>
        <td>CT (Same day return) GOODYEAR -- BANGNA/LKB - GY(Rangsit) - PAT 20'D</td>
        <td>Truck <br>ทะเบียน/ยี่ห้อรถบรรทุก</br></td>
        <td>71-8777</td>
    </tr>
    <tr>
        <td>Container Type <br>ประเภทตู้สินค้า</br></td>
        <td>D20' Container</td>
        <td>Driver Name&Phone <br>ชื่อคนขับ/โทรศัพท์</br></td>
        <td></td>
    </tr>
    <tr>
        <td>Special Instruction <br>คำแนะนำในการส่งสินค้า</br></td>
        <td>CUT OFF TIME : 11:59 - PAT#1</td>
        <td>Container No <br>หมายเลขตู้สินค้า</br></td>
        <td>TGBU2402766</td>
    </tr>
    <tr>
        <td colspan="2"></td>
        <td>Discrepancy Reason <br>หมายเหตุในการส่งสินค้าล่าช้า</br></td>
        <td></td>
    </tr>
    <tr>
        <th colspan="2">Billing information / ข้อมูลด้านบัญชีการเงิน </th>
        <th colspan="2">Audit Information / ข้อมูลสำหรับตรวจสอบสถานะเอกสาร</th>
    </tr>
    <tr>
        <td>Customer Invoice <br>หมายเลขใบกำกับภาษีของลูกค้า</br></td>
        <td></td>
        <td>Assign Vendor By <br>ผู้รับมอบหมายให้บริษัทขนส่ง</br></td>
        <td>NAVIADA 20-DEC-2019</td>
    </tr>
    <tr>
        <td>Vendor Invoice No <br>หมายเลขใบกำกับภาษีบริษัทขนส่ง</br></td>
        <td></td>
        <td>Created By <br>ผู้สร้างเอกสาร</br></td>
        <td>NAVINDA 20-DEC-2019 14:48</td>
    </tr>
    <tr>
        <td>Billing Remark <br>หมายเหตุทางการเงิน</br></td>
        <td></td>
        <td>Updated By <br>ผู้แก้ไขเอกสารล่าสุด</br></td>
        <td>ndd 25-DEC-2019 14:50</td>
    </tr>
    <tr>
        <th></th>
        <th>Pickup Services / การไปรับสินค้า</th>
        <th>Delivery Services / การส่งสินค้า</th>
        <th>Return Services / การส่งคืนสินค้า</th>
    </tr>
    <tr>
        <td>Location <br>ชื่อสถานที่</br></td>
        <td>STAR PACIFIC</td>
        <td>GOODYEAR</td>
        <td>ท่าเรือคลองเตย</td>
    </tr>
    <tr>
        <td>Address <br>ที่อยู่</br></td>
        <td>60/3 Moo 13,Bangplee-Yai,Bangplee Samutprakarn</td>
        <td>50/9 หมู่3 ถ.พหลโยธิน กม.36 แขวง คลองหนึ่ง เขตคลองหลวง ปทุมธานี 12120</td>
        <td>คลองเตย พระราม 4 กรุงเทพ</td>
    </tr>
    <tr>
        <td>Contact <br>ชื่อผู้ติดต่อ</br></td>
        <td>K.Fon T.02-7512008-10</td>
        <td>คุณเล็ก 085-812 5657</td>
        <td>K.</td>
    </tr>
    <tr>
        <td>Expected Date Time <br>วัน/เวลาที่คาดหมาย</br></td>
        <td>21-DEC-2019</td>
        <td>21-DEC-2019</td>
        <td>21-DEC-2019</td>
    </tr>
    <tr>
        <td>Actual Date Time <br>วัน/เวลาจริง</br></td>
        <td>21-DEC-2019</td>
        <td>21-DEC-2019</td>
        <td>21-DEC-2019</td>
    </tr>
    <tr>
        <td>Remark <br>หมายเหตุ</br></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>
