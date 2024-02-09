@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
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
    body {
        font-size: 11px;
    }
</style>
@If sqlQry <> "" Then
    Dim oData = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlQry)
    If oData.Rows.Count > 0 Then
        Dim balance As Double = 0
        Dim sumDebit As Double = 0
        Dim sumCredit As Double = 0
        Dim balSide = ""
        @<div style="width:100%;text-align:center;">
    @ViewBag.PROFILE_COMPANY_NAME<br />
    รายงานบัญชีแยกประเภททั่วไป<br />
    ระหว่างวันที่ @Convert.ToDateTime(beginDate).ToString("dd/MM/yyyy") ถึงวันที่ @Convert.ToDateTime(endDate).ToString("dd/MM/yyyy")
    <br />
    เลขที่บัญชี @oData.Rows(0)("AccCode") : @oData.Rows(0)("AccName")
</div>
    @<table style="width:100%;">
        <thead>
            <tr>
                <th>Type</th>
                <th>Date</th>
                <th>Description</th>
                <th>Debit</th>
                <th>Credit</th>
                <th>Balance</th>
            </tr>
        </thead>
        <tbody>
            @For each dr As System.Data.DataRow In oData.Rows
                If dr("AccGroup").ToString() = "BAL" Then
                    balance = Convert.ToDouble(dr("Debit")) + Convert.ToDouble(dr("Credit"))
                    @<tr>
                        @If dr("Debit") > 0 Then
                            balSide = "D"
                            @<td>@dr("AccGroup").ToString()</td>
                            @<td></td>
                            @<td>ยอดคงเหลือยกมา</td>
                            @<td style="text-align:right">@Convert.ToDouble(dr("Debit")).ToString("#,##0.00")</td>
                            @<td></td>
                            @<td style="text-align:right">@balance.ToString("#,##0.00")</td>
                        Else
                            balSide = "C"
                            @<td>@dr("AccGroup").ToString()</td>
                            @<td></td>
                            @<td>ยอดคงเหลือยกมา</td>
                            @<td></td>
                            @<td style="text-align:right">@Convert.ToDouble(dr("Credit")).ToString("#,##0.00")</td>
                            @<td style="text-align:right">@balance.ToString("#,##0.00")</td>
                        End If
                    </tr>

                Else
                    sumCredit += Convert.ToDouble(dr("Credit"))
                    sumDebit += Convert.ToDouble(dr("Debit"))
                    If balSide = "D" Then
                        If dr("Debit") > 0 Then
                            balance += Convert.ToDouble(dr("Debit"))
                        End If
                        If dr("Credit") > 0 Then
                            balance -= Convert.ToDouble(dr("Credit"))
                        End If
                    Else
                        If dr("Debit") > 0 Then
                            balance -= Convert.ToDouble(dr("Debit"))
                        End If
                        If dr("Credit") > 0 Then
                            balance += Convert.ToDouble(dr("Credit"))
                        End If
                    End If
                    @<tr>
                        @If dr("Debit") > 0 Then
                            @<td>@dr("AccGroup").ToString()</td>
                            @<td>@dr("DocDateDebit")</td>
                            @<td>@dr("DocNoDebit").ToString()</td>
                            @<td style="text-align:right">@Convert.ToDouble(dr("Debit")).ToString("#,##0.00")</td>
                            @<td></td>
                            @<td style="text-align:right">@balance.ToString("#,##0.00")</td>
                        Else
                            @<td>@dr("AccGroup").ToString()</td>
                            @<td>@dr("DocDateCredit")</td>
                            @<td>@dr("DocNoCredit").ToString()</td>
                            @<td></td>
                            @<td style="text-align:right">@Convert.ToDouble(dr("Credit")).ToString("#,##0.00")</td>
                            @<td style="text-align:right">@balance.ToString("#,##0.00")</td>
                        End If
                    </tr>

                End If
            Next
        </tbody>
    </table>
    End If
End If
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>
