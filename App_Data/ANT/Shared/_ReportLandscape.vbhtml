<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" media="all">
    <link rel="stylesheet" href="~/Content/bootstrap-select.min.css" media="all">
    <link rel="stylesheet" href="~/Content/jquery.datatables.min.css" media="all">
    <link rel="stylesheet" type="text/css" href="~/Content/sheets-of-paper-a4-landscape.css" media="all">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@300&display=swap" rel="stylesheet">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/Func/popup.js"></script>
    <script src="~/Scripts/Func/reports.js"></script>
    <style>
        table,
        table tr td,
        table tr th {
            page-break-inside: avoid;
        }
        * {
            font-family:'Prompt',sans-serif;
        }
    </style>
</head>
<body class="document">
    <div class="page" contenteditable="false">
        <table id="tblHeader" width="100%">
            <tr>
                <td width="90%">
                    <div id="divCompany" style="text-align:left;font-size:9px;">
                        <b>@ViewBag.PROFILE_COMPANY_NAME_EN (HEAD OFFICE)</b><br />
                        <b>@ViewBag.PROFILE_COMPANY_NAME (สำนักงานใหญ่)</b>
                        <br />@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN
                        <br />@ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2
                        <br />Tel @ViewBag.PROFILE_COMPANY_TEL E-Mail @ViewBag.PROFILE_COMPANY_EMAIL TAX REFERENCE : @ViewBag.PROFILE_TAXNUMBER
                    </div>
                </td>
                <td width="10%" style="text-align:center">
                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:50px" />
                </td>
            </tr>
            <tr>
                <td colspan="2" width="100%" style="text-align:center">
                    <h2>@ViewBag.ReportName</h2>
                </td>
            </tr>
            <tr>
                <td colspan="2" width="100%">
                    @RenderBody()
                </td>
            </tr>
            <tr>
                <td colspan="2" width="100%">
                    <p style="text-align:right">Printed By : @ViewBag.User Printed Date : @DateTime.Now &copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
