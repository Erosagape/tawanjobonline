@Code
    Layout = "~/Views/Shared/_ReportNoHead.vbhtml"
    ViewBag.ReportName = "BILL OF LADING"
    ViewBag.Title = "BILL OF LADING"
End Code
<style>
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
        border: 0px none;
        padding: 0.5em;
    }

    .curveBorder {
        border: 1px solid black;
        border-radius: 10px;
        padding: 5px;
    }

    .underLine {
        border-bottom: 1px solid black !important;
    }

    .upperLine {
        border-top: 1px solid black !important;
    }

    .textSpace {
        width: 20em;
    }
</style>

<p class="center bold">
    <label id="companyName" style="font-size:20px"></label>
</p>
<p class="center bold">
    <label id="address">ที่อยู่</label>
</p>
<p class="center bold">
    <label id="taxIdLbl">TAX ID :</label>
    <label id="taxId"></label>
</p>
<p class="center bold">
    <label style="font-size:16px">ใบแจ้งหนี้/INVOICE</label>
</p>

<div style="display:flex">
    <div style="flex:60%" class="curveBorder">
        <table class="table table-borderless">
            <tbody>
                <tr>
                    <td class="bold">
                        <label id="billToLbl">BILL TO NAME AND ADDRESS</label>
                    </td>
                    <td class="right">
                        <label id="id"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="billTo">

                        </label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="flex:2%">

    </div>
    <div style="flex:38%" class="curveBorder">
        <table class="table table-borderless">
            <tbody>
                <tr>
                    <td>
                        <label id="invoiceNoLbl">INVOICE NO.:</label>
                    </td>
                    <td>
                        <label id="invoiceNo"> </label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="invoiceDateLbl">INVOICE DATE:</label>
                    </td>
                    <td>
                        <label id="invoiceDate"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="crTermLbl">CR. TERM:</label>
                    </td>
                    <td>
                        <label id="crTerm"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="dueDateLbl">DUE DATE:</label>
                    </td>
                    <td>
                        <label id="dueDate"></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="currencyLbl">CURRENCY:</label>
                    </td>
                    <td>
                        <label id="currency"></label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<table class="table">

    <tbody>
        <tr>
            <td><label id="destinyLbl">ORIGIN/ DEST</label></td>
            <td>:</td>
            <td><label id="destiny"></label></td>

            <td><label id="jobNoLbl">JOB NO.</label></td>
            <td>:</td>
            <td><label id="jobNo"></label></td>

            <td></td>
            <td></td>
            <td></td>
        </tr>

        <tr>
            <td><label id="vesselLbl">VESSEL/VOYAGE</label></td>
            <td>:</td>
            <td><label id="vessel">SINAR SOLO V. 936N</label></td>

            <td><label id="etdLbl">ETD</label></td>
            <td>:</td>
            <td><label id="etd"></label></td>

            <td><label id="etaLbl">ETA</label></td>
            <td>:</td>
            <td><label id="eta"></label></td>
        </tr>

        <tr>
            <td><label id="hblNoLbl">H-B/L NO.</label></td>
            <td>:</td>
            <td><label id="hblNo"></label></td>

            <td><label id="quantityLbl">QUANTITY</label></td>
            <td>:</td>
            <td><label id="quantity"></label></td>

            <td><label id="totpkgLbl">TOTPKG</label></td>
            <td>:</td>
            <td><label id="totpkg"></label></td>
        </tr>

        <tr>
            <td><label id="newBlNoLbl">NEW B/L NO</label></td>
            <td>:</td>
            <td><label id="newBlNo"></label></td>

            <td><label id="weightLbl">WEIGHT</label></td>
            <td>:</td>
            <td><label id="weight"></label></td>

        </tr>

        <tr>
            <td><label id="containerNoLbl">CONTANER NO.</label></td>
            <td>:</td>
            <td><label id="containerNo"></label></td>

            <td><label id="volumeLbl">VOLUME</label></td>
            <td>:</td>
            <td><label id="volume"></label></td>
        </tr>

        <tr>
            <td><label id="custInvNoLbl">CUST INV NO.</label></td>
            <td>:</td>
            <td><label id="custInvNo"></label></td>

            <td><label id="refLbl">REF.</label></td>
            <td>:</td>
            <td><label id="ref"></label></td>
        </tr>

        <tr>
            <td><label id="carrierLbl">CARRIER</label></td>
            <td>:</td>
            <td><label id="carrier"></label></td>
        </tr>
    </tbody>
</table>

<table class="table  table-borderless">
    <thead>
        <tr class="upperLine underLine">
            <th class="bold align-top" rowspan="2">DESCRIPTION</th>
            <th class="center bold" colspan="6">IN SOURCE CURRENCY</th>
            <th class="center bold" colspan="3">AMOUNT IN THB</th>
        </tr>
        <tr class="upperLine">
            <th class="center bold">W/T</th>
            <th class="center bold">QTYs</th>
            <th class="center bold">UOM</th>
            <th class="center bold">Curr.</th>
            <th class="center bold">Exc.</th>
            <th class="center bold">@ UNIT</th>
            <th class="center bold">ADVANCE</th>
            <th class="center bold">NON VAT</th>
            <th class="center bold">VAT</th>
        </tr>
    </thead>
    <tbody>
        <tr class="upperLine">
            <td>INSPECTION CHARGE</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">2,500.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">2,500.00</td>
        </tr>
        <tr>
            <td>CUSTOMS CLEARANCE CHARGE</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">3,000.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">3,000.00</td>
        </tr>
        <tr>
            <td>FDA</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">2,000.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">2,000.00</td>
        </tr>
        <tr>
            <td>LPI PERMIT (DFA)</td>
            <td class="right">3.00</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">1,800.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
            <td class="right">1,800.00</td>
        </tr>
        <tr>
            <td>TRANSPORTATION</td>
            <td class="right">1.00</td>
            <td class="right">1.000</td>
            <td class="center">TRUCK</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">9,200.00</td>
            <td class="right">-</td>
            <td class="right">- </td>
            <td class="right">9,200.00</td>

        </tr>
        <tr>
            <td>THC , B/L, D/O ( RECEIPT )</td>
            <td class="right">-</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">8,223.68</td>
            <td class="right">8,223.68</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
        <tr>
            <td>CUSTOM TAX ( RECEIPT )</td>
            <td class="right">-</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">200.00</td>
            <td class="right">200.00</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
        <tr>
            <td>WAREHOUSE RENTAL(RECEIPT)</td>
            <td class="right">-</td>
            <td class="right">1.000</td>
            <td class="center">SET</td>
            <td class="right">THB</td>
            <td class="right">1.00000</td>
            <td class="right">676.13</td>
            <td class="right">676.13</td>
            <td class="right">-</td>
            <td class="right">-</td>
        </tr>
    </tbody>
</table>
<table class="table">
    <thead></thead>
    <tbody>
        <tr class="upperLine">
            <td class="underLine">TAX RATE</td>
            <td class="center underLine">GROSS</td>
            <td class="center underLine">W/T AMT</td>
            <td id="amountLbl" class="right">AMOUNT:</td>
            <td id="advanceAmount" class="right"></td>
            <td id="nonVatAmount" class="right" style="width:5em"></td>
            <td id="vatAmount" class="right"></td>
        </tr>
        <tr>
            <td id="taxRate1"></td>
            <td id="gross1" class="center right"></td>
            <td id="wtAmt1" class="center right"></td>
            <td id="valueAddedTaxLbl" class="right">VALUE ADDED TAX 7%:</td>
            <td class="right underLine"></td>
            <td class="right underLine"></td>
            <td id="valueAddedTax" class="right underLine"></td>
        </tr>
        <tr>
            <td id="taxRate1_5"></td>
            <td id="gross1_5" class="center right"></td>
            <td id="wtAmt1_5" class="center right"></td>
            <td id="totalAmountLbl" class="right">TOTAL AMOUNT:</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="totalAmount" class="right"></td>
        </tr>
        <tr>
            <td id="taxRate3"></td>
            <td id="gross3" class="center right"></td>
            <td id="wtAmt3" class="center right"></td>
            <td id="lessWithholdingTaxLbl" class="right">LESS: WITHHOLDING TAX:</td>
            <td class="right underLine"></td>
            <td class="right underLine"></td>
            <td id="lessWithholdingTax" class="right underLine"></td>
        </tr>
        <tr class="underLine">
            <td class="center"></td>
            <td class="center"></td>
            <td class="center"></td>
            <td id="netAmountLbl" class="right">NET AMOUNT:</td>
            <td class="right"></td>
            <td class="right"></td>
            <td id="netAmount" class="right"></td>
        </tr>
    </tbody>
</table>

<p>TOTAL AMOUNT IN WORDS: BAHT TWENTY-EIGHT THOUSAND FIVE HUNDRED TWENTY-THREE AND</p>
<p class="bold">DULY CHECKED AND RECEIVED IN GOOD CONDITION</p>
<table class="table">
    <tr>
        <td class="bold">Reciever :</td>
        <td class="underLine textSpace"></td>
        <td class="bold">Sender :</td>
        <td class="underLine textSpace"></td>
        <td> </td>
        <td class="underLine center">ALISA</td>
    </tr>
    <tr>
        <td class="bold">DATE :</td>
        <td class="underLine  textSpace"></td>
        <td class="bold">DATE :</td>
        <td class="underLine  textSpace"></td>
        <td> </td>
        <td class="center bold">AUTHORIZED SIGNATURE</td>
    </tr>
</table>
<p class="bold">PLEASE ISSUE A CROSSED CHEQUE PAYABLE TO "TOTAL SHIPPING SERVICE CO.,LTD."</p>
<p class="bold">หมายเหตุ ใบแจ้งหนี้นี้มิใช่ใบกำกับภาษี ใบกำกับภาษีจะออกให้ต่อเมื่อได้รับชำระเงินเรียบร้อยแล้ว</p>
<script src="~/Scripts/Func/reports.js"></script>
<script>
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    function LoadData() {
        $.get("http://103.225.168.137/total/acc/getinvoice?branch=00&code=IVS-2100001")
            .done(function (r) {
                console.log(JSON.stringify(r));
            });
    }


</script>
<script>
    // onload();
    function onload() {
        $("#companyName").text("TOTAL SHIPPING SERVICE CO.,LTD. (HEAD OFFICE)");
        $("#address").text("");
        $("#taxId").text("");
        $("#id").text("(102333)");
        $("#billTo").text("ชื่อที่่อยู่บริษัทลูกค้า");
        $("#invoiceNo").text("SLI21040096");
        $("#invoiceDate").text("02/04/2021");
        $("#crTerm").text("Cash");
        $("#dueDate").text("28/05/2021");
        $("#currency").text("THB");
        $("#destiny").text("PASIR GUDANG-BANGKOK");
        $("#jobNo").text("SI2104027");
        $("#vessel").text("SINAR SOLO V. 936N");
        $("#etd").text("26/03/2021");
        $("#eta").text("05/04/2021");
        $("#hblNo").text("POTA/BKP/21/00391");
        $("#quantity").text("7.086 CBM");
        $("#totpkg").text("5.000P ALLETS");
        $("#newBlNo").text("PCSINBKK2101157 Q");
        $("#weight").text("4,190.000 GW");
        $("#containerNo").text("TCNU8509617/40'HC");
        $("#volume").text("");
        $("#custInvNo").text("");
        $("#ref").text("");
        $("#carrier").text("GATEWAY CONTAINER LINE CO.,LTD.");

        $("#advanceAmount").text("9,099.81");
        $("#nonVatAmount").text("-");
        $("#vatAmount").text("18,500.00");
        $("#valueAddedTax").text("1,295.00");
        $("#totalAmount").text("28,894.81");
        $("#lessWithholdingTax").text("-371.00");
        $("#netAmount").text("28,523.81");


        $("#taxRate1").text("1%");
        $("#taxRate1_5").text("1.5%");
        $("#taxRate3").text("3%");

        $("#gross1").text("9200.00");
        $("#gross1_5").text("-");
        $("#gross3").text("9300.00");

        $("#wtAmt1").text("92.00");
        $("#wtAmt1_5").text("-");
        $("#wtAmt3").text("279.00");
    }
</script>