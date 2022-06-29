@Code
    ViewData("Title") = "Master Job"
End Code
<div class="row">
    <div class="col-sm-4">
        <label id="lblBranchCode">Branch Code</label>
        <br/>
        <div style="display:flex">
            <input type="text" id="txtBranchCode" style="width:50px;" class="form-control" value="@ViewBag.PROFILE_DEFAULT_BRANCH" />
            <button class="btn btn-default" onclick="LoadBranch()">...</button>
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
    <div class="col-sm-6">
        <label>Shipper</label>
        <br/>
        <div style="display:flex;">
            <input type="text" id="txtCustCode" class="form-control" style="width:20%;"/>
            <input type="text" id="txtCustBranch" class="form-control" style="width:10%;" />
            <button class="btn btn-default"  onclick="LoadCustomer('CUSTOMERS')">...</button>
            <input type="text" id="txtCustName" class="form-control" style="width:60%;" readonly />
        </div>
    </div>
    <div class="col-sm-6">
        <label>Consignee</label>
        <br />
        <div style="display:flex;">
            <input type="text" id="txtconsigncode" class="form-control" style="width:30%;" />
            <button href="" class="btn btn-default" onclick="LoadCustomer('CONSIGNEE')">...</button>
            <input type="text" id="txtconsignname" class="form-control" style="width:60%;" readonly/>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-6">
        <label>Notify Party</label>
        <br />
        <div style="display:flex;">
            <input type="text" id="txtNotifyCode" class="form-control" style="width:20%;" />            
            <button class="btn btn-default" onclick="LoadCustomer('NOTIFY')">...</button>
            <input type="text" id="txtNotifyName" class="form-control" style="width:60%;" readonly />
        </div>
    </div>
    <div class="col-sm-6">
        <label>Forwarder</label>
        <br />
        <div style="display:flex;">
            <input type="text" id="txtForwarderCode" class="form-control" style="width:30%;" />
            <button href="" class="btn btn-default" onclick="LoadVender('FORWARDER')">...</button>
            <input type="text" id="txtForwarderName" class="form-control" style="width:60%;" readonly />
        </div>
    </div>
</div>
<div class="modal" id="modBranch" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                List of Branch
            </div>
            <div class="modal-body">
                <table class="table table-responsive" id="tbBranch">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Code</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" id="modVender" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="model-header">
                List of Vender
            </div>
            <div class="model-body">
                <table class="table table-responsive" id="tbVender">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Code</th>
                            <th>Name</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" id="modCustomer" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                List of <label id="lblCustList"></label>
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
                                Name (TH)
                            </th>
                            <th>
                                Name (EN)
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
<div style="width:100%;">
    
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let companys = JSON.parse(@Html.Raw(Json.Encode(ViewBag.Company)));
    let branchs = JSON.parse(@Html.Raw(Json.Encode(ViewBag.Branch)));
    let venders = JSON.parse(@Html.Raw(Json.Encode(ViewBag.Vender)));
    let searchMode = '';
    let isLoadBranch = false;
    let isLoadVender = false;
    function LoadBranch() {
        if (!isLoadBranch) {
            let lst = branchs;
            $('#tbBranch tbody').empty();
            if (lst.length > 0) {
                for (let o of lst) {
                    let html = '<tr>';
                    html += '<td><button class="btn btn-warning" onclick="SelectBranch(' + "'" + o.Code + "'"+ ')">Select</button></td>';
                    html += '<td>' + o.Code + '</td>';
                    html += '<td>' + o.BrName + '</td>';
                    html += '</tr>';
                    $('#tbBranch tbody').append(html);
                }
            }
            isLoadBranch = true;
        }
        $('#modBranch').modal('show');
    }
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
    function LoadVender(type) {
        searchMode = type;
        $('#tbVender tbody').empty();
        if (venders.length > 0) {
            let lst = venders;
            for (let o of lst) {
                let html = '<tr>';
                html += '<td><button class="btn btn-warning" onclick="SelectVender(' + "'" + o.VenCode + "'" + ')">Select</button></td>';
                html += '<td>' + o.VenCode + '</td>';
                html += '<td>' + o.TName + '</td>';
                html += '</tr>';
                $('#tbVender tbody').append(html);
            }
        }
        $('#modVender').modal('show');
    }
    function LoadCustomer(type) {
        searchMode = type;
        $('#lblCustList').text(type);
        $('#tbCompany tbody').empty();
        if (companys.length > 0) {
            let lst = companys;
            //if (type !== '') {
            //    lst = $.grep(companys, function (data) {
            //        return data.CustGroup == type;
            //    });
            //}
            for (let o of lst) {
                let html = '<tr>';
                html += '<td><button class="btn btn-warning" onclick="SelectCust(' + "'"+ o.CustCode + "'" + ',' + "'" + o.Branch +"'"+ ')">Select</button></td>';
                html += '<td>' + o.CustCode + '/' + o.Branch + '</td>';
                html += '<td>' + o.NameThai + '</td>';
                html += '<td>' + o.NameEng + '</td>';
                html += '</tr>';
                $('#tbCompany tbody').append(html);
            }
        }
        $('#modCustomer').modal('show');
    }
    function SelectBranch(branch) {
        let lst = $.grep(branchs, function (data) {
            return data.Code == branch;
        });
        if (lst.length > 0) {
            let b = lst[0];
            $('#txtBranchCode').val(b.Code);
            $('#txtBranchName').val(b.BrName);
        }
        $('#modBranch').modal('hide');
    }
    function SelectCust(cust, branch) {
        let lst = companys;
        if (searchMode !== '') {
            lst = $.grep(companys, function (data) {
                return data.CustCode == cust && data.Branch==branch;
            });
            if (lst.length > 0) {
                let c = lst[0];
                switch (searchMode) {
                    case 'CUSTOMERS':
                        $('#txtCustCode').val(c.CustCode);
                        $('#txtCustBranch').val(c.Branch);
                        $('#txtCustName').val(c.NameThai);
                        break;
                    case 'CONSIGNEE':
                        $('#txtconsigncode').val(c.CustCode);
                        $('#txtconsignname').val(c.NameThai);
                        break;
                    case 'NOTIFY':
                        $('#txtNotifyCode').val(c.CustCode);
                        $('#txtNotifyName').val(c.NameThai);
                        break;
                }
            }
        }
        $('#modCustomer').modal('hide');
    }
    function SelectVender(vend) {
        let lst = venders;
        if (searchMode !== '') {
            lst = $.grep(venders, function (data) {
                return data.VenCode == vend;
            });
            if (lst.length > 0) {
                let v = lst[0];
                switch (searchMode) {
                    case 'FORWARDER':
                        $('#txtForwarderCode').val(v.VenCode);
                        $('#txtForwarderName').val(v.TName);
                        break;
                }
            }
        }
        $('#modVender').modal('hide');
    }
    $('#cboJobType').blur(() => {
        let val = $('#cboJobType').val();
        LoadShipBy(val);
    });

    //main
    LoadJobType();
    LoadShipBy();
</script>


