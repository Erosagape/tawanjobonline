@Code
    ViewBag.Title = "Recap Your Company"
    Dim dt1 As New Data.DataTable
    Dim dt2 As New Data.DataTable
    Dim dt3 As New Data.DataTable
    Dim dt4 As New Data.DataTable
    Dim dt5 As New Data.DataTable
    Dim dt6 As New Data.DataTable
    Dim dt6_1 As New Data.DataTable
    Dim dt4_1 As New Data.DataTable
    Dim dt1_1 As New Data.DataTable
    Dim dt1_2 As New Data.DataTable
    Dim dt2_1 As New Data.DataTable
    Dim dt2_2 As New Data.DataTable
    Dim dt1_3 As New Data.DataTable
    Dim dt1_4 As New Data.DataTable
    Dim obj = New CUtil(ViewBag.CONNECTION_JOB)
    Dim showDetail As String = ""
    Dim cliteria As String = ""
    Dim jobtype As Integer = 1
    Dim shipby As Integer = 1
    Dim dateFrom As String = New Date(Now.Year - 1, 1, 1).ToString("yyyy-MM-dd")
    Dim dateTo As String = New Date(Now.Year - 1, 12, 31).ToString("yyyy-MM-dd")
    Dim sqlSource As String = "
with tb as
(
select j.JNo,j.JobStatus,
jt.ConfigValue as JobTypeName,
sb.ConfigValue as ShipByName,
c.NameThai as CustomerName,
cl.JobNo,
isnull(cl.CustAdvAmount,0) as CustAdvAmount,
isnull(cl.ChargeAmount,0) as ChargeAmount,
isnull(cl.CostAmount,0) as CostAmount,
isnull(cl.AdvBill,0) as AdvBill,
isnull(cl.ChargeBill,0) as ChargeBill,
isnull(cl.AdvBill,0)+isnull(cl.ChargeBill,0) as BillAmount,
isnull(cl.RecvAdv,0) as RecvAdv,
isnull(cl.RecvCharge,0) as RecvCharge,
isnull(cl.RecvAdv,0)+isnull(cl.RecvCharge,0) as RecvAmount,
isnull(cl.UnBillAdv,0) as UnbillAdv,
isnull(cl.UnBillCharge,0) as UnbillCharge,
isnull(cl.UnbillAdv,0)+isnull(cl.UnBillCharge,0) as UnBillAmount,
isnull(cl.UnRecvAdv,0) as UnRecvAdv,
isnull(cl.UnRecvCharge,0) as UnRecvCharge,
isnull(cl.UnRecvAdv,0)+isnull(cl.UnRecvCharge,0) as UnReceiveAmount
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
sum(case when tb.JobNo is null and JobStatus=99 then 1 else 0 end) as TotalJobCancel,
sum(case when tb.JobNo is null and JobStatus<>99 then 1 else 0 end) as TotalJobNoClear,
sum(case when tb.JobNo is not null and tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0 then 1 else 0 end) as TotalJobCostonly,
sum(case when tb.JobNo is not null and not (tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0) and round(tb.UnBillAmount,0)<>0 then 1 else 0 end) as TotalJobBillAvaiable,
sum(case when tb.JobNo is not null and not (tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0) and round(tb.UnBillAmount,0)=0 and not round(tb.UnReceiveAmount,0)=0 then 1 else 0 end) as TotalBillRecvAvaiable,
sum(case when tb.JobNo is not null and not (tb.CostAmount>0 and tb.ChargeAmount=0 and tb.CustAdvAmount=0) and round(tb.UnBillAmount,0)=0 and round(tb.UnReceiveAmount,0)=0 then 1 else 0 end) as TotalBillRecvComplete
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
select distinct ','+cd.SDescription
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
select distinct ','+cd.SDescription
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
select distinct ','+cd.SDescription
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
select distinct ','+cd.SDescription
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
    Dim sql4 As String = "
select CustomerName,count(*) TotalDocs,round(sum(TotalAdvance),2) as TotalPayAdvance,
sum(case when TotalClear is null then 1 else 0 end) as TotalDocNoClear,
round(sum(case when TotalClear is null then TotalAdvance else 0 end),2) as TotalNoClear
from (
select h.BranchCode,h.AdvNo,c.NameThai as CustomerName,h.JobType,h.ShipBy,h.PaymentDate as DocDate,h.TotalAdvance,d.TotalClear
from Job_AdvHeader h
left join Mas_Company c on h.CustCode=c.CustCode and h.CustBranch=c.Branch
left join
(
select cd.BranchCode,cd.AdvNo,sum(cd.BNet) as TotalClear
from Job_ClearDetail cd inner join Job_ClearHeader ch on cd.ClrNo=ch.ClrNo and ch.DocStatus<>99 and cd.AdvNO<>''
group by cd.BranchCode,cd.AdvNo
) d
on h.AdvNo=d.AdvNO and h.BranchCode=d.BranchCode
where isnull(h.cancelprove,'')='' and isnull(h.PaymentRef,'')<>''
) j
{0}
group by CustomerName
ORDER By 2 desc
"
    Dim sql5 As String = "
select ReqBy,count(*) TotalDocs,round(sum(TotalAdvance),2) as TotalPayAdvance,
sum(case when TotalClear is null then 1 else 0 end) as TotalDocNoClear,
round(sum(case when TotalClear is null then TotalAdvance else 0 end),2) as TotalNoClear
from (
select h.BranchCode,h.AdvNo,c.NameThai as CustomerName,h.JobType,h.ShipBy,h.PaymentDate as DocDate,h.TotalAdvance,d.TotalClear,
concat(u.TName,' (',h.EmpCode,')') as ReqBy
from Job_AdvHeader h
left join Mas_User u on h.EmpCode=u.UserId
left join Mas_Company c on h.CustCode=c.CustCode and h.CustBranch=c.Branch
left join
(
select cd.BranchCode,cd.AdvNo,sum(cd.BNet) as TotalClear
from Job_ClearDetail cd inner join Job_ClearHeader ch on cd.ClrNo=ch.ClrNo and ch.DocStatus<>99 and cd.AdvNO<>''
group by cd.BranchCode,cd.AdvNo
) d
on h.AdvNo=d.AdvNO and h.BranchCode=d.BranchCode
where isnull(h.cancelprove,'')='' and isnull(h.PaymentRef,'')<>''
) j
{0}
group by ReqBy
ORDER By 2 desc
"
    Dim sql4_1 As String = "
select *
from (
select h.BranchCode,h.AdvNo,h.EmpCode,c.NameThai as CustomerName,h.JobType,h.ShipBy,h.PaymentDate as DocDate,h.TotalAdvance,d.TotalClear
from Job_AdvHeader h
left join Mas_Company c on h.CustCode=c.CustCode and h.CustBranch=c.Branch
left join
(
select cd.BranchCode,cd.AdvNo,sum(cd.BNet) as TotalClear
from Job_ClearDetail cd inner join Job_ClearHeader ch on cd.ClrNo=ch.ClrNo and ch.DocStatus<>99 and cd.AdvNO<>''
group by cd.BranchCode,cd.AdvNo
) d
on h.AdvNo=d.AdvNO and h.BranchCode=d.BranchCode
where isnull(h.cancelprove,'')='' and isnull(h.PaymentRef,'')<>''
and d.TotalClear is null
) j {0}
order by TotalAdvance DESC
"

    If ViewBag.User <> "" Then
        If Not Request.Form("submit") Is Nothing Then
            jobtype = Request.Form("jt")
            shipby = Request.Form("sb")
            dateFrom = Request.Form("df")
            dateTo = Request.Form("dt")
            showDetail = Request.Form("Detail")
            cliteria = Request.Form("Cliteria")

            Dim sqlWhere As String = String.Format("WHERE j.BranchCode='{0}' ", ViewBag.PROFILE_DEFAULT_BRANCH)
            sqlWhere &= String.Format(" AND j.DocDate>='{0}' AND j.DocDate<='{1}' ", dateFrom, dateTo)
            If jobtype > 0 Then
                sqlWhere &= String.Format(" AND j.JobType={0}", jobtype)
            End If
            If shipby > 0 Then
                sqlWhere &= String.Format(" AND j.ShipBy={0}", shipby)
            End If
            sqlSource = String.Format(sqlSource, sqlWhere)

            dt1 = obj.GetTableFromSQL(sqlSource & vbCrLf & sql1)
            If showDetail = "1" Then
                dt1_1 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnbillAdv>0", sqlStuff1))
            End If
            If showDetail = "2" Then
                dt1_2 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnRecvAdv>0", sqlStuff2))
            End If
            If showDetail = "3" Then
                dt1_3 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnbillCharge>0", sqlStuff3))
            End If
            If showDetail = "4" Then
                dt1_4 = obj.GetTableFromSQL(sqlSource & vbCrLf & String.Format("select tb.*{0} from tb where UnRecvCharge>0", sqlStuff4))
            End If
            dt2 = obj.GetTableFromSQL(sqlSource & vbCrLf & sql2)
            If showDetail = "5" Then
                dt2_1 = obj.GetTableFromSQL(sqlSource & vbCrLf & "select tb.* from tb where tb.JobNo is null")
            End If
            If showDetail = "6" Then
                dt2_2 = obj.GetTableFromSQL(sqlSource & vbCrLf & "select tb.* from tb where tb.JobNo is not null and tb.CostAmount>0 and tb.CustAdvAmount=0 and tb.ChargeAmount=0")
            End If
            dt3 = obj.GetTableFromSQL(sqlSource & vbCrLf & sql3)
            dt4 = obj.GetTableFromSQL(String.Format(sql4, sqlWhere))
            If showDetail = "7" Then
                dt4_1 = obj.GetTableFromSQL(String.Format(sql4_1, sqlWhere))
            End If
            dt5 = obj.GetTableFromSQL(String.Format(sql5, sqlWhere))
            dt6 = obj.GetTableFromSQL(String.Format("EXEC dbo.GetContainerVolume {0},{1},'{2}','{3}'", jobtype, shipby, dateFrom, dateTo))
            Dim sql6 = "
select TotalContainer,JNo,CustCode,CustBranch from Job_Order j {0} AND j.JobStatus<>99 
order by TotalContainer
"
            If showDetail = "8" Then
                If cliteria <> "" Then
                    sqlWhere &= String.Format(" AND j.TotalContainer like '%{0}%'", cliteria)
                End If
                dt6_1 = obj.GetTableFromSQL(String.Format(sql6, sqlWhere))
            Else
                If dt6.Rows.Count > 0 Then
                    cliteria = dt6.Rows(0)("Unit").ToString()
                End If
                If cliteria <> "" Then
                    sqlWhere &= String.Format(" AND j.TotalContainer like '%{0}%'", cliteria)
                End If
                dt6_1 = obj.GetTableFromSQL(String.Format(sql6, sqlWhere))
            End If
        End If
    End If
 End Code
<div class="w3-card">
    <div class="w3-container w3-green">
        <h1>Recap your company @Convert.ToDateTime(dateTo).Year</h1>
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
            <input type="hidden" name="Detail" id="txtDetail" value="@showDetail" />
            <input type="hidden" name="Cliteria" id="txtCliteria" value="@cliteria" />
        </form>
        <a href="~/JobOrder/Index"><b>Go to List Job</b></a>&nbsp;&nbsp;
        <a href="~/Admin/Index"><b>View Chart</b></a>
        @If ViewBag.User <> "" Then
            If dt6.Rows.Count > 0 Then
                @<div class="row">
                    <div class="col-sm-6">
                        <table class="dataTable">
                            <thead>
                                <tr>
                                    <th>Unit</th>
                                    <th>Volume</th>
                                </tr>
                            </thead>
                            <tbody>
                                @For each dr As Data.DataRow in dt6.Rows
                                    @<tr>
                                    <td>
                                        <a href="#tbJob" onclick="SetDetail(8,'@dr("Unit")')">@dr("Unit")</a>
                                    </td>
                                    <td>@dr("Volume")</td>
                                    </tr>
                                Next
                            </tbody>
                        </table>
                    </div>
                    <div class="col-sm-6">
                        <table class="dataTable">
                            <thead>
                                <tr>
                                    <th>Unit</th>
                                    <th>Job</th>
                                    <th>Customer</th>
                                </tr>
                            </thead>
                            <tbody>
                                @For Each dr As Data.DataRow In dt6_1.Rows
                                    @<tr>
                                         <td>@dr("TotalContainer")</td>
                                        <td>
                                            <a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a>
                                        </td>
                                <td>
                                    @dr("CustCode") / @dr("CustBranch")
                                </td>
                                    </tr>
                                Next
                            </tbody>
                        </table>
                    </div>
                </div>
            End If
        End If
    </div>
    @If ViewBag.User <> "" And showDetail = "" Then
        If dt2.Rows.Count > 0 Then
            For Each dr As Data.DataRow In dt2.Rows
                @<div class="w3-container">
                    <div class="w3-teal">
                        <h3>@dr("JobTypeName")</h3> TOTAL : @dr("TotalJob") JOBS
                    </div>
                    <table class="dataTable">
                        <thead>
                            <tr>
                                <th>Cancel</th>
                                <th>No Clear<br>ยังไม่มีใบเคลียร์</th>
                                <th>Cost Only<br>มีแต่ต้นทุน</th>
                                <th>Need Bill<br>ค้างวางบิล</th>
                                <th>Need Receive<br>ค้างออกใบเสร็จ</th>
                                <th>Complete</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>@dr("TotalJobCancel")</td>
                                <td><a href="#tb2_1" onclick="SetDetail(5)">@dr("TotalJobNoClear")</a></td>
                                <td><a href="#tb2_2" onclick="SetDetail(6)">@dr("TotalJobCostOnly")</a></td>
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

    @If ViewBag.User <> "" And showDetail = "" Then
        If dt4.Rows.Count > 0 And dt5.Rows.Count > 0 Then
            @<div class="w3-red">
                <h3>TOTAL ADVANCE PAYMENT<br />สรุปยอดการเบิกเงิน</h3>
            </div>
            @<div class="row">
                @if dt5.Rows.Count > 0 Then
                    @<div class="col-sm-6">
                        <div class="w3-container">
                            <table class="dataTable">
                                <thead>
                                    <tr>
                                        <th>Request By</th>
                                        <th>Total Docs/Unclear</th>
                                        <th>Advance<br>รวมยอดที่เบิก</th>
                                        <th>Total Unclear<br>รวมยอดค้างเคลียร์</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For Each dr As Data.DataRow In dt5.Rows
                                        @<tr>
                                            <td>@dr("ReqBy")</td>
                                            <td>@dr("TotalDocs")/@dr("TotalDocNoClear")</td>
                                            <td>@dr("TotalPayAdvance")</td>
                                            <td>@dr("TotalNoClear")</td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                End If
                @If dt4.Rows.Count > 0 Then
                    @<div class="col-sm-6">
                        <div class="w3-container">
                            <table class="dataTable">
                                <thead>
                                    <tr>
                                        <th>Customer</th>
                                        <th>Total Docs/Unclear</th>
                                        <th>Advance<br>รวมยอดที่เบิก</th>
                                        <th>Total Unclear<br>รวมยอดค้างเคลียร์</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @For Each dr As Data.DataRow In dt4.Rows
                                        @<tr>
                                            <td>@dr("CustomerName")</td>
                                            <td>@dr("TotalDocs")/@dr("TotalDocNoClear")</td>
                                            <td>@dr("TotalPayAdvance")</td>
                                            <td>@dr("TotalNoClear")</td>
                                        </tr>
                                    Next
                                </tbody>
                            </table>
                        </div>
                    </div>
                End If
            </div>
            @<a href="#tb4_1" onclick="SetDetail(7)"><b>View Advance Unclear</b></a>
        End If
    End If
    @If dt4_1.Rows.Count > 0 Then
        If Not System.DBNull.Value.Equals(dt4_1.Rows(0)("DocDate")) Then
            @<div Class="w3-container" id="tb4_1">
                <b>Total Advance Unclear</b>
                <Table Class="dataTable">
                    @For Each dr As Data.DataRow In dt4_1.Rows
                        @<tr>
                            <td><a href="~/Adv/Index?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&AdvNo=@dr("AdvNo")">@dr("AdvNo")</a></td>
                            <td>@Convert.ToDateTime(dr("DocDate")).ToString("dd/MM/yyyy")</td>
                            <td>@dr("CustomerName")</td>
                            <td>@dr("EmpCode")</td>
                            <td>@dr("TotalAdvance")</td>
                        </tr>

                    Next
                </Table>
            </div>
        End If
    End If
    @If dt2_1.Rows.Count > 0 Then
        @<div class="w3-container" id="tb2_1">
            <div class="w3-blue">
                <h4>JOB NO CLEARING / งานที่ไม่มีใบเคลียร์</h4>
            </div>
            <table class="dataTable">
                @For each dr As Data.DataRow In dt2_1.Rows
                    @<tr>
                        <td><a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a></td>
                        <td>@dr("CustomerName")</td>
                    </tr>
                Next
            </table>
        </div>
    End If
    @If dt2_2.Rows.Count > 0 Then
        @<div class="w3-container" id="tb2_2">
            <div class="w3-blue">
                <h4>JOB COST ONLY / งานที่มีแต่ต้นทุน</h4>
            </div>
            <table class="dataTable">
                @For each dr As Data.DataRow In dt2_2.Rows
                    @<tr>
                        <td><a href="~/JobOrder/ShowJob?BranchCode=@ViewBag.PROFILE_DEFAULT_BRANCH&JNo=@dr("JNo")">@dr("JNo")</a></td>
                        <td>@dr("CustomerName")</td>
                    </tr>
                Next
            </table>
        </div>
    End If
    <div Class="w3-container">
        @If ViewBag.User <> "" Then
            If dt3.Rows.Count > 0 And showDetail = "" Then
                @<table class="dataTable">
                    <thead>
                        <tr>
                            <th>Customer</th>
                            <th>Total Jobs</th>
                            <th>Advance Unbill<br>ค่าใช้จ่ายลูกค้าค้าง</th>
                            <th>Charge Unbill<br>ค่าบริการค้าง</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For each dr As Data.DataRow In dt3.Rows
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
    <div Class="w3-container">
        @Code
            If ViewBag.User <> "" Then
                If dt1.Rows.Count > 0 Then
                    Dim dr = dt1.Rows(0)
                    @<table class="dataTable">
                        @If Not System.DBNull.Value.Equals(dr("TotalAdvUnbill")) Then
                            @<tr>
                                <td><b>ADV UNBILL / ค่าใช้จ่ายของลูกค้าที่ยังไม่ได้เก็บเงิน = </b>@Convert.ToDouble(dr("TotalAdvUnBill")).ToString("#,##0.00") บาท (<a href="#dv_1_1" onclick="SetDetail('1')">@dr("TotalJobAdvUnbill").ToString() Jobs</a>)</td>
                            </tr>
                        End If
                        @If Not System.DBNull.Value.Equals(dr("TotalAdvUnRecv")) Then
                            @<tr>
                                <td><b>ADV NORECV / ค่าใช้จ่ายของลูกค้าที่ยังไมได้รับชำระ = </b>@Convert.ToDouble(dr("TotalAdvUnRecv")).ToString("#,##0.00") (<a href="#dv_1_2" onclick="SetDetail('2')">@dr("TotalJobAdvUnRecv").ToString() Jobs</a>)</td>
                            </tr>
                        End If
                        @If Not System.DBNull.Value.Equals(dr("TotalChargeUnBill")) Then
                            @<tr>
                                <td><b>CHG UNBILL / ค่าบริการที่ยังไม่ได้เก็บเงิน = </b>@Convert.ToDouble(dr("TotalChargeUnBill")).ToString("#,##0.00") (<a href="#dv_1_3" onclick="SetDetail('3')">@dr("TotalJobChargeUnbill").ToString() Jobs</a>)</td>
                            </tr>
                        End If
                        @If Not System.DBNull.Value.Equals(dr("TotalChargeUnRecv")) Then
                            @<tr>
                                <td><b>CHG NORECV / ค่าบริการที่ยังไม่ได้รับชำระ = </b>@Convert.ToDouble(dr("TotalChargeUnRecv")).ToString("#,##0.00") (<a href="#dv_1_4" onclick="SetDetail('4')">@dr("TotalJobChargeUnRecv").ToString() Jobs</a>)</td>
                            </tr>
                        End If
                    </table>
                End If
            End If
        End Code
    </div>
    @Code
        If dt1_1.Rows.Count > 0 Then
            @<div class="w3-container" id="dv_1_1">
                <b>ADV.UNBILL / ค่าใช้จ่ายของลูกค้าที่ยังไม่ได้เก็บเงิน </b>
                <table class="dataTable">
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
                <table class="dataTable">
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
                <table class="dataTable">
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
                <table class="dataTable">
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
    var detail = '@showDetail';
    if (detail=='1') {
       $('#dv_1_1').focus();
    }
    if (detail=='2') {
       $('#dv_1_2').focus();
    }
    if (detail=='3') {
       $('#dv_1_3').focus();
    }
    if (detail=='4') {
       $('#dv_1_4').focus();
    }
    if (detail=='5') {
       $('#tb2_1').focus();
    }
    if (detail=='6') {
       $('#tb2_1').focus();
    }
    if (detail=='7') {
       $('#tb4_1').focus();
    }
    $('#txtDetail').val('');
    function Submit() {
        $('#btnUpdate').click();
    }
    function SetDetail(id,param='') {
        $('#txtDetail').val(id);
        $('#txtCliteria').val(param);
        Submit();
    }
</script>