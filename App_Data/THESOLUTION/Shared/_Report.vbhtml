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
        <div style="display:flex;flex-direction:column">
            <div style="display:flex">
                <div style="vertical-align:middle">
                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:100px;"  />
                </div>
                <div style="padding:5px;">
                    <div id="divCompany" style="text-align:left;color:darkblue;font-size:12px">
                        <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b>
                        <br /><b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b>

                    </div>
   		<div style="font-size:13px;">
                @ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2 โทร @ViewBag.PROFILE_COMPANY_TEL แฟกซ์ @ViewBag.PROFILE_COMPANY_FAX
                <br />@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN TEL @ViewBag.PROFILE_COMPANY_TEL  <br />FAX @ViewBag.PROFILE_COMPANY_FAX
                <br />เลขประจำตัวผู้เสียภาษี @ViewBag.PROFILE_TAXNUMBER สาขา: สำนักงานใหญ่
            	</div>

                </div>
            </div>
         
            <div style="width:100%;text-align:center">
                <h3>@ViewBag.ReportName</h3>
            </div>
            <div style="width:100%">
                @RenderBody()
            </div>
        </div>
        <div id="dvFooter" style="width:100%;font-size:8px">
            <p style="text-align:left">Printed By : @ViewBag.User Printed Date : @DateTime.Now</p>
        </div>
    </div>
</body>
</html>
