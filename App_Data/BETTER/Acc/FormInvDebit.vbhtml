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
    table {
        border-color: coral;
    }
    #hbltable td {
        border-left: solid;
        border-right :solid;
        border-color: coral;
    }
</style>
<table border="0" style="width:100%; height:100%; border-bottom:solid; border-top:solid">
    <tr>
        <td align="left">
            PARTNER:
        </td>
        <td id="billToEName">
        </td>
        <td>
            CN NO.:
        </td>
        <td id="CNno">
        </td>
    </tr>
    <tr border="0">
        <td colspan="2" rowspan="2">
            <label id="billToAdd1"></label><label id="billToAdd2"></label>
        </td>
        <td>
            DATE:
        </td>
        <td id="indate">
        </td>
    </tr>
    <tr border="0">
        <td>
            BFT NO.:
        </td>
        <td id="jobno">
        </td>
    </tr>
    <tr border="0">
        <td>
            CONTACT:
        </td>
        <td id="billToContact">
        </td>
        <td>
            REF.:
        </td>
        <td>
        </td>
    </tr>
    <tr border="0">
        <td>
            ACCOUNT:
        </td>
        <td id="acc">
        </td>
        <td>
            HBL.:
        </td>
        <td id="HBL">
        </td>
    </tr>
    <tr border="0">
        <td>
            E-MAIL:
        </td>
        <td id="email">
        </td>
        <td>
            MBL.:
        </td>
        <td>
        </td>
    </tr>
</table>
<table border="0" style="width:100%; height:100%">
    <tr>
        <td>
            PORT OF LOADING:
        </td>
        <td id="loadport">
        </td>
        <td>
            PORT OF DISCHARGE:
        </td>
        <td id="dcport">
        </td>
    </tr>
    <tr>
        <td>
            ETD:
        </td>
        <td id="etd">
        </td>
        <td>
            ETA:
        </td>
        <td id="eta">
        </td>
    </tr>
    <tr>
        <td>
            FEEDER:
        </td>
        <td id="mvess">
        </td>
        <td>
            VESSEL:
        </td>
        <td id="vess">
        </td>
    </tr>
    <tr>
        <td>
            SHIPPER:
        </td>
        <td id="CustCode">
        </td>
        <td>
            CONSIGNEE:
        </td>
        <td id="consigneecode">
        </td>
    </tr>
    <tr>
        <td>
            NOTIFY:
        </td>
        <td id="noti">
        </td>
        <td>
            CUST INV.:
        </td>
        <td id="custinv">
        </td>
    </tr>
    <tr>
        <td>
            CTN SIZE:
        </td>
        <td id="totalcontainer">
        </td>
        <td>
            CBM.:<label id="Measurement"></label>
        </td>
        <td>
            G.W:<label id="gw"></label>
        </td>
    </tr>
</table>
<table id="hbltable" style="width:100%; height:100%; border-collapse:collapse">
    <tbody>
        <tr style="height:30px">
            <td style="text-align:center">
                H B/L NO.:
            </td>
            <td style="text-align:center">
                DESCRIPTION
            </td>
            <td style="text-align:center">
                QTYs
            </td>
            <td style="text-align:center">
                UOM
            </td>
            <td style="text-align:center">
                CURR.
            </td>
            <td style="text-align:center">
                PRICE
            </td>
            <td style="text-align:center">
                AMOUNT
            </td>
            <td style="text-align:center">
                DEBIT
            </td>
            <td style="text-align:center">
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
        <tr>
            <td style="width:85%" colspan="8">
                TOTAL BALANCE DUE TO:
            </td>
            <td style="width:15%">
            </td>
        </tr>
        <tr>
            <td colspan="9">
                <br />
            </td>
        </tr>
    </tbody>

</table>
<table border="0" style="width:100%; height:100%">
    <tr>
        <td style="width:75%">
            REMARK:
        </td>
        <td>
            BETTER FREIGHT & TRANSPORT CO.,LTD<br />
            Signed by
        </td>
    </tr>
    <tr>
        <td colspan="2">
            BANK INFORMATION<br />
            BENEFICIARY: BETTER FREIGHT $ TRANSPORT CO.,LTD.<br />
            ACCOUNT NO.: 840-105-0029-401635-501(USD)<br />
            BANK NAME: BANGKOK BANK PUBLIC CO.LTD.<br />
            BANK ADDRESS: 182 SUKHUMVIT RD., KLONGTOEY BANGKOK 10110<br />
            SWIFT CODE: BKKBTHBK
        </td>
    </tr>
</table>


@*<div style="display:flex;width: 100%;">
        <div style="flex:1">
            <img id="imgLogoAdd" src="/bft/Resource/BFT_RPT_P1.jpg" style="width: 100%;">
        </div>
        <div id="master" class="bold" style="display: flex; flex-direction: column; justify-content: center; text-align: center; width: 100px; height: 60px; display: none">
            <h1 style="font-size:20px">ตันฉบับ</h1>
            <h2 style="font-size:16px"> สำหรับลูกค้า</h2>
        </div>
        <div id="copy" class="bold" style="display:flex;flex-direction:column;justify-content :center;text-align:center;width:100px;height:60px;display:none">
            <h1 style="font-size:20px">สำเนา</h1>
            <h2 style="font-size:16px"> สำหรับลูกค้า</h2>
        </div>
    </div>
    <div style="display:flex;width: 100%;">
        <div style="width:30%">
            <img id="imgLogoAdd" src="/bft/Resource/BFT_RPT_P2.jpg" style="width: 100%;">
        </div>
        <div style="width:40%"></div>
        <div style="width:30%">
            <h2 style="font-size:16px" class="right" id="headerDoc" ondblclick="ChangeHeader()">ใบแจ้งหนี้/INVOICE</h2>
        </div>
    </div>*@


<table style="border:1px solid black">
    <tr>
        <td>
            MESSRS:
        </td>
        <td>
            (_______)
        </td>
        <td>
            DEBIT NOTE NO.:
        </td>
        <td id="debit">
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            DATE:
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td id="billToAdd1">
        </td>
        <td>
        </td>
        <td>
            CR. TERM:
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td id="billToAdd2">
        </td>
        <td>
        </td>
        <td>
            DUE DATE:
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            CURRENCY:
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <div style="display:flex">
                <div style="flex:1">
                    TEL:<label id="tell"></label>
                </div>
                <div style="flex:1">
                    FAX: <label id="fax"></label>
                </div>
            </div>
        </td>
        <td>
        </td>
        <td>
            REF NO.:
        </td>
        <td>
        </td>
    </tr>
</table>


<script type="text/javascript">

/*    $('#pFooter').hide();*/
    //$('#imgLogo').hide();
    //$('#imgLogoAdd').show();

    //let ans = confirm('OK to print Original or Cancel For Copy');
    //if (ans == true) {
    //    $('#master').show();
    //} else {
    //    $('#copy').show();
    //}

    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let code = getQueryString('code');

    loadData();
   // alert(getQueryString('form'));
    //$.get(path + 'Acc/GetInvoice?Branch=' + branch + '&Code=' + code).done(function (r) {
    //    if (r.invoice.header.length > 0) { }

    //});


    //console.log(code);
    async function loadData() {
        let GetInvoice = await $.get(path + '/Acc/GetInvoice?Branch=' + branch +   '&Code=' + code);
        let h = GetInvoice.invoice.header[0][0];
        let c = GetInvoice.invoice.customer[0][0];
        let j = GetInvoice.invoice.job[0][0];
        let d = GetInvoice.invoice.detail[0];


        let sum = 0;
        for (item of d) {
            console.log(item.SDescription);
            sum = sum + item.FTotalAmt;

            $('#tbdetail').html($('#tbdetail').html() +
                `<tr>
                    <td>${item.HAWB}</td>
                    <td>${item.SDescription}</td>
                    <td style="text-align:center">${item.Qty}</td>
                    <td style="text-align:center">${item.QtyUnit}</td>
                    <td style="text-align:center">${item.CurrencyCode}</td>
                    <td style="text-align:right">${item.FUnitPrice}</td>
                    <td style="text-align:right">${item.FTotalAmt}</td>
                    <td style="text-align:right">${item.FTotalAmt}</td>
                    <td style="text-align:right"></td>
                </tr>`)

        }
        $('#tbdetail').html($('#tbdetail').html() +
         `<tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td style="text-align:right">${sum}</td>
            <td style="text-align:right"></td>
            <td style="text-align:right"x></td>
        </tr>`);


        $('#CNno').text(code);
        $('#indate').text(ShowDate(h.DocDate));
        $('#jobno').text(j.JNo);
        $('#eta').text(ShowDate(j.ETADate));
        $('#etd').text(ShowDate(j.ETDDate));
        $('#mvess').text(j.MVesselName);
        $('#vess').text(j.VesselName);
        $('#Measurement').text(j.Measurement);
        $('#HBL').text(j.HAWB);
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
        console.log(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch)
        $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch).done(function (r) {
            console.log(r.company);
            /*console.log(r.company.data[0].NameEng);*/
            $('#billToEName').text(r.company.data[0].NameEng);
            $('#billToAdd1').text(r.company.data[0].EAddress1);
            $('#billToAdd2').text(r.company.data[0].EAddress2);
            $('#billToContact').text(r.company.data[0].ManagerCode);
            $('#acc').text(r.company.data[0].CSCodeIM);
            $('#email').text(r.company.data[0].CSCodeEX);
            r.Phone = "34343434";
            $('#tell').text(r.Phone)
            $('#fax').text(r.FaxNumber)
            /*console.log(r.company.contact);*/
        });


        //$.get(path + 'Master/GetCompany?Code=' + j.Consigneecode).done(function (r) {
        //    $('#consigneecode').text(r.company.data[0].NameEng);
        //    console.log(r.company.data[0].NameEng);
        //})
        console.log(jobno);

        $.get(path + 'joborder/GetBooking?Code=' + j.JNo + '&Branch=' + branch).done(function (r) {
            $('#consigneecode').text(r.booking.data[0].NameEng);
            $('#noti').text(r.booking.data[0].NotifyName);
        //    console.log(r.company.data[0].NameEng);
        })
        //let comp = await $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch);
        $('#debit').text(h.DocNo);
        $('#billToAdd1').text(c.EAddress1);
        $('#billToAdd2').text(c.EAddress2);














        c.Phone = "34343434";
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