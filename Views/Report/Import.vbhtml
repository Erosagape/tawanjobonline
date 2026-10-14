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
                                        strhtml &= "<option value=""" & dr("ConfigKey").ToString() & """>" & dr("ConfigValue") & "</option>"
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