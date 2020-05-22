
@Code
    ViewBag.Title = "Customers"
End Code
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <label id="lblCustCode">Customer Code:</label>
                <br /><input type="text" id="txtCustCode" class="form-control" tabIndex="0">
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
                <label id="lblNameEng">English :</label>
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
                        <br /><input type="text" id="txtTAddress1" class="form-control" tabIndex="7">
                        <br /><input type="text" id="txtTAddress2" class="form-control" tabIndex="8">
                    </div>
                    <div class="col-sm-6">
                        <label id="lblEAddress1">Address (EN) :</label>
                        <br /><input type="text" id="txtEAddress1" class="form-control" tabIndex="9">
                        <br /><input type="text" id="txtEAddress2" class="form-control" tabIndex="10">
                    </div>
                </div>
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
                            <input type="text" id="txtBillToCustCode"style="width:40%" class="form-control" tabIndex="24">
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
                        <br/>
                        Tracking Authorized : <br/>
                        <div style="display:flex">
                            <label id="lblLoginName" style="display:block;width:250px">Log in : </label><input type="text" id="txtLoginName" class="form-control">                                                                                      
                            <label id="lblLoginPassword" style="display:block;width:250px">Password : </label><input type="password" id="txtLoginPassword" class="form-control">
                        </div>
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
            <input type="hidden" id="txtLnNO" class="form-control">
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
            $('#txtCustCode').val('');
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
        if ($('#txtBranch').val().trim().length > 4) {
            ShowMessage('Branch must not have length over 4', true);
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
            ShowConfirm('Do you need to save this data?', function (ask) {
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
        ShowConfirm('Do you need to delete this data?', function (ask) {
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
</script>