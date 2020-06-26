
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Receipt Slip"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-size: 13px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    #dvFooter,#pFooter {
        display: none;
    }
</style>
<div style="text-align:center;width:100%;padding:5px 5px 5px 5px">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">ใบเสร็จรับเงินทดรองจ่าย (ADVANCE RECEIPT)</label>
</div>
<br />
<!--
<div style="display:flex;">
    <div style="flex:3;">
        <label>CUSTOMER:</label>
        <br/>
        <label id="lblCustCode"></label>
    </div>
    <div style="flex:1">
        BRANCH: <label id="lblBranchName">@ViewBag.PROFILE_DEFAULT_BRANCH_NAME</label>
        <br />
        TAX ID: <label id="lblTaxNumer">@ViewBag.PROFILE_TAXNUMBER</label>
    </div>

</div>
-->
<div style="display:flex;">
    <div style="flex:3;border:1px solid black;border-radius:5px;">
        NAME : <label id="lblCustName"></label><br />
        ADDRESS : <label id="lblCustAddr"></label><br />
        TEL : <label id="lblCustTel"></label><br />
        TAX-ID : <lable id="lblCustTax"></lable>
    </div>
    <div style="flex:1;border:1px solid black;border-radius:5px;">
        DOC NO. : <label id="lblReceiptNo"></label><br />
        REC DATE : <label id="lblReceiptDate"></label><br />
        CUST INV : <label id="lblCustInvNo"></label><br />
        JOB NO : <label id="lblJobNo"></label><br />
    </div>
</div>
<br/>
<div style="display:flex;border:1px solid black;border-radius:5px;">
    <div style="flex:2">
        <div class="row">
            <p class="col-sm-12">
                FROM :<label id="lblFromCountry"></label> TO :<label id="lblToCountry"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                PORT :<label id="lblInterPort"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                FLIGHT/VESSEL :<label id="lblVesselName"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                QUANTITY :<label id="lblQtyGross"></label> <label id="lblQtyUnit"></label>
                <br />
            </p>
        </div>
    </div>
    <div style="flex:2">
        <div class="row">
            <p class="col-sm-12">
                ETD :<label id="lblETDDate"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                HBL/HAWB :<label id="lblHAWB"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                MEASUREMENT :<label id="lblMeasurement"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                NET WEIGHT :<label id="lblNetWeight"></label> <label id="lblWeightUnit"></label>
            </p>
        </div>
    </div>
    <div style="flex:2">
        <div class="row">
            <p class="col-sm-12">
                ETA :<label id="lblETADate"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                MBL/MAWB :<label id="lblMAWB"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                CUSTOMER :<br /><label id="lblCustTName"></label>
            </p>
        </div>
    </div>
</div>
<table border="1" style="border-style:solid;width:100%; margin-top:5px" class="text-center">
    <thead>
        <tr style="background-color:lightblue;">
            <th height="40" width="60">INV.NO.</th>
            <th width="270">DESCRIPTION</th>
            <th width="60">AMOUNT</th>
            <th width="30">CURRENCY</th>
            <th width="40">RATE</th>
            <th width="60">THB AMOUNT</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tfoot>
        <tr style="background-color:lightblue;text-align:center;">
            <td colspan="3"><label id="lblTotalText"></label></td>
            <td colspan="2">TOTAL RECEIPT</td>
            <td colspan="1"><label id="lblTotalNum"></label></td>
        </tr>
    </tfoot>
</table>
<br/>
<p>
    PAY BY
</p>
<br/>
<div style="display:flex;flex-direction:column">
    <div>
        <label><input type="checkbox" name="vehicle1" value=""> CASH</label>
        DATE_____________  AMOUNT______________BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle2" value=""> CHEQUE</label>
        DATE_____________  NO_______________  BANK_________________  AMOUNT______________BAHT
    </div>
    <div>
        <label><input type="checkbox" name="vehicle3" value=""> TRANSFER</label>
        DATE_____________  BANK_________________  AMOUNT______________BAHT
    </div>
</div>
<br />
<div style="display:flex;">
    <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">

        FOR THE CUSTOMER
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
        AUTHORIZED SIGNATURE
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">

        FOR @ViewBag.PROFILE_COMPANY_NAME 
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let receiptno = getQueryString('code');

    $.get(path + 'acc/getreceivereport?branch=' + branch + '&code=' + receiptno, function (r) {
        if (r.receipt.data.length !== null) {
            ShowData(r.receipt.data);
        }
    });
    function ShowData(dt) {
        let h = dt[0];
        //$('#lblCustCode').text(h.CustCode);
        if (h.UsedLanguage == 'TH') {
            $('#lblCustName').text(h.CustTName);
            $('#lblCustAddr').text(h.CustTAddr);
            if(Number(h.CustBranch)>0) {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :' + h.CustBranch);
            } else {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :สำนักงานใหญ่');
            }
        } else {
            $('#lblCustName').text(h.CustEName);
            $('#lblCustAddr').text(h.CustEAddr);
            if(Number(h.CustBranch)>0) {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :' + h.CustBranch);
            } else {
                $('#lblCustTax').text(h.CustTaxID + ' BRANCH :HEAD OFFICE');
            }
        }
        $('#lblCustTel').text(h.CustPhone);

        $('#lblReceiptNo').text(h.ReceiptNo);
        $('#lblReceiptDate').text(ShowDate(CDateTH(h.ReceiptDate)));
        $.get(path + 'JobOrder/GetJobSQL?Branch=' + h.BranchCode + '&JNo=' + h.JobNo)
        .done(function (d) {
            if (d.job.data.length > 0) {
                let j = d.job.data[0];
                if (j !== null) {
                    $('#lblCustInvNo').text(j.InvNo);
                    ShowCustomerEN(path, j.CustCode,j.CustBranch, '#lblCustTName');		
                    $('#lblJobNo').text(j.JNo);
                    if(Number(j.JobType)==1){
                        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                        ShowCountry(path, j.InvCountry, '#lblToCountry');
                        ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#lblInterPort');
                    } else {
                        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                        ShowCountry(path, j.InvCountry, '#lblToCountry');
                        ShowInterPort(path, j.InvCountry, j.InvInterPort, '#lblInterPort');
                    }
                    $('#lblVesselName').text(j.VesselName);
                    $('#lblQtyGross').text(j.InvProductQty);
                    ShowInvUnit(path, j.InvProductUnit, '#lblQtyUnit');
                    $('#lblNetWeight').text(j.TotalNW);
                    ShowInvUnit(path, j.GWUnit, '#lblWeightUnit');
                    $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                    $('#lblHAWB').text(j.HAWB);
                    $('#lblMeasurement').text(j.Measurement);
                    $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                    $('#lblMAWB').text(j.MAWB);
                }
            }
        });
        let html = '';
        let total = 0;

        for (let d of dt) {
            html = '<tr>';
            html += '<td style="text-align:center">' + d.InvoiceNo + '</td>';
            html += '<td>' + d.SDescription + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.FNet,2) + '</td>';
            html += '<td style="text-align:center">' + d.DCurrencyCode + '</td>';
            html += '<td style="text-align:center">' + d.DExchangeRate + '</td>';
            html += '<td style="text-align:right">' + ShowNumber(d.Net,2) + '</td>';
            html += '</tr>';

            $('#tbDetail').append(html);

            total += Number(d.Net);
        }
        $('#lblTotalNum').text(ShowNumber(total, 2));
        $('#lblTotalText').text(CNumThai(total));
    }
</script>