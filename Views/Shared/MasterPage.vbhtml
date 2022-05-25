<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="~/Content/Site.css">
    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <link rel="stylesheet" href="~/Content/bootstrap-select.min.css">
    <link rel="stylesheet" href="~/Content/jquery.datatables.min.css">
    <link rel="stylesheet" href="~/Content/responsive.dataTables.min.css">
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/DataTables/dataTables.responsive.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootbox.js"></script>
    <script src="~/Scripts/bootstrap-select.js"></script>
    <script src="~/Scripts/Func/util.js?@DateTime.Now.Ticks"></script>
    <script src="~/Scripts/Func/popup.js?@DateTime.Now.Ticks"></script>
    <script src="~/Scripts/Func/combo.js?@DateTime.Now.Ticks"></script>
    <script src="~/Scripts/Func/menu.js?@DateTime.Now.Ticks"></script>
    <script src="~/Scripts/Func/lang.js?@DateTime.Now.Ticks"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    @Select Case ViewBag.DATABASE
        Case "1"
            @<style>
		#color_body,.panel-body{
			background-color: #f1fce6 !important;
		}

		#color_selectMenu,#color_side,#color_header{
			background-color: #008080 !important;
		}
            </style>
        Case "2"
            @<style>
		#color_body,.panel-body{
			background-color: #c0eef8 !important;
		}

		#color_selectMenu,#color_side,#color_header{
			background-color: #3f51b5 !important;
		}
            </style>
        Case "3"
            @<style>
		#color_body,.panel-body{
			background-color: #ffffff !important;
		}

		#color_selectMenu,#color_side,#color_header{
			background-color: #0e2516 !important;
		}
            </style>
    End Select
  

</head>
<body style="background:#e6e6e6;color:black;">
    <!-- Sidebar -->
    <div class="w3-sidebar w3-bar-block w3-animate-left" style="display:none;z-index:5" id="mySidebar">
        <div id="color_side"class="w3-sidebar w3-bar-block w3-indigo w3-card btn-success" style="width: 250px; ">
            <div id="color_selectMenu" style="">
                Select Menu :
                <select id="cboMenu" onchange="SwitchMenu()">
                    <option value="D">By Department</option>
                    <option value="W" selected>By Work Flow</option>
                </select>
            </div>
            <div style="width:100%;text-align:center;background-color:white">
                <img id="imgMenu" src="~/Resource/@ViewBag.PROFILE_LOGO" onclick="SetLogout()" style="width:70%;padding:5px 5px 5px 5px;" />
            </div>
            <div style="width:100%;text-align:center;background-color:white;color:black;font-size:11px">
                <label id="lblLicenseName" ondblclick="ReturnMain()">@ViewBag.LICENSE_NAME</label>
            </div>
            <div id="dvCustomerMenu">
                <div id="mainCust" class="w3-bar-item w3-button" onclick="w3_accordion('mnuCust')">
                    Importer/Exporter
                </div>
                <div id="mnuCust" class="w3-hide w3-pale-red w3-card-4">
                    <a href="#" id="mnuCust1" class="w3-bar-item w3-button" onclick="OpenLink('Tracking1')">- Transport Tracking</a>
                    <a href="#" id="mnuCust3" class="w3-bar-item w3-button" onclick="OpenLink('Tracking2')">- Shipment Status</a>
                    <a href="#" id="mnuCust2" class="w3-bar-item w3-button" onclick="OpenLink('CreateJob')">- Shipment Order</a>
                    <a href="#" id="mnuCust4" class="w3-bar-item w3-button" onclick="OpenLink('Document')">- Documents</a>
                </div>
            </div>
            <div id="dvShippingMenu">
                <div id="dvMenuByDept" style="display:none">
                    <div id="mainMkt" class="w3-bar-item w3-button" onclick="w3_accordion('mnuMkt')">
                        Marketing Works
                    </div>
                    <div id="mnuMkt" class="w3-hide w3-pale-green w3-card-4">
                        <a href="#" id="mnuMkt1" class="w3-bar-item w3-button" onclick="OpenLink('Quotation')">- Quotation</a>
                        <a href="#" id="mnuMkt3" class="w3-bar-item w3-button" onclick="OpenLink('EstimateCost')">- Estimate Cost</a>
                    </div>
                    <div id="mainCS" class="w3-bar-item w3-button" onclick="w3_accordion('mnuCS')">
                        CS Works
                    </div>
                    <div id="mnuCS" class="w3-hide w3-light-grey w3-card-4">
                        <a href="#" id="mnuCS1" class="w3-bar-item w3-button" onclick="OpenLink('CreateJob')">- Create Job</a>
                        <a href="#" id="mnuCS2" class="w3-bar-item w3-button" onclick="OpenLink('SearchJob')">- List Job</a>
                        <a href="#" id="mnuCS3" class="w3-bar-item w3-button" onclick="OpenLink('Transport')">- Transport Info</a>
                        <a href="#" id="mnuCS4" class="w3-bar-item w3-button" onclick="OpenLink('WHTax')">- Withholding Tax</a>
			<a href="#" id="mnuCS5" class="w3-bar-item w3-button" onclick="OpenLink('AddFuel')">Fuel Refill</a>
                    </div>
                    <div id="mainShp" class="w3-bar-item w3-button" onclick="w3_accordion('mnuShp')">
                        Shipping Works
                    </div>
                    <div id="mnuShp" class="w3-hide w3-khaki w3-card-4">
                        <a href="#" id="mnuShp4" class="w3-bar-item w3-button" onclick="OpenLink('CreateTransport')">- Create BL/AWB</a>
                        <a href="#" id="mnuShp3" class="w3-bar-item w3-button" onclick="OpenLink('Planing')">- Planing</a>
                        <a href="#" id="mnuShp1" class="w3-bar-item w3-button" onclick="OpenLink('Advance')">- Advance</a>
                        <a href="#" id="mnuShp2" class="w3-bar-item w3-button" onclick="OpenLink('Clearing')">- Clearing</a>
                    </div>
                    <div id="mainApp" class="w3-bar-item w3-button" onclick="w3_accordion('mnuApp')">
                        Approving
                    </div>
                    <div id="mnuApp" class="w3-hide w3-pale-yellow w3-card-4">
                        <a href="#" id="mnuMkt2" class="w3-bar-item w3-button" onclick="OpenLink('AppQuo')">- Quotation Confirm</a>
                        <a href="#" id="mnuApp5" class="w3-bar-item w3-button" onclick="OpenLink('AppJob')">- Job Confirm</a>
                        <a href="#" id="mnuApp1" class="w3-bar-item w3-button" onclick="OpenLink('AppAdvance')">- Advance Confirm</a>
                        <a href="#" id="mnuApp2" class="w3-bar-item w3-button" onclick="OpenLink('AppClearing')">- Clearing Confirm</a>
                        <a href="#" id="mnuApp3" class="w3-bar-item w3-button" onclick="OpenLink('AppExpense')">- Expense Confirm</a>
                        <a href="#" id="mnuApp4" class="w3-bar-item w3-button" onclick="OpenLink('AppTransport')">- Transport Confirm</a>
                    </div>
                    <div id="mainFin" class="w3-bar-item w3-button" onclick="w3_accordion('mnuFin')">
                        Finance Works
                    </div>
                    <div id="mnuFin" class="w3-hide w3-pale-blue w3-card-4">
                        <a href="#" id="mnuFin1" class="w3-bar-item w3-button" onclick="OpenLink('PayAdvance')">- Advance Payment</a>
                        <a href="#" id="mnuFin3" class="w3-bar-item w3-button" onclick="OpenLink('RecvClear')">- Clearing Receive</a>
                        <a href="#" id="mnuFin2" class="w3-bar-item w3-button" onclick="OpenLink('Payment')">- Expense Payment</a>
                        <a href="#" id="mnuFin4" class="w3-bar-item w3-button" onclick="OpenLink('RecvInv')">- Invoice Receive</a>
                        <a href="#" id="mnuFin5" class="w3-bar-item w3-button" onclick="OpenLink('Cheque')">- Cheque Management</a>
                        <a href="#" id="mnuFin7" class="w3-bar-item w3-button" onclick="OpenLink('PettyCash')">- Petty Cash</a>
                        <a href="#" id="mnuFin6" class="w3-bar-item w3-button" onclick="OpenLink('CreditAdv')">- Credit Advance</a>
                        <a href="#" id="mnuFin8" class="w3-bar-item w3-button" onclick="OpenLink('Earnest')">- Earnest Clearing</a>
                    </div>
                    <div id="mainAcc" class="w3-bar-item w3-button" onclick="w3_accordion('mnuAcc')">
                        Account Works
                    </div>
                    <div id="mnuAcc" class="w3-hide w3-pale-red w3-card-4">
                        <a href="#" id="mnuAcc1" class="w3-bar-item w3-button" onclick="OpenLink('Voucher')">- Vouchers</a>
                        <a href="#" id="mnuAcc2" class="w3-bar-item w3-button" onclick="OpenLink('Invoice')">- Invoice</a>
                        <a href="#" id="mnuAcc3" class="w3-bar-item w3-button" onclick="OpenLink('Billing')">- Billing</a>
                        <a href="#" id="mnuAcc4" class="w3-bar-item w3-button" onclick="OpenLink('Receipt')">- Receipts</a>
                        <a href="#" id="mnuAcc5" class="w3-bar-item w3-button" onclick="OpenLink('TaxInvoice')">- Tax-invoice</a>
                        <a href="#" id="mnuAcc6" class="w3-bar-item w3-button" onclick="OpenLink('BillPayment')">- Bill Payment</a>
                        <a href="#" id="mnuAcc7" class="w3-bar-item w3-button" onclick="OpenLink('CreditNote')">- Credit/Debit Note</a>
                        <a href="#" id="mnuAcc8" class="w3-bar-item w3-button" onclick="OpenLink('GLNote')">- Journal Entry</a>
                    </div>
                    <div id="mainVend2" class="w3-bar-item w3-button" onclick="w3_accordion('mnuVen')">
                        Vender Works
                    </div>
                    <div id="mnuVen" class="w3-hide w3-pale-red w3-card-4">
                        <a href="#" id="mnuVen0" class="w3-bar-item w3-button" onclick="OpenLink('AppTransport')">- Transport Confirm</a>
                        <a href="#" id="mnuVen1" class="w3-bar-item w3-button" onclick="OpenLink('BillPayment')">- Bill Payment</a>
                        <a href="#" id="mnuVen2" class="w3-bar-item w3-button" onclick="OpenLink('VenderInv')">- Vender Summary</a>
                        <a href="#" id="mnuVen3" class="w3-bar-item w3-button" onclick="OpenLink('Tracking1')">- Transport Tracking</a>
                    </div>
                    <div id="mainRpt" class="w3-bar-item w3-button" onclick="w3_accordion('mnuRpt')">
                        Report & Tracking
                    </div>
                    <div id="mnuRpt" class="w3-hide w3-amber w3-card-4">
                        <a href="#" id="mnuRpt1" class="w3-bar-item w3-button" onclick="OpenLink('Report')">- Reports</a>
                        <a href="#" id="mnuRpt2" class="w3-bar-item w3-button" onclick="OpenLink('Tracking1')">- Transport Tracking</a>
                        <a href="#" id="mnuRpt4" class="w3-bar-item w3-button" onclick="OpenLink('Tracking2')">- Job Timeline</a>
                        <a href="#" id="mnuRpt3" class="w3-bar-item w3-button" onclick="OpenLink('Dashboard')">- Customer Dashboard</a>
                        <a href="#" id="mnuRpt6" class="w3-bar-item w3-button" onclick="OpenLink('Dashboard2')">- Staff Dashboard</a>
                        <a href="#" id="mnuRpt5" class="w3-bar-item w3-button" onclick="OpenLink('Document')">-Document Tracking</a>
                    </div>
                    <div id="mainMas" class="w3-bar-item w3-button" onclick="w3_accordion('mnuMas')">
                        Master Files
                    </div>
                    <div id="mnuMas" class="w3-hide w3-sand w3-card-4">
                        <a href="#" id="mnuMas2" class="w3-bar-item w3-button" onclick="OpenLink('MasA')">- Accounts File</a>
                        <a href="#" id="mnuMas1" class="w3-bar-item w3-button" onclick="OpenLink('MasG')">- Customs File</a>
                        <a href="#" id="mnuMas3" class="w3-bar-item w3-button" onclick="OpenLink('MasS')">- System Files</a>
                    </div>
                    <div id="mainUtil" class="w3-bar-item w3-button" onclick="w3_accordion('mnuUtil')">
                        Utility
                    </div>
                    <div id="mnuUtil" class="w3-hide w3-sand w3-card-4">
                        <a href="#" id="mnuUtil1" class="w3-bar-item w3-button" onclick="OpenLink('Import')">- Import data</a>
                        <a href="#" id="mnuUtil2" class="w3-bar-item w3-button" onclick="OpenLink('Export')">- Export data</a>
                    </div>
                </div>
                <div id="dvMenuByFlow">
                    <div id="mnuMaster" class="w3-bar-item w3-button" onclick="w3_accordion('mnuMasters')">
                        My Master Data
                    </div>
                    <div id="mnuMasters" class="w3-hide w3-card-4 w3-sand">
                        <a href="#" id="mnuMaster1" class="w3-bar-item w3-button" onclick="OpenLink('MasS')">1.System Data</a>
                        <a href="#" id="mnuMaster2" class="w3-bar-item w3-button" onclick="OpenLink('MasG')">2.Customs Data</a>
                        <a href="#" id="mnuMaster3" class="w3-bar-item w3-button" onclick="OpenLink('MasA')">3.Accounts Data</a>
                    </div>
                    <div id="mnuShipments" class="w3-bar-item w3-button" onclick="w3_accordion('mnuOpenJob')">
                        My Shipments
                    </div>
                    <div id="mnuOpenJob" class="w3-hide w3-card-4 w3-light-grey">
                        <a href="#" id="mnuOpenJob1" class="w3-bar-item w3-button" onclick="OpenLink('CreateJob')">1.New Shipment</a>
                        <a href="#" id="mnuOpenJob2" class="w3-bar-item w3-button" onclick="OpenLink('SearchJob')">2.Edit Shipment</a>
                        <a href="#" id="mnuOpenJob3" class="w3-bar-item w3-button" onclick="OpenLink('Transport')">3.Edit Transport</a>
                    </div>
                    <div id="mnuPlaning" class="w3-bar-item w3-button" onclick="w3_accordion('mnuExpenses')">
                        My Services Planning
                    </div>
                    <div id="mnuExpenses" class="w3-hide w3-card-4 w3-pale-yellow">
                        <a href="#" id="mnuExpenses1" class="w3-bar-item w3-button" onclick="OpenLink('Quotation')">1.New Quotation</a>
                        <a href="#" id="mnuExpenses2" class="w3-bar-item w3-button" onclick="OpenLink('TransportRoute')">2.Edit Price Lists</a>
                        <a href="#" id="mnuExpenses3" class="w3-bar-item w3-button" onclick="OpenLink('EstimateCost')">3.Pre-Invoices</a>
                    </div>
                    <div id="mnuAdvExpenses" class="w3-bar-item w3-button" onclick="w3_accordion('mnuAdvances')">
                        My Expenses
                    </div>
                    <div id="mnuAdvances" class="w3-hide w3-card-4 w3-khaki">
                        <a href="#" id="mnuAdvance1" class="w3-bar-item w3-button" onclick="OpenLink('Advance')">1.Advance Requisition</a>
                        <a href="#" id="mnuAdvance2" class="w3-bar-item w3-button" onclick="OpenLink('CreditAdv')">2.Credit Advances</a>
                        <a href="#" id="mnuAdvance3" class="w3-bar-item w3-button" onclick="OpenLink('BillPayment')">3.Accrued Expenses</a>
                    </div>
                    <div id="mnuCosting" class="w3-bar-item w3-button" onclick="w3_accordion('mnuClearances')">
                        My Cost & Services
                    </div>
                    <div id="mnuClearances" class="w3-hide w3-card-4 w3-pale-blue">
                        <a href="#" id="mnuClearance1" class="w3-bar-item w3-button" onclick="OpenLink('Clearing')">1.Expenses Clearing</a>
                        <a href="#" id="mnuClearance2" class="w3-bar-item w3-button" onclick="OpenLink('Earnest')">2.Adjustment Clearing</a>
                    </div>
                    <div id="mnuIncome" class="w3-bar-item w3-button" onclick="w3_accordion('mnuBillings')">
                        My Incomes
                    </div>
                    <div id="mnuBillings" class="w3-hide w3-card-4 w3-pale-green">
                        <a href="#" id="mnuBilling1" class="w3-bar-item w3-button" onclick="OpenLink('Invoice')">1.Create Invoice</a>
                        <a href="#" id="mnuBilling2" class="w3-bar-item w3-button" onclick="OpenLink('Billing')">2.Create Billing</a>
                        <a href="#" id="mnuBilling3" class="w3-bar-item w3-button" onclick="OpenLink('Receipt')">3.Cash-Receipts</a>
                        <a href="#" id="mnuBilling4" class="w3-bar-item w3-button" onclick="OpenLink('TaxInvoice')">4.Tax-Receipts</a>
                    </div>
                    <div id="mnuDocuments" class="w3-bar-item w3-button" onclick="w3_accordion('mnuAuthorized')">
                        My Documents
                    </div>
                    <div id="mnuAuthorized" class="w3-hide w3-card-4 w3-pale-red">
                        <a href="#" id="mnuAuthorize1" class="w3-bar-item w3-button" onclick="OpenLink('AppQuo')">1.Quotation Approving</a>
                        <a href="#" id="mnuAuthorize2" class="w3-bar-item w3-button" onclick="OpenLink('AppJob')">2.Shipment Approving</a>
                        <a href="#" id="mnuAuthorize3" class="w3-bar-item w3-button" onclick="OpenLink('AppAdvance')">3.Advance Approving</a>
                        <a href="#" id="mnuAuthorize4" class="w3-bar-item w3-button" onclick="OpenLink('AppClearing')">4.Clearing Approving</a>
                        <a href="#" id="mnuAuthorize5" class="w3-bar-item w3-button" onclick="OpenLink('AppExpense')">5.Payables Approving</a>
                        <a href="#" id="mnuAuthorize6" class="w3-bar-item w3-button" onclick="OpenLink('AppTransport')">6.Transport Approving</a>
                        <a href="#" id="mnuAuthorize7" class="w3-bar-item w3-button" onclick="OpenLink('Document')">7.Document Files</a>
                    </div>
                    <div id="mnuCashFlow" class="w3-bar-item w3-button" onclick="w3_accordion('mnuCashManager')">
                        My Cash Flow
                    </div>
                    <div id="mnuCashManager" class="w3-hide w3-card-4 w3-light-blue">
                        <a href="#" id="mnuCash1" class="w3-bar-item w3-button" onclick="OpenLink('PettyCash')">1.Cash In/Out</a>
                        <a href="#" id="mnuCash2" class="w3-bar-item w3-button" onclick="OpenLink('Cheque')">2.Cheque In/Out</a>
                        <a href="#" id="mnuCash3" class="w3-bar-item w3-button" onclick="OpenLink('PayAdvance')">3.Advance Payment</a>
                        <a href="#" id="mnuCash4" class="w3-bar-item w3-button" onclick="OpenLink('RecvClear')">4.Advance Refund/Return</a>
                        <a href="#" id="mnuCash5" class="w3-bar-item w3-button" onclick="OpenLink('Payment')">5.A/P Payment</a>
                        <a href="#" id="mnuCash6" class="w3-bar-item w3-button" onclick="OpenLink('RecvInv')">6.A/R Receive</a>
                    </div>
                    <div id="mnuReports" class="w3-bar-item w3-button" onclick="w3_accordion('mnuSummary')">
                        My Reports
                    </div>
                    <div id="mnuSummary" class="w3-hide w3-card-4 w3-amber">
                        <a href="#" id="mnuSummary1" class="w3-bar-item w3-button" onclick="OpenLink('Report')">1.Reports</a>
                        <a href="#" id="mnuSummary2" class="w3-bar-item w3-button" onclick="OpenLink('Tracking1')">2.Status Tracking</a>
                        <a href="#" id="mnuSummary3" class="w3-bar-item w3-button" onclick="OpenLink('Tracking2')">3.Job Timeline</a>
                        <a href="#" id="mnuSummary4" class="w3-bar-item w3-button" onclick="OpenLink('Dashboard')">4.Dashboard By Customer</a>
                        <a href="#" id="mnuSummary5" class="w3-bar-item w3-button" onclick="OpenLink('Dashboard2')">5.Dashboard By Staff</a>
                    </div>
                </div>
            </div>
            <div id="dvVenderMenu">
                <div id="mainVend" class="w3-bar-item w3-button" onclick="w3_accordion('mnuVend')">
                    Vender Works
                </div>
                <div id="mnuVend" class="w3-hide w3-pale-red w3-card-4">
                    <a href="#" id="mnuVend0" class="w3-bar-item w3-button" onclick="OpenLink('AppTransport')">- Transport Confirm</a>
                    <a href="#" id="mnuVend2" class="w3-bar-item w3-button" onclick="OpenLink('BillPayment')">- Bill Payment</a>
                    <a href="#" id="mnuVend1" class="w3-bar-item w3-button" onclick="OpenLink('VenderInv')">- Vender Summary</a>
                    <a href="#" id="mnuVend3" class="w3-bar-item w3-button" onclick="OpenLink('Tracking1')">- Transport Tracking</a>
                </div>
            </div>
        </div>
    </div>
    <div id="dvModals">
        <div id="dvMasA" class="modal" style="width:100%">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="background-color:black">
                        <div id="mainMasA" class="modal-title" style="color:white;text-align:center">
                            Account Master Files
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <button id="mnuMasA1" class="btn btn-default btn-block" onclick="OpenLink('customers')">- Customers</button>
                                <button id="mnuMasA2" class="btn btn-default btn-block" onclick="OpenLink('venders')">- Venders</button>
                                <button id="mnuMasA3" class="btn btn-default btn-block" onclick="OpenLink('ServUnit')">- Service Units</button>
                                <button id="mnuMasA4" class="btn btn-default btn-block" onclick="OpenLink('Bank')">- Bank</button>
                                <button id="mnuMasA5" class="btn btn-default btn-block" onclick="OpenLink('BookAccount')">- Bank Accounts</button>
                                <button id="mnuMasA9" class="btn btn-default btn-block" onclick="OpenLink('AccountCode')">- Account Code</button>
                            </div>
                            <div class="col-sm-6">
                                <button id="mnuMasA6" class="btn btn-default btn-block" onclick="OpenLink('ServiceGroup')">- Service Groups</button>
                                <button id="mnuMasA7" class="btn btn-default btn-block" onclick="OpenLink('ServiceCode')">- Service Code</button>
                                <button id="mnuMasA8" class="btn btn-default btn-block" onclick="OpenLink('BudgetPolicy')">- Service Policy</button>
                 		<button id="mnuMasA10" class="btn btn-default btn-block" onclick="OpenLink('CarLicense')">- Car License</button>
                                <button id="mnuMasA11" class="btn btn-default btn-block" onclick="OpenLink('Employee')">- Employee</button>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvMasS" class="modal" style="width:100%">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="background-color:black">
                        <div id="mainMasS" class="modal-title" style="color:white;text-align:center">
                            System Master Files
                        </div>
                    </div>
                    <div class="modal-body" >
                        <div class="row">
                            <div class="col-sm-6">
                                <button id="mnuMasS1" class="btn btn-default btn-block" onclick="OpenLink('Constant')">- System Variables</button>
                                <button id="mnuMasS2" class="btn btn-default btn-block" onclick="OpenLink('users');">- System User</button>
                                <button id="mnuMasS3" class="btn btn-default btn-block" onclick="OpenLink('UserAuth');">- User Authorize</button>
                            </div>
                            <div class="col-sm-6">
                                <button id="mnuMasS4" class="btn btn-default btn-block" onclick="OpenLink('Branch')">- Branch</button>
                                <button id="mnuMasS5" class="btn btn-default btn-block" onclick="OpenLink('Role')">- User Role</button>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvMasG" class="modal" style="width:100%">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="background-color:black">
                        <div id="mainMasG" class="modal-title" style="color:white;text-align:center">
                            General Master Files
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <button id="mnuMasG1" class="btn btn-default btn-block" onclick="OpenLink('Currency')">- Currency</button>
                                <button id="mnuMasG2" class="btn btn-default btn-block" onclick="OpenLink('Country')">- Country</button>
                                <button id="mnuMasG3" class="btn btn-default btn-block" onclick="OpenLink('InterPort')">- Inter Ports</button>
                                <button id="mnuMasG4" class="btn btn-default btn-block" onclick="OpenLink('vessel')">- Vessel/Vehicles/Flight</button>
                                <button id="mnuMasG9" class="btn btn-default btn-block" onclick="OpenLink('TransportRoute')">- Transport Route</button>
                            </div>
                            <div class="col-sm-6">
                                <button id="mnuMasG8" class="btn btn-default btn-block" onclick="OpenLink('Province')">- Province</button>
                                <button id="mnuMasG5" class="btn btn-default btn-block" onclick="OpenLink('DeclareType')">- Declare Type</button>
                                <button id="mnuMasG6" class="btn btn-default btn-block" onclick="OpenLink('CustomsPort')">- Customs Port</button>
                                <button id="mnuMasG7" class="btn btn-default btn-block" onclick="OpenLink('CustomsUnit')">- Product Units</button>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvWaiting" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1">
            <div class="vertical-alignment-helper">
                <div class="modal-dialog vertical-align-center">
                    <div class="modal-content">
                        <div class="modal-body">Please wait...</div>
                    </div>
                </div>
            </div>
        </div>
        <div id="dvLogin" class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1">
            <div class="vertical-alignment-helper">
                <div class="modal-dialog vertical-align-center">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color:black">
                            <div class="modal-title" style="color:white;text-align:center">
                                Log in
                            </div>
                        </div>
                        <div class="modal-body">
                            Data : <select class="form-control dropdown" id="cboDatabase"></select>
                            <a id="linkLogout" onclick="ForceLogout()">User ID :</a> <input type="text" class="form-control" id="txtUserLogin" />
                            Password : <input type="password" class="form-control" id="txtUserPassword" />
                        </div>
                        <div class="modal-footer">
                            <div style="display:flex;flex-direction:row;float:left;">
                                <input type="radio" name="optRole" id="optShip" value="S" checked /><label for="optShip" style="padding-right:10px">Shipper</label>
                                <input type="radio" name="optRole" id="optVend" value="V" /><label for="optVend" style="padding-right:10px">Vender</label>
                                <input type="radio" name="optRole" id="optImEx" value="C" /><label for="optImEx" style="padding-right:10px">Importer/Exporter</label>
                            </div>
                            <button class="btn btn-primary" id="btnLogin" onclick="SetVariable()">Log in</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w3-overlay w3-animate-opacity" onclick="w3_close()" style="cursor:pointer" id="myOverlay"></div>
    <div style="display:flex;flex-direction:column;margin-bottom:100px;">
        <div class="w3-container" style="margin-bottom:10px">
            <!-- Page Content -->
            <div Class="panel-primary">
                <div id="color_header" Class="panel-heading w3-indigo" style="">
                    <div Class="panel-title">
                        <div class="row">
                            <div class="col-xs-1 col-md-1" style="text-align:center">
                                <img id="imgCompany" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:100%" onclick="w3_open();" />
                            </div>
                            <div class="col-xs-11 col-md-11">
                                <div style="display:flex;align-items:center;height:50px">
                                    <div style="text-align:left;flex:1;">
                                        <label id="lblTitle" onclick="OpenContact()">@ViewBag.Title</label>
                                        <input type="hidden" id="lblModule" value="@ViewBag.Module" />
                                    </div>
                                    <div style="text-align:right;flex:1;">
                                        <a href="#" onclick="SetLogin()"><label id="lblUserID" style="color:white;font-size:11px">Please Login</label></a>
                                        <select id="cboLanguage" onchange="ChangeLanguage($(this).val(),'@ViewBag.Module')" data-width="fit">
                                            <option value="EN">EN</option>
                                            <option value="TH">ไทย</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="color_body" class="panel-body" style="">
                    @RenderBody()
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        let userID = '@ViewBag.User';
        let dbID = GetDatabaseID();
        let userType = '@ViewBag.UserGroup';
        let sessionID = '@ViewBag.SESSION_ID';
        let dbMas = '@ViewBag.CONNECTION_MAS';
        let dbJob = '@ViewBag.CONNECTION_JOB';
        let userLang = '@ViewBag.PROFILE_DEFAULT_LANG';
        let menuType = '@ViewBag.PROFILE_MENU_TYPE';
        let base = '@Url.Content("~")';
        if (menuType !== '') {
            $('#cboMenu').val(menuType);
            ChangeMenu();
        }
        //if (userLang !== 'EN' && userLang !== '') {
            $('#cboLanguage').val(userLang);
            ChangeLanguage(userLang, $('#lblModule').val());
        //} else {
        //    userLang = 'EN';
        //    $('#cboLanguage').val(userLang);
        //}
        $('#dvLogin').on('shown.bs.modal', function () {
            $('#txtUserLogin').focus();
        });
	$('#dvLogin').css("margin-top", 20);
	$('#dvLogin').css("margin-left", 20);
        $('#txtUserLogin').keydown(function (event) {
            if (event.which === 13) {
                $('#txtUserPassword').focus();
            }
        });
        $('#txtUserPassword').keydown(function (event) {
            if (event.which === 13) {
                SetVariable();
            }
        });
        CheckLogin();
        CheckLanguage();
        function CheckLanguage() {
            $.get(base + 'Config/GetLangMessage').done(function (r) {
                if ($.isEmptyObject(r)==false) {
                    langMessage = r;
                }
            });
            $.get(base + 'Config/GetLangMenu').done(function (r) {
                if ($.isEmptyObject(r) == false) {
                    langMenu = r;
                }
            });
        }
        function ForceLogout() {
            userType = $('input[name=optRole]:checked').val();

            $.get(base + 'config/setlogout?group='+ userType +'&code=' + $('#txtUserLogin').val()).done(function (r) {
                if (r == "Y") {
                    ShowMessage('Logout complete!');
                }
            });
        }
        function GetDatabaseID() {
            let dbName = '@ViewBag.LICENSE_NAME';
            if (dbName.indexOf('/') > 0) {
                return dbName.split('/')[1].trim();
            } else {
                return '1';
            }
        }
        function SetVariable() {
            userID = $('#txtUserLogin').val();
            dbID = $('#cboDatabase').val();
            userType = $('input[name=optRole]:checked').val();

            let Password = $('#txtUserPassword').val();
            $.get(base + 'Config/SetLogin?Group='+ userType +'&Code=' + userID + '&Pass=' + Password + '&Database=' + dbID)
                .done(function (r) {
                    if (r.user.data.length > 0) {
                        window.location.reload();
                    } else {
                        ShowMessage(r.user.message,true);
                    }
                });
        }
        function SetLogin() {
            CheckPassword(dbID, userID, function () {
                ShowMessage('Welcome ' + userID + '!');
            });
        }

        function CheckLogin() {
            if (userID === '') {
                CheckSession(null);
            } else {
                $('#imgMenu').attr('src',path + 'Resource/@ViewBag.PROFILE_LOGO');
                $('#imgCompany').attr('src', path + 'Resource/@ViewBag.PROFILE_LOGO');
                //$('#imgMenu').attr('src', path + 'Resource/logo_main_bft.png');
                //$('#imgCompany').attr('src', path + 'Resource/logo_main_bft.png');
                $('#lblUserID').text('@ViewBag.UserName');
                $('#lblLicenseName').text('@ViewBag.LICENSE_NAME');
                $('#cboLanguage').val('@ViewBag.PROFILE_DEFAULT_LANG');
                userType = '@ViewBag.UserGroup';
                if (userType == 'S') {
                    $('#dvCustomerMenu').hide();
                    $('#dvVenderMenu').hide();
                }
                if (userType == 'C') {
                    $('#dvShippingMenu').hide();
                    $('#dvVenderMenu').hide();
                }
                if (userType == 'V') {
                    $('#dvShippingMenu').hide();
                    $('#dvCustomerMenu').hide();
                }
            }
        }
        function SetLogout() {
            ShowConfirm('Please confirm to log out the application', function (c) {
                if (c == true) {
                    ShowWait();
                    $.get(base + 'config/setlogout?group='+ userType +'&code=' + userID)
                        .done(function (r) {
                            CloseWait();
                            if (r == 'Y') {
                                window.location.href=base;
                            }
                        });
                }
            });
        }
        function OpenLink(mnu) {
            OpenMenu(mnu, false);
        }
        function OpenContact() {
            window.location.href=base + 'Menu/About';
        }
        function ReturnMain() {
            window.location.href=base + 'Master/Index';
        }
        function ChangeMenu() {
            switch ($('#cboMenu').val()) {
                case 'W':
                    $('#dvMenuByDept').hide();
                    $('#dvMenuByFlow').show();
                    break;
                case 'D':
                    $('#dvMenuByFlow').hide();
                    $('#dvMenuByDept').show();
                    break;
            }
        }
        function SwitchMenu() {
            SetMenu($('#cboMenu').val(), ChangeMenu);
        }
        function w3_open() {
            document.getElementById("mySidebar").style.display = "block";
            document.getElementById("myOverlay").style.display = "block";
        }
        function w3_close() {
            document.getElementById("mySidebar").style.display = "none";
            document.getElementById("myOverlay").style.display = "none";
        }
        function w3_accordion(id) {
            var x = document.getElementById(id);
            if (x.className.indexOf("w3-show") == -1) {
                x.className += " w3-show";
            } else {
                x.className = x.className.replace(" w3-show", "");
            }
        }
    </script>
</body>
</html> 