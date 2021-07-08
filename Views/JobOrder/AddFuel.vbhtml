@Code
    ViewData("Title") = "Add Fuel"
End Code
<!-- HTML CONTROLS -->
<div id="dvForm">
    <div class="row">
        <div class="col-sm-3">
            <label id="lblBranchCode">Branch Code</label>
            :
        </div>
        <div class="col-sm-4" style="display:flex">
            <input type="text" class="form-control" style="width:60px" id="txtBranchCode" disabled />
            <input type="button" class="btn btn-default" id="btnBrowseBranch" value="..." onclick="SearchData('branch')" />
            <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblDocNo">Doc No</label>
                    :
                </div>
                <div class="col-sm-8">
                    <input type="text" id="txtDocNo" class="form-control">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblDocDate">Doc Date</label>
            :
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="date" id="txtDocDate" class="form-control">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblBookingNo">Booking No</label>
                    :

                </div>
                <div class="col-sm-8" style="display:flex;">
                    <input type="text" id="txtBookingNo" class="form-control" disabled>
                    <input type="text" style="width:60px;" id="txtBookingItemNo" class="form-control" disabled>
                    <input type="button" class="btn btn-default" id="btnBrowseBook" value="..." onclick="SearchData('booking')" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblJNo">Job No</label>
            :

        </div>
        <div class="col-sm-4">
            <input type="text" id="txtJNo" class="form-control" disabled>
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblCarLicense">Car License</label>
                    :
                </div>
                <div class="col-sm-8" style="display:flex">
                    <input type="text" id="txtCarLicense" class="form-control">
                    <input type="button" class="btn btn-default" id="btnBrowseCar" value="..." onclick="SearchData('carlicense')" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblTrailerNo">Trailer No</label>
            :
        </div>
        <div class="col-sm-4" style="display:flex">
            <input type="text" id="txtTrailerNo" class="form-control">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblDriver">Driver</label>                    
                    :
                </div>
                <div class="col-sm-8" style="display:flex;">
                    <input type="text" id="txtDriver" class="form-control">
                    <input type="button" class="btn btn-default" id="btnBrowseDriver" value="..." onclick="SearchData('driver')" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblFuelType">Fuel Type</label>            
            :
        </div>
        <div class="col-sm-4">
            <select id="txtFuelType" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblStationCode">Station Code</label>                    
                    :
                </div>
                <div class="col-sm-8">
                    <select id="txtStationCode" class="form-control dropdown"></select>
                </div>
            </div>

        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblPaymentType">Payment Type</label>            
            :
        </div>
        <div class="col-sm-4">
            <select id="txtPaymentType" class="form-control dropdown">
            </select>
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblStationInvNo">Station InvNo</label>                    
                    :
                </div>
                <div class="col-sm-8">
                    <input type="text" id="txtStationInvNo" class="form-control">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblMileBegin">Mile Begin</label>            
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtMileBegin" class="form-control" value="0.00" onchange="CalculateMile()">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblMileEnd">Mile End</label>                    
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtMileEnd" class="form-control" value="0.00" onchange="CalculateMile()"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblMileTotal">Mile Total</label>            
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtMileTotal" class="form-control" value="0.00">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblBudgetVolume">Budget Volume</label>                    
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtBudgetVolume" class="form-control" value="0.00"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblBudgetValue">Budget Value</label>            
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtBudgetValue" class="form-control" value="0.00">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblActualVolume">Actual Volume</label>                    
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtActualVolume" class="form-control" value="0.00" onchange="CalculateTotal()"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblUnitPrice">Unit Price</label>            
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtUnitPrice" class="form-control" value="0.00" onchange="CalculateTotal()">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblTotalAmount">Total Amount</label>                    
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtTotalAmount" class="form-control" value="0.00"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label id="lblRemark">Remark</label>            
            :
        </div>
        <div class="col-sm-4">
            <input type="text" id="txtRemark" class="form-control">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblTotalWeight">Total Weight</label>                    
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtTotalWeight" class="form-control" value="0.00"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblCreateBy">Create By</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtCreateBy" class="form-control" disabled></div>
            </div>

            <div class="row">
                <div class="col-sm-5">
                    <label id="lblCreateDate">Create Date</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtCreateDate" class="form-control" disabled></div>
            </div>
        </div>

        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblUpdateBy">Update By</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtUpdateBy" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblLastUpdate">Last Update</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtLastUpdate" class="form-control" disabled></div>
            </div>

        </div>
        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    <input type="checkbox" id="chkApprove" onclick="ApproveData()" /> 
                    <label id="lblApproveBy">Approve By</label>
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtApproveBy" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblApproveDate">Approve Date</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtApproveDate" class="form-control" disabled></div>
            </div>

        </div>
        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    <input type="checkbox" id="chkCancel" onclick="CancelData()" /> 
                    <label id="lblCancelBy">Cancel By</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtCancelBy" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblCancelDate">Cancel Date</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtCancelDate" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblCancelReason">Cancel Reason</label>                    
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtCancelReason" class="form-control"></div>
            </div>
        </div>
    </div>
</div>
<div id="dvCommand">
    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>New</b>
    </a>
    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save</b>
    </a>
    <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
        <i class="fa fa-lg fa-trash"></i>&nbsp;<b>Delete</b>
    </a>
    <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('addfuel')">
        <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
    </a>
    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
        <i class="fa fa-lg fa-print"></i>&nbsp;<b><label id="lblPrintQuo">Print</label></b>
    </a>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user ='@ViewBag.User';
    let userRights = '@ViewBag.UserRights';
    let branch = getQueryString("Branch");
    let booking = getQueryString("Booking");
    let item = getQueryString("Item");
    let job = getQueryString("Job");
    let code = getQueryString("Code");
    SetEvents();
    if (branch !== '' && booking !== '' && item !== '' && job!=='') {
        $('#txtJNo').val(job);
        $('#txtBookingNo').val(booking);
        $('#txtBookingItemNo').val(item);
        $.get(path + 'JobOrder/GetTransport?Branch=' + branch + '&Code=' + booking + '&Job=' + job + '&Item=' + item).done(function (r) {
            if (r.transport.detail.length > 0) {
                let d = r.transport.detail[0];
                $('#txtCarLicense').val(d.TruckNO);
                $('#txtDriver').val(d.Driver);
                $('#txtMileBegin').val(d.MileBegin);
                $('#txtMileEnd').val(d.MileEnd);
                CalculateMile();
            }
        });
    }
    if (branch !== '' && code !== '') {
        $('#txtDocNo').val(code);
        CallBackQueryAddFuel(path, code, ReadData);
    }
    function CallBackQueryAddFuel(p, code, ev) {
        $.get(p + 'JobOrder/getaddfuel?Code=' + code).done(function (r) {
            let dr = r.addfuel.data;
            if (dr.length > 0) {
                ev(dr[0]);
            } else {
                ShowMessage('Data Not Found',true);
            }
        });
    }
    function SetEvents() {
        ClearData();
        var lists = 'FUEL_PAYMENT=#txtPaymentType';
        lists += ',FUEL_TYPE=#txtFuelType';
        lists += ',FUEL_STATION=#txtStationCode';
        loadCombos(path, lists);
        $('#txtDocNo').keydown(function (event) {
            if (event.which == 13) {
                let code=$('#txtDocNo').val();
                $('#txtDocNo').val(code);
                CallBackQueryAddFuel(path, code,ReadData);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            var dv = document.getElementById("dvLOVs");
            //Fuel
            CreateLOV(dv, '#frmSearchFuel', '#tbFuel', 'Refill Fuel', response, 5);
            //Job
            CreateLOV(dv, '#frmSearchBook', '#tbBook', 'Booking', response, 4);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //Driver
            CreateLOV(dv, '#frmSearchDriver', '#tbDriver', 'Driver', response, 2);
            //CarLicense
            CreateLOV(dv, '#frmSearchCarLicense', '#tbCarLicense', 'Car License', response, 2);
        });
    }
    //CRUD Functions used in HTML Java Scripts
    function DeleteData() {
        let code = $('#txtDocNo').val();
        ShowConfirm("Do you need to Delete " + code + "?",function(ask){
            if (ask == false) return;
            $.get(path + 'JobOrder/deladdfuel?code=' + code, function (r) {
                ShowMessage(r.addfuel.result);
                ClearData();
            });
        });
    }
    function ReadData(dr) {
        ClearData();
        $('#txtBranchCode').val(dr.BranchCode);
        $('#txtDocNo').val(dr.DocNo);
        $('#txtDocDate').val(CDateEN(dr.DocDate));
        $('#txtCarLicense').val(dr.CarLicense);
        $('#txtTrailerNo').val(dr.TrailerNo);
        $('#txtDriver').val(dr.Driver);
        $('#txtFuelType').val(dr.FuelType);
        $('#txtBudgetVolume').val(dr.BudgetVolume);
        $('#txtBudgetValue').val(dr.BudgetValue);
        $('#txtActualVolume').val(dr.ActualVolume);
        $('#txtUnitPrice').val(dr.UnitPrice);
        $('#txtTotalAmount').val(dr.TotalAmount);
        $('#txtStationCode').val(dr.StationCode);
        $('#txtStationInvNo').val(dr.StationInvNo);
        $('#txtPaymentType').val(dr.PaymentType);
        $('#txtMileBegin').val(dr.MileBegin);
        $('#txtMileEnd').val(dr.MileEnd);
        $('#txtMileTotal').val(dr.MileTotal);
        $('#txtRemark').val(dr.Remark);
        $('#txtTotalWeight').val(dr.TotalWeight);
        $('#txtCreateBy').val(dr.CreateBy);
        $('#txtCreateDate').val(CDateEN(dr.CreateDate));
        $('#txtUpdateBy').val(dr.UpdateBy);
        $('#txtLastUpdate').val(CDateEN(dr.LastUpdate));
        $('#txtApproveBy').val(dr.ApproveBy);
        $('#txtApproveDate').val(CDateEN(dr.ApproveDate));
        $('#txtCancelBy').val(dr.CancelBy);
        $('#txtCancelDate').val(CDateEN(dr.CancelDate));
        $('#txtCancelReason').val(dr.CancelReason);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtBookingItemNo').val(dr.BookingItemNo);
        $('#txtJNo').val(dr.JNo);

        if ($('#txtApproveBy').val() !== '') {
            $('#chkApprove').prop('checked', true);
        }
        if ($('#txtCancelBy').val() !== '') {
            $('#chkCancel').prop('checked', true);
        }
        if ($('#txtCancelBy').val() !== '' || $('#txtApproveBy').val() !== '') {
            $('#btnSave').attr('disabled', 'disabled');
            $('#btnDelete').attr('disabled', 'disabled');
        }

	}
	function SaveData(){
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            DocNo:$('#txtDocNo').val(),
            DocDate:CDateTH($('#txtDocDate').val()),
            CarLicense:$('#txtCarLicense').val(),
            Driver:$('#txtDriver').val(),
            FuelType:$('#txtFuelType').val(),
            BudgetVolume:CNum($('#txtBudgetVolume').val()),
            BudgetValue:CNum($('#txtBudgetValue').val()),
            ActualVolume:CNum($('#txtActualVolume').val()),
            UnitPrice:CNum($('#txtUnitPrice').val()),
            TotalAmount:CNum($('#txtTotalAmount').val()),
            StationCode:$('#txtStationCode').val(),
            StationInvNo:$('#txtStationInvNo').val(),
            PaymentType:$('#txtPaymentType').val(),
            MileBegin:CNum($('#txtMileBegin').val()),
            MileEnd:CNum($('#txtMileEnd').val()),
            MileTotal:CNum($('#txtMileTotal').val()),
            Remark:$('#txtRemark').val(),
            TotalWeight:CNum($('#txtTotalWeight').val()),
            CreateBy:$('#txtCreateBy').val(),
            CreateDate:CDateTH($('#txtCreateDate').val()),
            UpdateBy:$('#txtUpdateBy').val(),
            LastUpdate:CDateTH($('#txtLastUpdate').val()),
            ApproveBy:$('#txtApproveBy').val(),
            ApproveDate:CDateTH($('#txtApproveDate').val()),
            CancelBy:$('#txtCancelBy').val(),
            CancelDate:CDateTH($('#txtCancelDate').val()),
            CancelReason:$('#txtCancelReason').val(),
            BookingNo:$('#txtBookingNo').val(),
            BookingItemNo:$('#txtBookingItemNo').val(),
            JNo: $('#txtJNo').val(),
            TrailerNo: $('#txtTrailerNo').val()
        };
        ShowConfirm("Do you need to Save " + obj.DocNo + "?",function(ask){
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetAddFuel", "JobOrder")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        $('#txtDocNo').val(response.result.data);
                        $('#txtDocNo').focus();

                        CallBackQueryAddFuel(path, $('#txtDocNo').val(), ReadData);
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        });
    }
	function ClearData(){
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocNo').val('');
        $('#txtDocDate').val(GetToday());
        $('#txtFuelType').val('');
        $('#txtBudgetVolume').val('0.00');
        $('#txtBudgetValue').val('0.00');
        $('#txtActualVolume').val('0.00');
        $('#txtUnitPrice').val('0.00');
        $('#txtTotalAmount').val('0.00');
        $('#txtStationCode').val('');
        $('#txtStationInvNo').val('');
        $('#txtPaymentType').val('');
        $('#txtMileBegin').val('0.00');
        $('#txtMileEnd').val('0.00');
        $('#txtMileTotal').val('0.00');
        $('#txtRemark').val('');
        $('#txtTotalWeight').val('0.00');
        $('#txtTrailerNo').val('');

        $('#txtCreateBy').val(user);
        $('#txtCreateDate').val(GetToday());
        $('#txtUpdateBy').val(user);
        $('#txtLastUpdate').val(GetToday());
        $('#txtApproveBy').val('');
        $('#txtApproveDate').val('');
        $('#txtCancelBy').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelReason').val('');
        if (booking == '') {
            $('#txtBookingNo').val('');
            $('#txtBookingItemNo').val('');
            $('#txtJNo').val('');
            $('#txtCarLicense').val('');
            $('#txtDriver').val('');
        }
        $('#chkApprove').prop('checked', false);
        $('#chkCancel').prop('checked', false);
        $('#btnSave').removeAttr('disabled');
        $('#btnDelete').removeAttr('disabled');
	}
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'booking':
                let w = '?Branch=' + $('#txtBranchCode').val();
                SetGridTransport(path, '#tbBook', '#frmSearchBook', w, ReadBooking);
                break;
            case 'addfuel':
                SetGridAddFuel(path, '#tbFuel', '?Branch=' + $('#txtBranchCode').val(), '#frmSearchFuel', ReadData);
                break;
            case 'driver':
                SetGridEmployee(path, '#tbDriver', '#frmSearchDriver', ReadDriver);
                break;
            case 'carlicense':
                SetGridCar(path, '#tbCarLicense', '#frmSearchCarLicense', ReadCarLicense);
                break;
        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);

    }
    function ReadBooking(dr) {
        $('#txtJNo').val(dr.JNo);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtBookingItemNo').val(dr.ItemNo);
        $('#txtCarLicense').val(dr.TruckNO);
        $('#txtDriver').val(dr.Driver);
        $('#txtMileBegin').val(dr.MileBegin);
        $('#txtMileEnd').val(dr.MileEnd);
        CalculateMile();
    }
    function ReadDriver(dt) {
        $('#txtDriver').val(dt.Name);
    }
    function ReadCarLicense(dt) {
        $('#txtCarLicense').val(dt.CarLicense);
    }
    function CancelData() {
        let state = $('#chkCancel').prop('checked');
        if (state == false) {
            if ($('#txtCancelBy').val() !== '' && user.toLowerCase() == $('#txtCancelBy').val().toLowerCase()) {
                $('#txtCancelDate').val('');
                $('#txtCancelReason').val('');
                $('#txtCancelBy').val('');
                $('#btnSave').removeAttr('disabled');
            } else {
                ShowMessage("You can't re-open this document",true);
                $('#chkCancel').prop('checked', true);
            }
        } else {
            if ($('#txtCancelBy').val() == '' && $('#txtApproveBy').val() == '') {
                if ($('#txtCancelReason').val() == '') {
                    ShowMessage('You must provide reason of cancelling this document',true);
                    $('#chkCancel').prop('checked', false);
                    return;
                }
                $('#txtCancelDate').val(GetToday());
                $('#txtCancelBy').val(user);
            } else {
                ShowMessage("You can't cancel this document",true);
                $('#chkCancel').prop('checked', false);
            }
        }
    }
    function ApproveData() {
        let state = $('#chkApprove').prop('checked');
        if (state == false) {
            if ($('#txtApproveBy').val() !== '' && user.toLowerCase() == $('#txtApproveBy').val().toLowerCase()) {
                $('#txtApproveDate').val('');
                $('#txtApproveBy').val('');
                $('#btnSave').removeAttr('disabled');
            } else {
                ShowMessage("You can't edit approved document",true);
                $('#chkApprove').prop('checked', true);
            }
        } else {
            if ($('#txtCancelBy').val() == '' && $('#txtApproveBy').val() == '') {
                $('#txtApproveDate').val(GetToday());
                $('#txtApproveBy').val(user);
            } else {
                ShowMessage("You can't approve this document",true);
                $('#chkApprove').prop('checked', false);
            }
        }
    }
    function CalculateMile() {
        var start = CNum($('#txtMileBegin').val());
        var end = CNum($('#txtMileEnd').val());
        var diff = end - start;
        $('#txtMileTotal').val(diff);
    }
    function CalculateTotal() {
        var volume = CNum($('#txtActualVolume').val());
        var price = CNum($('#txtUnitPrice').val());
        var total = volume * price;
        $('#txtTotalAmount').val(CDbl(total, 2));
    }
    function PrintData() {
        window.open(path + 'JobOrder/FormAddFuel?Branch=' + $('#txtBranchCode').val() + '&Code=' + $('#txtDocNo').val(), '', '');
    }
</script>
