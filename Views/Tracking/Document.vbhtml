
@Code
    ViewBag.Title = "Document"
End Code
    <div class="row">
        <div class="col-sm-4">
            <label id="lblBranch">Branch</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
            </div>
        </div>
        <div class="col-sm-3">
            <label id="lblDocType">Doc Type</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <select id="txtDocType" class="form-control dropdown">
                    <option value="">ALL</option>
                    <optgroup label="STEP 1">
                        <option value="CIV">Commercial Invoice</option>
                        <option value="PKL">Packing List</option>
                        <option value="BL">Bill of Lading</option>
                        <option value="AWB">Air Waybill</option>
                    </optgroup>
                    <optgroup label="STEP 2">
                        <option value="JOB">Job Acknowledge</option>
                        <option value="CER">Certificates</option>
                        <option value="DEC">Declarations</option>
                    </optgroup>
                    <optgroup label="STEP 3">
                        <option value="DO">Delivery Order</option>
                        <option value="ADV">Advance</option>
                    </optgroup>
                    <optgroup label="STEP 4">
                        <option value="CLR">Clearing</option>
                        <option value="EXP">Expense Slip</option>
                        <option value="IMG">Images</option>
                    </optgroup>
                    <optgroup label="STEP 5">
                        <option value="INV">Invoice</option>
                        <option value="BIL">Billing</option>
                    </optgroup>
                    <optgroup label="STEP 6">
                        <option value="RCP">Receipts</option>
                        <option value="TAX">Tax-Invoice</option>
                    </optgroup>
                    <option value="OTH">Others</option>
                </select>
            </div>
        </div>
        <div class="col-sm-3">
            <label id="lblJob">Job No</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtJNo" style="width:100%" disabled />
                <input type="button" class="btn btn-default" value="..." onclick="SearchData('job');" />
            </div>
        </div>
        <div class="col-sm-2">
            <br />
            <input type="button" id="btnShow" class="btn btn-primary" value="Show" onclick="RefreshGrid()" />
        </div>
    </div>
    <div>
        <input type="button" id="btnAddFile" class="btn btn-primary" value="Add Files" onclick="AddFile()" />
        <table id="tbDocument" class="table table-responsive">
            <thead>
                <tr>
                    <th>#</th>
                    <th>DocType</th>
                    <th>JNo</th>
                    <th>DocNo</th>
                    <th>DocDate</th>
                    <th>Comment</th>
                    <th>CheckDate</th>
                    <th>ApproveDate</th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
        <a href="#" class="btn btn-danger" id="btnDelItem" onclick="DeleteFile()">
            <i class="fa fa-lg fa-trash"></i>&nbsp;<b><label id="lblDelFile">Delete File</label></b>
        </a>
    </div>
<div id="dvEditor" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <div class="row">
                    <div class="col-sm-2">
                        <label id="lblItemNo">No</label><br/>
                        <input type="text" id="txtItemNo" class="form-control" disabled />
                    </div>
                    <div class="col-sm-5">
                        <label id="lblDocTypeD">Type</label><br />
                        <select id="txtDocTypeD" class="form-control dropdown">
                            <option value="">ALL</option>
                            <option value="CIV">Commercial Invoice</option>
                            <option value="PKL">Packing List</option>
                            <option value="JOB">Job Acknowledge</option>
                            <option value="ADV">Advance</option>
                            <option value="CLR">Clearing</option>
                            <option value="EXP">Expense Slip</option>
                            <option value="BL">Bill of Lading</option>
                            <option value="AWB">Air Waybill</option>
                            <option value="CER">Certificates</option>
                            <option value="DO">Delivery Order</option>
                            <option value="INV">Invoice</option>
                            <option value="BIL">Billing</option>
                            <option value="RCP">Receipts</option>
                            <option value="TAX">Tax-Invoice</option>
                            <option value="DEC">Declarations</option>
                            <option value="IMG">Images</option>
                            <option value="OTH">Others</option>
                        </select>
                    </div>
                    <div class="col-sm-5">
                        <label id="lblDocDate">Doc Date</label><br />
                        <input type="date" id="txtDocDate" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-5">
                        <label id="lblDocNo">Doc No</label><br/>
                        <input type="text" id="txtDocNo" class="form-control" />
                    </div>
                    <div class="col-sm-7">
                        <label id="lblDescription">Description</label><br/>
                        <textarea id="txtDescription" class="form-control"></textarea>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <label id="lblFileType">File Type</label>
                        <br/>
                        <select id="txtFileType" class="form-control dropdown" disabled>
                            <option value=".jpg">JPG</option>
                            <option value=".jpeg">JPEG</option>
                            <option value=".png">PNG</option>
                            <option value=".pdf">PDF</option>
                        </select>
                    </div>
                    <div class="col-sm-6">
                        <label id="lblFilePath">File Path</label>
                        <br/>
                        <input type="text" id="txtFilePath" class="form-control" disabled />
                    </div>
                    <div class="col-sm-3">
                        <label id="lblFileSize">File Size</label><br/>
                        <input type="text" id="txtFileSize" class="form-control" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <input type="checkbox" id="chkChecked" />
                        <label id="lblCheckBy">Checked By</label><br />
                        <input type="text" class="form-control" id="txtCheckedBy" disabled />
                    </div>
                    <div class="col-sm-4">
                        <label id="lblCheckDate">Checked Date</label><br />
                        <input type="date" class="form-control" id="txtCheckedDate" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <label id="lblCheckNote">Check Comment</label><br />
                        <textarea class="form-control" style="width:100%" id="txtCheckNote"></textarea>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <input type="checkbox" id="chkApproved" /> 
                        <label id="lblApproveBy">Approve By</label><br />
                        <input type="text" class="form-control" id="txtApproveBy" disabled />
                    </div>
                    <div class="col-sm-4">
                        <label id="lblApproveDate">Approve Date</label><br />
                        <input type="date" class="form-control" id="txtApproveDate" disabled />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label id="lblUploadBy">Upload By</label>
                        <br />
                        <input type="text" class="form-control" id="txtUploadBy" disabled />
                    </div>
                    <div class="col-sm-8">
                        <label id="lblUploadDate">Upload Date</label><br />
                        <input type="date" class="form-control" id="txtUploadDate" disabled />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#" style="float:left" class="btn btn-success" id="btnCreateJob" onclick="SaveData()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b><label id="lblSaveData">Save Information</label></b>
                </a>
                <input type="button" value="X" class="btn btn-danger" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>
<div id="dvAddFile" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <input id="objFile" type="file" />
                <input id="btnUpload" type="button" value="Upload" onclick="UploadFile()" />                
            </div>
            <div class="modal-footer">
                <input type="button" value="X" class="btn btn-danger" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let branchcode = getQueryString("BranchCode");
    let jobno = getQueryString("JNo");
    let userGroup = '@ViewBag.UserGroup';
    let user = '@ViewBag.User'; 
    let cust = '';
    let vend = '';
    let row = {};
    if (userGroup == 'V') {
        $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
            if (r.vender.data.length > 0) {
                let dr = r.vender.data[0];
                vend = dr.VenCode;
            }
        });
        $('#btnDelItem').attr('disabled', 'disabled');
    }
    if (userGroup == 'C') {
        $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
            if (r.company.data.length > 0) {
                let dr = r.company.data[0];
                cust = dr.CustCode;
            }
        });
        $('#btnDelItem').attr('disabled', 'disabled');
    }
    SetLOVs();
    if (jobno !== '' && branchcode !=='') {
        $('#txtBranchCode').val(branchcode);
        $('#txtJNo').val(jobno);
        RefreshGrid();
    }
    function SetLOVs() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');        
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Jobs', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,4);
        });
        $('#chkApproved').on('click', function () {
            let chkmode = this.checked;
            $('#txtApproveBy').val(chkmode ? user : '');
            $('#txtApproveDate').val(chkmode ? GetToday() : '');
        });
        $('#chkChecked').on('click', function () {
            let chkmode = this.checked;
            $('#txtCheckedBy').val(chkmode ? user : '');
            $('#txtCheckedDate').val(chkmode ? GetToday() : '');
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'job':
                let w = '';
                if (userGroup == 'V') {
                    w += '?Agent=' + vend;
                }
                if (userGroup == 'C') {
                    w += '?CustCode=' + cust;
                }
                SetGridJob(path, '#tbJob', '#frmSearchJob', w, ReadJob);
                break;
        }
    }
    function ReadData(dt) {
        $('#txtItemNo').val(dt.ItemNo);
        $('#txtDocTypeD').val(dt.DocType);
        $('#txtDocDate').val(CDateEN(dt.DocDate));
        $('#txtDocNo').val(dt.DocNo);
        $('#txtDescription').val(dt.Description);
        $('#txtFileType').val(dt.FileType);
        $('#txtFilePath').val(dt.FilePath);
        $('#txtFileSize').val(dt.FileSize);        
        $('#txtUploadBy').val(dt.UploadBy);
        $('#txtUploadDate').val(CDateEN(dt.UploadDate));
        $('#chkChecked').prop('checked', (dt.CheckedBy !== '' ? true : false));
        $('#txtCheckedBy').val(dt.CheckedBy);
        $('#txtCheckedDate').val(CDateEN(dt.CheckedDate));
        $('#txtCheckNote').val(dt.CheckNote);
        $('#chkApproved').prop('checked', (dt.ApproveBy !== '' ? true : false));
        $('#txtApproveBy').val(dt.ApproveBy);
        $('#txtApproveDate').val(CDateEN(dt.ApproveDate));
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadJob(dt) {
        $('#txtJNo').val(dt.JNo);
    }
    function RefreshGrid() {
        $('#tbDocument').DataTable().clear().draw();
        let w = ($('#txtJNo').val() !== '' ? '&Code=' + $('#txtJNo').val() : '');
        if ($('#txtDocType').val() !== '') {
            w += '&Type=' + $('#txtDocType').val();
        }
        if (userGroup == 'C') {
            w += '&Cust=' + user;
        }
        if (userGroup == 'V') {
            w += '&Vend=' + user;
        }
        $.get(path + 'JobOrder/GetDocument?Branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.document.data !== undefined) {
                let d = r.document.data;
                $('#tbDocument').DataTable({
                    data: d,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        {
                            data: null, title: "#",
                            render: function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Edit</button>";
                                return html;
                            }
                        },
                        { data: "DocType", title: "Type" },
                        { data: "JNo", title: "Job" },
                        { data: "DocNo", title: "Doc.No" },
                        {
                            data: "DocDate", title: "Doc date ",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        },
                        { data: "CheckNote", title: "Comments" },
                        {
                            data: "CheckedDate", title: "Check date ",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        },
                        {
                            data: "ApproveDate", title: "Approve date ",
                            render: function (data) {
                                return CDateEN(data);
                            }
                        }
                    ],
                    responsive:true,
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                });
                $('#tbDocument tbody').on('click', 'tr', function () {
                    SetSelect('#tbDocument', this);
                    row = $('#tbDocument').DataTable().row(this).data(); //read current row selected
                    ReadData(row);
                });
                $('#tbDocument tbody').on('dblclick', 'tr', function () {
                    if (row.ItemNo !== undefined) {
                        window.open(path + row.FilePath, '', '');
                    }
                });
                $('#tbDocument tbody').on('click', 'button', function () {
                    $('#dvEditor').modal('show');
                });
            }
        });
    }
    function AddFile() {
        if ($('#txtJNo').val() !== '') {
            if ($('#txtDocType').val() !== '') {
                $('#dvAddFile').modal('show');
            } else {
                ShowMessage('Please choose some type of documents', true);
            }
        } else {
            ShowMessage('Please choose some job', true);
        }
    }
    function SaveData() {
        row.DocDate = CDateEN($('#txtDocDate').val());
        row.DocType = $('#txtDocTypeD').val();
        row.Description = $('#txtDescription').val();
        row.CheckNote = $('#txtCheckNote').val();
        row.CheckedBy = $('#txtCheckedBy').val();
        row.CheckedDate = CDateEN($('#txtCheckedDate').val());
        row.DocNo = $('#txtDocNo').val();
        row.ApproveBy = $('#txtApproveBy').val();
        row.ApproveDate = CDateEN($('#txtApproveDate').val());

        if (row.ItemNo != "") {
            ShowConfirm("Do you need to Save " + row.ItemNo + "?", function (ask) {
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: row });
                $.ajax({
                    url: "@Url.Action("SetDocument", "JobOrder")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            RefreshGrid();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        } else {
            ShowMessage('No data to save',true);
        }
    }
    function DeleteData() {
        $.get(path + 'JobOrder/DelDocument?Branch=' + row.BranchCode + '&Code=' + row.JNo + '&Item=' + row.ItemNo, function (r) {
            if (r.document.result !== undefined) {
                RefreshGrid();
                //ShowMessage(r.document.result);
            }
        });
        row = {};
    }
    function DeleteFile() {
        if (row.JNo !== undefined) {
            let fname = row.JNo + '_' + row.DocType;
            if (fname !== null) {
                $.get(path +'Config/RemovePicture?Path=Resource/Import/' + fname + '&Name=' + row.DocNo, function (r) {
                    if (r !== '') {
                        DeleteData();
                        ShowMessage(r);                        
                    }
                });
            }
        } else {
            ShowMessage('No File To Delete',true);
        }
    }
    function UploadFile() {
        let count = $('#objFile')[0].files.length;
        if (count == 0) {
            ShowMessage('no file selected',true);
            return;
        }
        let saveTo = 'Resource/Import';
        for (let file of $('#objFile')[0].files) {
            let data = new FormData();
            data.append(file.name, file);
            var xhr = new XMLHttpRequest();
            xhr.open('POST',path +'Tracking/UploadDocument?Branch='+ $('#txtBranchCode').val() +'&Code='+ $('#txtJNo').val() +'&Type='+ $('#txtDocType').val() +'&Path=' + saveTo);
            xhr.send(data);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    if (xhr.responseText.substr(0, 1) !== "[") {
                        let fname = xhr.responseText.split(' ')[1];
                        if (fname !== '') {
                            $('#objFile').val('');
                        }
                        ShowMessage(fname);
                        $('#dvAddFile').modal('hide');
                        RefreshGrid();
                        return;
                    }
                    ShowMessage(xhr.responseText,true);
                }
            }
        }
    }
</script>