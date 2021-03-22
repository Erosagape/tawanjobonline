
@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    * {
	font-size:12px;
    }
    table {
        border-width:thin;
        border-collapse:collapse;
    }    
    tbody td,th {
        font-size:11px;
    }
</style>
<div style="display:flex">
<div id="dvHeadF" style="float:left;flex:2;">
    <b>ROTJANIN CHANASINPHAWATKUN (DAN PHAK KAD)</b><br/>
9/10 T.Thachang,A.Mueng <br/>
Chanthaburi,THAILAND 22000<br/>
Tel: 084-5399663
</div>
<div id="dvHeadS" style="float:left;flex:2;">
<div style="display:flex">
<div style="flex:1;margin:5px 5px 5px 5px;">
                <img id="imgLogo" src="~/Resource/@ViewBag.PROFILE_LOGO" style="width:90px" />
</div>
<div style="flex:4;">
<b>ห้างหุ้นสวนจํากัด แดน ผักกาด (สํานักงานใหญ่)</b><br/>
9/10 หมู่ที 10 ตําบลท่าช้าง<br/>
อําเภอเมืองจันทบุรี จังหวัดจันทบุรี<br/>
โทร.039-460383,084-5399663<br/>
เลขประจำตัวผู้เสียภาษี 0223552000575
</div>
</div>
</div>
<div style="float:right;text-align:right;flex:1;">
    <b>INVOICE / ใบแจ้งหนี้</b>
<div id="dvCopy">    
</div>
</div>

</div>
<div style="display:flex;flex-direction:column">
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
            CUST INV : <label id="lblCustInvNo"></label>
        </div>
    </div>
    <div style="width:100%;border:1px solid black;border-radius:5px;">
        JOB NO : <span style="word-wrap:break-word" id="lblJobNo"></span>
    </div>    
    <div id="dvJob" style="display:flex;border:1px solid black;border-radius:5px;">
        <div style="flex:2">
            <div class="row">
                <p class="col-sm-12">
                    FROM :<label id="lblFromCountry"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    FLIGHT/VESSEL :<label id="lblVesselName"></label>
                </p>
            </div>
            <div class="row">
                <p class="col-sm-12">
                    QUANTITY/GROSSWEIGHT :<label id="lblQtyGross"></label>
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
                    DUE DATE :<label id="lblDueDate"></label>
                </p>
            </div>
        </div>
    </div>
    <br/>
    <table style="width:100%" border="1" class="text-center">
        <tr style="background-color :gainsboro;text-align:center;">
            <td width="100px">CODE</td>
            <td width="550px">DESCRIPTION</td>
            <td width="50px">QTY</td>
            <td width="100px">UNIT</td>
            <td width="100px">DISC</td>
            <td width="100px">AMOUNT</td>
        </tr>
        <tbody id="tbDetail"></tbody>
        <tr>
            <td>TOTAL (BAHT)</td>
            <td colspan="5">
                <div style="text-align:center"><label id="lblTotalBaht"></label></div>
            </td>
        </tr>
    </table>
    <div style="display:flex">
        <div style="border:1px solid black;border-radius:5px;flex:2">
            <u>PAYMENT:</u>
            <table id="tbPayF" style="width:100%">
                <tr><td>SCB (Robinson Chantaburi)</td><td>#854-206207-9</td></tr>
                <tr><td>KBANK (Robinson Chantaburi)</td><td>#528-200500-1</td></tr>
                <tr><td>TMB (Robinson Chantaburi)</td><td>#627-219687-1</td></tr>
                <tr><td>BBL (Makham)</td><td>#509-018310-3</td></tr>
            </table>
            <table id="tbPayS" style="width:100%">
                <tr><td>กรุณาโอนเงินเข้าบัญชีธนาคารกสิกรไทย สาขาโรบินสันจันทบุรี</td></tr>
                <tr><td>บัญชีออมทรัพย์ ชื่อบัญชี "หจก แดนผักกาด" เลขที่บัญชี 528-2-38819-9</td></tr>
                <tr><td>กรุณาหัก ณ ที่จ่าย และนำส่งใบหัก ณ ที่จ่าย มายัง</td></tr>
                <tr><td>หจก แดนผักกาด เลขที่ 9/10 ม.10 ต.ท่าช้าง อ.เมือง จ.จันทบุรี 22000</td></tr>
            </table>
            <div id="lblShippingRemark"></div>
            <u>REMARKS :</u>
            <br />
            <div id="lblDescription"></div>
        </div>
        <div class="text-left" style="border:1px solid black;border-radius:5px;flex:1">
            <table style="width:100%">
                <tr>
                    <td>
                        <u>TOTAL</u>
                    </td>
                    <td style="text-align:right;">
                        <label id="lblSumAmount"></label>
                    </td>
                </tr>
                <tr>
                    <td>VAT (RATE=<label id="lblVATRate"></label>%)</td>
                    <td style="text-align:right;">
                        <label id="lblSumVat"></label>
                    </td>
                </tr>
                <tr>
                    <td>GRAND TOTAL</td>
                    <td style="text-align:right;">
                        <label id="lblSumGrandTotal"></label>
                    </td>
                </tr>
            </table>
            <u>WITHHOLDING TAX DETAIL</u>
            <div style="display:flex">
                <div class="text-center" style="flex:2">
                    1%:<br />
                    3%:
                </div>
                <div style="flex:1;text-align:right;">
                    <label id="lblSumBaseWht1"></label><br />
                    <label id="lblSumBaseWht3"></label>
                </div>
                <div style="flex:1;text-align:right;">
                    <label id="lblSumWht1"></label>
                    <br />
                    <label id="lblSumWht3"></label>
                </div>
            </div>
            <div style="display:flex;">
                <div style="flex:2">
                    NET AMOUNT
                </div>
                <div style="flex:1;text-align:right;">
                    <label id="lblSumNetInvoice"></label>
                </div>
            </div>
        </div>
    </div>
    <div style="display:flex;width:100%;border:1px solid black;border-radius:5px;flex:1;text-align:center;">
        <div style="text-align:left;flex:1">
            TOTAL INVOICE (<label id="lblCurrencyCode"></label>)=<label id="lblForeignNet"></label> RATE=<label id="lblExchangeRate"></label>
        </div>
    </div>
    <div style="display:flex;font-size:12px;">
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            ผู้บันทึก<br /><br /> <br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            ผู้อนุมัติ<br /><br /> <br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            ผู้วางบิล<br /><br /> <br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
        </div>
        <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center;">
            ผู้รับวางบิล<br /><br /> <br /><br />
            ......................................................... <br />
            __________/_________/________ <br />
        </div>
    </div>

</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
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
            if(h.DocNo.substr(0,3)=='IVF')  $('#dvHeadS').hide(); 
            if(h.DocNo.substr(0,3)=='IVS')  $('#dvHeadF').hide(); 
            if(h.DocNo.substr(0,3)=='IVT')  $('#dvHeadF').hide(); 
            if(h.DocNo.substr(0,3)=='IVF')  $('#tbPayS').hide(); 
            if(h.DocNo.substr(0,3)=='IVS')  $('#tbPayF').hide(); 
            if(h.DocNo.substr(0,3)=='IVT')  $('#tbPayF').hide(); 
            if(h.DocNo.substr(0,3)=='IVF')  $('#dvJob').hide(); 
            $('#lblDocNo').text(h.DocNo);
            $('#lblJobNo').html(h.RefNo);
            $('#lblDocDate').text(ShowDate(CDateTH(h.DocDate)));
            $('#lblDueDate').text(ShowDate(CDateTH(h.DueDate)));
            $('#lblCurrencyCode').text(h.CurrencyCode);
            $('#lblExchangeRate').text(h.ExchangeRate);
            $('#lblForeignNet').text(ShowNumber(h.ForeignNet, 2));
            $('#lblDiscountRate').text(h.DiscountRate);
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


                $('#lblFromCountry').text(j.DeclareNumber);
                $('#lblVesselName').text(j.VesselName);
                $('#lblQtyGross').text(j.InvProductQty + ' ' + j.InvProductUnit + ' GW ' + j.TotalGW + ' '+ j.GWUnit);
                $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                $('#lblHAWB').text(j.HAWB);
                $('#lblMeasurement').text(j.Measurement);
                $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                $('#lblMAWB').text(j.MAWB);                
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
            //remark=remark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#lblDescription').html(CStr(remark));
            //remark=h.ShippingRemark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
            $('#lblShippingRemark').html(CStr(h.ShippingRemark));
            $('#lblSumAmount').text(ShowNumber(h.TotalCharge,2));
            $('#lblSumVat').text(ShowNumber(h.TotalVAT,2));
            $('#lblSumGrandTotal').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount),2));
            $('#lblTotalBaht').text('(' + CNumThai(CDbl(Number(h.TotalCharge) + Number(h.TotalAdvance) + Number(h.TotalVAT)-Number(h.TotalCustAdv)-Number(h.TotalDiscount), 2)) + ')');

            $('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalNet),2));
        }
        let d = dr.detail[0];
        let sumbase1 = 0;
        let sumbase3 = 0;
        let sumtax1 = 0;
        let sumtax3 = 0;

        if (d.length > 0) {
            for (let o of d) {
                let html = '<tr>';
                html += '<td style="text-align:center">' + o.SICode + '</td>';
                html += '<td>' + o.SDescription + '</td>';
                html += '<td style="text-align:center">' + o.Qty + ' ' + o.QtyUnit + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(o.UnitPrice, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(o.AmtDiscount, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(CNum(o.Amt)-CNum(o.AmtDiscount), 2) + '</td>';
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
        $('#lblSumBaseWht1').text(ShowNumber(sumbase1,2));
        $('#lblSumBaseWht3').text(ShowNumber(sumbase3,2));

        $('#lblSumWht1').text(ShowNumber(sumtax1,2));
        $('#lblSumWht3').text(ShowNumber(sumtax3,2));
    }
</script>