
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "DEBIT NOTE"
    ViewBag.ReportName = "DEBIT NOTE"
End Code
<style>
    * {
        font-family: Tahoma;
        font-size: 11px;
    }

    td {
        font-size: 11px;
        border-width: thin;
        border: 1px black solid;
    }



    table {

        border-collapse: collapse;
    }

    .row {
        width: 100%;
        display: flex;
        flex: 1;
        border: 1px black solid;
        text-align:center;
    }

    .center{
        text-align:center;
    }

    .right {
        text-align: right;
    }
</style>
<table style="width:100%">
    <tr>
        <td id="billAddress" rowspan="6" style="width:40%;vertical-align:top" >
            <b>Bill to Address</b>
            <br>
            <label id="companyName"></label>
            <label id="forwarderName"> SHIPPING LINES (THAILAND) CO.,LTD <br></label>
            <br>
            <br>
            <label id="address1"></label>
            <label id="address2">PATHUMWAN BANGKOK 10330 TH</label>
        </td>     
        <td class="center" style="width:20%">DEBIT NOTE NO: </td>
        <td class="center" style="width:20%"><label id="dbNo"></label></td>
        <td class="center" style="width:20%"> </td>
    </tr>
    <tr>
        <td class="center">DEBIT NOTE DATE:</td>
        <td class="center"><label id="dbDate" ></label></td>
        <td></td>
    </tr>
    <tr>
        <td class="center">SAP VENDOR NUMBER:</td>
        <td class="center"><label id="sapVenNo" >1000088767</label></td>
        <td></td>
    </tr>
    <tr>
        <td class="center">BL NO REFERENCE:</td>
        <td class="center"><label id="blRef" ></label></td>
        <td></td>
    </tr>
    <tr>
        <td class="center">LOCATION :</td>
        <td class="center"><label id="location" >THAILAND</label></td>
        <td></td>
    </tr>
    <tr>
        <td  class="center">CURRENCY:</td>
        <td class="center"><label id="currency" ></label></td>
        <td></td>
    </tr>
</table>
<table style="width:100%">
    <tr>
        <td class="center" style="width:5%">No.</td>
        <td class="center" style="width:40%">Description</td>
        <td class="center" style="width:15%">SAP Code</td>
        <td class="center" style="width:10%"></td>
        <td class="center" style="width:10%">Amount</td>
        <td class="center"  style="width:20%">Actual Amount</td>
    </tr>
    <tr>
        <td class="center" style="vertical-align:top" id="number"></td>
        <td height="600px" style="vertical-align:top">
            <label id="desc"></label>
        </td>
        <td class="center" style="vertical-align:top" id="sapCode"></td>
        <td></td>
        <td class="right" style="vertical-align:top" id="Amount"></td>
        <td class="right" style="vertical-align:top" id="ActualAmount"></td>
    </tr>
    <tr>
        <td class="center"  rowspan="2">Amount in Words</td>
        <td class="center"  rowspan="2" colspan="2"><label id="txtThb"></label></td>
        <td colspan="2">Sub-Total Value </td>
        <td class="right"><label id="subTotal"></label></td>
    </tr>
    <tr>
        <td colspan="2">VAT 7%</td>
        <td class="right"><label id="vat"></label></td>
    </tr>
    <tr>
        <td rowspan="2" colspan="3"></td>
        <td colspan="2">Grand Total payable</td>
        <td class="right"><label id="grandTotal"></label></td>
    </tr>
   <tr>
       <td class="center" colspan="3">
           <br />
           <br />
           <br />
           AUTHORISED SIGNATORY
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
        $('#dbNo').text(h.AdvNo);
        //$('#lblReqDate').text(ShowDate(GetToday()));
      //  $('#lblCustCode').text(h.CustCode + '/' + h.CustBranch);
    
        $('#dbDate').text(ShowDate(h.AdvDate));
        $('#currency').text(h.MainCurrency); 
    

        //$('#lblPayTo').text(h.PayChqTo);
       // ShowPendingAmount(h.BranchCode, h.EmpCode);
        //ShowCustomer(h.CustCode, h.CustBranch);

       // ShowUserSign(path,h.EmpCode, '#lblReqBy');
        //ShowUserSign(path,h.ApproveBy, '#lblAppBy');
        //ShowUserSign(path,h.EmpCode, '#lblPayBy');

      //  $('#lblRequestDate').text(ShowDate(h.AdvDate));
        //$('#lblAppDate').text(ShowDate(h.ApproveDate));
        //$('#lblPayDate').text(ShowDate(h.PaymentDate));

        //let jt = h.JobType;
        //let sb = h.ShipBy;
        //let at = h.AdvType;
        //if (jt < 10) jt = '0' + jt;
        //if (sb < 10) sb = '0' + sb;
        //if (at < 10) at = '0' + at;
        //ShowConfig(path,'JOB_TYPE', jt, '#lblJobType');
        //ShowConfig(path,'SHIP_BY', sb, '#lblShipBy');
        //ShowConfig(path,'ADV_TYPE', at, '#lblAdvType');
        //if (h.AdvCash > 0) {
        //    $('#chkCash').prop('checked', true);
        //    $('#txtAdvCash').text(ShowNumber(h.AdvCash, 2) + ' ' + h.SubCurrency);
        //}
        //if (h.AdvChq > 0) {
        //    $('#chkCustChq').prop('checked', true);
        //    $('#txtAdvChq').text(ShowNumber(h.AdvChq, 2) + ' ' + h.SubCurrency);
        //}
        //if (h.AdvChqCash > 0) {
        //    $('#chkCompChq').prop('checked', true);
        //    $('#txtAdvChqCash').text(ShowNumber(h.AdvChqCash, 2) + ' ' + h.SubCurrency);
        //}
        //if (h.AdvCred > 0) {
        //    $('#chkCredit').prop('checked', true);
        //    $('#txtAdvCred').text(ShowNumber(h.AdvCred, 2) + ' ' + h.SubCurrency);
        //}
       // $('#txtNetAmt').val(CCurrency(h.TotalAdvance.toFixed(2)));
   
        //$('#txtWHTAmt').val(CCurrency(h.Total50Tavi.toFixed(2)));
       // $('#txtTotalAmt').val(CCurrency((h.TotalAdvance - h.TotalVAT + h.Total50Tavi).toFixed(2)));

     
        ////show details
        let d = data.adv.detail;
        let jobno = d[0].ForJNo;
        //$('#lblJNo').text(jobno);
        $.get(path + 'JobOrder/GetJobSql?BranchCode=' + h.BranchCode + '&JNo=' + jobno).done(function (r) {
            if (r.job.data.length > 0) {
                let j = r.job.data[0];
                //$('#blRef').text(j.BLNo);
                $('#blRef').text(j.HAWB);
                $.get(path + 'Master/GetCompany?Code=' + j.Consigneecode ).done(function (r) {
                    let c = r.company.data[0];
                    $('#companyName').text(c.NameEng);
                    $('#address1').text(c.EAddress1);
                    $('#address2').text(c.EAddress2);
                
                })
                ShowVender(path, j.ForwarderCode, '#forwarderName');
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
    function ShowDetail(r,h) {
        //Dummy Data
        let no = '';
        let strDesc = '';
        let strJob = '';
        let strAmt = '';
        let strWht = '';
        let totAmt = 0;
        let vat = 0.00;
        let subtotal = 0.00;
        //let vat = 0;
        //let wht = 0;


        for (i = 0; i < r.length; i++) {
            let d = r[i];
            no += (i + 1) + ")<br>";
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
            $('#sapCode').html($('#sapCode').html() + $('#sapVenNo').html() + '<br/>');
            subtotal += d.AdvAmount;
            console.log(subtotal);
            vat += d.ChargeVAT;
          
            //wht += d.Charge50Tavi;
        }
        $('#number').html(no);
        $('#desc').html(strDesc);
        $('#Amount').html(strAmt);
        $('#ActualAmount').html(strAmt);
        $('#subTotal').text(CCurrency(Number.parseFloat(subtotal).toFixed(2)));
        $('#vat').text(CCurrency(Number.parseFloat(vat).toFixed(2)));
        $('#grandTotal').text(CCurrency(Number.parseFloat(subtotal + vat).toFixed(2)));
        $('#txtThb').text(CNumThai(Number.parseFloat(vat + subtotal).toFixed(2)));
   
       

    }

</script>