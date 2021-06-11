@Code
    ViewBag.Title = "Work flow"
End Code
<style>
    
    p {
        width:100%;
        font-size:10px !important;
    }

    p a {
        font-size: 10px !important;
    }

    .text-wrap {
        white-space:normal;
    }

    .btn{
        white-space:normal;  
    }
</style>
<header>
    <div class="container">
        <h1 class="text-center">May I help you today?</h1>
    </div>
</header>
<div id="dvOpenJob" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <input type="text" id="txtJobNo" class="form-control" placeholder="Your job number" />
                <button class="btn btn-success" onclick="OpenJob()">Edit Shipment Data</button>
                <button class="btn btn-primary" onclick="OpenTransport()">Edit Transport Data</button>
            </div>
            <div class="modal-footer">
                <a href="#" data-dismiss="modal">X</a>
            </div>
        </div>
    </div>
</div>
<div class="container w3-white">
    On Branch : <select id="cboBranch" class="form-control dropdown"></select>
    <br />
    <div id="dvShipments" >
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowShipment" onclick="w3_accordion('dvFlowShipment')">My Shipments</a>
        </h3>
        <div class="w3-hide w3-border" id="dvFlowShipment" style="background-color:lightcyan;">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Is this new shipment?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-5 text-center">
                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                    <p class="text-success">
                        <a href="~/master/customers" class="btn btn-warning">Register New Customer</a> OR
                    </p>
                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                    <p class="text-success">
                        <a href="~/joborder/createjob" class="btn btn-primary">Create Shipment</a>
                    </p>
                </div>
                <div class="col-xs-7 text-center">
                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                    <p class="bg-info w3-pale-yellow text-info btn">Know your job number?</p>
                    <div class="row">
                        <div class="col-xs-6 text-center">
                            <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-6 text-center">
                            <p class="btn">
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block">
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                            <p class="text-success text-wrap">
                                <a href="#" class="btn btn-success" onclick="ShowOpenJob()">Enter Job</a>
                            </p>
                        </div>
                        <div class="col-xs-6 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-danger text-wrap">
                                <a href="~/joborder/index" class="btn btn-warning">Find</a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div id="dvPlaning">
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowPlaning" onclick="w3_accordion('dvFlowPlaning')">My Services Planning</a>
        </h3>
        <div id="dvFlowPlaning" class="w3-hide w3-border" style="background-color:lightcyan;">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Is this job charges rate by the route?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/master/transportroute" class="btn btn-warning">Register New Route</a> OR
                            </p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/joborder/transport" class="btn btn-primary">Truck Order</a>
                            </p>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="bg-info w3-pale-yellow text-info btn">Use quotation for charges?</p>
                            <div class="row">
                                <div class="col-xs-5 text-center">
                                    <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="btn">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5">
                                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                                    <p class="center-block">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                    <p class="text-success text-wrap">
                                        <a href="~/joborder/quotation" class="btn btn-success">Quotation</a>
                                    </p>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                    <p class="text-danger text-wrap">
                                        <a href="~/adv/estimatecost" class="btn btn-warning">Estimate</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvExpense">
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowExpenses" onclick="w3_accordion('dvFlowExpenses')">My Expenses</a>
        </h3>
        <div id="dvFlowExpenses" class="w3-hide w3-border" style="background-color:lightcyan;">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Can I arrange the payments for this?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/acc/pettycash" class="btn btn-warning">Check Cash Onhand</a> OR
                            </p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/adv/creditadv" class="btn btn-primary">New Credit Advance</a>
                            </p>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="bg-info w3-pale-yellow text-info btn">Is accrued expenses?</p>
                            <div class="row">
                                <div class="col-xs-5 text-center">
                                    <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="btn">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5">
                                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                                    <p class="center-block">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                    <p class="text-success text-wrap">
                                        <a href="~/acc/expense" class="btn btn-success">Pay-in</a>
                                    </p>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                    <p class="text-danger text-wrap">
                                        <a href="~/adv/index" class="btn btn-warning">Advance</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvClearing">
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowClear" onclick="w3_accordion('dvFlowClear')">My Costing & Service</a>
        </h3>
        <div id="dvFlowClear" class="w3-hide w3-border" style="background-color:lightcyan;">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Don't need to collect by invoice?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/clr/index" class="btn btn-warning">New Clearing</a> OR
                            </p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/clr/earnest" class="btn btn-primary">Close Clearing</a>
                            </p>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="bg-info w3-pale-yellow text-info btn">Is this specific job?</p>
                            <div class="row">
                                <div class="col-xs-5 text-center">
                                    <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="btn">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5">
                                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                                    <p class="center-block">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                    <p class="text-success text-wrap">
                                        <a href="#" class="btn btn-success" onclick="ShowOpenJob()">Enter Job</a>
                                    </p>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                    <p class="text-danger text-wrap">
                                        <a href="~/clr/index" class="btn btn-warning">Clearing</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvInvoice">
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowInvoice" onclick="w3_accordion('dvFlowInvoice')">My Invoices</a>
        </h3>
        <div id="dvFlowInvoice" class="w3-hide w3-border" style="background-color:lightcyan">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Have all needed job been closed already?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/clr/generateinv" class="btn btn-primary">New Invoice</a>
                            </p>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="bg-info w3-pale-yellow text-info btn">Re-check data before?</p>
                            <div class="row">
                                <div class="col-xs-5 text-center">
                                    <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="btn">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5">
                                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                                    <p class="center-block">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                    <p class="text-success text-wrap">
                                        <a href="#" class="btn btn-success" onclick="ShowOpenJob()">Enter Job</a>
                                    </p>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                    <p class="text-danger text-wrap">
                                        <a href="~/clr/generateinv" class="btn btn-warning">Invoice</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvBilling">
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowBilling" onclick="w3_accordion('dvFlowBilling')">My Billing</a>
        </h3>
        <div id="dvFlowBilling" class="w3-hide w3-border" style="background-color:lightcyan">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Do you need to input the due date for payment?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/acc/invoice" class="btn btn-primary">Invoice</a>
                            </p>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="bg-info w3-pale-yellow text-info btn">Have yet to create billing?</p>
                            <div class="row">
                                <div class="col-xs-5 text-center">
                                    <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="btn">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5">
                                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                                    <p class="center-block">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                    <p class="text-success text-wrap">
                                        <a href="~/acc/billing" class="btn btn-success">Billing</a>
                                    </p>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                    <p class="text-danger text-wrap">
                                        <a href="~/acc/generatebilling" class="btn btn-warning">New Billing</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvReceipts">
        <h3>
            <span class="glyphicon glyphicon-circle-arrow-right" style="color:lightseagreen">
            </span>
            <a href="#dvFlowIncome" onclick="w3_accordion('dvFlowIncome')">My Receipts</a>
        </h3>
        <div id="dvFlowIncome" class="w3-hide w3-border" style="background-color:lightcyan">
            <div class="row">
                <div class="col-xs-12">
                    <p class="lead text-center w3-pale-green btn text-info center-block">Is this official tax-receipts?</p>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p><span class="glyphicon glyphicon-arrow-down"></span>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p>
                                <span class="glyphicon glyphicon-arrow-down"></span>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-5 text-center">
                            <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="text-success">
                                <a href="~/acc/generatetaxinv" class="btn btn-primary">New TAX-Receipts</a>
                            </p>
                        </div>
                        <div class="col-xs-7 text-center">
                            <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                            <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                            <p class="bg-info w3-pale-yellow text-info btn">Is Cash/Cheque Receipts?</p>
                            <div class="row">
                                <div class="col-xs-5 text-center">
                                    <p class="btn"><span class="glyphicon glyphicon-arrow-down"></span>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="btn">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-5">
                                    <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                                    <p class="center-block">
                                        <span class="glyphicon glyphicon-arrow-down"></span>
                                    </p>
                                    <p class="text-success text-wrap">
                                        <a href="~/acc/generatereceipt" class="btn btn-success">Receipts</a>
                                    </p>
                                </div>
                                <div class="col-xs-7 text-center">
                                    <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                    <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                    <p class="text-danger text-wrap">
                                        <a href="~/acc/creditnote" class="btn btn-warning">CN & DN</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    loadBranch(path);
    function ShowOpenJob() {        
        $('#dvOpenJob').modal('show');
    }
    function OpenJob() {
        $.get(path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJobNo').val(), function (r) {
            window.location.href=path + 'joborder/showjob?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJobNo').val();
        });
    }
    function OpenTransport() {
        window.location.href = path + 'joborder/transport?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJobNo').val();
    }
</script>