﻿@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "PRE-INVOICE"
    ViewBag.ReportName = "PRE-INVOICE"
End Code
<div style="float:right">
    <b>SHIPMENT NO : </b><label id="lblJNo"></label>
    <br />
    <b>DATE : </b><label id="lblOpenDate"></label>
</div>
<div style="float:left">
    <b>Invoice To : </b><label id="lblCustName"></label>
    <br />
    <b>Address : </b><label id="lblCustAddress1"></label>
    <br /><label id="lblCustAddress2"></label>
</div>
<br />
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>ORIGIN : </b><label id="lblCountryPort"></label>
    </div>
    <div style="flex:1">
        <b>ETD :</b><label id="lblETDDate"></label>
    </div>
    <div style="flex:1">
        <b>ETA :</b><label id="lblETADate"></label>
    </div>
</div>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>VESSEL : </b><label id="lblVesselName"></label>
    </div>
    <div style="flex:2">
        <b>FEEDER/VOY : </b><label id="lblMVesselName"></label>
    </div>
</div>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>CUST INV :</b><label id="lblCustInv"></label>
    </div>
    @*<div style="flex:1">
            <b>QUANTITY :</b><label id="lblInvQty"></label> &nbsp; <label id="lblInvQtyUnit"></label>
        </div>*@
    <div style="flex:1">
        <b>TOTAL CONTAINER :</b><label id="lblTotalContainer"></label>
    </div>
    <div style="flex:1">
        <b>CBM :</b><label id="lblMeasurement"></label>
    </div>
</div>
<div style="width:100%;display:flex">
    <div style="flex:1">
        <b>B/L CHANGE : </b><label id="lblBLStatus"></label>
    </div>
    <div style="flex:1">
        <b>WEIGHT : </b><label id="lblGrossWeight"></label>
    </div>
    <div style="flex:1">
        <b>SHED : </b><label id="lblDeliveryTo"></label>
    </div>
</div>
@*<hr style="border-style:solid;" />*@
<br />
<table id="dvHeader" style="width:100%">
    <thead d="dvHeader">
        <tr style="border-top: 1px solid black; border-bottom: 1px solid black; ">
            <th class="vborder" style="width:10%">DESCRIPTION</th>
            <th class="vborder" style="width:5%">EXC</th>
            <th class="vborder" style="width:5%">CUR</th>
            <th class="vborder" style="width:5%">QTY</th>
            <th class="vborder" style="width:5%">UNIT</th>
            <th class="vborder" style="width:10%">UNITPRICE</th>
            <th class="vborder" style="width:10%">CHARGE</th>
            <th class="vborder" style="width:10%">VAT</th>
            <th class="vborder" style="width:10%">WHT</th>
            <th class="vborder" style="width:10%">SERVICE<br />(A-W)</th>
            <th class="vborder" style="width:10%">ADVANCE</th>
            <th class="vborder" style="width:10%">TOTAL<br />(A+V-W)</th>
        </tr>
    </thead>
    <tbody id="dvDetail"></tbody>
    <tbody id="dvHeader2">
        <tr style="border-top: 1px solid black; border-bottom: 1px solid black;">
            <th class="vborder" style="width:10%">DESCRIPTION</th>
            <th class="vborder" style="width:5%">EXC</th>
            <th class="vborder" style="width:5%">CUR</th>
            <th class="vborder" style="width:5%">QTY</th>
            <th class="vborder" style="width:5%">UNIT</th>
            <th class="vborder" style="width:10%">UNITPRICE</th>
            <th class="vborder" style="width:10%">CHARGE</th>
            <th class="vborder" style="width:10%">VAT</th>
            <th class="vborder" style="width:10%">WHT</th>
            <th class="vborder" style="width:10%">COST<br />(A)</th>
            <th class="vborder" style="width:10%">ADVANCE</th>
            <th class="vborder" style="width:10%">TOTAL<br />(A+V-W)</th>
        </tr>
    </tbody>
    <tbody id="dvDetail2"></tbody>
</table>
<!--<div id="dvHeader" style="display:flex;text-align:center;border-top:1px solid black;border-bottom:1px solid black;">-->
@*<div class="vborder" style="width:10%">
        <u><b>SICODE</b></u>
    </div>*@
<!--<div class="vborder" style="width:25%">
        <u><b>DESCRIPTION</b></u>
    </div>
    <div class="vborder" style="width:5%">
        <u><b>EXC</b></u>
    </div>
    <div class="vborder" style="width:5%">
        <u><b>CUR</b></u>
    </div>
    <div class="vborder" style="width:10%">
        <u><b>QTY</b></u>
    </div>
    <div class="vborder" style="width:6%">
        <u><b>UNIT</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>SERVICE</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>VAT</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>WHT</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>CHARGE</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>ADVANCE</b></u>
    </div>
</div>-->

<br />
@*<table id="dvHeader2" style="width:100%">
</table>*@

<!--<div id="dvHeader2" style="display:flex;text-align:center;border-top:1px solid black;border-bottom:1px solid black;">-->
@*<div class="vborder" style="width:10%">
        <u><b>SICODE</b></u>
    </div>*@
<!--<div class="vborder" style="width:25%">
        <u><b>DESCRIPTION</b></u>
    </div>
    <div class="vborder" style="width:5%">
        <u><b>EXC</b></u>
    </div>
    <div class="vborder" style="width:5%">
        <u><b>CUR</b></u>
    </div>
    <div class="vborder" style="width:10%">
        <u><b>QTY</b></u>
    </div>
    <div class="vborder" style="width:6%">
        <u><b>UNIT</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>COST</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>VAT</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>WHT</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>COST</b></u>
    </div>
    <div class="vborder" style="width:15%">
        <u><b>ADVANCE</b></u>
    </div>
</div>
<div  id="dvDetail2">
</div>-->
<br />
<div id="summary" style="display:flex;text-align:center;border-top:1px solid black;border-bottom:1px solid black;">

</div>
<br />
<br />
<br />
@*<hr style="border-style:solid;" />*@
@*<div style="width:80%;text-align:right;float:left">
        <b>Advances:</b><br />
        <b>Charges:</b><br />
        <b>Vat:</b><br />
        <b>Total:</b><br />
        <b>With-holding tax:</b><br />
        <b>Net total:</b><br />
    </div>
    <div style="width:20%;float:right;text-align:right;">
        <div style="display:block;width:100%">
            <label id="lblSumCost"></label>
        </div>
        <div style="display:block;width:100%">
            <label id="lblSumAmount"></label>
        </div>
        <div style="display:block;width:100%">
            <label id="lblSumVat"></label>
        </div>
        <div style="display:block;width:100%">
            <label id="lblSumTotal"></label>
        </div>
        <div style="display:block;width:100%">
            <label id="lblSumWht"></label>
        </div>
        <div style="display:block;width:100%">
            <label id="lblSumNet"></label>
        </div>
    </div>*@
<div></div>
<p>
    PLEASE REMIT TO ACCOUNT NO.<br />
    017-111-1943<br />
    KASIKORN BANK<br />
    “ BETTER FREIGHT AND TRANSPORT CO.,LTD.”<br />

</p>
<script type="text/javascript">

    let ans = confirm('OK to print for Customer or Cancel For Company');
    if (ans == true) {
        $('#dvHeader2').hide();
        $('#dvDetail2').hide();
        $('#summary').hide();
    } else {

    }
    let path = '@Url.Content("~")';
    let branch = getQueryString("Branch");
    let job = getQueryString("Job");
    $.get(path + 'Adv/GetClearExpReport?Branch=' + branch + '&Job=' + job).done(function (r) {
        if (r.estimate.data.length > 0) {
            let dr = r.estimate.data;
            CallBackQueryJob(path, branch, job, ReadJob);
            ReadData(dr);
        }
    });
    function ReadJob(dt) {
        let dr = {};
        if (dt.length > 0) {
            dr = dt[0];
        } else {
            return;
        }
        $('#lblETDDate').text(ShowDate(dr.ETDDate));
        $('#lblETADate').text(ShowDate(dr.ETADate));
        $('#lblVesselName').text(dr.VesselName);
        $('#lblMVesselName').text(dr.MVesselName);
        $('#lblCustInv').text(dr.InvNo);
      /*  $('#lblInvQty').text(dr.InvProductQty);*/
        ShowCountry(path, dr.InvCountry, '#lblCountryPort');
        /*  ShowInvUnit(path, dr.InvProductUnit, '#lblInvQtyUnit');*/
        $('#lblTotalContainer').text(dr.TotalContainer);
        $('#lblMeasurement').text(dr.Measurement);
        $('#lblBLStatus').text(dr.BookingNo);
        $('#lblGrossWeight').text(dr.TotalGW + ' ' + dr.GWUnit);
        $('#lblDeliveryTo').text(dr.ClearPortNo);

        CallBackQueryCustomer(path, dr.CustCode, dr.CustBranch, function (data) {
            $('#lblCustName').text(data.NameEng);
            $('#lblCustAddress1').text(data.EAddress1);
            $('#lblCustAddress2').text(data.EAddress2);
        });
    }
    function ReadData(dt) {
        let dr = {};
        if (dt.length > 0) {
            dr = dt[0];
        } else {
            return;
        }
        $('#lblJNo').text(dr.JNo);
        $('#lblOpenDate').text(ShowDate(GetToday()));

        let html = '';
        let html2 = '';
        let totamt = 0;
        let totvat = 0;
        let totwht = 0;
        let total = 0;
        let totcost = 0;
        let totalCost = 0;
        let totalCharge = 0;

        let totalBaseCharge = 0;
        let totalVatCharge = 0;
        let totalWhtCharge = 0;
        let totalAdvCharge = 0;
        let totalBaseCost = 0;
        let totalVatCost = 0;
        let totalWhtCost = 0;
        let totalAdvCost = 0;
        let totalGet = 0
        let totalPay= 0;
        let sumHtml = "";

        let expense = dt.filter((obj) => (obj.SICode.indexOf("INT") >= 0 || (obj.IsExpense == 1 && obj.IsCredit == 0) || (obj.IsCredit == 1 && obj.IsExpense == 0)));

        expense = expense.filter((obj) => (obj.SICode!=="CSP-002" && obj.SICode !== "CSP-003"));

           
        console.log(expense);

        let income = dt.filter((obj) => (obj.SICode.indexOf("INT") < 0 && (obj.IsCredit == 0 && obj.IsExpense == 0) || (obj.IsCredit == 1 && obj.IsExpense == 0)) );
        console.log(income);

        //html += '<div class="border" style="display:flex;width:100%;padding:2px;">Income</div>';
        for (let r of income) {
            html += '<tr  >';
        /*    html += '<div class="vborder" style="width:10%">' + r.SICode + '</div>';*/
            html += '<td class="vborder" style="width:20%;">' + r.SDescription + '</td>';
            html += '<td class="vborder" style="width:5%;text-align:center">' + r.ExchangeRate + '</td>';
            html += '<td class="vborder" style="width:5%;text-align:center">' + r.CurrencyCode + '</td>';
            html += '<td class="vborder" style="width:5%;text-align:center">' + r.Qty + '</td>';
            html += '<td class="vborder" style="width:5%;text-align:center">' + r.QtyUnit + '</td>';
            html += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 0 ? CCurrency(CDbl(r.AmountCharge , 2)) : "") + '</td>';
            html += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 0 ? CCurrency(CDbl(r.AmountCharge * r.ExchangeRate * r.Qty, 2)):"" )+ '</td>';
            html += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 0 ?CCurrency(CDbl(r.AmtVat, 2)):"") + '</td>';
            html += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 0 ?CCurrency(CDbl(r.AmtWht, 2)):"") + '</td>';
            if (r.IsCredit == 1) {
                //html += '<td class="vborder" style="width:15%;text-align:right">' + CCurrency(CDbl(r.AmountCharge, 2)) + '</td>';
                html += '<td class="vborder" style="text-align:right"></td>';
                html += '<td class="vborder" style="text-align:right">' + (r.AmtTotal ? CCurrency(CDbl(r.AmountCharge * r.ExchangeRate * r.Qty, 2)) : "") + '</td>';
                html += '<td class="vborder" style="text-align:right"></td>';
            } else {
                html += '<td class="vborder" style="text-align:right">' + (r.AmtTotal ? CCurrency(CDbl((r.AmountCharge * r.ExchangeRate * r.Qty) - r.AmtWht, 2)) : "") + '</td>';
                html += '<td class="vborder" style="text-align:right"></td>';
                html += '<td class="vborder" style="text-align:right">' + (r.AmtTotal ? CCurrency(CDbl(r.AmtTotal, 2)) : "") + '</td>';
            }
            html += '</tr>';
            if (r.IsCredit == 0 && r.IsExpense == 0) {
                totalCharge += r.AmtTotal - 0;//cast
                totalGet += (r.AmountCharge * r.Qty * r.ExchangeRate) - r.AmtWht;
                totalBaseCharge += (r.AmountCharge*r.Qty*r.ExchangeRate) - 0;
                totalVatCharge += r.AmtVat - 0;
                totalWhtCharge += r.AmtWht - 0;
            }else  if (r.IsCredit == 1) {
                totalAdvCharge += r.AmtTotal;
            }


            //let amt = CNum(Number(r.AmountCharge) * Number(r.Qty) * Number(r.ExchangeRate));
            //if (r.IsCredit == 0) {
            //    totamt += amt;
            //} else {
            //    totcost += amt;
            //}
            //totvat += CNum(r.AmtVat);
            //totwht += CNum(r.AmtWht);
            //total += amt + CNum(r.AmtVat);
        }
        let sumCharge = "";
        sumCharge += '<tr  style="border-top:1px solid black;border-bottom:1px solid black">';
  /*      sumCharge += '<td class="vborder" style="width:10%"></td>';*/
        sumCharge += '<td class="vborder" style="font-weight:bold"">TOTAL CHARGE</td>';
        sumCharge += '<td class="vborder" style="text-align:center"></td>';
        sumCharge += '<td class="vborder" style="text-align:center"></td>';
        sumCharge += '<td class="vborder" style="text-align:center"></td>';
        sumCharge += '<td class="vborder" style="text-align:center"></td>';
        sumCharge += '<td class="vborder" style="text-align:center"></td>';
        sumCharge += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalBaseCharge, 2)) + '</td>';
        sumCharge += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalVatCharge, 2)) + '</td>';
        sumCharge += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalWhtCharge, 2)) + '</td>';
        sumCharge += '<td class="vborder" style="text-align:right;font-weight:bold"">' + CCurrency(CDbl(totalGet, 2)) + '</td>';

        sumCharge += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalAdvCharge, 2)) + '</td>';
        sumCharge += '<td class="vborder" style="text-align:right"">' + CCurrency(CDbl(totalCharge, 2)) + '</td>';

        sumCharge += '</tr>';
        sumCharge += '<tr><td><br></td></tr>';
        html += sumCharge;
        //html += '<div  style="display:flex;width:100%;border-top:1px solid black"></div>';
        console.log(totalCharge);
        //html += '<div class="border" style="display:flex;width:100%;padding:2px;">Expense</div>';
        for (let r of expense) {
            html2 += '<tr>';
          /*  html2 += '<div class="vborder" style="width:10%;">' + r.SICode + '</div>';*/
            html2 += '<td class="vborder" style="">' + r.SDescription + '</td>';
            html2 += '<td class="vborder" style="width:5%;text-align:center">' + r.ExchangeRate + '</td>';
            html2 += '<td class="vborder" style="width:5%;text-align:center">' + r.CurrencyCode + '</td>';
            html2 += '<td class="vborder" style="width:5%;text-align:center">' + r.Qty + '</td>';
            html2 += '<td class="vborder" style="width:5%;text-align:center">' + r.QtyUnit + '</td>';
            html2 += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsExpense == 1 && r.IsCredit == 0 ? CCurrency(CDbl(r.AmountCharge , 2)) : "") + '</td>';
            html2 += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsExpense == 1 && r.IsCredit == 0 ? CCurrency(CDbl(r.AmountCharge * r.ExchangeRate * r.Qty, 2)):"" )+ '</td>';
            html2 += '<td class="vborder" style="width:10%;text-align:right">' +( r.IsExpense == 1 && r.IsCredit == 0 ? CCurrency(CDbl(r.AmtVat, 2)):"") + '</td>';
            html2 += '<td class="vborder" style="width:10%;text-align:right">' + (r.IsExpense == 1 && r.IsCredit == 0 ?CCurrency(CDbl(r.AmtWht, 2)):"") + '</td>';
            if (r.IsCredit == 1) {
                html2 += '<td class="vborder" style="width:10%;text-align:right"></td>';
                html2 += '<td class="vborder" style="width:10%;text-align:right">' + (r.AmtTotal?CCurrency(CDbl(r.AmtTotal, 2)):"" )+ '</td>';
                html2 += '<td class="vborder" style="width:10%;text-align:right"></td>';
            } else {
                html2 += '<td class="vborder" style="width:10%;text-align:right">' + (r.AmtTotal ? CCurrency(CDbl(r.AmountCharge * r.ExchangeRate * r.Qty, 2)) : "") + '</td>';
                html2 += '<td class="vborder" style="width:10%;text-align:right"></td>';
                html2 += '<td class="vborder" style="text-align:right">' + (r.AmtTotal ? CCurrency(CDbl(r.AmtTotal, 2)) : "") + '</td>';
            }
            html2 += '</tr>';
            if ((r.IsExpense == 1 && r.IsCredit == 0) || r.SICode.indexOf("INT") >= 0) {
                console.log(r.SICode);
                totalCost += r.AmtTotal;//cast
                totalBaseCost += r.AmountCharge*r.Qty*r.ExchangeRate;
                totalVatCost += r.AmtVat;
                totalWhtCost += r.AmtWht;
                totalPay += r.AmountCharge * r.Qty * r.ExchangeRate;
                console.log(totalPay);
            }else if (r.IsCredit == 1) {
                totalAdvCost+= r.AmtTotal;
            }
            //let amt = CNum(Number(r.AmountCharge) * Number(r.Qty) * Number(r.ExchangeRate));
            //if (r.IsCredit == 0) {
            //    totamt += amt;
            //} else {
            //    totcost += amt;
            //}
            //totvat += CNum(r.AmtVat);
            //totwht += CNum(r.AmtWht);
            //total += amt + CNum(r.AmtVat);
        }
        let sumCost = "";
        sumCost += '<tr  style="border-top:1px solid black;border-bottom:1px solid black;">';
 /*       sumCost += '<div class="vborder" style="width:10%"></div>';*/
        sumCost += '<td class="vborder" style="font-weight:bold">TOTAL COST</td>';
        sumCost += '<td class="vborder" style="text-align:center"></td>';
        sumCost += '<td class="vborder" style="text-align:center"></td>';
        sumCost += '<td class="vborder" style="text-align:center"></td>';
        sumCost += '<td class="vborder" style="text-align:center"></td>';
        sumCost += '<td class="vborder" style="text-align:center"></td>';
        sumCost += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalBaseCost, 2)) + '</td>';
        sumCost += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalVatCost, 2)) + '</td>';
        sumCost += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalWhtCost, 2)) + '</td>';

        sumCost += '<td class="vborder" style="text-align:right;font-weight:bold">' + CCurrency(CDbl(totalPay, 2)) + '</td>';
        sumCost += '<td class="vborder" style="text-align:right">'+ CCurrency(CDbl(totalAdvCost, 2)) +'</td>';
        sumCost += '<td class="vborder" style="text-align:right">' + CCurrency(CDbl(totalCost, 2)) + '</td>';
        sumCost += '</tr>';
        html2 += sumCost;
        //html2 += '<div  style="display:flex;width:100%;border-top:1px solid black"></div>';
        console.log(totalCost);

        sumHtml += '<div style="width:85%;text-align:right;font-weight:bold">NET PROFIT:</div>';
        sumHtml += '<div style="width:15%;text-align:right;font-weight:bold">'+ CCurrency(CDbl((totalGet - totalPay),2))+'</div>';

        //for (let r of dt) {
        //    html += '<div style="display:flex;width:100%">';

        //    html += '<div style="width:20%">' + r.SICode + '</div>';
        //    html += '<div style="width:20%">'+ r.SDescription +'</div>';
        //    html += '<div style="width:5%">' + r.ExchangeRate + '</div>';
        //    html += '<div style="width:15%;text-align:center">' + r.CurrencyCode + '</div>';
        //    html += '<div style="width:10%;text-align:center">' + r.Qty + '</div>';
        //    html += '<div style="width:10%;text-align:center">' + r.QtyUnit + '</div>';
        //    if (r.IsCredit==1) {
        //        html += '<div style="width:20%;text-align:right">' + CCurrency(CDbl(r.AmtTotal, 2)) + '</div>';
        //        html += '<div style="width:20%;text-align:right">0.00</div>';
        //    } else {
        //        html += '<div style="width:20%;text-align:right">0.00</div>';
        //        html += '<div style="width:20%;text-align:right">' + CCurrency(CDbl(r.AmtTotal, 2)) + '</div>';
        //    }
        //    html += '</div>';
        //    let amt = CNum(Number(r.AmountCharge) * Number(r.Qty) * Number(r.ExchangeRate));
        //    if (r.IsCredit==0) {
        //        totamt += amt;
        //    } else {
        //        totcost += amt;
        //    }
        //    totvat += CNum(r.AmtVat);
        //    totwht += CNum(r.AmtWht);
        //    total += amt + CNum(r.AmtVat);
        //}
        $('#summary').html(sumHtml);
        $('#dvDetail').html(html);
        $('#dvDetail2').html(html2);
        $('#lblSumCost').text(CCurrency(CDbl(totcost,2)));
        $('#lblSumAmount').text(CCurrency(CDbl(totamt,2)));
        $('#lblSumVat').text(CCurrency(CDbl(totvat, 2)));
        $('#lblSumWht').text(CCurrency(CDbl(totwht, 2)));
        $('#lblSumTotal').text(CCurrency(CDbl(total, 2)));
        $('#lblSumNet').text(CCurrency(CDbl(total-totwht, 2)));
    }



</script>
<style>
    .vborder {
        border-left: 1px solid black;
        border-right: 1px solid black;
        padding: 2px;
    }

    .border {
        border: 1px solid black;
    }

    td div h3 {
        font-size: 20px;
    }

    table {
        border-collapse: collapse;
    }
</style>