let mainLanguage = 'EN';
let langMessage = GetLangMessage();
let langMenu = GetLangMenu();
function SetLanguage(lang) {
    for (let id in lang) {
        let obj = $('#' + id);
        if (obj !== null) {
            let str = '';
            //if (id.substr(0, 3) == 'mnu') {
                //str += '- ';
            //}
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
function SetGridLang(id, lang) {
    let tbcols = $(id + ' thead th').length;
    for (let idx = 0; idx < tbcols; idx++) {
        let findLang = lang[idx];
        if (findLang !== undefined) {
            if (mainLanguage == "EN") {
                $(id + ' thead th:eq(' + idx + ')').html(findLang.split('|')[0]);
            }
            if (mainLanguage == "TH") {
                $(id + ' thead th:eq(' + idx + ')').html(findLang.split('|')[1]);
            }
        }
    }
}
function GetLanguage(msg) {
    if (mainLanguage == "TH") {
        //let lang = GetLangMessage();
        let findLang = langMessage[msg];
        if (findLang !== undefined) {
            return findLang;
        }
    }
    return msg;
}
function GetLangGrid(module, id) {
    let gridLang = [];
    switch (module) {
        case 'Acc/GenerateBilling':
            if (id == '#tbHeader') {
                gridLang = [
                    "Inv No|เลขที่ใบแจ้งหนี้",
                    "Inv Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "Reference Number|เลขที่อ้างอิง",
                    "Cust.Adv|รับล่วงหน้า",
                    "Advance|ทดรองจ่าย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Inv No|เลขที่ใบแจ้งหนี้",
                    "Inv Date|วันที่เอกสาร",
                    "Advance|ทดรองจ่าย",
                    "Transport|ค่าขนส่ง",
                    "Service|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }

            break;
        case 'Acc/GenerateReceipt':
            if (id == '#tbSummary') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.date|วันที่เอกสาร",
                    "Billing To|เก็บเงินที่",
                    "Ref.No|เลขที่อ้างอิง",
                    "Advance|ทดรองจ่าย"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.date|วันที่เอกสาร",
                    "Billing To|เก็บเงินที่",
                    "Ref.No|เลขที่อ้างอิง",
                    "Description|ค่าใช้จ่าย",
                    "Advance|ทดรองจ่าย"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.date|วันที่เอกสาร",
                    "No|ลำดับ",
                    "Code|รหัส",
                    "Description|ค่าใช้จ่าย",
                    "Advance|ทดรองจ่าย"
                ];
            }

            break;
        case 'Acc/GenerateTaxInv':
            if (id == '#tbSummary') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.date|วันที่เอกสาร",
                    "Billing To|เก็บเงินที่",
                    "Ref.No|เลขที่อ้างอิง",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|WHT",
                    "NET|สุทธิ"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.date|วันที่เอกสาร",
                    "Billing To|เก็บเงินที่",
                    "Ref.No|เลขที่อ้างอิง",
                    "Expenses|คำอธิบาย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|WHT",
                    "NET|สุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.date|วันที่เอกสาร",
                    "No|ลำดับ",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|WHT",
                    "NET|สุทธิ"
                ];
            }
            break;
        case 'MODULE_ACC/Billing':
            if (id == '#tbHeader') {
                gridLang = [
                    "#|#",
                    "Billing No|ใบวางบิล",
                    "Doc Date|วันที่วางบิล",
                    "Customer|ลูกค้า",
                    "Remark|หมายเหตุ",
                    "Confirm Date|วันที่รับวางบิล",
                    "Due Date|กำหนดชำระ",
                    "Advance|ทดรองจ่าย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "Inv.Date|วันที่เอกสาร",
                    "Cust.Adv|รับล่วงหน้า",
                    "Advance|ทดรองจ่าย",
                    "Service (No VAT)|ค่าบริการ(ยกเว้น)",
                    "Service (VAT)|ค่าบริการ",
                    "Discount|ส่วนลด",
                    "WH-tax|หัก ณ ที่จ่าย",
                    "VAT|ภาษีมูลค่าเพิ่ม",
                    "Total|ยอดสุทธิ"
                ];
            }

            break;
        case 'MODULE_ACC/Cheque':
            if (id == '#tbControl') {
                gridLang = [
                    "Doc No|เลขที่เอกสาร",
                    "Voucher Date|วันที่ใบสำคัญ",
                    "Customer|ลูกค้า",
                    "Remark|หมายเหตุ",
                    "Job No|หมายเลขงาน",
                    "Cheque No|เลขที่เช็ค",
                    "Chq.Date|วันที่เช็ค",
                    "Chq.Total|ยอดเช็ค",
                    "Currency|สกุลเงิน",
                    "Control No|เลขที่ลงบัญชี"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Cheque|ยอดเช็ค",
                    "Currency|สกุลเงิน",
                    "Voucher|เลขที่ใบสำคัญ",
                    "Chq.No|เลขที้่เช็ค",
                    "Chq.Date|วันที่เช็ค",
                    "Bank|ธนาคาร",
                    "Branch|สาขา",
                    "Pay Form/To|ออกให้กับ"
                ];
            }

            break;
        case 'MODULE_ACC/Costing':
            if (id == '#tbDetail') {
                gridLang = [
                    "#|#",
                    "Clr.No|เลขที่ใบปิด",
                    "Exp.Code|รหัส",
                    "Description|รายละเอียด",
                    "Inv/Tax.No|ใบแจ้งหนี้/ใบเสร็จ",
                    "Advance|คชจ.จ่ายแทน",
                    "Charges|ค่าบริการ",
                    "Cost|ต้นทุน",
                    "Profit|กำไรขั้นต้น"
                ];
            }

            break;
        case 'MODULE_ACC/CreditNote':
            if (id == '#tbHeader') {
                gridLang = [
                    "#|#",
                    "Doc.No|เลขที่เอกสาร",
                    "Issue Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "Invoice No|ใบแจ้งหนี้",
                    "Remark|หมายเหตุ",
                    "Total|ยอดปรับปรุง"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "#|#",
                    "Invoice No|ใบแจ้งหนี้",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Original|ยอดที่ผิด",
                    "Correct|ยอดที่ถูก",
                    "Diff|ส่วนต่าง",
                    "VAT|VAT",
                    "Net|ยอดรวม",
                    "Currency|สกุลเงิน",
                    "Rate|อัตราแลกเปลี่ยน",
                    "Total|ยอดสุทธิ"
                ];
            }
            if (id == '#tbInvoice') {
                gridLang = [
                    "Inv.No|ใบแจ้งหนี้",
                    "No|รายการที่",
                    "Description|คำอธิบาย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "Net|สุทธิ"
                ];
            }

            break;
        case 'MODULE_ACC/Expense':
            if (id == '#tbHeader') {
                gridLang = [
                    "Bill.No|เลขที่บิล",
                    "Doc Date|วันที่รับวางบิล",
                    "Vender|ผู้ให้บริการ",
                    "Contact|ผู้ติดต่อ",
                    "Container No|เบอร์ตู้คอนเทนเนอร์",
                    "Invoice.No|เลขที่ใบแจ้งหนี้",
                    "Amount|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|สุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "#|#",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Job|หมายเลขงาน",
                    "Remark|หมายเหตุ",
                    "Amount|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|สุทธิ"
                ];
            }

            break;
        case 'MODULE_ACC/GenerateInv':
            if (id == '#tbHeader') {
                gridLang = [
                    "Job No|หมายเลขงาน",
                    "Clr No|ใบปิดค่าใช้จ่าย",
                    "Cont/Car No|เบอร์ตู้/ทะเบียนรถ",
                    "Customer|ลูกค้า",
                    "Description|ค่าใช้จ่าย",
                    "Advance|ทดรองจ่าย",
                    "Cost|ต้นทุน",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "#|#",
                    "Job No|หมายเลขงาน",
                    "Description|ค่าใช้จ่าย",
                    "Slip No|เลขที่ใบเสร็จ",
                    "Advance|ทดรองจ่าย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }
            if (id == '#tbCheque') {
                gridLang = [
                    "#|#",
                    "Cheque No|เลขที่เช็ค",
                    "Amount|ยอดที่ใช้"
                ];
            }
            if (id == '#tbCost') {
                gridLang = [
                    "#|#",
                    "Job No|หมายเลขงาน",
                    "Description|ค่าใช้จ่าย",
                    "Amount|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "Net|ยอดสุทธิ"
                ];
            }

            break;
        case 'MODULE_ACC/GLNote':
            gridLang = [
                "#|#",
                "Code|รหัส",
                "Description|คำอธิบาย",
                "Ref.No|เลขที่อ้างอิง",
                "Debit|เดบิต",
                "Credit|เครดิต"
            ];

            break;
        case 'MODULE_ACC/Invoice':
            if (id == '#tbHeader') {
                gridLang = [
                    "#|#",
                    "Inv No|ใบแจ้งหนี้",
                    "Inv Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "BillTo|วางบิล",
                    "Billing|ใบวางบิล",
                    "Reference|อ้างถึง",
                    "Cust Adv|รับล่วงหน้า",
                    "Advance|ทดรองจ่าย",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "No|ลำดับ",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Slip.No|เลขที่ใบเสร็จ",
                    "Advance|ทดรองจ่าย",
                    "Charge|ค่าบริการ",
                    "Currency|สกุลเงิน",
                    "Amount|ยอดเงิน",
                    "Discount|ส่วนลด",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|สุทธิ"
                ];
            }
            break;
        case 'MODULE_ACC/Payment':
            if (id == '#tbHeader') {
                gridLang = [
                    "Doc.No|เลขที่บิล",
                    "Due.Date|กำหนดชำระ",
                    "Vender|ผู่ให้บริการ",
                    "Contact|ผู้ติดต่อ",
                    "Ref.No|เลขอ้างอิง",
                    "Inv.No|ใบแจ้งหนี้",
                    "Expense|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|ยอดหัก",
                    "Net|สุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Type|ประเภท",
                    "Date|วันที่เอกสาร",
                    "For|สำหรับ",
                    "Company|ชื่อบริษัท",
                    "Branch|สาขา",
                    "Doc.Total|ยอดเอกสาร",
                    "Paid|ยอดที่จ่าย"
                ];
            }
            break;
        case 'MODULE_ACC/PettyCash':
            if (id == '#tbControl') {
                gridLang = [
                    "Doc No|เลขที่เอกสาร",
                    "Voucher Date|วันที่ใบสำคัญ",
                    "Remark|หมายเหตุ",
                    "Type|ประเภท",
                    "Book.Code|สมุดบัญชี",
                    "Trans.No|เลขที่อ้างอิง",
                    "Trans.Date|วันที่ทำรายการ",
                    "Trans.Total|ยอดเงิน",
                    "Currency|สกุลเงิน",
                    "Control No|เลขที่ลงบัญชี"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Cash|ยอดเงินสด/โอน",
                    "Currency|สกุลเงิน",
                    "Voucher|เลขที่ใบสำคัญ",
                    "Doc.No|เลขที้่สลิป",
                    "Tr.Date|วันที่รายการ",
                    "Bank|ธนาคาร",
                    "Branch|สาขา",
                    "Book Acc|สมุดบัญชี"
                ];
            }
            break;
        case 'MODULE_ACC/Receipt':
            if (id == '#tbHeader') {
                gridLang = [
                    "#|#",
                    "Receive No|เลขที่ใบเสร็จ",
                    "Issue Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "Ref.No|เลขที่อ้างอิง",
                    "Remark|หมายเหตุ",
                    "Total|ยอดสุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "#|#",
                    "Inv.No|เลขที่ใบแจ้งหนี้",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Cash|เงินสด",
                    "Transfer|เงินโอน",
                    "Cheque|เช็ค",
                    "Credit|เครดิต",
                    "Amt|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "Total|ยอดสุทธิ"
                ];
            }
            break;
        case 'MODULE_ACC/RecvInv':
            if (id == '#tbSummary') {
                gridLang = [
                    "Inv.No|เลขที่ใบแจ้งหนี้",
                    "Advance|ทดรองจ่าย",
                    "Service|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|ยอดหัก",
                    "Net|สุทธิ"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Inv.No|เลขที่ใบแจ้งหนี้",
                    "Inv.Date|วันที่ใบแจ้งหนี้",
                    "Receipt.No|เลขที่ใบเสร็จ",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Advance|ทดรองจ่าย",
                    "Service|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|ยอดหัก",
                    "Net|สุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Type|ประเภท",
                    "Date|วันที่เอกสาร",
                    "For|สำหรับ",
                    "Company|ชื่อบริษัท",
                    "Branch|สาขา",
                    "Doc.Total|ยอดเอกสาร",
                    "Paid|ยอดที่จ่าย"
                ];
            }
            break;
        case 'MODULE_ACC/TaxInvoice':
            if (id == '#tbHeader') {
                gridLang = [
                    "#|#",
                    "Receive No|เลขที่ใบเสร็จ",
                    "Issue Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "Ref.No|เลขที่อ้างอิง",
                    "Remark|หมายเหตุ",
                    "Charge|ค่าบริการ",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "NET|ยอดสุทธิ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "#|#",
                    "Inv.No|เลขที่ใบแจ้งหนี้",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Cash|เงินสด",
                    "Transfer|เงินโอน",
                    "Cheque|เช็ค",
                    "Credit|เครดิต",
                    "Amt|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "Net|ยอดสุทธิ"
                ];
            }
            break;
        case 'MODULE_ACC/Voucher':
            if (id == '#tbControl') {
                gridLang = [
                    "Control No|เลขที่ลงบัญชี",
                    "Voucher Date|วันที่ใบสำคัญ",
                    "Customer|ลูกค้า",
                    "Remark|หมายเหตุ",
                    "Voucher|เลขที่ใบสำคัญ",
                    "Chq.No|เลขที่เช็ค",
                    "Tr.Date|วันที่ทำรายการ",
                    "Chq.Total|ยอดเช็ค",
                    "Cash.Total|ยอดเงินสด",
                    "Cred.Total|ยอดเครดิต",
                    "Currency|สกุลเงิน",
                    "Doc.No|เลขที่เอกสาร"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Cheque.Amt|ยอดเช็ค",
                    "Cash.Amt|ยอดเงินสด",
                    "Credit.Amt|ยอดเครดิต",
                    "Currency|สกุลเงิน",
                    "Voucher|เลขที่ใบสำคัญ",
                    "Chq.No|เลขที่เช็ค",
                    "Tr.Date|วันที่ทำรายการ",
                    "Bank|ธนาคาร",
                    "Branch|สาขา",
                    "Pay From/To|ออกให้กับ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Type|ประเภท",
                    "Date|วันที่เอกสาร",
                    "For|สำหรับ",
                    "Company|ชื่อบริษัท",
                    "Branch|สาขา",
                    "Doc.Total|ยอดเอกสาร",
                    "Paid|ยอดที่จ่าย"
                ];
            }
            break;
        case 'MODULE_ACC/WHTax':
            if (id == '#tbControl') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Doc.Date|วันที่เอกสาร",
                    "Tax Issuer|ผู้มีหน้าที่หัก",
                    "Tax Agent|กระทำการแทน",
                    "Tax Payer|ผู้ถูกหัก",
                    "Job No|หมายเลขงาน",
                    "Inv No|อินวอยลูกค้า",
                    "Ref No|เลขที่อ้างอิง",
                    "Amount|ยอดเงินได้",
                    "Tax|ยอดภาษี"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "No|No",
                    "Type|ประเภท",
                    "Date|วันที่จ่าย",
                    "Amount|ยอดเงิน",
                    "Tax Rate|อัตรา",
                    "Tax|ภาษี",
                    "Desc|คำอธิบาย",
                    "Job No|หมายเลขงาน",
                    "Ref No|เลขที่อ้างอิง"
                ];
            }
            break;
        case 'MODULE_ADM/Role':
            if (id == '#tbHeader') {
                gridLang = [
                    "ID|รหัส",
                    "Role|บทบาท",
                    "Group|แผนก"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "User ID|รหัสพนักงาน",
                    "User Name|ชื่อพนักงาน"
                ];
            }
            if (id == '#tbPolicy') {
                gridLang = [
                    "Module|รหัส",
                    "Function|การทำงาน",
                    "Authorize|สิทธิ์การใช้งาน"
                ];
            }
            break;
        case 'MODULE_ADV/Approve':
            if (id == '#tbHeader') {
                gridLang = [
                    "Advance No|เลขที่ใบเบิก",
                    "Req.date|วันที่ขอเบิก",
                    "Job Number|หมายเลขงาน",
                    "Inv No|อินวอยลูกค้า",
                    "Customer|ลูกค้า",
                    "Total|ยอดเบิก",
                    "WHT|หัก ณ ที่จ่าย",
                    "Req.By|ผู้่ขอเบิก"
                ];
            }
            break;
        case 'MODULE_ADV/CreditAdv':
            if (id == '#tbControl') {
                gridLang = [
                    "Doc No|เลขที่เอกสาร",
                    "Date|วันที่เบิกเงิน",
                    "Customer|ลูกค้า",
                    "Remark|หมายเหตุ",
                    "Job No|หมายเลขงาน",
                    "Cheque No|เลขที่เช็ค",
                    "Chq.Date|วันที่เช็ค",
                    "Chq.Total|ยอดเช็ค",
                    "Cash.Total|ยอดเงินสด",
                    "Credit.Total|ยอดเครดิต",
                    "Currency|สกุลเงิน",
                    "Control No|เลขที่ลงบัญชี"
                ];
            }
            if (id == '#tbHeader') {
                gridLang = [
                    "Chq.Amt|ยอดเช็ค",
                    "Cash.Amt|ยอดเงินสด",
                    "Credit.Amt|ยอดเครดิต",
                    "Currency|สกุลเงิน",
                    "Voucher|เลขที่ใบสำคัญ",
                    "Chq.No|เลขที่เช็ค",
                    "Chq.Date|วันที่เช็ค",
                    "Bank|ธนาคาร",
                    "Branch|สาขา",
                    "Pay Form/To|ผู้ชำระเงิน"
                ];
            }
            break;
        case 'MODULE_ADV/Index':
            if (id == '#tbHeader') {
                gridLang = [
                    "Advance No|เลขที่ใบเบิก",
                    "Date|วันที่เบิก",
                    "Customer|ลูกค้า",
                    "Request By|ผู้ขอเบิก",
                    "Job Number|หมายเลขงาน",
                    "Cust Inv|อินวอยลูกค้า",
                    "Status|สถานะ",
                    "Total|ยอดเงิน",
                    "W/T|หัก ณ ที่จ่าย",
                    "W/T No|เลขที่ใบหัก",
                    "A/P No|เลขที่บิลค่าใช้จ่าย",
                    "Request Amt|ยอดที่รับเงิน"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Edit|Edit",
                    "Exp.Code|รหัสค่าใช้จ่าย",
                    "Description|วัตถุประสงค์",
                    "Job|หมายเลขงาน",
                    "Currency|สกุลเงิน",
                    "Rate|อัตราแลกเปลี่ยน",
                    "Qty|จำนวน",
                    "Price|ราคา",
                    "Amount|ยอดเงิน",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "Net|สุทธิ"
                ];
            }
            break;
        case 'MODULE_ADV/Payment':
            if (id == '#tbHeader') {
                gridLang = [
                    "Advance No|เลขที่ใบเบิก",
                    "Req.Date|วันที่ขอเบิก",
                    "Job No|หมายเลขงาน",
                    "Cust.Inv.No|อินวอยลูกค้า",
                    "Customer|ลูกค้า",
                    "Cash/Transfer|เงินสด/โอน",
                    "Company Chq (BFT)|เช็คบริษัท",
                    "Customer Chq|เช็คลูกค้า",
                    "Credit|เครดิต",
                    "Total|ยอดรวม",
                    "WHT|ยอดหัก",
                    "Req.By|ผู้ขอเบิก"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Type|ประเภท",
                    "Date|วันที่เอกสาร",
                    "For|สำหรับ",
                    "Company|ชื่อบริษัท",
                    "Branch|สาขา",
                    "Doc.Total|ยอดเอกสาร",
                    "Paid|ยอดที่จ่าย"
                ];
            }
            break;
        case 'MODULE_CLR/Approve':
            if (id == '#tbHeader') {
                gridLang = [
                    "Clearing No|เลขที่ใบปิด",
                    "Clr.Date|วันที่ปิด",
                    "Job Number|หมายเลขงาน",
                    "Cust-Inv No|อินวอยลูกค้่า",
                    "Customer|ลูกค้า",
                    "Adv.No|เลขที่ใบเบิก",
                    "Total.Adv|ยอดเบิก",
                    "Total.Clr|ยอดปิดบัญชี",
                    "WHT|ยอดหัก"
                ];
            }
            break;
        case 'MODULE_CLR/Earnest':
            if (id == '#tbHeader') {
                gridLang = [
                    "Clear.No|เลขที่ใบปิด",
                    "Clr.date|วันที่เอกสาร",
                    "Job No|หมายเลขงาน",
                    "Inv.No|อินวอยลูกค้า",
                    "Customer|ลูกค้า",
                    "Adv.No|ใบเบิก",
                    "Adv.Total|ยอดเบิก",
                    "Clr.Total|ยอดปิด",
                    "SlipNo|เลชที่ใบเสร็จ"
                ];
            }
            break;
        case 'MODULE_CLR/Index':
            if (id == '#tbHeader') {
                gridLang = [
                    "Clear No|เลขที่ใบปิด",
                    "Date|วันที่ทำรายการ",
                    "Customer|ลูกค้า",
                    "Request By|ผู้ขอเบิก",
                    "Job Number|หมายเลขงาน",
                    "Cust Inv|อินวอยลูกค้า",
                    "Status|สถานะ",
                    "Clr.Total|ยอดปิด",
                    "Container|เบอร์ตู้",
                    "Adv No|จากใบเบิก",
                    "Adv.Total|ยอดเบิก",
                    "Remark|หมายเหตุ"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Edit|Edit",
                    "Job|หมายเลขงาน",
                    "Code|รหัส",
                    "Description|คำอธิบาย",
                    "Adv No|เลขที่ใบเบิก",
                    "Advance|ยอดเบิก",
                    "Clear|ยอดปิด",
                    "VAT|VAT",
                    "WHT|หัก ณ ที่จ่าย",
                    "Net|ยอดสุทธิ",
                    "Currency|สกุลเงิน",
                    "Slip No|เลขที่ใบเสร็จ"
                ];
            }
            if (id == '#tbAdvance') {
                gridLang = [
                    "Adv.No|เลขที่ใบเบิก",
                    "Adv.Date|วันที่เบิก",
                    "#|#",
                    "Code|รหัส",
                    "Expense|ค่าใช้จ่าย",
                    "Job|หมายเลขงาน",
                    "Currency|สกุลเงิน",
                    "Rate|อัตราแลกเปลี่ยน",
                    "Qty|จำนวน",
                    "Unit|หน่วย",
                    "Balance|คงเหลือ",
                    "Used|ใช้ไป"
                ];
            }
            if (id == '#tbPayment') {
                gridLang = [
                    "Pay.Bill No|เลขที่บิลค่าใช้จ่าย",
                    "Due Date|กำหนดชำระ",
                    "#|#",
                    "Code|รหัส",
                    "Expense|ค่าใช้จ่าย",
                    "Job|หมายเลขงาน",
                    "Currency|สกุลเงิน",
                    "Rate|อัตราแลกเปลี่ยน",
                    "Qty|จำนวน",
                    "Unit|หน่วย",
                    "Total|ยอดเงิน",
                    "WHT|หัก ณ ที่จ่าย"
                ];
            }
            break;
        case 'MODULE_CLR/Receive':
            if (id == '#tbHeader') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "#|#",
                    "Description|ค่าใช้จ่าย",
                    "Adv.Total|ยอดเบิก",
                    "Clr.Net|ยอดปิด",
                    "Clr.VAT|VAT",
                    "Clr.WHT|ยอดหัก",
                    "Refund|รับคืน",
                    "Payback|จ่ายเพิ่ม"
                ];
            }
            if (id == '#tbDetail') {
                gridLang = [
                    "Doc.No|เลขที่เอกสาร",
                    "Type|ประเภท",
                    "Date|วันที่เอกสาร",
                    "For|สำหรับ",
                    "Company|บริษัท",
                    "Branch|สาขา",
                    "Total|ยอดเอกสาร",
                    "Paid|ยอดชำระ"
                ];
            }
            break;
        case 'MODULE_CS/ShowJob':
            if (id == "#tbTracking") {
                gridLang = [
                    "Doc Date|วันที่เอกสาร",
                    "Type|ประเภทเอกสาร",
                    "Doc No|เลขที่เอกสาร",
                    "Item|ลำดับที่",
                    "Description|รายละเอียด",
                    "Amount|ยอดเงิน",
                    "Status|สถานะ"
                ];
            }
            if (id == "#tbLog") {
                gridLang = [
                    "Date|วันที่บันทึก",
                    "Action|บันทึกข้อความ",
                    "User|ผู้บันทึก"
                ];
            }
            break;
        case 'MODULE_CS/Transport':
            if (id == '#tbDetail') {
                gridLang = [
                    "Container No|เบอร์ตู้",
                    "Container Size|ขนาดตู้",
                    "Seal|เบอร์ซีล",
                    "Qty|จำนวน",
                    "Status|สถานะงาน",
                    "G.W|น้ำหนักรวม",
                    "Pickup Date|วันที่รับตู้",
                    "Delivery No|เลขที่ใบส่งของ",
                    "V.Bill|วางบิลมาแล้ว",
                    "S.Clear|เคลียร์แล้ว",
                    "Balance|คงเหลือ"
                ];
            }
            if (id == '#tbPrice') {
                gridLang = [
                    "Cost.Code|รหัสต้นทุน",
                    "Description|คำอธิบาย",
                    "Cost Amt|ยอดเงินต้นทุน",
                    "Charge to|รหัสค่าบริการ",
                    "Charge Amt|บอดเรียกเก็บ"
                ];
            }
            if (id == '#tbExpense') {
                gridLang = [
                    "Cost.Code|รหัสต้นทุน",
                    "Description|คำอธิบาย",
                    "Cost Amt|ยอดเงินต้นทุน"
                ]
            }
            if (id == '#tbPayment') {
                gridLang = [
                    "Doc.No|เลขที่บิล",
                    "Date|กำหนดชำระ",
                    "Inv No|เลขที่ใบแจ้งหนี้",
                    "Cont.No|เบอร์ตู้",
                    "Total|รวมเงิน"
                ];
            }
            break;
        case 'MODULE_CS/Index':
            gridLang = [
                "Job Number|หมายเลขงาน",
                "Open Date|วันที่เปิดงาน",
                "Job Status|สถานะงาน",
                "Booking No|เลขที่ booking",
                "HAWB|เลขที่ HBL",
                "Customer Inv|อินวอยลูกค้า",
                "Im-Exporter|ชื่อลูกค้า",
                "BillTo/Consignee|ชื่อผู้ซื้อชาย",
                "Cust Ref.No|เลขที่อ้างอิงลูกค้า",
                "ETD Date|วันที่ออกจากท่า",
                "ETA Date|วันที่เทียบท่า"
            ];
            break;
        case 'MODULE_ADV/EstimateCost':
            gridLang = [
                "Code|รหัส",
                "Name|ค่าใช้จ่าย",
                "Status|ความจำเป็น",
                "Job No|หมาบเลขงาน",
                "Charge|ยอดเงิน",
                "Clearing No|เลขที่ใบปิด",
                "Clear.Amt|ยอดใช้จริง",
            ];
            break;
        case 'MODULE_MAS/BookAccount':
            gridLang = [
                "Cash|รวมทั้งสิ้น",
                "Cash In Bank|ในธนาคาร",
                "Chq On Hand|เช็คในมือ",
                "Chq Return|เช็คคืน",
                "Credit|ยอดเครดิต",
                "Balance|ยอดคงเหลือ"
            ];
            break;
        case 'MODULE_MAS/BudgetPolicy':
            gridLang = [
                "Code|รหัส",
                "Description|คำอธิบาย",
                "Max-Advance|เพดานยอดเบิก",
                "Max-Cost|เพดานต้นทุน",
                "Min=charge|ค่าบริการขั้นต่ำ",
                "Min-profit|กำไรขั้นต่ำ"
            ];
            break;
        case 'MODULE_MAS/CompanyContact':
            gridLang = [
                "No|No",
                "Name|ชื่อ",
                "Department|ฝ่าย/แผนก",
                "Position|ตำแหน่ง",
                "Email|อีเมล์/ช่องทางการติดต่อ",
                "Phone|เบอร์โทร/มือถือ"
            ];
            break;
        case 'MODULE_MAS/Index':
            gridLang = [
                "Group|กลุ่ม",
                "Code|รหัส",
                "Value|ค่า"
            ];
            break;
        case 'MODULE_MAS/Province':
            gridLang = [
                "Distirct|อำเภอ/เขต",
                "Sub District|ตำบล",
                "Zip Code|รหัสไปรษณีย์"
            ];
            break;
        case 'MODULE_MAS/ServiceGroup':
            gridLang = [
                "Code|รหัส",
                "Thai Desc|คำอธิบาย(ไทย)",
                "Eng Desc|คำอธิบาย(อังกฤษ)"
            ];
            break;
        case 'MODULE_MAS/TransportRoute':
            if (id == "#tbPrice") {
                gridLang = [
                    "Vender|ผู้ให้บริการ",
                    "Cust|ลูกค้า",
                    "Cost.Code|รหัสต้นทุน",
                    "Cost.Desc|ความหมายค่าใช้จ่าย",
                    "Cost.Amt|ยอดจ่ายเงิน",
                    "Chg.Code|รหัสค่าบริการ",
                    "Chg.Amt|ยอดเรียกเก็บได้",
                    "Location|เส้นทาง"
                ];
            }
            if (id == "#tbDetail") {
                gridLang = [
                    "Route ID|รหัสเส้นทาง",
                    "Route Detail|เส้นทาง",
                    "Edit|แก้ไช"
                ];
            }
            if (id == "#lstPlace1") {
                gridLang = ["Pickup|รับตู้ที่/โหลดสินค้าที่"];
            }
            if (id == "#lstPlace2") {
                gridLang = ["Delivery|สถานที่ส่งมอบของ"];
            }
            if (id == "#lstPlace3") {
                gridLang = ["Return|คืนตู้ที่"];
            }
            if (id == "#lstPlace4") {
                gridLang = ["Condition|เงื่อนไข"];
            }
            break;
        case 'MODULE_MAS/UserAuth':
            gridLang = [
                "ID|รหัส",
                "Description|คำอธิบาย"
            ];
            break;
        case 'MODULE_MAS/Users':
            if (id == '#tbRole') {
                gridLang = [
                    "ID|รหัส",
                    "Description|บทบาท"
                ];
            }
            if (id == '#tbAuthor') {
                gridLang = [
                    "Id|รหัส",
                    "Function|ฟังก์ชั่นการทำงาน",
                    "Authorize|สิทธิ์การใช้งาน"
                ];
            }
            break;
        case 'MODULE_SALES/QuoApprove':
            if (id == '#tbHeader') {
                gridLang = [
                    "Quotation No|เลขที่ใบเสนอราคา",
                    "Quotation Date|วันที่เสนอราคา",
                    "Salesman|ผู้เสนอราคา",
                    "Remark|หมายเหตุ",
                    "Contact|ผู้ติดต่อ",
                    "Billing To|เก็บเงินที่",
                    "Refer Q.No|อ้างถึงใบเสนอราคาเลขที่"
                ];
            }
            break;
        case 'MODULE_SALES/Quotation':
            if (id == "#tbHeader") {
                gridLang = [
                    "#|#",
                    "Quotation No|เลขที่ใบเสนอราคา",
                    "Doc Date|วันที่เอกสาร",
                    "Customer|ลูกค้า",
                    "Billing To|เก็บเงินที่",
                    "Remark|หมายเหตุ",
                    "Contact Name|ผู้ติดต่อ",
                    "Manager Name|ผู้เสนอราคา",
                    "Approve Date|วันที่อนุมัติ"
                ];
            }
            if (id == "#tbDetail") {
                gridLang = [
                    "#|#",
                    "Seq|หัวข้อ",
                    "Job Type|ประเภทงาน",
                    "Ship By|ลักษณะงาน",
                    "Description|คำอธิบาย"
                ];
            }
            if (id == "#tbItem") {
                gridLang = [
                    "#|#",
                    "Seq|ลำดับ",
                    "Code|รหัสค่าบริการ",
                    "Description|คำอธิบายค่าบริการ",
                    "Qty|จำนวน",
                    "Total|ยอดเงิน",
                    "Discount|ส่วนลด",
                    "Net|สุทธิ",
                    "Commission|คอมมิชชั่น",
                    "Profit|กำไร"
                ];
            }
            break;
        case 'Tracking/Document':
            gridLang = [
                "#|#",
                "Type|ประเภท",
                "Job|หมายเลขงาน",
                "Doc.No|เลขที่เอกสาร",
                "Doc Date|วันที่เอกสาร",
                "Comment|บันทึกเพิ่มเติม",
                "Check Date|วันที่ตรวจสอบ",
                "Approve Date|วันที่อนุมัติ"
            ];
            break;
    }
    return gridLang;
}
function GetLangMessage() {
    return {
        "Approve Complete": "อนุมัติเรียบร้อย",
        "Advance amount is not balance": "ยอดไม่ลงตัว",
        "Are you sure to delete this item?": "กรุณายืนยันการลบรายการนี้",
        "Balance not enough to payment": "ยอดคงเหลือไม่เพียงพอ",
        "Branch must not have length over 4": "สาขาต้องไม่ยาวเกิน 4 ตัวอักษร",
        "Bill-payment had been choosed": "บิลค่าใช้จ่ายถูกเลือกแล้ว",
        "Cannot Approve": "ไม่สามารถอนุมัติได้",
        "Cannot Delete": "ไม่สามารถลบได้",
        "Cannot Edit": "ไม่สามารถแก้ไขได้",
        "Customer not found": "ไม่พบลูกค้า",
        "Current document status is not allow to do this": "ไม่อนุญาตให้ดำเนินการในสถานะเอกสารนี้",
        "Data must not have space": "ข้อมูลต้องไม่มีช่องว่าง",
        "Data must not have length over 10": "ข้อมูลต้องไม่ยาวเกิน 10 ตัวอักษร",
        "Data must not have length less than 3": "ข้อมูลต้องไม่ยาวต่ำกว่า 3 ตัวอักษร",
        "Data not found": "ไม่พบช้อมูล",
        "Delete Complete": "ลบข้อมูลเรียบร้อย",
        "Logout Complete": "ออกจากโปรแกรมแล้ว",
        "No data to approve": "ไม่มีข้อมูลที่จะอนุมัติ",
        "No data to delete": "ไม่มีข้อมูลที่จะลบ",
        "No data to cancel": "ไม่มีข้อมูลที่จะยกเลิก",
        "No data to Save": "ไม่มีข้อมูลที่จะบันทึก",
        "Not Found Contact of This Company": "ไม่พบข้อมูลผู้ติดต่อ",
        "Please check advance amount": "โปรดตรวจสอบยอดเงินที่เบิก",
        "Please confirm to update container total to job": "กรุณายืนยันที่จะปรับปรุงจำนวนตู้ในหมายเลขงานนี้",
        "Please confirm to generate container": "กรุณายืนยันที่จะสร้างตู้คอนเทนเนอร์",
        "Please confirm to save": "กรุณายืนยันการบันทึกข้อมูล",
        "Please confirm to delete": "กรุณายืนยันการลบข้อมูล",
        "Please confirm to log out": "กรุณายืนยันการออกจากระบบ",
        "Please confirm to clear all data": "กรุณายืนยันการล้างข้อมูลในหน้าจอ",
        "Please confirm this operation": "กรุณายืนยันการดำเนินการต่อ",
        "Please choose database first": "กรุณาเลือกฐานข้อมูลก่อน",
        "Please choose customer first": "กรุณาเลือกลูกค้าก่อน",
        "Please choose billing place": "กรุณาเลือกสถานที่วางบิล",
        "Please choose vender first": "กรุณาระบุผู้ให้บริการ",
        "Please choose notify party": "กรุณาระบุผู้ติดต่อปลายทาง",
        "Please choose manager code": "โปรดระบุผู้จัดการ",
        "Please choose route": "กรุณาระบุเส้นทาง",
        "Please choose some type of documents": "โปรดเลือกประเภทเอกสาร",
        "Please enter slip number": "โปรดระบุเลขที่ใบเสร็จ",
        "Please enter date of slip": "โปรดระบุวันที่ใบเสร็จ",
        "Please enter job to use for copy data": "โปรดระบุหมายเลขงานที่ต้องการใช้เพื่อคัดลอกข้อมูล",
        "Please enter config code": "กรุณาระบุรหัสควบคุม",
        "Please enter config key": "กรุณาระบุชื่อตัวแปร",
        "Please enter config value": "กรุณาระบุค่าของตัวแปร",
        "Please enter reason for cancel": "กรุณาระบุเหตุผลที่ยกเลิก",
        "Please enter some data": "กรุณากรอกข้อมูลมากกว่านี้",
        "Please input transaction date": "โปรดระบุวันทำรายการ",
        "Please input cheque number": "โปรดใส่เลขที่เช็ค",
        "Please input cheque date": "โปรดระบุวันที่เช็ค",
        "Please input bank and branch": "โปรดระบุธนาคารและสาขา",
        "Please input reference number": "โปรดระบุเอกสารอ้างอิง",
        "Please input reference date": "โปรดระบุวันที่เอกสารอ้างอิง",
        "Please input expense code": "โปรดระบุรหัสค่าใช้จ่าย",
        "Please input VAT info": "โปรดกรอกข้อมูลภาษี",
        "Please input branch": "โปรดระบุสาขา",
        "Please input advance no": "โปรดระบุใบเบิก",
        "Please input clear no": "โปรดระบุใบปิด",
        "Please input Request By": "กรุณาระบุผู้ขอเบิก",
        "Please input invoice/booking": "กรุณาระบุอินวอย/บุคกิ้ง",
        "Please input inspection date": "กรุณาระบุวันที่ตรวจปล่อย",
        "Please input confirm date": "กรุณาระบุวันที่ลูกค้ายืนยัน",
        "Please input quantity": "กรุณาระบุจำนวน",
        "Please input code": "กรุณาระบุรหัส",
        "Please input name": "กรุณาระบุชื่อ",
        "Please input country code": "กรุณาระบุรหัสประเทศ",
        "Please save document before add detail": "กรุณาบันทึกเอกสารก่อนที่จะเพิ่มรายละเอียด",
        "Please select book account": "โปรดเลือกสมุดบัญชี",
        "Please select type of advance": "โปรดระบุประเภทการเบิก",
        "Please select type of payment": "โปรดระบุประเภทการจ่ายเงิน",
        "Please select job type": "โปรดระบุประเภทงาน",
        "Please select clear type": "โปรดระบุประเภทการปิด",
        "Please select clear from": "โปรดระบุแผนกที่ปิด",
        "Please select ship by": "โปรดระบุลักษณะงานขนส่ง",
        "Please select application": "กรุณาระบุโปรแกรม",
        "Please select type of expense": "กรุณาระบุประเภทค่าใช้จ่าย",
        "Please select job number": "โปรดระบุหมายเลขงาน",
        "Please select unit": "โปรดระบุหน่วย",
        "Please select expense code": "โปรดระบุรหัสค่าใช้จ่าย",
        "Please select menu": "กรุณาระบุเมนูการทำงาน",
        "Please select staff": "กรุณาระบุพนักงาน",
        "Please enter some data first": "กรุณาระบุรายการที่ต้องการก่อน",
        "Please login first": "กรุณาล็อกอินก่อน",
        "Save Complete": "บันทึกเรียบร้อย",
        "This document is locked": "เอกสารนี้ไม่สามารถแก้ไขได้แล้ว",
        "This document is cancelled": "เอกสารนี้ยกเลิกแล้ว",
        "This data is duplicate": "ข้อมูลซ้ำ",
        "This invoice is already billed,Please cancel billing": "ใบแจ้งหนี้นี้วางบิลแล้ว กรุณายกเลิกใบวางบิลก่อน",
        "This job has been closed": "งานนี้มีการปิดแล้ว",
        "This expense is not allowed": "รหัสนี้ไม่อนุญาตให้ใช้ในเอกสารนี้",
        "Under Development": "อยู่ในระหว่างการพัฒนา",
        "Voucher amount is not balance": "ยอดไม่ลงตัว",
        "Value must be more than zero": "จำนวนต้องมากกว่าศูนย์",
        "Value must be less than zero": "จำนวนต้องน้อยกว่าศูนย์",
        "You are not allow to do this": "คุณไม่ได้รับอนุญาตให้ดำเนินการ",
        "You are not allow to add": "คุณไม่ได้รับอนุญาตให้เพิ่มข้อมูล",
        "You are not allow to edit": "คุณไม่ได้รับอนุญาตให้แก้ไขข้อมูล",
        "You are not allow to save": "คุณไม่ได้รับอนุญาตให้บันทึกข้อมูล",
        "You are not allow to print": "คุณไม่ได้รับอนุญาตให้พิมพ์ข้อมูล",
        "You are not allow to delete": "คุณไม่ได้รับอนุญาตให้ลบข้อมูล",
        "You are not allow to cancel": "คุณไม่ได้รับอนุญาตให้ยกเลิกข้อมูล",
        "You are not allow to view": "คุณไม่ได้รับอนุญาตให้ดูข้อมูล",
        "You can choose cheque only for payment entry": "คุณจะสามารถเลือกรายการเช็คได้เมื่อทำการจ่ายเงินเท่านั้น"
    };
}
function GetLangMenu() {
    return {
        mainMkt: 'Marketing Works|แผนกการตลาด',
        mnuMkt1: 'Quotation|ใบเสนอราคา',
        mnuMkt2: 'Quotation Confirmation|อนุมัติใบเสนอราคา',
        mnuMkt3: 'Estimate Cost|ประมาณการค่าใช้จ่าย',
        mainCS: 'CS Works|แผนกบริการลูกค้า',
        mnuCS1: 'Create Job|สร้างงานใหม่',
        mnuCS2: 'List Job|ค้นหางาน',
        mnuCS3: 'Transport Info|ข้อมูลรับบรรทุก',
        mnuCS4: 'Witholding-Tax|ออกหนังสือหักณที่จ่าย',
        mnuCS5: 'Fuel Refill|ใบเติมน้ำมัน',
        mainShp: 'Shipping Works|แผนกชิปปิ้ง',
        mnuShp1: 'Advance|ใบเบิกค่าใช้จ่าย',
        mnuShp2: 'Clearing|ใบปิดค่าใช้จ่าย',
        mnuShp3: 'Planing|ข้อมูลการตรวจปล่อย',
        mnuShp4: 'Create Transport|สร้างงานขนส่ง',
        mainApp: 'Approving|อนุมัติเอกสาร',
        mnuApp1: 'Advance Confirm|อนุมัติใบเบิก',
        mnuApp2: 'Clearing Confirm|อนุมัติใบปิด',
        mnuApp3: 'Expense Confirm|อนุมัติบิลค่าใช้จ่าย',
        mnuApp4: 'Transport Confirm|อนุมัติงานขนส่ง',
        mnuApp5: 'Job Confirm|อนุมัติสถานะจ๊อบ',
        mainFin: 'Finance Works|แผนกการเงิน',
        mnuFin1: 'Advance Payment|จ่ายเงินตามใบเบิก',
        mnuFin2: 'Expense Payment|จ่ายเงินตามบิลค่าใช้จ่าย',
        mnuFin3: 'Clearing Receive|รับเคลียร์เงินใบเบิก/ปิด',
        mnuFin4: 'Invoice Receive|รับชำระใบแจ้งหนี้',
        mnuFin5: 'Cheque Management|บันทึกรับ/จ่ายเช็ค',
        mnuFin6: 'Credit Advance|เบิกเงินทดรองจ่าย',
        mnuFin7: 'Petty Cash|จัดการเงินสดย่อย',
        mnuFin8: 'Earnest Clearing|รับคืนมัดจำ/ทดรองจ่าย',
        mainAcc: 'Accounting Works|งานบัญชี',
        mnuAcc1: 'Vouchers|บันทึกการรับจ่ายเงิน',
        mnuAcc2: 'Invoice|ใบแจ้งหนี้',
        mnuAcc3: 'Billing|ใบวางบิล',
        mnuAcc4: 'Receipts|ใบเสร็จรับเงิน',
        mnuAcc5: 'Tax-Invoice|ใบกำกับภาษี',
        mnuAcc6: 'Bill Payment|บิลค่าใช้จ่าย',
        mnuAcc7: 'Credit/Debit Note|ใบเพิ่มหนี้/ลดหนี้',
        mnuAcc8: 'Journal Entry|สมุดรายวัน',
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
        mnuMasA10: 'Car License|ข้อมูลรถ',
        mnuMasA11: 'Employee|ข้อมูลพนักงาน',
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
        mnuUtil2: 'Export|ส่งออกข้อมูล',
        mainVend: 'Vender Works|งานผู้ให้บริการ',
        mainVend2: 'Vender Works|งานผู้ให้บริการ',
        mnuVen0: 'Transport Confirm|อนุมัติงานขนส่ง',
        mnuVen1: 'Bill Payment|บันทึกบิลค่าใช้จ่าย',
        mnuVen2: 'Vender Summary|บันทึกสรุปวางบิล',
        mnuVen3: 'Transport Tracking|การติดตามงานขนส่ง',
        mnuVen4: 'Expense Confirm|อนุมัติบิลค่าใช้จ่าย',
        mnuVend0: 'Transport Confirm|อนุมัติงานขนส่ง',
        mnuVend1: 'Bill Payment|บันทึกบิลค่าใช้จ่าย',
        mnuVend2: 'Vender Summary|บันทึกสรุปวางบิล',
        mnuVend3: 'Transport Tracking|การติดตามงานขนส่ง',
        mnuVend4: 'Expense Confirm|อนุมัติบิลค่าใช้จ่าย',
        mnuMaster: 'My Master Data|แฟ้มข้อมูลมาตรฐาน',
        mnuMaster1: '1.System Data|1.ค่าคงที่ระบบ',
        mnuMaster2: '2.Customs Data|2.ข้อมูลพิธีการ',
        mnuMaster3: '3.Accounts Data|3.ข้อมูลทางบัญชี',
        mnuShipments: 'My Shipments|แฟ้มข้อมูลงานหลัก',
        mnuOpenJob1: '1.New Shipment|1.เปิดงานใหม่',
        mnuOpenJob2: '2.Edit Shipment|2.แก้ไขรายละเอียดงาน',
        mnuOpenJob3: '3.Edit Transport|3.บันทึกข้อมูลงานขนส่ง',
        mnuPlaning: 'My Services Planning|แฟ้มข้อมูลการเตรียมงาน',
        mnuExpenses1: '1.Quotation|1.ใบเสนอราคา',
        mnuExpenses2: '2.Price Rates|2.รายการราคา',
        mnuExpenses3: '3.Pre-invoice|3.ใบประเมินค่าใช้จ่าย',
        mnuAdvExpenses: 'My Expenses|แฟ้มข้อมูลค่าใช้จ่าย',
        mnuAdvance1: '1.Advance Requisition|1.ใบเบิกค่าใช้จ่าย',
        mnuAdvance2: '2.Credit Advances|2.ใบสำรองค่าใช้จ่าย',
        mnuAdvance3: '3.Accrued Expenses|3.บันทึกบิลค่าใช้จ่าย',
        mnuCosting: 'My Cost & Services|แฟ้มข้อมูลต้นทุนและค่าบริการ',
        mnuClearance1: '1.Expense Clearing|1.ใบปิดค่าใช้จ่าย',
        mnuClearance2: '2.Adjustment Clearing|2.บันทึกเคลียร์ค่าใช้จ่าย',
        mnuIncome: 'My Incomes|แฟ้มข้อมูลรายได้',
        mnuBilling1: '1.Invoices|1.ใบแจ้งหนี้',
        mnuBilling2: '2.Billings|2.ใบวางบิล',
        mnuBilling3: '3.Cash-Receipts|3.ใบเสร็จรับเงิน',
        mnuBilling4: '4.Tax-Receipts|4.ใบกำกับภาษี',
        mnuDocuments: 'My Documents|แฟ้มข้อมูลเอกสาร',
        mnuAuthorize1: '1.Quotation Approving|1.อนุมัติใบเสนอราคา',
        mnuAuthorize2: '2.Shipment Approving|2.ยืนยันการทำงาน',
        mnuAuthorize3: '3.Advance Approving|3.อนุมัติใบเบิกค่าใช้จ่าย',
        mnuAuthorize4: '4.Clearing Approving|4.อนุมัติใบปิดค่าใช้จ่าย',
        mnuAuthorize5: '5.Payables Approving|5.อนุมัติจ่ายบิลค่าใช้จ่าย',
        mnuAuthorize6: '6.Transport Approving|6.อนุมัติงานขนส่ง',
        mnuAuthorize7: '7.Documents Files|7.แฟ้มเอกสาร',
        mnuCashFlow: 'My Cash Flow|แฟ้มข้อมูลทางการเงิน',
        mnuCash1: '1.Cash In/Out|1.รับ/จ่ายเงินสด',
        mnuCash2: '2.Cheque In/Out|2.รับ/จ่ายเช็ค',
        mnuCash3: '3.Advance Payment|3.จ่ายเงินตามใบเบิก',
        mnuCash4: '4.Advance Refund/Return|4.รับเงิน/คืนเงินใบเบิก',
        mnuCash5: '5.A/P Payment|5.จ่ายชำระหนี้',
        mnuCash6: '6.A/R Receival|6.รับชำระจากลูกค้า',
        mnuReports: 'My Reports|แฟ้มข้อมูลรายงาน',
        mnuSummary1: '1.Reports|1.รายงานต่างๆ',
        mnuSummary2: '2.Status Tracking|2.ติดตามสถานะงาน',
        mnuSummary3: '3.Job Timeline|3.สรุปสถานะงาน',
        mnuSummary4: '4.Dashboard By Customer|4.สรุปงานตามลูกค้า',
        mnuSummary5: '5.Dashboard By Staff|5.สรุปงานตามพนักงาน',
        mainSum: 'Summary|สรุปการทำงาน',
        mnuSum1: 'Operation|สรุปการปฏฺิบัติงาน',
        mnuSum2: 'Advance|สรุปการเบิกเงิน',
        mnuSum3: 'Clearing|สรุปการปิดค่าใช้จ่าย',
        mnuSum4: 'Account|สรุปรายการทางบัญชี'
    };
}
function GetLangForm(fname) {
    let lang = {};
    switch (fname) {
        case 'Acc/GenerateBilling':
            lang = {
                lblTitle: 'Generate Billing|สร้างใบวางบิล',
                lblBranch: 'Branch|สาขา',
                lblDocDateF: 'Invoice Date From|ใบแจ้งหนี้จากวันที่',
                lblDocDateT: 'Invoice Date To|ถึงวันที่',
                lblCustCode: 'Billing Place|สถานที่วางบิล',
                linkSearch: 'Search|ค้นหา',
                linkGen: 'Create Billing|สร้างใบวางบิล',
                lblDocDate: 'Billing Date|วันที่เอกสาร',
                lblBillToCustCode: 'Billing Place|สถานที่วางบิล',
                lblBillSummary: 'Billing Summary|สรุปรวมยอด',
                lblTotalAdvance: 'Advance|ทดรองจ่าย',
                lblTotalCharge: 'Charge|ค่าบริการ',
                lblTotalIsTaxCharge: 'Vatable|ฐานภาษีมุลค่าเพิ่ม',
                lblTotalIs50Tavi: 'Taxable|ฐานภาษี ณ ที่จ่าย',
                lblTotalVat: 'VAT|ภาษีมูลค่าเพิ่ม',
                lblTotalAfter: 'After VAT|ยอดรวม VAT',
                lblTotal50Tavi: 'WHT|หัก ณ ที่จ่าย',
                lblTotalService: 'After WHT|ยอดรวม WHT',
                lblTotalCustAdv: 'Cust.Advance|รับล่วงหน้า',
                lblTotalNet: 'NET|ยอดสุทธิ',
                linkSave: 'Save Billing|บันทึกใบวางบิล',
                lblDocNo: 'Billing No|เลขที่เอกสาร',
                linkPrint: 'Print Billing|พิมพ์ใบวางบิล',
                lblDetail: 'Billing Detail|รายการใบวางบิล'
            };
            break;
        case 'Acc/GenerateReceipt':
            lang = {
                lblTitle: 'Generate Receipts|สร้างใบเสร็จรับเงิน',
                lblBranch: 'Branch|สาขา',
                lblDocDateF: 'Invoice Date From|จากวันที่ใบแจ้งหนี้',
                lblDocDateT: 'Invoice Date To|ถึงวันที่',
                lblBilling: 'Search By billing|เลือกตามสถานที่วางบิล',
                linkSearch: 'Search|ค้นหา',
                linkGen: 'Create Receipts|สร้างใบเสร็จรับเงิน',
                lblGroupDoc: 'Group By Document|รับชำระตามยอดรวมเอกสาร',
                lblCustCode: 'Customer|ลูกค้า',
                lblDocDate: 'Receipt.Date|วันที่เอกสาร',
                lblBillToCustCode: 'Billing To|สถานที่วางบิล',
                lblTotalAdvance: 'Total Receipts|ยอดรวม',
                lblMerge: 'Generate One Receipt|รวมรายการเป็นใบเสร็จเดียว',
                linkSave: 'Save Receipts|บันทึกใบเสร็จรับเงิน',
                lblDocNo: 'Receipt No|เลขที่ใบเสร็จรับเงิน',
                linkPrint: 'Print Receipts|พิมพ์ใบเสร็จรับเงิน',
                lblDetail: 'Invoice Details|รายการใบแจ้งหนี้ที่จัดทำใบเสร็จ'
            };
            break;
        case 'Acc/GenerateTaxInv':
            lang = {
                lblTitle: 'Generate Tax-Invoice|สร้างใบกำกับภาษี',
                lblBranch: 'Branch|สาขา',
                lblDocType: 'Type|ประเภทเอกสาร',
                lblDocDateF: 'Invoice Date From|จากวันที่ใบแจ้งหนี้',
                lblDocDateT: 'Invoice Date To|ถึงวันที่',
                lblBilling: 'Search By billing|เลือกตามสถานที่วางบิล',
                linkSearch: 'Search|ค้นหา',
                linkGen: 'Create Tax-Invoice|สร้างใบกำกับภาษี',
                lblGroupDoc: 'Group By Document|รับชำระตามยอดรวมเอกสาร',
                lblSummary: 'Tax-Invoice Summary|รวมยอด',
                lblCustCode: 'Customer|ลูกค้า',
                lblDocDate: 'Receipt.Date|วันที่เอกสาร',
                lblBillToCustCode: 'Billing To|สถานที่วางบิล',
                lblTotalAdvance: 'Total Advance|รวมทดรองจ่าย',
                lblTotalCharge: 'Total Service|รวมค่าบริการ',
                lblTotalVAT: 'Total VAT|รวมภาษีมูลค่าเพิ่ม',
                lblTotal50Tavi: 'Total WH-Tax|รวมหัก ณ ที่จ่าย',
                lblTotalNet: 'Receive Total|รวมเงินได้สุทธิ',
                lblMerge: 'Generate One Tax-Invoice|รวมรายการเป็นใบเดียว',
                linkSave: 'Save Tax-Invoice|บันทึกใบกำกับภาษี',
                lblDocNo: 'Tax-Invoice No|เลขที่ใบกำกับภาษี',
                linkPrint: 'Print Tax-Invoice|พิมพ์ใบกำกับภาษี',
                lblDetail: 'Invoice Details|รายการใบแจ้งหนี้ที่จัดทำใบเสร็จ'
            };
            break;
        case 'MODULE_ADV/Approve':
            lang = {
                lblTitle: 'Advance Confirmation|อนุมัติใบเบิกค่าใช้จ่าย',
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
                linkApprove: 'Confirm|อนุมัติเอกสาร'
            };
            break;
        case 'MODULE_ADV/CreditAdv':
            lang = {
                lblTitle: 'Credit Advance|ใบทดรองจ่าย',
                lblBranch: 'Branch|สาขา',
                linkRef: 'Reference No|เลขที่บันทึกบัญชี',
                lblVoucherDate: 'Record Date|วันที่บันทึกรายการ',
                lblTRemark: 'Advance Note|บันทึก',
                lblCustCode: 'Customer|ลูกค้า',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                lblRecBy: 'Record By|ผู้บันทึกรายการ',
                lblRecDate: 'Date|วันที่',
                lblRecTime: 'Time|เวลา',
                lblPostBy: 'Posted By|ตรวจสอบโดย',
                lblPostDate: 'Date|วันที่',
                lblPostTime: 'Time|เวลา',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelDate: 'Date|วันที่',
                lblCancelTime: 'Time|เวลา',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblPayInfo: 'Payment Info|ข้อมูลนำจ่าย',
                lblVatInfo: 'Expense Info|ข้อมูลค่าใช้จ่าย',
                lblItemNo: 'No|ลำดับที่',
                lblVCNo: 'Voucher No|เลขที่ใบสำคัญ',
                lblACType: 'Type|ประเภทการจ่าย',
                linkBook: 'Book A/C|เลขที่บัญชี',
                lblBookName: 'Book Name|ชื่อบัญชี',
                lblBankCode: 'Bank Code|ธนาคารเจ้าของบัญชี',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblBankBranch: 'Branch|สาขา',
                lblChqNo: 'Cheque No|เลขที่เช็ค',
                lblChqDate: 'C.Date|วันที่เช็ค',
                lblLocal: 'Local Cheque|เป็นเช็คนอกจังหวัด',
                linkBank: 'Ref.Bank|ธนาคารที่ทำธุรกรรม',
                lblRefBankName: 'Ref.Bank Name|ชื่อธนาคาร',
                lblRefBankBranch: 'Ref.Branch|ชื่อสาขา',
                lblCashAmount: 'Cash.Amount|ยอดเงินสด',
                lblChqAmount: 'Chq.Amount|ยอดเช็ค',
                lblCreditAmount: 'Credit.Amount|ยอดเครดิต',
                linkCode: 'Exp.Code|รหัสค่าใช้จ่าบ',
                linkDocNo: 'Ref.No|เลขที่เอกสารอ้างอิง',
                lblPayTo: 'Paid To|จ่ายให้กับ',
                linkCurr: 'Currency|สกุลเงิน',
                lblCurrName: 'Currency Name|ชื่อสกุลเงิน',
                lblAmtBase: 'Amount Base|ยอดเงิน',
                lblExcRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblTotalAmt: 'Total Amount|ฐานภาษี',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                lblNote: 'Note|บันทึกเพิ่มเติม',
                lblJNo: 'Job No.|หมายเลขงาน',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblInvNo: 'Inv.No|อินวอยลูกค้า',
                linkUpdate: 'Save Detail|จัดเก็บรายการ',
                linkDelete: 'Delete Detail|ลบรายการ',
                linkClear: 'Clear Entry|เพิ่มเอกสารใหม่',
                linkSave: 'Save Entry|บันทีกเอกสาร',
                linkPrint: 'Print Entry|พิมพ์เอกสาร'
            };
            break;
        case 'MODULE_ADV/Index':
            lang = {
                lblTitle: 'Advance Information|ใบเบิกค่าใช้จ่าย',
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
                lblCash: 'Cash/Transfer|เงินสด/โอน',
                lblChqCash: 'Company Chq (BFT)|เช็คบริษัท',
                lblChq: 'Customer Chq|เช็คลูกค้า',
                lblCred: 'Credit|เครดิตหนี้',
                lblApproveBy: 'Approve By|อนุมัติโดย',
                lblApproveDate: 'Approve Date|วันที่อนุมัติ',
                lblApproveTime: 'Approve Time|เวลา',
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
                btnGetExcRate: 'Get Rate|ดึงอัตราแลกเปลี่ยน',
                lblPayChqDate: 'Operation Date|วันที่ใช้เงิน'
            };
            break;
        case 'MODULE_ADV/EstimateCost':
            lang = {
                lblTitle: 'Estimate Cost|ประมาณการค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblJNo: 'Job No|หมายเลขงาน',
                btnAutoEntry: 'Load From Quotation|ดึงข้อมูลใบเสนอราคา',
                btnAutoEntryC: 'Load From Clearing|ดึงข้อมูลใบปิดค่าใช้จ่าย',
                lblSICode: 'Service Code|รหัสค่าบริการ',
                lblRemark: 'Remark|หมายเหตุ',
                lblStatus: 'Status|สถานะ',
                lblAmount: 'Amount|ยอดเงิน',
                lblCurrency: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblQty: 'Qty|จำนวน',
                lblUnit: 'Unit|หน่วย',
                lblTotal: 'Total|ยอดรวม',
                lblVATRate: 'VAT Rate|อัตรา VAT',
                lblWHTRate: 'WHT Rate|อัตราหัก ณ ที่จ่าย',
                lblWHT: 'WHT|หัก ณ ที่จ่าย',
                lblTotal: 'Total|ยอดสุทธิ',
                linkNew: 'New|เพิ่มข้อมูล',
                linkSave: 'Save|บันทึกข้อมูล',
                linkDelete: 'Delete|ลบข้อมูล',
                linkCopy: 'Copy From Job|Copy ข้อมูลจาก Job',
                linkPrint: 'Print Pre-Invoice|พิมพ์แบบประเมินค่าใช้จ่าย'
            };
            break;
        case 'MODULE_ADV/Payment':
            lang = {
                lblTitle: 'Advance Payment|จ่ายเงินตามใบเบิกค่าใช้จ่าย',
                linkTab1: 'Select document|เลือกใบเบิกที่ต้องการ',
                linkTab2: 'Payment Info|ข้อมูลการชำระเงิน',
                linkTab3: 'Payment Detail|สรุปข้อมูลการจ่ายเงิน',
                optTab1: 'Select document|เลือกใบเบิกที่ต้องการ',
                optTab2: 'Payment Info|ข้อมูลการชำระเงิน',
                optTab3: 'Payment Detail|สรุปข้อมูลการจ่ายเงิน',
                lblBranch: 'Branch|สาขา',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblReqBy: 'Request By|ผู้ขอเบิก',
                lblAdvFor: 'Advance For|สำหรับลูกค้า',
                lblCurrency: 'Request Currency|สกุลเงินที่ขอเบิก',
                lblDateFrom: 'Request Date From|จากวันที่ขอเบิก',
                lblDateTo: 'Request Date To|ถึงวันที่',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Payment Document|เอกสารที่เลือก',
                linkCash: 'Cash/Transfer|เงินสด',
                lblBookCA: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCA: 'Trans.No (BFT)|เลขที่สลิปอ้างอิง',
                lblTranDateCA: 'Trans.Date|วันที่ทำรายการ',
                lblTranTimeCA: 'Trans.Time|เวลาที่ทำรายการ',
                lblBankCA: 'To Bank|ธนาคารที่รับโอน',
                lblBranchCA: 'To Branch|สาขาที่รับโอน',
                lblPayCA: 'Pay To|ชื่อบัญชที่โอนเข้า',
                linkChqCash: 'Company Chq (BFT)|เช็คบริษัท',
                lblBookCH: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCH: 'Slip.No|เลขที่สลิปโอน',
                lblTranDateCH: 'Slip.Date|วันที่โอน',
                lblStatusCH: 'Transfer Chg|โอนข้ามธนาคาร',
                lblBankCH: 'Transfer Bank|ธนาคารที่โอน',
                lblBranchCH: 'Transfer Branch|สาขาที่โอน',
                lblPayCH: 'Transfer To|ชื่อผู้รับเงิน',
                linkChqCust: 'Cheque|เช็คลูกค้าจ่าย',
                lblRefNoCU: 'Cheque No|เลขที่เช็ค',
                lblTranDateCU: 'Chq.Date|วันที่เช็ค',
                lblStatusCU: 'Local|เช็คข้ามจังหวัด',
                lblBankCU: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCU: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCU: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkCred: 'Credit|เครดิตบัญชี',
                lblRefNoCR: 'Ref No|เลขที่การลงบัญชี',
                lblTranDateCR: 'Ref Date|วันที่การลงบัญชี',
                lblPayCR: 'Pay To|ชื่อผู้รับบริการ',
                linkBal: 'Balance|ยอดคงเหลือ',
                lblForCA: 'For Cash/Transfer|สำหรับเงินสด/เงินโอน',
                lblForCH: 'For Cheque|สำหรับจ่ายเชิ็ค',
                lblPayDate: 'Payment Date|วันที่จ่ายเงิน',
                lblPayTotal: 'Payment Total|ยอดเงินรวม',
                lblWTTotal: 'W/T Total|ยอดหัก ณ ที่จ่าย',
                lblRemark: 'Remark|บันทึกการจ่ายเงิน',
                linkSave: 'Save Payment|บันทึกการจ่ายเงิน',
                lblCaptionChq: 'Select Cheque Onhand|เลือกเช็คที่ต้องการทำรายการ'
            };
            break;
        case 'MODULE_ACC/Approve':
            lang = {
                lblTitle: 'Expense Confirmation|อนุมัติบิลค่าใช้จ่าย',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Due Date From|กำหนดชำระวันที่',
                lblDateTo: 'To|ถึงวันที่',
                lblCurrency: 'Currency|สกุลเงินที่ต้องจ่าย',
                lblVenCode: 'Vender|ผู้ให้บริการ',
                linkSearch: 'Search|ค้นหา',
                lblListApprove: 'Selected Document|เอกสารที่เลือก',
                linkApprove: 'Confirm|อนุมัติเอกสาร'
            };
            break;
        case 'MODULE_ACC/AccountCode':
            lang = {
                lblTitle: 'Account Code|รหัสบัญชี',
                lblAccCode: 'Code|รหัส',
                lblAccTName: 'Name (TH)|ชื่อ(ไทย)',
                lblAccEName: 'Name (EN)|ชื่อ(อังกฤษ)',
                lblAccType: 'Type|ประเภท',
                lblAccMain: 'Close Balance To|ปิดยอดให้กับ',
                lblAccSide: 'Side|บันทึกบัญชีด้าน',
                linkAdd: 'New|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_ACC/Billing':
            lang = {
                lblTitle: 'Billing Acknowledgement|ใบวางบิล',
                lblBranch: 'Branch|สาขา',
                lblBillingPlace: 'Billing Place|สถานที่วางบิล',
                lblDocDateF: 'Bill Date From|จากวันที่วางบิล',
                lblDocDateT: 'Bill Date to|ถึงวันที่',
                linkSearch: 'Search|ค้นหา',
                linkCreate: 'New Billing|สร้างใบวางบิลใหม่',
                lblCancel: 'Show Cancel Only|แสดงที่ยกเลิกเท่านั้น',
                linkHeader: 'Headers|ส่วนควบคุม',
                linkDetail: 'Details|ส่วนรายการ',
                lblDocNo: 'Details of Billing No|รายละเอียดใบวางบิล',
                linkDelete: 'Delete|ลบรายการ',
                btnCancel: 'Cancel|ยกเลิก',
                linkPrint: 'Print|พิมพ์เอกสาร',
                linkPrint2: 'Print|พิมพ์เอกสาร',
                lblBillAcceptNo: 'Billing No|เลขที่ใบวางบิล',
                lblIssueDate: 'Issue Date|วันที่เอกสาร',
                lblBCustCode: 'Billing To|สถานที่วางบิล',
                lblBillRecvBy: 'Received By|รับวางบิลโดย',
                lblBillRecvDate: 'Confirm Date|วันที่รับวางบิล',
                lblBillRemark: 'Remark|หมายเหตุ',
                lblDuePaymentDate: 'Payment Due|กำหนดชำระ',
                lblCancelProve: 'Cancel By|ยกเลิกโดย',
                lblCancelReson: 'Reason|สาเหตุที่ยกเลิก',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelTime: 'Cancel Time|เวลาที่ยกเลิก',
                lblTotalAdvance: 'Advance|คชจ.จ่ายแทน',
                lblTotalChargeNonVAT: 'Service Non-vat|ค่าบริการไม่มี VAT',
                lblTotalChargeVAT: 'Service vat|ค่าบริการมี VAT',
                lblTotalCustAdv: 'Customer Adv|เงินรับล่วงหน้า',
                lblTotalVAT: 'Total VAT|ยอด VAT',
                lblTotalWH: 'WH Tax|หัก ณ ที่จ่าย',
                lblTotalDiscount: 'Total Discount|ส่วนลด',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                lblEmpCode: 'Staff|รหัสพนักงาน',
                lblRecDateTime: 'Record Date|วันทึบันทึก',
                linkUpdate: 'Update|จัดเก็บข้อมูล',
                linkPrint: 'Print|พิมพ์ใบวางบิล'
            };
            break;
        case 'MODULE_ACC/Cheque':
            lang = {
                lblTitle: 'Cheque Management|บันทีกรับจ่ายเช็ค',
                lblBranch: 'Branch|สาขา',
                lblChqType: 'Cheque Type|ประเภทเช็ค',
                optRcv: 'Received|เช็ครับ',
                optPay: 'Paid|เช็คจ่าย',
                linkRef: 'Reference No|เลขที่บันทึกบัญชี',
                lblVoucherDate: 'Record Date|วันที่บันทึกรายการ',
                lblTRemark: 'Cheque Note|บันทึก',
                lblCustCode: 'Customer|ลูกค้า',
                linkAdd: 'Add Detail|เพิ่มรายการเช็ค',
                lblRecBy: 'Record By|ผู้บันทึกรายการ',
                lblRecDate: 'Date|วันที่',
                lblRecTime: 'Time|เวลา',
                lblPostBy: 'Posted By|ตรวจสอบโดย',
                lblPostDate: 'Date|วันที่',
                lblPostTime: 'Time|เวลา',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelDate: 'Date|วันที่',
                lblCancelTime: 'Time|เวลา',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblChqInfo: 'Cheque Info|ข้อมูลหน้าเช็ค',
                lblVatInfo: 'Expense Info|ข้อมูลค่าใช้จ่าย',
                lblItemNo: 'No|ลำดับที่',
                lblVCNo: 'Voucher No|เลขที่ใบสำคัญ',
                lblIssuer: 'Issuer|เจ้าของเช็ค',
                optComp: 'Company|กิจการ',
                optCust: 'Customer|ลูกค้า',
                linkBook: 'Book A/C|เลขที่บัญชี',
                lblBookName: 'Book Name|ชื่อบัญชี',
                lblBankCode: 'Bank Code|ธนาคารเจ้าของบัญชี',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblBankBranch: 'Branch|สาขา',
                lblChqNo: 'Cheque No|เลขที่เช็ค',
                lblChqDate: 'C.Date|วันที่เช็ค',
                lblLocal: 'Local Cheque|เป็นเช็คนอกจังหวัด',
                linkBank: 'Ref.Bank|ธนาคารที่ทำธุรกรรม',
                lblRefBankName: 'Ref.Bank Name|ชื่อธนาคาร',
                lblRefBankBranch: 'Ref.Branch|ชื่อสาขา',
                lblChqAmount: 'Amount|ยอดเงิน',
                linkCode: 'Exp.Code|รหัสค่าใช้จ่าบ',
                linkDocType: 'Doc.Type|ประเภทเอกสาร',
                linkDocNo: 'Ref.No|เลขที่เอกสารอ้างอิง',
                lblPayTo: 'Paid To|จ่ายให้กับ',
                linkCurr: 'Currency|สกุลเงิน',
                lblCurrName: 'Currency Name|ชื่อสกุลเงิน',
                lblAmtBase: 'Amount Base|ยอดเงิน',
                lblExcRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblTotalAmt: 'Total Amount|ฐานภาษี',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                lblNote: 'Note|บันทึกเพิ่มเติม',
                lblJNo: 'Job No.|หมายเลขงาน',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblInvNo: 'Inv.No|อินวอยลูกค้า',
                linkUpdate: 'Save Cheque|จัดเก็บรายการเช็ค',
                linkDelete: 'Delete Cheque|ลบรายการเช็ค',
                linkClear: 'Clear Entry|เพิ่มเอกสารใหม่',
                linkSave: 'Save Entry|บันทีกเอกสาร',
                linkPrint: 'Print Entry|พิมพ์เอกสาร'
            };
            break;
        case 'MODULE_ACC/Costing':
            lang = {
                lblTitle: 'Job Summary|ต้นทุนและกำไรขั้นต้น',
                lblBranch: 'Branch|สาขา',
                lblJobNo: 'Job No|หมายเลขงาน',
                lblCloseDate: 'Close date|วันที่ปิดงาน',
                lblJobStatus: 'Job Status|สถานะงาน',
                lblService: 'Service|ค่าบริการ',
                lblAdvance: 'Advance|คชจ.จ่ายแทน',
                lblCost: 'Cost|ต้นทุน',
                lblProfit: 'Profit|กำไร',
                lblBaseVat: 'Vatable|ฐานภาษี',
                lblNonVat: 'Non-vat|ยกเว้นภาษี',
                lblVat: 'VAT|VAT',
                lblWhTax: 'WHT|หัก ณ ที่จ่าย',
                lblSumCharge: 'Chargeable|เรียกเก็บได้',
                lblInv: 'Invoiced|ทำใบแจ้งหนี้แล้ว',
                lblSumClear: 'Cleared|เคลียร์ต้นทุนแล้ว',
                lblPending: 'Pending|คงค้าง',
                linkGen: 'Generate Invoice|สร้างใบแจ้งหนี้',
                linkPrint: 'Print Summary|พิมพ์ใบสรุปต้นทุน',
                lblSetInv: 'Set Invoice To|บันทึกรวมชุดกับใบแจ้งหนี้',
                linkUpdate: 'Update Invoice|จัดเก็บข้อมูล'
            };
            break;
        case 'MODULE_ACC/Expense':
            lang = {
                lblTitle: 'Bill Payment|บิลค่าใช้จ่าย',
                lblBranch: 'Branch|รหัสสาขา',
                lblDocNo: 'Expenses No|เลขที่เอกสาร',
                lblDocDate: 'Due Date|กำหนดชำระ',
                linkHeader: 'Header|ส่วนควบคุม',
                linkDetail: 'Detail|ส่วนรายการ',
                lblEmpCode: 'Attn To|ผู้รับผิดชอบ',
                lblVenCode: 'Vender|ผุ้ให้บริการ',
                lblContactName: 'Contact|ช้อมูลการติดต่อ',
                lblRefNo: 'Ref No.1|เลขที่อ้างอิง 1',
                lblPoNo: 'Ref No.2|เลขที่อ้างอิง 2',
                lblForeignAmt: 'Total Document|ยอดรวมค่าใช้จ่าย',
                lblRemark: 'Remark|หมายเหตุ',
                lblAdvRef: 'Advance Reference|ใบเบิกเลขที่',
                lblCurrencyCode: 'Currency|รหัสสกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                btnGetExcRate: 'Get Rate|ดึงอัตราแลกเปลี่ยน',
                lblAppr: 'Approve By|อนุมัติโดย',
                lblApprDate: 'Date|วันที่',
                lblApprTime: 'Time|เวลา',
                lblPayment: 'Payment By|ชำระเงินโดย',
                lblPayDate: 'Date|วันที่',
                lblPayTime: 'Time|เวลา',
                lblPayRef: 'Payment Ref|เลขที่อ้างอิง',
                lblCancelProve: 'Cancel By|ยกเลิกโดย',
                lblCancelDate: 'Date|วันที่ยกเลิก',
                lblCancelTime: 'Time|เวลาที่ยกเลิก',
                lblCancelReson: 'Cancel Reason|สาเหตุที่ยกเลิก',
                linkClear: 'Clear Data|ล้างข้อมูล',
                linkSave: 'Save Data|บันทึกข้อมูล',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                linkDel: 'Delete Detail|ลบรายการ',
                lblVATRate: 'VAT Rate|อัตราVAT',
                lblTaxRate: 'TaxRate|อัตราหัก',
                lblPayType: 'Pay Type|ช่องทางชำระ',
                lblTotalExpense: 'Amount|ยอดรวม',
                lblTotalVAT: 'VAT|VAT',
                lblTotalTax: 'WH-Tax|หัก ณ ที่จ่าย',
                lblTotalDiscount: 'Discount|ส่วนลด',
                lblTotalNet: 'Total|สุทธิ',
                lblDetail: 'Detail|รายละเอียด',
                lblItemNo: 'No.|ลำดับที่',
                lblCopy: 'Use copy mode|ไม่ต้องล้างข้อมูล',
                lblJobNo: 'Job No|หมายเลขงาน',
                lblSICode: 'SICode|รหัสค่าบริการ',
                lblCustCode: 'For|สำหรับลูกค้า',
                lblBookingNo: 'Booking No|เลขที่ใบจอง',
                lblContNo: 'Container No|หมายเลขตู้',
                lblDescription: 'Description|รายละเอียดค่าบริการ',
                lblQty: 'Qty|จำนวน',
                lblQtyUnit: 'Unit|หน่วย',
                lblUnitPrice: 'Price|ราคา',
                lblAmt: 'Amount|รวม',
                lblDiscountPerc: 'Discount%|อัตราส่วนลด',
                lblIsTaxCharge: 'Vatable|ฐาน VAT',
                lblAmtVAT: 'VAT|VAT',
                lblIs50Tavi: 'Taxable|ฐานหัก',
                lblAmtWHT: 'WH-Tax|ยอดหัก',
                lblNETAmount: 'Net|สุทธิ',
                lblTotal: 'Total|รวมบาท',
                lblFTotal: 'Total(F)|รวมต่างประเทศ',
                lblSRemark: 'Remark|หมายเหตุ',
                lblClearingNo: 'Clearing No.|เลขที่ใบปิด',
                linkNew: 'New|เพิ่มรายการ',
                linkUpdate: 'Save|จัดเก็บรายการ',
                lblPayHeader: 'Billing Expenses|บิลค่าใช้จ่าย',
                btnSelPrice: 'Select Price|เลือกราคา'
            };
            break;
        case 'MODULE_ACC/Invoice':
            lang = {
                lblTitle: 'Invoice|ใบแจ้งหนี้',
                lblBranch: 'Branch|รหัสสาขา',
                lblDocDateF: 'Invoice Date From|วันที่ใบแจ้งหนี้',
                lblDocDateT: 'Invoice Date To|ถึงวันที่',
                lblCustCode: 'Customer|รหัสลูกค้า',
                linkSearch: 'Search|ค้นหา',
                linkGen: 'Create Invoice|สร้างใบแจ้งหนี้ใหม่',
                lblCancel: 'Show Cancel Only|แสดงที่ยกเลิก',
                linkHeader: 'Headers|ส่วนควบคุม',
                linkDetail: 'Details|ส่วนรายการ',
                lblDetInv: 'Details Of Invoice No|รายการในใบแจ้งหนี้',
                lblPrint: 'Print|พิมพ์เอกสาร',
                lblDCustCode: 'Customer|รหัสลูกค้า',
                lblDocNo: 'Invoice No|ใบแจ้งหนี้เลขที่',
                lblDocDate: 'Doc.Date|วันที่เอกสาร',
                lblTotalAdvance: 'Advance|ทดรองจ่าย',
                lblTotalCharge: 'Charge|ค่าบริการ',
                lblSumDiscount: 'Discount|ส่วนลดการค้า',
                lblDiscountCal: 'Disc.Total|รวมส่วนลด',
                lblTotalIsTaxCharge: 'Vatable|ฐานภาษีมูลค่าเพิ่ม',
                lblVatRate: 'VAT Rate|อัตราภาษี',
                lblTotalVat: 'VAT|ภาษีมูลค่าเพิ่ม',
                lblTotalIs50Tavi: 'Taxable|ฐานภาษีหัก ณ ที่จ่าย',
                lblTotal50Tavi: 'WH-Tax|หัก ณ ที่จ่าย',
                lblTotalCustAdv: 'Cust.Adv|รับล่วงหน้า',
                lblTotalNet: 'Total Inv|รวมใบแจ้งหนี้',
                lblContactName: 'Contact Name|ผู้ติดต่อ',
                lblShippingRemark: 'Shipping Note|หมายเหตุ',
                lblDueDate: 'Due Date|กำหนดชำระเงิน',
                lblBillToCustCode: 'Billing To|สถานที่วางบิล',
                lblBillAcceptNo: 'Bill.No|เลขที่ใบวางบิล',
                lblBillIssueDate: 'Issue Date|วันที่วางบิล',
                lblBillAcceptDate: 'Accept Date|วันที่รับวางบิล',
                lblDiscountRate: 'Discount Rate(%)|อัตราส่วนลด(%)',
                lblCalDiscount: 'Discount|ส่วนลดเงินสด',
                lblCurrencyCode: 'Currency Code|รหัสสกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblForeignNet: 'Total Foreign|รวมตามสกุลเงิน',
                lblCreateDate: 'Create Date|วันที่สร้างเอกสาร',
                lblRemark: 'Note|บันทึกเพิ่มเติม',
                lblCancelReson: 'CancelReson|สาเหตุที่ยกเลิก',
                lblCancelDate: 'Date|วันที่ยกเลิก',
                lblCancelTime: 'Time|เวลาที่ยกเลิก',
                lblCancelProve: 'Cancel By|ยกเลิกโดย',
                linkSave: 'Save|บันทึกใบแจ้งหนี้',
                linkPrint: 'Print|พิมพ์ใบแจ้งหนี้',
                lblDDocNo: 'Invoice No|เลขที่',
                lblItemNo: 'Item No.|ลำดับที่',
                lblSICode: 'Code|รหัสค่าบริการ',
                lblExpSlipNO: 'Slip No|เลขที่ใบเสร็จ',
                lblDCurrencyCode: 'Currency Code|รหัสสกุลเงิน',
                lblDExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblDiscountType: 'Discount Type|ประเภทส่วนลด',
                lblSRemark: 'Remark|หมายเหตุ',
                lblCurrencyCodeCredit: 'Currency Code|รหัสสกุลเงิน',
                lblExchangeRateCredit: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblQty: 'Qty|จำนวน',
                lblQtyUnit: 'QtyUnit|หน่วย',
                lblUnitPrice: 'Price(B)|ราคา(B)',
                lblAmt: 'Amount(B)|รวม(B)',
                lblIsTaxCharge: 'Vatable|ฐานภาษี',
                lblDVATRate: 'VAT Rate|อัตรา VAT',
                lblAmtDiscount: 'Discount (B)|ส่วนลด(B)',
                lblIs50Tavi: 'Taxable|ฐานหักณที่จ่าย',
                lblRate50Tavi: 'Rate|อัตราหัก',
                lblFAmtDiscount: 'Discount (F)|ส่วนลด (F)',
                lblFAmtCredit: 'Credit (F)|รับล่วงหน้า (F)',
                lblAmtCredit: 'Credit (B)|รับล่วงหน้า (B)',
                lblFUnitPrice: 'Price(F)|ราคา(F)',
                lblFAmt: 'Amount(F)|สุทธิ(F)',
                lblAmtAdvance: 'Advance|Advance',
                lblAmtCharge: 'Charge|Charge',
                lblFTotalAmt: 'Total(F)|รวมยอด(F)',
                lblTotalAmt: 'Total(B)|รวมยอด(B)',
                linkUpdate: 'Save|จัดเก็บข้อมูล',
                linkDelete: 'Delete|ลบข้อมูล'
            };
            break;
        case 'MODULE_ACC/CreditNote':
            lang = {
                lblTitle: 'Credit/Debit Note|ใบเพิ่มหนี้/ลดหนี้',
                lblBranch: 'Branch|สาขา',
                lblCustCode: 'Customer|ลูกค้า',
                lblDocDateF: 'Document Date From|วันที่เอกสารตั้งแต่',
                lblDocDateT: 'Document Date To|ถึงวันที่',
                linkSearch: 'Search|ค้นหา',
                linkCreate: 'Create New|สร้างรายการใหม่',
                lblHeader: 'Header|ส่วนควบคุม',
                lblDetail: 'Detail|ส่วนรายการ',
                lblCancel: 'Show Cancel Only|แสดงยกเลิกเท่านั้น',
                linkAdd: 'Add Invoice|เพิ่มใบแจ้งหนี้',
                lblDocNo: 'Document No|เลขที่เอกสาร',
                lblDocDate: 'Doc.Date|วันที่เอกสาร',
                lblDocType: 'Document Type|ประเภทเอกสาร',
                lblCreateBy: 'Create By|สร้างโดย',
                lblUpdate: 'Last update|ปรับปรุงล่าสุด',
                lblRemark: 'Document Note|บันทึกเอกสาร',
                lblCustNo: 'Customer|ลูกค้า',
                lblApprDate: 'Approve Date|วันที่อนุมัติ',
                lblApprTime: 'Approve Time|เวลาที่อนุมัติ',
                lblApprBy: 'Approve By|ผู้อนุมัติ',
                btnCancel: 'Cancel|ยกเลิก',
                lblCancelDate: 'Cancel date|วันที่ยกเลิก',
                lblUpdateBy: 'Update By|ผู้ปรับปรุง',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                linkSave: 'Save|บันทึกข้อมูล',
                linkPrint: 'Print|พิมพ์ข้อมูล',
                lblDDocNo: 'Doc.No|เลขที่เอกสาร',
                lblSeq: 'Seq.|ลำดับที่',
                lblInvNo: 'Inv.No|ใบแจ้งหนี้',
                lblSICode: 'Code|รหัสค่าบริการ',
                lblCurrCode: 'Currency|สกุลเงิน',
                lblExcRate: 'Exc.Rate|อัตราแลกเปลี่ยน',
                lblOriginal: 'Original|ยอดเดิม',
                lblCorrect: 'Correct|ยอดใหม่',
                lblDiff: 'Diff|ผลต่าง',
                lblVat: 'VAT|VAT',
                lblVATRate: 'Rate|อัตรา',
                lblWht: 'WHT|หัก ณ ที่จ่าย',
                lblWhtRate: 'Rate|อัตรา',
                lblNet: 'Net Change (B)|ยอดสุทธิ',
                lblFNet: 'Net Change (F)|ยอดต่างประเทศ',
                linkUpdate: 'Update|จัดเก็บรายการ',
                linkDelete: 'Delete|ลบรายการ',
                lblSelInv: 'Select Invoice|เลือกใบแจ้งหนี้'
            };
            break;
        case 'MODULE_ACC/Payment':
            lang = {
                lblTitle: 'Expense Payment|จ่ายเงินตามบิลค่าใช้จ่าย',
                linkTab1: 'Select document|เลือกเอกสารที่ต้องการ',
                linkTab2: 'Payment Info|ข้อมูลการชำระเงิน',
                linkTab3: 'Payment Detail|สรุปข้อมูลการจ่ายเงิน',
                optTab1: 'Select document|เลือกเอกสารที่ต้องการ',
                optTab2: 'Payment Info|ข้อมูลการชำระเงิน',
                optTab3: 'Payment Detail|สรุปข้อมูลการจ่ายเงิน',
                lblBranch: 'Branch|สาขา',
                lblPayFor: 'Payment For|จ่ายให้กับ',
                lblCurrency: 'Payment Currency|สกุลเงินที่จ่าย',
                lblDateFrom: 'Due Date From|จากวันกำหนดชำระ',
                lblDateTo: 'Due Date To|ถึงวันที่',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Payment Document|เอกสารที่เลือก',
                linkCash: 'Cash/Transfer|เงินสด/เงินโอน',
                lblBookCA: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCA: 'Trans.No (BFT)|เลขที่สลิปอ้างอิง',
                lblTranDateCA: 'Trans.Date|วันที่ทำรายการ',
                lblTranTimeCA: 'Trans.Time|เวลาที่ทำรายการ',
                lblBankCA: 'To Bank|ธนาคารที่รับโอน',
                lblBranchCA: 'To Branch|สาขาที่รับโอน',
                lblPayCA: 'Pay To|ชื่อบัญชที่โอนเข้า',
                linkChqCash: 'Company Chq (BFT)|เช็คบริษัทจ่าย',
                lblBookCH: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCH: 'Chq.No|เลขที่เช็ค',
                lblTranDateCH: 'Chq.Date|วันที่เช็ค',
                lblStatusCH: 'Cashier Cheque|เป็นแคชเชียร์เช็ค',
                lblBankCH: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCH: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCH: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkChqCust: 'Customer Cheque|เช็คลูกค้าจ่าย',
                lblRefNoCU: 'Cheque No|เลขที่เช็ค',
                lblTranDateCU: 'Chq.Date|วันที่เช็ค',
                lblStatusCU: 'Local|เช็คข้ามจังหวัด',
                lblBankCU: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCU: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCU: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkCred: 'Credit|เครดิตบัญชี',
                lblRefNoCR: 'Ref No|เลขที่การลงบัญชี',
                lblTranDateCR: 'Ref Date|วันที่การลงบัญชี',
                lblPayCR: 'Pay To|ชื่อผู้รับบริการ',
                linkBal: 'Balance|ยอดคงเหลือ',
                lblForCA: 'For Cash/Transfer|สำหรับเงินสด/เงินโอน',
                lblForCH: 'For Cheque|สำหรับจ่ายเชิ็ค',
                lblPayDate: 'Payment Date|วันที่จ่ายเงิน',
                lblPayTotal: 'Payment Total|ยอดเงินรวม',
                lblWTTotal: 'W/T Total|ยอดหัก ณ ที่จ่าย',
                lblRemark: 'Remark|บันทึกการจ่ายเงิน',
                linkSave: 'Save Payment|บันทึกการจ่ายเงิน',
                lblCaptionChq: 'Select Cheque Onhand|เลือกเช็คที่ต้องการทำรายการ'
            };
            break;
        case 'MODULE_ACC/PettyCash':
            lang = {
                lblTitle: 'Petty Cash Management|บันทีกรับจ่ายเงินสด/เงินฝาก',
                lblBranch: 'Branch|สาขา',
                lblTranType: 'Transaction Type|ประเภทการทำรายการ',
                optRcv: 'Received From|รับ/ฝากเงิน',
                optPay: 'Paid To|จ่าย/ถอนเงิน',
                linkRef: 'Reference No|เลขที่บันทึกบัญชี',
                lblVoucherDate: 'Record Date|วันที่บันทึกรายการ',
                lblTRemark: 'Transaction Note|บันทึก',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                lblRecBy: 'Record By|ผู้บันทึกรายการ',
                lblRecDate: 'Date|วันที่',
                lblRecTime: 'Time|เวลา',
                lblPostBy: 'Posted By|ตรวจสอบโดย',
                lblPostDate: 'Date|วันที่',
                lblPostTime: 'Time|เวลา',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelDate: 'Date|วันที่',
                lblCancelTime: 'Time|เวลา',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblTranInfo: 'Transaction Info|ข้อมูลการนำจ่าย',
                lblVatInfo: 'Expense Info|ข้อมูลค่าใช้จ่าย',
                lblItemNo: 'No|ลำดับที่',
                lblVCNo: 'Voucher No|เลขที่ใบสำคัญ',
                lblTranDType: 'Transaction Type|รูปแบบรายการ',
                optDeposit: 'Deposit|ฝาก/รับเงิน',
                optWithdraw: 'Withdraw|ถอน/จ่ายเงิน',
                linkBook: 'Book A/C (BFT)|เลขที่บัญชี',
                lblBookName: 'Book Name|ชื่อบัญชี',
                lblBankCode: 'Bank Code|ธนาคารเจ้าของบัญชี',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblBankBranch: 'Branch|สาขา',
                lblCashAmount: 'Amount|ยอดเงิน',
                linkDocType: 'Doc.Type|ประเภทเอกสาร',
                linkDocNo: 'Ref.No|เลขที่เอกสารอ้างอิง',
                lblPayTo: 'Paid To|จ่ายให้กับ',
                linkCurr: 'Currency|สกุลเงิน',
                lblCurrName: 'Currency Name|ชื่อสกุลเงิน',
                lblAmtBase: 'Amount Base|ยอดเงิน',
                lblExcRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblTotalAmt: 'Total Amount|ฐานภาษี',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                lblNote: 'Description|บันทึกเพิ่มเติม',
                linkUpdate: 'Save Data|จัดเก็บรายการ',
                linkDelete: 'Delete Data|ลบรายการ',
                linkClear: 'Clear Entry|เพิ่มเอกสารใหม่',
                linkSave: 'Save Entry|บันทีกเอกสาร',
                linkPrint: 'Print Entry|พิมพ์เอกสาร'
            };
            break;
        case 'MODULE_ACC/Receipt':
            lang = {
                lblTitle: 'Receipts|ใบเสร็จรับเงิน',
                lblBranch: 'Branch|สาขา',
                lblCustCode: 'Customer|ลูกค้า',
                lblDocDateF: 'Receipt Date From|วันที่ใบเสร็จตั้งแต่',
                lblDocDateT: 'Receipt Date To|ถึงวันที่',
                lblSearch: 'Search|ค้นหา',
                lblCreate: 'Create Receipts|สร้างใบเสร็จรับเงิน',
                linkHeader: 'Headers|ส่วนควบคุม',
                linkDetail: 'Details|ส่วนรายการ',
                lblCancel: 'Show cancel only|แสดงที่ยกเลิกเท่านั้น',
                lblDocNoDet: 'Details of Receipt No:|รายการของใบเสร็จรับเงินเลขที่',
                lblPrint: 'Print|พิมพ์ใบเสร็จรับเงิน',
                lblReceiptNo: 'Receipt No|เลขที่ใบเสร็จ',
                lblReceiptDate: 'Doc.Date|วันที่เอกสาร',
                lblHCustCode: 'Customer|ลูกค้า',
                lblBillToCustCode: 'Bill To|สถานที่วางบิล',
                lblTRemark: 'Receipt Note|หมายเหตุ',
                lblCurrencyCode: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblFTotalNet: 'Total Foreign|รวมเงิน',
                lblTotalCharge: 'Total Charge|รวมค่าบริการ',
                lblTotalVAT: 'Total VAT|ยอด VAT',
                lblTotal50Tavi: 'Total TAX|ยอดหัก ณ ที่จ่าย',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                lblReceiveRef: 'Voucher Ref|เลขที่ใบสำคัญรับ',
                lblReceiveDate: 'Receive Date|วันที่รับชำระ',
                lblReceiveTime: 'Receive Time|เวลา',
                lblReceiveBy: 'Receive By|ผู้รับชำระ',
                lblEmpCode: 'Create By|สร้างโดย',
                lblPrintedDate: 'Print Date|วันที่พิมพ์',
                lblPrintedTime: 'Print Time|เวลา',
                lblPrintedBy: 'Print By|พิมพ์โดย',
                lblCancelReson: 'Cancel Reason|เหตุผลที่ยกเลิก',
                btnCancel: 'Cancel|ยกเลิก',
                lblCancelDate: 'Cancel date|วันที่ยกเลิก',
                lblCancelTime: 'Cancel Time|เวลาที่ยกเลิก',
                lblCancelProve: 'Cancel By|ผู้ยกเลิก',
                linkSave: 'Save|บันทึก',
                linkPrint: 'Print|พิมพ์',
                lblDDocNo: 'Receipt No|เลขที่ใบเสร็จ',
                lblItemNo: 'Item No.|ลำดับที่',
                lblInvoiceNo: 'Invoice No|ใบแจ้งหนี้',
                lblInvoiceItemNo: 'No#|No#',
                lblSICode: 'Code|รหัสค่าบริการ',
                lblPayType: 'Payment Type|ประเภทรับชำระ',
                lblDCurrencyCode: 'Currency|สกุลเงิน',
                lblDExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblAmt: 'Amount|ยอดรวมบาท',
                lblAmtF: 'Amount (F)|ยอดต่างประเทศ',
                lblIsTaxCharge: 'Vatable|ฐานภาษี',
                lblVATRate: 'VAT Rate|อัตรา VAT',
                lblAmtVAT: 'VAT|VAT',
                lblIs50Tavi: 'Taxable|หัก ณ ที่จ่าย',
                lblRate50Tavi: 'Rate|อัตราหัก',
                lblAmt50Tavi: 'WHT|ยอดหัก',
                lblNet: 'Net|ยอดสุทธิ',
                lblFAmtVAT: 'VAT (F)|VAT (F)',
                lblFAmt50Tavi: 'WH-Tax (F)|WH-Tax (F)',
                lblFNet: 'Net (F)|สุทธิ (F)',
                lblVoucherNo: 'Voucher No|เลขที่ใบสำคัญ',
                lblControlNo: 'Control No|เลขที่การลงบัญชี',
                lblControlItemNo: '#No|#No',
                lblCashAmount: 'Cash|เงินสด',
                lblTransferAmount: 'Transfer|เงินโอน',
                lblChequeAmount: 'Cheque|เช็ค',
                lblCreditAmount: 'Credit|ลดหนี้',
                linkSave: 'Save|บันทีกข้อมูล',
                linkDel: 'Delete|ลบขัอมูล'
            }
            break;
        case 'MODULE_ACC/GenerateInv':
            lang = {
                lblTitle: 'Generate Invoice|สร้างใบแจ้งหนี้',
                lblBranch: 'Branch|สาขา',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblCustCode: 'Customer|ลูกค้า',
                linkJobNo: 'Job No|หมายเลขงาน',
                linkSearch: 'Search|ค้นหา',
                linkCreate: 'Create Invoice|สร้างใบแจ้งหนี้',
                linkReset: 'Reset Select|ล้างรายการที่เลือก',
                lblInvDate: 'Invoice Date|วันที่เอกสาร',
                lblInvType: 'Invoice Type|ประเภท',
                lblReplaceInv: 'Replace Invoice No|แทนเอกสารเลขที่',
                lblPrintDoc: 'Print Invoice|พิมพ์เอกสาร',
                lblDiscountRate: 'Discount Rate(%)|อัตราส่วนลด',
                lblCalDiscount: 'Discount Amt|ยอดส่วนลด',
                lblCheque: 'Use Customer Cheque|จัดเช็ครับล่วงหน้า',
                lblChqAmount: 'Cheque Used|ยอดที่ใช้',
                linkChq: 'Customer Cheques|เช็ครับล่วงหน้า',
                linkCost: 'Costing of Invoices|ต้นทุนของใบแจ้งหนี้',
                linkInv: 'Invoice Summary|สรุปยอดแจ้งหนี้',
                colAdv: 'Advance|คชจ จ่ายแทน',
                colChg: 'Charge|ค่าบริการ',
                colDis: 'Line Discount|ส่วนลดการค้า',
                colVatB: 'Vatable|ฐาน VAT',
                colTaxB: 'Taxable|ฐานหัก ณ ที่จ่าย',
                colVat: 'VAT|VAT',
                colSumVat: 'After VAT|รวม VAT',
                colCustAdv: 'Cust.Advance|จ่ายล่วงหน้า',
                colWH: 'WH-Tax|หัก ณ ที่จ่าย',
                colSumWH: 'After WHT|รวมหัก ณ ที่จ่าย',
                colSumDisc: 'Sum Discount|รวมหักส่วนลด',
                colNet: 'NET|รวมเรียกเก็บ',
                colCurr: 'Currency|สกุลเงิน',
                colExc: 'Exc Rate|อัตราแลกเปลี่บน',
                colInv: 'Invoice|รวมใบแจ้งหนี้',
                colCost: 'Cost|รวมต้นทุน',
                colProfit: 'Profit|รวมกำไร',
                linkSave: 'Save Invoice|สร้างใบแจ้งหนี้',
                linkDet: 'Invoice Detail|รายการใบแจ้งหนี้',
                btnMerge: 'Group Data|รวมรายการที่ซ้ำ',
                lblClearNo: 'Clearing No|เลขที่ใบปิด',
                lblJNo: 'Job No|หมายเลขงาน',
                lblCode: 'Code|รหัสค่าบริการ',
                lblDesc: 'Description|คำอธิบาย',
                lblAdv: 'Advance|ค่าใช้จ่ายจ่ายแทน',
                lblQtyD: 'Qty|จำนวน',
                lblUnitD: 'Unit|หน่วย',
                lblChg: 'Charges|ค่าบริการ',
                lblDisc: 'Disc (%)|อัตราส่วนลด',
                lblDiscAmt: 'Discount|ยอดลด',
                lblVATRate: 'VAT Rate|อัตรา VAT',
                lblVAT: 'VAT|VAT',
                lblWTRate: 'W/T|อัตรา WHT',
                lblWT: 'WH-Tax|หัก ณ ที่จ่าย',
                lblNetAmt: 'NET|สุทธิ',
                linkUpdate: 'Update Data|ปรับปรุงข้อมูล'
            };
            break;
        case 'MODULE_ACC/GLNote':
            lang = {
                lblTitle: 'Journal Entry|สมุดรายวัน',
                lblBranch: 'Branch|สาขา',
                lblBatchNo: 'Batch No|เลขที่ลงบัญชี',
                lblRecBy: 'Record By|บันทึกโดย',
                lblRecDate: 'Record Date|วันที่บันทึก',
                lblGLType: 'GL Type|ประเภทสมุดรายวัน',
                lblRemark: 'Remark|หมายเหตุ',
                lblYear: 'Fiscal Year|ปีบัญชี',
                linkAdd: 'Add Entry|เพิ่มรายการ',
                lblTotalDr: 'Total Debit|รวมเดบิต',
                lblTotalCr: 'Total Credit|รวมเครดิต',
                lblApprDate: 'Approve Date|วันที่อนุมัติ',
                lblApprBy: 'Approve By|ผู้อนุมัติ',
                lblPostDate: 'Post Date|วันที่ลงบัญชี',
                lblPostBy: 'Post By|ผู้บันทึกบัญชี',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                linkNew: 'New|เพิ่มเอกสารใหม่',
                linkSave: 'Save|บันทึก',
                linkCancel: 'Cancel|ยกเลิก',
                linkPrint: 'Print|พิมพ์',
                lblItemNo: 'Entry No|ลำดับที่',
                lblEntryDate: 'Entry Date|วันที่ทำรายการ',
                lblEntryBy: 'Entry By|ผู้ทำรายการ',
                lblAcCode: 'A/C Code|เลขที่บัญชี',
                lblAcDesc: 'A/C Description|คำอธิบายบัญชี',
                lblDr: 'Debit|เดบิต',
                lblCr: 'Credit|เครดิต',
                lblRefNo: 'Ref.No|เลขที่อ้างอิง',
                lblAdd: 'Add Entry|เพิมรายการ',
                lblUpdate: 'Save Entry|จัดเก็บรายการ',
                lblDelete: 'Delete Entry|ลบรายการ'
            };
            break;
        case 'MODULE_ACC/RecvInv':
            lang = {
                lblTitle: 'Invoice Receive|รับชำระใบแจ้งหนี้',
                linkTab1: 'Select Type|ประเภทการรับชำระ',
                linkTab2: 'Document Info|เลือกเอกสาร',
                linkTab3: 'Receiving Summary|สรุปข้อมูลการชำระเงิน',
                optTab1: 'Select Type|ประเภทการรับชำระ',
                optTab2: 'Document Info|เลือกเอกสาร',
                optTab3: 'Receiving Summary|สรุปข้อมูลการชำระเงิน',
                linkCash: 'Cash/Transfer|เงินสด/เงินโอน',
                lblBookCA: 'Book A/C|จากสมุดบัญชี',
                lblRefNoCA: 'Trans.No|เลขที่สลิปอ้างอิง',
                lblTranDateCA: 'Trans.Date|วันที่ทำรายการ',
                lblTranTimeCA: 'Trans.Time|เวลาที่ทำรายการ',
                lblBankCA: 'To Bank|ธนาคาร',
                lblBranchCA: 'To Branch|สาขา',
                lblPayCA: 'Pay To|ชื่อบัญชี',
                linkChqCash: 'Company Chq|เช็คบริษัท',
                lblBookCH: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCH: 'Chq.No|เลขที่เช็ค',
                lblTranDateCH: 'Chq.Date|วันที่เช็ค',
                lblStatusCH: 'Cashier Cheque|เป็นแคชเชียร์เช็ค',
                lblBankCH: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCH: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCH: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkChqCust: 'Customer Cheque|เช็คลูกค้า',
                lblRefNoCU: 'Cheque No|เลขที่เช็ค',
                lblTranDateCU: 'Chq.Date|วันที่เช็ค',
                lblStatusCU: 'Local|เช็คข้ามจังหวัด',
                lblBankCU: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCU: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCU: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkCred: 'Credit|เครดิตบัญชี',
                lblRefNoCR: 'Ref No|เลขที่การลงบัญชี',
                lblTranDateCR: 'Ref Date|วันที่การลงบัญชี',
                lblPayCR: 'Pay To|ชื่อผู้รับบริการ',
                linkBal: 'Balance|ยอดคงเหลือ',
                lblForCA: 'For Cash/Transfer|สำหรับเงินสด/เงินโอน',
                lblForCH: 'For Cheque|สำหรับจ่ายเชิ็ค',
                lblBranch: 'Branch|สาขา',
                lblGroupByDoc: 'Payment By Invoice|ชำระเงินแบบตามเอกสาร',
                lblSearchByDue: 'Search By Due Date|ค้นหาตามกำหนดวันชำระเงิน',
                lblCustCode: 'Customer|ลูกค้า',
                lblDateFrom: 'Invoice Date From|ใบแจ้งหนี้ตั้งแต่วันที่',
                lblDateTo: 'Invoice Date To|จนถึงวันที่',
                lblTaxNo: 'Receipt/Tax Inv.No|ระบุเลขที่ใบเสร็จ/ใบกำกับภาษี',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Receive Document|เอกสารที่เลือก',
                lblPayDate: 'Payment Date|วันที่ชำระเงิน',
                lblPayTotal: 'Payment Total|ยอดเงินรวม',
                lblWTTotal: 'W/T Total|ยอดหัก ณ ที่จ่าย',
                lblRemark: 'Remark|หมายเหตุการชำระเงิน',
                linkSave: 'Save Payment|บันทึกการชำระเงิน'
            }
            break;
        case 'MODULE_ACC/TaxInvoice':
            lang = {
                lblTitle: 'Tax-Invoice|ใบกำกับภาษี',
                lblBranch: 'Branch|สาขา',
                lblCustCode: 'Customer|ลูกค้า',
                lblDocType: 'Type of Documents|ประเภทเอกสาร',
                lblDocDateF: 'Tax-Invoice Date From|วันที่ใบกำกับภาษีตั้งแต่',
                lblDocDateT: 'Tax-Invoice Date To|ถึงวันที่',
                lblSearch: 'Search|ค้นหา',
                lblCreate: 'Create Tax-Invoice|สร้างใบกำกับภาษี',
                linkHeader: 'Headers|ส่วนควบคุม',
                linkDetail: 'Details|ส่วนรายการ',
                lblCancel: 'Show cancel only|แสดงที่ยกเลิกเท่านั้น',
                lblDocNoDet: 'Details of Tax-Invoice No:|รายการของใบกำกับภาษีเลขที่',
                lblPrint: 'Print|พิมพ์ใบกำกับภาษี',
                lblReceiptNo: 'Tax-Invoice No|เลขที่ใบกำกับภาษี',
                lblReceiptDate: 'Doc.Date|วันที่เอกสาร',
                lblHCustCode: 'Customer|ลูกค้า',
                lblBillToCustCode: 'Bill To|สถานที่วางบิล',
                lblTRemark: 'Receipt Note|หมายเหตุ',
                lblCurrencyCode: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblFTotalNet: 'Total Foreign|รวมเงิน',
                lblTotalCharge: 'Total Charge|รวมค่าบริการ',
                lblTotalVAT: 'Total VAT|ยอด VAT',
                lblTotal50Tavi: 'Total TAX|ยอดหัก ณ ที่จ่าย',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                lblReceiveRef: 'Voucher Ref|เลขที่ใบสำคัญรับ',
                lblReceiveDate: 'Receive Date|วันที่รับชำระ',
                lblReceiveTime: 'Receive Time|เวลา',
                lblReceiveBy: 'Receive By|ผู้รับชำระ',
                lblEmpCode: 'Create By|สร้างโดย',
                lblPrintedDate: 'Print Date|วันที่พิมพ์',
                lblPrintedTime: 'Print Time|เวลา',
                lblPrintedBy: 'Print By|พิมพ์โดย',
                lblCancelReson: 'Cancel Reason|เหตุผลที่ยกเลิก',
                btnCancel: 'Cancel|ยกเลิก',
                lblCancelDate: 'Cancel date|วันที่ยกเลิก',
                lblCancelTime: 'Cancel Time|เวลาที่ยกเลิก',
                lblCancelProve: 'Cancel By|ผู้ยกเลิก',
                linkSave: 'Save|บันทึก',
                linkPrint: 'Print|พิมพ์',
                lblDDocNo: 'Tax-Inv No|เลขที่ใบกำกับ',
                lblItemNo: 'Item No.|ลำดับที่',
                lblInvoiceNo: 'Invoice No|ใบแจ้งหนี้',
                lblInvoiceItemNo: 'No#|No#',
                lblSICode: 'Code|รหัสค่าบริการ',
                lblPayType: 'Payment Type|ประเภทรับชำระ',
                lblDCurrencyCode: 'Currency|สกุลเงิน',
                lblDExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblAmt: 'Amount|ยอดรวมบาท',
                lblAmtF: 'Amount (F)|ยอดต่างประเทศ',
                lblIsTaxCharge: 'Vatable|ฐานภาษี',
                lblVATRate: 'VAT Rate|อัตรา VAT',
                lblAmtVAT: 'VAT|VAT',
                lblIs50Tavi: 'Taxable|หัก ณ ที่จ่าย',
                lblRate50Tavi: 'Rate|อัตราหัก',
                lblAmt50Tavi: 'WHT|ยอดหัก',
                lblNet: 'Net|ยอดสุทธิ',
                lblFAmtVAT: 'VAT (F)|VAT (F)',
                lblFAmt50Tavi: 'WH-Tax (F)|WH-Tax (F)',
                lblFNet: 'Net (F)|สุทธิ (F)',
                lblVoucherNo: 'Voucher No|เลขที่ใบสำคัญ',
                lblControlNo: 'Control No|เลขที่การลงบัญชี',
                lblControlItemNo: '#No|#No',
                lblCashAmount: 'Cash|เงินสด',
                lblTransferAmount: 'Transfer|เงินโอน',
                lblChequeAmount: 'Cheque|เช็ค',
                lblCreditAmount: 'Credit|ลดหนี้',
                linkSave: 'Save|บันทีกข้อมูล',
                linkDel: 'Delete|ลบขัอมูล'
            }
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
                lblTotalPayTax: 'Total Tax|ยอดรวมภาษี',
                lblItemNo: 'No.|ลำดับที่',
                lblDocType: 'Doc Type|ประเภทเอกสาร',
                lblRefNo: 'Ref No|เลขที่เอกสารอ้างอิง',
                lblJNo: 'Job No|หมายเลขงาน',
                lblPayDate: 'Pay date|วันที่จ่าย',
                lblIncType: 'Revenue Type|ประเภทรายได้พึงประเมิน',
                lblPayTaxDesc: 'Description|กลุ่มรายได้',
                lblPayRate: 'Tax Rate|อัตราภาษี',
                lblAmount: 'Amount Base|ฐานภาษี',
                lblPayTax: 'Tax Amount|ยอดภาษี',
                linkSaveDet: 'Save Detail|บันทึกรายการ',
                linkDelDet: 'Delete Detail|ลบรายการ'
            };
            break;
        case 'MODULE_ACC/Voucher':
            lang = {
                lblTitle: 'Payment/Receive Vouchers|ข้อมูลการรับ/จ่ายเงิน',
                lblBranch: 'Branch|สาขา',
                linkControlNo: 'Reference No|เลขที่การลงบัญชี',
                lblVoucherDate: 'Voucher Date|วันที่บันทึกรายการ',
                lblTRemark: 'Note|บันทึกเพิ่มเติม',
                lblCustCode: 'Customer Code|รหัสลูกค้า',
                lblCustBranch: 'Branch|สาขา',
                linkTab1: 'Payment Info|ข้อมูลการชำระเงิน',
                linkTab2: 'Reference Documents|เอกสารอ้างอิง',
                linkAdd: 'Add Detail|เพิ่มรายการ',
                linkPay: 'Payment By|รวมจ่ายด้วย',
                lblPayCash: 'Cash|เงินสด',
                lblPayChq: 'Cheque|เช็ค',
                lblPayCred: 'Credit|เครดิตหนี้',
                linkRcv: 'Receive By|รวมรับด้วย',
                lblRcvCash: 'Cash|เงินสด',
                lblRcvChq: 'Cheque|เช็ค',
                lblRcvCred: 'Credit|เครดิตหนี้',
                linkSum: 'Sum|ยอดรวม',
                lblSumPay: 'Payment|รวมจ่าย',
                lblSumRcv: 'Receive|รวมรับ',
                linkTotal: 'Total|รวมสุทธิ',
                lblTotalPR: 'Voucher|รวมทุกรายการ',
                lblTotalDoc: 'Document|รวมทุกเอกสาร',
                linkAddDoc: 'Add Document|เพิ่มเอกสารอ้างอิง',
                lblRecBy: 'Record By|บันทึกโดย',
                lblRecDate: 'Date|วันที่',
                lblRecTime: 'Time|เวลา',
                lblPostBy: 'Posted By|ตรวจสอบโดย',
                lblPostDate: 'Date|วันที่',
                lblPostTime: 'Time|เวลา',
                lblCancelBy: 'Cancel By|ยกเลิกโดย',
                lblCancelDate: 'Date|วันที่',
                lblCancelTime: 'Time|เวลา',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblHeaderDet: 'Filter By Voucher Date|กรองตามวันที่ทำรายการ',
                lblDateFrom: 'From|จากวันที่',
                lblDateTo: 'To|ถึงวันที่',
                btnSearch: 'Search|แสดงข้อมูล',
                lblShowPay: 'Payment Info|ช้อมูลการชำระเงิน',
                lblShowTax: 'VAT/Tax Info|ช้อมูลทางภาษี',
                lblItemNo: 'No|ลำดับที่',
                lblVCNo: 'Voucher No|เลขที่ใบสำคัญ',
                lblType: 'Type|ประเภทบัญชี',
                linkBook: 'Book A/C (BFT)|สมุดบัญชี',
                lblBookName: 'Book Name|ชื่อบัญชี',
                lblBank: 'Bank|ธนาคาร',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblBankBranch: 'Branch|สาขา',
                lblChqNo: 'Cheque No|เลขที่เช็ค',
                lblChqDate: 'C.Date|วันที่เช็ค',
                lblLocalChq: 'Local Cheque|เป็นเช็คต่างจังหวัด',
                lblChqClr: 'CLR|สถานะ',
                linkRecvBank: 'Ref.Bank|ธนาคารที่ทำธุรกรรม',
                lblRefBankName: 'Ref.Bank Name|ชื่อธนาคาร',
                lblRefBankBranch: 'Ref.Branch|สาขา',
                lblCashAmount: 'Cash|ยอดเงินสด',
                lblChqAmount: 'Cheque|ยอดเช็ค',
                lblCreditAmount: 'Credit|ยอดเครดิต',
                lblRef: 'Ref.No|เลขที่อ้างอิง',
                lblPayTo: 'Paid To|ชื่อผู้รับ/จ่ายเงิน',
                linkCurr: 'Currency|สกุลเงิน',
                lblCurrName: 'Currency Name|ชื่อสกุลเงิน',
                lblSumAmt: 'Amount Base|ยอดเงิน',
                lblExcRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblTotalAmt: 'Total Amount|ยอดรวม',
                lblTotalNet: 'Total Net|ยอดสุทธิ',
                linkExpCode: 'Exp.Code|รหัสค่าบริการ',
                lblDRemark: 'Note|หมายเหตุ',
                lblJNo: 'Job No.|หมายเลขงาน',
                linkSaveDet: 'Save Detail|จัดเก็บรายการ',
                linkDelDet: 'Delete Detail|ลบรายการ',
                linkHeaderDoc: 'Document Info|ข้อมูลเอกสารอ้างอิง',
                lblDocItemNo: 'No|ลำดับที่',
                lblCmpType: 'Type|ออกโดย',
                linkComp: 'Company|บริษัท',
                lblCmpBranch: 'Branch|สาขา',
                lblCmpName: 'Name|ชื่อบริษัท',
                lblDocType: 'Doc.Type|ประเภทเอกสาร',
                lblDDocNo: 'Doc.No/Receipts|เลขที่เอกสาร/ใบเสร็จ',
                lblDDocDate: 'Doc.Date|วันที่เอกสาร',
                lblPayType: 'Pay.Type|ประเภทการชำระ',
                lblDocTotal: 'Total|ยอดรวมเอกสาร',
                lblPaidTotal: 'Amount|ยอดรวมที่ชำระ',
                linkSaveDoc: 'Save Document|บันทึกเอกสาร',
                linkDelDoc: 'Delete Document|ลบเอกสาร',
                linkClear: 'Clear Data|ล้างข้อมูล',
                linkSave: 'Save Data|บันทึกข้อมูล',
                linkPrint: 'Print Data|พิมพ์ข้อมูล'
            }
            break;
        case 'MODULE_ADM/Role':
            lang = {
                lblTitle: 'User Role|บทบาทของผู้ใช้งาน',
                lblRoleID: 'Role Id|รหัสบทบาท',
                lblRoleDesc: 'Role Description|คำอธิบาย',
                lblRoleGroup: 'Role Level|ระดับผู้่ใช้งาน',
                lblUser: 'User ID|รหัสพนักงาน',
                lblUserRole: 'User On this Role|พนักงานในบทบาทนี้',
                lblFunction: 'Function|ฟังก์ชั่นการทำงาน',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkAddUser: 'Add Staff|เพิ่มพนักงาน',
                linkCopyUser: 'Copy Authorize From User|คัดลอกสิทธิ์จากพนักงาน',
                linkDeleteUser: 'Remove Staff|ลบพนักงาน',
                linkAddRole: 'Apply Policy|บันทึกสิทธิ์การใช้งาน'
            };
            break;
        case 'MODULE_CLR/Approve':
            lang = {
                lblTitle: 'Clearing Confirmation|อนุมัติใบปิดค่าใช้จ่าย',
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
                linkApprove: 'Confirm|อนุมัติเอกสาร'
            };
            break;
        case 'MODULE_CLR/Earnest':
            lang = {
                lblTitle: 'Earnest/Advance Clearing|รับคืนเงินมัดจำ/ทดรองจ่าย',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Clear Date From|จากวันที่ปิดค่าใช้จ่าย',
                lblDateTo: 'Clear Date To|ถึงวันที่',
                lblJobType: 'Job Type|ประเภทงาน',
                lblClrBy: 'Clear By|ปิดโดย',
                lblExpCode: 'Expense Code|รหัสค่าบริการ',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Approve Document|เอกสารที่เลือก',
                lblTotal: 'Expenses Total|รวมเงิน',
                lblTab1: 'Payment Info|รายการการจ่ายเงิน',
                lblTab2: 'Expense Info|รายการค่าใช้จ่ายที่หัก',
                lblClrNo: 'Clearing No|เลขที่ใบปิด',
                lblSlipNo: 'Slip No|เลขที่ใบเสร็จ',
                lblJNo: 'Job No|หมายเลขงาน',
                lblItemNo: 'Item|รายการ',
                lblVend: 'Vender|ผู้ให้บริการ',
                lblAmt: 'Amount|ยอดเงิน',
                lblExp: 'Expense|หักค่าใช้จ่าย',
                lblRet: 'Return|รับคืน',
                lblDocType: 'Type|ประเภท',
                linkBook: 'Book Account|เข้าบัญชี',
                lblRefNo: 'Ref|เลขที่อ้างอิง',
                lblRefDate: 'Date|วันที่รับคืน',
                linkBank: 'Bank|ธนาคาร',
                lblRefBranch: 'Branch|สาขา',
                linkCode: 'Exp.Code|รหัสค่าใช้จ่าย',
                lblExpSlipNo: 'Exp.Slip|ใบเสร็จค่าใช้จ่าย',
                lblExpAmt: 'Amount|ยอดเงิน',
                lblNet: 'Net|สุทธิ',
                btnAddExpCode: 'Add|เพิ่มค่าใช้จ่าย',
                lblContNo: 'Container No|เบอร์ตู้',
                linkUnit: 'Unit|หน่วยตู้',
                linkSave: 'Save Expense|บันทึกการรับคืน'
            };
            break;
        case 'MODULE_CLR/Index':
            lang = {
                lblTitle: 'Clearing Information|ใบปิดค่าใช้จ่าย',
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
                lblCancelReson: 'Cancel Reason|เหตุผลที่ยกเลิก',
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
                lblVenCode: 'Pay To Vender|จ่ายให้กับ',
                lblDRemark: 'Remark|บันทึกเพิ่มเติม',
                lblIsCost: 'Is Company Cost(Cannot charge)|เป็นต้นทุนของบริษัท',
                lblAdvItemNo: 'Clear From Adv Item.No|ปิดมาจากใบเบิกรายการที่',
                lblAdvNo: 'Adv.No|เลขที่ใบเบิก',
                lblAdvAmt: 'Advance Net|ยอดเงินที่เบิก',
                lblInvNo: 'Invoice#|เลขที่ใบแจ้งหนี้',
                lblPayNo: 'Vender Inv#|เลขที่บิลค่าใช้จ่าย',
                linkClear: 'New|เพิ่มรายการใหม่',
                linkUpdate: 'Save|จัดเก็บรายการ',
                lblHeaderPay: 'Payment Lists|รายการบิลค่าใช้จ่าย',
                lblHeaderAdv: 'Advance Lists|รายการใบเบิกค่าใช้จ่าย',
                lblHeaderQuo: 'Quotation Lists|รายการใบเสนอราคา',
                lblCustCode: 'Customer|ลูกค้า',
                lblFilter: 'Filter By Status|เลือกตามสถานะ'
            };
            break;
        case 'MODULE_CLR/Receive':
            lang = {
                lblTitle: 'Clearing Receive|รับเคลียร์เงินตามใบเบิก/ปิด',
                linkTab1: 'Select Type|ประเภทการรับเคลียร์เงิน',
                linkTab2: 'Document Info|เลือกเอกสาร',
                linkTab3: 'Clearing Summary|สรุปข้อมูลการปิดบัญชี',
                optTab1: 'Select Type|ประเภทการรับเคลียร์เงิน',
                optTab2: 'Document Info|เลือกเอกสาร',
                optTab3: 'Clearing Summary|สรุปข้อมูลการปิดบัญชี',
                linkCash: 'Cash/Transfer|เงินสด/เงินโอน',
                lblBookCA: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCA: 'Trans.No (BFT)|เลขที่สลิปอ้างอิง',
                lblTranDateCA: 'Trans.Date|วันที่ทำรายการ',
                lblTranTimeCA: 'Trans.Time|เวลาที่ทำรายการ',
                lblBankCA: 'To Bank|ธนาคาร',
                lblBranchCA: 'To Branch|สาขา',
                lblPayCA: 'Pay To|ชื่อบัญชี',
                linkChqCash: 'Company Chq (BFT)|เช็คบริษัท',
                lblBookCH: 'Book A/C (BFT)|จากสมุดบัญชี',
                lblRefNoCH: 'Chq.No|เลขที่เช็ค',
                lblTranDateCH: 'Chq.Date|วันที่เช็ค',
                lblStatusCH: 'Cashier Cheque|เป็นแคชเชียร์เช็ค',
                lblBankCH: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCH: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCH: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkChqCust: 'Customer Cheque|เช็คลูกค้า',
                lblRefNoCU: 'Cheque No|เลขที่เช็ค',
                lblTranDateCU: 'Chq.Date|วันที่เช็ค',
                lblStatusCU: 'Local|เช็คข้ามจังหวัด',
                lblBankCU: 'Issue Bank|ธนาคารที่ออกเช็ค',
                lblBranchCU: 'Issue Branch|สาขาที่ออกเช็ค',
                lblPayCU: 'Cheque Pay To|ชื่อผู้รับเงิน',
                linkCred: 'Credit|เครดิตบัญชี',
                lblRefNoCR: 'Ref No|เลขที่การลงบัญชี',
                lblTranDateCR: 'Ref Date|วันที่การลงบัญชี',
                lblPayCR: 'Pay To|ชื่อผู้รับบริการ',
                linkBal: 'Balance|ยอดคงเหลือ',
                lblForCA: 'For Cash/Transfer|สำหรับเงินสด/เงินโอน',
                lblForCH: 'For Cheque|สำหรับจ่ายเชิ็ค',
                lblBranch: 'Branch|สาขา',
                lblJobType: 'Job Type|ประเภทงาน',
                lblReqBy: 'Clearance By|ผู้ปิดบัญชี',
                lblCustCode: 'Customer|ลูกค้า',
                lblDateFrom: 'Payment Date From|ตั้งแต่วันที่จ่ายเงิน',
                lblDateTo: 'Payment Date To|จนถึงวันที่',
                lblClrNoAdv: 'NON-ADVANCE Clearing|เคลียร์เงินจากใบปิดค่าใช้จ่ายที่ไม่มีใบเบิก',
                lblDocNo: 'Clearing Document|ระบุเลขที่ใบเบิก/ใบปิด',
                lblJNo: 'Clearing Job No|หรือระบุหมายเลขงาน',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Receive Document|เอกสารที่เลือก',
                lblPayDate: 'Payment Date|วันที่จ่ายเงิน',
                lblPayTotal: 'Payment Total|ยอดเงินรวม',
                lblWTTotal: 'W/T Total|ยอดหัก ณ ที่จ่าย',
                lblRemark: 'Remark|บันทึกการจ่ายเงิน',
                linkSave: 'Save Payment|บันทึกการจ่ายเงิน'
            };
            break;
        case 'MODULE_CS/Index':
            lang = {
                lblTitle: 'List Job|ค้นหางาน',
                lblBranch: 'Branch|สาขา',
                lblStatus: 'Status|สถานะ',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงาน',
                lblYear: 'Year|ปี',
                lblMonth: 'Month|เดือน',
                lblJob: 'Enter Job >>|คีย์หมายเลขงานที่นี่ >>',
                btnJobSlip: 'Show|แสดง',
                linkCreate: 'Create|สร้างงานใหม่',
                linkSearch: 'Search|ค้นหา',
                lblDutyDate: 'By Inspection Date|ตามวันที่ตรวจปล่อย',
                lblQuickSearch: 'Quick Search|ค้นหาแบบระบุเงื่อนไข',
                lblCliteria: 'Cliteria|ค่าที่ระบุ'
            };
            break;
        case 'MODULE_CS/CreateJob':
            lang = {
                lblTitle: 'Create Job|สร้างหมายเลขงานใหม่',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงานขนส่ง',
                lblBranch: 'Branch|สาขา',
                lblCSCode: 'Support By|พนักงานผู้รับผิดชอบ',
                lblCustCode: 'IM_EX PORTER|ลูกค้า',
                lblBillingPlace: 'BILLING TO|ผู้ซื้อขาย',
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
                btnViewJobS: 'Edit Job Data|แก่ไขข้อมูลงาน',
                btnViewJobT: 'Edit Transport Data|แก่ไขข้อมูลขนส่ง',
                lblForwarder: 'Forwarder/Agent|ตัวแทนเรือ/สายการบิน',
                lblTransport: 'Transporter|ตัวแทนขนส่ง',
                lblLoadDate: 'Load Date|วันที่รับบรรทุก',
                lblETDDate: 'ETD Date|วันที่ออกจากท่าต้นทาง',
                lblETADate: 'ETA Date|วันที่ถึงท่าปลายทาง',
                lblDeliveryDate: 'Delivery Date|วันที่ของถึงปลายทาง',
                lblVesselName: 'Vessel/Flight|ชื่อเรือ/เที่ยวบิน',
                lblInvFCountry: 'From Country|จากประเทศ',
                lblInvCountry: 'To Country|ไปประเทศ',
                lblInterPort: 'International Port|ท่าต่างประเทศ'
            };
            break;
        case 'MODULE_CS/ShowJob':
            lang = {
                lblTitle: 'Job Order|ใบสั่งงาน',
                lblBranchCode: 'Branch|สาขา',
                lblHeaderC: 'Service Summary|บันทึกจำนวนบริการตู้/รถ',
                lblJNo: 'Job Number|หมายเลขงาน',
                lblDocDate: 'Open Date|วันที่เปิดงาน',
                lblJobStatus: 'Job Status|สถานะงาน',
                lblCustCode: 'IM-EX PORTER|ผู้นำเข้าส่งออก',
                lblTAddress: 'Address|ที่อยู่(ไทย)',
                lblPhoneFax: 'Contact Info|รายละเอียดการติดต่อ',
                lblConsignee: 'BillTo/Consignee|ผู้ซื้อขาย',
                lblBillAddress: 'Address|ที่อยู่',
                lblUseLocalTrans: 'Use Local Transport|ใช้รถของลูกค้าเอง',
                lblContactName: 'Contact Person|ผู้ติดต่อ',
                lblCSName: 'Support By|พนักงานผู้รับผิดชอบ',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงานขนส่ง',
                lblJobCondition: 'Work Condition|รูปแบบการทำงาน',
                lblCustPoNo: 'Customer PO|ใบสั่งซื้อของลูกค้า',
                lblDescription: 'Note (Booking)|Note (Booking)',
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
                lblInvProduct: 'Commodity|รายการสินค้า',
                lblInvTotal: 'Inv.Total|มูลค่ารวมอินวอย',
                lblInvCurrency: 'Currency|สกุลเงิน',
                lblExchangeRate: 'Exchange Rate|อัตราแลกเปลี่ยน',
                lblBookingNo: 'Booking No|ใบบุคกิ้ง',
                lblBLNo: 'No. of Original B/L(s)|No. of Original B/L(s)',
                lblHAWB: 'House BL/AWB|House BL/AWB',
                lblMAWB: 'Master BL/AWB|Master BL/AWB',
                lblTotalCTN: 'Detail of CTN|ประเภทตู้',
                lblMeasurement: 'Meas.(M3)|ปริมาตร (M3)',
                lblDeliverNo: 'Delivery No|เลขที่ใบส่งของ',
                lblDeliverTo: 'Sub Agent|ผู้รับแจ้ง',
                lblProjectName: 'Packages Summary|ข้อมูลการบรรจุสินค้า',
                lblInvQty: 'Qty|จำนวนสินค้า',
                lblInvPackQty: 'CTN.Total|จำนวนรวมตู้',
                lblNetWeight: 'Net Weight|น้ำหนักสุทธิ',
                lblGrossWeight: 'Gross Weight|น้ำหนักรวม',
                lblInvFCountry: 'From Country|จากประเทศ',
                lblInvCountry: 'To Country|ไปประเทศ',
                lblInvInterPort: 'Inter Port|ท่าต่างประเทศ',
                lblForwarder: 'Shipping Line|ตัวแทนเรือ/สายการบิน',
                lblVesselName: 'Local Vessel|ชื่อพาหนะ',
                lblMVesselName: 'Ocean Vessel|ชื่อพาหนะถ่ายลำ',
                lblTransport: 'Co-Loader|ตัวแทนโหลดหลัก',
                lblETDDate: 'ETD Date|วันออกจากท่า',
                lblETADate: 'ETA Date|วันเทียบท่า',
                lblLoadDate: 'SI Date|SI Date',
                lblDeliveryDate: 'VGM Date|VGM Date',
                lblDeliverAddr: 'Address|ที่อยู่สถานที่ส่งของ',
                lblEDIDate: 'EDI Date|Declare Accept(01)|วันที่ EDI',
                lblReadyClearDate: 'Declare Accept(02)|วันที่ผ่านพิธีการ',
                lblDutyDate: 'Inspection Date(03)|วันที่ตรวจปล่อย',
                lblClearDate: 'Border Pass Date(04)|วันที่เคลียร์ของ',
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
                lblCustTotal: 'Total Paid|รวมค่าใช้จ่าย',
                lblQtyAdd: 'Qty|จำนวน',
                lblUnitAdd: 'Unit|หน่วยบริการ',
                btnAddCons: 'Add Service|เพิ่มข้อมูล',
                btnSaveCons: 'Update Value|ปรับปรุงข้อมูล',
                lblTotalC: 'Total Service|รวมงานบริการ',
                linkTab1: 'Customer Data|ข้อมูลลูกค้า',
                linkTab2: 'B/L Data|ข้อมูลอินวอยลูกค้า',
                linkTab3: 'Customs Data|ข้อมูลพิธีการ',
                linkTab4: 'Job Instruction|ข้อมูลการทำงาน',
                linkTab5: 'Accounts Control|ข้อมูลอื่นๆ',
                optTab1: 'Customers Data|ข้อมูลลูกค้า',
                optTab2: 'Invoices Data|ข้อมูลอินวอยลูกค้า',
                optTab3: 'Customs Data|ข้อมูลพิธีการ',
                optTab4: 'Job Instruction|ข้อมูลการทำงาน',
                optTab5: 'Accounts Control|ข้อมูลบัญชี',
                btnCloseJob: 'Close Job|ปิดงาน',
                btnCancelJob: 'Cancel Job|ยกเลิกงาน',
                btnDelivery: 'Delivery Slip|พิมพ์ใบส่งของ',
                lblGreen: 'Green|ไม่เปิดตรวจ',
                lblRed: 'Red|เปิดตรวจ',
                lblManual: 'Manual|เดิน Manual',
                btnViewTAdv: 'Accounts Advance|ใบทดรองจ่าย',
                btnViewChq: 'Transfer/Cheque|รับโอนเงินจากลูกค้า',
                linkAddLog: 'Add Remark|เพิ่มหมายเหตุ',
                btnLinkDoc: 'Document Files|จัดเก็บเอกสาร',
                btnLinkLoad: 'Booking Info|ข้อมูลการขนส่ง',
                btnLinkExp: 'Pre-Invoice|ประเมินค่าใช้จ่าย',
                btnLinkCAdv: 'Account Advance|ใบทดรองจ่าย',
                btnLinkAdv: 'Advance Request|ใบเบิกค่าใช้จ่าย',
                btnLinkClr: 'Advance Clearing|ใบปิดค่าใช้จ่าย',
                btnLinkCost: 'Job Summary|ข้อมูลกำไรขาดทุน',
                linkSave: 'Save|บันทึกข้อมูล',
                linkPrint: 'Print|พิมพ์ใบสั่งงาน',
                linkPrintClr: 'Print Instruction|พิมพ์ใบปฏิบัติงาน',		
                btnLinkPaperless: 'Load Data From TAWAN Paperless|ดึงข้อมูลจากระบบ PAPERLESS ตะวัน'
            };
            break;
        case 'MODULE_CS/Transport':
            lang = {
                lblTitle: 'Transport Information|ข้อมูลการรับบรรทุก',
                lblBranchCode: 'Branch|สาขา',
                lblBookingNo: 'Booking No|เลขที่ใบจอง',
                lblJNo: 'Job Number|หมายเลขงาน',
                lblTransportTerm: 'Transport Term|รูปแบบการขนส่ง',
                lblNotify: 'Notify Party|ผู้รับสินค้าปลายทาง',
                lblTransport: 'Transporter|บริษัทขนส่ง',
                lblLoadDate: 'Load Date|วันที่โหลดสินค้า',
                lblContact: 'Contact Name|ผู้ติดต่อ',
                lblRemark: 'Shipping Mask|ตราส่งสินค้า',
                lblPaymentCond: 'Freight Payment Condition|เงื่อนไขการจ่ายค่าเฟรท',
                lblPaymentBy: 'Freight Paid By|ผู้รับผิดชอบค่าใช้จ่าย',
                lblCYDate: 'CY Date :|วันที่รับตู้',
                lblCYTime: 'Time|เวลา',
                lblPackingDate: 'Factory Date:|โหลดของภายในวันที่',
                lblPackingTime: 'Time|เวลา',
                lblFactoryDate: 'Closing Date|ต้องถึงภายในวันที่',
                lblReturnDate: 'Return Date|คืนตู้ภายในวันที่',
                lblReturnTime: 'Time|เวลา',
                lblRoute: 'Delivery Zone|เส้นทางการขนส่ง',
                lblActive: 'Active Trip:|จำนวน',
                lblFinish: 'Finished Trip:|จบงาน',
                lblNonActive: 'Non-active|ยังไม่จบ',
                lblPlace1: 'Port of Receive: |รับสินค้า',
                lblPlace2: 'Port of Loading: |ส่งที่',
                lblPlace3: 'Port of Delivery: |ปล่อยของที่',
                lblPlace4: 'Delivery Agent: |ตัวแทนแจ้ง',
                lblAddress1: 'CY/CFS At:|ที่อยู่',
                lblAddress2: 'RTN At:|ที่อยู่',
                lblAddress3: 'Address:|ที่อยู่',
                lblAddress4: 'Address:|ที่อยู่',
                lblContact1: 'CY/CFS Contact:|ผู้ติดต่อ',
                lblContact2: 'RTN At:|ผู้ติดต่อ',
                lblContact3: 'Contact:|ผู้ติดต่อ',
                lblContact4: 'Contact:|ผู้ติดต่อ',
                lblAutoGenCon: 'Auto Create Items|สร้างตู้สินค้าอัตโนมัติ',
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
                lblPackDetail: 'Description of Goods|ข้อมุลการบรรจุ',
                lblPackQty: 'Qty|จำนวนหีบห่อ',
                lblPackUnit: 'Unit|หน่วยหีบห่อ',
                lblGW: 'G/W|น้ำหนักรวม',
                lblM3: 'M3|M3',
                lblOperDay: 'Cut off Days|จำนวนวันทำงาน',
                lblJobStatus: 'Truck Status|สถานะงาน',
                lblDriver: 'Driver|คนขับ',
                lblTruckNo: 'Truck ID|ทะเบียนรถ',
                lblTruckType: 'Truck Type|ประเภทรถ',
                lblRouteID: 'Zone/Area|เส้นทาง',
                lblLocationD: 'Area Description|การเดินทาง',
                lblComment: 'Remarks for Delivery|บันทึกข้อความ',
                lblShippingMark: 'Shipping Mark|ตราส่งหีบห่อ',
                lblDeliveryNo: 'Delivery No|เลขที่ใบส่งของ',
                lblExpCon: 'Expenses Can be Charged|ค่าใช้จ่ายที่เกิดขึ้นในเส้นทางนี้',
                lblVenBill: 'Expenses Billed|ค่าใช้จ่ายที่ได้รับการวางบิลมาแล้ว',
                linkTab1: 'Booking Information|ข้อมูลใบจอง',
                linkTab2: 'Delivery Information|ข้อมูลเส้นทางการเดินทาง',
                btnSaveLoc: 'Update Area/Zone Data|ปรับปรุงช้อมูลเส้นทาง',
                btnEditExp: 'Edit Area/Zone Expense|บันทึกประเมินราคา',
                linkNew: 'New Booking|เพิ่มข้อมูล',
                linkSave: 'Save Booking|บันทึกข้อมูล',
                linkDel: 'Delete Booking|ลบข้อมูล',
                linkPrint: 'Print Form|พิมพ์ฟอร์ม',
                linkUpCon: 'Update Total Containers To Job|ปรับปรุงข้อมูลจำนวนตู้ใน Job',
                linkAddCon: 'Add Container|เพิ่มตู้สินค้า',
                btnCreateContainer: 'Create|สร้างข้อมูล',
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
                lblPickupTarget: 'Estimate Date|ภายในวันที่',
                lblPickupTargetTime: 'Estimate Time|ก่อนเวลา',
                lblPickupActual: 'Actual Date|วันที่จริง',
                lblPickupActualTime: 'Actual Time|เวลาจริง',
                lblDelivery: 'Delivery|วันโหลดของ',
                lblDeliveryTarget: 'Estimate Date|ภายในวันที่',
                lblDeliveryTargetTime: 'Estimate Time|ก่อนเวลา',
                lblDeliveryActual: 'Actual Date|วันที่จริง',
                lblDeliveryActualTime: 'Actual Time|เวลาจริง',
                lblReturn: 'Return|วันคืนตู้',
                lblReturnTarget: 'Estimate Date|ภายในวันที่',
                lblReturnTargetTime: 'Estimate Time|ก่อนเวลา',
                lblReturnActual: 'Actual Date|วันที่จริง',
                lblReturnActualTime: 'Actual Time|เวลาจริง'
            };
            break;
        case 'MODULE_CS/TruckApprove':
            lang = {
                lblTitle: 'Transport Confirmation|อนุมัติสถานะงานขนส่ง',
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
                linkExp: 'Entry Expense|บันทึกค่าใช้จ่าย'
            };
            break;
        case 'MODULE_MAS/Bank':
            lang = {
                lblTitle: 'Banks|ธนาคาร',
                lblBankCode: 'Bank Code|รหัสธนาคาร',
                lblBankName: 'Bank Name|ชื่อธนาคาร',
                lblCustomsCode: 'Customs Code|รหัสธนาคารกรมศุล',
                linkAdd: 'New|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
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
                lblLimitBalance: 'Minimum Balance|ยอดเงินขั้นต่ำ',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/Branch':
            lang = {
                lblTitle: 'Branch|สาขา',
                lblBranchCode: 'Branch Code|สาขา',
                lblBranchName: 'Branch Name|ชื่อสาขา',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/BudgetPolicy':
            lang = {
                lblTitle: 'Budget Policy|มาตรฐานควบคุมงบประมาณ',
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
                lblUpdateBy: 'Update By|Update By',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Show configuration|แสดงข้อมูล'
            };
            break;
        case 'MODULE_MAS/Index':
            lang = {
                lblTitle: 'System variable|ค่าคงที่ระบบ',
                lblCode: 'Config Group|กลุ่ม',
                lblKey: 'Config Key|ชื่อตัวแปร',
                lblValue: 'Config Value|ค่าของตัวแปร',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/CompanyContact':
            lang = {
                lblTitle: 'Contacts|ผู้ติดต่อ',
                lblCustCode: 'Customer|ลูกค้า',
                lblItemNo: 'Code|รหัส',
                lblDepartment: 'Department|แผนก',
                lblPosition: 'Position|ตำแหน่ง',
                lblContactName: 'ContactName|ชื่อผู้ติดต่อ',
                lblEMail: 'EMail|EMail',
                lblPhone: 'Phone|หมายเลขโทรศัพท์',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ'
            };
            break;
        case 'MODULE_MAS/Country':
            lang = {
                lblTitle: 'Country|ประเทศ',
                lblCTYCODE: 'Country Code|รหัสประเทศ',
                lblCTYName: 'Country Name|ชื่อประเทศ',
                lblCURCODE: 'Currency Code|รหัสเงินตรา',
                lblFTCODE: 'FT CODE|FT CODE',
                lblCUCODE: 'CU CODE|CU CODE',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/Currency':
            lang = {
                lblTitle: 'Currency|สกุลเงิน',
                lblCode: 'Currency Code|รหัสเงินตรา',
                lblTName: 'Currency Name|ชื่อประเทศ',
                lblStartDate: 'Begin Date|วันที่เริ่มต้น',
                lblFinishDate: 'Expire Date|วันที่หมดอายุ',
                lblLastUpdate: 'Last Update|เปลี่ยนแปลงล่าสุด',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/Customers':
            lang = {
                lblTitle: 'Customers|ผู้นำเข้าส่งออก',
                lblCustCode: 'Customer Code|รหัสลูกค้า',
                lblBranch: 'Branch|สาขา',
                lblCustGroup: 'Customer Group|กลุ่มลูกค้า',
                lblTaxNumber: 'Tax-Reference|เลขประจำตัวผู้เสียภาษี',
                lblCustTitle: 'Title|คำนำหน้า',
                lblNameThai: 'Name (TH)|ชื่อ(ไทย)',
                lblNameEng: 'English|ชื่อ(อังกฤษ)',
                lblTAddress1: 'Address (TH)|ที่อยู่ (ไทย)',
                lblEAddress1: 'Address (EN)|ที่อยู่ (EN)',
                lblPhone: 'Phone|หมายเลขโทรศัพท์',
                lblFaxNumber: 'FaxNumber|หมายเลขโทรสาร',
                lblDMailAddress: 'MailAddress|อีเมล์',
                lblWEB_SITE: 'WEB SITE|เว็บไซต์/โซเซียลมีเดีย',
                lblUsedLanguage: 'UsedLanguage|ภาษาที่ใช้',
                lblCustType: 'Customer Type|ประเภท',
                lblLevelGrade: 'Level|ระดับ',
                lblTermOfPayment: 'Payment Term|เงื่อนไขการชำระเงิน',
                lblBillCondition: 'Billing Condition|เงื่อนไขการวางบิล',
                lblCreditLimit: 'Credit Limit|เครดิตชำระเงิน',
                lblDutyLimit: ' Duty Limit|วงเงินสูงสุด',
                lblCommRate: 'Commission Rate|อัตราคอมมิชชั่น',
                lblGLAccountCode: 'GL Code|รหัสลูกหนี้',
                lblBillToCustCode: 'Billing To|รหัสที่วางบิล',
                lblBillToBranch: 'Billing Branch|สาขาที่วางบิล',
                lblBillToCustName: 'Billing Name|ชื่อที่วางบิล',
                lblBillToAddress: 'Billing Address|ที่อยู่ที่วางบิล',
                lblTAddress: 'BLDG No/Street|ที่อยู่',
                lblTDistrict: 'District|อำเภอ',
                lblTSubProvince: 'Sub District|ตำบล',
                lblTProvince: 'Province|จังหวัด',
                lblTPostCode: 'PostCode|รหัสไปรษณีย์',
                lblManagerCode: 'Sales|เซลส์',
                lblCSCodeIM: 'CS Import|CS ขาเข้า',
                lblCSCodeEX: 'CS Export|CS ขาออก',
                lblCSCodeOT: ' CS Others| CS ประสานงาน',
                lblConsStatus: 'Consign Status|สถานะผู้ซื้อขาย',
                lblCommLevel: 'Commercial Level |ระดับธุรกิจ',
                lblLoginName: 'Log in|Log in',
                lblLoginPassword: 'Password|Password',
                linkTab1: 'Billing|ข้อมูลการวางบิล',
                linkTab2: 'Address|ที่อยู่ของบริษัท',
                linkTab3: 'Configuration|กำหนดค่าต่างๆ',
                btnSetBilling: 'Same as Company|วางบิลที่เดียวกัน',
                btnSetAddress: 'Set Full Address|สร้างข้อมูลที่อยู่',
                btnSetContact: 'Set Contact Person|บันทึกผู้ติดต่อ',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/CustomsPort':
            lang = {
                lblTitle: 'Customs Inspection Area|ด่านศุุลกากร',
                lblAreaCode: 'Area Code|รหัสด่าน',
                lblAreaName: 'Area Name|ชื่อด่าน',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/CustomsUnit':
            lang = {
                lblTitle: 'Customs Unit|หน่วยสินค้าศุลกากร',
                lblCode: 'Unit Code|รหัสหน่วย',
                lblTName: 'Unit Name|ชื่อหน่วย',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/DeclareType':
            lang = {
                lblTitle: 'Declare Type|ประเภทใบขน',
                lblType: 'Declare Type|Declare Type',
                lblDescription: 'Description|รายละเอียด',
                lblCategory: 'Category|ประเภท',
                lblStartDate: 'Start Date|วันที่เริ่มต้น',
                lblFinishDate: 'Finish Date|วันที่สิ้นสุด',
                lblLastUpdate: 'Last Update|วันที่ล่าสุด',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/InterPort':
            lang = {
                lblTitle: 'International Port|ท่าเรือต่างประเทศ',
                lblCountryCode: 'Country Code|รหัสประเทศ',
                lblPortCode: 'Port Code|รหัสพอร์ท',
                lblPortName: 'Port Name|ชื่อพอร์ท',
                lblStartDate: 'Start Date|วันที่เริ่มต้น',
                lblFinishDate: 'Finish Date|วันที่สิ้นสุด',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ'
            };
            break;
        case 'MODULE_MAS/Province':
            lang = {
                lblTitle: 'Province|อำเภอ/ตำบล/จังหวัด',
                lblProvinceCode: 'ProvinceCode|รหัสจังหวัด',
                lblProvinceName: 'ProvinceName|ชื่อจังหวัด',
                lblid: 'ID|ID',
                lblDistrict: 'District|ตำบล',
                lblSubProvince: 'SubProvince|อำเภอ',
                lblPostCode: 'PostCode|รหัสไปรษณีย์',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา',
                linkAddD: 'Add Detail|เพิ่มรายการ',
                linkSaveD: 'Save Detail|บันทึกรายการ',
                linkDeleteD: 'Delete Detail|ลบรายการ',
            };
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
                lblVend: 'Pay 50Tavi by Vender|บริษัทไม่ได้เป็นผู้หัก ณ ที่จ่าย',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
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
                lblVend: 'Pay 50Tavi by Vender|บริษัทไม่ได้เป็นผู้หัก ณ ที่จ่าย',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/ServUnit':
            lang = {
                lblTitle: 'Service Units|หน่วยสินค้าและบริการ',
                lblUnitType: 'Unit Type|ประเภท',
                lblUName: 'Name|ชื่อ(ไทย)',
                lblEName: 'English|ชื่อ(อังกฤษ)',
                lblIsCTNUnit: 'Unit Type|ประเภทหน่วย',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/TransportRoute':
            lang = {
                lblTitle: 'Transport Route|เส้นทางการขนส่ง',
                linkTab1: 'Route Lists|เส้นทางการขนส่ง',
                linkTab2: 'Price Lists|ค่าใช้จ่าย',
                lblTemplate: 'Type|ประเภท',
                lblPlace1: 'Pick Up|สถานที่รับสินค้า',
                lblAddress1: 'Address|ที่อยู่',
                lblContact1: 'Contact|ผู้ติดต่อ',
                lblPlace2: 'Delivery|สถานที่ส่งสินค้า',
                lblAddress2: 'Address|ที่อยู่',
                lblContact2: 'Contact|ผู้ติดต่อ',
                lblPlace3: 'Return|สถานที่ปล่อยสินค้า',
                lblAddress3: 'Address|ที่อยู่',
                lblContact3: 'Contact|ผู้ติดต่อ',
                lblPlace4: 'D.Agent|ตัวแทนลูกค้า',
                lblAddress4: 'Address|ที่อยู่',
                lblContact4: 'Contact|ผู้ติดต่อ',
                lblBranchCode: 'Branch|สาขา',
                lblLocation: 'Location|สถานที่',
                lblVender: 'Vender|ผู้ให้บริการ',
                lblCustomer: 'Customer|ลูกค้า',
                lblExpenseCode: 'Expense Code|รหัสค่าใช้จ่าย',
                lblAmount: 'Amount|ยอดค่าใช้จ่าย',
                lblChargeCode: 'Charge Code|รหัสค่าบริการ',
                lblCAmount: 'Amount|ยอดค่าบริการ',
                btnSelRoute: 'Search|ค้นหา',
                btnNewRoute: 'New|เพิ่ม',
                btnSaveRoute: 'Save|บันทึก',
                btnSaveP1: 'Save|จัดเก็บข้อมูล',
                btnClearP1: 'Clear|ล้างข้อมูล',
                btnDelP1: 'Delete|ลบข้อมูล',
                btnSaveP2: 'Save|จัดเก็บข้อมูล',
                btnClearP2: 'Clear|ล้างข้อมูล',
                btnDelP2: 'Delete|ลบข้อมูล',
                btnSaveP3: 'Save|จัดเก็บข้อมูล',
                btnClearP3: 'Clear|ล้างข้อมูล',
                btnDelP3: 'Delete|ลบข้อมูล',
                btnSaveP4: 'Save|จัดเก็บข้อมูล',
                btnClearP4: 'Clear|ล้างข้อมูล',
                btnDelP4: 'Delete|ลบข้อมูล',
                btnNewPrice: 'New Price|เพิ่มราคา',
                btnSavePrice: 'Save Price|จัดเก็บราคา',
                btnDelPrice: 'Delete Price|ลบราคา'
            };
            break;
        case 'MODULE_MAS/Users':
            lang = {
                lblTitle: 'Users|พนักงาน',
                lblUser: 'User ID|รหัสพนักงาน',
                lblUPassword: 'Password|รหัสผ่าน',
                lblDeptID: 'Department|รหัสแผนก',
                lblTName: 'Name|ชื่อ(ไทย)',
                lblEName: 'Englisth|ชื่อ(อังกฤษ)',
                lblTPosition: 'Position|ตำแหน่ง',
                lblUPosition: 'Level|ระดับ',
                lblUserUpline: 'Supervisor| หัวหน้างาน',
                lblEMail: 'EMail|EMail',
                lblMobilePhone: 'MobilePhone|หมายเลขโทรศัพท์',
                lblUsedLanguage: 'UsedLanguage|ภาษาที่ใช้',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
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
                lblPrint: 'Allow Print|พิมพ์ข้อมูลได้',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ'
            };
            break;
        case 'MODULE_MAS/Venders':
            lang = {
                lblTitle: 'Venders|ผู่้ให้บริการ',
                lblVenCode: 'Vender Code|รหัสเวนเดอร์',
                lblBranchCode: 'Branch|สาขา',
                lblTaxNumber: 'Tax Number|เลขประจำตัวผู้เสียภาษี',
                lblVenTitle: 'Title|คำนำหน้า',
                lblTName: 'Name|ชื่อ(ไทย)',
                lblEnglish: 'English|ชื่อ(อังกฤษ)',
                lblTAddress1: 'Address (TH)|ที่อยู่ (ไทย)',
                lblEAddress1: 'Address (EN)|ที่อยู่ (อังกฤษ)',
                lblPhone: 'Phone|โทรศัพท์',
                lblFaxNumber: 'Fax|แฟกซ์',
                lblWEB_SITE: 'Web/E-mail|Web/E-mail',
                lblGLAccountCode: 'GL Code|GL Code',
                lblContact: 'Contact Information|ข้อมูลผู้ติดต่อ',
                lblContactAcc: 'Account|บัญชี',
                lblContactSale: 'Sales|การตลาด',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'MODULE_MAS/Vessel':
            lang = {
                lblTitle: 'Vessel|พาหนะ',
                lblRegsNumber: 'Register Code|รหัส',
                lblTName: 'Name|ชื่อ',
                lblVesselType: 'Type|ประเภท',
                linkAdd: 'Add|เพิ่ม',
                linkSave: 'Save|บันทึก',
                linkDelete: 'Delete|ลบ',
                linkSearch: 'Search|ค้นหา'
            };
            break;
        case 'Menu/Index':
        case 'Tracking/Dashboard':
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
                lblGrid3: 'Status By Customer|จำนวนงานตามลูกค้า',
                lblGrid4: 'Status By Staff|จำนวนงานตามพนักงาน'
            };
            break;
        case 'MODULE_SALES/QuoApprove':
            lang = {
                lblTitle: 'Quotation Confirmation|อนุมัติใบเสนอราคา',
                lblBranch: 'Branch|สาขา',
                lblDateFrom: 'Date From|จากวันที่',
                lblDateTo: 'Date To|ถึงวันที่',
                lblReqBy: 'Sales By|เสนอราคาโดย',
                lblCustCode: 'Customer|ลูกค้า',
                linkSearch: 'Search|ค้นหา',
                lblListAppr: 'Approve Document|เอกสารที่เลือก',
                linkAppr: 'Confirm|อนุมัติเอกสาร'
            };
            break;
        case 'MODULE_SALES/Quotation':
            lang = {
                lblTitle: 'Quotation|ใบเสนอราคา',
                lblSearch: 'Search|ค้นหา',
                lblBranch: 'Branch|สาขา',
                lblCustomer: 'Customer|ลูกค้า',
                lblDCust: 'Customer|ลูกค้า',
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
                lblNewSectionD: 'New Section|เพิ่มหัวข้อ',
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
                lblDiscountRate: 'Discount Rate|อัตราส่วนลด (%)',
                lblVender: 'Vender|ผู้ให้บริการ',
                lblCostAmt: 'Cost Amount(Net)|ราคาทุนสุทธิ',
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
                linkDetail: 'Detail|ส่วนรายการ',
                btnCancel: 'Cancel|ยกเลิก',
                btnApprove: 'Confirm|อนุมัติ'
            };
            break;
        case 'Tracking/Document':
            lang = {
                lblTitle: 'Documents Tracking|การติดตามเอกสาร',
                lblBranch: 'Branch|สาขา',
                lblDocType: 'Doc Type|ประเภทเอกสาร',
                lblJob: 'Job No|หมายเลขงาน',
                btnShow: 'Show|แสดง',
                btnAddFile: 'Add File|เพิ่มไฟล์',
                lblDelFile: 'Delete File|ลบไฟล์',
                lblItemNo: 'No|ลำดับที่',
                lblDocTypeD: 'Doc Type|ประเภทเอกสาร',
                lblDocDate: 'Doc Date|วันที่เอกสาร',
                lblDocNo: 'Doc No|เลขที่เอกสาร',
                lblDescription: 'Description|คำอธิบาย',
                lblFileType: 'File Type|นามสกุล',
                lblFilePath: 'File Path|ที่อยู่ไฟล์',
                lblFileSize: 'File Size|ขนาดไฟล์',
                lblCheckBy: 'Check By|ผู้ตรวจสอบ',
                lblCheckDate: 'Check Date|วันที่ตรวจสอบ',
                lblCheckNote: 'Check Comment|บันทึกการตรวจสอบ',
                lblApproveBy: 'Approve By|ผู้อนุมัติ',
                lblApproveDate: 'Approve Date|วันที่อนุมัติ',
                lblUploadBy: 'Upload By|ผู้อัพโหลด',
                lblUploadDate: 'Upload Date|วันที่อัพโหลด',
                lblSaveData: 'Save Information|บันทึกข้อมูล'
            };
            break;
        case 'Tracking/Planing':
            lang = {
                lblTitle: 'Planing|ข้อมูลการตรวจปล่อย',
                lblStatus: 'Status|สถานะงาน',
                lblFilter: 'Filter|กรองข้อมูล',
                lblAgent: 'Agent|สายเรือ/สายการบิน',
                lblTransport: 'Transport|บริษัทขนส่ง',
                lblCustCode: 'Cust Code|รหัสผู้นำเข้าส่งออก',
                lblConsCode: 'BillTo/Consignee Code|รหัสผู้ซื้อขาย',
                lblJobType: 'Job Type|ประเภทงาน',
                lblShipBy: 'Ship By|ลักษณะงานขนส่ง',
                lblFromDate: 'From Date|จากวันที่',
                lblToDate: 'To Date|ถึงวันที่',
                lblDateBy: 'Date By|เลือกจากวันที่',
                lblBranchCode: 'Branch|สาขา'
            };
            break;
        case 'Master/CarLicense':
            lang = {
                lblTitle:'Car License|ข้อมูลรถ',
                lblCarNo: 'Car Code|รหัสรถ',
                lblCarLicense: 'Car License|ทะเบียนรถ',
                lblEmpCode: 'Driver|พนักงานขับรถ',
                lblDateStart: 'Begin Date|วันที่เริ่มใช้งาน',
                lblCarBrand: 'Car Brand|ยี่ห้อรถ',
                lblModelyear: 'Model Year|ปีที่ผลิต',
                lblCarModel: 'Model|รุ่น',
                lblCarType: 'Car Type|ประเภทรถ',
                lblCarRefNo: 'Ref#|เลขหางรถ/chassis',
                lblCarRefType: 'Ref Type|ประเภทหางรถ',
                lblCarPic: 'Picture|รูปภาพ',
                lblStatus: 'Status|สถานะรถ',
                lblWeight: 'Weight|น้ำหนักรถ'
            };
            break;
        case 'Master/Employee':
            lang = {
                lblTitle: 'Employee|ข้อมูลพนักงาน',
                lblEmpCode: 'Code|รหัสพนักงาน',
                lblPreName: 'Title|คำนำหน้าชื่อ',
                lblName: 'Name|ชื่อ',
                lblNickName: 'Nickname|ชื่อเล่น',
                lblAccountNumber: 'Bank Account|บัญชีธนาคาร',
                lblBranch: 'Branch|สาขา',
                lblAddress: 'Address|ที่อยู่',
                lblTel: 'Tel No.|เบอร์โทรศัพท์',
                lblRemark: 'Remark|หมายเหตุ',
                lblEmail: 'Email|อีเมล'
            };
            break;
        case 'JobOrder/AddFuel':
            lang = {
                lblTitle: 'Fuel Refill|ใบสั่งเติมน้ำมัน/เชื้่อเพลิง',
                lblBranchCode: 'Branch Code|สาขา',
                lblBookingNo: 'Booking No|เลขบุคกิ้ง',
                lblJNo: 'Job No|หมายเลขงาน',
                lblDocNo: 'Doc No|เลขที่เอกสาร',
                lblDocDate: 'Doc Date|วันที่เอกสาร',
                lblCarLicense: 'Car License|ทะเบียนรถหัวลาก',
                lblDriver: 'Driver|พนักงานขับรถ',
                lblFuelType: 'Fuel Type|ประเภทเชื้อเพลิง',
                lblStationCode: 'Station Code|สถานีบริการ',
                lblPaymentType: 'Payment Type|ประเภทการชำระเงิน',
                lblStationInvNo: 'Station InvNo|เลขที่ใบวางบิลปั้ม',
                lblMileBegin: 'Mile Begin|เลขไมล์เริ่มต้น',
                lblMileEnd: 'Mile End|เลขไมล์สิ้นสุด',
                lblMileTotal: 'Mile Total|รวมระยะทางไมล์',
                lblBudgetVolume: 'Budget Volume (LTR)|สั่งเติม (ลิตร)',
                lblBudgetValue: 'Budget Value (THB)|สั่งเติม (บาท)',
                lblActualVolume: 'Actual Volume (LTR)|เติมจริง (ลิตร)',
                lblUnitPrice: 'Unit Price|ลิตรละ (บาท)',
                lblTotalAmount: 'Total Amount|รวมเป็นเงิน',
                lblRemark: 'Remark|หมายเหตุ',
                lblTotalWeight: 'Total Weight|น้ำหนักรวม',
                lblCreateBy: 'Create By|สร้างเอกสารโดย',
                lblCreateDate: 'Create Date|วันที่สร้าง',
                lblUpdateBy: 'Update By|ผู้แก้ไขข้อมูล',
                lblLastUpdate: 'Last Update|วันที่แก้ไขล่าสุด',
                lblApproveBy: 'Approve By|ผู้อนุมัติ',
                lblApproveDate: 'Approve Date|วันที่อนุมัติ',
                lblCancelBy: 'Cancel By|ผู้ยกเลิก',
                lblCancelDate: 'Cancel Date|วันที่ยกเลิก',
                lblCancelReason: 'Cancel Reason|เหตุผลที่ยกเลิก',
                lblTrailerNo: 'Trailer No|เลขทะเบียนรถพ่วง',
                lblStationInvDate: 'Station Inv Date|วันที่ใบวางบิลปั้ม',
                lblPaymentBy: 'Payment By|ชำระเงินโดย',
                lblPaymentDate: 'Payment Date|วันที่ชำระเงิน',
                lblPaymentRef:'Payment Ref|เลขที่ชำระเงิน'
            };
            break;
    }
    return lang;
}
function GetReportGroups() {
    return [
        { "ConfigKey": "ACC", "ConfigValue": "Accounting Reports / รายงานแผนกบัญชี" },
        { "ConfigKey": "ADV", "ConfigValue": "Advancing Reports / รายงานการเบิกเงิน" },
        { "ConfigKey": "CLR", "ConfigValue": "Clearing Reports / รายงานการปิดบัญชี" },
        { "ConfigKey": "JOB", "ConfigValue": "Operation Reports / รายงานการปฏิบัติงาน" },
        { "ConfigKey": "INV", "ConfigValue": "Invoicing Reports / รายงานใบแจ้งหนี้" },
        { "ConfigKey": "RCV", "ConfigValue": "Receiving Reports / รายงานใบเสร็จ/ใบกำกับภาษี" },
        { "ConfigKey": "FIN", "ConfigValue": "Financial Reports / รายงานแผนกการเงิน" },
        { "ConfigKey": "MKT", "ConfigValue": "Marketing Reports / รายงานแผนกการตลาด" },
        { "ConfigKey": "MAS", "ConfigValue": "Master Files Reports / รายงานข้อมูลมาตรฐาน" },
        { "ConfigKey": "EXE", "ConfigValue": "Executives Reports / รายงานสำหรับผู้บริหาร" }
    ];
}
function GetReportLists() {
    return [
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBDAILY", "ReportNameEN": "Job List Daily", "ReportNameTH": "รายงานการตรวจปล่อยตามวันที่" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBCS", "ReportNameEN": "Job List By CS", "ReportNameTH": "รายงานการตรวจปล่อยตามพนักงานบริการลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBSHP", "ReportNameEN": "Job List By Shipping", "ReportNameTH": "รายงานการตรวจปล่อยตามชิปปิ้ง" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBTYPE", "ReportNameEN": "Job List By Type", "ReportNameTH": "รายงานการตรวจปล่อยตามประเภทงาน" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBSHIPBY", "ReportNameEN": "Job List By Transport", "ReportNameTH": "รายงานการตรวจปล่อยตามลักษณะงานขนส่ง" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBCUST", "ReportNameEN": "Job List By Customer", "ReportNameTH": "รายงานการตรวจปล่อยตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBPORT", "ReportNameEN": "Job List By Port", "ReportNameTH": "รายงานการตรวจปล่อยตามสถานที่ตรวจปล่อย" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBTRANSPORT", "ReportNameEN": "Job Transport Lists", "ReportNameTH": "รายงานงานขนส่งรายตู้ตามบริษัทขนส่ง" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBANALYSIS", "ReportNameEN": "Job Analysis", "ReportNameTH": "รายงานประเมินผลการปฏิบัติงาน" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBFOLLOWUP", "ReportNameEN": "Job List By Status", "ReportNameTH": "รายงานงานเรียงตามสถานะ" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "PLANLOAD", "ReportNameEN": "Container Loading By Load Date", "ReportNameTH": "รายงานงานขนส่งตามวันโหลด" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBLOADING", "ReportNameEN": "Job Loading By ETA Date", "ReportNameTH": "รายงานงานขนส่งตามวันเทียบท่า" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "PLANLOADIM", "ReportNameEN": "Container Loading Import Daily", "ReportNameTH": "รายงานการลากตู้ขนส่งขาเข้า" },
        { "ReportType": "STD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "PLANLOADEX", "ReportNameEN": "Container Loading Export Daily", "ReportNameTH": "รายงานลากตู้ขนส่งขาออก" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBADV", "ReportNameEN": "Advance By Emp", "ReportNameTH": "รายงานการเบิกเงินตามพนักงาน" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVSUMMARY", "ReportNameEN": "Advance Summary", "ReportNameTH": "รายงานสรุปใบเบิกค่าใช้จ่าย" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVDAILY", "ReportNameEN": "Advance Payment", "ReportNameTH": "รายงานการจ่ายเงินเบิกล่วงหน้า" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVDETAIL", "ReportNameEN": "Advance Expenses Report", "ReportNameTH": "รายงานการเบิกค่าใช้จ่ายแต่ละประเภท" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CREDITADV", "ReportNameEN": "Credit Advance Summary", "ReportNameTH": "รายงานสรุปใบทดรองจ่าย" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "EXPDAILY", "ReportNameEN": "Bill-Expense Report", "ReportNameTH": "รายงานบิลค่าใช้จ่าย" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "EXPDETAIL", "ReportNameEN": "Bill-Expense Detail Report", "ReportNameTH": "รายงานบิลค่าใช้จ่ายแต่ละประเภท" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVCLEARING", "ReportNameEN": "Advance Clearing Detail Report", "ReportNameTH": "รายงานการติดตามใบเบิก" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVIMPORT", "ReportNameEN": "Advance Import Detail Report", "ReportNameTH": "รายงานรายละเอียดใบเบิกขาเข้า" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVEXPORT", "ReportNameEN": "Advance Export Detail Report", "ReportNameTH": "รายงานรายละเอียดใบเบิกขาออก" },
        { "ReportType": "STD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVEXPENSE", "ReportNameEN": "Advance Total Expense Report", "ReportNameTH": "รายงานสรุปการเบิกแต่ละประเภท" },
        { "ReportType": "STD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CLRDAILY", "ReportNameEN": "Clearing Daily", "ReportNameTH": "รายงานการปิดค่าใช้จ่ายประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "EARNEST", "ReportNameEN": "Earnest Summary", "ReportNameTH": "รายงานเงินมัดจำ" },
        { "ReportType": "STD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CLRDETAIL", "ReportNameEN": "Clearing Expenses Report", "ReportNameTH": "รายงานการปิดค่าใช้จ่ายตามประเภท" },
        { "ReportType": "STD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CLRSUMMARY", "ReportNameEN": "Clearing Summary Status", "ReportNameTH": "รายงานสรุปสถานะการปิดค่าใช้จ่าย" },
        { "ReportType": "STD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "WHTAXCLR", "ReportNameEN": "Withholding-Tax Clearing Report", "ReportNameTH": "รายงานหัก ณ ที่จ่ายจากการปิดค่าใช้จ่าย" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RCPDAILY", "ReportNameEN": "Receipt Daily", "ReportNameTH": "รายงานใบเสร็จรับเงินประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RCPDETAIL", "ReportNameEN": "Receipt Expense Detail", "ReportNameTH": "รายงานใบเสร็จรับเงินตามประเภท" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RCPSUMMARY", "ReportNameEN": "Receipt Summary", "ReportNameTH": "รายงานสรุปใบเสร็จรับเงิน" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "TAXDAILY", "ReportNameEN": "Tax-invoice Daily", "ReportNameTH": "รายงานใบกำกับภาษีประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "TAXSUMMARY", "ReportNameEN": "Tax-invoice Summary", "ReportNameTH": "รายงานสรุปใบกำกับภาษี" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "OUTPUTTAX", "ReportNameEN": "Output TAX Report", "ReportNameTH": "รายงานภาษีมูลค่าเพิ่มตามใบกำกับภาษี" },
        { "ReportType": "STD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "OUTPUTWHT", "ReportNameEN": "Withholding TAX Report", "ReportNameTH": "รายงานหักภาษี ณ ที่จ่ายตามใบกำกับภาษี" },
        { "ReportType": "STD", "ReportGroup": "MKT", "ReportAuthor": "1,2,3,6,99", "ReportCode": "JOBSTATUS", "ReportNameEN": "Job Volume By Status", "ReportNameTH": "รายงานสรุปงานตามสถานะ" },
        { "ReportType": "STD", "ReportGroup": "MKT", "ReportAuthor": "1,2,3,6,99", "ReportCode": "JOBSALES", "ReportNameEN": "Job Sales By Emp", "ReportNameTH": "รายงานสรุปยอดขายตามพนักงาน" },
        { "ReportType": "STD", "ReportGroup": "MKT", "ReportAuthor": "1,2,3,6,99", "ReportCode": "JOBCOMM", "ReportNameEN": "Job Commission By Emp", "ReportNameTH": "รายงานสรุปค่าคอมมิชชั่น" },
        { "ReportType": "STD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVDAILY", "ReportNameEN": "Invoice Daily", "ReportNameTH": "รายงานใบแจ้งหนี้ประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVDETAIL", "ReportNameEN": "Invoice Expenses Detail", "ReportNameTH": "รายงานใบแจ้งหนี้ตามประเภท" },
        { "ReportType": "STD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVSTATUS", "ReportNameEN": "Invoice Status", "ReportNameTH": "รายงานสถานะใบแจ้งหนี้" },
        { "ReportType": "STD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVSUMMARY", "ReportNameEN": "Invoice Costing Summary", "ReportNameTH": "รายงานสรุปต้นทุนตามใบแจ้งหนี้" },
        { "ReportType": "STD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "BILLDAILY", "ReportNameEN": "Billing Daily", "ReportNameTH": "รายงานใบวางบิลประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "STATEMENT", "ReportNameEN": "Bank Statement", "ReportNameTH": "รายงานการรับจ่ายเงินตามสมุดบัญชี" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CASHBAL", "ReportNameEN": "Financial Balance", "ReportNameTH": "รายงานสรุปการรับจ่ายเงิน" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "BOOKBAL", "ReportNameEN": "Book Accounts Balance", "ReportNameTH": "รายงานการใช้จ่ายเงินตามสมุดบัญชี" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "DAILYCASH", "ReportNameEN": "Daily Cash", "ReportNameTH": "รายงานการรับเงิน" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CHQRECEIVE", "ReportNameEN": "Cheque Customer Receive", "ReportNameTH": "รายงานการรับเช็คประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CHQISSUE", "ReportNameEN": "Cashier Cheque Issue", "ReportNameTH": "รายงานการจ่ายเช็คประจำวัน" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CHQCUSTPAY", "ReportNameEN": "Cheque Customer Payment", "ReportNameTH": "รายงานการจ่ายเช็คของลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "WHTDAILY", "ReportNameEN": "Withholding-Tax Issue Report", "ReportNameTH": "รายงานการออกหนังสือหัก ณ ที่จ่าย" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "WHTAXSUM", "ReportNameEN": "Withholding-Tax Summary Report", "ReportNameTH": "รายงานสรุปการออกหนังสือหัก ณ ที่จ่าย" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD3", "ReportNameEN": "PRD-3 Cover Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบปะหน้า)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD53", "ReportNameEN": "PRD-53 Cover Report", "ReportNameTH": "รายงานนำส่ง หัก ณ ที่จ่าย ภ.ง.ด.53 (ใบปะหน้า)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD3D", "ReportNameEN": "PRD-3 Detail Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบแนบ)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD53D", "ReportNameEN": "PRD-53 Detail Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.53 (ใบแนบ)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CASHFLOW", "ReportNameEN": "Cash Flow", "ReportNameTH": "รายงานงบกระแสเงินสด" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBCOST", "ReportNameEN": "Job Costing Summary", "ReportNameTH": "รายงานสรุปต้นทุนตามจ๊อบ" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBPROFIT", "ReportNameEN": "Job Costing And Profit", "ReportNameTH": "รายงานกำไรขั้นต้นตามจ๊อบ" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "VATSALES", "ReportNameEN": "Sales VAT Report", "ReportNameTH": "รายงานภาษีขาย" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "VATBUY", "ReportNameEN": "Purchase VAT Report", "ReportNameTH": "รายงานภาษีซื้อ" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ACCEXP", "ReportNameEN": "Account Payable Report", "ReportNameTH": "รายงานค่าใช้จ่าย" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ACCINC", "ReportNameEN": "Account Receiable Report", "ReportNameTH": "รายงานรายได้" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ARBAL", "ReportNameEN": "Accrue Income Report", "ReportNameTH": "รายงานลูกหนี้คงเหลือ" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "APBAL", "ReportNameEN": "Accrue Expense Report", "ReportNameTH": "รายงานเจ้าหนี้คงค้าง" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "APBILL", "ReportNameEN": "Billing Expense Report", "ReportNameTH": "รายงานบิลค่าใช้จ่าย" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CNDN", "ReportNameEN": "Credit/Debit Note Report", "ReportNameTH": "รายงานการปรับปรุงหนี้" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PVDAILY", "ReportNameEN": "Payment Voucher Report", "ReportNameTH": "รายงานใบสำคัญจ่ายรายวัน" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RVDAILY", "ReportNameEN": "Receive Voucher Report", "ReportNameTH": "รายงานใบสำคัญรับรายวัน" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "GROSSPROFIT", "ReportNameEN": "Gross Profit Report", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามประเภทงาน" },
        { "ReportType": "STD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CUSTPROFIT", "ReportNameEN": "Customer Profit Report", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ADVTOTAL", "ReportNameEN": "Details of Advance Payment By Job Order", "ReportNameTH": "รายงานการเบิกค่าใช้จ่ายแยกตามประเภท" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "BUYRATE", "ReportNameEN": "Buy Rates By Broker", "ReportNameTH": "รายงานการเปรียบเทียบราคาต้นทุนแต่ละผู้ให้บริการ" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CUSTSUMMARY", "ReportNameEN": "PNL By Customer", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBSUMMARY", "ReportNameEN": "PNL By Job Order", "ReportNameTH": "รายงานสรุปกำไรขาดทุนตามจ๊อบ" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBDETAIL", "ReportNameEN": "Details of PNL By Job Order", "ReportNameTH": "รายงานรายละเอียดกำไรขั้นต้นตามจ๊อบ" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT01", "ReportNameEN": "Outstanding Job Order By Customer", "ReportNameTH": "รายงานสรุปงานคงค้างตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT02", "ReportNameEN": "Outstanding Job Order By Customer Service", "ReportNameTH": "รายงานสรุปงานคงค้างตามพนักงานบริการลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT03", "ReportNameEN": "Job Order Status", "ReportNameTH": "รายงานประเมินผลสถานะการปฏิบัติงาน" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT04", "ReportNameEN": "Outstanding Job By Customer/Waiting for Billing", "ReportNameTH": "รายงานติดตามผลการดำเนินงาน" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT05", "ReportNameEN": "Outstanding Advance By Job", "ReportNameTH": "รายงานติดตามการเบิกค่าใช้จ่ายตามจ๊อบ" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT06", "ReportNameEN": "Advance By Activity Summary By Customer", "ReportNameTH": "รายงานติดตามการเบิกค่าใช้จ่ายตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT07", "ReportNameEN": "Outstanding Advance By Activity Based-Deposit", "ReportNameTH": "รายงานติดตามเงินมัดจำ" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT08", "ReportNameEN": "Billing Report By Customer", "ReportNameTH": "รายงานติดตามการออกใบแจ้งหนี้ตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT09", "ReportNameEN": "Payment By Vender by Job Order", "ReportNameTH": "รายงานค่าใช้จ่ายเจ้าหนี้ตามจ๊อบงาน" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT10", "ReportNameEN": "A/P Accural Report", "ReportNameTH": "รายงานค่าใช้จ่ายรอการจ่าย" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT11", "ReportNameEN": "A/R Accural Report", "ReportNameTH": "รายงานรายได้รอการวางบิล" }
    ];
}
function GetReportLists_V2() {
    return [
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBDAILY", "ReportNameEN": "Job List Daily", "ReportNameTH": "รายงานการตรวจปล่อยตามวันที่" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBCS", "ReportNameEN": "Job List By CS", "ReportNameTH": "รายงานการตรวจปล่อยตามพนักงานบริการลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBSHP", "ReportNameEN": "Job List By Shipping", "ReportNameTH": "รายงานการตรวจปล่อยตามชิปปิ้ง" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBTYPE", "ReportNameEN": "Job List By Type", "ReportNameTH": "รายงานการตรวจปล่อยตามประเภทงาน" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBSHIPBY", "ReportNameEN": "Job List By Transport", "ReportNameTH": "รายงานการตรวจปล่อยตามลักษณะงานขนส่ง" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBCUST", "ReportNameEN": "Job List By Customer", "ReportNameTH": "รายงานการตรวจปล่อยตามลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBPORT", "ReportNameEN": "Job List By Port", "ReportNameTH": "รายงานการตรวจปล่อยตามสถานที่ตรวจปล่อย" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBTRANSPORT", "ReportNameEN": "Job Transport Lists", "ReportNameTH": "รายงานงานขนส่งรายตู้ตามบริษัทขนส่ง" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBANALYSIS", "ReportNameEN": "Job Analysis", "ReportNameTH": "รายงานประเมินผลการปฏิบัติงาน" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBFOLLOWUP", "ReportNameEN": "Job List By Status", "ReportNameTH": "รายงานงานเรียงตามสถานะ" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "PLANLOAD", "ReportNameEN": "Container Loading By Load Date", "ReportNameTH": "รายงานงานขนส่งตามวันโหลด" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBLOADING", "ReportNameEN": "Job Loading By ETA Date", "ReportNameTH": "รายงานงานขนส่งตามวันเทียบท่า" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "PLANLOADIM", "ReportNameEN": "Container Loading Import Daily", "ReportNameTH": "รายงานการลากตู้ขนส่งขาเข้า" },
        { "ReportType": "ADD", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "PLANLOADEX", "ReportNameEN": "Container Loading Export Daily", "ReportNameTH": "รายงานลากตู้ขนส่งขาออก" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "TRUCKPNL", "ReportNameEN": "Truck Summary Profit Report By Container", "ReportNameTH": "รายงานกำไรขาดทุนแต่ละตู้" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "TRUCKSUM-A", "ReportNameEN": "Truck Summary Report By Container - Actual Delivery", "ReportNameTH": "รายงานกำไรขาดทุนแต่ละตู้ตามเป้าหมาย" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "TRUCKSUM-T", "ReportNameEN": "Truck Summary Report By Container - Target Delivery", "ReportNameTH": "รายงานกำไรขาดทุนแต่ละตู้ตามสถานะจริง" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "TRUCKKPI", "ReportNameEN": "Truck KPI Report", "ReportNameTH": "รายงานสรุปการปฏิบัติงานตามตู้คอนเทนเนอร์" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBKPI", "ReportNameEN": "Job Operation On-Time Report", "ReportNameTH": "รายงานสรุปเวลาปฏิบัติงานตามจ๊อบ" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "APLIMPORT", "ReportNameEN": "Job Import Summary", "ReportNameTH": "รายงานสรุปการทำงานขาเข้า" },
        { "ReportType": "EXP", "ReportGroup": "JOB", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "APLEXPORT", "ReportNameEN": "Job Export Summary", "ReportNameTH": "รายงานสรุปการทำงานขาออก" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "JOBADV", "ReportNameEN": "Advance By Emp", "ReportNameTH": "รายงานการเบิกเงินตามพนักงาน" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVSUMMARY", "ReportNameEN": "Advance Summary", "ReportNameTH": "รายงานสรุปใบเบิกค่าใช้จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVDAILY", "ReportNameEN": "Advance Payment", "ReportNameTH": "รายงานการจ่ายเงินเบิกล่วงหน้า" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVDETAIL", "ReportNameEN": "Advance Expenses Report", "ReportNameTH": "รายงานการเบิกค่าใช้จ่ายแต่ละประเภท" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CREDITADV", "ReportNameEN": "Credit Advance Summary", "ReportNameTH": "รายงานสรุปใบทดรองจ่าย" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "EXPDAILY", "ReportNameEN": "Bill-Expense Report", "ReportNameTH": "รายงานบิลค่าใช้จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "EXPDETAIL", "ReportNameEN": "Bill-Expense Detail Report", "ReportNameTH": "รายงานบิลค่าใช้จ่ายแต่ละประเภท" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVCLEARING", "ReportNameEN": "Advance Clearing Detail Report", "ReportNameTH": "รายงานการติดตามใบเบิก" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVIMPORT", "ReportNameEN": "Advance Import Detail Report", "ReportNameTH": "รายงานรายละเอียดใบเบิกขาเข้า" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVEXPORT", "ReportNameEN": "Advance Export Detail Report", "ReportNameTH": "รายงานรายละเอียดใบเบิกขาออก" },
        { "ReportType": "ADD", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVOTHER", "ReportNameEN": "Advance Local Detail Report", "ReportNameTH": "รายงานรายละเอียดใบเบิกอื่นๆ" },
        { "ReportType": "FIX", "ReportGroup": "ADV", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "ADVEXPENSE", "ReportNameEN": "Advance Total Expense Report", "ReportNameTH": "รายงานสรุปการเบิกแต่ละประเภท" },
        { "ReportType": "ADD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CLRDAILY", "ReportNameEN": "Clearing Daily", "ReportNameTH": "รายงานการปิดค่าใช้จ่ายประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "EARNEST", "ReportNameEN": "Earnest Summary", "ReportNameTH": "รายงานเงินมัดจำ" },
        { "ReportType": "ADD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CLRDETAIL", "ReportNameEN": "Clearing Expenses Report", "ReportNameTH": "รายงานการปิดค่าใช้จ่ายตามประเภท" },
        { "ReportType": "ADD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "CLRSUMMARY", "ReportNameEN": "Clearing Summary Status", "ReportNameTH": "รายงานสรุปสถานะการปิดค่าใช้จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "CLR", "ReportAuthor": "1,2,3,4,5,6,98,99", "ReportCode": "WHTAXCLR", "ReportNameEN": "Withholding-Tax Clearing Report", "ReportNameTH": "รายงานหัก ณ ที่จ่ายจากการปิดค่าใช้จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RCPDAILY", "ReportNameEN": "Receipt Daily", "ReportNameTH": "รายงานใบเสร็จรับเงินประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RCPDETAIL", "ReportNameEN": "Receipt Expense Detail", "ReportNameTH": "รายงานใบเสร็จรับเงินตามประเภท" },
        { "ReportType": "ADD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RCPSUMMARY", "ReportNameEN": "Receipt Summary", "ReportNameTH": "รายงานสรุปใบเสร็จรับเงิน" },
        { "ReportType": "ADD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "TAXDAILY", "ReportNameEN": "Tax-invoice Daily", "ReportNameTH": "รายงานใบกำกับภาษีประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "TAXSUMMARY", "ReportNameEN": "Tax-invoice Summary", "ReportNameTH": "รายงานสรุปใบกำกับภาษี" },
        { "ReportType": "APL", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "OUTPUTTAX", "ReportNameEN": "Output TAX Report", "ReportNameTH": "รายงานภาษีมูลค่าเพิ่มตามใบกำกับภาษี" },
        { "ReportType": "APL", "ReportGroup": "RCV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "OUTPUTWHT", "ReportNameEN": "Withholding TAX Report", "ReportNameTH": "รายงานหักภาษี ณ ที่จ่ายตามใบกำกับภาษี" },
        { "ReportType": "ADD", "ReportGroup": "MKT", "ReportAuthor": "1,2,3,6,99", "ReportCode": "JOBSTATUS", "ReportNameEN": "Job Volume By Status", "ReportNameTH": "รายงานสรุปงานตามสถานะ" },
        { "ReportType": "ADD", "ReportGroup": "MKT", "ReportAuthor": "1,2,3,6,99", "ReportCode": "JOBSALES", "ReportNameEN": "Job Sales By Emp", "ReportNameTH": "รายงานสรุปยอดขายตามพนักงาน" },
        { "ReportType": "ADD", "ReportGroup": "MKT", "ReportAuthor": "1,2,3,6,99", "ReportCode": "JOBCOMM", "ReportNameEN": "Job Commission By Emp", "ReportNameTH": "รายงานสรุปค่าคอมมิชชั่น" },
        { "ReportType": "ADD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVDAILY", "ReportNameEN": "Invoice Daily", "ReportNameTH": "รายงานใบแจ้งหนี้ประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVDETAIL", "ReportNameEN": "Invoice Expenses Detail", "ReportNameTH": "รายงานใบแจ้งหนี้ตามประเภท" },
        { "ReportType": "ADD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVSTATUS", "ReportNameEN": "Invoice Status", "ReportNameTH": "รายงานสถานะใบแจ้งหนี้" },
        { "ReportType": "ADD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "INVSUMMARY", "ReportNameEN": "Invoice Costing Summary", "ReportNameTH": "รายงานสรุปต้นทุนตามใบแจ้งหนี้" },
        { "ReportType": "ADD", "ReportGroup": "INV", "ReportAuthor": "1,2,6,98,99", "ReportCode": "BILLDAILY", "ReportNameEN": "Billing Daily", "ReportNameTH": "รายงานใบวางบิลประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "STATEMENT", "ReportNameEN": "Bank Statement", "ReportNameTH": "รายงานการรับจ่ายเงินตามสมุดบัญชี" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CASHBAL", "ReportNameEN": "Financial Balance", "ReportNameTH": "รายงานสรุปการรับจ่ายเงิน" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "BOOKBAL", "ReportNameEN": "Book Accounts Balance", "ReportNameTH": "รายงานการใช้จ่ายเงินตามสมุดบัญชี" },
        { "ReportType": "APL", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "DAILYCASH", "ReportNameEN": "Daily Cash", "ReportNameTH": "รายงานการรับเงิน" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CHQRECEIVE", "ReportNameEN": "Cheque Customer Receive", "ReportNameTH": "รายงานการรับเช็คประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CHQISSUE", "ReportNameEN": "Cashier Cheque Issue", "ReportNameTH": "รายงานการจ่ายเช็คประจำวัน" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CHQCUSTPAY", "ReportNameEN": "Cheque Customer Payment", "ReportNameTH": "รายงานการจ่ายเช็คของลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "WHTDAILY", "ReportNameEN": "Withholding-Tax Issue Report", "ReportNameTH": "รายงานการออกหนังสือหัก ณ ที่จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "WHTAXSUM", "ReportNameEN": "Withholding-Tax Summary Report", "ReportNameTH": "รายงานสรุปการออกหนังสือหัก ณ ที่จ่าย" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD3", "ReportNameEN": "PRD-3 Cover Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบปะหน้า)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD53", "ReportNameEN": "PRD-53 Cover Report", "ReportNameTH": "รายงานนำส่ง หัก ณ ที่จ่าย ภ.ง.ด.53 (ใบปะหน้า)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD3D", "ReportNameEN": "PRD-3 Detail Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.3 (ใบแนบ)" },
        { "ReportType": "STD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PRD53D", "ReportNameEN": "PRD-53 Detail Report", "ReportNameTH": "รายงานนำส่งหัก ณ ที่จ่าย ภ.ง.ด.53 (ใบแนบ)" },
        { "ReportType": "ADD", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CASHFLOW", "ReportNameEN": "Cash Flow", "ReportNameTH": "รายงานงบกระแสเงินสด" },
        { "ReportType": "FIX", "ReportGroup": "FIN", "ReportAuthor": "1,2,6,98,99", "ReportCode": "VENDSUMMARY", "ReportNameEN": "Vender Summary Report", "ReportNameTH": "รายงานสรุปจ่ายเจ้าหนี้" },
        { "ReportType": "EXP", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBCOST", "ReportNameEN": "Job Costing Summary", "ReportNameTH": "รายงานสรุปต้นทุนตามจ๊อบ" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBPROFIT", "ReportNameEN": "Job Costing And Profit", "ReportNameTH": "รายงานกำไรขั้นต้นตามจ๊อบ" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "VATSALES", "ReportNameEN": "Sales VAT Report", "ReportNameTH": "รายงานภาษีขาย" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "VATBUY", "ReportNameEN": "Purchase VAT Report", "ReportNameTH": "รายงานภาษีซื้อ" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ACCEXP", "ReportNameEN": "Account Payable Report", "ReportNameTH": "รายงานค่าใช้จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ACCINC", "ReportNameEN": "Account Receiable Report", "ReportNameTH": "รายงานรายได้" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ARBAL", "ReportNameEN": "Accrue Income Report", "ReportNameTH": "รายงานลูกหนี้คงเหลือ" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "APBAL", "ReportNameEN": "Accrue Expense Report", "ReportNameTH": "รายงานเจ้าหนี้คงค้าง" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "APBILL", "ReportNameEN": "Billing Expense Report", "ReportNameTH": "รายงานบิลค่าใช้จ่าย" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CNDN", "ReportNameEN": "Credit/Debit Note Report", "ReportNameTH": "รายงานการปรับปรุงหนี้" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "PVDAILY", "ReportNameEN": "Payment Voucher Report", "ReportNameTH": "รายงานใบสำคัญจ่ายรายวัน" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "RVDAILY", "ReportNameEN": "Receive Voucher Report", "ReportNameTH": "รายงานใบสำคัญรับรายวัน" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "GROSSPROFIT", "ReportNameEN": "Gross Profit Report", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามประเภทงาน" },
        { "ReportType": "ADD", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CUSTPROFIT", "ReportNameEN": "Customer Profit Report", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามลูกค้า" },
        { "ReportType": "EXP", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "SETAR", "ReportNameEN": "SAP AR Input Report", "ReportNameTH": "รายงานตั้งลูกหนี้ SAP" },
        { "ReportType": "EXP", "ReportGroup": "ACC", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CUTAR", "ReportNameEN": "SAP AR Payment Report", "ReportNameTH": "รายงานตัดรับชำระหนี้ SAP" },
        { "ReportType": "FIX", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "ADVTOTAL", "ReportNameEN": "Details of Advance Payment By Job Order", "ReportNameTH": "รายงานการเบิกค่าใช้จ่ายแยกตามประเภท" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "BUYRATE", "ReportNameEN": "Buy Rates By Broker", "ReportNameTH": "รายงานการเปรียบเทียบราคาต้นทุนแต่ละผู้ให้บริการ" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "CUSTSUMMARY", "ReportNameEN": "PNL By Customer", "ReportNameTH": "รายงานสรุปกำไรขั้นต้นตามลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBSUMMARY", "ReportNameEN": "PNL By Job Order", "ReportNameTH": "รายงานสรุปกำไรขาดทุนตามจ๊อบ" },
        { "ReportType": "FIX", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBDETAIL", "ReportNameEN": "Details of PNL By Job Order", "ReportNameTH": "รายงานรายละเอียดกำไรขั้นต้นตามจ๊อบ" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT01", "ReportNameEN": "Outstanding Job Order By Customer", "ReportNameTH": "รายงานสรุปงานคงค้างตามลูกค้า" },
        { "ReportType": "STD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT02", "ReportNameEN": "Outstanding Job Order By Customer Service", "ReportNameTH": "รายงานสรุปงานคงค้างตามพนักงานบริการลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT03", "ReportNameEN": "Job Order Status", "ReportNameTH": "รายงานประเมินผลสถานะการปฏิบัติงาน" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT04", "ReportNameEN": "Outstanding Job By Customer/Waiting for Billing", "ReportNameTH": "รายงานติดตามผลการดำเนินงาน" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT05", "ReportNameEN": "Outstanding Advance By Job", "ReportNameTH": "รายงานติดตามการเบิกค่าใช้จ่ายตามจ๊อบ" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT06", "ReportNameEN": "Advance By Activity Summary By Customer", "ReportNameTH": "รายงานติดตามการเบิกค่าใช้จ่ายตามลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT07", "ReportNameEN": "Outstanding Advance By Activity Based-Deposit", "ReportNameTH": "รายงานติดตามเงินมัดจำ" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT08", "ReportNameEN": "Billing Report By Customer", "ReportNameTH": "รายงานติดตามการออกใบแจ้งหนี้ตามลูกค้า" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT09", "ReportNameEN": "Payment By Vender by Job Order", "ReportNameTH": "รายงานค่าใช้จ่ายเจ้าหนี้ตามจ๊อบงาน" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT10", "ReportNameEN": "A/P Accural Report", "ReportNameTH": "รายงานค่าใช้จ่ายรอการจ่าย" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,6,99", "ReportCode": "MGMT11", "ReportNameEN": "A/R Accural Report", "ReportNameTH": "รายงานรายได้รอการวางบิล" },
        { "ReportType": "EXP", "ReportGroup": "MAS", "ReportAuthor": "1,6,99", "ReportCode": "USERS", "ReportNameEN": "User Lists", "ReportNameTH": "รายชื่อผู้ใช้งาน" },
        { "ReportType": "EXP", "ReportGroup": "MAS", "ReportAuthor": "1,6,99", "ReportCode": "CUSTOMERS", "ReportNameEN": "Customer Lists", "ReportNameTH": "รายชื่อลูกค้า" },
        { "ReportType": "EXP", "ReportGroup": "MAS", "ReportAuthor": "1,6,99", "ReportCode": "VENDERS", "ReportNameEN": "Vender Lists", "ReportNameTH": "รายชื่อผู้ให้บริการ" },
        { "ReportType": "EXP", "ReportGroup": "MAS", "ReportAuthor": "1,6,99", "ReportCode": "SERVICES", "ReportNameEN": "Services Lists", "ReportNameTH": "รายการรหัสงานบริการ" },
        { "ReportType": "EXP", "ReportGroup": "MAS", "ReportAuthor": "1,6,99", "ReportCode": "AUTHORIZE", "ReportNameEN": "User Authorized Lists", "ReportNameTH": "รายการสิทธิผู้ใช้งาน" },
        { "ReportType": "ADD", "ReportGroup": "EXE", "ReportAuthor": "1,2,6,98,99", "ReportCode": "JOBCOUNTIM", "ReportNameEN": "Customer Job Count Report", "ReportNameTH": "รายงานสรุปจำนวนจ๊อบตามลูกค้า" },
        { "ReportType": "STD", "ReportCode": "PRD53AD", "ReportGroup": "FIN", "ReportNameTH": "รายงานนำส่งหักณที่จ่ายภ.ง.ด.53กระทำการแทน(ใบแนบ)", "ReportNameEN": "PRD-53 DetailReport(Agent)", "ReportAuthor": "1,2,6,98,99", "ReportUrl": "" },
        { "ReportType": "STD", "ReportCode": "PRD3AD", "ReportGroup": "FIN", "ReportNameTH": "รายงานนำส่งหักณที่จ่ายภ.ง.ด.3กระทำการแทน(ใบแนบ)", "ReportNameEN": "PRD-3 DetailReport(Agent)", "ReportAuthor": "1,2,6,98,99", "ReportUrl": "" },
        { "ReportType": "STD", "ReportCode": "PRD53A", "ReportGroup": "FIN", "ReportNameTH": "รายงานนำส่งหักณที่จ่ายภ.ง.ด.53กระทำการแทน(ใบปะหน้า)", "ReportNameEN": "PRD-53CoverReport(Agent)", "ReportAuthor": "1,2,6,98,99", "ReportUrl": "" },
        { "ReportType": "STD", "ReportCode": "PRD3A", "ReportGroup": "FIN", "ReportNameTH": "รายงานนำส่งหักณที่จ่ายภ.ง.ด.3กระทำการแทน(ใบปะหน้า)", "ReportNameEN": "PRD-3CoverReport(Agent)", "ReportAuthor": "1,2,6,98,99", "ReportUrl": "" },
        {"ReportType":"ADD","ReportCode":"ARBAL2","ReportGroup":"ACC","ReportNameTH":"รายงานลูกหนี้รับชำระแล้ว","ReportNameEN":"Accrue Income Report(Received)","ReportAuthor":"1,2,6,98,99","ReportUrl":""},
        {"ReportType":"ADD","ReportCode":"ARBAL3","ReportGroup":"ACC","ReportNameTH":"รายงานลูกหนี้ค้างชำระเกินดิว","ReportNameEN":"Accrue Income Report(Overdue)","ReportAuthor":"1,2,6,98,99","ReportUrl":""},
        {"ReportType":"ADD","ReportCode":"ARBAL4","ReportGroup":"ACC","ReportNameTH":"รายงานลูกหนี้ไม่ถึงดิวชำระ","ReportNameEN":"Accrue Income Report(No%20pay)","ReportAuthor":"1,2,6,98,99","ReportUrl":""},
        {"ReportType":"ADD","ReportCode":"ARBAL5","ReportGroup":"ACC","ReportNameTH":"รายงานลูกหนี้ค้างชำระทั้งหมด","ReportNameEN":"Accrue Income Report(WAIT%20FOR%20PAY)","ReportAuthor":"1,2,6,98,99","ReportUrl":""}
    ];
}
function ChangeLanguage(code, module) {
    ShowWait();
    mainLanguage = code;
    $.get(path + 'Config/SetLanguage?data=' + mainLanguage)
        .done(function () {
            SetLanguage(langMenu);
            ChangeLanguageForm(module);
            CloseWait();
        });
}
function ChangeLanguageForm(fname) {
    let lang = GetLangForm(fname);
    if (lang !== null) {
        if (fname == 'MODULE_REP/Index') {
            let reportLists = GetReportLists_V2();
            let group = $('#cboReportGroup').val();
            if (group == null || group == '') {
                group = 'N/A';
                let reportGroups = GetReportGroups();
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
                destroy: true
                , pageLength: 100
            });
        } else {
            SetLanguage(lang);
            ChangeLanguageGrid(fname, '#tbInvoice');
            ChangeLanguageGrid(fname, '#tbCost');
            ChangeLanguageGrid(fname, '#tbData');
            ChangeLanguageGrid(fname, '#tbCheque');
            ChangeLanguageGrid(fname, '#tbDocument');
            ChangeLanguageGrid(fname, '#tbHeader');
            ChangeLanguageGrid(fname, '#tbDetail');
            ChangeLanguageGrid(fname, '#tbItem');
            ChangeLanguageGrid(fname, '#tbMenu');
            ChangeLanguageGrid(fname, '#tbRole');
            ChangeLanguageGrid(fname, '#tbAuthor');
            ChangeLanguageGrid(fname, '#tbPrice');
            ChangeLanguageGrid(fname, '#tbDetail');
            ChangeLanguageGrid(fname, '#lstPlace1');
            ChangeLanguageGrid(fname, '#lstPlace2');
            ChangeLanguageGrid(fname, '#lstPlace3');
            ChangeLanguageGrid(fname, '#lstPlace4');
            ChangeLanguageGrid(fname, '#tblData');
            ChangeLanguageGrid(fname, '#tbBalance');
            ChangeLanguageGrid(fname, '#tbExpense');
            ChangeLanguageGrid(fname, '#tbPayment');
            ChangeLanguageGrid(fname, '#tbTracking');
            ChangeLanguageGrid(fname, '#tbLog');
            ChangeLanguageGrid(fname, '#tblJob');
            ChangeLanguageGrid(fname, '#tbAdvance');
            ChangeLanguageGrid(fname, '#tbPolicy');
            ChangeLanguageGrid(fname, '#tbControl');
            ChangeLanguageGrid(fname, '#tbSummary');
        }
    }
}
function ChangeLanguageGrid(module, id) {
    let lang = GetLangGrid(module, id);
    SetGridLang(id, lang);
}