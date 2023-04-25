@Code
    ViewData("Title") = "Loading"
    Dim c = 0
    Dim arrToday = "[""Release Port"",""Import"",""Export""]"
    For Each row In ViewBag.JobToday
        c += 1
        arrToday &= ","
        arrToday &= "['" & row.ClearPort & "'," & row.CountIM & "," & row.CountEX & "]"
    Next
    If c = 0 Then
        arrToday &= ",['N/A',0,0]"
    End If
    Dim arrLastWeek = "[""ETD/ETA Date"",""Import"",""Export""]"
    c = 0
    For Each row In ViewBag.JobLastWeek
        c += 1
        arrLastWeek &= ","
        arrLastWeek &= "['" & Convert.ToDateTime(row.ImExDate).ToString("dd/MM/yyyy") & "'," & row.CountIM & "," & row.CountEX & "]"
    Next
    If c = 0 Then
        arrLastWeek &= ",['N/A',0,0]"
    End If
    Dim arrNextWeek = "[""ETD/ETA Date"",""Import"",""Export""]"
    c = 0
    For Each row In ViewBag.JobNextWeek
        c += 1
        arrNextWeek &= ","
        arrNextWeek &= "['" & Convert.ToDateTime(row.ImExDate).ToString("dd/MM/yyyy") & "'," & row.CountIM & "," & row.CountEX & "]"
    Next
    If c = 0 Then
        arrNextWeek &= ",['N/A',0,0]"
    End If
End Code
<form class="container" method="post" action="">
    <b>At Date</b> 
    <br/>
    <input type="date" name="atDate" value="@ViewBag.AtDate" />
    <input type="submit" value="Show" class="btn btn-success" />
</form>
<div class="container">
    <div id="dvChartToday"></div>
    @If ViewBag.JobImToday.Count > 0 Then
        @<b> Import</b>
        For Each dt In ViewBag.JobImToday
            @<p>@dt.ClearPort-@dt.ClearPortName</p>
            @<div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Job No</th>
                            <th>Cust Inv</th>
                            <th>Declare</th>
                            <th>BL</th>
                            <th>Volume</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each row In dt.DataSource
                            @<tr>
                                <td>@row.job.JNo</td>
                                <td>@row.job.InvNo</td>
                                <td>@row.job.DeclareNumber</td>
                                <td>@row.job.HAWB</td>
                                <td>@row.job.TotalContainer</td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        Next
    End If
    @If ViewBag.JobExToday.Count > 0 Then
        @<b>Export</b>
        For Each dt In ViewBag.JobExToday
        @<p>@dt.ClearPort-@dt.ClearPortName</p>
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Job No</th>
                        <th>Cust Inv</th>
                        <th>Declare</th>
                        <th>BL</th>
                        <th>Volume</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In dt.DataSource
                        @<tr>
                            <td>@row.job.JNo</td>
                            <td>@row.job.InvNo</td>
                            <td>@row.job.DeclareNumber</td>
                            <td>@row.job.HAWB</td>
                            <td>@row.job.TotalContainer</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
        Next
    End If
</div>
<div class="container">
    <div id="dvChartLastWeek"></div>
    @For Each d In ViewBag.JobLastWeek
        @<b>@Convert.ToDateTime(d.ImExDate).ToString("dd/MM/yyyy")</b>
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Job#</th>
                        <th>Cust Inv#</th>
                        <th>BL#</th>
                        <th>Declare#</th>
                        <th>Release</th>
                        <th>Discharge</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In d.DataSource
                        For Each r In row.DataSource
                            @<tr>
                                <td>@r.job.JNo</td>
                                <td>@r.job.InvNo</td>
                                <td>@r.job.HAWB</td>
                                <td>@r.job.DeclareNumber</td>
                                <td>@r.job.ClearPort</td>
                                <td>@r.job.ClearPortNo</td>
                                <td>@r.job.TotalContainer</td>
                            </tr>
                        Next
                    Next
                </tbody>
            </table>
        </div>
    Next
</div>
<div class="container">
    <div id="dvChartNextWeek"></div>
    @For Each d In ViewBag.JobNextWeek
        @<b>@Convert.ToDateTime(d.ImExDate).ToString("dd/MM/yyyy")</b>
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Job#</th>
                        <th>Cust Inv#</th>
                        <th>BL#</th>
                        <th>Declare#</th>
                        <th>Release</th>
                        <th>Discharge</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In d.DataSource
                        For Each r In row.DataSource
                            @<tr>
                                <td>@r.job.JNo</td>
                                <td>@r.job.InvNo</td>
                                <td>@r.job.HAWB</td>
                                <td>@r.job.DeclareNumber</td>
                                <td>@r.job.ClearPort</td>
                                <td>@r.job.ClearPortNo</td>
                                <td>@r.job.TotalContainer</td>
                            </tr>
                        Next
                    Next
                </tbody>
            </table>
        </div>
    Next
</div>
<script type = "text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var arrToday = [@Html.Raw(arrToday)];
    var arrLastWeek = [@Html.Raw(arrLastWeek)];
    var arrNextWeek = [@Html.Raw(arrNextWeek)];

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);
    window.onresize = () => {
        drawChart();
    };

    function drawChart() {
        var data1 = google.visualization.arrayToDataTable(arrToday);

        var options1 = {
            width: 600,
            height: 400,
            legend: { position :'top', maxLines: 3 },
            bar: { groupWidth :'75%' },
            isStacked: true
        };

        var chart1 = new google.visualization.BarChart(document.getElementById('dvChartToday'));
        chart1.draw(data1, options1);

        var options2 = {
            title: 'Total Shipment Last Week',
            hAxis: {
                title: 'Date',
                format: 'dd/mm/yyyy'
            },
            vAxis: {
                title: 'Volume'
            },
            isStacked:true
        };

        var data2 = google.visualization.arrayToDataTable(arrLastWeek);

        var chart2 = new google.visualization.ColumnChart(
            document.getElementById('dvChartLastWeek'));

        chart2.draw(data2, options2);

        var options3 = {
            title: 'Total Shipment Next Week',
            hAxis: {
                title: 'Date',
                format: 'dd/mm/yyyy'
            },
            vAxis: {
                title: 'Volume'
            },
            isStacked: true
        };

        var data3 = google.visualization.arrayToDataTable(arrNextWeek);

        var chart3 = new google.visualization.ColumnChart(
            document.getElementById('dvChartNextWeek'));

        chart3.draw(data3, options3);
    }
</script>