@Code
    ViewData("Title") = "Shipment Notification"
    Layout = "~/Views/Shared/_Report.vbhtml"
End Code
<style>
    #dvFooter,#pFooter {
        display:none;
    }
    .underline {
        border-bottom: solid;
        border-width: thin;
        border-collapse: collapse;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    .block {
        margin-bottom: 4px;
    }

        .block tr td {
            text-align: center;
        }

    .textleft {
        text-align: left !important;
    }

    .textright {
        text-align: right !important;
    }
</style>
<div style="display:flex;flex-direction:column;">
    <div class="block" style="width:100%;display:flex">
        <div style="flex:4;text-align:right">
            DATE :
        </div>
        <div id="dvCurrDate" class="underline" style="flex:1">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            CONSIGNEE:
        </div>
        <div id="dvConsignee" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            AGENT:
        </div>
        <div id="dvForwarder" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            B/L Number
        </div>
        <div id="dvBLNo" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            ETA
        </div>
        <div id="dvETADate" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            INVOICE
        </div>
        <div id="dvInvNo" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            SHIPPING
        </div>
        <div id="dvShipping" class="underline" style="flex:2">

        </div>
    </div>
    <div class="block" style="display:flex;flex-direction:row">
        <div style="flex:1">
            HABOUR
        </div>
        <div id="txtClearPort" class="underline" style="flex:2">

        </div>
        <div style="flex:1">
            PORT
        </div>
        <div id="txtInterPort" class="underline" style="flex:2">

        </div>
    </div>
    <table border="1" class="block">
        <tr>
            <td>REFERENCE</td>
            <td>LIST</td>
            <td style="width:15%">SLIP</td>
            <td colspan="2" style="width:20%">ADVANCE AMT</td>
            <td colspan="2" style="width:20%">CLEARING AMT</td>
            <td style="width:20%">SIGN</td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">RENT</td>
            <td></td>
            <td style="width:20%"></td>
            <td></td>
            <td style="width:20%"></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">CUSTOMS OVERTIME</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">SERVICE CHARGES</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">CUSTOMS DOCUMENT</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">CUSTOMS CHARGES</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">EQUIPMENT,LABOUR,TOOLS</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">TRANSPORT</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">PHYTO</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">PLANT</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">GATE CHARGES</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align:left">HEALTH CERTIFICATE</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td><br /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td><br /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <div class="block" style="width:100%;display:flex">
        <div style="flex:1;text-align:right">
            NOTE :
        </div>
        <div id="dvNote" class="underline" style="flex:4">

        </div>
    </div>
</div>
<script type="text/javascript">
    let path = '@Url.Content("~")';    
</script>
