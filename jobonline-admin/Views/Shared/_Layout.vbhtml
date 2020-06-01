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
    </style>
</head>
<body style="background-color:black">    
    <div class="container body-content" style="background-color:white">
        <u><a href="/Home/Index">Main Menu</a></u>
        <header style="text-align:right;background-color:aqua;height:50px;border:thin;padding:10px 10px 10px 10px;">
            <b>@ViewBag.Title</b> - @ViewBag.UserName
        </header>
        @RenderBody()
        <hr />
        @ViewBag.Error
        <footer>
            <p>&copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
        </footer>
    </div>
</body>
</html>
