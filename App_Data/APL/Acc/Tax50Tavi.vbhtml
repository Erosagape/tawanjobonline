@Code
    ViewBag.Title = "Withholding-Tax Lists"
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
    <div class="col-sm-4">
        <label id="lblDateFrom">Date From:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateF" />
    </div>
    <div class="col-sm-4">
        <label id="lblDateTo">Date To:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateT" />
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <br />
        <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddWHTax()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkCreate">Create New Slip</b>
        </a>
    </div>
    <div class="col-sm-8" style="text-align:right">
        <br />
        <input type="checkbox" id="chkCancel" />Show Cancel Only
    </div>
    <div class="col-sm-2">
        <br />
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
        </a>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <table id="tbHeader" class="table table-responsive">
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
</div>

<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let arr = [];
    let list = [];
    let docno = '';
    //$(document).ready(function () {
    SetEvents();
    //});
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocDateF').val(GetFirstDayOfMonth());
        $('#txtDocDateT').val(GetLastDayOfMonth());
        //Events
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });
        }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
        }
    }

    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }

    function SetGridAdv(isAlert) {
        let w = '';
        if ($('#txtDocDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        if ($('#chkCancel').prop('checked')) {
            w = w + '&Show=CANCEL';
        } else {
            w = w + '&Show=ACTIVE';
        }
        $.get(path + 'acc/getwhtaxgrid?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.whtax.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.whtax.data;
            let tb=$('#tbHeader').DataTable({
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
                responsive: true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'acc/whtax?Branch=' + $('#txtBranchCode').val() + '&Code=' + data.DocNo,'','');
            });
        });
    }
    function AddWHTax() {
        window.open(path + 'acc/whtax','','');
    }

</script>