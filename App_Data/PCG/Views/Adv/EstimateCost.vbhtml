@Code
    ViewBag.Title = "CS JOB"
End Code
<!-- HTML CONTROLS -->
<div class="row">
    <div class="col-sm-6">
        <label id="lblBranch">Branch</label>
        <br />
        <div style="display:flex">
            <input type="text" class="form-control" style="width:60px" id="txtBranchCode" disabled />
            <input type="button" class="btn btn-default" id="btnBrowseBranch" value="..." onclick="SearchData('branch')" />
            <input type="text" class="form-control" style="width:100%" id="txtBranchName" disabled />
        </div>
    </div>
    <div class="col-sm-4">
        <label id="lblJNo" style="color:red;" onclick="OpenJob()">Job Number</label>
        <br />
        <div style="display:flex">
            <input type="text" id="txtJNo" class="form-control">
            <input type="button" class="btn btn-default" id="btnBrowseJob" value="..." onclick="SearchData('job')" />
        </div>
    </div>
    <div class="col-sm-2">
        <br />
        <button id="btnAutoEntry" class="btn btn-primary" onclick="LoadFromQuo()">Load from Quotation</button>
        <button id="btnAutoEntryC" class="btn btn-warning" onclick="LoadFromClr()">Load from Clearing</button>
    </div>
</div>
<div class="row">
    <div class="col-sm-6">
        <label id="lblSICode" for="txtSICode">Code  :</label>
        <br />
        <div style="display:flex">
            <input type="text" id="txtSICode" class="form-control" style="width:100px" />
            <input type="button" id="btnBrowseS" class="btn btn-default" value="..." onclick="SearchData('service')" />
            <input type="text" id="txtSDescription" class="form-control" style="width:100%" />
        </div>
    </div>
    <div class="col-sm-4">
        <label id="lblRemark">Remark :</label>
        <br />
        <div style="display:flex">
            <input type="text" id="txtTRemark" class="form-control">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblStatus">Status :</label>
        <br />
        <div style="display:flex">
            <select id="txtStatus" class="form-control dropdown">
                <option value="R">Required</option>
                <option value="O">Optional</option>
            </select>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblAmount">Amount :</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmountCharge" class="form-control" value="0.00" onchange="CalTotal()">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblCurrency">Currency:</label>        
        <br />
        <div style="display:flex">
            <input type="text" id="txtCurrencyCode" class="form-control" disabled />
            <input type="button" id="btnBrowseC" class="btn btn-default" value="..." onclick="SearchData('curr')" />
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblExchangeRate">Exchange Rate:</label>        
        <br />
        <div style="display:flex">
            <input type="number" id="txtExchangeRate" class="form-control" value="0.00" onchange="CalTotal()">
        </div>
    </div>

    <div class="col-sm-2">
        <label id="lblQty">Qty:</label>        
        <br />
        <div style="display:flex">
            <input type="number" id="txtQty" class="form-control" value="0.00" onchange="CalTotal()">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblUnit">Unit:</label>        
        <br />
        <div style="display:flex">
            <input type="text" id="txtQtyUnit" class="form-control" disabled />
            <input type="button" id="btnBrowseU" class="btn btn-default" value="..." onclick="SearchData('unit')" />
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblTotal">Total :</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmtCal" class="form-control" value="0.00" disabled>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblVATRate">Vat Rate:</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmtVatRate" class="form-control" value="0.00" onchange="CalTotal()">
        </div>
    </div>
    <div class="col-sm-2">
        Vat:
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmtVat" class="form-control" value="0.00" onchange="SumTotal()">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblWHTRate">Wht Rate:</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmtWhtRate" class="form-control" value="0.00" onchange="CalTotal()">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblWHT">WHT</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmtWht" class="form-control" value="0.00" onchange="SumTotal()">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblNetTotal">Net Total:</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtAmtTotal" class="form-control" value="0.00">
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblGrandTotal">Grand Total :</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtTotal" class="form-control w3-red" style="font-weight:bold;" value="0.00" disabled>
        </div>
    </div>

</div>
<div id="dvCommand">
    <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="ClearData()">
        <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">New</b>
    </a>
    <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
        <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save</b>
    </a>
    <a href="#" class="btn btn-danger" id="btnDelete" onclick="DeleteData()">
        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
    </a>
    <a href="#" class="btn btn-primary" id="btnCopy" onclick="CopyData()">
        <i class="fa fa-lg fa-copy"></i>&nbsp;<b id="linkCopy">Copy From Job</b>
    </a>
    <input type="text" id="txtJobCopyFrom" value="" />
</div>
<p>
    <table id="tbData" class="table table-responsive">
        <thead>
            <tr>
                <th>Code</th>
                <th class="all">Description</th>
                <th class="desktop">Status</th>
                <th>JNo</th>
                <th>AmountCharge</th>
                <th>Clear.No</th>
                <th>AmountClear</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</p>
<div class="row">
    <div class="col-sm-3">
        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Pre-invoice</b>
        </a>
    </div>
    <div class="col-sm-3">
        <label id="lblCharge">Charge :</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtCharge" class="form-control w3-green" style="font-weight:bold;" value="0.00" disabled>
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblCost">Cost :</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtCost" class="form-control w3-orange" style="font-weight:bold;" value="0.00" disabled>
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblProfit">Profit :</label>
        <br />
        <div style="display:flex">
            <input type="number" id="txtProfit" class="form-control w3-yellow" style="font-weight:bold;" value="0.00" disabled>
        </div>
    </div>

</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let branch = getQueryString("BranchCode");
    let job = getQueryString("JNo");
    if (job !== '') {
        $('#txtBranchCode').val(branch);
        ShowBranch(path, branch, '#txtBranchName');
        $('#txtJNo').val(job);
        RefreshGrid();
    } else {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtJNo').focus();
    }
    ClearData();
    SetEvents();
    function SetEvents() {
        $('#txtSICode').keydown(function (event) {
            if (event.which == 13) {
                let branch = $('#txtBranchCode').val();
                let code = $('#txtSICode').val();
                let job = $('#txtJNo').val();
                ClearData();
                $('#txtSICode').val(code);
                CallBackQueryClearExp(path, branch, code, job, ReadData);
            }
        });
        $('#txtJNo').keydown(function (event) {
            if (event.which == 13) {
                RefreshGrid();
            }
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Job
            CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job List', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,2);
            //SICode
            CreateLOV(dv, '#frmSearchSICode', '#tbServ', 'Service Code', response, 2);
            //Service Unit
            CreateLOV(dv, '#frmSearchSUnit', '#tbSUnit', 'Service Unit', response, 2);
            //Currency
            CreateLOV(dv, '#frmSearchCurr', '#tbCurr', 'Currency', response, 2);
        });
    }
    //CRUD Functions used in HTML Java Scripts
    function DeleteData() {
        let branch = $('#txtBranchCode').val();
        let code = $('#txtSICode').val();
        let job = $('#txtJNo').val();
        ShowConfirm('Please confirm to delete', function (ask) {
            if (ask == false) return;
            $.get(path + 'adv/delclearexp?branch=' + branch + '&code=' + code + '&job=' + job, function (r) {
                ShowMessage(r.estimate.result);
                ClearData();
                RefreshGrid();
            });
        });
    }
    function ReadData(dr) {
        $('#txtBranchCode').val(dr.BranchCode);
        $('#txtJNo').val(dr.JNo);
        $('#txtSICode').val(dr.SICode);
        $('#txtSDescription').val(dr.SDescription);
        $('#txtTRemark').val(dr.TRemark);
        $('#txtAmountCharge').val(CDbl(dr.AmountCharge,4));
        $('#txtStatus').val(dr.Status);
        $('#txtCurrencyCode').val(dr.CurrencyCode);
        $('#txtExchangeRate').val(dr.ExchangeRate);
        $('#txtQty').val(dr.Qty);
        CalTotal();
        $('#txtQtyUnit').val(dr.QtyUnit);
        $('#txtAmtVatRate').val(dr.AmtVatRate);
        $('#txtAmtVat').val(dr.AmtVat);
        $('#txtAmtWhtRate').val(dr.AmtWhtRate);
        $('#txtAmtWht').val(dr.AmtWht);
        $('#txtAmtTotal').val(dr.AmtTotal);
        SumTotal();
    }
    function SaveData() {
        let obj = {
            BranchCode: $('#txtBranchCode').val(),
            JNo:$('#txtJNo').val(),
            SICode:$('#txtSICode').val(),
            SDescription:$('#txtSDescription').val(),
            TRemark:$('#txtTRemark').val(),
            AmountCharge:CNum($('#txtAmountCharge').val()),
            Status: $('#txtStatus').val(),
            CurrencyCode: $('#txtCurrencyCode').val(),
            ExchangeRate: $('#txtExchangeRate').val(),
            Qty: $('#txtQty').val(),
            QtyUnit: $('#txtQtyUnit').val(),
            AmtVatRate: $('#txtAmtVatRate').val(),
            AmtVat: $('#txtAmtVat').val(),
            AmtWhtRate: $('#txtAmtWhtRate').val(),
            AmtWht: $('#txtAmtWht').val(),
            AmtTotal: $('#txtAmtTotal').val()
        };
        if (obj.SICode != "") {
            ShowConfirm('Please confirm to save', function (ask) {
                if (ask == false) return;
                let jsonText = JSON.stringify({ data: obj });
                //alert(jsonText);
                $.ajax({
                    url: "@Url.Action("SetClearExp", "Adv")",
                    type: "POST",
                    contentType: "application/json",
                    data: jsonText,
                    success: function (response) {
                        if (response.result.data != null) {
                            $('#txtSICode').val(response.result.data);
                            $('#txtSICode').focus();
                        }
                        RefreshGrid();
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
    function ClearData() {
        //$('#txtJNo').val('');
        $('#txtSICode').val('');
        $('#txtSDescription').val('');
        $('#txtTRemark').val('');
        $('#txtAmountCharge').val('0.00');
        $('#txtStatus').val('R');
        $('#txtCurrencyCode').val('THB');
        $('#txtExchangeRate').val('1');
        $('#txtQty').val('1');
        $('#txtQtyUnit').val('');
        $('#txtAmtCal').val('0.00');
        $('#txtAmtVatRate').val('0');
        $('#txtAmtVat').val('0.00');
        $('#txtAmtWhtRate').val('0');
        $('#txtAmtWht').val('0.00');
        $('#txtAmtTotal').val('0.00');
    }
    function RefreshGrid() {
        let w = '?Branch=' + $('#txtBranchCode').val();
        if ($('#txtJNo').val() !== '') {
            w += '&Job=' + $('#txtJNo').val();
        }
        $.get(path + 'Adv/GetClearExpReport' + w, function (r) {
            if (r.estimate.data.length == 0) {
                $('#tbData').DataTable().clear().draw();
                return;
            }
            let tot = 0;
            let chg = 0;
            let cost = 0;
            for (let row of r.estimate.data) {
                tot += Number(row.AmtTotal);
                if (row.IsExpense == 1) {
                    cost += Number(row.AmtTotal);
                } else {
                    chg += Number(row.AmtTotal);
                }
            }
            $('#txtCharge').val(CDbl(chg, 2));
            $('#txtCost').val(CDbl(cost, 2));
            $('#txtProfit').val(CDbl(chg-cost, 2));
            $('#txtTotal').val(CDbl(tot,2));
            let tb= $('#tbData').dataTable({
                data: r.estimate.data,
                columns: [
                    { data: "SICode", title: "Code" },
                    {
                        data: null, title: "Name",
                        render: function (data) {
                            return data.SDescription + ' / ' + data.Qty + 'x'+ data.QtyUnit;
                        }
                    },
                    {
                        data: null, title: "Status",
                        render: function (data) {
                            switch (data.Status) {
                                case 'R':
                                    return 'Required';
                                case 'O':
                                    return 'Optional';
                                default:
                                    return 'N/A';
                            }
                        }
                    },
                    { data: "JNo", title: "Job No" },
                    {
                        data: "AmtTotal", title: "Charge",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "ClrNo", title: "Clearing No" },
                    {
                        data: "CostAmount", title: "Clear.Amt",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    }
                ],
                destroy: true,
                responsive: true
                , pageLength: 100
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbData');
            $('#tbData tbody').on('click', 'tr', function () {
                SetSelect('#tbData', this);
                row = $('#tbData').DataTable().row(this).data(); //read current row selected
                ClearData();
                ReadData(row);
            });
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'code':
                RefreshGrid();
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'service':
                SetGridSICodeFilter(path, '#tbServ', '', '#frmSearchSICode', ReadService);
                break;
            case 'job':
                SetGridJob(path, '#tbJob', '#frmSearchJob','', ReadJob);
                break;
            case 'unit':
                SetGridServUnit(path, '#tbSUnit', '#frmSearchSUnit', ReadUnit);
                break;
            case 'curr':
                SetGridCurrency(path, '#tbCurr', '#frmSearchCurr', ReadCurrency);
                break;
        }
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
    }
    function ReadUnit(dt) {
        $('#txtQtyUnit').val(dt.UnitType);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }
    function ReadJob(dt) {
        $('#txtJNo').val(dt.JNo);
        RefreshGrid();
    }
    function ReadService(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSDescription').val(dt.NameThai);
        $('#txtTRemark').val(dt.NameEng);
        if ($('#txtCurrencyCode').val() == '') {
            $('#txtCurrencyCode').val(dt.CurrencyCode);
        }
        $('#txtQtyUnit').val(dt.UnitCharge);
        $('#txtAmountCharge').val(CNum(dt.StdPrice));
        if (dt.IsTaxCharge == 1) {
            $('#txtAmtVatRate').val(CDbl(CNum('@ViewBag.PROFILE_VATRATE')*100,0));
        }
        if (dt.Is50Tavi == 1) {
            $('#txtAmtWhtRate').val(CNum(dt.Rate50Tavi));
        }
        CalTotal();
    }
    function CalTotal() {
        let amtbase = CNum($('#txtAmountCharge').val());
        let excrate = CNum($('#txtExchangeRate').val());
        let qty = CNum($('#txtQty').val());
        let amtcal = (amtbase * excrate) * qty;
        $('#txtAmtCal').val(CDbl(amtcal, 2));
        let vatrate = CNum($('#txtAmtVatRate').val()) * 0.01;
        let vat = amtcal * vatrate;
        $('#txtAmtVat').val(CDbl(vat, 2));
        let whtrate = CNum($('#txtAmtWhtRate').val()) * 0.01;
        let wht = amtcal * whtrate;
        $('#txtAmtWht').val(CDbl(wht, 2));
        SumTotal();
    }
    function SumTotal() {
        let amtbase = CNum($('#txtAmtCal').val());
        let amtvat = CNum($('#txtAmtVat').val());
        let amtwht = CNum($('#txtAmtWht').val());
        $('#txtAmtTotal').val(CDbl(amtbase + amtvat - amtwht,2));
    }
    function CopyData() {
        if ($('#txtJobCopyFrom').val() == '') {
            ShowMessage('Please enter job to use for copy data',true);
            return;
        }
        let w = $('#txtBranchCode').val() + '|' + $('#txtJobCopyFrom').val() + '=' + $('#txtBranchCode').val() + '|' + $('#txtJNo').val();
        $.get(path + 'Adv/CopyClearExp?cliteria=' + w, function (msg) {
            RefreshGrid();
            ShowMessage(msg);
        });
    }
    function LoadFromQuo() {
        $.get(path + 'Adv/GetClearExpFromQuo?Branch=' + $('#txtBranchCode').val() + '&Job=' + $('#txtJNo').val())
        .done(function (r) {
            if (r.estimate.data.length > 0) {
                RefreshGrid();
            }
        });
    }
    function LoadFromClr() {
        $.get(path + 'Clr/GetClearExpFromClr?Branch=' + $('#txtBranchCode').val() + '&Job=' + $('#txtJNo').val())
        .done(function (r) {
            if (r.estimate.data.length > 0) {
                RefreshGrid();
            }
        });
    }
    function OpenJob() {
        window.open(path + 'JobOrder/ShowJob?BranchCode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }

    function PrintData() {
        window.open(path + 'Adv/FormEstimate?branch=' + $('#txtBranchCode').val() + '&job=' + $('#txtJNo').val());
    }
</script>