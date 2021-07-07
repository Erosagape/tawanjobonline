@Code
    Layout = "~/Views/Shared/_ReportLandscape.vbhtml"
    ViewData("Title") = "Planing By Inspection Date"
End Code
<style>
    * {
        font-size:9px;
    }
</style>
<b>Plan Loading By Inspection Date</b>
<table border="1" style="border-collapse:collapse;width:100%;">
    <thead>
        <tr>
            <th rowspan="2">No.</th>
            <th rowspan="2">วันที่่รับเอกสาร</th>
            <th>ชื่อ shipper</th>
            <th>ชื่อ สินค้า</th>
            <th>Inv.No</th>
            <th>ชื่อเรือ/เที่ยวบิน</th>
            <th rowspan="2">ETA</th>
            <th>จำนวน</th>
            <th rowspan="2">Loading Port</th>
            <th rowspan="2">Discharge Port</th>
            <th colspan="4">สายเรือ</th>
            <th rowspan="2">Surrender</th>
            <th>ราคาประมาณการ</th>
        </tr>
        <tr>
            <th>ชื่อ Consignee</th>
            <th>จำนวนตู้</th>
            <th>เบอร์ตู้</th>
            <th>Voyage</th>
            <th>น้ำหนัก</th>
            <th>DO</th>
            <th>มัดจำ</th>
            <th>ล้างตู้</th>
            <th>DEM</th>
            <th>ตรวจปล่อย</th>
        </tr>
    </thead>
    <tbody>
        @For Each dr As System.Data.DataRow In ViewBag.DataTable.Rows
            @<tr>
                <td rowspan="2">@Convert.ToInt32(ViewBag.DataTable.Rows.IndexOf(dr) + 1)</td>
                @If IsDate(dr("ConfirmDate")) Then
                    @<td>@String.Format(dr("ConfirmDate"), "dd/MM/yyyy")</td>
                Else
                    @<td></td>
                End If
                <td>@dr("CustTName").ToString()</td>
                <td>@dr("InvProduct").ToString()</td>
                <td>@dr("VesselName").ToString()</td>
                <td>@dr("InvNo").ToString()</td>
                @If IsDate(dr("ETADate")) Then
                    @<td rowspan="2">@String.Format(dr("ETADate"), "dd/MM/yyyy")</td>
                Else
                    @<td rowspan="2"></td>
                End If
                <td>@dr("InvProductQty").ToString() @dr("InvProductUnit").ToString()</td>
                <td rowspan="2">@dr("PortName").ToString()</td>
                <td>@dr("ClearPort").ToString()</td>
                <td colspan="4">@dr("ForwarderName").ToString()</td>
                <td rowspan="2">@dr("BLNo").ToString()</td>
                <td>@dr("TotalEstimate")</td>
            </tr>
            @<tr>
                <td>@dr("JNo").ToString()</td>
                <td>@dr("ConsigneeTName").ToString()</td>
                <td>@dr("TotalContainer").ToString()</td>
                <td>@dr("ContainerList").ToString()</td>
                <td>@dr("MVesselName").ToString()</td>
                <td>@dr("TotalGW").ToString()</td>
                <td>@dr("ClearPortNo").ToString()</td>
                <td>@dr("TotalDO")</td>
                <td>@dr("TotalERN")</td>
                <td>@dr("TotalCLEAN")</td>
                <td>@dr("TotalDEM")</td>
                @If IsDate(dr("DutyDate")) Then
                    @<td>@String.Format(dr("DutyDate"), "dd/MM/yyyy")</td>
                Else
                    @<td></td>
                End If

            </tr>
            @<tr>
    <td colspan="3">ติดต่อลูกค้า : @dr("CustContactName").ToString()</td>
    <td colspan="7">สถานที่ส่ง : @dr("DeliveryTo").ToString() @dr("DeliveryAddr").ToString()</td>
    <td colspan="4">M-BL : @dr("MAWB").ToString()</td>
    <td colspan="2">ภาษี : @dr("DutyAmount").ToString()</td>
</tr>
            @<tr>
        <td colspan="16">หมายเหตุ : @dr("Description").ToString()</td>
            </tr>

        Next
    </tbody>
</table>
<script type="text/javascript">
    var path = '@Url.Content("~")';

</script>

