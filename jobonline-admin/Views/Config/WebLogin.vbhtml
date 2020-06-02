@Code
    ViewData("Title") = "Web Log-in History"
End Code
Customer<br />
<select id="txtCustID" class="form-control dropdown">
    @For Each item In ViewBag.Cust
        @<option value="@item.CustID">@item.CustName</option>
    Next
</select>
<button id="btnSearch" class="btn btn-default" onclick="ShowData()">Show Data</button>
<table id="tbData" class="table table-responsive">
    <thead>
        <tr>
            <th>AppID</th>
            <th>CustID</th>
            <th>UserLogIN</th>
            <th>FromIP</th>
            <th>LoginDateTime</th>
            <th>ExpireDateTime</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<script type="text/javascript">
        const path = '@Url.Content("~")';
    function ShowData() {
        let w = '?Cust=' + $('#txtCustID').val();
        getData(path + 'Config/GetWebLogin' +w, (r) => {
            if (r !== null) {
                LoadData(r);
            }
        });
    }
    function LoadData(dr) {
        let html = '';
        for (let d of dr) {
            html += '<tr>';
            html += '<td>' + d.AppID + '</td>';
            html += '<td>' + d.CustID + '</td>';
            html += '<td>' + d.UserLogIN + '</td>';
            html += '<td>' + d.FromIP + '</td>';
            html += '<td>' + d.LoginDateTime + '</td>';
            html += '<td>' + d.ExpireDateTime +'</td>';
            html += '</tr>';
        }
        $('#tbData tbody').html(html);
        alert("Search Complete");
    }
</script>