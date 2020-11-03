@Code
    ViewBag.Title = "สร้างใบแจ้งหนี้"
End Code
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblBranch">Branch:</label>                
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
                </div>
            </div>
            <div class="col-sm-3">
                <label id="lblJobType">Job Type</label>
                <br />
                <select id="cboJobType" class="form-control dropdown" onchange="CheckJobType()"></select>
            </div>
            <div class="col-sm-3">
                <label id="lblShipBy">Ship By</label>
                <br />
                <select id="cboShipBy" class="form-control dropdown"></select>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblCustCode">Customer</label>                
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtCustCode" style="width:120px" />
                    <input type="text" id="txtCustBranch" style="width:50px" />
                    <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                    <input type="text" id="txtCustName" style="width:100%" disabled />
                </div>
            </div>
            <div class="col-sm-3">
                <a id="linkJobNo" href="#" onclick="SearchData('job')">Job No :</a><br />
                <input type="text" id="txtJobNo" class="form-control" disabled />
            </div>
            <div class="col-sm-3">
                <br />
                <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
                </a>
                <input type="checkbox" id="chkSelectAll" checked /> Select All 
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>JobNo</th>
                            <th class="desktop">ClrNo</th>
                            <th class="desktop">CustCode</th>
                            <th>Description</th>
                            <th class="desktop">Cost</th>
                            <th class="desktop">Advance</th>
                            <th class="desktop">Charge</th>
                            <th class="desktop">VAT</th>
                            <th class="desktop">WHT</th>
                            <th class="all">Net</th>
                        </tr>
                    </thead>
                </table>
                <br />
                <a href="#" class="btn btn-success" id="btnGen" onclick="ShowSummary()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkCreate">Create Invoice</b>
                </a>
                <a href="#" class="btn btn-warning" id="btnGen" onclick="SetTempInv()">
                    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkSave">Preview Invoice</b>
                </a>
                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ResetData()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkReset">Reset Select</b>
                </a>
            </div>
        </div>
    </div>
    <div id="dvCreate" class="modal modal-lg fade">
        <div class="modal-dialog-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-sm-4" style="display:flex">
                            <div style="flex:1">
                                <label id="lblInvDate">Invoice Date :</label>
                                <br />
                                <input type="date" id="txtDocDate" class="form-control" value="@DateTime.Today.ToString("yyyy-MM-dd")" />
                            </div>
                            <div style="flex:1">
                                <label id="lblInvType">Invoice Type :</label>
                                <br />
                                <select id="cboDocType" class="form-control dropdown">
                                    <option value="BKK">Service</option>
                                    <option value="RGM">Advance</option>
                                    <option value="APL">Outside</option>
                                </select>

                            </div>
                        </div>
                        <div class="col-sm-4" style="display:flex">
                            <div style="flex:1">
                                <label id="lblReplaceInv">Replace Invoice No:</label>
                                <br />
                                <div style="display:flex;flex-direction:row">
                                    <input type="text" id="txtDocNo" class="form-control" />
                                    <input type="button" onclick="SearchData('invoice')" value="..." />
                                </div>
                            </div>
                            <div style="flex:1">
                                <br />
                                <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintInvoice()">
                                    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="lblPrintDoc">Print Invoice</b>
                                </a>
                            </div>
                        </div>
                        <div class="col-sm-4" style="display:flex">
                            <div style="flex:1">
                                <label id="lblDiscountRate">Discount Rate(%):</label>
                                <br /><input type="number" id="txtDiscountRate" class="form-control" onchange="SetDiscount()" />
                            </div>
                            <div style="flex:1">
                                <label id="lblCalDiscount">Discount Amt</label>
                                <br /><input type="number" id="txtCalDiscount" class="form-control" onchange="SumDiscount()" />
                            </div>
                        </div>
                    </div>
                    <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-4">
                            <table>
                                <tr>
                                    <td>
                                        <label id="lblCheque">Use Cheque:</label>                                        
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtChqNo" class="form-control" disabled />
                                            <input type="button" onclick="SearchData('chequecust')" value="..." />
                                        </div>
                                    </td>
                                    <td>
                                        <label id="lblChqAmount">Cheque Used</label>
                                        <br />
                                        <input type="number" id="txtChqAmount" class="form-control" />
                                    </td>
                                    <td>
                                        <br />
                                        <input type="button" id="btnAddCheque" value="+" class="btn" onclick="AddCheque()" />
                                    </td>
                                </tr>
                            </table>
                            <b id="linkChq">Customer Cheques</b><br />
                            <input type="hidden" id="txtControlNo" />
                            <table id="tbCheque" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Cheque No</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                        <div class="col-sm-8">
                            <div style="width:100%">
                                <label id="lblBillToCustCode">Billing Place</label>
                                <br />
                                <div style="display:flex;flex-direction:row">
                                    <input type="text" id="txtBillToCustCode" style="width:120px" />
                                    <input type="text" id="txtBillToCustBranch" style="width:50px" />
                                    <button id="btnBrowseCust2" class="btn btn-default" onclick="SearchData('billing')">...</button>
                                    <input type="text" id="txtBillToCustName" style="width:100%" disabled />
                                </div>
                            </div>
                            <b id="linkCost">Costing of Invoice:</b><br />
                            <table id="tbCost" class="table table-responsive" style="width:100%;">
                                <thead>
                                    <tr>
                                        <th>Job No</th>
                                        <th class="all">Description</th>
                                        <th class="desktop">SlipNo</th>
                                        <th class="desktop">Expense</th>
                                        <th class="desktop">VAT</th>
                                        <th class="desktop">WH-Tax</th>
                                        <th class="all">Net</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <b id="linkInv">Invoice Summary:</b>
                            <br />
                            <table style="width:100%">
                                <tr><td id="colAdv">Advance</td><td><input type="text" id="txtTotalAdvance" class="form-control" disabled /></td></tr>
                                <tr><td id="colChg">Charge</td><td><input type="text" id="txtTotalCharge" class="form-control" disabled /></td></tr>
                                <tr><td id="colDis">Line Discount</td><td><input type="text" id="txtSumDiscount" class="form-control" disabled /></td></tr>
                                <tr><td id="colVatB">Vatable</td><td><input type="text" id="txtTotalIsTaxCharge" class="form-control" disabled /></td></tr>
                                <tr><td id="colTaxB">Taxable</td><td><input type="text" id="txtTotalIs50Tavi" class="form-control" disabled /></td></tr>
                                <tr><td id="colVat">VAT</td><td><input type="text" id="txtTotalVat" class="form-control" disabled /></td></tr>
                                <tr><td id="colSumVat">After VAT</td><td><input type="text" id="txtTotalAfter" class="form-control" disabled /></td></tr>
                                <tr><td id="colCustAdv">Cust.Advance</td><td><input type="text" id="txtTotalCustAdv" class="form-control" disabled /></td></tr>
                                <tr><td id="colWH">WHT</td><td><input type="text" id="txtTotal50Tavi" class="form-control" disabled /></td></tr>
                                <tr><td id="colSumWH">After WHT</td><td><input type="text" id="txtTotalService" class="form-control" disabled /></td></tr>
                                <tr><td id="colSumDisc">Sum Discount</td><td><input type="text" id="txtTotalDiscount" class="form-control" disabled /></td></tr>
                                <tr><td id="colNet">NET</td><td><input type="text" id="txtTotalNet" class="form-control" disabled /></td></tr>
                                <tr>
                                    <td id="colCurr">Currency</td>
                                    <td>
                                        <input type="text" id="txtCurrencyCode" disabled />
                                        <input type="button" value="..." onclick="SearchData('currency')" />
                                    </td>
                                </tr>
                                <tr><td id="colExc">Exc.Rate</td><td><input type="text" id="txtExchangeRate" class="form-control" onchange="CalForeign()" /></td></tr>
                                <tr><td id="colInv">Invoiced</td><td><input type="text" id="txtForeignNet" class="form-control" disabled /></td></tr>
                                <tr><td id="colCost">Cost</td><td><input type="text" id="txtTotalCost" class="form-control" disabled /></td></tr>
                                <tr><td id="colProfit">Profit</td><td><input type="text" id="txtTotalProfit" class="form-control" disabled /></td></tr>
                            </table>
                            <a href="#" class="btn btn-success" id="btnGen" onclick="ApproveData()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Invoice</b>
                            </a>
                        </div>
                        <div class="col-sm-8">
                            <b id="linkDet">Invoice Detail:</b>
                            <button id="btnMerge" class="btn btn-default" onclick="MergeData()">Group Data</button>
                            <br />
                            <table id="tbDetail" class="table table-responsive" style="width:100%;">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th class="all">JobNo</th>
                                        <th>Description</th>
                                        <th class="desktop">SlipNo</th>
                                        <th class="desktop">Advance</th>
                                        <th class="desktop">Charge</th>
                                        <th class="desktop">VAT</th>
                                        <th class="desktop">WH-Tax</th>
                                        <th class="all">Net</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div id="dvEditor" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <label id="lblClearNo">Clearing No</label> : 
                        <label id="lblClrNo"></label>                                                                     
                        <label id="lblJNo">Job No</label>: 
                        <label id="lblJobNo"></label>
                        <br />
                        <label id="lblCode">Code</label>: 
                        <label id="lblSICode"></label>
                        <label id="lblDesc">Description</label>:
                        <label id="lblSDescription"></label>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr style="width:100%">
                                <td style="width:20%">
                                    <label id="lblAdv">Advance :</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtAmtAdvance" onchange="CalNetAmount()" />
                                </td>
                                <td style="width:20%">
                                    <label id="lblChg">Charges</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtAmtCharge" onchange="CalVATWHT(0)" />
                                </td>
                                <td style="width:10%">
                                    <label id="lblQtyD">Qty</label>
                                    <br />
                                    <input type="number" id="txtAmtQty" class="form-control" value="0" onchange="CalDiscount()">
                                </td>
                                <td style="width:15%">
                                    <label id="lblUnitD">Unit:</label>
                                    <br />
                                    <input type="text" id="txtAmtUnit" value="" class="form-control" onchange="CalNetAmount()">
                                </td>
                            </tr>
                            <tr>
                                <td style="width:10%">
                                    <label id="lblDisc">Disc (%)</label>
                                    <br />
                                    <input type="number" id="txtAmtDiscountPerc" class="form-control" value="0" onchange="CalDiscount()">
                                </td>
                                <td style="width:15%">
                                    <label id="lblDiscAmt">Discount:</label>
                                    <br />
                                    <input type="text" id="txtAmtDiscount" value="0" class="form-control" onchange="CalNetAmount()">
                                </td>
                                <td style="width:5%">
                                    <label id="lblVATRate">VAT Rate:</label>
                                    <br /><input type="number" id="txtAmtVATRate" class="form-control" value="0" onchange="CalVATWHT(0)">
                                </td>
                                <td style="width:10%">
                                    <label id="lblVAT">VAT:</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtAmtVAT" onchange="CalNetAmount()" />
                                </td>
                                <td style="width:5%">
                                    <label id="lblWTRate">W/T :</label>
                                    <br /><input type="number" id="txtAmtWHTRate" class="form-control" value="0" onchange="CalVATWHT(1)">
                                </td>
                                <td style="width:10%">
                                    <label id="lblWT">WH-Tax:</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtAmtWHT" onchange="CalNetAmount()" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width:20%">
                                    <label id="lblNetAmt">NET :</label>
                                    <br />
                                    <input type="text" class="form-control" id="txtAmtNET" onchange="CalNetAmount()" />
                                </td>
                                <td style="width:10%">
                                    <br />
                                    <a href="#" class="btn btn-success" id="btnSplit" onclick="UpdateData()">
                                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkUpdate">Update Data</b>
                                    </a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    let arr = [];
    let arr_split = {};
    let arr_clr = [];
    let chq = [];
    let jt = '';
    let creditlimit = 0;
    //$(document).ready(function () {
    //Load params
    let branch = getQueryString("branch");
    let code = getQueryString("code");
    let custcode = getQueryString("custcode");
    let custbranch = getQueryString("custbranch");
    let billtocustcode = '';
    let billtocustbranch = '';

    if (branch !== '' && code !== '') {
        $('#txtBranchCode').val(branch);
        ShowBranch(path, branch, '#txtBranchName');
        $('#txtJobNo').val(code.toUpperCase());
        $.get(path + 'JobOrder/GetJobSQL?Branch=' + branch + '&JNo=' + code.toUpperCase(), function (dr) {
            if (dr.job.data.length > 0) {
                ReadJob(dr.job.data[0]);
            }
        });
    } else {
        if (custcode !== '') {
            $('#txtBranchCode').val(branch);
            ShowBranch(path, branch, '#txtBranchName');

            $('#txtCustCode').val(custcode);
            $('#txtCustBranch').val(custbranch);
            //ShowCustomer(path, custcode, custbranch, '#txtCustName');
            CallBackQueryCustomer(path, custcode, custbranch, ReadCustomer);
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
    }
    //});
    SetEvents();
    function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            return;
        }
        return;
    }
    function SetEvents() {
        //Combos
        let lists = 'JOB_TYPE=#cboJobType';
        lists += ',SHIP_BY=#cboShipBy';
        loadCombos(path, lists);
        //Events
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtCustBranch').keydown(function (event) {
            if (event.which == 13) {
                $('#txtCustName').val('');
                //ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
                CallBackQueryCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), ReadCustomer);
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchBill', '#tbBill', 'Billing Place', response, 3);

            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job', response, 3);
            CreateLOV(dv, '#frmSearchInv', '#tbInv', 'Cancelled Invoice', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency Code', response, 2);
            //Cheque
            CreateLOV(dv, '#frmSearchChq', '#tbChq', 'Customer Cheque', response, 5);
        });

    }
    function SetGridAdv(isAlert) {
        let w = '';
        if ($('#txtJobNo').val() !== "") {
            w = w + '&job=' + $('#txtJobNo').val();
        }
        if ($('#txtCustCode').val() !== "") {
            w = w + '&cust=' + $('#txtCustCode').val();
        }
        if ($('#cboJobType').val() !== "") {
            w = w + '&jtype=' + $('#cboJobType').val();
        }
        if ($('#cboShipBy').val() !== "") {
            w = w + '&sby=' + $('#cboShipBy').val();
        }
        $('#tbHeader').DataTable().clear().draw();
        $.get(path + 'acc/getclearforinv?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.invdetail.data.length == 0) {
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.invdetail.data;
            if (h[0].ClrNo == null) {
                return;
            }
            ClearVariable();
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "JobNo", title: "Job No" },
                    { data: "ClrNo", title: "Clr No" },
                    { data: "CustCode", title: "Customer" },
                    {
                        data: null, title: "Description",
                        render: function (data) {
                            return data.SICode + '-' + data.SDescription + (data.ExpSlipNO == null ? '' : ' #' + data.ExpSlipNO);
                        }
                    },
                    {
                        data: "AmtAdvance", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "AmtCost", title: "Cost",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "AmtCharge", title: "Charge",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "AmtVat", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "Amt50Tavi", title: "WHT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "TotalAmt", title: "NET",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    }
                ],
                responsive: true,
                pageLength: 100,
                createdRow: function (row, data, index) {
                    if ($('#chkSelectAll').prop('checked')) {
                        $(row).addClass('selected')
                    }
                },
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page,
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
                let clearno = $(this).find('td:eq(1)').text();
                //ShowMessage('you click ' + clearno);
                window.open(path + 'Clr/Index?BranchCode=' + $('#txtBranchCode').val() + '&ClrNo=' + clearno);
            });
            if ($('#chkSelectAll').prop('checked')) {
                for (let row of h) {
                    AddData(row);
                }
            }
        });

    }
    function CalSummary() {
        let totaladv = 0;
        let totalcharge = 0;
        let totalistaxcharge = 0;
        let totalis50tavi = 0;
        let totalvat = 0;
        let total50tavi = 0;
        let totalcustadv = 0;
        let totalnet = 0;
        let totalcost = 0;
        let totalsumdisc = 0;

        for (let obj of arr) {
            totaladv += (obj.AmtAdvance > 0 ? CNum(obj.AmtAdvance) : 0);
            totalcharge += (obj.AmtCharge > 0 ? CNum(obj.AmtCharge) : 0);
            totalcost += CNum(obj.AmtCost);
            if (CNum(obj.AmtCharge) > 0) {
                totalistaxcharge += (obj.AmtVat > 0 ? CNum(obj.AmtCharge) : 0);
                totalis50tavi += (obj.Amt50Tavi > 0 ? CNum(obj.AmtCharge) : 0);
                totalvat += CNum(obj.AmtVat);
                total50tavi += CNum(obj.Amt50Tavi);
            }
            totalnet += CNum(obj.AmtNet);
            totalsumdisc += CNum(obj.AmtDiscount);
        }
        for (let c of chq) {
            totalcustadv += CNum(c.ChqAmount);
        }
        $('#txtTotalAdvance').val(CDbl(totaladv, 2));
        $('#txtTotalCharge').val(CDbl(totalcharge, 2));
        $('#txtSumDiscount').val(CDbl(totalsumdisc, 2));
        SetDiscount();
        $('#txtTotalIsTaxCharge').val(CDbl(totalistaxcharge, 2));
        $('#txtTotalIs50Tavi').val(CDbl(totalis50tavi, 2));
        $('#txtTotalVat').val(CDbl(totalvat, 2));
        $('#txtTotalAfter').val(CDbl(totalcharge+totalvat, 2));
        $('#txtTotal50Tavi').val(CDbl(total50tavi, 2));
        $('#txtTotalService').val(CDbl(totalcharge+totalvat-total50tavi, 2));
        $('#txtTotalNet').val(CDbl(totalnet-totalcustadv, 2));
        $('#txtTotalCustAdv').val(CDbl(totalcustadv, 2));

        $('#txtCurrencyCode').val('@ViewBag.PROFILE_CURRENCY');
        $('#txtExchangeRate').val(1);
        $('#txtTotalCost').val(CDbl(totalcost, 2));
        $('#txtTotalProfit').val(CDbl(totalcharge - totalcost, 2));

        CalTotal();

        ShowDetail();
    }
    function ShowSummary() {
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            return;
        }
        if (arr.length == 0) {
            ShowMessage('No data to approve',true);
            return;
        }

        CalSummary();

        $('#txtDocNo').val('');
        $('#btnGen').show();
        $('#dvCreate').modal('show');
    }
    function ShowDetail() {
        arr_split = {};
        let arr_sel = arr.filter(function (d) {
            return d.AmtCharge > 0 || d.AmtAdvance > 0;
        });
        let tb=$('#tbDetail').DataTable({
            data: arr_sel,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: null, title: "#" },
                { data: "JobNo", title: "Job No" },
                {
                    data: null, title: "Description",
                    render: function (data) {
                        return data.SICode + '-' + data.SDescription + (data.ExpSlipNO == null ? '' : ' #' + data.ExpSlipNO);
                    }
                },
                { data: "ExpSlipNO", title: "Slip No" },
                {
                    data: "AmtAdvance", title: "Advance",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "AmtCharge", title: "Charge",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "AmtVat", title: "VAT",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "Amt50Tavi", title: "WHT",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "AmtNet", title: "NET",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                }
            ],
            responsive:true,
            destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            columnDefs: [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-warning'>Edit</button>";
                    return html;
                }
            }
            ],
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail tbody').on('click','button', function () {
            let data = GetSelect('#tbDetail',this); //read current row selected
            //if (data.ClrNo !== '') {
                LoadClearDetail(data);
            //}
        });
        let arr_cost = arr.filter(function (d) {
            return d.AmtCost > 0;
        });
        let tb1=$('#tbCost').DataTable({
            data: arr_cost,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "JobNo", title: "Job No" },
                {
                    data: null, title: "Description",
                    render: function (data) {
                        return data.SICode + '-' + data.SDescription + (data.ExpSlipNO == null ? '' : ' #' + data.ExpSlipNO);
                    }
                },
                { data: "ExpSlipNO", title: "Slip No" },
                {
                    data: "AmtCost", title: "Amount",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "AmtVat", title: "VAT",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "Amt50Tavi", title: "WHT",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                },
                {
                    data: "AmtNet", title: "NET",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                }
            ],
            responsive:true,
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbCost');
    }

    function UpdateData() {
        let arr_new = JSON.parse(JSON.stringify(arr_split));
        let old_amt = ShowNumber(CNum(arr_new.AmtAdvance) + CNum(arr_new.AmtCharge)+ CNum(arr_new.AmtDiscount), 2);
        //if amount changed
        if (ShowNumber(CNum($('#txtAmtAdvance').val()) + CNum($('#txtAmtCharge').val()), 2) !== old_amt) {
            arr_new.ClrItemNo = 0;
            arr_new.AmtDiscount = CNum($('#txtAmtDiscount').val());
            arr_new.DiscountPerc = CNum($('#txtAmtDiscountPerc').val());
            if (arr_new.AmtCharge > 0) {
                arr_new.AmtCharge = CNum($('#txtAmtCharge').val())-CNum($('#txtAmtDiscount').val());
                arr_new.IsTaxCharge = CNum($('#txtAmtVATRate').val()) > 0 ? 1 : 0;
                arr_new.Is50Tavi = CNum($('#txtAmtWHTRate').val()) > 0 ? 1 : 0;
                arr_new.VATRate = CNum($('#txtAmtVATRate').val());
                arr_new.Rate50Tavi = CNum($('#txtAmtWHTRate').val());
                arr_new.AmtVat = CNum($('#txtAmtVAT').val());
                arr_new.Amt50Tavi = CNum($('#txtAmtWHT').val());
            }
            if (arr_new.AmtAdvance > 0) {
                arr_new.AmtAdvance = CNum($('#txtAmtAdvance').val())-CNum($('#txtAmtDiscount').val());
            }
            arr_new.TotalAmt = CNum($('#txtAmtNET').val());
            arr_new.Qty = $('#txtAmtQty').val();
            arr_new.QtyUnit = $('#txtAmtUnit').val();
            SaveClearDetail(arr_new);
        } else {
            arr_split.AmtDiscount = CNum($('#txtAmtDiscount').val());
            arr_split.DiscountPerc = CNum($('#txtAmtDiscountPerc').val());
            arr_split.Qty = $('#txtAmtQty').val();
            arr_split.QtyUnit = $('#txtAmtUnit').val();
            if (arr_split.AmtAdvance > 0) {
                arr_split.AmtAdvance = CNum($('#txtAmtAdvance').val())-CNum($('#txtAmtDiscount').val());
            }
            if (arr_split.AmtCharge > 0) {
                arr_split.AmtCharge = CNum($('#txtAmtCharge').val())-CNum($('#txtAmtDiscount').val());
                arr_split.IsTaxCharge = CNum($('#txtAmtVATRate').val()) > 0 ? 1 : 0;
                arr_split.Is50Tavi = CNum($('#txtAmtWHTRate').val()) > 0 ? 1 : 0;
                arr_split.VATRate = CNum($('#txtAmtVATRate').val());
                arr_split.Rate50Tavi = CNum($('#txtAmtWHTRate').val());
                arr_split.AmtVat = CNum($('#txtAmtVAT').val());
                arr_split.Amt50Tavi = CNum($('#txtAmtWHT').val());
            }
            arr_split.TotalAmt = CNum($('#txtAmtNET').val());
            CalSummary();
            $('#dvEditor').modal('hide');
        }
    }
    function SaveClearDetail(dr) {
        //process old clear data
        if (dr.AmtAdvance > 0) {
            arr_clr[0].BNet -= CNum(dr.AmtAdvance);
            arr_clr[0].FNet -= CDbl((dr.AmtAdvance / dr.ExchangeRate),4);
            arr_clr[0].UsedAmount -= CDbl((dr.AmtAdvance * (100 / (100 + dr.VATRate))),4);
            if (dr.IsTaxCharge > 0) {
                arr_clr[0].ChargeVAT = CDbl((arr_clr[0].UsedAmount * (dr.VATRate*0.01)),4);
            } else {
                arr_clr[0].ChargeVAT = 0;
            }
            if (dr.Is50Tavi > 0) {
                arr_clr[0].Tax50Tavi= CDbl((arr_clr[0].UsedAmount * (dr.Rate50Tavi*0.01)),4);
            } else {
                arr_clr[0].Tax50Tavi = 0;
            }
        } else {
            arr_clr[0].UsedAmount -= CNum(dr.AmtCharge);
            arr_clr[0].ChargeVAT -= CNum(dr.AmtVat);
            arr_clr[0].Tax50Tavi -= CNum(dr.Amt50Tavi);
            arr_clr[0].BNet -= CDbl((CNum(dr.AmtCharge) + CNum(dr.AmtVat) - CNum(dr.Amt50Tavi)),4);
            arr_clr[0].FNet = CDbl((arr_clr[0].BNet / dr.ExchangeRate),4);
        }
        //create new clear data
        let cl = JSON.parse(JSON.stringify(arr_clr[0]));
        cl.ItemNo = 0;
        if (dr.AmtAdvance > 0) {
            cl.BNet = CNum(dr.AmtAdvance);
            cl.FNet = CDbl((dr.AmtAdvance / dr.ExchangeRate),4);
            cl.UsedAmount = CDbl((cl.BNet * (100 / (100 + CNum(dr.VATRate)))),4);
            if (dr.IsTaxCharge > 0) {
                cl.ChargeVAT = CDbl((CNum(cl.UsedAmount) * (dr.VATRate*0.01)),4);
            } else {
                cl.ChargeVAT = 0;
            }
            if (dr.Is50Tavi > 0) {
                cl.Tax50Tavi= CDbl((CNum(cl.UsedAmount) * (dr.Rate50Tavi*0.01)),4);
            } else {
                cl.Tax50Tavi = 0;
            }
        } else {
            cl.UsedAmount = CNum(dr.AmtCharge);
            cl.ChargeVAT = CNum(dr.AmtVat);
            cl.Tax50Tavi = CNum(dr.Amt50Tavi);
            cl.BNet = CDbl((CNum(dr.AmtCharge) + CNum(dr.AmtVat) - CNum(dr.Amt50Tavi)),4);
            cl.FNet = CDbl((cl.BNet / dr.ExchangeRate),4);
        }
        cl.Qty = dr.Qty;
        cl.UnitCode = dr.QtyUnit;
        arr_clr.push(cl);

        arr.push(dr);

        let jsonString = JSON.stringify({ data: arr_clr });
        //ShowMessage(jsonString);
        $.ajax({
            url: "@Url.Action("SaveClearDetail", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    ShowMessage(response.result.msg);
                    arr.splice(arr.indexOf(arr_split), 1);
                    CalSummary();
                    $('#dvEditor').modal('hide');
                }
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function LoadClearDetail(dr) {
        arr_split = dr;
        arr_clr = [];
        $('#lblClrNo').text(dr.ClrNoList);
        $('#lblJobNo').text(dr.JobNo);
        $('#lblSICode').text(dr.SICode);
        $('#lblSDescription').text(dr.SDescription);
        $('#txtAmtQty').val(dr.Qty);
        $('#txtAmtUnit').val(dr.QtyUnit);
        $('#txtAmtVATRate').val(CNum(dr.VATRate));
        $('#txtAmtWHTRate').val(CNum(dr.Rate50Tavi));


        if (dr.AmtAdvance > 0) {
            $('#txtAmtCharge').val(0);
                $('#txtAmtCharge').attr('disabled', 'disabled');
                $('#txtAmtAdvance').removeAttr('disabled');
                $('#txtAmtVAT').attr('disabled', 'disabled');
                $('#txtAmtWHT').attr('disabled', 'disabled');
                $('#txtAmtVATRate').attr('disabled', 'disabled');
                $('#txtAmtWHTRate').attr('disabled', 'disabled');
                $('#txtAmtAdvance').val(CDbl((dr.AmtAdvance+dr.AmtDiscount),2));
        } else {
            $('#txtAmtAdvance').val(0);
                $('#txtAmtAdvance').attr('disabled', 'disabled');
                $('#txtAmtCharge').removeAttr('disabled');
                $('#txtAmtVAT').removeAttr('disabled');
                $('#txtAmtWHT').removeAttr('disabled');
                $('#txtAmtVATRate').removeAttr('disabled');
                $('#txtAmtWHTRate').removeAttr('disabled');
                $('#txtAmtCharge').val(CDbl((dr.AmtCharge+dr.AmtDiscount),2));
            }
            $('#txtAmtVAT').val(CDbl(dr.AmtVat,2));
            $('#txtAmtWHT').val(CDbl(dr.Amt50Tavi,2));
            $('#txtAmtNET').val(CDbl(dr.TotalAmt,2));
            $('#txtAmtDiscountPerc').val(dr.DiscountPerc);
            $('#txtAmtDiscount').val(CDbl(dr.AmtDiscount,2));
            //CalVATWHT(0);
        if (dr.ClrNo !== '') {
            $('#btnSplit').attr('disabled', 'disabled');
            $.get(path + 'Clr/GetClrDetail?Branch=' + dr.BranchCode + '&Code=' + dr.ClrNo + '&Item=' + dr.ClrItemNo, function (res) {
                if (res.clr.detail.length > 0) {
                    let row = res.clr.detail[0];
                    arr_clr = [];
                    arr_clr.push(row);
                    $('#btnSplit').removeAttr('disabled');
                    $('#dvEditor').modal('show');
                }
            });
        } else {
            $('#txtAmtAdvance').attr('disabled', 'disabled');
            $('#txtAmtCharge').attr('disabled', 'disabled');
            $('#dvEditor').modal('show');
        }
    }
    function AddData(o) {
        let idx = arr.indexOf(o);
        if (idx < 0) {
            arr.push(o);
        }
    }
    function RemoveData(o) {
        let idx = arr.indexOf(o);
        if (idx < 0) {
            return;
        }
        arr.splice(idx, 1);
    }
    function ApproveData() {
        if (userRights.indexOf('I') < 0) {
            ShowMessage('You are not allow to add',true);
            return;
        }
        if (arr.length==0) {
            ShowMessage('No data to approve',true);
            return;
        }
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            return;
        }
        if ($('#txtDocNo').val() !== '') {
            DeleteDetail();
        } else {
            SaveHeader();
        }

        return;
    }
    function SaveHeader() {
        let dataInv =GetDataHeader();
        let jsonString = JSON.stringify({ data: dataInv });
        $.ajax({
            url: "@Url.Action("SetInvHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    if (chq.length > 0) {
                        SaveCheque(response.result.data);
                    }
                    if ($('#txtDocNo').val() == '') {
                        SaveDetail(response.result.data);
                    }
                    ShowMessage(response.result.data);
                    $('#dvCreate').modal('hide');

                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function GetRefNo() {
        let joblist = [];
        let retstr = '';
        for (let obj of arr) {
            if (joblist.indexOf(obj.JobNo) < 0) {
                joblist.push(obj.JobNo);
                if (retstr !== '') retstr += ',';
                retstr += obj.JobNo;
            }
        }
        return retstr;
    }
    function SaveCheque(docno) {
        let list = [];
        for (let o of chq) {
            list.push({
                BranchCode: o.BranchCode,
                ControlNo: o.ControlNo,
                ItemNo: 0,
                DocType: 'INV',
                DocNo: docno,
                DocDate: CDateEN($('#txtDocDate').val()),
                CmpType: 'C',
                CmpCode: o.CustCode,
                CmpBranch: o.CustBranch,
                PaidAmount: CDbl(o.ChqAmount, 2),
                TotalAmount: CDbl(o.ChqAmount, 2),
                acType:'CU'
            });
        }

        let jsonText = JSON.stringify({ data: list });
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetVoucherDoc", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.document !== null) {
                    ShowMessage(response.result.msg);
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
        $.get(path + 'Acc/DelInvDetail?Branch=' + $('#txtBranchCode').val() + '&Code=' + $('#txtDocNo').val()).done(function (r) {
            //if (r.invdetail.data !== null) {
            SaveHeader();
            SaveDetail($('#txtDocNo').val());
            //}
        });
    }
    function SaveDetail(docno) {
        $('#txtDocNo').val(docno);
        let list = GetDataDetail(arr,docno);
        let jsonText = JSON.stringify({ data: list });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SaveInvDetail", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data !== null) {
                        ShowMessage(response.result.msg + '\n=>' + response.result.data);
                        PrintInvoice();
                        ResetData();
                        //$('#btnGen').hide();
                        return;
                    }
                    ShowMessage(response.result.msg,true);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'job':
                SetGridJob(path, '#tbJob', '#frmSearchJob', '?branch=' + $('#txtBranchCode').val() + '&custcode=' + $('#txtCustCode').val(), ReadJob);
                break;
            case 'invoice':
                SetGridInv(path, '#tbInv', '#frmSearchInv', '?cancel=Y' ,ReadInv);
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
            case 'chequecust':
                SetGridCheque(path, '#tbChq', '#frmSearchChq', '?type=CU&Cancel=N&Branch=' + $('#txtBranchCode').val(), ReadCheque);
                break;
        }
    }
    function ReadInv(dt) {
        $('#txtDocNo').val(dt.DocNo);
    }
    function ReadJob(dt) {
        $('#txtJobNo').val(dt.JNo);
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.CustBranch);
        $('#cboJobType').val(CCode(dt.JobType));
        $('#cboShipBy').val(CCode(dt.ShipBy));
        //ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
        CallBackQueryCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), ReadCustomer);
    }
    function ReadCheque(dt) {
        if (dt.AmountRemain > 0) {
            $('#txtChqNo').val(dt.ChqNo);
            let amt = CNum($('#txtTotalNet').val()) + CNum($('#txtTotal50Tavi').val());
            if (dt.AmountRemain <= amt) {
                $('#txtChqAmount').val(CDbl(dt.AmountRemain,2));
            } else {
                $('#txtChqAmount').val(CDbl(amt,2));
            }
            $('#txtControlNo').val(dt.ControlNo);
            return;
        } else {
            ShowMessage('Value must be more than zero',true);
        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        CalForeign();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        //ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
        $('#txtCustName').val(dt.NameThai);
        billtocustcode = dt.BillToCustCode;
        billtocustbranch = dt.BillToBranch;
        $('#txtBillToCustCode').val(billtocustcode);
        $('#txtBillToCustBranch').val(billtocustbranch);
        ShowCustomer(path, billtocustcode, billtocustbranch, '#txtBillToCustName');
        creditlimit = dt.CreditLimit;
        $('#txtCustCode').focus();
    }
    function ReadBilling(dt) {
        $('#txtBillToCustCode').val(dt.CustCode);
        $('#txtBillToCustBranch').val(dt.Branch);
        //ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
        $('#txtBillToCustName').val(dt.NameThai);
        billtocustcode = dt.BillToCustCode;
        billtocustbranch = dt.BillToBranch;
        creditlimit = dt.CreditLimit;
    }
    function GetDueDate(d) {
        let addDays = CNum(creditlimit);
        if (addDays > 0) {
            let dinput = new Date(d);
            let day = dinput.getDay() + addDays;
            let month = dinput.getMonth;
            let year = dinput.getFullYear;
            let doutput = new Date(year, month, day);
            return CDateEN(doutput);
        }
        return '';
    }
    function GetDataDetail(o, no) {
        let data = [];
        let i = 0;
        let custadv = CNum($('#txtTotalCustAdv').val());
        for (let obj of o) {
            if (obj.AmtCharge > 0 || obj.AmtAdvance > 0) {
                let creditamt = 0;
                if (custadv > 0) {
                    if (custadv - (CNum(obj.AmtNet) + CNum(obj.Amt50Tavi)) < 0) {
                        creditamt = custadv;
                    } else {
                        creditamt = (CNum(obj.AmtNet) + CNum(obj.Amt50Tavi));
                    }
                    custadv -= creditamt;
                } else {
                    custadv=0
                }
                i = i + 1;
                data.push({
                    BranchCode: obj.BranchCode,
                    ClrNoList: obj.ClrNoList,
                    DocNo: no,
                    ItemNo: i,
                    SICode: obj.SICode,
                    SDescription: obj.SDescription,
                    ExpSlipNO: obj.ExpSlipNO,
                    SRemark: obj.SRemark,
                    CurrencyCode: $('#txtCurrencyCode').val(),
                    ExchangeRate: $('#txtExchangeRate').val(),
                    Qty: CNum(obj.Qty),
                    QtyUnit: obj.QtyUnit,
                    UnitPrice: obj.UnitPrice,
                    FUnitPrice: CDbl(obj.UnitPrice / CNum($('#txtExchangeRate').val()), 2),
                    Amt: CDbl(obj.Amt,2),
                    FAmt: CDbl(obj.Amt / CNum($('#txtExchangeRate').val()), 2),
                    DiscountType: obj.DiscountType,
                    DiscountPerc: obj.DiscountPerc,
                    AmtDiscount: CDbl(obj.AmtDiscount,2),
                    FAmtDiscount: CDbl(obj.AmtDiscount / CNum($('#txtExchangeRate').val()), 2),
                    Is50Tavi: obj.Is50Tavi,
                    Rate50Tavi: obj.Rate50Tavi,
                    Amt50Tavi: CDbl(obj.Amt50Tavi,2),
                    IsTaxCharge: obj.IsTaxCharge,
                    AmtVat: CDbl(obj.AmtVat,2),
                    TotalAmt: CDbl(obj.AmtNet,2),
                    FTotalAmt: CDbl(obj.AmtNet / CNum($('#txtExchangeRate').val()), 2),
                    AmtAdvance: (obj.AmtAdvance > 0 ? CDbl(obj.AmtAdvance  / CNum($('#txtExchangeRate').val()),2) : 0),
                    AmtCharge: (obj.AmtCharge > 0 ? CDbl(obj.AmtCharge  / CNum($('#txtExchangeRate').val()),2) : 0),
                    CurrencyCodeCredit: $('#txtCurrencyCode').val(),
                    ExchangeRateCredit: $('#txtExchangeRate').val(),
                    AmtCredit: (creditamt >0 ? CDbl((creditamt-CNum(obj.Amt50Tavi)),2) : 0),
                    FAmtCredit: (creditamt > 0 ? CDbl((creditamt - CNum(obj.Amt50Tavi)) / CNum($('#txtExchangeRate').val()), 2) : 0),
                    VATRate: CDbl(obj.VATRate,0)
                });
            } else {
                data.push({
                    BranchCode: obj.BranchCode,
                    ClrNoList: obj.ClrNoList,
                    DocNo: no,
                    ItemNo: 0,
                    SICode: obj.SICode,
                    SDescription: obj.SDescription,
                    ExpSlipNO: obj.ExpSlipNO,
                    SRemark: obj.SRemark,
                    CurrencyCode: $('#txtCurrencyCode').val(),
                    ExchangeRate: $('#txtExchangeRate').val(),
                    Qty: obj.Qty,
                    QtyUnit: obj.QtyUnit,
                    UnitPrice: obj.UnitPrice,
                    FUnitPrice: CDbl(obj.UnitPrice / CNum($('#txtExchangeRate').val()), 2),
                    Amt: obj.Amt,
                    FAmt: CDbl(obj.Amt / CNum($('#txtExchangeRate').val()), 2),
                    DiscountType: obj.DiscountType,
                    DiscountPerc: obj.DiscountPerc,
                    AmtDiscount: obj.AmtDiscount,
                    FAmtDiscount: CDbl(obj.AmtDiscount / CNum($('#txtExchangeRate').val()), 2),
                    Is50Tavi: obj.Is50Tavi,
                    Rate50Tavi: obj.Rate50Tavi,
                    Amt50Tavi: obj.Amt50Tavi,
                    IsTaxCharge: obj.IsTaxCharge,
                    AmtVat: obj.AmtVat,
                    TotalAmt: obj.TotalAmt,
                    FTotalAmt: CDbl(obj.TotalAmt / CNum($('#txtExchangeRate').val()), 2),
                    AmtAdvance: obj.AmtAdvance,
                    AmtCharge: obj.AmtCharge,
                    CurrencyCodeCredit: obj.CurrencyCodeCredit,
                    ExchangeRateCredit: obj.ExchangeRateCredit,
                    AmtCredit: obj.AmtCredit,
                    FAmtCredit: CDbl(obj.FAmtCredit / CNum($('#txtExchangeRate').val()), 2),
                    VATRate: obj.VATRate
                });
            }
        }
        return data;
    }
    function PrintInvoice() {
        let code = $('#txtDocNo').val();
        if (code !== '') {
            let branch = $('#txtBranchCode').val();
            window.open(path + 'Acc/FormInv?Branch=' + branch + '&Code=' + code,'_blank');
        }
    }
    function MergeData() {
        let arr_cost = arr.filter(function (d) {
            return d.AmtCost > 0;
        });
        let arr_new = [];
        if (arr_cost.length > 0) {
            arr_new=arr_cost;
        }

        let arr_sel = arr.filter(function (d) {
            return d.AmtCharge > 0 || d.AmtAdvance > 0;
        });
        sortData(arr_sel, 'SICode', 'asc');
        sortData(arr_sel, 'UnitPrice', 'asc');

        let slipList = '';
        let clearList = '';
        let currCode = '';
        let key = {};
        let itemNo = 0;
        let rowProcess = 0;
        let checkData = '';
        for (obj of arr_sel) {
            rowProcess += 1;
            checkData = obj.SICode + '' + obj.UnitPrice;
            if (currCode !== checkData) {
                if (currCode !== '') {
                    key.ClrNo = '';
                    key.ClrItemNo = 0;
                    key.ClrNoList = clearList;
                    key.ExpSlipNO = slipList;
                    key.UnitPrice = CNum(key.Amt) / CNum(key.Qty);
                    key.FUnitPrice = CDbl(CNum(key.UnitPrice) / CNum(obj.ExchangeRate), 2);
                    arr_new.push(key);
                }
                currCode = obj.SICode + '' + obj.UnitPrice;
                itemNo += 1;
                key = obj;
                key.ItemNo = itemNo;
                slipList = '';
                clearList = '';
            } else {
                key.Qty+= CNum(obj.Qty);
                key.Amt+= CNum(obj.Amt);
                key.FAmt= CNum(key.Amt) / CNum(obj.ExchangeRate);
                key.AmtDiscount+= CNum(obj.AmtDiscount);
                key.FAmtDiscount+= CNum(key.AmtDiscount) / CNum(obj.ExchangeRate);
                key.Amt50Tavi += CNum(obj.Amt50Tavi);
                key.AmtVat+= CNum(obj.AmtVat);
                key.TotalAmt += CNum(obj.TotalAmt);
                key.AmtNet += CNum(obj.TotalAmt);
                key.FTotalAmt= CDbl(CNum(key.TotalAmt) / CNum(obj.ExchangeRate), 2);
                key.AmtAdvance+= CNum(obj.AmtAdvance);
                key.AmtCharge+= CNum(obj.AmtCharge);
                key.AmtCredit+= CNum(obj.AmtCredit);
                key.FAmtCredit= CDbl(CNum(key.FAmtCredit) / CNum(obj.ExchangeRate), 2);
            }
            if (clearList.indexOf((obj.ClrNo + '/' + obj.ClrItemNo)) < 0) {
                clearList += (clearList !== '' ? ',' : '') + (obj.ClrNo + '/' + obj.ClrItemNo);
            }
            if (obj.ExpSlipNO !== null) {
                if (slipList.indexOf(obj.ExpSlipNO) < 0) {
                    slipList += (slipList !== '' ? ',' : '') + obj.ExpSlipNO;
                }
            }
            if (rowProcess==arr_sel.length) {
                key.ClrNo = '';
                key.ClrItemNo = 0;
                key.ClrNoList = clearList;
                key.ExpSlipNO = slipList;
                key.UnitPrice = CNum(key.Amt) / CNum(key.Qty);
                key.FUnitPrice = CDbl(CNum(key.UnitPrice) / CNum(obj.ExchangeRate), 2);
                arr_new.push(key);
            }
        }
        arr = arr_new;
        CalSummary();
    }
    function ClearVariable() {
        arr = [];
        arr_split = {};
        arr_clr = [];
        chq = [];
    }
    function ResetData() {
        ClearVariable();
        SetGridAdv(true);
    }
    function AddCheque() {
        let c = {
            BranchCode: $('#txtBranchCode').val(),
            ControlNo: $('#txtControlNo').val(),
            CustCode: $('#txtCustCode').val(),
            CustBranch: $('#txtCustBranch').val(),
            ChqNo: $('#txtChqNo').val(),
            ChqAmount: $('#txtChqAmount').val()
        };
        if (c.ChqAmount <= (CNum($('#txtTotalNet').val()) + CNum($('#txtTotal50Tavi').val()))) {
            $('#txtChqAmount').val(CDbl(c.ChqAmount,2));
        } else {
            //ShowMessage('Cheque Amount is more than total invoices', true);
            c.ChqAmount = (CNum($('#txtTotalNet').val()) + CNum($('#txtTotal50Tavi').val()));
            $('#txtChqAmount').val(CDbl((CNum($('#txtTotalNet').val()) + CNum($('#txtTotal50Tavi').val())),2));
        }
        if (chq.indexOf(c) < 0) {
            chq.push(c);
        } else {
            ShowMessage('This data is duplicate',true);
            return;
        }
        $('#txtChqNo').val('');
        $('#txtControlNo').val('');
        $('#txtChqAmount').val(0);
        ShowCheque();
        ShowSummary();
    }
    function ShowCheque() {
        let tb=$('#tbCheque').DataTable({
            data: chq,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: null, title: "#" },
                { data: "ChqNo", title: "Cheque No" },
                {
                    data: "ChqAmount", title: "Amount",
                    render: function (data) {
                        return ShowNumber(data, 2);
                    }
                }
            ],
            columnDefs: [ //กำหนด control เพิ่มเติมในแต่ละแถว
            {
                "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                "data": null,
                "render": function (data, type, full, meta) {
                    let html = "<button class='btn btn-danger'>Delete</button>";
                    return html;
                }
            }
            ],
            responsive:true,
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbCheque');
        $('#tbCheque tbody').on('click', 'button', function () {
            let dt = GetSelect('#tbCheque', this); //read current row selected
            if (chq.indexOf(dt) >= 0) {
                chq.splice(chq.indexOf(dt));
                ShowCheque();
                ShowSummary();
            }
        });
    }
    function CalVATWHT(step = 0) {
        let amt = CNum($('#txtAmtCharge').val())-CNum($('#txtAmtDiscount').val());
        if (step == 0) {
            let vat = amt * CNum($('#txtAmtVATRate').val()) * 0.01;
            $('#txtAmtVAT').val(ShowNumber(vat,2));
        }
        let wht = amt * CNum($('#txtAmtWHTRate').val()) * 0.01;
        $('#txtAmtWHT').val(ShowNumber(wht, 2));
        CalNetAmount();
    }
    function CalDiscount() {
        let amt = CNum($('#txtAmtAdvance').val()) + CNum($('#txtAmtCharge').val());
        let disc = amt * CNum($('#txtAmtDiscountPerc').val()) * 0.01;
        $('#txtAmtDiscount').val(ShowNumber(disc,2));
        CalVATWHT(0);
    }
    function SetDiscount() {
        let amt = CNum($('#txtTotalAdvance').val()) + CNum($('#txtTotalCharge').val()) + CNum($('#txtTotalVat').val()) - CNum($('#txtTotal50Tavi').val()) - CNum($('#txtTotalCustAdv').val());
        let disc = amt * CNum($('#txtDiscountRate').val()) * 0.01;
        $('#txtCalDiscount').val(ShowNumber(disc,2));
        SumDiscount();
    }
    function SumDiscount() {
        let totaldisc = CNum($('#txtCalDiscount').val());
        $('#txtTotalDiscount').val(ShowNumber(totaldisc,2));
        CalTotal();
    }
    function CalTotal() {
        let totalnet = CNum($('#txtTotalAdvance').val()) + CNum($('#txtTotalCharge').val()) + CNum($('#txtTotalVat').val()) - CNum($('#txtTotal50Tavi').val()) - CNum($('#txtTotalCustAdv').val()) - CNum($('#txtCalDiscount').val());
        if (CNum($('#txtTotalCustAdv').val()) > 0) {
            //alert(CNum($('#txtTotalCustAdv').val()));
            totalnet += CNum($('#txtTotal50Tavi').val());
        }
        $('#txtTotalNet').val(ShowNumber(totalnet, 2));
        let totalamt = CNum($('#txtTotalCharge').val()) - CNum($('#txtCalDiscount').val());
        $('#txtTotalProfit').val(ShowNumber(CNum(totalamt) - CNum($('#txtTotalCost').val()), 2));

        CalForeign();
    }
    function CalForeign() {
        let totalforeign = CDbl(CNum($('#txtTotalNet').val()) / CNum($('#txtExchangeRate').val()), 2);
        $('#txtForeignNet').val(ShowNumber(totalforeign,2));
    }
    function CalNetAmount() {
        let amt = CNum($('#txtAmtAdvance').val()) + CNum($('#txtAmtCharge').val());
        let vat = CNum($('#txtAmtVAT').val());
        let wht = CNum($('#txtAmtWHT').val());
        let disc = CNum($('#txtAmtDiscount').val());
        let net = amt-disc+ vat - wht;

        $('#txtAmtNET').val(ShowNumber(net,2));
    }
    function GetDataHeader() {
        let duedate = GetDueDate($('#txtDocDate').val());
        return {
            BranchCode: $('#txtBranchCode').val(),
            DocNo: $('#txtDocNo').val(),
            DocType: $('#cboDocType').val(),
            DocDate: CDateEN($('#txtDocDate').val()),
            CustCode: $('#txtCustCode').val(),
            CustBranch: $('#txtCustBranch').val(),
            BillToCustCode: billtocustcode,
            BillToCustBranch: billtocustbranch,
            ContactName: '',
            EmpCode: user,
            PrintedBy: '',
            PrintedDate: null,
            PrintedTime: null,
            RefNo: GetRefNo(),
            VATRate: CNum(CNum(@ViewBag.PROFILE_VATRATE) * 100),
            TotalAdvance: CNum($('#txtTotalAdvance').val()),
            TotalCharge: CNum($('#txtTotalCharge').val()),
            TotalIsTaxCharge: CNum($('#txtTotalIsTaxCharge').val()),
            TotalIs50Tavi: CNum($('#txtTotalIs50Tavi').val()),
            TotalVAT: CNum($('#txtTotalVat').val()),
            Total50Tavi: CNum($('#txtTotal50Tavi').val()),
            TotalCustAdv: CNum($('#txtTotalCustAdv').val()),
            TotalNet: CNum($('#txtTotalNet').val()),
            CurrencyCode: $('#txtCurrencyCode').val(),
            ExchangeRate: CNum($('#txtExchangeRate').val()),
            ForeignNet: CNum($('#txtForeignNet').val()),
            TotalDiscount: CNum($('#txtTotalDiscount').val()),
            SumDiscount: CNum($('#txtSumDiscount').val()),
            DiscountRate: CNum($('#txtDiscountRate').val()),
            CalDiscount: CNum($('#txtCalDiscount').val()),
            BillAcceptDate: null,
            BillIssueDate: null,
            BillAcceptNo: '',
            Remark1: '',
            Remark2: '',
            Remark3: '',
            Remark4: '',
            Remark5: '',
            Remark6: '',
            Remark7: '',
            Remark8: '',
            Remark9: '',
            Remark10: '',
            CancelReson: '',
            CancelProve: '',
            CancelDate: null,
            CancelTime: null,
            ShippingRemark: 'DUE DATE:' +  duedate,
            DueDate: duedate=''? null : duedate,
            CreateDate: CDateEN(GetToday())
        };
    }
    function SetTempInv() {
        if (arr.length > 0) {
            let jobno = arr[0].JobNo;
            let branchjob = arr[0].BranchCode;
            localStorage.setItem('invjob', '');
            if (jobno !== '') {
                $.get(path + 'JobOrder/GetJobSQL?Branch=' + branchjob + '&JNo=' + jobno, function (r) {
                    if (r.job.data !== undefined) {
                        localStorage.setItem('invjob', '[' + JSON.stringify(r.job.data) + ']');
                    }
                });
            }
            let det = GetDataDetail(arr, '').filter(function (d) {
                return d.ItemNo > 0;
            });
            let strHeader = '[' + JSON.stringify(GetDataHeader()) + ']';
            let strDetail = JSON.stringify(det);
            localStorage.setItem('invheader', strHeader);
            localStorage.setItem('invdetail', strDetail);

            window.open(path + 'Acc/FormInv', '_blank');
        }
    }
</script>