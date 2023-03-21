@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "ใบอนุมัติทำเช็ค"
    ViewBag.ReportName = ""
End Code
<style>
    * {
        font-family: Tahoma;
        font-size: 11px;
    }

    #pFooter, #dvFooter {
        display: none;
    }

    td {
        font-size: 11px;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }

    .underline {
        border-bottom: solid;
        border-width: thin;
        border-collapse: collapse;
    }
</style>
TRANSPORT DEPARTMENT
<br />
PAY FOR :
<input type="checkbox" /> IMPORT &nbsp;&nbsp;
<input type="checkbox" /> EXPORT  &nbsp;&nbsp;
<input type="checkbox" /> OTHER ____________________
<div style="display:flex;flex-direction:column;align-items:center">
    <br/>
    <table style="width:50%" border="1">
        <tr>
            <td>TRUCK INVOICE NO</td>
            <td id="ApproveRef"></td>
        </tr>
        <tr>
            <td>TRANSPORT COMPANY</td>
            <td id="VenderName"></td>
        </tr>
        <tr>
            <td>TRANSPORT CHARGES</td>
            <td id="TotalTransport"></td>
        </tr>
        <tr>
            <td>DOCUMENT CHARGES</td>
            <td id="TotalOthers"></td>
        </tr>
        <tr>
            <td>TOTAL</td>
            <td id="TotalAmount"></td>
        </tr>
        <tr>
            <td>WITH HOLDING TAX</td>
            <td id="TotalTax"></td>
        </tr>
        <tr>
            <td>CHEQUE TOTAL</td>
            <td id="TotalNet"></td>
        </tr>
    </table>
    <br/>
    <table border="1">
        <tr>
            <td>INV</td>
            <td>B/L</td>
            <td>SHIPPER</td>
            <td>DATE</td>
            <td>ROUTE</td>
            <td>QTY</td>
            <td>TRUCK/TRIP</td>
            <td>EXTRA CHARGES</td>
            <td>TOTAL</td>
            <td>DEPOT/PORT</td>
            <td>TOTALS</td>
        </tr>
        <tbody  id="tbDetail"></tbody>
        <tr>
            <td colspan="5">TOTAL</td>
            <td></td>
            <td></td>
            <td id="GTExtraCharge"></td>
            <td id="GTTotalTrans"></td>
            <td id="GTDocument"></td>
            <td id="GTTotalAll"></td>
        </tr>
    </table>
</div>
<br/>
<div style="display:flex;flex-direction:row">
    <div style="flex:1">
        <br />
        <br />
        <br />
        __________________________________
        <br />Paruhas Boonpamorn
        <br />Approved Date _________/_________/_________
    </div>
    <div style="flex:1">
        <br />
        <br />
        <br />
        __________________________________
        <br />Phillips Pan
        <br />Approved Date _________/_________/_________
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const branchcode = getQueryString("Branch");
    const refno = getQueryString("Code");

    if (branchcode !== '' && refno !== '') {
        let url = 'Acc/GetPaymentReport?Branch=' + branchcode;
        if (refno !== '') {
            url += '&Code=' + refno;
        }
        $.get(path + url).done(function (r) {
            if (r.payment.data.length > 0) {
                let th = r.payment.data[0];
                $('#ApproveRef').html(th.ApproveRef);
                $.get(path + 'Master/GetVender?Code=' + th.VenCode).done(function (r) {
                    if (r.vender.data.length > 0) {
                        let dr = r.vender.data[0];
                        $('#VenderName').html(dr.TName);
                    }
                });

                let tb = r.payment.data;
                let totalTransport = 0;
                let totalExtra = 0;
                let totalDocument = 0;
                let totalWhtax = 0;
                let html = '';

                for (let dr of tb) {
                    totalTransport += Number(dr.Transport);
                    totalExtra += Number(dr.ExtraCharge);
                    totalDocument += Number(dr.Others);
                    totalWhtax += Number(dr.Tax50Tavi);

                    html += '<tr>';
                    html += '<td>' + dr.PoNo + '</td>';
                    html += '<td>' + dr.BookingRefNo + '</td>';
                    html += '<td>' + dr.CustCode + '</td>';
                    html += '<td>' + ShowDate(dr.InspectionDate) + '</td>';
                    html += '<td>' + dr.Location + '</td>';
                    html += '<td>' + dr.QTY + '</td>';
                    html += '<td>' + ShowNumber(dr.UnitPrice,2) + '</td>';
                    html += '<td>' + ShowNumber(dr.ExtraCharge,2) + '</td>';
                    html += '<td>' + ShowNumber(dr.Transport,2) + '</td>';
                    html += '<td>' + ShowNumber(dr.Others,2) + '</td>';
                    html += '<td>' + ShowNumber(Number(dr.Others) + Number(dr.Transport) + Number(dr.ExtraCharge),2) + '</td>';
                    html += '</tr>';
                }
                $('#tbDetail').html(html);

                $('#TotalTransport').html(ShowNumber(totalTransport, 2));
                $('#TotalOthers').html(ShowNumber(totalDocument+totalExtra, 2));
                $('#GTExtraCharge').html(ShowNumber(totalExtra, 2));
                $('#GTDocument').html(ShowNumber(totalDocument, 2));
                $('#TotalAmount').html(ShowNumber(totalTransport + totalDocument+totalExtra, 2));
                $('#GTTotalTrans').html(ShowNumber(totalTransport, 2));
                $('#GTTotalAll').html(ShowNumber(totalTransport + totalDocument+totalExtra, 2));
                $('#TotalTax').html(ShowNumber(totalWhtax, 2));
                $('#TotalNet').html(ShowNumber(totalTransport + totalDocument + totalExtra - totalWhtax, 2));
            }
        });
    }
</script>