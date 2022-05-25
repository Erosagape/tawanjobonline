<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
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
