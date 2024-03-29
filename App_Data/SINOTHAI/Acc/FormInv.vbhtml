﻿
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    * {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
    #tbDetail tr {
        border-bottom:hidden;
    }

    #dvFooter {
        display: none;
    }

    #dvForm {
        padding-right: 5px;
    }
</style>
<div style="text-align:center;width:100%;padding:5px 5px 5px 5px">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">ใบแจ้งหนี้ (INVOICE)</label>
</div>
<div id="dvCopy"></div>
<div id="dvForm">
    <div style="display:flex;margin-bottom:5px;">
        <div style="flex:3;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;margin-right:5px">
            NAME :
            <label id="lblCustName"></label>
            <br />
            ADDRESS :
            <label id="lblCustAddress"></label>
            <br />
            <!--TEL : <label id="lblCustTel"></label><br />-->
            <label>TAX-ID:</label>
            <label id="lblTaxNumber"></label>
            <label>BRANCH:</label>
            <label id="lblTaxBranch"></label>
            <br />
            AGENT :
            <label id="lblAgentName"></label>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;">
            INV NO. :
            <label id="lblDocNo"></label>
            <br />
            INV DATE :
            <label id="lblDocDate"></label>
            <br />
            CUST INV :
            <label id="lblCustInvNo"></label>
            <br />
            JOB NO :
            <label id="lblJobNo"></label>
            <br />
        </div>
    </div>
    <div style="display:flex;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;margin-bottom:5px;">
        <div style="flex:2">
            <div class="row">
                <p class="col-sm-12">
                    FROM :
                    <label id="lblFromCountry"></label> TO :
                    <label id="lblToCountry"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    PORT :
                    <label id="lblInterPort"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    FLIGHT/VESSEL :
                    <label id="lblVesselName"></label>
                </p>
            </div>
        </div>
        <div style="flex:2">
            <div class="row">
                <p class="col-sm-12">
                    ETD :
                    <label id="lblETDDate"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    HBL/HAWB :
                    <label id="lblHAWB"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    QUANTITY :
                    <label id="lblTotalContainer"></label>
                </p>
            </div>
        </div>
        <div style="flex:2">
            <div class="row">
                <p class="col-sm-12">
                    ETA :
                    <label id="lblETADate"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    MBL/MAWB :
                    <label id="lblMAWB"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    G.W :
                    <label id="lblNetWeight"></label>
                    <label id="lblWeightUnit"></label>
                </p>
            </div>
        </div>
    </div>
    <table style="width:100%;" border="1" class="text-center">
        <thead>
            <tr style="background-color:gainsboro;text-align:center;">
                <th width="50px">No</th>
                <th width="600px">DESCRIPTION</th>
                <th width="100px">ADVANCE</th>
                <th width="100px">NON-VAT</th>
                <th width="50px">WHT</th>
                <th width="100px">SERVICE</th>
            </tr>
        </thead>
        <tbody id="tbDetail"></tbody>
        <tr>
            <td colspan="6" style="border-top:solid;"></td>
        </tr>
        <tfoot>
            <tr style="font-weight:bold;">
                <td colspan="2" style="text-align:right;">TOTAL</td>
                <td style="text-align: right;">
                    <label id="lblSumAdvance"></label>
                </td>
                <td style="text-align: right;">
                    <label id="lblSumNonVat"></label>
                </td>
                <td style="text-align: right;">
                    <label id="lblSumWht"></label>
                </td>
                <td style="text-align: right;">
                    <label id="lblSumBeforeVat"></label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div style="display:flex">
                        <div style="text-align:left;flex:1;vertical-align:top">
                            <div id="lblShippingRemark"></div>
                            REMARKS :
                            <br />
                            <div id="lblDescription"></div>
                        </div>
                    </div>
                </td>
                <td colspan="2">
                    VAT (RATE=
                    <label id="lblVATRate"></label>%)
                    <br />
                    SERVICE+VAT
                    <br />
                    TOTAL
                    <br />
                    CUST. ADV
                    <br />
                    GRAND TOTAL
                </td>
                <td style="background-color :gainsboro;text-align:right;">
                    <label id="lblSumVat"></label>
                    <br />
                    <label id="lblSumAfterVat"></label>
                    <br />
                    <label id="lblSumTotal"></label>
                    <br />
                    <label id="lblSumCustAdv"></label>
                    <br />
                    <label id="lblSumGrandTotal"></label>
                </td>
            </tr>
            <tr>
                <td>TOTAL (BAHT)</td>
                <td colspan="6">
                    <div style="text-align:center;">
                        <label id="lblTotalBaht" style="font-size:12px;"></label>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
    <div style="display:flex;margin-top:5px">
        <div class="text-left" style="border:1px solid black;border-radius:5px;flex:1;margin-right:5px;padding:5px 5px 5px 5px;">
            WITHHOLDING TAX DETAIL
            <table style="width:100%">
                <tr>
                    <td style="width:45%">TRANSPORT 1%</td>
                    <td style="width:35%;text-align:right">
                        (<label id="lblSumBaseWht1"></label>)
                        <br />
                    </td>
                    <td style="width:20%;text-align:right">
                        <label id="lblSumWht1"></label>
                    </td>
                </tr>
                <tr>
                    <td style="width:45%">SERVICE 3%</td>
                    <td style="width:35%;text-align:right">
                        (<label id="lblSumBaseWht3"></label>)
                    </td>
                    <td style="width:20%;text-align:right">
                        <label id="lblSumWht3"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width:100%;font-weight:bold">
                        NET TOTAL (
                        <label id="lblCurrencyCode"></label>)=
                        <label id="lblForeignNet"></label> RATE=
                        <label id="lblExchangeRate"></label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            FOR THE CUSTOMER
            <br />
            <br />
            <br />
            <br />
            <br />
            .........................................................
            <br />
            __________/_________/________
            <br />
            AUTHORIZED SIGNATURE
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            FOR @ViewBag.PROFILE_COMPANY_NAME_EN
            <br />
            <br />
            <br />
            <br />
            <br />
            .........................................................
            <br />
            __________/_________/________
            <br />
            AUTHORIZED SIGNATURE
        </div>
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
        let ans = confirm('OK to print Original or Cancel For Copy');
        if (ans == true) {
            $('#dvCopy').html('<b>**ORIGINAL**</b>');
        } else {
            $('#dvCopy').html('<b>**COPY**</b>');
        }
        let h = dr.header[0][0];
        if (dr.header[0].length > 0) {
            $('#lblDocNo').text(h.DocNo);
            $('#lblDocDate').text(ShowDate(CDateTH(h.DocDate)));
            $('#lblCurrencyCode').text(h.CurrencyCode);
            $('#lblExchangeRate').text(h.ExchangeRate);
            $('#lblForeignNet').text(ShowNumber(h.ForeignNet, 2));
            //$('#lblDiscountRate').text(h.DiscountRate);
            $('#lblVATRate').text(ShowNumber(h.VATRate, 1));

	        $.get(path+'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch='+ h.BillToCustBranch,function(r){
                let c = r.company.data[0];
                if (c !== null) {
                    $('#lblTaxNumber').text(c.TaxNumber);
                        if (c.UsedLanguage == 'TH') {
                            if (Number(c.Branch) == 0) {
                                $('#lblTaxBranch').text('สำนักงานใหญ่');
                            } else {
                                $('#lblTaxBranch').text(c.Branch);
                            }
                            $('#lblCustName').text(c.Title+' '+c.NameThai);
                            $('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
                            //$('#lblCustTName').text(dr.customer[0][0].NameThai);
                        } else {
                            if (Number(c.Branch) == 0) {
                                $('#lblTaxBranch').text('HEAD OFFICE');
                            } else {
                                $('#lblTaxBranch').text(c.Branch);
                            }

                            $('#lblCustName').text(c.NameEng);
                            $('#lblCustAddress').text(c.EAddress1 + '\n' + c.EAddress2);
                            //$('#lblCustTName').text(dr.customer[0][0].NameEng);
                        }
                        //$('#lblCustTel').text(c.Phone);
                }
            });

            let j = dr.job[0][0];
            if (j !== null) {
                $('#lblCustInvNo').text(j.InvNo);
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
                //$('#lblFromCountry').text(j.DeclareNumber);
                $('#lblVesselName').text(j.VesselName);
                $('#lblTotalContainer').text(j.TotalContainer);
                //ShowInvUnit(path, j.InvProductUnit, '#lblQtyUnit');
                $('#lblNetWeight').text(j.TotalGW);
                ShowInvUnit(path, j.GWUnit, '#lblWeightUnit');
                $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                $('#lblHAWB').text(j.HAWB);
                //$('#lblMeasurement').text(j.Measurement);
                $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                $('#lblMAWB').text(j.MAWB);
                ShowVender(path, j.ForwarderCode, '#lblAgentName');
            }
            let remark = h.Remark1;
            remark += (h.Remark2 !== '' ? '<br/>' : '') + h.Remark2;
            remark += (h.Remark3 !== '' ? '<br/>' : '') + h.Remark3;
            remark += (h.Remark4 !== '' ? '<br/>' : '') + h.Remark4;
            remark += (h.Remark5 !== '' ? '<br/>' : '') + h.Remark5;
            remark += (h.Remark6 !== '' ? '<br/>' : '') + h.Remark6;
            remark += (h.Remark7 !== '' ? '<br/>' : '') + h.Remark7;
            remark += (h.Remark8 !== '' ? '<br/>' : '') + h.Remark8;
            remark += (h.Remark9 !== '' ? '<br/>' : '') + h.Remark9;
            remark += (h.Remark10 !== '' ? '<br/>' : '') + h.Remark10;
            $('#lblDescription').html(CStr(remark));
            remark=h.ShippingRemark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#lblShippingRemark').html(remark);

            //$('#lblSumDiscount').text(ShowNumber(h.TotalDiscount,2));
            $('#lblSumCustAdv').text('('+ShowNumber(h.TotalCustAdv,2)+')');
            $('#lblSumBeforeVat').text(ShowNumber(h.TotalIsTaxCharge,2));
            $('#lblSumVat').text(ShowNumber(h.TotalVAT,2));
            $('#lblSumAfterVat').text(ShowNumber(Number(h.TotalIsTaxCharge)+Number(h.TotalVAT),2));
            $('#lblSumAdvance').text(ShowNumber(h.TotalAdvance,2));
            $('#lblSumGrandTotal').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount),2));
            //$('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.Total50Tavi)-Number(h.TotalDiscount),2));

            $('#lblTotalBaht').text('(' + CNumEng(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount),2)) + ')');

        }
        let d = dr.detail[0];
        sortData(d, 'ItemNo', 'asc');

        let sumbase1 = 0;
        let sumbase3 = 0;
        let sumtax1 = 0;
        let sumtax3 = 0;
        let sumadv = 0;
        let sumnonvat = 0;
        let irow = 0;
        if (d.length > 0) {
            for (let o of d) {
                irow += 1;
                let html = '<tr>';
                html += '<td style="text-align:center">' + irow + '</td>';
                if (o.AmtAdvance > 0) {
                    html += '<td>' + o.SDescription + (o.ExpSlipNO !== null ? '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; #' + o.ExpSlipNO : '') + '</td>';
                    html += '<td style="text-align:right;">' + (o.AmtAdvance > 0 ? ShowNumber(o.AmtAdvance, 2): '') +'</td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                } else {
                    html += '<td>' + o.SDescription + '</td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;">' + (o.AmtVat == 0 ? ShowNumber(o.AmtCharge, 2):'') + '</td>';
                    html += '<td style="text-align:right;">' + (o.Amt50Tavi > 0 ? ShowNumber(o.Amt50Tavi, 2) : '') + '</td>';
                    html += '<td style="text-align:right;">' + (o.AmtVat > 0 ? ShowNumber(o.AmtCharge, 2): '') + '</td>';
                }
                html += '</tr>';

                $('#tbDetail').append(html);
                if (o.AmtAdvance > 0) {
                    sumadv += o.TotalAmt;
                }
                if (o.AmtCharge > 0 && o.AmtVat == 0) {
                    sumnonvat += Number(o.TotalAmt)+Number(o.Amt50Tavi);
                }
                if (o.Amt50Tavi > 0 && o.AmtCharge>0) {
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
        let rowremain = 24 - irow;
        for (let i = 1; i <= rowremain; i++) {
            let html = '<tr>';
            html += '<td style="text-align:center"></td>';
            html += '<td><br/></td>';
            html += '<td style="text-align:right;"></td>';
            html += '<td style="text-align:right;"></td>';
            html += '<td style="text-align:right;"></td>';
            html += '<td style="text-align:right;"></td>';
            html += '</tr>';
            $('#tbDetail').append(html);
        }
        $('#lblSumNonVat').text(ShowNumber(sumnonvat, 2));
        $('#lblSumTotal').text(ShowNumber(Number(sumnonvat) + Number(sumadv) + Number(h.TotalIsTaxCharge) + Number(h.TotalVAT), 2));
        $('#lblSumBaseWht1').text(ShowNumber(sumbase1, 2));
        $('#lblSumBaseWht3').text(ShowNumber(sumbase3,2));
        $('#lblSumWht').text(ShowNumber(sumtax1 + sumtax3, 2));

        $('#lblSumWht1').text(ShowNumber(sumtax1,2));
        $('#lblSumWht3').text(ShowNumber(sumtax3,2));
    }
</script>