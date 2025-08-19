@Code
    ViewBag.Title = "Analysis Dashboard"
    Dim currentYear As String = ""
    If Not Request.QueryString("Year") Is Nothing Then
        currentYear = Request.QueryString("Year")
    End If
    If currentYear = "" Then
        currentYear = DateTime.Now.Year().ToString()
    End If

    Dim dtAdvPay As New Data.DataTable
    Dim sumAdvPay As Double = 0

    Dim dtAdvUnclear As New Data.DataTable
    Dim sumAdvUnclear As Double = 0

    Dim dtAdvUsed As New Data.DataTable
    Dim sumAdvUsed As Double = 0

    Dim dtEstProfit As New Data.DataTable
    Dim sumClrAdv As Double = 0
    Dim sumClrCost As Double = 0
    Dim sumClrDep As Double = 0
    Dim sumClrServ As Double = 0
    Dim sumClrProfit As Double = 0
    Dim sumServUnBill As Double = 0

    Dim dtCountJob As New Data.DataTable
    Dim countUnbill As Integer = 0
    Dim countBill As Integer = 0
    Dim countComplete As Integer = 0

    Dim user = ViewBag.User

    Dim sql As String = ""
    Dim cnn = New CUtil(ViewBag.CONNECTION_JOB)
    If user <> "" Then
        sql = "
SELECT SUM(round(a.TotalAdvance,3)) as TotalPayment,b.NameEng as CustName
from Job_AdvHeader a
inner join Mas_Company b
on a.CustCode=b.CustCode
where a.DocStatus>3 and ISNULL(a.CancelProve,'')=''
and Year(a.PaymentDate)={0}
group by b.NameEng
order by 1 desc
"
        dtAdvPay = cnn.GetTableFromSQL(String.Format(sql, currentYear))

        sql = "
select sum(b.AdvNet) as TotalUnClear,a.EmpCode
from Job_AdvHeader a
inner join Job_AdvDetail b
on a.AdvNo=b.AdvNo and a.BranchCode=b.BranchCode
where a.DocStatus>3 and ISNULL(a.CancelProve,'')=''
and Year(a.PaymentDate)={0}
and not exists(
select 1 from Job_ClearDetail cd inner join Job_ClearHeader ch on cd.ClrNo=ch.ClrNo
and cd.BranchCode=ch.BranchCode and cd.AdvNO=b.AdvNo and cd.AdvItemNo=b.ItemNo
and ch.DocStatus<>99
) group by a.EmpCode
order by 1 DESC
"
        dtAdvUnclear = cnn.GetTableFromSQL(String.Format(sql, currentYear))

        sql = "
select *,Refund-OverUse as Balance
from (
select a.EmpCode,
round(sum(case when c.TotalClear<b.AdvNet then b.AdvNet-c.TotalClear else 0 end),3) as Refund,
round(sum(case when c.TotalClear>b.AdvNet then c.TotalClear-b.AdvNet else 0 end),3) as OverUse,
round(sum(c.TotalClear),3) as ActualUsed
from Job_AdvHeader a
inner join Job_AdvDetail b
on a.AdvNo=b.AdvNo and a.BranchCode=b.BranchCode
inner join (
    select d.BranchCode,d.AdvNo,d.AdvItemNo,
    sum(d.BNet) as TotalClear
    from Job_ClearHeader h inner join Job_ClearDetail d
    on h.ClrNo=d.ClrNo and h.BranchCode=d.BranchCode
    where h.DocStatus<>99 and d.AdvItemNo>0
    group by d.BranchCode,d.AdvNo,d.AdvItemNo
) c on b.BranchCode=c.BranchCode and b.AdvNo=c.AdvNo and b.ItemNo=c.AdvItemNo
where a.DocStatus>3 and ISNULL(a.CancelProve,'')=''
and Year(a.PaymentDate)={0}
group by a.EmpCode
) t
order by Refund DESC
"
        dtAdvUsed = cnn.GetTableFromSQL(String.Format(sql, currentYear))

        sql = "
select *,ServChg-CostExp as EstProfit,
round(((ServChg-CostExp)/ServChg)*100,2) as ProfitRate
from (
	select jt.JobTypeName,
	sum(case when s.IsCredit=1 and d.LinkBillNo='' then d.BNet else 0 end) as CostAdv,
	sum(case when s.IsCredit=0 and s.IsExpense=1 and d.SDescription not like '%มัดจำ%' then d.UsedAmount else 0 end) as CostExp,
	sum(case when s.IsCredit=0 and s.IsExpense=1 and d.SDescription like '%มัดจำ%' and d.LinkBillNo='' then d.UsedAmount else 0 end) as CostDep,
	sum(case when s.IsCredit=0 and s.IsExpense=0 then d.UsedAmount else 0 end) as ServChg,
sum(case when s.IsCredit=0 and s.IsExpense=0 AND d.LinkBillNo='' then d.UsedAmount else 0 end) as ServUnBill,
	sum(case when s.IsCredit=0 and s.IsExpense=0 and d.Tax50TaviRate=1 then d.UsedAmount else 0 end) as ServChgRate1,
	sum(case when s.IsCredit=0 and s.IsExpense=0 and d.Tax50TaviRate>1 then d.UsedAmount else 0 end) as ServChgRate3,
	sum(case when s.IsCredit=0 and s.IsExpense=0 and d.Tax50TaviRate=0 and d.VATRate>0 then d.UsedAmount else 0 end) as ServChgNonTax,
	sum(case when s.IsCredit=0 and s.IsExpense=0 and d.Tax50TaviRate=0 and d.VATRate=0 then d.UsedAmount else 0 end) as ServChgNonVat
	from Job_ClearHeader h inner join Job_ClearDetail d
	on h.ClrNo=d.ClrNo and h.BranchCode=d.BranchCode
	inner join Job_Order j on d.JobNo=j.JNo and d.BranchCode=j.BranchCode
	inner join (select Cast(ConfigKey as int) as JobType,ConfigValue as JobTypeName from Mas_Config where ConfigCode='JOB_TYPE') jt
	on j.JobType=jt.JobType
	inner join Job_SrvSingle s on d.SICode=s.SICode
	where h.DocStatus<>9 and Year(h.ClrDate)={0}
	group by jt.JobTypeName
) t
"
        dtEstProfit = cnn.GetTableFromSQL(String.Format(sql, currentYear))

        sql = "
select j.CSCode as CSCode,
sum(case when j.JobStatus<5 then 1 else 0 end) as UnbillJob,
sum(case when j.JobStatus<7 and j.JobStatus>4 then 1 else 0 end) as BilledJob,
sum(case when j.JobStatus=7 then 1 else 0 end) as CollectedJob
from Job_Order j
where j.JobStatus<>99
and Year(j.DocDate)={0}
group by j.CSCode
"
        dtCountJob = cnn.GetTableFromSQL(String.Format(sql, currentYear))
    End If

End Code
<style>
    td label {
        color:black;
    }
</style>
<div class="container">
    <div class="modal fade" role="dialog" id="tbCountJob">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button data-dismiss="modal" class="btn btn-danger">Close</button> <b>Total of Jobs</b>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>CS</th>
                                <th>Unbill</th>
                                <th>Billed</th>
                                <th>Collected</th>
                            </tr>
                        </thead>
                        <tbody>
                            @If user <> "" Then
                                If dtCountJob.Rows.Count > 0 Then
                                    If System.DBNull.Value.Equals(dtCountJob.Rows(0)(0)) = False Then
                                        For Each dr As Data.DataRow In dtCountJob.Rows
                                            countUnbill += Convert.ToInt32(dr("UnbillJob"))
                                            countBill += Convert.ToInt32(dr("BilledJob"))
                                            countComplete += Convert.ToInt32(dr("CollectedJob"))
                                            @<tr>
    <td>@dr("CSCode")</td>
    <td class="text-right">@Convert.ToDouble(dr("UnbillJob")).ToString("0")</td>
    <td class="text-right">@Convert.ToDouble(dr("BilledJob")).ToString("0")</td>
    <td class="text-right">@Convert.ToDouble(dr("CollectedJob")).ToString("0")</td>
</tr>

                                        Next

                                    End If

                                End If
                            End If
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" role="dialog" id="tbAdvPay">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button data-dismiss="modal" class="btn btn-danger">Close</button> <b>Summary Of Payment By Customer</b>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Customer</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            @If user <> "" Then
                                sumAdvPay = 0
                                If dtAdvPay.Rows.Count > 0 Then
                                    If System.DBNull.Value.Equals(dtAdvPay.Rows(0)(0)) = False Then
                                        For Each dr As Data.DataRow In dtAdvPay.Rows
                                            @<tr>
                                                <td>@dr("CustName")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("TotalPayment")).ToString("#,##0.00")</td>
                                            </tr>
                                            sumAdvPay += Convert.ToDouble(dr("TotalPayment"))
                                        Next

                                    End If

                                End If
                            End If
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" role="dialog" id="tbAdvUnclear">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button data-dismiss="modal" class="btn btn-danger">Close</button> <b>Summary Of Payment Unclear By Staff</b>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Staff</th>
                                <th>Balance</th>
                            </tr>
                        </thead>
                        <tbody>
                            @If user <> "" Then
                                sumAdvUnclear = 0
                                If dtAdvUnclear.Rows.Count > 0 Then
                                    If System.DBNull.Value.Equals(dtAdvUnclear.Rows(0)(0)) = False Then
                                        For Each dr As Data.DataRow In dtAdvUnclear.Rows
                                            @<tr>
                                                <td>@dr("EmpCode")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("TotalUnclear")).ToString("#,##0.00")</td>
                                            </tr>
                                            sumAdvUnclear += Convert.ToDouble(dr("TotalUnclear"))
                                        Next
                                    End If

                                End If
                            End If
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" role="dialog" id="tbEstProfit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button data-dismiss="modal" class="btn btn-danger">Close</button> <b>Income and Espenses Entries</b>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                            <tr>
                                <th rowspan="2">Job Type</th>
                                <th colspan="3">Expenses</th>
                                <th rowspan="2">Incomes</th>
                                <th rowspan="2">Profit</th>
                                <th rowspan="2">%</th>
                            </tr>
                            <tr>
                                <th>Customers</th>
                                <th>Company</th>
                                <th>Earnest</th>
                            </tr>
                        </thead>
                        <tbody>
                            @If user <> "" Then
                                sumClrAdv = 0
                                sumClrCost = 0
                                sumClrDep = 0
                                sumClrServ = 0
                                sumClrProfit = 0
                                sumServUnBill = 0
                                If dtEstProfit.Rows.Count > 0 Then
                                    If System.DBNull.Value.Equals(dtEstProfit.Rows(0)(0)) = False Then
                                        For Each dr As Data.DataRow In dtEstProfit.Rows
                                            @<tr>
                                                <td>@dr("JobTypeName")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("CostAdv")).ToString("#,##0.00")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("CostExp")).ToString("#,##0.00")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("CostDep")).ToString("#,##0.00")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("ServChg")).ToString("#,##0.00")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("EstProfit")).ToString("#,##0.00")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("ProfitRate")).ToString("#,##0.00")</td>
                                            </tr>
                                            sumClrAdv += Convert.ToDouble(dr("CostAdv"))
                                            sumClrCost += Convert.ToDouble(dr("CostExp"))
                                            sumClrDep += Convert.ToDouble(dr("CostDep"))
                                            sumClrServ += Convert.ToDouble(dr("ServChg"))
                                            sumClrProfit += Convert.ToDouble(dr("EstProfit"))
                                            sumServUnBill += Convert.ToDouble(dr("ServUnBill"))
                                        Next
                                    End If

                                End If
                            End If
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" role="dialog" id="tbAdvPay">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button data-dismiss="modal" class="btn btn-danger">Close</button> <b>Summary Of Payment By Customer</b>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Customer</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            @If user <> "" Then
                                sumAdvPay = 0
                                If dtAdvPay.Rows.Count > 0 Then
                                    If System.DBNull.Value.Equals(dtAdvPay.Rows(0)(0)) = False Then
                                        For Each dr As Data.DataRow In dtAdvPay.Rows
                                            @<tr>
                                                <td>@dr("CustName")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("TotalPayment")).ToString("#,##0.00")</td>
                                            </tr>
                                            sumAdvPay += Convert.ToDouble(dr("TotalPayment"))
                                        Next

                                    End If

                                End If
                            End If
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <div style="display:flex">
                <div>
                    <b>Data of </b><br /> <input type="number" class="form-control" id="txtYear" value="@currentYear" />
                </div>
                <div>
                    <br />
                    <input type="button" class="btn btn-primary" onclick="RefreshPage()" value="Show" />
                </div>
            </div>
        </div>
        <div class="col-sm-3">
            <label>Unbill Jobs</label>
            <br />
            <div style="width: 100%; text-align: center; background-color:lightyellow; color:red; font-size: x-large">@countUnbill</div>
        </div>
        <div class="col-sm-3">
            <label>Billed Jobs</label>
            <br />
            <div style="width: 100%; text-align: center; background-color: lightgreen; color: green; font-size: x-large">@countBill</div>
        </div>
        <div class="col-sm-3">
            <label>Collected Jobs</label>
            <br />
            <div style="width:100%;text-align:center;background-color:lightblue;color:blue;font-size:x-large">@countComplete</div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-12">
            <label>Estimate Profit</label>
            <br />
            <table style="width:100%;border-width:thin;border-collapse:collapse;" border="1">
                <tr>
                    <td rowspan="3" colspan="2" style="text-align:center;background-color:hotpink;color:blue;font-size:large">
                        <label>Sales</label>
                        <br />
                        <b>@sumClrServ.ToString("#,##0.00")</b>
                    </td>
                    <td style="text-align:center;background-color:lightblue;color:blue;font-size:large">
                        <label>Company Cost</label>
                        <br />
                        <b>@sumClrCost.ToString("#,##0.00")</b>
                    </td>
                    <td style="text-align:center;background-color:white;color:darkgreen;font-size:large">
                        <label>Profit</label>
                        <br />
                        <b>
                            @((sumClrServ - sumClrCost).ToString("#,##0.00"))
                        </b>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;background-color:lightyellow;color:red;font-size:large">
                        <label>Credit Advance</label>
                        <br />
                        <b>@sumClrAdv.ToString("#,##0.00")</b>
                    </td>
                    <td style="text-align:center;background-color:lightgreen;color:green;font-size:large">
                        <label>Profit-Advance</label>
                        <br />
                        <b>@((sumClrServ - sumClrCost - sumClrAdv).ToString("#,##0.00"))</b>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;background-color:lightsalmon;color:red;font-size:large">
                        <label>Deposit Balance</label>
                        <br />
                        <b>@sumClrDep.ToString("#,##0.00")</b>

                    </td>
                    <td style="text-align:center;background-color:lightgreen;color:green;font-size:large">
                        <label>Profit-Deposit</label>
                        <br />
                        <b>@((sumClrServ - sumClrCost - sumClrAdv - sumClrDep).ToString("#,##0.00"))</b>
                    </td>
                </tr>
                <tr style="text-align:center;font-size:larger;">
                    <td rowspan="2">
                        <label>Service Billed</label>
                        <br />
                        <b>@((sumClrServ - sumServUnBill).ToString("#,##0.00"))</b>
                    </td>
                    <td rowspan="2">
                        <label>Service UnBilled</label>
                        <br />
                        <b>@(sumServUnBill.ToString("#,##0.00"))</b>
                    </td>
                    <td>
                        <label>Total Cost</label>
                        <br />
                        <b>@((sumClrCost + sumClrAdv + sumClrDep).ToString("#,##0.00"))</b>
                    </td>
                    <td>
                        <label>Net Profit</label>
                        <br />
                        <b>@((sumClrServ - sumClrCost - sumClrAdv - sumClrDep - sumServUnBill).ToString("#,##0.00"))</b>
                    </td>
                </tr>
                <tr style="text-align:center;font-size:larger;">
                    <td>
                        <label>Re-imbursement Cost</label>
                        <br />
                        <b>@((sumClrAdv + sumClrDep).ToString("#,##0.00"))</b>
                    </td>
                    <td>
                        <label>Actual Profit</label>
                        <br />
                        <b>@((sumClrServ - sumServUnBill - sumClrCost).ToString("#,##0.00"))</b>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-2">
            <label>Advance Payment </label>
        </div>
        <div class="col-sm-2" style="background-color:yellow;color:red;font-size:x-large">
            <span onclick="ToggleModal('#tbAdvPay')">@sumAdvPay.ToString("#,##0.00")</span>
        </div>
        <div class="col-sm-2">
            <label>Advance Unclear </label>
        </div>
        <div class="col-sm-2" style="background-color:red;color:white;font-size:x-large">
            <span onclick="ToggleModal('#tbAdvUnclear')">@sumAdvUnclear.ToString("#,##0.00")</span>
        </div>
        <div class="col-sm-2">
            <label>Advance Used </label>
        </div>
        <div class="col-sm-2" style="background-color:green;color:white;font-size:x-large">
            <span onclick="ToggleModal('#tbAdvUsed')">@sumAdvUsed.ToString("#,##0.00")</span>
        </div>
    </div>
</div>

<script type="text/javascript">
    var path = '@Url.Content("~")';
    function ToggleModal(id) {
        $(id).modal('show');
    }
    function RefreshPage() {
        let yy = $('#txtYear').val();
        window.location.href = '?Year=' + yy;
    }
</script>