
@Code
    ViewBag.Title = "Venders"
End Code
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblVenCode">Vender Code:</label>
<<<<<<< HEAD
                <br /><input type="text" id="txtVenCode" Class="form-control" tabIndex="0" value="{AUTO}" disabled />
=======
                <br /><input type="text" id="txtVenCode" Class="form-control" tabIndex="0" value="{AUTO}" />
>>>>>>> 3x
            </div>
            <div class="col-sm-4">
                <label id="lblBranchCode">Branch :</label>
                <br />
                <input type="text" id="txtBranchCode" Class="form-control" tabIndex="1" />
            </div>
            <div class="col-sm-4">
                <label id="lblTaxNumber">Tax Number:</label>
                <br /><input type="text" id="txtTaxNumber" Class="form-control" tabIndex="2">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <label id="lblVenTitle">Title:</label>
                <br /><input type="text" id="txtTitle" Class="form-control" tabIndex="3">
            </div>
            <div class="col-sm-4">
                <label id="lblTName">Name:</label>
                <br /><input type="text" id="txtTName" Class="form-control" tabIndex="4">
            </div>
            <div class="col-sm-5">
                <label id="lblEnglish">English:</label>
                <br /><input type="text" id="txtEnglish" Class="form-control" tabIndex="5">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblTAddress1">Address (TH):</label>
                <br /><div style="display: flex">
                    <input type="text" id="txtTAddress1" Class="form-control" tabIndex="6">
                    <button type="button" class="btn btn-default open-modal-btn" data-target-textarea="txtTAddress1">...</button>
                </div>
                <br /><input type="text" id="txtTAddress2" Class="form-control" tabIndex="7">
            </div>
            <div class="col-sm-6">
                <label id="lblEAddress1">Address (EN):</label>
                <br />
                <input type="text" id="txtEAddress1" Class="form-control" tabIndex="8">
                @*<div style="display: flex">
                    <input type="text" id="txtTAddress1" Class="form-control" tabIndex="6">
                    <button type="button" class="btn btn-default open-modal-btn" data-target-textarea="txtEAddress1">...</button>
                </div>*@
                <br /><input type="text" id="txtEAddress2" Class="form-control" tabIndex="9">
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
                <label id="lblPhone">Phone:</label>
                <br /><input type="text" id="txtPhone" Class="form-control" tabIndex="10">
            </div>
            <div class="col-sm-3">
                <label id="lblFaxNumber">Fax:</label>
                <br /><input type="text" id="txtFaxNumber" Class="form-control" tabIndex="11">
            </div>
            <div class="col-sm-4">
                <label id="lblWEB_SITE">Web/E-mail:</label>
                <br /><input type="text" id="txtWEB_SITE" Class="form-control" tabIndex="12">
            </div>
            <div class="col-sm-2">
                <label id="lblGLAccountCode">GL Code:</label>
                <br />
                <div style="display:flex">
                    <input type="text" id="txtGLAccountCode" Class="form-control" tabIndex="13">
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('acccode')" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4" style="display:flex;flex-direction:column">
                <b><label id="lblContact">Contact Information:</label></b>
                <br />
                <label id="lblContactAcc">Account :</label>
                <input type="text" id="txtContactAcc" Class="form-control" tabIndex="13">
                <label id="lblContactSale">Sales :</label><input type="text" id="txtContactSale" Class="form-control" tabIndex="14">
            </div>
            <div class="col-sm-4" style="display:flex;flex-direction:column">
                <b>Customer Service :</b><br />
                IMPORT : <input type="text" id="txtContactSupport1" Class="form-control" tabIndex="15">
                EXPORT :<input type="text" id="txtContactSupport2" Class="form-control" tabIndex="16">
                DOMESTIC :<input type="text" id="txtContactSupport3" Class="form-control" tabIndex="17">
            </div>
            <div class="col-sm-4" style="display:flex;flex-direction:column">
                <b>User Login :</b><br />
                User Name :<input type="text" id="txtLoginName" Class="form-control" tabIndex="18">
                Password :<input type="password" id="txtLoginPassword" Class="form-control" tabIndex="19">
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
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="SearchData('vender')">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
            </a>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';

    //$(document).ready(function () {
        SetEvents();
        SetLOVs();
        SetEnterToTab();
        ClearData();
    //});
    function GetDataSave() {
        let dr = {
            VenCode: $('#txtVenCode').val().trim(),
            BranchCode: $('#txtBranchCode').val(),
            TaxNumber: $('#txtTaxNumber').val(),
            Title: $('#txtTitle').val(),
            TName: $('#txtTName').val(),
            English: $('#txtEnglish').val(),
            TAddress1: $('#txtTAddress1').val(),
            TAddress2: $('#txtTAddress2').val(),
            EAddress1: $('#txtEAddress1').val(),
            EAddress2: $('#txtEAddress2').val(),
            Phone: $('#txtPhone').val(),
            FaxNumber: $('#txtFaxNumber').val(),
            LoginName: $('#txtLoginName').val(),
            LoginPassword: $('#txtLoginPassword').val(),
            GLAccountCode: $('#txtGLAccountCode').val(),
            ContactAcc: $('#txtContactAcc').val(),
            ContactSale: $('#txtContactSale').val(),
            ContactSupport1: $('#txtContactSupport1').val(),
            ContactSupport2: $('#txtContactSupport2').val(),
            ContactSupport3: $('#txtContactSupport3').val(),
            WEB_SITE: $('#txtWEB_SITE').val()
        };
        return dr;
    }
    function ClearData() {
        $('#txtVenCode').val('{AUTO}');
        $('#txtBranchCode').val('0000');
        $('#txtTaxNumber').val('');
        $('#txtTitle').val('');
        $('#txtTName').val('');
        $('#txtEnglish').val('');
        $('#txtTAddress1').val('');
        $('#txtTAddress2').val('');
        $('#txtEAddress1').val('');
        $('#txtEAddress2').val('');
        $('#txtPhone').val('');
        $('#txtFaxNumber').val('');
        $('#txtLoginName').val('');
        $('#txtLoginPassword').val('');
        $('#txtGLAccountCode').val('');
        $('#txtContactAcc').val('');
        $('#txtContactSale').val('');
        $('#txtContactSupport1').val('');
        $('#txtContactSupport2').val('');
        $('#txtContactSupport3').val('');
        $('#txtWEB_SITE').val('');

        $('#txtVenCode').focus();
    }
    function DeleteData() {
        var code = $('#txtVenCode').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delvender?code=' + code, function (r) {
                ShowMessage(r.vender.result);
                ClearData();
            });

        });
    }
    function SaveData(){ 
         $.get(path + 'Master/GetVender').done((r)=> {
             if(r==null) {
		SaveDataOK();
             }
             let arr = r.vender.data.filter((data) => {
                 return (data.VenCode !== $('#txtVenCode').val()) && (data.TaxNumber == $('#txtTaxNumber').val());
             });
             if(arr.length>0) {
                for(let a of arr) {
                  if($('#txtTaxNumber').val()!=='') {
                      ShowMessage('This TaxNumber ' + $('#txtTaxNumber').val() +' has been used for ' + a.VenCode + ' already!',true);
                        return;
                  }            
                }
                SaveDataOK(); 
             }
         }); 
    }
    function SaveDataOK() {
	
        var obj = GetDataSave();
        if (obj.VenCode == '') {
            ShowMessage('Please input code',true);
            return;
        }
        if (obj.TName == '') {
            ShowMessage('Please input name',true);
            return;
        }
<<<<<<< HEAD
=======
        if (obj.GLAccountCode == '') {
            ShowMessage('Please input GL A/P code',true);
            return;
        }
        if ($('#txtTaxNumber').val().trim().length != 13) {
           ShowMessage('กรุณากรอกเลขประจำตัวผู้เสียภาษีให้ครบ 13 หลัก', true);
           $('#txtTaxNumber').focus();
           return;
        }
>>>>>>> 3x
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetVender", "Master")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data!=null) {
                        $('#txtVenCode').val(response.result.data);
                        $('#txtVenCode').focus();
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });        
        });
    }
    function ReadAccount(dr) {
        $('#txtGLAccountCode').val(dr.AccCode);
    }
    function ReadVender(dr) {
        if (dr.VenCode != undefined) {

            $('#txtVenCode').val(dr.VenCode);
            $('#txtBranchCode').val(dr.BranchCode);
            $('#txtTaxNumber').val(dr.TaxNumber);
            $('#txtTitle').val(dr.Title);
            $('#txtTName').val(dr.TName);
            $('#txtEnglish').val(dr.English);
            $('#txtTAddress1').val(dr.TAddress1);
            $('#txtTAddress2').val(dr.TAddress2);
            $('#txtEAddress1').val(dr.EAddress1);
            $('#txtEAddress2').val(dr.EAddress2);
            $('#txtPhone').val(dr.Phone);
            $('#txtFaxNumber').val(dr.FaxNumber);
            $('#txtLoginName').val(dr.LoginName);
            $('#txtLoginPassword').val(dr.LoginPassword);
            $('#txtGLAccountCode').val(dr.GLAccountCode);
            $('#txtContactAcc').val(dr.ContactAcc);
            $('#txtContactSale').val(dr.ContactSale);
            $('#txtContactSupport1').val(dr.ContactSupport1);
            $('#txtContactSupport2').val(dr.ContactSupport2);
            $('#txtContactSupport3').val(dr.ContactSupport3);
            $('#txtWEB_SITE').val(dr.WEB_SITE);

            $('#btnSave').removeAttr('disabled');
            if (dr.VenCode != "") {
                $('#btnDel').removeAttr('disabled');
            } else {
                $('#btnDel').attr('disabled', 'disabled');
            }
        } else {
            ShowMessage('Data not found',true);
            ClearData();
        }
        //$('#txtVenCode').focus();
    }
    function SearchData(type) {
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'acccode':
                SetGridAccountCode(path, '#tbAcc', '#frmSearchAcc', '',ReadAccount);
                break;
            case 'subdistrict':
                SetGridProvinceSub(path, '#tbProvince', '#frmSearchProvince', '', ReadProvince);
                break;
        }
    }
    function SetEvents() {
        $('#txtVenCode').keydown(function (event) {
            if (event.which == 13) {
                let code = $('#txtVenCode').val();
                ClearData();
                $('#txtVenCode').val(code);
                CallBackQueryVender(path, code, ReadVender);
            }
        });
    }
    function SetLOVs() {
        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
            CreateLOV(dv, '#frmSearchAcc', '#tbAcc', 'Account Codes', response, 2);
            CreateLOV(dv, '#frmSearchProvince', '#tbProvince', 'Province/District/Sub District', response, 3);
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
                    $('[tabindex="0"]').focus();
                }
            });
        });
    }
<<<<<<< HEAD
=======

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

>>>>>>> 3x
</script>