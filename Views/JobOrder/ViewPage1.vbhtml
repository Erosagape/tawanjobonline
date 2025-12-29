@Code
    ViewData("Title") = "Container Maintenance"
    Dim dt As New Data.DataTable
    Dim jsonSource As String = "[]"
    Dim sqlW As String = "WHERE CancelBy=''"
    Dim containerNo As String = ""
    Dim rows As Integer = 0
    Dim msg As String = ""
    Dim sql As String = ""
    Dim debug As Boolean = False
    If Not Request.QueryString("Debug") Is Nothing Then
        debug = True
    End If
    If Not Request.QueryString("Show") Is Nothing Then
        Select Case Request.QueryString("Show")
            Case "APP"
                sqlW = "WHERE ApproveBy<>''"
            Case "ALL"
                sqlW = "WHERE CTN_NO<>''"
            Case "CANCEL"
                sqlW = "WHERE CancelBy<>''"
            Case "ACTIVE"
                sqlW = "WHERE EndDate<BeginDate "
            Case "COMPLETE"
                sqlW = "WHERE EndDate>=BeginDate "
        End Select
    End If
    If Not Request.QueryString("CTN_NO") Is Nothing Then
        containerNo = Request.QueryString("CTN_NO")
        sqlW &= String.Format(" AND CTN_NO='{0}'", containerNo)
    End If
    Dim obj = New jobonline.CUtil(ViewBag.CONNECTION_JOB)
    If ViewBag.UserName <> "" Then
        dt = obj.GetTableFromSQL(String.Format("SELECT * FROM Job_ContainerMaintenance {0} ORDER BY EntryDate DESC", sqlW))
        jsonSource = Newtonsoft.Json.JsonConvert.SerializeObject(dt)
        If Not Request.Form("Submit") Is Nothing Then
            msg = "OK"
            Dim seq As Integer = Request.Form("SEQ")
            containerNo = Request.Form("CTN_NO")
            If seq = 0 Then
                sql = "
DECLARE @@seq int=(SELECT ISNULL(MAX(SEQ),0)+1 as t FROM Job_ContainerMaintenance WHERE CTN_NO='{0}');

INSERT INTO Job_ContainerMaintenance
(CTN_NO,SEQ,CTN_PART,SerialNo,EntryDate,EntryBy,MaintenanceReason,MaintenanceType,PicturePath,VenderCode,DepotCode,CountryCode,BeginDate
,EndDate,ApproveBy,ApproveDate,CancelBy,CancelDate,BudgetAmount,CurrencyCode,PaymentNo,MaintenanceStatus)
SELECT '{0}',@@seq,'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}';
"
            Else
                sql = "
IF NOT EXISTS(select 1 from Job_ContainerMaintenance WHERE CTN_NO='{0}' AND SEQ={1})
BEGIN
INSERT INTO Job_ContainerMaintenance
(CTN_NO,SEQ,CTN_PART,SerialNo,EntryDate,EntryBy,MaintenanceReason,MaintenanceType,PicturePath,VenderCode,DepotCode,CountryCode,BeginDate
,EndDate,ApproveBy,ApproveDate,CancelBy,CancelDate,BudgetAmount,CurrencyCode,PaymentNo,MaintenanceStatus)
SELECT '{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}';
END
ELSE
BEGIN
UPDATE Job_ContainerMaintenance
SET CTN_PART='{2}',
SerialNo='{3}',
EntryDate='{4}',
EntryBy='{5}',
MaintenanceReason='{6}',
MaintenanceType='{7}',
PicturePath='{8}',
VenderCode='{9}',
DepotCode='{10}',
CountryCode='{11}',
BeginDate='{12}',
EndDate='{13}',
ApproveBy='{14}',
ApproveDate='{15}',
CancelBy='{16}',
CancelDate='{17}',
BudgetAmount={18},
CurrencyCode='{19}',
PaymentNo='{20}',
MaintenanceStatus='{21}'
WHERE CTN_NO='{0}' AND SEQ={1};
END
"
            End If
            sql = String.Format(
                sql, containerNo, seq,
                Request.Form("CTN_PART"),
                Request.Form("SerialNo"),
                Request.Form("EntryDate"),
                Request.Form("EntryBy"),
                Request.Form("MaintenanceReason"),
                Request.Form("MaintenanceType"),
                Request.Form("PicturePath"),
                Request.Form("VenderCode"),
                Request.Form("DepotCode"),
                Request.Form("CountryCode"),
                Request.Form("BeginDate"),
                Request.Form("EndDate"),
                Request.Form("ApproveBy"),
                Request.Form("ApproveDate"),
                Request.Form("CancelBy"),
                Request.Form("CancelDate"),
                Request.Form("BudgetAmount"),
                Request.Form("CurrencyCode"),
                Request.Form("PaymentNo"),
                Request.Form("MaintenanceStatus")
        )
            If debug = False Then
                msg = obj.ExecuteSQL(sql)
            Else
                msg = "OK"
            End If
        End If
    End If


End Code
@If debug = True Then
    @<textarea>@sql</textarea>
End If 
<input type="button" class="btn btn-primary" value="Add New" onclick="ClearData()" />
<div Class="modal fade" id="dvEditor">
    <div Class="modal-dialog">
        <div Class="modal-content">
            <div Class="modal-header">
                Maintenance Data
            </div>
            <div Class="modal-body">
                <form action = "" method="post">
                    <div Class="row">
                        <div Class="col-sm-4">
                            <Label> Container No</label>
                            <br />
                            <input type = "text" name="CTN_NO" id="txtCTN_NO" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Seq</label>
                            <br />
                            <input type = "number" name="SEQ" id="txtSEQ" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label>Date</label>
                            <br />
                            <input type = "date" name="EntryDate" id="txtEntryDate" Class="form-control" ReadOnly />
                        </div>
                    </div>
                    <div Class="row">
                        <div Class="col-sm-4">
                            <Label> PART</label>
                            <br />
                            <input type = "text" name="CTN_PART" id="txtCTN_PART" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Type MTN</label>
                            <br />
                            <input type = "text" name="MaintenanceType" id="txtMaintenanceType" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Serial#</label>
                            <br />
                            <input type = "text" name="SerialNo" id="txtSerialNo" Class="form-control" />
                        </div>
                    </div>
                    <div Class="row">
                        <div Class="col-sm-4">
                            <Label> Reason</label>
                            <br />
                            <input type = "text" name="MaintenanceReason" id="txtMaintenanceReason" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Start Date</label>
                            <br />
                            <input type = "date" name="BeginDate" id="txtBeginDate" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Finish Date</label>
                            <br />
                            <input type = "date" name="EndDate" id="txtEndDate" Class="form-control" />
                        </div>
                    </div>
                    <div Class="row">
                        <div Class="col-sm-4">
                            <Label> Vender</label>
                            <br />
                            <input type = "text" name="VenderCode" id="txtVenderCode" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Depot</label>
                            <br />
                            <input type = "text" name="DepotCode" id="txtDepotCode" Class="form-control" />
                        </div>
                        <div Class="col-sm-4">
                            <Label> Country</label>
                            <br />
                            <input type = "text" name="CountryCode" id="txtCountryCode" Class="form-control" />
                        </div>
                    </div>
                    <div Class="row">
                        <div Class="col-sm-3">
                            <Label> Picture</label>
                            <br />
                            <input type = "text" name="PicturePath" id="txtPicturePath" Class="form-control" />
                        </div>
                        <div Class="col-sm-3">
                            <Label> Budget Amount</label>
                            <br />
                            <input type = "number" name="BudgetAmount" id="txtBudgetAmount" Class="form-control" />
                        </div>
                        <div Class="col-sm-3">
                            <Label> Currency</label>
                            <br />
                            <input type = "text" name="CurrencyCode" id="txtCurrencyCode" Class="form-control" />
                        </div>
                        <div Class="col-sm-3">
                            <Label> Payment#</label>
                            <br />
                            <input type = "text" name="PaymentNo" id="txtPaymentNo" Class="form-control" />
                        </div>

                    </div>
                    <div Class="row">
                        <div Class="col-sm-3">
                            <input type = "checkbox" id="chkApprove" onclick="SetApprove()" />
                            <Label for="chkApprove">Approve By</label>
                            <br />
                            <input type = "text" name="ApproveBy" id="txtApproveBy" Class="form-control" ReadOnly />
                        </div>
                        <div Class="col-sm-3">
                            <Label> Approve Date</label>
                            <br />
                            <input type = "date" name="ApproveDate" id="txtApproveDate" Class="form-control" ReadOnly />
                        </div>
                        <div Class="col-sm-3">
                            <input type = "checkbox" id="chkCancel" onclick="SetCancel()" />
                            <Label for="chkCancel">Cancel By</label>
                            <br />
                            <input type = "text" name="CancelBy" id="txtCancelBy" Class="form-control" ReadOnly />
                        </div>
                        <div Class="col-sm-3">
                            <Label> Cancel Date</label>
                            <br />
                            <input type = "date" name="CancelDate" id="txtCancelDate" Class="form-control" ReadOnly />
                        </div>
                    </div>
                    <div Class="row">
                        <div Class="col-sm-3">
                            <Label> Status</label>
                            <br />
                            <input type = "text" name="MaintenanceStatus" id="txtMaintenanceStatus" Class="form-control" ReadOnly />
                        </div>
                        <div Class="col-sm-3">
                            <Label> Entry By</label>
                            <br />
                            <input type = "text" name="EntryBy" id="txtEntryBy" Class="form-control" ReadOnly />
                        </div>
                    </div>
                    <input type = "submit" name="Submit" Class="btn btn-success" value="Save Data" />
                </form>
            </div>
            <div Class="modal-footer">
                <input type = "button" data-dismiss="modal" Class="btn btn-danger" value="Close" />
            </div>
        </div>
    </div>
</div>
<Script type = "text/javascript" >
    let path = '@Url.Content("~")';
    let user ='@ViewBag.User';
    let dt = JSON.parse('@Html.Raw(jsonSource)');
    let msg = '@msg';
    if (msg !== '') {
        alert(msg);
        //window.location = window.location.href;
    }
    function SetApprove() {
        if ($('#chkApprove').prop('checked') == true) {
            $('#txtApproveBy').val(user);
            $('#txtApproveDate').val(CDateEN(GetToday()));
        } else {
            $('#txtApproveBy').val('');
            $('#txtApproveDate').val('');
        }
    }
    function SetCancel() {
        if ($('#chkCancel').prop('checked') == true) {
            $('#txtCancelBy').val(user);
            $('#txtCancelDate').val(CDateEN(GetToday()));
        } else {
            $('#txtCancelBy').val('');
            $('#txtCancelDate').val('');
        }
    }
    function ClearData() {
        $('#txtCTN_NO').val('@containerNo');
        $('#txtSEQ').val(0);
        $('#txtCTN_PART').val('');
        $('#txtEntryDate').val(GetToday());
        $('#txtMaintenanceType').val('');
        $('#txtMaintenanceReason').val('');
        $('#txtSerialNo').val('');
        $('#txtBeginDate').val('');
        $('#txtEndDate').val('');
        $('#txtVenderCode').val('');
        $('#txtDepotCode').val('');
        $('#txtCountryCode').val('');
        $('#txtPicturePath').val('');
        $('#txtBudgetAmount').val(0);
        $('#txtCurrencyCode').val('');
        $('#txtPaymentNo').val('');
        $('#txtEntryBy').val(user);
        $('#txtApproveDate').val('');
        $('#txtCancelDate').val('');
        $('#txtApproveBy').val('');
        $('#txtCancelBy').val('');
        $('#chkApprove').removeAttr('checked');
        $('#chkCancel').removeAttr('checked');
        $('#txtMaintenanceStatus').val('');
        $('#dvEditor').modal('show');
    }
    function LoadData(i) {
        ClearData();
        if (dt.length > 0) {
            $('#txtCTN_NO').val(dt[i].CTN_NO);
            $('#txtSEQ').val(dt[i].SEQ);
            $('#txtCTN_PART').val(dt[i].CTN_PART);
            $('#txtEntryDate').val(CDateEN(dt[i].EntryDate));
            $('#txtMaintenanceType').val(dt[i].MaintenanceType);
            $('#txtMaintenanceReason').val(dt[i].MaintenanceReason);
            $('#txtSerialNo').val(dt[i].SerialNo);
            $('#txtBeginDate').val(CDateEN(dt[i].BeginDate));
            $('#txtEndDate').val(CDateEN(dt[i].EndDate));
            $('#txtVenderCode').val(dt[i].VenderCode);
            $('#txtDepotCode').val(dt[i].DepotCode);
            $('#txtCountryCode').val(dt[i].CountryCode);
            $('#txtPicturePath').val(dt[i].PicturePath);
            $('#txtBudgetAmount').val(dt[i].BudgetAmount);
            $('#txtCurrencyCode').val(dt[i].CurrencyCode);
            $('#txtPaymentNo').val(dt[i].PaymentNo);
            $('#txtEntryBy').val(dt[i].EntryBy);
            $('#txtApproveDate').val(CDateEN(dt[i].ApproveDate));
            $('#txtCancelDate').val(CDateEN(dt[i].CancelDate));
            $('#txtApproveBy').val(dt[i].ApproveBy);
            $('#txtCancelBy').val(dt[i].CancelBy);
            if (dt[i].ApproveBy !== '') {
                $('#chkApprove').attr('checked', 'checked');
            } else {
                $('#chkApprove').removeAttr('checked');
            }
            if (dt[i].CancelBy !== '') {
                $('#chkCancel').attr('checked', 'checked');
            } else {
                $('#chkCancel').removeAttr('checked');
            }
            $('#txtMaintenanceStatus').val(dt[i].MaintenanceStatus);
        }
        $('#dvEditor').modal('show');
    }
</script>
@Code
    If dt.Rows.Count > 0 Then
        @<table class="table table-responsive table-bordered">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Date</th>
                    <th>Ctn#</th>
                    <th>Part</th>
                    <th>Type</th>
                    <th>Reason</th>
                    <th>Begin/End Mtn</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tbody>
                @For each dr As Data.DataRow In dt.Rows
                    If System.DBNull.Value.Equals(dr("CTN_NO")) Then
                        Continue For
                    End If
                    Dim beginDate As String = ""
                    Dim endDate As String = ""
                    Try
                        beginDate = Convert.ToDateTime(dr("BeginDate")).ToString("dd/MM/yyyy")
                    Catch ex As Exception

                    End Try
                    Try
                        endDate = Convert.ToDateTime(dr("EndDate")).ToString("dd/MM/yyyy")
                    Catch ex As Exception

                    End Try
                    @<tr>
                        <td>
                            <input type="button" class="btn btn-warning" value="Edit" onclick="LoadData(@rows)" />
                        </td>
                        <td>
                            @Convert.ToDateTime(dr("EntryDate")).ToString("dd/MM/yyyy")
                        </td>
                        <td>@dr("CTN_NO")</td>
                        <td>@dr("CTN_PART")</td>
                        <td>@dr("MaintenanceType")</td>
                        <td>@dr("MaintenanceReason")</td>
                        <td>
                            @beginDate / @endDate
                        </td>
                        <td>@dr("MaintenanceStatus")</td>
                    </tr>
                    rows += 1
                Next
            </tbody>
        </table>
    End If
End Code
