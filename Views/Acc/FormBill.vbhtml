
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = "ใบวางบิล (BILLING COVER SHEET)"
    Dim branch = Request.QueryString("branch")
    Dim code = Request.QueryString("bode")
    Dim bSummaryFlag = False
    Dim dt As New System.Data.DataTable
    If (branch & code).Length > 0 Then
        Dim sql = "
select d.SDescription,d.CurrencyCode
,sum(d.Amt) as GrossAmt
,sum(d.AmtVat) as VatAmt
,sum(d.Amt+d.AmtVat) as TotalAmt
,sum(case when d.Rate50Tavi=3 then d.Amt50Tavi else 0 end) as AmtWH3
,sum(case when d.Rate50Tavi=1 then d.Amt50Tavi else 0 end) as AmtWH1
,sum(d.TotalAmt) as NetAmt
from Job_InvoiceDetail d
inner join Job_InvoiceHeader h
on d.BranchCode=h.BranchCode
and d.DocNo=h.DocNo
where h.BranchCode='{0}' AND h.BillAcceptNo='{1}'
group by d.SDescription,d.CurrencyCode
"
        dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sql, branch, code))
        If dt.Rows.Count > 0 Then
            bSummaryFlag = True
        End If
    End If
End Code
<style>
    * {
        font-size: 12px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter {
        display: none;
    }
</style>
<div style="display:flex;">
    <div style="flex:1;" class="text-left">
        <p>
            TAX-ID : <label id="lblTaxNumber"></label>
        </p>
    </div>
    <div style="flex:1;text-align:right">
        DOC NO : <label id="lblBillAcceptNo"></label>
        <br />DATE : <label id="lblBillDate"></label>
    </div>
</div>
<div style="display:flex;">
    <div class="text-left">
        <p>
            NAME : <label id="lblCustName"></label>
        </p>
    </div>
</div>
<div style="display:flex;flex-direction:column">
    <div style="flex:1" class="text-left">
        <label id="lblCustAddress"></label>
    </div>
    <div style="flex:1" class="text-left">
        <br />
        PLEASE APPROVE BEFORE PAYMENT
    </div>
</div>
<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
    <thead>
        <tr>
            <th class="text-center" width="50" rowspan="2">NO</th>
            <th class="text-center" width="100" rowspan="2">ISSUE DATE</th>
            <th class="text-center" width="130" rowspan="2">INVOICE NO.</th>
            <th class="text-center" width="130" rowspan="2">CUST INV..</th>
            @*<th class="text-center" width="130" rowspan="2">JOB NO.</th>*@
            <th class="text-center" colspan="3">AMOUNT</th>
            <th class="text-center" width="60" rowspan="2">VAT</th>
            <th class="text-center" colspan="2">W/H</th>
            <th class="text-center" width="80" rowspan="2">TOTAL AMOUNT</th>
            <th class="text-center" width="80" rowspan="2">PREPAID</th>
            <th class="text-center" width="100" rowspan="2">NET</th>
        </tr>
        <tr>
            <th class="text-center" width="50">ADVANCE</th>
            <th class="text-center" width="40">NONVAT</th>
            <th class="text-center" width="40">SERVICE</th>
            <th class="text-center" width="50">1%</th>
            <th class="text-center" width="50">3%</th>
        </tr>
    </thead>
    <tbody id="tbDetail">
    </tbody>
    <tfoot>
        <tr>
            <td style="text-align:right" colspan="4">TOTAL</td>
            <td style="text-align:right"><label id="lblSumAdv"></label></td>
            <td style="text-align:right"><label id="lblSumNonvat"></label></td>
            <td style="text-align:right"><label id="lblSumService"></label></td>
            <td style="text-align:right"><label id="lblSumVat"></label></td>
            <td style="text-align:right"><label id="lblSumWh1"></label></td>
            <td style="text-align:right"><label id="lblSumWh3"></label></td>
            <td style="text-align:right"><label id="lblSumAmount"></label></td>
            <td style="text-align:right"><label id="lblSumPrepaid"></label></td>
            <td style="text-align:right"><label id="lblBillTotal"></label></td>
        </tr>
        <tr style="background-color:lightblue">
            <th class="text-center" colspan="13"><label id="lblBillTotalEng"></label></th>
        </tr>
    </tfoot>
</table>
@If bSummaryFlag Then
    Dim sumGross = 0
    Dim sumVat = 0
    Dim sumTotal = 0
    Dim sumWh1 = 0
    Dim sumWh3 = 0
    Dim sumNet = 0
    @<b>INVOICE DETAILS:</b>
    @<table border="1" style="border-style:solid;width:100%;margin-top:5px ">
        <thead>
            <tr>
                <th>DESCRIPTION</th>
                <th>CURRENCY</th>
                <th>GROSS AMT</th>
                <th>VAT</th>
                <th>TOTAL AMT</th>
                <th>WHD 3%</th>
                <th>WHD 1%</th>
                <th>NET AMT</th>
            </tr>
        </thead>
        <tbody>
            @For each dr As System.Data.DataRow In dt.Rows
                sumGross += Convert.ToDouble(dr("GrossAmt"))
                sumVat += Convert.ToDouble(dr("VatAmt"))
                sumTotal += Convert.ToDouble(dr("TotalAmt"))
                sumWh1 += Convert.ToDouble(dr("AmtWH1"))
                sumWh3 += Convert.ToDouble(dr("AmtWH3"))
                sumNet += Convert.ToDouble(dr("NetAmt"))
                @<tr>
    <td>@dr("SDescription")</td>
    <td style="text-align:center">
        @dr("CurrencyCode")
    </td>
    <td style="text-align:right">
        @dr("GrossAmt").ToString("#,##0.00")
    </td>
    <td style="text-align:right">
        @dr("GrossAmt").ToString("#,##0.00")
    </td>
    <td style="text-align:right">
        @dr("VatAmt").ToString("#,##0.00")
    </td>
    <td style="text-align:right">
        @dr("TotalAmt").ToString("#,##0.00")
    </td>
    <td style="text-align:right">
        @dr("AmtWH3").ToString("#,##0.00")
    </td>
    <td style="text-align:right">
        @dr("AmtWH1").ToString("#,##0.00")
    </td>
    <td style="text-align:right">
        @dr("NetAmt").ToString("#,##0.00")
    </td>
</tr>
            Next
        </tbody>
    <tfoot>
        <tr>
            <td>TOTAL</td>
            <td></td>
            <td style="text-align:right;">
                @sumGross.ToString("#,##0.00")
            </td>
            <td style="text-align:right;">
                @sumVat.ToString("#,##0.00")
            </td>
            <td style="text-align:right;">
                @sumTotal.ToString("#,##0.00")
            </td>
            <td style="text-align:right;">
                @sumWh3.ToString("#,##0.00")
            </td>
            <td style="text-align:right;">
                @sumWh1.ToString("#,##0.00")
            </td>
            <td style="text-align:right;">
                @sumNet.ToString("#,##0.00")
            </td>
        </tr>
    </tfoot>
    </table>
End If
<div style="margin-top:60px">
    <p>PAYMENT DUE DATE : <label id="lblPaymentDueDate"></label></p>
    <p>PLEASE PAY CHEQUE IN NAME @ViewBag.PROFILE_COMPANY_NAME_EN</p>
    <p>PAYMENT SHOULD BE PAID BY CROSS CHEQUE IN FAVOR OF  @ViewBag.PROFILE_COMPANY_NAME</p>
    <p>SIGN ON RECEIVER AND ASSIGNED PAYMENT DATE AND SEND THIS PAPER TO @ViewBag.PROFILE_COMPANY_NAME FAX. @ViewBag.PROFILE_COMPANY_FAX</p>
</div>

<div style="display:flex">
    <div style="flex:1;border:1px solid black ;border-radius:5px;text-align:center">
        FOR THE CUSTOMER<br />
        <br /><br /><br /><br />
        __________________________________________<br />
        .........................................<br />
        _____/______/______
    </div>
    <div style="flex:1;border:1px solid black ;border-radius:5px;text-align:center">
        FOR @ViewBag.PROFILE_COMPANY_NAME<br />
        <br /><br /><br /><br />
        __________________________________________<br />
        .........................................<br />
        _____/______/______
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    $("#dvCompLogo").html($("#dvCompLogo").html()+'<div id="dvCopy" style="flex:20;vertical-align:center"></div>');
  let ans = confirm('OK to print Original or Cancel For Copy');
        if (ans == true) {
            $('#dvCopy').html('<b style="font-size:30px">ORIGINAL</b>');
        } else {
            $('#dvCopy').html('<b style="font-size:30px">COPY</b>');
        }
    let branch = getQueryString('branch');
    let billno = getQueryString('code');
    $.get(path + 'acc/getbilling?branch=' + branch + '&code=' + billno, function (r) {
        if (r.billing.header !== null) {
            ShowData(r.billing);
        }
    });
    function ShowData(data) {
        if (data.header.length > 0) {
            $('#lblBillAcceptNo').text(data.header[0][0].BillAcceptNo);
            $('#lblBillDate').text(ShowDate(CDateTH(data.header[0][0].BillDate)));
            $('#lblPaymentDueDate').text(ShowDate(CDateTH(data.header[0][0].DuePaymentDate)));
        }
        if (data.customer.length > 0) {

            $('#lblTaxNumber').text(data.customer[0][0].TaxNumber);
            if (data.customer[0][0].UsedLanguage == 'TH') {
if(Number(data.customer[0][0].Branch)>0) {
        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :' + data.customer[0][0].CustBranch);
} else {
        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :สำนักงานใหญ่');
}
                $('#lblCustName').text(data.customer[0][0].NameThai);
                $('#lblCustAddress').text(data.customer[0][0].TAddress1 + '\n' + data.customer[0][0].TAddress2);
            } else {
if(Number(data.customer[0][0].Branch)>0) {
        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :' + data.customer[0][0].CustBranch);
} else {
        $('#lblTaxNumber').text(data.customer[0][0].TaxNumber + ' BRANCH :HEAD OFFICE');
}
                $('#lblCustName').text(data.customer[0][0].NameEng);
                $('#lblCustAddress').text(data.customer[0][0].EAddress1 + '\n' + data.customer[0][0].EAddress2);
            }
        }
        if (data.detail.length > 0) {
            let total = 0;
            let serv = 0;
            let nonvat = 0;
            let adv = 0;
            let vat = 0;
            let wh1 = 0;
            let wh3 = 0;
	    let sumAmount = 0 ;
            let prepaid = 0;
            let dv = $('#tbDetail');
            let html = '';
            let dtl=data.detail[0];
sortData(dtl,'ItemNo','asc');
            for (let dr of dtl) {
                html += '<tr>';
                html += '<td>' + dr.ItemNo + '</td>';
                html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td>' + dr.InvNo + '</td>';
              /*  html += '<td>' + dr.RefNo + '</td>';*/
                html += '<td>' + dr.CustInv + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(Number(dr.AmtChargeNonVAT), 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(Number(dr.AmtChargeVAT), 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtVAT, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH1, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.AmtWH3, 2) + '</td>';
                /*html += '<td style="text-align:right">' + ShowNumber(dr.TotalNet-dr.AmtVAT+dr.AmtWH1+dr.AmtWH3, 2) + '</td>';*/
                html += '<td style="text-align:right">' + ShowNumber(dr.TotalNet+dr.AmtWH1+dr.AmtWH3, 2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(dr.TotalCustAdv, 2) + '</td>';
		html += '<td style="text-align:right">' + ShowNumber(dr.TotalNet, 2) + '</td>';
                html += '</tr>';

                total += Number(dr.TotalNet);
                serv += Number(dr.AmtChargeVAT);
                nonvat += Number(dr.AmtChargeNonVAT);
                adv += Number(dr.AmtAdvance);
                vat += Number(dr.AmtVAT);
                prepaid += Number(dr.TotalCustAdv);
                wh1 += Number(ShowNumber(dr.AmtWH1, 2));
                wh3 += Number(ShowNumber(dr.AmtWH3, 2));
                //sumAmount += dr.TotalNet-dr.AmtVAT+dr.AmtWH1+dr.AmtWH3;
		sumAmount += dr.TotalNet+dr.AmtWH1+dr.AmtWH3;
            }
            dv.html(html);
            $('#lblSumAdv').text(ShowNumber(adv, 2));
            $('#lblSumNonvat').text(ShowNumber(nonvat, 2));
            $('#lblSumService').text(ShowNumber(serv, 2));
            $('#lblSumVat').text(ShowNumber(vat, 2));
            $('#lblSumWh1').text(ShowNumber(wh1, 2));
            $('#lblSumWh3').text(ShowNumber(wh3, 2));
 	    $('#lblSumAmount').text(ShowNumber(sumAmount , 2));
            $('#lblSumPrepaid').text(ShowNumber(prepaid , 2));
            $('#lblBillTotal').text(ShowNumber(total,2));
            $('#lblBillTotalEng').text(CNumEng(total.toFixed(2)));
        }
    }
</script>