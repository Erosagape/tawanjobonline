@Code
    ViewBag.Title = "Withholding-Tax Lists"
    Dim debug As Boolean = False
    If Not Request.QueryString("MODE") Is Nothing Then
        debug = Request.QueryString("MODE").Equals("DEBUG")
    End If
    Dim yy As String = DateTime.Now.Year.ToString("yyyy")
    If Not Request.Form("TaxYear") Is Nothing Then
        yy = Request.Form("TaxYear").ToString
    End If
    Dim mm As String = DateTime.Now.Month.ToString()
    If Not Request.Form("TaxMonth") Is Nothing Then
        mm = Request.Form("TaxMonth").ToString
    End If
    Dim tx As String = ""
    If Not Request.Form("TaxCode") Is Nothing Then
        tx = Request.Form("TaxCode").ToString
    End If
    Dim frm As String = "7"
    If Not Request.Form("FormType") Is Nothing Then
        frm = Request.Form("FormType").ToString
    End If
    Dim ty As String = ""
    If Not Request.Form("TaxType") Is Nothing Then
        ty = Request.Form("TaxType").ToString
    End If
    Dim ta As String = ""
    If Not Request.Form("TaxAgent") Is Nothing Then
        ta = Request.Form("TaxAgent").ToString
    End If
    Dim tu As String = ""
    If Not Request.Form("TaxUser") Is Nothing Then
        tu = Request.Form("TaxUser").ToString
    End If
    Dim tr As String = "0000"
    If Not Request.Form("TaxRegister") Is Nothing Then
        tr = Request.Form("TaxRegister").ToString
    End If
    Dim tln As String = "1"
    If Not Request.Form("TaxLawNo") Is Nothing Then
        tln = Request.Form("TaxLawNo").ToString
    End If
    Dim strHeader As String = ""
    Dim strDetail As String = ""
    Dim strAll As String = ""
    Dim sqlH As String = ""
    Dim sqlD As String = ""
    If ViewBag.User = "" Or Request.Form("Submit") = "" Then
    Else

        If sqlH = "" Then
            sqlH = "
select h.TaxNumber1,Convert(numeric,'0'+h.Branch1) as Branch1,h.TaxNumber2,Convert(numeric,'0'+h.Branch2) as Branch2,
count(d.DocNo) as TotalDoc,
CAST(SUM(d.PayAmount) AS DECIMAL(18, 2)) AS TotalPayAmount,
CAST(SUM(d.PayTax) AS DECIMAL(18, 2)) AS TotalPayTax,
h.TaxLawNo,h.SeqInForm
from Job_WHTax h left join Job_WHTaxDetail d
on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
where not isnull(h.CancelProve,'')<>'' AND h.FormType=" & frm & " AND Year(h.DocDate)={0} AND Month(h.DocDate)={1} AND h.TaxNumber1='{2}' " & IIf(ty = "2", String.Format(" AND h.TaxNumber2='{0}' ", ta), "") & "
and h.TaxLawNo=" & tln & "
group by h.TaxNumber1,Convert(numeric,'0'+h.Branch1),h.TaxNumber2,Convert(numeric,'0'+h.Branch2),h.TaxLawNo,h.SeqInForm
"
        End If

        If sqlD = "" Then
            sqlD = "
select h.DocNo,h.TaxNumber3,Convert(numeric, '0' + h.Branch3) AS Branch3,MAX(h.TName3) AS TName3,
CAST(d.PayRate AS DECIMAL(18, 2)) AS PayRate,d.PayDate,d.PayTaxDesc,h.PayTaxType,
CAST(SUM(d.PayAmount) AS DECIMAL(18, 2)) AS PayAmount,
CAST(SUM(d.PayTax) AS DECIMAL(18, 2)) AS PayTax
,MAX(dbo.ProcessAddressSingle(h.TAddress3)) as Address3
FROM Job_WHTax h
LEFT JOIN Job_WHTaxDetail d ON h.BranchCode = d.BranchCode AND h.DocNo = d.DocNo
WHERE NOT isnull(h.CancelProve, '') <> '' AND h.FormType = " & frm & " AND h.TaxLawNo = " & tln & " AND Year(h.DocDate) = {0}
AND Month(h.DocDate) = {1}
AND h.TaxNumber1 = '{2}'
" & IIf(ty = "2", " AND h.TaxNumber2='" & ta & "' ", "") & "
GROUP BY h.TaxNumber3,Convert(numeric, '0' + h.Branch3),h.DocNo,CAST(d.PayRate AS DECIMAL(18, 2)),
d.PayDate,d.PayTaxDesc,h.PayTaxType,h.TAddress3"

        End If

        Dim th = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlH, yy, mm, tx))
        For Each rh As System.Data.DataRow In th.Rows
            strHeader = "H" & "|"   '#1 HEADER
            strHeader &= tr & "|"   '#2 รหัสผู้นำส่ง
            If rh("TaxNumber2").ToString <> "" Then
                strHeader &= rh("TaxNumber2").ToString & "|"    '#3 เลขประจำตัวผู้เสียภาษีอากรผู้นำส่ง
                strHeader &= CInt("0" & rh("Branch2").ToString).ToString("000000") & "|"    '#4 สาขาที่ผู้นำส่ง
                strHeader &= "3" & "|"   '#5 ประเภทการนำส่ง (1=ผู้หักภาษี 2=ตัวแทน 3=ตัวกลาง 4=ยื่นรวม)
            Else
                strHeader &= rh("TaxNumber1").ToString & "|"    '#3 เลขประจำตัวผู้เสียภาษีอากรผู้นำส่ง
                strHeader &= CInt("0" & rh("Branch1").ToString).ToString("000000") & "|"    '#4 สาขาที่ผู้นำส่ง
                strHeader &= "1" & "|"   '#5 ประเภทการนำส่ง (1=ผู้หักภาษี 2=ตัวแทน 3=ตัวกลาง 4=ยื่นรวม)
            End If
            If frm = "7" Then
                strHeader &= "PND53" & "|"   '#6 ประเภทแบบภาษี PND
            End If
            If frm = "4" Then
                strHeader &= "PND3" & "|"   '#6 ประเภทแบบภาษี PND
            End If
            strHeader &= rh("TaxNumber1").ToString & "|"    '#7 เลขประจำตัวผู้เสียภาษีอากรผู้มีหน้าที่หักภาษี
            strHeader &= CInt("0" & rh("Branch1").ToString).ToString("000000") & "|"    '#8 สาขาที่ผู้มีหน้าที่หักภาษี
            strHeader &= "สำนักงานใหญ่" & "|"    '#9 ชื่อแผนก/ส่วน/ฝ่าย (สํานักงานใหญ่ กรณีไม่ แยกนําส่งเป็นแผนก)
            If CInt("0" & rh("TaxLawNo").ToString) = 1 Then
                strHeader &= "1" & "|"    '#10 มาตรา 3 เตรส
            Else
                strHeader &= "0" & "|"    '#10 มาตรา 3 เตรส
            End If
            If CInt("0" & rh("TaxLawNo").ToString) = 2 Then
                strHeader &= "1" & "|"    '#11 มาตรา 48 ทวิ
            Else
                strHeader &= "0" & "|"    '#11 มาตรา 48 ทวิ
            End If
            If CInt("0" & rh("TaxLawNo").ToString) = 3 Then
                strHeader &= "1" & "|"    '#12 มาตรา 50(3)(4)(5)
            Else
                strHeader &= "0" & "|"    '#12 มาตรา 50(3)(4)(5)
            End If
            strHeader &= "0" & "|"    '#13 สถานะผู้ประกอบการรายใหญ่
            strHeader &= CInt("0" & mm).ToString("00") & "|"    '#14 เดือนภาษี
            strHeader &= CInt("0" & yy).ToString("0000") + 543 & "|"    '#15 ปีภาษี
            strHeader &= "V" & "|"    '#16 ประเภทสาขา (V=สาขาภาษีมูลค่าเพิ่ม( S=สาขาภาษีธุรกิจเฉพาะ กรณีเป็นทั้งสอง ระบุ “V” กรณียื่นสื่อฯ ถ้าไม่มีค่าให้ระบุเป็น Null หรือ Pipe “|” ติดกัน)
            strHeader &= CInt("0" & rh("SeqInForm").ToString).ToString("00") & "|"    '#17 ประเภทการยื่นแบบ
            strHeader &= rh("TotalDoc") & "|"    '#18 รวมจำนวนราย
            strHeader &= rh("TotalPayAmount") & "|"    '#19 รวมจำนวนเงินได้ทั้งสิ้น
            strHeader &= rh("TotalPayTax") & "|"    '#20 รวมจำนวนเงินภาษีนำส่งทั้งสิ้น
            strHeader &= "0.00" & "|"    '#21 จำนวนเงินเพิ่ม
            strHeader &= rh("TotalPayTax") & "|"    '#22 จำนวนเงินยอดรวมภาษีนำส่งทั้งสิ้นและเงินเพิ่ม
            strHeader &= "0.00" & "|"    '#23 จำนวนเงินโอนผ่านธนาคาร
            strHeader &= tu & "|"    '#24 รหัส user
            strHeader &= "1" & ""    '#25 ช่องทางการยื่นแบบ

            strDetail = ""
            Dim lastDoc = ""
            Dim lastAddr = ""
            Dim rc As Integer = 0
            Dim td = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlD, yy, mm, tx))
            For Each rd As System.Data.DataRow In td.Rows
                rc += 1
                Dim pDate = ""
                Try
                    Dim pDayMonth = String.Concat(CDate(rd("PayDate").ToString()).Day.ToString("00"), CDate(rd("PayDate").ToString()).Month.ToString("00"))
                    Dim pYear = CDate(rd("PayDate").ToString()).Year
                    pDate = String.Concat(pDayMonth, pYear + 543)
                Catch ex As Exception
                    pDate = rd("PayDate").ToString()
                End Try
                strDetail &= vbCrLf
                strDetail &= "D" & "|"  '#1 DETAIL ต้องระบุเป็น D (ตัวพิมพ์ใหญ่)
                strDetail &= rc & "|"  '#2 ลำดับที่
                strDetail &= CInt("0" & rd("Branch3").ToString).ToString("000000") & "|"    '#3 สาขาผู้หักภาษี
                If rd("TaxNumber3").ToString.Length = 13 Then
                    strDetail &= rd("TaxNumber3").ToString() & "|"    '#4 เลขประจำตัวประชาชนผู้มีเงินได้
                Else
                    strDetail &= "|"    '#4 เลขประจำตัวประชาชนผู้มีเงินได้
                End If
                If rd("TaxNumber3").ToString.Length < 13 Then
                    strDetail &= CInt("0" & rd("TaxNumber3").ToString).ToString("0000000000") & "|"    '#5 เลขประจำตัวผู้เสียภาษีอากรผู้มีเงินได้
                Else
                    strDetail &= "0000000000|"    '#5 เลขประจำตัวผู้เสียภาษีอากรผู้มีเงินได้
                End If
                If frm = "4" Then
                    strDetail &= "-|"    '#6 คำนำหน้าชื่อ
                End If
                If frm = "7" Then
                    strDetail &= "บริษัท|"    '#6 คำนำหน้าชื่อ
                End If
                strDetail &= rd("TName3").ToString().Replace("บริษัท", "").Trim() & "|"    '#7 ชื่อผู้มีเงินได้
                strDetail &= "|"    '#8 ชื่อสกุลผู้มีเงินได้
                strDetail &= pDate & "|"    '#9 วันเดือนปีที่จ่าย เงินได้รายการที่ 1
                strDetail &= rd("PayRate").ToString() & "|"    '#10 อัตราภาษี
                strDetail &= rd("PayAmount").ToString() & "|"    '#11 จำนวนเงินที่จ่าย
                strDetail &= rd("PayTax").ToString() & "|"    '#12 จำนวนเงินภาษี
                strDetail &= rd("PayTaxDesc").ToString() & "|"    '#13 ประเภทเงินได้
                strDetail &= rd("PayTaxType").ToString() & "|"    '#14 เงื่อนไขการหักภาษี (1=หัก ณ ที่จ่าย, 2=ออกให้ตลอดไป, 3=ออกให้ครั้งเดียว ถ้าไม่มีค่าให้ระบุเป็น Null หรือ Pipe “|” ติดกัน)
                strDetail &= "00000000|"    '#15 ข้อมูลเปล่าๆ รายการ 2
                strDetail &= "|"    '#16
                strDetail &= "|"    '#17
                strDetail &= "|"    '#18
                strDetail &= "|"    '#19
                strDetail &= "|"    '#20

                strDetail &= "00000000|"    '#21  ข้อมูลเปล่าๆ รายการ 3
                strDetail &= "|"    '#22
                strDetail &= "|"    '#23
                strDetail &= "|"    '#24
                strDetail &= "|"    '#25
                strDetail &= "|"    '#26

                strDetail &= rd("Address3").ToString()

                'strDetail &= "|"    '#27 ชื่ออาคาร
                'strDetail &= "|"    '#28 ห้องเลขที่
                'strDetail &= "|"    '#29 ชั้นที่
                'strDetail &= lastAddr & "|"    '#30 หมู่บ้าน
                'strDetail &= "|"    '#31  เลขที่
                'strDetail &= "|"    '#32 หมู่ที่
                'strDetail &= "|"    '#33 ตรอก/ซอย
                'strDetail &= "|"    '#34  ถนน
                'strDetail &= "|"    '#35 ตำบล/แขวง
                'strDetail &= "|"    '#36 อำเภอ/เขต
                'strDetail &= "|"    '#37  จังหวัด
                'strDetail &= "|"    '#38 รหัสไปรษณีย์
            Next
            Exit For
        Next
        strAll = strHeader & strDetail
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(strAll)
        Response.Clear()
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = "UTF-8"
        Response.Buffer = True
        Response.ContentType = "application/text"
        Dim fname = ""
        If frm = "7" Then
            fname &= "53"
        End If
        If frm = "4" Then
            fname &= "3"
        End If
        fname &= "_" & ViewBag.PROFILE_TAXNUMBER & "_" & CInt(ViewBag.PROFILE_TAXBRANCH).ToString("000000") & "_" & CInt(yy) + 543 & "_" & CInt(mm).ToString("00")
        Response.AddHeader("content-disposition", "attachment; filename=PND" & fname & "_00_00.txt")
        Response.Write(sb.ToString())
        Response.End()
    End If
End Code
<div class="row">
    <div class="col-sm-4">
        <label id="lblBranch">Branch</label>
        <br />
        <div style="display:flex;flex-direction:row">
            <input type="text" class="form-control" id="txtBranchCode" style="width:15%" disabled />
            <input type="button" class="btn btn-default" value="..." onclick="SearchData('branch');" />
            <input type="text" class="form-control" id="txtBranchName" style="width:65%" disabled />
        </div>
    </div>
    <div class="col-sm-4">
        <label id="lblDateFrom">Date From:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateF" />
    </div>
    <div class="col-sm-4">
        <label id="lblDateTo">Date To:</label>
        <br />
        <input type="date" class="form-control" id="txtDocDateT" />
    </div>
</div>
<div class="row">
    <div class="col-sm-2">
        <br />
        <a href="#" class="btn btn-default w3-purple" id="btnAdd" onclick="AddWHTax()">
            <i class="fa fa-lg fa-file-o"></i>&nbsp;<b id="linkCreate">Create New Slip</b>
        </a>
    </div>
    <div class="col-sm-8" style="text-align:right">
        <br />
        <input type="checkbox" id="chkCancel" />Show Cancel Only
    </div>
    <div class="col-sm-2">
        <br />
        <a href="#" class="btn btn-primary" id="btnSearch" onclick="SetGridAdv(true)">
            <i class="fa fa-lg fa-filter"></i>&nbsp;<b id="linkSearch">Search</b>
        </a>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
        <table id="tbHeader" class="table table-responsive">
            <thead>
                <tr>
                    <th>DocNo</th>
                    <th class="desktop">DocDate</th>
                    <th class="desktop">TName1</th>
                    <th class="desktop">TName2</th>
                    <th class="desktop">TName3</th>
                    <th class="all">JNo</th>
                    <th class="desktop">InvNo</th>
                    <th class="desktop">DocRefNo</th>
                    <th class="all">PayAmount</th>
                    <th class="all">PayTax</th>
                </tr>
            </thead>
        </table>
    </div>
</div>

<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    let arr = [];
    let list = [];
    let docno = '';
    //$(document).ready(function () {
    SetEvents();
    //});
    function SetEvents() {
        $('#txtBranchCode').val('@ViewBag.PROFILE_DEFAULT_BRANCH');
        $('#txtBranchName').val('@ViewBag.PROFILE_DEFAULT_BRANCH_NAME');
        $('#txtDocDateF').val(GetFirstDayOfMonth());
        $('#txtDocDateT').val(GetLastDayOfMonth());
        //Events
        $('#txtBranchCode').focusout(function (event) {
            if (true) {
                $('#txtBranchName').val('');
                ShowBranch(path, $('#txtBranchCode').val(), '#txtBranchName');
            }
        });

        //3 Fields Show
        $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2', function (response) {
            let dv = document.getElementById("dvLOVs");
            CreateLOV(dv, '#frmSearchBranch', '#tbBranch', 'Branch', response, 2);
        });
        }
    function SearchData(type) {
        switch (type) {
            case 'branch':
                SetGridBranch(path, '#tbBranch', '#frmSearchBranch', ReadBranch);
                break;
        }
    }

    function ReadBranch(dt) {
        $('#txtBranchCode').val(dt.Code);
        $('#txtBranchName').val(dt.BrName);
    }

    function SetGridAdv(isAlert) {
        let w = '';
        if ($('#txtDocDateF').val() !== "") {
            w = w + '&DateFrom=' + CDateEN($('#txtDocDateF').val());
        }
        if ($('#txtDocDateT').val() !== "") {
            w = w + '&DateTo=' + CDateEN($('#txtDocDateT').val());
        }
        if ($('#chkCancel').prop('checked')) {
            w = w + '&Show=CANCEL';
        } else {
            w = w + '&Show=ACTIVE';
        }
        $.get(path + 'acc/getwhtaxgrid?branch=' + $('#txtBranchCode').val() + w, function (r) {
            if (r.whtax.data.length == 0) {
                ShowMessage('Data not found',true);
                return;
            }
            let h = r.whtax.data;
            let tb=$('#tbHeader').DataTable({
                data: h,
                selected: true, //ให้สามารถเลือกแถวได้
                columns: [ //กำหนด property ของ header column
                    { data: "DocNo", title: "Document.No" },
                    {
                        data: "DocDate", title: "Date",
                        render: function (data) {
                            return CDateEN(data);
                        }
                    },
                    { data: "TName1", title: "Tax Issue" },
                    { data: "TName2", title: "Tax Owner" },
                    { data: "TName3", title: "Tax Payer" },
                    { data: "JNo", title: "Job No" },
                    { data: "InvNo", title: "Inv No" },
                    { data: "DocRefNo", title: "Ref No" },
                    { data: "PayAmount", title: "Amount" },
                    { data: "PayTax", title: "Tax" }
                ],
                responsive: true,
                destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                , pageLength: 100
            });
            $('#tbHeader tbody').on('dblclick', 'tr', function () {
                let data = $('#tbHeader').DataTable().row(this).data(); //read current row selected
                window.open(path + 'acc/whtax?Branch=' + $('#txtBranchCode').val() + '&Code=' + data.DocNo,'','');
            });
        });
    }
    function AddWHTax() {
        window.open(path + 'acc/whtax','','');
    }
    function ShowExport() {
        $('#dvExport').modal('show');
    }
</script>
<input type="button" onclick="ShowExport()" value="Export Data" class="btn btn-primary" />
<div class="modal fade" id="dvExport">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <form method="post" action="">
                    <div class="row">
                        <div class="col-sm-4">
                            ปี ค.ศ.
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxYear" value="@yy" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            เดือน
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxMonth" value="@mm" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            Tax ID ผู้มีหน้าที่หัก ณ ที่จ่าย
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxCode" value="@tx" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            ภ.ง.ด
                        </div>
                        <div class="col-sm-6">
                            @Code
                                If frm = "4" Then
                                    @<select name="FormType">
                                        <option value="4" selected>3</option>
                                        <option value="7">53</option>
                                    </select>
                                Else
                                    @<select name="FormType">
                                        <option value="4">3</option>
                                        <option value="7" selected>53</option>
                                    </select>
                                End If
                            End Code
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            มาตรา
                        </div>
                        <div class="col-sm-6">
                            <select name="TaxLawNo">
                                <option value="1" @(IIf(tln = "1", Html.AttributeEncode("selected"), ""))>3 เตรส</option>
                                <option value="2" @(IIf(tln = "2", Html.AttributeEncode("selected"), ""))>65 จัดวา</option>
                                <option value="3" @(IIf(tln = "3", Html.AttributeEncode("selected"), ""))>69 ทวิ</option>
                                <option value="4" @(IIf(tln = "4", Html.AttributeEncode("selected"), ""))>48 ทวิ</option>
                                <option value="5" @(IIf(tln = "5", Html.AttributeEncode("selected"), ""))>50 ทวิ</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            ประเภทการนำส่ง
                        </div>
                        <div class="col-sm-6">
                            @Code
                                If ty = "2" Then
                                    @<select name="TaxType">
                                        <option value="1">จ่ายตรง</option>
                                        <option value="2" selected> ตัวกลาง</option>
                                    </select>
                                Else
                                    @<select name="TaxType">
                                        <option value="1" selected>จ่ายตรง</option>
                                        <option value="2"> ตัวกลาง</option>
                                    </select>
                                End If
                            End Code
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            Tax ID ผู้กระทำการแทน
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxAgent" value="@ta" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            รหัสลงทะเบียน/UserID
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxUser" value="@tu" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            รหัสผู้นำส่ง/Sender
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxRegister" value="@tr" />
                        </div>
                    </div>
                    <input type="submit" name="Submit" value="Submit" />
                </form>                
            </div>
        </div>
    </div>
</div>
