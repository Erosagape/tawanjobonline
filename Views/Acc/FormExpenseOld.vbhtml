@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "PAYABLE VOUCHER"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-size: 11px;
    }

    .table{
        width:100%;
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

    .table td, .table th {
        border-top: 0px none;
        padding: 0.3rem;
    }

    .table-bordered td, .table-bordered th {
        border: 1px solid black;
    }

    .table thead th {
        border-color: black;
        border-width: 1px;
        padding: 0.5em;
    }

    .table-borderless td, .table-borderless th {
        border: 0px none;
    }

    .underLine {
        border-bottom: 1px solid black !important;
    }

    .noUnderLine {
        border-bottom: 0px none !important;
    }

    .noUpperLine {
        border-top: 0px none !important;
    }

    .sideLine {
        border-left: 1px solid black;
        border-right: 1px solid black;
    }
</style>
<table class="table">
    <thead></thead>
    <tbody>
        <tr>
            <td colspan="2" class="bold">
                <label id="billToLbl">BILL TO NAME AND ADDRESS</label>
            </td>
            <td class="right">
                <label id="id"></label>
            </td>
            <td>
                <label id="voucherLbl" class="bold">A/P NO:</label>
            </td>
            <td>
                <label id="voucherNo"></label>
            </td>
        </tr>
        <tr>
            <td id="billTo" rowspan="4" colspan="3" style="vertical-align:top">
                <label id="billName"></label>
                <div id="billAddress"></div>
            </td>
            <td>
                <label id="voucherDateLbl" class="bold">CREATE DATE:</label>
            </td>
            <td>
                <label id="voucherDate"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="dueDateLbl" class="bold">DUE DATE:</label>
            </td>
            <td>
                <label id="dueDate"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="creditTermLbl" class="bold">CREDIT TERM:</label>
            </td>
            <td>
                <label id="creditTerm"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="currencyLbl" class="bold">CURRENCY:</label>
            </td>
            <td>
                <label id="currency"></label>
            </td>
        </tr>
        <tr>
            <td>
                <label id="jobNoLbl" class="bold">JOB NO</label>
            </td>
            <td>:</td>
            <td>
                <label id="jobNo" class=""></label>
            </td>
            <td>
                <label id="masterBLNoLbl" class="bold">MASTER B/L NO.</label>
            </td>
            <td>
                <label id="masterBLNo">:</label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="feederLbl" class="bold">FEEDER/VOYAGE</label>
            </td>
            <td>:</td>
            <td>
                <label id="feeder" class=""></label>
            </td>
            <td>
                <label id="houseBLNoLbl" class="bold">HOUSE B/L NO.</label>
            </td>
            <td>
                <label id="houseBLNo"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="vesselLbl" class="bold">VESSEL/VOYAGE</label>
            </td>
            <td>:</td>
            <td>
                <label id="vessel" class=""></label>
            </td>
            <td>
                <label id="newHBLNoLbl" class="bold">NEW HB/L NO.</label>
            </td>
            <td>
                <label id="newHBLNo"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="shipperNameLbl" class="bold">SHIPPER NAME</label>
            </td>
            <td>:</td>
            <td>
                <label id="shipperName" class=""></label>
            </td>
            <td>
                <label id="etdLbl" class="bold">ETD : </label>
                <label id="etd"></label>
            </td>
            <td>
                <label id="etaLbl" class="bold">ETA : </label>
                <label id="eta"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="consigneeNameLbl" class="bold">CONSIGNEE NAME</label>
            </td>
            <td>:</td>
            <td>
                <label id="consigneeName" class=""></label>
            </td>
            <td>
                <label id="originalLbl" class="bold">ORIGINAL</label>
            </td>
            <td>
                <label id="original"></label>
            </td>
        </tr>
        <tr>
            <td class="">
                <label id="carrierLbl" class="bold">CARRIER</label>
            </td>
            <td>:</td>
            <td>
                <label id="carrier" class=""></label>
            </td>
        </tr>
    </tbody>
</table>
<table class="table" border="1" style="border-width:thin;border-collapse:collapse;width:100%;">
    <thead>
        <tr>
            <th class="align-top" rowspan="2">DESCRIPTION</th>
            <th class="center align-top" rowspan="2">QTYs</th>
            <th class="center align-top" rowspan="2">UOM</th>
            <th class="center" colspan="4">IN SOURCE CURRENCY</th>
            <th class="center" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr>
            <th class="center">CURR.</th>
            <th class="center">@@ UNIT</th>
            <th class="center">AMOUNT</th>
            <th class="center">EXC.</th>
            <th class="center">ADVANCE</th>
            <th class="center">NO VAT</th>
            <th class="center">VAT</th>
        </tr>
    </thead>
    <tbody id="details">
    </tbody>
    <tr>
        <td rowspan="5" colspan="3">
            <table class="table table-borderless">
                <thead>
                    <tr class="underLine">
                        <th>WHT</th>
                        <th class="center">Gross Amt.</th>
                        <th class="center">Tax Amt.</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <label id="wht1">1%</label>
                        </td>
                        <td class="right">
                            <label id="gross1"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt1"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="wht1_5">1.5%</label>
                        </td>
                        <td class="right">
                            <label id="gross1_5"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt1_5"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="wht3">3%</label>
                        </td>
                        <td class="right">
                            <label id="gross3"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt3"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="wht10">10%</label>
                        </td>
                        <td class="right">
                            <label id="gross10"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmt10"></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="whtOthers">Others</label>
                        </td>
                        <td class="right">
                            <label id="grossOthers"></label>
                        </td>
                        <td class="right">
                            <label id="taxAmtOthers"></label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
        <td id="totalVatExclusiveAmountLbl" class="bold" colspan="4">TOTAL VAT EXCLUSIVE AMOUNT</td>
        <td id="advanceVatExclusiveAmount" class="right bold"></td>
        <td id="noVatVatExclusiveAmount" class="right bold"></td>
        <td id="vatVatExclusiveAmount" class="right bold"></td>

    </tr>
    <tr>
        <td id="totalVatAmountLbl" class="bold" colspan="4">TOTAL VAT AMOUNT</td>
        <td class="right"></td>
        <td class="right"></td>
        <td id="totalVatAmount" class="right bold"></td>
    </tr>
    <tr>
        <td id="totalVatInclusiveAmountLbl" class="bold" colspan="4">TOTAL VAT INCLUSIVE AMOUNT</td>
        <td id="totalVatInclusiveAmount" class="right bold" colspan="3"></td>
    </tr>
    <tr>
        <td id="lessWTLbl" class="bold" colspan="4">LESS W/T</td>
        <td id="lessWT" class="right bold" colspan="3"></td>
    </tr>
    <tr>
        <td id="netPaymentLbl" class="bold" colspan="4">NET PAYMENT</td>
        <td id="netPayment" class="right bold" colspan="3"></td>
    </tr>
</table>
<table class="table table-bordered" >
    <tr>
        <td class="center bold" style="height: 100px; vertical-align: top">
            PREPARED BY:
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
        <td class="center bold" style="height: 100px; vertical-align: top">
            APPROVED BY:
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
        <td class="center bold" style="height: 100px; vertical-align: top">
            RECEIVED BY:
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
        <td class="center bold" style="height: 100px; vertical-align: top">
            ACCOUNTANT:
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <div class="row" style="border-bottom:1px solid black;margin: 5px;"></div>
        </td>
    </tr>
</table>
<br/><b>REMARKS:</b>
<span id="remark"></span>
<script src="~/Scripts/Func/reports.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const branchcode = getQueryString("BranchCode");
    const id = getQueryString("DocNo");
    if (branchcode !== '' && id !== '') {
        let url = 'Acc/GetPaymentGrid?Branch=' + branchcode;
        if (id !== '') {
            url += '&Code=' + id;
        }
        $.get(path + url).done(function (r) {
            if (r.payment.data.length > 0) {
                let h = r.payment.data[0];
                $("#voucherNo").text(h.DocNo);
                $("#voucherDate").text(ShowDate(h.DocDate));
                $("#jobNo").text(h.ForJNo);
                $("#remark").html(CStr(h.Remark));      
                $("#totalVatAmount").text(ShowNumber(h.TotalVAT, 2));
                $("#lessWT").text(ShowNumber(h.TotalTax, 2));
                $("#netPayment").text(ShowNumber(h.TotalNet, 2));
                LoadJob(h.BranchCode, h.ForJNo, h);
                let d = r.payment.data;
                let sumAdv = 0;
                let sumNoVat = 0;
                let sumVat = 0;

                let sumbaseWht1 = 0
                let sumbaseWht1_5 = 0
                let sumbaseWht3 = 0
                let sumbaseWht10 = 0
                let sumbaseWhtother = 0

                let sumWht1 = 0
                let sumWht1_5 = 0
                let sumWht3 = 0
                let sumWht10 = 0
                let sumWhtother = 0
                let html = '';
                let totalRows = 20;
                let blankRows = totalRows - d.length;
                
                for (let row of d) {
                    html += '<tr>';
                    html += '<td class="">'+ row.SDescription +'</td>';
                    html += '<td class="right">'+row.Qty+'</td>';
                    html += '<td class="center">'+row.QtyUnit+'</td>';
                    html += '<td class="center">' + row.CurrencyCode + '</td>';
                    html += '<td class="right">' + ShowNumber(row.UnitPrice,2) + '</td>';
                    html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                    html += '<td class="right">' + row.ExchangeRate + '</td>';
                    let code = row.SICode;
                    if (code.indexOf('ADV') >= 0) {
                        html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                        html += '<td class="right"></td>';
                        html += '<td class="right"></td>';
                        sumAdv += row.Amt;
                    } else {
                        html += '<td class="right"></td>';
                        if (row.AmtVAT > 0) {
                            html += '<td class="right"></td>';
                            html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                            sumVat += row.Amt;
                        } else {
                            html += '<td class="right">' + ShowNumber(row.Amt, 2) + '</td>';
                            html += '<td class="right"></td>';
                            sumNoVat += row.Amt;
                        }
                    }
                    html += '</tr>';
                    let rateCal = 0;
                    if (row.AmtWHT > 0) {
                        if (((row.AmtWHT * 100) / 1) == row.Amt)
                        {
                            rateCal = 1;
                            sumbaseWht1 += row.Amt;
                            sumWht1 += row.AmtWHT;
                        }

                        if (((row.AmtWHT * 100) / 1.5) == row.Amt) {
                            rateCal = 1.5;
                            sumbaseWht1_5 += row.Amt;
                            sumWht1_5 += row.AmtWHT;
                        }
                        if (((row.AmtWHT * 100) / 3) == row.Amt)
                        {
                            rateCal = 3;
                            sumbaseWht3 += row.Amt;
                            sumWht3 += row.AmtWHT;
                        }
                        if (((row.AmtWHT * 100) / 10) == row.Amt)
                        {
                            rateCal = 10;
                            sumbaseWht10 += row.Amt;
                            sumWht10 += row.AmtWHT;
                        }
                        if (rateCal == 0) {
                            rateCal = (row.AmtWHT * 100) / row.Amt;
                            sumbaseWhtother += row.Amt;
                            sumWhtother += row.AmtWHT;
                        }
                        switch (rateCal) {
                            case 0:
                                break;
                            case 1:
                                $('#gross1').text(ShowNumber(sumbaseWht1,2));
                                $('#taxAmt1').text(ShowNumber(sumWht1, 2));
                                break;
                            case 1.5:
                                $('#gross1_5').text(ShowNumber(sumbaseWht1_5, 2));
                                $('#taxAmt1_5').text(ShowNumber(sumWht1_5, 2));
                                break;
                            case 3:
                                $('#gross3').text(ShowNumber(sumbaseWht3, 2));
                                $('#taxAmt3').text(ShowNumber(sumWht3, 2));
                                break;
                            case 10:
                                $('#gross10').text(ShowNumber(sumbaseWht10, 2));
                                $('#taxAmt10').text(ShowNumber(sumWht10, 2));
                                break;
                            default:
                                $('#grossOthers').text(ShowNumber(sumbaseWhtother, 2));
                                $('#taxAmtOthers').text(ShowNumber(sumWhtother, 2));
                                break;
                        }
                    }
                }
                for (let i = 1; i <= blankRows; i++) {
                    html += '<tr>';
                    html += '<td class=""><br/></td>';
                    html += '<td class="right"></td>';
                    html += '<td class="center"></td>';
                    html += '<td class="center"></td>';
                    html += '<td class="right"></td>';
                    html += '<td class="right"></td>';
                    html += '<td class="right"></td>';
                    html += '<td class="right"></td>';
                    html += '<td class="right"></td>';
                    html += '<td class="right"></td>';
                }
                $('#details').html(html);
                $("#advanceVatExclusiveAmount").text(ShowNumber(sumAdv,2));
                $("#noVatVatExclusiveAmount").text(ShowNumber(sumNoVat, 2));
                $("#vatVatExclusiveAmount").text(ShowNumber(sumVat, 2));
                $("#totalVatInclusiveAmount").text(ShowNumber(sumVat + h.TotalVAT, 2));
            }
        });
    }
    function LoadJob(branch, job, header) {
        $.get(path + 'JobOrder/getjobsql?Branch=' + branch + '&JNo=' + job).done(function (r) {
            if (r.job.data.length > 0) {
                let j = r.job.data[0];
                $("#id").text(j.CustCode);
                $("#masterBLNo").text(j.MAWB);
                $("#feeder").text(j.MVesselName);
                $("#houseBLNo").text(j.HAWB);
                $("#vessel").text(j.VesselName);
                $("#newHBLNo").text(j.BookingNo);
                $("#etd").text(ShowDate(j.ETDDate));
                $("#eta").text(ShowDate(j.ETADate));
                ShowCustomerAddress(path, j.CustCode, j.CustBranch, header);
                if (j.JobType == 1) {
                    ShowCustomerEN(path, j.CustCode, j.CustBranch, '#shipperName');
                    ShowCustomerEN(path, j.Consigneecode, j.CustBranch, '#consigneeName');
                    ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#original');
                } else {
                    ShowCustomerEN(path, j.CustCode, j.CustBranch, '#consigneeName');
                    ShowCustomerEN(path, j.Consigneecode, j.CustBranch, '#shipperName');
                    ShowInterPort(path, j.InvCountry, j.InvInterPort, '#original');
                }
                ShowVender(path, j.ForwarderCode, '#carrier');
            }
        });
    }
    function ShowCustomerAddress(path, code, branch,h) {
        $.get(path + 'Master/GetCompany?Code=' + code + '&Branch=' + branch).done(function (r) {
            if (r.company.data.length>0) {
                let c = r.company.data[0];
                $('#billName').text(c.NameEng);
                $('#billAddress').html(c.EAddress1 + '<br/>' + c.EAddress2);
                let creditlimit = Number(c.CreditLimit);
                $('#dueDate').text(AddDate(h.DocDate, creditlimit));
                $("#creditTerm").text(creditlimit + " DAYS");
                $("#currency").text(h.CurrencyCode);
            }
        });
    }

</script>