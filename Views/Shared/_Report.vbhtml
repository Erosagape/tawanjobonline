<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" type="text/css" href="~/Content/sheets-of-paper-a4.css">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/Func/util.js?@DateTime.Now.ToString("yyyyMMddHHMMss")"></script>
    <script src="~/Scripts/Func/reports.js?@DateTime.Now.ToString("yyyyMMddHHMMss")"></script>
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Sarabun:wght@300&display=swap" rel="stylesheet">
    <style>
        * {
            font-size: 10px;
            font-family: 'Sarabun', sans-serif;
        }
        div {
            page-break-inside: avoid;
            page-break-before: avoid;
            page-break-after: auto;
        }

    </style>
</head>

<body class="document">
    <div class="page" contenteditable="false">
        <div style="display:flex;flex-direction:column;">
            <div style="flex:1">
                <div style="display:flex;flex-direction:row;" id="dvCompLogo">
                    <div style="flex:20;vertical-align:middle;text-align:center">
                        <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:100px" />
                    </div>
                    <div style="flex:80;padding:5px;margin:5px 5px 5px 5px;">
                        <div id="divCompany" style="text-align:left;color:darkblue;font-size:12px;">
                            <div style="height:25px;">
                                <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b>
                            </div>
                            @*<div>
                        <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b>
                    </div>*@
                        </div>
                        <div style="font-size:12px;" id="dvCompAddr">
                            @* @ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2 โทร @ViewBag.PROFILE_COMPANY_TEL แฟกซ์ @ViewBag.PROFILE_COMPANY_FAX
                    <br />*@

                            <div style="margin-bottom:5px;">@ViewBag.PROFILE_COMPANY_ADDR1_EN </div>
                            <div style="margin-bottom:5px;">@ViewBag.PROFILE_COMPANY_ADDR2_EN </div>
                            <div style="margin-bottom:5px;">TEL @ViewBag.PROFILE_COMPANY_TEL FAX @ViewBag.PROFILE_COMPANY_FAX</div>
                            <div style="margin-bottom:5px;">TAX-ID @ViewBag.PROFILE_TAXNUMBER BRANCH : HEAD OFFICE</div>
                        </div>
                    </div>
                </div>
            </div>

            <div style="flex:1;width:100%;text-align:center">
                <h3>@ViewBag.ReportName</h3>
            </div>
            <div style="flex:1">
                @RenderBody()
            </div>
        </div>
    </div>
</body>
</html>
