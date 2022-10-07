@Code
    ViewData("Title") = "Import Excel"
End Code

<h2>Import Excel</h2>
<input type="hidden" id="dbName" value="@ViewBag.DatabaseName" />
<form method="post" action="" enctype="multipart/form-data">
    <input type="file" name="xlsFiles" />
    <input type="submit" value="Submit" />
</form>
<span>@ViewBag.Result</span>
<script>
    var path = '@Url.Content("~")';
    if ('@ViewBag.Result' !== 'Ready') {
        alert('@ViewBag.Result');
    }
</script>
