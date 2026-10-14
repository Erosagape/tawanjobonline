@Code
    ViewData("Title") = "Export"
End Code
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>
<h2>Export Job Order To Excel</h2>
<form method="post">
    From Date <input type="date" name="dateFrom" />
    To Date <input type="date" name="dateTo" />
    <input type="submit" value="Export" />
    <div>
        @ViewBag.Data
    </div>
</form>
