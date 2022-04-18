@Code
    ViewData("Title") = "Shipment Time line"
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
            Customer:
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtCustCode" style="width:20%" disabled />
                <input type="text" class="form-control" id="txtCustBranch" style="width:10%" disabled />
                <input type="button" class="btn btn-default" id="btnBrowseCust" value="..." onclick="SearchData('customer');" />
                <input type="text" class="form-control" id="txtCustName" style="width:60%" disabled />
            </div>
        </div>
        <div class="col-sm-3">
            Status:
            <br />
            <select id="cboStatus" class="form-control dropdown"></select>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Inspection Date From:
            <br/>
            <input type="date" id="txtDateFrom" class="form-control" />
        </div>
        <div class="col-sm-3">
            Inspection Date To:
            <br />
            <input type="date" id="txtDateTo" class="form-control" />
        </div>
        <div class="col-sm-3">
            Job Number:
            <br/>
            <input type="text" id="txtJNo" class="form-control" />
        </div>
        <div class="col-sm-3">
            <br />
            <a href="#" class="btn btn-primary" id="btnShow" onclick="RefreshGrid()">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Show</b>
            </a>
        </div>
    </div>
<br/>
<div id="dvJobs">
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let userGroup = '@ViewBag.UserGroup';
    let userPosition = '@ViewBag.UserPosition';
    let user = '@ViewBag.User';
    let cust = '';
    if (userGroup == 'C') {
        $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
            if (r.company.data.length > 0) {
                let dr = r.company.data[0];
                cust = dr.CustCode;
                $('#txtCustCode').val(dr.CustCode);
                $('#txtCustBranch').val(dr.Branch);
                $('#txtCustName').val(dr.NameThai);
                $('#btnBrowseCust').attr('disabled', 'disabled');
                $('#txtCustCode').attr('disabled', 'disabled');
                $('#txtCustBranch').attr('disabled', 'disabled');
            }
        });
    }
    SetLOVs();
    if (userGroup == 'S') {
        RefreshGrid();
    }
    function SetLOVs() {
        let lists = 'JOB_STATUS=#cboStatus';
        loadCombos(path, lists);
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDateFrom').val(GetFirstDayOfMonth());
        $('#txtDateTo').val(GetLastDayOfMonth());
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 4);

        });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
    function GetStatusStyle(val) {
        switch (val) {
            case 0:
                return 'background-color:lightyellow';
            case 1:
                return 'background-color:yellow';
            case 2:
                return 'background-color:palegoldenrod';
            case 3:
                return 'background-color:plum';
            case 4:
                return 'background-color:pink';
            case 5:
                return 'background-color:palegreen';
            case 6:
                return 'background-color:green';
            case 7:
                return 'background-color:gold';
        }
    }
    function RefreshGrid() {
        let url = '';
        if (userGroup == 'S') {
            switch (userPosition) {
                case '3':
                    url = path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#txtBranchCode').val() + '&ManagerCode=' + user;
                    break;
                case '4':
                    url = path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#txtBranchCode').val() + '&CSCode=' + user;
                    break;
                case '5':
                    url = path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#txtBranchCode').val() + '&ShippingCode=' + user;
                    break;
                default:
                    url = path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#txtBranchCode').val();
                    break;
            }
        }
        if (userGroup=='C') {
            url = path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#txtBranchCode').val() + '&CustCode=' + cust ;
        }
        $.get(url, function (r) {
            let branch = $('#txtBranchCode').val();
            cust = $('#txtCustCode').val();
            let w = '';
            if (cust !== '') {
                w += '&CustCode=' + cust;
            }
            let status = $('#cboStatus').val();
            if (status !== '') {
                w += '&Status=' + status;
            }
            if (userGroup == 'S' && userPosition=='3') {
                w += '&ManagerCode=' + user;
            }
            if (userGroup == 'S' && userPosition=='4') {
                w += '&CSCode=' + user;
            }
            if (userGroup == 'S' && userPosition=='5') {
                w += '&ShippingCode=' + user;
            }
            w += '&ByDate=DutyDate';
            if ($('#txtDateFrom').val()!=='') {
                w += '&DateFrom=' + CDateEN($('#txtDateFrom').val());
            }
            if ($('#txtDateTo').val()!=='') {
                w += '&DateTo=' + CDateEN($('#txtDateTo').val());
            }
            if ($('#txtJNo').val() !== '') {
                w += '&JNo=' + $('#txtJNo').val();
            }
            $('#dvJobs').html('');
            $.get(path + 'JobOrder/GetJobReport?Branch=' + branch + w)
                .done(function (r) {
                    if (r.job.data.length > 0) {
                        let html = '';
                        for (let dr of r.job.data) {
                            if (dr.JNo !== null) {
                                html += '<hr/>';
                                html += '<div class="row" style="background-color:white">';
                                let css = 'style="' + GetStatusStyle(dr.JobStatus) + '"';
                                let jobpath = path + 'joborder/showjob?BranchCode=' + dr.BranchCode + '&JNo=' + dr.JNo;
                                let linkjob = '<a href="' + jobpath + '" target="_blank"><b>' + dr.JNo + '</b></a>';
                                html += '<div class="col-sm-2">' + linkjob;
                                switch (dr.ShipBy) {
                                    case 1: //Air
                                        html += '<i class="fa fa-plane"></i>';
                                        break;
                                    case 2: //Sea
                                        html += '<i class="fa fa-ship"></i>';
                                        break;
                                    default:
                                        html += '<i class="fa fa-truck fa-flip-horizontal"></i>';
                                        break;
                                }
                                html += '<br/>' + dr.InvNo;
                                html += ' ('+ dr.CustCode+':' + dr.DeclareNumber + ')';
                                html += '</div>';
                                for (let i = 0; i <= dr.JobStatus; i++) {
                                    html += '<div class="col-sm-1" ' + css + '>';
                                    switch (i) {
                                        case 0: //Wait For Confirm
                                            html += ShowDate(dr.DocDate) + '<br/>(OPEN)';
                                            break;
                                        case 1: //wait for operation
                                            html += ShowDate(dr.ConfirmDate) + '<br/>(CONFIRM)';
                                            break;
                                        case 2: //wait for clear
                                            html += ShowDate(dr.DutyDate) + '<br/>(INSPECT)';
                                            break;
                                        case 3: //working finished
                                            html += ShowDate(dr.CloseJobDate) + '<br/>(FINISHED)';
                                            break;
                                        case 4: //expense cleared
                                            html += ShowDate(dr.ClearDate) + '<br/>(CLEARANCE)';
                                            break;
                                        case 5: //billing incomplete
                                            html += 'INVOICED';
                                            break;
                                        case 6: //billing complete
                                            html += 'CLEARED';
                                            break;
                                        case 7: //job completed
                                            html += 'PAYMENTED';
                                            break;
                                    }
                                    html += '</div>';
                                    if (i == dr.JobStatus) {
                                        html += '<div><i class="fa fa-space-shuttle"></i><b>'+ dr.JobStatusName +'</b></div>';
                                    }
                                }
                                html += '</div>';
                            }
                        }
                        html += '</div>';

                        $('#dvJobs').html(html).refresh();
                    }
                });

        });
    }
</script>