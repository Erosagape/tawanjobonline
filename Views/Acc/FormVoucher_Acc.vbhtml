
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Voucher"
    Dim branch = Request.QueryString("Branch")
    Dim controlNo = Request.QueryString("ControlNo")
    Dim sql = "
SELECT * FROM (
select d.*,h.TRemark as VoucherRemark,h.VoucherDate,ah.CustCode as CmpCode,ah.CustBranch as CmpBranch,ad.PayChqTo as VenderName,ad.TRemark as Remark,
ad.ForJNo as JobNo,ah.EmpCode, ah.AdvNo as DocRefNo,ah.AdvDate as DocDate,ad.SDescription,ad.AdvAmount as Amount,ad.ChargeVAT as VAT,ad.Charge50Tavi as WHT,ad.AdvNet as PaidAmount,'ADV' as GLType
from Job_CashControlSub d
inner join Job_CashControl h ON d.BranchCode=h.BranchCode
and d.ControlNo=h.ControlNo
inner join Job_AdvHeader ah ON h.BranchCode=ah.BranchCode
AND h.ControlNo=ah.PaymentRef
inner join Job_AdvDetail ad ON ah.BranchCode=ad.BranchCode
AND ah.AdvNo=ad.AdvNo
union
select d.*,h.TRemark as VoucherRemark,h.VoucherDate,j.CustCode,j.CustBranch,ad.Pay50TaviTo as VenderName,ad.Remark,
ad.JobNo,ah.EmpCode,ah.ClrNo,ah.ClrDate,ad.SDescription,ad.UsedAmount,ad.ChargeVAT,ad.Tax50Tavi,ad.BNet
,'CLRC' as GLType
from Job_CashControlSub d
inner join Job_CashControl h ON d.BranchCode=h.BranchCode
and d.ControlNo=h.ControlNo
inner join Job_ClearHeader ah ON h.BranchCode=ah.BranchCode
AND h.ControlNo=ah.ReceiveRef
inner join Job_ClearDetail ad ON ah.BranchCode=ad.BranchCode
AND ah.ClrNo=ad.ClrNo
left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.JobNo=j.JNo
where ISNULL(ad.AdvNo,'')=''
union
select d.*,h.TRemark as VoucherRemark,h.VoucherDate,j.CustCode,j.CustBranch,ad.Pay50TaviTo as VenderName,ad.Remark,
ad.JobNo,ah.EmpCode,ah.ClrNo,ah.ClrDate,ad.SDescription,ad.UsedAmount,ad.ChargeVAT,ad.Tax50Tavi,ad.BNet
,'CLRA' as GLType
from Job_CashControlSub d
inner join Job_CashControl h ON d.BranchCode=h.BranchCode
and d.ControlNo=h.ControlNo
inner join Job_CashControlDoc dc ON d.BranchCode=dc.BranchCode AND d.Controlno=dc.ControlNo
AND d.acType=dc.acType
inner join Job_ClearHeader ah ON h.BranchCode=ah.BranchCode
AND h.ControlNo=ah.ReceiveRef
inner join Job_ClearDetail ad ON ah.BranchCode=ad.BranchCode
AND ah.ClrNo=ad.ClrNo
left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.JobNo=j.JNo
inner join Job_AdvDetail av on dc.BranchCode=av.BranchCode AND
dc.DocNo =av.AdvNo+'#'+cast(av.ItemNo as varchar) AND
ad.BranchCode=av.BranchCode AND
ad.AdvNo+'#'+cast(ad.AdvItemNo as varchar)=av.AdvNo+'#'+cast(av.ItemNo as varchar)
where ISNULL(ad.AdvNo,'')<>''
union
select d.*,h.TRemark as VoucherRemark,h.VoucherDate,j.CustCode,j.CustBranch,cu.NameThai,ah.TRemark,
c.JobNo ,ah.EmpCode, ad.InvoiceNo,ah.ReceiptDate,ad.SDescription,ad.Amt,ad.AmtVAT,ad.Amt50Tavi,ad.Net
,'INV' as GLType
from Job_CashControlSub d
inner join Job_CashControl h ON d.BranchCode=h.BranchCode
and d.ControlNo=h.ControlNo
inner join Job_ReceiptDetail ad ON h.BranchCode=ad.BranchCode
AND h.ControlNo=ad.ControlNo
inner join Job_ReceiptHeader ah ON ad.BranchCode=ah.BranchCode
AND ad.ReceiptNo=ah.ReceiptNo
inner join Mas_Company cu on ah.BillToCustCode=cu.CustCode and ah.BillToCustBranch=cu.Branch
left join Job_ClearDetail c ON ad.BranchCode=c.BranchCode
AND ad.InvoiceNo=c.LinkBillNo AND ad.InvoiceItemNo=c.LinkItem
left join Job_Order j ON c.BranchCode=j.BranchCode AND c.JobNo=j.JNo
union
select d.*,h.TRemark as VoucherRemark,h.VoucherDate,h.CustCode,h.CustBranch,v.TName,ad.SRemark,
ad.ForJNo,ah.EmpCode,ad.DocNo,ah.PaymentDate,ad.SDescription,ad.Amt,ad.AmtVAT,ad.AmtWHT,ad.Total
,'PAY' as GLType
from Job_CashControlSub d
inner join Job_CashControl h ON d.BranchCode=h.BranchCode
and d.ControlNo=h.ControlNo
inner join Job_PaymentHeader ah ON h.BranchCode=ah.BranchCode
AND h.ControlNo=ah.PaymentRef
inner join Job_PaymentDetail ad ON ad.BranchCode=ah.BranchCode
AND ad.DocNo=ah.DocNo
left join Job_Order j ON ad.BranchCode=j.BranchCode AND ad.ForJNo=j.JNo
left join Mas_Vender v ON ah.VenCode=v.VenCode
) pr {0}
"
    sql = sql.Replace("{0}", String.Format("where BranchCode='{0}' And ControlNo='{1}'", branch, controlNo))
    Dim dt As New System.Data.DataTable
    Dim bLogin As Boolean = False
    If ViewBag.User <> "" Then
        bLogin = True
        dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sql)
    End If
    Dim docType = "VOUCHER"
    If dt.Rows.Count > 0 Then
        If dt.Rows(0)("PRType").ToString().Equals("P") Then
            docType = "PAYMENT " & docType
        End If
        If dt.Rows(0)("PRType").ToString().Equals("R") Then
            docType = "RECEIVE " & docType
        End If
    End If
End Code
<style>
    * {
        font-size:10px;
    }
</style>
@If bLogin Then
@<p style = "text-align:center" >
<b>@docType</b>
    @If dt.Rows.Count > 0 Then
        Dim dr = dt.Rows(0)
        @<table style="width:100%">
    <tr>
        <td style="width: 20%; font-weight: bold">Payment From/To</td>
        <td style="width:30%;">@dr("VenderName").ToString()</td>
        <td style="width: 20%; font-weight: bold">Voucher No</td>
        <td style="width:30%;">@dr("PRVoucher")</td>
    </tr>
    <tr>
        <td style="width: 20%; font-weight: bold">Remark</td>
        <td style="width:30%;">@dr("VoucherRemark").ToString()</td>
        <td style="width: 20%; font-weight: bold">Voucher Date</td>
        <td style="width:30%;">@Convert.ToDateTime(dr("VoucherDate")).ToString("dd/MM/yyyy")</td>
    </tr>
    <tr>
        <td style="width: 20%; font-weight: bold">Cheque/Slip No.</td>
        <td style="width:30%;">@dr("ChqNo").ToString() - @dr("RecvBank").ToString() </td>
        <td style="width: 20%; font-weight: bold">Cheque/Transfer Date</td>
        @If (String.IsNullOrEmpty(dr("ChqDate").ToString()) = False) Then
@<td style = "width:30%;" >@Convert.ToDateTime(dr("ChqDate")).ToString("dd/MM/yyyy")</td>
        Else
            @<td></td>
        End If
    </tr>
    <tr>
        <td style="width: 20%; font-weight: bold">Cheque/Transfer Bank.</td>
        <td style="width:30%;">@dr("RecvBank").ToString() / @dr("RecvBranch").ToString() </td>
        <td style="width:20%;font-weight:bold">Payer/Payee</td>
        <td style="width:30%;">@dr("PayChqTo").ToString() </td>
    </tr>
</table>
    End If        
</p>
@<table border="1" style="width:100%;border-collapse:collapse;border-width:thin;">
    <thead>
        <tr>
            <th>Code</th>
            <th>Description</th>
            <th>Debit</th>
            <th>Credit</th>
        </tr>
    </thead>
    <tbody>
        @If dt.Rows.Count > 0 Then
            Dim dr = dt.Rows(0)
            Dim sumPayment As Double = 0
            If dr("GLType").ToString().Equals("INV") Then
                Dim sumWht As Double = 0
                If Convert.ToDouble(dr("CashAmount")) > 0 Then
                    Convert.ToDouble(dr("CashAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("CashAmount"))
                End If
                If Convert.ToDouble(dr("ChqAmount")) > 0 Then
                    Convert.ToDouble(dr("ChqAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("ChqAmount"))
                End If
                If Convert.ToDouble(dr("CreditAmount")) > 0 Then
                    Convert.ToDouble(dr("CreditAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("CreditAmount"))
                End If
                @<tr>
                    <td>
                        @dr("CmpCode").ToString()
                    </td>
                    <td>
                        Cash-Received / @dr("VenderName").ToString()
                    </td>
                    <td style="text-align:right;">
                        @sumPayment.ToString("#,###,##0.0000")
                    </td>
                    <td>
                    </td>
                </tr>
                Dim totalPay As Double = 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(i)
                    totalPay += Convert.ToDouble(dr("PaidAmount"))
                    sumWht += Convert.ToDouble(dr("WHT"))
                    @<tr>
                        <td>
                            @dr("JobNo").ToString()
                        </td>
                        <td>
                            Account Receivables - @dr("DocRefNo").ToString() / @dr("SDescription").ToString()
                        </td>
                        <td style="text-align:right;">
                        </td>
                        <td style="text-align:right;">
                            @Convert.ToDouble(dr("PaidAmount")).ToString("#,###,##0.0000")
                        </td>
                    </tr>
                Next
                @If sumWht > 0 Then
                    @<tr>
                        <td>
                            @dr("CmpCode").ToString()
                        </td>
                        <td>
                            Withholding-Tax
                        </td>
                        <td style="text-align:right;">
                        </td>
                        <td style="text-align:right;">
                            @sumWht.ToString("#,###,##0.0000")
                        </td>
                    </tr>
                End If
                @<tr>
                    <td>TOTAL</td>
                    <td>
                    </td>
                    <td style="text-align:right">
                        @sumPayment.ToString("#,###,##0.0000")
                    </td>
                    <td style="text-align:right">
                        @Convert.ToDouble(sumWht + totalPay).ToString("#,###,##0.0000")
                    </td>
                </tr>
            End If
            If dr("GLType").ToString().Equals("PAY") Then
                If Convert.ToDouble(dr("CashAmount")) > 0 Then
                    Convert.ToDouble(dr("CashAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("CashAmount"))
                End If
                If Convert.ToDouble(dr("ChqAmount")) > 0 Then
                    Convert.ToDouble(dr("ChqAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("ChqAmount"))
                End If
                If Convert.ToDouble(dr("CreditAmount")) > 0 Then
                    Convert.ToDouble(dr("CreditAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("CreditAmount"))
                End If
                @<tr>
                    <td>
                        @dr("CmpCode").ToString()
                    </td>
                    <td>
                        Account Payables / @dr("VenderName").ToString()
                    </td>
                    <td style="text-align:right;">
                        @sumPayment.ToString("#,###,##0.0000")
                    </td>
                    <td>
                    </td>
                </tr>
                Dim totalPay = 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(i)
                    totalPay += Convert.ToDouble(dr("PaidAmount"))
                    @<tr>
                        <td>
                            @dr("JobNo").ToString()
                        </td>
                        <td>
                            Cash-Payment / @dr("SDescription").ToString()
                        </td>
                        <td style="text-align:right;">
                        </td>
                        <td style="text-align:right;">
                            @Convert.ToDouble(dr("PaidAmount")).ToString("#,###,##0.0000")
                        </td>
                    </tr>
                Next
                @<tr>
                    <td>TOTAL</td>
                    <td>
                    </td>
                    <td style="text-align:right">
                        @sumPayment.ToString("#,###,##0.0000")
                    </td>
                    <td style="text-align:right">
                        @totalPay.ToString("#,###,##0.0000")
                    </td>
                </tr>
            End If
            If dr("GLType").ToString().Equals("ADV") Then
                If Convert.ToDouble(dr("CashAmount")) > 0 Then
                    Convert.ToDouble(dr("CashAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("CashAmount"))
                End If
                If Convert.ToDouble(dr("ChqAmount")) > 0 Then
                    Convert.ToDouble(dr("ChqAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("ChqAmount"))
                End If
                If Convert.ToDouble(dr("CreditAmount")) > 0 Then
                    Convert.ToDouble(dr("CreditAmount")).ToString("#,###,##0.0000")
                    sumPayment = Convert.ToDouble(dr("CreditAmount"))
                End If
                @<tr>
                    <td>
                        @dr("CmpCode").ToString()
                    </td>
                    <td>
                        Advance-In-Process / @dr("EmpCode").ToString()
                    </td>
                    <td style="text-align:right;">
                        @sumPayment.ToString("#,###,##0.0000")
                    </td>
                    <td>
                    </td>
                </tr>
                Dim totalPay = 0
                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(i)
                    totalPay += Convert.ToDouble(dr("PaidAmount"))
                    @<tr>
                        <td>
                            @dr("JobNo").ToString()
                        </td>
                        <td>
                            Advance-Payment / @dr("SDescription").ToString()
                        </td>
                        <td style="text-align:right;">
                        </td>
                        <td style="text-align:right;">
                            @Convert.ToDouble(dr("PaidAmount")).ToString("#,###,##0.0000")
                        </td>
                    </tr>
                Next
                @<tr>
                    <td>TOTAL</td>
                    <td>
                    </td>
                    <td style="text-align:right">
                        @sumPayment.ToString("#,###,##0.0000")
                    </td>
                    <td style="text-align:right">
                        @totalPay.ToString("#,###,##0.0000")
                    </td>
                </tr>
            End If
        End If
    </tbody>
</table>
End If
<script type="text/javascript">
    let path = '@Url.Content("~")';
</script>