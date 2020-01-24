@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "Truck Order"
    ViewBag.Title = "Truck Order"

End Code
<style>
    * {
        font-size: 9px;
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
        <th>วันที่เอกสาร</th>
        <th colspan="3">20-DEC-2019 14:48</th>
    </tr>
    <tr>
        <td>เลขที่เอกสาร Truck Sheet</td>
        <td><label id="txtValue1"></label></td>
        <td>หมายเลข Work Order</td>
        <td><label id="txtValue2"></label></td>
    </tr>
    <tr>
        <td>ชื่อเรือ/เที่ยว</td>
        <td></td>
        <td>ปลายทาง(Port)</td>
        <td></td>
    </tr>
    <tr>
        <td>วัน-เวลาปิดรับ</td>
        <td></td>
        <td>วันเรือออก</td>
        <td></td>
    </tr>
    <tr>
        <td>คำแนะนำในการส่งสินค้า</td>
        <td><label id="txtValue23"></label></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <th colspan="2">ข้อมูลเกี่ยวกับลูกค้า</th>
        <th colspan="2">ข้อมูลเกี่ยวกับบริษัทเดินเรือ</th>
    </tr>
    <tr>
        <td>ชื่อบริษัทลูกค้า</td>
        <td><label id="txtValue3"></label></td>
        <td>ชือบริษัทเดินเรือ</td>
        <td><label id="txtValue11"></label></td>
    </tr>
    <tr>
        <td>ที่อยู่</td>
        <td><label id="txtValue5"></label></td>
        <td>ชื่อผู้ติดต่อ/โทรศัพท์</td>
        <td><label id="txtValue13"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>บุ้คกิ้ง</td>
        <td><label id="txtValue15"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>วันที่จอง</td>
        <td><label id="txtValue17"></label></td>
    </tr>
    <tr>
        <th colspan="2">ข้อมูลเกี่ยวกับการบริการ</th>
        <th colspan="2">ข้อมูลเกี่ยวกับรถบรรทุก</th>
    </tr>
    <tr>
        <td>ประเภทการให้บริการ</td>
        <td><label id="txtValue19"></label></td>
        <td>ทะเบียนรถบรรทุก</td>
        <td><label id="txtValue20"></label></td>
    </tr>
    <tr>
        <td>ขนาดตู้คอนเทนเนอร์</td>
        <td><label id="txtValue21"></label></td>
        <td>ชื่อคนขับ/โทรศัพท์</td>
        <td><label id="txtValue22"></label></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>หมายเลขตู้คอนเทนเนอร์</td>
        <td><label id="txtValue24"></label></td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td><label id="txtValue18"></label></td>
        <td>หมายเหตุในการส่งตู้ล่าช้า</td>
        <td><label id="txtValue25"></label></td>
    </tr>
    <tr>
        <th></th>
        <th>สถานที่รับตู้</th>
        <th>ไปส่งที่</th>
        <th>สถานที่ส่งคืน</th>
    </tr>
    <tr>
        <td>ชื่อสถานที่</td>
        <td><label id="txtValue32"></label></td>
        <td><label id="txtValue33"></label></td>
        <td><label id="txtValue34"></label></td>
    </tr>
    <tr>
        <td>ที่อยู่</td>
        <td><label id="txtValue35"></label></td>
        <td><label id="txtValue36"></label></td>
        <td><label id="txtValue37"></label></td>
    </tr>
    <tr>
        <td>ชื่อผู้ติดต่อ</td>
        <td><label id="txtValue38"></label></td>
        <td><label id="txtValue39"></label></td>
        <td><label id="txtValue40"></label></td>
    </tr>
    <tr>
        <td>วัน/เวลา</td>
        <td><label id="txtValue41"></label></td>
        <td><label id="txtValue42"></label></td>
        <td><label id="txtValue43"></label></td>
    </tr>
    <tr>
        <td>วัน/เวลาจริง</td>
        <td><label id="txtValue44"></label></td>
        <td><label id="txtValue45"></label></td>
        <td><label id="txtValue46"></label></td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td><label id="txtValue47"></label></td>
        <td><label id="txtValue48"></label></td>
        <td><label id="txtValue49"></label></td>
    </tr>
</table>
<script type="text/javascript">
    var val1 = localStorage.getItem("Value1");
    var val2 = localStorage.getItem("Value2");
    var val23 = localStorage.getItem("Value23");
    var val3 = localStorage.getItem("Value3");
    var val11 = localStorage.getItem("Value11");
    var val5 = localStorage.getItem("Value5");
    var val13 = localStorage.getItem("Value13");
    var val15 = localStorage.getItem("Value15");
    var val17 = localStorage.getItem("Value17");
    var val19 = localStorage.getItem("Value19");
    var val20 = localStorage.getItem("Value20");
    var val21 = localStorage.getItem("Value21");
    var val22 = localStorage.getItem("Value22");
    var val24 = localStorage.getItem("Value24");
    var val18 = localStorage.getItem("Value18");
    var val25 = localStorage.getItem("Value25");
    var val32 = localStorage.getItem("Value32");
    var val33 = localStorage.getItem("Value33");
    var val34 = localStorage.getItem("Value34");
    var val35 = localStorage.getItem("Value35");
    var val36 = localStorage.getItem("Value36");
    var val37 = localStorage.getItem("Value37");
    var val38 = localStorage.getItem("Value38");
    var val39 = localStorage.getItem("Value39");
    var val40 = localStorage.getItem("Value40");
    var val41 = localStorage.getItem("Value41");
    var val42 = localStorage.getItem("Value42");
    var val43 = localStorage.getItem("Value43");
    var val44 = localStorage.getItem("Value44");
    var val45 = localStorage.getItem("Value45");
    var val46 = localStorage.getItem("Value46");
    var val47 = localStorage.getItem("Value47");
    var val48 = localStorage.getItem("Value48");
    var val49 = localStorage.getItem("Value49");
    if (val1 !== null) {
        document.getElementById("txtValue1").innerText = val1;
    }
    if (val2 !== null) {
        document.getElementById("txtValue2").innerText = val2;
    }
    if (val23 !== null) {
        document.getElementById("txtValue23").innerText = val23;
    }
    if (val3 !== null) {
        document.getElementById("txtValue3").innerText = val3;
    }
    if (val11 !== null) {
        document.getElementById("txtValue11").innerText = val11;
    }
    if (val5 !== null) {
        document.getElementById("txtValue5").innerText = val5;
    }
    if (val13 !== null) {
        document.getElementById("txtValue13").innerText = val13;
    }
    if (val15 !== null) {
        document.getElementById("txtValue15").innerText = val15;
    }
    if (val17 !== null) {
        document.getElementById("txtValue17").innerText = val17;
    }
    if (val18 !== null) {
        document.getElementById("txtValue18").innerText = val18;
    }

    if (val19 !== null) {
        document.getElementById("txtValue19").innerText = val19;
    }
    if (val20 !== null) {
        document.getElementById("txtValue20").innerText = val20;
    }
    if (val21 !== null) {
        document.getElementById("txtValue21").innerText = val21;
    }
    if (val22 !== null) {
        document.getElementById("txtValue22").innerText = val22;
    }
    if (val24 !== null) {
        document.getElementById("txtValue24").innerText = val24;
    }
    if (val25 !== null) {
        document.getElementById("txtValue25").innerText = val25;
    }
    if (val32 !== null) {
        document.getElementById("txtValue32").innerText = val32;
    }
    if (val33 !== null) {
        document.getElementById("txtValue33").innerText = val33;
    }
    if (val34 !== null) {
        document.getElementById("txtValue34").innerText = val34;
    }
    if (val35 !== null) {
        document.getElementById("txtValue35").innerText = val35;
    }
    if (val36 !== null) {
        document.getElementById("txtValue36").innerText = val36;
    }
    if (val37 !== null) {
        document.getElementById("txtValue37").innerText = val37;
    }
    if (val38 !== null) {
        document.getElementById("txtValue38").innerText = val38;
    }
    if (val39 !== null) {
        document.getElementById("txtValue39").innerText = val39;
    }
    if (val40 !== null) {
        document.getElementById("txtValue40").innerText = val40;
    }
    if (val41 !== null) {
        document.getElementById("txtValue41").innerText = val41;
    }
    if (val42 !== null) {
        document.getElementById("txtValue42").innerText = val42;
    }
    if (val43 !== null) {
        document.getElementById("txtValue43").innerText = val43;
    }
    if (val44 !== null) {
        document.getElementById("txtValue44").innerText = val44;
    }
    if (val45 !== null) {
        document.getElementById("txtValue45").innerText = val45;
    }
    if (val46 !== null) {
        document.getElementById("txtValue46").innerText = val46;
    }
    if (val47 !== null) {
        document.getElementById("txtValue47").innerText = val47;
    }
    if (val48 !== null) {
        document.getElementById("txtValue48").innerText = val48;
    }
    if (val49 !== null) {
        document.getElementById("txtValue49").innerText = val49;
    }
</script>
