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
        /* border-radius: 10px;*/
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

    #dvFooter {
        display: none;
    }

    table {
        width: 100%;
    }
</style>
<div class="bold" style="font-size:16px;text-align:right;width:98%">
    ใบแจ้งหนี้/INVOICE
</div>
<br />
<div style="display:flex;width:98%">
    <div style="flex:60%" class="curveBorder">
        <table class="table table-borderless r">
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

    <div style="flex:40%" >
        <table class="table table-borderless curveBorder">
            <tbody>
                <tr>
                    <td>
                        <label id="invoiceNoLbl">INVOICE NO. :</label>
                    </td>
                    <td>
                        <label id="invoiceNo"> </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="invoiceDateLbl">INVOICE DATE :</label>
                    </td>
                    <td>
                        <label id="invoiceDate"></label>
                    </td>
                </tr>
                <tr>
                    <td><label id="jobNoLbl">JOB NO. :</label></td>
                    <td><label id="jobNo"></label></td>
                </tr>
                
            </tbody>
        </table>

        <table class="table table-borderless curveBorder">
            <tbody>
                <tr>
                    <td><label id="custInvNoLbl">CUST INV NO. :</label></td>
                    <td><label id="custInvNo"></label></td>
                </tr>
                <tr><td><br /></td></tr>
                <tr>
                    <td><label id="customsNoLbl">CUSTOMS NO. :</label></td>
                    <td><label id="customsNo"></label></td>
                </tr>

                @*<tr>
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
                </tr>*@
            </tbody>
        </table>
    </div>
</div>
<br />
<table class="table table-borderless curveBorder" style="width:98%">

    <tbody>
        <tr>
            @*<td><label id="destinyLbl">ORIGIN/ DEST</label></td>
        <td>:</td>
        <td><label id="destiny"></label></td>*@

            <td colspan="3" >Name of Importer - Exporter</td>

            <td id="loadportlbl">PORT OF LOADING</td>
            <td>:</td>
            <td id="loadport"></td>
        </tr>

        <tr>
            <td colspan="3" id="imexname"></td>

            <td><label id="etdLbl">ETD</label></td>
            <td>:</td>
            <td><label id="etd"></label></td>
        </tr>

        <tr>
            <td id="carrierlbl" style="width:10%">Carrier</td>
            <td style="width:5%">:</td>
            <td style="width:30%" id="carrier"></td>

            <td id="dcportlbl"  style="width:20%">PORT OF DISCHARGE</td>
            <td style="width:5%">:</td>
            <td id="dcport"  style="width:30%" ></td>
        </tr>

        <tr>
            <td id="bkglbl">BKG</td>
            <td>:</td>
            <td id="bkg"></td>
      
            <td><label id="etaLbl">ETA</label></td>
            <td>:</td>
            <td><label id="eta"></label></td>
        </tr>

        <tr>
            <td id="mbllbl">MBL</td>
            <td>:</td>
            <td id="mbl"></td>

            <td id="cbmlbl">CBM</td>
            <td>:</td>
            <td id="cbm"></td>
        </tr>

        <tr>
            <td id="hbllbl">HBL</td>
            <td>:</td>
            <td id="hbl"></td>

            <td id="gwlbl">G.W.</td>
            <td>:</td>
            <td id="gw"></td>
        </tr>

        <tr>
            <td><label id="vesselLbl">VESSEL</label></td>
            <td>:</td>
            <td><label id="vessel"></label></td>

            <td id="ctnlbl"><label >CTN SIZE</label></td>
            <td>:</td>
            <td id="ctn"><label ></label></td>
        </tr>

      
        @*<tr>
            <td><label id="vesselLbl">VESSEL/VOYAGE</label></td>
            <td>:</td>
            <td><label id="vessel">SINAR SOLO V. 936N</label></td>

           

           
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
            <td><label id="containerNoLbl">CONTANER NO.</label></td>
            <td>:</td>
            <td><div id="containerNo"></div></td>

            <td><label id="volumeLbl">VOLUME</label></td>
            <td>:</td>
            <td><label id="volume"></label></td>
        </tr>

        <tr>
            <td></td>
            <td></td>
            <td></td>
          

            <td><label id="refLbl">REF.</label></td>
            <td>:</td>
            <td><label id="ref"></label></td>
        </tr>

        <tr>
            <td><label id="carrierLbl">CARRIER</label></td>
            <td>:</td>
            <td><label id="carrier"></label></td>
        </tr>*@
    </tbody>
</table>
<br />
<table class="table" style="border-width:thin;border-collapse:collapse ;width:98%" border="1">
    <thead>
        <tr class="upperLine underLine">
            <th class="bold align-top" rowspan="2">DESCRIPTION</th>
            <th class="center bold" rowspan="2">W/T</th>
            <th class="center bold" rowspan="2">QTYs</th>
            <th class="center bold" rowspan="2">UOM</th>
            <th id="insouce" class="center bold" colspan="3">IN SOURCE CURRENCY</th>
            <th class="center bold" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr class="upperLine">

            <th class="center bold">Curr.</th>
            <th class="center bold">Exc.</th>
            <th class="center bold">@@ UNIT</th>
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
</table>
<br>
<p>
    TOTAL AMOUNT IN WORDS:
    <label id="bahtText">   BAHT TWENTY-EIGHT THOUSAND FIVE HUNDRED TWENTY-THREE AND</label>
</p>
<p class="bold">DULY CHECKED AND RECEIVED IN GOOD CONDITION</p>
<table class="table">
    <tr>
        <td class="bold" style="width:100px">Receiver :</td>
        <td class="underLine textSpace" style="width:50px"></td>
        <td class="bold" style="width:100px">Sender :</td>
        <td class="underLine textSpace" style="width:50px"></td>
        <td> </td>
        <td class="underLine center" style="width:200px"></td>
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


<p>
    Remark:
    <label id="remark"></label>
</p>

<script type="text/javascript">
    $('#imgLogo').hide();
    $('#imgLogoAdd').show();
    const path = '@Url.Content("~")';
    let bShowSlip = false;
    let branch = getQueryString('branch');
    let code = getQueryString('code');

    //if(confirm("show company header?")==false){
	   // $('#imgLogo').css('display','none');
	   // $('#divCompany').css('display','none');
	   // $('#dvCompAddr').css('display','none');
	   // $('#dvCompLogo').css('height','90px');
    //}

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
                ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#original');
                ShowCountry(path, j.InvCountry, '#destiny');

                $("#loadport").text(j.InvInterPort);
                $("#dcport").text(j.ClearPort);
                 ShowInterPort(path, j.InvFCountry, j.InvInterPort, "#loadport");
                ShowReleasePort(path, j.ClearPort, "#dcport");
            } else {
                $("#loadport").text(j.ClearPort);
                $("#dcport").text(j.InvInterPort);
                ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#dcport');
                ShowReleasePort(path, j.ClearPort, '#loadport');

               
                //ShowInterPort(path, j.InvCountry, j.ClearPort, "#loadport");
                //ShowInterPort(path, j.InvFCountry, j.InvInterPort, "#dcport");
            }
            $("#jobNo").text(j.JNo);
            $("#vessel").text(j.VesselName);
            $("#etd").text(ShowDate(j.ETDDate));
            $("#eta").text(ShowDate(j.ETADate));
            $("#hblNo").text(j.HAWB);
            $("#quantity").text(j.InvProductQty + ' ' + j.InvProductUnit);
            $("#totpkg").text(j.TotalQty + " PALLETS");
            $("#newBlNo").text(j.BookingNo);
            $("#weight").text(ShowNumber(j.TotalGW, 2) + ' ' + j.GWUnit);
            $("#volume").text(j.Measurement);
            $("#custInvNo").text(j.InvNo);
            $("#ref").text(j.CustRefNO);
            $("#customsNo").text(j.DeclareNumber); 
         
            $("#cbm").text(j.Measurement);
            $("#gw").text(j.TotalGW + " " + j.GWUnit);
            $("#ctn").text(j.TotalContainer);
            $("#hbl").text(j.HAWB);
            $("#mbl").text(j.MAWB);
            $("#carrier").text(j.ForwarderCode);
            $("#bkg").text(j.BookingNo);
            $("#imexname").text(c.NameEng);
            

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
                html += '            <td class="right">' + row.Rate50Tavi + '</td>';
                html += '            <td class="center">' + ShowNumber(row.Qty,2) + '</td>';
                html += '            <td class="right">' + row.QtyUnit+'</td>';
                html += '            <td class="right">' + row.CurrencyCode + '</td>';
                html += '            <td class="right">' + ShowNumber(row.ExchangeRate, 2) + '</td>';
                html += '            <td class="right">' + ShowNumber(row.FUnitPrice,2) + '</td>';
                html += '            <td class="right">' + (row.AmtAdvance?ShowNumber(row.Amt, 2):'') + '</td>';
                html += '            <td class="right">' + (row.AmtVat==0?(row.AmtCharge?ShowNumber(row.Amt, 2):''):'') + '</td>';
                html += '            <td class="right">' + (row.AmtVat > 0 && !row.AmtAdvance?ShowNumber(row.Amt, 2) : '') + '</td>';
                html += '        </tr>';
                adv += row.AmtAdvance * row.ExchangeRate.toFixed(4);
                if (row.AmtVat > 0) {
                    vat += row.AmtCharge * row.ExchangeRate.toFixed(4);
                } else {
                    nonVat += row.AmtCharge * row.ExchangeRate.toFixed(4);
                }
             
                if (row.AmtAdvance ) {
                    continue;
                }
                switch (row.Rate50Tavi) {
                  
                    case 1:
                        console.log(row.SDescription + " " + row.AmtAdvanc);
                        sumWht1 += row.Amt50Tavi;
                        sumbaseWht1 += row.Amt;
                        break;
                    case 1.5:
                        console.log(row.SDescription + " " + row.AmtAdvanc);
                        sumWht1_5 += row.Amt50Tavi;
                        sumbaseWht1_5 += row.Amt;
                        break;
                    case 3:
                        console.log(row.SDescription + " " + row.AmtAdvanc);
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
                html += '            <td class="right"></td>';
                html += '            <td class="right"></td>';
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