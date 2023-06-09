@Code
    ViewData("Title") = "Total Containers"
    Dim oSummary = New Dictionary(Of String, Int32)
    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB
        Dim sqlConMultiple = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c From job_order
where CHARINDEX(',',TotalContainer,0)>0
group by replace(TotalContainer,' ','')
"
        Dim sqlConSingle = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c From job_order
where CHARINDEX(',',TotalContainer,0)=0
group by replace(TotalContainer,' ','')
"

        Using rs = New CUtil(conn).GetTableFromSQL(sqlConSingle)
            If rs.Rows.Count > 0 Then
                For Each row In rs.Rows
                    Dim strCon = row("TotalContainer").ToString().ToUpper()
                    Dim xPos = strCon.IndexOf("X")
                    Dim jobQty = Convert.ToInt32(row("c"))
                    If xPos > 0 Then
                        Dim arrCon = strCon.Split("X")
                        Try
                            Dim conQty = Convert.ToInt32(arrCon(0)) * jobQty
                            Dim conUnit = arrCon(1)
                            If oSummary.ContainsKey(conUnit) Then
                                Dim oOldVal = oSummary(conUnit)
                                conQty = conQty + oOldVal
                                oSummary.Remove(conUnit)
                            End If
                            oSummary.Add(conUnit, conQty)
                        Catch ex As Exception
                            oSummary.Add(strCon, jobQty)
                        End Try
                    Else
                        Dim strUnit = ""
                        Dim qtyIndex = 0
                        For i As Integer = 0 To strCon.Length - 1
                            If "0123456789".IndexOf(strCon.Substring(i, 1)) < 0 Then
                                strUnit &= strCon.Substring(i, 1)
                                If qtyIndex > 0 Then
                                    Exit For
                                End If
                            Else
                                qtyIndex += 1
                            End If
                        Next
                        If qtyIndex > 0 Then
                            Try
                                jobQty = jobQty * Convert.ToInt32(strCon.Substring(0, qtyIndex))
                            Catch ex As Exception
                                jobQty = 1
                            End Try

                        End If
                        If oSummary.ContainsKey(strUnit) Then
                            Dim oOldVal = oSummary(strUnit)
                            jobQty = jobQty + oOldVal
                            oSummary.Remove(strUnit)
                        End If
                        oSummary.Add(strUnit, jobQty)
                    End If
                Next
            End If
        End Using
        Using rs = New CUtil(conn).GetTableFromSQL(sqlConMultiple)
            If rs.Rows.Count > 0 Then
                For Each row In rs.Rows
                    Dim strVal = row("TotalContainer").ToString().ToUpper()
                    For Each strCon In strVal.Split(",")
                        Dim xPos = strCon.IndexOf("X")
                        Dim jobQty = Convert.ToInt32(row("c"))
                        If xPos > 0 Then
                            Dim arrCon = strCon.Split("X")
                            Try
                                Dim conQty = Convert.ToInt32(arrCon(0)) * jobQty
                                Dim conUnit = arrCon(1)
                                If oSummary.ContainsKey(conUnit) Then
                                    Dim oOldVal = oSummary(conUnit)
                                    conQty = conQty + oOldVal
                                    oSummary.Remove(conUnit)
                                End If
                                oSummary.Add(conUnit, conQty)
                            Catch ex As Exception
                                oSummary.Add(strCon, jobQty)
                            End Try
                        Else
                            Dim strUnit = ""
                            Dim qtyIndex = 0
                            For i As Integer = 0 To strCon.Length - 1
                                If "0123456789".IndexOf(strCon.Substring(i, 1)) < 0 Then
                                    strUnit &= strCon.Substring(i, 1)
                                    If qtyIndex > 0 Then
                                        Exit For
                                    End If
                                Else
                                    qtyIndex += 1
                                End If
                            Next
                            If qtyIndex > 0 Then
                                Try
                                    jobQty = jobQty * Convert.ToInt32(strCon.Substring(0, qtyIndex))
                                Catch ex As Exception
                                    jobQty = 1
                                End Try

                            End If
                            If oSummary.ContainsKey(strUnit) Then
                                Dim oOldVal = oSummary(strUnit)
                                jobQty = jobQty + oOldVal
                                oSummary.Remove(strUnit)
                            End If
                            oSummary.Add(strUnit, jobQty)
                        End If
                    Next
                Next
            End If
        End Using
    End If
End Code
<div class="table-responsive">
    <table class="table table-bordered">
        <thead>
            <tr>
                <th>Size</th>
                <th>Qty</th>
            </tr>
        </thead>
        <tbody>
            @If oSummary.Count > 0 Then
                Dim oSorted = From item In oSummary
                              Order By item.Key Ascending
                              Select item

                For Each con In oSorted
                    @<tr>
                        <td>@con.Key</td>
                        <td>@con.Value</td>
                    </tr>
                Next
            End If
        </tbody>
    </table>
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
</script>