@Code
    ViewBag.Title = "Create Job"
End Code
    <div Class="panel-body">
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblJobType" style="display:block;width:100%;">Job Type</label>
                </div>
                <div style="width:70%">
                    <select id="cboJobType" class="form-control dropdown" onchange="CheckJobType()" style="width:100%" tabindex="0"></select>
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblShipBy" style="display:block;width:100%;">Ship By</label>
                </div>
                <div style="width:70%">
                    <select id="cboShipBy" class="form-control dropdown" onchange="GetQuotation()" style="width:100%" tabindex="1"></select>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblBranch" style="display:block;width:100%;">Branch</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" style="width:60px" id="txtBranchCode" tabindex="2" />
                    <input type="button" class="btn btn-default" id="btnBrowseBranch" value="..." onclick="SearchData('branch')" />
                    <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblCSCode" style="display:block;width:100%">CS Code:</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtCSCode" style="width:120px" tabindex="3" />
                    <input type="button" class="btn btn-default" id="btnBrowseCS" value="..." onclick="SearchData('user')" />
                    <input type="text" class="form-control" id="txtCSName" style="width:100%" disabled />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <a href="../Master/Customers"><label id="lblCustCode" style="display:block;width:100%;">Customer</label></a>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" style="width:80px" id="txtCustCode" tabindex="4" />
                    <input type="text" class="form-control" style="width:40px" id="txtCustBranch" tabindex="5" />
                    <input type="button" class="btn btn-default" id="btnBrowseCust" value="..." onclick="SearchData('customer')" />
                    <input type="text" class="form-control" style="width:100%" id="txtCustName" disabled />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <a href="../Master/Customers?Mode=CONSIGNEE"><label id="lblBillingPlace" style="display:block;width:100%;">Consignee</label></a>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtConsignee" style="width:120px" tabindex="6" />
                    <input type="button" class="btn btn-default" id="btnBrowseCons" value="..." onclick="SearchData('consignee')" />
                    <input type="text" class="form-control" id="txtConsignName" style="width:100%" disabled />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblContactName" style="display:block;width:100%;">Contact</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtContactPerson" style="width:100%" tabindex="7" />
                    <input type="button" class="btn btn-default" id="btnBrowseContact" value="..." onclick="SearchData('contact')" />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblQuotation" style="display:block;width:100%;">Quotation</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" style="width:100%" id="txtQNo" tabindex="8" disabled />
                    <input type="text" class="form-control" style="width:50px" id="txtRevise" tabindex="9" disabled />
                    <input type="button" class="btn btn-default" id="btnBrowseQuo" value="..." onclick="SearchData('quotation')" />
                    <input type="hidden" id="txtManagerCode" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblCustInv" style="display:block;width:100%;color:red">Commercial Invoice</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtCustInv" style="width:100%" tabindex="10" />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblPoNo" style="display:block;width:100%;">PO/Customer Reference</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" style="width:100%" id="txtCustPO" tabindex="11" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%;color:red">
                    <label id="lblBookingNo" style="display:block;width:100%;">Booking.No</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtBookingNo" style="width:100%" tabindex="12" />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblDutyDate" style="display:block;width:100%;">Operation Date</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="date" class="form-control" style="width:100%" id="txtDutyDate" tabindex="13" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblHAWB" style="display:block;width:100%;" onclick="CopyFromBooking()">House BL/AWB</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtHAWB" style="width:100%" tabindex="14" />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblMAWB" style="display:block;width:100%;" onclick="CopyFromHouseBL()">Master BL/AWB</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" style="width:100%" id="txtMAWB" tabindex="15" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblVesselName" style="display:block;width:100%;">Vessel Name</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtVesselName" style="width:100%" />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblJobDate" style="display:block;width:100%;">Job Date</label>
                </div>
                <div style="display:flex;width:40%">
                    <input type="date" class="form-control" style="width:100%" id="txtJobDate" tabindex="16" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <a href="../Master/Venders">
                        <label id="lblTransport" style="display:block;width:100%;">Transporter</label>
                    </a>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtAgentCode" style="width:120px" />
                    <input type="button" class="btn btn-default" id="btnBrowseAgent" value="..." onclick="SearchData('agent')" />
                    <input type="text" class="form-control" id="txtAgentName" style="width:100%" disabled />
                </div>
            </div>
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblForwarder" style="display:block;width:100%;">Forwarder/Agent</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtForwarderCode" style="width:120px" />
                    <input type="button" class="btn btn-default" id="btnBrowseForw" value="..." onclick="SearchData('forwarder')" />
                    <input type="text" class="form-control" id="txtForwarderName" style="width:100%" disabled />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:50%">
                    <label id="lblInvFCountry" style="display:block;width:100%;">From Country</label>
                    <div style="display:flex;">
                        <input type="text" class="form-control" id="txtInvFCountry" style="width:30%" disabled />
                        <input type="text" class="form-control" id="txtInvFCountryName" style="width:70%" disabled />
                        <input type="button" class="btn btn-default" id="btnBrowseFCountry" value="..." onclick="SearchData('country1')" />
                    </div>
                </div>
                <div style="width:50%">
                    <label id="lblInvCountry" style="display:block;width:100%;">To Country</label>
                    <div style="display:flex;">
                        <input type="text" class="form-control" id="txtInvCountry" style="width:30%" disabled />
                        <input type="text" class="form-control" id="txtInvCountryName" style="width:70%" disabled />
                        <input type="button" class="btn btn-default" id="btnBrowseCountry" value="..." onclick="SearchData('country2')" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <a href="../Master/InterPort">
                    <label id="lblInterPort" style="display:block;width:100%;">International Port</label>
                </a>
                <div style="display:flex;width:100%">
                    <input type="text" class="form-control" id="txtInterPort" style="width:120px" disabled />
                    <input type="text" class="form-control" id="txtInterPortName" style="width:100%" disabled />
                    <input type="button" class="btn btn-default" id="btnBrowsePort" value="..." onclick="SearchData('interport')" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <label id="lblLoadDate" style="display:block;width:100%;">Load Date</label>
                <input type="date" class="form-control" style="width:100%" id="txtLoadDate" />
            </div>
            <div class="col-sm-3">
                <label id="lblETDDate" style="display:block;width:100%;">ETD Date</label>
                <input type="date" class="form-control" style="width:100%" id="txtETDDate" />
            </div>
            <div class="col-sm-3">
                <label id="lblETADate" style="display:block;width:100%;">ETA Date</label>
                <input type="date" class="form-control" style="width:100%" id="txtETADate" />
            </div>
            <div class="col-sm-3">
                <label id="lblDeliveryDate" style="display:block;width:100%;">Delivery Date</label>
                <input type="date" class="form-control" style="width:100%" id="txtEstDeliverDate" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="display:flex">
                <div style="width:30%">
                    <label id="lblCopyFrom" style="display:block;width:100%;">Copy From</label>
                </div>
                <div style="display:flex;width:70%">
                    <input type="text" class="form-control" id="txtCopyFromJob" style="width:100%"/>
                    <input type="button" class="btn btn-default" id="btnBrowseJob" value="..." onclick="SearchData('job')" />
                </div>
            </div>
            <div class="col-sm-6">
                <br />
                <a href="#" class="btn btn-success" id="btnCreateJob" onclick="CreateJob()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b><label id="lblCreateJob">Create Job</label></b>
                </a>
                <input type="checkbox" id="chkConfirm" />Confirm Today
            </div>
        </div>
    </div>
    <div id="frmShowJob" class="modal fade" data-backdrop="static" data-keyboard="false">
        <div class="vertical-alignment-helper">
            <div class="modal-dialog vertical-align-center">
                <div class="modal-content">
                    <div id="dvResp" class="modal-header">
                        <label id="lblSaveComplete">Save Complete!</label>
                    </div>
                    <div class="modal-body" style="text-align:center">
                        <input id="txtJNo" type="text" style="position:center;font-size:20px;text-align:center;color:red" disabled />
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-primary" id="btnViewJobS" onclick="OpenJob()">Edit Job Data</button>
                        <button class="btn btn-warning" id="btnViewJobT" onclick="OpenJobT()">Edit Transport Data</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    //define letiables
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userGroup = '@ViewBag.UserGroup';
    let br = getQueryString('Branch');
    let jt = getQueryString('JType');
    let sb = getQueryString('SBy');
    //$(document).ready(function () {
        if (userGroup == 'C') {
            $('#btnBrowseCust').attr('disabled', 'disabled');
            $('#txtCustCode').attr('disabled', 'disabled');
            $('#txtCustBranch').attr('disabled', 'disabled');
            $('#txtConsignee').attr('disabled', 'disabled');
            $('#btnBrowseCons').attr('disabled', 'disabled');
            
            $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
                if (r.company.data.length > 0) {
                    let dr = r.company.data[0];
                    $('#txtCustCode').val(dr.CustCode);
                    $('#txtCustBranch').val(dr.Branch);
                    $('#txtCustName').val(dr.NameThai);
                    $('#txtConsignee').val(dr.CustCode);
                    $('#txtConsignName').val(dr.NameEng);
                    if (jt=='01') {
                        $('#txtCSCode').val(dr.CSCodeIM);
                        ShowUser(path, dr.CSCodeIM, '#txtCSName');
                    }
                    if (jt=='02') {
                        $('#txtCSCode').val(dr.CSCodeEX);
                        ShowUser(path, dr.CSCodeEX, '#txtCSName');
                    }
                    if (jt>'02') {
                        $('#txtCSCode').val(dr.CSCodeOT);
                        ShowUser(path, dr.CSCodeOT, '#txtCSName');
                    }
                }
            });
        }

        CheckParam();
        SetLOVs();
        SetEvents();
        SetEnterToTab();
    //});
    function CheckJobType() {
        if (jt !== $('#cboJobType').val()) {
            jt = $('#cboJobType').val();
            loadShipByByType(path, jt, '#cboShipBy');
            GetQuotation();
            return;
        }
        GetQuotation();
        return;
    }
    function CheckParam() {
        //read query string parameters
        if (br !== "") {
            $('#txtBranchCode').val(br);
            ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
        //Combos
        let lists = 'JOB_TYPE=#cboJobType|'+jt+',SHIP_BY=#cboShipBy|'+ sb;
        loadCombos(path, lists);

        $('#cboJobType').val(jt);
        $('#cboShipBy').val(sb);
        if (userGroup == 'S') {
            $('#txtCSCode').val(user);
            ShowUser(path, $('#txtCSCode').val(), '#txtCSName');
        }
        $('#txtJobDate').val(GetToday());
    }
    function SetLOVs() {
        //3 Fields Show
        SetListOfValues(function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv,'#frmSearchQuo','#tbQuo','Quotations',response,3);
            //Customers
            CreateLOV(dv,'#frmSearchCust','#tbCust','Customers',response,3);
            //Consignee
            CreateLOV(dv,'#frmSearchCons','#tbCons','Consignees',response,3);
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job List', response, 3);
            //Inter Port
            CreateLOV(dv,'#frmSearchIPort', '#tbIPort','International Port',response,3);

            //2 Fields
            //Country
            CreateLOV(dv,'#frmSearchCountry', '#tbCountry', 'Country', response,2);
            //FCountry
            CreateLOV(dv,'#frmSearchFCountry', '#tbFCountry','Country',response,2);
            //Users
            CreateLOV(dv,'#frmSearchUser','#tbUser','Users',response,2);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            //Agent
            CreateLOV(dv, '#frmSearchAgent', '#tbAgent', 'Agents', response, 3);
            //Transport
            CreateLOV(dv,'#frmSearchForw','#tbForw','Transporter',response,3);
            //1 Fields
            //Contact Name
            CreateLOV(dv,'#frmSearchContact','#tbContact','Contact Person',response,3);
        });
    }
    function SetEvents() {
        $('#txtBranchCode').focusout(function () {
            ShowBranch(path,$('#txtBranchCode').val(), '#txtBranchName');
        });
        $('#txtCSCode').focusout(function () {
            ShowUser(path,$('#txtCSCode').val(), '#txtCSName');
        });
        $('#txtCustCode').keydown(function (e) {
            if (e.which == 13) {
                $('#txtConsignee').val('');
                CallBackQueryCustomerSingle(path, $('#txtCustCode').val(), function (dr) {
                    $('#txtCustBranch').val(dr.Branch);
                    $('#txtCustName').val(dr.NameThai);					
                    $('#txtConsignee').val(dr.BillToCustCode);
					if($('#txtConsignee').val()==''){
						$('#txtConsignee').val(dr.CustCode);
					}
                    ReadCustRelateData();
                });
            }
        });
        $('#txtCustBranch').keydown(function (ev) {
            if (ev.which == 13) {
                ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
            }
        });
        $('#txtConsignee').focusout(function () {
            ShowCompany(path, $('#txtConsignee').val(), '#txtConsignName');
        });
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
                    $('[tabindex="1"]').focus();
                }
            });
        });
        $('#txtBranchCode').focus();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadUser(dt) {
        $('#txtCSCode').val(dt.UserID);
        $('#txtCSName').val(dt.TName);
        $('#txtCSCode').focus();
    }
    function ReadCountry(dt) {
        $('#txtInvCountryName').val(dt.CTYName);
        $('#txtInvCountry').val(dt.CTYCODE);
    }
    function ReadFCountry(dt) {
        $('#txtInvFCountryName').val(dt.CTYName);
        $('#txtInvFCountry').val(dt.CTYCODE);
    }
    function ReadInterPort(dt) {
        $('#txtInterPort').val(dt.PortCode);
        $('#txtInterPortName').val(dt.PortName);
    }

    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
        //if (dt.BillToCustCode !== '') {
        //    $('#txtConsignee').val(dt.BillToCustCode);            
        //} else {
        $('#txtConsignee').val(dt.CustCode);            
        //}
        ShowCompany(path, $('#txtConsignee').val(), '#txtConsignName');  
        ReadCustRelateData();
        $('#txtCustInv').focus();
    }
    function ReadCustRelateData() {
        //$('#txtContactPerson').val('');
        $('#txtQNo').val('');
        $('#txtRevise').val('');
        $('#txtManagerCode').val('');      
        GetContact();
        GetQuotation();
    }
    function ReadAgent(dt) {
        $('#txtAgentCode').val(dt.VenCode);
        $('#txtAgentName').val(dt.TName);
    }
    function ReadForwarder(dt) {
        $('#txtForwarderCode').val(dt.VenCode);
        $('#txtForwarderName').val(dt.TName);
    }
    function ReadConsignee(dt) {
        $('#txtConsignee').val(dt.CustCode);
        $('#txtConsBranch').val(dt.Branch);
        ShowCustomer(path,dt.CustCode, dt.Branch, '#txtConsignName');
        $('#txtConsignee').focus();
    }
    function ReadContactName(dt) {
        $('#txtContactPerson').val(dt.ContactName);
        $('#txtContactPerson').focus();
    }
    function ReadJob(dr) {
        $('#txtCopyFromJob').val(dr.JNo);
        $('#txtCSCode').val(dr.CSCode);
        $('#txtJobDate').val(CDateEN(dr.DocDate));
        $('#txtConsignee').val(dr.Consigneecode);
        $('#txtContactPerson').val(dr.CustContactName);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtDutyDate').val(CDateEN(dr.DutyDate));
        $('#txtQNo').val(dr.QNo);
        $('#txtRevise').val(dr.Revise);
        $('#txtCustInv').val(dr.InvNo);
        $('#txtCustPO').val(dr.CustRefNO);
        $('#txtVesselName').val(dr.VesselName);
        $('#txtHAWB').val(dr.HAWB);
        $('#txtMAWB').val(dr.MAWB);
        $('#txtManagerCode').val(dr.ManagerCode);
        $('#txtAgentCode').val(dr.AgentCode);
        $('#txtForwarderCode').val(dr.ForwarderCode);
        $('#txtLoadDate').val(CDateEN(dr.LoadDate));
        $('#txtETDDate').val(CDateEN(dr.ETDDate));
        $('#txtETADate').val(CDateEN(dr.ETADate));
        $('#txtEstDeliverDate').val(CDateEN(dr.EstDeliverDate));
    }
    function ReadQuo(dt) {
        $('#txtQNo').val(dt.QNo);
        $('#txtRevise').val(dt.SeqNo);
        $('#txtManagerCode').val(dt.ManagerCode);
        $('#txtContactPerson').val(dt.ContactName);

    }
    function SearchData(type) {
        switch (type) {
            case 'agent':
                SetGridVender(path, '#tbAgent', '#frmSearchAgent', ReadAgent);
                break;
            case 'forwarder':
                SetGridVender(path, '#tbForw', '#frmSearchForw', ReadForwarder);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'user':
                SetGridUser(path, '#tbUser', '#frmSearchUser', ReadUser);
                break;
            case 'customer':
                SetGridCompanyByGroup(path, '#tbCust','CUSTOMERS,INTERNAL,PERSON', '#frmSearchCust', ReadCustomer);
                break;
            case 'consignee':
                SetGridCompanyByGroup(path, '#tbCons','CONSIGNEE' ,'#frmSearchCons', ReadConsignee);
                break;
            case 'contact':
                let w = '?Branch=' + $('#txtCustBranch').val() + '&Code=' + $('#txtCustCode').val();
                SetGridCustContact(path, '#tbContact', w,'#frmSearchContact', ReadContactName);
                break;
            case 'interport':
                let CountryID = $('#cboJobType').val() == "01" ? $('#txtInvFCountry').val() : $('#txtInvCountry').val();
                SetGridInterPort(path, '#tbIPort', '#frmSearchIPort', CountryID, ReadInterPort);
                break;
            case 'country2':
                SetGridCountry(path, '#tbCountry', '#frmSearchCountry', ReadCountry);
                break;
            case 'country1':
                SetGridCountry(path, '#tbFCountry', '#frmSearchFCountry', ReadFCountry);
                break;
            case 'job':
                SetGridJob(path, '#tbJob', '#frmSearchJob', GetParam() , ReadJob);
                break;
            case 'quotation':
                let branch = $('#txtBranchCode').val();
                let cust = $('#txtCustCode').val();
                let jtype = $('#cboJobType').val();
                let sby = $('#cboShipBy').val();        
                SetGridQuotationDesc(path, '#tbQuo', '?branch=' + branch + '&cust=' + cust + '&jtype=' + jtype + '&sby=' + sby + '&status=1', '#frmSearchQuo', ReadQuo);
                break;
        }
    }
    function GetParam() {
        let strParam = '?';
        strParam += 'Branch=' + $('#txtBranchCode').val();
        //strParam += '&JType=' + $('#cboJobType').val().substr(0, 2);
        //strParam += '&SBy=' + $('#cboShipBy').val().substr(0, 2);
        strParam += '&CustCode=' + $('#txtCustCode').val();
        return strParam;
    }
    function GetContact() {
        let cust = $('#txtCustCode').val();
        $.get(path + 'Master/GetCompanyContact?code=' + cust)
            .done(function (r) {
                if (r.companycontact.data.length > 0) {
                    $('#txtContactPerson').val(r.companycontact.data[0].ContactName);
                }
            });
    }
    function GetQuotation() {
        let branch = $('#txtBranchCode').val();
        //let cust = $('#txtCustCode').val(); //Get From Customer
        let cust = $('#txtConsignee').val(); //Get From Consignee for ANT Global
        let jtype = $('#cboJobType').val();
        let sby = $('#cboShipBy').val();
        $('#txtQNo').val('');
        $('#txtRevise').val('');
        $('#txtManagerCode').val('');
        $.get(path + 'JobOrder/GetQuotationGrid?branch=' + branch + '&cust=' + cust + '&jtype=' + jtype + '&sby=' + sby + '&status=1')
            .done(function (r) {
                if (r.quotation.data.length > 0) {
                    if (r.quotation.data[0].QNo !== null) {
                        $('#txtQNo').val(r.quotation.data[0].QNo);
                        $('#txtRevise').val(r.quotation.data[0].SeqNo);
                        $('#txtManagerCode').val(r.quotation.data[0].ManagerCode);
					    $('#txtContactPerson').val(r.quotation.data[0].ContactName);
                    }
                }
            });
    }
    function CreateJob() {
        if ($('#txtBranchName').val() === '') {
            ShowMessage('Please input branch',true);
            $('#txtBranchCode').focus();
            return;
        }
        if ($('#cboJobType').val() === '') {
            ShowMessage('Please select job type',true);
            $('#cboJobType').focus();
            return;
        }
        if ($('#cboShipBy').val() === '') {
            ShowMessage('Please select ship by',true);
            $('#cboShipBy').focus();
            return;
        }
        if ($('#txtCSName').val() === '') {
            ShowMessage('Please select staff',true);
            $('#txtCSCode').focus();
            return;
        }
        if ($('#txtCustName').val() === '') {
            ShowMessage('Please choose customer first',true);
            $('#txtCustCode').focus();
            return;
        }
        if ($('#txtCustInv').val() === '' && $('#txtBookingNo').val()==='') {
            ShowMessage('Please input invoice/booking',true);
            $('#txtCustInv').focus();
            return;
        }
        //if pass every checked
        
        let strParam = path + 'JobOrder/GetNewJob?';
        strParam += 'Branch=' + $('#txtBranchCode').val();
        strParam += '&JType=' + $('#cboJobType').val().substr(0,2);
        strParam += '&SBy=' + $('#cboShipBy').val().substr(0, 2);
        if ($('#txtCopyFromJob').val() !== '') {
            strParam += '&CopyFrom=' + $('#txtCopyFromJob').val();
        }
        strParam += '&Cust=' + $('#txtCustCode').val() + '|' + $('#txtCustBranch').val();
        strParam += '&Inv=' + $('#txtCustInv').val();
        $.get(strParam)
            .done(function (r) {
                if (r.length == 0) {
                    ShowMessage(strParam,true);
                    return;
                }
                $('#btnCreateJob').attr('disabled', 'disabled');
                if (r.job.status == "Y") {
                    let data = GetDataSave(r.job.data[0]);
                    data.JobType = $('#cboJobType').val();
                    data.ShipBy = $('#cboShipBy').val();
                    SaveData(data);
                } else {
                    ShowMessage(r.job.result, true);
                    $('#btnCreateJob').removeAttr('disabled');
                }
                return;
                //ShowMessage(r.job.result + '=>' + data.JNo);
            });
    }
    function GetDataSave(dr) {
        dr.BranchCode = $('#txtBranchCode').val();
        dr.JNo = '';
        dr.CustCode = $('#txtCustCode').val();
        dr.CustBranch = $('#txtCustBranch').val();
        dr.CSCode = $('#txtCSCode').val();
        dr.DocDate = CDateEN($('#txtJobDate').val());
        dr.Consigneecode = $('#txtConsignee').val();
        dr.CustContactName = $('#txtContactPerson').val();
        dr.BookingNo = $('#txtBookingNo').val();
        dr.DutyDate = CDateEN($('#txtDutyDate').val());
        dr.QNo = $('#txtQNo').val();
        dr.JRevise = 1;
        dr.Revise = CNum($('#txtRevise').val());
        dr.InvNo = $('#txtCustInv').val() === '' ? $('#txtBookingNo').val() : $('#txtCustInv').val();
        dr.CustRefNO = $('#txtCustPO').val();
        dr.HAWB = $('#txtHAWB').val();
        dr.MAWB = $('#txtMAWB').val();
        dr.VesselName = $('#txtVesselName').val();
        dr.ManagerCode = $('#txtManagerCode').val();
        dr.AgentCode = $('#txtAgentCode').val();
        dr.ForwarderCode = $('#txtForwarderCode').val();
        dr.LoadDate = CDateEN($('#txtLoadDate').val());
        dr.ETDDate = CDateEN($('#txtETDDate').val());
        dr.ETADate = CDateEN($('#txtETADate').val());
        dr.EstDeliverDate = CDateEN($('#txtEstDeliverDate').val());
        if ($('#chkConfirm').prop('checked')) {
            dr.ConfirmDate = CDateEN(GetToday());
        } else {
            dr.ConfirmDate="0001-01-01T00:00:00"
        }
        dr.InvCountry = CStr($('#txtInvCountry').val());
        dr.InvFCountry = CStr($('#txtInvFCountry').val());
        dr.InvInterPort=CStr($('#txtInterPort').val());

        //--- Default Values 
        dr.DeclareNumber=CStr(dr.DeclareNumber);
        dr.Commission=0
        dr.TRemark = CStr(dr.TRemark);
        dr.CloseJobDate = CDateEN(dr.CloseJobDate);
        dr.Description = CStr(dr.Description);
        dr.CancelDate = "0001-01-01T00:00:00";
        dr.CancelReson="";
        dr.ProjectName=CStr(dr.ProjectName);
        dr.InvProduct=CStr(dr.InvProduct);
        dr.InvProductQty = CNum(dr.InvProductQty);
        dr.InvProductUnit=CStr(dr.InvProductUnit);
        dr.TotalQty = CNum(dr.TotalQty);
        dr.InvTotal = CNum(dr.InvTotal);
        dr.Measurement=CStr(dr.Measurement);
        dr.TotalNW = CNum(dr.TotalNW);
        dr.TotalGW = CNum(dr.TotalGW);
        dr.GWUnit=CStr(dr.GWUnit);
        dr.InvCurUnit=CStr(dr.InvCurUnit);
        dr.InvCurRate = CNum(dr.InvCurRate);

        dr.BLNo=CStr(dr.BLNo);

        dr.MVesselName = CStr(dr.MVesselName);

        dr.TotalContainer = CStr(dr.TotalContainer);

        dr.ImExDate = "0001-01-01T00:00:00";
        dr.ReadyToClearDate = "0001-01-01T00:00:00";


        dr.ClearDate = "0001-01-01T00:00:00";
        dr.ClearPort = CStr(dr.ClearPort);
        dr.ClearPortNo = CStr(dr.ClearPortNo);

        dr.ShippingEmp=CStr(dr.ShippingEmp);
        dr.ShippingCmd=CStr(dr.ShippingCmd);

        dr.DutyAmount = 0;
        dr.DutyLtdPayChqAmt = 0;
        dr.DutyLtdPayCashAmt = 0;
        dr.DutyLtdPayEPAYAmt = 0;
        dr.DutyLtdPayOtherAmt = 0;
        dr.DutyLtdPayOther = 0;

        dr.DutyCustPayChqAmt =0;
        dr.DutyCustPayCashAmt = 0;
        dr.DutyCustPayCardAmt = 0;
        dr.DutyCustPayBankAmt = 0;
        dr.DutyCustPayEPAYAmt = 0;
        dr.DutyCustPayOtherAmt = 0;
        dr.DutyCustPayOther = 0;

        dr.TSRequest = 0;
        dr.DeclareType = CStr(dr.DeclareType);
        dr.DeclareStatus = 0;
        dr.TyAuthorSp = 0;
        dr.Ty19BIS=0;
        dr.TyClearTax=0;
        dr.TyClearTaxReson = '';

        dr.DeliveryNo = '';
        dr.DeliveryTo = CStr(dr.DeliveryTo);
        dr.DeliveryAddr = CStr(dr.DeliveryAddr);
        return dr;
    }
    function OpenJob() {
        window.location.href='ShowJob?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val();
    }
    function OpenJobT() {
        window.location.href = 'Transport?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val();
    }
    function SaveData(obj) {
        
        let jsonText = JSON.stringify({ data: obj });
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetJobData", "JobOrder")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (r) {
                $('#txtJNo').val(r.result);
                $('#dvResp').html(r.msg);
                $('#frmShowJob').modal('show');
                $('#btnCreateJob').removeAttr('disabled');
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function CopyFromBooking() {
        $('#txtHAWB').val($('#txtBookingNo').val());
    }
    function CopyFromHouseBL() {
        $('#txtMAWB').val($('#txtHAWB').val());
    }
</script>

