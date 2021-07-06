@Code
    ViewData("Title") = "Planing By Inspection Date"
End Code
<table border="1" style="border-collapse:collapse">
    <thead>
        <tr>
            <th rowspan="2">No.</th>
            <th rowspan="2">วันที่่รับเอกสาร</th>
            <th>ชื่อ shipper</th>
            <th>ชื่อ สินค้า</th>
            <th>Inv.No</th>
            <th>ชื่อเรือ/เที่ยวบิน</th>
            <th rowspan="2">ETA</th>
            <th>จำนวน</th>
            <th rowspan="2">Loading Port</th>
            <th rowspan="2">Discharge Port</th>
            <th colspan="4">สายเรือ</th>
            <th rowspan="2">Surrender</th>
            <th>ราคาประมาณการ</th>
        </tr>
        <tr>
            <th>ชื่อ Consignee</th>
            <th>จำนวนตู้</th>
            <th>เบอร์ตู้</th>
            <th>Voyage</th>
            <th>น้ำหนัก</th>
            <th>DO</th>
            <th>มัดจำ</th>
            <th>ล้างตู้</th>
            <th>DEM</th>
            <th>ตรวจปล่อย</th>
        </tr>
    </thead>
    <tbody>
        @For Each dr As System.Data.DataRow In ViewBag.DataTable

        Next
    </tbody>
</table>

