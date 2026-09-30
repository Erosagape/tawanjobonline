@Code
    ViewData("Title") = "Import"
    Dim prefix As String = ""
    Dim jobtype As Integer = 0
    Dim shipby As Integer = 0
    Dim custcode As String = ""
    Dim custbranch As String = ""
    Dim group As String = ""
    If Not Request.QueryString("Prefix") Is Nothing Then
        prefix = Request.QueryString("Prefix")
    End If
    If Not Request.QueryString("JobType") Is Nothing Then
        jobtype = Convert.ToInt16(Request.QueryString("JobType"))
    End If
    If Not Request.QueryString("ShipBy") Is Nothing Then
        shipby = Convert.ToInt16(Request.QueryString("ShipBy"))
    End If
    If Not Request.QueryString("CustCode") Is Nothing Then
        custcode = Request.QueryString("CustCode")
    End If
    If Not Request.QueryString("CustBranch") Is Nothing Then
        custbranch = Request.QueryString("CustBranch")
    End If
    group = jobtype.ToString("00") & shipby.ToString("00") & prefix
    Dim msg As String = "" & ViewBag.Message
End Code
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>
<h2>Import Job Order From Excel</h2>
<div class="row">
    <div class="col-sm-4">
        <label>Group</label>
        <br />
        <select id="cboGroup" class="form-control dropdown" onchange="CheckGroup()" style="width:100%">
            <option value=""></option>
            <optgroup label="AIR">
                <option value="0101AI" @IIf(group.Equals("0101AI"), "selected", "")>AIR IMPORT</option>
                <option value="0201AE" @IIf(group.Equals("0201AE"), "selected", "")>AIR EXPORT</option>
                <option value="0301ATS" @IIf(group.Equals("0301ATS"), "selected", "")>AIR TRANSIT</option>
                <option value="0401AO" @IIf(group.Equals("0401AO"), "selected", "")>AIR OTHER</option>
            </optgroup>
            <optgroup label="SEA">
                <option value="0102SI" @IIf(group.Equals("0102SI"), "selected", "")>SEA IMPORT</option>
                <option value="0202SE" @IIf(group.Equals("0202SE"), "selected", "")>SEA EXPORT</option>
                <option value="0302STS" @IIf(group.Equals("0302STS"), "selected", "")>SEA TRANSIT</option>
                <option value="0402SO" @IIf(group.Equals("0402SO"), "selected", "")>SEA OTHER</option>
            </optgroup>
            <optgroup label="CROSS-BORDER">
                <option value="0103CBI" @IIf(group.Equals("0103CBI"), "selected", "")>CROSS-BORDER IMPORT</option>
                <option value="0203CBE" @IIf(group.Equals("0203CBE"), "selected", "")>CROSS-BORDER EXPORT</option>
                <option value="0403CBO" @IIf(group.Equals("0403CBO"), "selected", "")>CROSS-BORDER OTHER</option>
            </optgroup>
            <optgroup label="DOMESTIC">
                <option value="0104DI" @IIf(group.Equals("0104DI"), "selected", "")>DOMESTIC IMPORT</option>
                <option value="0204DE" @IIf(group.Equals("0204DE"), "selected", "")>DOMESTIC EXPORT</option>
                <option value="0404DO" @IIf(group.Equals("0404DO"), "selected", "")>DOMESTIC OTHER</option>
            </optgroup>
            <optgroup label="FREIGHT">
                <option value="0105FAI" @IIf(group.Equals("0105FAI"), "selected", "")>FREIGHT AIR/IMPORT</option>
                <option value="0106FSI" @IIf(group.Equals("0106FSI"), "selected", "")>FREIGHT SEA/IMPORT</option>
                <option value="0205FAE" @IIf(group.Equals("0205FAE"), "selected", "")>FREIGHT AIR/EXPORT</option>
                <option value="0206FSE" @IIf(group.Equals("0206FSE"), "selected", "")>FREIGHT SEA/EXPORT</option>
                <option value="0210FCBE" @IIf(group.Equals("0210FCBE"), "selected", "")>FREIGHT CROSS-BORDER/EXPORT</option>
                <option value="0110FCBI" @IIf(group.Equals("0110FCBI"), "selected", "")>FREIGHT CROSS-BORDER/IMPORT</option>
                <option value="0307FTS" @IIf(group.Equals("0307FTS"), "selected", "")>FREIGHT TRANSIT</option>
            </optgroup>
            <optgroup label="TRANSPORT">
                <option value="0107TI" @IIf(group.Equals("0107TI"), "selected", "")>TRANSPORT IMPORT</option>
                <option value="0207TE" @IIf(group.Equals("0207TE"), "selected", "")>TRANSPORT EXPORT</option>
                <option value="0507TD" @IIf(group.Equals("0507TD"), "selected", "")>TRANSPORT DOMESTIC</option>
            </optgroup>
            <optgroup label="WAREHOUSE">
                <option value="0108WHI" @IIf(group.Equals("0108WHI"), "selected", "")>WAREHOUSE Import</option>
                <option value="0208WHE" @IIf(group.Equals("0208WHE"), "selected", "")>WAREHOUSE Export</option>
                <option value="0109WDI" @IIf(group.Equals("0109WDI"), "selected", "")>WAREHOUSE Domestic (Import)</option>
                <option value="0209WDE" @IIf(group.Equals("0209WDE"), "selected", "")>WAREHOUSE Domestic (Export)</option>
                <option value="0409WO" @IIf(group.Equals("0409WO"), "selected", "")>WAREHOUSE Domestic (Other)</option>
            </optgroup>
        </select>
    </div>

</div>
<div class="row">
    <div class="col-sm-4">
        <label>Customer</label>
        <br />
        <select id="cboCustCode" class="form-control dropdown" onchange="CheckGroup()">
            <option value="|"></option>
            @Code
                Dim rs = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL("SELECT * FROM Mas_Company ORDER BY NameThai")
                For Each dr As Data.DataRow In rs.Rows
                    @<option value="@dr("CustCode")|@dr("Branch")" @IIf(String.Concat(custcode, "|", custbranch).Equals(String.Concat(dr("CustCode").ToString(), "|", dr("Branch").ToString())), "selected", "")>@dr("NameThai") (@String.Concat(dr("CustCode").ToString(), "|", dr("Branch").ToString()))</option>
                Next
            End Code
        </select>
    </div>
</div>
<input type="hidden" id="txtJobType" value="@jobtype" />
<input type="hidden" id="txtShipBy" value="@shipby" />
<input type="hidden" id="txtPrefix" value="@prefix" />
<input type="hidden" id="txtCustCode" value="@custcode" />
<input type="hidden" id="txtCustBranch" value="@custbranch" />

@Using Html.BeginForm("Import", "Report", New With {.CustCode = custcode, .CustBranch = custbranch, .JobType = jobtype, .ShipBy = shipby, .Prefix = prefix}, FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<p>@Html.Raw(msg.Replace(vbCrLf, "<br/>"))</p>
    @<input type="file" name="fileUpload" />
    @<input type="submit" value="Upload" />
    If Not ViewBag.Data Is Nothing Then
        @<table class="table table-bordered">
            <tr>
                @For Each col In ViewBag.Data.Columns
                    @<td>@col.ColumnName</td>
                Next
            </tr>
            @For Each row In ViewBag.Data.Rows
                @<tr>
                    @For Each col In ViewBag.Data.Columns
                        @<td>@row(col.ColumnName).ToString</td>
                    Next
                </tr>
            Next
        </table>
    End If
End Using
<script type="text/javascript">
    function CheckGroup() {
        let gstr = $('#cboGroup').val();
        let cust = $('#cboCustCode').val();
        $('#txtJobType').val(gstr.substr(0, 2));
        $('#txtShipBy').val(gstr.substr(2, 2));
        $('#txtPrefix').val(gstr.substr(4, 5));
        let custcode = cust.substr(0, cust.indexOf('|'));
        let custbr = cust.substr(cust.indexOf('|') + 1, 5);
        window.location = window.location.pathname + '?Prefix=' + $('#txtPrefix').val() + '&JobType=' + $('#txtJobType').val() + '&ShipBy=' + $('#txtShipBy').val() + '&CustCode=' + custcode + '&CustBranch=' + custbr;
    }
</script>