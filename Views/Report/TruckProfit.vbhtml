@Code
    Layout = "~/Views/Shared/_ReportLandscape.vbhtml"
    ViewData("Title") = "Profit & Costing By Truck"
    Dim SumProfit = 0
    Dim SumSumAdv = 0
    Dim SumSumTrip = 0
    Dim SumTotalFuelAmount = 0
    Dim SumSumCost = 0
    Dim SumSumCharge = 0
End Code
<style>
    * {
        font-size: 10px
    }

    .right {
        text-align: right;
    }

    tr td {
        border-style: none;
        border-color: white
    }

    .table thead > tr > th, .table tbody > tr > th, .table tfoot > tr > th, .table thead > tr > td, .table tbody > tr > td, .table tfoot > tr > td {
        border-style: none;
        padding: 0px 5px;
    }
</style>
<div>
    <table class="table">
        <tbody>
            @For Each dr As System.Data.DataRow In ViewBag.DataTable.Rows
                @<tr>
                    <td width="5%"> Customer</td>
                    <td width="10%">@dr("CustomerName").ToString()</td>
                    <td width="8%"></td>
                    <td width="8%"> Shipper</td>
                    <td width="10%">@dr("ShipperName").ToString()</td>
                    <td width="8%"> วันที่ส่งตู้บรรจุ</td>
                    @If IsDate(dr("LoadDate")) Then
                        @<td width="5%">@String.Format(dr("LoadDate"), "dd/MM/yyyy")</td>
                    Else
                        @<td width="5%"></td>
                    End If
                    <td width="8%"> Job#</td>
                    <td width="5%">@dr("JNo").ToString()</td>
                    <td width="8%"> Order#</td>
                    <td width="5%">@dr("HAWB").ToString()</td>
                    <td width="20%" rowspan="5">
                        <Table Class="table">
                            <tbody>
                                @Code
                                    Try
                                        SumProfit += dr("Profit")
                                        SumSumAdv += dr("SumAdv")
                                        SumSumTrip += dr("SumTrip")
                                        SumTotalFuelAmount += dr("TotalFuelAmount")
                                        SumSumCost += dr("SumCost")
                                        SumSumCharge += dr("SumCharge")
                                    Catch ex As Exception

                                    End Try
                                End Code
                                <tr style="border-bottom: 1px solid black">
                                    <td>กำไร/ขาดทุน</td>
                                    <td Class="right">@Format(dr("Profit").ToString(), "Fixed")</td>
                                </tr>
                                <tr>
                                    <td> ค่าเที่ยวสิ้นเดือน</td>
                                    <td Class="right">@Format(dr("SumTrip").ToString(), "Fixed")</td>
                                </tr>
                                <tr>
                                    <td> ค่าน้ำมัน/แก๊ส</td>
                                    <td Class="right">@Format(dr("TotalFuelAmount").ToString(), "Fixed")</td>
                                </tr>
                                <tr>
                                    <td> Total Cost</td>
                                    <td Class="right">@Format(dr("SumCost").ToString(), "Fixed")</td>
                                </tr>
                                <tr>
                                    <td> Total sale</td>
                                    <td Class="right">@Format(dr("SumCharge").ToString(), "Fixed")</td>
                                </tr>
                                <tr>
                                    <td> Total Adv</td>
                                    <td Class="right">@Format(dr("SumAdv").ToString(), "Fixed")</td>
                                </tr>
                            </tbody>
                        </Table>
                    </td>
                </tr>
                @<tr>
                    <td> พขร</td>
                    <td>@dr("Driver").ToString()</td>
                    <td>@dr("TruckNo").ToString()</td>
                    <td> สถานที่รับตู้</td>
                    <td> @dr("PickupPlace").ToString()</td>
                    <td> สถานที่บรรจุ</td>
                    <td colspan="3"> @dr("PackingPlace").ToString()</td>

                    <td> สถานที่คืนตู้</td>
                    <td> @dr("ReturnPlace").ToString()</td>
                    <td></td>
                </tr>
                @<tr>
                    <td> เบอร์ตู้</td>
                    <td colspan="2"> @dr("CTN_SIZE").ToString(), @dr("CTN_NO").ToString()</td>
                    <td> Booking no.</td>
                    <td> @dr("BookingNo").ToString()</td>
                    <td> Cust Inv.</td>
                    <td colspan="3">@dr("InvNo").ToString()</td>
                    <td> น้ำมัน(ลิตร)</td>
                    <td> @dr("TotalFuelUsed").ToString()</td>
                </tr>
                @<tr>
                    <td> Cost</td>
                    <td colspan="10"> @dr("DetailCost").ToString()</td>
                </tr>
                @<tr>
                    <td> Sale</td>
                    <td colspan="10"> @dr("DetailCharge").ToString()</td>
                </tr>
                @<tr style="border-bottom:1px solid black;margin-bottom:10px">
                    <td> Advance</td>
                    <td colspan="10"> @dr("DetailAdv").ToString()</td>
                </tr>
                                    Next
            <tr>
                <td colspan="11"></td>
                <td>
                    <table class="table">
                        <tbody>
                            <tr style="border-bottom: 1px solid black">
                                <td>กำไร/ขาดทุน</td>
                                <td Class="right">@Format(SumProfit, "Fixed")</td>
                            </tr>
                            <tr>
                                <td>ค่าเที่ยวสิ้นเดือน</td>
                                <td class="right"> @Format(SumSumTrip, "Fixed")</td>
                            </tr>
                            <tr>
                                <td>ค่าน้ำมัน/แก๊ส</td>
                                <td class="right"> @Format(SumTotalFuelAmount, "Fixed") </td>
                            </tr>
                            <tr>
                                <td>Total Cost</td>
                                <td class="right">@Format(SumSumCost, "Fixed")</td>
                            </tr>
                            <tr>
                                <td>Total sale</td>
                                <td class="right">@Format(SumSumCharge, "Fixed")</td>
                            </tr>
                        </tbody>
                    </table>
                </td>



            </tr>
        </tbody>
    </table>
</div>