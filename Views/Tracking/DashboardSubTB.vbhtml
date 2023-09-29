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
<div class="container">
    @If bLogin Then
        If sqlQry <> "" Then
            Dim oData = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlQry)
            If oData.Rows.Count > 0 Then
                Dim colCount = 0
                Dim sumDebit = 0
                Dim sumCredit = 0
                @<div class="panel">
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    @For each dc As System.Data.DataColumn In oData.Columns
                                        @<th>@dc.ColumnName</th>
                                    Next
                                </tr>
                            </thead>
                            <tbody>
                                @For Each dr As System.Data.DataRow In oData.Rows
                                    colCount = 0
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
                                Next
                            </tbody>
                            @If colCount > 0 Then
                                colCount = colCount - 2
                                @<tfoot>
                                    <tr>
                                        <td colspan="5">
                                            Total Debit
                                        </td>
                                        <td style="text-align:right;">@sumDebit.ToString("#,##0.00")</td>
                                        <td colspan="2">Total Credit</td>
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
</script>
