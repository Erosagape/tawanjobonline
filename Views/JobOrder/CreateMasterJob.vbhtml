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
    <div class="row">
        <div class="col-sm-6">
            <label>Exporter/Importer</label>
            <br/>
            <div style="display:flex;">

            </div>
        </div>
        <div class="col-sm-6">
            <label>Consignee</label>
            <br />
            <div style="display:flex;">

            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="modCustomer">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                List of Companys
            </div>
            <div class="modal-body">
                <table class="table table-responsive" id="tbCompany">
                    <thead>
                        <tr>
                            <th>
                                #
                            </th>
                            <th>
                                Code
                            </th>
                            <th>
                                Name
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var companys=JSON.parse(@Html.Raw(Json.Encode(ViewBag.Company)));
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
    function LoadCustomer(type) {
        $('#tbCompany tbody').empty();
        if (companys.length > 0) {
            let lst = companys;
            if (type !== '') {
                lst = $.grep(companys, function (data) {
                    return data.CustGroup == type;
                });
            }
            for (let o of lst) {

            }
        }
    }
    $('#cboJobType').blur(() => {
        let val = $('#cboJobType').val();
        LoadShipBy(val);
    });

    //main
    LoadJobType();
    LoadShipBy();
    LoadCustomer(type);
</script>


