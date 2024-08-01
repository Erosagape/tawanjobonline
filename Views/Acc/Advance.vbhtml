@Code
    ViewBag.Title = "List Advance"
End Code
<div class="panel-body">
    <div class="container">
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
            <div class="col-sm-2">
                <label id="lblDateFrom">Request Date From:</label>
                <br />
                <input type="date" class="form-control" id="txtAdvDateF" />
            </div>
            <div class="col-sm-2">
                <label id="lblDateTo">Request Date To:</label>
                <br />
                <input type="date" class="form-control" id="txtAdvDateT" />
            </div>
            <div class="col-sm-2">
                <label id="lblJobType">Job Type:</label>
                <br />
                <select id="cboJobType" class="form-control dropdown" onchange="CheckJobType()"></select>
            </div>
            <div class="col-sm-2">
                <label id="lblShipBy">Ship By:</label>
                <br />
                <select id="cboShipBy" class="form-control dropdown"></select>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblReqBy">Request By :</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtReqBy" style="width:100px" />
                    <button id="btnBrowseEmp2" class="btn btn-default" onclick="SearchData('reqby')">...</button>
                    <input type="text" id="txtReqName" class="form-control" style="width:100%" disabled />
                </div>
            </div>
            <div class="col-sm-6">
                <label id="lblAdvFor">Advance For :</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtCustCode" class="form-control" style="width:130px" />
                    <input type="text" id="txtCustBranch" class="form-control" style="width:70px" />
                    <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                    <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
                </div>
            </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-sm-2">
                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddAdvance()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkCreate">Create Advance</b>
                </a>
            </div>
            <div class="col-sm-8" style="text-align:right">
                Job No : <input type="text" id="txtJNo" /> &nbsp;
                <input type="checkbox" id="chkCancel" />Show Cancel Only
            </div>
            <div class="col-sm-2">
                <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th class="all">Adv.No</th>
                            <th class="all">Req.date</th>
                            <th class="desktop">Job No</th>
                            <th class="desktop">Inv.No</th>
                            <th>customer</th>
                            <th class="all">Total</th>
                            <th class="desktop">W-Tax</th>
                            <th class="desktop">Req.By</th>
                        </tr>
                    </thead>
                </table>
<br>
Total : <input type="text" id="txtSumApprove" readonly />

            </div>
        </div>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userGroup = '@ViewBag.UserGroup';
    let arr = [];
    let jt = '';
    //$(document).ready(function () {
        SetEvents();
    //});
    function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
        return;
    }
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtAdvDateF').val(GetFirstDayOfMonth());
        $('#txtAdvDateT').val(GetLastDayOfMonth());
        //Combos
        let lists = 'JOB_TYPE=#cboJobType';
        lists += ',SHIP_BY=#cboShipBy';
        loadCombos(path, lists);
        //Events
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtReqBy').keydown(function (event) {
            if (event.which == 13) {
                $('#txtReqName').val('');
                ShowUser(path, $('#txtReqBy').val(), '#txtReqName');
            }
        });
        $('#txtCustBranch').keydown(function (event) {
            if (event.which == 13) {
                $('#txtCustName').val('');
                ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchReq', '#tbReq', 'Request By', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });

    }
    function SetGridAdv(isAlert) {
        arr = [];

        let w = '';
        if(userGroup!=='S') {
            w = w + '&advby=' + user;      
        }
        if ($('#txtReqBy').val() !== "") {
            w = w + '&reqby=' + $('#txtReqBy').val();
        }
        if ($('#txtCustCode').val() !== "") {
            w = w + '&custcode=' + $('#txtCustCode').val();
        }
        if ($('#txtCustBranch').val() !== "") {
            w = w + '&custbranch=' + $('#txtCustBranch').val();
        }
        if ($('#cboJobType').val() !== "") {
            w = w + '&jtype=' + $('#cboJobType').val();
        }
        if ($('#txtJNo').val() !== "") {
            w = w + '&jobno=' + $('#txtJNo').val();
        }
        if ($('#cboShipBy').val() !== "") {
            w = w + '&sby=' + $('#cboShipBy').val();
        }
        if ($('#txtAdvDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtAdvDateF').val());
        }
        if ($('#txtAdvDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtAdvDateT').val());
        }
        if ($('#chkCancel').prop('checked')) {
            w = w + '&Show=CANCEL';
        } else {
            w = w + '&Show=ACTIVE';
        }
        $.get(path + 'adv/getadvancegrid?branchcode=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.adv.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.adv.data;
	    ShowSummary(h);
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "AdvNo", title: "Advance No" },
                    {
                        data: "AdvDate", title: "Request date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "JobNo", title: "Job Number" },
                    { data: "CustInvNo", title: "InvNo" },
                    { data: "CustCode", title: "Customer" },
                    {
                        data: "TotalAdvance", title: "Total",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "Total50Tavi", title: "W/T Amt",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "EmpCode", title: "Request By" }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                ,pageLength:100
            });

            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'adv/index?BranchCode=' + data.BranchCode + '&AdvNo=' + data.AdvNo,'','');
            });
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'reqby':
                SetGridUser(path, '#tbReq', '#frmSearchReq', ReadReqBy);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
        }
    }
    function ReadReqBy(dt) {
        $('#txtReqBy').val(dt.UserID);
        $('#txtReqName').val(dt.TName);
        $('#txtReqBy').focus();
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
        $('#txtCustCode').focus();
    }
    function AddAdvance() {
        window.open(path + 'adv/index', '', '');
    }
    function ShowSummary(h) {
        let tot = 0;
        for (let i = 0; i < h.length; i++) {
            let o = h[i];
            tot += o.TotalAdvance;
        }
        $('#txtSumApprove').val(ShowNumber(tot, 2));
    }
</script>
