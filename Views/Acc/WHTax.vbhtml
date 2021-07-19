
@Code
    ViewBag.Title = "With-holding Tax"
End Code
<style>
    @@media only screen and (max-width: 600px) {
        #btnAdd,#btnPrint,#btnSave,#btnAddDoc,#btnDelDoc,#btnUpdateDoc {
            width:100%;
        }
        #dvTypes .label {
            width:100% !important;
        }
    }
</style>
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblBranch">Branch:</label>
                <br/>
                <div style="display:flex;flex-direction:row;">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:70%" disabled />
                </div>
            </div>
            <div class="col-sm-4">
                <label id="lblDocNo">Doc No:</label>
                <br />
                <div style="display:flex;flex-direction:row;">
                    <input type="text" class="form-control" id="txtDocNo"/>
                    <input type="button" class="btn btn-default" value="..." onclick="SetGridWHTax()" />
                </div>
            </div>
            <div class="col-sm-4">
                <label id="lblDocDate">Date:</label>
                <br/>
                <div style="display:flex;flex-direction:row;">
                    <input type="date" class="form-control" id="txtDocDate"/>
                </div>
                
            </div>
        </div>
        <ul class="nav nav-tabs">
            <li class="active">
                <a data-toggle="tab" href="#tabHeader" id="linkTab1">Headers</a>
            </li>
            <li>
                <a data-toggle="tab" href="#tabDetail" id="linkTab2">Details</a>
            </li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade in active" id="tabHeader">
                <p>
                    <div class="row">
                        <div class="col-sm-6">
                            <label id="lblTaxName1">Tax Issuer</label>                            
                            <input id="chkVender" type="checkbox" /><label id="lblVend">Venders</label>
                            <br />
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTName1" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" value="..." onclick="SearchData('customer')" />
                            </div>

                        </div>
                        <div class="col-sm-3">
                            <label id="lblTaxNumber1">Tax Number</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTaxNumber1" class="form-control" style="width:100%" />
                            </div>                                                                                            
                        </div>
                        <div class="col-sm-3">
                            <label id="lblIDCard1">ID Number</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtIDCard1" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" value="DN" onclick="MoveData('1','2')" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-9">
                            <label id="lblAddress1">Address</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTAddress1" class="form-control" style="width:100%" />
                            </div>                            
                        </div>
                        <div class="col-sm-3">
                            <label id="lblBranch1">Branch</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtBranch1" class="form-control" style="width:100%" />
                            </div>
                        </div>
                    </div>
                </p>
                <p>
                    <div class="row">
                        <div class="col-sm-6">
                            <label id="lblTaxName2">Tax Agent</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTName2" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" value="..." onclick="GetDefault()" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label id="lblTaxNumber2">Tax Number</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTaxNumber2" class="form-control" style="width:100%" />
                            </div>                            
                        </div>
                        <div class="col-sm-3">
                            <label id="lblIDCard2">ID Number</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtIDCard2" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" value="DN" onclick="MoveData('2','3')" />
                                <input type="button" class="btn btn-default" value="UP" onclick="MoveData('2','1')" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-9">
                            <label id="lblAddress2">Address</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTAddress2" class="form-control" style="width:100%" />
                            </div>                            
                        </div>
                        <div class="col-sm-3">
                            <label id="lblBranch2">Branch</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtBranch2" class="form-control" style="width:100%" />
                            </div>                            
                        </div>
                    </div>
                </p>
                <p>
                    <div class="row">
                        <div class="col-sm-6">
                            <label id="lblTaxName3">Tax Payer</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTName3" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" value="..." onclick="SearchData('vender')" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label id="lblTaxNumber3">Tax Number</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTaxNumber3" class="form-control" style="width:100%" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label id="lblIDCard3">ID Number</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtIDCard3" class="form-control" style="width:100%" />
                                <input type="button" class="btn btn-default" value="UP" onclick="MoveData('3','2')" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-9">
                            <label id="lblAddress3">Address</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtTAddress3" class="form-control" style="width:100%" />
                            </div>                            
                        </div>
                        <div class="col-sm-3">
                            <label id="lblBranch3">Branch</label>
                            <br/>
                            <div style="display:flex;flex-direction:row;">
                                <input type="text" id="txtBranch3" class="form-control" style="width:100%" />
                            </div>                            
                        </div>
                    </div>
                </p>
                <p>
                    <div class="row">
                        <div class="col-sm-2">
                            <label id="lblSeqInForm">Number</label>                            
                            <input type="text" id="txtSeqInForm" class="form-control" />
                        </div>
                        <div class="col-sm-7">
                            <label id="lblFormType">Type of :</label>                            
                            <label><input type="radio" name="FormType" value="1" /> (1) ภ.ง.ด.1ก.</label>
                            <label><input type="radio" name="FormType" value="2" /> (2) ภ.ง.ด.1ก. พิเศษ</label>
                            <label><input type="radio" name="FormType" value="3" /> (3) ภ.ง.ด.2.</label>
                            <label><input type="radio" name="FormType" value="4" /> (4) ภ.ง.ด.3.</label>
                            <label><input type="radio" name="FormType" value="5" /> (5) ภ.ง.ด.2ก.</label>
                            <label><input type="radio" name="FormType" value="6" /> (6) ภ.ง.ด.3ก.</label>
                            <label><input type="radio" name="FormType" value="7" checked /> (7) ภ.ง.ด.53.</label>
                        </div>
                        <div class="col-sm-3" style="display:flex;flex-direction:column">
                            <label id="lblLawNo">Tax Code:</label>                            
                            <select class="form-control dropdown" id="txtTaxLawNo">
                                <option value="1" selected>3 เตรส</option>
                                <option value="2">65 จัดวา</option>
                                <option value="3">69 ทวิ</option>
                                <option value="4">48 ทวิ</option>
                                <option value="5">50 ทวิ</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6" style="display:flex;flex-direction:row">
                            <div style="flex:1">
                                <label style="display:block;width:20%">
                                <input type="checkbox" id="chkCancel" /><label id="lblCancel" style="color:red"> Cancel</label></label>
                            </div>
                            <div style="flex:4">
                                <label id="lblReason">Reason :</label>                                
                                <input type="text" id="txtCancelReason" class="form-control" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <label id="lblCancelBy">Cancel By:</label>
                            <br />
                            <input type="text" id="txtCancelProve" class="form-control" disabled />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblCancelDate">Cancel Date:</label>
                            <br />
                            <input type="date" id="txtCancelDate" class="form-control" disabled />
                        </div>
                    </div>
                </p>
                <div id="dvCommand">
                    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">Clear Data</b>
                    </a>
                    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveHeader()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Data</b>
                    </a>
                    <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                        <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Data</b>
                    </a>
                </div>
            </div>
            <div class="tab-pane fade" id="tabDetail">
                <p>
                    <a href="#" class="btn btn-warning" id="btnAddDoc" onclick="ClearDetail()">
                        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkAdd">Add Detail</b>
                    </a>
                </p>
                <p>
                    <table id="tbDetail" class="table table-bordered">
                        <thead>
                            <tr>
                                <th class="desktop">ItemNo</th>
                                <th class="desktop">IncType</th>
                                <th class="all">PayDate</th>
                                <th class="all">PayAmount</th>
                                <th class="desktop">IncRate</th>
                                <th class="all">PayTax</th>
                                <th class="desktop">PayTaxDesc</th>
                                <th class="desktop">JNo</th>
                                <th class="desktop">DocRefNo</th>
                            </tr>
                        </thead>
                    </table>
                </p>
                <div style="display:flex;flex-direction:row;">
                    <div style="flex:2;">
                        <div class="row">
                            <div class="col-sm-3">
                                <label id="lblCondition">Tax Condition:</label>                                
                                <select class="form-control dropdown" id="txtPayTaxType">
                                    <option value="1">หัก ณ ที่จ่าย</option>
                                    <option value="2">ออกภาษีให้ตลอดไป</option>
                                    <option value="3">ออกภาษีให้ครั้งเดียว</option>
                                    <option value="4">อื่นๆ (ระบุ)</option>
                                </select>
                            </div>
                            <div class="col-sm-4">
                                <label id="lblPayTaxOther">Condition Note:</label>                                
                                <input type="text" id="txtPayTaxOther" class="form-control" />
                            </div>
                            <div class="col-sm-5">
                                <label id="lblIncRate">Control Rate.</label>                                
                                <input type="text" id="txtIncRate" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <label id="lblIncOther">Description</label>                                
                                <input type="text" id="txtIncOther" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label id="lblSoLicNo">Social Security No.</label>                                
                                <input type="text" id="txtSoLicenseNo" class="form-control" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblSoTaxNo">Social Payer No.</label>                                
                                <input type="text" id="txtSoTaxNo" class="form-control" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblSoLicAmt">Amount.</label>                                
                                <input type="text" id="txtSoLicenseAmount" class="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label id="lblPayeeAccNo">Provident Payer.</label>                                
                                <input type="text" id="txtPayeeAccNo" class="form-control" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblProvidentAmt">Provident Amount.</label>                                
                                <input type="text" id="txtSoAccAmount" class="form-control" />
                            </div>
                            <div class="col-sm-4">
                                <label id="lblTeacherAmt">Teacher Amt.</label>                                
                                <input type="text" id="txtTeacherAmt" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <div style="flex:1;margin-left:10px">
                        <label id="lblTotalPayAmt">Total Amount :</label>                        
                        <input type="text" class="form-control" id="txtTotalPayAmount" />
                        <br />
                        <label id="lblTotalPayTax">Total Tax :</label>                        
                        <input type="text" class="form-control" id="txtTotalPayTax" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="frmDetail">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <div style="display:flex;flex-wrap:wrap">
                            <div>
                                <label id="lblItemNo">No :</label>                                
                                <br />
                                <input type="text" id="txtItemNo" class="form-control" value="0" disabled>
                            </div>
                            <div>
                                <label id="lblDocType">Doc.Type :</label>                                
                                <br />
                                <select id="txtDocRefType" class="form-control dropdown">
                                    <option value="1">ADV</option>
                                    <option value="2">CLR</option>
                                    <option value="3">PAY</option>
                                    <option value="4">TAX</option>
                                </select>
                            </div>
                            <div>
                                <label id="lblRefNo">RefNo :</label>                                
                                <br />
                                <input type="text" id="txtDocRefNo" class="form-control">
                            </div>
                            <div>
                                <br />
                                <input type="button" class="btn btn-default" value="..." onclick="GetDocRef()" />
                            </div>
                        </div>
                        <div style="display:flex;flex-wrap:wrap">
                            <div>
                                <label id="lblJNo">Job No :</label>                                
                                <br />
                                <input type="text" id="txtJNo" class="form-control">
                            </div>
                            <div>
                                <br />
                                <input type="button" class="btn btn-default" value="..." onclick="GetJobNo()" />
                            </div>
                            <div>
                                <label id="lblPayDate">Pay.Date :</label>                                
                                <br />
                                <input type="date" id="txtPayDate" class="form-control">
                            </div>
                        </div>
                        <div style="display:flex;flex-wrap:wrap">
                            <div>
                                <label id="lblIncType">Revenue Type :</label>                                
                                <br />
                                <select id="txtIncType" class="form-control dropdown">
                                    <option value="1">
                                        1.เงินเดือน ค่าจ้าง เบี้ยเลี้ยง โบนัส ฯลฯ ตามมาตรา 40(1)
                                    </option>
                                    <option value="2">
                                        2.ค่าธรรมเนียม ค่านายหน้า ฯลฯ ตามมาตรา 40(2)
                                    </option>
                                    <option value="3">
                                        3.ค่าแห่งลิขสิทธิ์ ฯลฯ ตามมาตรา 40(1)
                                    </option>
                                    <option value="4">
                                        4.(ก)ค่าดอกเบี้ย ฯลฯ ตามมาตรา 40(4)(ก)
                                    </option>
                                    <option value="5">
                                        4.(ข)(1)เงินปันผลเงินส่วนแบ่งกำไร (1.1) ร้อยละ 30
                                    </option>
                                    <option value="6">
                                        4.(ข)(1)เงินปันผลเงินส่วนแบ่งกำไร (1.2) ร้อยละ 25
                                    </option>
                                    <option value="7">
                                        4.(ข)(1)เงินปันผลเงินส่วนแบ่งกำไร (1.3) ร้อยละ 20
                                    </option>
                                    <option value="8">
                                        4.(ข)(1)เงินปันผลเงินส่วนแบ่งกำไร (1.4) อัตราอื่นๆ
                                    </option>
                                    <option value="9">
                                        4.(ข)(2)กรณีผู้รับเงินปันผลไม่ได้รับเครดิตภาษีเพราะกิจการได้รับยกเว้น
                                    </option>
                                    <option value="10">
                                        4.(ข)(3)เงินปันผลหรือส่วนแบ่งกำไรที่ได้รับยกเว้นไม่ต้องนำรวมมาคำนวณ
                                    </option>
                                    <option value="11">
                                        4.(ข)(4)กำไรที่รับรู้ทางบัญชีโดยวิธีส่วนได้เสีย
                                    </option>
                                    <option value="12">
                                        4.(ข)(5)อื่นๆ (ระบุ)
                                    </option>
                                    <option value="13">
                                        5.การจ่ายเงินได้ที่ต้องหักภาษี ณ ที่จ่ายตามคำสั่งกรมสรรพากรที่ออกตาม มาตรา 3 เตรส
                                    </option>
                                    <option value="14">
                                        6.อื่นๆ (ระบุ)
                                    </option>
                                </select>
                            </div>
                        </div>
                        <div style="display:flex;flex-wrap:wrap;">
                            <div style="flex:1">
                                <label id="lblPayTaxDesc">Description :</label>                                
                                <br />
                                <input type="text" id="txtPayTaxDesc" class="form-control">
                            </div>
                        </div>
                        <div style="display:flex;flex-wrap:wrap">
                            <div style="flex:1">
                                <label id="lblPayRate">Rate :</label>                                
                                <br />
                                <input type="number" id="txtPayRate" class="form-control" value="0.00" onchange="CalWHT()">
                            </div>
                            <div style="flex:1">
                                <label id="lblAmount">Amount :</label>                                
                                <br />
                                <input type="number" id="txtPayAmount" class="form-control" value="0.00" onchange="CalWHT()">
                            </div>
                            <div style="flex:1">
                                <label id="lblPayTax">Tax :</label>                                
                                <br />
                                <input type="number" id="txtPayTax" class="form-control" value="0.00">
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnUpdateDoc" onclick="SaveDetail()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSaveDet">Save Detail</b>
                            </a>
                            <a href="#" class="btn btn-danger" id="btnDelDoc" onclick="DeleteDetail()">
                                <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelDet">Delete Detail</b>
                            </a>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="frmHeader" class="modal modal-lg fade">
    <div class="modal-dialog-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"></button>
                <h4 class="modal-title"><label>Document List</label></h4>
            </div>
            <div class="modal-body">
                <table id="tbControl" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>DocNo</th>
                            <th class="desktop">DocDate</th>
                            <th class="desktop">TName1</th>
                            <th class="desktop">TName2</th>
                            <th class="desktop">TName3</th>
                            <th class="all">JNo</th>
                            <th class="desktop">InvNo</th>
                            <th class="desktop">DocRefNo</th>
                            <th class="all">PayAmount</th>
                            <th class="all">PayTax</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="modal-footer">
                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    let docSel = '';
    //$(document).ready(function () {
        SetEvents();
        SetLOVs();
        SetEnterToTab();
        ClearData();
        CheckParams();
    //});
    function CheckParams() {
        let branch = getQueryString('Branch');
        let code = getQueryString('Code');
        if (branch !== '' && code !== '') {
            $('#txtBranchCode').val(branch);
            $('#txtDocNo').val(code);
            CallBackQueryWHTax(path, branch, code, ReadData);
        } else {
            $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
            $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        }
    }
    function SetEvents() {
        $('#btnAddDoc').on('click', function () {
            $('#frmDetail').modal('show');
        });
        $('#txtDocNo').keydown(function (event) {
            if (event.which == 13) {
                let code = $('#txtDocNo').val();
                let branch = $('#txtBranchCode').val();
                ClearData();
                $('#txtBranchCode').val(branch);
                $('#txtDocNo').val(code);
                CallBackQueryWHTax(path, branch, code, ReadData);
            }
        });
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#chkCancel').on('click', function () {
            chkmode = this.checked;
            CallBackAuthorize(path, 'MODULE_ACC', 'WHTax', 'D', SetCancel);
        });

    }
    function SetLOVs() {
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 3);
            CreateLOV(dv, '#frmSearchDoc1', '#tbDoc1', 'Documents', response, 3);
            CreateLOV(dv, '#frmSearchDoc2', '#tbDoc2', 'Documents', response, 3);
            CreateLOV(dv, '#frmSearchDoc3', '#tbDoc3', 'Documents', response, 3);
            CreateLOV(dv, '#frmSearchDoc4', '#tbDoc4', 'Documents', response, 3);
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job Number', response, 3);
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
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'customer':
                if ($('#chkVender').prop('checked') == true) {
                    SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender1);
                } else {
                    SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                }
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender3);
                break;
        }
    }
    function SetGridWHTax() {
        let code = $('#txtBranchCode').val();
        $.get(path + 'acc/getwhtaxgrid?branch=' + code, function (r) {
            if (r.whtax.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.whtax.data[0].Table;
            let tb=$('#tbControl').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "DocNo", title: "Document.No" },
                    {
                        data: "DocDate", title: "Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "TName1", title: "Tax Issue" },
                    { data: "TName2", title: "Tax Owner" },
                    { data: "TName3", title: "Tax Payer" },
                    { data: "JNo", title: "Job No" },
                    { data: "InvNo", title: "Inv No" },
                    { data: "DocRefNo", title: "Ref No" },
                    { data: "PayAmount", title: "Amount" },
                    { data: "PayTax", title: "Tax" }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbControl');
            $('#tbControl tbody').on('click', 'tr', function () {
                $('#tbControl tbody > tr').removeClass('selected');
                $(this).addClass('selected');
                let data = $('#tbControl').DataTable().row(this).data(); //read current row selected

                CallBackQueryWHTax(path, data.BranchCode, data.DocNo, ReadData); //callback function from caller

                $('#frmHeader').modal('hide');
            });
            $('#frmHeader').on('shown.bs.modal', function () {
                $('#tbControl_filter input').focus();
            });
            $('#frmHeader').modal('show');
        });
    }
    function ReadBranch(dr) {
        $('#txtBranchCode').val(dr.Code);
        $('#txtBranchName').val(dr.BrName);
    }
    function ReadCustomer(dr) {
        $('#txtTName1').val(dr.Title + ' ' +dr.NameThai);
        $('#txtTAddress1').val(dr.TAddress1 + ' ' + dr.TAddress2);
        $('#txtTaxNumber1').val(dr.TaxNumber);
        $('#txtBranch1').val(dr.Branch);
    }
    function ReadVender1(dr) {
        $('#txtTName1').val(dr.Title + ' '+dr.TName);
        $('#txtTAddress1').val(dr.TAddress1 + ' ' + dr.TAddress2);
        $('#txtTaxNumber1').val(dr.TaxNumber);
        $('#txtBranch1').val(dr.BranchCode);
    }
    function ReadVender3(dr) {
        $('#txtTName3').val(dr.Title + ' '+ dr.TName);
        $('#txtTAddress3').val(dr.TAddress1 + ' ' + dr.TAddress2);
        $('#txtTaxNumber3').val(dr.TaxNumber);
        $('#txtBranch3').val(dr.BranchCode);
    }
    function GetDefault() {
        $('#txtTName2').val('@ViewBag.PROFILE_COMPANY_NAME');
        $('#txtTAddress2').val('@ViewBag.PROFILE_COMPANY_ADDR1' + ' ' + '@ViewBag.PROFILE_COMPANY_ADDR2');
        $('#txtTaxNumber2').val('@ViewBag.PROFILE_TAXNUMBER');
        $('#txtBranch2').val('@ViewBag.PROFILE_TAXBRANCH');
    }
    function ReadAdv(dr) {
        let dh = docSel.header.find(function (chk) {
            return chk.BranchCode==dr.BranchCode && chk.AdvNo==dr.AdvNo
        });
        $('#txtPayDate').val(CDateEN(dh.PaymentDate));
        $('#txtPayAmount').val(dr.AdvAmount);
        $('#txtPayRate').val(dr.Rate50Tavi);
        $('#txtPayTax').val(dr.Charge50Tavi);
        $('#txtPayTaxDesc').val(dr.SDescription);
        $('#txtJNo').val(dr.ForJNo);
        $('#txtDocRefNo').val(dr.AdvNo);
    }
    function ReadPay(dr) {
        $('#txtPayDate').val(CDateEN(dr.DocDate));
        $('#txtPayAmount').val(dr.Amt);
        $('#txtPayTax').val(dr.AmtWHT);
        $('#txtJNo').val(dr.ForJNo);
        $('#txtDocRefNo').val(dr.DocNo);
        $('#txtPayRate').val(dr.TaxRate);
    }
    function ReadRcv(dr) {
        $('#txtPayDate').val(CDateEN(dr.ReceiptDate));
        $('#txtPayAmount').val(dr.Amt);
        $('#txtPayTax').val(dr.Amt50Tavi);
        $('#txtJNo').val(dr.JobNo);
        $('#txtDocRefNo').val(dr.ReceiptNo);
        $('#txtPayRate').val(3);
    }

    function ReadClr(dr) {
        $('#txtPayDate').val(CDateEN(dr.ClrDate));
        $('#txtPayAmount').val(dr.Base50Tavi);
        $('#txtPayTax').val(dr.Clr50Tavi);
        $('#txtJNo').val(dr.JobNo);
        $('#txtDocRefNo').val(dr.ClrNo);
        $('#txtPayRate').val(dr.Rate50Tavi);
    }
    function ReadJob(dr) {
        $('#txtJNo').val(dr.JNo);
    }
    function GetDocRef() {
        let reftype = $('#txtDocRefType').val();
        switch (reftype) {
            case "1": //ADV
                $.get(path + 'Adv/GetAdvanceDetail' + '?branchcode=' + $('#txtBranchCode').val(), function (r) {
                    docSel = r.adv;
                    let d = docSel.detail;
                    let c = d.filter(function (chk) {
                        return chk.Rate50Tavi >0
                    });
                    let tb=$('#tbDoc1').DataTable({
                        data: c,
                        selected: true, //ให้สามารถเลือกแถวได้
                        columns: [ //กำหนด property ของ header column
                            { data: null, title: "#" },
                            { data: "AdvNo", title: "รหัส" },
                            { data: "SDescription", title: "คำอธิบาย" },
                            { data: "AdvAmount", title: "ยอดเงิน" }
                        ],
                        columnDefs: [ //กำหนด control เพิ่มเติมในแต่ละแถว
                            {
                                targets: 0, //column ที่ 0 เป็นหมายเลขแถว
                                data: null,
                                render: function (data, type, full, meta) {
                                    let html = "<button class='btn btn-warning'>Select</button>";
                                    return html;
                                }
                            }
                        ],
                        responsive:true,
                        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                        , pageLength: 100
                    });
                    $('#tbDoc1 tbody').on('click', 'button', function () {
                        let dt = GetSelect('#tbDoc1', this); //read current row selected
                        ReadAdv(dt); //callback function from caller
                        $('#frmSearchDoc1').modal('hide');
                    });
                    $('#tbDoc1 tbody').on('click', 'tr', function () {
                        $('#tbDoc1 tbody > tr').removeClass('selected'); //ล้างทุก row ที่มีการ select ก่อน
                        $(this).addClass('selected'); //select row ใหม่
                    });
                    $('#frmSearchDoc1').modal('show');
                });
                break;
            case "2": //CLR
                $.get(path + 'Clr/GetClearingGrid' + '?branchcode=' + $('#txtBranchCode').val(), function (r) {
                    let d = r.clr.data[0].Table;
                    $('#tbDoc2').DataTable({
                        data: d,
                        selected: true, //ให้สามารถเลือกแถวได้
                        columns: [ //กำหนด property ของ header column
                            { data: null, title: "#" },
                            { data: "ClrNo", title: "รหัส" },
                            { data: "AdvNO", title: "ใบเบิก" },
                            { data: "Base50Tavi", title: "ยอดเงิน" }
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
                        responsive:true,
                        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                        , pageLength: 100
                    });
                    BindEvent('#tbDoc2', '#frmSearchDoc2', ReadClr);
                });
                break;
            case "3": //PAY
                $.get(path + 'Acc/GetPaymentGrid' + '?branchcode=' + $('#txtBranchCode').val(), function (r) {
                    let d = r.payment.data[0].Table;
                    $('#tbDoc3').DataTable({
                        data: d,
                        selected: true, //ให้สามารถเลือกแถวได้
                        columns: [ //กำหนด property ของ header column
                            { data: null, title: "#" },
                            { data: "DocNo", title: "รหัส" },
                            { data: "BookingRefNo", title: "บุคกิ้ง" },
                            { data: "Amt", title: "ยอดเงิน" }
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
                        responsive: true,
                        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                        , pageLength: 100
                    });
                    BindEvent('#tbDoc3', '#frmSearchDoc3', ReadPay);
                });

                break;
            case "4": //TAX
                $.get(path + 'Acc/GetReceiveReport' + '?branch=' + $('#txtBranchCode').val(), function (r) {
                    let d = r.receipt.data[0].Table;
                    $('#tbDoc4').DataTable({
                        data: d,
                        selected: true, //ให้สามารถเลือกแถวได้
                        columns: [ //กำหนด property ของ header column
                            { data: null, title: "#" },
                            { data: "ReceiptNo", title: "ใบเสร็จ" },
                            { data: "SDescription", title: "ค่าใช้จ่าย" },
                            { data: "Amt", title: "ยอดเงิน" }
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
                        responsive: true,
                        destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                        , pageLength: 100
                    });
                    BindEvent('#tbDoc4', '#frmSearchDoc4', ReadRcv);
                });
                break;
        }
    }
    function GetJobNo() {
        SetGridJob(path, '#tbJob', '#frmSearchJob', '?branch=' + $('#txtBranchCode').val(), ReadJob);
    }
    function ReadData(dr,dt) {
        $('#txtBranchCode').val(dr.BranchCode);
        $('#txtDocNo').val(dr.DocNo);
        $('#txtDocDate').val(CDateEN(dr.DocDate));
        $('#txtTaxNumber1').val(dr.TaxNumber1);
        $('#txtTName1').val(dr.TName1);
        $('#txtTAddress1').val(dr.TAddress1);
        $('#txtTaxNumber2').val(dr.TaxNumber2);
        $('#txtTName2').val(dr.TName2);
        $('#txtTAddress2').val(dr.TAddress2);
        $('#txtTaxNumber3').val(dr.TaxNumber3);
        $('#txtTName3').val(dr.TName3);
        $('#txtTAddress3').val(dr.TAddress3);
        $('#txtIDCard1').val(dr.IDCard1);
        $('#txtIDCard2').val(dr.IDCard2);
        $('#txtIDCard3').val(dr.IDCard3);
        $('#txtSeqInForm').val(dr.SeqInForm);
        //$('#txtFormType').val(dr.FormType);
        $('input:radio[name=FormType]:checked').prop('checked', false);
        $('input:radio[name=FormType][value=' + dr.FormType + ']').prop('checked', true);
        $('#txtTaxLawNo').val(dr.TaxLawNo);
        $('#txtIncRate').val(dr.IncRate);
        $('#txtIncOther').val(dr.IncOther);
        //$('#txtUpdateBy').val(dr.UpdateBy);
        $('#txtTotalPayAmount').val(dr.TotalPayAmount);
        $('#txtTotalPayTax').val(dr.TotalPayTax);
        $('#txtSoLicenseNo').val(dr.SoLicenseNo);
        $('#txtSoLicenseAmount').val(dr.SoLicenseAmount);
        $('#txtSoAccAmount').val(dr.SoAccAmount);
        $('#txtPayeeAccNo').val(dr.PayeeAccNo);
        $('#txtSoTaxNo').val(dr.SoTaxNo);
        $('#txtPayTaxType').val(dr.PayTaxType);
        $('#txtPayTaxOther').val(dr.PayTaxOther);
        $('#chkCancel').prop('checked', dr.CancelProve == '' || dr.CancelProve == '' ? false : true);
        $('#txtCancelProve').val(dr.CancelProve);
        $('#txtCancelReason').val(dr.CancelReason);
        $('#txtCancelDate').val(CDateEN(dr.CancelDate));
        //$('#txtLastUpdate').val(CDateEN(dr.LastUpdate));
        $('#txtTeacherAmt').val(dr.TeacherAmt);
        $('#txtBranch1').val(dr.Branch1);
        $('#txtBranch2').val(dr.Branch2);
        $('#txtBranch3').val(dr.Branch3);

        if (dt.length > 0) {
            LoadGridDetail(dt);
        }
    }
    function LoadGridDetail(d) {
        $('#tbDetail').DataTable().clear().draw();
        let tb=$('#tbDetail').DataTable({
            data: d,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "ItemNo", title: "No" },
                { data: "IncType", title: "Type" },
                { data: "PayDate", title: "Date" },
                { data: "PayAmount", title: "Amount" },
                { data: "PayRate", title: "Tax Rate" },
                { data: "PayTax", title: "Tax" },
                { data: "PayTaxDesc", title: "Desc" },
                { data: "JNo", title: "Job No" },
                { data: "DocRefNo", title: "Ref No" }
            ],
            responsive:true,
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            , pageLength: 100
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
        $('#tbDetail tbody').on('click', 'tr', function () {
            $('#tbDetail tbody > tr').removeClass('selected');
            $(this).addClass('selected');
            let data = $('#tbDetail').DataTable().row(this).data(); //read current row selected

            LoadDetail(data);

            $('#frmDetail').modal('show');
        });
    }
    function LoadDetail(dr) {
        $('#txtItemNo').val(dr.ItemNo);
        $('#txtIncType').val(dr.IncType);
        $('#txtPayDate').val(CDateEN(dr.PayDate));
        $('#txtPayAmount').val(dr.PayAmount);
        $('#txtPayTax').val(dr.PayTax);
        $('#txtPayTaxDesc').val(dr.PayTaxDesc);
        $('#txtJNo').val(dr.JNo);
        $('#txtDocRefType').val(dr.DocRefType);
        $('#txtDocRefNo').val(dr.DocRefNo);
        $('#txtPayRate').val(dr.PayRate);
    }
    function ClearData() {
        $('#txtDocNo').val('');
        $('#txtDocDate').val(GetToday());
        $('#txtTaxNumber1').val('');
        $('#txtTName1').val('');
        $('#txtTAddress1').val('');
        $('#txtTaxNumber2').val('');
        $('#txtTName2').val('');
        $('#txtTAddress2').val('');
        $('#txtTaxNumber3').val('');
        $('#txtTName3').val('');
        $('#txtTAddress3').val('');
        $('#txtIDCard1').val('');
        $('#txtIDCard2').val('');
        $('#txtIDCard3').val('');
        $('#txtSeqInForm').val('');

        $('input:radio[name=FormType]:checked').prop('checked', false);
        $('input:radio[name=FormType][value=1]').prop('checked', true);

        $('#txtTaxLawNo').val('1');
        $('#txtPayTaxType').val('1');
        $('#txtIncRate').val('0');
        $('#txtIncOther').val('');
        $('#txtPayTaxOther').val('');

        $('#txtSoLicenseNo').val('');
        $('#txtSoLicenseAmount').val('0.00');
        $('#txtSoAccAmount').val('0.00');
        $('#txtPayeeAccNo').val('');
        $('#txtSoTaxNo').val('');

        $('#chkCancel').prop('checked', false);
        $('#txtCancelProve').val('');
        $('#txtCancelReason').val('');
        $('#txtCancelDate').val('');
        $('#txtTotalPayAmount').val('0.00');
        $('#txtTotalPayTax').val('0.00');
        $('#txtTeacherAmt').val('0.00');
        $('#txtBranch1').val('');
        $('#txtBranch2').val('');
        $('#txtBranch3').val('');

        $('#tbDetail').DataTable().clear().draw();
    }
    function GetFormType() {
        return $('input:radio[name=FormType]:checked').val() == undefined ? 1 : $('input:radio[name=FormType]:checked').val();
    }
    function GetDataHeader() {
        let obj = {

            BranchCode: $('#txtBranchCode').val(),
            DocNo: $('#txtDocNo').val(),
            DocDate: CDateEN($('#txtDocDate').val()),
            TaxNumber1: $('#txtTaxNumber1').val(),
            TName1: $('#txtTName1').val(),
            TAddress1: $('#txtTAddress1').val(),
            TaxNumber2: $('#txtTaxNumber2').val(),
            TName2: $('#txtTName2').val(),
            TAddress2: $('#txtTAddress2').val(),
            TaxNumber3: $('#txtTaxNumber3').val(),
            TName3: $('#txtTName3').val(),
            TAddress3: $('#txtTAddress3').val(),
            IDCard1: $('#txtIDCard1').val(),
            IDCard2: $('#txtIDCard2').val(),
            IDCard3: $('#txtIDCard3').val(),
            SeqInForm: $('#txtSeqInForm').val(),
            FormType: GetFormType(),
            TaxLawNo: $('#txtTaxLawNo').val(),
            IncRate: CNum($('#txtIncRate').val()),
            IncOther: $('#txtIncOther').val(),
            UpdateBy: user,
            TotalPayAmount: CNum($('#txtTotalPayAmount').val()),
            TotalPayTax: CNum($('#txtTotalPayTax').val()),
            SoLicenseNo: $('#txtSoLicenseNo').val(),
            SoLicenseAmount: CNum($('#txtSoLicenseAmount').val()),
            SoAccAmount: CNum($('#txtSoAccAmount').val()),
            PayeeAccNo: $('#txtPayeeAccNo').val(),
            SoTaxNo: $('#txtSoTaxNo').val(),
            PayTaxType: $('#txtPayTaxType').val(),
            PayTaxOther: $('#txtPayTaxOther').val(),
            CancelProve: $('#txtCancelProve').val(),
            CancelReason: $('#txtCancelReason').val(),
            CancelDate: CDateEN($('#txtCancelDate').val()),
            LastUpdate: CDateEN(GetToday()),
            TeacherAmt: CNum($('#txtTeacherAmt').val()),
            Branch1: $('#txtBranch1').val(),
            Branch2: $('#txtBranch2').val(),
            Branch3: $('#txtBranch3').val()
        };
        return obj;
    }
    function SaveHeader(showalert = true) {
        ShowConfirm('Please confirm to save', function (ask) {
            if (ask == false) return;
            let obj = GetDataHeader();
            let jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetWHTaxHeader", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data != '') {
                        $('#txtDocNo').val(response.result.data);
                        $('#txtDocNo').focus();
                    }
                    if(showalert) ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        });
    }
    function SetCancel(b) {
        if (b == true) {
            $('#txtCancelProve').val(chkmode ? user : '');
            $('#txtCancelDate').val(chkmode ? CDateEN(GetToday()) : '');
            $('#txtCancelTime').val(chkmode ? ShowTime(GetTime()) : '');
            return;
        }
        ShowMessage('You are not allow to do this',true);
        $('#chkCancel').prop('checked', !chkmode);
    }
    function SaveDetail() {
        if ($('#txtDocNo').val() == '') {
            ShowMessage('Please save document before add detail',true);
            return;
        }
        //SaveHeader(false);
        let obj={
            BranchCode:$('#txtBranchCode').val(),
            DocNo:$('#txtDocNo').val(),
            ItemNo:$('#txtItemNo').val(),
            IncType:$('#txtIncType').val(),
            PayDate:CDateEN($('#txtPayDate').val()),
            PayAmount:CNum($('#txtPayAmount').val()),
            PayTax:CNum($('#txtPayTax').val()),
            PayTaxDesc:$('#txtPayTaxDesc').val(),
            JNo:$('#txtJNo').val(),
            DocRefType:$('#txtDocRefType').val(),
            DocRefNo:$('#txtDocRefNo').val(),
            PayRate:CNum($('#txtPayRate').val())
	    };
        let jsonText = JSON.stringify({ data: obj });
        //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SetWHTaxDetail", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.data != null) {
                    $('#txtItemNo').val(response.result.data);
                    $('#txtItemNo').focus();
                }
                CallBackQueryWHTax(path, $('#txtBranchCode').val(), $('#txtDocNo').val(), ReadData);
                ShowMessage(response.result.msg);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function DeleteDetail() {
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;

            let branch = $('#txtBranchCode').val();
            let code = $('#txtDocNo').val();
            let item = $('#txtItemNo').val();

            $.get(path + 'acc/delwhtaxdetail?branch='+branch+'&code=' + code + '&itemno='+item, function (r) {
                CallBackQueryWHTax(path, $('#txtBranchCode').val(), $('#txtDocNo').val(), ReadData);
                ShowMessage(r.whtax.result);
                $('#frmDetail').modal('hide');
            });
        });
    }
    function ClearDetail() {
        $('#txtItemNo').val('0');
        $('#txtIncType').val('1');
        $('#txtPayDate').val('');
        $('#txtPayAmount').val('0.00');
        $('#txtPayTax').val('0.00');
        $('#txtPayTaxDesc').val('');
        $('#txtJNo').val('');
        $('#txtDocRefType').val('');
        $('#txtDocRefNo').val('');
        $('#txtPayRate').val($('#txtIncRate').val());

        $('#frmDetail').modal('show');
    }
    function RefreshDetail() {
        let branch = $('#txtBranchCode').val();
        let code = $('#txtDocNo').val();
        $.get(path + 'acc/delwhtaxdetail?branch='+branch+'&code=' + code, function (r) {
            LoadGridDetail(r.whtax.detail);
        });
    }
    function PrintData() {
        if (userRights.indexOf('P') < 0) {
            ShowMessage('You are not allow to print',true);
            return;
        }
        window.open(path + 'Acc/FormWHTax?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtDocNo').val());
    }
    function MoveData(f,t) {
        $('#txtTName' + t).val($('#txtTName' + f).val());
        $('#txtTAddress' + t).val($('#txtTAddress' + f).val());
        $('#txtTaxNumber' + t).val($('#txtTaxNumber' + f).val());
        $('#txtBranch' + t).val($('#txtBranch' + f).val());

        $('#txtTName' + f).val('');
        $('#txtTAddress' + f).val('');
        $('#txtTaxNumber' + f).val('');
        $('#txtBranch' + f).val('');
    }
    function CalWHT() {
        let rate = CNum($('#txtPayRate').val()) * 0.01;
        let amt = CNum($('#txtPayAmount').val());
        let tax = CDbl(amt * rate, 2);
        $('#txtPayTax').val(tax);
    }
</script>