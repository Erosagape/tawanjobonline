@Code
    Layout = Nothing

    ViewData("Title") = "WorkSheet"
    Dim sql = "
    select j.JNo,j.JobType,j.ShipBy,j.DocDate,j.ETDDate,j.ETADate,j.custRefNo,
j.CustCode,j.HAWB,j.BookingNo,j.DeclareNumber,j.TotalContainer,h.ClrDate,h.CTN_NO,
d.Date50Tavi as SlipDate,d.SlipNO,g.GroupName,
s.IsExpense,s.IsCredit,s.NameEng as ServiceNameEN,s.NameThai as ServiceNameTH,
(case when s.IsCredit=1 and s.IsExpense=0 then d.UsedAmount else 0 end) as AdvAmount,
(case when s.IsCredit=1 and s.IsExpense=0 then d.ChargeVAT else 0 end) as AdvVat,
(case when s.IsCredit=1 and s.IsExpense=0 then d.Tax50Tavi else 0 end) as AdvWht,
(case when s.IsCredit=1 and s.IsExpense=0 then d.BNet else 0 end) as AdvNet,
(case when s.IsCredit=0 and s.IsExpense=0 then d.UsedAmount else 0 end) as SalesAmount,
(case when s.IsCredit=0 and s.IsExpense=0 then d.ChargeVAT else 0 end) as SalesVat,
(case when s.IsCredit=0 AND s.IsExpense=0 then d.Tax50Tavi else 0 end) as SalesWht,
(case when s.IsCredit=0 AND s.IsExpense=0 then d.BNet else 0 end) as SalesNet,
(case when s.IsExpense=1 then d.UsedAmount else 0 end) as CostAmount,
(case when s.IsExpense=1 then d.ChargeVAT else 0 end) as CostVat,
(case when s.IsExpense=1 then d.Tax50Tavi else 0 end) as CostWht,
(case when s.IsExpense=1 then d.BNet else 0 end) as CostNet,
(case when s.IsCredit=1 then 0 else d.UsedAmount*(CASE WHEN s.IsExpense=1 then -1 else 1 end) end) as ProfitAmt,
d.VenderBillingNo,d.VenderCode,d.AdvNO,a.PaymentDate,d.AdvItemNo,
i.DocNo as InvNo,i.DocDate as InvDate,i.DueDate as InvDueDate,i.BillAcceptNo,i.BillIssueDate,i.BillAcceptDate,
rh.ReceiptNo,rh.ReceiptDate
from Job_Order j left join Job_ClearDetail d
on concat(j.branchcode,j.jno)=concat(d.BranchCode,d.JobNo)
left join Job_ClearHeader h
on concat(d.branchcode,d.clrno)=concat(h.branchcode,h.clrno)
left join job_AdvHeader a
on concat(d.BranchCode,d.AdvNO)=concat(a.BranchCode,a.AdvNo)
left join Job_InvoiceHeader i
on concat(d.branchcode,d.linkbillno)=concat(i.branchcode,i.docno)
left join Job_SrvSingle s
on d.SICode=s.SIcode 
left join Job_SrvGroup g
on s.GroupCode =g.GroupCode
left join Job_ReceiptDetail rd
on concat(d.branchcode,d.linkbillno,d.linkitem)=concat(rd.branchcode,rd.invoiceno,rd.invoiceitemno)
left join Job_ReceiptHeader rh 
on concat(rd.branchcode,rd.receiptno)=concat(rh.branchcode,rh.receiptno)
where isnull(h.DocStatus,0)<>99 and isnull(i.CancelProve,'')='' and isnull(rh.CancelPRove,'')=''
"
    Dim sqlwhere = "
"
    Dim onDate = "j.DocDate"
    If Request.QueryString("OnDate") IsNot Nothing Then
        onDate = Request.QueryString("OnDate")
    End If
    If Request.QueryString("Datefrom") IsNot Nothing Then
        sqlwhere &= " AND " & onDate & ">='" & Request.QueryString("DateFrom") & "'"
    Else
        sqlwhere &= " AND j.DocDate>='" & New Date(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd") & "'"
    End If
    If Request.QueryString("DateTo") IsNot Nothing Then
        sqlwhere &= " AND " & onDate & "<='" & Request.QueryString("DateTo") & "'"
    Else
        sqlwhere &= " AND j.DocDate<='" & New Date(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1).ToString("yyyy-MM-dd") & "'"
    End If

    If Request.QueryString("CustCode") IsNot Nothing Then
        sqlwhere &= " AND j.CustCode='" & Request.QueryString("CustCode") & "'"
    End If
    If Request.QueryString("JobType") IsNot Nothing Then
        sqlwhere &= " AND j.JobType=" & Request.QueryString("JobType") & ""
    End If
    If Request.QueryString("ShipBy") IsNot Nothing Then
        sqlwhere &= " AND j.ShipBy=" & Request.QueryString("ShipBy") & ""
    End If
    Dim sqlsort = "order by j.JNo"
    Dim tb = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sql & sqlwhere & sqlsort)
End Code
<h2>Costing Worksheet</h2>
<table style="border-collapse:collapse" border="1">
    <thead>
        <tr>
            <th>Job#</th>
            <th>ETD/ETA</th>
            <th>Cust.Ref#</th>
            <th>Booking</th>
            <th>B/L</th>
            <th>Adv.No</th>
            <th>Adv.Date</th>
            <th>Charges</th>
            <th>Cust.Adv</th>
            <th>Company.Chg</th>
            <th>Company.Cost</th>
            <th>Invoice / Billing</th>
            <th>Invoice Date</th>
            <th>Receipt</th>
            <th>Receipt Date</th>
        </tr>
    </thead>
    <tbody>
        @For Each dr As Data.DataRow In tb.Rows
                    @<tr>
            <td>@dr("JNo")</td>
            <td>
                @If dr("JobType") = "1" Then
                    If dr.IsNull("ETADate") = False Then
                        @Convert.ToDateTime(dr("ETADate")).ToString("dd/MM/yyyy")
                    End If
                Else
                    If dr.IsNull("ETDDate") = False Then
                        @Convert.ToDateTime(dr("ETDDate")).ToString("dd/MM/yyyy")
                    End If
                End If
            </td>
            <td>@dr("CustReFNo")</td>
            <td>@dr("BookingNo")</td>
            <td>@dr("HAWB")</td>
            <td>@dr("AdvNO")</td>
            <td>
                @If dr.IsNull("PaymentDate") = False Then
                    @Convert.ToDateTime(dr("PaymentDate")).ToString("dd/MM/yyyy")
                End If                    
            </td>
            <td>@dr("ServiceNameTH")</td>
            <td>@dr("AdvNet")</td>
            <td>@dr("SalesNet")</td>
            <td>@dr("CostNet")</td>
            <td>@dr("InvNo") / @dr("BillAcceptNo")</td>
            <td>
                @If dr.IsNull("InvDate") = False Then
                    @Convert.ToDateTime(dr("InvDate")).ToString("dd/MM/yyyy")
                End If
            </td>
            <td>@dr("ReceiptNo")</td>
            <td>
                @If dr.IsNull("ReceiptDate") = False Then
                    @Convert.ToDateTime(dr("ReceiptDate")).ToString("dd/MM/yyyy")
                End If
            </td>
        </tr>

        Next
    </tbody>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
</script>

