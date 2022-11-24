
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Voucher Slip"
End Code
<table id="tbAdvInfo" width="100%">
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>Voucher No : </b><label id="txtControlNo" style="text-decoration-line:underline"></label>
        </td>
        <td align="right" style="font-size:11px">
            <input type="text" id="txtVoucherType" value="VOUCHER" style="text-align:center;background-color:yellow;font:bold;font-size:large;" disabled />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="font-size:11px">
            <b>Remark</b>
            <label id="txtRemark" style="text-decoration-line:underline;"></label>
        </td>
        <td align="right" style="font-size:11px">
            <b>Voucher Date : </b><label id="txtVoucherDate" style="text-decoration-line:underline;"></label>
        </td>
    </tr>
</table>
<div style="display:flex;border:1px solid black;border-radius:5px;">
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
                QUANTITY :
                <label id="lblQtyGross"></label>
                <label id="lblQtyUnit"></label>
                <br />
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                JOB NO :
                <label id="lblJobNo"></label>
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
                MEASUREMENT :
                <label id="lblMeasurement"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                NET WEIGHT :
                <label id="lblNetWeight"></label>
                <label id="lblWeightUnit"></label>
            </p>
        </div>
        <div class="row">
            <p class="col-sm-12">
                CUSTOMER INV :
                <label id="lblCustInvNo"></label>
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
                CUSTOMER :
                <br />
                <label id="lblCustName"></label>
            </p>
        </div>
    </div>
</div>
<br />
<table id="tbData" style="border-collapse:collapse;width:100%">
    <tbody></tbody>
</table>
<br />
<table width="100%" style="border-collapse:collapse;">
    <tr>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            CREATED.BY
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            APPROVE.BY
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            PAYER
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:top">
            PAYEE
        </td>
    </tr>
    <tr>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom" height="100px">
            <label id="txtRecBy" style="font-size:10px">(__________________)</label><br />
            <label id="txtRecDate" style="font-size:9px">__/__/____</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <label id="txtPostedBy" style="font-size:10px">(__________________)</label><br />
            <label id="txtPostedDate" style="font-size:9px">__/__/____</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <label style="font-size:10px">(__________________)</label><br />
            <label style="font-size:9px">__/__/____</label>
        </td>
        <td style="border-style:solid;border-width:thin;text-align:center;vertical-align:bottom">
            <label style="font-size:9px">(__________________)</label><br />
            <label style="font-size:9px">__/__/____</label>
        </td>
    </tr>
</table>
<script type="text/javascript">
    let path = '@Url.Content("~")';
    let vcType='P';
    //$(document).ready(function () {
        let branch = getQueryString('branch');
        let controlno = getQueryString('controlno');
        $.get(path + 'acc/getvoucherreport?branch=' + branch + '&code=' + controlno, function (r) {
            if (r.voucher.header !== null) {
                ShowData(r.voucher);
            }
        });
    //});

    function ShowData(data) {
        let div = $('#tbData tbody');
        let vcTypeName = '';
        if (data.payment !== null) {
            for(let obj of data.payment) {
                if(vcType!==obj.PRType){
                    vcType=obj.PRType;
                }
                vcTypeName = GetVoucherType(vcType);
                let acType=obj.acType;
                let acTypeName = GetPaymentType(acType);
                let payType = '';
                let desc = '';
                let desc0 = '';

                appendLine(div, '<b>' + vcTypeName + ' BY ' + acTypeName + '</b>',obj.PRVoucher,CCurrency(CDbl(Number(obj.SumAmount),2)));
                //desc0 = '<b>TOTAL ' + obj.PRVoucher +'=' +  + ' ' + obj.CurrencyCode + '</b>';
                let debit = '';
                let credit = '';
                switch (acType) {
                    case 'CA':
                        payType = 'CASH';
                        if (obj.RecvBank !== '') {
                            payType = 'TRANSFER';
                        }
                        desc0 += obj.PayChqTo !== '' ? '<br/>PAY TO ' + obj.PayChqTo : '';
                        desc0 += obj.RecvBank != '' ? '<br/>BANK ' + obj.RecvBank + ' BRANCH ' + obj.RecvBranch : '';
                        desc0 += obj.BookCode != '' ? '<br/>ACCOUNT ' + obj.BookCode + ' REF# ' + obj.DocNo : '';
                        desc0 += obj.TRemark != '' ? '<br/>DATE : ' + obj.TRemark : '';
                        break;
                    case 'CH':
                        payType = 'CASHIER CHEQUE';
                    case 'CU':
                        payType = 'CUSTOMER CHEQUE';
                        desc0 += obj.ChqNo !== '' ? '<br/>NO ' + obj.ChqNo + ' DATE ' + ShowDate(CDateTH(obj.ChqDate)) : '';
                        desc0 += obj.BankCode != '' ? '<br/>BANK ' + obj.BankCode + ' BRANCH ' + obj.BankBranch : '';
                        desc0 += obj.PayChqTo !== '' ? '<br/>TO ' + obj.PayChqTo : '';
                        desc0 += obj.TRemark != '' ? '<br/>NOTE : ' + obj.TRemark : '';
                        desc0 += obj.RecvBank != '' ? '<br/>DEP.BANK ' + obj.RecvBank + ' BRANCH ' + obj.RecvBranch : '';
                        break;
                    case 'CR':
                        payType = 'CREDIT';
                        desc0 += obj.DocNo !== '' ? '<br/>REF ' + obj.DocNo + ' DATE ' + ShowDate(CDateTH(obj.ChqDate)) : '';
                        desc0 += obj.PayChqTo !== '' ? '<br/>TO ' + obj.PayChqTo : '';
                        break;
                }
                switch (vcType) {
                    case 'P':
                        desc += '<table style="text-align:left;width:100%">';
                        desc += '<tr><td>ค่าใช้จ่ายในการปฏิบัติงาน</td></tr>';
                        desc += '<tr><td>ภาษีหัก ณ ที่จ่ายค้างจ่าย</td></tr>';
                        desc += '<tr><td>เจ้าหนี้กรมสรรพากร</td></tr>';
                        desc += '<tr><td>'+payType+'</td></tr>';
                        desc += '</table>';

                        debit += '<table style="text-align:right;width:100%">';
                        debit += '<tr><td>' + CCurrency(CDbl(Number(obj.TotalAmount) + Number(obj.VatExc) + Number(obj.VatInc), 2)) + '</td></tr>';
                        debit += '<tr><td>' + CCurrency(CDbl(Number(obj.WhtExc) + Number(obj.WhtInc), 2)) + '</td></tr>';
                        debit += '<tr><td><br/></td></tr>';
                        debit += '<tr><td><br/></td></tr>';
                        debit += '</table>';

                        credit += '<table style="text-align:right;width:100%">';
                        credit += '<tr><td><br/></td></tr>';
                        credit += '<tr><td><br/></td></tr>';
                        credit += '<tr><td>' + CCurrency(CDbl(Number(obj.WhtExc) + Number(obj.WhtInc), 2)) + '</td></tr>';
                        credit += '<tr><td>' + CCurrency(CDbl(Number(obj.TotalNet) + Number(obj.WhtExc) + Number(obj.WhtInc), 2)) + '</td></tr>';
                        credit += '</table>';
                        break;
                    case 'R':
                        desc += '<table style="text-align:left;width:100%">';
                        desc += '<tr><td>' + payType + '</td></tr>';
                        desc += '<tr><td>ภาษีขาย</td></tr>';
                        desc += '<tr><td>เจ้าหนี้กรมสรรพากร</td></tr>';
                        desc += '<tr><td>ภาษีหัก ณ ที่จ่ายค้างจ่าย</td></tr>';
                        desc += '<tr><td>รายได้จากการปฏิบัติงาน</td></tr>';
                        desc += '</table>';

                        debit += '<table style="text-align:right;width:100%">';
                        debit += '<tr><td>' + CCurrency(CDbl(Number(obj.TotalAmount), 2)) + '</td></tr>';
                        debit += '<tr><td>' + CCurrency(CDbl(Number(obj.VatExc) + Number(obj.VatInc), 2)) + '</td></tr>';
                        debit += '<tr><td>' + CCurrency(CDbl(Number(obj.WhtExc) + Number(obj.WhtInc), 2)) + '</td></tr>';
                        debit += '<tr><td><br/></td></tr>';
                        debit += '<tr><td><br/></td></tr>';
                        debit += '</table>';

                        credit += '<table style="text-align:right;width:100%">';
                        credit += '<tr><td><br/></td></tr>';
                        credit += '<tr><td><br/></td></tr>';
                        credit += '<tr><td><br/></td></tr>';
                        credit += '<tr><td>' + CCurrency(CDbl(Number(obj.WhtExc) + Number(obj.WhtInc), 2)) + '</td></tr>';
                        credit += '<tr><td>' + CCurrency(CDbl(Number(obj.TotalNet) + Number(obj.WhtExc) + Number(obj.WhtInc), 2)) + '</td></tr>';
                        credit += '</table>';
                        break;
                }
                //appendLine(div, desc, debit, credit);
                appendLine(div, '<b>DETAILS OF USAGES</b>', '<b>FOREIGN PAID</b>', '<b>PAID (THB)</b>');
                if (data.document !== null) {
                    let jobno = '';
                    let doc=data.document.filter(function(r){
                        return r.acType == acType;
                    });
                    sortData(doc, 'VenderName', 'asc');
                    //sortData(doc, 'DocRefNo', 'asc');
                    if (doc !== undefined) {
                        let sum = 0;
                        let strDoc = '';
                        let lastvender = '';
                        for (d of doc) {
                            if (d.JobNo !== '') {
                                jobno = d.JobNo;
                            }
                            if (strDoc.indexOf(d.VenderName) < 0) {
                                if (lastvender !== '') {
                                    appendLine(div,d.VenderName,'<b>TOTAL</b>','<b>'+ShowNumber(sum,2)+'</b>');
                                    sum = 0;
                                }
                                strDoc += '|' + d.VenderName;
                                lastvender = d.VenderName;
                                //appendLine(div,'<b>'+ d.VenderName +'</b>','','');
                            }
                            sum += Number(CDbl(d.PaidAmount, 2));
                            desc = d.DocRefNo + ' : ' + d.SDescription;
                            if (d.Remark !== '') desc += '<br/>' + d.Remark;
                            appendLine(div, desc, CDbl(d.PaidAmount / CNum(obj.ExchangeRate), 2) + ' ' + obj.CurrencyCode + ' (Rate=' + obj.ExchangeRate + ')', CCurrency(CDbl(d.PaidAmount, 2)));
                        }
                        appendLine(div,'','<b>TOTAL</b>','<b>'+ShowNumber(sum,2)+'</b>');
                    }
                    if (jobno !== '') {
                        $.get(path + 'JobOrder/GetJobSQL?Branch='+ obj.BranchCode +'&JNo='+ jobno).done(function (r) {
                            let j = r.job.data[0];
                            if (j !== null) {
                                ShowCustomer(path, j.CustCode, j.CustBranch, '#lblCustName');
                                $('#lblCustInvNo').text(j.InvNo);
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
                                //$('#lblFromCountry').text(j.DeclareNumber);
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
                                ShowVender(path, j.ForwarderCode, '#lblAgentName');
                            }
                        });
                    }
                }
                if (obj.SICode !== '') {
                    desc0 += obj.SICode !== null ? '<br/>FOR ' + obj.SICode : '';
                }

                //summary section
                let desc1 = '<table width="100%">';
                desc1 += '<tr>';
                desc1 += '<td style="text-align:right">';
                desc1 += '<b>SUM AMOUNT</b>';
                desc1 += '</td>';
                desc1 += '</tr>';
                desc1 += '<tr>';
                desc1 += '<td style="text-align:right">';
                desc1 += '<b>SUM VAT' + (obj.VatInc > 0 ? ' Incl=' + CCurrency(CDbl(Number(obj.VatInc),2)) + '' : '') + '</b>';
                desc1 += '</td>';
                desc1 += '</tr>';
                desc1 += '<tr>';
                desc1 += '<td width="80%" style="text-align:right">';
                desc1 += '<b>SUM WHT' + (obj.WhtInc > 0 ? ' Incl=' + CCurrency(CDbl(Number(obj.WhtInc),2)) + '' : '') + '</b>';
                desc1 += '</td>';
                desc1 += '</tr>';
                desc1 += '<tr>';
                desc1 += '<td width="80%" style="text-align:right">';
                desc1 += '<b>GRAND TOTAL</b>';
                desc1 += '</td>';
                desc1 += '</tr>';
                desc1 += '</table>';

                let desc2 = '<table width="100%">';
                desc2 += '<tr>';
                desc2 += '<td width="20%" style="text-align:right">';
                desc2 += CCurrency(CDbl(Number(obj.TotalAmount),2));
                desc2 += '</td>';
                desc2 += '</tr>';
                desc2 += '<tr>';
                desc2 += '<td width="20%" style="text-align:right">';
                desc2 += CCurrency(CDbl(Number(obj.VatExc),2));
                desc2 += '</td>';
                desc2 += '</tr>';
                desc2 += '<tr>';
                desc2 += '<td width="20%" style="text-align:right">';
                desc2 += CCurrency(CDbl(Number(obj.WhtExc),2));
                desc2 += '</td>';
                desc2 += '</tr>';
                desc2 += '<tr>';
                desc2 += '<td width="20%" style="text-align:right">';
                desc2 += CCurrency(CDbl(Number(obj.TotalNet) + Number(obj.WhtExc) + Number(obj.WhtInc), 2));
                desc2 += '</td>';
                desc2 += '</tr>';
                desc2 += '</table>';

                appendLine(div, desc0, desc1, desc2);

            }
        }
        if (data.header !== null) {
            $('#txtControlNo').text(data.header[0].ControlNo);
            $('#txtVoucherType').val(vcTypeName + ' VOUCHER');
            $('#txtVoucherDate').text(ShowDate(CDateTH(data.header[0].VoucherDate)));
            $('#txtRemark').text(data.header[0].TRemark);
        }
    }
    function appendLine(dv,data,col1,col2) {
        let html = '<tr><td style="border-style:solid;border-width:thin;font-size:11px">';
        html += data;
        html += '</td>';
        html += '<td style="border-style:solid;border-width:thin;font-size:11px;text-align:right" width="150px">' + col1 + '</td>';
        html += '<td style="border-style:solid;border-width:thin;font-size:11px;text-align:right" width="100px">' + col2 + '</td>';
        html += '</tr>';

        dv.append(html);
    }
</script>