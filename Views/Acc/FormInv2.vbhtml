@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    * {
        font-size: 11px;
    }

    body {
        line-height: 1;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .bold {
        font-weight: bold;
    }

    .table td, .table th, .table thead th {
        border: 0px none;
        padding: 0.5em;
    }

    .curveBorder {
        border: 1px solid black;
        border-radius: 10px;
        padding: 5px;
    }

    .underLine {
        border-bottom: 1px solid black !important;
    }

    .upperLine {
        border-top: 1px solid black !important;
    }

    .textSpace {
        width: 20em;
    }
</style>

<p class="center bold">
    <label id="companyName" style="font-size:20px"></label>
</p>
<p class="center bold">
    <label id="address">ที่อยู่</label>
</p>
<p class="center bold">
    <label id="taxIdLbl">TAX ID :</label>
    <label id="taxId"></label>
</p>
<p class="center bold">
    <label style="font-size:16px">ใบแจ้งหนี้/INVOICE</label>
</p>

<div style="display:flex">
    <div style="flex:60%" class="curveBorder">
        <table class="table table-borderless">
            <tbody>
                <tr>
                    <td class="bold">
                        <label id="billToLbl">BILL TO NAME AND ADDRESS</label>
                    </td>
                    <td class="right">
                        <label id="id"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="billTo">

                        </label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="flex:2%">

    </div>
    <div style="flex:38%" class="curveBorder">
        <table class="table table-borderless">
            <tbody>
                <tr>
                    <td>
                        <label id="invoiceNoLbl">INVOICE NO.:</label>
                    </td>
                    <td>
                        <label id="invoiceNo"> </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="invoiceDateLbl">INVOICE DATE:</label>
                    </td>
                    <td>
                        <label id="invoiceDate"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="crTermLbl">CR. TERM:</label>
                    </td>
                    <td>
                        <label id="crTerm"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="dueDateLbl">DUE DATE:</label>
                    </td>
                    <td>
                        <label id="dueDate"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="currencyLbl">CURRENCY:</label>
                    </td>
                    <td>
                        <label id="currency"></label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<table class="table">

    <tbody>
        <tr>
            <td><label id="destinyLbl">ORIGIN/ DEST</label></td>
            <td>:</td>
            <td><label id="destiny"></label></td>

            <td><label id="jobNoLbl">JOB NO.</label></td>
            <td>:</td>
            <td><label id="jobNo"></label></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td><label id="vesselLbl">VESSEL/VOYAGE</label></td>
            <td>:</td>
            <td><label id="vessel">SINAR SOLO V. 936N</label></td>

            <td><label id="etdLbl">ETD</label></td>
            <td>:</td>
            <td><label id="etd"></label></td>

            <td><label id="etaLbl">ETA</label></td>
            <td>:</td>
            <td><label id="eta"></label></td>
        </tr>

        <tr>
            <td><label id="hblNoLbl">H-B/L NO.</label></td>
            <td>:</td>
            <td><label id="hblNo"></label></td>

            <td><label id="quantityLbl">QUANTITY</label></td>
            <td>:</td>
            <td><label id="quantity"></label></td>

            <td><label id="totpkgLbl">TOTPKG</label></td>
            <td>:</td>
            <td><label id="totpkg"></label></td>
        </tr>

        <tr>
            <td><label id="newBlNoLbl">NEW B/L NO</label></td>
            <td>:</td>
            <td><label id="newBlNo"></label></td>

            <td><label id="weightLbl">WEIGHT</label></td>
            <td>:</td>
            <td><label id="weight"></label></td>

        </tr>

        <tr>
            <td><label id="containerNoLbl">CONTANER NO.</label></td>
            <td>:</td>
            <td><label id="containerNo"></label></td>

            <td><label id="volumeLbl">VOLUME</label></td>
            <td>:</td>
            <td><label id="volume"></label></td>
        </tr>

        <tr>
            <td><label id="custInvNoLbl">CUST INV NO.</label></td>
            <td>:</td>
            <td><label id="custInvNo"></label></td>

            <td><label id="refLbl">REF.</label></td>
            <td>:</td>
            <td><label id="ref"></label></td>
        </tr>

        <tr>
            <td><label id="carrierLbl">CARRIER</label></td>
            <td>:</td>
            <td><label id="carrier"></label></td>
        </tr>
    </tbody>
</table>

<table class="table  table-borderless">
    <thead>
        <tr class="upperLine underLine">
            <th class="bold align-top" rowspan="2">DESCRIPTION</th>
            <th class="center bold" colspan="6">IN SOURCE CURRENCY</th>
            <th class="center bold" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr class="upperLine">
            <th class="center bold">W/T</th>
            <th class="center bold">QTYs</th>
            <th class="center bold">UOM</th>
            <th class="center bold">Curr.</th>
            <th class="center bold">Exc.</th>
            <th class="center bold">@ UNIT</th>
            <th class="center bold">ADVANCE</th>
            <th class="center bold">NON VAT</th>
            <th class="center bold">VAT</th>
        </tr>
    </thead>
    <tbody>
        <tr class="upperLine">
            <td>INSPECTION CHARGE</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">2,500.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">2,500.00</td>
        </tr>
        <tr>
            <td>CUSTOMS CLEARANCE CHARGE</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">3,000.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">3,000.00</td>
        </tr>
        <tr>
            <td>FDA</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">2,000.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">2,000.00</td>
        </tr>
        <tr>
            <td>LPI PERMIT (DFA)</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,800.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">1,800.00</td>
        </tr>
        <tr>
            <td>TRANSPORTATION</td>
            <td class="right">1.00</td>
            <td class="right">1.000</td>
            <td class="center">TRUCK</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">9,200.00</td>
            <td class="right">-</td>
            <td class="right">- </td>
            <td class="right">9,200.00</td>

        </tr>
        <tr>
            <td>THC , B/L, D/O ( RECEIPT )</td>
            <td class="right">-</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">8,223.68</td>
            <td class="right">8,223.68</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
        <tr>
            <td>CUSTOM TAX ( RECEIPT )</td>
            <td class="right">-</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">200.00</td>
            <td class="right">200.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
        <tr>
            <td>WAREHOUSE RENTAL(RECEIPT)</td>
            <td class="right">-</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">676.13</td>
            <td class="right">676.13</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
    </tbody>
</table>
<table class="table">
    <thead></thead>
    <tbody>
        <tr class="upperLine">
            <td class="underLine">TAX RATE</td>
            <td class="center underLine">GROSS</td>
            <td class="center underLine">W/T AMT</td>
            <td id="amountLbl" class="right">AMOUNT:</td>
            <td id="advanceAmount" class="right"></td>
            <td id="nonVatAmount" class="right" style="width:5em"></td>
            <td id="vatAmount" class="right"></td>
        </tr>
        <tr>
            <td id="taxRate1"></td>
            <td id="gross1" class="center right"></td>
            <td id="wtAmt1" class="center right"></td>
            <td id="valueAddedTaxLbl" class="right">VALUE ADDED TAX 7%:</td>
            <td class="right underLine"></td>
            <td class="right underLine"></td>
            <td id="valueAddedTax" class="right underLine"></td>
        </tr>
        <tr>
            <td id="taxRate1_5"></td>
            <td id="gross1_5" class="center right"></td>
            <td id="wtAmt1_5" class="center right"></td>
            <td id="totalAmountLbl" class="right">TOTAL AMOUNT:</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="totalAmount" class="right"></td>
        </tr>
        <tr>
            <td id="taxRate3"></td>
            <td id="gross3" class="center right"></td>
            <td id="wtAmt3" class="center right"></td>
            <td id="lessWithholdingTaxLbl" class="right">LESS: WITHHOLDING TAX:</td>
            <td class="right underLine"></td>
            <td class="right underLine"></td>
            <td id="lessWithholdingTax" class="right underLine"></td>
        </tr>
        <tr class="underLine">
            <td class="center"></td>
            <td class="center"></td>
            <td class="center"></td>
            <td id="netAmountLbl" class="right">NET AMOUNT:</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="netAmount" class="right"></td>
        </tr>
    </tbody>
</table>

<p>TOTAL AMOUNT IN WORDS: BAHT TWENTY-EIGHT THOUSAND FIVE HUNDRED TWENTY-THREE AND</p>
<p class="bold">DULY CHECKED AND RECEIVED IN GOOD CONDITION</p>
<table class="table">
    <tr>
        <td class="bold">Reciever :</td>
        <td class="underLine textSpace"></td>
        <td class="bold">Sender :</td>
        <td class="underLine textSpace"></td>
        <td> </td>
        <td class="underLine center">ALISA</td>
    </tr>
    <tr>
        <td class="bold">DATE :</td>
        <td class="underLine  textSpace"></td>
        <td class="bold">DATE :</td>
        <td class="underLine  textSpace"></td>
        <td> </td>
        <td class="center bold">AUTHORIZED SIGNATURE</td>
    </tr>
</table>
<p class="bold">PLEASE ISSUE A CROSSED CHEQUE PAYABLE TO "TOTAL SHIPPING SERVICE CO.,LTD."</p>
<p class="bold">หมายเหตุ ใบแจ้งหนี้นี้มิใช่ใบกำกับภาษี ใบกำกับภาษีจะออกให้ต่อเมื่อได้รับชำระเงินเรียบร้อยแล้ว</p>

<script type="text/javascript">
    const path = '@Url.Content("~")';
    let bShowSlip = false;
    let branch = getQueryString('branch');
    let invno = getQueryString('code');
    let tempheader = localStorage.getItem('invheader');
    let tempdetail = localStorage.getItem('invdetail');
    let tempjob = localStorage.getItem('invjob');
    if (confirm("Show Slip in Description?") == true) {
        bShowSlip = true;
    }
    if (tempheader !== '' && tempdetail !== '' && invno == '') {
        let oTemp = {
            header: [ JSON.parse(tempheader)],
            detail: [JSON.parse(tempdetail)],
            job: JSON.parse(tempjob)
        };
        ShowData(oTemp);

    } else {
        $.get(path + 'acc/getinvoice?branch=' + branch + '&code=' + invno, function (r) {
            if (r.invoice.header !== null) {
                console.log(JSON.stringify(r));
            }
        });
    }

    function ShowData(dr) {

        if (dr.header[0].length > 0) {
            let h = dr.header[0][0];
            $('#lblDocNo').text(h.DocNo);
            $('#lblDocDate').text(ShowDate(CDateEN(h.DocDate)));
            $('#lblDueDate').text(ShowDate(CDateEN(h.DueDate)));
            $('#lblCurrency').text(h.CurrencyCode);
            if (h.ExchangeRate > 1) {
                $('#rowForeign').css('display', 'inline');
            }
            $('#lblExcRate').text(h.ExchangeRate);
            $('#lblSumNetInvoiceF').text(ShowNumber(h.ForeignNet, 2));

            $('#lblVATRate').text(ShowNumber(h.VATRate,1));
	        $.get(path+'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch='+ h.BillToCustBranch,function(r){
                let c = r.company.data[0];
                if (c !== null) {
                    $('#lblTaxNumber').text(c.TaxNumber);
                    if (Number(c.Branch == 0)) {
                        $('#lblTaxBranch').text('HEAD OFFICE');
                    } else {
                        $('#lblTaxBranch').text(c.Branch);
                    }
                    $('#lblCustName').text(c.NameEng);
                    $('#lblCustAddress').text(c.EAddress1 + '\n' + c.EAddress2 + ' ' + c.TProvince + ' ' + c.TPostCode);
                    $('#lblCustTel').text(c.Phone);
                    //$('#lblCustTName').text(dr.customer[0][0].NameEng);
                        //$('#lblCustTel').text(c.Phone);
                }
            });
            $.get(path + 'Master/GetCompany?Code=' + h.CustCode + '&Branch=' + h.CustBranch, function (r) {
                let c = r.company.data[0];
                if (c !== null) {
                    $('#lblCustTName').text(c.NameEng);
                }
            });
            if (dr.job !== undefined) {
                let job = dr.job[0];
                let invNoList = '';
                let poNoList = '';
                let custContactList = '';
                let jobNoList = '';
                let containerList = '';

                for (let j of job) {
                    if (invNoList.indexOf(j.InvNo) < 0) {
                        if (invNoList !== '') invNoList += ',';
                        invNoList += j.InvNo;
                    }
                    if (poNoList.indexOf(j.CustRefNO) < 0) {
                        if (poNoList !== '') poNoList += ',';
                        poNoList += j.CustRefNO;
                    }
                    if (custContactList.indexOf(j.CustContactName) < 0) {
                        if (custContactList !== '') custContactList += ',';
                        custContactList += j.CustContactName;
                    }
                    if (jobNoList.indexOf(j.JNo) < 0) {
                        if (jobNoList !== '') jobNoList += ',';
                        jobNoList += j.JNo;
                    }
                    if (containerList.indexOf(j.TotalContainer) < 0) {
                        if (containerList !== '') containerList += ',';
                        containerList += j.TotalContainer;
                    }
                }
                $('#lblCustInvNo').text(invNoList);
                $('#lblCustPoNo').text(poNoList);
                $('#lblCustContact').text(custContactList);
                $('#lblJobNo').text(jobNoList);
                $('#lblTotalContainer').text(containerList);

                $('#tbLoading').hide();
                $.get(path + 'JobOrder/GetTransportReport?Branch=' + h.BranchCode + '&JobList=' + jobNoList).done(function (r) {
                    if (r.transport.data.length > 0) {
                        let dr = r.transport.data;
                        if (dr[0].BookingNo !== null) {
                            let html = '';
                            let i = 0;
                            for (let row of dr) {

                                i += 1;
                                html += '<tr>';
                                html += '<td>' + i + '</td>';
                                html += '<td style="padding-left:5px;padding-right:5px"> ' + row.BookingNo + ' </td>';
                                html += '<td style="padding-left:5px;padding-right:5px"> ' + row.CTN_SIZE + ' </td>';
                                html += '<td style="padding-left:5px;padding-right:5px"> ' + row.CTN_NO + ' </td>';
                                html += '<td style="padding-left:5px;padding-right:5px"> ' + row.Location + ' </td>';
                                html += '</tr>';
                            }
                            $('#tbLoading tbody').html(html);
                            $('#tbLoading').show();

                        }
                    }
                });
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
            $('#lblSumVat').text(ShowNumber(h.TotalVAT,2));

            $('#lblSumAdvance').text(ShowNumber(h.TotalAdvance,2));
            $('#lblSumTotal').text(ShowNumber(Number(h.TotalAdvance),2));
            $('#lblSumGrandTotal').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount),2));
            $('#lblTotalBaht').text('(' + CNumEng(CDbl(Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount), 2)) + ')');

            $('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalNet),2));
        }
        let d = dr.detail[0];

        sortData(d, 'ItemNo', 'asc');

        let sumbase1 = 0;
        let sumbase3 = 0;
        let sumtax1 = 0;
        let sumtax3 = 0;
        let sumvat = 0;
        let sumbaseadv = 0;
        let sumbasevat = 0;
        let sumvatadv = 0;
        let sumnonvat = 0;
        if (d.length > 0) {
            let irow = 0;
            for (let o of d) {
                irow += 1;
                let html = '<tr>';
                html += '<td style="text-align:center">' + irow + '</td>';
                html += '<td style="word-break:break-word">' + o.SDescription;
                if (o.CurrencyCode !== 'THB') {
                    html += ' ('+ ShowNumber(o.FTotalAmt) +' ' + o.CurrencyCode + ')';
                }
                if (bShowSlip == true) {
                    if (o.ExpSlipNO !== '') {
                        html += ' <span style="font-size:7px">#' + o.ExpSlipNO + '</span>';
                    }
                }
                html += '</td>';
                if (o.QtyUnit !== '') {
                    html += '<td style="text-align:center">' + o.Qty + 'x' + o.QtyUnit + '</td>';
                } else {
                    html += '<td style="text-align:center">' + o.Qty + '</td>';
                }
                html += '<td style="text-align:right">'+ShowNumber(o.UnitPrice, 2)+'</td>';

                sumbaseadv += (o.AmtAdvance > 0 ? Number(o.Amt) : 0);
                sumvatadv += (o.AmtAdvance > 0 ? Number(o.AmtVat) : 0);
                sumnonvat += (o.AmtCharge > 0 && o.AmtVat == 0 ? Number(o.Amt) : 0);
                sumbasevat += (o.AmtCharge > 0 && o.AmtVat > 0 ? Number(o.Amt) : 0);
                sumvat += (o.AmtCharge > 0 && o.AmtVat > 0 ? Number(o.AmtVat) : 0);

                html += '<td style="text-align:right">' + (o.AmtAdvance > 0 ? ShowNumber(o.Amt, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtAdvance > 0 ? ShowNumber(o.AmtVat, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtAdvance > 0 ? ShowNumber(o.TotalAmt, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtCharge > 0 && o.AmtVat==0 ? ShowNumber(o.Amt, 2) : '0.00') + '</td>';
                html += '<td style="text-align:right">' + (o.AmtCharge > 0 && o.AmtVat > 0 ? ShowNumber(o.Amt, 2) : '0.00') + '</td>';
                html += '</tr>';

                $('#tbDetail').append(html);

                if (o.Amt50Tavi > 0) {
                    if (o.Rate50Tavi == 1) {
                        sumbase1 += Number(o.Amt)-Number(o.AmtDiscount);
                        sumtax1 += Number(o.Amt50Tavi);
                    } else {
                        sumbase3 += Number(o.Amt)-Number(o.AmtDiscount);
                        sumtax3 += Number(o.Amt50Tavi);
                    }
                }
            }
        }
        $('#lblSumNonVat').text(ShowNumber(sumnonvat, 2));
        $('#lblSumBeforeVat').text(ShowNumber(sumbasevat, 2));
        $('#lblSumChargeVat').text(ShowNumber(sumbasevat, 2));
        $('#lblSumAfterVat').text(ShowNumber(sumbasevat + sumvat, 2));
        $('#lblSumChargeNonVat').text(ShowNumber(sumnonvat, 2));
        $('#lblSumBaseAdv').text(ShowNumber(sumbaseadv, 2));
        $('#lblSumVatAdv').text(ShowNumber(sumvatadv,2));
        $('#lblSumBaseWht1').text(ShowNumber(sumbase1,2));
        $('#lblSumBaseWht3').text(ShowNumber(sumbase3,2));

        $('#lblSumWht1').text(ShowNumber(sumtax1,2));
        $('#lblSumWht3').text(ShowNumber(sumtax3,2));
    }
</script>