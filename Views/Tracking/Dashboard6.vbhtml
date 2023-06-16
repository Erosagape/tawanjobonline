@Code
    ViewData("Title") = "Dashboard Account"
    Dim beginDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        beginDate = Request.QueryString("BeginDate")
    End If
    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
    End If
    Dim sqlCash = "
with s
as (
select c.VoucherDate, s.acType,s.BookCode,isnull(a.BookName,'เงินสดในมือ') as BookName,c.TRemark,
(case when s.PRType='R' then s.CashAmount+s.ChqAmount else 0 end) as Debit,
(case when s.PRType='P' then s.CashAmount+s.ChqAmount else 0 end) as Credit,
(case when s.acType='CU' then 'เงินทดรองจ่ายลูกค้า' else
(case when s.acType='CH' AND s.ChqStatus<>'P' then 'เช็คยังไม่ถึงกำหนด' else
(case when s.acType='CR' then 'รายการปรับปรุง' else 'เงินสด/เงินฝากธนาคาร' end)
end)
end) as acGroup,c.ControlNo,c.TRemark as Remark
from Job_CashControlSub s inner join Job_CashControl c
on concat(s.branchcode,s.controlno)=concat(c.branchcode,c.controlno)
left join Mas_BookAccount a on s.BookCode=a.BookCode
where not c.CancelProve<>''
union
select c.CancelDate, s.acType,s.BookCode,isnull(a.BookName,'เงินสดในมือ') as BookName,c.TRemark,
(case when s.PRType='P' then s.CashAmount+s.ChqAmount else 0 end) as Debit,
(case when s.PRType='R' then s.CashAmount+s.ChqAmount else 0 end) as Credit,
(case when s.acType='CU' then 'เงินทดรองจ่ายลูกค้า' else
(case when s.acType='CH' AND s.ChqStatus<>'P' then 'เช็คยังไม่ถึงกำหนด' else
(case when s.acType='CR' then 'รายการปรับปรุง' else 'เงินสด/เงินฝากธนาคาร' end)
end)
end) as acGroup,c.ControlNo,c.CancelReson
from Job_CashControlSub s inner join Job_CashControl c
on concat(s.branchcode,s.controlno)=concat(c.branchcode,c.controlno)
left join Mas_BookAccount a on s.BookCode=a.BookCode
where not c.CancelProve<>''
)
select
acGRoup,BookName,
(CASE WHEN sum(case when VoucherDate<'{0}' then Debit-Credit else 0 end) >0 then
sum(case when VoucherDate<'{0}' then Debit-Credit else 0 end)
ELSE 0 END) as BalDR,
(CASE WHEN sum(case when VoucherDate<'{0}' then Debit-Credit else 0 end) <0 then
sum(case when VoucherDate<'{0}' then Credit-Debit else 0 end)
ELSE 0 END) as BalCR,
sum(case when VoucherDate>='{0}' then Debit else 0 end) as CurrDR,
sum(case when VoucherDate>='{0}' then Credit else 0 end) as CurrCR,
(CASE WHEN sum(Debit-Credit) >0 then
sum(Debit-Credit)
ELSE 0 END) as NewDR,
(CASE WHEN sum(Debit-Credit) <0 then
sum(Credit-Debit)
ELSE 0 END) as NewCR
from s
where s.VoucherDate<='{1}'
group by acGRoup,BookName
order by acGRoup,BookName
"
    Dim sqlAR = "
with s
as
(
select 'A/R Service' as DocGroup,
h.BranchCode,h.DocNo,'A/R Service - Billing' as DocType,
h.CustCode,c.NameThai as CustTName,
h.DocDate as DocDate,
h.TotalCharge as Debit,
0 as Credit,
h.RefNo as Remark
from Job_InvoiceHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
where h.TotalCharge>0
union
select 'A/R Service' as DocGroup,
h.BranchCode,h.DocNo,'A/R Service - Billing Cancelled' as DocType,
h.CustCode,c.NameThai as CustTName,
h.CancelDate as DocDate,
0 as Debit,
h.TotalCharge as Credit,
h.RefNo as Remark
from Job_InvoiceHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
where h.TotalCharge>0 and h.CancelProve<>''
union
select 'A/R Advance' as DocGroup,
h.BranchCode,h.DocNo,'A/R Advance - Billing' as DocType,
h.CustCode,c.NameThai as CustTName,
h.DocDate as DocDate,
h.TotalAdvance as Debit,
0 as Credit,
h.RefNo
from Job_InvoiceHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
where h.TotalAdvance>0
union
select 'A/R Advance' as DocGroup,
h.BranchCode,h.DocNo,'A/R Advance - Billing Cancelled' as DocType,
h.CustCode,c.NameThai as CustTName,
h.CancelDate as DocDate,
0 as Debit,
h.TotalAdvance as Credit,
h.RefNo
from Job_InvoiceHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
where h.TotalAdvance>0 and h.CancelProve<>''
union
select 'A/R Service' as DocGroup,
h.BranchCode,h.ReceiptNo,'A/R Service - Payment' as DocType,
h.CustCode,c.NameThai as CustTName,
h.ReceiptDate as DocDate,
0 as Debit,
sum(d.Amt) as Credit,
d.InvoiceNo
from Job_ReceiptHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
inner join Job_ReceiptDetail d
on CONCAT(h.BranchCode,h.ReceiptNo)=CONCAT(d.BranchCode,d.ReceiptNo)
inner join Job_InvoiceDetail i
on CONCAT(d.BranchCode,d.InvoiceNo,d.InvoiceItemNo)=CONCAT(i.BranchCode,i.DocNo,i.ItemNo)
where i.AmtCharge>0
group by h.BranchCode,h.ReceiptNo,
h.CustCode,c.NameThai,h.ReceiptDate,d.InvoiceNo
union
select 'A/R Service' as DocGroup,
h.BranchCode,h.ReceiptNo,'A/R Service - Payment Cancelled' as DocType,
h.CustCode,c.NameThai as CustTName,
h.CancelDate as DocDate,
sum(d.Amt) as Debit,
0 as Credit,
d.InvoiceNo
from Job_ReceiptHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
inner join Job_ReceiptDetail d
on CONCAT(h.BranchCode,h.ReceiptNo)=CONCAT(d.BranchCode,d.ReceiptNo)
inner join Job_InvoiceDetail i
on CONCAT(d.BranchCode,d.InvoiceNo,d.InvoiceItemNo)=CONCAT(i.BranchCode,i.DocNo,i.ItemNo)
where i.AmtCharge>0 and h.CancelProve<>''
group by h.BranchCode,h.ReceiptNo,
h.CustCode,c.NameThai,h.CancelDate,d.InvoiceNo
union
select 'A/R Advance' as DocGroup,
h.BranchCode,h.ReceiptNo,'A/R Advance - Payment' as DocType,
h.CustCode,c.NameThai as CustTName,
h.ReceiptDate as DocDate,
0 as Debit,
sum(d.Amt) as Credit,
d.InvoiceNo
from Job_ReceiptHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
inner join Job_ReceiptDetail d
on CONCAT(h.BranchCode,h.ReceiptNo)=CONCAT(d.BranchCode,d.ReceiptNo)
inner join Job_InvoiceDetail i
on CONCAT(d.BranchCode,d.InvoiceNo,d.InvoiceItemNo)=CONCAT(i.BranchCode,i.DocNo,i.ItemNo)
where i.AmtAdvance>0
group by h.BranchCode,h.ReceiptNo,
h.CustCode,c.NameThai,h.ReceiptDate,d.InvoiceNo
union
select 'A/R Advance' as DocGroup,
h.BranchCode,h.ReceiptNo,'A/R Advance - Payment Cancelled' as DocType,
h.CustCode,c.NameThai as CustTName,
h.CancelDate as DocDate,
sum(d.Amt) as Debit,
0 as Credit,
d.InvoiceNo
from Job_ReceiptHeader h
inner join Mas_Company c on CONCAT(h.Custcode,h.CustBranch)=CONCAT(c.CustCode,c.Branch)
inner join Job_ReceiptDetail d
on CONCAT(h.BranchCode,h.ReceiptNo)=CONCAT(d.BranchCode,d.ReceiptNo)
inner join Job_InvoiceDetail i
on CONCAT(d.BranchCode,d.InvoiceNo,d.InvoiceItemNo)=CONCAT(i.BranchCode,i.DocNo,i.ItemNo)
where i.AmtAdvance>0 and h.CancelProve<>''
group by h.BranchCode,h.ReceiptNo,
h.CustCode,c.NameThai,h.CancelDate,d.InvoiceNo

)
select
DocGroup,CustTName as CustName,
(CASE WHEN sum(case when DocDate<'{0}' then Debit-Credit else 0 end) >0 then
sum(case when DocDate<'{0}' then Debit-Credit else 0 end)
ELSE 0 END) as BalDR,
(CASE WHEN sum(case when DocDate<'{0}' then Debit-Credit else 0 end) <0 then
sum(case when DocDate<'{0}' then Credit-Debit else 0 end)
ELSE 0 END) as BalCR,
sum(case when DocDate>='{0}' then Debit else 0 end) as CurrDR,
sum(case when DocDate>='{0}' then Credit else 0 end) as CurrCR,
(CASE WHEN sum(Debit-Credit) >0 then
sum(Debit-Credit)
ELSE 0 END) as NewDR,
(CASE WHEN sum(Debit-Credit) <0 then
sum(Credit-Debit)
ELSE 0 END) as NewCR
from s
where s.DocDate<='{1}'
group by DocGroup,CustTName
order by DocGroup,CustTName
"
    Dim sqlAP = "
with s as
(
select 'A/P Setup' as DocGroup,'A/P Billing' as DocType,h.DocDate,h.VenCode,v.TName as VenderName,
h.RefNo,h.PoNo,0 as Debit,d.Amt as Credit,d.SDescription
from Job_PaymentHeader h inner join Job_PaymentDetail d
on CONCAT(h.BranchCode,h.DocNo)=CONCAT(d.BranchCode,d.DocNo)
left join Mas_Vender v on h.VenCode=v.VenCode
where h.ApproveBy<>''
union
select 'A/P Setup','A/P Billing Cancelled',h.CancelDate,h.VenCode,v.TName as VenderName,
h.RefNo,h.PoNo,d.Amt as Debit,0 as Credit,d.SDescription
from Job_PaymentHeader h inner join Job_PaymentDetail d
on CONCAT(h.BranchCode,h.DocNo)=CONCAT(d.BranchCode,d.DocNo)
left join Mas_Vender v on h.VenCode=v.VenCode
where h.CancelProve<>''
union
select 'A/P Setup' as DocGroup,'A/P Payment' as DocType,h.PaymentDate,h.VenCode,v.TName as VenderName,
h.RefNo,h.PoNo,d.Amt as Debit,0 as Credit,h.PaymentRef
from Job_PaymentHeader h inner join Job_PaymentDetail d
on CONCAT(h.BranchCode,h.DocNo)=CONCAT(d.BranchCode,d.DocNo)
left join Mas_Vender v on h.VenCode=v.VenCode
where h.PaymentRef<>'' and h.AdvRef=''
union
select 'A/P Setup' as DocGroup,'A/P Payment' as DocType,a.PaymentDate,h.VenCode,v.TName as VenderName,
h.RefNo,h.PoNo,d.Amt as Debit,0 as Credit,a.PaymentRef
from Job_PaymentHeader h inner join Job_PaymentDetail d
on CONCAT(h.BranchCode,h.DocNo)=CONCAT(d.BranchCode,d.DocNo)
left join Mas_Vender v on h.VenCode=v.VenCode
inner join Job_AdvHeader a on CONCAT(h.BranchCode,h.AdvRef)=CONCAT(a.BranchCode,a.AdvNo)
where a.PaymentRef<>''
union
select 'A/P Overhead' as DocGroup,'A/P Advance' as DocType,a.AdvDate as ReqDate,a.EmpCode,u.TName,
b.ForJNo,b.TRemark,0 as Debit,b.AdvAmount as Credit,b.SDescription
from Job_AdvHeader a inner join Job_AdvDetail b
on CONCAT(a.BranchCode,a.AdVNo)=CONCAT(b.BranchCode,b.AdvNo)
left join Mas_User u on a.EmpCode=u.UserID
where a.PaymentNo='' and a.ApproveBy<>''
union
select 'A/P Overhead' as DocGroup,'A/P Advance Cancelled' as DocType,a.CancelDate as ReqDate,a.EmpCode,u.TName,
b.ForJNo,b.TRemark,b.AdvAmount as Debit,0 as Credit,a.CancelReson
from Job_AdvHeader a inner join Job_AdvDetail b
on CONCAT(a.BranchCode,a.AdVNo)=CONCAT(b.BranchCode,b.AdvNo)
left join Mas_User u on a.EmpCode=u.UserID
where a.PaymentNo='' and a.CancelProve<>''
union
select 'A/P Overhead' as DocGroup,'A/P Payment' as DocType,a.PaymentDate as ReqDate,a.EmpCode,u.TName,
b.ForJNo,b.TRemark,b.AdvAmount as Debit,0 as Credit,a.PaymentRef
from Job_AdvHeader a inner join Job_AdvDetail b
on CONCAT(a.BranchCode,a.AdVNo)=CONCAT(b.BranchCode,b.AdvNo)
left join Mas_User u on a.EmpCode=u.UserID
where a.PaymentNo='' and a.PaymentRef<>''
)
select
DocGroup,VenderName,
(CASE WHEN sum(case when DocDate<'{0}' then Debit-Credit else 0 end) >0 then
sum(case when DocDate<'{0}' then Debit-Credit else 0 end)
ELSE 0 END) as BalDR,
(CASE WHEN sum(case when DocDate<'{0}' then Debit-Credit else 0 end) <0 then
sum(case when DocDate<'{0}' then Credit-Debit else 0 end)
ELSE 0 END) as BalCR,
sum(case when DocDate>='{0}' then Debit else 0 end) as CurrDR,
sum(case when DocDate>='{0}' then Credit else 0 end) as CurrCR,
(CASE WHEN sum(Debit-Credit) >0 then
sum(Debit-Credit)
ELSE 0 END) as NewDR,
(CASE WHEN sum(Debit-Credit) <0 then
sum(Credit-Debit)
ELSE 0 END) as NewCR
from s
where s.DocDate<='{1}'
group by DocGroup,VenderName
order by DocGroup,VenderName
"
    Dim sqlPL = "
with s as (
select 
isnull(isnull(i.DocDate,d.Date50Tavi),h.ClrDate) as DocDate,
d.ClrNo,d.SlipNO,d.Remark,d.JobNo,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then d.UsedAmount else 0 end) as Debit,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then 0 else d.UsedAmount end) as Credit,
d.SDescription,s.NameThai as AccountName,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then 
(case when isnull(s.IsCredit,0)=1 then 'Re-imbursement' else 'Expenses' end)
else 'Income' end) as DocType,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then 'Expenses' else 'Income' end) as DocGroup
from Job_ClearDetail d 
inner join Job_ClearHeader h
on Concat(d.branchcode,d.clrno)=concat(h.branchcode,h.clrno)
left join Job_SrvSingle s
on d.SICode=s.SIcode 
left join Job_InvoiceHeader i
on concat(d.BranchCode,d.LinkBillNo)=concat(i.BranchCode,i.DocNo)
union 
select 
h.CancelDate as DocDate,
d.ClrNo,d.SlipNO,h.CancelReson,d.JobNo,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then 0 else d.UsedAmount end) as Debit,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then d.UsedAmount else 0 end) as Credit,
d.SDescription,s.NameThai as AccountName,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then 
(case when isnull(s.IsCredit,0)=1 then 'Re-imbursement Cancelled' else 'Expenses Cancelled' end)
else 'Income Cancelled' end) as DocType,
(case when isnull(s.IsCredit,0)=1 or isnull(s.IsExpense,0)=1  then 'Expenses' else 'Income' end) as DocGroup
from Job_ClearDetail d 
inner join Job_ClearHeader h
on Concat(d.branchcode,d.clrno)=concat(h.branchcode,h.clrno)
left join Job_SrvSingle s
on d.SICode=s.SIcode 
where h.CancelProve<>''
)
select
DocGroup,AccountName,
(CASE WHEN sum(case when DocDate<'{0}' then Debit-Credit else 0 end) >0 then
sum(case when DocDate<'{0}' then Debit-Credit else 0 end)
ELSE 0 END) as BalDR,
(CASE WHEN sum(case when DocDate<'{0}' then Debit-Credit else 0 end) <0 then
sum(case when DocDate<'{0}' then Credit-Debit else 0 end)
ELSE 0 END) as BalCR,
sum(case when DocDate>='{0}' then Debit else 0 end) as CurrDR,
sum(case when DocDate>='{0}' then Credit else 0 end) as CurrCR,
(CASE WHEN sum(Debit-Credit) >0 then
sum(Debit-Credit)
ELSE 0 END) as NewDR,
(CASE WHEN sum(Debit-Credit) <0 then
sum(Credit-Debit)
ELSE 0 END) as NewCR
from s
where s.DocDate<='{1}'
group by DocGroup,AccountName
order by DocGroup,AccountName
"
End Code
<div class="row">
    <div class="col-sm-3">
        From Date <br />
        <input type="date" id="txtDateFrom" class="form-control" value="@beginDate" />
    </div>
    <div class="col-sm-3">
        To Date <br />
        <input type="date" id="txtDateTo" class="form-control" value="@endDate" />
    </div>
    <div class="col-sm-3">
        <br />
        <input type="button" class="btn btn-primary" value="Search" onclick="RefreshData()" />
    </div>
</div>
@If ViewBag.User <> "" Then
    Dim oCashSum = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlCash, beginDate, endDate))

    Dim acGroup = ""
    @<div class="table-responsive">
         <h3>
             Cash Activities
         </h3>
    <table class="table table-bordered">
            <thead>
                <tr>
                    <th rowspan="2">Descriptions</th>
                    <th colspan="2">Bring Forward<br />at @beginDate</th>
                    <th colspan="2">Balance</th>
                    <th colspan="2">Carry Forward<br />at @endDate</th>
                </tr>
                <tr>
                    <th>Debit</th>
                    <th>Credit</th>
                    <th>Debit</th>
                    <th>Credit</th>
                    <th>Debit</th>
                    <th>Credit</th>
                </tr>
            </thead>
            <tbody>
                @If oCashSum.Rows.Count > 0 Then
                    Dim sumBFDebit As Double = 0
                    Dim sumBFCredit As Double = 0
                    Dim totalBFDebit As Double = 0
                    Dim totalBFCredit As Double = 0
                    Dim sumDebit As Double = 0
                    Dim sumCredit As Double = 0
                    Dim totalDebit As Double = 0
                    Dim totalCredit As Double = 0
                    Dim sumAFDebit As Double = 0
                    Dim sumAFCredit As Double = 0
                    Dim totalAFDebit As Double = 0
                    Dim totalAFCredit As Double = 0
                    For Each dr In oCashSum.Rows
                        If acGroup <> dr("acGroup") Then
                            If acGroup <> "" Then
                                @<tr style="font-weight:bold;background-color:lightblue;">
                                    <td style="text-align:right;">TOTAL @acGroup</td>
                                    <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                                </tr>
                            End If
                            acGroup = dr("acGroup")
                            sumBFCredit = 0
                            sumBFDebit = 0
                            sumCredit = 0
                            sumDebit = 0
                            sumAFCredit = 0
                            sumAFDebit = 0
                            @<tr>
                                <td colspan="7" style="font-weight:bold;background-color:lightgreen">
                                    @acGroup
                                </td>
                            </tr>
                        End If
                        sumBFCredit += Convert.ToDouble(dr("BalCR"))
                        sumBFDebit += Convert.ToDouble(dr("BalDR"))
                        sumCredit += Convert.ToDouble(dr("CurrCR"))
                        sumDebit += Convert.ToDouble(dr("CurrDR"))
                        sumAFCredit += Convert.ToDouble(dr("NewCR"))
                        sumAFDebit += Convert.ToDouble(dr("NewDR"))

                        totalBFCredit += Convert.ToDouble(dr("BalCR"))
                        totalBFDebit += Convert.ToDouble(dr("BalDR"))
                        totalCredit += Convert.ToDouble(dr("CurrCR"))
                        totalDebit += Convert.ToDouble(dr("CurrDR"))
                        totalAFCredit += Convert.ToDouble(dr("NewCR"))
                        totalAFDebit += Convert.ToDouble(dr("NewDR"))
                        @<tr>
                             <td>&nbsp;&nbsp; @dr("BookName")</td>
                            <td style="text-align:right;padding-left:5px;">@Convert.ToDouble(dr("BalDR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("BalCR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("CurrDR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("CurrCR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("NewDR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("NewCR")).ToString("#,##0.00")</td>
                        </tr>
                    Next
                    @<tr style="font-weight:bold;background-color:lightblue">
                        <td style="text-align:right;">TOTAL @acGroup</td>
                        <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                    </tr>
                    @<tr style="font-weight:bold;background-color:lightyellow;">
                        <td>GRAND TOTAL</td>
                        <td style="text-align:right;padding-left:5px;">@totalBFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalBFCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalAFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalAFCredit.ToString("#,##0.00")</td>
                    </tr>

                End If
            </tbody>
        </table>
    </div>
    acGroup = ""

    Dim oARSum = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlAR, beginDate, endDate))

    @<div class="table-responsive">
        <h3>Account Receivables</h3>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th rowspan="2">Descriptions</th>
                    <th colspan="2">Bring Forward<br />at @beginDate</th>
                    <th colspan="2">Balance</th>
                    <th colspan="2">Carry Forward<br />at @endDate</th>
                </tr>
                <tr>
                    <th>Debit</th>
                    <th>Credit</th>
                    <th>Debit</th>
                    <th>Credit</th>
                    <th>Debit</th>
                    <th>Credit</th>
                </tr>
            </thead>
            <tbody>
                @If oARSum.Rows.Count > 0 Then
                    Dim sumBFDebit As Double = 0
                    Dim sumBFCredit As Double = 0
                    Dim totalBFDebit As Double = 0
                    Dim totalBFCredit As Double = 0
                    Dim sumDebit As Double = 0
                    Dim sumCredit As Double = 0
                    Dim totalDebit As Double = 0
                    Dim totalCredit As Double = 0
                    Dim sumAFDebit As Double = 0
                    Dim sumAFCredit As Double = 0
                    Dim totalAFDebit As Double = 0
                    Dim totalAFCredit As Double = 0
                    For Each dr In oARSum.Rows
                        If acGroup <> dr("DocGroup") Then
                            If acGroup <> "" Then
                                @<tr style="font-weight:bold;background-color:lightblue;">
                                    <td style="text-align:right;">TOTAL @acGroup</td>
                                    <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                                    <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                                </tr>
                            End If
                            acGroup = dr("DocGroup")
                            sumBFCredit = 0
                            sumBFDebit = 0
                            sumCredit = 0
                            sumDebit = 0
                            sumAFCredit = 0
                            sumAFDebit = 0
                            @<tr>
                                <td colspan="7" style="font-weight:bold;background-color:lightgreen">
                                    @acGroup
                                </td>
                            </tr>
                        End If
                        sumBFCredit += Convert.ToDouble(dr("BalCR"))
                        sumBFDebit += Convert.ToDouble(dr("BalDR"))
                        sumCredit += Convert.ToDouble(dr("CurrCR"))
                        sumDebit += Convert.ToDouble(dr("CurrDR"))
                        sumAFCredit += Convert.ToDouble(dr("NewCR"))
                        sumAFDebit += Convert.ToDouble(dr("NewDR"))

                        totalBFCredit += Convert.ToDouble(dr("BalCR"))
                        totalBFDebit += Convert.ToDouble(dr("BalDR"))
                        totalCredit += Convert.ToDouble(dr("CurrCR"))
                        totalDebit += Convert.ToDouble(dr("CurrDR"))
                        totalAFCredit += Convert.ToDouble(dr("NewCR"))
                        totalAFDebit += Convert.ToDouble(dr("NewDR"))
                        @<tr>
                            <td>&nbsp;&nbsp; @dr("CustName")</td>
                            <td style="text-align:right;padding-left:5px;">@Convert.ToDouble(dr("BalDR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("BalCR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("CurrDR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("CurrCR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("NewDR")).ToString("#,##0.00")</td>
                            <td style="text-align: right;">@Convert.ToDouble(dr("NewCR")).ToString("#,##0.00")</td>
                        </tr>
                    Next
                    @<tr style="font-weight:bold;background-color:lightblue">
                        <td style="text-align:right;">TOTAL @acGroup</td>
                        <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                    </tr>
                    @<tr style="font-weight:bold;background-color:lightyellow;">
                        <td>GRAND TOTAL</td>
                        <td style="text-align:right;padding-left:5px;">@totalBFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalBFCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalCredit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalAFDebit.ToString("#,##0.00")</td>
                        <td style="text-align: right;">@totalAFCredit.ToString("#,##0.00")</td>
                    </tr>
                End If
            </tbody>
        </table>
    </div>
    acGroup = ""
    Dim oAPSum = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlAP, beginDate, endDate))
    @<div class="table-responsive">
    <h3>Account Payables</h3>
    <table class="table table-bordered">
        <thead>
            <tr>
                <th rowspan="2">Descriptions</th>
                <th colspan="2">Bring Forward<br />at @beginDate</th>
                <th colspan="2">Balance</th>
                <th colspan="2">Carry Forward<br />at @endDate</th>
            </tr>
            <tr>
                <th>Debit</th>
                <th>Credit</th>
                <th>Debit</th>
                <th>Credit</th>
                <th>Debit</th>
                <th>Credit</th>
            </tr>
        </thead>
        <tbody>
            @If oAPSum.Rows.Count > 0 Then
                Dim sumBFDebit As Double = 0
                Dim sumBFCredit As Double = 0
                Dim totalBFDebit As Double = 0
                Dim totalBFCredit As Double = 0
                Dim sumDebit As Double = 0
                Dim sumCredit As Double = 0
                Dim totalDebit As Double = 0
                Dim totalCredit As Double = 0
                Dim sumAFDebit As Double = 0
                Dim sumAFCredit As Double = 0
                Dim totalAFDebit As Double = 0
                Dim totalAFCredit As Double = 0
                For Each dr In oAPSum.Rows
                    If acGroup <> dr("DocGroup") Then
                        If acGroup <> "" Then
                            @<tr style="font-weight:bold;background-color:lightblue;">
                                <td style="text-align:right;">TOTAL @acGroup</td>
                                <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                            </tr>
                        End If
                        acGroup = dr("DocGroup")
                        sumBFCredit = 0
                        sumBFDebit = 0
                        sumCredit = 0
                        sumDebit = 0
                        sumAFCredit = 0
                        sumAFDebit = 0
                        @<tr>
                            <td colspan="7" style="font-weight:bold;background-color:lightgreen">
                                @acGroup
                            </td>
                        </tr>
                    End If
                    sumBFCredit += Convert.ToDouble(dr("BalCR"))
                    sumBFDebit += Convert.ToDouble(dr("BalDR"))
                    sumCredit += Convert.ToDouble(dr("CurrCR"))
                    sumDebit += Convert.ToDouble(dr("CurrDR"))
                    sumAFCredit += Convert.ToDouble(dr("NewCR"))
                    sumAFDebit += Convert.ToDouble(dr("NewDR"))

                    totalBFCredit += Convert.ToDouble(dr("BalCR"))
                    totalBFDebit += Convert.ToDouble(dr("BalDR"))
                    totalCredit += Convert.ToDouble(dr("CurrCR"))
                    totalDebit += Convert.ToDouble(dr("CurrDR"))
                    totalAFCredit += Convert.ToDouble(dr("NewCR"))
                    totalAFDebit += Convert.ToDouble(dr("NewDR"))
                    @<tr>
                        <td>&nbsp;&nbsp; @dr("VenderName")</td>
                        <td style="text-align:right;padding-left:5px;">@Convert.ToDouble(dr("BalDR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("BalCR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("CurrDR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("CurrCR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("NewDR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("NewCR")).ToString("#,##0.00")</td>
                    </tr>
                Next
                @<tr style="font-weight:bold;background-color:lightblue">
                    <td style="text-align:right;">TOTAL @acGroup</td>
                    <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                </tr>
                @<tr style="font-weight:bold;background-color:lightyellow;">
                    <td>GRAND TOTAL</td>
                    <td style="text-align:right;padding-left:5px;">@totalBFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalBFCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalAFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalAFCredit.ToString("#,##0.00")</td>
                </tr>
            End If
        </tbody>
    </table>    
    </div>
    acGroup = ""
    Dim oPLSum = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlPL, beginDate, endDate))
    @<div class="table-responsive">
    <h3>Revenue and Expenses</h3>
    <table class="table table-bordered">
        <thead>
            <tr>
                <th rowspan="2">Descriptions</th>
                <th colspan="2">Bring Forward<br />at @beginDate</th>
                <th colspan="2">Balance</th>
                <th colspan="2">Carry Forward<br />at @endDate</th>
            </tr>
            <tr>
                <th>Debit</th>
                <th>Credit</th>
                <th>Debit</th>
                <th>Credit</th>
                <th>Debit</th>
                <th>Credit</th>
            </tr>
        </thead>
        <tbody>
            @If oPLSum.Rows.Count > 0 Then
                Dim sumBFDebit As Double = 0
                Dim sumBFCredit As Double = 0
                Dim totalBFDebit As Double = 0
                Dim totalBFCredit As Double = 0
                Dim sumDebit As Double = 0
                Dim sumCredit As Double = 0
                Dim totalDebit As Double = 0
                Dim totalCredit As Double = 0
                Dim sumAFDebit As Double = 0
                Dim sumAFCredit As Double = 0
                Dim totalAFDebit As Double = 0
                Dim totalAFCredit As Double = 0
                For Each dr In oPLSum.Rows
                    If acGroup <> dr("DocGroup") Then
                        If acGroup <> "" Then
                            @<tr style="font-weight:bold;background-color:lightblue;">
                                <td style="text-align:right;">TOTAL @acGroup</td>
                                <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                                <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                            </tr>
                        End If
                        acGroup = dr("DocGroup")
                        sumBFCredit = 0
                        sumBFDebit = 0
                        sumCredit = 0
                        sumDebit = 0
                        sumAFCredit = 0
                        sumAFDebit = 0
                        @<tr>
                            <td colspan="7" style="font-weight:bold;background-color:lightgreen">
                                @acGroup
                            </td>
                        </tr>
                    End If
                    sumBFCredit += Convert.ToDouble(dr("BalCR"))
                    sumBFDebit += Convert.ToDouble(dr("BalDR"))
                    sumCredit += Convert.ToDouble(dr("CurrCR"))
                    sumDebit += Convert.ToDouble(dr("CurrDR"))
                    sumAFCredit += Convert.ToDouble(dr("NewCR"))
                    sumAFDebit += Convert.ToDouble(dr("NewDR"))

                    totalBFCredit += Convert.ToDouble(dr("BalCR"))
                    totalBFDebit += Convert.ToDouble(dr("BalDR"))
                    totalCredit += Convert.ToDouble(dr("CurrCR"))
                    totalDebit += Convert.ToDouble(dr("CurrDR"))
                    totalAFCredit += Convert.ToDouble(dr("NewCR"))
                    totalAFDebit += Convert.ToDouble(dr("NewDR"))
                    @<tr>
                        <td>&nbsp;&nbsp; @dr("AccountName")</td>
                        <td style="text-align:right;padding-left:5px;">@Convert.ToDouble(dr("BalDR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("BalCR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("CurrDR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("CurrCR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("NewDR")).ToString("#,##0.00")</td>
                        <td style="text-align: right;">@Convert.ToDouble(dr("NewCR")).ToString("#,##0.00")</td>
                    </tr>
                Next
                @<tr style="font-weight:bold;background-color:lightblue">
                    <td style="text-align:right;">TOTAL @acGroup</td>
                    <td style="text-align:right;padding-left:5px;">@sumBFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumBFCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumAFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@sumAFCredit.ToString("#,##0.00")</td>
                </tr>
                @<tr style="font-weight:bold;background-color:lightyellow;">
                    <td>GRAND TOTAL</td>
                    <td style="text-align:right;padding-left:5px;">@totalBFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalBFCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalCredit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalAFDebit.ToString("#,##0.00")</td>
                    <td style="text-align: right;">@totalAFCredit.ToString("#,##0.00")</td>
                </tr>
            End If
        </tbody>
    </table>
</div>
End If
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function RefreshData() {
        window.location.href = path + 'Tracking/Dashboard?Form=6&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val();
    }
</script>
