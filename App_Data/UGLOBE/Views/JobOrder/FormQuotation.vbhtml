﻿@Code
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
        <pre id="lblDescriptionH"></pre>
    </div>
</div>

<table style="" border="1" width="100%">
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
    <tfoot>
        <tr>
            <td colspan="6" class="number">GRAND TOTAL (THB)</td>
            <td colspan="2" style="text-align:right"><label id="lblTotalCharge"></label></td>
        </tr>
    </tfoot>
</table>
<p>
    <br />
    <div style="display:flex;width:100%">
 		<div style="flex:4">
			<div id="lblDescriptionF" style="word-wrap: break-word;white-space: pre-wrap;" ></div>
		</div>
		<div style="flex:6">
			<div id="lblTRemark" style="word-wrap: break-word;white-space: pre-wrap;width:100%;height:100%"></div>
		</div>
    </div>
    <br />
</p>
<p>
    Best Regards,
    <br /><br /><br /><br />
    <label id="lblManagerName"></label>
<br/>
UNITED GLOBE LOGISTICS (THAILAND) CO.,LTD.<br/>
21/13 B BLDG.,ROYAL CITY AVENUE SOI SOONVIJAI<br/>
RAMA 9 ROAD, BANGKAPI, HUAYKWANG BANGKOK 10310<br/>
TELEPHONE NO. : 02-664-6229<br/>
FAX NO. :02-664-6232-3<br/>
ACCOUNT NO. 028-109-641-9 <br/>
BANK : KASIKORN THAI<br/>
BRANCH : NEW PETCHBURI ROAD.
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
                <td colspan="3"><label id="lblCmp"></label></td>
                <td>Order confirmation by customer</td>
            </tr>         
  	    <tr style="text-align: center;background-color:lightgreen;">
		<td > Quoted by</td>
		<td > Qualify by</td>
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
 		<td>
                    <br> <br> <br> <br> <br>
                </td>
            </tr>
            <tr >
                <td style="width:25%">
                    (<label id="lblQBy">________________</label>)<br>
                    <label id="lblQDate">Date &nbsp;:________________  </label><br>
                    <label id="lblQbyPosition">________________</label>
                </td>
		 <td style="width:25%"> 
                    (<label id="lblIBy">________________</label>)<br>
                    <label id="lblIDate">Date &nbsp;:________________  </label><br>
                    <label id="lblIbyPosition">________________ </label>
                </td>
                <td style="width:25%"> 
                    (<label id="lblABy">________________</label>)<br>
                    <label id="lblADate">Date &nbsp;:________________  </label><br>
                    <label id="lblAbyPosition">________________ </label>
                </td>
		
                <td style="text-align: left;">Date &nbsp;: <br>Position &nbsp;: </td>
            </tr>
        </tbody>
    </table>
<div id="companyText1" style="text-align:center;width:100%;display:none"><br/>
บริษัท ยูไนเต็ด โลจิสติกสั่ (ประเทศไทย จำกัด<br/>
21/13 ตึก มี รอยัลซิตื้อเวนิว ซอยศูนย์วิจัย ถนนพระรามเก้า<br/>
แขวงบางกะปี เขตห้วยขว้าง กรุงเทพฯ 103 10<br/>
เบอร์โทรศัพท์ : 02-664-6229<br/>
เบอร์แฟกซ์ : 02-664-6232-3<br/>
UNITED GLOBE LOGISTICS (THAILAND) CO.. LTD.<br/>
21/13 B BLDG., ROYAL CITY AVENUE SOI SOONVIJAI<br/>
RAMA 9 ROAD, BANGKAPI, HUAYKWANG BANGKOK 10310<br/>
TELEPHONE NO. : 02-664-6229<br/>
FAX NO. : 02-664-6232-3<br/>
เลขประจำตัวผู้เสียภาษี : 3-0331-1043-2<br/>
กรุณาโอนเงินเข้าบัญชีของทางบริษัท ตามนี้ค่ะ<br/>
บริษัท ยูไนเต็ด โกลบ โลจิสติกส์ (ประเทศไทย) จำกัด<br/>
UNITED GLOBE LOGISTICS (THAILAND) CO., LTD.<br/>
ธนาคาร กสิกรไทย / สาขมเพชรบุรีตัดใหม่<br/>
บัญชีกระแสรายวัน เลขที่ 028-109-641-9<br/>
ขอความกรุณา เมื่อโอนเงินเข้ามาแล้ว รบกวนแฟกซ์เอกสารการโอนเงินมาให้ด้วยนะค่ะ<br/>
เพื่อเป็นการยืนยันความถูกต้องของจำนวนเงิน ขอบคุณค่ะ<br/>
<br/>
</div>
<div id="companyText2" style="text-align:center;width:100%;display:none"><br/>
บริษัท ยู่ในเต็ด โกลบ ทรานสปอรั่ต จำกัด<br/>
21/13 ตึก มี รอยัลซิตื้อเวนิว ซอยศูนย์วิจัย ถนนพระรามเก้า<br/>
แขวงบางกะปี เขตห้วยขว้าง กรุงเทพฯ 10310<br/>
เบอร์โทรศัพท์ : 02-664-6229<br/>
เบอร์แฟกซ์ : 02-664-6232-3<br/>
UNITED GLOBE TRANSPORT CO.. LTD.<br/>
21/13 B BLDG., ROYAL CITY AVENUE SOI SOONVIJAI<br/>
RAMA 9 ROAD, BANGKAPI, HUAYKWANG BANGKOK 10310<br/>
TELEPHONE NO. : 02-664-6229<br/>
FAX NO. : 02-664-6232-3<br/>
เลขประจำตัวผู้เสียภาษี : 0105554111091<br/>
กรุณาโอนเงินเข้าบัญชีของทางบริษัท ตามนี้ค่ะ<br/>
บริษัท ยูไนเต็ด โกลบ ทรานสปอร์ต จำกัด<br/>
UNITED GLOBE TRANSPORT CO., LTD.<br/>
ธนาคาร กสิกรไทย / สาขมเพชรบุรีตัดใหม่<br/>
บัญชีกระแสรายวัน เลขที่ 028-109-774-1<br/>
ขอความกรุณา เมื่อโอนเงินเข้ามาแล้ว รบกวนแฟกซ์เอกสารการโอนเงินมาให้ด้วยนะ<br/>
เพื่อเป็นการยืนยันความถูกต้องของจำนวนเงิน ขอบคุณ<br/>
</div>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    let branch = getQueryString('branch');
    let docno = getQueryString('docno');

		//$('#companyText'+@Viewbag.DATABASE).show();
	console.log(@Viewbag.DATABASE);
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

        ShowUser(path, h.ManagerCode, '#lblManagerName');

        let html = '';
        let service = 0;
        let rowid=0;
        for (let d of dt.detail) {

            html = '<tr style="background-color:lightgreen;"><td>' + d.SeqNo + '</td>';
            html += '<td colspan="3">' + d.Description + '</td>';
            html += '<td colspan="2">' + d.JobTypeName + '</td>';
            html += '<td colspan="2">' + d.ShipByName + '</td>';
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
                html += '<td>' +  i.QtyEnd + '</td>';
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