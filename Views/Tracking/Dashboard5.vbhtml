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

    Dim oSummaryIM = New Dictionary(Of String, Int32)
    Dim oSummaryEX = New Dictionary(Of String, Int32)
    If ViewBag.User <> "" Then
        Dim conn = ViewBag.CONNECTION_JOB
        Dim sqlConMultiple = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c,JobType
From job_order
where CHARINDEX(',',TotalContainer,0)>0
and DocDate>='{0}' and DocDate<='{1}'
group by replace(TotalContainer,' ',''),JobType
"
        Dim sqlConSingle = "
select replace(TotalContainer,' ','') as TotalContainer,count(*) as c,JobType
From job_order
where CHARINDEX(',',TotalContainer,0)=0
and DocDate>='{0}' and DocDate<='{1}'
group by replace(TotalContainer,' ',''),JobType
"
        Using rs = New CUtil(conn).GetTableFromSQL(String.Format(sqlConSingle, beginDate, endDate))
            If rs.Rows.Count > 0 Then
                For Each row In rs.Rows
                    Dim strCon = row("TotalContainer").ToString().ToUpper()
                    Dim xPos = strCon.IndexOf("X")
                    Dim jobQty = Convert.ToInt32(row("c"))
                    If xPos > 0 Then
                        Dim arrCon
                        Dim conQty
                        Dim conUnit
                        If row("JobType").ToString().Equals("1") Then
                            Try
                                arrCon = strCon.Split("X")
                                conQty = Convert.ToInt32(arrCon(0)) * jobQty
                                conUnit = arrCon(1)

                                If oSummaryIM.ContainsKey(conUnit) Then
                                    Dim oOldVal = oSummaryIM(conUnit)
                                    conQty = conQty + oOldVal
                                    oSummaryIM.Remove(conUnit)
                                End If
                                oSummaryIM.Add(conUnit, conQty)
                            Catch ex As Exception
                                oSummaryIM.Add(strCon, jobQty)
                            End Try
                        Else
                            Try
                                arrCon = strCon.Split("X")
                                conQty = Convert.ToInt32(arrCon(0)) * jobQty
                                conUnit = arrCon(1)

                                If oSummaryEX.ContainsKey(conUnit) Then
                                    Dim oOldVal = oSummaryEX(conUnit)
                                    conQty = conQty + oOldVal
                                    oSummaryEX.Remove(conUnit)
                                End If
                                oSummaryEX.Add(conUnit, conQty)
                            Catch ex As Exception
                                oSummaryEX.Add(strCon, jobQty)
                            End Try
                        End If

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
                        If row("JobType").ToString().Equals("1") Then
                            If oSummaryIM.ContainsKey(strUnit) Then
                                Dim oOldVal = oSummaryIM(strUnit)
                                jobQty = jobQty + oOldVal
                                oSummaryIM.Remove(strUnit)
                            End If
                            oSummaryIM.Add(strUnit, jobQty)
                        Else
                            If oSummaryEX.ContainsKey(strUnit) Then
                                Dim oOldVal = oSummaryEX(strUnit)
                                jobQty = jobQty + oOldVal
                                oSummaryEX.Remove(strUnit)
                            End If
                            oSummaryEX.Add(strUnit, jobQty)
                        End If
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
                            Dim arrCon
                            Dim conQty
                            Dim conUnit
                            If row("JobType").ToString().Equals("1") Then
                                Try
                                    arrCon = strCon.Split("X")
                                    conQty = Convert.ToInt32(arrCon(0)) * jobQty
                                    conUnit = arrCon(1)
                                    If oSummaryIM.ContainsKey(conUnit) Then
                                        Dim oOldVal = oSummaryIM(conUnit)
                                        conQty = conQty + oOldVal
                                        oSummaryIM.Remove(conUnit)
                                    End If
                                    oSummaryIM.Add(conUnit, conQty)
                                Catch ex As Exception
                                    oSummaryIM.Add(strCon, jobQty)
                                End Try
                            Else
                                Try
                                    arrCon = strCon.Split("X")
                                    conQty = Convert.ToInt32(arrCon(0)) * jobQty
                                    conUnit = arrCon(1)
                                    If oSummaryEX.ContainsKey(conUnit) Then
                                        Dim oOldVal = oSummaryEX(conUnit)
                                        conQty = conQty + oOldVal
                                        oSummaryEX.Remove(conUnit)
                                    End If
                                    oSummaryEX.Add(conUnit, conQty)
                                Catch ex As Exception
                                    oSummaryEX.Add(strCon, jobQty)
                                End Try
                            End If

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
                            If row("JobType").ToString().Equals("1") Then
                                If oSummaryIM.ContainsKey(strUnit) Then
                                    Dim oOldVal = oSummaryIM(strUnit)
                                    jobQty = jobQty + oOldVal
                                    oSummaryIM.Remove(strUnit)
                                End If
                                oSummaryIM.Add(strUnit, jobQty)

                            Else
                                If oSummaryEX.ContainsKey(strUnit) Then
                                    Dim oOldVal = oSummaryEX(strUnit)
                                    jobQty = jobQty + oOldVal
                                    oSummaryEX.Remove(strUnit)
                                End If
                                oSummaryEX.Add(strUnit, jobQty)
                            End If

                        End If
                    Next
                Next
            End If
        End Using
    End If
    Dim arrSummary = ""
    If oSummaryIM.Count > 0 Then
        Dim oSortedIM = From item In oSummaryIM
                        Order By item.Key Ascending
                        Select item

        arrSummary = "[""Unit"",""Qty""]"
        For Each con In oSortedIM
            arrSummary &= ",[""" & con.Key & """," & con.Value & "]"
        Next
    End If
    If oSummaryEX.Count > 0 Then
        Dim oSortedEX = From item In oSummaryEX
                        Order By item.Key Ascending
                        Select item

        If arrSummary = "" Then
            arrSummary = "[""Unit"",""Qty""]"
        End If
        For Each con In oSortedEX
            arrSummary &= ",[""" & con.Key & """," & con.Value & "]"
        Next
    Else
        If arrSummary = "" Then
            arrSummary = "[""Unit"",""Qty""],[""N/A"",0]"
        End If
    End If

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