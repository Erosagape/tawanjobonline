
@Code
    ViewBag.Title = "Transport & Loading Information"
End Code
<ul class="nav nav-tabs">
    <li class="active">
        <a data-toggle="tab" href="#tabLoading">Loading Information</a>
    </li>
    <li>
        <a data-toggle="tab" href="#tabContainer">Container Information</a>
    </li>
</ul>
<div class="tab-content">
    <div class="tab-pane fade in active" id="tabLoading">
        <div id="dvForm">
            <div class="row">
                <div class="col-sm-3">
                    Branch
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" class="form-control" id="txtBranchCode" style="width:20%" disabled />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                        <input type="text" class="form-control" id="txtBranchName" style="width:100%" disabled />
                    </div>
                </div>
                <div class="col-sm-3">
                    Booking No
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtBookingNo" class="form-control" style="width:100%" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('booking');" />
                    </div>
                </div>
                <div class="col-sm-3">
                    Job Number
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtJNo" class="form-control" style="width:100%" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('job');" />
                    </div>
                </div>
                <div class="col-sm-3">
                    Transport Term
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <select id="txtTransMode" class="form-control dropdown">
                            <option value="EXP">EXW (EX Works)</option>
                            <option value="FCA">FCA (Free Carrier)</option>
                            <option value="FAS">FAS (Free Alongside Ship)</option>
                            <option value="FOB">FOB (Free On Board)</option>
                            <option value="CPT">CPT (Carriage Paid To)</option>
                            <option value="CFR">CFR (Cost and Freight)</option>
                            <option value="CIF">CIF (Carriage Paid To)</option>
                            <option value="CIP">CIP (Carriage and Insurance Paid)</option>
                            <option value="DAT">DAT (Delivered at Terminal)</option>
                            <option value="DAP">DAP (Delivered at Place)</option>
                            <option value="DDP">DDP (Delivered Duty Paid)</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    Notify Party :<br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtNotifyCode" class="form-control" style="width:20%" />
                        <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                        <input type="text" id="txtNotifyName" class="form-control" style="width:100%" disabled />
                    </div>
                </div>
                <div class="col-sm-6">
                    Vender Code :<br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtVenderCode" class="form-control" style="width:20%">
                        <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('vender')">...</button>
                        <input type="text" id="txtVenderName" class="form-control" style="width:100%" disabled />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    Load Date :<br />
                    <div style="display:flex;flex-direction:row">
                        <input type="date" id="txtLoadDate" class="form-control">
                    </div>
                </div>
                <div class="col-sm-3">
                    Contact Name :<br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtContactName" class="form-control">
                    </div>
                </div>
                <div class="col-sm-6">
                    Remark :<br />
                    <div style="display:flex;flex-direction:row">
                        <textarea id="txtRemark" class="form-control"></textarea>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    Payment Condition :<br /><div style="display:flex;flex-direction:row"><input type="text" id="txtPaymentCondition" class="form-control"></div>
                </div>
                <div class="col-sm-6">
                    Payment By :<br /><div style="display:flex;flex-direction:row"><input type="text" id="txtPaymentBy" class="form-control"></div>
                </div>
            </div>
            <div class="panel" style="background-color:lightgreen;padding:10px 10px 10px 10px;margin-top:10px">
                <div class="row">
                    <div class="col-sm-6">
                        Select Route: <br />
                        <select id="cboLocation" class="form-control dropdown" onchange="LoadLocation()"></select>
                    </div>
                    <div class="col-sm-2">
                        Active Trip:<br />
                        <input type="text" id="txtTotalTripA" class="form-control" disabled />
                    </div>
                    <div class="col-sm-2">
                        Finished Trip:<br />
                        <input type="text" id="txtTotalTripF" class="form-control" disabled />
                    </div>
                    <div class="col-sm-2">
                        Non-active Trip:<br />
                        <input type="text" id="txtTotalTripC" class="form-control" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        CY Place :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtCYPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        At CY Date :<br />
                        <div style="display:flex;flex-direction:row"><input type="date" id="txtCYDate" class="form-control"></div>
                    </div>
                    <div class="col-sm-3">
                        At CY Time :<br />
                        <div style="display:flex;flex-direction:row"><input type="text" id="txtCYTime" class="form-control"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Factory Place :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtFactoryPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        At Factory Date :<br />
                        <div style="display:flex;flex-direction:row"><input type="date" id="txtFactoryDate" class="form-control"></div>
                    </div>
                    <div class="col-sm-3">
                        At Factory Time :<br />
                        <div style="display:flex;flex-direction:row"><input type="text" id="txtFactoryTime" class="form-control"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Packing Place :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtPackingPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        Packing Date :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="date" id="txtPackingDate" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        Packing Time :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtPackingTime" class="form-control">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Return Place :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtReturnPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        Return Date :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="date" id="txtReturnDate" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-3">
                        Return Time :<br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtReturnTime" class="form-control">
                        </div>
                    </div>
                </div>
                <input type="button" id="btnSaveLoc" value="Save Route" class="btn btn-primary" onclick="SaveLocation()" />
                <input type="button" id="btnEditExp" value="Edit Expenses" class="btn btn-info" onclick="EditExpense()" />
            </div>
        </div>
        <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearBooking()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>New Booking</b>
        </a>
        <a href="#" class="btn btn-success" id="btnSave" onclick="SaveBooking()">
            <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save Booking</b>
        </a>
        <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteBooking()">
            <i class="fa fa-lg fa-trash"></i>&nbsp;<b>Delete Booking</b>
        </a>
        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintBooking()">
            <i class="fa fa-lg fa-print"></i>&nbsp;<b>Print Booking</b>
        </a>
    </div>
    <div class="tab-pane fade" id="tabContainer">
        <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>Add Container</b>
        </a>
        <table id="tbDetail" class="table table-responsive">
            <thead>
                <tr>
                    <th>CTN_NO</th>
                    <th class="desktop">CTN_SIZE</th>
                    <th class="desktop">SealNumber</th>
                    <th class="all">TruckNO</th>
                    <th class="desktop">TruckType</th>
                    <th class="desktop">Location</th>
                    <th class="all">UnloadDate</th>
                    <th class="all">DeliveryNo</th>
                </tr>
            </thead>
        </table>
        <a href="#" class="btn btn-primary" id="btnExpense" onclick="EntryExpenses()">
            <i class="fa fa-lg fa-save"></i>&nbsp;<b>Entry Expenses</b>
        </a>
        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
            <i class="fa fa-lg fa-print"></i>&nbsp;<b>Print Delivery Slip</b>
        </a>
    </div>
</div>
<div id="dvExpenses" class="modal fade">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h4>Edit Expenses For Route</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-1">
                        <input type="text" id="txtLocationID" class="form-control" disabled />
                    </div>
                    <div class="col-sm-11">
                        <input type="text" id="txtLocationRoute" class="form-control" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label id="lblSICode">Expense Code</label><br />
                        <div style="display:flex">
                            <input type="text" id="txtSICode" class="form-control" disabled />
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('servicecode');" />
                        </div>
                    </div>
                    <div class="col-sm-10">
                        <label id="lblSIDesc">Expense Description</label><br />
                        <div style="display:flex">
                            <input type="text" id="txtSDescription" class="form-control" disabled />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblCostAmt">Cost Amount</label><br />
                        <div style="display:flex">
                            <input type="number" id="txtCostAmount" class="form-control" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label id="lblChargeAmt">Charge Amount</label><br />
                        <div style="display:flex">
                            <input type="number" id="txtChargeAmount" class="form-control" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <br />
                        <input type="button" class="btn btn-success" value="Save Expense" onclick="SaveExpense()" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div id="dvContainer" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <div class="row">
                    <div class="col-sm-2">
                        No :<br /><div style="display:flex"><input type="text" id="txtItemNo" class="form-control" disabled></div>
                    </div>
                    <div class="col-sm-4">
                        Container# :<br /><div style="display:flex"><input type="text" id="txtCTN_NO" class="form-control"></div>
                    </div>
                    <div class="col-sm-3">
                        Size :<br /><div style="display:flex"><select id="txtCTN_SIZE" class="form-control dropdown"></select></div>
                    </div>
                    <div class="col-sm-3">
                        Seal No.:<br /><div style="display:flex"><input type="text" id="txtSealNumber" class="form-control"></div>
                    </div>
                </div>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-6">
                        Product :<br /><div style="display:flex"><input type="text" id="txtProductDesc" class="form-control"></div>
                    </div>
                    <div class="col-sm-2">
                        Qty :<br /><div style="display:flex"><input type="number" id="txtProductQty" class="form-control" value="0.00"></div>
                    </div>
                    <div class="col-sm-4">
                        Unit :
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtProductUnit" class="form-control" style="width:100%">
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('servunit')" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        G/W :<br /><div style="display:flex"><input type="number" id="txtGrossWeight" class="form-control" value="0.00"></div>
                    </div>
                    <div class="col-sm-2">
                        M3 :<br /><div style="display:flex"><input type="number" id="txtMeasurement" class="form-control" value="0.00"></div>
                    </div>
                    <div class="col-sm-4">
                        Return Date :<br /><div style="display:flex"><input type="date" id="txtDReturnDate" class="form-control"></div>
                    </div>
                    <div class="col-sm-3">
                        Job Status:<br />
                        <div style="display:flex">
                            <select id="txtCauseCode" class="form-control dropdown">
                                <option value="0">Checking</option>
                                <option value="1">Approved</option>
                                <option value="2">Rejected</option>
                                <option value="3">Finished</option>
                                <option value="99">Cancelled</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        Driver :<br /><div style="display:flex"><input type="text" id="txtDriver" class="form-control"></div>
                    </div>
                    <div class="col-sm-3">
                        Truck ID :<br /><div style="display:flex"><input type="text" id="txtTruckNO" class="form-control"></div>
                    </div>
                    <div class="col-sm-4">
                        Type :
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtTruckType" class="form-control">
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('carunit')" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        Location :<br />
                        <div style="display:flex">
                            <select id="txtLocation" class="form-control"></select>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        Operation Note :<br /><div style="display:flex"><textarea id="txtComment" class="form-control"></textarea></div>
                    </div>
                    <div class="col-sm-6">
                        Shipping Mark :<br /><div style="display:flex"><textarea id="txtShippingMark" class="form-control"></textarea></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                        <b>Summary:</b>
                        <div>
                            Truck In :<br /><div style="display:flex"><input type="date" id="txtTruckIN" class="form-control"></div>
                        </div>
                        <div>
                            Truck Out:<br /><div style="display:flex"><input type="text" id="txtStart" class="form-control"></div>
                        </div>
                        <div>
                            Truck Return:<br /><div style="display:flex"><input type="text" id="txtFinish" class="form-control"></div>
                        </div>
                        <div>
                            Mile Used :<br /><div style="display:flex"><input type="number" id="txtTimeUsed" class="form-control"></div>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                        <b>Target:</b>
                        <div>
                            At Yard Date:<br /><div style="display:flex"><input type="date" id="txtTargetYardDate" class="form-control"></div>
                        </div>
                        <div>
                            At Yard Time :<br /><div style="display:flex"><input type="text" id="txtTargetYardTime" class="form-control"></div>
                        </div>
                        <div>
                            Unload Date :<br /><div style="display:flex"><input type="date" id="txtUnloadDate" class="form-control"></div>
                        </div>
                        <div>
                            Unload Time :<br /><div style="display:flex"><input type="text" id="txtUnloadTime" class="form-control"></div>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                        <b>Actual:</b>
                        <div>
                            At Yard Date :<br /><div style="display:flex"><input type="date" id="txtActualYardDate" class="form-control"></div>
                        </div>
                        <div>
                            At Yard Time :<br /><div style="display:flex"><input type="text" id="txtActualYardTime" class="form-control"></div>
                        </div>
                        <div>
                            Unload Date :<br /><div style="display:flex"><input type="date" id="txtUnloadFinishDate" class="form-control"></div>
                        </div>
                        <div>
                            Unload Time :<br /><div style="display:flex"><input type="text" id="txtUnloadFinishTime" class="form-control"></div>
                        </div>
                    </div>
                </div>
                Delivery No:
                <div style="display:flex;">
                    <div style="display:flex"><input type="text" id="txtDeliveryNo" class="form-control" disabled></div>
                    <input type="button" id="btnGenDeliveryNo" onclick="GenerateDO()" class="btn btn-warning" value="Create" />
                </div>
            </div>
            <div class="modal-footer">
                <div style="float:left">
                    <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="ClearDetail()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>New Container</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnUpdateDetail" onclick="SaveDetail()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save Container</b>
                    </a>
                    <a href="#" class="btn btn-danger" id="btnDeleteDetail" onclick="DeleteDetail()">
                        <i class="fa fa-lg fa-trash"></i>&nbsp;<b>Delete Container</b>
                    </a>
                </div>
                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    //define letiables
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    let row = {};
    let isjobmode = false;
    SetLOVs();
    SetEvents();
    function AddDetail() {
        ClearDetail();
        $('#dvContainer').modal('show');
    }
    function SetEvents() {
        let branch = getQueryString("BranchCode");
        let job = getQueryString("JNo");
        if (branch !== '') {
            $('#txtBranchCode').val(branch);
            ShowBranch(path, branch, '#txtBranchName');
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
        if (job !== '') {
            isjobmode = true;
            $('#txtJNo').val(job);
            CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtJNo').val(), ReadJobFull);
        }
        $('#txtBookingNo').keydown(function (ev) {
            if (ev.which == 13) {
                LoadData();
            }
        });
    }
    function loadRoute() {
        $.get(path + 'JobOrder/GetTransportRoute', function (r) {
            if (r.transportroute.data !== undefined) {
                let dr = r.transportroute.data;
                $('#cboLocation').empty();
                $('#txtLocation').empty();
                $('#cboLocation').append($('<option>', { value: '0' })
                    .text('New'));
                $('#txtLocation').append($('<option>', { value: '' })
                    .text('N/A'));
                if (dr.length > 0) {
                    for (let i = 0; i < dr.length; i++) {
                        $('#cboLocation').append($('<option>', { value: dr[i].LocationID })
                            .text(dr[i].LocationRoute));
                        $('#txtLocation').append($('<option>', { value: dr[i].LocationRoute })
                            .text(dr[i].LocationRoute));

                    }
                }
            }
        });
    }
    function SetLOVs() {
        loadUnit('#txtCTN_SIZE', path, '?Type=1');
        loadRoute();
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv,'#frmSearchCust', '#tbCust','Customers',response,3);
            //Agent
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchServ', '#tbServ', 'Service Code', response, 2);
            //Units
            CreateLOV(dv, '#frmSearchUnitS', '#tbUnitS', 'Commodity Unit', response, 2);
            CreateLOV(dv, '#frmSearchUnitC', '#tbUnitC', 'Car Unit', response, 2);
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job', response, 3);
            //Booking
            CreateLOV(dv, '#frmSearchBook', '#tbBook', 'Booking', response, 4);
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'customer':
                SetGridCompanyByGroup(path, '#tbCust', 'NOTIFY_PARTY', '#frmSearchCust', ReadCustomer);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch','#frmSearchBranch', ReadBranch);
                break;
            case 'job':
                SetGridJob(path, '#tbJob', '#frmSearchJob', '?branch=' + $('#txtBranchCode').val(), ReadJobFull);
                break;
            case 'servunit':
                SetGridServUnitFilter(path, '#tbUnitS', '?Type=0', '#frmSearchUnitS', ReadUnit);
                break;
            case 'carunit':
                SetGridServUnitFilter(path, '#tbUnitC', '?Type=2', '#frmSearchUnitC', ReadCarUnit);
                break;
            case 'booking':
                let w = '?Branch=' + $('#txtBranchCode').val();
                SetGridTransport(path, '#tbBook', '#frmSearchBook', w, ReadBooking);
                break;
            case 'servicecode':
                SetGridSICode(path, '#tbServ', '', '#frmSearchServ', ReadService);
                break;
        }
    }
    function ReadService(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameThai);
        $('#txtChargeAmount').val(CDbl(dt.StdPrice,2));
        $('#txtCostAmount').val(CDbl(dt.StdPrice, 2));
        LoadExpense();
    }
    function ReadVender(dt) {
        $('#txtVenderCode').val(dt.VenCode);
        $('#txtVenderName').val(dt.TName);
    }
    function ReadCustomer(dt) {
        $('#txtNotifyCode').val(dt.CustCode);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtNotifyName');
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadJobFull(dr) {
        $('#txtJNo').val(dr.JNo);
        $('#txtVenderCode').val(dr.AgentCode);
        ShowVender(path, dr.VenderCode, '#txtVenderName');
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtNotifyCode').val(dr.CustCode);
        ShowCompany(path, dr.CustCode, '#txtNotifyName');
        $('#txtContactName').val(dr.CustContactName);

        $('#txtProductDesc').val(dr.InvProduct);
        $('#txtProductQty').val('0.00');
        $('#txtProductUnit').val(dr.InvProductUnit);
        $('#txtGrossWeight').val(dr.TotalGW);
        $('#txtMeasurement').val(dr.Measurement);
    }
    function ReadBooking(dr, loadcont = true) {
        $('#txtBranchCode').val(dr.BranchCode);
        ShowBranch(path, dr.BranchCode, '#txtBranchName');
        $('#txtJNo').val(dr.JNo);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtVenderCode').val(dr.VenderCode);
        ShowVender(path, dr.VenderCode, '#txtVenderName');
        $('#txtContactName').val(dr.ContactName);
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtRemark').val(dr.Remark);
        $('#txtPackingPlace').val(dr.PackingPlace);
        $('#txtCYPlace').val(dr.CYPlace);
        $('#txtFactoryPlace').val(dr.FactoryPlace);
        $('#txtReturnPlace').val(dr.ReturnPlace);
        $('#txtPackingDate').val(CDateEN(dr.PackingDate));
        $('#txtCYDate').val(CDateEN(dr.CYDate));
        $('#txtFactoryDate').val(CDateEN(dr.FactoryDate));
        $('#txtReturnDate').val(CDateEN(dr.ReturnDate));
        $('#txtPackingTime').val(ShowTime(dr.PackingTime));
        $('#txtCYTime').val(ShowTime(dr.CYTime));
        $('#txtFactoryTime').val(ShowTime(dr.FactoryTime));
        $('#txtReturnTime').val(ShowTime(dr.ReturnTime));
        $('#txtNotifyCode').val(dr.NotifyCode);
        ShowCompany(path, dr.NotifyCode, '#txtNotifyName');
        $('#txtTransMode').val(dr.TransMode);
        $('#txtPaymentCondition').val(dr.PaymentCondition);
        $('#txtPaymentBy').val(dr.PaymentBy);
        if (loadcont == true) {
            LoadDetail(dr.BranchCode, dr.BookingNo);
        }
    }
    function LoadDetail(code,doc) {
        $('#tbDetail').DataTable().clear().draw();
        $.get(path + 'joborder/gettransportdetail?Branch=' + code + '&Code=' + doc).done(function (r) {
            let dr = r.transport.detail;
            if (dr.length > 0) {
                CountContainer(dr);
                ReadContainer(dr);
            }
        });
    }
    function CountContainer(dr) {
        let countA=dr.filter(function (el) {
            return CNum(el.CauseCode) >= 1 && CNum(el.CauseCode) < 99;
        }).length;
        let countF=dr.filter(function (el) {
            return CNum(el.CauseCode) ==3;
        }).length;
        let countC = dr.filter(function (el) {
            return CNum(el.CauseCode) == 0 || CNum(el.CauseCode) == 99;
        }).length;
        $('#txtTotalTripA').val(countA);
        $('#txtTotalTripF').val(countF);
        $('#txtTotalTripC').val(countC);
    }
    function ReadContainer(dr) {
        $('#tbDetail').DataTable({
            data: dr,
            columns: [
                { data: "CTN_NO", title: "Container No" },
                { data: "CTN_SIZE", title: "Container Size" },
                { data: "SealNumber", title: "Seal" },
                { data: "TruckNO", title: "Truck No" },
                { data: "TruckType", title: "Truck.Type" },
                { data: "Location", title: "To Location" },
                {
                    data: null, title: "Unload Date",
                    render: function (data) {
                        return CDateEN(data.UnloadDate);
                    }
                },
                { data: "DeliveryNo", title: "Delivery No" }
            ],
            destroy: true,
            responsive:true
        });
        $('#tbDetail tbody').on('click', 'tr', function () {
            SetSelect('#tbDetail', this);
            row = $('#tbDetail').DataTable().row(this).data(); //read current row selected
            ClearDetail();
            ReadDetail(row);
        });
        $('#tbDetail tbody').on('dblclick', 'tr', function () {
            $('#dvContainer').modal('show');
        });
    }
    function PrintData() {
        if (row.DeliveryNo !== null) {
            window.open(path + 'JobOrder/FormDelivery?Branch=' + row.BranchCode + '&Doc=' + row.DeliveryNo, '', '');
        }
    }
    function LoadData() {
        let branch = $('#txtBranchCode').val();
        let job = $('#txtJNo').val();
        let code = $('#txtBookingNo').val();
        ClearBooking();
        $.get(path + 'joborder/gettransport?Branch='+ branch +'&Code=' + code + '&Job=' + job).done(function (r) {
            let dr = r.transport;
            if (dr.header.length > 0) {
                ReadBooking(dr.header[0],false);
                ReadContainer(dr.detail);
            }
        });
    }

    //CRUD Functions used in HTML Java Scripts
    function DeleteBooking() {
        let code = $('#txtBookingNo').val();
        let branch = $('#txtBranchCode').val();
        ShowConfirm("Do you need to Delete " + code + "?", function (ask) {
            if (ask == false) return;
            $.get(path + 'joborder/deltransportheader?branch=' + branch + '&code=' + code, function (r) {
                ShowMessage(r.transport.result);
                ClearBooking();
            });
        });
    }
    function SaveBooking() {
        let obj = {
            BranchCode:$('#txtBranchCode').val(),
            JNo:$('#txtJNo').val(),
            VenderCode:$('#txtVenderCode').val(),
            ContactName:$('#txtContactName').val(),
            BookingNo:$('#txtBookingNo').val(),
            LoadDate:CDateEN($('#txtLoadDate').val()),
            Remark:$('#txtRemark').val(),
            PackingPlace:$('#txtPackingPlace').val(),
            CYPlace:$('#txtCYPlace').val(),
            FactoryPlace:$('#txtFactoryPlace').val(),
            ReturnPlace:$('#txtReturnPlace').val(),
            PackingDate:CDateEN($('#txtPackingDate').val()),
            CYDate:CDateEN($('#txtCYDate').val()),
            FactoryDate:CDateEN($('#txtFactoryDate').val()),
            ReturnDate:CDateEN($('#txtReturnDate').val()),
            PackingTime:$('#txtPackingTime').val(),
            CYTime:$('#txtCYTime').val(),
            FactoryTime:$('#txtFactoryTime').val(),
            ReturnTime:$('#txtReturnTime').val(),
            NotifyCode:$('#txtNotifyCode').val(),
            TransMode:$('#txtTransMode').val(),
            PaymentCondition:$('#txtPaymentCondition').val(),
            PaymentBy:$('#txtPaymentBy').val()
	    };
        if (obj.BookingNo != "") {
            ShowConfirm("Do you need to Save " + obj.BookingNo + "?", function (ask) {
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetTransportHeader", "JobOrder")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtBookingNo').val(response.result.data);
                            $('#txtBookingNo').focus();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e);
                    }
                });
            });
        } else {
            ShowMessage('No data to save');
        }
    }
    function ClearBooking() {
        $('#txtJNo').val('');
        $('#txtVenderCode').val('');
        $('#txtVenderName').val('');
        $('#txtContactName').val('');
        $('#txtBookingNo').val('');
        $('#txtLoadDate').val('');
        $('#txtRemark').val('');
        $('#txtPackingPlace').val('');
        $('#txtCYPlace').val('');
        $('#txtFactoryPlace').val('');
        $('#txtReturnPlace').val('');
        $('#txtPackingDate').val('');
        $('#txtCYDate').val('');
        $('#txtFactoryDate').val('');
        $('#txtReturnDate').val('');
        $('#txtPackingTime').val('');
        $('#txtCYTime').val('');
        $('#txtFactoryTime').val('');
        $('#txtReturnTime').val('');
        $('#txtNotifyCode').val('');
        $('#txtNotifyName').val('');
        $('#txtTransMode').val('');
        $('#txtPaymentCondition').val('');
        $('#txtPaymentBy').val('');
        $('#tbDetail').DataTable().clear().draw();
        $('#txtTotalTripA').val(0);
        $('#txtTotalTripF').val(0);
        $('#txtTotalTripC').val(0);
    }
    function PrintBooking() {
        window.open(path + 'JobOrder/FormDelivery?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
    }
    function ClearDetail() {		        
        $('#txtItemNo').val('0');
        $('#txtCTN_NO').val('');
        $('#txtSealNumber').val('');
        $('#txtTruckNO').val('');
        $('#txtTruckIN').val('');
        $('#txtStart').val('');
        $('#txtFinish').val('');
        $('#txtTimeUsed').val('');
        $('#txtCauseCode').val('');
        $('#txtComment').val('');
        $('#txtTruckType').val('');
        $('#txtDriver').val('');
        $('#txtTargetYardDate').val('');
        $('#txtTargetYardTime').val('');
        $('#txtActualYardDate').val('');
        $('#txtActualYardTime').val('');
        $('#txtUnloadFinishDate').val('');
        $('#txtUnloadFinishTime').val('');
        $('#txtUnloadDate').val('');
        $('#txtUnloadTime').val('');
        $('#txtLocation').val('');
        $('#txtDeliveryNo').val('');
        $('#txtDReturnDate').val('');
        $('#txtShippingMark').val('');
        $('#txtCTN_SIZE').val('');
        if (isjobmode == false) {
            $('#txtProductDesc').val('');
            $('#txtProductQty').val('0.00');
            $('#txtProductUnit').val('');
            $('#txtGrossWeight').val('0.00');
            $('#txtMeasurement').val('0.00');
        }
    }
    function SaveDetail() {
        let obj = {			
            BranchCode:$('#txtBranchCode').val(),
            JNo:$('#txtJNo').val(),
            ItemNo:$('#txtItemNo').val(),
            CTN_NO:$('#txtCTN_NO').val(),
            SealNumber:$('#txtSealNumber').val(),
            TruckNO:$('#txtTruckNO').val(),
            TruckIN:CDateEN($('#txtTruckIN').val()),
            Start:$('#txtStart').val(),
            Finish:$('#txtFinish').val(),
            TimeUsed:$('#txtTimeUsed').val(),
            CauseCode:$('#txtCauseCode').val(),
            Comment:$('#txtComment').val(),
            TruckType:$('#txtTruckType').val(),
            Driver:$('#txtDriver').val(),
            TargetYardDate:CDateEN($('#txtTargetYardDate').val()),
            TargetYardTime:$('#txtTargetYardTime').val(),
            ActualYardDate:CDateEN($('#txtActualYardDate').val()),
            ActualYardTime:$('#txtActualYardTime').val(),
            UnloadFinishDate:CDateEN($('#txtUnloadFinishDate').val()),
            UnloadFinishTime:$('#txtUnloadFinishTime').val(),
            UnloadDate:CDateEN($('#txtUnloadDate').val()),
            UnloadTime:$('#txtUnloadTime').val(),
            Location:$('#txtLocation').val(),
            ReturnDate:CDateEN($('#txtDReturnDate').val()),
            ShippingMark:$('#txtShippingMark').val(),
            ProductDesc:$('#txtProductDesc').val(),
            CTN_SIZE:$('#txtCTN_SIZE').val(),
            ProductQty:CNum($('#txtProductQty').val()),
            ProductUnit:$('#txtProductUnit').val(),
            GrossWeight:CNum($('#txtGrossWeight').val()),
            Measurement:CNum($('#txtMeasurement').val()),
            BookingNo: $('#txtBookingNo').val(),
            DeliveryNo: $('#txtDeliveryNo').val()
        };
        if (obj.ItemNo != "") {
            ShowConfirm("Do you need to Save " + obj.ItemNo + "?", function (ask) {
                if (ask == false) return;
                row = obj;
                let jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetTransportDetail", "JobOrder")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtItemNo').val(response.result.data);
                            $('#txtItemNo').focus();
                            LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e);
                    }
                });
            });
        } else {
            ShowMessage('No data to save');
        }
    }
    function ReadDetail(dr){		
        $('#txtItemNo').val(dr.ItemNo);
        $('#txtCTN_NO').val(dr.CTN_NO);
        $('#txtSealNumber').val(dr.SealNumber);
        $('#txtTruckNO').val(dr.TruckNO);
        $('#txtTruckIN').val(CDateEN(dr.TruckIN));
        $('#txtStart').val(ShowTime(dr.Start));
        $('#txtFinish').val(ShowTime(dr.Finish));
        $('#txtTimeUsed').val(dr.TimeUsed);
        $('#txtCauseCode').val(dr.CauseCode);
        $('#txtComment').val(dr.Comment);
        $('#txtTruckType').val(dr.TruckType);
        $('#txtDriver').val(dr.Driver);
        $('#txtTargetYardDate').val(CDateEN(dr.TargetYardDate));
        $('#txtTargetYardTime').val(ShowTime(dr.TargetYardTime));
        $('#txtActualYardDate').val(CDateEN(dr.ActualYardDate));
        $('#txtActualYardTime').val(ShowTime(dr.ActualYardTime));
        $('#txtUnloadFinishDate').val(CDateEN(dr.UnloadFinishDate));
        $('#txtUnloadFinishTime').val(ShowTime(dr.UnloadFinishTime));
        $('#txtUnloadDate').val(CDateEN(dr.UnloadDate));
        $('#txtUnloadTime').val(ShowTime(dr.UnloadTime));
        $('#txtLocation').val(dr.Location);
        $('#txtDeliveryNo').val(dr.DeliveryNo);
        $('#txtDReturnDate').val(CDateEN(dr.ReturnDate));
        $('#txtShippingMark').val(dr.ShippingMark);
        $('#txtProductDesc').val(dr.ProductDesc);
        $('#txtCTN_SIZE').val(dr.CTN_SIZE);
        $('#txtProductQty').val(dr.ProductQty);
        $('#txtProductUnit').val(dr.ProductUnit);
        $('#txtGrossWeight').val(dr.GrossWeight);
        $('#txtMeasurement').val(dr.Measurement);
    }
    function DeleteDetail() {
        let branch = $('#txtBranchCode').val();
        let code = $('#txtBookingNo').val();
        let item = $('#txtItemNo').val();
        ShowConfirm("Do you need to Delete " + item + "?", function (ask) {
            if (ask == false) return;
            $.get(path + 'joborder/deltransportdetail?branch=' + branch + '&code=' + code + '&item=' + item, function (r) {
                LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
                $('#dvContainer').modal('hide');
                ShowMessage(r.transport.result);
            });
        });
    }
    function ReadUnit(dr) {
        $('#txtProductUnit').val(dr.UnitType);
    }
    function ReadCarUnit(dr) {
        $('#txtTruckType').val(dr.UnitType);
    }
    function GenerateDO() {        
        let branch = $('#txtBranchCode').val();
        let code = $('#txtBookingNo').val();
        let item = $('#txtItemNo').val();
        $.get(path + 'JobOrder/GetNewDelivery?Branch=' + branch + '&Code=' + code + '&Item=' + item, function (r) {
            if (r.substr(0, 1) !== "[") {
                $('#txtDeliveryNo').val(r);
            }
            LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
            ShowMessage(r);
        });
    }
    function EntryExpenses() {
        if (row.ItemNo !== undefined) {
            window.open(path + 'Acc/Expense?BranchCode=' + row.BranchCode + '&BookNo=' + row.BookingNo + '&Item=' + row.ItemNo + '&Job=' + $('#txtJNo').val() + '&Vend='+$('#txtVenderCode').val() + '&Cont=' + row.CTN_NO + '&Cust=' + $('#txtNotifyCode').val(), '', '');
        }
    }
    function LoadExpense() {
        $.get(path + 'JobOrder/GetTransportPrice?Branch='+$('#txtBranchCode').val()+'&ID=' + $('#txtLocationID').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cust=' + $('#txtNotifyCode').val() + '&Code=' + $('#txtSICode').val(), function (r) {
            if (r.transportprice.data.length>0) {
                let dr = r.transportprice.data[0];
                $('#txtCostAmount').val(CDbl(dr.CostAmount,2));
                $('#txtChargeAmount').val(CDbl(dr.ChargeAmount,2));
            }
        });
    }
    function LoadLocation() {
        $.get(path + 'JobOrder/GetTransportRoute?ID=' + $('#cboLocation').val(), function (r) {
            if (r.transportroute.data !== undefined) {
                let dr = r.transportroute.data[0];
                $('#txtCYPlace').val(dr.Place1);
                $('#txtFactoryPlace').val(dr.Place2);
                $('#txtPackingPlace').val(dr.Place3);
                $('#txtReturnPlace').val(dr.Place4);
            }
        });
    }
    function GetRoute() {
        let w = '';
        if ($('#txtCYPlace').val() !== '') {
            w += (w == '' ? '': '->') + $('#txtCYPlace').val();
        }
        if ($('#txtFactoryPlace').val() !== '') {
            w += (w == '' ? '': '->') + $('#txtFactoryPlace').val();
        }
        if ($('#txtPackingPlace').val() !== '') {
            w += (w == '' ? '': '->') + $('#txtPackingPlace').val();
        }
        if ($('#txtReturnPlace').val() !== '') {
            w += (w == '' ? '' : '->') + $('#txtReturnPlace').val();
        }
        return w;
    }
    function SaveLocation() {
        if ($('#txtCYPlace').val() !== '') {
            let obj = {
                LocationID: $('#cboLocation').val(),
                Place1: $('#txtCYPlace').val(),
                Place2: $('#txtFactoryPlace').val(),
                Place3: $('#txtPackingPlace').val(),
                Place4: $('#txtReturnPlace').val(),
                LocationRoute: GetRoute(),
                IsActive: true
            };
            let jsonText = JSON.stringify({ data: obj });
            $.ajax({
                url: "@Url.Action("SetTransportRoute", "JobOrder")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        if (response.result.data >= 0) {
                            ShowMessage('Save Route Complete');
                        }
                        loadRoute();
                        return;
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e);
                }
            });
        } else {
            ShowMessage('Please enter some data');
        }
    }
    function SaveExpense() {
        if ($('#txtSICode').val() !== '') {
            let obj = {
                BranchCode: $('#txtBranchCode').val(),
                LocationID: $('#cboLocation').val(),
                VenderCode: $('#txtVenderCode').val(),
                CustCode: $('#txtNotifyCode').val(),
                SICode: $('#txtSICode').val(),
                SDescription: $('#txtSDescription').val(),
                CostAmount: CDbl($('#txtCostAmount').val(),2),
                ChargeAmount: CDbl($('#txtChargeAmount').val(), 2),
                Location: $('#txtLocationRoute').val()
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
                            ShowMessage('Save Price Complete');
                        }
                        loadRoute();
                        return;
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e);
                }
            });
        } else {
            ShowMessage('Please enter some data');
        }
    }
    function EditExpense() {
        if ($('#txtVenderCode').val() == '') {
            ShowMessage('Please Select Vender First');
            return;
        }
        if ($('#txtNotifyCode').val() == '') {
            ShowMessage('Please Select Notift Party First');
            return;
        }
        if ($('#txtBranchCode').val() == '') {
            ShowMessage('Please Select Branch First');
            return;
        }
        if ($('#cboLocation').val() > 0) {            
            $('#txtLocationID').val($('#cboLocation').val());
            $('#txtLocationRoute').val($('#cboLocation option:selected').text());

            $('#dvExpenses').modal('show');
        } else {
            ShowMessage('Please select route first!');
        }
    }
</script>