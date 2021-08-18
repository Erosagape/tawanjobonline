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
    <div style="flex:2">
        CO-PERSON : <label id="txtCoPersonCode"></label>
    </div>
    <div style="flex:1">
        TRUCK : <label id="txtTruckNo"></label>
    </div>
    <div style="flex:1">
        Driver : <label id="txtDriver"></label>
    </div>
</div>

<div style="display:flex">
    <div style="flex:2">
        REMARK : <label id="txtRemark"></label>
    </div>
    <div style="flex:1">
        Customer PO : <label id="txtCustPo"></label>
    </div>
    <div style="flex:1">
        A/C No : <label id="txtEmpAcc"></label>
    </div>
</div>
<div style="display:flex;flex-direction:column;margin:5px 5px 5px 5px;">
    <table border="1" width="100%">
        <tr class="text-center" style="font-weight:bold">
            <td width="10%">CODE.</td>
            <td width="48%">DESCRIPTION</td>
            <td width="12%">JOBNO</td>
            <td width="10%">VAT</td>
            <td width="10%">WHTAK</td>
            <td width="10%">PAID</td>
        </tr>
        <tbody id="tbDetail"></tbody>
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
                        Advance Summary:<br />
                        <table style="width:100%;">
                            <tbody id="tbAdv"></tbody>
                        </table>
                    </div>
                    <div style="flex:1 ;text-align:right">
                        AMOUNT (VAT)
                        <br />
                        AMOUNT (NON-VAT)
                        <br />
                        VAT
                        <br />
                        TOTAL
                        <br />
                        WHD-1%
                        <br />
                        WHD-1.5/3%
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
                        <label id="txtSumVat"></label>
                        <br />
                        <label id="txtWht1"></label>
                        <br />
                        <label id="txtWht3"></label>
                        <br />
                        <label id="txtTotal"></label>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <table border="1" width="100%" style="margin-top:50px">
        <tr Class="text-center">
            <th> CLEARING BY</th>
            <th> APPROVED BY</th>
            <th> FINANCIAL</th>
            <th> ACCOUNTING</th>
            <th> PAYEE</th>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr Class="text-center">
            <td>
                <br />
                <br />
                <label id="txtClrBy"></label>
                <label id="txtPrintDate"></label>
            </td>
            <td>
                <br />
                <br />
                <label id="txtApproveBy"></label>
                <label id="txtApproveDate"></label>
            </td>
            <td>
                <br />
                <br />
                <label id="txtReceiveBy"></label>
                <label id="txtReceiveDate"></label>
            </td>
            <td>
                <br />
                <br />
                ________/_______/_______
            </td>
            <td>
                <br />
                <br />
                ________/_______/_______
            </td>
        </tr>
    </table>
</div>

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
                    $('#txtCoPersonCode').text(h.Driver);
                    $('#txtRemark').text(h.TransportRoute);
                    $('#txtTruckNo').text(h.TruckNO);
                    $('#txtClrType').text(h.ClrTypeName);
                    $('#txtClrFrom').text(h.ClrFromName);
                    $('#txtClrBy').text(h.ClrByName);
                    $('#txtPrintDate').text(GetToday());
                    $('#txtApproveBy').text(h.ApproveByName);
                    $('#txtApproveDate').text(CDateEN(h.ApproveDate));
                    $('#txtReceiveBy').text(h.ReceiveByName);
                    $('#txtReceiveDate').text(CDateEN(h.ReceiveDate));
                    $('#txtCustPo').text(h.CustRefNO);
                    $.get(path + 'master/getemployee?code=' + h.Driver).done(function (r) {
                        if (r.employee.data.length > 0) {
                            let d = r.employee.data[0];
                            $('#txtDriver').text(d.PreName + d.Name);
                            $('#txtEmpAcc').text(d.AccountNumber);
                        }
                    });
                    let html = '';
                    let cust = '';
                    let amtforvat = 0;
                    let amtnonvat = 0;
                    let amtvat = 0;
                    let amtwht1 = 0;
                    let amtwht3 = 0;
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

                        html += '<tr><td>' + d[i].SICode + '</td><td>' + d[i].SDescription + '' + advref + '</td><td>' + d[i].JobNo +'<br/>' + d[i].InvNo + '</td><td style="text-align:right;">' + CCurrency(CDbl(d[i].ChargeVAT, 3)) + '</td><td style="text-align:right;">' + CCurrency(CDbl(d[i].Tax50Tavi, 3)) + '</td><td style="text-align:right;">' + CCurrency(CDbl(d[i].UsedAmount, 2)) + '</td></tr>';

                        if (d[i].ChargeVAT > 0) {
                            amtforvat += d[i].UsedAmount;
                            amtvat += d[i].ChargeVAT;
                        } else {
                            amtnonvat += d[i].UsedAmount;
                        }
                        if (d[i].Tax50Tavi > 0) {
                            if (d[i].Rate50Tavi == 1) {
                                amtwht1 += d[i].Tax50Tavi;
                            } else {
                                amtwht3 += d[i].Tax50Tavi;
                            }
                        }
                        amttotal += d[i].BNet;
                    }
                    $('#tbDetail').html(html);

                    $('#txtAmtVat').text(CCurrency(CDbl(amtforvat,2)));
                    $('#txtAmtNonVat').text(CCurrency(CDbl(amtnonvat,2)));
                    $('#txtVat').text(CCurrency(CDbl(amtvat, 2)));
                    $('#txtSumVat').text(CCurrency(CDbl(amtvat+amtforvat+amtnonvat,2)));
                    $('#txtWht3').text(CCurrency(CDbl(amtwht3,2)));
                    $('#txtWht1').text(CCurrency(CDbl(amtwht1,2)));
                    $('#txtTotal').text(CCurrency(CDbl(amttotal, 2)));
                    if (advlist !== '') {
                        advlist = advlist.substr(1, advlist.length - 1);
                        $.get(path + 'Clr/GetAdvForClear?show=ALL&advno=' + advlist).done(function (r) {
                            if (r.clr.data.length > 0) {
                                let lastadv = '';
                                let sumadv = 0;
                                let sumused = 0;
                                let sumreturn = 0;
                                let sumoverpay = 0;
                                let html = '';
                                html = '<tr>';
                                html += '<td>#</td>';
                                html += '<td>Advance</td>';
                                html += '<td>Used</td>';
                                html += '<td>Balance</td>';
                                html += '<td>Paid</td>';
                                html += '</tr>';
                                $('#tbAdv').append(html);
                                html = '';
                                for (let d of r.clr.data[0].Table) {
                                    if (lastadv !== d.AdvNO) {
                                        lastadv = d.AdvNO;
                                        if (html !== '') {
                                            html = html.replace('{0}', ShowNumber(sumadv,2));
                                            html = html.replace('{1}', ShowNumber(sumused,2));
                                            html = html.replace('{2}', ShowNumber(sumreturn,2));
                                            html = html.replace('{3}', ShowNumber(sumoverpay,2));
                                            $('#tbAdv').append(html);
                                        }
                                        sumadv = 0;
                                        sumused = 0;
                                        sumreturn = 0;
                                        sumoverpay = 0;
                                        html = '<tr>';
                                        html += '<td>' + lastadv + '</td>';
                                        html += '<td>{0}</td>';
                                        html += '<td>{1}</td>';
                                        html += '<td>{2}</td>';
                                        html += '<td>{3}</td>';
                                        html += '</tr>';
                                    }
                                    sumadv += d.AdvNet;
                                    sumused += d.UsedAmount;
                                    if (d.AdvBalance > 0) {
                                        sumreturn += d.AdvBalance;
                                    } else {
                                        sumoverpay += Math.abs(d.AdvBalance);
                                    }
                                }
                                if (html !== '') {
                                    html = html.replace('{0}', ShowNumber(sumadv,2));
                                    html = html.replace('{1}', ShowNumber(sumused,2));
                                    html = html.replace('{2}', ShowNumber(sumreturn,2));
                                    html = html.replace('{3}', ShowNumber(sumoverpay,2));
                                    $('#tbAdv').append(html);
                                }

                                /*
                                let html = '';
                                for (let d of r.clr.data[0].Table) {
                                    let advno = d.AdvNO;
                                    let advnet = d.AdvNet;
                                    let advbalance = d.AdvBalance;
                                    let usedamount = d.UsedAmount;
                                    html += '<br/>';
                                    html += '' + advno + ' Total=' + ShowNumber(advnet,4) + ' Used=' + ShowNumber(usedamount,4) + ' Balance=' + ShowNumber(advbalance,4);
                                }
                                */
                                //$('#dvSummary').html(html);
                            }
                        });
                    }
                }
            });
        }
    //});
</script>