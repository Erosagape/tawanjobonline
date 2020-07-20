
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    thead {
        font-size: 13px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter {
        display: none;
    }

    #dvForm {
        padding-right: 5px;
    }

    .roundbox {
        border: 1px solid black;
        border-radius: 5px;
        margin: 2px 2px 2px 2px;
        padding: 2px 2px 2px 2px;
    }
</style>
<div style="text-align:right;width:100%;">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">INVOICE / ใบแจ้งหนี้</label>
</div>
<br />
<span class="roundbox">CUSTOMER :</span>
<label>TAX REFERENCE-ID:</label>
<label id="lblTaxNumber"></label>
<label>BRANCH:</label>
<label id="lblTaxBranch"></label>
<div id="dvForm">
    <div style="display:flex;">
        <div style="flex:3" class="roundbox">
            NAME : <label id="lblCustName"></label>
            <br />
            ADDRESS : <label id="lblCustAddress"></label><br />
            <!--TEL : <label id="lblCustTel"></label><br />-->
        </div>
        <div style="flex:1;" class="roundbox">
            DATE : <label id="lblDocDate"></label><br />
            TICKET NO. : <label id="lblDocNo"></label><br />
            SERVICE : <label id="lblTotalContainer"></label>
        </div>
    </div>
    <div style="width:100%" class="roundbox">
        INVOICE : <label id="lblCustInvNo"></label>
    </div>
    <br />
    <table style="width:100%" border="1" class="text-center">
        <thead>
            <tr style="background-color :gainsboro;text-align:center;">
                <th width="50px" rowspan="2">Item</th>
                <th width="350px" rowspan="2">Description</th>
                <th width="325px" colspan="3">Advance Re-Imbursement</th>
                <th width="275px" colspan="2">Services Charge</th>
            </tr>
            <tr style="background-color :gainsboro;text-align:center;">
                <th>Service</th>
                <th>Vat</th>
                <th>Amount</th>
                <th>NON-VAT</th>
                <th>VATABLE</th>
            </tr>
        </thead>
        <tbody id="tbDetail"></tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    TOTAL INVOICE (<label id="lblCurrencyCode"></label>)=<label id="lblForeignNet"></label> RATE=<label id="lblExchangeRate"></label>
                </td>
                <td style="background-color :gainsboro;text-align:right">
                    <label id="lblSumBaseAdv"></label>
                </td>
                <td style="background-color :gainsboro;text-align:right">
                    <label id="lblSumVatAdv"></label>
                </td>
                <td style="background-color :gainsboro;text-align:right">
                    <label id="lblSumAdvance"></label>
                </td>
                <td style="background-color :gainsboro;text-align:right">
                    <label id="lblSumNonVat"></label>
                </td>
                <td style="background-color :gainsboro;text-align:right">
                    <label id="lblSumBeforeVat"></label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="lblShippingRemark"></div>
                    REMARKS :<br />
                    <div id="lblDescription"></div>
                </td>

                <td colspan="3">
                    VAT (<label id="lblVATRate"></label>%)<br />
                    TOTAL<br />
                    ADVANCE<br />
                    GRAND TOTAL
                </td>
                <td style="background-color :gainsboro;text-align:right;" colspan="2">
                    <label id="lblSumVat"></label><br />
                    <label id="lblSumAfterVat"></label><br />
                    <label id="lblSumTotal"></label><br />
                    <label id="lblSumGrandTotal"></label>
                </td>
            </tr>
            <tr>
                <td>TOTAL (BAHT)</td>
                <td colspan="7">
                    <div style="text-align:center;"><label id="lblTotalBaht" style="font-size:14px;"></label></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <br />
    <div style="display:flex">
        <div class="text-left" style="border:1px solid black;border-radius:5px;flex:1;text-align:center">
            WITHHOLDING TAX DETAIL
            <table style="width:100%;text-align:left">
                <tr>
                    <td style="width:55%">TRANSPORT 1%</td>
                    <td style="width:25%;text-align:right"><label id="lblSumBaseWht1"></label><br /></td>
                    <td style="width:20%;text-align:right"><label id="lblSumWht1"></label></td>
                </tr>
                <tr>
                    <td style="width:55%">SERVICE 1.5%</td>
                    <td style="width:25%;text-align:right"><label id="lblSumBaseWht3"></label></td>
                    <td style="width:20%;text-align:right"><label id="lblSumWht3"></label></td>
                </tr>
                <tr>
                    <td colspan="2" style="width:80%">
                        NET AMOUNT
                    </td>
                    <td style="width:20%;text-align:right">
                        <label id="lblSumNetInvoice"></label>
                    </td>
                </tr>

            </table>
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            <br />
            FOR THE CUSTOMER <br /><br /> <br /><br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
            AUTHORIZED SIGNATURE
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            <br />
            FOR THE APL LOGISTICS SVCS (THAILAND) <br /><br /> <br /><br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
            AUTHORIZED SIGNATURE
        </div>
    </div>
</div>
<div>
    <div style="float:left">
        Please pay cheque (A/C Payer only) payable to APL Logistics svcs (Thailand) Co.,ltd.<br />
        - Late payment 2% will be charge if paid after due date.<br />
        - Any incorrect item: please inform within 7 days from the date of invoice, otherwise will be considered correct.
    </div>
    <div style="float:right">
        JOB# <label id="lblJobNo"></label><br />
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';

    let branch = getQueryString('branch');
    let invno = getQueryString('code');
    $.get(path + 'acc/getinvoice?branch=' + branch + '&code=' + invno, function (r) {
        if (r.invoice.header !== null) {
            ShowData(r.invoice);
        }
    });
    //});
    function ShowData(dr) {

        if (dr.header[0].length > 0) {
            let h = dr.header[0][0];
            $('#lblDocNo').text(h.DocNo);
            $('#lblDocDate').text(ShowDate(CDateTH(h.DocDate)));
            $('#lblCurrencyCode').text(h.CurrencyCode);
            $('#lblExchangeRate').text(h.ExchangeRate);
            $('#lblForeignNet').text(ShowNumber(h.ForeignNet, 2));

            $('#lblVATRate').text(ShowNumber(h.VATRate,1));
	$.get(path+'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch='+ h.BillToCustBranch,function(r){
            let c = r.company.data[0];
        if (c !== null) {
            $('#lblTaxNumber').text(c.TaxNumber);
            if (c.UsedLanguage == 'TH') {
            if (Number(c.Branch == 0)) {
                $('#lblTaxBranch').text('สำนักงานใหญ่');
            } else {
                $('#lblTaxBranch').text(c.Branch);
            }
                    $('#lblCustName').text(c.Title+' '+c.NameThai);
                    $('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
	$('#lblCustTName').text(dr.customer[0][0].NameThai);
            } else {
            if (Number(c.Branch == 0)) {
                $('#lblTaxBranch').text('HEAD OFFICE');
            } else {
                $('#lblTaxBranch').text(c.Branch);
            }

                    $('#lblCustName').text(c.NameEng);
                    $('#lblCustAddress').text(c.EAddress1 + '\n' + c.EAddress2);
	$('#lblCustTName').text(dr.customer[0][0].NameEng);
                }
                //$('#lblCustTel').text(c.Phone);
            }
	});
            let j = dr.job[0][0];
            if (j !== null) {
                $('#lblCustInvNo').text(j.InvNo);
                $('#lblJobNo').text(j.JNo);
                $('#lblTotalContainer').text(j.TotalContainer);
            }
            let remark = h.Remark1;
	        remark +=(h.Remark2!=='' ? '<br/>':'')+ h.Remark2;
	        remark +=(h.Remark3!=='' ? '<br/>':'')+ h.Remark3;
	        remark +=(h.Remark4!=='' ? '<br/>':'')+ h.Remark4;
	        remark +=(h.Remark5!=='' ? '<br/>':'')+ h.Remark5;
	        remark +=(h.Remark6!=='' ? '<br/>':'')+ h.Remark6;
	        remark +=(h.Remark7!=='' ? '<br/>':'')+ h.Remark7;
	        remark +=(h.Remark8!=='' ? '<br/>':'')+ h.Remark8;
	        remark +=(h.Remark9!=='' ? '<br/>':'')+ h.Remark9;
	        remark +=(h.Remark10!=='' ? '<br/>':'')+ h.Remark10;
            $('#lblDescription').html(CStr(remark));
            remark=h.ShippingRemark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#lblShippingRemark').html(remark);

            $('#lblSumCustAdv').text(ShowNumber(h.TotalCustAdv,2));
            $('#lblSumBeforeVat').text(ShowNumber(h.TotalIsTaxCharge,2));
            $('#lblSumVat').text(ShowNumber(h.TotalVAT,2));
            $('#lblSumAfterVat').text(ShowNumber(Number(h.TotalIsTaxCharge)+Number(h.TotalVAT),2));
            $('#lblSumAdvance').text(ShowNumber(h.TotalAdvance,2));
            $('#lblSumTotal').text(ShowNumber(Number(h.TotalAdvance),2));
            $('#lblSumGrandTotal').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount),2));
            $('#lblTotalBaht').text('(' + CNumThai(CDbl(Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount), 2)) + ')');

            $('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalNet),2));
        }
        let d = dr.detail[0];
        let sumbase1 = 0;
        let sumbase3 = 0;
        let sumtax1 = 0;
        let sumtax3 = 0;
        let sumbaseadv = 0;
        let sumvatadv = 0;
        let sumnonvat = 0;
        if (d.length > 0) {
            let irow = 0;
            for (let o of d) {
                irow += 1;
                let html = '<tr>';
                html += '<td style="text-align:center">' + irow + '</td>';
                html += '<td>' + o.SDescription + '</td>';
                sumbaseadv += (o.AmtAdvance > 0 ? o.Amt : 0);
                sumvatadv += (o.AmtAdvance > 0 ? o.AmtVat : 0);
                sumnonvat += (o.AmtCharge > 0 && o.AmtVat == 0 ? o.Amt : 0);

                html += '<td style="text-align:right">' + (o.AmtAdvance > 0 ? ShowNumber(o.Amt, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtAdvance > 0 ? ShowNumber(o.AmtVat, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtAdvance > 0 ? ShowNumber(o.TotalAmt, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtCharge > 0 && o.AmtVat==0 ? ShowNumber(o.Amt, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtCharge > 0 && o.AmtVat > 0 ? ShowNumber(o.Amt, 2) : '0.00') + '</td>';
                html += '</tr>';

                $('#tbDetail').append(html);

                if (o.Amt50Tavi > 0) {
                    if (o.Rate50Tavi == 1) {
                        sumbase1 += (o.Amt-o.AmtDiscount);
                        sumtax1 += o.Amt50Tavi;
                    } else {
                        sumbase3 += (o.Amt-o.AmtDiscount);
                        sumtax3 += o.Amt50Tavi;
                    }
                }
            }
        }
        $('#lblSumNonVat').text(ShowNumber(sumnonvat, 2));
        $('#lblSumBaseAdv').text(ShowNumber(sumbaseadv, 2));
        $('#lblSumVatAdv').text(ShowNumber(sumvatadv,2));
        $('#lblSumBaseWht1').text(ShowNumber(sumbase1,2));
        $('#lblSumBaseWht3').text(ShowNumber(sumbase3,2));

        $('#lblSumWht1').text(ShowNumber(sumtax1,2));
        $('#lblSumWht3').text(ShowNumber(sumtax3,2));
    }
</script>