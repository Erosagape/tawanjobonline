@Code
    ViewData("Title") = "Cash Flow"
    Dim arrVen = "[""Vender"",""Total""]"
    Dim arrCust = "[""Customer"",""Total""]"
    Dim arrCashWeekly = "[""Due Date"",""Total Expense"",""Total Receive""]"
    Dim arrCashMonthly = "[""Period"",""Total Expense"",""Total Receive""]"
    Dim arrAPMonth = "[""Vender"",""Total""]"
    Dim arrARMonth = "[""Customer"",""Total""]"

    Dim c = 0
    For Each row In ViewBag.SumVendDaily
        arrVen &= ","
        arrVen &= "[""" & row.VenderName & """," & row.SumExpense & "]"
        c += 1
    Next
    If c = 0 Then
        arrVen &= ",[""N/A"",0]"
    End If

    c = 0
    For Each row In ViewBag.SumCustDaily
        arrCust &= ","
        arrCust &= "[""" & row.CustName & """," & row.SumReceive & "]"
        c += 1
    Next
    If c = 0 Then
        arrCust &= ",[""N/A"",0]"
    End If

    c = 0
    For Each row In ViewBag.SumCashWeekly
        arrCashWeekly &= ","
        arrCashWeekly &= "[""" & Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy") & """," & row.TotalExpense & "," & row.TotalReceive & "]"
        c += 1
    Next
    If c = 0 Then
        arrCashWeekly &= ",[""N/A"",0,0]"
    End If

    c = 0
    For Each row In ViewBag.SumCashMonthly
        arrCashMonthly &= ","
        arrCashMonthly &= "[""" & String.Concat(row.DueYear, "/", row.DueMonth) & """," & row.TotalExpense & "," & row.TotalReceive & "]"
        c += 1
    Next
    If c = 0 Then
        arrCashMonthly &= ",[""N/A"",0,0]"
    End If

    c = 0
    For Each row In ViewBag.APMonth
        arrAPMonth &= ","
        arrAPMonth &= "[""" & row.VenderName & """," & row.TotalPayment & "]"
        c += 1
    Next
    If c = 0 Then
        arrAPMonth &= ",[""N/A"",0]"
    End If

    c = 0
    For Each row In ViewBag.ARMonth
        arrARMonth &= ","
        arrARMonth &= "[""" & row.CustName & """," & row.TotalInvoice & "]"
        c += 1
    Next
    If c = 0 Then
        arrARMonth &= ",[""N/A"",0]"
    End If
End Code
<h2>Cash Flow</h2>
<input type="date" id="atDate" value="@ViewBag.AtDate" />
<input type="button" value="Refresh" class="btn btn-success" onclick="RefreshData()" />
<div class="container">
    <h3>Payments Balance</h3>
    <br />- Expenses Payment
    <div id="dvChartVenToday"></div>
    <br />- Invoice Receive
    <div id="dvChartCustToday"></div>
    <div class="table-responsive">
        @If ViewBag.SumCashDaily.Count > 0 Then
            @<table class="table">
                <thead>
                    <tr>
                        <th>Due Date</th>
                        <th>Expense Payment</th>
                        <th>Invoice Receive</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.SumCashDaily
                        @<tr style="background-color:greenyellow">
                            <td>@Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy")</td>
                            <td>@row.TotalExpense</td>
                            <td>@row.TotalReceive</td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
    </div>
    <b>Weekly</b>
    <div id="dvChartWeeklyCash"></div>
    <div class="table-responsive">
        @If ViewBag.SumCashWeekly.Count > 0 Then
            @<table class="table">
                <thead>
                    <tr>
                        <th>Due Date</th>
                        <th>Expense Payment</th>
                        <th>Invoice Receive</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.SumCashWeekly
                        @<tr>
                            <td>@Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy")</td>
                            <td>@row.TotalExpense</td>
                            <td>@row.TotalReceive</td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
    </div>
    <b>Monthly</b>
    <div id="dvChartMonthlyCash"></div>
    <div class="table-responsive">
        @If ViewBag.SumCashMonthly.Count > 0 Then
            @<table class="table">
                <thead>
                    <tr>
                        <th>Period</th>
                        <th>Expense Payment</th>
                        <th>Invoice Receive</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.SumCashMonthly
                        @<tr>
                            <td>@String.Concat(row.DueYear, "/", row.DueMonth)</td>
                            <td>@row.TotalExpense</td>
                            <td>@row.TotalReceive</td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
    </div>
</div>
<div class="container">
    <h3>Account Payables Monthly</h3>
    <div id="dvChartAPMonth"></div>
    <b>Today</b>
    @If ViewBag.APToday.Count > 0 Then
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Vender</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.APToday
                        @<tr>
                            <td>@row.VenderName</td>
                            <td>@row.TotalPayment</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If
    <b>Last Week</b>
    @If ViewBag.APLastWeek.Count > 0 Then
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.APLastWeek
                        @<tr>
                            <td>@Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy")</td>
                            <td>@row.TotalPayment</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If
    <b>Next Week</b>
    @If ViewBag.APNextWeek.Count > 0 Then
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.APNextWeek
                        @<tr>
                            <td>@Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy")</td>
                            <td>@row.TotalPayment</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If

</div>
<div class="container">
    <h3>Account Receivables Monthly</h3>
    <div id="dvChartARMonth"></div>
    <b>Today</b>
    @If ViewBag.ARToday.Count > 0 Then
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Customer</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.ARToday
                        @<tr>
                            <td>@row.CustName</td>
                            <td>@row.TotalInvoice</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If
    <b>Last Week</b>
    @If ViewBag.ARLastWeek.Count > 0 Then
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.ARLastWeek
                        @<tr>
                            <td>@Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy")</td>
                            <td>@row.TotalInvoice</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If
    <b>Next Week</b>
    @If ViewBag.ARNextWeek.Count > 0 Then
        @<div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each row In ViewBag.ARNextWeek
                        @<tr>
                            <td>@Convert.ToDateTime(row.DueDate).ToString("dd/MM/yyyy")</td>
                            <td>@row.TotalInvoice</td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If
</div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var arrVend = [@Html.Raw(arrVen)];
    var arrCust = [@Html.Raw(arrCust)];
    var arrCashWeekly = [@Html.Raw(arrCashWeekly)];
    var arrCashMonthly = [@Html.Raw(arrCashMonthly)];
    var arrAPMonth = [@Html.Raw(arrAPMonth)];
    var arrARMonth = [@Html.Raw(arrARMonth)];

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);
    window.onresize = () => {
        drawChart();
    };
    function drawChart() {
        var data1 = google.visualization.arrayToDataTable(arrVend);

        var options1 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart1 = new google.visualization.BarChart(document.getElementById('dvChartVenToday'));
        chart1.draw(data1, options1);

        var data2 = google.visualization.arrayToDataTable(arrCust);

        var options2 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart2 = new google.visualization.BarChart(document.getElementById('dvChartCustToday'));
        chart2.draw(data2, options2);

        var data3 = google.visualization.arrayToDataTable(arrCashWeekly);

        var options3 = {
            title: 'Total Cash Weekly',
            hAxis: {
                title: 'Date',
                format: 'dd/mm/yyyy'
            },
            vAxis: {
                title: 'Value'
            },
            isStacked: true
        };

        var chart3 = new google.visualization.ColumnChart(document.getElementById('dvChartWeeklyCash'));
        chart3.draw(data3, options3);

        var data4 = google.visualization.arrayToDataTable(arrCashMonthly);

        var options4 = {
            title: 'Total Cash Monthly',
            hAxis: {
                title: 'Period',
            },
            vAxis: {
                title: 'Value'
            },
            isStacked: true
        };

        var chart4 = new google.visualization.ColumnChart(document.getElementById('dvChartMonthlyCash'));
        chart4.draw(data4, options4);

        var data5 = google.visualization.arrayToDataTable(arrAPMonth);

        var options5 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart5 = new google.visualization.BarChart(document.getElementById('dvChartAPMonth'));
        chart5.draw(data5, options5);

        var data6 = google.visualization.arrayToDataTable(arrARMonth);

        var options6 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart6 = new google.visualization.BarChart(document.getElementById('dvChartARMonth'));
        chart6.draw(data6, options6);
    }
    function RefreshData() {
        window.location.href = '@Url.Action("Finance", "Chart")?AtDate=' + document.getElementById("atDate").value;
    }
</script>
