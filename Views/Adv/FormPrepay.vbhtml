@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.Title = "Advance Prepay"
    ViewBag.ReportName = ""
    Dim space = "&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;"
End Code
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
</style>
<div>
    <div style="flex:3;padding:5px 5px 5px 5px;margin-right:5px">
        <label id="lblCustName" style="font-size:16px;font-weight:bold"></label>
        <br />
        <label id="lblCustAddress"></label>
        <br />
        <label>TAX-ID:</label>
        <label id="lblTaxNumber"></label>
        <br />
        AGENT :
        <label id="lblAgentName"></label>
    </div>
</div>
<div style="text-align:center;width:100%;padding:5px 5px 5px 5px">
    <label id="lblDocType" style="font-size:16px;font-weight:bold">The submission request to pay the tax first ( ใบยื่นยันขอให้ชำระภาษีไปก่อน )</label>
</div>
<div id="dvCopy"></div>
<div id="dvForm">
    <div style="display:flex;margin-bottom:5px;">
        <div style="flex:3;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;margin-right:5px">
            NAME :
            <label>@ViewBag.PROFILE_COMPANY_NAME_EN</label>
            <br />
            ADDRESS :
            <label>@ViewBag.PROFILE_COMPANY_ADDR1_EN @ViewBag.PROFILE_COMPANY_ADDR2_EN </label>
            <br />
            TEL : <label>@ViewBag.PROFILE_COMPANY_TEL </label><br />
            FAX :<label>@ViewBag.PROFILE_COMPANY_FAX</label>
            <label>TAX-ID:</label>
            <label>@ViewBag.PROFILE_TAXNUMBER</label> สาขา: สำนักงานใหญ่
            @*<label>BRANCH:</label>
                <label id="lblTaxBranch"></label>
                <br />
                AGENT :
                <label id="lblAgentName"></label>*@
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
            <label id="lblJNo"></label>
            <br />
            PROJECT :
            <label id="lblProjectName"></label>
        </div>
    </div>
    <div style="display:flex;border:1px solid black;border-radius:5px;padding:5px 5px 5px 5px;margin-bottom:5px;">
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

    </div>
    <div style="padding:5px;">
        <label>Please make a trial payment on behalf of my company first  โปรดชำระเงินทดลองจ่ายแทนบริษัทฯข้าพเจ้าไปก่อน</label>
    </div>

    <table style="border-collapse:collapse;width:100%">
        <tr style="text-align:center;">
            <td style="border-style:solid;border-width:thin;font-size:11px">
                <b>No.</b>
            </td>
            <td style="border-style:solid;border-width:thin;font-size:11px">
                <b>Description</b>
            </td>
            <td style="border-style:solid;border-width:thin;font-size:11px">
                <b>Advance</b>
            </td>
        </tr>
        <tr style="height:100px;vertical-align:top">
            <td style="border-style:solid;border-width:thin;text-align:left;position:relative">
                <div id="divNo" style="font-size:12px;padding-left:5px;"></div>
            </td>
            <td style="border-style:solid;border-width:thin;text-align:right">
                <div id="divDesc" style="font-size:12px"></div>
            </td>
            <td style="border-style:solid;border-width:thin;text-align:right">
                <div id="divAmt" style="font-size:12px"></div>
            </td>
        </tr>
    </table>
    <div style="padding:5px;">
        <label>บริษัทฯจะชำระเงินทดลองจ่ายคืนภายใน 7 วันนับจากวันที่สำรองจ่ายตามใบเสร็จรับเงิน หากเกินกำหนด 7 วัน</label><br />
        <label>ค่าทดลองงจ่ายให้พร้อมดอกเบี้ยชำระล่าช้า 5%</label><br /><br /><br /><br />
        <label>การคิดอัตราดอกเบี้ยนี้จะยึดจากวันโอนเงินคืนค่าภาษี</label>
    </div>

    <!--<div id="divInterest" style="display:none; margin-top:10px;">
        <table style="border-collapse:collapse; width:100%; font-size:11px;">
            <thead>
                <tr style="text-align:center;">
                    <td style="border:1px solid black; width:30%;"><b>Free time 7 วัน วันที่ต้องชำระโดยไม่มีดอกเบี้ย</b></td>
                    <td style="border:1px solid black; width:30%;"></td>
                    <td style="border:1px solid black; width:20%;"></td>
                    <td style="border:1px solid black; width:20%;"><b><span id="lblFreeTimeEndDate"></span></b></td>
                </tr>
            </thead>
            <tbody id="tbInterestBody">
            </tbody>
        </table>-->
    @* <div style="font-size:10px; margin-top:5px;">การคิดอัตราดอกเบี้ยนี้จะยึดจากวันโอนเงินคืนค่าภาษี</div>*@
    <!--</div>-->

    @Code
        Dim duedays As Integer = 7
        Dim intRates As Integer = 0.05
        Dim sql = "
select *,
TotalNet*" & intRates & " as Interests
from (
select h.PaymentDate,h.AdvNo,
DATEDIFF(day,h.PaymentDate,GetDate())-" & duedays & " as OverDue,
sum(d.AdvNet) as TotalNet
from Job_AdvDetail d inner join Job_AdvHeader h
on d.AdvNo=h.AdvNo and d.BranchCode=h.BranchCode
where h.DocStatus>2 and isnull(Cancelprove,'')=''
and h.CustCode in(select CustCode from Job_AdvHeader where BranchCode='{0}' AND AdvNo='{1}')
and h.PaymentDate is not null
and not exists(
select 1 from Job_ClearDetail cd inner join Job_ClearHeader ch
on cd.ClrNo=ch.ClrNo and cd.BranchCode=ch.BranchCode
where ch.DocStatus<>99
and cd.AdvNo=d.AdvNo and cd.AdvItemNo=d.ItemNo
)
group by h.PaymentDate,h.AdvNo
) t
where OverDue>0
"
        Dim branch = Request.QueryString("Branch")
        Dim advno = Request.QueryString("AdvNo")
        sql = String.Format(sql, branch, advno)
        Dim obj As New jobonline.CUtil(ViewBag.CONNECTION_JOB)
        Dim dt As New Data.DataTable
        If ViewBag.User <> "" Then
            dt = obj.GetTableFromSQL(sql)
        End If
    End Code
    @If dt.Rows.Count > 0 Then
        If Not DBNull.Value.Equals(dt.Rows(0)("AdvNo")) Then
            @<table style="width:100%">
                @For each dr As Data.DataRow In dt.Rows
                    @<tr>
                        <td>@Convert.ToDateTime(dr("PaymentDate")).ToString("dd/MM/yyyy")</td>
                        <td>@dr("AdvNo")</td>
                        <td>@dr("OverDue")</td>
                        <td>@dr("Interests")</td>
                        <td>@dr("TotalNet")</td>
                    </tr>
                Next
            </table>
        End If
    End If
    <div style="display:flex;margin-top:5px">
        <div id="box1" style="font-size:10px;border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            FOR <label id="lblCustNameSign"></label>
            <br />
            <br />
            <br />
            <br />
            @*<br />*@
            @*.........................................................*@
            @*<br />*@
            ___________________________
            <br />
            AUTHORIZED SIGNATURE
        </div>
        <div id="box2" style="font-size:10px;border:1px solid black;border-radius:5px;flex:1;text-align:center;padding:5px 5px 5px 5px;margin-right:5px">
            FOR @ViewBag.PROFILE_COMPANY_NAME_EN
            <br />
            <br />
            <br />
            <br />
            @*<br />*@
            @*.........................................................*@
            @*<br />*@
            ___________________________
            <br />
            AUTHORIZED SIGNATURE

        </div>
    </div>

</div>
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
                    let d = r.clr.data[0];
                    let sum = d.map(item => item.AdvBalance).reduce((prev, next) => prev + next);
                    $('#lblPendingAmount').text(ShowNumber(sum, 2));
                }
            });
    }
    function ShowData(data) {

        let h = data.adv.header[0];
        $('#lblDocNo').text(h.AdvNo);
        $('#lblReqDate').text(ShowDate(GetToday()));
        $('#lblCustCode').text(h.CustCode + '/' + h.CustBranch);
        $('#lblRemark').text(h.TRemark);
        $('#lblDocDate').text(ShowDate(h.AdvDate));
        $('#lblPayTo').html(h.PayChqTo);
        ShowPendingAmount(h.BranchCode, h.EmpCode);
        ShowCustomer(h.CustCode, h.CustBranch);

        ShowUserSign(path,h.EmpCode, '#lblReqBy');
        ShowUserSign(path,h.ApproveBy, '#lblAppBy');
        ShowUserSign(path,h.EmpCode, '#lblPayBy');

        $('#lblRequestDate').text(ShowDate(h.AdvDate));
        $('#lblAppDate').text(ShowDate(h.ApproveDate));
        $('#lblPayDate').text(ShowDate(h.PaymentDate));

        let jt = h.JobType;
        let sb = h.ShipBy;
        let at = h.AdvType;
        if (jt < 10) jt = '0' + jt;
        if (sb < 10) sb = '0' + sb;
        if (at < 10) at = '0' + at;
        ShowConfig(path,'JOB_TYPE', jt, '#lblJobType');
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
        $('#txtTotalText').val(CCurrency((h.TotalAdvance + h.Total50Tavi).toFixed(2)));
        //show details
        let d = data.adv.detail;
        let jobno = d[0].ForJNo;
        $('#lblJNo').text(jobno);
        $.get(path + 'JobOrder/GetJobSql?BranchCode=' + h.BranchCode + '&JNo=' + jobno).done(function (r) {
            if (r.job.data.length > 0) {
                let j = r.job.data[0];

                $('#lblInvNo').text(j.InvNo);
                $('#lblHAWBNo').text(j.HAWB);
                $('#lblCustInvNo').text(j.InvNo);
                $('#lblProjectName').text(j.ProjectName);


                if (Number(j.JobType) == 1) {
                    ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                    ShowCountry(path, j.InvCountry, '#lblToCountry');
                    ShowInterPort(path, j.InvFCountry, j.InvInterPort, '#lblInterPort');
                } else {
                    ShowCountry(path, j.InvFCountry, '#lblFromCountry');
                    ShowCountry(path, j.InvCountry, '#lblToCountry');
                    ShowInterPort(path, j.InvCountry, j.InvInterPort, '#lblInterPort');
                }

                $('#lblVesselName').text(j.VesselName);
                $('#lblTotalContainer').text(j.TotalContainer);
                $('#lblNetWeight').text(j.TotalGW);

                let weightUnitText = (j.GWUnit || '') + (j.Measurement ? ' / ' + j.Measurement + ' CBM' : '');
                ShowInvUnit(path, weightUnitText, '#lblWeightUnit');

                $('#lblETDDate').text(ShowDate(CDateTH(j.ETDDate)));
                $('#lblHAWB').text(j.HAWB);
                $('#lblETADate').text(ShowDate(CDateTH(j.ETADate)));
                $('#lblMAWB').text(j.MAWB);
                ShowVender(path, j.ForwarderCode, '#lblAgentName');
                $('#lblDeliveryTo').text(j.DeliveryTo);
                $('#lblBookingNo').text(j.BookingNo);
                // ------------------------------
            } else {
                console.warn("No job data found.");
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
                        $('#lblCustNameSign').text(c.NameThai);
                        $('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
                        $('#lblTaxNumber').text(c.TaxNumber);
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
        let totAmt = 0;
        //let vat = 0;
        //let wht = 0;
        let strNo = '';
        let r = dr;
        sortData(r, 'TRemark', 'asc');
        let venCode = 'tmp';
        let rowNum = 0;
        for (i = 0; i < r.length; i++) {

            let d = r[i];
            console.log(d);
            //if (d.TRemark !== venCode) {
            //    venCode = d.TRemark;
            //    strDesc += '<b>' + d.TRemark + '</b><br/>';
            //    strAmt += '<br/>';
            //    strWht += '<br/>';
            //    strNo += '<br/>';
            //}
            rowNum++;
            strNo += rowNum + '.<br/>';
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
            totAmt += d.AdvAmount;
            //vat += d.ChargeVAT;
            //wht += d.Charge50Tavi;
        }
        $('#divNo').html(strNo);
        $('#divDesc').html(strDesc);
        $('#divWht').html(strWht);
        $('#divAmt').html(strAmt);
        $('#txtAmt').val(CCurrency(totAmt.toFixed(2)))
        if (totAmt > 0) {
            CalculateInterest(totAmt, h.AdvDate);
        }
    }
    function CalculateInterest(baseAmount, startDateStr) {
        let html = '';
        let startDate = new Date(startDateStr);

        let freeTimeDate = new Date(startDate);
        freeTimeDate.setDate(freeTimeDate.getDate() + 7);
        $('#lblFreeTimeEndDate').text(ShowDate(freeTimeDate)); // แสดงวันที่ครบกำหนดด้านบนขวา


        let interestRate = 0.05; // 5%
        let currentTotal = baseAmount;

        for (let i = 1; i <= 22; i++) {
            let rowDate = new Date(freeTimeDate);
            rowDate.setDate(rowDate.getDate() + i);

            let dailyInterest = (baseAmount * interestRate) / 12;
            currentTotal += dailyInterest;

            html += `<tr>
            <td style="border:1px solid black; padding-left:10px;">${ShowDate(rowDate)}</td>
            <td style="border:1px solid black; padding-left:10px;">Advance + Interest</td>
            <td style="border:1px solid black; text-align:right; padding-right:5px;">${CCurrency(dailyInterest.toFixed(2))}</td>
            <td style="border:1px solid black; text-align:right; padding-right:5px;">${CCurrency(currentTotal.toFixed(2))}</td>
        </tr>`;
        }

        $('#tbInterestBody').html(html);
        $('#divInterest').show();
    }

</script>