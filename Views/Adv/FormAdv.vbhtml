@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Advance Slip"
    ViewBag.ReportName = ""
    Dim space = "&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;"
End Code
<table id="tbAdvInfo" style="width:100%">
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>เลขที่ใบเบิก: </b>
            <label id="lblAdvNo" style="text-decoration-line:underline"></label>
            &nbsp;&nbsp;
            <b>JOB TYPE: </b>
            <label id="lblJobType" style="text-decoration-line:underline;font-weight:bold;font-size:14px"></label>
            &nbsp;&nbsp;
            <b>SHIP BY: </b>
            <label id="lblShipBy" style="text-decoration-line:underline;"></label>
        </td>
        <td align="right" style="font-size:11px">
            <input type="text" value="ใบขอเบิกจ่าย" style="text-align:center;background-color:yellow;font-weight:bold;font-size:large;" disabled />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>CUSTOMER : </b>
            <label id="lblCustCode" style="text-decoration-line:underline;"></label>
            &nbsp;&nbsp;
            <label id="lblCustName" style="text-decoration-line:underline;"></label>
        </td>
        <td align="right" style="font-size:11px">
            <b>วันที่ขอเบิก : </b>
            <label id="lblAdvDate" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="font-size:11px">
            <b>จ่ายให้ : </b>
            <label id="lblVender" style="text-decoration-line:underline;font-weight:bold;font-size:13px"></label>
        </td>
        <td align="right" colspan="2" style="font-size:11px">
            <b>ADVANCE TYPE : </b>
            <label id="lblAdvType" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>TOTAL CONTAINER : </b>
            <label id="lblTotalContainer" style="text-decoration-line:underline;"></label>
            &nbsp;&nbsp;

            <b>GROSS WEIGHT: </b>
            <label id="lblGrossWeight" style="text-decoration-line:underline;"></label>
            &nbsp;&nbsp;

            <b>CBM : </b>
            <label id="lblMeasurement" style="text-decoration-line:underline;"></label>
        </td>
        @*<td align="right" style="font-size:11px">
                <b>Request Date : </b>
                <label id="lblReqDate" style="text-decoration-line:underline;"></label>
            </td>*@
        <td align="right" style="font-size:11px">
            <b>วันที่ใช้เงิน : </b>
            <label id="lblOperaionDate" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <b>CUSTOMER INVOICE :</b>
            <label id="lblInvNo" style="text-decoration-line:underline;"></label>
        </td>
        <td>
            <b>HOUSE BL/AWB:</b>
            <label id="lblHAWBNo" style="text-decoration-line:underline;"></label>
        </td>
        <td align="right">
            <b>JOB NO :</b>
            <label id="lblJNo" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <b>ETD :</b>
            <label id="lblETDDate" style="text-decoration-line:underline;"></label>
        </td>
        <td>
            <b>ETA:</b>
            <label id="lblETADate" style="text-decoration-line:underline;"></label>
        </td>
        
    </tr>
    <tr>
        <td colspan="4">
            <b>REMARK</b>
            <label id="lblRemark" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
</table>
<br />
<table style="border-collapse:collapse;width:100%">
    <tr style="text-align:center;">
        <td style="border-style:solid;border-width:thin;font-size:11px">
            <b>DESCRIPTION</b>
        </td>
        <td style="border-style:solid;border-width:thin;font-size:11px;width:100px">
            <b>VAT</b>
        </td>
        <td style="border-style:solid;border-width:thin;font-size:11px;width:100px">
            <b>WHT</b>
        </td>

        <td style="border-style:solid;border-width:thin;font-size:11px;width:150px">
            <b>AMOUNT</b>
        </td>
    </tr>
    <tr style="height:400px;vertical-align:top">
        <td style="border-style:solid;border-width:thin;text-align:left;position:relative">
            <div id="divDesc" style="font-size:12px;padding-left:5px;"></div>
            <div id="lblPayTo" style="position:absolute;bottom:0;font-weight:bold;font-size:14px;padding:5px 5px 5px 5px;">
            </div>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right">
            <div id="divVat" style="font-size:12px"></div>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right">
            <div id="divWht" style="font-size:12px"></div>
        </td>

        <td style="border-style:solid;border-width:thin;text-align:right">
            <div id="divAmt" style="font-size:12px"></div>
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px" colspan="2">
            <input type="checkbox" id="chkCash" /> CASH :
            <label id="lblAccNo">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label>
            <label id="txtAdvCash">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="100px">Amount</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border:none;text-align:right;font-size:11px" id="txtAmt" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px" colspan="2">
            <input type="checkbox" id="chkCompChq" /> TRANSFER :
            <label id="lblCompChqNo">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label>:
            <label id="txtAdvChqCash">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="100px">WH-Tax</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border: none; text-align: right; font-size: 11px; width: 100%" id="txtWHTAmt" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px" colspan="2">
            <input type="checkbox" id="chkCustChq" /> CHQ NO :
            <label id="lblcustChqNo" style="width:50px">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label> DATE :
            <label id="lblDepDate" style="width:50px">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label> CHQ.AMT :
            <label id="txtAdvChq" style="width:50px">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="100px">VAT</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border: none; text-align: right; font-size: 11px; width: 100%" id="txtVATAmt" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px;" colspan="2">
            &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;บัญชีผู้ตรวจสอบใบขอเบิกจ่าย&emsp;_______________________________
            @*<input type="checkbox" id="chkCredit" /> ACCOUNT PAYABLES :__________________ <label id="txtAdvCred"></label>*@
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:14px;" width="100px">Net Total</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border: none; text-align: right; font-size: 14px; width: 100%" id="txtNetAmt" />
        </td>
    </tr>
    <!--<tr>-->
    <!--<td style="text-align:left;font-size:11px;">
        <b> Customer payment : ______________  <label id="txtCustomerPayment"> </label></b>
    </td>-->
    <!--<td></td>
        <td style="border-style: solid; border-width: thin; text-align: right; font-weight: bold;" width="130px"><label style="color: red;font-size: 14px;">Customer Payment</label></td>
        <td style="border-style: solid; border-width: thin; font-size: 16px" width="150px">
            <input type="text" style="border: none; text-align: right; color: red; font-size: 14px; width: 100%; font-weight: bold;" id="txtCustomerPayment2" />
        </td>
    </tr>-->
</table>
            **ADVANCE WAIT FOR CLEAR AT @DateTime.Now IS
            <label id="lblPendingAmount">0.00</label>**
            <br />
            <div style="width:100%;text-align:right">
                <b style="font-size:14px">
                    ( จำนวนเงินที่ต้องจ่าย :
                    <label style="font-size:14px;" id="txtTotal"></label> )
                </b>
            </div>
           

            <input type="text" id="txtTotalText" value="ZERO BAHT ONLY" style="font-size:14px;color:black;background-color:yellow;font-weight:bold;text-align:center;width:100%;" disabled />
            <br />

            <br />
            <br />
            ( ผู้จัดทำ ผู้อนุมัติ และบัญชีผู้ตรวจสอบ ลงนามเซ็นชื่อรับทราบ และยืนยันความถูกต้อง ว่าได้มีการตรวจสอบข้อมูลการเบิกจ่ายว่าเป็นข้อมูลที่ใช้ในงานอย่างถูกต้อง ก่อนที่จะให้ผู้บริหารโอนจ่ายหรือทำเช็คจ่าย หากมีความเสียหายเกิดขึ้นหรือข้อมูลที่ให้ไม่เป็นความจริง ยินดีรับผิดชอบความเสียหายนั้นทั้งหมดครบถ้วนสมบูรณ์ )
            <br />
            <br />
            <table style="border-collapse:collapse;width:100%">
                <tr>
                    <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                        ADVANCE.BY
                    </td>
                    <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                        REQUEST.BY
                    </td>
                    <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                        APPROVE.BY
                    </td>
                    <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                        RECEIVED.BY
                    </td>
                    @*<td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                        POSTED.BY
                    </td>*@
                    <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
                        CLEARED.BY
                    </td>
                </tr>

                <tr>
                    <td style="border-style: solid; border-width: thin; text-align: center; vertical-align: bottom; width: 20%" height="100px">
                        <label id="lblAdvBy" style="font-size:10px">(__________________)</label>
                        <br />
                        <label id="lblAdvDate" style="font-size:9px">__/__/____</label>
                    </td>
                    <td style="border-style: solid; border-width: thin; text-align: center; vertical-align: bottom; width: 20%" height="100px">
                        <label id="lblReqBy" style="font-size:10px">(__________________)</label>
                        <br />
                        <label id="lblRequestDate" style="font-size:9px">__/__/____</label>
                    </td>
                    <td style="border-style: solid; border-width: thin; text-align: center; vertical-align: bottom; width: 20%">
                        <label id="lblAppBy" style="font-size:10px">(__________________)</label>
                        <br />
                        <label id="lblAppDate" style="font-size:9px">__/__/____</label>
                    </td>
                    <td style="border-style: solid; border-width: thin; text-align: center; vertical-align: bottom; width: 20%">
                        <label id="lblPayBy" style="font-size:10px">(__________________)</label>
                        <br />
                        <label id="lblPayDate" style="font-size:9px">__/__/____</label>
                    </td>
                    @*<td style="border-style: solid; border-width: thin; text-align: center; vertical-align: bottom; width: 20%">
            <label id="lblPostBy" style="font-size:9px">(__________________)</label>
            <br />
            <label id="lblPostDate" style="font-size:9px">__/__/____</label>
        </td>*@
                    <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom;width:20%">
                        <label id="lblClrBy" style="font-size:9px">(__________________)</label>
                        <br />
                        <label id="lblClrDate" style="font-size:9px">__/__/____</label>
                    </td>
                </tr>
            </table>

            <script type="text/javascript">
    const path = '@Url.Content("~")';
    let serv = [];
    //$(document).ready(function () {
        let branch = getQueryString('branch');
        let advno = getQueryString('advno');
        if (branch != "" && advno != "") {
            GetAdv(branch, advno);
        }
    //});
    function GetAdv(Branch, Doc) {
        $.get(path +'adv/getadvance?branchcode=' + Branch + '&advno=' + Doc)
            .done(function (r) {
                if (r.adv.header.length > 0) {
                    ShowData(r);
                    return;
                }
            });
    }
    function LoadServices(d,h) {
        $.get(path +'Master/GetServiceCode')
            .done(function (r) {
                serv = r.servicecode.data;
                ShowDetail(d,h);
            });
    }
    function ShowPendingAmount(branch, reqby) {
        $.get(path + 'Clr/GetAdvForClear?show=NOCLR&branchcode=' + branch + '&reqby=' + reqby)
            .done(function (r) {
                if (r.clr.data.length > 0) {
                    let d = r.clr.data[0].Table;
                    let sum = d.map(item => item.AdvBalance).reduce((prev, next) => prev + next);
                    $('#lblPendingAmount').text(ShowNumber(sum, 2));
                }
            });
    }
    function ShowData(data) {
        //show headers
        let h = data.adv.header[0];
        $('#lblAdvNo').text(h.AdvNo);
        $('#lblReqDate').text(ShowDate(GetToday()));
        $('#lblOperaionDate').text(ShowDate(h.PayChqDate));
        $('#lblCustCode').text(h.CustCode + '/' + h.CustBranch);
        $('#lblRemark').text(h.TRemark);
        $('#lblVender').text(data.adv.detail.length > 0 ? data.adv.detail[0].PayChqTo:"");
        $('#lblAdvDate').text(ShowDate(h.AdvDate));
        $('#lblPayTo').html(h.PayChqTo);
        ShowPendingAmount(h.BranchCode, h.EmpCode);
        ShowCustomer(h.CustCode, h.CustBranch);

        ShowUserSign(path, h.AdvBy, '#lblAdvBy');
        ShowUserSign(path,h.EmpCode, '#lblReqBy');
        ShowUserSign(path,h.ApproveBy, '#lblAppBy');
        ShowUserSign(path,h.EmpCode, '#lblPayBy');

        $('#lblAdvDate').text(ShowDate(h.AdvDate));
        $('#lblRequestDate').text(ShowDate(h.AdvDate));
        $('#lblAppDate').text(ShowDate(h.ApproveDate));
        $('#lblPayDate').text(ShowDate(h.PaymentDate));

        let jt = h.JobType;
        let sb = h.ShipBy;
        let at = h.AdvType;
        if (jt < 10) jt = '0' + jt;
        if (sb < 10) sb = '0' + sb;
        if (at < 10) at = '0' + at;
        ShowConfig(path, 'JOB_TYPE', jt, '#lblJobType');

            $("#lblJobType").css("color", jt === 1?"orange":"green")

        ShowConfig(path,'SHIP_BY', sb, '#lblShipBy');
        ShowConfig(path,'ADV_TYPE', at, '#lblAdvType');
        if (h.AdvCash > 0) {
            $('#chkCash').prop('checked', true);
            $('#txtAdvCash').text(ShowNumber(h.AdvCash, 2) + ' ' + h.SubCurrency);
        }
        if (h.AdvChq > 0) {
            $('#chkCustChq').prop('checked', true);
            $('#txtAdvChq').text(ShowNumber(h.AdvChq, 2) + ' ' + h.SubCurrency);
        }
        if (h.AdvChqCash > 0) {
            $('#chkCompChq').prop('checked', true);
            $('#txtAdvChqCash').text(ShowNumber(h.AdvChqCash, 2) + ' ' + h.SubCurrency);
        }
        //if (h.AdvCred > 0) {
        //    $('#chkCredit').prop('checked', true);
        //    $('#txtAdvCred').text(ShowNumber(h.AdvCred, 2) + ' ' + h.SubCurrency);
        //}
        $('#txtNetAmt').val(CCurrency(h.TotalAdvance.toFixed(2)));
        $('#txtVATAmt').val(CCurrency(h.TotalVAT.toFixed(2)));
        $('#txtWHTAmt').val(CCurrency(h.Total50Tavi.toFixed(2)));

        //$('#txtTotalAmt').val(CCurrency((h.TotalAdvance + h.Total50Tavi).toFixed(2)));
        $('#txtCustomerPayment').text(CCurrency((h.TotalAdvance + h.Total50Tavi).toFixed(2)));
        $('#txtCustomerPayment2').val(CCurrency((h.TotalAdvance + h.Total50Tavi).toFixed(2)));
        $('#txtTotalText').val(CNumThai((h.TotalAdvance).toFixed(2)));
        $('#txtTotal').text(CCurrency((h.TotalAdvance).toFixed(2)));
        //show details
        let d = data.adv.detail;
        let jobno = d[0].ForJNo;
        $('#lblJNo').text(jobno);


        $.get(path + 'JobOrder/GetJobSql?BranchCode=' + h.BranchCode + '&JNo=' + jobno).done(function (r) {
            if (r.job.data.length > 0) {
                let j = r.job.data[0];
                $('#lblInvNo').text(j.InvNo);
                $('#lblHAWBNo').text(j.HAWB);
                $('#lblTotalContainer').text(j.TotalContainer);
                $('#lblMeasurement').text(j.Measurement);
                $('#lblGrossWeight').text(j.TotalGW + " " + j.GWUnit);
                $('#lblETDDate').text(ShowDate(j.ETDDate));
                $('#lblETADate').text(ShowDate(j.ETADate));
                

            }
        });
        LoadServices(d,h);
    }
    function ShowCustomer(Code, Branch) {
        $('#lblCustName').text('-');
        if ((Code + Branch).length > 0) {
            $.get(path +'Master/GetCompany?Code=' + Code + '&Branch=' + Branch)
                .done(function (r) {
                    if (r.company.data.length > 0) {
                        let c = r.company.data[0];
                        $('#lblCustName').text(c.NameThai);
                    }
                });
        }
    }
    function ShowDetail(dr,h) {
        //Dummy Data
        let strDesc = '';
        let strJob = '';
        let strAmt = '';
        let strWht = '';
        let strVat = '';
        let totAmt = 0;
        //let vat = 0;
        //let wht = 0;
        let r = dr;
        sortData(r, 'TRemark', 'asc');
        let venCode = 'tmp';
        for (i = 0; i < r.length; i++) {
            let d = r[i];
            if (d.TRemark !== venCode) {
                venCode = d.TRemark;
                strDesc += '<b>' + d.TRemark + '</b><br/>';
                strAmt += '<br/>';
                strWht += '<br/>';
                strVat+= '<br/>';
            }
            if (serv.length > 0) {
                let c = $.grep(serv, function (data) {
                    return data.SICode === d.SICode;
                });
                if (c.length > 0) {
                    strDesc = strDesc + (d.SICode + '-' + d.SDescription + '<br/>');
                } else {
                    strDesc = strDesc + d.SDescription+ '<br/>';
                }
            } else {
                strDesc = strDesc + (d.SICode + '<br/>');
            }
            strAmt = strAmt + (CCurrency((d.AdvAmount).toFixed(3)) + '<br/>');
            strWht = strWht + (CCurrency((d.Charge50Tavi).toFixed(3)) + '<br/>');
            strVat = strVat + (CCurrency((d.ChargeVAT).toFixed(3)) + '<br/>');
            totAmt += d.AdvAmount;
            //vat += d.ChargeVAT;
            //wht += d.Charge50Tavi;
        }
        $('#divDesc').html(strDesc);
        $('#divWht').html(strWht);
        $('#divAmt').html(strAmt);
        $('#divVat').html(strVat);
	$('#txtAmt').val(CCurrency(totAmt.toFixed(2)))
    }

            </script>