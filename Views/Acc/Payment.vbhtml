﻿@Code
    ViewBag.Title = "Expense Payment"
End Code
<style>
    @@media only screen and ( max-width:600px ) {
        #myTabs {
            display: none;
        }

        #mySelects {
            width: 100%;
            display: block !important;
        }
    }
</style>
<div class="panel-body">
    <div class="container">
        <input type="hidden" id="txtControlNo" />
        <ul id="myTabs" class="nav nav-tabs">
            <li class="active"><a id="linkTab1" data-toggle="tab" href="#tab1">Select document</a></li>
            <li><a id="linkTab2" data-toggle="tab" href="#tab2">Payment Info</a></li>
            <li><a id="linkTab3" data-toggle="tab" href="#tab3">Payment Details</a></li>
        </ul>
        <select id="mySelects" class="form-control" style="display:none" onchange="ChangeTab(this.value);">
            <option id="optTab1" value="#tab1" selected>STEP 1 - Select Document</option>
            <option id="optTab2" value="#tab2">STEP 2 - Entry Payment</option>
            <option id="optTab3" value="#tab3">STEP 3 - Confirm Payment</option>
        </select>
        <div class="tab-content">
            <div id="tab1" class="tab-pane fade in active">
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
                        <label id="lblDateFrom">Due Date From:</label>
                        <input type="date" class="form-control" id="txtDocDateF" />
                    </div>
                    <div class="col-sm-4">
                        <label id="lblDateTo">Due Date To:</label>
                        <input type="date" class="form-control" id="txtDocDateT" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblCurrency">Request Currency :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" class="form-control" id="txtCurrencyCode" style="width:20%" />
                            <button id="btnBrowseCur" class="btn btn-default" onclick="SearchData('currency')">...</button>
                            <input type="text" class="form-control" id="txtCurrencyName" style="width:100%" disabled />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblPayFor">Payment For :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" class="form-control" id="txtVenCode" style="width:20%" />
                            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('vender')">...</button>
                            <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
                            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSeacrh">Search</b>
                        </a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <table id="tbHeader" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>DocNo</th>
                                    <th class="desktop">DocDate</th>
                                    <th class="desktop">VenCode</th>
                                    <th class="desktop">EmpCode</th>
                                    <th class="all">Ref</th>
                                    <th class="desktop">PoNo</th>
                                    <th class="desktop">Amount</th>
                                    <th class="desktop">WT</th>
                                    <th class="desktop">VAT</th>
                                    <th class="all">NET</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <label id="lblListAppr">Payment Document :</label>                        
                        <br /><input type="text" id="txtListApprove" class="form-control" value="" disabled />
                    </div>
                </div>
            </div>
            <div id="tab2" class="tab-pane fade">
                <div class="row">
                    <div class="col-sm-3 table-bordered" id="dvCash">
                        <b id="linkCash">Cash/Transfer :</b><input type="text" id="txtAdvCash" class="form-control" value="" />
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <label id="lblBookCA">Book A/C:</label>
                                    <br /><input type="text" id="txtBookCash" class="form-control" value="" />
                                </td>
                                <td>
                                    <br />
                                    <input type="button" class="btn btn-default" onclick="SearchData('cashacc')" value="..." />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <label id="lblRefNoCA">Trans.No:</label>
                        <input type="text" id="txtRefNoCash" class="form-control" value="" />
                        <br />
                        <label id="lblTranDateCA">Trans.Date:</label>
                        <input type="date" id="txtCashTranDate" class="form-control" disabled />
                        <label id="lblTranTimeCA">Trans.Time:</label>
                        <input type="text" id="txtCashTranTime" class="form-control" value="" />
                        <br />
                        <label id="lblBankCA">To Bank:</label>
                        <select id="cboBankCash" class="form-control"></select>
                        <label id="lblBranchCA">To Branch:</label>
                        <input type="text" id="txtBankBranchCash" class="form-control" />
                        <label id="lblPayCA">Pay To:</label>
                        <input type="text" id="txtCashPayTo" class="form-control" />
                        <br />
                        <input type="hidden" id="fldBankCodeCash" />
                        <input type="hidden" id="fldBankBranchCash" />
                    </div>
                    <div class="col-sm-3 table-bordered" id="dvChqCash">
                        <b id="linkChqCash">Company Chq :</b><input type="text" id="txtAdvChqCash" class="form-control" value="" />
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <label id="lblBookCH">Book A/C:</label>
                                    <br /><input type="text" id="txtBookChqCash" class="form-control" value="" />
                                </td>
                                <td>
                                    <br />
                                    <input type="button" class="btn btn-default" onclick="SearchData('chqacc')" value="..." />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <label id="lblRefNoCH">Chq No:</label>
                        <input type="text" id="txtRefNoChqCash" class="form-control" value="" />
                        <br />
                        <label id="lblTranDateCH">Chq Date:</label>
                        <input type="date" id="txtChqCashTranDate" class="form-control" />
                        <br />
                        <input type="checkbox" id="chkStatusChq" />
                        <label id="lblStatusCH" for="chkStatusChq">Cashier Cheque</label>
                        <br />
                        <label id="lblBankCH">Chq Bank:</label>
                        <select id="cboBankChqCash" class="form-control"></select>
                        <label id="lblBranchCH">Chq Branch:</label>
                        <input type="text" id="txtBankBranchChqCash" class="form-control" />
                        <label id="lblPayCH">Pay To:</label>
                        <input type="text" id="txtChqCashPayTo" class="form-control" />
                        <br />
                        <input type="hidden" id="fldBankCodeChqCash" />
                        <input type="hidden" id="fldBankBranchChqCash" />
                    </div>
                    <div class="col-sm-3 table-bordered" id="dvChq">
                        <b id="linkChqCust">Customer Chq : </b><input type="text" id="txtAdvChq" class="form-control" value="" />
                        <br />
                        <a id="lblRefNoCU" href="../acc/cheque" target="_blank">Chq No:</a><input type="text" id="txtRefNoChq" class="form-control" value="" disabled />
                        <input type="button" class="btn" id="btnBrowseChq" value="..." onclick="SearchData('chequecust')" />
                        <br />
                        <label id="lblTranDateCU">Chq Date:</label>
                        <input type="date" id="txtChqTranDate" class="form-control" />
                        <br />
                        <input type="checkbox" id="chkIsLocal" />
                        <label id="lblStatusCU" for="chkIsLocal">Local</label>
                        <br />
                        <label id="lblBankCU">Issue Bank:</label>
                        <select id="cboBankChq" class="form-control"></select>
                        <label id="lblBranchCU">Issue Branch:</label>
                        <input type="text" id="txtBankBranchChq" class="form-control" />
                        <label id="lblPayCU">Pay To:</label>
                        <input type="text" id="txtChqPayTo" class="form-control" />
                        <br />
                    </div>
                    <div class="col-sm-3 table-bordered" id="dvCred">
                        <div>
                            <b id="linkCred">Credit : </b><input type="text" id="txtAdvCred" class="form-control" value="" />
                            <br />
                            <a href="#" id="lblRefNoCR" onclick="SearchData('document')">Ref No</a>:<input type="text" id="txtRefNoCred" class="form-control" value="" disabled />
                            <br />
                            <label id="lblTranDateCR">Ref Date:</label>
                            <input type="date" id="txtCredTranDate" class="form-control" />
                            <label id="lblPayCR">Pay To:</label>
                            <input type="text" id="txtCredPayTo" class="form-control" />
                        </div>
                        <div style="background-color:greenyellow;padding:10px 10px 10px 10px;margin:10px 10px 10px 10px;">
                            <b id="linkBal">Balance</b>
                            <br />
                            <label id="lblForCA">For Cash/Transfer :</label>
                            <br />
                            <input type="number" id="txtCashBal" class="form-control" disabled />
                            <label id="lblForCH">For Cheque : </label>
                            <br /> <input type="number" id="txtChqCashBal" class="form-control" disabled />
                        </div>
                    </div>
                </div>
            </div>
            <div id="tab3" class="tab-pane fade">
                <div class="row">
                    <div class="col-sm-12">
                        <table id="tbDetail" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>Doc.No</th>
                                    <th class="desktop">Doc.Type</th>
                                    <th class="all">Doc.Date</th>
                                    <th class="desktop">Pay.Type</th>
                                    <th class="desktop">For</th>
                                    <th class="desktop">Branch</th>
                                    <th class="desktop">Doc.Total</th>
                                    <th class="all">Paid.Total</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label id="lblPayDate">Payment Date : </label>
                        <input type="date" id="txtPaymentDate" class="form-control" value="" />
                    </div>
                    <div class="col-sm-2">
                        <label id="lblPayTotal">Payment Total : </label>
                        <input type="text" id="txtSumApprove" class="form-control" value="" />
                    </div>
                    <div class="col-sm-2">
                        <label id="lblWTTotal">W/T Total : </label>
                        <input type="text" id="txtSumWHTax" class="form-control" value="" />
                    </div>
                    <div class="col-sm-6">
                        <label id="lblRemark">Remark : </label>
                        <input type="text" id="txtTRemark" class="form-control" value="" />
                    </div>
                </div>
                <a href="#" class="btn btn-success" id="btnSave" onclick="ApproveData()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Payment</b>
                </a>
            </div>
        </div>
    </div>
    <did id="frmSearchChq" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <label id="lblCaptionChq">Select Cheque Onhand</label>
                </div>
                <div class="modal-body">
                    <table id="tbChq" class="table table-responsive">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>ChqNo</th>
                                <th class="all">ChqDate</th>
                                <th class="desktop">ChqAmount</th>
                                <th class="desktop">AmountUsed</th>
                                <th class="all">AmountRemain</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button id="btnHide" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </did>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let arr = [];
    let list = [];
    let docno = '';
    //$(document).ready(function () {
    SetEvents();
    //});
    function ChangeTab(id) {
        $('#myTabs a[href="' + id + '"]').tab('show');
    }
    function SetEvents() {

        let cbos = ['#cboBankCash', '#cboBankChqCash', '#cboBankChq'];
        loadBank(cbos, path);
        //default values
        $('#txtCurrencyCode').val('THB');
        ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');

        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocDateF').val(GetFirstDayOfMonth());
        $('#txtDocDateT').val(GetLastDayOfMonth());
        //Events
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtBookCash').focusout(function (event) {
            if (true) {
                $('#fldBankCodeCash').val('');
                $('#fldBankBranchCash').val('');
                CallBackQueryBookAccount(path, $('#txtBranchCode').val(), $('#txtBookCash').val(), ReadBookCash);
            }
        });
        $('#txtBookChqCash').focusout(function (event) {
            if (true) {
                $('#fldBankCodeChqCash').val('');
                $('#fldBankBranchChqCash').val('');
                CallBackQueryBookAccount(path, $('#txtBranchCode').val(), $('#txtBookChqCash').val(), ReadBookChq);
            }
        });
        $('#txtCurrencyCode').focusout(function (event) {
            if (true) {
                $('#txtCurrencyName').val('');
                ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            }
        });
        $('#txtCustBranch').focusout(function (event) {
            if (true) {
                $('#txtCustName').val('');
                ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");

            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 3);
            CreateLOV(dv, '#frmSearchReq', '#tbReq', 'Request By', response, 2);
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchBookCash', '#tbBookCash', 'Book Accounts', response, 2);
            CreateLOV(dv, '#frmSearchBookChq', '#tbBookChq', 'Book Accounts', response, 2);
            CreateLOV(dv, '#frmSearchDoc', '#tbDoc', 'Account Receivables', response, 5);
        });
    }
    function ClearData() {
        $('#txtAdvCash').val('');
        $('#txtBookCash').val('');
        $('#txtRefNoCash').val('');
        $('#txtCashTranDate').val(CDateEN(GetToday()));
        $('#txtCashTranTime').val('');
        $('#cboBankCash').val('');
        $('#txtBankBranchCash').val('');
        $('#txtCashPayTo').val('');
        $('#txtAdvChqCash').val('');
        $('#txtBookChqCash').val('');
        $('#txtRefNoChqCash').val('');
        $('#txtChqCashTranDate').val('');
        $('#chkStatusChq').prop('checked', false);
        $('#cboBankChqCash').val('');
        $('#txtBankBranchChqCash').val('');
        $('#txtChqCashPayTo').val('');
        $('#txtAdvChq').val('');
        $('#txtRefNoChq').val('');
        $('#txtChqTranDate').val('');
        $('#chkIsLocal').prop('checked', false);
        $('#cboBankChq').val('');
        $('#txtBankBranchChq').val('');
        $('#txtChqPayTo').val('');
        $('#txtAdvCred').val('');
        $('#txtRefNoCred').val('');
        $('#txtCredTranDate').val('');
        $('#txtCredPayTo').val('');
        $('#txtPaymentDate').val(CDateEN(GetToday()));
        $('#txtSumApprove').val('');
        $('#txtSumWHTax').val('');
        $('#txtTRemark').val('');
    }
    function SetGridAdv(isAlert) {
        arr = [];
        ClearData();
        ShowSummary();
        docno = '';

        let w = '';
        if ($('#txtVenCode').val() !== "") {
            w = w + '&vencode=' + $('#txtVenCode').val();
        }
        if ($('#txtDocDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        w = w + '&currency=' + $('#txtCurrencyCode').val();
        w = w + '&Type=NOPAY&Status=A';
        $.get(path + 'acc/getpayment?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.payment.header.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if(isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.payment.header;
            $('#tbHeader').DataTable().destroy();
            $('#tbHeader').empty();
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "DocNo", title: "Pay.No" },
                    {
                        data: "DocDate", title: "Due Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "VenCode", title: "Vender" },
                    { data: "ContactName", title: "Contact" },
                    { data: "RefNo", title: "Ref.No" },
                    { data: "PoNo", title: "PO.No" },
                    {
                        data: "TotalExpense", title: "Amount",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "TotalVAT", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "TotalTax", title: "Tax",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "TotalNet", title: "Net",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    }
                ],
                responsive: true,
                destroy: true
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
                window.open(path + 'acc/expense?BranchCode=' + data.BranchCode + '&DocNo=' + data.DocNo,'','');
            });
        });
    }
    function SetStatusInput(d, bl, ctl) {
        if (bl == false) {
            $(d).css("background-color", "darkgrey");
            $(d + ' :input').attr('disabled', true);
        } else {
            $(d).css("background-color", "lightgreen");
            $(d + ' :input').removeAttr('disabled');
            if (ctl !== null) {
                $(ctl).attr('disabled', true);
            }
        }
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
        let cash = 0;
        let chqcash = 0;
        let chqcust = 0;
        let cred = 0;
        let wtax = 0;
        let doc = '';
        list = [];

        for (let i = 0; i < arr.length; i++) {

            let o = arr[i];
            wtax += (o.TotalTax > 0 ? o.TotalTax : 0);
            tot += (o.TotalExpense > 0 ? o.TotalExpense+o.TotalVAT : 0);
            cash += (o.PayType == 'CA' ? o.TotalNet : 0);
            chqcash += (o.PayType == 'CH' ? o.TotalNet : 0);
            chqcust += (o.PayType == 'CU' ? o.TotalNet : 0);
            cred += (o.PayType =='CR' ? o.TotalNet : 0);
            doc += (doc != '' ? ',' : '') + o.DocNo;
            if (o.TotalNet > 0) {
                let obj = {
                    BranchCode: $('#txtBranchCode').val(),
                    ControlNo: null,
                    ItemNo: i + 1,
                    DocType: 'PAY',
                    DocNo: o.DocNo,
                    DocDate: CDateEN(o.DocDate),
                    CmpType: 'V',
                    CmpCode: o.VenCode,
                    CmpBranch: '',
                    PaidAmount: CDbl(o.TotalNet, 2),
                    TotalAmount: CDbl(CNum(o.TotalExpense)+CNum(o.TotalVAT), 2),
                    acType:o.PayType
                };
                list.push(obj);
            }
        }
        //show selected details
        let tb=$('#tbDetail').DataTable({
            data: list,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "DocNo", title: "Doc.No" },
                { data: "DocType", title: "Type " },
                {
                    data: "DocDate", title: "Date",
                    render: function (data) {
                        return CDateEN(data);
                    }
                },
                { data: "CmpType", title: "For" },
                { data: "CmpCode", title: "Customer" },
                { data: "CmpBranch", title: "Branch" },
                { data: "TotalAmount", title: "Doc.Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "PaidAmount", title: "Paid",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                }
            ],
            responsive:true,
            destroy: true
            , pageLength: 100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');

        SetStatusInput('#dvCash', (cash > 0 ? true : false), '#txtAdvCash');
        $('#txtAdvCash').val(CDbl(cash, 2));

        SetStatusInput('#dvChqCash', (chqcash > 0 ? true : false), '#txtAdvChqCash');
        $('#txtAdvChqCash').val(CDbl(chqcash, 2));

        SetStatusInput('#dvChq', (chqcust > 0 ? true : false), '#txtAdvChq');
        $('#txtAdvChq').val(CDbl(chqcust, 2));
        $('#txtRefNoChq').attr('disabled', 'disabled');

        SetStatusInput('#dvCred', (cred > 0 ? true : false), '#txtAdvCred');
        $('#txtAdvCred').val(CDbl(cred, 2));

        $('#txtSumApprove').val(CDbl(tot, 2));
        $('#txtSumWHTax').val(CDbl(wtax, 2));

        $('#txtListApprove').val(doc);
        $('#txtTRemark').val(doc);
    }
    function GetSumPayment(type) {
        let filter_data = arr.filter(function (data) {
            return data.PayType == type
        });
        let filter_sum = {
            sumamount: 0,
            currencycode: '',
            exchangerate: 1,
            totalamount: 0,
            vatinc: 0,
            vatexc: 0,
            whtinc: 0,
            whtexc: 0,
            totalnet: 0
        };
        for (let i = 0; i < filter_data.length; i++) {
            filter_sum.currencycode = filter_data[i].CurrencyCode;
            filter_sum.exchangerate = filter_data[i].ExchangeRate;
            filter_sum.sumamount += Number(filter_data[i].TotalExpense);
            filter_sum.totalamount += Number(filter_data[i].TotalExpense + filter_data[i].TotalVAT);
            filter_sum.totalnet += Number(filter_data[i].TotalNet);
            filter_sum.vatinc += Number(0);
            filter_sum.vatexc += Number(filter_data[i].TotalVAT);
            filter_sum.whtinc += Number(0);
            filter_sum.whtexc += Number(filter_data[i].TotalTax);
        }
        return filter_sum;
    }
    function SavePayment() {
        let oData = [];
        let i = 0;
        if ($('#txtAdvCash').val() > 0) {
            i = i + 1;
            let sum_cash = GetSumPayment('CA');
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType: 'P',
                ChqNo: '',
                BookCode: $('#txtBookCash').val(),
                BankCode: $('#fldBankCodeCash').val(),
                BankBranch: $('#fldBankBranchCash').val(),
                ChqDate: '',
                CashAmount: CNum($('#txtAdvCash').val()),
                ChqAmount: 0,
                CreditAmount: 0,
                SumAmount: sum_cash.sumamount,
                CurrencyCode: sum_cash.currencycode,
                ExchangeRate: sum_cash.exchangerate,
                TotalAmount: sum_cash.totalamount,
                VatInc: sum_cash.vatinc,
                VatExc: sum_cash.vatexc,
                WhtInc: sum_cash.whtinc,
                WhtExc: sum_cash.whtexc,
                TotalNet: sum_cash.totalnet,
                IsLocal: 0,
                ChqStatus: '',
                TRemark: $('#txtCashTranDate').val() + '-' + $('#txtCashTranTime').val(),
                PayChqTo: $('#txtCashPayTo').val(),
                DocNo: $('#txtRefNoCash').val(),
                SICode: '',
                RecvBank: $('#cboBankCash').val(),
                RecvBranch: $('#txtBankBranchCash').val(),
                acType : 'CA'
            });
        }
        if ($('#txtAdvChq').val() > 0) {
            i = i + 1;
            let sum_chq = GetSumPayment('CU');
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType: 'P',
                ChqNo: $('#txtRefNoChq').val(),
                BookCode: '',
                BankCode: '',
                BankBranch: '',
                ChqDate: CDateEN($('#txtChqTranDate').val()),
                CashAmount: 0,
                ChqAmount: CNum($('#txtAdvChq').val()),
                CreditAmount: 0,
                SumAmount: sum_chq.sumamount,
                CurrencyCode: sum_chq.currencycode,
                ExchangeRate: sum_chq.exchangerate,
                TotalAmount: sum_chq.totalamount,
                VatInc: sum_chq.vatinc,
                VatExc: sum_chq.vatexc,
                WhtInc: sum_chq.whtinc,
                WhtExc: sum_chq.whtexc,
                TotalNet: sum_chq.totalnet,
                IsLocal: $('#chkStatusChq').prop('checked') == true ? 1 : 0,
                ChqStatus:'C',
                TRemark: '',
                PayChqTo: $('#txtChqPayTo').val(),
                DocNo: '',
                SICode: '',
                RecvBank: $('#cboBankChq').val(),
                RecvBranch: $('#txtBankBranchChq').val(),
                acType: 'CU'
            });
        }
        if ($('#txtAdvChqCash').val() > 0) {
            i = i + 1;
            let sum_chqcash = GetSumPayment('CH');
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType: 'P',
                ChqNo: $('#txtRefNoChqCash').val(),
                BookCode: $('#txtBookChqCash').val(),
                BankCode: $('#fldBankCodeChqCash').val(),
                BankBranch: $('#fldBankBranchChqCash').val(),
                ChqDate: CDateEN($('#txtChqCashTranDate').val()),
                CashAmount: 0,
                ChqAmount: CNum($('#txtAdvChqCash').val()),
                CreditAmount: 0,
                SumAmount: sum_chqcash.sumamount,
                CurrencyCode: sum_chqcash.currencycode,
                ExchangeRate: sum_chqcash.exchangerate,
                TotalAmount: sum_chqcash.totalamount,
                VatInc: sum_chqcash.vatinc,
                VatExc: sum_chqcash.vatexc,
                WhtInc: sum_chqcash.whtinc,
                WhtExc: sum_chqcash.whtexc,
                TotalNet: sum_chqcash.totalnet,
                IsLocal: '',
                ChqStatus: $('#chkStatusChq').prop('checked') == true ? 'R' : 'P',
                TRemark: '',
                PayChqTo: $('#txtChqCashPayTo').val(),
                DocNo: '',
                SICode: '',
                RecvBank: $('#cboBankChqCash').val(),
                RecvBranch: $('#txtBankBranchChqCash').val(),
                acType: 'CH'
            });
        }
        if ($('#txtAdvCred').val() > 0) {
            i = i + 1;
            let sum_cr = GetSumPayment('CR');
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType: 'P',
                ChqNo: '',
                BookCode: '',
                BankCode: '',
                BankBranch: '',
                ChqDate: CDateEN($('#txtCredTranDate').val()),
                CashAmount: 0,
                ChqAmount: 0,
                CreditAmount: CNum($('#txtAdvCred').val()),
                SumAmount: sum_cr.sumamount,
                CurrencyCode: sum_cr.currencycode,
                ExchangeRate: sum_cr.exchangerate,
                TotalAmount: sum_cr.totalamount,
                VatInc: sum_cr.vatinc,
                VatExc: sum_cr.vatexc,
                WhtInc: sum_cr.whtinc,
                WhtExc: sum_cr.whtexc,
                TotalNet: sum_cr.totalnet,
                IsLocal: 0,
                ChqStatus: '',
                TRemark: '',
                PayChqTo: $('#txtCredPayTo').val(),
                DocNo: $('#txtRefNoCred').val(),
                SICode: '',
                RecvBank: '',
                RecvBranch: '',
                acType: 'CR',
                ForJNo: ''
            });
        }
        if (oData.length > 0) {
            let jsonString = JSON.stringify({ data: oData });
            $.ajax({
                url: "@Url.Action("SetVoucherSub", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    if (response.result.data != null) {
                        SaveDetail();
                    }
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('No data to approve',true);
        }
    }
    function SaveClearing() {
        if (list.length > 0) {
            let str = '';
            for (let i = 0; i < list.length; i++) {
                let o = list[i];
                str += (str !== '' ? ',' : '') + o.DocNo;
            }
            $.get(path + 'clr/setclrbypay?branch=' + $('#txtBranchCode').val() + '&ref=' + docno + '&code=' + str + '&status=Y')
                .done(function (r) {
                    alert(r.clr.result);
                })
                .error(function (e) {
                    alert(e);
                });
        }
    }
    function SaveDetail() {
        if (list.length > 0) {
            for (let i = 0; i < list.length; i++) {
                let o = list[i];
                o.ControlNo = docno;
            }
            let jsonString = JSON.stringify({ data: list });
            $.ajax({
                url: "@Url.Action("SetVoucherDoc", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    if (response.result.data != null) {
                        //SaveClearing();
                        SetGridAdv(false);
                        ShowMessage(response.result.msg);
                    }
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        }
    }
    function ApproveData() {
        if (arr.length < 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        if (CheckBalance() == false) {
            return;
        }
        let oHeader = {
            BranchCode: $('#txtBranchCode').val(),
            ControlNo: '',
            VoucherDate: CDateEN($('#txtPaymentDate').val()),
            TRemark: $('#txtTRemark').val(),
            RecUser: user,
            RecDate: CDateEN(GetToday()),
            RecTime: CDateEN(GetTime()),
            PostedBy: '',
            PostedDate: '',
            PostedTime: '',
            CancelReson: '',
            CancelProve: '',
            CancelDate: '',
            CancelTime: '',
            CustCode: $('#txtCustCode').val(),
            CustBranch: $('#txtCustBranch').val(),
            PostRefNo: ''
        };
        docno = '';
        let jsonString = JSON.stringify({ data: oHeader });
        $.ajax({
            url: "@Url.Action("SetVoucherHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data != null) {
                    docno = response.result.data;
                    if (docno != '') {
                        $('#txtControlNo').val(docno);
                        SavePayment();
                    }
                }
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
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'cashacc':
                SetGridBookAccount(path, '#tbBookCash', '#frmSearchBookCash', ReadBookCash);
                break;
            case 'chqacc':
                SetGridBookAccount(path, '#tbBookChq', '#frmSearchBookChq', ReadBookChq);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
            case 'chequecust':
                if (type == 'chequecust') {
                    SetGridCheque(path, '#tbChq', '#frmSearchChq', '?cancel=N& type=CU & branch=' + $('#txtBranchCode').val(), ReadCheque);
                } else {
                    SetGridCheque(path, '#tbChq', '#frmSearchChq', '?cancel=N&type=CH&branch=' + $('#txtBranchCode').val(), ReadCheque);
                }
                break;
            case 'document':
                SetGridDocument(path, '#tbDoc', '#frmSearchDoc', '?type=R&branch=' + $('#txtBranchCode').val(), ReadDocument);
                break;
        }
    }
    function ReadDocument(dt) {
        let crAmt = Number($('#txtAdvCred').val());
        if (dt.AmountRemain < crAmt) {
            ShowMessage('Balance is not enough to payment',true);
            return;
        }
        $('#txtRefNoCred').val(dt.DocNo);
    }
    function ReadCheque(dt) {
        let chqAmt = dt.acType == 'CU' ? Number($('#txtAdvChq').val()) : Number($('#txtAdvChqCash').val());
        if (dt.AmountRemain < chqAmt) {
            ShowMessage('Balance is not enough to payment',true);
            return;
        }
        $('#txtRefNoChq').val(dt.ChqNo);
        $('#txtChqTranDate').val(CDateEN(dt.ChqDate));
        $('#chkIsLocal').prop('checked', dt.IsLocal == 1 ? true : false);
        $('#txtChqPayTo').val(dt.PayChqTo);
        $('#cboBankChq').val(dt.RecvBank);
        $('#txtBankBranchChq').val(dt.RecvBranch);
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
    }
    function ReadBookCash(dt) {
        $('#txtBookCash').val(dt.BookCode);
        $('#fldBankCodeCash').val(dt.BankCode);
        $('#fldBankBranchCash').val(dt.BankBranch);
        $('#txtCashBal').val(0);
        $.get(path + 'master/getbookbalance?code='+ dt.BookCode, function (r) {
            if (r.bookaccount.data.length > 0) {
                let dt = r.bookaccount.data[0].Table[0];
                $('#txtCashBal').val(dt.SumCashInBank);
            }
        });
    }
    function ReadBookChq(dt) {
        $('#txtBookChqCash').val(dt.BookCode);
        $('#fldBankCodeChqCash').val(dt.BankCode);
        $('#fldBankBranchChqCash').val(dt.BankBranch);
        $('#txtChqCashBal').val(0);
        $.get(path + 'master/getbookbalance?code='+ dt.BookCode, function (r) {
            if (r.bookaccount.data.length > 0) {
                let dt = r.bookaccount.data[0].Table[0];
                $('#txtChqCashBal').val(dt.SumCashInBank);
            }
        });

    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        ShowVender(path, dt.VenCode, '#txtVenName');
    }
    function CheckBalance() {
        if ($('#txtBookCash').val() == $('#txtBookChqCash').val()) {
            let amtChk = Number($('#txtAdvCash').val()) + Number($('#txtAdvChqCash').val());
            let amtBal = Number($('#txtCashBal').val());
            if (amtBal < amtChk) {
                ShowMessage('Balance is not enough to payment',true);
                return false;
            }
        }
        let amtChk = Number($('#txtAdvCash').val());
        if (amtChk > 0) {
            let amtBal = Number($('#txtCashBal').val());
            if (amtBal < amtChk) {
                ShowMessage('Balance is not enough to payment',true);
                return false;
            } else {
                if ($('#txtBookCash').val() == '') {
                    ShowMessage('Please select book account',true);
                    $('#txtBookCash').focus();
                    return false;
                } else {
                    if ($('#txtCashTranDate').val() == '') {
                        ShowMessage('Please input transaction date',true);
                        $('#txtCashTranDate').focus();
                        return false;
                    }
                }
            }
        }
        amtChk = Number($('#txtAdvChqCash').val());
        if (amtChk > 0) {
            let amtBal = CNum($('#txtChqCashBal').val());
            if (amtBal < amtChk) {
                ShowMessage('Balance is not enough to payment',true);
                return false
            } else {
                if ($('#txtBookChqCash').val() == '') {
                    ShowMessage('Please select book account',true);
                    $('#txtBookChqCash').focus();
                    return false;
                } else {
                    if ($('#txtRefNoChqCash').val() == '') {
                        ShowMessage('Please input cheque number',true);
                        $('#txtRefNoChqCash').focus();
                        return false;
                    } else {
                        if ($('#txtChqCashTranDate').val() == '') {
                            ShowMessage('Please input cheque date',true);
                            $('#txtChqCashTranDate').focus();
                            return false;
                        }
                    }
                    if ($('#chkStatusChq').prop('checked') == true) {
                        if ($('#cboBankChqCash').val() == '' || $('#txtBankBranchChqCash').val() == '') {
                            ShowMessage('Please input bank and branch',true);
                            $('#cboBankChqCash').focus();
                            return false;
                        }
                    }
                }
            }
        }
        amtChk = Number($('#txtAdvChq').val());
        if (amtChk > 0) {
            if ($('#txtRefNoChq').val() == '') {
                ShowMessage('Please input cheque number',true);
                $('#txtRefNoChq').focus();
                return false;
            } else {
                if ($('#txtChqTranDate').val() == '') {
                    ShowMessage('Please input cheque date',true);
                    $('#txtChqTranDate').focus();
                    return false;
                } else {
                    if ($('#cboBankChq').val() == '' || $('#txtBankBranchChq').val() == '') {
                        ShowMessage('Please input bank and branch',true);
                        $('#cboBankChq').focus();
                        return false;
                    }
                }
            }
        }
        amtChk = Number($('#txtAdvCred').val());
        if (amtChk > 0) {
            if ($('#txtRefNoCred').val() == '') {
                ShowMessage('Please input reference number',true);
                $('#txtRefNoCred').focus();
                return false;
            } else {
                if ($('#txtCredTranDate').val() == '') {
                    ShowMessage('Please input reference date',true);
                    $('#txtCredTranDate').focus();
                    return false;
                }
            }
        }
        return true;
    }
    function PrintVoucher(br, cno) {
        window.open(path + 'Acc/FormVoucher?branch=' + $('#txtBranchCode').val() + '&controlno=' + $('#txtControlNo').val());
    }

</script>
