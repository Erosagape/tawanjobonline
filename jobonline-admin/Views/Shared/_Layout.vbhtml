<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Module</title>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <script src="~/Scripts/function.js"></script>
    <style>
        h2 {
            padding:5px 5px 5px 5px;
        }
        table {
            background-color:white;
        }
        div {
            padding:3px 3px 3px 3px;
        }
    </style>
</head>
<body style="background-color:black">    
    <div class="container body-content" style="background-color:aqua">
        <header>
            @ViewBag.UserName
        </header>
        <div style="background-color:white;height:50px;border:thin;padding:5px 5px 5px 5px;">
            <div style="float:left">
                <img src="~/Content/logo-tawan.jpg" style="width:100px" onclick="window.open('/home/index')" />
            </div>
            <div style="float:right;text-align:right;">
                <b>@ViewBag.Title</b>
            </div>
        </div>
        <div style="background-color:wheat;">
            @ViewBag.Error
            @RenderBody()
        </div>
        <footer>
            <p>&copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
        </footer>
    </div>
</body>
</html>
