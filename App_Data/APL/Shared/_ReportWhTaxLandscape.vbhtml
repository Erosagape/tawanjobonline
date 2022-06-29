<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" media="all">
    <link rel="stylesheet" href="~/Content/bootstrap-select.min.css" media="all">
    <link rel="stylesheet" href="~/Content/jquery.datatables.min.css" media="all">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/Func/reports.js"></script>
</head>
<body class="document">
    <div class="page" contenteditable="false">
        @RenderBody()
    </div>
</body>
</html>
