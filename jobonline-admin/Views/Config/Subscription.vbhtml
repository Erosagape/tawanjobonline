@Code
    ViewData("Title") = "Subscriptions"
End Code
<div class="row">
    <div class="col-sm-2">
        ID :<br />
        <input type="number" id="txtSubScriptionID" class="form-control" />
    </div>
    <div class="col-sm-4">
        Name:<br />
        <input type="text" id="txtSubscriptionName" class="form-control" />
    </div>
    <div class="col-sm-4">
        Description:
        <br />
        <textarea id="txtSubscriptionDesc" class="form-control"></textarea>
    </div>
    <div class="col-sm-2">
        Edition:
        <br/>
        <input type="number" id="txtEdition" class="form-control" />
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        Application:
        <br/>
        <select id="txtAppID" class="form-control dropdown">
            @For Each item In ViewBag.App
                @<option value="@item.AppID">@item.AppNameTH</option>
            Next
        </select> 
    </div>
    <div Class="col-sm-3">
        Begin Date:
        <br/>
        <input type="text" id="txtBeginDate" class="form-control" />
    </div>
    <div Class="col-sm-3">
        Expire Date:
        <br />
        <input type="text" id="txtExpireDate" class="form-control" />
    </div>
    <div Class="col-sm-3">
        Login Count:
        <br/>
        <input type="number" id="txtLoginCount" class="form-control" />
    </div>
</div>
<input type="button" id="btnSave" class="btn btn-success" value="Save Data" onclick="SaveData()" />
<Table id = "tbData" Class="table table-responsive">
    <thead>
        <tr>
            <th> Subscription ID</th>
            <th>Subscription Name</th>
            <th>Begin Date</th>
            <th>Expire Date</th>
            <th>Login Count</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In ViewBag.Data
            @<tr>
                <td><a href="#" onclick="SearchData('@item.SubScriptionID')">@item.SubScriptionID</a></td>
                <td>@item.SubscriptionName</td>
                <td>@item.BeginDate</td>
                <td>@item.ExpireDate</td>
                <td>@item.LoginCount</td>
            </tr>
        Next
    </tbody>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function SearchData(id) {
        getData(path + 'Config/GetSubscription?ID=' + id, (data) => {
            if (data.length > 0) {
                $('#txtSubScriptionID').val(data[0].SubScriptionID);
                $('#txtSubscriptionName').val(data[0].SubscriptionName);
                $('#txtSubscriptionDesc').val(data[0].SubscriptionDesc);
                $('#txtAppID').val(data[0].AppID);
                $('#txtEdition').val(data[0].Edition);
                $('#txtBeginDate').val(ShowDate(data[0].BeginDate));
                $('#txtExpireDate').val(ShowDate(data[0].ExpireDate));
                $('#txtLoginCount').val(data[0].LoginCount);
            }
        });
    }
    function SaveData() {
        let obj = {
            SubScriptionID: $('#txtSubScriptionID').val(),
            SubscriptionName: $('#txtSubscriptionName').val(),
            SubscriptionDesc: $('#txtSubscriptionDesc').val(),
            AppID: $('#txtAppID').val(),
            Edition: $('#txtEdition').val(),
            BeginDate: CDateEN($('#txtBeginDate').val()),
            ExpireDate: CDateEN($('#txtExpireDate').val()),
            LoginCount: $('#txtLoginCount').val()
        };
        let json = JSON.stringify({ data: obj });
        postData(path + 'Config/SetSubscription', json, (msg) => {
            alert(msg);
            location.reload();
        });
    }
</script>

