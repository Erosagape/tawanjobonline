@Code
    ViewData("Title") = "Profit Report By Truck"

End Code
<div class="container">
    <h2>Profit Report By Truck</h2>
    <div class="row">
        <div class="col-sm-3">
            <label>Job Date From:</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="date" class="form-control" id="txtDateFrom" style="width:100%" />
            </div>
        </div>
        <div class="col-sm-3">
            <label id="txtDateFrom">Job Date To:</label>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="date" class="form-control" id="txtDateTo" style="width:100%" />
            </div>
        </div>
        <div class="col-sm-3">
            <label id="lblCSName" for="#txtCSCode">Support By :</label>
            <div style="display:flex;flex-direction:row">
                <input type="text" id="#txtCSCode" class="form-control" style="width:100%" disabled />
                <input type="button" id="btnBrowseCS" class="btn btn-default" value="..." onclick="SearchData('driver')" />
            </div>
        </div>
    </div>

    @*<div class="row">
            <div class="col-sm-6">
                <label id="lblCustomer" for="#txtCustCode">Im/Ex porter:</label>
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="#txtCustCode" class="form-control" style="width:100%" disabled />
                    <input type="button" id="btnBrowseCustomer" class="btn btn-default" value="..." onclick="SearchData('customer')" />
                </div>
            </div>

            <div class="col-sm-6">
                <label id="lblVender" for="#txtVenderCode">Transport Vender:</label>
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="#txtVenderCode" class="form-control" style="width:100%" disabled />
                    <input type="button" id="btnBrowseVender" class="btn btn-default" value="..." onclick="SearchData('vender')" />
                </div>
            </div>
        </div>*@

<div class="row">
    <div class="col-sm-6">
        <label id="lblCustCode">Im/Ex porter:</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" id="txtCustCode" class="form-control" style="width:130px" disabled />
            <input type="text" id="txtCustBranch" class="form-control" style="width:70px" disabled />
            <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
            <input type="text" id="txtCustName" class="form-control" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-6">
        <label id="lblVenCode">Transport Vender:</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtVenCode" style="width:20%" disabled />
            <button id="btnBrowseVend" class="btn btn-default" onclick="SearchData('vender')">...</button>
            <input type="text" class="form-control" id="txtVenName" style="width:100%" disabled />
        </div>
    </div>

</div>

    <input type="button" class="btn btn-success" value="Print" onclick="PrintData()" />
</div>
<script type="text/javascript" src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user = '@ViewBag.User';



    function PrintData() {
        let w = '?Form=';
        if ($('#txtDateFrom').val() !== '') {
            w += '&DateFrom=' + $('#txtDateFrom').val();
        }
        if ($('#txtDateTo').val() !== '') {
            w += '&DateTo=' + $('#txtDateTo').val();
        }
        if ($('#txtCSCode').val() !== '') {
            w += '&CSCode=' + $('#txtCSCode').val();
        }
        if ($('#txtCustCode').val() !== '') {
            w += '&CustCode=' + $('#txtCustCode').val();
        }
        if ($('#txtVenCode').val() !== '') {
            w += '&VenCode=' + $('#txtVenCode').val();
        }
        window.location.href = path + 'Report/TruckProfitDetail' + w;
    }

    function SearchData(type) {
        let w = '';
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'customer':
                SetGridCompanyByGroup(path, '#tbCust', 'NOTIFY_PARTY', '#frmSearchCust', ReadCustomer);
                break;
            case 'branch':
                SetGridBranch(path, '#tbBranch','#frmSearchBranch', ReadBranch);
                break;
            case 'job':
                w = '';
                if (userGroup == 'V') {
                    w += '&Vend=' + $('#txtVenderCode').val();
                }
                if (userGroup == 'C') {
                    w += '&CustCode=' + cust;
                }
                SetGridJob(path, '#tbJob', '#frmSearchJob', '?branch=' + $('#txtBranchCode').val() + w, ReadJobFull);
                break;
            case 'servunit':
                SetGridServUnitFilter(path, '#tbUnitS', '?Type=0', '#frmSearchUnitS', ReadUnit);
                break;
            case 'carunit':
                SetGridServUnitFilter(path, '#tbUnitC', '?Type=2', '#frmSearchUnitC', ReadCarUnit);
                break;
            case 'booking':
                w = '?Branch=' + $('#txtBranchCode').val();
                if (userGroup == 'V') {
                    w += '&Vend=' + $('#txtVenderCode').val();
                }
                if (userGroup == 'C') {
                    w += '&Cust=' + cust;
                }
                if ($('#txtJNo').val() !== '') {
                    w += '&Job=' + $('#txtJNo').val();
                }
                SetGridTransport(path, '#tbBook', '#frmSearchBook', w, ReadBooking);
                break;
            case 'servicecode1':
                SetGridSICode(path, '#tbServ1', '', '#frmSearchServ1', ReadService1);
                break;
            case 'servicecode2':
                SetGridSICode(path, '#tbServ2', '', '#frmSearchServ2', ReadService2);
                break;
            case 'location':
                SetGridTransportPrice(path, '#tbMainRoute', '#frmSearchMainRoute','?Vend=' + $('#txtVenderCode').val(), ReadMainRoute);
                break;
            case 'route':
                SetGridTransportPrice(path, '#tbRoute', '#frmSearchRoute', '?Vend=' + $('#txtVenderCode').val(), ReadRoute);
                break;
            case 'place1':
                SetGridLocation(path, '#tbPlace1', '#frmSearchPlace1', '?Place=1', ReadPickup);
                break;
            case 'place2':
                SetGridLocation(path, '#tbPlace2', '#frmSearchPlace2', '?Place=2', ReadDelivery);
                break;
            case 'place3':
                SetGridLocation(path, '#tbPlace3', '#frmSearchPlace3', '?Place=3', ReadReturn);
                break;
            case 'carlicense':
                SetGridCar(path, '#tbCar', '#frmSearchCar', ReadCar);
                break;
            case 'driver':
                SetGridEmployee(path, '#tbEmp', '#frmSearchEmp', ReadEmp);
                break;
        }
    }

    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
    function ReadVender(dt) {
        $('#txtVenCode').val(dt.VenCode);
        ShowVender(path, dt.VenCode, '#txtVenName');
    }
</script>



