@Code
    ViewData("Title") = "Advance"
    Dim oAdvR = ViewBag.AdvRequest
    Dim arrAdvRByEmp = "[""Staff"",""Cash"",""Cheque"",""Customer Cheque""]"
    Dim totalCash = 0
    Dim totalChq = 0
    Dim totalChqCash = 0

    Dim c = 0
    For Each row In oAdvR
        arrAdvRByEmp &= ","
        arrAdvRByEmp &= "[""" & row.EmpCode & """," & row.SumCash & "," & row.SumChq & "," & row.SumChqCash & "]"
        c += 1
    Next
    If c = 0 Then
        arrAdvRByEmp &= ",[""N/A"",0,0,0]"
    End If

    Dim oAdvUC = ViewBag.AdvUncleared
    Dim arrAdvUCByEmp = "[""Staff"",""Cash"",""Cheque"",""Customer Cheque""]"

    c = 0
    For Each row In oAdvUC
        arrAdvUCByEmp &= ","
        arrAdvUCByEmp &= "[""" & row.EmpCode & """," & row.SumCash & "," & row.SumChq & "," & row.SumChqCash & "]"
        c += 1
    Next
    If c = 0 Then
        arrAdvUCByEmp &= ",[""N/A"",0,0,0]"
    End If

    Dim oAdvUB = ViewBag.AdvUnBilled
    Dim arrAdvUB = "[""Customer"",""Total""]"
    c = 0
    For Each row In oAdvUB
        arrAdvUB &= ","
        arrAdvUB &= "[""" & row.CustCode & """," & row.SumNet + row.SumWht & "]"
        c += 1
    Next
    If c = 0 Then
        arrAdvUB &= ",[""N/A"",0]"
    End If

    Dim oAdvC = ViewBag.AdvCleared
    Dim arrAdvC = "[""Customer"",""Billed"",""UnBilled"",""Cost""]"
    c = 0
    For Each row In oAdvC
        arrAdvC &= ","
        arrAdvC &= "[""" & row.CustCode & """," & row.SumBilled & "," & row.SumUnBilled & "," & row.SumCost & "]"
        c += 1
    Next
    If c = 0 Then
        arrAdvC &= ",[""N/A"",0,0,0]"
    End If
End Code
<div class="container">
    <p>
        <div class="row">
            <div class="col">
                Date From
            </div>
            <div class="col">
                <input type="date" id="dateFrom" value="@ViewBag.DateFrom" />
            </div>
            <div class="col">
                Date To
            </div>
            <div class="col">
                <input type="date" id="dateTo" value="@ViewBag.DateTo" />
            </div>
            <div class="col">
                <input type="button" onclick="RefreshPage()" class="btn btn-success" value="Refresh" />
            </div>
        </div>
    </p>
    <p>
        <b>Waiting For Payment</b>
@If oAdvR.Count > 0 Then
    @<input type="button" class="btn btn-primary" data-toggle="modal" data-target="#dvAdvReq" value="Details" />
    @<div id = "dvChartAdvR" ></div>
    @<div class="modal fade" id="dvAdvReq" data-keyboard="false">
        <div class="modal-dialog-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                    <b>List of Advance Document Waiting for Payment</b>
                </div>
                <div class="modal-body">
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>No</th>
                                    <th>Desc</th>
                                    <th>Days</th>
                                    <th>Amt</th>
                                    <th>Vat</th>
                                    <th>Whd</th>
                                </tr>
                            </thead>
                            <tbody>
                                @For each row In ViewBag.AdvRequest
                                    totalCash += row.SumCash
                                    totalChq += row.SumChq
                                    totalChqCash += row.SumChqCash
                                    @<tr style="background-color:aquamarine;font-weight:bold;">
                                        <td colspan="6">
                                            @row.EmpCode
                                        </td>
                                    </tr>
                                    Dim sumamt = 0
                                    Dim sumvat = 0
                                    Dim sumwhd = 0
                                    For Each r In row.DataSource
                                        sumamt = sumamt + r.dtl.AdvAmount
                                        sumvat = sumvat + r.dtl.ChargeVAT
                                        sumwhd = sumwhd + r.dtl.Charge50Tavi
                                        @<tr style="text-align:right;">
                                             <td style="text-align:left;">
                                                 @r.hdr.AdvNo / @r.dtl.ForJNo / @r.hdr.CustCode
                                             </td>
                                             <td style="text-align:left;">
                                                 @r.dtl.SDescription - @r.dtl.VenCode - @Convert.ToDateTime(r.hdr.AdvDate).ToString("dd/MM/yyyy")
                                             </td>
    <td>
        @DateDiff(DateInterval.Day, r.hdr.AdvDate, DateTime.Now)
    </td>
    <td>
        @Convert.ToDouble(r.dtl.AdvAmount).ToString("#,##0.00")
    </td>
    <td>
        @Convert.ToDouble(r.dtl.ChargeVAT).ToString("#,##0.00")
    </td>
    <td>
        @Convert.ToDouble(r.dtl.Charge50Tavi).ToString("#,##0.00")
    </td>
</tr>
                                    Next
                                    @<tr style="background-color:lightyellow;font-weight:bold;text-align:right">
                                        <td colspan="3">TOTAL</td>
                                        <td>
                                            @Convert.ToDouble(sumamt).ToString("#,##0.00")
                                        </td>
                                        <td>
                                            @Convert.ToDouble(sumvat).ToString("#,##0.00")
                                        </td>
                                        <td>
                                            @Convert.ToDouble(sumwhd).ToString("#,##0.00")
                                        </td>
                                    </tr>
                                Next
                            </tbody>                            
                        </table>
                    </div>
                </div>
            </div>                
        </div>
        </div>
    @<div class="table-responsive">
        <table class="table">
            <thead>
                <tr>
                    <th>
                        Cash
                    </th>
                    <th>
                        Customer Cheque
                    </th>
                    <th>
                        Cashier Cheque
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>@totalCash.ToString("#,##0.00")</td>
                    <td>@totalChq.ToString("#,##0.00")</td>
                    <td>@totalChqCash.ToString("#,##0.00")</td>
                </tr>
            </tbody>
        </table>
        </div>
End If
    </p>
    <p>
        <b>Waiting For Clearance</b>
        @If oAdvUC.Count > 0 Then
            totalCash = 0
            totalChq = 0
            totalChqCash = 0
            @<input type="button" class="btn btn-primary" data-toggle="modal" data-target="#dvAdvUC" value="Details" />
            @<div id="dvChartAdvUC"></div>
            @<div class="modal fade" role="dialog" id="dvAdvUC">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                            <b>List of Advance Document Waiting for Clearance</b>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>No</th>
                                            <th>Desc</th>
                                            <th>Days</th>
                                            <th>
                                                Amt
                                            </th>
                                            <th>Vat</th>
                                            <th>Whd</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        @For each row In ViewBag.AdvUncleared
                                            totalCash += row.SumCash
                                            totalChq += row.SumChq
                                            totalChqCash += row.SumChqCash
                                            @<tr style="background-color:aquamarine;font-weight:bold;">
                                                <td colspan="6">
                                                    @row.EmpCode
                                                </td>
                                            </tr>
                                            Dim sumamt = 0
                                            Dim sumvat = 0
                                            Dim sumwhd = 0
                                            For Each r In row.DataSource
                                                sumamt = sumamt + r.dtl.AdvAmount
                                                sumvat = sumvat + r.dtl.ChargeVAT
                                                sumwhd = sumwhd + r.dtl.Charge50Tavi
                                                @<tr style="text-align:right;">
                                                    <td style="text-align:left;">
                                                        @r.hdr.AdvNo / @r.dtl.ForJNo / @r.hdr.CustCode 
                                                    </td>
                                                    <td style="text-align:left;">
                                                        @r.dtl.SDescription - @r.dtl.VenCode - @Convert.ToDateTime(r.hdr.PaymentDate).ToString("dd/MM/yyyy")
                                                    </td>
                                                    <td>
                                                        @DateDiff(DateInterval.Day, r.hdr.PaymentDate, DateTime.Now)
                                                    </td>
                                                    <td>
                                                        @Convert.ToDouble(r.dtl.AdvAmount).ToString("#,##0.00")
                                                    </td>
                                                    <td>
                                                        @Convert.ToDouble(r.dtl.ChargeVAT).ToString("#,##0.00")
                                                    </td>
                                                    <td>
                                                        @Convert.ToDouble(r.dtl.Charge50Tavi).ToString("#,##0.00")
                                                    </td>
                                                </tr>
                                            Next
                                            @<tr style="background-color:lightyellow;font-weight:bold;text-align:right">
                                                <td colspan="3">TOTAL</td>
                                                <td>
                                                    @Convert.ToDouble(sumamt).ToString("#,##0.00")
                                                </td>
                                                <td>
                                                    @Convert.ToDouble(sumvat).ToString("#,##0.00")
                                                </td>
                                                <td>
                                                    @Convert.ToDouble(sumwhd).ToString("#,##0.00")
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            @<div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th>
                                Cash
                            </th>
                            <th>
                                Customer Cheque
                            </th>
                            <th>
                                Cashier Cheque
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>@totalCash.ToString("#,##0.00")</td>
                            <td>@totalChq.ToString("#,##0.00")</td>
                            <td>@totalChqCash.ToString("#,##0.00")</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        End If
    </p>
    <p>
        <b>Total Cleared Advance - UnBilled</b>
        @If oAdvUB.Count > 0 Then
            @<input type="button" class="btn btn-primary" data-toggle="modal" data-target="#dvAdvUB" value="Details" />
            @<div id="dvChartAdvUB"></div>
            @<div class="modal fade" role="dialog" id="dvAdvUB">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                            <b>List of Advance Document Cleared - Unbiled</b>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>No</th>
                                            <th>Desc</th>
                                            <th>
                                                Amt
                                            </th>
                                            <th>Vat</th>
                                            <th>Whd</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        @For each row In ViewBag.AdvUnBilled
                                            @<tr style="background-color:aquamarine;font-weight:bold;">
                                                <td colspan="6">
                                                    @row.CustCode
                                                </td>
                                            </tr>
                                            Dim sumamt = 0
                                            Dim sumvat = 0
                                            Dim sumwhd = 0
                                            For Each r In row.DataSource
                                                sumamt = sumamt + r.clr.UsedAmount
                                                sumvat = sumvat + r.clr.ChargeVAT
                                                sumwhd = sumwhd + r.clr.Tax50Tavi
                                                @<tr style="text-align:right;">
                                                    <td style="text-align:left;">
                                                        @r.hdr.AdvNo / @r.clr.JobNo
                                                    </td>
                                                    <td style="text-align:left;">
                                                        @r.clr.SDescription - @r.clr.ClrNo - @r.clr.SlipNO
                                                    </td>
                                                    <td>
                                                        @Convert.ToDouble(r.clr.UsedAmount).ToString("#,##0.00")
                                                    </td>
                                                    <td>
                                                        @Convert.ToDouble(r.clr.ChargeVAT).ToString("#,##0.00")
                                                    </td>
                                                    <td>
                                                        @Convert.ToDouble(r.clr.Tax50Tavi).ToString("#,##0.00")
                                                    </td>
                                                </tr>
                                            Next
                                            @<tr style="background-color:lightyellow;font-weight:bold;text-align:right">
                                                <td colspan="2">TOTAL</td>
                                                <td>
                                                    @Convert.ToDouble(sumamt).ToString("#,##0.00")
                                                </td>
                                                <td>
                                                    @Convert.ToDouble(sumvat).ToString("#,##0.00")
                                                </td>
                                                <td>
                                                    @Convert.ToDouble(sumwhd).ToString("#,##0.00")
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        End If
    </p>
    <p>
        <b>Total Cleared Advance - Summary</b>
        @If oAdvC.Count > 0 Then
            @<input type="button" class="btn btn-primary" data-toggle="modal" data-target="#dvAdvC" value="Details" />
            @<div id="dvChartAdvC"></div>
            @<div class="modal fade" role="dialog" id="dvAdvC">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <input type="button" data-dismiss="modal" class="btn btn-danger" value="X" />
                            <b>List of Advance Document Cleared</b>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>No</th>
                                            <th>Desc</th>
                                            <th>
                                                Billed
                                            </th>
                                            <th>Unbilled</th>
                                            <th>Cost</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        @For each row In ViewBag.AdvCleared
                                            Dim sumbill = 0
                                            Dim sumcost = 0
                                            Dim sumunbill = 0

                                            @<tr style="background-color:aquamarine;font-weight:bold;">
                                                <td colspan="6">
                                                    @row.CustCode
                                                </td>
                                            </tr>
                                            For Each r In row.DataSource
                                                @<tr style="text-align:right;">
                                                    <td style="text-align:left;">
                                                        @r.hdr.AdvNo / @r.clr.JobNo
                                                    </td>
                                                    <td style="text-align:left;">
                                                        @r.clr.SDescription - @r.clr.ClrNo - @r.clr.SlipNO
                                                    </td>
                                                    <td>
                                                        @If r.clr.LinkItem > 0 And r.srv.IsExpense = 0 Then
                                                            sumbill += Convert.ToDouble(r.clr.UsedAmount + r.clr.ChargeVAT)
                                                            @Convert.ToDouble(r.clr.UsedAmount + r.clr.ChargeVAT).ToString("#,##0.00")
                                                        End If
                                                    </td>
                                                    <td>
                                                        @If r.clr.LinkItem = 0 And r.srv.IsExpense = 0 Then
                                                            sumunbill += Convert.ToDouble(r.clr.UsedAmount + r.clr.ChargeVAT)
                                                            @Convert.ToDouble(r.clr.UsedAmount + r.clr.ChargeVAT).ToString("#,##0.00")
                                                        End If
                                                    </td>
                                                    <td>
                                                        @If r.srv.IsExpense = 1 Then
                                                            sumcost += Convert.ToDouble(r.clr.UsedAmount + r.clr.ChargeVAT)
                                                            @Convert.ToDouble(r.clr.UsedAmount + r.clr.ChargeVAT).ToString("#,##0.00")
                                                        End If
                                                    </td>
                                                </tr>
                                            Next
                                            @<tr style="background-color:lightyellow;font-weight:bold;text-align:right">
                                                <td colspan="2">TOTAL</td>
                                                <td>
                                                    @Convert.ToDouble(sumbill).ToString("#,##0.00")
                                                </td>
                                                <td>
                                                    @Convert.ToDouble(sumunbill).ToString("#,##0.00")
                                                </td>
                                                <td>
                                                    @Convert.ToDouble(sumcost).ToString("#,##0.00")
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        End If
    </p>
</div>
<script type = "text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var arrAdvR = [@Html.Raw(arrAdvRByEmp)];
    var arrAdvC = [@Html.Raw(arrAdvC)];
    var arrAdvUC = [@Html.Raw(arrAdvUCByEmp)];
    var arrAdvUB = [@Html.Raw(arrAdvUB)];

    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawChart);
    window.onresize = () => {
        drawChart();
    };

    function drawChart() {
        var data1 = google.visualization.arrayToDataTable(arrAdvR);
        var data2 = google.visualization.arrayToDataTable(arrAdvUC);
        var data3 = google.visualization.arrayToDataTable(arrAdvUB);
        var data4 = google.visualization.arrayToDataTable(arrAdvC);

        var options1 = {
            width: 600,
            height: 400,
            legend: { position: 'top', maxLines: 3 },
            bar: { groupWidth: '75%' },
            isStacked: true
        };

        var chart1 = new google.visualization.BarChart(document.getElementById('dvChartAdvR'));
        chart1.draw(data1, options1);

        var chart2 = new google.visualization.BarChart(document.getElementById('dvChartAdvUC'));
        chart2.draw(data2, options1);

        var chart3 = new google.visualization.BarChart(document.getElementById('dvChartAdvUB'));
        chart3.draw(data3, options1);

        var chart4 = new google.visualization.BarChart(document.getElementById('dvChartAdvC'));
        chart4.draw(data4, options1);
    }
    function RefreshPage() {
        window.location.href = '@Url.Action("Advance", "Chart")?DateFrom=' + document.getElementById("dateFrom").value + '&DateTo=' + document.getElementById("dateTo").value;
    }
</script>
