@Code
    ViewData("Title") = "UpVersion"
End Code
<h2>Update Version</h2>
<input type="button" id="btnReport" value="Create Report Data" onclick="ImportReportToDb()" />
<input type="button" id="btnLang" value="Create Language Data (Message)" onclick="ReadLangMsgToDb()"/>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function ReadLangMsgToDb() {
        let arr = [];
        let data = GetLangMessage();
        for (const [key, value] of Object.entries(data)) {
            arr.push({ Source : key, Translate : value });
        }
        let lang = { data: arr }
        $.post(path + 'Admin/ImportLangMessage', lang, (r) => {
            ShowMessage('Import Lang Message=>' + r);
        });
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
