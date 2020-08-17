<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" type="text/css" href="~/Content/sheets-of-paper-a4.css">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/Func/reports.js"></script>
    <style>
        * {
            font-size: 11px;
        }
    </style>
</head>

<body class="document">
    <div class="page" contenteditable="false">

        <div style="display:flex">
            <div style="flex:1;vertical-align:middle">
<br/>
                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:120px" />
            </div>
            <div style="flex:4;padding:5px;">
                <div id="divCompany" style="text-align:left;color:darkblue;font-size:14px">
                    <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b> (สำนักงานใหญ่)
                    <br />@ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2
                    <br />Tel @ViewBag.PROFILE_COMPANY_TEL Tax ID : @ViewBag.PROFILE_TAXNUMBER
                    <br />E-mail: @ViewBag.PROFILE_COMPANY_EMAIL
                </div>
            </div>
        </div>
        <div style="display:flex;flex-direction:column">
            <div style="width:100%;text-align:center">
                <h3>@ViewBag.ReportName</h3>
            </div>
            <div style="width:100%">
                @RenderBody()
            </div>
        </div>
    </div>
</body>
</html>
