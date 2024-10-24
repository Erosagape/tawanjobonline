﻿@Code
    ViewBag.Title = "รับคืนเงินมัดจำ/ทดรองจ่าย"
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
            <div class="col-sm-6">
                <label id="lblExpCode">Expense Code:</label>                
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtSICode" class="form-control" style="width:100px" />
                    <button id="btnBrowseEmp3" class="btn btn-default" onclick="SearchData('servicecode')">...</button>
                    <input type="text" id="txtSDescription" class="form-control" style="width:100%" disabled />
                </div>
            </div>
        </div>
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridClr(true)">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
        </a>
        <div class="row">
            <div class="col-sm-12">
                <label id="lblListAppr">Approve Document</label>
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
                <label id="lblTotal">Expenses Total</label>
                 : <input type="text" id="txtSumApprove" class="form-control" value="" />
            </div>
        </div>
    </div>
    <div id="dvDetail" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <input type="radio" value="dvInfo" name="showInfo" onchange="ShowInfo()" checked />
                    <label id="lblTab1">Earnest Info</label>                                                                                                       
                    <input type="radio" value="dvExp" name="showInfo" onchange="ShowInfo()" />
                    <label id="lblTab2">Expenses</label>
                </div>                    
                <div class="modal-body">
                    <input type="hidden" id="txtExpVender" />
                    <input type="hidden" id="txtExpGroup" />
                    <input type="hidden" id="txtIsCost" />
                    <input type="hidden" id="txtVatType" />
                    <input type="hidden" id="txtVatRate" />
                    <input type="hidden" id="txtWhtRate" />
                    <div id="dvInfo">
                        <div class="row">
                            <div class="col-sm-4">
                                <label id="lblClrNo">Clearing No</label>
                                 : <br /><input type="text" id="txtClrNo" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblSlipNo">Earnest No</label>
                                 : <br /><input type="text" id="txtSlipNo" class="form-control" disabled />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblJNo">Job No</label>
                                 : <br /><input type="text" id="txtExpJobNo" class="form-control" disabled />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                <label id="lblItemNo">Item</label>
                                <br /><input type="text" id="txtItemNo" class="form-control" disabled />
                            </div>
                            <div class="col-sm-10">
                                <label id="lblVend">Vender</label>
                                :<br />
                                <input type="text" id="txtVenderName" class="form-control" disabled />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblAmt">Amount</label>
                                 : <br /><input type="text" id="txtClrNet" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblExp">Expense</label>
                                 : <br /><input type="text" id="txtExpSum" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblRet">Return</label>
                                 : <br /><input type="text" id="txtTotalNet" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblDocType">Type</label>
                                <br />
                                <select id="cboRefType" class="form-control dropdown"></select>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-4">
                                <a id="linkBook" href="#" onclick="SearchData('book')">Book Account</a><br />
                                <input type="text" class="form-control" id="txtRefBook" />
                                <input type="hidden" id="txtRecvBank" />
                                <input type="hidden" id="txtRecvBranch" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblRefNo">Ref</label>
                                :<br /> <input type="text" class="form-control" id="txtRefNo" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblRefDate">Date</label>
                                :<br /><input type="date" class="form-control" id="txtRefDate" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-2">
                                <a id="linkBank" href="#" onclick="SearchData('bank')">Bank</a><br />
                                <input type="text" id="txtRefBank" class="form-control" />
                            </div>
                            <div class="col-sm-6">
                                <br />
                                <input type="text" id="txtRefBankName" class="form-control" disabled />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblRefBranch">Branch</label>
                                <br />
                                <input type="text" id="txtRefBranch" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div id="dvExp">
                        <div class="row">
                            <div class="col-sm-3">
                                <a id="linkCode" href="#" onclick="SearchData('serviceexp')">Exp.Code</a><br />
                                <input type="text" id="txtExpCode" class="form-control" />
                            </div>
                            <div class="col-sm-6">
                                <br />
                                <input type="text" id="txtExpName" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblExpSlipNo">Exp.Slip</label>
                                <br />
                                <input type="text" id="txtExpSlip" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblExpAmt">Amount</label>
                                 <br /><input type="number" class="form-control" id="txtExpAmount" />
                            </div>
                            <div class="col-sm-3">
                                Vat <br /><input type="number" class="form-control" id="txtExpVat" onchange="CalTotal()" />
                            </div>
                            <div class="col-sm-3">
                                Wht <br /><input type="number" class="form-control" id="txtExpWht" onchange="CalTotal()" />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblNet">Net</label>
                                 <br /><input type="number" class="form-control" id="txtExpNet" onchange="CalTotal()" />
                            </div>
                        </div>
                        <select id="cboClrType" class="form-control dropdown">
                            <option value="1">Advance</option>
                            <option value="2">Cost</option>
                        </select>
                        <button id="btnAddExpCode" class="btn btn-primary" onclick="AddExpense()">Add</button>
                        <table id="dvExpense" class="table table-bordered" style="width:100%"></table>
                    </div>
                </div>
                <div class="modal-footer">         
                    <div class="row">
                        <div class="col-sm-4">
                            <label id="lblContNo">Container No</label>
                            :<br />
                            <input type="text" id="txtCTN_NO" class="form-control" />
                        </div>
                        <div class="col-sm-3">
                            <a id="linkUnit" href="#" onclick="SearchData('servunit')">Unit</a><br/>
                            <input type="text" id="txtExpUnit" class="form-control" />
                        </div>
                        <div class="col-sm-5">
                            <div style="float:left">
                                <a href="#" class="btn btn-success" id="btnUpdatePay" onclick="SaveExpense()">
                                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Expense</b>
                                </a>
                            </div>
                            <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                        </div>
                    </div>
                </div>
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
    let dtl = [];
    let expsum = 0;
    //$(document).ready(function () {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME'); 
        SetEvents();
    //});
    function SetEvents() {
        //Combos
        let lists = 'JOB_TYPE=#cboJobType';
        lists += ',PAYMENT_TYPE=#cboRefType';

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
        $('#txtSICode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtSDescription').val('');
                CallBackQueryService(path, $('#txtSICode').val(), ReadService);
            }
        });
        $('#txtExpCode').focusout(function () {
            $('#txtExpName').val('');
            CallBackQueryService(path, $('#txtExpCode').val(), ReadExpense);
        });
        $('#txtExpAmount').keydown(function (event) {
            if (event.which == 13) {
                CalVATWHT();
            }
        });
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchEmp', '#tbEmp', 'Clear By', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //Services
            CreateLOV(dv, '#frmSearchServ', '#tbServ', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchExp', '#tbExp', 'Service Code', response, 2);
            //Unit
            CreateLOV(dv, '#frmSearchUnit', '#tbUnit', 'Service Unit', response, 2);
            //bank
            CreateLOV(dv, '#frmSearchBank', '#tbBank', 'Bank', response, 2);
            //book account
            CreateLOV(dv, '#frmSearchBook', '#tbBook', 'Book Account', response, 2);
        });
    }
    function SetGridClr(isAlert) {
        if ($('#txtSICode').val() === "") {
            ShowMessage('Please input expense code', true);
            return;
        }
        arr = [];
        ShowSummary();

        let w = '';
        if ($('#txtClrBy').val() !== "") {
            w = w + '&clrby=' + $('#txtClrBy').val();
        }

        if ($('#cboJobType').val() !== "") {
            w = w + '&jtype=' + $('#cboJobType').val();
        }
        if ($('#txtClrDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtClrDateF').val());
        }
        if ($('#txtClrDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtClrDateT').val());
        }
        w = w + '&sicode=' + $('#txtSICode').val();
        w = w + '&Condition=ERN';
        $.get(path + 'clr/getclearingreport?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.data[0].Table;
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
                    { data: "InvNo", title: "InvNo" },
                    { data: "CustCode", title: "Customer" },
                    { data: "AdvNO", title: "Adv.No" },
                    {
                        data: "AdvNet", title: "Total.Adv",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "ClrNet", title: "Total.Clr",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "SlipNO", title: "Slip No" }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                $('#tbHeader tbody > tr').removeClass('selected');
                $(this).addClass('selected');

                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected                
                ShowExpense(data);
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'clr/index?BranchCode=' + data.BranchCode + '&ClrNo=' + data.ClrNo,'','');
            });
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
            tot += o.ClrNet;
            doc += (doc != '' ? ',' : '') + o.ClrNo;
        }
        $('#txtSumApprove').val(CDbl(tot, 2));
        $('#txtListApprove').val(doc);
    }
    function ApproveData(docno) {
        if (arr.length < 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        let dataApp = [];
        dataApp.push(docno);
        for (let i = 0; i < arr.length; i++) {
            dataApp.push(arr[i].BranchCode + '|' + arr[i].ClrNo + '|' + arr[i].ItemNo);
        }
        let jsonString = JSON.stringify({ data: dataApp });
        $.ajax({
            url: "@Url.Action("ReceiveEarnest", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                SetGridClr(false);
                response ? ShowMessage("Clearing Complete") : ShowMessage("Cannot Approve",true);
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
            case 'servicecode':
                SetGridSICodeFilter(path,'#tbServ','?Type=E' ,'#frmSearchServ', ReadService);
                break;
            case 'serviceexp':
                let w = '';
                if ($('#cboClrType').val() == "1") {
                    w = '&Type=A';
                } else {
                    w = '&Type=C';
                }
                SetGridSICode(path,'#tbExp',w,'#frmSearchExp', ReadExpense);
                break;
            case 'servunit':
                SetGridServUnit(path, '#tbUnit', '#frmSearchUnit', ReadUnit);
                break;
            case 'book':
                SetGridBookAccount(path, '#tbBook', '#frmSearchBook', ReadBook);
                break;
            case 'bank':
                SetGridBank(path, '#tbBank', '#frmSearchBank', ReadBank);
                break;
        }
    }
    function ReadReqBy(dt) {
        $('#txtClrBy').val(dt.UserID);
        $('#txtClrByName').val(dt.TName);
        $('#txtClrBy').focus();
    }
    function ReadBank(dt) {
        $('#txtRefBank').val(dt.Code);
        $('#txtRefBankName').val(dt.BName);
    }
    function ReadUnit(dt) {
        $('#txtExpUnit').val(dt.UnitType);
    }
    function ReadBook(dt) {
        $('#txtRefBook').val(dt.BookCode);
        $('#txtRecvBank').val(dt.BankCode);
        $('#txtRecvBranch').val(dt.BankBranch);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }

    function ReadService(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameThai);
    }
    function ReadExpense(dt) {
        $('#txtExpCode').val(dt.SICode);
        $('#txtExpGroup').val(dt.GroupCode);
        $('#txtExpName').val(dt.NameThai);
        $('#txtVatType').val(dt.IsTaxCharge);
        $('#txtIsCost').val(dt.IsExpense);
        $('#txtVatRate').val('@ViewBag.PROFILE_VATRATE');
        $('#txtWhtRate').val(dt.Rate50Tavi);
        CalVATWHT();
    }
    function ShowExpense(dr) {
        RemoveData(dr);
        $('#txtClrNo').val(dr.AdvNO == '' ? dr.ClrNo : dr.AdvNO); 
        $('#txtItemNo').val(dr.AdvItemNo);
        $('#txtSlipNo').val(dr.SlipNO);
        $('#txtExpCode').val('');
        $('#txtCTN_NO').val('');
        $('#txtExpName').val('');
        $('#txtExpSlip').val('');
        $('#txtExpJobNo').val(dr.JobNo);
        $('#txtExpUnit').val('');
        $('#txtExpVender').val(dr.VenderCode);
        $('#txtVenderName').val(dr.VenderName);
        $('#txtExpGroup').val('');
        $('#txtExpAmount').val(0);
        $('#txtIsCost').val(0);
        $('#txtVatType').val(0);
        $('#txtVatRate').val(0);
        $('#txtWhtRate').val(0);
        $('#txtExpVat').val(0);
        $('#txtExpWht').val(0);
        $('#txtExpNet').val(0);
        $('#dvExpense').empty();
        $('#txtClrNet').val(CDbl(dr.ClrNet,4));
        $('#txtExpSum').val(0);
        $('#txtTotalNet').val(CDbl(dr.ClrNet,4));
        $('#cboRefType').val('CA');
        $('#txtRefBook').val('');
        $('#txtRefBank').val('');
        $('#txtRefBranch').val('');
        $('#txtRefBankName').val('');
        $('#txtRefDate').val('');
        $('#txtRefNo').val('');
        $('#txtRecvBank').val('');
        $('#txtRecvBranch').val('');

        expsum = 0;
        dtl = [];
        AddData(dr); //callback function from caller
        ShowInfo();

        $('#dvDetail').modal('show');
    }
    function AddExpense() {
        let dv = document.getElementById("dvExpense");
        let desc = $('#txtExpCode').val() + '-' + $('#txtExpName').val() + ($('#txtExpSlip').val() !== '' ? '#' + $('#txtExpSlip').val() : '');

        let html = '<tr>';
        html += '<td style="width:80%">'+desc+'</td>';
        html += '<td style="width:20%">' + ShowNumber($('#txtExpNet').val(), 2) + '</td>';
        html += '</tr>';

        dv.insertAdjacentHTML('beforeend',html);

        expsum += Number($('#txtExpNet').val());
        $('#txtExpSum').val(CDbl(expsum, 2));
        $('#txtTotalNet').val(CDbl(Number($('#txtClrNet').val()) - expsum, 2));

        dtl.push(GetDataDetail());
    }
    function SaveEarnest() {

        let obj = {
            BranchCode:$('#txtBranchCode').val(),
            ControlNo:'',
            VoucherDate:CDateEN(GetToday()),
            TRemark:'**Refund Clearing** ' + $('#txtClrNo').val() + '/' + $('#txtItemNo').val() + ' #'+$('#txtSlipNo').val(),
            RecUser: user,
            RecDate: CDateEN(GetToday()),
            RecTime: GetTime(),
            PostedBy:'',
            PostedDate:null,
            PostedTime:null,
            CancelReson:'',
            CancelProve:'',
            CancelDate:null,
            CancelTime: null,
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
                    SavePayment(response.result.data);
                    SaveDocument(response.result.data);
                    return;
                }
                ShowMessage(response.result.msg);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });

    }
    function SaveExpense() {       
        if ($('#txtRefBook').val() == '') {
            ShowMessage('Please select book account', true);
            return;
        }
        if ($('#txtRefBank').val() == '') {
            ShowMessage('Please input bank and branch', true);
            return;
        }
        if ($('#txtRefDate').val() == '') {
            ShowMessage('Please input reference date', true);
            return;
        }
        if ($('#txtRefNo').val() == '') {
            ShowMessage('Please input reference number', true);
            return;
        }
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            SaveEarnest();
        });
    }
    function CalTotal() {
        let amt = CDbl($('#txtExpAmount').val(),4);
        let vat = CDbl($('#txtExpVat').val(),4);
        let wht = CDbl($('#txtExpWht').val(),4);
        let net = CDbl($('#txtExpNet').val(),4);
        let type = $('#txtVatType').val();
        if (type == ''||type=='0') type = '1';
        if (type == '2') {
            //$('#txtExpAmount').val(CDbl(CNum(net) - CNum(vat) ,4));
            //$('#txtExpNet').val(CDbl(net,4));
        }
        if (type == '1') {
            $('#txtExpNet').val(CDbl(CNum(amt) + CNum(vat) - CNum(wht),4));
            $('#txtExpAmount').val(CDbl(amt,4));
        }
    }
    function CalVATWHT() {
        let type = $('#txtVatType').val();
        if (type == ''||type=='0') type = '1';
        let amt = CDbl($('#txtExpAmount').val(),4);
        if (type == '2') {
            amt = CDbl(Number($('#txtExpNet').val())+Number($('#txtExpWht').val()),4);
        }
        let vatrate = CDbl($('#txtVatRate').val(),4)*100;
        let whtrate = CDbl($('#txtWhtRate').val(),4);
        let vat = 0;
        let wht = 0;
        if (type == "2") {
            let base = amt * 100 / (100 + Number(vatrate));
            vat = base * vatrate * 0.01;
            wht = base * whtrate * 0.01;
            $('#txtExpAmount').val(CDbl(CNum(base),2));
            $('#txtExpNet').val(CDbl(CNum(base) + CNum(vat) - CNum(wht), 2));
        }
        if (type == "1") {
            vat = amt * vatrate * 0.01;
            wht = amt * whtrate * 0.01;
        }
        $('#txtExpVat').val(CDbl(vat,4));
        $('#txtExpWht').val(CDbl(wht,4));
        CalTotal();
    }
    function GetDataHeader(controlno) {
        let dt = {
            BranchCode: $('#txtBranchCode').val(),
            ClrNo: '',
            ClrDate: CDateEN(GetToday()),
            ClearanceDate: null,
            EmpCode: user,
            AdvRefNo: null,
            AdvTotal: 0,
            JobType: $('#cboJobType').val(),
            JNo: null,
            InvNo: null,
            ClearType: $('#cboClrType').val(),
            ClearFrom: 0,
            DocStatus: 3,
            TotalExpense: 0,
            TRemark: '**Earnest clearing** ' + $('#txtSlipNo').val(),
            ApproveBy: user,
            ApproveDate: CDateEN(GetToday()),
            ApproveTime: GetTime(),
            ReceiveBy: user,
            ReceiveDate: CDateEN(GetToday()),
            ReceiveTime: GetTime(),
            ReceiveRef: controlno,
            CancelReson: '',
            CancelProve: '',
            CancelDate: null,
            CancelTime: null,
            CoPersonCode: '',
            CTN_NO: $('#txtCTN_NO').val(),
            ClearTotal: 0,
            ClearVat: 0,
            ClearWht: 0,
            ClearNet: 0,
            ClearBill: 0,
            ClearCost: 0
        };
        return dt;
    }
    function GetDataDetail() {
        let dt = {
            BranchCode: $('#txtBranchCode').val(),
            ClrNo: '',
            ItemNo: 0,
            LinkItem: 0,
            SICode: $('#txtExpCode').val(),
            STCode:  $('#txtExpGroup').val(),
            SDescription: $('#txtExpName').val(),
            VenderCode: $('#txtExpVender').val(),
            Qty: 1,
            UnitCode: $('#txtExpUnit').val(),
            CurrencyCode: '@ViewBag.PROFILE_CURRENCY',
            CurRate: 1,
            UnitPrice: $('#txtIsCost').val()=="1" ? 0 : $('#txtExpAmount').val(),
            FPrice: $('#txtIsCost').val()=="1" ? 0 : $('#txtExpAmount').val(),
            BPrice: $('#txtIsCost').val()=="1"  ? 0 : $('#txtExpAmount').val(),
            QUnitPrice: 0,
            QFPrice: 0,
            QBPrice: 0,
            UnitCost: $('#txtExpAmount').val(),
            FCost: $('#txtExpAmount').val(),
            BCost: $('#txtExpAmount').val(),
            ChargeVAT: $('#txtExpVat').val(),
            Tax50Tavi: $('#txtExpWht').val(),
            AdvNO: $('#txtClrNo').val(),
            AdvItemNo: $('#txtItemNo').val(),
            AdvAmount: 0,
            UsedAmount: $('#txtExpAmount').val(),
            IsQuoItem: 0,
            SlipNO: $('#txtExpSlip').val(),
            Remark: '**' + $('#txtSlipNo').val(),
            IsLtdAdv50Tavi: 0,
            Pay50TaviTo: '',
            NO50Tavi: '',
            Date50Tavi: null,
            VenderBillingNo: '',
            AirQtyStep: '',
            StepSub: '',
            LinkBillNo : '',
            JobNo : $('#txtExpJobNo').val(),
            VATType : $('#txtVatType').val(),
            VATRate: $('#txtVatRate').val()*100,
            Tax50TaviRate : $('#txtWhtRate').val(),
            IsDuplicate: 0,
            QNo: '',
            FNet: $('#txtExpNet').val(),
            BNet: $('#txtExpNet').val()
        };
        return dt;
    }
    function SavePayment(docno) {
        let prType = CNum($('#txtTotalNet').val()) > 0 ? 'R' : 'P';
        let amt = CNum(Math.abs($('#txtTotalNet').val()));
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            ControlNo: docno,
            ItemNo: 0,
            PRVoucher:'',
            PRType:prType,
            ChqNo:$('#txtRefNo').val(),
            BookCode:$('#txtRefBook').val(),
            BankCode:$('#txtRefBank').val(),
            BankBranch:$('#txtRefBranch').val(),
            ChqDate:CDateEN($('#txtRefDate').val()),
            CashAmount: ($('#cboRefType').val() == "CA" ? amt : 0),
            ChqAmount: ($('#cboRefType').val() == "CH" || $('#cboRefType').val() == "CU" ? amt : 0),
            CreditAmount: ($('#cboRefType').val() == "CR" ? amt : 0),
            SumAmount: amt,
            CurrencyCode: '@ViewBag.PROFILE_CURRENCY',
            ExchangeRate: 1,
            TotalAmount: amt,
            VatExc: 0,
            VatInc: 0,
            WhtExc: 0,
            WhtInc: 0,
            TotalNet: amt,
            IsLocal:0,
            ChqStatus:'C',
            TRemark:'**Auto Clearing Earnest** #' + $('#txtSlipNo').val(),
            PayChqTo:'',
            DocNo:$('#txtClrNo').val(),
            SICode:$('#txtSICode').val(),
            RecvBank:$('#txtRecvBank').val(),
            RecvBranch: $('#txtRecvBranch').val(),
            acType: $('#cboRefType').val(),
            ForJNo: $('#txtExpJobNo').val()
        };

            let jsonText = JSON.stringify({ data:[ obj ]});
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetVoucherSub", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data !== null) {                        
                        return;
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
    }
    function SaveDocument(docno) {
        let obj = {
            BranchCode:$('#txtBranchCode').val(),
            ControlNo:docno,
            ItemNo:0,
            DocType:'CLR',
            DocNo:$('#txtClrNo').val()+ '#' + $('#txtItemNo').val(),
            DocDate:CDateEN(GetToday()),
            CmpType:'V',
            CmpCode:$('#txtExpVender').val(),
            CmpBranch:'',
            PaidAmount:CNum(Math.abs($('#txtTotalNet').val())),
            TotalAmount: CNum(Math.abs($('#txtTotalNet').val())),
            acType: $('#txtDocacType').val()
        };
        let jsonText = JSON.stringify({ data:[ obj ]});
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetVoucherDoc", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.data !== null) {
                    if ($('#txtExpSum').val() > 0) {
                        SaveClearHeader(response.result.data);
                    }
                    ApproveData(response.result.data);
                    return;
                }
                ShowMessage(response.result.msg);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function SaveClearHeader(controlno) {
        let obj = GetDataHeader(controlno);
        let jsonString = JSON.stringify({ data: obj });
        //ShowMessage(jsonString);
        $.ajax({
            url: "@Url.Action("SetClrHeader", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    SaveClearDetail(response.result.data);                    
                }
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
        return;
    }
    function SaveClearDetail(docno) {
        for (let i = 0; i < dtl.length; i++) {
            dtl[i].ClrNo = docno;
        }
        let jsonString = JSON.stringify({ data: dtl });
        //ShowMessage(jsonString);
        $.ajax({
            url: "@Url.Action("SaveClearDetail", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    ShowMessage(response.result.msg);                    
                }
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function ShowInfo() {
        let chk = $('input:radio[name=showInfo]:checked').val();
        switch (chk) {
            case 'dvInfo':
                $('#dvInfo').show();
                $('#dvExp').hide();
                break;
            case 'dvExp':
                $('#dvInfo').hide();
                $('#dvExp').show();
                break;
        }
    }
</script>