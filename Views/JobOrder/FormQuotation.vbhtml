@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.ReportName = "QUOTATION"
    ViewBag.Title = "Quotation Form"
End Code
<style>
    * {
        font-family: Tahoma;
        font-size: 14px;
    }

    td {
        font-size: 14px;
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
<table style="width:100%">
	<tbody>
        <tr>
            <td style="width:60%">
                CUSTOMER : <label id="lblCustName"></label>
            </td>
            <td style="width: 20%">   </td>
            <td> REF  </td>
            <td> : </td>
            <td>
                <label id="lblQNo"></label>
            </td>
        </tr>
        <tr>
            <td>
                @*<label id="lblCustAddress"></label>*@
		CODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : <label id="lblCustCode"></label>
            </td>
            <td style="width: 20%">   </td>
            <td>DATE </td>
            <td>:</td>
            <td> <label id="lblDocDate"></label></td>
        </tr>
        @*<tr>
            <td> <label id="lblCustTelFax"></label></td>
        </tr>*@
	</tbody>
</table>
<span id="lblDescriptionH" style='white-space:pre-wrap;width:100%'></span>
@*<div style="display:flex">
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
</div>*@

<table style="margin-top:10px;" border="1" width="100%">
    <thead>
        <tr>
            <th width="5%">NO.</th>
            <th width="40%">DESCRIPTION</th>
            <th width="8%">UNIT</th>
            <th width="7%">QTY</th>
            <th width="15%">UNIT PRICE</th>
            <th width="5%">EXC</th>
            <th width="10%">AMOUNT<br />(FC)</th>
            <th width="10%">NET<br />(THB)</th>
        </tr>
    </thead>
    <tbody id="tbDetail"></tbody>
    @*<tfoot>
            <tr>
                <td colspan="4" class="number">GRAND TOTAL (THB)</td>
                <td style="text-align:right"><label id="lblTotalCharge"></label></td>
            </tr>
        </tfoot>*@
</table>
<p>
    <div>
 		<div>
<br>
			<div id="lblDescriptionF" style="word-wrap: break-word;white-space: pre-wrap;" ></div>
		</div>
		<div>
			<div id="lblTRemark" style="word-wrap: break-word;white-space: pre-wrap;width:100%;height:100%"></div>
		</div>
    </div>

</p>
<p>
    Best Regards
    <br /><br /><br />
    <label id="lblManagerName"></label>
</p>
<br />
<div style="display:none;">
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
  <table style="width: 100%;" border="1">
        <tbody style="text-align: center;">
            <tr style="text-align: center;background-color:lightgreen;">
                <td colspan="2"><label id="lblCmp"></label></td>
                <td>Order confirmation by customer</td>
            </tr>         
  	    <tr style="text-align: center;background-color:lightgreen;">
		<td > Quoted by</td>
                <td > Approve by</td>
		
                <td>Authorize Signature & Company Stamp</td>
            </tr>
            <tr>
                <td>
                    <br> <br> <br> <br> <br>
                </td>
 		<td>
                    <br> <br> <br> <br> <br>
                </td>
 		<td>
                    <br> <br> <br> <br> <br>
                </td>
            </tr>
            <tr >
                <td style="width:25%">
                    (<label id="lblQBy">________________</label>)<br>
                    <label id="lblQbyPosition">________________</label><br>
                    <label id="lblQDate">Date &nbsp;:________________  </label>
                </td>
                <td style="width:25%"> 
                    (<label id="lblABy">________________</label>)<br>
                    @*<label id="lblAbyPosition">________________ </label>*@
			<br>
                    <label id="lblADate">Date &nbsp;:________________  </label>
                </td>
		
                <td style="text-align:center;">
(________________)
<br>
<label id="lblCustEName"></label><br>
			Date &nbsp;: ________________
		</td>
            </tr>
        </tbody>
    </table>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let docno = getQueryString('docno');
    $.get(path + 'joborder/getquotation?branch=' + branch + '&code=' + docno, (r) =>{
        if (r.quotation.header !== null) {
            ShowData(r.quotation);
	    $.get(path + '/Master/GetUser?code='+r.quotation.header[0].ManagerCode,  (r)=> {
		let u = r.user.data[0];
		$('#lblQBy').text(u.EName?u.EName:"________________");
		$('#lblQDate').text("Date : "+ShowDate(new Date(Date.now()).toISOString()));
		$('#lblQbyPosition').text(u.TPosition?u.TPosition:"________________");
	    });
	    if(r.quotation.header[0].ApproveBy){
		$('#lblADate').text("Date : "+ShowDate(r.quotation.header[0].ApproveDate));
 		$.get(path + 'Master/GetUser?code='+r.quotation.header[0].ApproveBy, (r) =>{
			let u = r.user.data[0];
			$('#lblABy').text(u.EName?u.EName:"________________");
			$('#lblAbyPosition').text(u.TPosition?u.TPosition:"________________");
	    	});
	    }
 	   
	

        }
    });
    function LoadCustomer(cde, br) {
        $.get(path + 'master/getcompany?code=' + cde + '&branch=' + br, function (r) {
            if (r.company.data.length > 0) {
                let c = r.company.data[0];
                $('#lblCustName').text(c.Title + ' ' + c.NameThai);
                $('#lblCustEName').text(c.NameEng);
		$('#lblCustCode').text(c.CustCode);
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
        $('#lblTRemark').html(h.TRemark);
        $('#lblContactName').text(h.ContactName);
        $('#lblDescriptionH').text(h.DescriptionH);
        $('#lblDescriptionF').html(h.DescriptionF);

        //ShowUser(path, h.ManagerCode, '#lblManagerName');

        let html = '';
        let service = 0;
        let rowid=0;
        for (let d of dt.detail) {

            html = '<tr style="background-color:lightgreen;"><td style="text-align:center">' + d.SeqNo + '</td>';
            html += '<td colspan="3">' + d.Description + '</td>';
            //html += '<td colspan="2">' + d.JobTypeName + '</td>';
            //html += '<td colspan="2">' + d.ShipByName + '</td>';
            html += '<td colspan="2"></td>';
            html += '<td colspan="2"></td>';
            html += '</tr>';
            rowid++;
            $('#tbDetail').append(html);
            let items = dt.item.filter(function (data) {
                return data.SeqNo == d.SeqNo;
            });
	    let itemid=0;
            for (let i of items) {
		itemid++;
                let desc = i.DescriptionThai;
                let amtTotal = Number(i.TotalCharge) * Number(i.QtyEnd);
                desc += i.UnitDiscntAmt > 0 ? '<br/>Discount (Rate=' + i.UnitDiscntPerc + '%)=' + i.UnitDiscntAmt : '';
                html = '<tr><td></td>';
                html += '<td>' + rowid + '.' + itemid + ' ' + desc + '</td>';
                html += '<td>' + i.UnitCheck + '</td>';
                html += '<td style="text-align:center">' +  i.QtyEnd + '</td>';
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