<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" href="~/Content/Site.css">
    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <link rel="stylesheet" href="~/Content/bootstrap-select.min.css">
    <link rel="stylesheet" href="~/Content/jquery.datatables.min.css">
    <link rel="stylesheet" href="~/Content/responsive.dataTables.min.css">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/DataTables/dataTables.responsive.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootbox.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <style>
        body {
            background-color: #145314;
        }

        .panel-body {
            background-color: #f1f1e6;
        }

        .panel-body, .panel-heading {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <div class="container body-content">
        <div class="panel-primary">
            <div class="panel-body" >
                @RenderBody()
            </div>
        </div>
    </div>
</body>
</html>
