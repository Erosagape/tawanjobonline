@Code
    ViewData("Title") = "CashFlow"
End Code
<h2>Cash Flow</h2>
<input type="date" id="atDate" value="@ViewBag.AtDate" />
<input type="button" value="Refresh" class="btn btn-success" onclick="RefreshData()" />
<div class="container">
    <h3>Payments Balance</h3>
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
    <b>Weekly</b>
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
    <h3>Account Payables</h3>
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
    <h3>Account Receivables</h3>
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
<script type="text/javascript">
    function RefreshData() {
        window.location.href = '@Url.Action("Finance", "Chart")?AtDate=' + document.getElementById("atDate").value;
    }
</script>
