﻿@Code
    Layout = "~/Views/Shared/_Report.vbhtml"
    ViewBag.Title = "Fuel Refill Form"
    ViewBag.ReportName = ""
End Code
<style>
    tr td {
        border-color: white;
    }

    .center {
        text-align: center;
    }

    .right {
        text-align: right;
    }

    .box {
        width: 100%;
        border: 2px solid black;
        height: 150px;
    }

    .dottedUnderline {
        border-bottom: 2px dotted black;
    }

    .underline {
        border-bottom: 2px solid black;
    }
</style>
<p>
    <table>
        <thead>
            <tr>
                <th class="center" colspan="10">
                    <label for="" style="border:2px solid black;padding: 10px;border-radius: 10px;position: relative;top: 0em;">
                        ใบสั่งงาน
                    </label>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><label id="orderNoLbl">เลขที่ Order</label></td>
                <td>:</td>
                <td colspan="8"><label id="orderNo" style=" font-weight: bold;"></label></td>
            </tr>
            <tr>
                <td><label>เลขที่ใบสั่งงาน</label></td>
                <td>:</td>
                <td><label id="docNo"></label></td>
                <td><label>Ref No.</label></td>
                <td>:</td>
                <td><label id="refNo"></label></td>
                <td><label>วันที่สั่งงาน</label></td>
                <td>:</td>
                <td><label id="docDate"></label></td>
                <td></td>
            </tr>
            <tr>
                <td><label>ชื่อโรงงาน</label></td>
                <td>:</td>
                <td><label id="factory"></label></td>
                <td></td>
                <td></td>
                <td></td>
                <td><label style=" font-weight: bold;">ชื่อสินค้า</label></td>
                <td>:</td>
                <td><label id="product" style=" font-weight: bold;"></label></td>
                <td></td>
            </tr>
            <tr>
                <td><label>เอเยนต์เรือ</label></td>
                <td>:</td>
                <td><label id="agent"></label></td>
                <td></td>
                <td></td>
                <td></td>
                <td><label>ชื่อเรือ</label></td>
                <td>:</td>
                <td><label id="vessel"></label></td>
                <td></td>
            </tr>
            <tr>
                <td><label>ท่าปลายทาง</label></td>
                <td>:</td>
                <td><label id="destPort"></label></td>
                <td></td>
                <td></td>
                <td></td>
                <td><label>Last Load</label></td>
                <td>:</td>
                <td><label id="lastLoad"></label></td>
                <td></td>
            </tr>
            <tr>
                <td><label>เบอร์ตู้</label></td>
                <td>:</td>
                <td><div id="containerNo"></div></td>
                <td><label>เบอร์ซีล</label></td>
                <td>:</td>
                <td><div id="sealNo"></div></td>
                <td><label style=" font-weight: bold;">เบอร์บุ๊คกิ้ง</label></td>
                <td>:</td>
                <td><label id="bookingNo" style=" font-weight: bold;"></label></td>
                <td></td>
            </tr>
            <tr>
                <td><label>สถานที่รับตู้</label></td>
                <td>:</td>
                <td><label id="getContainerPlace" style=" font-weight: bold;"></label></td>
                <td></td>
                <td></td>
                <td></td>
                <td><label>วันที่รับตู้</label></td>
                <td>:</td>
                <td><label id="getContainerDate"></label></td>
                <td><label id="getContainerTime"></label></td>
            </tr>
            <tr>
                <td><label>สถานที่ส่งของ</label></td>
                <td>:</td>
                <td><label id="loadPlace" style=" font-weight: bold;"></label></td>
                <td></td>
                <td></td>
                <td></td>
                <td><label>วันที่ส่งของ</label></td>
                <td>:</td>
                <td><label id="loadDate"></label></td>
                <td><label id="loadTime"></label></td>
            </tr>
            <tr>
                <td><label>สถานที่คืนตู้</label></td>
                <td>:</td>
                <td><label id="returnContainerPlace" style=" font-weight: bold;"></label></td>
                <td></td>
                <td></td>
                <td></td>
                <td><label>วันที่คืนตู้</label></td>
                <td>:</td>
                <td><label id="returnContainerDate"></label></td>
                <td><label id="returnContainerTime"></label></td>
            </tr>
            <tr>
                <td><label>หมายเหตุ</label></td>
                <td>:</td>
                <td colspan="4"><label id="remark"></label></td>
                <td><label>Customer PO</label></td>
                <td>:</td>
                <td><label id="custPo1"></label></td>
            </tr>
            <tr>
                <td><label>ชื่อ พขร</label></td>
                <td>:</td>
                <td><label id="driverName"></label></td>
                <td><label>เบอร์รถ</label></td>
                <td>:</td>
                <td><label id="carID"></label></td>
                <td><label>ทะเบียนรถ</label></td>
                <td>:</td>
                <td><label id="carNo"></label></td>
                <td><label id="carRefNo"></label></td>
            </tr>
            <tr>
                <td colspan="4">
                    <div class="center">
                        <br />
                        <p>.......................................................................................................................</p>
                        <div>ลงชื่อ พนักงานขับรถ</div>
                    </div>
                    <div>
                        <br />
                        <p>ลงชื่อ .................................................................................................................</p>
                        <p>เวลารถเข้าถึงโรงงาน .....................................................................................</p>
                        <div class="center">ผู้ว่าจ้างหรือตัวแทนเจ้าของสินค้า</div>
                    </div>
                </td>
                <td></td>
                <td></td>
                <td colspan="4">
                    <div class="center">
                        <br />
                        <p>.......................................................................................................................</p>
                        <div>ลงชื่อ ผู้สั่งงาน</div>
                    </div>
                    <div>
                        <br />
                        <p>ลงชื่อ ..................................................................................................................</p>
                        <p>เวลารถออกจากโรงงาน ...................................................................................</p>
                        <div class="center">ผู้ว่าจ้างหรือตัวแทนเจ้าของสินค้า</div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <br />
    <table>
        <thead>
            <tr>
                <td class="center" colspan="5">
                    <label for="" style="border:2px solid black;padding: 10px;border-radius: 10px;position: relative;top: 0em;">
                        ใบสั่งเติมน้ำมัน
                    </label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="underline" colspan="3"><label id="date"></label> <label id="time"></label></td>
                <td class="underline" style="font-weight:bold" colspan="2">เลขที่ใบสั่งเติม <label style="font-weight:bold" id="fueldocNo"></label></td>
            </tr>
        </thead>


        <tbody>
            <tr>
                <td style="width:20%">ชื่อปั๊มที่เติม</td>
                <td class="dottedUnderline" style="width:40%" colspan="2"><label id="fillingStation"></label></td>
                <td style="width:10%">วันที่</td>
                <td class="dottedUnderline" style="width:30%"><label id="fillDate"></label></td>
            </tr>
            <tr>
                <td style="font-weight:bold">ทะเบียนรถที่เติม</td>
                <td class="dottedUnderline" colspan="2"><label id="carLicenseNo" style="font-weight:bold"></label></td>
                <td style="font-weight:bold">ชื่อ พขร</td>
                <td class="dottedUnderline"><label style="font-weight:bold" id="driver"></label></td>
            </tr>
            <tr>
                <td>ชนิดเชื้อเพลิง</td>
                <td class="dottedUnderline" colspan="2"><label id="fuelType"></label></td>
                <td>เลขไมล์</td>
                <td class="dottedUnderline center"><label id="mile"></label></td>
            </tr>
            <tr>
                <td>ปริมาตร(ลิตร|กก.)</td>
                <td class="dottedUnderline right"><label id="volume"></label></td>
                <td class="dottedUnderline" style="display:flex">
                    (
                    <div style="flex: 1;text-align: center;">
                        <label id="volumeText"></label>
                    </div>
                    )
                </td>
                <td style="font-weight:bold">Job no. : </td>
                <td style="font-weight:bold" class="dottedUnderline"><label id="jobNo"></label></td>
            </tr>
            <tr>
                <td>จำนวนเงิน (บาท)</td>
                <td class="dottedUnderline right"><label id="baht"></label></td>
                <td class="dottedUnderline" style="display:flex">
                    (
                    <div style="flex: 1;text-align: center;"><label id="bahtText"></label></div>
                    )
                </td>
                <td>น้ำหนัก</td>
                <td class="dottedUnderline">
                    <label id="weight"></label>
                </td>
            </tr>
            <tr>
                <td>หมายเหตุ</td>
                <td class="dottedUnderline" colspan="2"><label id="fuelremark"></label></td>
                <td>Customer PO</td>
                <td class="dottedUnderline"><label id="custPo2"></label></td>

            </tr>
            <tr>
                <td colspan="5">ขอให้ทางปั๊มเดิมน้ำมันดังกล่าวข้างต้นด้วย</td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    ลงชื่อ .................................................................... พนักงานขับรถ
                </td>

                <td colspan="4">
                    <br />
                    ลงชื่อ ................................................................... ผู้สั่งเติม
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <br />
                    ลงชื่อ .....................................................................พนักงานปั๊มน้ำมัน
                </td>
            </tr>
        </tbody>
    </table>
    <div style="display:flex;width:100%;">
        <img src="~/Resource/fuel.jpg" style="width:100%;" />
    </div>
</p>

<script type="text/javascript">
    let branch = getQueryString("Branch");
    let code = getQueryString("Code");
    var path = '@Url.Content("~")';
    $.get(path + 'JobOrder/GetAddFuel?Branch=' + branch + '&Code=' + code).done(function (r) {
        if (r.addfuel.data.length > 0) {
            let d = r.addfuel.data[0];
            //$('#date').text(new Date().toString());
            //$('#time').text(ShowTime(new Date().toString()));
            $('#fueldocNo').text(d.DocNo);
            $('#fillingStation').text(d.StationCode);
            $('#fillDate').text(ShowDate(d.DocDate));
            $('#carLicenseNo').text(d.CarLicense + (d.TrailerNo == null ? '' : ' / ' + d.TrailerNo));

            $('#driver').text(d.Driver);
            $('#fuelType').text(d.FuelType);
            $('#mile').text(d.MileBegin);
            $('#volume').text(d.ActualVolume);
            $('#volumeText').text(CNumThai(d.ActualVolume).replace("บาทถ้วน",""));
            $('#jobNo').text(d.JNo);
            $('#baht').text(d.TotalAmount);
            $('#bahtText').text(CNumThai(d.TotalAmount));
            $('#fuelremark').text(d.Remark);
            $('#weight').text(d.TotalWeight);
            $('#carID').text(d.CarNo);
            $('#carNo').text(d.CarLicense);
            $('#carRefNo').text(d.TrailerNo);

            LoadJob(d.BranchCode, d.BookingNo,d.BookingItemNo);
        }
    });
    function LoadJob(branch, book, item) {
        $.get(path + 'JobOrder/GetTransportReport?Branch=' + branch + '&Code=' + book).done(function (r) {
            if (r.transport.data.length > 0) {
                let d = r.transport.data.filter(function (data) {
                    return data.ItemNo == item;
                });
                //let j = r.transport.data[0];
                let j = d[0];
                $('#orderNo').text(j.JNo);
                $('#docNo').text(j.DeliveryNo);
                $('#refNo').text(j.CustRefNO);
                $('#docDate').text(j.DocDate.replaceAll("T"," "));
                $('#factory').text(j.DeliveryPlace);
                $('#product').text(j.InvProduct);
                $('#agent').text(j.ForwarderCode);
                $('#vessel').text(j.MVesselName);
                $('#destPort').text(j.InvInterPort);
                $('#lastLoad').text(j.ClearPortNo);
                let cont = '';
                let seal = '';
                for (let c of d) {
                    if (cont !== '') cont += '<br/>';
                    cont += c.CTN_SIZE + ' ' + c.CTN_NO;
                    if (seal !== '') seal += '<br/>';
                    seal += c.SealNumber;
                }
                $('#containerNo').html(cont);
                $('#sealNo').html(seal);
                $('#bookingNo').text(j.BookingNo);

                $('#getContainerPlace').text(j.CYPlace);
                $('#getContainerDate').text(ShowDate(j.CYDate));
                $('#getContainerTime').text(ShowTime(j.CYTime));
                $('#loadPlace').text(j.PlaceName2);
                $('#loadDate').text(ShowDate(j.UnloadFinishDate));
                $('#loadTime').text(ShowTime(j.UnloadFinishTime));
                $('#returnContainerPlace').text(j.PlaceName3);
                $('#returnContainerDate').text(ShowDate(j.ReturnDate));
                $('#returnContainerTime').text(ShowTime(j.ReturnTime));
                //$('#route').text(j.LocationRoute);
                $('#remark').text(j.Remark);
                $('#custPo1').text(j.CustRefNO);
                $('#custPo2').text(j.CustRefNO);
                ShowEmpName(j.Driver);
            }
        });

    }
    function ShowEmpName(emp) {
        $('#driverName').val(emp);
        $.get(path + 'Master/GetEmployee?Code=' + emp).done(function (r) {
            if (r.employee.data.length > 0) {
                $('#driverName').text(r.employee.data[0].Name);
            }
        });
    }

</script>