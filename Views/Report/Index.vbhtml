﻿@Code
    ViewData("Title") = "Reports"
End Code
<div class="row">
    <div class="col-sm-6">
        <div style="display:flex">
            <label style="display:block;width:200px">Group Report</label>
            <select id="cboReportGroup" class="form-control dropdown" onchange="LoadReportList()" style="width:100%"></select>
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
        <b>Report Cliteria:</b><br />
        <label id="lblBranch">Branch</label>
        <br />
        <div style="display:flex">
            <input type="text" class="form-control" style="width:60px" id="txtBranchCode" disabled />
            <input type="button" class="btn btn-default" id="btnBrowseBranch" value="..." onclick="BrowseCliteria('branch')" />
            <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
        </div>
        <div id="cliteriaSet1">
            <div style="display:flex;width:100%;flex-direction:column" id="tbDate">
                <div style="display:flex;">
                    <div style="flex:1">
                        <span id="fromDate">Date</span> From
                    </div>
                    <div style="flex:2">
                        <input type="date" id="txtDateFrom" />
                    </div>
                </div>
                <div style="display:flex;">
                    <div style="flex:1">
                        To
                    </div>
                    <div style="flex:2">
                        <input type="date" id="txtDateTo" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCust">
                <div style="display:flex;">
                    <div style="flex:1">
                        Customer :
                    </div>
                    <div style="flex:2">
                        <textarea id="txtCustCliteria"></textarea>
                        <input type="button" class="btn btn-default" onclick="BrowseCliteria('cust')" value="..." />
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
        <div id="cliteriaSet2" style="display:none;">
            <div style="display:flex;width:100%;flex-direction:column" id="tbJobType">
                <div style="display:flex;">
                    <div style="flex:1">
                        Job Type:
                    </div>
                    <div style="flex:2">
                        <select id="cboJobType" class="form-control dropdown"></select>
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbShipBy">
                <div style="display:flex;">
                    <div style="flex:1">
                        Ship By:
                    </div>
                    <div style="flex:2">
                        <select id="cboShipBy" class="form-control dropdown"></select>
                    </div>
                </div>
            </div>

            <div style="display:flex;width:100%;flex-direction:column" id="tbJobType">
                <div style="display:flex;">
                    <div style="flex:1">
                        Date By:
                    </div>
                    <div style="flex:2">
                        <select id="cboDateBy" class="form-control dropdown"></select>
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCons">
                <div style="display:flex;">
                    <div style="flex:1">
                        Date From :
                    </div>
                    <div style="flex:2">
                        <input type="date" id="txtFromDate" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCons">
                <div style="display:flex;">
                    <div style="flex:1">
                        Date To :
                    </div>
                    <div style="flex:2">
                        <input type="date" id="txtToDate" />
                    </div>
                </div>
            </div>

            <div style="display:flex;width:100%;flex-direction:column" id="tbCus">
                <div style="display:flex;">
                    <div style="flex:1">
                        Customer :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtCustomer" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCons">
                <div style="display:flex;">
                    <div style="flex:1">
                        Consignee :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtConsignee" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbCS">
                <div style="display:flex;">
                    <div style="flex:1">
                        CS :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtCS" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbShip">
                <div style="display:flex;">
                    <div style="flex:1">
                        Shipping :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtShipping" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbAgent">
                <div style="display:flex;">
                    <div style="flex:1">
                        Agent :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtAgent" />
                    </div>
                </div>
            </div>

            <div style="display:flex;width:100%;flex-direction:column" id="tbTrans">
                <div style="display:flex;">
                    <div style="flex:1">
                        Transporter :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtTransport" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbHBL">
                <div style="display:flex;">
                    <div style="flex:1">
                        House BL :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtHBL" />
                    </div>
                </div>
            </div>
            <div style="display:flex;width:100%;flex-direction:column" id="tbJob">
                <div style="display:flex;">
                    <div style="flex:1">
                        Job Number :
                    </div>
                    <div style="flex:2">
                        <input type="text" id="txtJobNumber" />
                    </div>
                </div>
            </div>
        </div>
        <a href="#" class="btn btn-info" id="btnPrnJob" onclick="PrintReport()">
            <i class="fa fa-lg fa-print"><b>Print Report</b></i>
        </a>
    </div>
</div>
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
    SetEvents();
    LoadReportList();
    function LoadReportList() {
        let group = $('#cboReportGroup').val();
        if (group == null) {
            group = '';
        }
        $.get(path + 'Report/GetReportList?group=' + group).done((r) => {
            if ($.isEmptyObject(r) == false && r[0].ReportCode !== null) {
                $('#tbReportList').dataTable({
                    data: r,
                    columns: [
                        { data: "ReportCode", title: "Report Code" },
                        { data: (mainLanguage == 'TH' ? "ReportNameTH" : "ReportNameEN"), title: "ReportName" }
                    ],
                    responsive: true,
                    destroy: true
                    , pageLength: 100
                });
            } else {
                ChangeLanguageForm('@ViewBag.Module');
            }
        });
    }
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
        lists += ",REPORT_GROUP=#cboReportGroup";
        lists += ",JOB_TYPE=#cboJobType";
        lists += ",SHIP_BY=#cboShipBy";
        loadCombos(path, lists);

        $('#tbCode').hide();
        $('#tbReportList tbody').on('click', 'tr', function () {
            let src = $('#tbReportList').DataTable().row(this).data();
            data = {
                ReportType: src.ReportType,
                ReportCode: src.ReportCode,
                ReportGroup: src.ReportGroup,
                ReportNameTH: src.ReportNameTH,
                ReportNameEN: src.ReportNameEN,
                ReportAuthor: src.ReportAuthor,
                ReportUrl: src.ReportUrl ==null? '': src.ReportUrl
            }
            $('#btnPrnJob').show();
            SetSelect('#tbReportList', this);
            reportID = data.ReportCode;
            if (src.ReportType == 'DEV') {
                $('#cboDateBy').empty();
                let cliteria = src.ReportCliteria.split('|');
                for (let str of cliteria) {
                    if (str.indexOf('DateBy') >= 0) {
                        let list = str.split(',');
                        for (let i = 1; i < list.length; i++) {
                            let val = list[i].split('/');
                            $('#cboDateBy').append($('<option>', { value : val[0] }).text(val[1]));
                        }
                    }
                }
                $('#cliteriaSet1').css('display','none');
                $('#cliteriaSet2').css('display','inline');
            } else {
                $('#cliteriaSet2').css('display', 'none');
                $('#cliteriaSet1').css('display', 'inline');
                if (src.ReportCliteria !== undefined) {
                    ReadCliteria(src.ReportCliteria + ',,,');
                } else {
                    LoadCliteria(src.ReportCode);
                }
            }
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
    function ReadCliteria(str) {
        let arr = str.split(',');
        if (arr[1] !== '') {
            $('#tbDate').show();
            let vStr = arr[1].indexOf('.') > 0 ? arr[1].split('.')[1] : arr[1];
            $('#fromDate').text(vStr.toString().replace('Date',' Date'));
        } else {
            $('#tbDate').hide();
        }
        if (arr[2] !== '') {
            $('#tbCust').show();
        } else {
            $('#tbCust').hide();
        }
        if (arr[3] !== '') {
            $('#tbJob').show();
        } else {
            $('#tbJob').hide();
        }
        if (arr[4] !== '') {
            $('#tbEmp').show();
        } else {
            $('#tbEmp').hide();
        }
        if (arr[5] !== '') {
            $('#tbVend').show();
        } else {
            $('#tbVend').hide();
        }
        if (arr[6] !== '') {
            $('#tbStatus').show();
        } else {
            $('#tbStatus').hide();
        }
        if (arr[8] !== '') {
            $('#tbCode').show();
        } else {
            $('#tbCode').hide();
        }
        if (arr[9] !== '') {
            $('#tbGroup').show();
        } else {
            $('#tbGroup').hide();
        }
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
            case 'cons':
                $('#lblCliteria').text('Filter Data For Consignee');
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
            case 'cons':
                SetGridCompany(path, '#tblCust', '#frmSearchCust', ReadData);
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
            case 'cons':
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
            case 'cons':
                $('#txtConsCliteria').val(cliteria);
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
            case 'DEV':
                window.open(path + data.ReportUrl + GetQueryString(),'','');
                break;
            case 'STD':
                window.open(path + 'Report/Preview' + GetCliteria()+ '&Layout=', '', '');
                break;
            case 'APL':
                window.open(path + 'Report/Preview' + GetCliteria() + '&Layout=2', '', '');
                break;
            case 'FIX':
            case 'EXP':
            case 'EXC':
                window.open(path + 'Report/Preview' + GetCliteria() +'&Layout=1', '', '');
                break;
            case 'ADD':
                window.open(path + 'Report/Preview' + GetCliteria() + '&Layout=', '', '');
                break;
        }
    }
    function GetQueryString() {
        var str = '?Branch=' + $('#txtBranchCode').val();
        if ($('#txtFromDate').val() !== '') {
            str += '&DateFrom=' + CDateEN($('#txtFromDate').val());
        }
        if ($('#txtToDate').val() !== '') {
            str += '&DateTo=' + CDateEN($('#txtToDate').val());
        }
        if ($('#cboDateBy').val() !== '') {
            str += '&DateBy=' + $('#cboDateBy').val();
        }
        if ($('#cboJobType').val() !== '') {
            str += '&JobType=' + $('#cboJobType').val();
        }
        if ($('#cboShipBy').val() !== '') {
            str += '&ShipBy=' + $('#cboShipBy').val();
        }
        if ($('#txtCustomer').val() !== '') {
            str += '&Cust=' + $('#txtCustomer').val();
        }
        if ($('#txtConsignee').val() !== '') {
            str += '&Cons=' + $('#txtConsignee').val();
        }
        if ($('#txtShipping').val() !== '') {
            str += '&Shipping=' + $('#txtShipping').val();
        }
        if ($('#txtCS').val() !== '') {
            str += '&CS=' + $('#txtCS').val();
        }
        if ($('#txtAgent').val() !== '') {
            str += '&Agent=' + $('#txtAgent').val();
        }
        if ($('#txtTransport').val() !== '') {
            str += '&Transport=' + $('#txtTransport').val();
        }
        if ($('#txtHBL').val() !== '') {
            str += '&HBL=' + $('#txtHBL').val();
        }
        if ($('#txtJobNumber').val() !== '') {
            str += '&Job=' + $('#txtJobNumber').val();
        }
        return str;
    }
</script>
