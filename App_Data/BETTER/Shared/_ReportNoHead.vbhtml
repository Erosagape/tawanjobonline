<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link rel="stylesheet" type="text/css" href="~/Content/sheets-of-paper-a4.css" media="all">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/Func/util.js?_=@Date.Now"></script>
    <script src="~/Scripts/Func/reports.js?_=@Date.Now"></script>
</head>
<body class="document">
    <div class="page" contenteditable="false">
        @RenderBody()
        <p id="pFooter" style="text-align:right">Printed By : @ViewBag.User Printed Date : @DateTime.Now  </p>
    </div>
</body>

</html>
