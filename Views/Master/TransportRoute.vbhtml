@Code
    ViewBag.Title = "Transport Route"
End Code
<div class="row">
    <div class="col-sm-1">
        Type:
        <br/>
        <select id="cboTemplate" class="form-control dropdown" onclick="GenRoute()">
            <option value="3124" selected>
                EXPORT
            </option>
            <option value="4123">
                IMPORT
            </option>
        </select>
    </div>
    <div class="col-sm-1">
        #<br />
        <input type="text" id="txtLocationID" class="form-control" value="0" disabled />
    </div>
    <div class="col-sm-8">
        <label id="lblRouteFormat"></label><br/>
        <input type="text" id="txtLocationRoute" class="form-control" disabled />
    </div>
    <div class="col-sm-1">
        <br/>
        <input type="button" class="btn w3-purple" style="width:100%" value="New Route" onclick="ClearRoute()" />
    </div>
    <div class="col-sm-1">        
        <br/>
        <input type="button" id="btnSaveRoute" style="width:100%" value="Save Route" class="btn btn-success" onclick="SaveRoute()" />
    </div>
</div>
<div class="row">
    <div class="col-md-3">
        Plant List:<br />
        <div id="lstPlace1"></div>
    </div>
    <div class="col-md-3">
        Place List:<br />
        <div id="lstPlace2"></div>
    </div>
    <div class="col-md-3">
        Yard List:<br />
        <div id="lstPlace3"></div>
    </div>
    <div class="col-md-3">
        Port List:<br />
        <div id="lstPlace4"></div>
    </div>
</div>
<div class="row">
    <div class="col-md-3">
        Plant<br />
        <input type="text" class="form-control" id="txtPlace1" onchange="GenRoute()" />
        Address<br />
        <textarea class="form-control" id="txtAddress1"></textarea>
        Contact<br />
        <input type="text" class="form-control" id="txtContact1" />
        <input type="button" class="btn btn-success" value="Save" onclick="SavePlace(1)" />
        <input type="button" class="btn w3-purple" value="Clear" onclick="ClearPlace(1)" />
    </div>
    <div class="col-md-3">
        Place<br />
        <input type="text" class="form-control" id="txtPlace2" onchange="GenRoute()" />
        Address<br />
        <textarea class="form-control" id="txtAddress2"></textarea>
        Contact<br />
        <input type="text" class="form-control" id="txtContact2" />
        <input type="button" class="btn btn-success" value="Save" onclick="SavePlace(2)" />
        <input type="button" class="btn w3-purple" value="Clear" onclick="ClearPlace(2)" />
    </div>
    <div class="col-md-3">
        Yard<br />
        <input type="text" class="form-control" id="txtPlace3" onchange="GenRoute()" />
        Address<br />
        <textarea class="form-control" id="txtAddress3"></textarea>
        Contact<br />
        <input type="text" class="form-control" id="txtContact3" />
        <input type="button" class="btn btn-success" value="Save" onclick="SavePlace(3)" />
        <input type="button" class="btn w3-purple" value="Clear" onclick="ClearPlace(3)" />
    </div>
    <div class="col-md-3">
        Port<br />
        <input type="text" class="form-control" id="txtPlace4" onchange="GenRoute()" />
        Address<br />
        <textarea class="form-control" id="txtAddress4"></textarea>
        Contact<br />
        <input type="text" class="form-control" id="txtContact4" />
        <input type="button" class="btn btn-success" value="Save" onclick="SavePlace(4)" />
        <input type="button" class="btn w3-purple" value="Clear" onclick="ClearPlace(4)" />
    </div>
</div>
<table id="tbDetail" class="table table-responsive">
    <thead>
        <tr>
            <th>Route ID</th>
            <th>Place1</th>
            <th>Place2</th>
            <th>Place3</th>
            <th>Place4</th>
            <th>Delete</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    ShowData();
    LoadGrid();
    function ShowData() {
        LoadPlace(1);
        LoadPlace(2);
        LoadPlace(3);
        LoadPlace(4);
    }
    function LoadGrid() {
        $.get(path + 'JobOrder/GetTransportRoute').done((r) => {
            if (r.transportroute.data.length > 0) {
                $('#tbDetail').DataTable({
                    data: r.transportroute.data,
                    columns: [
                        { data: "LocationID", title: "Route ID"},
                        { data: "Place1", title: "Place1" },
                        { data: "Place2", title: "Place2" },
                        { data: "Place3", title: "Place3" },
                        { data: "Place4", title: "Place4" },
                        {
                            data: null, "title": "Edit",
                            render: function (data) {
                                let html = '';
                                html += '<button class="btn btn-danger" onclick="DeleteRoute(' + data.LocationID + ')">Delete</button>';
                                html += '<button class="btn btn-warning" onclick="ShowPrice(' + data.LocationID + ')">Prices</button>';
                                return html;
                            }
                        }
                    ],
                    destroy:true
                });
                $('#tbDetail tbody').on('click', 'tr', function () {
                    $('#tbDetail tbody > tr').removeClass('selected');
                    $(this).addClass('selected');

                    var data = $('#tbDetail').DataTable().row(this).data();
                    $('#txtLocationID').val(data.LocationID);
                    $('#txtLocationRoute').val(data.LocationRoute);
                    $('#txtPlace1').val(data.Place1);
                    $('#txtAddress1').val(data.Address1);                    
                    $('#txtContact1').val(data.Contact1);
                    $('#txtPlace2').val(data.Place2);
                    $('#txtAddress2').val(data.Address2);                    
                    $('#txtContact2').val(data.Contact2);
                    $('#txtPlace3').val(data.Place3);
                    $('#txtAddress3').val(data.Address3);                    
                    $('#txtContact3').val(data.Contact3);
                    $('#txtPlace4').val(data.Place4);
                    $('#txtAddress4').val(data.Address4);                    
                    $('#txtContact4').val(data.Contact4);
                });
            }
        });
    }
    function DeleteRoute(id) {
        alert(id);
    }
    function ShowPrice(id) {
        alert(id);
    }
    function ClearRoute() {
        $('#txtLocationID').val(0);
    }
    function ClearPlace(id) {
        $('#txtPlace' + id).val('').change();
        $('#txtAddress' + id).val('');
        $('#txtContact' + id).val('');
    }
    function LoadPlace(id) {
        $.get(path + 'Master/GetTransportPlace?Type=' + id).done(function (r) {
            if (r.transportplace.data.length > 0) {
                html = '';                
                for (let o of r.transportplace.data) {
                    html += '<button style="width:100%" onclick="SetPlace(' + o.PlaceType + ',' + "'" + o.PlaceName + "'" + ')">';
                    html += o.PlaceName;
                    html +='</button>';
                }
                $('#lstPlace' + id).html(html);
            }
        });
    }
    function SetPlace(id, val) {
        $.get(path + 'Master/GetTransportPlace?Code=' + val).done(function (r) {
            if (r.transportplace.data.length > 0) {
                let d = r.transportplace.data[0];
                $('#txtAddress'+ d.PlaceType).val(d.PlaceAddress);
                $('#txtContact' + d.PlaceType).val(d.PlaceContact);
            }
        });
        $('#txtPlace' + id).val(val).change();
    }
    function GetFormat(id) {
        let str = '';
        for (let i = 0; i < 4;i++) {
            switch (id.substr(i, 1)) {
                case '1':
                    str += (str !== '' ? ',' : '') + 'Plant';
                    break;
                case '2':
                    str += (str !== '' ? ',' : '') + 'Place';
                    break;
                case '3':
                    str += (str !== '' ? ',' : '') + 'Yard';
                    break;
                case '4':
                    str += (str !== '' ? ',' : '') + 'Port';
                    break;
            }
        }
        return str;
    }
    function GenRoute() {
        $('#lblRouteFormat').text(GetFormat($('#cboTemplate').val()));
        let idx1 = $('#txtPlace' + $('#cboTemplate').val().substr(0, 1)).val();
        let idx2 = $('#txtPlace' + $('#cboTemplate').val().substr(1, 1)).val();
        let idx3 = $('#txtPlace' + $('#cboTemplate').val().substr(2, 1)).val();
        let idx4 = $('#txtPlace' + $('#cboTemplate').val().substr(3, 1)).val();
        let str = '';
        if(idx1!=='') str += (str !== '' ? '=>' : '') + idx1;
        if(idx2!=='') str += (str !== '' ? '=>' : '') + idx2;
        if(idx3!=='') str += (str !== '' ? '=>' : '') + idx3;
        if(idx4!=='') str += (str !== '' ? '=>' : '') + idx4;
        $('#txtLocationRoute').val(str);
    }
    function SaveRoute() {
        alert($('#txtLocationRoute').val());
    }
    function SavePlace(id) {
        let pname = $('#txtPlace' + id).val();
        let obj = {
            PlaceType: id,
            PlaceName: pname,
            PlaceAddress: $('#txtAddress' + id).val(),
            PlaceContact: $('#txtContact' + id).val()
        };
        let json = JSON.stringify({ data: obj });
        ShowConfirm('are you sure to save ' + pname, function (ask) {
            if (ask == true) {
                postData(path + 'Master/SetTransportPlace', json, function (r) {
                    ShowData();
                    ShowMessage(r.result.msg);
                });
            }
        });
    }
    function SaveRoute() {
        let obj = {
            LocationID: CNum($('#txtLocationID').val()),
            Place1: $('#txtPlace1').val(),
            Place2: $('#txtPlace2').val(),
            Place3: $('#txtPlace3').val(),
            Place4: $('#txtPlace4').val(),
            Address1: $('#txtAddress1').val(),
            Address2: $('#txtAddress2').val(),
            Address3: $('#txtAddress3').val(),
            Address4: $('#txtAddress4').val(),
            Contact1: $('#txtContact1').val(),
            Contact2: $('#txtContact2').val(),
            Contact3: $('#txtContact3').val(),
            Contact4: $('#txtContact4').val(),
            LocationRoute: $('#txtLocationRoute').val(),
            IsActive: true
        };
        let json = JSON.stringify({ data: obj });
        ShowConfirm('are you sure to save ' + $('#txtLocationRoute').val(), function (ask) {
            if (ask == true) {
                postData(path + 'JobOrder/SetTransportRoute', json, function (r) {
                    ShowMessage(r.result.msg);
                    LoadGrid();
                });
            }
        });
    }
</script>