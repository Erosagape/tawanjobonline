
@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.Title = "Tax-Invoice Slip"
End Code
<style>
    * {
        font-size: 13px;
    }

    td {
        font-size: 13px;
    }

    th {
        font-size: 14px;
    }

    table {
        border:none;
        border-width: thin;
        border-collapse: collapse;
        page-break-inside: avoid
    }

    #dvFooter, #pFooter {
        display: none;
    }

    thead {
        display: table-row-group
    }

    tfoot {
        display: table-row-group
    }

    /* tr {
        page-break-inside: avoid
    }*/
</style>
<div id="dvTitle" style="display:flex;flex-direction:column">
    <div style="display:flex" id="dvCompLogo">
        <div style="flex:1;vertical-align:middle">
            <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:50px" />
        </div>
        <div style="flex:4;padding:5px;">
            <div id="divCompany" style="text-align:left;color:darkblue;font-size:12px;">
                <div style="height:25px;">
                    <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME_EN</b>
                </div>
                <div>
                    <b style="font-size:18px">@ViewBag.PROFILE_COMPANY_NAME</b>
                </div>
            </div>
        </div>
    </div>
    <div style="font-size:10px;" id="dvCompAddr">
        @ViewBag.PROFILE_COMPANY_ADDR1 @ViewBag.PROFILE_COMPANY_ADDR2 โทร @ViewBag.PROFILE_COMPANY_TEL แฟกซ์ @ViewBag.PROFILE_COMPANY_FAX
        <br />@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN TEL @ViewBag.PROFILE_COMPANY_TEL FAX @ViewBag.PROFILE_COMPANY_FAX
        <br />เลขประจำตัวผู้เสียภาษี @ViewBag.PROFILE_TAXNUMBER สาขา: สำนักงานใหญ่
    </div>
</div>
<div id="dvTemp" style="display:none">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</div>
<div style="display:flex;flex-direction:column;height:900px;">
    <div style="text-align:center;width:100%;">
        <br/>
        <label style="font-size:16px;font-weight:bold;" id="lblDocType">ใบเสร็จรับเงิน/ใบกำกับภาษี (RECEIPT/TAX-INVOICE)</label>
    </div>
    <br />
    <!--
    <div style="display:flex;">
        <div style="flex:3;">
            <label>CUSTOMER:</label>
            <br />
            <label id="lblCustCode"></label>
        </div>
        <div style="flex:1">
            BRANCH: <label id="lblBranchName">@ViewBag.PROFILE_DEFAULT_BRANCH_NAME</label>
            <br />
            TAX ID: <label id="lblTaxNumer">@ViewBag.PROFILE_TAXNUMBER</label>
        </div>
    </div>
    -->
    <div style="display:flex;width:96%">
        <div style="flex:3;border:1px solid black;border-radius:5px;">
            NAME : <label id="lblCustName"></label><br />
            ADDRESS : <label id="lblCustAddr1"></label><br />
            <label id="lblCustAddr2"></label><br />
            @*TEL : <label id="lblCustTel"></label><br />*@
            TAX-ID : <lable id="lblCustTax"></lable>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;">
            NO. : <label id="lblReceiptNo"></label><br />
            ISSUE DATE : <label id="lblReceiptDate"></label><br />
            CUST INV : <label id="lblCustInvNo"></label><br />
            JOB NO : <label id="lblJobNo"></label><br />
        </div>
    </div>
    <br />
    <div style="display:flex;width:96%;border:1px solid black;border-radius:5px;">
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
    <br/>
    <table style="width:96%; margin-top:5px" class="text-center">
        <thead>
            <tr style="background-color: lightblue; border-style: solid; border-width: thin;">
                <th height="40" width="60" style="border-right:solid;border-width:thin">INV.NO.</th>
                <th width="320" style="border-right:solid;border-width:thin">DESCRIPTION</th>
                <th width="60" style="border-right:solid;border-width:thin">ADVANCE</th>
                <th width="60" style="border-right:solid;border-width:thin">NON-VAT</th>
                <th width="30">VAT</th>
                <!--<th width="30">WHT</th>-->
            </tr>
        </thead>
        <tbody id="tbDetail"></tbody>
        <tfoot>
            <tr style="background-color: lightblue; text-align: right; border-style: solid; border-width: thin;">
                <td colspan="2" style="border-left:solid;border-width:thin;"></td>
                <td colspan="1" style="border-left:solid;border-width:thin;"><label id="lblSubTotalAdv"></label></td>
                <td colspan="1" style="border-left:solid;border-width:thin;"><label id="lblSubTotalNonVat"></label></td>
                <td colspan="1" style="border-left:solid;border-width:thin;"><label id="lblSubTotalVat"></label></td>
                <!--<td colspan="1"><label id="lblSubTotalWht"></label></td>-->
            </tr>
            <tr style="background-color:lightblue;text-align:right;border-style:solid;border-width:thin;">
                <td colspan="2" style="border-left:solid;border-width:thin;"></td>
                <td colspan="2" style="border-left:solid;border-width:thin;">TOTAL VAT</td>
                <td colspan="1" style="border-left:solid;border-width:thin;"><label id="lblTotalVAT"></label></td>
            </tr>
            <tr style="background-color: lightblue; text-align: right; border-style: solid; border-width: thin;">
                <td colspan="2" style="text-align:center;border-left:solid;border-width:thin;"><label id="lblTotalText"></label></td>
                <td colspan="2" style="border-left:solid;border-width:thin;">TOTAL AMOUNT</td>
                <td colspan="1" style="border-left:solid;border-width:thin;"><label id="lblTotalAfterVAT"></label></td>
            </tr>
        </tfoot>
    </table>
    <br />
    <p>
        PAID BY
    </p>
    <br />
    <div style="display:flex;flex-direction:column">
        <div>
            <label><input id="chkCash" type="checkbox" name="vehicle1" value=""> CASH </label>
            DATE <label id="lblCashDate"> _____________ </label>
            AMOUNT <label id="lblCashAmount">______________</label> BAHT
        </div>
        <div>
            <label><input id="chkCheque" type="checkbox" name="vehicle2" value=""> CHEQUE </label>
            DATE <label id="lblChqDate">_____________ </label>
            NO <label id="lblChqNo">_______________</label>
            BANK <label id="lblChqBank">_________________</label>
            AMOUNT <label id="lblChqAmount">______________</label> BAHT
        </div>
        <div>
            <label><input id="chkTransfer" type="checkbox" name="vehicle3" value=""> TRANSFER</label>
            DATE  <label id="lblTransferDate">_____________</label>
            BANK <label id="lblTransferBank"> _________________</label>
            AMOUNT <label id="lblTransferAmount">______________</label> BAHT
        </div>
    </div>
    <br />
    <br />
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
    let isShowHeader = true;
    if (confirm("show company header?") == false) {
        isShowHeader = false;
        $('#dvTitle').css('display', 'none');
        $('#dvTemp').css('display', 'inline');
        //$('#imgLogo').css('display', 'none');
        //$('#divCompany').css('display', 'none');
        //$('#dvCompAddr').css('display', 'none');
        //$('#dvCompLogo').css('height', '90px');
    }
    $.get(path + 'acc/getreceivereport?branch=' + branch + '&code=' + receiptno, function (r) {
        if (r.receipt.data.length !== null) {
            ShowData(r.receipt.data);
        }
    });

    function ShowData(dt) {
        let h = dt[0];
        if (h.ReceiptType == 'TAX') {
            $('#lblDocType').text('ใบเสร็จรับเงิน/ใบกำกับภาษี  (RECEIPT/TAX-INVOICE)');
        }
        if (h.ReceiptType == 'SRV') {
            $('#lblDocType').text('ใบเสร็จรับเงิน/ใบกำกับภาษี  (RECEIPT/TAX-INVOICE)');
        }
        if (h.ReceiptType == 'REC') {
            $('#lblDocType').text('ใบเสร็จรับเงิน (RECEIPT)');
        }
        if (h.ReceiptType == 'RCV') {
            $('#lblDocType').text('ใบเสร็จรับเงิน (RECEIPT)');
        }
        let address = h.CustTAddr.split(",");
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
            //$('#lblCustAddr1').text(h.CustEAddr);
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
        //let j = dr.job[0][0];
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
	    let adv = 0;
	    let nonvat = 0;
	    let vat = 0;
        let service = 0;
        let invvat = 0;
        let wht = 0;
        let total = 0;
        let rowid = 0;
        let pageid = 0;
        let totalrow = 35;

        let htmlHead = '<tr>';
        htmlHead += '<td><br/></td>';
        htmlHead += '<td></td>';
        htmlHead += '<td></td>';
        htmlHead += '<td></td>';
        htmlHead += '<td></td>';
        htmlHead += '</tr>';

        for (let d of dt) {
            rowid++;
            if ((rowid % totalrow == 0) && pageid == 0) {
                if (isShowHeader == false) {
                    html = '<tr><td colspan="5" style="border:none;"><br/><br/><br/><br/><br/><br/></td></tr>';
                    $('#tbDetail').append(html);
                }
                pageid++;
                $('#tbDetail').append(htmlHead);
            } else {
                if (isShowHeader == false) {
                    if ((rowid - totalrow) % 47 == 0) {
                        html = '<tr><td colspan="5" style="border:none;"><br/><br/><br/><br/><br/><br/><br/></td></tr>';
                        $('#tbDetail').append(html);
                    }
                } else {
                    if ((rowid - totalrow) % 52 == 0) {
                        $('#tbDetail').append(htmlHead);
                    }
                }
            }
            html = '<tr style="border-style:solid;border-width:thin;">';
            html += '<td style="text-align:center;white-space:nowrap;border-right:solid;border-width:thin;">' + d.InvoiceNo + '</td>';
            html += '<td style="border-right:solid;border-width:thin;">' + d.SDescription + '</td>';
            html += '<td style="text-align:right;border-right:solid;border-width:thin;">' + (d.AmtAdvance>0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            html += '<td style="text-align:right;border-right:solid;border-width:thin;">' + (d.AmtCharge>0&&d.InvVAT==0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            html += '<td style="text-align:right">' + (d.AmtCharge>0&&d.InvVAT>0? ShowNumber(d.InvAmt,2):'0.00') + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);

  	        service += Number(d.InvAmt);
            total += Number(d.InvAmt) + Number(d.InvVAT);

            if (d.AmtAdvance > 0)
            {
		        adv += Number(d.InvAmt);
            }

            if (d.AmtCharge > 0) {
		        if(d.InvVAT>0){
		           vat += Number(d.InvAmt);
                }
                else
                {
		           nonvat += Number(d.InvAmt);
		        }
                invvat += Number(d.InvVAT);
                wht += Number(d.Inv50Tavi);
            }
        }

        $('#lblSubTotalAdv').text(ShowNumber(adv,2));
        $('#lblSubTotalNonVat').text(ShowNumber(nonvat,2));
        $('#lblSubTotalVat').text(ShowNumber(vat,2));
        //$('#lblSubTotalWht').text(ShowNumber(wht,2));
        //$('#lblTotalBeforeVAT').text(ShowNumber(service, 2));
        $('#lblTotalVAT').text(ShowNumber(invvat, 2));
        $('#lblTotalAfterVAT').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(ShowNumber(total,2)));

        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        $.get(path + 'Acc/GetVoucher?Branch=' + h.BranchCode + '&Code=' + h.ReceiveRef).done(function (r) {
            if (r.voucher.payment.length > 0) {
                for (let p of r.voucher.payment) {
                    let pdate = p.TRemark.split('-');
                    switch (p.acType) {
                        case 'CA':
                            $('#chkCash').prop('checked', true);
                            //$('#lblCashDate').text(p.TRemark);
                            $('#lblCashDate').text(pdate[2] + "-" + pdate[1] + "-" + pdate[0]);
                            $('#lblCashDate').css('text-decoration', 'underline');
                            $('#lblCashAmount').text(ShowNumber(p.CashAmount, 2));
                            $('#lblCashAmount').css('text-decoration', 'underline');
                            break;
                        case 'CH':
                            $('#chkTransfer').prop('checked', true);
                            /*  $('#lblTransferDate').text(p.TRemark);        */
                            $('#lblTransferDate').text(ShowDate(p.ChqDate));
                            $('#lblTransferDate').css('text-decoration', 'underline');
                            $('#lblTransferBank').text(p.BookCode);
                            $('#lblTransferBank').css('text-decoration', 'underline');
                            $('#lblTransferAmount').text(ShowNumber(p.ChqAmount, 2));
                            $('#lblTransferAmount').css('text-decoration', 'underline');
                            break;
                        case 'CU':
                            $('#chkCheque').prop('checked', true);
                            $('#lblChqDate').text(ShowDate(p.ChqDate));
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
    }
</script>
