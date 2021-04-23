@Code
    ViewData("Title") = "UpVersion"
End Code
<h2>Update Version</h2>
<input type="button" id="btnReport" value="Create Report Data" onclick="ImportReportToDb()" />
<input type="button" id="btnLang1" value="Create Language Data (Message)" onclick="ReadLangMsgToDb()"/>
<input type="button" id="btnLang2" value="Create Language Data (Menu)" onclick="ReadLangMenuToDb()" />
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function ReadLangMenuToDb() {
        let arr = [];
        let data = GetLangMenu();
        for (const [key, value] of Object.entries(data)) {
            arr.push({ Source: key, Translate: value });
        }
        let lang = { data: arr }
        $.post(path + 'Admin/ImportLangMenu', lang, (r) => {
            alert('Import Lang Menu=>' + r);
        });
    }
    function ReadLangMsgToDb() {
        let arr = [];
        let data = GetLangMessage();
        for (const [key, value] of Object.entries(data)) {
            arr.push({ Source : key, Translate : value });
        }
        let lang = { data: arr }
        $.post(path + 'Admin/ImportLangMessage', lang, (r) => {
            alert('Import Lang Message=>' + r);
        });
    }
    function ImportReportToDb() {
        let reportLists = { data: GetReportLists_V2() }
        let reportGroups = { data: GetReportGroups() }
        $.post(path + 'Admin/ImportReportGroup', reportGroups,(r) => {
            alert('Import Group -> ' + r);
        });
        $.post(path + 'Admin/ImportReportConfig', reportLists,(r) => {
            alert('Import Config=>' + r);
        });
    }
</script>
