﻿@Code
    ViewBag.Title = "Tracking Status"
    Layout = Nothing
End Code
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <link rel="stylesheet" href="~/Content/Site.css">
        <link rel="stylesheet" href="~/Content/bootstrap.min.css">
        <link rel="stylesheet" href="~/Content/bootstrap-select.min.css">
        <link rel="stylesheet" href="~/Content/jquery.datatables.min.css">
        <link rel="stylesheet" href="~/Content/responsive.dataTables.min.css">
        <script src="~/Scripts/jquery-3.4.1.min.js"></script>
        <script src="~/Scripts/DataTables/jquery.dataTables.min.js"></script>
        <script src="~/Scripts/DataTables/dataTables.responsive.min.js"></script>
        <script src="~/Scripts/bootstrap.js"></script>
        <script src="~/Scripts/bootbox.js"></script>
        <script src="~/Scripts/bootstrap-select.js"></script>
        <script src="~/Scripts/Func/util.js"></script>
        <script src="~/Scripts/Func/popup.js"></script>
        <script src="~/Scripts/Func/combo.js"></script>
        <script src="~/Scripts/Func/menu.js"></script>
        <script src="~/Scripts/Func/lang.js"></script>
        <script src="~/Scripts/bootstrap.min.js"></script>
    </head>
    <div style="width:100%;background-color:indigo;color:white;padding:10px 10px 10px 10px">
        <h3>Tracking Your Shipment</h3>
    </div>    
    <div class="row">
        <div class="col-sm-4">
            Branch
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
            </div>
        </div>
        <div class="col-sm-5">
            Customer Tax-ID:
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtTaxNumber" style="width:30%" />
                <input type="text" class="form-control" id="txtCustName" style="width:70%" disabled />
            </div>
        </div>
        <div class="col-sm-3">
            Status:
            <br/>
            <select id="cboStatus" class="form-control dropdown"></select> 
        </div>
    </div>
    <a href="#" class="btn btn-primary" id="btnShow" onclick="RefreshGrid()">
        <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Show</b>
    </a>
    <div class="row">
        <div class="col-md-12">
            <b>Status By Customer:</b>
            <div id="chartCust"></div>
        </div>
    </div>
    <table id="tbDetail" class="table table-responsive">
        <thead>
            <tr>
                <th class="all">CUST.INV</th>
                <th class="all">JOB NO</th>
                <th>PREPARING</th>
                <th>AUTHORIZED</th>
                <th>CUSTOMS READY</th>
                <th>DEPARTURE</th>
                <th>ARRIVAL</th>
                <th>LOADING</th>
                <th>DELIVERED</th>
                <th>BILLED</th>
                <th class="all">STATUS</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
<div id="dvLOVs"></div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let dbIndex = getQueryString("db") == '' ? '1' : getQueryString("db");

    google.charts.load("current", { packages: ["corechart"] });
    window.onresize = () => {
        drawChart();
    }
    QuickCallback(function () {
        SetLOVs();
    },dbIndex);
    $('#txtTaxNumber').focusout(function () {
        QuickCallback(function () {
            ShowCompanyByTax(path, $('#txtTaxNumber').val(), '#txtCustName');
        },dbIndex);
    });
    function SetLOVs() {
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,4);
        });
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,4);
        });
        let lists = 'JOB_STATUS=#cboStatus';
        loadCombos(path, lists);
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                QuickCallback(function () {
                    SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                },dbIndex);
                break;
        }
    }
    function RefreshGrid() {
        QuickCallback(function () {
            let branch = $('#txtBranchCode').val();
            let taxno = $('#txtTaxNumber').val();
            let status = $('#cboStatus').val();
            let opt = '';
            if (status !== '') {
                opt += '&Status=' + status;
            }
            $('#tbDetail').DataTable({
                ajax: {
                    url: path+'joborder/gettrackingreport?Branch=' + branch + '&TaxNumber=' + taxno + opt, //web service ที่จะ call ไปดึงข้อมูลมา
                    dataSrc: 'transport.data'
                },
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "InvNo", title: "CUST.INV" },
                    {
                        data: null, title: "JOB",
                        render: function (data) {
                            let html = data.JNo;
                            html += '<br/>' + CDateEN(data.DocDate);
                            return html;
                        }
                    },
                    {
                        data: null, title: "PREPARING",
                        render: function (data) {
                            let html = '';
                            if (data.InvProduct !== null) data.InvProduct + '<br/>';
                            if (data.InvProductQty > 0) html += data.InvProductQty + ' ' + data.InvProductUnit + '<br/>';
                            if (data.TotalGW > 0) html += data.TotalGW + ' ' + data.GWUnit + '<br/>';
                            return html;
                        }
                    },
                    {
                        data: null, title: "AUTHORIZED",
                        render: function (data) {
                            let html = '';
                            if (data.DeclareNumber !== null) {
                                html += data.DeclareNumber;
                            } else {
                                if (data.ImExDate !== null) {
                                    html += 'SENT:' + CDateEN(data.ImExDate);
                                }
                            }
                            if (data.ClearDate !== null) {
                                if (html !== '') html += '<br/>';
                                html += 'APPR:'+CDateEN(data.ClearDate);
                            }
                            return html;
                        }
                    },
                    {
                        data: null, title: "CUSTOMS READY",
                        render: function (data) {
                            let html = '';
                            if (data.DutyAmount > 0) {
                                html += 'DUTY=' + data.DutyAmount + ' THB';
                            }
                            if (data.DutyDate !== null) {
                                if (html !== '') html += '<br/>';
                                html += 'CLEAR:'+CDateEN(data.DutyDate);
                            }
                            return html;
                        }
                    },
                    {
                        data: null, title: "DEPARTURE",
                        render: function (data) {
                            let html = '';
                            if (data.InvFCountry !== null) html += data.InvFCountry;
                            if (data.JobType == 1) {
                                if (data.InvInterPort !== null) html += '(' + data.InvInterPort + ')';
                                if (data.VesselName !== null) html += '<br/>' + data.VesselName;
                            } else {
                                if (data.ClearPort !== null) html += '(' + data.ClearPort + ')';
                            }
                            if (data.ETDDate !== null) {
                                if (html !== '') html += '<br/>';
                                html += CDateEN(data.ETDDate);
                            }
                            return html;
                        }
                    },
                    {
                        data: null, title: "ARRIVAL",
                        render: function (data) {
                            let html = '';
                            if (data.InvCountry !== null) html += data.InvCountry;
                            if (data.JobType !== 1) {
                                if (data.InvInterPort !== null) html += '(' + data.InvInterPort + ')';
                            } else {
                                if (data.ClearPort !== null) html += '(' + data.ClearPort + ')';
                                if (data.VesselName !== null) html += '<br/>' + data.VesselName;
                            }
                            if (data.ETADate !== null) {
                                if (html !== '') html += '<br/>';
                                html += CDateEN(data.ETADate);
                            }
                            return html;
                        }
                    },
                    {
                        data: null, title: "LOADING",
                        render: function (data) {
                            let html = ''
                            if (data.TruckNO !== null) html += 'TRK:' + data.TruckNO + ' ';
                            if (data.TruckType !== null) html += '(' + data.TruckType + ')<br/>';
                            if (data.CTN_SIZE !== null) html += data.CTN_SIZE + '<br/>';
                            if (data.CTN_NO !== null) html += 'CTN:' + data.CTN_NO + '';
                            if (data.SealNumber !== null) html += '#' + data.SealNumber + '';
                            if (data.LoadDate !== null) {
                                if (html !== '') html += '<br/>';
                                html += CDateEN(data.LoadDate);
                            }
                            return html;
                        }
                    },
                    {
                        data: null, title: "DELIVERED",
                        render: function (data) {
                            let html = '';
                            if (data.DeliveryNo !== null) html += 'DO:' + data.DeliveryNo + '<br/>';
                            if (data.ContactName !== null) html += 'TO:' + data.ContactName + '<br/>';
                            if (data.UnloadFinishDate !== null) {
                                html += CDateEN(data.UnloadFinishDate) + '<br/>';
                            } else {
                                if (data.EstDeliverDate !== null) {
                                    html += 'EST:' + CDateEN(data.EstDeliverDate) + '<br/>';
                                }
                            }
                            if (data.ProductQty > 0) html += 'QTY:' + data.ProductQty + ' ' + data.ProductUnit;
                            return html;
                        }
                    },
                    {
                        data: null, title: "BILLED",
                        render: function (data) {
                            if (data.consigneecode !== null) {
                                let html = 'FROM:' + data.consigneecode + '<br/>';
                                if (data.BillToCustCode !== null) html += 'TO:' + data.BillToCustCode + '<br/>';
                                return html;
                            } else {
                                return '';
                            }
                        }
                    },
                    {
                        data: null, title: "STATUS",
                        render: function (data) {
                            let html = '';
                            let status = $('#cboStatus option[value="' + CCode(data.JobStatus) + '"]').text();
                            if (status !== '') {
                                status = status.split('/')[1];
                            }
                            html = status;
                            if (data.CloseJobDate !== null) {
                                html += '<br/>' + CDateEN(data.CloseJobDate);
                            }
                            return html;
                        }
                    }
                ],
                destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                responsive:true
            });
            drawChart();
        },dbIndex);
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function drawChart() {
        let w = '?Branch=' + $('#txtBranchCode').val() + '&TaxNumber=' + $('#txtTaxNumber').val();
        $.get(path + 'JobOrder/GetTrackingSummary' + w, function (r) {
            if (r.transport.data.length > 0) {
                var custTable = google.visualization.arrayToDataTable(r.transport.data);
                var custOptions = {
                    legend: { position: 'top', maxLines: 3 },
                    chartArea: {width: '50%'},
                    hAxis: {
                      title: 'Total Job',
                      minValue: 0,
                    },
                    vAxis: {
                      title: 'Status'
                    }
                };
                var chartCust = new google.visualization.BarChart(document.getElementById('chartCust'));
                chartCust.draw(custTable, custOptions);
            }
        });
    }
    function getDataTable(dt) {
        if (dt.length > 0) {
            return dt;
        }
        dt = [["Status", "Volume"], ["ALL", 0]];
        return dt;
    }
    function getDataView(tb) {
        let dt = getDataTable(tb);
        let totalColumns = dt[0].length - 1;
        let data = google.visualization.arrayToDataTable(dt);
        let view = new google.visualization.DataView(data);
        let columns = [];
        for (let i = 0; i <= totalColumns; i++) {
            if (i > 0) {
                columns.push(i);
                columns.push({
                    calc: function (dataTable, rowIndex) {
                        return getAnnotation(dataTable, rowIndex, i);
                    },
                    type: "string",
                    role: "annotation"
                });
            } else {
                columns.push(i);
            }
        }
        view.setColumns(columns);
        return view;
    }
    function getAnnotation(dataTable, rowIndex, columnIndex) {
        return dataTable.getFormattedValue(rowIndex, columnIndex) == "0" ? null : dataTable.getFormattedValue(rowIndex, columnIndex);
    }
</script>