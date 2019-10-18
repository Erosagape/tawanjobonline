@Code
    ViewBag.Title = "Master Files"
End Code
<div class="panel-body">
    <div class="container">
        <a href="#" class="btn btn-success" id="btnUpdate" onclick="TestFunction()">
            <i class="fa fa-lg fa-save"></i>&nbsp;<b><label id="lblSaveQuo">Test Log</label></b>
        </a>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function TestFunction() {
        $.post(path + 'Config/SetLog', { LogID: 0, CustID: 'TAWAN', AppID: 'JOBSHIPPING', ModuleName: 'TEST', LogAction: 'Test', Message: 'ทดสอบ' }).done(function (r) {
            ShowMessage(r.result.msg);
        });
    }
</script>
