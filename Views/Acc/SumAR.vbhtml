@Code
    Dim sqlARWhere = ""
    Dim cutoffDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        cutoffDate = Request.QueryString("BeginDate")
    End If
    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
        sqlARWhere &= String.Format(" AND i.DocDate>='{0}'", endDate)
    End If
    Dim sqlARSet = "
SELECT CONCAT(i.BillToCustCode,'-',c.NameThai) as CustTName,i.DocDate,i.DocNo,
i.RefNo,i.TotalNET,i.TotalVAT,i.Total50Tavi,i.BillToCustCode,i.BillToCustBranch,
b.BillAcceptNo,b.BillDate,b.BillRecvDate,b.DuePaymentDate,
i.TotalAdvance,i.TotalCharge,d.TotalService,d.TotalTaxService,
d.TotalTransport,d.TotalTaxTransport,d.TotalNonTax
from Job_InvoiceHeader i left join Mas_Company c
on CONCAT(i.BillToCustCode,i.BillToCustBranch)=CONCAT(c.CustCode,c.Branch)
left join Job_BillAcceptHeader b
on CONCAT(i.BranchCode,i.BillAcceptNo)=CONCAT(b.BranchCode,b.BillAcceptNo)
inner join (
select BranchCode,DocNo,
SUM(CASE WHEN AmtCharge>0 AND Rate50Tavi=1 THEN AmtCharge ELSE 0 END) as TotalTransport,
SUM(CASE WHEN AmtCharge>0 AND Rate50Tavi>1 THEN AmtCharge ELSE 0 END) as TotalService,
SUM(CASE WHEN AmtCharge>0 AND VATRate=0 AND Rate50Tavi=0 THEN AmtCharge ELSE 0 END) as TotalNonTax,
SUM(CASE WHEN AmtCharge>0 AND Rate50Tavi=1 THEN Amt50Tavi ELSE 0 END) as TotalTaxTransport,
SUM(CASE WHEN AmtCharge>0 AND Rate50Tavi>1 THEN Amt50Tavi ELSE 0 END) as TotalTaxService
from Job_InvoiceDetail
group by BranchCode,DocNo
) d
on CONCAt(i.BranchCode,i.DocNo)=CONCAT(d.BranchCode,d.DocNo)
left join (
select h.BranchCode,d.InvoiceNo,
sum(d.Net) as ReceiptNet,sum(d.Amt50Tavi) as ReceiptWHT
from Job_ReceiptHeader h inner join Job_ReceiptDetail d
on CONCAT(h.BranchCode,h.ReceiptNo)=CONCAT(d.BranchCode,d.ReceiptNo)
inner join Job_CashControl v
on CONCAT(d.BranchCode,d.ControlNo)=CONCAT(v.BranchCode,v.ControlNo)
where not isnull(h.CancelProve,'')<>'' and not isnull(v.CancelProve,'')<>''
group by h.BranchCode,d.InvoiceNo
) rd
on CONCAt(i.BranchCode,i.DocNo)=CONCAT(rd.BranchCode,rd.InvoiceNo)
where not isnull(i.CancelProve,'')<>'' " & sqlARWhere & "
ORDER BY i.DocDate,i.BillToCustCode
"
    Dim oARSet = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlARSet)
End Code
<h3>Account Receivables</h3>  (@cutoffDate - @endDate)
<div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>Inv.No</th>
                <th>Inv.Date</th>
                <th>Ref No</th>
                <th>
                    Advance
                </th>
                <th>
                    Transport
                </th>
                <th>
                    WHD 1%
                </th>
                <th>
                    Service
                </th>
                <th>
                    VAT
                </th>
                <th>
                    WHD 3%
                </th>
                <th>
                    Non-Vat
                </th>
            </tr>
        </thead>
        <tbody>
            @Code
                Dim totaladvBF = 0
                Dim totaltranBF = 0
                Dim totaltrantaxBF = 0
                Dim totalservBF = 0
                Dim totalservtaxBF = 0
                Dim totalnonvatBF = 0
                Dim totalvatBF = 0
                Dim isShowTotal = False
                For Each dr In oARSet.Rows
                    If Convert.ToDateTime(dr("DocDate")).ToString("yyyy-MM-dd") <= cutoffDate Then
                        totaladvBF += dr("TotalAdvance")
                        totaltranBF += dr("TotalTransport")
                        totaltrantaxBF += dr("TotalTaxTransport")
                        totalservBF += dr("TotalService")
                        totalservtaxBF += dr("TotalTaxService")
                        totalnonvatBF += dr("TotalNonTax")
                        totalvatBF += dr("TotalVAT")
                    Else
                        If Not isShowTotal Then
                            @<tr>
                                <td colspan="3">Balance</td>
                                <td>@totaladvBF.ToString("#,##0.00")</td>
                                <td>@totaltranBF.ToString("#,##0.00")</td>
                                <td>@totaltrantaxBF.ToString("#,##0.00")</td>
                                <td>@totalservBF.ToString("#,##0.00")</td>
                                <td>@totalvatBF.ToString("#,##0.00")</td>
                                <td>@totalservtaxBF.ToString("#,##0.00")</td>
                                <td>@totalnonvatBF.ToString("#,##0.00")</td>
                            </tr>
                            isShowTotal = True
                        End If
                        @<tr>
                            <td colspan="3">Balance</td>
                            <td>@Convert.ToDouble(dr("TotalAdvance")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("TotalTransport")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("TotalTaxTransport")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("TotalService")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("TotalVAT")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("TotalTaxService")).ToString("#,##0.00")</td>
                            <td>@Convert.ToDouble(dr("TotalNonTax")).ToString("#,##0.00")</td>
                        </tr>
                    End If
                Next
            End Code
        </tbody>
    </table>
</div>


