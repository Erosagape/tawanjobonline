﻿@Code
    ViewBag.Title = "Country"
End Code
<div class="panel-body">
    <div id="dvForm">
        <div class="row">
            <div class="col-sm-3">
                <label id="lblCTYCODE">Country Code :</label><br/>
                <input type="text" id="txtCTYCODE" class="form-control" tabIndex="1">
            </div>
            <div class="col-sm-9">
                <label id="lblCTYName">Country Name :</label><br /><input type="text" id="txtCTYName" class="form-control" tabIndex="2">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-8">
                <label id="lblCURCODE">Currency Code:</label>
                <br />
                <div style="display:flex">
                    <div style="flex:20%">
                        <input type="text" id="txtCURCODE" class="form-control" tabIndex="3">
                    </div>
                    <div>
                        <input type="button" value="..." class="btn btn-default" onclick="SearchData('currency')" />
                    </div>
                    <div style="flex:60%">
                        <input type="text" id="txtCURNAME" class="form-control" disabled>
                    </div>
                </div>
            </div>
            <div class="col-sm-2">
                <label id="lblFTCODE">FT CODE :</label><br /><input type="number" id="txtFTCODE" class="form-control" tabIndex="4" value="0">
            </div>
            <div class="col-sm-2">
                <label id="lblCUCODE">CU CODE :</label><br /><input type="number" id="txtCUCODE" class="form-control" tabIndex="5" value="0">
            </div>
        </div>
    </div>
    <div id="dvCommand">
        <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
        </a>
        <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
            <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
        </a>
        <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteData()">
            <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
        </a>
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('country')">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
        </a>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        SetEvents();
        SetEnterToTab();
        ClearData();
    //});
    function SetEvents() {
        $('#txtCTYCODE').keydown(function (event) {
            if (event.which == 13) {
                var code = $('#txtCTYCODE').val();
                ClearData();
                CallBackQueryCountry(path, code, ReadData);
            }
        });
        $('#txtCURCODE').keydown(function (event) {
            if (event.which == 13) {
                var code = $('#txtCURCODE').val();
                $('#txtCURCODE').val('');
                $('#txtCURNAME').val('');
                CallBackQueryCurrency(path, code, ReadCurrency);
                $('#txtCURCODE').focus();
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
            CreateLOV(dv, '#frmSearchCountry', '#tbCountry', 'Country', response, 2);
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
    function ReadCurrency(dr) {
        $('#txtCURCODE').val(dr.Code);
        $('#txtCURNAME').val(dr.TName);
        $('#txtCURCODE').focus();
    }
    function ReadData(dr) {
        $('#txtCTYCODE').val(dr.CTYCODE);
        $('#txtCTYName').val(dr.CTYName);
        $('#txtCURCODE').val('');
        $('#txtCURNAME').val('');
        CallBackQueryCurrency(path, dr.CURCODE, ReadCurrency);
        $('#txtFTCODE').val(dr.FTCODE);
        $('#txtCUCODE').val(dr.CUCODE);

        $('[tabindex="1"]').focus();
    }
    function ClearData() {
        $('#txtCTYCODE').val('');
        $('#txtCTYName').val('');
        $('#txtCURCODE').val('');
        $('#txtCURNAME').val('');
        $('#txtFTCODE').val('0');
        $('#txtCUCODE').val('0');
        $('[tabindex="1"]').focus();
    }
    function DeleteData() {
        var code = $('#txtCTYCODE').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delcountry?code=' + code, function (r) {
                ShowMessage(r.country.result);
                ClearData();
            });
        });
    }
    function SaveData() {
        var obj = {
            CTYCODE: $('#txtCTYCODE').val(),
            CTYName: $('#txtCTYName').val(),
            CURCODE: $('#txtCURCODE').val(),
            FTCODE: $('#txtFTCODE').val(),
            CUCODE: $('#txtCUCODE').val()
        };
        if (obj.CTYCODE != "") {
            if (obj.CTYName == '') {
                ShowMessage('Please enter some data',true);
                return;
            }
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetCountry", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtCTYCODE').val(response.result.data);
                            $('#txtCTYCODE').focus();
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
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
            case 'country':
                SetGridCountry(path, '#tbCountry', '#frmSearchCountry', ReadData);
                break;
        }
    }
</script>
