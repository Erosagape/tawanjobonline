INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'ADV', N'Credit Advances', N'1030', 1, 0, 0, 0, 1, 0, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'CST', N'Costs', N'5000', 1, 0, 0, 0, 0, 1, 0, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'ERN', N'Earnests', N'1910', 1, 0, 0, 0, 0, 1, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'FR0', N'Freights (NO-WHT)', N'4050', 1, 2, 0, 0, 1, 0, 1, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'FR1', N'Freights (WHT)', N'4050', 1, 1, 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'SRV', N'Services (Vat 7,WHT 3)', N'4010', 1, 1, 1, 3, 0, 0, 0, 0)
GO
INSERT [dbo].[Job_SrvGroup] ([GroupCode], [GroupName], [GLAccountCode], [IsApplyPolicy], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsHaveSlip], [IsLtdAdv50Tavi]) VALUES (N'TRN', N'Transportations', N'4060', 1, 0, 1, 1, 1, 0, 1, 1)
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-001', N'ค่าภาษีอากร', N'Duty And Taxes', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-002', N'ค่าระวางเรือ', N'Sea Frieght', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-003', N'ค่า D/O', N'Delivery Order', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-004', N'ค่า B/L', N'Bill of Lading', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-005', N'ค่าแรงงาน', N'Labour charges', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-006', N'ค่าล้างตู้', NULL, 200, N'CNTR', N'THB', N'MOL', NULL, NULL, NULL, 2, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'ADV-007', N'ค่าซ่อมตู้', NULL, 1500, N'CTNR', N'THB', N'APLT', NULL, NULL, NULL, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, N'ADV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'CST-001', N'ค่าขนส่ง', N'Transport cost', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, N'CST')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-001', N'ค่าบริการขาเข้า', N'Service Charges Import', 3000, N'SHP', N'THB', NULL, NULL, NULL, NULL, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-002', N'ค่าบริการขาออก', N'Export Service Charges', 3000, N'SHP', N'THB', NULL, NULL, NULL, NULL, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-003', N'ค่า THC', N'Terminal Handing Charges', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 1, 1, 3, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Job_SrvSingle] ([SICode], [NameThai], [NameEng], [StdPrice], [UnitCharge], [CurrencyCode], [DefaultVender], [ProcessDesc], [GLAccountCodeSales], [GLAccountCodeCost], [IsTaxCharge], [Is50Tavi], [Rate50Tavi], [IsCredit], [IsExpense], [IsShowPrice], [IsHaveSlip], [IsPay50TaviTo], [IsLtdAdv50Tavi], [IsUsedCoSlip], [GroupCode]) VALUES (N'SRV-004', N'ค่าขนส่ง', N'Transport charges', 0, N'SHP', N'THB', NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, N'SRV')
GO
INSERT [dbo].[Mas_Branch] ([Code], [BrName]) VALUES (N'00', N'สำนักงานใหญ่')
GO
INSERT [dbo].[Mas_Branch] ([Code], [BrName]) VALUES (N'01', N'แหลมฉบัง')
GO
INSERT [dbo].[Mas_Branch] ([Code], [BrName]) VALUES (N'02', N'สุวรรณภูมิ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'01', N'REQUEST')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'02', N'APPROVE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'03', N'PAYMENT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'04', N'PART-CLEARING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'05', N'FULL-CLEARING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'06', N'CLEARED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_STATUS', N'99', N'CANCELLED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'01', N'ค่าใช้จ่ายการเตรียมงาน (C/S)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'02', N'ค่าดำเนินการทางพิธีการ (C/S)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'03', N'ค่าใช้จ่ายในระหว่างการตรวจปล่อย (S/P)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'ADV_TYPE', N'04', N'ค่าใช้จ่ายอื่นๆ หลังการตรวจปล่อย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'C', N'CHECKING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'P', N'PASS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CHQ_STATUS', N'R', N'RETURN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'1', N'Marketing Dept.')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'2', N'Customer Services')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'3', N'Shipping Dept')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'4', N'Financial Dept')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'5', N'Accounting Dept')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_FROM', N'6', N'IT Administration Dept')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'01', N'REQUEST')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'02', N'APPROVED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'03', N'CLEARED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'04', N'BILLED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_STATUS', N'99', N'CANCEL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'1', N'Advance')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'2', N'Cost (Non-advance)')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CLR_TYPE', N'3', N'Services')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'RT', N'RETAIL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMMERCIAL_LEVEL', N'WO', N'WHOLESALER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'AG', N'AGENT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'CO', N'CONSIGNEE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'DI', N'DISTRIBUTOR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'FW', N'FORWARDER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'MA', N'MANUFACTURERS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'OT', N'OTHERS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'TR', N'TRANSPORTER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'COMPANY_TYPE', N'VE', N'VENDER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'CONSIGNEE', N'ผู้ซื้อขาย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'CUSTOMERS', N'ลูกค้าทั่วไป')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'INTERNAL', N'หน่วยงานภายใน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'NOTIFY_PARTY', N'ผู้รับส่งสินค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'PERSON', N'บุคคลทั่วไป')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_GROUP', N'PROSPECT', N'ผู้มุ่งหวัง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_TYPE', N'0', N'LOCAL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMER_TYPE', N'1', N'FOREIGN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_19BIS', N'BG', N'BANK GUARANTEE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_19BIS', N'CA', N'CASH')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_19BIS', N'DD', N'DRAFT DEPOSIT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'AF', N'AFTA')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'NX', N'TAX EXCEPTS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'OT', N'OTHERS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_EXPENSES', N'TX', N'TAX PAID')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_PRIVILEGE', N'CB', N'CUSTOMS BROKER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'CUSTOMS_PRIVILEGE', N'GC', N'GOLD CARD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_ACC', N'G', N'GL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_ACC', N'P', N'PV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_ACC', N'R', N'RV')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'ADV', N'ADVANCE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'CLR', N'CLEARING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'INV', N'INVOICE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'DOCUMENT_TYPE', N'PAY', N'BILL PAYMENT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'00', N'PENDING CONFIRM')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'01', N'WAIT FOR OPERATION')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'02', N'WAIT FOR CLEAR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'03', N'WORKING FINISHED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'04', N'EXPENSES CLEARED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'05', N'BILLING INCOMPLETE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'06', N'BILLING COMPLETED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'07', N'JOB COMPLETED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'98', N'HOLD FOR CHECKING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_STATUS', N'99', N'JOB CANCELLED')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'ACC', N'Accounting')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'ADM', N'Admin')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'ADV', N'Advance Request')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'CLR', N'Advance Clearing')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'CS', N'Job Control')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'MAS', N'Master Files')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'REP', N'Reports & Analysis')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE', N'SALES', N'Marketing')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'AccountCode', N'ผังบัญชี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Adjustment', N'รายการปรับปรุง')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Approve', N'อนุมัติรายการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Billing', N'ใบวางบิล')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Cheque', N'รับเช็คล่วงหน้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Costing', N'ต้นทุนค่าบริการค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'CreditNote', N'ใบเพิ่มหนี้/ลดหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Expense', N'บิลค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'GenerateInv', N'สร้างใบแจ้งหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'GLNote', N'สมุุดรายวัน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Invoice', N'ใบแจ้งหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Payment', N'จ่ายเงินตามบิลค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'PettyCash', N'เงินสดย่อย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Receipt', N'ใบเสร็จรับเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'RecvInv', N'รับชำระตามใบแจ้งหนี้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'TaxInvoice', N'ใบกำกับภาษี')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'Voucher', N'ข้อมูลการรับ/จ่ายเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ACC', N'WHTax', N'ใบหัก ณ ที่จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADM', N'FileManager', N'File Manager')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADM', N'Role', N'บทบาทผู้ใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADM', N'SQLAdmin', N'SQL Administrator')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'Approve', N'อนุมัติใบเบิกค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'CreditAdv', N'เบิกเงินสดย่อย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'EstimateCost', N'ประมาณการค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'Index', N'ใบเบิกค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_ADV', N'Payment', N'จ่ายเงินตามใบเบิกค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Approve', N'อนุมัติใบปิดค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Earnest', N'เคลียร์เงินมัดจำตู้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Index', N'ใบปิดค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CLR', N'Receive', N'รับเคลียร์เงินจากใบปิดค่าใช้จ่าย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'CreateJob', N'เปิดงานใหม่')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Index', N'ค้นหางาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'ShowJob', N'รายละเอียดงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_CS', N'Transport', N'ใบจองรถ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Bank', N'ธนาคาร')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'BookAccount', N'สมุดบัญชีธนาคาร')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Branch', N'สาขา')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'BudgetPolicy', N'มาตรฐานค่าบริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'CompanyContact', N'รายชื่อผู้ติดต่อ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Country', N'ประเทศ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Currency', N'สกุลเงิน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Customers', N'ผู้นำเข้าส่งออก')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'CustomsPort', N'ท่าที่ตรวจปล่อย')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'CustomsUnit', N'หน่วยสินค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'DeclareType', N'ประเภทใบขนสินค้า')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Index', N'ค่าคงที่ระบบ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'InterPort', N'ท่าต่างประเทศ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Province', N'จังหวัด/อำเภอ/ตำบล')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'ServiceCode', N'ค่าบริการต่างๆ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'ServiceGroup', N'กลุ่มค่าบริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'ServUnit', N'หน่วยการบริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'UserAuth', N'สิทธิการใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Users', N'ผู้ใช้งาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Venders', N'ผู้ให้บริการ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_MAS', N'Vessel', N'ชื่อพาหนะ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Export', N'ส่งออกข้อมูล')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Import', N'นำเข้าข้อมูล')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Index', N'รายงานต่างๆ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_REP', N'Tracking', N'ตรวจสอบสถานะงาน')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_SALES', N'QuoApprove', N'อนุมัติใบเสนอราคา')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'MODULE_SALES', N'Quotation', N'ใบเสนอราคา')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CA', N'Cash/Transfer')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CH', N'Cashier Cheque')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CR', N'Credit')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PAYMENT_TYPE', N'CU', N'Customer Cheque')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS1', N'เลขที่ 5/17 สุขุมวิท 54 แขวงพระโขนงไต้')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_ADDRESS2', N'เขตพระโขนง กทม 10260')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_EMAIL', N'all@tawantech.co.th')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_FAX', N'02-7159988')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_LOGO', N'logo-tawan.jpg')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_NAME', N'บริษัท ตะวันเทคโนโลยี จำกัด')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TAXBRANCH', N'00000')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TAXNUMBER', N'0105544112818')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'COMPANY_TEL', N'02-7159598')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'CURRENCY', N'THB')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'DEFAULT_BRANCH', N'00')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'DEFAULT_LANGUAGE', N'TH')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'PAYMENT_CREDIT_DAYS', N'30')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'PROFILE', N'VATRATE', N'0.07')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'EXP', N'Expenses')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'INC', N'Income')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SERVICE_TYPE', N'STD', N'Standard Services')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'01', N'Managing director')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'02', N'Manager')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'03', N'Sales')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'04', N'Customer Services')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'05', N'Shipping')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'06', N'Accounting')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'98', N'Others')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'USER_LEVEL', N'99', N'Administrators')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'01', N'IMPORT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'02', N'EXPORT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'03', N'DOMESTIC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'04', N'C/O')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'05', N'BANKING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'06', N'OFFICE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'07', N'SUPPORT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'08', N'FREIGHT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'JOB_TYPE', N'99', N'GENERAL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'01', N'AIR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'02', N'SEA')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'03', N'TRUCK')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'04', N'TRAIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'05', N'PARCEL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'06', N'PASSENGER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'07', N'19BIS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'08', N'MACHINE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'09', N'CONSIGNMENT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'10', N'LOCAL')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'11', N'TRANSFER-IN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'12', N'TRANSFER-OUT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'13', N'REFUND-TAX')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'14', N'BOI')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'15', N'RE-EXPORT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'16', N'FORMULA')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'17', N'TAX-RETURN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'18', N'FORM-A')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'19', N'FORM-D')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'20', N'FORM-E')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'21', N'FORM-CO')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'22', N'CHAMBER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'23', N'FORM-AI')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'24', N'FORM-AK')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'25', N'TEXTTILE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'26', N'THAI-AUS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'27', N'JTEPA')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'28', N'MEXICO')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'29', N'ANNZ')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'30', N'REGISTER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'31', N'BANKING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'32', N'LEGALIZE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'33', N'INSURANCE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'34', N'COURIER')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'35', N'MARGETING')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'36', N'FREIGHT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'37', N'DOCUMENT')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'38', N'WAREHOUSE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'39', N'LABOUR')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'40', N'MILK-RUN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'41', N'FREEZONE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'42', N'YARD')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'43', N'SUPPLY-CHAIN')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'44', N'CUSTOMER-SERVICE')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'45', N'OTHERS')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'46', N'AIR-IMP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'47', N'AIR-EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'48', N'SEA-IMP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'49', N'SEA-EXP')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY', N'50', N'DOMESTIC')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'01', N'01,02,03,04,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'02', N'01,02,03,04,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'03', N'01,02,03,04,07,08,10,13,14,15,16,17,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'04', N'18,19,20,21,22,23,24,25,26,27,28,29,30,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'05', N'31,32,33,37,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'06', N'30,35,36,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'07', N'09,37,38,39,40,45')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'08', N'01,02,41,45,46,47,48,49,50')
GO
INSERT [dbo].[Mas_Config] ([ConfigCode], [ConfigKey], [ConfigValue]) VALUES (N'SHIP_BY_FILTER', N'99', N'09,10,37,38,40,42,43,44,45')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'ACM', N'acm', N'ผู้จัดการฝ่ายบัญชี', N'Account Manager', N'ACC-MGR', NULL, NULL, NULL, NULL, 2, 0, 0, NULL, N'account@tawantech.co.th', NULL, 0, 0, 0, N'BOAT', NULL, N'TH', NULL, NULL, NULL, NULL, N'5')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'ADMIN', N'1234', N'ADMINISTRATOR', N'ADMINISTRATOR', N'ADMINISTRATOR', NULL, NULL, NULL, NULL, 99, 0, 0, N'11111111111111111', N'', N'', 1, 0, 0, N'', N'', N'TH', N'', N'', N',01,02,03,04,05,06', N',01,02,03,04', N'6')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'BOAT', N'4780', N'พุทธิพงษ์ คงพ่วง', N'Phuthipong Kongpoung', N'IT', NULL, NULL, NULL, NULL, 99, 0, 0, N'', N'puttipong@tawantech.co.th', N'0823320506', 0, 0, 0, N'ADMIN', N'', N'EN', N'', N'', N'', N'', N'6')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'CASH1', N'cash1', N'แคชเชียร์', N'Cashier 1', N'finance', NULL, NULL, NULL, NULL, 6, 0, 0, N'', N'', N'', 0, 0, 0, N'ACM', N'', N'TH', N'', N'', N'', N'', N'4')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'CS', N'CS', N'นางสาวรักดี ใฝ่เรียน', N'Miss Rukdee Fairean', N'CS Import', NULL, NULL, NULL, NULL, 4, 0, 0, N'', N'cs@tawantech.co.th', N'02-9989898', 0, 0, 0, N'BOAT', N'', N'TH', N'', N'', N'', N'', N'2')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'pasit', N'1234', N'pasit', N'', N'', NULL, NULL, NULL, NULL, 99, 0, 0, N'', N'', N'', 0, 0, 0, N'', N'', N'TH', N'', N'', N'', N'', N'6')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'SHP', N'shp', N'ชิปปิ้ง', N'Shipping', N'Shipping Import', NULL, NULL, NULL, NULL, 5, 0, 0, N'', N'', N'', 0, 0, 0, N'BOAT', N'', N'TH', N'', N'', N'', N'', N'3')
GO
INSERT [dbo].[Mas_User] ([UserID], [UPassword], [TName], [EName], [TPosition], [LoginDate], [LoginTime], [LogoutDate], [LogoutTime], [UPosition], [MaxRateDisc], [MaxAdvance], [JobAuthorize], [EMail], [MobilePhone], [IsAlertByAgent], [IsAlertByEMail], [IsAlertBySMS], [UserUpline], [GLAccountCode], [UsedLanguage], [DMailAccount], [DMailPassword], [JobPolicy], [AlertPolicy], [DeptID]) VALUES (N'test', N'test', N'พนักงานทดสอบ', N'test user', N'', NULL, NULL, NULL, NULL, 2, 0, 0, N'', N'', N'', 0, 0, 0, N'ADMIN', N'', N'', N'', N'', N'', N'', N'1')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'GLNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_ADV', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CLR', N'Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CLR', N'Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ACM', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Approve', N'MIREDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'GLNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADM', N'FileManager', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_ADM', N'Role', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_ADV', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CLR', N'Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Bank', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_MAS', N'Branch', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Country', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Currency', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Customers', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_MAS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'InterPort', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Province', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_MAS', N'Users', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Venders', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_MAS', N'Vessel', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Dashboard', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_REP', N'Export', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'admin', N'MODULE_REP', N'Import', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_REP', N'Reports', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'ADMIN', N'MODULE_SALES', N'Quotation', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Approve', N'MIREDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'GLNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADM', N'FileManager', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADM', N'Role', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADV', N'Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_ADV', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CLR', N'Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CLR', N'Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CLR', N'Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Bank', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Branch', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'CompanyContact', N'MIREDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Country', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Currency', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Customers', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'InterPort', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Province', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Users', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Venders', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_MAS', N'Vessel', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_REP', N'Dashboard', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_REP', N'Export', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_REP', N'Import', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_REP', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_REP', N'Reports', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'BOAT', N'MODULE_SALES', N'Quotation', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_ADV', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CLR', N'Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CLR', N'Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CASH1', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'CS', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'AccountCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Adjustment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'CreditNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'GLNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADM', N'FileManager', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADM', N'Role', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADM', N'SQLAdmin', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADV', N'Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_ADV', N'Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CLR', N'Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CLR', N'Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CLR', N'Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Bank', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'BookAccount', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Branch', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'BudgetPolicy', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'CompanyContact', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Country', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Currency', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Customers', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'CustomsPort', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'CustomsUnit', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'DeclareType', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'InterPort', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Province', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'ServiceCode', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'ServiceGroup', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'ServUnit', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'UserAuth', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Users', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Venders', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_MAS', N'Vessel', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_REP', N'Dashboard', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_REP', N'Export', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_REP', N'Import', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_REP', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_REP', N'Reports', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_SALES', N'QuoApprove', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'pasit', N'MODULE_SALES', N'Quotation', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_ACC', N'Invoice', N'MIR')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_ACC', N'WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_ADV', N'CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_ADV', N'EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_ADV', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_CLR', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_CS', N'CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_CS', N'Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_CS', N'ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserAuth] ([UserID], [AppID], [MenuID], [Author]) VALUES (N'test', N'MODULE_CS', N'Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'ACC', N'Accounting Staff', 5)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'ACC-MGR', N'Accounting Manager', 5)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CS', N'Customer Services Staff', 2)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'CS-MGR', N'Customer Services Manager', 2)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'FIN', N'Finance Staff', 4)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'FIN-MGR', N'Finance Manager', 4)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'IT', N'IT Department', 6)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'IT_MGR', N'IT MANAGER', 6)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'MGT', N'Marketing Staff', 1)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'MGT-MGR', N'Marketing Manager', 1)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'SP', N'Shipping Staff', 3)
GO
INSERT [dbo].[Mas_UserRole] ([RoleID], [RoleDesc], [RoleGroup]) VALUES (N'SP-MGR', N'Shipping Manager', 3)
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'ACM')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'BOAT')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'ACM')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'ACC-MGR', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'BOAT')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'CS')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS', N'test')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'BOAT')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'CS-MGR', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'ACM')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'BOAT')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'CASH1')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'FIN-MGR', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'BOAT')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'IT', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'MGT-MGR', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP', N'pasit')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'ADMIN')
GO
INSERT [dbo].[Mas_UserRoleDetail] ([RoleID], [UserID]) VALUES (N'SP-MGR', N'pasit')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Adjustment', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Cheque', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/CreditNote', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/GLNote', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Payment', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/PettyCash', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Receipt', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/RecvInv', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/TaxInvoice', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ACC/WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_ADV/Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CLR/Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CLR/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CLR/Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/ShowJob', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC', N'MODULE_CS/Transport', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/AccountCode', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Adjustment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/CreditNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/GLNote', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_ACC/Voucher', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_CS/Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_MAS/BookAccount', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'ACC-MGR', N'MODULE_MAS/BudgetPolicy', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ACC/WHTax', N'MIREP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ADV/CreditAdv', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ADV/EstimateCost', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_ADV/Index', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CLR/Index', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/ShowJob', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS', N'MODULE_CS/Transport', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ACC/Costing', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_ADV/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CLR/Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CLR/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CS/ShowJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'CS-MGR', N'MODULE_CS/Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Billing', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Cheque', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Costing', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Expense', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/GenerateInv', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Invoice', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Payment', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/PettyCash', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Receipt', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/RecvInv', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/TaxInvoice', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/Voucher', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ACC/WHTax', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_ADV/Payment', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CLR/Earnest', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CLR/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CLR/Receive', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/CreateJob', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/ShowJob', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN', N'MODULE_CS/Transport', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Billing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Cheque', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Costing', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Expense', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/GenerateInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Invoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/PettyCash', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Receipt', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/RecvInv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/TaxInvoice', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_ACC/Voucher', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_CLR/Earnest', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_CLR/Receive', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'FIN-MGR', N'MODULE_CS/Transport', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ACC/AccountCode', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ACC/Expense', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ACC/Payment', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ADM/FileManager', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ADM/Role', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_ADM/SQLAdmin', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Bank', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/BookAccount', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Branch', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/BudgetPolicy', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Country', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Currency', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Customers', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/CustomsPort', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/CustomsUnit', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/DeclareType', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Index', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/InterPort', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Province', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/ServiceCode', N'MR')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/ServiceGroup', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/ServUnit', N'MIRE')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/UserAuth', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Users', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Venders', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_MAS/Vessel', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Dashboard', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Export', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Import', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Index', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_REP/Reports', N'M')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_SALES/QuoApprove', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'IT', N'MODULE_SALES/Quotation', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT', N'MODULE_ADV/CreditAdv', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT', N'MODULE_ADV/EstimateCost', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT', N'MODULE_SALES/Quotation', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_ADV/CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_ADV/EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_MAS/BudgetPolicy', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_MAS/CompanyContact', N'MIREDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_SALES/QuoApprove', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'MGT-MGR', N'MODULE_SALES/Quotation', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_ADV/CreditAdv', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_ADV/EstimateCost', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_ADV/Index', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CLR/Index', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/ShowJob', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP', N'MODULE_CS/Transport', N'MEIRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ACC/Costing', N'MRP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/CreditAdv', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/EstimateCost', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_ADV/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_CLR/Approve', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_CLR/Index', N'MEIRDP')
GO
INSERT [dbo].[Mas_UserRolePolicy] ([RoleID], [ModuleID], [Author]) VALUES (N'SP-MGR', N'MODULE_CS/Transport', N'MEIRDP')
GO
