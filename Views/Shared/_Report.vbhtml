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
     /*   div {
            page-break-inside: avoid;
            page-break-after: auto;
        }*/
        table tr {
            page-break-inside: avoid;
            page-break-after: auto;
        }

        thead {
            display: table-header-group;
       /*     display: table-row-group;*/
        }

        tbody {
            display: table-row-group;
        }

        tfoot {
            display: table-row-group;
          /*  display: table-footer-group;*/
        }

      /*  #tbResult tbody tr td {
            border-color: red !important
        }*/
    </style>
</head>

<body class="document">
    <div class="page" contenteditable="false">
        <div style="display:flex;flex-direction:column">
            @*<div style="display:flex" id="dvCompLogo">
                <div style="flex:1;vertical-align:middle">
                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:50px" />
                </div>
                <div style="flex:4;padding:5px;">
                    <div id="divCompany" style="text-align:left;color:darkblue;font-size:12px;">
                        <div style="height:25px;">
                            <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b>
                        </div>
                        <div>
                            <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b>
                        </div>
                    </div>
                </div>
            </div>
            <div style="font-size:10px;" id="dvCompAddr">
                @ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2 โทร @ViewBag.PROFILE_COMPANY_TEL แฟกซ์ @ViewBag.PROFILE_COMPANY_FAX
                <br />@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN TEL @ViewBag.PROFILE_COMPANY_TEL FAX @ViewBag.PROFILE_COMPANY_FAX
                <br />เลขประจำตัวผู้เสียภาษี @ViewBag.PROFILE_TAXNUMBER สาขา: สำนักงานใหญ่
            </div>

            <div style="width:100%;text-align:center">
                <h3>@ViewBag.ReportName</h3>
            </div>
            <div style="width:100%">
                @RenderBody()
            </div>*@

        <table border="0" style="width:100%">
            <thead>
                <tr>
                    <td>
                        <div style="display:flex;justify-content:center">
                            <img id="imgLogo" src="~/Resource/bft_header.png" style="width:90%;" />
                            <img id="imgLogoAdd" src="~/Resource/bft_header.jpeg" style="width:90%;display:none;" />
                            <img id="imgLogo2" src="~/Resource/invheader.jpg" style="width:90%;display:none;" />
                        </div>
                        
                        @*<div style="display:flex" id="dvCompLogo">
                            <div style="flex:1;vertical-align:middle">
                                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:50px" />
                            </div>
                            <div style="flex:4;padding:5px;">
                                <div id="divCompany" style="text-align:left;color:darkblue;font-size:12px;">
                                    <div style="height:25px;">
                                        <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b>
                                    </div>
                                    <div>
                                        <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="font-size:10px;" id="dvCompAddr">
                            @ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2 โทร @ViewBag.PROFILE_COMPANY_TEL แฟกซ์ @ViewBag.PROFILE_COMPANY_FAX
                            <br />@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN TEL @ViewBag.PROFILE_COMPANY_TEL FAX @ViewBag.PROFILE_COMPANY_FAX
                            <br />เลขประจำตัวผู้เสียภาษี @ViewBag.PROFILE_TAXNUMBER สาขา: สำนักงานใหญ่
                        </div>*@

                        <div style="width:100%;text-align:center">
                            <h3>@ViewBag.ReportName</h3>
                        </div>
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                       
                        
                    </td>
                </tr>

                <tr>
                    <td> @RenderBody()</td>
                </tr>
            </tbody>
        </table>

        </div>
        @*<div id="dvFooter" style="width:100%;font-size:8px">
            <p style="text-align:left">Printed By : @ViewBag.User Printed Date : @DateTime.Now</p>
        </div>*@
    </div>
</body>
</html>
