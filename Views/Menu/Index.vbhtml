@Code
    ViewBag.Title = "Main Dashboard"
End Code
<div id="dvCliteria">
    <div class="row">
        <div class="col-sm-3">
            <label id="lblJobType">Job Type </label>
            : <br /><select id="cboJobType" class="form-control dropdown" onchange="checkJobType()"></select>
        </div>
        <div class="col-sm-3">
            <label id="lblShipBy">Transport By</label>
             : <br /><select id="cboShipBy" class="form-control dropdown" onchange="drawChart()"></select>
        </div>
        <div class="col-sm-2">
            <label id="lblDateFrom">Duty Date From</label>
            :<br />
            <input type="date" id="txtDateFrom" class="form-control" />
        </div>
        <div class="col-sm-2">
            <label id="lblDateTo">Duty Date To</label>
            :<br />
            <input type="date" id="txtDateTo" class="form-control" />
        </div>
        <div class="col-sm-2">
            <input type="checkbox" id="chkAutoRefresh" checked /><label id="lblAutoRefresh">Auto Refresh</label><br />
            <button class="btn btn-success" id="btnUpdate" onclick="RefreshGrid()">Update</button>
            <button class="btn w3-indigo" id="btnAddJob" onclick="CreateNewJob()">New</button>
        </div>
    </div>
</div>
<div id="dvMainDashboard">
    <div class="row">
        <div class="col-md-6">
            <b><label id="lblGrid1">Volume By Status</label>:</b>
            <div id="chartVol"></div>
        </div>
        <div class="col-md-6">
            <b><label id="lblGrid2">Status By Job Type</label>:</b>
            <div id="chartStatus"></div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <b><label id="lblGrid3">Status By Customer</label>:</b>
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
    var chartType = getQueryString("Type");
    var firstDateOfMonth = [new Date().getFullYear(), CCode(new Date().getMonth()+1), '01'].join('-');
    var lastDateOfMonth = [new Date().getFullYear(), CCode(new Date().getMonth()+1), new Date(new Date().getFullYear(), new Date().getMonth() + 1, 0).getDate()].join('-');

    $('#txtDateFrom').val(firstDateOfMonth);
    $('#txtDateTo').val(lastDateOfMonth);
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
            pieHole: 0.4,
        };
        var chartVol = new google.visualization.PieChart(document.getElementById('chartVol'));
        google.visualization.events.addListener(chartVol, 'select', function (e) {
            if (chartVol.getSelection() != null &&  
                    chartVol.getSelection()[0] != null &&  
                    chartVol.getSelection()[0]['row'] != null &&  
                    chartVol.getSelection().length > 0)  
            {  

                alert(dataVol.getFormattedValue(chartVol.getSelection()[0].row,0) + '='+ dataVol.getFormattedValue(chartVol.getSelection()[0].row,1));
            }  
        });
        chartVol.draw(dataVol, volOptions);
    }
    function drawChartStatus(dt) {
        var statusView = getDataView(dt);
        var statusTable = getChartTable(dt);
        var statusOptions = {
            legend: { position: 'top', maxLines: 3 },
            isStacked: 'percent',
            hAxis: {
                minValue: 0,
                ticks: [0, .25, .5, .75, 1]
            }
        };
        var chartStatus = new google.visualization.ColumnChart(document.getElementById('chartStatus'));
        google.visualization.events.addListener(chartStatus, 'select', function (e) {
            if (chartStatus.getSelection() != null &&  
                    chartStatus.getSelection()[0] != null &&  
                    chartStatus.getSelection()[0]['row'] != null &&  
                    chartStatus.getSelection().length > 0)  
            {  

                let val = statusView.getFormattedValue(chartStatus.getSelection()[0]['row'], chartStatus.getSelection()[0]['column']);
                let row = statusView.getFormattedValue(chartStatus.getSelection()[0]['row'], 0);
                let col = statusTable[chartStatus.getSelection()[0]['column']-1];
                alert(row + '/' + col +'='+ val);
            }  
        });
        chartStatus.draw(statusView, statusOptions);
    }
    function drawChartCust(dt) {
        var chartHeight = dt.length * 60;
        var custTable = getChartTable(dt);
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
        google.visualization.events.addListener(chartCust, 'select', function (e) {
            if (chartCust.getSelection() != null &&  
                    chartCust.getSelection()[0] != null &&  
                    chartCust.getSelection()[0]['row'] != null &&  
                    chartCust.getSelection().length > 0)  
            {  

                let val = custView.getFormattedValue(chartCust.getSelection()[0]['row'], chartCust.getSelection()[0]['column']);
                let row = custView.getFormattedValue(chartCust.getSelection()[0]['row'], 0);
                let col = custTable[chartCust.getSelection()[0]['column']-1];
                alert(row + '/' + col +'='+ val);
            }  
        });
        chartCust.draw(custView, custOptions);
    }

    function drawChart() {   
        drawChartVol([]);
        drawChartStatus([]);
        drawChartCust([]);
        //ShowWait();
        var url = 'JobOrder/GetDashBoard';
        if (chartType !== '') {
            url += '_' + chartType;
        }
        $.get(path + url + getWhere()).done(function (r) {
            if (r.result.length > 0) {
                drawChartVol(r.result[0].data1);
                drawChartStatus(r.result[0].data2);
                drawChartCust(r.result[0].data3);
            }
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