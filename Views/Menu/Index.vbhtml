@Code
    ViewBag.Title = "Main Dashboard"
End Code
<div id="dvCliteria">
    <div class="row">
        <div class="col-sm-3">
            Job Type : <br /><select id="cboJobType" class="form-control dropdown" onchange="checkJobType()"></select>
        </div>
        <div class="col-sm-3">
            Transport By : <br /><select id="cboShipBy" class="form-control dropdown" onchange="drawChart()"></select>
        </div>
        <div class="col-sm-2">
            Duty Date From :<br />
            <input type="date" id="txtDateFrom" class="form-control" />
        </div>
        <div class="col-sm-2">
            Duty Date To :<br />
            <input type="date" id="txtDateTo" class="form-control" />
        </div>
        <div class="col-sm-2">
            <input type="checkbox" id="chkAutoRefresh" checked />Auto Refresh<br />
            <input type="button" class="btn btn-success" onclick="RefreshGrid()" value="Show" />
            <input type="button" class="btn w3-indigo" onclick="CreateNewJob()" value="New" />
        </div>
    </div>
</div>
<div id="dvMainDashboard">
    <div class="row">
        <div class="col-md-6">
            <b>Volume By Status:</b>
            <div id="chartVol"></div>
        </div>
        <div class="col-md-6">
            <b>Status By Shipment Type:</b>
            <div id="chartStatus"></div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <b>Status By Customer:</b>
            <div id="chartCust"></div>
        </div>
    </div>
</div>
<script type="text/javascript" src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    var jobtype = '';
    var user = '@ViewBag.User';
    var userGroup = '@ViewBag.UserGroup';

    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);

    window.onresize = () => {
        CheckSession(drawChart());
    }
    setInterval(function () {
        if ($('#chkAutoRefresh').prop('checked')) {
            CheckSession(drawChart());
        }
    }, 300000);
    SetLOVs();

    function SetLOVs() {
        loadCombos(path, 'SHIP_BY=#cboShipBy,JOB_TYPE=#cboJobType');
        return;
    }
    function RefreshGrid() {
        CheckSession(drawChart());
    }
    function getWhere() {
        let w = '';
        if ($('#cboJobType').val() > '') {
            if (w == '') w += '?';
            w += 'JobType=' + $('#cboJobType').val();
        }
        if ($('#cboShipBy').val() > '') {
            w += (w !== '' ? '&' : '?');
            w += 'ShipBy=' + $('#cboShipBy').val();
        }
        if ($('#txtDateFrom').val()!==null) {
            w += (w !== '' ? '&' : '?');
            w += 'DateFrom=' + CDateEN($('#txtDateFrom').val());
        }
        if ($('#txtDateTo').val()!==null) {
            w += (w !== '' ? '&' : '?');
            w += 'DateTo=' + CDateEN($('#txtDateTo').val());
        }
        if (userGroup == 'C') {
            w += (w !== '' ? '&' : '?');
            w += 'Cust=' + user;
        }
        return w;
    }
    function checkJobType() {
        if (jobtype !== $('#cboJobType').val()) {
            jobtype = $('#cboJobType').val();
            loadShipByByType(path, jobtype, '#cboShipBy');
            drawChart();
            return;
        }
        drawChart();
        return;
    }
    function drawChartVol(dt) {
        var dataVol = google.visualization.arrayToDataTable(getDataTable(dt));
        var volOptions = {
            title: 'Total Job By Status',
            pieHole: 0.4,
        };
        var chartVol = new google.visualization.PieChart(document.getElementById('chartVol'));
        chartVol.draw(dataVol, volOptions);
    }
    function drawChartStatus(dt) {
        var statusView = getDataView(dt);
        var statusOptions = {
            legend: { position: 'top', maxLines: 3 },
            isStacked: 'percent',
            hAxis: {
                minValue: 0,
                ticks: [0, .25, .5, .75, 1]
            }
        };
        var chartStatus = new google.visualization.ColumnChart(document.getElementById('chartStatus'));
        chartStatus.draw(statusView, statusOptions);
    }
    function drawChartCust(dt) {
        var chartHeight = dt.length * 30;
        var custView = getDataView(dt);
        var custOptions = {
            legend: { position: 'top' },
            height: chartHeight,
            isStacked: 'percent',
            hAxis: {
                minValue: 0,
                ticks: [0, .3, .6, .9, 1]
            }
        };
        var chartCust = new google.visualization.BarChart(document.getElementById('chartCust'));
        chartCust.draw(custView, custOptions);
    }
    function drawChart() {   
        drawChartVol([]);
        drawChartStatus([]);
        drawChartCust([]);
        //ShowWait();
        $.get(path + 'JobOrder/GetDashBoard' + getWhere()).done(function (r) {
            if (r.result.length > 0) {
                drawChartVol(r.result[0].data1);
                drawChartStatus(r.result[0].data2);
                drawChartCust(r.result[0].data3);
            }
            //CloseWait();
        });
        return true;
    }
    function getDataTable(dt) {
        if (dt.length > 0) {
            return dt;
        }
        dt = [["Status", "Volume"], ["ALL", 0]];
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
    function CreateNewJob() {
        window.open(path +'joborder/createjob?JType=' + $('#cboJobType').val() + '&SBy=' + $('#cboShipBy').val() + '&Branch=' + branch);
    }

</script>