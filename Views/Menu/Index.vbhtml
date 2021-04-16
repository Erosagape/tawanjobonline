@Code
    ViewBag.Title = "Main Work flow"
End Code
<style>
    p {
        width:100%;
    }

    .text-wrap {
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
    <div id="dvShipments">
        <h3 class="page-header">My Shipments</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Is this new shipment?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6 text-center">
                <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                <p class="text-success">
                    <a href="~/master/customers">Register New Customer</a> OR
                </p>
                <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                <p class="text-success">
                    <a href="~/joborder/createjob" class="btn btn-primary">Create Shipment</a>
                </p>
            </div>
            <div class="col-xs-6 text-center">
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
                            <a href="~/joborder/index" class="btn btn-warning">View List</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvPlaning">
        <h3 class="page-header">My Services Planning</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Is this job charges by route?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/master/transportroute">Register New Route</a> OR
                        </p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/joborder/transport" class="btn btn-primary">Create Booking/Truck Order</a>
                        </p>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="bg-info w3-pale-yellow text-info btn">Use quotation?</p>
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
                                    <a href="~/joborder/quotation" class="btn btn-success">Quotation</a>
                                </p>
                            </div>
                            <div class="col-xs-6 text-center">
                                <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                <p class="text-danger text-wrap">
                                    <a href="~/adv/estimatecost" class="btn btn-warning">Pre-invoice</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div id="dvExpense">
        <h3 class="page-header">My Expenses</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Can I payment for this?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/acc/pettycash">Add Petty Cash</a> OR
                        </p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/adv/creditadv" class="btn btn-primary">New Credit Advance</a>
                        </p>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="bg-info w3-pale-yellow text-info btn">Is accrued expenses?</p>
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
                                    <a href="~/acc/expense" class="btn btn-success">Pay-in Entry</a>
                                </p>
                            </div>
                            <div class="col-xs-6 text-center">
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
    <div id="dvClearing">
        <h3 class="page-header">My Cost/Services Clearing</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Don't need to collect by invoice?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/clr/index">Add Clearing</a> OR
                        </p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/clr/earnest" class="btn btn-primary">Close Clearing</a>
                        </p>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="bg-info w3-pale-yellow text-info btn">Is specific job?</p>
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
                                    <a href="~/clr/index" class="btn btn-warning">Clearing</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvInvoice">
        <h3 class="page-header">My Invoice</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Have all needed job been closed already?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/clr/generateinv" class="btn btn-primary">Create Invoice</a>
                        </p>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="bg-info w3-pale-yellow text-info btn">Check data before?</p>
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
                                    <a href="~/clr/generateinv" class="btn btn-warning">Create Invoice</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvBilling">
        <h3 class="page-header">My Billing</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Do you need to input the due for payment?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/acc/invoice" class="btn btn-primary">Open Invoice</a>
                        </p>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="bg-info w3-pale-yellow text-info btn">Is Billing Created?</p>
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
                                    <a href="~/acc/billing" class="btn btn-success">Billing</a>
                                </p>
                            </div>
                            <div class="col-xs-6 text-center">
                                <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                <p class="text-danger text-wrap">
                                    <a href="~/acc/generatebilling" class="btn btn-warning">Create Billing</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvReceipts">
        <h3 class="page-header">My Receipts</h3>
        <div class="row">
            <div class="col-xs-12">
                <p class="lead text-center w3-pale-green btn text-info center-block">Is this official tax-receipts?</p>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p><span class="glyphicon glyphicon-arrow-down"></span>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p>
                            <span class="glyphicon glyphicon-arrow-down"></span>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-success">Yes</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="text-success">
                            <a href="~/acc/generatetaxinv" class="btn btn-primary">Create TAX-Receipts</a>
                        </p>
                    </div>
                    <div class="col-xs-6 text-center">
                        <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                        <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                        <p class="bg-info w3-pale-yellow text-info btn">Is Cash/Cheque Receipts?</p>
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
                                    <a href="~/acc/generatereceipt" class="btn btn-success">Receipts</a>
                                </p>
                            </div>
                            <div class="col-xs-6 text-center">
                                <p class="center-block"><span class="btn btn-lg text-danger">No</span></p>
                                <p class="center-block"><span class="glyphicon glyphicon-arrow-down"></span></p>
                                <p class="text-danger text-wrap">
                                    <a href="~/acc/creditnote" class="btn btn-warning">Credit/Debit<br/>Note</a>
                                </p>
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