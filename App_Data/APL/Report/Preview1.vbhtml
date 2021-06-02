@Code
    Layout = "~/Views/Shared/_ReportNoHeadLandscape.vbhtml"
    ViewBag.FileName = "export" & DateTime.Now.ToString("yyyyMMddHHMMss") & ".xls"
End Code
<style>
    * {
        font-size: 11px;
    }

    label {
        font-size: 14px;
    }
</style>
<label id="rptTitle" onclick="ExportData()">Report Title</label>
<div style="display:flex;flex-direction:column;width:100%">
    <table id="tbResult" style="width:100%">
        <thead></thead>
        <tbody></tbody>
        <tfoot></tfoot>
    </table>
</div>
<div style="float:right" id="rptCliteria">Report Cliteria</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let data = getQueryString("data");
    let cliteria = getQueryString("cliteria");
    let user = '@ViewBag.User';
    let lang = '@ViewBag.PROFILE_DEFAULT_LANG';
    let row = {};
    if (data !== '') {
        row = JSON.parse(data);
        let obj = JSON.parse(cliteria);
        html = '';
        if (obj.DATEFROM !== '') html += obj.DATEFROM + ',';
        if (obj.DATETO !== '') html += obj.DATETO + ',';
        if (obj.CUSTWHERE !== '') html += obj.CUSTWHERE + ',';
        if (obj.JOBWHERE !== '') html += obj.JOBWHERE + ',';
        if (obj.VENDWHERE !== '') html += obj.VENDWHERE + ',';
        if (obj.STATUSWHERE !== '') html += obj.STATUSWHERE + ',';
        if (obj.EMPWHERE !== '') html += obj.EMPWHERE + ',';
        if (obj.CODEWHERE !== '') html += obj.CODEWHERE + ',';
        if (obj.GROUPWHERE !== '') html += obj.GROUPWHERE + ',';
        $('#rptCliteria').html('REPORT CODE:' + row.REPORTCODE + ', CLITERIA:'+ html);
        switch (lang) {
            case 'TH':
                $('#rptTitle').text(row.REPORTNAMETH);
                break;
            case 'EN':
                $('#rptTitle').text(row.REPORTNAMEEN);
                break;
        }
        if (row.ReportCode !== '') {
            let data = {
                ReportType: row.REPORTTYPE,
                ReportCode: row.REPORTCODE,
                ReportCliteria: html
            }
            if (data.ReportType == 'EXP') {
                if (data.ReportCode == 'SETAR' || data.ReportCode == 'CUTAR') {
                    $('#rptCliteria').css('display', 'none');
                }
                LoadReportNoTotal(path, row.REPORTCODE, data, lang);
            }
            else
            {
                LoadReport(path, row.REPORTCODE, data, lang);
            }
        }
    }
    function ExportData() {
        var ans = confirm("Download This Data?");
        if (ans == true) {
            ExportTableToCSV('@ViewBag.FileName');
        }
    }
    function DownloadCSV(csv, filename) {
        var csvFile;
        var downloadLink;

        // CSV file
        csvFile = new Blob(["\ufeff" + csv], { type: "text/csv;charset=utf-8" });

        // Download link
        downloadLink = document.createElement("a");

        // File name
        downloadLink.download = filename;

        // Create a link to the file
        downloadLink.href =window.URL.createObjectURL(csvFile);

        // Hide download link
        downloadLink.style.display = "none";

        // Add the link to DOM
        document.body.appendChild(downloadLink);

        // Click download link
        downloadLink.click();
    }

    function ExportTableToCSV(filename) {
        var csv = [];
        var rows = document.querySelectorAll("#tbResult tr");
        //csv.push($('#rptTitle').text());
        for (var i = 0; i < rows.length; i++) {
            var row = [], cols = rows[i].querySelectorAll("td, th");

            for (var j = 0; j < cols.length; j++)
                row.push(cols[j].innerText);

            csv.push(row.join("\t"));
        }
        //csv.push($('#rptCliteria').text());
        // Download CSV file
        DownloadCSV(csv.join("\n"), filename);
    }


</script>