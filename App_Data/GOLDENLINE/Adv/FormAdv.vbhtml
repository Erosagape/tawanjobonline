@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Advance Slip"
    ViewBag.ReportName = ""
End Code
<table id="tbAdvInfo" style="width:100%">
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>Advance No : </b>
            <label id="lblAdvNo" style="text-decoration-line:underline"></label>
        </td>
        <td align="right" style="font-size:11px">
            <input type="text" value="ADVANCE" style="text-align:center;background-color:yellow;font:bold;font-size:large;" disabled />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>Customer : </b>
            <label id="lblCustCode" style="text-decoration-line:underline;"></label>
            <br />
            <label id="lblCustName" style="text-decoration-line:underline;"></label>
            <div style="width:100%;display:flex">
                <div style="flex:1">
                    <b>Consignee : </b>
                    <label style="text-decoration-line:underline;" id="lblConsName"></label>
                </div>
            </div>
        </td>
        <td align="right" style="font-size:11px">
            <b>Request Date : </b>
            <label id="lblAdvDate" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="font-size:11px">
            <b>Job Type : </b>
            <label id="lblJobType" style="text-decoration-line:underline;"></label>
            <b>Ship By : </b>
            <label id="lblShipBy" style="text-decoration-line:underline;"></label>
        </td>
        <td align="right" colspan="2" style="font-size:11px">
            <b>Advance Type : </b>
            <label id="lblAdvType" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>Pay To :</b>
            <label id="lblPayTo" style="text-decoration-line:underline;"></label>
        </td>
        <td align="right" style="font-size:11px">
            <b>Request By : </b>
            <label id="lblReqBy" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <div id="divJob"></div>
        </td>
    </tr>
</table>
<table style="border-collapse:collapse;width:100%">
    <tr style="text-align:center;">
        <td style="border-style:solid;border-width:thin;font-size:11px;width:15%">
            <b>A/C Code</b>
        </td>
        <td style="border-style:solid;border-width:thin;font-size:11px;width:45%">
            <b>Advance Expenses</b>
        </td>
        <td style="border-style:solid;border-width:thin;font-size:11px;width:10%">
            <b>Quantity</b>
        </td>
        <td style="border-style:solid;border-width:thin;font-size:11px;width:15%">
            <b>Unit Price</b>
        </td>
        <td style="border-style:solid;border-width:thin;font-size:11px;width:15%">
            <b>Total</b>
        </td>
    </tr>
    <tr style="height:350px;vertical-align:top">
        <td style="border-style:solid;border-width:thin;text-align:center">
            <div id="divCode" style="font-size:12px"></div>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:left">
            <div id="divDesc" style="font-size:12px"></div>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right">
            <div id="divQty" style="font-size:12px"></div>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right">
            <div id="divPrice" style="font-size:12px"></div>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right">
            <div id="divAmt" style="font-size:12px"></div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            CODE - ADV : เก็บเงินลูกค้า / Invoice to Customer
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="130px">Net Amount</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border:none;text-align:right;font-size:11px" id="txtTotalAmt" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            CODE - CST : ค่าใช้จ่ายบริษัท / Company Expenses
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="130px">
            VAT
        </td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border:none;text-align:right;font-size:11px" id="txtVATAmt" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px" colspan="3">
            <input type="checkbox" id="chkCash" /> CASH/TRANSFER :
            <label id="lblAccNo">______________</label>
            <label id="txtAdvCash"></label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="130px">WH-Tax</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border:none;text-align:right;font-size:11px" id="txtWHTAmt" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px" colspan="3">
            <input type="checkbox" id="chkCustChq" /> CUST.CHQ NO :
            <label id="lblcustChqNo">__________</label> DEP.DATE :
            <label id="lblDepDate">________</label>
            <label id="txtAdvChqCash"></label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:right;font-size:11px" width="130px">Total</td>
        <td style="border-style:solid;border-width:thin" width="150px">
            <input type="text" style="border:none;text-align:right;font-size:11px" id="txtNetAmt" />
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px" colspan="5">
            <input type="checkbox" id="chkCompChq" /> CHQ NO :
            <label id="lblCompChqNo">__________</label> CHQ.DATE :
            <label id="lblChqDate">________</label>
            <label id="txtAdvChq"></label>
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:11px;" colspan="5">
            <input type="checkbox" id="chkCredit" /> ACCOUNT PAYABLES :__________________
            <label id="txtAdvCred"></label>
        </td>
    </tr>
</table>
**Accumulated Advance Cash By User Requested at @DateTime.Now is
<label id="lblPendingAmount">0.00</label>**
<br />
TOTAL :
<br />
<input type="text" id="txtTotalText" value="ZERO BAHT ONLY" style="font-size:11px;background-color:burlywood;font:bold;text-align:center;width:90%;" disabled />

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
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>

        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <br />
            <label style="font-size:9px">(________________________________________)</label>
            <br />
            <label style="font-size:9px">วันที่/Date_______/______________/__________</label>
        </td>
    </tr>
</table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let serv = [];
    let venders = [];
    //$(document).ready(function () {
    let branch = getQueryString('branch');
    let advno = getQueryString('advno');
    if (branch != "" && advno != "") {
        $.get(path + 'master/getvender').done(function (r) {
            if (r.vender.data.length > 0) {
                venders = r.vender.data;
            }
            GetAdv(branch, advno);
        });
    }
    //});
    function GetAdv(Branch, Doc) {
        $.get(path +'adv/getadvancereport?branchcode=' + Branch + '&advno=' + Doc)
            .done(function (r) {
                if (r.adv.data.length > 0) {
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
        let h = data.adv.data[0].Table[0];
        $('#lblAdvNo').text(h.AdvNo);
        $('#lblCustCode').text(h.CustCode + '/' + h.CustBranch);
        //$('#lblRemark').text(h.TRemark);
        $('#lblAdvDate').text(ShowDate(h.AdvDate));
        //$('#lblPayTo').text(h.PayChqTo);
        $('#lblReqBy').text(h.EmpCode);
        ShowPendingAmount(h.BranchCode, h.EmpCode);
        ShowCustomer(h.CustCode, h.CustBranch);
        CallBackQueryCustomerSingle(path, h.consigneecode, function (c) {
            $('#lblConsName').text(c.NameThai);
        });

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
        if (h.AdvCred > 0) {
            $('#chkCredit').prop('checked', true);
            $('#txtAdvCred').text(ShowNumber(h.AdvCred, 2) + ' ' + h.SubCurrency);
        }
        $('#txtNetAmt').val(CCurrency(h.TotalAdvance.toFixed(2)));
        $('#txtVATAmt').val(CCurrency(h.TotalVAT.toFixed(2)));
        $('#txtWHTAmt').val(CCurrency(h.Total50Tavi.toFixed(2)));
        $('#txtTotalAmt').val(CCurrency((h.TotalAdvance - h.TotalVAT + h.Total50Tavi).toFixed(2)));

        $('#txtTotalText').val(CNumEng(CCurrency((h.TotalAdvance - h.TotalVAT + h.Total50Tavi).toFixed(2))));
        //show details
        let d = data.adv.data[0].Table;
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
        let strCode = '';
        let strDesc = '';
        let strJob = '';
        let strAmt = '';
        let strPrice = '';
        let strQty = '';
        let totAmt = 0;
        let listJob = [];
        //let vat = 0;
        //let wht = 0;
        let r = JSON.parse(JSON.stringify(dr));
        sortData(r, 'ForJNo', 'asc');
        for (i = 0; i < r.length; i++) {
            let d = r[i];
            if (d.ForJNo !== '') {
                if (listJob.indexOf(d.ForJNo) < 0) {
                    let v = $.grep(venders, function (data) {
                        return data.VenCode === d.ForwarderCode;
                    });
                    strJob = '<b>Job Number :</b><span style="text-decoration-line:underline;">' + ((d.ForJNo == null || d.ForJNo == '' ? '' : d.ForJNo) + ((d.CustInvNo==null?'':' INV#:'+ d.CustInvNo)) + '</span><br/>');
                    strJob = strJob + '<b>Container :</b><span style="text-decoration-line:underline;">' + ((d.TotalContainer == null || d.TotalContainer == '' ? '' : d.TotalContainer) + '</span><br/>');
                    strJob = strJob + '<b>BL/AWB :</b><span style="text-decoration-line:underline;">' + ((d.HAWB == null || d.HAWB == '' ? '' : d.HAWB) + '</span><br/>');
                    if (v.length > 0) {
                        strJob = strJob + '<b>Agent :</b><span style="text-decoration-line:underline;">' + (v[0].TName + '</span><br/>');
                    } else {
                        strJob = strJob + '<b>Agent :</b><span style="text-decoration-line:underline;">' + ((d.AgentCode == null || d.AgentCode == '' ? '' : d.AgentCode) + '') + '</span>';
                    }
                    listJob.push(d.ForJNo);
                    //strAmt += '<br/><br/><br/><br/>';
                    //strPrice += '<br/><br/><br/><br/>';
                    //strQty += '<br/><br/><br/><br/>';
                }
            }
            //strDesc = strDesc+strJob;
            strCode = strCode + d.SICode + '<br/>';
            if (serv.length > 0) {
                let c = $.grep(serv, function (data) {
                    return data.SICode === d.SICode;
                });
                //if (c.length > 0) {
                    //strDesc = strDesc + (d.SICode + '-' + d.SDescription + '<br/>');
                //} else {
                    strDesc = strDesc + d.SDescription+ '<br/>';
                //}
            } else {
                strDesc = strDesc + d.SICode + '<br/>';
            }
            strAmt = strAmt + (CCurrency((d.BaseAmount).toFixed(2)))+'<br/>';
            //strWht = strWht + (CCurrency((d.Charge50Tavi).toFixed(2)))+'<br/>';
            strPrice = strPrice + (CCurrency((d.UnitPrice).toFixed(2))) + '<br/>';
            strQty = strQty + (CCurrency((d.AdvQty).toFixed(2))) + '<br/>';

            totAmt += d.BaseAmount;
            //vat += d.ChargeVAT;
            //wht += d.Charge50Tavi;
            if (d.VenCode !== '') {
                $.get(path + 'Master/GetVender?Code=' + d.VenCode).done(function (v) {
                    if (v.vender.data.length > 0) {
                        let dv = v.vender.data[0];
                        $('#lblPayTo').text(dv.TName + (dv.ContactAcc !== '' ? ' A/C ' : '') + dv.ContactAcc);
                    }
                });
            }
        }
        //strDesc += '<br/>CODE - ADV : เก็บเงินลูกค้า / Invoice to Customer';
        //strDesc += '<br/>CODE - CST : ค่าใช้จ่ายบริษัท / Company Expenses';
        $('#divJob').html(strJob);
        $('#divCode').html(strCode);
        $('#divDesc').html(strDesc);
        $('#divQty').html(strQty);
        $('#divPrice').html(strPrice);
        $('#divAmt').html(strAmt);
    }
</script>