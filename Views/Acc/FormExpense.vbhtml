@Code
    Layout = "~/Views/Shared/_ReportLandscape.vbhtml"
    ViewBag.Title = "Vender Summary Report"
    ViewBag.FileName = "export" & DateTime.Now.ToString("yyyyMMddHHMMss") & ".csv"
End Code
<style>
    * {
        font-size: 8px;
    }

    label {
        font-size: 10px;
    }
</style>
<label id="rptTitle" onclick="ExportData()">Report Title</label>
<div style="float:right" id="rptCliteria">Report Cliteria</div>
<div style="display:flex;flex-direction:column;width:100%">
    <table id="tbResult" style="width:100%">
        <thead></thead>
        <tbody></tbody>
        <tfoot></tfoot>
    </table>

</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let code = getQueryString("Code");
    let user = '@ViewBag.User';
    let lang = '@ViewBag.PROFILE_DEFAULT_LANG';
    $('#rptTitle').text('@ViewBag.Title');
    $('#rptCliteria').text('Ref# :' + code);
    $.ajax({
        url: path+'Acc/GetVenderReport?Branch=' + branch + '&No='+ code,
        type: "GET",
        contentType: "application/json",
        success: function (response) {
            let res = response.payment.data;
            if (res.length > 0) {
                var tb = res;
                let groupField = '';
                let groupVal = null;
                let colCount = 0;
                let sumGroup = [];
                let sumTotal = [];
                groupField = 'VenderInvNo';

                let html = '<thead><tr><th style="border:1px solid black;text-align:left;background-color:lightgrey;">#</th>';
                $.each(tb[0], function (key, value) {
                    if (key !== groupField) {
                        //html += '<th style="border:1px solid black;text-align:left;">' + key + '</th>';
                        html += '<th style="border:1px solid black;text-align:left;background-color:lightgrey;"><b>' + GetColumnHeader(key, lang) + '</b></th>';                        
                        sumGroup.push({ isSummary: ((colCount >= 8 && colCount< (Object.keys(tb[0]).length-3))? CheckAllIsNumber(tb, key) : false), value: 0 });
                        sumTotal.push(0);
                        colCount++;
                    }
                });

                html += '</tr></thead><tbody>';

                let groupCount = 0;
                let groupCaption = GetColumnHeader(groupField, lang);
                let row = 0;
                for (let r of tb) {
                    html += '<tr>';
                    if (groupField !== '') {
                        if (FormatValue(groupField, r[groupField]) !== groupVal) {
                            //Show Summary
                            if (groupCount > 0) {
                                html += '<td colspan="2" style="background-color:lightblue;border:1px solid black;text-align:left;"><u><b>SUB TOTAL</b></u></td>';
                                for (let i = 1; i < colCount; i++) {
                                    if (sumGroup[i].isSummary == true) {
                                        html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"><u><b>' + ShowNumber(sumGroup[i].value, 2) + '</b></u></td>';
                                    } else {
                                        html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"></td>';
                                    }
                                    sumGroup[i].value = 0;
                                }
                                html += '</tr><tr>';
                                groupCount = 0;
                            }
                            groupVal = FormatValue(groupField, r[groupField]);
                            groupCount++;

                            html += '<td colspan="' + (colCount+1) + '" style="background-color:lightyellow;border:1px solid black;text-align:left;">'+ groupCaption +' <b>' + GetGroupCaption(res.groupdata, groupField, groupVal) + '<b/></td>';
                            html += '</tr><tr>';
                        } else {
                            groupCount++;
                        }
                    }
                    row++;
                    html += '<td style="border:1px solid black;text-align:right;">' + row + '</td>';
                    let col = 0;
                    for (let c in r) {
                        if (c !== groupField) {
                            if (c.indexOf('Date') >= 0) {
                                html += '<td style="border:1px solid black;text-align:left;">' + ShowDate(r[c]) + '</td>';
                            } else {
                                if (r[c] !== null) {
                                    if (sumGroup[col].isSummary == true) {
                                        sumGroup[col].value += Number(r[c]);
                                        sumTotal[col] += Number(r[c]);
                                        html += '<td style="border:1px solid black;text-align:right;">' + ShowNumber(r[c], 2) + '</td>';
                                    } else {
                                        html += '<td style="border:1px solid black;text-align:left;">' + r[c] + '</td>';
                                    }
                                } else {
                                    html += '<td style="border:1px solid black;text-align:left;"></td>';
                                }
                            }
                            col++;
                        }
                    }
                    html += '</tr>';
                }
                //Last Total
                if (groupCount > 0) {
                    html += '<td colspan="2" style="background-color:lightblue;border:1px solid black;text-align:left;"><u><b>SUB TOTAL</b></u></td>';
                    for (let i = 1; i < colCount; i++) {
                        if (sumGroup[i].isSummary == true) {
                            html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"><u><b>' + ShowNumber(sumGroup[i].value, 2) + '</b></u></td>';
                        } else {
                            html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"></td>';
                        }
                    }
                    html += '</tr>';
                    groupCount = 0;
                }
                html+='</tbody>'
                //Grand Total
                html += '<tfoot><tr style="font-weight:bold;background-color:lightgreen;"><td colspan="2" style="border:1px solid black;text-align:left;"><b>GRAND TOTAL<b/></td>';
                for (let i = 1; i < colCount; i++) {
                    if (sumGroup[i].isSummary == true) {
                        html += '<td style="border:1px solid black;text-align:right;"><b>' + ShowNumber(sumTotal[i], 2) + '</b></td>';
                    } else {
                        html += '<td style="border:1px solid black;text-align:right;"></td>';
                    }
                }
                html += '</tr>';

                html += '</tfoot>';
                //ShowMessage(html);
                $('#tbResult').html(html);
            }
        }
    });

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
        csv.push($('#rptTitle').text());
        for (var i = 0; i < rows.length; i++) {
            var row = [], cols = rows[i].querySelectorAll("td, th");

            for (var j = 0; j < cols.length; j++)
                row.push(cols[j].innerText);

            csv.push(row.join("\t"));
        }
        csv.push($('#rptCliteria').text());
        // Download CSV file
        DownloadCSV(csv.join("\n"), filename);
    }
    function CheckAllIsNumber(arr, colName) {
        let tb = JSON.parse(JSON.stringify(arr));
        sortData(tb, colName, 'desc');
        try {
            let dbl = Number(tb[0][colName]);
            if (isNaN(dbl)==false) {
                return true;
            } else {
                return false;
            }
        } catch {
            return false;
        }
    }

</script>