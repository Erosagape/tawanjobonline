@Code
    ViewBag.Title = "invoice"
End Code
<div class="panel-body">
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
        <div class="col-sm-6">
            <label id="lblCustCode">Customer:</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtCustCode" style="width:20%" disabled />
                <input type="text" class="form-control" id="txtCustBranch" style="width:10%" disabled />
                <input type="button" class="btn btn-default" value="..." onclick="SearchData('customer');" />
                <input type="text" class="form-control" id="txtCustName" style="width:60%" disabled />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            <label id="lblDocDateF">Invoice Date From:</label>
            <br />
            <input type="date" class="form-control" id="txtDocDateF" />
        </div>
        <div class="col-sm-2">
            <label id="lblDocDateT">Invoice Date To:</label>
            <br />
            <input type="date" class="form-control" id="txtDocDateT" />
        </div>
        <div class="col-sm-3">
            <br />
            <a href="#" class="btn btn-primary" id="btnShow">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
            <a href="#" class="btn btn-default w3-purple" id="btnGen" onclick="CreateInvoice()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkGen">Create Invoice</b>
            </a>
        </div>
    </div>
    <ul class="nav nav-tabs">
        <li class="active">
            <a data-toggle="tab" href="#tabHeader" id="linkHeader">Headers</a>
        </li>
        <li>
            <a data-toggle="tab" href="#tabDetail" id="linkDetail">Details</a>
        </li>
    </ul>
    <div class="tab-content">
        <input type="checkbox" id="chkCancel" /><label id="lblCancel">Show Cancel Only</label>
        <div class="tab-pane fade in active" id="tabHeader">
            <table id="tbHeader" class="table table-responsive">
                <thead>
                    <tr>
                        <th>#</th>
                        <th class="all">DocNo</th>
                        <th class="desktop">DocDate</th>
                        <th class="desktop">CustCode</th>
                        <th>Remark</th>
                        <th class="desktop">Discount</th>
                        <th class="desktop">Cust.Adv</th>
                        <th class="desktop">Advance</th>
                        <th class="desktop">Charge</th>
                        <th class="desktop">VAT</th>
                        <th class="desktop">WHT</th>
                        <th class="all">Net</th>
                    </tr>
                </thead>
            </table>
        </div>
        <div class="tab-pane fade" id="tabDetail">
            <label id="lblDetInv">Details Of Invoice No:</label>
            <input type="text" id="txtInvNo" style="width:10%" disabled />
            <table id="tbDetail" class="table table-responsive" style="width:100%">
                <thead>
                    <tr>
                        <th>ItemNo</th>
                        <th class="desktop">SICode</th>
                        <th class="all">SDescription</th>
                        <th class="desktop">ExpSlipNo</th>
                        <th class="desktop">AmtAdvance</th>
                        <th class="desktop">AmtCharge</th>
                        <th class="desktop">Currency</th>
                        <th class="desktop">Amt</th>
                        <th class="desktop">AmtDiscount</th>
                        <th class="desktop">AmtVAT</th>
                        <th class="desktop">Amt50Tavi</th>
                        <th class="all">TotalAmt</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="lblPrint">Print</b>
    </a>
    <div id="frmHeader" class="modal modal-lg fade">
        <div class="modal-dialog-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-sm-3">
                            <label id="lblDocNo">Invoice No:</label>
                            <br />
                            <input type="text" id="txtDocNo" class="form-control" disabled />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDocDate">Doc.Date:</label>
                            <br />
                            <input type="date" id="txtDocDate" class="form-control"/>
                        </div>
                        <div class="col-sm-6">
                            <label id="lblDCustCode">Customer:</label>
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtDCustCode" class="form-control" style="width:20%" disabled />
                                <input type="text" id="txtDCustBranch" class="form-control" style="width:15%" disabled />
                                <input type="button" class="btn btn-default" value="..." onclick="SearchData('customer2');" />
                                <input type="text" id="txtDCustName" class="form-control" style="width:65%" disabled />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-3" style="display:flex;flex-direction:column">
                            <input type="hidden" id="txtTotalDiscount" />
                            <label id="lblTotalAdvance">Advance</label><input type="text" id="txtTotalAdvance" class="form-control" disabled />
                            <label id="lblTotalCharge">Charge</label><input type="text" id="txtTotalCharge" class="form-control" disabled />
                            <label id="lblSumDiscount">Disc.Line</label><input type="text" id="txtSumDiscount" class="form-control" disabled />
                            <label id="lblDiscountCal">Disc.Total</label><input type="text" id="txtDiscountCal" class="form-control" disabled />
                            <label id="lblTotalIsTaxCharge">Vatable</label><input type="text" id="txtTotalIsTaxCharge" class="form-control" disabled />
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblVatRate">VAT Rate</label><br />
                                    <input type="text" id="txtVATRate" class="form-control" /><br />
                                </div>
                                <div style="flex:2">
                                    <label id="lblTotalVat">VAT</label><br /><input type="text" id="txtTotalVAT" class="form-control" disabled />
                                </div>
                            </div>
                            <label id="lblTotalIs50Tavi">Taxable</label><input type="text" id="txtTotalIs50Tavi" class="form-control" disabled />
                            <label id="lblTotal50Tavi">WH-Tax</label><input type="text" id="txtTotal50Tavi" class="form-control" disabled />
                            <label id="lblTotalCustAdv">Cust.Adv</label><input type="text" id="txtTotalCustAdv" class="form-control" disabled />
                            <label id="lblTotalNet">Total Inv</label><input type="text" id="txtTotalNet" class="form-control" disabled />
                        </div>
                        <div class="col-sm-5" style="display:flex;flex-direction:column">
                            <p>
                                <label id="lblBillToCustCode">Bill To:</label>
                                <br />
                                <div style="display:flex;flex-direction:row">
                                    <input type="text" id="txtBillToCustCode" class="form-control" style="width:20%" disabled />
                                    <input type="text" id="txtBillToCustBranch" class="form-control" style="width:15%" disabled />
                                    <button class="btn btn-default" onclick="SearchData('billing')">...</button>
                                    <input type="text" id="txtBillToCustName" class="form-control" style="width:65%" disabled />
                                </div>
                                <textarea id="txtBillAddress" style="width:100%" class="form-control-lg" disabled></textarea>
                            </p>
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblBillAcceptNo">Bill.No</label>
                                    :<br /><input type="text" id="txtBillAcceptNo" class="form-control" disabled />
                                </div>
                                <div style="flex:1">
                                    <label id="lblBillIssueDate">Issue Date</label>
                                    :<br /><input type="date" id="txtBillIssueDate" class="form-control" disabled />
                                </div>
                            </div>
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblBillAcceptDate">Accept Date</label>
                                    :<br /><input type="date" id="txtBillAcceptDate" class="form-control" />
                                </div>
                                <div style="flex:1">
                                    <label id="lblDueDate">Due Date</label>
                                    :<br /><input type="date" id="txtDueDate" class="form-control" />
                                </div>
                            </div>
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblDiscountRate">Discount Rate(%)</label>
                                    :<br /><input type="text" id="txtDiscountRate" class="form-control" onchange="SetDiscount()" />
                                </div>
                                <div style="flex:2">
                                    <label id="lblCalDiscount">Discount</label>
                                    :<br /><input type="text" id="txtCalDiscount" class="form-control" />
                                </div>
                            </div>
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblCurrencyCode">Currency</label>
                                    :<br />
                                    <div style="display:flex">
                                        <input type="text" id="txtCurrencyCode" class="form-control" disabled />
                                        <button class="btn btn-default" onclick="SearchData('currency')">...</button>
                                    </div>
                                </div>
                                <div style="flex:3">
                                    <br />
                                    <input type="text" id="txtCurrencyName" class="form-control" disabled />
                                </div>
                            </div>
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblExchangeRate">Exchange Rate</label>
                                    :<br /><input type="text" id="txtExchangeRate" class="form-control" onchange="CalForeign()" />
                                </div>
                                <div style="flex:1">
                                    <label id="lblForeignNet">Total Foreign</label>
                                    :<br /><input type="text" id="txtForeignNet" class="form-control" />
                                </div>
                            </div>
                            <div>
                                <label id="lblCancelReson">Cancel Reason</label>
                                :<br /> <textarea id="txtCancelReson" class="form-control-lg" style="width:100%"></textarea>
                                <button id="btnCancel" class="btn btn-danger" onclick="CancelData()">Cancel</button>
                            </div>
                            <div style="display:flex;flex-direction:row">
                                <div style="flex:1">
                                    <label id="lblCancelDate">Cancel date</label>
                                    :<br /> <input type="date" id="txtCancelDate" class="form-control" disabled />
                                </div>
                                <div style="flex:1">
                                    <label id="lblCancelTime">Cancel Time</label>
                                    :<br /><input type="text" id="txtCancelTime" class="form-control" disabled />
                                </div>
                                <div style="flex:1">
                                    <label id="lblCancelProve">Cancel By</label>
                                    :<br /> <input type="text" id="txtCancelProve" class="form-control" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <label id="lblCreateDate">Create Date</label>
                            : <input type="date" id="txtCreateDate" class="form-control" disabled />
                            <p>
                                <label id="lblContactName">Cust contact</label>
                                :<input type="text" id="txtContactName" class="form-control" />
                            </p>
                            <p>
                                <label id="lblShippingRemark">Shipping Note</label>
                                :<br />
                                <textarea id="txtShippingRemark" style="width:100%" class="form-control-lg"></textarea>
                            </p>
                            <label id="lblRemark">Remark</label>
                            :
                            <input type="text" id="txtRemark1" class="form-control" />
                            <input type="text" id="txtRemark2" class="form-control" />
                            <input type="text" id="txtRemark3" class="form-control" />
                            <input type="text" id="txtRemark4" class="form-control" />
                            <input type="text" id="txtRemark5" class="form-control" />
                            <input type="text" id="txtRemark6" class="form-control" />
                            <input type="text" id="txtRemark7" class="form-control" />
                            <input type="text" id="txtRemark8" class="form-control" />
                            <input type="text" id="txtRemark9" class="form-control" />
                            <input type="text" id="txtRemark10" class="form-control" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div style="float:left">
                        <a href="#" class="btn btn-success" id="btnUpdate" onclick="SaveData()">
                            <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                        </a>
                        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print</b>
                        </a>
                    </div>
                    <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                </div>
            </div>
        </div>
    </div>
    <div id="frmDetail" class="modal modal-lg fade">
        <div class="modal-dialog-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-sm-4">
                            <div style="display:flex;">
                                <div>
                                    <label id="lblDDocNo">Invoice No</label>
                                    <br />
                                    <input type="text" id="txtDDocNo" class="form-control" style="width:150px" disabled />
                                </div>
                                <div>
                                    <label id="lblItemNo">Item No.</label>
                                    <br />
                                    <input type="text" id="txtItemNo" class="form-control" style="width:50px" disabled />
                                </div>
                                <div>
                                    <label id="lblExpSlipNO">Slip No</label>
                                    <br /><input type="text" class="form-control" id="txtExpSlipNO" style="width:100%" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <label id="lblSICode">Code</label>
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtSICode" class="form-control" style="width:20%" disabled />
                                <input type="text" id="txtSDescription" class="form-control" style="width:80%" />

                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <label id="lblDCurrencyCode">Currency</label>
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtDCurrencyCode" class="form-control" style="width:20%" disabled />
                                <input type="button" id="btnCurr" class="btn btn-default" value="..." onclick="SearchData('dcurrency')" />
                                <input type="text" id="txtDCurrencyName" class="form-control" disabled />
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div style="display:flex">
                                <div style="flex:1">
                                    <label id="lblDExchangeRate">Exc.Rate</label>
                                    <br />
                                    <input type="text" id="txtDExchangeRate" class="form-control" onchange="CalForeignDetail()" />
                                </div>
                                <div style="flex:2">
                                    <label id="lblDiscountType">Discount</label>
                                    <br />
                                    <div style="display:flex">
                                        <select id="txtDiscountType" class="form-control" style="width:40%" onchange="ShowDiscount()">
                                            <option value="0" selected>Percent</option>
                                            <option value="1">Cash</option>
                                        </select>
                                        <input type="text" id="txtDiscountPerc" class="form-control" style="width:60%" onchange="CalDiscountDetail()" />
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                    <p>
                        <div class="row">
                            <div class="col-sm-6">
                                <label id="lblSRemark">Remark</label>
                                <textarea id="txtSRemark" style="width:100%"></textarea>
                                <input type="hidden" id="txtCurrencyCodeCredit" />
                                <input type="hidden" id="txtExchangeRateCredit" />
                            </div>
                            <div class="col-sm-6" style="display:flex;flex-direction:row">
                                <div style="flex-direction:column;flex:1">
                                    <label id="lblQty">Qty</label>
                                    <input type="text" class="form-control" id="txtQty" />
                                </div>
                                <div style="flex-direction:column;flex:1">
                                    <label id="lblQtyUnit">Unit</label>
                                    <input type="text" class="form-control" id="txtQtyUnit" />
                                </div>
                                <div style="flex-direction:column;flex:1">
                                    <label id="lblUnitPrice">Price(B)</label>
                                    <input type="text" class="form-control" id="txtUnitPrice" />
                                </div>
                                <div style="flex-direction:column;flex:1">
                                    <label id="lblAmt">Amount(B)</label>
                                    <input type="text" class="form-control" id="txtAmt" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div style="display:flex;flex-direction:column">
                                    <div style="display:flex;flex-direction:row;">
                                        <div style="flex:1">
                                            <label id="lblIsTaxCharge">VAT</label>
                                            <br />
                                            <select id="txtIsTaxCharge" class="form-control dropdown" >
                                                <option value="0">NO</option>
                                                <option value="1">EX</option>
                                                <option value="2">IN</option>
                                            </select>
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblDVATRate">Rate</label>
                                            <br />
                                            <input type="text" id="txtDVATRate" class="form-control"  onchange="CalVATWHT(0)" />
                                        </div>
                                        <div style="flex:1">
                                            <br />
                                            <input type="text" id="txtAmtVat" class="form-control" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblAmtDiscount">Discount (B)</label>
                                            <br />
                                            <input type="text" id="txtAmtDiscount" class="form-control" onchange="CalVATWHT(0)" />
                                        </div>
                                    </div>
                                    <div style="display:flex;flex-direction:row;">
                                        <div style="flex:1">
                                            <label id="lblIs50Tavi">WHT</label>
                                            <br />
                                            <select id="txtIs50Tavi" class="form-control dropdown">
                                                <option value="0">NO</option>
                                                <option value="1">YES</option>
                                            </select>
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblRate50Tavi">Rate</label>
                                            <br />
                                            <input type="text" id="txtRate50Tavi" class="form-control" onchange="CalVATWHT(0)" />
                                        </div>
                                        <div style="flex:1">
                                            <br />
                                            <input type="text" id="txtAmt50Tavi" class="form-control" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblFAmtDiscount">Discount (F)</label>
                                            <br />
                                            <input type="text" id="txtFAmtDiscount" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div style="display:flex;flex-direction:column">
                                    <div style="display:flex;flex-direction:row;">
                                        <div style="flex:1">
                                            <label id="lblFAmtCredit">Credit (F)</label>
                                            <br />
                                            <input type="text" class="form-control" id="txtFAmtCredit" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblAmtCredit">Credit (B)</label>
                                            <br />
                                            <input type="text" class="form-control" id="txtAmtCredit" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblFUnitPrice">Price(F)</label>
                                            <br />
                                            <input type="text" class="form-control" id="txtFUnitPrice" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblFAmt">Amount(F)</label>
                                            <br />
                                            <input type="text" class="form-control" id="txtFAmt" />
                                        </div>
                                    </div>
                                    <div style="display:flex;flex-direction:row;">
                                        <div style="flex:1">
                                            <b id="lblAmtAdvance">Advance</b><br />
                                            <input type="text" class="form-control" id="txtAmtAdvance" style="font:bold" />
                                        </div>
                                        <div style="flex:1">
                                            <b id="lblAmtCharge">Charge</b><br />
                                            <input type="text" class="form-control" id="txtAmtCharge" style="font:bold" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblFTotalAmt">Total(F)</label>
                                            <br /><input type="text" class="form-control" id="txtFTotalAmt" />
                                        </div>
                                        <div style="flex:1">
                                            <label id="lblTotalAmt">Total(B)</label>
                                            <br /><input type="text" class="form-control" id="txtTotalAmt" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </p>
                </div>
                <div class="modal-footer">
                    <div style="float:left">
                        <a href="#" class="btn btn-success" id="btnUpd" onclick="SaveDetail()">
                            <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkUpdate">Save</b>
                        </a>
                        <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteDetail()">
                            <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
                        </a>
                    </div>
                    <button id="btnHid" class="btn btn-danger" data-dismiss="modal">X</button>
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
    const userRights = '@ViewBag.UserRights';
    let code = getQueryString("Code");
    let branch = getQueryString("Branch");

    let row = {};
    let row_d = {};
    SetLOVs();
    if (branch !== '' && code !== '') {
        $('#txtBranchCode').val(branch);
        ShowHeader();
    }
    $('#btnShow').on('click', function () {
        ShowHeader();
    });
    function ShowHeader() {
        let w = '';
        if ($('#txtCustCode').val() !== '') {
            w += '&cust=' + $('#txtCustCode').val();
        }
        if ($('#txtDocDateF').val() !== "") {
            w += '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w += '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        if ($('#chkCancel').prop('checked') == true) {
            w += '&show=CANCEL';
        } else {
            w += '&show=ACTIVE';
        }
        if (code !== '') {
            w += '&Code=' + code;
        }
        $.get(path + 'acc/getinvforbill?branch=' + $('#txtBranchCode').val()+ w).done(function (r)
        {
            if (r.invdetail.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.invdetail.data;
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    {
                        data: null, title: "#",
                        render: function (data, type, full, meta) {
                            let html = "<button class='btn btn-warning'>Edit</button>";
                            return html;
                        }
                    },
                    { data: "DocNo", title: "Inv No" },
                    {
                        data: "DocDate", title: "Inv date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "RefNo", title: "Reference Number" },
                    { data: "TotalDiscount", title: "Discount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalCustAdv", title: "Cust.Adv",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalAdvance", title: "Advance",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalCharge", title: "Charge",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalVAT", title: "VAT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "Total50Tavi", title: "WHT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalNet", title: "NET",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page,
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                SetSelect('#tbHeader', this);
                row = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                row_d = {};
                ReadData();
                ShowDetail(row.BranchCode, row.DocNo);
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                $('a[href="#tabDetail"]').click();
            });
            $('#tbHeader tbody').on('click', 'button', function () {
                if (userRights.indexOf('E') > 0) {
                    $('#frmHeader').modal('show');
                } else {
                    ShowMessage('You are not allow to edit',true);
                }
            });
        });
    }
    function PrintData() {
        let code = row.DocNo;
        if (code !== '') {
            let branch = row.BranchCode;
            window.open(path + 'Acc/FormInv?Branch=' + branch + '&Code=' + code,'_blank');
        }
    }
    function ShowDetail(branch, code) {
        $('#tbDetail').DataTable().clear().draw();
        $.get(path + 'Acc/GetInvDetail?branch=' + branch + '&code=' + code, function (r) {
            if (r.invdetail.data.length > 0) {
                let d = r.invdetail.data;
                let tb=$('#tbDetail').DataTable({
                    data: d,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: "ItemNo", title: "No" },
                        { data: "SICode", title: "Code" },
                        { data: "SDescription", title: "Desc" },
                        { data: "ExpSlipNO", title: "Slip" },
                        { data: "AmtAdvance", title: "Advance",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtCharge", title: "Charge",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: null, title: "Currency", render:function(data) {
                                return data.CurrencyCode + '=' + data.ExchangeRate;
                            }
                        },
                        { data: "Amt", title: "Amount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtDiscount", title: "Discount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtVat", title: "VAT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "Amt50Tavi", title: "WHT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "TotalAmt", title: "NET",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        }
                    ],
                    responsive:true,
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
                $('#tbDetail tbody').on('click', 'tr', function () {
                    SetSelect('#tbDetail', this);
                    if (userRights.indexOf('E') > 0) {
                        let data = $('#tbDetail').DataTable().row(this).data();
                        LoadDetail(data);
                    } else {
                        ShowMessage('You are not allow to edit',true);
                    }
                });
            }
        });
    }
    function SetLOVs() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocDateF').val(GetFirstDayOfMonth());
        $('#txtDocDateT').val(GetLastDayOfMonth());

        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchCust2', '#tbCust2', 'Customers', response, 3);
            //Customers
            CreateLOV(dv, '#frmSearchBill', '#tbBill', 'Billing Place', response, 3);

            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,4);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency Code', response, 4);
        });
    }
    function LoadDetail(dt) {
        row_d = dt;
        $('#txtDDocNo').val(dt.DocNo);
        $('#txtItemNo').val(dt.ItemNo);
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.SDescription);
        $('#txtExpSlipNO').val(dt.ExpSlipNO);
        $('#txtSRemark').val(dt.SRemark);
        $('#txtDCurrencyCode').val(dt.CurrencyCode);
        ShowCurrency(path, dt.CurrencyCode, '#txtDCurrencyName');
        $('#txtDExchangeRate').val(dt.ExchangeRate);
        $('#txtQty').val(dt.Qty);
        $('#txtQtyUnit').val(dt.QtyUnit);
        $('#txtUnitPrice').val(ShowNumber(dt.UnitPrice,2));
        $('#txtFUnitPrice').val(ShowNumber(dt.FUnitPrice, 2));
        $('#txtAmt').val(ShowNumber(dt.Amt, 2));
        $('#txtFAmt').val(ShowNumber(dt.FAmt, 2));
        $('#txtDiscountType').val(dt.DiscountType);
        $('#txtDiscountPerc').val(dt.DiscountPerc);
        $('#txtAmtDiscount').val(ShowNumber(dt.AmtDiscount, 2));
        $('#txtFAmtDiscount').val(ShowNumber(dt.FAmtDiscount, 2));
        $('#txtIs50Tavi').val(dt.Is50Tavi);
        $('#txtRate50Tavi').val(dt.Rate50Tavi);
        $('#txtAmt50Tavi').val(ShowNumber(dt.Amt50Tavi,2));
        $('#txtIsTaxCharge').val(dt.IsTaxCharge);
        $('#txtAmtVat').val(ShowNumber(dt.AmtVat,2));
        $('#txtTotalAmt').val(ShowNumber(dt.TotalAmt,2));
        $('#txtFTotalAmt').val(ShowNumber(dt.FTotalAmt,2));
        $('#txtAmtAdvance').val(ShowNumber(dt.AmtAdvance,2));
        $('#txtAmtCharge').val(ShowNumber(dt.AmtCharge, 2));
        $('#txtDVATRate').val(ShowNumber(dt.VATRate,0));
        $('#txtCurrencyCodeCredit').val(dt.CurrencyCodeCredit);
        $('#txtExchangeRateCredit').val(dt.ExchangeRateCredit);
        $('#txtAmtCredit').val(ShowNumber(dt.AmtCredit,2));
        $('#txtFAmtCredit').val(ShowNumber(dt.FAmtCredit, 2));

        $('#frmDetail').modal('show');
    }
    function SaveDetail() {
        if (row_d !== null) {
            row_d.SDescription = $('#txtSDescription').val();
            row_d.ExpSlipNO = $('#txtExpSlipNO').val();
            row_d.SRemark = $('#txtSRemark').val();
            row_d.CurrencyCode = $('#txtDCurrencyCode').val();
            row_d.ExchangeRate = $('#txtDExchangeRate').val();
            row_d.FUnitPrice = CNum($('#txtFUnitPrice').val());
            row_d.FAmt = CNum($('#txtFAmt').val());
            row_d.DiscountType = $('#txtDiscountType').val();
            row_d.DiscountPerc = CNum($('#txtDiscountPerc').val());
            row_d.AmtDiscount = CNum($('#txtAmtDiscount').val());
            row_d.FAmtDiscount = CNum($('#txtFAmtDiscount').val());
            row_d.Amt50Tavi = CNum($('#txtAmt50Tavi').val());
            row_d.AmtVat = CNum($('#txtAmtVat').val());
            row_d.TotalAmt = CNum($('#txtTotalAmt').val());
            row_d.FTotalAmt = CNum($('#txtFTotalAmt').val());
            row_d.AmtAdvance = CNum($('#txtAmtAdvance').val());
            row_d.AmtCharge = CNum($('#txtAmtCharge').val());
            row_d.QtyUnit = $('#txtQtyUnit').val();
            row_d.IsTaxCharge = $('#txtIsTaxCharge').val();
            row_d.Is50Tavi = $('#txtIs50Tavi').val();
            row_d.VATRate = $('#txtDVATRate').val();
            row_d.Rate50Tavi = $('#txtRate50Tavi').val();

            let jsonText = JSON.stringify({ data: row_d });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetInvDetail", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data !== null) {
                        ShowDetail(row.BranchCode, row.DocNo);
                        ShowMessage(response.result.msg + '\n=>' + response.result.data);
                        $('#frmDetail').modal('hide');
                        return;
                    }
                    ShowMessage(response.result.msg,true);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    function DeleteDetail() {
        if (row_d !== null) {
            $.get(path+ 'Acc/DelInvDetail?Branch=' + row.BranchCode + '&Code=' + row.DocNo + '&Item=' + row_d.ItemNo)
                .done(function (r) {
                    if (r.invdetail.data !== null) {
                        ShowDetail(row.BranchCode, row.DocNo);
                    }
                    ShowMessage(r.invdetail.result);
                });
        } else {
            ShowMessage('No data to delete',true);
        }

    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
            case 'customer2':
                SetGridCompany(path, '#tbCust2', '#frmSearchCust2', ReadCustomer2);
                break;
            case 'billing':
                SetGridCompany(path, '#tbBill', '#frmSearchBill', ReadBilling);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
            case 'dcurrency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadDCurrency);
                break;
        }
    }
    function SaveData() {
         let dataInv = {
            BranchCode:$('#txtBranchCode').val(),
            DocNo: $('#txtDocNo').val(),
            DocType:row.DocType,
            DocDate: CDateEN($('#txtDocDate').val()),
            CustCode:$('#txtDCustCode').val(),
            CustBranch:$('#txtDCustBranch').val(),
            BillToCustCode:$('#txtBillToCustCode').val(),
            BillToCustBranch:$('#txtBillToCustBranch').val(),
            ContactName:$('#txtContactName').val(),
            EmpCode:user,
            PrintedBy:row.PrintedBy,
            PrintedDate:CDateEN(row.PrintedDate),
            PrintedTime:row.PrintedTime,
            RefNo: row.RefNo,
            VATRate:CDbl($('#txtVATRate').val(),0),
            TotalAdvance:CNum($('#txtTotalAdvance').val()),
            TotalCharge:CNum($('#txtTotalCharge').val()),
            TotalIsTaxCharge:CNum($('#txtTotalIsTaxCharge').val()),
            TotalIs50Tavi:CNum($('#txtTotalIs50Tavi').val()),
            TotalVAT:CNum($('#txtTotalVAT').val()),
            Total50Tavi:CNum($('#txtTotal50Tavi').val()),
            TotalCustAdv:CNum($('#txtTotalCustAdv').val()),
            TotalNet:CNum($('#txtTotalNet').val()),
            CurrencyCode:$('#txtCurrencyCode').val(),
            ExchangeRate:CNum($('#txtExchangeRate').val()),
            ForeignNet: CNum($('#txtForeignNet').val()),
            TotalDiscount: CNum($('#txtTotalDiscount').val()),
            SumDiscount: CNum($('#txtSumDiscount').val()),
            DiscountRate: CNum($('#txtDiscountRate').val()),
            DiscountCal:CNum($('#txtDiscountCal').val()),
            BillAcceptDate:CDateEN($('#txtBillAcceptDate').val()),
            BillIssueDate:CDateEN($('#txtBillIssueDate').val()),
            BillAcceptNo:$('#txtBillAcceptNo').val(),
            Remark1:$('#txtRemark1').val(),
            Remark2:$('#txtRemark2').val(),
            Remark3:$('#txtRemark3').val(),
            Remark4:$('#txtRemark4').val(),
            Remark5:$('#txtRemark5').val(),
            Remark6:$('#txtRemark6').val(),
            Remark7:$('#txtRemark7').val(),
            Remark8:$('#txtRemark8').val(),
            Remark9:$('#txtRemark9').val(),
            Remark10:$('#txtRemark10').val(),
            CancelReson:$('#txtCancelReson').val(),
            CancelProve:$('#txtCancelProve').val(),
            CancelDate:CDateEN($('#txtCancelDate').val()),
            CancelTime:$('#txtCancelTime').val(),
            ShippingRemark: $('#txtShippingRemark').val(),
            DueDate: CDateEN($('#txtDueDate').val()),
            CreateDate:row.CreateDate
        };
        let jsonString = JSON.stringify({ data: dataInv });
        $.ajax({
            url: "@Url.Action("SetInvHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    ShowHeader();
                    ShowMessage(response.result.data);
                    $('#frmHeader').modal('hide');
                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function CancelData() {
        if (userRights.indexOf('D') > 0) {
            if ($('#txtCancelReson').val() == '') {
                ShowMessage('Please enter reason for cancel',true);
                $('#txtCancelReson').focus();
                return;
            }
            if ($('#txtBillAcceptNo').val() !== '') {
                ShowMessage('This invoice is already billed,Please cancel billing', true);
                return;
            }
            $.get(path + 'Acc/GetRcpDetail?Branch=' + $('#txtBranchCode').val() + '&InvNo=' + $('#txtDocNo').val()).done(function (r) {
                if (r.rcpdetail.data.length > 0) {
                    if (mainLanguage == 'TH') {
                        ShowMessage('ใบแจ้งหนี้นี้ได้ออกใบรับเงิน/ไปแล้วในเลขที่ ' + r.rcpdetail.data[0].ReceiptNo,true);
                    } else {
                        ShowMessage('This invoice has been received in ' + r.rcpdetail.data[0].ReceiptNo,true);
                    }
                } else {
                    $('#txtCancelDate').val(GetToday());
                    $('#txtCancelTime').val(ShowTime(GetTime()));
                    $('#txtCancelProve').val(user);
                    SaveData();
                }
            });
        } else {
            ShowMessage('You are not allow to cancel',true);
        }
    }
    function ReadData() {
        $('#txtInvNo').val(row.DocNo);
        $('#txtDocNo').val(row.DocNo);
        $('#txtDocDate').val(CDateEN(row.DocDate));
        $('#txtDCustCode').val(row.CustCode);
        $('#txtDCustBranch').val(row.CustBranch);
        ShowCustomer(path, row.CustCode, row.CustBranch, '#txtDCustName');
        $('#txtContactName').val(row.ContactName);
        $('#txtShippingRemark').val(row.ShippingRemark);
        $('#txtBillToCustCode').val(row.BillToCustCode);
        $('#txtBillToCustBranch').val(row.BillToCustBranch);
        ShowCustomerAddress(path, row.BillToCustCode, row.BillToCustBranch, '#txtBillToCustName', '#txtBillAddress');
        $('#txtBillAcceptNo').val(row.BillAcceptNo);
        $('#txtBillIssueDate').val(CDateEN(row.BillIssueDate));
        $('#txtBillAcceptDate').val(CDateEN(row.BillAcceptDate));
        $('#txtDueDate').val(CDateEN(row.DueDate));
        $('#txtDiscountRate').val(row.DiscountRate);
        $('#txtDiscountCal').val(ShowNumber(row.DiscountCal,2));
        $('#txtCurrencyCode').val(row.CurrencyCode);
        $('#txtExchangeRate').val(row.ExchangeRate);
        $('#txtVATRate').val(CDbl(row.VATRate));
        ShowCurrency(path, row.CurrencyCode, '#txtCurrencyName');
        $('#txtForeignNet').val(ShowNumber(row.ForeignNet,2));
        $('#txtRemark1').val(row.Remark1);
        $('#txtRemark2').val(row.Remark2);
        $('#txtRemark3').val(row.Remark3);
        $('#txtRemark4').val(row.Remark4);
        $('#txtRemark5').val(row.Remark5);
        $('#txtRemark6').val(row.Remark6);
        $('#txtRemark7').val(row.Remark7);
        $('#txtRemark8').val(row.Remark8);
        $('#txtRemark9').val(row.Remark9);
        $('#txtRemark10').val(row.Remark10);
        $('#txtTotalAdvance').val(ShowNumber(row.TotalAdvance,2));
        $('#txtTotalCharge').val(ShowNumber(row.TotalCharge,2));
        $('#txtSumDiscount').val(ShowNumber(row.SumDiscount,2));
        $('#txtCalDiscount').val(ShowNumber(row.DiscountCal,2));
        $('#txtTotalDiscount').val(ShowNumber(row.TotalDiscount,2));
        $('#txtTotalCustAdv').val(ShowNumber(row.TotalCustAdv,2));
        $('#txtTotalIsTaxCharge').val(ShowNumber(row.TotalIsTaxCharge,2));
        $('#txtTotalIs50Tavi').val(ShowNumber(row.TotalIs50Tavi,2));
        $('#txtTotalVAT').val(ShowNumber(row.TotalVAT,2));
        $('#txtTotal50Tavi').val(ShowNumber(row.Total50Tavi,2));
        $('#txtTotalNet').val(ShowNumber(row.TotalNet,2));
        $('#txtCancelReson').val(row.CancelReson);
        $('#txtCancelDate').val(CDateEN(row.CancelDate));
        $('#txtCancelTime').val(ShowTime(row.CancelTime));
        $('#txtCancelProve').val(row.CancelProve);
        $('#txtCreateDate').val(CDateEN(row.CreateDate));
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
    function ReadCustomer2(dt) {
        $('#txtDCustCode').val(dt.CustCode);
        $('#txtDCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtDCustName');
    }
    function ReadBilling(dt) {
        $('#txtBillToCustCode').val(dt.CustCode);
        $('#txtBillToCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtBillToCustName');
        $('#txtBillAddress').val(dt.TAddress1 + '' + dt.TAddress2);
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
        $('#txtExchangeRate').focus();
    }
    function ReadDCurrency(dt) {
        $('#txtDCurrencyCode').val(dt.Code);
        $('#txtDCurrencyName').val(dt.TName);
        $('#txtDExchangeRate').focus();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ShowDiscount() {
        let chk = $('#txtDiscountType').val();
        if (chk === "1") {
            $('#txtDiscountPerc').val(0);
            $('#txtDiscountPerc').attr('disabled', 'disabled');
        } else {
            $('#txtDiscountPerc').removeAttr('disabled');
        }
    }
    function SetDiscount() {
        let amt = CNum($('#txtTotalAdvance').val()) + CNum($('#txtTotalCharge').val()) - CNum($('#txtSumDiscount').val()) + CNum($('#txtTotalVAT').val()) - CNum($('#txtTotal50Tavi').val()) - CNum($('#txtTotalCustAdv').val());
        let disc = amt * Number($('#txtDiscountRate').val()) * 0.01;
        $('#txtCalDiscount').val(ShowNumber(disc, 2));
        $('#txtDiscountCal').val(ShowNumber(disc,2));
        SumDiscount();
    }
    function SumDiscount() {
        let totaldisc = CNum($('#txtSumDiscount').val()) + CNum($('#txtCalDiscount').val());
        $('#txtTotalDiscount').val(ShowNumber(totaldisc,2));
        CalTotal();
    }
    function CalTotal() {
        let totaldisc = CNum($('#txtSumDiscount').val()) + CNum($('#txtCalDiscount').val());
        let totalnet = CNum($('#txtTotalAdvance').val()) + CNum($('#txtTotalCharge').val())- totaldisc + CNum($('#txtTotalVAT').val()) - CNum($('#txtTotal50Tavi').val()) - CNum($('#txtTotalCustAdv').val());
        $('#txtTotalNet').val(ShowNumber(totalnet,2));
        CalForeign();
    }
    function CalForeign() {
        let totalforeign = CDbl(CNum($('#txtTotalNet').val()) / CNum($('#txtExchangeRate').val()), 2);
        $('#txtForeignNet').val(ShowNumber(totalforeign,2));
    }
    function CalForeignDetail() {
        let rate = CNum($('#txtDExchangeRate').val());
        $('#txtFUnitPrice').val(CDbl(CNum($('#txtUnitPrice').val()) / rate, 2));
        $('#txtFAmt').val(CDbl(CNum($('#txtAmt').val()) / rate, 2));
        $('#txtFTotalAmt').val(CDbl(CNum($('#txtTotalAmt').val()) / rate, 2));
        //$('#txtFAmtCredit').val(CDbl(CNum($('#txtAmtCredit').val()) / rate, 2));
        $('#txtFAmtDiscount').val(CDbl(CNum($('#txtAmtDiscount').val()) / rate, 2));
        if (CNum($('#txtAmtAdvance').val()) > 0) {
            $('#txtAmtAdvance').val(ShowNumber($('#txtFTotalAmt').val(), 2));
        }
        if (CNum($('#txtAmtCharge').val()) > 0) {
            $('#txtAmtCharge').val(ShowNumber(CNum($('#txtFAmt').val()) - CNum($('#txtFAmtDiscount').val()), 2));
        }
    }
    function CalDiscountDetail() {
        let amt = CNum($('#txtAmt').val());
        let disc = amt * CNum($('#txtDiscountPerc').val()) * 0.01;
        $('#txtAmtDiscount').val(ShowNumber(disc,2));
        CalVATWHT(0);
    }
    function CalVATWHT(step = 0) {
        let amt = CNum($('#txtAmt').val())-CNum($('#txtAmtDiscount').val());
        if (step == 0) {
            let vat = amt * CNum($('#txtDVATRate').val()) * 0.01;
            $('#txtAmtVat').val(ShowNumber(vat,2));
        }
        let wht = amt * CNum($('#txtRate50Tavi').val()) * 0.01;
        $('#txtAmt50Tavi').val(ShowNumber(wht, 2));
        CalNetAmount();
    }
    function CalNetAmount() {
        let amt = CNum($('#txtAmt').val()) - CNum($('#txtAmtDiscount').val());
        let vat = CNum($('#txtAmtVat').val());
        let wht = CNum($('#txtAmt50Tavi').val());
        let net = amt + vat - wht;

        $('#txtTotalAmt').val(ShowNumber(net, 2));
        CalForeignDetail();
    }
    function CreateInvoice() {
        let w = '';
        if ($('#txtCustCode').val() !== '') {
            w += '&custcode=' + $('#txtCustCode').val() + '&custbranch=' + $('#txtCustBranch').val();
        }
        window.open(path +'clr/generateinv?branch=' + $('#txtBranchCode').val() + w, '_blank');
    }
</script>


