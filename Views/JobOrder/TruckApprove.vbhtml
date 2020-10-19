@Code
    ViewBag.Title = "Transport Approve"
End Code
<div class="row">
    <div class="col-sm-4">
        <label id="lblBranch">Branch</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
            <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblDateFrom">Load Date From</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateF" />
    </div>
    <div class="col-sm-3">
        <label id="lblDateTo">Load Date To:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateT" />
    </div>
    <div class="col-sm-2">
        Status
        <br />
        <select id="cboCauseCode" class="form-control dropdown">
            <option value="">ALL</option>
            <option value="N">Checking</option>
            <option value="1">Working</option>
            <option value="2">Rejected</option>
            <option value="3">Finished</option>
            <option value="99">Cancelled</option>
        </select>
    </div>
</div>
<div class="row">
    <div class="col-sm-4">
        <label id="lblVenCode">Vender :</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtVenCode" style="width:20%" />
            <button id="btnBrowseVend" class="btn btn-default" onclick="SearchData('vender')">...</button>
            <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-6">
        <label id="lblCustCode">Customer :</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" id="txtCustCode" class="form-control" style="width:130px" />
            <input type="text" id="txtCustBranch" class="form-control" style="width:70px" />
            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
            <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-2">
        Job No
        <br />
        <input type="text" class="form-control" id="txtJNo" />
    </div>
</div>
<a href="#" class="btn btn-primary" id="btnSearch" onclick="RefreshGrid()">
    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
</a>
<table id="tbDetail" class="table table-responsive">
    <thead>
        <tr>
            <th>#</th>
            <th>Job Number</th>
            <th class="desktop">Customer</th>
            <th class="desktop">Booking No</th>
            <th class="all">Container No</th>
            <th class="desktop">Container Size</th>
            <th class="desktop">Route</th>
            <th class="desktop">DeliveryDate</th>
            <th class="desktop">Status</th>
        </tr>
    </thead>
</table>
<b>Set Status Selected Container To >></b>
<div style="display:flex">
    <select id="cboStatus" class="form-control dropdown" style="width:10%">
        <option value="1">Working</option>
        <option value="2">Rejected</option>
        <option value="3">Finished</option>
        <option value="99">Cancelled</option>
    </select>
    <input type="text" id="txtListApprove" class="form-control" style="width:70%" />
    <button id="btnApprove" class="btn btn-success" onclick="ApproveData()">Approve</button>
</div>
<div class="modal fade" role="dialog" id="dvContainer">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                <div class="row">
                    <div class="col-sm-4">
                        Booking
                        <br /><div style="display:flex"><input type="text" id="txtBookingNo" class="form-control" disabled></div>
                    </div>
                    <div class="col-sm-2">
                        <label id="lblItemNo">No :</label>
                        <br /><div style="display:flex"><input type="text" id="txtItemNo" class="form-control" disabled></div>
                    </div>
                    <div class="col-sm-3">
                        Vender
                        <br /><div style="display:flex"><input type="text" id="txtVenderCode" class="form-control" disabled></div>
                    </div>
                    <div class="col-sm-3">
                        Customer
                        <br /><div style="display:flex"><input type="text" id="txtNotifyCode" class="form-control" disabled></div>
                    </div>
                </div>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblContNo">Container :</label>
                        <br /><div style="display:flex"><input type="text" id="txtCTN_NO" class="form-control"></div>
                    </div>
                    <div class="col-sm-4">
                        <label id="lblContSize">Size :</label>
                        <br /><div style="display:flex"><select id="txtCTN_SIZE" class="form-control dropdown"></select></div>
                    </div>
                    <div class="col-sm-4">
                        <label id="lblSealNo">Seal No.:</label>
                        <br /><div style="display:flex"><input type="text" id="txtSealNumber" class="form-control"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-5">
                                <label id="lblDriver">Driver :</label>
                                <br /><div style="display:flex"><input type="text" id="txtDriver" class="form-control"></div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblTruckNo">Truck ID :</label>
                                <br /><div style="display:flex"><input type="text" id="txtTruckNO" class="form-control"></div>
                            </div>
                            <div class="col-sm-4">
                                <label id="lblTruckType">Type :</label>
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtTruckType" class="form-control" disabled>
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('carunit')" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblRouteID">Route ID:</label>
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtRouteID" class="form-control" disabled />
                                    <input type="button" class="btn btn-default" value="..." id="btnBrowseLoc" onclick="SearchData('route')" />
                                </div>
                            </div>
                            <div class="col-sm-9">
                                <label id="lblLocation">Location :</label>
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtLocation" class="form-control" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblComment">Comment :</label>
                                <br /><div style="display:flex"><textarea id="txtComment" class="form-control"></textarea></div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblShippingMark">Shipping Mark :</label>
                                <br /><div style="display:flex"><textarea id="txtShippingMark" class="form-control" disabled></textarea></div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblStatus">Job Status:</label>
                                <br />
                                <div style="display:flex">
                                    <select id="txtCauseCode" class="form-control dropdown">
                                        <option value="">Checking</option>
                                        <option value="1">Working</option>
                                        <option value="2">Rejected</option>
                                        <option value="3">Finished</option>
                                        <option value="99">Cancelled</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                Job No:
                                <br/>
                                <input type="text" id="txtJobNo" class="form-control" disabled />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblExpCon">Expense Can Billing On This Route</label>
                        :<br />
                        <table id="tbExpense" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>SICode</th>
                                    <th>SDescription</th>
                                    <th>CostAmount</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <label id="lblVenBill" onclick="ShowPayment()">Expense Billed By Vender</label>
                        :<br />
                        <table id="tbPayment" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>DocNo</th>
                                    <th>DocDate</th>
                                    <th>PoNo</th>
                                    <th>WND Tax</th>
                                    <th>TotalNet</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                        <input type="checkbox" id="chkPickup" />
                        <label id="lblPickup">Pick-up:</label>
                        <div style="display:flex;flex-direction:row">
                            <div style="flex:1">
                                <div style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                                    <div>
                                        At<br />
                                        <div style="display:flex">
                                            <input type="text" id="txtPlaceName1" />
                                        </div>
                                    </div>
                                    <div>
                                        Address
                                        <textarea id="txtPlaceAddress1"></textarea>
                                    </div>
                                    <div>
                                        Contact
                                        <input type="text" id="txtPlaceContact1" />
                                    </div>
                                </div>
                            </div>
                            <div style="flex:1">
                                <div style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                                    <div>
                                        <label id="lblPickupTarget">Target Date :</label>
                                        <br />
                                        <div style="display:flex"><input type="date" id="txtTargetYardDate" class="form-control" disabled></div>
                                    </div>
                                    <div>
                                        <label id="lblPickupTargetTime"></label>
                                        <br />
                                        <div style="display:flex"><input type="text" id="txtTargetYardTime" class="form-control" disabled></div>

                                    </div>
                                    <div>
                                        <label id="lblPickupActual">Actual Date :</label>
                                        <br />
                                        <div style="display:flex"><input type="date" id="txtActualYardDate" class="form-control"></div>
                                    </div>
                                    <div>
                                        <label id="lblPickupActualTime">Actual Time :</label>
                                        <br />
                                        <div style="display:flex"><input type="text" id="txtActualYardTime" class="form-control"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                        <input type="checkbox" id="chkDelivery" /><label id="lblDelivery">Delivery:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <div style="flex:1">
                                <div style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                                    <div>
                                        At<br />
                                        <div style="display:flex">
                                            <input type="text" id="txtPlaceName2" />
                                        </div>

                                    </div>
                                    <div>
                                        Address
                                        <textarea id="txtPlaceAddress2"></textarea>
                                    </div>
                                    <div>
                                        Contact
                                        <input type="text" id="txtPlaceContact2" />
                                    </div>
                                </div>
                            </div>
                            <div style="flex:1">
                                <div style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                                    <div>
                                        <label id="lblDeliveryTarget">Target Date :</label>
                                        <br /><div style="display:flex"><input type="date" id="txtUnloadDate" class="form-control" disabled></div>
                                    </div>
                                    <div>
                                        <label id="lblDeliveryTargetTime">Target Time :</label>
                                        <br /><div style="display:flex"><input type="text" id="txtUnloadTime" class="form-control" disabled></div>
                                    </div>
                                    <div>
                                        <label id="lblDeliveryActual">Actual Date :</label>
                                        <br /><div style="display:flex"><input type="date" id="txtUnloadFinishDate" class="form-control"></div>
                                    </div>
                                    <div>
                                        <label id="lblDeliveryActualTime">Actual Time :</label>
                                        <br /><div style="display:flex"><input type="text" id="txtUnloadFinishTime" class="form-control"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                        <input type="checkbox" id="chkReturn" /><label id="lblReturn">Return:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <div style="flex:1">
                                <div style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                                    <div>
                                        At<br />
                                        <div style="display:flex">
                                            <input type="text" id="txtPlaceName3" />
                                        </div>
                                    </div>
                                    <div>
                                        Address
                                        <textarea id="txtPlaceAddress3"></textarea>
                                    </div>
                                    <div>
                                        Contact
                                        <input type="text" id="txtPlaceContact3" />
                                    </div>
                                </div>
                            </div>
                            <div style="flex:1">
                                <div style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                                    <div>
                                        <label id="lblReturnTarget">Target Date:</label>
                                        <br />
                                        <div style="display:flex"><input type="date" id="txtTruckIN" class="form-control" disabled></div>
                                    </div>
                                    <div>
                                        <label id="lblReturnTargetTime">Target Time:</label>
                                        <br />
                                        <div style="display:flex"><input type="text" id="txtStart" class="form-control" disabled></div>
                                    </div>
                                    <div>
                                        <label id="lblReturnActual">Actual Date:</label>
                                        <br />
                                        <div style="display:flex"><input type="date" id="txtDReturnDate" class="form-control"></div>
                                    </div>
                                    <div>
                                        <label id="lblReturnActualTime">Actual Time:</label>
                                        <br />
                                        <div style="display:flex"><input type="text" id="txtFinish" class="form-control"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#" class="btn btn-success" id="btnUpdateDetail" onclick="SaveDetail()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Container</b>
                </a>
                <a href="#" class="btn btn-primary" id="btnExpense" onclick="EntryExpenses()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkExp">Entry Expenses</b>
                </a>
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var userGroup = '@ViewBag.UserGroup';
    var user = '@ViewBag.User';
    var arr = [];
    var row = {};
    SetEvents();
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocDateF').val(GetFirstDayOfMonth());
        $('#txtDocDateT').val(GetLastDayOfMonth());
        if (userGroup == 'S') {
            $('#txtTargetYardDate').removeAttr('disabled');
            $('#txtTargetYardTime').removeAttr('disabled');
            $('#txtUnloadDate').removeAttr('disabled');
            $('#txtUnloadTime').removeAttr('disabled');
            $('#txtTruckIN').removeAttr('disabled');
            $('#txtStart').removeAttr('disabled');
        }
        if (userGroup == 'V') {
            $('#txtVenCode').attr('disabled', 'disabled');
            $('#txtVenName').attr('disabled', 'disabled');
            $('#btnBrowseVend').attr('disabled', 'disabled');
            $('#btnBrowseLoc').attr('disabled', 'disabled');
            $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
                if (r.vender.data.length > 0) {
                    let dr = r.vender.data[0];
                    $('#txtVenCode').val(dr.VenCode);
                    $('#txtVenName').val(dr.TName);
                }
            });
        }
        if (userGroup == 'C') {
            $('#txtCustCode').attr('disabled', 'disabled');
            $('#txtCustBranch').attr('disabled', 'disabled');
            $('#txtCustName').attr('disabled', 'disabled');
            $('#btnBrowseCust').attr('disabled', 'disabled');
            $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
                if (r.company.data.length > 0) {
                    let dr = r.company.data[0];
                    $('#txtCustCode').val(dr.CustCode);
                    $('#txtCustBranch').val(dr.Branch);
                    $('#txtCustName').val(dr.NameThai);
                }
            });
        }
        loadUnit('#txtCTN_SIZE', path, '?Type=1');
        //Events
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtCustBranch').focusout(function (event) {
            if (true) {
                $('#txtCustName').val('');
                ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
            }
        });
        $('#chkPickup').on('click',function () {
            if (this.checked) {
                $('#txtCauseCode').val('1');
                $('#txtActualYardDate').val(GetToday());
            } else {
                $('#txtActualYardDate').val('');
            }
        });
        $('#chkDelivery').on('click',function () {
            if (this.checked) {
                $('#txtCauseCode').val('3');
                $('#txtUnloadFinishDate').val(GetToday());
            } else {
                $('#txtUnloadFinishDate').val('');
            }
        });
        $('#chkReturn').on('click',function () {
            if (this.checked) {
                $('#txtCauseCode').val('3');
                $('#txtDReturnDate').val(GetToday());
            } else {
                $('#txtDReturnDate').val('');
            }
        });
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 3);
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchRoute', '#tbRoute', 'Transport Route', response, 2);
            CreateLOV(dv, '#frmSearchUnitC', '#tbUnitC', 'Car Unit', response, 2);
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'customer':
                if (userGroup == 'V') {
                    SetGridCompanyByVender(path, '#tbCust', $('#txtVenCode').val(), '#frmSearchCust', ReadCustomer);
                } else {
                    SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                }
                break;
            case 'carunit':
                SetGridServUnitFilter(path, '#tbUnitC', '?Type=2', '#frmSearchUnitC', ReadCarUnit);
                break;
            case 'route':
                SetGridTransportRoute(path, '#tbRoute', '#frmSearchRoute', ReadRoute);
                break;
        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        ShowVender(path, dt.VenCode, '#txtVenName');
    }
    function ReadCarUnit(dr) {
        $('#txtTruckType').val(dr.UnitType);
    }
    function ReadRoute(dt) {
        $('#txtRouteID').val(dt.LocationID);
        $('#txtLocation').val(dt.LocationRoute);
    }
    function RefreshGrid() {
        $('#tbDetail').hide();
        arr = [];
        ShowSummary();
        let w = '?Branch=' + $('#txtBranchCode').val();
        if ($('#txtJNo').val() !== '') {
            w = w + '&Job=' + $('#txtJNo').val();
        }
        if ($('#cboCauseCode').val() !== "") {
            w = w + '&Status=' + $('#cboCauseCode').val();
        }
        if ($('#txtVenCode').val() !== "") {
            w = w + '&Vend=' + $('#txtVenCode').val();
        }
        if ($('#txtDocDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        if ($('#txtCustCode').val() !== "") {
            w = w + '&Cust=' + $('#txtCustCode').val();
        }
        $.get(path + 'joborder/gettransportdetail'+w).done(function (r) {
            let dr = r.transport.detail;
            if (dr.length > 0) {
                ReadContainer(dr);
            }
        });
    }
    function ReadContainer(dr) {
        let d = dr;
        sortData(d, 'JNo', 'asc');
        $('#tbDetail').DataTable({
            data: d,
            columns: [
                {
                    data: null, title: "$",
                    render: function (data) {
                        return '<button class="btn btn-warning">Edit</button>'
                    }
                },
                { data: "JNo", title: "Job Number"},
                { data: "NotifyCode", title: "Customer" },
                { data: "BookingNo", title: "Booking" },
                { data: "CTN_NO", title: "Container No" },
                { data: "CTN_SIZE", title: "Container Size" },
                { data: "Location", title: "Route" },
                {
                    data: null, title: "Delivery",
                    render: function (data) {
                        return CDateEN(data.UnloadFinishDate);
                    }
                },
                {
                    data: "CauseCode", title: "Status",
                    render: function (data) {
                        switch (data) {
                            case '1':
                                return 'Working';
                                break;
                            case '2':
                                return 'Reject';
                                break;
                            case '3':
                                return 'Finished';
                                break;
                            case '99':
                                return 'Cancel';
                                break;
                            default:
                                return 'Checking';
                                break;
                        }
                    }
                }
            ],
            destroy: true,
            responsive:true
        });
        $('#tbDetail tbody').on('click', 'tr', function () {
            row = $('#tbDetail').DataTable().row(this).data();
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                let idx = arr.indexOf(row);
                if (idx < 0) {
                    return;
                }
                arr.splice(idx, 1);
                ShowSummary();
            } else {
                $(this).addClass('selected');
                if (arr.indexOf(row) < 0) {
                    arr.push(row);
                }
                ShowSummary();
            }
        });
        $('#tbDetail tbody').on('click', 'button', function () {
            row = GetSelect('#tbDetail', this);
            ReadDetail(row);
            if ($(this).hasClass('selected')) {
            } else {
                $(this).addClass('selected');
            }
            if (arr.indexOf(row) < 0) {
                arr.push(row);
            }
            ShowExpense();
            ShowPayment();
            ShowSummary();
            $('#dvContainer').modal('show');
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail').show();
    }
    function ReadDetail(dr) {
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtItemNo').val(dr.ItemNo);
        $('#txtJobNo').val(dr.JNo);
        $('#txtNotifyCode').val(dr.NotifyCode);
        $('#txtVenderCode').val(dr.VenderCode);
        $('#txtCTN_NO').val(dr.CTN_NO);
        $('#txtSealNumber').val(dr.SealNumber);
        $('#txtTruckNO').val(dr.TruckNO);
        $('#txtTruckIN').val(CDateEN(dr.TruckIN));
        $('#txtStart').val(ShowTime(dr.Start));
        $('#txtFinish').val(ShowTime(dr.Finish));
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
        $('#txtRouteID').val(dr.LocationID);
        $('#txtDReturnDate').val(CDateEN(dr.ReturnDate));
        $('#txtShippingMark').val(dr.ShippingMark);
        $('#txtCTN_SIZE').val(dr.CTN_SIZE);
        $('#txtPlaceName1').val(dr.PlaceName1);
        $('#txtPlaceAddress1').val(dr.PlaceAddress1);
        $('#txtPlaceContact1').val(dr.PlaceContact1);
        $('#txtPlaceName2').val(dr.PlaceName2);
        $('#txtPlaceAddress2').val(dr.PlaceAddress2);
        $('#txtPlaceContact2').val(dr.PlaceContact2);
        $('#txtPlaceName3').val(dr.PlaceName3);
        $('#txtPlaceAddress3').val(dr.PlaceAddress3);
        $('#txtPlaceContact3').val(dr.PlaceContact3);
        $('#txtPlaceName4').val(dr.PlaceName4);
        $('#txtPlaceAddress4').val(dr.PlaceAddress4);
        $('#txtPlaceContact4').val(dr.PlaceContact4);
    }

    function SaveDetail() {
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            BookingNo: row.BookingNo,
            JNo: row.JNo,
            ItemNo: $('#txtItemNo').val(),
            CTN_NO: $('#txtCTN_NO').val(),
            SealNumber: $('#txtSealNumber').val(),
            TruckNO: $('#txtTruckNO').val(),
            TruckIN: CDateEN($('#txtTruckIN').val()),
            Start: $('#txtStart').val(),
            Finish: $('#txtFinish').val(),
            TimeUsed: row.TimeUsed,
            CauseCode: $('#txtCauseCode').val(),
            Comment: $('#txtComment').val(),
            TruckType: $('#txtTruckType').val(),
            Driver: $('#txtDriver').val(),
            TargetYardDate: CDateEN($('#txtTargetYardDate').val()),
            TargetYardTime: $('#txtTargetYardTime').val(),
            ActualYardDate: CDateEN($('#txtActualYardDate').val()),
            ActualYardTime: $('#txtActualYardTime').val(),
            UnloadFinishDate: CDateEN($('#txtUnloadFinishDate').val()),
            UnloadFinishTime: $('#txtUnloadFinishTime').val(),
            UnloadDate: CDateEN($('#txtUnloadDate').val()),
            UnloadTime: $('#txtUnloadTime').val(),
            Location: $('#txtLocation').val(),
            LocationID: $('#txtRouteID').val(),
            ReturnDate: CDateEN($('#txtDReturnDate').val()),
            ShippingMark: $('#txtShippingMark').val(),
            ProductDesc: row.ProductDesc,
            CTN_SIZE: $('#txtCTN_SIZE').val(),
            ProductQty: row.ProductQty,
            ProductUnit: row.ProductUnit,
            GrossWeight: row.GrossWeight,
            Measurement: row.Measurement,
            DeliveryNo: row.DeliveryNo,
            NetWeight: row.NetWeight,
            ProductPrice: row.ProductPrice,
            PlaceName1: $('#txtPlaceName1').val(),
            PlaceAddress1: $('#txtPlaceAddress1').val(),
            PlaceContact1: $('#txtPlaceContact1').val(),
            PlaceName2: $('#txtPlaceName2').val(),
            PlaceAddress2: $('#txtPlaceAddress2').val(),
            PlaceContact2: $('#txtPlaceContact2').val(),
            PlaceName3: $('#txtPlaceName3').val(),
            PlaceAddress3: $('#txtPlaceAddress3').val(),
            PlaceContact3: $('#txtPlaceContact3').val(),
            PlaceName4: $('#txtPlaceName4').val(),
            PlaceAddress4: $('#txtPlaceAddress4').val(),
            PlaceContact4: $('#txtPlaceContact4').val()
        };
        if (obj.ItemNo != "") {
            ShowConfirm('Please confirm to save', function (ask) {
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
                            RefreshGrid();
                            row = obj;
                        }
                        ShowMessage(response.result.msg);
                        //$('#dvContainer').modal('hide');
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
    function EntryExpenses() {
        if (row == null) {
            ShowMessage('Please Reload This Data', true);
            return;
        }
        if (row.CTN_NO == '') {
            ShowMessage('Please input container Number', true);
            return;
        }
        if (row.CauseCode == '2' || row.CauseCode == '3') {
            if (row.CauseCode == '3') {
                if (CStr(row.ActualYardDate) == '') {
                    ShowMessage('Please input Pickup Actual Date', true);
                    return;
                }
                if (CStr(row.UnloadFinishDate) == '') {
                    ShowMessage('Please input Delivery Actual Date', true);
                    return;
                }
                if (CStr(row.ReturnDate) == '') {
                    ShowMessage('Please input Return Actual Date', true);
                    return;
                }
            }
            //SaveDetail();
            window.open(path + 'Acc/Expense?BranchCode=' + $('#txtBranchCode').val() + '&BookNo=' + $('#txtBookingNo').val() + '&Item=' + $('#txtItemNo').val() + '&Vend=' + $('#txtVenderCode').val() +'&Job='+ $('#txtJobNo').val() + '&Cont=' + row.CTN_NO + '&Cust='+ $('#txtNotifyCode').val() + '&Route=' + row.LocationID, '', '');
        } else {
            ShowMessage('Current document status is not allow to do this', true);
        }
        return;
    }
    function ApproveData() {
        if (arr.length <= 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        let dataApp = [];
        dataApp.push(user);
        for (let i = 0; i < arr.length; i++) {
            dataApp.push(arr[i].BookingNo + '|' + arr[i].CTN_NO);
        }
        let jsonString = JSON.stringify({ data: dataApp });
        $.ajax({
            url: "@Url.Action("ApproveTransport", "JobOrder")" + "?Status=" + $('#cboStatus').val(),
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                RefreshGrid();
                ShowSummary();
                response ? ShowMessage("Approve Complete") : ShowMessage("Cannot Approve",true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
        return;
    }
    function ShowSummary() {
        let doc = '';
        for (let i = 0; i < arr.length; i++) {
            let o = arr[i];
            doc += (doc != '' ? ',' : '') + o.BookingNo;
        }
        $('#txtListApprove').val(doc);
    }
    function ShowExpense() {
        $('#tbExpense').DataTable().clear().draw();
        $.get(path + 'JobOrder/GetTransportPrice?ID=' + row.LocationID + '&Vend=' + row.VenderCode + '&Cust=' + row.NotifyCode).done((r) => {
            if (r.transportprice.data.length > 0) {
                let tb=$('#tbExpense').DataTable({
                    data: r.transportprice.data,
                    columns: [
                        { data: "SICode", title: "Cost.Cde" },
                        { data: "SDescription", title: "Cost.Desc" },
                        { data: "CostAmount", title: "Cost.Amt" }
                    ],
                    destroy: true
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbExpense');
            }
        });
    }
    function ShowPayment() {
        $('#tbPayment').DataTable().clear().draw();
        if ($('#txtCTN_NO').val() !== '') {
            $.get(path + 'Acc/GetPayment?VenCode=' + row.VenderCode + '&Ref=' + row.CTN_NO + '&Status=Y').done((r) => {
                if (r.payment.header.length > 0) {
                    let tb = $('#tbPayment').DataTable({
                        data: r.payment.header,
                        columns: [
                            { data: "DocNo", title: "Doc.No" },
                            { data: "DocDate", title: "Date" },
                            { data: "PoNo", title: "Inv.No" },
                            { data: "TotalTax", title: "WHD Tax" },
                            { data: "TotalNet", title: "Total" }
                        ],
                        destroy: true
                    });
                    ChangeLanguageGrid('@ViewBag.Module', '#tbPayment');
                    $('#tbPayment tbody').on('dblclick', 'tr', function () {
                        let rowd = $('#tbPayment').DataTable().row(this).data();
                        window.open(path + 'Acc/Expense?BranchCode=' + rowd.BranchCode + '&DocNo=' + rowd.DocNo + '&BookNo='+row.BookingNo+'&Item='+row.ItemNo+'&Route=' + $('#txtRouteID').val()+ '&Job='+ row.JNo, '', '');
                    });
                    $('#btnExpense').attr('disabled', 'disabled');
                } else {
                    $('#btnExpense').removeAttr('disabled');
                }
            });
        }
    }
</script>