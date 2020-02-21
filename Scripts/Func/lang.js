let mainLanguage = 'EN';
function GetReportLists() {
    return [
        { "ReportGroup": "CS", "ReportCode": "JOBDAILY", "ReportNameEN": "Job List Daily", "ReportNameTH": "รายงานการตรวจปล่อยตามวันที่" },
        { "ReportGroup": "CS", "ReportCode": "JOBCS", "ReportNameEN": "Job List By CS", "ReportNameTH": "รายงานการตรวจปล่อยตามพนักงานบริการลูกค้า" },
        { "ReportGroup": "CS", "ReportCode": "JOBSHP", "ReportNameEN": "Job List By Shipping", "ReportNameTH": "รายงานการตรวจปล่อยตามชิปปิ้ง" },
        { "ReportGroup": "CS", "ReportCode": "JOBTYPE", "ReportNameEN": "Job List By Type", "ReportNameTH": "รายงานการตรวจปล่อยตามประเภทงาน" },
        { "ReportGroup": "CS", "ReportCode": "JOBSHIPBY", "ReportNameEN": "Job List By Transport", "ReportNameTH": "รายงานการตรวจปล่อยตามลักษณะงานขนส่ง" },
        { "ReportGroup": "CS", "ReportCode": "JOBCUST", "ReportNameEN": "Job List By Customer", "ReportNameTH": "รายงานการตรวจปล่อยตามลูกค้า" },
        { "ReportGroup": "CS", "ReportCode": "JOBPORT", "ReportNameEN": "Job List By Port", "ReportNameTH": "รายงานการตรวจปล่อยตามสถานที่ตรวจปล่อย" },
        { "ReportGroup": "CS", "ReportCode": "JOBADV", "ReportNameEN": "Advance By Emp", "ReportNameTH": "รายงานการเบิกเงินตามพนักงาน" },
        { "ReportGroup": "SALES", "ReportCode": "JOBVOLUME", "ReportNameEN": "Job Volume By Cust", "ReportNameTH": "รายงานสรุปงานตามลูกค้า" },
        { "ReportGroup": "SALES", "ReportCode": "JOBSTATUS", "ReportNameEN": "Job Volume By Status", "ReportNameTH": "รายงานสรุปงานตามสถานะ" },
        { "ReportGroup": "SALES", "ReportCode": "JOBSALES", "ReportNameEN": "Job Sales By Emp", "ReportNameTH": "รายงานสรุปยอดขายตามพนักงาน" },
        { "ReportGroup": "SALES", "ReportCode": "JOBCOMM", "ReportNameEN": "Job Commission By Emp", "ReportNameTH": "รายงานสรุปค่าคอมมิชชั่น" },
        { "ReportGroup": "FIN", "ReportCode": "ADVSUMMARY", "ReportNameEN": "Advance Summary", "ReportNameTH": "รายงานสรุปใบเบิกค่าใช้จ่าย" },
        { "ReportGroup": "FIN", "ReportCode": "STATEMENT", "ReportNameEN": "Bank Statement", "ReportNameTH": "รายงานการรับจ่ายเงินตามสมุดบัญชี" },
        { "ReportGroup": "FIN", "ReportCode": "ADVDAILY", "ReportNameEN": "Advance Payment", "ReportNameTH": "รายงานการจ่ายเงินเบิกล่วงหน้า" },
        { "ReportGroup": "FIN", "ReportCode": "EXPDAILY", "ReportNameEN": "Expense Payment", "ReportNameTH": "รายงานการจ่ายเงินทดรองจ่าย" },
        { "ReportGroup": "FIN", "ReportCode": "RCPDAILY", "ReportNameEN": "Receipt Daily", "ReportNameTH": "รายงานใบเสร็จรับเงินประจำวัน" },
        { "ReportGroup": "FIN", "ReportCode": "TAXDAILY", "ReportNameEN": "Tax-invoice Daily", "ReportNameTH": "รายงานใบกำกับภาษีประจำวัน" },
        { "ReportGroup": "FIN", "ReportCode": "CASHDAILY", "ReportNameEN": "Transaction Daily", "ReportNameTH": "รายงานการรับจ่ายเงินประจำวัน" },
        { "ReportGroup": "BILL", "ReportCode": "CLRDAILY", "ReportNameEN": "Clearing Daily", "ReportNameTH": "รายงานการปิดค่าใช้จ่ายประจำวัน" },
        { "ReportGroup": "BILL", "ReportCode": "INVDAILY", "ReportNameEN": "Invoice Daily", "ReportNameTH": "รายงานใบแจ้งหนี้ประจำวัน" },
        { "ReportGroup": "BILL", "ReportCode": "BILLDAILY", "ReportNameEN": "Billing Daily", "ReportNameTH": "รายงานใบวางบิลประจำวัน" },
        { "ReportGroup": "ACC", "ReportCode": "JOBCOST", "ReportNameEN": "Job Costing And Profit", "ReportNameTH": "รายงานต้นทุนและกำไรขั้นต้นตามจ๊อบ" },
        { "ReportGroup": "ACC", "ReportCode": "JOBSUMMARY", "ReportNameEN": "Job Costing Summary", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามจ๊อบ" },
        { "ReportGroup": "ACC", "ReportCode": "CUSTSUMMARY", "ReportNameEN": "Customer Costing Summary", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามลูกค้า" },
        { "ReportGroup": "ACC", "ReportCode": "INVSUMMARY", "ReportNameEN": "Invoice Costing Summary", "ReportNameTH": "รายงานสรุปต้นทุนตามใบแจ้งหนี้" },
        { "ReportGroup": "ACC", "ReportCode": "BOOKBAL", "ReportNameEN": "Book Accounts Balance", "ReportNameTH": "รายงานการใช้จ่ายเงินตามสมุดบัญชี" },
        { "ReportGroup": "ACC", "ReportCode": "VATSALES", "ReportNameEN": "Output VAT Report", "ReportNameTH": "รายงานภาษีขาย" },
        { "ReportGroup": "ACC", "ReportCode": "VATBUY", "ReportNameEN": "Input VAT Report", "ReportNameTH": "รายงานภาษีซื้อ" },
        { "ReportGroup": "ACC", "ReportCode": "WHTAX", "ReportNameEN": "Withholding-Tax Report", "ReportNameTH": "รายงานหัก ณ ที่จ่าย" },
        { "ReportGroup": "ACC", "ReportCode": "ACCEXP", "ReportNameEN": "Account Payable Report", "ReportNameTH": "รายงานค่าใช้จ่าย" },
        { "ReportGroup": "ACC", "ReportCode": "ACCINC", "ReportNameEN": "Account Receiable Report", "ReportNameTH": "รายงานรายได้" },
        { "ReportGroup": "ACC", "ReportCode": "ARBAL", "ReportNameEN": "Accrue Income Report", "ReportNameTH": "รายงานลูกหนี้คงเหลือ" },
        { "ReportGroup": "ACC", "ReportCode": "APBAL", "ReportNameEN": "Accrue Expense Report", "ReportNameTH": "รายงานเจ้าหนี้คงค้าง" },
        { "ReportGroup": "ACC", "ReportCode": "CNDN", "ReportNameEN": "Credit/Debit Note Report", "ReportNameTH": "รายงานการปรับปรุงหนี้" },
        { "ReportGroup": "ACC", "ReportCode": "TRIALBAL", "ReportNameEN": "Trial Balance Report", "ReportNameTH": "รายงานงบทดลอง" },
        { "ReportGroup": "ACC", "ReportCode": "BALANCS", "ReportNameEN": "Balance Sheet", "ReportNameTH": "รายงานงบดุล" },
        { "ReportGroup": "ACC", "ReportCode": "PROFITLOSS", "ReportNameEN": "Profit And Loss", "ReportNameTH": "รายงานงบกำไรขาดทุน" },
        { "ReportGroup": "ACC", "ReportCode": "CASHFLOW", "ReportNameEN": "Cash Flow", "ReportNameTH": "รายงานงบกระแสเงินสด" },
        { "ReportGroup": "ACC", "ReportCode": "JOURNAL", "ReportNameEN": "Journal Entry Report", "ReportNameTH": "รายงานสมุดรายวัน" }
    ];
}
function SetLanguage(lang) {
    for (let id in lang) {
        let obj = $('#' + id);
        if (obj !== null) {
            let str = '';
            if (id.substr(0, 3) == 'mnu') {
                str += '- ';
            }
            switch (mainLanguage) {
                case 'EN':
                    str += lang[id].split('|')[0].trim();
                    obj.text(str);
                    break;
                case 'TH':
                    str += lang[id].split('|')[1].trim();
                    obj.text(str);
                    break;
            }
        }
    }
}
function ChangeLanguage(code, module) {
    ShowWait();
    mainLanguage = code;
    $.get(path+'Config/SetLanguage?data=' + mainLanguage)
        .done(function () {
            let lang = {
                mainMkt: 'Marketing Works|แผนกการตลาด',
                mnuMkt1: 'Quotation|ใบเสนอราคา',
                mnuMkt2: 'Approve Quotation|อนุมัติใบเสนอราคา',
                mnuMkt3: 'Estimate Cost|ประมาณการค่าใช้จ่าย',
                mainCS: 'CS Works|แผนกบริการลูกค้า',
                mnuCS1: 'CreateJob|สร้างงานใหม่',
                mnuCS2: 'List Job|ค้นหางาน',
                mnuCS3: 'Loading Info|ข้อมูลรับบรรทุก',
                mnuCS4: 'Witholding-Tax|ออกหนังสือหักณที่จ่าย',
                mainShp: 'Shipping Works|แผนกชิปปิ้ง',
                mnuShp1: 'Advance|ใบเบิกค่าใช้จ่าย',
                mnuShp2: 'Clearing|ใบปิดค่าใช้จ่าย',
                mainApp: 'Approving|อนุมัติเอกสาร',
                mnuApp1: 'Approve Advance|อนุมัติใบเบิก',
                mnuApp2: 'Approve Clearing|อนุมัติใบปิด',
                mnuApp3: 'Approve Expense|อนุมัติบิลค่าใช้จ่าย',
                mnuApp4: 'Approve Transport|อนุมัติงานขนส่ง',
                mainFin: 'Finance Works|แผนกการเงิน',
                mnuFin1: 'Payment Advance|จ่ายเงินตามใบเบิก',
                mnuFin2: 'Payment Bill|จ่ายเงินตามบิลค่าใช้จ่าย',
                mnuFin3: 'Receive Clearing|รับเคลียร์เงินใบเบิก/ปิด',
                mnuFin4: 'Receive Invoice|รับชำระใบแจ้งหนี้',
                mnuFin5: 'Cheque Management|บันทึกรับ/จ่ายเช็ค',
                mnuFin6: 'Credit Advance|เบิกเงินทดรองจ่าย',
                mnuFin7: 'Petty Cash|จัดการเงินสดย่อย',
                mnuFin8: 'Earnest Clearing|เคลียร์เงินมัดจำ',
                mainAcc: 'Accounting Works|งานบัญชี',
                mnuAcc1: 'Vouchers|บันทึกการรับจ่ายเงิน',
                mnuAcc2: 'Invoice|ใบแจ้งหนี้',
                mnuAcc3: 'Billing|ใบวางบิล',
                mnuAcc4: 'Receipts|ใบเสร็จรับเงิน',
                mnuAcc5: 'Tax-Invoice|ใบกำกับภาษี',
                mnuAcc6: 'Payment Bill|บิลค่าใช้จ่าย',
                mnuAcc7: 'Credit/DebitNote|ใบเพิ่มหนี้/ลดหนี้',
                mnuAcc8: 'JournalEntry|สมุดรายวัน',
                mainRpt: 'Reports/Tracking|รายงานและการติดตามงาน',
                mnuRpt1: 'Reports|รายงานต่างๆ',
                mnuRpt2: 'Transport Tracking|การติดตามงานขนส่ง',
                mnuRpt4: 'Customer Tracking|การติดตามสถานะงาน',
                mnuRpt3: 'Job Dashboard|ภาพรวมสถานะงาน',
                mainMas: 'Master Files|ข้อมูลมาตรฐาน',
                mnuMas1: 'Customs File|ข้อมูลทางศุลกากร',
                mnuMas2: 'Account File|ข้อมูลทางบัญชี',
                mnuMas3: 'System File|ข้อมูลพื้นฐานระบบ',
                mainMasA: 'Account Files|ข้อมูลมาตรฐานบัญชี',
                mnuMasA1: 'Customers|ผู้นำเข้าส่งออก',
                mnuMasA2: 'Venders|ผู้ให้บริการ',
                mnuMasA3: 'Service Units|หน่วยบริการ',
                mnuMasA4: 'Bank|ธนาคาร',
                mnuMasA5: 'Bank Accounts|บัญชีธนาคาร',
                mnuMasA6: 'Service Groups|กลุ่มค่าบริการ',
                mnuMasA7: 'Service Code|รหัสค่าบริการ',
                mnuMasA8: 'Service Policy|มาตรฐานค่าบริการ',
                mnuMasA9: 'Account Code|ผังบัญชี',
                mainMasS: 'System Files|ข้อมูลพื้นฐานระบบ',
                mnuMasS1: 'System Variables|ค่าคงที่ระบบ',
                mnuMasS2: 'System User|ผู้ใช้งานระบบ',
                mnuMasS3: 'User Authorize|กำหนดสิทธิผู้ใช้',
                mnuMasS4: 'Branch|สาขา',
                mnuMasS5: 'User Role|กำหนดบทบาทผู้ใช้งาน',
                mainMasG: 'General Files|ข้อมูลพื้นฐานทั่วไป',
                mnuMasG1: 'Currency|สกุลเงิน',
                mnuMasG2: 'Country|ประเทศ',
                mnuMasG3: 'Inter Ports|ท่าต่างประเทศ',
                mnuMasG4: 'Vessels/Vehicles/Flight|ชื่อพาหนะ',
                mnuMasG5: 'Declare Type|ประเภทใบขน',
                mnuMasG6: 'Customs Port|ท่าตรวจปล่อย',
                mnuMasG7: 'Product Unit|หน่วยสินค้า',
                mnuMasG8: 'Province|จังหวัด/อำเภอ/ตำบล',
                mnuMasG9: 'Transport Route|เส้นทางการขนส่งสินค้า',
                mainLang: 'Change Language|เปลี่ยนภาษา',
                mnuLang1: 'English|ภาษาอังกฤษ',
                mnuLang2: 'Thai|ภาษาไทย',
                mainUtil: 'Utility Tools|เครื่องมือต่างๆ',
                mnuUtil1: 'Import|นำเข้าข้อมูล',
                mnuUtil2: 'Export|ส่งออกข้อมูล'
            };
            SetLanguage(lang);
            ChangeLanguageForm(module);
            CloseWait();
        });
}
function ChangeLanguageForm(fname) {
    let lang = {};
    switch (fname) {
        case 'MODULE_SALES/Quotation':
            lang = {
                lblTitle:'Quotation|ใบเสนอราคา',
                lblBranch: 'Branch|สาขา',
                lblCustomer: 'Customer|ลูกค้า',
                lblDateFrom: 'Date From|วันที่เอกสาร',
                lblDateTo: 'Date To|ถึงวันที่',
                lblShowCancel: 'Show Cancel Only|แสดงเอกสารที่ยกเลิก',
                lblDetail: 'Detail of Quotation|รายการใบเสนอราคา',
                lblAddSection: 'Add Section|เพิ่มรายการ',
                lblDelSection: 'Delete Section|ลบรายการ',
                lblAddQuo: 'Add Quotation|เพิ่มใบเสนอราคา',
                lblCopyQuo: 'Copy Quotation|ก๊อปปี้ใบเสนอราคา',
                lblPrintQuo: 'Print Quotation|พิมพ์ใบเสนอราคา',
                lblQuoHeader: 'Add/Edit Quotation|ข้อมูลใบเสนอราคา',
                lblQNo: 'Quotation No|เลขที่ใบเสนอราคา',
                lblDocDate: 'Issue Date|วันที่เอกสาร',
                lblStatus: 'Status|สถานะ',
                lblReferQNo: 'Refer Q.No|อ้างถึงใบเสนอราคา',
                lblBillingTo: 'Billing To|เก็บเงินที่',
                lblManager: 'Manager|ผู้เสนอราคา',
                lblContact: 'Contact Name|ผู้ติดต่อ',
                lblRemark: 'Remark|หมายเหตุ',
                lblDescriptionH: 'Header|ข้อความส่วนต้น',
                lblDescriptionF: 'Footer|ข้อความส่วนท้าย',
                lblApproveBy: 'Approve By|อนุมัติโดย',
                lblApproveDate: 'Approve Date|วันที่อนุมัติ',
                lblApproveTime: 'Approve Time|เวลาอนุมัติ',
                lblCancelBy: 'Cancel By|ยกเลิกโดย',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblSaveQuo: 'Update Quotation|บันทึกข้อมูล',
                lblSection: 'Section and Expenses|หัวข้อและรายการ',
                lblNewSection: 'New Section|เพิ่มหัวข้อ',
                lblSeqNo: 'Section No|หัวข้อที่',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblSDescription: 'Description|คำอธิบายหัวข้อ',
                lblUpdSection: 'Update Section|ปรับปรุงหัวข้อ',
                lblExpenses: 'Lists of expenses|รายการค่าบริการ',
                lblNewExpenses: 'New Expense|เพิ่มรายการ',
                lblDelExpenses: 'Delete Expenses|ลบรายการ',
                lblItemNo: 'Item No|รายการที่',
                lblCalType: 'Calculate Type|ประเภทการคำนวณ',
                lblRequired: 'Required?|จำเป็นต้องเรียกเก็บทุกครั้ง',
                lblSICode: 'Service Code|รหัสค่าบริการ',
                lblCurrency: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exc.Rate|อัตราแลกเปลี่บน',
                lblDescriptionTH: 'Service Description|ความหมายค่าบริการ',
                lblQtyBegin: 'Qty Begin|จำนวนเริ่มต้น',
                lblQtyEnd: 'Qty End|จำนวนสิ้นสุด',
                lblUnitCheck: 'Unit|หน่วยบริการ',
                lblChargeAmt: 'Price|ราคาต่อหน่วย',
                lblDiscountType: 'Discount Type|ประเภทส่วนลด',
                lblDiscountRate: 'Discount Rate|อัตราส่วนลด',
                lblVender: 'Vender|ผู้ให้บริการ',
                lblCostAmt: 'Cost Amount|ราคาทุน',
                lblCommType: 'Commission Type|วิธีคิดคอมมิชชั่น',
                lblCommAmt: 'Commission Amt|ยอดเงินคอมมิชชั่น',
                lblVAT: 'VAT|ภาษีมูลค่าเพิ่ม',
                lblVATRate: 'Rate|ร้อยละ',
                lblVATAmt: 'VAT Amt|ยอดเงิน',
                lblWHT: 'WHT|ภาษี ณ ที่จ่าย',
                lblWHTRate: 'Rate|ร้อยละ',
                lblWHTAmt: 'WHT Amt|ยอดเงิน',
                lblCharge: 'Charge|ค่าบริการ',
                lblTotal: 'Total|ยอดสุทธิ',
                lblBaseProfit: 'Base Profit|กำไรขั้นต้น',
                lblNetProfit: 'Net Profit|กำไรสุทธิ',
                lblAddExpense: 'Add Expense|เพิ่มรายการ',
                lblUpdExpense: 'Update Expense|บันทึกรายการ',
                lblCreateFrom: 'Create Quotation Base From|สร้างใบเสนอราคาจาก',
                lblCreate: 'Create|สร้างเลย',
                lblDiscountB: 'Discount (B)|ส่วนลด (บาท)',
                lblDiscountF: 'Discount (F)|ส่วนลด (ตปท)'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_CS/CreateJob':
            lang = {
                lblTitle: 'Create Job|สร้างหมายเลขงานใหม่',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงานขนส่ง',
                lblBranch: 'Branch|สาขา',
                lblCSCode: 'Support By|พนักงานผู้รับผิดชอบ',
                lblCustCode: 'Customer|ลูกค้า',
                lblBillingPlace: 'Consignee|ผู้ซื้อขาย',
                lblContactName: 'Contact|ผู้ติดต่อ',
                lblQuotation: 'Quotation|ใบเสนอราคา',
                lblCustInv: 'Cust Inv.|อินวอยลูกค้า',
                lblBookingNo: 'Booking.No|เลขที่ใบจอง',
                lblDutyDate: 'Operation Date|วันที่ปฏิบัติงาน',
                lblPoNo: 'PO No/RefNo|ใบสั่งซื้อของลูกค้า',
                lblHAWB: 'House AWB/BL|House AWB/BL',
                lblMAWB: 'Master AWB/BL|Master AWB/BL',
                lblCopyFrom: 'Copy from|สร้างโดยดึงข้อมูลจาก',
                lblJobDate: 'Job Date|วันที่เปิดงาน',
                lblCreateJob: 'Create Job|สร้างหมายเลขงาน',
                lblSaveComplete: 'Create Job Complete|สร้างหมายเลขงานเรียบร้อย',
                btnViewJob: 'View/Edit Job|ดู/แก่ไชข้อมูล'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_REP/Index':
            let reportLists = GetReportLists();            
            let group = $('#cboReportGroup').val();
            if (group == null) {
                group = 'N/A';
                let reportGroups = [
                    { "ConfigKey": "ACC", "ConfigValue": "Account Reports|รายงานแผนกบัญชี" },
                    { "ConfigKey": "BILL", "ConfigValue": "Finance Reports|รายงานแผนกบิลลิ่ง" },
                    { "ConfigKey": "CS", "ConfigValue": "CS Reports|รายงานแผนกบริการลูกค้า" },
                    { "ConfigKey": "FIN", "ConfigValue": "Finance Reports|รายงานแผนกการเงิน" },
                    { "ConfigKey": "SALES", "ConfigValue": "Sales Reports|รายงานแผนกการตลาด" }
                ];
                loadComboArray('#cboReportGroup', reportGroups, 'N/A');
            }
            let reports = reportLists;
            if (group !== 'N/A') {
                reports = reportLists.filter(function (data) {
                    return data.ReportGroup == group;
                });
            }
            $('#tbReportList').DataTable({
                data: reports,
                columns: [
                    { data: "ReportCode", title: "Report Code" },
                    { data: (mainLanguage == 'TH' ? "ReportNameTH" : "ReportNameEN"), title: "ReportName" }
                ],
                responsive: true,
                destroy:true
            });
            break;
    }    
}
