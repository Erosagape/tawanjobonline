
@Code
    ViewBag.Title = "Transport Tracking"
End Code
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
        <div class="col-sm-4">
            <span id="lblType">Customer</span>
            <br />
            <div style="display:flex;flex-direction:row">
                <input type="text" class="form-control" id="txtCustCode" style="width:20%" disabled />
                <input type="text" class="form-control" id="txtCustBranch" style="width:10%" disabled />
                <input type="button" class="btn btn-default" id="btnBrowseCust" value="..." onclick="SearchData('customer');" />
                <input type="text" class="form-control" id="txtCustName" style="width:60%" disabled />
            </div>
        </div>
        <div class="col-sm-4">
            Status:
            <br />
            <select id="cboStatus" class="form-control dropdown"></select>
        </div>
    </div>
<a href="#" class="btn btn-primary" id="btnShow" onclick="RefreshGrid()">
    <i class="fa fa-lg fa-filter"></i>&nbsp;<b>Show</b>
</a>
<div class="row">
    <div class="col-md-12">
        <b>Job Clearance By Later/Coming 3 Days</b>
        <div id="chartTimeLine"></div>
    </div>
</div>
<b>Transport Tracking</b>
<table id="tbDetail" class="table table-responsive">
    <thead>
        <tr>
            <th>Job Number</th>
            <th class="desktop">Customer</th>
            <th class="desktop">Booking No</th>
            <th class="all">Container No</th>
            <th class="desktop">Container Size</th>
            <th class="desktop">Route</th>
            <th class="desktop">DeliveryDate</th>
            <th class="desktop">Status</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<div id="dvLOVs"></div>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    let userGroup = '@ViewBag.UserGroup';
    let user = '@ViewBag.User';
    let vencode = '';
    if (userGroup == 'V') {
        $('#lblType').html('Vender:');
        $.get(path + 'Master/GetVender?ID=' + user).done(function (r) {
            if (r.vender.data.length > 0) {
                let dr = r.vender.data[0];
                $('#txtCustCode').val(dr.VenCode);
                $('#txtCustBranch').val(dr.BranchCode);
                $('#txtCustName').val(dr.TName);
                $('#btnBrowseCust').attr('disabled', 'disabled');
                $('#txtCustCode').attr('disabled', 'disabled');
                $('#txtCustBranch').attr('disabled', 'disabled');
            }
        });

    }
    if (userGroup == 'C') {
        $.get(path + 'Master/GetCompany?ID=' + user).done(function (r) {
            if (r.company.data.length > 0) {
                let dr = r.company.data[0];
                $('#txtCustCode').val(dr.CustCode);
                $('#txtCustBranch').val(dr.Branch);
                $('#txtCustName').val(dr.NameThai);
                $('#btnBrowseCust').attr('disabled', 'disabled');
                $('#txtCustCode').attr('disabled', 'disabled');
                $('#txtCustBranch').attr('disabled', 'disabled');

                google.charts.load("current", { packages: ["corechart"] });
                SetLOVs();
                RefreshGrid();
                window.onresize = () => {
                    drawChart();
                }
            }
        });
    } else {
        google.charts.load("current", { packages: ["corechart"] });
        SetLOVs();
        window.onresize = () => {
            drawChart();
        }
    }
    function getDataTable(dt) {
        if (dt.length > 0) {
            return dt;
        }
        dt = [["JobDay", "Volume"], ["ALL", 0]];
        return dt;
    }
    function drawChart() {
        let w = '?Branch='+ $('#txtBranchCode').val();
        if (userGroup == 'V') {
            if ($('#txtCustCode').val() !== '') {
                w += '&Vend=' + $('#txtCustCode').val();
            }
        } else {
            if ($('#txtCustCode').val() !== '') {
                w += '&Cust=' + $('#txtCustCode').val();
            }
        }
        $.get(path + 'JobOrder/GetTimelineReport' + w).done(function (r) {
            var dt = getDataTable(r.tracking.data);
            var data = new google.visualization.DataTable();
            let rows = [];
            let cols = dt[0];
            for (let i = 0; i < cols.length; i++){
                if (cols[i] == 'JobDay') {
                    data.addColumn('string', 'Date');
                } else {
                    data.addColumn('number', cols[i]);
                }
            }
            for (let i = 1; i < dt.length; i++) {
                rows.push(dt[i]);
            }
            data.addRows(rows);
            var options = {
                chart: {
                    title: 'Total Shipment By Loading Date',
                    subtitle: 'in past 7 and next 7 days',
                    chartArea: { width: '50%' }
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('chartTimeLine'));
            chart.draw(data, options);
        });
    }
    function SetLOVs() {
        let lists = 'JOB_STATUS=#cboStatus';
        loadCombos(path, lists);
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response,4);
        });
    }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
            case 'customer':
                SetGridCompany(path, '#tbCust', '#frmSearchCust', ReadCustomer);
                break;
        }
    }
    function RefreshGrid() {
        let branch = $('#txtBranchCode').val();
        let cust = $('#txtCustCode').val();
        let w = '';
        if (userGroup == 'V') {
            if (cust !== '') {
                w += '&Vend=' + cust;
            }
        } else {
            if (cust !== '') {
                w += '&Cust=' + cust;
            }
        }
        let status = $('#cboStatus').val();
        if (status !== '') {
            w += '&Status=' + status;
        }
        $.get(path + 'JobOrder/GetTransportReport?Branch=' + branch + w).done(function (r) {
            if (r.transport.data.length > 0) {
                let dr = r.transport.data;
                sortData(dr, 'JNo', 'asc');
                $('#tbDetail').DataTable({
                    data: dr,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: "JNo", title: "Job No" },
                        { data: "NotifyCode", title: "Customer" },
                        { data: "BookingNo", title: "Booking No" },
                        { data: "CTN_NO", title: "Container No" },
                        { data: "CTN_SIZE", title: "Container.Size" },
                        { data: "Location", title: "Route" },                       
                        {
                            data: null, title: "Delivery Date", render: function (data) {
                                return CDateEN(data.UnloadFinishDate);
                            }
                        },
                        { data: "TruckStatus", title: "Status" }
                    ],
                    destroy: true, //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    responsive:true
                });
                $('#tbDetail tbody').on('dblclick', 'tr', function () {
                    SetSelect('#tbDetail', this);
                    let row = $('#tbDetail').DataTable().row(this).data(); //read current row selected
                    if (userGroup !== 'V') {
                        window.open(path + 'JobOrder/ShowJob?BranchCode=' + row.BranchCode + '&JNo=' + row.JNo, '', '');
                    } else {
                        window.open(path + 'JobOrder/TruckOrder?BranchCode=' + row.BranchCode + '&BookingNo=' + row.BookingNo + '&ContainerNo=' + row.CTN_NO, '', '');
                    }
                });
            }
        });
        drawChart();
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
    }
</script>
