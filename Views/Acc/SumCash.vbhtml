@Code
    Dim cutoffDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        cutoffDate = Request.QueryString("BeginDate")
    End If
    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
    End If
    Dim sqlCashSource = "
select c.VoucherDate, s.acType,s.BookCode,c.TRemark,
(case when s.PRType='R' then s.CashAmount+s.ChqAmount else 0 end) as Debit,
(case when s.PRType='P' then s.CashAmount+s.ChqAmount else 0 end) as Credit,
(case when s.acType='CU' then 'เงินทดรองจ่ายลูกค้า' else 
(case when s.acType='CH' AND s.ChqStatus<>'P' then 'เช็คยังไม่ถึงกำหนด' else 
(case when s.acType='CR' then 'รายการปรับปรุง' else 'เงินสด/เงินฝากธนาคาร' end)
end) 
end) as acGroup
from Job_CashControlSub s inner join Job_CashControl c
on concat(s.branchcode,s.controlno)=concat(c.branchcode,c.controlno)
where not c.CancelProve<>''
"
    Dim sqlCashTotal = "
with s 
as (
" & sqlCashSource & "
)
select 
acGRoup,
(CASE WHEN sum(case when VoucherDate<'" & cutoffDate & "' then Debit-Credit else 0 end) >0 then 
sum(case when VoucherDate<'" & cutoffDate & "' then Debit-Credit else 0 end) 
ELSE 0 END) as BalDR,
(CASE WHEN sum(case when VoucherDate<'" & cutoffDate & "' then Debit-Credit else 0 end) <0 then 
sum(case when VoucherDate<'" & cutoffDate & "' then Credit-Debit else 0 end) 
ELSE 0 END) as BalCR,
sum(case when VoucherDate>='" & cutoffDate & "' then Debit else 0 end) as CurrDR,
sum(case when VoucherDate>='" & cutoffDate & "' then Credit else 0 end) as CurrCR,
(CASE WHEN sum(Debit-Credit) >0 then 
sum(Debit-Credit) 
ELSE 0 END) as NewDR,
(CASE WHEN sum(Debit-Credit) <0 then 
sum(Credit-Debit) 
ELSE 0 END) as NewCR
from s
where s.VoucherDate<='" & endDate & "'
group by acGRoup"
    Dim oCashTotal = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlCashTotal)
End Code
<h3>Cash/Cheque</h3> (@cutoffDate - @endDate)
@If oCashTotal.Rows.Count > 0 Then
    @<table>
    </table>
End If