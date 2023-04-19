@Code
    ViewData("Title") = "CashFlow"
End Code
<h2>Cash Flow</h2>
<input type="date" id="atDate" value="@ViewBag.AtDate" />
<input type="button" value="Refresh" class="btn btn-success" onclick="RefreshData()" />
@If ViewBag.SumCashDaily.Count > 0 Then
    @<table>
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
<script type="text/javascript">
    function RefreshData() {
        window.location.href = '@Url.Action("Finance", "Chart")?AtDate=' + document.getElementById("atDate").value;
    }
</script>
