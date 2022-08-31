@Code
    ViewBag.Title = "Quotation"
End Code
<style>
    @@media only screen and (max-width: 600px) {
        #btnAdd,#btnCancel,#btnPrint {
            width:100%;
        }
    } 
</style>
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
                <a href="../Master/Customers" target="_blank"><label id="lblCustomer">Customer</label></a>:
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtCustCode" class="form-control" style="width:130px" />
                    <input type="text" id="txtCustBranch" class="form-control" style="width:70px" />
                    <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                    <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <label id="lblDateFrom">Date From</label>:<br />
                <input type="date" class="form-control" id="txtDocDateF" />
            </div>
            <div class="col-sm-2">
                <label id="lblDateTo"></label>:<br />
                <input type="date" class="form-control" id="txtDocDateT" />
            </div>
            <div class="col-sm-6">
                <br />
                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddHeader()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b><label id="lblAddQuo">New Quotation</label></b>
                </a>
                <a href="#" class="btn btn-warning" id="btnCopy" onclick="CopyData()">
                    <i class="fa fa-lg fa-close"></i>&nbsp;<b><label id="lblCopyQuo">Copy Quotation</label></b>
                </a>
                <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                    <i class="fa fa-lg fa-print"></i>&nbsp;<b><label id="lblPrintQuo">Print Quotation</label></b>
                </a>
                <a href="#" class="btn btn-primary" id="btnSearch" onclick="ShowHeader()">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b><label id="lblSearch">Search</label></b>
                </a>
                <input type="checkbox" id="chkCancel" /><b><label id="lblShowCancel" style="color:red">Show Cancel Only</label></b>
            </div>
        </div>
        <div>
            <ul class="nav nav-tabs">
                <li class="active">
                    <a data-toggle="tab" id="linkHeader" href="#tabHeader">Headers</a>
                </li>
                <li>
                    <a data-toggle="tab" id="linkDetail" href="#tabDetail">Details</a>
                </li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane fade in active" id="tabHeader">
                    <table id="tbHeader" class="table table-responsive">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th class="all">Quotation No</th>
                                <th class="desktop">Doc Date</th>
                                <th class="desktop">Customer</th>
                                <th class="desktop">Billing To</th>
                                <th class="desktop">Remark</th>
                                <th class="desktop">Contact Name</th>
                                <th class="desktop">Manager Name</th>
                                <th class="desktop">Approve Date</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div class="tab-pane fade" id="tabDetail">
                    <p>
                        <label id="lblDetail">Details of Quotation No</label>
                        :<input type="text" id="txtDocNo" style="width:10%" disabled />
                        <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
                            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b><label id="lblAddSection">Add Section</label></b>
                        </a>
                        <table id="tbDetail" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Seq</th>
                                    <th class="desktop">Job Type</th>
                                    <th class="desktop">Ship By</th>
                                    <th class="all">Description</th>
                                </tr>
                            </thead>
                        </table>
                        <a href="#" class="btn btn-danger" id="btnDelDetail" onclick="DeleteDetail()">
                            <i class="fa fa-lg fa-trash"></i>&nbsp;<b><label id="lblDelSection">Delete Section</label></b>
                        </a>
                    </p>
                </div>
            </div>
        </div>
        <div id="frmHeader" class="modal fade">
            <div class="modal-dialog-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4><b><label id="lblQuoHeader">Add/Edit Quotation</label></b></h4>
                        <div class="row">
                            <div class="col-sm-2">
                                <label id="lblQNo">Quotation No</label>:<br /> <input type="text" id="txtQNo" class="form-control" disabled />
                            </div>
                            <div class="col-sm-2">
                                <label id="lblDocDate">Issue Date</label>:<br /> <input type="date" id="txtDocDate" class="form-control" />
                            </div>
                            <div class="col-sm-2">
                                <label id="lblStatus">Status</label> :<br />
                                <select id="txtDocStatus" class="form-control dropdown" disabled>
                                    <option value="0">REQUEST</option>
                                    <option value="1">APPROVE</option>
                                    <option value="99">CANCEL</option>
                                </select>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblReferQNo">Refer Q.No</label> : <br />
                                <input type="text" id="txtReferQNo" class="form-control" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblDCust">Customer:</label>                                
                                <br/>
                                <div style="display:flex;flex-direction:row">
                                    <input type="text" id="txtDCustCode" class="form-control" style="width:130px" disabled />
                                    <input type="text" id="txtDCustBranch" class="form-control" style="width:70px" disabled />
                                    <input type="text" id="txtDCustName" class="form-control" style="width:100%" disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <a href="../Master/Customers" target="_blank"><label id="lblBillingTo">เก็บเงินที่</label></a>:<br />
                                <div style="display:flex">
                                    <input type="text" id="txtBCustCode" style="width:150px" disabled />
                                    <input type="text" id="txtBCustBranch" style="width:100px" disabled />
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('billing')" />
                                    <input type="text" id="txtBCustName" style="width:100%" disabled />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <label id="lblManager">Manager</label>:<br />
                                <div style="display:flex">
                                    <input type="text" id="txtManagerCode" style="width:150px" disabled />
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('sales')" />
                                    <input type="text" id="txtManagerName" style="width:100%" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label id="lblDescriptionH">Header</label>:
                                <br />
                                <div style="display:flex">
                                    <textarea id="txtDescriptionH" class="form-control"></textarea>
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('header')" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <label id="lblDescriptionF">Footer</label>:
                                <br />
                                <div style="display:flex">
                                    <textarea id="txtDescriptionF" class="form-control"></textarea>
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('footer')" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label id="lblContact">Contact Name</label>:
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtContactName" class="form-control" style="width:100%" />
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('contact')" />
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <label id="lblRemark">Remark</label>:
                                <br />
                                <div style="display:flex">
                                    <textarea id="txtTRemark" class="form-control"></textarea>
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('remark')" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblApproveBy">Approve By</label>:<input type="text" id="txtApproveBy" style="width:100%" disabled />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblApproveDate">Approve Date</label>:
                                        <br /><input type="date" id="txtApproveDate" disabled /> &nbsp;
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblApproveTime">Approve Time</label>:
                                        <br /><input type="text" id="txtApproveTime" disabled /> &nbsp;
                                    </div>
                                </div>
                                <button id="btnApprove" class="btn btn-primary" onclick="ApproveData()">Approve</button>
                            </div>
                            <div class="col-sm-3" style="display:flex">
                                <div style="flex:1">
                                    <label id="lblCancelBy">Cancel By</label>:<br />
                                    <input type="text" id="txtCancelBy" style="width:100%" disabled />
                                </div>
                                <div style="flex:1">
                                    <label id="lblCancelDate">Cancel Date</label>:<br />
                                    <input type="date" id="txtCancelDate" disabled /> &nbsp;
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblCancelReason">Cancel Reason</label>:<br />
                                <textarea id="txtCancelReason" style="width:100%"></textarea>
                                <button id="btnCancel" class="btn btn-danger" onclick="CancelData()">Cancel</button>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <button class="btn btn-success" id="btnUpdate" onclick="SaveData()">
                                <i id="lblSaveQuo" class="fa fa-lg fa-save">Update Quotation</i>
                            </button>
                            <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
                                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b><label id="lblNewSectionD">Add Detail</label></b>
                            </a>
                            <a href="#" class="btn btn-info" id="btnPrintQ" onclick="PrintData()">
                                <i class="fa fa-lg fa-print"></i>&nbsp;<b><label>Print Quotation</label></b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmDetail" class="modal">
            <div class="modal-dialog-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div style="display:flex">
                            <h4><b><label id="lblSection">Section And Expenses</label></b></h4>
                        </div>
                        <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
                            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b><label id="lblNewSection">New Section</label></b>
                        </a>
                        <div class="row">
                            <div class="col-sm-2">
                                <label id="lblSeqNo">Section No</label>:<br />
                                <input type="text" id="txtSeqNo" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblJobType">Job Type</label> :<br /><select id="txtJobType" class="form-control dropdown" value="0" onchange="CheckJobType()" ></select>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblShipBy">Ship By</label> :<br /><select id="txtShipBy" class="form-control dropdown" value="0"></select>
                            </div>
                            <div class="col-sm-4">
                                <label id="lblSDescription">Description</label>:
                                <br/>
                                <div style="display:flex">
                                    <textarea id="txtDescription" class="form-control"></textarea>
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('desc')" />
                                </div>                                
                            </div>
                        </div>
                        <div>
                            <div style="float:left">
                                <a href="#" class="btn btn-success" id="btnUpdateD" onclick="SaveDetail()">
                                    <i class="fa fa-lg fa-save"></i>&nbsp;<b><label id="lblUpdSection">Update Section</label></b>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="modal-body">
                        <h4><b><label id="lblExpenses">Lists of Expenses</label>:</b></h4>
                        <a href="#" class="btn btn-default w3-purple" id="btnAddItem" onclick="AddItem()">
                            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b><label id="lblNewExpenses">Add Expenses</label></b>
                        </a>
                        <input type="hidden" id="txtDocItemNo" />
                        <table id="tbItem" class="table table-responsive" style="width:100%">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>ItemNo</th>
                                    <th class="desktop">SICode</th>
                                    <th class="all">Description</th>
                                    <th class="desktop">QtyBegin-QtyEnd/Unit</th>
                                    <th class="desktop">Total</th>
                                    <th class="desktop">Disc</th>
                                    <th class="mobile">Net</th>
                                    <th class="desktop">Commission</th>
                                    <th class="desktop">Profit</th>
                                </tr>
                            </thead>
                        </table>
                        <a href="#" class="btn btn-danger" id="btnDelItem" onclick="DeleteItem()">
                            <i class="fa fa-lg fa-trash"></i>&nbsp;<b><label id="lblDelExpenses">Delete Expense</label></b>
                        </a>
                    </div>
                    <div class="modal-footer">
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmItem" class="modal">
            <div class="modal-dialog-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>For <label id="lblHeader"></label></h4>
                        <div class="row">
                            <div class="col-sm-1">
                                <label id="lblItemNo">Item No</label>:<input type="text" class="form-control" id="txtItemNo" disabled />
                            </div>
                            <div class="col-sm-2">
                                <label id="lblCalType">Calculate Type</label>
                                <div style="display:flex">
                                    <select id="txtCalculateType" class="form-control dropdown">
                                        <option value="0">Last Price</option>
                                        <option value="1">Accumulate Price</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblRequired">Required?</label>
                                <select id="txtIsRequired" class="form-control dropdown">
                                    <option value="0">No</option>
                                    <option value="1">Yes</option>
                                </select>
                            </div>
                            <div class="col-sm-4">
                                <label id="lblCurrency">Currency</label>
                                <div style="display:flex">
                                    <input type="text" id="txtCurrencyCode" class="form-control" style="width:20%" disabled />
                                    <input type="button" id="btnCurr" class="btn btn-default" value="..." onclick="SearchData('currency')" />
                                    <input type="text" id="txtCurrencyName" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblExchangeRate">Exc.Rate</label>
                                <div style="display:flex">
                                    <input type="text" id="txtCurrencyRate" class="form-control" onchange="CalAmount()" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-4">
                                <a href="../Master/ServiceCode" target="_blank"><label id="lblSICode">รหัสค่าบริการ</label></a>
                                <div style="display:flex">
                                    <input type="text" id="txtSICode" class="form-control" style="width:20%" disabled />
                                    <input type="button" id="btnServ" class="btn btn-default" value="..." onclick="SearchData('service')" />
                                    <input type="text" id="txtSDescription" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <a href="#" onclick="SearchData('route')"><label id="lblDescriptionTH">Service Description</label></a>
                                <br />
                                <textarea id="txtDescriptionThai" class="form-control"></textarea>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblQtyBegin">Qty Start </label>
                                <div style="display:flex">
                                    <input type="text" id="txtQtyBegin" class="form-control" />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblQtyEnd">Qty End</label>
                                <div style="display:flex">
                                    <input type="text" id="txtQtyEnd" class="form-control" />
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                <label id="lblChargeAmt">Price</label>
                                <div style="display:flex">
                                    <input type="text" id="txtChargeAmt" class="form-control" onchange="CalAmount()" />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblUnitCheck">Unit </label>
                                <div style="display:flex">
                                    <input type="text" class="form-control" id="txtUnitCheck" />
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('unit')" />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <b><label id="lblTotal">Total</label></b>
                                <div style="display:flex">
                                    <input type="text" id="txtTotalAmt" class="form-control" disabled style="font:bold" />
                                </div>
                            </div>
                            <div class="col-sm-1">
                                <label id="lblDiscountType">Discount Type</label>
                                <div style="display:flex">
                                    <select id="txtDiscountType" class="form-control dropdown" onchange="ShowDiscount()">
                                        <option value="0" selected>%</option>
                                        <option value="1">Fix</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-sm-1">
                                <label id="lblDiscountRate">Discount Rate</label>
                                <div style="display:flex">
                                    <input type="text" id="txtUnitDiscntPerc" class="form-control" onchange="CalDiscount()" />
                                </div>
                            </div>
                            <div class="col-sm-1">
                                <label id="lblDiscountB">Discount (B)</label>
                                <div style="display:flex">
                                    <input type="text" id="txtUnitDiscntAmt" class="form-control" onchange="CalDiscount()" disabled />
                                </div>
                            </div>
                            <div class="col-sm-1">
                                <label id="lblDiscountF">Discount (F)</label>
                                <div style="display:flex">
                                    <input type="text" id="txtFUnitDiscntAmt" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <b><label id="lblCharge">Charge</label></b>
                                <div style="display:flex">
                                    <input type="text" id="txtTotalCharge" class="form-control" style="font:bold" disabled />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label id="lblCommType">Commission Type</label>
                                <div style="display:flex">
                                    <select id="txtCommissionType" style="width:20%" class="form-control dropdown" onchange="ShowCommission()">
                                        <option value="0" selected>%</option>
                                        <option value="1">Fix</option>
                                    </select>
                                    <input type="text" id="txtCommissionPerc" class="form-control" style="width:30%" onchange="CalCommission()" />
                                    <input type="text" id="txtCommissionAmt" onchange="CalProfit()" style="width:50%" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <input type="hidden" id="txtIsService" value="0" />
                                <label id="lblVender">Vender</label>
                                <div style="display:flex">
                                    <input type="text" id="txtVenderCode" class="form-control" style="width:150px" disabled />
                                    <input type="button" id="btnBrow" class="btn" value="..." onclick="SearchData('vender')" />
                                    <input type="text" id="txtVenderName" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblCostAmt">Cost Amount</label>
                                <div style="display:flex">
                                    <input type="text" id="txtVenderCost" class="form-control" onchange="CalProfit()" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-5">
                                <label id="lblVAT">VAT</label>
                                <div style="display:flex">
                                    <select id="txtIsvat" style="width:20%" class="form-control dropdown" onchange="CalVATWHT()">
                                        <option value="0">NO</option>
                                        <option value="1">EX</option>
                                        <option value="2">IN</option>
                                    </select>
                                    <input type="text" id="txtVatRate" style="width:30%" class="form-control" onchange="CalVATWHT()" />
                                    <input type="text" id="txtVatAmt" style="width:50%" class="form-control" onchange="CalCommission()" />
                                </div>
                            </div>
                            <div class="col-sm-5">
                                <label id="lblWHT">WHT</label>
                                <div style="display:flex">                                    
                                    <select id="txtIsTax" style="width:20%" class="form-control dropdown" onchange="CalVATWHT()">
                                        <option value="0">NO</option>
                                        <option value="1">YES</option>
                                    </select>
                                    <input type="text" id="txtTaxRate" style="width:30%" class="form-control" onchange="CalVATWHT()" />
                                    <input type="text" id="txtTaxAmt" style="width:50%" class="form-control" onchange="CalCommission()" />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <div style="float:right">
                                    <label id="lblBaseProfit">Base Profit</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtBaseProfit" disabled />
                                </div>
                                <div style="float:right">
                                    <label id="lblNetProfit">Net Profit</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtNetProfit" disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-default w3-purple" id="btnAddItem" onclick="AddItem()">
                                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b><label id="lblAddExpense">Add Expenses</label></b>
                            </a>
                            **Copy Mode <input type="checkbox" id="chkCopy" />
                            <a href="#" class="btn btn-success" id="btnUpdateI" onclick="SaveItem()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b><label id="lblUpdExpense">Update Expenses</label></b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmCopy" class="modal" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <label id="lblCreateFrom">Create Quotation Base From</label>
                    </div>
                    <div class="modal-body">
                        <input type="text" id="txtBaseQNo" class="form-control" />
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnGen" onclick="CreateData()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b><label id="lblCreate">Create</label></b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
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
    let row = {};
    let row_d = {};
    let row_i = {};
    let chkmode = '';
    let jt = '';

    SetLOVs();

    function CheckJobType() {
        if (jt !== $('#txtJobType').val()) {
            jt = $('#txtJobType').val();
            loadShipByByType(path, jt, '#txtShipBy');
            return;
        }
        return;
    }
    function ShowHeader() {
        ShowWait();
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
        $('#tbHeader').DataTable().clear().draw();
        $('#tbDetail').DataTable().clear().draw();
        $('#tbItem').DataTable().clear().draw();
        ClearHeader();
        ClearDetail();
        ClearItem();
        $.get(path + 'joborder/getquotation?branch=' + $('#txtBranchCode').val() + w, function (r) {
            CloseWait();
            if (r.quotation.header.length == 0) {                
                //ShowMessage('Data not found');
                return;
            }
            let h = r.quotation.header;
            row = {};
            row_d = {};
            row_i = {};
            let tb= $('#tbHeader').DataTable({
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
                    { data: "QNo", title: "Quotation No" },
                    {
                        data: "DocDate", title: "Doc Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "BillToCustCode", title: "Billing To" },
                    { data: "TRemark", title: "Remark" },
                    { data: "ContactName", title: "Contact Name" },
                    { data: "ManagerCode", title: "Manager Name" },
                    {
                        data: "ApproveDate", title: "Approve Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    }                    
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                SetSelect('#tbHeader', this);
                ClearHeader();
                row = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                $('#txtCustCode').val(row.CustCode);
                $('#txtCustBranch').val(row.CustBranch);
                $('#txtBCustCode').val(row.BillToCustCode);
                $('#txtBCustBranch').val(row.BillToCustBranch);
                ShowCustomer(path, row.CustCode, row.CustBranch, '#txtCustName');
                ReadData();
                ShowDetail(row.BranchCode, row.QNo);
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
    function ShowItem(branch, code, seq) {
        $('#tbItem').DataTable().clear().draw();
        row_i = {};
        $.get(path + 'JobOrder/GetQuoItem?Branch=' + branch + '&Code=' + code + '&Seq=' + seq, function (r) {
            if (r.quotation.items.length > 0) {
                let d = r.quotation.items;
                let tb= $('#tbItem').DataTable({
                    data: d,
                    selected: true,
                    columns: [
                        {
                            data: null, title: "#",
                            render: function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Edit</button>";
                                return html;
                            }
                        },
                        { data: "ItemNo", title: "Seq" },
                        { data: "SICode", title: "Code" },
                        { data: "DescriptionThai", title: "Description" },
                        {
                            data: null, title: "Qty",
                            render: function (data) {
                                return data.QtyBegin + '-' + data.QtyEnd + '/' + data.UnitCheck;
                            }
                        },
                        {
                            data: "TotalAmt", title: "Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "UnitDiscntAmt", title: "Discount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "TotalCharge", title: "Net",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "CommissionAmt", title: "Commission",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "NetProfit", title: "Profit",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        }
                    ],
                    responsive:true,
                    destroy: true
                    , pageLength: 100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbItem');
                $('#tbItem tbody').on('click', 'tr', function () {
                    SetSelect('#tbItem', this);
                    row_i = $('#tbItem').DataTable().row(this).data();
                    ReadItem();
                });
                $('#tbItem tbody').on('dblclick', 'tr', function () {
                    EditItem();
                });
                $('#tbItem tbody').on('click', 'button', function () {
                    EditItem();
                });
            }
        });
    }
    function EditItem() {
        if (userRights.indexOf('E') > 0) {
            $('#frmItem').modal('show');
        } else {
            ShowMessage('You are not allow to edit',true);
        }
    }
    function ShowDetail(branch, code) {
        $('#tbDetail').DataTable().clear().draw();
        row_d = {};
        row_i = {};
        $.get(path + 'JobOrder/GetQuotation?Branch=' + branch + '&Code=' + code, function (r) {
            if (r.quotation.detail.length > 0) {
                let d = r.quotation.detail;
                let tb= $('#tbDetail').DataTable({
                    data: d,
                    selected: true,
                    columns: [
                        {
                            data: null, title: "#",
                            render: function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Edit</button>";
                                return html;
                            }
                        },
                        { data: "SeqNo", title: "Seq" },
                        { data: "JobTypeName", title: "Job Type" },
                        { data: "ShipByName", title: "Ship By" },
                        { data: "Description", title: "Description" }
                    ],
                    responsive:true,
                    destroy: true
                    , pageLength: 100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
                $('#tbDetail tbody').on('click', 'tr', function () {
                    SetSelect('#tbDetail', this);
                    row_d = $('#tbDetail').DataTable().row(this).data();
                    ShowItem(row_d.BranchCode, row_d.QNo, row_d.SeqNo);
                    ReadDetail();
                });
                $('#tbDetail tbody').on('dblclick', 'tr', function () {
                    EditDetail();
                });
                $('#tbDetail tbody').on('click', 'button', function () {
                    EditDetail();                    
                });
            }
        });
    }
    function EditDetail() {
        if (userRights.indexOf('E') > 0) {
            $('#frmDetail').modal('show');
        } else {
            ShowMessage('You are not allow to edit',true);
        }
    }
    function PrintData() {
        let code = row.QNo;
        if (code !== '') {
            let branch = row.BranchCode;
            window.open(path + 'JobOrder/FormQuotation?Branch=' + branch + '&docno=' + code, '_blank');
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
            $('#txtDocStatus').val('99');
        } else {
            ShowMessage('You are not allow to cancel',true);
        }
    }
    function ApproveData() {
        chkmode = $('#txtApproveBy').val() == '' ? 'I' : 'D';
        CallBackAuthorize(path, 'MODULE_SALES', 'QuoApprove',chkmode, SetApprove);
    }
    function SetApprove(b) {
        if (b == true) {
            $('#txtApproveBy').val(chkmode == 'I' ? user : '');
            $('#txtApproveDate').val(chkmode == 'I' ? GetToday() : '');
            $('#txtApproveTime').val(chkmode == 'I' ? ShowTime(GetTime()) : '');
            if (row.DocStatus !== '99') $('#txtDocStatus').val(chkmode == 'I' ? '1' : '0');
            $('#btnUpdate').removeAttr('disabled');
        } else {
            ShowMessage('You are not allow to approve',true);
        }
    }
    function SaveData() {
        if ($('#txtBCustCode').val() == '') {
            ShowMessage('Please choose billing place',true);
            return;
        }
        if ($('#txtManagerCode').val() == '') {
            ShowMessage('Please choose manager code',true);
            return;
        }
        row.BranchCode = $('#txtBranchCode').val();
        row.QNo = $('#txtQNo').val();
        row.ReferQNo = $('#txtReferQNo').val();
        row.CustCode = $('#txtCustCode').val();
        row.CustBranch = $('#txtCustBranch').val();
        row.BillToCustCode = $('#txtBCustCode').val();
        row.BillToCustBranch = $('#txtBCustBranch').val();
        row.ContactName = $('#txtContactName').val();
        row.DocDate = CDateEN($('#txtDocDate').val());
        row.ManagerCode = $('#txtManagerCode').val();
        row.DescriptionH = $('#txtDescriptionH').val();
        row.DescriptionF = $('#txtDescriptionF').val();
        row.TRemark = $('#txtTRemark').val();
        row.DocStatus = $('#txtDocStatus').val();
        row.ApproveBy = $('#txtApproveBy').val();
        row.ApproveDate = CDateEN($('#txtApproveDate').val());
        row.ApproveTime = $('#txtApproveTime').val();
        row.CancelBy = $('#txtCancelBy').val();
        row.CancelDate = CDateEN($('#txtCancelDate').val());
        row.CancelReason = $('#txtCancelReason').val();

        let jsonString = JSON.stringify({ data: row });

        $.ajax({
            url: "@Url.Action("SetQuoHeader", "JobOrder")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    ShowHeader();
                    $('#txtDocNo').val(response.result.data);
                    $('#txtQNo').val(response.result.data);
                    ShowMessage('Save Quotation=>'+response.result.data);                    
                    return;
                }
                ShowMessage(response.result.msg,true);
                return;
            },
            error: function (e) {
                ShowMessage(e,true);
                return;
            },            
        });
        return;
    }
    function SaveDetail() {
        row_d.BranchCode = $('#txtBranchCode').val();
        row_d.QNo = $('#txtDocNo').val();
        row_d.SeqNo = $('#txtSeqNo').val();
        row_d.JobType = $('#txtJobType').val();
        row_d.ShipBy = $('#txtShipBy').val();
        row_d.Description = $('#txtDescription').val();
        row_d.JobTypeName = null;
        row_d.ShipByName = null;

        let jsonString = JSON.stringify({ data: row_d });
        $.ajax({
            url: "@Url.Action("SetQuoDetail", "JobOrder")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    $('#txtSeqNo').val(response.result.data);
                    ShowDetail($('#txtBranchCode').val(), $('#txtDocNo').val());
                    $('#txtDocItemNo').val(response.result.data);
                    ShowItem($('#txtBranchCode').val(), $('#txtDocNo').val(), $('#txtSeqNo').val());
                    ShowMessage('Save Section=>'+ response.result.data);
                    //$('#frmDetail').modal('hide');
                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function SaveItem() {
        row_i.BranchCode = $('#txtBranchCode').val();
        row_i.QNo = $('#txtDocNo').val();
        row_i.SeqNo = $('#txtSeqNo').val();
        row_i.ItemNo = $('#txtItemNo').val();
        row_i.SICode = $('#txtSICode').val();
        row_i.DescriptionThai = $('#txtDescriptionThai').val();
        row_i.CalculateType = $('#txtCalculateType').val();
        row_i.QtyBegin = $('#txtQtyBegin').val();
        row_i.QtyEnd = $('#txtQtyEnd').val();
        row_i.UnitCheck = $('#txtUnitCheck').val();
        row_i.CurrencyCode = $('#txtCurrencyCode').val();
        row_i.CurrencyRate = $('#txtCurrencyRate').val();
        row_i.ChargeAmt = $('#txtChargeAmt').val();
        row_i.Isvat = $('#txtIsvat').val();
        row_i.VatRate = $('#txtVatRate').val();
        row_i.VatAmt = $('#txtVatAmt').val();
        row_i.IsTax = $('#txtIsTax').val();
        row_i.TaxRate = $('#txtTaxRate').val();
        row_i.TaxAmt = $('#txtTaxAmt').val();
        row_i.TotalAmt = $('#txtTotalAmt').val();
        row_i.TotalCharge = $('#txtTotalCharge').val();
        row_i.UnitDiscntPerc = $('#txtUnitDiscntPerc').val();
        row_i.UnitDiscntAmt = $('#txtUnitDiscntAmt').val();
        row_i.VenderCode = $('#txtVenderCode').val();
        row_i.VenderCost = $('#txtVenderCost').val();
        row_i.BaseProfit = $('#txtBaseProfit').val();
        row_i.CommissionPerc = $('#txtCommissionPerc').val();
        row_i.CommissionAmt = $('#txtCommissionAmt').val();
        row_i.NetProfit = $('#txtNetProfit').val();
        row_i.IsRequired = $('#txtIsRequired').val();

        let jsonString = JSON.stringify({ data: row_i });
        $.ajax({
            url: "@Url.Action("SetQuoItem", "JobOrder")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    $('#txtDocItemNo').val(response.result.data);
                    ShowItem($('#txtBranchCode').val(), $('#txtDocNo').val(), $('#txtSeqNo').val());
                    ShowMessage('Save Item=>' +response.result.data);
                    //$('#frmItem').modal('hide');
                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function DeleteDetail() {
        if (userRights.indexOf('D') < 0) {
            ShowMessage('You are not allow to delete',true);
            return;
        }
        if (row_d.SeqNo !== undefined) {
            ShowConfirm('Please confirm to delete', function (result) {
                if (result == true) {
                    $.get(path+ 'JobOrder/DelQuoDetail?Branch=' + row_d.BranchCode + '&Code=' + row_d.QNo + '&Seq=' + row_d.SeqNo)
                        .done(function (r) {
                            if (r.quodetail.data !== null) {
                                ShowDetail(row.BranchCode, row.QNo);
                                row_d = {};
                                row_i = {};
                                $('#tbItem').DataTable().clear().draw();
                            }
                            ShowMessage(r.quodetail.result);
                        });
                }
            });
        } else {
            ShowMessage('No data to delete',true);
        }
    }
    function DeleteItem() {
        if (userRights.indexOf('D') < 0) {
            ShowMessage('You are not allow to delete',true);
            return;
        }
        if (row_i.ItemNo !== undefined) {
            ShowConfirm('Please confirm to delete', function (result) {
                if (result == true) {
                    $.get(path+ 'JobOrder/DelQuoItem?Branch=' + row_i.BranchCode + '&Code=' + row_i.QNo + '&Seq=' + row_i.SeqNo + '&Item=' + row_i.ItemNo)
                        .done(function (r) {
                            if (r.quoitem.data !== null) {
                                ShowItem(row_d.BranchCode, row_d.QNo, row_d.SeqNo);
                                row_i = {};
                            }
                            ShowMessage(r.quoitem.result);
                        });
                }
            });
        } else {
            ShowMessage('No data to delete',true);
        }
    }
    function AddHeader() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        if ($('#txtBranchCode').val() == '') {
            ShowMessage('Please input branch',true);
            return;
        }
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            return;
        }
        ShowHeader();
        $('#frmHeader').modal('show');
    }
    function ClearHeader() {
        row_d = {};
        row_i = {};
        $('#txtQNo').val('');
        $('#txtDocNo').val('');
        $('#txtDocItemNo').val('');
        $('#txtReferQNo').val('');
        $('#txtDocDate').val(GetToday());
        if ($('#txtBCustCode').val() == '') {
            $('#txtBCustCode').val($('#txtCustCode').val());
            $('#txtBCustBranch').val($('#txtCustBranch').val());
            $('#txtBCustName').val($('#txtCustName').val());
            GetContact();
        }
        $('#txtApproveDate').val('');
        $('#txtApproveTime').val('');
        $('#txtApproveBy').val('');
        $('#txtTRemark').val('');
        $('#txtDocStatus').val('0');
        $('#txtCancelReason').val('');
        $('#txtCancelBy').val('');
        $('#txtCancelDate').val('');        
        $('#txtManagerCode').val(user);
        ShowUser(path, user, '#txtManagerName');
        $('#txtDescriptionH').val('');
        $('#txtDescriptionF').val('');

        $('#btnUpdate').attr('disabled', 'disabled');
        $('#btnUpdateI').attr('disabled', 'disabled');
        $('#btnUpdateD').attr('disabled', 'disabled');
        $('#btnDelItem').attr('disabled', 'disabled');
        $('#btnDelDetail').attr('disabled', 'disabled');
        if (userRights.indexOf('E') >= 0 || userRights.indexOf('I') >= 0) {
            $('#btnUpdate').removeAttr('disabled');
            $('#btnUpdateI').removeAttr('disabled');
            $('#btnUpdateD').removeAttr('disabled');
        }
        if (userRights.indexOf('D') >= 0) {
            $('#btnDelItem').removeAttr('disabled');
            $('#btnDelDetail').removeAttr('disabled');
        }
    }
    function ClearDetail() {
        $('#txtSeqNo').val('0');
        $('#txtJobType').val('');
        $('#txtShipBy').val('');
        $('#txtDescription').val('');
        $('#tbItem').DataTable().clear().draw();
    }
    function ClearItem() {
        $('#lblHeader').text($('#txtDescription').val());
        $('#txtItemNo').val('0');
        $('#txtSICode').val('');
        $('#txtSDescription').val('');
        $('#txtDescriptionThai').val('');
        $('#txtCalculateType').val('0');
        $('#txtQtyBegin').val(1);
        $('#txtQtyEnd').val(1);
        $('#txtUnitCheck').val('');
        $('#txtCurrencyCode').val('@ViewBag.PROFILE_CURRENCY');
        $('#txtCurrencyName').val('THAI BAHT');
        $('#txtCurrencyRate').val(1);
        $('#txtChargeAmt').val(0);
        $('#txtIsvat').val('0');
        $('#txtVatRate').val('0');
        $('#txtVatAmt').val('0');
        $('#txtIsTax').val('0');
        $('#txtIsService').val('0');
        $('#txtTaxRate').val('0');
        $('#txtTaxAmt').val('0');
        $('#txtTotalAmt').val('0');
        $('#txtTotalCharge').val('0');
        $('#txtDiscountType').val('0');
        ShowDiscount();
        $('#txtUnitDiscntPerc').val('0');
        $('#txtUnitDiscntAmt').val('0');
        $('#txtFUnitDiscntAmt').val('0');
        $('#txtVenderCode').val('');
        $('#txtVenderName').val('');
        $('#txtVenderCost').val('0');
        $('#txtBaseProfit').val('0');
        $('#txtCommissionType').val('0');
        ShowCommission();
        $('#txtCommissionPerc').val('0');
        $('#txtCommissionAmt').val('0');
        $('#txtNetProfit').val('0');
        $('#txtIsRequired').val('1');
    }
    function AddDetail() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        if ($('#txtDocNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        row_d = {};
        ClearDetail();
        $('#frmDetail').modal('show');
    }
    function AddItem() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        if ($('#txtDocItemNo').val() == '') {
            ShowMessage('Please enter some data first',true);
            return;
        }
        row_i = {};
        if ($('#chkCopy').prop('checked') == false) {
            ClearItem();
        } else {
            $('#txtItemNo').val('0');
        }
        $('#frmItem').modal('show');
    }
    function SetLOVs() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');

        let lists = 'JOB_TYPE=#txtJobType|,SHIP_BY=#txtShipBy|';
        loadCombos(path, lists);

        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchBill', '#tbBill', 'Billing Place', response, 3);
            //currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
            //Vender
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            //users
            CreateLOV(dv, '#frmSearchUser', '#tbUser', 'Users', response, 2);
            //Contact
            CreateLOV(dv, '#frmSearchCont', '#tbCont', 'Contact Person', response, 3);
            //routes
            CreateLOV(dv, '#frmSearchRoute', '#tbRoute', 'Service Routes', response, 4);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //Service 
            CreateLOV(dv, '#frmSearchServ', '#tbServ', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchUnit', '#tbUnit', 'Unit', response, 2);
            //Quotation Remark,header,footer
            CreateLOV(dv, '#frmSearchRemark', '#tbRemark', 'Remark List', response, 1);
            CreateLOV(dv, '#frmSearchHeader', '#tbListHeader', 'Header List', response, 1);
            CreateLOV(dv, '#frmSearchFooter', '#tbListFooter', 'Footer List', response, 1);
            
            CreateLOV(dv, '#frmSearchDesc', '#tbDesc', 'Description List', response, 1);
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
            case 'billing':
                SetGridCompany(path, '#tbBill', '#frmSearchBill', ReadBilling);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'sales':
                SetGridUser(path, '#tbUser', '#frmSearchUser', ReadManager);
                break;
            case 'service':
                SetGridSICode(path, '#tbServ','', '#frmSearchServ', ReadService);
                break;
            case 'contact':
                let w = '?Branch=' + $('#txtBCustBranch').val() + '&Code=' + $('#txtBCustCode').val();
                SetGridCustContact(path, '#tbCont' , w,'#frmSearchCont', ReadContactName);
                break;
            case 'remark':
                SetGridDataDistinct(path, '#tbRemark', '?Table=Job_QuotationHeader&Field=TRemark', '#frmSearchRemark', ReadRemark);
                break;
            case 'header':
                SetGridDataDistinct(path, '#tbListHeader', '?Table=Job_QuotationHeader&Field=DescriptionH', '#frmSearchHeader', ReadHeader);
                break;
            case 'footer':
                SetGridDataDistinct(path, '#tbListFooter', '?Table=Job_QuotationHeader&Field=DescriptionF', '#frmSearchFooter', ReadFooter);
                break;
            case 'desc':
                SetGridDataDistinct(path, '#tbDesc', '?Table=Job_QuotationDetail&Field=Description', '#frmSearchDesc', ReadDesc);
                break;
            case 'route':
                SetGridTransportPrice(path, '#tbRoute', '#frmSearchRoute', '?Branch=' + $('#txtBranchCode').val() + '&Cust=' + $('#txtCustCode').val(), ReadPrice);
                break;
            case 'unit':
                SetGridServUnit(path, '#tbUnit', '#frmSearchUnit', ReadUnit);
                break;
        }
    }
    function ReadUnit(dt) {
        $('#txtUnitCheck').val(dt.UnitType);
    }
    function ReadRemark(dt) {
        $('#txtTRemark').val(dt.val);
    }
    function ReadHeader(dt) {
        $('#txtDescriptionH').val(dt.val);
    }
    function ReadFooter(dt) {
        $('#txtDescriptionF').val(dt.val);
    }
    function ReadDesc(dt) {
        $('#txtDescription').val(dt.val);
    }
    function ReadData() {
        $('#txtQNo').val(row.QNo);
        $('#txtDocNo').val(row.QNo);
        $('#txtReferQNo').val(row.ReferQNo);
        $('#txtDocDate').val(CDateEN(row.DocDate));
        $('#txtDCustCode').val(row.CustCode);
        $('#txtDCustBranch').val(row.CustBranch);
        ShowCustomer(path, row.CustCode, row.CustBranch, '#txtDCustName');
        $('#txtBCustCode').val(row.BillToCustCode);
        $('#txtBCustBranch').val(row.BillToCustBranch);
        ShowCustomer(path, row.BillToCustCode, row.BillToCustBranch, '#txtBCustName');
        $('#txtContactName').val(row.ContactName);
        $('#txtApproveDate').val(CDateEN(row.ApproveDate));
        $('#txtApproveTime').val(ShowTime(row.ApproveTime));
        $('#txtApproveBy').val(row.ApproveBy);
        $('#txtTRemark').val(row.TRemark);
        $('#txtDocStatus').val(row.DocStatus);
        $('#txtCancelReason').val(row.CancelReason);
        $('#txtCancelBy').val(row.CancelBy);
        $('#txtCancelDate').val(CDateEN(row.CancelDate));        
        $('#txtManagerCode').val(row.ManagerCode);
        ShowUser(path, row.ManagerCode, '#txtManagerName');
        $('#txtDescriptionH').val(row.DescriptionH);
        $('#txtDescriptionF').val(row.DescriptionF);

        $('#btnUpdate').attr('disabled', 'disabled');
        $('#btnUpdateI').attr('disabled', 'disabled');
        $('#btnUpdateD').attr('disabled', 'disabled');
        $('#btnDelItem').attr('disabled', 'disabled');
        $('#btnDelDetail').attr('disabled', 'disabled');
        if (row.DocStatus == 0 && userRights.indexOf('E') >= 0) {
            $('#btnUpdate').removeAttr('disabled');
            $('#btnUpdateI').removeAttr('disabled');
            $('#btnUpdateD').removeAttr('disabled');
        }
        if (row.DocStatus == 0 && userRights.indexOf('D') >= 0) {
            $('#btnDelItem').removeAttr('disabled');
            $('#btnDelDetail').removeAttr('disabled');
        }
    }
    function ReadDetail() {
        $('#txtDocItemNo').val(row_d.SeqNo);
        $('#txtSeqNo').val(row_d.SeqNo);
        $('#txtJobType').val(CCode(row_d.JobType));
        $('#txtShipBy').val(CCode(row_d.ShipBy));
        $('#txtDescription').val(row_d.Description);
    }
    function ReadPrice(dt) {
        if (dt !== undefined) {
            $('#txtSICode').val(dt.ChargeCode);
            ShowServiceCode(path, dt.ChargeCode, '#txtSDescription');
            $('#txtDescriptionThai').val(dt.Location);
            $('#txtChargeAmt').val(CDbl(dt.ChargeAmount, 2));
            $('#txtVenderCost').val(CDbl(dt.CostAmount, 2));
            $('#txtVenderCode').val(dt.VenderCode);
            CalAmount();
        }
    }
    function ReadItem() {
        $('#lblHeader').text(row_d.Description);
        $('#txtItemNo').val(row_i.ItemNo);
        $('#txtSICode').val(row_i.SICode);
        ShowServiceCode(path, row_i.SICode, '#txtSDescription');
        $('#txtDescriptionThai').val(row_i.DescriptionThai);
        $('#txtCalculateType').val(row_i.CalculateType);
        $('#txtQtyBegin').val(row_i.QtyBegin);
        $('#txtQtyEnd').val(row_i.QtyEnd);
        $('#txtUnitCheck').val(row_i.UnitCheck);
        $('#txtCurrencyCode').val(row_i.CurrencyCode);
        ShowCurrency(path, row_i.CurrencyCode, '#txtCurrencyName');
        $('#txtCurrencyRate').val(row_i.CurrencyRate);
        $('#txtChargeAmt').val(CDbl(row_i.ChargeAmt,2));
        $('#txtIsvat').val(row_i.Isvat);
        $('#txtVatRate').val(row_i.VatRate);
        $('#txtVatAmt').val(CDbl(row_i.VatAmt,2));
        $('#txtIsTax').val(row_i.IsTax);
        $('#txtTaxRate').val(row_i.TaxRate);
        $('#txtTaxAmt').val(CDbl(row_i.TaxAmt,2));
        $('#txtTotalAmt').val(CDbl(row_i.TotalAmt,2));
        $('#txtTotalCharge').val(CDbl(row_i.TotalCharge,2));
        $('#txtDiscountType').val((row_i.UnitDiscntPerc > 0 ? '0' : '1'));
        ShowDiscount();
        $('#txtUnitDiscntPerc').val(row_i.UnitDiscntPerc);
        $('#txtUnitDiscntAmt').val(CDbl(row_i.UnitDiscntAmt,2));
        $('#txtVenderCode').val(row_i.VenderCode);
        ShowVender(path, row_i.VenderCode, '#txtVenderName');
        $('#txtVenderCost').val(CDbl(row_i.VenderCost, 2));
        if (row_i.VenderCost > 0) {
            $('#txtIsService').val('0');
        } else {
            $('#txtIsService').val('1');
        }
        $('#txtBaseProfit').val(CDbl(row_i.BaseProfit,2));
        $('#txtCommissionType').val((row_i.CommissionPerc > 0 ? '0' : '1'));
        ShowCommission();
        $('#txtCommissionPerc').val(row_i.CommissionPerc);
        $('#txtCommissionAmt').val(CDbl(row_i.CommissionAmt,2));
        $('#txtNetProfit').val(CDbl(row_i.BaseProfit,2));
        $('#txtIsRequired').val(row_i.IsRequired);
        CalAmount();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        $('#txtCustName').val(dt.Title + ' ' + dt.NameThai);
        $('#txtDCustCode').val(dt.CustCode);
        $('#txtDCustBranch').val(dt.Branch);
        $('#txtDCustName').val(dt.Title + ' ' + dt.NameThai);
        $('#txtBCustCode').val(dt.BillToCustCode);
        $('#txtBCustBranch').val(dt.BillToBranch);
        $('#txtCommissionPerc').val(dt.CommRate);
        GetContact();
        let w = '?Branch=' + $('#txtBCustBranch').val() + '&Code=' + $('#txtBCustCode').val();        
        //ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
        ShowCustomer(path, dt.BillToCustCode, dt.BillToBranch, '#txtBCustName');
    }
    function ReadContactName(dt) {
        $('#txtContactName').val(dt.ContactName);
        $('#txtContactName').focus();
    }
    function ReadBilling(dt) {
        $('#txtBCustCode').val(dt.CustCode);
        $('#txtBCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtBCustName');        
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
        $('#txtCurrencyRate').focus();
    }
    function ReadVender(dt) {
        $('#txtVenderCode').val(dt.VenCode);
        $('#txtVenderName').val(dt.TName);
        $('#txtVenderCost').focus();
    }
    function ReadManager(dt) {
        $('#txtManagerCode').val(dt.UserID);
        $('#txtManagerName').val(dt.TName);
    }
    function ReadService(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameEng);
        $('#txtDescriptionThai').val(dt.NameEng);
        $('#txtIsvat').val(dt.IsTaxCharge);
        $('#txtIsTax').val(dt.Is50Tavi);
        $('#txtIsService').val(dt.IsCredit == 1 || dt.IsExpense == 1 ? '0': '1');
        $('#txtVatRate').val(dt.IsTaxCharge == 1 ? CDbl(@ViewBag.PROFILE_VATRATE* 100, 0) : 0);
        $('#txtTaxRate').val(dt.Rate50Tavi);
        $('#txtUnitCheck').val(dt.UnitCharge);
        $('#txtCurrencyCode').val(dt.CurrencyCode);
        ShowCurrency(path, dt.CurrencyCode, '#txtCurrencyName');
        $('#txtChargeAmt').val(CDbl(dt.StdPrice,2));
        $('#txtVenderCode').val(dt.DefaultVender);
        ShowVender(path, dt.DefaultVender, '#txtVenderName');
        CalAmount();
    }
    function ShowDiscount() {
        if ($('#txtDiscountType').val() == '1') {
            $('#txtUnitDiscntPerc').val('0');
            $('#txtUnitDiscntAmt').removeAttr('disabled');
            $('#txtUnitDiscntPerc').attr('disabled','disabled');
        } else {
            $('#txtUnitDiscntAmt').attr('disabled', 'disabled');
            $('#txtUnitDiscntPerc').removeAttr('disabled');
        }
    }
    function ShowCommission() {
        if ($('#txtCommissionType').val() == '1') {
            $('#txtCommissionPerc').val('0');
            $('#txtCommissionAmt').removeAttr('disabled');
            $('#txtCommissionPerc').attr('disabled', 'disabled');
        } else {
            $('#txtCommissionAmt').attr('disabled', 'disabled');
            $('#txtCommissionPerc').removeAttr('disabled');
        }
    }
    function CalAmount() {
        let rate = CNum($('#txtCurrencyRate').val());
        let charge = CDbl(($('#txtChargeAmt').val() * rate), 2);
        $('#txtTotalAmt').val(CDbl(charge, 2));
        /*
        if ($('#txtIsService').val() == '0' && CNum($('#txtVenderCost').val())== 0) {
            $('#txtVenderCost').val(CDbl(charge, 2));
        }
        */
        CalDiscount();
    }
    function CalDiscount() {
        let type = $('#txtDiscountType').val();
        let rate = CNum($('#txtUnitDiscntPerc').val());
        let disc = 0;
        if (type == 1) {
            disc = CNum($('#txtUnitDiscntAmt').val());
        } else {
            disc = CDbl((CNum($('#txtChargeAmt').val()) * CNum($('#txtCurrencyRate').val())) * (rate * 0.01), 2);
            $('#txtUnitDiscntAmt').val(CDbl(disc,2));
        }
        $('#txtFUnitDiscntAmt').val(CDbl(disc / CNum($('#txtCurrencyRate').val()),2));
        $('#txtTotalCharge').val(CNum($('#txtTotalAmt').val()) - disc);
        CalVATWHT();
    }
    function GetBasePrice() {
        let type = $('#txtIsvat').val();
        let amt = CNum(CNum($('#txtTotalAmt').val()) - CNum($('#txtUnitDiscntAmt').val()));
        switch (type) {
            case '2': //inc vat
                amt = amt * (100 / (100 + (CNum($('#txtVatRate').val()) - CNum($('#txtTaxRate').val()))));
                break;
        }
        return amt;
    }
    function GetNetPrice() {
        let type = $('#txtIsvat').val();
        let amt = 0;
        if (type == '2') {
            amt = CNum($('#txtTotalCharge').val()) + CNum($('#txtTaxAmt').val()) - CNum($('#txtVatAmt').val());
        } else {
            amt = CNum($('#txtTotalCharge').val()) + CNum($('#txtVatAmt').val()) - CNum($('#txtTaxAmt').val());
        }
        return amt;
    }
    function CalVATWHT() {
        let amt = GetBasePrice();
        let type = $('#txtIsvat').val();
        let vat = 0;
        switch (type) {
            case '0': //novat
                vat = 0;
                break;
            default:
                $('#txtTotalCharge').val(amt);
                vat = amt * (CNum($('#txtVatRate').val()) * 0.01);
                break;
        }
        $('#txtVatAmt').val(CDbl(vat,3));
        let wht = 0;
        type = $('#txtIsTax').val();
        switch (type) {
            case '0': //novat
                break;
            default:
                wht = amt * (CNum($('#txtTaxRate').val()) * 0.01);
                break;
        }
        $('#txtTaxAmt').val(CDbl(wht, 3));
        CalCommission();
    }
    function CalCommission() {
        let type = $('#txtCommissionType').val();
        let rate = CNum($('#txtCommissionPerc').val());
        let comm = CDbl((GetBasePrice()-CNum($('#txtVenderCost').val())) * (rate * 0.01), 2);
        if (type == 1) {
            comm = CNum($('#txtCommissionAmt').val());
        }
        $('#txtCommissionAmt').val(CDbl(comm, 3));
        CalProfit();
    }
    function CalProfit() {
        let comm = CNum($('#txtCommissionAmt').val());
        let cost = CNum($('#txtVenderCost').val());
        let amt = GetBasePrice();
        $('#txtBaseProfit').val(CDbl(amt - cost, 3));
        $('#txtNetProfit').val(CDbl(amt - comm - cost, 3));
    }
    function CopyData() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        if ($('#txtBranchCode').val() == '') {
            ShowMessage('Please input branch',true);
            return;
        }
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            return;
        }
        $('#frmCopy').modal('show');
    }
    function CreateData() {
        $.get(path + 'JobOrder/CopyQuotation?branch=' + $('#txtBranchCode').val() + '&cust=' + $('#txtCustCode').val() + '|'+$('#txtCustBranch').val()+'&code=' + $('#txtBaseQNo').val())
            .done(function (r) {
                ShowMessage(r.result);
                ShowHeader();
            });
    }
    function GetContact() {
        $('#txtContactName').val('');
        let cust = $('#txtBCustCode').val();
        $.get(path + 'Master/GetCompanyContact?code=' + cust)
            .done(function (r) {
                if (r.companycontact.data.length > 0) {
                    ReadContactName(r.companycontact.data[0]);
                }
            });
    }
</script>

