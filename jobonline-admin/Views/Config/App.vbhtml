@Code
    ViewData("Title") = "App"
End Code

<h2 style="background-color:greenyellow">Application</h2>
<div class="row">
    <div class="col-sm-2">
        App ID
    </div>
    <div class="col-sm-4">
        <input type="text" class="form-control" id="txtAppID" />
    </div>
    <div class="col-sm-2">
        App Main URL
    </div>
    <div class="col-sm-4">
        <input type="text" class="form-control" id="txtAppMainURL" />
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        Name(TH)
    </div>
    <div class="col-sm-4">
        <input type="text" class="form-control" id="txtAppNameTH" />
    </div>
    <div class="col-sm-2">
        Name(EN)
    </div>
    <div class="col-sm-4">
        <input type="text" class="form-control" id="txtAppNameEN" />
    </div>
</div>
<button id="btnSave" class="btn btn-success" onclick="SaveData()">Save Data</button>
<table id="tbData" class="table table-responsive">
    <thead>
        <tr>
            <th>App ID</th>
            <th>App Name</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In ViewBag.App
            @<tr>
                <td><a href="#" onclick="SearchData('@item.AppID')">@item.AppID</a></td>
                <td>@item.AppNameTH</td>
            </tr>
        Next
    </tbody>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function SearchData(id) {
        getData(path +'Config/GetApp?Code=' + id,(r)=> {
            if (r !== null) {
                LoadData(r[0]);
            }
        });
    }
    function LoadData(dr) {
        $('#txtAppID').val(dr.AppID);
        $('#txtAppMainURL').val(dr.AppMainURL);
        $('#txtAppNameTH').val(dr.AppNameTH);
        $('#txtAppNameEN').val(dr.AppNameEN);
    }
    function SaveData() {
        let obj = {
            AppID: $('#txtAppID').val(),
            AppMainURL: $('#txtAppMainURL').val(),
            AppNameTH: $('#txtAppNameTH').val(),
            AppNameEN: $('#txtAppNameEN').val()
        };
        let json = JSON.stringify({ data: obj });
        postData(path + 'Config/SetApp', json, (msg) => {
            alert(msg);
            location.reload();
        });
    }
</script>