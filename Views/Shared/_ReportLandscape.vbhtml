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
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/Func/popup.js"></script>
    <script src="~/Scripts/Func/reports.js"></script>
    <style>
    table {    
	page-break-before:avoid;
        page-break-inside:auto;
    }
   tr    { page-break-inside:avoid; page-break-after:auto; }
    </style>
</head>
<body class="document">
    <div class="page" contenteditable="false">
	<div style="display:flex;flex-direction:column;">
		<div style="display:flex;flex-direction:row;">
                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:20%"/>
                    <div id="divCompany" style="text-align:left;color:darkblue;font-size:11px;">
                        <b>@ViewBag.PROFILE_COMPANY_NAME</b>
                        <br />@ViewBag.PROFILE_COMPANY_ADDR1 <br/> @ViewBag.PROFILE_COMPANY_ADDR2
                        <br />Tel @ViewBag.PROFILE_COMPANY_TEL Fax @ViewBag.PROFILE_COMPANY_FAX E-mail/Website @ViewBag.PROFILE_COMPANY_EMAIL
                        <br />Tax-Reference ID : @ViewBag.PROFILE_TAXNUMBER Branch @ViewBag.PROFILE_TAXBRANCH
                    </div>
		</div>
                <b>@ViewBag.ReportName</b>
                @RenderBody()                
	</div>

    </div>
</body>
</html>
