
@Code
    ViewBag.Title = "Job Summary"
End Code
<div class="row">
    <div class="col-sm-3">
        <label id="lblBranch">Branch</label>        
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtBranchCode" style="width:60px" disabled />
            <input type="text" class="form-control" id="txtBranchName" style="width:100%" disabled />
        </div>
    </div>
    <div class="col-sm-2">
        <label id="lblJobNo">Job No:</label>        
        <br/>
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtJNo" disabled />
        </div>
    </div>
    <div class="col-sm-3">
        <label id="lblCloseDate">Close Date :</label>        
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="date" id="txtCloseDate" class="form-control" disabled />
        </div>
    </div>
    <div class="col-sm-4">
        <label id="lblJobStatus">Job Status:</label>        
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtJobStatus" style="background-color:lightgoldenrodyellow;color:red;" disabled />
        </div>
    </div>
</div>
<table id="tbDetail" class="table table-responsive">
    <thead>
        <tr>
            <th width="5%">#</th>
            <th width="10%">Clear.No</th>
            <th width="8%">Exp.Code</th>
            <th width="30%">Description</th>
            <th width="10%">Inv.No</th>
            <th width="8%">Advance</th>
            <th width="8%">Charges</th>
            <th width="8%">Cost</th>
            <th width="8%">Profit</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<div class="row">
    <div class="col-sm-3">
        <label id="lblService">Service</label>
         : <input type="text" id="txtSumService" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblAdvance">Advance</label>
         :<input type="text" id="txtSumAdvance" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblCost">Cost</label>
         :<input type="text" id="txtSumCost" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblProfit">Profit</label>
         :<input type="text" id="txtSumProfit" class="form-control" disabled />
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        <label id="lblBaseVat">Vatable</label>
         :<input type="text" id="txtSumBaseVAT" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblNonVat">Non-vat</label>
         :<input type="text" id="txtSumNonVAT" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblVat">VAT</label>
         :<input type="text" id="txtSumVAT" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblWhTax">W/H-Tax</label>
         :<input type="text" id="txtSumWHT" class="form-control" disabled />
    </div>
</div>
<div class="row">
    <div class="col-sm-3">
        <label id="lblSumCharge">Chargeable</label>
         :<input type="text" id="txtSumCharge" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblInv">Invoiced</label>
         :<input type="text" id="txtSumInvoice" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblSumClear">Cleared</label>
         :<input type="text" id="txtSumClear" class="form-control" disabled />
    </div>
    <div class="col-sm-3">
        <label id="lblPending">Pending</label>
         :<input type="text" id="txtSumPending" class="form-control" disabled />
    </div>
</div>
<a href="#" class="btn btn-success" id="btnGenerateInv">
    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkGen">Generate Invoice</b>
</a>
<a href="#" class="btn btn-info" id="btnPrintJobsum">
    <i class="fa fa-lg fa-print"></i>&nbsp;<b id="linkPrint">Print Summary</b>
</a>
<div class="modal fade" id="dvEditor" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <label id="lblSetInv">Set Invoice To</label>
                 <label id="lblClrNo"></label> # <label id="lblItemNo"></label>
            </div>
            <div class="modal-body">
                <input type="text" id="txtInvoiceNo" />
                <a href="#" class="btn btn-success" id="btnUpdateInv" onclick="UpdateInvoice()">
                    <i class="fa fa-lg fa-save"></i>&nbsp;<b id="linkUpdate">Update Invoice</b>
                </a>
            </div>
            <div class="modal-footer">
                <button id="btnHide" class="btn btn-danger" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let user = '@ViewBag.User';
    let branch = getQueryString('branchcode');
    let code = getQueryString('jno');
    if (branch != "" && code != "") {
        $('#txtBranchCode').val(branch);
        $('#txtJNo').val(code);
        RefreshGrid();
    }
    $('#tbDetail tbody').on('dblclick', 'tr', function () {
        let clearno = $(this).find('td:eq(1)').text().split('#')[0];
        //ShowMessage('you click ' + clearno);
        window.open(path + 'Clr/Index?BranchCode=' + $('#txtBranchCode').val() + '&ClrNo=' + clearno);
    });
    $('#btnPrintJobsum').on('click', function () {
        window.open(path + 'JobOrder/FormJobSum?branchcode=' + $('#txtBranchCode').val() + '&JNo=' + $('#txtJNo').val(),'','');
    });
    $('#btnGenerateInv').on('click', function () {
        window.open(path + 'Clr/GenerateInv?branch=' + $('#txtBranchCode').val() + '&code=' + $('#txtJNo').val(),'','');
    });
    function RefreshGrid() {
        ShowWait();
        $.get(path + 'clr/getclearingreport?branch=' + branch + '&job=' + code, function (r) {
            if (r.data[0].Table !== undefined) {
                let h = r.data[0].Table[0];
                $('#txtBranchCode').val(h.BranchCode);
                $('#txtBranchName').val(h.BranchName);
                $('#txtJNo').val(h.JobNo);
                $('#txtCloseDate').val(CDateEN(h.CloseJobDate));
                if (h.CloseJobBy !== '') {
                    $('#btnGenerateInv').removeAttr('disabled');
                } else {
                    $('#btnGenerateInv').attr('disabled', 'disabled');
                }
                $('#txtJobStatus').val(h.JobStatusName);

                let html = '';

                let amtforvat = 0;
                let amtnonvat = 0;
                let amtvat = 0;
                let amtwht = 0;
                let amtcharge = 0;
                let amtadvance = 0;
                let amttotal = 0;
                let amtprofit = 0;
                let amtcost = 0;
                let amtinv = 0;
                let amtclear = 0;
                let amtpending = 0;

                let d = r.data[0].Table.filter(function (data) {
                    return data.BNet !== 0;
                });
                for (let i = 0; i < d.length; i++){
                    let amt = d[i].UsedAmount + d[i].ChargeVAT;
                    let adv = (d[i].IsCredit == 1 && d[i].IsExpense == 0 ? amt : 0);
                    let serv = (d[i].IsCredit == 0 && d[i].IsExpense == 0 ? d[i].UsedAmount : 0);
                    let cost = (d[i].IsExpense == 1 ?  d[i].UsedAmount : 0);
                    let profit = (d[i].IsExpense == 1 ?  d[i].UsedAmount*-1 : d[i].IsCredit==1 ? 0 : d[i].UsedAmount);
                    let slipNo = (d[i].IsHaveSlip == 1 && d[i].IsCredit==1 ? ' #' + d[i].SlipNO : '');

                    if (d[i].IsCredit == 0 && d[i].IsExpense == 0) {
                        if (d[i].IsTaxCharge > 0) {
                            amtforvat += d[i].UsedAmount;
                            amtvat += d[i].ChargeVAT;
                            slipNo += '<br/>VAT ' + d[i].VATRate + '%=' + d[i].ChargeVAT;
                        } else {
                            amtnonvat += d[i].UsedAmount;
                        }
                        if (d[i].Is50Tavi > 0) {
                            amtwht += d[i].Tax50Tavi;
                            slipNo += '<br/>WH-Tax ' + d[i].Tax50TaviRate + '%=' + d[i].Tax50Tavi;
                        }
                    }


                    html += '<tr>';
                    if ((d[i].LinkBillNo == '' ||d[i].LinkBillNo == null ) && cost >0) {
                        html += '<td><input type="button" value="Edit" onclick="OpenEditor(' + "'" + d[i].ClrNo + "'" + ',' + d[i].ItemNo + ')"/></td>';
                    } else {
                        html += '<td><input type="button" value="View" onclick="OpenInvoice(' + "'" + d[i].BranchCode + "'" + ',' + "'" + d[i].LinkBillNo + "'" + ')"/></td>';
                    }
                    html += '<td>' + d[i].ClrNo + '#' + d[i].ItemNo + '</td>';
                    html += '<td>'+d[i].SICode+'</td>';
                    html += '<td>' + d[i].SDescription + '' + slipNo + '</td>';
                    if (d[i].LinkBillNo == '' || d[i].LinkBillNo == '') {
                        html += '<td></td>';
                        amtpending += amt;
                    } else {
                        if (d[i].LastReceipt !== null) {
                            html += '<td>' + d[i].LinkBillNo + '-' + d[i].LinkItem + '<br/>';
                            html += d[i].LastReceipt + '</td>';
                        } else {
                            html += '<td>' + d[i].LinkBillNo + '-' + d[i].LinkItem + '</td>';
                        }
                        if (cost > 0) {
                            amtclear += amt;
                        } else {
                            amtinv += amt;
                        }
                    }
                    html += '<td>'+ ShowNumber(adv,2) +'</td>';
                    html += '<td>'+ ShowNumber(serv,2) +'</td>';
                    html += '<td>' + ShowNumber(cost,2) + '</td>';
                    html += '<td>' + ShowNumber(profit,2) + '</td>';
                    html += '</tr>';

                    amtadvance += adv;
                    amtcharge += serv;
                    amtcost += cost;
                    amttotal += serv + adv;
                    amtprofit += profit;
                }
                $('#tbDetail tbody').html(html);
                ChangeLanguageGrid('@ViewBag.Module', '#tbDetail');

                $('#txtSumBaseVAT').val(ShowNumber(amtforvat,2));
                $('#txtSumNonVAT').val(ShowNumber(amtnonvat,2));
                $('#txtSumVAT').val(ShowNumber(amtvat,2));
                $('#txtSumWHT').val(ShowNumber(amtwht, 2));

                $('#txtSumService').val(ShowNumber(amtcharge,2));
                $('#txtSumAdvance').val(ShowNumber(amtadvance, 2));
                $('#txtSumCost').val(ShowNumber(amtcost, 2));
                $('#txtSumProfit').val(ShowNumber(amtprofit, 2));

                $('#txtSumCharge').val(ShowNumber(amttotal, 2));
                $('#txtSumInvoice').val(ShowNumber(amtinv, 2));
                $('#txtSumClear').val(ShowNumber(amtclear, 2));

                $('#txtSumPending').val(ShowNumber(amtpending, 2));

            }
            CloseWait();
        });
    }
    function OpenInvoice(branch,code) {
        window.open(path + 'Acc/FormInv?Branch=' + branch + '&Code=' + code,'_blank');
    }
    function OpenEditor(clrno, item) {
        //ShowMessage('you click ' + clrno + '/' + item);
        $('#lblClrNo').text(clrno);
        $('#lblItemNo').text(item);
        $('#dvEditor').modal('show');
    }
    function UpdateInvoice() {
        let clrno = $('#lblClrNo').text();
        let item = $('#lblItemNo').text();
        $.get(path + 'Clr/GetClrDetail?Branch=' + $('#txtBranchCode').val() + '&Code=' + clrno + '&Item=' + item)
            .done(function (r) {
                if (r.clr.detail.length > 0) {
                    let dr = r.clr.detail[0];
                    dr.LinkBillNo = $('#txtInvoiceNo').val();
                    dr.LinkItem = 0;
                    SaveClrDetail(dr);
                }
            });
    }
    function SaveClrDetail(dr) {
        let jsonString = JSON.stringify({ data: dr });
        $.ajax({
            url: "@Url.Action("SetClrDetail", "Clr")",
            type: "POST",
            contentType: "application/json",
            data: jsonString,
            success: function (response) {
                RefreshGrid();
                ShowMessage(response.result.msg);
                $('#dvEditor').modal('hide');
            }
        });
    }
</script>