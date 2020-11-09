@Code
    ViewBag.Title = "Job Confirmation"
End Code
<style>
    @@media only screen and (max-width: 600px) {
        #btnRefresh, #btnGenJob {
            width: 100%;
        }
    }
</style>
<div class="panel-body">
    <div class="row">
        <div class="col-sm-2">
            <label for="cboBranch" id="lblBranch">Branch</label>
            <select id="cboBranch" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-2">
            <label for="cboStatus" id="lblStatus">Status</label>
            <select id="cboStatus" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-2">
            <label for="cboJobType" id="lblJobType">Job Type</label>
            <select id="cboJobType" class="form-control dropdown" onchange="CheckJobType()"></select>
        </div>
        <div class="col-sm-2">
            <label for="cboShipBy" id="lblShipBy">Ship By</label>
            <select id="cboShipBy" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-1">
            <label for="cboYear" id="lblYear">Year</label>
            <select id="cboYear" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-1">
            <label for="cboMonth" id="lblMonth">Month</label>
            <select id="cboMonth" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-2">
            <br />
            <input type="checkbox" id="chkDuty" />
            <label for="chkDuty" id="lblDutyDate">By Inspection Date</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <label id="lblVenCode">Vender :</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtVenCode" style="width:20%" disabled />
                <button id="btnBrowseVend" class="btn btn-default" onclick="SearchData('vender')">...</button>
                <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
            </div>
        </div>
        <div class="col-sm-6">
            <label id="lblCustCode">Customer :</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" id="txtCustCode" class="form-control" style="width:130px" disabled />
                <input type="text" id="txtCustBranch" class="form-control" style="width:70px" disabled />
                <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <a href="#" class="btn btn-primary" id="btnRefresh" onclick="getJobdata()">
                <i class="fa fa-lg fa-filter"></i> &nbsp;<b id="linkSearch">Search</b>
            </a>
            <table id="tblJob" class="table table-responsive">
                <thead>
                    <tr>
                        <th>JobNo</th>
                        <th class="desktop">DocDate</th>
                        <th class="desktop">JobStatus</th>
                        <th class="all">InspectDate</th>
                        <th class="all">Inv.Customer</th>
                        <th class="desktop">Customer</th>
                        <th>DeclareNo</th>
                        <th class="desktop">Po/Ref</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            <label for="txtJobNo" id="lblJob">Enter Job >></label>
            <input type="text" id="txtJobNo" class="form-control" />
        </div>
        <div class="col-sm-4">
            <br />
            <div class="btn-group">
                <button id="btnJobSlip" class="btn btn-success" onclick="OpenJob()">Show</button>
                <select id="selStatus" class="dropdown">
                    <option value="1">CONFIRM</option>
                    <option value="3">CLOSE</option>
                    <option value="6">BILLING-COMPLETE</option>
                    <option value="7">PAYMENT-COMPLETE</option>
                    <option value="0">RE-OPEN</option>
                    <option value="99">CANCEL</option>
                </select>
                <a href="#" class="btn btn-primary" id="btnPrnJob" onclick="ApproveJob()">
                    Change Status
                </a>
            </div>
        </div>
        <div class="col-sm-3">
            <label id="lblQuickSearch">Quick Search</label>:
            <br />
            <select class="form-control dropdown" id="cboField">
                <option value="">{Please Select}</option>
                <option value="CustCode">Customer</option>
                <option value="CSCode">Customer Service</option>
                <option value="ManagerCode">Sales Person</option>
                <option value="ShippingCode">Shipping Staff</option>
                <option value="DeclareNo">Declaration</option>
                <option value="HAWB">House BL/AWB</option>
                <option value="MAWB">Master BL/AWB</option>
                <option value="BookingNo">Booking No</option>
                <option value="InvNo">Commercial Invoice</option>
            </select>
        </div>
        <div class="col-sm-3">
            <label id="lblCliteria">Cliteria</label>:
            <br />
            <input type="text" id="txtCliteria" class="form-control" />
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let dateWhere = 'DocDate';
    let jt = getQueryString("jobtype");
    let sb = getQueryString("shipby");
    let arr = [];
    //3 Fields Show
    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
        let dv = document.getElementById("dvLOVs");
        CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 3);
        CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
        loadCombo();
        getJobdata();
        //SetEvents();
    });
    function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
        return;
    }

    function loadCombo() {
        let lists = 'JOB_TYPE=#cboJobType|'+ jt;
        lists += ',SHIP_BY=#cboShipBy|'+sb;
        lists += ',JOB_STATUS=#cboStatus';

        loadCombos(path, lists);
        loadBranch(path);
        loadYear(path);
        loadMonth('#cboMonth');

        $('#txtJobNo').keydown(function (e) {
            if (e.which == 13) {
                if ($('#txtJobNo').val() !== '') {
                    OpenJob();
                }
            }
        });
        $('#txtCliteria').keydown(function (e) {
            if (e.which == 13) {
                getJobdata();
            }
        });
    }
    function getJobdata() {
        ShowWait();
        $.get(path + 'joborder/updatejobstatus' + GetCliteria(), function (r) {
            CloseWait();
            let tb=$('#tblJob').DataTable({
                "ajax": {
                    //"url": "joborder/getjobjson" + strParam,
                    "url": path+"joborder/getjobreport" + GetCliteria(),
                    "dataSrc": "job.data"
                },
                "destroy": true,
                "responsive": true,
                "selected":true,
                "columns": [
                    { "data": "JNo", "title": "Job Number" },
                    {
                        "data": "DocDate", "title": "Open Date",
                        "render" : function (data) {
                            return CDateEN(data);
                        }
                    },
                    {
                        "data": null, "title": "Job Status",
                        "render": function (data) {
                            return data.JobStatus;
                        }
                    },
                    {
                        "data": "DutyDate", "title": "Clearance Date",
                        "render" : function (data) {
                            return CDateEN(data);
                        }
                    },
                    { "data": "InvNo", "title": "Customer Inv." },
                    { "data": "CustTName", "title": "Customer" },
                    { "data": "DeclareNumber", "title": "Declare No." },
                    { "data": "CustRefNO", "title": "Cust.Ref" }
                ]
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tblJob');
            $('#tblJob tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected') == true) {
                    $(this).removeClass('selected');
                    let data = $('#tblJob').DataTable().row(this).data(); //read current row selected
                    RemoveData(data); //callback function from caller
                    return;
                }
                $(this).addClass('selected');
                let data = $('#tblJob').DataTable().row(this).data(); //read current row selected
                AddData(data); //callback function from caller

                $('#txtJobNo').val(data.JNo);
            });
            $('#tblJob tbody').on('dblclick', 'tr', function () {
                OpenJob();
            });
            CloseWait();
        });
    }
    function AddData(o) {
        arr.push(o);
    }
    function RemoveData(o) {
        let idx = arr.indexOf(o);
        if (idx < 0) {
            return;
        }
        arr.splice(idx, 1);
    }
    function GetCliteria() {
        let str = '';
        if ($('#chkDuty').prop('checked')) {
            dateWhere = 'DutyDate';
        }
        if ($('#cboJobType').val() > '') {
            if (str.length > 0) str += '&';
            str += 'JType=' + $('#cboJobType').val();
        }
        if ($('#cboShipBy').val() > '') {
            if (str.length > 0) str += '&';
            str += 'SBy=' + $('#cboShipBy').val();
        }
        if ($('#cboBranch').val() >= '00') {
            if (str.length > 0) str += '&';
            str += 'Branch=' + $('#cboBranch').val();
        }
        if ($('#cboYear').val() > '') {
            if (str.length > 0) str += '&';
            str += 'Year=' + $('#cboYear').val();
        }
        if ($('#cboMonth').val() > '') {
            if (str.length > 0) str += '&';
            str += 'Month=' + $('#cboMonth').val();
        }
        if ($('#cboStatus').val() > '') {
            if (str.length > 0) str += '&';
            str += 'Status=' + $('#cboStatus').val();
        }
        if ($('#cboField').val() > '') {
            if (str.length > 0) str += '&';
            str += $('#cboField').val() + '=' + $('#txtCliteria').val();
        }
        if ($('#txtCustCode').val() > '') {
            if (str.length > 0) str += '&';
            str += 'CustCode=' + $('#txtCustCode').val();
        }
        if ($('#txtVenCode').val() > '') {
            if (str.length > 0) str += '&';
            str += 'Agent=' + $('#txtVenCode').val();
        }
        return '?NoLog=Y&ByDate=' + dateWhere + '&' + str;
    }
    function OpenJob() {
        $.get(path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJobNo').val(), function (r) {
            //ShowMessage(r);
            window.open(path + 'joborder/showjob?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJobNo').val());
        });
    }
    function PrintJob() {
        window.open(path +'joborder/formjob?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJobNo').val());
    }
    function PrintPrepareForm() {
        window.open(path + 'joborder/formprepare');
    }
    function CreateNewJob() {
        window.open(path +'joborder/createjob?JType=' + $('#cboJobType').val() + '&SBy=' + $('#cboShipBy').val() + '&Branch=' + $('#cboBranch').val());
    }
    function SearchData(type) {
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
        }
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
    function ApproveJob() {
        let status = $('#selStatus').val();
        if (arr.length < 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        let dataApp = [];
        dataApp.push(user);
        for (let i = 0; i < arr.length; i++) {
            dataApp.push(arr[i].BranchCode + '|' + arr[i].JNo);
        }
        let jsonString = JSON.stringify({ data: dataApp });
        $.ajax({
            url: "@Url.Action("SetJobStatus", "JobOrder")?Status=" + status,
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                arr = [];
                getJobdata();
                response ? ShowMessage("Approve Complete") : ShowMessage("Cannot Approve");
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
        return;
    }
</script>