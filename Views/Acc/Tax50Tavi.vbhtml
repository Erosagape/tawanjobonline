@Code
    ViewBag.Title = "Withholding-Tax Lists"
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

    Dim strHeader As String = ""
    Dim strDetail As String = ""
    Dim strAll As String = ""
    If ViewBag.User = "" Or Request.Form("Submit") = "" Then
    Else
        Dim sqlH = ""
        If sqlH = "" Then
            sqlH = "
select h.TaxNumber1,Convert(numeric,'0'+h.Branch1) as Branch1,h.TaxNumber2,Convert(numeric,'0'+h.Branch2) as Branch2,h.SeqInForm,h.TaxLawNo,
count(distinct d.DocNo) as TotalDoc,SUM(d.PayAmount) as TotalPayAmount,sum(d.PayTax) as TotalPayTax
from Job_WHTax h left join Job_WHTaxDetail d
on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
where h.FormType=" & frm & " AND Year(h.DocDate)={0} AND Month(h.DocDate)={1} AND h.TaxNumber1='{2}'
group by h.TaxNumber1,Convert(numeric,'0'+h.Branch1),h.TaxNumber2,Convert(numeric,'0'+h.Branch2),h.SeqInForm,h.TaxLawNo
"
        End If
        Dim sqlD = ""
        If sqlD = "" Then
            sqlD = "
select h.DocNo,h.TaxNumber3,Convert(numeric,'0'+h.Branch3) as Branch3,MAX(h.TName3) as TName3,MAX(h.TAddress3) as TAddress3,
d.PayRate,d.PayDate,d.PayTaxDesc,d.DocRefType,
SUM(d.PayAmount) as PayAmount,sum(d.PayTax) as PayTax
from Job_WHTax h left join Job_WHTaxDetail d
on h.BranchCode=d.BranchCode and h.DocNo=d.DocNo
where h.FormType=" & frm & " AND Year(h.DocDate)={0} AND Month(h.DocDate)={1} AND h.TaxNumber1='{2}'
AND h.TaxNumber2='{3}' AND Convert(numeric,'0'+h.Branch2)={4} AND h.SeqInForm='{5}' AND h.TaxLawNo='{6}'
group by h.DocNo,h.TaxNumber3,Convert(numeric,'0'+h.Branch3),
d.PayRate,d.PayDate,d.PayTaxDesc,d.DocRefType
"
        End If

        Dim th = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlH, yy, mm, tx))
        For Each rh As System.Data.DataRow In th.Rows
            strHeader = "H" & "|"   '#1
            strHeader &= "0000" & "|"   '#2
            If rh("TaxNumber2").ToString <> "" Then
                strHeader &= rh("TaxNumber2").ToString & "|"    '#3
                strHeader &= CInt("0" & rh("Branch2").ToString).ToString("000000") & "|"    '#4
                strHeader &= "2" & "|"   '#5
            Else
                strHeader &= rh("TaxNumber1").ToString & "|"    '#3
                strHeader &= CInt("0" & rh("Branch1").ToString).ToString("000000") & "|"    '#4
                strHeader &= "1" & "|"   '#5
            End If
            strHeader &= "PND53" & "|"   '#6
            strHeader &= rh("TaxNumber1").ToString & "|"    '#7
            strHeader &= CInt("0" & rh("Branch1").ToString).ToString("000000") & "|"    '#8
            strHeader &= "แผนกบัญชี" & "|"    '#9
            If CInt("0" & rh("TaxLawNo").ToString) = 1 Then
                strHeader &= "1" & "|"    '#10
            Else
                strHeader &= "0" & "|"    '#10
            End If
            If CInt("0" & rh("TaxLawNo").ToString) = 2 Then
                strHeader &= "1" & "|"    '#11
            Else
                strHeader &= "0" & "|"    '#11
            End If
            If CInt("0" & rh("TaxLawNo").ToString) = 3 Then
                strHeader &= "1" & "|"    '#12
            Else
                strHeader &= "0" & "|"    '#12
            End If
            strHeader &= "0" & "|"    '#13
            strHeader &= CInt("0" & mm).ToString("00") & "|"    '#14
            strHeader &= CInt("0" & yy).ToString("0000") + 543 & "|"    '#15
            strHeader &= "V" & "|"    '#16                
            strHeader &= CInt("0" & rh("SeqInForm").ToString).ToString("00") & "|"    '#17
            strHeader &= rh("TotalDoc") & "|"    '#18
            strHeader &= rh("TotalPayAmount") & "|"    '#19
            strHeader &= rh("TotalPayTax") & "|"    '#20
            strHeader &= "0.00" & "|"    '#21
            strHeader &= rh("TotalPayTax") & "|"    '#22
            strHeader &= "0.00" & "|"    '#23
            strHeader &= ViewBag.PROFILE_TAXNUMBER & "|"    '#24
            strHeader &= "2" & "|"    '#25
            strHeader &= vbCrLf

            strDetail = ""
            Dim lastDoc = ""
            Dim lastAddr = ""

            Dim rc As Integer = 0
            Dim ic As Integer = 0
            Dim td = New CUtil(ViewBag.CONNECTION_JOB).GetTableFromSQL(String.Format(sqlD, yy, mm, tx, rh("TaxNumber2").ToString, rh("Branch2").ToString, rh("SeqInForm").ToString, rh("TaxLawNo").ToString))
            For Each rd As System.Data.DataRow In td.Rows
                If lastDoc <> rd("DocNo").ToString Then
                    If ic = 1 Then
                        strDetail &= "00000000|"    '#15
                        strDetail &= "|"    '#16
                        strDetail &= "|"    '#17
                        strDetail &= "|"    '#18
                        strDetail &= "|"    '#19
                        strDetail &= "|"    '#20

                        strDetail &= "00000000|"    '#21
                        strDetail &= "|"    '#22
                        strDetail &= "|"    '#23
                        strDetail &= "|"    '#24
                        strDetail &= "|"    '#25
                        strDetail &= "|"    '#26
                    End If
                    If ic = 2 Then
                        strDetail &= "00000000|"    '#21
                        strDetail &= "|"    '#22
                        strDetail &= "|"    '#23
                        strDetail &= "|"    '#24
                        strDetail &= "|"    '#25
                        strDetail &= "|"    '#26
                    End If
                    strDetail &= "|"    '#27
                    strDetail &= "|"    '#28
                    strDetail &= "|"    '#29
                    strDetail &= lastAddr & "|"    '#30
                    strDetail &= "|"    '#31
                    strDetail &= "|"    '#32
                    strDetail &= "|"    '#33
                    strDetail &= "|"    '#34
                    strDetail &= "|"    '#35
                    strDetail &= "|"    '#36
                    strDetail &= "|"    '#37
                    strDetail &= "|"    '#38

                    lastDoc = rd("DocNo").ToString
                    lastAddr = rd("TAddress3").ToString
                    ic = 0
                    rc += 1
                    If rc > 1 Then
                        strDetail &= vbCrLf
                    End If
                    strDetail &= "D" & "|"  '#1
                    strDetail &= rc & "|"  '#2
                    strDetail &= CInt("0" & rd("Branch3").ToString).ToString("000000") & "|"    '#3
                    If rd("TaxNumber3").ToString.Length = 13 Then
                        strDetail &= rd("TaxNumber3").ToString() & "|"    '#4
                    Else
                        strDetail &= "|"    '#4
                    End If
                    If rd("TaxNumber3").ToString.Length < 13 Then
                        strDetail &= CInt("0" & rd("TaxNumber3").ToString).ToString("000000") & "|"    '#5
                    Else
                        strDetail &= "|"    '#5
                    End If
                    strDetail &= "|"    '#6
                    strDetail &= rd("TName3").ToString() & "|"    '#7
                    strDetail &= "|"    '#8
                End If
                ic += 1
                If ic = 1 Then
                    strDetail &= CDate(rd("PayDate").ToString()).AddYears(543).ToString("ddMMyyyy") & "|"    '#9
                    strDetail &= rd("PayRate").ToString() & "|"    '#10
                    strDetail &= rd("PayAmount").ToString() & "|"    '#11
                    strDetail &= rd("PayTax").ToString() & "|"    '#12
                    strDetail &= rd("PayTaxDesc").ToString() & "|"    '#13
                    strDetail &= rd("DocRefType").ToString() & "|"    '#14
                End If
                If ic = 2 Then
                    strDetail &= CDate(rd("PayDate").ToString()).AddYears(543).ToString("ddMMyyyy") & "|"    '#15
                    strDetail &= rd("PayRate").ToString() & "|"    '#16
                    strDetail &= rd("PayAmount").ToString() & "|"    '#17
                    strDetail &= rd("PayTax").ToString() & "|"    '#18
                    strDetail &= rd("PayTaxDesc").ToString() & "|"    '#19
                    strDetail &= rd("DocRefType").ToString() & "|"    '#20
                End If
                If ic = 3 Then
                    strDetail &= CDate(rd("PayDate").ToString()).AddYears(543).ToString("ddMMyyyy") & "|"    '#21
                    strDetail &= rd("PayRate").ToString() & "|"    '#22
                    strDetail &= rd("PayAmount").ToString() & "|"    '#23
                    strDetail &= rd("PayTax").ToString() & "|"    '#24
                    strDetail &= rd("PayTaxDesc").ToString() & "|"    '#25
                    strDetail &= rd("DocRefType").ToString() & "|"    '#26
                End If
            Next
            If ic = 1 Then
                strDetail &= "00000000|"    '#15
                strDetail &= "|"    '#16
                strDetail &= "|"    '#17
                strDetail &= "|"    '#18
                strDetail &= "|"    '#19
                strDetail &= "|"    '#20

                strDetail &= "00000000|"    '#21
                strDetail &= "|"    '#22
                strDetail &= "|"    '#23
                strDetail &= "|"    '#24
                strDetail &= "|"    '#25
                strDetail &= "|"    '#26
            End If
            If ic = 2 Then
                strDetail &= "00000000|"    '#21
                strDetail &= "|"    '#22
                strDetail &= "|"    '#23
                strDetail &= "|"    '#24
                strDetail &= "|"    '#25
                strDetail &= "|"    '#26
            End If
            strDetail &= "|"    '#27
            strDetail &= "|"    '#28
            strDetail &= "|"    '#29
            strDetail &= lastAddr & "|"    '#30
            strDetail &= "|"    '#31
            strDetail &= "|"    '#32
            strDetail &= "|"    '#33
            strDetail &= "|"    '#34
            strDetail &= "|"    '#35
            strDetail &= "|"    '#36
            strDetail &= "|"    '#37
            strDetail &= "|"    '#38

            If strAll <> "" Then
                strAll &= vbCrLf
            End If
            strAll &= strHeader & strDetail
        Next
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(strAll)
        Response.Clear()
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = "UTF-8"
        Response.Buffer = True
        Response.ContentType = "application/text"
        Response.AddHeader("content-disposition", "attachment; filename=PND.txt")
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
                            Year
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxYear" value="@yy" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            Month
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxMonth" value="@mm" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            Tax Issue
                        </div>
                        <div class="col-sm-6">
                            <input type="text" name="TaxCode" value="@tx" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            Tax Form
                        </div>
                        <div class="col-sm-6">
                            <select name="FormType">
                                <option value="4">3</option>
                                <option value="7">53</option>
                            </select>
                        </div>
                    </div>
                    <input type="submit" name="Submit" value="Submit" />
                </form>
            </div>
        </div>
    </div>
    
</div>