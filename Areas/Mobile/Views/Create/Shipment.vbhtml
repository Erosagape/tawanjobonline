<link rel="stylesheet" href="~/Content/jquery.datatables.min.css">
<link rel="stylesheet" href="~/Content/responsive.dataTables.min.css">
<script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
<script src="~/Scripts/DataTables/dataTables.responsive.min.js"></script>
@Code
    ViewData("Title") = "Shipment"
    Dim jobType = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='JOB_TYPE'")
    Dim jobShipBy = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY'")
    Dim customers = New CUtil(ViewBag.JobConn).GetTableFromSQL("SELECT * FROM Mas_Company WHERE CustGroup='CUSTOMERS'")
    ViewBag.Customers = customers
    ViewBag.CustCode = "#txtCustCode"
    ViewBag.CustTName = "#txtCustName"
    Dim consignees = New CUtil(ViewBag.JobConn).GetTableFromSQL("SELECT * FROM Mas_Company WHERE CustGroup='CONSIGNEE'")
    ViewBag.Consignees = consignees
    ViewBag.ConsignCode = "#txtConsignCode"
    ViewBag.ConsignTName = "#txtConsignName"
    Dim units = New CCustomsUnit(ViewBag.MasConn).GetData(" ORDER BY TName")
    Dim ctntype = New CServUnit(ViewBag.MasConn).GetData(" ORDER BY UName")
    Dim interports = New CInterPort(ViewBag.MasConn).GetData(" ORDER BY PortName")
    Dim countrys = New CCountry(ViewBag.MasConn).GetData(" ORDER BY CTYName")
    ViewBag.CountryCode = "#txtCountryCode"
    ViewBag.CountryName = "#txtCountryName"
    ViewBag.FCountryCode = "#txtFCountryCode"
    ViewBag.FCountryName = "#txtFCountryName"

    Dim customsports = New CCustomsPort(ViewBag.MasConn).GetData(" ORDER BY AreaCode")
End Code
<form action="" method="post">
    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <b>Shipment Type : </b>
                <select name="jobtype" class="form-control dropdown">
                    @For Each d In jobType
                        @<option value="@d.ConfigKey">@d.ConfigValue</option>
                    Next
                </select>
            </div>
            <div class="col-sm-6">
                <b>Transport mode : </b>
                <select name="shipby" class="form-control dropdown">
                    @For Each d In jobShipBy
                        @<option value="@d.ConfigKey">@d.ConfigValue</option>
                    Next
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <b>
                    <a data-target="#mdlCustomers" data-toggle="modal">Exporter/Importer</a>
                </b>
                <input type="hidden" id="txtCustCode" name="customer" />
                <input type="text" id="txtCustName" readonly class="form-control" />
                @Html.Partial("CustomerList", customers)
        </div>
            <div class="col-sm-6">
                <b>
                    <a data-target="#mdlConsignees" data-toggle="modal">Consignee</a>
                </b>
                <input type="hidden" id="txtConsignCode" name="consignee" />
                <input type="text" id="txtConsignName" readonly class="form-control" />
                @Html.Partial("ConsigneeList", consignees)
            </div>
    </div>
<div class="row">
    <div class="col-sm-6">
        <b>
            <a data-target="#mdlCountries" data-toggle="modal"><b>Transhipment Country</b></a>
        </b>
        <div style="display:flex;flex-direction:column;">
            <input type="hidden" id="txtCountryCode" />
            <input type="text" id="txtCountryName" readonly class="form-control" />
            <input type="hidden" id="txtInterPortCodeS" name="invcountry" />
            <input type="text" id="txtInterPortNameS" readonly class="form-control" />
        </div>
        @Html.Partial("CountryList", countrys)
        @*<select name="invcountry" class="form-control dropdown">
            @For Each port In interports
                Dim ctry = countrys.Where(Function(e) e.CTYCODE.Equals(port.CountryCode)).FirstOrDefault()
                If ctry IsNot Nothing Then
                    @<option value="@port.PortCode|@port.CountryCode">
                        @port.PortName / @ctry.CTYName
                    </option>
                Else
                    @<option value="@port.PortCode|@port.CountryCode">
                        @port.PortName / @port.CountryCode
                    </option>
                End If
            Next
        </select>*@
    </div>
    <div Class="col-sm-6">        
        <b>
            <a data-target="#mdlFCountries" data-toggle="modal"><b> Consignment Country</b></a>
        </b>
        <div style="display:flex;flex-direction:column;">
            <input type="hidden" id="txtFCountryCode" />
            <input type="text" id="txtFCountryName" readonly class="form-control" />
            <input type="hidden" id="txtInterPortCodeF" name="invfcountry" />
            <input type="text" id="txtInterPortNameF" readonly class="form-control" />
        </div>
        
        @Html.Partial("FCountryList", countrys)
        @*<select name="invfcountry" class="form-control dropdown">
            @For Each port In interports
                Dim ctry = countrys.Where(Function(e) e.CTYCODE.Equals(port.CountryCode)).FirstOrDefault()
                If ctry IsNot Nothing Then
                    @<option value="@port.PortCode|@port.CountryCode">
                        @port.PortName / @ctry.CTYName
                    </option>
                Else
                    @<option value="@port.PortCode/@port.CountryCode">
                        @port.PortName / @port.CountryCode
                    </option>
                End If
            Next
        </select>*@
    </div>
</div>
<div class="row">
<div class="col-sm-6">
    <b>Load/Unload At</b>
    <input type="text" name="deliveryto" class="form-control" />
</div>
<div class="col-sm-6">
    <b>Load/Unload Address</b>
    <input type="text" name="deliveryaddr" class="form-control" />
</div>
</div>

<div Class="row">
<div Class="col-sm-6">
    <b>Local Port</b>
    <select name="clearport" class="form-control dropdown">
        @For Each port In customsports
            @<option value="@port.AreaCode">@port.AreaCode / @port.AreaName</option>
        Next
    </select>
</div>
<div class="col-sm-6">
    <b>Discharge Port</b>
    <input type="text" class="form-control" name="clearportno" />
</div>
</div>
<div class="row">
<div class="col-sm-6">
    <b>PI/PO Reference</b>
    <input type="text" name="custrefno" class="form-control" />
</div>
<div class="col-sm-6">
    <b> Commodity</b>
    <input type="text" name="product" Class="form-control" />
</div>
</div>
<div Class="row">
<div Class="col-sm-4">
    <b> Qty</b>
    <input type="number" name="prdqty" Class="form-control" />
</div>
<div Class="col-sm-4">
    <b> Unit</b>
    <select name="prdunit" Class="form-control dropdown">
        @For Each r In units
            @<option value="@r.Code">@r.TName</option>
        Next
    </select>
</div>
<div Class="col-sm-4">
    <b>Total Packages</b>
    <input type="number" name="totalbox" class="form-control" />
</div>
</div>
<div Class="row">
<div Class="col-sm-3">
    <b>Width</b>
    <input type="number" name="boxwidth" Class="form-control" />
</div>
<div Class="col-sm-3">
    <b>Height</b>
    <input type="number" name="boxheight" Class="form-control" />
</div>
<div Class="col-sm-3">
    <b>High</b>
    <input type="number" name="boxhigh" Class="form-control" />
</div>
<div Class="col-sm-3">
    <b>Weight</b>
    <input type="number" name="boxweight" Class="form-control" />
</div>
</div>
<div class="row">
<div class="col-sm-4">
    <b>ETD/ETA</b>
    <input type="date" name="imexdate" class="form-control" />
</div>
<div class="col-sm-4">
    <b>Total CTNs</b>
    <input type="text" name="totalctn" class="form-control" />
</div>
<div class="col-sm-4">
    <b>EQP Type</b>
    <select name="ctnunit" class="form-control">
        @For Each unit In ctntype
            @<option value="@unit.UnitType">@unit.UName</option>
        Next
    </select>
</div>
</div>
</div>
<input type="submit" Class="btn btn-success" value="Create" />
</form>
