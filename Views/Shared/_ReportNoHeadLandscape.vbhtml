<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" media="all">
    <link rel="stylesheet" href="~/Content/bootstrap-select.min.css" media="all">
    <link rel="stylesheet" href="~/Content/jquery.datatables.min.css" media="all">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js?@DateTime.Now.Ticks"></script>
    <script src="~/Scripts/Func/reports.js?@DateTime.Now.Ticks"></script>
    
    <style>
        table {
            width: 100%;
        }

            table td {
                white-space: nowrap; /** added **/
            }

        
    </style>
</head>
<body class="document">
    <div class="page" contenteditable="false">
        <table id="tblHeader">
            <tr>
                <td colspan="2" style="text-align:center">
                    <h2>@ViewBag.ReportName</h2>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    @RenderBody()
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p id="pFooter" style="text-align:right">Printed By : @ViewBag.User Printed Date : @DateTime.Now &copy; @DateTime.Now.Year - Tawan Technology Co.,ltd</p>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
