<style>
    * {
        box-sizing: border-box;
    }

    ul.list-group {
        list-style-type: none;
        padding: 0;
        margin: 0;
    }

        ul.list-group li {
            border: 1px solid #ddd;
            margin-top: -1px; /* Prevent double borders */
            background-color: #f6f6f6;
            padding: 12px;
        }

        ul.list-group .badge-red {
            background-color: red;
            color: #fff;
            font-weight: bold;
            border-radius: 50%;
            padding: 5px 10px;
            text-align: center;
            margin-left: 5px;
        }
        ul.list-group .badge-green {
            background-color: green;
            color: #fff;
            font-weight: bold;
            border-radius: 50%;
            padding: 5px 10px;
            text-align: center;
            margin-left: 5px;
        }
</style>
@Code
    ViewData("Title") = "Chart"
    Dim table = DirectCast(ViewBag.JobList, List(Of CJobOrder))
    Dim dataCancel = table.Where(Function(e) e.JobStatus >= 90)
    Dim data = table.Where(Function(e) e.JobStatus < 90)
    Dim totaljobActiveIM = data.Where(Function(e) e.JobType = 1).Count
    Dim totaljobActiveEX = data.Where(Function(e) e.JobType <> 1).Count
    Dim totaljobCancelIM = dataCancel.Where(Function(e) e.JobType = 1).Count
    Dim totaljobCancelEX = dataCancel.Where(Function(e) e.JobType <> 1).Count
    Dim jobOnPrepare = data.AsEnumerable().Where(Function(e) e.ETADate > Today.Date).ToList
    Dim totalJobOnPrepare = jobOnPrepare.Count
    Dim totalJobOnPrepareIM = jobOnPrepare.Where(Function(e) e.JobType = 1 And e.DeclareNumber = "").Count
    Dim totalJobOnPrepareEX = jobOnPrepare.Where(Function(e) e.JobType <> 1 And e.DeclareNumber = "").Count
    Dim totalJobOnCustomIM = jobOnPrepare.Where(Function(e) e.JobType = 1 And e.DeclareNumber <> "").Count
    Dim totalJobOnCustomEX = jobOnPrepare.Where(Function(e) e.JobType <> 1 And e.DeclareNumber <> "").Count
    Dim jobOnWorking = data.AsEnumerable().Where(Function(e) e.ETADate <= Today.Date).ToList
    Dim totalJobOnWorking = jobOnWorking.Count
    Dim jobOnDelivering = jobOnWorking.Where(Function(e) e.CloseJobBy = "").ToList
    Dim totalJobOnDeliveringIM = jobOnDelivering.Where(Function(e) e.JobType = 1).Count
    Dim totalJobOnDeliveringEX = jobOnDelivering.Where(Function(e) e.JobType <> 1).Count
    Dim jobOnClearing = jobOnWorking.Where(Function(e) e.CloseJobBy <> "")
    Dim totalJobOnClearingIM = jobOnClearing.Where(Function(e) e.JobType = 1).Count
    Dim totalJobOnClearingEX = jobOnClearing.Where(Function(e) e.JobType <> 1).Count
End Code
<div class="container">
    <div class="row">
        <div class="col">
            <div id="chartJob"></div>
        </div>
    </div>   
    <div class="row">
        <div class="col-6">
            <h2>Active Job</h2>
            <input type="button" data-toggle="modal" data-target="#modCancel" value="Show Cancel" class="btn btn-danger" />
            <div id="chartVol"></div>
            <div class="modal fade" id="modCancel" role="dialog">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <input type="button" data-dismiss="modal" class="btn btn-danger" value="Close" />
                        </div>
                        <div class="modal-body container">                            
                            <b>Job Cancelled</b>
                            <div class="row">
                                <div class="col-6">
                                    <div class="table-responsive">
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th>Job#</th>
                                                    <th>Po#</th>
                                                    <th>Bkg#</th>
                                                    <th>BL#</th>
                                                    <th>Inv#</th>
                                                    <th>Commodity</th>
                                                    <th>Volume</th>
                                                    <th>Reason</th>
                                                    <th>Cancel By</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @for Each row In dataCancel
                                                    @<tr>
                                                        <td>@row.JNo</td>
                                                        <td>@row.CustRefNO</td>
                                                        <td>@row.BookingNo</td>
                                                        <td>@row.HAWB</td>
                                                        <td>@row.InvNo</td>
                                                        <td>@row.InvProduct</td>
                                                        <td>@row.TotalContainer</td>
                                                        <td>@row.CancelReson</td>
                                                        <td>@row.CancelProve</td>
                                                    </tr>
                                                Next
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <h2>In Process </h2><input type="button" data-toggle="modal" data-target="#modPrepare" value="Show Details" class="btn btn-success" />
            <div id = "chartVol1" ></div>
                <div class="modal fade" id="modPrepare" role="dialog">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <input type="button" data-dismiss="modal" class="btn btn-danger" value="Close" />
                        </div>
                        <div class="modal-body container">                            
                            <b>Job In Process</b>
                            <ul class="list-group">
                                <li><a href="#tbPreparing">Preparing</a> <span class="badge-red">@jobOnPrepare.Where(Function(e) e.DeclareNumber = "").Count</span></li>
                                <li><a href="#tbCustomsAccept">Customs Accept</a> <span class="badge-green">@jobOnPrepare.Where(Function(e) e.DeclareNumber <> "").Count</span></li>
                            </ul>

                            <div class="row">
                                <div class="col-6">
                                    <div class="table-responsive">
                                        <Table class="table" id="tbPreparing">
                                            <thead>
                                                <tr>
                                                    <th> Job#</th>
                                                    <th> Po#</th>
                                                    <th> Bkg#</th>
                                                    <th> Loading#</th>
                                                    <th> Discharge#</th>
                                                    <th> ETD/ETA#</th>
                                                    <th> Volume</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @For Each row In jobOnPrepare.Where(Function(e) e.DeclareNumber = "").OrderBy(Function(e) e.JobType)
                                                    @<tr>
                                                        <td>@row.JNo</td>
                                                        <td>@row.CustRefNO</td>
                                                        <td>@row.BookingNo</td>
                                                        @If row.JobType = 1 Then
                                                            @<td>@row.InvInterPort</td>
                                                            @<td>@row.ClearPort</td>
                                                        Else
                                                            @<td>@row.ClearPort</td>
                                                            @<td>@row.InvInterPort</td>
                                                        End If
                                                        <td>@String.Format(IIf(row.JobType = 1, row.ETADate, row.ETDDate), "dd/MM/yyyy")</td>
                                                        <td>@row.TotalContainer</td>
                                                    </tr>
                                                Next
                                            </tbody>
                                            <tfoot>
                                                <tr style="font-weight:bold">
                                                    <td colspan="5">Total Preparing</td>
                                                    <td>@jobOnPrepare.Where(Function(e) e.DeclareNumber = "").Count</td>
                                                    <td>Jobs</td>
                                                </tr>
                                            </tfoot>
                                        </Table>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="table-responsive">
                                        <table class="table" id="tbCustomsAccept">
                                            <thead>
                                                <tr>
                                                    <th>Job#</th>
                                                    <th>Po#</th>
                                                    <th>Bkg#</th>
                                                    <th>Loading#</th>
                                                    <th>Discharge#</th>
                                                    <th>Decl#</th>
                                                    <th>Volume</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @For Each row In jobOnPrepare.Where(Function(e) e.DeclareNumber <> "").OrderBy(Function(e) e.JobType)
                                                    @<tr>
                                                        <td>@row.JNo</td>
                                                        <td>@row.CustRefNO</td>
                                                        <td>@row.BookingNo</td>
                                                        @If row.JobType = 1 Then
                                                            @<td>@row.InvInterPort</td>
                                                            @<td>@row.ClearPort</td>
                                                        Else
                                                            @<td>@row.ClearPort</td>
                                                            @<td>@row.InvInterPort</td>
                                                        End If
                                                        <td>@row.DeclareNumber</td>
                                                        <td>@row.TotalContainer</td>
                                                    </tr>
                                                Next
                                            </tbody>
                                            <tfoot>
                                                <tr style="font-weight:bold">
                                                    <td colspan="5">Total Customs Accept</td>
                                                    <td>@jobOnPrepare.Where(Function(e) e.DeclareNumber <> "").Count</td>
                                                    <td>Jobs</td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <h2>In Loading</h2><input type="button" data-toggle="modal" data-target="#modClearing" value="Show Details" class="btn btn-success" />
            <div id="chartVol2"></div>
            <div id="chartVol4"></div>
            <div class="modal fade" id="modClearing" role="dialog">
                <div class="modal-dialog-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <input type="button" data-dismiss="modal" class="btn btn-danger" value="Close" />
                        </div>
                        <div class="modal-body container">                            
                            <b>Job In Loading</b>
                            <ul class="list-group">
                                <li><a href="#tbDelivering">Delivering</a> <span class="badge-red">@jobOnDelivering.Count</span></li>
                                <li><a href="#tbDelivered">Delivered</a> <span class="badge-green">@jobOnClearing.Count</span></li>
                            </ul>
                            <div class="row">
                                <div class="col-6">
                                    <div class="table">
                                        <table class="table" id="tbDelivering">
                                            <thead>
                                                <tr>
                                                    <th>Job#</th>
                                                    <th>Po#</th>
                                                    <th>Bkg#</th>
                                                    <th>Loading#</th>
                                                    <th>Load Date</th>
                                                    <th>Delivery Date</th>
                                                    <th>Declare#</th>
                                                    <th>Volume</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @For Each row In jobOnDelivering.OrderBy(Function(e) e.JobType)
                                                    @<tr>
                                                        <td>@row.JNo</td>
                                                        <td>@row.CustRefNO</td>
                                                        <td>@row.BookingNo</td>
                                                        <td>@row.ClearPortNo</td>
                                                        <td>@String.Format(row.LoadDate, "dd/MM/yyyy")</td>
                                                        <td>@String.Format(row.EstDeliverDate, "dd/MM/yyyy")</td>
                                                        <td>@row.DeclareNumber</td>
                                                        <td>@row.TotalContainer</td>
                                                    </tr>
                                                Next
                                            </tbody>
                                            <tfoot>
                                                <tr style="font-weight:bold">
                                                    <td colspan="5">Total Delivering</td>
                                                    <td>@jobOnDelivering.Count</td>
                                                    <td>Jobs</td>
                                                </tr>
                                            </tfoot>

                                        </table>
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <div class="table-responsive">
                                        <table class="table" id="tbDelivered">
                                            <thead>
                                                <tr>
                                                    <th>Job#</th>
                                                    <th>Po#</th>
                                                    <th>Bkg#</th>
                                                    <th>Loading#</th>
                                                    <th>Load Date</th>
                                                    <th>Delivery Date</th>
                                                    <th>Declare#</th>
                                                    <th>Volume</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @For Each row In jobOnClearing.OrderBy(Function(e) e.JobType)
                                                    @<tr>
                                                        <td>@row.JNo</td>
                                                        <td>@row.CustRefNO</td>
                                                        <td>@row.BookingNo</td>
                                                        <td>@row.ClearPortNo</td>
                                                        <td>@String.Format(row.LoadDate, "dd/MM/yyyy")</td>
                                                        <td>@String.Format(row.EstDeliverDate, "dd/MM/yyyy")</td>
                                                        <td>@row.DeclareNumber</td>
                                                        <td>@row.TotalContainer</td>
                                                    </tr>
                                                Next
                                            </tbody>
                                            <tfoot>
                                                <tr style="font-weight:bold">
                                                    <td colspan="5">Total Delivered</td>
                                                    <td>@jobOnClearing.Count</td>
                                                    <td>Jobs</td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);
    window.onresize = ()=> {
        drawChart();
    };
    function drawChart() {
        //prepare data
        var arr0 = [
            ["Status", "Active","Cancel"],
            ["Import", @totaljobActiveIM,@totaljobCancelIM],
            ["Export", @totaljobActiveEX,@totaljobCancelEX]
        ];
        var arr1 = [
            ["Status", "Total"],
            ["In Process",@totalJobOnPrepare],
            ["In Loading",@totalJobOnWorking]
        ];
        var arr2 = [
            ["JobType","Delivering", "Delivered"],
            ["Import",@totalJobOnDeliveringIM,@totalJobOnClearingIM],
            ["Export",@totalJobOnDeliveringEX,@totalJobOnClearingEX]
        ];
        var arr3 = [
            ["JobType","Preparing", "Customs Accept"],
            ["Import",@totalJobOnPrepareIM,@totalJobOnCustomIM],
            ["Export",@totalJobOnPrepareEX,@totalJobOnCustomEX]
        ];
        var arr4 = [
            ["Status","Total"],
            ["Delivering",@totalJobOnDeliveringIM+@totalJobOnDeliveringEX],
            ["Delivered",@totalJobOnClearingIM+@totalJobOnClearingEX]
        ];

        var dataVol0 = google.visualization.arrayToDataTable(arr0);
        var dataVol1 = google.visualization.arrayToDataTable(arr1);
        var dataVol2 = google.visualization.arrayToDataTable(arr2);
        var dataVol3 = google.visualization.arrayToDataTable(arr3);
        var dataVol4 = google.visualization.arrayToDataTable(arr4);
        //chart total job
        var optionsJob = {
            title: 'Total',
            chartArea: { width: '50%' },
            isStacked: true,
            hAxis: {
                title: 'Total Job',
                minValue: 0,
            },
            vAxis: {
                title: 'Status'
            }
        };

        var chart = new google.visualization.BarChart(document.getElementById('chartJob'));
        chart.draw(dataVol0,optionsJob);

        var volOptions = {
            pieHole: 0.4,
            colors: GetColorStatus()
        };
        //chart active job
        var chartVol = new google.visualization.PieChart(document.getElementById('chartVol'));
        google.visualization.events.addListener(chartVol, 'select', function (e) {
            if (chartVol.getSelection() != null &&
                chartVol.getSelection()[0] != null &&
                chartVol.getSelection()[0]['row'] != null &&
                chartVol.getSelection().length > 0) {
                let selType=dataVol1.getFormattedValue(chartVol.getSelection()[0].row, 0);
            }
        });
        chartVol.draw(dataVol1, volOptions);
        
        var chartVol4 = new google.visualization.PieChart(document.getElementById('chartVol4'));
        chartVol4.draw(dataVol4, volOptions);

        var options = {
            title: 'Total Clearance',
            chartArea: { width: '50%' },
            isStacked: true,
            hAxis: {
                title: 'Total Clearance',
                minValue: 0
            },
            vAxis: {
                title: 'Job Type'
            }
        };
        var chartVol2 = new google.visualization.BarChart(document.getElementById('chartVol2'));
        chartVol2.draw(dataVol2, options);

        var options2 = {
            title: 'Total Preparation',
            chartArea: { width: '50%' },
            isStacked: true,
            hAxis: {
                title: 'Total Preparation',
                minValue: 0
            },
            vAxis: {
                title: 'Job Type'
            }
        };

        var chartVol3 = new google.visualization.BarChart(document.getElementById('chartVol1'));
        chartVol3.draw(dataVol3, options2);
    }
    function GetColorStatus() {
        return [
            { color: 'antiquewhite', visibleInLegend: true },
            { color: 'aquamarine', visibleInLegend: true },
            { color: 'coral', visibleInLegend: true },
            { color: 'cyan', visibleInLegend: true },
            { color: 'cornsilk', visibleInLegend: true },
            { color: 'darkgreen', visibleInLegend: true },
            { color: 'deeppink', visibleInLegend: true },
            { color: 'greenyellow', visibleInLegend: true },
            { color: 'lightblue', visibleInLegend: true },
            { color: 'olive', visibleInLegend: true },
        ];
    }

</script>