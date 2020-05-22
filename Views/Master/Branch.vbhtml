@Code
    ViewBag.Title = "Branch"
End Code
<div class="panel-body">
    <div class="container">
        <div id="dvForm">
            <label id="lblBranchCode">Branch Code :</label>
            <br /><input type="text" id="txtCode" class="form-control" tabIndex="1">
            <label id="lblBranchName">Branch Name :</label>
            <br /><input type="text" id="txtBrName" class="form-control" tabIndex="2">
        </div>
        <br />
        <div id="dvCommand" class="col-sm-12">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
            </a>
            <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteData()">
                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
            </a>
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('branch')">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
        </div>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        SetEvents();
        SetEnterToTab();
        ClearData();
    //});
    function SetEvents() {
        $('#txtCode').keydown(function (event) {
            if (event.which == 13) {
                ShowBranch(path, $('#txtCode').val(),'#txtBrName');
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });
    }
    function SetEnterToTab() {
        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    var idx = (this.tabIndex + 1);
                    var nextElement = $('[tabindex="' + idx + '"]');
                    while (nextElement.length) {
                        if (nextElement.prop('disabled') == false) {
                            $('[tabindex="' + idx + '"]').focus();
                            e.preventDefault();
                            return;
                        } else {
                            idx = idx + 1;
                            nextElement = $('[tabindex="' + idx + '"]');
                        }
                    }
                    $('[tabindex="1"]').focus();
                }
            });
        });
    }
    function ReadData(dr) {
        $('#txtCode').val(dr.Code);
        $('#txtBrName').val(dr.BrName);
        $('[tabindex="1"]').focus();
    }
    function ClearData() {
        $('#txtCode').val('');
        $('#txtBrName').val('');
        $('[tabindex="1"]').focus();
    }
    function DeleteData() {
        var code = $('#txtCode').val();
        ShowConfirm('Do you need to delete this data?', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delbranch?code=' + code, function (r) {
                ShowMessage(r.branch.result);
                ClearData();
            });
        });
    }
    function SaveData() {
        var obj = {

            Code: $('#txtCode').val(),
            BrName: $('#txtBrName').val(),
        };
        if (obj.Code != "") {
            if (obj.BrName == '') {
                ShowMessage('Please enter some data',true);
                return;
            }
            ShowConfirm('Do you need to save this data?', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetBranch", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtCode').val(response.result.data);
                            $('#txtCode').focus();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadData);
                break;
        }
    }
</script>
