@Code
    ViewBag.Title = "Payment/Receive Voucher"
End Code
<div class="panel-body">
    <div class="container">
        <div id="dvForm">
            <div class="row">
                <div class="col-sm-5">
                    <label id="lblBranch">Branch:</label>                    
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" class="form-control" id="txtBranchCode" style="width:15%" readonly />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                        <input type="text" class="form-control" id="txtBranchName" style="width:65%" readonly />
                    </div>
                </div>
                <div class="col-sm-4">
                    <b id="linkControlNo" ondblclick="SaveData()">Reference No:</b>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" class="form-control" id="txtControlNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('controlno')" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <label id="lblVoucherDate">Voucher Date</label>
                    <br /> <input type="date" id="txtVoucherDate" class="form-control" tabIndex="3">
                </div>
            </div>
            <div class="row">
                <div class="col-sm-8">
                    <label id="lblTRemark">Note</label>
                    <br /><input type="text" id="txtTRemark" class="form-control" tabIndex="4">
                </div>
                <div class="col-sm-4">
                    <label id="lblCustCode">Customer Code</label>
                    <br/>
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtCustCode" style="width:100%" />
                        <input type="text" id="txtCustBranch" style="width:100px" />
                        <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                    </div>
                </div>
            </div>

            <ul class="nav nav-tabs">
                <li class="active"><a id="linkTab1" data-toggle="tab" href="#tabHeader">Payment Info</a></li>
                <li><a id="linkTab2" data-toggle="tab" href="#tabDetail">Reference Documents</a></li>
            </ul>
            <div class="tab-content">
                <div id="tabHeader" class="tab-pane fade in active">
                    <a href="#" class="btn btn-warning" id="btnAddPayment" onclick="AddPayment()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Detail</b>
                    </a>

                    <div class="row">
                        <div class="col-sm-3">
                            <u><b id="linkPay">Payment</b></u>
                            <br />
                            <label id="lblPayCash">Cash</label>
                             : <input type="text" id="txtPayCash" readonly />
                            <br />
                            <label id="lblPayChq">Cheque</label>
                             : <input type="text" id="txtPayChq" readonly />
                            <br />
                            <label id="lblPayCred">Credit</label>
                             : <input type="text" id="txtPayCred" readonly />
                        </div>
                        <div class="col-sm-3">
                            <u><b id="linkRcv">Receive</b></u>
                            <br />
                            <label id="lblRcvCash">Cash</label>
                             : <input type="text" id="txtRcvCash" readonly />
                            <br />
                            <label id="lblRcvChq">Cheque</label>
                             : <input type="text" id="txtRcvChq" readonly />
                            <br />
                            <label id="lblRcvCred">Credit</label>
                             : <input type="text" id="txtRcvCred" readonly />
                        </div>
                        <div class="col-sm-3">
                            <u><b id="linkSum">Sum</b></u>
                            <br />
                            <label id="lblSumPay">Payment</label>
                             : <input type="text" id="txtPaySum" readonly />
                            <br />
                            <label id="lblSumRcv">Receive</label>
                             : <input type="text" id="txtRcvSum" readonly />
                        </div>
                        <div class="col-sm-3">
                            <u><b id="linkTotal">Total</b></u>
                            <br />
                            <label id="lblTotalPR">Voucher</label>
                            : <input type="text" id="txtPRSum" readonly />
                            <br />
                            <label id="lblTotalDoc">Document</label>
                             : <input type="text" id="txtDocSum" readonly />
                        </div>
                    </div>

                    <table id="tbHeader" class="table table-responsive">
                        <thead>
                            <tr>
                                <th class="desktop">Chq</th>
                                <th class="desktop">Cash</th>
                                <th class="desktop">Credit</th>
                                <th class="all">VCNo</th>
                                <th class="desktop">BookAcc</th>
                                <th class="desktop">RefChqNo</th>
                                <th class="desktop">RefDate</th>
                                <th class="desktop">Bank</th>
                                <th class="desktop">Branch</th>
                                <th class="desktop">PayChqTo</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div id="tabDetail" class="tab-pane fade">
                    <div>
                        <a href="#" class="btn btn-warning" id="btnAddDoc" onclick="AddDocument()">
                            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAddDoc">Add Document</b>
                        </a>
                    </div>
                    <table id="tbDetail" class="table table-responsive">
                        <thead>
                            <tr>
                                <th class="all">DocNo</th>
                                <th class="desktop">DocType</th>
                                <th class="desktop">DocDate</th>
                                <th class="desktop">CmpType</th>
                                <th class="desktop">CmpCode</th>
                                <th class="desktop">CmpBranch</th>
                                <th class="desktop">TotalDoc</th>
                                <th class="all">TotalPaid</th>
                            </tr>
                        </thead>
                    </table>

                </div>
            </div>
            <div class="row">
                <div class="col-md-4" style="border-style:solid;border-width:1px">
                    <label id="lblRecBy">Record By</label>
                    <br />
                    <input type="text" id="txtRecUser" style="width:250px" readonly />
                    <br />
                    <label id="lblRecDate">Date:</label>                    
                    <input type="date" id="txtRecDate" readonly />
                    <label id="lblRecTime">Time:</label>                    
                    <input type="text" id="txtRecTime" style="width:80px" readonly />
                </div>
                <div class="col-md-4" style="border-style:solid;border-width:1px">
                    <input type="checkbox" id="chkPosted" />
                    <label id="lblPostBy" for="chkPosted">Posted By</label><br />
                    <input type="text" id="txtPostedBy" style="width:250px" disabled />
                    <br />
                    <label id="lblPostDate">Date:</label>
                    <input type="date" id="txtPostedDate" />
                    <label id="lblPostTime">Time:</label>
                    <input type="text" id="txtPostedTime" style="width:80px" disabled />
                    <br />
                    <label id="lblPostRefNo" for="txtPostRefNo">Post Ref#</label><br />
                    <input type="text" id="txtPostRefNo" style="width:250px" />
                </div>
                <div class="col-md-4" style="border-style:solid;border-width:1px;color:red">
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
                    <div class="modal-header">
                        <h4 class="modal-title"><label id="lblHeaderDet">Filter By Voucher Date</label></h4>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblDateFrom">From</label>
                                 : <input type="date" id="txtDateFrom" class="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblDateTo">To</label>
                                 : <input type="date" id="txtDateTo" class="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <br/>
                                <button id="btnSearch" class="btn btn-primary" onclick="SetGridControl()">Search</button>
                            </div>
                        </div>
                    </div>
                    <div class="modal-body">
                        <table id="tbControl" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th class="desktop">ControlNo</th>
                                    <th class="all">VoucherDate</th>
                                    <th class="desktop">CustCode</th>
                                    <th class="desktop">Remark</th>
                                    <th class="all">VoucherNo</th>
                                    <th class="desktop">ChqNo</th>
                                    <th class="desktop">ChqDate</th>
                                    <th class="desktop">ChqAmount</th>
                                    <th class="desktop">CashAmount</th>
                                    <th class="desktop">CreditAmount</th>
                                    <th class="desktop">Currency</th>
                                    <th class="all">DocNo</th>
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
                        <input type="radio" id="optShowPay" value="dvPayInfo" name="showInfo" onchange="ShowInfo()" checked /> <label id="lblShowPay" for="optShowPay">Payment Info</label>
                        <input type="radio" id="optShowTax" value="dvPayTax" name="showInfo" onchange="ShowInfo()" /><label id="lblShowTax" for="optShowTax">VAT/Tax info</label>
                    </div>
                    <div class="modal-body">
                        <div id="dvPayInfo">
                            <div class="row">
                                <div class="col-md-2">
                                    <label id="lblItemNo">No</label>
                                    <br /><input type="text" id="txtItemNo" class="form-control" disabled>
                                </div>
                                <div class="col-md-3">
                                    P/R<br /><input type="hidden" id="txtPRType" class="form-control">
                                    <select id="cboPRType" class="form-control dropdown" onchange="SetPRType()"></select>
                                </div>
                                <div class="col-md-4">
                                    <label id="lblVCNo">Voucher No</label>
                                    :<br /><input type="text" id="txtPRVoucher" class="form-control">
                                </div>
                                <div class="col-md-3">
                                    <label id="lblType">Type</label>
                                    :<br /><input type="hidden" id="txtacType" class="form-control">
                                    <select id="cboacType" class="form-control dropdown" onchange="SetACType('cboacType','txtacType')"></select>
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
                                        <label id="lblBank">Bank</label>
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

                            <div id="dvChqInfo">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label id="lblChqNo">Cheque No</label>
                                        <br /><input type="text" id="txtChqNo" class="form-control">
                                    </div>
                                    <div class="col-md-4">
                                        <label id="lblChqDate">C.Date</label>
                                        <br /><input type="date" id="txtChqDate" class="form-control">
                                    </div>
                                    <div class="col-md-3">
                                        <label id="lblChqClr">CLR</label>
                                        <br /><input type="hidden" id="txtChqStatus" class="form-control">
                                        <select id="cboChqStatus" class="form-control dropdown" onchange="SetChqStatus()"></select>
                                    </div>
                                    <div class="col-md-2">
                                        <label id="lblLocalChq">Local Cheque</label>                                        
                                        <br />
                                        <input type="hidden" id="txtIsLocal" class="form-control" value="0">
                                        <input type="checkbox" id="chkIsLocal" onclick="SetIsLocal()" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <a id="linkRecvBank" onclick="SearchData('bank')">Ref.Bank</a><br /><input type="text" id="txtRecvBank" class="form-control">
                                    </div>
                                    <div class="col-md-6">
                                        <label id="lblRefBankName">Ref.Bank Name</label>
                                        <br /><input type="text" id="txtRecvBankName" class="form-control" disabled>
                                    </div>
                                    <div class="col-md-4">
                                        <label id="lblRefBankBranch">Ref.Branch</label>
                                        <br /><input type="text" id="txtRecvBranch" class="form-control">
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <label id="lblCashAmount">CashAmount</label>
                                    <br /><input type="number" id="txtCashAmount" class="form-control" value="0.00">
                                </div>
                                <div class="col-md-4">
                                    <label id="lblChqAmount">ChqAmount</label>
                                    <br /><input type="number" id="txtChqAmount" class="form-control" value="0.00">
                                </div>
                                <div class="col-md-4">
                                    <label id="lblCreditAmount">CreditAmount</label>
                                    <br /><input type="number" id="txtCreditAmount" class="form-control" value="0.00">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label id="lblRef">Ref.No</label>
                                    <br /><input type="text" id="txtDocNo" class="form-control">
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
                                    <label id="lblSumAmt">Amount Base</label>
                                    <br />
                                    <input type="text" id="txtSumAmt" class="form-control" onchange="CalculateTotal()" />
                                </div>
                                <div class="col-md-3">
                                    <label id="lblExcRate">Exchange Rate</label>
                                    <br />
                                    <input type="text" id="txtExchangeRate" class="form-control" onchange="CalculateTotal()"/>
                                </div>
                                <div class="col-md-4">
                                    <label id="lblTotalAmt">Total Amount</label>
                                    <br />
                                    <input type="text" id="txtTotalAmt" class="form-control" onchange="CalculateTotal()"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    Vat(Include)<br />
                                    <input type="text" id="txtVatInc" class="form-control" onchange="CalculateTotal()"/>
                                </div>
                                <div class="col-md-3">
                                    Vat(Exclude)<br />
                                    <input type="text" id="txtVatExc" class="form-control" onchange="CalculateTotal()"/>
                                </div>
                                <div class="col-md-3">
                                    Wht(Include)<br />
                                    <input type="text" id="txtWhtInc" class="form-control" onchange="CalculateTotal()"/>
                                </div>
                                <div class="col-md-3">
                                    Wht(Exclude)<br />
                                    <input type="text" id="txtWhtExc" class="form-control" onchange="CalculateTotal()"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label id="lblTotalNet">Total Net</label>
                                    <br />
                                    <input type="text" id="txtTotalNet" class="form-control" disabled/>
                                </div>
                                <div class="col-md-3">
                                    <a id="linkExpCode" onclick="SearchData('servicecode')">Exp.Code</a><br /><input type="text" id="txtSICode" class="form-control">
                                </div>
                                <div class="col-md-6">
                                    <br />
                                    <input type="text" id="txtSDescription" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <label id="lblDRemark">Note</label>
                                    <br /><input type="text" id="txtDTRemark" class="form-control">
                                </div>
                                <div class="col-md-4">
                                    <label id="lblJNo">Job No.</label>
                                    <br /><input type="text" id="txtForJNo" class="form-control">
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnUpdatePay" onclick="SavePayment()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveDet">Save Detail</b>
                            </a>
                            <a href="#" class="btn btn-danger" id="btnDelPay" onclick="DeletePayment()">
                                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelDet">Delete Detail</b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmDocument" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title"><label id="lblHeaderDoc">Document Info</label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-2">
                                <label id="lblDocItemNo">No</label>
                                <br /><input type="text" id="txtDocItemNo" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <label id="lblCmpType">Type</label>
                                <br /><input type="hidden" id="txtCmpType" class="form-control">
                                <select id="cboCmpType" class="form-control dropdown" onchange="SetCmpType()">
                                    <option value="">N/A</option>
                                    <option value="C">Customers</option>
                                    <option value="V">Venders</option>
                                </select>
                            </div>
                            <div class="col-md-4">
                                <a id="linkComp" onclick="SearchData(GetCmpType())">Company</a><br /><input type="text" id="txtCmpCode" class="form-control">
                            </div>
                            <div class="col-md-2">
                                <label id="lblCmpBranch">Branch</label>
                                <br /><input type="text" id="txtCmpBranch" class="form-control">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-7">
                                <label id="lblCmpName">Name</label>
                                <br /><input type="text" id="txtCmpName" class="form-control" disabled>
                            </div>
                            <div class="col-md-5">
                                <label id="lblDocType">Doc.Type</label>
                                <br /><input type="hidden" id="txtDocType" class="form-control">
                                <select id="cboDocType" class="form-control dropdown" onchange="SetDocType()"></select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label id="lblDDocNo">Doc.No</label>
                                <br /><input type="text" id="txtDDocNo" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <label id="lblDDocDate">Doc.Date</label>
                                <br /><input type="date" id="txtDocDate" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <label id="lblPayType">Pay.Type</label>
                                <br /><input type="hidden" id="txtDocacType" class="form-control">
                                <select id="cboDocacType" class="form-control dropdown" onchange="SetACType('cboDocacType','txtDocacType')"></select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                <label id="lblDocTotal">Total</label>
                                <br /><input type="number" id="txtTotalAmount" class="form-control" value="0.00">
                            </div>
                            <div class="col-md-5">
                                <label id="lblPaidTotal">Amount</label>
                                <br /><input type="number" id="txtPaidAmount" class="form-control" value="0.00">
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnUpdateDoc" onclick="SaveDocument()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveDoc">Save Document</b>
                            </a>
                            <a href="#" class="btn btn-danger" id="btnDelDoc" onclick="DeleteDocument()">
                                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelDoc">Delete Document</b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvCommand">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearForm()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkClear">Clear Data</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Data</b>
            </a>
            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Data</b>
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
    const branch = getQueryString("Branch");
    const code = getQueryString("Code");
    let chkmode = false;
    //$(document).ready(function () {
    SetEvents();
    SetLOVs();
    SetEnterToTab();
    $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
    $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');

    if (branch !== '' && code !== '') {
        $('#txtControlNo').val(code);
        LoadData();
    }
        //});
    function SetIsLocal() {
        $('#txtIsLocal').val($('#chkIsLocal').prop('checked') ? '1' : '0');
    }
    function SetPRType() {
        $('#txtPRType').val($('#cboPRType').val());
    }
    function SetACType(n, d) {
        let typ = $('#' + n).val();
        $('#' + d).val(typ);

        if (n == 'cbodocacType') {
            return;
        }
        let cashfld = 'CashAmount';
        let chqfld = 'ChqAmount';
        let credfld = 'CreditAmount';
        let sumval = Number($('#txtCashAmount').val()) + Number($('#txtChqAmount').val()) + Number($('#txtCreditAmount').val());

        $('#txt' + cashfld).attr('disabled', 'disabled');
        $('#txt' + credfld).attr('disabled', 'disabled');
        $('#txt' + chqfld).attr('disabled', 'disabled');
        $('#dvChqInfo').show();
        $('#dvBookInfo').hide();
        switch (typ) {
            case 'CR':
                $('#txt' + chqfld).val(0);
                $('#txt' + cashfld).val(0);
                $('#txt' + credfld).val(sumval);
                $('#txt' + credfld).removeAttr('disabled');
                $('#dvChqInfo').hide();
                break;
            case 'CA':
                $('#txt' + chqfld).val(0);
                $('#txt' + credfld).val(0);
                $('#txt' + cashfld).val(sumval);
                $('#txt' + cashfld).removeAttr('disabled');
                $('#dvChqInfo').hide();
                $('#dvBookInfo').show();
                break;
            case 'CU':
                $('#txt' + cashfld).val(0);
                $('#txt' + credfld).val(0);
                $('#txt' + chqfld).val(sumval);
                $('#txt' + chqfld).removeAttr('disabled');
                break;
            case 'CH':
                $('#txt' + cashfld).val(0);
                $('#txt' + credfld).val(0);
                $('#txt' + chqfld).val(sumval);
                $('#txt' + chqfld).removeAttr('disabled');
                $('#dvBookInfo').show();
                break;
            default:
                $('#txt' + cashfld).val(0);
                $('#txt' + credfld).val(0);
                $('#txt' + chqfld).val(0);
                $('#dvChqInfo').hide();
                break;
        }
    }
    function SetCmpType() {
        $('#txtCmpType').val($('#cboCmpType').val());
        if ($('#cboCmpType').val() == '') {
            $('#txtCmpCode').attr('disabled', 'disabled');
            $('#txtCmpBranch').attr('disabled', 'disabled');
        } else {
            $('#txtCmpCode').removeAttr('disabled');
            $('#txtCmpBranch').removeAttr('disabled');
        }
    }
    function SetChqStatus() {
        $('#txtChqStatus').val($('#cboChqStatus').val());
    }
    function SetDocType() {
        $('#txtDocType').val($('#cboDocType').val());
    }
    function SetEvents() {
        $('#txtDateFrom').val(GetToday());
        $('#txtDateTo').val(GetToday());
        $('#txtControlNo').keydown(function (event) {
            if (event.which == 13) {
                LoadData();
            }
        });
        $('#txtSICode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtSDescription').val('');
                CallBackQueryService(path, $('#txtSICode').val(), ReadService);
            }
        });
        $('#txtCmpBranch').keydown(function (event) {
            if (event.which == 13) {
                $('#txtCmpName').val('');
                if (GetCmpType() == "cust") {
                    ShowCustomer(path, $('#txtCmpCode').val(), $('#txtCmpBranch').val(), '#txtCmpName');
                    return;
                }
                if (GetCmpType() == "vender") {
                    ShowVender(path, $('#txtCmpCode').val(), '#txtCmpName');
                    return;
                }
            }
        });
        $('#txtBookCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBookName').val('');
                $('#txtBankCode').val('');
                $('#txtBankName').val('');
                $('#txtBankBranch').val('');
                $('#chkIsLocal').prop('checked', false);

                CallBackQueryBookAccount(path, $('#txtBranchCode').val(), $('#txtBookCode').val(), ReadBookAccount);
            }
        });
        $('#txtRecvBank').keydown(function (event) {
            if (event.which == 13) {
                $('#txtRecvBankName').val('');
                CallBackQueryBank(path, $('#txtRecvBank').val(), ReadBank);
            }
        });
        $('#txtCurrencyCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtCurrencyName').val('');
                CallBackQueryCurrency(path, $('#txtCurrencyCode').val(), ReadCurrency);
            }
        });
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#chkPosted').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ACC', 'Voucher',(chkmode ? 'I':'D'), SetApprove);
        });

        $('#chkCancel').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ACC', 'Voucher', 'D', SetCancel);
        });
        $('#txtChqAmount').focusout(function (event) {
            $('#txtSumAmt').val($('#txtChqAmount').val());
            CalculateTotal();
        });
        $('#txtCashAmount').focusout(function (event) {
            $('#txtSumAmt').val($('#txtCashAmount').val());
            CalculateTotal();
        });
        $('#txtCreditAmount').focusout(function (event) {
            $('#txtSumAmt').val($('#txtCreditAmount').val());
            CalculateTotal();
        });

    }
    function SetEnterToTab() {
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
        let lists = 'PAYMENT_TYPE=#cboDocacType';
        lists += ',PAYMENT_TYPE=#cboacType';
        lists += ',DOCUMENT_TYPE=#cboDocType';
        lists += ',DOCUMENT_ACC=#cboPRType';
        lists += ',CHQ_STATUS=#cboChqStatus';

        loadCombos(path,lists)

        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name').done(function(response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customer List', response, 3);
            //Venders
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //Bank
            CreateLOV(dv, '#frmSearchBank', '#tbBank', 'Bank', response, 2);
            //Service Code
            CreateLOV(dv, '#frmSearchExp', '#tbExp', 'Expenses Code', response, 2);
            //BookAccount
            CreateLOV(dv, '#frmSearchBookAcc', '#tbBookAcc', 'Book Accounts', response, 2);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
        });
    }
    function SetApprove(b) {
        if (b == true) {
            //$('#txtPostRefNo').val(chkmode ? $('#txtPostRefNo').val() : '');
            $('#txtPostedBy').val(chkmode ? user : '');
            //$('#txtPostedDate').val(chkmode ? CDateEN(GetToday()) : '');
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
            SaveData();
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkCancel').prop('checked', !chkmode);
    }
    function SearchData(type) {
        switch (type) {
            case 'bookacc':
                SetGridBookAccount(path, '#tbBookAcc', '#frmSearchBookAcc', ReadBookAccount);
                break;
            case 'bank':
                SetGridBank(path, '#tbBank', '#frmSearchBank', ReadBank);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'controlno':
                $('#frmHeader').modal('show');
                SetGridControl();
                break;
            case 'cust':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCompany);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'servicecode':
                SetGridSICode(path, '#tbExp','','#frmSearchExp', ReadService);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
        }
    }
    function LoadData() {
        let code = $('#txtControlNo').val();
        let branch = $('#txtBranchCode').val();
        $('#txtBranchCode').val(branch);
        $('#txtControlNo').val(code);
        CallBackQueryVoucher(path, branch,code, ReadData);
    }

    function ClearForm() {
        $('#txtBranchCode').val('');
        $('#txtBranchName').val('');
        $('#txtControlNo').val('');
        $('#txtVoucherDate').val('');
        $('#txtTRemark').val('');
        $('#txtRecUser').val('');
        $('#txtRecDate').val('');
        $('#txtRecTime').val('');
        $('#chkPosted').prop('checked',false);
        $('#txtPostedBy').val('');
        $('#txtPostedDate').val('');
        $('#txtPostedTime').val('');
        $('#txtPostRefNo').val('');

        $('#chkCancel').prop('checked', false);
        $('#txtCancelReson').val('');
        $('#txtCancelProve').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelTime').val('');

        $('#txtPayCash').val('0.00');
        $('#txtPayChq').val('0.00');
        $('#txtPayCred').val('0.00');
        $('#txtPaySum').val('0.00');

        $('#txtRcvCash').val('0.00');
        $('#txtRcvChq').val('0.00');
        $('#txtRcvCred').val('0.00');
        $('#txtRcvSum').val('0.00');

        $('#txtPRSum').val('0.00');
        $('#txtDocSum').val('0.00');

        $('#tbHeader').empty();
        $('#tbDetail').empty();

        $('#btnAdd').removeAttr('disabled');
        $('#btnSave').removeAttr('disabled');
        if (userRights.indexOf('I') < 0) {
            $('#btnAdd').attr('disabled', 'disabled');
        } 
        if (userRights.indexOf('E') < 0) {
            $('#btnSave').attr('disabled', 'disabled');
        }
        ClearPayment();
        ClearDocument();
    }
    function AddPayment() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        ClearPayment();
        $('#frmPayment').modal('show');
    }
    function AddDocument() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        ClearDocument();
        $('#frmDocument').modal('show');
    }
    function DeletePayment() {
        if (userRights.indexOf('D') < 0) {
            ShowMessage('You are not allow to delete',true);
            return;
        }
        $.get(path + 'acc/delvouchersub?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtControlNo').val() + '&item=' + $('#txtItemNo').val()).done(function(r) {
            LoadData();
            ShowMessage(r.voucher.result);
            $('#frmPayment').modal('hide');
            
        });
    }
    function DeleteDocument() {
        if (userRights.indexOf('D') < 0) {
            ShowMessage('You are not allow to delete',true);
            return;
        }
        let sumDoc = Number($('#txtDocSum').val().replace(/[^0-9.-]+/g,""));
        let thisAmt = Number($('#txtPaidAmount').val().replace(/[^0-9.-]+/g,""));
        let sumVoucher = Number($('#txtPRSum').val().replace(/[^0-9.-]+/g,""));
        if ((sumDoc - thisAmt) < sumVoucher) {
            ShowMessage('Voucher amount is not balance',true);
            return;
        }
        $.get(path + 'acc/delvoucherdoc?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtControlNo').val() + '&item=' + $('#txtDocItemNo').val()).done(function(r) {
            SetGridDocument(r.voucher.data[0]);
            ShowSumDocument(r.voucher.data[0]);
            ShowMessage(r.voucher.result);
            $('#frmDocument').modal('hide');
        });
    }
    function ReadData(dt) {
        ClearForm();
        if (dt.header.length > 0) {
            ReadHeader(dt.header[0]);
        }
        if (dt.payment.length > 0) {
            SetGridPayment(dt.payment);
            ShowSumPayment(dt.payment);
        }
        if (dt.document.length > 0) {
            SetGridDocument(dt.document);
            ShowSumDocument(dt.document);
        }
    }
    function ShowSumDocument(dt) {
        let sumDoc = 0;
        for (let o of dt) {
            sumDoc += Number(o.PaidAmount);
        }
        $('#txtDocSum').val(CCurrency(CDbl(sumDoc,2)));
    }
    function ShowSumPayment(dt) {
        let sumPCash = 0;
        let sumPChq = 0;
        let sumPCred = 0;
        let sumRCash = 0;
        let sumRChq = 0;
        let sumRCred = 0;
        let sumPR = 0;

        for (let o of dt) {
            if (o.PRType == 'P') {
                sumPCash += Number(o.CashAmount);
                sumPChq += Number(o.ChqAmount);
                sumPCred += Number(o.CreditAmount);
            }
            if (o.PRType == 'R') {
                sumRCash += Number(o.CashAmount);
                sumRChq += Number(o.ChqAmount);
                sumRCred += Number(o.CreditAmount);
            }
            sumPR += Number(o.CashAmount) + Number(o.ChqAmount) + Number(o.CreditAmount);
        }

        $('#txtPayCash').val(CCurrency(CDbl(sumPCash,2)));
        $('#txtPayChq').val(CCurrency(CDbl(sumPChq,2)));
        $('#txtPayCred').val(CCurrency(CDbl(sumPCred,2)));
        $('#txtPaySum').val(CCurrency(CDbl(sumPCash + sumPChq + sumPCred,2)));

        $('#txtRcvCash').val(CCurrency(CDbl(sumRCash,2)));
        $('#txtRcvChq').val(CCurrency(CDbl(sumRChq,2)));
        $('#txtRcvCred').val(CCurrency(CDbl(sumRCred,2)));
        $('#txtRcvSum').val(CCurrency(CDbl(sumRCash + sumRChq + sumRCred, 2)));

        $('#txtPRSum').val(CCurrency(CDbl(sumPR,2)));
    }
    function SaveData() {
        //if (obj.ControlNo != "") {
        ShowConfirm('Please confirm to save', function (ask) {
            let obj = {
                BranchCode:$('#txtBranchCode').val(),
                ControlNo:$('#txtControlNo').val(),
                VoucherDate:CDateEN($('#txtVoucherDate').val()),
                TRemark:$('#txtTRemark').val(),
                RecUser:$('#txtRecUser').val(),
                RecDate:CDateEN($('#txtRecDate').val()),
                RecTime:$('#txtRecTime').val(),
                PostedBy:$('#txtPostedBy').val(),
                PostedDate:CDateEN($('#txtPostedDate').val()),
                PostedTime:$('#txtPostedTime').val(),
                CancelReson:$('#txtCancelReson').val(),
                CancelProve:$('#txtCancelProve').val(),
                CancelDate:CDateEN($('#txtCancelDate').val()),
                CancelTime:$('#txtCancelTime').val(),
                CustCode: $('#txtCustCode').val(),
                CustBranch: $('#txtCustBranch').val(),
                PostRefNo: $('#txtPostRefNo').val()
            };
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetVoucherHeader", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != '') {
                        $('#txtControlNo').val(response.result.data);
                        $('#txtControlNo').focus();
                        LoadData();
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        });
        //} else {
        //    ShowMessage('No data to Save');
        //}
    }
    function SetGridControl() {
        let w ='?Branch=' + $('#txtBranchCode').val();
        if ($('#txtDateFrom').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDateFrom').val());
        }
        if ($('#txtDateTo').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDateTo').val());
        }
        $.get(path + 'acc/getvouchergrid' + w).done(function(r) {
            if (r.voucher.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.voucher.data[0].Table;
            let tb=$('#tbControl').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "ControlNo", title: "Control No" },
                    {
                        data: "VoucherDate", title: "Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CmpCode", title: "Customer" },
                    { data: "TRemark", title: "Remark" },
                    { data: "PRVoucher", title: "Voucher" },
                    { data: "ChqNo", title: "Cheque No" },
                    {
                        data: "ChqDate", title: "Chq Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "ChqAmount", title: "Chq Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "CashAmount", title: "Cash Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "CreditAmount", title: "Credit Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "CurrencyCode", title: "Currency" },
                    { data: "DocNo", title: "Doc No" }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
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
        });
    }
    function SetGridPayment(list) {
        //show selected details
        let tb=$('#tbHeader').DataTable({
            data: list,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "ChqAmount", title: "Cheque",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "CashAmount", title: "Cash",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "CreditAmount", title: "Credit",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "CurrencyCode", title: "Currency" },
                { data: "PRVoucher", title: "Voucher" },
                { data: "ChqNo", title: "Chq.No" },
                {
                    data: "ChqDate", title: "Chq.Date",
                    render: function (data) {
                        return CDateEN(data);
                    }
                },
                { data: "BankCode", title: "Bank" },
                { data: "BankBranch", title: "Branch" },
                { data: "PayChqTo", title: "Pay From/To" }
            ],
            responsive:true,
            destroy: true
            , pageLength: 100
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
    function SetGridDocument(list) {
        //show selected details
        let tb=$('#tbDetail').DataTable({
            data: list,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "DocNo", title: "Doc.No" },
                { data: "DocType", title: "Type " },
                { data: "DocDate", title: "Date" },
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
        $('#tbDetail tbody').on('click', 'tr', function () {
            $('#tbDetail tbody > tr').removeClass('selected');
            $(this).addClass('selected');
            if (userRights.indexOf('E') > 0) {
                let data = $('#tbDetail').DataTable().row(this).data(); //read current row selected
                ReadDocument(data); //callback function from caller 
                $('#frmDocument').modal('show');
            }
        });
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
            $('#txtPostRefNo').val(dr.PostRefNo);
            if (dr.PostedBy !== '' && dr.PostedBy!==null) {
                $('#chkPosted').prop('checked', true);
                DisableSave();
            }
            $('#txtPostedDate').val(CDateEN(dr.PostedDate));
            $('#txtPostedTime').val(ShowTime(dr.PostedTime));
            $('#txtCancelReson').val(dr.CancelReson);
            $('#txtCancelProve').val(dr.CancelProve);
            if (dr.CancelProve !=='' && dr.CancelProve!==null) {
                $('#chkCancel').prop('checked', true);
                //DisableSave();
            }
            $('#txtCancelDate').val(CDateEN(dr.CancelDate));
            $('#txtCancelTime').val(ShowTime(dr.CancelTime));
            $('#txtCustCode').val(dr.CustCode);
            $('#txtCustBranch').val(dr.CustBranch);
        }
    }
    function DisableSave() {
        $('#btnSave').attr('disabled', 'disabled');
        $('#btnUpdatePay').attr('disabled', 'disabled');
        $('#btnUpdateDoc').attr('disabled', 'disabled');
        $('#btnDelPay').attr('disabled', 'disabled');
        $('#btnDelDoc').attr('disabled', 'disabled');
    }
    function ReadPayment(dr) {
        ClearPayment();
        if (dr !== undefined) {
            $('#txtItemNo').val(dr.ItemNo);
            $('#txtPRVoucher').val(dr.PRVoucher);
            $('#txtPRType').val(dr.PRType);
            $('#cboPRType').val(dr.PRType);
            $('#txtChqNo').val(dr.ChqNo);
            $('#txtBankCode').val(dr.BankCode);
            $('#txtBookCode').val(dr.BookCode);
            $('#txtBankBranch').val(dr.BankBranch);
            $('#txtChqDate').val(CDateEN(dr.ChqDate));
            $('#txtCashAmount').val(dr.CashAmount);
            $('#txtChqAmount').val(dr.ChqAmount);
            $('#txtCreditAmount').val(dr.CreditAmount);
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
            $('#txtIsLocal').val(dr.IsLocal);
            $('#chkIsLocal').prop('checked', dr.IsLocal == 1 ? true : false);
            $('#txtChqStatus').val(dr.ChqStatus);
            $('#cboChqStatus').val(dr.ChqStatus);
            $('#txtDTRemark').val(dr.TRemark);
            $('#txtPayChqTo').val(dr.PayChqTo);
            $('#txtDocNo').val(dr.DocNo);
            $('#txtSICode').val(dr.SICode);            
            $('#txtRecvBank').val(dr.RecvBank);
            $('#txtRecvBranch').val(dr.RecvBranch);
            $('#txtacType').val(dr.acType);
            $('#txtForJNo').val(dr.ForJNo);
            $('#cboacType').val(dr.acType);
            $('#cboacType').change();
            if (dr.BankCode !== '') {
                ShowBookAccount(path, dr.BookCode, '#txtBookName');
                ShowBank(path, dr.BankCode, '#txtBankName');
            } else {
                CallBackQueryBookAccount(path, dr.BranchCode, dr.BookCode, ReadBookAccount);
            }
            CallBackQueryService(path, dr.SICode, ReadService);
            ShowBank(path, dr.RecvBank, '#txtRecvBankName');
        }
    }
    function ReadDocument(dr) {
        if (dr !== undefined) {
            $('#txtDocType').val(dr.DocType);
            $('#cboDocType').val(dr.DocType);
            $('#txtDocItemNo').val(dr.ItemNo);
            $('#txtDDocNo').val(dr.DocNo);
            $('#txtDocDate').val(CDateEN(dr.DocDate));
            $('#txtCmpType').val(dr.CmpType);
            $('#cboCmpType').val(dr.CmpType);
            $('#txtCmpCode').val(dr.CmpCode);
            $('#txtCmpBranch').val(dr.CmpBranch);
            if (dr.CmpType == "C") {
                ShowCustomer(path, dr.CmpCode, dr.CmpBranch, '#txtCmpName');
            }
            if (dr.cmpType == "V") {
                ShowVender(path, dr.CmpCode, '#txtCmpName');
            }
            $('#txtPaidAmount').val(dr.PaidAmount);
            $('#txtTotalAmount').val(dr.TotalAmount);
            $('#txtDocacType').val(dr.acType);
            $('#cboDocacType').val(dr.acType);
        }
    }
    function ClearPayment() {
        $('#txtPRVoucher').val('');
        $('#txtItemNo').val('0');
        $('#txtForJNo').val('');
        $('#txtPRType').val('');
        $('#cboPRType').val('');
        $('#txtChqNo').val('');
        $('#txtBookCode').val('');
        $('#txtBankCode').val('');
        $('#txtBankName').val('');
        $('#txtBankBranch').val('');
        $('#txtChqDate').val('');
        $('#txtCashAmount').val('0.00');
        $('#txtChqAmount').val('0.00');
        $('#txtCreditAmount').val('0.00');
        $('#txtSumAmt').val('0.00');
        $('#txtTotalAmt').val('0.00');
        $('#txtTotalNet').val('0.00');
        $('#txtVatExc').val('0.00');
        $('#txtWhtExc').val('0.00');
        $('#txtVatInc').val('0.00');
        $('#txtWhtInc').val('0.00');
        $('#txtCurrencyCode').val('THB');
        $('#txtCurrencyName').val('THAI BAHT');
        $('#txtExchangeRate').val('1');
        $('#txtIsLocal').val('');
        $('#txtChqStatus').val('');
        $('#cboChqStatus').val('');
        $('#txtDTRemark').val('');
        $('#txtPayChqTo').val('');
        $('#txtRecvBank').val('');
        $('#txtRecvBankName').val('');
        $('#txtRecvBranch').val('');
        $('#txtSICode').val('');
        $('#txtSDescription').val('');
        $('#txtDocNo').val('');
        $('#txtacType').val('');
        $('#cboacType').val('');
        $('#cboacType').change();

        $('#btnAddPay').removeAttr('disabled');
        $('#btnDelPay').removeAttr('disabled');
        $('#chkPosted').removeAttr('disabled');
        $('#chkCancel').removeAttr('disabled');
        $('#btnUpdatePay').removeAttr('disabled');
        if ($('#chkPosted').prop('checked') == true || $('#chkCancel').prop('checked') == true) {
            $('#btnAddPay').attr('disabled', 'disabled');
            $('#chkCancel').attr('disabled', 'disabled');
            $('#chkPosted').attr('disabled', 'disabled');
            $('#btnUpdatePay').attr('disabled', 'disabled');
            $('#btnDelPay').attr('disabled', 'disabled');
        }
        ShowInfo();
    }
    function ClearDocument() {
        $('#txtDocType').val('');
        $('#cboDocType').val('');
        $('#txtDDocNo').val('');
        $('#txtDocItemNo').val('0');
        $('#txtDocDate').val('');
        $('#txtCmpType').val('');
        $('#cboCmpType').val('');
        $('#cboCmpType').change();
        $('#txtCmpCode').val('');
        $('#txtCmpName').val('');
        $('#txtCmpBranch').val('');
        $('#txtPaidAmount').val('0.00');
        $('#txtTotalAmount').val('0.00');
        $('#txtDocacType').val('');
        $('#cboDocacType').val('');

        $('#btnAddDoc').removeAttr('disabled');
        $('#btnDelDoc').removeAttr('disabled');
        $('#btnUpdateDoc').removeAttr('disabled');
        if ($('#chkPosted').prop('checked')==true||$('#chkCancel').prop('checked')==true) {
            $('#btnAddDoc').attr('disabled', 'disabled');
            $('#btnUpdateDoc').attr('disabled', 'disabled');
            $('#btnDelDoc').attr('disabled', 'disabled');
        }
    }
    function SavePayment() {
        //if (obj.PRVoucher != "") {
        ShowConfirm('Please confirm to save', function (ask) {
            let obj = {
                BranchCode: $('#txtBranchCode').val(),
                ControlNo: $('#txtControlNo').val(),
                ItemNo: $('#txtItemNo').val(),
                PRVoucher:$('#txtPRVoucher').val(),
                PRType:$('#txtPRType').val(),
                ChqNo:$('#txtChqNo').val(),
                BookCode:$('#txtBookCode').val(),
                BankCode:$('#txtBankCode').val(),
                BankBranch:$('#txtBankBranch').val(),
                ChqDate:CDateEN($('#txtChqDate').val()),
                CashAmount:CNum($('#txtCashAmount').val()),
                ChqAmount:CNum($('#txtChqAmount').val()),
                CreditAmount: CNum($('#txtCreditAmount').val()),
                SumAmount: CNum($('#txtSumAmt').val()),
                CurrencyCode: $('#txtCurrencyCode').val(),
                ExchangeRate: CNum($('#txtExchangeRate').val()),
                TotalAmount: CNum($('#txtTotalAmt').val()),
                VatExc: CNum($('#txtVatExc').val()),
                VatInc: CNum($('#txtVatInc').val()),
                WhtExc: CNum($('#txtWhtExc').val()),
                WhtInc: CNum($('#txtWhtInc').val()),
                TotalNet: CNum($('#txtTotalNet').val()),
                IsLocal:$('#txtIsLocal').val(),
                ChqStatus:$('#txtChqStatus').val(),
                TRemark:$('#txtDTRemark').val(),
                PayChqTo:$('#txtPayChqTo').val(),
                DocNo:$('#txtDocNo').val(),
                SICode:$('#txtSICode').val(),
                RecvBank:$('#txtRecvBank').val(),
                RecvBranch: $('#txtRecvBranch').val(),
                acType: $('#txtacType').val(),
                ForJNo: $('#txtForJNo').val()
            };
            if (ask == false) return;
            let jsonText = JSON.stringify({ data:[ obj ]});
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetVoucherSub", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data !== '') {
                        SetGridPayment(response.result.data[0]);
                        ShowSumPayment(response.result.data[0]);
                    }
                    ShowMessage("Save " + response.result.msg +"!");
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        });
        //} else {
        //    ShowMessage('No data to Save');
        //}
    }
    function SaveDocument() {       
        if ($('#txtDDocNo').val() !== "") {
            ShowConfirm('Please confirm to save', function (ask) {
                let obj = {
                    BranchCode:$('#txtBranchCode').val(),
                    ControlNo:$('#txtControlNo').val(),
                    ItemNo:$('#txtDocItemNo').val(),
                    DocType:$('#txtDocType').val(),
                    DocNo:$('#txtDDocNo').val(),
                    DocDate:CDateEN($('#txtDocDate').val()),
                    CmpType:$('#txtCmpType').val(),
                    CmpCode:$('#txtCmpCode').val(),
                    CmpBranch:$('#txtCmpBranch').val(),
                    PaidAmount:CNum($('#txtPaidAmount').val()),
                    TotalAmount: CNum($('#txtTotalAmount').val()),
                    acType: $('#txtDocacType').val()
                };
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: [obj] });
                            //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetVoucherDoc", "Acc")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.document !== null) {
                            SetGridDocument(response.result.document[0]);
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
    function ReadVender(dt) {
        $('#txtCmpCode').val(dt.VenCode);
        $('#txtCmpName').val(dt.TName);
        $('#txtCmpBranch').val('');
        $('#txtCmpCode').focus();
    }
    function ReadCompany(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        $('#txtCustCode').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCmpCode').val(dt.CustCode);
        $('#txtCmpBranch').val(dt.Branch);
        $('#txtCmpName').val(dt.NameThai);
        $('#txtCmpCode').focus();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadBank(dt) {
        $('#txtRecvBank').val(dt.Code);
        $('#txtRecvBankName').val(dt.BName);
    }
    function ReadService(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameThai);
    }
    function ReadBookAccount(dt) {
        $('#txtBookCode').val(dt.BookCode);
        $('#txtBookName').val(dt.BookName);
        $('#txtBankCode').val(dt.BankCode);
        ShowBank(path, dt.BankCode, '#txtBankName');
        $('#txtBankBranch').val(dt.BankBranch);
        $('#chkIsLocal').prop('checked', dt.IsLocal = 1 ? true : false);
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
    }
    function GetCmpType() {
        let v = '';
        switch ($('#cboCmpType').val()) {
            case 'C':
                v = 'cust';
                break;
            case 'V':
                v = 'vender';
                break;
            default:
                break;
        }
        return v;
    }
    function CalculateTotal() {
        let amtbase = Number($('#txtSumAmt').val());
        let excrate = Number($('#txtExchangeRate').val());
        let totalamt = amtbase * excrate;
        $('#txtTotalAmt').val(CDbl(totalamt, 4));
        //calculate for exclude vat/wht
        totalamt = Number($('#txtTotalAmt').val());
        let vatexc = Number($('#txtVatExc').val());
        let whtexc = Number($('#txtWhtExc').val());
        totalamt += vatexc;
        totalamt -= whtexc;
        $('#txtTotalNet').val(CDbl(totalamt, 4));

        //calculate base for included vat/wht
        let vatinc = Number($('#txtVatInc').val());
        let whtinc = Number($('#txtWhtInc').val());        
        totalamt += whtinc;
        totalamt -= vatinc;
        $('#txtTotalAmt').val(CDbl(totalamt, 4));
    }
    function PrintData() {
        if (userRights.indexOf('P') < 0) {
            ShowMessage('You are not allow to print',true);
            return;
        }
        window.open(path + 'Acc/FormVoucher?branch=' + $('#txtBranchCode').val() + '&controlno=' + $('#txtControlNo').val());
    }

</script>