@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "PRE-INVOICE"
    ViewBag.ReportName = "PRE-INVOICE"
End Code
<table style="width:100%">
    <tbody>
        <tr>
            <td style="width:15%" >CODE</td>
            <td>:</td>
            <td style="width:55%" id="lblCustCode"></td>

            <td style="width:15%">PRE INVOICE NO.</td>
            <td>:</td>
            <td  style="width:15%" id="lblDocNo"></td>
        </tr>
        <tr>
            <td>INVOICE TO</td>
            <td>:</td>
            <td id="lblCustName"></td>

            <td>INV. DATE</td>
            <td>:</td>
            <td id="lblInvDate">@DateTime.Now.ToString("dd/MM/yyyy")</td>
        </tr>
        <tr>
            <td style="vertical-align:top">ADDRESS</td>
            <td style="vertical-align:top">:</td>
            <td style="vertical-align:top">
                <label id="lblCustAddress1"></label>
            </td>
            <td>JOB NO.</td>
            <td>:</td>
            <td id="lblJNo"></td>
        </tr>
        <tr>
 	    <td></td>
            <td></td>
            <td>TAX ID :<label id="lblCustTaxID"></label></td>

            <td>TYPE</td>
            <td>:</td>
            <td id=""><label id="lblJobType"></label>-<label id="lblShipby"></label></td>
        </tr>
        <tr>
           <td></td>
            <td></td>
            <td>BRANCH: Head Office</td>

            <td>CREDIT TERM</td>
            <td>:</td>
            <td>CASH</td>
        </tr>
        <tr>
            
        </tr>
        
    </tbody>
</table>
<table style="width:100%">
    <tbody>
	<tr>
            <td style="width:15%">COMMODITY</td>
            <td>:</td>
            <td style="width:55%" id="lblInvProduct"></td>


        </tr>
        <tr>
            <td style="width:15%">ORIGIN / DEST.</td>
            <td >:</td>
            <td style="width:55%" id="lblCountryPort"></td>

            <td style="width:5%">ETD</td>
            <td>:</td>
            <td  style="width:15%" id="lblETDDate"></td>

            <td>ETA</td>
            <td>:</td>
            <td id="lblETADate"></td>
        </tr>
        <tr>
            <td>FEEDER</td>
            <td>:</td>
            <td id="lblMVesselName"></td>

            <td>QUANTITY</td>
            <td>:</td>
            <td></td>

            <td>VOLUME</td>
            <td>:</td>
            <td id="lblMeasurement"></td>
        </tr>

        <tr>
            <td>VESSEL</td>
            <td>:</td>
            <td id="lblVesselName"></td>

            <td>WEIGHT</td>
            <td>:</td>
            <td id="lblGrossWeight"></td>
        </tr>

        <tr>
            <td>B/L NO.</td>
            <td>:</td>
            <td id="lblBLStatus"></td>

            <td>OBL NO.</td>
            <td>:</td>
            <td></td>
        </tr>

        <tr>
            <td>CONTAINER NO.</td>
            <td>:</td>
            <td></td>
        </tr>

        <tr>
            <td colspan="3">SHIPPER</td>
            <td colspan="3">CONSIGNEE</td>
        </tr>

        <tr>
            <td colspan="3"></td>
            <td colspan="3"></td>
        </tr>
    </tbody>

</table>
<!--<div style="float:right">
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
    </div>-->
    @*<div style="flex:1">
            <b>QUANTITY :</b><label id="lblInvQty"></label> &nbsp; <label id="lblInvQtyUnit"></label>
        </div>*@
    <!--<div style="flex:1">
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
</div>-->
@*<hr style="border-style:solid;" />*@
<br />
<table style="width:100%;border-collapse:collapse"> 
      <thead>
          <tr >
              <th style="border-top:1px black solid;border-bottom:1px black solid;">DESCRIPTION</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">RATE</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">CURR</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">QTY</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">UNIT</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">EXCH</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">ADVANCE</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">NON VAT</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">VAT 7</th>
              <th style="border-top:1px black solid;border-bottom:1px black solid;">WHT</th>
          </tr>
      </thead>
      <tbody id="tbDetail">

      </tbody>
      <tbody>
        
      </tbody>
</table>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<div style="width:100%;display:flex">
    <div style="flex:1">
        <div style="width:100%;border-bottom:1px black solid;text-align:center"></div>
        <div style="text-align:center">ผู้จัดทำ / ()</div>
    </div>
    <div style="flex:1"></div>
    <div style="flex:1">
        <div style="width:100%;border-bottom:1px black solid;text-align:center"></div>
        <div style="text-align:center">นัดรับเช็ค / วันที่  ()</div>
    </div>


    <div style="flex:1"></div>
    <div style="flex:1">
        <div style="width:100%;border-bottom:1px black solid;text-align:center"></div>
        <div style="text-align:center">Authorized Signature</div>
    </div>
</div>
<br>
<div  style="font-weight:bold">
                  "หากชำระเกินกำหนด ทางบริษัทจะคิดดอกเบีี้ยในอัตราร้อยละ 15% ต่อปี  จากยอดตามใบแจ้งหนี้ นับตั้งแต่วันที่ครบกำหนดตามใบแจ้งหนี้"<br />
       Please issue a cross cheque payable to "LEO GLOBAL LOGISTICS PUBLIC COMPANY LIMITED" Only
</div>
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

        ShowJobTypeShipBy(path, dr.JobType, dr.ShipBy, dr.JobStatus, '#lblJobType', '#lblShipby', '#txtJobStatus');

        $('#lblJobType').text(dr.JobType);
        $('#lblJNo').text(dr.JNo);
	$('#lblDocNo').text(dr.QNo);
        $('#lblETDDate').text(ShowDate(dr.ETDDate));
        $('#lblETADate').text(ShowDate(dr.ETADate));
        $('#lblVesselName').text(dr.VesselName);
        $('#lblMVesselName').text(dr.MVesselName);
        $('#lblCustInv').text(dr.InvNo);
        $('#lblInvProduct').text(dr.InvProduct);

        
      /*  $('#lblInvQty').text(dr.InvProductQty);*/
        ShowCountry(path, dr.InvCountry, '#lblCountryPort');
        /*  ShowInvUnit(path, dr.InvProductUnit, '#lblInvQtyUnit');*/
        $('#lblTotalContainer').text(dr.TotalContainer);
        $('#lblMeasurement').text(dr.Measurement);
        $('#lblBLStatus').text(dr.BookingNo);
        $('#lblGrossWeight').text(dr.TotalGW + ' ' + dr.GWUnit);
        $('#lblDeliveryTo').text(dr.ClearPortNo);

        CallBackQueryCustomer(path, dr.CustCode, dr.CustBranch, function (data) {
            console.log(data);
            $('#lblCustName').text(data.NameEng);
            $('#lblCustAddress1').text(data.EAddress1 + ' '+data.EAddress2);
            $('#lblCustTaxID').text(data.TaxNumber);
            $('#lblCustCode').text(data.CustCode);
            
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
        let totalNonVat = 0;
        let totalSrvVat = 0;

        let sumWht1 = 0;
        let sumbaseWht1 = 0;
        let sumWht1_5 = 0;
        let sumbaseWht1_5 = 0;
        let sumWht3 = 0;
        let sumbaseWht3 = 0;
        
        
        let sumHtml = "";
        let expense = dt.filter((obj) => (obj.IsExpense == 1 && obj.IsCredit == 0) || (obj.IsCredit == 1 && obj.IsExpense == 0 ));
        console.log(expense);

        let income = dt.filter((obj) => (obj.IsCredit == 0 && obj.IsExpense == 0) || (obj.IsCredit == 1 && obj.IsExpense == 0));
        console.log(income);

   
        for (let r of income) {
            if (r.IsCredit == 0 && r.IsExpense == 0) {
                totalCharge += r.AmountCharge - 0;//cast
                if (r.AmtVat) {
                    totalSrvVat += r.AmountCharge;
                } else {
                    totalNonVat += r.AmountCharge;
                }
                totalBaseCharge += r.AmountCharge - 0;
                totalVatCharge += r.AmtVat - 0;
                totalWhtCharge += r.AmtWht - 0;
            }else  if (r.IsCredit == 1) {
                totalAdvCharge += r.AmtTotal;
            }
            switch (r.AmtWhtRate) {
                case 1:
                    sumWht1 += r.AmtWht;
                    sumbaseWht1 += r.AmountCharge;
                    break;
                case 1.5:
                    sumWht1_5 += r.AmtWht;
                    sumbaseWht1_5 += r.AmountCharge;
                    break;
                case 3:
                    sumWht3 += r.AmtWht;
                    sumbaseWht3 += r.AmountCharge;
                    break;
                default:
                    break;
            }
            html += '<tr>';
            html += '<td>' + r.SDescription + '</td>';
            html += '<td style="text-align:right">' + CCurrency(CDbl(r.AmountCharge,2))  + '</td>';
            html += '<td style="text-align:center">' + r.CurrencyCode + '</td>';
            html += '<td style="text-align:center">' + r.Qty + '</td>';
            html += '<td style="text-align:center">' + r.QtyUnit + '</td>'; 
            html += '<td style="text-align:center">' + r.ExchangeRate + '</td>';
            html += '<td style="text-align:right">' + (r.IsCredit == 1 && r.IsExpense == 0 ? CCurrency(CDbl(r.AmountCharge * r.Qty , 2)) : 0) + '</td>';
            html += '<td style="text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 1 ? CCurrency(CDbl(r.AmountCharge * r.Qty, 2)) : 0) + '</td>';
            html += '<td style="text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 0 ? CCurrency(CDbl(r.AmountCharge * r.Qty, 2)) : 0) + '</td>';
            html += '<td style="text-align:right">' + (r.IsCredit == 0 && r.IsExpense == 0 ? CCurrency(CDbl(r.AmtWhtRate, 2)) : 0) + '</td>';
            html += '</tr>';
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
        sumCharge += '<tr>';
        sumCharge += '<td class="" style="border-top:1px black solid">(ผิด ตก ยกเว้น O.E.)</td>';
        sumCharge += '<td colspan="5" style="border-top:1px black solid;text-align:right">AMOUNT</td>';
        sumCharge += '<td class="" style="border-top:1px black solid;text-align:right">'+ CCurrency(CDbl(totalAdvCharge, 2)) +'</td>';
        sumCharge += '<td class="" style="border-top:1px black solid;text-align:right">' + CCurrency(CDbl(totalNonVat, 2)) +'</td>';
        sumCharge += '<td class="" style="border-top:1px black solid;text-align:right">' + CCurrency(CDbl(totalSrvVat, 2)) +'</td>';
        sumCharge += '<td class="" style="border-top:1px black solid"></td>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td colspan="5" style="text-align:right">SUB TOTAL</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style="text-align:right">' + CCurrency(CDbl(totalCharge, 2)) + '</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td colspan="5" style="text-align:right">VALUE ADD TAX 7 %</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style="text-align:right">' + CCurrency(CDbl(totalVatCharge, 2)) + '</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td colspan="5" style="text-align:right;font-weight:bold">TOTAL</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style="text-align:right;font-weight:bold">' + CCurrency(CDbl(totalCharge+totalVatCharge, 2)) + '</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td colspan="5" style="text-align:right">WHT</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style="text-align:right;border-bottom:1px black solid">' + CCurrency(CDbl(totalWhtCharge, 2)) + '</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td colspan="5" style="text-align:right;font-weight:bold">GRAND TOTAL</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '<td class="" style="text-align:right;border-bottom:1px black double;font-weight:bold">' + CCurrency(CDbl(totalCharge +totalVatCharge-totalWhtCharge, 2)) + '</td>';
        sumCharge += '<td class="" style=""></td>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style="" colspan="10">(' + CNumEng(CDbl(totalCharge + totalVatCharge - totalWhtCharge,2))+')</td>';
        sumCharge += '</tr>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style="" colspan="10">หัก ณ ที่จ่าย 1.00% จำนวนเงิน ' + CNumEng(CDbl(sumbaseWht1, 2)) + ' = ' + CNumEng(CDbl(sumWht1, 2))+')</td>';
        sumCharge += '</tr>';
        sumCharge += '</tr>';
        sumCharge += '<tr>';
        sumCharge += '<td class="" style="" colspan="10">หัก ณ ที่จ่าย 3.00% จำนวนเงิน ' + CNumEng(CDbl(sumbaseWht3, 2)) + ' = ' + CNumEng(CDbl(sumWht3, 2)) + ')</td>';
        sumCharge += '</tr>';

        html += sumCharge;
    
        console.log(totalCharge);

        $('#summary').html(sumHtml);
        $('#tbDetail').html(html);
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
</style>