﻿@Code
    ViewBag.Title = "Transport Approve"
End Code
<div class="row">
    <div class="col-sm-4">
        Branch
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
            <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
        </div>
    </div>
    <div class="col-sm-4">
        Load Date From:<br />
        <input type="date" class="form-control" id="txtDocDateF" />
    </div>
    <div class="col-sm-4">
        Load Date To:<br />
        <input type="date" class="form-control" id="txtDocDateT" />
    </div>
</div>
<div class="row">
    <div class="col-sm-4">
        Vender :
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtVenCode" style="width:20%" />
            <button id="btnBrowseVend" class="btn btn-default" onclick="SearchData('vender')">...</button>
            <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-6">
        Customer :<br />
        <div style="display:flex;flex-direction:row">
            <input type="text" id="txtCustCode" class="form-control" style="width:130px" />
            <input type="text" id="txtCustBranch" class="form-control" style="width:70px" />
            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
            <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-2">
        <br />
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="RefreshGrid()">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
        </a>
    </div>
</div>
<table id="tbDetail" class="table table-responsive">
    <thead>
        <tr>
            <th>Booking</th>
            <th>No</th>
            <th>CTN_NO</th>
            <th class="desktop">CTN_SIZE</th>
            <th class="desktop">SealNumber</th>
            <th class="all">TruckNO</th>
            <th class="desktop">Status</th>
            <th class="desktop">Location</th>
            <th class="all">UnloadDate</th>
        </tr>
    </thead>
</table>
<div class="modal fade" role="dialog" id="dvContainer">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                Edit Container Data
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-2">
                        No :<br /><div style="display:flex"><input type="text" id="txtItemNo" class="form-control" disabled></div>
                    </div>
                    <div class="col-sm-4">
                        Container :<br /><div style="display:flex"><input type="text" id="txtCTN_NO" class="form-control"></div>
                    </div>
                    <div class="col-sm-3">
                        Size :<br /><div style="display:flex"><select id="txtCTN_SIZE" class="form-control dropdown"></select></div>
                    </div>
                    <div class="col-sm-3">
                        Seal No.:<br /><div style="display:flex"><input type="text" id="txtSealNumber" class="form-control"></div>
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
                            <input type="text" id="txtTruckType" class="form-control" disabled>
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('carunit')" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        Route ID:<br />
                        <div style="display:flex">
                            <input type="text" id="txtRouteID" class="form-control" disabled />
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('route')" />
                        </div>
                    </div>
                    <div class="col-sm-9">
                        Location :<br />
                        <div style="display:flex">
                            <input type="text" id="txtLocation" class="form-control" disabled/>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        Comment :<br /><div style="display:flex"><textarea id="txtComment" class="form-control"></textarea></div>
                    </div>
                    <div class="col-sm-3">
                        Shipping Mark :<br /><div style="display:flex"><textarea id="txtShippingMark" class="form-control" disabled></textarea></div>
                    </div>
                    <div class="col-sm-3">
                        Job Status:<br />
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
                </div>
                <div class="row">
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                        <b>Pick-up:</b>
                        <div>
                            Target Date :<br />
                            <div style="display:flex"><input type="date" id="txtTargetYardDate" class="form-control" disabled></div>
                        </div>
                        <div>
                            Target Time:<br />
                            <div style="display:flex"><input type="text" id="txtTargetYardTime" class="form-control" disabled></div>

                        </div>
                        <div>
                            Actual Date :<br />
                            <div style="display:flex"><input type="date" id="txtActualYardDate" class="form-control"></div>
                        </div>
                        <div>
                            Actual Time :<br />
                            <div style="display:flex"><input type="text" id="txtActualYardTime" class="form-control"></div>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                        <b>Delivery:</b>
                        <div>
                            Target Date :<br /><div style="display:flex"><input type="date" id="txtUnloadDate" class="form-control" disabled></div>
                        </div>
                        <div>
                            Target Time :<br /><div style="display:flex"><input type="text" id="txtUnloadTime" class="form-control" disabled></div>
                        </div>
                        <div>
                            Actual Date :<br /><div style="display:flex"><input type="date" id="txtUnloadFinishDate" class="form-control"></div>
                        </div>
                        <div>
                            Actual Time :<br /><div style="display:flex"><input type="text" id="txtUnloadFinishTime" class="form-control"></div>
                        </div>
                    </div>
                    <div class="col-sm-4" style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                        <b>Return:</b>
                        <div>
                            Target Date:<br />
                            <div style="display:flex"><input type="date" id="txtTruckIN" class="form-control" disabled></div>
                        </div>
                        <div>
                            Target Time :<br />
                            <div style="display:flex"><input type="text" id="txtStart" class="form-control" disabled></div>
                        </div>
                        <div>
                            Actual Date:<br />
                            <div style="display:flex"><input type="date" id="txtDReturnDate" class="form-control"></div>
                        </div>
                        <div>
                            Actual Time:<br />
                            <div style="display:flex"><input type="text" id="txtFinish" class="form-control"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#" class="btn btn-success" id="btnUpdateDetail" onclick="SaveDetail()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save Container</b>
                </a>
                <a href="#" class="btn btn-primary" id="btnExpense" onclick="EntryExpenses()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b>Entry Expenses</b>
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
        if (userGroup == 'V') {
            $('#txtVenCode').attr('disabled', 'disabled');
            $('#txtVenName').attr('disabled', 'disabled');
            $('#btnBrowseVend').attr('disabled', 'disabled');            
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
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
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
        $('#tbDetail').DataTable().clear().draw();
        let w = '?Status=N&Branch=' + $('#txtBranchCode').val();
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
        $('#tbDetail').DataTable({
            data: dr,
            columns: [
                { data: "BookingNo", title: "Booking"},
                { data: "ItemNo", title: "#"},
                { data: "CTN_NO", title: "Container No" },
                { data: "CTN_SIZE", title: "Container Size" },
                { data: "SealNumber", title: "Seal" },
                {
                    data: null, title: "ProductDesc",
                    render: function (data) {
                        return data.ProductDesc + ' G.W =' + data.GrossWeight + ' M3=' + data.Measurement;
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
                },
                { data: "Location", title: "To Location" },
                {
                    data: null, title: "Unload Date",
                    render: function (data) {
                        return CDateEN(data.UnloadDate);
                    }
                }
            ],
            destroy: true,
            responsive:true
        });
        $('#tbDetail tbody').on('click', 'tr', function () {
            SetSelect('#tbDetail', this);        
            row = $('#tbDetail').DataTable().row(this).data();
            ReadDetail(row);
        });
        $('#tbDetail tbody').on('dblclick', 'tr', function () {
            $('#dvContainer').modal('show');
        });
    }
    function ReadDetail(dr) {	
        $('#txtItemNo').val(dr.ItemNo);
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
            DeliveryNo: row.DeliveryNo
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
                            RefreshGrid();
                        }
                        ShowMessage(response.result.msg);
                        $('#dvContainer').modal('hide');
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        } else {
            ShowMessage('No data to save',true);
        }
        }
    function EntryExpenses() {
        if ($('#txtCauseCode').val() == '2' || $('#txtCauseCode').val() == '3') {
            window.open(path + 'Acc/Expense?BranchCode=' + $('#txtBranchCode').val() + '&BookNo=' + row.BookingNo + '&Item=' + $('#txtItemNo').val() + '&Job=' + row.JNo + '&Vend=' + $('#txtVenCode').val() + '&Cont=' + $('#txtCTN_NO').val() + '&Cust=' + $('#txtCustCode').val(), '', '');
        } else {
            ShowMessage('This Container status not allow to entry Expenses', true);
        }
    }
</script>