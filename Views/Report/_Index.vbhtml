@Code
    ViewData("Title") = "Reports"
    End Code
<style>
	 * {
        font-family: CORDIA NEW;
        font-size: 16px;
    }
</style>
    <div class="row">
        <div class="col-sm-6">
            <div style="display:flex">
                <label style="display:block;width:200px">Group Report</label>
                <select id="cboReportGroup" class="form-control dropdown" onchange="ChangeLanguageForm('@ViewBag.Module');" style="width:100%"></select>
            </div>
            <table id="tbReportList" class="table table-responsive">
                <thead>
                    <tr>
                        <th class="desktop">
                            Report Code
                        </th>
                        <th class="all">
                            Report Name
                        </th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
        <div class="col-sm-6" style="background-color:aliceblue">
            <label id="lblBranch">Branch</label>
            <br />
            <div style="display:flex">
                <input type="text" class="form-control" style="width:60px" id="txtBranchCode" disabled />
                <input type="button" class="btn btn-default" id="btnBrowseBranch" value="..." onclick="BrowseCliteria('branch')" />
                <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
            </div>
            <br />
            <b>Report Cliteria:</b><br />
            <div style="display:flex;width:100%;flex-direction:column" id="tbDate">
                <div style="display:flex;">
                    <div style="flex:1">
                        Date From
                    </div>
                    <div style="flex:2">
                        <input type="date" id="txtDateFrom" />
                    </div>
                </div>
                <div style="display:flex;">
                    <div style="flex:1">
                        Date To
                    </div>
                    <div style="flex:2">
                        <input type="date" id="txtDateTo" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCust">
                <div style="display:flex;">
                    <div style="flex:1">
                        Customer:
                    </div>
                    <div style="flex:2">
                        <textarea id="txtCustCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('cust')" value="..." />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbJob">
                <div style="display:flex;">
                    <div style="flex:1">
                        Job Number:
                    </div>
                    <div style="flex:2">
                        <textarea id="txtJobCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('job')" value="..." />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbStatus">
                <div style="display:flex;">
                    <div style="flex:1">
                        Status:
                    </div>
                    <div style="flex:2">
                        <textarea id="txtStatusCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('status')" value="..." />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbEmp">
                <div style="display:flex;">
                    <div style="flex:1">
                        Employee:
                    </div>
                    <div style="flex:2">
                        <textarea id="txtEmpCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('emp')" value="..." />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbVend">
                <div style="display:flex;">
                    <div style="flex:1">
                        Vender:
                    </div>
                    <div style="flex:2">
                        <textarea id="txtVendCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('vend')" value="..." />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCode">
                <div style="display:flex;">
                    <div style="flex:1">
                        Exp.Code:
                    </div>
                    <div style="flex:2">
                        <textarea id="txtCodeCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('code')" value="..." />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbGroup">
                <div style="display:flex;">
                    <div style="flex:1">
                        Customer Group:
                    </div>
                    <div style="flex:2">
                        <select id="cboCommLevel" class="form-control"></select>
                    </div>
                </div>
            </div>
        </div>
        <br/>
        <a href="#" class="btn btn-info" id="btnPrnJob" onclick="PrintReport()">
            <i class="fa fa-lg fa-print"><b>Print Report</b></i>
        </a>
        <div id="dvCliteria" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <label id="lblCliteria">Select Cliteria of xxx</label>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-4">
                                <select id="selCliteria" class="form-control dropdown">
                                    <option value="=">Equal</option>
                                    <option value="&gt=">Greater/Equal</option>
                                    <option value="&lt=">Less than/Equal</option>
                                    <option value="&lt&gt">Not Equal</option>
                                    <option value="Like%">Contain</option>
                                </select>
                            </div>
                            <div class="col-sm-8" style="display:flex">                                
                                <input type="text" id="txtValue" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" onclick="SearchData()" value="..." />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <select id="selOption" class="form-control dropdown">
                                    <option value="AND">AND</option>
                                    <option value="OR">OR</option>
                                </select>
                            </div>
                            <div class="col-sm-3">
                                <input type="button" class="btn btn-warning" onclick="SetData()" value="Add Clieria" />
                            </div>
                            <div class="col-sm-6">
                                <label>Your Cliteria is:</label>
                                <div id="dvSql"></div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <input type="button" class="btn btn-success" onclick="AddData()" value="Apply Cliteria" />
                        </div>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
<div id="dvLOVs"></div>
<script type="text/javascript" src="~/Scripts/Func/reports.js"></script>
<script type="text/javascript" src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let reportID = '';
    let browseWhat = '';
    let cliterias = [];
    let userPosition = '@ViewBag.UserPosition';
    let data = {};
    var path = '@Url.Content("~")';
    ChangeLanguageForm('@ViewBag.Module');
    SetEvents();
    function GetCliteria() {
        let obj = {
            branch: '[BRANCH]=' + $('#txtBranchCode').val(),
            dateFrom: ($('#txtDateFrom').val()==''?'': '[DATE]>=' + $('#txtDateFrom').val()),
            dateTo: ($('#txtDateTo').val()==''?'': '[DATE]<=' + $('#txtDateTo').val()),
            custWhere: $('#txtCustCliteria').val(),
            jobWhere: $('#txtJobCliteria').val(),
            empWhere: $('#txtEmpCliteria').val(),
            vendWhere: $('#txtVendCliteria').val(),
            statusWhere: $('#txtStatusCliteria').val(),
            codeWhere: $('#txtCodeCliteria').val(),
            groupWhere: $('#cboCommLevel').val()==''?'': '[GROUP]=' + $('#cboCommLevel').val()
        };
        let str = JSON.stringify(obj);
        return '?data=' + JSON.stringify(data) + '&cliteria=' + encodeURIComponent(str) + '&group=' + $('#cboReportGroup').val();
    }
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDateFrom').val(GetFirstDayOfMonth());
        $('#txtDateTo').val(GetLastDayOfMonth());
        var lists = "COMMERCIAL_LEVEL=#cboCommLevel";
        loadCombos(path, lists);

        $('#tbCode').hide();
        $('#tbReportList tbody').on('click', 'tr', function () {
            data = $('#tbReportList').DataTable().row(this).data();
            //if (data.ReportAuthor.indexOf(userPosition) < 0) {
                //ShowMessage("Your position are not authorized to view Report", true);
                //$('#btnPrnJob').hide();
                //return;
            //}
            $('#btnPrnJob').show();
            SetSelect('#tbReportList', this);
            reportID = data.ReportCode;
            LoadCliteria(reportID);
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchBranch', '#tblBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchCust', '#tblCust', 'Search Customers', response, 3);
            CreateLOV(dv, '#frmSearchJob', '#tblJob', 'Search Job', response, 3);
            CreateLOV(dv, '#frmSearchVend', '#tblVend', 'Search Venders', response, 2);
            CreateLOV(dv, '#frmSearchEmp', '#tblEmp', 'Search Employee', response, 2);
            CreateLOV(dv, '#frmSearchStatus', '#tblStatus', 'Search Status', response, 3);
            CreateLOV(dv, '#frmSearchCode', '#tblCode', 'Search Code', response, 2);
        });
    }
    function BrowseCliteria(what) {
        browseWhat = what;
        switch (browseWhat) {
            case 'branch':
                SearchData();
                return;
            case 'cust':
                $('#lblCliteria').text('Filter Data For Customer');
                break;
            case 'job':
                $('#lblCliteria').text('Filter Data For Job');
                break;
            case 'vend':
                $('#lblCliteria').text('Filter Data For Vender');
                break;
            case 'emp':
                $('#lblCliteria').text('Filter Data For Staff');
                break;
            case 'status':
                let type = GetReportStatus(reportID);
                if (type !== '') {
                    $('#lblCliteria').text('Filter Data For ' + type);
                }
                break;
            case 'code':
                $('#lblCliteria').text('Filter Data For Service Code');
                SearchData();
                break;
        }
        $('#dvSql').html('');
        $('#txtValue').val('');
        cliterias = [];
        $('#dvCliteria').modal('show');
    }
    function SearchData() {
        switch (browseWhat) {
            case 'branch':
                SetGridBranch(path, '#tblBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'cust':
                SetGridCompany(path, '#tblCust', '#frmSearchCust',ReadData);
                break;
            case 'job':
                SetGridJob(path, '#tblJob', '#frmSearchJob', '', ReadData);
                break;
            case 'vend':
                SetGridVender(path, '#tblVend', '#frmSearchVend', ReadData);
                break;
            case 'emp':
                SetGridUser(path, '#tblEmp', '#frmSearchEmp', ReadData);
                break;
            case 'status':
                let type = GetReportStatus(reportID);
                if (type !== '') {
                    SetGridConfigVal(path, '#tblStatus', type, '#frmSearchStatus', ReadData);
                }
                break;
            case 'code':
                SetGridSICode(path, '#tblCode', '', '#frmSearchCode', ReadData);
                break;
        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadData(dr) {
        switch (browseWhat) {
            case 'cust':
                if (reportID.substr(0, 3) == 'PRD') {
                    $('#txtValue').val(dr.TaxNumber);
                    break;
                }
                $('#txtValue').val(dr.CustCode);
                break;
            case 'job':
                $('#txtValue').val(dr.JNo);
                break;
            case 'vend':
                $('#txtValue').val(dr.VenCode);
                break;
            case 'emp':
                $('#txtValue').val(dr.UserID);
                break;
            case 'status':
                $('#txtValue').val(dr.ConfigKey);
                break;
            case 'code':
                $('#txtValue').val(dr.SICode);
        }
    }
    function SetData() {
        let str = '[' + browseWhat + ']';
        if (cliterias.length > 0 && $('#selOption').val() == "OR") {
            str = $('#selOption').val() + str;
        }
        cliterias.push(str + '' + $('#selCliteria').val() + $('#txtValue').val());
        $('#dvSql').html(cliterias.toString());
        $('#txtValue').val('');
    }
    function AddData() {
        if ($('#txtValue').val() !== '') {
            SetData();
        }
        let cliteria=$('#dvSql').html();
        switch (browseWhat) {
            case 'cust':
                $('#txtCustCliteria').val(cliteria);
                break;
            case 'job':
                $('#txtJobCliteria').val(cliteria);
                break;
            case 'vend':
                $('#txtVendCliteria').val(cliteria);
                break;
            case 'emp':
                $('#txtEmpCliteria').val(cliteria);
                break;
            case 'status':
                $('#txtStatusCliteria').val(cliteria);
                break;
            case 'code':
                $('#txtCodeCliteria').val(cliteria);
        }
        $('#dvCliteria').modal('hide');
    }
    function PrintReport() {
        if (reportID.indexOf('PRD')>=0) {
            switch (reportID) {
                case 'PRD3':
                    window.open(path +'Acc/FormWTax3' + GetCliteria(), '', '');
                    break;
                case 'PRD3D':
                    window.open(path +'Acc/FormWTax3D' + GetCliteria(), '', '');
                    break;
                case 'PRD53':
                    window.open(path +'Acc/FormWTax53' + GetCliteria(), '', '');
                    break;
                case 'PRD53D':
                    window.open(path +'Acc/FormWTax53D' + GetCliteria(), '', '');
                    break;
            }
            return;
        }
        switch (data.ReportType) {
            case 'STD':
                window.open(path + 'Report/Preview' + GetCliteria()+ '&Layout=', '', '');
                break;
            case 'APL':
                window.open(path + 'Report/Preview' + GetCliteria() + '&Layout=2', '', '');
                break;
            case 'FIX':
            case 'EXP':
                window.open(path + 'Report/Preview' + GetCliteria() +'&Layout=1', '', '');
                break;
            case 'ADD':
                window.open(path + 'Report/Preview' + GetCliteria() + '&Layout=', '', '');
                break;
        }
    }
</script>
