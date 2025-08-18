@Code
    ViewBag.Title = "Main Dashboard"
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
    End If

End Code
<div class="container">
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
    <div class="modal fade" role="dialog" id="tbAdvUsed">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button data-dismiss="modal" class="btn btn-danger">Close</button> <b>Summary Of Payment Used By Staff</b>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Staff</th>
                                <th>Refund</th>
                                <th>Used</th>
                            </tr>
                        </thead>
                        <tbody>
                            @If user <> "" Then
                                sumAdvUsed = 0
                                If dtAdvUsed.Rows.Count > 0 Then
                                    If System.DBNull.Value.Equals(dtAdvUsed.Rows(0)(0)) = False Then
                                        For Each dr As Data.DataRow In dtAdvUsed.Rows
                                            @<tr>
                                                <td>@dr("EmpCode")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("Balance")).ToString("#,##0.00")</td>
                                                <td class="text-right">@Convert.ToDouble(dr("ActualUsed")).ToString("#,##0.00")</td>
                                            </tr>
                                            sumAdvUsed += Convert.ToDouble(dr("ActualUsed"))
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
        <div class="col-sm-2">
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
    </div>
    <div class="row">
        <div class="col-sm-2">
            <label>Total Payment </label>
        </div>
        <div class="col-sm-2" style="background-color:yellow;color:red;font-size:x-large">
            <label onclick="ToggleModal('#tbAdvPay')">@sumAdvPay.ToString("#,##0.00")</label>
        </div>
        <div class="col-sm-2">
            <label>Total Unclear </label>
        </div>
        <div class="col-sm-2" style="background-color:red;color:white;font-size:x-large">
            <label onclick="ToggleModal('#tbAdvUnclear')">@sumAdvUnclear.ToString("#,##0.00")</label>
        </div>
        <div class="col-sm-2">
            <label>Total Used </label>
        </div>
        <div class="col-sm-2" style="background-color:green;color:white;font-size:x-large">
            <label onclick="ToggleModal('#tbAdvUsed')">@sumAdvUsed.ToString("#,##0.00")</label>
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