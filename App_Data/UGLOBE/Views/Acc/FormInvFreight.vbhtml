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
        padding: 0.3em;
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

    .vborder {
        border-right: 1px solid black;
        border-left: 1px solid black;
    }

    .textSpace {
        width: 20em;
    }

    #dvFooter {
        display: none;
    }

    table {
        width: 100%;
    }

    #header,#details td,th {
        border-right: 1px solid black;
        border-left: 1px solid black;
    }
</style>
<div class="center bold">
    <br />
    <label style="font-size:16px">ใบแจ้งหนี้/INVOICE</label>
</div>

<div style="display:flex;width:98%">
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
                        <label id="billName"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="billAddress1"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="billAddress2"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="billContactInfo"></label>
                    </td>
                </tr>

            </tbody>
        </table>
    </div>
    <div style="flex:2%"></div>
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
            <td><label id="destinyLbl">POL/ POD</label></td>
            <td>:</td>
            <td>
                <label id="port"></label>
                <label id="origin"></label>
                to <label id="destiny"></label>
            </td>



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
            <td><label id="mblNoLbl">M-B/L NO.</label></td>
            <td>:</td>
            <td><label id="mblNo"></label></td>

            <td><label id="hblNoLbl">H-B/L NO.</label></td>
            <td>:</td>
            <td><label id="hblNo"></label></td>

            <td><label id="newBlNoLbl">B/L CHANGE NO</label></td>
            <td>:</td>
            <td><label id="newBlNo"></label></td>


        </tr>

        <tr>

            <td><label id="quantityLbl">QUANTITY</label></td>
            <td>:</td>
            <td><label id="quantity"></label></td>

            <td><label id="totpkgLbl">TOTAL PKG</label></td>
            <td>:</td>
            <td><label id="totpkg"></label></td>

            <td><label id="weightLbl">WEIGHT</label></td>
            <td>:</td>
            <td><label id="weight"></label></td>

        </tr>

        <tr>
            <td><label id="containerNoLbl">CONTANER NO.</label></td>
            <td>:</td>
            <td><div id="containerNo"></div></td>

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


    </tbody>
</table>

<table id="main" class="table" style="border-width:thin;border-collapse:collapse ;width:98%">
    <thead  id="header">
        <tr class="upperLine underLine">
            <th class="bold align-top underLine" rowspan="2">DESCRIPTION</th>
            <th id="insouce" class="center bold underLine" colspan="5">IN SOURCE CURRENCY</th>
            <th class="center bold underLine" colspan="2">AMOUNT IN THB</th>
        </tr>
        <tr class="upperLine">
            @*<th class="center bold underLine">W/T</th>*@
            <th class="center bold underLine">QTYs</th>
            <th class="center bold underLine">UOM</th>
            <th class="center bold underLine">Curr.</th>
            <th class="center bold underLine">Exc.</th>
            <th class="center bold underLine">@@ UNIT</th>
            @*<th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">ADVANCE</th>*@
            <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">NON VAT</th>
            <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">VAT</th>
        </tr>
    </thead>
    <tbody id="details" style="border-bottom:1px black solid">
    </tbody>
    <tbody id="summary">
        <tr>
            <td colspan="7" style="text-align:right">Amount(VAT)</td>
            <td id="vatAmount" class="right"></td>
        </tr>
        <tr>
            <td colspan="7" style="text-align:right">VAT 7%</td>
            <td id="valueAddedTax" class="right"></td>
        </tr>
        <tr>
            <td colspan="7" style="text-align:right">Amount(Non VAT)</td>
            <td id="nonVatAmount" class="right"></td>
        </tr>
        <tr>
            <td colspan="7" style="text-align:right">Total</td>
            <td id="totalAmountLbl" class="right"></td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:right">หักภาษี ณ ที่จ่าย ค่าขนส่ง</td>
            <td style="text-align:right">1%</td>
            <td style="text-align:right" id="gross1"></td>
            <td style="text-align:right" id="wtAmt1"></td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:right">หักภาษี ณ ที่จ่าย ค่าขนส่ง</td>
            <td style="text-align:right">3%</td>
            <td style="text-align:right" id="gross3"></td>
            <td style="text-align:right" id="wtAmt3"></td>
        </tr>
        <tr>
            <td colspan="7" style="text-align:right">GRAND TOTAL</td>
            <td id="netAmount" class="right"></td>
        </tr>

    </tbody>
</table>

<br>
<p>
    TOTAL AMOUNT IN WORDS:
    <label id="bahtText">   BAHT TWENTY-EIGHT THOUSAND FIVE HUNDRED TWENTY-THREE AND</label>
</p>
<p>
    Credit Terms : <label id="lblCreditLimit"></label> DAYS
</p>
<p style="text-align:center">
    นัดรับชำระทันที
</p>
<p>
    Remark:
    <label id="remark"></label>
</p>
<br />
<br />
<table class="table" style="width:100%">
    <tr>
        <td colspan="2" class="bold" style="flex:1;text-align:center;">ผู้รับวางบิล / Received By :</td>

        <td colspan="2" class="bold" style="flex: 1; text-align: center;">อนุมัติโดย / Approved By :</td>

        <td colspan="2" class="bold" style="flex: 1; text-align: center;">ผูัจัดทำ /  Preapared By </td>

    </tr>
    <tr>
        <td colspan="2" class="underLine textSpace" style="flex: 1; text-align: center;"><br /><br /><br /><br /><br /></td>
        <td colspan="2" class="underLine textSpace" style="flex: 1; text-align: center;"></td>
        <td colspan="2" class="underLine center" style="flex: 1; text-align: center;"> </td>
    </tr>
    <tr>
        <td class="bold" style="width:10%; text-align: center;">DATE :</td>
        <td class="underLine  textSpace" style="flex: 1; text-align: center;"></td>
        <td class="bold" style="width: 10%; text-align: center;">DATE :</td>
        <td class="underLine  textSpace" style="flex: 1; text-align: center;"></td>
        <td class="bold" style="width: 10%; text-align: center;">DATE :</td>
        <td class="underLine  textSpace" style="flex: 1; text-align: center;"></td>

    </tr>
</table>
<p style="text-align:center">
   ** กรุณาหักภาษี ณ ที่จ่าย "บริษัท ยูไนเต็ด โกลบ โลจิสติกส์(ประเทศไทย)" **
</p>
<script type="text/javascript">

    const path = '@Url.Content("~")';
    let bShowSlip = false;
    let branch = getQueryString('branch');
    let code = getQueryString('code');

    if(confirm("show company header?")==false){
	    $('#imgLogo').css('display','none');
	    $('#divCompany').css('display','none');
	    $('#dvCompAddr').css('display','none');
	    $('#dvCompLogo').css('height','90px');
    }

    $.get(path + 'Acc/GetInvoice?Branch=' + branch + '&Code=' + code).done(function (r) {
        if (r.invoice.header.length > 0) {
            let h = r.invoice.header[0][0];
            let c = r.invoice.customer[0][0];
            let j = r.invoice.job[0][0];
	        $.get(path + 'Master/GetCompany?Code='+h.BillToCustCode+'&Branch='+h.BillToCustBranch).done(function (r) {
                let b = r.company.data[0];
                $("#billName").text(b.NameEng);

                let addr = '';
                addr += b.EAddress1 + '<br/>' + b.EAddress2;
                addr += '<br/>Tax ID : ' + b.TaxNumber + ' BRANCH : ' + b.Branch;
		        $("#billAddress1").text(b.EAddress1);
		        $("#billAddress2").text(b.EAddress2);
                $("#billContactInfo").text('Tax ID : ' + b.TaxNumber + ' BRANCH : ' + b.Branch);
                $("#crTerm").text(b.CreditLimit);
                $("#dueDate").text(AddDate(h.DocDate, b.CreditLimit));
                $("#lblCreditLimit").text(b.CreditLimit);
                
	        });
            $("#id").text(h.CustCode);
            //$("#billName").text(c.NameEng);
            //$("#billAddress").html(c.EAddress1 + '<br/>' + c.EAddress2);
            //console.log(c.EAddress1);
            $("#invoiceNo").text(h.DocNo);
            //let date = new Date();
            //date.setMonth(date.getMonth()+1);
            //let tmpInvNo = "inv-"+(date.getFullYear()-2000)+(date.getMonth()<10?"0"+date.getMonth():date.getMonth())+h.DocNo.substring(6,12);
            //$("#invoiceNo").text(tmpInvNo);
            $("#invoiceDate").text(ShowDate(h.DocDate));
            //$("#crTerm").text(c.CreditLimit);
            //$("#dueDate").text(AddDate(h.DocDate, c.CreditLimit));
            $("#currency").text(h.CurrencyCode);
            //$("#destiny").text("PASIR GUDANG-BANGKOK");
            $("#remark").text(h.Remark1);
            if (j.JobType == 1) {
                ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#port');
                ShowCountry(path, j.InvFCountry, '#origin');
                ShowCountry(path, j.InvCountry, '#destiny');
            } else {

                ShowInterPort(path, j.InvCountry, j.InvInterPort, '#port');
                ShowCountry(path, j.InvFCountry, '#destiny');
                ShowCountry(path, j.InvCountry, '#origin');
            }
            $("#jobNo").text(j.JNo);
            $("#vessel").text(j.VesselName);
            $("#etd").text(ShowDate(j.ETDDate));
            $("#eta").text(ShowDate(j.ETADate));
            $("#hblNo").text(j.HAWB);
            $("#mblNo").text(j.MAWB);
            $("#quantity").text(j.InvProductQty + ' ' + j.InvProductUnit);
            $("#totpkg").text(j.TotalQty + " PALLETS");
            $("#newBlNo").text(j.BookingNo);
            $("#weight").text(ShowNumber(j.TotalGW, 2) + ' ' + j.GWUnit);
            $("#volume").text(j.Measurement);
            $("#custInvNo").text(j.InvNo);
            $("#ref").text(j.CustRefNO);


            ShowVender(path, j.ForwarderCode, '#carrier');
            ShowContainer(j.BranchCode, j.JNo);

            let d = r.invoice.detail[0];
            let html = '';
            let adv = 0;
            let nonVat = 0;
            let vat = 0;
            let sumbaseWht1 = 0;
            let sumbaseWht1_5 = 0;
            let sumbaseWht3 = 0;
            let sumWht1 = 0;
            let sumWht1_5 = 0;
            let sumWht3 = 0;
            let totalRows = 10;
            let blankRows = totalRows - d.length;
            for (let row of d) {
                html += '        <tr>';
                html += '            <td class="">' + row.SDescription + ' #' + row.ExpSlipNO +  '</td>';
                //html += '            <td class="right">' + row.Rate50Tavi + '</td>';
                html += '            <td class="center">' + ShowNumber(row.Qty,2) + '</td>';
                html += '            <td class="right">' + row.QtyUnit+'</td>';
                html += '            <td class="right">' + row.CurrencyCode + '</td>';
                html += '            <td class="right">' + ShowNumber(row.ExchangeRate, 2) + '</td>';
                html += '            <td class="right">' + ShowNumber(row.FUnitPrice,2) + '</td>';
                //html += '            <td class="right">' + (row.AmtAdvance?ShowNumber(row.Amt, 2):'') + '</td>';
                html += '            <td class="right">' + (row.AmtVat==0?(row.AmtCharge?ShowNumber(row.Amt, 2):''):'') + '</td>';
                html += '            <td class="right">' + (row.AmtVat>0?ShowNumber(row.Amt, 2) : '') + '</td>';
                html += '        </tr>';
                adv += row.AmtAdvance * row.ExchangeRate.toFixed(4);
                if (row.AmtVat > 0) {
                    vat += row.AmtCharge * row.ExchangeRate.toFixed(4);
                } else {
                    nonVat += row.AmtCharge * row.ExchangeRate.toFixed(4);
                }
                switch (row.Rate50Tavi - 0) {
                    case 1:
                        sumWht1 += row.Amt50Tavi;
                        sumbaseWht1 += row.Amt;
                        break;
                    case 1.5:
                        sumWht1_5 += row.Amt50Tavi;
                        sumbaseWht1_5 += row.Amt;
                        break;
                    case 3:
                        sumWht3 += row.Amt50Tavi;
                        sumbaseWht3 += row.Amt;
                        break;
                    default:
                        break;
                }
            }
            for (let i = 1; i <= blankRows; i++) {
                html += '        <tr>';
                html += '            <td><br/></td>';
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
                html += '            <td class="center"></td>';
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                html += '        </tr>';
            }
            $('#gross1').text(ShowNumber(sumbaseWht1, 2));
            $('#wtAmt1').text(ShowNumber(sumWht1, 2));
            $('#gross3').text(ShowNumber(sumbaseWht3, 2));
            $('#wtAmt3').text(ShowNumber(sumWht3, 2));
            $('#gross1_5').text(ShowNumber(sumbaseWht1_5, 2));
            $('#wtAmt1_5').text(ShowNumber(sumWht1_5, 2));

            $("#advanceAmount").text(ShowNumber(adv,2));
            $("#nonVatAmount").text(ShowNumber(nonVat, 2));
            $("#vatAmount").text(ShowNumber(vat, 2));
            $('#details').html(html);
            $("#valueAddedTax").text(ShowNumber(h.TotalVAT, 2));
            $("#totalAmount").text(ShowNumber(vat + h.TotalVAT, 2));
            $("#lessWithholdingTax").text(ShowNumber(h.Total50Tavi, 2));
            $("#netAmount").text(ShowNumber(h.TotalNet, 2));
            $("#taxRate1").text("1%");
            $("#taxRate1_5").text("1.5%");
            $("#taxRate3").text("3%");
            $("#bahtText").text(CNumThai(CDbl(h.TotalNet,2)));


        }
    });
    function ShowContainer(branch,job) {
        $.get(path + 'JobOrder/GetTransportReport?Branch=' + branch + '&JobList=' + job).done(function (r) {
            if (r.transport.data.length > 0) {
                let t = r.transport.data;
                let str = '';
                for (let row of t) {
                    if (str !== '') str += '<br/>';
                    str += row.CTN_NO + '/' + row.CTN_SIZE;
                }
                $("#containerNo").html(str);
            }
        });
    }
</script>