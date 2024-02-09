@Code
    ViewBag.Title = "Trial Balance By Transaction Type"
    Dim bLogin = False
    If ViewBag.User <> "" Then
        bLogin = True
    End If

    Dim beginDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        beginDate = Request.QueryString("BeginDate")
    End If
    ViewBag.BeginDate = beginDate

    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
    End If
    ViewBag.EndDate = endDate
    Dim transType = ""
    If Request.QueryString("Type") IsNot Nothing Then
        transType = Request.QueryString("Type")
    End If
    Dim acccode = ""
    If Request.QueryString("Code") IsNot Nothing Then
        acccode = Request.QueryString("Code")
    End If
    Dim sqlQry = ""
    If transType <> "" Then
        Select Case transType
            Case "ADVR", "ADVC", "ADVP", "CLRA"
                sqlQry = String.Format("EXEC dbo.GetGL_AdvanceDetail '{0}','{1}','{2}','{3}'", beginDate, endDate, transType, acccode)
            Case "SETP", "CANP", "PAYP"
                sqlQry = String.Format("EXEC dbo.GetGL_PayablesDetail '{0}','{1}','{2}','{3}'", beginDate, endDate, transType, acccode)
            Case Else
                sqlQry = String.Format("EXEC dbo.GetGL_ReceivablesDetail '{0}','{1}','{2}','{3}'", beginDate, endDate, transType, acccode)
        End Select
    End If
End Code
<style>
    th {
        text-align: center;
        vertical-align: middle;
    }
</style>
<div class="container">
    @If bLogin Then
        If sqlQry <> "" Then
            Dim oData = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlQry)
            If oData.Rows.Count > 0 Then
                Dim colCount = 0
                Dim sumDebit As Double = 0
                Dim sumCredit As Double = 0
        @<b>Total Rows=@oData.Rows.Count</b>
        @<div class="panel">
            <b>@oData.Rows(0)("AccCode") / @oData.Rows(0)("AccName")</b>
            <div class="table-responsive">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Ref No</th>
                            <th>Date</th>
                            <th>Group</th>
                            <th>Account Code</th>
                            <th>Account Name</th>
                            <th>Debit</th>
                            <th>Credit</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each dr As System.Data.DataRow In oData.Rows
                            colCount = 0
                            @<tr>
                                @For each dc As System.Data.DataColumn In oData.Columns
                                    colCount += 1
                                    If dc.ColumnName.Equals("DocDate") Then
                                        @<td>@Convert.ToDateTime(dr(dc.ColumnName)).ToString("dd/MM/yyyy")</td>
                                    ElseIf dc.ColumnName.Equals("Debit") Or dc.ColumnName.Equals("Credit") Then
                                        @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.00")</td>
                                    Else
                                        @<td>@dr(dc.ColumnName)</td>
                                    End If

                                Next
                            </tr>
                            sumDebit += Convert.ToDouble(dr("Debit"))
                            sumCredit += Convert.ToDouble(dr("Credit"))
                        Next
                    </tbody>
                    @If colCount > 0 Then
                        colCount = colCount - 2
                        @<tfoot style="background-color:lightgreen;font-weight:bold;">
                            <tr>
                                <td>
                                    Total
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td style="text-align:right;">@sumDebit.ToString("#,##0.00")</td>
                                <td style="text-align:right;">@sumCredit.ToString("#,##0.00")</td>
                            </tr>
                        </tfoot>
                    End If
                </table>
            </div>
        </div>
    End If
Else
    @<p>
        No data to show
    </p>
End If
Else
@<p>
    Please Login First
</p>
End If
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    $('td:nth-child(4),th:nth-child(4)').hide();
    $('td:nth-child(5),th:nth-child(5)').hide();
</script>