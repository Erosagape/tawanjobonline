
@Code
    ViewBag.Title = "Journal Entry"
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
        <div class="col-sm-4">
            <b id="lblBatchNo">Batch No:</b>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtGLRefNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                <input type="button" class="btn btn-default" value="..." onclick="SearchData('glrefno')" />
            </div>
        </div>
        <div class="col-sm-2">
            <label id="lblRecBy">Record By :</label>
            <br /><div style="display:flex"><input type="text" id="txtUpdateBy" class="form-control" disabled></div>
        </div>
        <div class="col-sm-2">
            <label id="lblRecDate">Record Date</label>
            <br /> <input type="date" id="txtBatchDate" class="form-control" tabIndex="3">
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label id="lblGLType">GL Type</label>            
            <br />
            <select id="txtGLType" class="form-control dropdown">
                <option value="OP">Opening Entry</option>
                <option value="RC">Receive Cash</option>
                <option value="PC">Payment Cash</option>
                <option value="PO">Purchase Entry</option>
                <option value="SO">Sales Entry</option>
                <option value="PR">Purchase Return</option>
                <option value="SR">Sales Return</option>
                <option value="CL">Closing Entry</option>
                <option value="AJ">Adjustment Entry</option>
                <option value="GL">General Ledger</option>
            </select>
        </div>
        <div class="col-sm-6">
            <label id="lblRemark">Remark :</label>
            <br /><div style="display:flex"><textarea id="txtRemark" class="form-control"></textarea></div>
        </div>
        <div class="col-sm-2">
            <label id="lblYear">Fiscal Year :</label>
            <br /><div style="display:flex"><input type="text" id="txtFiscalYear" class="form-control"></div>
        </div>
    </div>
<div>
    <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Entry</b>
    </a>
    <table id="tbDetail" class="table table-responsive">
        <thead>
            <tr>
                <th class="desktop">ItemNo</th>
                <th class="all">Account Code</th>
                <th class="desktop">Description</th>
                <th class="desktop">Document</th>
                <th class="all">Debit</th>
                <th class="all">Credit</th>
            </tr>
        </thead>
    </table>
</div>
<div class="row">
    <div class="col-sm-4" style="display:flex;flex-direction:column">
        <div>
            <label id="lblTotalDr">Total Debit :</label>
            <br /><div style="display:flex"><input type="number" id="txtTotalDebit" class="form-control" value="0.00" disabled></div>
        </div>
        <div>
            <label id="lblTotalCr">Total Credit :</label>
            <br /><div style="display:flex"><input type="number" id="txtTotalCredit" class="form-control" value="0.00" disabled></div>
        </div>
    </div>
    <div class="col-sm-4" style="display:flex;flex-direction:column">
        <div>
            <label id="lblApprDate">Approve Date :</label>
            <br /><div style="display:flex"><input type="date" id="txtApproveDate" class="form-control" disabled></div>
        </div>
        <div>
            <label id="lblApprBy">Approve By :</label>            
            <br />
            <div style="display:flex">
                <input type="text" id="txtApproveBy" class="form-control" disabled>
                <input type="button" id="btnApprove" class="btn btn-primary" onclick="ApproveData()" value="Approve" />
            </div>
        </div>        
    </div>
    <div class="col-sm-4" style="display:flex;flex-direction:column">
        <div>
            <label id="lblPostDate">Post Date :</label>
            <br /><div style="display:flex"><input type="date" id="txtPostDate" class="form-control" disabled></div>
        </div>
        <div>
            <label id="lblPostBy">Post By :</label>
            <br /><div style="display:flex"><input type="text" id="txtPostBy" class="form-control" disabled></div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        <label id="lblCancelDate">Cancel Date :</label>
        <br /><div style="display:flex"><input type="date" id="txtCancelDate" class="form-control" disabled></div>
    </div>
    <div class="col-sm-3">
        <label id="lblCancelBy">Cancel By :</label>
        <br /><div style="display:flex"><input type="text" id="txtCancelBy" class="form-control" disabled></div>
    </div>
    <div class="col-sm-6">
        <label id="lblCancelReason">Cancel Reason :</label>
        <br /><div style="display:flex"><input type="text" id="txtCancelReason" class="form-control"></div>
    </div>
</div>
<div id="dvCommands">
    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">New</b>
    </a>
    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
    </a>
    <a href="#" class="btn btn-danger" id="btnDelete" onclick="CancelData()">
        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkCancel">Cancel</b>
    </a>
    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print</b>
    </a>
</div>
<div id="dvDetail" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="display:flex">
                <div>
                    <label id="lblItemNo">Entry No:</label>
                    <br /><div style="display:flex"><input type="text" id="txtItemNo" class="form-control"></div>
                </div>
                <div>
                    <label id="lblEntryDate">Entry Date :</label>
                    <br /><div style="display:flex"><input type="date" id="txtEntryDate" class="form-control" disabled></div>
                </div>
                <div>
                    <label id="lblEntryBy">Entry By :</label>
                    <br /><div style="display:flex"><input type="text" id="txtEntryBy" class="form-control" disabled></div>
                </div>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblAcCode">A/C Code :</label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtGLAccountCode" class="form-control">
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('acccode')" />
                        </div>
                    </div>
                    <div class="col-sm-8">
                        <label id="lblAcDesc">A/C Description :</label>
                        <br /><div style="display:flex"><input type="text" id="txtGLDescription" class="form-control"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblDr">Debit</label>
                         :<br /><div style="display:flex"><input type="number" id="txtDebitAmt" class="form-control" value="0.00"></div>
                    </div>
                    <div class="col-sm-4">
                        <label id="lblCr">Credit</label>
                         :<br /><div style="display:flex"><input type="number" id="txtCreditAmt" class="form-control" value="0.00"></div>
                    </div>
                    <div class="col-sm-4">
                        <label id="lblRefNo">Ref.No</label>
                         :<br /><div style="display:flex"><input type="text" id="txtSourceDocument" class="form-control"></div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <div style="float:left">
                    <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="ClearDetail()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="lblAdd">New Entry</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnUpdateDetail" onclick="SaveDetail()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="lblUpdate">Save Entry</b>
                    </a>
                    <a href="#" class="btn btn-danger" id="btnDeleteDetail" onclick="DeleteDetail()">
                        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="lblDelete">Delete Entry</b>
                    </a>
                </div>
                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    let userRights = '@ViewBag.UserRights';

    SetEvents();
    SetLOVs();
    ClearData();

    function SetEvents() {
        $('#txtGLAccountCode').keydown(function (event) {
            if (event.which == 13) {
                ShowAccount(path, $('#txtGLAccountCode'), '#txtGLDescription');
            }
        });
        $('#txtGLRefNo').keydown(function (event) {
            if (event.which == 13) {
                let branch = $('#txtBranchCode').val();
                let code=$('#txtGLRefNo').val();
                ClearData();
                $('#txtBranchCode').val(branch);
                $('#txtGLRefNo').val(code);
                CallBackQueryGLHeader(path, branch, code,ReadData);
            }
        });
    }
    //CRUD Functions used in HTML Java Scripts
    function AddDetail() {
        ClearDetail();
        $('#dvDetail').modal('show');
    }
    function LoadDetail(code, doc) {
        $('#tbDetail').DataTable().clear().draw();
        $.get(path + 'acc/getgldetail?Branch=' + code + '&Code=' + doc).done(function (r) {
            let dr = r.journal.detail;
            if (dr.length > 0) {
                RefreshGrid(dr);
            }
        });
    }
    function RefreshGrid(dr) {
        let tb=$('#tbDetail').DataTable({
            data: dr,
            columns: [
                { data: "ItemNo", title: "No" },
                { data: "GLAccountCode", title: "Code" },
                { data: "GLDescription", title: "Description" },
                { data: "SourceDocument", title: "Ref.Document" },
                { data: "DebitAmt", title: "Debit",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "CreditAmt", title: "Credit",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                }
            ],
            destroy: true,
            responsive:true
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail tbody').on('click', 'tr', function () {
            SetSelect('#tbDetail', this);
            row = $('#tbDetail').DataTable().row(this).data(); //read current row selected
            ClearDetail();
            ReadDetail(row);
            $('#dvDetail').modal('show');
        });
    }
    function DeleteData() {
        let branch = $('#txtBranchCode').val();
        let code = $('#txtGLRefNo').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'acc/delglheader?branch=' + branch + '&code=' + code, function (r) {
                ShowMessage(r.journal.result);
                ClearData();
            });
        });
    }
    function DeleteDetail() {
        let branch = $('#txtBranchCode').val();
        let code = $('#txtGLRefNo').val();
        let item = $('#txtItemNo').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'acc/delgldetail?branch=' + branch + '&code=' + code + '&item=' + item, function (r) {
                LoadDetail($('#txtBranchCode').val(), $('#txtGLRefNo').val());
                ShowMessage(r.journal.result);
                ClearDetail();
            });
        });
    }
    function ReadData(dr) {
        $('#txtBranchCode').val(dr.BranchCode);
        ShowBranch(path, dr.BranchCode, '#txtBranchName');
        $('#txtGLRefNo').val(dr.GLRefNo);
        $('#txtFiscalYear').val(dr.FiscalYear);
        $('#txtBatchDate').val(CDateEN(dr.BatchDate));
        $('#txtUpdateBy').val(dr.UpdateBy);
        $('#txtGLType').val(dr.GLType);
        $('#txtRemark').val(dr.Remark);
        $('#txtTotalDebit').val(dr.TotalDebit);
        $('#txtTotalCredit').val(dr.TotalCredit);
        $('#txtApproveDate').val(CDateEN(dr.ApproveDate));
        $('#txtApproveBy').val(dr.ApproveBy);
        if ($('#txtApproveBy').val() !== '' || $('#txtPostBy').val() !== '') {
            $('#btnSave').attr('disabled', 'disabled');
            $('#btnUpdateDetail').attr('disabled', 'disabled');
            $('#btnDeleteDetail').attr('disabled', 'disabled');
        }
        $('#txtPostDate').val(CDateEN(dr.PostDate));
        $('#txtPostBy').val(dr.PostBy);
        $('#txtCancelDate').val(CDateEN(dr.CancelDate));
        $('#txtCancelBy').val(dr.CancelBy);
        $('#txtCancelReason').val(dr.CancelReason);

        LoadDetail($('#txtBranchCode').val(), $('#txtGLRefNo').val());
    }
    function ReadDetail(dr) {		
        $('#txtItemNo').val(dr.ItemNo);
        $('#txtGLAccountCode').val(dr.GLAccountCode);
        $('#txtGLDescription').val(dr.GLDescription);
        $('#txtSourceDocument').val(dr.SourceDocument);
        $('#txtDebitAmt').val(dr.DebitAmt);
        $('#txtCreditAmt').val(dr.CreditAmt);
        $('#txtEntryDate').val(CDateEN(dr.EntryDate));
        $('#txtEntryBy').val(dr.EntryBy);
    }
    function SaveData(){
        let obj = {
            BranchCode:$('#txtBranchCode').val(),
            GLRefNo:$('#txtGLRefNo').val(),
            FiscalYear: $('#txtFiscalYear').val(),
            BatchDate:CDateEN($('#txtBatchDate').val()),
            LastupDate:CDateEN(GetToday()),
            UpdateBy:user,
            GLType:$('#txtGLType').val(),
            Remark:$('#txtRemark').val(),
            TotalDebit:CNum($('#txtTotalDebit').val()),
            TotalCredit:CNum($('#txtTotalCredit').val()),
            ApproveDate:CDateEN($('#txtApproveDate').val()),
            ApproveBy:$('#txtApproveBy').val(),
            PostDate:CDateEN($('#txtPostDate').val()),
            PostBy:$('#txtPostBy').val(),
            CancelDate:CDateEN($('#txtCancelDate').val()),
            CancelBy:$('#txtCancelBy').val(),
            CancelReason:$('#txtCancelReason').val()
        };
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetGLHeader", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        $('#txtGLRefNo').val(response.result.data);
                        LoadDetail($('#txtBranchCode').val(), $('#txtGLRefNo').val());
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        });
    }
    function SaveDetail() {
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            GLRefNo: $('#txtGLRefNo').val(),
            ItemNo: $('#txtItemNo').val(),
            GLAccountCode: $('#txtGLAccountCode').val(),
            GLDescription: $('#txtGLDescription').val(),
            SourceDocument: $('#txtSourceDocument').val(),
            DebitAmt: CNum($('#txtDebitAmt').val()),
            CreditAmt: CNum($('#txtCreditAmt').val()),
            EntryDate: CDateEN(GetToday()),
            EntryBy: user
        };
        if (obj.ItemNo != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetGLDetail", "Acc")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            LoadDetail($('#txtBranchCode').val(), $('#txtGLRefNo').val());
                        }
                        ShowMessage(response.result.msg);
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
    function ClearData() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtGLRefNo').val('');
        $('#txtFiscalYear').val('');
        $('#txtBatchDate').val(GetToday());
        $('#txtUpdateBy').val(user);
        $('#txtGLType').val('GL');
        $('#txtRemark').val('');
        $('#txtTotalDebit').val('0.00');
        $('#txtTotalCredit').val('0.00');
        $('#txtApproveDate').val('');
        $('#txtApproveBy').val('');
        $('#txtPostDate').val('');
        $('#txtPostBy').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelBy').val('');
        $('#txtCancelReason').val('');
        $('#tbDetail').DataTable().clear().draw();
        $('#btnSave').removeAttr('disabled');
        $('#btnUpdateDetail').removeAttr('disabled');
        $('#btnDeleteDetail').removeAttr('disabled');
    }
    function ClearDetail() {		        
        $('#txtItemNo').val('0');
        $('#txtGLAccountCode').val('');
        $('#txtGLDescription').val('');
        $('#txtSourceDocument').val('');
        $('#txtDebitAmt').val('0.00');
        $('#txtCreditAmt').val('0.00');
        $('#txtEntryDate').val(GetToday());
        $('#txtEntryBy').val(user);
    }

    function SetLOVs() {
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //code
            CreateLOV(dv, '#frmSearchAcc', '#tbAcc', 'Account Codes', response, 2);
            //gl
            CreateLOV(dv, '#frmSearchRef', '#tbRef', 'Batch Entry', response, 4);
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'acccode':
                SetGridAccountCode(path, '#tbAcc', '#frmSearchAcc', '', ReadAccount);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch','#frmSearchBranch', ReadBranch);
                break;
            case 'glrefno':
                let w = '?Branch=' + $('#txtBranchCode').val();
                SetGridJournal(path, '#tbRef', '#frmSearchRef', w, ReadData);
                break;
        }
    }
    function ReadAccount(dt) {
        $('#txtGLAccountCode').val(dt.AccCode);
        $('#txtGLDescription').val(dt.AccTName);
        if (dt.AccSide == 'C') {
            $('#txtCreditAmt').focus();
        }
        if (dt.AccSide == 'D') {
            $('#txtDebitAmt').focus();
        }

    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function PrintData() {
        window.open(path + 'Acc/FormGL?Branch=' + $('#txtBranchCode').val() + '&Code=' + $('#txtGLRefNo').val(), '', '');
    }
    function ApproveData() {
        if ($('#txtCancelBy').val() == '') {
            chkmode = $('#txtApproveBy').val() == '' ? 'I' : 'D';
            CallBackAuthorize(path, 'MODULE_ACC', 'Approve', chkmode, SetApprove);
        } else {
            ShowMessage('This document is cancelled',true);
        }
    }
    function SetApprove(b) {
        if (b == true) {
            $('#txtApproveBy').val(chkmode == 'I' ? user : '');
            $('#txtApproveDate').val(chkmode == 'I' ? GetToday() : '');
            SaveData();
            if (chkmode == 'I') {
                $('#btnSave').attr('disabled', 'disabled');
                $('#btnUpdateDetail').attr('disabled', 'disabled');
                $('#btnDeleteDetail').attr('disabled','disabled');
            } else {
                $('#btnSave').removeAttr('disabled');
                $('#btnUpdateDetail').removeAttr('disabled');
                $('#btnDeleteDetail').removeAttr('disabled');
            }
        } else {
            ShowMessage('You are not allow to do this',true);
        }
    }
    function CancelData() {
        if (userRights.indexOf('D') > 0) {
            if ($('#txtCancelReason').val() == '') {
                ShowMessage('Please enter reason for cancel',true);
                $('#txtCancelReason').focus();
                return;
            }
            $('#txtCancelDate').val(GetToday());
            $('#txtCancelBy').val(user);
            SaveData();
        } else {
            ShowMessage('You are not allow to do this',true);
        }
    }

</script>