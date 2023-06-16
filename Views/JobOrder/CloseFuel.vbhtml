@Code
    ViewData("Title") = "Refill Fuel"
    Dim appData = ViewBag.DataForApprove
    Dim billData = ViewBag.DataForBill
    Dim dataBilled = ViewBag.DataBilled
    Dim sqlW = ""
    Dim dateFrom = ""
    Dim dateTo = ""
    If Request.QueryString("DateFrom") IsNot Nothing Then
        dateFrom = Request.QueryString("DateFrom")
        sqlW &= String.Format(" AND DocDate>='{0}'", dateFrom)
    End If
    If Request.QueryString("DateTo") IsNot Nothing Then
        dateTo = Request.QueryString("DateTo")
        sqlW &= String.Format(" AND DocDate<='{0}'", dateTo)
    End If
    If sqlW <> "" Then
        appData = New CAddFuel(ViewBag.CONNECTION_JOB).GetData(" WHERE ISNULL(ApproveBy,'')='' AND ISNULL(CancelBy,'')='' " & sqlW)
        billData = New CAddFuel(ViewBag.CONNECTION_JOB).GetData(" WHERE ISNULL(ApproveBy,'')<>'' AND ISNULL(StationInvNo,'')='' AND ISNULL(CancelBy,'')=''" & sqlW)
        dataBilled = New CAddFuel(ViewBag.CONNECTION_JOB).GetData(" WHERE ISNULL(ApproveBy,'')<>'' AND ISNULL(StationInvNo,'')<>'' AND ISNULL(CancelBy,'')=''" & sqlW)
    End If
End Code
<div class="row">
    <div class="col-sm-3">
        From Date <br />
        <input type="date" id="txtDateFrom" class="form-control" value="@dateFrom" />
    </div>
    <div class="col-sm-3">
        To Date <br />
        <input type="date" id="txtDateTo" class="form-control" value="@dateTo" />
    </div>
    <div class="col-sm-3">
        <br />
        <input type="button" class="btn btn-primary" value="Search" onclick="RefreshData()" />
    </div>
</div>
<ul class="nav nav-tabs">
    <li class="active"><a id="linkRequest" data-toggle="tab" href="#tabRequest">Fuel Request</a></li>
    <li><a id="linkApprove" data-toggle="tab" href="#tabApprove">Fuel Approved</a></li>
    <li><a id="linkInvoice" data-toggle="tab" href="#tabBilled">Fuel Billed</a></li>
</ul>
<div class="tab-content">
    <div class="tab-pane fade in active" id="tabRequest">
        <a href="#" class="btn btn-default w3-purple" id="btnNew" onclick="AddData()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkNew">New Document</b>
        </a>
        <table id="tbFuelRequest" class="table table-responsive">
            <thead>
                <tr>
                    <th>#</th>
                    <th>DocNo</th>
                    <th>DocDate</th>
                    <th>JobNo</th>
                    <th>Driver</th>
                    <th>Truck</th>
                    <th>Request</th>
                </tr>
            </thead>
            <tbody>
                @For Each row As CAddFuel In appData
                    @<tr ondblclick="ShowDoc('@row.BranchCode','@row.DocNo')">
                        <td>
                            <input type="checkbox" onclick="ProcessCheckApprove(this,'@row.DocNo')" />
                        </td>
                        <td>@row.DocNo</td>
                        <td>@row.DocDate.ToString("dd/MM/yyyy")</td>
                        <td>@row.JNo</td>
                        <td>@row.Driver</td>
                        <td>@row.CarLicense / @row.TrailerNo</td>
                        <td>@row.BudgetVolume</td>
                    </tr>
                Next
            </tbody>
        </table>
        <form method="POST" action="@Url.Action("ApproveFuel", "JobOrder")">
            Document selected for approve : <input type="text" name="txtApprove" id="txtApprove" style="width:100%" />
            <br />
            <input type="submit" value="Approve" class="btn btn-success" />
            <br />
            @ViewBag.MessageApp
        </form>
    </div>
    <div class="tab-pane fade" id="tabApprove">
        <table id="tbFuelApprove" class="table table-responsive">
            <thead>
                <tr>
                    <th>#</th>
                    <th>DocNo</th>
                    <th>DocDate</th>
                    <th>JobNo</th>
                    <th>Driver</th>
                    <th>Truck</th>
                    <th>Approve</th>
                    <th>Actual</th>
                </tr>
            </thead>
            <tbody>
                @For Each row As CAddFuel In billData
                    @<tr ondblclick="ShowDoc('@row.BranchCode','@row.DocNo')">
                        <td>
                            <input type="checkbox" onclick="ProcessCheckBill(this,'@row.DocNo')" />
                        </td>
                        <td>@row.DocNo</td>
                        <td>@row.DocDate.ToString("dd/MM/yyyy")</td>
                        <td>@row.JNo</td>
                        <td>@row.Driver</td>
                        <td>@row.CarLicense / @row.TrailerNo</td>
                        <td>@row.BudgetVolume</td>
                        <td>@row.ActualVolume</td>
                    </tr>
                Next
            </tbody>
        </table>
        <form method="POST" action="@Url.Action("SetInvoiceFuel", "JobOrder")">
            Document selected for Input Invoice# : <input type="text" name="txtBilling" id="txtBilling" style="width:100%" />
            <br />
            Station Invoice# : <input type="text" name="txtInvNo" id="txtInvNo" />
            <br />
            <input type="submit" value="Approve" class="btn btn-success" />
            <br />
            @ViewBag.MessageBill
        </form>

    </div>
    <div class="tab-pane fade" id="tabBilled">
        <table id="tbFuelInvoice" class="table table-responsive">
            <thead>
                <tr>
                    <th>DocNo</th>
                    <th>DocDate</th>
                    <th>JobNo</th>
                    <th>Driver</th>
                    <th>Truck</th>
                    <th>Actual</th>
                    <th>Invoice</th>
                </tr>
            </thead>
            <tbody>
                @For Each row As CAddFuel In dataBilled
                    @<tr ondblclick="ShowDoc('@row.BranchCode','@row.DocNo')">
                        <td>@row.DocNo</td>
                        <td>@row.DocDate.ToString("dd/MM/yyyy")</td>
                        <td>@row.JNo</td>
                        <td>@row.Driver</td>
                        <td>@row.CarLicense / @row.TrailerNo</td>
                        <td>@row.ActualVolume</td>
                        <td>@row.StationCode #@row.StationInvNo</td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    var arrSelApp = [];
    var arrSelBill = [];
    $('#tbFuelRequest').DataTable();
    $('#tbFuelApprove').DataTable();
    $('#tbFuelInvoice').DataTable();
    function ProcessCheckApprove(o, doc) {
        if ($(o).prop('checked') == true) {
            arrSelApp.push(doc);
        } else {
            arrSelApp.splice(arrSelApp.indexOf(doc), 1);
        }
        ShowApproveSelected();
    }
    function ProcessCheckBill(o, doc) {
        if ($(o).prop('checked') == true) {
            arrSelBill.push(doc);
        } else {
            arrSelBill.splice(arrSelBill.indexOf(doc), 1);
        }
        ShowBillSelected();
    }

    function ShowApproveSelected() {
        let str = '';
        for (let i = 0; i < arrSelApp.length; i++) {
            if (str !== '') str += ',';
            str += arrSelApp[i];
        }
        $('#txtApprove').val(str);
    }
    function ShowBillSelected() {
        let str = '';
        for (let i = 0; i < arrSelBill.length; i++) {
            if (str !== '') str += ',';
            str += arrSelBill[i];
        }
        $('#txtBilling').val(str);
    }

    function ShowDoc(branch, code) {
        window.open(path + 'JobOrder/AddFuel?Branch=' + branch + '&Code=' + code, '', '');
    }
    function AddData() {
        window.open(path + 'JobOrder/AddFuel','','');
    }
    function RefreshData() {
        window.location.href = path + 'JobOrder/CloseFuel?DateFrom=' + $('#txtDateFrom').val() + '&DateTo=' + $('#txtDateTo').val();
    }
</script>
