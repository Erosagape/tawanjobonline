@Code
    ViewBag.Title = "Book Account"
End Code
    <div class="panel-body">
        <div class="container">
            <!-- HTML BOOTSTRAP CONTROLS -->
            <div id="dvForm">
                <label id="lblBranchCode">
                    Branch:
                </label>
                <div class="row">
                    <div class="col-sm-4" style="display:flex;flex-direction:row;">
                        <input type="text" class="form-control" id="txtBranchCode" style="width:15%" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                        <input type="text" class="form-control" id="txtBranchName" style="width:60%" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblBookCode">
                            Book No:
                        </label>
                        <br /><input type="text" id="txtBookCode" class="form-control" tabIndex="2">
                    </div>
                    <div class="col-sm-6">
                        <label id="lblBookName">
                            Account Name :
                        </label>
                        <br /><input type="text" id="txtBookName" class="form-control" tabIndex="3">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblACType">
                            Account Type :
                        </label>
                        <br />
                        <select id="txtACType" class="form-control dropdown" tabIndex="4">
                            <option value="C">Current</option>
                            <option value="S">Saving</option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <a onclick="SearchData('bank')"><label id="lblBankCode">Bank Code :</label></a>
                        <br />
                        <input type="text" id="txtBankCode" class="form-control" tabIndex="5">
                    </div>
                    <div class="col-sm-4">
                        <label id="lblBankName">
                            Bank Name:
                        </label>
                        <br />
                        <input type="text" id="txtBankName" class="form-control" disabled>
                    </div>
                    <div class="col-sm-4">
                        <label id="lblBankBranch">
                            Bank Branch :
                        </label>
                        <br /><input type="text" id="txtBankBranch" class="form-control" tabIndex="6" />
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <input type="checkbox" id="chkIsLocal" tabIndex="7">
                        <label id="lblChkIsLocal" for="chkIsLocal">Is Local Bank?</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5">
                        <label id="lblTAddress1">
                            Address (TH) :
                        </label>
                        <br /><input type="text" id="txtTAddress1" class="form-control" tabIndex="8">
                        <br /><input type="text" id="txtTAddress2" class="form-control" tabIndex="9">
                    </div>
                    <div class="col-sm-5">
                        <label id="lblEAddress1">
                            Address (EN) :
                        </label>
                        <br /><input type="text" id="txtEAddress1" class="form-control" tabIndex="10">
                        <br /><input type="text" id="txtEAddress2" class="form-control" tabIndex="11">
                    </div>
                    <div class="col-sm-2">
                        <label id="lblGLAccountCode">
                            GL Code :
                        </label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtGLAccountCode" class="form-control" />
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('acccode')" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblPhone">
                            Phone :
                        </label>
                        <br /><input type="text" id="txtPhone" class="form-control" tabIndex="12">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblFaxNumber">
                            Fax :
                        </label>
                        <br /><input type="text" id="txtFaxNumber" class="form-control" tabIndex="13">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblLimitBalance">
                            Minimum Balance :
                        </label>
                        <br /><input type="number" id="txtLimitBalance" class="form-control" tabIndex="14">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblControlBalance">
                            Control Balance :
                        </label>
                        <br /><input type="number" id="txtControlBalance" class="form-control" tabIndex="14">
                    </div>
                </div>
            </div>
            <br />
            <div id="dvCommand" class="col-sm-12">
                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
                </a>
                <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                </a>
                <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteData()">
                    <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
                </a>
                <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('book')">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
                </a>
                <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Petty Cash</b>
                </a>
            </div>
            <br />
            <table id="tbBalance" class="table table-responsive">
                <thead>
                    <tr>
                        <th>Cash on hand</th>
                        <th class="all">Cash avaiable</th>
                        <th class="desktop">Chq on hand</th>
                        <th class="desktop">Chq return</th>
                        <th class="desktop">Credit</th>
                        <th class="desktop">Balance</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
            <br />
            <a href="#" class="btn btn-warning" id="btnChange" onclick="ShowPayment()">
                <i class="fa fa-lg fa-check"></i>&nbsp;<b id="linkChange">Refund Account</b>
            </a>
            <a href="#" class="btn btn-primary" id="btnHistory" onclick="ShowApprove()">
                <i class="fa fa-lg fa-search"></i>&nbsp;<b id="linkSearchApprove">Print Summary</b>
            </a>
            <div id="dvApprove" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <b>List of Approved Documents</b>
                        </div>
                        <div class="modal-body">
                            <table id="tbApprove" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>Ref#</th>
                                        <th>Date</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-danger" data-dismiss="modal">X</button>
                        </div>
                    </div>
                </div>
            </div>
            <div id="dvPayment" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            From <input type="date" id="txtDateFrom" /> To <input type="date" id="txtDateTo" />
                            <input type="button" id="btnRefresh" class="btn btn-primary" value="Show" onclick="SetGridPayment()" />
                        </div>
                        <div class="modal-body">
                            <table id="tbPayment" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>Doc</th>
                                        <th>Desc</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <div style="float:left">
                                Balance <input type="number" id="txtBalance" disabled />
                                <button class="btn btn-success" onclick="SavePettyCash()">Save</button>
                            </div>
                            <button class="btn btn-danger" data-dismiss="modal">X</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvLOVs"></div>
    </div>

<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        SetEvents();
        SetEnterToTab();
        ClearData();
    //});
    function SetEvents() {
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtBankCode').keydown(function (event) {
            if (event.which == 13) {
                ShowBank(path, $('#txtBankCode').val(), '#txtBankName');
            }
        });
        $('#txtBookCode').keydown(function (event) {
            if (event.which == 13) {
                var branch = $('#txtBranchCode').val();
                var code = $('#txtBookCode').val();
                ClearData();
                $('#txtBranchCode').val(branch);
                $('#txtBookCode').val(code);
                CallBackQueryBookAccount(path, branch,code, ReadData);
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchBank', '#tbBank', 'Bank', response, 2);
            CreateLOV(dv, '#frmSearchBook', '#tbBook', 'Book Account', response, 2);
            CreateLOV(dv, '#frmSearchAcc', '#tbAcc', 'Account Code', response, 2);
        });
    }
    function SetEnterToTab() {
        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    var idx = (this.tabIndex + 1);
                    var nextElement = $('[tabindex="' + idx + '"]');
                    while (nextElement.length) {
                        if (nextElement.prop('disabled') == false) {
                            $('[tabindex="' + idx + '"]').focus();
                            e.preventDefault();
                            return;
                        } else {
                            idx = idx + 1;
                            nextElement = $('[tabindex="' + idx + '"]');
                        }
                    }
                    $('[tabindex="1"]').focus();
                }
            });
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'acccode':
                SetGridAccountCode(path, '#tbAcc', '#frmSearchAcc', '', ReadAccount);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'bank':
                SetGridBank(path, '#tbBank', '#frmSearchBank', ReadBank);
                break;
            case 'book':
                SetGridBookAccount(path, '#tbBook', '#frmSearchBook', ReadData);
                break;

        }
    }
    function ReadAccount(dr) {
        $('#txtGLAccountCode').val(dr.AccCode);
    }
    function ReadBank(dr) {
        $('#txtBankCode').val(dr.Code);
        $('#txtBankName').val(dr.BName);
        $('#txtBankCode').focus();
    }
    function ReadBranch(dr) {
        $('#txtBranchCode').val(dr.Code);
        $('#txtBranchName').val(dr.BrName);
        $('#txtBranchCode').focus();
    }

//CRUD Functions used in HTML Java Scripts
    function DeleteData() {
        var branch = $('#txtBranchCode').val();
        var code = $('#txtBookCode').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delbookaccount?branch='+branch+'&code=' + code, function (r) {
                ShowMessage(r.bookaccount.result);
                ClearData();
            });
        });
    }
    function ReadData(dr) {
        $('#txtBranchCode').val(dr.BranchCode);
        ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
        $('#txtBookCode').val(dr.BookCode);
        $('#txtGLAccountCode').val(dr.GLAccountCode);
        $('#txtBookName').val(dr.BookName);
        $('#txtBankCode').val(dr.BankCode);
        ShowBank(path, $('#txtBankCode').val(), '#txtBankName');
        $('#txtBankBranch').val(dr.BankBranch);
        $('#chkIsLocal').prop('checked', dr.IsLocal = 1 ? true : false);
        $('#txtACType').val(dr.ACType);
        $('#txtTAddress1').val(dr.TAddress1);
        $('#txtTAddress2').val(dr.TAddress2);
        $('#txtEAddress1').val(dr.EAddress1);
        $('#txtEAddress2').val(dr.EAddress2);
        $('#txtPhone').val(dr.Phone);
        $('#txtFaxNumber').val(dr.FaxNumber);        
        $('#txtLimitBalance').val(dr.LimitBalance);   
        $('#txtControlBalance').val(dr.ControlBalance); 
        ShowBalance();
    }
    function ShowBalance() {
        $('#tbBalance').DataTable().clear().draw();
        $.get(path + 'Master/GetBookBalance?code=' + $('#txtBookCode').val(), function (r) {
            if (r.bookaccount.data.length > 0) {
                let tb = r.bookaccount.data[0].Table;
                let t=$('#tbBalance').DataTable({
                    data: tb,
                    columns: [
                        { data: "SumCash" },
                        { data: "SumCashInBank" },
                        { data: "SumChqOnhand" },
                        { data: "SumChqReturn" },
                        { data: "SumCredit" },
                        { data: "SumBal" }
                    ],
                    responsive:true,
                    destroy:true
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbBalance');
            }
        });
    }
    function SaveData(){
        var obj={
            BranchCode: $('#txtBranchCode').val(),
            BookCode:$('#txtBookCode').val(),
            BookName:$('#txtBookName').val(),
            BankCode: $('#txtBankCode').val(),
            BankBranch:$('#txtBankBranch').val(),
            IsLocal: ($('#chkIsLocal').prop('checked') == true ? 1 : 0),
            ACType:$('#txtACType').val(),
            TAddress1:$('#txtTAddress1').val(),
            TAddress2:$('#txtTAddress2').val(),
            EAddress1:$('#txtEAddress1').val(),
            EAddress2:$('#txtEAddress2').val(),
            Phone:$('#txtPhone').val(),
            FaxNumber: $('#txtFaxNumber').val(),
            LimitBalance: $('#txtLimitBalance').val(),
            GLAccountCode: $('#txtGLAccountCode').val(),
            ControlBalance: $('#txtControlBalance').val()
        };
        if (obj.BookCode != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                $.ajax({
                    url: "@Url.Action("SetBookAccount", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtBookCode').val(response.result.data);
                            $('#txtBookCode').focus();
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
    function ClearData(){
        //$('#txtBranchCode').val('');
        //$('#txtBranchName').val('');
        $('#txtBookCode').val('');
        $('#txtBookName').val('');
        $('#txtBankCode').val('');
        $('#txtBankName').val('');
        $('#txtBankBranch').val('');
        $('#chkIsLocal').prop('checked', false);
        $('#txtACType').val('');
        $('#txtTAddress1').val('');
        $('#txtTAddress2').val('');
        $('#txtEAddress1').val('');
        $('#txtEAddress2').val('');
        $('#txtPhone').val('');
        $('#txtFaxNumber').val('');
        $('#txtBookCode').focus();
        $('#txtLimitBalance').val(0);   
        $('#txtControlBalance').val(0);
        $('#txtGLAccountCode').val('');
        $('#tbBalance').DataTable().clear().draw();
    }
    function PrintData() {
        window.open(path + 'Acc/FormPettyCash?Branch=' + $('#txtBranchCode').val() + '&Code=' + $('#txtBookCode').val(), '', '');
    }
    function ShowApprove() {
        $('#dvApprove').modal('show');
        SetGridApprove();
    }
    function SetGridApprove() {
        let w = '';
        w = w + '&Code=' + $('#txtBookCode').val();

        $.get(path + 'acc/getpettycashlist?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.pettycash.header.length == 0) {
                $('#tbApprove').DataTable().clear().draw();
                ShowMessage('Data not found', true);
                return;
            }
            let h = r.pettycash.header;
            $('#tbApprove').DataTable().destroy();
            $('#tbApprove').empty();
            let tb = $('#tbApprove').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "PostRefNo", title: "Ref#" },
                    { data: "PostedDate", title: "Date#" }
                ],
                responsive: true,
                destroy: true
            });
            $('#tbApprove tbody').on('dblclick', 'tr', function () {
                let data = $('#tbApprove').DataTable().row(this).data(); //read current row selected
                window.open(path + 'acc/formpettycash?Branch=' + $('#txtBranchCode').val() + '&DocNo=' + data.PostRefNo, '', '');
            });
        });
    }
    function ShowPayment() {
        $('#txtDateFrom').val('');
        $('#txtDateTo').val('');
        SetGridPayment();
        $('#dvPayment').modal('show');
    }
    function SetGridPayment() {
        let br =  $('#txtBranchCode').val();
        let bk = $('#txtBookCode').val();
        let dfrom = CDateEN($('#txtDateFrom').val());
        let dto = CDateEN($('#txtDateTo').val());
        let w = '';
        if (dfrom !== '') {
            w += '&DateFrom=' + dfrom;
        }
        if (dto !== '') {
            w += '&DateTo=' + dto;
        }
        $.get(path + 'Acc/GetVoucherDetail?BranchCode=' + br + '&BookNo=' + bk +w).done(function (r) {
            if (r.data.detail.length > 0) {
                let dh = r.data.header[0].Table;
                let total = 0;
                for (let r of dh) {
                    total += Number(r.Net);
                }
                $('#txtBalance').val(CDbl(total, 2));

                let dr = r.data.detail[0].Table;
                $('#tbPayment').DataTable().destroy();
                $('#tbPayment').empty();
                $('#tbPayment').DataTable({
                    data: dr,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: "DocNo", title: "Doc#" },
                        { data: "SDescription", title: "Desc" },
                        { data: "TotalNet", title: "Amount" }
                    ],
                    responsive: true,
                    destroy: true
                });
            }
        });
    }
    function SavePettyCash() {

    }
</script>
