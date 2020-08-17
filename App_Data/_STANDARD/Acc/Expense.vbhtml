
@Code
    ViewBag.Title = "บันทึกบิลค่าใช้จ่าย"
End Code
<div class="panel-body">
    <div id="dvHeader" class="container">
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
            <div class="col-sm-4" style="text-align:left">
                <b id="lblDocNo">Expenses No:</b>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtDocNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('payment')" />
                </div>
            </div>
            <div class="col-sm-3">
                <label id="lblDocDate">Doc Date :</label>
                <br />
                <input type="date" class="form-control" id="txtDocDate" tabindex="1" />
            </div>
        </div>
        <ul class="nav nav-tabs">
            <li class="active"><a id="linkHeader" data-toggle="tab" href="#tabHeader">Header</a></li>
            <li><a id="linkDetail" data-toggle="tab" href="#tabDetail">Detail</a></li>
        </ul>
        <div class="tab-content">
            <div id="tabHeader" class="tab-pane fade in active">
                <div class="row">
                    <div class="col-sm-7" style="display:flex;flex-direction:column">
                        <div style="flex:1">
                            <label id="lblEmpCode">Attn :</label>                            
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtEmpCode" style="width:30%" class="form-control" tabindex="2" />
                                <button id="btnBrowseEmp1" class="btn btn-default" onclick="SearchData('user')">...</button>
                                <input type="text" id="txtEmpName" class="form-control" style="width:100%" disabled />
                            </div>
                        </div>
                        <div style="flex:1">
                            <label id="lblVenCode">Vender:</label>                            
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtVenCode" class="form-control" style="width:30%" tabindex="4" />
                                <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('vender')">...</button>
                                <input type="text" id="txtVenName" class="form-control" style="width:100%" tabindex="5" disabled />
                            </div>
                        </div>
                        <div style="flex:1">
                            <label id="lblContactName">Contact:</label>                            
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtContactName" class="form-control"/>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <div style="display:flex;flex-direction:column">
                            <div style="flex:1">
                                <label id="lblRefNo">Container No:</label>
                                <br/>
                                <input type="text" id="txtRefNo" class="form-control" tabindex="6" />
                            </div>
                            <div style="flex:1">
                                <label id="lblPoNo">Invoice No:</label>
                                <br/>
                                <input type="text" id="txtPoNo" class="form-control" tabindex="7" />
                            </div>
                            <div style="flex:1">
                                <label id="lblForeignAmt">Total Document:</label>                                
                                <br/>
                                <input type="text" id="txtForeignAmt" class="form-control" style="text-align:right" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7">
                        <label id="lblRemark">Remark:</label>                        
                        <textarea id="txtRemark" class="form-control-lg" style="width:100%;height:80px" tabindex="8"></textarea>
                        <br />
                        <label id="lblAdvRef">Advance Reference:</label>
                        <input type="text" id="txtAdvRef" class="form-control" disabled />
                    </div>
                    <div class="col-sm-5">
                        <div style="display:flex">
                            <div>
                                <a id="lblCurrencyCode" onclick="SearchData('currency')">Currency:</a><br/>
                                <input type="text" id="txtCurrencyCode" class="form-control" style="width:150px" value="@ViewBag.PROFILE_CURRENCY" disabled />
                            </div>
                            <div>
                                <label id="lblExchangeRate">Exchange Rate:</label>
                                <br/>
                                <input type="text" id="txtExchangeRate" class="form-control" style="width:100px" value="1" />
                            </div>
                            <div>
                                <br />
                                <button id="btnGetExcRate" class="btn btn-warning" onclick="GetExchangeRate()">Get Rate</button>
                            </div>
                        </div>
                        <div style="display:flex">
                            <div>
                                <label id="lblVATRate">VAT Rate :</label>
                                <br />
                                <input type="text" id="txtVATRate" class="form-control" style="width:100px" />
                            </div>
                            <div>
                                <label id="lblTaxRate">TAX Rate :</label>
                                <br />
                                <input type="text" id="txtTaxRate" class="form-control" style="width:100px" />
                            </div>
                            <div>
                                <label id="lblPayType">Pay Type :</label>
                                <br />
                                <select id="txtPayType" class="form-control dropdown"></select>
                            </div>
                        </div>
                    </div>
                </div>                
                <div class="row">
                    <div class="col-sm-4" style="border-style:solid;border-width:1px">
                        <input type="checkbox" id="chkApprove" />
                        <label id="lblAppr">Approve By</label>
                        <br />
                        <input type="text" id="txtApproveBy" style="width:250px" disabled />
                        <br />
                        <label id="lblApprDate">Date:</label>
                        <input type="date" id="txtApproveDate" disabled />
                        <label id="lblApprTime">Time:</label>
                        <input type="text" id="txtApproveTime" style="width:80px" disabled />
                        <br />
                        <label>Ref#</label> <input type="text" id="txtApproveRef" style="width:250px" disabled />
                    </div>
                    <div class="col-sm-4" style="border-style:solid;border-width:1px">
                        <label id="lblPayment">Payment By</label>
                        <input type="text" id="txtPaymentBy" style="width:250px" disabled />
                        <br />
                        <label id="lblPayDate">Date:</label>                        
                        <input type="date" id="txtPaymentDate" disabled />
                        <label id="lblPayTime">Time:</label>                        
                        <input type="text" id="txtPaymentTime" style="width:80px" disabled />
                        <br />
                        <label id="lblPayRef">Payment Ref:</label><br/>
                        <input type="text" id="txtPaymentRef" style="width:200px" disabled />
                    </div>
                    <div class="col-sm-4" style="border-style:solid;border-width:1px;color:red">
                        <input type="checkbox" id="chkCancel" />
                        <label id="lblCancelProve" for="chkCancel">Cancel By</label>
                        <input type="text" id="txtCancelProve" style="width:250px" disabled />
                        <br />
                        <label id="lblCancelDate">Date:</label>                        
                        <input type="date" id="txtCancelDate" disabled />
                        <label id="lblCancelTime">Time:</label>                        
                        <input type="text" id="txtCancelTime" style="width:80px" disabled />
                        <br />
                        <label id="lblCancelReson">Cancel Reason :</label>
                        <input type="text" id="txtCancelReson" style="width:250px" />
                    </div>
                </div>
                <div id="dvCommand">
                    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddHeader()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkClear">Clear Data</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveHeader()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Data</b>
                    </a>
                </div>
            </div>
            <div id="tabDetail" class="tab-pane fade">
                <div class="row">
                    <div class="col-sm-12">
                        <table id="tbDetail" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>
                                    <th>SICode</th>
                                    <th class="all">Description</th>
                                    <th class="desktop">Qty</th>
                                    <th class="desktop">Price</th>
                                    <th class="desktop">Amount</th>
                                    <th class="desktop">Vat</th>
                                    <th class="desktop">WH-Tax</th>
                                    <th class="all">Net</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-8">
                        <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddDetail()">
                            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Detail</b>
                        </a>
                        <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteDetail()">
                            <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDel">Delete Detail</b>
                        </a>
                    </div>
                    <div class="col-sm-4">
                        <div style="display:flex">
                            <div style="flex:1">
                                <label id="lblTotalExpense">Amount :</label>                                
                            </div>
                            <div style="flex:1">
                                <input type="text" id="txtTotalExpense" class="form-control" style="text-align:right;" /><br />
                            </div>
                        </div>
                        <div style="display:flex">
                            <div style="flex:1">
                                <label id="lblTotalVAT">VAT :</label>                                
                            </div>
                            <div style="flex:1">
                                <input type="text" id="txtTotalVAT" class="form-control" style="text-align:right;" /><br />
                            </div>
                        </div>
                        <div style="display:flex">
                            <div style="flex:1">
                                <label id="lblTotalTax">WHT :</label>                                
                            </div>
                            <div style="flex:1">
                                <input type="text" id="txtTotalTax" class="form-control" style="text-align:right;" /><br />
                            </div>
                        </div>
                        <div style="display:flex">
                            <div style="flex:1">
                                <label id="lblTotalDiscount">Discount :</label>                                
                            </div>
                            <div style="flex:1">
                                <input type="text" id="txtTotalDiscount" class="form-control" style="text-align:right;" /><br />
                            </div>
                        </div>
                        <div style="display:flex">
                            <div style="flex:1">
                                <label id="lblTotalNet">Total </label>                                
                            </div>
                            <div style="flex:1">
                                <input type="text" id="txtTotalNet" class="form-control" style="text-align:right;" />
                            </div>                            
                        </div>
                    </div>
                </div>

            </div>
            <div id="frmDetail" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"></button>
                            <h4 class="modal-title"><label id="lblDetail">Detail</label></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label id="lblItemNo" for="txtItemNo">No :</label><br/>
                                    <input type="text" id="txtItemNo" class="form-control" disabled />
                                </div>
                                <div class="col-sm-10">
                                    <br />
                                    <input type="checkbox" id="chkCopy" /><label id="lblCopy">Use Copy Mode</label> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label id="lblJobNo">Job No :</label>                                    
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtForJNo" class="form-control" />
                                        <input type="button" class="btn btn-default" onclick="SearchData('job')" value="..." />
                                    </div>                                    
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblCustCode">For :</label>                                    
                                    <br/>
                                    <input type="text" id="txtCustCode" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblBookingNo">Booking No :</label>                                    
                                    <br/>
                                    <input type="text" id="txtBookingRefNo" class="form-control" disabled />
                                </div>
                                <div class="col-sm-2">
                                    #<br/>
                                    <input type="text" id="txtBookingItemNo" class="form-control" disabled />
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblContNo">Container No :</label>                                    
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtContainerNo" class="form-control" disabled />
                                        <button class="btn btn-default" id="btnSelPrice" onclick="SearchData('transportprice')">Select Price</button>
                                    </div>                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblSICode" for="txtSICode">Code :</label>
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtSICode" class="form-control" tabindex="12" />
                                        <input type="button" id="btnBrowseS" class="btn btn-default" value="..." onclick="SearchData('service')" />
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <label id="lblDescription">Description :</label>
                                    <br/>
                                    <input type="text" class="form-control" id="txtSDescription" tabindex="13" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblQty" for="txtQty">Qty:</label><br/>
                                    <input type="text" id="txtQty" class="form-control" tabindex="14" />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblQtyUnit">Unit :</label>
                                    <br/>
                                    <input type="text" id="txtQtyUnit" class="form-control" tabindex="15" />

                                </div>
                                <div class="col-sm-4">
                                    <label id="lblUnitPrice" for="txtUnitPrice">Price :</label><br/>
                                    <input type="text" id="txtUnitPrice" class="form-control" tabindex="16" />
                                </div>
                            </div>                            
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblAmt" for="txtAmt">Amount :</label>
                                    <br/>
                                    <input type="text" id="txtAmt" class="form-control" tabindex="17" />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblDiscountPerc">Discount(%)</label>
                                    <br/>
                                    <input type="text" class="form-control" id="txtDiscountPerc" onchange="CalDiscount()" tabindex="18" />
                                </div>
                                <div class="col-sm-4">
                                    <br/><input type="text" id="txtAmtDisc" class="form-control" tabindex="19" onchange="CalTotal()" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <input type="checkbox" id="txtIsTaxCharge" onclick="CalVATWHT()"><label id="lblIsTaxCharge"> VAT :</label><br />
                                    <input type="text" id="txtAmtVAT" class="form-control" tabindex="20" />
                                </div>
                                <div class="col-sm-4">
                                    <input type="checkbox" id="txtIs50Tavi" onclick="CalVATWHT()"><label id="lblIs50Tavi">WH-Tax :</label><br/>
                                    <input type="text" id="txtAmtWHT" class="form-control" tabindex="21" />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblNETAmount" for="txtTotal">Net :</label><br/>
                                    <input type="text" id="txtTotal" class="form-control" tabindex="22" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-8">
                                    <label id="lblSRemark">Remark :</label>
                                    <br/><input type="text" id="txtSRemark" class="form-control" tabindex="23" />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblFTotal">Total(F) :</label>
                                    <br/>
                                    <input type="text" id="txtFTotal" class="form-control" disabled />
                                </div>
                            </div>                            
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblClearingNo">Clearing No :</label>
                                    <br/>
                                    <input type="text" class="form-control" id="txtClrRefNo" disabled />
                                </div>
                                <div class="col-sm-2">
                                    #<br/> <input type="text" class="form-control" id="txtClrItemNo" disabled />
                                </div>
                                <div class="col-sm-3">
                                    Route ID<br/>
                                    <input type="text" class="form-control" id="txtRouteID" />
                                </div>
                            </div>                                                       
                            <input type="hidden" id="txtAdvItemNo" />
                        </div>
                        <div class="modal-footer">
                            <div style="float:left">
                                <a href="#" class="btn btn-default w3-purple" id="btnAddDet" onclick="AddDetail()">
                                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">New</b>
                                </a>
                                <a href="#" class="btn btn-success" id="btnUpdate" onclick="SaveDetail()">
                                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkUpdate">Save</b>
                                </a>
                            </div>
                            <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                        </div>
                    </div>
                </div>
            </div>
            <div id="frmHeader" class="modal modal-lg fade">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"></button>
                            <h4 class="modal-title"><label id="lblPayHeader">Billing Payment</label></h4>
                        </div>
                        <div class="modal-body">
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
                        <div class="modal-footer">
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
    const userGroup = '@ViewBag.UserGroup';
    const userRights = '@ViewBag.UserRights';
    let serv = []; //must be array of object
    let hdr = {}; //simple object
    let dtl = {}; //simple object
    let isjobmode = false;
    let chkmode = false;

    let bookno = getQueryString("BookNo");
    let item = getQueryString("Item");
    let job = getQueryString("Job");
    let vend = getQueryString("Vend");
    let cont = getQueryString("Cont");
    let cust = getQueryString("Cust");
    let route = getQueryString("Route");
        //$(document).ready(function () {
    if (userGroup == 'V') {
        $('#btnBrowseCust').attr('disabled', 'disabled');
        $('#txtVenCode').attr('disabled', 'disabled');
        $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
            if (r.vender.data.length > 0) {
                let dr = r.vender.data[0];
                vend = dr.VenCode;
                $('#txtVenCode').val(vend);
                $('#txtVenName').val(dr.TName);
            }
        });
    }

    SetLOVs();
    SetEvents();
    SetEnterToTab();
    CheckParam();
    //});
    function CheckParam() {
        ClearHeader();
        //read query string parameters
        let br = getQueryString('BranchCode');
        if (br.length>0) {
            $('#txtBranchCode').val(br);
            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            let ano = getQueryString('DocNo');
            if (ano.length > 0) {
                $('#txtDocNo').val(ano);
                ShowData(br, $('#txtDocNo').val());
            } 
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
        if ((br + bookno + item).trim() !== '') {
            isjobmode = true;
            $('#txtBookingRefNo').val(bookno);
            $('#txtBookingItemNo').val(item);
            if (cust == '') {
                CallBackQueryJob(path, br, job, ReadJob);
            } else {
                $('#txtCustCode').val(cust);
            }
            $('#txtVenCode').val(vend);
            $('#txtContainerNo').val(cont);
            $('#txtRefNo').val(cont);
            ShowVender(path, $('#txtVenCode').val(), '#txtVenName');
        } else {
            item = 0;
        }
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
                    $('[tabindex="0"]').focus();
                }
            });
        });
    }
    function SetEvents() {

        $('#frmDetail').on('shown.bs.modal', function () {
            $('#txtSICode').focus();
        });
        $('#chkCancel').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ACC', 'Expense', 'D', SetCancel);
        });
        $('#chkApprove').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ADV', 'Approve',(chkmode ? 'I':'D'), SetApprove);
        });
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtDocNo').focusout(function (event) {
            if (true) {
                ShowData($('#txtBranchCode').val(),$('#txtDocNo').val());
            }
        });
        $('#txtEmpCode').change(function (event) {
            if (true) {
                ShowUser(path, $('#txtEmpCode').val(), '#txtEmpName');
            }
        });
        $('#txtVenCode').change(function (event) {
            if (true) {
                ShowVender(path, $('#txtVenCode').val(), '#txtVenName');
            }
        });
        $('#txtSICode').change(function (event) {
            if (true) {
                let dt = FindService($('#txtSICode').val())
                ReadService(dt);
            }
        });
        $('#txtQty').change(function (event) {
            if (true) {
                CalAmount();
            }
        });
        $('#txtUnitPrice').change(function (event) {
            if (true) {
                CalAmount();
            }
        });
        $('#txtAmt').change(function (event) {
            if (true) {
                CalVATWHT();
            }
        });
        $('#txtAmtVAT').change(function (event) {
            if (true) {
                CalTotal();
            }
        });
        $('#txtAmtWHT').change(function (event) {
            if (true) {
                CalTotal();
            }
        });
        $('#txtTotal').change(function (event) {
            if (true) {
                let type = $('#txtIsTaxCharge').val();
                if (type == '0'||type=='') type = "1";
                if (type == "2") {
                    CalVATWHT();
                } else {
                    CalTotal();
                }
            }
        });
        EnableSave();
    }
    function SetApprove(b) {
        if ($('#txtPaymentBy').val() == '' && $('#txtCancelProve').val() == '') {
            if (b == true) {
                $('#txtApproveBy').val(chkmode ? user : '');
                $('#txtApproveDate').val(chkmode ? GetToday() : '');
                $('#txtApproveTime').val(chkmode ? ShowTime(GetTime()) : '');
                SaveHeader();
                EnableSave();
            } else {
                ShowMessage('Cannot approve',true);
            }
        } else {
            ShowMessage('This document is locked',true);
        }
    }
    function SetCancel(b) {
        if (b == true) {
            ShowConfirm('Please confirm this operation', function (result) {
                if (result == true) {
                    $('#txtCancelProve').val(chkmode ? user : '');
                    $('#txtCancelDate').val(chkmode ? CDateEN(GetToday()) : '');
                    $('#txtCancelTime').val(chkmode ? ShowTime(GetTime()) : '');
                    return;
                }
                $('#chkCancel').prop('checked', !chkmode);
            });
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkCancel').prop('checked', !chkmode);
    }
    function SetLOVs() {
        //Combos
        let lists = 'PAYMENT_TYPE=#txtPayType|CA';
        loadCombos(path, lists);

        LoadService();

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Venders
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response,2);
            //Users
            CreateLOV(dv, '#frmSearchEmp', '#tbEmp', 'Entry By', response,2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,2);
            //SICode
            CreateLOV(dv, '#frmSearchSICode', '#tbServ', 'Service Code', response,2);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency Code', response, 2);
            //Jobs
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Jobs', response, 4);
            CreateLOV(dv, '#frmSearchPrice', '#tbPrice', 'Price Lists', response, 4);
        });
    }
    function ShowData(branchcode, docno) {
        if (userRights.indexOf('R') < 0) {
            ShowMessage('You are not allow to do this',true);
            return;
        }
        $.get(path + 'acc/getpayment?branch='+branchcode+'&code='+ docno, function (r) {
            let h = r.payment.header[0];
            ReadPaymentHeader(h);
            let d = r.payment.detail;
            ReadPaymentDetail(d);
        });
    }
    function SaveHeader() {
        let obj = GetDataHeader();
        if (obj.DocNo == '') {
            if (userRights.indexOf('I') < 0) {
                ShowMessage('You are not allow to add',true);
                return;
            }
        }
        if (userRights.indexOf('E') < 0) {
            ShowMessage('You are not allow to save',true);
            return;
        }
        let jsonString = JSON.stringify({ data: obj });
        $.ajax({
            url: "@Url.Action("SetPayHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                ShowMessage(response.result.msg);
                if (response.result.data !== '') {
                    $('#txtDocNo').val(response.result.data);
                    ShowData($('#txtBranchCode').val(), $('#txtDocNo').val());
                }
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function GetDataHeader() {
        let dt = {
            BranchCode:$('#txtBranchCode').val(),
            DocNo:$('#txtDocNo').val(),
            DocDate:CDateEN($('#txtDocDate').val()),
            VenCode:$('#txtVenCode').val(),
            ContactName:$('#txtContactName').val(),
            EmpCode:$('#txtEmpCode').val(),
            PoNo:$('#txtPoNo').val(),
            VATRate:CNum($('#txtVATRate').val()),
            TaxRate:CNum($('#txtTaxRate').val()),
            TotalExpense:CNum($('#txtTotalExpense').val()),
            TotalTax:CNum($('#txtTotalTax').val()),
            TotalVAT:CNum($('#txtTotalVAT').val()),
            TotalDiscount:CNum($('#txtTotalDiscount').val()),
            TotalNet:CNum($('#txtTotalNet').val()),
            Remark:$('#txtRemark').val(),
            CancelReson:$('#txtCancelReson').val(),
            CancelProve:$('#txtCancelProve').val(),
            CancelDate:CDateEN($('#txtCancelDate').val()),
            CancelTime:CDateEN($('#txtCancelTime').val()),
            CurrencyCode:$('#txtCurrencyCode').val(),
            ExchangeRate:CNum($('#txtExchangeRate').val()),
            ForeignAmt:CNum($('#txtForeignAmt').val()),
            RefNo: $('#txtRefNo').val(),
            PayType: $('#txtPayType').val(),
            PaymentBy: $('#txtPaymentBy').val(),
            PaymentDate : CDateEN($('#txtPaymentDate').val()),
            PaymentTime : $('#txtPaymentTime').val(),
            PaymentRef : $('#txtPaymentRef').val(),
            ApproveBy : $('#txtApproveBy').val(),
            ApproveDate : CDateEN($('#txtApproveDate').val()),
            ApproveTime : $('#txtApproveTime').val(),
            AdvRef: $('#txtAdvRef').val(),
            ApproveRef: $('#txtApproveRef').val()
        };
        return dt;
    }
    function ReadPaymentHeader(dt) {
        if (dt != undefined) {
            hdr = dt;
            $('#txtDocNo').val(dt.DocNo);
            $('#txtDocDate').val(CDateEN(dt.DocDate));
            $('#txtVenCode').val(dt.VenCode);
            ShowVender(path, dt.VenCode, '#txtVenName');
            $('#txtContactName').val(dt.ContactName);
            $('#txtEmpCode').val(dt.EmpCode);
            ShowUser(path, dt.EmpCode, '#txtEmpName');
            $('#txtPoNo').val(dt.PoNo);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            $('#txtExchangeRate').val(dt.ExchangeRate);
            $('#txtVATRate').val(dt.VATRate);
            $('#txtTaxRate').val(dt.TaxRate);
            $('#txtTotalExpense').val(dt.TotalExpense);
            $('#txtTotalVAT').val(dt.TotalVAT);
            $('#txtTotalTax').val(dt.TotalTax);
            $('#txtTotalDiscount').val(dt.TotalDiscount);
            $('#txtTotalNet').val(dt.TotalNet);
            $('#txtForeignAmt').val(dt.ForeignAmt);
            $('#txtRemark').val(dt.Remark);
            $('#txtPaymentBy').val(dt.PaymentBy);
            $('#txtPaymentDate').val(CDateEN(dt.PaymentDate));
            $('#txtPaymentTime').val(ShowTime(dt.PaymentTime));
            $('#txtPaymentRef').val(dt.PaymentRef);
            $('#txtApproveBy').val(dt.ApproveBy);
            $('#txtApproveRef').val(dt.ApproveRef);
            $('#txtApproveDate').val(CDateEN(dt.ApproveDate));
            $('#txtApproveTime').val(ShowTime(dt.ApproveTime));
            $('#txtCancelReson').val(dt.CancelReson);
            $('#txtCancelProve').val(dt.CancelProve);
            $('#txtCancelDate').val(CDateEN(dt.CancelDate));
            $('#txtCancelTime').val(ShowTime(dt.CancelTime));
            $('#txtAdvRef').val(dt.AdvRef);
            $('#txtRefNo').val(dt.RefNo);
            $('#txtPayType').val(dt.PayType);
            $('#chkApprove').prop('checked', $('#txtApproveBy').val() == '' ? false : true);
            $('#chkCancel').prop('checked', $('#txtCancelProve').val() == '' ? false : true);
            EnableSave();
            return;
        }
        ClearHeader();
    }
    function AddHeader() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        $('#txtDocNo').val('');
        ClearHeader();
    }
    function AddDetail() {
        if ($('#txtDocNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        ClearDetail();
        $('#frmDetail').modal('show');
    }
    function DeleteDetail() {
        if (dtl.ItemNo != undefined) {
            if (userRights.indexOf('D') < 0) {
                ShowMessage('You are not allow to delete',true);
                return;
            }
            if (dtl.ClrItemNo > 0 || dtl.AdvItemNo>0) {
                ShowMessage('Cannot delete',true);
                return;
            }
            ShowConfirm('Please confirm to delete', function (result) {
                if (result == true) {
                    $.get(path + 'acc/delpaydetail?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtDocNo').val() + '&item=' + dtl.ItemNo, function (r) {
                        ShowMessage(r.payment.result);
                        ShowData($('#txtBranchCode').val(), $('#txtDocNo').val());
                    });
                }
            });
        } else {
            ShowMessage('No data to delete',true);
        }
    }
    function ClearHeader() {
        hdr = {};
        //$('#txtDocNo').val('');
        $('#txtDocDate').val( CDateEN(GetToday()));
        $('#txtVenCode').val(vend);
        if (userGroup !== 'V') {
            $('#txtVenName').val('');
            $('#txtEmpCode').val(user);
            ShowUser(path, user, '#txtEmpName');
        } else {
            $('#txtEmpCode').val('');
            $('#txtEmpName').val('');   
        }
        $('#txtContactName').val('');
        $('#txtPoNo').val('');
        $('#txtCurrencyCode').val('@ViewBag.PROFILE_CURRENCY');
        $('#txtExchangeRate').val('1');
        $('#txtVATRate').val(CDbl(CNum('@ViewBag.PROFILE_VATRATE')*100,0));
        $('#txtTaxRate').val('0');
        $('#txtTotalExpense').val('0');
        $('#txtTotalVAT').val('0');
        $('#txtTotalTax').val('0');
        $('#txtTotalDiscount').val('0');
        $('#txtTotalNet').val('0');
        $('#txtForeignAmt').val('0');
        $('#txtRemark').val('');
        $('#txtAdvRef').val('');
        $('#txtPaymentBy').val('');
        $('#txtPaymentDate').val('');
        $('#txtPaymentTime').val('');
        $('#txtPaymentRef').val('');
        $('#txtApproveBy').val('');
        $('#txtApproveRef').val('');
        $('#txtApproveDate').val('');
        $('#txtApproveTime').val('');
        $('#txtCancelReson').val('');
        $('#txtCancelProve').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelTime').val('');
        if (isjobmode == false) {
            $('#txtRefNo').val('');
        } else {
            $('#txtRefNo').val(cont);
        }
        $('#txtPayType').val('CA');
        $('#chkApprove').prop('checked', false);
        $('#chkCancel').prop('checked', false);
        $('#tbDetail').DataTable().clear().draw();
        EnableSave();
    }
    function SaveDetail() {

        if (hdr == undefined||hdr.DocNo == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        let obj = GetDataDetail();
        if (obj.ItemNo == 0) {
            if (userRights.indexOf('I') < 0) {
                ShowMessage('You are not allow to add',true);
                return;
            }
        }
        if (userRights.indexOf('E') < 0) {
            ShowMessage('You are not allow to edit',true);
            return;
        }
        if (obj.ClrItemNo > 0 || obj.AdvItemNo>0) {
            ShowMessage('Cannot Edit',true);
            return;
        }

        let jsonString = JSON.stringify({ data: obj });
        //ShowMessage(jsonString);
        $.ajax({
            url: "@Url.Action("SetPayDetail", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                ShowMessage(response.result.msg);
                ShowData($('#txtBranchCode').val(), $('#txtDocNo').val());
            }
        });
    }
    function ReadPaymentDetail(dt) {
        let tb=$('#tbDetail').DataTable({
            data:dt,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: null, title: "Edit" },
                { data: "SICode", title: "Exp" },
                { data: "SDescription", title: "Description" },
                { data: "ForJNo", title: "Job" },
                { data: "SRemark", title: "Remark" },
                { data: "Amt", title: "Amount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "AmtVAT", title: "Vat",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "AmtWHT", title: "WH-Tax",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                },
                { data: "Total", title: "Net",
                            render: function (data) {
                                return ShowNumber(data, 2);
                    }
                }
            ],
            "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                {
                    "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                    "data": null,
                    "render": function (data, type, full, meta) {
                        let html = "<button class='btn btn-warning'>Edit</button>";
                        return html;
                    }
                }
            ],
            responsive:true,
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail tbody').on('click', 'tr', function () {
            $('#tbDetail tbody > tr').removeClass('selected');
            $(this).addClass('selected');
            let data = $('#tbDetail').DataTable().row(this).data(); //read current row selected
            LoadDetail(data); //callback function from caller
        });
        $('#tbDetail tbody').on('click', 'button', function () {
            $('#frmDetail').modal('show');
            $('#txtSICode').focus();
        });
    }
    function GetDataDetail() {
        let dt = {
            BranchCode: $('#txtBranchCode').val(),
            DocNo: $('#txtDocNo').val(),
            ItemNo: $('#txtItemNo').val(),
            SICode: $('#txtSICode').val(),
            SDescription: $('#txtSDescription').val(),
            SRemark: $('#txtSRemark').val(),
            Qty: $('#txtQty').val(),
            QtyUnit: $('#txtQtyUnit').val(),
            UnitPrice: $('#txtUnitPrice').val(),
            IsTaxCharge: ($('#txtIsTaxCharge').prop('checked') == true ? '1' : '0'),
            Is50Tavi: ($('#txtIs50Tavi').prop('checked') == true ? '1' : '0'),
            DiscountPerc: $('#txtDiscountPerc').val(),
            Amt: $('#txtAmt').val(),
            AmtDisc: $('#txtAmtDisc').val(),
            AmtVAT: $('#txtAmtVAT').val(),
            AmtWHT: $('#txtAmtWHT').val(),
            Total: $('#txtTotal').val(),
            FTotal: $('#txtFTotal').val(),
            ForJNo: $('#txtForJNo').val(),
            ClrRefNo: $('#txtClrRefNo').val(),
            ClrItemNo: $('#txtClrItemNo').val(),
            BookingRefNo: $('#txtBookingRefNo').val(),
            BookingItemNo: $('#txtBookingItemNo').val(),
            AdvItemNo: $('#txtAdvItemNo').val()
        };
        return dt;
    }
    function LoadDetail(dt) {
        if (dt != undefined) {
            ClearDetail();
            dtl = dt;
            $('#txtRouteID').val(route);
            $('#txtItemNo').val(dt.ItemNo);
            $('#txtSICode').val(dt.SICode);
            $('#txtSDescription').val(dt.SDescription);
            $('#txtSRemark').val(dt.SRemark);
            $('#txtQty').val(dt.Qty);
            $('#txtQtyUnit').val(dt.QtyUnit);
            $('#txtUnitPrice').val(dt.UnitPrice);
            $('#txtIsTaxCharge').prop('checked', (dt.IsTaxCharge == 1 ? true : false));
            $('#txtIs50Tavi').prop('checked', (dt.Is50Tavi == 1 ? true : false));
            $('#txtDiscountPerc').val(dt.DiscountPerc);
            $('#txtAmt').val(dt.Amt);
            $('#txtAmtDisc').val(dt.AmtDisc);
            $('#txtAmtVAT').val(dt.AmtVAT);
            $('#txtAmtWHT').val(dt.AmtWHT);
            $('#txtTotal').val(dt.Total);
            $('#txtFTotal').val(dt.FTotal);
            $('#txtForJNo').val(dt.ForJNo);
            $('#txtBookingRefNo').val(dt.BookingRefNo);
            $('#txtBookingItemNo').val(dt.BookingItemNo);
            $('#txtClrRefNo').val(dt.ClrRefNo);
            $('#txtClrItemNo').val(dt.ClrItemNo);
            $('#txtAdvItemNo').val(dt.AdvItemNo);
            if (dr.ClrItemNo > 0 || dr.AdvItemNo > 0) {
                $('#btnUpdate').attr('disabled', 'disabled');
            }
            return;
        }
        ClearDetail();
    }
    function ClearDetail() {
        dtl = {};
        $('#txtItemNo').val(0);
        if ($('#chkCopy').prop('checked') == false) {
            $('#txtSICode').val('');
            $('#txtSDescription').val('');
            $('#txtSRemark').val('');
            $('#txtQty').val('1');
            $('#txtQtyUnit').val('');
            $('#txtUnitPrice').val('');
            $('#txtIsTaxCharge').prop('checked', false);
            $('#txtIs50Tavi').prop('checked', false);
            $('#txtDiscountPerc').val('0');
            $('#txtAmt').val('0');
            $('#txtAmtDisc').val('0');
            $('#txtAmtVAT').val('0');
            $('#txtAmtWHT').val('0');
            $('#txtTotal').val('0');
            $('#txtFTotal').val('0');
            $('#txtForJNo').val(job);
            $('#txtBookingRefNo').val(bookno);
            $('#txtContainerNo').val(cont);
            $('#txtBookingItemNo').val(item);

            $('#txtSICode').removeAttr('disabled');
            $('#txtSDescription').removeAttr('disabled');
            $('#txtUnitPrice').removeAttr('disabled');
            $('#txtSRemark').removeAttr('disabled');
        }
        $('#txtAdvItemNo').val(0);
        $('#txtClrRefNo').val('');
        $('#txtClrItemNo').val(0);
        //EnableSave();
    }
    function LoadService() {
        if (serv.length==0) {
            $.get(path + 'master/getservicecode')
                .done(function (r) {
                    if (r.servicecode.data.length > 0) {
                        serv = r.servicecode.data;
                    }
                });
        }
    }
    function FindService(Code) {
        let c = $.grep(serv, function (data) {
            return data.SICode === Code;
        });
        return c[0];
    }
    function SetGridAdv() {
        let w = '&branch=' + $('#txtBranchCode').val();
        if ($('#txtEmpCode').val() !== '') {
            w += '&empcode=' + $('#txtEmpCode').val();
        }
        if (userGroup == 'V') {
            w += '&VenCode=' + $('#txtVenCode').val();
        } else {
            if ($('#txtVenCode').val() !== '') {
                w += '&vencode=' + $('#txtVenCode').val();
            }
        }
        $.get(path + 'acc/getpayment?status=Y' +  w, function (r) {
            if (r.payment.header.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.payment.header;
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
                    { data: "TotalExpense", title: "Amount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalVAT", title: "VAT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalTax", title: "Tax",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalNet", title: "Net",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                $('#tbHeader tbody > tr').removeClass('selected');
                $(this).addClass('selected');
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                ShowData(data.BranchCode, data.DocNo); //callback function from caller
                $('#frmHeader').modal('hide');
            });
            $('#frmHeader').on('shown.bs.modal', function () {
                $('#tbHeader_filter input').focus();
            });
            $('#frmHeader').modal('show');
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'payment':
                SetGridAdv();
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'user':
                SetGridUser(path, '#tbEmp', '#frmSearchEmp', ReadUser);
                break;
            case 'service':
                SetGridSICodeFilter(path, '#tbServ', '?Type=E', '#frmSearchSICode', ReadService);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'job':
                if (userGroup == 'V') {
                    SetGridTransport(path, '#tbJob', '#frmSearchJob', '?Cont='+ $('#txtRefNo').val() +'&Vend=' + $('#txtVenCode').val(), ReadTransport);
                } else {
                    SetGridJob(path, '#tbJob', '#frmSearchJob', '?Vend=' + $('#txtVenCode').val(), ReadJob);
                }
                break;
            case 'transportprice':
                if (route !== '') {
                    SetGridTransportPrice(path, '#tbPrice', '#frmSearchPrice', '?Branch=' + $('#txtBranchCode').val() + '&Vend=' + $('#txtVenCode').val() + '&Cust=' + $('#txtCustCode').val() + '&id=' + route, ReadPrice);
                } else {
                    SetGridTransportPrice(path, '#tbPrice', '#frmSearchPrice', '?Branch=' + $('#txtBranchCode').val() + '&Vend=' + $('#txtVenCode').val() + '&Cust=' + $('#txtCustCode').val(), ReadPrice);
                }
                break;
        }
    }
    function GetParam() {
        let strParam = '?';
        strParam += 'Branch=' + $('#txtBranchCode').val();
        strParam += '&VenCode=' + $('#txtVenCode').val();
        return strParam;
    }
    function ReadTransport(dt) {
        route = dt.LocationID;
        $('#txtRouteID').val(dt.LocationID);
        $('#txtBookingRefNo').val(dt.BookingNo);
        $('#txtBookingItemNo').val(dt.ItemNo);
        $('#txtContainerNo').val(dt.CTN_NO);
        $('#txtForJNo').val(dt.JNo);
        $('#txtCustCode').val(dt.NotifyCode);
    }
    function ReadJob(dt) {
        $('#txtForJNo').val(dt.JNo);
        $('#txtCustCode').val(dt.CustCode);
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        $('#txtVenName').val(dt.TName);
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtExchangeRate').focus();
    }
    function ReadUser(dt) {
        $('#txtEmpCode').val(dt.UserID);
        $('#txtEmpName').val(dt.TName);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadService(dt) {
        if (dt != undefined) {
            $('#txtSICode').val(dt.SICode);
            $('#txtSDescription').val(dt.NameThai);
            $('#txtQtyUnit').val(dt.UnitCharge);
            $('#txtUnitPrice').val(CDbl(CNum(dt.StdPrice) / CNum($('#txtExchangeRate').val()), 2));
            if (dt.IsTaxCharge == 1) {
                $('#txtIsTaxCharge').prop('checked', true);
            }
            if (dt.Is50Tavi == 1) {
                $('#txtTaxRate').val(dt.Rate50Tavi);
                $('#txtIs50Tavi').prop('checked', true);
            }
            CalAmount();    
            return;
        }
        CalAmount();
    }
    function ReadPrice(dt) {
        if (dt !== undefined) {
            $('#txtSICode').val(dt.SICode);
            $('#txtSICode').change();
            $('#txtSDescription').val(dt.SDescription);
            $('#txtSRemark').val(dt.Location);
            $('#txtUnitPrice').val(CDbl(CNum(dt.CostAmount) / CNum($('#txtExchangeRate').val()), 2));

            $('#txtSICode').attr('disabled', 'disabled');
            $('#txtSDescription').attr('disabled', 'disabled');
            $('#txtUnitPrice').attr('disabled', 'disabled');
            $('#txtSRemark').attr('disabled', 'disabled');

            CalAmount();    
        }
    }
    function CalDiscount() {
        let rate = CNum($('#txtDiscountPerc').val());
        let disc = 0;
        if (rate == 0) {
            disc = CNum($('#txtAmtDisc').val());
        } else {
            disc = CDbl(CNum($('#txtTotal').val()) * (rate * 0.01), 2);
            $('#txtAmtDisc').val(disc);
        }
        CalTotal();
    }
    function CalAmount() {
        let price = CDbl($('#txtUnitPrice').val(), 4);
        let qty = CDbl($('#txtQty').val(),4);
        let rate = CDbl($('#txtExchangeRate').val(),4); //rate ของ detail
        if (qty > 0) {
            let amt = CNum(qty) * CNum(price);
            $('#txtAmt').val(CDbl(CNum(amt) * CNum(rate), 4));
            CalVATWHT();
        } else {
            $('#txtUnitPrice').val(0);
            $('#txtAmt').val(0);
            $('#txtAmtDisc').val(0);
            $('#txtTotal').val(0);
            $('#txtFTotal').val(0);
            $('#txtAmtVAT').val(0);
            $('#txtAmtWHT').val(0);
        }
    }
    function CalTotal() {
        let amt = CDbl($('#txtAmt').val(), 4);
        let disc = CDbl($('#txtAmtDisc').val(), 4);
        let vat = CDbl($('#txtAmtVAT').val(),4);
        let wht = CDbl($('#txtAmtWHT').val(),4);
        $('#txtTotal').val(CDbl(CNum(amt) + CNum(vat) - CNum(wht) - CNum(disc), 4));
        let rate = CDbl($('#txtExchangeRate').val(), 4);
        let net = CDbl($('#txtTotal').val(), 4);
        $('#txtFTotal').val(CDbl((net / rate), 4));
    }
    function CalVATWHT() {
        let vattype = $('#txtIsTaxCharge').prop('checked') == true ? '1' : '0';
        let whttype = $('#txtIs50Tavi').prop('checked') == true ? '1' : '0';
        let amt = CDbl($('#txtAmt').val(),4);
        let vatrate = CDbl($('#txtVATRate').val(),4);
        let whtrate = CDbl($('#txtTaxRate').val(), 4);
        let vat = 0;
        let wht = 0;
        if (vattype == '1') {
            vat = amt * vatrate * 0.01;
        }
        if (whttype == '1') {
            wht = amt * whtrate * 0.01;
        }
        $('#txtAmtVAT').val(CDbl(vat,4));
        $('#txtAmtWHT').val(CDbl(wht,4));
        CalTotal();
    }
    function GetExchangeRate() {
        $.get('https://free.currencyconverterapi.com/api/v6/convert?q=' + $('#txtCurrencyCode').val() + '_THB&compact=ultra&apiKey=6210d55b79170a4a7da2', function (r) {
            let rate = CDbl(r[$('#txtCurrencyCode').val() + '_THB'], 4);
            $('#txtExchangeRate').val(rate);
        });
    }
    function EnableSave() {
        let b = (userRights.indexOf('E') > 0 && ($('#txtApproveBy').val()=='' && $('#txtCancelProve').val()=='' && $('#txtAdvRef').val()=='' && $('#txtPaymentRef').val()==''))
        if (b == false) {
            $('#btnSave').attr('disabled', 'disabled');
            $('#btnDel').attr('disabled', 'disabled');
            $('#btnUpdate').attr('disabled', 'disabled');
        } else {
            $('#btnSave').removeAttr('disabled');
            $('#btnDel').removeAttr('disabled');
            $('#btnUpdate').removeAttr('disabled');
        }
        if (userRights.indexOf('I') < 0) $('#btnNew').attr('disabled', 'disabled');
        if (userRights.indexOf('I') < 0) $('#btnAdd').attr('disabled', 'disabled');
        if (userRights.indexOf('E') < 0) $('#btnSave').attr('disabled', 'disabled');
        if (userRights.indexOf('E') < 0) $('#btnUpdate').attr('disabled', 'disabled');
        if (userRights.indexOf('D') < 0) $('#btnDel').attr('disabled', 'disabled');
        if (userRights.indexOf('P') < 0) $('#btnPrint').attr('disabled', 'disabled');
    }
</script>