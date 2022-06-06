@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.Title = "Invoice Slip"
End Code
<style>
    #pFooter {
        display: none;
    }

    * {
        font-size: 11px;
    }

    body {
        line-height: 1;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .bold {
        font-weight: bold;
    }

    .table td, .table th, .table thead th {
        padding: 0.3em;
    }

    .curveBorder {
        border: 1px solid black;
        /* border-radius: 10px;*/
        padding: 5px;
    }

    .underLine {
        border-bottom: 1px solid black !important;
    }

    .upperLine {
        border-top: 1px solid black !important;
    }

    .verticalLine {
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }

    .textSpace {
        width: 20em;
    }

    #dvFooter {
        display: none;
    }

    table {
        width: 100%;
        border-color: #66ffcc;
        border-style: solid;
        border-width: 0px;
    }

        /*    #details td {
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }

    #tbhead th {
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }

    #tbfoot > tr > td {
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }*/
        table td {
            padding: 5px;
        }

    #hbltable td {
        border: 1px solid #66ffcc;
    }

    #tbdetail td {
        border-bottom-width: 0px;
        border-top-width: 0px;
    }
</style>
<div style="display:flex;width: 100%;">
    <div style="flex:1">
        <img id="imgLogoAdd" src="/bft/Resource/BFT_RPT_P1.jpg" style="width: 100%;">
    </div>
    <div id="master" class="bold" style="display: flex; flex-direction: column; justify-content: center; text-align: center; width: 100px; height: 60px; display: none">
        <h1 style="font-size:20px">ORIGINAL</h1>

    </div>
    <div id="copy" class="bold" style="display:flex;flex-direction:column;justify-content :center;text-align:center;width:100px;height:60px;display:none">
        <h1 style="font-size:20px">COPY</h1>
    </div>
</div>
<div style="display:flex;width: 100%;">
    <div style="width:30%">
        <img id="imgLogoAdd" src="/bft/Resource/BFT_RPT_P2.jpg" style="width: 100%;">
    </div>
    <div style="width:40%"></div>
    <div style="width:30%">
        <h2 style="font-size:16px" class="right" id="headerDoc" ondblclick="ChangeHeader()">CREDIT NOTE</h2>
    </div>
</div>
<table border="0" style="width: 100%; height: 100%; border-bottom-width: medium; border-top-width: medium">
    <tr>
        <td align="left" style="width: 20%">
            PARTNER
        </td>
        <td>:</td>
        <td id="billToEName" style="width: 50%">
        </td>
        <td style="width: 10%">
            CN NO.
        </td>
        <td>:</td>
        <td id="CNno" style="width: 20%">
        </td>
    </tr>
    <tr border="0">
        <td colspan="3" rowspan="2">
            <label id="billToAdd1"></label><label id="billToAdd2"></label>
        </td>
        <td>
            DATE
        </td>
        <td>:</td>
        <td id="indate">
        </td>
    </tr>
    <tr border="0">
        <td>
            BFT NO.
        </td>
        <td>:</td>
        <td id="jobno">
        </td>
    </tr>
    <tr border="0">
        <td>
            CONTACT
        </td>
        <td>:</td>
        <td id="acc">
        </td>
        <td>
            REF.
        </td>
        <td>:</td>
        <td id="refno">
        </td>
    </tr>
    <tr border="0">
        <td>
            ACCOUNT
        </td>
        <td>:</td>
        <td id="email">
        </td>
        <td>
            HBL.
        </td>
        <td>:</td>
        <td id="HBL">
        </td>
    </tr>
    <tr border="0">
        <td>
            E-MAIL
        </td>
        <td>:</td>
        <td id="billToContact">
        </td>
        <td>
            MBL.
        </td>
        <td>:</td>
        <td id="MBL">
        </td>
    </tr>
</table>
<table border="0" style="width:100%; height:100%">
    <tr>
        <td>
            PORT OF LOADING
        </td>
        <td>:</td>
        <td id="loadport">
        </td>
        <td>
            PORT OF DISCHARGE
        </td>
        <td>:</td>
        <td id="dcport">
        </td>
    </tr>
    <tr>
        <td>
            ETD
        </td>
        <td>:</td>
        <td id="etd">
        </td>
        <td>
            ETA
        </td>
        <td>:</td>
        <td id="eta">
        </td>
    </tr>
    <tr>
        <td>
            FEEDER
        </td>
        <td>:</td>
        <td id="mvess">
        </td>
        <td>
            VESSEL
        </td>
        <td>:</td>
        <td id="vess">
        </td>
    </tr>
    <tr>
        <td>
            SHIPPER
        </td>
        <td>:</td>
        <td id="CustCode">
        </td>
        <td>
            CONSIGNEE
        </td>
        <td>:</td>
        <td id="consigneecode">
        </td>
    </tr>
    <tr>
        <td>
            NOTIFY
        </td>
        <td>:</td>
        <td id="noti">
        </td>
        <td>
            CUST INV.
        </td>
        <td>:</td>
        <td id="custinv">
        </td>
    </tr>
    <tr>
        <td>
            CTN SIZE
        </td>
        <td>:</td>
        <td id="totalcontainer">
        </td>
        <td>
            CBM. : <label id="Measurement"></label>
        </td>
        <td></td>
        <td>
            G.W : <label id="gw"></label>
        </td>
    </tr>
</table>
<table id="hbltable" style="width:100%; height:100%; border-collapse:collapse">
    <tbody>
        <tr style="height: 30px; background-color: #c7fff2 ">
            <td style="text-align:center;border-left-width:0px" width="15%">
                H B/L NO.:
            </td>
            <td style="text-align:center" width="25%">
                DESCRIPTION
            </td>
            <td style="text-align:center" width="10%">
                QTYs
            </td>
            <td style="text-align:center" width="5%">
                UOM
            </td>
            <td style="text-align:center" width="5%">
                CURR.
            </td>
            <td style="text-align:center" width="10%">
                PRICE
            </td>
            <td style="text-align:center" width="10%">
                AMOUNT
            </td>
            <td style="text-align:center" width="10%">
                DEBIT
            </td>
            <td style="text-align: center; border-right-width: 0px" width="10%">
                CREDIT
            </td>
        </tr>
    </tbody>

    <tbody id="tbdetail" style="padding:1px">
    </tbody>


    @*<tr>
            <td>
                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
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
            <td>
            </td>
            <td>
            </td>
        </tr>*@
    <tbody id="tbSubtotal" style="padding:1px">
    </tbody>
    <tbody>
        @*<tr>
                <td colspan="2" align="right">
                    SUBTOTAL:
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
                <td id="debit">
                </td>
                <td>
                </td>
            </tr>*@
        <tr style="background-color: #c7fff2">
            <td style="width: 85%; border-left-width: 0px" colspan="7">
                TOTAL BALANCE DUE TO : <label id="tbdt"></label>
            </td>
            <td  style="width: 10%;  text-align:right">
            </td>
            <td id="ttbdt" style="width: 5%; border-right-width: 0px;text-align:right">
            </td>
        </tr>
        <tr>
            <td colspan="9" style=" border-left-width: 0px; border-right-width: 0px; text-align:center" id="number">
                <br />
            </td>
        </tr>
    </tbody>

</table>
<table border="0" style="width:100%; height:100%">
    <tr>
        <td style="width:60%">
            REMARK:
        </td>
        <td style="width:40%">
            <div style="padding-top:10px;">
                BETTER FREIGHT & TRANSPORT CO.,LTD
            </div>
            <div style="padding-top: 10px; font-style: italic; color: #66ffcc">
                Signed by
            </div>

            <div style="width: 100%; border-bottom: 1px #66ffcc solid; text-align: center; padding-top: 10px"><p style="color: blue; font-size: 14px;">@viewbag.username</p></div>
            <div id="userPos" style="text-align: center; padding-top: 10px;"></div>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="border-top: solid; border-bottom: solid; border-color: #66ffcc;line-height:2">
            BANK INFORMATION<br />
            BENEFICIARY: BETTER FREIGHT & TRANSPORT CO.,LTD.<br />
            ACCOUNT NO.: 840-105-0029-401635-501(USD)<br />
            BANK NAME: BANGKOK BANK PUBLIC CO.LTD.<br />
            BANK ADDRESS: 182 SUKHUMVIT RD., KLONGTOEY BANGKOK 10110<br />
            SWIFT CODE: BKKBTHBK
        </td>
    </tr>
</table>






<script type="text/javascript">

    $('#pFooter').hide();
    $('#imgLogo').hide();
    $('#imgLogoAdd').show();

    let ans = confirm('OK to print Original or Cancel For Copy');
    if (ans == true) {
        $('#master').show();
    } else {
        $('#copy').show();
    }

    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let code = getQueryString('code');

    loadData();

    async function loadData() {
        let GetInvoice = await $.get(path + '/Acc/GetInvoice?Branch=' + branch +   '&Code=' + code);
        let h = GetInvoice.invoice.header[0][0];
        let c = GetInvoice.invoice.customer[0][0];
        let j = GetInvoice.invoice.job[0][0];
        let d = GetInvoice.invoice.detail[0];
        let clr = await $.get(path + 'clr/getclearingreport?job=' + j.JNo + '&Branch=' + j.BranchCode);
        let clrd = clr.data.filter((data) => {
            return data.LinkBillNo == code;
        });
;

        console.log(clrd);
        let sum = 0;
        for (item of clrd) {
            sum = sum + item.FFNet;
            $('#tbdetail').html($('#tbdetail').html() +
                `<tr>
                    <td style="border-left-width:0px">${j.HAWB}</td>
                    <td>${item.SDescription}</td>
                    <td style="text-align:center">${ShowNumber(item.Qty,3)}</td>
                    <td style="text-align:center">${item.UnitCode}</td>
                    <td style="text-align:center">${item.CurrencyCode}</td>
                    <td style="text-align:right">${ShowNumber(item.FUnitCost, 2)}</td>
                    <td style="text-align:right">${ShowNumber(item.FFNet,2)}</td>
                    <td style="text-align:right"></td>
                    <td style="text-align:right;border-right-width:0px">${ShowNumber(item.FFNet, 2)}</td>
                </tr>`)

        }
        $('#tbSubtotal').html(
         `<tr>
            <td style="border-left-width:0px; text-align:right" colspan="2">SUB TOTAL:</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td style="text-align:right"></td>
            <td style="text-align:right"></td>
            <td style="text-align:right;border-right-width:0px">${ShowNumber(sum, 2)}</td>
        </tr>`);
        $('#ttbdt').html(
            `${ShowNumber(sum, 2)}`);
        $('#number').html(
            `${CNumEng(ShowNumber(sum, 2))}`);

        $('#CNno').text(code);
        $('#indate').text(ShowDate(h.DocDate));
        $('#jobno').text(j.JNo);
        $('#eta').text(ShowDate(j.ETADate));
        $('#etd').text(ShowDate(j.ETDDate));
        $('#mvess').text(j.MVesselName);
        $('#vess').text(j.VesselName);
        $('#Measurement').text(j.Measurement);
        $('#HBL').text(j.HAWB);
        $('#MBL').text(j.MAWB);
        $('#refno').text(j.CustRefNO);

        $('#gw').text(j.TotalGW);
        $('#totalcontainer').text(j.TotalContainer);
        $('#custinv').text(j.InvNo);
        $("#dcport").text(j.ClearPortNo);
        $('#CustCode').text(c.NameEng);
        ShowInterPort(path, (j.JobType == 1 ? j.InvFCountry : j.InvCountry), j.InvInterPort, '#loadport').then(() => {
            $.get(path + 'Master/GetCountry?Code=' + (j.JobType == 1 ? j.InvFCountry : j.InvCountry)).done(function (r) {
                $('#loadport').text(($('#loadport').text() + " ," + r.country.data[0].CTYName).toUpperCase());
            });
        });
        //console.log(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch)
        $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch).done(function (r) {
            console.log(r.company);
            /*console.log(r.company.data[0].NameEng);*/
            $('#billToEName').text(r.company.data[0].NameEng);
            $('#tbdt').text(r.company.data[0].NameEng);
            $('#billToAdd1').text(r.company.data[0].EAddress1);
            $('#billToAdd2').text(r.company.data[0].EAddress2);
            $('#billToContact').text(r.company.data[0].DMailAddress);
            $('#acc').text(r.company.data[0].CSCodeIM);
            $('#email').text(r.company.data[0].CSCodeEX);
            r.Phone = "34343434";
            $('#tell').text(r.Phone)
            $('#fax').text(r.FaxNumber)
            /*console.log(r.company.contact);*/
        });


        $.get(path + 'Master/GetCompany?Code=' + j.Consigneecode).done(function (r) {
            $('#consigneecode').text(r.company.data[0].NameEng);
            //console.log(r.company.data[0].NameEng);
        })



        $.get(path + 'joborder/GetBooking?job=' + j.JNo + '&Branch=' + branch).done(function (r) {

            $('#noti').text(r.booking.data[0].NotifyName);
        //    console.log(r.company.data[0].NameEng);
        })
        //let comp = await $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch);
        $('#debit').text(h.DocNo);
        $('#billToAdd1').text(c.EAddress1);
        $('#billToAdd2').text(c.EAddress2);

        ShowUserPosition(path,"@viewbag.user", "#userPos");


        $('#tell').text(c.Phone)
        $('#fax').text(c.FaxNumber)
    }

        //$('#billToEName').text(comp.company.data[0].NameEng);
        //$('#billToAdd1').text(comp.company.data[0].EAddress1);
        //$('#billToAdd2').text(comp.company.data[0].EAddress2);
        //comp.company.data[0].Phone = "34343434";
        //$('#tell').text(comp.company.data[0].Phone)
        //$('#fax').text(comp.company.data[0].FaxNumber)
        //
        //$.get(path + '/Acc/GetInvoice?form=debit&Branch=00&Code=TIVS-2204145').done(function (r) {
        //    let h = r.invoice.header[0][0];
        //    let c = r.invoice.customer[0][0];
        //    let j = r.invoice.job[0][0];
        //    $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch)

        //});


</script>