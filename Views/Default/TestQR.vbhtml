@Code
    ViewData("Title") = "TestQR"
    Layout = "~/Views/Shared/_Report.vbhtml"
End Code
<h2>Test QR Code</h2>
<div id="dvQR"></div>
<script src="~/Scripts/qrcode/jquery.qrcode.js"></script>
<script src="~/Scripts/qrcode/qrcode.js"></script>
<script>
    var path = '@Url.Content("~")';
    var timeStamp ='@ViewBag.SESSION_ID'+'_'+ GetTime().replaceAll(' ', '').replaceAll('-', '').replaceAll(':', '');
    var url = 'http://103.225.168.137/test/default/testcanvas?id=' + timeStamp;
    $('#dvQR').qrcode({
        width: 115,
        height:115,
        text: url
    });
</script>
