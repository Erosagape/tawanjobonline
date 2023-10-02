@Code
    ViewBag.Title = "Trial Balance"
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
    Dim sqlQry = String.Format("EXEC dbo.GetGL_Summary '{0}','{1}'", beginDate, endDate)
End Code
<style>
    th {
        text-align:center;
        vertical-align:middle;
    }
</style>
<div class="container">
    @If bLogin Then
        @<div Class="row">
            <div Class="col-sm-3">
                From Date
                <br />
                <input type="date" id="txtDateFrom" Class="form-control" value="@beginDate" />
            </div>
            <div Class="col-sm-3">
                To Date
                <br />
                <input type="date" id="txtDateTo" Class="form-control" value="@endDate" />
            </div>
            <div class="col-sm-3">
                <br />
                <input type="button" Class="btn btn-success" value="Show" onclick="RefreshData()" />
            </div>
        </div>
        @<div class="row">
             <div class="col-sm-3">
                 <input type="button" Class="btn btn-primary" value="View By Work flow" onclick="ShowByTransType()" />
             </div>
        </div>
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
                                    <th rowspan="2">Account Code</th>
                                    <th rowspan="2">Account Name</th>
                                    <th colspan="2">Previous Balance</th>
                                    <th colspan="2">Current Balance</th>
                                    <th colspan="2">Forward Balance</th>
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
                                @For Each dr As System.Data.DataRow In oData.Rows
                                    colCount = 0
                                    @If not (dr("TotalCurrentDebit") > 0 Or dr("TotalCurrentCredit") > 0) Then
                                        @<tr style="background-color:lightyellow;">
                                            @For each dc As System.Data.DataColumn In oData.Columns
                                                colCount += 1
                                                If colCount > 2 Then
                                                    @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.00")</td>
                                                Else
                                                    If dc.ColumnName.Equals("AccName") Then
                                                        @<td>
                                                            @dr(dc.ColumnName)                                  
                                                        </td>
                                                    Else
                                                        @<td>@dr(dc.ColumnName)</td>
                                                    End If

                                                End If
                                            Next
                                        </tr>
                                    Else
                                        sumDebit += Convert.ToDouble(dr("TotalCurrentDebit"))
                                        sumCredit += Convert.ToDouble(dr("TotalCurrentCredit"))
                                        @<tr>
                                            @For each dc As System.Data.DataColumn In oData.Columns
                                                colCount += 1
                                                If colCount > 2 Then
                                                    @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.00")</td>
                                                Else
                                                    If dc.ColumnName.Equals("AccName") Then
                                                        @<td>
                                                            @dr(dc.ColumnName)
                                                            @If dr("TotalCurrentDebit") > 0 Or dr("TotalCurrentCredit") > 0 Then
                                                                @<a href="#" onclick="ShowDetail('@dr("AccCode")')">Details</a>
                                                            End If
                                                        </td>
                                                    Else
                                                        @<td>@dr(dc.ColumnName)</td>
                                                    End If

                                                End If
                                            Next
                                        </tr>

                                    End If
                                Next
                            </tbody>
                            <tfoot style="background-color:lightgreen;font-weight:bold">
                                <tr>
                                    <td colspan="4"></td>
                                    <td style="text-align:right;">@sumDebit.ToString("#,##0.00#")</td>
                                    <td style="text-align:right;">@sumCredit.ToString("#,##0.00#")</td>
                                    <td colspan="2"></td>
                                </tr>
                            </tfoot>
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
    function RefreshData() {
        window.location.href = path + 'Tracking/Dashboard?Form=7&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val();
    }
    function ShowDetail(acccode) {
        window.location.href = path + 'Tracking/Dashboard?Form=SubTB&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val() + '&Code='+acccode;
    }
    function ShowByTransType() {
        window.location.href = path + 'Tracking/Dashboard?Form=6&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val();
    }
</script>