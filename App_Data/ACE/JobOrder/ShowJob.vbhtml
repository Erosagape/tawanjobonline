@Code
    ViewBag.Title = "Job Information"
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
<div Class="panel-body">
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
                    <input type="date" class="form-control" id="txtDocDate" disabled />
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
            <div class="tab-content">
                <div id="tabinfo" class="tab-pane fade in active">
                    <div class="row">
                        <div class="col-sm-8">
                            <div style="display:flex;flex-direction:column">
                                <div>
                                    <a href="../Master/Customers" target="_blank">
                                        <label id="lblCustCode">Customer :</label>
                                    </a>
                                    <input type="text" id="txtCustCode" style="width:130px" tabindex="0" />
                                    <input type="text" id="txtCustBranch" style="width:40px" tabindex="1" />
                                    <input type="button" id="btnBrowseCust" value="..." onclick="SearchData('CUSTOMER')" />
                                    <input type="text" id="txtCustName" style="width:100%" disabled />
                                </div>
                                <div>
                                    <label id="lblTAddress" for="txtTAddress">Address   :</label><br />
                                    <textarea id="txtTAddress" style="width:250px" disabled></textarea>
                                    <textarea id="txtEAddress" style="width:250px" disabled></textarea>
                                </div>
                                <div>
                                    <label id="lblPhoneFax" for="txtPhoneFax">Contact Info :</label>
                                    <input type="text" id="txtPhoneFax" style="width:100%" tabindex="2" />
                                </div>
                                <div>
                                    <a href="../Master/Customers?mode=CONSIGNEE" target="_blank">
                                        <label id="lblConsignee">Consignee :</label>
                                    </a>
                                    <input type="text" id="txtConsignee" style="width:130px" tabindex="7" />
                                    <input type="text" id="txtConsBranch" style="width:40px" tabindex="8" />
                                    <input type="button" id="btnBrowseCons" value="..." onclick="SearchData('CONSIGNEE')" />
                                    <input type="text" id="txtConsignName" style="width:100%" disabled />
                                </div>
                                <div>
                                    <label id="lblBillAddress" for="txtBillTAddress">Address   :</label><br />
                                    <textarea id="txtBillTAddress" style="width:250px" disabled></textarea>
                                    <textarea id="txtBillEAddress" style="width:250px" disabled></textarea>
                                </div>
                                <div>
                                    <input type="checkbox" id="chkTSRequest" />
                                    <label id="lblUseLocalTrans" for="chkTSRequest">Use Local Transport</label>
                                </div>
                                <div>
                                    <label id="lblContactName" for="txtContactName">Contact Person :</label>
                                    <input type="text" id="txtContactName" style="width:100%" tabindex="3" />
                                    <label id="lblCSName" for="txtCSName">Support By :</label>
                                    <input type="text" id="txtCSName" style="width:150px" disabled />
                                    <input type="button" id="btnBrowseCS" value="..." onclick="SearchData('cs')" />
                                </div>
                                <div>
                                    <label id="lblJobType" for="txtJobType">Job Type : </label>
                                    <input type="text" id="txtJobType" style="width:150px" disabled />
                                    <label id="lblShipBy" for="txtShipBy">Ship By : </label>
                                    <input type="text" id="txtShipBy" style="width:150px" disabled />

                                </div>
                                <div>
                                    <label id="lblJobCondition" for="txtJobCondition">Work Condition :</label>
                                    <input type="text" id="txtJobCondition" style="width:300px" tabindex="4" />
                                </div>
                                <div>
                                    <label id="lblCustPoNo" for="txtCustPoNo">Customer PO :</label>
                                    <input type="text" id="txtCustPoNo" style="width:300px" tabindex="5" />
                                </div>
                                <div>
                                    <label id="lblDescription" for="txtDescription">Descriptions : </label>
                                    <textarea id="txtDescription" style="width:180px" tabindex="6"></textarea>
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div style="display:flex;flex-direction:column">
                                <div>
                                    <label id="lblQNo" for="txtQNo">Quotation : </label>
                                    <input type="text" id="txtQNo" style="width:130px" tabindex="9" />
                                    <input type="text" id="txtQRevise" style="width:40px" tabindex="10" />
                                </div>
                                <div>
                                    <label id="lblManagerName" for="txtManagerName">Sales By :</label>
                                    <input type="text" id="txtManagerName" style="width:130px" disabled />
                                    <input type="button" id="btnBrowseSales" value="..." onclick="SearchData('sales')" />
                                </div>
                                <div>
                                    <label id="lblCommission" for="txtCommission">Commission :</label>
                                    <input type="text" id="txtCommission" style="width:130px" tabindex="11" />
                                </div>
                                <div>
                                    <label id="lblConfirmDate" for="txtConfirmDate" style="color:red">Confirm Date :</label>
                                    <input type="date" id="txtConfirmDate" style="width:130px" tabindex="12" />

                                </div>
                                <div>
                                    <label id="lblCloseBy" for="txtCloseBy">Close By :</label>
                                    <input type="text" id="txtCloseBy" style="width:130px" disabled />
                                </div>
                                <div>
                                    <label id="lblCloseDate" for="txtCloseDate">Close Date : </label>
                                    <input type="date" id="txtCloseDate" style="width:130px" disabled />
                                    <button id="btnCloseJob" class="btn btn-warning" onclick="CloseJob()" style="width:130px">Close Job</button>
                                </div>
                                <div>
                                    <label id="lblCancelBy" for="txtCancelBy">Cancel By :</label>
                                    <input type="text" id="txtCancelBy" style="width:130px" disabled />
                                </div>
                                <div>
                                    <label id="lblCancelDate" for="txtCancelDate">Cancel Date :</label>
                                    <input type="date" id="txtCancelDate" style="width:130px" disabled />
                                </div>
                                <div>
                                    <label id="lblCancelReason" for="txtCancelReason">Cancel Note : </label>
                                    <textarea id="txtCancelReason" style="width:180px"></textarea>
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
                                <div>
                                    <label id="lblCustInvNo" for="txtCustInvNo" style="color:red">Cust.Invoice No :</label>
                                    <input type="text" id="txtCustInvNo" style="width:200px" tabindex="13" />
                                </div>
                                <div>
                                    <label id="lblInvProduct" for="txtInvProduct">Products :</label>
                                    <input type="text" id="txtInvProduct" style="width:200px" tabindex="14" />
                                    <input type="button" id="btnBrowseProd" value="..." onclick="SearchData('InvProduct')" />
                                </div>
                                <div>
                                    <label id="lblInvTotal" for="txtInvTotal">Inv.Total :</label>
                                    <input type="text" id="txtInvTotal" style="width:130px" tabindex="15" />
                                </div>
                                <div>
                                    <a href="../Master/Currency" target="_blank">
                                        <label id="lblInvCurrency">Currency :</label>
                                    </a>
                                    <input type="text" id="txtInvCurrency" style="width:80px" tabindex="16" />
                                    <input type="button" id="btnBrowseRate" value="..." onclick="SearchData('CURRENCY')" />
                                    <label id="lblExchangeRate" for="txtInvCurRate">Exchange Rate :</label>
                                    <input type="text" id="txtInvCurRate" style="width:80px" tabindex="17" />
                                </div>
                                <div>
                                    <label id="lblBookingNo" for="txtBookingNo" style="color:red">Booking No :</label>
                                    <input type="text" id="txtBookingNo" style="width:250px" tabindex="18" />
                                </div>
                                <div>
                                    <label id="lblBLNo" for="txtBLNo">BL/AWB Status :</label>
                                    <input type="text" id="txtBLNo" style="width:200px" tabindex="19" />
                                </div>
                                <div>
                                    <label id="lblHAWB" for="txtHAWB">House BL/AWB :</label>
                                    <input type="text" id="txtHAWB" style="width:200px" tabindex="20" />
                                </div>
                                <div>
                                    <label id="lblMAWB" for="txtMAWB">Master BL/AWB :</label>
                                    <input type="text" id="txtMAWB" style="width:200px" tabindex="21" />
                                </div>
                                <div>
                                    <label id="lblTotalCTN" for="txtTotalCTN">Total Containers :</label>
                                    <input type="text" id="txtTotalCTN" style="width:130px" tabindex="22" />
                                    <input type="button" id="btnGetCTN" value="..." onclick="SplitData()" />
                                </div>
                                <div>
                                    <label id="lblMeasurement" for="txtMeasurement">Meas.(CBM) :</label>
                                    <input type="text" id="txtMeasurement" style="width:80px" tabindex="23" />
                                    <label id="lblDeliverNo" for="txtDeliverNo">Delivery No :</label>
                                    <input type="text" id="txtDeliverNo" style="width:130px" tabindex="24" />
                                </div>
                                <div>
                                    <label id="lblDeliverTo" for="txtDeliverTo">Delivery To :</label>
                                    <input type="text" id="txtDeliverTo" style="width:300px" tabindex="25" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div style="display:flex;flex-direction:column">
                                <div>
                                    <label id="lblProjectName" for="txtProjectName">Project Name :</label>
                                    <textarea id="txtProjectName" style="width:70%" tabindex="26"></textarea>
                                    <input type="button" id="btnBrowseProj" value="..." onclick="SearchData('ProjectName')" />
                                </div>
                                <div>
                                    <label id="lblInvQty" for="txtInvQty">Qty :</label>
                                    <input type="text" id="txtInvQty" style="width:130px" tabindex="27" />
                                    <input type="text" id="txtInvUnit" style="width:40px" tabindex="28" />
                                    <input type="button" id="btnBrowseUnit" value="..." onclick="SearchData('invproductunit')" />
                                    <label id="lblInvPackQty" for="txtInvPackQty">Package.Total :</label>
                                    <input type="text" id="txtInvPackQty" style="width:130px" tabindex="29" />
                                </div>
                                <div>
                                    <label id="lblNetWeight" for="txtNetWeight">Net Weight :</label>
                                    <input type="text" id="txtNetWeight" style="width:80px" tabindex="30" />
                                    <label id="lblGrossWeight" for="txtGrossWeight">Gross Weight :</label>
                                    <input type="text" id="txtGrossWeight" style="width:80px" tabindex="31" />
                                    <input type="text" id="txtWeightUnit" style="width:60px" tabindex="32" />
                                    <input type="button" id="btnBrowseMeas" value="..." onclick="SearchData('GWUnit')" />
                                </div>
                                <div>
                                    <label id="lblInvFCountry" for="txtInvFCountry">From Country :</label>
                                    <input type="hidden" id="txtInvFCountryCode" />
                                    <input type="text" id="txtInvFCountry" style="width:130px" disabled />
                                    <input type="button" id="btnBrowseFCountry" value="..." onclick="SearchData('fcountry')" tabindex="33" />
                                    <label id="lblInvCountry" for="txtInvCountry">To :</label>
                                    <input type="hidden" id="txtInvCountryCode" />
                                    <input type="text" id="txtInvCountry" style="width:130px" disabled />
                                    <input type="button" id="btnBrowseCountry" value="..." onclick="SearchData('country')" tabindex="34" />
                                </div>
                                <div>
                                    <a href="../Master/InterPort" target="_blank">
                                        <label id="lblInvInterPort">Inter Port:</label>
                                    </a>
                                    <input type="text" id="txtInterPort" style="width:130px" tabindex="35" />
                                    <input type="button" id="btnBrowseIPort" value="..." onclick="SearchData('interport')" />
                                    <input type="text" id="txtInterPortName" style="width:160px" disabled />
                                </div>
                                <div>
                                    <a href="../Master/Venders" target="_blank"><label style="color:red" id="lblForwarder">Agent:</label></a>
                                    <input type="text" id="txtForwarder" style="width:130px" tabindex="36" />
                                    <input type="button" id="btnBrowseFwdr" value="..." onclick="SearchData('forwarder')" />
                                    <input type="text" id="txtForwarderName" style="width:300px" disabled />
                                </div>
                                <div>
                                    <label id="lblVesselName" for="txtVesselName">Vessel Name :</label>
                                    <input type="text" id="txtVesselName" style="width:200px" tabindex="37" />
                                    <input type="button" id="btnBrowseVsl1" value="..." onclick="SearchData('vessel')" />
                                </div>
                                <div>
                                    <label id="lblMVesselName" for="txtMVesselName">Master Vessel Name :</label>
                                    <input type="text" id="txtMVesselName" style="width:200px" tabindex="38" />
                                    <input type="button" id="btnBrowseVsl2" value="..." onclick="SearchData('mvessel')" />
                                </div>
                                <div>
                                    <a href="../Master/Venders" target="_blank"><label style="color:red" id="lblTransporter">Transporter:</label></a>
                                    <input type="text" id="txtTransporter" style="width:130px" tabindex="39" />
                                    <input type="button" id="btnBrowseTrans" value="..." onclick="SearchData('agent')" />
                                    <input type="text" id="txtTransporterName" style="width:250px" disabled />
                                </div>
                                <div>
                                    <label id="lblETDDate" for="txtETDDate" style="color:red">ETD Date:</label><input type="date" style="width:130px" id="txtETDDate" tabindex="40" />
                                    <label id="lblETADate" for="txtETADate" style="color:red">ETA Date:</label><input type="date" style="width:130px" id="txtETADate" tabindex="41" />
                                </div>
                                <div>
                                    <label id="lblLoadDate" for="txtLoadDate" style="color:red">Load Date:</label><input type="date" style="width:130px" id="txtLoadDate" tabindex="42" />
                                    <label id="lblDeliveryDate" for="txtDeliveryDate" style="color:red">Unload Date :</label><input type="date" style="width:130px" id="txtDeliveryDate" tabindex="43" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <label id="lblDeliverAddr" for="txtDeliverAddr">Delivery Address :</label>
                            <textarea id="txtDeliverAddr" style="width:100%" tabindex="44"></textarea>
                            <button id="btnDelivery" class="btn btn-info" onclick="PrintDelivery()">Delivery Slip</button>
                        </div>
                    </div>
                </div>
                <div id="tabdeclare" class="tab-pane fade">
                    <div class="row">
                        <div class="col-sm-3">
                            <label id="lblEDIDate" for="txtEDIDate">EDI Date :</label>
                            <input type="date" id="txtEDIDate" style="width:130px" tabindex="45" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblReadyClearDate" for="txtReadyClearDate">Ready Clear :</label>
                            <input type="date" id="txtReadyClearDate" style="width:130px" tabindex="46" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDutyDate" for="txtDutyDate" style="color:red">Inspection Date :</label>
                            <input type="date" id="txtDutyDate" style="width:130px" tabindex="47" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblClearDate" for="txtClearDate">Clear Date :</label>
                            <input type="date" id="txtClearDate" style="width:130px" tabindex="48" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <a href="../Master/DeclareType" target="_blank">
                                <label id="lblDeclareType">Declare Type :</label>
                            </a>
                            <input type="text" id="txtDeclareType" style="width:130px" tabindex="49" />
                            <input type="button" id="btnBrowseDCType" value="..." onclick="SearchData('RFDCT')" />
                            <input type="text" id="txtDeclareTypeName" style="width:200px" disabled />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDeclareNo" for="txtDeclareNo" style="color:red">Declare No :</label>
                            <input type="text" id="txtDeclareNo" style="width:130px" tabindex="50" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblDutyAmt" for="txtDutyAmt">Duty Amt :</label>
                            <input type="text" id="txtDutyAmt" style="width:130px" tabindex="51" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <input type="checkbox" id="chkTyAuthorSp" />
                            <label id="lblTyAuthorSp" for="chkTyAuthorSp">Special Privilege</label>
                            <select id="cboTyAuthorSp" class="dropdown"></select>
                        </div>
                        <div class="col-sm-4">
                            <input type="checkbox" id="chkTy19BIS" />
                            <label id="lblTy19BIS" for="chkTy19BIS">19 BIS Rule</label>
                            <select id="cboTy19BIS" class="dropdown"></select>
                        </div>
                        <div class="col-sm-4">
                            <input type="checkbox" id="chkTyClearTax" />
                            <label id="lblTyClearTax" for="chkTyClearTax">Duty Rule</label>
                            <select id="cboTyClearTax" class="dropdown"></select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div style="display:flex;flex-direction:column">
                                <div>
                                    <label id="lblClearTaxReson" for="txtClearTaxReson">Certificates# </label>
                                    <input type="text" id="txtClearTaxReson" style="width:300px" tabindex="52" />
                                </div>
                                <div>
                                    <label id="lblDeclareStatus" for="optDeclareStatus">Declaration Status :</label>
                                    <label class="radio-inline"><input type="radio" name="optDeclareStatus" value="G"><label style="color:green;font:bold" id="lblGreen">Green</label></label>
                                    <label class="radio-inline"><input type="radio" name="optDeclareStatus" value="R"><label style="color:red;font:bold" id="lblRed">Red</label></label>
                                    <label class="radio-inline"><input type="radio" name="optDeclareStatus" value="M"><label style="color:blue;font:bold" id="lblManual">Manual</label></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div style="display:flex;flex-direction:column">
                                <div>
                                    <a href="../Master/CustomsPort" target="_blank">
                                        <label id="lblReleasePort" style="color:red">Release Port :</label>
                                    </a>
                                    <input type="text" id="txtReleasePort" style="width:50px" tabindex="53" />
                                    <input type="button" id="btnBrowseLCPort" value="..." onclick="SearchData('RFARS')" />
                                    <input type="text" id="txtReleasePortName" style="width:200px" disabled />
                                </div>
                                <div>
                                    <label id="lblPortNo" for="txtPortNo">Discharge Port#</label>
                                    <input type="text" id="txtPortNo" style="width:300px" tabindex="54" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <label id="lblShippingCmd" for="txtShippingCmd">Shipping Note :</label>
                            <textarea id="txtShippingCmd" style="width:100%" tabindex="56"></textarea>
                        </div>

                        <div class="col-sm-7">
                            <label id="lblShipping" for="txtShipping">Shipping Staff :</label>
                            <input type="text" id="txtShipping" style="width:130px" tabindex="55" />
                            <input type="button" id="btnBrowseShipping" value="..." onclick="SearchData('user')" />
                            <input type="text" id="txtShippingName" style="width:300px" disabled />
                            <br />
                            <button id="btnLinkPaperless" class="btn btn-success" onclick="LoadPaperless()">Load Data From TAWAN Paperless</button>
                        </div>
                    </div>
                    <br />
                    <label>Advances Expenses Information :</label>
                    <div class="row">
                        <div class="col-sm-6">
                            <table>
                                <tr>
                                    <td>
                                        <label id="lblComPaidBy" style="font:bold">Company Paid By : </label>
                                        <br />
                                        <label id="lblComChq">Cheque:</label>
                                    </td>
                                    <td>
                                        <br />
                                        <input type="text" id="txtComPaidChq" style="width:130px" onchange="CalTotalLtd();" tabindex="57" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblComCash">Cash:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtComPaidCash" style="width:130px" onchange="CalTotalLtd();" tabindex="58" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblComEPay">E-Payment:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtComPaidEPay" style="width:130px" onchange="CalTotalLtd();" tabindex="59" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblComOther">Others:</label>
                                        <input type="text" id="txtComOthersPayBy" style="width:130px" tabindex="58" />
                                    </td>
                                    <td>
                                        <input type="text" id="txtComPaidOthers" style="width:130px" onchange="CalTotalLtd();" tabindex="60" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblComTotal">Total Paid:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtComPaidTotal" style="width:130px" disabled />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-sm-6">
                            <table>
                                <tr>
                                    <td>
                                        <label id="lblCustPaidBy" style="font:bold">Customer Paid By : </label>
                                        <br />
                                        <label id="lblCustChq">Cheque:</label>
                                    </td>
                                    <td>
                                        <br />
                                        <input type="text" id="txtCustPaidChq" style="width:130px" onchange="CalTotalCust();" tabindex="61" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblCustCash">Cash:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtCustPaidCash" style="width:130px" onchange="CalTotalCust();" tabindex="62" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblCustTaxCard">Tax-Card:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtCustPaidCard" style="width:130px" onchange="CalTotalCust();" tabindex="63" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblCustEPay">E-Payment:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtCustPaidEPay" style="width:130px" onchange="CalTotalCust();" tabindex="64" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblCustBankGuarantee">Bank Guarantee:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtCustPaidBank" style="width:130px" onchange="CalTotalCust();" tabindex="65" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblCustOther">Others:</label>
                                        <input type="text" id="txtCustOthersPayBy" style="width:130px" tabindex="65" />
                                    </td>
                                    <td>
                                        <input type="text" id="txtCustPaidOthers" style="width:130px" onchange="CalTotalCust();" tabindex="66" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label id="lblCustTotal">Total Paid:</label>
                                    </td>
                                    <td>
                                        <input type="text" id="txtCustPaidTotal" style="width:130px" disabled />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <button id="btnViewTAdv" class="btn btn-default" onclick="OpenCreditAdv()">Credit Advances</button>
                        </div>
                        <div class="col-sm-6">
                            <button id="btnViewChq" class="btn btn-default" onclick="OpenCheque()">Customer Cheque</button>
                        </div>
                    </div>
                </div>
                <div id="tabtracking" class="tab-pane fade">
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
                                    Document No
                                </th>
                                <th class="desktop">
                                    Expenses
                                </th>
                                <th class="desktop">
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
                            <button class="btn btn-warning" id="btnLinkAdv" onclick="OpenAdvance()">Advance Request</button>
                            <button class="btn btn-success" id="btnLinkClr" onclick="OpenClearing()">Advance Clearing</button>
                            <button class="btn btn-danger" id="btnLinkCost" onclick="OpenCosting()">Cost & Profit</button>
                        </div>
                    </div>
                </div>
            </div>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
            </a>
            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print</b>
            </a>
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
    let rec = {};
    //main function
    //$(document).ready(function () {
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
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("frmLOVs");
            //Customers
            CreateLOV(dv,'#frmSearchCust', '#tbCust','Customers',response,3);
            //Consignee
            CreateLOV(dv,'#frmSearchCons', '#tbCons','Consignees',response,3);
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
            case 'ProjectName':
                SetGridProjectName(path, '#tbProj', '#frmSearchProj', ReadProjectName);
                break;
            case 'InvProduct':
                SetGridInvProduct(path, '#tbProd', '#frmSearchProd', ReadInvProduct);
                break;
            case 'SERVUNIT':
                SetContainerEdit();
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
                ShowCustomerFull(path,dr.CustCode, dr.CustBranch, '#txtCustName', '#txtTAddress', '#txtEAddress', '#txtPhoneFax');
                ShowJobTypeShipBy(path,dr.JobType, dr.ShipBy, dr.JobStatus, '#txtJobType', '#txtShipBy', '#txtJobStatus');
                $('#txtRevised').val(dr.JRevise);
                $('#txtDocDate').val(CDateEN(dr.DocDate));
                $('#txtQNo').val(dr.QNo);
                $('#txtQRevise').val(dr.Revise);
                $('#txtCustInvNo').val(dr.InvNo);
                $('#txtDeclareNo').val(dr.DeclareNumber);
                ShowUser(path,dr.ManagerCode, '#txtManagerName');
                $('#txtCommission').val(dr.Commission);
                $('#txtContactName').val(dr.CustContactName);
                ShowUser(path,dr.CSCode, '#txtCSName');
                $('#txtConfirmDate').val(CDateEN(dr.ConfirmDate));
                ShowUser(path,dr.CloseJobBy, '#txtCloseBy');
                $('#txtJobCondition').val(dr.TRemark);
                $('#txtCloseDate').val(CDateEN(dr.CloseJobDate));
                $('#txtCustPoNo').val(dr.CustRefNO);
                $('#txtDescription').val(dr.Description);
                $('#txtCancelReason').val(dr.CancelReson);
                ShowUser(path,dr.CancelProve, '#txtCancelBy');
                $('#txtConsignee').val(dr.Consigneecode);
                $('#txtConsBranch').val(dr.CustBranch);
                ShowCustomerFull(path,dr.Consigneecode, dr.CustBranch, '#txtConsignName', '#txtBillTAddress', '#txtBillEAddress', '');

                $('#txtCancelDate').val(CDateEN(dr.CancelDate));
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
                $('#chkTyAuthorSp').prop('checked', $('#cboTyAuthorSp').val()==='' ? false : true);
                $('#chkTy19BIS').prop('checked', $('#cboTy19BIS').val() === '' ? false : true);
                $('#chkTyClearTax').prop('checked', $('#cboTyClearTax').val() === '' ? false : true);

                $('input:radio[name=optDeclareStatus]:checked').prop('checked', false);
                $('input:radio[name=optDeclareStatus][value="' + dr.DeclareStatus + '"]').prop('checked', true);

                $('#txtInvCurrency').val(dr.InvCurUnit);
                $('#txtInvCurRate').val(dr.InvCurRate);
                $('#txtInvCountryCode').val(dr.InvCountry);
                $('#txtInvFCountryCode').val(dr.InvFCountry);
                ShowCountry(path,dr.InvCountry, '#txtInvCountry');
                ShowCountry(path,dr.InvFCountry, '#txtInvFCountry');
                $('#txtBookingNo').val(dr.BookingNo);
                $('#txtBLNo').val(dr.BLNo);
                $('#txtHAWB').val(dr.HAWB);
                $('#txtMAWB').val(dr.MAWB);
                $('#txtForwarder').val(dr.ForwarderCode);
                ShowVender(path,dr.ForwarderCode, '#txtForwarderName');
                $('#txtVesselName').val(dr.VesselName);
                $('#txtMVesselName').val(dr.MVesselName);
                $('#txtInterPort').val(dr.InvInterPort);
                ShowInterPort(path, dr.JobType == 1 ? dr.InvFCountry : dr.InvCountry, dr.InvInterPort, '#txtInterPortName');
                $('#txtTransporter').val(dr.AgentCode);
                ShowVender(path,dr.AgentCode, '#txtTransporterName');
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
                ShowDeclareType(path,dr.DeclareType, '#txtDeclareTypeName');
                $('#txtReleasePort').val(dr.ClearPort);
                $('#txtPortNo').val(dr.ClearPortNo);
                ShowReleasePort(path,dr.ClearPort, '#txtReleasePortName');
                $('#txtDutyAmt').val(dr.DutyAmount);
                $('#txtShipping').val(dr.ShippingEmp);
                ShowUser(path,dr.ShippingEmp, '#txtShippingName');
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

                CalTotalLtd();
                CalTotalCust();

                $('#txtDeliverNo').val(dr.DeliveryNo);
                $('#txtDeliverTo').val(dr.DeliveryTo);
                $('#txtDeliverAddr').val(dr.DeliveryAddr);

                if (dr.JobStatus >= 7) {
                    $('#btnSave').attr('disabled', 'disabled');
                }
            }
        });
        ShowLog(Branch, Job);
        ShowTracking(Branch, Job);
    }
    function ShowTracking(Branch, Job) {
        let w = '&cancel=' + ($('#chkCancel').prop('checked') ? 'Y' : 'N');
        $.get(path + 'joborder/getjobdocument?branch=' + Branch + '&job=' + Job + w)
        .done(function (r) {
            if (r.job.data.length > 0) {
                let d = r.job.data;
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
                        { data: "DocNo", title: "Doc No" },
                        { data: "Expense", title: "Description" },
                        { data: "Amount", title: "Amount" },
                        { data: "DocStatus", title: "Status" }
                    ],
                    destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    responsive:true
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
                        responsive:true
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
        if (rec.JobStatus !== 99) {
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
                ShowMessage('Please enter reason for cancel',true);
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
        });
        $('#tbSUnt tbody').on('click', 'button', function () {
            let dt = GetSelect('#tbSUnt', this); //read current row selected
            $('#txtUnitAdd').val(dt.UnitType);
            $('#frmSearchSUnt').hide();
        });
        $('#tbSUnt tbody').on('click', 'tr', function () {
            $('#tbSUnt tbody > tr').removeClass('selected'); //ล้างทุก row ที่มีการ select ก่อน
            $(this).addClass('selected'); //select row ใหม่
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
</script>
