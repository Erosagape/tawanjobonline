
@Code
    ViewBag.Title = "Transport Information"
End Code
<style>
    @@media only screen and (max-width: 600px) {
        #btnAdd, #btnDelete, #btnSave, #btnUpdateJob,
        #btnAddDetail, #btnDeleteDetail, #btnUpdateDetail {
            width: 100%;
        }
    }
</style>
<div class="row">
    <div class="col-sm-3">
        <label id="lblBranchCode">Branch</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtBranchCode" style="width:20%" disabled />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
            <input type="text" class="form-control" id="txtBranchName" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblJNo" style="color:red;" onclick="OpenJob()">Job Number</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" id="txtJNo" class="form-control" style="width:100%" />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('job');" />
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblBookingNo" style="color:blue;">Booking No</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" id="txtBookingNo" class="form-control" style="width:100%" />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('booking');" />
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblTransportTerm">Transport Term</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <select id="txtTransMode" class="form-control dropdown">
                <option value="CY-CY">CY/CY</option>
                <option value="CY-CFS">CY/CFS</option>
                <option value="CFS-CY">CFS/CY</option>
                <option value="CFS-CFS">CFS/CFS</option>
            </select>
        </div>
    </div>
</div>
<a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearBooking()">
    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">New Booking</b>
</a>
<a href="#" class="btn btn-success" id="btnSave" onclick="SaveBooking()">
    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Booking</b>
</a>
<a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteBooking()">
    <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDel">Delete Booking</b>
</a>
<a href="#" class="btn btn-warning" id="btnChange" onclick="ChangeBooking()">
    <i class="fa fa-lg fa-check"></i>&nbsp;<b id="linkChange">Change Booking</b>
</a>
 To >>
<input type="text" id="txtBookingNew" />
<ul class="nav nav-tabs">
    <li class="active">
        <a data-toggle="tab" href="#tabLoading" id="linkTab1">Loading Information</a>
    </li>
    <li>
        <a data-toggle="tab" href="#tabContainer" id="linkTab2">Route Information</a>
    </li>
</ul>
<div class="tab-content">
    <div class="tab-pane fade in active" id="tabLoading">
        <div id="dvForm">
            <div class="row">
                <div class="col-sm-6">
                    <a href="../Master/Customers?mode=NOTIFY_PARTY" target="_blank">
                        <label id="lblNotify">Notify Party:</label>
                    </a>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtNotifyCode" class="form-control" style="width:20%" />
                        <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                        <input type="text" id="txtNotifyName" class="form-control" style="width:100%" disabled />
                    </div>
                </div>
                <div class="col-sm-6">
                    <a href="../Master/Venders" target="_blank">
                        <label id="lblTransport">Transporter:</label>
                    </a>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtVenderCode" class="form-control" style="width:20%">
                        <button id="btnBrowseVend" class="btn btn-default" onclick="SearchData('vender')">...</button>
                        <input type="text" id="txtVenderName" class="form-control" style="width:100%" disabled />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <label id="lblLoadDate">Load Date :</label>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="date" id="txtLoadDate" class="form-control">
                    </div>
                </div>
                <div class="col-sm-3">
                    <label id="lblContact">Contact Name :</label>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtContactName" class="form-control">
                    </div>
                </div>
                <div class="col-sm-6">
                    <label id="lblRemark">Remark :</label>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <textarea id="txtRemark" class="form-control"></textarea>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <label id="lblPaymentCond">Freight Payment Condition :</label>
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <textarea id="txtPaymentCondition" class="form-control"></textarea>
                    </div>
                </div>
                <div class="col-sm-6">
                    <label id="lblPaymentBy">Freight Paid By :</label>
                    <br /><div style="display:flex;flex-direction:row"><input type="text" id="txtPaymentBy" class="form-control"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3" style="display:flex;flex-direction:row">
                    <div>
                        <label id="lblCYDate">Pickup Date :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="date" id="txtCYDate" class="form-control">
                        </div>
                    </div>
                    <div>
                        <label id="lblCYTime">Time :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtCYTime" class="form-control">
                        </div>
                    </div>
                </div>
                <div class="col-sm-3" style="display:flex;flex-direction:row">
                    <div>
                        <label id="lblPackingDate">Packing Date:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="date" id="txtPackingDate" class="form-control">
                        </div>
                    </div>
                    <div>
                        <label id="lblPackingTime">Time :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtPackingTime" class="form-control">
                        </div>
                    </div>
                </div>
                <div class="col-sm-3" style="display:flex;flex-direction:row">
                    <div>
                        <label id="lblFactoryDate">Delivery Date :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="date" id="txtFactoryDate" class="form-control">
                        </div>
                    </div>
                    <div>
                        <label id="lblFactoryTime">Time :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtFactoryTime" class="form-control">
                        </div>
                    </div>
                </div>
                <div class="col-sm-3" style="display:flex;flex-direction:row">
                    <div>
                        <label id="lblReturnDate">Return Date :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="date" id="txtReturnDate" class="form-control">
                        </div>
                    </div>
                    <div>
                        <label id="lblReturnTime">Time :</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtReturnTime" class="form-control">
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintBooking()">
                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Form</b>
            </a>
            <select id="cboPrintForm">
                <option value="BK">Booking Request</option>
                <option value="TI">Truck Order (IMPORT)</option>
                <option value="TE">Truck Order (EXPORT)</option>
                <option value="BA">Booking Confirmation (AIR)</option>
                <option value="BS">Booking Confirmation (SEA)</option>
                <option value="SP">Shipping Particulars</option>
                <option value="BLW">Bill of Lading - WALMAY</option>
                <option value="BLE">Bill of Lading - EASTRONG</option>
                <option value="BLS">Sea Way Bill</option>
                <option value="HAW">House Air Way Bill</option>
                <option value="MAW">Master Air Way Bill</option>
                <option value="DO">D/O Letter</option>
                <option value="SC">Sales Contract</option>
                <option value="PL">Packing Lists</option>
            </select>
            >
            <div class="row">
                <div class="col-sm-4">
                    <label id="lblActive">Active Trip:</label>
                    <input type="text" id="txtTotalTripA" class="form-control" disabled />
                </div>
                <div class="col-sm-4">
                    <label id="lblFinish">Finished Trip:</label>
                    <input type="text" id="txtTotalTripF" class="form-control" disabled />
                </div>
                <div class="col-sm-4">
                    <label id="lblNonActive">Non-active Trip:</label>
                    <input type="text" id="txtTotalTripC" class="form-control" disabled />
                </div>
            </div>
        </div>
    </div>
    <div class="tab-pane fade" id="tabContainer">
        <div class="row">
            <div class="col-sm-2">
                <br />
                <select id="cboTemplate" class="form-control dropdown" onclick="GenRoute()">
                    <option value="4123" selected>
                        EXPORT
                    </option>
                    <option value="4123">
                        IMPORT
                    </option>
                    <option value="412">
                        DOMESTIC
                    </option>
                </select>
            </div>
            <div class="col-sm-5">
                <a href="../Master/TransportRoute"><label id="lblRoute">Transport Route</label></a>:
                <br />
                <div style="display:flex">
                    <input type="text" id="txtMainRoute" style="width:10%;" class="form-control" disabled />
                    <input type="text" id="txtMainLocation" style="width:100%" class="form-control" disabled />
                    <button id="btnRoute" class="btn btn-default" onclick="SearchData('location');">...</button>
                </div>
                <input type="checkbox" id="chkAllRoute" /> Show All
            </div>
            <div class="col-sm-2">
                <label id="lblAutoGenCon">Auto Create Container</label>
                =>
                <select id="cboContainerSize" class="form-control dropdown"></select>
            </div>
            <div class="col-sm-1">
                <label id="lblTotalCon">Total(s)</label>
                : <input type="number" id="txtTotalContainer" class="form-control" />
            </div>
            <div class="col-sm-2">
                <br />
                <button id="btnCreateContainer" class="btn btn-success" value="Create" onclick="GenContainer()">Create</button>
            </div>

        </div>
        <div class="row">
            <div class="col-sm-4">
                <label id="lblPlace1">Pick up: </label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtPlace1" class="form-control" />
                </div>
            </div>
            <div class="col-sm-5">
                <label id="lblAddress1">Address:</label>
                <br />
                <textarea id="txtAddress1" class="form-control"></textarea>
            </div>
            <div class="col-sm-3">
                <label id="lblContact1">Contact:</label>
                <br />
                <input type="text" class="form-control" id="txtContact1" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label id="lblPlace2">Delivery:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtPlace2" class="form-control" />
                </div>
            </div>
            <div class="col-sm-5">
                <label id="lblAddress2">Address:</label>
                <br />
                <textarea id="txtAddress2" class="form-control"></textarea>
            </div>
            <div class="col-sm-3">
                <label id="lblContact2">Contact:</label>
                <br />
                <input type="text" class="form-control" id="txtContact2" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label id="lblPlace3">Return:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtPlace3" class="form-control" />
                </div>
            </div>
            <div class="col-sm-5">
                <label id="lblAddress3">Address:</label>
                <br />
                <textarea id="txtAddress3" class="form-control"></textarea>
            </div>
            <div class="col-sm-3">
                <label id="lblContact3">Contact:</label>
                <br />
                <input type="text" class="form-control" id="txtContact3" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label id="lblPlace4">Size:</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtPlace4" class="form-control">
                </div>
            </div>
            <div class="col-sm-5">
                <label id="lblAddress4">Address:</label>
                <br />
                <textarea id="txtAddress4" class="form-control"></textarea>
            </div>
            <div class="col-sm-3">
                <label id="lblContact4">Contact:</label>
                <br />
                <input type="text" class="form-control" id="txtContact4" />
            </div>
        </div>
        <button id="btnSaveLoc" class="btn btn-primary" onclick="SaveLocation(true)">Save Route Data</button>
        <button id="btnEditExp" class="btn btn-info" onclick="EditExpense()">Edit Route Expense</button>
    </div>
</div>
<div id="dvExpenses" class="modal fade">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-body">
                <table id="tbPrice" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>SICode</th>
                            <th>SDescription</th>
                            <th>CostAmount</th>
                            <th>ChargeCode</th>
                            <th>ChargeAmount</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
                <div class="row">
                    <div class="col-sm-1">
                        <input type="text" id="txtLocationID" class="form-control" disabled />
                    </div>
                    <div class="col-sm-11">
                        <input type="text" id="txtLocationRoute" class="form-control" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label id="lblSICode">Expense Code</label><br />
                        <div style="display:flex">
                            <input type="text" id="txtSICode" class="form-control" disabled />
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('servicecode1');" />
                        </div>
                    </div>
                    <div class="col-sm-10">
                        <label id="lblSIDesc">Expense Description</label><br />
                        <div style="display:flex">
                            <input type="text" id="txtSDescription" class="form-control" disabled />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <label id="lblCostAmt">Cost Amount</label><br />
                        <div style="display:flex">
                            <input type="number" id="txtCostAmount" class="form-control" />
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <label id="lblChargeAmt">Charge Amount</label><br />
                        <div style="display:flex">
                            <input type="number" id="txtChargeAmount" class="form-control" />
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <label id="lblChargeCode">Charge Code</label><br />
                        <div style="display:flex">
                            <input type="text" id="txtChargeCode" class="form-control" disabled />
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('servicecode2');" />
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <br />
                        <button class="btn btn-success" id="btnSaveExp" onclick="SaveExpense()">Save Expenses</button>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div id="dvContainer" class="modal fade">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                <ul class="nav nav-tabs" style="float:right;">
                    <li class="active"><a id="linkHeader" data-toggle="tab" href="#tabHeader">Container/Cargo Info</a></li>
                    <li><a id="linkDetailTruck" data-toggle="tab" href="#tabDetailTruck">Truck Info</a></li>
                    <li><a id="linkDetailTime" data-toggle="tab" href="#tabDetailTime">Timeline Info</a></li>
                </ul>
                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="ClearDetail()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNewCont">New Container</b>
                </a>
                <a href="#" class="btn btn-success" id="btnUpdateDetail" onclick="SaveDetail()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveCont">Save Container</b>
                </a>
                <a href="#" class="btn btn-danger" id="btnDeleteDetail" onclick="DeleteDetail()" style="display:none">
                    <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelCont">Delete Container</b>
                </a>
            </div>
            <div class="modal-body">
                <div style="display:flex;">
                    <div style="flex:1">
                        <label id="lblNo">No :</label>
                        <br /><div style="display:flex"><input type="text" id="txtItemNo" class="form-control"></div>
                    </div>
                    <div style="flex:2">
                        <label id="lblContainerNo">Container </label>
                        :<br /><div style="display:flex"><input type="text" id="txtCTN_NO" class="form-control"></div>
                    </div>
                    <div style="flex:1">
                        <label id="lblContainerSize">Size</label>
                        :<br /><div style="display:flex"><select id="txtCTN_SIZE" class="form-control dropdown"></select></div>
                    </div>
                    <div style="flex:1">
                        <label id="lblSealNo">Seal No.</label>
                        :<br /><div style="display:flex"><input type="text" id="txtSealNumber" class="form-control"></div>
                    </div>
                </div>
                <div class="tab-content">
                    <div id="tabHeader" class="tab-pane fade in active" style="width:100%">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblPackDetail">Package Details</label>
                                        :<br /><div style="display:flex"><textarea id="txtProductDesc" class="form-control"></textarea></div>
                                    </div>
                                    <div class="col-sm-3">
                                        <label id="lblPackQty">Package Qty </label>
                                        :<br /><div style="display:flex"><input type="number" id="txtProductQty" class="form-control" value="0.00"></div>
                                    </div>
                                    <div class="col-sm-3">
                                        <label id="lblPackUnit">Package Unit</label>
                                        :
                                        <br />
                                        <div style="display:flex">
                                            <input type="text" id="txtProductUnit" class="form-control" style="width:100%">
                                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('servunit')" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblPrice">Price/Unit</label>
                                        :<br /><div style="display:flex"><input type="number" id="txtProductPrice" class="form-control" value="0.00"></div>
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblNW">N/W</label>
                                        :<br /><div style="display:flex"><input type="number" id="txtNetWeight" class="form-control" value="0.00"></div>
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblGW">G/W</label>
                                        :<br /><div style="display:flex"><input type="number" id="txtGrossWeight" class="form-control" value="0.00"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblM3">M3</label>
                                        :<br /><div style="display:flex"><input type="number" id="txtMeasurement" class="form-control" value="0.00"></div>
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblOperDay">Operation Days</label>
                                        :<br /><div style="display:flex"><input type="number" id="txtTimeUsed" class="form-control"></div>
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblJobStatus">Job Status</label>
                                        :<br />
                                        <div style="display:flex">
                                            <select id="txtCauseCode" class="form-control dropdown">
                                                <option value="">Checking</option>
                                                <option value="1">Working</option>
                                                <option value="2">Rejected</option>
                                                <option value="3">Finished</option>
                                                <option value="99">Cancelled</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblComment">Comment </label>
                                        :<br /><div style="display:flex"><textarea id="txtComment" class="form-control"></textarea></div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblShippingMark">Shipping Mark</label>
                                        :<br /><div style="display:flex"><textarea id="txtShippingMark" class="form-control"></textarea></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label id="lblExpCon">Expense Can Billing On This Route</label>
                                :<br />
                                <table id="tbExpense" class="table table-responsive">
                                    <thead>
                                        <tr>
                                            <th>SICode</th>
                                            <th>SDescription</th>
                                            <th>CostAmount</th>
                                        </tr>
                                    </thead>
                                    <tbody></tbody>
                                </table>
                                <a href="#" class="btn btn-primary" id="btnExpense2" onclick="EntryExpenses2()">
                                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkEntryExp2">Entry Expenses</b>
                                </a><br />
                                <label id="lblVenBill">Expense Billed By Vender</label>
                                :<br />
                                <table id="tbPayment" class="table table-responsive">
                                    <thead>
                                        <tr>
                                            <th>DocNo</th>
                                            <th>DocDate</th>
                                            <th>InvNo</th>
                                            <th>ApprNo</th>
                                            <th>PaymentNo</th>
                                            <th>TotalNet</th>
                                        </tr>
                                    </thead>
                                    <tbody></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div id="tabDetailTime" class="tab-pane fade">
                        <div class="row">
                            <div class="col-sm-4" style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                                <label id="lblPickup">Pick-up:</label>
                                <br />
                                <div style="display:flex;flex-direction:column">
                                    <div style="flex:1">
                                        <div style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                                            <div>
                                                At <select id="cboPlaceName1"></select>
                                                Contact
                                                <input type="text" id="txtPlaceContact1" />
                                                <br />
                                                <div style="display:flex">
                                                    <input type="text" id="txtPlaceName1" class="form-control" />
                                                    <button class="btn btn-default" onclick="SearchData('place1')">...</button>
                                                </div>
                                            </div>
                                            <div>
                                                Address
                                                <textarea id="txtPlaceAddress1"></textarea>
                                            </div>
                                            <div>
                                                <input type="button" class="btn btn-success" onclick="SavePlace('1')" value="Save" />
                                                <input type="button" class="btn btn-danger" onclick="DeletePlace('1')" value="Delete" />
                                            </div>
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <div style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                                            <div style="flex:1;display: flex;flex-direction: row; ">
                                                <div>
                                                    <label id="lblPickupTarget">Target Date :</label>
                                                    <br />
                                                    <div style="display:flex"><input type="date" id="txtTargetYardDate" class="form-control"></div>
                                                </div>
                                                <div>
                                                    <label id="lblPickupTargetTime"></label>
                                                    <br />
                                                    <div style="display:flex"><input type="text" id="txtTargetYardTime" class="form-control"></div>
                                                </div>
                                            </div>
                                            <div style="flex:1;display: flex;flex-direction: row; ">
                                                <div>
                                                    <label id="lblPickupActual">Actual Date :</label>
                                                    <br />
                                                    <div style="display:flex"><input type="date" id="txtActualYardDate" class="form-control"></div>
                                                </div>
                                                <div>
                                                    <label id="lblPickupActualTime">Actual Time :</label>
                                                    <br />
                                                    <div style="display:flex"><input type="text" id="txtActualYardTime" class="form-control"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                                <label id="lblDelivery">Delivery:</label>
                                <br />
                                <div style="display:flex;flex-direction:column">
                                    <div style="flex:1">
                                        <div style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                                            <div>
                                                At <select id="cboPlaceName2"></select>
                                                Contact
                                                <input type="text" id="txtPlaceContact2" />
                                                <br />
                                                <div style="display:flex">
                                                    <input type="text" id="txtPlaceName2" class="form-control" />
                                                    <button class="btn btn-default" onclick="SearchData('place2')">...</button>
                                                </div>

                                            </div>
                                            <div>
                                                Address
                                                <textarea id="txtPlaceAddress2"></textarea>
                                            </div>
                                            <div>
                                                <input type="button" class="btn btn-success" onclick="SavePlace('2')" value="Save" />
                                                <input type="button" class="btn btn-danger" onclick="DeletePlace('2')" value="Delete" />
                                            </div>
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <div style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                                            <div style="flex:1;display: flex;flex-direction: row; ">
                                                <div>
                                                    <label id="lblDeliveryTarget">Target Date :</label>
                                                    <br /><div style="display:flex"><input type="date" id="txtUnloadDate" class="form-control"></div>
                                                </div>
                                                <div>
                                                    <label id="lblDeliveryTargetTime">Target Time :</label>
                                                    <br /><div style="display:flex"><input type="text" id="txtUnloadTime" class="form-control"></div>
                                                </div>
                                            </div>
                                            <div style="flex:1;display: flex;flex-direction: row; ">
                                                <div>
                                                    <label id="lblDeliveryActual">Actual Date :</label>
                                                    <br /><div style="display:flex"><input type="date" id="txtUnloadFinishDate" class="form-control"></div>
                                                </div>
                                                <div>
                                                    <label id="lblDeliveryActualTime">Actual Time :</label>
                                                    <br /><div style="display:flex"><input type="text" id="txtUnloadFinishTime" class="form-control"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                                <label id="lblReturn">Return:</label>
                                <br />
                                <div style="display:flex;flex-direction:column">
                                    <div style="flex:1">
                                        <div style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                                            <div>
                                                At <select id="cboPlaceName3"></select>
                                                Contact
                                                <input type="text" id="txtPlaceContact3" />
                                                <br />
                                                <div style="display:flex">
                                                    <input type="text" id="txtPlaceName3" class="form-control" />
                                                    <button class="btn btn-default" onclick="SearchData('place3')">...</button>
                                                </div>
                                            </div>
                                            <div>
                                                Address
                                                <textarea id="txtPlaceAddress3"></textarea>
                                            </div>
                                            <div>
                                                <input type="button" class="btn btn-success" onclick="SavePlace('3')" value="Save" />
                                                <input type="button" class="btn btn-danger" onclick="DeletePlace('3')" value="Delete" />
                                            </div>

                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <div style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                                            <div style="flex:1;display:flex;flex-direction:row;">
                                                <div>
                                                    <label id="lblReturnTarget">Target Date:</label>
                                                    <br />
                                                    <div style="display:flex"><input type="date" id="txtTruckIN" class="form-control"></div>
                                                </div>
                                                <div>
                                                    <label id="lblReturnTargetTime">Target Time:</label>
                                                    <br />
                                                    <div style="display:flex"><input type="text" id="txtStart" class="form-control"></div>
                                                </div>
                                            </div>
                                            <div style="flex:1;display: flex;flex-direction: row; ">
                                                <div>
                                                    <label id="lblReturnActual">Actual Date:</label>
                                                    <br />
                                                    <div style="display:flex"><input type="date" id="txtDReturnDate" class="form-control"></div>
                                                </div>
                                                <div>
                                                    <label id="lblReturnActualTime">Actual Time:</label>
                                                    <br />
                                                    <div style="display:flex"><input type="text" id="txtFinish" class="form-control"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label id="lblDeliveryNo">Delivery No</label>
                                :
                                <div style="display:flex;">
                                    <div style="display:flex"><input type="text" id="txtDeliveryNo" class="form-control"></div>
                                    <button id="btnGenDeliveryNo" onclick="GenerateDO()" class="btn btn-warning">Create</button>
                                    <button id="btnPrintSlip" class="btn btn-info" onclick="PrintDelivery()">Delivery Slip</button>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div style="display:flex">
                                    <div style="flex:1">
                                        Packing
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtPlaceName4" class="form-control">
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        Address
                                        <br />
                                        <textarea id="txtPlaceAddress4" class="form-control"></textarea>
                                    </div>
                                    <div style="flex:1">
                                        Contact
                                        <br />
                                        <input type="text" class="form-control" id="txtPlaceContact4" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tabDetailTruck" class="tab-pane fade">
                        <div class="row">
                            <div class="col-sm-5">
                                <a href="~/Master/Employee"><label id="lblDriver">Driver</label></a>
                                :
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtDriver" class="form-control">
                                    <button class="btn btn-default" onclick="SearchData('driver')">...</button>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <a href="~/Master/CarLicense"><label id="lblTruckNo">Truck ID</label></a>
                                :
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtTruckNO" class="form-control">
                                    <button class="btn btn-default" onclick="SearchData('carlicense')">...</button>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <label id="lblTruckType">Type</label>
                                :
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtTruckType" class="form-control">
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('carunit')" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblRouteID">Route ID</label><input type="checkbox" id="chkAllCust" />Show All
                                :<br />
                                <div style="display:flex">
                                    <input type="text" id="txtRouteID" class="form-control" disabled />
                                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('route')" />
                                </div>
                            </div>
                            <div class="col-sm-9">
                                <label id="lblLocationD">Location</label>
                                :<br />
                                <div style="display:flex">
                                    <input type="text" id="txtLocation" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label id="lblMileBegin">Mile Begin</label>
                                :<br />
                                <div style="display:flex">
                                    <input type="number" id="txtMileBegin" class="form-control" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <label id="lblMileBegin">Mile End</label>
                                :<br />
                                <div style="display:flex">
                                    <input type="number" id="txtMileEnd" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <table class="table table-responsive" id="tbAddFuel">
                            <thead>
                                <tr>
                                    <th>No</th>
                                    <th>Date</th>
                                    <th>Total</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                        <button id="btnAddFuel" class="btn btn-warning" onclick="AddFuel()">Add Fuel Request</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="panel" style="background-color:lightgreen;padding:10px 10px 10px 10px;margin-top:10px">
    <table id="tbDetail" class="table table-responsive">
        <thead>
            <tr>
                <th>CTN_NO</th>
                <th class="desktop">CTN_SIZE</th>
                <th class="desktop">SealNumber</th>
                <th class="all">Qty</th>
                <th class="desktop">Status</th>
                <th class="desktop">G.W</th>
                <th class="desktop">PickupDate</th>
                <th class="desktop">Driver</th>
                <th class="desktop">V.Inv</th>
                <th class="desktop">Clear</th>
                <th class="desktop">Bal</th>
            </tr>
        </thead>
    </table>
    <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAddCon">Add Container</b>
    </a>
    <a href="#" class="btn btn-warning" id="btnUpdateJob" onclick="UpdateJob()">
        <i class="fa fa-lg fa-check"></i>&nbsp;<b id="linkUpCon">Update Total Container To Job</b>
    </a>
    <a href="#" class="btn btn-primary" id="btnExpense" onclick="EntryExpenses()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkEntryExp">Entry Expenses</b>
    </a>
    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrintTruck">Print Truck Order</b>
    </a>
    <select id="cboTypeForm">
        <option value="0" selected>Full</option>
        <option value="1">Short</option>
    </select>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    //define letiables
    var path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userGroup ='@ViewBag.UserGroup';
    const userRights = '@ViewBag.UserRights';
    let cust = '';
    let row = {};
    let drivers = [];
    let isjobmode = false;
    if (userGroup == 'V') {
        $('#btnBrowseVend').attr('disabled', 'disabled');
        $('#txtVenderCode').attr('disabled', 'disabled');
        $('#txtTargetYardDate').attr('disabled', 'disabled');
        $('#txtTargetYardTime').attr('disabled', 'disabled');
        $('#txtUnloadDate').attr('disabled', 'disabled');
        $('#txtUnloadTime').attr('disabled', 'disabled');
        $('#txtTruckIN').attr('disabled', 'disabled');
        $('#txtStart').attr('disabled', 'disabled');
        $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
            if (r.vender.data.length > 0) {
                let dr = r.vender.data[0];
                $('#txtVenderCode').val(dr.VenCode);
                $('#txtVenderName').val(dr.TName);
            }
        });
    }
    if (userGroup == 'C') {
        $('#btnBrowseCust').attr('disabled', 'disabled');
        $('#txtVenderCode').attr('disabled', 'disabled');
        $('#txtTargetYardDate').attr('disabled', 'disabled');
        $('#txtTargetYardTime').attr('disabled', 'disabled');
        $('#txtUnloadDate').attr('disabled', 'disabled');
        $('#txtUnloadTime').attr('disabled', 'disabled');
        $('#txtTruckIN').attr('disabled', 'disabled');
        $('#txtStart').attr('disabled', 'disabled');
        $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
            if (r.company.data.length > 0) {
                let dr = r.company.data[0];
                cust = dr.CustCode;
                $('#txtNotifyCode').val(dr.CustCode);
                $('#txtNotifyName').val(dr.NameThai);
            }
        });
    }
    $.get(path + 'Master/GetEmployee').done(function (r) {
        drivers = r.employee.data;
        SetLOVs();
        SetEvents();
    });
    function AddDetail() {
        ClearDetail();
        $('#dvContainer').modal('show');
    }
    function SetEvents() {
        ClearBooking();
        let branch = getQueryString("BranchCode");
        let job = getQueryString("JNo");
        if (branch !== '') {
            $('#txtBranchCode').val(branch);
            ShowBranch(path, branch, '#txtBranchName');
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
        if (job !== '') {
            isjobmode = true;
            $('#txtJNo').val(job);
            CallBackQueryJob(path, $('#txtBranchCode').val(), $('#txtJNo').val(), ReadJobFull);
        }
        $('#txtBookingNo').keydown(function (ev) {
            if (ev.which == 13) {
                LoadData();
            }
        });
        $('#cboPlaceName1').change(function () {
            let str = $(this).val();
            if (str !== '') {
                $('#txtPlaceName1').val($(this).find('option:selected').text());
                $('#txtPlaceAddress1').val(str.split('|')[0]);
                $('#txtPlaceContact1').val(str.split('|')[1]);
            }
        });
        $('#cboPlaceName2').change(function () {
            let str = $(this).val();
            if (str !== '') {
                $('#txtPlaceName2').val($(this).find('option:selected').text());
                $('#txtPlaceAddress2').val(str.split('|')[0]);
                $('#txtPlaceContact2').val(str.split('|')[1]);
            }
        });
        $('#cboPlaceName3').change(function () {
            let str = $(this).val();
            if (str !== '') {
                $('#txtPlaceName3').val($(this).find('option:selected').text());
                $('#txtPlaceAddress3').val(str.split('|')[0]);
                $('#txtPlaceContact3').val(str.split('|')[1]);
            }
        });
        $('#txtItemNo').keydown(function (ev) {
            if (ev.which == 13) {
                let rows = $('#tbDetail').DataTable().rows().data(); //read current row selected
                let rowFind = rows.filter(function (data) {
                    return data.ItemNo == $('#txtItemNo').val();
                });
                ClearDetail();
                if (rowFind.length > 0) {
                    row = rowFind[0];
                    ReadDetail(row);
                }
            }
        });
    }
    function SetLOVs() {
        loadLocation(path, '#cboPlaceName1', '1');
        loadLocation(path, '#cboPlaceName2', '2');
        loadLocation(path, '#cboPlaceName3', '3');
        loadUnit('#txtCTN_SIZE', path, '?Type=1');
        loadUnit('#cboContainerSize', path, '?Type=1');

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            //Routes
            CreateLOV(dv, '#frmSearchMainRoute', '#tbMainRoute', 'Transport Routes', response, 4);
            //Agent
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchServ1', '#tbServ1', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchServ2', '#tbServ2', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchRoute', '#tbRoute', 'Transport Route', response, 4);
            //Units
            CreateLOV(dv, '#frmSearchUnitS', '#tbUnitS', 'Commodity Unit', response, 2);
            CreateLOV(dv, '#frmSearchUnitC', '#tbUnitC', 'Car Unit', response, 2);
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job', response, 3);
            //Booking
            CreateLOV(dv, '#frmSearchBook', '#tbBook', 'Booking', response, 4);
            //Places
            CreateLOV(dv, '#frmSearchPlace1', '#tbPlace1', 'Pick up', response, 1);
            CreateLOV(dv, '#frmSearchPlace2', '#tbPlace2', 'Delivery', response, 1);
            CreateLOV(dv, '#frmSearchPlace3', '#tbPlace3', 'Return', response, 1);
            //Car
            CreateLOV(dv, '#frmSearchCar', '#tbCar', 'Car License', response, 2);
            //Emp
            CreateLOV(dv, '#frmSearchEmp', '#tbEmp', 'Driver', response, 2);
        });
    }
    function SearchData(type) {
        let w = '';
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'customer':
                SetGridCompanyByGroup(path, '#tbCust', 'NOTIFY_PARTY', '#frmSearchCust', ReadCustomer);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch','#frmSearchBranch', ReadBranch);
                break;
            case 'job':
                w = '';
                if (userGroup == 'V') {
                    w += '&Vend=' + $('#txtVenderCode').val();
                }
                if (userGroup == 'C') {
                    w += '&CustCode=' + cust;
                }
                SetGridJob(path, '#tbJob', '#frmSearchJob', '?branch=' + $('#txtBranchCode').val() + w, ReadJobFull);
                break;
            case 'servunit':
                SetGridServUnitFilter(path, '#tbUnitS', '?Type=0', '#frmSearchUnitS', ReadUnit);
                break;
            case 'carunit':
                SetGridServUnitFilter(path, '#tbUnitC', '?Type=2', '#frmSearchUnitC', ReadCarUnit);
                break;
            case 'booking':
                w = '?Branch=' + $('#txtBranchCode').val();
                if (userGroup == 'V') {
                    w += '&Vend=' + $('#txtVenderCode').val();
                }
                if (userGroup == 'C') {
                    w += '&Cust=' + cust;
                }
                if ($('#txtJNo').val() !== '') {
                    w += '&Job=' + $('#txtJNo').val();
                }
                SetGridTransport(path, '#tbBook', '#frmSearchBook', w, ReadBooking);
                break;
            case 'servicecode1':
                SetGridSICode(path, '#tbServ1', '', '#frmSearchServ1', ReadService1);
                break;
            case 'servicecode2':
                SetGridSICode(path, '#tbServ2', '', '#frmSearchServ2', ReadService2);
                break;
            case 'location':
                SetGridTransportPrice(path, '#tbMainRoute', '#frmSearchMainRoute','?Vend=' + $('#txtVenderCode').val() + ($('#chkAllRoute').prop('checked') ? '':'&Cust='+ $('#txtNotifyCode').val()), ReadMainRoute);
                break;
            case 'route':
                SetGridTransportPrice(path, '#tbRoute', '#frmSearchRoute', '?Vend=' + $('#txtVenderCode').val() + ($('#chkAllCust').prop('checked') ? '' : '&Cust=' + $('#txtNotifyCode').val()), ReadRoute);
                break;
            case 'place1':
                SetGridLocation(path, '#tbPlace1', '#frmSearchPlace1', '?Place=1', ReadPickup);
                break;
            case 'place2':
                SetGridLocation(path, '#tbPlace2', '#frmSearchPlace2', '?Place=2', ReadDelivery);
                break;
            case 'place3':
                SetGridLocation(path, '#tbPlace3', '#frmSearchPlace3', '?Place=3', ReadReturn);
                break;
            case 'carlicense':
                SetGridCar(path, '#tbCar', '#frmSearchCar', ReadCar);
                break;            
            case 'driver':
                SetGridEmployee(path, '#tbEmp', '#frmSearchEmp', ReadEmp);
                break;
        }
    }
    function ReadEmp(dt) {
        $('#txtDriver').val(dt.EmpCode);
    }
    function ReadCar(dt) {
        $('#txtTruckNO').val(dt.CarNo);
        //$('#txtDriver').val(dt.EmpCode);
    }
    function ReadRoute(dt) {
        $('#txtRouteID').val(dt.LocationID);
        $('#txtLocation').val(dt.Location);
        $.get(path + 'JobOrder/GetTransportRoute?ID=' + dt.LocationID).done(function (dt) {
            if (dt.transportroute.data.length > 0) {
                let r = dt.transportroute.data[0];

                let r1 = GetValueRoute(r, 1);
                let r2 = GetValueRoute(r, 2);
                let r3 = GetValueRoute(r, 3);
                let r4 = GetValueRoute(r, 4);

                $('#txtPlaceName1').val(r1.Place);
                $('#txtPlaceAddress1').val(r1.Address);
                $('#txtPlaceContact1').val(r1.Contact);

                $('#txtPlaceName2').val(r2.Place);
                $('#txtPlaceAddress2').val(r2.Address);
                $('#txtPlaceContact2').val(r2.Contact);

                $('#txtPlaceName3').val(r3.Place);
                $('#txtPlaceAddress3').val(r3.Address);
                $('#txtPlaceContact3').val(r3.Contact);

                $('#txtPlaceName4').val(r4.Place);
                $('#txtPlaceAddress4').val(r4.Address);
                $('#txtPlaceContact4').val(r4.Contact);

            }
        });
        ShowExpense();
        ShowAddFuel();
        ShowPayment();
    }
    function ReadPickup(r) {
        $('#txtPlaceName1').val(r.Place);
        $('#txtPlaceAddress1').val(r.Address);
        $('#txtPlaceContact1').val(r.Contact);
    }
    function ReadDelivery(r) {
        $('#txtPlaceName2').val(r.Place);
        $('#txtPlaceAddress2').val(r.Address);
        $('#txtPlaceContact2').val(r.Contact);
    }
    function ReadReturn(r) {
        $('#txtPlaceName3').val(r.Place);
        $('#txtPlaceAddress3').val(r.Address);
        $('#txtPlaceContact3').val(r.Contact);
    }
    function GetValueRoute(r,idx) {
        let c = r.RouteFormat.indexOf(idx);
        if (c >=0) {
            let v = {};
            switch (c) {
                case 0:
                    v= {
                        Place: r.Place1,
                        Address: r.Address1,
                        Contact: r.Contact1,
                    }
                    break;
                case 1:
                    v= {
                        Place: r.Place2,
                        Address: r.Address2,
                        Contact: r.Contact2,
                    }
                    break;
                case 2:
                    v= {
                        Place: r.Place3,
                        Address: r.Address3,
                        Contact: r.Contact3,
                    }
                    break;
                case 3:
                    v= {
                        Place: r.Place4,
                        Address: r.Address4,
                        Contact: r.Contact4,
                    }
                    break;
                default:
                    v = {
                        Place: '',
                        Address: '',
                        Contact:''
                    }
                    break;
            }
            return v;
        } else {
            return {
                Place: '',
                Address: '',
                Contact:''
            }
        }
    }
    function ReadMainRoute(dr) {
        $('#txtMainRoute').val(dr.LocationID);
        $('#txtMainLocation').val(dr.Location);
        $.get(path + 'JobOrder/GetTransportRoute?ID=' + dr.LocationID).done(function (dt) {
            if (dt.transportroute.data.length > 0) {
                let r = dt.transportroute.data[0];
                $('#cboTemplate').val(r.RouteFormat);

                let r1 = GetValueRoute(r, 1);
                let r2 = GetValueRoute(r, 2);
                let r3 = GetValueRoute(r, 3);
                let r4 = GetValueRoute(r, 4);

                $('#txtPlace1').val(r1.Place);
                $('#txtAddress1').val(r1.Address);
                $('#txtContact1').val(r1.Contact);

                $('#txtPlace2').val(r2.Place);
                $('#txtAddress2').val(r2.Address);
                $('#txtContact2').val(r2.Contact);

                $('#txtPlace3').val(r3.Place);
                $('#txtAddress3').val(r3.Address);
                $('#txtContact3').val(r3.Contact);

                $('#txtPlace4').val(r4.Place);
                $('#txtAddress4').val(r4.Address);
                $('#txtContact4').val(r4.Contact);
            }
        });
    }
    function ReadService1(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameThai);
        $('#txtChargeAmount').val(CDbl(dt.StdPrice,2));
        $('#txtCostAmount').val(CDbl(dt.StdPrice, 2));
        LoadExpense();
    }
    function ReadService2(dt) {
        $('#txtChargeCode').val(dt.SICode);
        //$('#txtSDescription').val(dt.NameThai);
    }
    function ReadVender(dt) {
        $('#txtVenderCode').val(dt.VenCode);
        $('#txtVenderName').val(dt.TName);
    }
    function ReadCustomer(dt) {
        $('#txtNotifyCode').val(dt.CustCode);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtNotifyName');
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadJobFull(dr) {
        if (dr.length > 0) {
            dr = dr[0];
        }
        $('#txtJNo').val(dr.JNo);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtVenderCode').val(dr.AgentCode);
        ShowVender(path, dr.AgentCode, '#txtVenderName');
        //ShowVender(path, dr.AgentCode, '#txtPaymentBy');
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtNotifyCode').val(dr.Consigneecode);
        ShowCompany(path, dr.Consigneecode, '#txtNotifyName');
        $('#txtContactName').val(dr.CustContactName);
        //$('#txtPackingDate').val(CDateEN(dr.JobType==1? dr.ETADate : dr.ETDDate));
        //$('#txtFactoryDate').val(CDateEN(dr.EstDeliverDate));
        $('#txtPlace3').val(dr.DeliveryTo);
        $('#txtAddress3').val(dr.DeliveryAddr);
        $('#txtProductDesc').val(dr.InvProduct);
        $('#txtProductQty').val('0.00');
        $('#txtProductUnit').val(dr.InvProductUnit);
        $('#txtGrossWeight').val(dr.TotalGW);
        $('#txtProductPrice').val(dr.InvTotal);
        $('#txtNetWeight').val(dr.TotalNW);
        $('#txtMeasurement').val(dr.Measurement);
        if (isjobmode == true) {
            LoadData();
        } else {
            if (dr.BookingNo !== '') {
                LoadData();
            }
        }
    }
    function ReadBooking(dr, loadcont = true) {
        $('#txtBranchCode').val(dr.BranchCode);
        ShowBranch(path, dr.BranchCode, '#txtBranchName');
        $('#txtJNo').val(dr.JNo);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtVenderCode').val(dr.VenderCode);
        ShowVender(path, dr.VenderCode, '#txtVenderName');
        $('#txtContactName').val(dr.ContactName);
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtRemark').val(dr.Remark);
        $('#txtPlace1').val(dr.CYPlace);
        $('#txtPlace2').val(dr.FactoryPlace);
        $('#txtPlace3').val(dr.PackingPlace);
        $('#txtPlace4').val(dr.ReturnPlace);
        $('#txtAddress1').val(dr.CYAddress);
        $('#txtAddress2').val(dr.FactoryAddress);
        $('#txtAddress3').val(dr.PackingAddress);
        $('#txtAddress4').val(dr.ReturnAddress);
        $('#txtContact1').val(dr.CYContact);
        $('#txtContact2').val(dr.FactoryContact);
        $('#txtContact3').val(dr.PackingContact);
        $('#txtContact4').val(dr.ReturnContact);
        $('#txtPackingDate').val(CDateEN(dr.PackingDate));
        $('#txtCYDate').val(CDateEN(dr.CYDate));
        $('#txtFactoryDate').val(CDateEN(dr.FactoryDate));
        $('#txtReturnDate').val(CDateEN(dr.ReturnDate));
        $('#txtPackingTime').val(ShowTime(dr.PackingTime));
        $('#txtCYTime').val(ShowTime(dr.CYTime));
        $('#txtFactoryTime').val(ShowTime(dr.FactoryTime));
        $('#txtReturnTime').val(ShowTime(dr.ReturnTime));
        $('#txtNotifyCode').val(dr.NotifyCode);
        ShowCompany(path, dr.NotifyCode, '#txtNotifyName');
        $('#txtTransMode').val(dr.TransMode);
        $('#txtPaymentCondition').val(CStr(dr.PaymentCondition));
        $('#txtPaymentBy').val(dr.PaymentBy);
        if (loadcont == true) {
            LoadDetail(dr.BranchCode, dr.BookingNo);
        }
    }
    function LoadDetail(code,doc) {
        $('#tbDetail').DataTable().clear().draw();
        $.get(path + 'joborder/gettransportdetail?Branch=' + code + '&Code=' + doc).done(function (r) {
            let dr = r.transport.detail;
            if (dr.length > 0) {
                CountContainer(dr);
                ReadContainer(dr);
            }
        });
    }
    function CountContainer(dr) {
        let countA=dr.filter(function (el) {
            return CNum(el.CauseCode) >= 1 && CNum(el.CauseCode) < 99;
        }).length;
        let countF=dr.filter(function (el) {
            return CNum(el.CauseCode) ==3;
        }).length;
        let countC = dr.filter(function (el) {
            return CNum(el.CauseCode) == 0 || CNum(el.CauseCode) == 99;
        }).length;
        $('#txtTotalTripA').val(countA);
        $('#txtTotalTripF').val(countF);
        $('#txtTotalTripC').val(countC);
    }
    function ReadContainer(dr) {
        let tb=$('#tbDetail').DataTable({
            data: dr,
            columns: [
                {
                    data: null, title: "Container No",
                    render: function (data) {
                        return data.ItemNo + '.' + data.CTN_NO;
                    }
                },
                { data: "CTN_SIZE", title: "Container Size" },
                { data: "SealNumber", title: "Seal" },
                { data: "ProductQty", title: "Qty" },
                {
                    data: "CauseCode", title: "Status",
                    render: function (data) {
                        switch (data) {
                            case '1':
                                return 'Working';
                            case '2':
                                return 'Reject';
                            case '3':
                                return 'Finished';
                            case '99':
                                return 'Cancel';
                        }
                        return 'Checking';
                    }
                },
                { data: "GrossWeight", title: "G.W" },
                {
                    data: null, title: "Pickup Date",
                    render: function (data) {
                        return CDateEN(data.TargetYardDate);
                    }
                },
                {
                    data: "Driver", title: "Driver",
                    render: function (data) {
                        if (drivers.length > 0) {
                            let filter = drivers.filter(function (d) {
                                return d.EmpCode == data;
                            });
                            if (filter.length > 0) {
                                return filter[0].Name;
                            } else {
                                return data;
                            }
                        } else {
                            return data;
                        }
                    }
                },
                { data: "CountBill", title: "V.Bill" },
                { data: "CountClear", title: "S.Clear" },
                { data: "CountBalance", title: "Balance" }
            ],
            destroy: true,
            responsive: true
            , pageLength: 100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail tbody').on('click', 'tr', function () {
            SetSelect('#tbDetail', this);
            row = $('#tbDetail').DataTable().row(this).data(); //read current row selected
            ClearDetail();
            ReadDetail(row);
        });
        $('#tbDetail tbody').on('dblclick', 'tr', function () {
            $('#dvContainer').modal('show');
        });
    }
    function PrintData() {
        if ($('#cboTypeForm').val()=="0") {
            window.open(path + 'JobOrder/TruckOrder?BranchCode=' + row.BranchCode + '&BookingNo=' + row.BookingNo + '&ContainerNo=' + row.CTN_NO, '', '');
        }
        if ($('#cboTypeForm').val()=="1") {
            window.open(path + 'JobOrder/FormTruckOrder?BranchCode=' + row.BranchCode + '&BookingNo=' + row.BookingNo + '&ContainerNo=' + row.CTN_NO, '', '');
        }
    }
    function LoadData() {
        let branch = $('#txtBranchCode').val();
        let job = $('#txtJNo').val();
        let code = $('#txtBookingNo').val();
        if (isjobmode == false) {
            ClearBooking();
        }
        $.get(path + 'joborder/gettransport?Branch='+ branch +'&Code=' + code + '&Job=' + job).done(function (r) {
            let dr = r.transport;
            if (dr.header.length > 0) {
                ReadBooking(dr.header[0],true);
                //ReadContainer(dr.detail);
            }
        });
    }

    //CRUD Functions used in HTML Java Scripts
    function DeleteBooking() {
        let code = $('#txtBookingNo').val();
        let branch = $('#txtBranchCode').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'joborder/deltransportheader?branch=' + branch + '&code=' + code, function (r) {
                ShowMessage(r.transport.result);
                ClearBooking();
            });
        });
    }
    function SaveBooking() {
        let obj = {
            BranchCode:$('#txtBranchCode').val(),
            JNo:$('#txtJNo').val(),
            VenderCode:$('#txtVenderCode').val(),
            ContactName:$('#txtContactName').val(),
            BookingNo:$('#txtBookingNo').val(),
            LoadDate:CDateEN($('#txtLoadDate').val()),
            Remark:$('#txtRemark').val(),
            CYPlace: $('#txtPlace1').val(),
            CYAddress:$('#txtAddress1').val(),
            CYContact:$('#txtContact1').val(),
            FactoryPlace: $('#txtPlace2').val(),
            FactoryAddress: $('#txtAddress2').val(),
            FactoryContact:$('#txtContact2').val(),
            PackingPlace: $('#txtPlace3').val(),
            PackingAddress: $('#txtAddress3').val(),
            PackingContact: $('#txtContact3').val(),
            ReturnPlace: $('#txtPlace4').val(),
            ReturnAddress: $('#txtAddress4').val(),
            ReturnContact:$('#txtContact4').val(),
            PackingDate:CDateEN($('#txtPackingDate').val()),
            CYDate:CDateEN($('#txtCYDate').val()),
            FactoryDate:CDateEN($('#txtFactoryDate').val()),
            ReturnDate:CDateEN($('#txtReturnDate').val()),
            PackingTime:$('#txtPackingTime').val(),
            CYTime:$('#txtCYTime').val(),
            FactoryTime:$('#txtFactoryTime').val(),
            ReturnTime:$('#txtReturnTime').val(),
            NotifyCode:$('#txtNotifyCode').val(),
            TransMode:$('#txtTransMode').val(),
            PaymentCondition:$('#txtPaymentCondition').val(),
            PaymentBy:$('#txtPaymentBy').val()
	    };
        if (obj.BookingNo != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetTransportHeader", "JobOrder")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtBookingNo').val(response.result.data);
                            $('#txtBookingNo').focus();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    function ClearBooking() {
        $('#txtJNo').val('');
        if (userGroup !== 'V') {
            $('#txtVenderCode').val('');
            $('#txtVenderName').val('');
        }
        $('#txtContactName').val('');
        $('#txtBookingNo').val('');
        $('#txtLoadDate').val('');
        $('#txtRemark').val('');
        $('#txtPlace2').val('');
        $('#txtPlace1').val('');
        $('#txtPlace3').val('');
        $('#txtPlace4').val('');
        $('#txtPackingDate').val('');
        $('#txtCYDate').val('');
        $('#txtFactoryDate').val('');
        $('#txtReturnDate').val('');
        $('#txtPackingTime').val('00:00');
        $('#txtCYTime').val('00:00');
        $('#txtFactoryTime').val('00:00');
        $('#txtReturnTime').val('00:00');
        $('#txtAddress2').val('');
        $('#txtAddress1').val('');
        $('#txtAddress3').val('');
        $('#txtAddress4').val('');
        $('#txtContact2').val('');
        $('#txtContact1').val('');
        $('#txtContact3').val('');
        $('#txtContact4').val('');
        $('#txtNotifyCode').val('');
        $('#txtNotifyName').val('');
        $('#txtTransMode').val('CY-CY');
        $('#txtPaymentCondition').val('');
        $('#txtPaymentBy').val('');
        $('#tbDetail').DataTable().clear().draw();
        $('#txtTotalTripA').val(0);
        $('#txtTotalTripF').val(0);
        $('#txtTotalTripC').val(0);
        $('#txtMainRoute').val('');
        $('#txtMainLocation').val('');
    }
    function PrintBooking() {
        switch ($('#cboPrintForm').val()) {
            case 'TI':
                window.open(path + 'JobOrder/FormBookingIm?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'TE':
                window.open(path + 'JobOrder/FormBookingEx?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BA':
                window.open(path + 'JobOrder/FormBookingAir?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BS':
                window.open(path + 'JobOrder/FormBookingSea?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'SP':
                window.open(path + 'JobOrder/FormBooking?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BLS':
                window.open(path + 'JobOrder/FormTransport?Type=SEA&BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BLW':
                window.open(path + 'JobOrder/FormTransport?Type=WALMAY&BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BLE':
                window.open(path + 'JobOrder/FormTransport?Type=EASTRONG&BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'HAW':
                window.open(path + 'JobOrder/FormTransport?Type=HAIR&BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'MAW':
                window.open(path + 'JobOrder/FormTransport?Type=MAIR&Branch=' + $('#txtBranchCode').val() + '&Code=' + $('#txtJNo').val(), '', '');
                break;
            case 'DO':
                window.open(path + 'JobOrder/FormLetter?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
                break;
            case 'SC':
                window.open(path + 'JobOrder/FormSalesContract?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BK':
                window.open(path + 'JobOrder/FormInvoice?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'PL':
                window.open(path + 'JobOrder/FormPackingList?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
        }
    }
    function ClearDetail() {
        $('#txtItemNo').val('0');
        $('#txtCTN_NO').val('');
        $('#txtSealNumber').val('');
        $('#txtTruckNO').val('');
        $('#txtTruckIN').val($('#txtReturnDate').val());
        $('#txtStart').val($('#txtReturnTime').val());
        $('#txtDReturnDate').val('');
        $('#txtFinish').val('00:00');
        $('#txtTimeUsed').val('');
        $('#txtCauseCode').val('');
        $('#txtComment').val('');
        $('#txtTruckType').val('');
        $('#txtDriver').val('');
        $('#txtTargetYardDate').val($('#txtCYDate').val());
        $('#txtTargetYardTime').val($('#txtCYTime').val());
        $('#txtActualYardDate').val('');
        $('#txtActualYardTime').val('00:00');
        $('#txtUnloadDate').val($('#txtFactoryDate').val());
        $('#txtUnloadTime').val($('#txtFactoryTime').val());
        $('#txtUnloadFinishDate').val('');
        $('#txtUnloadFinishTime').val('00:00');
        $('#txtLocation').val($('#txtRoute').val());
        $('#txtRouteID').val($('#txtMainRoute').val());
        $('#txtDeliveryNo').val('');
        $('#txtShippingMark').val('');
        $('#txtCTN_SIZE').val('');
        $('#cboPlaceName1').val('');
        $('#cboPlaceName2').val('');
        $('#cboPlaceName3').val('');
        $('#txtPlaceName1').val('');
        $('#txtPlaceAddress1').val('');
        $('#txtPlaceContact1').val('');
        $('#txtPlaceName2').val('');
        $('#txtPlaceAddress2').val('');
        $('#txtPlaceContact2').val('');
        $('#txtPlaceName3').val('');
        $('#txtPlaceAddress3').val('');
        $('#txtPlaceContact3').val('');
        $('#txtPlaceName4').val('');
        $('#txtPlaceAddress4').val('');
        $('#txtPlaceContact4').val('');
        if (isjobmode == false) {
            $('#txtProductDesc').val('');
            $('#txtProductQty').val('0.00');
            $('#txtProductUnit').val('');
            $('#txtGrossWeight').val('0.00');
            $('#txtNetWeight').val('0.00');
            $('#txtMeasurement').val('0.00');
            $('#txtProductPrice').val('0.00');
        }
        $('#txtMileBegin').val(0);
        $('#txtMileEnd').val(0);
        ShowExpense();
        ShowAddFuel();
        ShowPayment();
    }
    function SaveDetail() {
	if($('#txtDriver').val()==''){
		ShowMessage('Please enter driver',true);
		return;
	}
	if($('#txtTruckNO').val()==''){
		ShowMessage('Please enter truck no',true);
		return;
	}
        let obj = {
            BranchCode:$('#txtBranchCode').val(),
            JNo:$('#txtJNo').val(),
            ItemNo:$('#txtItemNo').val(),
            CTN_NO:$('#txtCTN_NO').val(),
            SealNumber:$('#txtSealNumber').val(),
            TruckNO:$('#txtTruckNO').val(),
            TruckIN:CDateEN($('#txtTruckIN').val()),
            Start:$('#txtStart').val(),
            Finish:$('#txtFinish').val(),
            TimeUsed:$('#txtTimeUsed').val(),
            CauseCode:$('#txtCauseCode').val(),
            Comment:$('#txtComment').val(),
            TruckType:$('#txtTruckType').val(),
            Driver:$('#txtDriver').val(),
            TargetYardDate:CDateEN($('#txtTargetYardDate').val()),
            TargetYardTime:$('#txtTargetYardTime').val(),
            ActualYardDate:CDateEN($('#txtActualYardDate').val()),
            ActualYardTime:$('#txtActualYardTime').val(),
            UnloadFinishDate:CDateEN($('#txtUnloadFinishDate').val()),
            UnloadFinishTime:$('#txtUnloadFinishTime').val(),
            UnloadDate:CDateEN($('#txtUnloadDate').val()),
            UnloadTime:$('#txtUnloadTime').val(),
            Location: $('#txtLocation').val(),
            LocationID: $('#txtRouteID').val(),
            ReturnDate:CDateEN($('#txtDReturnDate').val()),
            ShippingMark:$('#txtShippingMark').val(),
            ProductDesc:$('#txtProductDesc').val(),
            CTN_SIZE:$('#txtCTN_SIZE').val(),
            ProductQty:CNum($('#txtProductQty').val()),
            ProductUnit:$('#txtProductUnit').val(),
            GrossWeight:CNum($('#txtGrossWeight').val()),
            Measurement:CNum($('#txtMeasurement').val()),
            BookingNo: $('#txtBookingNo').val(),
            DeliveryNo: $('#txtDeliveryNo').val(),
            ProductPrice: CNum($('#txtProductPrice').val()),
            NetWeight: CNum($('#txtNetWeight').val()),
            PlaceName1: $('#txtPlaceName1').val(),
            PlaceAddress1: $('#txtPlaceAddress1').val(),
            PlaceContact1: $('#txtPlaceContact1').val(),
            PlaceName2: $('#txtPlaceName2').val(),
            PlaceAddress2: $('#txtPlaceAddress2').val(),
            PlaceContact2: $('#txtPlaceContact2').val(),
            PlaceName3: $('#txtPlaceName3').val(),
            PlaceAddress3: $('#txtPlaceAddress3').val(),
            PlaceContact3: $('#txtPlaceContact3').val(),
            PlaceName4: $('#txtPlaceName4').val(),
            PlaceAddress4: $('#txtPlaceAddress4').val(),
            PlaceContact4: $('#txtPlaceContact4').val(),
            MileBegin: $('#txtMileBegin').val(),
            MileEnd: $('#txtMileEnd').val()
        };
        if (obj.ItemNo != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                row = obj;
                let jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetTransportDetail", "JobOrder")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtItemNo').val(response.result.data);
                            $('#txtItemNo').focus();
                            if (($('#txtCauseCode').val() == '2' || $('#txtCauseCode').val() == '3') && ($('#txtCTN_NO').val() !== '')) {
                                $('#btnExpense2').removeAttr('disabled');
                            } else {
                                $('#btnExpense2').attr('disabled','disabled');
                            }
                            LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    function ReadDetail(dr){
        $('#txtItemNo').val(dr.ItemNo);
        $('#txtCTN_NO').val(dr.CTN_NO);
        $('#txtSealNumber').val(dr.SealNumber);
        $('#txtTruckNO').val(dr.TruckNO);
        $('#txtTruckIN').val(CDateEN(dr.TruckIN));
        $('#txtStart').val(ShowTime(dr.Start));
        $('#txtFinish').val(ShowTime(dr.Finish));
        $('#txtTimeUsed').val(dr.TimeUsed);
        $('#txtCauseCode').val(dr.CauseCode);
        if (dr.CauseCode == '99') {
            $('#btnDeleteDetail').show();
        } else {
            if ((dr.CauseCode == '2' || dr.CauseCode == '3') && dr.CTN_NO !== '') {
                $('#btnExpense2').removeAttr('disabled');
            } else {
                $('#btnExpense2').attr('disabled', 'disabled');
            }
            $('#btnDeleteDetail').hide();
        }
        $('#txtComment').val(dr.Comment);
        $('#txtTruckType').val(dr.TruckType);
        $('#txtDriver').val(dr.Driver);
        $('#txtTargetYardDate').val(CDateEN(dr.TargetYardDate));
        $('#txtTargetYardTime').val(ShowTime(dr.TargetYardTime));
        $('#txtActualYardDate').val(CDateEN(dr.ActualYardDate));
        $('#txtActualYardTime').val(ShowTime(dr.ActualYardTime));
        $('#txtUnloadFinishDate').val(CDateEN(dr.UnloadFinishDate));
        $('#txtUnloadFinishTime').val(ShowTime(dr.UnloadFinishTime));
        $('#txtUnloadDate').val(CDateEN(dr.UnloadDate));
        $('#txtUnloadTime').val(ShowTime(dr.UnloadTime));
        $('#txtLocation').val(dr.Location);
        $('#txtRouteID').val(dr.LocationID);
        if (dr.LocationID == 0 && $('#txtMainRoute').val() !== '') {
            $('#txtRouteID').val($('#txtMainRoute').val());
            $('#txtLocation').val($('#txtMainLocation').val());
        }
        $('#txtDeliveryNo').val(dr.DeliveryNo);
        $('#txtDReturnDate').val(CDateEN(dr.ReturnDate));
        $('#txtShippingMark').val(dr.ShippingMark);
        $('#txtProductDesc').val(dr.ProductDesc);
        $('#txtCTN_SIZE').val(dr.CTN_SIZE);
        $('#txtProductQty').val(dr.ProductQty);
        $('#txtProductUnit').val(dr.ProductUnit);
        $('#txtGrossWeight').val(dr.GrossWeight);
        $('#txtMeasurement').val(dr.Measurement);
        $('#txtNetWeight').val(dr.NetWeight);
        $('#txtProductPrice').val(dr.ProductPrice);
        $('#txtPlaceName1').val(dr.PlaceName1);
        $('#txtPlaceAddress1').val(dr.PlaceAddress1);
        $('#txtPlaceContact1').val(dr.PlaceContact1);
        $('#txtPlaceName2').val(dr.PlaceName2);
        $('#txtPlaceAddress2').val(dr.PlaceAddress2);
        $('#txtPlaceContact2').val(dr.PlaceContact2);
        $('#txtPlaceName3').val(dr.PlaceName3);
        $('#txtPlaceAddress3').val(dr.PlaceAddress3);
        $('#txtPlaceContact3').val(dr.PlaceContact3);
        $('#txtPlaceName4').val(dr.PlaceName4);
        $('#txtPlaceAddress4').val(dr.PlaceAddress4);
        $('#txtPlaceContact4').val(dr.PlaceContact4);
        $('#txtMileBegin').val(dr.MileBegin);
        $('#txtMileEnd').val(dr.MileEnd);
        ShowExpense();
        ShowAddFuel();
        ShowPayment();
    }
    function DeleteDetail() {
        if ($('#txtCauseCode').val() == '99' || $('#txtCauseCode').val() === '') {
            ShowConfirm('Please confirm to delete', function (ask) {
                if (ask == false) return;
                let branch = $('#txtBranchCode').val();
                let code = $('#txtBookingNo').val();
                let item = $('#txtItemNo').val();
                $.get(path + 'joborder/deltransportdetail?branch=' + branch + '&code=' + code + '&item=' + item).done(function (r) {
                    LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
                    $('#dvContainer').modal('hide');
                    ShowMessage(r.transport.result);
                });
            });
        }
    }
    function ReadUnit(dr) {
        $('#txtProductUnit').val(dr.UnitType);
    }
    function ReadCarUnit(dr) {
        $('#txtTruckType').val(dr.UnitType);
    }
    function GenerateDO() {
        let branch = $('#txtBranchCode').val();
        let code = $('#txtBookingNo').val();
        let item = $('#txtItemNo').val();
        $.get(path + 'JobOrder/GetNewDelivery?Branch=' + branch + '&Code=' + code + '&Item=' + item, function (r) {
            if (r.substr(0, 1) !== "[") {
                $('#txtDeliveryNo').val(r);
            }
            LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
            ShowMessage(r);
        });
    }
    function EntryExpenses() {
        if (row.ItemNo !== undefined) {
            if (row.CauseCode == '2' || row.CauseCode == '3') {
                window.open(path + 'Acc/Expense?BranchCode=' + row.BranchCode + '&BookNo=' + row.BookingNo + '&Item=' + row.ItemNo + '&Job=' + $('#txtJNo').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cont=' + row.CTN_NO + '&Cust=' + $('#txtNotifyCode').val() + '&Route=' + $('#txtRouteID').val(), '', '');
            } else {
                ShowMessage('Current document status is not allow to do this',true);
            }
        }
    }
    function EntryExpenses2() {
        if ($('#txtCauseCode').val() == '2' || $('#txtCauseCode').val() == '3') {
            window.open(path + 'Acc/Expense?BranchCode=' + $('#txtBranchCode').val() + '&BookNo=' + $('#txtBookingNo').val() + '&Item=' + $('#txtItemNo').val() + '&Job=' + $('#txtJNo').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cont=' + $('#txtCTN_NO').val() + '&Cust=' + $('#txtNotifyCode').val() + '&Route='+ $('#txtRouteID').val(), '', '');
        } else {
            ShowMessage('Current document status is not allow to do this', true);
        }
    }
    function LoadExpense() {
        $.get(path + 'JobOrder/GetTransportPrice?Branch='+$('#txtBranchCode').val()+'&ID=' + $('#txtLocationID').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cust=' + $('#txtNotifyCode').val() + '&Code=' + $('#txtSICode').val(), function (r) {
            if (r.transportprice.data.length>0) {
                let dr = r.transportprice.data[0];
                $('#txtCostAmount').val(CDbl(dr.CostAmount,2));
                $('#txtChargeAmount').val(CDbl(dr.ChargeAmount, 2));
                $('#txtChargeCode').val(dr.ChargeCode);
            }
        });
    }
    function SaveLocation(active = true) {
        if ($('#txtPlace1').val() !== '') {
            let routeFormat = $('#cboTemplate').val();
            let idx1 = (routeFormat.length > 0 ? routeFormat.substr(0, 1) : 0);
            let idx2 = (routeFormat.length > 1 ? routeFormat.substr(1, 1) : 0);
            let idx3 = (routeFormat.length > 2 ? routeFormat.substr(2, 1) : 0);
            let idx4 = (routeFormat.length > 3 ? routeFormat.substr(3, 1) : 0);

            let obj = {
                LocationID: $('#txtMainRoute').val(),
                Place1: $('#txtPlace' + idx1).val(),
                Place2: $('#txtPlace' + idx2).val(),
                Place3: $('#txtPlace' + idx3).val(),
                Place4: $('#txtPlace' + idx4).val(),
                Address1: $('#txtAddress' + idx1).val(),
                Address2: $('#txtAddress' + idx2).val(),
                Address3: $('#txtAddress' + idx3).val(),
                Address4: $('#txtAddress' + idx4).val(),
                Contact1: $('#txtContact' + idx1).val(),
                Contact2: $('#txtContact' + idx2).val(),
                Contact3: $('#txtContact' + idx3).val(),
                Contact4: $('#txtContact' + idx4).val(),
                LocationRoute: $('#txtMainLocation').val(),
                IsActive: active,
                RouteFormat: $('#cboTemplate').val()
            };
            let jsonText = JSON.stringify({ data: obj });
            $.ajax({
                url: "@Url.Action("SetTransportRoute", "JobOrder")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        if (response.result.data >= 0) {
                            ShowMessage('Save Complete');
                        }
                        return;
                    }
                    ShowMessage(response.result.msg,true);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('Please enter some data',true);
        }
    }
    function SaveExpense() {
        if ($('#txtSICode').val() !== '') {
            let obj = {
                BranchCode: $('#txtBranchCode').val(),
                LocationID: $('#txtLocationID').val(),
                VenderCode: $('#txtVenderCode').val(),
                CustCode: $('#txtNotifyCode').val(),
                SICode: $('#txtSICode').val(),
                SDescription: $('#txtSDescription').val(),
                CostAmount: CDbl($('#txtCostAmount').val(),2),
                ChargeAmount: CDbl($('#txtChargeAmount').val(), 2),
                Location: $('#txtLocationRoute').val(),
                ChargeCode: $('#txtChargeCode').val()
            };
            let jsonText = JSON.stringify({ data: obj });
            $.ajax({
                url: "@Url.Action("SetTransportPrice", "JobOrder")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != null) {
                        if (response.result.data >= 0) {
                            ShowMessage('Save Complete');
                        }

                        return;
                    }
                    ShowMessage(response.result.msg,true);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('Please enter some data',true);
        }
    }
    function LoadExpense() {
        let w = '?Branch=' + $('#txtBranchCode').val();
        if ($('#txtLocationID').val() !== '' && $('#txtLocationID').val() !== null) {
            w += '&ID=' + $('#txtLocationID').val();
        }
        if ($('#txtVenderCode').val() !== '') {
            w += '&Vend=' + $('#txtVenderCode').val();
        }
        if ($('#txtNotifyCode').val() !== '') {
            w += '&Cust=' + $('#txtNotifyCode').val();
        }
        $('#tbPrice').DataTable().clear().draw();
        $.get(path + 'JobOrder/GetTransportPrice' + w).done((r) => {
            if (r.transportprice.data.length > 0) {
                let tb=$('#tbPrice').DataTable({
                    data: r.transportprice.data,
                    columns: [
                        { data: "SICode", title: "Cost.Cde" },
                        { data: "SDescription", title: "Cost.Desc" },
                        { data: "CostAmount", title: "Cost.Amt" },
                        { data: "ChargeCode", title: "Charge.Cde" },
                        { data: "ChargeAmount", title: "Charge.Amt" }
                    ],
                    destroy: true
                    , pageLength: 100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbPrice');
                $('#tbPrice tbody').on('click', 'tr', function () {
                    $('#tbPrice tbody > tr').removeClass('selected');
                    $(this).addClass('selected');

                    let data = $('#tbPrice').DataTable().row(this).data();
                    $('#txtSICode').val(data.SICode);
                    $('#txtSDescription').val(data.SDescription);
                    $('#txtCostAmount').val(data.CostAmount);
                    $('#txtChargeCode').val(data.ChargeCode);
                    $('#txtChargeAmount').val(data.ChargeAmount);
                });
            }
        });
    }
    function EditExpense() {
        if ($('#txtVenderCode').val() == '') {
            ShowMessage('Please choose vender first',true);
            return;
        }
        if ($('#txtNotifyCode').val() == '') {
            ShowMessage('Please choose notify party',true);
            return;
        }
        if ($('#txtBranchCode').val() == '') {
            ShowMessage('Please input branch',true);
            return;
        }
        if ($('#txtMainRoute').val() !== '') {
            $('#txtLocationID').val($('#txtMainRoute').val());
            $('#txtLocationRoute').val($('#txtMainLocation').val());
            LoadExpense();
            $('#dvExpenses').modal('show');
        } else {
            ShowMessage('Please choose route',true);
        }
    }
    function ShowExpense() {
        $('#tbExpense').DataTable().clear().draw();
        $.get(path + 'JobOrder/GetTransportPrice?ID=' + $('#txtRouteID').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cust=' + $('#txtNotifyCode').val()).done((r) => {
            if (r.transportprice.data.length > 0) {
                let tb=$('#tbExpense').DataTable({
                    data: r.transportprice.data,
                    columns: [
                        { data: "SICode", title: "Cost.Cde" },
                        { data: "SDescription", title: "Cost.Desc" },
                        { data: "CostAmount", title: "Cost.Amt" }
                    ],
                    destroy: true
                    , pageLength: 100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbExpense');
            }
        });
    }
    function ShowPayment() {
        $('#txtCTN_NO').removeAttr('disabled');
        $('#btnExpense2').attr('disabled', 'disabled');
        $('#tbPayment').DataTable().clear().draw();
        if ($('#txtCTN_NO').val() !== '') {
            $.get(path + 'Acc/GetPayment?VenCode=' + $('#txtVenderCode').val() + '&Ref=' + $('#txtCTN_NO').val() + '&Job='+ $('#txtJNo').val() +'&Status=Y').done((r) => {
                if (r.payment.header.length > 0) {
                    $('#txtCTN_NO').attr('disabled', 'disabled');
                    let tb = $('#tbPayment').DataTable({
                        data: r.payment.header,
                        columns: [
                            { data: "DocNo", title: "Doc.No" },
                            { data: "DocDate", title: "Date" },
                            { data: "PoNo", title: "Inv.No" },
                            { data: "ApproveRef", title: "Appr.No" },
                            { data: "PaymentRef", title: "Payment.No" },
                            { data: "TotalNet", title: "Total" }
                        ],
                        destroy: true
                        , pageLength: 100
                    });
                    ChangeLanguageGrid('@ViewBag.Module', '#tbPayment');
                    $('#tbPayment tbody').on('dblclick', 'tr', function () {
                        let row = $('#tbPayment').DataTable().row(this).data();
                        window.open(path + 'Acc/Expense?BranchCode=' + row.BranchCode + '&DocNo=' + row.DocNo + '&BookNo=' + $('#txtBookingNo').val() + '&Item=' + $('#txtItemNo').val() + '&Job=' + $('#txtJNo').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cont=' + $('#txtCTN_NO').val() + '&Cust=' + $('#txtNotifyCode').val() + '&Route=' + $('#txtRouteID').val(), '', '');
                    });
                } else {
                    if ($('#txtCauseCode').val() == '2' || $('#txtCauseCode').val() == '3') {
                        $('#btnExpense2').removeAttr('disabled');
                    }
                }
            });
        }
    }
    function GenContainer() {
        ShowConfirm('Please confirm to generate container', (ans) => {
            if (ans == true) {
                let w ='?Branch='+ $('#txtBranchCode').val() + '&Code='+ $('#txtBookingNo').val() + '&Qty=' +$('#txtTotalContainer').val() + '&Size=' + $('#cboContainerSize').val() +'&Route=' + $('#txtMainRoute').val();
                $.get(path + 'JobOrder/CreateContainer' + w).done(function (r) {
                    if (r.result.data !== null) {
                        LoadDetail($('#txtBranchCode').val(), $('#txtBookingNo').val());
                    }
                    ShowMessage(r.result.msg);
                });
            }
        });
    }
    function UpdateJob() {
        ShowConfirm('Please confirm to update container total to job', (ans) => {
            if (ans == true) {
                $.get(path + 'JobOrder/UpdateContainerToJob?Branch=' + $('#txtBranchCode').val()+ '&Job=' + $('#txtJNo').val()).done(function (r) {
                    ShowMessage(r.result.msg);
                });
            }
        });
    }
    function PrintDelivery() {
        window.open(path + 'JobOrder/FormDelivery?Branch=' + $('#txtBranchCode').val() + '&Doc=' + $('#txtDeliveryNo').val(), '', '');
    }
    function OpenJob() {
        window.open(path + 'JobOrder/ShowJob?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(),'','');
    }
    function SavePlace(id) {
        let pname = $('#txtPlaceName' + id).val();
        let obj = {
            PlaceType: id,
            PlaceName: pname,
            PlaceAddress: $('#txtPlaceAddress' + id).val(),
            PlaceContact: $('#txtPlaceContact' + id).val()
        };
        let json = JSON.stringify({ data: obj });
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == true) {
                postData(path + 'Master/SetTransportPlace', json, function (r) {
                    loadLocation(path, '#cboPlaceName' + id, id);
                    ShowMessage(r.result.msg);
                });
            }
        });
    }
    function DeletePlace(id) {
        let pname = $('#txtPlaceName' + id).val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == true) {
                $.get(path + 'Master/DelTransportPlace?Type=' + id + '&Code=' + pname).done(function (r) {
                    loadLocation(path, '#cboPlaceName' + id, id);
                    ShowMessage(r.transportplace.result);
                });
            }
        });
    }
    function ChangeBooking() {
        if ($('#txtBookingNew').val() !== '') {
            $.get(path + 'JobOrder/ChangeBooking?From=' + $('#txtBookingNo').val() + '&To=' + $('#txtBookingNew').val()).done(function (r) {
                ShowMessage(r.result);
            });
        } else {
            ShowMessage('Please enter some data', true);
        }
    }
    function AddFuel() {
        window.open(path + 'JobOrder/AddFuel?Branch=' + row.BranchCode + '&Job='+ row.JNo +'&Booking=' + row.BookingNo + '&Item=' + row.ItemNo, '', '');
    }
    function ShowAddFuel() {
	console.log('ShowAddFuel');
        $('#tbAddFuel').DataTable().clear().draw();
        $.get(path + 'JobOrder/GetAddFuel?Branch=' + $('#txtBranchCode').val() + '&Job=' + $('#txtJNo').val() + '&Book=' + $('#txtBookingNo').val() + '&Item=' + $('#txtItemNo').val()).done((r) => {
            if (r.addfuel.data.length > 0) {
                let tb=$('#tbAddFuel').DataTable({
                    data: r.addfuel.data,
                    columns: [
                        { data: "DocNo", title: "No" },
                        {
                            data: "DocDate", title: "Date",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        },
                        {
                            data: "TotalAmount", title: "Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: null, title: "Status",
                            render: function (data) {
                                switch (true) {
                                    case data.CancelBy !== null:
                                        return 'Cancel';
                                    case data.ApproveBy !== null:
                                        return 'Approve';
                                    default:
                                        return 'Request';
                                }
                            }
                        }
                    ],
                    destroy: true
                    , pageLength: 100
                });
		let i = 0;
                $('#tbAddFuel tbody').on('dblclick', 'tr', function () {
			i++;
                    let row = $('#tbAddFuel').DataTable().row(this).data();
                    window.open(path + 'JobOrder/AddFuel?Branch=' + row.BranchCode + '&Code=' + row.DocNo, '', '');
                });
		console.log(i);
                ChangeLanguageGrid('@ViewBag.Module', '#tbAddFuel');
            }
        });
    }
</script>