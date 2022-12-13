@Code
    ViewData("Title") = "Util"
End Code
<h2>Transfer Data</h2>
<div class="row">
    <div class="col-sm-3">
        <b>Change Job Number</b> : From<br />
        <input type="text" class="form-control" id="txtFromJob" />
    </div>
    <div class="col-sm-3">
        To <br />
        <input type="text" class="form-control" id="txtToJob" />
    </div>
    <div class="col-sm-3">
        <br/>
        <input type="button" class="btn btn-primary" value="Change" id="btnChangeJob" />
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        <b>Change Customer</b> : From
        <br />
        <div style="display:flex;">
            <input type="text" class="form-control" id="txtFromCust" style="width:80%" />
            <input type="text" class="form-control" id="txtFromBranch" />
        </div>        
    </div>
    <div class="col-sm-3">
        To
        <br />
        <div style="display:flex;">
            <input type="text" class="form-control" id="txtToCust" style="width:80%" />
            <input type="text" class="form-control" id="txtToBranch" />
        </div>
    </div>
    <div class="col-sm-3">
        <br />
        <input type="button" class="btn btn-primary" value="Change" id="btnChangeCust" />
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        <b>Change Service Charges</b> : From<br />
        <input type="text" class="form-control" id="txtFromCode" />
    </div>
    <div class="col-sm-3">
        To <br />
        <input type="text" class="form-control" id="txtToCode" />
    </div>
    <div class="col-sm-3">
        <br />
        <input type="button" class="btn btn-primary" value="Change" id="btnChangeSICode" />
    </div>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    $('#btnChangeJob').one('click', function () {
        $('#btnChangeJob').attr('disabled', 'disabled');
        $.get(path + 'JobOrder/ChangeJobNumber?FromCode=' + $('#txtFromJob').val() + '&ToCode=' + $('#txtToJob').val()).done(function (r) {
            ShowMessage(r);
        });
    });
    $('#btnChangeCust').one('cust', function () {
        $('#btnChangeCust').attr('disabled', 'disabled');
        $.get(path + 'JobOrder/ChangeCustomer?FromCode=' + $('#txtFromCust').val() + '&ToCode=' + $('#txtToCust').val() + '&FromBranch=' + $('#txtFromBranch').val() + '&ToBranch=' + $('#txtToBranch').val()).done(function (r) {
            ShowMessage(r);
        });
    });
    $('#btnChangeSICode').one('click', function () {
        $('#btnChangeSICode').attr('disabled', 'disabled');
        $.get(path + 'JobOrder/ChangeServiceCode?FromCode=' + $('#txtFromCode').val() + '&ToCode=' + $('#txtToCode').val()).done(function (r) {
            ShowMessage(r);
        });
    });
</script>