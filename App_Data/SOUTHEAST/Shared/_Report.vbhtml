﻿<!DOCTYPE html>
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
                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:100px" />
            </div>
            <div style="flex:4;padding:5px;">
                <div id="divCompany" style="text-align:left;color:darkblue;font-size:14px">
                    <div style="font-weight:bold;font-size:16px">
                        @ViewBag.PROFILE_COMPANY_NAME (@ViewBag.PROFILE_TAXBRANCH)<br />
                        @ViewBag.PROFILE_COMPANY_NAME_EN
                    </div>
                    @ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2<br />
                    @ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN<br />
                    Tel @ViewBag.PROFILE_COMPANY_TEL Fax @ViewBag.PROFILE_COMPANY_FAX E-mail/Website @ViewBag.PROFILE_COMPANY_EMAIL
                    <br />Tax-Reference ID : @ViewBag.PROFILE_TAXNUMBER
                </div>
            </div>
        </div>
        <div style="display:flex;flex-direction:column">
            <div style="width:100%;text-align:center">
                <h3>@ViewBag.ReportName</h3>
            </div>
            <div id="dvBody" style="width:100%">
                @RenderBody()
            </div>
        </div>
        <div style="width:100%;font-size:8px">
            <p style="text-align:left">Printed By : @ViewBag.User Printed Date : @DateTime.Now &copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
        </div>
    </div>
</body>
</html>
