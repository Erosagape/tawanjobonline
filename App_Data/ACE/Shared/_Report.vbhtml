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
                <br />
                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:130px" ondblclick="ChangeAddress()" />
            </div>
            <div style="flex:4;padding:5px;">
                @if ViewBag.PROFILE_DEFAULT_LANG = "EN" Then
                    @<div id="divCompany" style="text-align:left;color:darkblue;font-size:12px">
                        <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b>
                        <br />@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN
                        <br />Tel @ViewBag.PROFILE_COMPANY_TEL E-Mail @ViewBag.PROFILE_COMPANY_EMAIL
                        <br />Tax ID @ViewBag.PROFILE_TAXNUMBER Branch: HEAD OFFICE
                    </div>
                Else
                    @<div id="divCompany" style="text-align:left;color:darkblue;font-size:12px">
                        <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b>
                        <br />@ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2
                        <br />Tel @ViewBag.PROFILE_COMPANY_TEL E-Mail @ViewBag.PROFILE_COMPANY_EMAIL
                        <br />Tax ID @ViewBag.PROFILE_TAXNUMBER Branch: สำนักงานใหญ่
                    </div>
                End If
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
        <div id="dvFooter" style="width:100%;font-size:8px">
            <p style="text-align:left">Printed By : @ViewBag.User Printed Date : @DateTime.Now &copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
        </div>
    </div>
    <script type="text/javascript">
        var lang = '@ViewBag.PROFILE_DEFAULT_LANG';
        function ChangeAddress() {
            if (confirm('Do you want to change address to old company') == true) {
                let html = '';
                if (lang == 'TH') {
                    html = '<b style="font-size:18px">บริษัท แอดวานซ์ คาร์โก้ เอ็กซ์เพรส จำกัด</b>';
                    html += '<br />21 ซอยร่มเกล้า 21/3 แขวงคลองสามประเวศ เขตลาดกระบัง กรุงเทพมหานคร 10520';
                    html += '<br />Tel (+66)2 067 0660 E-Mail ace@th.ace.com';
                    html += '<br />Tax ID 0105558166206 Branch: สำนักงานใหญ่';
                } else {
                    html = '<b style="font-size:18px">ADVANCE CARGO EXPRESS CO.,LTD</b>';
                    html += '<br />21 ROMKLAO 21/3 KLONGSAMPRAVET LADKRABANG BANGKOK 10520 THAILAND ';
                    html += '<br />Tel (+66)2 067 0660 E-Mail ace@th.ace.com';
                    html += '<br />Tax ID 0105558166206 Branch: HEAD OFFICE';
                }
                $('#divCompany').html(html);
            }
        }
    </script>
</body>
</html>
