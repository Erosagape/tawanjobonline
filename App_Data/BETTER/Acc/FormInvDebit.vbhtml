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

    #details td{
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }
    #tbhead th{
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }
    #tbfoot>tr>td {
        border-left: 1px solid black !important;
        border-right: 1px solid black !important;
    }
   
</style>
<div style="display:flex;width: 100%;" >
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
</div>


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
        <td id="billToEName">
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

  

    async function loadData() {
        let GetInvoice = await $.get(path + '/Acc/GetInvoice?form=debit&Branch=00&Code=TIVS-2204145');
        let h = GetInvoice.invoice.header[0][0];
        let c = GetInvoice.invoice.customer[0][0];
        let j = GetInvoice.invoice.job[0][0];
        console.log(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch)
        $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch).done(function (r) {
            console.log("Done : " + r.company.data[0].NameEng);
            let c = r.company.data[0];
            $('#billToEName').text(c.NameEng);
            $('#billToAdd1').text(c.EAddress1);
            $('#billToAdd2').text(c.EAddress2);
            c.Phone = "34343434";
            $('#tell').text(c.Phone)
            $('#fax').text(c.FaxNumber)
        });
        //let comp = await $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch);
        $('#debit').text(h.DocNo);
        $('#billToAdd1').text(c.EAddress1);
        $('#billToAdd2').text(c.EAddress2);













        c.Phone = "34343434";
        $('#tell').text(c.Phone)
        $('#fax').text(c.FaxNumber)
   

        //$('#billToEName').text(comp.company.data[0].NameEng);
        //$('#billToAdd1').text(comp.company.data[0].EAddress1);
        //$('#billToAdd2').text(comp.company.data[0].EAddress2);
        //comp.company.data[0].Phone = "34343434";
        //$('#tell').text(comp.company.data[0].Phone)
        //$('#fax').text(comp.company.data[0].FaxNumber)

        //$.get(path + '/Acc/GetInvoice?form=debit&Branch=00&Code=TIVS-2204145').done(function (r) {
        //    let h = r.invoice.header[0][0];
        //    let c = r.invoice.customer[0][0];
        //    let j = r.invoice.job[0][0];
        //    $.get(path + 'Master/GetCompany?Code=' + h.BillToCustCode + '&Branch=' + h.BillToCustBranch)

        //});
    }
</script>