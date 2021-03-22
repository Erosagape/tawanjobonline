@Code
    ViewData("Title") = "UpVersion"
End Code
<h2>Update Version</h2>
<input type="button" id="btnReport" value="Create Report Data" onclick="ImportReportToDb()" />
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function ImportReportToDb() {
        let reportLists = { data: GetReportLists_V2() }
        let reportGroups = { data: GetReportGroups() }
        $.post(path + 'Admin/ImportReportGroup', reportGroups,(r) => {
            ShowMessage('Import Group -> ' + r);
        });
        $.post(path + 'Admin/ImportReportConfig', reportLists,(r) => {
            ShowMessage('Import Config=>' + r);
        });
    }
</script>
