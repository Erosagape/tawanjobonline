@Code
    ViewData("Title") = "Container"
    Dim bLogin = False
    If ViewBag.User <> "" Then
        bLogin = True
    End If
    Dim rows As New List(Of CContainer)
    If bLogin Then
        rows = New CContainer(ViewBag.CONNECTION_JOB).GetData("")
    End If
End Code
<div class="container">
    <ul class="nav nav-tabs">
        <li class="active">
            <a data-toggle="tab" href="#tabListCon" id="linkTab1">Container List</a>
        </li>
        <li>
            <a data-toggle="tab" href="#tabListBooking" id="linkTab2">Booking List</a>
        </li>
    </ul>
    <div class="tab-content">
        <div class="tab-pane fade in active" id="tabListCon">
            <input type="button" class="btn btn-default w3-purple" value="New Container" onclick="AddNewData()" />
            <table id="tbData" class="table table-responsive">
                <thead>
                    <tr>
                        <th></th>
                        <th>CTN_NO</th>
                        <th>CTN_SIZE</th>
                        <th>VenderCode</th>
                        <th>AcquireDate</th>
                        <th>EndDate</th>
                        <th>CountryCode</th>
                    </tr>
                </thead>
                <tbody>
                    @If rows.Count > 0 Then
                        For Each r In rows
                            @<tr>
                                 <td>
                                     <input type="button" class="btn btn-warning" value="Edit" onclick="EditData('@r.CTN_NO')" />
                                     <input type="button" class="btn btn-info" value="History" onclick="ShowData('@r.CTN_NO')" />
                                 </td>
                                <td>
                                    @r.CTN_NO
                                </td>
                                <td>
                                    @r.CTN_SIZE
                                </td>
                                <td>
                                    @r.VenderCode
                                </td>
                                <td>
                                    @r.AcquisitionDate.ToString("dd/MM/yyyy")
                                </td>
                                <td>
                                    @r.EndDate.ToString("dd/MM/yyyy")
                                </td>
                                <td>
                                    @r.CountryCode
                                </td>
                            </tr>
                        Next
                    End If
                </tbody>
            </table>
        </div>
        <div class="tab-pane fade" id="tabListBooking">
            <div class="row">
                <div class="col-sm-3">
                    <label for="txtVenCode">Vender Code:</label>
                    <div style="display:flex;">
                        <input type="text" id="txtVenCode" class="form-control" style="width:100%;" readonly />
                        <input type="button" class="btn btn-default" value="..." onclick="SearchData('vend')" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <label for="txtVenName">Vender Name</label><br />
                    <input type="text" id="txtVenName" class="form-control" readonly style="width:100%" />
                </div>
                <div class="col-sm-3">
                    <label for="txtContainer">Container</label>
                    <div style="display:flex;">
                        <input type="text" id="txtContainer" class="form-control" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <label for="txtReturnDate">Return From</label>
                    <div style="display:flex;">
                        <input type="date" id="txtReturnDate" class="form-control" />
                        <input type="button" id="btnSearchTrans" class="btn btn-info" value="Search" onclick="FindData()" />
                    </div>
                </div>
            </div>
            <table id="tbTran" class="table table-responsive">
                <thead>
                    <tr>
                        <th>CTN_NO</th>
                        <th>JNo</th>
                        <th>InvNo</th>
                        <th>Port</th>
                        <th>PickupDate</th>
                        <th>LoadDate</th>
                        <th>ReturnDate</th>
                        <th>ReturnPlace</th>
                    </tr>
                </thead>
                <tbody />
            </table>
        </div>
    </div>
</div>
<div id="dvEditor" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                Edit Container
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-sm-4">
                        Container No
                    </div>
                    <div class="col-sm-8">
                        <input type="text" id="txtCTN_NO" class="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        Size
                    </div>
                    <div class="col-sm-8">
                        <input type="text" id="txtCTN_SIZE" class="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        Acquisition Date
                    </div>
                    <div class="col-sm-8">
                        <input type="date" id="txtAcquisitionDate" class="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        End Usage Date
                    </div>
                    <div class="col-sm-8">
                        <input type="date" id="txtEndDate" class="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        Vender Code
                    </div>
                    <div class="col-sm-8">
                        <div class="row">
                            <div class="col-sm-6" style="display:flex;">
                                <input type="text" id="txtVenderCode" class="form-control" style="width:100%;" readonly />
                                <input type="button" class="btn btn-default" value="..." onclick="SearchData('vender')" />
                            </div>
                            <div class="col-sm-6">
                                <input type="text" id="txtVenderName" class="form-control" readonly style="width:100%" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        Country
                    </div>
                    <div class="col-sm-8">
                        <div class="row">
                            <div class="col-sm-6" style="display:flex;">
                                <input type="text" id="txtCountryCode" class="form-control" style="width:100%;" readonly />
                                <input type="button" class="btn btn-default" value="..." onclick="SearchData('country')" />
                            </div>
                            <div class="col-sm-6">
                                <input type="text" id="txtCountryName" class="form-control" readonly style="width:100%" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        Remark
                    </div>
                    <div class="col-sm-8">
                        <textarea id="txtRemark" class="form-control"></textarea>
                    </div>
                </div>

            </div>
            <div class="modal-footer" style="text-align:left;">
                <input type="button" class="btn btn-success" value="Save" onclick="SaveData()" />
                <input type="button" class="btn btn-danger" value="Close" data-dismiss="modal" />
            </div>
        </div>
    </div>
</div>
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var tb=$('#tbData').DataTable();
    var dv = $('#dvLOVs');
    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
        var dv = document.getElementById("dvLOVs");
        CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Vender', response, 2);
        CreateLOV(dv, '#frmSearchCountry', '#tbCountry', 'Country', response, 2);
    });
    function SearchData(type) {
        switch (type) {
            case 'vender':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'vend':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVend);
                break;
            case 'country':
                SetGridCountry(path, '#tbCountry', '#frmSearchCountry', ReadCountry);
                break;
        }
    }
    function ReadVender(dt) {
        $('#txtVenderCode').val(dt.VenCode);
        $('#txtVenderName').val(dt.TName);
    }
    function ReadVend(dt) {
        $('#txtVenCode').val(dt.VenCode);
        $('#txtVenName').val(dt.TName);
    }
    function ReadCountry(dt) {
        $('#txtCountryCode').val(dt.CTYCODE);
        $('#txtCountryName').val(dt.CTYName);
    }
    function SaveData() {
        if ($('#txtCTN_NO').val() == '') {
            ShowMessage('Please enter Container No', true);
            return;
        }
        if ($('#txtCTN_SIZE').val() == '') {
            ShowMessage('Please enter Container Size', true);
            return;
        }
        if ($('#txtVenderCode').val() == '') {
            ShowMessage('Please enter Vender', true);
            return;
        }
        if ($('#txtAcquisitionDate').val() == '') {
            ShowMessage('Please enter Acquire Date', true);
            return;
        }
        if ($('#txtCountryCode').val() == '') {
            ShowMessage('Please enter Country Code', true);
            return;
        }
        if ($('#txtRemark').val() == '') {
            ShowMessage('Please enter Remark', true);
            return;
        }
        var obj = {
            CTN_NO: $('#txtCTN_NO').val(),
            VenderCode: $('#txtVenderCode').val(),
            CTN_SIZE: $('#txtCTN_SIZE').val(),
            AcquisitionDate: CDateEN($('#txtAcquisitionDate').val()),
            EndDate: CDateEN($('#txtEndDate').val()),
            CountryCode: $('#txtCountryCode').val(),
            Remark: $('#txtRemark').val()
        };
        var jsonText = JSON.stringify({ data: obj });
        $.ajax({
            url: "@Url.Action("SetContainer", "JobOrder")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                ShowMessage(response.result.msg);
                if (response.result.data != null) {
                    window.location.reload();
                }
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function AddNewData() {
        $('#txtCTN_NO').val('');
        $('#txtCTN_SIZE').val('');
        $('#txtVenderCode').val('');
        ShowVender(path, '', '#txtVenderName');
        $('#txtCountryCode').val('');
        ShowCountry(path, '', '#txtCountryName');
        $('#txtAcquisitionDate').val('');
        $('#txtEndDate').val('');
        $('#txtRemark').val('');
        $('#dvEditor').modal('show');
    }
    function ShowData(c) {
        $('#txtContainer').val(c);
        $('#txtVenCode').val('');
        $('#txtReturnDate').val('');
        FindData();
    }
    function FindData() {
        let w = '';
        if ($('#txtVenCode').val() != '') {
            if (w != '') w += '&';
            w += 'VenderCode=' + $('#txtVenCode').val();
        }
        if ($('#txtReturnDate').val() !== '') {
            if (w != '') w += '&';
            w += 'DateReturn=' + $('#txtReturnDate').val();
        }
        if ($('#txtContainer').val() !== '') {
            if (w != '') w += '&';
            w += 'Cont=' + $('#txtContainer').val();
        }
        $('#tbTran').hide();
        $.get(path + 'JobOrder/GetContainerReport?' + w).done(function (r) {
            if (r.data.length > 0) {
                let dt = r.data;
                let table = $('#tbTran').dataTable({
                    data: dt,
                    columns: [
                        { data: "CTN_NO", title: "Container" },
                        { data: "JNo", title: "Job" },
                        { data: "InvNo", title: "C.Inv" },
                        { data: "InterPortName", title: "Port" },
                        { data: "TargetYardDate", title: "Yard", render: function (data) { return ShowDate(data); }  },
                        { data: "LoadDate", title: "Load", render: function (data) { return ShowDate(data); }  },
                        { data: "ReturnDate", title: "Return", render: function (data) { return ShowDate(data); } },
                        { data: "PlaceName3", title: "Transport" },
                    ],
                    destroy: true, pageLength: 100
                });
                $('#tbTran').show();
                $('a[href="#tabListBooking"]').click();
            }
        });
    }
    function EditData(ctnno) {
        $.get(path + 'JobOrder/GetContainer?CTN_NO=' + ctnno).done((r) => {
            if (r.container.data.length > 0) {
                let d = r.container.data[0];
                $('#txtCTN_NO').val(d.CTN_NO);
                $('#txtCTN_SIZE').val(d.CTN_SIZE);
                $('#txtVenderCode').val(d.VenderCode);
                ShowVender(path, d.VenderCode, '#txtVenderName');
                $('#txtCountryCode').val(d.CountryCode);
                ShowCountry(path, d.CountryCode, '#txtCountryName');
                $('#txtAcquisitionDate').val(CDateEN(d.AcquisitionDate));
                $('#txtEndDate').val(CDateEN(d.EndDate));
                $('#txtRemark').val(d.Remark);
                $('#dvEditor').modal('show');
            }
        });
    }
</script>

