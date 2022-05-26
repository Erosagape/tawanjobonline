@Code
    ViewData("Title") = "Master Job"
End Code
<div class="row">
    <div class="col-sm-4">
        <label id="lblBranchCode">Branch Code</label>
        <br/>
        <div style="display:flex">
            <input type="text" id="txtBranchCode" style="width:50px;" class="form-control" value="@ViewBag.PROFILE_DEFAULT_BRANCH" />
            <a class="btn btn-default">...</a>
            <input type="text" id="txtBranchName" class="form-control" style="width:100%;" value="@ViewBag.PROFILE_DEFAULT_BRANCH_NAME" disabled />
        </div>
    </div>
    <div class="col-sm-4">
        <label id="lblJobType">Job Type</label>
        <br/>
        <div style="display:flex">
            <select id="cboJobType" class="form-control dropdown"></select>
        </div>
    </div>
    <div class="col-sm-4">
        <label id="lblJobType">Ship By</label>
        <br />
        <div style="display:flex">
            <select id="cboShipBy" class="form-control dropdown"></select>
        </div>
    </div>
</div>
<div class="row">

</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function LoadJobType() {
        let arr = JSON.parse(@Html.Raw(Json.Encode(ViewBag.JobType)));
        $('#cboJobType').empty();
        $('#cboJobType').append($('<option>', { value: '' })
            .text('N/A'));
        for (let jt of arr) {

            $('#cboJobType').append($('<option>', { value: jt.ConfigKey })
                .text(jt.ConfigValue));
        }
        return true;
    }
    function LoadShipBy(jt='') {
        let arr = JSON.parse(@Html.Raw(Json.Encode(ViewBag.ShipBy)));
        let chk = JSON.parse(@Html.Raw(Json.Encode(ViewBag.ShipByFilter)));
        let filter = $.grep(chk,function(data) {
            return data.ConfigKey == jt;
        });
        $('#cboShipBy').empty();
        $('#cboShipBy').append($('<option>', { value: '' }).text('N/A'));
        if (filter.length > 0) {
            for (let sb of arr) {
                if (filter[0].ConfigValue.indexOf(sb.ConfigKey) >= 0 || jt == '') {
                    $('#cboShipBy').append($('<option>', { value: sb.ConfigKey })
                        .text(sb.ConfigValue));
                }
            }
        }
        return true;
    }
    $('#cboJobType').blur(() => {
        let val = $('#cboJobType').val();
        LoadShipBy(val);
    });
    //main caller
    LoadJobType();
    LoadShipBy();
</script>


