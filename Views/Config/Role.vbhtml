﻿
@Code
    ViewBag.Title = "User Policy"
End Code
<div class="panel-body">
    <div class="container">
        <div style="display:flex;flex-direction:column;">
            <div style="flex:1">
                <div class="row">
                    <div class="col-sm-2"><label id="lblRoleID">Role ID :</label><br /><input type="text" id="txtRoleID" class="form-control"></div>
                    <div class="col-sm-6"><label id="lblRoleDesc">Role Description :</label><br /><input type="text" id="txtRoleDesc" class="form-control"></div>
                    <div class="col-sm-4"><label id="lblRoleGroup">Role Group :</label><br /><select id="txtRoleGroup" class="form-control dropdown"></select></div>
                </div>
                <div id="dvCommand">
                    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearHeader()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveHeader()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                    </a>
                    <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteHeader()">
                        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
                    </a>
                </div>
            </div>
            <div style="flex:1">
                <div id="dvHeader" class="row">
                    <div id="gridRole" class="col-sm-6">
                        <table id="tbHeader" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>roleID</th>
                                    <th>roleName</th>
                                    <th>roleGroup</th>
                                </tr>
                            </thead>
                            <tbody />
                        </table>
                    </div>
                    <div id="dvDetail" class="col-sm-6" style="display:flex;flex-direction:column;">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tabPolicy">Policy</a></li>
                            <li><a data-toggle="tab" href="#tabUser">Users</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane fade" id="tabUser">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblUser">UserID :</label>
                                        <br />
                                        <div style="display:flex">
                                            <input type="text" id="txtUserID" class="form-control" style="width:40%" tabIndex="1" />
                                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('user')" />
                                            <input type="text" id="txtUserName" class="form-control" style="width:100%" disabled>
                                        </div>
                                    </div>
                                </div>
                                <a href="#" class="btn btn-success" id="btnSaveUser" style="width:100%" onclick="SaveUser()">
                                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkAddUser">Apply Role</b>
                                </a>

                                <label id="lblUserRole">User in this role:</label>
                                <table id="tbDetail" class="table table-responsive">
                                    <thead>
                                        <tr>
                                            <th>userID</th>
                                            <th>userName</th>
                                        </tr>
                                    </thead>
                                    <tbody />
                                </table>
                                <a href="#" class="btn btn-danger" id="btnDeleteUser" onclick="DeleteUser()">
                                    <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDeleteUser">Remove User</b>
                                </a>
                                <a href="#" class="btn btn-primary" id="btnCopyUser" onclick="CopyUser()">
                                    <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkCopyUser">Copy Authorize From User</b>
                                </a>
                                <input type="text" id="txtUserFrom" />
                            </div>
                            <div class="tab-pane fade in active" id="tabPolicy">
                                <label id="lblFunction">Module:</label>                                            
                                <input type="checkbox" id="chkAll" onclick="CheckAll()" /> Allow All
                                <div style="display:flex;flex-direction:column">
                                    <div style="display:flex;">
                                        <input type="hidden" id="txtModuleID" class="form-control" />
                                        <input type="text" style="flex:1" id="txtModuleName" class="form-control" disabled />
                                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('module')" />
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <input type="checkbox" id="chkManage" />
                                            <label for="chkManage">Use</label>
                                            <input type="checkbox" id="chkInsert" />
                                            <label for="chkInsert">Add</label>
                                            <input type="checkbox" id="chkRead" />
                                            <label for="chkRead">Search</label>
                                            <input type="checkbox" id="chkEdit" />
                                            <label for="chkEdit">Edit</label>
                                            <input type="checkbox" id="chkDelete" />
                                            <label for="chkDelete">Delete</label>
                                            <input type="checkbox" id="chkPrint" />
                                            <label for="chkPrint">Print</label>
                                        </div>
                                    </div>
                                    <a href="#" class="btn btn-success" id="btnSavePolicy" onclick="SavePolicy()">
                                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkAddRole">Apply Policy</b>
                                    </a>
                                    <table id="tbPolicy" class="table table-responsive">
                                        <thead>
                                            <tr>
                                                <th>ModuleID</th>
                                                <th>ModuleName</th>
                                                <th>Author</th>
                                            </tr>
                                        </thead>
                                        <tbody />
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        loadConfig('#txtRoleGroup', 'CLR_FROM', path, '');
        SetEvents();
        LoadGrid();
    //});
    function SetEvents() {
        $('#txtRoleID').keydown(function (event) {
            if (event.which == 13) {
                $('#txtRoleDesc').val('');
                $('#txtRoleGroup').val('');
                CallBackQueryUserRole(path, $('#txtRoleID').val(), ReadRole);
                LoadUser($('#txtRoleID').val());
                LoadPolicy($('#txtRoleID').val());
            }
        });
        $('#txtUserID').keydown(function (event) {
            if (event.which == 13) {
                $('#txtUserName').val('');
                CallBackQueryUser(path, $('#txtUserID').val(), ReadUser);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchUser', '#tbUser', 'Search User', response, 2);
            CreateLOV(dv, '#frmSearchModule', '#tbModule', 'Search Module', response, 3);
        });   
    }
    function SearchData(type) {
        switch (type) {
            case 'user':
                SetGridUser(path, '#tbUser', '#frmSearchUser', ReadUser);
                break;
            case 'module':
                SetGridConfigVal(path, '#tbModule', 'MODULE_%','#frmSearchModule', ReadModule);
                break;
        }
    }
    function LoadGrid() {
        $.get(path + 'Config/GetUserRole', function (response) {
            if (response.userrole!==null) {
                LoadRole(response.userrole);
            }
        });
    }
    function LoadUser(user) {
        $.get(path + 'Config/GetUserRoleDetail?Code=' +user, function (response) {
            if (response.userrole.detail !== null) {
                let table = $('#tbDetail').dataTable({
                    data: response.userrole.detail,
                    columns: [
                        { data: "UserID", title: "User Id" },
                        { data: "UserName", title: "User Name"}
                    ],
                    destroy: true,
                    pageLength:100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
                $('#tbDetail tbody').on('click', 'tr', function () {
                    $('#tbDetail tbody > tr').removeClass('selected');
                    $(this).addClass('selected');

                    var data = $('#tbDetail').DataTable().row(this).data();
                    $('#txtUserID').val(data.UserID);
                    $('#txtUserName').val(data.UserName);                    
                });
                
            }
        });
    }
    function LoadPolicy(role) {
        $.get(path + 'Config/GetUserRolePolicy?Code=' + role, function (response) {
            if (response.userrole.policy !== null) {
                let table = $('#tbPolicy').dataTable({
                    data: response.userrole.policy,
                    columns: [
                        { data: "ModuleID", title: "Module Id" },
                        { data: "ModuleName", title: "Module Name" },
                        { data: "Author", title: "Authorize" }
                    ],
                    destroy: true,pageLength:100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbPolicy');
                $('#tbPolicy tbody').on('click', 'tr', function () {
                    $('#tbPolicy tbody > tr').removeClass('selected');
                    $(this).addClass('selected');
                    
                    var data = $('#tbPolicy').DataTable().row(this).data();

                    $('#txtModuleID').val(data.ModuleID);
                    $('#txtModuleName').val(data.ModuleName);
                    $('#chkManage').prop('checked', data.Author.indexOf('M') >= 0 ? true : false);
                    $('#chkInsert').prop('checked', data.Author.indexOf('I') >= 0 ? true : false);
                    $('#chkEdit').prop('checked', data.Author.indexOf('E') >= 0 ? true : false);
                    $('#chkDelete').prop('checked', data.Author.indexOf('D') >= 0 ? true : false);
                    $('#chkRead').prop('checked', data.Author.indexOf('R') >= 0 ? true : false);
                    $('#chkPrint').prop('checked', data.Author.indexOf('P') >= 0 ? true : false);
                });
            }
        });
    }
    function LoadRole(dt) {
        let header = dt.data;
        let table= $('#tbHeader').dataTable({
            data: header,
            columns: [
                { data: "RoleID", title: "Id" },
                { data: "RoleDesc", title: "Role Description" },
                { data: "RoleGroup", title: "Group" }
            ],
            destroy:true,pageLength:100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
        $('#tbHeader tbody').on('click', 'tr', function() {
            $('#tbHeader tbody > tr').removeClass('selected');
            $(this).addClass('selected');

            var data = $('#tbHeader').DataTable().row(this).data();
            $('#txtRoleID').val(data.RoleID);
            $('#txtRoleDesc').val(data.RoleDesc);
            $('#txtRoleGroup').val(data.RoleGroup);

            //ClearUser();
            ClearPolicy();

            LoadUser(data.RoleID);
            LoadPolicy(data.RoleID);
        });
        LoadUser($('#txtRoleID').val());
        LoadPolicy($('#txtRoleID').val());
    }
    function DeleteHeader() {
        var code = $('#txtRoleID').val();
        if (code !== '') {
            ShowConfirm('Please confirm to delete', function (ask) {
                if (ask == false) return;
                $.get(path + 'config/deluserrole?code=' + code, function (r) {
                    ShowMessage(r.userrole.result);
                    ClearHeader();
                    LoadGrid();
                });
            });
        }
    }
    function DeleteUser() {
        var code = $('#txtRoleID').val();
        var id = $('#txtUserID').val();
        if (id !== '') {
            ShowConfirm('Please confirm to delete', function (ask) {
                if (ask == false) return;
                $.get(path + 'config/deluserroledetail?code=' + code + '&id=' + id, function (r) {
                    ShowMessage(r.userrole.result);
                    LoadUser($('#txtRoleID').val());
                });
            });
        }
    }
    function SaveUser() {
        var obj={			
            RoleID: $('#txtRoleID').val(),
            UserID: $('#txtUserID').val()
	    };
        if (obj.RoleID != "" && obj.UserID != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                var result =$.ajax({
                    url: "@Url.Action("SetUserRoleDetail", "Config")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText
                });
                result.done(function (response) {
                    if (response.result.data != null) {
                        LoadUser($('#txtRoleID').val());
                        $('#txtUserID').focus();
                    }
                    ShowMessage(response.result.msg);
                });
                result.fail(function (err) {
                    ShowMessage(err,true);
                });
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
	function SaveHeader(){
		var obj={
			
            RoleID:$('#txtRoleID').val(),
            RoleDesc: $('#txtRoleDesc').val(),
            RoleGroup: $('#txtRoleGroup').val()
	    };
        if (obj.RoleID != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetUserRole", "Config")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    async:false,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtRoleID').val(response.result.data);
                            $('#txtRoleID').focus();
                            LoadGrid();
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
    function CopyUser() {
        let userFrom = $('#txtUserFrom').val();
        let msg = "Do you need to copy rights from " + userFrom + " to " + $('#txtUserID').val();
        if (mainLanguage == "TH") {
            msg="กรุณายืนยันการคัดลอกสิทธิ์ของ " + userFrom + " ให้กับ " + $('#txtUserID').val()
        }
        ShowConfirm(msg, (ask) => {
            if (ask == false) return;
            $.get(path + 'Config/CopyMenuAuth?From=' + userFrom + '&To=' + $('#txtUserID').val()).done(function (r) {
                ShowMessage(r);
            });
        });
    }
    function SavePolicy() {
        var obj={			
            RoleID: $('#txtRoleID').val(),
            ModuleID: $('#txtModuleID').val(),
            Author: GetAuthor()
	    };
        if (obj.RoleID != "" && obj.ModuleID != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                var result = $.ajax({
                    url: "@Url.Action("SetUserRolePolicy", "Config")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText
                });
                result.done(function (response) {
                    if (response.result.data != null) {
                        LoadPolicy($('#txtRoleID').val());
                    }
                    ShowMessage(response.result.msg);
                });
                result.fail(function (err) {
                    ShowMessage(err,true);
                });
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    function GetAuthor() {
        let str = '';
        str += $('#chkManage').prop('checked') == true ? 'M' : '';
        str += $('#chkInsert').prop('checked') == true ? 'I' : '';
        str += $('#chkRead').prop('checked') == true ? 'R' : '';
        str += $('#chkEdit').prop('checked') == true ? 'E' : '';
        str += $('#chkDelete').prop('checked') == true ? 'D' : '';
        str += $('#chkPrint').prop('checked') == true ? 'P' : '';
        return str;
    }
	function ClearHeader(){		
        $('#txtRoleID').val('');
        $('#txtRoleDesc').val('');
        $('#txtRoleGroup').val('');
        //ClearUser();
        ClearPolicy();
    }
    function ClearUser() {
        $('#txtUserID').val('');
        $('#txtUserName').val('');
    }
    function ClearPolicy() {
        $('#txtModuleID').val('');
        $('#txtModuleName').val('');
        $('#chkManage').prop('checked', false);
        $('#chkInsert').prop('checked', false);
        $('#chkEdit').prop('checked', false);
        $('#chkDelete').prop('checked', false);
        $('#chkRead').prop('checked', false);
        $('#chkPrint').prop('checked', false);
    }
    function ReadRole(dr) {
        $('#txtRoleDesc').val(dr.data[0].RoleDesc);
        $('#txtRoleGroup').val(dr.data[0].RoleGroup);
    }
    function ReadUser(dr) {
        $('#txtUserID').val(dr.UserID);
        $('#txtUserName').val(dr.TName);
    }
    function ReadModule(dr) {
        $('#txtModuleID').val(dr.ConfigCode +'/'+dr.ConfigKey);
        $('#txtModuleName').val(dr.ConfigValue);
    }
    function CheckAll() {
        if ($('#chkAll').prop('checked')) {
            $('#chkManage').prop('checked', true);
            $('#chkInsert').prop('checked', true);
            $('#chkEdit').prop('checked', true);
            $('#chkDelete').prop('checked', true);
            $('#chkRead').prop('checked', true);
            $('#chkPrint').prop('checked', true);
        } else {
            $('#chkManage').prop('checked', false);
            $('#chkInsert').prop('checked', false);
            $('#chkEdit').prop('checked', false);
            $('#chkDelete').prop('checked', false);
            $('#chkRead').prop('checked', false);
            $('#chkPrint').prop('checked', false);
        }
    }
</script>