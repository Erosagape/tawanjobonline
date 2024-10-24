﻿@Code
    ViewBag.Title = "System Variables"
End Code
<div class="panel-body">
    <div id="divInputs">
        <table id="frmConfig">
            <tr>
                <td>
                    <label id="lblCode">Config Code :</label>                    
                </td>
                <td>
                    <input type="text" class="form-control" id="txtCode" />
                </td>
            </tr>
            <tr>
                <td>
                    <label id="lblKey">Config Key :</label>                    
                </td>
                <td>
                    <input type="text" class="form-control" id="txtKey" />
                </td>
            </tr>
            <tr>
                <td>
                    <label id="lblValue">Config Value :</label>                    
                </td>
                <td>
                    <textarea class="form-control" id="txtValue"></textarea>
                </td>
            </tr>
        </table>
        <div id="dvCommand">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
            </a>
            <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
            </a>
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData()">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
        </div>
    </div>
    <div id="dvLOVs"></div>
    <hr />
    <div id="divGrid">
        <table id="tblData" class="table table-responsive">
            <thead>
                <tr>
                    <th>Code</th>
                    <th>Key</th>
                    <th>Value</th>
                </tr>
            </thead>
            <tbody />
        </table>
    </div>
</div>
<div id="dvMsg"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    //define variables
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        SetLOV();
        SetEvents();
        ShowData("", "");
        $("#txtCode").focus();
    //});
    function SetLOV() {
        //single field show in grid
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code', function (response) {
            var dv = document.getElementById("dvLOVs");
            //Unit
            CreateLOV(dv,'#frmSearch', '#tbLOV', 'Setting',response,1);
        });
    }
    function SetEvents() {
        //listening events
        $("#txtCode").keydown(function (event) {
            if (event.which == 13) {
                ShowData($('#txtCode').val(), "");
                $("#txtKey").focus();
            }
        });
        $("#txtKey").keydown(function (event) {
            if (event.which == 13) {
                GetData();
                $("#txtValue").focus();
            }
        });
    }
    function SearchData() {
        //popup for search data
        SetGridConfigList(path, '#tbLOV', '#frmSearch', LoadData);
    }
    function ClearData() {
        //clear input form and set default values
        $('#txtCode').val('');
        $('#txtKey').val('');
        $('#txtValue').val('');
        $("#txtCode").focus();
    }
    function GetData() {
        ShowConfigValue(path, $('#txtCode').val(), $('#txtKey').val(), '#txtValue');
    }
    function GetInput() {
        //read input data and generated class for post
        var obj = {
            ConfigCode: $('#txtCode').val().trim(),
            ConfigKey: $('#txtKey').val().trim(),
            ConfigValue: $('#txtValue').val().trim()
        };
        return obj;
    }
    function SaveData() {
        //post data input to web API
        var obj = GetInput();
        if (obj.ConfigCode == '') {
            ShowMessage('Please enter config code',true);
            return;
        }
        if (obj.ConfigKey == '') {
            ShowMessage('Please enter config key',true);
            return;
        }
        if (obj.ConfigValue == '') {
            ShowMessage('Please enter config value',true);
            return;
        }
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            $.ajax({
                url: "@Url.Action("SetConfig", "Config")",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ data: obj }),
                success: function (response) {
                    response ? ShowMessage("Save Complete") : ShowMessage("Cannot Save data",true);
                    ShowData($('#txtCode').val(), "");
                    $("#txtCode").focus();
                }
            });
        });
    }
    function GetParam(Code, Key) {
        //create query string from user input
        var strParam = "";
        if (Code != "") {
            strParam += "Code=" + Code;
        }
        if (Key != "") {
            if (strParam != "") strParam += "&";
            strParam += "Key=" + Key;
        }
        if (strParam != "") strParam = "?" + strParam;
        return strParam;
    }   
    function LoadData(dt) {
        ShowData(dt.ConfigCode, "");
        $('#txtKey').val('');
        $('#txtValue').val('');
        $("#txtCode").focus();
    }
    function DeleteData() {
        var code = $('#txtCode').val();
        var key = $('#txtKey').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'config/delconfig' + GetParam(code,key), function (r) {
                ShowMessage(r.config.result);
                ShowData($('#txtCode').val(), "");
            });
        });
    }
    function ShowData(Code, Key) {
    //function for show grid data
        $('#txtCode').val(Code);
        let tb=$('#tblData').DataTable({
            ajax: {
                url: path + "Config/getConfig" + GetParam(Code, Key),
                dataSrc: "config.data"
            },
            destroy: true,
            columns: [
                { data: "ConfigCode" },
                { data: "ConfigKey" },
                { data: "ConfigValue" },
            ]
            ,pageLength: 100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tblData');
        //on click load current row select to form
        $('#tblData tbody').on('click', 'tr', function () {
            $('#tblData tbody > tr').removeClass('selected');
            $(this).addClass('selected');

            var data = $('#tblData').DataTable().row(this).data();
            $('#txtCode').val(data.ConfigCode);
            $('#txtKey').val(data.ConfigKey);
            $('#txtValue').val(data.ConfigValue);

            $("#txtCode").focus();
        });
    }
</script>
