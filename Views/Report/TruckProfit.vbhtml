@Code
    ViewData("Title") = "Profit Report By Truck"

End Code
<div class="container">
    <h2>Profit Report By Truck</h2>
    <div class="row">
        <div class="col-sm-2">
            Job Date From
        </div>
        <div class="col-sm-2">
            <input type="date" id="txtDateFrom" class="form-control" />
        </div>
        <div class="col-sm-2">
            Job Date To
        </div>
        <div class="col-sm-2">
            <input type="date" id="txtDateTo" class="form-control" />
        </div>
        <div class="col-sm-2">
            CS
        </div>
        <div class="col-sm-2">
            <input type="text" id="txtCSCode" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Im/Ex porter
        </div>
        <div class="col-sm-3">
            <input type="text" id="txtCustCode" class="form-control" />
        </div>
        <div class="col-sm-2">
            Transport Vender
        </div>
        <div class="col-sm-3">
            <input type="text" id="txtVenCode" class="form-control" />
        </div>
    </div>
    <input type="button" class="btn btn-success" value="Print" onclick="PrintData()" />
</div>
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
</script>


