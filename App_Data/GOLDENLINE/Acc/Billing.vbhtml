﻿@Code
    ViewBag.Title = "Billing Acknowledgement"
End Code
    <div class="panel-body">
        <div class="row">
            <div class="col-sm-4">
                <label id="lblBranch">Branch:</label>
                <br/>
                <div style="display:flex">
                    <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
                    <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
                </div>
            </div>
            <div class="col-sm-6">
                <label id="lblBillingPlace">Billing Place:</label>
                <br/>
                <div style="display:flex">
                    <input type="text" class="form-control" id="txtCustCode" style="width:20%" disabled />
                    <input type="text" class="form-control" id="txtCustBranch" style="width:10%" disabled />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('customer');" />
                    <input type="text" class="form-control" id="txtCustName" style="width:60%" disabled />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <label id="lblDocDateF">Bill Date From:</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateF" />
            </div>
            <div class="col-sm-2">
                <label id="lblDocDateT">Bill Date To:</label>
                <br />
                <input type="date" class="form-control" id="txtDocDateT" />
            </div>
            <div class="col-sm-3">
                <br />
                <a href="#" class="btn btn-primary" id="btnShow">
                    <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
                </a>
                <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="CreateBilling()">
                    <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkCreate">New Billing</b>
                </a>
            </div>
        </div>

        <ul class="nav nav-tabs">
            <li class="active">
                <a id="linkHeader" data-toggle="tab" href="#tabHeader">Headers</a>
            </li>
            <li>
                <a id="linkDetail" data-toggle="tab" href="#tabDetail">Details</a>
            </li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade in active" id="tabHeader">                
                <input type="checkbox" id="chkCancel" /><label id="lblCancel">Show Cancel Only</label>
                <table id="tbHeader" class="table table-responsive">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>BillNo</th>
                            <th class="desktop">BillDate</th>
                            <th class="desktop">CustCode</th>
                            <th class="desktop">BillRemark</th>
                            <th class="desktop">BillRecvDate</th>
                            <th>DuePayment</th>
                            <th class="desktop">Advance</th>
                            <th class="desktop">Charge</th>
                            <th class="desktop">VAT</th>
                            <th class="desktop">WHT</th>
                            <th class="all">Net</th>
                        </tr>
                    </thead>
                </table>
            </div>
            <div class="tab-pane fade" id="tabDetail">
                <label id="lblDocNo">Details of Billing No:</label>
                <input type="text" id="txtDocNo" class="form-control" disabled />
                <table id="tbDetail" class="table table-responsive" style="width:100%">
                    <thead>
                        <tr>
                            <th>InvNo</th>
                            <th class="desktop">InvDate</th>
                            <th class="desktop">CustAdv</th>
                            <th class="desktop">Adv</th>
                            <th class="desktop">Charge</th>
                            <th class="desktop">ChargeVat</th>
                            <th class="desktop">Disc</th>
                            <th class="desktop">WH</th>
                            <th class="desktop">VAT</th>
                            <th class="all">Total</th>
                        </tr>
                    </thead>
                </table>

                <div style="float:right">
                    <a href="#" class="btn btn-danger" id="btnDel" onclick="DeleteDetail()">
                        <i class="fa fa-lg fa-trash"></i>&nbsp;<b id="linkDelete">Delete</b>
                    </a>
                </div>
            </div>
        </div>
        <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
            <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print</b>
        </a>
        <div id="frmHeader" class="modal fade">
            <div class="modal-dialog-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div style="display:flex">
                            <div>
                                <label id="lblBillAcceptNo">Billing No:</label>
                                <br/>
                                <input type="text" id="txtBillAcceptNo" class="form-control" style="width:150px" disabled />
                            </div>
                            <div>
                                <label id="lblIssueDate">Issue Date:</label>
                                <br/>
                                <input type="date" id="txtBillDate" class="form-control" style="width:150px" disabled />
                            </div>
                            
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-6">
                                <label id="lblBCustCode">Billing To:</label>                                
                                <br />
                                <div style="display:flex">
                                    <input type="text" id="txtBCustCode" class="form-control" style="width:30%" disabled />
                                    <input type="text" id="txtBCustBranch" class="form-control" style="width:10%" disabled />
                                    <input type="text" id="txtBCustName" class="form-control" style="width:60%" disabled />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblBillRecvBy">Received By :</label>                                        
                                        <br />
                                        <div style="display:flex">
                                            <input type="text" id="txtBillRecvBy" class="form-control" /> &nbsp;
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblBillRecvDate">Confirm Date :</label>                                        
                                        <br />
                                        <div style="display:flex">
                                            <input type="date" id="txtBillRecvDate" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div style="display:flex">
                                    <div style="flex:2">
                                        <label id="lblBillRemark">Remark:</label>
                                        <br /><textarea id="txtBillRemark" class="form-control" style="width:100%"></textarea>
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblDuePaymentDate">Payment Due :</label>
                                        <br /> <input type="date" id="txtDuePaymentDate" class="form-control" />
                                    </div>
                                </div>
                                <br />
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblCancelProve">Cancel By</label>
                                        <br/>
                                        <input type="text" id="txtCancelProve" class="form-control" disabled />
                                    </div>
                                    <div style="flex:3">
                                        <label id="lblCancelReson">Reason</label>
                                        <br/>
                                        <textarea id="txtCancelReson" class="form-control" style="width:100%"></textarea>
                                    </div>
                                </div>
                                <br/>
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblCancelDate">Cancel Date</label>
                                        <br/> <input type="date" id="txtCancelDate" class="form-control" disabled /> &nbsp;
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblCancelTime">Cancel Time</label>
                                        <br/> <input type="text" id="txtCancelTime" class="form-control" disabled /> &nbsp;
                                    </div>                                    
                                    <div style="flex:1">
                                        <br />
                                        <button id="btnCancel" class="btn btn-danger" onclick="CancelData()">Cancel</button>
                                    </div>                                    
                                </div>
                            </div>     
                            <div class="col-sm-6">
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblTotalAdvance">Advance</label>                                        
                                        <br/>
                                        <div>
                                            <input type="number" id="txtTotalAdvance" class="form-control" disabled />
                                        </div>
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblTotalCustAdv">Cust.Adv</label>                                        
                                        <br/>
                                        <div>
                                            <input type="number" id="txtTotalCustAdv" class="form-control" disabled />
                                        </div>
                                    </div>
                                </div>
                                <br/>
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblTotalChargeNonVAT">Service (NON VAT)</label>
                                        <br/>
                                        <input type="number" id="txtTotalChargeNonVAT" class="form-control" disabled />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblTotalChargeVAT">Service (VAT)</label>
                                        <br/>
                                        <input type="number" id="txtTotalChargeVAT" class="form-control" disabled />
                                    </div>
                                </div>
                                <br/>
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblTotalVAT">VAT</label>                                        
                                        <br />
                                        <input type="number" id="txtTotalVAT" class="form-control" disabled />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblTotalWH">WH-Tax</label>                                        
                                        <br />
                                        <input type="number" id="txtTotalWH" class="form-control" disabled />
                                    </div>
                                </div>
                                <br/>
                                <div style="display:flex">
                                    <div style="flex:1">
                                        <label id="lblTotalDiscount">Discount</label>                                        
                                        <br/>
                                        <input type="number" id="txtTotalDiscount" class="form-control" disabled />
                                    </div>
                                    <div style="flex:1">
                                        <label id="lblTotalNet">Total</label>                                        
                                        <br />
                                        <input type="number" id="txtTotalNet" class="form-control" disabled />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div style="float:left">
                            <a href="#" class="btn btn-success" id="btnSave" onclick="SaveData()">
                                <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkUpdate">Update</b>
                            </a>
                            <a href="#" class="btn btn-info" id="btnPrint" onclick="PrintData()">
                                <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint2">Print</b>
                            </a>
                            Last update <label id="lblEmpCode"></label> At <label id="lblRecDateTime"></label>
                        </div>
                        <button id="btnHide" class="btn btn-danger" data-dismiss="modal">X</button>
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
    const userRights = '@ViewBag.UserRights';
    let row = {};
    let row_d = {};
    SetLOVs();
    $('#btnShow').on('click', function () {
        ShowHeader();
    });
    function ShowHeader() {
        let w = '';
        if ($('#txtCustCode').val() !== '') {
            w += '&cust=' + $('#txtCustCode').val();
        }
        if ($('#txtDocDateF').val() !== "") {
            w += '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w += '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        if ($('#chkCancel').prop('checked') == true) {
            w += '&show=CANCEL';
        } else {
            w += '&show=ACTIVE';
        }
        $.get(path + 'acc/getbillheader?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.billheader.data.length == 0) {
                $('#tbHeader').DataTable().clear().draw();
                if (isAlert==true) ShowMessage('Data not found',true);
                return;
            }
            let h = r.billheader.data;
            row = {};
            row_d = {};
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    {
                        data: null, title: "#",
                        render: function (data, type, full, meta) {
                            let html = "<button class='btn btn-warning'>Edit</button>";
                            return html;
                        }
                    },
                    { data: "BillAcceptNo", title: "Bill No" },
                    {
                        data: "BillDate", title: "Doc date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "CustCode", title: "Customer" },
                    { data: "BillRemark", title: "Remark" },
                    {
                        data: "BillRecvDate", title: "Confirm date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    {
                        data: "DuePaymentDate", title: "Due date ",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    {
                        data: "TotalAdvance", title: "Advance",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: null, title: "Charge",
                        render: function (data) {
                            return ShowNumber((Number(data.TotalChargeNonVAT)+Number(data.TotalChargeVAT)), 2);
                        }
                    },
                    {
                        data: "TotalVAT", title: "VAT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }
                    },
                    {
                        data: "TotalWH", title: "WHT",
                        render: function (data) {
                            return ShowNumber(data, 2);
                        }                        
                    },
                    {
                        data: "TotalNet", title: "NET",
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
                row = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                SetSelect('#tbHeader', this);
                row_d = {};
                ReadData();
                ShowDetail(row.BranchCode, row.BillAcceptNo);
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                $('a[href="#tabDetail"]').click();
            });
            $('#tbHeader tbody').on('click', 'button', function () {
                if (userRights.indexOf('E') > 0) {
                    $('#frmHeader').modal('show');
                } else {
                    ShowMessage('You are not allow to edit',true);
                }
            });
        });
    }
    function PrintData() {
        let code = row.BillAcceptNo;
        if (code !== '') {

            let branch = row.BranchCode;
            window.open(path + 'Acc/FormBill?Branch=' + branch + '&Code=' + code, '_blank');
        }
    }
    function ReadData() {
        $('#txtDocNo').val(row.BillAcceptNo);
        $('#txtBillAcceptNo').val(row.BillAcceptNo);
        $('#txtBillDate').val(CDateEN(row.BillDate));
        $('#txtBCustCode').val(row.CustCode);
        $('#txtBCustBranch').val(row.CustBranch);
        ShowCustomer(path, row.CustCode, row.CustBranch, '#txtBCustName');
        $('#txtBillRecvBy').val(row.BillRecvBy);
        $('#txtBillRecvDate').val(CDateEN(row.BillRecvDate));
        $('#txtDuePaymentDate').val(CDateEN(row.DuePaymentDate));
        $('#txtBillRemark').val(row.BillRemark);
        $('#txtCancelReson').val(row.CancelReson);
        $('#txtCancelProve').val(row.CancelProve);
        $('#txtCancelDate').val(CDateEN(row.CancelDate));
        $('#txtCancelTime').val(ShowTime(row.CancelTime));
        $('#lblEmpCode').text(row.EmpCode);
        $('#lblRecDateTime').text(ShowDate(row.RecDateTime));
        $('#txtTotalAdvance').val(CDbl(row.TotalAdvance, 2));
        $('#txtTotalCustAdv').val(CDbl(row.TotalCustAdv, 2));
        $('#txtTotalChargeVAT').val(CDbl(row.TotalChargeVAT, 2));
        $('#txtTotalChargeNonVAT').val(CDbl(row.TotalChargeNonVAT, 2));
        $('#txtTotalVAT').val(CDbl(row.TotalVAT, 2));
        $('#txtTotalWH').val(CDbl(row.TotalWH, 2));
        $('#txtTotalDiscount').val(CDbl(row.TotalDiscount, 2));
        $('#txtTotalNet').val(CDbl(row.TotalNet, 2));
    }
    function CancelData() {
        if (userRights.indexOf('D') > 0) {
            if ($('#txtCancelReson').val() == '') {
                ShowMessage('Please enter reason for cancel',true);
                $('#txtCancelReson').focus();
                return;
            }
            $('#txtCancelDate').val(GetToday());
            $('#txtCancelTime').val(ShowTime(GetTime()));
            $('#txtCancelProve').val(user);
        } else {
            ShowMessage('You are not allow to cancel',true);
        }
    }
    function SaveData() {
        if (row !== null) {
            row.BillRemark = $('#txtBillRemark').val();
            row.BillRecvBy = $('#txtBillRecvBy').val();
            row.BillRecvDate = CDateEN($('#txtBillRecvDate').val());
            row.DuePaymentDate = CDateEN($('#txtDuePaymentDate').val());
            row.CancelDate = CDateEN($('#txtCancelDate').val());
            row.CancelTime = $('#txtCancelTime').val();
            row.CancelProve = $('#txtCancelProve').val();
            row.CancelReson = $('#txtCancelReson').val();
            row.EmpCode = user;
            row.RecDateTime = CDateEN(GetToday());

            let jsonString = JSON.stringify({ data: row });
            $.ajax({
                url: "@Url.Action("SetBillHeader", "Acc")",
                type: "POST",
                contentType: "application/json",
                data: jsonString,
                success: function (response) {
                    if (response.result.data !== null) {
                        
                        ShowMessage(response.result.data);
                        $('#frmHeader').modal('hide');
                        return;
                    }
                    ShowMessage(response.result.msg,true);
                },
                error: function (e) {
                    ShowMessage(e,true);
                }
            });
        }
    }
    function ShowDetail(branch, code) {
        $('#tbDetail').DataTable().clear().draw();
        $.get(path + 'Acc/GetBillDetail?Branch=' + branch + '&Code=' + code, function (r) {
            if (r.billdetail.data.length > 0) {
                let d = r.billdetail.data;
                let tb=$('#tbDetail').DataTable({
                    data: d,
                    selected: true,
                    columns: [
                        { data: "InvNo", title: "Inv.No" },
                        {
                            data: null, title: "Inv.Date",
                            render: function (data) {
                                return CDateEN(data.InvDate);
                            }
                        },
                        {
                            data: "AmtCustAdvance", title: "Cust.Adv",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }  
                        },
                        { data: "AmtAdvance", title: "Advance",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtChargeNonVAT", title: "Service",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtChargeVAT", title: "Service (VAT)",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtDiscount", title: "Discount",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtWH", title: "WH-Tax",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtVAT", title: "VAT",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        { data: "AmtTotal", title: "Total",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        }
                    ],
                    responsive:true,
                    destroy:true
                });
                ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');
                $('#tbDetail tbody').on('click', 'tr', function () {
                    SetSelect('#tbDetail', this);
                    row_d = $('#tbDetail').DataTable().row(this).data();
                });
            }
        });
    }
    function DeleteDetail() {
        if (row_d.ItemNo !== undefined) {
            ShowConfirm('Please confirm to delete', function (result) {
                if (result == true) {
                    $.get(path + 'Acc/DelBillDetail?Branch=' + row.BranchCode + '&Code=' + row.BillAcceptNo + '&Item=' + row_d.ItemNo)
                    .done(function (r) {
                        if (r.billdetail.data !== null) {
                            ShowDetail(row.BranchCode, row.BillAcceptNo);
                        }
                        ShowMessage(r.billdetail.result);
                    });
                }                
            });
        } else {
            ShowMessage('No data to cancel',true);
        }

    }
    function SetLOVs() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocDateF').val(GetFirstDayOfMonth());
        $('#txtDocDateT').val(GetLastDayOfMonth());
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
    function CreateBilling() {
        let w = '?branch=' + $('#txtBranchCode').val();
        if ($('#txtCustCode').val() !== '') {
            w += '&custcode=' + $('#txtCustCode').val() + '&custbranch=' + $('#txtCustBranch').val();
        }        
        window.open(path +'Acc/GenerateBilling' + w, '_blank');
    }
</script>

