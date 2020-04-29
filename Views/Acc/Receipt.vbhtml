@Code
    ViewBag.Title = "Receipt"
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
                <label id="lblDocDateF">Receipt Date From:</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateF" />
            </div>
            <div class="col-sm-2">
                <label id="lblDocDateT">Receipt Date To:</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateT" />
            </div>
            <div class="col-sm-3">
                <br />
                <a href="#" class="btn btn-primary" id="btnShow">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="lblSearch">Search</b>
                </a>
                <a href="#" class="btn btn-default w3-purple" id="btnGen" onclick="CreateReceipt()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="lblCreate">Create Receipt</b>
                </a>
            </div>
        </div>
        <ul class="nav nav-tabs">
            <li class="active">
                <a id="linkHeader" data-toggle="tab" href="#tabHeader">Headers</a>
            </li>
            <li>
                <a id="linkDetail" data-toggle="tab" href="#tabDetail">Details</a>
            </li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade in active" id="tabHeader">
                <input type="checkbox" id="chkCancel" /><label id="lblCancel">Show Cancel Only</label>
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th class="all">DocNo</th>
                            <th class="desktop">DocDate</th>
                            <th class="desktop">CustCode</th>
                            <th class="desktop">Reference</th>
                            <th class="desktop">Remark</th>
                            <th class="all">Advance</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="tab-pane fade" id="tabDetail">
                <label id="lblDocNoDet">Details of Receipt No:</label>
                <input type="text" id="txtDocNo" class="form-control" disabled />
                <table id="tbDetail" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th class="all">InvNo</th>
                            <th class="desktop">SICode</th>
                            <th class="desktop">SDescription</th>
                            <th class="desktop">Cash</th>
                            <th class="desktop">Transfer</th>
                            <th class="desktop">Cheque</th>
                            <th class="desktop">Credit</th>
                            <th class="desktop">Amt</th>
                            <th class="desktop">VAT</th>
                            <th class="desktop">W-Tax</th>
                            <th class="all">Net</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="lblPrint">Print</b>
        </a>
        <div id="frmHeader" class="modal fade">
            <div class="modal-dialog-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblReceiptNo">Receipt No:</label>
                                <br/><input type="text" id="txtReceiptNo" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblReceiptDate">Doc.Date:</label>
                                <br/><input type="date" id="txtReceiptDate" class="form-control" disabled />
                            </div>
                            <div class="col-sm-6">
                                <label id="lblHCustCode">Customer:</label>                                
                                <br/>
                                <div style="display:flex">
                                    <input type="text" id="txtHCustCode" class="form-control" style="width:20%" disabled />
                                    <input type="text" id="txtHCustBranch" class="form-control" style="width:10%" disabled />
                                    <input type="text" id="txtHCustName" class="form-control" style="width:70%" disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-5" style="display:flex;flex-direction:column">
                                <div>
                                    <label id="lblBillToCustCode">Bill To:</label>                                    
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtBillToCustCode" class="form-control" style="width:20%" disabled />
                                        <input type="text" id="txtBillToCustBranch" class="form-control" style="width:10%" disabled />
                                        <input type="text" id="txtBillToCustName" class="form-control" style="width:70%" disabled />
                                    </div>                                    
                                </div>
                                <div>
                                    <textarea id="txtBillAddress" class="form-control-lg" style="width:100%;height:100%" disabled></textarea>
                                </div>
                                <div>
                                    <label id="lblTRemark">Receipt Note:</label>                                    
                                    <br/>
                                    <textarea id="txtTRemark" class="form-control-lg" style="width:100%;height:100%"></textarea>
                                </div>
                                <div>
                                    <label id="lblCurrencyCode">Currency:</label>                                    
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtCurrencyCode" class="form-control" style="width:15%" disabled />
                                        <button class="btn btn-default" onclick="SearchData('currency')">...</button>
                                        <input type="text" id="txtCurrencyName" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="display:flex;flex-direction:column">
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblExchangeRate">Exchange Rate:</label>                                        
                                        <br/>
                                        <input type="text" id="txtExchangeRate" class="form-control" onchange="CalForeign()" />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblFTotalNet">Total Foreign:</label>                                        
                                        <br/>
                                        <input type="text" id="txtFTotalNet" class="form-control" disabled />
                                    </div>                                                                        
                                </div>
                                <div style="display:flex">
                                    <label style="width:40%" id="lblTotalCharge">Total Charge:</label><input type="text" id="txtTotalCharge" class="form-control" style="width:40%" disabled /> THB
                                </div>
                                <div style="display:flex">
                                    <label style="width:40%" id="lblTotalVAT">Total VAT:</label><input type="text" id="txtTotalVAT" class="form-control" style="width:40%" disabled /> THB
                                </div>
                                <div style="display:flex">
                                    <label style="width:40%" id="lblTotal50Tavi">Total TAX:</label><input type="text" id="txtTotal50Tavi" class="form-control" style="width:40%" disabled /> THB
                                </div>
                                <div style="display:flex">
                                    <label style="width:40%" id="lblTotalNet">Total Net:</label><input type="text" id="txtTotalNet" class="form-control" style="width:40%" disabled /> THB
                                </div>
                            </div>
                            <div class="col-sm-3" style="display:flex;flex-direction:column">
                                <div>
                                    <label id="lblReceiveRef">Voucher Ref:</label>
                                    <br/><input type="text" id="txtReceiveRef" class="form-control" disabled />
                                </div>
                                <div>
                                    <label id="lblReceiveDate">Receive Date:</label>
                                    <br/><input type="date" id="txtReceiveDate" class="form-control" disabled />
                                </div>
                                <div>
                                    <label id="lblReceiveTime">Receive Time:</label>
                                    <br/><input type="text" id="txtReceiveTime" class="form-control" disabled />
                                </div>
                                <div>
                                    <label id="lblReceiveBy">Receive By:</label>
                                    <br/><input type="text" id="txtReceiveBy" class="form-control" disabled />
                                </div>
                            </div>
                        </div>
                        <p>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblEmpCode">Create By:</label>
                                    <br /> <input type="text" id="txtEmpCode" class="form-control" disabled />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblPrintedDate">Print Date:</label>
                                    <br /> <input type="date" id="txtPrintedDate" class="form-control" disabled />
                                </div>
                                <div class="col-sm-2">
                                    <label id="lblPrintedTime">Print Time:</label>
                                    <br /><input type="text" id="txtPrintedTime" class="form-control" disabled />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblPrintedBy">Print By:</label>
                                    <br /> <input type="text" id="txtPrintedBy" class="form-control" disabled />
                                </div>
                            </div>
                        </p>
                        <div class="row">
                            <div class="col-sm-4">
                                <label id="lblCancelReson">Cancel Reason:</label>
                                <br /> <textarea id="txtCancelReson" class="form-control-lg" style="width:80%"></textarea>
                                <button id="btnCancel" class="btn btn-danger" onclick="CancelData()">Cancel</button>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblCancelDate">Cancel date:</label>
                                <br /> <input type="date" id="txtCancelDate" class="form-control" disabled />
                            </div>
                            <div class="col-sm-2">
                                <label id="lblCancelTime">Cancel Time:</label>
                                <br /><input type="text" id="txtCancelTime" class="form-control" disabled />
                            </div>
                            <div class="col-sm-3">
                                <label id="lblCancelProve">Cancel By:</label>
                                <br /> <input type="text" id="txtCancelProve" class="form-control" disabled />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnUpdate" onclick="SaveData()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                            </a>
                        </div>
                        <a href="#" class="btn btn-info" id="btnPrint2" onclick="PrintData()">
                            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print</b>
                        </a>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmDetail" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <div class="col-sm-6" style="display:flex">
                                <div style="flex:3">
                                    <label id="lblDDocNo">Receipt No</label>                                    
                                    <br/>
                                    <input type="text" id="txtDDocNo" class="form-control" disabled />
                                </div>
                                <div style="flex:1">
                                    <label id="lblItemNo">Item No.</label>
                                    <br/>
                                    <input type="text" id="txtItemNo" class="form-control" disabled />
                                </div>                                                                                                
                            </div>
                            <div class="col-sm-6" style="display:flex">
                                <div style="flex:3">
                                    <label id="lblInvoiceNo">Invoice No</label>                                    
                                    <br/>
                                    <input type="text" id="txtInvoiceNo" class="form-control" disabled />
                                </div>
                                <div style="flex:1">
                                    <label id="lblInvoiceItemNo">No#</label>                                    
                                    <br/>
                                    <input type="text" id="txtInvoiceItemNo" class="form-control" disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblSICode">Code</label>                                
                                <br/>
                                <input type="text" id="txtSICode" class="form-control" disabled />
                            </div>
                            <div class="col-sm-9">
                                <br/>
                                <input type="text" id="txtSDescription" class="form-control" />
                            </div>
                        </div>                       
                        <p>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblPayType">Payment Type</label>                                    
                                    <br/>
                                    <select id="cboacType" class="form-control" onchange="ChangeAmount()">
                                        <option value="CA">Cash</option>
                                        <option value="TR">Transfer</option>
                                        <option value="CH">Cheque</option>
                                        <option value="CR">Credit</option>
                                    </select>
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblDCurrencyCode">Currency</label>                                    
                                    <br/>
                                    <input type="text" id="txtDCurrencyCode" class="form-control" disabled />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblDExchangeRate">Exc.Rate</label>                                    
                                    <br/>
                                    <input type="number" id="txtDExchangeRate" class="form-control" onchange="CalForeignDetail()" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div style="display:flex">
                                        <div style="flex:1">
                                            <label id="lblAmt">Amount</label>                                            
                                        </div>
                                        <div style="flex:2">
                                            <input type="number" id="txtAmt" class="form-control" onchange="CalVATWHT(0)" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div style="display:flex">
                                        <div style="flex:1">
                                            <label id="lblAmtF">Amount (F)</label>                                            
                                        </div>
                                        <div style="flex:2">
                                            <input type="number" id="txtFAmt" class="form-control" onchange="CalForeignDetail()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6" style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblIsTaxCharge">VAT</label>                                        
                                        <br />
                                        <select id="txtIsTaxCharge" class="form-control dropdown" disabled>
                                            <option value="0">NO</option>
                                            <option value="1">EX</option>
                                            <option value="2">IN</option>
                                        </select>
                                    </div>
                                    <div style="flex:2">
                                        <label id="lblVATRate">Rate</label>                                        
                                        <br/>
                                        <input type="number" id="txtVATRate" class="form-control" onchange="CalVATWHT(0)" />
                                    </div>
                                </div>
                                <div class="col-sm-6" style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblAmtVAT">VAT</label>                                        
                                        <br/>
                                        <input type="number" id="txtAmtVAT" class="form-control" onchange="CalNetAmount()" />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblFAmtVAT">VAT (F)</label>                                        
                                        <br />
                                        <input type="number" id="txtFAmtVAT" class="form-control" disabled />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6" style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblIs50Tavi">WH-TAX</label>                                        
                                        <br />
                                        <select id="txtIs50Tavi" class="form-control dropdown" disabled>
                                            <option value="0">NO</option>
                                            <option value="1">YES</option>
                                        </select>
                                    </div>
                                    <div style="flex:2">
                                        <label id="lblRate50Tavi">Rate</label>                                        
                                        <br />       
                                        <input type="number" id="txtRate50Tavi" class="form-control" onchange="CalVATWHT(1)" />
                                    </div>
                                </div>
                                <div class="col-sm-6" style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblAmt50Tavi">WHT</label>                                        
                                        <br />
                                        <input type="number" id="txtAmt50Tavi" class="form-control" onchange="CalNetAmount()" />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblFAmt50Tavi">WHT (F)</label>                                        
                                        <br />
                                        <input type="number" id="txtFAmt50Tavi" class="form-control" disabled />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div style="display:flex">
                                        <div style="flex:1">
                                            <label id="lblNet">Net</label>                                            
                                        </div>
                                        <div style="flex:2">
                                            <input type="number" id="txtNet" class="form-control" onchange="ChangeAmount()" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div style="display:flex">
                                        <div style="flex:1">
                                            <label id="lblFNet">Net (F)</label>                                            
                                        </div>
                                        <div style="flex:2">
                                            <input type="number" id="txtFNet" class="form-control" disabled />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </p>
                        <p>
                            <div class="row">
                                <div class="col-sm-3">
                                    <label id="lblCashAmount">Cash</label>
                                    <br /><input type="number" id="txtCashAmount" class="form-control" disabled />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblTransferAmount">Transfer</label>
                                    <br /><input type="number" id="txtTransferAmount" class="form-control" disabled />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblChequeAmount">Cheque</label>
                                    <br /><input type="number" id="txtChequeAmount" class="form-control" disabled />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblCreditAmount">Credit</label>
                                    <br /><input type="number" id="txtCreditAmount" class="form-control" disabled />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblVoucherNo">Voucher No:</label>
                                    <br />
                                    <input type="text" id="txtVoucherNo" class="form-control" disabled />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblControlNo">Control No:</label>
                                    <br />
                                    <input type="text" id="txtControlNo" class="form-control" disabled />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblControlItemNo">#No:</label>
                                    <br />
                                    <input type="text" id="txtControlItemNo" class="form-control" disabled />
                                </div>
                            </div>
                        </p>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnUpd" onclick="SaveDetail()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                            </a>
                            <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteDetail()">
                                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDel">Delete</b>
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
    let row = {};
    let row_d = {};
    SetLOVs();
    $('#btnShow').on('click', function () {
        ShowHeader();
    });
    function SetLOVs() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,4);
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
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
        }
    }
    function CancelData() {
        if (userRights.indexOf('D') > 0) {
            if ($('#txtCancelReson').val() == '') {
                ShowMessage('Please enter reason for cancel',true);
                $('#txtCancelReson').focus();
                return;
            }
            $('#txtCancelDate').val(GetToday());
            $('#txtCancelTime').val(ShowTime(GetTime()));
            $('#txtCancelProve').val(user);
        } else {
            ShowMessage('you are not allow to cancel receipt',true);
        }
    }
    function SaveData() {
        let dataRcv = {
            BranchCode:$('#txtBranchCode').val(),
            ReceiptNo: $('#txtReceiptNo').val(),
            ReceiptDate: CDateEN($('#txtReceiptDate').val()),
            ReceiptType:row.ReceiptType,
            CustCode:$('#txtHCustCode').val(),
            CustBranch:$('#txtHCustBranch').val(),
            BillToCustCode:$('#txtBillToCustCode').val(),
            BillToCustBranch: $('#txtBillToCustBranch').val(),
            TRemark: $('#txtTRemark').val(),
            EmpCode:user,
            PrintedBy:row.PrintedBy,
            PrintedDate:CDateEN(row.PrintedDate),
            PrintedTime: row.PrintedTime,
            ReceiveBy: row.ReceiveBy,
            ReceiveDate:CDateEN(row.ReceiveDate),
            ReceiveTime: row.ReceiveTime,
            ReceiveRef: row.ReceiveRef,
            CancelReson:$('#txtCancelReson').val(),
            CancelProve:$('#txtCancelProve').val(),
            CancelDate:CDateEN($('#txtCancelDate').val()),
            CancelTime: $('#txtCancelTime').val(),
            CurrencyCode:$('#txtCurrencyCode').val(),
            ExchangeRate:CNum($('#txtExchangeRate').val()),
            TotalCharge:CNum($('#txtTotalCharge').val()),
            TotalVAT:CNum($('#txtTotalVAT').val()),
            Total50Tavi:CNum($('#txtTotal50Tavi').val()),
            TotalNet:CNum($('#txtTotalNet').val()),
            FTotalNet: CNum($('#txtFTotalNet').val())
        };
        let jsonString = JSON.stringify({ data: dataRcv });
        $.ajax({
            url: "@Url.Action("SetRcpHeader", "Acc")",
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
    function PrintData() {
        let code = row.ReceiptNo;
        if (code !== '') {
            let branch = row.BranchCode;
            window.open(path + 'Acc/FormRcp?Branch=' + branch + '&Code=' + code);
        }
    }
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
        $.get(path + 'acc/getReceipt?type=ADV&branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.receipt.header.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                ShowMessage('data not found',true);
                return;
            }
            let h = r.receipt.header[0];
            $('#tbHeader').DataTable({
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
                    { data: "ReceiptNo", title: "Receive No" },
                    {
                        data: "ReceiptDate", title: "Issue date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "ReceiveRef", title: "Reference Number" },
                    { data: "TRemark", title: "Remark" },
                    { data: "TotalNet", title: "Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                        }
                    }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            $('#tbHeader tbody').on('click', 'tr', function () {
                row = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                SetSelect('#tbHeader', this);
                $('#txtDocNo').val(row.ReceiptNo);
                row_d = {};
                ReadData();
                ShowDetail(row.BranchCode, row.ReceiptNo);
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                $('a[href="#tabDetail"]').click();
            });
            $('#tbHeader tbody').on('click', 'button', function () {
                if (userRights.indexOf('E') > 0) {
                    $('#frmHeader').modal('show');
                } else {
                    ShowMessage('you are not allow to edit receipt document',true);
                }
            });
        });
    }
    function ShowDetail(branch, code) {
        $('#tbDetail').DataTable().clear().draw();
        $.get(path + 'Acc/GetRcpDetail?Branch=' + branch + '&Code=' + code, function (r) {
            if (r.rcpdetail.data.length > 0) {
                let d = r.rcpdetail.data;
                $('#tbDetail').DataTable({
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
                        {
                            data: null, title: "Inv.No",
                            render: function (data) {
                                return data.InvoiceNo + '#' + data.InvoiceItemNo;
                            }
                        },
                        { data: "SICode", title: "Cpde" },
                        { data: "SDescription", title: "Expenses" },
                        { data: "CashAmount", title: "Cash",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "TransferAmount", title: "Transfer",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "ChequeAmount", title: "Cheque" ,
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "CreditAmount", title: "Credit" ,
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "Amt", title: "Amount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtVAT", title: "VAT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "Amt50Tavi", title: "WH-Tax",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "Net", title: "Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        }
                    ],
                    responsive:true,
                    destroy:true
                });
                $('#tbDetail tbody').on('click', 'tr', function () {
                    SetSelect('#tbDetail', this);
                    row_d = $('#tbDetail').DataTable().row(this).data();
                    LoadDetail();
                });
                $('#tbDetail tbody').on('click', 'button', function () {
                    if (userRights.indexOf('E') > 0) {
                        $('#frmDetail').modal('show');
                    } else {
                        ShowMessage('you are not allow to edit receipt document',true);
                    }
                });
            }
        });

    }
    function ReadData() {
        $('#txtReceiptNo').val(row.ReceiptNo);
        $('#txtReceiptDate').val(CDateEN(row.ReceiptDate));
        $('#txtReceiptType').val(row.ReceiptType);
        $('#txtHCustCode').val(row.CustCode);
        $('#txtHCustBranch').val(row.CustBranch);
        ShowCustomer(path, row.CustCode, row.CustBranch, '#txtHCustName');
        $('#txtBillToCustCode').val(row.BillToCustCode);
        $('#txtBillToCustBranch').val(row.BillToCustBranch);
        ShowCustomerAddress(path, row.BillToCustCode, row.BillToCustBranch, '#txtBillToCustName', '#txtBillAddress');
        $('#txtTRemark').val(row.TRemark);
        $('#txtEmpCode').val(row.EmpCode);
        $('#txtPrintedBy').val(row.PrintedBy);
        $('#txtPrintedDate').val(CDateEN(row.PrintedDate));
        $('#txtPrintedTime').val(ShowTime(row.PrintedTime));
        $('#txtReceiveBy').val(row.ReceiveBy);
        $('#txtReceiveDate').val(CDateEN(row.ReceiveDate));
        $('#txtReceiveTime').val(ShowTime(row.ReceiveTime));
        $('#txtReceiveRef').val(row.ReceiveRef);
        $('#txtCancelReson').val(row.CancelReson);
        $('#txtCancelProve').val(row.CancelProve);
        $('#txtCancelDate').val(CDateEN(row.CancelDate));
        $('#txtCancelTime').val(ShowTime(row.CancelTime));
        $('#txtCurrencyCode').val(row.CurrencyCode);
        ShowCurrency(path, row.CurrencyCode, '#txtCurrencyName');
        $('#txtExchangeRate').val(row.ExchangeRate);
        $('#txtTotalCharge').val(row.TotalCharge);
        $('#txtTotalVAT').val(row.TotalVAT);
        $('#txtTotal50Tavi').val(row.Total50Tavi);
        $('#txtTotalNet').val(row.TotalNet);
        $('#txtFTotalNet').val(row.FTotalNet);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
        $('#txtExchangeRate').focus();
    }
    function LoadDetail() {
        $('#txtDDocNo').val(row_d.ReceiptNo);
        $('#txtItemNo').val(row_d.ItemNo);

        $('#txtCashAmount').val(0);
        $('#txtTransferAmount').val(0);
        $('#txtChequeAmount').val(0);
        $('#txtCreditAmount').val(0);

        if (row_d.CashAmount > 0) {
            $('#cboacType').val('CA');
            $('#txtCashAmount').val(row_d.CashAmount);
        } else if (row_d.TransferAmount > 0) {
            $('#cboacType').val('TR');
            $('#txtTransferAmount').val(row_d.TransferAmount);
        } else if (row_d.ChequeAmount > 0) {
            $('#cboacType').val('CH');
            $('#txtChequeAmount').val(row_d.ChequeAmount);
        } else if (row_d.CreditAmount > 0) {
            $('#cboacType').val('CR');
            $('#txtCreditAmount').val(row_d.CreditAmount);
        }
        
        $('#txtControlNo').val(row_d.ControlNo);
        $('#txtVoucherNo').val(row_d.VoucherNo);
        $('#txtControlItemNo').val(row_d.ControlItemNo);
        $('#txtInvoiceNo').val(row_d.InvoiceNo);
        $('#txtInvoiceItemNo').val(row_d.InvoiceItemNo);
        $('#txtSICode').val(row_d.SICode);
        $('#txtSDescription').val(row_d.SDescription);
        $('#txtVATRate').val(row_d.VATRate);
        $('#txtRate50Tavi').val(row_d.Rate50Tavi);
        $('#txtAmt').val(row_d.Amt);
        $('#txtAmtVAT').val(row_d.AmtVAT);
        $('#txtAmt50Tavi').val(row_d.Amt50Tavi);
        $('#txtNet').val(row_d.Net);
        $('#txtDCurrencyCode').val(row_d.DCurrencyCode);
        $('#txtDExchangeRate').val(row_d.DExchangeRate);
        $('#txtFAmt').val(row_d.FAmt);
        $('#txtFAmtVAT').val(row_d.FAmtVAT);
        $('#txtFAmt50Tavi').val(row_d.FAmt50Tavi);
        $('#txtFNet').val(row_d.FNet);
        if ($('#txtControlNo').val() !== '') {
            $('#btnUpd').attr('disabled', 'disabled');
            $('#btnDel').attr('disabled', 'disabled');
        } else {
            $('#btnUpd').removeAttr('disabled');
            $('#btnDel').removeAttr('disabled');
        }
    }
    function SaveDetail() {
        if (row_d !== null) {
            row_d.SDescription = $('#txtSDescription').val();
            row_d.DCurrencyCode = $('#txtDCurrencyCode').val();
            row_d.DExchangeRate = $('#txtDExchangeRate').val();
            row_d.FAmt = CNum($('#txtFAmt').val());
            row_d.FAmt50Tavi = CNum($('#txtFAmt50Tavi').val());
            row_d.FAmtVAT = CNum($('#txtFAmtVAT').val());
            row_d.FNet = CNum($('#txtFNet').val());
            row_d.Amt = CNum($('#txtAmt').val());
            row_d.Amt50Tavi = CNum($('#txtAmt50Tavi').val());
            row_d.AmtVAT = CNum($('#txtAmtVAT').val());
            row_d.Net = CNum($('#txtNet').val());
            row_d.CashAmount = CNum($('#txtCashAmount').val());
            row_d.TransferAmount = CNum($('#txtTransferAmount').val());
            row_d.ChequeAmount = CNum($('#txtChequeAmount').val());
            row_d.CreditAmount = CNum($('#txtCreditAmount').val());
            row_d.VATRate = CNum($('#txtVATRate').val());
            row_d.Rate50Tavi = CNum($('#txtRate50Tavi').val());

            let jsonText = JSON.stringify({ data: row_d });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetRcpDetail", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data !== null) {
                        ShowDetail(row.BranchCode, row.ReceiptNo);
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
            ShowMessage('no data to save',true);
        }
    }
    function DeleteDetail() {
        if (row_d !== null) {
            $.get(path+ 'Acc/DelRcpDetail?Branch=' + row.BranchCode + '&Code=' + row.ReceiptNo + '&Item=' + row_d.ItemNo)
                .done(function (r) {
                    if (r.rcpdetail.data !== null) {
                        ShowDetail(row.BranchCode, row.ReceiptNo);
                    }
                    ShowMessage(r.rcpdetail.result);
                });
        } else {
            ShowMessage('no data to delete',true);
        }
    }
    function ChangeAmount() {
        $('#txtCashAmount').val(0);
        $('#txtTransferAmount').val(0);
        $('#txtChequeAmount').val(0);
        $('#txtCreditAmount').val(0);
        let amt = $('#txtNet').val();
        switch ($('#cboacType').val()) {
            case 'CA':
                $('#txtCashAmount').val(amt);
                break;
            case 'TR':
                $('#txtTransferAmount').val(amt);
                break;
            case 'CH':
                $('#txtChequeAmount').val(amt);
                break;
            case 'CR':
                $('#txtCreditAmount').val(amt);
                break;
        }
    }
    function CalForeign() {
        let totalforeign = CDbl(CNum($('#txtTotalNet').val()) / CNum($('#txtExchangeRate').val()), 2);
        $('#txtFTotalNet').val(ShowNumber(totalforeign,2));
    }
    function CalForeignDetail() {
        let rate = CNum($('#txtDExchangeRate').val());
        $('#txtAmt').val(CDbl(CNum($('#txtFAmt').val()) * rate, 2));
        CalVATWHT(0);
    }
    function CalVATWHT(step = 0) {
        
        let amt = CNum($('#txtAmt').val());
        if (step == 0) {
            let vat = amt * CNum($('#txtVATRate').val()) * 0.01;
            $('#txtAmtVAT').val(CDbl(vat,2));
        }
        let wht = amt * CNum($('#txtRate50Tavi').val()) * 0.01;
        $('#txtAmt50Tavi').val(CDbl(wht, 2));
        CalNetAmount();
    }
    function CalNetAmount() {
        let amt = CNum($('#txtAmt').val());
        let vat = CNum($('#txtAmtVAT').val());
        let wht = CNum($('#txtAmt50Tavi').val());
        let net = amt + vat - wht;

        $('#txtNet').val(CDbl(net, 2));

        let rate = CNum($('#txtDExchangeRate').val());
        $('#txtFAmtVAT').val(CDbl(CNum($('#txtAmtVAT').val()) / rate, 2));
        $('#txtFAmt50Tavi').val(CDbl(CNum($('#txtAmt50Tavi').val()) / rate, 2));
        $('#txtFNet').val(CDbl(CNum($('#txtNet').val()) / rate, 2));
        ChangeAmount();
    }
    function CreateReceipt() {
        let w = '?branch=' + $('#txtBranchCode').val();
        if ($('#txtCustCode').val() !== '') {
            w += '&custcode=' + $('#txtCustCode').val() + '&custbranch=' + $('#txtCustBranch').val();
        }        
        window.open(path +'Acc/GenerateReceipt' + w, '_blank');
    }
</script>
