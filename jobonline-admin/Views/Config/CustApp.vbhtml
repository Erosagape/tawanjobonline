@Code
    ViewData("Title") = "Customer in Applications"
End Code
<div class="row">
    <div class="col-sm-3">
        Application<br/>
        <select id="txtAppID" class="form-control dropdown">
            @For Each item In ViewBag.App
                @<option value="@item.AppID">@item.AppNameTH</option>
            Next
        </select>
    </div>
    <div class="col-sm-5">
        Customer<br />
        <select id="txtCustID" class="form-control dropdown">
            @For Each item In ViewBag.Cust
                @<option value="@item.CustID">@item.CustName</option>
            Next
        </select>
    </div>
    <div class="col-sm-2">
        Seq<br/>
        <input type="number" id="txtSeq" class="form-control" />
    </div>
    <div class="col-sm-2">
        DB
        <br/>
        <select id="txtWebDBType" class="form-control dropdown">
            <option value="0">SQL Server</option>
            <option value="1">MY SQL</option>
            <option value="2">Access</option>
        </select> 
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        Master DB
        <br/>
        <input type="text" id="txtWebMasDB" class="form-control" />
    </div>
    <div class="col-sm-9">
        Connection String
        <br />
        <textarea id="txtWebMasConnect" class="form-control"></textarea>
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        Transaction DB
        <br />
        <input type="text" id="txtWebTranDB" class="form-control" />
    </div>
    <div class="col-sm-9">
        Connection String
        <br />
        <div style="display:flex">
            <textarea id="txtWebTranConnect" class="form-control"></textarea>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-sm-4">
        Web URL
        <br/>
        <input type="text" id="txtWebURL" class="form-control" />
        <button class="btn btn-primary" onclick="OpenWebURL()">Go</button>
    </div>
    <div class="col-sm-2">
        Language
        <br />
        <select id="txtDefaultLang" class="form-control dropdown">
            <option value="TH">ไทย</option>
            <option value="EN">ENG</option>
        </select>
    </div>
    <div class="col-sm-2">
        Status
        <br />
        <select id="txtActive" class="form-control dropdown">
            <option value="0">NO</option>
            <option value="1">YES</option>
        </select>
    </div>
    <div class="col-sm-4">
        Subscription
        <br />
        <select id="txtSubscriptionID" class="form-control dropdown">
            @For Each item In ViewBag.Subscription
                @<option value="@item.SubscriptionID">@item.SubscriptionName</option>
            Next
        </select>
    </div>
</div>
<button id="btnSave" class="btn btn-success" onclick="SaveData()">Save Data</button>
<button id="btnTestConnect" class="btn btn-warning" onclick="TestConnect()">Test Config</button>
<Table class="table table-responsive">
    <thead>
        <tr>
            <th>AppID</th>
            <th>CustId</th>
            <th>Seq</th>
            <th>WebURL</th>
            <th>WebTransDB</th>
            <th>WebMasDB</th>
            <th>Active</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In ViewBag.Data
        @<tr>
            <td><a href="#" onclick="SearchData('@item.AppID','@item.CustID',@item.Seq)">@item.AppID</a></td>
            <td>@item.CustID</td>
            <td>@item.Seq</td>
            <td>@item.WebURL</td>
            <td>@item.WebTranDB</td>
            <td>@item.WebMasDB</td>
            <td>@item.Active</td>
        </tr>
        Next
    </tbody>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    function SearchData(app,cust,seq) {
        getData(path + 'Config/GetCustomerApp?App='+ app +'&Cust='+ cust +'&ID=' + seq, (data) => {
            if (data.length > 0) {
                $('#txtAppID').val(data[0].AppID);
                $('#txtCustID').val(data[0].CustID);
                $('#txtWebURL').val(data[0].WebURL);
                $('#txtWebTranDB').val(data[0].WebTranDB);
                $('#txtWebMasDB').val(data[0].WebMasDB);
                $('#txtWebTranConnect').val(data[0].WebTranConnect);
                $('#txtWebMasConnect').val(data[0].WebMasConnect);
                $('#txtActive').val(data[0].Active==true?1 :0);
                $('#txtSubscriptionID').val(data[0].SubscriptionID);
                $('#txtSeq').val(data[0].Seq);
                $('#txtDefaultLang').val(data[0].DefaultLang);
            }
        });
    }
    function SaveData() {
        let obj = {
            AppID: $('#txtAppID').val(),
            CustID: $('#txtCustID').val(),
            WebURL: $('#txtWebURL').val(),
            WebDBType: $('#txtWebDBType').val(),
            WebTranDB: $('#txtWebTranDB').val(),
            WebMasDB: $('#txtWebMasDB').val(),
            WebTranConnect: $('#txtWebTranConnect').val(),
            WebMasConnect: $('#txtWebMasConnect').val(),
            Active: $('#txtActive').val()==1 ? true:false,
            SubscriptionID: $('#txtSubscriptionID').val(),
            Seq: $('#txtSeq').val(),
            DefaultLang: $('#txtDefaultLang').val()
        }
        let json = JSON.stringify({ data: obj });
        postData(path + 'Config/SetCustomerApp', json, (msg) => {
            alert(msg);
            location.reload();
        });
        }
    function OpenWebURL() {
        window.open("http://" + $('#txtWebURL').val(),'','');
        }
    function TestConnect() {
        getData(path + 'home/testconnectapplication?cust=' + $('#txtCustID').val() + '&app=' + $('#txtAppID').val(), function (r) {
            if (r !== null) {
                alert(r.result);
            }
        });
    }
</script>
