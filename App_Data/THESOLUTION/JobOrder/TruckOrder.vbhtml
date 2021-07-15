@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Transport Order"
End Code
<p>
    <div style="display:flex;flex-direction:row">
        <div style="flex:1">
            รายชื่องาน :
            <label id="txtProjectName"></label>
            <br />
            จำนวน :
            <label id="txtTotalContainer"></label>
            <br />
            ลูกค้า :
            <label id="txtCustName"></label>
            <br />
            BL NO :
            <label id="txtHAWB"></label>
            <br />
            JOB NO :
            <label id="txtJNo"></label>
            <br />
            รับตู้หนักวันที่ :
            <label id="txtCYDate"></label>
            <br />
            ข้ามด่าน/ส่งลูกค้าวันที่ :
            <label id="txtDutyDate"></label>
            <br />
            ท่ารับตู้หนัก :
            <label id="txtCYPlace"></label>
            <br />
            สถานที่คืนตู้เปล่า :
            <label id="txtReturnPlace"></label>
            <br />
            จบงานวันที่ :
            <label id="txtCloseJobDate"></label>
            <br />
            <table style="width:80%">
                <thead>
                    <tr>
                        <td>ใบเบิก</td>
                        <td>จำนวนเงิน</td>
                    </tr>
                </thead>
                <tbody id="tbAdvance"></tbody>
            </table>
        </div>
        <div style="flex:2">
            <table border="1" style="border-collapse:collapse;width:100%">
                <tr>
                    <td colspan="2">วันที่วางบิล :</td>
                </tr>
                <tr>
                    <td colspan="2">เลขที่บิล :</td>
                </tr>
                <tr>
                    <td>ค่าขนส่ง</td>
                    <td>ค่า D/O</td>
                </tr>
                <tr>
                    <td>ค่าผ่านท่า</td>
                    <td>ค่า Rent</td>
                </tr>
                <tr>
                    <td>ค่ารับตู้</td>
                    <td>ค่าพิธีการ</td>
                </tr>
                <tr>
                    <td>ค่าคืนตู้</td>
                    <td>ค่าธรรมเนียม</td>
                </tr>
                <tr>
                    <td>ค่าล้างตู้</td>
                    <td>ค่าชอร์</td>
                </tr>
                <tr>
                    <td>ค่าซ่อมตู้</td>
                    <td>ค่าค้างคืนรถ</td>
                </tr>
                <tr>
                    <td>ค่าชั่งน้ำหนัก</td>
                    <td>รายได้อื่น</td>
                </tr>
                <tr>
                    <td>ค่าจอดรถ</td>
                    <td>ลดหนี้</td>
                </tr>
                <tr>
                    <td>ค่าล่วงเวลา</td>
                    <td>ค่าใช้จ่ายอื่นๆ</td>
                </tr>
                <tr>
                    <td>ค่า BL</td>
                    <td>อื่นๆ</td>
                </tr>
            </table>
        </div>
    </div>
    <table border="1" style="border-collapse:collapse;width:100%;">
        <tbody id="tbTruck"></tbody>
    </table>
</p>
<script type="text/javascript">
    let br = getQueryString("BranchCode");
    let doc = getQueryString("BookingNo");
    let user = '@ViewBag.User';
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetBooking?Branch=' + br + '&Code=' + doc).done(function (r) {
        if (r.booking !== null) {
            let h = r.booking.data[0];
            $('#txtProjectName').text(h.ProjectName);
            $('#txtTotalContainer').text(h.TotalContainer);
            $('#txtCustName').text(h.ShipperName + ' ' + h.CustContactName);
            $('#txtHAWB').text(h.HAWB);
            $('#txtJNo').text(h.JNo);
            $('#txtCYDate').text(CDateEN(h.CYDate));
            $('#txtDutyDate').text(CDateEN(h.DeliveryDate));
            $('#txtCYPlace').text(h.CYPlace);
            $('#txtReturnPlace').text(h.ReturnPlace);
            $('#txtCloseJobDate').text(CDateEN(h.ActualReturnDate));

            LoadAdvance(h.BranchCode, h.JNo);
            LoadTruck(h.BranchCode, h.JNo);
        }
    });
    function LoadTruck(branch, job) {
        $.get(path + 'JobOrder/GetFuelData?Branch=' + branch + '&Job=' + job).done(function (r) {
            let rows = r.data;
            if (rows.length > 0) {
                let html = '';
                let c = 0;
                let i = 0;
                for (let d of rows) {
                    if (html == '')
                        html = '<tr>';
                    i += 1;
                    if (i == 4) {
                        i = 1;
                        if (html !== '')
                            html += '</tr>';
                        html += '<tr>';
                    }
                    html += '<td>';
                    html += 'No.' + (c + 1) + '<br/>';
                    html += 'ชื่อ พขร:' + d.Driver + '<br/>';
                    html += 'เบอร์โทรไทย:' + d.Tel + '<br/>';
                    html += 'เบอร์โทรลาว:' + d.EmpRemark + '<br/>';
                    html += 'ทะเบียนหัว:' + d.CarLicense + '<br/>';
                    html += 'ทะเบียนหาง:' + d.TrailerNo + '<br/>';
                    html += 'ยี่ห้อรถ:' + d.CarBrand + '/' + d.CarType;
                    html += 'จังหวัด:' + d.CarModel;
                    html += '</td>';
                    c += 1;
                }
                if (html !== '')
                    html += '</tr>';
                $('#tbTruck').html(html);
            }
        });
    }
    function LoadAdvance(branch, job) {
        $.get(path + 'adv/getadvancereport?branchcode=' + branch + '&jobno=' + job).done(function (r) {
            if (r.adv.data.length > 0) {
                let html = '';
                let lastAdv = '';
                let c = 0;
                let tot = 0;
                for (let d of r.adv.data[0].Table) {
                    c += 1;
                    html += '<tr>';
                    html += '<td>' + d.AdvNo + '</td>';
                    html += '<td>' + ShowNumber(d.TotalAdvance, 2) + '</td>';
                    html += '</tr>';

                }
                $('#tbAdvance').html(html);
            }
        });
    }
</script>
