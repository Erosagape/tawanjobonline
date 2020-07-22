@Code
    ViewBag.Title = "สร้างใบวางบิล"
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
                <label id="lblDocDateT">Invoice Date To</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateT" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <label id="lblCustCode">Billing Place</label>                
                <br />
                <div style="display:flex;flex-direction:row">
                    <input type="text" id="txtCustCode" style="width:120px" />
                    <input type="text" id="txtCustBranch" style="width:50px" />
                    <button id="btnBrowseCust" class="btn btn-default" onclick="SearchData('customer')">...</button>
                    <input type="text" id="txtCustName" style="width:100%" disabled />
                </div>
            </div>
            <div class="col-sm-3">
                <br />
                <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>DocNo</th>
                            <th class="desktop">DocDate</th>
                            <th class="desktop">CustCode</th>
                            <th class="desktop">Remark</th>
                            <th class="desktop">Cust.Adv</th>
                            <th class="all">Advance</th>
                            <th class="all">Charge</th>
                            <th class="desktop">VAT</th>
                            <th class="desktop">WHT</th>
                            <th class="all">Net</th>
                        </tr>
                    </thead>
                </table>
                <br />
                <a href="#" class="btn btn-success" id="btnGen" onclick="ShowSummary()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkGen">Create Billing</b>
                </a>
            </div>
        </div>
    </div>
    <div id="dvCreate" class="modal modal-lg fade" role="dialog">
        <div class="modal-dialog-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-sm-3">
                            <label id="lblDocDate">Billing Date</label>
                            <br />
                            <input type="date" id="txtDocDate" class="form-control" value="@DateTime.Today.ToString("yyyy-MM-dd")" />
                        </div>
                        <div class="col-sm-3">
                            <a id="lblBillToCustCode" href="#" onclick="SearchData('billing')">Billing Place :</a><br />
                            <input type="text" id="txtBillToCustCode" class="form-control" disabled />
                        </div>
                        <div class="col-sm-2">
                            <br />
                            <input type="text" id="txtBillToCustBranch"  class="form-control" disabled />
                        </div>
                        <div class="col-sm-4">
                            <br />
                            <input type="text" id="txtBillToCustName"  class="form-control" disabled />
                        </div>
                    </div>
                    <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
                </div>
                <div class="modal-body">
                    <b id="lblBillSummary">Billing Summary:</b><br />
                    <div class="row">
                        <div class="col-sm-4">
                            <table style="width:100%">
                                <tr><td id="lblTotalAdvance">Advance </td><td><input type="text" id="txtTotalAdvance" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalCharge">Charge</td><td><input type="text" id="txtTotalCharge" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalIsTaxCharge">Vatable</td><td><input type="text" id="txtTotalIsTaxCharge" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalIs50Tavi">Taxable</td><td><input type="text" id="txtTotalIs50Tavi" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalVat">VAT</td><td><input type="text" id="txtTotalVat" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalAfter">After VAT</td><td><input type="text" id="txtTotalAfter" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotal50Tavi">WHT</td><td><input type="text" id="txtTotal50Tavi" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalService">After WHT</td><td><input type="text" id="txtTotalService" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalCustAdv">Cust.Advance</td><td><input type="text" id="txtTotalCustAdv" class="form-control" disabled /></td></tr>
                                <tr><td id="lblTotalNet">NET</td><td><input type="text" id="txtTotalNet" class="form-control" disabled /></td></tr>
                            </table>
                            <a href="#" class="btn btn-success" id="btnGen" onclick="SaveData()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkSave">Save Billing</b>
                            </a>
                            <br/>
                            <label id="lblDocNo">Billing No :</label>
                            <br/>
                            <input type="text" id="txtDocNo" />
                            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintBilling()">
                                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Billing</b>
                            </a>
                        </div>
                        <div class="col-sm-8">
                            <b id="lblDetail">Billing Detail:</b><br />
                            <table id="tbDetail" style="width:100%;">
                                <thead>
                                    <tr>
                                        <th>InvNo</th>
                                        <th class="desktop">InvDate</th>
                                        <th class="all">Advance</th>
                                        <th class="all">Transport</th>
                                        <th class="all">Service</th>
                                        <th class="desktop">VAT</th>
                                        <th class="desktop">WH-Tax</th>
                                        <th class="all">Net</th>
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
    let  arr = [];
    //$(document).ready(function () {
    //});
    let branch = getQueryString("branch");
    let custcode = getQueryString("custcode");
    let custbranch = getQueryString("custbranch");
    let creditdays = 0;
    if (custcode !== '') {
        $('#txtBranchCode').val(branch);
        ShowBranch(path, branch, '#txtBranchName');

        $('#txtCustCode').val(custcode);
        $('#txtCustBranch').val(custbranch);
        //ShowCustomer(path, custcode, custbranch, '#txtCustName');
        CallBackQueryCustomer(path, $('#txtCustCode').val(), $('#txtCustBranch').val(), ReadCustomer);
    } else {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME'); 
    }
    SetEvents();
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
    function SetGridAdv(isAlert) {
        arr = [];

        let w = '';
        if ($('#txtCustCode').val() !== "") {
            w = w + '&Bill=' + $('#txtCustCode').val();
        }
        if ($('#txtDocDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        $.get(path + 'acc/getinvforbill?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.invdetail.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.invdetail.data;
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "DocNo", title: "Inv No" },
                    {
                        data: "DocDate", title: "Inv date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "RefNo", title: "Reference Number" },
                    { data: "TotalCustAdv", title: "Cust.Adv",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalAdvance", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalCharge", title: "Charge",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalVAT", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "Total50Tavi", title: "WHT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    { data: "TotalNet", title: "NET",
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
        let totalcharge = 0;
        let totalistaxcharge = 0;
        let totalis50tavi = 0;
        let totalvat = 0;
        let total50tavi = 0;
        let totalcustadv = 0;
        let totalnet = 0;

        for (let obj of arr) {
            totaladv += obj.TotalAdvance;
            totalcharge += obj.TotalCharge;
            totalistaxcharge += obj.TotalIsTaxCharge;
            totalis50tavi += obj.TotalIsTaxCharge;
            totalvat += obj.TotalVAT;
            total50tavi += obj.Total50Tavi;
            totalcustadv += obj.TotalCustAdv;
            totalnet += obj.TotalNet;
        }
        $('#txtTotalAdvance').val(CDbl(totaladv, 2));
        $('#txtTotalCharge').val(CDbl(totalcharge, 2));
        $('#txtTotalIsTaxCharge').val(CDbl(totalistaxcharge, 2));
        $('#txtTotalIs50Tavi').val(CDbl(totalis50tavi, 2));
        $('#txtTotalVat').val(CDbl(totalvat, 2));
        $('#txtTotalAfter').val(CDbl(totalcharge+totalvat, 2));
        $('#txtTotal50Tavi').val(CDbl(total50tavi, 2));
        $('#txtTotalService').val(CDbl(totalcharge+totalvat-total50tavi, 2));
        $('#txtTotalNet').val(CDbl(totalnet, 2));
        $('#txtTotalCustAdv').val(CDbl(totalcustadv, 2));

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
                { data: "DocNo", title: "Doc No" },
                {
                    data: "DocDate", title: "Inv date ",
                    render: function (data) {
                        return CDateEN(data);
                    }
                },
                { data: "TotalAdvance", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                    }
                },
                { data: "TotalNonVat", title: "Transport",
                        render: function (data) {
                            return ShowNumber(data, 2);
                    }
                },
                { data: "TotalIsTaxCharge", title: "Service",
                        render: function (data) {
                            return ShowNumber(data, 2);
                    }
                },
                { data: "TotalVAT", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                    }
                },
                { data: "Total50Tavi", title: "WHT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                    }
                },
                { data: "TotalNet", title: "NET",
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
    function CalTotal() {
        let totalnet = CNum($('#txtTotalAdvance').val()) + CNum($('#txtTotalCharge').val()) + CNum($('#txtTotalVat').val()) - CNum($('#txtTotal50Tavi').val()) - CNum($('#txtTotalCustAdv').val());
        $('#txtTotalNet').val(totalnet);

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
    function ApproveData() {
        if ($('#txtBillToCustCode').val() == '') {
            ShowMessage('Please choose billing place',true);
            return;
        }
        let dataInv = {
            BranchCode:$('#txtBranchCode').val(),
            BillAcceptNo: $('#txtDocNo').val(),
            BillDate: CDateEN($('#txtDocDate').val()),
            CustCode:$('#txtBillToCustCode').val(),
            CustBranch:$('#txtBillToCustBranch').val(),
            BillRecvBy: '',
            BillRecvDate: null,
            DuePaymentDate: null,
            BillRemark:'',
            CancelReson:'',
            CancelProve:'',
            CancelDate:null,
            CancelTime: null,
            EmpCode: user,
            RecDateTime:CDateEN(GetToday())
        };
        let jsonString = JSON.stringify({ data: dataInv });
        $.ajax({
            url: "@Url.Action("SetBillHeader", "Acc")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                if (response.result.data !== null) {
                    SaveDetail(response.result.data);
                    return;
                }
                ShowMessage(response.result.msg);
            },
            error: function (e) {
                ShowMessage(e,true);
            }
        });
        return;
    }
    function SaveDetail(docno) {
        $('#txtDocNo').val(docno);
        let list = GetDataDetail(arr,docno);
        let jsonText = JSON.stringify({ data: list });
            //ShowMessage(jsonText);
            $.ajax({
                url: "@Url.Action("SetBillDetail", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonText,
                success: function (response) {
                    if (response.result.data !== null) {
                        ShowMessage(response.result.msg+'\n->'+response.result.data);
                        SetGridAdv(false);
                        $('#btnGen').hide();
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
        //ShowCustomer(path, dt.CustCode, dt.Branch, '#txtCustName');
        $('#txtBillToCustName').val(dt.NameThai);
        $('#txtCustName').val(dt.NameThai);
        $('#txtBillToCustCode').val(dt.CustCode);
        $('#txtBillToCustBranch').val(dt.Branch);
        $('#txtCustCode').focus();
        creditdays = CNum(dt.CreditLimit);
    }
    function ReadBilling(dt) {
        $('#txtBillToCustCode').val(dt.CustCode);
        $('#txtBillToCustBranch').val(dt.Branch);
        ShowCustomer(path, dt.CustCode, dt.Branch, '#txtBillToCustName');
        creditdays = CNum(dt.CreditLimit);
    }

    function GetDataDetail(o, no) {
        let data = [];
        let i = 0;
        for (let obj of o) {
            //if (obj.TotalNet !== 0) {
                i = i + 1;
                data.push({
                    BranchCode: obj.BranchCode,
                    BillAcceptNo: no,
                    ItemNo: i,
                    InvNo: obj.DocNo,
                    InvDate: obj.DocDate,
                    RefNo:obj.RefNo,
                    CurrencyCode: obj.CurrencyCode,
                    ExchangeRate: obj.ExchangeRate,
                    AmtAdvance: obj.TotalAdvance,
                    AmtChargeNonVAT: obj.TotalNonVat,
                    AmtChargeVAT: obj.TotalIsTaxCharge,
                    AmtVAT: obj.TotalVAT,
                    AmtVATRate:obj.VATRate,
                    AmtWH: obj.Total50Tavi,
                    AmtWHRate: (Number(obj.Total50Tavi) > 0 ? (((Number(obj.TotalCharge) / Number(obj.Total50Tavi))/100)==1 ? 1 :3) : 0),
                    AmtTotal: obj.TotalNet,
                    AmtCustAdvance: obj.TotalCustAdv,
                    AmtDiscount: obj.TotalDiscount,
                    AmtDiscRate: obj.DiscountRate,
                    AmtForeign: obj.ForeignNet
                });
            //}
        }
        return data;
    }
    function SaveData() {
        if ($('#txtDocNo').val() !== '') {
            $.get(path + 'Acc/DelBillDetail?Branch' + $('#txtBranchCode').val() + '&Code=' + $('#txtDocNo').val()).done(function (r) {
                ApproveData();
            });
        } else {
            ApproveData();
        }
    }
    function PrintBilling() {
        let code = $('#txtDocNo').val();
        if (code !== '') {
            let branch = $('#txtBranchCode').val();
            window.open(path + 'Acc/FormBill?Branch=' + branch + '&Code=' + code);
        }
    }

</script>