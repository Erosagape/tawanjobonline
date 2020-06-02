@Code
    ViewData("Title") = "Action History Log"
End Code
<div class="row">
    <div class="col-sm-6">
        Customer<br />
        <select id="txtCustID" class="form-control dropdown">
            @For Each item In ViewBag.Cust
                @<option value="@item.CustID">@item.CustName</option>
            Next
        </select>
    </div>
    <div class="col-sm-3">
        Date From<br/>
        <input type="date" id="txtDateFrom" />
    </div>
    <div class="col-sm-3">
        Date To<br />
        <input type="date" id="txtDateTo" />
    </div>
</div>
<div class="row">
    <div class="col-sm-4">
        <input type="checkbox" class="checkbox" id="chkIsError" /> Error
    </div>
    <div class="col-sm-4">

    </div>
    <div class="col-sm-4">
        <button id="btnSearch" class="btn btn-default" onclick="ShowData()">Show Data</button>
    </div>
</div>
<table id="tbData" class="table table-responsive">
    <thead>
        <tr>
            <th>LogDateTime</th>
            <th>CustID</th>
            <th>FromIP</th>
            <th>ModuleName</th>
            <th>LogAction</th>
            <th>JsonData</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function ShowData() {
        let w = '';
        if ($('#chkIsError').prop('checked')) {
            w += '?Error=1';
        } else {
            w += '?Error=0';
        }
        if ($('#txtDateFrom').val() !== '') {
            w = w + '&DateFrom=' + CDateEN($('#txtDateFrom').val());
        }
        if ($('#txtDateTo').val() !== '') {
            w = w + '&DateTo=' + CDateEN($('#txtDateTo').val());
        }
        w += '&Cust=' + $('#txtCustID').val();
        getData(path + 'Config/GetLog' +w, (r) => {
            if (r !== null) {
                LoadData(r);
            }
        });
    }
    function LoadData(dr) {
        let html = '';
        for (let d of dr) {
            html += '<tr>';
            html += '<td>' + d.LogDateTime + '</td>';
            html += '<td>' + d.CustID + '</td>';
            html += '<td>' + d.FromIP + '</td>';
            html += '<td>' + d.ModuleName + '</td>';
            html += '<td>' + d.LogAction + '</td>';
            html += '<td>' + d.JsonData +'</td>';
            html += '</tr>';
        }
        $('#tbData tbody').html(html);
        alert("Search Complete");
    }
</script>
