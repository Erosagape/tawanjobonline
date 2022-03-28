@Code
    ViewData("Title") = "Create Shipments"
End Code
<form method="POST" action="@Url.Content("~")/JobOrder/PostCreateTransport">
    <div Class="row">
        <div Class="col-sm-2">
            Job Type
        </div>
        <div Class="col-sm-4">
            <select id="txtJobType" name="JobType" Class="form-control dropdown" onchange="CheckJobType()"></select>
        </div>
        <div Class="col-sm-2">
            Ship By
        </div>
        <div Class="col-sm-4">
            <select id="txtShipBy" name="ShipBy" Class="form-control dropdown"></select>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a onclick="SearchData('cust')">Customer</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Cust" id="txtCustCode" />
            <input type="text" id="txtCustName" Class="form-control" disabled />
        </div>
        <div Class="col-sm-2">
            <a onclick="SearchData('bill')">Billing To</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="BillTo" id="txtBillToCustCode" />
            <input type="text" id="txtBillToCustName" Class="form-control" disabled />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a onclick="SearchData('shipper')">Shipper </a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Shipper" id="txtShipperCode" />
            <input type="text" id="txtShipperName" Class="form-control" disabled />
        </div>
        <div Class="col-sm-2">
            <a onclick="SearchData('cons')">Consignee</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Consignee" id="txtConsigneeCode" />
            <input type="text" id="txtConsigneeName" Class="form-control" disabled />
        </div>

    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a onclick="SearchData('actshipper')">Notify Party</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Notify" id="txtActualShipperCode" />
            <input type="text" id="txtActualShipperName" Class="form-control" disabled />
        </div>
        <div Class="col-sm-2">
            <a onclick="SearchData('actcons')">Also Notify</a>
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="hidden" name="AlsoNotify" id="txtActualConsigneeCode" />
            <input type="text" id="txtActualConsigneeName" Class="form-control" disabled />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a onclick="SearchData('delivery')">Delivery Agent</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Delivery" id="txtDeliveryAgentCode" />
            <input type="hidden" name="DeliveryAddress" id="txtDeliveryAgentAddress" />
            <input type="text" name="DeliveryName" id="txtDeliveryAgentName" Class="form-control" disabled />
        </div>
        <div Class="col-sm-2">
            <a onclick="SearchData('forwarder')">Shipping Line</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Forwarder" id="txtForwarderCode" />
            <input type="text" id="txtForwarderName" Class="form-control" disabled />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Booking
        </div>
        <div Class="col-sm-4">
            <input type="text" name="BookingNo" id="txtBookingNo" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Cust Inv
        </div>
        <div Class="col-sm-4">
            <input type="text" name="CustInv" id="txtInvNo" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            H B/L
        </div>
        <div Class="col-sm-4">
            <input type="text" name="HouseBL" id="txtHAWB" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            M B/L
        </div>
        <div Class="col-sm-4">
            <input type="text" name="MasterBL" id="txtMAWB" Class="form-control" />
        </div>
    </div>

    <div Class="row">
        <div Class="col-sm-2">
            ETD
        </div>
        <div Class="col-sm-4">
            <input type="date" name="ETD" id="txtETDDate" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            ETA
        </div>
        <div Class="col-sm-4">
            <input type="date" name="ETA" id="txtETADate" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Place of Receive
        </div>
        <div Class="col-sm-4">
            <input type="text" name="PlaceReceive" id="txtReceivePlace" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Place of Loading
        </div>
        <div Class="col-sm-4">
            <input type="text" name="PlaceLoading" id="txtLoadingPlace" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Place of Delivery
        </div>
        <div Class="col-sm-4">
            <input type="text" name="PlaceDelivery" id="txtDeliveryPlace" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Place of Discharge
        </div>
        <div Class="col-sm-4">
            <input type="text" name="PlaceDischarge" id="txtDischargePlace" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Local Vessel
        </div>
        <div Class="col-sm-4">
            <input type="text" name="Vessel" id="txtMVesselName" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Ocean Vessel
        </div>
        <div Class="col-sm-4">
            <input type="text" name="MVessel" id="txtVesselName" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Freight And Charges
        </div>
        <div Class="col-sm-4">
            <select name="FreightCondition" id="txtFreightType" Class="form-control dropdown">
                <option> PREPAID</option>
                <option> COLLECT</option>
                <option>AS ARRANGED</option>
            </select>
        </div>
        <div Class="col-sm-2">
            Freight Payable At
        </div>
        <div Class="col-sm-4">
            <input type="text" name="FreightPaymentBy" id="txtFreightPayAt" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a onclick="SearchData('transport')">Transport</a>
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="hidden" name="Transport" id="txtTransportCode" />
            <input type="text" id="txtTransportName" Class="form-control" disabled />
        </div>
        <div Class="col-sm-2">
            <a onclick="SearchData('unit')">No OF Container</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="number" name="ContQty" id="txtTotalContainer" Class="form-control" />
            <input type="text" name="ContUnit" id="txtContainerUnit" Class="form-control" disabled />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            No Of Original B/L
        </div>
        <div Class="col-sm-4">
            <select id="txtCountBL" name="BLNo" Class="form-control dropdown">
                <option value="3"> ORIGINAL</option>
                <option value="0"> SURRENDER</option>
                <option value=""> SEA WAYBILL</option>
            </select>
        </div>
        <div Class="col-sm-2">
            Measurement
        </div>
        <div Class="col-sm-4">
            <input type="number" name="M3" id="txtMeasureMent" Class="form-control" />
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Net Weight
        </div>
        <div Class="col-sm-4">
            <input type="number" name="NetWeight" id="txtNetWeight" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Gross Weight
        </div>
        <div Class="col-sm-4">
            <input type="number" name="GrossWeight" id="txtGrossWeight" Class="form-control" />
        </div>
    </div>

    <div Class="row">
        <div Class="col-sm-2">
            Branch Code
        </div>
        <div Class="col-sm-4">
            <select id="cboBranch" name="Branch" Class="form-control dropdown"></select>
        </div>
        <div Class="col-sm-2">
            Job No
        </div>
        <div Class="col-sm-4">
            <input type="text" name="Job" id="txtJNo" Class="form-control" disabled value="@ViewBag.JobNo" />
        </div>
    </div>
    <input type="submit" id="btnSave" Class="btn btn-success" value="Save Data" />
</form>
@ViewBag.Message
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var job = '@ViewBag.JobNo';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    if (job !== '') {
        if (confirm("Do you want to show job?")) {
            window.location.href=path + 'JobOrder/ShowJob?BranchCode=' + branch + '&JNo=' + job;
        }
    }
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
                    $('#txtDeliveryAgentAddress').val(dr.EAddress1 +' '+ dr.EAddress2);
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