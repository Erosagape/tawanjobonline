@Code
    ViewBag.Title = "Customers"
End Code
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <label id="lblCustCode">Customer Code:</label>
                <br />
                <input type="text" id="txtCustCode" class="form-control" tabIndex="0" value="" />
            </div>
            <div class="col-sm-3">
                <label id="lblBranch">Branch :</label>
                <br /><input type="text" id="txtBranch" class="form-control" tabIndex="1">
            </div>
            <div class="col-sm-3">
                <label id="lblCustGroup">Customer Group :</label>
                <br />
                <select id="txtCustGroup" class="form-control dropdown" tabIndex="2"></select>
            </div>
            <div class="col-sm-3">
                <label id="lblTaxNumber">Tax-Reference :</label>
                <br /><input type="text" id="txtTaxNumber" class="form-control" tabIndex="3">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <label id="lblCustTitle">Title :</label>
                <br />
                <select id="txtTitle" class="form-control dropdown" tabIndex="4">
                    <option value=""></option>
                    <option value="บริษัท">บริษัท</option>
                    <option value="ห้างหุ้นส่วน">ห้างหุ้นส่วน</option>
                    <option value="นาย">นาย</option>
                    <option value="นาง">นาง</option>
                    <option value="นางสาว">นางสาว</option>
                </select>
            </div>
            <div class="col-sm-5">
                <label id="lblNameThai">Name (TH) :</label>
                <br /><input type="text" id="txtNameThai" class="form-control" tabIndex="5">
            </div>
            <div class="col-sm-5">
                <label id="lblNameEng" onclick="CopyName()">English :</label>
                <br /><input type="text" id="txtNameEng" class="form-control" tabIndex="6">
            </div>
        </div>
        <ul class="nav nav-tabs">
            <li class="active"><a id="linkTab1" data-toggle="tab" href="#tabCust2">Billing</a></li>
            <li><a id="linkTab2" data-toggle="tab" href="#tabCust1">Addresses</a></li>
            <li><a id="linkTab3" data-toggle="tab" href="#tabCust3">Configuration</a></li>
        </ul>
        <div class="tab-content">
            <div id="tabCust1" class="tab-pane">
                <div class="row">
                    <div class="col-sm-6">
                        <label id="lblTAddress1">Address (TH) :</label>
                        <br />
                        @*<input type="text" id="txtTAddress1" class="form-control" tabIndex="7">*@
                        <div style="display: flex">
                            <input type="text" id="txtTAddress1" Class="form-control" tabIndex="7">
                            <button type="button" class="btn btn-default open-modal-btn" data-target-textarea="txtTAddress1">...</button>
                        </div>
                        <br /><input type="text" id="txtTAddress2" class="form-control" tabIndex="8">
                    </div>
                    <div class="col-sm-6">
                        <label id="lblEAddress1">Address (EN) :</label>
                        <br /><textarea id="txtEAddress1" class="form-control" tabIndex="9"></textarea>
                        <br /><textarea id="txtEAddress2" class="form-control" tabIndex="10"></textarea>
                    </div>
                </div>
                @*-------------*@

                <div class="modal fade" id="frmAddress">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="frmAddressLabel"><label>กรอกข้อมูลที่อยู่</label></h4>
                                @*<button type="button" class="btn btn-info mt-2" id="toggleLanguageBtn">สลับภาษา: ไทย</button>*@
                            </div>
                            <div class="modal-body">
                                <div style="display:flex;flex-wrap:wrap;">
                                    <div style="flex:1">
                                        <label id="lblAddNo">Add No:</label> @*#31  เลขที่*@
                                        <br />
                                        <input type="text" id="txtAddNo" class="form-control" placeholder="เลขที่ (Address No)" maxlength="20">
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblMooNo">Moo No:</label> @*#32 หมู่ที่*@
                                        <br />
                                        <input type="text" id="txtMooNo" class="form-control" placeholder="หมู่ที่ (Moo No)" maxlength="20">
                                    </div>
                                </div>
                                <div style="display:flex;flex-wrap:wrap;">
                                    <div style="flex:1">
                                        <label id="lblBuild">Build Name:</label> @*#27 ชื่ออาคาร*@
                                        <br />
                                        <input type="text" id="txtBuild" class="form-control" placeholder="อาคาร (Building)" maxlength="40">
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblFloorNo">Floor No:</label> @*#29 ชั้นที่*@
                                        <br />
                                        <input type="text" id="txtFloorNo" class="form-control" placeholder="ชั้นที่ (Floor No)" maxlength="20">
                                    </div>
                                </div>
                                <div style="display:flex;flex-wrap:wrap;">
                                    <div style="flex:1">
                                        <label id="lblRoomNo">Room No:</label> @*#28 ห้องเลขที่*@
                                        <br />
                                        <input type="text" id="txtRoomNo" class="form-control" placeholder="ห้องเลขที่ (Room No)" maxlength="20">
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblVillage">Village Name:</label> @*#30 หมู่บ้าน *@
                                        <br />
                                        <input type="text" id="txtVillage" class="form-control" placeholder="หมู่บ้าน (Village)" maxlength="100">
                                    </div>
                                </div>
                                <div style="display:flex;flex-wrap:wrap;">
                                    <div style="flex:1">
                                        <label id="lblSoi">Soi:</label> @*#33 ตรอก/ซอย*@
                                        <br />
                                        <input type="text" id="txtSoi" class="form-control" placeholder="ตรอก/ซอย (Soi)" maxlength="100">
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblStreetName">Street Name:</label> @*#34 ถนน*@
                                        <br />
                                        <input type="text" id="txtStreetName" class="form-control" placeholder="ถนน (Street)" maxlength="100">
                                    </div>
                                </div>
                                <div style="display:flex;flex-wrap:wrap;">
                                    <div style="flex:1">
                                        <label id="lblSubDistrict">Sub District:</label> @*35 ตำบล/แขวง*@
                                        <br />
                                        <div style="display:flex">
                                            <input type="text" id="txtSubDistrict" class="form-control" placeholder="ตำบล/แขวง (Sub-District)" maxlength="50">
                                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('subdistrict')" />
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblDistrict">District:</label> @*#36 อำเภอ/เขต*@
                                        <br />
                                        <input type="text" id="txtDistrict" class="form-control" placeholder="อำเภอ/เขต (District)" maxlength="50">

                                    </div>

                                </div>
                                <div style="display:flex;flex-wrap:wrap;">

                                    <div style="flex:1">
                                        <label id="lblProvince">Province:</label> @*#37 จังหวัด*@
                                        <br />
                                        <div style="display:flex">
                                            <input type="text" id="txtTProvince" class="form-control" style="width: 20%; display:none" tabIndex="29">
                                            <input type="text" id="txtProvince" class="form-control" placeholder="จังหวัด (Province)">
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblPostcode">Postcode:</label> @*#38
                                        *@
                                        <br />
                                        <input type="text" id="txtPostcode" class="form-control" placeholder="รหัสไปรษณีย์ (Postcode)" maxlength="5">
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div style="float:left">
                                    <a href="#" class="btn btn-success" id="btnUpdateAddress">
                                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveAddress">Save</b>
                                    </a>
                                    @*<a href="#" class="btn btn-danger" id="btnDelAddress">
                                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelAddress">Delete</b>
                            </a>*@
                                </div>
                                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                            </div>
                        </div>
                    </div>
                </div>

                @*-------------*@
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblPhone">Phone :</label>
                        <br /><input type="text" id="txtPhone" class="form-control" tabIndex="11">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblFaxNumber">Fax :</label>
                        <br /><input type="text" id="txtFaxNumber" class="form-control" tabIndex="12">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblDMailAddress">EMail :</label>
                        <br /><input type="text" id="txtDMailAddress" class="form-control" tabIndex="13">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblWEB_SITE">WEB :</label>
                        <br /><input type="text" id="txtWEB_SITE" class="form-control" tabIndex="14">
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblUsedLanguage">Language :</label>
                        <br /><select id="txtUsedLanguage" class="form-control dropdown" tabIndex="15"></select>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblCustType">Customer Type :</label>
                        <br />
                        <select id="txtCustType" class="form-control dropdown" tabIndex="16"></select>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblLevelGrade">Grade/Level :</label>
                        <br /><input type="text" id="txtLevelGrade" class="form-control" tabIndex="17">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblTermOfPayment">Payment Term :</label>
                        <br /><input type="text" id="txtTermOfPayment" class="form-control" tabIndex="18" value="0">
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblBillCondition">Billing Condition :</label>
                        <br /><input type="text" id="txtBillCondition" class="form-control" tabIndex="19">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblCreditLimit">Credit Limit :</label>
                        <br /><input type="text" id="txtCreditLimit" class="form-control" tabIndex="20" value="0.00">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblDutyLimit">Duty Limit :</label>
                        <br /><input type="text" id="txtDutyLimit" class="form-control" tabIndex="21" value="0.00">
                    </div>
                    <div class="col-sm-3">
                        <label id="lblCommRate">Commission Rate :</label>
                        <br /><input type="text" id="txtCommRate" class="form-control" tabIndex="22" value="0.00">
                    </div>
                </div>
            </div>
            <div id="tabCust2" class="tab-pane fade in active">
                <div class="row">
                    <div class="col-sm-6">
                        <label id="lblGLAccountCode">GL Code :</label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtGLAccountCode" class="form-control" style="width:20%" tabIndex="23">
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('acccode')" />
                            <input type="text" id="txtGLAccountName" class="form-control" style="width:100%" disabled>
                        </div>
                        <label id="lblBillToCustCode">Billing To:</label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtBillToCustCode" style="width:40%" class="form-control" tabIndex="24">
                            <input type="text" id="txtBillToBranch" style="width:20%" class="form-control" tabIndex="25">
                            <input type="button" value="..." class="btn btn-default" onclick="SearchData('billing')" />
                            <button id="btnSetBilling" class="btn btn-primary" onclick="SetBilling()">Same as Company</button>
                        </div>
                        <label id="lblBillToCustName">Billing Name :</label>
                        <input type="text" id="txtBillToCustName" class="form-control" disabled />
                        <label id="lblBillToAddress">Billing Address :</label>
                        <textarea id="txtBillToAddress" class="form-control" disabled></textarea>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblTAddress">BLDG No/Street :</label>
                        <br />
                        <input type="text" id="txtTAddress" class="form-control" tabIndex="26">
                        <label id="lblTDistrict">District :</label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtTDistrict" class="form-control" style="width:100%" tabIndex="27">
                            <input type="button" class="btn btn-default" value="..." onclick="SearchData('subdistrict')" />
                        </div>
                        <label id="lblTSubProvince">Sub District :</label>
                        <br />
                        <input type="text" id="txtTSubProvince" class="form-control" tabIndex="28">
                        <label id="lblTProvince">Province :</label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtTProvince" class="form-control" style="width:20%" tabIndex="29">
                            <input type="text" id="txtTProvinceName" class="form-control" style="width:80%" disabled>
                        </div>
                        <label id="lblTPostCode">PostCode :</label>
                        <br />
                        <div style="display:flex">
                            <input type="text" id="txtTPostCode" style="width:20%" class="form-control" tabIndex="30">
                            <button id="btnSetAddress" class="btn btn-primary" onclick="SetAddress()">Set Full Address</button> &nbsp;
                            <button id="btnSetContact" class="btn btn-warning" onclick="AddContact()">Set Contact Person</button>
                        </div>
                    </div>
                </div>

            </div>
            <div id="tabCust3" class="tab-pane fade">
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblManagerCode">Sales:</label>
                        <br />
                        <div style="display:flex">
                            <div style="flex:1">
                                <input type="text" id="txtManagerCode" class="form-control" tabIndex="31">
                            </div>
                            <div>
                                <input type="button" value="..." class="btn btn-default" onclick="SearchData('sales')" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblCSCodeIM">CS Import :</label>
                        <br />
                        <div style="display:flex">
                            <div style="flex:1">
                                <input type="text" id="txtCSCodeIM" class="form-control" tabIndex="32">
                            </div>
                            <div>
                                <input type="button" value="..." class="btn btn-default" onclick="SearchData('csimport')" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblCSCodeEX">CS Export :</label>
                        <br />
                        <div style="display:flex">
                            <div style="flex:1">
                                <input type="text" id="txtCSCodeEX" class="form-control" tabIndex="33">
                            </div>
                            <div>
                                <input type="button" value="..." class="btn btn-default" onclick="SearchData('csexport')" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <label id="lblCSCodeOT">CS Others :</label>
                        <br />
                        <div style="display:flex">
                            <div style="flex:1">
                                <input type="text" id="txtCSCodeOT" class="form-control" tabIndex="34">
                            </div>
                            <div>
                                <input type="button" value="..." class="btn btn-default" onclick="SearchData('csother')" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <label id="lblConsStatus">Consign Status :</label>
                        <br /><input type="text" id="txtConsStatus" class="form-control" disabled />
                        <br /><select id="cboCompanyType" class="form-control" style="height:300px" multiple></select>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblCommLevel">Commercial Level :</label>
                        <br /><input type="text" id="txtCommLevel" class="form-control" disabled />
                        <br /><select id="cboCommLevel" class="form-control"></select>
                        <br />
                        Tracking Authorized : <br />
                        <div style="display:flex">
                            <label id="lblLoginName" style="display:block;width:250px">Log in : </label><input type="text" id="txtLoginName" class="form-control">
                            <label id="lblLoginPassword" style="display:block;width:250px">Password : </label><input type="password" id="txtLoginPassword" class="form-control">
                        </div>
                        <br />
                        SAP Customer ID:<br />
                        <input type="text" id="txtLnNO" />
                    </div>
                </div>
            </div>
        </div>
        <div id="dvCommand">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">New</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
            </a>
            <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
            </a>
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('customer')">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
        </div>
        <div id="dvLOVs"></div>
        <div id="dvHidden" style="display:none">
            <input type="hidden" id="txtMapText" class="form-control">
            <input type="hidden" id="txtMapFileName" class="form-control">
            <input type="hidden" id="txtCmpType" class="form-control">
            <input type="hidden" id="txtCmpLevelExp" class="form-control">
            <input type="hidden" id="txtCmpLevelImp" class="form-control">
            <input type="hidden" id="txtIs19bis" class="form-control" value="0">
            <input type="hidden" id="txtMgrSeq" class="form-control" value="0">
            <input type="hidden" id="txtLevelNoExp" class="form-control" value="0">
            <input type="hidden" id="txtLevelNoImp" class="form-control" value="0">

            <input type="hidden" id="txtAdjTaxCode" class="form-control">
            <input type="hidden" id="txtBkAuthorNo" class="form-control">
            <input type="hidden" id="txtBkAuthorCnn" class="form-control">
            <input type="hidden" id="txtLtdPsWkName" class="form-control">
            <input type="hidden" id="txtPrivilegeOption" class="form-control">
            <input type="hidden" id="txtGoldCardNO" class="form-control" value="0">
            <input type="hidden" id="txtCustomsBrokerSeq" class="form-control" value="0">
            <input type="hidden" id="txtISCustomerSign" class="form-control" value="0">
            <input type="hidden" id="txtISCustomerSignInv" class="form-control" value="0">
            <input type="hidden" id="txtISCustomerSignDec" class="form-control" value="0">
            <input type="hidden" id="txtISCustomerSignECon" class="form-control" value="0">
            <input type="hidden" id="txtIsShippingCannotSign" class="form-control" value="0">
            <input type="hidden" id="txtExportCode" class="form-control">
            <input type="hidden" id="txtCode19BIS" class="form-control">
        </div>
    </div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let userGroup = '@ViewBag.UserGroup';
    let mode = getQueryString("Mode");
    let user = '@ViewBag.User';
    if (userGroup !== 'S') {
        $('#btnSearch').attr('disabled', 'disabled');
    }
    //$(document).ready(function () {
    SetLOVs();
    SetEvents();
    SetEnterToTab();
    ClearData();
    $('#txtCustCode').focus();
    //});
    function SetEvents() {
        $('#txtBranch').keydown(function (event) {
            if (event.which == 13) {
                let code = $('#txtCustCode').val();
                let branch = $('#txtBranch').val();
                ClearData();
                $('#txtCustCode').val(code);
                $('#txtBranch').val(branch);
                CallBackQueryCustomer(path,code ,branch, ReadCustomer);
            }
        });
        $('#txtCustCode').keydown(function (event) {
            if (event.which == 13) {
                if (userGroup == 'S') {
                    let code = $('#txtCustCode').val();
                    ClearData();
                    $('#txtCustCode').val(code);
                    CallBackQueryCustomerSingle(path, $('#txtCustCode').val(), ReadCustomer);
                }
            }
        });
        $('#txtBillToBranch').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBillToCustName').val('');
                $('#txtBillToAddress').val('');
                CallBackQueryCustomer(path, $('#txtBillToCustCode').val(), $('#txtBillToBranch').val(), ReadBilling);
            }
        });
        $('#txtGLAccountCode').change(function () {
            ShowAccount(path, $('#txtGLAccountCode').val(), '#txtGLAccountName');
        });
        $('#txtTProvince').change(function () {
            CallBackQueryProvince(path, $('#txtTProvince').val(), ShowProvince);
        });
        $('#cboCommLevel').change(function () {
            var data = $(this).val();
            $('#txtCommLevel').val(data);
        });
        $('#cboCompanyType').change(function () {
            var data = $(this).val();
            var val = data.length>1? data.join(","): data[0];

            $('#txtConsStatus').val(val);
        });
    }
    function SetEnterToTab() {
        //Set enter to tab
        $("input[tabindex], select[tabindex], textarea[tabindex]").each(function () {
            $(this).on("keypress", function (e) {
                if (e.keyCode === 13) {
                    var idx = (this.tabIndex + 1);
                    var nextElement = $('[tabindex="' + idx + '"]');
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
    function SetLOVs() {
        //prepare searching data grid
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (res) {
            var dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', res, 3);
            CreateLOV(dv, '#frmSearchBill', '#tbBill', 'Billing Place', res, 3);
            CreateLOV(dv, '#frmSearchSales', '#tbSales', 'Staffs', res, 2);
            CreateLOV(dv, '#frmSearchCSIM', '#tbCSI', 'Staffs', res, 2);
            CreateLOV(dv, '#frmSearchCSEX', '#tbCSE', 'Staffs', res, 2);
            CreateLOV(dv, '#frmSearchCSOT', '#tbCSO', 'Staffs', res, 2);
            CreateLOV(dv, '#frmSearchAcc', '#tbAcc', 'Account Codes', res, 2);
            CreateLOV(dv, '#frmSearchProvince', '#tbProvince', 'Province/District/Sub District',res, 3);
        });
        //load configuration data
        if (mode == '') {
            mode = 'CUSTOMERS';
            if (userGroup == 'C') {
                $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
                    if (r.company.data.length > 0) {
                        let dr = r.company.data[0];
                        $('#txtCustCode').attr('disabled','disabled');
                        $('#txtBranch').attr('disabled','disabled');
                        ReadCustomer(dr);
                    }
                });
            }
        } else {
            $('#txtCustGroup').attr('disabled', 'disabled');
        }
        var lists = "CUSTOMER_GROUP=#txtCustGroup|" + mode;
        lists += ",CUSTOMER_TYPE=#txtCustType|0";
        lists += ",COMPANY_TYPE=#cboCompanyType";
        lists += ",COMMERCIAL_LEVEL=#cboCommLevel";

        loadCombos(path, lists);
        loadLang('#txtUsedLanguage');
    }
    function SearchData(type) {
        switch (type) {
            case 'acccode':
                SetGridAccountCode(path, '#tbAcc', '#frmSearchAcc','', ReadAccountCode);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust','#frmSearchCust', ReadCustomer);
                break;
            case 'billing':
                SetGridCompany(path, '#tbBill', '#frmSearchBill' ,ReadBilling);
                break;
            case 'sales':
                SetGridUser(path, '#tbSales', '#frmSearchSales',ReadSales);
                break;
            case 'csimport':
                SetGridUser(path, '#tbCSI','#frmSearchCSIM', ReadCSImp);
                break;
            case 'csexport':
                SetGridUser(path, '#tbCSE', '#frmSearchCSEX', ReadCSExp);
                break;
            case 'csother':
                SetGridUser(path, '#tbCSO', '#frmSearchCSOT',ReadCSOth);
                break;
            case 'subdistrict':
                SetGridProvinceSub(path, '#tbProvince', '#frmSearchProvince', '', ReadProvince);
                break;
        }
    }
    function ShowProvince(dr) {
        $('#txtTProvinceName').val(dr.ProvinceName);
    }
    function ReadAccountCode(dr) {
        $('#txtGLAccountCode').val(dr.AccCode);
        $('#txtGLAccountName').val(dr.AccTName);
    }
    function ReadProvince(dr) {
        $('#txtTProvince').val(dr.ProvinceCode);
        $('#txtTProvince').change();
        $('#txtTPostCode').val(dr.PostCode);
        $('#txtTDistrict').val(dr.District);
        $('#txtTSubProvince').val(dr.SubProvince);
    }
    function ReadCustomer(dr) {
        if (dr.CustCode != undefined) {
            $('#txtCustCode').val(dr.CustCode);
            $('#txtBranch').val(dr.Branch);
            $('#txtCustGroup').val(dr.CustGroup);
            $('#txtTaxNumber').val(dr.TaxNumber);
            $('#txtTitle').val(dr.Title);
            $('#txtNameThai').val(dr.NameThai);
            $('#txtNameEng').val(dr.NameEng);
            $('#txtTAddress1').val(dr.TAddress1);
            $('#txtTAddress2').val(dr.TAddress2);
            $('#txtEAddress1').val(dr.EAddress1);
            $('#txtEAddress2').val(dr.EAddress2);
            $('#txtPhone').val(dr.Phone);
            $('#txtFaxNumber').val(dr.FaxNumber);
            $('#txtLoginName').val(dr.LoginName);
            $('#txtLoginPassword').val(dr.LoginPassword);
            $('#txtManagerCode').val(dr.ManagerCode);
            $('#txtCSCodeIM').val(dr.CSCodeIM);
            $('#txtCSCodeEX').val(dr.CSCodeEX);
            $('#txtCSCodeOT').val(dr.CSCodeOT);
            $('#txtGLAccountCode').val(dr.GLAccountCode);
            ShowAccount(path, dr.GLAccountCode, '#txtGLAccountName');
            $('#txtCustType').val(dr.CustType);
            $('#txtBillToCustCode').val(dr.BillToCustCode);
            $('#txtBillToBranch').val(dr.BillToBranch);

            $('#txtBillToCustName').val('');
            $('#txtBillToAddress').val('');

            CallBackQueryCustomer(path, dr.BillToCustCode, dr.BillToBranch, ReadBilling);

            $('#txtUsedLanguage').val(dr.UsedLanguage);
            $('#txtLevelGrade').val(dr.LevelGrade);
            $('#txtTermOfPayment').val(dr.TermOfPayment);
            $('#txtBillCondition').val(dr.BillCondition);
            $('#txtCreditLimit').val(dr.CreditLimit);
            $('#txtMapText').val(dr.MapText);
            $('#txtMapFileName').val(dr.MapFileName);
            $('#txtCmpType').val(dr.CmpType);
            $('#txtCmpLevelExp').val(dr.CmpLevelExp);
            $('#txtCmpLevelImp').val(dr.CmpLevelImp);
            $('#txtIs19bis').val(dr.Is19bis);
            $('#txtMgrSeq').val(dr.MgrSeq);
            $('#txtLevelNoExp').val(dr.LevelNoExp);
            $('#txtLevelNoImp').val(dr.LevelNoImp);
            $('#txtLnNO').val(dr.LnNO);
            $('#txtAdjTaxCode').val(dr.AdjTaxCode);
            $('#txtBkAuthorNo').val(dr.BkAuthorNo);
            $('#txtBkAuthorCnn').val(dr.BkAuthorCnn);
            $('#txtLtdPsWkName').val(dr.LtdPsWkName);
            $('#txtDutyLimit').val(dr.DutyLimit);
            $('#txtCommRate').val(dr.CommRate);
            $('#txtTAddress').val(dr.TAddress);
            $('#txtTDistrict').val(dr.TDistrict);
            $('#txtTSubProvince').val(dr.TSubProvince);
            $('#txtTProvince').val(dr.TProvince);
            $('#txtTPostCode').val(dr.TPostCode);
            $('#txtDMailAddress').val(dr.DMailAddress);
            $('#txtPrivilegeOption').val(dr.PrivilegeOption);
            $('#txtGoldCardNO').val(dr.GoldCardNO);
            $('#txtCustomsBrokerSeq').val(dr.CustomsBrokerSeq);
            $('#txtISCustomerSign').val(dr.ISCustomerSign);
            $('#txtISCustomerSignInv').val(dr.ISCustomerSignInv);
            $('#txtISCustomerSignDec').val(dr.ISCustomerSignDec);
            $('#txtISCustomerSignECon').val(dr.ISCustomerSignECon);
            $('#txtIsShippingCannotSign').val(dr.IsShippingCannotSign);
            $('#txtExportCode').val(dr.ExportCode);
            $('#txtCode19BIS').val(dr.Code19BIS);
            $('#txtWEB_SITE').val(dr.WEB_SITE);

            var cons = dr.ConsStatus == null ? '' : dr.ConsStatus;
            var lvl = dr.CommLevel == null ? '' : dr.CommLevel;

            $('#txtConsStatus').val(cons);
            $('#txtCommLevel').val(lvl);
            $('#cboCommLevel').val(lvl);

            if (cons.indexOf(',') >= 0) {
                $('#cboCompanyType').val(cons.split(','));
            } else {
                $('#cboCompanyType').val(cons);
            }
        } else {
            ShowMessage('Data not found',true);
            ClearData();
        }
    }
    function ReadBilling(dr) {
        $('#txtBillToCustCode').val(dr.CustCode);
        $('#txtBillToBranch').val(dr.Branch);
        if ($('#txtUsedLanguage').val() == "TH") {
            $('#txtBillToCustName').val(dr.NameThai);
            $('#txtBillToAddress').val(dr.TAddress1 + ' ' + dr.TAddress2);
        } else {
            $('#txtBillToCustName').val(dr.NameEng);
            $('#txtBillToAddress').val(dr.EAddress1 + ' ' + dr.EAddress2);
        }
    }
    function ReadSales(dt) {
        $('#txtManagerCode').val(dt.UserID);
        $('#txtManagerCode').focus();
    }
    function ReadCSImp(dt) {
        $('#txtCSCodeIM').val(dt.UserID);
        $('#txtCSCodeIM').focus();
    }
    function ReadCSExp(dt) {
        $('#txtCSCodeEX').val(dt.UserID);
        $('#txtCSCodeEX').focus();
    }
    function ReadCSOth(dt) {
        $('#txtCSCodeOT').val(dt.UserID);
        $('#txtCSCodeOT').focus();
    }
    function ClearData() {
        if (userGroup !== 'C') {
            $('#txtCustCode').val('{AUTO}');
            $('#txtBranch').val('0000');
        }
        $('#txtCustGroup').val(mode);
        $('#txtTaxNumber').val('');
        $('#txtTitle').val('');
        $('#txtNameThai').val('');
        $('#txtNameEng').val('');
        $('#txtTAddress1').val('');
        $('#txtTAddress2').val('');
        $('#txtEAddress1').val('');
        $('#txtEAddress2').val('');
        $('#txtPhone').val('');
        $('#txtFaxNumber').val('');
        $('#txtLoginName').val('');
        $('#txtLoginPassword').val('');
        $('#txtManagerCode').val('');
        $('#txtCSCodeIM').val('');
        $('#txtCSCodeEX').val('');
        $('#txtCSCodeOT').val('');
        $('#txtGLAccountCode').val('');
        $('#txtGLAccountName').val('');
        $('#txtCustType').val('');
        $('#txtBillToCustCode').val('');
        $('#txtBillToCustName').val('');
        $('#txtBillToAddress').val('');
        $('#txtBillToBranch').val('');
        $('#txtUsedLanguage').val('TH');
        $('#txtLevelGrade').val('');
        $('#txtTermOfPayment').val('');
        $('#txtBillCondition').val('');
        $('#txtCreditLimit').val('0.00');
        $('#txtMapText').val('');
        $('#txtMapFileName').val('');
        $('#txtCmpType').val('');
        $('#txtCmpLevelExp').val('');
        $('#txtCmpLevelImp').val('');
        $('#txtIs19bis').val('');
        $('#txtMgrSeq').val('');
        $('#txtLevelNoExp').val('');
        $('#txtLevelNoImp').val('');
        $('#txtLnNO').val('');
        $('#txtAdjTaxCode').val('');
        $('#txtBkAuthorNo').val('');
        $('#txtBkAuthorCnn').val('');
        $('#txtLtdPsWkName').val('');
        $('#txtConsStatus').val('');
        $('#txtCommLevel').val('');
        $('#txtDutyLimit').val('0.00');
        $('#txtCommRate').val('0.00');
        $('#txtTAddress').val('');
        $('#txtTDistrict').val('');
        $('#txtTSubProvince').val('');
        $('#txtTProvince').val('');
        $('#txtTProvinceName').val('');
        $('#txtTPostCode').val('');
        $('#txtDMailAddress').val('');
        $('#txtPrivilegeOption').val('');
        $('#txtGoldCardNO').val('');
        $('#txtCustomsBrokerSeq').val('');
        $('#txtISCustomerSign').val('');
        $('#txtISCustomerSignInv').val('');
        $('#txtISCustomerSignDec').val('');
        $('#txtISCustomerSignECon').val('');
        $('#txtIsShippingCannotSign').val('');
        $('#txtExportCode').val('');
        $('#txtCode19BIS').val('');
        $('#txtWEB_SITE').val('');
        $('#cboCompanyType').val('');
        $('#cboCommLevel').val('');

        $('#txtCustCode').focus();
    }
    function SaveData() {
        if ($('#txtCustCode').val().trim().indexOf(' ') >= 0) {
            ShowMessage('Data must not have space', true);
            return;
        }
        if ($('#txtCustCode').val().trim().length > 10) {
            ShowMessage('Data must not have length over 10', true);
            return;
        }
        if ($('#txtCustCode').val().trim().length < 3) {
            ShowMessage('Data must not have length less than 3', true);
            return;
        }
        if ($('#txtBranch').val().trim().length > 5) {
            ShowMessage('Branch must not have length over 5', true);
            return;
        }
        if ($('#txtTaxNumber').val().trim().length != 13) {
           ShowMessage('กรุณากรอกเลขประจำตัวผู้เสียภาษีให้ครบ 13 หลัก', true);
           $('#txtTaxNumber').focus();
           return;
        }
        if ($('#txtBillToCustCode').val().trim().indexOf(' ') >= 0) {
            ShowMessage('Please input Billing Code.', true);
            return;
        }
        var obj = {
            CustCode: $('#txtCustCode').val().trim(),
            Branch: $('#txtBranch').val().trim(),
            CustGroup: $('#txtCustGroup').val(),
            TaxNumber: $('#txtTaxNumber').val(),
            Title: $('#txtTitle').val(),
            NameThai: $('#txtNameThai').val(),
            NameEng: $('#txtNameEng').val(),
            TAddress1: $('#txtTAddress1').val(),
            TAddress2: $('#txtTAddress2').val(),
            EAddress1: $('#txtEAddress1').val(),
            EAddress2: $('#txtEAddress2').val(),
            Phone: $('#txtPhone').val(),
            FaxNumber: $('#txtFaxNumber').val(),
            LoginName: $('#txtLoginName').val(),
            LoginPassword: $('#txtLoginPassword').val(),
            ManagerCode: $('#txtManagerCode').val(),
            CSCodeIM: $('#txtCSCodeIM').val(),
            CSCodeEX: $('#txtCSCodeEX').val(),
            CSCodeOT: $('#txtCSCodeOT').val(),
            GLAccountCode: $('#txtGLAccountCode').val(),
            CustType: $('#txtCustType').val(),
            BillToCustCode: $('#txtBillToCustCode').val(),
            BillToBranch: $('#txtBillToBranch').val(),
            UsedLanguage: $('#txtUsedLanguage').val(),
            LevelGrade: $('#txtLevelGrade').val(),
            TermOfPayment: $('#txtTermOfPayment').val(),
            BillCondition: $('#txtBillCondition').val(),
            CreditLimit: CNum($('#txtCreditLimit').val()),
            MapText: $('#txtMapText').val(),
            MapFileName: $('#txtMapFileName').val(),
            CmpType: $('#txtCmpType').val(),
            CmpLevelExp: $('#txtCmpLevelExp').val(),
            CmpLevelImp: $('#txtCmpLevelImp').val(),
            Is19bis: $('#txtIs19bis').val(),
            MgrSeq: $('#txtMgrSeq').val(),
            LevelNoExp: $('#txtLevelNoExp').val(),
            LevelNoImp: $('#txtLevelNoImp').val(),
            LnNO: $('#txtLnNO').val(),
            AdjTaxCode: $('#txtAdjTaxCode').val(),
            BkAuthorNo: $('#txtBkAuthorNo').val(),
            BkAuthorCnn: $('#txtBkAuthorCnn').val(),
            LtdPsWkName: $('#txtLtdPsWkName').val(),
            ConsStatus: $('#txtConsStatus').val(),
            CommLevel: $('#txtCommLevel').val(),
            DutyLimit: CNum($('#txtDutyLimit').val()),
            CommRate: CNum($('#txtCommRate').val()),
            TAddress: $('#txtTAddress').val(),
            TDistrict: $('#txtTDistrict').val(),
            TSubProvince: $('#txtTSubProvince').val(),
            TProvince: $('#txtTProvince').val(),
            TPostCode: $('#txtTPostCode').val(),
            DMailAddress: $('#txtDMailAddress').val(),
            PrivilegeOption: $('#txtPrivilegeOption').val(),
            GoldCardNO: $('#txtGoldCardNO').val(),
            CustomsBrokerSeq: $('#txtCustomsBrokerSeq').val(),
            ISCustomerSign: $('#txtISCustomerSign').val(),
            ISCustomerSignInv: $('#txtISCustomerSignInv').val(),
            ISCustomerSignDec: $('#txtISCustomerSignDec').val(),
            ISCustomerSignECon: $('#txtISCustomerSignECon').val(),
            IsShippingCannotSign: $('#txtIsShippingCannotSign').val(),
            ExportCode: $('#txtExportCode').val(),
            Code19BIS: $('#txtCode19BIS').val(),
            WEB_SITE: $('#txtWEB_SITE').val()
        };
        if (obj.CustCode != "") {
            if (obj.Branch == '') {
                ShowMessage('Please input branch',true);
                return;
            }
            if (obj.NameThai == '') {
                ShowMessage('Please input name',true);
                return;
            }
            if (obj.GLAccountCode == '') {
                ShowMessage('Please select GL A/R Code',true);
                return;
            }
	    if (obj.BillToCustCode == '' && obj.BillToBranch == ''){
		SetBilling();
 		obj.BillToCustCode = $('#txtBillToCustCode').val();
                obj.BillToBranch = $('#txtBillToBranch').val();
	    }
	    @*if (obj.BillToCustCode != '') {
		ShowMessage('Please input Billing Code.',true);
		return;
	    }else if(obj.BillToCustCode == obj.CustCode && obj.BillToBranch != obj.Branch) {
		ShowMessage('Please input Billing Branch same as Company Branch1.',true);
		return;
	    }*@
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: obj });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetCompany", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtCustCode').val(response.result.data);
                            $('#txtCustCode').focus();
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
    function DeleteData() {
        var code = $('#txtCustCode').val();
        var branch = $('#txtBranch').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delcompany?code=' + code + '&branch=' + branch, function (r) {
                ShowMessage(r.company.result);
                ClearData();
            });
        });
    }
    function AddContact() {
        window.open(path + 'master/companycontact?custbranch=' + $('#txtBranch').val() + '&custcode=' + $('#txtCustCode').val(), '', '');
    }

    function SetAddress() {
        $('#txtTAddress1').val($('#txtTAddress').val() + ' ' + $('#txtTDistrict').val());
        $('#txtTAddress2').val('แขวง'+$('#txtTSubProvince').val() +' '+ $('#txtTProvinceName').val()+ ' '+ $('#txtTPostCode').val());
        }
    function SetBilling() {
        $('#txtBillToCustCode').val($('#txtCustCode').val());
        $('#txtBillToBranch').val($('#txtBranch').val());
        $('#txtBillToCustName').val($('#txtNameThai').val());
        $('#txtBillToAddress').val($('#txtTAddress1').val() + ' '+$('#txtTAddress2').val());
    }

    function CopyName() {
        $('#txtNameEng').val($('#txtNameThai').val());
    }

    function ShowProvince(dr) {
        $('#txtProvince').val(dr.ProvinceName);
    }

    function ReadProvince(dr) {
        $('#txtTProvince').val(dr.ProvinceCode);
        $('#txtTProvince').change();
        $('#txtPostcode').val(dr.PostCode);
        $('#txtDistrict').val(dr.District);
        $('#txtSubDistrict').val(dr.SubProvince);

        //$('#txtProvince').val(dr.ProvinceName);
    }

    $(document).ready(function () {
        let currentLanguage = 'en'; // Initial language is Thai
        let activeTextareaId = '';

        // Text labels for different languages
        const labels = {
            en: {
                build: 'Building', roomNo: 'Room No', floorNo: 'Floor No', village: 'Village',
                addNo: 'No.', mooNo: 'Moo', soi: 'Soi', street: 'Street',
                subDistrict: 'Subdistrict', district: 'District', province: 'Province', postcode: 'Postcode'
            },
            th: {
                build: 'อาคาร', roomNo: 'ห้องที่', floorNo: 'ชั้นที่', village: 'หมู่บ้าน',
                addNo: 'เลขที่', mooNo: 'หมู่ที่', soi: 'ซอย', street: 'ถนน',
                subDistrict: 'ตำบล/แขวง', district: 'อำเภอ/เขต', province: 'จังหวัด', postcode: 'รหัสไปรษณีย์'
            }
        };

        // Function to toggle language labels on the form
        function toggleLanguage(lang) {
            //const newLang = currentLanguage === 'th' ? 'en' : 'th';
            //currentLanguage = newLang;
            //const currentLabels = labels[currentLanguage];
            currentLanguage = lang;
            const currentLabels = labels[currentLanguage];

            $('#lblBuild').text(currentLabels.build);
            $('#lblRoomNo').text(currentLabels.roomNo);
            $('#lblFloorNo').text(currentLabels.floorNo);
            $('#lblVillage').text(currentLabels.village);
            $('#lblAddNo').text(currentLabels.addNo);
            $('#lblMooNo').text(currentLabels.mooNo);
            $('#lblSoi').text(currentLabels.soi);
            $('#lblStreetName').text(currentLabels.street);
            $('#lblSubDistrict').text(currentLabels.subDistrict);
            $('#lblDistrict').text(currentLabels.district);
            $('#lblProvince').text(currentLabels.province);
            $('#lblPostcode').text(currentLabels.postcode);

            $('#linkSaveAddress').text(currentLanguage === 'th' ? 'บันทึก' : 'Save');
            $('#linkDelAddress').text(currentLanguage === 'th' ? 'ลบ' : 'Delete');

            const buttonText = currentLanguage === 'th' ? 'สลับภาษา: อังกฤษ' : 'สลับภาษา: ไทย';
            $('#toggleLanguageBtn').text(buttonText);
        }

        // Function to save and display address

        function saveAndDisplayAddress() {
            if (!activeTextareaId) return;

            const address1Parts = [];
            const address2Parts = [];

            // Get all values from the form
            const buildVal = $('#txtBuild').val().trim();
            const roomNoVal = $('#txtRoomNo').val().trim();
            const floorNoVal = $('#txtFloorNo').val().trim();
            const villageVal = $('#txtVillage').val().trim();
            const addNoVal = $('#txtAddNo').val().trim();
            const mooNoVal = $('#txtMooNo').val().trim();
            const soiVal = $('#txtSoi').val().trim();
            const streetNameVal = $('#txtStreetName').val().trim();
            const subDistrictVal = $('#txtSubDistrict').val().trim();
            const districtVal = $('#txtDistrict').val().trim();
            const provinceVal = $('#txtProvince').val().trim();
            const postcodeVal = $('#txtPostcode').val().trim();

            // SAVE: Separate parts into TAddress1 and TAddress2
            if (currentLanguage === 'en') {
                if (buildVal) address1Parts.push(`${buildVal} Building`);
                if (roomNoVal) address1Parts.push(`Room ${roomNoVal}`);
                if (floorNoVal) address1Parts.push(`Floor ${floorNoVal}`);
                if (villageVal) address1Parts.push(`${villageVal} Village`);
                if (addNoVal) address1Parts.push(`No. ${addNoVal}`);
                if (mooNoVal) address1Parts.push(`Moo ${mooNoVal}`);
                if (soiVal) address1Parts.push(`Soi ${soiVal}`);
                if (streetNameVal) address1Parts.push(`${streetNameVal} Road`);

                if (subDistrictVal) address2Parts.push(`${subDistrictVal} Subdistrict`);
                if (districtVal) address2Parts.push(`${districtVal} District`);
                if (provinceVal && postcodeVal) {
                    address2Parts.push(`${provinceVal} ${postcodeVal}`);
                } else if (provinceVal) {
                    address2Parts.push(provinceVal);
                } else if (postcodeVal) {
                    address2Parts.push(postcodeVal);
                }
            } else {
                // Thai formatting
                if (buildVal) address1Parts.push(`อาคาร${buildVal}`);
                if (roomNoVal) address1Parts.push(`ห้องที่${roomNoVal}`);
                if (floorNoVal) address1Parts.push(`ชั้นที่${floorNoVal}`);
                if (villageVal) address1Parts.push(`หมู่บ้าน${villageVal}`);
                if (addNoVal) address1Parts.push(`เลขที่${addNoVal}`);
                if (mooNoVal) address1Parts.push(`หมู่ที่${mooNoVal}`);
                if (soiVal) address1Parts.push(`ซอย${soiVal}`);
                if (streetNameVal) address1Parts.push(`ถนน${streetNameVal}`);

                const isBangkok = provinceVal.includes('กรุงเทพมหานคร');
                const subDistrictPrefix = isBangkok ? 'แขวง' : 'ตำบล';
                if (subDistrictVal) address2Parts.push(`${subDistrictPrefix}${subDistrictVal}`);

                if (districtVal) {
                    const districtPrefix = isBangkok ? 'เขต' : 'อำเภอ';
                    address2Parts.push(`${districtPrefix}${districtVal}`);
                }

                const provincePrefix = isBangkok ? '' : 'จังหวัด';
                if (provinceVal) address2Parts.push(`${provincePrefix}${provinceVal}`);
                if (postcodeVal) address2Parts.push(`${postcodeVal}`);
            }

            const fullAddress1 = address1Parts.join(' ');
            const fullAddress2 = address2Parts.join(' ');

            // Assign to the corresponding textareas based on activeTextareaId
            if (activeTextareaId.endsWith('TAddress1')) {
                $(`#${activeTextareaId}`).val(fullAddress1);
                $(`#${activeTextareaId.replace('TAddress1', 'TAddress2')}`).val(fullAddress2);
            } else if (activeTextareaId.endsWith('EAddress1')) {
                $(`#${activeTextareaId}`).val(fullAddress1);
                $(`#${activeTextareaId.replace('EAddress1', 'EAddress2')}`).val(fullAddress2);
            }

            //SaveHeader();
            $('#frmAddress').modal('hide');
        }
        // Function to load address from textarea into modal fields
        function LoadAddress() {
            if (!activeTextareaId) return;

            if (activeTextareaId.startsWith('txtE')) {
                toggleLanguage('en');
            } else if (activeTextareaId.startsWith('txtT')) {
                toggleLanguage('th');
            }

            $('#frmAddress input[type="text"]').val('');

            const fullAddress1 = $(`#${activeTextareaId}`).val() || '';
            const fullAddress2 = $(`#${activeTextareaId.replace('Address1', 'Address2')}`).val() || '';

            if (currentLanguage === 'en') {
                let address1 = fullAddress1;
                let address2 = fullAddress2;

                // 🌟 แก้ไข: ใช้ Regex เพื่อดึงข้อมูลทีละส่วน 🌟
                const parts = [
                    { id: 'txtPostcode', regex: /(\d{5})$/ },
                    { id: 'txtProvince', regex: /(.+?)(?=\s\d{5}$)/ },
                    { id: 'txtDistrict', regex: /(.+)\sDistrict/i },
                    { id: 'txtSubDistrict', regex: /(.+)\sSub-?district/i },
                    { id: 'txtStreetName', regex: /(.+)\sRoad$/i },
                    { id: 'txtSoi', regex: /Soi\s(.+)/i },
                    { id: 'txtMooNo', regex: /Moo\s(.+)/i },
                    { id: 'txtAddNo', regex: /(No\.)\s(.+)/i },
                    { id: 'txtVillage', regex: /(.+)\sVillage/i },
                    { id: 'txtFloorNo', regex: /Floor\s(.+)/i },
                    { id: 'txtRoomNo', regex: /Room\s(.+)/i },
                    { id: 'txtBuild', regex: /(.+)\sBuilding/i }
                ];

                // Process Address 2 first
                if (address2) {
                    let tempAddress2 = address2;
                    parts.slice(0, 4).forEach(part => {
                        const match = tempAddress2.match(part.regex);
                        if (match) {
                            $(`#${part.id}`).val(match[1].trim());
                            tempAddress2 = tempAddress2.replace(match[0], '').trim();
                        }
                    });

                    // Handle Province and Postcode separately for better accuracy
                    const postcodeMatch = address2.match(/(\d{5})$/);
                    if (postcodeMatch) {
                        $('#txtPostcode').val(postcodeMatch[1]);
                        const provinceText = address2.replace(postcodeMatch[0], '').trim().split(',').pop().trim();
                        $('#txtProvince').val(provinceText);
                    }
                }

                // Process Address 1
                if (address1) {
                    let tempAddress1 = address1;
                    parts.slice(4).forEach(part => {
                        const match = tempAddress1.match(part.regex);
                        if (match) {
                            if (part.id === 'txtAddNo') {
                                $('#txtAddNo').val(match[2].trim());
                            } else {
                                $(`#${part.id}`).val(match[1].trim());
                            }
                            tempAddress1 = tempAddress1.replace(match[0], '').trim();
                        }
                    });
                }

            } else {
                // Thai parsing logic (same as before)
                let fullAddress = `${fullAddress1} ${fullAddress2}`.trim();
                if (!fullAddress) return;
                // New and improved Thai parsing logic
                const postcodeMatch = fullAddress.match(/(\d{5})$/);
                if (postcodeMatch) {
                    $('#txtPostcode').val(postcodeMatch[1]);
                    fullAddress = fullAddress.replace(postcodeMatch[0], '').trim();
                }

                let provinceMatch = fullAddress.match(/(กรุงเทพมหานคร)$/);
                if (provinceMatch) {
                    $('#txtProvince').val(provinceMatch[1].trim());
                    fullAddress = fullAddress.replace(provinceMatch[0], '').trim();
                } else {
                    provinceMatch = fullAddress.match(/(?:จังหวัด)(.*?)$/);
                    if (provinceMatch) {
                        $('#txtProvince').val(provinceMatch[1].trim());
                        fullAddress = fullAddress.replace(provinceMatch[0], '').trim();
                    }
                }

                const districtRegex = /(?:อำเภอ|เขต)(.*?)$/;
                const districtMatch = fullAddress.match(districtRegex);
                if (districtMatch) {
                    $('#txtDistrict').val(districtMatch[1].trim());
                    fullAddress = fullAddress.replace(districtMatch[0], '').trim();
                }

                const subDistrictRegex = /(?:ตำบล|แขวง)(.*?)$/;
                const subDistrictMatch = fullAddress.match(subDistrictRegex);
                if (subDistrictMatch) {
                    $('#txtSubDistrict').val(subDistrictMatch[1].trim());
                    fullAddress = fullAddress.replace(subDistrictMatch[0], '').trim();
                }

                const streetRegex = /ถนน(.*?)((?=\s(หมู่บ้าน|ซอย|อาคาร|เลขที่))|$)/;
                const streetMatch = fullAddress.match(streetRegex);
                if (streetMatch) {
                    $('#txtStreetName').val(streetMatch[1].trim());
                    fullAddress = fullAddress.replace(streetMatch[0], '').trim();
                }

                // 2. Parse ซอย (Soi)
                const soiRegex = /ซอย(.*?)((?=\s(หมู่บ้าน|อาคาร|เลขที่|ถนน))|$)/;
                const soiMatch = fullAddress.match(soiRegex);
                if (soiMatch) {
                    $('#txtSoi').val(soiMatch[1].trim());
                    fullAddress = fullAddress.replace(soiMatch[0], '').trim();
                }

                // 3. Parse เลขที่ (Address No)
                const addNoRegex = /เลขที่(.*?)(?=\s(หมู่ที่|อาคาร|ซอย|ถนน|หมู่บ้าน|ห้องที่|ชั้นที่)|$)/;
                const addNoMatch = fullAddress.match(addNoRegex);
                if (addNoMatch) {
                    $('#txtAddNo').val(addNoMatch[1].trim());
                    fullAddress = fullAddress.replace(addNoMatch[0], '').trim();
                }

                // 4. Parse ส่วนอื่นๆ ตามลำดับความสำคัญ
                const mooRegex = /หมู่ที่(\d+)(?=\s|$)/;
                const mooMatch = fullAddress.match(mooRegex);
                if (mooMatch) {
                    $('#txtMooNo').val(mooMatch[1].trim());
                    fullAddress = fullAddress.replace(mooMatch[0], '').trim();
                }

                const roomNoRegex = /ห้องที่(.*?)(?=\s(ชั้นที่|อาคาร|หมู่บ้าน|ซอย|ถนน|เลขที่|หมู่ที่)|$)/;
                const roomNoMatch = fullAddress.match(roomNoRegex);
                if (roomNoMatch) {
                    $('#txtRoomNo').val(roomNoMatch[1].trim());
                    fullAddress = fullAddress.replace(roomNoMatch[0], '').trim();
                }

                const floorRegex = /ชั้นที่(.*?)(?=\s(ห้องที่|อาคาร|หมู่บ้าน|ซอย|ถนน|เลขที่|หมู่ที่)|$)/;
                const floorMatch = fullAddress.match(floorRegex);
                if (floorMatch) {
                    $('#txtFloorNo').val(floorMatch[1].trim());
                    fullAddress = fullAddress.replace(floorMatch[0], '').trim();
                }

                const buildRegex = /อาคาร(.*?)(?=\s(ซอย|ถนน|เลขที่|หมู่ที่|หมู่บ้าน|ห้องที่|ชั้นที่)|$)/;
                const buildMatch = fullAddress.match(buildRegex);
                if (buildMatch) {
                    $('#txtBuild').val(buildMatch[1].trim());
                    fullAddress = fullAddress.replace(buildMatch[0], '').trim();
                }

                const villageRegex = /หมู่บ้าน(.*?)(?=\s(ซอย|ถนน|เลขที่|หมู่ที่|อาคาร|ห้องที่|ชั้นที่)|$)/;
                const villageMatch = fullAddress.match(villageRegex);
                if (villageMatch) {
                    $('#txtVillage').val(villageMatch[1].trim());
                    fullAddress = fullAddress.replace(villageMatch[0], '').trim();
                }

                const addNoRegex1 = /เลขที่(.*?)$/;
                const addNoMatch1 = fullAddress.match(addNoRegex1);
                if (addNoMatch1) {
                    $('#txtAddNo').val(addNoMatch1[1].trim());
                    fullAddress = fullAddress.replace(addNoMatch1[0], '').trim();
                }
            }
        }

        // Event listeners
        $('#btnUpdateAddress').on('click', saveAndDisplayAddress);

        // Use a class selector to handle all buttons
        $('.open-modal-btn').on('click', function () {
            activeTextareaId = $(this).data('target-textarea');

            // กำหนดภาษาตาม data-target-textarea
            if (activeTextareaId.startsWith('txtE')) {
                toggleLanguage('en');
            } else {
                toggleLanguage('th');
            }

            LoadAddress();
            $('#frmAddress').modal('show');
        });

        $('#btnDelAddress').on('click', function () {
            // Clear all input fields in the modal
            $('#frmAddress input[type="text"]').val('');
            // Clear the active textarea
            if (activeTextareaId) {
                $(`#${activeTextareaId}`).val('');
                if (activeTextareaId.endsWith('TAddress1')) {
                    $(`#${activeTextareaId.replace('TAddress1', 'TAddress2')}`).val('');
                } else if (activeTextareaId.endsWith('EAddress1')) {
                    $(`#${activeTextareaId.replace('EAddress1', 'EAddress2')}`).val('');
                }

            }
            // Hide the modal
            $('#frmAddress').modal('hide');
        });

        $('#btnSetData').on('click', function () {
            if (!activeTextareaId) return;

            const sampleAddress1Thai = "อาคารตะวัน ห้องที่5077 ชั้นที่77 หมู่บ้านเอเวอร์กรีน เลขที่011 หมู่ที่145 ซอยบางนาตราด56 ถนนกรุงเทพกรีฑา";
            const sampleAddress2Thai = "แขวงหัวหมาก เขตบางกะปิ กรุงเทพมหานคร 10245";

            const sampleAddress1English = "Tawan Building Room 5077 Floor 77 Evergreen Village No. 011 Moo 145 Soi Bangna-Trad 56 Krungthep Kreetha Road";
            const sampleAddress2English = "Hua Mak Subdistrict Bang Kapi District Bangkok 10245";

            if (currentLanguage === 'th') {
                $(`#${activeTextareaId}`).val(sampleAddress1Thai);
                $(`#${activeTextareaId.replace('TAddress1', 'TAddress2')}`).val(sampleAddress2Thai);
            } else {
                $(`#${activeTextareaId}`).val(sampleAddress1English);
                $(`#${activeTextareaId.replace('EAddress1', 'EAddress2')}`).val(sampleAddress2English);
            }
            LoadAddress();
        });

        // Function to be called from outside
        window.SetAddress = function (targetTextareaId) {
            activeTextareaId = targetTextareaId;
            LoadAddress();
            $('#frmAddress').modal('show');
        };

        $('#toggleLanguageBtn').on('click', toggleLanguage);

        // Call on page load to set initial state
        toggleLanguage('th');
    });

</script>