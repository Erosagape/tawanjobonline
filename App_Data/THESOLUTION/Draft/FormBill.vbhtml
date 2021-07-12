
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Billing Slip"
    ViewBag.ReportName = "BILLING NOTE"
End Code
<style>
    table {
        padding: 10px;
        font-size:11px
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    h3 {
        margin-top: -10px;
    }

    .box {
        border: 1px solid black;
        border-radius: 10px;
        padding: 10px;
        margin: 10px;
    }

    tr td {
        border-style: none ;
        border-color:white;
    }

    .upperLine {
        border-top: 1px solid black;
    }

    .underLine {
        border-bottom: 1px solid black;
    }
</style>
<div class="container">
    <div class="row">
        <div class="col-sm-7" style="margin:10px">
            <label style="background-color: white;padding: 5px;font-size: 20px;">Customer</label>
        </div>
        <div class="col-sm-4 center" style="margin:10px">
            <label style="background-color: white;padding: 5px;font-size: 20px;">ใบวางบิล</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-7 box">
            <table class="table">
                <tbody>
                    <tr>
                        <td><label id="companyName"></label></td>
                    </tr>
                    <tr>
                        <td><label id="address1"></label></td>
                    </tr>
                    <tr>
                        <td><label id="address2"></label></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="col-sm-4 box">
            <table class="table">
                <tbody>
                    <tr>
                        <td style="width: 10%;"></td>
                        <td>เลขที่</td>
                        <td>:</td>
                        <td class="right"><label id="no"></label></td>
                        <td style="width: 10%;"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><label>วันที่</label></td>
                        <td>:</td>
                        <td class="right"><label id="date"></label></td>
                        <td></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <table class="table">
        <tbody id="detail">
            <tr>
                <td class="center upperLine underLine">ลำดับที่</td>
                <td class="upperLine underLine">เอกสาร</td>
                <td class="center upperLine underLine">ลงวันที่</td>
                <td class="center upperLine underLine">ครบกำหนดชำระ</td>
                <td class="center upperLine underLine">TaxBase</td>
                <td class="center upperLine underLine">VAT</td>
                <td class="center upperLine underLine">จำนวนเงิน</td>
            </tr>
            @*<tr>
                <td class="center">1</td>
                <td>IV-025890</td>
                <td>24/05/21</td>
                <td>24/05/21</td>
                <td>56,000.00</td>
                <td></td>
                <td>56,000.00</td>
            </tr>*@
            <tr style="height: 300px;">
            </tr>
            <tr>
                <td colspan="7">
                    <div class="row">
                        <div class="col-sm-6 box" style="display: flex;height: 150px;">
                            <div>ค่าขนส่ง</div>
                            <div class="right" style="flex:1">
                                <label id="frieght"></label>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <br>
                            <label id="something"></label>
                        </div>
                    </div>

                </td>
            </tr>
            <tr>
                <td class="upperLine underLine" colspan="6">รวม : (<label id="totalTxt"></label>)</td>
                <td class="upperLine underLine"><label id="total"></label> </td>
            </tr>
        </tbody>
    </table>
    <div style="display: flex;">
        <div class="center" style="flex:1;padding: 10px;white-space: nowrap;">
            <br>
            <br>
            <br>
            <br>
            <div for="">______________________</div>
            <p>ผู้รับวางบิล</p>
        </div>
        <div class="center" style="flex:1;padding: 10px;white-space: nowrap;">
            <br>
            <br>
            <br>
            <br>
            <div for="">______ /______ /______</div>
            <p>วันที่รับบิล</p>
        </div>
        <div class="center" style="flex:1;padding: 10px;white-space: nowrap;">
            <br>
            <br>
            <br>
            <br>
            <div for="">______ /______ /______</div>
            <p>วันที่กำหนดชำระ</p>
        </div>
        <div class="center" style="flex:1;padding: 10px;white-space: nowrap;">
            <br>
            <br>
            <br>
            <br>
        </div>
        <div class="center" style="flex:1;padding: 10px;white-space: nowrap;">
            <br>
            <br>
            <br>
            <br>
            <div for="">______________________</div>
            <p>ผู้วางบิล</p>
        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';

    let branch = getQueryString('branch');
    let billno = getQueryString('code');
    $.get(path + 'acc/getbilling?branch=' + branch + '&code=' + billno, function (r) {
        if (r.billing.header !== null) {
            ShowData(r.billing);
        }
    });
   
    $('#something').text('64050195(KPS21/1348)');
    $('#totalTxt').text('ห้าหมื่นหกพันบาทถ้วน');
  
    function ShowData(data) {
        if (data.header.length > 0) {
            $('#no').text(data.header[0][0].BillAcceptNo);
            $('#date').text(ShowDate(CDateTH(data.header[0][0].BillDate)));
           
        }
        if (data.customer.length > 0) {
         
            $('#companyName').text(data.customer[0][0].NameEng);
            $('#address1').text(data.customer[0][0].EAddress1);
            $('#address2').text(data.customer[0][0].EAddress2);
        }
        if (data.detail.length > 0) {
            let total = 0;
            let serv = 0;
            let adv = 0;
            let vat = 0;
            let wh1 = 0;
            var detail = document.getElementById("detail");   
           
            let dv = $('#detail');
          
            let i = 0;
            for (let dr of data.detail[0]) {
                i += 1;
                let html = '';
                html += '<td class="center">' + i + '</td>';
                html += '<td>' + dr.InvNo + '</td>';
                html += '<td>' + ShowDate(CDateTH(dr.InvDate)) + '</td>';
                html += '<td>' + ShowDate(CDateTH(dr.DueDate)) + '</td>';
                if (dr.AmtAdvance) {
                    html += '<td>' + ShowNumber(dr.AmtAdvance, 2) + '</td>';
                } else if (dr.AmtChargeNonVAT) {
                    html += '<td>' + ShowNumber(dr.AmtChargeNonVAT, 2) + '</td>';
                } else {
                    html += '<td>' + ShowNumber(dr.AmtChargeVAT, 2) + '</td>';
                }
                html += '<td>' + ShowNumber(dr.AmtVAT, 2) + '</td>';

                html += '<td>' + ShowNumber(dr.AmtAdvance + dr.AmtChargeNonVAT + dr.AmtChargeVAT + dr.AmtVAT, 2) + '</td>';
            
             
                total += Number(dr.AmtAdvance + dr.AmtChargeNonVAT + dr.AmtChargeVAT + dr.AmtVAT);
              
                var tr = document.createElement("TR");
                tr.innerHTML += html;
                detail.insertBefore(tr, detail.childNodes[i+1]); 
            }
            $('#frieght').text(ShowNumber(total, 2));
            $('#total').text(ShowNumber(total, 2));
        }
    }
</script>