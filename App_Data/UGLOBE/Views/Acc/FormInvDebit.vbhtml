@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>

    * {
        font-size: 13px;
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

    #header, #details td, th {
        border-right: 1px solid black;
        border-left: 1px solid black;
    }
</style>
<div class="center bold">
    <br />
    <label style="font-size:16px">DEBIT NOTE</label>
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
                        <label id="invoiceNoLbl">DEBIT NOTE NO.:</label>
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
   		<label id="portfrom"></label>&nbsp; 
   		<label id="origin"></label>
   		to <label id="portto"></label>&nbsp; <label id="destiny"></label>
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
            <td><label id="hblNoLbl">H-B/L NO.</label></td>
            <td>:</td>
            <td><label id="hblNo"></label></td>

            <td><label id="quantityLbl">QUANTITY</label></td>
            <td>:</td>
            <td><label id="quantity"></label></td>

            <td><label id="totpkgLbl">TOTAL PKG</label></td>
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
            <td><label id="containerNoLbl">CONTAINER NO.</label></td>
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
    <thead>
        <tr class="upperLine underLine">
            <th class="bold align-top underLine" colspan="2" style="width:70%">DESCRIPTION</th>
            <th class="center bold underLine">AMOUNT</th>
        </tr>
        @*<tr class="upperLine">
                <th class="center bold underLine">W/T</th>
                <th class="center bold underLine">QTYs</th>
                <th class="center bold underLine">UOM</th>
                <th class="center bold underLine">Curr.</th>
                <th class="center bold underLine">Exc.</th>
                <th class="center bold underLine">@@ UNIT</th>
                <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">ADVANCE</th>
                <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">NON VAT</th>
                <th style="width:60px;border:1px black solid;border-collapse:collapse" class="center bold">VAT</th>
            </tr>*@
    </thead>
    <tbody id="details">
    </tbody>
    <tbody id="summary" class="upperLine">
        <tr>
            <td colspan="2" style="text-align:right">TOTAL</td>
            <td id="totalNet" style="text-align:right" class="vborder underLine"></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right">LESS(-)</td>
            <td style="text-align:right" class="vborder underLine"></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right;font-weight:bold">GRAND TOTAL</td>
            <td id="grandTotal" style="text-align:right" class="vborder underLine"></td>
        </tr>
    </tbody>
</table>
@*<table class="table" style="width:98%;border-collapse:collapse ">
        <thead></thead>
        <tbody>
            <tr class="upperLine">
                <td class="underLine">TAX RATE</td>
                <td class="center underLine">GROSS</td>
                <td class="center underLine">W/T AMT</td>
                <td id="amountLbl" class="right">AMOUNT:</td>
                <td style="width:60px;" id="advanceAmount" class="right"></td>
                <td style="width:60px;" id="nonVatAmount" class="right" style="width:5em"></td>
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
    </table>*@
<br>

<p>
    Remark:
    <label id="remark"></label>
</p>
<br />
<br />
<table class="table" style="width:100%">
    <tr>
        <td class="bold" style="width:33%;text-align:center;">ผู้รับวางบิล / Received By :</td>

        <td class="bold" style="width: 33%; text-align: center;">อนุมัติโดย / Approved By :</td>

        <td class="bold" style="width: 33%; text-align: center;">ผูัจัดทำ /  Preapared By </td>

    </tr>
    <tr>
        <td class="textSpace" style="flex: 1; text-align: center;"><br /><br /><br /><br /><br /> _________________________________________</td>
        <td class="textSpace" style="flex: 1; text-align: center;"><br /><br /><br /><br /><br /> _________________________________________</td>
        <td class="center" style="flex: 1; text-align: center;"> <br /><br /><br /><br /><br /> _________________________________________</td>
    </tr>
    <tr>
        <td class="bold" style="text-align: center;">DATE : ________________________________</td>
        <td class="bold" style="text-align: center;">DATE : ________________________________</td>
        <td class="bold" style="text-align: center;">DATE : ________________________________</td>
    </tr>
</table>
<b>
    <br />
    1. PLEASE ADVISE YOUR CONFIRMATION BEFORE CLEAR BALANCE
    <br />
    2. PLEASE PAY TO OUR BANK:
    <br />
</b>
BANK DETAILS FOR UNITED GLOBE LOGISTICS (THAILAND) CO.,LTD.
<table style="width:100%">
    <tbody>
        <tr>
            <td colspan="2">ACCOUNT NAME </td>
            <td>: UNITED GLOBE LOGISTICS (THAILAND) CO.,LTD.</td>
        </tr>
        <tr>
            <td colspan="2">BANK NAME & ADDRESS</td>
            <td>KASITKORN BANK PUBLIC CO.,LTD. HEAD OFFICE</td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td>RATBURANA ROAD BANKOK 10140 THAILAND</td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td>CABLE ADDRESS "FARMERS BANGKOK"</td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td>TELEX NO TH 82542 TH 84798</td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td>CONTACT : OVERSEAS MONEY TRANSFER DIVSION</td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td>TEL : 02-4701444,02-4701429-40</td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td>TANANIN PHETBURI TATANAI BRANCH</td>
        </tr>
        <tr>
            <td style="color:transparent">___________</td>
            <td style="">ACCOUNT No. </td>
            <td>028-109-641-9</td>
        </tr>
        <tr>
            <td></td>
            <td>SWIFT BANK CODE </td>
            <td>: KASITHBK</td>
        </tr>
    </tbody>

</table>

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
                addr += '<br/>Tax ID : ' + b.TaxNumber + ' BRANCH : 0' + b.Branch;
		        $("#billAddress1").text(b.EAddress1);
		        $("#billAddress2").text(b.EAddress2);
                $("#billContactInfo").text('Tax ID : ' + b.TaxNumber + ' BRANCH : 0' + b.Branch);
                $("#crTerm").text(b.CreditLimit);
                $("#dueDate").text(AddDate(h.DocDate, b.CreditLimit));
                $("#id").text(h.BillToCustCode);
	        });

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
            $("#hblNo").text(j.HAWB);
            $("#quantity").text(j.InvProductQty + ' ' + j.InvProductUnit);
            $("#totpkg").text(j.TotalQty + " PALLETS");
            $("#newBlNo").text(j.BookingNo);
            $("#weight").text(ShowNumber(j.TotalGW,3) + ' ' + j.GWUnit);
            $("#volume").text(j.Measurement);
            $("#custInvNo").text(j.InvNo);
            //$("#ref").text(j.CustRefNO);
	        $.get(path + 'Master/GetCompany?Code='+h.CustCode+'&Branch='+h.CustBranch).done(function (r) {
                let b = r.company.data[0];
                $("#ref").text(b.NameEng);
	        });

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
                html += '            <td class="" style="border-right-color: transparent;">' + row.SDescription + ' #' + row.ExpSlipNO + '</td>';
                html += '            <td>' + row.CurrencyCode + ShowNumber(row.FUnitPrice,2) + '/' + ShowNumber(row.Qty, 3) + ' ' + row.QtyUnit + '</td>';
                html += '            <td class="right">'+ row.CurrencyCode + ShowNumber(row.FAmt,2)  + '</td>';

                //html += '            <td class="right">' + row.Rate50Tavi + '</td>';
                //html += '            <td class="center">' + ShowNumber(row.Qty,3) + '</td>';
                //html += '            <td class="right">' + row.QtyUnit+'</td>';
                //html += '            <td class="right">' + row.CurrencyCode + '</td>';
                //html += '            <td class="right">' + ShowNumber(row.ExchangeRate,3) + '</td>';
                //html += '            <td class="right">' + ShowNumber(row.FUnitPrice,3) + '</td>';
                //html += '            <td class="right">' + (row.AmtAdvance?ShowNumber(row.Amt,3):'') + '</td>';
                //html += '            <td class="right">' + (row.AmtVat==0?(row.AmtCharge?ShowNumber(row.Amt,3):''):'') + '</td>';
                //html += '            <td class="right">' + (row.AmtVat>0?ShowNumber(row.Amt,3) : '') + '</td>';
                html += '        </tr>';
                adv += row.AmtAdvance * row.ExchangeRate.toFixed(4);
                if (row.AmtVat > 0) {
                    vat += row.FAmt;
                } else {
                    nonVat += row.FAmt;
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
                html += '            <td style="border-right-color: transparent;"><br/></td>';
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
                //html += '            <td class="center"></td>';
                //html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                //html += '            <td class="right"></td>';
                html += '        </tr>';
            }
            $('#gross1').text(ShowNumber(sumbaseWht1,3));
            $('#wtAmt1').text(ShowNumber(sumWht1,3));
            $('#gross3').text(ShowNumber(sumbaseWht3,3));
            $('#wtAmt3').text(ShowNumber(sumWht3,3));
            $('#gross1_5').text(ShowNumber(sumbaseWht1_5,3));
            $('#wtAmt1_5').text(ShowNumber(sumWht1_5,3));

            $("#advanceAmount").text(ShowNumber(adv,3));
            $("#nonVatAmount").text(ShowNumber(nonVat,3));
            $("#vatAmount").text(ShowNumber(vat,3));
            $('#details').html(html);
            $("#valueAddedTax").text(ShowNumber(h.TotalVAT,3));
            $("#totalAmount").text(ShowNumber(vat + h.TotalVAT,3));
            $("#lessWithholdingTax").text(ShowNumber(h.Total50Tavi,3));
            $("#netAmount").text(ShowNumber(h.FTotalAmt,2));
            $("#taxRate1").text("1%");
            $("#taxRate1_5").text("1.5%");
            $("#taxRate3").text("3%");
            $("#bahtText").text(CNumEng(CDbl(h.TotalNet,3)));

            $("#totalNet").text(h.CurrencyCode+" "+ShowNumber(nonVat,3));
            $("#grandTotal").text(h.CurrencyCode + " " +ShowNumber(nonVat,3));



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