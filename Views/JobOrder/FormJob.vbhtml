@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "SHIPPING CLOSING SHEET"
    ViewBag.Title = "SHIPPING CLOSING SHEET"
End Code
<div>
    <table id="divJobInfo" width="100%">
        <tr>
            <td colspan="2" >
                <b style="font-size:16px">Job No : </b><input  type="text" style="font-size:16px;border:groove;text-align:center" id="txtJNo" value="" />
            </td>
            <td >
                <b style="font-size:16px">Job Type : <label style="font-size:16px" id="lblJobType"></label></b>
            </td>
            <td>
                <b  style="font-size:16px">Ship By : <label  style="font-size:16px" id="lblShipBy"></label></b>
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
    </table>
    <table id="divBillingPlace">
        <tr>
            <td><b>Consignee : </b><label id="lblBillToCustCode"></label> / <label id="lblBillToCustName"></label></td>
        </tr>
    </table>
    <table id="tbInvoiceInfo" width="100%">
        <tr>
            <td colspan="3">
                <b>INVOICE NO : </b><label id="lblInvNo"></label>
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
                <b>TOTAL : </b><label id="lblInvTotal"></label>
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
            <td colspan="2">
                <b>DECL.TYPE : </b><label id="lblDeclareType"></label>
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
                <b>PORT : </b><label id="lblFromPort"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>TO : </b><label id="lblToCountry"></label>
            </td>
            <td colspan="2">
                <b>PORT : </b><label id="lblToPort"></label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>VESSEL/FLIGHT : </b><label id="lblVesselName"></label>
            </td>
            <td colspan="2">
                <b>AGENT : </b><label id="lblAgentName"></label>
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
    <table id="tbExpenses" style="width:100%;border-collapse:collapse;font-size:8px">
        <thead>
            <tr>
                <th colspan="5" style="border-style:solid;border-width:thin;">ค่าใช้จ่ายเคลียร์พิธีการศุลกากร</th>
            </tr>
            <tr>
                <th colspan="3" style="border-style:solid;border-width:thin;width:50%">มีใบเสร็จในนามลูกค้า</th>
                <th colspan="2" style="border-style:solid;border-width:thin;width:50%">ไม่มีใบเสร็จรับเงินในนามลูกค้า</th>
            </tr>
            <tr>
                <th style="border-style:solid;border-width:thin;width:30%">รายละเอียด</th>
                <th style="border-style:solid;border-width:thin;width:20%">เลขที่ใบเสร็จ</th>
                <th style="border-style:solid;border-width:thin;width:10%">จำนวนเงิน</th>
                <th style="border-style:solid;border-width:thin;width:30%">รายละเอียด</th>
                <th style="border-style:solid;border-width:thin;width:10%">จำนวนเงิน</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าธรรมเนียม Paperless</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าปล่อยเบย์-จัดเรียงสินค้า</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าภาษีอากร</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าปล่อยวาลฟ์</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าล่วงเวลากรมศุลกากร</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่ารถตักสินค้า</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าล่วงเวลาการท่าเรือ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าพิธีการตรวจปล่อย</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าล่วงเวลาเอเย่นต์</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่านำแรงงานท่าเรือ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าแลก D/O</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าแรงงานคลังขนถ่ายสินค้า</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าเช่าการท่าเรือ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">จำนวน (คน)</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่ามัดจำตู้</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่านายตรวจศุลกากร</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่ารถขนส่งสินค้า 6ล้อ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าปล่อย Print Permit</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่ารถขนส่งสินค้า 4ล้อ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่ารถหัวลากต่อระยะ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าผ่านท่า</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าใช้จ่ายเจ้าหน้าที่ประมง</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าคืนตู้เปล่า</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าใช้จ่ายเจ้าหน้าที่ อย</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่า Demurrage</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าทำบัตร</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่า Detention</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าจอดรถ</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าธรรมเนียมธนาคาร</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่ารับเอกสารทางอีเมล์</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่าซ่อมตู้</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">ค่าเช็คภาษี</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">ค่ายื่น C/O หอการค้า</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;"><b>รวมรายจ่าย</b></td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
                <td style="border-style:solid;border-width:thin;"><b>รวมรายจ่าย</b></td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
            </tr>
            <tr>
                <td style="border-style:solid;border-width:thin;">**FOR JOB NUMBER</td>
                <td style="border-style:solid;border-width:thin;"><label id="lblJobNo"></label></td>
                <td style="border-style:solid;border-width:thin;">ONLY**</td>
                <td style="border-style:solid;border-width:thin;"><b>รวมทั้งสิ้น</b></td>
                <td style="border-style:solid;border-width:thin;">&nbsp;</td>
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
                <b>PREPARED BY:
                <label id="lblCSName"></label></b> (<label id="lblPosition"></label>)
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';

$('#imgLogo').css('display','none');
$('#imgLogoAdd').css('display','inline');
    //$(document).ready(function () {
        let br = getQueryString('BranchCode');
        let jno = getQueryString('JNo');
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
                            $('#lblCustName').text(c.NameThai);
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

</script>