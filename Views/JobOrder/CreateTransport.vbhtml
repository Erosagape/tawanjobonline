@Code
    ViewData("Title") = "Create Job"
End Code
<form id="form" method="POST" action="@Url.Content("~")/JobOrder/PostCreateTransport">
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
            <a href="../Master/Customers">Customers</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Cust" id="txtCustCode" />
            <input type="text" id="txtCustName" Class="form-control" disabled />
            <a onclick="SearchData('cust')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Customers">Billing To</a>            
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="BillTo" id="txtBillToCustCode" />
            <input type="text" id="txtBillToCustName" Class="form-control" disabled />
            <a class="btn btn-default" onclick="SearchData('bill')">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a href="../Master/Customers">Shipper</a>            
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Shipper" id="txtShipperCode" />
            <input type="text" id="txtShipperName" Class="form-control" disabled />
            <a onclick="SearchData('shipper')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Customers">Consignee</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Consignee" id="txtConsigneeCode" />
            <input type="text" id="txtConsigneeName" Class="form-control" disabled />
            <a onclick="SearchData('cons')" class="btn btn-default">...</a>
        </div>

    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a href="../Master/Customers">Notify</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Notify" id="txtActualShipperCode" />
            <input type="text" id="txtActualShipperName" Class="form-control" disabled />
            <a onclick="SearchData('actshipper')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Customers">Also Notify</a>
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="hidden" name="AlsoNotify" id="txtActualConsigneeCode" />
            <input type="text" id="txtActualConsigneeName" Class="form-control" disabled />
            <a onclick="SearchData('actcons')" class="btn btn-default">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a href="../Master/Venders">Delivery Agent</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Delivery" id="txtDeliveryAgentCode" />
            <input type="hidden" name="DeliveryAddress" id="txtDeliveryAgentAddress" />
            <input type="text" name="DeliveryName" id="txtDeliveryAgentName" Class="form-control" />
            <a class="btn btn-default" onclick="SearchData('delivery')">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Venders">Shipping Line</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Forwarder" id="txtForwarderCode" />
            <input type="text" id="txtForwarderName" Class="form-control" disabled />
            <a class="btn btn-default" onclick="SearchData('forwarder')">...</a>
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
            <a href="../Master/Venders">Transport</a>
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="hidden" name="Transport" id="txtTransportCode" />
            <input type="text" id="txtTransportName" Class="form-control" disabled />
            <a onclick="SearchData('transport')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            No's' of Containers
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="number" name="ContQty" id="txtTotalContainer" Class="form-control" />
            <input type="text" name="ContUnit" id="txtContainerUnit" Class="form-control" />
            <a onclick="SearchData('unit')" class="btn btn-default">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            No's Of Original B/L
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
            <input type="number" name="M3" id="txtMeasurement" Class="form-control" />
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
    <div class="row">
        <div class="col-sm-2">
            Container#<br /><input type="text" class="form-control" id="txtCTN" />
        </div>
        <div class="col-sm-2">
            Seal<br /><input type="text" class="form-control" id="txtSeal" />
        </div>
        <div class="col-sm-3">
            Qty<br />
            <div style="display:flex">
                <input type="text" class="form-control" id="txtQty" />
                <input type="text" class="form-control" id="txtUnit" />
            </div>
        </div>
        <div class="col-sm-2">
            N/W<br /><input type="text" class="form-control" id="txtNetW" />
        </div>
        <div class="col-sm-2">
            G/W<br /><input type="text" class="form-control" id="txtGrossW" />
        </div>
        <div class="col-sm-1">
            CBM<br /><input type="text" class="form-control" id="txtM3" />
        </div>
    </div>
    <a onclick="AddCont()" class="btn btn-warning">Add Details</a>
    <table id="tbContainers" class="table table-responsive">
        <thead>
            <tr>
                <th>No</th>
                <th>Qty</th>
                <th>Net Weight</th>
                <th>Gross Weight</th>
                <th>M3</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    <input type="hidden" name="ContList" id="ContainerList" />
    <input type="button" id="btnSave" Class="btn btn-success" onclick="return ValidateData()" value="Save Data" />
</form>
@ViewBag.Message
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var job = '@ViewBag.JobNo';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    if (job !== '') {
        window.location.href=path + 'JobOrder/Transport?BranchCode=' + branch + '&JNo=' + job;
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
                    $('#txtBillToCustCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtBillToCustName').val(dr.NameEng);
                    $('#txtShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtShipperName').val(dr.NameEng);
                    $('#txtActualShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtActualShipperName').val(dr.NameEng);
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
                    $('#txtActualConsigneeCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtActualConsigneeName').val(dr.NameEng);
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
    function AddCont() {
        if ($('#txtNetW').val() == '') {
            ShowMessage('Net Weight Must be input', true);
            return;
        }
        if ($('#txtGrossW').val() == '') {
            ShowMessage('Gross Weight Must be input', true);
            return;
        }
        if ($('#txtM3').val() == '') {
            ShowMessage('CBM Must be input', true);
            return;
        }
        if ($('#txtQty').val() == '') {
            ShowMessage('Quantity Must be input', true);
            return;
        }
        if ($('#txtUnit').val() == '') {
            ShowMessage('Unit Must be input', true);
            return;
        }
        let obj = $('#ContainerList').val();
        obj += $('#txtCTN').val();
        obj += '|' + $('#txtNetW').val();
        obj += '|' + $('#txtGrossW').val();
        obj += '|' + $('#txtM3').val();
        obj += '|' + $('#txtQty').val();
        obj += '|' + $('#txtUnit').val();
        obj += '|' + $('#txtSeal').val();
        obj += ';';
        $('#ContainerList').val(obj);
        let html = '<tr>';
        html += '<td>' + $('#txtCTN').val() + '/' + $('#txtSeal').val()+ '</td>';
        html += '<td>' + $('#txtQty').val() + ' ' + $('#txtUnit').val() + '</td>';
        html += '<td>' + $('#txtNetW').val() + '</td>';
        html += '<td>' + $('#txtGrossW').val() + '</td>';
        html += '<td>' + $('#txtM3').val() + '</td>';
        html += '</tr>';
        $('#tbContainers tbody').append(html);
        let val = Number($('#txtTotalContainer').val()) + 1;
        let m3 = Number($('#txtMeasurement').val()) + Number($('#txtM3').val());
        let netw = Number($('#txtNetWeight').val()) + Number($('#txtNetW').val());
        let grossw = Number($('#txtGrossWeight').val()) + Number($('#txtGrossW').val());
        $('#txtTotalContainer').val(val);
        $('#txtMeasurement').val(m3);
        $('#txtNetWeight').val(netw);
        $('#txtGrossWeight').val(grossw);
        //alert(val + ',' + netw + ',' + grossw);
    }
    function ValidateData() {
        if ($('#txtJobType').val() == '' || $('#txtShipBy').val() == '') {
            ShowMessage("Job Type And Ship By must have been chosen", true);
            if ($('#txtJobType').val() == '') $('#txtJobType').focus();
            if ($('#txtShipBy').val() == '') $('#txtShipBy').focus();
            return;
        }
        if ($('#txtCustCode').val() == '') {
            ShowMessage("Customer Must be chosen", true);
            SearchData('cust');
            return;
        }
        if ($('#txtBillToCustCode').val() == '') {
            ShowMessage("Billing's Place Must be chosen", true);
            SearchData('bill');
            return;
        }
        if ($('#txtShipperCode').val() == '') {
            ShowMessage("Shipper Must be chosen", true);
            SearchData('shipper');
            return;
        }
        if ($('#txtConsigneeCode').val() == '') {
            ShowMessage("Consignee Must be chosen", true);
            SearchData('cons');
            return;
        }
        if ($('#txtActualShipperCode').val() == '') {
            ShowMessage("Actual Shipper Must be chosen", true);
            SearchData('actshipper');
            return;
        }
        /*
        if ($('#txtActualConsigneeCode').val() == '') {
            ShowMessage("Actual Consignee Must be chosen", true);
            SearchData('actcons');
            return;
        }
        */
        /*
        if ($('#txtDeliveryAgentCode').val() == '') {
            ShowMessage("Delivery Agent Must be chosen", true);
            SearchData('delivery');
            return;
        }
        */
        if ($('#txtForwarderCode').val() == '') {
            ShowMessage("Shipping liner Must be chosen", true);
            SearchData('forwarder');
            return;
        }
        if ($('#txtBookingNo').val() == '') {
            ShowMessage("Booking No Must be chosen", true);
            return;
        }
        if ($('#txtInvNo').val() == '') {
            ShowMessage("Customer Inv.No Must be chosen", true);
            return;
        }
        if ($('#txtHAWB').val() == '') {
            ShowMessage("House BL/AWB Must be chosen", true);
            return;
        }
        if ($('#txtMAWB').val() == '') {
            ShowMessage("Master BL/AWB Must be chosen", true);
            return;
        }
        if ($('#txtETDDate').val() == '') {
            ShowMessage("ETD Must be chosen", true);
            return;
        }
        if ($('#txtETADate').val() == '') {
            ShowMessage("ETA Must be chosen", true);
            return;
        }
        if ($('#txtReceivePlace').val() == '') {
            ShowMessage("Place of receive Must be chosen", true);
            return;
        }
        if ($('#txtLoadingPlace').val() == '') {
            ShowMessage("Place of Loading Must be chosen", true);
            return;
        }
        if ($('#txtDeliveryPlace').val() == '') {
            ShowMessage("Place of Delivery Must be chosen", true);
            return;
        }
        if ($('#txtDischargePlace').val() == '') {
            ShowMessage("Place of Discharge Must be chosen", true);
            return;
        }
        if ($('#txtMVesselName').val() == '') {
            ShowMessage("Local vessel Must be chosen", true);
            return;
        }
        if ($('#txtVesselName').val() == '') {
            ShowMessage("Ocean vessel Must be chosen", true);
            return;
        }
        if ($('#txtFreightType').val() == '') {
            ShowMessage("Freight Type Must be chosen", true);
            return;
        }
        if ($('#txtFreightPayAt').val() == '') {
            ShowMessage("Freight Pay At Must be chosen", true);
            return;
        }
        if ($('#txtTransportCode').val() == '') {
            ShowMessage("Transport Code Must be chosen", true);
            SearchData('transport');
            return;
        }
        if ($('#txtTotalContainer').val() == '') {
            ShowMessage("Total Container Must be chosen", true);
            return;
        }
        if ($('#txtContainerUnit').val() == '') {
            ShowMessage("Container Unit Must be chosen", true);
            SearchData('unit');
            return;
        }
        if ($('#txtCountBL').val() == '') {
            ShowMessage("No's of B/L Must be chosen", true);
            return;
        }
        if ($('#txtMeasurement').val() == '') {
            ShowMessage("Measurement Must be chosen", true);
            return;
        }
        if ($('#txtNetWeight').val() == '') {
            ShowMessage("Net Weight Must be chosen", true);
            return;
        }
        if ($('#txtGrossWeight').val() == '') {
            ShowMessage("Gross Weight Must be chosen", true);
            return;
        }
        ShowConfirm("Are you sure to create by this information?", function (e) {
            if (e == true) {
                $('#form').submit();
            }
        });    
    }
</script>