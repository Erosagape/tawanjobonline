@Code
    ViewData("Title") = "Total Containers"
    Dim beginDate = New Date(Today.Year, Today.Month, 1).ToString("yyyy-MM-dd")
    If Request.QueryString("BeginDate") IsNot Nothing Then
        beginDate = Request.QueryString("BeginDate")
    End If
    Dim endDate = New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
    If Request.QueryString("EndDate") IsNot Nothing Then
        endDate = Request.QueryString("EndDate")
    End If

    Dim oSummary = New Dictionary(Of String, Int32)
    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB
        Dim sqlConMultiple = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c From job_order
where CHARINDEX(',',TotalContainer,0)>0 
and DocDate>='{0}' and DocDate<='{1}'
group by replace(TotalContainer,' ','')
"
        Dim sqlConSingle = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c From job_order
where CHARINDEX(',',TotalContainer,0)=0
and DocDate>='{0}' and DocDate<='{1}'
group by replace(TotalContainer,' ','')
"
        Using rs = New CUtil(conn).GetTableFromSQL(String.Format(sqlConSingle, beginDate, endDate))
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
        Using rs = New CUtil(conn).GetTableFromSQL(String.Format(sqlConMultiple, beginDate, endDate))
            If rs.Rows.Count > 0 Then
                For Each row In rs.Rows
                    Dim strVal = row("TotalContainer").ToString().ToUpper()
                    For Each strCon In strVal.Split(",")
                        Dim xPos = strCon.IndexOf("X")
                        Dim jobQty As Int32 = 0
                        If Int32.TryParse(row("c").ToString(), jobQty) = False Then
                            Continue For
                        Else
                            jobQty = Convert.ToInt32(row("c"))
                        End If
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
    Dim arrSummary = ""
End Code
<div class="row">
    <div class="col-sm-3">
        From Date <br />
        <input type="date" id="txtDateFrom" class="form-control" value="@beginDate" />
    </div>
    <div class="col-sm-3">
        To Date <br />
        <input type="date" id="txtDateTo" class="form-control" value="@endDate" />
    </div>
    <div class="col-sm-3">
        <br />
        <input type="button" class="btn btn-primary" value="Search" onclick="RefreshData()" />
    </div>
</div>
<div id="dvChart"></div>
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

                arrSummary = "[""Unit"",""Qty""]"
                For Each con In oSorted
                    arrSummary &= ",[""" & con.Key & """," & con.Value & "]"
                    @<tr>
                        <td>@con.Key</td>
                        <td>@con.Value</td>
                    </tr>
                Next
            Else
                arrSummary = "[""Unit"",""Qty""],[""N/A"",0]"
            End If
        </tbody>
    </table>
</div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    var arrSummary = [@Html.Raw(arrSummary)];
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    function drawChart() {
        var data1 = google.visualization.arrayToDataTable(arrSummary);

        var options1 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart1 = new google.visualization.BarChart(document.getElementById('dvChart'));
        chart1.draw(data1, options1);
    }

    function RefreshData() {
        window.location.href = path + 'Tracking/Dashboard?Form=5&BeginDate=' + $('#txtDateFrom').val() + '&EndDate=' + $('#txtDateTo').val();
    }
</script>