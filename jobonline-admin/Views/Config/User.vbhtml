@Code
    ViewData("Title") = "Web Users"
End Code
<div class="row">
    <div class="col-sm-4">
        User ID :<br/>
        <input type="text" id="txtTWTUserID" class="form-control" />
    </div>
    <div class="col-sm-4">
        User Name:<br />
        <input type="text" id="txtTWTUserName" class="form-control" />
    </div>
    <div class="col-sm-4">
        Password:<br />
        <input type="password" id="txtTWTUserPassword" class="form-control" />
    </div>
</div>
<button id="btnSave" class="btn btn-success" onclick="SaveData()">Save Data</button>
<table id="tbData" class="table table-responsive">
    <thead>
        <tr>
            <th>User ID</th>
            <th>User Name</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In ViewBag.Data
            @<tr>
                <td><a href="#" onclick="SearchData('@item.TWTUserID')">@item.TWTUserID</a></td>
                <td>@item.TWTUserName</td>
            </tr>
        Next
    </tbody>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function SearchData(id) {
        getData(path + 'Config/GetUser?Code=' + id, (data) => {
            if (data.length > 0) {
                $('#txtTWTUserID').val(data[0].TWTUserID);
                $('#txtTWTUserName').val(data[0].TWTUserName);
                $('#txtTWTUserPassword').val(data[0].TWTUserPassword);
            }
        });
    }
    function SaveData() {
        let obj = {
            TWTUserID: $('#txtTWTUserID').val(),
            TWTUserName: $('#txtTWTUserName').val(),
            TWTUserPassword: $('#txtTWTUserPassword').val()
        };
        let json = JSON.stringify({ data: obj });
        postData(path + 'Config/SetUser', json, (msg) => {
            alert(msg);
            location.reload();
        });
    }
</script>
