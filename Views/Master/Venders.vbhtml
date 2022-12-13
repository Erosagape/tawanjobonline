
@Code
    ViewBag.Title = "Venders"
End Code
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblVenCode">Vender Code:</label>  <a href="#" onclick="$('#modChange').modal('show');">Change</a>
                <br /><input type="text" id="txtVenCode" Class="form-control" tabIndex="0" readonly>
            </div>
            <div class="col-sm-4">
                <label id="lblBranchCode">Branch :</label>
                <br />
                <input type="text" id="txtBranchCode" Class="form-control" tabIndex="1" maxlength="4"/>
            </div>
            <div class="col-sm-4">
                <label id="lblTaxNumber">Tax Number:</label>
                <br /><input type="text" id="txtTaxNumber" Class="form-control" tabIndex="2">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <label id="lblVenTitle">Title:</label>
                <br /><input type="text" id="txtTitle" Class="form-control" tabIndex="3">
            </div>
            <div class="col-sm-4">
                <label id="lblTName">Name:</label>
                <br /><input type="text" id="txtTName" Class="form-control" tabIndex="4">
            </div>
            <div class="col-sm-5">
                <label id="lblEnglish">English:</label>
                <br /><input type="text" id="txtEnglish" Class="form-control" tabIndex="5">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblTAddress1">Address (TH):</label>
                <br /><input type="text" id="txtTAddress1" Class="form-control" tabIndex="6">
                <br /><input type="text" id="txtTAddress2" Class="form-control" tabIndex="7">
            </div>
            <div class="col-sm-6">
                <label id="lblEAddress1">Address (EN):</label>
                <br /><input type="text" id="txtEAddress1" Class="form-control" tabIndex="8">
                <br /><input type="text" id="txtEAddress2" Class="form-control" tabIndex="9">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <label id="lblPhone">Phone:</label>
                <br /><input type="text" id="txtPhone" Class="form-control" tabIndex="10">
            </div>
            <div class="col-sm-3">
                <label id="lblFaxNumber">Fax:</label>
                <br /><input type="text" id="txtFaxNumber" Class="form-control" tabIndex="11">
            </div>
            <div class="col-sm-4">
                <label id="lblWEB_SITE">Web/E-mail:</label>
                <br /><input type="text" id="txtWEB_SITE" Class="form-control" tabIndex="12">
            </div>
            <div class="col-sm-2">
                <label id="lblGLAccountCode">GL Code:</label>                
                <br />
                <div style="display:flex">
                    <input type="text" id="txtGLAccountCode" Class="form-control" tabIndex="13">
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('acccode')" />
                </div>                
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4" style="display:flex;flex-direction:column">
                <b><label id="lblContact">Contact Information:</label></b>
                <br/>      
                <label id="lblContactAcc">Account :</label>
                <input type="text" id="txtContactAcc" Class="form-control" tabIndex="13">
                <label id="lblContactSale">Sales :</label><input type="text" id="txtContactSale" Class="form-control" tabIndex="14">
            </div>
            <div class="col-sm-4" style="display:flex;flex-direction:column">
                <b>Customer Service :</b><br/>
                IMPORT : <input type="text" id="txtContactSupport1" Class="form-control" tabIndex="15">
                EXPORT :<input type="text" id="txtContactSupport2" Class="form-control" tabIndex="16">
                DOMESTIC :<input type="text" id="txtContactSupport3" Class="form-control" tabIndex="17">
            </div>
            <div class="col-sm-4" style="display:flex;flex-direction:column">
                <b>User Login :</b><br />
                User Name :<input type="text" id="txtLoginName" Class="form-control" tabIndex="18">
                Password :<input type="password" id="txtLoginPassword" Class="form-control" tabIndex="19">
            </div>
        </div>
        <div id="dvCommand">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
            </a>
            <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()" style="display:none">
                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
            </a>
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('vender')">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
        </div>
    </div>
</div>
<div id="modChange" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-4">
                        To Code
                    </div>
                    <div class="col-sm-8">
                        <input type="text" id="txtToVenCode" />
                    </div>
                </div>
                <button class="btn btn-warning" onclick="ChangeVender()">Change Vender</button>
                <label id="lblResult">Ready</label>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';

    //$(document).ready(function () {
        SetEvents();
        SetLOVs();
        SetEnterToTab();
        ClearData();
    //});
    function GetDataSave() {
        $('#txtEnglish').val($('#txtEnglish').val().toUpperCase());
        $('#txtTName').val($('#txtTName').val().toUpperCase());
        let dr = {
            VenCode: $('#txtVenCode').val().trim(),
            BranchCode: $('#txtBranchCode').val(),
            TaxNumber: $('#txtTaxNumber').val(),
            Title: $('#txtTitle').val(),
            TName: $('#txtTName').val(),
            English: $('#txtEnglish').val(),
            TAddress1: $('#txtTAddress1').val(),
            TAddress2: $('#txtTAddress2').val(),
            EAddress1: $('#txtEAddress1').val(),
            EAddress2: $('#txtEAddress2').val(),
            Phone: $('#txtPhone').val(),
            FaxNumber: $('#txtFaxNumber').val(),
            LoginName: $('#txtLoginName').val(),
            LoginPassword: $('#txtLoginPassword').val(),
            GLAccountCode: $('#txtGLAccountCode').val(),
            ContactAcc: $('#txtContactAcc').val(),
            ContactSale: $('#txtContactSale').val(),
            ContactSupport1: $('#txtContactSupport1').val(),
            ContactSupport2: $('#txtContactSupport2').val(),
            ContactSupport3: $('#txtContactSupport3').val(),
            WEB_SITE: $('#txtWEB_SITE').val()
        };
        return dr;
    }
    function ClearData() {
        $('#txtVenCode').val('{AUTO}');
        $('#txtBranchCode').val('0000');
        $('#txtTaxNumber').val('');
        $('#txtTitle').val('');
        $('#txtTName').val('');
        $('#txtEnglish').val('');
        $('#txtTAddress1').val('');
        $('#txtTAddress2').val('');
        $('#txtEAddress1').val('');
        $('#txtEAddress2').val('');
        $('#txtPhone').val('');
        $('#txtFaxNumber').val('');
        $('#txtLoginName').val('');
        $('#txtLoginPassword').val('');
        $('#txtGLAccountCode').val('');
        $('#txtContactAcc').val('');
        $('#txtContactSale').val('');
        $('#txtContactSupport1').val('');
        $('#txtContactSupport2').val('');
        $('#txtContactSupport3').val('');
        $('#txtWEB_SITE').val('');

        $('#txtVenCode').focus();
    }
    function DeleteData() {
        var code = $('#txtVenCode').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delvender?code=' + code, function (r) {
                ShowMessage(r.vender.result);
                ClearData();
            });

        });
    }
    function SaveData() {
        var obj = GetDataSave();
        /*
        if (obj.VenCode == '') {
            ShowMessage('Please input code',true);
            return;
        }
        */
        if (obj.TName == '') {
            ShowMessage('Please input name',true);
            return;
        }
        if (obj.English == '') {
            ShowMessage('Please input name', true);
            return;
        }

        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetVender", "Master")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data!=null) {
                        $('#txtVenCode').val(response.result.data);
                        $('#txtVenCode').focus();
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        });
    }
    function ReadAccount(dr) {
        $('#txtGLAccountCode').val(dr.AccCode);
    }
    function ReadVender(dr) {
        if (dr.VenCode != undefined) {

            $('#txtVenCode').val(dr.VenCode);
            $('#txtBranchCode').val(dr.BranchCode);
            $('#txtTaxNumber').val(dr.TaxNumber);
            $('#txtTitle').val(dr.Title);
            $('#txtTName').val(dr.TName);
            $('#txtEnglish').val(dr.English);
            $('#txtTAddress1').val(dr.TAddress1);
            $('#txtTAddress2').val(dr.TAddress2);
            $('#txtEAddress1').val(dr.EAddress1);
            $('#txtEAddress2').val(dr.EAddress2);
            $('#txtPhone').val(dr.Phone);
            $('#txtFaxNumber').val(dr.FaxNumber);
            $('#txtLoginName').val(dr.LoginName);
            $('#txtLoginPassword').val(dr.LoginPassword);
            $('#txtGLAccountCode').val(dr.GLAccountCode);
            $('#txtContactAcc').val(dr.ContactAcc);
            $('#txtContactSale').val(dr.ContactSale);
            $('#txtContactSupport1').val(dr.ContactSupport1);
            $('#txtContactSupport2').val(dr.ContactSupport2);
            $('#txtContactSupport3').val(dr.ContactSupport3);
            $('#txtWEB_SITE').val(dr.WEB_SITE);

            $('#btnSave').removeAttr('disabled');
            if (dr.VenCode != "") {
                $('#btnDel').removeAttr('disabled');
            } else {
                $('#btnDel').attr('disabled', 'disabled');
            }
        } else {
            ShowMessage('Data not found',true);
            ClearData();
        }
        //$('#txtVenCode').focus();
    }
    function SearchData(type) {
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'acccode':
                SetGridAccountCode(path, '#tbAcc', '#frmSearchAcc', '',ReadAccount);
                break;
        }
    }
    function SetEvents() {
        $('#txtVenCode').keydown(function (event) {
            if (event.which == 13) {
                let code = $('#txtVenCode').val();
                ClearData();
                $('#txtVenCode').val(code);
                CallBackQueryVender(path, code, ReadVender);
            }
        });
    }
    function SetLOVs() {
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            CreateLOV(dv, '#frmSearchAcc', '#tbAcc', 'Account Codes', response, 2);
        });
    }
    function SetEnterToTab() {

        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    let idx = (this.tabIndex + 1);
                    let nextElement = $('[tabindex="' + idx + '"]');
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
                    $('[tabindex="0"]').focus();
                }
            });
        });
    }
    function ChangeVender() {
        let fromcode = $('#txtVenCode').val();
        let tocode = $('#txtToVenCode').val();
        ShowConfirm(
            "Please confirm to change code from '" + fromcode +  "' to '" + tocode + "'",
            function (ans) {
                if (ans == true) {
                    $.get(path + 'Master/ChangeVender?FromCode=' + fromcode + '&ToCode=' + tocode).done(function (r) {
                        ShowMessage(r);
                        $('#lblResult').text(r);
                    });
                }
            });
    }
</script>
