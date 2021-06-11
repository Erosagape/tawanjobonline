@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "JOB COSTING SUMMARY"
    ViewBag.Title = "Job Costing Summary"
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

    .table-bordered td, .table-bordered th {
        border: 1px solid black;
    }

    .table td, table th {
        padding: .3rem;
    }

    .table-borderless td {
        border: none;
    }

    .table-bordered thead td, .table-bordered thead th {
        border-bottom-width: 1px;
    }
</style>
<div class="center bold">
    <label id="companyName" style="font-size:20px">TOTAL SHIPPING SERVICE CO.,LTD.</label>
</div>
<div style="display: flex;">
    <div style="flex:25%"></div>
    <div class="center bold" style="flex:50%">
        <label class="" style="font-size:16px">SALE RECORD (SEA INBOUND)</label>
    </div>
    <div style="flex:10%">
        <label id="numberLbl">Number</label>

    </div>
    <div style="flex:15%">
        <label id="number"></label>
    </div>
</div>

<table class="table table-borderless">
    <thead></thead>
    <tbody>
        <tr>
            <td id="dateLbl">Date</td>
            <td>:</td>
            <td id="date"></td>

            <td id="referenceLbl">Reference </td>
            <td>:</td>
            <td id="reference"></td>

            <td id="BLNoLbl">B/L No.</td>
            <td>:</td>
            <td id="BLNo"></td>
        </tr>
        <tr>
            <td id="agentLbl">Agent</td>
            <td>:</td>
            <td id="agent"></td>

            <td id="fromLbl">From.</td>
            <td>:</td>
            <td id="from"></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td id="shipperLbl">Shipper</td>
            <td>:</td>
            <td id="shipper"></td>

            <td id="toLbl">To.</td>
            <td>:</td>
            <td id="to"></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td id="consigneeNameLbl">Consignee</td>
            <td>:</td>
            <td id="consigneeName"></td>

            <td id="termLbl">Term</td>
            <td>:</td>
            <td id="term"></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td id="shippingAgentLbl">Shipping Agent</td>
            <td>:</td>
            <td id="shippingAgent"></td>

            <td id="etdLbl">ETD</td>
            <td>:</td>
            <td id="etd"></td>

            <td id="etaLbl">ETA</td>
            <td>:</td>
            <td id="eta"></td>
        </tr>
        <tr>
            <td id="customsBrokerLbl">Customs Broker</td>
            <td>:</td>
            <td id="customsBroker"></td>

            <td id="shedLbl">SHED</td>
            <td>:</td>
            <td id="shed"></td>

            <td id="terminalLbl">TERMINAL</td>
            <td>:</td>
            <td id="terminal"></td>
        </tr>
        <tr>
            <td id="feederLbl">FEEDER / VESSEL</td>
            <td>:</td>
            <td id="feeder"></td>

            <td id="cbmLbl">CBM</td>
            <td>:</td>
            <td id="cbm"></td>

            <td id="volumeLbl">Volume</td>
            <td>:</td>
            <td id="volume"></td>
        </tr>
        <tr>
            <td id="remarkLbl">REMARK</td>
            <td>:</td>
            <td id="remark"></td>

            <td id="sellUSD:THBLbl">Selling USD:THB</td>
            <td>:</td>
            <td id="sellUSD:THB"></td>

            <td id="buyUSD:THBLbl">Buying USD:THB</td>
            <td>:</td>
            <td id="buyUSD:THB"></td>
        </tr>
    </tbody>
</table>

<table class="table" border="1" style="width:100%;border-collapse:collapse;border-width:thin;">
    <thead>
        <tr>
            <td rowspan="2">Description</td>
            <td class="center" rowspan="2">C/P</td>
            <td class="center" rowspan="2">Settle with</td>
            <td class="center" rowspan="2">Qty</td>
            <td class="center" rowspan="2">Uom</td>
            <td class="center" colspan="4">IN SOURCE CURRENCY</td>
            <td class="center" colspan="4">TOTAL BILL (DOC. CURR)</td>
        </tr>
        <tr>
            <td class="center">Curr</td>
            <td class="center">Exc</td>
            <td class="center">Unit price</td>
            <td class="center">Amount</td>
            <td class="center">Advance</td>
            <td class="center">Charge</td>
            <td class="center">Total</td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>CUSTOMS CLEARANCE CHARGE</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">3,000.00</td>
            <td class="right">3,000.00</td>
            <td class="right">-</td>
            <td class="right">3,000.00</td>
            <td class="right">3,000.00</td>
        </tr>
        <tr>
            <td>CUSTOM TAX ( RECEIPT )</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">200.00</td>
            <td class="right">200.00</td>
            <td class="right">200.00</td>
            <td class="right">-</td>
            <td class="right">200.00</td>
        </tr>
        <tr>
            <td>IMPORT DUTIES (RECEIPT)</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">21,609.00</td>
            <td class="right">21,609.00</td>
            <td class="right">21,609.00</td>
            <td class="right">-</td>
            <td class="right">21,609.00</td>
        </tr>
        <tr>
            <td>THC , B/L, D/O ( RECEIPT )</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">8,223.68</td>
            <td class="right">8,223.68</td>
            <td class="right">8,223.68</td>
            <td class="right">-</td>
            <td class="right">8,223.68</td>
        </tr>
        <tr>
            <td>WAREHOUSE RENTAL (RECEIIPT )</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right"> 676.13</td>
            <td class="right"> 676.13</td>
            <td class="right"> 676.13</td>
            <td class="right">-</td>
            <td class="right"> 676.13</td>
        </tr>
        <tr>
            <td>INSPECTION CHARGE</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">2,500.00</td>
            <td class="right">2,500.00</td>
            <td class="right">-</td>
            <td class="right">2,500.00</td>
            <td class="right">2,500.00</td>
        </tr>
        <tr>
            <td>FDA</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">2,000.00</td>
            <td class="right">2,000.00</td>
            <td class="right">-</td>
            <td class="right">2,000.00</td>
            <td class="right">2,000.00</td>
        </tr>
        <tr>
            <td>LPI PERMIT (DFA)</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,800.00</td>
            <td class="right">1,800.00</td>
            <td class="right">-</td>
            <td class="right">1,800.00</td>
            <td class="right">1,800.00</td>
        </tr>
        <tr>
            <td>TRANSPORTATION</td>
            <td class="center">P</td>
            <td class="">PHARMAMARK</td>
            <td class="right">1.00</td>
            <td class="center">TRUCK</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">9,200.00</td>
            <td class="right">9,200.00</td>
            <td class="right">-</td>
            <td class="right">9,200.00</td>
            <td class="right">9,200.00</td>
        </tr>
        <tr>
            <td colspan="9"></td>
            <td id="advance1"></td>
            <td id="charge1"></td>
            <td id="total1"></td>
        </tr>
    </tbody>
</table>

<table class="table" border="1" style="width:100%;border-width:thin;border-collapse:collapse;">
    <thead>
        <tr>
            <td rowspan="2">Description</td>
            <td class="center" rowspan="2">C/P</td>
            <td class="center" rowspan="2">Settle with</td>
            <td class="center" rowspan="2">Qty</td>
            <td class="center" rowspan="2">Uom</td>
            <td class="center" colspan="4">IN SOURCE CURRENCY</td>
            <td class="center" colspan="4">TOTAL BILL (DOC. CURR)</td>
        </tr>
        <tr>
            <td class="center">Curr</td>
            <td class="center">Exc</td>
            <td class="center">Unit price</td>
            <td class="center">Amount</td>
            <td class="center">Advance</td>
            <td class="center">Charge</td>
            <td class="center">Total</td>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>CUSTOMS CLEARANCE CHARGE</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,900.00</td>
            <td class="right">1,900.00</td>
            <td class="right">-</td>
            <td class="right">1,900.00</td>
            <td class="right">1,900.00</td>
        </tr>
        <tr>
            <td>CUSTOM TAX ( RECEIPT )</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">200.00</td>
            <td class="right">200.00</td>
            <td class="right">200.00</td>
            <td class="right">0.00</td>
            <td class="right">200.00</td>
        </tr>
        <tr>
            <td>IMPORT DUTIES (RECEIPT)</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">21,609.00</td>
            <td class="right">21,609.00</td>
            <td class="right">21,609.00</td>
            <td class="right">0.00</td>
            <td class="right">21,609.00</td>
        </tr>
        <tr>
            <td>THC , B/L, D/O ( RECEIPT )</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">8,223.68</td>
            <td class="right">8,223.68</td>
            <td class="right">8,223.68</td>
            <td class="right">0.00</td>
            <td class="right">8,223.68</td>
        </tr>
        <tr>
            <td>IT CHARGE</td>
            <td class="center">P</td>
            <td class="">UN-TH</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">USD</td>
            <td class="right">30.95000</td>
            <td class="right">3.00</td>
            <td class="right">3.00</td>
            <td class="right">-</td>
            <td class="right">92.85</td>
            <td class="right">92.85</td>
        </tr>
        <tr>
            <td>WAREHOUSE RENTAL (RECEIIPT )</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right"> 676.13</td>
            <td class="right"> 676.13</td>
            <td class="right"> 676.13</td>
            <td class="right">0.00</td>
            <td class="right"> 676.13</td>
        </tr>
        <tr>
            <td>INSPECTION CHARGE</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,500.00</td>
            <td class="right">1,500.00</td>
            <td class="right">-</td>
            <td class="right">1,500.00</td>
            <td class="right">1,500.00</td>
        </tr>
        <tr>
            <td>TRANSPORTATION</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">TRUCK</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">8,000.00</td>
            <td class="right">8,000.00</td>
            <td class="right">-</td>
            <td class="right">8,000.00</td>
            <td class="right">8,000.00</td>
        </tr>
        <tr>
            <td>SERVICE FEE</td>
            <td class="center">P</td>
            <td class="">UN-TH</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">USD</td>
            <td class="right">30.95000</td>
            <td class="right">10.00</td>
            <td class="right">10.00</td>
            <td class="right">-</td>
            <td class="right">309.50</td>
            <td class="right">309.50</td>
        </tr>
        <tr>
            <td>FDA</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,500.00</td>
            <td class="right">1,500.00</td>
            <td class="right">-</td>
            <td class="right">1,500.00</td>
            <td class="right">1,500.00</td>
        </tr>
        <tr>
            <td>LPI PERMIT (DFA)</td>
            <td class="center">P</td>
            <td class="">UNIVERSE LOG</td>
            <td class="right">1.00</td>
            <td class="center">SET</td>
            <td class="center">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,000.00</td>
            <td class="right">1,000.00</td>
            <td class="right">-</td>
            <td class="right">1,000.00</td>
            <td class="right">1,000.00</td>
        </tr>
        <tr>
            <td colspan="9"></td>
            <td id="advance2"></td>
            <td id="charge2"></td>
            <td id="total2"></td>
        </tr>
    </tbody>
</table>

<div class="row">
    <div class="col-8"></div>
    <div class="col-4">
        <p class="right bold" style="border: 1px solid black;">
            <label id="netAmountLbl"> NET AMOUNT IN THB</label>
            <label id="netAmount"></label>
        </p>
    </div>
</div>

<script type="text/javascript">
    let path = '@Url.Content("~")';
    let br = getQueryString('BranchCode');
    let jno = getQueryString('JNo');
    if (br != "" && jno != "") {
        GetJobInfo(br, jno);
        GetChequeInfo(br, jno);
        GetClearingInfo(br, jno);
        GetAdvanceInfo(br, jno);
    }
    function GetJobInfo(branch, jno) {
        $.get(path+ 'joborder/getjobreport?branch=' + branch + '&jno=' + jno, function (r) {
            if (r.job.data.length > 0) {
                let h = r.job.data[0];
                $('#lblJNo').text(h.JNo);
                $('#lblJobTypeName').text(h.JobTypeName);
                $('#lblJobDate').text(ShowDate(CDateTH(h.DocDate)));
                $('#lblCustName').text(h.CustTName);
                $('#lblShipByName').text(h.ShipByName);
                $('#lblInvNo').text(h.InvNo);
                $('#lblDeclareNo').text(h.DeclareNumber);
                $('#lblVesselName').text(h.VesselName);
                $('#lblProductName').text(h.InvProduct);
                $('#lblGrossWeight').text(h.TotalGW);
                $('#lblContainer').text(h.TotalContainer);
                $('#lblCSName').text(h.CSName);
                $('#lblInvQty').text(h.InvProductQty);
            }
        });
    }
    function GetChequeInfo(branch, code) {
        $.get(path + 'acc/getvouchergrid?branch=' + branch + '&job=' + code + '&type=CHQR', function (r) {
            if (r.voucher.data.length > 0) {
                let dv = $('#dvCheque');
                dv.empty();
                for (o of r.voucher.data[0].Table) {
                    let html = '';

                    html += '<tr>';
                    html += '<td>'+o.ChqNo+'</td>';
                    html += '<td>' + o.BankCode + ' สาขา ' + o.BankBranch + '</td>';
                    html += '<td>'+ShowDate(CDateTH(o.ChqDate))+'</td>';
                    html += '<td style="text-align:right">'+CCurrency(CDbl(o.ChqAmount,2))+'</td>';
                    html += '<td style="text-align:right">'+CCurrency(CDbl(o.SumAmount,2))+'</td>';
                    html += '<td>'+o.DRemark+'</td>';
                    html += '</tr>';

                    dv.append(html);
                }
            }
        });
    }
    function GetAdvanceInfo(branch, code) {
        $.get(path + 'adv/getadvancereport?branchcode=' + branch + '&jobno=' + code +'&advtype=1,2,3,4,5', function (r) {
            let i = 0;
            let itotalvat = 0;
            let itotalpay = 0;
            let itotalwht = 0;
            let itotalamt = 0;
            let itotalnet = 0;
            let jtotaladv = 0;
            let j = 0;

            if (r.adv.data.length > 0) {
                let d1 = $('#dvAdv');
                let d2 = $('#dvCustAdv');
                d1.empty();
                d2.empty();
                let d = r.adv.data[0].Table;

                for (let i = 0; i < d.length; i++){
                    let o = d[i];
                    let html1 = '';
                    let html2 = '';

                    if (o.AdvType < 5) {
                        j += 1;
                        itotalamt += o.BaseAmount;
                        itotalvat += o.ChargeVAT;
                        itotalwht += o.Charge50Tavi;
                        itotalpay += o.AdvPayAmount;
                        itotalnet += o.AdvNet;

                        html1 = '<tr>';
                        html1 += '<td>' + j + '</td>';
                        html1 += '<td>' + ShowDate(o.PaymentDate) + '</td>';
                        html1 += '<td>' + o.AdvNo + '#' + o.ItemNo + '</td>';
                        html1 += '<td>';
                        if (o.SICode !== null) html1 += o.SICode + '-' + o.SDescription;
                        html1 += '</td>';
                        html1 += '<td style="text-align:right">' + CCurrency(CDbl(o.AdvPayAmount, 2)) + '</td>';
                        html1 += '</tr>';
                        d1.append(html1);
                    } else {
                        jtotaladv += o.AdvPayAmount;
                        html2 = '<tr>';
                        html2 += '<td>';
                        if (o.SICode !== null) html2 += o.SICode + '-' + o.SDescription + ' #' + o.AdvNo;
                        html2 += '</td>';
                        html2 += '<td style="text-align:right">' + CCurrency(CDbl(o.AdvPayAmount, 2)) + '</td>';
                        html2 += '</tr>';
                        d2.append(html2);
                    }
                }
            }

            $('#lblTotalCustAdv').text(CCurrency(CDbl(jtotaladv, 2)));
            $('#lblTotalADVVAT').text(CCurrency(CDbl(itotalvat,2)));
            $('#lblTotalADVAfterVAT').text(CCurrency(CDbl(itotalpay,2)));
            $('#lblTotalADVAmt').text(CCurrency(CDbl(itotalamt,2)));
            $('#lblTotalADVWHT').text(CCurrency(CDbl(itotalwht,2)));
            $('#lblTotalADV').text(CCurrency(CDbl(itotalnet, 2)));
        });
    }
    function GetClearingInfo(branch, code) {
        $.get(path + 'clr/getclearingreport?branch=' + branch + '&job=' + code, function (r) {
            let amtadv = 0;
            let amtserv = 0;
            let amtvat = 0;
            let amtwht = 0;
            let amttotal = 0;
            let amtprofit = 0;
            let amtcost = 0;
            let commrate = 0;
            if (r.data.length > 0) {
                let dv = $('#dvClear');
                dv.empty();

                let h = r.data[0].Table[0];

                commrate = h.Commission;

                let d = r.data[0].Table.filter(function (data) {
                    return data.BNet !== 0;
                });
                for (let i = 0; i < d.length; i++){
                    let html = '';

                    let amt = d[i].UsedAmount;
                    let adv = (d[i].IsCredit == 1 ? amt : 0);
                    let serv = (d[i].IsCredit == 0 && d[i].IsExpense == 0 ? amt : 0);
                    let cost = (d[i].IsExpense == 1 || d[i].IsCredit==1 ? amt : 0);
                    let profit = (d[i].IsExpense == 1 ? amt*-1 : d[i].IsCredit==1 ? 0 : d[i].UsedAmount);

                    amtadv += adv;
                    amtserv += serv;

                    if (d[i].IsCredit == 0 && d[i].IsExpense == 0) {
                        if (d[i].IsTaxCharge > 0) {
                            amtvat += d[i].ChargeVAT;
                        }
                        if (d[i].Is50Tavi > 0) {
                            amtwht += d[i].Tax50Tavi;
                        }
                    }
                    html = '<tr>';
                    html += '<td>' + d[i].ClrNo + '#' + d[i].ItemNo + '</td>';
                    html += '<td>' + d[i].SICode + '-' + d[i].SDescription;
                    if (d[i].AdvNO !== null) html +=' จากใบเบิก '+ d[i].AdvNO;
                    if (d[i].SlipNO !== null) html += ' ใบเสร็จเลขที่ ' + d[i].SlipNO;

                    html += '</td>';
                    html += '<td style="text-align:right">' + CCurrency(CDbl(adv + serv, 2)) + '</td>';
                    html += '<td style="text-align:right">' + CCurrency(CDbl(d[i].ChargeVAT, 3)) + '</td>';
                    html += '<td style="text-align:right">' + CCurrency(CDbl(d[i].Tax50Tavi, 3)) + '</td>';
                    html += '<td style="text-align:right">' + CCurrency(CDbl(cost, 2)) + '</td>';
                    html += '<td style="text-align:right">' + CCurrency(CDbl(profit,2)) + '</td>';
                    html += '</tr>';

                    amtcost += cost;
                    amttotal += serv + adv;
                    amtprofit += profit;

                    dv.append(html);
                }
            }
            $('#lblSumAdv').text(CCurrency(CDbl(amtadv, 2)));
            $('#lblSumServ').text(CCurrency(CDbl(amtserv,2)));

            $('#lblSumCharge').text(CCurrency(CDbl(amttotal,2)));
            $('#lblSumTax').text(CCurrency(CDbl(amtwht,2)));
            $('#lblSumCost').text(CCurrency(CDbl(amtcost,2)));
            $('#lblSumProfit').text(CCurrency(CDbl(amtprofit,2)));
            $('#lblTotalVAT').text(CCurrency(CDbl(amtvat, 2)));
            if (amtprofit > 0) {
                $('#lblCommRate').text(CCurrency(CDbl(amtprofit * (commrate / 100), 2)));
                $('#lblNetProfit').text(CCurrency(CDbl(amtprofit - (amtprofit * (commrate / 100)), 2)));
            } else {
                $('#lblCommRate').text(CCurrency(CDbl(0,2)));
                $('#lblNetProfit').text(CCurrency(CDbl(amtprofit, 2)));
            }
        });
    }
</script>