@Code
    ViewBag.Title = "Billing Payment"
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
        <label id="lblDateFrom">Due Date From:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateF" />
    </div>
    <div class="col-sm-4">
        <label id="lblDateTo">Due Date To:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateT" />
    </div>
</div>
<div class="row">
    <div class="col-sm-4">
        <label id="lblCurrency">Currency :</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtCurrencyCode" style="width:20%" />
            <button id="btnBrowseCur" class="btn btn-default" onclick="SearchData('currency')">...</button>
            <input type="text" class="form-control" id="txtCurrencyName" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-6">
        <label id="lblVenCode">Vender :</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtVenCode" style="width:20%" />
            <button id="btnBrowseVend" class="btn btn-default" onclick="SearchData('vender')">...</button>
            <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-2">
        <input type="checkbox" id="chkCancel" /><label id="lblCancel">Show Cancel</label>
        <br />
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
        </a>
    </div>
</div>
<a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="EntryExpense()">
    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkCreate">Entry Expense</b>
</a>
<div class="row">
    <div class="col-sm-12">
        <table id="tbHeader" class="table table-responsive">
            <thead>
                <tr>
                    <th>DocNo</th>
                    <th class="desktop">Job.No</th>
                    <th class="desktop">Booking</th>
                    <th class="desktop">Customer</th>
                    <th class="all">Container</th>
                    <th class="desktop">Vender.Inv</th>
                    <th class="all">Approve No</th>
                    <th class="desktop">Payment.No</th>
                    <th class="desktop">Amount</th>
                    <th class="desktop">WT</th>
                    <th class="desktop">VAT</th>
                    <th class="all">NET</th>
                </tr>
            </thead>
        </table>
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        Print Approval Form:<br />
        <input type="text" class="form-control" id="txtApproveRef" />
    </div>
    <div class="col-sm-2">
        <br />
        <a href="#" class="btn btn-info" id="btnPrnBill" onclick="PrintData()">
            <i class="fa fa-lg fa-print"></i>
        </a>
    </div>
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userGroup = '@ViewBag.UserGroup';
    //$(document).ready(function () {
    SetEvents();
    //});
    function SetEvents() {
        if (userGroup == 'V') {
            $('#txtVenCode').attr('disabled', 'disabled');
            $('#txtVenName').attr('disabled', 'disabled');
            $('#btnBrowseVend').attr('disabled', 'disabled');
            $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
                if (r.vender.data.length > 0) {
                    let dr = r.vender.data[0];
                    $('#txtVenCode').val(dr.VenCode);
                    $('#txtVenName').val(dr.TName);
                }
            });
        }
        //default values
        $('#txtCurrencyCode').val('THB');
        ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');

        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');

        //Events
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });

        $('#txtCurrencyCode').focusout(function (event) {
            if (true) {
                $('#txtCurrencyName').val('');
                ShowCurrency(path, $('#txtCurrencyCode').val(), '#txtCurrencyName');
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");

            CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 3);
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });
    }

    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
        }
    }

    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        ShowVender(path, dt.VenCode, '#txtVenName');
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurrencyName').val(dt.TName);
        }
    function SetGridAdv(isAlert) {
        let w = '';
        if ($('#txtVenCode').val() !== "") {
            w = w + '&vencode=' + $('#txtVenCode').val();
        }
        if ($('#txtDocDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        w = w + '&show='+ ($('#chkCancel').prop('checked')?'CANCEL':'ACTIVE') +'&currency=' + $('#txtCurrencyCode').val();
        $.get(path + 'acc/getpaymentsummary?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.payment.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if(isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.payment.data;
            $('#tbHeader').DataTable().destroy();
            $('#tbHeader').empty();
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "DocNo", title: "Pay.No" },
                    { data: "JobNo", title: "JobNo" },
                    { data: "BookingRefNo", title: "Booking" },
                    { data: "CustCode", title: "Customer" },
                    { data: "RefNo", title: "Container.No" },
                    { data: "PoNo", title: "Vender.Inv" },
                    { data: "ApproveRef", title: "Approve.Ref" },
                    { data: "PaymentRef", title: "Payment.Ref" },
                    {
                        data: "Amt", title: "Amount",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "AmtVat", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "AmtTax50Tavi", title: "Tax",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    },
                    {
                        data: "Total", title: "Net",
                        render: function (data) {
                            return ShowNumber(data,2);
                        }
                    }
                ],
                responsive: true,
                destroy:true
            });
            //ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                SetSelect('#tbHeader', this);
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                $('#txtApproveRef').val(data.ApproveRef);
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'acc/expense?BranchCode=' + data.BranchCode + '&DocNo=' + data.DocNo + '&Job=' + data.JobNo +'&BookNo='+ data.BookingRefNo +'&Item=' + data.BookingItemNo,'','');
            });
        });
    }
    function EntryExpense() {
        window.open(path + 'acc/expense', '', '');
    }
    function PrintData() {
        window.open(path + 'acc/formexpense?Branch=' + $('#txtBranchCode').val() + '&Code=' + $('#txtApproveRef').val(), '', '');
    }
</script>