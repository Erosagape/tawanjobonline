@Code
    ViewData("Title") = "Costing Summary (Normal/Additional)"
End Code
<div id="dvMainDashboard">
    <div class="row">
        <div class="col-md-6">
            Year <input type="text" id="txtYear" /> Month <input type="text" id="txtMonth" />
            <input type="button" class="btn btn-success" value="Show" onclick="drawChart()" />
            <div id="chartSummary"></div>
        </div>
        <div class="col-md-6">
            <div id="valueTable"></div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            Date By
            <select id="cboGroup" onchange="drawChart()">
                <option value="j.DocDate">Open Date</option>
                <option value="j.ETDDate">ETD</option>
                <option value="j.ETADate">ETA</option>
                <option value="j.DutyDate">Inspection</option>
            </select>
            <br />
            Value:<br />
            <table id="tbDetail" class="table table-responsive">
                <thead>
                    <tr>
                        <th>Open Date</th>
                        <th>Inspection Date</th>
                        <th>Job No</th>
                        <th>Job Type</th>
                        <th>Ship By</th>
                        <th>Product</th>
                        <th>Customer Inv</th>
                        <th>Declare</th>
                        <th>ETD</th>
                        <th>ETA</th>
                        <th>Close</th>
                        <th>T.CTN</th>
                        <th class="all">Normal</th>
                        <th class="all">Addition</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    var user = '@ViewBag.User';
    var userGroup = '@ViewBag.UserGroup';
    $('#txtYear').val(new Date().getFullYear());
    $('#txtMonth').val(new Date().getMonth());
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChartSummary(dt) {
        var chartTable = google.visualization.arrayToDataTable(getDataTable(dt));
        var chartOptions = {
            legend: { position: 'top', maxLines: 3 },
        };
        var chartSummary = new google.visualization.BarChart(document.getElementById('chartSummary'));
        chartSummary.draw(chartTable, chartOptions);
    }
    function drawChart() {
        drawChartSummary([]);
        $('#valueTable').html('');
        let w = 'Mode=A&DateWhere=' + $('#cboGroup').val();
        if ($('#txtYear').val() !== '') {
            w += '&Year=' + $('#txtYear').val();
        }
        if ($('#txtMonth').val() !== '') {
            w += '&Month=' + $('#txtMonth').val();
        }
        if ('@ViewBag.UserGroup' == 'C') {
            w += '&Cust=@ViewBag.UserUpline';
        }
        if ('@ViewBag.UserGroup' == 'V') {
            w += '&Vend=@ViewBag.UserUpline';
        }
        //ShowWait();
        var url = 'joborder/getdashboardcost?'+w;
        $.get(path + url).done(function (r) {
            if (r.data.detail.length > 0) {
                $('#tbDetail').DataTable({
                    data: r.data.detail,
                    columns: [
                        { data: "DocDate", title: "Open Date" },
                        { data: "DutyDate", title: "Inspection Date" },
                        { data: "JNo", title: "Job No" },
                        { data: "JobTypeName", title: "Job Type" },
                        { data: "ShipByName", title: "Ship By" },
                        { data: "InvProduct", title: "Product" },
                        { data: "InvNo", title: "Customer Inv" },
                        { data: "DeclareNumber", title: "Declare" },
                        { data: "ETDDate", title: "ETD" },
                        { data: "ETADate", title: "ETA" },
                        { data: "CloseJobDate", title: "Close Date" },
                        { data: "TotalContainer", title: "T.CTN" },
                        { data: null, title: "Normal Cost",render:function(data){ return ShowNumber(data.SumNormalCost,2); } },
                        { data: null, title: "Addition Cost",render:function(data){ return ShowNumber(data.SumAdditionCost,2); }  }
                    ],
                    responsive:true,
                    destroy:true
                });
            }

            if (r.data.summary.length > 0) {
                let html = '<table class="table table-responsive">';
                html += '<thead><tr>';
                html += '<th>Normal Cost</th>';
                html += '<th>Value</th>';
                html += '</tr></thead><tbody>';
                for (let row of r.data.summary) {
                    html += '<tr>';
                    html += '<td>'+ row.JobTypeName+'</td>';
                    html += '<td>'+ ShowNumber(row.SumNormalCost,2) +'</td>';
                    html += '</tr>';
                }
                html += '</tbody></table>';
                html += '<table class="table table-responsive">';
                html += '<thead><tr>';
                html += '<th>Additional Cost</th>';
                html += '<th>Value</th>';
                html += '</tr></thead><tbody>';
                for (let row of r.data.summary) {
                    html += '<tr>';
                    html += '<td>' + row.JobTypeName + '</td>';
                    html += '<td>' + ShowNumber(row.SumAdditionCost,2) + '</td>';
                    html += '</tr>';
                }
                html += '</tbody></table>';

                $('#valueTable').html(html);
            }
            drawChartSummary(r.data.chart);
            //CloseWait();
        });
        return true;
    }
    function getChartTable(dt) {
        let cols = [];
        if (dt.length > 0) {
            let totalColumns = dt[0].length - 1;
            for (let i = 1; i <= totalColumns; i++) {
                cols.push(dt[0][i]);
                cols.push(i);
            }
        }
        return cols;
    }
    function getDataTable(dt) {
        if (dt.length > 0) {
            return dt;
        }
        dt = [["Type", "Value"], ["N/A", 0]];
        return dt;
    }
    function getDataView(tb) {
        let dt = getDataTable(tb);
        let totalColumns = dt[0].length - 1;
        let data = google.visualization.arrayToDataTable(dt);
        let view = new google.visualization.DataView(data);
        let columns = [];
        for (let i = 0; i <= totalColumns; i++) {
            if (i > 0) {
                columns.push(i);
                columns.push({
                    calc: function (dataTable, rowIndex) {
                        return getAnnotation(dataTable, rowIndex, i);
                    },
                    type: "string",
                    role: "annotation"
                });
            } else {
                columns.push(i);
            }
        }
        view.setColumns(columns);
        return view;
    }
    function getAnnotation(dataTable, rowIndex, columnIndex) {
        return dataTable.getFormattedValue(rowIndex, columnIndex) == "0" ? null : dataTable.getFormattedValue(rowIndex, columnIndex);
    }
    function getValueByText(id, value) {38
        let chk = '';
        $(id + ' > option').each(function () {
            if (this.text.split('/')[1].trim()==value.trim()) {
                chk = this.value;
            }
        });
        return chk;
    }
</script>


