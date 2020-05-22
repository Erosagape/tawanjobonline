@Code
    ViewBag.Title = "สร้างใบเสร็จรับเงิน"
End Code
<div class="panel-body">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblBranch">Branch:</label>                
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
                </div>
            </div>
            <div class="col-sm-2">
                <label id="lblDocDateF">Invoice Date From:</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateF" />
            </div>
            <div class="col-sm-2">
                <label id="lblDocDateT">Invoice Date To:</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateT" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblCustCode">Customer:</label>
                <input type="checkbox" id="chkBilling"><label id="lblBilling">Search For Billing Place</label>
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtCustCode" style="width:120px" />
                    <input type="text" id="txtCustBranch" style="width:50px" />
                    <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                    <input type="text" id="txtCustName" style="width:100%" disabled />
                </div>
            </div>
        </div>
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
        </a>
        <label id="lblGroupDoc" for="chkGroupByDoc">Group By Document</label>
        <input type="checkbox" id="chkGroupByDoc" onclick="SetVisible()" />
        <div class="row" id="dvSummary" style="display:none">
            <div class="col-sm-12">
                <table id="tbSummary" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>DocNo</th>
                            <th class="desktop">DocDate</th>
                            <th class="desktop">CustCode</th>
                            <th class="desktop">RefNo</th>
                            <th class="all">Advance</th>
                        </tr>
                    </thead>
                </table>

            </div>
        </div>
        <div class="row" id="dvHeader">
            <div class="col-sm-12">
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>DocNo</th>
                            <th class="desktop">DocDate</th>
                            <th class="desktop">CustCode</th>
                            <th class="desktop">Remark</th>
                            <th class="desktop">Desc</th>
                            <th class="all">Advance</th>
                        </tr>
                    </thead>
                </table>

            </div>
        </div>
        <br />
        <a href="#" class="btn btn-success" id="btnGen" onclick="ShowSummary()">
            <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkGen">Create Receipts</b>
        </a>
    </div>
    <div id="dvCreate" class="modal modal-lg fade" role="dialog">
        <div class="modal-dialog-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-sm-3">
                            <label id="lblDocDate">Receipt Date :</label>
                            <br />
                            <input type="date" id="txtDocDate" class="form-control" value="@DateTime.Today.ToString("yyyy-MM-dd")" />
                        </div>
                        <div class="col-sm-3">
                            <label id="lblBillToCustCode">Billing Place :</label><br />
                            <input type="text" id="txtBillToCustCode" class="form-control" disabled />
                        </div>
                        <div class="col-sm-2">
                            <br />
                            <div style="display:flex">
                                <input type="text" id="txtBillToCustBranch" class="form-control" disabled />
                                <button class="btn btn-default" onclick=" SearchData('billing')">...</button>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <br />
                            <input type="text" id="txtBillToCustName" class="form-control" disabled />
                        </div>
                    </div>
                    <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-sm-2">
                            <label id="lblTotalAdvance">Total Advance:</label>                            
                            <br />
                            <input type="text" id="txtTotalAdvance" class="form-control" disabled />
                            <br />
                            <input type="checkbox" id="chkMerge" checked /><label id="lblMerge">Generate One Receipt</label> <br />
                            <div id="dvMsg"></div>
                            <a href="#" class="btn btn-success" id="btnGen" onclick="ApproveData()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Receipts</b>
                            </a>
                            <br />
                            <label id="lblDocNo">Receipt No :</label>
                            <br/><input type="text" id="txtDocNo" class="form-control" /><br />
                            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintReceipt()">
                                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Receipts</b>
                            </a>

                        </div>
                        <div class="col-sm-10">
                            <b id="lblDetail">Invoice Detail:</b><br />
                            <table id="tbDetail" class="table table-responsive" style="width:100%;">
                                <thead>
                                    <tr>
                                        <th>InvNo</th>
                                        <th class="desktop">InvDate</th>
                                        <th class="desktop">Item</th>
                                        <th class="desktop">Code</th>
                                        <th class="all">Description</th>
                                        <th class="all">Advance</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div id="dvLOVs"></div>
</div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let arr = [];
    let dtl = [];
    let dtl_list = [];
    let resp_count = 0;
    let branch = getQueryString("branch");
    let custcode = getQueryString("custcode");
    let custbranch = getQueryString("custbranch");
    if (custcode !== '') {
        $('#txtBranchCode').val(branch);
        ShowBranch(path, branch, '#txtBranchName');

        $('#txtCustCode').val(custcode);
        $('#txtCustBranch').val(custbranch);
        //ShowCustomer(path, custcode, custbranch, '#txtCustName');
        CallBackQueryCustomer(path, custcode, custbranch, ReadCustomer);
    } else {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME'); 
    }
    //$(document).ready(function () {
        SetEvents();
    //});
    function SetEvents() {
        //Events
        $('#txtBranchCode').keydown(function (event) {
            if (event.which == 13) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });
        $('#txtCustBranch').keydown(function (event) {
            if (event.which == 13) {
                $('#txtCustName').val('');
                //ShowCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), '#txtCustName');
                CallBackQueryCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), ReadCustomer);
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name', function (response) {
            let dv = document.getElementById("dvLOVs");
            //Customers
            CreateLOV(dv, '#frmSearchCust', '#tbCust', 'Customers', response, 3);
            CreateLOV(dv, '#frmSearchBill', '#tbBill', 'Billing Place', response, 3);
            //Branch
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });
    }
    function SetVisible() {
        if ($('#chkGroupByDoc').prop('checked')) {
            $('#dvSummary').css('display', 'initial');
            $('#dvHeader').css('display', 'none');
        } else {
            $('#dvSummary').css('display', 'none');
            $('#dvHeader').css('display', 'initial');
        }
        $('#tbSummary tbody > tr').removeClass('selected');
        $('#tbHeader tbody > tr').removeClass('selected');
        arr = [];
    }
    function SetGridAdv(isAlert) {
        arr = [];
        dtl = [];
        dtl_list = [];
        let w = '';
        if ($('#chkBilling').prop('checked') == true) {
            if ($('#txtCustCode').val() !== "") {
                w = w + '&billto=' + $('#txtCustCode').val();
            }
            if ($('#txtDocDateF').val() !== "") {
                w = w + '&BillDateFrom=' + CDateEN($('#txtDocDateF').val());
            }
            if ($('#txtDocDateT').val() !== "") {
                w = w + '&BillDateTo=' + CDateEN($('#txtDocDateT').val());
            }
        } else {
            if ($('#txtCustCode').val() !== "") {
                w = w + '&cust=' + $('#txtCustCode').val();
            }
            if ($('#txtDocDateF').val() !== "") {
                w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
            }
            if ($('#txtDocDateT').val() !== "") {
                w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
            }
        }
        let url = path + 'acc/getinvforreceive?show=WAIT&type=ADV&branch=' + $('#txtBranchCode').val() + w;
        $.get(url , function (r) {
            if (r.invdetail.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                $('#tbSummary').DataTable().clear().draw();
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.invdetail.data;
            dtl = r.invdetail.data;
            let s = r.invdetail.summary;
            let tb1=$('#tbSummary').DataTable({
                data: s,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "InvoiceNo", title: "Inv No" },
                    {
                        data: "InvoiceDate", title: "Inv date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "BillToCustCode", title: "Billing To" },
                    { data: "RefNo", title: "Reference Number" },
                    {
                        data: "TotalNet", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbSummary');
            $('#tbSummary tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected') == true) {
                    $(this).removeClass('selected');

                    let data = $('#tbSummary').DataTable().row(this).data();
                    let filter = $.grep(dtl,function (d) {
                        return d.InvoiceNo == data.InvoiceNo;
                    });
                    for (let d of filter) {
                        RemoveData(d);
                    }
                    return;
                }

                $(this).addClass('selected');

                let data = $('#tbSummary').DataTable().row(this).data();
                let filter = $.grep(dtl,function (d) {
                    return d.InvoiceNo == data.InvoiceNo;
                });
                for (let d of filter) {
                    AddData(d);
                }                      
            });

            let tb2=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "InvoiceNo", title: "Inv No" },
                    {
                        data: "InvoiceDate", title: "Inv date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "BillToCustCode", title: "Billing To" },
                    { data: "RefNo", title: "Reference Number" },
                    { data: "SDescription", title: "Expenses" },
                    { data: "Amt", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    }
                ],
                responsive:true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
            });
            ChangeLanguageGrid('@ViewBag.Module', '#tbHeader');
            $('#tbHeader tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected') == true) {
                    $(this).removeClass('selected');
                    let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                    RemoveData(data); //callback function from caller
                    return;
                }
                $(this).addClass('selected');
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                AddData(data); //callback function from caller
            });
        });
        $('#btnGen').removeAttr('disabled');
    }
    function ShowSummary() {
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            return;
        }

        if (arr.length == 0) {
            ShowMessage('No data to approve',true);
            return;
        }
        let totaladv = 0;


        for (let obj of arr) {
            totaladv += obj.Amt;
        }
        $('#txtTotalAdvance').val(CDbl(totaladv, 2));;

        ShowDetail();
        $('#txtDocNo').val('');
        $('#btnGen').show();
        $('#dvCreate').modal('show');
    }
    function ShowDetail() {
        let tb=$('#tbDetail').DataTable({
            data: arr,
            selected: true, //ให้สามารถเลือกแถวได้
            columns: [ //กำหนด property ของ header column
                { data: "InvoiceNo", title: "Doc No" },
                {
                    data: "InvoiceDate", title: "Inv date ",
                    render: function (data) {
                        return CDateEN(data);
                    }
                },
                { data: "ItemNo", title: "Item No" },
                { data: "SICode", title: "Code" },
                { data: "SDescription", title: "Description" },
                { data: "Amt", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                    }
                }
            ],
            responsive:true,
            destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
        });
        ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
    }
    function AddData(o) {
        arr.push(o);
    }
    function RemoveData(o) {
        let idx = arr.indexOf(o);
        if (idx < 0) {
            return;
        }
        arr.splice(idx, 1);
    }
    function DisplayMessage(str) {
        $('#dvMsg').append('<br/>' + str);
    }
    function ApproveData() {
        if ($('#txtCustCode').val() == '') {
            ShowMessage('Please choose customer first',true);
            return;
        }
        if ($('#txtBillToCustCode').val() == '') {
            ShowMessage('Please choose billing place',true);
            return;
        }
        if ($('#chkMerge').prop('checked') == true) {
            let dataInv = {
                BranchCode: $('#txtBranchCode').val(),
                ReceiptNo: $('#txtDocNo').val(),
                ReceiptDate: CDateEN($('#txtDocDate').val()),
                ReceiptType: 'ADV',
                CustCode: $('#txtCustCode').val(),
                CustBranch: $('#txtCustBranch').val(),
                BillToCustCode: $('#txtBillToCustCode').val(),
                BillToCustBranch: $('#txtBillToCustBranch').val(),
                TRemark: '',
                EmpCode: user,
                PrintedBy: '',
                PrintedDate: null,
                PrintedTime: null,
                ReceiveBy: '',
                ReceiveDate: null,
                ReceiveRef: '',
                CancelReson: '',
                CancelProve: '',
                CancelDate: null,
                CancelTime: null,
                CurrencyCode: '@ViewBag.PROFILE_CURRENCY',
                ExchangeRate: 1,
                TotalCharge: $('#txtTotalAdvance').val(),
                TotalVAT: 0,
                Total50Tavi: 0,
                TotalNet: $('#txtTotalAdvance').val(),
                FTotalNet: $('#txtTotalAdvance').val()
            };
            let jsonString = JSON.stringify({ data: dataInv });
            $.ajax({
                url: "@Url.Action("SetRcpHeader", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    if (response.result.data !== null) {
                        SaveDetail(response.result.data);
                        return;
                    }
                    DisplayMessage(response.result.msg);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        } else {
            sortData(arr, 'InvoiceNo', 'asc');
            let rowProcess = 0;
            let currInv = '';
            let dtl = [];
            dtl_list = [];
            resp_count = 0;
            $('#dvMsg').html('');
            for (let obj of arr) {
                rowProcess += 1;
                if (currInv !== obj.InvoiceNo) {
                    if (dtl.length > 0) {
                        let data = JSON.parse(JSON.stringify(dtl));
                        SaveHeaderByInv(data,currInv);
                    }
                    currInv = obj.InvoiceNo;
                    dtl = [];
                }
                dtl.push(obj);
                if (rowProcess == arr.length) {
                    let data = JSON.parse(JSON.stringify(dtl));
                    SaveHeaderByInv(data,currInv);
                }
            }
        }
        return;
    }
    function SaveHeaderByInv(dt,inv) {
        dtl_list.push({
            docno:inv,
            data: dt
        });
        let dataInv = {
            BranchCode: $('#txtBranchCode').val(),
            ReceiptNo: $('#txtDocNo').val(),
            ReceiptDate: CDateEN($('#txtDocDate').val()),
            ReceiptType: 'ADV',
            CustCode: $('#txtCustCode').val(),
            CustBranch: $('#txtCustBranch').val(),
            BillToCustCode: $('#txtBillToCustCode').val(),
            BillToCustBranch: $('#txtBillToCustBranch').val(),
            TRemark: '',
            EmpCode: user,
            PrintedBy: '',
            PrintedDate: null,
            PrintedTime: null,
            ReceiveBy: '',
            ReceiveDate: null,
            ReceiveRef: '',
            CancelReson: '',
            CancelProve: '',
            CancelDate: null,
            CancelTime: null,
            CurrencyCode: '@ViewBag.PROFILE_CURRENCY',
            ExchangeRate: 1,
            TotalCharge: $('#txtTotalAdvance').val(),
            TotalVAT: 0,
            Total50Tavi: 0,
            TotalNet: $('#txtTotalAdvance').val(),
            FTotalNet: $('#txtTotalAdvance').val()
        };
        let jsonString = JSON.stringify({ data: dataInv });
        $.ajax({
            url: "@Url.Action("SetRcpHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    SaveDetailFromArray(response.result.data, resp_count);
                    resp_count +=1;
                    return;
                }
                DisplayMessage(response.result.msg);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function SaveDetail(docno) {
        $('#txtDocNo').val(docno);
        let list = GetDataDetail(arr,docno);
        let jsonText = JSON.stringify({ data: list });
            //ShowMessage(jsonText);
        $.ajax({
            url: "@Url.Action("SaveRcpDetail", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.data !== null) {
                    DisplayMessage(response.result.msg + '\n->' + response.result.data);
                    SetGridAdv(false);
                    $('#btnGen').attr('disabled', 'disabled');
                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
    }
    function SaveDetailFromArray(docno) {
        let list = GetDataDetail(dtl_list[resp_count].data,docno);
        let jsonText = JSON.stringify({ data: list });
        $.ajax({
            url: "@Url.Action("SaveRcpDetail", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonText,
            success: function (response) {
                if (response.result.data !== null) {
                    DisplayMessage(response.result.msg + '=>' + response.result.data);
                    return;
                }
                ShowMessage(response.result.msg,true);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
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
            case 'billing':
                SetGridCompany(path, '#tbBill', '#frmSearchBill', ReadBilling);
                break;

        }
    }
    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
        $('#txtBranchCode').focus();
    }
    function ReadCustomer(dt) {
        $('#txtCustCode').val(dt.CustCode);
        $('#txtCustBranch').val(dt.Branch);
        $('#txtCustName').val(dt.NameThai);
        if (dt.BillToCustCode !== null && $('#chkBilling').prop('checked')==false) {
            CallBackQueryCustomer(path, dt.BillToCustCode, dt.BillToBranch, ReadBilling);
        } else {
            ReadBilling(dt);
        }
        $('#txtCustCode').focus();
    }
    function ReadBilling(dt) {
        $('#txtBillToCustCode').val(dt.CustCode);
        $('#txtBillToCustBranch').val(dt.Branch);
        $('#txtBillToCustName').val(dt.NameThai);
    }

    function GetDataDetail(o, no) {
        let data = [];
        let i = 0;
        for (let obj of o) {
            if (obj.TotalNet !== 0) {
                i = i + 1;
                data.push({
                    BranchCode: obj.BranchCode,
                    ReceiptNo: no,
                    ItemNo: i,
                    CreditAmount: obj.CreditAmount,
                    CashAmount: obj.CashAmount,
                    TransferAmount: obj.TransferAmount,
                    ChequeAmount: obj.ChequeAmount,
                    ControlNo: obj.ControlNo,
                    VoucherNo: obj.VoucherNo,
                    ControlItemNo:obj.ControlItemNo,
                    InvoiceNo: obj.InvoiceNo,
                    InvoiceItemNo: obj.InvoiceItemNo,
                    SICode: obj.SICode,
                    SDescription: obj.SDescription,
                    VATRate: obj.VATRate,
                    Rate50Tavi: obj.Rate50Tavi,
                    Amt: obj.Amt,
                    AmtVAT: obj.AmtVAT,
                    Amt50Tavi: obj.Amt50Tavi,
                    Net: obj.Net,
                    DCurrencyCode: obj.DCurrencyCode,
                    DExchangeRate: obj.DExchangeRate,
                    FAmt: obj.FAmt,
                    FAmtVAT: obj.FAmtVAT,
                    FAmt50Tavi: obj.FAmt50Tavi,
                    FNet:obj.FNet
                });
            }
        }
        return data;
    }

    function PrintReceipt() {
        let code = $('#txtDocNo').val();
        if (code !== '') {
            let branch = $('#txtBranchCode').val();
            window.open(path + 'Acc/FormRcp?Branch=' + branch + '&Code=' + code,'_blank');
        }
    }

</script>