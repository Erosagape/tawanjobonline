
@Code
    ViewBag.Title = "Transport & Loading Information"
End Code
<style>
    @@media only screen and (max-width: 600px) {
        #btnAdd,#btnDelete,#btnSave,#btnUpdateJob,
        #btnAddDetail,#btnDeleteDetail,#btnUpdateDetail {
            width: 100%;
        }
    }
</style>
<ul class="nav nav-tabs">
    <li class="active">
        <a data-toggle="tab" href="#tabLoading" id="linkTab1">Loading Information</a>
    </li>
    <li>
        <a data-toggle="tab" href="#tabContainer" id="linkTab2">Container Information</a>
    </li>
</ul>
<div class="tab-content">
    <div class="tab-pane fade in active" id="tabLoading">
        <div id="dvForm">
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
                    <label id="lblBookingNo">Booking No</label>                    
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtBookingNo" class="form-control" style="width:100%" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('booking');" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <label id="lblJNo">Job Number</label>                    
                    <br />
                    <div style="display:flex;flex-direction:row">
                        <input type="text" id="txtJNo" class="form-control" style="width:100%" />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('job');" />
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
                        <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('vender')">...</button>
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
                        <input type="text" id="txtPaymentCondition" class="form-control" />
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
                        <label id="lblCYDate">CY Closing/Pickup Date :</label>
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
                        <label id="lblPackingDate">Last Load/Packing Date:</label>
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
                        <label id="lblFactoryDate">Arrival/Delivery Date :</label>
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
            <div class="panel" style="background-color:lightgreen;padding:10px 10px 10px 10px;margin-top:10px">
                <div class="row">
                    <div class="col-sm-6">
                        <a href="../Master/TransportRoute"><label id="lblRoute">Transport Route</label></a>: <br />
                        <select id="cboLocation" class="form-control dropdown" onchange="LoadLocation()"></select>
                    </div>
                    <div class="col-sm-2">
                        <label id="lblActive">Active Trip:</label>
                        <br />
                        <input type="text" id="txtTotalTripA" class="form-control" disabled />
                    </div>
                    <div class="col-sm-2">
                        <label id="lblFinish">Finished Trip:</label>
                        <br />
                        <input type="text" id="txtTotalTripF" class="form-control" disabled />
                    </div>
                    <div class="col-sm-2">
                        <label id="lblNonActive">Non-active Trip:</label>
                        <br />
                        <input type="text" id="txtTotalTripC" class="form-control" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblPlace1">Place #1: </label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtCYPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <label id="lblAddress1">Address #1:</label>
                        <br />
                        <textarea id="txtCYAddress" class="form-control"></textarea>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblContact1">Contact #1:</label>
                        <br />
                        <input type="text" class="form-control" id="txtCYContact" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblPlace2">Place #2:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtPackingPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <label id="lblAddress2">Address #2:</label>
                        <br />
                        <textarea id="txtPackingAddress" class="form-control"></textarea>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblContact2">Contact #2:</label>
                        <br />
                        <input type="text" class="form-control" id="txtPackingContact" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblPlace3">Place #3:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtFactoryPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <label id="lblAddress3">Address #3:</label>
                        <br />
                        <textarea id="txtFactoryAddress" class="form-control"></textarea>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblContact3">Contact #3:</label>
                        <br />
                        <input type="text" class="form-control" id="txtFactoryContact" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblPlace4">Place #4:</label>
                        <br />
                        <div style="display:flex;flex-direction:row">
                            <input type="text" id="txtReturnPlace" class="form-control">
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <label id="lblAddress4">Address #4:</label>
                        <br />
                        <textarea id="txtReturnAddress" class="form-control"></textarea>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblContact4">Contact #4:</label>
                        <br />
                        <input type="text" class="form-control" id="txtReturnContact" />
                    </div>
                </div>
                <button id="btnSaveLoc" class="btn btn-primary" onclick="SaveLocation(true)" >Save Route Data</button>
                <button id="btnEditExp" class="btn btn-info" onclick="EditExpense()" >Edit Route Expense</button>
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
        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintBooking()">
            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Form</b>
        </a>
        <select id="cboPrintForm">
            <option value="BA">Booking Confirmation (AIR)</option>
            <option value="BS">Booking Confirmation (SEA)</option>
            <option value="SP">Shipping Particulars</option>
            <option value="BL">BL/AWB</option>
            <option value="DO">D/O Letter</option>
            <option value="SC">Sales Contract</option>
            <option value="IV">Commercial Invoice</option>
            <option value="PL">Packing Lists</option>
        </select>
        <a href="#" class="btn btn-primary" id="btnUpdateJob" onclick="UpdateJob()">
            <i class="fa fa-lg fa-check"></i>&nbsp;<b id="linkUpCon">Update Total Container To Job</b>
        </a>
    </div>
    <div class="tab-pane fade" id="tabContainer">
        <div class="row">
            <div class="col-sm-2">
                <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="AddDetail()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAddCon">Add Container</b>
                </a>
            </div>
            <div class="col-sm-4">
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
        <table id="tbDetail" class="table table-responsive">
            <thead>
                <tr>
                    <th class="desktop">No</th>
                    <th>CTN_NO</th>
                    <th class="desktop">CTN_SIZE</th>
                    <th class="desktop">SealNumber</th>
                    <th class="all">Qty</th>
                    <th class="desktop">Status</th>
                    <th class="desktop">G.W</th>
                    <th class="desktop">UnloadDate</th>
                    <th class="desktop">DeliveryNo</th>
                    <th class="desktop">V.Inv</th>
                    <th class="desktop">Clear</th>
                    <th class="desktop">Bal</th>
                </tr>
            </thead>
        </table>
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
                        <button class="btn btn-success" id="btnSaveExp" onclick="SaveExpense()" >Save Expenses</button>
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
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-sm-2">
                                <label id="lblNo">No :</label>
                                <br /><div style="display:flex"><input type="text" id="txtItemNo" class="form-control" disabled></div>
                            </div>
                            <div class="col-sm-4">
                                <label id="lblContainerNo">Container </label>
                                :<br /><div style="display:flex"><input type="text" id="txtCTN_NO" class="form-control"></div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblContainerSize">Size</label>
                                :<br /><div style="display:flex"><select id="txtCTN_SIZE" class="form-control dropdown"></select></div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblSealNo">Seal No.</label>
                                :<br /><div style="display:flex"><input type="text" id="txtSealNumber" class="form-control"></div>
                            </div>
                        </div>
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
                            <div class="col-sm-5">
                                <label id="lblDriver">Driver</label>
                                :<br /><div style="display:flex"><input type="text" id="txtDriver" class="form-control"></div>
                            </div>
                            <div class="col-sm-3">
                                <label id="lblTruckNo">Truck ID</label>
                                :<br /><div style="display:flex"><input type="text" id="txtTruckNO" class="form-control"></div>
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
                                <label id="lblRouteID">Route ID</label>
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
                                <label id="lblComment">Comment </label>
                                :<br /><div style="display:flex"><textarea id="txtComment" class="form-control"></textarea></div>
                            </div>
                            <div class="col-sm-6">
                                <label id="lblShippingMark">Shipping Mark</label>
                                :<br /><div style="display:flex"><textarea id="txtShippingMark" class="form-control"></textarea></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4" style="display:flex;flex-direction:column;background:gold;padding-bottom:1em">
                                <label id="lblPickup">Pick-up:</label>
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
                            <div class="col-sm-4" style="display:flex;flex-direction:column;background:salmon;padding-bottom:1em">
                                <label id="lblDelivery">Delivery:</label>
                                <div>
                                    <label id="lblDeliveryTarget">Target Date :</label>
                                    <br /><div style="display:flex"><input type="date" id="txtUnloadDate" class="form-control"></div>
                                </div>
                                <div>
                                    <label id="lblDeliveryTargetTime">Target Time :</label>
                                    <br /><div style="display:flex"><input type="text" id="txtUnloadTime" class="form-control"></div>
                                </div>
                                <div>
                                    <label id="lblDeliveryActual">Actual Date :</label>
                                    <br /><div style="display:flex"><input type="date" id="txtUnloadFinishDate" class="form-control"></div>
                                </div>
                                <div>
                                    <label id="lblDeliveryActualTime">Actual Time :</label>
                                    <br /><div style="display:flex"><input type="text" id="txtUnloadFinishTime" class="form-control"></div>
                                </div>
                            </div>
                            <div class="col-sm-4" style="display:flex;flex-direction:column;background:lightgreen;padding-bottom:1em">
                                <label id="lblReturn">Return:</label>
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
                    <div class="col-md-6">
                        <label id="lblDeliveryNo">Delivery No</label>
                        :
                        <div style="display:flex;">
                            <div style="display:flex"><input type="text" id="txtDeliveryNo" class="form-control" disabled></div>
                            <button id="btnGenDeliveryNo" onclick="GenerateDO()" class="btn btn-warning">Create</button>
                            <button id="btnPrintSlip" class="btn btn-info" onclick="PrintDelivery()">Delivery Slip</button>
                        </div>
                        <br />
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
                                    <th>PoNo</th>
                                    <th>RefNo</th>
                                    <th>TotalNet</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>

            </div>
            <div class="modal-footer">
                <div style="float:left">
                    <a href="#" class="btn btn-default w3-purple" id="btnAddDetail" onclick="ClearDetail()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNewCont">New Container</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnUpdateDetail" onclick="SaveDetail()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveCont">Save Container</b>
                    </a>
                    <a href="#" class="btn btn-danger" id="btnDeleteDetail" onclick="DeleteDetail()">
                        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelCont">Delete Container</b>
                    </a>
                </div>
                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
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
    let isjobmode = false;
    if (userGroup == 'V') {
        $('#btnBrowseCust').attr('disabled', 'disabled');
        $('#txtVenderCode').attr('disabled', 'disabled');
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
        $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
            if (r.company.data.length > 0) {
                let dr = r.company.data[0];
                cust = dr.CustCode;
                $('#txtNotifyCode').val(dr.CustCode);
                $('#txtNotifyName').val(dr.NameThai);
            }
        });
    }
    SetLOVs();
    SetEvents();
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
    }
    function loadRoute() {
        $.get(path + 'JobOrder/GetTransportRoute', function (r) {
            if (r.transportroute.data !== undefined) {
                let dr = r.transportroute.data;
                $('#cboLocation').empty();
                if (dr.length > 0) {
                    for (let i = 0; i < dr.length; i++) {
                        $('#cboLocation').append($('<option>', { value: dr[i].LocationID })
                            .text(dr[i].LocationRoute));
                    }
                }
            }
        });
    }
    function SetLOVs() {
        loadUnit('#txtCTN_SIZE', path, '?Type=1');
        loadUnit('#cboContainerSize', path, '?Type=1');
        loadRoute();
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv,'#frmSearchCust', '#tbCust','Customers',response,3);
            //Agent
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchServ1', '#tbServ1', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchServ2', '#tbServ2', 'Service Code', response, 2);
            CreateLOV(dv, '#frmSearchRoute', '#tbRoute', 'Transport Route', response, 2);
            //Units
            CreateLOV(dv, '#frmSearchUnitS', '#tbUnitS', 'Commodity Unit', response, 2);
            CreateLOV(dv, '#frmSearchUnitC', '#tbUnitC', 'Car Unit', response, 2);
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job', response, 3);
            //Booking
            CreateLOV(dv, '#frmSearchBook', '#tbBook', 'Booking', response, 4);
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
                    w += '&Agent=' + $('#txtVenderCode').val();
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
                SetGridTransport(path, '#tbBook', '#frmSearchBook', w, ReadBooking);
                break;
            case 'servicecode1':
                SetGridSICode(path, '#tbServ1', '', '#frmSearchServ1', ReadService1);
                break;
            case 'servicecode2':
                SetGridSICode(path, '#tbServ2', '', '#frmSearchServ2', ReadService2);
                break;
            case 'route':
                SetGridTransportRoute(path, '#tbRoute', '#frmSearchRoute', ReadRoute);
                break;
        }
    }
    function ReadRoute(dt) {
        $('#txtRouteID').val(dt.LocationID);
        $('#txtLocation').val(dt.LocationRoute);
        ShowExpense();
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
        ShowVender(path, dr.AgentCode, '#txtPaymentBy');
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtNotifyCode').val(dr.Consigneecode);
        ShowCompany(path, dr.Consigneecode, '#txtNotifyName');
        $('#txtContactName').val(dr.CustContactName);
        $('#txtPackingDate').val(CDateEN(dr.JobType==1? dr.ETADate : dr.ETDDate));
        $('#txtFactoryDate').val(CDateEN(dr.EstDeliverDate));
        $('#txtFactoryPlace').val(dr.DeliveryTo);
        $('#txtFactoryAddress').val(dr.DeliveryAddr);
        $('#txtProductDesc').val(dr.InvProduct);
        $('#txtProductQty').val('0.00');
        $('#txtProductUnit').val(dr.InvProductUnit);
        $('#txtGrossWeight').val(dr.TotalGW);
        $('#txtProductPrice').val(dr.InvTotal);
        $('#txtNetWeight').val(dr.TotalNW);
        $('#txtMeasurement').val(dr.Measurement);
        if (isjobmode == true) {
            LoadData();
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
        $('#txtPackingPlace').val(dr.PackingPlace);
        $('#txtCYPlace').val(dr.CYPlace);
        $('#txtFactoryPlace').val(dr.FactoryPlace);
        $('#txtReturnPlace').val(dr.ReturnPlace);
        $('#txtPackingAddress').val(dr.PackingAddress);
        $('#txtCYAddress').val(dr.CYAddress);
        $('#txtFactoryAddress').val(dr.FactoryAddress);
        $('#txtReturnAddress').val(dr.ReturnAddress);
        $('#txtPackingContact').val(dr.PackingContact);
        $('#txtCYContact').val(dr.CYContact);
        $('#txtFactoryContact').val(dr.FactoryContact);
        $('#txtReturnContact').val(dr.ReturnContact);
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
        $('#txtPaymentCondition').val(dr.PaymentCondition);
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
                { data: "ItemNo", title: "#"},
                { data: "CTN_NO", title: "Container No" },
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
                    data: null, title: "Unload Date",
                    render: function (data) {
                        return CDateEN(data.UnloadDate);
                    }
                },
                { data: "DeliveryNo", title: "Delivery No" },
                { data: "CountBill", title: "V.Bill" },
                { data: "CountClear", title: "S.Clear" },
                { data: "CountBalance", title: "Balance" }
            ],
            destroy: true,
            responsive:true
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
            PackingPlace:$('#txtPackingPlace').val(),
            CYPlace:$('#txtCYPlace').val(),
            FactoryPlace:$('#txtFactoryPlace').val(),
            ReturnPlace: $('#txtReturnPlace').val(),
            PackingAddress:$('#txtPackingAddress').val(),
            CYAddress:$('#txtCYAddress').val(),
            FactoryAddress:$('#txtFactoryAddress').val(),
            ReturnAddress: $('#txtReturnAddress').val(),
            PackingContact:$('#txtPackingContact').val(),
            CYContact:$('#txtCYContact').val(),
            FactoryContact:$('#txtFactoryContact').val(),
            ReturnContact:$('#txtReturnContact').val(),
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
        $('#txtPackingPlace').val('');
        $('#txtCYPlace').val('');
        $('#txtFactoryPlace').val('');
        $('#txtReturnPlace').val('');
        $('#txtPackingDate').val('');
        $('#txtCYDate').val('');
        $('#txtFactoryDate').val('');
        $('#txtReturnDate').val('');
        $('#txtPackingTime').val('00:00');
        $('#txtCYTime').val('00:00');
        $('#txtFactoryTime').val('00:00');
        $('#txtReturnTime').val('00:00');
        $('#txtPackingAddress').val('');
        $('#txtCYAddress').val('');
        $('#txtFactoryAddress').val('');
        $('#txtReturnAddress').val('');
        $('#txtPackingContact').val('');
        $('#txtCYContact').val('');
        $('#txtFactoryContact').val('');
        $('#txtReturnContact').val('');
        $('#txtNotifyCode').val('');
        $('#txtNotifyName').val('');
        $('#txtTransMode').val('CY-CY');
        $('#txtPaymentCondition').val('EXW');
        $('#txtPaymentBy').val('');
        $('#tbDetail').DataTable().clear().draw();
        $('#txtTotalTripA').val(0);
        $('#txtTotalTripF').val(0);
        $('#txtTotalTripC').val(0);
    }
    function PrintBooking() {
        switch ($('#cboPrintForm').val()) {
            case 'BA':
                window.open(path + 'JobOrder/FormBookingAir?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BS':
                window.open(path + 'JobOrder/FormBookingSea?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'SP':
                window.open(path + 'JobOrder/FormBooking?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BL':
                window.open(path + 'JobOrder/FormTransport?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'DO':
                window.open(path + 'JobOrder/FormLetter?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
                break;
            case 'SC':
                window.open(path + 'JobOrder/FormSalesContract?BranchCode=' + $('#txtBranchCode').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'IV':
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
        $('#txtLocation').val($('#cboLocation option:selected').text());
        $('#txtRouteID').val($('#cboLocation').val());
        $('#txtDeliveryNo').val('');
        $('#txtShippingMark').val('');
        $('#txtCTN_SIZE').val('');
        if (isjobmode == false) {
            $('#txtProductDesc').val('');
            $('#txtProductQty').val('0.00');
            $('#txtProductUnit').val('');
            $('#txtGrossWeight').val('0.00');
            $('#txtNetWeight').val('0.00');
            $('#txtMeasurement').val('0.00');
            $('#txtProductPrice').val('0.00');
        }
        ShowExpense();
        ShowPayment();
    }
    function SaveDetail() {
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
            NetWeight: CNum($('#txtNetWeight').val())
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
        ShowExpense();
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
                window.open(path + 'Acc/Expense?BranchCode=' + row.BranchCode + '&BookNo=' + row.BookingNo + '&Item=' + row.ItemNo + '&Job=' + $('#txtJNo').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cont=' + row.CTN_NO + '&Cust=' + $('#txtNotifyCode').val(), '', '');
            } else {
                ShowMessage('Current document status is not allow to do this',true);
            }
        }
    }
    function EntryExpenses2() {
        if ($('#txtCauseCode').val() == '2' || $('#txtCauseCode').val() == '3') {
            window.open(path + 'Acc/Expense?BranchCode=' + $('#txtBranchCode').val() + '&BookNo=' + $('#txtBookingNo').val() + '&Item=' + $('#txtItemNo').val() + '&Job=' + $('#txtJNo').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cont=' + $('#txtCTN_NO').val() + '&Cust=' + $('#txtNotifyCode').val(), '', '');
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
    function LoadLocation() {
        $.get(path + 'JobOrder/GetTransportRoute?ID=' + $('#cboLocation').val(), function (r) {
            if (r.transportroute.data !== undefined) {
                let dr = r.transportroute.data[0];

                $('#txtCYPlace').val(dr.Place1);
                $('#txtCYAddress').val(dr.Address1);
                $('#txtCYContact').val(dr.Contact1);

                $('#txtPackingPlace').val(dr.Place2);
                $('#txtPackingAddress').val(dr.Address2);
                $('#txtPackingContact').val(dr.Contact2);

                $('#txtFactoryPlace').val(dr.Place3);
                $('#txtFactoryAddress').val(dr.Address3);
                $('#txtFactoryContact').val(dr.Contact3);

                $('#txtReturnPlace').val(dr.Place4);
                $('#txtReturnAddress').val(dr.Address4);
                $('#txtReturnContact').val(dr.Contact4);
            }
        });
    }
    function GetRoute() {
        let w = '';
        if ($('#txtCYPlace').val() !== '') {
            w += (w == '' ? '': '->') + $('#txtCYPlace').val();
        }
        if ($('#txtPackingPlace').val() !== '') {
            w += (w == '' ? '': '->') + $('#txtPackingPlace').val();
        }
        if ($('#txtFactoryPlace').val() !== '') {
            w += (w == '' ? '': '->') + $('#txtFactoryPlace').val();
        }
        if ($('#txtReturnPlace').val() !== '') {
            w += (w == '' ? '' : '->') + $('#txtReturnPlace').val();
        }
        return w;
    }
    function SaveLocation(active = true) {
        if ($('#txtCYPlace').val() !== '') {
            let obj = {
                LocationID: $('#cboLocation').val(),
                Place1: $('#txtCYPlace').val(),
                Place2: $('#txtFactoryPlace').val(),
                Place3: $('#txtPackingPlace').val(),
                Place4: $('#txtReturnPlace').val(),
                Address1: $('#txtCYAddress').val(),
                Address2: $('#txtFactoryAddress').val(),
                Address3: $('#txtPackingAddress').val(),
                Address4: $('#txtReturnAddress').val(),
                Contact1: $('#txtCYContact').val(),
                Contact2: $('#txtFactoryContact').val(),
                Contact3: $('#txtPackingContact').val(),
                Contact4: $('#txtReturnContact').val(),
                LocationRoute: GetRoute(),
                IsActive: active
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
                        loadRoute();
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
                        loadRoute();
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
                    destroy:true
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
        if ($('#cboLocation').val() > 0) {
            $('#txtLocationID').val($('#cboLocation').val());
            $('#txtLocationRoute').val($('#cboLocation option:selected').text());
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
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbExpense');
            }
        });
    }
    function ShowPayment() {
        $('#tbPayment').DataTable().clear().draw();
        if ($('#txtCTN_NO').val() !== '') {
            $.get(path + 'Acc/GetPayment?VenCode=' + $('#txtVenderCode').val() + '&Ref=' + $('#txtCTN_NO').val() + '&Status=Y').done((r) => {
                if (r.payment.header.length > 0) {
                    let tb= $('#tbPayment').DataTable({
                        data: r.payment.header,
                        columns: [
                            { data: "DocNo", title: "Doc.No" },
                            { data: "DocDate", title: "Date" },
                            { data: "PoNo", title: "Inv.No" },
                            { data: "RefNo", title: "Cont.No" },
                            { data: "TotalNet", title: "Total" }
                        ],
                        destroy: true
                    });
                    ChangeLanguageGrid('@ViewBag.Module', '#tbPayment');
                    $('#tbPayment tbody').on('dblclick', 'tr', function () {
                        let row = $('#tbPayment').DataTable().row(this).data();
                        window.open(path + 'Acc/Expense?BranchCode=' + row.BranchCode + '&DocNo='+ row.DocNo +'&BookNo=' + $('#txtBookingNo').val() + '&Item=' + $('#txtItemNo').val() + '&Job=' + $('#txtJNo').val() + '&Vend=' + $('#txtVenderCode').val() + '&Cont=' + $('#txtCTN_NO').val() + '&Cust=' + $('#txtNotifyCode').val(), '', '');
                    });
                }
            });
        }
    }
    function GenContainer() {
        ShowConfirm('Please confirm to generate container', (ans) => {
            if (ans == true) {
                let w ='?Branch='+ $('#txtBranchCode').val() + '&Code='+ $('#txtBookingNo').val() + '&Qty=' +$('#txtTotalContainer').val() + '&Size=' + $('#cboContainerSize').val();
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
        window.open(path + 'JobOrder/FormDelivery?Branch=' + $('#txtBranchCode').val() + '&Doc=' + $('#txtDeliverNo').val(), '', '');
    }

</script>