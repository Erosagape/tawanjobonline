@Code
    ViewBag.Title = "General Leader"
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
    Dim acccode = ""
    If Request.QueryString("Code") IsNot Nothing Then
        acccode = Request.QueryString("Code")
    End If
    Dim sqlQry = String.Format("EXEC dbo.GetGL_Detail '{0}','{1}','{2}'", beginDate, endDate, acccode)
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
                Dim sumPrevDebit As Double = 0
                Dim sumPrevCredit As Double = 0
                @<div class="panel">                
                <div class="table-responsive">
                    <table class="table table-bordered" id="tbData">
                        <thead>
                            <tr>
                                <th></th>
                                <th></th>
                                <th colspan="8">@oData.Rows(0)("AccCode").ToString() /  @oData.Rows(0)("AccName").ToString()</th>
                            </tr>
                            <tr>
                                <th>Account Code</th>
                                <th>Account Name</th>
                                <th>Description</th>
                                <th>Date</th>
                                <th>Ref#</th>
                                <th>Debit</th>
                                <th>Date</th>
                                <th>Ref#</th>
                                <th>Credit</th>
                                <th>Group</th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each dr As System.Data.DataRow In oData.Rows
                                colCount = 0
                                If dr("AccGroup").ToString().Equals("BAL") Then
                                    sumPrevDebit += Convert.ToDouble(dr("Debit"))
                                    sumPrevCredit += Convert.ToDouble(dr("Credit"))
                                    @<tr style="background-color:lightyellow;font-weight:bold">
                                        @For each dc As System.Data.DataColumn In oData.Columns
                                            colCount += 1
                                            If dc.ColumnName.Equals("Debit") Or dc.ColumnName.Equals("Credit") Then
                                                @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.00")</td>
                                            Else
                                                @<td>@dr(dc.ColumnName)</td>
                                            End If

                                        Next
                                    </tr>
                                Else
                                    @<tr>
                                        @For each dc As System.Data.DataColumn In oData.Columns
                                            colCount += 1
                                            If dc.ColumnName.Equals("Debit") Or dc.ColumnName.Equals("Credit") Then
                                                @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.00")</td>
                                            Else
                                                @<td>@dr(dc.ColumnName)</td>
                                            End If

                                        Next
                                    </tr>
                                    sumDebit += Convert.ToDouble(dr("Debit"))
                                    sumCredit += Convert.ToDouble(dr("Credit"))
                                End If
                            Next
                        </tbody>
                        @If colCount > 0 Then
                            colCount = colCount - 2
                            Dim totalDebit As Double = sumDebit + sumPrevDebit
                            Dim totalCredit As Double = sumCredit + sumPrevCredit
                            Dim totalChange As Double = sumDebit - sumCredit
                            @<tfoot>
                                <tr style="background-color:lightblue;font-weight:bold;">
                                    <td></td>
                                    <td></td>
                                    <td colspan="3">
                                        Current Debit
                                    </td>
                                    <td style="text-align:right;">@sumDebit.ToString("#,##0.00")</td>
                                    <td colspan="2">Current Credit</td>
                                    <td style="text-align:right;">@sumCredit.ToString("#,##0.00")</td>
                                    <td></td>
                                </tr>
                                <tr style="background-color:lightgreen;font-weight:bold;">
                                    <td></td>
                                    <td></td>
                                    <td colspan="3">
                                        Total Debit
                                    </td>
                                    @If (totalChange > 0) Then
                                        @<td style="text-align:right;">@totalChange.ToString("#,##0.00")</td>
                                        @<td colspan="2">Total Credit</td>
                                        @<td style="text-align:right;"></td>
                                        @<td></td>

                                    Else
                                        @<td style="text-align:right;"></td>
                                        @<td colspan="2">Total Credit</td>
                                        @<td style="text-align:right;">@Math.Abs(totalChange).ToString("#,##0.00")</td>
                                        @<td></td>

                                    End If
                                </tr>
                                <tr style="font-weight:bold;">
                                    <td></td>
                                    <td></td>
                                    <td colspan="3">
                                        Forward Balance
                                    </td>
                                    @If (totalDebit - totalCredit > 0) Then
                                        Dim bal As Double = totalDebit - totalCredit
                                        @<td style="text-align:right;">@bal.ToString("#,##0.00")</td>
                                        @<td colspan="2"></td>
                                        @<td style="text-align:right;"></td>
                                        @<td></td>
                                    Else
                                        Dim bal As Double = totalCredit - totalDebit
                                        @<td style="text-align:right;"></td>
                                        @<td colspan="2"></td>
                                        @<td style="text-align:right;">@bal.ToString("#,##0.00")</td>
                                        @<td></td>
                                    End If
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
    $('td:nth-child(1),th:nth-child(1)').hide();
    $('td:nth-child(2),th:nth-child(2)').hide();
</script>
