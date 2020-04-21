@Code
    ViewBag.Title = "Service Group"
End Code
<div class="panel-body">
    <div id="dvForm" class="container" style="width:100%">
        <div class="form-group row">
            <div class="col-sm-3">
                <label id="lblGroupCode">Group Code :</label>
                <br />
                <input type="text" id="txtGroupCode" class="form-control" tabIndex="1">
            </div>
            <div class="col-sm-5"><label id="lblGroupName">Group Name :</label><br /><input type="text" id="txtGroupName" class="form-control" tabIndex="2"></div>
            <div class="col-sm-4"><label id="lblGLAccountCode">GL Account :</label>
            <br />
            <div style="display:flex">
                <input type="text" id="txtGLAccountCode" class="form-control" tabIndex="3">
                <input type="button" class="btn btn-default" value="..." onclick="SearchAccount()" />
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-6">
                <input type="checkbox" id="chkIsTaxCharge" />
                <label id="lblchkIsTaxCharge" for="chkIsTaxCharge">Calculate VAT</label>
                <div style="display:flex">
                    <input type="radio" name="optVAT" value="1" id="optExc"><label for="optExc" class="radio-inline" id="lblExc">Exclude</label> &nbsp;&nbsp;
                    <input type="radio" name="optVAT" value="2" id="optInc"><label for="optInc" class="radio-inline" id="lblInc">Include</label>
                </div>
                <input type="checkbox" id="chkIsCredit" />
                <label id="lblchkIsCredit" for="chkIsCredit">Credit Advance</label>
                <br />
                <input type="checkbox" id="chkIsExpense" />
                <label id="lblchkIsExpense" for="chkIsExpense">Company Expenses</label>
                <br />
                <input type="checkbox" id="chkIsHaveSlip" />
                <label id="lblchkIsHaveSlip" for="chkIsHaveSlip">Must have slip</label>
            </div>
            <div class="col-md-6">
                <input type="checkbox" id="chkIs50Tavi" />
                <label id="lblchkIs50Tavi" for="chkIs50Tavi">Calculate 50Tavi</label>
                <input type="text" id="txtRate50Tavi" /><b>%</b>
                <div style="display:flex">
                    <input type="radio" name="optWHT" value="1" id="optWH1"><label for="optWH1" class="radio-inline" id="lblComp">Paid 50Tavi By Company</label> &nbsp;&nbsp;
                    <input type="radio" name="optWHT" value="2" id="optWH2"><label for="optWH2" class="radio-inline" id="lblVend">Pay 50Tavi by Vender</label>
                </div>
                <input type="checkbox" id="chkIsApplyPolicy" />
                <label id="lblchkIsApplyPolicy" for="chkIsApplyPolicy">Apply Policy To all Code</label>
            </div>
        </div>
        <div id="dvCommand">
            <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddData()">
                <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>New</b>
            </a>
            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                <i class="fa fa-lg fa-save"></i>&nbsp;<b>Save</b>
            </a>
            <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
                <i class="fa fa-lg fa-trash"></i>&nbsp;<b>Delete</b>
            </a>
            <a href="#" class="btn btn-primary" id="btnSearch" onclick="RefreshGrid()">
                <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Search</b>
            </a>
        </div>
        <table class="table table-responsive" id="tbDetail">
            <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
        <a href="#" class="btn btn-warning" id="btnSearch" onclick="AddService()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b>Add Code To Group</b>
        </a>
    </div>
    <div id="dvAdd" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    Add Service Code
                </div>
                <div class="modal-body">
                    <label id="lblSICode">Service Code</label>
                    <input type="text" id="txtSICode" style="width:100px" />
                    <input type="button" value="..." class="btn btn-default" onclick="SearchService()" />
                    <input type="text" id="txtSDescription" style="width:300px" disabled />
                    <a href="#" class="btn btn-success" id="btnSaveDetail" onclick="SaveDetail()">
                        <i class="fa fa-lg fa-save"></i>&nbsp;<b>Add To Group</b>
                    </a>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-danger" data-dismiss="modal">X</button>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="dvList"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let row = {}; //row pointer to current record show in buffer
    let row_d = {};
    //$(document).ready(function () {
        SetEvents();
        SetEnterToTab();
        $('#txtGroupCode').focus();
    //});
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
                }
            });
        });
    }
    function SetLOVs() {
        //2 Field show in grid
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key', function (response) {
            var dv = document.getElementById("dvList");
            //2 Fields
            //Service Group
            CreateLOV(dv, '#dvSearch', '#tbGrid', 'Service Group', response, 2);
            CreateLOV(dv, '#dvServ', '#tbServ', 'Service Charges', response, 2);
            CreateLOV(dv, '#dvAcc', '#tbAcc', 'Account Codes', response, 2);
        });
    }
    function SetEvents() {
        SetLOVs();
        //if value IsTaxCharge =1 -> Exclude VAT ,2-> Include VAT
        $('#chkIsTaxCharge').change(function () {
            //Default value is Excluded VAT
            $('input:radio[name=optVAT][value=1]').prop('checked', this.checked ? true : false);
        });
        $('#chkIs50Tavi').change(function () {
            $('input:radio[name=optWHT][value=1]').prop('checked', this.checked ? true : false);
        });
        //if enter value then query from database
        $('#txtGroupCode').keydown(function (e) {
            if (e.which === 13) {
                SearchData($('#txtGroupCode').val());
            }
        });
        $('#txtSICode').keydown(function (e) {
            if (e.which === 13) {
                $('#txtSDescription').val('');
                CallBackQueryService(path, $('#txtSICode').val(), ReadService);
            }
        });
    }
    function SearchData(code) {
        //function for query data from code
        $.get(path + 'master/getservicegroup?code=' + code).done(function (r) {
            if (r.servicegroup.data.length > 0) {
                LoadData(r.servicegroup.data[0]);
                return;
            } else {
                ShowMessage('Data not found',true);
                AddData();
            }
        });
    }
    function SearchService() {
        SetGridSICodeFilter(path, '#tbServ', '', '#dvServ', ReadService);
    }
    function SearchAccount() {
        SetGridAccountCode(path, '#tbAcc', '#dvAcc', '', ReadAccount);
    }
    function ReadService(dt) {
        row_d = dt;
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameThai);
    }
    function ReadAccount(dt) {
        $('#txtGLAccountCode').val(dt.AccCode);
    }
    function ShowData(dt) {
        LoadData(dt);
        $('#txtGroupCode').focus();
    }
    function RefreshGrid() {
        SetGridGroupCode( path, '#tbGrid', '#dvSearch' , ShowData);
    }
    function AddService() {
        $('#dvAdd').modal('show');
    }
    function AddData() {
        $('#txtGroupCode').val('');
        $('#txtGroupName').val('');
        $('#txtGLAccountCode').val('');

        $('#chkIsTaxCharge').prop('checked',false);
        $('#chkIs50Tavi').prop('checked', false);

        $('input:radio[name=optVAT]:checked').prop('checked', false);
        $('input:radio[name=optWHT]:checked').prop('checked', false);

        $('#txtRate50Tavi').val(0);

        $('#chkIsApplyPolicy').prop('checked', false);
        $('#chkIsHaveSlip').prop('checked', false);
        $('#chkIsCredit').prop('checked', false);
        $('#chkIsExpense').prop('checked', false);
        row = {};
        $('#tbDetail').DataTable().clear().draw();
    }
    function DeleteData() {
        var code = $('#txtGroupCode').val();
        ShowConfirm("Do you need to Delete " + code + "?", function (ask) {
            if (ask == false) return;
            $.get(path + 'master/delservicegroup?code=' + code, function (r) {
                ShowMessage(r.servicegroup.result);
                ShowData(r.servicegroup.data[0]);
            });
        });
    }
    function LoadData(dt) {
        row = dt;

        $('#txtGroupCode').val(dt.GroupCode);
        $('#txtGroupName').val(dt.GroupName);
        $('#txtGLAccountCode').val(dt.GLAccountCode);

        $('#chkIsApplyPolicy').prop('checked', dt.IsApplyPolicy === 0 ? false : true);
        $('#chkIsTaxCharge').prop('checked', dt.IsTaxCharge === 0 ? false : true);
        $('#chkIs50Tavi').prop('checked', dt.Is50Tavi === 0 ? false : true);

        $('input:radio[name=optVAT]:checked').prop('checked', false);
        $('input:radio[name=optWHT]:checked').prop('checked', false);
        $('input:radio[name=optVAT][value="' + dt.IsTaxCharge + '"]').prop('checked', true);
        $('input:radio[name=optWHT][value=1]').prop('checked', dt.IsLtdAdv50Tavi === 1 ? true : false);
        $('input:radio[name=optWHT][value=2]').prop('checked', dt.IsPay50TaviTo === 1 ? true : false);

        $('#txtRate50Tavi').val(dt.Rate50Tavi);

        $('#chkIsHaveSlip').prop('checked', dt.IsHaveSlip === 0 ? false : true);
        $('#chkIsCredit').prop('checked', dt.IsCredit === 0 ? false : true);
        $('#chkIsExpense').prop('checked', dt.IsExpense === 0 ? false : true);

        ShowDetail()
    }
    function ShowDetail() {
        $.get(path + 'Master/GetServiceCode?Group=' + row.GroupCode, function (r) {
            $('#tbDetail').dataTable({
                data: r.servicecode.data,
                columns: [
                    { data: "SICode", title: "Id" },
                    { data: "NameThai", title: "Description (TH)" },
                    { data: "NameEng", title: "Description (EN)" }
                ],
                select:true,
                destroy:true
            });
			$('#tbDetail tbody').on('click', 'tr', function () {
                SetSelect('#tbDetail', this);
            });
            $('#tbDetail tbody').on('dblclick', 'tr', function () {
                let dr = $('#tbDetail').DataTable().row(this).data(); //read current row selected
                window.open(path + 'Master/ServiceCode?code=' + dr.SICode, '', '');
            });
        });
    }
    function GetDataSave() {
        let dt = row;
        dt.GroupCode = $('#txtGroupCode').val();
        dt.GroupName = $('#txtGroupName').val();
        dt.GLAccountCode= $('#txtGLAccountCode').val();

        if ($('#chkIsTaxCharge').prop('checked') == false) {
            dt.IsTaxCharge = 0;
        } else {
            dt.IsTaxCharge = $('input:radio[name=optVAT]:checked').val() == '2' ? 2 : 1;
        }
        dt.IsApplyPolicy = $('#chkIsApplyPolicy').prop('checked') == true ? 1 : 0;
        dt.Is50Tavi = $('#chkIs50Tavi').prop('checked') == true ? 1 : 0;

        dt.IsPay50TaviTo = $('input:radio[name=optWHT]:checked').val() == '2' ? 1 : 0;
        dt.IsLtdAdv50Tavi = $('input:radio[name=optWHT]:checked').val() == '1' ? 1 : 0;
        dt.Rate50Tavi = CNum($('#txtRate50Tavi').val());

        dt.IsHaveSlip = $('#chkIsHaveSlip').prop('checked') === true ? 1 : 0;
        dt.IsCredit = $('#chkIsCredit').prop('checked') === true ? 1 : 0;
        dt.IsExpense = $('#chkIsExpense').prop('checked') === true ? 1 : 0;
        
        return dt;
    }
    function SaveData() {
        var obj = GetDataSave();        
        if (obj.GroupCode == '') {
            ShowMessage('Please enter code',true);
            return;
        }
        if (obj.GroupName == '') {
            ShowMessage('Please enter name',true);
            return;
        }
        row = obj;
        ShowConfirm("Do you need to " + (row.GroupCode == "" ? "Add" : "Save") + " this data?", function (ask) {
            if (ask == false) return;
            var jsonText = JSON.stringify({ data: obj });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetServiceGroup", "Master")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data!=null) {
                        $('#txtGroupCode').val(response.result.data);
                        $('#txtGroupCode').focus();
                        SearchData($('#txtGroupCode').val());
                    }
                    ShowMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });        
        });
    }
    function SaveDetail() {
        if (row_d !== null) {
            row_d.GroupCode = row.GroupCode;
            if (row.IsApplyPolicy==1) {
                row_d.IsTaxCharge = row.IsTaxCharge;
                row_d.Is50Tavi = row.Is50Tavi;
                row_d.IsPay50TaviTo = $('input:radio[name=optWHT]:checked').val() == '2' ? 1 : 0;
                row_d.IsLtdAdv50Tavi = $('input:radio[name=optWHT]:checked').val() == '1' ? 1 : 0;
                row_d.IsHaveSlip = row.IsHaveSlip;
                row_d.IsCredit = row.IsCredit;
                row_d.IsExpense = row.IsExpense;
            }
            ShowConfirm("Do you need to set " + (row_d.SICode) + " to this group?", function (ask) {
                if (ask == false) return;
                var jsonText = JSON.stringify({ data: row_d });
                //ShowMessage(jsonText);
                $.ajax({
                    url: "@Url.Action("SetServiceCode", "Master")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            ShowDetail();
                        }
                        ShowMessage(response.result.msg);
                    },
                    error: function (e) {
                        ShowMessage(e,true);
                    }
                });
            });
        }
    }
</script>

