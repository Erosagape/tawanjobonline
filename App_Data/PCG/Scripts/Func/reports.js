//this function bind for label using in reports
function ShowBranch(path, Branch, ControlID) {
    $(ControlID).text('');
    $.get(path + 'Config/GetBranch?Code=' + Branch)
        .done(function (r) {
            if (r.branch.data.length > 0) {
                let b = r.branch.data[0];
                $(ControlID).text(b.BrName);
            }
        });
}
function ShowJobTypeShipBy(path, jt, sb, js, ControlJT, ControlSB, ControlST) {
    $(ControlJT).text('');
    $(ControlSB).text('');
    if (jt < 10) jt = '0' + jt;
    if (sb < 10) sb = '0' + sb;
    $.get(path + 'Config/GetConfig?Code=JOB_TYPE&Key=' + jt)
        .done(function (r) {
            let b = r.config.data;
            if (b.length > 0) {
                $(ControlJT).text(b[0].ConfigValue);
            }
        });
    $.get(path + 'Config/GetConfig?Code=SHIP_BY&Key=' + sb)
        .done(function (r) {
            let b = r.config.data;
            if (b.length > 0) {
                $(ControlSB).text(b[0].ConfigValue);
            }
        });
    if (ControlST != "") {
        $(ControlST).val('');
        if (js < 10) js = '0' + js;
        $.get(path + 'Config/GetConfig?Code=JOB_STATUS&Key=' + js)
            .done(function (r) {
                let b = r.config.data;
                if (b.length > 0) {
                    $(ControlST).text(b[0].ConfigValue);
                }
            });
    }
}
function ShowInvUnit(path, unitCode, ControlID) {
    $(ControlID).text(unitCode);
    if (unitCode != "") {
        $.get(path + 'Master/GetCustomsUnit?Code=' + unitCode)
            .done(function (r) {
                if (r.customsunit.data.length > 0) {
                    let b = r.customsunit.data[0];
                    $(ControlID).text(b.TName);
                }
            });
    }
}
function ShowServUnit(path, unitCode, ControlID) {
    $(ControlID).text(unitCode);
    if (unitCode != "") {
        $.get(path + 'Master/GetServUnit?Code=' + unitCode)
            .done(function (r) {
                if (r.servunit.data.length > 0) {
                    let b = r.servunit.data[0];
                    $(ControlID).text(b.UName);
                }
            });
    }
}
function ShowCompany(d) {
    let c = DummyCompanyData();
    $(d).html('<b>' + c.CompanyName + '</b>'
        + '<br/>' + c.CompanyAddress1
        + ' '
        + c.CompanyAddress2);
}
function ShowCountry(path, CountryID, ControlID) {
    $(ControlID).text('-');
    if (CountryID != "") {
        $.get(path + 'Master/GetCountry?Code=' + CountryID)
            .done(function (r) {
                if (r.country.data.length > 0) {
                    let b = r.country.data[0];
                    $(ControlID).text(b.CTYName);
                }
            });
    }
}
function ShowInterPort(path, CountryID, PortCode, ControlID) {
    $(ControlID).text('-');
    $.get(path + 'Master/GetInterPort?Code=' + PortCode + '&Key=' + CountryID)
        .done(function (r) {
            if (r.interport.data.length > 0) {
                let b = r.interport.data[0];
                $(ControlID).text(b.PortName);
            }
        });
}
function ShowReleasePort(path, Code, ControlID) {
    $(ControlID).text('-');
    $.get(path + 'Master/GetCustomsPort?Code=' + Code)
        .done(function (r) {
            if (r.RFARS.data.length > 0) {
                let b = r.RFARS.data[0];
                $(ControlID).text(b.AreaName);
            }
        });
}
function ShowVender(path, VenderID, ControlID) {
    $(ControlID).text('-');
    if (VenderID != "") {
        $.get(path + 'Master/GetVender?Code=' + VenderID)
            .done(function (r) {
                if (r.vender.data.length > 0) {
                    let b = r.vender.data[0];
                    $(ControlID).text(b.TName);
                }
            });
    }
}
function ShowDeclareType(path, Code, ControlID) {
    $(ControlID).text('-');
    $.get(path + 'Master/GetDeclareType?Code=' + Code)
        .done(function (r) {
            if (r.RFDCT.data.length > 0) {
                let b = r.RFDCT.data[0];
                $(ControlID).text(b.Description);
            }
        });
}
function ShowUser(path, UserID, ControlID) {
    $(ControlID).text('-');
    if (UserID != "") {
        $.get(path + 'Master/GetUser?Code=' + UserID)
            .done(function (r) {
                if (r.user.data.length > 0) {
                    let b = r.user.data[0];
                    $(ControlID).text(b.TName);
                }
            });
    }
}
function ShowConfig(path, Code, Key, ControlID) {
    $.get(path + 'Config/GetConfig?Code=' + Code + '&Key=' + Key)
        .done(function (r) {
            let b = r.config.data;
            if (b.length > 0) {
                $(ControlID).text(b[0].ConfigValue);
            }
        });
}
function ShowUserSign(path, UserID, ControlID) {
    if (UserID != "") {
        $.get(path + 'Master/GetUser?Code=' + UserID)
            .done(function (r) {
                if (r.user.data.length > 0) {
                    let b = r.user.data[0];
                    $(ControlID).text('(' + b.TName + ')');
                }
            });
    }
}
function ShowCustomer(path, Code, Branch, ControlID) {
    $(ControlID).val('');
    if ((Code + Branch).length > 0) {
        $.get(path + 'Master/GetCompany?Code=' + Code + '&Branch=' + Branch)
            .done(function (r) {
                if (r.company.data.length > 0) {
                    let c = r.company.data[0];
                    $(ControlID).text(c.NameThai);
                }
            });
    }
}
function ShowCustomerEN(path, Code, Branch, ControlID) {
    $(ControlID).val('');
    if ((Code + Branch).length > 0) {
        $.get(path + 'Master/GetCompany?Code=' + Code + '&Branch=' + Branch)
            .done(function (r) {
                if (r.company.data.length > 0) {
                    let c = r.company.data[0];
                    $(ControlID).text(c.NameEng);
                }
            });
    }
}
function GetReportStatus(reportID) {
    let val = '';
    switch (reportID) {
        case 'JOBADV':
        case 'ADVDAILY':
        case 'ADVSUMMARY':
        case 'ADVCLEARING':
            val = 'ADV_STATUS';
            break;
        case 'CLRDAILY':
            val = 'CLR_STATUS';
            break;
        case 'JOBDAILY':
        case 'JOBCS':
        case 'JOBSHP':
        case 'JOBTYPE':
        case 'JOBSHIPBY':
        case 'JOBCUST':
        case 'JOBPORT':
        case 'JOBSALES':
        case 'JOBCOMM':
        case 'RCPDAILY':
        case 'TAXDAILY':
        case 'INVDAILY':
        case 'BILLDAILY':
        case 'JOBCOST':
        case 'ACCINC':
        case 'JOBVOLUME':
        case 'JOBSTATUS':
        case 'ARBAL':
        case 'PLANLOAD':
        case 'JOBTRANSPORT':
            val = 'JOB_STATUS';
            break;
        case 'EXPDAILY':
        case 'CASHDAILY':
        case 'BOOKBAL':
        case 'VATSALES':
        case 'VATBUY':
        case 'WHTAX':
        case 'ACCEXP':
        case 'APBAL':
        case 'CNDN':
        case 'TRIALBAL':
        case 'BALANCS':
        case 'PROFITLOSS':
        case 'CASHFLOW':
        case 'CASHBAL':
        case 'JOURNAL':
            val = '';
            break;
        case 'CHQISSUE':
        case 'CHQRECEIVE':
            val = 'CHQ_STATUS';
            break;
    }
    return val;
}
function GetPaymentType(p) {
    switch (p) {
        case 'CA':
            return 'Cash/Transfer';
            break;
        case 'CH':
            return 'Cashier Cheque';
            break;
        case 'CU':
            return 'Customer Cheque';
            break;
        case 'CR':
            return 'Credit';
            break;
    }
}
function GetVoucherType() {
    switch (vcType) {
        case 'P':
            return 'PAYMENT';
            break;
        case 'R':
            return 'RECEIVE';
            break;
        default:
            return '';
            break;
    }
}
function LoadCliteria(reportID) {
    $('#tbDate').show();
    $('#tbCode').hide();
    switch (reportID) {
        case 'JOBDAILY':
        case 'JOBCS':
        case 'JOBFOLLOWUP':
        case 'JOBSHP':
        case 'JOBTYPE':
        case 'JOBSHIPBY':
        case 'JOBCUST':
        case 'JOBPORT':
        case 'JOBSALES':
        case 'JOBCOMM':
        case 'INVDAILY':
        case 'INVSTATUS':
        case 'RCPDAILY':
        case 'RCPSUMMARY':
        case 'TAXDAILY':
        case 'TAXSUMMARY':
        case 'INVDAILY':
        case 'BILLDAILY':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').show();
            $('#tbJob').show();
            $('#tbVend').hide(); //hide
            break;
        case 'JOBADV':
        case 'ADVDAILY':
        case 'CASHDAILY':
        case 'CLRDAILY':
        case 'JOBCOST':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').show();
            $('#tbJob').show();
            $('#tbVend').show();
            break;
        case 'JOBVOLUME':
        case 'JOBSTATUS':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').show();
            $('#tbJob').hide(); //hide
            $('#tbVend').hide(); //hide
            break;
        case 'EXPDAILY':
        case 'EXPDETAIL':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').hide(); //hide
            $('#tbStatus').show();
            $('#tbJob').show();
            $('#tbVend').show();
            break;
        case 'STATEMENT':
        case 'BOOKBAL':
        case 'TRIALBAL':
        case 'BALANCS':
        case 'PROFITLOSS':
        case 'CASHFLOW':
        case 'CASHBAL':
            $('#tbDate').show();
            $('#tbEmp').hide(); //hide
            $('#tbCust').hide();  //hide
            $('#tbStatus').hide(); //hide
            $('#tbJob').show(); //hide
            $('#tbVend').hide(); //hide
            break;
        case 'JOURNAL':
        case 'ADVSUMMARY':
            $('#tbDate').show();
            $('#tbEmp').hide(); //hide
            $('#tbCust').hide();  //hide
            $('#tbStatus').hide(); //hide
            $('#tbJob').hide(); //hide
            $('#tbVend').hide(); //hide
            break;
        case 'VATSALES':
        case 'WHTAX':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').hide(); //hide
            $('#tbJob').show();
            $('#tbVend').hide();
            break;
        case 'VATBUY':
        case 'ACCEXP':
        case 'APBAL':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').hide(); //hide
            $('#tbStatus').hide(); //hide
            $('#tbJob').hide(); //hide
            $('#tbVend').show();
            break;
        case 'ACCINC':
        case 'ARBAL':
        case 'CNDN':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').hide(); //hide
            $('#tbJob').hide(); //hide
            $('#tbVend').hide(); //hide
            break;
        case 'ADVDETAIL':
        case 'CLRDETAIL':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').show();
            $('#tbJob').show();
            $('#tbVend').show();
            $('#tbCode').show();
            break;
        case 'INVDETAIL':
        case 'RCPDETAIL':
            $('#tbDate').show();
            $('#tbEmp').show();
            $('#tbCust').show();
            $('#tbStatus').hide(); //hide
            $('#tbJob').hide();  //hide
            $('#tbVend').hide();  //hide
            $('#tbCode').show();
            break;
    }
}
function IsNumberColumn(cname) {
    let colname = ',InvTotal,InvProductQty,InvCurRate,DutyAmount,TotalGW,Commission,TotalNW,TotalQty,AdvNet,AdvPayAmount,ClrNet,UsedAmount,AdvBalance,TotalNet,PaidAmount,UnPaidAmount,TotalAdv,TotalCharge,TotalVAT,TotalVat,Total50Tavi,Tax3Tres,TaxNot3Tres,TotalJob,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ',TotalWHT,TotalNet,TotalReceived,TotalCredit,TotalBal,LimitBalance,SumCashOnhand,SumChqClear,SumChqOnhand,SumCreditable,SumAdvance,SumCharge,SumCost,Profit,ExpenseAmt,ExpenseVAT,TotalChargeVAT,TotalChargeNonVAT,AmtAdvance,AmtChargeNonVAT,AmtChargeVAT,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ',TotalExpClear,TotalExpWaitBill,TotalCostWaitBill,TotalCost,TotalProfit,SumWhTax,TotalAdvance,TotalPrepaid,TotalBalance,AmountRemain,ChqAmount,Amt50Tavi,AmtNet,ServiceAmount,TranAmount,TaxTransport,TaxService,PayTax,CashAmount,AmountUsed,AmtCostSlip,AmtCostNoSlip,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ',TotalAdvBilled,TotalCostBilled,TotalChargeBilled,Amt,AmtVAT,AmtVat,AmtCredit,CreditNet,AmtWH,AmtTotal,AdvTotal,ClrTotal,TotalPayback,TotalReturn,Amt, Tax50Tavi, TotalInv, ReceivedNet, Charge50Tavi, Total, SumReceipt, TotalComm, VAT, WHT, CostAmount, ChargeAmount, ';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",PENDING CONFIRM,WAIT FOR OPERATION,WAIT FOR CLEAR,WORKING FINISHED,EXPENSES CLEARED,BILLING INCOMPLETE,BILLING COMPLETED,JOB COMPLETED,HOLD FOR CHECKING,JOB CANCELLED,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",JOB CONFIRMED,JOB IN PROCESS,CLEARANCE COMPLETED,READY FOR BILLING,PARTIAL BILLING,PAYMENT COMPLETED,CANCELLED,BILLED,UNBILLED,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Invoice To Customer-Advance,Invoice To Customer-Service,Payment To Vender-Advance,Payment To Vender-Cost,Payment To Vender-Deposit,Amount,Prepaid,Total Amount,CN,DN Amount,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Customer Billed-Advance,Customer Billed-Service,Customer Unbilled-Advance,Customer Unbilled-Service,Paid,Unpaid,Invoice Billed,Invoice Unbilled,Payment Received,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Exp-Billed,Exp-Unbilled,Exp-Paid,Advance Amount,Actual Spending,Billable Amount,Billing With Tax,Billing Outstanding,Net Avaiable Balance,Billed Advance,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Advanced Credit Limit,Advance Requested,Advance Paid,Paid+Cleared Advance,Billed To Customer,Unbilled Advance,Advance Cost,Advance Amount,Customer Payment,"
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Container Deposit,Addition Expenses,Deposit Return,Clear Amount,Clear VAT,Clear WHT,Clear Net,Adjust Amount,SVC Amount,VAT Amount,WHT Amount,TotalChargeWaitBill,TotalAdvWaitBill,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Chq Amt,Cash Amt,WHD Tax,Total Amt,Transport,Service,Vat,Advance,Amt.Baht,Revenue,Cost,Total Job,Profit,TotalEarnest,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    return false;
}
function IsSummaryColumn(cname) {
    let colname = ',DutyAmount,TotalGW,Commission,TotalNW,AdvNet,AdvPayAmount,ClrNet,UsedAmount,AdvBalance,TotalNet,PaidAmount,UnPaidAmount,TotalAdv,TotalCharge,TotalVAT,TotalVat,Total50Tavi,TotalWHT,TotalNet,TotalReceived,TotalCredit,TotalBal,Amount,Prepaid,Total Amount,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ',LimitBalance,SumCashOnhand,SumChqClear,SumChqOnhand,SumCreditable,SumAdvance,SumCharge,SumCost,Profit,ExpenseAmt,ExpenseVAT,TotalChargeVAT,TotalChargeNonVAT,AmtAdvance,AmtChargeNonVAT,AmtChargeVAT,Amt,AmtVAT,AmtVat,AmtCredit,VAT,WHT,Payment Received,CN,DN Amount,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ',CreditNet,AmtWH,AmtTotal,Tax50Tavi,TotalInv,ReceivedNet,Charge50Tavi,Total,SumReceipt,TotalComm,AdvTotal,ClrTotal,TotalPayback,TotalReturn,ReceiveAmt,PayTax,Tax3Tres,TaxNot3Tres,CashAmount,AmountUsed,TotalJob,TotalAdvWaitBill,TotalCostWaitBill,TotalChargeWaitBill,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ',TotalAdvBilled,TotalCostBilled,TotalChargeBilled,TotalExpClear,TotalExpWaitBill,TotalCostWaitBill,TotalCost,TotalProfit,SumWhTax,TotalAdvance,TotalPrepaid,TotalBalance,AmountRemain,ChqAmount,Amt50Tavi,AmtNet,ServiceAmount,TranAmount,TaxTransport,TaxService,';
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",PENDING CONFIRM,WAIT FOR OPERATION,WAIT FOR CLEAR,WORKING FINISHED,EXPENSES CLEARED,BILLING INCOMPLETE,BILLING COMPLETED,JOB COMPLETED,HOLD FOR CHECKING,JOB CANCELLED,TotalAdvWaitBill,TotalChargeWaitBill,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",JOB CONFIRMED,JOB IN PROCESS,CLEARANCE COMPLETED,READY FOR BILLING,PARTIAL BILLING,PAYMENT COMPLETED,CANCELLED,UNBILLED,BILLED,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Invoice To Customer-Advance,Invoice To Customer-Service,Payment To Vender-Advance,Payment To Vender-Cost,Payment To Vender-Deposit,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Customer Billed-Advance,Customer Billed-Service,Customer Unbilled-Advance,Customer Unbilled-Service,Paid,Unpaid,Invoice Billed,Invoice Unbilled,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Exp-Billed,Exp-Unbilled,Exp-Paid,Advance Amount,Actual Spending,Billable Amount,Billing With Tax,Billing Outstanding,Billed Advance,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Net Avaiable Balance,Advance Requested,Advance Paid,Paid+Cleared Advance,Billed To Customer,Unbilled Advance,Advance Cost,Advance Amount,Customer Payment,"
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Container Deposit,Addition Expenses,Deposit Return,Clear Amount,Clear VAT,Clear WHT,Clear Net,Adjust Amount,SVC Amount,VAT Amount,WHT Amount,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    colname = ",Chq Amt,Cash Amt,WHD Tax,Total Amt,Transport,Service,Vat,Advance,Amt.Baht,Revenue,Cost,Total Job,Profit,TotalEarnest,AmtCostSlip,AmtCostNoSlip,";
    if (colname.indexOf(',' + cname + ',') >= 0) {
        return true;
    }
    return false;
}
function FormatValue(c, val) {
    if (c.indexOf('Date') >= 0) {
        return ShowDate(val);
    } else {
        if (IsNumberColumn(c)) {
            return ShowNumber(val, 2);
        } else {
            return val;
        }
    }
}
function GetColumnHeader(id, langid) {
    let lang = {
        JNo: 'Job#|เลขงาน',
        DocDate: 'Open Date|วันที่เปิด',
        BranchCode: 'Branch|สาขา',
        ConfirmDate: 'Confirm Date|วันที่ยืนยัน',
        CustCode: 'Customer|ลูกค้า',
        CustContactName: 'Contact|ผู้ติดต่อ',
        QNo: 'Quotation#|ใบเสนอราคา',
        ManagerCode: 'Sales|ขายโดย',
        CSCode: 'CS|พนักงาน',
        EmpCode: 'CS|พนักงาน',
        Description: 'Description|รายละเอียด',
        TRemark: 'Remark|หมายเหตุ',
        JobStatusName: 'Status|สถานะ',
        JobStatus: 'Status|สถานะ',
        JobType: 'Type|ประเภท',
        JobTypeName: 'Type|ประเภท',
        ShipBy: 'ShipBy|ลักษณะ',
        ShipByName: 'ShipBy|ลักษณะ',
        InvNo: 'Invoice#|อินวอย',
        InvDate: 'Inv.Date|วันที่ออก',
        InvTotal: 'Total Inv.|ยอดอินวอย',
        InvProduct: 'Product|สินค้า',
        InvCountry: 'Origin Cty|ต้นทาง',
        InvFCountry: 'Dest Cty|ปลายทาง',
        InvInterPort: 'Inter Port|Port ตปท',
        InvProductQty: 'Qty|จำนวน',
        InvProductUnit: 'Unit|หน่วย',
        InvCurUnit: 'Currency|สกุลเงิน',
        InvCurRate: 'Rate|แลกเปลี่ยน',
        ImExDate: 'EDI Date|วันที่ทำEDI',
        BLNo: 'BL/AWB Status|สถานะ BL/AWB',
        BookingNo: 'Booking No|ใบจองพาหนะ',
        ClearPort: 'Clear Port|สถานที่ตรวจปล่อย',
        ClearPortNo: 'Port#|จุดตรวจปล่อย',
        ClearDate: 'Customs Date|วันที่ผ่านพิธีการ',
        LoadDate: 'Load Date|วันที่ลงของ',
        ForwarderCode: 'Agent|ตัวแทนเรือ/สายการบิน',
        AgentCode: 'Transport|ขนส่ง',
        VesselName: 'Vessel|ชื่อเรือ/เที่ยวบิน',
        ETDDate: 'ETD|วันออกจากท่า',
        ETADate: 'ETA|วันเทียบท่า',
        CancelReson: 'Cancel Reason|เหตุผลที่ยกเลิก',
        CancelDate: 'Cancel Date|วันที่ยกเลิก',
        CancelProve: 'Cancel By|ผู้ยกเลิก',
        CloseJobDate: 'Close Date|วันที่ปิดงาน',
        CloseJobBy: 'Close By|ผู้ปิดงาน',
        DeclareType: 'Decl.Type|ประเภทใบขน',
        DeclareNumber: 'Declare#|เลขที่ใบขน',
        EstDeliverDate: 'Delivery Date|วันที่ส่งของ',
        TotalContainer: 'Total CTN|จำนวนตู้',
        DutyDate: 'Shipment Date|วันที่ตรวจปล่อย',
        DutyAmount: 'Duty Amt|ภาษีอากร',
        ConfirmChqDate: 'Confirm Date|วันที่ยืนยัน',
        ShippingEmp: 'Shipping|ชิปปิ้ง',
        ShippingCmd: 'Caution|ข้อพึงระวัง',
        TotalGW: 'Gross WT|น้ำหนักสุทธิ',
        GWUnit: 'Unit|หน่วย',
        ReadyToClearDate: 'Ready Date|วันที่พร้อมตรวจปล่อย',
        Commission: 'Commission|คอมมิชชั่น',
        ProjectName: 'Project|ชื่อโครงการ',
        MVesselName: 'Mother Vsl|เรือแม่/เที่ยวบินขนถ่าย',
        TotalNW: 'Net WT|น้ำหนักสุทธิ',
        Measurement: 'M3|ปริมาตร',
        CustRefNO: 'RefNo|เลขที่อ้างอิง',
        TotalQty: 'Total Qty|จำนวนรวม',
        HAWB: 'House AWB/BL|House AWB/BL',
        MAWB: 'Master AWB/BL|Master AWB/BL',
        consigneecode: 'Consignee|ผู้ซื้อขาย',
        DeliveryNo: 'Delivery|ใบส่งของ',
        DeliveryTo: 'Delivery To|ส่งถึง',
        DeliveryAddr: 'Delivery Addr|ที่อยู่',
        PaymentDate: 'Payment Date|วันที่จ่าย',
        AdvNo: 'Advance No|เลขที่ใบเบิก',
        JobNo: 'Job No|หมายเลขงาน',
        ForJNo: 'Job No|หมายเลขงาน',
        ReqBy: 'Request By|ผู้ขอ',
        SDescription: 'Expense|ชื่อค่าใช้จ่าย',
        VenderCode: 'Vender|รหัสผู้ให้บริการ',
        AdvNet: 'Net|ยอดเบิก',
        AdvTotal: 'Advance|ยอดเบิก',
        AdvPayAmount: 'Net|ยอดเบิก',
        ClrNet: 'Used|ยอดปิด',
        UsedAmount: 'Used|ยอดใช้ไป',
        AdvBalance: 'Balance|รอเคลียร์',
        PRVoucher: 'Voucher|เลขที่ใบสำคัญ',
        VoucherDate: 'Date|วันที่ออก',
        ChqNo: 'Chq No|เลขที่เช็ค',
        ChqDate: 'Chq Date|วันที่เช็ค',
        TotalNet: 'Net|ยอดสุทธิ',
        ControlNo: 'Control No|เลขที่ลงบัญชี',
        DocNo: 'Doc No|เลขที่เอกสาร',
        TName: 'Name|ชื่อภาษาไทย',
        PoNo: 'PO No|ใบสั่งซื้อ',
        RefNo: 'Ref No|เลขที่อ้างอิง',
        PaidAmount: 'Paid|ยอดที่จ่าย',
        UnPaidAmount: 'UnPaid|ยอดที่ค้าง',
        PaymentRef: 'Paid.Ref|เลขที่ชำระ',
        TotalAdv: 'Advance|ทดรองจ่าย',
        TotalAdvance: 'Advance|ทดรองจ่าย',
        TotalCharge: 'Service|ค่าบริการ',
        TotalVat: 'VAT|VAT',
        TotalVAT: 'VAT|VAT',
        Total50Tavi: 'W-Tax|หัก ณ ที่จ่าย',
        TotalWHT: 'W-Tax|หัก ณ ที่จ่าย',
        SumWhTax: 'WH-Tax|หัก ณ ที่จ่าย',
        TotalNet: 'Net|สุทธิ',
        TotalReceived: 'Received|รับชำระแล้ว',
        TotalCredit: 'Credit|ลดหนี้/ปรับปรุง',
        TotalBal: 'Balance|คงเหลือ',
        BookCode: 'Book No|สมุดบัญชี',
        LimitBalance: 'Limit|ขั้นต่ำ',
        SumCashOnhand: 'Cash Onhand|เงินสดในมือ',
        SumChqClear: 'Chq Clear|เช็คเคลียร์',
        SumChqOnhand: 'Chq Onhand|เช็คในมือ',
        SumCreditable: 'Adjust|ปรับปรุง',
        InvoiceNo: 'Inv No|ใบแจ้งหนี้',
        SumAdvance: 'Advance|ทดรองจ่าย',
        SumCharge: 'Charge|ค่าบริการ',
        SumCost: 'Cost|ต้นทุน',
        Profit: 'Profit|กำไรชั้นต้น',
        ExpenseDate: 'Exp.Date|วันที่จ่าย',
        SlipNo: 'Slip No|เลขที่ใบเสร็จ',
        SlipNO: 'Slip No|เลขที่ใบเสร็จ',
        VenderName: 'Name|ชื่อ',
        TaxNumber: 'Tax No|เลขผู้เสียภาษี',
        Branch: 'Branch|สาขา',
        ExpenseAmt: 'Amt|ยอดเงิน',
        ExpenseVAT: 'VAT|VAt',
        ReceiptDate: 'Date|วันที่ใบกำกับ',
        ReceiptNo: 'Receipt No|เลชที่ใบกำกับ',
        ServiceType: 'Description|รายละเอียด',
        TotalChargeVAT: 'VAT Base|ฐานภาษีมูลค่าเพิ่ม',
        TotalChargeNonVAT: 'VAT Except|ยกเว้นภาษี',
        Date50Tavi: 'Date|วันที่เอกสาร',
        NO50Tavi: 'Doc No|เลขที่เอกสาร',
        VenTaxNumber: 'Tax.Issue|เลขผู้เสียภาษีผู้หัก',
        VenTaxBranch: 'Tax.Branch|สาขาผู้หัก',
        FormTypeName: 'Tax.Form|แบบภาษี',
        CustTaxBranch: 'Branch|สาขาผู้ถูกหัก',
        CustTaxNumber: 'Tax.Receive|เลขผู้เสียภาษีผู้ถูกหัก',
        CustName: 'Name|ชื่อผู้ถูกหัก',
        TaxBy: 'Tax By|ผู้มีหน้าที่หัก ณ ที่จ่าย',
        TaxYear: 'Tax Year|ปีภาษี',
        TaxMonth: 'Tax Mo|เดือน',
        ServiceAmount: 'Service|ค่าบริการ',
        TranAmount: 'Transport|ค่าขนส่ง',
        TaxService: 'Tax (Serv)|ภาษี(ค่าบริการ)',
        TaxTransport: 'Tax (Tran)|ภาษี(ค่าขนส่ง)',
        TaxType: 'Tax-type|ประเภท',
        TaxForm: 'Tax-Form|แบบยื่น',
        Tax3Tres: '3-Tres|3 เตรส',
        TaxNot3Tres: 'No 3-Tres|ไม่ใช่ 3 เตรส',
        Tax50TaviRate: 'Rate|อัตราหัก ณ ที่จ่าย',
        BillAcceptNo: 'Bill No|ใบวางบิล',
        BillDate: 'Date|วันที่ออก',
        AmtAdvance: 'Advance|ทดรองจ่าย',
        AmtChargeNonVAT: 'VAT Except|ยกเว้นภาษี',
        AmtChargeVAT: 'VAT Base|ฐานภาษี',
        Amt: 'Amt|ยอดเงิน',
        AmtVAT: 'VAT|VAT',
        AmtVat: 'VAT|VAT',
        AmtCredit: 'Credit|ชำระก่อน',
        CreditNet: 'Adjust|ปรับปรุง',
        AmtWH: 'W/H-Tax|W/H-Tax',
        Amt50Tavi: 'W/H-Tax|W/H-Tax',
        AmtTotal: 'Net|สุทธิ',
        AmtNet: 'Net|สุทธิ',
        ClrTotal: 'Used|ยอดใช้ไป',
        ClrNo: 'Clr.No|ใบปิดค่าใช้จ่าย',
        ClrDate: 'Date|วันที่ปิด',
        AdvNO: 'Adv.No|ใบเบิก',
        Tax50Tavi: 'W/H-Tax|W/H-Tax',
        TotalInv: 'Inv.Total|ยอดรวม',
        TotalExpClear: 'Expenses|รวมค่าใช้จ่าย',
        TotalExpWaitBill: 'Exp Pending|คชจรอวางบิล',
        TotalCostWaitBill: 'Cost Pending|ต้นทุนรอวางบิล',
        TotalEarnest: 'Container Earnest|มัดจำตู้',
        TotalCost: 'Cost|ต้นทุนรวม',
        TotalPrepaid: 'Prepaid|รับล่วงหน้า',
        TotalBalance: 'Balance|ค้างชำระ',
        TotalProfit: 'Profit|กำไรขั้นต้น',
        TotalPayback: 'Payback|ยอดจ่ายคืน',
        TotalReturn: 'Return|ยอดรับคืน',
        ReceiveRef: 'Ref#|อ้างอิงรับเคลียร์',
        ReceivedNet: 'Received|ชำระแล้ว',
        ReceiveAmt: 'Cleared|ชำระแล้ว',
        Charge50Tavi: 'W/H-Tax|W/H-Tax',
        RecvBank: 'Bank|ธนาคาร',
        Total: 'Total|ยอดรวม',
        DRefNo: 'Ref No|อ้างอิงเอกสาร',
        DocUsed: 'Document|เอกสารอ้างอิง',
        ChqStatus: 'CHK|สถานะ',
        SumReceipt: 'Receive|ยอดใบเสร็จ',
        TotalComm: 'Commission|ค่าคอม',
        ChqAmount: 'Chq.Amt|ยอดเช็ค',
        AmountUsed: 'Used.Amt|ยอดใช้ไป',
        AmountRemain: 'Remain|ยอดคงเหลือ',
        AmtCostSlip: 'Cost Slip|ต้นทุนมีใบเสร็จ',
        AmtCostNoSlip: 'Cost No-Slip|ต้นทุนไม่มีใบเสร็จ',
        'Invoice No': 'APLL Invoice#|ใบแจ้งหนี้',
        'Invoice Date': 'APLL Invoice Date|วันที่ใบแจ้งหนี้',
        'Receipt No': 'APLL Receipt#|ใบเสร็จรับเงิน',
        'Receipt Date': 'APLL Receipt Date|วันที่ใบเสร็จ',
        'Inv.Create Date': 'APLL Inv.Create Date|วันที่ใบแจ้งหนี้'
    }
    let str = id;
    if (lang[id] !== undefined) {
        switch (langid) {
            case 'EN':
                str = lang[id].split('|')[0].trim();
                break;
            case 'TH':
                str = lang[id].split('|')[1].trim();
                break;
        }
    }
    return str;
}
function GetGroupCaption(src, fld, val) {
    let retstr = val;
    //if (src.length > 0) {
    switch (fld) {
        case 'PRType':
            if (src.length > 0) {
                let status = src[0];
                retstr = status[val];
            }
            break;
        case 'acType':
            if (src.length > 0) {
                let status = src[0];
                retstr = status[val];
            }
            break;
        case "JobStatus":
            if (src.length > 0) {
                let status = src[0].filter(function (data) {
                    return val == data.ConfigKey;
                });
                if (status.length > 0) {
                    retstr = status[0].ConfigValue;
                }
            }
            break;
        case "CustCode":
            if (src.length > 0) {
                let cust = src[0].filter(function (data) {
                    return val == data.CustCode;
                });
                if (cust.length > 0) {
                    retstr = cust[0].CustCode + ' / ' + cust[0].NameThai;
                }
            }
            break;
        case "CSCode":
        case "EmpCode":
        case "ShippingEmp":
        case "ReqBy":
            if (src.length > 0) {
                let emp = src[0].filter(function (data) {
                    return val == data.UserID;
                });
                if (emp.length > 0) {
                    retstr = emp[0].UserID + ' / ' + emp[0].TName;
                }
            }
            break;
        case "ClearPort":
            if (src.length > 0) {
                let ports = src[0].filter(function (data) {
                    return val == data.AreaCode;
                });
                if (ports.length > 0) {
                    retstr = ports[0].AreaCode + ' / ' + ports[0].AreaName;
                }
            }
            break;
    }
    //}
    return retstr;
}
function LoadReport(path, reportID, obj, lang) {
    let str = JSON.stringify(obj);
    let urlReport = '';
    if (obj.ReportType == 'STD' || obj.ReportType == 'FIX') {
        urlReport = path + 'Report/GetReport';
    } else {
        urlReport = path + 'Report/GetReportByConfig';
    }
    $.ajax({
        url: urlReport,
        type: "POST",
        contentType: "application/json",
        data: str,
        success: function (response) {
            let res = JSON.parse(response);
            if (res.msg !== "OK") {
                //alert(r.msg);
                return;
            }
            if (res.result.length > 0) {
                var tb = res.result;
                let groupField = '';
                let groupVal = null;
                let colCount = 0;
                let sumGroup = [];
                let sumTotal = [];
                let lengthFld = '';
                let colWidth = [];
                let textFields = '';
                if (res.colwidth !== '') {
                    lengthFld = res.colwidth;
                }
                if (lengthFld.indexOf(',') > 0) {
                    colWidth = lengthFld.split(',');
                }
                if (res.text_field !== '') {
                    textFields = res.text_field;
                }
                if (res.group !== '') {
                    groupField = res.group;
                }

                let html = '<thead><tr><th style="border:1px solid black;text-align:left;background-color:lightgrey;width:2%">#</th>';
                $.each(tb[0], function (key, value) {
                    if (key !== groupField) {
                        html += '<th style="border:1px solid black;text-align:left;background-color:lightgrey;';
                        if (colWidth.length > 0) {
                            if (colWidth.length > colCount) {
                                html += 'width:' + colWidth[colCount] + '%';
                            }
                        }
                        html += '"><b>' + GetColumnHeader(key, lang) + '</b></th>';
                        if (textFields.indexOf(key) >= 0 || key.indexOf('CustCode') >= 0) {
                            sumGroup.push({ isSummary: false, value: 0 });
                        } else {
                            if (IsSummaryColumn(key) == true) {
                                sumGroup.push({ isSummary: true, value: 0 });
                            } else {
                                sumGroup.push({ isSummary: CheckAllIsNumber(tb, key), value: 0 });
                            }
                        }
                        sumTotal.push(0);
                        colCount++;
                    }
                });

                html += '</tr></thead><tbody>';

                let groupCount = 0;
                let groupCaption = GetColumnHeader(groupField, lang);
                let row = 0;
                for (let r of tb) {
                    html += '<tr>';
                    if (groupField !== '') {
                        if (FormatValue(groupField, r[groupField]) !== groupVal) {
                            //Show Summary
                            if (groupCount > 0) {
                                html += '<td colspan="2" style="background-color:lightblue;border:1px solid black;text-align:left;"><u><b>SUB TOTAL</b></u></td>';
                                for (let i = 1; i < colCount; i++) {
                                    if (sumGroup[i].isSummary == true) {
                                        html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"><u><b>' + ShowNumber(sumGroup[i].value, 2) + '</b></u></td>';
                                    } else {
                                        html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"></td>';
                                    }
                                    sumGroup[i].value = 0;
                                }
                                html += '</tr><tr>';
                                groupCount = 0;
                            }
                            groupVal = FormatValue(groupField, r[groupField]);
                            groupCount++;

                            html += '<td colspan="' + (colCount + 1) + '" style="background-color:lightyellow;border:1px solid black;text-align:left;">' + groupCaption + ' <b>' + GetGroupCaption(res.groupdata, groupField, groupVal) + '<b/></td>';
                            html += '</tr><tr>';
                        } else {
                            groupCount++;
                        }
                    }
                    row++;
                    html += '<td style="border:1px solid black;text-align:center;">' + row + '</td>';
                    let col = 0;
                    for (let c in r) {
                        if (c !== groupField) {
                            if (c.indexOf('Date') >= 0) {
                                html += '<td style="border:1px solid black;text-align:left;">' + ShowDate(r[c]) + '</td>';
                            } else {
                                if (r[c] !== null) {
                                    if (sumGroup[col].isSummary == true) {
                                        sumGroup[col].value += Number(r[c]);
                                        sumTotal[col] += Number(r[c]);
                                        html += '<td style="border:1px solid black;text-align:right;">' + ShowNumber(r[c], 2) + '</td>';
                                    } else {
                                        html += '<td style="border:1px solid black;text-align:left;">' + r[c] + '</td>';
                                    }
                                } else {
                                    html += '<td style="border:1px solid black;text-align:left;"></td>';
                                }
                            }
                            col++;
                        }
                    }
                    html += '</tr>';
                }
                //Last Total
                if (groupCount > 0) {
                    html += '<td colspan="2" style="background-color:lightblue;border:1px solid black;text-align:left;"><u><b>SUB TOTAL</b></u></td>';
                    for (let i = 1; i < colCount; i++) {
                        if (sumGroup[i].isSummary == true) {
                            html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"><u><b>' + ShowNumber(sumGroup[i].value, 2) + '</b></u></td>';
                        } else {
                            html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"></td>';
                        }
                    }
                    html += '</tr>';
                    groupCount = 0;
                }
                html += '</tbody>'
                //Grand Total
                html += '<tfoot><tr style="font-weight:bold;background-color:lightgreen;"><td colspan="2" style="border:1px solid black;text-align:left;"><b>GRAND TOTAL<b/></td>';
                for (let i = 1; i < colCount; i++) {
                    if (sumGroup[i].isSummary == true) {
                        html += '<td style="border:1px solid black;text-align:right;"><b>' + ShowNumber(sumTotal[i], 2) + '</b></td>';
                    } else {
                        html += '<td style="border:1px solid black;text-align:right;"></td>';
                    }
                }
                html += '</tr>';

                html += '</tfoot>';
                //ShowMessage(html);
                $('#tbResult').html(html);
            }
        }
    });
}
function LoadReportNoTotal(path, reportID, obj, lang) {
    let str = JSON.stringify(obj);
    let urlReport = '';
    if (obj.ReportType == 'STD' || obj.ReportType == 'FIX') {
        urlReport = path + 'Report/GetReport';
    } else {
        urlReport = path + 'Report/GetReportByConfig';
    }

    $.ajax({
        url: urlReport,
        type: "POST",
        contentType: "application/json",
        data: str,
        success: function (response) {
            let res = JSON.parse(response);
            if (res.msg !== "OK") {
                //alert(r.msg);
                return;
            }
            if (res.result.length > 0) {
                var tb = res.result;
                let groupField = '';
                let groupVal = null;
                let colCount = 0;
                let sumGroup = [];
                let sumTotal = [];
                let sumFields = '';
                if (res.summary !== '') {
                    sumFields = res.summary;
                }
                if (res.group !== '') {
                    groupField = res.group;
                }

                let html = '<thead><tr>';
                $.each(tb[0], function (key, value) {
                    if (key !== groupField) {
                        //html += '<th style="border:1px solid black;text-align:left;">' + key + '</th>';
                        html += '<th style="border:1px solid black;text-align:left;background-color:lightgrey;"><b>' + GetColumnHeader(key, lang) + '</b></th>';
                        if (sumFields.indexOf(key) >= 0 && CheckAllIsNumber(tb, key)) {
                            sumGroup.push({ isSummary: true, value: 0 });
                        } else {
                            sumGroup.push({ isSummary: false, value: 0 });
                        }
                        sumTotal.push(0);
                        colCount++;
                    }
                });

                html += '</tr></thead><tbody>';

                let groupCount = 0;
                let groupCaption = GetColumnHeader(groupField, lang);
                let row = 0;
                for (let r of tb) {
                    html += '<tr>';
                    if (groupField !== '') {
                        if (FormatValue(groupField, r[groupField]) !== groupVal) {
                            //Show Summary
                            if (groupCount > 0) {
                                html += '<td colspan="2" style="background-color:lightblue;border:1px solid black;text-align:left;"><u><b>SUB TOTAL</b></u></td>';
                                for (let i = 1; i < colCount; i++) {
                                    if (sumGroup[i].isSummary == true) {
                                        html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"><u><b>' + ShowNumber(sumGroup[i].value, 2) + '</b></u></td>';
                                    } else {
                                        html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"></td>';
                                    }
                                    sumGroup[i].value = 0;
                                }
                                html += '</tr><tr>';
                                groupCount = 0;
                            }
                            groupVal = FormatValue(groupField, r[groupField]);
                            groupCount++;

                            html += '<td colspan="' + (colCount) + '" style="background-color:lightyellow;border:1px solid black;text-align:left;">' + groupCaption + ' <b>' + GetGroupCaption(res.groupdata, groupField, groupVal) + '<b/></td>';
                            html += '</tr><tr>';
                        } else {
                            groupCount++;
                        }
                    }
                    row++;
                    let col = 0;
                    for (let c in r) {
                        if (c !== groupField) {
                            if (c.indexOf('Date') >= 0) {
                                html += '<td style="border:1px solid black;text-align:left;">' + ShowDate(r[c]) + '</td>';
                            } else {
                                if (r[c] !== null) {
                                    if (sumGroup[col].isSummary == true) {
                                        sumGroup[col].value += Number(r[c]);
                                        sumTotal[col] += Number(r[c]);
                                        html += '<td style="border:1px solid black;text-align:right;">' + ShowNumber(r[c], 2) + '</td>';
                                    } else {
                                        html += '<td style="border:1px solid black;text-align:left;">' + r[c] + '</td>';
                                    }
                                } else {
                                    html += '<td style="border:1px solid black;text-align:left;"></td>';
                                }
                            }
                            col++;
                        }
                    }
                    html += '</tr>';
                }
                //Last Total
                if (groupCount > 0) {
                    html += '<td style="background-color:lightblue;border:1px solid black;text-align:left;"><u><b>SUB TOTAL</b></u></td>';
                    for (let i = 1; i < colCount; i++) {
                        if (sumGroup[i].isSummary == true) {
                            html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"><u><b>' + ShowNumber(sumGroup[i].value, 2) + '</b></u></td>';
                        } else {
                            html += '<td style="background-color:lightblue;border:1px solid black;text-align:right;"></td>';
                        }
                    }
                    html += '</tr>';
                    groupCount = 0;
                }
                html += '</tbody>'
                //ShowMessage(html);
                $('#tbResult').html(html);
            }
        }
    });
}
function CheckAllIsNumber(arr, colName) {
    let tb = JSON.parse(JSON.stringify(arr));
    sortData(tb, colName, 'desc');
    try {
        if (tb[0][colName] !== null) {
            let dbl = Number(tb[0][colName]);
            if (isNaN(dbl) == false) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    } catch {
        return false;
    }
}
