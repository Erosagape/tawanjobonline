@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "QUOTATION"
    ViewBag.Title = "Quotation Form"
End Code
<style>
    * {
        font-family: Tahoma;
        font-size: 11px;
    }

    td {
        font-size: 11px;
    }

    th {
        text-align: center;
    }

    .number {
        text-align: right;
    }

    tr {
        vertical-align: top;
    }

    table {
        border-width: thin;
        border-collapse: collapse;
    }
</style>
<div style="display:flex">
    <div style="flex:1">
        CUSTOMER : <label id="lblCustName"></label>
    </div>
    <div style="flex:1">
        <div style="flex:1;text-align:right">
            REF : <label id="lblQNo"></label>
        </div>
    </div>
</div>

<div style="display:flex">
    <div style="flex:1">
        <label id="lblCustAddress"></label>
    </div>
    <div style="flex:1">
        <div style="flex:1;text-align:right">
            DATE : <label id="lblDocDate"></label>
        </div>
    </div>
</div>

<div style="display:flex">
    <div style="flex:1">
        <label id="lblCustTelFax"></label>
    </div>
    <div style="flex:1">
        <div style="flex:1;text-align:right">
            OFFERED TO : <label id="lblContactName"></label>
        </div>
    </div>
</div>
<br />
<div style="display:flex">
    <div style="flex:1">
        <label id="lblDescriptionH"></label>
    </div>
</div>

<table style="" border="1" width="100%">
    <thead>
        <tr style="background-color:lightgrey;">
            <th width="5%">NO.</th>
            <th width="45%">DESCRIPTION</th>
            <th width="5%">UNIT</th>
            <th width="5%">QTY</th>
            <th width="15%">UNIT PRICE</th>
            <th width="5%">XRT</th>
            <th width="10%">AMOUNT<br />(FC)</th>
            <th width="10%">NET<br />(THB)</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    <tfoot>
        <tr>
            <td colspan="6" class="number">GRAND TOTAL (THB)</td>
            <td colspan="2" style="text-align:right"><label id="lblTotalCharge"></label></td>
        </tr>
    </tfoot>
</table>
<p>
    <br />
    <div style="display:flex">
        <div style="flex:1">
            REMARKS : <label id="lblTRemark"></label>
        </div>
    </div>
    <br />
    <label id="lblDescriptionF"></label>
</p>
<p>
    Best Regards,
    <br /><br /><br /><br />
    <label id="lblManagerName"></label>
</p>
<br />
<div style="display:flex;">
    <div style="border:1px solid black ;border-radius:5px;flex:1;text-align:center;">
        FOR THE CUSTOMER
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
        AUTHORIZED SIGNATURE
    </div>
    <div style="border:1px solid black;border-radius:5px;flex:1;text-align:center">
        FOR THE COMPANY
        <br /><br /><br />
        <p>_____________________</p>
        _____________________<br />
        ___/_______/___<br />
    </div>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let docno = getQueryString('docno');
    $.get(path + 'joborder/getquotation?branch=' + branch + '&code=' + docno, function (r) {
        if (r.quotation.header !== null) {
            ShowData(r.quotation);
        }
    });
    function LoadCustomer(cde, br) {
        $.get(path + 'master/getcompany?code=' + cde + '&branch=' + br, function (r) {
            if (r.company.data.length > 0) {
                let c = r.company.data[0];
                $('#lblCustName').text(c.Title + ' ' + c.NameThai);
                $('#lblCustAddress').text(c.TAddress1 + '\n' + c.TAddress2);
                $('#lblCustTelFax').text((CStr(c.Phone) == '' ? '' : 'Tel :' + CStr(c.Phone)) + (CStr(c.FaxNumber) == '' ? '' : ' Fax :' + CStr(c.FaxNumber)));
            }
        });
    }
    function ShowData(dt) {
        let h = dt.header[0];
        LoadCustomer(h.CustCode, h.CustBranch);

        $('#lblQNo').text(h.QNo);
        $('#lblDocDate').text(ShowDate(CDateTH(h.DocDate)));
        $('#lblTRemark').html(CStr(h.TRemark));
        $('#lblContactName').text(h.ContactName);
        $('#lblDescriptionH').html(CStr(h.DescriptionH));
        $('#lblDescriptionF').html(CStr(h.DescriptionF));

        ShowUser(path, h.ManagerCode, '#lblManagerName');

        let html = '';
        let service = 0;
        let irow = 0;
        for (let d of dt.detail) {

            html = '<tr style="background-color:lightyellow;"><td>' + d.SeqNo + '</td>';
            html += '<td colspan="3">' + d.Description + '</td>';
            html += '<td colspan="2">' + d.JobTypeName + '</td>';
            html += '<td colspan="2">' + d.ShipByName + '</td>';
            html += '</tr>';
	irow=0;
            $('#tbDetail').append(html);
            let items = dt.item.filter(function (data) {
                return data.SeqNo == d.SeqNo;
            });
            for (let i of items) {
		irow+=1;
                let desc = i.DescriptionThai;
                let amtTotal = Number(i.TotalCharge) * Number(i.QtyEnd);
                desc += i.UnitDiscntAmt > 0 ? '<br/>Discount (Rate=' + i.UnitDiscntPerc + '%)=' + i.UnitDiscntAmt : '';
                html = '<tr><td></td>';
                //html += '<td>' + d.SeqNo + '.' + i.ItemNo + ' ' + desc + '</td>';
		html += '<td>' + d.SeqNo + '.' + irow + ' ' + desc + '</td>';
                html += '<td>' + i.UnitCheck + '</td>';
                html += '<td>' + i.QtyBegin + '-' + i.QtyEnd + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(i.ChargeAmt, 2) + ' ' + i.CurrencyCode + '</td>';
                html += '<td style="text-align:center">' + i.CurrencyRate + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(i.TotalAmt,2) + '</td>';
                html += '<td style="text-align:right">' + ShowNumber(amtTotal,2) + '</td>';
                html += '<tr></tr>';

                $('#tbDetail').append(html);
                service += amtTotal;
            }
        }
        $('#lblTotalCharge').text(ShowNumber(service, 2));
    }
</script>