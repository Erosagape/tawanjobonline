<style>
    a {
        font-weight:bold;
    }
</style>
<div class="row" style="margin:5px 5px 5px 5px">
    <div class="col-sm-3">
        <div>
            <a href="/Config/Cust">Add/Edit Customer</a>
        </div>
        <div>
            <a href="/Config/App">Add/Edit Application</a>
        </div>
        <div>
            <a href="/Config/Subscription">Add/Edit Subscription</a>
        </div>
        <div>
            <a href="/Config/CustApp">Add/Edit Customer For Application</a>
        </div>
        <div>
            <a href="/Config/Users">Add/Edit Web User</a>
        </div>
        <div>
            <a href="/Config/Log">Action History Log</a>
        </div>
        <div>
            <a href="/Config/WebLogin">Web Log-in History Log</a>
        </div>
        <div>
            <a href="/Admin/Billing">TAWAN BILLING Monthly Report</a>
        </div>
    </div>
    <div class="col-sm-9">
        <table class="table table-bordered" style="width:100%">
            <thead>
                <tr style="background-color:lightgray">
                    <th style="width:20%">Variable Name</th>
                    <th style="width:40%">Current Values</th>
                    <th style="width:40%">New Values</th>
                </tr>
            </thead>
            <tbody>
                @Code
                    For Each vwData In ViewData
                        @<tr>
                            <td>@vwData.Key</td>
                            <td>@vwData.Value</td>
                            <td><input type="text" id="txt@vwData.Key" value="@vwData.Value" /></td>
                        </tr>
                    Next
                End Code
            </tbody>
        </table>
    </div>
</div>

