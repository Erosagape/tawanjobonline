﻿@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    body {
        font-size: 11px;
    }
#dvFooter {
	display:none;
}
	    table {
        border-width: thin;
        border-collapse: collapse;
    }
</style>
<div style="text-align:center;width:100%">
    <h2>INVOICE</h2>
</div>
<div id="dvCopy" style="text-align:right;width:100%">
</div>
<div>
    <div style="display:flex;">
        <div style="flex:3;border:1px solid black;border-radius:5px;">
            NAME : <label id="lblCustName"></label><br />
            ADDRESS : <label id="lblCustAddress"></label><br />
            <!--TEL : <label id="lblCustTel"></label><br />-->
            <label>TAX REFERENCE ID:</label>
            <label id="lblTaxNumber"></label>
            <label>BRANCH:</label>
            <label id="lblTaxBranch"></label>

        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;">
            INV NO. : <label id="lblDocNo"></label><br />
            INV DATE : <label id="lblDocDate"></label><br />
            CUST INV : <label id="lblCustInvNo"></label><br />
            JOB NO : <label id="lblJobNo"></label><br />
            DECLARE : <label id="lblDeclareNumber"></label><br />
        </div>
    </div>
    <div style="display:flex;border:1px solid black;border-radius:5px;">
        <div style="flex:2">
            <div class="row">
                <p class="col-sm-12">
                    FROM :<label id="lblFromCountry"></label>,<label id="lblInterPort"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    FLIGHT/VISSEL :<label id="lblVesselName"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    QUANTITY :<label id="lblQtyGross"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    RELEASE PORT :<label id="lblClearPort"></label>
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
                    COMMODITY :<label id="lblInvProduct"></label>
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
                    CONTAINER :<label id="lblTotalContainer"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    DECLARE TYPE :<label id="lblDeclareType"></label>
<br/>
CUST PO: <label id="lblCustRefNo"></label>
                </p>
            </div>
        </div>
    </div>
    <table style="width:100%" border="1" class="text-center">
        <thead>
            <tr style="background-color :gainsboro;text-align:center;">
                <th width="30px">No</th>
                <th width="390px">DESCRIPTION</th>
                <th width="80px">ADVANCE</th>
                <th width="80px">SERVICE</th>
                <th width="50px">CURR</th>
                <th width="50px">QTY</th>
                <th width="80px">VAT</th>
                <th width="80px">WHT</th>
                <th width="100px">TOTAL</th>
            </tr>
        </thead>
        <tbody id="tbDetail"></tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <div style="display:flex">
                        <div style="text-align:left;flex:1">
                            <div id="lblShippingRemark"></div>
                            REMARKS :<br />
                            <div id="lblDescription"></div>
                        </div>
                    </div>
                </td>
                <td colspan="3">
                    TOTAL ADVANCE<br />
                    TOTAL SERVICE <br />
                    VATABLE<br />
                    VAT (RATE=<label id="lblVATRate"></label>%)<br />
                    SERVICE+VAT<br />
                    SERVICE+ADVANCE<br />
                    DISCOUNT (RATE=<label id="lblDiscountRate"></label>%)<br />
                    CUST. ADV<br />
                    GRAND TOTAL
                </td>
                <td style="background-color :gainsboro;text-align:right;" colspan="2">
                    <label id="lblSumAdvance"></label><br />
                    <label id="lblSumNonVat"></label><br />
                    <label id="lblSumBeforeVat"></label><br />
                    <label id="lblSumVat"></label><br />
                    <label id="lblSumAfterVat"></label><br />
                    <label id="lblSumTotal"></label><br />
                    <label id="lblSumDiscount"></label><br />
                    <label id="lblSumCustAdv"></label><br />
                    <label id="lblSumGrandTotal"></label>
                </td>
            </tr>
            <tr>
                <td>TOTAL</td>
                <td colspan="8">
                    <div style="text-align:center"><label id="lblTotalBaht"></label></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <div style="display:flex">
        <div class="text-left" style="border:1px solid black;border-radius:5px;flex:1">
            WITHHOLDING TAX DETAIL
            <div style="display:flex">
                <div class="text-center" style="flex:2">
                    TRANSPORT CHARGES:<br />
                    SERVICE CHARGES:
                </div>
                <div class="text-center" style="flex:1">
                    <label id="lblSumBaseWht1"></label><br />
                    <label id="lblSumBaseWht3"></label>
                </div>
                <div class="text-center" style="flex:1">
                    <label id="lblSumWht1"></label>
                    <br />
                    <label id="lblSumWht3"></label>
                </div>
            </div>
            <div style="display:flex;">
                <div style="flex:2">
                    TOTAL INVOICE
                </div>
                <div style="flex:1">
                    <label id="lblForeignNet"></label> <label id="lblCurrencyCode"></label>
                </div>
            </div>
            <div id="dvForeign" style="display:flex">
                <div style="flex:2">
                    (1=<label id="lblExchangeRate"></label>)
                </div>
                <div style="flex:1">
                    <label id="lblSumNetInvoice"></label>                    
                </div>
            </div>
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            FOR THE CUSTOMER <br /><br /> <br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
            AUTHORIZED SIGNATURE
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            FOR @ViewBag.PROFILE_COMPANY_NAME_EN <br /><br /> <br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
            AUTHORIZED SIGNATURE
        </div>
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    var isUseEng = false;
    //$(document).ready(function () {
    let ans = confirm('OK to print Original or Cancel For Copy');
    if (ans == true) {
        $('#dvCopy').html('<b>**ORIGINAL**</b>');
    } else {
        $('#dvCopy').html('<b>**COPY**</b>');
    }
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
            $('#lblDiscountRate').text(h.DiscountRate);
            $('#lblVATRate').text(ShowNumber(h.VATRate,1));

            $.get(path + 'Master/GetCompany?Code='+ h.BillToCustCode + '&Branch='+ h.BillToCustBranch).done(function(r) {
                if (r.company.data.length > 0) {
                     let c = r.company.data[0];
                     $('#lblTaxNumber').text(c.TaxNumber);               
                    if (c.UsedLanguage == 'TH') {
                        if (isUseEng==false) {
                            $('#lblTotalBaht').text('(' + CNumThai(CDbl((Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT) - Number(h.TotalCustAdv) - Number(h.TotalDiscount)), 2)) + ')');
                        }
                        if (Number(c.Branch) == 0) { 
                            $('#lblTaxBranch').text('สำนักงานใหญ่');
                        } else {
                            $('#lblTaxBranch').text(c.Branch);
                        }
                        $('#lblCustName').text(c.Title+' '+c.NameThai);
                        $('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
                    } else {
                        if (isUseEng==false) {
                            $('#lblTotalBaht').text('(' + CNumEng(CDbl((Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT) - Number(h.TotalCustAdv) - Number(h.TotalDiscount)), 2)) + ')');
                        }
                        if (Number(c.Branch) == 0) { 
                            $('#lblTaxBranch').text('HEAD OFFICE');
                        } else {
                            $('#lblTaxBranch').text(c.Branch);
                        }
                        $('#lblCustName').text(c.NameEng);
                        $('#lblCustAddress').text(c.EAddress1 + '\n' + c.EAddress2);
                     }
                }
            });
            let j = dr.job[0][0];
            if (j !== null) {
                $('#lblCustInvNo').text(j.InvNo);
                $('#lblJobNo').text(j.JNo);
                $('#lblDeclareNumber').text(j.DeclareNumber);
                if (j.JobType == 1) {
                    ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                    ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#lblInterPort');
                } else {
                    ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                    ShowInterPort(path, j.InvCountry, j.InvInterPort, '#lblInterPort');
                }
                $('#lblVesselName').text(j.VesselName);
                $('#lblQtyGross').text(j.InvProductQty + ' ' + j.InvProductUnit + ' G.W ' + j.TotalGW + ' '+ j.GWUnit);
                $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                $('#lblHAWB').text(j.HAWB);
                $('#lblMeasurement').text(j.Measurement);
                $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                $('#lblMAWB').text(j.MAWB);
                $('#lblInvProduct').text(j.InvProduct);
                ShowReleasePort(path, j.ClearPort, '#lblClearPort');
                $('#lblTotalContainer').text(j.TotalContainer);
                ShowDeclareType(path, j.DeclareType, '#lblDeclareType');
                $('#lblCustRefNo').text(j.CustRefNO);
            }
            let remark = h.Remark1 + '\n' + h.Remark2 + '\n' + h.Remark3 + '\n' + h.Remark4 + '\n' + h.Remark5 + '\n' + h.Remark6 + '\n' + h.Remark7 + '\n' + h.Remark8 + '\n' + h.Remark9 + '\n' + h.Remark10;
            remark=remark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#lblDescription').html(remark);
            remark=h.ShippingRemark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#lblShippingRemark').html(remark);
            $('#lblSumNonVat').text(ShowNumber(h.TotalCharge/h.ExchangeRate,2));
            $('#lblSumDiscount').text(ShowNumber(h.TotalDiscount / h.ExchangeRate,2));
            $('#lblSumCustAdv').text(ShowNumber(h.TotalCustAdv / h.ExchangeRate,2));
            $('#lblSumBeforeVat').text(ShowNumber(h.TotalIsTaxCharge / h.ExchangeRate,2));
            $('#lblSumVat').text(ShowNumber(h.TotalVAT / h.ExchangeRate,2));
            $('#lblSumAfterVat').text(ShowNumber((Number(h.TotalIsTaxCharge) + Number(h.TotalVAT))/h.ExchangeRate,2));
            $('#lblSumAdvance').text(ShowNumber(h.TotalAdvance/h.ExchangeRate,2));
            $('#lblSumTotal').text(ShowNumber((Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT)) / h.ExchangeRate,2));
            $('#lblSumGrandTotal').text(ShowNumber((Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT) - Number(h.TotalCustAdv) - Number(h.TotalDiscount)) / h.ExchangeRate,2));
            if (h.DocNo.substr(0, 3) == 'IVF') {
                isUseEng = true;
                $('#lblTotalBaht').text('(' + CNumEng(CDbl((Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT) - Number(h.TotalCustAdv) - Number(h.TotalDiscount)), 2) / h.ExchangeRate) + ')');
            }
            if (h.CurrencyCode !== 'THB') {
                isUseEng = true;
                $('#dvForeign').css('display', 'none');
                $('#lblTotalBaht').text('(' + CNumEng(CDbl(Number(h.ForeignNet),2)) + ')');
            }
            $('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalNet), 2));
        }
        let d = dr.detail[0];
        sortData(d, 'AmtAdvance', 'asc');
        let sumbase1 = 0;
        let sumbase3 = 0;
        let sumtax1 = 0;
        let sumtax3 = 0;
        let icount = 0;
        let h = dr.header[0][0];
        if (d.length > 0) {
            for (let o of d) {
                icount += 1;
                let html = '<tr>';
                html += '<td style="text-align:center">' + icount + '</td>';
                if ((o.ExchangeRate !== 1) && (dr.header[0][0].CurrencyCode=='THB')) {
                    html += '<td>' + o.SDescription +' (Rate='+ o.ExchangeRate+' THB)' +'</td>';
                } else {
                    html += '<td>' + o.SDescription + '</td>';
                }                
                if (o.AmtAdvance > 0) {
                    html += '<td style="text-align:right">' + ShowNumber(CNum(o.AmtAdvance), 2) + '</td>';
                    html += '<td style="text-align:right">0.00</td>';
                } else {
                    html += '<td style="text-align:right">0.00</td>';
                    html += '<td style="text-align:right">' + ShowNumber(CNum(o.AmtCharge), 2) + '</td>';
                }
                html += '<td style="text-align:center">' + o.CurrencyCode + '</td>';
                html += '<td style="text-align:center">' + o.Qty + ' '+ o.QtyUnit + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(o.AmtVat, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(o.Amt50Tavi, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(CNum(h.CurrencyCode!=="THB"?o.FTotalAmt:o.TotalAmt), 2) + '</td>';
                html += '</tr>';

                $('#tbDetail').append(html);

                if (o.Amt50Tavi > 0) {
                    if (o.Rate50Tavi == 1) {
                        sumbase1 += (o.Amt - o.AmtDiscount) / (h.CurrencyCode !== "THB" ? o.ExchangeRate : 1);
                        sumtax1 += o.Amt50Tavi / (h.CurrencyCode !== "THB" ? o.ExchangeRate : 1);
                    } else {
                        sumbase3 += (o.Amt - o.AmtDiscount) / (h.CurrencyCode !== "THB" ? o.ExchangeRate : 1);
                        sumtax3 += o.Amt50Tavi / (h.CurrencyCode !== "THB" ? o.ExchangeRate : 1);
                    }
                }
            }
        }
        $('#lblSumBaseWht1').text(ShowNumber(sumbase1,2));
        $('#lblSumBaseWht3').text(ShowNumber(sumbase3,2));

        $('#lblSumWht1').text(ShowNumber(sumtax1,2));
        $('#lblSumWht3').text(ShowNumber(sumtax3, 2));
    }
</script>