@Code
    ViewData("Title") = "Yearly"
    Dim arr = "[""Period"",""Import"",""Export""]"
    For Each row In ViewBag.JobCountMonthly
        arr &= ","
        arr &= "['" & row.JobYear & "/" & row.JobMonth.ToString("00") & "'," & row.JobCountIM & "," & row.JobCountEX & "]"
    Next
    Dim yearList = From data In DirectCast(ViewBag.JobCountMonthly, IEnumerable)
                   Select data.JobYear Distinct

    Dim arrAIE = "[""Period"",""Import"",""Export""]"
    For Each row In ViewBag.AdvSumMonthly
        arrAIE &= ","
        arrAIE &= "['" & row.PayYear & "/" & row.PayMonth.ToString("00") & "'," & row.SumPaymentIM & "," & row.SumPaymentEX & "]"
    Next

    Dim arrRIE = "[""Period"",""Import"",""Export""]"
    For Each row In ViewBag.RcpSumMonthly
        arrRIE &= ","
        arrRIE &= "['" & row.RcpYear & "/" & row.RcpMonth.ToString("00") & "'," & row.SumReceiveIM & "," & row.SumReceiveEX & "]"
    Next

    Dim arrRA = "[""Period"",""Receive"",""Payment""]"
    For Each row In ViewBag.SumAdvRcpMonthly
        arrRA &= ","
        arrRA &= "['" & row.FiscalYear & "/" & row.FiscalMonth.ToString("00") & "'," & row.TotalReceive & "," & row.TotalAdvance & "]"
    Next

    Dim arrBal = "[""Period"",""Cash Balance""]"
    For Each row In ViewBag.SumAdvRcpMonthly
        arrBal &= ","
        arrBal &= "['" & row.FiscalYear & "/" & row.FiscalMonth.ToString("00") & "'," & row.TotalReceive - row.TotalAdvance & "]"
    Next
End Code
<div class="container">
    <h2>Job Volume Yearly</h2>
    <div style="display:flex;flex-direction:row;">
        <div>
            From Year :
            <br />
            <select class="dropdown" id="cbFromYear">
                @For Each row In yearList
                    @<option>@row</option>
                Next
            </select>
        </div>
        <div>
            To Year :
            <br />
            <select class="dropdown" id="cbToYear">
                @For Each row In yearList
                    @<option>@row</option>
                Next
            </select>
        </div>
    </div>
    <div>
        <input type="button" class="btn btn-success" value="Show Data" onclick="ShowData()" />
        <input type="button" class="btn btn-warning" value="Reset Data" onclick="ResetData()" />
    </div>
</div>
<div class="container">
    <div id="dvChart"></div>
    <div id="dvTableJob" Class="table-responsive">
        <Table Class="table">
            <thead>
                <tr>
                    <th> Year</th>
                    <th> Month</th>
                    <th> Import</th>
                    <th> Export</th>
                </tr>
            </thead>
            <tbody>
                @For Each row In ViewBag.JobCountMonthly
                    @<tr>
                        <td>@row.JobYear</td>
                        <td>@row.JobMonth</td>
                        <td>@row.JobCountIM</td>
                        <td>@row.JobCountEX</td>
                    </tr>
                Next
            </tbody>
        </Table>
        <br />
        Advance Payments
        <div id="dvChartAdvIE"></div>
        <div id="dvTableAdvIE" Class="table-responsive">
            <Table Class="table">
                <thead>
                    <tr>
                        <th> Year</th>
                        <th> Month</th>
                        <th> Import</th>
                        <th> Export</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.AdvSumMonthly
                        @<tr>
                            <td>@row.PayYear</td>
                            <td>@row.PayMonth</td>
                            <td>@row.SumPaymentIM</td>
                            <td>@row.SumPaymentEX</td>
                        </tr>
                    Next
                </tbody>
            </Table>

        </div>
        Invoice Receipts
        <div id="dvChartRcpIE"></div>
        <div id="dvTableRcpIE" class="table-responsive">
            <Table class="table">
                <thead>
                    <tr>
                        <th> Year</th>
                        <th> Month</th>
                        <th> Import</th>
                        <th> Export</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.RcpSumMonthly
                        @<tr>
                            <td>@row.RcpYear</td>
                            <td>@row.RcpMonth</td>
                            <td>@row.SumReceiveIM</td>
                            <td>@row.SumReceiveEX</td>
                        </tr>
                    Next
                </tbody>
            </Table>
            --Summary--
            <div id="dvChartRcpAdv"></div>
            <div id="dvChartBal"></div>
        </div>
    </div>    
</div>
<script type = "text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript" src="~/Scripts/Func/util.js"></script>
<script type="text/javascript">
    var arrList = [@Html.Raw(arr)];
    var arrListAdvIE = [@Html.Raw(arrAIE)];
    var arrListRcpIE = [@Html.Raw(arrRIE)];
    var arrListRcpAdv = [@Html.Raw(arrRA)];
    var arrListBal = [@Html.Raw(arrBal)];

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);
    window.onresize = () => {
        drawChart();
    };
    function ShowData() {
        window.location.href = '@Url.Action("Yearly", "Chart")?FromYear='+ document.getElementById("cbFromYear").value+'&ToYear='+ document.getElementById("cbToYear").value;
    }

    function ResetData() {
        window.location.href = '@Url.Action("Yearly", "Chart")';
    }
    function drawChart() {
        if (getQueryString("fromYear") !== "")
            document.getElementById("cbFromYear").value = getQueryString("fromYear");
        if (getQueryString("ToYear") !== "")
            document.getElementById("cbToYear").value = getQueryString("ToYear");

        var data1 = google.visualization.arrayToDataTable(arrList);

        var options1 = {
            backgroundColor: '#ddd',
            legend: { position: 'bottom' },
            connectSteps: false,
            isStacked: true,
        };

        var chart1 = new google.visualization.SteppedAreaChart(document.getElementById('dvChart'));
        chart1.draw(data1, options1);

        var data2 = google.visualization.arrayToDataTable(arrListAdvIE);

        var options2 = {
            title: 'Total Payments',
            isStacked: true,
            hAxis: {
                title: 'Import/Export',
            },
            vAxis: {
                title: 'Total'
            }
        };
        var chart2 = new google.visualization.ColumnChart(document.getElementById('dvChartAdvIE'));
        chart2.draw(data2, options2);

        var data3 = google.visualization.arrayToDataTable(arrListRcpIE);

        var options3 = {
            title: 'Total Receive',
            hAxis: {
                title: 'Import/Export',
            },
            vAxis: {
                title: 'Total'
            }
        };
        var chart3 = new google.visualization.ColumnChart(document.getElementById('dvChartRcpIE'));
        chart3.draw(data3, options3);

        var data4 = google.visualization.arrayToDataTable(arrListRcpAdv);

        var options4 = {
            title: 'Company Performance',
            hAxis: { title: 'Year', titleTextStyle: { color: '#333' } },
            vAxis: { minValue: 0 }
        };

        var chart4 = new google.visualization.AreaChart(document.getElementById('dvChartRcpAdv'));

        chart4.draw(data4, options4);

        var data5 = google.visualization.arrayToDataTable(arrListBal);

        var options5 = {
            title: 'Cash Balance',
            curveType: 'function',
            legend: { position: 'bottom' }
        };

        var chart5 = new google.visualization.LineChart(document.getElementById('dvChartBal'));
        chart5.draw(data5, options5);
    }
</script>