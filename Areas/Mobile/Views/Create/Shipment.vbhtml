@Code
    ViewData("Title") = "Shipment"
    Dim jobType = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='JOB_TYPE'")
    Dim jobShipBy = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY'")
    Dim customers = New CUtil(ViewBag.JobConn).GetTableFromSQL("SELECT * FROM Mas_Company WHERE CustGroup='CUSTOMERS'")
    Dim consignees = New CUtil(ViewBag.JobConn).GetTableFromSQL("SELECT * FROM Mas_Company WHERE CustGroup='CONSIGNEE'")
    Dim units = New CCustomsUnit(ViewBag.MasConn).GetData(" ORDER BY TName")
    Dim ctntype = New CServUnit(ViewBag.MasConn).GetData(" ORDER BY UName")
    Dim interports = New CInterPort(ViewBag.MasConn).GetData(" ORDER BY PortName")
    Dim countrys = New CCountry(ViewBag.MasConn).GetData(" ORDER BY CTYName")
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
                    Exporter/Importer
                </b>
                <select name="customer" class="form-control dropdown">
                    @For Each r As System.Data.DataRow In customers.Rows
                        @<option value="@r("CustCode")|@r("Branch")">@r("NameThai") / @r("Branch")</option>
                    Next
                </select>
            </div>
            <div class="col-sm-6">
                <b>
                    Consignee
                </b>
                <select name="consignee" class="form-control dropdown">
                    @For Each r As System.Data.DataRow In consignees.Rows
                        @<option value="@r("CustCode")">@r("NameEng")</option>
                    Next
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <b>Transhipment Country</b>
                <select name="invcountry" class="form-control dropdown">
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
                </select>
            </div>
            <div Class="col-sm-6">
                <b> Consignment Country</b>
                <select name="invfcountry" class="form-control dropdown">
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
                </select>
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
    <input type = "submit" Class="btn btn-success" value="Create" />
</form>
