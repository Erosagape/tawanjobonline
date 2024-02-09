
@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
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
    body {
        font-size: 11px;
    }
</style>
<div style="width:100%;text-align:center">
    @ViewBag.PROFILE_COMPANY_NAME<br />
    งบทดลอง<br/>
    ระหว่างวันที่ @Convert.ToDateTime(beginDate).ToString("dd/MM/yyyy") ถึงวันที่ @Convert.ToDateTime(endDate).ToString("dd/MM/yyyy") 
</div>
@If sqlQry <> "" Then
    Dim oData = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlQry)
    If oData.Rows.Count > 0 Then
        Dim colCount = 0
        Dim sumDebit = 0
        Dim sumCredit = 0
        @<table style="width:100%;">
        <thead>
        <tr>
            <th>Account Code</th>
            <th>Account Name</th>
            <th>Debit</th>
            <th>Credit</th>
        </tr>
        </thead>
        <tbody>
            @For Each dr As System.Data.DataRow In oData.Rows
                sumDebit += Convert.ToDouble(dr("TotalCurrentDebit"))
                sumCredit += Convert.ToDouble(dr("TotalCurrentCredit"))
                @<tr>
                    <td>@dr("AccCode").ToString()</td>
                    <td>@dr("AccName").ToString()</td>
                    <td style="text-align:right;">@Convert.ToDouble(dr("TotalCurrentDebit")).ToString("#,##0.00#")</td>
                    <td style="text-align:right;">@Convert.ToDouble(dr("TotalCurrentCredit")).ToString("#,##0.00#")</td>
                </tr>
            Next
        </tbody>
        <tfoot>
        <tr>
            <td colspan = "2" ></td>
            <td style = "text-align:right;text-decoration:underline;" >@sumDebit.ToString("#,##0.00#")</td>
            <td style="text-align:right;text-decoration:underline;">@sumCredit.ToString("#,##0.00#")</td>
        </tr>
        </tfoot>
        </table>   
    End If
Else
@<p>
No data to show
</p>
End If
<script type="text/javascript">
    const path = '@Url.Content("~")';
</script>