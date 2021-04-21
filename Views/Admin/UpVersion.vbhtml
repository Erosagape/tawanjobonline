@Code
    ViewData("Title") = "UpVersion"
End Code
<h2>Update Version</h2>
<input type="button" id="btnReport" value="Create Report Data" onclick="ImportReportToDb()" />
<input type="button" id="btnLang" value="Create Language Data" onclick="ReadLangToDb()"/>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function ReadLangToDb() {

    }
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
