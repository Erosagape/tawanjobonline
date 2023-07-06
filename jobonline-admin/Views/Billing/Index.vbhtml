@Code
    ViewData("Title") = "Billing"
    Dim oCusts = ViewBag.CustProfiles
    Dim oCustData = ViewBag.CustData
    Dim oDBLists = Newtonsoft.Json.JsonConvert.SerializeObject(oCustData)
    Dim totalJob = 0
    Dim totalinv = 0
    Dim totalLogin = 0
    Dim sqljob = "
SELECT j.*,jt.JobTypeName,sb.ShipByName
FROM Job_Order j left join 
(SELECT CONVERT(int,ConfigKey) as JobType,ConfigValue as JobTypeName FROM Mas_Config WHERE ConfigCode='JOB_TYPE') jt 
on j.JobType=jt.JobType 
left join 
(SELECT CONVERT(int,ConfigKey) as ShipBy,ConfigValue as ShipByName FROM Mas_Config WHERE ConfigCode='SHIP_BY') sb 
on j.ShipBy=sb.ShipBy
where Year(j.CreateDate)={0} AND Month(j.CreateDate)={1} AND j.JobStatus<>99
ORDER BY j.JobType,j.ShipBy,j.JNo 
"
    Dim sqlInv = "
SELECT h.* FROM Job_InvoiceHeader h 
where Year(h.CreateDate)={0} AND Month(h.CreateDate)={1} AND NOT h.CancelProve<>''
"
    Dim sqlLogin = "
select distinct LogAction as UserID from weblicense.dbo.TWTLog where 
year(logdatetime)={0} and month(logdatetime)={1}
and custID like '{2}%'
AND LogAction NOT IN('admin','cs','test','boat','tawan','pasit')
and ModuleName='LOGIN_SHIPPING' 
"
    Dim sqlLogin0 = "
SELECT tb.* FROM (
select b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+'/'+RIGHT('0'+Convert(varchar,Month(a.LogDateTime)),2) as Period
,REPLACE(a.CustID,b.CustID+'/','') as UserID
,Convert(varchar,Max(a.LogDateTime),103) as LastLogin
from weblicense.dbo.TWTLog a,weblicense.dbo.TWTCustomer b
where b.CustID='{2}' AND CHARINDEX(b.CustID+'/',a.CustID)>0
AND REPLACE(a.CustID,b.CustID+'/','') NOT IN('ADMIN','CS','BOAT','pasit','test')
AND Year(a.LogDateTime)={0} AND Month(a.LogDateTime)={1}
group by b.CustID,b.CustName,Convert(varchar,Year(a.LogDateTime))+'/'+RIGHT('0'+Convert(varchar,Month(a.LogDateTime)),2),REPLACE(a.CustID,b.CustID+'/','')
) tb

"
End Code
<h2>Billing</h2>
<form action="" method="post">
    <input type="hidden" name="sqlJob" value="@sqljob" />
    <input type="hidden" name="sqlInv" value="@sqlInv" />
    <input type="hidden" name="sqlLogin" value="@sqlLogin" />
    <div class="row">
        <div class="col-sm-2">
            Company
        </div>
        <div class="col-sm-3">
            <select class="form-control dropdown" id="selCustomer" name="selCustomer" onchange="PopulateDBList()">
                <option value="">N/A</option>
                @For Each cust In oCusts
                    @<option value="@cust.CustID">@cust.CustName</option>
                Next
            </select>
        </div>
        <div class="col-sm-2">
            Database
        </div>
        <div class="col-sm-3">
            <select class="form-control dropdown" id="selDatabase" name="selDatabase"></select>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            Year :
        </div>
        <div class="col-sm-3">
            <input type="number" class="form-control" name="onYear" value="@ViewBag.YearSel" />
        </div>
        <div class="col-sm-2">
            Month :
        </div>
        <div class="col-sm-3">
            <input type="number" class="form-control" name="onMonth" value="@ViewBag.MonthSel" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            <input type="submit" value="View" Class="btn btn-primary" />
        </div>
    </div>
</form>
<h2>Total Job Used</h2>
@If ViewBag.JobList IsNot Nothing Then
    Dim groupName = ""
    Dim countJob = 0

    @<table class="table table-bordered">
        <thead>
            <tr>
                <th>#</th>
                <th>Job</th>
                <th>Booking</th>
                <th>Cust</th>
            </tr>
        </thead>
        <tbody>
            @For each dr As System.Data.DataRow In ViewBag.JobList
                @If groupName <> dr("JobTypeName") & " / " & dr("ShipByName") Then
                    If countJob <> 0 Then
                        @<tr style="font-weight:bold;">
                            <td colspan="2">Total</td>
                            <td>@groupName</td>
                            <td>@countJob</td>
                        </tr>
                        countJob = 0
                    End If
                    groupName = dr("JobTypeName") & " / " & dr("ShipByName")
                    @<tr style="background-color:lightblue">
                        <td colspan="2">@dr("JobTypeName")</td>
                        <td colspan="2">@dr("ShipByName")</td>
                    </tr>
                End If
                countJob += 1
                @<tr>
                    <td>@countJob</td>
                    <td>@dr("JNo")</td>
                    <td>@dr("BookingNo")</td>
                    <td>@dr("Custcode")</td>
                </tr>
                totalJob += 1
                If totalJob = ViewBag.JobList.Count Then
                    @<tr style="font-weight:bold;">
                        <td colspan="2">Total</td>
                        <td>@groupName</td>
                        <td>@countJob</td>
                    </tr>
                    @<tr style="background-color:lightblue;font-weight:bold;">
                        <td colspan="3">GRAND TOTAL</td>
                        <td>@totalJob</td>
                    </tr>
                End If
            Next
        </tbody>
    </table>
Else
    @ViewBag.JobMessage
End If
<h2>Total Invoice Issued</h2>
@If ViewBag.InvList IsNot Nothing Then

    @<table class="table table-bordered">
    <thead>
        <tr>
            <th>#</th>
            <th>Doc.No</th>
            <th>Ref.No</th>
            <th>Customer</th>
        </tr>
    </thead>
    <tbody>
        @For each dr As System.Data.DataRow In ViewBag.InvList
            totalinv += 1
            @<tr>
                <td>@totalinv</td>
                <td>@dr("DocNo")</td>
                <td>@dr("RefNo")</td>
                <td>@dr("BillToCustCode")</td>
            </tr>
        Next
        <tr style="font-weight:bold;background-color:lightblue;">
            <td colspan="3">Total</td>
            <td>@totalinv</td>
        </tr>
    </tbody>
    </table>
Else
    @ViewBag.InvMessage
End If
<h2>Total User Used</h2>
@If ViewBag.LoginList IsNot Nothing Then

    @<table class="table table-bordered">
        <thead>
            <tr>
                <th>#</th>
                <th>User ID</th>
            </tr>
        </thead>
    <tbody>
        @For each dr As System.Data.DataRow In ViewBag.LoginList
            totalLogin += 1
                @<tr>
        <td>@totalLogin</td>
        <td>@dr("UserID")</td>
                  </tr>
        Next
        <tr style="font-weight:bold;background-color:lightblue;">
            <td>Total</td>
            <td>@totalLogin</td>
        </tr>
    </tbody>
    </table>
Else
    @ViewBag.LoginMessage
End If
<h2>Summary</h2>
<br />
<b>Total Job : @totalJob job(s) </b>
<br />
<b>Total Invoice : @totalinv document(s) </b>
<br />
<b>Total Login : @totalLogin user(s) </b>
<script type = "text/javascript" >
    var dbList = @Html.Raw(oDBLists);
    $('#selCustomer').val('@ViewBag.CustSel');
    PopulateDBList();
    $('#selDatabase').val('@ViewBag.DBSel');

    function PopulateDBList() {
        var id = $('#selCustomer').val();
        var dbFilter = dbList.filter(function (r) {
            return r.CustID == id;
        });
        let html = '';
        $("#selDatabase").empty();
        for(var d of dbFilter) {
            $("#selDatabase").append($("<option>")
                .val(d.Seq)
                .html(d.Comment)
            );
        }
        $('#selDatabase').html = html;
    }
</script>