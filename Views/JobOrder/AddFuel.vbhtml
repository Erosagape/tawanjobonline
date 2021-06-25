@Code
    ViewData("Title") = "Add Fuel"
End Code
<!-- HTML CONTROLS -->
<div id="dvForm">
    <div class="row">
        <div class="col-sm-3">
            Branch Code
            :
        </div>
        <div class="col-sm-9" style="display:flex">
            <input type="text" class="form-control" style="width:60px" id="txtBranchCode" disabled />
            <input type="button" class="btn btn-default" id="btnBrowseBranch" value="..." onclick="SearchData('branch')" />
            <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Booking No
            :
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="text" id="txtBookingNo" class="form-control" disabled>
            <input type="text" style="width:60px;" id="txtBookingItemNo" class="form-control" disabled>
            <input type="button" class="btn btn-default" id="btnBrowseJob" value="..." onclick="SearchData('booking')" />
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Job No
                    :
                </div>
                <div class="col-sm-8">
                    <input type="text" id="txtJNo" class="form-control" disabled>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Doc No
            :
        </div>
        <div class="col-sm-4" style="display:flex">
            <input type="text" id="txtDocNo" class="form-control">
            <button class="btn btn-default" onclick="SearchData('addfuel')">...</button>
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Doc Date
                    :
                </div>
                <div class="col-sm-8"><input type="date" id="txtDocDate" class="form-control"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Car License
            :
        </div>
        <div class="col-sm-4">
            <input type="text" id="txtCarLicense" class="form-control">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Driver
                    :
                </div>
                <div class="col-sm-8">
                    <input type="text" id="txtDriver" class="form-control">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Fuel Type
            :
        </div>
        <div class="col-sm-4">
            <select id="txtFuelType" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Station Code
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
            Payment Type
            :
        </div>
        <div class="col-sm-4">
            <select id="txtPaymentType" class="form-control dropdown">
            </select>
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Station InvNo
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
            Mile Begin
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtMileBegin" class="form-control" value="0.00" onchange="CalculateMile()">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Mile End
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtMileEnd" class="form-control" value="0.00" onchange="CalculateMile()"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Mile Total
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtMileTotal" class="form-control" value="0.00">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Budget Volume
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtBudgetVolume" class="form-control" value="0.00"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Budget Value
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtBudgetValue" class="form-control" value="0.00">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Actual Volume
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtActualVolume" class="form-control" value="0.00" onchange="CalculateTotal()"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Unit Price
            :
        </div>
        <div class="col-sm-4">
            <input type="number" id="txtUnitPrice" class="form-control" value="0.00" onchange="CalculateTotal()">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Total Amount
                    :
                </div>
                <div class="col-sm-8"><input type="number" id="txtTotalAmount" class="form-control" value="0.00"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Remark
            :
        </div>
        <div class="col-sm-4">
            <input type="text" id="txtRemark" class="form-control">
        </div>
        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    Total Weight
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
                    Create By
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtCreateBy" class="form-control" disabled></div>
            </div>

            <div class="row">
                <div class="col-sm-5">
                    Create Date
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtCreateDate" class="form-control" disabled></div>
            </div>
        </div>

        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    Update By
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtUpdateBy" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    Last Update
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtLastUpdate" class="form-control" disabled></div>
            </div>

        </div>
        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    <input type="checkbox" id="chkApprove" onclick="ApproveData()" /> Approve By
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtApproveBy" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    Approve Date
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtApproveDate" class="form-control" disabled></div>
            </div>

        </div>
        <div class="col-sm-3">
            <div class="row">
                <div class="col-sm-5">
                    <input type="checkbox" id="chkCancel" onclick="CancelData()" /> Cancel By
                    :
                </div>
                <div class="col-sm-7"><input type="text" id="txtCancelBy" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    Cancel Date
                    :
                </div>
                <div class="col-sm-7"><input type="date" id="txtCancelDate" class="form-control" disabled></div>
            </div>
            <div class="row">
                <div class="col-sm-5">
                    Cancel Reason
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
    <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('branch')">
        <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
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
                ClearData();
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
	function ReadData(dr){
        $('#txtBranchCode').val(dr.BranchCode);
        $('#txtDocNo').val(dr.DocNo);
        $('#txtDocDate').val(CDateEN(dr.DocDate));
        $('#txtCarLicense').val(dr.CarLicense);
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
                    ShowMessage(e);
                }
            });
        });
    }
	function ClearData(){
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocNo').val('');
        $('#txtDocDate').val(GetToday());
        $('#txtCarLicense').val('');
        $('#txtDriver').val('');
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
        $('#txtCreateBy').val(user);
        $('#txtCreateDate').val(GetToday());
        $('#txtUpdateBy').val(user);
        $('#txtLastUpdate').val(GetToday());
        $('#txtApproveBy').val('');
        $('#txtApproveDate').val('');
        $('#txtCancelBy').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelReason').val('');
        $('#txtBookingNo').val('');
        $('#txtBookingItemNo').val('');
        $('#txtJNo').val('');

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
                alert("You can't re-open this document");
                $('#chkCancel').prop('checked', true);
            }
        } else {
            if ($('#txtCancelBy').val() == '' && $('#txtApproveBy').val() == '') {
                if ($('#txtCancelReason').val() == '') {
                    alert('You must provide reason of cancelling this document');
                    $('#chkCancel').prop('checked', false);
                    return;
                }
                $('#txtCancelDate').val(GetToday());
                $('#txtCancelBy').val(user);
            } else {
                alert("You can't cancel this document");
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
                alert("You can't edit approved document");
                $('#chkApprove').prop('checked', true);
            }
        } else {
            if ($('#txtCancelBy').val() == '' && $('#txtApproveBy').val() == '') {
                $('#txtApproveDate').val(GetToday());
                $('#txtApproveBy').val(user);
            } else {
                alert("You can't approve this document");
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
</script>
