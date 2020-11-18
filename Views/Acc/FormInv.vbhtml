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

    #dvForm {
        padding-right: 5px;
    }

    .roundbox {
        border: 1px solid black;
        border-radius: 5px;
        margin: 2px 2px 2px 2px;
        padding: 2px 2px 2px 2px;
        word-wrap: break-word;
    }

    #dvFooter {
        display: none;
    }
</style>
<div style="text-align:right;width:100%;">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">INVOICE / ใบแจ้งหนี้</label>
</div>
<br />
<span class="roundbox">CUSTOMER :</span>
<label>TAX ID:</label>
<label id="lblTaxNumber"></label>
<label>BRANCH:</label>
<label id="lblTaxBranch"></label>
<div id="dvForm">
    <div style="display:flex;">
        <div style="flex:3" class="roundbox">
            NAME : <label id="lblCustName"></label>
            <br />
            ADDRESS : <label id="lblCustAddress"></label><br />
            CONTACT : <label id="lblCustContact"></label><br />
            TEL : <label id="lblCustTel"></label>
        </div>
        <div style="flex:1;" class="roundbox">
            DATE : <label id="lblDocDate"></label><br />
            INVOICE NO. : <label id="lblDocNo"></label><br />
            SERVICE : <label id="lblTotalContainer"></label><br />
            DUE DATE: <label id="lblDueDate"></label>
        </div>
    </div>
    <div style="width:100%" class="roundbox">
        INVOICE : <label id="lblCustInvNo"></label><br />
        CUSTOMER PO : <label id="lblCustPoNo"></label><br />
    </div>
    <br />
    <p id="dvLoading">
        <table id="tbLoading">
            <thead>
                <tr>
                    <th>
                        ITEM
                    </th>
                    <th>
                        BOOKING
                    </th>
                    <th>
                        UNIT
                    </th>
                    <th>
                        CONTAINER
                    </th>
                    <th>
                        PLACE
                    </th>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </p>
    <table style="width:100%;" border="1" class="text-center">
        <tr style="background-color :gainsboro;text-align:center;">
            <th width="40" rowspan="2">ITEM</th>
            <th width="220" rowspan="2">DESCRIPTION</th>
            <th width="50" rowspan="2">QTY</th>
            <th width="60" rowspan="2">UNIT PRICE</th>
            <th width="230" colspan="3">ADVANCE RE-IMBURSEMENT</th>
            <th width="160" colspan="2">SERVICE CHARGES</th>
        </tr>
        <tr style="background-color :gainsboro;text-align:center;">
            <th width="80">SERVICE</th>
            <th width="70">VAT</th>
            <th width="80">AMOUNT</th>
            <th width="80">NON-VAT</th>
            <th width="80">VAT</th>
        </tr>
        <tbody id="tbDetail"></tbody>
        <tfoot>
            <tr>
                <td colspan="4" style="text-align:right">
                    TOTAL INVOICE
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
                <td colspan="5">
                    <div id="lblShippingRemark"></div>
                    REMARKS :<br />
                    <div id="lblDescription"></div>
                </td>

                <td colspan="2">
                    SUBTOTAL VAT<br />
                    VAT (<label id="lblVATRate"></label>%)<br />
                    TOTAL<br />
                    SERVICE NON-VAT<br />
                    ADVANCE<br />
                    GRAND TOTAL
                </td>
                <td style="background-color :gainsboro;text-align:right;" colspan="2">
                    <label id="lblSumChargeVat"></label><br />
                    <label id="lblSumVat"></label><br />
                    <label id="lblSumAfterVat"></label><br />
                    <label id="lblSumChargeNonVat"></label><br />
                    <label id="lblSumTotal"></label><br />
                    <label id="lblSumGrandTotal"></label>
                </td>
            </tr>
            <tr>
                <td>TOTAL (BAHT)</td>
                <td colspan="9">
                    <div style="text-align:center;"><label id="lblTotalBaht" style="font-size:14px;"></label></div>
                </td>
            </tr>
        </tfoot>
    </table>
    <br />
    <div style="display:flex;">
        <div class="text-left" style="border:1px solid black;border-radius:5px;flex:1;text-align:center">
            WITHHOLDING TAX DETAIL
            <table style="width:100%;text-align:left">
                <tr>
                    <td style="width:55%">TRANSPORT 1%</td>
                    <td style="width:25%;text-align:right"><label id="lblSumBaseWht1"></label><br /></td>
                    <td style="width:20%;text-align:right"><label id="lblSumWht1"></label></td>
                </tr>
                <tr>
                    <td style="width:55%">SERVICE 3%</td>
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
                <tr id="rowForeign" style="display:none">
                    <td style="width:55%">
                        NET TOTAL<br /> (Rate=<label id="lblExcRate"></label>)
                    </td>
                    <td style="width:25%;text-align:right">
                        <label id="lblSumNetInvoiceF"></label>
                    </td>
                    <td style="width:20%;text-align:left">
                        <label id="lblCurrency"></label>
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
    <div style="width:100%;word-wrap:break-word;">
        JOB# <label id="lblJobNo"></label><br />
        PLEASE PAY CHEQUE (A/C PAYER ONLY) PAYABLE TO APL LOGISTICS SVCS (THAILAND),LTD.<br />
        - LATE PAYMENT 2% WILL BE CHARGED IF PAID AFTER DUE DATE.<br />
        - IF ANY INCORRECT ITEM, PLEASE INFORM WITHIN 7 DAYS FROM THE DATE OF INVOICE,OTHERWISE WILL BE CONSIDERED CORRECT.<br />
        - TRANSPORTATION CHARGE IS NON-VAT AND SUBJECT TO 1% WITHHOLDING TAX.<br />
        - ALL OTHERS CHARGES EXCLUDING TRANSPORTATION ARE VAT AND SUBJECT TO 3% WITHHOLDING TAX.
    </div>
</div>

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
                ShowData(r.invoice);
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
        sortData(d, 'AmtCharge', 'desc');
        //sortData(d, 'ItemNo', 'asc');

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