
@Code
    ViewBag.Title = "Advance Information"
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
                <label id="lblAdvNo">Advance No:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtAdvNo" style="font-weight:bold;font-size:20px;text-align:center;background-color:navajowhite;color:brown" tabindex="1" />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('advance')" />
                </div>
            </div>
            <div class="col-sm-3">
                <label id="lblAdvDate">Request Date :</label>
                <br />
                <input type="date" class="form-control" id="txtAdvDate" tabindex="1" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <ul class="nav nav-tabs">
                    <li class="active"><a id="linkHeader" data-toggle="tab" href="#tabHeader">Advance Header</a></li>
                    <li><a id="linkDetail" data-toggle="tab" href="#tabDetail">Advance Detail</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tabHeader" class="tab-pane fade in active" style="width:100%">
                        <div class="row">
                            <div class="col-sm-7">
                                <table>
                                    <tr>
                                        <td>
                                            *<label id="lblAdvBy">Advance By :</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtAdvBy" class="form-control" style="width:120px" tabindex="2" />
                                            <button id="btnBrowseEmp1" class="btn btn-default" onclick="SearchData('advby')">...</button>
                                            <input type="text" id="txtAdvName" class="form-control" style="width:100%" disabled />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            *<label id="lblReqBy">Request By :</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtReqBy" class="form-control" style="width:120px" tabindex="3" />
                                            <button id="btnBrowseEmp2" class="btn btn-default" onclick="SearchData('reqby')">...</button>
                                            <input type="text" id="txtReqName" class="form-control" style="width:100%" disabled />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            *<label id="lblAdvFor">Advance For :</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtCustCode" class="form-control" style="width:130px" tabindex="4" />
                                            <input type="text" id="txtCustBranch" class="form-control" style="width:70px" tabindex="5" />
                                            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                                            <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <label id="lblWHTaxNo">WH-Tax No:</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtDoc50Tavi" class="form-control" style="width:100%" tabindex="6" />
                                            <button id="btnAddWHTax" class="btn btn-default" onclick="AutoGenWHTax()">Add</button>
                                        </td>
                                        <td>
                                            <label id="lblPaymentNo">Bill A/P:</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtPaymentNo" class="form-control" style="width:200px" tabindex="7" disabled />
                                            <button id="btnBrowsePay" class="btn btn-default" onclick="SearchData('payment')">...</button>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-sm-5">
                                <table>
                                    <tr>
                                        <td>
                                            <label id="lblJobType">Job Type :</label>
                                        </td>
                                        <td>
                                            <select id="cboJobType" style="width:200px" class="form-control dropdown" tabindex="8" onchange="CheckJobType()"></select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label id="lblShipBy">Ship By :</label>
                                        </td>
                                        <td>
                                            <select id="cboShipBy" style="width:200px" class="form-control dropdown" tabindex="9"></select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label id="lblStatus">Status :</label>
                                        </td>
                                        <td>
                                            <select id="cboDocStatus" style="width:200px;" class="form-control dropdown" disabled></select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label id="lblPayChqDate">Operation Date :</label>
                                        </td>
                                        <td>
                                            <input type="date" class="form-control" id="txtPayChqDate" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-7">
                                <label id="lblAdvType">Advance Type:</label>
                                <select id="cboAdvType" class="form-control dropdown" style="width:100%" tabindex="10"></select>
                                <br />
                                <label id="lblRemark">Remark:</label>
                                <textarea id="txtTRemark" class="form-control-lg" style="width:100%;height:80px" tabindex="11"></textarea>
                            </div>
                            <div class="col-sm-5">
                                <table>
                                    <tr>
                                        <td>
                                            <label id="lblCurrency">Request Currency:</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtSubCurrency" style="width:100%" value="@ViewBag.PROFILE_CURRENCY" disabled />
                                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('subcurrency')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <label id="lblPayTotal">Payment Total:</label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="checkbox" id="chkCash" />
                                            <label id="lblCash" for="chkCash">Cash</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtAdvCash" class="form-control" style="width:100%;text-align:right" disabled />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="checkbox" id="chkChqCash" />
                                            <label id="lblChqCash" for="chkChqCash">Transfer</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtAdvChqCash" class="form-control" style="width:100%;text-align:right" disabled />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="checkbox" id="chkChq" />
                                            <label id="lblChq" for="chkChq">Cheque</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtAdvChq" class="form-control" style="width:100%;text-align:right" disabled />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <input type="checkbox" id="chkCred" />
                                            <label id="lblCred" for="chkCred">Credit</label>
                                        </td>
                                        <td style="display:flex;flex-direction:row">
                                            <input type="text" id="txtAdvCred" class="form-control" style="width:100%;text-align:right" disabled />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4" style="border-style:solid;border-width:1px">
                                <input type="checkbox" id="chkApprove" />
                                <label id="lblApproveBy" for="chkApprove">Approve By</label>
                                <br />
                                <input type="text" id="txtApproveBy" style="width:250px" disabled />
                                <br />
                                <label id="lblApproveDate">Date:</label>
                                <input type="date" id="txtApproveDate" disabled />
                                <label id="lblApproveTime">Time:</label>
                                <input type="text" id="txtApproveTime" style="width:80px" disabled />
                            </div>
                            <div class="col-sm-4" style="border-style:solid;border-width:1px">
                                <input type="checkbox" id="chkPayment" disabled />
                                <label id="lblPaymentBy" for="chkPayment">Payment By</label>
                                <input type="text" id="txtPaymentBy" style="width:250px" disabled />
                                <br />
                                <label id="lblPaymentDate">Date:</label>
                                <input type="date" id="txtPaymentDate" disabled />
                                <label id="lblPaymentTime">Time:</label>
                                <input type="text" id="txtPaymentTime" style="width:80px" disabled />
                                <br />
                                <label id="lblPaymentRef">Payment Ref:</label>
                                <input type="text" id="txtPaymentRef" style="width:200px" disabled />
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
                            <a href="#" class="btn btn-warning" id="btnClear" onclick="PrintClear()">
                                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkClear">Print Clearing</b>
                            </a>
                        </div>
                    </div>
                    <div id="tabDetail" class="tab-pane fade">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddDetail()">
                                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Detail</b>
                                </a>
                                <table id="tbDetail" class="table table-responsive">
                                    <thead>
                                        <tr>
                                            <th>
                                            <th class="desktop">SICode</th>
                                            <th class="all">Description</th>
                                            <th class="desktop">Job No</th>
                                            <th class="desktop">Currency</th>
                                            <th class="desktop">Rate</th>
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
                            <div class="col-sm-9">
                                <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteDetail()">
                                    <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDel">Delete Detail</b>
                                </a>
                                <label id="lblMainCurr">Main Currency:</label>
                                <input type="text" id="txtMainCurrency" style="width:50px" value="@ViewBag.PROFILE_CURRENCY" disabled />
                                <label id="lblExcRate">Exchange Rate:</label>
                                <input type="text" id="txtExchangeRate" style="width:50px" value="1" />
                                <button id="btnGetExcRate" class="btn btn-success" onclick="GetExchangeRate()">Get Rate</button>
                            </div>
                            <div class="col-sm-3" style="text-align:right">
                                <label id="lblAdvAmount">Amount</label>
                                :
                                <input type="text" id="txtAdvAmount" style="width:100px;text-align:right" /><br />
                                <label id="lblVatAmount">VAT</label>
                                :
                                <input type="text" id="txtVatAmount" style="width:100px;text-align:right" /><br />
                                <label id="lblWhtAmount">WHT</label>
                                :
                                <input type="text" id="txtWhtAmount" style="width:100px;text-align:right" />
                                <br />
                                <label id="lblTotalAmount">Total</label>
                                :
                                <input type="text" id="txtTotalAmount" style="width:100px;text-align:right" />
                            </div>
                        </div>
                        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint2">Print Document</b>
                        </a>
                    </div>
                    <div id="frmDetail" class="modal fade" role="dialog">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-sm-2">
                                            <label id="lblItemNo" for="txtItemNo">No :</label>
                                            <input type="text" id="txtItemNo" class="form-control" disabled />
                                        </div>
                                        <div class="col-sm-6">
                                            <label id="lblSTCode">Service Type</label>
                                            <div style="display:flex">
                                                <select id="cboSTCode" class="form-control dropdown"></select>
                                                <input type="button" id="btnBrowseS" class="btn btn-default" value="Estimate" onclick="SearchData('estimate')" />
                                            </div>                                                                                        
                                        </div>
                                        <div class="col-sm-4">
                                            <label id="lblDuplicate" for="chkDuplicate">Can Partial Clear</label><br />
                                            <input type="checkbox" id="chkDuplicate" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <a href="../Master/ServiceCode" target="_blank"><label id="lblSICode">Service Code</label></a>
                                            <div style="display:flex">
                                                <input type="text" id="txtSICode" class="form-control" tabindex="12" />
                                                <input type="button" id="btnBrowseS" class="btn btn-default" value="..." onclick="SearchData('servicecode')" />
                                            </div>
                                        </div>
                                        <div class="col-sm-8">
                                            <label id="lblSDescription">Advance Description</label><br />
                                            <input type="text" id="txtSDescription" class="form-control" tabindex="13" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-5">
                                            <label id="lblForJNo" for="txtForJNo">Job No :</label>
                                            <div style="display:flex">
                                                <input type="text" id="txtForJNo" class="form-control" tabindex="14" />
                                                <input type="button" id="btnBrowseJ" value="..." onclick="SearchData('job')" />
                                            </div>
                                        </div>
                                        <div class="col-sm-7">
                                            <label id="lblCustInv">Cust.Inv :</label>
                                            <div style="display:flex">
                                                <input type="text" id="txtInvNo" class="form-control" disabled />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <a href="../Master/Currency" target="_blank"><label id="lblCurrencyCode">Currency</label></a>
                                            <div style="display:flex">
                                                <input type="text" id="txtCurrencyCode" class="form-control" style="width:100px" tabindex="15" />
                                                <input type="button" id="btnBrowseCur" class="btn btn-default" value="..." onclick="SearchData('detcurrency')" />
                                                <input type="text" id="txtCurrencyName" class="form-control" style="width:100%" disabled />
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <label id="lblRate" for="txtExcRate">Rate :</label>
                                            <div style="display:flex">
                                                <input type="text" id="txtDetCurrency" class="form-control" style="width:100px" disabled />
                                                <input type="text" id="txtExcRate" class="form-control" style="width:100%;text-align:right" tabindex="16" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <label id="lblQty" for="txtAdvQty">Qty:</label>
                                            <br />
                                            <input type="text" id="txtAdvQty" class="form-control" style="text-align:right" tabindex="17" />
                                        </div>
                                        <div class="col-sm-3">
                                            <label id="lblUnitPrice" for="txtUnitPrice" style="color:red">Price :</label>
                                            <br />
                                            <input type="text" id="txtUnitPrice" class="form-control" style="color:red;font-weight:bold;text-align:right;background-color:lightyellow" tabindex="18" />
                                        </div>
                                        <div class="col-sm-3">
                                            <label id="lblAMTCal" for="txtAMTCal">Amount :</label>
                                            <br />
                                            <input type="text" id="txtAMTCal" class="form-control" style="text-align:right" disabled />
                                        </div>
                                        <div class="col-sm-3">
                                            <label id="lblAmount" for="txtAmount">Amount :</label>
                                            <br />
                                            <input type="text" id="txtAMT" class="form-control" style="text-align:right" tabindex="19" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-5">
                                            <label id="lblVATRate" for="txtVATRate">VAT Rate:</label>
                                            <div style="display:flex">
                                                <input type="text" id="txtVATRate" class="form-control" style="text-align:right" tabindex="20" />
                                                <select id="txtVatType" class="form-control dropdown" disabled>
                                                    <option value="0">NO</option>
                                                    <option value="1">EX</option>
                                                    <option value="2">IN</option>
                                                </select>
                                                <input type="text" id="txtVAT" class="form-control" style="text-align:right" tabindex="21" />
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <label id="lblWHTRate" for="txtWHTRate">WHT :</label>
                                            <br />
                                            <div style="display:flex">
                                                <input type="text" id="txtWHTRate" class="form-control" style="text-align:right" tabindex="22" />
                                                <input type="text" id="txtWHT" class="form-control" style="text-align:right" tabindex="23" />
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <label id="lblNETAmount" for="txtNETAmount" style="color:blue">Net Amount :</label>
                                            <br />
                                            <input type="text" id="txtNET" class="form-control" style="color:darkblue;font-weight:bold;text-align:right;background-color:lightgreen" tabindex="24" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <label id="lblWTNo">WH-Tax No :</label>
                                            <br />
                                            <div style="display:flex">
                                                <input type="text" id="txt50Tavi" class="form-control" tabindex="25" />
                                            </div>
                                        </div>
                                        <div class="col-sm-8">
                                            <label id="lblVenCode">Pay To Vender :</label>
                                            <br />
                                            <div style="display:flex">
                                                <input type="text" id="txtVenCode" class="form-control" style="width:100px" tabindex="26" />
                                                <input type="button" id="btnBrowseVen" onclick="SearchData('vender')" value="..." />
                                                <input type="text" id="txtPayChqTo" class="form-control" tabindex="27" />
                                            </div>
                                        </div>
                                    </div>
                                    <label id="lblDRemark">Remark :</label>
                                    <textarea id="txtRemark" style="width:100%;height:80px" tabindex="28"></textarea>
                                </div>
                                <div class="modal-footer">
                                    <div style="float:left">
                                        <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddDetail()">
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
                                    <select id="cboStatus" class="form-control dropdown" onchange="SetGridAdv()"></select>
                                    <br />
                                    <table id="tbHeader" class="table table-responsive">
                                        <thead>
                                            <tr>
                                                <th>AdvNo</th>
                                                <th class="all">AdvDate</th>
                                                <th class="desktop">CustCode</th>
                                                <th class="desktop">ReqBy</th>
                                                <th>Job</th>
                                                <th class="desktop">Inv No</th>
                                                <th class="desktop">Status</th>
                                                <th class="all">Amount</th>
                                                <th class="all">WT</th>
                                                <th class="desktop">WTDoc</th>
                                                <th class="desktop">APDoc</th>
                                                <th class="desktop">Remark</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <div id="dvAdvFilter" style="float:left">
                                    </div>
                                    <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                                </div>
                            </div>
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
    const userRights = '@ViewBag.UserRights';
    let serv = []; //must be array of object
    let hdr = {}; //simple object
    let dtl = {}; //simple object
    let job = '';
    let isjobmode = false;
    let chkmode = false;
    let jt = '';
    //$(document).ready(function () {
    SetLOVs();
    SetEvents();
    SetEnterToTab();
    CheckParam();
    //});
    function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
        return;
    }
    function CheckParam() {
        ClearHeader();
        //read query string parameters
        let br = getQueryString('BranchCode');
        if (br.length>0) {
            $('#txtBranchCode').val(br);
            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            let ano = getQueryString('AdvNo');
            if (ano.length > 0) {
                $('#txtAdvNo').val(ano);
                ShowData(br, $('#txtAdvNo').val());
            } else {
                job = getQueryString('JNo');
                if (job.length > 0) {
                    isjobmode = true;
                    $('#dvJob').html('<h4>***For Job ' + job.toUpperCase() + '***</h4>');
                    $('#txtAdvNo').attr('disabled', 'disabled');
                    CallBackQueryJob(path, $('#txtBranchCode').val(), job, LoadJob);
                }
            }

        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
        $('#txtAdvDate').val(GetToday());
    }
    function LoadJob(dt) {
        if (dt.length > 0) {
            let dr = dt[0];
            $('#txtForJNo').val(dr.JNo);
            $('#txtCustCode').val(dr.CustCode);
            $('#txtCustBranch').val(dr.CustBranch);
            $('#txtInvNo').val(dr.InvNo);
            $('#cboJobType').val(CCode(dr.JobType));
            $('#cboShipBy').val(CCode(dr.ShipBy));
            $('#cboDocStatus').val('01');

            ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');

            $('#txtCustCode').attr('disabled', 'disabled');
            $('#txtCustBranch').attr('disabled', 'disabled');
            $('#btnBrowseCust').attr('disabled', 'disabled');
            $('#txtForJNo').attr('disabled', 'disabled');
            $('#btnBrowseJ').attr('disabled', 'disabled');
            $('#cboJobType').attr('disabled', 'disabled');
            $('#cboShipBy').attr('disabled', 'disabled');

            $('#txtAdvBy').val(user);
            ShowUser(path, $('#txtAdvBy').val(), '#txtAdvName');

            $('#txtAdvBy').focus();
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
    function CalPayment(id) {
        let val = GetTotal();
        if (val < 0) {
            ShowMessage('Advance amount is not balance',true);
            $('#txtAdv' + id.substr(3)).val(0);
            $('#txtAdv' + id.substr(3)).attr('disabled', 'disabled');
            $('#chk' + id.substr(3)).checked = false;
            return;
        }
        $('#txtAdv' + id.substr(3)).val(val);
        $('#txtAdv' + id.substr(3)).removeAttr('disabled');
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
        $('#cboSTCode').on('change', function () {
            if ($('#cboSTCode').val() == '') {
                $('#txtSICode').val('');
                $('#txtSDescription').val('');

                $('#txtSICode').attr('disabled', 'disabled');
                //$('#txtSDescription').attr('disabled', 'disabled');
                $('#chkDuplicate').prop('checked', true);
                return;
            }
            $('#chkDuplicate').prop('checked', false);
            $('#txtSICode').removeAttr('disabled');
            $('#txtSDescription').removeAttr('disabled');
        });
        $('#chkCash,#chkChq,#chkChqCash,#chkCred').on('click', function () {
            let id = this.id;
            let chk = this.checked;
            if (this.checked == false) {
                $('#txtAdv' + id.substr(3)).val(0);
                $('#txtAdv' + id.substr(3)).attr('disabled', 'disabled');
                return;
            }
            CalPayment(this.id);
            return;
        });
        $('#txtAdvCash,#txtAdvChq,#txtAdvChqCash,#txtAdvCred').keydown(function (e) {
            if (e.which == 13) {
                if (GetTotal() < 0) {
                    ShowMessage('Advance amount is not balance',true);
                    $('#' + this.id).val(0);
                }
                let amt = $('#' + this.id).val();
                $('#chk' + this.id.substr(6)).prop('checked', amt > 0 ? true : false);
            }
        });
        $('#txtAdvCash,#txtAdvChq,#txtAdvChqCash,#txtAdvCred').on('blur', function () {
            let amt = $('#' + this.id).val();
            if (amt > 0) {
                if ($('#chk' + this.id.substr(6)).prop('checked') == false) {
                    $('#' + this.id).val(0);
                    $('#' + this.id).attr('disabled', 'disabled');
                } else {
                    if (GetTotal() < 0) {
                        $('#' + this.id).val(0);
                        $('#chk' + this.id.substr(6)).prop('checked', false);
                        $('#' + this.id).attr('disabled', 'disabled');
                        ShowMessage('Advance amount is not balance',true);
                    }
                }
                return;
            }
            $('#' + this.id).attr('disabled', 'disabled');
            $('#chk' + this.id.substr(6)).prop('checked', false);
        });
        $('#chkApprove').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ADV', 'Approve',(chkmode ? 'I':'D'), SetApprove);
        });
        $('#chkCancel').on('click', function () {
            chkmode = this.checked;
            if (chkmode == true && $('#cboDocStatus').val().substr(0,2) !== '01') {
                ShowMessage('Cannot cancel on this document status', true);
                return;
            }
            CallBackAuthorize(path, 'MODULE_ADV', 'Index', 'D', SetCancel);
        });
        $('#txtCurrencyCode').focusout(function (event) {
            if (true) {
                ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
                ShowCaption();
            }
        });
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtAdvNo').focusout(function (event) {
            if (true) {
                ShowData($('#txtBranchCode').val(),$('#txtAdvNo').val());
            }
        });
        $('#txtAdvBy').change(function (event) {
            if (true) {
                ShowUser(path, $('#txtAdvBy').val(), '#txtAdvName');
            }
        });
        $('#txtReqBy').change(function (event) {
            if (true) {
                ShowUser(path, $('#txtReqBy').val(), '#txtReqName');
            }
        });
        $('#txtCustBranch').change(function (event) {
            if (true) {
                ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
            }
        });
        $('#txtSICode').change(function (event) {
            if (true) {
                let dt = FindService($('#txtSICode').val())
                ReadService(dt);
            }
        });
        $('#txtAdvQty').change(function (event) {
            if (true) {
                CalAmount();
            }
        });
        $('#txtUnitPrice').focusout(function (event) {
            if (true) {
                CalAmount();
            }
        });
        $('#txtExcRate').change(function (event) {
            if (true) {
                CalVATWHT();
            }
        });
        $('#txtAMT').focusout(function (event) {
            if (true) {
                CalVATWHT();
            }
        });
        $('#txtVATRate').change(function (event) {
            if (true) {
                CalVATWHT();
            }
        });
        $('#txtWHTRate').change(function (event) {
            if (true) {
                CalVATWHT();
            }
        });
        $('#txtVAT').change(function (event) {
            if (true) {
                CalTotal();
            }
        });
        $('#txtWHT').change(function (event) {
            if (true) {
                CalTotal();
            }
        });
        $('#txtForJNo').change(function (event) {
            if (true) {
                ShowInvNo(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), '#txtInvNo');
            }
        });
        $('#txtNET').change(function (event) {
            if (true) {
                let type = $('#txtVatType').val();
                if (type == '0'||type=='') type = "1";
                if (type == "2") {
                    CalVATWHT();
                } else {
                    CalTotal();
                }
            }
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
                    dataApp.push($('#txtBranchCode').val() + '|' + $('#txtAdvNo').val());
                    let jsonString = JSON.stringify({ data: dataApp });
                    $.ajax({
                        url: "@Url.Action("ApproveAdvance", "Adv")",
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
                    return;
                }
            } else {
                if ($('#cboDocStatus').val().substr(0, 2) == '02') {
                    $('#cboDocStatus').val('01');
                }
            }
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkApprove').prop('checked', !chkmode);
    }
    function GetStatus() {
        let status = 1;
        if ($('#txtPaymentBy').val() !== '') {
            status = 3;
        } else if ($('#txtApproveBy').val() !== '') {
            status = 2;
        }
        return status;
    }
    function SetCancel(b) {
        if (b == true) {
            ShowConfirm('Please confirm this operation', function (result) {
                if (result == true) {
                    $('#cboDocStatus').val(chkmode ? '99' : GetStatus());
                    $('#txtCancelProve').val(chkmode ? user : '');
                    $('#txtCancelDate').val(chkmode ? CDateEN(GetToday()) : '');
                    $('#txtCancelTime').val(chkmode ? ShowTime(GetTime()) : '');
                    SaveHeader();
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
        let lists = 'JOB_TYPE=#cboJobType';
        lists += ',SHIP_BY=#cboShipBy';
        lists += ',ADV_STATUS=#cboDocStatus';
        lists += ',ADV_STATUS=#cboStatus|';
        lists += ',ADV_TYPE=#cboAdvType';

        loadCombos(path, lists);
        loadServiceGroup(path, '#cboSTCode',true);
        LoadService();

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            //Payment
            CreateLOV(dv, '#frmSearchPay', '#tbPay', 'Payment Bills', response, 5);
            //Venders
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response,2);
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job List', response, 3);
            //Users
            CreateLOV(dv, '#frmSearchAdv', '#tbAdv', 'Advance By', response,2);
            CreateLOV(dv, '#frmSearchReq', '#tbReq', 'Request By', response,2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,2);
            //SICode
            CreateLOV(dv, '#frmSearchSICode', '#tbServ', 'Service Code', response,2);
            //Currency
            CreateLOV(dv, '#frmSearchSubCur', '#tbSubCur', 'Currency Code', response,2);
            CreateLOV(dv, '#frmSearchExpCur', '#tbExpCur', 'Currency Code', response, 2);
            //Estimate
            CreateLOV(dv, '#frmSearchEstimate', '#tbEstimate', 'Estimate Price', response, 3);
        });
    }
    function ShowData(branchcode, advno) {
        if (branchcode == '') {
            ShowMessage('Please input branch',true);
            return;
        }
        if (advno == '') {
            ShowMessage('Please input advance no',true);
            return;
        }
        if (userRights.indexOf('R') < 0) {
            ShowMessage('You are not allow to view',true);
            return;
        }
        $.get(path + 'adv/getadvance?branchcode='+branchcode+'&advno='+ advno, function (r) {
            let h = r.adv.header[0];
            ReadAdvHeader(h);
            let d = r.adv.detail;
            ReadAdvDetail(d);
        });
    }
    function PrintData() {
        if (userRights.indexOf('P') < 0) {
            ShowMessage('You are not allow to print',true);
            return;
        }
        window.open(path + 'Adv/FormAdv?branch=' + $('#txtBranchCode').val() + '&advno=' + $('#txtAdvNo').val());
    }
    function CheckEntry() {
        if (hdr == undefined) {
            ShowMessage('No data to Save',true);
            return false;
        }
        if ($('#txtReqBy').val() == '') {
            ShowMessage('Please input Request By',true);
            return false;
        }
        if (hdr.AdvNo == '') {
            if (userRights.indexOf('I') < 0) {
                ShowMessage('You are not allow to add',true);
                return false;
            }
        }
        if (userRights.indexOf('E') < 0) {
            ShowMessage('You are not allow to save',true);
            return false;
        }
        if (Number($('#txtTotalAmount').val())!==Number(SumTotal())) {
            if (Number($('#txtTotalAmount').val()) > 0) {
                if (Number(SumTotal()) == 0) {
                    ShowMessage('Please select type of payment',true);
                    return false;
                } else {
                    ShowMessage('Advance amount is not balance',true);
                    return false;
                }
            }
        }
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            $('#txtCustCode').focus();
            return false;
        }
        if ($('#cboJobType').val() == 0) {
            ShowMessage('please select job type',true);
            $('#cboJobType').focus();
            return false;
        }
        if ($('#cboShipBy').val() == 0) {
            ShowMessage('please select ship by',true);
            $('#cboShipBy').focus();
            return false;
        }
        if ($('#cboAdvType').val() == 0) {
            ShowMessage('Please select type of advance',true);
            $('#cboAdvType').focus();
            return false;
        }
        return true;
    }
    function SaveHeader() {
        if (CheckEntry()==true) {
            let obj = GetDataHeader(hdr);
            let jsonString = JSON.stringify({ data: obj });
            //ShowMessage(jsonString);
            $.ajax({
                url: "@Url.Action("SaveAdvanceHeader", "Adv")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    ShowMessage(response.result.msg);
                    if (response.result.data !== '') {
                        $('#txtAdvNo').val(response.result.data);
                        ShowData($('#txtBranchCode').val(), $('#txtAdvNo').val());
                    }
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        }
    }
    function GetDataHeader() {
        let dt = {
            BranchCode : $('#txtBranchCode').val(),
            AdvNo : $('#txtAdvNo').val(),
            AdvDate : CDateEN($('#txtAdvDate').val()),
            EmpCode : $('#txtReqBy').val(),
            AdvBy : $('#txtAdvBy').val(),
            CustCode : $('#txtCustCode').val(),
            CustBranch : $('#txtCustBranch').val(),
            Doc50Tavi : $('#txtDoc50Tavi').val(),
            PaymentNo : $('#txtPaymentNo').val(),
            TRemark : $('#txtTRemark').val(),

            CancelProve : $('#txtCancelProve').val(),
            CancelReson : $('#txtCancelReson').val(),
            CancelDate : CDateEN($('#txtCancelDate').val()),
            CancelTime : $('#txtCancelTime').val(),

            PaymentBy : $('#txtPaymentBy').val(),
            PaymentDate : CDateEN($('#txtPaymentDate').val()),
            PaymentTime : $('#txtPaymentTime').val(),
            PaymentRef : $('#txtPaymentRef').val(),

            ApproveBy : $('#txtApproveBy').val(),
            ApproveDate : CDateEN($('#txtApproveDate').val()),
            ApproveTime : $('#txtApproveTime').val(),

            AdvCash : CNum($('#txtAdvCash').val()),
            AdvChq : CNum($('#txtAdvChq').val()),
            AdvChqCash : CNum($('#txtAdvChqCash').val()),
            AdvCred : CNum($('#txtAdvCred').val()),

            TotalAdvance : CNum($('#txtTotalAmount').val()),
            TotalVAT : CNum($('#txtVatAmount').val()),
            Total50Tavi : CNum($('#txtWhtAmount').val()),

            JobType : $('#cboJobType').val(),
            ShipBy : $('#cboShipBy').val(),
            AdvType : $('#cboAdvType').val(),
            DocStatus: $('#cboDocStatus').val(),

            JNo: null,
            InvNo: null,
            VATRate: 0,
            PayChqTo: null,
            PayChqDate: CDateEN($('#txtPayChqDate').val()),

            MainCurrency: $('#txtMainCurrency').val(),
            SubCurrency: $('#txtSubCurrency').val(),
            ExchangeRate: $('#txtExchangeRate').val()
        };

        return dt;
    }
    function ReadAdvHeader(dt) {
        if (dt != undefined) {
            ClearHeader();
            hdr = dt;
            $('#txtBranchCode').val(dt.BranchCode);
            $('#txtAdvNo').val(dt.AdvNo);
            $('#txtAdvDate').val(CDateEN(dt.AdvDate));
            $('#txtAdvBy').val(dt.AdvBy);
            $('#txtReqBy').val(dt.EmpCode);
            if (isjobmode == false) {
                $('#txtCustCode').val(dt.CustCode);
                $('#txtCustBranch').val(dt.CustBranch);
                $('#cboJobType').val(CCode(dt.JobType));
                $('#cboShipBy').val(CCode(dt.ShipBy));
                ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
            }
            $('#txtDoc50Tavi').val(dt.Doc50Tavi);
            $('#txtPaymentNo').val(dt.PaymentNo);
            $('#txtTRemark').val(dt.TRemark);

            $('#txtCancelProve').val(dt.CancelProve);
            $('#txtCancelReson').val(dt.CancelReson);
            $('#txtCancelDate').val(CDateEN(dt.CancelDate));
            $('#txtCancelTime').val(ShowTime(dt.CancelTime));

            $('#txtPaymentBy').val(dt.PaymentBy);
            $('#txtPaymentDate').val(CDateEN(dt.PaymentDate));
            $('#txtPaymentTime').val(ShowTime(dt.PaymentTime));
            $('#txtPaymentRef').val(dt.PaymentRef);

            $('#txtApproveBy').val(dt.ApproveBy);
            $('#txtApproveDate').val(CDateEN(dt.ApproveDate));
            $('#txtApproveTime').val(ShowTime(dt.ApproveTime));

            $('#txtAdvCash').val(CDbl(dt.AdvCash,2));
            $('#txtAdvChq').val(CDbl(dt.AdvChq, 2));
            $('#txtAdvChqCash').val(CDbl(dt.AdvChqCash,2));
            $('#txtAdvCred').val(CDbl(dt.AdvCred,2));

            $('#txtAdvAmount').val(CDbl(Number(CDbl(dt.TotalAdvance,2))-Number(CDbl(dt.TotalVAT,2))+Number(CDbl(dt.Total50Tavi,2)),2));
            $('#txtVatAmount').val(CDbl(dt.TotalVAT,2));
            $('#txtWhtAmount').val(CDbl(dt.Total50Tavi,2));
            $('#txtTotalAmount').val(CDbl((dt.TotalAdvance),2));

            $('#chkCancel').prop('checked', $('#txtCancelProve').val() == '' ? false : true);
            $('#chkApprove').prop('checked', $('#txtApproveBy').val() == '' ? false : true);
            $('#chkPayment').prop('checked', $('#txtPaymentBy').val() == '' ? false : true);

            $('#chkCash').prop('checked', dt.AdvCash > 0 ? true : false);
            $('#chkChq').prop('checked', dt.AdvChq > 0 ? true : false);
            $('#chkChqCash').prop('checked', dt.AdvChqCash > 0 ? true : false);
            $('#chkCred').prop('checked', dt.AdvCred > 0 ? true : false);

            $('#txtMainCurrency').val(dt.MainCurrency);
            $('#txtSubCurrency').val(dt.SubCurrency);
            $('#txtExchangeRate').val(CDbl(dt.ExchangeRate, 2));

            $('#txtPayChqDate').val(CDateEN(dt.PayChqDate));
            //Combos
            $('#cboAdvType').val(CCode(dt.AdvType));
            $('#cboDocStatus').val(CCode(dt.DocStatus));

            ShowUser(path, $('#txtAdvBy').val(), '#txtAdvName');
            ShowUser(path, $('#txtReqBy').val(), '#txtReqName');

            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');

            if (dt.DocStatus > 2) {
                //if document is paymented/cancelled/cleared then disable save button
                $('#chkApprove').attr('disabled', 'disabled');
                $('#txtApproveDate').attr('disabled', 'disabled');
                $('#txtApproveBy').attr('disabled', 'disabled');
                $('#txtApproveTime').attr('disabled', 'disabled');

                $('#chkPayment').attr('disabled', 'disabled');
                $('#txtPaymentDate').attr('disabled', 'disabled');
                $('#txtPaymentBy').attr('disabled', 'disabled');
                $('#txtPaymentTime').attr('disabled', 'disabled');
                $('#txtPaymentRef').attr('disabled', 'disabled');

                $('#chkCancel').attr('disabled', 'disabled');
                $('#txtCancelDate').attr('disabled', 'disabled');
                $('#txtCancelBy').attr('disabled', 'disabled');
                $('#txtCancelTime').attr('disabled', 'disabled');

                $('#btnSave').attr('disabled', 'disabled');
                $('#btnUpdate').attr('disabled', 'disabled');
                $('#btnDel').attr('disabled', 'disabled');
            } else {
                //if document approved by this user or not then check authorized to unlock
                if (dt.DocStatus == 2 && user == dt.ApproveBy && userRights.indexOf('E') >= 0) {
                    $('#txtApproveDate').removeAttr('disabled');
                    $('#txtApproveBy').removeAttr('disabled');
                    $('#txtApproveTime').removeAttr('disabled');
                    $('#chkApprove').removeAttr('disabled');

                    $('#btnSave').removeAttr('disabled');
                    $('#btnDel').removeAttr('disabled');
                    $('#btnUpdate').removeAttr('disabled');
                } else {
                    if (dt.DocStatus == 2) {
                        //$('#chkApprove').attr('disabled', 'disabled');
                        $('#txtApproveDate').attr('disabled', 'disabled');
                        $('#txtApproveBy').attr('disabled', 'disabled');
                        $('#txtApproveTime').attr('disabled', 'disabled');

                        $('#btnSave').attr('disabled', 'disabled');
                        $('#btnUpdate').attr('disabled', 'disabled');
                        $('#btnDel').attr('disabled', 'disabled');
                    }
                }
            }
            return;
        }
        ClearHeader();
    }
    function AddHeader() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        $('#txtAdvNo').val('');
        $.get(path + 'adv/getnewadvanceheader?branchcode=' + $('#txtBranchCode').val() , function (r) {
            let h = r.adv.header;
            ReadAdvHeader(h);
            if (isjobmode == false) {
                $('#cboJobType').val('');
                $('#cboShipBy').val('');
            }
            $('#cboDocStatus').val('01');
            $('#cboAdvType').val('01');
            $('#txtAdvBy').val(user);
            $('#txtMainCurrency').val('@ViewBag.PROFILE_CURRENCY');
            $('#txtSubCurrency').val('@ViewBag.PROFILE_CURRENCY');
            $('#txtExchangeRate').val(1);
            $('#txtExcRate').val(1);

            ShowUser(path, $('#txtAdvBy').val(), '#txtAdvName');
            let d = r.adv.detail;
            ReadAdvDetail(d);
            ClearDetail();
            $('#txtAdvNo').focus();
        });
    }
    function AddDetail() {
        if ($('#txtAdvNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        $.get(path + 'adv/getnewadvancedetail?branchcode=' + $('#txtBranchCode').val() + '&advno=' + $('#txtAdvNo').val(), function (r) {
            let d = r.adv.detail[0];
            LoadDetail(d);
            $('#chkDuplicate').prop('checked', true);
            $('#txtSICode').attr('disabled', 'disabled');
            //$('#txtSDescription').attr('disabled', 'disabled');
            $('#frmDetail').modal('show');
            $('#txtCurrencyCode').val($('#txtSubCurrency').val());
            $('#txtExcRate').val($('#txtExchangeRate').val());
            $('#txtSICode').focus();
        });
    }
    function DeleteDetail() {
        if (dtl != undefined) {
            if (userRights.indexOf('D') < 0) {
                ShowMessage('You are not allow to delete',true);
                return;
            }
            $.get(path + 'adv/deladvancedetail?branchcode=' + $('#txtBranchCode').val() + '&advno=' + $('#txtAdvNo').val() + '&itemno=' + dtl.ItemNo, function (r) {
                ShowMessage(r.adv.result);
                ShowData($('#txtBranchCode').val(), $('#txtAdvNo').val());
            });
        } else {
            ShowMessage('No data to delete',true);
        }
    }
    function ClearHeader() {
        hdr = {};
        $('#txtAdvDate').val(GetToday());
        $('#txtPayChqDate').val(GetToday());
        $('#txtAdvBy').val(user);
        $('#txtReqBy').val('');
        if (isjobmode == false) {
            $('#txtCustCode').val('');
            $('#txtCustBranch').val('');
            $('#cboJobType').val('');
            $('#cboShipBy').val('');
            ShowCustomer(path, '', $('#txtCustBranch').val(), '#txtCustName');
        }
        $('#txtDoc50Tavi').val('');
        $('#txtPaymentNo').val('');
        $('#txtTRemark').val('');

        $('#txtCancelProve').val('');
        $('#txtCancelReson').val('');
        $('#txtCancelDate').val('');
        $('#txtCancelTime').val('');

        $('#txtPaymentBy').val('');
        $('#txtPaymentDate').val('');
        $('#txtPaymentTime').val('');
        $('#txtPaymentRef').val('');

        $('#txtApproveBy').val('');
        $('#txtApproveDate').val('');
        $('#txtApproveTime').val('');

        $('#txtAdvCash').val('');
        $('#txtAdvChq').val('');
        $('#txtAdvChqCash').val('');
        $('#txtAdvCred').val('');

        $('#txtAdvAmount').val('');
        $('#txtVatAmount').val('');
        $('#txtWhtAmount').val('');
        $('#txtTotalAmount').val('');

        $('#chkCancel').prop('checked', $('#txtCancelProve').val() == '' ? false : true);
        $('#chkApprove').prop('checked', $('#txtApproveBy').val() == '' ? false : true);
        $('#chkPayment').prop('checked', $('#txtPaymentBy').val() == '' ? false : true);

        $('#chkCash').prop('checked', true);
        $('#chkChq').prop('checked', false);
        $('#chkChqCash').prop('checked', false);
        $('#chkCred').prop('checked', false);

        //Combos
        $('#cboAdvType').val('01');
        $('#cboDocStatus').val('01');

        ShowUser(path, $('#txtAdvBy').val(), '#txtAdvName');
        ShowUser(path, '', '#txtReqName');

        $('#chkApprove').removeAttr('disabled');
        $('#chkCancel').removeAttr('disabled');

        $('#btnPrint').attr('disabled', 'disabled');
        $('#txtAdvCash').attr('disabled', 'disabled');
        $('#txtAdvChq').attr('disabled', 'disabled');
        $('#txtAdvChqCash').attr('disabled', 'disabled');
        $('#txtAdvCred').attr('disabled', 'disabled');
        $('#btnAdd').attr('disabled', 'disabled');
        $('#btnDel').attr('disabled', 'disabled');
        $('#btnSave').attr('disabled', 'disabled');
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
    }
    function SaveDetail() {

        if (hdr == undefined) {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        if (hdr.AdvNo == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        if (Number($('#txtNET').val()) == 0) {
            ShowMessage('Please check advance amount', true);
            return;
        }
  	if ($('#txtExcRate').val() < 1) {
            ShowMessage('Exchange Rate must equal or hignher than 1', true);
            $('#txtExcRate').focus();
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
            if (CheckDuplicate(obj) == true) {
                ShowMessage('This data is duplicate',true);
                return;
            }
            let jsonString = JSON.stringify({ data: obj });
            //ShowMessage(jsonString);
            $.ajax({
                url: "@Url.Action("SaveAdvanceDetail", "Adv")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    ShowMessage(response.result.msg);
                    ShowData($('#txtBranchCode').val(), $('#txtAdvNo').val());
                }
            });
            return;
        }
        ShowMessage('No data to Save',true);
    }
    function CheckDuplicate(o) {
        let rows = $('#tbDetail').DataTable().rows().data();
        let filter = rows.filter(function (row) {
            return CStr(row.ForJNo) == o.ForJNo && row.SICode == o.SICode && row.SDescription == o.SDescription && Number(row.ItemNo)!==Number(o.ItemNo);
        });
        return (filter.length > 0);
    }
    function ReadAdvDetail(dt) {
        let tb=$('#tbDetail').DataTable({
            data:dt,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: null, title: "Edit" },
                { data: "SICode", title: "Service" },
                { data: "SDescription", title: "Description" },
                { data: "ForJNo", title: "Job" },
                { data: "CurrencyCode", title: "Currency" },
                { data: "ExchangeRate", title: "Rate" },
                { data: "AdvQty", title: "Qty" },
                {
                    data: "UnitPrice", title: "Price",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                {
                    data: "AdvAmount", title: "Amount",
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
                    data: "Charge50Tavi", title: "WH-Tax",
                    render: function (data) {
                        return ShowNumber(data, 3);
                    }
                },
                {
                    data: "AdvNet", title: "Net",
                    render: function (data) {
                        return ShowNumber(data, 3);
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
            , pageLength: 100
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
    function GetAdvDetail(list) {
        let rows = [];
        let header = list.header[0];
        let item = 0;
        for (let row of list.detail) {
            item += 1;
            let dt = {
                BranchCode : $('#txtBranchCode').val(),
                AdvNo : $('#txtAdvNo').val(),
                ItemNo : item,
                SICode : row.SICode,
                STCode : 'EXP',
                ForJNo : row.ForJNo,
                TRemark : row.SRemark,
                Doc50Tavi : '',
                PayChqTo : header.DocNo +'#' + row.ItemNo,
                SDescription : row.SDescription,
                IsChargeVAT : row.IsTaxCharge,
                VATRate: header.VATRate,
                Is50Tavi: row.Is50Tavi,
                Rate50Tavi : header.TaxRate,
                AdvAmount : CDbl(CNum(row.Amt/header.ExchangeRate),2),
                ChargeVAT : CDbl(CNum(row.AmtVAT/header.ExchangeRate),2),
                Charge50Tavi : CDbl(CNum(row.AmtWHT/header.ExchangeRate),2),
                AdvNet: row.FTotal,
                AdvQty: row.Qty,
                UnitPrice: row.UnitPrice,
                CurrencyCode: header.CurrencyCode,
                ExchangeRate: header.ExchangeRate,
                VenCode: header.VenCode,
                IsDuplicate: 0
            };
            rows.push(dt);
        }
        return rows;
    }
    function GetDataDetail() {
        let dt = {
            BranchCode : $('#txtBranchCode').val(),
            AdvNo : $('#txtAdvNo').val(),
            ItemNo : $('#txtItemNo').val(),
            SICode : $('#txtSICode').val(),
            STCode : $('#cboSTCode').val(),
            ForJNo : $('#txtForJNo').val(),
            TRemark : $('#txtRemark').val(),
            Doc50Tavi : $('#txt50Tavi').val(),
            PayChqTo : $('#txtPayChqTo').val(),
            SDescription : $('#txtSDescription').val(),
            IsChargeVAT : $('#txtVatType').val(),
            VATRate: $('#txtVATRate').val(),
            Is50Tavi: ($('#txtWHTRate').val() >0? 1:0),
            Rate50Tavi : $('#txtWHTRate').val(),
            AdvAmount : $('#txtAMT').val(),
            ChargeVAT : $('#txtVAT').val(),
            Charge50Tavi : $('#txtWHT').val(),
            AdvNet: $('#txtNET').val(),
            AdvQty: $('#txtAdvQty').val(),
            UnitPrice: $('#txtUnitPrice').val(),
            CurrencyCode: $('#txtCurrencyCode').val(),
            ExchangeRate: $('#txtExcRate').val(),
            VenCode: $('#txtVenCode').val(),
            IsDuplicate: ($('#chkDuplicate').prop('checked')==true? 1:0)
        };
        return dt;
    }
    function LoadDetail(dt) {
        if (dt != undefined) {
            ClearDetail();
            dtl = dt;
            $('#txtItemNo').val(dt.ItemNo);
            $('#txtSICode').val(dt.SICode);
            $('#cboSTCode').val(dt.STCode);
            $('#cboSTCode').change();
            //let r = FindService($('#txtSICode').val())
            //ReadService(r);
            $('#txtSDescription').val(dt.SDescription);
            if (isjobmode == false) {
                $('#txtForJNo').val(dt.ForJNo);
                $('#txtInvNo').val('');
                if ($('#txtForJNo').val()!= '') {
                    ShowInvNo(path, $('#txtBranchCode').val(), $('#txtForJNo').val(), '#txtInvNo');
                }
            }
            $('#txtAdvQty').val(dt.AdvQty);
            $('#txtExcRate').val(dt.ExchangeRate);
            $('#txtUnitPrice').val(CDbl(dt.UnitPrice,2));
            CalAmount();
            $('#txtRemark').val(dt.TRemark);
            $('#txt50Tavi').val(dt.Doc50Tavi);
            $('#txtPayChqTo').val(dt.PayChqTo);
            $('#txtSDescription').val(dt.SDescription);
            $('#txtVatType').val(dt.IsChargeVAT);
            $('#txtVATRate').val(dt.VATRate);
            $('#txtWHTRate').val(dt.Rate50Tavi);
            $('#txtAMT').val(CDbl(dt.AdvAmount,2));
            $('#txtVAT').val(CDbl(dt.ChargeVAT,2));
            $('#txtWHT').val(CDbl(dt.Charge50Tavi,2));
            $('#txtNET').val(CDbl(dt.AdvNet,2));
            $('#txtVenCode').val(dt.VenCode);
            $('#chkDuplicate').prop('checked', dt.IsDuplicate > 0 ? true : false);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            ShowCaption();
            return;
        }
        ClearDetail();
    }
    function ClearDetail() {
        dtl = {};
        $('#txtItemNo').val('0');
        $('#txtSICode').val('');
        $('#cboSTCode').val('');
        $('#chkDuplicate').prop('checked', false);
        if (isjobmode == false) {
            $('#txtForJNo').val('');
            $('#txtInvNo').val('');
        }
        $('#txtRemark').val('');
        $('#txt50Tavi').val('');
        $('#txtPayChqTo').val('');
        $('#txtSDescription').val('');
        $('#txtVatType').val('1');
        $('#txtVATRate').val('');
        $('#txtWHTRate').val('');
        $('#txtAMT').val(0);
        $('#txtVAT').val(0);
        $('#txtWHT').val(0);
        $('#txtNET').val(0);
        $('#txtAMTCal').val(0);
        $('#txtAdvQty').val(1);
        $('#txtExcRate').val($('#txtExchangeRate').val());
        $('#txtUnitPrice').val('');
        $('#txtCurrencyCode').val($('#txtSubCurrency').val());
        ShowCurrency(path, $('#txtSubCurrency').val(), '#txtCurrencyName');
        ShowCaption();
        $('#txtDetCurrency').val($('#txtMainCurrency').val());
        $('#txtVenCode').val('');

        $('#chkDuplicate').prop('checked', false);
        $('#txtAMT').removeAttr('disabled');
        $('#txtVATRate').removeAttr('disabled');
        $('#txtWHTRate').removeAttr('disabled');
        $('#txtVAT').removeAttr('disabled');
        $('#txtWHT').removeAttr('disabled');
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
        let w ='?branchcode='+ $('#txtBranchCode').val();
        if (job.length > 0) {
            w += '&jobno=' + job;
        } else {
            if ($('#txtCustCode').val()!=='') {
                w += '&custcode=' + $('#txtCustCode').val();
            }
            if ($('#txtCustBranch').val() !== '') {
                w += '&custbranch=' + $('#txtCustBranch').val();
            }
            if ($('#cboJobType').val() !== '') {
                w += '&jtype=' + $('#cboJobType').val();
            }
            if ($('#cboShipBy').val() !== '') {
                w += '&sby=' + $('#cboShipBy').val();
            }
            if ($('#txtAdvBy').val() !== '') {
                w += '&advby=' + $('#txtAdvBy').val();
            }
            if ($('#txtReqBy').val() !== '') {
                w += '&reqby=' + $('#txtReqBy').val();
            }
        }
        if ($('#cboStatus').val() !== '') {
            w += '&status=' + $('#cboStatus').val();
        }
        $('#dvAdvFilter').html(w);
        $.get(path + 'adv/getadvancegrid' +  w, function (r) {
            if (r.adv.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.adv.data[0].Table;
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "AdvNo", title: "Advance No" },
                    {
                        data: "AdvDate", title: "Date",
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
                        data: "TotalAdvance", title: "Total",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "Total50Tavi", title: "W/T",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "Doc50Tavi", title: "W/T No" },
                    { data: "PaymentNo", title: "A/P No" },
                    {
                        data: null, title: "Request Amt",
                        render: function (data) {
                            return CDbl(Number(data.AdvCash) + Number(data.AdvChqCash) + Number(data.AdvChq) + Number(data.AdvCred), 2) + '' + data.SubCurrency;
                        }
                    },
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
                ShowData(data.BranchCode, data.AdvNo); //callback function from caller
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
            case 'advance':
                SetGridAdv();
                break;
            case 'estimate':
                SetGridEstimateCost(path, '#tbEstimate', '?status=NOCLR&group=' + $('#cboSTCode').val() + '&Job=' + $('#txtForJNo').val(), '#frmSearchEstimate', ReadEstimate);
                break;
            case 'payment':
                if ($('#txtPaymentNo').val() !== '') {
                    ShowMessage('Bill-payment had been choosed',true);
                    return;
                }
                let pt = '';
                if ($('#chkCash').prop('checked') == true) {
                    pt = '&paytype=CA';
                }
                if ($('#chkChqCash').prop('checked') == true) {
                    pt = '&paytype=CH';
                }
                if ($('#chkChq').prop('checked') == true) {
                    pt = '&paytype=CU';
                }
                if ($('#chkCred').prop('checked') == true) {
                    pt = '&paytype=CR';
                }
                if (pt == '') {
                    ShowMessage('Please select type of payment',true);
                    return;
                }
                if (CheckEntry() == true) {
                    SetGridPayment(path, '#tbPay', '?branch=' + $('#txtBranchCode').val() + '&type=NOPAY' + pt, '#frmSearchPay', ReadPayment);
                }
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'advby':
                SetGridUser(path, '#tbAdv', '#frmSearchAdv', ReadAdvBy);
                break;
            case 'reqby':
                SetGridUser(path, '#tbReq', '#frmSearchReq', ReadReqBy);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
            case 'servicecode':
                SetGridSICodeByGroup(path, '#tbServ', $('#cboSTCode').val(), '#frmSearchSICode', ReadService);
                break;
            case 'job':
                SetGridJob(path, '#tbJob', '#frmSearchJob', GetParam(), ReadJob);
                break;
            case 'subcurrency':
                SetGridCurrency(path, '#tbSubCur', '#frmSearchSubCur', ReadCurrencyH);
                break;
            case 'detcurrency':
                SetGridCurrency(path, '#tbExpCur', '#frmSearchExpCur', ReadCurrencyD);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
        }
    }
    function GetParam() {
        let strParam = '?Status=0,1,2,3,4,5,6,7';
        strParam += '&Branch=' + $('#txtBranchCode').val();
        strParam += '&JType=' + $('#cboJobType').val().substr(0, 2);
        strParam += '&SBy=' + $('#cboShipBy').val().substr(0, 2);
        strParam += '&CustCode=' + $('#txtCustCode').val();
        return strParam;
    }
    function ShowCaption() {
        if (mainLanguage == 'EN') {
            $('#lblUnitPrice').text("Price (" + $('#txtCurrencyCode').val() + "):");
            $('#lblAMTCal').text("Amount (" + $('#txtCurrencyCode').val() + "):");
            $('#lblAmount').text("Amount (" + $('#txtMainCurrency').val() + "):");
            $('#lblVATRate').text("VAT (" + $('#txtMainCurrency').val() + "):");
            $('#lblWHTRate').text("WHT (" + $('#txtMainCurrency').val() + "):");
            $('#lblNETAmount').text("Net (" + $('#txtMainCurrency').val() + "):");
        }
        if (mainLanguage == 'TH') {
            $('#lblUnitPrice').text("ราคา (" + $('#txtCurrencyCode').val() + "):");
            $('#lblAMTCal').text("ราคารวม (" + $('#txtCurrencyCode').val() + "):");
            $('#lblAmount').text("ราคาสุทธิ (" + $('#txtMainCurrency').val() + "):");
            $('#lblVATRate').text("ภาษีมูลค่าเพิ่ม (" + $('#txtMainCurrency').val() + "):");
            $('#lblWHTRate').text("หัก ณ ที่จ่าย (" + $('#txtMainCurrency').val() + "):");
            $('#lblNETAmount').text("ยอดสุทธิ (" + $('#txtMainCurrency').val() + "):");
        }
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        $('#txtPayChqTo').val(dt.TName);
        $('#txtRemark').val(dt.ContactAcc);
        $('#txtPayChqTo').focus();
    }
    function ReadCurrencyD(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
        $('#txtExcRate').val(0);
        CalAmount();
        ShowCaption();
        $('#txtExcRate').focus();
    }
    function ReadCurrencyH(dt) {
        $('#txtSubCurrency').val(dt.Code);
        $('#txtExchangeRate').focus();
    }
    function ReadAdvBy(dt) {
        $('#txtAdvBy').val(dt.UserID);
        $('#txtAdvName').val(dt.TName);
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
    function ReadEstimate(dt) {
        $('#txtSICode').val(dt.SICode);
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
        $('#txtAdvQty').val(CNum(dt.Qty));
        $('#txtUnitCode').val(dt.QtyUnit);
        $('#txtVenCode').val(dt.VenderCode);
        ShowVender(path, dt.VenderCode, '#txtPayChqTo');
        CalAmount();
    }
    function ReadService(dt) {
        if (dt != undefined) {
            $('#txtSICode').val(dt.SICode);
            $('#cboSTCode').val(dt.GroupCode);
            $('#cboSTCode').change();
            $('#txtSDescription').val(dt.NameThai);
            $('#txtVatType').val(dt.IsTaxCharge);
            $('#txtVATRate').val(dt.IsTaxCharge == "0" ? "0" : CDbl(@ViewBag.PROFILE_VATRATE*100,0));
            $('#txtWHTRate').val(dt.Is50Tavi == "0" ? "0" : dt.Rate50Tavi);
            $('#txtCurrencyCode').val(dt.CurrencyCode);
            ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            if (CNum($('#txtUnitPrice').val) == 0) {
                $('#txtUnitPrice').val(dt.StdPrice);
                CalAmount();
            }
            if (dt.IsTaxCharge == "2") {
                $('#txtAMT').attr('disabled', 'disabled');
                $('#txtVAT').attr('disabled', 'disabled');
                $('#txtWHT').attr('disabled', 'disabled');
            } else {
                $('#txtAMT').removeAttr('disabled');
                $('#txtVAT').removeAttr('disabled');
                $('#txtWHT').removeAttr('disabled');
            }
            CalVATWHT();
            return;
        }
        $('#txtSDescription').val('');
        $('#txtVatType').val(1);
        $('#txtVATRate').val(0);
        $('#txtWHTRate').val(0);
        $('#txtAMT').removeAttr('disabled');
        $('#txtVATRate').removeAttr('disabled');
        $('#txtWHTRate').removeAttr('disabled');
        $('#txtVAT').removeAttr('disabled');
        $('#txtWHT').removeAttr('disabled');
        CalVATWHT();
    }
    function ReadJob(dt) {
        if (ShowDate(dt.CloseJobDate) !== '-') {
            ShowMessage('This job has been closed',true);
            return;
        }
        if (dt.JobStatus==99) {
            ShowMessage('This job has been cancelled', true);
            return;
        }
        $('#txtForJNo').val(dt.JNo);
        $('#txtInvNo').val(dt.InvNo);
    }
    function ReadPayment(dt) {
        if ($('#txtAdvNo').val() !== '') {
            let docno = dt.DocNo;
            let branch = dt.BranchCode;
            $('#txtPaymentNo').val(docno);
            $.get(path + 'acc/getpaymentforadv?branch=' + branch + '&code=' + docno)
                .done(function (r) {
                    if (r.payment.detail.length > 0) {
                        let dt = GetAdvDetail(r.payment);
                        SaveAdvFromPay(dt);
                    }
                });
        } else {
            ShowMessage('Please save document before add detail',true);
        }
    }
    function SaveAdvFromPay(obj) {
        let jsonString = JSON.stringify({ data: obj });
        $.ajax({
            url: "@Url.Action("SetAdvDetail", "Adv")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                ShowData($('#txtBranchCode').val(), $('#txtAdvNo').val());
                SaveHeader();
            }
        });
        return;
    }
    function SumTotal() {
        let cash = CDbl($('#txtAdvCash').val(),2);
        let chq = CDbl($('#txtAdvChq').val(),2);
        let chqcash = CDbl($('#txtAdvChqCash').val(),2);
        let cred = CDbl($('#txtAdvCred').val(),2);
        return CDbl(Number(cash) + Number(chq) + Number(chqcash) + Number(cred),2);
    }
    function GetTotal() {
        let total = SumTotal();
        let sum = CNum($('#txtTotalAmount').val());
        return CDbl(sum / CNum($('#txtExchangeRate').val()) - total,2);
    }
    function CalAmount() {
        $('#txtAMT').val(0);
        $('#txtVAT').val(0);
        $('#txtWHT').val(0);
        $('#txtNET').val(0);
        let price = CDbl($('#txtUnitPrice').val(),2);
        let qty = CDbl($('#txtAdvQty').val(),2);
        let rate = CDbl($('#txtExcRate').val(),2); //rate ของ detail
        let type = $('#txtVatType').val();
        if (qty > 0) {
            let amt = CNum(qty) * CNum(price);
            $('#txtAMTCal').val(CDbl(CNum(amt), 2));
            if (type == '0' || type == '') type = '1';
            if (type == '2') {
                $('#txtNET').val(CDbl(CNum(amt) * CNum(rate), 2));
            }
            if (type == '1') {
                $('#txtAMT').val(CDbl(CNum(amt) * CNum(rate),2));
            }
            CalVATWHT();
        }
    }
    function CalTotal() {
        let amt = CDbl($('#txtAMT').val(),2);
        let vat = CDbl($('#txtVAT').val(),2);
        let wht = CDbl($('#txtWHT').val(), 2);

        $('#txtNET').val(CDbl(CNum(amt) + CNum(vat) - CNum(wht),2));
        $('#txtAMT').val(CDbl(amt,2));
    }
    function CalVATWHT() {
        let type = $('#txtVatType').val();
        if (type == '' || type == '0') {
            type = '1';
            $('#txtVatType').val(type);
        }
        let amt = CDbl($('#txtAMT').val(),2);
        if (type == '2') {
            amt = CDbl(CNum($('#txtNET').val()) + CNum($('#txtWHT').val()), 2);
        }
        let vatrate = CDbl($('#txtVATRate').val(),2);
        let whtrate = CDbl($('#txtWHTRate').val(),2);
        let vat = 0;
        let wht = 0;
        if (type == "2") {
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
        $('#txtVAT').val(CDbl(vat.toFixed(3),3));
        $('#txtWHT').val(CDbl(wht.toFixed(3),3));
        CalTotal();
    }
    function GetExchangeRate() {
        $.get('https://free.currencyconverterapi.com/api/v6/convert?q=' + $('#txtSubCurrency').val() + '_' + $('#txtMainCurrency').val() + '&compact=ultra&apiKey=6210d55b79170a4a7da2', function (r) {
            let rate = CDbl(r[$('#txtSubCurrency').val() + '_' + $('#txtMainCurrency').val()], 2);
            $('#txtExchangeRate').val(rate);
        });
    }
    function AutoGenWHTax() {
        if ($('#txtDoc50Tavi').val() !== '') {
            window.open(path + 'Acc/WHTax?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtDoc50Tavi').val());
            return;
        }
        $.get(path + 'master/getcompany?Code=' + $('#txtCustCode').val() + '&Branch' + $('#txtCustBranch').val()).done(function (r) {
            let dr = r.company.data;
            if (dr.length > 0) {
                SaveWHTax(dr[0]);
            }
        });
    }
    function SaveWHTax(dt) {
        //if ($('#btnSave').attr('disabled') == 'disabled') {
        //    ShowMessage('This document is locked',true);
        //    return;
        //}
        let obj = GetWHTaxHeader(dt);
        let jsonText = JSON.stringify({ data: obj });
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetWHTaxHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.data != '') {
                    SetWHTaxDetail(response.result.data);
                    ShowMessage(response.result.msg);
                    $('#txtDoc50Tavi').val(response.result.data);
                    //$('#txtDoc50Tavi').focus();
                    window.open(path + 'Acc/WHTax?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtDoc50Tavi').val());
                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function SetWHTaxDetail(docno) {
        $.get(path + 'adv/getadvanceforwht?branchcode=' + $('#txtBranchCode').val() + '&advno=' + $('#txtAdvNo').val(), function (r) {
            let dt = r.adv.detail.filter(function (data) {
                return data.Charge50Tavi > 0;
            });
            let i = 0;
            let j = 0;
            for (let d of dt) {
                i += 1;
                let obj={
                    BranchCode:$('#txtBranchCode').val(),
                    DocNo:docno,
                    ItemNo:i,
                    IncType:14,
                    PayDate:CDateEN($('#txtAdvDate').val()),
                    PayAmount:d.AdvAmount,
                    PayTax:d.Charge50Tavi,
                    PayTaxDesc:d.SDescription,
                    JNo:d.ForJNo,
                    DocRefType:1,
                    DocRefNo:$('#txtAdvNo').val(),
                    PayRate:d.Rate50Tavi
                };

                SaveWHTaxDetail(obj);
            }
        });
    }
    function SaveWHTaxDetail(obj) {
        let jsonText = JSON.stringify({ data: obj });
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetWHTaxDetail", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.data != '') {
                    j = response.result.data;
                    return;
                }
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function GetWHTaxHeader(dt) {
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            DocNo: '',
            DocDate: CDateEN($('#txtAdvDate').val()),
            TaxNumber1: dt.TaxNumber,
            TName1: dt.NameThai,
            TAddress1: dt.TAddress1 + ' ' +dt.TAddress2,
            TaxNumber2: '@ViewBag.PROFILE_TAXNUMBER',
            TName2: '@ViewBag.PROFILE_COMPANY_NAME',
            TAddress2: '@ViewBag.PROFILE_COMPANY_ADDR1' + '' + '@ViewBag.PROFILE_COMPANY_ADDR2',
            TaxNumber3: '',
            TName3: '',
            TAddress3: '',
            IDCard1: '',
            IDCard2: '',
            IDCard3: '',
            SeqInForm: 0,
            FormType: 7,
            TaxLawNo: 5,
            IncRate: 3,
            IncOther: '',
            UpdateBy: user,
            TotalPayAmount: 0,
            TotalPayTax: 0,
            SoLicenseNo: '',
            SoLicenseAmount: 0,
            SoAccAmount: 0,
            PayeeAccNo: '',
            SoTaxNo: '',
            PayTaxType: '',
            PayTaxOther: '',
            CancelProve: '',
            CancelReason: '',
            CancelDate: null,
            LastUpdate: CDateEN(GetToday()),
            TeacherAmt: 0,
            Branch1: '',
            Branch2: '',
            Branch3: '',
            IsCSV:0
        };
        return obj;
    }
    function PrintClear() {
        window.open(path + 'Adv/FormClrAdv?branch=' + $('#txtBranchCode').val() + '&advno=' + $('#txtAdvNo').val());
    }
</script>