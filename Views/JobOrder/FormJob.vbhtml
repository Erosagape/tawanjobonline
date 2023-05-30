@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "JOB ACKNOWLEDGEMENT"
    ViewBag.Title = "Job Acknowledgement"
End Code
<style>
    * {
        font-size:10px;
    }
</style>
<div>
    <table id="divJobInfo" width="100%">
        <tr>
            <td colspan="2">
                <b>Job No : </b><input type="text" style="border:groove;text-align:center" id="txtJNo" value="" />
            </td>
            <td>
                <b>Job Type : <label id="lblJobType"></label></b>
            </td>
            <td>
                <b>Ship By : <label id="lblShipBy"></label></b>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>Quotation : </b><label id="lblQuotation"></label>
            </td>
            <td>
                <b>Confirm Date : </b><label id="lblConfirmDate"></label>
            </td>
            <td>
                <b>Open Date : </b><label id="lblOpenDate"></label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td><b>Customer : </b><label id="lblCustCode"></label> / <label id="lblCustName"></label></td>
        </tr>
        <tr>
            <td id="dvAddr"></td>
        </tr>
        @*<tr>
            <td><b>Tel : </b><label id="lblTel"></label></td>
        </tr>
        <tr>
            <td><b>Fax : </b><label id="lblFax"></label></td>
        </tr>
        <tr>
            <td><b>Contact : </b><label id="lblContact"></label></td>
        </tr>
        *@
    </table>
    <table id="divBillingPlace">
        <tr>
            <td><b>Consignee : </b><label id="lblBillToCustCode"></label> / <label id="lblBillToCustName"></label></td>
        </tr>
        <tr>
            <td id="dvBillAddr"></td>
        </tr>
    </table>
    <table id="tbInvoiceInfo" width="100%">
        <tr>
            <td colspan="3">
                <b>COMMERCIAL INV: </b><label id="lblInvNo"></label>
            </td>
            <td>
                <b>RATE :</b>1 <label id="lblCurrency"></label>=<label id="lblExcRate"></label> THB
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>COMMODITY : </b><label id="lblInvProduct"></label>
            </td>
            <td>
                <b>QTY : </b><label id="lblInvQty"></label> <label id="lblInvUnit"></label>
            </td>
            <td>
                <b>AMOUNT : </b><label id="lblInvTotal"></label>
            </td>
        </tr>
        <tr>
            <td>
                <b>PACKAGE : </b><label id="lblPackQty"></label> <label id="lblPackUnit"></label>
            </td>
            <td>
                <b>GROSS WT : </b><label id="lblTotalGW"></label> <label id="lblGWUnit"></label>
            </td>
            <td>
                <b>NET WT : </b><label id="lblTotalNW"></label> <label id="lblNWUnit"></label>
            </td>
            <td>
                <b>M3 : </b><label id="lblMeasurement"></label>
            </td>
        </tr>
        <tr>
            <td>
                <b>BOOKING : </b><label id="lblBookingNo"></label>
            </td>
            <td>
                <b>H.BL/AWB : </b><label id="lblHAWBNo"></label>
            </td>
            <td>
                <b>M.BL/AWB : </b><label id="lblMAWBNo"></label>
            </td>
            <td>
                <b>DECLARE NO : </b><label id="lblDeclareNo"></label>
            </td>
        </tr>
        <tr>
            <td>
                <b>DUTY.AMT : </b><label id="lblDutyAmt"></label>
            </td>
            <td>
                <b>CERTIFICATES : </b><label id="lblTaxPrivilege"></label>
            </td>
            <td>
                <b>DECL.TYPE : </b><label id="lblDeclareType"></label>
            </td>
            <td>
                <b>CUST.REF : </b><label id="lblCustRefNo"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>SHIPPING NOTE : </b><label id="lblShippingCmd"></label>
            </td>
            <td colspan="2">
                <b>SHIPPING : </b><label id="lblShippingName"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>FROM : </b><label id="lblFromCountry"></label>
            </td>
            <td colspan="2">
                <b>PORT OF LOADING: </b><label id="lblFromPort"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>TO : </b><label id="lblToCountry"></label>
            </td>
            <td colspan="2">
                <b>PORT OF DELIVERY: </b><label id="lblToPort"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>VESSEL/FLIGHT : </b><label id="lblVesselName"></label>
            </td>
            <td colspan="2">
                <b>CARRIER : </b><label id="lblAgentName"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>LOADING / CTN : </b><label id="lblTotalContainer"></label>
            </td>
            <td colspan="2">
                <b>TRANSPORTER : </b><label id="lblTransportName"></label>
            </td>
        </tr>
        <tr>
            <td>
                <b>ETD : </b><label id="lblETDDate"></label>
            </td>
            <td>
                <b>ETA : </b><label id="lblETADate"></label>
            </td>
            <td>
                <b>LOAD : </b><label id="lblLoadDate"></label>
            </td>
            <td>
                <b>DELIVERY : </b><label id="lblDeliveryDate"></label>
            </td>
        </tr>
    </table>
    <table id="tbExpenses" style="width:100%;border-collapse:collapse;">
        <thead>
            <tr>
                <th style="border-style:solid;border-width:thin;width:40%">DESCRIPTION</th>
                <th style="border-style:solid;border-width:thin;width:20%">ADVANCE</th>
                <th style="border-style:solid;border-width:thin;width:20%">COST</th>
                <th style="border-style:solid;border-width:thin;width:20%">SERVICE</th>
            </tr>
        </thead>
        <tbody>
            @Code
                For i As Integer = 1 To 30
                    Dim rowid = "row" & i
                    Dim rowadv = "adv" & i
                    Dim rowcost = "cost" & i
                    Dim rowserv = "serv" & i
                    @<tr>
                        <td style = "border-style:solid;border-width:thin;" id="@rowid"></td>
                        <td style = "border-style:solid;border-width:thin; text-align:right;" id="@rowadv"></td>
                        <td style = "border-style: solid; border-width: thin; text-align: right;" id="@rowcost"></td>
                        <td style = "border-style: solid; border-width: thin; text-align: right;" id="@rowserv"></td>
                    </tr>
                Next
            End Code
            <tr>
                <td style="border-style:solid;border-width:thin;"><b>GRAND TOTAL</b><label id="lblJobNo"></label></td>
                <td style="border-style:solid;border-width:thin;" id="rowTotalAdv"></td>
                <td style="border-style:solid;border-width:thin;" id="rowTotalCost"></td>
                <td style="border-style:solid;border-width:thin;" id="rowTotalServ"></td>
            </tr>
        </tbody>
    </table>
    <table id="tblFooter" style="width:100%">
        <tr>
            <td width="60%" valign="top">
                <b>NOTE:</b> <br />
                <div id="lblDescription"></div>
            </td>
            <td width="40%" style="text-align:right">
                <b>
                    PREPARED BY:
                    <label id="lblCSName"></label>
                </b> (<label id="lblPosition"></label>)
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    //$(document).ready(function () {
    let br = getQueryString('BranchCode');
    let jno = getQueryString('JNo');
    PopulateGridDetail();
    if (br != "" && jno != "") {
        GetJob(br, jno);
    }
    //});
    function GetJob(Branch, Job) {
        $.get(path+'joborder/getjobsql?branch=' + Branch + '&jno=' + Job)
            .done(function (r) {
                if (r.job.data.length > 0) {
                    var rec = r.job.data[0];
                    DisplayData(rec);
                    return;
                }
        });

    }
    function ShowCustomer(Code, Branch, isCons) {
        let url = '';
        if (isCons == true) {
            $('#lblBillToCustName').text('-');
            $('#dvBillAddr').html('<b>Address : </b>-');
            url = path + 'Master/GetCompany?Code=' + Code;
        }
        if (isCons == false) {
            $('#lblCustName').text('-');
            $('#dvAddr').html('<b>Address : </b>-');
            $('#lblTel').text('-');
            $('#lblFax').text('-');
            url = path + 'Master/GetCompany?Code=' + Code + '&Branch=' + Branch;
        }
        if ((Code + Branch).length > 0) {
            $.get(url)
                .done(function (r) {
                    if (r.company.data.length > 0) {
                        var c = r.company.data[0];
                        if (isCons == true) {
                            $('#lblBillToCustName').text(c.NameEng + ' Tax Reference :' + c.TaxNumber);
                            $('#dvBillAddr').html('<b>Address : </b>'
                                + (c.EAddress1 + ' ' + c.EAddress2).trim());
                        }
                        if (isCons == false) {
                            $('#lblCustName').text(c.Title+' '+c.NameThai);
                            $('#dvAddr').html('<b>Address : </b>'
                                + (c.TAddress1 + ' ' + c.TAddress2).trim());
                            $('#lblTel').text(c.Phone);
                            $('#lblFax').text(c.FaxNumber);
                        }
                    }
                });
        }
    }
    function DisplayData(j) {
        $('#txtJNo').val(j.JNo);
        $('#lblJobNo').text(j.JNo);
        $('#lblOpenDate').text(ShowDate(j.DocDate));
        $('#lblConfirmDate').text(ShowDate(j.ConfirmDate));
        $('#lblETDDate').text(ShowDate(j.ETDDate));
        $('#lblETADate').text(ShowDate(j.ETADate));
        $('#lblLoadDate').text(ShowDate(j.LoadDate));
        $('#lblDeliveryDate').text(ShowDate(j.EstDeliverDate));
        $('#lblQuotation').text(j.QNo);
        $('#lblInvNo').text(j.InvNo);
        $('#lblCurrency').text(j.InvCurUnit);
        $('#lblExcRate').text(j.InvCurRate);
        $('#lblInvProduct').text(j.InvProduct);
        $('#lblInvTotal').text(j.InvTotal + ' ' + CStr(j.InvCurUnit));
        $('#lblInvQty').text(j.InvProductQty);

        ShowInvUnit(path, j.InvProductUnit, '#lblInvUnit');

        $('#lblPackQty').text(j.TotalQty);
        $('#lblPackUnit').text('PKGS');
        $('#lblTotalGW').text(j.TotalGW);
        $('#lblTotalNW').text(j.TotalNW);

        ShowInvUnit(path, j.GWUnit, '#lblNWUnit');
        ShowInvUnit(path, j.GWUnit, '#lblGWUnit');
        $('#lblMeasurement').text(j.Measurement);
        $('#lblBookingNo').text(j.BookingNo);
        $('#lblHAWBNo').text(j.HAWB);
        $('#lblMAWBNo').text(j.MAWB);
        $('#lblVesselName').text(j.VesselName);
        $('#lblTotalContainer').text(j.TotalContainer);
        $('#lblDeclareNo').text(j.DeclareNumber);
        $('#lblContact').text(j.CustContactName);
        $('#lblDutyAmt').text(j.DutyAmount + ' THB');
        $('#lblTaxPrivilege').text(j.TyClearTaxReson);
        $('#lblShippingCmd').text(j.ShippingCmd);
        $('#lblCustRefNo').text(j.CustRefNO);
        let str =j.Description.replace(/(?:\r\n|\r|\n)/g, '<br/>');
        $('#lblDescription').html(str);

        var jt = j.JobType;
        var sb = j.ShipBy;
        if (jt < 10) jt = '0' + jt;
        if (sb < 10) sb = '0' + sb;
        ShowConfig(path, 'JOB_TYPE', jt, '#lblJobType');
        ShowConfig(path, 'SHIP_BY', sb, '#lblShipBy');

        $('#lblCustCode').text(j.CustCode);
        ShowCustomer(j.CustCode, j.CustBranch, false);

        $('#lblBillToCustCode').text(j.Consigneecode);
        ShowCustomer(j.Consigneecode, j.CustBranch, true);

        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
        ShowCountry(path, j.InvCountry, '#lblToCountry');
        if (j.JobType == '1') {

            ShowInterPort(path,j.InvFCountry, j.InvInterPort, '#lblFromPort');
            ShowReleasePort(path,j.ClearPort, '#lblToPort');
        } else {
            ShowInterPort(path,j.InvCountry, j.InvInterPort, '#lblToPort');
            ShowReleasePort(path,j.ClearPort, '#lblFromPort');
        }
        ShowVender(path,j.ForwarderCode, '#lblAgentName');
        ShowVender(path,j.AgentCode, '#lblTransportName');

        ShowDeclareType(path,j.DeclareType,'#lblDeclareType');
        ShowUser(path,j.CSCode, '#lblCSName');
        ShowUser(path,j.ShippingEmp, '#lblShippingName');

        $('#lblPosition').text('Customer Services');
    }
    function PopulateGridDetail() {
        $('#row1').text('CUSTOMS TAX');
        $('#row2').text('D/O CHARGE');
        $('#row3').text('CONTAINER DEPOSIT');
        $('#row4').text('CUSTOMS FEE');
        $('#row5').text('O/T CUSTOMS');
        $('#row6').text('STORAGE CHARGE');
        $('#row7').text('DEMURRAGE CHARGE');
        $('#row8').text('ROYAL FOREST PERMIT');
        $('#row9').text('PHYTO PERMIT');
        $('#row10').text('TISI PERMIT');
        $('#row11').text('MARINE DEPARTMENT PERMIT');
        $('#row12').text('EXCISE PERMIT');
        $('#row13').text('DIT PERMIT');
        $('#row14').text('CUSTOMS INSPECTION CHARGE');
        $('#row15').text('SHIPPING CHARGE');
        $('#row16').text('O/T SHIPPING');
        $('#row17').text('TRANSPORT');
        $('#row18').text('RETURN CONTAINER');
        $('#row19').text('SHIPPING BANGPU');
        $('#row20').text('O/T SHIPPING BANGPU');
        $('#row21').text('LEAD FZ');
        $('#row22').text('INSURANCE');
        $('#row23').text('OCEAN FREIGHT');
        $('#row24').text('TERMINAL WHARF/EQUIPMENT CHARGE');
        $('#row25').text('CONTAINER CLEANING/REPAIR');
        $('#row26').text('B/L FEE/CHANGING D/O');
        $('#row27').text('DELIVERY HANDLING');
        $('#row28').text('LIFT ON/LIFT OFF/GATE CHARGE');
        $('#row29').text('SERVICE/DOCUMENT CHARGE');
        $('#row30').text('OTHER CHARGE');
        $.get(path + 'clr/getclearingreport?branch=' + br + '&job=' + jno, function (r) {
            if (r.data.length > 0) {
                let sumadv = 0;
                let sumcost = 0;
                let sumserv = 0;
                for (let i = 0; i < r.data.length; i++) {
                    let d = r.data[i];
                    let oldval = 0;
                    switch (d.SICode) {
                        case 'ADV-042':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv1').text(d.BNet+oldval);
                            break;
                        case 'ADV-003':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv2').text(d.BNet+eldval);
                            break;
                        case 'ADV-152':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv3').text(d.BNet+oldval);
                            break;
                        case 'CST-213':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#cost3').text(d.BNet+oldval);
                            break;
                        case 'ADV-011':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv4').text(d.BNet+oldval);
                            break;
                        case 'ADV-010':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv5').text(d.BNet+oldval);
                            break;
                        case 'ADV-157':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv6').text(d.BNet+oldval);
                            break;
                        case 'CST-214':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#cost6').text(d.BNet+oldval);
                            break;
                        case 'ADV-043':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#adv7').text(d.BNet+oldval);
                            break;
                        case 'SRV-183':
                            if (CNum($('#adv1').text()) > 0)
                                oldval = CNum($('#adv1').text());
                            $('#serv8').text(d.BNet+oldval);
                            break;
                        case 'CST-179':
                            if (CNum($('#cost9').text()) > 0)
                                oldval = CNum($('#cost9').text());
                            $('#cost9').text(d.BNet + oldval);
                            break;
                        case 'CST-201':
                            if (CNum($('#cost9').text()) > 0)
                                oldval = CNum($('#cost9').text());
                            $('#cost9').text(d.BNet + oldval);
                            break;
                        case 'CST-224':
                            if (CNum($('#cost9').text()) > 0)
                                oldval = CNum($('#cost9').text());
                            $('#cost9').text(d.BNet + oldval);
                            break;
                        case 'CST-171':
                            if (CNum($('#cost10').text()) > 0)
                                oldval = CNum($('#cost10').text());
                            $('#cost10').text(d.BNet + oldval);
                            break;
                        case 'SRV-059':
                            if (CNum($('#serv10').text()) > 0)
                                oldval = CNum($('#serv10').text());
                            $('#serv10').text(d.BNet + oldval);
                            break;
                        case 'SRV-044':
                            if (CNum($('#serv11').text()) > 0)
                                oldval = CNum($('#serv11').text());
                            $('#serv11').text(d.BNet + oldval);
                            break;
                        case 'SRV-111':
                            if (CNum($('#serv11').text()) > 0)
                                oldval = CNum($('#serv11').text());
                            $('#serv11').text(d.BNet + oldval);
                            break;
                        case 'SRV-123':
                            if (CNum($('#serv11').text()) > 0)
                                oldval = CNum($('#serv11').text());
                            $('#serv11').text(d.BNet + oldval);
                            break;
                        case 'CST-172':
                            if (CNum($('#cost12').text()) > 0)
                                oldval = CNum($('#cost12').text());
                            $('#cost12').text(d.BNet + oldval);
                            break;
                        case 'SRV-120':
                            if (CNum($('#serv12').text()) > 0)
                                oldval = CNum($('#serv12').text());
                            $('#serv12').text(d.BNet + oldval);
                            break;
                        case 'SRV-148':
                            if (CNum($('#serv13').text()) > 0)
                                oldval = CNum($('#serv13').text());
                            $('#serv13').text(d.BNet + oldval);
                            break;
                        case 'SRV-071':
                            if (CNum($('#serv14').text()) > 0)
                                oldval = CNum($('#serv14').text());
                            $('#serv14').text(d.BNet + oldval);
                            break;
                        case 'ADV-163':
                            if (CNum($('#adv15').text()) > 0)
                                oldval = CNum($('#adv15').text());
                            $('#adv15').text(d.BNet + oldval);
                            break;
                        case 'SRV-127':
                            if (CNum($('#serv15').text()) > 0)
                                oldval = CNum($('#serv15').text());
                            $('#serv15').text(d.BNet + oldval);
                            break;
                        case 'SRV-184':
                            if (CNum($('#serv16').text()) > 0)
                                oldval = CNum($('#serv16').text());
                            $('#serv16').text(d.BNet + oldval);
                            break;
                        case 'ADV-209':
                            if (CNum($('#adv17').text()) > 0)
                                oldval = CNum($('#adv17').text());
                            $('#adv17').text(d.BNet + oldval);
                            break;
                        case 'CST-148':
                            if (CNum($('#cost17').text()) > 0)
                                oldval = CNum($('#cost17').text());
                            $('#cost17').text(d.BNet + oldval);
                            break;
                        case 'SRV-019':
                            if (CNum($('#serv17').text()) > 0)
                                oldval = CNum($('#serv17').text());
                            $('#serv17').text(d.BNet + oldval);
                            break;
                        case 'CST-149':
                            if (CNum($('#cost18').text()) > 0)
                                oldval = CNum($('#cost18').text());
                            $('#cost18').text(d.BNet + oldval);
                            break;
                        case 'ADV-161':
                            if (CNum($('#adv18').text()) > 0)
                                oldval = CNum($('#adv18').text());
                            $('#adv18').text(d.BNet + oldval);
                            break;
                        case 'CST-193':
                            if (CNum($('#cost19').text()) > 0)
                                oldval = CNum($('#cost19').text());
                            $('#cost19').text(d.BNet + oldval);
                            break;
                        case 'ADV-269':
                            if (CNum($('#adv20').text()) > 0)
                                oldval = CNum($('#adv20').text());
                            $('#adv20').text(d.BNet + oldval);
                            break;
                        case 'SRV-119':
                            if (CNum($('#serv20').text()) > 0)
                                oldval = CNum($('#serv20').text());
                            $('#serv20').text(d.BNet + oldval);
                            break;
                        case 'ADV-169':
                            if (CNum($('#adv22').text()) > 0)
                                oldval = CNum($('#adv22').text());
                            $('#adv22').text(d.BNet + oldval);
                            break;
                        case 'CST-191':
                            if (CNum($('#cost22').text()) > 0)
                                oldval = CNum($('#cost22').text());
                            $('#cost22').text(d.BNet + oldval);
                            break;
                        case 'SRV-163':
                            if (CNum($('#serv22').text()) > 0)
                                oldval = CNum($('#serv22').text());
                            $('#serv22').text(d.BNet + oldval);
                            break;
                        case 'ADV-177':
                            if (CNum($('#adv23').text()) > 0)
                                oldval = CNum($('#adv23').text());
                            $('#adv23').text(d.BNet + oldval);
                            break;
                        case 'ADV-033':
                            if (CNum($('#adv24').text()) > 0)
                                oldval = CNum($('#adv24').text());
                            $('#adv24').text(d.BNet + oldval);
                            break;
                        case 'ADV-166':
                            if (CNum($('#adv25').text()) > 0)
                                oldval = CNum($('#adv25').text());
                            $('#adv25').text(d.BNet + oldval);
                            break;
                        case 'SRV-115':
                            if (CNum($('#serv26').text()) > 0)
                                oldval = CNum($('#serv26').text());
                            $('#serv26').text(d.BNet + oldval);
                            break;
                        case 'ADV-192':
                            if (CNum($('#adv27').text()) > 0)
                                oldval = CNum($('#adv27').text());
                            $('#adv27').text(d.BNet + oldval);
                            break;
                        case 'SRV-180':
                            if (CNum($('#serv27').text()) > 0)
                                oldval = CNum($('#serv27').text());
                            $('#serv27').text(d.BNet + oldval);
                            break;
                        case 'SRV-008':
                            if (CNum($('#serv28').text()) > 0)
                                oldval = CNum($('#serv28').text());
                            $('#serv28').text(d.BNet + oldval);
                            break;
                        case 'SRV-169':
                            if (CNum($('#serv29').text()) > 0)
                                oldval = CNum($('#serv29').text());
                            $('#serv29').text(d.BNet + oldval);
                            break;
                        default:
                            if (d.IsExpense == 1) {
                                if (CNum($('#cost30').text()) > 0)
                                    oldval = CNum($('#cost30').text());
                                $('#cost30').text(d.BNet + oldval);
                            } else {
                                if (d.IsCredit == 1) {
                                    if (CNum($('#adv30').text()) > 0)
                                        oldval = CNum($('#adv30').text());
                                    $('#adv30').text(d.BNet + oldval);
                                } else {
                                    if (CNum($('#serv30').text()) > 0)
                                        oldval = CNum($('#serv30').text());
                                    $('#serv30').text(d.BNet + oldval);
                                }
                            }
                            break;
                    }
                }
            }
        });
    }
</script>