<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>@ViewBag.Title</title>
    <link rel="stylesheet" type="text/css" href="~/Content/sheets-of-paper-a4.css" />
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/Func/util.js"></script>
    <script src="~/Scripts/Func/reports.js"></script>
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Sarabun:wght@300;400;600;700&display=swap" rel="stylesheet" />
    <style>
        * { font-family: 'Sarabun', sans-serif; font-size: 10px; text-transform: uppercase; }
        #main { width: 100%; border-collapse: collapse; }
        #main > thead { display: table-header-group; }
        #main > tbody { display: table-row-group; }
        #main > thead > tr > th { font-weight: normal; }
        .company-header-row > th, .invoice-header-row > th { border: 0 !important; text-align: left; vertical-align: top; padding: 0 !important; }
        #main > tbody#invoice-ending > tr > td { border: 0 !important; padding: 0 !important; }
        @@media print {
            @@page { size: A4; margin: 10mm 10mm 12mm 10mm; }
            html, body { margin: 0 !important; padding: 0 !important; height: auto !important; overflow: visible !important; }
            body.document { background: none !important; }
            .page { display: block !important; width: auto !important; height: auto !important; min-height: 0 !important; max-height: none !important; overflow: visible !important; margin: 0 !important; padding: 0 !important; border: 0 !important; box-shadow: none !important; break-after: auto !important; page-break-after: auto !important; }
            #main { display: table !important; width: 100% !important; border-collapse: collapse !important; }
            #main > thead { display: table-header-group !important; }
            #main > tbody { display: table-row-group !important; }
            #main > thead > tr, #main > tbody#details > tr { break-inside: avoid; page-break-inside: avoid; }
            #main > thead > tr > th { vertical-align: top; }
            .company-header-row > th, .invoice-header-row > th { padding: 0 !important; }
            #report-company-header { margin: 0 !important; padding: 0 !important; }
            #dvCompLogo { height: auto !important; min-height: 0 !important; align-items: center !important; }
            #imgLogo { width: auto !important; max-width: 120px !important; max-height: 65px !important; object-fit: contain; }
            #dvCompAddr, #dvCompTelEmail, #dvCompTaxNum { padding: 1px 3px !important; line-height: 1.1 !important; }
            #dvTitle, #dvTitle h3 { margin: 2px 0 !important; padding: 0 !important; }
            #main > thead .table td, #main > thead .table th { padding: 2px !important; line-height: 1.1 !important; }
        }

        /* PRINT: each page is a separate DOM sheet, not a repeating table header */
        #invoice-print-pages { position:absolute; left:-10000px; top:0; width:210mm; visibility:hidden; }
        .invoice-sheet { width:210mm; height:297mm; padding:10mm 10mm 12mm; box-sizing:border-box; background:white; overflow:hidden; }
        .invoice-sheet-content { height:100%; width:100%; overflow:hidden; }
        .invoice-sheet table { border-collapse:collapse; width:100%; }
        .invoice-sheet .invoice-detail-table > tbody > tr > td { padding:0.3em; border-left:1px solid black; border-right:1px solid black; vertical-align:top; overflow-wrap:anywhere; }
.invoice-sheet:not(:last-child)
.invoice-detail-table > tbody > tr:last-child > td {
    border-bottom: 1px solid black !important;
}
        .invoice-sheet .invoice-detail-table > thead > tr.invoice-column-header > th { padding:0.3em; border-left:1px solid black; border-right:1px solid black; }
        .invoice-sheet .invoice-detail-table > thead > tr.company-header-row > th,
        .invoice-sheet .invoice-detail-table > thead > tr.invoice-header-row > th { border:0 !important; padding:0 !important; text-align:left; vertical-align:top; font-weight:normal; }
        @@media print {
            @@page { size:A4; margin:0; }
            html,body,body.document { width:auto !important; height:auto !important; margin:0 !important; padding:0 !important; background:white !important; overflow:visible !important; }
            body > .page { display:none !important; }
            #invoice-print-pages { display:block !important; position:static !important; left:auto !important; top:auto !important; width:auto !important; visibility:visible !important; }
            .invoice-sheet { display:block; width:210mm !important; height:297mm !important; min-height:297mm !important; margin:0 !important; padding:10mm 10mm 12mm !important; border:0 !important; box-shadow:none !important; overflow:hidden !important; break-after:page; page-break-after:always; }
            .invoice-sheet:last-child { break-after:auto; page-break-after:auto; }
            .invoice-sheet-content { height:100%; overflow:hidden; }
            .invoice-sheet .invoice-detail-table > thead { display:table-header-group; }
            .invoice-sheet .invoice-detail-table > tbody > tr { break-inside:avoid; page-break-inside:avoid; }
        }

.invoice-sheet
.invoice-detail-table > tbody > tr:last-child > td {
    border-bottom: 1px solid black !important;
}
    </style>
    @RenderSection("ReportStyles", required:=False)
</head>
<body class="document">
    <div class="page">
        <table id="main">
            <thead>
                <tr class="company-header-row">
                    <th colspan="10">
                        <div id="report-company-header">
                            <div style="display:flex;width:100%" id="dvCompLogo">
                                <div style="flex:40;vertical-align:middle;text-align:center;">
                                    <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:80%" />
                                </div>
                                <div style="flex:75;padding:5px;">
                                    <div id="divCompany" style="text-align:left;color:#FF6601;font-size:12px;">
                                        <div><b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b></div>
                                    </div>
                                    <div style="font-size:11px;color:black;padding:3px;" id="dvCompAddr">@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN</div>
                                    <div style="font-size:11px;color:black;padding:3px;" id="dvCompTelEmail">TEL. : @ViewBag.PROFILE_COMPANY_TEL E-MAIL : @ViewBag.PROFILE_COMPANY_EMAIL</div>
                                    <div style="font-size:11px;color:black;padding:3px;" id="dvCompTaxNum">เลขประจำตัวผู้เสียภาษี : @ViewBag.PROFILE_TAXNUMBER สาขา : สำนักงานใหญ่</div>
                                </div>
                            </div>
                            <div id="dvTitle" style="width:100%;text-align:center"><h3>@ViewBag.ReportName</h3></div>
                        </div>
                    </th>
                </tr>
                <tr class="invoice-header-row">
                    <th colspan="10">
                        @RenderSection("InvoiceHeader", required:=False)
                    </th>
                </tr>
                @RenderSection("InvoiceColumns", required:=False)
            </thead>
            <tbody id="details"></tbody>
            <tbody id="invoice-ending">
                <tr><td colspan="10">@RenderBody()</td></tr>
            </tbody>
        </table>
    </div>
    <div id="invoice-print-pages" aria-hidden="true"></div>
    @RenderSection("ReportScripts", required:=False)
</body>
</html>
