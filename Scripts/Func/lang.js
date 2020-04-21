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
        { "ReportGroup": "FIN", "ReportCode": "RCPSUMMARY", "ReportNameEN": "Receipt Summary", "ReportNameTH": "รายงานสรุปใบเสร็จรับเงิน" },
        { "ReportGroup": "FIN", "ReportCode": "TAXDAILY", "ReportNameEN": "Tax-invoice Daily", "ReportNameTH": "รายงานใบกำกับภาษีประจำวัน" },
        { "ReportGroup": "FIN", "ReportCode": "TAXSUMMARY", "ReportNameEN": "Tax-invoice Summary", "ReportNameTH": "รายงานสรุปใบกำกับภาษี" },
        { "ReportGroup": "FIN", "ReportCode": "CASHDAILY", "ReportNameEN": "Transaction Daily", "ReportNameTH": "รายงานการรับจ่ายเงินประจำวัน" },
        { "ReportGroup": "FIN", "ReportCode": "CHQRECEIVE", "ReportNameEN": "Cheque Receive", "ReportNameTH": "รายงานการรับเช็คประจำวัน" },
        { "ReportGroup": "FIN", "ReportCode": "CHQISSUE", "ReportNameEN": "Cheque Issue", "ReportNameTH": "รายงานการจ่ายเช็คประจำวัน" },
        { "ReportGroup": "BILL", "ReportCode": "CLRDAILY", "ReportNameEN": "Clearing Daily", "ReportNameTH": "รายงานการปิดค่าใช้จ่ายประจำวัน" },
        { "ReportGroup": "BILL", "ReportCode": "CLRSTATUS", "ReportNameEN": "Clearing Status", "ReportNameTH": "รายงานสถานะการปิดค่าใช้จ่าย" },
        { "ReportGroup": "BILL", "ReportCode": "INVDAILY", "ReportNameEN": "Invoice Daily", "ReportNameTH": "รายงานใบแจ้งหนี้ประจำวัน" },
        { "ReportGroup": "BILL", "ReportCode": "INVSTATUS", "ReportNameEN": "Invoice Status", "ReportNameTH": "รายงานสถานะใบแจ้งหนี้" },
        { "ReportGroup": "BILL", "ReportCode": "BILLDAILY", "ReportNameEN": "Billing Daily", "ReportNameTH": "รายงานใบวางบิลประจำวัน" },
        { "ReportGroup": "ACC", "ReportCode": "JOBCOST", "ReportNameEN": "Job Costing And Profit", "ReportNameTH": "รายงานต้นทุนและกำไรขั้นต้นตามจ๊อบ" },
        { "ReportGroup": "ACC", "ReportCode": "JOBSUMMARY", "ReportNameEN": "Job Costing Summary", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามจ๊อบ" },
        { "ReportGroup": "ACC", "ReportCode": "CUSTSUMMARY", "ReportNameEN": "Customer Costing Summary", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามลูกค้า" },
        { "ReportGroup": "ACC", "ReportCode": "INVSUMMARY", "ReportNameEN": "Invoice Costing Summary", "ReportNameTH": "รายงานสรุปต้นทุนตามใบแจ้งหนี้" },
        { "ReportGroup": "ACC", "ReportCode": "BOOKBAL", "ReportNameEN": "Book Accounts Balance", "ReportNameTH": "รายงานการใช้จ่ายเงินตามสมุดบัญชี" },
        { "ReportGroup": "ACC", "ReportCode": "VATSALES", "ReportNameEN": "Output VAT Report", "ReportNameTH": "รายงานภาษีขาย" },
        { "ReportGroup": "ACC", "ReportCode": "VATBUY", "ReportNameEN": "Input VAT Report", "ReportNameTH": "รายงานภาษีซื้อ" },
        { "ReportGroup": "ACC", "ReportCode": "WHTDAILY", "ReportNameEN": "Withholding-Tax Issue Report", "ReportNameTH": "รายงานการออกหนังสือหัก ณ ที่จ่าย" },
        { "ReportGroup": "ACC", "ReportCode": "WHTAXSUM", "ReportNameEN": "Withholding-Tax Summary Report", "ReportNameTH": "รายงานสรุปการออกหนังสือหัก ณ ที่จ่าย" },
        { "ReportGroup": "ACC", "ReportCode": "WHTAXCLR", "ReportNameEN": "Withholding-Tax Clearing Report", "ReportNameTH": "รายงานหัก ณ ที่จ่ายจากการปิดค่าใช้จ่าย" },
        { "ReportGroup": "ACC", "ReportCode": "PRD3", "ReportNameEN": "PRD-3 Cover Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบปะหน้า)" },
        { "ReportGroup": "ACC", "ReportCode": "PRD53", "ReportNameEN": "PRD-53 Cover Report", "ReportNameTH": "รายงานนำส่ง หัก ณ ที่จ่าย ภ.ง.ด.53 (ใบปะหน้า)" },
        { "ReportGroup": "ACC", "ReportCode": "PRD3D", "ReportNameEN": "PRD-3 Detail Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบแนบ)" },
        { "ReportGroup": "ACC", "ReportCode": "PRD53D", "ReportNameEN": "PRD-53 Detail Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.53 (ใบแนบ)" },
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
                mnuRpt5: 'Document Tracking|การติดตามสถานะเอกสาร',
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
        case 'MODULE_ADV/Approve':
            lang = {
                lblTitle: 'Approve Advance Slip|อนุมัติใบเบิกค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Request Date From|ช่วงวันที่ขอเบิก',
                lblDateTo: 'Request Date To|ถึงวันที่',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblReqBy: 'Request By|ขอเบิกโดย',
                lblAdvFor: 'Advance For|สำหรับลูกค้า',
                linkSearch: 'Search|ค้นหา',
                lblDocList: 'Approve Document|เอกสารที่เลือก',
                lblTotal: 'Approve Total|ยอดรวมที่อนุมัติ',
                linkApprove:'Approve|อนุมัติเอกสาร'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_ADV/Index':
            lang = {
                lblTitle: 'Advance Slip|ใบเบิกค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblAdvNo: 'Advance No|เลขที่ใบเบิก',
                lblAdvDate: 'Advance Date|วันที่ขอเบิก',
                linkHeader: 'Advance Header|ส่วนควบคุม',
                linkDetail: 'Advance Detail|ส่วนรายการ',
                lblAdvBy: 'Advance By|ผู้จัดทำ',
                lblReqBy: 'Request By|ผู้ขอเบิก',
                lblAdvFor: 'Advance For|สำหรับลูกค้า',
                lblWHTaxNo: 'WH-Tax No|ใบหัก ณ ที่จ่าย',
                btnAddWHTax: 'Add|เพิ่ม',
                lblPaymentNo: 'Bill A/P|บืลค่าใช้จ่าย',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblStatus: 'Status|สถานะ',
                lblAdvType: 'Advance Type|ประเภทการเบิก',
                lblRemark: 'Remark|หมายเหตุ',
                lblCurrency: 'Currency|สกุลเงิน',
                lblPayTotal: 'Payment Total|รวมเงินที่ขอเบิก',
                lblCash: 'Cash|เงินสด',
                lblChq: 'Cashier Cheque|เช็คบริษัท',
                lblChqCash: 'Customer Chq|เช็คลูกค้า',
                lblCred: 'Credit|เครดิตหนี้',
                lblApproveBy: 'Approve By|อนุมัติโดย',
                lblApproveDate: 'Approve Date|วันที่อนุมัติ',
                lblApproveTime:'Approve Time|เวลา',
                lblPaymentBy: 'Payment By|ทำจ่ายโดย',
                lblPaymentDate: 'Payment Date|วันที่จ่าย',
                lblPaymentTime: 'Payment Time|เวลา',
                lblPaymentRef: 'Payment Ref|เลขที่การลงบัญชี',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelTime: 'Cancel Time|เวลา',
                lblCancelReson: 'Cancel Reason|เหตุผลที่ยกเลิก',
                linkNew: 'New Advance|สร้างใบเบิกใหม่',
                linkSave: 'Save Advance|บันทึกใบเบิก',
                linkPrint: 'Print Advance|พิมพ์ใบเบิก',
                linkPrint2: 'Print Advance|พิมพ์ใบเบิก',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                linkDel: 'Delete Detail|ลบรายการ',
                lblMainCurr: 'Main Currency|สกุลเงินหลัก',
                lblExcRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblAdvAmount: 'Amount|ยอดรวม',
                lblVatAmount: 'VAT|ภาษีมูลค่าเพิ่ม',
                lblWhtAmount: 'WHT|หัก ณ ที่จ่าย',
                lblTotalAmount: 'Total|ยอดสุทธิ',
                lblItemNo: 'No|ลำดับที่',
                lblSTCode: 'Service Group|กลุ่มค่าใช้จ่าย',
                lblDuplicate: 'Can Partial Clear|สามารถแตกรายการปิดได้',
                lblSICode: 'Service Code|รหัสค่าใช้จ่าย',
                lblSDescription: 'Service Description|ชื่อค่าใช้จ่าย',
                lblForJNo: 'Job No|หมายเลขงาน',
                lblCustInv: 'Cust.Inv|อินวอยลูกค้า',
                lblCurrencyCode: 'Currency|สกุลเงิน',
                lblRate: 'Rate|อัตราแลกเปลี่ยน',
                lblQty: 'Qty|จำนวน',
                lblUnitPrice: 'Price|ราคา/หน่วย',
                lblAMTCal: 'Amount|ราคารวม',
                lblAmount: 'Conv.Amt|ราคาสุทธิ',
                lblVATRate: 'VAT Rate|อัตรา VAT',
                lblWHTRate: 'WHT Rate|อัตราหัก ณ ที่จ่าย',
                lblNETAmount: 'Net Amount|ยอดสุทธิ',
                lblWTNo: 'WH-Tax No|เลขที่ใบหัก(ที่ได้รับมา)',
                lblVenCode: 'Pay to Vender|จ่ายให้กับ',
                lblDRemark: 'Remark|บันทึกเพิ่มเติม',
                linkClear: 'New|เพิ่มรายการ',
                linkUpdate: 'Save|จัดเก็บรายการ',
                lblFilter: 'Filter By Status|แสดงข้อมูลตามสถานะ',
                btnGetExcRate:'Get Rate|ดึงอัตราแลกเปลี่ยน'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_ADV/EstimateCost':
            lang = {
                lblTitle:'Estimate Cost|ประมาณการค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblJNo: 'Job No|หมายเลขงาน',
                btnAutoEntry: 'Load From Quotation|ดึงรายการจากใบเสนอราคา',
                lblSICode: 'Service Code|รหัสค่าบริการ',
                lblRemark: 'Remark|หมายเหตุ',
                lblStatus: 'Status|สถานะ',
                lblAmount: 'Amount|ยอดเงิน',
                lblCurrency: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblQty: 'Qty|จำนวน',
                lblUnit: 'Unit|หน่วย',
                lblTotal:'Total|ยอดรวม',
                lblVATRate: 'VAT Rate|อัตรา VAT',
                lblWHTRate: 'WHT Rate|อัตราหัก ณ ที่จ่าย',
                lblWHT: 'WHT|หัก ณ ที่จ่าย',
                lblTotal: 'Total|ยอดสุทธิ',
                linkNew: 'New|เพิ่มข้อมูล',
                linkSave: 'Save|บันทึกข้อมูล',
                linkDelete: 'Delete|ลบข้อมูล',
                linkCopy: 'Copy From Job|Copy ข้อมูลจาก Job',
                linkPrint:'Print Pre-Invoice|พิมพ์แบบประเมินค่าใช้จ่าย'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_ACC/Approve':
            lang = {
                lblTitle: 'Payment Billing Approve|อนุมัติบิลค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Due Date From|กำหนดชำระวันที่',
                lblDateTo: 'To|ถึงวันที่',
                lblCurrency: 'Currency|สกุลเงินที่ต้องจ่าย',
                lblVenCode: 'Vender|ผู้ให้บริการ',
                linkSearch: 'Search|ค้นหา',
                lblListApprove: 'Selected Document|เอกสารที่เลือก',
                linkApprove:'Approve|อนุมัติเอกสาร'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_ACC/AccountCode':
            lang = {
                lblTitle : 'Account Code|รหัสบัญชี',
                lblAccCode: 'Code|รหัส',
                lblAccTName: 'Name (TH)|ชื่อ(ไทย)',
                lblAccEName: 'Name (EN)|ชื่อ(อังกฤษ)',
                lblAccType: 'Type|ประเภท',
                lblAccMain: 'Close Balance To|ปิดยอดให้กับ',
                lblAccSide: 'Side|บันทึกบัญชีด้าน'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_ACC/WHTax':
            lang = {
                lblTitle: 'Withholding Tax|หนังสือรับรองหัก ณ ที่จ่าย',
                lblBranch: 'Branch|สาขา',
                lblDocNo: 'Doc No|เลขที่เอกสาร',
                lblDocDate: 'Doc Date|วันที่ออกเอกสาร',
                linkTab1: 'Headers|ส่วนควบคุม',
                linkTab2: 'Details|ส่วนรายการ',
                lblTaxName1: 'Tax Issuer|ผู้มีหน้าที่หัก ณ ที่จ่าย',
                lblVend: 'Venders|เลือกจากผู้ให้บริการ',
                lblTaxNumber1: 'Tax Number|เลขประจำตัวผู้เสียภาษี',
                lblIDCard1: 'ID Number|เลขประจำตัวประชาชน',
                lblAddress1: 'Address|ที่อยู่',
                lblBranch1: 'Branch|สาขา',
                lblTaxName2: 'Tax Agent|กระทำการแทนโดย',
                lblTaxNumber2: 'Tax Number|เลขประจำตัวผู้เสียภาษี',
                lblIDCard2: 'ID Number|เลขประจำตัวประชาชน',
                lblAddress2: 'Address|ที่อยู่',
                lblBranch2: 'Branch|สาขา',
                lblTaxName3: 'Tax Payer|ผู้่ถูกหักภาษี ณ ที่จ่าย',
                lblTaxNumber3: 'Tax Number|เลขประจำตัวผู้เสียภาษี',
                lblIDCard3: 'ID Number|เลขประจำตัวประชาชน',
                lblAddress3: 'Address|ที่อยู่',
                lblBranch3: 'Branch|สาขา',
                lblSeqInForm: 'Number|ลำดับที่',
                lblFormType: 'Type Of|สำหรับยื่นแบบภาษี',
                lblLawNo: 'Tax Code|หักภาษีตามมาตรา',
                lblCancel: 'Cancel|ยกเลิก',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblReason: 'Reason|เหตุผลที่ยกเลิก',
                lblCancelDate: 'Cancel date|วันที่ยกเลิก',
                linkNew: 'Clear Data|เพิ่มข้อมูล',
                linkSave: 'Save Data|บันทึกข้อมูล',
                linkPrint: 'Print Data|พิมพ์ข้อมุล',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                lblCondition: 'Tax Condition|รูปแบบการหักภาษี',
                lblPayTaxOther: 'Condition Note|หมายเหตุ',
                lblIncRate: 'Control Rate|อัตราภาษีคุม',
                lblIncOther: 'Description|ประเภทรายได้',
                lblSoLicNo: 'Social Security No|เลขประจำตัวผู้ประกันตน',
                lblSoTaxNo: 'Social Payer No|เลขประจำตัวนายจ้างผู้นำส่งปกส',
                lblSoLicAmt: 'Social Amount|ยอดนำส่งประกันสังคม',
                lblPayeeAccNo: 'Provident Payer|เลขประจำตัวกองทุนสมทบ',
                lblProvidentAmt: 'Provident Amt|ยอดเงินนำส่งกองทุนสมทบ',
                lblTeacherAmt: 'Teacher Amt|ยอดเงินกองทุนสงเคราะห์ครู',
                lblTotalPayAmt: 'Total Amount|รวมรายได้พึงประเมิน',
                lblTotalPayTax:'Total Tax|ยอดรวมภาษี',
                lblItemNo: 'No.|ลำดับที่',
                lblDocType: 'Doc Type|ประเภทเอกสาร',
                lblRefNo: 'Ref No|เลขที่เอกสารอ้างอิง',
                lblJNo: 'Job No|หมายเลขงาน',
                lblPayDate: 'Pay date|วันที่จ่าย',
                lblIncType: 'Revenue Type|ประเภทรายได้พึงประเมิน',
                lblPayTaxDesc: 'Description|กลุ่มรายได้',
                lblPayRate: 'Rate|อัตราภาษี',
                lblAmount: 'Tax Base|ฐานภาษี',
                lblPayTax: 'Tax|ยอดภาษี',
                linkSaveDet: 'Save Detail|บันทึกรายการ',
                linkDelDet: 'Delete Detail|ลบรายการ'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_ADM/Role':
            lang = {
                lblTitle: 'User Role|บทบาทของผู้ใช้งาน',
                lblRoleID: 'Role Id|รหัสบทบาท',
                lblRoleDesc: 'Role Description|คำอธิบาย',
                lblRoleGroup: 'Role Level|ระดับผู้่ใช้งาน',
                lblUser: 'User ID|รหัสพนักงาน',
                lblUserRole: 'User On this Role|พนักงานในบทบาทนี้',
                lblFunction: 'Function|ฟังก์ชั่นการทำงาน'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_CLR/Approve':
            lang = {
                lblTitle: 'Clearing Approve|อนุมัติใบปิดค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Clear Date From|จากวันที่เคลียร์',
                lblDateTo: 'Clear Date To|ถึงวันที่',
                lblJobType: 'Job Type|ประเภทงาน',
                lblClrBy: 'Clear By|ปิดบัญชีโดย',
                lblClrFrom: 'Clear From|จากแผนก',
                lblClrType: 'Clear Type|ประเภทการปิดบัญชี',
                linkSearch: 'Search|ค้นหา',
                lblListApprove: 'Approve Document|เอกสารที่เลือก',
                lblExpTotal: 'Expenses Total|ยอดรวมอนุมัติ',
                linkApprove: 'Approve|อนุมัติเอกสาร'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_CLR/Index':
            lang = {
                lblTitle: 'Clearance Slip|ใบปิดค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblClrNo: 'Clearing No|เลขที่ใบปิด',
                lblClrDate: 'Document Date|วันที่เอกสาร',
                linkHeader: 'Header|ส่วนควบคุม',
                linkDetail: 'Detail|ส่วนรายการ',
                lblClrBy: 'Clear By|ผู้ทำรายการ',
                lblClrType: 'Clearing Type|ประเภทการปิดบัญชี',
                lblContNo: 'Container No|เลขที่ตู้คอนเทนเนอร์',
                lblClearanceDate: 'Clearance Date|วันที่ปฏิบัติงาน',
                lblJobType: 'Job Type|ประเภทงาน',
                lblClrFrom: 'Clear From|งานของแผนก',
                lblClrStatus: 'Status|สถานะ',
                lblCoPerson: 'Co-person Reference|ชื่อกลุ่มบุคคลอ้างอิง',
                lblTRemark: 'Remark|บันทึกเพิ่มเติม',
                lblAdvTotal: 'Advance Total|ยอดเบิกที่จ่ายไป',
                lblExpTotal: 'Expense Total|ยอดค่าใช้จ่ายจริง',
                lblClrTotal: 'Clear Total|ยอดคืนเงิน/จ่ายคืน',
                lblApprBy: 'Approve By|ผู้ตรวจสอบ',
                lblApprDate: 'Approve Date|วันที่ตรวจสอบ',
                lblApprTime: 'Approve Time|เวลา',
                lblRecvBy: 'Receive By|ผู้รับเคลียร์',
                lblRecvDate: 'Receive Date|วันที่รับเคลียร์',
                lblRecvTime: 'Receive Time|เวลา',
                lblRecvRef: 'Receive Ref|เลขที่การลงบัญชี',
                lblCancelBy: 'Cancel By|ยกเลิกโดย',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelTime: 'Cancel Time|เวลา',
                lblCancelReson:'Cancel Reason|เหตุผลที่ยกเลิก',
                linkNew: 'New Clearing|สร้างใบปิดใหม่',
                linkSave: 'Save Clearing|บันทึกใบปิด',
                linkPrint: 'Print Clearing|พิมพ์ใบปิด',
                linkPrint2: 'Print Clearing|พิมพ์ใบปิด',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                linkAdv: 'Choose Advance|เลือกรายการใบเบิก',
                linkPay: 'Choose Payment|เลือกรายการบิลค่าใช้จ่าย',
                linkDel: 'Delete Detail|ลบรายการ',
                lblSumCharge: 'Customers Chargable|รวมยอดที่เรียกเก็บได้',
                lblSumCost: 'Company Cost|รวมยอดที่เรียกเก็บไม่ได้',
                lblClrAmount: 'Clear Amount|ยอดรวมค่าใช้จ่าย',
                lblVatAmount: 'VAT|ภาษีมูลค่าเพิ่ม',
                lblWhtAmount: 'WHT|หัก ณ ที่จ่าย',
                lblNetAmount: 'Net Amount|ยอดค่าใช้จ่ายสุทธิ',
                lblItemNo: 'No|ลำดับที่',
                lblSTCode: 'Service Group|กลุ่มค่าใช้จ่าย',
                lblDuplicate: 'Partial Clear|เคลียร์ค่าใช้จ่ายใบเบิกแบบต่อเนื่อง',
                lblSICode: 'Service Code|รหัสค่าใช้จ่าย',
                lblSDescription: 'Description|คำอธิบาย',
                lblJobNo: 'Job No|หมายเลขงาน',
                lblCustInv: 'Cust.Inv|อินวอยลูกค้า',
                lblQNo: 'Quotation No|ใบเสนอราคา',
                lblCurrCode: 'Currency|สกุลเงิน',
                lblCurrRate: 'Rate|อัตราแลกเปลี่ยน',
                lblQty: 'Qty|จำนวน',
                lblUnit: 'Unit|หน่วย',
                lblUnitPrice: 'Price|ราคา',
                lblAmount: 'Amount|ราคารวม',
                lblVATRate: 'VAT|ภาษีมูลค่าเพิ่ม',
                lblWHTRate: 'WH-Tax|หัก ณ ที่จ่าย',
                lblNETAmount: 'Net|ยอดสุทธิ',
                lblWTNo: 'WH-Tax No|ใบหัก ณ ที่จ่าย(ที่ได้รับ)',
                lblSlipNo: 'Slip No|เลขที่ใบเสร็จ',
                lblSlipDate: 'Slip Date|วันที่ในใบเสร็จ',
                lblLtdAdv: '**Use Tax Article 60,69,70|**หักตามมาตรา 60,69,70',
                lblVenCode:'Pay To Vender|จ่ายให้กับ',
                lblDRemark: 'Remark|บันทึกเพิ่มเติม',
                lblIsCost: 'Is Company Cost(Cannot charge)|เป็นต้นทุนของบริษัท',
                lblAdvItemNo: 'Clear From Adv Item.No|ปิดมาจากใบเบิกรายการที่',
                lblAdvNo: 'Adv.No|เลขที่ใบเบิก',
                lblAdvAmt:'Advance Net|ยอดเงินที่เบิก',
                lblInvNo: 'Invoice#|เลขที่ใบแจ้งหนี้',
                lblPayNo: 'Vender Inv#|เลขที่บิลค่าใช้จ่าย',
                linkClear: 'New|เพิ่มรายการใหม่',
                linkUpdate: 'Save|จัดเก็บรายการ',
                lblHeaderPay: 'Payment Lists|รายการบิลค่าใช้จ่าย',
                lblHeaderAdv: 'Advance Lists|รายการใบเบิกค่าใช้จ่าย',
                lblHeaderQuo: 'Quotation Lists|รายการใบเสนอราคา',
                lblCustCode: 'Customer|ลูกค้า',
                lblFilter:'Filter By Status|เลือกตามสถานะ'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_CS/Index':
            lang = {
                lblBranch: 'Branch|สาขา',
                lblStatus: 'Status|สถานะ',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblYear: 'Year|ปี',
                lblMonth: 'Month|เดือน',
                lblJob: 'Enter Job >>|คีย์หมายเลขงานที่นี่ >>',
                btnJobSlip: 'Show|แสดง',
                linkCreate: 'Create|สร้างงานใหม่',
                linkSearch:'Search|ค้นหา'
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
        case 'MODULE_CS/ShowJob':
            lang = {
                lblTitle: 'Job Order|ใบสั่งงาน',
                lblBranchCode: 'Branch|สาขา',
                lblJNo: 'Job Number|หมายเลขงาน',
                lblDocDate: 'Open Date|วันที่เปิดงาน',
                lblJobStatus: 'Job Status|สถานะงาน',
                lblCustCode: 'Customer|ลูกค้า',
                lblTAddress: 'Address|ที่อยู่(ไทย)',
                lblPhoneFax: 'Contact Info|รายละเอียดการติดต่อ',
                lblConsignee: 'Consignee|ผู้ซื้อขาย',
                lblBillAddress: 'Address|ที่อยู่',
                lblUseLocalTrans: 'Use Local Transport|ใช้รถของลูกค้าเอง',
                lblContactName: 'Contact Person|ผู้ติดต่อ',
                lblCSName: 'Support By|พนักงานผู้รับผิดชอบ',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงานขนส่ง',
                lblJobCondition: 'Work Condition|รูปแบบการทำงาน',
                lblCustPoNo: 'Customer PO|ใบสั่งซื้อของลูกค้า',
                lblDescription: 'Description|รายละเอียดงาน',
                lblQNo: 'Quotation|ใบเสนอราคา',
                lblManagerName: 'Sales By|พนักงานขาย',
                lblCommission: 'Commission|อัตราคาคอมมิชชั่น',
                lblConfirmDate: 'Confirm Date|วันที่ลูกค้ายืนยัน',
                lblCloseBy: 'Close By|ผู้ปิดงาน',
                lblCloseDate: 'Close Date|วันที่ปิดงาน',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblCustInvNo: 'Customer Inv|อินวอยลูกค้า',
                lblInvProduct: 'Products|รายการสินค้า',
                lblInvTotal: 'Inv.Total|มูลค่ารวมอินวอย',
                lblInvCurrency: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblBookingNo: 'Booking No|ใบบุคกิ้ง',
                lblBLNo: 'BL/AWB Status|สถานะ BL/AWB',
                lblHAWB: 'House BL/AWB|House BL/AWB',
                lblMAWB: 'Master BL/AWB|Master BL/AWB',
                lblTotalCTN: 'Total Containers|จำนวนตู้',
                lblMeasurement: 'Meas.(M3)|ปริมาตร (M3)',
                lblDeliverNo: 'Delivery No|เลขที่ใบส่งของ',
                lblDeliverTo: 'Delivery To|สถานที่ส่งสินค้า',
                lblProjectName: 'Project Name|ชื่อโครงการ/วัตถุประสงค์',
                lblInvQty: 'Qty|จำนวนสินค้า',
                lblInvPackQty: 'Pack.Total|รวมหีบห่อ',
                lblNetWeight: 'Net Weight|น้ำหนักสุทธิ',
                lblGrossWeight: 'Gross Weight|น้ำหนักรวม',
                lblInvFCountry: 'From Country|จากประเทศ',
                lblInvCountry: 'To Country|ไปประเทศ',
                lblInvInterPort: 'Inter Port|ท่าต่างประเทศ',
                lblForwarder: 'Agent/Forwarder|ตัวแทนเรือ/สายการบิน',
                lblVesselName: 'Vessel Name|ชื่อพาหนะ',
                lblMVesselName: 'Master Vessel|ชื่อพาหนะถ่ายลำ',
                lblTransport: 'Transporter|บริษัทขนส่งในประเทศ',
                lblETDDate: 'ETD Date|วันออกจากท่า',
                lblETADate: 'ETA Date|วันเทียบท่า',
                lblLoadDate: 'Load Date|วันบรรทุกของขึ้น',
                lblDeliveryDate: 'Unload Date|วันบรรทุกของลง',
                lblDeliverAddr: 'Delivery Address|ที่อยู่สถานที่ส่งของ',
                lblEDIDate: 'EDI Date|วันที่ทำใบขนสินค้า',
                lblReadyClearDate: 'Ready Clear|วันที่ผ่านพิธีการ',
                lblDutyDate: 'Inspection Date|วันที่ตรวจปล่อย',
                lblClearDate: 'Clear Date|วันที่เคลียร์ของ',
                lblDeclareType: 'Declare Type|ประเภทใบขน',
                lblDeclareNo: 'Declare No|เลขที่ใบขนสินค้า',
                lblDutyAmt: 'Duty Amt|ยอดภาษีอากร',
                lblTyAuthorSp: 'Special Privilege|สิทธิประโยชน์',
                lblTy19BIS: '19 BIS Rule|แบบ 19 ทวิ',
                lblTyClearTax: 'Duty Rule|เงื่อนไขภาษี',
                lblClearTaxReson: 'Certificate#|เลขที่ใบอนุญาต',
                lblDeclareStatus: 'Declare Status|สถานะใบขน',
                lblReleasePort: 'Release Port|สถานที่ตรวจปล่อย',
                lblPortNo: 'Discharge Port|ท่าตรวจปล่อย',
                lblShippingCmd: 'Shipping Note|หมายเหตุชิปปิ้ง',
                lblShipping: 'Shipping Staff|พนักงานตรวจปล่อย',
                lblComPaidBy: 'Company Paid By|ค่าใช้จ่ายของบริษัท',
                lblComChq: 'Cheque|เช็คจ่าย',
                lblComCash: 'Cash|เงินสด',
                lblComEPay: 'E-Payment|E-Payment',
                lblComOther: 'Others|อื่นๆ',
                lblComTotal: 'Total Paid|รวมค่าใช้จ่าย',
                lblCustPaidBy: 'Customer Paid By|ค่าใช้จ่ายของลูกค้า',
                lblCustChq: 'Cheque|เช็ครับ',
                lblCustCash: 'Cash|เงินสด',
                lblCustTaxCard: 'Tax-Card|บัตรภาษี',
                lblCustEPay: 'E-Payment|E-Payment',
                lblCustBankGuarantee: 'Bank Guarantee|วางเงินประกัน',
                lblCustOther: 'Others|อื่นๆ',
                lblCustTotal:'Total Paid|รวมค่าใช้จ่าย',
                lblQtyAdd: 'Qty|จำนวน',
                lblUnitAdd: 'Unit|หน่วยบริการ',
                linkTab1: 'Customer Data|ข้อมูลลูกค้า',
                linkTab2: 'Invoice Data|ข้อมูลอินวอยลูกค้า',
                linkTab3: 'Customs Data|ข้อมูลพิธีการ',
                linkTab4: 'Operation Data|ข้อมูลการทำงาน',
                linkTab5:'Others Control|ข้อมูลอื่นๆ',
                optTab1: 'Customers Data|ข้อมูลลูกค้า',
                optTab2: 'Invoice Data|ข้อมูลอินวอยลูกค้า',
                optTab3: 'Customs Data|ข้อมูลพิธีการ',
                optTab4: 'Document Tracking|ข้อมูลการทำงาน',
                optTab5: 'Others Control|ข้อมูลอื่นๆ',
                btnCloseJob: 'Close Job|ปิดงาน',
                btnCancelJob: 'Cancel Job|ยกเลิกงาน',
                btnDelivery: 'Delivery Slip|พิมพ์ใบส่งของ',
                lblGreen: 'Green|ไม่เปิดตรวจ',
                lblRed: 'Red|เปิดตรวจ',
                lblManual: 'Manual|เดิน Manual',
                btnViewTAdv: 'Credit Advance|ใบทดรองจ่าย',
                btnViewChq: 'Customer Cheque|บันทึกรับเช็คจากลูกค้า',
                linkAddLog: 'Add Remark|เพิ่มหมายเหตุ',
                btnLinkDoc: 'Document Files|จัดเก็บเอกสาร',
                btnLinkLoad: 'Transport Info|ข้อมูลการขนส่ง',
                btnLinkExp: 'Estimate Expenses|ประเมินค่าใช้จ่าย',
                btnLinkCAdv: 'Credit Advance|ใบทดรองจ่าย',
                btnLinkAdv: 'Advance Request|ใบเบิกค่าใช้จ่าย',
                btnLinkClr: 'Advance Clearing|ใบปิดค่าใช้จ่าย',
                btnLinkCost: 'Cost & Profit|ข้อมูลกำไรขาดทุน',
                linkSave: 'Save|บันทึกข้อมูล',
                linkPrint:'Print|พิมพ์ใบสั่งงาน'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_CS/Transport':
            lang = {
                lblTitle: 'Loading Information|ข้อมูลการรับบรรทุก',
                lblBranchCode: 'Branch|สาขา',
                lblBookingNo: 'Booking No|เลขที่ใบจอง',
                lblJNo: 'Job Number|หมายเลขงาน',
                lblTransportTerm: 'Transport Term|รูปแบบการขนส่ง',
                lblNotify: 'Notify Party|ผู้รับสินค้าปลายทาง',
                lblTransport: 'Transporter|ผู้ให้บริการขนส่ง',
                lblLoadDate: 'Load Date|วันที่โหลดสินค้า',
                lblContact: 'Contact Name|ผู้ติดต่อ',
                lblRemark: 'Remark|หมายเหตุ',
                lblPaymentCond: 'Freight Payment Condition|เงื่อนไขการจ่ายค่าเฟรท',
                lblPaymentBy: 'Freight Paid By|ผู้รับผิดชอบค่าใช้จ่าย',
                lblCYDate: 'CY Closing/Pickup Date :|วันที่ปิดรับตู้',
                lblCYTime: 'Time|เวลา',
                lblPackingDate: 'Last Load/Packing Date:|โหลดของภายในวันที่',
                lblPackingTime: 'Time|เวลา',
                lblFactoryDate: 'Arrival/Delivery Date|ต้องถึงท่าภายในวันที่',
                lblReturnDate: 'Return Date|คืนตู้ภายในวันที่',
                lblReturnTime: 'Time|เวลา',
                lblRoute: 'Transport Route|เส้นทางการขนส่ง',
                lblActive: 'Active Trip:|จำนวน',
                lblFinish: 'Finished Trip:|จบงาน',
                lblNonActive:'Non-active|ยังไม่จบ',
                lblPlace1: 'Place #1: |จุดที่ 1',
                lblPlace2: 'Place #2: |จุดที่ 2',
                lblPlace3: 'Place #3: |จุดที่ 3',
                lblPlace4: 'Place #4: |จุดที่ 4',
                lblAddress1: 'Address #1:|ที่อยู่ 1',
                lblAddress2: 'Address #2:|ที่อยู่ 2',
                lblAddress3: 'Address #3:|ที่อยู่ 3',
                lblAddress4: 'Address #4:|ที่อยู่ 4',
                lblContact1: 'Contact #1:|ผู้ติดต่อ 1',
                lblContact2: 'Contact #2:|ผู้ติดต่อ 2',
                lblContact3: 'Contact #3:|ผู้ติดต่อ 3',
                lblContact4: 'Contact #4:|ผู้ติดต่อ 4',
                lblAutoGenCon: 'Auto Create Container|สร้างตู้สินค้าอัตโนมัติ',
                lblTotalCon: 'Total(s)|จำนวนตู้',
                lblSICode: 'Expense code|รหัสค่าใช้จ่าย',
                lblSIDesc: 'Expense Description|ชื่อค่าใช้จ่าย',
                lblCostAmt: 'Cost Amount|ราคาต้นทุน',
                lblChargeAmt: 'Charge Amount|ราคาเรียกเก็บ',
                lblChargeCode: 'Charge Code|รหัสค่าบริการ',
                lblNo: 'No :|ลำดับที่',
                lblContainerNo: 'Container|หมายเลขตู้',
                lblContainerSize: 'Size|ขนาดตู้',
                lblSealNo: 'Seal No.|เบอร์ซีล',
                lblPackDetail: 'Package Details|ข้อมุลการบรรจุหีบห่อ',
                lblPackQty: 'Package Qty|จำนวนหีบห่อ',
                lblPackUnit: 'Package Unit|หน่วยหีบห่อ',
                lblGW: 'G/W|น้ำหนักรวม',
                lblM3: 'M3|M3',
                lblOperDay: 'Operation Days|จำนวนวันทำงาน',
                lblJobStatus: 'Job Status|สถานะงาน',
                lblDriver: 'Driver|คนขับ',
                lblTruckNo: 'Truck ID|ทะเบียนรถ',
                lblTruckType: 'Type|ประเภทรถ',
                lblRouteID: 'Route ID|เส้นทาง',
                lblLocationD: 'Location|การเดินทาง',
                lblComment: 'Comment|บันทึกข้อความ',
                lblShippingMark: 'Shipping Mark|ตราส่งหีบห่อ',
                lblDeliveryNo: 'Delivery No|เลขที่ใบส่งของ',
                lblExpCon: 'Expense Can Billing On This Route|ค่าใช้จ่ายที่เกิดขึ้นในเส้นทางนี้',
                lblVenBill: 'Expense Billed By Vender|ค่าใช้จ่ายที่ได้รับการวางบิลมาแล้ว',
                linkTab1: 'Loading Information|ข้อมูลใบจอง',
                linkTab2: 'Container Information|ข้อมูลการรับบรรทุก',
                btnSaveLoc: 'Update Route Data|ปรับปรุงช้อมูลเส้นทาง',
                btnEditExp: 'Edit Route Expense|บันทึกประเมินราคา',
                linkNew: 'New Booking|เพิ่มข้อมูล',
                linkSave: 'Save Booking|บันทึกข้อมูล',
                linkDel: 'Delete Booking|ลบข้อมูล',
                linkPrint: 'Print Form|พิมพ์ฟอร์ม',
                linkUpCon: 'Update Total Container To Job|ปรับปรุงข้อมูลจำนวนตู้ใน Job',
                linkAddCon: 'Add Container|เพิ่มตู้สินค้า',
                btnCreateContainer:'Create|สร้างข้อมูล',
                linkEntryExp: 'Entry Expenses|บันทึกค่าใช้จ่าย',
                linkEntryExp2: 'Entry Expenses|ใบค่าใช้จ่าย',
                linkPrintTruck: 'Print Truck Order|พิมพ์ใบสั่งงานขนส่ง',
                btnSaveExp: 'Save Price|บันทึกราคา',
                btnGenDeliveryNo: 'Create|สร้างใบส่งของ',
                btnPrintSlip: 'Delivery Slip|ใบส่งของ',
                linkNewCont: 'New Container|เพิ่มตู้ใหม่',
                linkSaveCont: 'Save Container|บันทึกตู้',
                linkDelCont: 'Delete Container|ลบตู้',
                lblPickup: 'Pick-Up|วันรับตู้/ออกรับของ',
                lblPickupTarget: 'Target Date|ภายในวันที่',
                lblPickupTargetTime: 'Target Time|ก่อนเวลา',
                lblPickupActual: 'Actual Date|วันที่จริง',
                lblPickupActualTime: 'Actual Time|เวลาจริง',
                lblDelivery: 'Delivery|วันโหลดของ',
                lblDeliveryTarget: 'Target Date|ภายในวันที่',
                lblDeliveryTargetTime: 'Target Time|ก่อนเวลา',
                lblDeliveryActual: 'Actual Date|วันที่จริง',
                lblDeliveryActualTime: 'Actual Time|เวลาจริง',
                lblReturn: 'Return|วันคืนตู้',
                lblReturnTarget: 'Target Date|ภายในวันที่',
                lblReturnTargetTime: 'Target Time|ก่อนเวลา',
                lblReturnActual: 'Actual Date|วันที่จริง',
                lblReturnActualTime: 'Actual Time|เวลาจริง'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_CS/TruckApprove':
            lang = {
                lblTitle: 'Transport Order Approve|อนุมัติสถานะงานขนส่ง',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Load Date From|จากวันที่โหลด',
                lblDateTo: 'To|ถึงวันที่',
                lblVenCode: 'Vender|ผู้ให้บริการ',
                lblCustCode: 'Customer|ลูกค้า',
                linkSearch: 'Search|ค้นหา',
                lblItemNo: 'No|ลำดับที่',
                lblContNo: 'Container|เบอร์ตู้',
                lblContSize: 'Size|ขนาดตู้',
                lblSealNo: 'Seal.No|เบอร์ซีล',
                lblDriver: 'Driver|คนขับ',
                lblTruckNo: 'Truck ID|ทะเบียนรถ',
                lblTruckType: 'Type|ประเภทรถ',
                lblRouteID: 'Route ID|รหัสเส้นทาง',
                lblLocation: 'Location|ชื่อเส้นทาง',
                lblComment: 'Comment|บันทึกเพิ่มเติม',
                lblShippingMark: 'Shipping Mark|เครื่องหมายหีบห่อ',
                lblStatus: 'Job Status|สถานะงานขนส่ง',
                lblPickup: 'Pick-Up|วันรับตู้/ออกรับของ',
                lblPickupTarget: 'Target Date|ภายในวันที่',
                lblPickupTargetTime: 'Target Time|ก่อนเวลา',
                lblPickupActual: 'Actual Date|วันที่จริง',
                lblPickupActualTime: 'Actual Time|เวลาจริง',
                lblDelivery: 'Delivery|วันโหลดของ',
                lblDeliveryTarget: 'Target Date|ภายในวันที่',
                lblDeliveryTargetTime: 'Target Time|ก่อนเวลา',
                lblDeliveryActual: 'Actual Date|วันที่จริง',
                lblDeliveryActualTime: 'Actual Time|เวลาจริง',
                lblReturn: 'Return|วันคืนตู้',
                lblReturnTarget: 'Target Date|ภายในวันที่',
                lblReturnTargetTime: 'Target Time|ก่อนเวลา',
                lblReturnActual: 'Actual Date|วันที่จริง',
                lblReturnActualTime: 'Actual Time|เวลาจริง',
                linkSave: 'Update Container|ปรับปรุงข้อมูล',
                linkExp:'Entry Expense|บันทึกค่าใช้จ่าย'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Bank':
            lang = {
                lblTitle: 'Banks|ธนาคาร',
                lblBankCode: 'Bank Code|รหัสธนาคาร',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblCustomsCode: 'Customs Code|รหัสธนาคารกรมศุล'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/BookAccount':
            lang = {
                lblTitle: 'Bank Accounts|สมุดบัญชีธนาคาร',
                lblchkIslocal: 'Is Local Bank?|ธนาคารในพื้นที่',
                lblBranchCode: 'Branch|รหัสสาขา',
                lblBookCode: 'Book No|เลขที่สมุดบัญชี',
                lblBookName: 'Account Name|ชื่อบัญชี',
                lblACType: 'Account Type|ประเภทบัญชี',
                lblBankCode: 'Bank Code|รหัสธนาคาร',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblBankBranch: 'Bank Branch|สาขาธนาคาร',
                lblTAddress1: 'Address (TH)|ที่อยู่(ไทย)',
                lblEAddress1: 'Address (EN)|ที่อยู่(อังกฤษ)',
                lblGLAccountCode: 'GL Code|บัญชีแยกประเภท',
                lblPhone: 'Phone|หมายเลขโทรศัพท์',
                lblFaxNumber: 'Fax|หมายเลขโทรสาร',
                lblLimitBalance: 'Minimum Balance|ยอดเงินขั้นต่ำ'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Branch':
            lang = {
                lblTitle: 'Branch|สาขา',
                lblBranchCode: 'Branch Code|สาขา',
                lblBranchName: 'Branch Name|ชื่อสาขา'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/BudgetPolicy':
            lang = {
                lblTitle: 'Budget Control Policy|มาตรฐานควบคุมงบประมาณ',
                lblBranchCode: 'Branch Code|รหัสสาขา',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|โดยทาง',
                lblID: 'Policy ID|รหัส',
                lblSICode: 'Code|รหัสค่าบริการ',
                lblSDescription: 'Bank Code|รหัสธนาคาร',
                lblTRemark: 'lblTRemark|หมายเหตุ',
                lblMaxAdvance: 'Max Advance|Max Advance',
                lblMaxCost: 'Max Cost|Max Cost',
                lblMinCharge: 'Min Charge|Min Charge',
                lblMinProfit: 'Min Profit|Min Profit',
                lblActive: 'Active|Active',
                lblLastUpdate: 'Last Update|Last Update',
                lblUpdateBy: 'Update By|Update By'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Index':
            lang = {
                lblTitle: 'System variable|ค่าคงที่ระบบ',
                lblCode: 'Config Group|กลุ่ม',
                lblKey: 'Config Key|ชื่อตัวแปร',
                lblValue: 'Config Value|ค่าของตัวแปร'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/CompanyContact':
            lang = {
                lblTitle: 'Contacts|ผู้ติดต่อ',
                lblCustCode:'Customer|ลูกค้า',
                lblItemNo: 'Code|รหัส',
                lblDepartment: 'Department|แผนก',
                lblPosition: 'Position|ตำแหน่ง',
                lblContactName: 'ContactName|ชื่อผู้ติดต่อ',
                lblEMail: 'EMail|EMail',
                lblPhone: 'Phone|หมายเลขโทรศัพท์'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Country':
            lang = {
                lblTitle: 'Country|ประเทศ',
                lblCTYCODE: 'Country Code|รหัสประเทศ',
                lblCTYName: 'Country Name|ชื่อประเทศ',
                lblCURCODE: 'Currency Code|รหัสเงินตรา',
                lblFTCODE: 'FT CODE|FT CODE',
                lblCUCODE: 'CU CODE|CU CODE'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Currency':
            lang = {
                lblTitle:'Currency|สกุลเงิน',
                lblCode: 'Currency Code|รหัสเงินตรา',
                lblTName: 'Currency Name|ชื่อประเทศ',
                lblStartDate: 'Begin Date|วันที่เริ่มต้น',
                lblFinishDate: 'Expire Date|วันที่หมดอายุ',
                lblLastUpdate: 'Last Update|เปลี่ยนแปลงล่าสุด'

            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Customers':
            lang = {
                lblTitle:'Customers|ผู้นำเข้าส่งออก',
                lblCustCode: 'Customer Code|รหัสลูกค้า',
                lblBranch: 'Branch|สาขา',
                lblCustGroup: 'Customer Group|กลุ่มลูกค้า',
                lblTaxNumber: 'Tax-Reference|Tax-Reference',
                lblCustTitle: 'Title|Title',
                lblNameThai: 'Name (TH)|ชื่อ(ไทย)',
                lblNameEng: 'English|ชื่อ(อังกฤษ)',
                lblTAddress1: 'Address (TH)|Address (TH)',
                lblEAddress1: 'Address (EN)|Address (EN)',
                lblPhone: 'Phone|หมายเลขโทรศัพท์',
                lblFaxNumber: 'FaxNumber|หมายเลขโทรสาร',
                lblDMailAddress: 'MailAddress|MailAddress',
                lblWEB_SITE: 'WEB SITE|WEB SITE',
                lblUsedLanguage: 'UsedLanguage|ภาษาที่ใช้',
                lblCustType: 'Customer Type|Customer Type',
                lblLevelGrade: 'Level|Level',
                lblTermOfPayment: 'Payment Term|เงื่อนไขการชำระเงิน',
                lblBillCondition: 'Billing Condition|เงื่อนไขการวางบิล',
                lblCreditLimit: 'Credit Limit|Credit Limit',
                lblDutyLimit: ' Duty Limit| Duty Limit',
                lblCommRate: 'Commission Rate|Commission Rate',
                lblGLAccountCode: 'GL Code|GL Code',
                lblBillToCustCode: 'Billing To|รหัสที่วางบิล',
                lblBillToBranch: 'Billing Branch|สาขาที่วางบิล',
                lblBillToCustName: 'Billing Name|ชื่อที่วางบิล',
                lblBillToAddress: 'Billing Address|ที่อยู่ที่วางบิล',
                lblTAddress: 'BLDG No/Street|ที่อยู่',
                lblTDistrict: 'District|ตำบล',
                lblTSubProvince: 'Sub District|อำเภอ',
                lblTProvince: 'Province|จังหวัด',
                lblTPostCode: 'PostCode|รหัสไปรษณี',
                lblManagerCode: 'Sales|เซลส์',
                lblCSCodeIM: 'CS Import|CS Import',
                lblCSCodeEX: 'CS Export|CS Export',
                lblCSCodeOT: ' CS Others| CS Others',
                lblConsStatus: 'Consign Status|Consign Status',
                lblCommLevel: 'Commercial Level |Commercial Level ',
                lblLoginName: 'Log in|Log in',
                lblLoginPassword: 'Password|Password'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/CustomsPort':
            lang = {
                lblTitle: 'Customs Inspection Area|ด่านศุุลกากร',
                lblAreaCode: 'Area Code|รหัสด่าน',
                lblAreaName: 'Area Name|ชื่อด่าน'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/CustomsUnit':
            lang = {
                lblTitle: 'Customs Unit|หน่วยสินค้าศุลกากร',
                lblCode: 'Unit Code|รหัสหน่วย',
                lblTName: 'Unit Name|ชื่อหน่วย'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/DeclareType':
            lang = {
                lblTitle: 'Declare Type|ประเภทใบขน',
                lblType: 'Declare Type|Declare Type',
                lblDescription: 'Description|รายละเอียด',
                lblCategory: 'Category|ประเภท',
                lblStartDate: 'Start Date|วันที่เริ่มต้น',
                lblFinishDate: 'Finish Date|วันที่สิ้นสุด',
                lblLastUpdate: 'Last Update|วันที่ล่าสุด'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/InterPort':
            lang = {
                lblTitle: 'International Port|ท่าเรือต่างประเทศ',
                lblCountryCode: 'Country Code|รหัสประเทศ',
                lblPortCode: 'Port Code|รหัสพอร์ท',
                lblPortName: 'Port Name|ชื่อพอร์ท',
                lblStartDate: 'Start Date|วันที่เริ่มต้น',
                lblFinishDate: 'Finish Date|วันที่สิ้นสุด'
                //txtLastUpdate : 'LastUpdate|LastUpdate'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Province':
            lang = {
                lblTitle: 'Province|อำเภอ/ตำบล/จังหวัด',
                lblProvinceCode: 'ProvinceCode|รหัสจังหวัด',
                lblProvinceName: 'ProvinceName|ชื่อจังหวัด',
                lblid: 'ID|ID',
                lblDistrict: 'District|ตำบล',
                lblSubProvince: 'SubProvince|อำเภอ',
                lblPostCode: 'PostCode|รหัสไปรษณี'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/ServiceCode':
            lang = {
                lblTitle: 'Service Code|รหัสค่าบริการ',
                lblType: 'Type|ประเภท',
                lblSICode: 'Service Code|รหัสค่าบริการ',
                lblNameThai: 'Name|ชื่อ(ไทย)',
                lblNameEng: 'Englisth|ชื่อ(อังกฤษ)',
                lblStdPrice: 'Price|ราคา',
                lblCurrencyCode: 'Currency|สกุลเงิน',
                lblUnitCharge: 'Unit Charge|หน่วยเรียกเก็บ',
                lblDefaultVender: 'Vender|ผุ้ให้บริการ',
                lblGLAccountCodeSales: 'GL Sales|รหัสบัญชีรายได้',
                lblGLAccountCodeCost: 'GL Cost|รหัสบัญชีต้นทุน',
                lblProcessDesc: 'Process Desc|คำอธิบาย',
                lblchkIsTaxCharge: 'Calculate VAT|คิดภาษีมูลค่าเพิ่ม',
                lblchkIsCredit: 'Customer Expenses|เป็นค่าบริการแบบเครดิต',
                lblchkIsExpense: 'Company Expenses|เป็นต้นทุน',
                lblchkIsHaveSlip: 'Must Input Slip|เป็นค่าบริการมีใบเสร็จในนามลูกค้า',
                lblchkIs50Tavi: 'Calculate 50Tavi|ต้องหัก ณ ที่จ่าย',
                lblchkIsShowPrice: 'Is Show Price|แสดงราคาให้เห็นได้',
                lblchkIsUsedCoSlip: 'Is Earnest Expense|เป็นเงินมัดจำ',
                lblExc: 'Exclude|คำนวณจากฐานภาษี',
                lblInc: 'Include|ราคารวมภาษีแล้ว',
                lblComp: 'Paid 50Tavi By Company|บริษัทเป็นผู้มีหน้าที่ หัก ณ ที่จ่าย',
                lblVend: 'Pay 50Tavi by Vender|บริษัทไม่ได้เป็นผู้หัก ณ ที่จ่าย'
            };            
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/ServiceGroup':
            lang = {
                lblTitle: 'Service Group|กลุ่มค่าบริการ',
                lblGroupCode: 'Group Code|รหัสกลุ่มค่าบริการ',
                lblGroupName: 'Group Name|ชื่อกลุ่มค่าบริการ',
                lblGLAccountCode: 'Account Code|เลขที่บัญชี',
                lblchkIsTaxCharge: 'Calculate VAT|คิดภาษีมูลค่าเพิ่ม',
                lblchkIsCredit: 'Customer Expenses|เป็นค่าบริการแบบเครดิต',
                lblchkIsExpense: 'Company Expenses|เป็นต้นทุน',
                lblchkIsHaveSlip: 'Must Input Slip|เป็นค่าบริการมีใบเสร็จในนามลูกค้า',
                lblchkIs50Tavi: 'Calculate 50Tavi|คิดหัก ณ ที่จ่ายไหม',
                lblchkIsApplyPolicy: 'Apply Policy To All| บังคับใช้ทุกค่าบริการ',
                lblSICode: 'Service Code|รหัสค่าบริการ',
                lblExc: 'Exclude|คำนวณจากฐานภาษี',
                lblInc: 'Include|ราคารวมภาษีแล้ว',
                lblComp: 'Paid 50Tavi By Company|บริษัทเป็นผู้มีหน้าที่ หัก ณ ที่จ่าย',
                lblVend: 'Pay 50Tavi by Vender|บริษัทไม่ได้เป็นผู้หัก ณ ที่จ่าย'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/ServUnit':
            lang = {
                lblTitle:'Service Units|หน่วยสินค้าและบริการ',
                lblUnitType: 'Unit Type|ประเภท',
                lblUName: 'Name|ชื่อ(ไทย)',
                lblEName: 'English|ชื่อ(อังกฤษ)',
                lblIsCTNUnit: 'Unit Type|ประเภทหน่วย'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/TransportRoute':
            lang = {
                lblTitle: 'Transport Route|เส้นทางการขนส่ง',
                lblTemplate: 'Type|ประเภท',
                lblPlace1: 'Pickup|สถานที่รับสินค้า',
                lblAddress1: 'Address|ที่อยู่',
                lblContact1: 'Contact|ผู้ติดต่อ',
                lblPlace2: 'Delivery|สถานที่ส่งสินค้า',
                lblAddress2: 'Address|ที่อยู่',
                lblContact2: 'Contact|ผู้ติดต่อ',
                lblPlace3: 'Container Yard|ลานตู้สินค้า',
                lblAddress3: 'Address|ที่อยู่',
                lblContact3: 'Contact|ผู้ติดต่อ',
                lblPlace4: 'Port|ท่าตรวจปล่อย',
                lblAddress4: 'Address|ที่อยู่',
                lblContact4: 'Contact|ผู้ติดต่อ',
                lblBranchCode: 'Branch|สาขา',
                lblLocation: 'Location|สถานที่',
                lblVender: 'Vender|ผู้ให้บริการ',
                lblCustomer: 'Customer|ลูกค้า',
                lblExpenseCode: 'Expense Code|รหัสค่าใช้จ่าย',
                lblAmount: 'Amount|ยอดค่าใช้จ่าย',
                lblChargeCode: 'Charge Code|รหัสค่าบริการ',
                lblCAmount: 'Amount|ยอดค่าบริการ'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Users':
            lang = {
                lblTitle:'Users|พนักงาน',
                lblUser: 'User ID|รหัสพนักงาน',
                lblUPassword: 'Password|รหัสผ่าน',
                lblDeptID: 'Department|รหัสแผนก',
                lblTName: 'Name|ชื่อ(ไทย)',
                lblEName: 'Englisth|ชื่อ(อังกฤษ)',
                lblTPosition: 'Position|ตำแหน่ง',
                lblUPosition: 'Level|ระดับ',
                lblUserUpline: 'Supervisor| หัวหน้างาน',
                lblEMail : 'EMail|EMail',
                lblMobilePhone: 'MobilePhone|หมายเลขโทรศัพท์',
                lblUsedLanguage : 'UsedLanguage|ภาษาที่ใช้'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/UserAuth':
            lang = {
                lblTitle: 'User Authorize|กำหนดสิทธิผู้ใช้งาน',
                lblAppID: 'Module|กลุ่มงาน',
                lblFunction: 'Function|เมนูการทำงาน',
                lblSetBy: 'Set By|กำหนดตาม',
                lblManage: 'Allow Manage|เข้าใช้งาน',
                lblInsert: 'Allow Add|เพิ่มได้',
                lblRead: 'Allow Search|ค้นหาได้',
                lblEdit: 'Allow Edit|บันทึกข้อมูลได้',
                lblDelete: 'Allow Delete|ลบ/ยกเลิกได้',
                lblPrint:'Allow Print|พิมพ์ข้อมูลได้'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Venders':
            lang = {
                lblTitle: 'Venders|ผู่้ให้บริการ',
                lblVenCode: 'Vender Code|รหัสเวนเดอร์',
                lblBranchCode: 'Branch|สาขา',
                lblTaxNumber: 'Tax Number|เลขประจำตัวผู้เสียภาษี',
                lblVenTitle : 'Title|คำนำหน้า',
                lblTName: 'Name|ชื่อ(ไทย)',
                lblEnglish: 'English|ชื่อ(อังกฤษ)',
                lblTAddress1: 'Address (TH)|ที่อยู่ (ไทย)',
                lblEAddress1: 'Address (EN)|ที่อยู่ (อังกฤษ)',
                lblPhone: 'Phone|โทรศัพท์',
                lblFaxNumber: 'Fax|แฟกซ์',
                lblWEB_SITE: 'Web/E-mail|Web/E-mail',
                lblGLAccountCode: 'GL Code|GL Code',
                lblContact:'Contact Information|ข้อมูลผู้ติดต่อ',
                lblContactAcc: 'Account|บัญชี',
                lblContactSale: 'Sales|การตลาด'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_MAS/Vessel':
            lang = {
                lblTitle:'Vessel|พาหนะ',
                lblRegsNumber: 'Register Code|รหัส',
                lblTName: 'Name|ชื่อ',
                lblVesselType: 'Type|ประเภท'
            };
            SetLanguage(lang);
            break;
        case 'Menu/Index':
            lang = {
                lblTitle: 'Main Dashboard|ภาพรวมการทำงาน',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Transport By|ลักษณะงานขนส่ง',
                lblDateFrom: 'Inspect Date From|ช่วงวันที่ตรวจปล่อย',
                lblDateTo: 'To|ถึงวันที่',
                lblAutoRefresh: 'Auto Refresh|ปรับปรุงข้อมูลอัตโนมัติ',
                btnUpdate: 'Update|ปรับปรุงข้อมูล',
                btnAddJob: 'New|สร้างงานใหม่',
                lblGrid1: 'Volume By Status|จำนวนงานตามสถานะ',
                lblGrid2: 'Status By Job Type|จำนวนงานตามประเภทงาน',
                lblGrid3: 'Status By Customer|จำนวนงานตามลูกค้า'
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
        case 'MODULE_SALES/QuoApprove':
            lang = {
                lblTitle: 'Approve Quotation|อนุมัติใบเสนอราคา',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Date From|จากวันที่',
                lblDateTo: 'Date To|ถึงวันที่',
                lblReqBy: 'Sales By|เสนอราคาโดย',
                lblCustCode: 'Customer|ลูกค้า',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Approve Document|เอกสารที่เลือก',
                linkAppr:'Approve|อนุมัติเอกสาร'
            };
            SetLanguage(lang);
            break;
        case 'MODULE_SALES/Quotation':
            lang = {
                lblTitle: 'Quotation|ใบเสนอราคา',
                lblSearch: 'Search|ค้นหา',
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
                lblDiscountF: 'Discount (F)|ส่วนลด (ตปท)',
                linkHeader: 'Header|ส่วนควบคุม',
                linkDetail: 'Detail|ส่วนรายการ'
            };
            SetLanguage(lang);
            break;
    }    
}
