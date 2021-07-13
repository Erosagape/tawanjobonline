@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "JOB COSTING SUMMARY"
    ViewBag.Title = "Job Costing Summary"
End Code
<style>
    td {
        font-size: 11px;
    }

    tr {
        vertical-align: top;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter {
        display: none;
    }
</style>
<div style="text-align:left;width:100%">
    <b>JOB NO: <label id="lblJNo"></label></b><br />
    <b>BOOKING NO: <label id="lblBLNo"></label></b>
</div>
<div style="display:flex">
    <div style="flex:2">
        JOB TYPE : <label id="lblJobTypeName"></label>
    </div>
    <div style="flex:1">
        SHIP BY : <label id="lblShipByName"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:2">
        CUST NAME : <label id="lblCustName"></label>
    </div>
    <div style="flex:1">
        JOB DATE : <label id="lblJobDate"></label>
    </div>
</div>
<div style="display:flex">
    <div style="flex:2">
        CONSIGNEE : <label id="lblConsName"></label>
    </div>
    <div style="flex:1">
        INSPECTION DATE : <label id="lblDutyDate"></label>
    </div>
</div>
<div style="display:flex">
    <div style="flex:1">
        INVOICE : <label id="lblInvNo"></label>
    </div>
    <div style="flex:1">
        DECLARE NO : <label id="lblDeclareNo"></label>
    </div>
    <div style="flex:1">
        VESSEL : <label id="lblVesselName"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:2">
        PRODUCT NAME : <label id="lblProductName"></label>
    </div>
    <div style="flex:1">
        WEIGHT : <label id="lblGrossWeight"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:1">
        CONTAINER : <label id="lblContainer"></label>
    </div>
    <div style="flex:1">
        SERVICE BY : <label id="lblCSName"></label>
    </div>
    <div style="flex:1">
        QUANTITY : <label id="lblInvQty"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:2">
        <table id="tbAdv" style="width:98%" border="1">
            <thead>
                <tr class="text-center">
                    <th width="5%">NO.</th>
                    <th width="15%">PAY DATE</th>
                    <th width="25%">ADV NO</th>
                    <th width="35%">PRE ADVANCE</th>
                    <th width="15%">AMOUNT</th>
                </tr>
            </thead>
            <tbody id="dvAdv"></tbody>
            <tr>
                <td colspan="4">
                    <div style="display:flex">
                        <div style="flex:1">

                        </div>

                        <div style="flex:1">
                            <br />
                            VAT <br />
                            TOTAL VAT
                        </div>

                        <div style="flex:1">
                            <br />
                            <label id="lblTotalADVVAT"></label><br />
                            <label id="lblTotalADVAfterVAT"></label>
                        </div>

                        <div style="flex:1">
                            TOTAL AMOUNT<br />
                            TAX AMOUNT<br />
                            GRAND TOTAL
                        </div>
                    </div>
                </td>
                <td style="text-align:right">
                    <label id="lblTotalADVAmt"></label><br />
                    <label id="lblTotalADVWHT"></label><br />
                    <label id="lblTotalADV"></label>
                </td>
            </tr>
        </table>
    </div>

    <div style="flex:1">
        <table id="tbCustAdv" style="width:100%" border="1">
            <thead>
                <tr>
                    <th>CUST ADVANCE</th>
                    <th>AMOUNT</th>
                </tr>
            </thead>
            <tbody id="dvCustAdv"></tbody>
            <tr>
                <th style="text-align:right">CREDIT ADVANCE</th>
                <td style="text-align:right"><label id="lblTotalCustAdv"></label></td>
            </tr>
            <tr>
                <th style="text-align:right">CUSTOMER CHEQUE</th>
                <td style="text-align:right"><label id="lblTotalCheque"></label></td>
            </tr>
            <tr>
                <th style="text-align:right">TOTAL EXPENSES</th>
                <td style="text-align:right"><label id="lblTotalExpense"></label></td>
            </tr>
            <tr>
                <th style="text-align:right">TOTAL BALANCE</th>
                <td style="text-align:right"><label id="lblTotalBalance"></label></td>
            </tr>
        </table>
        <br />
        <table style="width:100%" border="1">
            <thead>
                <tr>
                    <th>
                        Adv No/Item
                    </th>
                    <th>
                        Amount
                    </th>
                </tr>
            </thead>
            <tbody id="tbSumClr"></tbody>
            <tr>
                <td><b>TOTAL NON-CLEAR</b></td>
                <td style="text-align:right">
                    <label id="lblTotalClear"></label>
                </td>
            </tr>
        </table>
    </div>
</div>

<br />

<div style="display:flex">
    <div style="flex:1">
        <table id="tbClear" style="width:100%" border="1">
            <thead>
                <tr class="text-center">
                    <th width="15%">CL.NO</th>
                    <th width="28%">DESCRIPTION</th>
                    <th width="12%">SERVICE</th>
                    <th width="10%">VAT</th>
                    <th width="10%">DEPOSIT</th>
                    <th width="13%">ADVANCE</th>
                    <th width="12%">COST</th>
                </tr>
            </thead>
            <tbody id="dvClear"></tbody>
            <tr>
                <td colspan="2">TOTAL</td>
                <td style="text-align:right">
                    <label id="lblSumServ"></label>
                </td>
                <td style="text-align:right">
                    <label id="lblSumVat"></label>
                </td>
                <td style="text-align:right">
                    <label id="lblSumDeposit"></label>
                </td>
                <td style="text-align:right">
                    <label id="lblSumAdv"></label>
                </td>
                <td style="text-align:right">
                    <label id="lblSumCost"></label>
                </td>
            </tr>
        </table>
    </div>
</div>

<div style="display:flex">
    <div style="flex:1">

    </div>
    <div style="flex:1">
        <table style="width:50%" border="1" align="right">
            <tr style="text-align:right">
                <td width="60%">PROFIT</td>
                <td>
                    <label id="lblNetProfit"></label>
                </td>
            </tr>
            <tr style="text-align:right">
                <td width="60%">COMMISSION</td>
                <td><label id="lblCommRate"></label></td>
            </tr>
        </table>
    </div>
</div>

<br />
<table id="tbCheque" style="width:100%" border="1">
    <thead>
        <tr class="text-center">
            <th>CHEQUE NO.</th>
            <th>BANK</th>
            <th>CHEQUE DATE</th>
            <th>CHEQUE AMT</th>
            <th>USED</th>
            <th>REMARK</th>
        </tr>
    </thead>
    <tbody id="dvCheque"></tbody>
</table>
<br />
<table style="border-collapse:collapse;width:100%">
    <tr>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            จัดทำโดย / PREPARED.BY
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            ตรวจสอบโดย / CHECKED.BY
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            อนุมัติโดย / APPROVED.BY
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            ลงบัญชีโดย / POSTED.BY
        </td>
    </tr>
    <tr>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom" height="100px">
            <br />
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <br />
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <br />
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <br />
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
    </tr>
</table>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let br = getQueryString('BranchCode');
    let jno = getQueryString('JNo');
    if (br != "" && jno != "") {
        GetJobInfo(br, jno);
        GetChequeInfo(br, jno);
        GetClearingInfo(br, jno);
        GetAdvanceInfo(br, jno);
        GetAdvanceUnclear(br, jno);
    }
    function GetJobInfo(branch, jno) {
        $.get(path+ 'joborder/getjobreport?branch=' + branch + '&jno=' + jno, function (r) {
            if (r.job.data.length > 0) {
                let h = r.job.data[0];
                $('#lblJNo').text(h.JNo);
                $('#lblBLNo').text(h.BookingNo);
                $('#lblJobTypeName').text(h.JobTypeName);
                $('#lblJobDate').text(ShowDate(CDateTH(h.DocDate)));
                $('#lblCustName').text(h.CustTName);
                $('#lblConsName').text(h.ConsigneeName);
                $('#lblDutyDate').text(ShowDate(CDateTH(h.DutyDate)));
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
        $('#lblTotalCheque').text('0.00');
        $.get(path + 'acc/getvouchergrid?branch=' + branch + '&job=' + code + '&type=CHQR', function (r) {
            if (r.voucher.data.length > 0) {
                let dv = $('#dvCheque');
                dv.empty();
                let totalchq = 0;
                for (o of r.voucher.data[0].Table) {
                    if (o.ChqNo !== null) {
                        let html = '';

                        html += '<tr>';
                        html += '<td>'+o.ChqNo+'</td>';
                        html += '<td>' + o.BankCode + ' สาขา ' + o.BankBranch + '</td>';
                        html += '<td>'+ShowDate(CDateTH(o.ChqDate))+'</td>';
                        html += '<td style="text-align:right">'+CCurrency(CDbl(o.ChqAmount,2))+'</td>';
                        html += '<td style="text-align:right">'+CCurrency(CDbl(o.SumAmount,2))+'</td>';
                        html += '<td>'+o.DRemark+'</td>';
                        html += '</tr>';
                        totalchq += Number(o.ChqAmount);
                        dv.append(html);
                    }
                }
                $('#lblTotalCheque').text(CCurrency(CDbl(totalchq, 2)));
            }
        });
    }
    function GetAdvanceUnclear(branch, code) {
        $.get(path + 'clr/getadvforclear?branchcode=' + branch + '&jobno=' + code + '&show=ALL', function (r) {
            if (r.clr.data.length > 0) {
                let dr = r.clr.data[0].Table;
                let dv = $('#tbSumClr');
                dv.empty();
                let sumunclr = 0;
                for (let i = 0; i < dr.length; i++) {
                    let d = dr[i];
                    if (d.DocStatus < 6) {
                        //if ((d.AdvBalance > 0 && d.UsedAmount >= 0) || d.AdvDate == null) {
                        if (d.AdvBalance !== 0) {
                            let htmlc = '<tr>';
                            htmlc += '<td>' + d.AdvNO + '#' + d.AdvItemNo + '</td>';
                            htmlc += '<td style="text-align:right">' + CCurrency(CDbl(d.AdvBalance, 2)) + '</td>';
                            htmlc += '</tr>';
                            sumunclr += d.AdvBalance;
                            dv.append(htmlc);
                        }
                    }
                }
                $('#lblTotalClear').text(CCurrency(CDbl(sumunclr, 2)));
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
        $.get(path + 'clr/getclearingreport?branch=' + branch + '&job=' + code,function (r) {
            let amtadv = 0;
            let amtserv = 0;
            let amtchg = 0;
            let amtvat = 0;
            let amtdeposit = 0;
            let amtwht = 0;
            let amttotal = 0;
            let amtclr = 0;
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
                let codeDepo = ',ERN-001,B-DEP-001';
                for (let i = 0; i < d.length; i++){
                    let html = '';

                    let adv = (d[i].IsCredit == 1 ? d[i].BNet : 0);
                    let serv = (d[i].IsCredit == 0 && d[i].IsExpense == 0 && codeDepo.indexOf(d[i].SICode) < 0 ? d[i].BNet : 0);
                    let cost = (d[i].IsExpense == 1 && codeDepo.indexOf(d[i].SICode) < 0 ? d[i].BNet : 0);
                    let profit = (d[i].IsExpense == 1 && codeDepo.indexOf(d[i].SICode) < 0 ? d[i].BNet * -1 : (d[i].IsCredit == 1 && codeDepo.indexOf(d[i].SICode) < 0  ? 0 : d[i].BNet));
                    if (codeDepo.indexOf(d[i].SICode) >= 0) {
                        amtdeposit += d[i].BNet;
                    }
                    amtadv += adv;
                    amtserv += serv;
                    if (serv > 0) {
                        amtchg += d[i].UsedAmount;
                    }
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
                    html += '<td>' + d[i].SDescription;
                    if (d[i].AdvNO !== '') {
                        html += ' (' + d[i].AdvNO + ')';
                    }
                    if (d[i].SlipNO !== '') html += ' #' + d[i].SlipNO;

                    html += '</td>';
                    html += '<td style="text-align:right">' + (serv > 0 ? CCurrency(CDbl(d[i].UsedAmount, 2)) : '0.00') + '</td>';
                    html += '<td style="text-align:right">' + (serv > 0 ? CCurrency(CDbl(d[i].ChargeVAT, 2)): '0.00') + '</td>';
                    html += '<td style="text-align:right">' + (codeDepo.indexOf(d[i].SICode) >= 0 ? CCurrency(CDbl(d[i].BNet, 2)): '0.00') + '</td>';
                    html += '<td style="text-align:right">' + (adv > 0 ? CCurrency(CDbl(d[i].BNet, 2)): '0.00') + '</td>';
                    html += '<td style="text-align:right">' + (cost > 0 ? CCurrency(CDbl(d[i].BNet, 2)): '0.00') + '</td>';
                    html += '</tr>';

                    amtcost += cost;
                    amttotal += serv + adv;
                    amtprofit += profit;

                    dv.append(html);
                }
            }
            //$('#lblTotalClear').text(CCurrency(CDbl(amtclr, 2)));
            $('#lblSumDeposit').text(CCurrency(CDbl(amtdeposit, 2)));
            $('#lblSumCost').text(CCurrency(CDbl(amtcost, 2)));
            $('#lblSumAdv').text(CCurrency(CDbl(amtadv, 2)));
            $('#lblSumServ').text(CCurrency(CDbl(amtchg, 2)));
            $('#lblSumVat').text(CCurrency(CDbl(amtvat, 2)));
            //$('#lblSumWht').text(CCurrency(CDbl(amtwht,2)));
            $('#lblTotalExpense').text(CCurrency(CDbl((amtadv+amtserv), 2)));
            $('#lblTotalBalance').text(CCurrency(CDbl(CNum(CNum($('#lblTotalCustAdv').text())+CNum($('#lblTotalCheque').text()))- CNum(amtadv + amtserv),2)));
            //$('#lblSumCharge').text(CCurrency(CDbl(amttotal,2)));
            //$('#lblSumTax').text(CCurrency(CDbl(amtwht,2)));
            //$('#lblSumNet').text(CCurrency(CDbl(amtcost+amtserv+amtadv,2)));
            //$('#lblSumProfit').text(CCurrency(CDbl(amtprofit,2)));
            //$('#lblTotalVAT').text(CCurrency(CDbl(amtvat, 2)));
            amtprofit = amtchg - (amtvat + amtcost);
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