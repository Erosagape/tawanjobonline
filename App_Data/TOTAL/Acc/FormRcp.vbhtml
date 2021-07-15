
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Receipt Slip"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-size: 13px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter,#pFooter {
        display: none;
    }
</style>
<div style="display:flex;flex-direction:column;height:900px;">
    <div style="flex:80%;">
        <div style="text-align:center;width:100%;padding:5px 5px 5px 5px">
            <label id="lblDocType" style="font-size:16px;font-weight:bold">ใบเสร็จรับเงิน (RECEIPT)</label>
        </div>
        <br />
        <!--
    <div style="display:flex;">
        <div style="flex:3;">
            <label>CUSTOMER:</label>
            <br/>
            <label id="lblCustCode"></label>
        </div>
        <div style="flex:1">
            BRANCH: <label id="lblBranchName">@ViewBag.PROFILE_DEFAULT_BRANCH_NAME</label>
            <br />
            TAX ID: <label id="lblTaxNumer">@ViewBag.PROFILE_TAXNUMBER</label>
        </div>

    </div>
    -->
        <div style="display:flex;">
            <div style="flex:3;border:1px solid black;border-radius:5px;">
                NAME : <label id="lblCustName"></label><br />
                ADDRESS : <label id="lblCustAddr1"></label><br /><label id="lblCustAddr2"></label><br />
                <label id="lblCustTel"></label><br />
                TAX-ID : <lable id="lblCustTax"></lable>
            </div>
            <div style="flex:1;border:1px solid black;border-radius:5px;">
                DOC NO. : <label id="lblReceiptNo"></label><br />
                REC DATE : <label id="lblReceiptDate"></label><br />
                CUST INV : <label id="lblCustInvNo"></label><br />
                JOB NO : <label id="lblJobNo"></label><br />
            </div>
        </div>
        <br />
        <div style="display:flex;border:1px solid black;border-radius:5px;">
            <div style="flex:2">
                <div class="row">
                    <p class="col-sm-12">
                        FROM :<label id="lblFromCountry"></label> TO :<label id="lblToCountry"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        PORT :<label id="lblInterPort"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        FLIGHT/VESSEL :<label id="lblVesselName"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        QUANTITY :<label id="lblQtyGross"></label> <label id="lblQtyUnit"></label>
                        <br />
                    </p>
                </div>
            </div>
            <div style="flex:2">
                <div class="row">
                    <p class="col-sm-12">
                        ETD :<label id="lblETDDate"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        HBL/HAWB :<label id="lblHAWB"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        MEASUREMENT :<label id="lblMeasurement"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        NET WEIGHT :<label id="lblNetWeight"></label> <label id="lblWeightUnit"></label>
                    </p>
                </div>
            </div>
            <div style="flex:2">
                <div class="row">
                    <p class="col-sm-12">
                        ETA :<label id="lblETADate"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        MBL/MAWB :<label id="lblMAWB"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        CUSTOMER :<br /><label id="lblCustTName"></label>
                    </p>
                </div>
            </div>
        </div>
        <table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
            <thead>
                <tr style="background-color:lightblue;">
                    <th height="40" width="60">INV.NO.</th>
                    <th width="270">DESCRIPTION</th>
                    <th width="60">AMOUNT</th>
                    <th width="30">CURRENCY</th>
                    <th width="40">RATE</th>
                    <th width="60">THB AMOUNT</th>
                </tr>
            </thead>
            <tbody id="tbDetail"></tbody>
            <tfoot>
                <tr style="background-color:lightblue;text-align:center;">
                    <td colspan="3"><label id="lblTotalText"></label></td>
                    <td colspan="2">TOTAL RECEIPT</td>
                    <td colspan="1"><label id="lblTotalNum"></label></td>
                </tr>
            </tfoot>
        </table>
        <br />
        <p>
            PAY BY
        </p>
        <br />
        <div style="display:flex;flex-direction:column">
            <div>
                <label><input type="checkbox" name="vehicle1" id="chkCash" value=""> CASH</label>
                DATE <label id="lblCashDate">_____________</label>  AMOUNT <label id="lblCashAmount">______________</label> BAHT
            </div>
            <div>
                <label><input type="checkbox" name="vehicle2" value="" id="chkCheque"> CHEQUE</label>
                DATE <label id="lblChqDate">_____________</label>  NO <label id="lblChqNo">_______________</label>  BANK <label id="lblChqBank">_________________</label>  AMOUNT <label id="lblChqAmount">______________</label> BAHT
            </div>
            <div>
                <label><input type="checkbox" name="vehicle3" value="" id="chkTransfer"> TRANSFER</label>
                DATE <label id="lblTransferDate">_____________</label>  BANK <label id="lblTransferBank">_________________</label>  AMOUNT <label id="lblTransferAmount">______________</label> BAHT
            </div>
        </div>
    </div>
    <div style="flex:20%;display:flex;align-items:flex-end;">
        <div style="flex:1;text-align:center;">
            <br /><br /><br />
            <p>_____________________</p>
            ผู้เก็บเงิน
            <br />
            CASHIER AND COLLECTOR
        </div>
        <div style="flex:1"></div>
        <div style="flex:1;text-align:center">

            <br /><br /><br />
            <p>_____________________</p>
            ผู้ได้รับมอบอำนาจ
            <br />
            AUTHORIZED SIGNATURE
        </div>
    </div>
</div>

<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');

    $.get(path + 'acc/getreceivereport?branch=' + branch + '&code=' + receiptno, function (r) {
        if (r.receipt.data.length !== null) {
            ShowData(r.receipt.data);
        }
    });
    function ShowData(dt) {
        let h = dt[0];
        //$('#lblCustCode').text(h.CustCode);
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr1').text(h.CustTAddr1);
            $('#lblCustAddr2').text(h.CustTAddr2);
            if(Number(h.CustBranch)>0) {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :' + h.CustBranch);
            } else {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :สำนักงานใหญ่');
            }
        } else {
            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr1').text(h.CustEAddr1);
            $('#lblCustAddr2').text(h.CustEAddr2);
            if(Number(h.CustBranch)>0) {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :' + h.CustBranch);
            } else {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :HEAD OFFICE');
            }
        }
        $('#lblCustTel').text(h.CustPhone);

        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        $.get(path + 'Acc/GetVoucher?Branch=' + h.BranchCode + '&Code=' + h.ReceiveRef).done(function (r) {
            if (r.voucher.payment.length > 0) {
                for (let p of r.voucher.payment) {
                    switch (p.acType) {
                        case 'CA':
                            if (p.ChqNo !== '') {
                                $('#chkTransfer').prop('checked', true);
                                $('#lblTransferDate').text(p.TRemark);
                                $('#lblTransferDate').css('text-decoration', 'underline');
                                $('#lblTransferBank').text(p.DocNo);
                                $('#lblTransferBank').css('text-decoration', 'underline');
                                $('#lblTransferAmount').text(ShowNumber(p.CashAmount, 2));
                                $('#lblTransferAmount').css('text-decoration', 'underline');
                            } else {
                                $('#chkCash').prop('checked', true);
                                $('#lblCashDate').text(p.TRemark);
                                $('#lblCashDate').css('text-decoration', 'underline');
                                $('#lblCashAmount').text(ShowNumber(p.CashAmount, 2));
                                $('#lblCashAmount').css('text-decoration', 'underline');
                            }
                            break;
                        case 'CH':
                            $('#chkCheque').prop('checked', true);
                            $('#lblChqDate').text(p.ChqDate);
                            $('#lblChqDate').css('text-decoration', 'underline');
                            $('#lblChqAmount').text(ShowNumber(p.ChqAmount, 2));
                            $('#lblChqAmount').css('text-decoration', 'underline');
                            $('#lblChqBank').text(p.TRemark);
                            $('#lblChqBank').css('text-decoration', 'underline');
                            $('#lblChqNo').text(p.ChqNo);
                            $('#lblChqNo').css('text-decoration', 'underline');
                            break;
                        case 'CR':
                            break;
                    }
                }
            }
        });
        $.get(path + 'JobOrder/GetJobSQL?Branch=' + h.BranchCode + '&JNo=' + h.JobNo)
        .done(function (d) {
            if (d.job.data.length > 0) {
                let j = d.job.data[0];
                if (j !== null) {
                    $('#lblCustInvNo').text(j.InvNo);
                    ShowCustomerEN(path, j.CustCode,j.CustBranch, '#lblCustTName');		
                    $('#lblJobNo').text(j.JNo);
                    if(Number(j.JobType)==1){
                        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                        ShowCountry(path, j.InvCountry, '#lblToCountry');
                        ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#lblInterPort');
                    } else {
                        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                        ShowCountry(path, j.InvCountry, '#lblToCountry');
                        ShowInterPort(path, j.InvCountry, j.InvInterPort, '#lblInterPort');
                    }
                    $('#lblVesselName').text(j.VesselName);
                    $('#lblQtyGross').text(j.InvProductQty);
                    ShowInvUnit(path, j.InvProductUnit, '#lblQtyUnit');
                    $('#lblNetWeight').text(j.TotalNW);
                    ShowInvUnit(path, j.GWUnit, '#lblWeightUnit');
                    $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                    $('#lblHAWB').text(j.HAWB);
                    $('#lblMeasurement').text(j.Measurement);
                    $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                    $('#lblMAWB').text(j.MAWB);
                }
            }
        });
        let html = '';
        let total = 0;

        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td>' + d.SDescription + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.FNet,2) + '</td>';
            html += '<td style="text-align:center">' + d.DCurrencyCode + '</td>';
            html += '<td style="text-align:center">' + d.DExchangeRate + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.Net,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);

            total += Number(d.Net);
        }
        $('#lblTotalNum').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(total));
    }
</script>