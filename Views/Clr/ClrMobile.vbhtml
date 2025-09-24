@Code
    Dim csCode As String = ""
    If Not Request.QueryString("CS") Is Nothing Then
        csCode = Request.QueryString("CS")
    End If
End Code
<div class="container" style="padding-bottom:5px;">
    <input type="button" class="btn btn-warning" value="Reset" onclick="window.location.reload()" />
    <div class="panel-body" style="background-color:white;margin-top:5px;">
        <h4>STEP 1</h4>
        <div class="row">
            <div class="col-sm-3">
                <label>ระบุผู้ขอเบิก/เลขตู้/job งาน</label>
            </div>
            <div class="col-sm-9">
                ผู้ขอเบิก<br />
                <div style="display:flex;width:100%">

                    <input type="text" class="form-control" id="txtEmpCode" value="@csCode" readonly />
                    <input type="button" class="btn btn-default" onclick="SearchData('reqby')" value="..." />
                </div>
                เลขตู้<br />
                <div style="display:flex;width:100%">
                    <input type="text" class="form-control" id="txtCTN_NO" value="" />
                </div>
                Job<br />
                <div style="display:flex;width:100%">
                    <input type="text" class="form-control" id="txtForJNo" value="" readonly />
                    <input type="button" class="btn btn-default" onclick="SearchData('job')" value="..." />
                </div>
                <br />
                <div style="display:flex;width:100%">
                    <div style="flex:1">
                        <label>ยอดค้างเคลียร์ :</label><br />
                        <input type="number" id="txtAdvBalance" class="form-control" readonly />
                    </div>
                    <div style="flex:1">
                        <label>จำนวน </label>
                        <br />
                        <input type="number" id="txtAdvCount" class="form-control" readonly />
                        <label>รายการ</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel-body" style="background-color: white;margin-top: 5px;">
        <h4>STEP 2</h4>
        <div class="row">
            <div class="col-sm-3">
                <label>เลือกใบเบิกที่จะเคลียร์เงิน</label>
            </div>
            <div class="col-sm-9">
                <table id="tbAdvance" class="table table-responsive">
                </table>
            </div>
        </div>
    </div>
    <div class="panel-body" style="background-color: white; margin-top: 5px;">
        <h4>STEP 3</h4>
        <div class="row">
            <div class="col-sm-3">
                <label>กรอกรายละเอียดเอกสาร</label>
            </div>
            <div class="col-sm-9">
                ชื่อบริษัท :
                <div style="display:flex">
                    <input type="text" id="txtVenderCode" class="form-control" readonly />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('vend')" />
                </div>

                <input type="text" id="txtVenderName" class="form-control" readonly />
                <br />
                เลขใบเสร็จ :
                <input type="text" id="txtSlipNo" class="form-control" />
                <br />
                วันที่ใบเสร็จ :
                <input type="date" id="txtDate50Tavi" class="form-control" />
                <br />
                เลขหนังสือรับรอง หัก ณ ที่จ่าย :
                <input type="text" id="txtNO50Tavi" class="form-control" />
                <br />
                หมายเหตุ :
                <textarea id="txtRemark" class="form-control"></textarea>
                <br />
                Job :
                <div style="display:flex">
                    <input type="text" class="form-control" id="txtJNo" readonly />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('job2')" />
                </div>
                <br />
                ประเภท :
                <div style="display:flex">
                    <input type="text" class="form-control" id="txtJobTypeName" readonly />
                    <input type="text" class="form-control" id="txtShipByName" readonly />
                </div>
                <input type="hidden" id="txtJobType" />
                <input type="hidden" id="txtSTCode" />
                <input type="hidden" id="txtIsExpense" />
                <input type="hidden" id="txtClrType" />
                <input type="hidden" id="txtClrFrom" value="3" />
            </div>
        </div>
    </div>
    <div class="panel-body" style="background-color: white; margin-top: 5px;">
        <h4>STEP 4</h4>
        <div class="row">
            <div class="col-sm-3">
                <label>บันทึกยอดค่าใช้จ่าย</label>
            </div>
            <div class="col-sm-9">
                รหัสค่าใช้จ่าย :
                <div style="display:flex">
                    <input type="text" id="txtSICode" class="form-control" readonly />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('service')" />
                </div>
                <br />
                คำอธิบาย :
                <textarea id="txtSDescription" class="form-control"></textarea>
                <br />
                จำนวน/หน่วย :
                <div style="display:flex">
                    <input type="number" id="txtQty" class="form-control" onchange="CalAmount()" />
                    <input type="text" id="txtUnitCode" class="form-control" readonly />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('unit')" />
                </div>
                <br />
                สกุลเงิน/อัตราแลกเปลี่ยน :
                <div style="display:flex">
                    <input type="text" id="txtCurrencyCode" class="form-control" readonly />
                    <input type="button" class="btn btn-default" value="..." onclick="SearchData('currency')" />
                    <input type="number" id="txtCurRate" class="form-control" onchange="CalAmount()" />
                </div>
                <br />
                ราคา/หน่วย :
                <input type="number" id="txtUnitPrice" class="form-control" onchange="CalAmount()" />
                <br />
                ยอดเงิน(บาท) :
                <input type="number" id="txtUsedAmount" class="form-control" readonly />
                <br />
                <br />
                ภาษีมูลค่าเพิ่ม/หัก ณ ที่จ่าย:
                <div style="display:flex">
                    <select id="txtVATType" class="form-control dropdown" onchange="EnableCal()">
                        <option value="0">NO</option>
                        <option value="1">EXC</option>
                        <option value="2">INC</option>
                    </select>
                    <input type="number" id="txtVATRate" class="form-control" onchange="Recalculate()" />
                    <input type="number" id="txtTax50TaviRate" class="form-control" onchange="Recalculate()" />
                </div>
                <br />
                ภาษีมูลค่าเพิ่ม :
                <input type="number" id="txtChargeVAT" class="form-control" readonly />
                <br />
                หัก ณ ที่จ่าย :
                <input type="number" id="txtTax50Tavi" class="form-control" readonly />
                <br />
                ยอดสุทธิ(บาท) :
                <input type="number" id="txtBNet" class="form-control" readonly />
            </div>
        </div>
    </div>
    <div class="panel-body" style="background-color: white; margin-top: 5px;">
        <h4>STEP 5</h4>
        <div class="row">
            <div class="col-sm-3">
                <label>ตรวจสอบยอดคงเหลือ</label>
            </div>
            <div class="col-sm-9">
                ยอดเบิก :
                <input type="number" id="txtAdvAmount" class="form-control" readonly />
                <br />
                คงเหลือ :
                <input type="number" id="txtAdvReturn" class="form-control" readonly />
            </div>
        </div>
    </div>
    <input type="button" class="btn btn-success" value="Save Data" onclick="SaveData()" />
    <div>
        เลขที่เอกสาร :
        <input type="text" id="txtClrNo" class="form-control" />
        <textarea id="txtJsonD"></textarea>
        <textarea id="txtJsonH"></textarea>
    </div>    
</div>
<div id="dvLOVs"></div>
<script src="~/Scripts/Func/combo.js"></script>
<script type="text/javascript">
    const path = '@Url.Content("~")';
    const user = '@ViewBag.User';
    const userRights = '@ViewBag.UserRights';
    const userPosition = '@ViewBag.UserPosition';
    let row = {};
    let csCode = '@csCode';
    let branchCode = '@ViewBag.PROFILE_DEFAULT_BRANCH';
    window.onload = function () {
        if (user !== '') {
            $.get(path + 'Config/ListValue?ID=tbX&Head=cpX&FLD=code,key,name,desc1,desc2').done(function (response) {
                let dv = document.getElementById("dvLOVs");
                //Venders
                CreateLOV(dv, '#frmSearchVend', '#tbVend', 'Venders', response, 2);
                //Job
                CreateLOV(dv, '#frmSearchJob', '#tbJob', 'Job List', response, 4);
                //Users
                CreateLOV(dv, '#frmSearchClr', '#tbClr', 'CS Code', response, 2);
                //SICode
                CreateLOV(dv, '#frmSearchSICode', '#tbServ', 'Service Code', response, 2);
                //Currency
                CreateLOV(dv, '#frmSearchExpCur', '#tbExpCur', 'Currency Code', response, 2);
                //Unit
                CreateLOV(dv, '#frmSearchUnit', '#tbUnit', 'Unit Code', response, 2);
            });
            if (csCode !== '') {
                $('#txtEmpCode').val(csCode);
                LoadAdvance(branchCode, csCode,'');
            }            
        }        
    }
    function SearchData(type) {
        switch (type) {
            case 'reqby':
                SetGridUser(path, '#tbClr', '#frmSearchClr', ReadCS);
                break;
            case 'job':
                SetGridTransport(path,'#tbJob','#frmSearchJob','?Cont='+ $('#txtCTN_NO').val(),ReadBooking);
                break;
            case 'job2':
                SetGridTransport(path, '#tbJob', '#frmSearchJob','', ReadJob);
                break;
            case 'vend':
                SetGridVender(path, '#tbVend', '#frmSearchVend', ReadVender);
                break;
            case 'service':
                SetGridSICode(path, '#tbServ','', '#frmSearchSICode', ReadService);
                break;
            case 'unit':
                SetGridServUnit(path, '#tbUnit', '#frmSearchUnit', ReadUnit);
                break;
            case 'currency':
                SetGridCurrency(path, '#tbExpCur', '#frmSearchExpCur', ReadCurrency);
                break;
        }
    }
    function LoadAdvance(branch, cs,job) {
        $('#tbAdvance').empty();
        $('#txtAdvBalance').val(0);
        $('#txtAdvCount').val(0);
        let q = '?branchcode=' + branch;
        if (cs !== '') {
            q += '&reqby=' + cs;
        }
        if (job !== '') {
            q += '&jobno=' + job;
        }
        let url = path + 'Clr/GetAdvForClear' + q;        
        $.get(url).done(function (r) {
            if (r.clr.data.length > 0) {
                let totaldoc = 0;
                let countdoc = 0;
                let d = r.clr.data;
                for (let o of d) {
                    countdoc++;
                    totaldoc += o.AdvBalance;
                }
                $('#txtAdvBalance').val(totaldoc.toFixed(2));
                $('#txtAdvCount').val(countdoc);
                $('#tbAdvance').DataTable({
                    data: d,
                    selected: true, //ให้สามารถเลือกแถวได้
                    columns: [ //กำหนด property ของ header column
                        { data: "AdvNO", title: "Adv.No" },
                        { data: "SDescription", title: "Expense Name" },
                        {
                            data: "AdvBalance", title: "Balance",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                        {
                            data: "UsedAmount", title: "Used",
                            render: function (data) {
                                return ShowNumber(data, 2);
                            }
                        },
                    ],
                    responsive: true,
                    destroy: true //ให้ล้างข้อมูลใหม่ทุกครั้งที่ reload page
                    , pageLength: 100
                });
                $('#tbAdvance tbody').on('click', 'tr', function () {
                    if ($('#tbAdvance tbody > tr').hasClass('selected')) {
                        $('#tbAdvance tbody > tr').removeClass('selected');
                    }
                    $(this).addClass('selected');

                    row= $('#tbAdvance').DataTable().row(this).data(); //read current row selected                    
                    LoadDetail(row);
                });
            } else {
                    ShowMessage("Not found data for clear", true);
            }
        });
    }
    function ReadCurrency(dt) {
        $('#txtCurrencyCode').val(dt.Code);
        $('#txtCurRate').val(1);
     }
    function ReadUnit(dt) {
        $('#txtUnitCode').val(dt.UnitType);
    }
    function ReadCS(dt) {
        $('#txtEmpCode').val(dt.UserID);
        LoadAdvance(branchCode, dt.UserID,'');
    }
    function ReadJob(dt) {
        $('#txtJNo').val(dt.JNo);
        CallBackQueryJob(path, dt.BranchCode, dt.JNo, (d) => {
            if (d.length > 0) {
                let r = d[0];
                $('#txtJobType').val(r.JobType);
                ShowJobTypeShipBy(path, r.JobType, r.ShipBy, r.JobStatus, '#txtJobTypeName', '#txtShipByName', '');
            }
        });
    }
    function ReadBooking(dt) {
        $('#txtForJNo').val(dt.JNo);
        LoadAdvance(branchCode, $('#txtEmpCode').val(), dt.JNo);
    }
    function ReadVender(dt) {
        $('#txtVenderCode').val(dt.VenCode);
        $('#txtVenderName').val(dt.TName);
    }
    function ReadService(dt) {
        $('#txtSICode').val(dt.SICode);
        $('#txtSTCode').val(dt.GroupCode);
        $('#txtSDescription').val(dt.NameThai);
        $('#txtIsExpense').val(dt.IsExpense);
        $('#txtVATType').val(dt.IsTaxCharge);
        if (dt.IsTaxCharge == 0) {
            $('#txtVATRate').val(0);
        } else {
            $('#txtVATRate').val(@ViewBag.PROFILE_VATRATE);
        }
        if (dt.IsExpense == 1) {
            $('#txtClrType').val(2);
        } else {
            $('#txtClrType').val(1);
        }
        $('#txtTax50TaviRate').val(dt.Rate50Tavi);
        EnableCal();
        Recalculate();
    }
    function LoadDetail(dt) {
        $('#txtClrNo').val('');
        $('#txtAdvAmount').val(dt.AdvBalance);
        $('#txtVenderCode').val(dt.VenderCode);
        ShowVender(path, dt.VenderCode, '#txtVenderName');
        $('#txtSICode').val(dt.SICode);
        $('#txtSTCode').val(dt.STCode);
        $('#txtSDescription').val(dt.SDescription);
        $('#txtVATType').val(dt.VATType);
        $('#txtQty').val(dt.Qty);
        $('#txtUnitCode').val(dt.UnitCode);
        $('#txtCurrencyCode').val(dt.CurrencyCode);
        $('#txtCurRate').val(dt.CurRate);
        $('#txtIsExpense').val(dt.IsExpense);
        if (dt.IsExpense == 1) {
            $('#txtClrType').val(2);
        } else {
            $('#txtClrType').val(1);
        }
        EnableCal()
        $('#txtVATRate').val(dt.VATRate);
        $('#txtTax50TaviRate').val(dt.Tax50TaviRate);
        $('#txtJNo').val(dt.JobNo);
        CallBackQueryJob(path, dt.BranchCode, dt.JobNo, (d) => {
            if (d.length > 0) {
                let r = d[0];
                $('#txtJobType').val(r.JobType);
                ShowJobTypeShipBy(path, r.JobType, r.ShipBy, r.JobStatus, '#txtJobTypeName', '#txtShipByName', '');
            }
        });                
        CalVATWHT(dt);
        $('#txtSlipNo').focus();
    }
    function EnableCal() {
        let vt = $('#txtVATType').val();
        $('#txtUsedAmount').removeAttr('readonly');
        $('#txtBNet').removeAttr('readonly');
        if (vt == "2") {
            $('#txtUsedAmount').attr('readonly', 'readonly');
            $('#txtBNet').change(Recalculate);
            $('#txtUsedAmount').change(function () { });
        }
        if (vt == "1") {
            $('#txtBNet').attr('readonly', 'readonly');
            $('#txtUsedAmount').change(Recalculate);
            $('#txtBNet').change(function () { });
        }
    }
    function CalAmount() {
        let qty = Number($('#txtQty').val());
        let unitprice = Number($('#txtUnitPrice').val());
        let excrate = Number($('#txtCurRate').val());
        let total = qty * unitprice * excrate;
        if ($('#txtVATType').val() == "2") {
            $('#txtBNet').val(total.toFixed(2));
            Recalculate();
        }
        if ($('#txtVATType').val() !== "2") {
            $('#txtUsedAmount').val(total.toFixed(2));
            Recalculate();
        }
    }
    function Recalculate() {
        if ($('#txtVATType').val() !== "2") {
            let amt = Number($('#txtUsedAmount').val());
            let vat = Number(amt * (Number($('#txtVATRate').val()) / 100));
            let wht = Number(amt * (Number($('#txtTax50TaviRate').val()) / 100));
            let net = amt + Number(vat.toFixed(2)) - Number(wht.toFixed(2));

            $('#txtChargeVAT').val(vat.toFixed(2));
            $('#txtTax50Tavi').val(wht.toFixed(2));
            $('#txtBNet').val(net.toFixed(2));
        }
        if ($('#txtVATType').val() == "2") {
            let vat = ((Number($('#txtBNet').val()) * 100) / (100 + Number($('#txtVATRate').val()) - Number($('#txtTax50TaviRate').val())) * (Number($('#txtVATRate').val()) / 100));
            let wht = ((Number($('#txtBNet').val()) * 100) / (100 + Number($('#txtVATRate').val()) - Number($('#txtTax50TaviRate').val())) * (Number($('#txtTax50TaviRate').val()) / 100));
            let amt = Number($('#txtBNet').val()) + Number(wht.toFixed(2)) - Number(vat.toFixed(2));
            $('#txtUsedAmount').val(amt.toFixed(2));
            $('#txtChargeVAT').val(vat.toFixed(2));
            $('#txtTax50Tavi').val(wht.toFixed(2));
        }
        $('#txtAdvReturn').val(Number($('#txtAdvAmount').val()) - Number($('#txtBNet').val()));
    }
    function CalVATWHT(dt) {
        if (dt.VATType > 0) {
            let amt = (dt.AdvBalance * 100) / (100 + dt.VATRate - dt.Tax50TaviRate);
            let vat = ((dt.AdvBalance * 100) / (100 + dt.VATRate - dt.Tax50TaviRate) * (dt.VATRate / 100));
            let wht = ((dt.AdvBalance * 100) / (100 + dt.VATRate - dt.Tax50TaviRate) * (dt.Tax50TaviRate / 100));
            let net = amt + vat - wht;
            $('#txtUsedAmount').val(amt.toFixed(2));
            $('#txtChargeVAT').val(vat.toFixed(2));
            $('#txtTax50Tavi').val(wht.toFixed(2));
            $('#txtBNet').val(net.toFixed(2));
        } else {
            $('#txtUsedAmount').val(dt.AdvBalance);
            $('#txtChargeVAT').val(0);
            $('#txtTax50Tavi').val(0);
            $('#txtBNet').val(dt.AdvBalance);
        }
        let unitprice = (Number($('#txtUsedAmount').val()) / dt.CurRate) / dt.Qty;
        $('#txtUnitPrice').val(unitprice);
        $('#txtAdvReturn').val(0);
    }
    function SaveData() {
        let obj = GetDataDetail($('#txtClrNo').val());        
        let jsonD = JSON.stringify({ data: obj });
        obj = GetDataHeader(obj);
        let jsonH = JSON.stringify({ data: obj });
        $('#txtJsonD').val(jsonD);
        $('#txtJsonH').val(jsonH);
    }
    function GetDataDetail(clrno) {
        let dt = {
            BranchCode: row.BranchCode,
            ClrNo: clrno,
            ItemNo: 0,
            LinkItem: 0,
            SICode: $('#txtSICode').val(),
            STCode: $('#txtSTCode').val(),
            SDescription: $('#txtSDescription').val(),
            VenderCode: $('#txtVenderCode').val(),
            Qty: $('#txtQty').val(),
            UnitCode: $('#txtUnitCode').val(),
            CurrencyCode: $('#txtCurrencyCode').val(),
            CurRate: $('#txtCurRate').val(),
            UnitPrice: $('#txtIsExpense').val()==1 ? 0 : $('#txtUnitPrice').val(),
            FPrice: $('#txtIsExpense').val() == 1 ? 0 : CDbl(Number($('#txtUsedAmount').val()) / Number($('#txtCurRate').val()), 2),
            BPrice: $('#txtIsExpense').val() == 1 ? 0 : CDbl(Number($('#txtUsedAmount').val()), 2),
            QUnitPrice: row.QUnitPrice,
            QFPrice: CDbl(CNum(row.QUnitPrice) * CNum($('#txtQty').val()), 4),
            QBPrice: CDbl(CNum($('#txtCurRate').val()) * CNum(row.QUnitPrice) * CNum($('#txtQty').val()), 2),
            UnitCost: $('#txtUnitPrice').val(),
            FCost: CDbl(Number($('#txtUsedAmount').val()) / Number($('#txtCurRate').val()), 2),
            BCost: CDbl(Number($('#txtUsedAmount').val()), 2),
            ChargeVAT: $('#txtChargeVAT').val(),
            Tax50Tavi: $('#txtTax50Tavi').val(),
            AdvNO: row.AdvNO,
            AdvItemNo: row.AdvItemNo,
            AdvAmount: row.AdvBalance,
            UsedAmount: $('#txtUsedAmount').val(),
            IsQuoItem: row.IsQuoItem,
            SlipNO: $('#txtSlipNo').val(),
            Remark: $('#txtRemark').val(),
            IsLtdAdv50Tavi: row.IsLtdAdv50Tavi,
            Pay50TaviTo: row.Pay50TaviTo,
            NO50Tavi: $('#txtNO50Tavi').val(),
            Date50Tavi: CDateEN($('#txtDate50Tavi').val()),
            VenderBillingNo: row.VenderBillingNo,
            AirQtyStep: row.AirQtyStep,
            StepSub: row.StepSub,
            LinkBillNo: '',
            JobNo: $('#txtJNo').val(),
            VATType: $('#txtVATType').val(),
            VATRate: $('#txtVATRate').val(),
            Tax50TaviRate: $('#txtTax50TaviRate').val(),
            IsDuplicate: row.IsDuplicate,
            QNo: row.QNo,
            FNet: Number($('#txtBNet').val()) / Number($('#txtCurRate').val()),
            BNet: $('#txtBNet').val()
        };
        return dt;
    }
    function GetDataHeader(dt) {
        let dh = {
            BranchCode: dt.BranchCode,
            ClrNo: '',
            ClrDate: GetToday(),
            ClearanceDate: GetToday(),
            EmpCode: user,
            AdvRefNo: row.AdvNO,
            AdvTotal: row.AdvBalance,
            JobType: $('#txtJobType').val(),
            JNo: dt.JobNo,
            InvNo: $('#txtCTN_NO').val(),
            ClearType: $('#txtClrType').val(),
            ClearFrom: $('#txtClrFrom').val(),
            DocStatus: 0,
            TotalExpense: dt.BNet,
            TRemark: '',
            ApproveBy: '',
            ApproveDate: null,
            ApproveTime: null,
            ReceiveBy: '',
            ReceiveDate: null,
            ReceiveTime: null,
            ReceiveRef: '',
            CancelReson: '',
            CancelProve: '',
            CancelDate: null,
            CancelTime: null,
            CoPersonCode: '',
            CTN_NO: $('#txtCTN_NO').val(),
            ClearTotal: (row.AdvBalance-dt.BNet),
            ClearVat: dt.ChargeVAT,
            ClearWht: dt.Tax50Tavi,
            ClearNet: dt.BNet,
            ClearBill: (dt.BPrice > 0 ? dt.BPrice : 0),
            ClearCost: (dt.BPrice == 0 ? dt.BCost:0)
        };

        return dh;
    }
</script>