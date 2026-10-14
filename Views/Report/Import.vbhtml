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
                                @Code
                                    Dim strhtml As String = ""
                                    Dim tmp As String = ""
                                    Dim rsGroup = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL("SELECT * FROM Mas_Config WHERE ConfigCode like 'JOB_PREFIX%'")
                                    For Each dr As System.Data.DataRow In rsGroup.Rows
                                        If tmp <> dr("ConfigCode") Then
                                            If tmp <> "" Then
                                                strhtml &= "</optgroup>"
                                            End If
                                            tmp = dr("ConfigCode")
                                            strhtml &= "<optgroup label=""" & dr("ConfigCode").ToString().Replace("JOB_PREFIX_", "") & """>"
                                        End If
                                        strhtml &= "<option value=""" & dr("ConfigKey").ToString() & """ " & IIf(group.Equals(dr("ConfigKey")), "selected", "") & ">" & dr("ConfigValue") & "</option>"
                                    Next
                                    If tmp <> "" Then
                                        strhtml &= "</optgroup>"
                                    End If
                                End Code
                                @Html.Raw(strhtml)
                            </select>
    </div>

</div>
<div class="row">
    <div class="col-sm-6">
        <label id="lblCustCode">Customer :</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" id="txtCustCode" class="form-control" style="width:130px" value="@custcode" disabled />
            <input type="text" id="txtCustBranch" class="form-control" style="width:70px" value="@custbranch" disabled />
            <button id="btnBrowseCust" type="button" class="btn btn-default" onclick="SearchData('customer')">...</button>
            @code
                Dim custName As String = ""
                If Not String.IsNullOrEmpty(custcode) Then
                    Dim sql As String = "SELECT NameThai FROM Mas_Company WHERE CustCode = '" & custcode & "' AND Branch = '" & custbranch & "'"
                    Dim dtCust = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sql)
                    
                    If dtCust.Rows.Count > 0 Then
                        custName = dtCust.Rows(0)("NameThai").ToString()
                    End If
                End If
             End Code
            <input type="text" id="txtCustName" class="form-control" style="width:100%" value="@custName" disabled />
        </div>
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
<div id="dvLOVs"></div>
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
    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
        let dv = document.getElementById("dvLOVs");
        CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
    });
    function SearchData(type) {        
        switch (type) {                        
            case 'customer':                
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);                
                break;        
        }    
    }
    function ReadCustomer(dt) {        
        $('#txtCustCode').val(dt.CustCode);        
        $('#txtCustBranch').val(dt.Branch);        
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
        $('#frmSearchCust').modal('hide');
        if (typeof CheckGroup === 'function') {
            CheckGroup();
        }
    }
</script>