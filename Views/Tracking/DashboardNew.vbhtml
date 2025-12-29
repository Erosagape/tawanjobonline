@Code
    ViewBag.Title = "Main Dashboard"
    Dim dt1 As New Data.DataTable
    Dim dt2 As New Data.DataTable
    Dim dt3 As New Data.DataTable
    Dim dt1_1 As New Data.DataTable
    Dim dt1_2 As New Data.DataTable
    Dim dt1_3 As New Data.DataTable
    Dim dt1_4 As New Data.DataTable
    Dim obj = New CUtil(ViewBag.CONNECTION_JOB)
    Dim jobtype As Integer = 0
    Dim shipby As Integer = 0
    Dim dateFrom As String = New Date(Now.Year - 1, 1, 1).ToString("yyyy-MM-dd")
    Dim dateTo As String = New Date(Now.Year - 1, 12, 31).ToString("yyyy-MM-dd")
    If ViewBag.User <> "" Then
        If Not Request.Form("submit") Is Nothing Then
            jobtype = Request.Form("jt")
            shipby = Request.Form("sb")
            dateFrom = Request.Form("df")
            dateTo = Request.Form("dt")
            Dim sqlSource As String = "
with tb as
(
select j.JNo,j.JobStatus,
jt.ConfigValue as JobTypeName,
sb.ConfigValue as ShipByName,
c.NameThai as CustomerName,
cl.CustAdvAmount,cl.ChargeAmount,cl.CostAmount,
cl.AdvBill,cl.ChargeBill,
cl.AdvBill+cl.ChargeBill as BillAmount,
cl.RecvAdv,cl.RecvCharge,
cl.RecvAdv+cl.RecvCharge as RecvAmount,
cl.UnBillAdv,cl.UnBillCharge,
cl.UnbillAdv+cl.UnBillCharge as UnBillAmount,
cl.UnRecvAdv,cl.UnRecvCharge,
cl.UnRecvAdv+cl.UnRecvCharge as UnReceiveAmount
from
Job_Order j
left join Mas_Company c
on j.CustCode=c.CustCode and j.CustBranch=c.Branch
left join Mas_Config jt
on j.jobType=jt.ConfigKey
and jt.ConfigCode='JOB_TYPE'
left join Mas_Config sb
on j.ShipBy=sb.ConfigKey
and sb.ConfigCode='SHIP_BY'
left join (
select d.BranchCode,d.JobNo,
sum(case when s.IsExpense=1 then d.UsedAmount else 0 end) as CostAmount,
sum(case when s.IsExpense=0 and s.IsCredit=0 then d.UsedAmount else 0 end) as ChargeAmount,
sum(case when s.IsExpense=0 and s.IsCredit=1 then d.BNet else 0 end) as CustAdvAmount,
sum(case when s.IsExpense=0 and s.IsCredit=0 and i.DocNo is not null then d.UsedAmount else 0 end) as ChargeBill,
sum(case when s.IsExpense=0 and s.IsCredit=1 and i.DocNo is not null then d.BNet else 0 end) as AdvBill,
sum(case when s.IsExpense=0 and s.IsCredit=0 and i.DocNo is not null and r.ReceiptNo is not null then d.UsedAmount else 0 end) as RecvCharge,
sum(case when s.IsExpense=0 and s.IsCredit=1 and i.DocNo is not null and r.ReceiptNo is not null then d.BNet else 0 end) as RecvAdv,
sum(case when s.IsExpense=0 and s.IsCredit=0 and i.DocNo is not null and r.ReceiptNo is null then d.UsedAmount else 0 end) as UnRecvCharge,
sum(case when s.IsExpense=0 and s.IsCredit=1 and i.DocNo is not null and r.ReceiptNo is null then d.BNet else 0 end) as UnRecvAdv,
sum(case when s.IsExpense=0 and s.IsCredit=0 and i.DocNo is null then d.UsedAmount else 0 end) as UnBillCharge,
sum(case when s.IsExpense=0 and s.IsCredit=1 and i.DocNo is null then d.UsedAmount else 0 end) as UnBillAdv
from Job_ClearDetail d
inner join Job_ClearHeader h
on d.ClrNo=h.ClrNo and d.BranchCode=h.BranchCode
left join Job_SrvSingle s
on d.SIcode=s.SICode
left join
(
select * from Job_InvoiceHeader where isnull(CancelProve,'')=''
) i
on d.LinkBillNo=i.DocNo and d.BranchCode=i.BranchCode
left join
(
select * from Job_ReceiptDetail dt
where not exists(
select 1 from Job_ReceiptHeader where Receiptno=dt.ReceiptNo and isnull(CancelProve,'')<>''
)
) r
on d.LinkBillNo=r.InvoiceNo and d.LinkItem=r.InvoiceItemNo
where h.DocStatus<>99
group by d.BranchCode,d.JobNo
) cl on j.JNo=cl.JobNo and j.BranchCode=cl.BranchCode
{0}
)
"
            Dim sqlWhere As String = String.Format("WHERE j.BranchCode='{0}' ", ViewBag.PROFILE_DEFAULT_BRANCH)
            sqlWhere &= String.Format(" AND j.DocDate>='{0}' AND j.DocDate<='{1}' ", dateFrom, dateTo)
            If jobtype > 0 Then
                sqlWhere &= String.Format(" AND j.JobType={0}", jobtype)
            End If
            If shipby > 0 Then
                sqlWhere &= String.Format(" AND j.ShipBy={0}", shipby)
            End If
            sqlSource = String.Format(sqlSource, sqlWhere)
            Dim sql1 As String = "
select
count(*) as TotalJob,
sum(isnull(tb.CustAdvAmount,0)) as TotalAdvance,
sum(isnull(tb.UnRecvAdv,0)) as TotalAdvUnRecv,
sum( case when isnull(tb.UnRecvAdv,0)>0 then 1 else 0 end) as TotalJobAdvUnRecv,
sum(isnull(tb.UnbillAdv,0)) as TotalAdvUnbill,
sum( case when isnull(tb.UnbillAdv,0)>0 then 1 else 0 end) as TotalJobAdvUnBill,
sum(isnull(tb.ChargeAmount,0)) as TotalCharge,
sum(isnull(tb.UnRecvCharge,0)) as TotalChargeUnRecv,
sum( case when isnull(tb.UnRecvCharge,0)>0 then 1 else 0 end) as TotalJobChargeUnRecv,
sum(isnull(tb.UnBillCharge,0)) as TotalChargeUnBill,
sum( case when isnull(tb.UnBillCharge,0)>0 then 1 else 0 end) as TotalJobChargeUnBill
from tb
"
            Dim sql2 As String = "
select JobTypeName,
count(*) as TotalJob,
sum(case when tb.ChargeAmount is null and JobStatus=99 then 1 else 0 end) as TotalJobCancel,
sum(case when tb.ChargeAmount is null and JobStatus<>99 then 1 else 0 end) as TotalJobNoClear,
sum(case when tb.ChargeAmount is not null and tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0 then 1 else 0 end) as TotalJobCostonly,
sum(case when tb.ChargeAmount is not null and not (tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0) and round(tb.UnBillAmount,0)<>0 then 1 else 0 end) as TotalJobBillAvaiable,
sum(case when tb.ChargeAmount is not null and not (tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0) and round(tb.UnBillAmount,0)=0 and not round(tb.UnReceiveAmount,0)=0 then 1 else 0 end) as TotalBillRecvAvaiable,
sum(case when tb.ChargeAmount is not null and not (tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0) and round(tb.UnBillAmount,0)=0 and round(tb.UnReceiveAmount,0)=0 then 1 else 0 end) as TotalBillRecvComplete
from tb
group by JobTypeName
order by 2 DESC
"
            Dim sql3 As String = "
select CustomerName,
count(*) as TotalJob,
sum(isnull(tb.CustAdvAmount,0)) as TotalAdvance,
sum(isnull(tb.UnRecvAdv,0)) as TotalAdvUnRecv,
sum(isnull(tb.UnbillAdv,0)) as TotalAdvUnbill,
sum(isnull(tb.ChargeAmount,0)) as TotalCharge,
sum(isnull(tb.UnRecvCharge,0)) as TotalChargeUnRecv,
sum(isnull(tb.UnBillCharge,0)) as TotalChargeUnBill
from tb
group by CustomerName
order by 2 DESC
"
            Dim sqlStuff1 As String = "
,STUFF((
select ','+cd.SDescription
from Job_ClearDetail cd inner join Job_ClearHeader ch
on cd.ClrNo=ch.ClrNo and cd.BranchCode=ch.BranchCode
inner join Job_SrvSingle s on cd.SICode=s.SICode
where ch.DocStatus<>99
and s.IsCredit=1 and s.IsExpense=0 and isnull(cd.LinkBillNo,'')=''
and cd.JobNo=tb.JNo
FOR XML PATH ('')
), 1, 1, '') as ListData
"
            Dim sqlStuff2 As String = "
,STUFF((
select ','+cd.SDescription
from Job_ClearDetail cd inner join Job_ClearHeader ch
on cd.ClrNo=ch.ClrNo and cd.BranchCode=ch.BranchCode
inner join Job_SrvSingle s on cd.SICode=s.SICode
inner join Job_InvoiceHeader i on cd.LinkBillNo=i.DocNo
where ch.DocStatus<>99 and isnull(i.CancelProve,'')=''
and cd.LinkItem>0
and not exists(select 1 from
Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
on rd.ReceiptNo=rh.ReceiptNo and rd.BranchCode=rh.BranchCode
where isnull(rh.CancelProve,'')=''
and rd.InvoiceNo=cd.LinkBillNo and rd.InvoiceItemNo=cd.LinkItem
)
and s.IsCredit=1 and s.IsExpense=0
and cd.JobNo=tb.JNo
FOR XML PATH ('')
), 1, 1, '') as ListData
"
            Dim sqlStuff3 As String = "
,STUFF((
select ','+cd.SDescription
from Job_ClearDetail cd inner join Job_ClearHeader ch
on cd.ClrNo=ch.ClrNo and cd.BranchCode=ch.BranchCode
inner join Job_SrvSingle s on cd.SICode=s.SICode
where ch.DocStatus<>99
and s.IsCredit=0 and s.IsExpense=0 and isnull(cd.LinkBillNo,'')=''
and cd.JobNo=tb.JNo
FOR XML PATH ('')
), 1, 1, '') as ListData
"
            Dim sqlStuff4 As String = "
,STUFF((
select ','+cd.SDescription
from Job_ClearDetail cd inner join Job_ClearHeader ch
on cd.ClrNo=ch.ClrNo and cd.BranchCode=ch.BranchCode
inner join Job_SrvSingle s on cd.SICode=s.SICode
inner join Job_InvoiceHeader i on cd.LinkBillNo=i.DocNo
where ch.DocStatus<>99 and isnull(i.CancelProve,'')=''
and cd.LinkItem>0
and not exists(select 1 from
Job_ReceiptDetail rd inner join Job_ReceiptHeader rh
on rd.ReceiptNo=rh.ReceiptNo and rd.BranchCode=rh.BranchCode
where isnull(rh.CancelProve,'')=''
and rd.InvoiceNo=cd.LinkBillNo and rd.InvoiceItemNo=cd.LinkItem
)
and s.IsCredit=0 and s.IsExpense=0
and cd.JobNo=tb.JNo
FOR XML PATH ('')
), 1, 1, '') as ListData
"
            dt1 = obj.GetTableFromSQL(sqlSource & vbCrLf & sql1)
            dt1_1 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnbillAdv<>0", sqlStuff1))
            dt1_2 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnRecvAdv<>0", sqlStuff2))
            dt1_3 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnbillCharge<>0", sqlStuff3))
            dt1_4 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnRecvCharge<>0", sqlStuff4))
            dt2 = obj.GetTableFromSQL(sqlSource & vbCrLf & sql2)
            dt3 = obj.GetTableFromSQL(sqlSource & vbCrLf & sql3)
        End If

    End If
End Code
<div class="w3-card">
    <div class="w3-container w3-red">
        <h1>Recap your company</h1>
    </div>
    <div class="w3-container">
        <form id="dvCliteria" action="" method="post">
            <div class="row">
                <div class="col-sm-3">
                    <label id="lblJobType">Job Type </label>
                    : <br />
                    <select id="cboJobType" name="jt" class="form-control dropdown" onchange="Submit()">
                        @If ViewBag.User <> "" Then
                            If jobtype = 0 Then
                                @<option value="0" selected> ALL</option>
                            Else
                                @<option value="0"> ALL</option>
                            End If
                            Dim jt = obj.GetTableFromSQL("SELECT * FROM Mas_Config WHERE ConfigCode='JOB_TYPE'")
                            If jt.Rows.Count > 0 Then
                                For Each dr As Data.DataRow In jt.Rows
                                    If Convert.ToInt32(dr("ConfigKey")).Equals(jobtype) And jobtype > 0 Then
                                        @<option value="@Convert.ToInt32(dr("ConfigKey"))" selected>
                                            @dr("ConfigValue").ToString()
                                        </option>
                                    Else
                                        @<option value="@Convert.ToInt32(dr("ConfigKey"))">
                                            @dr("ConfigValue").ToString()
                                        </option>
                                    End If
                                Next
                            End If
                        End If
                    </select>
                </div>
                <div Class="col-sm-3">
                    <Label id="lblShipBy"> Transport By</Label>
                    : <br />
                    <select id="cboShipBy" name="sb" class="form-control dropdown" onchange="Submit();">
                        @If ViewBag.User <> "" Then
                            If shipby = 0 Then
                                @<option value="0" selected> ALL</option>
                            Else
                                @<option value="0"> ALL</option>
                            End If
                            Dim sb = obj.GetTableFromSQL(String.Format("SELECT * FROM Mas_Config a WHERE ConfigCode='SHIP_BY'
and exists(select 1 from Mas_Config WHERE ConfigCode='SHIP_BY_FILTER'
and CHARINDEX(a.ConfigKey,ConfigValue,1)>0 and ConfigKey='{0}')", jobtype.ToString("00")))
                            If sb.Rows.Count > 0 Then
                                For Each dr As Data.DataRow In sb.Rows
                                    If Not System.DBNull.Value.Equals(dr("ConfigKey")) Then
                                        If Convert.ToInt32(dr("ConfigKey")).Equals(shipby) And shipby > 0 Then
                                            @<option value="@Convert.ToInt32(dr("ConfigKey"))" selected>
                                                @dr("ConfigValue").ToString()
                                            </option>
                                        Else
                                            @<option value="@Convert.ToInt32(dr("ConfigKey"))">
                                                @dr("ConfigValue").ToString()
                                            </option>
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    </select>
                </div>
                <div class="col-sm-2">
                    <label id="lblDateFrom">Duty Date From</label>
                    :<br />
                    <input type="date" name="df" id="txtDateFrom" class="form-control" value="@dateFrom" />
                </div>
                <div class="col-sm-2">
                    <label id="lblDateTo">Duty Date To</label>
                    :<br />
                    <input type="date" name="dt" id="txtDateTo" class="form-control" value="@dateTo" />
                </div>
                <div class="col-sm-2">
                    <br />
                    <input type="submit" class="btn btn-success" name="submit" id="btnUpdate" value="Update" />
                </div>
            </div>
        </form>
    </div>
    @If ViewBag.User <> "" Then
        If dt2.Rows.Count > 0 Then
            For Each dr As Data.DataRow In dt2.Rows
                @<div class="w3-container">
                    <div class="w3-teal">
                        <b>@dr("JobTypeName")</b> TOTAL : @dr("TotalJob") JOBS
                    </div>
                    <table class="dataTable">
                        <thead>
                            <tr>
                                <th>Cancel</th>
                                <th>No Clear</th>
                                <th>Cost Only</th>
                                <th>Need Bill</th>
                                <th>Need Receive</th>
                                <th>Complete</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>@dr("TotalJobCancel")</td>
                                <td>@dr("TotalJobNoClear")</td>
                                <td>@dr("TotalJobCostOnly")</td>
                                <td>@dr("TotalJobBillAvaiable")</td>
                                <td>@dr("TotalBillRecvAvaiable")</td>
                                <td>@dr("TotalBillRecvComplete")</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            Next
        End If
    End If
    <div class="w3-container">
        @If ViewBag.User <> "" Then
            If dt3.Rows.Count > 0 Then
                @<table class="dataTable">
                    <thead>
                        <tr>
                            <th>Customer</th>
                            <th>Total Jobs</th>
                            <th>Advance Unbill</th>
                            <th>Charge Unbill</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For each dr As Data.DataRow in dt3.Rows
                            @<tr>
                                <td>@dr("CustomerName")</td>
                                <td>@dr("TotalJob")</td>
                                <td>@dr("TotalAdvUnbill")</td>
                                <td>@dr("TotalChargeUnbill")</td>
                            </tr>
                        Next
                    </tbody>
                </table>
            End If
        End If
    </div>
    <div Class="w3-container w3-blue">
        @Code
            If ViewBag.User <> "" Then
                If dt1.Rows.Count > 0 Then
                    Dim dr = dt1.Rows(0)
                    @<div class="container">
                        <table>
                            <tr>
                                <td><b>ADV UNBILL / ค่าใช้จ่ายของลูกค้าที่ยังไม่ได้เก็บเงิน = </b>@Convert.ToDouble(dr("TotalAdvUnBill")).ToString("#,##0.00") บาท (@dr("TotalJobAdvUnbill").ToString() <a href="#dv_1_1">Jobs</a>)</td>
                            </tr>
                            <tr>
                                <td><b>ADV NORECV / ค่าใช้จ่ายของลูกค้าที่ยังไมได้รับชำระ = </b>@Convert.ToDouble(dr("TotalAdvUnRecv")).ToString("#,##0.00") (@dr("TotalJobAdvUnRecv").ToString() <a href="#dv_1_2">Jobs</a>)</td>
                            </tr>
                            <tr>
                                <td><b>CHG UNBILL / ค่าบริการที่ยังไม่ได้เก็บเงิน = </b>@Convert.ToDouble(dr("TotalChargeUnBill")).ToString("#,##0.00") (@dr("TotalJobChargeUnbill").ToString() <a href="#dv_1_3">Jobs</a>)</td>
                            </tr>
                            <tr>
                                <td><b>CHG NORECV / ค่าบริการที่ยังไม่ได้รับชำระ = </b>@Convert.ToDouble(dr("TotalChargeUnRecv")).ToString("#,##0.00") (@dr("TotalChargeUnRecv").ToString() <a href="#dv_1_4">Jobs</a>)</td>
                            </tr>
                        </table>
                    </div>
                End If
            End If
        End Code
    </div>
    @Code
        If dt1_1.Rows.Count > 0 Then
            @<div class="w3-container" id="dv_1_1">
                <b>ADV.UNBILL / ค่าใช้จ่ายของลูกค้าที่ยังไม่ได้เก็บเงิน </b>
                <table>
                    @For each dr As Data.DataRow In dt1_1.Rows
                        @<tr>
                            <td><a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a></td>
                            <td>@dr("CustomerName")</td>
                            <td>@dr("UnbillAdv")</td>
                            <td>@dr("ListData")</td>
                        </tr>
                    Next
                </table>
            </div>
        End If
        If dt1_2.Rows.Count > 0 Then
            @<div class="w3-container" id="dv_1_2">
                <b>ADV.NORECV / ค่าใช้จ่ายของลูกค้าที่ยังไมได้รับชำระ</b>
                <table>
                    @For each dr As Data.DataRow In dt1_2.Rows
                        @<tr>
                            <td><a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a></td>
                            <td>@dr("CustomerName")</td>
                            <td>@dr("UnRecvAdv")</td>
                            <td>@dr("ListData")</td>
                        </tr>
                    Next
                </table>
            </div>
        End If
        If dt1_3.Rows.Count > 0 Then
            @<div class="w3-container" id="dv_1_3">
                <b>CHG.UNBILL / ค่าบริการที่ยังไม่ได้เก็บเงิน </b>
                <table>
                    @For each dr As Data.DataRow In dt1_3.Rows
                        @<tr>
                            <td><a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a></td>
                            <td>@dr("CustomerName")</td>
                            <td>@dr("UnbillCharge")</td>
                            <td>@dr("ListData")</td>
                        </tr>
                    Next
                </table>
            </div>
        End If
        If dt1_4.Rows.Count > 0 Then
            @<div class="w3-container" id="dv_1_4">
                <b>CHG.NORECV / ค่าบริการที่ยังไม่ได้รับชำระ</b>
                <table>
                    @For each dr As Data.DataRow In dt1_4.Rows
                        @<tr>
                            <td><a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a></td>
                            <td>@dr("CustomerName")</td>
                            <td>@dr("UnRecvCharge")</td>
                            <td>@dr("ListData")</td>
                        </tr>
                    Next
                </table>
            </div>
        End If
    End Code
</div>
<script type="text/javascript" src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var branch = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    var jobtype = '@jobtype';
                            var shipby = '@shipby';
    function Submit() {
        $('#btnUpdate').click();
    }
</script>