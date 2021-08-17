
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    * {
        font-size: 12px;
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
</style>
<div style="text-align:center;width:100%;padding:5px 5px 5px 5px">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">ใบแจ้งหนี้ (INVOICE)</label>
</div>
<div id="dvForm"  style="display:flex;flex-direction:column;">        
    <div style="display:flex;flex-direction:row;">
        <div style="flex:3;border:1px solid black;border-radius:5px;margin-right:5px;padding:5px 5px 5px 5px;">
            NAME : <label id="lblCustName"></label><br />
            ADDRESS : <label id="lblCustAddress"></label><br />
            <!--TEL : <label id="lblCustTel"></label><br />-->
            <label>TAX-ID:</label>
            <label id="lblTaxNumber"></label>
            <label>BRANCH:</label>
            <label id="lblTaxBranch"></label>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;">
            INV NO. : <label id="lblDocNo"></label><br />
            INV DATE : <label id="lblDocDate"></label><br />
            CUST INV : <label id="lblCustInvNo"></label><br />
            JOB NO : <label id="lblJobNo"></label><br />
        </div>
    </div>
    <div style="border:1px solid black;border-radius:5px;margin-top:5px;padding:5px 5px 5px 5px;">
        <div style="display:flex">
            <div style="flex:1">
                FROM :<label id="lblFromCountry"></label> TO :<label id="lblToCountry"></label>
            </div>
            <div style="flex:1">
                ETD :<label id="lblETDDate"></label>
            </div>
            <div style="flex:1">
                ETA :<label id="lblETADate"></label>
            </div>
        </div>
        <div style="display:flex">
            <div style="flex:1">
                PORT :<label id="lblInterPort"></label>
            </div>
            <div style="flex:1">
                HBL/HAWB :<label id="lblHAWB"></label>
            </div>
            <div style="flex:1">
                MBL/MAWB :<label id="lblMAWB"></label>
            </div>
        </div>
        <div style="display:flex">
            <div style="flex:1">
                FLIGHT/VESSEL :<label id="lblVesselName"></label>
            </div>
            <div style="flex:1">
                CUSTOMER :<label id="lblCustTName"></label>
            </div>

        </div>
        <div style="display:flex">
            <div style="flex:1">
                QUANTITY :<label id="lblQtyGross"></label> <label id="lblQtyUnit"></label>
            </div>
            <div style="flex:1">
                Customer PO :<label id="lblCustPo"></label>
            </div>
            <div style="flex:1">
            </div>
        </div>
    </div>
    <div>
        <table style="width:100%;margin-top:5px;" border="1" class="text-center">
            <tr style="background-color :gainsboro;text-align:center;font-weight:bold">
                <td width="50px">No</td>
                <td width="370px">DESCRIPTION</td>
                <td width="80px">PRICE</td>
                <td width="50px">QTY</td>
                <td width="100px">ADVANCE</td>
                <td width="100px">NON-VAT</td>
                <td width="100px">SERVICE</td>
            </tr>
            <tbody id="tbDetail"></tbody>
            <tr style="font-weight:bold;">
                <td colspan="4">
                    TOTAL AMOUNT
                </td>
                <td style="text-align:right">
                    <label id="lblSumAdvance"></label>
                </td>
                <td style="text-align:right">
                    <label id="lblSumNonVat"></label>
                </td>
                <td style="text-align:right">
                    <label id="lblSumBeforeVat"></label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="display:flex">
                        <div style="text-align:left;flex:1;vertical-align:top">
                            <div id="lblShippingRemark"></div>
                            REMARKS :<br />
                            <div id="lblDescription"></div>
                        </div>
                    </div>
                </td>
                <td colspan="2">
                    VAT (RATE=<label id="lblVATRate"></label>%)<br />
                    SERVICE+VAT<br />
                    DISCOUNT (RATE=<label id="lblDiscountRate"></label>%)<br />
                    CUST. ADV<br />
                    <b>GRAND TOTAL</b>
                </td>
                <td style="background-color:gainsboro;text-align:right;" colspan="2">
                    <label id="lblSumVat"></label><br />
                    <label id="lblSumAfterVat"></label><br />
                    <label id="lblSumDiscount"></label><br />
                    <label id="lblSumCustAdv"></label><br />
                    <label id="lblSumGrandTotal" style="font-weight:bold;"></label>
                </td>
            </tr>
            <tr>
                <td>TOTAL<br />(<label id="lblCurrency"></label>)</td>
                <td colspan="6">
                    <div style="text-align:center;"><label id="lblTotalBaht" style="font-size:14px;font-weight:bold"></label></div>
                </td>
            </tr>
        </table>
    </div>
    <div style="display:flex;margin-top:5px;">
        <div class="text-left" style="border:1px solid black;border-radius:5px;flex:1;margin-right:5px;padding:5px 5px 5px 5px;font-size:10px;">
            WITHHOLDING TAX DETAIL
            <table style="width:100%;">
                <tr>
                    <td style="width:55%;font-size:10px;">TRANSPORT 1%</td>
                    <td style="width:25%;text-align:right;font-size:10px;"><label id="lblSumBaseWht1"></label><br /></td>
                    <td style="width:20%;text-align:right;font-size:10px;"><label id="lblSumWht1"></label></td>
                </tr>
                <tr>
                    <td style="width:55%;font-size:10px;">SERVICE 3%</td>
                    <td style="width:25%;text-align:right;font-size:10px;"><label id="lblSumBaseWht3"></label></td>
                    <td style="width:20%;text-align:right;font-size:10px;"><label id="lblSumWht3"></label></td>
                </tr>
                <tr>
                    <td colspan="2" style="width:80%;font-size:10px;">
                        <b>NET AMOUNT</b>
                    </td>
                    <td style="width:20%;text-align:right;font-size:10px;">
                        <label id="lblSumNetInvoice" style="font-weight:bold"></label>
                    </td>
                </tr>

            </table>
            <br />
            <div>
            </div>
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;margin-right:5px;padding:5px 5px 5px 5px;font-size:10px;">
            FOR THE CUSTOMER <br /><br /> <br /><br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
            AUTHORIZED SIGNATURE
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;font-size:10px;">
            FOR @ViewBag.PROFILE_COMPANY_NAME <br /><br /> <br /><br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
            AUTHORIZED SIGNATURE
        </div>
    </div>
    @If ViewBag.DATABASE = "2" Then
        @<div style="border:1px solid black;border-radius:5px;margin-top:5px;padding:5px 5px 5px 5px;">
            สั่งจ่าย : <span id="lblCompanyName2" style="font-weight:bold">บจก.เกื้อพสิษฐ์</span> บัญชีออมทรัพย์ ธนาคารกสิกรไทย สาขาถนนศรีนครินทร์ กม.17<br />
            เลขที่บัญชี <span id="lblAccountName2" style="font-weight:bold">026-8-76046-6</span> <br />
            ชำระโดย By <input type="checkbox" />เงินสด/Cash <input type="checkbox" />เงินโอน/Transfer <input type="checkbox" /> เช็ค/Cheque No_______________/D_____________<br />
            ธนาคาร/ Bank ___________________________________ จำนวนเงิน/Amount__________________บาท/Baht
        </div>
    Else
        @<div style="border:1px solid black;border-radius:5px;margin-top:5px;padding:5px 5px 5px 5px;">
            สั่งจ่าย : <span id="lblCompanyName2" style="font-weight:bold">บจก.เดอะโซลูชั่น โลจิสติกส์</span>
            <br />-บัญชีออมทรัพย์ ธนาคารกสิกรไทย สาขาถนนศรีนครินทร์ กม.17 เลขที่บัญชี <span id="lblAccountName2" style="font-weight:bold">026-8-76862-9</span>
            <br />-บัญชีกระแสรายวัน ธนาคารกสิกรไทย สาขาถนนรัชดาภิเษก (ตากสิน-ท่าพระ) เลขที่บัญชี <span id="lblAccountName3" style="font-weight:bold">707-1-00389-7</span>
            <br />-บัญชีออมทรัพย์ ธนาคารกรุงเทพ สาขาถนนเทพารักษ์ กม.22 เลขที่บัญชี <span id="lblAccountName4" style="font-weight:bold">921-0-38888-1</span>
            <br />-บัญชีกระแสรายวัน ธนาคารกรุงเทพ สาขาถนนเทพารักษ์ กม.22 เลขที่บัญชี <span id="lblAccountName5" style="font-weight:bold">921-3-00552-4</span>
            <br />ชำระโดย By <input type="checkbox" />เงินสด/Cash <input type="checkbox" />เงินโอน/Transfer <input type="checkbox" /> เช็ค/Cheque No_______________/D_____________<br />
            ธนาคาร/ Bank ___________________________________ จำนวนเงิน/Amount__________________บาท/Baht
        </div>
    End If
</div>
<script type="text/javascript">
    var path = '@Url.Content("~")';
    const license = '@ViewBag.LICENSE_NAME';
    let branch = getQueryString('branch');
    let invno = getQueryString('code');
    $.get(path + 'acc/getinvoice?branch=' + branch + '&code=' + invno, function (r) {
        if (r.invoice.header!== null) {
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
            $('#lblCurrency').text(h.CurrencyCode);
            $('#lblExchangeRate').text(h.ExchangeRate);
            $('#lblForeignNet').text(ShowNumber(h.ForeignNet, 2));
            $('#lblDiscountRate').text(h.DiscountRate);
            $('#lblVATRate').text(ShowNumber(h.VATRate,1));
            $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch, function (r) {
                let c = r.company.data[0];
                if (c!== null) {
                    $('#lblTaxNumber').text(c.TaxNumber);
                    //if (c.UsedLanguage == 'TH') {
                    //if (Number(c.Branch == 0)) {
                    //$('#lblTaxBranch').text('สำนักงานใหญ่');
                    //} else {
                    //$('#lblTaxBranch').text(c.Branch);
                    //}
                        //$('#lblCustName').text(c.Title+' '+c.NameThai);
                        //$('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
                    //$('#lblCustTName').text(dr.customer[0][0].NameThai);
                    //} else {
                    if (Number(c.Branch == 0)) {
                        $('#lblTaxBranch').text('HEAD OFFICE');
                    } else {
                        $('#lblTaxBranch').text(c.Branch);
                    }
                    $('#lblCustName').text(c.NameEng);
                    $('#lblCustAddress').text(c.EAddress1 + '\n' + c.EAddress2);
                    $('#lblCustTName').text(dr.customer[0][0].NameEng);
                //}
                //$('#lblCustTel').text(c.Phone);
                }

            });
            let j = dr.job[0][0];
            if (j!== null) {
                $('#lblCustInvNo').text(j.InvNo);
                $('#lblJobNo').text(j.JNo);
	            if (Number(j.JobType) == 1) {
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
                $('#lblQtyGross').text(j.InvProductQty);
                ShowInvUnit(path, j.InvProductUnit, '#lblQtyUnit');
                //$('#lblNetWeight').text(j.TotalNW);
                //ShowInvUnit(path, j.GWUnit, '#lblWeightUnit');
                $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                $('#lblHAWB').text(j.HAWB);
                //$('#lblMeasurement').text(j.Measurement);
                $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                $('#lblMAWB').text(j.MAWB);
                $('#lblCustPo').text(j.CustRefNO);
            }
            let remark = h.Remark1;
	        remark += (h.Remark2 !=='' ? '<br/>':'')+ h.Remark2;
            remark +=(h.Remark3 !=='' ? '<br/>':'')+ h.Remark3;
	        remark += (h.Remark4 !=='' ? '<br/>':'')+ h.Remark4;
            remark +=(h.Remark5 !=='' ? '<br/>':'')+ h.Remark5;
	        remark += (h.Remark6 !=='' ? '<br/>':'')+ h.Remark6;
            remark +=(h.Remark7 !=='' ? '<br/>':'')+ h.Remark7;
	        remark += (h.Remark8 !=='' ? '<br/>':'')+ h.Remark8;
            remark +=(h.Remark9 !=='' ? '<br/>':'')+ h.Remark9;
	        remark += (h.Remark10 !=='' ? '<br/>':'')+ h.Remark10;
            $('#lblDescription').html(CStr(remark));
            remark = h.ShippingRemark.replace(/ (?:\r\n|\r|\n)/g, '<br/>');
            $('#lblShippingRemark').html(remark);

            $('#lblSumDiscount').text(ShowNumber(h.TotalDiscount, 2));
            $('#lblSumCustAdv').text(ShowNumber(h.TotalCustAdv,2));

            $('#lblSumVat').text(ShowNumber(h.TotalVAT,2));

            $('#lblSumAdvance').text(ShowNumber(h.TotalAdvance,2));
            $('#lblSumTotal').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT),2));
            $('#lblSumGrandTotal').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount),2));
            $('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT) - Number(h.TotalCustAdv) - Number(h.Total50Tavi) - Number(h.TotalDiscount), 2));
            if (h.CurrencyCode == 'THB') {
                $('#lblTotalBaht').text('(' + CNumThai(CDbl($('#lblSumGrandTotal').text(), 2)) + ')');
            } else {
                $('#lblTotalBaht').text('(' + CNumEng(CDbl($('#lblSumGrandTotal').text(), 2)) + ')');
            }
            $.get(path + 'Acc/GetInvDetailReport?Branch=' + h.BranchCode + '&Code=' + h.DocNo).done(function (r) {
                if (r.invdetail.data.length > 0) {
                    let d = r.invdetail.data;
                    if (d[0].ItemNo !== null) {
                        LoadDetail(d);
                    }
                }
            });
        }

    }
    function LoadDetail(d) {
        //sortData(d,'AmtAdvance','asc');
        sortData(d, 'CTN_NO', 'asc');
        // sortData(d,'AmtVat','dasc');
	
        let sumbase1 = 0;
        let sumbase3 = 0;
        let sumtax1 = 0;
        let sumtax3 = 0;
        let sumbasevat = 0;
        let sumnonvat = 0;
        let sumvat = 0;
        let currCtn = '-';
        let i = 0;
        if (d.length > 0) {
            for (let o of d) {
                let Html = '';
                if (currCtn !== o.CTN_NO) {
                    currCtn = o.CTN_NO;
                    Html = '<tr>';
                    Html += '<td colspan="7">' + o.CTN_NO + '</td>';
                    Html += '</tr>';
                    $('#tbDetail').append(Html);
                }
                i++;
                Html = '<tr>';
                Html += '<td style="text-align:center">' + i + '</td>';
                Html += '<td>' + o.SDescription + '-' + o.TRemark + '</td>';
                //Html += '<td style="text-align:center">' + o.CurrencyCode + '</td>';
                //Html += '<td style="text-align:center">' + o.QtyUnit + '</td>';
                Html += '<td style="text-align:right">' + ShowNumber(Number(o.UnitPrice), 2) + '</td>';
                Html += '<td style="text-align:center">' + o.Qty + '</td>';
                if (o.AmtAdvance > 0) {
                    Html += '<td style="text-align:right">' + ShowNumber(Number(o.AmtAdvance) * Number(o.ExchangeRate), 2) + '</td>';
                    Html += '<td style="text-align:right">0.00</td>';
                } else {
                    Html += '<td style="text-align:right">0.00</td>';
                    Html += '<td style="text-align:right">' + (o.AmtVat == 0 ? ShowNumber(Number(o.AmtCharge) * Number(o.ExchangeRate), 2) : "0.00") + '</td>';
                }
                Html += '<td style="text-align:right">' + (o.AmtVat > 0 ? ShowNumber(Number(o.AmtCharge) * Number(o.ExchangeRate), 2) : "0.00") + '</td>';

                Html += '</tr>';

                $('#tbDetail').append(Html);
                if (o.AmtCharge > 0) {
                    if (o.AmtVat > 0) {
                        sumbasevat += (o.Amt - o.AmtDiscount);
                        sumvat += o.AmtVat;
                    } else {

                        sumnonvat += (o.Amt - o.AmtDiscount);
                    }
                    if (o.Amt50Tavi > 0) {
                        if (o.Rate50Tavi == 1) {
                            sumbase1 += (o.Amt - o.AmtDiscount);
                            sumtax1 += o.Amt50Tavi;
                        } else {
                            sumbase3 += (o.Amt - o.AmtDiscount);
                            sumtax3 += o.Amt50Tavi;
                        }
                    }
                }

            }
        }
        $('#lblSumNonVat').text(ShowNumber(sumnonvat, 2));
        $('#lblSumBeforeVat').text(ShowNumber(sumbasevat, 2));
        $('#lblSumAfterVat').text(ShowNumber(sumbasevat + sumvat, 2));
        $('#lblSumBaseWht1').text(ShowNumber(sumbase1, 2));
        $('#lblSumBaseWht3').text(ShowNumber(sumbase3, 2));

        $('#lblSumWht1').text(ShowNumber(sumtax1, 2));
        $('#lblSumWht3').text(ShowNumber(sumtax3, 2));
    }
</script>