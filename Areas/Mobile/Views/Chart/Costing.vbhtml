@Code
    ViewData("Title") = "Costing and Profit"
    Dim dateFrom = New Date(Today.Year, Today.Month, 1)
    Dim dateTo = dateFrom.AddMonths(1).AddDays(-1)
    Dim custCode = ""
    Dim jobType = ""
    Dim shipBy = ""
    Dim managerCode = ""
    Dim sqlw = ""
    If Request.QueryString("DateFrom") IsNot Nothing Then
        sqlw &= " AND j.DocDate>='" & Request.QueryString("DateFrom") & "' "
        dateFrom = Convert.ToDateTime(Request.QueryString("DateFrom"))
    End If
    If Request.QueryString("DateTo") IsNot Nothing Then
        sqlw &= " AND j.DocDate<='" & Request.QueryString("DateTo") & "' "
        dateTo = Convert.ToDateTime(Request.QueryString("DateTo"))
    End If
    If Request.QueryString("CustCode") IsNot Nothing Then
        sqlw &= " AND j.CustCode='" & Request.QueryString("CustCode") & "' "
        custCode = Request.QueryString("CustCode")
    End If
    If Request.QueryString("JobType") IsNot Nothing Then
        sqlw &= " AND j.JobType=" & Request.QueryString("JobType") & ""
        jobType = Request.QueryString("JobType")
    End If
    If Request.QueryString("ShipBy") IsNot Nothing Then
        sqlw &= " AND j.ShipBy=" & Request.QueryString("ShipBy") & " "
        shipBy = Request.QueryString("ShipBy")
    End If
    If Request.QueryString("SalesBy") IsNot Nothing Then
        sqlw &= " AND j.ManagerCode='" & Request.QueryString("SalesBy") & "' "
        managerCode = Request.QueryString("SalesBy")
    End If
    Dim sql = "
WITH t as
(
SELECT 
(CASE WHEN j.JobType=1 THEN j.ETADate ELSE j.ETDDate END) as VesselDate,
j.*,d.SICode,d.SDescription,d.LinkBillNo,d.UsedAmount,s.IsExpense,s.IsCredit,s.IsHaveSlip
FROM Job_Order as j
INNER JOIN Job_ClearDetail as d
on CONCAT(j.BranchCode,j.JNo)=CONCAT(d.BranchCode,d.JobNo)
INNER JOIN Job_ClearHeader as h
ON CONCAT(d.BranchCode,d.ClrNo)=CONCAT(h.BranchCode,h.ClrNo) AND h.DocStatus<>99
INNER JOIN Job_SrvSingle s ON d.SIcode=s.SICode
WHERE d.BNet>0 " & sqlw & "
)
select JobYear,JobMonth,serviceAmount,costAmount
from (
select Year(DocDate) as JobYear, Month(DocDate) as JobMonth,
sum(case when isExpense=1 or (IsCredit=1 and LinkBillNo='') then UsedAmount else 0 end) as costAmount,
sum(case when isExpense=0 and LinkBillNo<>'' then UsedAmount else 0 end) as invoiceAmount,
sum(case when isExpense=0 and IsCredit=1 and LinkBillNo<>'' then UsedAmount else 0 end) as advanceAmount,
sum(case when isExpense=0 and IsCredit=0 and LinkBillNo<>'' then UsedAmount else 0 end) as serviceAmount,
sum(case when isExpense=0 and IsCredit=0 and LinkBillNo<>'' then UsedAmount else (case when IsExpense=1 or (IsCredit=1 and LinkBillNo='') then UsedAmount*-1 else 0 end) end) as profitAmount
from t
group by Year(DocDate),Month(DocDate)
) v
order by 1,2
"
    Dim tb = New CUtil(ViewBag.JobConn).GetTableFromSQL(sql)
    Dim jt = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='JOB_TYPE'")
    Dim sb = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY'")
    Dim cust = New CCompany(ViewBag.JobConn).GetData("")
    Dim user = New CUser(ViewBag.JobConn).GetData("")
End Code
<div class="container">
    <div class="row">
        <div class="col-sm-3">
            From Date<br />
            <input type="date" id="txtDateFrom" class="form-control" value="@dateFrom.ToString("yyyy-MM-dd")" />
        </div>
        <div class="col-sm-3">
            To Date<br />
            <input type="date" id="txtDateTo" class="form-control" value="@dateTo.ToString("yyyy-MM-dd")" />
        </div>
        <div class="col-sm-3">
            Job Type<br />
                    <select id="cboJobType" class="form-control dropdown">
                        @For Each row In jt
                            If row.ConfigKey.Equals(jobType) Then
                                @<option value="@row.ConfigKey" selected>@row.ConfigValue</option>
                            Else
                                @<option value="@row.ConfigKey">@row.ConfigValue</option>
                            End If
                        Next
                    </select>
        </div>
        <div class="col-sm-3">
            Ship By<br />
            <select id="cboShipBy" class="form-control dropdown">
                @For Each row In sb
                    If row.ConfigKey.Equals(shipBy) Then
                        @<option value="@row.ConfigKey" selected>@row.ConfigValue</option>
                    Else
                        @<option value="@row.ConfigKey">@row.ConfigValue</option>
                    End If
                Next
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            Customer <br />
                     <div style="display:flex;flex-direction:column">
                         <input type="text" id="txtCustCode" class="form-control" style="width:20%" />
                         <input type="text" id="txtCustName" class="form-control" style="width:80%" readonly />
                     </div>
        </div>
        <div class="col-sm-4">
            Sales By<br />
            <div style="display:flex;flex-direction:column">
                <input type="text" id="txtManagerCode" class="form-control" style="width:20%" />
                <input type="text" id="txtManagerName" class="form-control" style="width:80%" readonly />
            </div>
        </div>
        <div class="col-sm-4">
            <br />
            <input type="button" class="btn btn-primary" value="Search" onclick="SearchData()" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <div class="dvChart">
            </div>
        </div>
        <div class="col-sm-6">
            <div class="table-responsive">
                <table class="table table-bordered">

                </table>
            </div>
        </div>
    </div>
</div>