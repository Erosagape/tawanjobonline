﻿@Code
    ViewBag.Title = "Clearing Receive"
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
            <li class="active"><a id="linkTab1" data-toggle="tab" href="#tab1">Type of Clear</a></li>
            <li><a id="linkTab2" data-toggle="tab" href="#tab2">Document Info</a></li>
            <li><a id="linkTab3" data-toggle="tab" href="#tab3">Clearing Details</a></li>
        </ul>
        <select id="mySelects" class="form-control" style="display:none" onchange="ChangeTab(this.value);">
            <option id="optTab1" value="#tab1" selected>STEP 1 - Entry Clearing</option>
            <option id="optTab2" value="#tab2">STEP 2 - Select Document</option>
            <option id="optTab3" value="#tab3">STEP 3 - Confirm Clearing</option>
        </select>
        <div class="tab-content">
            <div id="tab1" class="tab-pane fade in active">
                <div class="row">
                    <div class="col-sm-3 table-bordered" id="dvCash">
                        <label><input type="radio" name="optACType" id="chkCash" value="CA"><b id="linkCash">Cash/Transfer :</b></label>
                        <input type="text" id="txtAdvCash" class="form-control" value="" />
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
                        <input type="text" id="txtRefNoCash" class="form-control" value="" ondblclick="AutoGenRef()" />
                        <br />
                        <label id="lblTranDateCA">Trans.Date:</label>
                        <input type="date" id="txtCashTranDate" class="form-control" />
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
                        <input type="radio" name="optACType" id="chkChqCash" value="CU"><label><b id="linkChqCash">Customer Cheque :</b></label><input type="text" id="txtAdvChqCash" class="form-control" value="" />
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
                        <label id="lblStatusCH" for="chkStatusChq">Returned Cheque</label>
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
                        <label><input type="radio" name="optACType" id="chkChq" value="CH"><b id="linkChqCust">Company Cheque :</b></label>
                        <input type="text" id="txtAdvChq" class="form-control" value="" />
                        <br />
                        <label id="lblRefNoCU">Chq No:</label>
                        <input type="text" id="txtRefNoChq" class="form-control" value="" />
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
                            <label><input type="radio" name="optACType" id="optCred" value="CR"><b id="linkCred">Credit :</b></label>
                            <input type="text" id="txtAdvCred" class="form-control" value="" />
                            <br />
                            <label id="lblRefNoCR">Ref No:</label>
                            <input type="text" id="txtRefNoCred" class="form-control" value="" />
                            <br />
                            <label id="lblTranDateCR">Ref Date:</label>
                            <input type="date" id="txtCredTranDate" class="form-control" />
                            <label id="lblPayCR">Pay To:</label>
                            <input type="text" id="txtCredPayTo" class="form-control" />
                            <br />
                        </div>
                        <div style="background-color:greenyellow;padding:10px 10px 10px 10px;margin:10px 10px 10px 10px;">
                            <b id="linkBal">Balance</b>
                            <br />
                            <label id="lblForCA">For Cash/Transfer :</label>
                            <br />
                            <input type="number" id="txtCashBal" class="form-control" disabled />                                   
                            <label id="lblForCH">For Cheque : </label>
                            <br /> 
                            <input type="number" id="txtChqCashBal" class="form-control" disabled />
                        </div>
                    </div>
                </div>
            </div>
            <div id="tab2" class="tab-pane fade">
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
                        <label id="lblJobType">Job Type:</label>
                        <br />
                        <select id="cboJobType" class="form-control dropdown"></select>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblReqBy">Request By :</label>                        
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" class="form-control" id="txtReqBy" style="width:100px" />
                            <button id="btnBrowseEmp2" class="btn btn-default" onclick="SearchData('reqby')">...</button>
                            <input type="text" id="txtReqName" class="form-control" style="width:100%" disabled />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <label id="lblCustCode">Customer :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtCustCode" class="form-control" style="width:130px" />
                            <input type="text" id="txtCustBranch" class="form-control" style="width:70px" />
                            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                            <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblDateFrom">Payment Date From:</label>
                        <br />
                        <input type="date" class="form-control" id="txtAdvDateF" />
                    </div>
                    <div class="col-sm-3">
                        <label id="lblDateTo">Payment Date To:</label>
                        <input type="date" class="form-control" id="txtAdvDateT" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblDocNo">Clearing Document:</label>
                        <br />
                        <input type="text" id="txtAdvNo" class="form-control" />
                    </div>
                    <div class="col-sm-4">
                        <label id="lblJNo">Clearing Job No:</label>
                        <br />
                        <input type="text" id="txtJNo" class="form-control" />
                    </div>
                    <div class="col-sm-4">
                        <input type="checkbox" id="chkFromClr" /><label for="chkFromClr" id="lblClrNoAdv">NON-ADVANCE Clearing</label>
                        <br />
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
                                    <th>Clr.No</th>
                                    <th class="desktop">Clr.date</th>
                                    <th class="all">Job No</th>
                                    <th class="desktop">Inv.No</th>
                                    <th class="desktop">customer</th>
                                    <th class="desktop">Adv.No</th>
                                    <th class="all">Adv.Total</th>
                                    <th class="all">Used</th>
                                    <th class="desktop">Balance</th>
                                    <th class="desktop">W-Tax</th>
                                    <th class="desktop">Clr.By</th>
                                </tr>
                            </thead>
                        </table>
                        <label id="lblListAppr">Receive Document : </label>
                        <br /><input type="text" id="txtListApprove" class="form-control" value="" disabled />
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
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let arr = [];
    let list = [];
    let dataApp = [];
    let docno = '';
    //$(document).ready(function () {
        SetEvents();
    //});
    function ChangeTab(id) {
        $('#myTabs a[href="' + id + '"]').tab('show');
    }
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtAdvDateF').val(GetFirstDayOfMonth());
        $('#txtAdvDateT').val(GetLastDayOfMonth());
        //Combos
        let lists = 'JOB_TYPE=#cboJobType';
        loadCombos(path, lists);

        let cbos = ['#cboBankCash', '#cboBankChqCash', '#cboBankChq'];
        loadBank(cbos, path);
        //default values
        $('#txtCurrencyCode').val('THB');
        ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');

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
        $('#txtReqBy').focusout(function (event) {
            if (true) {
                $('#txtReqName').val('');
                ShowUser(path, $('#txtReqBy').val(), '#txtReqName');
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
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");

            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchReq', '#tbReq', 'Request By', response, 2);
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchBookCash', '#tbBookCash', 'Book Accounts', response, 2);
            CreateLOV(dv, '#frmSearchBookChq', '#tbBookChq', 'Book Accounts', response, 2);
        });
    }
    function ClearData() {
        $('#txtAdvCash').val('');
        $('#txtBookCash').val('');
        $('#txtRefNoCash').val('');
        $('#txtCashTranDate').val('');
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
        $('#chkCash').prop('checked', true);
        $('#chkChq').prop('checked', false);
        $('#chkChqCash').prop('checked', false);
        $('#chkCred').prop('checked', false);
    }
    function SetGridAdv(isAlert) {
        arr = [];
        ClearData();
        ShowSummary();
        docno = '';

        let w = '';
        if ($('#txtAdvNo').val() !== "") {
            if ($('#chkFromClr').prop('checked')) {
                w = w + '&clrno=' + $('#txtAdvNo').val();
            } else {
                w = w + '&advno=' + $('#txtAdvNo').val();
            }
        }
        if ($('#txtJNo').val() !== "") {
            w = w + '&jobno=' + $('#txtJNo').val();
        }
        if ($('#txtReqBy').val() !== "") {
            w = w + '&advby=' + $('#txtReqBy').val();
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
        if ($('#txtAdvDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtAdvDateF').val());
        }
        if ($('#txtAdvDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtAdvDateT').val());
        }
        //w = w + '&Show=BAL';
        if ($('#chkFromClr').prop('checked') == true) {
            w = w + '&Data=CLR';
        }
        $.get(path + 'clr/getclearingsum?branchcode=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.clr.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if(isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.clr.data[0].Table;
            $('#tbHeader').DataTable().destroy();
            $('#tbHeader').empty();
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data:($('#chkFromClr').prop('checked') ? "ClrNo" : "AdvNo"), title: "Adv No" },
                    {
                        data: ($('#chkFromClr').prop('checked') ? "ClrDate" : "PaymentDate"), title: "Payment date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "ItemNo", title: "No" },
                    { data: "SICode", title: "Adv.Code" },
                    { data: "SDescription", title: "Adv.Expenses" },
                    {
                        data: "AdvNet", title: "Adv Total",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "ClrNet", title: "Clear",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "ClrVat", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "Clr50Tavi", title: "WT",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "ClrBal", title: "Balance",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    }
                ],
                responsive: true,
                destroy:true
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
        let acType = $('input:radio[name=optACType]:checked').val();
        o.acType = acType;

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
        let wtax = 0;
        let doc = '';
        let sum_ca = 0;
        let sum_ch = 0;
        let sum_cu = 0;
        let sum_cr = 0;

        list = [];

        for (let i = 0; i < arr.length; i++) {

            let o = arr[i];
            wtax += Number(o.Clr50Tavi);
            tot += Number(o.ClrBal);

            let obj = {
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: null,
                ItemNo: i + 1,
                DocType: 'CLR',
                CmpType: 'C',
                CmpCode: o.CustCode,
                CmpBranch: o.CustBranch,
                PaidAmount: CDbl(Math.abs(o.ClrBal), 2),
                TotalAmount: CDbl(Math.abs(o.ClrBal), 2),
                acType:o.acType
            };
            if ($('#chkFromClr').prop('checked') == true) {
                obj.DocNo = o.ClrNo + '#'+ o.ItemNo;
                obj.DocDate = CDateEN(o.ClrDate);
                if (doc.indexOf(o.ClrNo) < 0) {
                    doc += (doc !== '' ? ',' : '') + o.ClrNo;
                }
            } else {
                obj.DocNo = o.AdvNo + '#'+ o.ItemNo;
                obj.DocDate = CDateEN(o.PaymentDate);
                if (doc.indexOf(o.AdvNo) < 0) {
                    doc += (doc !== '' ? ',' : '') + o.AdvNo;
                }
            }
            if (o.acType == 'CA') sum_ca += Number(o.ClrBal);
            if (o.acType == 'CH') sum_ch += Number(o.ClrBal);
            if (o.acType == 'CU') sum_cu += Number(o.ClrBal);
            if (o.acType == 'CR') sum_cr += Number(o.ClrBal);

            list.push(obj);
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
                {
                    data: "TotalAmount", title: "Doc.Total",
                    render: function (data) {
                        return CCurrency(data);
                    }
                },
                {
                    data: "PaidAmount", title: "Paid",
                    render: function (data) {
                        return CCurrency(data);
                    }
                }
            ],
            responsive:true,
            destroy:true
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#txtAdvCash').val(CDbl(sum_ca, 2));
        $('#txtAdvChq').val(CDbl(sum_ch, 2));
        $('#txtAdvChqCash').val(CDbl(sum_cu, 2));
        $('#txtAdvCred').val(CDbl(sum_cr, 2));

        $('#txtSumApprove').val(CDbl(tot, 2));
        $('#txtSumWHTax').val(CDbl(wtax, 2));
        $('#txtListApprove').val(doc);
        $('#txtTRemark').val(doc);

    }
    function GetSumPayment(type) {
        let filter_data = arr.filter(function (data) {
            return data.acType == type;
        });
        let filter_sum = {
            sumamount: 0,
            currencycode : '@ViewBag.PROFILE_CURRENCY',
            exchangerate: 1,
            count: 0
        };
        for (let i = 0; i < filter_data.length; i++) {

            filter_sum.sumamount += Number(filter_data[i].ClrBal);
            filter_sum.count += 1;
        }
        return filter_sum;
    }
    function SavePayment() {
        let oData = [];
        let i = 0;
        let sum_cash = GetSumPayment('CA');
        if (sum_cash.count !== 0) {
            i = i + 1;
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType: sum_cash.sumamount > 0 ? 'R' : 'P',
                ChqNo: '',
                BookCode: $('#txtBookCash').val(),
                BankCode: $('#fldBankCodeCash').val(),
                BankBranch: $('#fldBankBranchCash').val(),
                ChqDate: '',
                CashAmount: Math.abs(sum_cash.sumamount),
                ChqAmount: 0,
                CreditAmount: 0,
                SumAmount: sum_cash.sumamount,
                CurrencyCode: sum_cash.currencycode,
                ExchangeRate: sum_cash.exchangerate,
                TotalAmount: Math.abs(sum_cash.sumamount),
                VatInc: 0,
                VatExc: 0,
                WhtInc: 0,
                WhtExc: 0,
                TotalNet: Math.abs(sum_cash.sumamount),
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
        let sum_chqcash = GetSumPayment('CH');
        if (sum_chqcash.count !== 0) {
            i = i + 1;
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType:sum_chqcash.sumamount > 0 ? 'R' : 'P',
                ChqNo: $('#txtRefNoChqCash').val(),
                BookCode: '',
                BankCode: '',
                BankBranch: '',
                ChqDate: CDateEN($('#txtChqCashTranDate').val()),
                CashAmount: 0,
                ChqAmount: Math.abs(sum_chqcash.sumamount),
                CreditAmount: 0,
                SumAmount:  Math.abs(sum_chqcash.sumamount),
                CurrencyCode: sum_chqcash.currencycode,
                ExchangeRate: sum_chqcash.exchangerate,
                TotalAmount:  Math.abs(sum_chqcash.sumamount),
                VatInc: 0,
                VatExc: 0,
                WhtInc: 0,
                WhtExc: 0,
                TotalNet: Math.abs(sum_chqcash.sumamount),
                IsLocal: 0,
                ChqStatus: $('#chkStatusChq').prop('checked')==true? 'P':'',
                TRemark: '',
                PayChqTo: $('#txtChqCashPayTo').val(),
                DocNo: '',
                SICode: '',
                RecvBank: $('#cboBankChqCash').val(),
                RecvBranch: $('#txtBankBranchChqCash').val(),
                acType: 'CH'
            });
        }
        let sum_chq = GetSumPayment('CU');
        if (sum_chq.count !== 0) {
            i = i + 1;
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType:sum_chq.sumamount> 0 ? 'R' : 'P',
                ChqNo: $('#txtRefNoChq').val(),
                BookCode: $('#txtBookChq').val(),
                BankCode: $('#fldBankCodeChqCash').val(),
                BankBranch: $('#fldBankBranchChqCash').val(),
                ChqDate: CDateEN($('#txtChqTranDate').val()),
                CashAmount: 0,
                ChqAmount: Math.abs(sum_chq.sumamount),
                CreditAmount: 0,
                SumAmount: Math.abs(sum_chq.sumamount),
                CurrencyCode: sum_chq.currencycode,
                ExchangeRate: sum_chq.exchangerate,
                TotalAmount: Math.abs(sum_chq.sumamount),
                VatInc: 0,
                VatExc: 0,
                WhtInc: 0,
                WhtExc: 0,
                TotalNet: Math.abs(sum_chq.sumamount),
                IsLocal: $('#chkIsLocal').prop('checked') == true ? 'P' : '',
                ChqStatus: '',
                TRemark: '',
                PayChqTo: $('#txtChqPayTo').val(),
                DocNo: '',
                SICode: '',
                RecvBank: $('#cboBankChq').val(),
                RecvBranch: $('#txtBankBranchChq').val(),
                acType: 'CU'
            });
        }
        let sum_cr = GetSumPayment('CR');
        if (sum_cr.count!== 0) {
            i = i + 1;
            oData.push({
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: docno,
                ItemNo: i,
                PRVoucher: '',
                PRType: sum_cr.sumamount > 0 ? 'R' : 'P',
                ChqNo: '',
                BookCode: '',
                BankCode: '',
                BankBranch: '',
                ChqDate: CDateEN($('#txtCredTranDate').val()),
                CashAmount: 0,
                ChqAmount: 0,
                CreditAmount: Math.abs(sum_cr.sumamount),
                SumAmount:Math.abs(sum_cr.sumamount),
                CurrencyCode: sum_cr.currencycode,
                ExchangeRate: sum_cr.exchangerate,
                TotalAmount: Math.abs(sum_cr.sumamount),
                VatInc: 0,
                VatExc: 0,
                WhtInc: 0,
                WhtExc: 0,
                TotalNet: Math.abs(sum_cr.sumamount),
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
                        if ($('#txtAdvNo').val() !== '') {

                            dataApp = [];
                            dataApp.push(user + '|' + response.result.data + '|' + ($('#chkFromClr').prop('checked') ? 'CLR' : 'ADV'));

                            dataApp.push($('#txtBranchCode').val() + '|' + $('#txtAdvNo').val());

                            ReceiveClearing(response.result.data);
                        } else {
                            dataApp = [];
                            dataApp.push(user + '|' + docno + '|' + ($('#chkFromClr').prop('checked') ? 'CLR' : 'ADV'));
                            for (let i = 0; i < arr.length; i++) {
                                let o = arr[i];
                                let docApp = '';
                                if ($('#chkFromClr').prop('checked') == true) {
                                    docApp = $('#txtBranchCode').val() + '|' + o.ClrNo;
                                } else {
                                    docApp = $('#txtBranchCode').val() + '|' + o.AdvNo;
                                }
                                if (dataApp.indexOf(docApp) < 0) {
                                    dataApp.push(docApp);
                                }
                            }
                            ReceiveClearing(docno);
                        }
                        SetGridAdv(false);
                        ShowMessage(response.result.msg);
                        PrintVoucher($('#txtBranchCode').val(), $('#txtControlNo').val());
                    }
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        }
    }
    function ReceiveClearing(cno) {
        let msg = "Clear Document " + cno + " Complete";

        let jsonString = JSON.stringify({ data: dataApp });
        $.ajax({
            url: "@Url.Action("ReceiveClearing", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                response ? ShowMessage(msg) : ShowMessage("Cannot Clear Document",true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
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
            case 'reqby':
                SetGridUser(path, '#tbReq', '#frmSearchReq', ReadReqBy);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
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
        }
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
    function ReadReqBy(dt) {
        $('#txtReqBy').val(dt.UserID);
        $('#txtReqName').val(dt.TName);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
    function PrintVoucher(br, cno) {
        window.open(path + 'Acc/FormVoucher?branch=' + $('#txtBranchCode').val() + '&controlno=' + $('#txtControlNo').val());
    }
    function CheckBalance() {
        if ($('#txtBookCash').val() == $('#txtBookChqCash').val()) {
            let amtChk = Number($('#txtAdvCash').val()) + Number($('#txtAdvChqCash').val());
            let amtBal = Number($('#txtCashBal').val());
            if ((amtBal + amtChk)<0) {
                ShowMessage('Balance not enough to payment',true);
                return false;
            }
        }
        let amtChk = Number($('#txtAdvCash').val());
        if (amtChk < 0) {
            let amtBal = Number($('#txtCashBal').val());
            if ((amtBal + amtChk)<0) {
                ShowMessage('Balance not enough to payment',true);
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
        if (amtChk < 0) {
            let amtBal = CNum($('#txtChqCashBal').val());
            if ((amtBal + amtChk)<0) {
                ShowMessage('Balance not enough to payment',true);
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
        if (amtChk !== 0) {
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
        if (amtChk!==0) {
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
    function AutoGenRef() {
        $('#txtRefNoCash').val('CA'+'@DateTime.Now.ToString("yyyyMMddHHmmss")');
    }
</script>
