@Code
    ViewBag.Title = "Main Dashboard"
End Code
<div id="dvMainDashboard">
    <div class="row">
        <div class="col-md-6">
            Year <input type="text" id="txtYear" /> Month <input type="text" id="txtMonth" />
            <input type="button" class="btn btn-success" value="Show" onclick="drawChart()" />
            <div id="chartVal"></div>
        </div>
        <div class="col-md-6">
            <div id="valueTable"></div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            View By 
            <select id="cboGroup" onchange="drawChart()">
                <option value="j.CustCode">Customer</option>
                <option value="j.ConsigneeCode">Consignee</option>
                <option value="j.CSCode">CS Staff</option>
                <option value="j.ForwarderCode">Forwarder</option>
                <option value="j.AgentCode">Agent</option>
                <option value="j.ClearPort">Release Port</option>
                <option value="j.InvProduct">Commodity</option>
                <option value="j.InvCountry">Country</option>
                <option value="j.BookingNo">Booking.No</option>
                <option value="j.HAWB">BL.No</option>
                <option value="j.DeclareNumber">Declare.No</option>
                <option value="j.InvNo">Commercial Inv.</option>
                <option value="j.JNo">Job No</option>
                <option value="j.JobStatus">Job Status</option>
                <option value="sv.NameEng">Charges</option>

            </select>
            <div id="chartCust"></div>
        </div>
    </div>
</div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    var user = '@ViewBag.User';
    var userGroup = '@ViewBag.UserGroup';
    var cust = '';
    if (userGroup == 'C') {
        $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
            if (r.company.data.length > 0) {
                let dr = r.company.data[0];
                cust=dr.CustCode;
            }
        });
    }
    $('#txtYear').val(new Date().getFullYear());
    $('#txtMonth').val(new Date().getMonth());
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChartVal(dt) {
        var dataVol = google.visualization.arrayToDataTable(getDataTable(dt));
        var volOptions = {
            pieHole: 0.4
        };
        var chartVol = new google.visualization.PieChart(document.getElementById('chartVal'));
        chartVol.draw(dataVol, volOptions);
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
                ticks: [0, .25, .5, .75, 1]
            },
        };
        var chartCust = new google.visualization.BarChart(document.getElementById('chartCust'));
        chartCust.draw(custView, custOptions);
    }
    function drawChart() {
        drawChartVal([]);
        drawChartCust([]);
        $('#valueTable').html('');
        let w = 'OnWhere=';
        if ($('#txtYear').val() !== '') {
            w += '&OnYear=' + $('#txtYear').val();
        }
        if ($('#txtMonth').val() !== '' && $('#txtMonth').val() !== '0') {
            w += '&OnMonth=' + $('#txtMonth').val();
        }
        if (getQueryString('Cust') !== '') {
            w += '&OnWhere=j.CustCode&OnValue=' + getQueryString('Cust');
        }
        if (getQueryString('Vender') !== '') {
            w += '&OnWhere=j.ForwarderCode&OnValue=' + getQueryString('Vender');
        }
        if (getQueryString('Agent') !== '') {
            w += '&OnWhere=j.AgentCode&OnValue=' + getQueryString('Agent');
        }
        let type='@ViewBag.UserGroup'
        if (type == 'C') {
            w += '&OnWhere=j.CustCode&OnValue=' + cust + '&type=C';
        }
        if (type == 'V') {
            w += '&OnWhere=j.ForwarderCode&OnValue=@ViewBag.User';
        }

        //ShowWait();
        var url = 'acc/getsummaryrevenuemonthly?'+w;
        $.get(path + url).done(function (r) {
            if (r.data.length > 0) {
                drawChartVal(r.data);
            }
            if (r.table.length > 0) {
                let html = '<table class="table table-responsive">';
                html += '<thead><tr>';
                html += '<th>Summary</th>';
                html += '<th>Value</th>';
                html += '</tr></thead><tbody>';
                for (let row of r.table) {
                    if (type == 'C') {
                        html += '<tr>';
                        html += '<td>Expenses (Billed)</td>';
                        html += '<td>' + row.InvBill.toFixed(2) + '</td>';
                        html += '</tr>';

                        html += '<tr>';
                        html += '<td>Expenses (Non-Bill)</td>';
                        html += '<td>' + row.InvUnBill.toFixed(2) + '</td>';
                        html += '</tr>';

                    } else {
                        html += '<tr>';
                        html += '<td>Income (Billed)</td>';
                        html += '<td>' + row.RevenueBill.toFixed(2) + '</td>';
                        html += '</tr>';

                        html += '<tr>';
                        html += '<td>Income (Non-Bill)</td>';
                        html += '<td>' + row.RevenueUnBill.toFixed(2) + '</td>';
                        html += '</tr>';

                        html += '<tr>';
                        html += '<td>Cost</td>';
                        html += '<td>' + row.Cost.toFixed(2) + '</td>';
                        html += '</tr>';

                        html += '<tr>';
                        html += '<td>Profit</td>';
                        html += '<td>' + (Number(row.RevenueBill) - Number(row.Cost)).toFixed(2) + '</td>';
                        html += '</tr>';

                        html += '<tr>';
                        html += '<td>Profit (%)</td>';
                        html += '<td>' + row.ProfitRatio.toFixed(2) + '</td>';
                        html += '</tr>';

                        html += '<tr>';
                        html += '<td>Profit/Job</td>';
                        html += '<td>' + ((Number(row.RevenueBill) - Number(row.Cost)) / Number(row.JobCount)).toFixed(2) + '</td>';
                        html += '</tr>';

                    }
                    html += '<tr>';
                    html += '<td>Total Job</td>';
                    html += '<td>' + row.JobCount + '</td>';
                    html += '</tr>';
                }
                html += '</tbody></table>';
                $('#valueTable').html(html);
            }
            //CloseWait();
        });
        url = 'acc/getdetailrevenuemonthly?' + w + '&OnGroup=' + $('#cboGroup').val();
        $.get(path + url).done(function (r) {
            if (r.data.length > 0) {
                drawChartCust(r.data);
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
        dt = [["Type", "Value"], ["Cost", 0], ["Revenue", 0]];
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
    function getValueByText(id, value) {
        let chk = '';
        $(id + ' > option').each(function () {
            if (this.text.split('/')[1].trim()==value.trim()) {
                chk = this.value;
            }
        });
        return chk;
    }
</script>