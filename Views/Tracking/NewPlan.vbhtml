@Code
    Layout = "~/Views/Shared/_ReportLandscape.vbhtml"
    ViewData("Title") = "Planing By Inspection Date"
End Code
<style>
    * {
        font-size: 11px
    }

    .right {
        text-align: right;
    }
</style>
<div>
    <table class="table">
        <tbody>
            @For Each dr As System.Data.DataRow In ViewBag.DataTable.Rows
                @<tr>
                     <td>
                         <Table Class="table">
                             <tbody>
                                 <tr>
                                     <td> Customer</td>
                                     <td>@dr("CustCode").ToString()</td>
                                     <td></td>
                                     <td> Shipper</td>
                                     <td>@dr("CustCode").ToString()</td>
                                     <td> วันที่ส่งตู้บรรจุ</td>
                                     @If IsDate(dr("LoadDate")) Then
                                         @<td>@String.Format(dr("LoadDate"), "dd/MM/yyyy")</td>
                                     Else
                                         @<td ></td>
                                     End If
                                     <td> Job#</td>
                                     <td>@dr("JNo").ToString()</td>
                                     <td> Order#</td>
                                     <td>19991</td>
                                     <td rowspan="5">
                                         <table class="table">
                                             <tbody>
                                                 <tr>
                                                     <td>กำไร/ขาดทุน</td>
                                                     <td class="right">28,047.90</td>
                                                 </tr>
                                                 <tr>
                                                     <td>ค่าเที่ยวสิ้นเดือน</td>
                                                     <td class="right">0.00</td>
                                                 </tr>
                                                 <tr>
                                                     <td>ค่าน้ำมัน/แก๊ส</td>
                                                     <td class="right">8,532.10</td>
                                                 </tr>
                                                 <tr>
                                                     <td>Total Cost</td>
                                                     <td class="right">3,420.00</td>
                                                 </tr>
                                                 <tr>
                                                     <td>Total sale</td>
                                                     <td class="right">40,000.00</td>
                                                 </tr>
                                             </tbody>
                                         </table>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td> พขร</td>
                                     <td> แดนสยาม บุตรโท</td>
                                     <td>64-9407</td>
                                     <td> สถานที่รับตู้</td>
                                     <td> @dr("FactoryAddress").ToString()</td>
                                     <td> สถานที่บรรจุ</td>
                                     <td colspan="3"> @dr("PackingAddress").ToString()</td>

                                     <td> สถานที่คืนตู้</td>
                                     <td> @dr("ReturnAddress").ToString()</td>
                                     <td></td>
                                 </tr>
                                 <tr>
                                     <td> เบอร์ตู้</td>
                                     <td colspan="2"> 40 'HC,CULU5803151</td>
                                     <td> Booking no.</td>
                                     <td> @dr("BookingNo").ToString()</td>
                                     <td> Cust Inv.</td>
                                     <td colspan="3">@dr("InvNo").ToString()</td>
                                     <td> น้ำมัน(ลิตร)</td>
                                     <td>410.00</td>
                                 </tr>
                                 <tr>
                                     <td> Cost</td>
                                     <td colspan="10"> ค่าคื่นตู้เปล่า = 1270.0, ค่าผ่านทางเรือ = 100.0, ค่าล่วงเวลา = 50.0, ค่าเที่ยว = 2000.0</td>
                                 </tr>
                                 <tr>
                                     <td> Sale</td>
                                     <td colspan="10"> ค่าขนส่ง = 20500.00, ค่าคืนตู้ = 1270.00, ค่าผ่านท่า = 100.00, ค่าใช้จ่ายอื่น = 3000.00, ค่าภาระ = 1070.00, รายได้อื่น = 1960.00, ค่าธรรมเนียมในการผ่านแดน = 500.00</td>
                                 </tr>
                             </tbody>
                         </Table>
                     </td>
                </tr>
            Next
            
        </tbody>
        
    </table>
   
</div>



