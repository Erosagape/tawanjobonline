@Code
    ViewData("Title") = "Export"
End Code
<form method="post">
    Export Job Order :
    <br/>
    From Date <input type="date" name="dateFrom" />
    To Date <input type="date" name="dateTo" />
    <input type="submit" value="Export" />
</form>