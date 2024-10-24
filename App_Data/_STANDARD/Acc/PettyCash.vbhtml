﻿@Code
    ViewBag.Title = "Cash Management"
End Code
<div class="panel-body">
    <div class="container">
        <div id="dvForm">
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblBranch">Branch:</label>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                        <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
                    </div>
                </div>
                <div class="col-sm-2">
                    <label id="lblTranType">Transaction Type</label><br />
                    <select id="cboPRType" class="form-control dropdown">
                        <option value="R" id="optRcv">Received From</option>
                        <option value="P" id="optPay">Transfer To</option>
                    </select>
                </div>
                <div class="col-sm-3">
                    <b id="linkRef">Reference No:</b>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" class="form-control" id="txtControlNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('controlno')" />
                    </div>
                </div>
                <div class="col-sm-2">
                    <label id="lblVoucherDate">Record Date</label>
                    <br /> <input type="date" id="txtVoucherDate" class="form-control" tabIndex="3">
                </div>

            </div>
            <div class="row">
                <div class="col-sm-12">
                    <label id="lblTRemark">Transaction Note</label>
                    <br /><input type="text" id="txtTRemark" class="form-control" tabIndex="4">
                </div>
            </div>
            <div>
                <a href="#" class="btn btn-default w3-purple" id="btnAddPay" onclick="AddPayment()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Detail</b>
                </a>
            </div>
            <table id="tbHeader" class="table table-bordered">
                <thead>
                    <tr>
                        <th class="all">Cash</th>
                        <th class="all">VCNo</th>
                        <th class="desktop">BookAcc</th>
                        <th class="desktop">RefNo</th>
                        <th class="desktop">RefDate</th>
                        <th class="desktop">Bank</th>
                        <th class="desktop">Branch</th>
                        <th class="desktop">PayChqTo</th>
                    </tr>
                </thead>
            </table>
            <div class="row">
                <div class="col-sm-4" style="border-style:solid;border-width:1px">
                    <label id="lblRecBy">Issue By</label>
                    <br />
                    <input type="text" id="txtRecUser" style="width:250px" disabled />
                    <br />
                    <label id="lblRecDate">Date:</label>
                    <input type="date" id="txtRecDate" disabled />
                    <label id="lblRecTime">Time:</label>
                    <input type="text" id="txtRecTime" style="width:80px" disabled />
                </div>
                <div class="col-sm-4" style="border-style:solid;border-width:1px">
                    <input type="checkbox" id="chkPosted" />
                    <label id="lblPostBy" for="chkPosted">Posted By</label><br />
                    <input type="text" id="txtPostedBy" style="width:250px" disabled />
                    <br />
                    <label id="lblPostDate">Date:</label>
                    <input type="date" id="txtPostedDate" disabled />
                    <label id="lblPostTime">Time:</label>
                    <input type="text" id="txtPostedTime" style="width:80px" disabled />
                </div>
                <div class="col-sm-4" style="border-style:solid;border-width:1px;color:red">
                    <input type="checkbox" id="chkCancel" />
                    <label id="lblCancelBy" for="chkCancel">Cancel By</label>
                    <input type="text" id="txtCancelProve" style="width:250px" disabled />
                    <br />
                    <label id="lblCancelDate">Date:</label>
                    <input type="date" id="txtCancelDate" disabled />
                    <label id="lblCancelTime">Time:</label>
                    <input type="text" id="txtCancelTime" style="width:80px" disabled />
                    <br />
                    <label id="lblCancelReason">Cancel Reason</label>
                    <input type="text" id="txtCancelReson" style="width:250px" />
                </div>
            </div>
        </div>
        <div id="frmHeader" class="modal modal-lg fade">
            <div class="modal-dialog-lg">
                <div class="modal-content">
                    <div class="modal-body">
                        <table id="tbControl" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th class="desktop">ControlNo</th>
                                    <th class="all">VoucherDate</th>
                                    <th class="desktop">CustCode</th>
                                    <th class="desktop">Remark</th>
                                    <th class="desktop">VoucherNo</th>
                                    <th class="all">RefNo</th>
                                    <th class="desktop">RefDate</th>
                                    <th class="all">CashAmount</th>
                                    <th class="desktop">Currency</th>
                                    <th class="desktop">DocNo</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmPayment" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <input type="radio" id="optShowPay" value="dvPayInfo" name="showInfo" onchange="ShowInfo()" checked /><label id="lblTranInfo">Transaction Info</label>
                        <input type="radio" id="optShowTax" value="dvPayTax" name="showInfo" onchange="ShowInfo()" /><label id="lblVatInfo">Expense info</label>
                    </div>
                    <div class="modal-body">
                        <div id="dvPayInfo">
                            <div class="row">
                                <div class="col-md-2">
                                    <label id="lblItemNo">No</label>
                                    <br /><input type="text" id="txtItemNo" class="form-control" disabled>
                                </div>
                                <div class="col-md-5">
                                    <label id="lblVCNo">Voucher No:</label>
                                    <br /><input type="text" id="txtPRVoucher" class="form-control" disabled>
                                </div>
                                <div class="col-md-3">
                                    <label id="lblTranDType">Transaction Type</label>
                                    <br />
                                    <select id="cboPRTypeD" class="form-control dropdown">
                                        <option id="optDeposit" value="R">Deposit</option>
                                        <option id="optWithdraw" value="P">Withdraw</option>
                                    </select>
                                </div>
                            </div>
                            <div id="dvBookInfo">
                                <div class="row">
                                    <div class="col-md-3">
                                        <a id="linkBook" onclick="SearchData('bookacc')">Book A/C</a><br /><input type="text" id="txtBookCode" class="form-control">
                                    </div>
                                    <div class="col-md-9">
                                        <label id="lblBookName">Book Name</label>
                                        <br /><input type="text" id="txtBookName" class="form-control" disabled>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <label id="lblBankCode">Bank</label>
                                        <br /><input type="text" id="txtBankCode" class="form-control" disabled>
                                    </div>
                                    <div class="col-md-6">
                                        <label id="lblBankName">Bank Name</label>
                                        <br /><input type="text" id="txtBankName" class="form-control" disabled>
                                    </div>
                                    <div class="col-md-4">
                                        <label id="lblBankBranch">Branch</label>
                                        <br /><input type="text" id="txtBankBranch" class="form-control" disabled>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label id="lblCashAmount">Amount</label>
                                    <br /><input type="number" id="txtCashAmount" class="form-control" value="0.00" />
                                </div>
                                <div class="col-md-9">
                                    <label id="lblPayTo">Paid To</label>
                                    <br /><input type="text" id="txtPayChqTo" class="form-control">
                                </div>
                            </div>
                        </div>
                        <div id="dvPayTax">
                            <div class="row">
                                <div class="col-md-3">
                                    <a id="linkDocType" onclick="SearchData('document')">Doc.Type</a><br />
                                    <select id="txtDocType" class="form-control dropdown"></select>
                                </div>
                                <div class="col-md-4">
                                    <label id="linkDocNo">Ref.No</label>
                                    <br /><input type="text" id="txtDocNo" class="form-control">
                                </div>
                                <div class="col-md-5">
                                    <label id="lblNote">Description</label>
                                    <br /><input type="text" id="txtDTRemark" class="form-control">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label><a id="linkCurr" href="#" onclick="SearchData('currency');">Currency</a></label><br />
                                    <input type="text" id="txtCurrencyCode" class="form-control" />
                                </div>
                                <div class="col-md-9">
                                    <label id="lblCurrName">Currency Name</label>
                                    <br />
                                    <input type="text" id="txtCurrencyName" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <label id="lblAmtBase">Amount Base</label>
                                    <br />
                                    <input type="text" id="txtSumAmt" class="form-control" onchange="CalculateTotal()" />
                                </div>
                                <div class="col-md-3">
                                    <label id="lblExcRate">Exchange Rate</label>
                                    <br />
                                    <input type="text" id="txtExchangeRate" class="form-control" onchange="CalculateTotal()" />
                                </div>
                                <div class="col-md-4">
                                    <label id="lblTotalAmt">Total Amount</label>
                                    <br />
                                    <input type="text" id="txtTotalAmt" class="form-control" onchange="CalculateTotal()" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    Vat(Include)<br />
                                    <input type="text" id="txtVatInc" class="form-control" onchange="CalculateTotal()" />
                                </div>
                                <div class="col-md-3">
                                    Vat(Exclude)<br />
                                    <input type="text" id="txtVatExc" class="form-control" onchange="CalculateTotal()" />
                                </div>
                                <div class="col-md-3">
                                    Wht(Include)<br />
                                    <input type="text" id="txtWhtInc" class="form-control" onchange="CalculateTotal()" />
                                </div>
                                <div class="col-md-3">
                                    Wht(Exclude)<br />
                                    <input type="text" id="txtWhtExc" class="form-control" onchange="CalculateTotal()" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label id="lblTotalNet">Total Net</label>
                                    <br />
                                    <input type="text" id="txtTotalNet" class="form-control" disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnUpdatePay" onclick="SavePayment()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkUpdate">Save Detail</b>
                            </a>
                            <a href="#" class="btn btn-danger" id="btnDelPay" onclick="DeletePayment()">
                                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete Detail</b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvCommand">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearForm()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkClear">Clear Entry</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Entry</b>
            </a>
            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Entry</b>
            </a>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    //$(document).ready(function () {
    SetEvents();
    SetLOVs();
    SetEnterToTab();
    $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
    $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME'); 
    //});
    function SetEvents() {
        $('#txtControlNo').keydown(function (event) {
            if (event.which == 13) {
                LoadData();
            }
        });
        $('#txtBookCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBookName').val('');
                $('#txtBankCode').val('');
                $('#txtBankName').val('');
                $('#txtBankBranch').val('');
                //$('#chkIsLocal').prop('checked', false);

                CallBackQueryBookAccount(path, $('#txtBranchCode').val(), $('#txtBookCode').val(), ReadBookAccount);
            }
        });
        $('#txtCurrencyCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtCurrencyName').val('');
                CallBackQueryCurrency(path, $('#txtCurrencyCode').val(), ReadCurrency);
            }
        });
        $('#txtCashAmount').focusout(function (event) {
            $('#txtSumAmt').val($('#txtCashAmount').val());
            CalculateTotal();
        });
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#chkPosted').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ADV', 'CreditAdv',(chkmode ? 'I':'D'), SetApprove);
        });

        $('#chkCancel').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ADV', 'CreditAdv', 'D', SetCancel);
        });
    }
    function SetEnterToTab() {
        $('#txtVoucherDate').val(GetToday());

        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    let idx = (this.tabIndex + 1);
                    let nextElement = $('[tabindex="' + idx + '"]');
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
    function SetLOVs() {
        let lists ='DOCUMENT_TYPE=#txtDocType';

        loadCombos(path,lists)

        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //BookAccount
            CreateLOV(dv, '#frmSearchBookAcc', '#tbBookAcc', 'Book Accounts', response, 2);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
        });
    }
    function SetApprove(b) {
        if (b == true) {
            $('#txtPostedBy').val(chkmode ? user : '');
            $('#txtPostedDate').val(chkmode ? CDateEN(GetToday()) : '');
            $('#txtPostedTime').val(chkmode ? ShowTime(GetTime()) : '');
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkPosted').prop('checked', !chkmode);
    }
    function SetCancel(b) {
        if (b == true) {
            $('#txtCancelProve').val(chkmode ? user : '');
            $('#txtCancelDate').val(chkmode ? CDateEN(GetToday()) : '');
            $('#txtCancelTime').val(chkmode ? ShowTime(GetTime()) : '');
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkCancel').prop('checked', !chkmode);
    }
    function LoadData() {
        let code = $('#txtControlNo').val();
        let branch = $('#txtBranchCode').val();
        $('#txtBranchCode').val(branch);
        $('#txtControlNo').val(code);
        CallBackQueryVoucher(path, branch,code, ReadData);
    }
    function SearchData(type) {
        switch (type) {
            case 'bookacc':
                SetGridBookAccount(path, '#tbBookAcc', '#frmSearchBookAcc', ReadBookAccount);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'controlno':
                SetGridControl();
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
        }
    }
    function ClearForm() {
        //$('#txtBranchCode').val('');
        //$('#txtBranchName').val('');
        $('#txtControlNo').val('');
        $('#txtVoucherDate').val(GetToday());
        $('#txtTRemark').val('');
        $('#txtRecUser').val(user);
        $('#txtRecDate').val(GetToday());
        $('#txtRecTime').val(GetTime());
        $('#chkPosted').prop('checked',false);
        $('#txtPostedBy').val('');
        $('#txtPostedDate').val('');
        $('#txtPostedTime').val('');
        $('#chkCancel').prop('checked', false);
        $('#txtCancelReson').val('');
        $('#txtCancelProve').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelTime').val('');

        $('#tbHeader').empty();

        $('#btnAdd').removeAttr('disabled');
        $('#btnSave').removeAttr('disabled');
        if (userRights.indexOf('I') < 0) {
            $('#btnAdd').attr('disabled', 'disabled');
        }
        if (userRights.indexOf('E') < 0) {
            $('#btnSave').attr('disabled', 'disabled');
        }
        ClearPayment();
    }
    function AddPayment() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        ClearPayment();
        $('#frmPayment').modal('show');
    }
    function ReadData(dt) {
        ClearForm();
        if (dt.header.length > 0) {
            ReadHeader(dt.header[0]);
        }
        if (dt.payment.length > 0) {
            let data = dt.payment.filter(function (d) {
                return d.PRType==$('#cboPRType').val() && d.CashAmount>0
            });
            SetGridPayment(data);
        }
    }
    function SaveData() {
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            let obj = {
                BranchCode:$('#txtBranchCode').val(),
                ControlNo:$('#txtControlNo').val(),
                VoucherDate:CDateEN($('#txtVoucherDate').val()),
                TRemark:$('#txtTRemark').val(),
                RecUser: user,
                RecDate: CDateEN(GetToday()),
                RecTime: GetTime(),
                PostedBy:$('#txtPostedBy').val(),
                PostedDate:CDateEN($('#txtPostedDate').val()),
                PostedTime:$('#txtPostedTime').val(),
                CancelReson:$('#txtCancelReson').val(),
                CancelProve:$('#txtCancelProve').val(),
                CancelDate:CDateEN($('#txtCancelDate').val()),
                CancelTime: $('#txtCancelTime').val(),
                CustCode: '',
                CustBranch: ''
            };
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetVoucherHeader", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        $('#txtControlNo').val(response.result.data);
                        LoadData();
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });

        });
    }
    function SetGridControl() {
        let code = $('#txtBranchCode').val();
        $.get(path + 'acc/getvouchergrid?branch=' + code + '&type=CASH' + $('#cboPRType').val(), function (r) {
            if (r.voucher.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.voucher.data;
            let tb=$('#tbControl').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "DRefNo", title: "Doc No" },
                    {
                        data: "VoucherDate", title: "Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "TRemark", title: "Remark" },
                    { data: "PRType", title: "Type" },
                    { data: "BookCode", title: "BookCode" },
                    { data: "DocNo", title: "Trans No" },
                    {
                        data: "ChqDate", title: "Trans Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CashAmount", title: "Cash Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "CurrencyCode", title: "Currency" },
                    { data: "ControlNo", title: "Control No" }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbControl');
            $('#tbControl tbody').on('click', 'tr', function () {
                $('#tbControl tbody > tr').removeClass('selected');
                $(this).addClass('selected');
                let data = $('#tbControl').DataTable().row(this).data(); //read current row selected

                CallBackQueryVoucher(path, data.BranchCode, data.ControlNo, ReadData); //callback function from caller

                $('#frmHeader').modal('hide');
            });
            $('#frmHeader').on('shown.bs.modal', function () {
                $('#tbControl_filter input').focus();
            });
            $('#frmHeader').modal('show');
        });
    }
    function SetGridPayment(list) {
        //show selected details
        let tb=$('#tbHeader').DataTable({
            data: list,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "CashAmount", title: "Amount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "CurrencyCode", title: "Currency" },
                { data: "PRVoucher", title: "Voucher" },
                { data: "DocNo", title: "Trans.No" },
                {
                    data: "ChqDate", title: "Trans.Date",
                    render: function (data) {
                        return CDateEN(data);
                    }
                },
                { data: "BankCode", title: "Bank" },
                { data: "BankBranch", title: "Branch" },
                { data: "BookCode", title: "BookCode" }
            ],
            responsive:true,
            destroy: true
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
        $('#tbHeader tbody').on('click', 'tr', function () {
            $('#tbHeader tbody > tr').removeClass('selected');
            $(this).addClass('selected');
            if (userRights.indexOf('E') > 0) {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                ReadPayment(data); //callback function from caller
                $('#frmPayment').modal('show');
            }

        });
    }
    function ShowInfo() {
        let chk = $('input:radio[name=showInfo]:checked').val();
        switch (chk) {
            case 'dvPayInfo':
                $('#dvPayInfo').show();
                $('#dvPayTax').hide();
                break;
            case 'dvPayTax':
                $('#dvPayInfo').hide();
                $('#dvPayTax').show();
                break;
        }
    }

    function ReadHeader(dr) {
        if (dr !== undefined) {
            $('#txtBranchCode').val(dr.BranchCode);
            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            $('#txtControlNo').val(dr.ControlNo);
            $('#txtVoucherDate').val(CDateEN(dr.VoucherDate));
            $('#txtTRemark').val(dr.TRemark);
            $('#txtRecUser').val(dr.RecUser);
            $('#txtRecDate').val(CDateEN(dr.RecDate));
            $('#txtRecTime').val(ShowTime(dr.RecTime));
            $('#txtPostedBy').val(dr.PostedBy);
            if (dr.PostedBy !== '') {
                $('#chkPosted').prop('checked', true);
                DisableSave();
            }
            $('#txtPostedDate').val(CDateEN(dr.PostedDate));
            $('#txtPostedTime').val(ShowTime(dr.PostedTime));
            $('#txtCancelReson').val(dr.CancelReson);
            $('#txtCancelProve').val(dr.CancelProve);
            if (dr.CancelProve !== '') {
                $('#chkCancel').prop('checked', true);
                DisableSave();
            }
            $('#txtCancelDate').val(CDateEN(dr.CancelDate));
            $('#txtCancelTime').val(ShowTime(dr.CancelTime));
        }
    }
    function ReadPayment(dr) {
        ClearPayment();
        if (dr !== undefined) {
            $('#txtItemNo').val(dr.ItemNo);
            $('#txtPRVoucher').val(dr.PRVoucher);
            //$('#txtPRType').val(dr.PRType);
            $('#cboPRTypeD').val(dr.PRType);
            //$('#txtChqNo').val(dr.ChqNo);
            $('#txtBankCode').val(dr.BankCode);
            $('#txtBookCode').val(dr.BookCode);
            $('#txtBankBranch').val(dr.BankBranch);
            //$('#txtChqDate').val(CDateEN(dr.ChqDate));
            $('#txtCashAmount').val(CNum(dr.CashAmount));
            $('#txtSumAmt').val(dr.SumAmount);
            $('#txtCurrencyCode').val(dr.CurrencyCode);
            ShowCurrency(path, dr.CurrencyCode, '#txtCurrencyName');
            $('#txtExchangeRate').val(dr.ExchangeRate);
            $('#txtTotalAmt').val(dr.TotalAmount);
            $('#txtVatExc').val(dr.VatExc);
            $('#txtWhtExc').val(dr.WhtExc);
            $('#txtVatInc').val(dr.VatInc);
            $('#txtWhtInc').val(dr.WhtInc);
            $('#txtTotalNet').val(dr.TotalNet);
            //$('#txtIsLocal').val(dr.IsLocal);
            //$('#chkIsLocal').prop('checked', dr.IsLocal == 1 ? true : false);
            //$('#txtChqStatus').val(dr.ChqStatus);
            //$('#cboChqStatus').val(dr.ChqStatus);
            $('#txtDTRemark').val(dr.TRemark);
            $('#txtPayChqTo').val(dr.PayChqTo);
            $('#txtDocNo').val(dr.DocNo);
            //$('#txtSICode').val(dr.SICode);
            $//('#txtRecvBank').val(dr.RecvBank);
            //$('#txtRecvBranch').val(dr.RecvBranch);
            //$('#txtForJNo').val(dr.ForJNo);
            //CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), ReadJob);
            //$('#txtacType').val(dr.acType);
            //$('#cboacType').val(dr.acType);
            //$('#cboacType').change();
            if (dr.BankCode !== null) {
                ShowBookAccount(path, dr.BookCode, '#txtBookName');
                ShowBank(path, dr.BankCode, '#txtBankName');
            } else {
                CallBackQueryBookAccount(path, dr.BranchCode, dr.BookCode, ReadBookAccount);
            }
            //CallBackQueryService(path, dr.SICode, ReadService);
            //ShowBank(path, dr.RecvBank, '#txtRecvBankName');
        }
    }
    function DisableSave() {
        $('#btnSave').attr('disabled', 'disabled');
        $('#btnUpdatePay').attr('disabled', 'disabled');
        $('#btnDelPay').attr('disabled', 'disabled');
    }
    function ClearPayment() {
        $('#cboPRTypeD').val($('#cboPRType').val());
        $('#txtPRVoucher').val('');
        $('#txtItemNo').val('0');
        //$('#txtChqNo').val('');
        $('#txtBookCode').val('');
        $('#txtBankCode').val('');
        $('#txtBankName').val('');
        $('#txtBankBranch').val('');
        //$('#txtChqDate').val('');
        $('#txtCashAmount').val('0.00');
        $('#txtSumAmt').val('0.00');
        $('#txtTotalAmt').val('0.00');
        $('#txtTotalNet').val('0.00');
        $('#txtVatExc').val('0.00');
        $('#txtWhtExc').val('0.00');
        $('#txtVatInc').val('0.00');
        $('#txtWhtInc').val('0.00');
        $('#txtCurrencyCode').val('@ViewBag.PROFILE_CURRENCY');
        $('#txtCurrencyName').val('THAI BAHT');
        $('#txtExchangeRate').val('1');
        //$('#txtIsLocal').val('');
        //$('#txtChqStatus').val('');
        //$('#cboChqStatus').val('');
        $('#txtDTRemark').val('');
        $('#txtPayChqTo').val('');
        //$('#txtRecvBank').val('');
        //$('#txtRecvBankName').val('');
        //$('#txtRecvBranch').val('');
        //$('#txtSICode').val('');
        //$('#txtSDescription').val('');
        $('#txtDocType').val('');
        $('#txtDocNo').val('');
        //$('#txtJobType').val('');
        //$('#txtShipBy').val('');
        //$('#txtJobTypeName').val('');
        //$('#txtShipByName').val('');
        //$('#txtInvNo').val('');
        //$('#txtForJNo').val('');
        //$('#txtacType').val('');
        //$('#cboacType').val('CU');
        //$('#cboacType').change();

        $('#btnAddPay').removeAttr('disabled');
        $('#btnUpdatePay').removeAttr('disabled');
        $('#btnDelPay').removeAttr('disabled');
        if ($('#chkPosted').prop('checked') == true || $('#chkCancel').prop('checked') == true) {
            $('#btnAddPay').attr('disabled', 'disabled');
            $('#btnUpdatePay').attr('disabled', 'disabled');
            $('#btnDelPay').attr('disabled', 'disabled');
        }
        ShowInfo();
    }
    function SavePayment() {
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            ControlNo: $('#txtControlNo').val(),
            ItemNo: $('#txtItemNo').val(),
            PRVoucher:$('#txtPRVoucher').val(),
            PRType:$('#cboPRTypeD').val(),
            ChqNo:'',
            BookCode:$('#txtBookCode').val(),
            BankCode:$('#txtBankCode').val(),
            BankBranch:$('#txtBankBranch').val(),
            ChqDate: CDateEN($('#txtVoucherDate').val()),
            CashAmount:CNum($('#txtCashAmount').val()),
            ChqAmount:0,            
            CreditAmount: 0,
            SumAmount: CNum($('#txtSumAmt').val()),
            CurrencyCode: $('#txtCurrencyCode').val(),
            ExchangeRate: CNum($('#txtExchangeRate').val()),
            TotalAmount: CNum($('#txtSumAmt').val()),
            VatExc: CNum($('#txtVatExc').val()),
            VatInc: CNum($('#txtVatInc').val()),
            WhtExc: CNum($('#txtWhtExc').val()),
            WhtInc: CNum($('#txtWhtInc').val()),
            TotalNet: CNum($('#txtTotalNet').val()),
            IsLocal:0,
            ChqStatus:'',
            TRemark:$('#txtDTRemark').val(),
            PayChqTo:$('#txtPayChqTo').val(),
            DocNo:'',
            SICode:'',
            RecvBank:'',
            RecvBranch:'',
            acType: 'CA',
            ForJNo:''
        };
        let jsonText = JSON.stringify({ data:[ obj ]});
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetVoucherSub", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                ShowMessage(response.result.msg);
                LoadData();
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }

    function DeletePayment() {
        let itemno = $('#txtItemNo').val();
        let code = $('#txtControlNo').val();
        let branch = $('#txtBranchCode').val();

        $.get(path + 'acc/delvouchersub?branch=' + branch + '&code=' + code + '&item=' + itemno, function (r) {
            LoadData();
            ShowMessage(r.voucher.result);
        });
    }


    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }

    function ReadBookAccount(dt) {
        $('#txtBookCode').val(dt.BookCode);
        $('#txtBookName').val(dt.BookName);
        $('#txtBankCode').val(dt.BankCode);
        ShowBank(path, dt.BankCode, '#txtBankName');
        $('#txtBankBranch').val(dt.BankBranch);
        //$('#chkIsLocal').prop('checked', dt.IsLocal = 1 ? true : false);
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
    }

    function CalculateTotal() {
        let amtbase = Number($('#txtSumAmt').val());
        let excrate = Number($('#txtExchangeRate').val());
        let totalamt = amtbase * excrate;
        $('#txtTotalAmt').val(CDbl(totalamt, 4));
        //calculate base for included vat/wht
        let vatinc = Number($('#txtVatInc').val());
        let whtinc = Number($('#txtWhtInc').val());
        totalamt += whtinc;
        totalamt -= vatinc;
        //calculate for exclude vat/wht
        let vatexc = Number($('#txtVatExc').val());
        let whtexc = Number($('#txtWhtExc').val());
        totalamt += vatexc;
        totalamt -= whtexc;
        $('#txtTotalNet').val(CDbl(totalamt, 4));
    }
    function PrintData() {
        if (userRights.indexOf('P') < 0) {
            ShowMessage('You are not allow to print',true);
            return;
        }
        window.open(path + 'Acc/FormVoucher?branch=' + $('#txtBranchCode').val() + '&controlno=' + $('#txtControlNo').val());
    }

</script>