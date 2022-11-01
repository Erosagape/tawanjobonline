@Code
    ViewData("Title") = "Planing"
End Code
<div class="row">
    <div class="col-sm-2">
        <label id="lblBranchCode">Branch</label>
    </div>
    <div class="col-sm-4" style="display:flex;">
        <input type="text" id="txtBranchCode" style="width:20%;" class="form-control" value="@ViewBag.PROFILE_DEFAULT_BRANCH" disabled />
        <input type="text" id="txtBranchName" class="form-control" value="@ViewBag.PROFILE_DEFAULT_BRANCH_NAME" disabled />
    </div>
    <div class="col-sm-2">
        <label id="lblDateBy">Select Date</label>
    </div>
    <div class="col-sm-4">
        <select id="txtDateBy" class="form-control dropdown">
            <option selected value="j.DutyDate">Inspection Date</option>
            <option value="j.DocDate"> Open Date</option>
            <option value="j.ConfirmDate"> Confirm Date</option>
        </select>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblFromDate"> From Date</label>
    </div>
    <div class="col-sm-4">
        <input type="date" id="txtDateFrom" class="form-control" />
    </div>
    <div class="col-sm-2">
        <label id="lblToDate">To Date</label>
    </div>
    <div class="col-sm-4">
        <input type="date" id="txtDateTo" class="form-control" />
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblJobType"> Job Type</label>
    </div>
    <div class="col-sm-4">
        <select id="txtJobType" class="form-control dropdown"></select>
    </div>
    <div class="col-sm-2">
        <label id="lblShipBy"> Ship By</label>
    </div>
    <div class="col-sm-4">
        <select id="txtShipBy" class="form-control dropdown"></select>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblCustCode"> Cust Code</label>
    </div>
    <div class="col-sm-4" style="display:flex">
        <input type="text" id="txtCust" class="form-control" />
        <button onclick="SearchData('cust')" class="btn btn-default">...</button>
    </div>
    <div class="col-sm-2">
        <label id="lblConsCode"> Consignee Code</label>
    </div>
    <div class="col-sm-4" style="display:flex">
        <input type="text" id="txtCons" class="form-control" />
        <button onclick="SearchData('cons')" class="btn btn-default">...</button>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblShipping"> Shipping</label>
    </div>
    <div class="col-sm-4" style="display:flex">
        <input type="text" id="txtShipping" class="form-control" />
        <button onclick="SearchData('shipping')" class="btn btn-default">...</button>
    </div>
    <div class="col-sm-2">
        <label id="lblCS"> CS</label>
    </div>
    <div class="col-sm-4" style="display:flex">
        <input type="text" id="txtCS" class="form-control" />
        <button onclick="SearchData('cs')" class="btn btn-default">...</button>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblAgent"> Agent</label>
    </div>
    <div class="col-sm-4" style="display:flex">
        <input type="text" id="txtAgent" class="form-control" />
        <button onclick="SearchData('agent')" class="btn btn-default">...</button>
    </div>
    <div class="col-sm-2">
        <label id="lblTransport"> Transport</label>
    </div>
    <div class="col-sm-4" style="display:flex">
        <input type="text" id="txtTransport" class="form-control" />
        <button onclick="SearchData('transport')" class="btn btn-default">...</button>
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <label id="lblHBL"> HAWB / BL</label>
    </div>
    <div class="col-sm-4">
        <input type="text" id="txtHBL" class="form-control" />
    </div>
    <div class="col-sm-2">
        <label id="lblMBL"> MAWB / BL</label>
    </div>
    <div class="col-sm-4">
        <input type="text" id="txtMBL" class="form-control" />
    </div>
</div>

<div class="row">
    <div class="col-sm-2">
        <label id="lblFilter"> Filter</label>
    </div>
    <div class="col-sm-4">
        <select id="txtShow" class="form-control dropdown">
            <option selected value="">N/A</option>
            <option value="Unclear"> Un-clear</option>
            <option value="Unbill"> Un-billed</option>
            <option value="Billed"> Billed</option>
            <option value="Cancel"> Cancelled</option>
        </select>
    </div>
    <div class="col-sm-2">
        <label id="lblStatus"> Status</label>
    </div>
    <div class="col-sm-4">
        <select id="txtStatus" class="form-control dropdown">
        </select>
    </div>
</div>
<a href="#" class="btn btn-info" id="btnPrnJob" onclick="PrintReport()">
    <i class="fa fa-lg fa-print"><b>View Data</b></i>
</a>
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    SetEvents();

    function SetEvents() {
        let lists = 'JOB_TYPE=#txtJobType,SHIP_BY=#txtShipBy,JOB_STATUS=#txtStatus';
        loadCombos(path, lists);
        SetListOfValues(function (r) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Search Customer', r, 3);
            CreateLOV(dv, '#frmSearchCons', '#tbCons', 'Search Consignee', r, 3);
            CreateLOV(dv, '#frmSearchShipping', '#tbShipping', 'Search Shipping', r, 2);
            CreateLOV(dv, '#frmSearchCS', '#tbCS', 'Search CS', r, 2);
            CreateLOV(dv, '#frmSearchAgent', '#tbAgent', 'Search Agent', r, 2);
            CreateLOV(dv, '#frmSearchTransport', '#tbTransport', 'Search Transport', r, 2);
        });
    }
    function PrintReport() {
        var str = '?Branch=' + $('#txtBranchCode').val();
        if($('#txtDateFrom').val() !== '') {
            str += '&DateFrom=' + CDateEN($('#txtDateFrom').val());
        }
        if ($('#txtDateTo').val() !== '') {
            str += '&DateTo=' + CDateEN($('#txtDateTo').val());
        }
        if ($('#txtDateBy').val() !== '') {
            str += '&DateBy=' + $('#txtDateBy').val();
        }
        if ($('#txtJobType').val() !== '') {
            str += '&JobType=' + $('#txtJobType').val();
        }
        if ($('#txtShipBy').val() !== '') {
            str += '&ShipBy=' + $('#txtShipBy').val();
        }
        if ($('#txtCust').val() !== '') {
            str += '&Cust=' + $('#txtCust').val();
        }
        if ($('#txtCons').val() !== '') {
            str += '&Cons=' + $('#txtCons').val();
        }
        if ($('#txtShipping').val() !== '') {
            str += '&Shipping=' + $('#txtShipping').val();
        }
        if ($('#txtCS').val() !== '') {
            str += '&CS=' + $('#txtCS').val();
        }
        if ($('#txtAgent').val() !== '') {
            str += '&Agent=' + $('#txtAgent').val();
        }
        if ($('#txtTransport').val() !== '') {
            str += '&Transport=' + $('#txtTransport').val();
        }
        if ($('#txtHBL').val() !== '') {
            str += '&HBL=' + $('#txtHBL').val();
        }
        if ($('#txtMBL').val() !== '') {
            str += '&MBL=' + $('#txtMBL').val();
        }
        if ($('#txtShow').val() !== '') {
            str += '&Show=' + $('#txtShow').val();
        }
        if ($('#txtStatus').val() !== '') {
            str += '&Status=' + $('#txtStatus').val();
        }
        window.open(path + 'Tracking/Planload' + str, '', '');
    }
    function SearchData(type) {
        switch (type) {
            case 'cust':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', function (dr) {
                    $('#txtCust').val(dr.CustCode);
                });
                break;
            case 'cons':
                SetGridCompany(path, '#tbCons', '#frmSearchCons', function (dr) {
                    $('#txtCons').val(dr.CustCode);
                });
                break;
            case 'shipping':
                SetGridUser(path, '#tbShipping', '#frmSearchShipping', function (dr) {
                    $('#txtShipping').val(dr.UserID);
                });
                break;
            case 'cs':
                SetGridUser(path, '#tbCS', '#frmSearchCS', function (dr) {
                    $('#txtCS').val(dr.UserID);
                });
                break;
            case 'agent':
                SetGridVender(path, '#tbAgent', '#frmSearchAgent', function (dr) {
                    $('#txtAgent').val(dr.VenCode);
                });
                break;
            case 'transport':
                SetGridVender(path, '#tbTransport', '#frmSearchTransport', function (dr) {
                    $('#txtTransport').val(dr.VenCode);
                });
                break;
        }
    }
</script>
