@Code
    ViewData("Title") = "Create Shipments"
End Code
<form method="POST">
    <div class="row">
        <div class="col-sm-2">
            Job Type
        </div>
        <div class="col-sm-4">
            <select id="txtJobType" name="JobType" class="form-control dropdown" onchange="CheckJobType()"></select>
        </div>
        <div class="col-sm-2">
            Ship By
        </div>
        <div class="col-sm-4">
            <select id="txtShipBy" name="ShipBy" class="form-control dropdown"></select>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Customer
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Cust" id="txtCustCode" />
            <input type="text" id="txtCustName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('cust')">...</button>
        </div>
        <div class="col-sm-2">
            Billing To
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="BillTo" id="txtBillToCustCode" />
            <input type="text" id="txtBillToCustName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('bill')">...</button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Shipper
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Shipper" id="txtShipperCode" />
            <input type="text" id="txtShipperName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('shipper')">...</button>
        </div>
        <div class="col-sm-2">
            Actual Shipper
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Notify" id="txtActualShipperCode" />
            <input type="text" id="txtActualShipperName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('actshipper')">...</button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Consignee
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Consignee" id="txtConsigneeCode" />
            <input type="text" id="txtConsigneeName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('cons')">...</button>
        </div>
        <div class="col-sm-2">
            Actual Consignee
        </div>
        <div class="col-sm-4" style="display:flex">
            <input type="hidden" name="AlsoNotify" id="txtActualConsigneeCode" />
            <input type="text" id="txtActualConsigneeName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('actcons')">...</button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Delivery Agent
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Delivery" id="txtDeliveryAgentCode" />
            <input type="text" id="txtDeliveryAgentName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('delivery')">...</button>
        </div>
        <div class="col-sm-2">
            Freight And Charges
        </div>
        <div class="col-sm-4">
            <input type="text" name="FreightType" id="txtFreightType" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Cust Inv
        </div>
        <div class="col-sm-4">
            <input type="text" name="CustInv" id="txtInvNo" class="form-control" />
        </div>
        <div class="col-sm-2">
            Booking
        </div>
        <div class="col-sm-4">
            <input type="text" name="BookingNo" id="txtBookingNo" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            ETD
        </div>
        <div class="col-sm-4">
            <input type="date" name="ETD" id="txtETDDate" class="form-control" />
        </div>
        <div class="col-sm-2">
            ETA
        </div>
        <div class="col-sm-4">
            <input type="date" name="ETA" id="txtETADate" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            B/L
        </div>
        <div class="col-sm-4">
            <input type="text" name="HouseBL" id="txtHAWB" class="form-control" />
        </div>
        <div class="col-sm-2">
            Master B/L
        </div>
        <div class="col-sm-4">
            <input type="text" name="MasterBL" id="txtMAWB" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Local Vessel
        </div>
        <div class="col-sm-4">
            <input type="text" name="Vessel" id="txtVesselName" class="form-control" />
        </div>
        <div class="col-sm-2">
            Ocean Vessel
        </div>
        <div class="col-sm-4">
            <input type="text" name="MVessel" id="txtMVesselName" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Shipping Line
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Forwarder" id="txtForwarderCode" />
            <input type="text" id="txtForwarderName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('forwarder')">...</button>
        </div>
        <div class="col-sm-2">
            Transport
        </div>
        <div class="col-sm-4" style="display:flex">
            <input type="hidden" name="Transport" id="txtTransportCode" />
            <input type="text" id="txtTransportName" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('transport')">...</button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            No OF Container
        </div>
        <div class="col-sm-4" style="display:flex;">
            <input type="number" name="ContQty" id="txtTotalContainer" class="form-control" />
            <input type="text" name="ContUnit" id="txtContainerUnit" class="form-control" disabled />
            <button class="btn btn-default" onclick="SearchData('unit')">...</button>
        </div>
        <div class="col-sm-2">
            Measurement
        </div>
        <div class="col-sm-4">
            <input type="number" name="M3" id="txtMeasureMent" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Net Weight
        </div>
        <div class="col-sm-4">
            <input type="number" name="NetWeight" id="txtNetWeight" class="form-control" />
        </div>
        <div class="col-sm-2">
            Gross Weight
        </div>
        <div class="col-sm-4">
            <input type="number" name="GrossWeight" id="txtGrossWeight" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Place of Receive
        </div>
        <div class="col-sm-4">
            <input type="text" name="PlaceReceive" id="txtReceivePlace" class="form-control" />
        </div>
        <div class="col-sm-2">
            Place of Loading
        </div>
        <div class="col-sm-4">
            <input type="text" name="PlaceLoading" id="txtLoadingPlace" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Place of Delivery
        </div>
        <div class="col-sm-4">
            <input type="text" name="PlaceDelivery" id="txtDeliveryPlace" class="form-control" />
        </div>
        <div class="col-sm-2">
            Place of Discharge
        </div>
        <div class="col-sm-4">
            <input type="text" name="PlaceDischarge" id="txtDischargePlace" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Branch Code
        </div>
        <div class="col-sm-4">
            <select id="cboBranch" name="Branch" class="form-control dropdown"></select>
        </div>
        <div class="col-sm-2">
            Job No
        </div>
        <div class="col-sm-4">
            <input type="text" name="Job" id="txtJNo" class="form-control" disabled value="@ViewBag.JobNo" />
        </div>
    </div>
    <input type="submit" id="btnSave" class="btn btn-success" value="Save Data" />
    @ViewBag.Message
</form>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    loadBranch(path);

    let list = 'JOB_TYPE=#txtJobType,';
    list += 'SHIP_BY=#txtShipBy';
    loadCombos(path, list);

    let jt = '';
    function CheckJobType() {
        if (jt !== $('#txtJobType').val()) {
            jt = $('#txtJobType').val();
            loadShipByByType(path, jt, '#txtShipBy');
            return;
        }
        return;
    }

    SetListOfValues((r) => {
        let dv = document.getElementById("dvLOVs");
        CreateLOV(dv, '#dvCustomer', '#tbCustomer', 'Customers', r, 3);
        CreateLOV(dv, '#dvBillTo', '#tbBillTo', 'Bill To', r, 3);
        CreateLOV(dv, '#dvShipper', '#tbShipper', 'Shipper', r, 3);
        CreateLOV(dv, '#dvActShipper', '#tbActShipper', 'Actual Shipper', r, 3);
        CreateLOV(dv, '#dvConsignee', '#tbConsignee', 'Consignee', r, 3);
        CreateLOV(dv, '#dvActConsignee', '#tbActConsignee', 'Actual Consignee', r, 3);
        CreateLOV(dv, '#dvDeliveryAgent', '#tbDeliveryAgent', 'Delivery Agent', r, 3);
        CreateLOV(dv, '#dvAgent', '#tbAgent', 'Agent', r, 3);
        CreateLOV(dv, '#dvTransporter', '#tbTransporter', 'Transporter', r, 3);
        CreateLOV(dv, '#dvUnit', '#tbUnit', 'Unit', r, 2);
    });
    function SearchData(type) {
        switch (type) {
            case 'cust':
                SetGridCompany(path, '#tbCustomer', '#dvCustomer', (dr) => {
                    $('#txtCustCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtCustName').val(dr.NameEng);
                });
                break;
            case 'bill':
                SetGridCompany(path, '#tbBillTo', '#dvBillTo', (dr) => {
                    $('#txtBillToCustCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtBillToCustName').val(dr.NameEng);
                });
                break;
            case 'shipper':
                SetGridCompany(path, '#tbShipper', '#dvShipper', (dr) => {
                    $('#txtShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtShipperName').val(dr.NameEng);
                });
                break;
            case 'actshipper':
                SetGridCompany(path, '#tbActShipper', '#dvActShipper', (dr) => {
                    $('#txtActualShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtActualShipperName').val(dr.NameEng);
                });
                break;
            case 'cons':
                SetGridCompany(path, '#tbConsignee', '#dvConsignee', (dr) => {
                    $('#txtConsigneeCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtConsigneeName').val(dr.NameEng);
                });
                break;
            case 'actcons':
                SetGridCompany(path, '#tbActConsignee', '#dvActConsignee', (dr) => {
                    $('#txtActualConsigneeCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtActualConsigneeName').val(dr.NameEng);
                });
                break;
            case 'delivery':
                SetGridVender(path, '#tbDeliveryAgent', '#dvDeliveryAgent', (dr) => {
                    $('#txtDeliveryAgentCode').val(dr.VenCode);
                    $('#txtDeliveryAgentName').val(dr.English);
                });
                break;
            case 'forwarder':
                SetGridVender(path, '#tbAgent', '#dvAgent', (dr) => {
                    $('#txtForwarderCode').val(dr.VenCode);
                    $('#txtForwarderName').val(dr.English);
                });
                break;
            case 'transport':
                SetGridVender(path, '#tbTransporter', '#dvTransporter', (dr) => {
                    $('#txtTransportCode').val(dr.VenCode);
                    $('#txtTransportName').val(dr.English);
                });
                break;
            case 'unit':
                SetGridServUnit(path, '#tbUnit', '#dvUnit', (dr) => {
                    $('#txtContainerUnit').val(dr.UnitType);
                });
                break;
        }
    }
</script>