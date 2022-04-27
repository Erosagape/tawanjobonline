@Code
    ViewData("Title") = "Summary"
End Code
<div style="display:flex;">
    <button class="btn w3-indigo" id="btnAddJob" onclick="CreateNewJob()">Create New</button>
    <button class="btn btn-primary" id="btnListJob" onclick="ShowList()">List Job</button>
    <div style="flex-direction:column">
        <label for="txtJobNo" id="lblJob">Enter Job</label>
        <input type="text" id="txtJobNo" class="form-control" />
    </div>
    <button id="btnJobSlip" class="btn btn-success" onclick="OpenJob()">Show Job</button>
</div>
<h3>Summary By Customers</h3>
<table class="table table-responsive">
    <thead>
        <tr>
            <th>Totals</th>
            <th>Last Date</th>
            <th>Last Job#</th>
            <th>Status</th>
        </tr>
    </thead>
    <tbody>
        @Code
            For Each dr As Data.DataRow In ViewBag.DataCount1.Rows
                @<tr style="background-color:aquamarine;">
                    <td><b>@dr("TotalJob")</b></td>
                    @If ViewBag.PROFILE_DEFAULT_LANG = "EN" Then
                        @<td colspan="3">
                            <a onclick="LoadJob('?CustCode=@dr("CustCode").ToString()')"><b>@dr("NameEng").ToString() / @dr("CustCode").ToString()</b></a>
                        </td>
                    Else
                        @<td colspan="3">
                            <a onclick="LoadJob('?CustCode=@dr("CustCode").ToString()')"><b>@dr("NameThai").ToString() / @dr("CustCode").ToString()</b></a>
                        </td>
                    End If
                </tr>
                @For Each row As CConfig In ViewBag.DataStatus
                    If dr(row.ConfigValue) > 0 Then
                        @<tr>
                            <td>@dr(row.ConfigValue).ToString()</td>
                            @If (dr("LastWorkDate").Equals(System.DBNull.Value)) Then
                                @<td>@dr("LastWorkDate").ToString()</td>
                            Else
                                @<td>@Convert.ToDateTime(dr("LastWorkDate")).ToString("dd/MM/yyyy")</td>
                            End If
                            <td>@dr("LastJobNo").ToString()</td>
                            <td>
                                <a onclick="LoadJob('?CustCode=@dr("CustCode").ToString()&status=@row.ConfigKey')"><b>@row.ConfigValue</b></a>
                            </td>
                        </tr>
                    End If
                Next
            Next
        End Code
    </tbody>
</table>
<div id="dvLOVs"></div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
        var dv = document.getElementById("dvLOVs");
        CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job Numbers', response, 3);
    });
    $('#txtJobNo').keydown(function (e) {
        if (e.which == 13) {
            if ($('#txtJobNo').val() !== '') {
                OpenJob();
            }
        }
    });

    function LoadJob(w) {
        SetGridJob(path, '#tbJob', '#frmSearchJob', w, ReadJob);
    }
    function ReadJob(dt) {
        window.open(path + 'joborder/showjob?BranchCode=' + dt.BranchCode + '&JNo=' + dt.JNo);
    }
    function OpenJob() {
        $.get(path + 'joborder/updatejobstatus?NoLog=Y&BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=' + $('#txtJobNo').val(), function (r) {
            //ShowMessage(r);
            window.open(path + 'joborder/showjob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=' + $('#txtJobNo').val());
        });
    }
    function CreateNewJob() {
        window.open(path + 'joborder/createjob');
    }
    function ShowList() {
        window.open(path + 'joborder/index');
    }
</script>

