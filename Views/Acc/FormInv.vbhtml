
@Code
    If Request.QueryString("code").Substring(0, 3) = "IVF" Then
        Layout = "~/Views/Shared/_ReportEng.vbhtml"
    Else
        Layout = "~/Views/Shared/_Report.vbhtml"
    End If
    ViewBag.Title = "Invoice Slip GL"
    Dim additionSQL As String = "SELECT Job_SrvSingle.NameThai,[Job_CashControlSub].*
FROM [job_stl].[dbo].[Job_CashControlSub]
INNER JOIN Job_CashControlDoc ON Job_CashControlDoc.ControlNo = Job_CashControlSub.ControlNo AND Job_CashControlDoc.BranchCode = Job_CashControlSub.BranchCode
INNER JOIN Job_CashControl ON Job_CashControl.ControlNo = Job_CashControlSub.ControlNo AND Job_CashControl.BranchCode = Job_CashControlSub.BranchCode
LEFT JOIN  Job_SrvSingle ON Job_SrvSingle.SICode = [Job_CashControlSub].SICode
WHERE [Job_CashControlSub].acType  = 'CU' AND [Job_CashControlSub].PRType='P' AND ISNULL(Job_CashControl.CancelProve,'')='' AND Job_CashControlDoc.DocType='INV'
AND Job_CashControlDoc.DocNo='" & Request.QueryString("code") & "' AND Job_CashControlDoc.BranchCode = '" & Request.QueryString("Branch") & "'"


    Dim dt = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(additionSQL)
    Dim custAdvDsc As String = ""
    @If dt.Rows.Count > 0 Then
        custAdvDsc = dt.Rows(0)("NameThai").ToString & " " & dt.Rows(0)("TRemark").ToString
    Else

    End If

End Code
@CODE
    Dim sty = "block"
    @If ViewBag.Database = "1" Or ViewBag.Database = "2" Then
        sty = "none"
    Else

    End If
    Dim sty2 = "table-row"
    @If ViewBag.Database = "1" Or ViewBag.Database = "2" Then
        sty2 = "none"
    Else

    End If
END CODE
<style>
    * {
        font-size: 11px;
    }

    span {
        font-size: 10px !important;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
        page-break-inside: auto !important;
        page-break-after: auto !important;
    }

    #tbDetail tr {
        border-bottom: hidden;
    }

    #dvFooter {
        display: none;
    }

    #dvForm {
        padding-right: 5px;
    }

    td textarea {
        width: 100%;
        height: 100%;border: none !important;
        resize: none !important;
    }

    textarea::placeholder {
        color: black; /* เปลี่ยนสีเป็นดำ */
    }

    .text-box {
        width: 100%;
        height: 100%;
        font-family: Roboto, -apple-system, San Francisco, Segoe UI, Helvetica Neue, sans-serif !important;
    }
</style>
<div style="text-align:center;width:100%;padding:5px 5px 5px 5px">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">JOURNAL VOUCHER</label>
</div>
<div id="dvCopy"></div>
<div id="dvForm">
    @*<div style="text-align: right;">
            <table style="width:200px;margin:0 auto;">
                <tr>
                    <td style="text-align: right;">VOUCHER NO.</td>
                    <td style="text-align: right;">________________</td>
                </tr>
                <tr>
                    <td style="text-align: right;">DATE &nbsp;</td>
                    <td style="text-align: right;">________________</td>
                </tr>
            </table>
        </div>*@

    <div style="display: flex; margin-bottom: 5px; text-align: right;">
        <div style="flex:3;">

        </div>
        <div style="flex:1;">
            <label>VOUCHER NO.</label>
            <label>________________</label>
            <br />
            <label>&nbsp; &nbsp;DATE &nbsp;</label>
            <label>________________</label>
            <br />
        </div>
    </div>

    <div style="display:flex;margin-bottom:5px;">
        <div style="flex:3;">
            REF:JOB NO.
            <label id="lblJobNo"></label>
        </div>
        <div style="flex:1;">
            &nbsp; REF:INV NO.  &nbsp;
            <label id="lblDocNo"></label>
        </div>
    </div>
    <!--<div style="display:flex;margin-bottom:5px;">
        <div style="flex:3;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;margin-right:5px">
            NAME :
            <label id="lblCustName"></label>
            <br />
            ADDRESS :
            <label id="lblCustAddress"></label>
            <br />-->
    <!--TEL : <label id="lblCustTel"></label><br />-->
    <!--<label>TAX-ID:</label>
            <label id="lblTaxNumber"></label>
            <label>BRANCH:</label>
            <label id="lblTaxBranch"></label>
            <br />
            AGENT :
            <label id="lblAgentName"></label>
        </div>
        <div style="flex:1;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;overflow-wrap:break-word;">
            INV NO. :
            <label id="lblDocNo"></label>
            <br />
            INV DATE :
            <label id="lblDocDate"></label>
            <br />
            CUST INV :
            <label id="lblCustInvNo"></label>
            <br />
            JOB NO :
            <label id="lblJobNo"></label>
            <br />
            PROJECT :
            <label id="lblProjectName"></label>
            <br />
            CR. TERM :
            <label id="lblCrTerm"></label>
            <br />
            DUE DATE :
            <label id="lblDueDate"></label>
        </div>
    </div>-->
    @*<div style="display:flex;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;margin-bottom:5px;">
            <div style="flex:2">
                <div class="row">
                    <p class="col-sm-12">
                        FROM :
                        <label id="lblFromCountry"></label> TO :
                        <label id="lblToCountry"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        PORT :
                        <label id="lblInterPort"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        FLIGHT/VESSEL :
                        <label id="lblVesselName"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        DELIVERY TO :
                        <label id="lblDeliveryTo"></label>
                    </p>
                </div>
            </div>
            <div style="flex:2">
                <div class="row">
                    <p class="col-sm-12">
                        ETD :
                        <label id="lblETDDate"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        HBL/HAWB :
                        <label id="lblHAWB"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        QUANTITY :
                        <label id="lblTotalContainer"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        BOOKING NO :
                        <label id="lblBookingNo"></label>
                    </p>
                </div>
            </div>
            <div style="flex:2">
                <div class="row">
                    <p class="col-sm-12">
                        ETA :
                        <label id="lblETADate"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        MBL/MAWB :
                        <label id="lblMAWB"></label>
                    </p>
                </div>
                <div class="row">
                    <p class="col-sm-12">
                        G.W :
                        <label id="lblNetWeight"></label>
                        <label id="lblWeightUnit"></label>
                    </p>
                </div>
            </div>
        </div>*@
    <table style="width:100%;" border="1" class="text-center">
        <thead>
            <tr style="background-color:gainsboro;text-align:center;">
                @*<th width="50px">No</th>*@
                <th width="600px">DESCRIPTION</th>
                <th width="100px">ACCT.CODE</th>
                <th width="100px">DR</th>
                @*<th width="50px">WHT</th>*@
                <th width="100px">CR</th>
            </tr>
        </thead>
        <tbody id="tbDetail"></tbody>
        <tr>
            <td colspan="6" style="border-top:solid;"></td>
        </tr>
        <tbody>
            <tr style="font-weight:bold;">
                <td colspan="1" style="text-align:center;">
                    @Code
                        If ViewBag.Database = "999" Then
                            @("")
                        Else
                            @("TOTAL")
                        End If
                    End Code

                </td>
                @*<td style="text-align: right;">
                        <label id="lblNoDiscountAdvance"></label>
                    </td>*@
                <td style="text-align: right;">
                    <label id=""></label>
                </td>
                <td style="text-align: right;">
                    <label id="lblSumTotal"></label>
                </td>
                <td style="text-align: right;">
                    <label id="lblSumTotal1"></label>
                </td>
            </tr>
            @*<tr style="font-weight:bold;display:@sty2">
                    <td colspan="2" style="text-align:right;">
                        DISCOUNT
                    </td>
                    <td style="text-align: right;">
                        (<label id="lblDiscountAdvance"></label>)
                    </td>
                    <td style="text-align: right;">
                        (<label id="lblDiscountNonVat"></label>)
                    </td>
                    <td style="text-align: right;">
                        (<label id="lblDiscountWht"></label>)
                    </td>
                    <td style="text-align: right;">
                        (<label id="lblDiscountSrvVat"></label>)
                    </td>
                </tr>*@


            @*<tr style="font-weight:bold;">
                    <td colspan="2" style="text-align:right;">
                        @Code
                            If ViewBag.Database = "999" Then
                                @("NET TOTAL")
                            Else
                                @("TOTAL")
                            End If
                        End Code

                    </td>
                    <td style="text-align: right;">
                        <label id="lblSumAdvance"></label>
                    </td>
                    <td style="text-align: right;">
                        <label id="lblSumNonVat"></label>
                    </td>
                    <td style="text-align: right;">
                        <label id="lblSumWht"></label>
                    </td>
                    <td style="text-align: right;">
                        <label id="lblSumBeforeVat"></label>
                    </td>
                </tr>*@
            @*<tr>
                    <td colspan="3">
                        <div style="display:flex">
                            <div style="text-align:left;flex:1;vertical-align:top">
                                <div id="lblShippingRemark"></div>
                                REMARKS :
                                <br />
                                <div id="lblDescription"></div>
                            </div>
                        </div>
                    </td>
                    <td colspan="2">

                        VAT (RATE=
                        <label id="lblVATRate"></label>%)
                        <br />
                        SERVICE+VAT
                        <br />
                        TOTAL
                        <div style="display:@sty">
                            CUST. ADV
                            <br />
                            GRAND TOTAL <label id="lblCurr"></label>
                        </div>
                    </td>
                    <td style="background-color :gainsboro;text-align:right;">
                        <label id="lblSumVat"></label>
                        <br />
                        <label id="lblSumAfterVat"></label>
                        <br />
                        <label id="lblSumTotal"></label>

                        <div style="display:@sty">
                            <label id="lblSumCustAdv"></label>
                            <br />
                            <label id="lblSumGrandTotal"></label>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>TOTAL (TEXT)</td>
                    <td colspan="6">
                        <div style="text-align:center;">
                            <label id="lblTotalBaht" style="font-size:12px;"></label>
                        </div>
                    </td>
                </tr>*@
        </tbody>
    </table>

    <div>
        <label>&nbsp;</label><br />
        <label>DESCRIPTION</label><br />
        <hr style="color: black; margin-top: 20px; border-top: 1px solid black;" />
        <hr style="color: black; margin-top: 20px; border-top: 1px solid black;" />
        <hr style="color: black; margin-top: 20px; border-top: 1px solid black;" /><br />
        <br />

    </div>
    <div style="display:flex;margin-top:5px">
        <div id="box1" style="font-size:10px;border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            <u>ISSUED BY:</u>
            <br />
            <br />
            <br />
            <br />
            <br />
            .........................................................
            <br />
            __________/_________/________
            <br />

        </div>
        <div id="box2" style="font-size:10px;border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            <u>AUTHORIZED BY:</u>
            <br />
            <br />
            <br />
            <br />
            <br />
            .........................................................
            <br />
            __________/_________/________
            <br />

        </div>
        @*<div id="box3" style="display:none;flex:2;border:1px solid black;border-radius:5px;text-align:left;padding:5px 5px 5px 5px;margin-right:5px">
                BANK DETAILS:<br />
                ACCOUNT NAME: @ViewBag.PROFILE_COMPANY_NAME_EN<br />
                ADD: @ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN <br />
                @Code
                    If ViewBag.Database = "1" Then
                        @<label>SIAM COMMERCIAL BANK PUBLIC COMPANY LIMITED</label>
                        @<br />
                        @<label>ACCOUNT NO: 245-211559-2 (SCB)</label>
                        @<br />
                        @<label>SWIFT CODE : SICOTHBK</label>
                    Else
                        @<label>BANK OF CHINA / SAVING</label>
                        @<br />
                        @<label>ACCOUNT NO: 100000300899322</label>
                        @<br />
                        @<label>SWIFT CODE : BKCHTHBK</label>
                        @<br />
                        @<span>**All foreign bank charges incurred are for responsibility of the sender**</span>
                    End If
                End Code
            </div>*@
        <div id="box3" style="font-size:10px;border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            <u>APPROVED BY:</u>
            <br />
            <br />
            <br />
            <br />
            <br />
            .........................................................
            <br />
            __________/_________/________
            <br />

        </div>
    </div>
</div>
@*@Code
        If ViewBag.Database = "1" Then
            @<div style="font-size:10px;page-break-inside:avoid">
                โปรดจ่ายเช็คคร่อมในนาม "@ViewBag.PROFILE_COMPANY_NAME"  หากเกินกำหนดชำระ จะต้องจ่ายดอกเบี้ย 2% ต่อเดือน จากยอดค้างทั้งหมด<br />
                ชื่อบริษัท : "@ViewBag.PROFILE_COMPANY_NAME". <span id="lblBankAccount">ธนาคาร : ไทยพาณิชย์ สาขา  ปาโซ่ทาวเวอร์   เลขที่บัญชี 245-2-13493-6</span>
                <br />
                Please issue a crossed Cheque to the order of "@ViewBag.PROFILE_COMPANY_NAME_EN"<br /> All payment are to be paid in full, interest 2% per month., will charged on all overdue payment notice
            </div>If
                If ViewBag.Database = "2" Then
            @<div style="font-size:10px;page-break-inside:avoid">
                โปรดจ่ายเช็คคร่อมในนาม "@ViewBag.PROFILE_COMPANY_NAME"  หากเกินกำหนดชำระ จะต้องจ่ายดอกเบี้ย 2% ต่อเดือน จากยอดค้างทั้งหมด<br />
                ชื่อบริษัท : "@ViewBag.PROFILE_COMPANY_NAME". <span id="lblBankAccount" style="font-size:14px">ธนาคาร : ไทยพาณิชย์ สาขา  ปาโซ่ทาวเวอร์   เลขที่บัญชี 245-2-14000-0</span>
                <br />
                ชื่อบริษัท : "@ViewBag.PROFILE_COMPANY_NAME_EN". <span id="lblBankAccount2" style="font-size:14px">ธนาคาร : SIAM COMMERCIAL BANK PUBLIC COMPANY LIMITED เลขที่บัญชี 245-2-14000-0</span>
                <br />
                Please issue a crossed Cheque to the order of "@ViewBag.PROFILE_COMPANY_NAME_EN"<br /> All payment are to be paid in full, interest 2% per month., will charged on all overdue payment notice
            </div>If
                If ViewBag.Database = "3" Then
            @<div style="font-size:10px;page-break-inside:avoid;display:none;">
                โปรดจ่ายเช็คคร่อมในนาม "@ViewBag.PROFILE_COMPANY_NAME"  หากเกินกำหนดชำระ จะต้องจ่ายดอกเบี้ย 2% ต่อเดือน จากยอดค้างทั้งหมด<br />
                ชื่อบริษัท : "@ViewBag.PROFILE_COMPANY_NAME". <span id="lblBankAccount">ธนาคาร : ไทยพาณิชย์ สาขา  ปาโซ่ทาวเวอร์   เลขที่บัญชี 245-2-13493-6</span>
                <br />
                Please issue a crossed Cheque to the order of "@ViewBag.PROFILE_COMPANY_NAME_EN"<br /> All payment are to be paid in full, interest 2% per month., will charged on all overdue payment notice
            </div>
                        End If
    End Code*@
<script type="text/javascript">
    const path = '@Url.Content("~")';

    let branch = getQueryString('branch');
    let invno = getQueryString('code');
    //if ('@ViewBag.Database' == '2') {
    //    $('#lblBankAccount').text('ธนาคาร : กสิกรไทย สาขา  สำนักสีลม   เลขที่บัญชี 040-1-14558-3')
    //}
    if (invno.substring(0, 3) == 'IVF') {
        $('#lblDocType').text('DEBIT NOTE');
        $('#box3').css('display', 'inline');
        $('#box1').css('display', 'none');
        $('#box2').css('display', 'none');
    }
    $.get(path + 'acc/getinvoice?branch=' + branch + '&code=' + invno, function (r) {
        if (r.invoice.header !== null) {
            ShowData(r.invoice);
        }
    });
    //});
    function ShowData(dr) {
        let ans = confirm('OK to print Original or Cancel For Copy');
        if (ans == true) {
            $('#dvCopy').html('<b>**ORIGINAL**</b>');
        } else {
            $('#dvCopy').html('<b>**COPY**</b>');
        }
        let h = dr.header[0][0];
	$('#lblDueDate').text(ShowDate(h.DueDate));
        if (dr.header[0].length > 0) {
            $('#lblDocNo').text(h.DocNo);
            $('#lblDocDate').text(ShowDate(CDateTH(h.DocDate)));
            $('#lblCurrencyCode').text(h.CurrencyCode);
            $('#lblExchangeRate').text(h.ExchangeRate);

            //$('#lblDiscountRate').text(h.DiscountRate);
            $('#lblVATRate').text(ShowNumber(h.VATRate, 1));

            $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch, function (r) {
                let c = r.company.data[0];
                if (c !== null) {
                    $('#lblTaxNumber').text(c.TaxNumber);
                    $('#lblCrTerm').text(c.CreditLimit);
                    if (c.UsedLanguage == 'TH') {
                        if (Number(c.Branch) == 0) {
                            $('#lblTaxBranch').text('สำนักงานใหญ่');
                        } else {
                            $('#lblTaxBranch').text('0000' + Number(c.Branch));
                        }
                        $('#lblCustName').text(c.Title + ' ' + c.NameThai);
                        $('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
                        //$('#lblCustTName').text(dr.customer[0][0].NameThai);
                    } else {
                        if (Number(c.Branch) == 0) {
                            $('#lblTaxBranch').text('HEAD OFFICE');
                        } else {
                            $('#lblTaxBranch').text('0000' + Number(c.Branch));
                        }
                        $('#lblCustName').text(c.NameEng);
                        $('#lblCustAddress').text(c.EAddress1 + '\n' + c.EAddress2);
                        //$('#lblCustTName').text(dr.customer[0][0].NameEng);
                    }
                    //$('#lblCustTel').text(c.Phone);

                }
                //companyName = c.NameEng;
                //});

                let j = dr.job[0][0];
                if (j !== null) {
                    $('#lblCustInvNo').text(j.InvNo);
                    $('#lblJobNo').text(j.JNo);
                    if (Number(j.JobType) == 1) {
                        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                        ShowCountry(path, j.InvCountry, '#lblToCountry');
                        ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#lblInterPort');
                    } else {
                        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                        ShowCountry(path, j.InvCountry, '#lblToCountry');
                        ShowInterPort(path, j.InvCountry, j.InvInterPort, '#lblInterPort');
                    }
                    //$('#lblFromCountry').text(j.DeclareNumber);
                    $('#lblVesselName').text(j.VesselName);
                    $('#lblTotalContainer').text(j.TotalContainer);
                    //ShowInvUnit(path, j.InvProductUnit, '#lblQtyUnit');
                    $('#lblNetWeight').text(j.TotalGW);
                    ShowInvUnit(path, j.GWUnit + ' ' + j.Measurement ? ' / ' + j.Measurement + ' CBM' : '', '#lblWeightUnit');
                    $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                    $('#lblHAWB').text(j.HAWB);
                    //$('#lblMeasurement').text(j.Measurement);
                    $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                    $('#lblMAWB').text(j.MAWB);
                    ShowVender(path, j.ForwarderCode, '#lblAgentName');
                    $('#lblDeliveryTo').text(j.DeliveryTo);
                    $('#lblBookingNo').text(j.BookingNo);
                    $('#lblProjectName').text(j.ProjectName);
                }
                let remark = h.Remark1;
                remark += (h.Remark2 !== '' ? '<br/>' : '') + h.Remark2;
                remark += (h.Remark3 !== '' ? '<br/>' : '') + h.Remark3;
                remark += (h.Remark4 !== '' ? '<br/>' : '') + h.Remark4;
                remark += (h.Remark5 !== '' ? '<br/>' : '') + h.Remark5;
                remark += (h.Remark6 !== '' ? '<br/>' : '') + h.Remark6;
                remark += (h.Remark7 !== '' ? '<br/>' : '') + h.Remark7;
                remark += (h.Remark8 !== '' ? '<br/>' : '') + h.Remark8;
                remark += (h.Remark9 !== '' ? '<br/>' : '') + h.Remark9;
                remark += (h.Remark10 !== '' ? '<br/>' : '') + h.Remark10;
                $('#lblDescription').html(CStr(remark));
                remark = h.ShippingRemark.replace(/(?:\r\n|\r|\n)/g, '<br/>');
                //$('#lblShippingRemark').html(remark);



                //}
                let d = dr.detail[0];
                sortData(d, 'ItemNo', 'asc');
                let companyName = '';
                let sumbase1 = 0;
                let sumbase3 = 0;
                let sumbase5 = 0;
                let sumtax1 = 0;
                let sumtax3 = 0;
                let sumtax5 = 0;
                let sumadv = 0;
                let sumserv = 0;
                let sumnonvat = 0;
                let sumdiscnovat = 0;
                let sumdiscvat = 0;
                let sumdiscadv = 0;

                let irow = 0;
                if (d.length > 0) {
                    for (let o of d) {
                        irow += 1;
                        let html = '<tr>';
                        if (irow === 1) {
                            html += `<td>` + c.NameEng + `</td><td></td><td style="text-align:right;">` + (Number(h.TotalAmt) + Number(h.Total50Tavi)) + '</td><td></td></tr><tr>';
                        }
                        //html += '<td style="text-align:center">' + irow + '</td>';
                        if (o.AmtAdvance > 0) {
                            html += '<td>' + o.SDescription + '</td>';
                            //html += '<td style="text-align:right;">' + (o.AmtAdvance > 0 ? ShowNumber(o.AmtAdvance, 2): '') +'</td>';
                            html += '<td style="text-align:right;"></td>';
                            html += '<td style="text-align:right;"></td>';
                            html += '<td style="text-align:right;">' + (o.AmtAdvance > 0 ? ShowNumber(o.AmtAdvance, 2) + '<br>' : '') + '</td>';

                        } else {
                            html += '<td>' + o.SDescription + (o.AmtDiscount > 0 ? ` (Discount : ${ShowNumber(o.Amt, 2)}-${ShowNumber(o.AmtDiscount, 2)} )` : "") + '</td>';
                            //html += '<td style="text-align:right;"></td>';
                            html += '<td style="text-align:right;"></td>';
                            html += '<td style="text-align:right;"></td>';
                            html += '<td style="text-align:right;">' + ((o.AmtVat != 0 || o.TotalAmt < 0) ? ShowNumber(o.AmtCharge + o.AmtDiscount, 2) : '') + '</td>';
                        }
                        html += '</tr>';

                        $('#tbDetail').append(html);
                        if (Number(o.AmtAdvance) > 0) {
                            sumadv += Number(o.AmtAdvance);
                            sumdiscadv += Number(o.AmtDiscount);
                        } else {

                        }
                        if (o.AmtCharge > 0 && o.AmtVat == 0) {
                            sumnonvat += Number(o.AmtCharge);
                            sumdiscnovat += Number(o.AmtDiscount);
                        } else if (o.AmtCharge > 0 && o.AmtVat > 0) {
                            sumdiscvat += Number(o.AmtDiscount);
                            sumserv += Number(o.AmtCharge);
                        } else if (o.AmtCharge < 0 && o.AmtVat < 0) {
                            //ONLY FOR CASE SPECIAL DISCOUNT(-)
                            sumserv += Number(o.AmtCharge);
                        }
                        if (o.Amt50Tavi != 0 && o.AmtCharge != 0) {
                            if (o.Rate50Tavi == 1) {
                                sumbase1 += Number((o.AmtCharge), 2);
                                sumtax1 += o.Amt50Tavi;
                            } else if (o.Rate50Tavi == 3) {
                                sumbase3 += Number((o.AmtCharge), 2);
                                sumtax3 += o.Amt50Tavi;
                            } else if (o.Rate50Tavi == 5) {
                                sumbase5 += Number((o.AmtCharge), 2);
                                sumtax5 += o.Amt50Tavi;
                            }

                        }

                    }
                }
                if ((@ViewBag.Database== 1 || @ViewBag.Database== 2) & h.TotalCustAdv > 0) {


                    irow += 1;
                    let html = '<tr>';
                    //html += '<td style="text-align:center">'+irow+'</td>';
                    //html += '<td><textarea style="border: none; width: 100%; -webkit-box-sizing: border-box; -moz-box-sizing: border-box; box-sizing: border-box; overflow:hidden; resize: none;" >CUST CUSTOMS DUTY TAX ADVANCE ( @custAdvDsc)</textarea></td>';
                    html += '<td><textarea class="text-box" style="width: 100%; height: 100%; border: none; overflow:hidden; font-family: "Roboto", -apple-system, "San Francisco", "Segoe UI", "Helvetica Neue", sans-serif;" >CUST CUSTOMS DUTY TAX ADVANCE ( @custAdvDsc)</textarea></td>';
                    //html += '<td style="text-align:right;">-'+ShowNumber(h.TotalCustAdv, 2)+'</td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '</tr>';
                    $('#tbDetail').append(html);
                }

                let rowremain = 19 - irow;
                for (let i = 1; i <= rowremain; i++) {
                    let html = '<tr>';
                    //html += '<td style="text-align:center"></td>';
                    html += '<td><br/></td>';
                    //html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '<td style="text-align:right;"></td>';
                    html += '</tr>';
                    $('#tbDetail').append(html);
                }


                $('#lblDiscountAdvance').text(ShowNumber(sumdiscadv, 2));
                $('#lblDiscountNonVat').text(ShowNumber(sumdiscnovat, 2));
                $('#lblDiscountSrvVat').text(ShowNumber(sumdiscvat, 2));

                $('#lblNoDiscountAdvance').text(ShowNumber(sumadv + sumdiscadv, 2));
                $('#lblNoDiscountSumNonVat').text(ShowNumber(sumnonvat + sumdiscnovat, 2));
                //$('#lblNoDiscountSumBeforeVat').text(ShowNumber((h.TotalIsTaxCharge + sumdiscvat) / h.ExchangeRate, 2));
                //$('#lblNoDiscountSumBeforeVat').text(ShowNumber((sumserv + sumdiscvat) / h.ExchangeRate, 2) + (sumadv + sumdiscadv, 2));

                $('#lblSumAdvance').text(ShowNumber(sumadv, 2));
                $('#lblSumNonVat').text(ShowNumber(sumnonvat, 2));
                $('#lblSumTotal').text(ShowNumber(Number(sumadv) + Number(sumnonvat) + Number(sumserv) + (Number(h.TotalVAT) / h.ExchangeRate), 2));
                $('#lblSumTotal1').text(ShowNumber(Number(sumadv) + Number(sumnonvat) + Number(sumserv) + (Number(h.TotalVAT) / h.ExchangeRate), 2));


                $('#lblSumBaseWht1').text(ShowNumber(sumbase1, 2));
                $('#lblSumBaseWht3').text(ShowNumber(sumbase3, 2));
                $('#lblSumBaseWht5').text(ShowNumber(sumbase5, 2));
                $('#lblSumWht').text(ShowNumber((sumtax1 + sumtax3) / h.ExchangeRate, 2));

                $('#lblSumWht1').text(ShowNumber(sumtax1 / h.ExchangeRate, 2));
                $('#lblSumWht3').text(ShowNumber(sumtax3 / h.ExchangeRate, 2));
                $('#lblSumWht5').text(ShowNumber(sumtax5 / h.ExchangeRate, 2));

                $('#lblSumGrandTotal').text(ShowNumber(Number(sumadv) + Number(sumnonvat) + Number(sumserv) + ((Number(h.TotalVAT) - Number(h.TotalCustAdv) - Number(h.TotalDiscount)) / h.ExchangeRate), 2));
                $('#lblForeignNet').text(ShowNumber(Number(sumadv) + Number(sumnonvat) + Number(sumserv) + ((Number(h.TotalVAT) - Number(h.Total50Tavi) - Number(h.TotalCustAdv) - Number(h.TotalDiscount)) / h.ExchangeRate), 2));
                //$('#lblSumNetInvoice').text(ShowNumber(Number(h.TotalCharge)+Number(h.TotalAdvance)+Number(h.TotalVAT)-Number(h.Total50Tavi)-Number(h.TotalDiscount),2));
                $('#lblTotalBaht').text('(' + CNumEng($('#lblSumGrandTotal').text()) + ')');

                if (@ViewBag.Database== 1 ||@ViewBag.Database== 2) {
                    $('#lblNoDiscountAdvance').text(ShowNumber(sumadv + sumdiscadv - h.TotalCustAdv, 2));
                    $('#lblDiscountAdvance').text(ShowNumber(h.TotalCustAdv, 2));
                    $('#lblSumAdvance').text(ShowNumber(sumadv - h.TotalCustAdv, 2));
                    $('#lblSumTotal').text(ShowNumber(Number(sumadv) + Number(sumnonvat) + Number(sumserv)
                        + (Number(h.TotalVAT) / h.ExchangeRate) - h.TotalCustAdv, 2));
                }


                if (h.ExchangeRate > 1) {
                    $('#lblCurr').text('(' + h.CurrencyCode + ')');
                    $('#lblSumCustAdv').text('(' + ShowNumber((h.TotalCustAdv) / h.ExchangeRate, 2) + ')');
                    //$('#lblSumBeforeVat').text(ShowNumber((h.TotalIsTaxCharge) / h.ExchangeRate, 2));
                    //$('#lblSumVat').text(ShowNumber((h.TotalVAT) / h.ExchangeRate, 2));
                    //$('#lblSumAfterVat').text(ShowNumber((Number(h.TotalIsTaxCharge) + Number(h.TotalVAT)) / h.ExchangeRate, 2));
                    $('#lblSumBeforeVat').text(ShowNumber((sumserv) / h.ExchangeRate, 2));
                    $('#lblSumVat').text(ShowNumber((h.TotalVAT) / h.ExchangeRate, 2));
                    $('#lblSumAfterVat').text(ShowNumber((Number(sumserv) + Number(h.TotalVAT)) / h.ExchangeRate, 2));
                } else {
                    $('#lblSumCustAdv').text('(' + ShowNumber(h.TotalCustAdv, 2) + ')');
                    $('#lblSumCustAdv').text('(' + ShowNumber(h.TotalCustAdv, 2) + ')');
                    //$('#lblSumBeforeVat').text(ShowNumber(h.TotalIsTaxCharge, 2));
                    //$('#lblSumVat').text(ShowNumber(h.TotalVAT, 2));
                    //$('#lblSumAfterVat').text(ShowNumber(Number(h.TotalIsTaxCharge) + Number(h.TotalVAT), 2));
                    $('#lblSumBeforeVat').text(ShowNumber(sumserv, 2));
                    $('#lblSumVat').text(ShowNumber(h.TotalVAT, 2));
                    $('#lblSumAfterVat').text(ShowNumber(Number(sumserv) + Number(h.TotalVAT), 2));

                }
            }
            );
        }
}



</script>