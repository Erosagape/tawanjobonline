
@Code
    Layout = "~/Views/Shared/_ReportImgLogo.vbhtml"
    ViewBag.Title = "Voucher Slip"
    ViewBag.HeadSrc = "voucher_rv.jpg"
End Code
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
            <td  style="width:20%" >
                <label id="lblVoucherDate"></label>
            </td>
        </tr>
        <tr>
            <td >
                BANK CODE:
            </td>
            <td  >
                <label id="lblBankCode"></label>
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
                รับจาก:
            </td>
            <td  style="width:20%">
                <label id="lblPayCompany"></label>
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
            <td colspan="3">
            </td>
          
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
            <td >
                <label id="lblChqDate"></label>
            </td>
        </tr>
    </tbody>
</table>
<div id="paymentData" style="width:100%">


</div>


<table style="width: 100%; border-collapse: collapse;" id="T1">
    <tbody>
        <tr>
            <td style="width:20%" pv="ผู้ขอเบิก" class="PVMode">
                ผู้ออกใบเสร็จ
            </td>
            <td style="width:20%" pv="ผู้อนุมัติใบขอเบิก" class="PVMode">
                ผู้ตรวจสอบเงินเข็าบัญชี
            </td>
            <td style="width:20%" pv="ผู้จัดทำใบสำคัญจ่าย" class="PVMode">
                ผู้จัดทำใบสำคัญรับ
            </td>
            <td style="width:20%" pv="ผู้ตรวจสอบใบสำคัญจ่าย" class="PVMode">
                ผู้ตรวจสอบใบสำคัญรับ
            </td>
            <td style="width:20%" pv="ผู้อนุมัติใบสำคัญจ่าย" class="PVMode">
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
<br />
<br />
<br />
<br />
<br />
<div style="display:flex;flex-direction:column;">
    <div style="text-align:center" pv="(การเบิกจ่ายที่ไม่เกี่ยวข้องกับงานหรือกระทำการบิดเบือนความจริงเข้าข่ายการทุจริตและประพฤติมิชอบ หรือยักยอกทรัพย์บริษัท)" class="PVMode">(การออกใบเสร็จและใบสำคัญรับ  โดยไม่มีการตรวจสอบหรือกระทำการบิดเบือนความจริง เข้าข่ายการทุจริตและประพฤติมิชอบหรือยักยอกทรัพย์บริษัท)</div>
<div style="text-align:center;color:green;font-size:20px">บริษัท เบทเตอร์เฟรท แอนด์ทรานสปอร์ต จำกัด<br />BETTER FREIGHT & TRANSPORT CO.,LTD</div>
</div>

<script type="text/javascript">
    let path = '@Url.Content("~")';
    let vcType='P';
    //$(document).ready(function () {
    let branch = getQueryString('branch');
    let controlno = getQueryString('controlno');

    //$('#imgLogo').hide();



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
            //$('#txtRemark').text(data.header[0].TRemark);
        }
        if (data.payment ) {
          
            $('#lblPayCompany').text(data.payment[0].PayChqTo);//

            //if (data.payment[0].acType == "CA") {
              
            //} else if (data.payment[0].acType == "CH"){
            //    $('#lblChqNo').text(data.payment[0].ChqNo);
            //    $('#lblChqDate').text(ShowDate(CDateTH(data.payment[0].ChqDate)));
            //}
        }
        if (data.document ) {
            $('#lblBankCode').text(data.document[0].BankCode);
            $('#lblBankAccount').text(data.document[0].BookName);
         

            //$.get(path + 'Master/GetCompany?branch=' + data.document[0].CmpBranch + '&code=' + data.document[0].CmpCode, function (r) {
            //    if (r.company.data ) {
            //        $('#lblPayCompany').text(r.company.data[0].NameThai);
            //    }
            //});

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
            }
        }
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
            }

            vcTypeName = GetVoucherType(vcType);
            const doc = data.document.filter(d => d.acType == pay.acType);
            let detailTrs = ``;
            let i = 1;
            let totalNet = 0;
            for (d of doc) {
                let tr = "";
                //<td style="text-align:center;padding:0px 5px;">${i++}</td>
                tr += `<tr style="height:0px">
                           <td style="text-align:center;padding:0px 5px;">${d.DocRefNo}</td>
                           <td style="text-align:center;padding:0px 5px;">${ShowDate(d.DocDate)}</td>
                            ${ pay.PRType == "R" ?
                                 `<td style="padding: 0px 5px; ">${d.BookingNo ? d.BookingNo : ""}</td>` :
                                 ` <td colspan="2" style="padding:0px 5px;">${d.SDescription ? d.SDescription : ""}</td>`
                            }
                            <td style="padding:0px 5px;">${d.JobNo ? d.JobNo : ""}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.Amount,2))}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.VAT, 2))}</td>
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.WHT, 2))}</td>                       
                            <td style="text-align:right;padding:0px 5px;">${ CCurrency(CDbl(d.PaidAmount, 2))}</td></tr>`;
                            totalNet += d.PaidAmount;
                            detailTrs += tr;
            }
            detailTrs += "<tr> </tr>"
            let desc = "";
            let payType;
            switch (pay.acType) {
                case 'CA':
                    payType = 'CASH';
                    if (pay.RecvBank !== '') {
                        payType = 'TRANSFER';
                    }
                    desc += pay.PayChqTo !== '' ? 'PAY TO : ' + pay.PayChqTo : '';
                    desc += pay.RecvBank != '' ? '<br/>' + pay.RecvBranch : '';
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
                ${ pay.PRType == "P" ? "จ่ายให้:" :"รับจาก:"}
               
            </td>
            <td colspan="4" rowspan="2" style="text-align:left">
                ${desc}
            </td>
            <td colspan="2" style="font-size:13px;">
                  ${ pay.PRType == "P" ? "จำนวนเงินที่ต้องจ่าย:" : "รับเงินจำนวน:"}
               
            </td>
            <td colspan="3">
                <label id="lblAmount" style="text-align:center;padding:0px 5px;font-size:16px;">${CCurrency(CDbl(totalNet, 2))}</label>
            </td>
        </tr>
        <tr>
            <td colspan="5" style="text-align:center;padding:0px 5px;"> ${CNumThai(CDbl(Number(totalNet), 2))} </td>
        </tr>`;
            let table =
                `<table id="voucherTable" style="width: 100%; border-collapse: collapse;">
                <thead>
                    <tr id="A1">
                        <td style="width: 12%; ">
                           เอกสารอ้างอิง
                        </td>
                        <td style="width: 10%; ">
                            วันที่
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