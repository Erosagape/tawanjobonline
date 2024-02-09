
@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    'ViewBag.ReportName = "Truck Order"
    'ViewBag.Title = "ใบสั่งงานรถ (Truck Order)"
End Code
@*<div style="text-align:right;width:100%">
        <b>DATE :</b> <label id="lblBookingDate"></label><br/>
        <b>JOB NUMBER :</b> <label id="lblJNo"></label>
    </div>*@
<div style="width:100%">
    <div style="display:flex">
        <div style="width:60%">
            <label id="lblAgent1"> </label><br />
            <label id="lblAgentAddress_2"> </label>
        </div>
        <div style="width:40%">
            <label id="lblConfirmDate"></label>
        </div>
    </div>
    <div style="display:flex">
        <div style="width:10%">ATTN : </div>
        <div style="width:90%">
            IMPORT DEPARTMENT / FROM : <label id="lblCSCode"> </label>
        </div>
    </div>
    <div style="display:flex">
        <div style="width:10%">RE : </div>
        <div style="width:90%">
            VSSL AMENDMENT FOR CONSOLIDATION SHIPMENT B/L NO. <label id="lblBookingNo"></label><br />
            VESSEL : <label id="lblVesselName"></label>
            @*<label id="lblCountryTo1"></label>*@
        </div>
    </div>
    <div>
        DEAR SIRS. PLEASE BE SO KIND ENOUGH TO AMEND THE FOLLOWING D/O AND B/L TO READ AS DETAILS OUTLISTED HERE UNDER:
    </div>
    @*<div>
            ด้วยทางบริษัทฯ ได้รับมอบอำนาจให้ส่งสินค้าผ่านแดนจากต่างประเทศไปประเทศ <label id="countrytxt"></label> นำเข้าโดยเรือ <label id="lblVessel"></label>  เที่ยววันที่ <label id="lblETD" style="color:red"></label> ทางบริษัทฯ มีความประสงค์ให้ทาง  <label id="lblAgent2" style="color:red"></label>  แก้ไขและแยกบัญชีเรือเป็นสินค้าผ่านแดนไปประเทศ <label id="lblCountryTo2"></label> ดังต่อไปนี้
        </div>*@
    <table style="width:100%">
        <thead>
            <tr>
                <th style="text-align:left;width:30%">MARKS</th>
                <th style="text-align:left">DESCRIPTION</th>
                <th style="text-align:left">NO. OF P'KGS</th>
                @*<th style="text-align:left;width:40%">CONSIGNEE</th>*@
                <th>G.W.</th>
            </tr>
        </thead>
        <tbody id="tbdetail" style="vertical-align: top;">
            <tr>
                <td id="">
                    <pre id="lblMarks" style="margin:0px"></pre> <label id="lblTotalCTN"></label>
                </td>
                <td id="lblDescription"></td>
                <td id="lblPkg1"></td>

                <!--<td>
                <label id="lblConsignee"></label>
                <br />
                <label id="lblAddress1"></label>
                <label id="lblAddress2"></label>
                <br /> <br />-->
                @*<label id="">C/O &nbsp;@ViewBag.PROFILE_COMPANY_NAME_EN</label>*@
                <!--</td>-->
                <td>
                    <div id="lblGW" style="text-align:right"></div>
                    <div id="lblM3" style="text-align:right"></div>
                </td>
            </tr>
        </tbody>
    </table>
    <br /><br /><br />
    <h1 style="text-align:center">"กรุณาแจ้งเปิดตู้ด่วนด้วยค่ะ"</h1>
    <p>"FREIGHT PREPAID"  <label id="lblTransportTerm"></label></p>
    <p>CONSIGNEE:  <label id="lblConsignee"></label></p>
    <p>We hereby undertake to hold you free from all claims and consequences which may arise from your action as per our request</p>
    <p>Please Contact the under signed in order to pick- up D/O andpayment for all changes involved.</p>
    <p>Thank you very much for your usaul kind cooperation</p>
    <p>Your faithfully,</p>
    <!--<div style="text-align:center"> IN TRANSIT CARGO TO <label id="lblProjectName"></label></div>-->
    @*<div style="display:flex">
            <div style="width:20%"></div>
            <div style="width:10%">NOTIFY: </div>
            <div style="width:50%">
                <div id="lblNotify">
                    D.Y.Y. LOGISTICS CO,LTD.
                </div>
                <div id="lblNotifyAddress1">71/1-2 MODERN SWEET HOME 2,RAMA 9 ROAD,HUAY KWANG,</div>
                <div id="lblNotifyAddress2">BANGKOK,THAILAND 103010</div>

            </div>
            <div style="width:20%"></div>
        </div>

        <p style="text-align:center;color:red">"CONTAINER STATUS IS CY. THE CARGO  MOVEMENT IS TRANSIT(7)"<label id="lblTRemark"></label>  </p>
        <div style="display:flex">
            <div style="width:20%"></div>
            <div style="width:20%">TOTAL PACKAGE</div>
            <div style="width:30%" id="lblPkg2"></div>
        </div>
        <div style="display:flex">
            <div style="width:20%"></div>
            <div style="width:20%">B/L NO.</div>
            <div style="width:30%" id="lblBLNo"></div>
        </div>
        <div style="display:flex">
            <div style="width:20%"></div>
            <div style="width:20%">GROSS WEIGHT</div>
            <div style="width:30%" id="lblGW"></div>
        </div>
        <div style="display:flex">
            <div style="width:20%"></div>
            <div style="width:20%">MEASUREMENT</div>
            <div style="width:30%" id="lblM3"></div>
        </div>
        <div style="display:flex">
            <div style="width:20%"></div>
            <div style="width:20%">CONTAINER NO.</div>
            <div style="width:40%" id="lblCtns"></div>
        </div>*@
    @*<div>ฉะนั้นทางบริษัทฯ จึงเรียนมายังท่านได้กรุณาช่วยจัดการแก้ไขแยกบัญชีเรือเป็นสินค้าผ่านแดน ดังกล่าวข้างต้นด้วยจักเป็นพระคุณอย่างยิ่ง</div>
        <br />*@
    <div style="display:flex">
        <div style="width :60%;text-align:center">
            <br />
            <br />
            <br />
            <br />
            <div>  (<label>_______________________</label>)</div>
            <div>  <label id="lblEmp"></label></div>
            <div>Import Department</div>
        </div>
        <div style="width :40%;text-align:center">

        </div>
    </div>
    <div> </div>
</div>
<style>
    * {
        font-family: Cordia UPC;
        font-size:13px;
    }
</style>
<script async type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("JNo");
    let book = getQueryString("BookingNo");
    var path = '@Url.Content("~")';
    $('#dvCompLogo').hide();
    //$("#imgLogo").hide();
    // $("#imgLogoAdd").show();
    loadData();
    async function loadData() {
        let rb = await $.get(path + '/joborder/getbooking?branch=' + br + '&code=' + book);
        if (rb.booking !== null) {
            let b = rb.booking.data[0];
            $('#lblTransportTerm').text(b.TransMode);
                    $('#lblMarks').text(b.Remark);
                    $('#lblBookingNo').text(b.BookingNo);
            $.get(path + '/joborder/getjobsql?branch=' + br + '&jno=' + b.JNo).done(function (r) {
                if (r.job !== null) {
                    let j = r.job.data[0];
                    //$.get(path + 'Master/GetCompany?Code=' + j.CustCode + '&Branch=' + j.CustBranch).done(function (r) {
                    //    if (r.company !== null) {
                    //        let c = r.company.data[0];
                    //        $('#lblCustName1').text(c.NameEng);
                    //        $('#lblCustName2').text(c.NameEng);
                    //    }
                    //});
                    $.get(path + '/Master/GetCountry?code=' + j.InvCountry).done(function (r) {
                        if (r.country !== null) {
                            let c = r.country.data[0];
                            $('#lblCountryTo1').text(c.CTYName);
                            $('#lblCountryTo2').text(c.CTYName);
                        }
                    });
                    $.get(path + '/Master/GetVender?code=' + j.ForwarderCode).done(function (r) {
                        if (r.vender !== null) {
                            let v = r.vender.data[0];
                            $('#lblAgent1').text(v.English);
                            $('#lblAgent2').text(v.English);
                            $('#lblAgentAddress_2').text(v.EAddress2);
                        }
                    });
                    $.get(path + 'Master/GetCompany?Code=' + j.Consigneecode + '&Branch=' + j.CustBranch).done(function (r) {
                        if (r.company !== null) {
                            let c = r.company.data[0];
                            $('#lblConsignee').text(c.NameEng);
                            $('#lblAddress1').text(c.EAddress1);
                            $('#lblAddress2').text(c.EAddress2);
                        }
                    });
                    $.get(path + 'Master/GetCompany?Code=' + j.CustCode + '&Branch=' + j.CustBranch).done(function (r) {
                        if (r.company !== null) {
                            let c = r.company.data[0];
                            let newhead =
                                `<div id="divCompany" >
                                            <div style = "height:25px;text-align:left;color:darkblue;font-size:12px;" >
                                                <b style="font-size:18px"> ${c.NameEng}</b>
                                            </div >
                                            <div style="font-size:14px;" id="dvCompAddr">${c.EAddress1 + " " + c.EAddress2}
                                                <br>
                                                    TEL  ${c.Phone ? c.Phone : " - "}    FAX ${c.FaxNumber ? c.FaxNumber : ' - '}
                                                    <br>เลขประจำตัวผู้เสียภาษี ${c.FaxNumber ? c.FaxNumber : " - "} สาขา: ${c.Branch == "0000" ? "สำนักงานใหญ่" : c.Branch}
                        	                </div>
                             </div >`;

                            newhead += ``
                            $('#dvCompLogo').html(newhead);
                            $('#dvCompLogo').show();
                        }

                    });
                    $.get(path + 'joborder/gettransportdetail?Code=' + j.BookingNo + '&Branch=' + br + '&Job=' + j.JNo).done(function (r) {
                        if (r.transport !== null) {
                            let ctns = "";
                            r.transport.detail.forEach((item, index) => { ctns += (index == 0 ? "" : ", ") + item.CTN_NO });
                            $('#lblCtns').text(ctns);
                        }
                    });
                    $('#lblVesselName').text(j.VesselName);
                    $('#lblDescription').text(j.InvProduct);
                    $('#lblPkg1').text(j.InvProductQty + " " + j.InvProductUnit);
                    $('#lblPkg2').text(j.InvProductQty + " " + j.InvProductUnit);
                    $('#lblM3').text(j.Measurement + " CBM");
                    $('#lblGW').text(j.TotalGW + " " + j.GWUnit);
                    $('#lblBLNo').text(j.HAWB);
                    $('#lblTotalCTN').text(j.TotalContainer);

                    $('#lblTRemark').text(j.TRemark);
                    $('#lblDischargePort').text(j.ClearPortNo);
                    $('#lblETD').text(ShowDate(j.JobType > 1 ? j.ETDDate : j.ETADate));
                    $('#lblConfirmDate').text(ShowDate(j.ConfirmDate));
                    $('#lblDischargePort').text(j.ClearPortNo);
                    $('#lblProjectName').text(j.ProjectName);
                    $('#lblCountryTo').text(j.ClearPortNo);
                    $('#lblEmp').text(j.CSCode);
                    $('#lblCSCode').text(j.CSCode);
                  
                    
                }
            });
        }

      

    }

   
</script>
