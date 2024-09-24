@Code
    Layout = "~/Views/Shared/_ReportNoHeadLandscape.vbhtml"
    ViewData("Title") = "TruckProfitDetail"
    Dim sqlFrom As String = "
from Job_LoadInfo lh inner join Job_LoadInfoDetail ld
on lh.BookingNo=ld.BookingNo and lh.BranchCode=ld.BranchCode
inner join Job_Order j on ld.JNo=j.JNo and ld.BranchCode=j.BranchCode
inner join Mas_Company c on c.Custcode=j.CustCode and c.Branch=j.CustBranch
inner join Mas_Vender v on j.AgentCode=v.VenCode
"
    Dim sqlWhere As String = ""
    If Not Request.QueryString("DateFrom") Is Nothing Then
        sqlWhere &= " AND j.DocDate>='" & Request.QueryString("DateFrom") & "'"
    End If
    If Not Request.QueryString("DateTo") Is Nothing Then
        sqlWhere &= " AND j.DocDate<='" & Request.QueryString("DateTo") & "'"
    End If
    If Not Request.QueryString("CustCode") Is Nothing Then
        sqlWhere &= " AND c.CustCode='" & Request.QueryString("CustCode") & "'"
    End If
    If Not Request.QueryString("VenCode") Is Nothing Then
        sqlWhere &= " AND v.VenCode='" & Request.QueryString("VenCode") & "'"
    End If
    If Not Request.QueryString("CSCode") Is Nothing Then
        sqlWhere &= " AND j.CSCode='" & Request.QueryString("CSCode") & "'"
    End If
    Dim sqlSource As String = "
select j.DocDate,j.JNo,c.NameEng as CustName,j.BookingNo,ld.CTN_NO,ld.Location as TransportRoute,ld.TruckNO,ld.Driver,v.TName as VenderName,
isnull(cl.TotalCost,0) as TotalCost{3},
isnull(cl.TotalAdv,0) as TotalAdv{4},
isnull(cl.TotalCharge,0) as TotalCharge{5},
isnull(cl.TotalCharge-cl.TotalCost,0) as Profit
" & sqlFrom & "
left join (
    select h.BranchCode,h.CTN_NO,d.JobNo,
    sum(case when s.IsExpense=1 then d.BNet else 0 end) as TotalCost,
    sum(case when s.IsExpense=0 And s.IsCredit=1 then d.BNet else 0 end) as TotalAdv,
    sum(case when s.IsExpense=0 And s.IsCredit=0 then d.BNet else 0 end) as TotalCharge
{0}{1}{2}
    from Job_ClearDetail d inner join Job_ClearHeader h
    on d.ClrNo=h.ClrNo and d.BranchCode=h.BranchCode
    inner join Job_SrvSingle s on d.SICode=s.SICode
    where h.DocStatus<>99
    group by h.BranchCode,h.CTN_NO,d.JobNo
) cl
on ld.JNo=cl.JobNo and ld.CTN_NO=cl.CTN_NO and ld.BranchCode=cl.BranchCode
WHERE j.JobStatus<> 99
"
    Dim sqlOrder As String = "ORDER BY j.DocDate,j.JNo"
    Dim sqlDetail As String = sqlFrom & "
inner join Job_ClearDetail d 
on d.JobNo=j.JNo and d.BranchCode=j.BranchCode 
inner join Job_ClearHeader h
on d.ClrNo=h.ClrNo and d.BranchCode=h.BranchCode
and ld.CTN_NO=h.CTN_NO
inner join Job_SrvSingle s on d.SICode=s.SICode
WHERE j.JobStatus<> 99 AND h.DocStatus<>99
"
    Dim sqlSub As String = " SELECT distinct s.SICode,s.NameEng as SDescription,s.IsExpense,s.IsCredit " & sqlDetail & sqlWhere & " ORDER BY s.SICode"

    Dim bLogin As Boolean = False
    Dim dt As New Data.DataTable
    Dim dh As New Data.DataTable
    Dim sql As String = sqlSource & sqlWhere
    Dim arrCost As New List(Of String)
    Dim arrAdv As New List(Of String)
    Dim arrServ As New List(Of String)

    If ViewBag.User <> "" Then
        bLogin = True
        dh = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sqlSub)
        Dim sqlCost As String = ""
        Dim sqlAdv As String = ""
        Dim sqlService As String = ""
        Dim listCost As String = ""
        Dim listAdv As String = ""
        Dim listService As String = ""
        If dh.Rows.Count > 0 Then
            For Each dr As Data.DataRow In dh.Rows
                If dr("IsExpense").ToString().Equals("1") Then
                    sqlCost &= ",SUM(CASE WHEN d.SICode='" & dr("SICode").ToString() & "' THEN d.BNet ELSE 0 END) as [" & dr("SICode") & "]"
                    listCost &= ",isnull(cl.[" & dr("SICode") & "],0) as [" & dr("SICode") & "]"
                    arrCost.Add(dr("SICode") & "|" & dr("SDescription"))
                ElseIf dr("IsCredit").ToString().Equals("1") Then
                    sqlAdv &= ",SUM(CASE WHEN d.SICode='" & dr("SICode").ToString() & "' THEN d.BNet ELSE 0 END) as [" & dr("SICode") & "]"
                    listAdv &= ",isnull(cl.[" & dr("SICode") & "],0) as [" & dr("SICode") & "]"
                    arrAdv.Add(dr("SICode") & "|" & dr("SDescription"))
                Else
                    sqlService &= ",SUM(CASE WHEN d.SICode='" & dr("SICode").ToString() & "' THEN d.BNet ELSE 0 END) as [" & dr("SICode") & "]"
                    listService &= ",isnull(cl.[" & dr("SICode") & "],0) as [" & dr("SICode") & "]"
                    arrServ.Add(dr("SICode") & "|" & dr("SDescription"))
                End If
            Next
        End If
        sql = String.Format(sql, sqlCost, sqlAdv, sqlService, listCost, listAdv, listService) & sqlOrder
        dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(sql)
    End If
End Code
<style>

    table {
        font-size: 10px;
        page-break-inside: avoid;
    }

    tr {
        page-break-inside: avoid;
        page-break-after: auto;
    }

    td {
        overflow: hidden;
    }
</style>

@If bLogin Then
    @<span><label ondblclick="ExportData()">Cost and Profit Report By Truck</label></span>
    @If dt.Rows.Count > 0 Then
        @<table id="tbSource" border="1" style="border-width:thin;border-collapse:collapse;">
            <thead>
                <tr>
                    <th rowspan="2">Job Date</th>
                    <th rowspan="2">Job No</th>
                    <th rowspan="2">Customer</th>
                    <th rowspan="2">Booking</th>
                    <th rowspan="2">Container</th>
                    <th rowspan="2">Route</th>
                    <th rowspan="2">Truck</th>
                    <th rowspan="2">Driver</th>
                    <th rowspan="2">Vender</th>
                    <th colspan="@arrCost.Count">Cost</th>
                    <th rowspan="2">Total Cost</th>
                    <th colspan="@arrAdv.Count">Advance</th>
                    <th rowspan="2">Total Advance</th>
                    <th colspan="@arrServ.Count">Transport</th>
                    <th rowspan="2">Total Transport</th>
                    <th rowspan="2">Profit</th>
                </tr>
                <tr>
                    @For Each str As String In arrCost
                        @<th>@str.Split("|")(0)<br>@str.Split("|")(1)</th>
                    Next
                    @For Each str As String In arrAdv
                        @<th>@str.Split("|")(0)<br>@str.Split("|")(1)</th>
                    Next
                    @For Each str As String In arrServ
                        @<th>@str.Split("|")(0)<br>@str.Split("|")(1)</th>
                    Next
                </tr>
            </thead>
            <tbody id="tbResult">
                @For Each dr As Data.DataRow In dt.Rows
                    @<tr>
    <td>@Convert.ToDateTime(dr("DocDate")).ToString("dd/MM/yyyy")</td>
    <td>@dr("JNo").ToString()</td>
    <td>@dr("CustName").ToString()</td>
    <td>@dr("BookingNo").ToString()</td>
    <td>@dr("CTN_NO").ToString()</td>
    <td>@dr("TransportRoute").ToString()</td>
    <td>@dr("TruckNO").ToString()</td>
    <td>@dr("Driver").ToString()</td>
    <td>@dr("VenderName").ToString()</td>
    @For Each str As String In arrCost
        @<td style="text-align:right">@Convert.ToDouble(dr(str.Split("|")(0))).ToString("#,##0.00")</td>
    Next
    <td style="text-align:right">@Convert.ToDouble(dr("TotalCost")).ToString("#,##0.00")</td>
    @For Each str As String In arrAdv
        @<td style="text-align:right">@Convert.ToDouble(dr(str.Split("|")(0))).ToString("#,##0.00")</td>
    Next
    <td style="text-align:right">@Convert.ToDouble(dr("TotalAdv")).ToString("#,##0.00")</td>
    @For Each str As String In arrServ
        @<td style="text-align:right">@Convert.ToDouble(dr(str.Split("|")(0))).ToString("#,##0.00")</td>
    Next
    <td style="text-align:right">@Convert.ToDouble(dr("TotalCharge")).ToString("#,##0.00")</td>
    <td style="text-align:right">@Convert.ToDouble(dr("Profit")).ToString("#,##0.00")</td>
</tr>
                Next
            </tbody>
        </table>
    End If
End If
