@Code
    ViewData("Title") = "Shipment"
    Dim oJob As List(Of CJobOrder) = ViewBag.DataSource
    If Request.QueryString("Branch") IsNot Nothing Then
        oJob = oJob.Where(Function(e) e.BranchCode.Equals(Request.QueryString("Branch"))).ToList
    End If
    If Request.QueryString("Job") IsNot Nothing Then
        oJob = oJob.Where(Function(e) e.JNo.Equals(Request.QueryString("Job"))).ToList
    End If
    Dim oJobType = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='JOB_TYPE'")
    Dim oShipBy = New CConfig(ViewBag.JobConn).GetData(" WHERE ConfigCode='SHIP_BY'")
End Code
<h2>Total @oJob.Count Job(s)<br /></h2>
<div class="container">
    @Code
        For Each jt In oJobType
            Dim oJobFilter = oJob.Where(Function(e) e.JobType.ToString("00").Equals(jt.ConfigKey)).ToList()
            If oJobFilter.Count > 0 Then
                Dim oShipByList = (From j In oJobFilter
                                   Select j.ShipBy).Distinct()
                @<p>
    @For Each sb In oShipByList
        Dim sbData = oShipBy.FirstOrDefault(Function(e) e.ConfigKey.Equals(sb.ToString("00")))
        If String.IsNullOrEmpty(sbData.ConfigValue) = False Then
            Dim oJobList = oJobFilter.Where(Function(e) e.ShipBy.Equals(sb)).ToList()
            @<b>@jt.ConfigValue / @sbData.ConfigValue</b> @<span>Total @oJobList.Count Job(s)</span>
            @<table class="table">
                <thead>
                    <tr>
                        <th>Ref</th>
                        <th>PO</th>
                        <th>CI</th>
                        <th>DECL</th>
                        <th>ETA</th>
                        <th>COMMODITY</th>
                        <th>VOL</th>
                    </tr>
                </thead>
                <tbody>
                    @For each row In oJobList
                        @<tr>
                            <td>@row.JNo</td>
                            <td>@row.CustRefNO</td>
                            <td>@row.InvNo</td>
                            <td>@row.DeclareNumber</td>
                            <td>@row.ETADate.ToString("dd/MM/yyyy")</td>
                            <td>@row.InvProduct</td>
                            <td>@row.TotalContainer</td>
                        </tr>
                    Next
                </tbody>
            </table>
        End If
    Next
</p>
            End If
        Next
    End Code
</div>
