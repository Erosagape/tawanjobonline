@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>

    * {
        font-size: 10px;
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

    #main td, th {
        border-right: 1px solid black;
        border-left: 1px solid black;
    }
</style>
<div class="center bold">
    <label style="font-size:16px">ใบแจ้งหนี้/INVOICE</label>
</div>
<div class="right bold">
    <label style="font-size:16px" id="lblCopy">**ORIGINAL**</label>
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
            <td></td>
            <td></td>
            <td><label id=""></label></td>

            <td><label >Reference No.</label></td>
            <td>:</td>
            <td><label id="ref"></label></td>
        </tr>
        <tr>
            <td>ผู้ส่งออก/Shipper</td>
            <td>:</td>
            <td><label id="shipper"></label></td>

            <td><label id="jobNoLbl">BOP JOB NO.</label></td>
            <td>:</td>
            <td><label id="jobNo"></label></td>
        </tr>
        <tr>
            <td>ผู้นำเข้า/Consignee</td>
            <td>:</td>
            <td><label id="consignee"></label></td>

            <td>Quotation Ref</td>
            <td>:</td>
            <td><label id="qno"></label></td>
        </tr>
        <tr>
            <td>เลขที่ใบขน/Entry No</td>
            <td>:</td>
            <td><label id="decl"></label></td>

            <td>เลขที่อ้างอิง/Customer Ref</td>
            <td>:</td>
            <td><label id="custInvNo"></label></td>
        </tr>
        <tr>
            <td>สินค้า/Commodity</td>
            <td>:</td>
            <td><label id="commodity"></label></td>

            <td>จำนวน/Packages</td>
            <td>:</td>
            <td><label id="quantity"></label></td>
        </tr>
        <tr>
            <td>FCL/LCL</td>
            <td>:</td>
            <td><label id="totalctn"></label></td>

            <td>HAWB</td>
            <td>:</td>
            <td><label id="hawb"></label></td>

            <td>MAWB</td>
            <td>:</td>
            <td><label id="mawb"></label></td>
        </tr>
        <tr>
            <td>ยานพาหนะ/Voy</td>
            <td>:</td>
            <td><label id="vessel"></label></td>

            <td>วันนำเข้า/ETA</td>
            <td>:</td>
            <td><label id="eta"></label></td>
        </tr>
        <tr>
            <td>ท่าต้นทาง/Pol</td>
            <td>:</td>
            <td><label id="portfrom"></label></td>

            <td>สถานที่ส่ง/Delivery To</td>
            <td>:</td>
            <td><label id=""></label></td>

        </tr>
        <tr>
            <td>Mail To</td>
            <td>:</td>
            <td><label id="portfrom"></label></td>

            <td>Term of Payment</td>
            <td>:</td>
            <td><label id=""></label></td>
        </tr>
      
    </tbody>
</table>

<table id="main" class="table" style="border-width:thin;border-collapse:collapse ;width:98%">
    <thead>
        <tr class="upperLine underLine">
            <th class="bold align-top underLine" rowspan="2">DESCRIPTION</th>
            <th id="insouce" class="center bold underLine" colspan="6">IN SOURCE CURRENCY</th>
            <th class="center bold underLine" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr class="upperLine">
            <th class="center bold underLine">W/T</th>
            <th class="center bold underLine">QTYs</th>
            <th class="center bold underLine">UNIT</th>
            <th class="center bold underLine">Curr.</th>
            <th class="center bold underLine">Exc.</th>
            <th class="center bold underLine">@@ UNIT</th>
            <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">ADVANCE</th>
            <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">NON VAT</th>
            <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">VAT</th>
        </tr>
    </thead>
    <tbody id="details">
    </tbody>
</table>
<table class="table" style="width:98%;border-collapse:collapse ">
    <thead></thead>
    <tbody>
        <tr class="upperLine">
            <td class="underLine">TAX RATE</td>
            <td class="center underLine">GROSS</td>
            <td class="center underLine">W/T AMT</td>
            <td id="amountLbl" class="right">AMOUNT:</td>
            <td style="width:60px;" id="advanceAmount" class="right"></td>
            <td style="width:5em;" id="nonVatAmount" class="right"></td>
            <td style="width:60px;" id="vatAmount" class="right"></td>
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
            <td></td>
            <td></td>
            <td></td>
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
        <tr class="">
            <td class="center"></td>
            <td class="center"></td>
            <td class="center"></td>
            <td id="netAmountLbl" class="right">NET AMOUNT:</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="netAmount" class="right"></td>
        </tr>
        <tr>
            <td class="center"></td>
            <td class="center"></td>
            <td class="center"></td>
            <td id="custAdvLbl" class="right">CUST ADV:</td>
            <td class="right underLine"></td>
            <td class="right underLine"></td>
            <td id="custAdv" class="right underLine"></td>
        </tr>
        <tr class="underLine">
            <td class="center"></td>
            <td class="center"></td>
            <td class="center"></td>
            <td id="grandTotalLbl" class="right">GRAND TOTAL:</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="grandTotal" class="right"></td>
        </tr>
    </tbody>
</table>
<div>
    TOTAL AMOUNT IN WORDS:
    <label id="bahtText">   BAHT TWENTY-EIGHT THOUSAND FIVE HUNDRED TWENTY-THREE AND</label>
</div>
<div>
<br/>
    <label id="remark"></label>
</div>
<br>
<table class="table" style="width:100%">
    <tr>
	<td class="bold" style="width: 33%; text-align: center;">ผูัจัดทำ /  Prepared By </td>
        <td class="bold" style="width: 33%; text-align: center;">อนุมัติโดย / Approved By :</td>
        <td class="bold" style="width:33%;text-align:center;">ผู้รับวางบิล / Received By :</td>       
    </tr>
    <tr>
	<td class="center" style="flex: 1; text-align: center;"> <br /><br /><br /><br /> <label id="empcode">_________________________________________</label></td>
        <td class="textSpace" style="flex: 1; text-align: center;"><br /><br /><br /><br /> _________________________________________</td>
        <td class="textSpace" style="flex: 1; text-align: center;"><br /><br /><br /><br /> _________________________________________</td>
        
    </tr>
    <tr>
	<td class="bold" style="text-align: center;">DATE : <label id="createDate">________________________________</label></td>
        <td class="bold" style="text-align: center;">DATE : ________________________________</td>
        <td class="bold" style="text-align: center;">DATE : ________________________________</td>
        
    </tr>
</table>
<br>
Please make payment by crossed cheque with "A/C PAYEE ONLY" TO BOP EXPRESS CO.,LTD.<br/>
Or bank transfer to account "BOP EXPRESS CO.,LTD."<br/>
A/C No.466-1-07285-2 Bank: TMB BANK PUBLIC COMPANY LIMITED Sriracha Branch.<br/>
A/C No.354-2-54700-7 Bank: Kasikorn Bank,Laemchabang Branch.<br/>
A/C No.491-1-13902-0 Bank: Krungsri Bank,Laemchabang Branch.<br/>
A/C No.653-290641-9  Bank: Siam Commercial Bank,Laemchabang Branch.<br/>
<br>
REMARK<br>
1.if the description on this invoice is incorrect. Please contact our office within 7 day otherwise no correction<br>
2.Interest rate of 0.75% per month will be charged on all overdue accounts. <br>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let bShowSlip = false;
    let branch = getQueryString('branch');
    let code = getQueryString('code');

    if(confirm("OK For Original Or Copy")==false){
    	$('#lblCopy').text('**COPY**');
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
                addr += '<br/>Tax ID : ' + b.TaxNumber + ' BRANCH : 0' + b.Branch;
		        $("#billAddress1").text(b.EAddress1);
		        $("#billAddress2").text(b.EAddress2);
                $("#billContactInfo").text('Tax ID : ' + b.TaxNumber + ' BRANCH : 0' + b.Branch);
                $("#crTerm").text(b.CreditLimit);
                $("#dueDate").text(ShowDate(h.DueDate));
                $("#id").text(h.BillToCustCode);
	        });
           
            $("#invoiceNo").text(h.DocNo);
            $("#invoiceDate").text(ShowDate(h.DocDate));
            $("#currency").text(h.CurrencyCode);
            $("#shipper").text(h.Remark1);
            $("#consignee").text(h.Remark2);
            $("#remark").text(h.Remark3);
	    $.get(path + 'Master/GetUser?Code=' + h.EmpCode)
            .done(function (r) {
                if (r.user.data.length > 0) {
                    let b = r.user.data[0];
                    $('#empcode').text(b.EName);
                }
            });
            $("#createDate").text(ShowDate(h.CreateDate));
	    if (j.ShipBy == 1) {
                //ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#portfrom');
                ShowCountry(path, j.InvFCountry, '#origin');
                ShowCountry(path, j.InvCountry, '#destiny');
		$.get(path + 'Master/GetInterPort?Code=' + j.InvInterPort+ '&Key=' + j.InvFCountry)
             	.done(function (r) {
            		if (r.interport.data.length > 0) {
                		let b = r.interport.data[0];
                		$('#portfrom').text(b.PortName?b.PortName+" ":"");
            		}
             	});
            } else {
                //ShowInterPort(path, j.InvCountry, j.InvInterPort, '#portto');
                ShowCountry(path, j.InvFCountry, '#origin');
  		ShowCountry(path, j.InvCountry, '#destiny');
		$.get(path + 'Master/GetInterPort?Code=' + j.InvInterPort+ '&Key=' + j.InvCountry)
             	.done(function (r) {
            		if (r.interport.data.length > 0) {
                		let b = r.interport.data[0];
                		$('#portto').text(b.PortName?b.PortName+" ":"");
            		}
             	});
            }
            $("#jobNo").text(j.JNo);
            $("#vessel").text(j.VesselName);
            $("#etd").text(ShowDate(j.ETDDate));
            $("#eta").text(ShowDate(j.ETADate));
            $("#hawb").text(j.HAWB);
            $("#mawb").text(j.MAWB);
            $("#commodity").text(j.InvProduct);
            
            $("#quantity").text(j.InvProductQty + ' ' + j.InvProductUnit);
            $("#totpkg").text(j.TotalQty + " PACKAGE");
            $("#newBlNo").text(j.BookingNo);
            $("#weight").text(ShowNumber(j.TotalGW,3) + ' ' + j.GWUnit);
	        $("#totalctn").text(j.TotalContainer);
            $("#decl").text(j.DeclareNumber);


            //$("#volume").text(j.Measurement);
 		//<td><label id="volumeLbl">VOLUME</label></td>
            //<td>:</td>
            //<td><label id="volume"></label></td>
            $("#custInvNo").text(j.InvNo);
            $("#ref").text(j.CustRefNO);
            $('#blno').text(j.BLNo);
            $("#qno").text(j.QNo);
            

            //ShowCustomerEN(path, j.CustCode, j.CustBranch, '#shipper');
            //ShowCustomerEN(path, j.Consigneecode,'0000', '#consignee');
            ShowVender(path, j.ForwarderCode, '#carrier');
            //ShowContainer(j.BranchCode, j.JNo);

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
            let varFromSrv = 0;
            for (let row of d) {
                html += '        <tr>';
                html += '            <td class="">' + row.SDescription + '</td>';
                html += '            <td class="right">' + row.Rate50Tavi + '</td>';
                html += '            <td class="center">' + ShowNumber(row.Qty,3) + '</td>';
                html += '            <td class="right">' + row.QtyUnit+'</td>';
                html += '            <td class="right">' + row.CurrencyCode + '</td>';
                html += '            <td class="right">' + ShowNumber(row.ExchangeRate,4) + '</td>';
                html += '            <td class="right">' + ShowNumber(row.AmtAdvance ? row.FUnitPrice + (row.AmtVat / row.Qty) : row.FUnitPrice,2) + '</td>';
                html += '            <td class="right">' + (row.AmtAdvance ? ShowNumber(row.Amt + row.AmtVat,  2):'') + '</td>';
                html += '            <td class="right">' + (row.AmtVat==0?(row.AmtCharge?ShowNumber(row.Amt,2):''):'') + '</td>';
                html += '            <td class="right">' + (!row.AmtAdvance &&row.AmtVat>0?ShowNumber(row.Amt,2) : '') + '</td>';
                html += '        </tr>';
                if (row.AmtAdvance) {
                    adv += ((row.Amt) * row.ExchangeRate.toFixed(4)+ row.AmtVat);
                } else {
                    if (row.AmtVat > 0) {
                        vat += row.AmtCharge * row.ExchangeRate.toFixed(4);
                        varFromSrv += row.AmtVat;
                    } else {
                        nonVat += row.AmtCharge* row.ExchangeRate.toFixed(4) ;
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
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
                html += '        </tr>';
            }
            $('#gross1').text(ShowNumber(sumbaseWht1,2));
            $('#wtAmt1').text(ShowNumber(sumWht1,2));
            $('#gross3').text(ShowNumber(sumbaseWht3,2));
            $('#wtAmt3').text(ShowNumber(sumWht3,2));
            $('#gross1_5').text(ShowNumber(sumbaseWht1_5,2));
            $('#wtAmt1_5').text(ShowNumber(sumWht1_5,2));

            $("#advanceAmount").text(ShowNumber(adv,2));
            $("#nonVatAmount").text(ShowNumber(nonVat,2));
            $("#vatAmount").text(ShowNumber(vat,2));
            $('#details').html(html);
            $("#valueAddedTax").text(ShowNumber(varFromSrv,2));
            $("#totalAmount").text(ShowNumber(adv+nonVat +vat + h.TotalVAT,2));
            $("#lessWithholdingTax").text(ShowNumber(h.Total50Tavi,2));
            $("#netAmount").text(ShowNumber(adv + vat + nonVat + h.TotalVAT - h.Total50Tavi,2));
            $("#custAdv").text(ShowNumber(h.TotalCustAdv,2));
            $("#grandTotal").text(ShowNumber((adv + vat + nonVat + h.TotalVAT - h.Total50Tavi)-h.TotalCustAdv,2));

            $("#taxRate1").text("1%");
            $("#taxRate1_5").text("1.5%");
            $("#taxRate3").text("3%");
            $("#bahtText").text(CNumEng(CDbl(h.TotalNet,2)));


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