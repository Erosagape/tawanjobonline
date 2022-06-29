@Code
    ViewBag.Title = "Clearing Information"
End Code
<div class="panel-body">
    <div id="dvHeader" class="container">
        <div class="row">
            <div class="col-sm-5">
                *<label id="lblBranch">Branch:</label>                
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
                </div>
                <div id="dvJob"></div>
            </div>
            <div class="col-sm-4" style="text-align:left">
                <label id="lblClrNo" ondblclick="SaveHeader()">Clearing No:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtClrNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('clearing')" />
                </div>
            </div>
            <div class="col-sm-3">
                <label id="lblClrDate">Document Date </label><br/>
                <input type="date" class="form-control" id="txtClrDate" tabindex="1" />
            </div>
        </div>
        <ul class="nav nav-tabs">
            <li class="active"><a id="linkHeader" data-toggle="tab" href="#tabHeader">Clearing Header</a></li>
            <li><a id="linkDetail" data-toggle="tab" href="#tabDetail">Clearing Detail</a></li>
        </ul>
        <div class="tab-content">
            <div id="tabHeader" class="tab-pane fade in active">
                <div class="row">
                    <div class="col-sm-7">
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblClrBy">Clear By :</label>

                            </div>
                            <div class="col-sm-9" style="display:flex">
                                <input type="text" id="txtEmpCode" class="form-control" style="width:100px" disabled />
                                <button id="btnBrowseEmp1" class="btn btn-default" onclick="SearchData('clrby')" tabindex="2">...</button>
                                <input type="text" id="txtEmpName" class="form-control" style="width:100%" disabled />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblClrType">Clear Type :</label>
                            </div>
                            <div class="col-sm-4">
                                <select id="cboClrType" class="form-control dropdown"></select>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblAdvRefNo">Ref No :</label>
                            </div>
                            <div class="col-sm-3">
                                <input type="text" id="txtAdvRefNo" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
				<input type="checkbox" id="chkContainer" onclick="CheckContainer()" checked />
                                <label id="lblContNo" style="color:red">Container No:</label>
                            </div>
                            <div class="col-sm-4" style="display:flex">
                                <input type="text" id="txtCTN_NO" class="form-control" tabindex="6" value="N/A" disabled />
                                <button class="btn btn-default" onclick="SearchData('container')">...</button>
                            </div>
                            <div class="col-sm-2">
                                <label id="lblClearanceDate">Clearance Date :</label>
                            </div>
                            <div class="col-sm-3" style="display:flex">
                                <input type="date" id="txtClearanceDate" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <table style="width:100%">
                            <tr>
                                <td>
                                    <label id="lblJobType">Job Type :</label>                                    
                                </td>
                                <td style="display:flex;flex-direction:row">
                                    <select id="cboJobType" class="form-control dropdown" tabindex="8"></select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label id="lblClrFrom">Clear From :</label>                                    
                                </td>
                                <td style="display:flex;flex-direction:row">
                                    <select id="cboClrFrom" class="form-control dropdown" tabindex="9"></select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label id="lblClrStatus">Status :</label>                                    
                                </td>
                                <td style="display:flex;flex-direction:row">
                                    <select id="cboDocStatus" class="form-control dropdown" disabled></select>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-7">
                        <label id="lblCoPerson">Co-person Reference:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" class="form-control" id="txtCoPersonCode" />
                        </div>
                        <label id="lblTRemark">Remark:</label>                        
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <textarea id="txtTRemark" class="form-control" tabindex="11"></textarea>
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <table>
                            <tr>
                                <td>
                                    <label id="lblAdvTotal">Advance Total</label>
                                </td>
                                <td style="display:flex;flex-direction:row">
                                    <input type="text" id="txtAdvTotal" class="form-control" style="width:100%;text-align:right" disabled />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label id="lblExpTotal">Expenses Total</label>
                                </td>
                                <td style="display:flex;flex-direction:row">
                                    <input type="text" id="txtTotalExpense" class="form-control" style="width:100%;text-align:right" disabled />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label id="lblClrTotal">Clear Total</label>
                                </td>
                                <td style="display:flex;flex-direction:row">
                                    <input type="text" id="txtClearTotal" class="form-control" style="width:100%;text-align:right" disabled />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4" style="border-style:solid;border-width:1px">
                        <input type="checkbox" id="chkApprove" />
                        <label id="lblApprBy" for="chkApprove">Approve By</label>
                        <br />
                        <input type="text" id="txtApproveBy" style="width:250px" disabled />
                        <br />
                        <label id="lblApprDate">Date:</label>                        
                        <input type="date" id="txtApproveDate" disabled />
                        <label id="lblApprTime">Time:</label>                        
                        <input type="text" id="txtApproveTime" style="width:80px" disabled />
                    </div>
                    <div class="col-sm-4" style="border-style:solid;border-width:1px">
                        <input type="checkbox" id="chkReceive" disabled />
                        <label id="lblRecvBy" for="chkReceive">Receive By</label>
                        <input type="text" id="txtReceiveBy" style="width:250px" disabled />
                        <br />
                        <label id="lblRecvDate">Date:</label>                        
                        <input type="date" id="txtReceiveDate" disabled />
                        <label id="lblRecvTime">Time:</label>
                        <input type="text" id="txtReceiveTime" style="width:80px" disabled />
                        <br />
                        <label id="lblRecvRef">R/V Ref:</label>
                        <input type="text" id="txtReceiveRef" style="width:200px" disabled />
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
                        <label id="lblCancelReson">Cancel Reason :</label>
                        <input type="text" id="txtCancelReson" style="width:250px" />
                    </div>
                </div>
                <div id="dvCommand">
                    <a href="#" class="btn btn-default w3-purple" id="btnNew" onclick="AddHeader()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">New Document</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveHeader()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Document</b>
                    </a>
                    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Document</b>
                    </a>
                </div>
            </div>
            <div id="tabDetail" class="tab-pane fade" onclick="PrepareData()" >
                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddDetail()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Detail</b>
                </a>
                <a href="#" class="btn btn-warning" id="btnChooseAdv" onclick="LoadAdvance()">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkAdv">Choose Advances</b>
                </a>
                <a href="#" class="btn btn-primary" id="btnChooseAdv" onclick="LoadPayment()">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkPay">Choose Payments</b>
                </a>
                <div class="row">
                    <div class="col-sm-12">
                        <table id="tbDetail" class="table table-responsive">
                            <thead>
                                <tr>
                                    <th>
                                    <th class="desktop">SICode</th>
                                    <th class="all">Description</th>
                                    <th class="desktop">Job.No</th>
                                    <th class="desktop">Adv.No</th>
                                    <th class="desktop">Advance</th>
                                    <th class="desktop">Clear</th>
                                    <th class="desktop">Vat</th>
                                    <th class="desktop">WH-Tax</th>
                                    <th class="all">Net</th>
                                    <th class="desktop">Currency</th>
                                    <th class="desktop">Remark</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-9">
                        <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteDetail()">
                            <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDel">Delete Detail</b>
                        </a>
                        <p>
                            <label id="lblSumCharge">Customers Chargable :</label>                            
                            <input type="text" id="txtSumCharge" style="width:100px;text-align:right" />
                            <br />                                                                                                        
                            <label id="lblSumCost">Company Cost :</label>                            
                            <input type="text" id="txtSumCost" style="width:100px;text-align:right" /><br />
                        </p>
                    </div>
                    <div class="col-sm-3" style="text-align:right">
                        <label id="lblClrAmount">Amount</label>
                         :
                        <input type="text" id="txtClrAmount" style="width:100px;text-align:right" />
                        <br />                                                                                                    
                        <label id="lblVatAmount">VAT</label>
                         :
                        <input type="text" id="txtVatAmount" style="width:100px;text-align:right" />
                        <br />
                        <label id="lblWhtAmount">WHT</label>
                         :
                        <input type="text" id="txtWhtAmount" style="width:100px;text-align:right" />
                        <br />
                        <label id="lblNetAmount">Total</label>
                         :
                        <input type="text" id="txtNetAmount" style="width:100px;text-align:right" />
                    </div>
                </div>
                <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint2">Print Document</b>
                </a>
            </div>
            <div id="frmDetail" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label id="lblItemNo" for="txtItemNo">No :</label><br />
                                    <input type="text" id="txtItemNo" class="form-control" disabled />
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblSTCode">Service Type</label>
                                    <br />
                                    <div style="display:flex">
                                        <select id="cboSTCode" class="form-control dropdown"></select>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblDuplicate" for="chkDuplicate">Partial Clear</label><br />
                                    <input type="checkbox" id="chkDuplicate" onchange="ToggleClearBtn()" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <a href="../Master/ServiceCode" target="_blank"><label id="lblSICode">Service Code</label></a>
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtSICode" class="form-control" tabindex="12" />
                                        <input type="button" id="btnBrowseS" class="btn btn-default" value="..." onclick="SearchData('servicecode')" />
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <label id="lblSDescription">Description : </label>
                                    <br/>
                                    <div style="display:flex">
                                        <input type="text" id="txtSDescription" class="form-control" tabindex="13" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblJobNo" for="txtForJNo">Job No :</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtForJNo" class="form-control" tabindex="14" />
                                        <input type="button" id="btnBrowseJ" class="btn btn-default" value="..." onclick="SearchData('job')" />
                                    </div>
                                </div>
                                <div class="col-sm-8">
                                    <label id="lblCustInv">Cust.Inv :</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtInvNo" class="form-control" disabled />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblQNo">Quotation No :</label>/<label id="lblEstimate" onclick="SearchData('estimate')" >Estimate</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtQNo" class="form-control" disabled />
                                        <input type="button" id="btnBrowseQ" class="btn btn-default" value="..." onclick="SearchData('quotation')" />
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblCurrCode" for="txtCurrencyCode">Currency:</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtCurrencyCode" class="form-control" style="width:100px" tabindex="15" />
                                        <input type="button" id="btnBrowseCurr" class="btn btn-default" value="..." onclick="SearchData('detcurrency')" />
                                        <input type="text" id="txtCurrencyName" class="form-control" disabled />
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <label id="lblCurrRate" for="txtCurRate">Rate :</label><br />
                                    <input type="text" id="txtCurRate" class="form-control" style="text-align:right" tabindex="16" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <label id="lblQty" for="txtQty">Qty:</label><br/>
                                    <input type="text" id="txtQty" class="form-control" style="text-align:right" tabindex="17" />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblUnit" for="txtUnitcode"><a onclick="SearchData('servunit')">Unit:</a></label>
                                    <br/>
                                    <input type="text" id="txtUnitCode" class="form-control" tabindex="18" />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblUnitPrice" for="txtUnitPrice" style="color:red">Price :</label>
                                    <br/>
                                    <input type="text" id="txtUnitPrice" class="form-control" style="color:red;text-align:right;background-color:lightyellow;font-weight:bold" tabindex="19" />
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblAmount" for="txtAmount">Amount :</label>
                                    <br />
                                    <input type="text" id="txtAMT" class="form-control" style="text-align:right" tabindex="20" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-5">
                                    <label id="lblVATRate" for="txtVATRate">VAT :</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtVATRate" class="form-control" style="text-align:right" tabindex="21" />
                                        <select id="txtVatType" class="form-control dropdown">
                                            <option value="0">NO</option>
                                            <option value="1">EX</option>
                                            <option value="2">IN</option>
                                        </select>
                                        <input type="text" id="txtVAT" class="form-control" style="text-align:right" tabindex="22" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblWHTRate" for="txtWHTRate">WH-Tax :</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtWHTRate" class="form-control" style="text-align:right" tabindex="23" />
                                        <input type="text" id="txtWHT" class="form-control" style="text-align:right" tabindex="24" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <label id="lblNETAmount" for="txtNETAmount" style="color:blue">Net :</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtNET" class="form-control" style="color:darkblue;font-weight:bold;text-align:right;background-color:aquamarine" tabindex="25" />
                                    </div>
                                </div>
                            </div>   
                            <div class="row">
                                <div class="col-sm-4">
                                    <label id="lblWTNo">WH-Tax No :</label>                                    
                                    <br />
                                    <input type="text" id="txt50Tavi" class="form-control" tabindex="28" />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblSlipDate">Slip Date :</label>                                    
                                    <br />
                                    <input type="date" class="form-control" id="txtDate50Tavi" tabindex="26" />
                                </div>
                                <div class="col-sm-4">
                                    <label id="lblSlipNo">Slip No :</label>
                                    <br />
                                    <input type="text" id="txtSlipNo" class="form-control" tabindex="27" />
                                </div>
                            </div>                            
                            <div>
                                <input type="checkbox" id="chkIsLtdAdv50Tavi" />
                                <label id="lblLtdAdv" for="chkIsLtdAdv50Tavi">**หักตามมาตรา 60,69,70</label>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <label id="lblVenCode">Pay To Vender :</label>
                                    <div style="display:flex">
                                        <input type="text" id="txtVenCode" class="form-control" style="width:150px" tabindex="29" />
                                        <input type="button" id="btnBrowseVen" class="btn btn-default" onclick="SearchData('vender')" value="..." />
                                        <input type="text" id="txtPayChqTo" class="form-control" tabindex="30" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <label id="lblDRemark">Remark :</label>
                                    <br/>
                                    <textarea id="txtRemark" style="width:100%;height:80px" tabindex="31"></textarea>
                                </div>
                                <div class="col-sm-6">
                                    <input type="checkbox" id="chkIsCost" disabled />
                                    <label id="lblIsCost" for="chkIscost">Is Company Cost (Cannot Charge)</label>
                                    <br />
                                    <label id="lblAdvItemNo" for="txtAdvItemNo">Clear From Adv Item.No :</label>
                                    <input type="text" id="txtAdvItemNo" style="width:40px"/>
                                    <br/>
                                    <label id="lblAdvNo" for="txtAdvNo">Adv.No :</label>
                                    <input type="text" id="txtAdvNo" style="width:150px"/> 
                                    <br/>
                                    <label id="lblAdvAmt">Advance Net :</label>                                    
                                    <input type="text" id="txtAdvAmount" style="width:60px"/>
                                </div>
                            </div>                            
                            <div class="row">
                                <div class="col-sm-6">
                                    <label id="lblInvNo">Invoice# :</label><input type="text" id="txtLinkBillNo" style="width:150px" disabled />
                                    <input type="text" id="txtLinkItem" style="width:30px" disabled />
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblPayNo" ondblclick="SaveDetail()">Vender Inv#</label>
                                    <input type="text" id="txtVenderBillingNo" style="width:150px" />
                                    <input type="button" value="View" onclick="ShowVenderBill()" />
                                </div>
                            </div>
                            <input type="hidden" id="txtJobType" />
                            <input type="hidden" id="txtShipBy" />
                        </div>
                        <div class="modal-footer">
                            <div style="float:left">
                                <a href="#" class="btn btn-default w3-purple" id="btnAddD" onclick="ClearDetail()">
                                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkClear">New</b>
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
                        <div class="modal-body">
                            <label id="lblFilter">Filter By Status : </label>
                            <select id="cboStatus" class="form-control dropdown" onchange="SetGridClr()"></select>
                            <br />
                            <table id="tbHeader" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>ClrNo</th>
                                        <th class="desktop">ClrDate</th>
                                        <th class="desktop">CustCode</th>
                                        <th class="desktop">ReqBy</th>
                                        <th>Job</th>
                                        <th class="desktop">Inv No</th>
                                        <th class="desktop">Status</th>
                                        <th class="all">ClrAmount</th>
                                        <th class="desktop">Container</th>
                                        <th class="desktop">AdvNo</th>
                                        <th class="all">AdvAmount</th>
                                        <th class="desktop">Remark</th>
                                    </tr>
                                </thead>
                            </table>
                            <div id="dvClrFilter"></div>
                        </div>
                        <div class="modal-footer">
                            <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                        </div>
                    </div>
                </div>
            </div>
            <div id="frmPayment" class="modal modal-lg fade">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"><label id="lblHeaderPay">Payments List</label></h4>
                        </div>
                        <div class="modal-body">
                            <table id="tbPayment" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>PaymentNo</th>
                                        <th class="desktop">DueDate</th>
                                        <th class="all">ItemNo</th>
                                        <th class="desktop">SICode</th>
                                        <th>Description</th>
                                        <th class="desktop">JobNo</th>
                                        <th class="desktop">Currency</th>
                                        <th class="desktop">ExcRate</th>
                                        <th class="desktop">Qty</th>
                                        <th class="desktop">Unit</th>
                                        <th class="all">Net</th>
                                        <th class="all">50Tavi</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button id="btnHideP" class="btn btn-danger" data-dismiss="modal">X</button>
                        </div>
                    </div>
                </div>
            </div>
            <div id="frmAdvance" class="modal modal-lg fade">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"><label id="lblHeaderAdv">Advance List</label></h4>
                        </div>
                        <div class="modal-body">
                            <table id="tbAdvance" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>AdvNo</th>
                                        <th class="desktop">AdvDate</th>
                                        <th class="all">Container</th>
                                        <th class="desktop">SICode</th>
                                        <th>Description</th>
                                        <th class="desktop">JobNo</th>
                                        <th class="desktop">Currency</th>
                                        <th class="desktop">ExcRate</th>
                                        <th class="desktop">Qty</th>
                                        <th class="desktop">Unit</th>
                                        <th class="all">AdvNet</th>
                                        <th class="all">50Tavi</th>
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
    <div id="frmSearchQuo" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <label id="lblHeaderQuo">Select Quotation</label>
                    <br />
                    <label id="lblCustCode">Customer :</label>
                    <input type="text" id="txtCustCode" style="width:100px" disabled />
                    <input type="text" id="txtCustBranch" style="width:50px" disabled />
                    <input type="text" id="txtCustName" style="width:400px" disabled />
                </div>
                <div class="modal-body">
                    <table id="tbQuo" class="table table-responsive">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Q.No</th>
                                <th>Code</th>
                                <th>Desc</th>
                                <th>Unit Price</th>
                                <th class="desktop">Vender</th>
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
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    const userPosition = '@ViewBag.UserPosition';
    let serv = []; //must be array of object
    let hdr = {}; //simple object
    let dtl = {}; //simple object
    let job = '';
    let isjobmode = false;
    let chkmode = false;
    //$(document).ready(function () {
        SetLOVs();
        SetEvents();
        SetEnterToTab();
        CheckParam();
    //});
    function CheckContainer() { 
	if($('#chkContainer').prop('checked')==false){
		$('#txtCTN_NO').val('N/A');
	}
    }
    function ToggleClearBtn() {
        //if ($('#txtAdvNo').val() == '') {
        //    $('#btnAddD').show();
        //} else {
        //    if ($('#chkDuplicate').prop('checked') == false) {
        //        $('#btnAddD').show();
        //    } else {
        //        $('#btnAddD').hide();
        //    }
        //}
    }
    function CheckParam() {
        ClearHeader();
        //read query string parameters
        let br = getQueryString('BranchCode');
        if (br.length > 0) {
            $('#txtBranchCode').val(br);
            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            let ano = getQueryString('ClrNo');
            if (ano.length > 0) {
                $('#txtClrNo').val(ano);
                ShowData(br, $('#txtClrNo').val());
            } else {
                job = getQueryString('JNo');
                SetJob();
            }
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME'); 
        }
    }
    function SetJob() {
        $('#dvJob').html('<h4>***For Job ' + job.toUpperCase() + '***</h4>');
        if (job.length > 0) {
            isjobmode = true;
            $('#txtForJNo').val(job);
            $('#txtClrNo').attr('disabled', 'disabled');
            CallBackQueryJob(path, $('#txtBranchCode').val(), job, LoadJob);
        }
    }
    function LoadJob(dt) {
        if (dt.length > 0) {
            let dr = dt[0];
            $('#txtForJNo').val(dr.JNo);
            $('#txtInvNo').val(dr.InvNo);
            $('#cboJobType').val(CCode(dr.JobType));
            $('#cboDocStatus').val('01');
            $('#txtQNo').val(dr.QNo);
            $('#txtCustCode').val(dr.CustCode);
            $('#txtCustBranch').val(dr.CustBranch);
            $('#txtJobType').val(dr.JobType);
            $('#txtShipBy').val(dr.ShipBy);
            ShowCustomer(path, dr.CustCode, dr.CustBranch, '#txtCustName');

            $('#btnBrowseCust').attr('disabled', 'disabled');
            $('#txtForJNo').attr('disabled', 'disabled');
            $('#btnBrowseJ').attr('disabled', 'disabled');
            $('#cboJobType').attr('disabled', 'disabled');            

            $('#txtEmpCode').val(user);
            CallBackQueryUser(path, $('#txtEmpCode').val(), ReadClrBy);

            //$('#txtEmpCode').focus();
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
    function CheckService(dt) {
        if (dt !== undefined) {
            if ($('#cboClrType').val() == 1 && dt.IsCredit !== 1) {
                ShowMessage('This expense is not allowed');
                return false;
            }
            if ($('#cboClrType').val() == 2 && dt.IsExpense !== 1) {
                ShowMessage('This expense is not allowed');
                return false;
            }
            if ($('#cboClrType').val() == 3 && (dt.IsExpense == 1 || dt.IsCredit ==1)) {
                ShowMessage('This expense is not allowed');
                return false;
            }
        }
        return true;
    }
    function SetEvents() {
        if (userRights.indexOf('I') < 0) $('#btnNew').attr('disabled', 'disabled');
        if (userRights.indexOf('I') < 0) $('#btnAdd').attr('disabled', 'disabled');
        if (userRights.indexOf('E') < 0) $('#btnSave').attr('disabled', 'disabled');
        if (userRights.indexOf('E') < 0) $('#btnUpdate').attr('disabled', 'disabled');
        if (userRights.indexOf('D') < 0) $('#btnDel').attr('disabled', 'disabled');
        if (userRights.indexOf('P') < 0) $('#btnPrint').attr('disabled', 'disabled');

        $('#frmDetail').on('shown.bs.modal', function () {
            $('#txtSICode').focus();
        });

        $('#chkApprove').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_CLR', 'Approve',(chkmode ? 'I':'D'), SetApprove);
        });

        $('#chkCancel').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_CLR', 'Index', 'D', SetCancel);
        });

        $('#txtCurrencyCode').keydown(function (event) {
            if (event.which == 13) {
                ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
                ShowCaption();
            }
        });

        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });

        $('#txtClrNo').keydown(function (event) {
            if (event.which == 13) {
                ShowData($('#txtBranchCode').val(),$('#txtClrNo').val());
            }
        });

        $('#txtEmpCode').keydown(function (event) {
            if (event.which == 13) {
                CallBackQueryUser(path, $('#txtEmpCode').val(), ReadClrBy);
            }
        });

        $('#txtSICode').keydown(function (event) {
            if (event.which == 13) {
                let dt = FindService($('#txtSICode').val());               
                if (CheckService(dt) == false) {
                    return;
                }
                ReadService(dt);
            }
        });

        $('#txtQty').keydown(function (event) {
            if (event.which == 13) {
                CalAmount();
            }
        });

        $('#txtUnitPrice').focusout(function (event) {
            if (true) {
                CalAmount();
            }
        });

        $('#txtCurRate').keydown(function (event) {
            if (event.which == 13) {
                CalAmount();
            }
        });

        $('#txtAMT').focusout(function (event) {
            if (true) {
                CalVATWHT();
            }
        });

        $('#txtVATRate').keydown(function (event) {
            if (event.which == 13) {
                CalVATWHT();
            }
        });

        $('#txtWHTRate').keydown(function (event) {
            if (event.which == 13) {
                CalVATWHT();
            }
        });

        $('#txtVAT').keydown(function (event) {
            if (event.which == 13) {
                CalTotal();
            }
        });

        $('#txtWHT').keydown(function (event) {
            if (event.which == 13) {
                CalTotal();
            }
        });

        $('#txtForJNo').keydown(function (event) {
            if (event.which == 13) {
                //ShowInvNo(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), '#txtInvNo');
                $('#txtInvNo').val('');
                $('#txtQNo').val('');
                $('#txtCustCode').val('');
                $('#txtCustBranch').val('');
                $('#txtCustName').val('');
                $('#txtJobType').val('0');
                $('#txtShipBy').val('0');
                CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), ReadJob);
            }
        });

        $('#txtNET').keydown(function (event) {
            if (event.which == 13) {
                let type = $('#txtVatType').val();
                if (type == ''||type=='0') type = "1";
                if (type == "2") {
                    CalVATWHT();
                } else {
                    CalTotal();
                }
            }
        });

        $('#cboClrType').click(function (ev) {
            loadServiceGroupForClear(path, '#cboSTCode', $('#cboClrType').val());
        });
    }
    function SetApprove(b) {
        if (b == true) {
            $('#txtApproveBy').val(chkmode ? user : '');
            $('#txtApproveDate').val(chkmode ? CDateEN(GetToday()) : '');
            $('#txtApproveTime').val(chkmode ? ShowTime(GetTime()) : '');
            if (chkmode) {
                if ($('#cboDocStatus').val().substr(0, 2) == '01') {
                    $('#cboDocStatus').val('02');
                    let dataApp = [];
                    dataApp.push(user);
                    dataApp.push($('#txtBranchCode').val() + '|' + $('#txtClrNo').val());
                    let jsonString = JSON.stringify({ data: dataApp });
                    $.ajax({
                        url: "@Url.Action("ApproveClearing", "Clr")",
                        type: "POST",
                        contentType: "application/json",
                        data: jsonString,
                        success: function (response) {
                            if (response) {
                                SaveHeader();
                            } else {
                                ShowMessage("Cannot Approve",true);
                            }
                            return;
                        },
                        error: function (e) {
                            ShowMessage(e,true);
                            return;
                        }
                    });
                }
                return;
            } else {
                if ($('#cboDocStatus').val().substr(0, 2) == '02') {
                    $('#cboDocStatus').val('01');
                }
                SaveHeader();
            }
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkApprove').prop('checked', !chkmode);
    }

    function SetClear(b) {
        if (b == true) {
            $('#txtReceiveBy').val(chkmode ? user : '');
            $('#txtReceiveDate').val(chkmode ? CDateEN(GetToday()) : '');
            $('#txtReceiveTime').val(chkmode ? ShowTime(GetTime()) : '');
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkReceive').prop('checked', !chkmode);
    }

    function SetCancel(b) {
        if (b == true) {
            if (chkmode) {
                $('#cboDocStatus').val('99');
            } else {
                $('#cboDocStatus').val('1');
                $('#txtApproveDate').val('');
                $('#txtApproveTime').val('');
            }                
            $('#txtCancelProve').val(chkmode ? user : '');
            $('#txtCancelDate').val(chkmode ? CDateEN(GetToday()) : '');
            $('#txtCancelTime').val(chkmode ? ShowTime(GetTime()) : '');
            SaveHeader();
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkCancel').prop('checked', !chkmode);
    }

    function SetLOVs() {
        //Combos
        let lists = 'JOB_TYPE=#cboJobType';
        lists += ',CLR_STATUS=#cboDocStatus|01';
        lists += ',CLR_STATUS=#cboStatus|';
        lists += ',CLR_TYPE=#cboClrType|';
        lists += ',CLR_FROM=#cboClrFrom';

        loadCombos(path, lists);
        LoadService();

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2').done(function (response) {
            let dv = document.getElementById("dvLOVs");
            //Venders
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response,2);
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job List', response, 3);
            //Users
            CreateLOV(dv, '#frmSearchClr', '#tbClr', 'Clear By', response,2);            
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,2);
            //SICode
            CreateLOV(dv, '#frmSearchSICode', '#tbServ', 'Service Code', response,2);
            //Currency
            CreateLOV(dv, '#frmSearchExpCur', '#tbExpCur', 'Currency Code', response, 2);
            //Unit
            CreateLOV(dv, '#frmSearchUnit', '#tbUnit', 'Unit Code', response, 2);
            //Estimate
            CreateLOV(dv, '#frmSearchEstimate', '#tbEstimate', 'Estimate Price', response, 3);
            //Containers
            CreateLOV(dv, '#frmSearchCont', '#tbCont', 'Container Code', response, 4);
        });
    }
    function ShowData(branchcode, clrno) {
        if (branchcode == '') {
            ShowMessage('Please input branch',true);
            return;
        }
        if (clrno == '') {
            ShowMessage('Please input clear no',true);
            return;
        }
        if (userRights.indexOf('R') < 0) {
            ShowMessage('You are not allow to view',true);
            return;
        }
        ClearHeader();
        $.get(path + 'clr/getclearing?branch=' + branchcode + '&code=' + clrno).done(function (r) {
            if (r.clr !== undefined) {
                let h = r.clr.header[0];
                ReadClrHeader(h);
                let d = r.clr.detail;
                ReadClrDetail(d);
            }
        });
    }
    function PrintData() {
        if (userRights.indexOf('P') < 0) {
            ShowMessage('You are not allow to print',true);
            return;
        }
        window.open(path + 'Clr/FormClr?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtClrNo').val());
    }
    function CheckEntry() {
        if ($('#txtBranchName').val() == '') {
            ShowMessage('Please input branch',true);
            $('#txtBranchCode').focus();
            return false;
        }
/*
        if ($('#txtCTN_NO').val() == '') {
            ShowMessage('Please input container',true);
            $('#txtCTN_NO').focus();
            return false;
        }
*/
        if ($('#cboJobType').val() == 0) {
            ShowMessage('Please select job type',true);
            $('#cboJobType').focus();
            return false;
        }
        if ($('#cboClrType').val() == 0) {
            ShowMessage('Please select clear type',true);
            $('#cboClrType').focus();
            return false;
        }
        if ($('#cboClrFrom').val() == 0) {
            ShowMessage('Please select clear from',true);
            $('#cboClrFrom').focus();
            return false;
        }
        if (userRights.indexOf('E') < 0) {
            ShowMessage('You are not allow to save',true);
            return false;
        }
        return true;
    }
    function SaveHeader() {
        if (hdr != undefined) {
            if (CheckEntry() == false) {
                return;
            }
            let obj = GetDataHeader();
            if (obj.ClrNo == '') {
                if (userRights.indexOf('I') < 0) {
                    ShowMessage('You are not allow to add',true);
                    return;
                }
            }
            let jsonString = JSON.stringify({ data: obj });
            //ShowMessage(jsonString);
            $.ajax({
                url: "@Url.Action("SetClrHeader", "Clr")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    if (response.result.data !== '') {
                        $('#txtClrNo').val(response.result.data);
                        ShowData($('#txtBranchCode').val(), $('#txtClrNo').val());
                        ShowMessage(response.result.msg);
                        return;
                    }
                    ShowMessage(response.result.msg,true);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
            return;
        }
        ShowMessage('No data to Save',true);
    }
    function GetDataHeader() {
        let dt = {
            BranchCode : $('#txtBranchCode').val(),
            ClrNo : $('#txtClrNo').val(),
            ClrDate: CDateEN($('#txtClrDate').val()),
            ClearanceDate: CDateEN($('#txtClearanceDate').val()),
            EmpCode: $('#txtEmpCode').val(),
            AdvRefNo: $('#txtAdvRefNo').val(),
            AdvTotal: CNum($('#txtAdvTotal').val()),
            JobType: $('#cboJobType').val(),
            JNo: $('#txtJNo').val(),
            InvNo: $('#txtBookingNo').val(),
            ClearType: $('#cboClrType').val(),
            ClearFrom: $('#cboClrFrom').val(),
            DocStatus: $('#cboDocStatus').val(),
            TotalExpense: CNum($('#txtTotalExpense').val()),
            TRemark: $('#txtTRemark').val(),
            ApproveBy: $('#txtApproveBy').val(),
            ApproveDate: CDateEN($('#txtApproveDate').val()),
            ApproveTime: $('#txtApproveTime').val(),
            ReceiveBy: $('#txtReceiveBy').val(),
            ReceiveDate: CDateEN($('#txtReceiveDate').val()),
            ReceiveTime: $('#txtReceiveTime').val(),
            ReceiveRef: $('#txtReceiveRef').val(),
            CancelReson: $('#txtCancelReson').val(),
            CancelProve: $('#txtCancelProve').val(),
            CancelDate: CDateEN($('#txtCancelDate').val()),
            CancelTime: $('#txtCancelTime').val(),
            CoPersonCode: $('#txtCoPersonCode').val(),
            CTN_NO: $('#txtCTN_NO').val(),
            ClearTotal: CNum($('#txtClearTotal').val()),
            ClearVat: CNum($('#txtVatAmount').val()),
            ClearWht: CNum($('#txtWhtAmount').val()),
            ClearNet: CNum($('#txtNetAmount').val()),
            ClearBill: CNum($('#txtSumCharge').val()),
            ClearCost: CNum($('#txtSumCost').val())
        };

        return dt;
    }
    function ReadClrHeader(dt) {
        if (dt != undefined) {
            hdr = dt;
            //$('#txtBranchCode').val(dt.BranchCode);
            $('#txtClrNo').val(dt.ClrNo);
            $('#txtJNo').val(dt.JNo);
            $('#txtBookingNo').val(dt.InvNo);
            $('#txtAdvRefNo').val(dt.AdvRefNo);

            $('#txtClrDate').val(CDateEN(dt.ClrDate));
            $('#txtClearanceDate').val(CDateEN(dt.ClearanceDate));
            
            $('#txtEmpCode').val(dt.EmpCode);
            $('#txtAdvTotal').val(CDbl(dt.AdvTotal, 2));
            if (isjobmode == false) {
                $('#cboJobType').val(CCode(dt.JobType));
            }
            //Combos
            $('#cboClrType').val(dt.ClearType);
            $('#cboClrFrom').val(dt.ClearFrom);
            $('#cboDocStatus').val(CCode(dt.DocStatus));
            $('#txtTotalExpense').val(CDbl(dt.TotalExpense, 2));
            $('#txtTRemark').val(dt.TRemark);
            $('#txtApproveBy').val(dt.ApproveBy);
            $('#txtApproveDate').val(CDateEN(dt.ApproveDate));
            $('#txtApproveTime').val(ShowTime(dt.ApproveTime));
            $('#txtReceiveBy').val(dt.ReceiveBy);
            $('#txtReceiveDate').val(CDateEN(dt.ReceiveDate));
            $('#txtReceiveTime').val(ShowTime(dt.ReceiveTime));
            $('#txtReceiveRef').val(dt.ReceiveRef);
            $('#txtCancelProve').val(dt.CancelProve);
            $('#txtCancelReson').val(dt.CancelReson);
            $('#txtCancelDate').val(CDateEN(dt.CancelDate));
            $('#txtCancelTime').val(ShowTime(dt.CancelTime));

            $('#txtCTN_NO').val(dt.CTN_NO);
            $('#txtCoPersonCode').val(dt.CoPersonCode);
            $('#txtClearTotal').val(CDbl(dt.ClearTotal, 2));
            $('#txtClrAmount').val(CDbl(dt.ClearNet+dt.ClearWht-dt.ClearVat, 2));
            $('#txtVatAmount').val(CDbl(dt.ClearVat, 2));
            $('#txtWhtAmount').val(CDbl(dt.ClearWht, 2));
            $('#txtNetAmount').val(CDbl(dt.ClearNet, 2));
            $('#txtSumCharge').val(CDbl(dt.ClearBill, 2));
            $('#txtSumCost').val(CDbl(dt.ClearCost,2));

            $('#chkCancel').prop('checked', $('#txtCancelProve').val() == '' ? false : true);
            $('#chkApprove').prop('checked', $('#txtApproveBy').val() == '' ? false : true);
            $('#chkReceive').prop('checked', $('#txtReceiveBy').val() == '' ? false : true);
            
            CallBackQueryUser(path, $('#txtEmpCode').val(), ReadClrBy);
            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');

            if (dt.DocStatus > 2) {
                $('#chkApprove').attr('disabled', 'disabled');                
                //if document paymented/cancelled/cleared then disable save button
                EnableSave(false);
            } else {
                if (dt.DocStatus == 2) {
                    //$('#chkApprove').attr('disabled', 'disabled');
                    EnableSave(false);
                } else {
                    EnableSave(true);
                }
            }
            $('#cboClrType').attr('disabled', 'disabled');
            $('#cboClrFrom').attr('disabled', 'disabled');
            return;
        }
    }
    function EnableSave(b) {
        //$('#btnSave').removeAttr('disabled');
        $('#btnDel').removeAttr('disabled');
        $('#btnUpdate').removeAttr('disabled');
        if (b == false) {
            //$('#chkCancel').attr('disabled', 'disabled');
            //$('#btnSave').attr('disabled', 'disabled');
            $('#btnDel').attr('disabled', 'disabled');
            $('#btnUpdate').attr('disabled', 'disabled');
        }
    }
    function AddHeader() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        $('#txtClrNo').val('');
        ClearHeader();
        ClearDetail();
        $.get(path + 'clr/getnewclearheader?branchcode=' + $('#txtBranchCode').val()).done(function (r) {
            let h = r.clr.header;
            ReadClrHeader(h);
            if (isjobmode == false) {
                $('#cboJobType').val('');
            }
            $('#cboDocStatus').val('01');
            $('#cboClrType').val('1');
            $('#cboClrFrom').val('1');
            $('#txtEmpCode').val(user);
            $('#txtClrDate').val(GetToday());

            $('#cboClrType').removeAttr('disabled');
            $('#cboClrFrom').removeAttr('disabled');

            CallBackQueryUser(path, $('#txtEmpCode').val(), ReadClrBy);
            let d = r.clr.detail;
            ReadClrDetail(d);
            $('#txtClrNo').focus();
        });
    }
    function AddDetail() {
        if ($('#txtClrNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }  
        $('#chkDuplicate').prop('checked', false);
        ClearDetail();
        $.get(path + 'clr/getnewcleardetail?branchcode=' + $('#txtBranchCode').val() + '&clrno=' + $('#txtClrNo').val()).done(function (r) {
            let d = r.clr.detail[0];
            LoadDetail(d);

            $('#frmDetail').modal('show');
            $('#txtSICode').focus();
        });
    }
    function DeleteDetail() {
        if (dtl != undefined) {
            if (userRights.indexOf('D') < 0) {
                ShowMessage('You are not allow to delete',true);
                return;
            }
            if (dtl.LinkBillNo !== '') {
                ShowMessage('Cannot delete');
                return;
            }
            $.get(path + 'clr/delclrdetail?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtClrNo').val() + '&item=' + dtl.ItemNo).done(function (r) {
                ShowMessage(r.clr.result);
                ShowData($('#txtBranchCode').val(), $('#txtClrNo').val());
            });
        } else {
            ShowMessage('No data to delete',true);
        }
    }
    function ClearHeader() {
        hdr = {};
        $('#txtClrDate').val(GetToday());
        $('#txtClearanceDate').val('');
        $('#txtEmpCode').val(user);
        if (isjobmode == false) {
            $('#cboJobType').val('');
        }
        $('#txtCoPersonCode').val('');
        $('#txtCTN_NO').val('');
        $('#txtTRemark').val('');
        $('#txtAdvRefNo').val('');
        $('#txtJNo').val('');
        $('#txtBookingNo').val('');

        $('#txtCancelProve').val('');
        $('#txtCancelReson').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelTime').val('');

        $('#txtReceiveBy').val('');
        $('#txtReceiveDate').val('');
        $('#txtReceiveTime').val('');
        $('#txtReceiveRef').val('');

        $('#txtApproveBy').val('');
        $('#txtApproveDate').val('');
        $('#txtApproveTime').val('');

        $('#txtAdvTotal').val('0.00');
        $('#txtTotalExpense').val('0.00');
        $('#txtClearTotal').val('0.00');

        $('#txtClrAmount').val('0.00');
        $('#txtVatAmount').val('0.00');
        $('#txtWhtAmount').val('0.00');
        $('#txtNetAmount').val('0.00');

        $('#txtSumCharge').val('0.00');
        $('#txtSumCost').val('0.00');

        $('#chkCancel').prop('checked', $('#txtCancelProve').val() == '' ? false : true);
        $('#chkApprove').prop('checked', $('#txtApproveBy').val() == '' ? false : true);
        $('#chkReceive').prop('checked', $('#txtReceiveBy').val() == '' ? false : true);

        $('#chkApprove').removeAttr('disabled');
        $('#chkCancel').removeAttr('disabled');
        //Combos
        $('#cboClrType').val('1');
        $('#cboClrFrom').val('1');
        $('#cboDocStatus').val('01');

        CallBackQueryUser(path, $('#txtEmpCode').val(), ReadClrBy);

        $('#btnPrint').attr('disabled', 'disabled');
        $('#btnAdd').attr('disabled', 'disabled');
        $('#btnDel').attr('disabled', 'disabled');
        $('#btnUpdate').attr('disabled', 'disabled');
                
        if (userRights.indexOf('E') >= 0){
            $('#btnSave').removeAttr('disabled');
            $('#btnUpdate').removeAttr('disabled');
        }
        if (userRights.indexOf('I') >= 0) {
            $('#btnSave').removeAttr('disabled');
            $('#btnUpdate').removeAttr('disabled');
            $('#btnAdd').removeAttr('disabled');
        }
        if (userRights.indexOf('D') >= 0) {
            $('#btnDel').removeAttr('disabled');
        }
        if (userRights.indexOf('P') >= 0) {
            $('#btnPrint').removeAttr('disabled');
        }
        $('#cboClrType').removeAttr('disabled');
        $('#cboClrFrom').removeAttr('disabled');
    }
    function SaveDetail() {

        if (hdr == undefined) {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        if (hdr.ClrNo == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        if ($('#txtForJNo').val() == '') {
            ShowMessage('Please select job number', true);
            $('#txtForJNo').focus();
            return;
        }
        if ($('#txtUnitCode').val() == '') {
            ShowMessage('Please select unit', true);
            $('#txtUnitCode').focus();
            return;
        }
        if ($('#txtSICode').val() == '') {
            ShowMessage('Please select expense code', true);
            $('#txtSICode').focus();
            return;
        }
        if ($('#txtSlipNo').val().length<2 && $('#txtSlipNo').prop('disabled')==false) {
            ShowMessage('Please enter slip number', true);
            $('#txtSlipNo').focus();
            return;
        }
        if ($('#txtDate50Tavi').val() == '' && $('#txtSlipNo').val() !== '') {
            ShowMessage('Please enter date of slip',true);
            $('#txtDate50Tavi').focus();
            return false;
        }
        if (Number($('#txtQty').val()) == 0) {
            ShowMessage('Please check quantity', true);
            return;
        }

        if (dtl != undefined) {
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
            let jsonString = JSON.stringify({ data: obj });
            //ShowMessage(jsonString);
            $.ajax({
                url: "@Url.Action("SetClrDetail", "Clr")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    ShowMessage(response.result.msg);
                    SaveHeader();
                    //ShowData($('#txtBranchCode').val(), $('#txtClrNo').val());
                    if ($('#txtAdvNo').val() !== '' && $('#chkDuplicate').prop('checked') == false) {
                        $('#frmDetail').modal('hide');
                    }
                }
            });
            return;
        }
        ShowMessage('No data to Save',true);
    }

    function ReadClrDetail(dt) {
        let tb=$('#tbDetail').DataTable({
            data:dt,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: null, title: "Edit" },                
                { data: "JobNo", title: "Job" },
                { data: "SICode", title: "Service" },
                { data: "SDescription", title: "Description" },
                { data: "AdvNO", title: "Adv.No" },
                {
                    data: "AdvAmount", title: "Advance",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                {
                    data: "UsedAmount", title: "Clear",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                {
                    data: "ChargeVAT", title: "VAT",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                {
                    data: "Tax50Tavi", title: "WH-Tax",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                {
                    data: "BNet", title: "Net",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                { data: "CurrencyCode", title: "Currency" },
                { data: "SlipNO", title: "Slip No" }
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
            , pageLength: 100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail tbody').on('click', 'tr', function () {
            $('#tbDetail tbody > tr').removeClass('selected');
            $(this).addClass('selected');
            let data = $('#tbDetail').DataTable().row(this).data(); //read current row selected
            ClearDetail();
            LoadDetail(data); //callback function from caller
        });
        $('#tbDetail tbody').on('dblclick', 'tr', function () {
            let data = $('#tbDetail').DataTable().row(this).data(); //read current row selected
            if (data.AdvNO !== '') {
                window.open(path + 'Adv/Index?BranchCode=' + data.BranchCode + '&AdvNo=' + data.AdvNO, '_blank');
            }
        });
        $('#tbDetail tbody').on('click', 'button', function () {
            $('#frmDetail').modal('show');
            $('#txtSICode').focus();
        });
    }
    function GetDataDetail() {
        let dt = {
            BranchCode: $('#txtBranchCode').val(),
            ClrNo: $('#txtClrNo').val(),
            ItemNo: $('#txtItemNo').val(),
            LinkItem: dtl.LinkItem,
            SICode: $('#txtSICode').val(),
            STCode: $('#cboSTCode').val(),
            SDescription: $('#txtSDescription').val(),
            VenderCode: $('#txtVenCode').val(),
            Qty: $('#txtQty').val(),
            UnitCode: $('#txtUnitCode').val(),
            CurrencyCode: $('#txtCurrencyCode').val(),
            CurRate: $('#txtCurRate').val(),
            UnitPrice: $('#chkIsCost').prop('checked') == true ? 0 : $('#txtUnitPrice').val(),
            FPrice: $('#chkIsCost').prop('checked') == true ? 0 : CDbl(Number($('#txtAMT').val()) / Number($('#txtCurRate').val()),2),
            BPrice: $('#chkIsCost').prop('checked') == true ? 0 : CDbl(Number($('#txtAMT').val()), 2),
            QUnitPrice: dtl.QUnitPrice,
            QFPrice: CDbl(CNum(dtl.QUnitPrice) * CNum($('#txtQty').val()), 4),
            QBPrice: CDbl(CNum($('#txtCurRate').val())*CNum(dtl.QUnitPrice) * CNum($('#txtQty').val()), 2),
            UnitCost: $('#txtUnitPrice').val(),
            FCost: CDbl(Number($('#txtAMT').val()) / Number($('#txtCurRate').val()),2),
            BCost: CDbl(Number($('#txtAMT').val()),2),
            ChargeVAT: $('#txtVAT').val(),
            Tax50Tavi: $('#txtWHT').val(),
            AdvNO: $('#txtAdvNo').val(),
            AdvItemNo: $('#txtAdvItemNo').val(),
            AdvAmount: ($('#chkDuplicate').prop('checked') == true ? $('#txtNET').val() : $('#txtAdvAmount').val()),
            UsedAmount: $('#txtAMT').val(),
            IsQuoItem: dtl.IsQuoItem,
            SlipNO: $('#txtSlipNo').val(),
            Remark: $('#txtRemark').val(),
            IsLtdAdv50Tavi:  ($('#chkIsLtdAdv50Tavi').prop('checked') == true ? 1 : 0),
            Pay50TaviTo: $('#txtPayChqTo').val(),
            NO50Tavi: $('#txt50Tavi').val(),
            Date50Tavi: CDateEN($('#txtDate50Tavi').val()),
            VenderBillingNo: $('#txtVenderBillingNo').val(),
            AirQtyStep: dtl.AirQtyStep,
            StepSub: dtl.StepSub,
            LinkBillNo : dtl.LinkBillNo,
            JobNo : $('#txtForJNo').val(),
            VATType : $('#txtVatType').val(),
            VATRate: $('#txtVATRate').val(),
            Tax50TaviRate : $('#txtWHTRate').val(),
            IsDuplicate: ($('#chkDuplicate').prop('checked') == true ? 1 : 0),
            QNo: $('#txtQNo').val(),
            FNet: Number($('#txtNET').val())/Number($('#txtCurRate').val()),
            BNet: $('#txtNET').val()
        };
        return dt;
    }
    function LoadDetail(dt) {
        if (dt != undefined) {
            let r = FindService(dt.SICode);
            ReadService(r);
            dtl = dt;
            $('#txtItemNo').val(dt.ItemNo);
            $('#txtSICode').val(dt.SICode);
            $('#cboSTCode').val(dt.STCode);
            if (isjobmode == false) {
                $('#txtForJNo').val(dt.JobNo);
                $('#txtInvNo').val('');
                if ($('#txtForJNo').val()!= '') {
                    //ShowInvNo(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), '#txtInvNo');
                    CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), ReadJob);
                }
            }
            $('#txtQty').val(dt.Qty);
            $('#txtCurRate').val(dt.CurRate);
            $('#txtUnitPrice').val(dt.UnitCost);
            $('#txtUnitCode').val(dt.UnitCode);
            CalAmount();
            $('#txtRemark').val(dt.Remark);
            $('#txtSlipNo').val(dt.SlipNO);
            $('#txt50Tavi').val(dt.NO50Tavi);
            $('#txtDate50Tavi').val(CDateEN(dt.Date50Tavi));
            $('#txtPayChqTo').val(dt.Pay50TaviTo);
            $('#txtSDescription').val(dt.SDescription);
            $('#txtVatType').val(dt.VATType);
            $('#txtVATRate').val(CDbl(dt.VATRate,0));
            $('#txtWHTRate').val(dt.Tax50TaviRate);
            $('#txtAMT').val(CDbl(dt.UsedAmount,2));
            $('#txtVAT').val(CDbl(dt.ChargeVAT,2));
            $('#txtWHT').val(CDbl(dt.Tax50Tavi,2));
            $('#txtNET').val(CDbl(dt.BNet,2));
            $('#txtVenCode').val(dt.VenderCode);
            $('#chkIsLtdAdv50Tavi').prop('checked', dt.IsLtdAdv50Tavi == 1 ? true : false);
            $('#chkDuplicate').prop('checked', dt.IsDuplicate == 1 ? true : false);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            $('#txtAdvNo').val(dt.AdvNO);
            $('#txtQNo').val(dt.QNo);
            $('#txtAdvItemNo').val(dt.AdvItemNo);
            $('#txtAdvAmount').val(CDbl(dt.AdvAmount, 2));
            $('#txtVenderBillingNo').val(dt.VenderBillingNo);
            $('#txtLinkBillNo').val(dt.LinkBillNo); 
            if ($('#txtLinkBillNo').val() !== '') {
                $('#btnUpdate').attr('disabled', 'disabled');
            }
            $('#txtLinkItem').val(dt.LinkItem);
            ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            ShowCaption();
            return;
        }
    }
    function LoadDetailFromPay(dt) {
        if (dt != undefined) {
            let r = FindService(dt.SICode);
            if (CheckService(r) == false) {
                return;
            }
            dtl = dt;
            $('#txtItemNo').val(dt.ItemNo);
            $('#txtSICode').val(dt.SICode);
            $('#cboSTCode').val(dt.STCode);
            ReadService(r);
            $('#txtForJNo').val(dt.JobNo);
            $('#txtInvNo').val('');
            if ($('#txtForJNo').val() != '') {
                //ShowInvNo(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), '#txtInvNo');
                CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), ReadJob);
            }
            $('#txtQty').val(dt.Qty);
            $('#txtCurRate').val(dt.CurRate);
            $('#txtUnitPrice').val(CDbl(dt.UnitPrice,2));
            $('#txtUnitCode').val(dt.UnitCode);            
            $('#txtRemark').val(dt.Remark);
            $('#txtSlipNo').val(dt.SlipNO);
            $('#txt50Tavi').val(dt.NO50Tavi);
            $('#txtDate50Tavi').val(CDateEN(dt.Date50Tavi));
            $('#txtPayChqTo').val(dt.Pay50TaviTo);
            $('#txtSDescription').val(dt.SDescription);
            $('#txtVatType').val(dt.VATType);
            $('#txtVATRate').val(dt.VATRate);
            $('#txtWHTRate').val(dt.Tax50TaviRate);
            $('#txtAMT').val(CDbl(dt.UnitPrice,2));
            $('#txtVAT').val(CDbl(dt.ChargeVAT,2));
            $('#txtWHT').val(CDbl(dt.Tax50Tavi,2));
            $('#txtNET').val(CDbl(dt.BNet,2));
            $('#txtVenCode').val(dt.VenderCode);
            $('#chkIsLtdAdv50Tavi').prop('checked', dt.IsLtdAdv50Tavi == 1 ? true : false);
            $('#chkDuplicate').prop('checked', dt.IsDuplicate == 1 ? true : false);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            $('#chkIsCost').prop('checked', dt.IsExpense == 1 ? true : false);
            $('#txtAdvNo').val('');
            $('#txtAdvItemNo').val(0);
            $('#txtAdvAmount').val(0);
            $('#txtQNo').val('');
            $('#txtVenderBillingNo').val(dt.VenderBillingNo);
            $('#txtLinkBillNo').val(dt.LinkBillNo); 
            $('#txtLinkItem').val(dt.LinkItem);
            $('#txtCTN_NO').val(dt.RefNo);
            ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            ShowCaption();
            return;
        }
    }
    function LoadDetailFromAdv(dt) {
        if (dt != undefined) {
            let r = FindService(dt.SICode);
            if (CheckService(r) == false) {
                $('#txtSICode').val('');
                $('#txtSDescription').val('');
            } else {
                $('#txtSICode').val(dt.SICode);
                $('#cboSTCode').val(dt.STCode);
                $('#txtSDescription').val(dt.SDescription);
                ReadService(r);
            }
            dtl = dt;
            $('#txtItemNo').val(dt.ItemNo);
            $('#txtForJNo').val(dt.JobNo);
            $('#txtInvNo').val('');
            if ($('#txtForJNo').val() != '') {
                //ShowInvNo(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), '#txtInvNo');
                CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), ReadJob);
            }
            $('#txtQty').val(dt.Qty);
            $('#txtCurRate').val(dt.CurRate);
            $('#txtUnitPrice').val(CDbl(dt.UnitCost,2));
            $('#txtUnitCode').val(dt.UnitCode);            
            $('#txtRemark').val(dt.Remark);
            $('#txtSlipNo').val(dt.SlipNO);
            $('#txt50Tavi').val(dt.NO50Tavi);
            $('#txtDate50Tavi').val(CDateEN(dt.Date50Tavi));
            $('#txtPayChqTo').val(dt.Pay50TaviTo);
            
            $('#txtVatType').val(dt.VATType);
            $('#txtVATRate').val(dt.VATRate);
            $('#txtWHTRate').val(dt.Tax50TaviRate);
            $('#txtAMT').val(CDbl(dt.AdvBalance / CDbl(1 + ((dt.VATRate - dt.Tax50TaviRate) * 0.01),2),2));
            $('#txtVAT').val(CDbl(CNum($('#txtAMT').val())*(dt.VATRate*0.01),2));
            $('#txtWHT').val(CDbl(CNum($('#txtAMT').val())*(dt.Tax50TaviRate*0.01),2));
            $('#txtNET').val(CDbl(CNum($('#txtAMT').val()) + (CNum($('#txtAMT').val()) * (dt.VATRate * 0.01)) - (CNum($('#txtAMT').val()) * (dt.Tax50TaviRate * 0.01)),2));
            $('#txtVenCode').val(dt.VenderCode);
            $('#chkIsLtdAdv50Tavi').prop('checked', dt.IsLtdAdv50Tavi == 1 ? true : false);
            $('#chkDuplicate').prop('checked', dt.IsDuplicate == 1 ? true : false);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            $('#chkIsCost').prop('checked', dt.IsExpense == 1 ? true : false);
            $('#txtAdvNo').val(dt.AdvNO);
            $('#txtAdvItemNo').val(dt.AdvItemNo);
            $('#txtAdvAmount').val(CDbl(dt.AdvBalance,2));
            $('#txtQNo').val(dt.QNo);
            $('#txtVenderBillingNo').val(dt.VenderBillingNo);
            $('#txtLinkBillNo').val(dt.LinkBillNo); 
            $('#txtLinkItem').val(dt.LinkItem);
            ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            ShowCaption();
            return;
        }
    }
    function ClearDetail() {
        dtl = {};
        $('#txtItemNo').val('0');
        $('#txtSICode').val('');
        $('#cboSTCode').val('');
        $('#txtUnitCode').val('');
        if (isjobmode == false) {
            $('#txtForJNo').val('');
            $('#txtInvNo').val('');
            $('#txtQNo').val('');
        }
        $('#txtRemark').val($('#txtCTN_NO').val());
        $('#txt50Tavi').val('');
        $('#txtDate50Tavi').val('');
        $('#txtPayChqTo').val('');
        $('#txtSDescription').val('');
        $('#txtVatType').val('1');
        $('#txtVATRate').val(0);
        $('#txtWHTRate').val(0);
        $('#txtAMT').val(0);
        $('#txtVAT').val(0);
        $('#txtWHT').val(0);
        $('#txtNET').val(0);
        $('#txtQty').val(1);
        $('#txtCurRate').val(1);
        $('#txtUnitPrice').val(0);
        $('#chkIsLtdAdv50Tavi').prop('checked', false);
        $('#txtCurrencyCode').val($('#txtSubCurrency').val());
        $('#txtVenderBillingNo').val('');
        $('#txtLinkBillNo').val(''); 
        $('#txtLinkItem').val('');
        ShowCurrency(path, $('#txtSubCurrency').val(), '#txtCurrencyName');
        ShowCaption();
        $('#txtVenCode').val('');
        if ($('#chkDuplicate').prop('checked') == false) {
            $('#txtAdvNo').val('');
            $('#txtAdvItemNo').val('0');
            $('#txtAdvAmount').val('0');
        }
        $('#txtSlipNo').val('');        
        $('#txtSlipNo').removeAttr('disabled');
        $('#txtAMT').removeAttr('disabled');
        $('#txtVATRate').removeAttr('disabled');
        $('#txtWHTRate').removeAttr('disabled');
        $('#txtVAT').removeAttr('disabled');
        $('#txtWHT').removeAttr('disabled');
        $('#btnAddD').show();
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
    function SetGridClr() {
        let w ='?branchcode='+ $('#txtBranchCode').val();
        if (job.length > 0) {
            w += '&jobno=' + job;
        } else {
            if ($('#txtEmpCode').val() !== '') {
                w += '&clrby='+ $('#txtEmpCode').val();
            }
        }
        if ($('#cboStatus').val() !== '') {
            w += '&status=' + $('#cboStatus').val();
        }
        if ($('#cboClrType').val() > 0) {
            w += '&ctype=' + $('#cboClrType').val();
        }
        $('#dvClrFilter').html(w);
        $.get(path + 'clr/getclearinggrid' +  w).done(function (r) {
            if (r.clr.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.clr.data;
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "ClrNo", title: "Clear No" },
                    {
                        data: "ClrDate", title: "Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "EmpCode", title: "Request By" },
                    { data: "JobNo", title: "Job Number" },
                    { data: "CustInvNo", title: "Cust Inv" },
                    { data: "DocStatus", title: "Status" },
                    {
                        data: "ClrNet", title: "Clr.Total",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "CTN_NO", title: "Container" },
                    { data: "AdvNO", title: "Adv No" },
                    {
                        data: "TotalAdvance", title: "Adv.Total",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "TRemark", title: "Remark" },
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                $('#tbHeader tbody > tr').removeClass('selected');
                $(this).addClass('selected');
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                ShowData(data.BranchCode, data.ClrNo); //callback function from caller
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
            case 'container':
                w = '?Branch=' + $('#txtBranchCode').val();
                if (job !== '') {
                    w += '&Job=' + job;
                }
                SetGridTransport(path, '#tbCont', '#frmSearchCont', w, ReadContainer);
                break;
            case 'clearing':
                SetGridClr();
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'clrby':
                SetGridUser(path, '#tbClr', '#frmSearchClr', ReadClrBy);
                break;
            case 'servicecode':
                let q = GetClrType($('#cboClrType').val());
                if ($('#cboSTCode').val() !== '') {
                    q += '&group=' + $('#cboSTCode').val();
                }
                SetGridSICodeFilter(path, '#tbServ', q, '#frmSearchSICode', ReadService);
                break;
            case 'job':
                SetGridJob(path, '#tbJob', '#frmSearchJob', GetParam(), ReadJob);
                break;
            case 'detcurrency':
                SetGridCurrency(path, '#tbExpCur', '#frmSearchExpCur', ReadCurrencyD);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'servunit':
                SetGridServUnit(path, '#tbUnit', '#frmSearchUnit', ReadUnit);
                break;
            case 'estimate':
                SetGridEstimateCost(path, '#tbEstimate', '?status=NOCLR&type=' + $('#cboClrType').val() + '&Job=' + $('#txtForJNo').val(), '#frmSearchEstimate', ReadEstimate);
                break;
            case 'quotation':
                //let qry = '?branch=' + $('#txtBranchCode').val() + '&cust=' + $('#txtCustCode').val() + '&code=' + $('#txtSICode').val() + '&jtype=' + $('#txtJobType').val() + '&sby=' + $('#txtShipBy').val();
                let qry = '?branch=' + $('#txtBranchCode').val() + '&cust=' + $('#txtCustCode').val();
                if ($('#txtJobType').val() > '0') {
                    qry += '&jtype=' + $('#txtJobType').val();
                }
                if ($('#txtShipBy').val() > '0') {
                    qry += '&sby=' + $('#txtShipBy').val();
                }                
                SetGridQuotation(path, '#tbQuo', qry, '#frmSearchQuo', ReadQuotation);
                break;
        }
    }
    function GetClrType(type) {
        switch (type) {
            case "1":
                return "?type=A";
            case "2":
                return "?type=C";
            case "3":
                return "?type=S";
            default:
                return "";
        }
    }
    function GetClrFrom(type) {
        switch (type) {
            case "1":
                return "&cfrom=MKT";
            case "2":
                return "&cfrom=CS";
            case "3":
                return "&cfrom=SP";
            case "4":
                return "&cfrom=FIN";
            case "5":
                return "&cfrom=ACC";
            case "6":
                return "&cfrom=IT";
            default:
                return "";
        }
    }

    function GetParam() {
        let strParam = '?Status=0,1,2,3,4,5,6';
        strParam += '&Branch=' + $('#txtBranchCode').val();
        strParam += '&JType=' + $('#cboJobType').val().substr(0, 2);
        return strParam;
    }
    function ShowCaption() {
        if (mainLanguage == 'TH') {
            $('#lblUnitPrice').text("ราคา (" + $('#txtCurrencyCode').val() + "):");
            $('#lblAmount').text("ราคารวม (" + $('#txtCurrencyCode').val() + "):");
            $('#lblVATRate').text("ภาษีมูลค่าเพิ่ม (" + $('#txtCurrencyCode').val() + "):");
            $('#lblWHTRate').text("หัก ณ ที่จ่าย (" + $('#txtCurrencyCode').val() + "):");
            $('#lblNETAmount').text("ยอดสุทธิ (" + $('#txtCurrencyCode').val() + "):");
        }
        if (mainLanguage == 'EN') {
            $('#lblUnitPrice').text("Price (" + $('#txtCurrencyCode').val() + "):");
            $('#lblAmount').text("Amount (" + $('#txtCurrencyCode').val() + "):");
            $('#lblVATRate').text("VAT (" + $('#txtCurrencyCode').val() + "):");
            $('#lblWHTRate').text("WHT (" + $('#txtCurrencyCode').val() + "):");
            $('#lblNETAmount').text("Net (" + $('#txtCurrencyCode').val() + "):");
        }
    }
    function ReadUnit(dt) {
        $('#txtUnitCode').val(dt.UnitType);
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        $('#txtPayChqTo').val(dt.TName);
        $('#txtPayChqTo').focus();
    }
    function ReadCurrencyD(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
        $('#txtCurRate').val(1);
        CalAmount();
        ShowCaption();
        $('#txtCurRate').focus();
    }
    function ReadCurrencyH(dt) {
        $('#txtSubCurrency').val(dt.Code);
        $('#txtExchangeRate').focus();
    }
    function ReadClrBy(dt) {
        $('#txtEmpCode').val(dt.UserID);
        $('#txtEmpName').val(dt.TName);
        $('#cboClrFrom').val(dt.DeptID);
        //$('#txtEmpCode').focus();
    }
    function ReadContainer(dt) {
        job = dt.JNo;
        SetJob();
        $('#txtCTN_NO').val(dt.CTN_NO);
        $('#txtJNo').val(dt.JNo);
        $('#txtBookingNo').val(dt.BookingNo);
        $('#txtCoPersonCode').val(dt.Driver);
        $('#txtTRemark').val(dt.Location);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadService(dt) {
        $('#txtSICode').focus();
        if (dt != undefined) {
            $('#txtSICode').val(dt.SICode);
            $('#cboSTCode').val(dt.GroupCode);
            $('#txtSDescription').val(dt.NameEng);
            $('#txtVatType').val(dt.IsTaxCharge);
            $('#txtVATRate').val(dt.IsTaxCharge == "0" ? "0" : CDbl(@ViewBag.PROFILE_VATRATE*100,0));
            $('#txtWHTRate').val(dt.Is50Tavi == "0" ? "0" : dt.Rate50Tavi);
            $('#txtUnitCode').val(dt.UnitCharge);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            ShowCurrency(path, dt.CurrencyCode, '#txtCurrencyName');
            ShowCaption();
            //$('#txtVenCode').val(dt.DefaultVender);
            ShowVender(path, dt.DefaultVender, '#txtPayChqTo');
            /*
            if (dt.IsTaxCharge == "2") {
                $('#txtAMT').attr('disabled', 'disabled');
                $('#txtVATRate').attr('disabled', 'disabled');
                $('#txtWHTRate').attr('disabled', 'disabled');
                $('#txtVAT').attr('disabled', 'disabled');
                $('#txtWHT').attr('disabled', 'disabled');
            } else {
                $('#txtAMT').removeAttr('disabled');
                $('#txtVATRate').removeAttr('disabled');
                $('#txtWHTRate').removeAttr('disabled');
                $('#txtVAT').removeAttr('disabled');
                $('#txtWHT').removeAttr('disabled');
            }
            */
            $('#chkIsCost').prop('checked', dt.IsExpense == 1 ? true : false);
            if (dt.IsHaveSlip == 0) {
                $('#txtSlipNo').attr('disabled', 'disabled');
            } else {
		$('#txtSlipNo').removeAttr('disabled');
            }
            CalVATWHT();
            return;
        }
        //$('#txtSDescription').val('');
        $('#txtVatType').val(1);
        $('#txtVATRate').val(0);
        $('#txtWHTRate').val(0);
        /*
        $('#txtAMT').removeAttr('disabled');
        $('#txtVATRate').removeAttr('disabled');
        $('#txtWHTRate').removeAttr('disabled');
        $('#txtVAT').removeAttr('disabled');
        $('#txtWHT').removeAttr('disabled');
        */
        CalVATWHT();
    }
    function ReadJob(r) {
        let dt = r;
        if (r.length > 0) {
            dt = r[0];
        }
        if (dt.JobStatus == 99) {
            ShowMessage('This job has been cancelled', true);
        } else {
            $('#txtForJNo').val(dt.JNo);
            $('#txtInvNo').val(dt.InvNo);
            $('#txtQNo').val(dt.QNo);
            $('#txtCustCode').val(dt.CustCode);
            $('#txtCustBranch').val(dt.CustBranch);
            $('#txtJobType').val(dt.JobType);
            $('#txtShipBy').val(dt.ShipBy);
            ShowCustomer(path, dt.CustCode, dt.CustBranch, '#txtCustName');
        }
        $('#txtForJNo').focus();
    }
    
    function GetTotal() {
        return CDbl(CNum($('#txtTotalClear').val()) / CNum($('#txtExchangeRate').val()) ,2);
    }
    function CalAmount() {
        $('#txtAMT').val(0);
        $('#txtNET').val(0);
        $('#txtVAT').val(0);
        $('#txtWHT').val(0);

        let price = CDbl($('#txtUnitPrice').val(),4);
        let qty = CDbl($('#txtQty').val(),4);
        let rate = CDbl($('#txtCurRate').val(),4); //rate ของ detail
        let type = $('#txtVatType').val();
        if (type == '' || type == '0') type = '1';
        if (qty > 0) {
            let amt = CNum(qty) * CNum(price);
            //let exc = CDbl($('#txtExchangeRate').val(), 4); //rate ของ header
            //let total = CDbl(CNum(amt) / CNum(exc),4);
            if (type == '2') {
                //$('#txtNET').val(CDbl(CNum(total),4));
                $('#txtNET').val(CDbl(CNum(amt) * CNum(rate), 4));
            }
            if (type == '1') {
                //$('#txtAMT').val(CDbl(CNum(total),4));
                $('#txtAMT').val(CDbl(CNum(amt) * CNum(rate),2));
            }
            CalVATWHT();
        }           
    }
    function CalTotal() {
        let amt = CDbl($('#txtAMT').val(),3);
        let vat = CDbl($('#txtVAT').val(),3);
        let wht = CDbl($('#txtWHT').val(),3);

        $('#txtNET').val(CDbl(CNum(amt) + CNum(vat) - CNum(wht),2));
        $('#txtAMT').val(CDbl(amt,2));
    }
    function CalVATWHT() {
        let type = $('#txtVatType').val();
        if (type == ''||type=='0') type = '1';
        let amt = CDbl($('#txtAMT').val(),4);
        if (type == '2') {
            amt = CDbl(CNum($('#txtNET').val()) + CNum($('#txtWHT').val()), 4);
        }
        let vatrate = CDbl($('#txtVATRate').val(),4);
        let whtrate = CDbl($('#txtWHTRate').val(),4);
        let vat = 0;
        let wht = 0;
        if (type == "2") {
            //let base = amt * 100 / (100 + (vatrate - whtrate));
            let base = amt * 100 / (100 + Number(vatrate));
            vat = base * vatrate * 0.01;
            wht = base * whtrate * 0.01;
            $('#txtAMT').val(CDbl(CNum(base),2));
            $('#txtNET').val(CDbl(CNum(base) + CNum(vat) - CNum(wht), 2));
        }
        if (type == "1") {
            vat = amt * vatrate * 0.01;
            wht = amt * whtrate * 0.01;
        }
        $('#txtVAT').val(CDbl(vat,3));
        $('#txtWHT').val(CDbl(wht,3));
        CalTotal();
    }
    function LoadAdvance() {
        if ($('#txtClrNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }  
        let jtype = $('#cboJobType').val();
        let branch = $('#txtBranchCode').val();
        if (job !== "") {
            jtype += '&jobno=' + job;
        }
        var advclick = 0;
        //$.get(path + 'Clr / GetAdvForClear ? branchcode = '+branch+' & jtype=' + jtype + GetClrFrom(cfrom), function (r) {
        $.get(path + 'Clr/GetAdvForClear?branchcode=' + branch + '&jtype=' + jtype).done(function (r) {
            if (r.clr.data.length > 0) {
                let d = r.clr.data;
                $('#tbAdvance').DataTable({
                    data: d,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: "AdvNO", title: "Adv.No" },
                        {
                            data: "AdvDate", title: "Adv.Date",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        },
                        { data: "ItemNo", title: "#" },
                        { data: "SICode", title: "Code" },
                        { data: "SDescription", title: "Expense Name" },
                        { data: "JobNo", title: "Job" },
                        { data: "CurrencyCode", title: "Currency" },
                        { data: "CurRate", title: "Rate" },
                        { data: "Qty", title: "Qty" },
                        { data: "UnitCode", title: "Unit" },
                        {
                            data: "AdvBalance", title: "Balance",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "UsedAmount", title: "Used",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                    ],
                    responsive:true,
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                $('#tbAdvance tbody').on('click', 'tr', function () {
                    if (advclick == 0) {
                        advclick = 1;
                        $('#tbAdvance tbody > tr').removeClass('selected');
                        $(this).addClass('selected');

                        let dt = $('#tbAdvance').DataTable().row(this).data(); //read current row selected

                        dt.BranchCode = $('#txtBranchCode').val();
                        dt.ClrNo = $('#txtClrNo').val();
                        dtl = dt;
                        $('#frmAdvance').modal('hide');
                        ClearDetail();
                        LoadDetailFromAdv(dt);
                        $('#frmDetail').modal('show');

                    }
                });
                $('#frmAdvance').modal('show');
            } else {
                ShowMessage("Not found data for clear",true);
            }
        });
    }
    function ReadEstimate(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#cboSTCode').val('QUO');
        $('#txtSDescription').val(dt.SDescription);
        $('#txtVatType').val(dt.IsTaxCharge);
        $('#txtVATRate').val(dt.AmtVatRate);
        $('#txtWHTRate').val(dt.AmtWhtRate == "0" ? "0" : dt.AmtWhtRate);
        if (dt.IsTaxCharge == "2") {
            $('#txtAMT').attr('disabled', 'disabled');
            $('#txtVATRate').attr('disabled', 'disabled');
            $('#txtWHTRate').attr('disabled', 'disabled');
            $('#txtVAT').attr('disabled', 'disabled');
            $('#txtWHT').attr('disabled', 'disabled');
        } else {
            $('#txtAMT').removeAttr('disabled');
            $('#txtVATRate').removeAttr('disabled');
            $('#txtWHTRate').removeAttr('disabled');
            $('#txtVAT').removeAttr('disabled');
            $('#txtWHT').removeAttr('disabled');
        }
        $('#txtCurrencyCode').val(dt.CurrencyCode);
        ShowCurrency(path, dt.CurrencyCode, '#txtCurrencyName');
        $('#txtCurRate').val(dt.ExchangeRate);
        $('#txtUnitPrice').val(CDbl(dt.AmountCharge, 2));
        $('#txtQty').val(CNum(dt.Qty));
        $('#txtUnitCode').val(dt.QtyUnit);
        $('#txtVenCode').val(dt.VenderCode);
        ShowVender(path, dt.VenderCode, '#txtPayChqTo');
        CalAmount();
    }
    function ReadQuotation(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#cboSTCode').val('QUO');
        $('#txtSDescription').val(dt.DescriptionThai);
        $('#txtVatType').val(dt.Isvat);
        $('#txtVATRate').val(dt.VatRate);
        $('#txtWHTRate').val(dt.IsTax == "0" ? "0" : dt.TaxRate);
        if (dt.Isvat == "2") {
            $('#txtAMT').attr('disabled', 'disabled');
            $('#txtVATRate').attr('disabled', 'disabled');
            $('#txtWHTRate').attr('disabled', 'disabled');
            $('#txtVAT').attr('disabled', 'disabled');
            $('#txtWHT').attr('disabled', 'disabled');
        } else {
            $('#txtAMT').removeAttr('disabled');
            $('#txtVATRate').removeAttr('disabled');
            $('#txtWHTRate').removeAttr('disabled');
            $('#txtVAT').removeAttr('disabled');
            $('#txtWHT').removeAttr('disabled');
        }
        $('#txtCurrencyCode').val(dt.CurrencyCode);
        ShowCurrency(path, dt.CurrencyCode, '#txtCurrencyName');
        $('#txtCurRate').val(dt.CurrencyRate);
        $('#txtUnitPrice').val(CDbl(dt.ChargeAmt,2));
        $('#txtUnitCode').val(dt.UnitCheck);            
        $('#txtVenCode').val(dt.VenderCode);           
        ShowVender(path, dt.VenderCode, '#txtPayChqTo');
        CalAmount();
    }
    function LoadPayment() {
        if ($('#txtClrNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }        
        let branch = $('#txtBranchCode').val();
        let w = '';

        switch ($('#cboClrType').val()) {
            case '1':
                w = '&type=ADV';
                break;
            case '2':
                w = '&type=COST';
                break;
            case '3':
                w = '&type=SERV';
                break;
        }
        if (job !== "") {
            w += '&jobno=' + job;
        }
        var payclick = 0;
        $.get(path + 'Clr/GetPaymentForClear?branch=' + branch + w).done(function (r) {
            if (r.clr.data.length > 0) {
                //let d = r.clr.data;
                let d = $("#txtCTN_NO").val() == "N/A" ? r.clr.data : r.clr.data.filter(data => data.RefNo == $("#txtCTN_NO").val());
               // { data: "ItemNo", title: "#" },
                $('#tbPayment').DataTable({
                    data: d,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column

                        { data: "VenderBillingNo", title: "Payment.No" },
                        {
                            data: "VenderBillDate", title: "Due.Date",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        },
                      
                        { data: "RefNo", title: "Container" },
                        {
                            data: "SICode", title: "Code"
                        },
                        {
                            data: "SDescription", title: "Expense Name"                            
                        },
                        { data: "JobNo", title: "Job" },
                        { data: "CurrencyCode", title: "Currency" },
                        { data: "CurRate", title: "Rate" },
                        { data: "Qty", title: "Qty" },
                        { data: "UnitCode", title: "Unit" },
                        {
                            data: "BNet", title: "Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "Tax50Tavi", title: "WHT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                    ],
                    responsive:true,
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                $('#tbPayment tbody').on('click', 'tr', function () {
                    if (payclick == 0) {
                        payclick = 1;
                        $('#tbPayment tbody > tr').removeClass('selected');
                        $(this).addClass('selected');

                        let dt = $('#tbPayment').DataTable().row(this).data(); //read current row selected

                        dt.BranchCode = $('#txtBranchCode').val();
                        dt.ClrNo = $('#txtClrNo').val();
                        dtl = dt;
                        $('#frmPayment').modal('hide');
                        ClearDetail();
                        LoadDetailFromPay(dt);
                        $('#frmDetail').modal('show');
                    }
                });
                $('#frmPayment').modal('show');
            } else {
                ShowMessage("Not found data for payment",true);
            }
        });
    }
    function PrepareData() {
        loadServiceGroupForClear(path, '#cboSTCode', $('#cboClrType').val());
    }
    function ShowVenderBill() {
        if ($('#txtVenderBillingNo').val() !== '') {
            let doc = $('#txtVenderBillingNo').val().split('#')[0];
            window.open(path + 'Acc/Expense?BranchCode=' + $('#txtBranchCode').val() + '&DocNo=' + doc, '_blank');
        }
    }
    
</script>