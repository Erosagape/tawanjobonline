
@Code
    Layout = "~/Views/Shared/_ReportImgLogo.vbhtml"
    ViewBag.Title = "Voucher Slip"
    ViewBag.HeadSrc = "voucher_rv.jpg"
End Code
<style>
    #voucherTable{
        page-break-inside:auto;
    }
</style>
@*<div style="display:flex;  justify-content: center;  align-items: center;">
        <div style="width:15%"><img style="width:100%;" src="/test/Resource/logo_bft.png" /></div>
        <div style="font-weight:bold;font-size:30px;text-align:center" pv="ใบสำคัญจ่าย / PAYMENT VOUCHER" class="PVMode">ใบสำคัญรับ / RECEIPT VOUCHER</div>
    </div>*@

<table style="width: 100%; border-collapse: collapse;  ">
    <tbody>
        <tr>
            @*<td style="width:13%" id="test" pv="เลขที่ใบเบิก" class="PVMode">
                    เลขที่ใบรับเงิน:
                </td>
                <td style="width:8%">
                    <label id="lblControlNo1"></label>
                </td>
                <td style="width:6%" pv="วันที่เบิก" class="PVMode">
                    วันที่รับ:
                </td>*@
            <td pv="ใบสำคัญจ่ายเลขที่" class="PVMode" style="width:15%">
                ใบสำคัญรับเลขที่:
            </td>
            <td style="width:20%">
                <label id="lblControlNo2"></label>
            </td>
            @*<td style="width:8%">
                    <label id="lblRecvPayDate"></label>
                </td>*@
            <td style="width:15%">
                VOUCHER NO:
            </td>
            <td style="width:20%">
                <label id="lblVoucherNo"></label>
            </td>
            <td style="width:10%">
                DATE:
            </td>
            <td style="width:20%">
                <label id="lblVoucherDate"></label>
            </td>
        </tr>
        <tr>
            <td>
                BANK CODE:
            </td>
            <td>
                <label id="lblBankName"></label> <label id="lblBankCode"></label> 
            </td>
            <td style="width:10%">
                BANK A/C:
            </td>
            <td colspan="3">
                <label id="lblBankAccount"></label>
            </td>

        </tr>
    </tbody>
</table>
<table style="width: 100%; border-collapse: collapse;">
    <tbody>
        <tr>
            <td style="width:10%" pv="จ่ายให้" class="PVMode">
                ชำระโดย/เพื่อ:
            </td>
            <td style="width:20%">
                <label id="lblPayCompany"></label><br/>
                <label id="lblTRemark"></label>
            </td>
            <td style="width:10%">
                ชำระเป็น:
            </td>
            <td style="width:10%;">
                <div style="display:flex;width:100%">
                    <div style="flex:1;text-align:right;"><input id="cash" type="checkbox"></div>
                    <div style="flex:1;text-align:right;">เงินสด</div>
                </div>
            </td>
            <td style="width:10%;">
                <div style="display:flex;width:100%">
                    <div style="flex:1;text-align:right;"><input id="transfer" type="checkbox"></div>
                    <div style="flex:1;text-align:right">เงินโอน</div>
                </div>
            </td>
            <td style="width:10%">
            </td>
            <td style="width:10%">
                เลขที่:
            </td>
            <td style="width:20%">
                <label id="lblRefNo"></label>
            </td>
        </tr>
        <tr>
            <td pv="">ส่วนต่างรับ</td>
            
            <td colspan="2" id="lblDiff" style="color:red"></td>

            <td>
                <div style="display:flex;width:100%">
                    <div style="flex:1;text-align:right;"><input id="cheque" type="checkbox"></div>
                    <div style="flex:1;text-align:right">เช็ค</div>
                </div>
            </td>
            <td style="text-align: right;"> เลขที่</td>
            <td>
                <label id="lblChqNo"></label>
            </td>
            <td>
                ลงวันที่:
            </td>
            <td>
                <label id="lblChqDate"></label>
            </td>
        </tr>
    </tbody>
</table>
<div id="paymentData" style="width:100%">


</div>
<br />
<div>( ผู้จัดทำ ผู้อนุมัติ และบัญชีผู้ตรวจสอบ ลงนามเซ็นชื่อรับทราบ และยืนยันความถูกต้อง ว่าได้มีการตรวจสอบข้อมูลการเบิกจ่ายว่าเป็นข้อมูลที่ใช้ในงานอย่างถูกต้อง ก่อนที่จะให้ผู้บริหารโอนจ่ายหรือทำเช็คจ่าย หากมีความเสียหายเกิดขึ้นหรือข้อมูลที่ให้ไม่เป็นความจริง ยินดีรับผิดชอบความเสียหายนั้นทั้งหมดครบถ้วนสมบูรณ์ )</div>
<br />
<table style="width: 100%; border-collapse: collapse;" id="T1">
    <tbody>
        <tr>
            <td style="width:20%" id="person1" pv="ผู้ขอเบิก" class="PVMode">
                ผู้ตรวจสอบเงินเข้าบัญชี
            </td>
            <td style="width:20%" id="person2" pv="ผู้อนุมัติใบขอเบิก" class="PVMode">
                ผู้จัดทำใบสำคัญรับ
            </td>
            <td style="width:20%" id="person3" pv="ผู้จัดทำใบสำคัญจ่าย" class="PVMode">
                ผู้ตรวจสอบใบสำคัญรับ
            </td>
            <td style="width:20%" id="person4" pv="ผู้ตรวจสอบใบสำคัญจ่าย" class="PVMode">
                ผู้อนุมัติใบสำคัญรับ
            </td>
            <td style="width:20%" id="person5" pv="ผู้อนุมัติใบสำคัญจ่าย" class="PVMode">
                ผู้ออกใบเสร็จ
            </td>
        </tr>
        <tr>
            <td >
                <br />
                <br />
                <br />
                <br />
                <br />
                <label id="signature1"></label><br /><label  id="date1"></label>
            </td>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <label id="signature2"></label><br /><label id="date2"></label>
            </td>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <label id="signature3"></label><br /><label id="date3"></label>
            </td>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <label id="signature4"></label><br /><label id="date4"></label>
            </td>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <label id="signature5"></label><br /><label id="date5"></label>
            </td>
        </tr>
    </tbody>
</table>
<br />
<br />
<br />
<br />
<br />
<div style="display:flex;flex-direction:column;">
    <div style="text-align:center" pv="(การเบิกจ่ายที่ไม่เกี่ยวข้องกับงานหรือกระทำการบิดเบือนความจริงเข้าข่ายการทุจริตและประพฤติมิชอบ หรือยักยอกทรัพย์บริษัท)" class="PVMode">(การออกใบเสร็จและใบสำคัญรับ  โดยไม่มีการตรวจสอบหรือกระทำการบิดเบือนความจริง เข้าข่ายการทุจริตและประพฤติมิชอบหรือยักยอกทรัพย์บริษัท)</div>
    <div style="text-align:center;color:green;font-size:20px">บริษัท เบทเตอร์เฟรท แอนด์ทรานสปอร์ต จำกัด<br />BETTER FREIGHT & TRANSPORT CO.,LTD</div>
    <br />
    <br />
    <br />
</div>

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



    async function loadVoucher2() {

        let data = await fetch(path + 'acc/getvoucherreport')
            .then((r) => r.json())
            .then((d) => {
                //console.log(d);
                return d;
            });

    }

    async function loadVoucher() {
        let r = await fetch(path + 'acc/getvoucherreport');
        let d = await r.json();
        console.log(d);
    }




    function ShowData(data) {
        if (data.header) {
            $('#lblControlNo1').text(data.header[0].ControlNo);
            $('#lblControlNo2').text(data.header[0].ControlNo);
            //$('#txtVoucherType').val(vcTypeName + ' VOUCHER');
            $('#lblVoucherDate').text(ShowDate(CDateTH(data.header[0].VoucherDate)));
            $('#lblRecvPayDate').text(ShowDate(data.header[0].RecTime));
            $('#lblTRemark').text(data.header[0].TRemark);
            $.get(path + 'Master/GetCompany?branch=' + data.header[0].CustBranch + '&code=' + data.header[0].CustCode, function (r) {
                if (r.company.data) {
                    $('#lblPayCompany').text(r.company.data[0].NameEng);
                }
            });
            //$('#txtRemark').text(data.header[0].TRemark);
        }
        if (data.document) {
            $('#lblBankCode').text(data.document[0].BankCode);
            ShowBank(path, data.document[0].BankCode, '#lblBankName');
            $('#lblBankAccount').text(data.document[0].BookName);
        }
        if (data.payment ) {
            $('#lblBankCode').text(data.payment[0].BankCode);
            ShowBank(path, data.payment[0].BankCode, '#lblBankName');
            $('#lblBankAccount').text(data.payment[0].BookCode);
            fetch(path + 'Master/GetBookAccount?Code=' + data.payment[0].BookCode)
                .then((r) => r.json())
                .then((d) => {
                    if (d.bookaccount) {
                        $('#lblBankAccount').text(d.bookaccount.data[0].BookName);
                    }
                    return d;
                });
            //$('#lblPayCompany').text(data.payment[0].PayChqTo);

            //if (data.payment[0].acType == "CA") {

            //} else if (data.payment[0].acType == "CH"){
            //    $('#lblChqNo').text(data.payment[0].ChqNo);
            //    $('#lblChqDate').text(ShowDate(CDateTH(data.payment[0].ChqDate)));
            //}
        }
     
        let div = $('#tbData tbody');
        let vcTypeName = '';
        if (data.payment && data.payment.length > 0) {
            let pay = data.payment[0];
            if (pay.PRType == "P") {
                $(".PVMode").each(function () {
                    $(this).text(this.getAttribute("pv"));
                });
                $("#imgLogo").prop("src", path + "/Resource/voucher_pv.jpg");
                $('#lblPayCompany').text(data.payment[0].PayChqTo);
                ShowUser(path, data.header[0].RecUser, "#signature3");
                $('#date3').text(ShowDate(data.header[0].RecDate));
                //$('#signature3').text(data.header[0].RecUser);
                //$('#signature4').text();
                //$('#signature5').text("");

            } else {
                ShowUser(path, data.header[0].RecUser, "#signature2");
                $('#date2').text(ShowDate(data.header[0].RecDate));
                if (data.document) {
                    $.get(path + 'acc/GetInvoice?branch=' + branch + '&code=' + data.document[0].DocRefNo, function (r) {
                        let h = r.invoice.header;
                        if (h) {
                            $.get(path + 'Master/GetCompany?branch=' + h[0][0].BillToCustBranch + '&code=' + h[0][0].BillToCustCode, function (r) {
                                if (r.company.data) {
                                    $('#lblPayCompany').text(r.company.data[0].NameEng);
                                }
                            });
                        }
                    });
                }
            }
        }
	let totPay=0;
        for (pay of data.payment) {
            if ($('#lblVoucherNo').text() != "") {
                $('#lblVoucherNo').text($('#lblVoucherNo').text()+","+pay.PRVoucher);
            } else {
                $('#lblVoucherNo').text(pay.PRVoucher);
            }
	    
            if (pay.acType == "CA") {
                $('#lblRefNo').text(pay.DocNo ? pay.DocNo : "____________");
                $('#transfer').prop('checked', true);
            } else if (pay.acType == "CH" || pay.acType == "CU") {
                $('#lblChqNo').text(pay.ChqNo ? pay.ChqNo : "____________");
                $('#lblChqDate').text(pay.ChqDate ? ShowDate(pay.ChqDate) : "____________");
                $('#cheque').prop('checked', true);
                $('#lblBankCode').text(pay.RecvBranch);
            }

            vcTypeName = GetVoucherType(vcType);
            const doc = data.document.filter(d => d.acType == pay.acType);
            let detailTrs = ``;
            let i = 1;
            let totalNet = pay.TotalNet;
            if (doc.length > 0) {
                totalNet = 0;
                if (pay.PRType == "P") {
                    ShowUser(path, doc[0].DocRefBy, "#signature1");
                    ShowUser(path, doc[0].DocRefApproveBy, "#signature2");
                    $("#date1").text(ShowDate(doc[0].DocRefDate));
                    $("#date2").text(ShowDate(doc[0].DocRefApproveDate));
                    if (doc[0].DocRefNo.indexOf("PAY") >= 0) {
                        $("#person1").text("ผู้ขอเบิกจ่าย");
                        $("#person2").text("ผู้ขออนุมัติเบิกจ่าย");
                    }
                } else {
                
}
                //$('#signature1').text(doc[0].DocRefBy);
                //$('#signature2').text(doc[0].DocRefApproveBy);
            } 

            
            for (d of doc) {
                let tr = "";
                //<td style="text-align:center;padding:0px 5px;">${i++}</td>
                 //<td style="padding:0px 5px;">${d.JobNo ? d.JobNo : ""}</td>
                 //           <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.PaidAmount ? d.Amount : d.CashAmount,2))}</td>
                 //           <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.PaidAmount ? d.VAT:0, 2))}</td>
                 //           <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.PaidAmount ? d.WHT:0, 2))}</td>
                 //           <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.PaidAmount ? d.PaidAmount : d.CashAmount, 2))}</td></tr >`;
                tr += `<tr style="height:0px">
                           <td style="text-align:center;padding:0px 5px;">${d.DocRefNo}</td>
                           <td style="text-align:center;padding:0px 5px;">${d.CustInv/* ShowDate(d.DocDate)*/}</td>
                            ${ pay.PRType == "R" ?
                                 `<td style="padding: 0px 5px; ">${d.BookingNo ? d.BookingNo : ""}</td>` :
                                 ` <td colspan="2" style="padding:0px 5px;">${d.SDescription ? d.SDescription : ""}</td>`
                            }
                            <td style="padding:0px 5px;">${d.JobNo ? d.JobNo : ""}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.Amount, 2))}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.VAT, 2))}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl( d.WHT, 2))}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.Amount + d.VAT - d.WHT, 2))}</td></tr>`;
                //totalNet += d.PaidAmount ? d.PaidAmount :d.CashAmoun;
                totalNet +=  d.Amount + d.VAT - d.WHT;
                console.log(d.Amount + d.VAT - d.WHT);
                //console.log(d.PaidAmount);
                //console.log(d.TotalAmount);
                            detailTrs += tr;
            }
            console.log(totalNet + " " + pay.TotalNet);
  //          if(totalNet>0){
		//totPay+=totalNet;
  //          } else {
		totPay+=pay.TotalNet;
            //}
            $('#lblDiff').text(pay.PRType == "R" ? (Math.round((pay.TotalNet - totalNet) * 100) / 100).toFixed(2) : "");
            console.log(pay.TotalNet + "/" + totalNet);
            detailTrs += "<tr> </tr>"
            let desc = "";
            let payType;
            switch (pay.acType) {
                case 'CA':
                    payType = 'CASH';
                    if (pay.RecvBank !== '') {
                        payType = 'TRANSFER';
                    }
                    //let str = pay.PRType == "R" ? "PAY BY : " : "PAY TO : ";
                    //desc += pay.PayChqTo !== '' ? str + pay.PayChqTo : '';
                    desc += pay.PayChqTo;
                    //desc += pay.RecvBank != '' ? '<br/>' + pay.RecvBranch : '';
                    //if (data.document[0].BookName !== '') {
                    //    desc += pay.BookCode != '' ? '<br/>ACCOUNT ' + data.document[0].BookName + ' REF# ' + pay.DocNo : '';
                    //} else {
                    //    desc += pay.BookCode != '' ? '<br/>ACCOUNT ' + pay.BookCode + ' REF# ' + pay.DocNo : '';
                    //}
                    //desc += pay.TRemark != '' ? '<br/>DATE : ' + pay.TRemark : '';
                    break;
                case 'CH':
                    payType = 'CASHIER CHEQUE';
                case 'CU':
                    payType = 'CUSTOMER CHEQUE';
                    desc += pay.ChqNo !== '' ? '<br/>NO ' + pay.ChqNo + ' DATE ' + ShowDate(CDateTH(pay.ChqDate)) : '';
                    desc += pay.BankCode != '' ? '<br/>BANK ' + pay.BankCode + ' BRANCH ' + pay.BankBranch : '';
                    desc += pay.PayChqTo !== '' ? '<br/>TO ' + pay.PayChqTo : '';
                    desc += pay.TRemark != '' ? '<br/>NOTE : ' + pay.TRemark : '';
                    desc += pay.RecvBank != '' ? '<br/>DEP.BANK ' + pay.RecvBank + ' BRANCH ' + pay.RecvBranch : '';
                    break;
                case 'CR':
                    payType = 'CREDIT';
                    desc += pay.DocNo !== '' ? '<br/>REF ' + pay.DocNo + ' DATE ' + ShowDate(CDateTH(pay.ChqDate)) : '';
                    desc += pay.PayChqTo !== '' ? '<br/>TO ' + pay.PayChqTo : '';
                    break;
            }
            //<label id="lblBankAccInfo">${pay.PayChqTo ? pay.PayChqTo : "________________"}</label><br/>
            //BANK < label id = "lblBankAccInfo" > ${ pay.RecvBank ? pay.RecvBank : "________________" }</label >
            //    BRANCH < label id = "lblBankAccInfo" > ${ pay.RecvBranch ? pay.RecvBranch : "________________" }</label > <br />
            //ACCOUNT ${ doc[0].BookName !== '' ? (pay.BookCode != '' ? 'ACCOUNT ' + doc[0].BookName + ' <br/REF# ' + pay.DocNo : '') : (pay.BookCode != '' ? '<br/>ACCOUNT ' + pay.BookCode + ' <br/REF# ' + pay.DocNo : '') }

           
            let sumTr = `<tr id="A3">
            <td rowspan="2" style="font-size:13px;">
                ${ pay.PRType == "P" ? "จ่ายให้:" :"สำหรับ:"}

            </td>
            <td colspan="4" rowspan="2" style="text-align:left">
                ${desc}
            </td>
            <td colspan="2" style="font-size:13px;">
                  ${ pay.PRType == "P" ? "จำนวนเงินที่ต้องจ่าย:" : "รับเงินจำนวน:"}

            </td>
            <td colspan="3">
                <label id="lblAmount" style="text-align:center;padding:0px 5px;font-size:16px;">${CCurrency(CDbl(totPay, 2))}</label>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;padding:0px 5px;"> ${CNumThai(CDbl(Number(totPay), 2))} </td>
        </tr>`;
            let table =
                `<table id="voucherTable" style="width: 100%; border-collapse: collapse;">
                <thead>
                    <tr id="A1">
                        <td style="width: 12%; ">
                           เอกสารอ้างอิง
                        </td>
                        <td style="width: 10%; ">
                            เลขที่อ้างอิง
                        </td>
                        ${  pay.PRType == "R" ?
                        `
                        <td style="width:14%; ">
                            เลขที่ใบจอง/เลขที่ใบตราขนส่ง
                        </td>`
                        :
                         `<td colspan="2" style="width:28%; ">
                            รายละเอียด/คำอธิบาย
                        </td>` }

                        <td style="width:10%; ">
                            งานอ้างอิง
                        </td>
                        <td style="width:10%; ">
                            จำนวนเงิน
                        </td>
                        <td style="width:10%; ">
                            VAT7%
                        </td>
                        <td style="width:10%; ">
                            WHT
                        </td>
                        <td style="width:10%; ">
                            จำนวนเงินรวม
                        </td>
                    </tr>
                </thead>
                <tbody id="tbdetail">
                    ${detailTrs}
                </tbody>
                <tfoot>
                    ${sumTr}
                </tfoot>
            </table>`;
            $('#paymentData').html($('#paymentData').html()+table);
        }

        $('#dvFooter').css("display", "block");
        console.log($('#dvFooter').html());

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
    * {
        font-size: 11px;
    }

    #voucherTable tr td {
        padding: 5px;
        border-left: 1px solid black;
        border-right: 1px solid black;
    }

    table tr td {
        /*  border:1px solid black;*/
        padding: 1px;
        height: 19px;
    }


    table table {
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