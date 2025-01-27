@Code
    ViewData("Title") = "Summary"
    Dim sql = ""
    Dim dateFrom = Request.Form("dateFrom")
    Dim dateTo = Request.Form("dateTo")
    Dim submit = Request.Form("submit")
    If ViewBag.User <> "" Then
        Dim dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL("SELECT ConfigValue from Mas_Config Where ConfigKey='PostJobToAcc'")
        If dt.Rows.Count > 0 Then
            sql = dt.Rows(0)(0).ToString()
        End If
        If submit <> "" Then
            sql = sql.Replace("{0}", dateFrom)
            sql = sql.Replace("{1}", dateTo)
            sql = sql.Replace("{2}", dateTo)
            sql = sql.Replace("{3}", ViewBag.User)
            'submit = New CUtil(ViewBag.CONNECTION_JOB).ExecuteSQL(sql)
            submit = sql
        End If
    End If
End Code
<h2>Summary</h2>
<form action="" method="post">
    <div class="row">
        <div class="col-sm-2">
            Date From
        </div>
        <div class="col-sm-3">
            <input type="date" class="form-control" name="dateFrom" value="@dateFrom" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Date To
        </div>
        <div class="col-sm-3">
            <input type="date" class="form-control" name="dateTo" value="@dateTo" />
        </div>
    </div>
    <input type="submit" name="submit" value="Submit" />
</form>
<span>
    @submit
</span>
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>