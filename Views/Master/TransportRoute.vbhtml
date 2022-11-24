@Code
    ViewBag.Title = "Transport Route"
End Code
<ul class="nav nav-tabs">
    <li class="active"><a id="linkTab1" data-toggle="tab" href="#tabHeader">Route Lists</a></li>
    <li><a id="linkTab2" data-toggle="tab" href="#tabDetail">Price Lists</a></li>
</ul>
<div class="tab-content">
    <div id="tabHeader" class="tab-pane fade in active">
        <div class="row">
            <div class="col-sm-2">
                <label id="lblTemplate">Type:</label>                
                <br />
                <select id="cboTemplate" class="form-control dropdown" onclick="GenRoute()">
                    <option value="4123" selected>
                        EXPORT
                    </option>
                    <option value="4123">
                        IMPORT
                    </option>
                    <option value="412">
                        DOMESTIC
                    </option>
                </select>
            </div>
            <div class="col-sm-1">
                #<br />
                <input type="text" id="txtLocationID" class="form-control" value="0" disabled />
            </div>
            <div class="col-sm-6">
                <label id="lblRouteFormat"></label><br />
                <input type="text" id="txtLocationRoute" class="form-control" disabled />
            </div>
            <div class="col-sm-1">
                <br />
                <button id="btnSelRoute" class="btn btn-primary" style="width:100%" onclick="$('#dvList').modal('show');">Select</button>
            </div>
            <div class="col-sm-1">
                <br />
                <button id="btnNewRoute" class="btn w3-purple" style="width:100%" onclick="ClearRoute()" >New</button>
            </div>
            <div class="col-sm-1">
                <br />
                <button id="btnSaveRoute" style="width:100%" class="btn btn-success" onclick="SaveRoute()">Save</button>
            </div>
        </div>
        <p>
            <div class="row">
                <div class="col-md-3">
                    <label id="lblPlace1">Pickup</label><br />
                    <input type="text" class="form-control" id="txtPlace1" onchange="GenRoute()" />
                    <label id="lblAddress1">Address</label><br />
                    <textarea class="form-control" id="txtAddress1"></textarea>
                    <label id="lblContact1">Contact</label><br />
                    <input type="text" class="form-control" id="txtContact1" />
                    <button id="btnSaveP1" class="btn btn-success" onclick="SavePlace(1)">Save</button>
                    <button id="btnClearP1" class="btn w3-purple" onclick="ClearPlace(1)">Clear</button>
                    <button id="btnDelP1" class="btn btn-danger" onclick="DeletePlace(1)">Delete</button>
                </div>
                <div class="col-md-3">
                    <label id="lblPlace2">Delivery</label><br />
                    <input type="text" class="form-control" id="txtPlace2" onchange="GenRoute()" />
                    <label id="lblAddress2">Address</label><br />
                    <textarea class="form-control" id="txtAddress2"></textarea>
                    <label id="lblContact2">Contact</label><br />
                    <input type="text" class="form-control" id="txtContact2" />
                    <button id="btnSaveP2" class="btn btn-success" onclick="SavePlace(2)">Save</button>
                    <button id="btnClearP2" class="btn w3-purple" onclick="ClearPlace(2)">Clear</button>
                    <button id="btnDelP2" class="btn btn-danger" onclick="DeletePlace(2)">Delete</button>
                </div>
                <div class="col-md-3">
                    <label id="lblPlace3">Return</label><br />
                    <input type="text" class="form-control" id="txtPlace3" onchange="GenRoute()" />
                    <label id="lblAddress3">Address</label><br />
                    <textarea class="form-control" id="txtAddress3"></textarea>
                    <label id="lblContact3">Contact</label><br />
                    <input type="text" class="form-control" id="txtContact3" />
                    <button id="btnSaveP3" class="btn btn-success" onclick="SavePlace(3)">Save</button>
                    <button id="btnClearP3" class="btn w3-purple" onclick="ClearPlace(3)">Clear</button>
                    <button id="btnDelP3" class="btn btn-danger" onclick="DeletePlace(3)">Delete</button>
                </div>
                <div class="col-md-3">
                    <label id="lblPlace4">Container Size</label><br />
                    <input type="text" class="form-control" id="txtPlace4" onchange="GenRoute()" />
                    <label id="lblAddress4">Address</label><br />
                    <textarea class="form-control" id="txtAddress4"></textarea>
                    <label id="lblContact4">Contact</label><br />
                    <input type="text" class="form-control" id="txtContact4" />
                    <button id="btnSaveP4" class="btn btn-success" onclick="SavePlace(4)">Save</button>
                    <button id="btnClearP4" class="btn w3-purple" onclick="ClearPlace(4)">Clear</button>
                    <button id="btnDelP4" class="btn btn-danger" onclick="DeletePlace(4)">Delete</button>
                </div>
            </div>
        </p>
        <div class="row">
            <div class="col-md-3">
                <table id="lstPlace1" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Pickup</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div class="col-md-3">
                <table id="lstPlace2" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Delivery</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div class="col-md-3">
                <table id="lstPlace3" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Return</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div class="col-md-3">
                <table id="lstPlace4" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Condition</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div>
    </div>
    <div id="tabDetail" class="tab-pane fade">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblBranchCode">Branch:</label>
                <br />
                <div style="display:flex">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:60%" disabled />
                </div>
            </div>
            <div class="col-md-4">
                <label id="lblLocation">Location:</label>
                <br />
                <select id="cboLocationID" class="form-control dropdown" onchange="LoadPrice()"></select>
            </div>
            <div class="col-md-4">
                <br />
                <button class="btn w3-purple" id="btnNewPrice" onclick="ClearExpense()">New Price</button>
                <button class="btn btn-success" id="btnSavePrice" onclick="SaveExpense()">Save Price</button>
                <button class="btn btn-danger" id="btnDelPrice" onclick="DelExpense()">Delete Price</button>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <label id="lblVender">Vender :</label>
                <br />
                <div style="display:flex">
                    <input type="text" id="txtVenderCode" class="form-control" style="width:20%" disabled />
                    <input type="button" id="btnBrowseVend" class="btn btn-default" value="..." onclick="SearchData('vender')" />
                    <input type="text" id="txtVenderName" class="form-control" style="width:70%" disabled />
                </div>
            </div>
            <div class="col-md-6">
                <label id="lblCustomer">Customer :</label>
                <br />
                <div style="display:flex">
                    <input type="text" id="txtCustCode" class="form-control" style="width:20%" disabled />
                    <input type="button" id="btnBrowseCust" class="btn btn-default" value="..." onclick="SearchData('cust')" />
                    <input type="text" id="txtCustName" class="form-control" style="width:70%" disabled />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label id="lblExpenseCode">Expense Code:</label>
                <br />
                <div style="display:flex">
                    <input type="text" id="txtSICode" class="form-control" style="width:20%" disabled />
                    <input type="button" id="btnBrowseCost" class="btn btn-default" value="..." onclick="SearchData('costcode')" />
                    <input type="text" id="txtCostName" class="form-control" style="width:70%" disabled />
                </div>
            </div>
            <div class="col-md-2">
                <label id="lblAmount">Amount:</label>
                <br />
                <input type="text" id="txtCostAmount" class="form-control" />
            </div>
            <div class="col-md-4">
                <label id="lblChargeCode">Charge Code:</label>
                <br />
                <div style="display:flex">
                    <input type="text" id="txtChargeCode" class="form-control" style="width:20%" disabled />
                    <input type="button" id="btnBrowseCharge" class="btn btn-default" value="..." onclick="SearchData('servicecode')" />
                    <input type="text" id="txtChargeName" class="form-control" style="width:70%" disabled />
                </div>
            </div>
            <div class="col-md-2">
                <label id="lblCAmount">Amount:</label>
                <br />
                <input type="text" id="txtChargeAmount" class="form-control" />
            </div>
        </div>
        <table id="tbPrice" class="table table-responsive">
            <thead>
                <tr>
                    <th>VenderCode</th>
                    <th>CustCode</th>
                    <th>SICode</th>
                    <th>SDescription</th>
                    <th>CostAmount</th>
                    <th>ChargeCode</th>
                    <th>ChargeAmount</th>
                    <th>Location</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>
</div>
<div id="dvList" class="modal fade" role="dialog">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-body">
                <table id="tbDetail" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Route ID</th>
                            <th>LocationRoute</th>
                            <th>Delete</th>
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
<div id="dvLOVs">
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    let userGroup = '@ViewBag.UserGroup';
    if (userGroup == 'V') {
        $('#btnBrowseVend').attr('disabled', 'disabled');
        $('#txtVenderCode').attr('disabled', 'disabled');
        $('#txtVenderName').attr('disabled', 'disabled');
        $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
            if (r.vender.data.length > 0) {
                let dr = r.vender.data[0];
                $('#txtVenderCode').val(dr.VenCode);
                $('#txtVenderName').val(dr.TName);
            }
        });
    }
    SetLOVs();
    LoadPrice();
    ShowData();
    LoadGrid();
    function SetLOVs() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        LoadRoute();
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv,'#frmSearchCust', '#tbCust','Customers',response,3);
            //Agent
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchServ1', '#tbServ1', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchServ2', '#tbServ2', 'Service Code', response, 2);
        });
    }
    function LoadRoute() {
        $.get(path + 'JobOrder/GetTransportRoute', function (r) {
            if (r.transportroute.data !== undefined) {
                let dr = r.transportroute.data;
                $('#cboLocationID').empty();
                $('#cboLocationID').append($('<option>', { value: '' })
                    .text('N/A'));
                if (dr.length > 0) {
                    for (let i = 0; i < dr.length; i++) {
                        $('#cboLocationID').append($('<option>', { value: dr[i].LocationID })
                            .text(dr[i].LocationRoute));
                    }
                }
            }
        });
    }
    function ShowData() {
        LoadPlace(1);
        LoadPlace(2);
        LoadPlace(3);
        LoadPlace(4);
    }
    function LoadPrice() {
        let w = '?Branch=' + $('#txtBranchCode').val();
        if ($('#cboLocationID').val() !== '' && $('#cboLocationID').val() !== null) {
            w += '&ID=' + $('#cboLocationID').val();
        }
        if ($('#txtVenderCode').val() !== '') {
            w += '&Vend=' + $('#txtVenderCode').val();
        }
        if ($('#txtCustCode').val() !== '') {
            w += '&Cust=' + $('#txtCustCode').val();
        }
        $('#tbPrice').DataTable().clear().draw();
        $.get(path + 'JobOrder/GetTransportPrice' + w).done((r) => {
            if (r.transportprice.data.length > 0) {
                let tbp=$('#tbPrice').DataTable({
                    data: r.transportprice.data,
                    columns: [
                        { data: "VenderCode", title: "Vender" },
                        { data: "CustCode", title: "Customer" },
                        { data: "SICode", title: "Cost Code" },
                        { data: "SDescription", title: "Description" },
                        { data: "CostAmount", title: "Buy Rate" },
                        { data: "ChargeCode", title: "Charge Code" },
                        { data: "ChargeAmount", title: "Sale Rate" },
                        { data: "Location", title: "Location" }
                    ],
                    destroy:true
                });
                //ChangeLanguageGrid('@ViewBag.Module', '#tbPrice');
                $('#tbPrice tbody').on('click', 'tr', function () {
                    $('#tbPrice tbody > tr').removeClass('selected');
                    $(this).addClass('selected');

                    let data = $('#tbPrice').DataTable().row(this).data();
                    $('#cboLocationID').val(data.LocationID);
                    $('#txtVenderCode').val(data.VenderCode);
                    ShowVender(path, data.VenderCode, '#txtVenderName');
                    $('#txtCustCode').val(data.CustCode);
                    ShowCompany(path, data.CustCode, '#txtCustName');
                    $('#txtSICode').val(data.SICode);
                    $('#txtCostName').val(data.SDescription);
                    $('#txtCostAmount').val(data.CostAmount);
                    $('#txtChargeCode').val(data.ChargeCode);
                    ShowServiceCode(path, data.ChargeCode, '#txtChargeName');
                    $('#txtChargeAmount').val(data.ChargeAmount);
                });
            }
        });
    }
    function LoadGrid() {
        $.get(path + 'JobOrder/GetTransportRoute').done((r) => {
            if (r.transportroute.data.length > 0) {
                let tbd=$('#tbDetail').DataTable({
                    data: r.transportroute.data,
                    columns: [
                        { data: "LocationID", title: "Route ID"},
                        { data: "LocationRoute", title: "Route" },
                        {
                            data: null, "title": "Edit",
                            render: function (data) {
                                let html = '';
                                html += '<button class="btn btn-danger" onclick="DeleteRoute(' + data.LocationID + ')">'+(mainLanguage=="EN"?"Delete":"ลบเส้นทาง")+'</button>';
                                html += '<button class="btn btn-warning" onclick="ShowPrice(' + data.LocationID + ')">'+(mainLanguage=="EN"?"Price":"แสดงราคา")+'</button>';
                                return html;
                            }
                        }
                    ],
                    destroy:true
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
                $('#tbDetail tbody').on('dblclick', 'tr', function () {
                    $('#dvList').modal('hide');
                });
                $('#tbDetail tbody').on('click', 'tr', function () {
                    $('#tbDetail tbody > tr').removeClass('selected');
                    $(this).addClass('selected');

                    let data = $('#tbDetail').DataTable().row(this).data();
                    $('#cboTemplate').val(data.RouteFormat);
                    let idx1 = (data.RouteFormat.length > 0 ? data.RouteFormat.substr(0, 1) : 0);
                    let idx2 = (data.RouteFormat.length > 1 ? data.RouteFormat.substr(1, 1) : 0);
                    let idx3 = (data.RouteFormat.length > 2 ? data.RouteFormat.substr(2, 1) : 0);
                    let idx4 = (data.RouteFormat.length > 3 ? data.RouteFormat.substr(3, 1) : 0);

                    ClearPlace(1);
                    ClearPlace(2);
                    ClearPlace(3);
                    ClearPlace(4);

                    $('#txtLocationID').val(data.LocationID);
                    $('#cboLocationID').val(data.LocationID);
                    $('#txtLocationRoute').val(data.LocationRoute);

                    $('#txtPlace' + idx1).val(data.Place1);
                    $('#txtAddress' + idx1).val(data.Address1);
                    $('#txtContact' + idx1).val(data.Contact1);
                    $('#txtPlace' + idx2).val(data.Place2);
                    $('#txtAddress' + idx2).val(data.Address2);
                    $('#txtContact' + idx2).val(data.Contact2);
                    $('#txtPlace' + idx3).val(data.Place3);
                    $('#txtAddress' + idx3).val(data.Address3);
                    $('#txtContact' + idx3).val(data.Contact3);
                    $('#txtPlace' + idx4).val(data.Place4);
                    $('#txtAddress' + idx4).val(data.Address4);
                    $('#txtContact' + idx4).val(data.Contact4);
                    LoadPrice();
                });
            }
        });
    }
    function DeleteRoute(id) {
        var pathdel = path + 'JobOrder/DelTransportRoute?ID=' + id;
        ShowConfirm('Please confirm to delete', (ans) => {
            if (ans == true) {
                $.get(pathdel).done(function (r) {
                    ShowMessage(r.transportroute.result);
                    LoadGrid();
                });
            }
        });
    }
    function ShowPrice(id) {
        $('#dvList').modal('hide');
        $('a[href="#tabDetail"]').click();
    }
    function ClearRoute() {
        $('#txtLocationID').val(0);
        ShowConfirm('Please confirm to clear all data', (ans) => {
            if (ans == true) {
                ClearPlace(1);
                ClearPlace(2);
                ClearPlace(3);
                ClearPlace(4);
            }
        });
    }
    function ClearPlace(id) {
        $('#txtPlace' + id).val('').change();
        $('#txtAddress' + id).val('');
        $('#txtContact' + id).val('');
    }
    function LoadPlace(id) {
        $.get(path + 'Master/GetTransportPlace?Type=' + id).done(function (r) {
            if (r.transportplace.data.length > 0) {
                $('#lstPlace' + id).DataTable({
                    data: r.transportplace.data,
                    columns: [
                        { data: "PlaceName" }
                    ],
                    destroy:true
                });
                ChangeLanguageGrid('@ViewBag.Module', '#lstPlace'+ id);
                $('#lstPlace'+id+' tbody').on('click', 'tr', function () {
                    $('#lstPlace'+id+' tbody > tr').removeClass('selected');
                    $(this).addClass('selected');

                    let data = $('#lstPlace' + id).DataTable().row(this).data();
                    SetPlace(data.PlaceType, data.PlaceName);
                });
            }
        });
    }
    function SetPlace(id, val) {
        $.get(path + 'Master/GetTransportPlace?Type=' + id + '&Code=' + val.toString().replace("'", "''")).done(function (r) {
            if (r.transportplace.data.length > 0) {
                let d = r.transportplace.data[0];
                $('#txtAddress'+ d.PlaceType).val(d.PlaceAddress);
                $('#txtContact' + d.PlaceType).val(d.PlaceContact);
                $('#txtPlace' + d.PlaceType).val(d.PlaceName).change();
            }
        });
    }
    function GetFormat(id) {
        let str = '';
        for (let i = 0; i < 4;i++) {
            switch (id.substr(i, 1)) {
                case '1':
                    str += (str !== '' ? ',' : '') + 'Pickup';
                    break;
                case '2':
                    str += (str !== '' ? ',' : '') + 'Delivery';
                    break;
                case '3':
                    str += (str !== '' ? ',' : '') + 'Container Yard';
                    break;
                case '4':
                    str += (str !== '' ? ',' : '') + 'Container Size';
                    break;
            }
        }
        return str;
    }
    function GenRoute() {
        $('#lblRouteFormat').text(GetFormat($('#cboTemplate').val()));
        let str = '';
        if ($('#cboTemplate').val().toString().length >= 1) {
            let idx1 = $('#txtPlace'+$('#cboTemplate').val().toString().substr(0, 1)).val();
            if (idx1 !== '') str += (str !== '' ? '->' : '') + idx1;
        }
        if ($('#cboTemplate').val().toString().length >= 2) {
            let idx2 = $('#txtPlace' + $('#cboTemplate').val().toString().substr(1, 1)).val();
            if (idx2 !== '') str += (str !== '' ? '->' : '') + idx2;
        }
        if ($('#cboTemplate').val().toString().length >= 3) {
            let idx3 = $('#txtPlace' + $('#cboTemplate').val().toString().substr(2, 1)).val();
            if(idx3!=='') str += (str !== '' ? '->' : '') + idx3;
        }
        if ($('#cboTemplate').val().toString().length >= 4) {
            let idx4 = $('#txtPlace' + $('#cboTemplate').val().toString().substr(3, 1)).val();
            if(idx4!=='') str += (str !== '' ? '->' : '') + idx4;      
        }
        $('#txtLocationRoute').val(str);
    }
    function DeletePlace(id) {
        let pname = $('#txtPlace' + id).val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == true) {
                $.get(path + 'Master/DelTransportPlace?Type=' + id + '&Code=' + pname).done(function (r) {
                    ShowMessage(r.transportplace.result);
                    ShowData();
                });
            }
        });
    }

    function SavePlace(id) {
        let pname = $('#txtPlace' + id).val();
        let obj = {
            PlaceType: id,
            PlaceName: pname,
            PlaceAddress: $('#txtAddress' + id).val(),
            PlaceContact: $('#txtContact' + id).val()
        };
        let json = JSON.stringify({ data: obj });
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == true) {
                postData(path + 'Master/SetTransportPlace', json, function (r) {
                    ShowData();
                    ShowMessage(r.result.msg);
                });
            }
        });
    }
    function SaveRoute() {
        let routeFormat = $('#cboTemplate').val();
        let idx1 = (routeFormat.length > 0 ? routeFormat.substr(0, 1) : 0);
        let idx2 = (routeFormat.length > 1 ? routeFormat.substr(1, 1) : 0);
        let idx3 = (routeFormat.length > 2 ? routeFormat.substr(2, 1) : 0);
        let idx4 = (routeFormat.length > 3 ? routeFormat.substr(3, 1) : 0);
        
        let obj = {
            LocationID: CNum($('#txtLocationID').val()),
            Place1: $('#txtPlace'+ idx1).val(),
            Place2: $('#txtPlace'+ idx2).val(),
            Place3: $('#txtPlace'+ idx3).val(),
            Place4: $('#txtPlace'+ idx4).val(),
            Address1: $('#txtAddress'+ idx1).val(),
            Address2: $('#txtAddress'+ idx2).val(),
            Address3: $('#txtAddress'+ idx3).val(),
            Address4: $('#txtAddress'+ idx4).val(),
            Contact1: $('#txtContact'+ idx1).val(),
            Contact2: $('#txtContact'+ idx2).val(),
            Contact3: $('#txtContact'+ idx3).val(),
            Contact4: $('#txtContact'+ idx4).val(),
            LocationRoute: $('#txtLocationRoute').val(),
            RouteFormat: routeFormat,
            IsActive: true
        };
        let json = JSON.stringify({ data: obj });
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == true) {
                postData(path + 'JobOrder/SetTransportRoute', json, function (r) {
                    ShowMessage(r.result.msg);
                    LoadRoute();
                    LoadGrid();
                });
            }
        });
    }
    function SearchData(type) {
        let w = '';
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'cust':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch','#frmSearchBranch', ReadBranch);
                break;
            case 'costcode':
                SetGridSICode(path, '#tbServ1', '', '#frmSearchServ1', ReadService1);
                break;
            case 'servicecode':
                SetGridSICode(path, '#tbServ2', '', '#frmSearchServ2', ReadService2);
                break;
        }
    }
    function ReadService1(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtCostName').val(dt.NameThai);
        $('#txtChargeAmount').val(CDbl(dt.StdPrice,2));
        $('#txtCostAmount').val(CDbl(dt.StdPrice, 2));
        ReadService2(dt);
    }
    function ReadService2(dt) {
        $('#txtChargeCode').val(dt.SICode);
        $('#txtChargeName').val(dt.NameThai);
        $('#txtChargeAmount').val(CDbl(dt.StdPrice,2));
    }
    function ReadVender(dt) {
        $('#txtVenderCode').val(dt.VenCode);
        $('#txtVenderName').val(dt.TName);
        LoadPrice();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustName').val(dt.Title + ' ' + dt.NameThai);
        LoadPrice();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function SaveExpense() {
        if ($('#txtBranchCode').val() === '') {
            ShowMessage('Please input branch', true);
            return;
        }
        if ($('#txtCustCode').val() === '') {
            ShowMessage('Please choose customer first', true);
            return;
        }
        if ($('#txtVenderCode').val() === '') {
            ShowMessage('Please choose vender first', true);
            return;
        }
        if ($('#cboLocationID').val() === '') {
            ShowMessage('Please choose route', true);
            return;
        }
        if ($('#txtSICode').val() !== '') {
            ShowConfirm('Please confirm to save', (ans) => {
                if (ans == true) {
                    let obj = {
                        BranchCode: $('#txtBranchCode').val(),
                        LocationID: $('#cboLocationID').val(),
                        VenderCode: $('#txtVenderCode').val(),
                        CustCode: $('#txtCustCode').val(),
                        SICode: $('#txtSICode').val(),
                        SDescription: $('#txtCostName').val(),
                        CostAmount: CDbl($('#txtCostAmount').val(),2),
                        ChargeAmount: CDbl($('#txtChargeAmount').val(), 2),
                        Location: $('#cboLocationID option:selected').text(),
                        ChargeCode: $('#txtChargeCode').val()
                    };
                    let jsonText = JSON.stringify({ data: obj });
                    $.ajax({
                        url: "@Url.Action("SetTransportPrice", "JobOrder")",
                        type: "POST",
                        contentType: "application/json",
                        data: jsonText,
                        success: function (response) {
                            if (response.result.data != null) {
                                if (response.result.data >= 0) {
                                    //LoadRoute();
                                    LoadPrice();
                                    ShowMessage('Save Complete');
                                }
                                return;
                            }
                            ShowMessage(response.result.msg,true);
                        },
                        error: function (e) {
                            ShowMessage(e,true);
                        }
                    });
                }
            });
        } else {
            ShowMessage('Please input expense code',true);
        }
    }
    function DelExpense() {
        ShowConfirm('Please confirm to delete', (ans) => {
            if (ans == true) {
                let w = '';
                w += '?Branch=' + $('#txtBranchCode').val();
                w += '&ID=' + $('#cboLocationID').val();
                w += '&Vend=' + $('#txtVenderCode').val();
                w += '&Cust=' + $('#txtCustCode').val();
                w += '&Code=' + $('#txtSICode').val();
                $.get(path + 'JobOrder/DelTransportPrice' + w).done((r) => {
                    if (r.transportprice.data !== null) {
                        LoadPrice();
                    }
                    ShowMessage(r.transportprice.result);
                });
            }
        });
    }
    function ClearExpense() {
        $('#txtVenderCode').val('');
        $('#txtVenderName').val('');
        $('#txtCustCode').val('');
        $('#txtCustName').val('');
        $('#txtSICode').val('');
        $('#txtChargeCode').val('');
        $('#txtCostName').val('');
        $('#txtChargeName').val('');
        $('#txtCostAmount').val('0.00');
        $('#txtChargeAmount').val('0.00');
        LoadPrice();
    }
</script>