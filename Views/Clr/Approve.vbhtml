﻿@Code
    ViewBag.Title = "Clearing Confirmation"
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
                <label id="lblDateFrom">Clear Date From:</label>
                <br />
                <input type="date" class="form-control" id="txtClrDateF" />
            </div>
            <div class="col-sm-2">
                <label id="lblDateTo">Clear Date To:</label>
                <br />
                <input type="date" class="form-control" id="txtClrDateT" />
            </div>
            <div class="col-sm-2">
                <label id="lblJobType">Job Type:</label>
                <br />
                <select id="cboJobType" class="form-control dropdown"></select>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblClrBy">Clear By :</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtClrBy" style="width:100px" />
                    <button id="btnBrowseEmp2" class="btn btn-default" onclick="SearchData('reqby')">...</button>
                    <input type="text" id="txtClrByName" class="form-control" style="width:100%" disabled />
                </div>
            </div>
            <div class="col-sm-2">
                <label id="lblClrFrom">Clear From:</label>
                <br />
                <select id="cboClrFrom" class="form-control dropdown"></select>
            </div>

            <div class="col-sm-2">
                <label id="lblClrType">Clear Type:</label>
                <br />
                <select id="cboClrType" class="form-control dropdown"></select>
            </div>
            <div class="col-sm-2">
                <input type="checkbox" id="chkSelectAll" checked /> Select All
                <br />
                <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridClr(true)">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <label id="lblListApprove">Approve Document</label>
                 : <input type="text" id="txtListApprove" class="form-control" value="" disabled />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Clr.No</th>
                            <th class="desktop">Clr.date</th>
                            <th>Job No</th>
                            <th class="desktop">Inv.No</th>
                            <th class="desktop">Customer</th>
                            <th class="desktop">Adv.No</th>
                            <th class="desktop">Adv.Total</th>
                            <th class="all">Clr.Total</th>
                            <th class="all">WH-Tax</th>
                        </tr>
                    </thead>
                </table>
                <label id="lblExpTotal">Expenses Total</label>
                 : <input type="text" id="txtSumApprove" class="form-control" value="" />
                <br />
                <a href="#" class="btn btn-success" id="btnSave" onclick="ApproveData()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkApprove">Confirm</b>
                </a>
            </div>
        </div>
    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let arr = [];
    //$(document).ready(function () {
    SetEvents();
    //});
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');

        $('#txtClrDateF').val(GetFirstDayOfMonth());
        $('#txtClrDateT').val(GetLastDayOfMonth());
        //Combos
        let lists = 'JOB_TYPE=#cboJobType';
        lists += ',CLR_TYPE=#cboClrType';
        lists += ',CLR_FROM=#cboClrFrom';

        loadCombos(path, lists);
        //Events
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtClrBy').keydown(function (event) {
            if (event.which == 13) {
                $('#txtClrByName').val('');
                ShowUser(path, $('#txtClrBy').val(), '#txtClrByName');
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchEmp', '#tbEmp', 'Clear By', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });
    }
    function SetGridClr(isAlert) {
        arr = [];
        ShowSummary();

        let w = '';
        if ($('#txtClrBy').val() !== "") {
            w = w + '&clrby=' + $('#txtClrBy').val();
        }

        if ($('#cboJobType').val() !== "") {
            w = w + '&jtype=' + $('#cboJobType').val();
        }
        if ($('#cboClrType').val() !== "") {
            w = w + '&ctype=' + $('#cboClrType').val();
        }
        if ($('#cboClrFrom').val() !== "") {
            w = w + '&cfrom=' + $('#cboClrFrom').val();
        }
        if ($('#txtClrDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtClrDateF').val());
        }
        if ($('#txtClrDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtClrDateT').val());
        }
        w = w + '&Status=1';
        $.get(path + 'clr/getclearinggrid?branchcode=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.clr.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.clr.data[0].Table;
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "ClrNo", title: "Clearing No" },
                    {
                        data: "ClrDate", title: "Clear date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "JobNo", title: "Job Number" },
                    { data: "CustInvNo", title: "InvNo" },
                    { data: "CustCode", title: "Customer" },
                    { data: "AdvNO", title: "Adv.No" },
                    {
                        data: "AdvTotal", title: "Total.Adv",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "ClrAmt", title: "Total.Clr",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "Clr50Tavi", title: "W/T",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    }
                ],
                createdRow: function (row, data, index) {
                    if ($('#chkSelectAll').prop('checked')) {
                        $(row).addClass('selected')
                    }
                },
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected') == true) {
                    $(this).removeClass('selected');
                    let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                    RemoveData(data); //callback function from caller
                    return;
                }
                $(this).addClass('selected');
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                AddData(data); //callback function from caller
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'clr/index?BranchCode=' + data.BranchCode + '&ClrNo=' + data.ClrNo,'','');
            });
            if ($('#chkSelectAll').prop('checked')) {
                for (let row of h) {
                    AddData(row);
                }
            }
        });
    }
    function AddData(o) {
        arr.push(o);
        ShowSummary();
    }
    function RemoveData(o) {
        let idx = arr.indexOf(o);
        if (idx < 0) {
            return;
        }
        arr.splice(idx, 1);
        ShowSummary();
    }
    function ShowSummary() {
        let tot = 0;
        let doc = '';
        for (let i = 0; i < arr.length; i++) {
            let o = arr[i];
            tot += o.ClrAmt;
            doc += (doc != '' ? ',' : '') + o.ClrNo;
        }
        $('#txtSumApprove').val(CDbl(tot, 2));
        $('#txtListApprove').val(doc);
    }
    function ApproveData() {
        if (arr.length < 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        let dataApp = [];
        dataApp.push(user);
        for (let i = 0; i < arr.length; i++) {
            dataApp.push(arr[i].BranchCode + '|' + arr[i].ClrNo);
        }
        let jsonString = JSON.stringify({ data: dataApp });
        $.ajax({
            url: "@Url.Action("ApproveClearing", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                SetGridClr(false);
                response ? ShowMessage("Approve Complete") : ShowMessage("Cannot Approve");
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
        return;
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'reqby':
                SetGridUser(path, '#tbEmp', '#frmSearchEmp', ReadReqBy);
                break;
        }
    }
    function ReadReqBy(dt) {
        $('#txtClrBy').val(dt.UserID);
        $('#txtClrByName').val(dt.TName);
        $('#txtClrBy').focus();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
</script>