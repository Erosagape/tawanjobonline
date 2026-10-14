@Code
    ViewData("Title") = "Shipment Notification"
    Layout = "~/Views/Shared/_Report.vbhtml"
End Code
<style>
    * {
    	text-transform : uppercase !important;
    }
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

<table style="width:100%">
<tbody style="border:1px solid black">
<tr>
	<td style="white-space:nowrap"><b> JOB NO./เลขที่งาน  <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblJobNo"></td>
	<td style="white-space:nowrap"><b> DATE/วันที่ <b></td>
	<td style="border-bottom:1px solid black;width:250px"  colspan="2" id="lblOpenDate"></td>
</tr>
<tr>
	<td style="white-space:nowrap"><b> CUSTOMER'S NAME/ชื่อลูกค้า <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblCustName"></td>
	<td style="white-space:nowrap"><b> CUST INV./inv ลูกค้า <b></td>
	<td style="border-bottom:1px solid black;width:250px"  colspan="2" id="lblInvNo"></td>

</tr>
<tr>
	<td style="white-space:nowrap"><b> COMMODITIES/ชื่อสินค้า <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="5" id="lblInvProduct"></td>
</tr>

<tr>
	<td style="white-space:nowrap"><b> NO. OF PACKAGES/จำนวนสินค้า <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" ><label id="lblInvQty"></label> <label id="lblInvUnit"></label> </td>
	<td style="white-space:nowrap"><b> NO. CONT/จำนวนตู้<b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblTotalContainer"></td>
</tr>
<tr>
	<td style="white-space:nowrap"><b> M.VESSEL/เรือแม่ <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblMVesselName"></td>
	<td style="white-space:nowrap"><b> FEEDER/เรือถ่ายลำ<b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblVesselName"></td>
</tr>
<tr>
	<td style="white-space:nowrap"><b> ETA/วันเรือเข้า <b></td>
	<td style="border-bottom:1px solid black;width:150px" id="lblETADate"></td>
	<td style="white-space:nowrap"><b>WAREHOUSE NO./โกดังที่ <b></td>
	<td style="border-bottom:1px solid black;"></td>
	<td style="white-space:nowrap"><b>PORTท่า	<b></td>
	<td style="border-bottom:1px solid black;width:250px" id="lblToPort"></td>
</tr>

<tr>
	<td style="white-space:nowrap"><b> B/L NO./ใบตราส่ง <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblBLNo"></td>
	<td style="white-space:nowrap"><b> INS./ค่าประกัน<b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2"></td>
</tr>
<tr>
	<td style="white-space:nowrap"><b> HOUSE BL<b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblHAWBNo"></td>
	<td style="white-space:nowrap"><b> MASTER BL<b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="2" id="lblMAWBNo"></td>
</tr>



<tr>

	<td colspan="4"><br></td>
</tr>
</tbody>

</table>
<br>
<b> STATUS/สถานภาพ <b>

<div style="display:flex">
	<div style="flex:1"> <input type="checkbox"/> PORT W/H/เข้าโกดัง</div>
	<div style="flex:1"> <input type="checkbox"/> TRAILING/ตู้ลาก</div>
	<div style="flex:1"> <input type="checkbox"/>UNSTUFFING/ขนส่งหน้าตู้</div>
</div>
<div style="display:flex">
	<div style="flex:1"> <input type="checkbox"/> แรงงานเรือ</div>
	<div style="flex:1"> <input type="checkbox"/> แรงงานชิปปิ้ง</div>
	<div style="flex:1"> </div>
</div>

<table style="width:100%">
<tr>
	<td style="white-space:nowrap" ><b> SHIPPING'S AGENT/บริษัทเรือ <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="3"><label id="lblAgentName"></label></td>
	<td style="white-space:nowrap"><b>CONT./ติดต่อ<b></td>
	<td style="border-bottom:1px solid black;width:250px" ></td>
</tr>
<tr>
	<td style="white-space:nowrap"><b>TEL/โทร <b></td>
	<td style="border-bottom:1px solid black;width:150px"></td>
	<td style="white-space:nowrap"><b>Ext./ต่อ <b></td>
	<td style="border-bottom:1px solid black;width:50px"></td>
	<td style="white-space:nowrap"><b>FAX./แฟ็กซ์	<b></td>
	<td style="border-bottom:1px solid black;width:250px"></td>
</tr>
<tr>
	<td style="white-space:nowrap" ><b>OTHER./อื่นๆ <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="5"></td>
	
</tr>
</table>
<br>
<table border="1" style="width:100%">
	<tr>
		<th>DOC. REC/เอกสารที่ได้รับ</th>
		<th>DATE REC./วันที่</th>
		<th>REMARK./หมายเหตุ</th>
	</tr>
	<tr>
		<td style="white-space:nowrap">INV,PL</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">Arrival Notice </td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">COA / SDS / Tank Cer</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">Form E</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">Booking</td><td></td><td></td>
	</tr>
	
</table>
<br>
<table border="1" style="width:100%">
	<tr>
		<th>JOB STATUS/ความเคลื่อนไหวของงาน</th>
		<th>DATE REC./วันที่</th>
		<th>REMARK./หมายเหตุ</th>
	</tr>
	<tr>
		<td style="white-space:nowrap">เช็คใบอนุญาต/ปริมาณคงเหลือ/ประเทศที่ส่งออกได้</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">จองเรือ</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">Booking NO.</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">Arrival Notice / Enter BL / Surrender BL</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">คีย์ DG-Net / วอ.อก 6 / FDA / DOE / TISI</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">จ่ายค่า DO / รับ DO </td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">ส่งเอกสารให้ Shipping</td><td></td><td></td>
	</tr>

	<tr>
		<td style="white-space:nowrap">จ่ายค่า Ocaen Fireght</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">จ่ายค่าภาษี</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">จ่ายค่า DG Surcharge</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">ลากตู้/ตรวจปล่อยวันที่</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">จองรถ</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">จัดส่งวันที่/สถานที่/ดรอปตู้</td><td></td><td></td>
	</tr>
	<tr>
		<td style="white-space:nowrap">OTHER./ อื่นๆ</td><td></td><td></td>
	</tr>
</table>

<br>
<table style="width:100%">
<tr>
	<td style="white-space:nowrap" ><b> LICENSE PLATE NO. /ทะเบียนรถ <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="5"></td>

</tr>
<tr>
	<td style="white-space:nowrap" ><b> DRIVER'S NAME/ชื่อพนักงานขับรถ  <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="3"></td>
	<td style="white-space:nowrap" ><b>TEL/โทร<b></td>
	<td style="border-bottom:1px solid black;width:250px" ></td>

</tr>
<tr>
	<td style="white-space:nowrap"><b>TEL/โทร <b></td>
	<td style="border-bottom:1px solid black;width:150px"></td>
	<td style="white-space:nowrap"><b>Ext./ต่อ <b></td>
	<td style="border-bottom:1px solid black;width:50px"></td>
	<td style="white-space:nowrap"><b>FAX./แฟ็กซ์	<b></td>
	<td style="border-bottom:1px solid black;width:250px"></td>
</tr>
<tr>
	<td style="white-space:nowrap" ><b>OTHER./อื่นๆ <b></td>
	<td style="border-bottom:1px solid black;width:250px" colspan="5"><br></td>
</tr>
<tr>
	<td style="border-bottom:1px solid black;width:250px" colspan="6"><br></td>
</tr>
<tr>
	<td style="border-bottom:1px solid black;width:250px" colspan="6"><br></td>
</tr>
<tr>
	<td style="border-bottom:1px solid black;width:250px" colspan="6"><br></td>
</tr>
</table>


<script type="text/javascript">
    	let path = '@Url.Content("~")';    
	let br = getQueryString('BranchCode');
        let jno = getQueryString('JNo');
        if (br != "" && jno != "") {
            GetJob(br, jno);
        }

	function GetJob(Branch, Job) {
        $.get(path+'joborder/getjobsql?branch=' + Branch + '&jno=' + Job)
            .done(function (r) {
                if (r.job.data.length > 0) {
                    var rec = r.job.data[0];
                    DisplayData(rec);
                    $.get(path + 'joborder/gettransportdetail?branch=' + Branch + '&Job=' + Job + '& Code=' + rec.BookingNo).done(function (r) {
                       
                        if (r.transport.detail.length > 0) {
                            let html = "";
                            for (t of r.transport.detail) {
                                let arr = [t.CTN_NO, t.DriverName, t.CarLicense, t.Location, ShowDate(t.TargetYardDate) + "<br/>" + ShowTime(t.TargetYardTime), ShowDate(t.UnloadDate) + "<br/>" + ShowTime(t.UnloadTime), ShowDate(t.TruckIN) + "<br/>" + ShowTime(t.Start), ShowDate(t.ActualYardDate) + "<br/>" + ShowTime(t.ActualYardTime), ShowDate(t.UnloadFinishDate) + "<br/>" + ShowTime(t.UnloadFinishTime), ShowDate(t.ReturnDate) + "<br/>" + ShowTime(t.Finish)];
                                console.log(arr);
                                html += "<tr>" + arr.map(x => "<td>" + x + "</td>") + "</tr>";
                            }
                            $("#containertb").html(html);
                        }
                    });
                    return;
                }
        });

    	}

	function ShowCustomer(Code, Branch, isCons) {
        let url = '';
        if (isCons == true) {
            $('#lblBillToCustName').text('-');
            $('#dvBillAddr').html('<b>Address : </b>-');
            url = path + 'Master/GetCompany?Code=' + Code;
        }
        if (isCons == false) {
            $('#lblCustName').text('-');
            $('#dvAddr').html('<b>Address : </b>-');
            $('#lblTel').text('-');
            $('#lblFax').text('-');
            url = path + 'Master/GetCompany?Code=' + Code + '&Branch=' + Branch;
        }
        if ((Code + Branch).length > 0) {
            $.get(url)
                .done(function (r) {
                    if (r.company.data.length > 0) {
                        var c = r.company.data[0];
                        if (isCons == true) {
                            $('#lblBillToCustName').text(c.NameEng + ' Tax Reference :' + c.TaxNumber);
                            $('#dvBillAddr').html('<b>Address : </b>'
                                + (c.EAddress1 + ' ' + c.EAddress2).trim());
                        }
                        if (isCons == false) {
                            $('#lblCustName').text(c.NameThai);
                            $('#dvAddr').html('<b>Address : </b>'
                                + (c.TAddress1 + ' ' + c.TAddress2).trim());
                            $('#lblTel').text(c.Phone);
                            $('#lblFax').text(c.FaxNumber);
                        }
                    }
                });
        }
    }

    function DisplayData(j) {
        $('#txtJNo').val(j.JNo);
        $('#lblJobNo').text(j.JNo);
        $('#lblOpenDate').text(ShowDate(j.DocDate));
        $('#lblConfirmDate').text(ShowDate(j.ConfirmDate));
        $('#lblETDDate').text(ShowDate(j.ETDDate));
        $('#lblETADate').text(ShowDate(j.ETADate));
        $('#lblLoadDate').text(ShowDate(j.LoadDate));
        $('#lblDeliveryDate').text(ShowDate(j.EstDeliverDate));
        $('#lblQuotation').text(j.QNo);
        $('#lblInvNo').text(j.InvNo);
        $('#lblCurrency').text(j.InvCurUnit);
        $('#lblExcRate').text(j.InvCurRate);
        $('#lblInvProduct').text(j.InvProduct);
        $('#lblInvTotal').text(j.InvTotal + ' ' + CStr(j.InvCurUnit));
        $('#lblInvQty').text(j.InvProductQty);
	$('#lblBLNo').text(j.BLNo);

        ShowInvUnit(path, j.InvProductUnit, '#lblInvUnit');

        $('#lblPackQty').text(j.TotalQty);
        $('#lblPackUnit').text('PKGS');
        $('#lblTotalGW').text(j.TotalGW);
        $('#lblTotalNW').text(j.TotalNW);

        ShowInvUnit(path, j.GWUnit, '#lblNWUnit');
        ShowInvUnit(path, j.GWUnit, '#lblGWUnit');
        $('#lblMeasurement').text(j.Measurement);
        $('#lblBookingNo').text(j.BookingNo);
        $('#lblHAWBNo').text(j.HAWB);
        $('#lblMAWBNo').text(j.MAWB);
        $('#lblVesselName').text(j.VesselName);
	$('#lblMVesselName').text(j.MVesselName);
        $('#lblTotalContainer').text(j.TotalContainer);
        $('#lblDeclareNo').text(j.DeclareNumber);
        $('#lblContact').text(j.CustContactName);
        $('#lblDutyAmt').text(j.DutyAmount + ' THB');
        $('#lblTaxPrivilege').text(j.TyClearTaxReson);
        $('#lblShippingCmd').text(j.ShippingCmd);
        let str =j.Description.replace(/(?:\r\n|\r|\n)/g, '<br/>');
        $('#lblDescription').html(str);

        var jt = j.JobType;
        var sb = j.ShipBy;
        if (jt < 10) jt = '0' + jt;
        if (sb < 10) sb = '0' + sb;
        ShowConfig(path, 'JOB_TYPE', jt, '#lblJobType');
        ShowConfig(path, 'SHIP_BY', sb, '#lblShipBy');

        $('#lblCustCode').text(j.CustCode);
        ShowCustomer(j.CustCode, j.CustBranch, false);

        $('#lblBillToCustCode').text(j.Consigneecode);
        ShowCustomer(j.Consigneecode, j.CustBranch, true);

        ShowCountry(path, j.InvFCountry, '#lblFromCountry');
        ShowCountry(path, j.InvCountry, '#lblToCountry');
        if (j.JobType == '1') {

            ShowInterPort(path,j.InvFCountry, j.InvInterPort, '#lblFromPort');
            ShowReleasePort(path,j.ClearPort, '#lblToPort');
        } else {
            ShowInterPort(path,j.InvCountry, j.InvInterPort, '#lblToPort');
            ShowReleasePort(path,j.ClearPort, '#lblFromPort');
        }
        ShowVender(path,j.ForwarderCode, '#lblAgentName');
        ShowVender(path,j.AgentCode, '#lblTransportName');

        ShowDeclareType(path,j.DeclareType,'#lblDeclareType');
        ShowUser(path,j.CSCode, '#lblCSName');
        ShowUser(path,j.ShippingEmp, '#lblShippingName');

        $('#lblPosition').text('Customer Services');
    }
</script>
