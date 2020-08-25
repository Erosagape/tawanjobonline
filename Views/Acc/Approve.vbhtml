@Code
    ViewBag.Title = "Approve Billing Payment"
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
            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('vender')">...</button>
            <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
        </div>
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
                    <th class="desktop">VenCode</th>
                    <th class="desktop">Customer</th>
                    <th class="desktop">Job</th>
                    <th class="all">Container</th>
                    <th class="desktop">Inv.No</th>
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
    <div class="col-sm-12">
        <label id="lblListApprove">Selected Document</label>
        : <br /><input type="text" id="txtListApprove" class="form-control" value="" disabled />
    </div>
</div>
<br />
<a href="#" class="btn btn-success" id="btnSave" onclick="ApproveData()">
    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkApprove">Approve</b>
</a>
<a href="#" class="btn btn-primary" id="btnHistory" onclick="ShowApprove()">
    <i class="fa fa-lg fa-search"></i>&nbsp;<b id="linkSearchApprove">Approve History</b>
</a>
<div id="dvApprove" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <b>List of Approved Documents</b>
            </div>
            <div class="modal-body">
                <table id="tbApprove" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>Approve Ref#</th>
                            <th>Approve Date</th>
                            <th>Vender Ref#</th>
                            <th>Payment Ref#</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="modal-footer">
                <div style="float:left">
                    Set Payment Ref# <input type="text" id="txtPaymentRef" />
                    <input type="hidden" id="txtRefNo" />
                    <button class="btn btn-success" onclick="SetPayRef()">Save</button>
                </div>
                <button class="btn btn-danger" data-dismiss="modal">X</button>
            </div>
        </div>
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
    function SetGridApprove() {
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
        w = w + '&currency=' + $('#txtCurrencyCode').val();
        w = w + '&Type=APP&Status=Y';
        $.get(path + 'acc/getpaymentapprove?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.payment.header.length == 0) {
                $('#tbApprove').DataTable().clear().draw();
                if(isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.payment.header;
            $('#tbApprove').DataTable().destroy();
            $('#tbApprove').empty();
            let tb=$('#tbApprove').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "ApproveRef", title: "Approve.Ref#" },
                    {
                        data: "ApproveDate", title: "Appr.Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "PoNo", title: "Vender Ref#" },
                    { data: "PaymentRef", title: "Payment Ref#" }
                ],
                responsive: true,
                destroy:true
            });
            $('#tbApprove tbody').on('click', 'tr', function () {
                SetSelect('#tbApprove', this);
                let data = $('#tbApprove').DataTable().row(this).data(); //read current row selected                
                $('#txtRefNo').val(data.ApproveRef);
                $('#txtPaymentRef').val(data.PaymentRef);
            });
            $('#tbApprove tbody').on('dblclick', 'tr', function () {
                let data = $('#tbApprove').DataTable().row(this).data(); //read current row selected
                window.open(path + 'acc/formexpense?Branch=' + $('#txtBranchCode').val() + '&Code=' + data.ApproveRef,'','');
            });
        });
    }
    function SetGridAdv(isAlert) {
        arr = [];
        ShowSummary();
        docno = '';

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
        w = w + '&currency=' + $('#txtCurrencyCode').val();
        w = w + '&Type=NOAPP';
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
                    {
                        data: "DocDate", title: "Due Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "VenCode", title: "Vender" },
                    { data: "CustCode", title: "Customer" },
                    { data: "JobNo", title: "Job Number" },
                    { data: "RefNo", title: "Container.No" },
                    { data: "PoNo", title: "Inv.No" },
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
                if ($(this).hasClass('selected') == true) {
                    $(this).removeClass('selected');
                    let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                    RemoveData(data); //callback function from caller
                    return;
                }
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                if (data.PoNo !== '') {
                    $(this).addClass('selected');
                    AddData(data); //callback function from caller
                } else {
                    ShowMessage('This Data have not yet billed by vender',true);
                }
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'acc/expense?BranchCode=' + data.BranchCode + '&DocNo=' + data.DocNo,'','');
            });
        });
    }

    function AddData(o) {
        arr.push(o);
        ShowSummary();
    }
    function RemoveData(o) {
        let idx = arr.indexOf(o);
        if (idx < 0) {
            return;
        }
        arr.splice(idx, 1);
        ShowSummary();
    }
    function ShowSummary() {
        let doc = '';
        list = [];

        for (let i = 0; i < arr.length; i++) {

            let o = arr[i];
            doc += (doc != '' ? ',' : '') + o.DocNo;
        }
        $('#txtListApprove').val(doc);
    }
    function ApproveData() {
        if ($('#txtVenCode').val() == '') {
            ShowMessage('Please Select Vendor', true);
            return;
        }
        if (arr.length < 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        let dataApp = [];
        dataApp.push(user);
        for (let i = 0; i < arr.length; i++) {
            if (dataApp.indexOf(arr[i].BranchCode + '|' + arr[i].DocNo) < 0) {
                dataApp.push(arr[i].BranchCode + '|' + arr[i].DocNo);
            }
        }
        let jsonString = JSON.stringify({ data: dataApp });
        $.ajax({
            url: "@Url.Action("ApproveExpense", "Acc")?Code=" + $('#txtVenCode').val(),
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                SetGridAdv(false);
                response ? ShowMessage("Approve Completed") : ShowMessage("Cannot Approve");
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
        return;
    }
    function ShowApprove() {
        $('#dvApprove').modal('show');
        SetGridApprove();
    }
    function SetPayRef() {
        $.get(path + 'Acc/SetPaymentRef?AppRef=' + $('#txtRefNo').val() + '&PayRef=' + $('#txtPaymentRef').val()).done(function (r) {
            ShowMessage(r);
        });
    }
</script>