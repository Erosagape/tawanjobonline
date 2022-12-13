@Code
    ViewData("Title") = "Create BL/AWB"
End Code
<form id="form" method="POST" action="@Url.Content("~")/JobOrder/PostCreateTransport">
    <input type="hidden" name="mode" id="txtMode" value="A" />
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
            <a href="../JobOrder/Quotation">Quotation</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Cust" id="txtCustCode" />
            <input type="text" id="txtQuotation" name="QuoNo" Class="form-control" />
            <a onclick="SearchData('quotation')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Country">Country</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Country" id="txtCountryCode" />
            <input type="hidden" name="PortCode" id="txtPortCode" />
            <input type="text" id="txtCountryName" Class="form-control" readonly />
            <a class="btn btn-default" onclick="SearchData('country')">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a href="../Master/Customers">Shipper</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Shipper" id="txtShipperCode" />
            <input type="text" id="txtShipperName" Class="form-control" readonly />
            <a onclick="SearchData('shipper')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Customers">Consignee</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Consignee" id="txtConsigneeCode" />
            <input type="text" id="txtConsigneeName" Class="form-control" readonly />
            <a onclick="SearchData('cons')" class="btn btn-default">...</a>
        </div>

    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a href="../Master/Customers">Notify</a>
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="hidden" name="Notify" id="txtActualShipperCode" />
            <input type="text" id="txtActualShipperName" Class="form-control" readonly />
            <a onclick="SearchData('actshipper')" class="btn btn-default">...</a>
        </div>
        <div Class="col-sm-2">
            <a href="../Master/Customers">Also Notify</a>
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="hidden" name="AlsoNotify" id="txtActualConsigneeCode" />
            <input type="text" id="txtActualConsigneeName" Class="form-control" readonly />
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
            <input type="text" id="txtForwarderName" Class="form-control" readonly />
            <a class="btn btn-default" onclick="SearchData('forwarder')">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Booking <input type="checkbox" onclick="SetAuto('#txtBookingNo')" /> Auto
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
            H B/L <input type="checkbox" onclick="SetAuto('#txtHAWB')" /> Auto
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
            Place of Loading
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="text" name="PlaceLoading" id="txtLoadingPlace" Class="form-control" />
            <a class="btn btn-default" onclick="SearchData('loadat')">...</a>
        </div>
        <div Class="col-sm-2">
            Place of Receive
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="text" name="PlaceReceive" id="txtReceivePlace" Class="form-control" />
            <a class="btn btn-default" onclick="SearchData('receiveat')">...</a>
        </div>

    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Place of Discharge
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="text" name="PlaceDischarge" id="txtDischargePlace" Class="form-control" />
            <a class="btn btn-default" onclick="SearchData('dischargeat')">...</a>
        </div>
        <div Class="col-sm-2">
            Place of Delivery
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="text" name="PlaceDelivery" id="txtDeliveryPlace" Class="form-control" />
            <a class="btn btn-default" onclick="SearchData('deliveryat')">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Ocean Vessel
        </div>
        <div Class="col-sm-4">
            <input type="text" name="Vessel" id="txtVesselName" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Local Vessel
        </div>
        <div Class="col-sm-4">
            <input type="text" name="MVessel" id="txtMVesselName" Class="form-control" />
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
        <div Class="col-sm-4" style="display:flex;">
            <input type="text" name="FreightPaymentBy" id="txtFreightPayAt" Class="form-control" />
            <a class="btn btn-default" onclick="SearchData('payableat')">...</a>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            <a href="../Master/Venders">Transport</a>
        </div>
        <div Class="col-sm-4" style="display:flex">
            <input type="hidden" name="Transport" id="txtTransportCode" />
            <input type="text" id="txtTransportName" Class="form-control" readonly />
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
            Commodity
        </div>
        <div Class="col-sm-4">
            <input type="text" name="InvProduct" id="txtInvProduct" Class="form-control" />
        </div>
        <div Class="col-sm-2">
            Shipping Mask
        </div>
        <div Class="col-sm-4">
            <textarea name="Remark" style="width:100%" id="txtRemark" Class="form-control-lg"></textarea>
        </div>
    </div>
    <div Class="row">
        <div Class="col-sm-2">
            Package Summary
        </div>
        <div Class="col-sm-4" style="display:flex">
            <textarea name="ProjectName" style="width:100%" id="txtProjectName" Class="form-control-lg"></textarea>
        </div>
        <div Class="col-sm-2">
            Package Qty
        </div>
        <div Class="col-sm-4" style="display:flex;">
            <input type="number" name="InvProductQty" id="txtInvProductQty" Class="form-control" />
            <input type="text" name="InvProductUnit" id="txtInvProductUnit" Class="form-control" />
            <a onclick="SearchData('unit2')" class="btn btn-default">...</a>
        </div>
    </div>
    <div class="panel" style="background-color:lightgreen;padding:5px 5px 5px 5px;font-weight:bold">
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
            <div Class="col-sm-4" style="display:flex;">
                <input type="text" name="Job" id="txtJNo" Class="form-control" value="@ViewBag.JobNo" readonly />
                <a class="btn btn-primary" onclick="SearchData('job')">Search</a>
                <a class="btn btn-warning" onclick="OpenJob()">View</a>

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
    </div>
    <div class="row">
        <div class="col-sm-3">
            Cut off SI<br />
            <div style="display:flex">
                <input type="date" name="LoadDate" id="txtSIDate" class="form-control" />
                <input type="time" name="EstDeliverTime" id="txtSITime" class="form-control" />
            </div>
        </div>
        <div class="col-sm-3">
            Cut off VGM<br />
            <div style="display:flex">
                <input type="date" name="EstDeliverDate" id="txtVGMDate" class="form-control" />
                <input type="time" name="ConfirmChqDate" id="txtVGMTime" class="form-control" />
            </div>
        </div>
        <div class="col-sm-3">
            CY/CFS Date<br />
            <div style="display:flex">
                <input type="date" name="CYDate" id="txtCYDate" class="form-control" />
            </div>
        </div>
        <div class="col-sm-3">
            Closing Date<br />
            <div style="display:flex">
                <input type="date" name="PackingDate" id="txtPackingDate" class="form-control" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            Cut off RTN<br />
            <div style="display:flex">
                <input type="date" name="FactoryDate" id="txtFactoryDate" class="form-control" />
                <input type="time" name="FactoryTime" id="txtFactoryTime" class="form-control" />
            </div>
        </div>
        <div class="col-sm-2">
            Return Date<br />
            <div style="display:flex">
                <input type="date" name="ReturnDate" id="txtReturnDate" class="form-control" />
            </div>
        </div>
        <div class="col-sm-2">
            Clear Port<br />
            <div style="display:flex">
                <input type="text" class="form-control" name="ClearPort" id="txtClearPort" />
                <a class="btn btn-default" onclick="SearchData('clearport')">...</a>
            </div>
        </div>
        <div class="col-sm-3">
            Return AT<br />
            <div style="display:flex">
                <input type="text" name="CYContact" id="txtCYContact" class="form-control" />
            </div>
        </div>
        <div class="col-sm-2">
            Mode
            <br />
            <select name="TransMode" id="txtTransMode" class="form-control dropdown">
                <option value="CY-CY">CY/CY</option>
                <option value="CY-CFS">CY/CFS</option>
                <option value="CFS-CY">CFS/CY</option>
                <option value="CFS-CFS">CFS/CFS</option>
            </select>
        </div>
    </div>
    <input type="hidden" name="fieldJobType" value="ShipBy" />
    <input type="hidden" name="ContList" id="ContainerList" />
    <input type="button" id="btnSave" Class="btn btn-success" onclick="return ValidateData()" value="Save Data" />
    <input class="btn btn-default w3-purple" type="reset" onclick="ClearCont()" value="New" />

    @ViewBag.Message
</form>
<a href="#" class="btn btn-info" id="btnPrint" onclick="PrintBooking()">
    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Form</b>
</a>
<select id="cboPrintForm">
    <option value="JO">Shipment Order</option>
    <option value="BA">Booking Confirmation (AIR)</option>
    <option value="BS">Booking Confirmation (SEA)</option>
    <option value="SP">Shipping Instruction</option>
    <option value="BLE">Bill of Lading - UGLOBE</option>
</select>
<div id="dvLOVs"></div>
<script type="text/javascript">
    /*---NOTE----
     ****This version checking for IMPORT or EXPORT is change from field jobtype to shipby for UGLOBE ONLY****
    -------------*/
    var path = '@Url.Content("~")';
    var job = '@ViewBag.JobNo';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    var arr = [];
    loadBranch(path);

    let list = 'JOB_TYPE=#txtJobType,';
    list += 'SHIP_BY=#txtShipBy';
    loadCombos(path, list);

    if (job !== '') {
        alert('@ViewBag.Message');
        $('#txtJNo').val(job);
        //window.location.href=path + 'JobOrder/Transport?BranchCode=' + branch + '&JNo=' + job;
        CallBackQueryJob(path, branch, job, function (dt) {
            if (dt.length > 0) {
                LoadJob(dt[0]);
            }
        });
    }

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
        CreateLOV(dv, '#dvJob', '#tbJob', 'Job', r, 3);
        CreateLOV(dv, '#dvShipper', '#tbShipper', 'Shipper', r, 3);
        CreateLOV(dv, '#dvActShipper', '#tbActShipper', 'Notify Party', r, 3);
        CreateLOV(dv, '#dvConsignee', '#tbConsignee', 'Consignee', r, 3);
        CreateLOV(dv, '#dvActConsignee', '#tbActConsignee', 'Also Notify', r, 3);
        CreateLOV(dv, '#dvDeliveryAgent', '#tbDeliveryAgent', 'Delivery Agent', r, 3);
        CreateLOV(dv, '#dvAgent', '#tbAgent', 'Agent', r, 3);
        CreateLOV(dv, '#dvTransporter', '#tbTransporter', 'Transporter', r, 3);
        CreateLOV(dv, '#dvPort', '#tbPort', 'Clear Port', r, 2);
        CreateLOV(dv, '#dvUnit', '#tbUnit', 'Container Unit', r, 2);
        CreateLOV(dv, '#dvUnit2', '#tbUnit2', 'Package Unit', r, 2);
        CreateLOV(dv, '#dvQuotation', '#tbQuotation', 'Quotation', r, 3);
        CreateLOV(dv, '#dvCountry', '#tbCountry', 'Country', r, 2);
        CreateLOV(dv, '#dvReceiveAt', '#tbReceiveAt', 'Place of Receive', r, 3);
        CreateLOV(dv, '#dvLoadAt', '#tbLoadAt', 'Place of Loading', r, 3);
        CreateLOV(dv, '#dvDeliveryAt', '#tbDeliveryAt', 'Place of Delivery', r, 3);
        CreateLOV(dv, '#dvDischargeAt', '#tbDischargeAt', 'Place of Discharge', r, 3);
        CreateLOV(dv, '#dvPayableAt', '#tbPayableAt', 'Freight Payable At', r, 3);
    });

    function GetParam() {
        let strParam = '?';
        strParam += 'Branch=' + branch;
        strParam += '&JType=' + $('#txtJobType').val();
        strParam += '&SBy=' + $('#txtShipBy').val();
        strParam += '&CustCode=' + $('#txtCustCode').val().split('|')[0];
        return strParam;
    }
    function LoadBooking(dt) {
        $.get(path + 'JobOrder/GetTransport?Branch='+ dt.BranchCode +'&Code=' + dt.BookingNo).done((r) => {
            if (r.transport.header.length > 0) {
                let h = r.transport.header[0];

                $.get(path + 'Master/GetCompany?Code=' + h.NotifyCode).done((r) => {
                    if (r.company.data.length > 0) {
                        let c = r.company.data[0];
                        $('#txtActualShipperCode').val(c.CustCode + '|' + c.Branch);
                        $('#txtActualShipperName').val(c.NameEng);
                    }
                });

                $('#txtTransportCode').val(h.VenderCode);
                ShowVenderEN(path, h.VenderCode, '#txtTransportName');

                $('#txtActualConsigneeCode').val(h.ReturnContact);
                ShowCustomerEN(path, h.ReturnContact.split('|')[0], h.ReturnContact.split('|')[1], '#txtActualConsigneeName');

                $('#txtTransMode').val(h.TransMode);
                $('#txtFreightType').val(h.PaymentCondition);
                $('#txtFreightPayAt').val(h.PaymentBy);

                $('#txtReceivePlace').val(h.CYPlace);
                $('#txtLoadingPlace').val(h.FactoryPlace);
                $('#txtDeliveryPlace').val(h.PackingPlace);
                $('#txtDischargePlace').val(h.ReturnPlace);

                $('#txtCYContact').val(h.CYContact);
                $('#txtCYDate').val(CDateEN(h.CYDate));
                $('#txtReturnDate').val(CDateEN(h.ReturnDate));
                $('#txtPackingDate').val(CDateEN(h.PackingDate));
                $('#txtFactoryDate').val(CDateEN(h.FactoryDate));
                $('#txtFactoryTime').val(ShowTime(h.FactoryTime));

                $('#txtRemark').val(h.Remark);
            }
            $('#ContainerList').val('');
            $('#tbContainers tbody').empty();
            if (r.transport.detail.length > 0) {
                for (let d of r.transport.detail) {
                    ShowCont(d);
                }
            }
        });
    }
    function ClearCont() {
        $('#ContainerList').val('');
        $('#tbContainers tbody').empty();
    }
    function LoadJob(dr) {
        $('#txtMode').val('E');
        $('#txtJNo').val(dr.JNo);
        $('#txtQuotation').val(dr.QNo);
        $('#txtJobType').val(CCode(dr.JobType));
        $('#txtShipBy').val(CCode(dr.ShipBy));

        $('#txtPortCode').val(dr.InvInterPort);

        $('#txtCountryCode').val(dr.ShipBy == 1 ? dr.InvFCountry : dr.InvCountry);
        ShowCountry(path, $('#txtCountryCode').val(), '#txtCountryName');

        $('#txtShipperCode').val(dr.CustCode + '|' + dr.CustBranch);
        ShowCustomerEN(path, dr.CustCode, dr.CustBranch, '#txtShipperName');

        $('#txtInvNo').val(dr.InvNo);
        $('#txtBookingNo').val(dr.BookingNo);
        $('#txtHAWB').val(dr.HAWB);
        $('#txtMAWB').val(dr.MAWB);
        $('#txtETDDate').val(CDateEN(dr.ETDDate));
        $('#txtETADate').val(CDateEN(dr.ETADate));
        $('#txtVesselName').val(dr.VesselName);
        $('#txtMVesselName').val(dr.MVesselName);

        $('#txtForwarderCode').val(dr.ForwarderCode);
        ShowVenderEN(path, dr.ForwarderCode, '#txtForwarderName');

        $('#txtTransportCode').val(dr.AgentCode);
        ShowVenderEN(path, dr.AgentCode, '#txtTransportName');
        $('#txtNetWeight').val(dr.TotalNW);
        $('#txtGrossWeight').val(dr.TotalGW);
        $('#txtMeasurement').val(dr.Measurement);
        $('#txtDeliveryAgentName').val(dr.DeliveryTo);
        $('#txtDeliveryAgentAddress').val(dr.DeliveryAddr);
        $('#txtCountBL').val(dr.BLNo);
        $('#txtProjectName').val(dr.ProjectName);
        $('#txtInvProduct').val(dr.InvProduct);
        $('#txtInvProductQty').val(dr.InvProductQty);
        $('#txtInvProductUnit').val(dr.InvProductUnit);

        $('#txtSIDate').val(CDateEN(dr.LoadDate));
        $('#txtSITime').val(ShowTime(dr.EstDeliverTime));

        $('#txtVGMDate').val(CDateEN(dr.EstDeliverDate));
        $('#txtVGMTime').val(ShowTime(dr.ConfirmChqDate));

        $('#txtClearPort').val(dr.ClearPort);

        let ttlctn = dr.TotalContainer.split('x');
        $('#txtTotalContainer').val(ttlctn[0]);
        $('#txtContainerUnit').val(ttlctn[1]);

        $.get(path + 'Master/GetCompany?Code=' + dr.Consigneecode).done((r) => {
            if (r.company.data.length > 0) {
                let c = r.company.data[0];
                $('#txtConsigneeCode').val(c.CustCode + '|' + c.Branch);
                $('#txtConsigneeName').val(c.NameEng);
            }
        });
        LoadBooking(dr);
    }
    function SearchData(type) {
        let w = '';
        switch (type) {
            case 'job':
                SetGridJob(path, '#tbJob', '#dvJob', '', LoadJob);
                break;
            case 'shipper':
                SetGridCompany(path, '#tbShipper', '#dvShipper', (dr) => {
                    $('#txtShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtShipperName').val(dr.NameEng);
                    $('#txtActualShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtActualShipperName').val(dr.NameEng);
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
            case 'unit2':
                SetGridServUnit(path, '#tbUnit2', '#dvUnit2', (dr) => {
                    $('#txtInvProductUnit').val(dr.UnitType);
                });
                break;
            case 'clearport':
                SetGridCustomsPort(path, '#tbPort', '#dvPort', (dr) => {
                    $('#txtClearPort').val(dr.AreaCode);
                });
                break;
            case 'quotation':
                let t = '?JType=' + $('#txtJobType').val() + '&SBy=' + $('#txtShipBy').val();
                //popup for search data
                $('#tbQuotation').DataTable({
                    ajax: {
                        url: path + 'JobOrder/GetQuotationGrid' + t, //web service ที่จะ call ไปดึงข้อมูลมา
                        dataSrc: 'quotation.data'
                    },
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: null, title: "#" },
                        { data: "QNo", title: "Quotation No" },
                        { data: "CustTName", title: "CustCode" },
                        { data: "BillTName", title: "BillTo" }
                    ],
                    "columnDefs": [ //กำหนด control เพิ่มเติมในแต่ละแถว
                        {
                            "targets": 0, //column ที่ 0 เป็นหมายเลขแถว
                            "data": null,
                            "render": function (data, type, full, meta) {
                                let html = "<button class='btn btn-warning'>Select</button>";
                                return html;
                            }
                        }
                    ],
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                });
                BindEvent('#tbQuotation', '#dvQuotation', function (dr) {
                    $('#txtQuotation').val(dr.QNo);
                    $('#txtCustCode').val(dr.CustCode + '|' + dr.CustBranch);
                    $('#txtBillToCustCode').val(dr.BillToCustCode + '|' + dr.BillToCustBranch);

                    $('#txtShipperCode').val(dr.CustCode + '|' + dr.CustBranch);
                    $('#txtShipperName').val(dr.CustEName);
                    $('#txtActualShipperCode').val(dr.CustCode + '|' + dr.Branch);
                    $('#txtActualShipperName').val(dr.CustEName);

                    //$('#txtConsigneeCode').val(dr.BillToCustCode + '|' + dr.BillToCustBranch);
                    //$('#txtConsigneeName').val(dr.BillEName);
                    //$('#txtActualConsigneeCode').val(dr.BillToCustCode + '|' + dr.BillToCustBranch);
                    //$('#txtActualConsigneeName').val(dr.BillEName);
                });
                break;
            case 'country':
                SetGridCountry(path, '#tbCountry', '#dvCountry', function (dr) {
                    $('#txtCountryCode').val(dr.CTYCODE);
                    $('#txtCountryName').val(dr.CTYName);
                });
                break;
            case 'receiveat':
                w = Number($('#txtShipBy').val()) == 1 ? $('#txtCountryCode').val() : 'TH';
                SetGridInterPort(path, '#tbReceiveAt', '#dvReceiveAt', w, function (dr) {
                    if (Number($('#txtShipBy').val()) == 1) {
                        $('#txtReceivePlace').val(dr.PortName + ',' + $('#txtCountryName').val());
                    } else {
                        $('#txtReceivePlace').val(dr.PortName + ',THAILAND');
                    }
                });
                break;
            case 'loadat':
                w = Number($('#txtShipBy').val()) == 1 ? $('#txtCountryCode').val() : 'TH';
                SetGridInterPort(path, '#tbLoadAt', '#dvLoadAt', w, function (dr) {
                    if (Number($('#txtShipBy').val()) == 1) {
                        $('#txtPortCode').val(dr.PortCode);
                        $('#txtLoadingPlace').val(dr.PortName + ',' +$('#txtCountryName').val());
                        if ($('#txtReceivePlace').val() == '') {
                            $('#txtReceivePlace').val(dr.PortName + ',' + $('#txtCountryName').val());
                        }
                    } else {
                        $('#txtLoadingPlace').val(dr.PortName + ',THAILAND');
                        if ($('#txtReceivePlace').val() == '') {
                            $('#txtReceivePlace').val(dr.PortName + ',THAILAND');
                        }
                    }
                });
                break;
            case 'dischargeat':
                w = Number($('#txtShipBy').val()) == 1 ? 'TH' : $('#txtCountryCode').val();
                SetGridInterPort(path, '#tbDischargeAt', '#dvDischargeAt', w, function (dr) {
                    if (Number($('#txtShipBy').val()) !== 1) {
                        $('#txtPortCode').val(dr.PortCode);
                        $('#txtDischargePlace').val(dr.PortName + ',' + $('#txtCountryName').val());
                        if ($('#txtDeliveryPlace').val() == '') {
                            $('#txtDeliveryPlace').val(dr.PortName + ',' + $('#txtCountryName').val());
                        }
                    } else {
                        $('#txtDischargePlace').val(dr.PortName + ',THAILAND');
                        if ($('#txtDeliveryPlace').val() == '') {
                            $('#txtDeliveryPlace').val(dr.PortName + ',THAILAND');
                        }
                    }
                });
                break;
            case 'deliveryat':
                w = Number($('#txtShipBy').val()) == 1 ? 'TH' : $('#txtCountryCode').val();
                SetGridInterPort(path, '#tbDeliveryAt', '#dvDeliveryAt', w, function (dr) {
                    if (Number($('#txtShipBy').val()) == 1) {
                        $('#txtDeliveryPlace').val(dr.PortName + ',THAILAND');
                    } else {
                        $('#txtDeliveryPlace').val(dr.PortName + ','+ $('#txtCountryName').val());
                    }
                });
                break;
            case 'payableat':
                SetGridInterPort(path, '#tbPayableAt', '#dvPayableAt', '', function (dr) {
                    $('#txtFreightPayAt').val(dr.PortName);
                });
                break;
        }
    }
    function ShowCont(dr) {
        let obj = $('#ContainerList').val();
        obj += dr.CTN_NO;
        obj += '|' + dr.NetWeight;
        obj += '|' + dr.GrossWeight;
        obj += '|' + dr.Measurement;
        obj += '|' + dr.ProductQty;
        obj += '|' + dr.ProductUnit;
        obj += '|' + dr.SealNumber;
        obj += ';';
        $('#ContainerList').val(obj);

        let html = '<tr>';
        html += '<td>' + dr.CTN_NO + '/' + dr.SealNumber + '</td>';
        html += '<td>' + dr.ProductQty + ' ' + dr.ProductUnit + '</td>';
        html += '<td>' + dr.NetWeight + '</td>';
        html += '<td>' + dr.GrossWeight + '</td>';
        html += '<td>' + dr.Measurement + '</td>';
        html += '</tr>';

        $('#tbContainers tbody').append(html);
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
        if (arr.length == 0) {
            $('#txtTotalContainer').val(0);
            $('#txtMeasurement').val(0);
            $('#txtNetWeight').val(0);
            $('#txtGrossWeight').val(0);
            let o = {
                Qty: 1,
                Unit: $('#txtContainerUnit').val()
            };
            arr.push(o);
        }
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

/*
        if ($('#txtQuotation').val() == '') {
            ShowMessage("Quotation Must be chosen", true);
            $('#txtQuotation').focus();
            return;
        }
        
        if ($('#txtCountryCode').val() == '') {
            ShowMessage("Country Must be chosen", true);
            SearchData('country');
            return;
        }
        if ($('#txtActualShipperCode').val() == '') {
            ShowMessage("Actual Shipper Must be chosen", true);
            SearchData('actshipper');
            return;
        }
        
        if ($('#txtActualConsigneeCode').val() == '') {
            ShowMessage("Actual Consignee Must be chosen", true);
            SearchData('actcons');
            return;
        }
        if ($('#txtDeliveryAgentCode').val() == '') {
            ShowMessage("Delivery Agent Must be chosen", true);
            SearchData('delivery');
            return;
        }
        
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
*/
        ShowConfirm("Are you sure to create by this information?", function (e) {
            if (e == true) {
                $('#form').submit();
            }
        });
    }
    function SetAuto(id) {
        $(id).val('{AUTO}');
    }
    function PrintBooking() {
        switch ($('#cboPrintForm').val()) {
            case 'JO':
                window.open(path + 'JobOrder/FormJob?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJNo').val(), '', '');
                break;
            case 'TI':
                window.open(path + 'JobOrder/FormBookingIm?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'TE':
                window.open(path + 'JobOrder/FormBookingEx?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BA':
                window.open(path + 'JobOrder/FormBookingAir?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BS':
                window.open(path + 'JobOrder/FormBookingSea?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'SP':
                window.open(path + 'JobOrder/FormBooking?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            //case 'BFT':
            //    window.open(path + 'JobOrder/FormTransport?Type=BETTER&BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
            //    break;
            case 'BLS':
                window.open(path + 'JobOrder/FormTransport?Type=SEA&BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BLW':
                window.open(path + 'JobOrder/FormTransport?Type=WALMAY&BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BLE':
                window.open(path + 'JobOrder/FormTransport?Type=EASTRONG&BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'HAW':
                window.open(path + 'JobOrder/FormTransport?Type=HAIR&BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'MAW':
                window.open(path + 'JobOrder/FormTransport?Type=MAIR&Branch=' + $('#cboBranch').val() + '&Code=' + $('#txtJNo').val(), '', '');
                break;
            case 'DO':
                window.open(path + 'JobOrder/FormLetter?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJNo').val(), '', '');
                break;
            case 'SC':
                window.open(path + 'JobOrder/FormSalesContract?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'BK':
                window.open(path + 'JobOrder/FormInvoice?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
            case 'PL':
                window.open(path + 'JobOrder/FormPackingList?BranchCode=' + $('#cboBranch').val() + '&BookingNo=' + $('#txtBookingNo').val(), '', '');
                break;
        }
    }
    function OpenJob() {
        window.open(path + 'JobOrder/ShowJob?BranchCode=' + $('#cboBranch').val() + '&JNo=' + $('#txtJNo').val(), '', '');
    }
</script>