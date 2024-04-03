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
    <link href="https://fonts.googleapis.com/css2?family=Sarabun:wght@300&display=swap" rel="stylesheet">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/Func/popup.js"></script>
    <script src="~/Scripts/Func/reports.js"></script>
    <style>
	* {
		font-size:11px;
	        font-family: 'Sarabun', sans-serif;
	}

    </style>
</head>
<body class="document">
    <div class="page" contenteditable="false">
<div style="display:flex;flex-direction:column;width:100%">
<div style="display:flex;flex-direction:row">
 <div style="flex:20%">
                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:150px"/>
 </div>
 <div style="flex:80%">
                    <div id="divCompany" style="text-align:left;color:darkblue;">
                        <b>@ViewBag.PROFILE_COMPANY_NAME</b>
                        <br />@ViewBag.PROFILE_COMPANY_ADDR1 <br/> @ViewBag.PROFILE_COMPANY_ADDR2
                        <br />Tel @ViewBag.PROFILE_COMPANY_TEL Fax @ViewBag.PROFILE_COMPANY_FAX E-mail/Website @ViewBag.PROFILE_COMPANY_EMAIL
                        <br />Tax-Reference ID : @ViewBag.PROFILE_TAXNUMBER Branch @ViewBag.PROFILE_TAXBRANCH
                    </div>
 </div>
</div>
                <div width="100%" style="flex:1;text-align:center">
                    <h2>@ViewBag.ReportName</h2>
                </div>
                <div width="100%" style="flex:1;">
                    @RenderBody()
                </div>
                <div width="100%" style="flex:1;">
                    <p style="text-align:right">Printed By : @ViewBag.User Printed Date : @DateTime.Now &copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
                </div>
</div>
        
    </div>
</body>
</html>
