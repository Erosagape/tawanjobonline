﻿@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "Index"
End Code
<style>
    #imgHeader {
        height: auto;
        width: 100%;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }
</style>
<div class="row">
    <div class="col-xs-4">
            <div class="modal-header">
                <img id="imgHeader" src="~/Resource/logo_bop.jpeg" />
            </div>
            <div class="modal-body">
                <div style="display:flex;flex-direction:row;float:left;">
                    <input type="radio" name="optRole" id="optShip" value="S" checked /><label for="optShip" style="padding-right:10px">BOP</label>
                    <input type="radio" name="optRole" id="optImEx" value="C" /><label for="optImEx" style="padding-right:10px">Customer</label>
                </div>
		<select class="form-control dropdown" id="cboDatabase"></select>
                <a id="linkLogout" onclick="ForceLogout()">User ID :</a> <input type="text" class="form-control" id="txtUserLogin" />
                Password : <input type="password" autocomplete="on" class="form-control" id="txtUserPassword" />
            </div>
            <div class="modal-footer">
                <button class="btn btn-primary" id="btnLogin" onclick="SetVariable()">Log in</button>
                <button class="btn btn-warning" id="btnTracking" onclick="OpenTracking()">Tracking Your Shipment</button>
            </div>
        </form>
    </div>
    <div class="col-xs-8">
        <img src="~/Resource/bop_bg.png" style="width:90%;" />
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';    
    $('#txtUserLogin').keydown(function (event) {
        if (event.which === 13) {
            $('#txtUserPassword').focus();
        }
    });
    $('#txtUserPassword').keydown(function (event) {
        if (event.which === 13) {
            SetVariable();
        }
    });
    $('#cboDatabase').empty();
    $('#cboDatabase').append($('<option>', { value: '' })
        .text('N/A'));
    $.get(path +'Config/GetDatabase').done(function (dr) {
        if (dr.database.length > 0) {
            for (let i = 0; i < dr.database.length; i++) {
                $('#cboDatabase').append($('<option>', { value: (i + 1) })
                    .text(dr.company + '->' + dr.database[i].trim()));
            }
            $('#cboDatabase').val(1);
        }
    });
    function SetVariable() {
        let userID = $('#txtUserLogin').val();
        let dbID = $('#cboDatabase').val();
        let userType = $('input[name=optRole]:checked').val();

        let Password = $('#txtUserPassword').val();
        $.get(path +'Config/SetLogin?Group=' + userType + '&Code=' + userID + '&Pass=' + Password + '&Database=' + dbID)
            .done(function (r) {
                if (r.user.data.length > 0) {
                    window.location.assign(path +'Master');
                } else {
                    alert(r.user.message);
                }
            });
    }
function OpenTracking(){
                    window.location.href=path +'Tracking/PublicIndex';
}
    function ForceLogout() {
        userType = $('input[name=optRole]:checked').val();

        $.get(path + 'config/setlogout?group=' + userType + '&code=' + $('#txtUserLogin').val()).done(function (r) {
            if (r == "Y") {
                alert('Logout complete!');
            }
        });
    }
</script>