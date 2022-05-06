
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Voucher Slip"
End Code
<table style="width: 100%; border-collapse: collapse;">
<tbody>
    <tr>
        <td style="width:13%" id="test">
            เลขที่ใบเบิก:
        </td>
        <td style="width:7%">
        </td>
        <td style="width:10%">
            วันที่รับ:
        </td>
        <td style="width:10%">
        </td>
        <td style="width:12%">
            VOUCHER NO:
        </td>
        <td colspan="2" style="width:18%">
        </td>
        <td style="width:10%">
            DATE:
        </td>
        <td colspan="2" style="width:20%">
        </td>
    </tr>
    <tr>
        <td style="width:10%">
            BANK CODE:
        </td>
        <td colspan="3" style="width:30%">
        </td>
        <td style="width:10%">
            BANK A/C:
        </td>
        <td colspan="2" style="width:20%">
        </td>
        <td colspan="3" style="width:30%">
        </td>
    </tr>
</tbody>
        </table>
<table style="width: 100%; border-collapse: collapse;">
    <tbody>
        <tr>
            <td style="width:13%">
                รับจาก:
            </td>
            <td colspan="3" style="width:27%">
            </td>
            <td style="width:12%">
                ชำระเป็น:
            </td>
            <td style="width:10%">
                <input type="checkbox"> เงินสด
            </td>
            <td style="width:8%">
                <input type="checkbox"> เงินโอน
            </td>
            <td style="width:10%">
            </td>
            <td style="width:10%">
                เลขที่:
            </td>
            <td style="width:10%">
            </td>
        </tr>
        <tr>
            <td>
                ใบสำคัญรับเลขที่:
            </td>
            <td colspan="3">
            </td>
            <td>
            </td>
            <td>
                <input type="checkbox">เช็ค    เลขที่:
            </td>
            <td style="text-align: right;">เลขที่</td>
            <td>
            </td>
            <td>
                ลงวันที่:
            </td>
            <td colspan="3">
            </td>
        </tr>
    </tbody>
</table>
<table style="width: 100%; border-collapse: collapse;">
    <tbody id="tbdetail">
        <tr id="A1">
            <td style="width: 3%; ">
                ลำดับ
            </td>
            <td colspan="2" style="width:8%; ">
                เอกสารอ้างอิง
            </td>
            <td colspan="2" style="width:12%; ">
                เลขที่ใบจอง/เลขที่ใบตราขนส่ง
            </td>
            <td style="width:3%; ">
                งานอ้างอิง
            </td>
            <td style="width:3%; ">
                จำนวนเงิน
            </td>
            <td style="width:3%; ">
                VAT7%
            </td>
            <td style="width:3%; ">
                WHT
            </td>
            <td style="width:3%; ">
                ส่วนลด
            </td>
            <td style="width:4%; ">
                จำนวนเงินรวม
            </td>
        </tr>
        <tr id="A2">
            <td>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>

                <br>
            </td>
            <td colspan="2">
                (เลขที่ใบแจ้งหนี้)
            </td>
            <td colspan="2">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr id="A3">
            <td rowspan="2">
                รับจาก:
            </td>
            <td colspan="6" rowspan="2">
                เป็นชื่อและเลขที่บัญชีของลูกค้า
            </td>
            <td colspan="2">
                รับเงินจำนวน
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </tbody>
</table>
<table style="width: 100%; border-collapse: collapse;" id="T1">
    <tbody>
        <tr>
            <td>
                ผู้ออกไบเสร็จ
            </td>
            <td>
                ผู้ตรวจสอบเงินเข็าบัญชี
            </td>
            <td>
                ผู้จัดทำใบสำคัญรับ
            </td>
            <td>
                ผู้ตรวจสอบใบสำคัญรับ
            </td>
            <td>
                ผู้อนุมัติใบสำคัญรับ
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </tbody>
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
                        if(data.document[0].BookName!==''){
	                        desc0 += obj.BookCode != '' ? '<br/>ACCOUNT ' + data.document[0].BookName + ' REF# ' + obj.DocNo : '';
			} else {
                        	desc0 += obj.BookCode != '' ? '<br/>ACCOUNT ' + obj.BookCode + ' REF# ' + obj.DocNo : '';
			}
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
                        //let strDoc = '';
                        let lastvender = '';
                        for (d of doc) {
                            if (d.JobNo !== '' && jobno=='') {
                                jobno = d.JobNo;
                            }
                            if (lastvender!==d.VenderName) {
                                if (sum>0) {
                                    appendLine(div,'','<b>TOTAL</b>','<b>'+ShowNumber(sum,2)+'</b>');
                                    sum = 0;
                                }
                                //strDoc += '|' + d.VenderName;
                                lastvender = d.VenderName;
                                appendLine(div,'<b>'+ d.VenderName +'</b>','','');
                            }
                            sum += Number(CDbl(d.PaidAmount, 2));
                            desc = d.DocRefNo + ' : ' + d.SDescription;
                            //if (d.Remark !== '') desc += '<br/>' + d.Remark+' '+ d.VenderName;
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
                                $('#lblCustPo').text(j.CustRefNO);

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
                desc2 += CCurrency(CDbl(Number(obj.TotalNet), 2));
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
<style>
    table tr td {
        /*  border:1px solid black;*/
        font-size: 12px;
        padding: 1px;
        height: 19px;
    }

    table {
        border: 1px solid black;
        margin-bottom: 5px;
    }

    #A1 td {
        border: 1px solid black;
        text-align: center;
    }

    #A2 td {
        border: 1px solid black;
        text-align: center;
    }

    #A3 td {
        border: 1px solid black;
        text-align: center;
    }

    #T1 td {
        border: 1px solid black;
        text-align: center;
    }
</style>