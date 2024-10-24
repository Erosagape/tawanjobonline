﻿@Code
    ViewBag.Title = "User Authorized"
End Code
<div class="panel-body">
    <div class="container">
        <div id="dvForm">
            <div class="row"> 
                <label id="lblAppID">Module :</label>
                <br /><select id="txtAppID" class="form-control dropdown" tabIndex="0" onchange="LoadGrid()"></select>
            </div>
            <div class="row">
                <table id="tbMenu" class="table table-responsive"></table>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblFunction">Function :</label>
                    <br/><input type="text" id="txtMenuID" class="form-control" disabled>
                </div>                
                <div class="col-sm-8">
                    <br/>
                    <input type="text" id="txtMenuName" class="form-control" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div style="display:flex">
                        <div>
                            <label id="lblSetBy">Set By :</label>                            
                            <br/>
                            <select id="cboUserType" class="form-control dropdown">
                                <option value="U" selected>User ID</option>
                                <option value="C">Customer ID</option>
                                <option value="V">Vender ID</option>
                            </select>

                        </div>
                        <div style="flex:1">
                            <br/>
                            <input type="text" id="txtUserID" class="form-control" tabIndex="1" />
                        </div>
                        <div>
                            <br/>
                            <input type="button" value="..." class="btn btn-default" onclick="SearchData('user')" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-8">
                    <br /><input type="text" id="txtUserName" class="form-control" disabled>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <input type="checkbox" id="chkManage" onchange="SetAuth()" />
                    <label id="lblManage" for="chkManage">Allow Manage</label>
                    <input type="checkbox" id="chkInsert" onchange="SetAuth()" />
                    <label id="lblInsert" for="chkInsert">Allow Add</label>
                    <input type="checkbox" id="chkRead" onchange="SetAuth()" />
                    <label id="lblRead" for="chkRead">Allow Search</label>
                    <input type="checkbox" id="chkEdit" onchange="SetAuth()" />
                    <label id="lblEdit" for="chkEdit">Can Edit</label>
                    <input type="checkbox" id="chkDelete" onchange="SetAuth()" />
                    <label id="lblDelete" for="chkDelete">Can Delete</label>
                    <input type="checkbox" id="chkPrint" onchange="SetAuth()" />
                    <label id="lblPrint" for="chkPrint">Can Print</label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    Summary : <input type="text" id="txtAuthor" class="form-control">
                </div>
                <div class="col-sm-8">
                    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                    </a>
                    <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
                        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        SetEvents();
    //});
    function LoadGrid() {
        var code = 'MODULE_'+ $('#txtAppID').val();
        var tb=$('#tbMenu').DataTable({
            ajax: {
                url: path + 'Config/GetConfig?Code='+code, //web service ที่จะ call ไปดึงข้อมูลมา
                dataSrc: 'config.data'
            },
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "ConfigKey", title: "รหัส" },
                { data: "ConfigValue", title: "คำอธิบาย" }
            ],
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            ,pageLength:100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbMenu');
        $('#tbMenu tbody').on('click', 'tr', function () {
            $('#tbMenu tbody > tr').removeClass('selected'); //ล้างทุก row ที่มีการ select ก่อน
            $(this).addClass('selected'); //select row ใหม่
            var dr = $('#tbMenu').DataTable().row(this).data();
            $('#txtMenuID').val(dr.ConfigKey);
            $('#txtMenuName').val(dr.ConfigValue);
            if ($('#txtUserID').val() !== "") {
                ShowData();
            }
        });
        ClearData();
    }
    function SetAuth() {
        var str = '';
        str += $('#chkManage').prop('checked') == true ? 'M' : '';
        str += $('#chkInsert').prop('checked') == true ? 'I' : '';
        str += $('#chkRead').prop('checked') == true ? 'R' : '';
        str += $('#chkEdit').prop('checked') == true ? 'E' : '';
        str += $('#chkDelete').prop('checked') == true ? 'D' : '';
        str += $('#chkPrint').prop('checked') == true ? 'P' : '';
        $('#txtAuthor').val(str);
    }
    function SetEvents() {
        loadConfig('#txtAppID', 'MODULE', path, '');   
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchUser', '#tbUser', 'Search User', response, 2);
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Search Customer', response, 2);
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Search Vender', response, 2);
        });     
        $('#txtUserID').keydown(function (event) {
            if (event.which == 13) {
                $('#txtUserName').val('');
                if ($('#cboUserType').val() == 'U') {
                    CallBackQueryUser(path, $('#txtUserID').val(), ReadUser);
                }
                if ($('#cboUserType').val() == 'C') {
                    CallBackQueryCustomerSingle(path, $('#txtUserID').val(), ReadCustomer);
                }
                if ($('#cboUserType').val() == 'V') {
                    CallBackQueryVender(path, $('#txtUserID').val(), ReadVender);
                }
            }
        });
    }
    function ReadUser(dr) {
        $('#txtUserID').val(dr.UserID);
        $('#txtUserName').val(dr.TName);
        ShowData();
    }
    function ReadCompany(dr) {
        $('#txtUserID').val(dr.LoginName);
        $('#txtUserName').val(dr.NameThai);
        ShowData();
    }
    function ReadVender(dr) {
        $('#txtUserID').val(dr.LoginName);
        $('#txtUserName').val(dr.TName);
        ShowData();
    }
    function SearchData(type) {
        switch (type) {
            case 'user':
                if ($('#cboUserType').val() == 'U') {
                    SetGridUser(path, '#tbUser', '#frmSearchUser', ReadUser);
                }
                if ($('#cboUserType').val() == 'C') {
                    SetGridCompanyLogin(path, '#tbCust', '#frmSearchCust', ReadCompany);
                }
                if ($('#cboUserType').val() == 'V') {
                    SetGridVenderLogin(path, '#tbVend', '#frmSearchVend', ReadVender);
                }
                break;
        }
    }
    function DeleteData() {
        var code = $('#txtUserID').val();
        var key ="MODULE_"+ $('#txtAppID').val();
        var menu = $('#txtMenuID').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/deluserauth?code=' + code + '&app='+key+'&menu='+menu, function (r) {
                ShowMessage(r.userauth.result);
                ClearData();
            });
        });
    }
    function ReadData(dr) {
        var data = (dr.Author ==null? '':dr.Author);        
        $('#txtAuthor').val(data);
        $('#chkManage').prop('checked', data.indexOf('M') >= 0 ? true : false);
        $('#chkInsert').prop('checked', data.indexOf('I') >= 0 ? true : false);
        $('#chkRead').prop('checked', data.indexOf('R') >= 0 ? true : false);
        $('#chkEdit').prop('checked', data.indexOf('E') >= 0 ? true : false);
        $('#chkDelete').prop('checked', data.indexOf('D') >= 0 ? true : false);
        $('#chkPrint').prop('checked', data.indexOf('P') >= 0 ? true : false);
    }
    function ShowData() {
        var code = $('#txtUserID').val();
        var app = "MODULE_" +$('#txtAppID').val();
        var menu = $('#txtMenuID').val();
        ClearData();
        CallBackQueryUserAuth(path, code, app, menu, ReadData);
    }
    function SaveData() {
        SetAuth();
        var obj = {
            UserID:$('#txtUserID').val(),
            AppID: $('#txtAppID').val(),
            MenuID:$('#txtMenuID').val(),
            Author:$('#txtAuthor').val()
        };
        if (obj.UserID !== "") {
            if (obj.AppID === "") {
                ShowMessage('Please select application',true);
                return;
            }
            obj.AppID = "MODULE_" + $('#txtAppID').val();
            if (obj.MenuID === "") {
                ShowMessage('Please select menu',true);
                return;
            }
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                $.ajax({
                    url: "@Url.Action("SetUserAuth", "Config")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
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
    function ClearData(){
        $('#txtAuthor').val('*MIREDP');
        $('#chkManage').prop('checked', true);
        $('#chkInsert').prop('checked', true);
        $('#chkRead').prop('checked', true);
        $('#chkEdit').prop('checked', true);
        $('#chkDelete').prop('checked', true);
        $('#chkPrint').prop('checked', true);
    }
</script>
