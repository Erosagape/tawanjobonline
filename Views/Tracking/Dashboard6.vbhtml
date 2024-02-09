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
    Dim sqlQry = ""
    If transType <> "" Then
        Select Case transType
            Case "ADVR", "ADVC", "ADVP", "CLRA"
                sqlQry = String.Format("EXEC dbo.GetGL_AdvanceCal '{0}','{1}','{2}'", beginDate, endDate, transType)
            Case "SETP", "CANP", "PAYP", "CLRE", "CLRC", "CLRP"
                sqlQry = String.Format("EXEC dbo.GetGL_PayablesCal '{0}','{1}','{2}'", beginDate, endDate, transType)
            Case "SETI", "CANI", "RCPT", "RCVI", "CDNI", "CDNC"
                sqlQry = String.Format("EXEC dbo.GetGL_ReceivablesCal '{0}','{1}','{2}'", beginDate, endDate, transType)
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
        Dim oAccType = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL("SELECT * FROM Mas_Config WHERE ConfigCode='ACC_TRANS' ORDER BY ConfigValue")
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
            <div Class="col-sm-6">
                Transaction Type
                <br />
                <select id="cboTransType" class="form-control dropdown">
                    @If oAccType.Rows.Count > 0 Then
                        For Each dr As System.Data.DataRow In oAccType.Rows
                            If transType.Equals(dr("ConfigKey").ToString()) Then
                                @<option value="@dr("ConfigKey")" selected>
                                    @dr("ConfigValue").ToString()
                                </option>
                            Else
                                @<option value="@dr("ConfigKey")">
                                    @dr("ConfigValue").ToString() (@dr("ConfigKey").ToString())
                                </option>
                            End If
                        Next
                    End If
                </select>
            </div>
        </div>
        @<div class="row">
            <div class="col-sm-3">
                <input type="button" Class="btn btn-primary" value="Search" onclick="RefreshData()" />
            </div>
        </div>
        @If sqlQry <> "" Then
            Dim oData = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlQry)
            If oData.Rows.Count > 0 Then
                Dim colCount = 0
                Dim sumCredit As Double = 0
                Dim sumDebit As Double = 0
                @<div class="panel">
                     <div class="table-responsive">
                         <table class="table table-bordered">
                             <thead>
                                 <tr>
                                     <th rowspan="2">Type</th>
                                     <th rowspan="2">Account Code</th>
                                     <th rowspan="2">Account Name</th>
                                     <th colspan="2">Previous Balance</th>
                                     <th colspan="2">Current Balance</th>
                                 </tr>
                                 <tr>
                                     <th>Debit</th>
                                     <th>Credit</th>
                                     <th>Debit</th>
                                     <th>Credit</th>
                                 </tr>
                             </thead>
                             <tbody>
                                 @For Each dr As System.Data.DataRow In oData.Rows
                                     colCount = 0
                                     sumDebit += Convert.ToDouble(dr(5))
                                     sumCredit += Convert.ToDouble(dr(6))
                                    @<tr>
                                        @For each dc As System.Data.DataColumn In oData.Columns
                                            colCount += 1
                                            If colCount > 3 Then
                                                @<td style="text-align:right">@Convert.ToDouble(dr(dc.ColumnName)).ToString("#,##0.00")</td>
                                            Else
                                                If dc.ColumnName.Equals("AccName") Then
                                                    @<td>
                                                        @dr(dc.ColumnName)
                                                        @If dr(5) > 0 Or dr(6) > 0 Then
                                                            @<a href="#" onclick="ShowData('@dr("AccCode").ToString()')">Details</a>
                                                        End If
                                                    </td>
                                                Else
                                                    @<td>@dr(dc.ColumnName)</td>
                                                End If

                                            End If
                                        Next
                                    </tr>
                                 Next
                             </tbody>              
                             <tfoot style="background-color:lightgreen;font-weight:bold;">
                                 <tr>
                                     <td colspan="3">Total</td>
                                     <td></td>
                                     <td></td>
                                     <td style="text-align:right">@sumDebit.ToString("#,##0.00#")</td>
                                     <td style="text-align:right">@sumCredit.ToString("#,##0.00#")</td>
                                 </tr>
                             </tfoot>
                         </table>
                     </div>
                </div>
            End If
        End If
    Else
        @<p>Please login first</p>
    End If
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    function RefreshData() {
        window.location.href = path + 'Tracking/Dashboard?Form=6&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val() +'&Type=' + $('#cboTransType').val();
    }
    function ShowData(code) {
        window.location.href = path + 'Tracking/Dashboard?Form=SubGL&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val() + '&Type=' + $('#cboTransType').val() + '&Code='+code;
    }
</script>