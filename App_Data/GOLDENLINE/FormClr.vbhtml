@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Clearing Slip"
    ViewBag.ReportName = "CLEARING SLIP"
End Code
<style>
    td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
    #dvFooter {
        display:none;
    }
</style>
<div style="display:flex">
    <div style="flex:1" class="text-left">
        EXPENSE CLEARING &nbsp;&nbsp;&nbsp; <label id="txtJobType"></label>
    </div>

    <div style="flex:1;text-align:right">
        <label id="txtBranchName"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:1" class="text-left">
        OPERATION DATE : <label id="txtClearanceDate"></label>
    </div>

    <div style="flex:1;text-align:right">
        <label id="txtDocStatus"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:2">
        CTN NO : <label id="txtContainerNo"></label>
    </div>
    <div style="flex:1">
        CLEAR DATE : <label id="txtDocDate"></label>
    </div>
    <div style="flex:1">
        DOC NO : <label id="txtClrNo"></label>
    </div>
</div>

<div style="display:flex;flex-wrap:wrap;">
    <div style="flex:1">
        CO-PERSON : <label id="txtCoPersonCode"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:1">
        REMARK : <label id="txtRemark"></label>
    </div>
</div>

<table id="tbDetail" border="1" width="100%">
    <thead>
        <tr class="text-center">
            <th width="8%">CODE.</th>
            <th width="50%">DESCRIPTION</th>
            <th width="12%">JOBNO</th>
            <th width="10%">VAT</th>
            <th width="10%">WHTAK</th>
            <th width="10%">PAID</th>
        </tr>
    </thead>
    <tbody></tbody>
</table>
<table border="1" width="100%">
    <tr class="text-center">
        <td width="10%"></td>
        <td width="50%"></td>
        <td width="20%"></td>
        <td width="10%"></td>
        <td width="10%"></td>
    </tr>
    <tr>
        <td colspan="4">
            <div style="display:flex">
                <div style="flex:1" class="text-left">
                    CLEARING TYPE : <label id="txtClrType"></label>
                    <br />
                    CLEARING FROM :  <label id="txtClrFrom"></label>
                </div>
                <div style="flex:1 ;text-align:right">
                    AMOUNT (VAT)
                    <br />
                    AMOUNT (NON-VAT)
                    <br />
                    VAT
                    <br />
                    AMOUNT (WHT)
                    <br />
                    WITH-HOLDING TAX
                    <br />
                    CLEARING NET
                </div>
            </div>
        </td>
        <td style="text-align:right">
            <div style="display:flex">
                <div style="flex:1">
                    <label id="txtAmtVat"></label>
                    <br />
                    <label id="txtAmtNonVat"></label>
                    <br />
                    <label id="txtVat"></label>
                    <br />
                    <label id="txtAmtWht"></label>
                    <br />
                    <label id="txtWht"></label>
                    <br />
                    <label id="txtTotal"></label>
                </div>
            </div>
        </td>
    </tr>
</table>
<div id="dvSummary">
</div>
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

        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">

        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">

        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">

        </td>
    </tr>
</table>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
        let branch = getQueryString('branch');
        let code = getQueryString('code');
        if (branch != "" && code != "") {
            $.get(path + 'clr/getclearingreport?branch=' + branch + '&code=' + code, function (r) {
                if (r.data[0].Table !== undefined) {
                    let h = r.data[0].Table[0];
                    $('#txtDocStatus').text(h.ClrStatusName);
                    $('#txtClearanceDate').text(CDateEN(h.ClearanceDate));
                    $('#txtJobType').text(h.JobTypeName);
                    $('#txtBranchName').text(h.BranchName);
                    $('#txtContainerNo').text(h.CTN_NO);
                    $('#txtDocDate').text(CDateEN(h.ClrDate));
                    $('#txtClrNo').text(h.ClrNo);
                    $('#txtCoPersonCode').text(h.CoPersonCode);
                    $('#txtRemark').text(h.TRemark);
                    $('#txtClrType').text(h.ClrTypeName);
                    $('#txtClrFrom').text(h.ClrFromName);

                    let html = '';
                    let cust = '';
                    let amtforvat = 0;
                    let amtnonvat = 0;
                    let amtvat = 0;
                    let amtwht = 0;
                    let amtforwht = 0;
                    let amttotal = 0;
                    let advlist = '';

                    let d = r.data[0].Table;
                    for (let i= 0; i < d.length; i++){
                        if (d[i].CustCode !== cust) {
                            cust = d[i].CustCode;
                            html += '<tr><td colspan="6">'+d[i].CustCode + ' ' + d[i].NameThai+'</td></tr>';
                        }
                        if (d[i].AdvNO !== null) {
                            if (advlist.indexOf(d[i].AdvNO) < 0) {
                                advlist += ',' + d[i].AdvNO;
                            }
                        }
                        let advref = (d[i].SlipNO !== null ? ' เลขที่#' + d[i].SlipNO : '');
                        advref = advref + (d[i].AdvNO !== null ? '<br/>จากใบเบิก ' + d[i].AdvNO : '');
                        advref = advref + (d[i].AdvAmount > 0 ? ' ยอดเบิก=' + CCurrency(CDbl(d[i].AdvAmount, 2)) : '');
                        advref = advref + (d[i].Remark !== '' ? '<br/>' + d[i].Remark : '');

                        let strJob = advref + '<br/>DECL: ' +d[i].DeclareNumber + '<br/>';
                        strJob = strJob + 'CONTAINER:' + ((d.TotalContainer == null || d.TotalContainer == '' ? '' : d.TotalContainer) + '<br/>');
                        strJob = strJob + 'BL/AWB:' + ((d.HAWB == null || d.HAWB == '' ? '' : d.HAWB) + '<br/>');
                        strJob = strJob + 'SHIPPER:' + ((d.ShippingEmp == null || d.ShippingEmp == '' ? '' : d.ShippingEmp) + '<br/>');

                        html += '<tr><td>' + d[i].SICode + '</td><td>' + d[i].SDescription + '' + strJob + '</td><td>' + d[i].JobNo + '<br/>' + '</td><td style="text-align:right;">' + CCurrency(CDbl(d[i].ChargeVAT, 2)) + '</td><td style="text-align:right;">' + CCurrency(CDbl(d[i].Tax50Tavi, 2)) + '</td><td style="text-align:right;">' + CCurrency(CDbl(d[i].UsedAmount, 2)) + '</td></tr>';

                        if (d[i].ChargeVAT > 0) {
                            amtforvat += d[i].UsedAmount;
                            amtvat += d[i].ChargeVAT;
                        } else {
                            amtnonvat += d[i].UsedAmount;
                        }
                        if (d[i].Tax50Tavi > 0) {
                            amtforwht += d[i].UsedAmount;
                            amtwht += d[i].Tax50Tavi;
                        }
                        amttotal += d[i].BNet;
                    }
                    $('#tbDetail tbody').html(html);

                    $('#txtAmtVat').text(CCurrency(CDbl(amtforvat,2)));
                    $('#txtAmtNonVat').text(CCurrency(CDbl(amtnonvat,2)));
                    $('#txtVat').text(CCurrency(CDbl(amtvat,2)));
                    $('#txtAmtWht').text(CCurrency(CDbl(amtforwht,2)));
                    $('#txtWht').text(CCurrency(CDbl(amtwht,2)));
                    $('#txtTotal').text(CCurrency(CDbl(amttotal, 2)));
                    if (advlist !== '') {
                        advlist = advlist.substr(1, advlist.length - 1);
                        $.get(path + 'Clr/GetAdvForClear?show=ALL&advno=' + advlist).done(function (r) {
                            if (r.clr.data.length > 0) {
                                let html = '';
                                for (let d of r.clr.data[0].Table) {
                                    let advno = d.AdvNO;
                                    let advnet = d.AdvNet;
                                    let advbalance = d.AdvBalance;
                                    let usedamount = d.UsedAmount;
                                    html += '<br/>';
                                    html += '' + advno + ' Total=' + ShowNumber(advnet,4) + ' Used=' + ShowNumber(usedamount,4) + ' Balance=' + ShowNumber(advbalance,4);
                                }
                                $('#dvSummary').html(html);
                            }
                        });
                    }
                }
            });
        }
    //});
</script>