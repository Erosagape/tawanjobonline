@Code
    ViewData("Title") = "Customers"
End Code
<input id="btnShow" type="button" value="Show List" onclick="LoadGrid()" />
<table id="tbCustomer" class="table table-responsive">
    <thead>
        <tr>
            <th>#</th>
            <th>CustID</th>
            <th>CustName</th>
            <th>CustContact</th>
            <th>CustTelFaxMobile</th>
            <th>ExpireDate</th>
            <th>Active</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<div id="dvEditor">
    <div class="row">
        <div class="col-md-4">
            Customer ID
        </div>
        <div class="col-md-8">
            <input type="text" id="txtCustID" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Customer Name
        </div>
        <div class="col-md-8">
            <input type="text" id="txtCustName" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Cust.Tax-ID
        </div>
        <div class="col-md-8">
            <input type="text" id="txtCustTaxID" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Cust.Address
        </div>
        <div class="col-md-8">
            <input type="text" id="txtCustAddress" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Cust.Contact
        </div>
        <div class="col-md-8">
            <input type="text" id="txtCustContact" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Cust.Tel/Fax/Mobile
        </div>
        <div class="col-md-8">
            <input type="text" id="txtCustTelFaxMobile" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            M/A Begin Date
        </div>
        <div class="col-md-8">
            <input type="text" id="txtBeginDate" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            M/A End Date
        </div>
        <div class="col-md-8">
            <input type="text" id="txtExpireDate" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            
        </div>
        <div class="col-md-8">
            <input type="checkbox" id="chkIsActive" />Active
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Cust.Remark
        </div>
        <div class="col-md-8">
            <textarea id="txtCustRemark" class="form-control"></textarea>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Message
        </div>
        <div class="col-md-8">
            <textarea id="txtCustMessage" class="form-control"></textarea>
        </div>
    </div>
    <input type="button" id="btnSave" class="btn btn-success" value="Save Data" onclick="SaveData()" />
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let rows = [];
    SetEvents();
    function SetEvents() {
        $('#tbCustomer').hide();
        $('#txtCustID').keydown((e) => {
            if (e.which == 13) {
                FindData();
            }
        });
    }
    function FindData() {
        let code = $('#txtCustID').val();
        getData(path +'Config/GetCustomer?Code=' + code,(r)=> {
            if (r !== null) {
                LoadData(r[0]);
            }
        });
    }
    function LoadGrid() {
        getData(path +'Config/GetCustomer',(r)=> {
            if (r !== null) {
                rows = r;
                let html = '';
                let i = 0;
                for (let o of r) {
                    i += 1;
                    html += '<tr>';
                    html += '<td><a href="/CustApp?Cust='+ o.CustID +'">' + i +'</a></td>';
                    html += '<td><a href="#" onclick="ShowData('+ (i-1) +')">' + o.CustID + '</a></td>';
                    html += '<td>' + o.CustName + '</td>';
                    html += '<td>' + o.CustContact + '</td>';
                    html += '<td>' + o.CustTelFaxMobile + '</td>';
                    if (o.ExpireDate !== null) {
                        html += '<td>' + o.ExpireDate.substr(0, 10) + '</td>';
                    } else {
                        html += '<td></td>';
                    }
                    html += '<td>' + o.Active + '</td>';
                    html += '</tr>';
                }
                $('#tbCustomer tbody').html(html);
                $('#tbCustomer').show();
            }
        });
    }
    function LoadData(dr) {
        $('#txtCustID').val(dr.CustID);
        $('#txtCustName').val(dr.CustName);
        $('#txtCustAddress').val(dr.CustAddress);
        $('#txtCustContact').val(dr.CustContact);
        $('#txtCustTelFaxMobile').val(dr.CustTelFaxMobile);
        $('#txtBeginDate').val(ShowDate(dr.BeginDate));
        $('#txtExpireDate').val(ShowDate(dr.ExpireDate));
        if (dr.Active == true) {
            $('#chkIsActive').prop('checked', true);
        } else {
            $('#chkIsActive').prop('checked', false);
        }
        $('#txtCustRemark').val(dr.CustRemark);
        $('#txtCustMessage').val(dr.CustMessage);
    }
    function ShowData(idx) {
        if (rows.length > idx) {
            LoadData(rows[idx]);
        }
    }
    function SaveData() {
        let obj = {
            CustID: $('#txtCustID').val(),
            CustName: $('#txtCustName').val(),
            CustTaxID: $('#txtCustTaxID').val(),
            CustAddress: $('#txtCustAddress').val(),
            CustContact: $('#txtCustContact').val(),
            CustTelFaxMobile: $('#txtCustTelFaxMobile').val(),
            BeginDate: CDateEN(ReverseDate($('#txtBeginDate').val())),
            ExpireDate: CDateEN(ReverseDate($('#txtExpireDate').val())),
            Active: $('#chkIsActive').prop('checked'),
            CustRemark: $('#txtCustRemark').val(),
            CustMessage: $('#txtCustMessage').val()
        }
        let json = JSON.stringify({ data: obj });

        postData(path + 'Config/SetCustomer', json, (msg) => {
            LoadGrid();
            alert(msg);
        });
    }
</script>