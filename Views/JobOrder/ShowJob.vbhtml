@Code
    ViewBag.Title = "Job Order"
End Code
<style>
    @@media only screen and (max-width: 600px) {
        #btnLinkAdv, #btnLinkClr, #btnLinkCost, #btnLinkDoc, #btnLinkExp, #btnLinkLoad, #btnLinkTAdv,
        #btnLinkCAdv, #btnCloseJob, #btnCancelJob, #btnViewChq, #btnViewTAdv {
            width: 100% !important;
        }

        #myTabs {
            display: none;
        }

        #mySelects {
            width: 100%;
            display: block !important;
        }
    }
</style>
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <div style="display:flex;flex-direction:row">
                    <label id="lblBranchCode">Branch Code:</label>
                    <input type="text" class="form-control" style="width:50px" id="txtBranchCode" disabled />
                    <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
                </div>
            </div>
            <div class="col-sm-3">
                <div style="display:flex;flex-direction:row">
                    <label id="lblJNo">Job Number:</label>
                    <input type="text" class="form-control" style="width:100%;background-color:yellow;color:red;font-weight:bold" id="txtJNo" disabled />
                    <input type="text" class="form-control" style="width:50px" id="txtRevised" disabled />
                </div>
            </div>
            <div class="col-sm-3">
                <div style="display:flex;flex-direction:row">
                    <label id="lblDocDate">Open Date:</label>
                    <input type="date" class="form-control" id="txtDocDate" />
                </div>
            </div>
            <div class="col-sm-3">
                <div style="display:flex;flex-direction:row">
                    <label id="lblJobStatus">Job Status:</label>
                    <input type="text" class="form-control" style="width:100%;background-color:aquamarine;font-weight:bold" id="txtJobStatus" disabled />
                </div>
            </div>
        </div>
        <p>
            <div class="row">
                <div class="col-sm-8">
                    <ul id="myTabs" class="nav nav-tabs">
                        <li id="tab1" class="active"><a data-toggle="tab" id="linkTab1" href="#tabinfo">Customers Data</a></li>
                        <li id="tab2"><a data-toggle="tab" href="#tabinv" id="linkTab2">Invoice Data</a></li>
                        <li id="tab3"><a data-toggle="tab" href="#tabdeclare" id="linkTab3">Customs Data</a></li>
                        <li id="tab4"><a data-toggle="tab" href="#tabtracking" id="linkTab4">Operation Data</a></li>
                        <li id="tab5"><a data-toggle="tab" href="#tabremark" id="linkTab5">Other Controls</a></li>
                    </ul>
                    <select id="mySelects" class="form-control" style="display:none" onchange="ChangeTab(this.value);">
                        <option id="optTab1" value="#tabinfo" selected>Customers Data</option>
                        <option id="optTab2" value="#tabinv">Invoices Data</option>
                        <option id="optTab3" value="#tabdeclare">Customs Data</option>
                        <option id="optTab4" value="#tabtracking">Operation Data</option>
                        <option id="optTab5" value="#tabremark">Others Controls</option>
                    </select>
                </div>
                <div class="col-sm-4">
                    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
                    </a>
                    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print</b>
                    </a>
                </div>
            </div>
            <div class="tab-content">
                <div id="tabinfo" class="tab-pane fade in active">
                    <div class="row">
                        <div class="col-sm-8">
                            <div style="display:flex;flex-direction:column">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblJobType" for="txtJobType">Job Type : </label>
                                        <input type="text" id="txtJobType" class="form-control" style="width:100%" disabled />
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblShipBy" for="txtShipBy">Ship By : </label>
                                        <input type="text" id="txtShipBy" class="form-control" style="width:100%" disabled />
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblCSName" for="txtCSName">Support By :</label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtCSName" class="form-control" style="width:100%" disabled />
                                            <input type="button" id="btnBrowseCS" class="btn btn-default" value="..." onclick="SearchData('cs')" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <a href="../Master/Customers" target="_blank">
                                            <label id="lblCustCode">IM-EX PORTER :</label>
                                        </a>
                                    </div>
                                    <div class="col-sm-8">
                                        <input type="checkbox" id="chkTSRequest" />
                                        <label id="lblUseLocalTrans" for="chkTSRequest">Use Local Transport</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtCustCode" class="form-control" style="width:100%" tabindex="0" />
                                            <input type="text" id="txtCustBranch" class="form-control" style="width:60px" tabindex="1" />
                                            <input type="button" id="btnBrowseCust" class="btn btn-default" value="..." onclick="SearchData('CUSTOMER')" />
                                        </div>
                                    </div>
                                    <div class="col-sm-8">
                                        <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                                <label id="lblTAddress" for="txtTAddress">Address   :</label>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <textarea id="txtTAddress" class="form-control" style="width:100%" disabled></textarea>
                                    </div>
                                    <div class="col-sm-6">
                                        <textarea id="txtEAddress" class="form-control" style="width:100%" disabled></textarea>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblPhoneFax" for="txtPhoneFax">Contact Info :</label>
                                        <input type="text" id="txtPhoneFax" class="form-control" style="width:100%" tabindex="2" />
                                    </div>
                                </div>
                                <a href="../Master/Customers?mode=CONSIGNEE" target="_blank">
                                    <label id="lblConsignee">BILLING TO :</label>
                                </a>
                                <div class="row">
                                    <div class="col-sm-4" style="display:flex;flex-direction:row;">
                                        <input type="text" id="txtConsignee" class="form-control" style="width:100%" tabindex="3" />
                                        <input type="text" id="txtConsBranch" class="form-control" style="width:60px" tabindex="4" />
                                        <input type="button" id="btnBrowseCons" class="btn btn-default" value="..." onclick="SearchData('CONSIGNEE')" />
                                    </div>
                                    <div class="col-sm-8">
                                        <input type="text" id="txtConsignName" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                                <label id="lblBillAddress" for="txtBillTAddress">Address   :</label>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <textarea id="txtBillTAddress" class="form-control" style="width:100%" disabled></textarea>
                                    </div>
                                    <div class="col-sm-6">
                                        <textarea id="txtBillEAddress" class="form-control" style="width:100%" disabled></textarea>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblContactName" for="txtContactName">Contact Person :</label>
                                        <input type="text" id="txtContactName" class="form-control" style="width:100%" tabindex="5" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblDescription" for="txtDescription">Descriptions : </label>
                                        <textarea id="txtDescription" class="form-control" style="width:100%" tabindex="6"></textarea>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div style="display:flex;flex-direction:column">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblJobCondition" for="txtJobCondition">Work Condition :</label>
                                        <input type="text" id="txtJobCondition" class="form-control" style="width:100%" tabindex="7" />
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblCustPoNo" for="txtCustPoNo">Customer PO :</label>
                                        <input type="text" id="txtCustPoNo" class="form-control" style="width:100%" tabindex="8" />
                                        <input type="button" id="btnLinkJob" value="Load From Job Shipping" class="btn btn-primary" onclick="SearchData('job')" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblQNo" for="txtQNo">Quotation : </label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" class="form-control" id="txtQNo" style="width:100%" tabindex="9" />
                                            <input type="text" class="form-control" id="txtQRevise" style="width:60px" tabindex="10" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblManagerName" for="txtManagerName">Sales By :</label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" class="form-control" id="txtManagerName" style="width:100%" disabled />
                                            <input type="button" class="btn btn-default" id="btnBrowseSales" value="..." onclick="SearchData('sales')" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblConfirmDate" for="txtConfirmDate" style="color:red">Confirm Date :</label>
                                        <br />
                                        <input type="date" id="txtConfirmDate" class="form-control" style="width:100%" tabindex="11" />
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblCommission" for="txtCommission">Commission :</label>
                                        <br />
                                        <input type="text" id="txtCommission" class="form-control" style="width:100%" tabindex="12" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCloseBy" for="txtCloseBy">Close By :</label>
                                        <br />
                                        <input type="text" id="txtCloseBy" class="form-control" style="width:100%" disabled />
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblCloseDate" for="txtCloseDate">Close Date : </label>
                                        <br />
                                        <input type="date" id="txtCloseDate" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                                <button id="btnCloseJob" class="btn btn-warning" onclick="CloseJob()" style="width:130px">Close Job</button>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCancelBy" for="txtCancelBy">Cancel By :</label>
                                        <input type="text" id="txtCancelBy" class="form-control" style="width:100%" disabled />
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblCancelDate" for="txtCancelDate">Cancel Date :</label>
                                        <input type="date" id="txtCancelDate" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblCancelReason" for="txtCancelReason">Cancel Note : </label>
                                        <br />
                                        <textarea id="txtCancelReason" class="form-control" style="width:100%"></textarea>
                                    </div>
                                </div>
                                <button id="btnCancelJob" class="btn btn-danger" onclick="CancelJob()" style="width:130px">Cancel Job</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabinv" class="tab-pane fade">
                    <div class="row">
                        <div class="col-sm-5">
                            <div style="display:flex;flex-direction:column">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblCustInvNo" for="txtCustInvNo" style="color:red">Cust.Invoice No :</label>
                                    </div>
                                    <div class="col-sm-8">
                                        <input type="text" id="txtCustInvNo" class="form-control" style="width:100%" tabindex="13" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblInvProduct" for="txtInvProduct">Products :</label>
                                    </div>
                                    <div class="col-sm-8" style="display:flex;">
                                        <input type="text" class="form-control" id="txtInvProduct" style="width:100%" tabindex="14" />
                                        <input type="button" id="btnBrowseProd" class="btn btn-default" value="..." onclick="SearchData('InvProduct')" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblInvTotal" for="txtInvTotal">Inv.Total :</label>
                                    </div>
                                    <div class="col-sm-8">
                                        <input type="text" id="txtInvTotal" class="form-control" style="width:100%" tabindex="15" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <a href="../Master/Currency" target="_blank">
                                            <label id="lblInvCurrency">Currency :</label>
                                        </a>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" class="form-control" id="txtInvCurrency" style="width:100%" tabindex="16" />
                                            <input type="button" class="btn btn-default" id="btnBrowseRate" value="..." onclick="SearchData('CURRENCY')" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblExchangeRate" for="txtInvCurRate">Exchange Rate :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtInvCurRate" class="form-control" style="width:100%" tabindex="17" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblBookingNo" for="txtBookingNo" style="color:red">Booking No :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtBookingNo" class="form-control" style="width:100%" tabindex="18" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblBLNo" for="txtBLNo">BL/AWB Status :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtBLNo" class="form-control" style="width:100%" tabindex="19" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblHAWB" for="txtHAWB">House BL/AWB :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtHAWB" class="form-control" style="width:100%" tabindex="20" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblMAWB" for="txtMAWB">Master BL/AWB :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtMAWB" class="form-control" style="width:100%" tabindex="21" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblTotalCTN" for="txtTotalCTN">Total Containers :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtTotalCTN" class="form-control" style="width:100%" tabindex="22" />
                                            <input type="button" id="btnGetCTN" class="btn btn-default" value="..." onclick="SplitData()" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblMeasurement" for="txtMeasurement">Meas.(CBM) :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtMeasurement" class="form-control" style="width:100%" tabindex="23" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblDeliverNo" for="txtDeliverNo">Delivery No :</label>
                                    </div>
                                    <div class="col-sm-8">
                                        <input type="text" id="txtDeliverNo" class="form-control" style="width:100%" tabindex="24" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <a href="../Master/Customers?mode=NOTIFY_PARTY" target="_blank">
                                            <label id="lblDeliverTo">Consignee SI :</label>
                                        </a>
                                    </div>
                                    <div class="col-sm-8" style="display:flex;flex-direction:row">
                                        <input type="text" id="txtDeliverTo" class="form-control" style="width:100%" tabindex="25" />
                                        <input type="button" id="btnBrowseCust3" class="btn btn-default" value="..." onclick="SearchData('NOTIFY')" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label id="lblDeliverAddr" for="txtDeliverAddr">Delivery Address :</label>
                                        <br />
                                        <textarea id="txtDeliverAddr" class="form-control" style="width:100%" tabindex="26"></textarea>
                                    </div>
                                </div>
                                <button id="btnDelivery" class="btn btn-info" onclick="PrintDelivery()">Delivery Slip</button>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div style="display:flex;flex-direction:column">
                                <div class="row">
                                    <div class="col-sm-8">
                                        <label id="lblProjectName" for="txtProjectName">Project Name :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <textarea id="txtProjectName" class="form-control" style="width:100%" tabindex="27"></textarea>
                                            <input type="button" class="btn btn-default" id="btnBrowseProj" value="..." onclick="SearchData('ProjectName')" />
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <label id="lblInvPackQty" for="txtInvPackQty">Package.Total :</label>
                                        <br />
                                        <input type="text" id="txtInvPackQty" class="form-control" style="width:100%" tabindex="28" />
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label id="lblInvQty" for="txtInvQty">Qty :</label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" class="form-control" id="txtInvQty" style="width:100%" tabindex="29" />
                                            <input type="text" class="form-control" id="txtInvUnit" style="width:60px" tabindex="30" />
                                            <input type="button" class="btn btn-default" id="btnBrowseUnit" value="..." onclick="SearchData('invproductunit')" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <label id="lblNetWeight" for="txtNetWeight">Net Weight :</label>
                                        <br />
                                        <input type="text" id="txtNetWeight" class="form-control" style="width:100%" tabindex="31" />
                                    </div>
                                    <div class="col-sm-5">
                                        <label id="lblGrossWeight" for="txtGrossWeight">Gross Weight :</label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" class="form-control" id="txtGrossWeight" style="width:100%" tabindex="32" />
                                            <input type="text" class="form-control" id="txtWeightUnit" style="width:60px" tabindex="33" />
                                            <input type="button" class="btn btn-default" id="btnBrowseMeas" value="..." onclick="SearchData('GWUnit')" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblInvFCountry" for="txtInvFCountry">From Country :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="hidden" id="txtInvFCountryCode" />
                                            <input type="text" id="txtInvFCountry" class="form-control" style="width:100%" disabled />
                                            <input type="button" id="btnBrowseFCountry" class="btn btn-default" value="..." onclick="SearchData('fcountry')" tabindex="34" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblInvCountry" for="txtInvCountry">To :</label>
                                        <br />
                                        <div style="display:flex;flex-direction:row">
                                            <input type="hidden" id="txtInvCountryCode" />
                                            <input type="text" id="txtInvCountry" class="form-control" style="width:100%" disabled />
                                            <input type="button" id="btnBrowseCountry" class="btn btn-default" value="..." onclick="SearchData('country')" tabindex="35" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <a href="../Master/InterPort" target="_blank">
                                            <label id="lblInvInterPort">Inter Port:</label>
                                        </a>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtInterPort" class="form-control" style="width:130px" tabindex="36" />
                                            <input type="button" id="btnBrowseIPort" class="btn btn-default" value="..." onclick="SearchData('interport')" />
                                            <input type="text" id="txtInterPortName" class="form-control" style="width:100%" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <a href="../Master/Venders" target="_blank"><label style="color:red" id="lblForwarder">Agent:</label></a>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtForwarder" class="form-control" style="width:130px" tabindex="37" />
                                            <input type="button" id="btnBrowseFwdr" class="btn btn-default" value="..." onclick="SearchData('forwarder')" />
                                            <input type="text" id="txtForwarderName" class="form-control" style="width:100%" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblVesselName" for="txtVesselName">Vessel Name :</label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtVesselName" class="form-control" style="width:100%" tabindex="38" />
                                            <input type="button" id="btnBrowseVsl1" class="btn btn-default" value="..." onclick="SearchData('vessel')" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <label id="lblMVesselName" for="txtMVesselName">Master Vessel Name :</label>
                                        <div style="display:flex;flex-direction:row">
                                            <input type="text" id="txtMVesselName" class="form-control" style="width:100%" tabindex="39" />
                                            <input type="button" id="btnBrowseVsl2" class="btn btn-default" value="..." onclick="SearchData('mvessel')" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <a href="../Master/Venders" target="_blank"><label style="color:red" id="lblTransporter">Transporter:</label></a>
                                        <div style="display:flex;flex-direction:row">

                                            <input type="text" id="txtTransporter" class="form-control" style="width:130px" tabindex="40" />
                                            <input type="button" id="btnBrowseTrans" class="btn btn-default" value="..." onclick="SearchData('agent')" />
                                            <input type="text" id="txtTransporterName" class="form-control" style="width:100%" disabled />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <label id="lblETDDate" for="txtETDDate" style="color:red">ETD Date:</label><input type="date" style="width:100%" class="form-control" id="txtETDDate" tabindex="41" />
                                    </div>
                                    <div class="col-sm-3">
                                        <label id="lblETADate" for="txtETADate" style="color:red">ETA Date:</label><input type="date" style="width:100%" class="form-control" id="txtETADate" tabindex="42" />
                                    </div>
                                    <div class="col-sm-3">
                                        <label id="lblLoadDate" for="txtLoadDate" style="color:red">Load Date:</label><input type="date" style="width:100%" class="form-control" id="txtLoadDate" tabindex="43" />
                                    </div>
                                    <div class="col-sm-3">
                                        <label id="lblDeliveryDate" for="txtDeliveryDate" style="color:red">Unload Date :</label><input type="date" style="width:100%" class="form-control" id="txtDeliveryDate" tabindex="44" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabdeclare" class="tab-pane fade">
                    <div class="row">
                        <div class="col-sm-3">
                            <label id="lblEDIDate" for="txtEDIDate">EDI Date :</label>
                            <input type="date" id="txtEDIDate" class="form-control" style="width:100%" tabindex="45" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblReadyClearDate" for="txtReadyClearDate">Ready Clear :</label>
                            <input type="date" id="txtReadyClearDate" class="form-control" style="width:100%" tabindex="46" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDutyDate" for="txtDutyDate" style="color:red">Inspection Date :</label>
                            <input type="date" id="txtDutyDate" class="form-control" style="width:100%" tabindex="47" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblClearDate" for="txtClearDate">Clear Date :</label>
                            <input type="date" id="txtClearDate" class="form-control" style="width:100%" tabindex="48" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <a href="../Master/DeclareType" target="_blank">
                                <label id="lblDeclareType">Declare Type :</label>
                            </a>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <input type="text" id="txtDeclareType" class="form-control" style="width:130px" tabindex="49" />
                                <input type="button" id="btnBrowseDCType" class="btn btn-default" value="..." onclick="SearchData('RFDCT')" />
                                <input type="text" id="txtDeclareTypeName" class="form-control" style="width:100%" disabled />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDeclareNo" for="txtDeclareNo" style="color:red">Declare No :</label>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <input type="text" id="txtDeclareNo" class="form-control" style="width:100%" tabindex="50" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDutyAmt" for="txtDutyAmt">Duty Amt :</label>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <input type="text" id="txtDutyAmt" class="form-control" style="width:100%" tabindex="51" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <input type="checkbox" id="chkTyAuthorSp" />
                            <label id="lblTyAuthorSp" for="chkTyAuthorSp">Special Privilege</label>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <select id="cboTyAuthorSp" class="form-control dropdown"></select>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <input type="checkbox" id="chkTy19BIS" />
                            <label id="lblTy19BIS" for="chkTy19BIS">19 BIS Rule</label>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <select id="cboTy19BIS" class="form-control dropdown"></select>
                            </div>

                        </div>
                        <div class="col-sm-4">
                            <input type="checkbox" id="chkTyClearTax" />
                            <label id="lblTyClearTax" for="chkTyClearTax">Duty Rule</label>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <select id="cboTyClearTax" class="form-control dropdown"></select>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label id="lblClearTaxReson" for="txtClearTaxReson">Certificates# </label>
                                    <input type="text" id="txtClearTaxReson" class="form-control" style="width:100%" tabindex="52" />
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblDeclareStatus" for="optDeclareStatus">Declaration Status :</label>
                                    <br />
                                    <label class="radio-inline"><input type="radio" name="optDeclareStatus" value="G"><label style="color:green;font:bold" id="lblGreen">Green</label></label>
                                    <label class="radio-inline"><input type="radio" name="optDeclareStatus" value="R"><label style="color:red;font:bold" id="lblRed">Red</label></label>
                                    <label class="radio-inline"><input type="radio" name="optDeclareStatus" value="M"><label style="color:blue;font:bold" id="lblManual">Manual</label></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="row">
                                <div class="col-sm-6">
                                    <a href="../Master/CustomsPort" target="_blank">
                                        <label id="lblReleasePort" style="color:red">Release Port :</label>
                                    </a>
                                    <br />
                                    <div style="display:flex;flex-direction:row">
                                        <input type="text" id="txtReleasePort" class="form-control" style="width:60px" tabindex="53" />
                                        <input type="button" id="btnBrowseLCPort" class="btn btn-default" value="..." onclick="SearchData('RFARS')" />
                                        <input type="text" id="txtReleasePortName" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <label id="lblPortNo" for="txtPortNo">Discharge Port#</label>
                                    <br />
                                    <input type="text" id="txtPortNo" class="form-control" style="width:100%" tabindex="54" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <label id="lblShippingCmd" for="txtShippingCmd">Shipping Note :</label>
                            <br />
                            <textarea id="txtShippingCmd" class="form-control" style="width:100%" tabindex="56"></textarea>
                        </div>

                        <div class="col-sm-7">
                            <label id="lblShipping" for="txtShipping">Shipping Staff :</label>
                            <br />
                            <div style="display:flex;flex-direction:row">
                                <input type="text" id="txtShipping" class="form-control" style="width:130px" tabindex="55" />
                                <input type="button" id="btnBrowseShipping" class="btn btn-default" value="..." onclick="SearchData('user')" />
                                <input type="text" id="txtShippingName" style="width:100%" class="form-control" disabled />
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-10" style="display:flex;flex-direction:row">
                                    <button id="btnLinkPaperless" class="btn btn-success" onclick="LoadPaperless()">Load Data From Paperless</button>
                                    <select id="cboDBType" class="form-control dropdown">
                                        <option value="JANDT" selected>TAWAN</option>
                                        <option value="ECS">ECS</option>
					<option value="ETRANSIT">ETRANSIT(ทดสอบระบบ)</option>
                                    </select>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div id="tabtracking" class="tab-pane fade">
                    <a href="#" class="btn btn-primary" id="btnPrintClr" onclick="PrintForm()">
                        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrintClr">Print Form Clear</b>
                    </a>
                    <br />
                    Filter :
                    <select id="cboDocType" class="dropdown" onclick="ShowTracking($('#txtBranchCode').val(), $('#txtJNo').val());">
                        <option value="">All</option>
                        <option value="ADV">Advance</option>
                        <option value="CLR">Clearing</option>
                        <option value="CHQ">Cheque</option>
                        <option value="INV">Invoice</option>
                        <option value="RCV">Cash Receipts</option>
                        <option value="TAX">Tax Receipts</option>
                    </select>
                    <input type="checkbox" id="chkCancel" onchange="ShowTracking($('#txtBranchCode').val(), $('#txtJNo').val());">Show Cancelled Document
                    <table id="tbTracking" class="table table-responsive">
                        <thead>
                            <tr>
                                <th class="desktop">
                                    Date
                                </th>
                                <th class="desktop">
                                    Type
                                </th>
                                <th class="all">
                                    Container
                                </th>
                                <th class="all">
                                    Document No
                                </th>
                                <th class="desktop">
                                    Item
                                </th>
                                <th class="desktop">
                                    Expenses
                                </th>
                                <th class="all">
                                    Amount
                                </th>
                                <th class="desktop">
                                    Status
                                </th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
                <div id="tabremark" class="tab-pane fade">
                    <a href="#" class="btn btn-default w3-purple" id="btnAddLog" onclick="AddJobLog()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAddLog">Add Remark</b>
                    </a>
                    <div class="row">
                        <div class="col-sm-12">
                            <table id="tbLog" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th class="desktop">
                                            Date
                                        </th>
                                        <th class="all">
                                            Action
                                        </th>
                                        <th class="desktop">
                                            User
                                        </th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <button class="btn btn-default" id="btnLinkDoc" onclick="OpenDocument()">Document Files</button>
                            <button class="btn btn-default" id="btnLinkLoad" onclick="OpenTransport()">Transport Info</button>
                            <button class="btn btn-default" id="btnLinkExp" onclick="OpenExpense()">Estimate Expenses</button>
                            <button class="btn btn-default" id="btnLinkCAdv" onclick="OpenCreditAdv()">Credit Advance</button>
                            <button class="btn btn-default" id="btnViewChq" onclick="OpenCheque()">Customer Cheque</button>
                            <button class="btn btn-warning" id="btnLinkAdv" onclick="OpenAdvance()">Advance Request</button>
                            <button class="btn btn-success" id="btnLinkClr" onclick="OpenClearing()">Advance Clearing</button>
                            <button class="btn btn-danger" id="btnLinkCost" onclick="OpenCosting()">Cost & Profit</button>
                        </div>
                    </div>
                    <label>Advances Expenses Information :</label>
                    <div class="row">
                        <div class="col-sm-6">
                            <div style="display:flex;flex-direction:column">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblComPaidBy" style="font:bold">Company Paid By : </label>
                                        <br />
                                        <label id="lblComChq">Cheque:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <br />
                                        <input type="text" id="txtComPaidChq" class="form-control" style="width:100%" onchange="CalTotalLtd();" tabindex="57" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblComCash">Cash:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtComPaidCash" class="form-control" style="width:100%" onchange="CalTotalLtd();" tabindex="58" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblComEPay">E-Payment:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtComPaidEPay" class="form-control" style="width:100%" onchange="CalTotalLtd();" tabindex="59" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblComOther">Others:</label>
                                        <input type="text" id="txtComOthersPayBy" class="form-control" style="width:100%" tabindex="58" />
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtComPaidOthers" class="form-control" style="width:100%" onchange="CalTotalLtd();" tabindex="60" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblComTotal">Total Paid:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtComPaidTotal" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div style="display:flex;flex-direction:column">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustPaidBy" style="font:bold">Customer Paid By : </label>
                                        <br />
                                        <label id="lblCustChq">Cheque:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <br />
                                        <input type="text" id="txtCustPaidChq" class="form-control" style="width:100%" onchange="CalTotalCust();" tabindex="61" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustCash">Cash:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtCustPaidCash" class="form-control" style="width:100%" onchange="CalTotalCust();" tabindex="62" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustTaxCard">Tax-Card:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtCustPaidCard" class="form-control" style="width:100%" onchange="CalTotalCust();" tabindex="63" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustEPay">E-Payment:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtCustPaidEPay" class="form-control" style="width:100%" onchange="CalTotalCust();" tabindex="64" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustBankGuarantee">Bank Guarantee:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtCustPaidBank" class="form-control" style="width:100%" onchange="CalTotalCust();" tabindex="65" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustOther">Others:</label>
                                        <input type="text" id="txtCustOthersPayBy" class="form-control" style="width:100%" tabindex="65" />
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtCustPaidOthers" class="form-control" style="width:100%" onchange="CalTotalCust();" tabindex="66" /><br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label id="lblCustTotal">Total Paid:</label>
                                    </div>
                                    <div class="col-sm-6">
                                        <input type="text" id="txtCustPaidTotal" class="form-control" style="width:100%" disabled />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </p>
        <div id="frmJobOrderLog" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <textarea id="txtLogRemark" class="form-control"></textarea>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" id="btnSaveLog" onclick="SaveJobLog()">Save Remark</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmContainerEdit" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"></button>
                        <h4 class="modal-title"><label id="lblHeaderC">Services Summary</label></h4>
                    </div>
                    <div class="modal-body">
                        <label id="lblQtyAdd">Qty : </label>
                        <input type="text" id="txtQtyAdd" />
                        <label id="lblUnitAdd">Unit : </label>
                        <input type="text" id="txtUnitAdd" disabled />
                        <button id="btnBrowseSUnt" onclick="SearchData('SERVUNIT')">...</button>
                        <button class="btn btn-primary" id="btnAddCons" onclick="AddService()">Add Service</button>
                        <div id="frmSearchSUnt">
                            <table id="tbSUnt" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>
                                        <th>Code</th>
                                        <th>Name</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div id="dvSplit"></div>
                    </div>
                    <div class="modal-footer">
                        <label id="lblTotalC">Total Container</label>
                        : <input type="text" id="txtTotalCon" disabled />
                        <button class="btn btn-success" id="btnSaveCons" onclick="ApplyService()">Update Value</button>
                        <button class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="frmLOVs"></div>
    </div>
</div>
<script type="text/javascript">
    //define letiables
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userGroup = '@ViewBag.UserGroup';
    const userRights = '@ViewBag.UserRights';
    const userPosition = '@ViewBag.UserPosition';
    const license = '@ViewBag.LICENSE_NAME';
    let rec = {};
    SetLOVs();
    SetEvents();
    //check parameters
    let br = getQueryString('BranchCode');
    let jno = getQueryString('JNo');
    if (br != "" && jno != "") {
        $('#txtBranchCode').val(br);
        ShowBranch(path, br, '#txtBranchName');
        ShowJob(br, jno);
    }
    SetEnterToTab();
    if (userPosition == '4' || userPosition == '5') {
        $('#tab4').hide();
        $('#btnLinkCost').hide();
    } else {
        if (userGroup == 'C') {
            $('#tab4').hide();
            $('#btnLinkExp').hide();
            $('#btnLinkAdv').hide();
            $('#btnLinkTAdv').hide();
            $('#btnLinkClr').hide();
            $('#btnLinkCost').hide();
        }
    }
    if (userRights.indexOf('E') < 0) $('#btnSave').attr('disabled', 'disabled');
    if (userRights.indexOf('P') < 0) $('#btnPrint').attr('disabled', 'disabled');

    //});
    function ChangeTab(id) {
        $('#myTabs a[href="' + id + '"]').tab('show');
    }
    function SetEnterToTab() {
        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    if (this.id !== 'txtDescription') {
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
                        $('[tabindex="1"]').focus();
                    } else {
                        //e.preventDefault();
                        return;
                    }
                }
            });
        });
        $('#txtCustCode').focus();
    }
    function SetEvents() {
        $('#txtTransporter').keydown(function (event) {
            if (event.which == 13) {
                ShowVender(path, $('#txtTransporter').val(), '#txtTransporterName');
            }
        });
        $('#txtForwarder').keydown(function (event) {
            if (event.which == 13) {
                ShowVender(path, $('#txtForwarder').val(), '#txtForwarderName');
            }
        });
        $('#txtShipping').keydown(function (event) {
            if (event.which == 13) {
                ShowUser(path, $('#txtShipping').val(), '#txtShippingName');
            }
        });
        $('#txtCustBranch').keydown(function (event) {
            if (event.which == 13) {
                ShowCustomerFull(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName', '#txtTAddress', '#txtEAddress', '#txtPhoneFax');
            }
        });
        $('#txtConsBranch').keydown(function (event) {
            if (event.which == 13) {
                ShowCustomerFull(path, $('#txtConsignee').val(), $('#txtConsBranch').val(), '#txtConsignName', '#txtBillTAddress', '#txtBillEAddress', '');
            }
        });
        $('#txtReleasePort').keydown(function (event) {
            if (event.which == 13) {
                ShowReleasePort(path, $('#txtReleasePort').val(), '#txtReleasePortName');
            }
        });
        $('#txtInterPort').keydown(function (event) {
            if (event.which == 13) {
                ShowInterPort(path, $('#txtJobType').val() == 'IMPORT' ? $('#txtInvFCountryCode').val() : $('#txtInvCountryCode').val(), $('#txtInterPort').val(), '#txtInterPortName');
            }
        });
        $('#txtDeclareType').keydown(function (event) {
            if (event.which == 13) {
                ShowDeclareType(path,$('#txtDeclareType').val(), '#txtDeclareTypeName');
            }
        });
        $('#frmContainerEdit').on('shown.bs.modal', function () {
            $('#txtQtyAdd').focus();
        });
    }
    function SetLOVs() {
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("frmLOVs");
            //Jobs
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job Shipping', response, 4);
            //Customers
            CreateLOV(dv,'#frmSearchCust', '#tbCust','Customers',response,3);
            //Consignee
            CreateLOV(dv, '#frmSearchCons', '#tbCons', 'Consignees', response, 3);
            //Notify
            CreateLOV(dv, '#frmSearchNotify', '#tbNotify', 'Notify Party', response, 3);
            //Inter Port
            CreateLOV(dv,'#frmSearchIPort', '#tbIPort','International Port',response,3);

            //2 Fields
            //Users
            CreateLOV(dv, '#frmSearchUser1', '#tbUser1', 'Users', response, 2);
            CreateLOV(dv, '#frmSearchUser2', '#tbUser2', 'Users', response, 2);
            CreateLOV(dv,'#frmSearchUser3', '#tbUser3','Users',response,2);
            //Declare Type
            CreateLOV(dv,'#frmSearchDType', '#tbDType','Declare Type',response,2);
            //Customs Port
            CreateLOV(dv,'#frmSearchCPort', '#tbCPort','Customs Port',response,2);
            //Currency
            CreateLOV(dv,'#frmSearchCurr', '#tbCurr','Currency',response,2);
            //Country
            CreateLOV(dv,'#frmSearchCountry', '#tbCountry', 'Country', response,2);
            //FCountry
            CreateLOV(dv,'#frmSearchFCountry', '#tbFCountry','Country',response,2);
            //Agent
            CreateLOV(dv,'#frmSearchVend', '#tbVend','Venders', response,2);
            //Forwarder/Transporter
            CreateLOV(dv,'#frmSearchForw', '#tbForw','Venders',response,2);

            //1 Fields
            //Projects Name
            CreateLOV(dv,'#frmSearchProj', '#tbProj', 'Project Name',response,1);
            //Products
            CreateLOV(dv,'#frmSearchProd', '#tbProd', 'Products',response,1);
            //Vessel
            CreateLOV(dv,'#frmSearchVessel', '#tbVessel', 'Vessels',response,1);
            //Mother Vessel
            CreateLOV(dv,'#frmSearchMVessel', '#tbMVessel','Mother Vessels',response,1);
            //Inv Units
            CreateLOV(dv,'#frmSearchIUnt', '#tbIUnt','Invoice Units',response,2);
            //Weights Unit
            CreateLOV(dv,'#frmSearchWUnt', '#tbWUnt', 'Weight Unit',response,2);
        });
        //load list of values
        let lists = 'CUSTOMS_PRIVILEGE=#cboTyAuthorSp';
        lists += ',CUSTOMS_19BIS=#cboTy19BIS';
        lists += ',CUSTOMS_EXPENSES=#cboTyClearTax';
        loadCombos(path, lists);
    }
    //This section is for popup searching function
    function ReadInterPort(dt) {
        $('#txtInterPort').val(dt.PortCode);
        $('#txtInterPortName').val(dt.PortName);
        $('#txtInterPort').focus();
    }
    function ReadTransporter(dt) {
        $('#txtTransporter').val(dt.VenCode);
        $('#txtTransporterName').val(dt.TName);
        $('#txtTransporter').focus();
    }
    function ReadForwarder(dt) {
        $('#txtForwarder').val(dt.VenCode);
        $('#txtForwarderName').val(dt.TName);
        $('#txtForwarder').focus();
    }
    function ReadCountry(dt) {
        $('#txtInvCountry').val(dt.CTYName);
        $('#txtInvCountryCode').val(dt.CTYCODE);
    }
    function ReadFCountry(dt) {
        $('#txtInvFCountry').val(dt.CTYName);
        $('#txtInvFCountryCode').val(dt.CTYCODE);
    }
    function ReadGWUnit(dt) {
        $('#txtWeightUnit').val(dt.Code);
        $('#txtWeightUnit').focus();
    }
    function ReadInvUnit(dt) {
        $('#txtInvUnit').val(dt.Code);
        $('#txtInvUnit').focus();
    }
    function ReadVessel(dt) {
        $('#txtVesselName').val(dt.TName);
        $('#txtVesselName').focus();
    }
    function ReadMVessel(dt) {
        $('#txtMVesselName').val(dt.TName);
        $('#txtMVesselName').focus();
    }
    function ReadShipping(dt) {
        $('#txtShipping').val(dt.UserID);
        $('#txtShippingName').val(dt.TName);
        $('#txtShipping').focus();
    }
    function ReadCS(dt) {
        rec.CSCode =dt.UserID;
        $('#txtCSName').val(dt.TName);
    }
    function ReadSales(dt) {
        rec.ManagerCode =dt.UserID;
        $('#txtManagerName').val(dt.TName);
    }
    function ReadDeclareType(dt) {
        $('#txtDeclareType').val(dt.Type);
        $('#txtDeclareTypeName').val(dt.Description);
        $('#txtDeclareType').focus();
    }
    function ReadCustomsPort(dt) {
        $('#txtReleasePort').val(dt.AreaCode);
        $('#txtReleasePortName').val(dt.AreaName);
        $('#txtReleasePort').focus();
    }
    function ReadCurrency(dt) {
        $('#txtInvCurrency').val(dt.Code);
        $('#txtInvCurrency').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomerFull(path, dt.CustCode, dt.Branch, '#txtCustName', '#txtTAddress', '#txtEAddress', '#txtPhoneFax');
        $('#txtCustCode').focus();
    }
    function ReadConsignee(dt) {
        $('#txtConsignee').val(dt.CustCode);
        $('#txtConsBranch').val(dt.Branch);
        ShowCustomerFull(path, dt.CustCode, dt.Branch, '#txtConsignName', '#txtBillTAddress', '#txtBillEAddress', '');
        $('#txtConsignee').focus();
    }
    function ReadNotify(dt) {
        $('#txtDeliverTo').val(dt.NameEng);
        $('#txtDeliverAddr').val(dt.EAddress1 + dt.EAddress2);
    }
    function ReadInvProduct(dt) {
        $('#txtInvProduct').val(dt.val);
        $('#txtInvProduct').focus();
    }
    function ReadProjectName(dt) {
        $('#txtProjectName').val(dt.val);
        $('#txtProjectName').focus();
    }
    function SearchData(type) {
        switch (type) {
            case 'interport':
                let CountryID = $('#txtJobType').val() == "IMPORT" ? $('#txtInvFCountryCode').val() : $('#txtInvCountryCode').val();
                SetGridInterPort(path, '#tbIPort', '#frmSearchIPort', CountryID, ReadInterPort);
                break;
            case 'agent':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadTransporter);
                break;
            case 'forwarder':
                SetGridVender(path, '#tbForw', '#frmSearchForw', ReadForwarder);
                break;
            case 'country':
                SetGridCountry(path, '#tbCountry', '#frmSearchCountry', ReadCountry);
                break;
            case 'fcountry':
                SetGridCountry(path, '#tbFCountry', '#frmSearchFCountry', ReadFCountry);
                break;
            case 'GWUnit':
                SetGridUnit(path, '#tbWUnt', '#frmSearchWUnt', ReadGWUnit);
                break;
            case 'invproductunit':
                SetGridUnit(path, '#tbIUnt', '#frmSearchIUnt', ReadInvUnit);
                break;
            case 'mvessel':
                SetGridVessel(path, '#tbMVessel', '#frmSearchMVessel', 'M', ReadMVessel);
                break;
            case 'vessel':
                SetGridVessel(path, '#tbVessel', '#frmSearchVessel', '', ReadVessel);
                break;
            case 'cs':
                SetGridUser(path, '#tbUser2', '#frmSearchUser2', ReadCS);
                break;
            case 'sales':
                SetGridUser(path, '#tbUser3', '#frmSearchUser3', ReadSales);
                break;
            case 'user':
                SetGridUser(path, '#tbUser1', '#frmSearchUser1', ReadShipping);
                break;
            case 'RFDCT':
                SetGridDeclareType(path, '#tbDType', '#frmSearchDType', ReadDeclareType);
                break;
            case 'RFARS':
                SetGridCustomsPort(path, '#tbCPort', '#frmSearchCPort', ReadCustomsPort);
                break;
            case 'CURRENCY':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
            case 'CUSTOMER':
                SetGridCompanyByGroup(path, '#tbCust', 'CUSTOMERS', '#frmSearchCust', ReadCustomer);
                break;
            case 'CONSIGNEE':
                SetGridCompanyByGroup(path, '#tbCons','CONSIGNEE', '#frmSearchCons', ReadConsignee);
                break;
            case 'NOTIFY':
                SetGridCompanyByGroup(path, '#tbNotify', 'NOTIFY_PARTY', '#frmSearchNotify', ReadNotify);
                break;
            case 'ProjectName':
                SetGridProjectName(path, '#tbProj', '#frmSearchProj', ReadProjectName);
                break;
            case 'InvProduct':
                SetGridInvProduct(path, '#tbProd', '#frmSearchProd', ReadInvProduct);
                break;
            case 'SERVUNIT':
                SetContainerEdit();
                break;
            case 'job':
                let dbID = '@ViewBag.DATABASE';
                switch (dbID) {
                    case '1':
                        dbID = '3';
                        break;
                    case '2':
                        dbID = '1';
                        break;
                    case '3':                        
                        break;
                }
                let invNo = $('#txtCustInvNo').val();
                let w = '?DBID=' + dbID;
                if (invNo !== '') w += '&InvNo=' + invNo;
                SetGridJob(path, '#tbJob', '#frmSearchJob', w, function (r) {
                    $('#txtCustPoNo').val(r.JNo);
                    ReadJob(r);
                    ShowConfirm("Import Transport Data too?", function (ans) {
                        if (ans == true) {
                            ImportTransport(dbID, r.JNo);
                        }
                    });

                });
                break;
        }
    }
    //This section for calculate amount of duty payment
    function CalTotalLtd() {
        let ltd1 = Number($('#txtComPaidChq').val());
        let ltd2 = Number($('#txtComPaidCash').val());
        let ltd3 = Number($('#txtComPaidEPay').val());
        let ltd4 = Number($('#txtComPaidOthers').val());

        $('#txtComPaidTotal').val(ltd1 + ltd2 + ltd3 + ltd4);
    }
    function CalTotalCust() {
        let cust1 = Number($('#txtCustPaidChq').val());
        let cust2 = Number($('#txtCustPaidCash').val());
        let cust3 = Number($('#txtCustPaidCard').val());
        let cust4 = Number($('#txtCustPaidBank').val());
        let cust5 = Number($('#txtCustPaidEPay').val());
        let cust6 = Number($('#txtCustPaidOthers').val());

        $('#txtCustPaidTotal').val(cust1 + cust2 + cust3 + cust4 + cust5 + cust6);
    }
    //This section for Load Data And Print data
    function ShowJob(Branch, Job) {
        $.get(path + 'joborder/getjobsql?branch=' + Branch + '&jno=' + Job)
        .done(function (r) {
            if (r.job.data.length > 0) {
                let dr = r.job.data[0];
                rec = dr;
                $('#txtJNo').val(dr.JNo);
                $('#txtCustCode').val(dr.CustCode);
                $('#txtCustBranch').val(dr.CustBranch);
                $('#txtRevised').val(dr.JRevise);
                $('#txtDocDate').val(CDateEN(dr.DocDate));
                $('#txtConfirmDate').val(CDateEN(dr.ConfirmDate));
                $('#txtCloseDate').val(CDateEN(dr.CloseJobDate));
                $('#txtCustPoNo').val(dr.CustRefNO);
                $('#txtCancelReason').val(dr.CancelReson);
                $('#txtCancelDate').val(CDateEN(dr.CancelDate));
                $('#txtConsignee').val(dr.Consigneecode);
                $('#txtConsBranch').val(dr.CustBranch);
                $('#txtShipping').val(dr.ShippingEmp);
                $('#txtForwarder').val(dr.ForwarderCode);
                $('#txtTransporter').val(dr.AgentCode);

                ShowCustomerFull(path,dr.CustCode, dr.CustBranch, '#txtCustName', '#txtTAddress', '#txtEAddress', '#txtPhoneFax');
                ShowJobTypeShipBy(path, dr.JobType, dr.ShipBy, dr.JobStatus, '#txtJobType', '#txtShipBy', '#txtJobStatus');

                ShowUser(path, dr.ManagerCode, '#txtManagerName');
                ShowUser(path, dr.CSCode, '#txtCSName');
                ShowUser(path, dr.CloseJobBy, '#txtCloseBy');
                ShowUser(path, dr.CancelProve, '#txtCancelBy');
                ShowUser(path, dr.ShippingEmp, '#txtShippingName');

                ShowVender(path, dr.ForwarderCode, '#txtForwarderName');
                ShowVender(path, dr.AgentCode, '#txtTransporterName');

                ShowCustomerFull(path, dr.Consigneecode, dr.CustBranch, '#txtConsignName', '#txtBillTAddress', '#txtBillEAddress', '');

                ReadJob(dr);

                if (dr.JobStatus >= 7 && userPosition<='6') {
                    $('#btnSave').attr('disabled', 'disabled');
                } else {
                    $('#btnSave').removeAttr('disabled');
		}

		if(dr.JobStatus>90){
		    $('#btnLinkAdv').attr('disabled', 'disabled');
		    $('#btnLinkClr').attr('disabled', 'disabled');
		}
            }
        });
        ShowLog(Branch, Job);
        ShowTracking(Branch, Job);
    }
    function ReadJob(dr) {
        $('#txtQNo').val(dr.QNo);
        $('#txtQRevise').val(dr.Revise);
        $('#txtCustInvNo').val(dr.InvNo);
        $('#txtDeclareNo').val(dr.DeclareNumber);
        $('#txtCommission').val(dr.Commission);
        $('#txtContactName').val(dr.CustContactName);
        $('#txtJobCondition').val(dr.TRemark);
        $('#txtDescription').val(dr.Description);
        $('#txtProjectName').val(dr.ProjectName);
        $('#txtInvProduct').val(dr.InvProduct);
        $('#txtInvQty').val(dr.InvProductQty);
        $('#txtInvUnit').val(dr.InvProductUnit);
        $('#txtInvPackQty').val(dr.TotalQty);
        $('#txtInvTotal').val(dr.InvTotal);
        $('#txtMeasurement').val(dr.Measurement);
        $('#txtNetWeight').val(dr.TotalNW);
        $('#txtGrossWeight').val(dr.TotalGW);
        $('#txtWeightUnit').val(dr.GWUnit);

        $('#cboTyAuthorSp').val(dr.TyAuthorSp);
        $('#cboTy19BIS').val(dr.Ty19BIS);
        $('#cboTyClearTax').val(dr.TyClearTax);
        $('#txtClearTaxReson').val(dr.TyClearTaxReson);

        $('#chkTSRequest').prop('checked', dr.TSRequest === 1 ? true : false);
        $('#chkTyAuthorSp').prop('checked', $('#cboTyAuthorSp').val() === '' ? false : true);
        $('#chkTy19BIS').prop('checked', $('#cboTy19BIS').val() === '' ? false : true);
        $('#chkTyClearTax').prop('checked', $('#cboTyClearTax').val() === '' ? false : true);

        $('input:radio[name=optDeclareStatus]:checked').prop('checked', false);
        $('input:radio[name=optDeclareStatus][value="' + dr.DeclareStatus + '"]').prop('checked', true);

        $('#txtInvCurrency').val(dr.InvCurUnit);
        $('#txtInvCurRate').val(dr.InvCurRate);
        $('#txtInvCountryCode').val(dr.InvCountry);
        $('#txtInvFCountryCode').val(dr.InvFCountry);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtBLNo').val(dr.BLNo);
        $('#txtHAWB').val(dr.HAWB);
        $('#txtMAWB').val(dr.MAWB);
        $('#txtVesselName').val(dr.VesselName);
        $('#txtMVesselName').val(dr.MVesselName);
        $('#txtInterPort').val(dr.InvInterPort);
        $('#txtTotalCTN').val(dr.TotalContainer);
        $('#txtETDDate').val(CDateEN(dr.ETDDate));
        $('#txtETADate').val(CDateEN(dr.ETADate));
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtDeliveryDate').val(CDateEN(dr.EstDeliverDate));
        $('#txtEDIDate').val(CDateEN(dr.ImExDate));
        $('#txtReadyClearDate').val(CDateEN(dr.ReadyToClearDate));
        $('#txtDutyDate').val(CDateEN(dr.DutyDate));

        $('#txtClearDate').val(CDateEN(dr.ClearDate));
        $('#txtDeclareType').val(dr.DeclareType);
        $('#txtReleasePort').val(dr.ClearPort);
        $('#txtPortNo').val(dr.ClearPortNo);
        $('#txtDutyAmt').val(dr.DutyAmount);

        $('#txtShippingCmd').val(dr.ShippingCmd);

        $('#txtComPaidChq').val(dr.DutyLtdPayChqAmt);
        $('#txtComPaidCash').val(dr.DutyLtdPayCashAmt);
        $('#txtComPaidEPay').val(dr.DutyLtdPayEPAYAmt);
        $('#txtComPaidOthers').val(dr.DutyLtdPayOtherAmt);
        $('#txtComOthersPayBy').val(dr.DutyLtdPayOther);

        $('#txtCustPaidChq').val(dr.DutyCustPayChqAmt);
        $('#txtCustPaidCash').val(dr.DutyCustPayCashAmt);
        $('#txtCustPaidCard').val(dr.DutyCustPayCardAmt);
        $('#txtCustPaidBank').val(dr.DutyCustPayBankAmt);
        $('#txtCustPaidEPay').val(dr.DutyCustPayEPAYAmt);
        $('#txtCustPaidOthers').val(dr.DutyCustPayOtherAmt);
        $('#txtCustOthersPayBy').val(dr.DutyCustPayOther);
        $('#txtDeliverNo').val(dr.DeliveryNo);
        $('#txtDeliverTo').val(dr.DeliveryTo);
        $('#txtDeliverAddr').val(dr.DeliveryAddr);

        ShowCountry(path, dr.InvCountry, '#txtInvCountry');
        ShowCountry(path, dr.InvFCountry, '#txtInvFCountry');
        ShowInterPort(path, dr.JobType == 1 ? dr.InvFCountry : dr.InvCountry, dr.InvInterPort, '#txtInterPortName');

        ShowDeclareType(path, dr.DeclareType, '#txtDeclareTypeName');
        ShowReleasePort(path, dr.ClearPort, '#txtReleasePortName');

        CalTotalLtd();
        CalTotalCust();
    }
    function ShowTracking(Branch, Job) {
        let w = '&cancel=' + ($('#chkCancel').prop('checked') ? 'Y' : 'N');
        w += '&type=' + $('#cboDocType').val();
        $.get(path + 'joborder/getjobdocument?branch=' + Branch + '&job=' + Job + w)
        .done(function (r) {
            if (r.job.data.length > 0) {
                let d = r.job.data;
                let br = $('#txtBranchCode').val();
                let tb=$('#tbTracking').DataTable({
                    data: d,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        {
                            data: "DocDate", title: "Doc Date",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        },
                        { data: "DocType", title: "Type" },
                        { data: "Container", title: "Container" },
                        {
                            data: null, title: "Doc No",
                            render: function (data) {
                                switch (data.DocType) {
                                    case "CHQ":
                                        return '<a href="../Acc/Cheque?BranchCode=' + br + '&ControlNo=' + data.DocNo +'">' + data.DocNo + '</a>';
                                        break;
                                    case "ADV":
                                        return '<a href="../Adv/Index?BranchCode=' + br + '&AdvNo=' + data.DocNo +'">' + data.DocNo + '</a>';
                                        break;
                                    case "CLR":
                                        return '<a href="../Clr/Index?BranchCode='+ br +'&ClrNo='+ data.DocNo+'">' + data.DocNo + '</a>';
                                        break;
                                    case "INV":
                                        return '<a href="../Acc/Invoice?Branch='+ br +'&Code='+ data.DocNo+ '">' + data.DocNo + '</a>';
                                        break;
                                    case "TAX":
                                        return '<a href="../Acc/TaxInvoice?Branch=' + br + '&Code=' + data.DocNo + '">' + data.DocNo + '</a>';
                                        break;
                                    case "RCV":
                                        return '<a href="../Acc/Receipt?Branch=' + br + '&Code=' + data.DocNo + '">' + data.DocNo + '</a>';
                                        break;
                                    default:
                                        return data.DocNo;
                                        break;
                                }
                            }
                        },
                        { data: "ItemNo", title: "Seq" },
                        { data: "Expense", title: "Description" },
                        {
                            data: "Amount", title: "Amount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "DocStatus", title: "Status" }
                    ],
                    destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    responsive: true
                    , pageLength: 100
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbTracking');
            }
        });
    }
    function ShowLog(Branch,Job) {
        $.get(path + 'joborder/getjoborderlog?branch=' + Branch + '&code=' + Job)
            .done(function (r) {
                if (r.joborderlog.data.length > 0) {
                    let d = r.joborderlog.data;
                    let tb=$('#tbLog').DataTable({
                        data: d,
                        selected: true, //ให้สามารถเลือกแถวได้
                        columns: [ //กำหนด property ของ header column
                            {
                                data: "LogDate", title: "Date",
                                render: function (data) {
                                    return CDateEN(data);
                                }
                            },
                            { data: "EmpCode", title: "Staff" },
                            { data: "TRemark", title: "Description" }
                        ],
                        destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                        responsive: true
                        , pageLength: 100
                    });
                    ChangeLanguageGrid('@ViewBag.Module', '#tbLog');
                }
            });
    }
    function PrintData() {
        window.open(path + 'JobOrder/FormJob?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function PrintDelivery() {
        window.open(path + 'JobOrder/FormDelivery?Branch=' + $('#txtBranchCode').val() + '&Doc=' + $('#txtDeliverNo').val(), '', '');
    }
    function OpenAdvance() {
        window.open(path + 'Adv/Index?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenCreditAdv() {
        window.open(path + 'Adv/CreditAdv?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }

    function OpenClearing() {
        window.open(path + 'Clr/Index?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenTransport() {
        window.open(path + 'JobOrder/Transport?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenDocument() {
        window.open(path + 'Tracking/Document?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenExpense() {
        window.open(path + 'Adv/EstimateCost?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenCosting() {
        window.open(path + 'Clr/Costing?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenCheque() {
        window.open(path + 'Acc/Cheque?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function OpenTruckOrder() {
        window.open(path + 'JobOrder/TruckOrder?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
    function GetDataSave(dr) {
        dr.CustCode = $('#txtCustCode').val();
        dr.CustBranch = $('#txtCustBranch').val();
        dr.JRevise = Number($('#txtRevised').val()) + 1;
        dr.DocDate= CDateEN($('#txtDocDate').val());
        dr.QNo=$('#txtQNo').val();
        dr.Revise=$('#txtQRevise').val();
        dr.InvNo=$('#txtCustInvNo').val();
        dr.DeclareNumber=$('#txtDeclareNo').val();
        dr.Commission=$('#txtCommission').val();
        dr.CustContactName=$('#txtContactName').val();
        dr.ConfirmDate=CDateEN($('#txtConfirmDate').val());

        dr.TRemark = $('#txtJobCondition').val();

        dr.CloseJobDate = CDateEN($('#txtCloseDate').val());

        dr.CustRefNO=$('#txtCustPoNo').val();
        dr.Description = $('#txtDescription').val();

        dr.CancelDate = CDateEN($('#txtCancelDate').val());
        dr.CancelReson=$('#txtCancelReason').val();

        dr.Consigneecode=$('#txtConsignee').val();

        dr.ProjectName=$('#txtProjectName').val();
        dr.InvProduct=$('#txtInvProduct').val();
        dr.InvProductQty = CNum($('#txtInvQty').val());
        dr.InvProductUnit=$('#txtInvUnit').val();
        dr.TotalQty = CNum($('#txtInvPackQty').val());
        dr.InvTotal = CNum($('#txtInvTotal').val());
        dr.Measurement=$('#txtMeasurement').val();
        dr.TotalNW = CNum($('#txtNetWeight').val());
        dr.TotalGW = CNum($('#txtGrossWeight').val());
        dr.GWUnit=$('#txtWeightUnit').val();
        dr.InvCurUnit=$('#txtInvCurrency').val();
        dr.InvCurRate = CNum($('#txtInvCurRate').val());
        dr.InvCountry=$('#txtInvCountryCode').val();
        dr.InvFCountry = $('#txtInvFCountryCode').val();

        dr.BookingNo=$('#txtBookingNo').val();
        dr.BLNo=$('#txtBLNo').val();
        dr.HAWB=$('#txtHAWB').val();
        dr.MAWB=$('#txtMAWB').val();
        dr.ForwarderCode=$('#txtForwarder').val();

        dr.VesselName=$('#txtVesselName').val();
        dr.MVesselName=$('#txtMVesselName').val();
        dr.InvInterPort=$('#txtInterPort').val();
        dr.AgentCode=$('#txtTransporter').val();

        dr.TotalContainer = $('#txtTotalCTN').val();

        dr.ETDDate = CDateEN($('#txtETDDate').val());
        dr.ETADate = CDateEN($('#txtETADate').val());
        dr.LoadDate = CDateEN($('#txtLoadDate').val());
        dr.EstDeliverDate = CDateEN($('#txtDeliveryDate').val());
        dr.ImExDate = CDateEN($('#txtEDIDate').val());
        dr.ReadyToClearDate = CDateEN($('#txtReadyClearDate').val());
        dr.DutyDate = CDateEN($('#txtDutyDate').val());

        dr.ClearDate = CDateEN($('#txtClearDate').val());
        dr.ClearPort = $('#txtReleasePort').val();
        dr.ClearPortNo = $('#txtPortNo').val();

        dr.ShippingEmp=$('#txtShipping').val();
        dr.ShippingCmd=$('#txtShippingCmd').val();

        dr.DutyAmount = CNum($('#txtDutyAmt').val());
        dr.DutyLtdPayChqAmt = CNum($('#txtComPaidChq').val());
        dr.DutyLtdPayCashAmt = CNum($('#txtComPaidCash').val());
        dr.DutyLtdPayEPAYAmt = CNum($('#txtComPaidEPay').val());
        dr.DutyLtdPayOtherAmt = CNum($('#txtComPaidOthers').val());
        dr.DutyLtdPayOther = CNum($('#txtComOthersPayBy').val());

        dr.DutyCustPayChqAmt = CNum($('#txtCustPaidChq').val());
        dr.DutyCustPayCashAmt = CNum($('#txtCustPaidCash').val());
        dr.DutyCustPayCardAmt = CNum($('#txtCustPaidCard').val());
        dr.DutyCustPayBankAmt = CNum($('#txtCustPaidBank').val());
        dr.DutyCustPayEPAYAmt = CNum($('#txtCustPaidEPay').val());
        dr.DutyCustPayOtherAmt = CNum($('#txtCustPaidOthers').val());
        dr.DutyCustPayOther = CNum($('#txtCustOthersPayBy').val());

        dr.TSRequest = $('#chkTSRequest').prop('checked');
        dr.DeclareType = $('#txtDeclareType').val();
        dr.DeclareStatus = $('input:radio[name=optDeclareStatus]:checked').val() == undefined ? '' : $('input:radio[name=optDeclareStatus]:checked').val();
        dr.TyAuthorSp = $('#cboTyAuthorSp').val();
        dr.Ty19BIS=$('#cboTy19BIS').val();
        dr.TyClearTax= $('#cboTyClearTax').val();
        dr.TyClearTaxReson = $('#txtClearTaxReson').val();

        dr.DeliveryNo = $('#txtDeliverNo').val();
        dr.DeliveryTo = $('#txtDeliverTo').val();
        dr.DeliveryAddr = $('#txtDeliverAddr').val();

        return dr;
    }
    //This section is For Save Data function
    function CancelJob() {
        if (rec.JobStatus < 99) {
            if (rec.JobStatus < 2||rec.JobStatus==98) {
                if ($('#txtCancelReason').val() !== '') {
                    rec.JobStatus = 99;
                    rec.CancelProve = user;
                    rec.CancelTime = GetTime();
                    ShowUser(path, rec.CancelProve, '#txtCancelBy');

                    $('#txtCancelDate').val(CDateEN(GetToday()));
                    ShowJobTypeShipBy(path, rec.JobType, rec.ShipBy, rec.JobStatus, '#txtJobType', '#txtShipBy', '#txtJobStatus');
                    SaveData();
                    return;
                } else {
                    ShowMessage('Please enter reason for cancel', true);
                    return;
                }
            } else {
                ShowMessage('This job has been cleared,cannot cancel!', true);
                return;
            }
        } else {
            if (user == rec.CancelProve) {
                rec.JobStatus = 0;
                rec.CancelProve = null;
                rec.CancelTime = null;
                rec.CancelDate = null;
                rec.CancelReson = null;
                $('#txtCancelBy').val('');
                $('#txtCancelDate').val('');
                $('#txtCancelReason').val('');
                SaveData();
                $.get(path + 'joborder/updatejobstatus?NoLog=Y&branch=' + rec.BranchCode + '&JNo=' + rec.JNo, function (r) {
                    ShowJob(rec.BranchCode, rec.JNo);
                    return;
                });
                return;
            }
        }
        ShowMessage('This document is cancelled',true);
    }
    function CloseJob() {
        if ($('#txtCloseBy').val() == '') {
            if ($('#txtDutyDate').val()=='') {
                ShowMessage('Please input inspection date',true);
                $('#txtDutyDate').focus();
                return;
            }
            if ($('#txtConfirmDate').val()=='') {
                ShowMessage('Please input confirm date',true);
                $('#txtConfirmDate').focus();
                return;
            }
            if (rec.JobStatus < 3) {
                rec.JobStatus = 3;
            }
            rec.CloseJobBy = user;
            rec.CloseJobTime = GetTime();
            ShowUser(path, rec.CloseJobBy, '#txtCloseBy');
            $('#txtCloseDate').val(CDateEN(GetToday()));
            ShowJobTypeShipBy(path, rec.JobType, rec.ShipBy, rec.JobStatus, '#txtJobType', '#txtShipBy', '#txtJobStatus');
            SaveData();
            return;
        } else {
            if (user == rec.CloseJobBy) {
                if (rec.JobStatus >= 3) {
                    rec.JobStatus = 0;
                    rec.CloseJobBy = null;
                    rec.CloseJobTime = null;
                    rec.CloseJobDate = null;
                    $('#txtCloseBy').val('');
                    $('#txtCloseDate').val('');
                    SaveData();
                    $.get(path + 'joborder/updatejobstatus?NoLog=Y&branch=' + rec.BranchCode + '&JNo=' + rec.JNo, function (r) {
                        ShowJob(rec.BranchCode, rec.JNo);
                        return;
                    });
                    return;
                }
            }
        }
        ShowMessage('This job has been closed');
    }
    function SaveData() {
        if (rec.JNo != undefined) {
            let obj = GetDataSave(rec);

            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetJobData", "JobOrder")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (r) {
                    ShowMessage(r.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            ShowMessage('No data to Save',true);
        }
    }
    //This section is for Total Container Editing
    function SetContainerEdit() {
        $('#tbSUnt').DataTable({
            ajax: {
                url: path + 'Master/GetServUnit', //web service ที่จะ call ไปดึงข้อมูลมา
                dataSrc: 'servunit.data'
            },
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: null, title: "#" },
                { data: "UnitType", title: "รหัส" },
                { data: "UName", title: "คำอธิบาย" }
            ],
            "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                {
                    "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                    "data": null,
                    "render": function (data, type, full, meta) {
                        let html = "<button class='btn btn-warning'>Select</button>";
                        return html;
                    }
                }
            ],
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            , pageLength: 100
        });
        $('#tbSUnt tbody').on('click', 'button', function () {
            let dt = GetSelect('#tbSUnt', this); //read current row selected
            $('#txtUnitAdd').val(dt.UnitType);
            $('#frmSearchSUnt').hide();
        });
        $('#tbSUnt tbody').on('click', 'tr', function () {
            $('#tbSUnt tbody > tr').removeclass('selected'); //ล้างทุก row ที่มีการ select ก่อน
            $(this).addclass('selected'); //select row ใหม่
        });
        $('#frmSearchSUnt').show();
        $('#tbSUnt_filter input').focus();
    }
    function SplitData() {
        let dv = document.getElementById("dvSplit")
        dv.innerHTML = '';
        let str = document.getElementById("txtTotalCTN").value;
        if (str.indexOf(',')>0) {
            let arr = str.split(",");
            for (let i = 0; i < arr.length; i++) {
                AddNewService(arr[i]);
            }
        }
        $('#frmSearchSUnt').hide();

        $('#txtQtyAdd').val('');
        $('#txtUnitAdd').val('');
        SumService();
        $('#frmContainerEdit').modal('show');
    }
    function AddService() {
		if($('#txtUnitAdd').val()==''){
			ShowMessage('Please select unit',true);
			return;
		}
		if($('#txtQtyAdd').val()==''){
			ShowMessage('Please input quantity',true);
			return;
		}
        AddNewService($('#txtQtyAdd').val() + 'x' + $('#txtUnitAdd').val());
    }
    function AddNewService(val) {
        if (val.indexOf("x") < 0) val = "1x" + val;
        let dv = document.getElementById("dvSplit");

        let text = document.createElement("input");
        text.setAttribute("type", "text");
        text.setAttribute("name", "txtQtyCon");
        text.value = val.split("x")[0];
        dv.appendChild(text);

        let text2 = document.createElement("input");
        text2.setAttribute("type", "text");
        text2.setAttribute("name", "txtUnitCon");
        text2.value = val.split("x")[1];
        dv.appendChild(text2);

        let br = document.createElement("br");
        dv.appendChild(br);
        $('#txtQtyAdd').val('');
        $('#txtUnitAdd').val('');
        SumService();
    }
    function SumService() {
        let c = document.getElementsByName("txtQtyCon");
        let u = document.getElementsByName("txtUnitCon");
        let str = '';
        for (let i = 0; i < c.length; i++) {
            if (u[i].value == '') continue;
            if (str.length > 0) str += ',';
            let q = c[i].value;
            if (q == '') q = '1';
            str += q + 'x' + u[i].value;
        }
        let o = document.getElementById("txtTotalCon");
        o.value = str;
    }
    function ApplyService() {
        SumService();
        $('#txtTotalCTN').val($('#txtTotalCon').val());
        $('#frmContainerEdit').modal('hide');
    }
    function AddJobLog() {
        $('#txtLogRemark').val('');
        $('#frmJobOrderLog').modal('show');
    }
    function SaveJobLog() {
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            JNo: $('#txtJNo').val(),
            ItemNo: 0,
            EmpCode: user,
            LogDate:  CDateEN(GetToday()),
            LogTime: GetTime(),
            TRemark: $('#txtLogRemark').val()
        };
        let jsonText = JSON.stringify({ data: obj });
        $.ajax({
            url: "@Url.Action("SetJobOrderLog", "JobOrder")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (r) {
                ShowLog($('#txtBranchCode').val(), $('#txtJNo').val());
                ShowMessage(r.result.msg);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function LoadPaperless() {
        let db = $('#cboDBType').val();
        switch (db) {
            case 'JANDT':
                LoadPaperlessJANDT();
                break;
            case 'ECS':
                if (rec.JobType == 1) {
                    LoadPaperlessECSImport();
                } else {
                    LoadPaperlessECSExport();
                }
                break;
	     case 'ETRANSIT':
               	LoadPaperlessETRANSIT();
                break;
        }
    }
    function LoadPaperlessECSExport() {
        let url = '?job=' + rec.JNo + '&type=' + rec.JobType;
        $.get(path + 'JobOrder/GetPaperless'+ url).done(function (r) {
            if (r.length > 0) {
                $('#txtDeclareNo').val(r[0].DecNO);
                $('#txtCustInvNo').val(r[0].InvNOList);
                $('#txtInvCountry').val(r[0].PurchaseCountry);
                $('#txtInvFCountry').val(r[0].DestCountry);
                if (r[0].DepDate !== null) $('#txtETDDate').val(CDateEN(r[0].DepDate));
                $('#txtInvCurrency').val(r[0].CurCode);
                $('#txtInvCurRate').val(r[0].CurRate);
                $('#txtInvTotal').val(r[0].FOBValueF);
                $('#txtVesselName').val(r[0].VesselName + (r[0].VoyNumber !== '' ? ' V.' + r[0].VoyNumber : ''));
                $('#txtReleasePort').val(r[0].ReleasePort);
                $('#txtPortNo').val(r[0].LoadedPort);
                $('#txtHAWB').val(r[0].HouseBL);
                $('#txtMAWB').val(r[0].MasterBL);
                $('#txtNetWeight').val(r[0].TotalNetW);
                $('#txtGrossWeight').val(r[0].TotalGrossW);
                $('#txtWeightUnit').val(r[0].WeightUnit);
                $('#txtInvQty').val(r[0].TotalPackageAmt);
                $('#txtInvUnit').val(r[0].TotalPackageUnit);

                if (r[0].RecDate !== null) $('#txtEDIDate').val(CDateEN(r[0].RecDate));
                if(r[0].UDateDeclare !==null) $('#txtReadyClearDate').val(CDateEN(r[0].UDateDeclare));
                if (r[0].UDateRelease !== null) $('#txtDutyDate').val(CDateEN(r[0].UDateRelease));
                if (r[0].UDateActual !== null) $('#txtClearDate').val(CDateEN(r[0].UDateActual));

                ShowMessage('Update Complete');
            } else {
                ShowMessage('Data not found', true);
            }
        });
    }
    function LoadPaperlessECSImport() {
        let url = '?job=' + rec.JNo + '&type=' + rec.JobType;
        $.get(path + 'JobOrder/GetPaperless'+ url).done(function (r) {
            if (r.length > 0) {
                $('#txtDeclareNo').val(r[0].DecNO);
                $('#txtCustInvNo').val(r[0].InvNOList);
                $('#txtInvFCountry').val(r[0].ConsCountry);
                $('#txtInvCountry').val(r[0].OriginCountry);
                if (r[0].ArrivalDate !== null) $('#txtETADate').val(CDateEN(r[0].ArrivalDate));
                $('#txtInvCurrency').val(r[0].CurCode);
                $('#txtInvCurRate').val(r[0].CurRate);
                $('#txtInvTotal').val(r[0].CIFValueF);
                $('#txtDutyAmt').val(r[0].TotalTax);
                $('#txtVesselName').val(r[0].VesselName + (r[0].VoyNumber !== '' ? ' V.' + r[0].VoyNumber : ''));
                $('#txtReleasePort').val(r[0].ReleasePort);
                $('#txtPortNo').val(r[0].DischargePort);
                $('#txtHAWB').val(r[0].HouseBL);
                $('#txtMAWB').val(r[0].MasterBL);
                $('#txtNetWeight').val(r[0].TotalNetW);
                $('#txtGrossWeight').val(r[0].TotalGrossW);
                $('#txtWeightUnit').val(r[0].WeightUnit);
                $('#txtInvQty').val(r[0].TotalPackageAmt);
                $('#txtInvUnit').val(r[0].TotalPackageUnit);

                if (r[0].RecDate !== null) $('#txtEDIDate').val(CDateEN(r[0].RecDate));
                if(r[0].UDateDeclare !==null) $('#txtReadyClearDate').val(CDateEN(r[0].UDateDeclare));
                if (r[0].UDateRelease !== null) $('#txtDutyDate').val(CDateEN(r[0].UDateRelease));
                if(r[0].UDateActual !==null) $('#txtClearDate').val(CDateEN(r[0].UDateActual));

                ShowMessage('Update Complete');
            } else {
                ShowMessage('Data not found', true);
            }
        });

    }
    function LoadPaperlessJANDT() {
        let url = '?job=' + rec.JNo + '&type=' + rec.JobType;
        $.get(path + 'JobOrder/GetPaperless'+ url).done(function (r) {
            if (r.length > 0) {
                $('#txtDeclareNo').val(r[0].DECLNO);
                $('#txtCustInvNo').val(r[0].invoiceno);
                if (rec.JobType == 1) {
                    $('#txtInvFCountry').val(r[0].consignmentCTY);
                    $('#txtInvCountry').val(r[0].OriginCTY);
                    if(r[0].VSLDTE!==null) $('#txtETADate').val(ReverseDate(r[0].VSLDTE));
                    $('#txtInvTotal').val(r[0].BAHTVAL);
                    $('#txtDutyAmt').val(r[0].ALLDUTY);
                    $('#txtVesselName').val(r[0].VSLNME + (r[0].voy !== '' ? ' V.' + r[0].voy : ''));
                } else {
                    $('#txtInvCountry').val(r[0].DestinationCTY);
                    $('#txtInvFCountry').val(r[0].PurchaseCTY);
                    if(r[0].VSLDTE!==null) $('#txtETDDate').val(ReverseDate(r[0].VSLDTE));
                    $('#txtInvTotal').val(r[0].FOREVAL);
                    $('#txtReadyClearDate').val(r[0].CHECKEDTIME.substring(0, 10));
                    if(r[0].LOADEDTIME!==null) $('#txtClearDate').val(r[0].LOADEDTIME.substring(0, 10));
                    $('#txtVesselName').val(r[0].VSLNME + (r[0].VOY!==''? ' V.'+ r[0].VOY:''));
                }
                $('#txtReleasePort').val(r[0].ReleasedPort);
                $('#txtPortNo').val(r[0].LoadedPort);
                $('#txtHAWB').val(r[0].HBL);
                $('#txtMAWB').val(r[0].MBL);
                $('#txtNetWeight').val(r[0].Net);
                $('#txtGrossWeight').val(r[0].Gross);
                $('#txtWeightUnit').val(r[0].GrossUnit);
                $('#txtInvQty').val(r[0].PCK);
                $('#txtInvUnit').val(r[0].PCKUNT);
                $('#txtInvCurrency').val(r[0].CUCVAL);
                $('#txtInvCurRate').val(r[0].EHRVAL);
                if(r[0].DECLDATECAL !==null) $('#txtEDIDate').val(ReverseDate(r[0].DECLDATECAL));
                if(r[0].DECLDATE !==null) $('#txtDutyDate').val(ReverseDate(r[0].DECLDATE));

                ShowMessage('Update Complete');
            } else {
                ShowMessage('Data not found', true);
            }
        });
    }
    function LoadPaperlessETRANSIT() {
        let url = '?job=' + rec.JNo + '&type=' + rec.JobType;
        $.get(path + 'JobOrder/GetPaperless2' + url).done(function (r) {
            if (r.length > 0) {
                $('#txtDeclareNo').val(r[0].DECLNO);
                //$('#txtDeclareType').val(r[0].DOCTYPEOLD.split('-')[0]);
                $('#txtCustInvNo').val(r[0].invoiceno);
      		let d = new Date(r[0].fImp_ArrivalDate);
		d.setHours(12);
		let dateStr = d.toISOString().split('T')[0];
      		$('#txtEDIDate').val(dateStr);
                $('#txtReadyClearDate').val(dateStr);
                $('#txtClearDate').val(dateStr);
                if (rec.JobType == 1) {
                    $('#txtInvFCountry').val(r[0].consignmentCTY);
                    $('#txtInvCountry').val(r[0].OriginCTY);
                    //if (r[0].VSLDTE !== null) $('#txtETADate').val(ReverseDate(r[0].VSLDTE));
                    $('#txtInvTotal').val(r[0].BAHTVAL);
                    $('#txtDutyAmt').val(r[0].ALLDUTY);
                    $('#txtComOthersPayBy').val(r[0].PaymentNo);
                    $('#txtComPaidEPay').val(r[0].ALLDUTY);
                    $('#txtVesselName').val(r[0].VSLNME + (r[0].voy !== '' ? ' V.' + r[0].voy : ''));
                } else {
                    $('#txtInvCountry').val(r[0].DestinationCTY);
                    $('#txtInvFCountry').val(r[0].PurchaseCTY);
                    if (r[0].VSLDTE !== null) $('#txtETDDate').val(ReverseDate(r[0].VSLDTE));
                    $('#txtInvTotal').val(r[0].FOREVAL);
                    $('#txtReadyClearDate').val(r[0].CHECKEDTIME.substring(0, 10));
                    if (r[0].LOADEDTIME !== null) $('#txtClearDate').val(r[0].LOADEDTIME.substring(0, 10));
                    $('#txtVesselName').val(r[0].VSLNME + (r[0].VOY !== '' ? ' V.' + r[0].VOY : ''));
                }
                $('#txtReleasePort').val(r[0].DischargePort);
                $('#txtPortNo').val(r[0].LoadedPort);
                $('#txtHAWB').val(r[0].HBL);
                $('#txtMAWB').val(r[0].MBL);
                $('#txtNetWeight').val(r[0].Net);
                $('#txtGrossWeight').val(r[0].Gross);
                $('#txtWeightUnit').val(r[0].GrossUnit);
                $('#txtInvQty').val(r[0].PCK);
                $('#txtInvUnit').val(r[0].PCKUNT);
                $('#txtInvCurrency').val(r[0].CUCVAL);
                $('#txtInvCurRate').val(r[0].EHRVAL);
                //if (r[0].DECLDATECAL !== null) $('#txtReadyClearDate').val(ReverseDate(r[0].DECLDATECAL));
                //if (r[0].DECLDATE !== null) $('#txtDutyDate').val(ReverseDate(r[0].DECLDATE));
                $('#txtClearTaxReson').val(r[0].fReferenceNumber);
                $('#txtInvCurrency').val(r[0].CurrencyCode);
                $('#txtInvProduct').val(r[0].ProductEName);
                ShowMessage('Update Complete');
            } else {
                ShowMessage('Data not found', true);
            }
        });
    }
    function PrintForm() {
        window.open(path + 'Clr/FormEntry?branch=' + $('#txtBranchCode').val() + '&job=' + $('#txtJNo').val());
    }
    function ImportTransport(db, job) {
        SaveData();
        $.get(path + 'JobOrder/CopyTransportData?DBID=' + db + '&FROM=' + job + '&TO=' + $('#txtJNo').val()).done(function (r) {
            ShowMessage(r);
        });
    }
</script>